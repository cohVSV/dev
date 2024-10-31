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

Namespace DECV_PROD2007.Student_Exit_Track 'Namespace @1-4B73CE90

'Forms Definition @1-BD0EC4F6
Public Class [Student_Exit_TrackPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-43172762
    Protected Student_ExitData As Student_ExitDataProvider
    Protected Student_ExitErrors As NameValueCollection = New NameValueCollection()
    Protected Student_ExitOperations As FormSupportedOperations
    Protected Student_ExitIsSubmitted As Boolean = False
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestErrors As NameValueCollection = New NameValueCollection()
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestIsSubmitted As Boolean = False
    Protected Student_Exit_TrackContentMeta As String
'End Forms Objects
Protected sStudent_Exit_Search as string="Exit_"
'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-4BAAF77E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Student_ExitShow()
            viewMaintainSearchRequestShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form Student_Exit Parameters @2-8A64D663

    Protected Sub Student_ExitParameters()
        Dim item As new Student_ExitItem
        Try
            Student_ExitData.CtrlHidden_CommentID = FloatParameter.GetParam(item.Hidden_CommentID.Value, ParameterSourceType.Control, "", Nothing, false)
            Student_ExitData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            Student_ExitData.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            Student_ExitData.CtrllbEXIT_DESTINATION = IntegerParameter.GetParam(item.lbEXIT_DESTINATION.Value, ParameterSourceType.Control, "", Nothing, false)
            Student_ExitData.CtrlTextAreaComments = TextParameter.GetParam(item.TextAreaComments.Value, ParameterSourceType.Control, "", Nothing, false)
            Student_ExitData.CtrlTXT_LastAlteredBy = TextParameter.GetParam(item.TXT_LastAlteredBy.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            Student_ExitErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form Student_Exit Parameters

'Record Form Student_Exit Show method @2-9F15123B
    Protected Sub Student_ExitShow()
        If Student_ExitOperations.None Then
            Student_ExitHolder.Visible = False
            Return
        End If
        Dim item As Student_ExitItem = Student_ExitItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not Student_ExitOperations.AllowRead
        Student_ExitErrors.Add(item.errors)
        If Student_ExitErrors.Count > 0 Then
            Student_ExitShowErrors()
            Return
        End If
'End Record Form Student_Exit Show method

'Record Form Student_Exit BeforeShow tail @2-D1A468B2
        Student_ExitParameters()
        Student_ExitData.FillItem(item, IsInsertMode)
        Student_ExitHolder.DataBind()
        Student_ExitButton_Update.Visible=Not (IsInsertMode) AndAlso Student_ExitOperations.AllowUpdate
        Student_ExitLbl_Name.Text = Server.HtmlEncode(item.Lbl_Name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitLbl_StudentID.Text = Server.HtmlEncode(item.Lbl_StudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitLbl_WithDrawnReason.Text = Server.HtmlEncode(item.Lbl_WithDrawnReason.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitLbl_WithDrawnDate.Text = Server.HtmlEncode(item.Lbl_WithDrawnDate.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitlbEXIT_DESTINATION.Items.Add(new ListItem("Select Destination",""))
        Student_ExitlbEXIT_DESTINATION.Items(0).Selected = True
        item.lbEXIT_DESTINATIONItems.SetSelection(item.lbEXIT_DESTINATION.GetFormattedValue())
        If Not item.lbEXIT_DESTINATIONItems.GetSelectedItem() Is Nothing Then
            Student_ExitlbEXIT_DESTINATION.SelectedIndex = -1
        End If
        item.lbEXIT_DESTINATIONItems.CopyTo(Student_ExitlbEXIT_DESTINATION.Items)
        Student_ExitTextAreaComments.Text=item.TextAreaComments.GetFormattedValue()
        Student_ExitLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_ExitTXT_LastAlteredBy.Value = item.TXT_LastAlteredBy.GetFormattedValue()
        Student_ExitHidden_CommentID.Value = item.Hidden_CommentID.GetFormattedValue()
'End Record Form Student_Exit BeforeShow tail

'DEL              sStudent_Exit_Search = sStudent_Exit_Search & System.Web.HttpContext.Current.Request.QueryString("Enrolment_Year")


'Record Student_Exit Event BeforeShow. Action Custom Code @51-73254650
    '-------------------------
	'21-Oct-2010|EA| hide form if not all details supplied. unfuddle #325
	
	if (isnothing(Student_ExitData.Urls_ENROLMENT_YEAR) and isnothing(Student_ExitData.Urls_STUDENT_ID)) then
		Student_ExitHolder.visible = false
	end if 
	
	'if (isnothing(item.rawdata)) then
	'	Student_ExitHolder.visible = false
	'end if
'DEL      ' -------------------------
'DEL      System.Web.HttpContext.Current.Response.Write(Select_.ToString())
'DEL      ' -------------------------

    
    ' -------------------------
'End Record Student_Exit Event BeforeShow. Action Custom Code

'Record Form Student_Exit Show method tail @2-01CAA6E9
        If Student_ExitErrors.Count > 0 Then
            Student_ExitShowErrors()
        End If
    End Sub
'End Record Form Student_Exit Show method tail

'Record Form Student_Exit LoadItemFromRequest method @2-C017E656

    Protected Sub Student_ExitLoadItemFromRequest(item As Student_ExitItem, ByVal EnableValidation As Boolean)
        Try
        item.lbEXIT_DESTINATION.IsEmpty = IsNothing(Request.Form(Student_ExitlbEXIT_DESTINATION.UniqueID))
        item.lbEXIT_DESTINATION.SetValue(Student_ExitlbEXIT_DESTINATION.Value)
        item.lbEXIT_DESTINATIONItems.CopyFrom(Student_ExitlbEXIT_DESTINATION.Items)
        Catch ae As ArgumentException
            Student_ExitErrors.Add("lbEXIT_DESTINATION",String.Format(Resources.strings.CCS_IncorrectValue,"EXIT DESTINATION"))
        End Try
        item.TextAreaComments.IsEmpty = IsNothing(Request.Form(Student_ExitTextAreaComments.UniqueID))
        If ControlCustomValues("Student_ExitTextAreaComments") Is Nothing Then
            item.TextAreaComments.SetValue(Student_ExitTextAreaComments.Text)
        Else
            item.TextAreaComments.SetValue(ControlCustomValues("Student_ExitTextAreaComments"))
        End If
        item.TXT_LastAlteredBy.IsEmpty = IsNothing(Request.Form(Student_ExitTXT_LastAlteredBy.UniqueID))
        item.TXT_LastAlteredBy.SetValue(Student_ExitTXT_LastAlteredBy.Value)
        item.Hidden_CommentID.IsEmpty = IsNothing(Request.Form(Student_ExitHidden_CommentID.UniqueID))
        item.Hidden_CommentID.SetValue(Student_ExitHidden_CommentID.Value)
        If EnableValidation Then
            item.Validate(Student_ExitData)
        End If
        Student_ExitErrors.Add(item.errors)
    End Sub
'End Record Form Student_Exit LoadItemFromRequest method

'Record Form Student_Exit GetRedirectUrl method @2-E0792300

    Protected Function GetStudent_ExitRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","s_STUDENT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form Student_Exit GetRedirectUrl method

'Record Form Student_Exit ShowErrors method @2-4F18B094

    Protected Sub Student_ExitShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To Student_ExitErrors.Count - 1
        Select Case Student_ExitErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & Student_ExitErrors(i)
        End Select
        Next i
        Student_ExitError.Visible = True
        Student_ExitErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form Student_Exit ShowErrors method

'Record Form Student_Exit Insert Operation @2-29F549AA

    Protected Sub Student_Exit_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_ExitItem = New Student_ExitItem()
        Student_ExitIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Student_Exit Insert Operation

'Record Form Student_Exit BeforeInsert tail @2-ADBEB3DE
    Student_ExitParameters()
    Student_ExitLoadItemFromRequest(item, EnableValidation)
'End Record Form Student_Exit BeforeInsert tail

'Record Form Student_Exit AfterInsert tail  @2-2438920A
        ErrorFlag=(Student_ExitErrors.Count > 0)
        If ErrorFlag Then
            Student_ExitShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Student_Exit AfterInsert tail 

'Record Form Student_Exit Update Operation @2-9BCC668D

    Protected Sub Student_Exit_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_ExitItem = New Student_ExitItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        Student_ExitIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Student_Exit Update Operation

'Button Button_Update OnClick. @6-E022809C
        If CType(sender,Control).ID = "Student_ExitButton_Update" Then
            RedirectUrl = GetStudent_ExitRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form Student_Exit Before Update tail @2-4AA7D8DB
        Student_ExitParameters()
        Student_ExitLoadItemFromRequest(item, EnableValidation)
        If Student_ExitOperations.AllowUpdate Then
        ErrorFlag = (Student_ExitErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                Student_ExitData.UpdateItem(item)
            Catch ex As Exception
                Student_ExitErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form Student_Exit Before Update tail

'Record Student_Exit Event AfterUpdate. Action Custom Code @56-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Record Student_Exit Event AfterUpdate. Action Custom Code

'Record Form Student_Exit Update Operation tail @2-A073F315
        End If
        ErrorFlag=(Student_ExitErrors.Count > 0)
        If ErrorFlag Then
            Student_ExitShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Student_Exit Update Operation tail

'Record Form Student_Exit Delete Operation @2-50F46A67
    Protected Sub Student_Exit_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        Student_ExitIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As Student_ExitItem = New Student_ExitItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form Student_Exit Delete Operation

'Record Form BeforeDelete tail @2-ADBEB3DE
        Student_ExitParameters()
        Student_ExitLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-0733AF43
        If ErrorFlag Then
            Student_ExitShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form Student_Exit Cancel Operation @2-6F372972

    Protected Sub Student_Exit_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_ExitItem = New Student_ExitItem()
        Student_ExitIsSubmitted = True
        Dim RedirectUrl As String = ""
        Student_ExitLoadItemFromRequest(item, False)
'End Record Form Student_Exit Cancel Operation

'Button Button_Cancel OnClick. @7-BC967A4F
    If CType(sender,Control).ID = "Student_ExitButton_Cancel" Then
        RedirectUrl = GetStudent_ExitRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @7-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form Student_Exit Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form Student_Exit Cancel Operation tail

'Record Form viewMaintainSearchRequest Parameters @59-80C4ACFE

    Protected Sub viewMaintainSearchRequestParameters()
        Dim item As new viewMaintainSearchRequestItem
        Try
        Catch e As Exception
            viewMaintainSearchRequestErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewMaintainSearchRequest Parameters

'Record Form viewMaintainSearchRequest Show method @59-16823886
    Protected Sub viewMaintainSearchRequestShow()
        If viewMaintainSearchRequestOperations.None Then
            viewMaintainSearchRequestHolder.Visible = False
            Return
        End If
        Dim item As viewMaintainSearchRequestItem = viewMaintainSearchRequestItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewMaintainSearchRequestOperations.AllowRead
        item.ClearParametersHref = "Student_Exit_Track.aspx"
        viewMaintainSearchRequestErrors.Add(item.errors)
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
            Return
        End If
'End Record Form viewMaintainSearchRequest Show method

'Record Form viewMaintainSearchRequest BeforeShow tail @59-5E0C3445
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestData.FillItem(item, IsInsertMode)
        viewMaintainSearchRequestHolder.DataBind()
        viewMaintainSearchRequestClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_STUDENT_ID;s_ENROLMENT_YEAR", ViewState)
        viewMaintainSearchRequests_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        viewMaintainSearchRequests_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
'End Record Form viewMaintainSearchRequest BeforeShow tail

'Record Form viewMaintainSearchRequest Show method tail @59-D3A5B4A7
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Show method tail

'Record Form viewMaintainSearchRequest LoadItemFromRequest method @59-75CAB9E4

    Protected Sub viewMaintainSearchRequestLoadItemFromRequest(item As viewMaintainSearchRequestItem, ByVal EnableValidation As Boolean)
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_STUDENT_ID.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(viewMaintainSearchRequests_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("viewMaintainSearchRequests_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            viewMaintainSearchRequestErrors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(viewMaintainSearchRequests_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewMaintainSearchRequests_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            viewMaintainSearchRequestErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        If EnableValidation Then
            item.Validate(viewMaintainSearchRequestData)
        End If
        viewMaintainSearchRequestErrors.Add(item.errors)
    End Sub
'End Record Form viewMaintainSearchRequest LoadItemFromRequest method

'Record Form viewMaintainSearchRequest GetRedirectUrl method @59-B334A3CF

    Protected Function GetviewMaintainSearchRequestRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Exit_Track.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewMaintainSearchRequest GetRedirectUrl method

'Record Form viewMaintainSearchRequest ShowErrors method @59-2271AF53

    Protected Sub viewMaintainSearchRequestShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewMaintainSearchRequestErrors.Count - 1
        Select Case viewMaintainSearchRequestErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewMaintainSearchRequestErrors(i)
        End Select
        Next i
        viewMaintainSearchRequestError.Visible = True
        viewMaintainSearchRequestErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewMaintainSearchRequest ShowErrors method

'Record Form viewMaintainSearchRequest Insert Operation @59-00993BC6

    Protected Sub viewMaintainSearchRequest_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequest Insert Operation

'Record Form viewMaintainSearchRequest BeforeInsert tail @59-CF511C3D
    viewMaintainSearchRequestParameters()
    viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest BeforeInsert tail

'Record Form viewMaintainSearchRequest AfterInsert tail  @59-1B133DD0
        ErrorFlag=(viewMaintainSearchRequestErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest AfterInsert tail 

'Record Form viewMaintainSearchRequest Update Operation @59-66525082

    Protected Sub viewMaintainSearchRequest_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequest Update Operation

'Record Form viewMaintainSearchRequest Before Update tail @59-CF511C3D
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest Before Update tail

'Record Form viewMaintainSearchRequest Update Operation tail @59-1B133DD0
        ErrorFlag=(viewMaintainSearchRequestErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Update Operation tail

'Record Form viewMaintainSearchRequest Delete Operation @59-BE5D2BAE
    Protected Sub viewMaintainSearchRequest_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewMaintainSearchRequest Delete Operation

'Record Form BeforeDelete tail @59-CF511C3D
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @59-0F56CE2C
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewMaintainSearchRequest Cancel Operation @59-60657F47

    Protected Sub viewMaintainSearchRequest_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewMaintainSearchRequestLoadItemFromRequest(item, True)
'End Record Form viewMaintainSearchRequest Cancel Operation

'Record Form viewMaintainSearchRequest Cancel Operation tail @59-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewMaintainSearchRequest Cancel Operation tail

'Record Form viewMaintainSearchRequest Search Operation @59-136E5E10
    Protected Sub viewMaintainSearchRequest_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewMaintainSearchRequestIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest Search Operation

'Button Button_DoSearch OnClick. @61-637B295B
        If CType(sender,Control).ID = "viewMaintainSearchRequestButton_DoSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestRedirectUrl("", "s_STUDENT_ID;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @61-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewMaintainSearchRequest Search Operation tail @59-AFFD7BB7
        ErrorFlag = viewMaintainSearchRequestErrors.Count > 0
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewMaintainSearchRequests_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(viewMaintainSearchRequests_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewMaintainSearchRequests_ENROLMENT_YEAR.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-D4B465AB
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Exit_TrackContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Student_ExitData = New Student_ExitDataProvider()
        Student_ExitOperations = New FormSupportedOperations(False, True, False, True, False)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

