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

Namespace DECV_PROD2007.StudentSubject_Details_maintain 'Namespace @1-4051995B

'Forms Definition @1-AD54B6A4
Public Class [StudentSubject_Details_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1668D333
    Protected viewStudentSummary_SubjecData As viewStudentSummary_SubjecDataProvider
    Protected viewStudentSummary_SubjecErrors As NameValueCollection = New NameValueCollection()
    Protected viewStudentSummary_SubjecOperations As FormSupportedOperations
    Protected viewStudentSummary_SubjecIsSubmitted As Boolean = False
    Protected BOOK_DESPATCHData As BOOK_DESPATCHDataProvider
    Protected BOOK_DESPATCHOperations As FormSupportedOperations
    Protected BOOK_DESPATCHCurrentRowNumber As Integer
    Protected STUDENT_SUBJECTData As STUDENT_SUBJECTDataProvider
    Protected STUDENT_SUBJECTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_SUBJECTOperations As FormSupportedOperations
    Protected STUDENT_SUBJECTIsSubmitted As Boolean = False
    Protected EditableGrid1Data As EditableGrid1DataProvider
    Protected EditableGrid1CurrentRowNumber As Integer
    Protected EditableGrid1IsSubmitted As Boolean = False
    Protected EditableGrid1Errors As New NameValueCollection()
    Protected EditableGrid1Operations As FormSupportedOperations
    Protected EditableGrid1DataItem As EditableGrid1Item
    Protected StudentSubject_Details_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-ED19537B
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.linkSubjectListHref = "Student_Subject_maintain.aspx"
            PageData.FillItem(item)
            linkSubjectList.InnerText += item.linkSubjectList.GetFormattedValue().Replace(vbCrLf,"")
            linkSubjectList.HRef = item.linkSubjectListHref+item.linkSubjectListHrefParameters.ToString("GET","SUBJECT_ID", ViewState)
            linkSubjectList.DataBind()
            lblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
            viewStudentSummary_SubjecShow()
            BOOK_DESPATCHBind
            STUDENT_SUBJECTShow()
            EditableGrid1Bind()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form viewStudentSummary_Subjec Parameters @4-B746BAC7

    Protected Sub viewStudentSummary_SubjecParameters()
        Dim item As new viewStudentSummary_SubjecItem
        Try
            viewStudentSummary_SubjecData.Urlstudent_id = FloatParameter.GetParam("student_id", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_SubjecData.Urlenrolment_year = FloatParameter.GetParam("enrolment_year", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_SubjecData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_SubjecData.ExprKey4 = TextParameter.GetParam(dbutility.userid.tostring, ParameterSourceType.Expression, "", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlhidden_STUDENT_ID = FloatParameter.GetParam(item.hidden_STUDENT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlhidden_ENROLMENT_YEAR = FloatParameter.GetParam(item.hidden_ENROLMENT_YEAR.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlhidden_SUBJECT_ID = IntegerParameter.GetParam(item.hidden_SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.CtrlSEMESTER = TextParameter.GetParam(item.SEMESTER.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.CtrlSUBJ_ENROL_STATUS = TextParameter.GetParam(item.SUBJ_ENROL_STATUS.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlenrolment_date = DateParameter.GetParam(item.enrolment_date.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlwithdrawal_date = DateParameter.GetParam(item.withdrawal_date.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            viewStudentSummary_SubjecData.CtrlWITHDRAWAL_REASON_ID = FloatParameter.GetParam(item.WITHDRAWAL_REASON_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.CtrlSTAFF_ID = TextParameter.GetParam(item.STAFF_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.CtrlVBOS_REGISTERED = BooleanParameter.GetParam(item.VBOS_REGISTERED.Value, ParameterSourceType.Control, "Yes;No", Nothing, false)
            viewStudentSummary_SubjecData.CtrlAPPEARS_ON_VASS = BooleanParameter.GetParam(item.APPEARS_ON_VASS.Value, ParameterSourceType.Control, "Yes;No", Nothing, false)
            viewStudentSummary_SubjecData.CtrlEXTENSION_OF_VCE_UNIT = BooleanParameter.GetParam(item.EXTENSION_OF_VCE_UNIT.Value, ParameterSourceType.Control, "Yes;No", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlhidden_LAST_ALTERED_BY = TextParameter.GetParam(item.hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentSummary_SubjecData.Ctrlhidden_LAST_ALTERED_DATE = DateParameter.GetParam(item.hidden_LAST_ALTERED_DATE.Value, ParameterSourceType.Control, "yyyy-MM-dd HH\:mm\:ss", Nothing, false)
            viewStudentSummary_SubjecData.CtrlNON_SUBMITTING_FLAG = IntegerParameter.GetParam(item.NON_SUBMITTING_FLAG.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            viewStudentSummary_SubjecErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewStudentSummary_Subjec Parameters

'Record Form viewStudentSummary_Subjec Show method @4-5497A616
    Protected Sub viewStudentSummary_SubjecShow()
        If viewStudentSummary_SubjecOperations.None Then
            viewStudentSummary_SubjecHolder.Visible = False
            Return
        End If
        Dim item As viewStudentSummary_SubjecItem = viewStudentSummary_SubjecItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewStudentSummary_SubjecOperations.AllowRead
        viewStudentSummary_SubjecErrors.Add(item.errors)
        If viewStudentSummary_SubjecErrors.Count > 0 Then
            viewStudentSummary_SubjecShowErrors()
            Return
        End If
'End Record Form viewStudentSummary_Subjec Show method

'Record Form viewStudentSummary_Subjec BeforeShow tail @4-34527EA7
        viewStudentSummary_SubjecParameters()
        viewStudentSummary_SubjecData.FillItem(item, IsInsertMode)
        viewStudentSummary_SubjecHolder.DataBind()
        viewStudentSummary_SubjecButton_Extend.Visible=IsInsertMode AndAlso viewStudentSummary_SubjecOperations.AllowInsert
        viewStudentSummary_SubjecButton_Update.Visible=Not (IsInsertMode) AndAlso viewStudentSummary_SubjecOperations.AllowUpdate
        viewStudentSummary_Subjecstudent_id.Text = Server.HtmlEncode(item.student_id.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Subjecenrolment_year.Text = Server.HtmlEncode(item.enrolment_year.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecSUBJECT_ID.Text = Server.HtmlEncode(item.SUBJECT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecSUBJECT_TITLE.Text = Server.HtmlEncode(item.SUBJECT_TITLE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecSEMESTER.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecSEMESTER.Items(0).Selected = True
        item.SEMESTERItems.SetSelection(item.SEMESTER.GetFormattedValue())
        If Not item.SEMESTERItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecSEMESTER.SelectedIndex = -1
        End If
        item.SEMESTERItems.CopyTo(viewStudentSummary_SubjecSEMESTER.Items)
        viewStudentSummary_SubjecCOURSE_DISTRIBUTION.Text = Server.HtmlEncode(item.COURSE_DISTRIBUTION.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecSUBJ_ENROL_STATUS.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecSUBJ_ENROL_STATUS.Items(0).Selected = True
        item.SUBJ_ENROL_STATUSItems.SetSelection(item.SUBJ_ENROL_STATUS.GetFormattedValue())
        If Not item.SUBJ_ENROL_STATUSItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecSUBJ_ENROL_STATUS.SelectedIndex = -1
        End If
        item.SUBJ_ENROL_STATUSItems.CopyTo(viewStudentSummary_SubjecSUBJ_ENROL_STATUS.Items)
        viewStudentSummary_Subjecenrolment_date.Text=item.enrolment_date.GetFormattedValue()
        viewStudentSummary_Subjecwithdrawal_date.Text=item.withdrawal_date.GetFormattedValue()
        viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.Items(0).Selected = True
        item.WITHDRAWAL_REASON_IDItems.SetSelection(item.WITHDRAWAL_REASON_ID.GetFormattedValue())
        If Not item.WITHDRAWAL_REASON_IDItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.SelectedIndex = -1
        End If
        item.WITHDRAWAL_REASON_IDItems.CopyTo(viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.Items)
        viewStudentSummary_SubjecNUM_ASSMT_SUBMISSIONS.Text = Server.HtmlEncode(item.NUM_ASSMT_SUBMISSIONS.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecSTAFF_ID.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecSTAFF_ID.Items(0).Selected = True
        item.STAFF_IDItems.SetSelection(item.STAFF_ID.GetFormattedValue())
        If Not item.STAFF_IDItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecSTAFF_ID.SelectedIndex = -1
        End If
        item.STAFF_IDItems.CopyTo(viewStudentSummary_SubjecSTAFF_ID.Items)
        viewStudentSummary_SubjecFINAL_PROGRESS_CODE.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecFINAL_PROGRESS_CODE.Items(0).Selected = True
        item.FINAL_PROGRESS_CODEItems.SetSelection(item.FINAL_PROGRESS_CODE.GetFormattedValue())
        If Not item.FINAL_PROGRESS_CODEItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecFINAL_PROGRESS_CODE.SelectedIndex = -1
        End If
        item.FINAL_PROGRESS_CODEItems.CopyTo(viewStudentSummary_SubjecFINAL_PROGRESS_CODE.Items)
        item.VBOS_REGISTEREDItems.SetSelection(item.VBOS_REGISTERED.GetFormattedValue())
        viewStudentSummary_SubjecVBOS_REGISTERED.SelectedIndex = -1
        item.VBOS_REGISTEREDItems.CopyTo(viewStudentSummary_SubjecVBOS_REGISTERED.Items)
        item.APPEARS_ON_VASSItems.SetSelection(item.APPEARS_ON_VASS.GetFormattedValue())
        viewStudentSummary_SubjecAPPEARS_ON_VASS.SelectedIndex = -1
        item.APPEARS_ON_VASSItems.CopyTo(viewStudentSummary_SubjecAPPEARS_ON_VASS.Items)
        viewStudentSummary_SubjecLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Subjechidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        viewStudentSummary_Subjechidden_ENROLMENT_YEAR.Value = item.hidden_ENROLMENT_YEAR.GetFormattedValue()
        viewStudentSummary_Subjechidden_SUBJECT_ID.Value = item.hidden_SUBJECT_ID.GetFormattedValue()
        viewStudentSummary_Subjechidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        viewStudentSummary_Subjechidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        viewStudentSummary_SubjeclblSTAFF_ID.Text = Server.HtmlEncode(item.lblSTAFF_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjeclblDebug2.Text = Server.HtmlEncode(item.lblDebug2.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.Items.Add(new ListItem("Select Value",""))
        viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.Items(0).Selected = True
        item.INTERIM_PROGRESS_CODEItems.SetSelection(item.INTERIM_PROGRESS_CODE.GetFormattedValue())
        If Not item.INTERIM_PROGRESS_CODEItems.GetSelectedItem() Is Nothing Then
            viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.SelectedIndex = -1
        End If
        item.INTERIM_PROGRESS_CODEItems.CopyTo(viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.Items)
        item.EXTENSION_OF_VCE_UNITItems.SetSelection(item.EXTENSION_OF_VCE_UNIT.GetFormattedValue())
        viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.SelectedIndex = -1
        item.EXTENSION_OF_VCE_UNITItems.CopyTo(viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.Items)
        item.NON_SUBMITTING_FLAGItems.SetSelection(item.NON_SUBMITTING_FLAG.GetFormattedValue())
        viewStudentSummary_SubjecNON_SUBMITTING_FLAG.SelectedIndex = -1
        item.NON_SUBMITTING_FLAGItems.CopyTo(viewStudentSummary_SubjecNON_SUBMITTING_FLAG.Items)
        viewStudentSummary_SubjeclabelErrorStaffID.Text = item.labelErrorStaffID.GetFormattedValue()
'End Record Form viewStudentSummary_Subjec BeforeShow tail

'ListBox STAFF_ID Event BeforeShow. Action Custom Code @121-73254650
    ' -------------------------
     '1-Nov-2012|EA| per Matt, if subject is Launchpad (921,922,923) or Discovery Learning (931,932,933) then disable Staff list
     '	as should be changed on SS Teacher and cascade to here.
     Dim introductorySubjectQuery = "select concat(cast(vis.IntroductorySubjectID as varchar(20)), ',') from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1) for xml path('');"
     Dim introductorySubjectQueryResult = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(introductorySubjectQuery).ToString()
     Dim introductorySubjectIDs = introductorySubjectQueryResult.Split({","c}, StringSplitOptions.RemoveEmptyEntries)

     If (introductorySubjectIDs.Contains(item.SUBJECT_ID.GetFormattedValue().Trim())) Then
         viewStudentSummary_SubjecSTAFF_ID.visible = False
         'viewStudentSummary_SubjecSTAFF_ID.
     Else
         ' 26 Oct 2021|RW| Remove the system values from the list of options for assigning a student subject teacher
         ' However if the current selection is a system value, eg. N-A, it must be left as-is.
         Dim itemsToRemoveIfNotSelected = {"N-A", "NO_SST", "UNASSIGN"}
         Dim itemIndex = 0
         While (itemIndex < viewStudentSummary_SubjecSTAFF_ID.Items.Count)
            Dim listItem = viewStudentSummary_SubjecSTAFF_ID.Items(itemIndex)
            Dim itemValue = listItem.Value.Trim().ToUpper()
            Dim itemRemoved = False
            If ((Not listItem.Selected) AndAlso
                  (itemsToRemoveIfNotSelected.Contains(itemValue) OrElse itemValue.StartsWith("NSUBMIT"))) Then
               viewStudentSummary_SubjecSTAFF_ID.Items.Remove(listItem)
               itemRemoved = True
            End If

            If (Not itemRemoved) Then
               itemIndex += 1
            End If
         End While
     End If

    ' -------------------------
'End ListBox STAFF_ID Event BeforeShow. Action Custom Code

'Button Button_Extend Event BeforeShow. Action Declare Variable @316-4243F073
            Dim tmpSemester As String = "0"
'End Button Button_Extend Event BeforeShow. Action Declare Variable

'Button Button_Extend Event BeforeShow. Action Save Control Value @303-8A06A31E
            tmpSemester=viewStudentSummary_SubjecSEMESTER.Value
'End Button Button_Extend Event BeforeShow. Action Save Control Value

'Button Button_Extend Event BeforeShow. Action Declare Variable @317-DB3DAF1C
            Dim tmpExtended As Boolean = 0
'End Button Button_Extend Event BeforeShow. Action Declare Variable

'Button Button_Extend Event BeforeShow. Action Declare Variable @318-766D7E2C
            Dim tmpSubjectID As Int64 = 0
'End Button Button_Extend Event BeforeShow. Action Declare Variable

'Button Button_Extend Event BeforeShow. Action Save Control Value @319-931EBFE0
            tmpSubjectID=viewStudentSummary_Subjechidden_SUBJECT_ID.Value
'End Button Button_Extend Event BeforeShow. Action Save Control Value

'Button Button_Extend Event BeforeShow. Action Declare Variable @320-C17E8C98
            Dim tmpMonth As Int64 = Today.Month()
'End Button Button_Extend Event BeforeShow. Action Declare Variable

'Button Button_Extend Event BeforeShow. Action Custom Code @304-73254650
    ' -------------------------
    ' 16-June-2016|EA| show the 'Extend Subject' button if:
    '  Subject is in Sem 1 & Date is between June and August & Extended = No/0
    tmpExtended = item.EXTENSION_OF_VCE_UNIT.Value
    If (tmpSemester = "1" AND tmpExtended = false AND tmpSubjectID < 900 AND (tmpMonth <=8 AND tmpMonth >= 6)) Then
    	viewStudentSummary_SubjecButton_Extend.Visible = true
    Else
    	viewStudentSummary_SubjecButton_Extend.Visible = false
    End if
    ' -------------------------
'End Button Button_Extend Event BeforeShow. Action Custom Code

'Record Form viewStudentSummary_Subjec Show method tail @4-DE7B1899
        If viewStudentSummary_SubjecErrors.Count > 0 Then
            viewStudentSummary_SubjecShowErrors()
        End If
    End Sub
'End Record Form viewStudentSummary_Subjec Show method tail

'Record Form viewStudentSummary_Subjec LoadItemFromRequest method @4-BBEAE1AE

    Protected Sub viewStudentSummary_SubjecLoadItemFromRequest(item As viewStudentSummary_SubjecItem, ByVal EnableValidation As Boolean)
        item.SEMESTER.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecSEMESTER.UniqueID))
        item.SEMESTER.SetValue(viewStudentSummary_SubjecSEMESTER.Value)
        item.SEMESTERItems.CopyFrom(viewStudentSummary_SubjecSEMESTER.Items)
        item.SUBJ_ENROL_STATUS.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecSUBJ_ENROL_STATUS.UniqueID))
        item.SUBJ_ENROL_STATUS.SetValue(viewStudentSummary_SubjecSUBJ_ENROL_STATUS.Value)
        item.SUBJ_ENROL_STATUSItems.CopyFrom(viewStudentSummary_SubjecSUBJ_ENROL_STATUS.Items)
        Try
        item.enrolment_date.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjecenrolment_date.UniqueID))
        If ControlCustomValues("viewStudentSummary_Subjecenrolment_date") Is Nothing Then
            item.enrolment_date.SetValue(viewStudentSummary_Subjecenrolment_date.Text)
        Else
            item.enrolment_date.SetValue(ControlCustomValues("viewStudentSummary_Subjecenrolment_date"))
        End If
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("enrolment_date",String.Format(Resources.strings.CCS_IncorrectFormat,"ENROLMENT DATE","dd/mm/yy"))
        End Try
        Try
        item.withdrawal_date.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjecwithdrawal_date.UniqueID))
        If ControlCustomValues("viewStudentSummary_Subjecwithdrawal_date") Is Nothing Then
            item.withdrawal_date.SetValue(viewStudentSummary_Subjecwithdrawal_date.Text)
        Else
            item.withdrawal_date.SetValue(ControlCustomValues("viewStudentSummary_Subjecwithdrawal_date"))
        End If
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("withdrawal_date",String.Format(Resources.strings.CCS_IncorrectFormat,"END DATE","dd/mm/yy"))
        End Try
        Try
        item.WITHDRAWAL_REASON_ID.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.UniqueID))
        item.WITHDRAWAL_REASON_ID.SetValue(viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.Value)
        item.WITHDRAWAL_REASON_IDItems.CopyFrom(viewStudentSummary_SubjecWITHDRAWAL_REASON_ID.Items)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("WITHDRAWAL_REASON_ID",String.Format(Resources.strings.CCS_IncorrectValue,"WITHDRAWAL REASON"))
        End Try
        item.STAFF_ID.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecSTAFF_ID.UniqueID))
        item.STAFF_ID.SetValue(viewStudentSummary_SubjecSTAFF_ID.Value)
        item.STAFF_IDItems.CopyFrom(viewStudentSummary_SubjecSTAFF_ID.Items)
        item.FINAL_PROGRESS_CODE.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecFINAL_PROGRESS_CODE.UniqueID))
        item.FINAL_PROGRESS_CODE.SetValue(viewStudentSummary_SubjecFINAL_PROGRESS_CODE.Value)
        item.FINAL_PROGRESS_CODEItems.CopyFrom(viewStudentSummary_SubjecFINAL_PROGRESS_CODE.Items)
        Try
        item.VBOS_REGISTERED.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecVBOS_REGISTERED.UniqueID))
        If Not IsNothing(viewStudentSummary_SubjecVBOS_REGISTERED.SelectedItem) Then
            item.VBOS_REGISTERED.SetValue(viewStudentSummary_SubjecVBOS_REGISTERED.SelectedItem.Value)
        Else
            item.VBOS_REGISTERED.Value = Nothing
        End If
        item.VBOS_REGISTEREDItems.CopyFrom(viewStudentSummary_SubjecVBOS_REGISTERED.Items)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("VBOS_REGISTERED",String.Format(Resources.strings.CCS_IncorrectValue,"VBOS REGISTERED"))
        End Try
        Try
        item.APPEARS_ON_VASS.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecAPPEARS_ON_VASS.UniqueID))
        If Not IsNothing(viewStudentSummary_SubjecAPPEARS_ON_VASS.SelectedItem) Then
            item.APPEARS_ON_VASS.SetValue(viewStudentSummary_SubjecAPPEARS_ON_VASS.SelectedItem.Value)
        Else
            item.APPEARS_ON_VASS.Value = Nothing
        End If
        item.APPEARS_ON_VASSItems.CopyFrom(viewStudentSummary_SubjecAPPEARS_ON_VASS.Items)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("APPEARS_ON_VASS",String.Format(Resources.strings.CCS_IncorrectValue,"APPEARS ON VASS"))
        End Try
        Try
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjechidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(viewStudentSummary_Subjechidden_STUDENT_ID.Value)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("hidden_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_STUDENT_ID"))
        End Try
        Try
        item.hidden_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjechidden_ENROLMENT_YEAR.UniqueID))
        item.hidden_ENROLMENT_YEAR.SetValue(viewStudentSummary_Subjechidden_ENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("hidden_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_ENROLMENT_YEAR"))
        End Try
        Try
        item.hidden_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjechidden_SUBJECT_ID.UniqueID))
        item.hidden_SUBJECT_ID.SetValue(viewStudentSummary_Subjechidden_SUBJECT_ID.Value)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("hidden_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_SUBJECT_ID"))
        End Try
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjechidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(viewStudentSummary_Subjechidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","dd/mm/yyyy"))
        End Try
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Subjechidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(viewStudentSummary_Subjechidden_LAST_ALTERED_BY.Value)
        item.INTERIM_PROGRESS_CODE.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.UniqueID))
        item.INTERIM_PROGRESS_CODE.SetValue(viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.Value)
        item.INTERIM_PROGRESS_CODEItems.CopyFrom(viewStudentSummary_SubjecINTERIM_PROGRESS_CODE.Items)
        Try
        item.EXTENSION_OF_VCE_UNIT.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.UniqueID))
        If Not IsNothing(viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.SelectedItem) Then
            item.EXTENSION_OF_VCE_UNIT.SetValue(viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.SelectedItem.Value)
        Else
            item.EXTENSION_OF_VCE_UNIT.Value = Nothing
        End If
        item.EXTENSION_OF_VCE_UNITItems.CopyFrom(viewStudentSummary_SubjecEXTENSION_OF_VCE_UNIT.Items)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("EXTENSION_OF_VCE_UNIT",String.Format(Resources.strings.CCS_IncorrectValue,"EXTENSION OF VCE UNIT"))
        End Try
        Try
        item.NON_SUBMITTING_FLAG.IsEmpty = IsNothing(Request.Form(viewStudentSummary_SubjecNON_SUBMITTING_FLAG.UniqueID))
        If Not IsNothing(viewStudentSummary_SubjecNON_SUBMITTING_FLAG.SelectedItem) Then
            item.NON_SUBMITTING_FLAG.SetValue(viewStudentSummary_SubjecNON_SUBMITTING_FLAG.SelectedItem.Value)
        Else
            item.NON_SUBMITTING_FLAG.Value = Nothing
        End If
        item.NON_SUBMITTING_FLAGItems.CopyFrom(viewStudentSummary_SubjecNON_SUBMITTING_FLAG.Items)
        Catch ae As ArgumentException
            viewStudentSummary_SubjecErrors.Add("NON_SUBMITTING_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"NON SUBMITTING"))
        End Try
        If EnableValidation Then
            item.Validate(viewStudentSummary_SubjecData)
        End If
        viewStudentSummary_SubjecErrors.Add(item.errors)
    End Sub
'End Record Form viewStudentSummary_Subjec LoadItemFromRequest method

'Record Form viewStudentSummary_Subjec GetRedirectUrl method @4-DBC339BD

    Protected Function GetviewStudentSummary_SubjecRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewStudentSummary_Subjec GetRedirectUrl method

'Record Form viewStudentSummary_Subjec ShowErrors method @4-19A6B8A1

    Protected Sub viewStudentSummary_SubjecShowErrors()
        viewStudentSummary_SubjeclabelErrorStaffID.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewStudentSummary_SubjecErrors.Count - 1
        Select Case viewStudentSummary_SubjecErrors.AllKeys(i)
            Case "STAFF_ID"
                If viewStudentSummary_SubjeclabelErrorStaffID.Text <> "" Then  viewStudentSummary_SubjeclabelErrorStaffID.Text &= "<br>"
                viewStudentSummary_SubjeclabelErrorStaffID.Text = viewStudentSummary_SubjeclabelErrorStaffID.Text & viewStudentSummary_SubjecErrors(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewStudentSummary_SubjecErrors(i)
        End Select
        Next i
        viewStudentSummary_SubjecError.Visible = True
        viewStudentSummary_SubjecErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewStudentSummary_Subjec ShowErrors method

'Record Form viewStudentSummary_Subjec Insert Operation @4-108BF29D

    Protected Sub viewStudentSummary_Subjec_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_SubjecItem = New viewStudentSummary_SubjecItem()
        Dim ExecuteFlag As Boolean = True
        viewStudentSummary_SubjecIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentSummary_Subjec Insert Operation

'Button Button_Extend OnClick. @301-50AD3420
        If CType(sender,Control).ID = "viewStudentSummary_SubjecButton_Extend" Then
            RedirectUrl = GetviewStudentSummary_SubjecRedirectUrl("Student_Subject_maintain.aspx", "SUBJECT_ID")
            EnableValidation  = False
'End Button Button_Extend OnClick.

'Button Button_Extend OnClick tail. @301-477CF3C9
        End If
'End Button Button_Extend OnClick tail.

'Record Form viewStudentSummary_Subjec BeforeInsert tail @4-7E209902
    viewStudentSummary_SubjecParameters()
    viewStudentSummary_SubjecLoadItemFromRequest(item, EnableValidation)
    If viewStudentSummary_SubjecOperations.AllowInsert Then
        ErrorFlag=(viewStudentSummary_SubjecErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                viewStudentSummary_SubjecData.InsertItem(item)
            Catch ex As Exception
                viewStudentSummary_SubjecErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form viewStudentSummary_Subjec BeforeInsert tail

'Record Form viewStudentSummary_Subjec AfterInsert tail  @4-D69F2F6B
        End If
        ErrorFlag=(viewStudentSummary_SubjecErrors.Count > 0)
        If ErrorFlag Then
            viewStudentSummary_SubjecShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentSummary_Subjec AfterInsert tail 

'Record Form viewStudentSummary_Subjec Update Operation @4-F42D0AB6

    Protected Sub viewStudentSummary_Subjec_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_SubjecItem = New viewStudentSummary_SubjecItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        viewStudentSummary_SubjecIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentSummary_Subjec Update Operation

'Button Button_Update OnClick. @5-2284F517
        If CType(sender,Control).ID = "viewStudentSummary_SubjecButton_Update" Then
            RedirectUrl = GetviewStudentSummary_SubjecRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record viewStudentSummary_Subjec Event BeforeUpdate. Action Retrieve Value for Control @103-6F8510A7
        viewStudentSummary_Subjechidden_LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record viewStudentSummary_Subjec Event BeforeUpdate. Action Retrieve Value for Control

'Record viewStudentSummary_Subjec Event BeforeUpdate. Action Retrieve Value for Control @104-E9CA92AE
        viewStudentSummary_Subjechidden_LAST_ALTERED_DATE.Value = (New DateField(Settings.DateFormat, (now()))).GetFormattedValue()
'End Record viewStudentSummary_Subjec Event BeforeUpdate. Action Retrieve Value for Control

'Record Form viewStudentSummary_Subjec Before Update tail @4-249C023C
        viewStudentSummary_SubjecParameters()
        viewStudentSummary_SubjecLoadItemFromRequest(item, EnableValidation)
        If viewStudentSummary_SubjecOperations.AllowUpdate Then
        ErrorFlag = (viewStudentSummary_SubjecErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                viewStudentSummary_SubjecData.UpdateItem(item)
            Catch ex As Exception
                viewStudentSummary_SubjecErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form viewStudentSummary_Subjec Before Update tail

'Record viewStudentSummary_Subjec Event AfterUpdate. Action Custom Code @185-73254650
    ' -------------------------
        ' LN: 5/5/2014
        If item.lblSTAFF_ID.Value <> Nothing Then
            ' LN: 24/10/2013
            If item.STAFF_ID.Value.IndexOf("NSUBMIT") >= 0 And item.lblSTAFF_ID.Value <> item.STAFF_ID.Value Then
                Dim studentID As String = item.hidden_STUDENT_ID.GetFormattedValue("")
                Dim studentSupportTeacher As String = ""
                ' Get the Student Support Teacher to e-mail the notification to.

                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                If NewDao.NativeConnection.State <> ConnectionState.Open Then
                    NewDao.NativeConnection.Open()
                End If
                Dim cmd As New SqlClient.SqlCommand
                cmd = NewDao.NativeConnection.CreateCommand
                Dim strSQL As String = "SELECT PASTORAL_CARE_ID FROM STUDENT_ENROLMENT WHERE ENROLMENT_YEAR = year(getdate()) AND STUDENT_ID = " & studentID
                cmd.CommandText = strSQL
                studentSupportTeacher = cmd.ExecuteScalar()

                Dim MessageFrom As String = "reports@vsv.vic.edu.au"
                'Dim MessageTo As String = "pcsupport@distance.vic.edu.au"
                'Dim MessageTo As String = "lnigro@distance.vic.edu.au"
                Dim MessageTo As String = studentSupportTeacher.ToLower() & "@vsv.vic.edu.au"

                Dim MessageSubject As String = "Student changed to NSUBMIT"
                Dim MessageBody As String = "Your SST Student has been changed to NSUBMIT in a subject. " & _
                 "Click the link below to go to their Summary " & _
                 "http://decv-db/STUDENT_ADMIN/StudentSummary.aspx?enrolment_year=" & Year(Now) & "&student_id=" & studentID & " " & _
                 "<br><br>---- that is all ----" '& studentSupportTeacher.ToLower()

                Dim TestEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
                TestEmail.IsBodyHtml = True
                ' 19-Nov-2015|EA| used web.config server not hard coded
                'Dim EmailServer As New System.Net.Mail.SmtpClient("DECV-CAS")
                Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))

                EmailServer.Send(TestEmail)
            End If
        End If
      ' -------------------------
'End Record viewStudentSummary_Subjec Event AfterUpdate. Action Custom Code

'Record Form viewStudentSummary_Subjec Update Operation tail @4-D69F2F6B
        End If
        ErrorFlag=(viewStudentSummary_SubjecErrors.Count > 0)
        If ErrorFlag Then
            viewStudentSummary_SubjecShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentSummary_Subjec Update Operation tail

'Record Form viewStudentSummary_Subjec Delete Operation @4-916027D7
    Protected Sub viewStudentSummary_Subjec_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewStudentSummary_SubjecIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewStudentSummary_SubjecItem = New viewStudentSummary_SubjecItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewStudentSummary_Subjec Delete Operation

'Record Form BeforeDelete tail @4-9E594FFF
        viewStudentSummary_SubjecParameters()
        viewStudentSummary_SubjecLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-F35A4ECC
        If ErrorFlag Then
            viewStudentSummary_SubjecShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewStudentSummary_Subjec Cancel Operation @4-CF75E77D

    Protected Sub viewStudentSummary_Subjec_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_SubjecItem = New viewStudentSummary_SubjecItem()
        viewStudentSummary_SubjecIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewStudentSummary_SubjecLoadItemFromRequest(item, False)
'End Record Form viewStudentSummary_Subjec Cancel Operation

'Button Button_Cancel OnClick. @6-BD93E9BA
    If CType(sender,Control).ID = "viewStudentSummary_SubjecButton_Cancel" Then
        RedirectUrl = GetviewStudentSummary_SubjecRedirectUrl("Student_Subject_maintain.aspx", "SUBJECT_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @6-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form viewStudentSummary_Subjec Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewStudentSummary_Subjec Cancel Operation tail

'Grid BOOK_DESPATCH Bind @61-27038E70

    Protected Sub BOOK_DESPATCHBind()
        If Not BOOK_DESPATCHOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"BOOK_DESPATCH",GetType(BOOK_DESPATCHDataProvider.SortFields), 80, 100)
        End If
'End Grid BOOK_DESPATCH Bind

'Grid Form BOOK_DESPATCH BeforeShow tail @61-3A173279
        BOOK_DESPATCHParameters()
        BOOK_DESPATCHData.SortField = CType(ViewState("BOOK_DESPATCHSortField"),BOOK_DESPATCHDataProvider.SortFields)
        BOOK_DESPATCHData.SortDir = CType(ViewState("BOOK_DESPATCHSortDir"),SortDirections)
        BOOK_DESPATCHData.PageNumber = CInt(ViewState("BOOK_DESPATCHPageNumber"))
        BOOK_DESPATCHData.RecordsPerPage = CInt(ViewState("BOOK_DESPATCHPageSize"))
        BOOK_DESPATCHRepeater.DataSource = BOOK_DESPATCHData.GetResultSet(PagesCount, BOOK_DESPATCHOperations)
        ViewState("BOOK_DESPATCHPagesCount") = PagesCount
        Dim item As BOOK_DESPATCHItem = New BOOK_DESPATCHItem()
        BOOK_DESPATCHRepeater.DataBind
        FooterIndex = BOOK_DESPATCHRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            BOOK_DESPATCHRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form BOOK_DESPATCH BeforeShow tail

'Grid BOOK_DESPATCH Bind tail @61-E31F8E2A
    End Sub
'End Grid BOOK_DESPATCH Bind tail

'Grid BOOK_DESPATCH Table Parameters @61-1D437600

    Protected Sub BOOK_DESPATCHParameters()
        Try
            BOOK_DESPATCHData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            BOOK_DESPATCHData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            BOOK_DESPATCHData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=BOOK_DESPATCHRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(BOOK_DESPATCHRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid BOOK_DESPATCH: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid BOOK_DESPATCH Table Parameters

'Grid BOOK_DESPATCH ItemDataBound event @61-0444C7E4

    Protected Sub BOOK_DESPATCHItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as BOOK_DESPATCHItem = CType(e.Item.DataItem,BOOK_DESPATCHItem)
        Dim Item as BOOK_DESPATCHItem = DataItem
        Dim FormDataSource As BOOK_DESPATCHItem() = CType(BOOK_DESPATCHRepeater.DataSource, BOOK_DESPATCHItem())
        Dim BOOK_DESPATCHDataRows As Integer = FormDataSource.Length
        Dim BOOK_DESPATCHIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            BOOK_DESPATCHCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(BOOK_DESPATCHRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, BOOK_DESPATCHCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim BOOK_DESPATCHBOOK_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("BOOK_DESPATCHBOOK_ID"),System.Web.UI.WebControls.Literal)
            Dim BOOK_DESPATCHDESPATCH_STATUS As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("BOOK_DESPATCHDESPATCH_STATUS"),System.Web.UI.WebControls.RadioButtonList)
            Dim BOOK_DESPATCHDESPATCH_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("BOOK_DESPATCHDESPATCH_DATE"),System.Web.UI.WebControls.TextBox)
            Dim BOOK_DESPATCHlblModule As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("BOOK_DESPATCHlblModule"),System.Web.UI.WebControls.Literal)
            DataItem.DESPATCH_STATUSItems.SetSelection(DataItem.DESPATCH_STATUS.GetFormattedValue())
            BOOK_DESPATCHDESPATCH_STATUS.SelectedIndex = -1
            DataItem.DESPATCH_STATUSItems.CopyTo(BOOK_DESPATCHDESPATCH_STATUS.Items, True)
        End If
'End Grid BOOK_DESPATCH ItemDataBound event

'Grid BOOK_DESPATCH BeforeShowRow event @61-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid BOOK_DESPATCH BeforeShowRow event

'Grid BOOK_DESPATCH Event BeforeShowRow. Action Set Row Style @62-CB174137
            Dim styles62 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex62 As Integer = (BOOK_DESPATCHCurrentRowNumber - 1) Mod styles62.Length
            Dim rawStyle62 As String = styles62(styleIndex62).Replace("\;",";")
            If rawStyle62.IndexOf("=") = -1 And rawStyle62.IndexOf(":") > -1 Then
                rawStyle62 = "style=""" + rawStyle62 + """"
            ElseIf rawStyle62.IndexOf("=") = -1 And rawStyle62.IndexOf(":") = -1 And rawStyle62 <> "" Then
                rawStyle62 = "class=""" + rawStyle62 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(BOOK_DESPATCHRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle62), AttributeOption.Multiple)
'End Grid BOOK_DESPATCH Event BeforeShowRow. Action Set Row Style

'Grid BOOK_DESPATCH BeforeShowRow event tail @61-477CF3C9
        End If
'End Grid BOOK_DESPATCH BeforeShowRow event tail

'Grid BOOK_DESPATCH ItemDataBound event tail @61-98193809
        If BOOK_DESPATCHIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(BOOK_DESPATCHCurrentRowNumber, ListItemType.Item)
            BOOK_DESPATCHRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            BOOK_DESPATCHItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid BOOK_DESPATCH ItemDataBound event tail

'Grid BOOK_DESPATCH ItemCommand event @61-9E95AAA3

    Protected Sub BOOK_DESPATCHItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= BOOK_DESPATCHRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("BOOK_DESPATCHSortDir"),SortDirections) = SortDirections._Asc And ViewState("BOOK_DESPATCHSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("BOOK_DESPATCHSortDir")=SortDirections._Desc
                Else
                    ViewState("BOOK_DESPATCHSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("BOOK_DESPATCHSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As BOOK_DESPATCHDataProvider.SortFields = 0
            ViewState("BOOK_DESPATCHSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("BOOK_DESPATCHPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("BOOK_DESPATCHPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("BOOK_DESPATCHPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("BOOK_DESPATCHPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            BOOK_DESPATCHBind
        End If
    End Sub
'End Grid BOOK_DESPATCH ItemCommand event

'Record Form STUDENT_SUBJECT Parameters @128-A18C1DD1

    Protected Sub STUDENT_SUBJECTParameters()
        Dim item As new STUDENT_SUBJECTItem
        Try
            STUDENT_SUBJECTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_SUBJECTData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_SUBJECTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_SUBJECTData.CtrlENROLMENT_YEAR = FloatParameter.GetParam(item.ENROLMENT_YEAR.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_SUBJECTData.CtrlSUBJECT_ID = IntegerParameter.GetParam(item.SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_SUBJECTData.Expr146 = TextParameter.GetParam(dbutility.userid.tostring, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_SUBJECTData.Expr147 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            STUDENT_SUBJECTData.CtrlMODULE_CUSTOMPROGRAM = IntegerParameter.GetParam(item.MODULE_CUSTOMPROGRAM.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_SUBJECTData.CtrlMODULE_NEXTMODULE = TextParameter.GetParam(item.MODULE_NEXTMODULE.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            STUDENT_SUBJECTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_SUBJECT Parameters

'Record Form STUDENT_SUBJECT Show method @128-E91A922A
    Protected Sub STUDENT_SUBJECTShow()
        If STUDENT_SUBJECTOperations.None Then
            STUDENT_SUBJECTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_SUBJECTItem = STUDENT_SUBJECTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_SUBJECTOperations.AllowRead
        STUDENT_SUBJECTErrors.Add(item.errors)
        If STUDENT_SUBJECTErrors.Count > 0 Then
            STUDENT_SUBJECTShowErrors()
            Return
        End If
'End Record Form STUDENT_SUBJECT Show method

'Record Form STUDENT_SUBJECT BeforeShow tail @128-CA062F65
        STUDENT_SUBJECTParameters()
        STUDENT_SUBJECTData.FillItem(item, IsInsertMode)
        STUDENT_SUBJECTHolder.DataBind()
        STUDENT_SUBJECTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_SUBJECTOperations.AllowUpdate
        STUDENT_SUBJECTENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        STUDENT_SUBJECTSUBJECT_ID.Value = item.SUBJECT_ID.GetFormattedValue()
        STUDENT_SUBJECTSEMESTER.Value = item.SEMESTER.GetFormattedValue()
        STUDENT_SUBJECTMODULE_LAST_ALTERED_BY.Value = item.MODULE_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE.Value = item.MODULE_LAST_ALTERED_DATE.GetFormattedValue()
        item.MODULE_CUSTOMPROGRAMItems.SetSelection(item.MODULE_CUSTOMPROGRAM.GetFormattedValue())
        STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.SelectedIndex = -1
        item.MODULE_CUSTOMPROGRAMItems.CopyTo(STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.Items)
        STUDENT_SUBJECTMODULE_NEXTMODULE.Items.Add(new ListItem("Select Value",""))
        STUDENT_SUBJECTMODULE_NEXTMODULE.Items(0).Selected = True
        item.MODULE_NEXTMODULEItems.SetSelection(item.MODULE_NEXTMODULE.GetFormattedValue())
        If Not item.MODULE_NEXTMODULEItems.GetSelectedItem() Is Nothing Then
            STUDENT_SUBJECTMODULE_NEXTMODULE.SelectedIndex = -1
        End If
        item.MODULE_NEXTMODULEItems.CopyTo(STUDENT_SUBJECTMODULE_NEXTMODULE.Items)
        STUDENT_SUBJECTMODULE_LAST_ALTERED_BY1.Text = Server.HtmlEncode(item.MODULE_LAST_ALTERED_BY1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE1.Text = Server.HtmlEncode(item.MODULE_LAST_ALTERED_DATE1.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STUDENT_SUBJECT BeforeShow tail

'RadioButton MODULE_CUSTOMPROGRAM Event BeforeShow. Action Custom Code @153-73254650
    ' -------------------------
    'Change modules No/Yes to horizontal
	STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.RepeatDirection = RepeatDirection.Horizontal
    ' -------------------------
'End RadioButton MODULE_CUSTOMPROGRAM Event BeforeShow. Action Custom Code

'Record Form STUDENT_SUBJECT Show method tail @128-326CF018
        If STUDENT_SUBJECTErrors.Count > 0 Then
            STUDENT_SUBJECTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_SUBJECT Show method tail

'Record Form STUDENT_SUBJECT LoadItemFromRequest method @128-45371203

    Protected Sub STUDENT_SUBJECTLoadItemFromRequest(item As STUDENT_SUBJECTItem, ByVal EnableValidation As Boolean)
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(STUDENT_SUBJECTENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            STUDENT_SUBJECTErrors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        Try
        item.SUBJECT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTSUBJECT_ID.UniqueID))
        item.SUBJECT_ID.SetValue(STUDENT_SUBJECTSUBJECT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_SUBJECTErrors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
        End Try
        item.SEMESTER.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTSEMESTER.UniqueID))
        item.SEMESTER.SetValue(STUDENT_SUBJECTSEMESTER.Value)
        item.MODULE_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTMODULE_LAST_ALTERED_BY.UniqueID))
        item.MODULE_LAST_ALTERED_BY.SetValue(STUDENT_SUBJECTMODULE_LAST_ALTERED_BY.Value)
        Try
        item.MODULE_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE.UniqueID))
        item.MODULE_LAST_ALTERED_DATE.SetValue(STUDENT_SUBJECTMODULE_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_SUBJECTErrors.Add("MODULE_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"MODULE LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        Try
        item.MODULE_CUSTOMPROGRAM.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.UniqueID))
        If Not IsNothing(STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.SelectedItem) Then
            item.MODULE_CUSTOMPROGRAM.SetValue(STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.SelectedItem.Value)
        Else
            item.MODULE_CUSTOMPROGRAM.Value = Nothing
        End If
        item.MODULE_CUSTOMPROGRAMItems.CopyFrom(STUDENT_SUBJECTMODULE_CUSTOMPROGRAM.Items)
        Catch ae As ArgumentException
            STUDENT_SUBJECTErrors.Add("MODULE_CUSTOMPROGRAM",String.Format(Resources.strings.CCS_IncorrectValue,"Customised Learning Program"))
        End Try
        item.MODULE_NEXTMODULE.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECTMODULE_NEXTMODULE.UniqueID))
        item.MODULE_NEXTMODULE.SetValue(STUDENT_SUBJECTMODULE_NEXTMODULE.Value)
        item.MODULE_NEXTMODULEItems.CopyFrom(STUDENT_SUBJECTMODULE_NEXTMODULE.Items)
        If EnableValidation Then
            item.Validate(STUDENT_SUBJECTData)
        End If
        STUDENT_SUBJECTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_SUBJECT LoadItemFromRequest method

'Record Form STUDENT_SUBJECT GetRedirectUrl method @128-62EDDD7F

    Protected Function GetSTUDENT_SUBJECTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_SUBJECT GetRedirectUrl method

'Record Form STUDENT_SUBJECT ShowErrors method @128-1A6A1FB6

    Protected Sub STUDENT_SUBJECTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_SUBJECTErrors.Count - 1
        Select Case STUDENT_SUBJECTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_SUBJECTErrors(i)
        End Select
        Next i
        STUDENT_SUBJECTError.Visible = True
        STUDENT_SUBJECTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_SUBJECT ShowErrors method

'Record Form STUDENT_SUBJECT Insert Operation @128-F7FE71AB

    Protected Sub STUDENT_SUBJECT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECTItem = New STUDENT_SUBJECTItem()
        STUDENT_SUBJECTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_SUBJECT Insert Operation

'Record Form STUDENT_SUBJECT BeforeInsert tail @128-649FDB16
    STUDENT_SUBJECTParameters()
    STUDENT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_SUBJECT BeforeInsert tail

'Record Form STUDENT_SUBJECT AfterInsert tail  @128-A42764AF
        ErrorFlag=(STUDENT_SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_SUBJECT AfterInsert tail 

'Record Form STUDENT_SUBJECT Update Operation @128-F287D879

    Protected Sub STUDENT_SUBJECT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECTItem = New STUDENT_SUBJECTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_SUBJECT Update Operation

'Button Button_Update OnClick. @129-C0DAB326
        If CType(sender,Control).ID = "STUDENT_SUBJECTButton_Update" Then
            RedirectUrl = GetSTUDENT_SUBJECTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @129-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT_SUBJECT Before Update tail @128-9888F003
        STUDENT_SUBJECTParameters()
        STUDENT_SUBJECTLoadItemFromRequest(item, EnableValidation)
        If STUDENT_SUBJECTOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_SUBJECTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_SUBJECTData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_SUBJECTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_SUBJECT Before Update tail

'Record Form STUDENT_SUBJECT Update Operation tail @128-58DCE67C
        End If
        ErrorFlag=(STUDENT_SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_SUBJECT Update Operation tail

'Record Form STUDENT_SUBJECT Delete Operation @128-05A43291
    Protected Sub STUDENT_SUBJECT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_SUBJECTItem = New STUDENT_SUBJECTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_SUBJECT Delete Operation

'Record Form BeforeDelete tail @128-649FDB16
        STUDENT_SUBJECTParameters()
        STUDENT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @128-38622A61
        If ErrorFlag Then
            STUDENT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_SUBJECT Cancel Operation @128-EB95D7BF

    Protected Sub STUDENT_SUBJECT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECTItem = New STUDENT_SUBJECTItem()
        STUDENT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_SUBJECTLoadItemFromRequest(item, False)
'End Record Form STUDENT_SUBJECT Cancel Operation

'Button Button_Cancel OnClick. @130-3FBCEE25
    If CType(sender,Control).ID = "STUDENT_SUBJECTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_SUBJECTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @130-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_SUBJECT Cancel Operation tail @128-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_SUBJECT Cancel Operation tail

'EditableGrid EditableGrid1 Bind @231-5A3B21A6
    Protected Sub EditableGrid1Bind()
        If EditableGrid1Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"EditableGrid1",GetType(EditableGrid1DataProvider.SortFields), 30, 100)
        End If
'End EditableGrid EditableGrid1 Bind

'EditableGrid Form EditableGrid1 BeforeShow tail @231-1454486C
        EditableGrid1Parameters()
        EditableGrid1Data.SortField = CType(ViewState("EditableGrid1SortField"), EditableGrid1DataProvider.SortFields)
        EditableGrid1Data.SortDir = CType(ViewState("EditableGrid1SortDir"), SortDirections)
        EditableGrid1Data.PageNumber = CType(ViewState("EditableGrid1PageNumber"), Integer)
        EditableGrid1Data.RecordsPerPage = CType(ViewState("EditableGrid1PageSize"), Integer)
        EditableGrid1Repeater.DataSource = EditableGrid1Data.GetResultSet(PagesCount, EditableGrid1Operations)
        ViewState("EditableGrid1PagesCount") = PagesCount
        ViewState("EditableGrid1FormState") = New Hashtable()
        ViewState("EditableGrid1RowState") = New Hashtable()
        EditableGrid1Repeater.DataBind()
        Dim item As EditableGrid1Item = EditableGrid1DataItem
        If IsNothing(item) Then item = New EditableGrid1Item()
        FooterIndex = EditableGrid1Repeater.Controls.Count - 1
        Dim EditableGrid1Button_Submit As System.Web.UI.WebControls.Button = DirectCast(EditableGrid1Repeater.Controls(FooterIndex).FindControl("EditableGrid1Button_Submit"),System.Web.UI.WebControls.Button)


        EditableGrid1Button_Submit.Visible = EditableGrid1Operations.Editable
        If Not CType(EditableGrid1Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            EditableGrid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If EditableGrid1Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(EditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(EditableGrid1Repeater.Controls(0).FindControl("EditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In EditableGrid1Errors
                ErrorLabel.Text += EditableGrid1Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form EditableGrid1 BeforeShow tail

'EditableGrid EditableGrid1 Bind tail @231-F48D4C57
        EditableGrid1ShowErrors(New ArrayList(CType(EditableGrid1Repeater.DataSource, ICollection)), EditableGrid1Repeater.Items)
    End Sub
'End EditableGrid EditableGrid1 Bind tail

'EditableGrid EditableGrid1 Table Parameters @231-1BDFA7D6
    Protected Sub EditableGrid1Parameters()
        Try
        Dim item As new EditableGrid1Item
            EditableGrid1Data.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            EditableGrid1Data.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", 2014, false)
            EditableGrid1Data.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", 0, false)
            EditableGrid1Data.CtrlBOOK_ID = IntegerParameter.GetParam(item.BOOK_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            EditableGrid1Data.CtrlDESPATCH_STATUS = TextParameter.GetParam(item.DESPATCH_STATUS.Value, ParameterSourceType.Control, "", Nothing, false)
            EditableGrid1Data.CtrlDESPATCH_DATE = DateParameter.GetParam(item.DESPATCH_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = EditableGrid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(EditableGrid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid EditableGrid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid EditableGrid1 Table Parameters

'EditableGrid EditableGrid1 ItemDataBound event @231-1F68BFCF
    Protected Sub EditableGrid1ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As EditableGrid1Item = DirectCast(e.Item.DataItem, EditableGrid1Item)
        Dim Item as EditableGrid1Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            EditableGrid1CurrentRowNumber = EditableGrid1CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("EditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditableGrid1RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("EditableGrid1lblBookID").UniqueID) = DataItem.lblBookID.Value
            ViewState(e.Item.FindControl("EditableGrid1module_display").UniqueID) = DataItem.module_display.Value
            Dim EditableGrid1BOOK_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("EditableGrid1BOOK_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim EditableGrid1DESPATCH_STATUS As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("EditableGrid1DESPATCH_STATUS"),System.Web.UI.WebControls.RadioButtonList)
            Dim EditableGrid1DESPATCH_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("EditableGrid1DESPATCH_DATE"),System.Web.UI.WebControls.TextBox)
            Dim EditableGrid1lblBookID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1lblBookID"),System.Web.UI.WebControls.Literal)
            Dim EditableGrid1module_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1module_display"),System.Web.UI.WebControls.Literal)
            CType(Page,CCPage).ControlAttributes.Add(EditableGrid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, EditableGrid1CurrentRowNumber), AttributeOption.Multiple)
            DataItem.DESPATCH_STATUSItems.SetSelection(DataItem.DESPATCH_STATUS.GetFormattedValue())
            EditableGrid1DESPATCH_STATUS.SelectedIndex = -1
            DataItem.DESPATCH_STATUSItems.CopyTo(EditableGrid1DESPATCH_STATUS.Items, True)
        End If
'End EditableGrid EditableGrid1 ItemDataBound event

'EditableGrid EditableGrid1 BeforeShowRow event @231-5B819080
        If Not IsNothing(Item) Then EditableGrid1DataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid EditableGrid1 BeforeShowRow event

'EditableGrid EditableGrid1 BeforeShowRow event tail @231-477CF3C9
        End If
'End EditableGrid EditableGrid1 BeforeShowRow event tail

'EditableGrid EditableGrid1 ItemDataBound event tail @231-E31F8E2A
    End Sub
'End EditableGrid EditableGrid1 ItemDataBound event tail

'EditableGrid EditableGrid1 GetRedirectUrl method @231-9FE0ED8C
    Protected Function GetEditableGrid1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetEditableGrid1RedirectUrl(ByVal redirectString As String) As String
        Return GetEditableGrid1RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid EditableGrid1 GetRedirectUrl method

'EditableGrid EditableGrid1 ShowErrors method @231-37DAE1CF
    Protected Function EditableGrid1ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), EditableGrid1Item).IsUpdated Then col(CType(items(i), EditableGrid1Item).RowId).Visible = False
            If (CType(items(i), EditableGrid1Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), EditableGrid1Item).errors.Count - 1
                Select CType(items(i), EditableGrid1Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), EditableGrid1Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), EditableGrid1Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), EditableGrid1Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid EditableGrid1 ShowErrors method

'EditableGrid EditableGrid1 ItemCommand event @231-659AF02B
    Protected Sub EditableGrid1ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = EditableGrid1Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid EditableGrid1 ItemCommand event

'Button Button_Submit OnClick. @241-C339CCA2
        If Ctype(e.CommandSource,Control).ID = "EditableGrid1Button_Submit" Then
            RedirectUrl  = GetEditableGrid1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @241-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'EditableGrid Form EditableGrid1 ItemCommand event tail @231-FE727B63
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("EditableGrid1SortDir"), SortDirections) = SortDirections._Asc And ViewState("EditableGrid1SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("EditableGrid1SortDir") = SortDirections._Desc
                Else
                    ViewState("EditableGrid1SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("EditableGrid1SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As EditableGrid1DataProvider.SortFields = 0
            ViewState("EditableGrid1SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("EditableGrid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("EditableGrid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("EditableGrid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("EditableGrid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            EditableGrid1IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = EditableGrid1Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("EditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditableGrid1RowState"), Hashtable)
            EditableGrid1Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim EditableGrid1BOOK_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("EditableGrid1BOOK_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim EditableGrid1DESPATCH_STATUS As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("EditableGrid1DESPATCH_STATUS"),System.Web.UI.WebControls.RadioButtonList)
                    Dim EditableGrid1DESPATCH_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("EditableGrid1DESPATCH_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim EditableGrid1lblBookID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1lblBookID"),System.Web.UI.WebControls.Literal)
                    Dim EditableGrid1module_display As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1module_display"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As EditableGrid1Item = New EditableGrid1Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.lblBookID.Value = ViewState(EditableGrid1lblBookID.UniqueID)
                    item.module_display.Value = ViewState(EditableGrid1module_display.UniqueID)
                    Try
                    item.BOOK_ID.IsEmpty = IsNothing(Request.Form(EditableGrid1BOOK_ID.UniqueID))
                    item.BOOK_ID.SetValue(EditableGrid1BOOK_ID.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("BOOK_ID",String.Format(Resources.strings.CCS_IncorrectValue,"BOOK ID"))
                    End Try
                    item.DESPATCH_STATUS.IsEmpty = IsNothing(Request.Form(EditableGrid1DESPATCH_STATUS.UniqueID))
                    If Not IsNothing(EditableGrid1DESPATCH_STATUS.SelectedItem) Then
                        item.DESPATCH_STATUS.SetValue(EditableGrid1DESPATCH_STATUS.SelectedItem.Value)
                    Else
                        item.DESPATCH_STATUS.Value = Nothing
                    End If
                    item.DESPATCH_STATUSItems.CopyFrom(EditableGrid1DESPATCH_STATUS.Items)
                    Try
                    item.DESPATCH_DATE.IsEmpty = IsNothing(Request.Form(EditableGrid1DESPATCH_DATE.UniqueID))
                    If ControlCustomValues("EditableGrid1DESPATCH_DATE") Is Nothing Then
                        item.DESPATCH_DATE.SetValue(EditableGrid1DESPATCH_DATE.Text)
                    Else
                        item.DESPATCH_DATE.SetValue(ControlCustomValues("EditableGrid1DESPATCH_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("DESPATCH_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"DESPATCH DATE","dd/mm/yy"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(EditableGrid1Data) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form EditableGrid1 ItemCommand event tail

'EditableGrid EditableGrid1 Update @231-E41E6A29
            If BindAllowed Then
                Try
                    EditableGrid1Parameters()
                    EditableGrid1Data.Update(items, EditableGrid1Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(EditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(EditableGrid1Repeater.Controls(0).FindControl("EditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid EditableGrid1 Update

'EditableGrid EditableGrid1 After Update @231-8005DFA8
                End Try
                If EditableGrid1ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                EditableGrid1ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                EditableGrid1Bind()
            End If
        End Sub
'End EditableGrid EditableGrid1 After Update

 '+++++++++++++++++++++++++++++++++++++++++
 ' REALLY REALLY Old code lifted from original system and never updated. Whole Runs Taken should be in an Edittable Grid with a Custom SQL update.
        Protected Sub BOOK_DESPATCH_button_UpdateRuns_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BOOK_DESPATCHButton_UpdateRuns.Click
            ' ERA: loop through the grid of Books and update the Despatch record
            Dim repItem As RepeaterItem
            Dim intBookId As Integer
            Dim radStatus As String
            Dim txtDateDespatched As String
            Dim dateDespatched As DateTime
            Dim txtstudentid As String
            Dim txtenrolyear As String
            Dim txtsubjectid As String

            'actually send the requested changes to the SQL string
            Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
            'April-2013|EA| finally convert to SQL connection following move to DECV-DB
            'Dim trans As OleDb.OleDbTransaction
            'Dim cmd As OleDb.OleDbCommand
            Dim trans As SqlClient.SqlTransaction
            Dim cmd As SqlClient.SqlCommand

            Try
                ' a little more formal than the Sybase 'begin trans' statement
                If NewDao.NativeConnection.State <> ConnectionState.Open Then
                    NewDao.NativeConnection.Open()
                    'NewDao.DateFormat = "mdy"
                End If

                trans = NewDao.NativeConnection.BeginTransaction()
                cmd = NewDao.NativeConnection.CreateCommand

                cmd.CommandType = CommandType.Text
                cmd.Transaction = trans

                Dim strSQL As String = ""
                Me.lblSelections.text = ""
                Dim tmpUsername As String
                If (Session("UserID").ToString = "") Then
                    tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                Else
                    tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                End If

                txtstudentid = Me.viewStudentSummary_Subjechidden_STUDENT_ID.Value
                txtenrolyear = Me.viewStudentSummary_Subjechidden_ENROLMENT_YEAR.Value
                txtsubjectid = Me.viewStudentSummary_Subjechidden_SUBJECT_ID.Value

                For Each repItem In BOOK_DESPATCHRepeater.Items
                    intBookId = CType(repItem.FindControl("BOOK_DESPATCHBOOK_ID"), Literal).Text
                    radStatus = CType(repItem.FindControl("BOOK_DESPATCHDESPATCH_STATUS"), RadioButtonList).SelectedItem.Value
                    txtDateDespatched = CType(repItem.FindControl("BOOK_DESPATCHDESPATCH_DATE"), TextBox).Text

                    If intBookId <> 0 Then
                        strSQL = "update BOOK_DESPATCH "
                        strSQL += " set DESPATCH_STATUS=" & NewDao.ToSql(radStatus, FieldType._Text, True) & " "
                        If (txtDateDespatched = "") Then
                            strSQL += ", DESPATCH_DATE= NULL"
                        Else
                            dateDespatched = DateTime.ParseExact(txtDateDespatched.ToString, "dd/MM/yy", Nothing)
                            'strSQL += ", DESPATCH_DATE=" & NewDao.ToSql(txtDateDespatched, FieldType._Date) & " "
                            strSQL += ", DESPATCH_DATE=" & NewDao.ToSql(dateDespatched.ToString("yyyy-MM-dd"), FieldType._Date) & " "
                        End If
                        strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
                        strSQL += " , LAST_ALTERED_DATE=getdate() "
                        strSQL += "where SUBJECT_ID= " & NewDao.ToSql(txtsubjectid, FieldType._Integer) & " "
                        strSQL += " and STUDENT_ID= " & NewDao.ToSql(txtstudentid, FieldType._Integer) & " "
                        strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(txtenrolyear, FieldType._Integer) & " "
                        strSQL += " and BOOK_ID= " & NewDao.ToSql(intBookId, FieldType._Integer) & " "
                        cmd.CommandText = strSQL
                        cmd.ExecuteNonQuery()

                        'BOOK_DESPATCHlblSelections.Text += "<hr>" & strSQL
                    End If
                Next

                trans.Commit()
                'Me.lblSelections.Text += "<br><font color=green>Subject Book Despatch ID Update performed successfully</font>"
                response.redirect(GetviewStudentSummary_SubjecRedirectUrl("", ""))

            Catch ex As Exception
                trans.Rollback()
                Me.lblSelections.Text += "<br><font color=red>Subject Book Despatch ID Update <b>FAILED</b> for Subject ID " & txtsubjectid.tostring() & " - Book ID " & intBookId.tostring() & " - Check that the Date is dd/mm/yy format </font>"
                Me.lblSelections.Visible = True
            Finally
                If NewDao.NativeConnection.State = ConnectionState.Open Then
                    NewDao.NativeConnection.Close()
                End If
            End Try

        End Sub
 '+++++++++++++++++++++++++++++++++++++++++       

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-03E25551
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentSubject_Details_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewStudentSummary_SubjecData = New viewStudentSummary_SubjecDataProvider()
        viewStudentSummary_SubjecOperations = New FormSupportedOperations(False, True, True, True, False)
        BOOK_DESPATCHData = New BOOK_DESPATCHDataProvider()
        BOOK_DESPATCHOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_SUBJECTData = New STUDENT_SUBJECTDataProvider()
        STUDENT_SUBJECTOperations = New FormSupportedOperations(False, True, False, True, False)
        EditableGrid1Data = New EditableGrid1DataProvider()
        EditableGrid1Operations = New FormSupportedOperations(False, True, False, True, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
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

