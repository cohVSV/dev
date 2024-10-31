'CCPage class @0-DF232AFC
'Target Framework version is 3.5
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Web.UI.HtmlControls
Imports System.Security.Permissions
Imports System.Web.UI.WebControls
Imports DECV_PROD2007.Data

Namespace  DECV_PROD2007.Controls
    _
   Public Class CCPage
      Inherits Page
      Protected HtmlFormClientId As String
      Protected rm As System.Resources.ResourceManager
      Protected PageStyleName As String
      Protected ControlCustomValues As New NameValueCollection()
	  Protected PageVariables As New NameValueCollection()
      Public ControlAttributes As New AttributesContainer()
      
      Public Sub New()
      End Sub 'New



		Protected Overrides Sub OnInit(e As EventArgs)
		   MyBase.OnInit(e)
		   
		   If DBUtility.UserId Is Nothing AndAlso Page.User.Identity.IsAuthenticated Then
			  Dim password As String = CType(Page.User.Identity, FormsIdentity).Ticket.UserData
			  Dim login As String = CType(Page.User.Identity, FormsIdentity).Ticket.Name
			  Dim IsPersistent As Boolean = CType(Page.User.Identity, FormsIdentity).Ticket.IsPersistent
			  If DBUtility.CheckUser(login, password) Then
				 Security.SecurityUtility.SetSecurityCookies(login, password, IsPersistent)
				 If IsPostBack Then
					Response.Redirect(".")
				 End If
			  Else
				 Security.SecurityUtility.ClearSecurityCookies()
			  End If
		   End If
		   
		End Sub 
   End Class 
End Namespace 

'End CCPage class

