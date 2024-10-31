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

Namespace DECV_PROD2007.WinLogin.Student_Contact_QuickEntry 'Namespace @1-BC42E70F

'Forms Definition @1-10305BB1
Public Class [Student_Contact_QuickEntryPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-DF61F8F6
    Protected QuickEnterFormData As QuickEnterFormDataProvider
    Protected QuickEnterFormErrors As NameValueCollection = New NameValueCollection()
    Protected QuickEnterFormOperations As FormSupportedOperations
    Protected QuickEnterFormIsSubmitted As Boolean = False
    Protected Student_Contact_QuickEntryContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-2EDF13D2
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            QuickEnterFormShow()
    End If
            'QuickEnterFormUpdateDB1_insertCommentQuickEntryPrepare()
            'End Page_Load Event BeforeIsPostBack

        End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form QuickEnterForm Parameters @4-E36BA58B

    Protected Sub QuickEnterFormParameters()
        Dim item As new QuickEnterFormItem
        Try
            QuickEnterFormData.UrlCOMMENT_ID = IntegerParameter.GetParam("COMMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            QuickEnterFormData.CtrlCOMMENT = TextParameter.GetParam(item.COMMENT.Value, ParameterSourceType.Control, "", "", false)
            QuickEnterFormData.CtrlSTUDENT_ID = TextParameter.GetParam(item.STUDENT_ID.Value, ParameterSourceType.Control, "", "", false)
            QuickEnterFormData.CtrlLAST_ALTERED_BY = TextParameter.GetParam(item.LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", "", false)
            QuickEnterFormData.CtrlCOMMENT_TYPE = TextParameter.GetParam(item.COMMENT_TYPE.Value, ParameterSourceType.Control, "", "REGULAR", false)
        Catch e As Exception
            QuickEnterFormErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form QuickEnterForm Parameters

'Record Form QuickEnterForm Show method @4-5BFD54AA
    Protected Sub QuickEnterFormShow()
        If QuickEnterFormOperations.None Then
            QuickEnterFormHolder.Visible = False
            Return
        End If
        Dim item As QuickEnterFormItem = QuickEnterFormItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not QuickEnterFormOperations.AllowRead
        item.Label1.SetValue(System.Web.HttpContext.Current.User.Identity.Name)
        item.Hidden_STAFFID.SetValue(System.Web.HttpContext.Current.User.Identity.Name)
        QuickEnterFormErrors.Add(item.errors)
        If QuickEnterFormErrors.Count > 0 Then
            QuickEnterFormShowErrors()
            Return
        End If
'End Record Form QuickEnterForm Show method

'Record Form QuickEnterForm BeforeShow tail @4-17F1BC7C
        QuickEnterFormParameters()
        QuickEnterFormData.FillItem(item, IsInsertMode)
        QuickEnterFormHolder.DataBind()
        QuickEnterFormButton_Insert.Visible=IsInsertMode AndAlso QuickEnterFormOperations.AllowInsert
        item.COMMENT_TYPEItems.SetSelection(item.COMMENT_TYPE.GetFormattedValue())
        QuickEnterFormCOMMENT_TYPE.SelectedIndex = -1
        item.COMMENT_TYPEItems.CopyTo(QuickEnterFormCOMMENT_TYPE.Items)
        QuickEnterFormCOMMENT.Text=item.COMMENT.GetFormattedValue()
        QuickEnterFormSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        QuickEnterFormLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        QuickEnterFormtext_Who.Text=item.text_Who.GetFormattedValue()
        QuickEnterFormLabel1.Text = Server.HtmlEncode(item.Label1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        QuickEnterFormHidden_STAFFID.Value = item.Hidden_STAFFID.GetFormattedValue()
'End Record Form QuickEnterForm BeforeShow tail

'Record QuickEnterForm Event BeforeShow. Action Retrieve Value for Control @19-BC2C7BC4
            QuickEnterFormSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record QuickEnterForm Event BeforeShow. Action Retrieve Value for Control

'Record QuickEnterForm Event BeforeShow. Action Retrieve Value for Control @20-5B37A0F8
            QuickEnterFormtext_Who.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record QuickEnterForm Event BeforeShow. Action Retrieve Value for Control

'Record Form QuickEnterForm Show method tail @4-EF045B02
        If QuickEnterFormErrors.Count > 0 Then
            QuickEnterFormShowErrors()
        End If
    End Sub
'End Record Form QuickEnterForm Show method tail

'Record Form QuickEnterForm LoadItemFromRequest method @4-4D1CB448

    Protected Sub QuickEnterFormLoadItemFromRequest(item As QuickEnterFormItem, ByVal EnableValidation As Boolean)
        item.COMMENT_TYPE.IsEmpty = IsNothing(Request.Form(QuickEnterFormCOMMENT_TYPE.UniqueID))
        If Not IsNothing(QuickEnterFormCOMMENT_TYPE.SelectedItem) Then
            item.COMMENT_TYPE.SetValue(QuickEnterFormCOMMENT_TYPE.SelectedItem.Value)
        Else
            item.COMMENT_TYPE.Value = Nothing
        End If
        item.COMMENT_TYPEItems.CopyFrom(QuickEnterFormCOMMENT_TYPE.Items)
        item.COMMENT.IsEmpty = IsNothing(Request.Form(QuickEnterFormCOMMENT.UniqueID))
        If ControlCustomValues("QuickEnterFormCOMMENT") Is Nothing Then
            item.COMMENT.SetValue(QuickEnterFormCOMMENT.Text)
        Else
            item.COMMENT.SetValue(ControlCustomValues("QuickEnterFormCOMMENT"))
        End If
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(QuickEnterFormSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(QuickEnterFormSTUDENT_ID.Value)
        Catch ae As ArgumentException
            QuickEnterFormErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(QuickEnterFormLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(QuickEnterFormLAST_ALTERED_BY.Value)
        item.text_Who.IsEmpty = IsNothing(Request.Form(QuickEnterFormtext_Who.UniqueID))
        If ControlCustomValues("QuickEnterFormtext_Who") Is Nothing Then
            item.text_Who.SetValue(QuickEnterFormtext_Who.Text)
        Else
            item.text_Who.SetValue(ControlCustomValues("QuickEnterFormtext_Who"))
        End If
        item.Hidden_STAFFID.IsEmpty = IsNothing(Request.Form(QuickEnterFormHidden_STAFFID.UniqueID))
        item.Hidden_STAFFID.SetValue(QuickEnterFormHidden_STAFFID.Value)
        If EnableValidation Then
            item.Validate(QuickEnterFormData)
        End If
        QuickEnterFormErrors.Add(item.errors)
    End Sub
'End Record Form QuickEnterForm LoadItemFromRequest method

'Record Form QuickEnterForm GetRedirectUrl method @4-7909BA43

    Protected Function GetQuickEnterFormRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","STUDENT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form QuickEnterForm GetRedirectUrl method

'Record Form QuickEnterForm ShowErrors method @4-26A947CA

    Protected Sub QuickEnterFormShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To QuickEnterFormErrors.Count - 1
        Select Case QuickEnterFormErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & QuickEnterFormErrors(i)
        End Select
        Next i
        QuickEnterFormError.Visible = True
        QuickEnterFormErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form QuickEnterForm ShowErrors method

'Record Form QuickEnterForm Insert Operation @4-EC6A93FF

    Protected Sub QuickEnterForm_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As QuickEnterFormItem = New QuickEnterFormItem()
        Dim ExecuteFlag As Boolean = True
        QuickEnterFormIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form QuickEnterForm Insert Operation

'Button Button_Insert OnClick. @5-0D62EF3C
        If CType(sender,Control).ID = "QuickEnterFormButton_Insert" Then
            RedirectUrl = GetQuickEnterFormRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @5-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form QuickEnterForm BeforeInsert tail @4-2EB9B538
    QuickEnterFormParameters()
    QuickEnterFormLoadItemFromRequest(item, EnableValidation)
    If QuickEnterFormOperations.AllowInsert Then
        ErrorFlag=(QuickEnterFormErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                QuickEnterFormData.InsertItem(item)
            Catch ex As Exception
                QuickEnterFormErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form QuickEnterForm BeforeInsert tail

'Record Form QuickEnterForm AfterInsert tail  @4-F9E6DA79
        End If
        ErrorFlag=(QuickEnterFormErrors.Count > 0)
        If ErrorFlag Then
            QuickEnterFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form QuickEnterForm AfterInsert tail 

'Record Form QuickEnterForm Update Operation @4-6DD34B4B

    Protected Sub QuickEnterForm_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As QuickEnterFormItem = New QuickEnterFormItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        QuickEnterFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form QuickEnterForm Update Operation

'Record Form QuickEnterForm Before Update tail @4-9E753521
        QuickEnterFormParameters()
        QuickEnterFormLoadItemFromRequest(item, EnableValidation)
'End Record Form QuickEnterForm Before Update tail

'Record Form QuickEnterForm Update Operation tail @4-41D1ED50
        ErrorFlag=(QuickEnterFormErrors.Count > 0)
        If ErrorFlag Then
            QuickEnterFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form QuickEnterForm Update Operation tail

'Record Form QuickEnterForm Delete Operation @4-CE2B22D6
    Protected Sub QuickEnterForm_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        QuickEnterFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As QuickEnterFormItem = New QuickEnterFormItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form QuickEnterForm Delete Operation

'Record Form BeforeDelete tail @4-9E753521
        QuickEnterFormParameters()
        QuickEnterFormLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-208F11F6
        If ErrorFlag Then
            QuickEnterFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form QuickEnterForm Cancel Operation @4-317C4E1F

    Protected Sub QuickEnterForm_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As QuickEnterFormItem = New QuickEnterFormItem()
        QuickEnterFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        QuickEnterFormLoadItemFromRequest(item, False)
'End Record Form QuickEnterForm Cancel Operation

'Button Button_Cancel OnClick. @6-83DFD70A
    If CType(sender,Control).ID = "QuickEnterFormButton_Cancel" Then
        RedirectUrl = GetQuickEnterFormRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @6-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form QuickEnterForm Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form QuickEnterForm Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'UpdateDB1_insertCommentQuickEntry Initialization @34-CE989E8D
        If Request("callbackControl") = "QuickEnterFormUpdateDB1_insertCommentQuickEntry" Then
                'QuickEnterFormUpdateDB1_insertCommentQuickEntryExecute()
            End If
'End UpdateDB1_insertCommentQuickEntry Initialization

'OnInit Event Body @1-EF57F9C6
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Contact_QuickEntryContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        QuickEnterFormData = New QuickEnterFormDataProvider()
        QuickEnterFormOperations = New FormSupportedOperations(False, False, True, False, False)
'End OnInit Event Body

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

