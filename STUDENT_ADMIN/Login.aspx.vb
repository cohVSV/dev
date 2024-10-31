'Using Statements @1-82FB19C3
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web
Imports System.IO
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
'End Using Statements

Namespace DECV_PROD2007.Login 'Namespace @1-46F8C514

'Forms Definition @1-A21F2BD0
Public Class [LoginPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-A783295C
    Protected LoginData As LoginDataProvider
    Protected LoginErrors As NameValueCollection = New NameValueCollection()
    Protected LoginOperations As FormSupportedOperations
    Protected LoginIsSubmitted As Boolean = False
    Protected LoginContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-D2F4F1CF
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            LoginShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form Login Parameters @2-D9F8FE7F

    Protected Sub LoginParameters()
        Dim item As new LoginItem
        Try
        Catch e As Exception
            LoginErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form Login Parameters

'Record Form Login Show method @2-D6168038
    Protected Sub LoginShow()
        If LoginOperations.None Then
            LoginHolder.Visible = False
            Return
        End If
        Dim item As LoginItem = LoginItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not LoginOperations.AllowRead
        LoginErrors.Add(item.errors)
        If LoginErrors.Count > 0 Then
            LoginShowErrors()
            Return
        End If
'End Record Form Login Show method

'Record Form Login BeforeShow tail @2-B0342B37
        LoginParameters()
        LoginData.FillItem(item, IsInsertMode)
        LoginHolder.DataBind()
        CType(Page,CCPage).ControlAttributes.Add(Loginlogin,New CCSControlAttribute("placeholder", FieldType._Text, ("eg. JSMITH")))
        Loginlogin.Text=item.login.GetFormattedValue()
        Loginpassword.Text=item.password.GetFormattedValue()
        If item.cb_remembermeCheckedValue.Value.Equals(item.cb_rememberme.Value) Then
            Logincb_rememberme.Checked = True
        End If
'End Record Form Login BeforeShow tail

'Record Login Event BeforeShow. Action Retrieve Value for Control @13-FEF32D83
            Loginlogin.Text = (New TextField("", (HttpContext.Current.User.Identity.Name.ToString()))).GetFormattedValue()
'End Record Login Event BeforeShow. Action Retrieve Value for Control

'Record Form Login Show method tail @2-66ED9A5C
        If LoginErrors.Count > 0 Then
            LoginShowErrors()
        End If
    End Sub
'End Record Form Login Show method tail

'Record Form Login LoadItemFromRequest method @2-1FB76729

    Protected Sub LoginLoadItemFromRequest(item As LoginItem, ByVal EnableValidation As Boolean)
        item.login.IsEmpty = IsNothing(Request.Form(Loginlogin.UniqueID))
        If ControlCustomValues("Loginlogin") Is Nothing Then
            item.login.SetValue(Loginlogin.Text)
        Else
            item.login.SetValue(ControlCustomValues("Loginlogin"))
        End If
        item.password.IsEmpty = IsNothing(Request.Form(Loginpassword.UniqueID))
        If ControlCustomValues("Loginpassword") Is Nothing Then
            item.password.SetValue(Loginpassword.Text)
        Else
            item.password.SetValue(ControlCustomValues("Loginpassword"))
        End If
        If Logincb_rememberme.Checked Then
            item.cb_rememberme.Value = (item.cb_remembermeCheckedValue.Value)
        Else
            item.cb_rememberme.Value = (item.cb_remembermeUncheckedValue.Value)
        End If
        If EnableValidation Then
            item.Validate(LoginData)
        End If
        LoginErrors.Add(item.errors)
    End Sub
'End Record Form Login LoadItemFromRequest method

'Record Form Login GetRedirectUrl method @2-A1DA256C

    Protected Function GetLoginRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Menu.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form Login GetRedirectUrl method

'Record Form Login ShowErrors method @2-8D57139A

    Protected Sub LoginShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To LoginErrors.Count - 1
        Select Case LoginErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & LoginErrors(i)
        End Select
        Next i
        LoginError.Visible = True
        LoginErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form Login ShowErrors method

'Record Form Login Insert Operation @2-E587F671

    Protected Sub Login_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LoginItem = New LoginItem()
        LoginIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Login Insert Operation

'Record Form Login BeforeInsert tail @2-7CCE846D
    LoginParameters()
    LoginLoadItemFromRequest(item, EnableValidation)
'End Record Form Login BeforeInsert tail

'Record Form Login AfterInsert tail  @2-361B687E
        ErrorFlag=(LoginErrors.Count > 0)
        If ErrorFlag Then
            LoginShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Login AfterInsert tail 

'Record Form Login Update Operation @2-F83A1796

    Protected Sub Login_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LoginItem = New LoginItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        LoginIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Login Update Operation

'Record Form Login Before Update tail @2-7CCE846D
        LoginParameters()
        LoginLoadItemFromRequest(item, EnableValidation)
'End Record Form Login Before Update tail

'Record Form Login Update Operation tail @2-361B687E
        ErrorFlag=(LoginErrors.Count > 0)
        If ErrorFlag Then
            LoginShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Login Update Operation tail

'Record Form Login Delete Operation @2-D90C191E
    Protected Sub Login_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        LoginIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As LoginItem = New LoginItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form Login Delete Operation

'Record Form BeforeDelete tail @2-7CCE846D
        LoginParameters()
        LoginLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-95FB8148
        If ErrorFlag Then
            LoginShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form Login Cancel Operation @2-6117E74F

    Protected Sub Login_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LoginItem = New LoginItem()
        LoginIsSubmitted = True
        Dim RedirectUrl As String = ""
        LoginLoadItemFromRequest(item, True)
'End Record Form Login Cancel Operation

'Record Form Login Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form Login Cancel Operation tail

'Button Button_DoLogin OnClick Handler @3-99AD5149
    Protected Sub Login_Button_DoLogin_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetLoginRedirectUrl("", "")
        Dim item As New LoginItem
        LoginLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (LoginErrors.Count > 0)
'End Button Button_DoLogin OnClick Handler

'Button Button_DoLogin Event OnClick. Action Login @4-62DA9852
        If Not ErrorFlag AndAlso Membership.ValidateUser(Loginlogin.Text,Loginpassword.Text) Then
            SecurityUtility.SetSecurityCookies(Loginlogin.Text,Loginpassword.Text, Logincb_rememberme.Checked)
            If Not(HttpContext.Current.Request("ret_link") is Nothing) Then 
                If Not(HttpContext.Current.Request("ret_link")="") Then 
                Response.Redirect(HttpContext.Current.Request("ret_link"))
                Else
                ErrorFlag=True
                LoginErrors.Add("",Resources.strings.CCS_LoginError)
                End If
            End If
        ElseIf Not ErrorFlag Then
            ErrorFlag=True
            LoginErrors.Add("",Resources.strings.CCS_LoginError)
        End If
'End Button Button_DoLogin Event OnClick. Action Login

'Button Button_DoLogin Event OnClick. Action Custom Code @15-73254650
    ' -------------------------
    'ERA: March-2012|EA| even if correct, if the User is inactive, then bounce 
	dim InactiveFlag as Boolean = CType((New BooleanField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT STATUS FROM STAFF WHERE CAMPUS_CODE='D' and STAFF_ID='" & Loginlogin.Text &"'"))).Value, Boolean)
	if (Not InactiveFlag) then
            HttpContext.Current.Session.Remove("UserID")
            HttpContext.Current.Session.Remove("GroupID")
            HttpContext.Current.Session.Remove("UserLogin")
			'ERA: extra session variable for permissions
			HttpContext.Current.Session.Remove("AccessGroups")
            FormsAuthentication.SignOut()
			ErrorFlag=True
            LoginErrors.Add("",Resources.strings.CCS_LoginError)
	end if
    ' -------------------------
'End Button Button_DoLogin Event OnClick. Action Custom Code

'Button Button_DoLogin OnClick Handler tail @3-95FB8148
        If ErrorFlag Then
            LoginShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoLogin OnClick Handler tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-EFE250B7
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        LoginContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        LoginData = New LoginDataProvider()
        LoginOperations = New FormSupportedOperations(False, True, True, True, True)
'End OnInit Event Body

'Page Login Event AfterInitialize. Action Logout @9-8C5E5A21
        If Not IsNothing(HttpContext.Current.Request("Logout")) Then
            HttpContext.Current.Session.Remove("UserID")
            HttpContext.Current.Session.Remove("GroupID")
            HttpContext.Current.Session.Remove("UserLogin")
			'ERA: extra session variable for permissions
			HttpContext.Current.Session.Remove("AccessGroups")
            FormsAuthentication.SignOut()
        End If
'End Page Login Event AfterInitialize. Action Logout

'Page Login Event AfterInitialize. Action Custom Code @14-73254650
    ' -------------------------
    ' 
   ' 11 Aug 2021|RW| Unconditional redirect to the Windows authentication handler
   Response.Redirect(Settings.AccessDeniedUrl, False)
   HttpContext.Current.ApplicationInstance.CompleteRequest()

   ' 7 Apr 2021|RW| Removed this legacy code block which had been an attempt to get autologin to work based on the signed in Windows user
   '                Windows authentication needs to be enabled for the web app to allow IIS to be able to pick up the ID of the currently signed in Windows user
   '                But, CodeCharge Studio only supports Forms based authentication

	'ERA: setting up auto login by getting login from Browser and if matching Database then allow login
	' UPDATED: 11/01/2011 - try to get this thing working.
	'Pull the identity from the windows login - different depending on ASP.NET vs CodeCharge I think
	' per Vikas, check System.Security.Principal.WindowsIdentity.GetCurrent().Name
	' per google/stackoverflow, maybe even old Request.ServerVariables["LOGON_USER"]

'	Dim CurrentUser as String 
'	'CurrentUser = System.Web.HttpContext.Current.User.Identity.Name.ToString()
'	'CurrentUser = System.Environment.GetEnvironmentVariable("username").Tostring()
'	CurrentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name
'
'	'End Pull Identity
'
'	'debug - turn off
'	'CurrentUser = "IUSR/someth8ing"
'
'	If InStr(CurrentUser,"IUSR") Then
'  		'They are not logged in as a specific user, so load the login form as normal
'	Else
' 		'Need to split the CurrentUser at the \
' 		Dim myIndex as Integer = CurrentUser.IndexOf("\")
' 		CurrentUser = CurrentUser.Remove(0,myIndex + 1)
' 		Dim myUserPassword as String	' then get the password to match and set up.
' 		'myUserPassword = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select PASSWORD from STAFF where STATUS = 1 and CAMPUS_CODE='D' and STAFF_ID = '"& CurrentUser & "'").ToString
'		myUserPassword = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT PASSWORD FROM STAFF WHERE STATUS=1 and CAMPUS_CODE='D' and STAFF_ID='" & CurrentUser &"'"))).Value, String)
'		'debug
'		'response.write ("<hr><br>User:" & CurrentUser)
'		'response.write ("<br>PWD:" & myUserPassword &"<hr>")
'		'response.end
'
'		'Here is the code that bypasses actually having to login....
'		' and should put the Menu as the default ret_link if there is none
'		if (Membership.ValidateUser(CurrentUser,myUserPassword)) then
'			' set security
'			SecurityUtility.SetSecurityCookies(CurrentUser,myUserPassword, Logincb_rememberme.Checked)
'
'			If Not(HttpContext.Current.Request("ret_link") is Nothing) Then
'				If Not(HttpContext.Current.Request("ret_link")="") Then
'					Response.Redirect(HttpContext.Current.Request("ret_link"))
'				End If
'			else
'				Dim RedirectUrl As String = GetLoginRedirectUrl("", "")
' 				Response.Redirect(RedirectUrl)
'			End If
'		End If
'	End If

    ' -------------------------
'End Page Login Event AfterInitialize. Action Custom Code

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'InitializeComponent Event @1-EA5E2628
    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub
    #End Region
'End InitializeComponent Event

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

