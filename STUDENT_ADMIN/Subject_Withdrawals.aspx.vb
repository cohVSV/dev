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

Namespace DECV_PROD2007.Subject_Withdrawals 'Namespace @1-89A85C03

'Forms Definition @1-7C470E0B
Public Class [Subject_WithdrawalsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-3E790912
    Protected SUBJECTSearchData As SUBJECTSearchDataProvider
    Protected SUBJECTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECTSearchOperations As FormSupportedOperations
    Protected SUBJECTSearchIsSubmitted As Boolean = False
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTCurrentRowNumber As Integer
    Protected Subject_WithdrawalsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CB4C26FF
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECTSearchShow()
            UpdateFormShow()
            SUBJECTBind
    End If
'End Page_Load Event BeforeIsPostBack

'Page Subject_Withdrawals Event BeforeShow. Action Hide-Show Component @73-8BDAAAA4
        Dim Urls_STUDENT_ID_73_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_STUDENT_ID"))
        Dim ExprParam2_73_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_STUDENT_ID_73_1, ExprParam2_73_2) Then
            UpdateFormHolder.Visible = False
        End If
'End Page Subject_Withdrawals Event BeforeShow. Action Hide-Show Component

'Page Subject_Withdrawals Event BeforeShow. Action Hide-Show Component @74-BA3446AC
        Dim Urls_STUDENT_ID_74_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_STUDENT_ID"))
        Dim ExprParam2_74_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_STUDENT_ID_74_1, ExprParam2_74_2) Then
            SUBJECTRepeater.Visible = False
        End If
'End Page Subject_Withdrawals Event BeforeShow. Action Hide-Show Component

'DEL      ' -------------------------
'DEL      'ERA: add Update option to Updateform     
'DEL  		Dim Urls_STUDENT_ID_73_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_STUDENT_ID"))
'DEL          Dim ExprParam2_73_2 As TextField = New TextField("", (""))
'DEL          If FieldBase.NotEqualOp(Urls_STUDENT_ID_73_1, ExprParam2_73_2) Then
'DEL              UpdateFormHolder..Visible = False
'DEL          End If
'DEL      ' -------------------------


    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SUBJECTSearch Parameters @8-0DBBE141

    Protected Sub SUBJECTSearchParameters()
        Dim item As new SUBJECTSearchItem
        Try
        Catch e As Exception
            SUBJECTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECTSearch Parameters

'Record Form SUBJECTSearch Show method @8-3B0884E5
    Protected Sub SUBJECTSearchShow()
        If SUBJECTSearchOperations.None Then
            SUBJECTSearchHolder.Visible = False
            Return
        End If
        Dim item As SUBJECTSearchItem = SUBJECTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECTSearchOperations.AllowRead
        SUBJECTSearchErrors.Add(item.errors)
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
            Return
        End If
'End Record Form SUBJECTSearch Show method

'Record Form SUBJECTSearch BeforeShow tail @8-A9DECC75
        SUBJECTSearchParameters()
        SUBJECTSearchData.FillItem(item, IsInsertMode)
        SUBJECTSearchHolder.DataBind()
        SUBJECTSearchs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        SUBJECTSearchs_ENROL_YEAR.Text=item.s_ENROL_YEAR.GetFormattedValue()
'End Record Form SUBJECTSearch BeforeShow tail

'Record Form SUBJECTSearch Show method tail @8-2B15C3B5
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
        End If
    End Sub
'End Record Form SUBJECTSearch Show method tail

'Record Form SUBJECTSearch LoadItemFromRequest method @8-EC126EF4

    Protected Sub SUBJECTSearchLoadItemFromRequest(item As SUBJECTSearchItem, ByVal EnableValidation As Boolean)
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(SUBJECTSearchs_STUDENT_ID.UniqueID))
        If ControlCustomValues("SUBJECTSearchs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(SUBJECTSearchs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("SUBJECTSearchs_STUDENT_ID"))
        End If
        item.s_ENROL_YEAR.IsEmpty = IsNothing(Request.Form(SUBJECTSearchs_ENROL_YEAR.UniqueID))
        If ControlCustomValues("SUBJECTSearchs_ENROL_YEAR") Is Nothing Then
            item.s_ENROL_YEAR.SetValue(SUBJECTSearchs_ENROL_YEAR.Text)
        Else
            item.s_ENROL_YEAR.SetValue(ControlCustomValues("SUBJECTSearchs_ENROL_YEAR"))
        End If
        If EnableValidation Then
            item.Validate(SUBJECTSearchData)
        End If
        SUBJECTSearchErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECTSearch LoadItemFromRequest method

'Record Form SUBJECTSearch GetRedirectUrl method @8-7C395654

    Protected Function GetSUBJECTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Subject_Withdrawals.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECTSearch GetRedirectUrl method

'Record Form SUBJECTSearch ShowErrors method @8-1BBB8726

    Protected Sub SUBJECTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECTSearchErrors.Count - 1
        Select Case SUBJECTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECTSearchErrors(i)
        End Select
        Next i
        SUBJECTSearchError.Visible = True
        SUBJECTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECTSearch ShowErrors method

'Record Form SUBJECTSearch Insert Operation @8-33FDEC64

    Protected Sub SUBJECTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Insert Operation

'Record Form SUBJECTSearch BeforeInsert tail @8-8EC67B0F
    SUBJECTSearchParameters()
    SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch BeforeInsert tail

'Record Form SUBJECTSearch AfterInsert tail  @8-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch AfterInsert tail 

'Record Form SUBJECTSearch Update Operation @8-CEA8EC00

    Protected Sub SUBJECTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Update Operation

'Record Form SUBJECTSearch Before Update tail @8-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Before Update tail

'Record Form SUBJECTSearch Update Operation tail @8-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch Update Operation tail

'Record Form SUBJECTSearch Delete Operation @8-7B81E740
    Protected Sub SUBJECTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECTSearch Delete Operation

'Record Form BeforeDelete tail @8-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @8-D8B6C6AE
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECTSearch Cancel Operation @8-2C955275

    Protected Sub SUBJECTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECTSearchLoadItemFromRequest(item, True)
'End Record Form SUBJECTSearch Cancel Operation

'Record Form SUBJECTSearch Cancel Operation tail @8-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECTSearch Cancel Operation tail

'Record Form SUBJECTSearch Search Operation @8-8AD27A71
    Protected Sub SUBJECTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Search Operation

'Button Button_DoSearch OnClick. @9-DEE720AD
        If CType(sender,Control).ID = "SUBJECTSearchButton_DoSearch" Then
            RedirectUrl = GetSUBJECTSearchRedirectUrl("", "s_STUDENT_ID;s_ENROL_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch Event OnClick. Action Custom Code @30-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Button Button_DoSearch Event OnClick. Action Custom Code

'Button Button_DoSearch OnClick tail. @9-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECTSearch Search Operation tail @8-4367018E
        ErrorFlag = SUBJECTSearchErrors.Count > 0
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(SUBJECTSearchs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(SUBJECTSearchs_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(SUBJECTSearchs_ENROL_YEAR.Text <> "",("s_ENROL_YEAR=" & Server.UrlEncode(SUBJECTSearchs_ENROL_YEAR.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch Search Operation tail

'Record Form UpdateForm Parameters @53-5778B33E

    Protected Sub UpdateFormParameters()
        Dim item As new UpdateFormItem
        Try
            UpdateFormData.Urls_STUDENT_ID = IntegerParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            UpdateFormData.Urls_ENROL_YEAR = IntegerParameter.GetParam("s_ENROL_YEAR", ParameterSourceType.URL, "", year(now()), false)
        Catch e As Exception
            UpdateFormErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form UpdateForm Parameters

'Record Form UpdateForm Show method @53-AB77C25F
    Protected Sub UpdateFormShow()
        If UpdateFormOperations.None Then
            UpdateFormHolder.Visible = False
            Return
        End If
        Dim item As UpdateFormItem = UpdateFormItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not UpdateFormOperations.AllowRead
        item.linkEarlyExitHref = ""
        UpdateFormErrors.Add(item.errors)
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
            Return
        End If
'End Record Form UpdateForm Show method

'Record Form UpdateForm BeforeShow tail @53-E82F61EA
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblFirstname.Text = Server.HtmlEncode(item.lblFirstname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblSurname.Text = Server.HtmlEncode(item.lblSurname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblEnrolYear.Text = Server.HtmlEncode(item.lblEnrolYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormwithdrawaldate.Text=item.withdrawaldate.GetFormattedValue()
        UpdateFormlistReasonOff.Items.Add(new ListItem("Select Value",""))
        UpdateFormlistReasonOff.Items(0).Selected = True
        item.listReasonOffItems.SetSelection(item.listReasonOff.GetFormattedValue())
        If Not item.listReasonOffItems.GetSelectedItem() Is Nothing Then
            UpdateFormlistReasonOff.SelectedIndex = -1
        End If
        item.listReasonOffItems.CopyTo(UpdateFormlistReasonOff.Items)
        UpdateFormlistSub_Enrol_Status.Items.Add(new ListItem("Select Value",""))
        UpdateFormlistSub_Enrol_Status.Items(0).Selected = True
        item.listSub_Enrol_StatusItems.SetSelection(item.listSub_Enrol_Status.GetFormattedValue())
        If Not item.listSub_Enrol_StatusItems.GetSelectedItem() Is Nothing Then
            UpdateFormlistSub_Enrol_Status.SelectedIndex = -1
        End If
        item.listSub_Enrol_StatusItems.CopyTo(UpdateFormlistSub_Enrol_Status.Items)
        UpdateFormlblYearLevel.Text = Server.HtmlEncode(item.lblYearLevel.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlistNonSubmitReason.Items.Add(new ListItem("Select Value",""))
        UpdateFormlistNonSubmitReason.Items(0).Selected = True
        item.listNonSubmitReasonItems.SetSelection(item.listNonSubmitReason.GetFormattedValue())
        If Not item.listNonSubmitReasonItems.GetSelectedItem() Is Nothing Then
            UpdateFormlistNonSubmitReason.SelectedIndex = -1
        End If
        item.listNonSubmitReasonItems.CopyTo(UpdateFormlistNonSubmitReason.Items)
        UpdateFormlblSSTeacherID.Text = Server.HtmlEncode(item.lblSSTeacherID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormcoord_comment.Text=item.coord_comment.GetFormattedValue()
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlinkEarlyExit.InnerText += item.linkEarlyExit.GetFormattedValue().Replace(vbCrLf,"")
        UpdateFormlinkEarlyExit.HRef = item.linkEarlyExitHref+item.linkEarlyExitHrefParameters.ToString("None","s_STUDENT_ID;s_ENROLMENT_YEAR", ViewState)
'End Record Form UpdateForm BeforeShow tail

'Link linkEarlyExit Event BeforeShow. Action Custom Code @103-73254650
    ' -------------------------
    '21-Aug-2014|EA| get subject teachers and cc to reception link details for linkEarlyExit with text and subject
    dim tmpENROLYEAR as string = Convert.ToString(Year(Now()))
	if (UpdateFormlblEnrolYear.Text<>"") then
		tmpENROLYEAR = UpdateFormlblEnrolYear.Text
	end if
	dim tmpStudentID as string = "0"
	if (UpdateFormlblStudentID.Text<>"") then
		tmpStudentID = UpdateFormlblStudentID.Text
	end if
	
    dim tmpStudentName as string = UpdateFormlblFirstname.Text  & " " & UpdateFormlblSurname.Text
    dim tmpSubject as string = "Early Exit Report for " & tmpStudentName & " (VSV Student ID " & tmpStudentID & ")"
    dim tmpEmailBody as string = "Dear Teacher/s%0A%0AThis student meets the criteria for an Early Exit Report, i.e. he/she is a non-school-based (VSV) student who has completed the equivalent of four weeks (one module) of work since the last interim or mid-year reporting cycle. The [Early Exit Report] fillable PDF template can be accessed at S%3A%5CAdmin%5CReporting%5C2014%5CEarly%20Exiting%20Reports%5CF-12%20Early%20Exit%20Reports%20Fillable.pdf. %0A%0APlease complete the [Early Exit Report] Fillable PDF and email it as an attachment to Kathryn Allen within three (3) working days of receiving this email so it can be collated and despatched.%0A%0A%0AThank You."
    dim tmpCC as string = "kallen@vsv.vic.edu.au;mmciver@vsv.vic.edu.au"
    dim strTeacherEmailList as string = ""
    
    ' get list of teachers from DB into tmpTo
    ' debug first version with simple code
    'dim tmpMailToSource = "mailto:" & tmpTo &"?subject=" & tmpSubject &"&cc=" &tmpCC &"&body="&tmpEmailBody
    'UpdateFormlinkEarlyExit.HRef = tmpMailToSource
    
	strTeacherEmailList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+';' from (select distinct rtrim(staff_id) + '@vsv.vic.edu.au' as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR &" and STUDENT_ID = " & tmpStudentID & " and STAFF_ID !='N-A' and SUBJ_ENROL_STATUS in ('C','D','E')) as T1; select @sCsv2;"))).Value, String)
	
	if (Not IsNothing(strTeacherEmailList)) then
		'if the last char is a semi-colon then remove it
		Dim chArr1() As Char = {" ", ";"}
		strTeacherEmailList = strTeacherEmailList.TrimEnd(chArr1)
		' for Reports it is 'DataItem', for records it is 'item'
		item.linkEarlyExitHref = strTeacherEmailList.ToString
	end if

	' ERA: then add the parameters of student name and number to email mailto link DECV Subject Teacher email for [Firstname] [Surname] (DECV Student ID [StudentID])"
	 item.linkEarlyExitHrefParameters.Add("subject",(tmpSubject).ToString())
	 item.linkEarlyExitHrefParameters.Add("cc",(tmpCC).ToString())
	 'tmpEmailBody = "Dear Teacher/s%0A%0AThis student meets the criteria for an Early Exit Report, i.e. he/she is a non-school-based (DECV) student who has completed the equivalent of four weeks (one module) of work since the last interim or mid-year reporting cycle. The Early Exit Report fillable PDF template can be accessed at http%3A%2F%2Fintranet%2FIntranet%2Fpages%2FForms%2520and%2520Files.aspx. %0A%0APlease complete the Early Exit Report Fillable PDF and email it as an attachment to Kathryn Allen within three (3) working days of receiving this email so it can be collated and despatched.%0A%0AThank You."
	 item.linkEarlyExitHrefParameters.Add("body",(tmpEmailBody).ToString())
	 if not IsDBNull(item.linkEarlyExitHref) then
			UpdateFormlinkEarlyExit.HRef = "mailto:" & item.linkEarlyExitHref & item.linkEarlyExitHrefParameters.ToString("None","", ViewState)
			'''''UpdateFormlinkEarlyExit.HRef = "mailto:" & HttpContext.Current.Server.UrlEncode( item.linkEarlyExitHref & item.linkEarlyExitHrefParameters.ToString("None","", ViewState)) & ""
			'UpdateFormlinkEarlyExit.HRef = "javascript:makeEarlyExitEmail('" & ( item.linkEarlyExitHref & item.linkEarlyExitHrefParameters.ToString("None","", ViewState)) & "');"
			'UpdateFormlinkEarlyExit.HRef = "javascript:window.open('mailto:" & HttpContext.Current.Server.UrlEncode( item.linkEarlyExitHref & item.linkEarlyExitHrefParameters.ToString("None","", ViewState)) & "');"
	 end if
    
    ' -------------------------
'End Link linkEarlyExit Event BeforeShow. Action Custom Code

'Record Form UpdateForm Show method tail @53-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @53-B4CAEF91

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        Try
        item.withdrawaldate.IsEmpty = IsNothing(Request.Form(UpdateFormwithdrawaldate.UniqueID))
        If ControlCustomValues("UpdateFormwithdrawaldate") Is Nothing Then
            item.withdrawaldate.SetValue(UpdateFormwithdrawaldate.Text)
        Else
            item.withdrawaldate.SetValue(ControlCustomValues("UpdateFormwithdrawaldate"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("withdrawaldate",String.Format(Resources.strings.CCS_IncorrectFormat,"Withdrawal Date","dd/mm/yyyy"))
        End Try
        item.listReasonOff.IsEmpty = IsNothing(Request.Form(UpdateFormlistReasonOff.UniqueID))
        item.listReasonOff.SetValue(UpdateFormlistReasonOff.Value)
        item.listReasonOffItems.CopyFrom(UpdateFormlistReasonOff.Items)
        item.listSub_Enrol_Status.IsEmpty = IsNothing(Request.Form(UpdateFormlistSub_Enrol_Status.UniqueID))
        item.listSub_Enrol_Status.SetValue(UpdateFormlistSub_Enrol_Status.Value)
        item.listSub_Enrol_StatusItems.CopyFrom(UpdateFormlistSub_Enrol_Status.Items)
        item.listNonSubmitReason.IsEmpty = IsNothing(Request.Form(UpdateFormlistNonSubmitReason.UniqueID))
        item.listNonSubmitReason.SetValue(UpdateFormlistNonSubmitReason.Value)
        item.listNonSubmitReasonItems.CopyFrom(UpdateFormlistNonSubmitReason.Items)
        item.coord_comment.IsEmpty = IsNothing(Request.Form(UpdateFormcoord_comment.UniqueID))
        If ControlCustomValues("UpdateFormcoord_comment") Is Nothing Then
            item.coord_comment.SetValue(UpdateFormcoord_comment.Text)
        Else
            item.coord_comment.SetValue(ControlCustomValues("UpdateFormcoord_comment"))
        End If
        If EnableValidation Then
            item.Validate(UpdateFormData)
        End If
        UpdateFormErrors.Add(item.errors)
    End Sub
'End Record Form UpdateForm LoadItemFromRequest method

'Record Form UpdateForm GetRedirectUrl method @53-E63A1AD3

    Protected Function GetUpdateFormRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form UpdateForm GetRedirectUrl method

'Record Form UpdateForm ShowErrors method @53-52F4A342

    Protected Sub UpdateFormShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To UpdateFormErrors.Count - 1
        Select Case UpdateFormErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & UpdateFormErrors(i)
        End Select
        Next i
        UpdateFormError.Visible = True
        UpdateFormErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form UpdateForm ShowErrors method

'Record Form UpdateForm Insert Operation @53-337A0C41

    Protected Sub UpdateForm_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Insert Operation

'Record Form UpdateForm BeforeInsert tail @53-B633AE71
    UpdateFormParameters()
    UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm BeforeInsert tail

'Record Form UpdateForm AfterInsert tail  @53-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm AfterInsert tail 

'Record Form UpdateForm Update Operation @53-26B5347A

    Protected Sub UpdateForm_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Update Operation

'Record Form UpdateForm Before Update tail @53-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm Before Update tail

'Record Form UpdateForm Update Operation tail @53-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm Update Operation tail

'Record Form UpdateForm Delete Operation @53-339A2861
    Protected Sub UpdateForm_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form UpdateForm Delete Operation

'Record Form BeforeDelete tail @53-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @53-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form UpdateForm Cancel Operation @53-062247BE

    Protected Sub UpdateForm_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        UpdateFormLoadItemFromRequest(item, True)
'End Record Form UpdateForm Cancel Operation

'Record Form UpdateForm Cancel Operation tail @53-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form UpdateForm Cancel Operation tail

'Button Button_DoUpdate OnClick Handler @45-E5D60DA0
    Protected Sub UpdateForm_Button_DoUpdate_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate OnClick Handler

'Button Button_DoUpdate Event OnClick. Action Custom Code @52-73254650
    ' -------------------------
      'ERA: sort through the selected subjects
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strSubjectID as string
		'	UpdateFormlblSelections.Text = "<br>Date: " & item.despatchdate.value
		'	UpdateFormlblSelections.Text += "<br>Books from " & item.book_range_from.getformattedvalue() & " to " & item.book_range_to.getformattedvalue() 
		'	UpdateFormlblSelections.Text += "<br>Semester1: " & item.semester_1.value
		'	UpdateFormlblSelections.Text += "<br>Semester2: " & item.semester_2.value
		'	UpdateFormlblSelections.Text += "<br>SemesterB: " & item.semester_both.value
        '   UpdateFormlblSelections.Text += "<br>Subjects selected:<br><br>"
  		'	for each repItem in SUBJECTRepeater.items
  		'		chkBoxed = repItem.FindControl("SUBJECTcbox")
  		'		if chkBoxed.checked then
  		'			strSubjectID = ctype(repItem.FindControl("SUBJECTSubject_ID"),Literal).Text
        '           UpdateFormlblSelections.Text += "<br>Subjects ID: " & strSubjectID.ToString
        '       End If
        '   Next
        If (not ErrorFlag) Then

                ' ensure the date is in yyyy-MM-dd format for standard SQL
                'set as local variable
                'Dim GBformat As New CultureInfo("en-GB", True)
                'Dim strDateTemp As String = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(item.despatchdate.Value, GBformat))

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

                'Dim trans As OleDb.OleDbTransaction    ' LN: 8/11/2013
                'Dim cmd As OleDb.OleDbCommand          ' LN: 8/11/2013
                Dim trans As SqlClient.SqlTransaction   ' LN: 8/11/2013
                Dim cmd As SqlClient.SqlCommand         ' LN: 8/11/2013

   				Try
					UpdateFormlblSelections.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""
					Dim tmpUsername As String
					 If (Session("UserID") is nothing) Then
                        tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    
					dim intTmpWDCounter as integer = 0
					dim tmpenrolstatus as string = ""
					dim tmpWDDate as string = ""

					if item.listsub_enrol_status.value = "W" then
						tmpenrolstatus = "W"
						tmpWDDate = "'" & item.withdrawaldate.Value & "'"
						' June 2008|EA| swap tmpWDDate as incorrect in original code
					else
						tmpenrolstatus = item.listsub_enrol_status.value
						tmpWDDate = "null"
                    End If

                    For Each repItem In SUBJECTRepeater.Items
                        chkBoxed = repItem.FindControl("SUBJECTcbox")
                        If chkBoxed.Checked Then
                            strSubjectID = CType(repItem.FindControl("SUBJECTSubject_ID"), Literal).Text
                            If strSubjectID <> "" Then
                                'NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer)

								strSQL = "update STUDENT_SUBJECT "
								strSQL += " set WITHDRAWAL_DATE= " & tmpWDdate.tostring & " "
								strSQL += " , SUBJ_ENROL_STATUS='" & tmpenrolstatus & "' "
								strSQL += " , WITHDRAWAL_REASON_ID= " & NewDao.ToSql(item.listReasonOff.value, FieldType._Integer) & " "
								strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
								strSQL += " , LAST_ALTERED_DATE=getdate() "
								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and STUDENT_ID= " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
                                strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolYear.Text, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()

								intTmpWDCounter += 1
                                'UpdateFormlblSelections.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

					' final update depending on how many subjects withdrawn

					if (intTmpWDCounter = SUBJECTRepeater.items.count) then
						strSQL = "update STUDENT_ENROLMENT "
						strSQL += " set WITHDRAWAL_DATE=" & tmpWDdate.tostring & "  "
						strSQL += " , ENROLMENT_STATUS='N' , WITHDRAWAL_REASON_ID=" & NewDao.ToSql(item.listReasonOff.value, FieldType._Integer) & " "
                        strSQL += "where STUDENT_ID= " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
                        strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolYear.Text, FieldType._Integer) & " "
                        UpdateFormlblSelections.Text += "<br><font color=red>No more enrolled subjects, Student Enrolment is now Withdrawn</font>"
					else
						strSQL = "update STUDENT_ENROLMENT "
						strSQL += " set WITHDRAWAL_DATE= null "
						strSQL += " , ENROLMENT_STATUS='E' , WITHDRAWAL_REASON_ID= null "
                        strSQL += "where STUDENT_ID= " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
                        strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolYear.Text, FieldType._Integer) & " "
					end if
					cmd.CommandText = strSQL
					cmd.ExecuteNonQuery()
					'UpdateFormlblSelections.Text += "<hr>" & strSQL

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student Subject Update performed successfully for Student ID " & Me.UpdateFormlblStudentID.text & "</font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student Subject Update <b>FAILED</b> for Student ID " & Me.UpdateFormlblStudentID.text & "</font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button Button_DoUpdate Event OnClick. Action Custom Code

'Button Button_DoUpdate OnClick Handler tail @45-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
   'ERA: don't redirect - stay on page to view error
        'Else
         '   Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate OnClick Handler tail

'Button Button_DoUpdate1 OnClick Handler @76-5B8BAA25
    Protected Sub UpdateForm_Button_DoUpdate1_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, False)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate1 OnClick Handler

'Button Button_DoUpdate1 Event OnClick. Action Custom Code @77-73254650
    ' -------------------------
    	'20-Feb-2014|EA| per request by Lidia M. allow bulk NSUBMIT setting for subjects
    	' by coordinator (based on WD code, to process selected subjects
    	' will set the TEacher to the selected NSUBMIT
    	
    	'12-Mar-2015|EA| change from using NSUBMITx to flagging NON_SUBMITTING_FLAG to 1 (unfuddle #690)
    	
      'ERA: sort through the selected subjects
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strSubjectID as string
		Dim strSQL As String = ""
  		'27-Feb-2014|EA| copied from the other update button - this is for unfuddle (#613) to do similar
  		'		updates for NSUBMIT for selected subjects.
  		
        '   UpdateFormlblSelections.Text += "<br>Subjects selected:<br><br>"
  		'	for each repItem in SUBJECTRepeater.items
  		'		chkBoxed = repItem.FindControl("SUBJECTcbox")
  		'		if chkBoxed.checked then
  		'			strSubjectID = ctype(repItem.FindControl("SUBJECTSubject_ID"),Literal).Text
        '           UpdateFormlblSelections.Text += "<br>Subjects ID: " & strSubjectID.ToString
        '       End If
        '   Next
        
        'ERA: currently have NSUBMITx - where x relates to Year Level P/7/8/9 and 0 for 10. Will select right one
        ' We may at a later stage put a general purpose NSUBMIT teacher, but that will need to be added to the 
        ' STAFF table so the foreign key to STUDENT_SUBJECT will work.
'12-Mar-2015|EA| change from using NSUBMITx to flagging NON_SUBMITTING_FLAG to 1 (unfuddle #690)
'        dim tmpNSUBMIT as string = "NSUBMIT0"
'        dim tmpYearLevel as integer = Convert.toInt32(Me.UpdateFormlblYearLevel.Text)
                
'        Select Case tmpYearLevel
'    		Case 0 To 6
'				tmpNSUBMIT = "NSUBMITP"
'    		Case 7
'				tmpNSUBMIT = "NSUBMIT7"
'    		Case 8
'				tmpNSUBMIT = "NSUBMIT8"
'			Case 9
'				tmpNSUBMIT = "NSUBMIT9"
'    		Case Else
'				tmpNSUBMIT = "NSUBMIT0"	'Year 10 and any others, just in case
'		End Select
' end 12 Mar
        
        If (not ErrorFlag) Then

                ' ensure the date is in yyyy-MM-dd format for standard SQL
                'set as local variable
                'Dim GBformat As New CultureInfo("en-GB", True)
                'Dim strDateTemp As String = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(item.despatchdate.Value, GBformat))

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

                Dim trans As SqlClient.SqlTransaction
                Dim cmd As SqlClient.SqlCommand

   				Try
					UpdateFormlblSelections.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans


					Dim tmpUsername As String
					 If (Session("UserID") is nothing) Then
                        tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    
                    For Each repItem In SUBJECTRepeater.Items
                        chkBoxed = repItem.FindControl("SUBJECTcbox")
                        If chkBoxed.Checked Then
                            strSubjectID = CType(repItem.FindControl("SUBJECTSubject_ID"), Literal).Text
                            If strSubjectID <> "" Then
                                'NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer)

								'12-Mar-2015|EA| change from using NSUBMITx to flagging NON_SUBMITTING_FLAG to 1 (unfuddle #690)
								strSQL = "update STUDENT_SUBJECT "
								'strSQL += " set STAFF_ID= " & NewDao.ToSql(tmpNSUBMIT, FieldType._Text) & " "
								strSQL += " set NON_SUBMITTING_FLAG = 1 "
								strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
								strSQL += " , LAST_ALTERED_DATE=getdate() "
								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and STUDENT_ID= " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
                                strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolYear.Text, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()
								'DEBUG
                                'UpdateFormlblSelections.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

					
					' update student SST to NSUBMIT - later if needed we can use the yearlevel label to choose the right NSUBMITP/7/8/9/0
'12-Mar-2015|EA| change from using NSUBMITx to flagging NON_SUBMITTING_FLAG to 1 (unfuddle #690)
'					if (Me.UpdateFormlblStudentID.Text <> "") then
'						strSQL = "update STUDENT_ENROLMENT set PASTORAL_CARE_ID=" & NewDao.ToSql(tmpNSUBMIT, FieldType._Text) & " "
'                        strSQL += "where STUDENT_ID= " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
'                        strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolYear.Text, FieldType._Integer) & " "
'                        UpdateFormlblSelections.Text += "<br><font color=green>SS Teacher changed to '"& tmpNSUBMIT &"'</font>"
'                        'DEBUG
'						'UpdateFormlblSelections.Text += "<hr>" & strSQL
'					end if
					
'					cmd.CommandText = strSQL
'					cmd.ExecuteNonQuery()
' end 12 Mar
					
					' add coord comment if there is one.
					if (Me.UpdateFormcoord_comment.Text <> "") then
						strSQL = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE])  "
						strSQL += "select (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) " 
						strSQL += ", " & NewDao.ToSql(Me.UpdateFormlblStudentID.Text, FieldType._Integer) & " "
						strSQL += ", " & NewDao.ToSql(Me.UpdateFormcoord_comment.Text, FieldType._Text) & " "
						strSQL += ", " & tmpUsername & ", getdate(),'A','COORD_DECISION' "
                        UpdateFormlblSelections.Text += "<br><font color=green>Coordinator Comment Added</font>"
						'DEBUG
						'UpdateFormlblSelections.Text += "<hr>" & strSQL
					end if
					
					cmd.CommandText = strSQL
					cmd.ExecuteNonQuery()

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=green><strong>Student Non-Submitting Update performed successfully for Student ID " & Me.UpdateFormlblStudentID.text & "</strong></font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student Non-Submitting Update <b>FAILED</b> for Student ID " & Me.UpdateFormlblStudentID.text & "</font>"
                    UpdateFormlblSelections.Text += "<br>Error: [" & ex.Message.ToString & "]"
                    UpdateFormlblSelections.Text += "<br>SQL: [" & strSQL & "]"
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button Button_DoUpdate1 Event OnClick. Action Custom Code

'Button Button_DoUpdate1 OnClick Handler tail @76-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
	'ERA: don't redirect - stay on page to view error
        'Else
         '   Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate1 OnClick Handler tail

'Grid SUBJECT Bind @3-8BE7C752

    Protected Sub SUBJECTBind()
        If Not SUBJECTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT",GetType(SUBJECTDataProvider.SortFields), 80, 100)
        End If
'End Grid SUBJECT Bind

'Grid Form SUBJECT BeforeShow tail @3-9CDB5C02
        SUBJECTParameters()
        SUBJECTData.SortField = CType(ViewState("SUBJECTSortField"),SUBJECTDataProvider.SortFields)
        SUBJECTData.SortDir = CType(ViewState("SUBJECTSortDir"),SortDirections)
        SUBJECTData.PageNumber = CInt(ViewState("SUBJECTPageNumber"))
        SUBJECTData.RecordsPerPage = CInt(ViewState("SUBJECTPageSize"))
        SUBJECTRepeater.DataSource = SUBJECTData.GetResultSet(PagesCount, SUBJECTOperations)
        ViewState("SUBJECTPagesCount") = PagesCount
        Dim item As SUBJECTItem = New SUBJECTItem()
        SUBJECTRepeater.DataBind
        FooterIndex = SUBJECTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SUBJECTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim SUBJECTSUBJECT_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(SUBJECTRepeater.Controls(0).FindControl("SUBJECTSUBJECT_TotalRecords"),System.Web.UI.WebControls.Literal)

        SUBJECTSUBJECT_TotalRecords.Text = Server.HtmlEncode(item.SUBJECT_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form SUBJECT BeforeShow tail

'Label SUBJECT_TotalRecords Event BeforeShow. Action Retrieve number of records @12-D68F1E16
            SUBJECTSUBJECT_TotalRecords.Text = SUBJECTData.RecordCount.ToString()
'End Label SUBJECT_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid SUBJECT Bind tail @3-E31F8E2A
    End Sub
'End Grid SUBJECT Bind tail

'Grid SUBJECT Table Parameters @3-1C6F5BAC

    Protected Sub SUBJECTParameters()
        Try
            SUBJECTData.Urls_STUDENT_ID = TextParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            SUBJECTData.Urls_ENROL_YEAR = TextParameter.GetParam("s_ENROL_YEAR", ParameterSourceType.URL, "", year(now()), false)

        Catch
            Dim ParentControls As ControlCollection=SUBJECTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SUBJECTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SUBJECT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SUBJECT Table Parameters

'Grid SUBJECT ItemDataBound event @3-99BC924D

    Protected Sub SUBJECTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SUBJECTItem = CType(e.Item.DataItem,SUBJECTItem)
        Dim Item as SUBJECTItem = DataItem
        Dim FormDataSource As SUBJECTItem() = CType(SUBJECTRepeater.DataSource, SUBJECTItem())
        Dim SUBJECTDataRows As Integer = FormDataSource.Length
        Dim SUBJECTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SUBJECTcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("SUBJECTcbox"),System.Web.UI.WebControls.CheckBox)
            Dim SUBJECTSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSTATUS"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTNON_SUBMIT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTNON_SUBMIT"),System.Web.UI.WebControls.Literal)
            If DataItem.cboxCheckedValue.Value.Equals(DataItem.cbox.Value) Then
                SUBJECTcbox.Checked = True
            End If
        End If
'End Grid SUBJECT ItemDataBound event

'Grid SUBJECT BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid SUBJECT BeforeShowRow event

'Grid SUBJECT Event BeforeShowRow. Action Set Row Style @17-DF8BE80B
            Dim styles17 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex17 As Integer = (SUBJECTCurrentRowNumber - 1) Mod styles17.Length
            Dim rawStyle17 As String = styles17(styleIndex17).Replace("\;",";")
            If rawStyle17.IndexOf("=") = -1 And rawStyle17.IndexOf(":") > -1 Then
                rawStyle17 = "style=""" + rawStyle17 + """"
            ElseIf rawStyle17.IndexOf("=") = -1 And rawStyle17.IndexOf(":") = -1 And rawStyle17 <> "" Then
                rawStyle17 = "class=""" + rawStyle17 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle17), AttributeOption.Multiple)
'End Grid SUBJECT Event BeforeShowRow. Action Set Row Style

'Grid SUBJECT Event BeforeShowRow. Action Custom Code @75-73254650
    ' -------------------------
    'ERA: change colour of row depending on comment type
    
    Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("displaysubjects_row"),System.Web.UI.HtmlControls.HtmlTableRow)

	if (DataItem.status.value = "W") Then
      comment_row.Attributes("Class") = "AltRow"
    Else
      comment_row.Attributes("Class") = "Row"
    End if 
    ' -------------------------
'End Grid SUBJECT Event BeforeShowRow. Action Custom Code

'Grid SUBJECT BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid SUBJECT BeforeShowRow event tail

'Grid SUBJECT ItemDataBound event tail @3-2D28AE0B
        If SUBJECTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SUBJECTCurrentRowNumber, ListItemType.Item)
            SUBJECTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SUBJECTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SUBJECT ItemDataBound event tail

'Grid SUBJECT ItemCommand event @3-0DD9B41C

    Protected Sub SUBJECTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SUBJECTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SUBJECTSortDir"),SortDirections) = SortDirections._Asc And ViewState("SUBJECTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SUBJECTSortDir")=SortDirections._Desc
                Else
                    ViewState("SUBJECTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SUBJECTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SUBJECTDataProvider.SortFields = 0
            ViewState("SUBJECTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SUBJECTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SUBJECTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SUBJECTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SUBJECTBind
        End If
    End Sub
'End Grid SUBJECT ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-30920670
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Subject_WithdrawalsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTSearchData = New SUBJECTSearchDataProvider()
        SUBJECTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        UpdateFormData = New UpdateFormDataProvider()
        UpdateFormOperations = New FormSupportedOperations(False, True, False, False, False)
        SUBJECTData = New SUBJECTDataProvider()
        SUBJECTOperations = New FormSupportedOperations(False, True, False, False, False)
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

