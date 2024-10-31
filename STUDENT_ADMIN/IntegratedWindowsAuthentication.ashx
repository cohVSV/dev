<!-- 9 Aug 2021|RW| Changes added to apply a hybrid of Windows and Forms authentication
This file needs to be configured for Windows authentication, and within web.config it's set as the loginUrl for Forms authentication.
So, unauthenticated student database users will always be directed to it.
When it kicks in, the page will pick up the user's Windows auth and feed those credentials to the Forms auth tickets.
It will also set up the session variables containing the user's AD groups as well as their regular CodeCharge security group membership.
Important: this file must be individually selected and marked as requiring Integrated Windows Auth in IIS, and
   anonymous auth disabled for it.
-->

<%@ WebHandler Language="VB" Class="IntegratedWindowsAuthentication" %>


Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Security
Imports System.DirectoryServices.AccountManagement
Imports System.DirectoryServices
Imports System.Threading



Public Class IntegratedWindowsAuthentication : Implements IHttpHandler, IRequiresSessionState

   Private Const LogoutUrlParameter = "Logout"
   Private Const CodeChargeReturnParameter = "ret_link"
   Private Const ErrorPage = "IntegratedWindowsAuthenticationError.aspx"
   Private Const ErrorParameterValue = "errorCode"
   Private Const ErrorWindowsAccountNotFoundParameterValue = "WindowsAccountNotFound"
   Private Const ErrorSDBAccountNotFoundParameterValue = "SDBAccountNotFound"
   Private Const ErrorSDBAccountInactiveParameterValue = "SDBAccountInactive"
   Private Const ErrorSDBAccountValidationFailedParameterValue = "SDBAccountValidationFailed"


   Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
      context.Response.ContentType = "text/plain"

      If Not IsNothing(context.Request(LogoutUrlParameter)) Then
         ' CodeCharge session variables
         context.Session.Remove(Common.UserIDSessionID)
         context.Session.Remove(Common.GroupIDSessionID)
         context.Session.Remove(Common.UserLoginSessionID)

         ' VSV access group session variable
         context.Session.Remove(Common.AccessGroupsSessionID)

         ' Active Directory groups session variable
         context.Session.Remove(Common.ActiveDirectoryGroupsSessionID)

         FormsAuthentication.SignOut()
      Else
         Dim environment = ConfigurationManager.AppSettings(Common.EnvironmentSettingName)
         Dim domainQualifiedUsername As String = Nothing
         If (environment.Equals(Common.DevelopmentEnvironmentName)) Then
            domainQualifiedUsername = System.Security.Principal.WindowsIdentity.GetCurrent().Name
         Else
            domainQualifiedUsername = context.User.Identity.Name
         End If
         Dim username = domainQualifiedUsername?.Replace(Common.WindowsDomain & "\", "")
         If (Not String.IsNullOrEmpty(username)) Then
            Dim credentials = Common.GetStudentDatabaseUserCredentials(username)
            If (credentials IsNot Nothing) Then
               If (credentials.Status) Then
                  ' Use CodeCharge's membership provider to validate the user, and in doing so initialise the user's session variables
                  If (Membership.ValidateUser(username, credentials.Password)) Then
                     ' Save the forms-based authentication credentials, via CodeCharge's method
                     SecurityUtility.SetSecurityCookies(username, credentials.Password, False)

                     context.Session(Common.AccessGroupsSessionID) = credentials.SecurityFunctions

                     ' AD groups
                     Dim securityGroups = Common.GetUserSecurityGroups(username).Select(Function(group) group.SamAccountName).ToHashSet()
                     context.Session(Common.ActiveDirectoryGroupsSessionID) = securityGroups

                     context.Session(Common.PermissionsLastRefreshTimeSessionID) = Date.Now

                     'DumpSecurityGroups(context, username, securityGroups)

                     Dim codeChargeReturnUrl = context.Request(CodeChargeReturnParameter)
                     If (String.IsNullOrEmpty(codeChargeReturnUrl)) Then
                        'context.Response.Write("Authentication credentials have been refreshed")
                        FormsAuthentication.RedirectFromLoginPage(username, False)
                     Else
                        'context.Response.Write("Authentication credentials have been refreshed.")
                        RedirectToUrl(context, codeChargeReturnUrl)
                     End If
                  Else
                     ' Forms validation failed, somehow
                     ' This shouldn't happen unless there's a bug, since our auth is feeding the user's stored dummy credentials straight back to Code Charge's
                     '   membership provider, which then checks the very same credentials.
                     RedirectToUrl(context, $"{ErrorPage}?{ErrorParameterValue}={ErrorSDBAccountValidationFailedParameterValue}")
                  End If
               Else
                  ' Inactive SDB user
                  RedirectToUrl(context, $"{ErrorPage}?{ErrorParameterValue}={ErrorSDBAccountInactiveParameterValue}")
               End If
            Else
               ' Non-existent SDB user
               RedirectToUrl(context, $"{ErrorPage}?{ErrorParameterValue}={ErrorSDBAccountNotFoundParameterValue}")
            End If
         Else
            ' Could not determine the signed in Windows user
            RedirectToUrl(context, $"{ErrorPage}?{ErrorParameterValue}={ErrorWindowsAccountNotFoundParameterValue}")
         End If
      End If
   End Sub


   Private Sub DumpSecurityGroups(context As HttpContext, username As String, securityGroups As IEnumerable(Of String))
      With context
         .Response.Write("You are signed in as:" & username & vbCrLf & vbCrLf)

         .Response.Write("You are a member of the following AD groups:" & vbCrLf & vbCrLf)
         For Each securityGroup In securityGroups
            .Response.Write(securityGroup)
            .Response.Write(vbCrLf)
         Next
      End With
   End Sub


   Private Sub RedirectToUrl(context As HttpContext, url As String)
      context.Response.Redirect(url, False)
      context.ApplicationInstance.CompleteRequest()
   End Sub


   Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
      Get
         Return False
      End Get
   End Property

End Class