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

Namespace DECV_PROD2007.Student_Future_Intentions 'Namespace @1-3AEF8BD5

'Forms Definition @1-B5069032
Public Class [Student_Future_IntentionsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-B92564E9
    Protected STUDENT_FUTURE_INTENTIONSData As STUDENT_FUTURE_INTENTIONSDataProvider
    Protected STUDENT_FUTURE_INTENTIONSErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_FUTURE_INTENTIONSOperations As FormSupportedOperations
    Protected STUDENT_FUTURE_INTENTIONSIsSubmitted As Boolean = False
    Protected Student_Future_IntentionsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-2F0027B4
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf,"")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref+item.Link_BacktoPastoralListHrefParameters.ToString("None","", ViewState)
            Link_BacktoPastoralList.DataBind()
            STUDENT_FUTURE_INTENTIONSShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @49-73254650
    ' -------------------------
   'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")
	 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MenuStudentMaintain.visible = true
     End If
    ' -------------------------
'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_FUTURE_INTENTIONS Parameters @3-6503A94F

    Protected Sub STUDENT_FUTURE_INTENTIONSParameters()
        Dim item As new STUDENT_FUTURE_INTENTIONSItem
        Try
            STUDENT_FUTURE_INTENTIONSData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_FUTURE_INTENTIONSData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_FUTURE_INTENTIONSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS Parameters

'Record Form STUDENT_FUTURE_INTENTIONS Show method @3-B8C8EA32
    Protected Sub STUDENT_FUTURE_INTENTIONSShow()
        If STUDENT_FUTURE_INTENTIONSOperations.None Then
            STUDENT_FUTURE_INTENTIONSHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_FUTURE_INTENTIONSItem = STUDENT_FUTURE_INTENTIONSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_FUTURE_INTENTIONSOperations.AllowRead
        STUDENT_FUTURE_INTENTIONSErrors.Add(item.errors)
        If STUDENT_FUTURE_INTENTIONSErrors.Count > 0 Then
            STUDENT_FUTURE_INTENTIONSShowErrors()
            Return
        End If
'End Record Form STUDENT_FUTURE_INTENTIONS Show method

'Record Form STUDENT_FUTURE_INTENTIONS BeforeShow tail @3-AEA27485
        STUDENT_FUTURE_INTENTIONSParameters()
        STUDENT_FUTURE_INTENTIONSData.FillItem(item, IsInsertMode)
        STUDENT_FUTURE_INTENTIONSHolder.DataBind()
        STUDENT_FUTURE_INTENTIONSButton_Insert.Visible=IsInsertMode AndAlso STUDENT_FUTURE_INTENTIONSOperations.AllowInsert
        STUDENT_FUTURE_INTENTIONSButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_FUTURE_INTENTIONSOperations.AllowUpdate
        STUDENT_FUTURE_INTENTIONSSCHOOL_NAME.Text=item.SCHOOL_NAME.GetFormattedValue()
        STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL.Text=item.EMPLOYER_DETAIL.GetFormattedValue()
        item.RE_ENROLMENT_FLAGItems.SetSelection(item.RE_ENROLMENT_FLAG.GetFormattedValue())
        STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.SelectedIndex = -1
        item.RE_ENROLMENT_FLAGItems.CopyTo(STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.Items)
        item.NEW_SCHOOL_FLAGItems.SetSelection(item.NEW_SCHOOL_FLAG.GetFormattedValue())
        STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.SelectedIndex = -1
        item.NEW_SCHOOL_FLAGItems.CopyTo(STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.Items)
        item.LEAVING_FLAGItems.SetSelection(item.LEAVING_FLAG.GetFormattedValue())
        STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.SelectedIndex = -1
        item.LEAVING_FLAGItems.CopyTo(STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.Items)
        item.SEEKING_WORK_FLAGItems.SetSelection(item.SEEKING_WORK_FLAG.GetFormattedValue())
        STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.SelectedIndex = -1
        item.SEEKING_WORK_FLAGItems.CopyTo(STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.Items)
        item.EMPLOYMENT_FLAGItems.SetSelection(item.EMPLOYMENT_FLAG.GetFormattedValue())
        STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.SelectedIndex = -1
        item.EMPLOYMENT_FLAGItems.CopyTo(STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.Items)
        STUDENT_FUTURE_INTENTIONSLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_FUTURE_INTENTIONSLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_FUTURE_INTENTIONSSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_FUTURE_INTENTIONSENROLMENT_YEAR.Text = Server.HtmlEncode(item.ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_FUTURE_INTENTIONSHidden_lastalteredby.Value = item.Hidden_lastalteredby.GetFormattedValue()
        STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date.Value = item.Hidden_lastaltered_date.GetFormattedValue()
        STUDENT_FUTURE_INTENTIONSHidden_student_id.Value = item.Hidden_student_id.GetFormattedValue()
        STUDENT_FUTURE_INTENTIONSHidden_enrolmentyear.Value = item.Hidden_enrolmentyear.GetFormattedValue()
'End Record Form STUDENT_FUTURE_INTENTIONS BeforeShow tail

'Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control @30-72B31F2E
            STUDENT_FUTURE_INTENTIONSSTUDENT_ID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control @31-FD725700
            STUDENT_FUTURE_INTENTIONSENROLMENT_YEAR.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control @36-6180F71B
            STUDENT_FUTURE_INTENTIONSHidden_student_id.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control @37-6CFB8E55
            STUDENT_FUTURE_INTENTIONSHidden_enrolmentyear.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_FUTURE_INTENTIONS Show method tail @3-46FB61B6
        If STUDENT_FUTURE_INTENTIONSErrors.Count > 0 Then
            STUDENT_FUTURE_INTENTIONSShowErrors()
        End If
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS Show method tail

'Record Form STUDENT_FUTURE_INTENTIONS LoadItemFromRequest method @3-DE16E163

    Protected Sub STUDENT_FUTURE_INTENTIONSLoadItemFromRequest(item As STUDENT_FUTURE_INTENTIONSItem, ByVal EnableValidation As Boolean)
        item.SCHOOL_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSSCHOOL_NAME.UniqueID))
        If ControlCustomValues("STUDENT_FUTURE_INTENTIONSSCHOOL_NAME") Is Nothing Then
            item.SCHOOL_NAME.SetValue(STUDENT_FUTURE_INTENTIONSSCHOOL_NAME.Text)
        Else
            item.SCHOOL_NAME.SetValue(ControlCustomValues("STUDENT_FUTURE_INTENTIONSSCHOOL_NAME"))
        End If
        item.EMPLOYER_DETAIL.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL.UniqueID))
        If ControlCustomValues("STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL") Is Nothing Then
            item.EMPLOYER_DETAIL.SetValue(STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL.Text)
        Else
            item.EMPLOYER_DETAIL.SetValue(ControlCustomValues("STUDENT_FUTURE_INTENTIONSEMPLOYER_DETAIL"))
        End If
        item.RE_ENROLMENT_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.UniqueID))
        If Not IsNothing(STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.SelectedItem) Then
            item.RE_ENROLMENT_FLAG.SetValue(STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.SelectedItem.Value)
        Else
            item.RE_ENROLMENT_FLAG.Value = Nothing
        End If
        item.RE_ENROLMENT_FLAGItems.CopyFrom(STUDENT_FUTURE_INTENTIONSRE_ENROLMENT_FLAG.Items)
        item.NEW_SCHOOL_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.UniqueID))
        If Not IsNothing(STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.SelectedItem) Then
            item.NEW_SCHOOL_FLAG.SetValue(STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.SelectedItem.Value)
        Else
            item.NEW_SCHOOL_FLAG.Value = Nothing
        End If
        item.NEW_SCHOOL_FLAGItems.CopyFrom(STUDENT_FUTURE_INTENTIONSNEW_SCHOOL_FLAG.Items)
        item.LEAVING_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.UniqueID))
        If Not IsNothing(STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.SelectedItem) Then
            item.LEAVING_FLAG.SetValue(STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.SelectedItem.Value)
        Else
            item.LEAVING_FLAG.Value = Nothing
        End If
        item.LEAVING_FLAGItems.CopyFrom(STUDENT_FUTURE_INTENTIONSLEAVING_FLAG.Items)
        item.SEEKING_WORK_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.UniqueID))
        If Not IsNothing(STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.SelectedItem) Then
            item.SEEKING_WORK_FLAG.SetValue(STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.SelectedItem.Value)
        Else
            item.SEEKING_WORK_FLAG.Value = Nothing
        End If
        item.SEEKING_WORK_FLAGItems.CopyFrom(STUDENT_FUTURE_INTENTIONSSEEKING_WORK_FLAG.Items)
        item.EMPLOYMENT_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.UniqueID))
        If Not IsNothing(STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.SelectedItem) Then
            item.EMPLOYMENT_FLAG.SetValue(STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.SelectedItem.Value)
        Else
            item.EMPLOYMENT_FLAG.Value = Nothing
        End If
        item.EMPLOYMENT_FLAGItems.CopyFrom(STUDENT_FUTURE_INTENTIONSEMPLOYMENT_FLAG.Items)
        item.Hidden_lastalteredby.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSHidden_lastalteredby.UniqueID))
        item.Hidden_lastalteredby.SetValue(STUDENT_FUTURE_INTENTIONSHidden_lastalteredby.Value)
        Try
        item.Hidden_lastaltered_date.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date.UniqueID))
        item.Hidden_lastaltered_date.SetValue(STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date.Value)
        Catch ae As ArgumentException
            STUDENT_FUTURE_INTENTIONSErrors.Add("Hidden_lastaltered_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_lastaltered_date","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.Hidden_student_id.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSHidden_student_id.UniqueID))
        item.Hidden_student_id.SetValue(STUDENT_FUTURE_INTENTIONSHidden_student_id.Value)
        item.Hidden_enrolmentyear.IsEmpty = IsNothing(Request.Form(STUDENT_FUTURE_INTENTIONSHidden_enrolmentyear.UniqueID))
        item.Hidden_enrolmentyear.SetValue(STUDENT_FUTURE_INTENTIONSHidden_enrolmentyear.Value)
        If EnableValidation Then
            item.Validate(STUDENT_FUTURE_INTENTIONSData)
        End If
        STUDENT_FUTURE_INTENTIONSErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS LoadItemFromRequest method

'Record Form STUDENT_FUTURE_INTENTIONS GetRedirectUrl method @3-DA32550E

    Protected Function GetSTUDENT_FUTURE_INTENTIONSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentSummary.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_FUTURE_INTENTIONS GetRedirectUrl method

'Record Form STUDENT_FUTURE_INTENTIONS ShowErrors method @3-C46D9F4D

    Protected Sub STUDENT_FUTURE_INTENTIONSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_FUTURE_INTENTIONSErrors.Count - 1
        Select Case STUDENT_FUTURE_INTENTIONSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_FUTURE_INTENTIONSErrors(i)
        End Select
        Next i
        STUDENT_FUTURE_INTENTIONSError.Visible = True
        STUDENT_FUTURE_INTENTIONSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS ShowErrors method

'Record Form STUDENT_FUTURE_INTENTIONS Insert Operation @3-C66D50A9

    Protected Sub STUDENT_FUTURE_INTENTIONS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_FUTURE_INTENTIONSItem = New STUDENT_FUTURE_INTENTIONSItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_FUTURE_INTENTIONSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_FUTURE_INTENTIONS Insert Operation

'Button Button_Insert OnClick. @4-16A3B61D
        If CType(sender,Control).ID = "STUDENT_FUTURE_INTENTIONSButton_Insert" Then
            RedirectUrl = GetSTUDENT_FUTURE_INTENTIONSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @4-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT_FUTURE_INTENTIONS Event BeforeInsert. Action Retrieve Value for Control @40-90EBCAB2
        STUDENT_FUTURE_INTENTIONSHidden_lastalteredby.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeInsert. Action Retrieve Value for Control

'Record STUDENT_FUTURE_INTENTIONS Event BeforeInsert. Action Retrieve Value for Control @41-4934BD17
        STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeInsert. Action Retrieve Value for Control

'Record Form STUDENT_FUTURE_INTENTIONS BeforeInsert tail @3-42A280E2
    STUDENT_FUTURE_INTENTIONSParameters()
    STUDENT_FUTURE_INTENTIONSLoadItemFromRequest(item, EnableValidation)
    If STUDENT_FUTURE_INTENTIONSOperations.AllowInsert Then
        ErrorFlag=(STUDENT_FUTURE_INTENTIONSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_FUTURE_INTENTIONSData.InsertItem(item)
            Catch ex As Exception
                STUDENT_FUTURE_INTENTIONSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_FUTURE_INTENTIONS BeforeInsert tail

'Record Form STUDENT_FUTURE_INTENTIONS AfterInsert tail  @3-5898E112
        End If
        ErrorFlag=(STUDENT_FUTURE_INTENTIONSErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_FUTURE_INTENTIONSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS AfterInsert tail 

'Record Form STUDENT_FUTURE_INTENTIONS Update Operation @3-E2EA9D09

    Protected Sub STUDENT_FUTURE_INTENTIONS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_FUTURE_INTENTIONSItem = New STUDENT_FUTURE_INTENTIONSItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_FUTURE_INTENTIONSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_FUTURE_INTENTIONS Update Operation

'Button Button_Update OnClick. @5-D3586E34
        If CType(sender,Control).ID = "STUDENT_FUTURE_INTENTIONSButton_Update" Then
            RedirectUrl = GetSTUDENT_FUTURE_INTENTIONSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_FUTURE_INTENTIONS Event BeforeUpdate. Action Retrieve Value for Control @42-90EBCAB2
        STUDENT_FUTURE_INTENTIONSHidden_lastalteredby.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_FUTURE_INTENTIONS Event BeforeUpdate. Action Retrieve Value for Control @43-4934BD17
        STUDENT_FUTURE_INTENTIONSHidden_lastaltered_date.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record STUDENT_FUTURE_INTENTIONS Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_FUTURE_INTENTIONS Before Update tail @3-181E1BDC
        STUDENT_FUTURE_INTENTIONSParameters()
        STUDENT_FUTURE_INTENTIONSLoadItemFromRequest(item, EnableValidation)
        If STUDENT_FUTURE_INTENTIONSOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_FUTURE_INTENTIONSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_FUTURE_INTENTIONSData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_FUTURE_INTENTIONSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_FUTURE_INTENTIONS Before Update tail

'Record Form STUDENT_FUTURE_INTENTIONS Update Operation tail @3-5898E112
        End If
        ErrorFlag=(STUDENT_FUTURE_INTENTIONSErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_FUTURE_INTENTIONSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS Update Operation tail

'Record Form STUDENT_FUTURE_INTENTIONS Delete Operation @3-8B794C6D
    Protected Sub STUDENT_FUTURE_INTENTIONS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_FUTURE_INTENTIONSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_FUTURE_INTENTIONSItem = New STUDENT_FUTURE_INTENTIONSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_FUTURE_INTENTIONS Delete Operation

'Record Form BeforeDelete tail @3-CE11AC90
        STUDENT_FUTURE_INTENTIONSParameters()
        STUDENT_FUTURE_INTENTIONSLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-354FA76C
        If ErrorFlag Then
            STUDENT_FUTURE_INTENTIONSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_FUTURE_INTENTIONS Cancel Operation @3-A2AE3E3F

    Protected Sub STUDENT_FUTURE_INTENTIONS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_FUTURE_INTENTIONSItem = New STUDENT_FUTURE_INTENTIONSItem()
        STUDENT_FUTURE_INTENTIONSIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_FUTURE_INTENTIONSLoadItemFromRequest(item, False)
'End Record Form STUDENT_FUTURE_INTENTIONS Cancel Operation

'Button Button_Cancel OnClick. @7-9A814E65
    If CType(sender,Control).ID = "STUDENT_FUTURE_INTENTIONSButton_Cancel" Then
        RedirectUrl = GetSTUDENT_FUTURE_INTENTIONSRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @7-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_FUTURE_INTENTIONS Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_FUTURE_INTENTIONS Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-D1D19619
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Future_IntentionsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_FUTURE_INTENTIONSData = New STUDENT_FUTURE_INTENTIONSDataProvider()
        STUDENT_FUTURE_INTENTIONSOperations = New FormSupportedOperations(False, True, True, True, False)
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

