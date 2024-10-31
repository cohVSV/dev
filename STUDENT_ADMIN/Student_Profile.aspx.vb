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

Namespace DECV_PROD2007.Student_Profile 'Namespace @1-599E85AA

'Forms Definition @1-D3DC3825
Public Class [Student_ProfilePage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-175E2ECB
    Protected STUDENT_PROFILE1Data As STUDENT_PROFILE1DataProvider
    Protected STUDENT_PROFILE1Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_PROFILE1Operations As FormSupportedOperations
    Protected STUDENT_PROFILE1IsSubmitted As Boolean = False
    Protected Student_ProfileContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-BF79242D
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            STUDENT_PROFILE1Show()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_Profile Event BeforeShow. Action Custom Code @123-73254650
    ' -------------------------
    '29-Jan-2017|EA|ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    'convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
	dim arrHigherGroups as String() = strHigherGroups.split(",")
	If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
	    Panel_MenuStudentMaintain.visible = true
	End If
    ' -------------------------
'End Page Student_Profile Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_PROFILE1 Parameters @3-75A9012D

    Protected Sub STUDENT_PROFILE1Parameters()
        Dim item As new STUDENT_PROFILE1Item
        Try
            STUDENT_PROFILE1Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_PROFILE1Data.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_PROFILE1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_PROFILE1 Parameters

'Record Form STUDENT_PROFILE1 Show method @3-978D65A2
    Protected Sub STUDENT_PROFILE1Show()
        If STUDENT_PROFILE1Operations.None Then
            STUDENT_PROFILE1Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_PROFILE1Item = STUDENT_PROFILE1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_PROFILE1Operations.AllowRead
        item.Link1Href = "Student_EACL.aspx"
        item.Link2Href = "Student_Medical_maintain.aspx"
        STUDENT_PROFILE1Errors.Add(item.errors)
        If STUDENT_PROFILE1Errors.Count > 0 Then
            STUDENT_PROFILE1ShowErrors()
            Return
        End If
'End Record Form STUDENT_PROFILE1 Show method

'Record Form STUDENT_PROFILE1 BeforeShow tail @3-1E0DAA17
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1Data.FillItem(item, IsInsertMode)
        STUDENT_PROFILE1Holder.DataBind()
        STUDENT_PROFILE1Button_Insert.Visible=IsInsertMode AndAlso STUDENT_PROFILE1Operations.AllowInsert
        STUDENT_PROFILE1Button_Insert1.Visible=IsInsertMode AndAlso STUDENT_PROFILE1Operations.AllowInsert
        STUDENT_PROFILE1Button_Insert2.Visible=IsInsertMode AndAlso STUDENT_PROFILE1Operations.AllowInsert
        STUDENT_PROFILE1Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_PROFILE1Operations.AllowUpdate
        STUDENT_PROFILE1Button_Update1.Visible=Not (IsInsertMode) AndAlso STUDENT_PROFILE1Operations.AllowUpdate
        STUDENT_PROFILE1Button_Update2.Visible=Not (IsInsertMode) AndAlso STUDENT_PROFILE1Operations.AllowUpdate
        STUDENT_PROFILE1STUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_PROFILE1ENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        STUDENT_PROFILE1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1BACKGROUND_INFO.Text=item.BACKGROUND_INFO.GetFormattedValue()
        STUDENT_PROFILE1ENROL_REASONS.Text=item.ENROL_REASONS.GetFormattedValue()
        STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS.Text=item.WELLBEING_INCLUSION_CONCERNS.GetFormattedValue()
        STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL.Text=item.EXPECT_RETURN_TO_SCHOOL.GetFormattedValue()
        item.RETURN_STUDENTItems.SetSelection(item.RETURN_STUDENT.GetFormattedValue())
        STUDENT_PROFILE1RETURN_STUDENT.SelectedIndex = -1
        item.RETURN_STUDENTItems.CopyTo(STUDENT_PROFILE1RETURN_STUDENT.Items, True)
        item.KNOWN_WELLBEINGItems.SetSelection(item.KNOWN_WELLBEING.GetFormattedValue())
        STUDENT_PROFILE1KNOWN_WELLBEING.SelectedIndex = -1
        item.KNOWN_WELLBEINGItems.CopyTo(STUDENT_PROFILE1KNOWN_WELLBEING.Items, True)
        item.KNOWN_INCLUSIONItems.SetSelection(item.KNOWN_INCLUSION.GetFormattedValue())
        STUDENT_PROFILE1KNOWN_INCLUSION.SelectedIndex = -1
        item.KNOWN_INCLUSIONItems.CopyTo(STUDENT_PROFILE1KNOWN_INCLUSION.Items, True)
        item.KNOWN_PATHWAYSItems.SetSelection(item.KNOWN_PATHWAYS.GetFormattedValue())
        STUDENT_PROFILE1KNOWN_PATHWAYS.SelectedIndex = -1
        item.KNOWN_PATHWAYSItems.CopyTo(STUDENT_PROFILE1KNOWN_PATHWAYS.Items, True)
        If item.SUPPORT_DOCS_AGENCY_REFERRALCheckedValue.Value.Equals(item.SUPPORT_DOCS_AGENCY_REFERRAL.Value) Then
            STUDENT_PROFILE1SUPPORT_DOCS_AGENCY_REFERRAL.Checked = True
        End If
        If item.SUPPORT_DOCS_SCHOOL_REFERRALCheckedValue.Value.Equals(item.SUPPORT_DOCS_SCHOOL_REFERRAL.Value) Then
            STUDENT_PROFILE1SUPPORT_DOCS_SCHOOL_REFERRAL.Checked = True
        End If
        If item.SUPPORT_DOCS_YOUNG_ADULTCheckedValue.Value.Equals(item.SUPPORT_DOCS_YOUNG_ADULT.Value) Then
            STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT.Checked = True
        End If
        STUDENT_PROFILE1SUPPORT_DOCS_OTHER.Text=item.SUPPORT_DOCS_OTHER.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME.Text=item.SUPPORT_KEY_PROFESSIONAL_NAME.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT.Text=item.SUPPORT_KEY_PROFESSIONAL_CONTACT.GetFormattedValue()
        STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS.Text=item.ENGAGEMENT_HOBBIES_INTERESTS.GetFormattedValue()
        item.COMM_VISIT_FLAGItems.SetSelection(item.COMM_VISIT_FLAG.GetFormattedValue())
        STUDENT_PROFILE1COMM_VISIT_FLAG.SelectedIndex = -1
        item.COMM_VISIT_FLAGItems.CopyTo(STUDENT_PROFILE1COMM_VISIT_FLAG.Items, True)
        STUDENT_PROFILE1COMM_VISIT_DATE.Text=item.COMM_VISIT_DATE.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("COMM_CONTACT_TYPE")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("COMM_CONTACT_TYPE").GetUpperBound(0)
                item.COMM_CONTACT_TYPEItems.SetSelection(Request.QueryString.GetValues("COMM_CONTACT_TYPE")(i))
            Next i
        End If
        item.COMM_CONTACT_TYPEItems.SetSelection(item.COMM_CONTACT_TYPE.Value)
        STUDENT_PROFILE1COMM_CONTACT_TYPE.SelectedIndex = -1
        item.COMM_CONTACT_TYPEItems.CopyTo(STUDENT_PROFILE1COMM_CONTACT_TYPE.Items)
        STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER.Text=item.COMM_CONTACT_TYPE_OTHER.GetFormattedValue()
        item.COMM_PHONE_CONTACTItems.SetSelection(item.COMM_PHONE_CONTACT.GetFormattedValue())
        STUDENT_PROFILE1COMM_PHONE_CONTACT.SelectedIndex = -1
        item.COMM_PHONE_CONTACTItems.CopyTo(STUDENT_PROFILE1COMM_PHONE_CONTACT.Items)
        STUDENT_PROFILE1CARER_CONTACT_METHOD.Text=item.CARER_CONTACT_METHOD.GetFormattedValue()
        STUDENT_PROFILE1CARER_SUPERVISOR_NAME.Text=item.CARER_SUPERVISOR_NAME.GetFormattedValue()
        item.CARER_SUPERVISOR_ROLEItems.SetSelection(item.CARER_SUPERVISOR_ROLE.GetFormattedValue())
        STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.SelectedIndex = -1
        item.CARER_SUPERVISOR_ROLEItems.CopyTo(STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.Items, True)
        STUDENT_PROFILE1CARER_ADDITIONAL.Text=item.CARER_ADDITIONAL.GetFormattedValue()
        STUDENT_PROFILE1ORGANISATION_WHENWHERE.Text=item.ORGANISATION_WHENWHERE.GetFormattedValue()
        item.ORGANISATION_TIMETABLEItems.SetSelection(item.ORGANISATION_TIMETABLE.GetFormattedValue())
        STUDENT_PROFILE1ORGANISATION_TIMETABLE.SelectedIndex = -1
        item.ORGANISATION_TIMETABLEItems.CopyTo(STUDENT_PROFILE1ORGANISATION_TIMETABLE.Items, True)
        STUDENT_PROFILE1ORGANISATION_HARDWARE.Items.Add(new ListItem("Select Value",""))
        STUDENT_PROFILE1ORGANISATION_HARDWARE.Items(0).Selected = True
        item.ORGANISATION_HARDWAREItems.SetSelection(item.ORGANISATION_HARDWARE.GetFormattedValue())
        If Not item.ORGANISATION_HARDWAREItems.GetSelectedItem() Is Nothing Then
            STUDENT_PROFILE1ORGANISATION_HARDWARE.SelectedIndex = -1
        End If
        item.ORGANISATION_HARDWAREItems.CopyTo(STUDENT_PROFILE1ORGANISATION_HARDWARE.Items)
        STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET.Text=item.ORGANISATION_ACCESS_INTERNET.GetFormattedValue()
        STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL.Text=item.ORGANISATION_PREVIOUS_SCHOOL.GetFormattedValue()
        STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY.Text=item.ORGANISATION_ACADEMIC_HISTORY.GetFormattedValue()
        item.ORGANISATION_RECENTREPORT_FILEDItems.SetSelection(item.ORGANISATION_RECENTREPORT_FILED.GetFormattedValue())
        STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.SelectedIndex = -1
        item.ORGANISATION_RECENTREPORT_FILEDItems.CopyTo(STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.Items, True)
        item.LAUNCH_PAD_DONEItems.SetSelection(item.LAUNCH_PAD_DONE.GetFormattedValue())
        STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedIndex = -1
        item.LAUNCH_PAD_DONEItems.CopyTo(STUDENT_PROFILE1LAUNCH_PAD_DONE.Items, True)
        STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.Text=item.LAUNCH_PAD_DONE_DATE.GetFormattedValue()
        STUDENT_PROFILE1LEARNING_PROGRAM.Value = item.LEARNING_PROGRAM.GetFormattedValue()
        STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.Text=item.LEARNING_PROGRAM_DETAILS.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("LEARNING_PROGRAM_CONSULT")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("LEARNING_PROGRAM_CONSULT").GetUpperBound(0)
                item.LEARNING_PROGRAM_CONSULTItems.SetSelection(Request.QueryString.GetValues("LEARNING_PROGRAM_CONSULT")(i))
            Next i
        End If
        item.LEARNING_PROGRAM_CONSULTItems.SetSelection(item.LEARNING_PROGRAM_CONSULT.Value)
        STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedIndex = -1
        item.LEARNING_PROGRAM_CONSULTItems.CopyTo(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
        STUDENT_PROFILE1LEARNING_GOALS.Text=item.LEARNING_GOALS.GetFormattedValue()
        item.SPECIAL_PROVISION_FLAGItems.SetSelection(item.SPECIAL_PROVISION_FLAG.GetFormattedValue())
        STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedIndex = -1
        item.SPECIAL_PROVISION_FLAGItems.CopyTo(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.Items, True)
        STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.Text=item.SPECIAL_PROVISION_DETAILS.GetFormattedValue()
        item.PATHWAYS_CAREER_PLAN_FLAGItems.SetSelection(item.PATHWAYS_CAREER_PLAN_FLAG.GetFormattedValue())
        STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.SelectedIndex = -1
        item.PATHWAYS_CAREER_PLAN_FLAGItems.CopyTo(STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.Items, True)
        STUDENT_PROFILE1PATHWAYS_CAREER_GOALS.Text=item.PATHWAYS_CAREER_GOALS.GetFormattedValue()
        STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR.Text=item.PATHWAYS_CAREER_GOALS_MIDYEAR.GetFormattedValue()
        STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.Text=item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.GetFormattedValue()
        item.PATHWAYS_WORKEXP_FLAGItems.SetSelection(item.PATHWAYS_WORKEXP_FLAG.GetFormattedValue())
        STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.SelectedIndex = -1
        item.PATHWAYS_WORKEXP_FLAGItems.CopyTo(STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.Items, True)
        STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS.Text=item.PATHWAYS_WORKEXP_DETAILS.GetFormattedValue()
        STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS.Text=item.PATHWAYS_PARTTIMEJOBS.GetFormattedValue()
        item.PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems.SetSelection(item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.GetFormattedValue())
        STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SelectedIndex = -1
        item.PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems.CopyTo(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.Items, True)
        STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE.Text=item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.GetFormattedValue()
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems.SetSelection(item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.GetFormattedValue())
        STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SelectedIndex = -1
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems.CopyTo(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.Items, True)
        STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.Text=item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.GetFormattedValue()
        STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.Text=item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue()
        STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.Text=item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue()
        STUDENT_PROFILE1lblLearningProgram.Text = item.lblLearningProgram.GetFormattedValue()
        STUDENT_PROFILE1lblStudentID.Text = item.lblStudentID.GetFormattedValue()
        STUDENT_PROFILE1lblEnrolYear.Text = Server.HtmlEncode(item.lblEnrolYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_BY1.Text = Server.HtmlEncode(item.LAST_ALTERED_BY1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_DATE1.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1hidden_LastUpdatedBy.Value = item.hidden_LastUpdatedBy.GetFormattedValue()
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = item.hidden_LastUpdatedWhen.GetFormattedValue()
        STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_ENGLANG_LP.Text=item.ASSESS_ENGLANG_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_ENGLANG_RL.Text=item.ASSESS_ENGLANG_RL.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_MATH_LP.Text=item.ASSESS_MATH_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_MATH_RL.Text=item.ASSESS_MATH_RL.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.Text=item.ASSESS_PATSCIENCE_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.Text=item.ASSESS_PATSCIENCE_RL.GetFormattedValue()
        STUDENT_PROFILE1error_BackgroundInfo.Text = item.error_BackgroundInfo.GetFormattedValue()
        STUDENT_PROFILE1error_ReasonsEnrol.Text = item.error_ReasonsEnrol.GetFormattedValue()
        STUDENT_PROFILE1error_StudentWellbeing.Text = item.error_StudentWellbeing.GetFormattedValue()
        STUDENT_PROFILE1error_ReturnMainstream.Text = item.error_ReturnMainstream.GetFormattedValue()
        STUDENT_PROFILE1error_ReturningStudent.Text = item.error_ReturningStudent.GetFormattedValue()
        STUDENT_PROFILE1error_StudentWellbeing2.Text = item.error_StudentWellbeing2.GetFormattedValue()
        STUDENT_PROFILE1error_StudentInclusion.Text = item.error_StudentInclusion.GetFormattedValue()
        STUDENT_PROFILE1error_PrevPathways.Text = item.error_PrevPathways.GetFormattedValue()
        STUDENT_PROFILE1error_SupportDocs.Text = item.error_SupportDocs.GetFormattedValue()
        STUDENT_PROFILE1error_HobbiesInterests.Text = item.error_HobbiesInterests.GetFormattedValue()
        STUDENT_PROFILE1error_CommsVisit.Text = item.error_CommsVisit.GetFormattedValue()
        STUDENT_PROFILE1error_ContactType.Text = item.error_ContactType.GetFormattedValue()
        STUDENT_PROFILE1error_CarerContactMethod.Text = item.error_CarerContactMethod.GetFormattedValue()
        STUDENT_PROFILE1error_SupervisorName.Text = item.error_SupervisorName.GetFormattedValue()
        STUDENT_PROFILE1error_SupervisorRole.Text = item.error_SupervisorRole.GetFormattedValue()
        STUDENT_PROFILE1error_KeyProfSupports.Text = item.error_KeyProfSupports.GetFormattedValue()
        STUDENT_PROFILE1error_AddCarerInfo.Text = item.error_AddCarerInfo.GetFormattedValue()
        STUDENT_PROFILE1error_Workspace.Text = item.error_Workspace.GetFormattedValue()
        STUDENT_PROFILE1error_OrgHardware.Text = item.error_OrgHardware.GetFormattedValue()
        STUDENT_PROFILE1error_OrgInternet.Text = item.error_OrgInternet.GetFormattedValue()
        STUDENT_PROFILE1error_OrgPrevSchools.Text = item.error_OrgPrevSchools.GetFormattedValue()
        STUDENT_PROFILE1error_OrgAcademic.Text = item.error_OrgAcademic.GetFormattedValue()
        STUDENT_PROFILE1error_AssessData.Text = item.error_AssessData.GetFormattedValue()
        STUDENT_PROFILE1error_LearnDetails.Text = item.error_LearnDetails.GetFormattedValue()
        STUDENT_PROFILE1error_LearnGoals.Text = item.error_LearnGoals.GetFormattedValue()
        STUDENT_PROFILE1error_SpecialProvision.Text = item.error_SpecialProvision.GetFormattedValue()
        STUDENT_PROFILE1error_Goals.Text = item.error_Goals.GetFormattedValue()
        STUDENT_PROFILE1error_GoalsMidyear.Text = item.error_GoalsMidyear.GetFormattedValue()
        STUDENT_PROFILE1error_PartTimeJobs.Text = item.error_PartTimeJobs.GetFormattedValue()
        STUDENT_PROFILE1error_ProgressSem1.Text = item.error_ProgressSem1.GetFormattedValue()
        STUDENT_PROFILE1error_ProgressSem2.Text = item.error_ProgressSem2.GetFormattedValue()
        STUDENT_PROFILE1error_WorkExp910.Text = item.error_WorkExp910.GetFormattedValue()
        STUDENT_PROFILE1error_EndYearDisc.Text = item.error_EndYearDisc.GetFormattedValue()
        STUDENT_PROFILE1error_EndYearLogged.Text = item.error_EndYearLogged.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2.Text=item.SUPPORT_KEY_PROFESSIONAL_NAME2.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2.Text=item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.GetFormattedValue()
        If item.cbENROL_FILE_CHECKEDCheckedValue.Value.Equals(item.cbENROL_FILE_CHECKED.Value) Then
            STUDENT_PROFILE1cbENROL_FILE_CHECKED.Checked = True
        End If
        STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value = item.Hidden_COMM_CONTACT_TYPE_MULTI.GetFormattedValue()
        STUDENT_PROFILE1error_LPDone.Text = item.error_LPDone.GetFormattedValue()
        STUDENT_PROFILE1Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_PROFILE1Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
        If item.cbConfidentialDocumentsCheckedValue.Value.Equals(item.cbConfidentialDocuments.Value) Then
            STUDENT_PROFILE1cbConfidentialDocuments.Checked = True
        End If
        If item.cbRiskFactorsCheckedValue.Value.Equals(item.cbRiskFactors.Value) Then
            STUDENT_PROFILE1cbRiskFactors.Checked = True
        End If
        If (Not IsNothing(Request.QueryString("COMM_INTAKE_CONTACT_TYPE_MULTI")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("COMM_INTAKE_CONTACT_TYPE_MULTI").GetUpperBound(0)
                item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.SetSelection(Request.QueryString.GetValues("COMM_INTAKE_CONTACT_TYPE_MULTI")(i))
            Next i
        End If
        item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.SetSelection(item.COMM_INTAKE_CONTACT_TYPE_MULTI.Value)
        STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI.SelectedIndex = -1
        item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.CopyTo(STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI.Items)
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE.Text=item.SUPPORT_KEY_PROFESSIONAL_ROLE.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2.Text=item.SUPPORT_KEY_PROFESSIONAL_ROLE2.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3.Text=item.SUPPORT_KEY_PROFESSIONAL_NAME3.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3.Text=item.SUPPORT_KEY_PROFESSIONAL_ROLE3.GetFormattedValue()
        STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3.Text=item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.GetFormattedValue()
        If item.SUPPORT_DOCS_YOUNG_ADULT1CheckedValue.Value.Equals(item.SUPPORT_DOCS_YOUNG_ADULT1.Value) Then
            STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT1.Checked = True
        End If
        STUDENT_PROFILE1Link2.InnerText += item.Link2.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_PROFILE1Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("GET","", ViewState)
'End Record Form STUDENT_PROFILE1 BeforeShow tail

'CheckBoxList COMM_CONTACT_TYPE Event BeforeShow. Action Custom Code @210-73254650
    ' -------------------------
    'change layout 
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatColumns = 1
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatDirection = RepeatDirection.Vertical
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatLayout = RepeatLayout.Flow
	
    ' -------------------------
'End CheckBoxList COMM_CONTACT_TYPE Event BeforeShow. Action Custom Code

'CheckBoxList COMM_CONTACT_TYPE Event BeforeShow. Action Custom Code @211-73254650
    ' -------------------------
     '22-Mar-2018|EA| tick the Contact Types

	if (item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0" and item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0,") then

		Dim checkItemsDis2 As String() = item.Hidden_COMM_CONTACT_TYPE_MULTI.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis2 As String = ""
		For Each thisItemDis2 In checkItemsDis2
			' set that item as checked
			item.COMM_CONTACT_TYPEItems.SetSelection(thisItemDis2)
		Next
		' and display
		STUDENT_PROFILE1COMM_CONTACT_TYPE.Items.Clear()
	    item.COMM_CONTACT_TYPEItems.CopyTo(STUDENT_PROFILE1COMM_CONTACT_TYPE.Items)
	end if
    
    ' -------------------------
'End CheckBoxList COMM_CONTACT_TYPE Event BeforeShow. Action Custom Code

'Hidden LEARNING_PROGRAM Event BeforeShow. Action Declare Variable @201-584C1CC6
            Dim intCLPCount As Int64 = 0
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action Declare Variable

'Hidden LEARNING_PROGRAM Event BeforeShow. Action DLookup @199-16EE4444
            intCLPCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "view_StudentsOnACLP" & " WHERE " & "StudentId = "&STUDENT_PROFILE1Data.UrlSTUDENT_ID.tostring()))).Value, Int64)
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action DLookup

'Hidden LEARNING_PROGRAM Event BeforeShow. Action Custom Code @200-73254650
    ' -------------------------
    '8-Feb-2018|EA| count student custom subjects and change label accordingly  (ticket 10637)
    if (intCLPCount > 0) then
    	STUDENT_PROFILE1LEARNING_PROGRAM.Value = "Customised"
    	STUDENT_PROFILE1lblLearningProgram.Text = "<span style='color:white;background-color:orange'><strong>Customised</strong></span>"
    else
    	STUDENT_PROFILE1LEARNING_PROGRAM.Value = "Standard"
    	STUDENT_PROFILE1lblLearningProgram.Text = "Standard"
    end if
    ' -------------------------
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action Custom Code

'CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code @105-73254650
    ' -------------------------
    'change layout 
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatColumns = 1
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatDirection = RepeatDirection.Vertical
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatLayout = RepeatLayout.Flow
	
    ' -------------------------
'End CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code

'CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code @99-73254650
    ' -------------------------
     '15-Dec-2016|EA| tick the Learning Program Consultation
     ' item.LEARNING_PROGRAM_CONSULTItems.SetSelection(item.LEARNING_PROGRAM_CONSULT.Value)
      ' STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.

	if (item.Hidden_LEARNING_PROGRAM_CONSULT.Value <> "0" and item.Hidden_LEARNING_PROGRAM_CONSULT.Value <> "0,") then

		Dim checkItemsDis As String() = item.Hidden_LEARNING_PROGRAM_CONSULT.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis As String = ""
		For Each thisItemDis In checkItemsDis
			' set that item as checked
			item.LEARNING_PROGRAM_CONSULTItems.SetSelection(thisItemDis)
		Next
		' and display
		STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items.Clear()
	    item.LEARNING_PROGRAM_CONSULTItems.CopyTo(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
	end if
    ' -------------------------
'End CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code

'Hidden hidden_LastUpdatedBy Event BeforeShow. Action Retrieve Value for Control @126-F1E0820D
            STUDENT_PROFILE1hidden_LastUpdatedBy.Value = (New TextField("", (DBUtility.UserID.ToUpper))).GetFormattedValue()
'End Hidden hidden_LastUpdatedBy Event BeforeShow. Action Retrieve Value for Control

'CheckBoxList COMM_INTAKE_CONTACT_TYPE_MULTI Event BeforeShow. Action Custom Code @228-73254650
    ' -------------------------
    'change layout 
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatColumns = 1
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatDirection = RepeatDirection.Vertical
	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatLayout = RepeatLayout.Flow
	
    ' -------------------------
'End CheckBoxList COMM_INTAKE_CONTACT_TYPE_MULTI Event BeforeShow. Action Custom Code

'CheckBoxList COMM_INTAKE_CONTACT_TYPE_MULTI Event BeforeShow. Action Custom Code @229-73254650
    ' -------------------------
     '22-Mar-2018|EA| tick the Contact Types

	if (item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0" and item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0,") then

		Dim checkItemsDis2 As String() = item.Hidden_COMM_CONTACT_TYPE_MULTI.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis2 As String = ""
		For Each thisItemDis2 In checkItemsDis2
			' set that item as checked
			item.COMM_CONTACT_TYPEItems.SetSelection(thisItemDis2)
		Next
		' and display
		STUDENT_PROFILE1COMM_CONTACT_TYPE.Items.Clear()
	    item.COMM_CONTACT_TYPEItems.CopyTo(STUDENT_PROFILE1COMM_CONTACT_TYPE.Items)
	end if
    
    ' -------------------------
'End CheckBoxList COMM_INTAKE_CONTACT_TYPE_MULTI Event BeforeShow. Action Custom Code

'Record Form STUDENT_PROFILE1 Show method tail @3-5901EE9C
        If STUDENT_PROFILE1Errors.Count > 0 Then
            STUDENT_PROFILE1ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 Show method tail

'Record Form STUDENT_PROFILE1 LoadItemFromRequest method @3-E32F8F01

    Protected Sub STUDENT_PROFILE1LoadItemFromRequest(item As STUDENT_PROFILE1Item, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1STUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_PROFILE1STUDENT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(STUDENT_PROFILE1ENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.BACKGROUND_INFO.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1BACKGROUND_INFO.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1BACKGROUND_INFO") Is Nothing Then
            item.BACKGROUND_INFO.SetValue(STUDENT_PROFILE1BACKGROUND_INFO.Text)
        Else
            item.BACKGROUND_INFO.SetValue(ControlCustomValues("STUDENT_PROFILE1BACKGROUND_INFO"))
        End If
        item.ENROL_REASONS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ENROL_REASONS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ENROL_REASONS") Is Nothing Then
            item.ENROL_REASONS.SetValue(STUDENT_PROFILE1ENROL_REASONS.Text)
        Else
            item.ENROL_REASONS.SetValue(ControlCustomValues("STUDENT_PROFILE1ENROL_REASONS"))
        End If
        item.WELLBEING_INCLUSION_CONCERNS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS") Is Nothing Then
            item.WELLBEING_INCLUSION_CONCERNS.SetValue(STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS.Text)
        Else
            item.WELLBEING_INCLUSION_CONCERNS.SetValue(ControlCustomValues("STUDENT_PROFILE1WELLBEING_INCLUSION_CONCERNS"))
        End If
        item.EXPECT_RETURN_TO_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL") Is Nothing Then
            item.EXPECT_RETURN_TO_SCHOOL.SetValue(STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL.Text)
        Else
            item.EXPECT_RETURN_TO_SCHOOL.SetValue(ControlCustomValues("STUDENT_PROFILE1EXPECT_RETURN_TO_SCHOOL"))
        End If
        item.RETURN_STUDENT.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1RETURN_STUDENT.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1RETURN_STUDENT.SelectedItem) Then
            item.RETURN_STUDENT.SetValue(STUDENT_PROFILE1RETURN_STUDENT.SelectedItem.Value)
        Else
            item.RETURN_STUDENT.Value = Nothing
        End If
        item.RETURN_STUDENTItems.CopyFrom(STUDENT_PROFILE1RETURN_STUDENT.Items)
        item.KNOWN_WELLBEING.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1KNOWN_WELLBEING.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1KNOWN_WELLBEING.SelectedItem) Then
            item.KNOWN_WELLBEING.SetValue(STUDENT_PROFILE1KNOWN_WELLBEING.SelectedItem.Value)
        Else
            item.KNOWN_WELLBEING.Value = Nothing
        End If
        item.KNOWN_WELLBEINGItems.CopyFrom(STUDENT_PROFILE1KNOWN_WELLBEING.Items)
        item.KNOWN_INCLUSION.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1KNOWN_INCLUSION.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1KNOWN_INCLUSION.SelectedItem) Then
            item.KNOWN_INCLUSION.SetValue(STUDENT_PROFILE1KNOWN_INCLUSION.SelectedItem.Value)
        Else
            item.KNOWN_INCLUSION.Value = Nothing
        End If
        item.KNOWN_INCLUSIONItems.CopyFrom(STUDENT_PROFILE1KNOWN_INCLUSION.Items)
        item.KNOWN_PATHWAYS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1KNOWN_PATHWAYS.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1KNOWN_PATHWAYS.SelectedItem) Then
            item.KNOWN_PATHWAYS.SetValue(STUDENT_PROFILE1KNOWN_PATHWAYS.SelectedItem.Value)
        Else
            item.KNOWN_PATHWAYS.Value = Nothing
        End If
        item.KNOWN_PATHWAYSItems.CopyFrom(STUDENT_PROFILE1KNOWN_PATHWAYS.Items)
        If STUDENT_PROFILE1SUPPORT_DOCS_AGENCY_REFERRAL.Checked Then
            item.SUPPORT_DOCS_AGENCY_REFERRAL.Value = (item.SUPPORT_DOCS_AGENCY_REFERRALCheckedValue.Value)
        Else
            item.SUPPORT_DOCS_AGENCY_REFERRAL.Value = (item.SUPPORT_DOCS_AGENCY_REFERRALUncheckedValue.Value)
        End If
        If STUDENT_PROFILE1SUPPORT_DOCS_SCHOOL_REFERRAL.Checked Then
            item.SUPPORT_DOCS_SCHOOL_REFERRAL.Value = (item.SUPPORT_DOCS_SCHOOL_REFERRALCheckedValue.Value)
        Else
            item.SUPPORT_DOCS_SCHOOL_REFERRAL.Value = (item.SUPPORT_DOCS_SCHOOL_REFERRALUncheckedValue.Value)
        End If
        If STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT.Checked Then
            item.SUPPORT_DOCS_YOUNG_ADULT.Value = (item.SUPPORT_DOCS_YOUNG_ADULTCheckedValue.Value)
        Else
            item.SUPPORT_DOCS_YOUNG_ADULT.Value = (item.SUPPORT_DOCS_YOUNG_ADULTUncheckedValue.Value)
        End If
        item.SUPPORT_DOCS_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_DOCS_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_DOCS_OTHER") Is Nothing Then
            item.SUPPORT_DOCS_OTHER.SetValue(STUDENT_PROFILE1SUPPORT_DOCS_OTHER.Text)
        Else
            item.SUPPORT_DOCS_OTHER.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_DOCS_OTHER"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_NAME.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_NAME.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT"))
        End If
        item.ENGAGEMENT_HOBBIES_INTERESTS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS") Is Nothing Then
            item.ENGAGEMENT_HOBBIES_INTERESTS.SetValue(STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS.Text)
        Else
            item.ENGAGEMENT_HOBBIES_INTERESTS.SetValue(ControlCustomValues("STUDENT_PROFILE1ENGAGEMENT_HOBBIES_INTERESTS"))
        End If
        item.COMM_VISIT_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1COMM_VISIT_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1COMM_VISIT_FLAG.SelectedItem) Then
            item.COMM_VISIT_FLAG.SetValue(STUDENT_PROFILE1COMM_VISIT_FLAG.SelectedItem.Value)
        Else
            item.COMM_VISIT_FLAG.Value = Nothing
        End If
        item.COMM_VISIT_FLAGItems.CopyFrom(STUDENT_PROFILE1COMM_VISIT_FLAG.Items)
        Try
        item.COMM_VISIT_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1COMM_VISIT_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1COMM_VISIT_DATE") Is Nothing Then
            item.COMM_VISIT_DATE.SetValue(STUDENT_PROFILE1COMM_VISIT_DATE.Text)
        Else
            item.COMM_VISIT_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1COMM_VISIT_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("COMM_VISIT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"COMM VISIT DATE","d/m/yyyy"))
        End Try
        If Not IsNothing(STUDENT_PROFILE1COMM_CONTACT_TYPE.SelectedItem) Then
            item.COMM_CONTACT_TYPE.SetValue(STUDENT_PROFILE1COMM_CONTACT_TYPE.SelectedItem.Value)
        Else
            item.COMM_CONTACT_TYPE.Value = Nothing
        End If
        item.COMM_CONTACT_TYPEItems.CopyFrom(STUDENT_PROFILE1COMM_CONTACT_TYPE.Items)
        item.COMM_CONTACT_TYPE_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER") Is Nothing Then
            item.COMM_CONTACT_TYPE_OTHER.SetValue(STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER.Text)
        Else
            item.COMM_CONTACT_TYPE_OTHER.SetValue(ControlCustomValues("STUDENT_PROFILE1COMM_CONTACT_TYPE_OTHER"))
        End If
        item.COMM_PHONE_CONTACT.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1COMM_PHONE_CONTACT.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1COMM_PHONE_CONTACT.SelectedItem) Then
            item.COMM_PHONE_CONTACT.SetValue(STUDENT_PROFILE1COMM_PHONE_CONTACT.SelectedItem.Value)
        Else
            item.COMM_PHONE_CONTACT.Value = Nothing
        End If
        item.COMM_PHONE_CONTACTItems.CopyFrom(STUDENT_PROFILE1COMM_PHONE_CONTACT.Items)
        item.CARER_CONTACT_METHOD.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1CARER_CONTACT_METHOD.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1CARER_CONTACT_METHOD") Is Nothing Then
            item.CARER_CONTACT_METHOD.SetValue(STUDENT_PROFILE1CARER_CONTACT_METHOD.Text)
        Else
            item.CARER_CONTACT_METHOD.SetValue(ControlCustomValues("STUDENT_PROFILE1CARER_CONTACT_METHOD"))
        End If
        item.CARER_SUPERVISOR_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1CARER_SUPERVISOR_NAME.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1CARER_SUPERVISOR_NAME") Is Nothing Then
            item.CARER_SUPERVISOR_NAME.SetValue(STUDENT_PROFILE1CARER_SUPERVISOR_NAME.Text)
        Else
            item.CARER_SUPERVISOR_NAME.SetValue(ControlCustomValues("STUDENT_PROFILE1CARER_SUPERVISOR_NAME"))
        End If
        item.CARER_SUPERVISOR_ROLE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.SelectedItem) Then
            item.CARER_SUPERVISOR_ROLE.SetValue(STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.SelectedItem.Value)
        Else
            item.CARER_SUPERVISOR_ROLE.Value = Nothing
        End If
        item.CARER_SUPERVISOR_ROLEItems.CopyFrom(STUDENT_PROFILE1CARER_SUPERVISOR_ROLE.Items)
        item.CARER_ADDITIONAL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1CARER_ADDITIONAL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1CARER_ADDITIONAL") Is Nothing Then
            item.CARER_ADDITIONAL.SetValue(STUDENT_PROFILE1CARER_ADDITIONAL.Text)
        Else
            item.CARER_ADDITIONAL.SetValue(ControlCustomValues("STUDENT_PROFILE1CARER_ADDITIONAL"))
        End If
        item.ORGANISATION_WHENWHERE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_WHENWHERE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ORGANISATION_WHENWHERE") Is Nothing Then
            item.ORGANISATION_WHENWHERE.SetValue(STUDENT_PROFILE1ORGANISATION_WHENWHERE.Text)
        Else
            item.ORGANISATION_WHENWHERE.SetValue(ControlCustomValues("STUDENT_PROFILE1ORGANISATION_WHENWHERE"))
        End If
        item.ORGANISATION_TIMETABLE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_TIMETABLE.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1ORGANISATION_TIMETABLE.SelectedItem) Then
            item.ORGANISATION_TIMETABLE.SetValue(STUDENT_PROFILE1ORGANISATION_TIMETABLE.SelectedItem.Value)
        Else
            item.ORGANISATION_TIMETABLE.Value = Nothing
        End If
        item.ORGANISATION_TIMETABLEItems.CopyFrom(STUDENT_PROFILE1ORGANISATION_TIMETABLE.Items)
        item.ORGANISATION_HARDWARE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_HARDWARE.UniqueID))
        item.ORGANISATION_HARDWARE.SetValue(STUDENT_PROFILE1ORGANISATION_HARDWARE.Value)
        item.ORGANISATION_HARDWAREItems.CopyFrom(STUDENT_PROFILE1ORGANISATION_HARDWARE.Items)
        item.ORGANISATION_ACCESS_INTERNET.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET") Is Nothing Then
            item.ORGANISATION_ACCESS_INTERNET.SetValue(STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET.Text)
        Else
            item.ORGANISATION_ACCESS_INTERNET.SetValue(ControlCustomValues("STUDENT_PROFILE1ORGANISATION_ACCESS_INTERNET"))
        End If
        item.ORGANISATION_PREVIOUS_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL") Is Nothing Then
            item.ORGANISATION_PREVIOUS_SCHOOL.SetValue(STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL.Text)
        Else
            item.ORGANISATION_PREVIOUS_SCHOOL.SetValue(ControlCustomValues("STUDENT_PROFILE1ORGANISATION_PREVIOUS_SCHOOL"))
        End If
        item.ORGANISATION_ACADEMIC_HISTORY.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY") Is Nothing Then
            item.ORGANISATION_ACADEMIC_HISTORY.SetValue(STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY.Text)
        Else
            item.ORGANISATION_ACADEMIC_HISTORY.SetValue(ControlCustomValues("STUDENT_PROFILE1ORGANISATION_ACADEMIC_HISTORY"))
        End If
        item.ORGANISATION_RECENTREPORT_FILED.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.SelectedItem) Then
            item.ORGANISATION_RECENTREPORT_FILED.SetValue(STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.SelectedItem.Value)
        Else
            item.ORGANISATION_RECENTREPORT_FILED.Value = Nothing
        End If
        item.ORGANISATION_RECENTREPORT_FILEDItems.CopyFrom(STUDENT_PROFILE1ORGANISATION_RECENTREPORT_FILED.Items)
        item.LAUNCH_PAD_DONE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LAUNCH_PAD_DONE.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedItem) Then
            item.LAUNCH_PAD_DONE.SetValue(STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedItem.Value)
        Else
            item.LAUNCH_PAD_DONE.Value = Nothing
        End If
        item.LAUNCH_PAD_DONEItems.CopyFrom(STUDENT_PROFILE1LAUNCH_PAD_DONE.Items)
        Try
        item.LAUNCH_PAD_DONE_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE") Is Nothing Then
            item.LAUNCH_PAD_DONE_DATE.SetValue(STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.Text)
        Else
            item.LAUNCH_PAD_DONE_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("LAUNCH_PAD_DONE_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAUNCH PAD DONE DATE","d/m/yyyy"))
        End Try
        item.LEARNING_PROGRAM.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LEARNING_PROGRAM.UniqueID))
        item.LEARNING_PROGRAM.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM.Value)
        item.LEARNING_PROGRAM_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS") Is Nothing Then
            item.LEARNING_PROGRAM_DETAILS.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.Text)
        Else
            item.LEARNING_PROGRAM_DETAILS.SetValue(ControlCustomValues("STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS"))
        End If
        If Not IsNothing(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedItem) Then
            item.LEARNING_PROGRAM_CONSULT.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedItem.Value)
        Else
            item.LEARNING_PROGRAM_CONSULT.Value = Nothing
        End If
        item.LEARNING_PROGRAM_CONSULTItems.CopyFrom(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
        item.LEARNING_GOALS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LEARNING_GOALS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1LEARNING_GOALS") Is Nothing Then
            item.LEARNING_GOALS.SetValue(STUDENT_PROFILE1LEARNING_GOALS.Text)
        Else
            item.LEARNING_GOALS.SetValue(ControlCustomValues("STUDENT_PROFILE1LEARNING_GOALS"))
        End If
        item.SPECIAL_PROVISION_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedItem) Then
            item.SPECIAL_PROVISION_FLAG.SetValue(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedItem.Value)
        Else
            item.SPECIAL_PROVISION_FLAG.Value = Nothing
        End If
        item.SPECIAL_PROVISION_FLAGItems.CopyFrom(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.Items)
        item.SPECIAL_PROVISION_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS") Is Nothing Then
            item.SPECIAL_PROVISION_DETAILS.SetValue(STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.Text)
        Else
            item.SPECIAL_PROVISION_DETAILS.SetValue(ControlCustomValues("STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS"))
        End If
        item.PATHWAYS_CAREER_PLAN_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.SelectedItem) Then
            item.PATHWAYS_CAREER_PLAN_FLAG.SetValue(STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.SelectedItem.Value)
        Else
            item.PATHWAYS_CAREER_PLAN_FLAG.Value = Nothing
        End If
        item.PATHWAYS_CAREER_PLAN_FLAGItems.CopyFrom(STUDENT_PROFILE1PATHWAYS_CAREER_PLAN_FLAG.Items)
        item.PATHWAYS_CAREER_GOALS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS") Is Nothing Then
            item.PATHWAYS_CAREER_GOALS.SetValue(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS.Text)
        Else
            item.PATHWAYS_CAREER_GOALS.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS"))
        End If
        item.PATHWAYS_CAREER_GOALS_MIDYEAR.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR") Is Nothing Then
            item.PATHWAYS_CAREER_GOALS_MIDYEAR.SetValue(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR.Text)
        Else
            item.PATHWAYS_CAREER_GOALS_MIDYEAR.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR"))
        End If
        Try
        item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE") Is Nothing Then
            item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.SetValue(STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.Text)
        Else
            item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("PATHWAYS_CAREER_GOALS_MIDYEAR_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"PATHWAYS CAREER GOALS MIDYEAR DATE","d/m/yyyy"))
        End Try
        item.PATHWAYS_WORKEXP_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.SelectedItem) Then
            item.PATHWAYS_WORKEXP_FLAG.SetValue(STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.SelectedItem.Value)
        Else
            item.PATHWAYS_WORKEXP_FLAG.Value = Nothing
        End If
        item.PATHWAYS_WORKEXP_FLAGItems.CopyFrom(STUDENT_PROFILE1PATHWAYS_WORKEXP_FLAG.Items)
        item.PATHWAYS_WORKEXP_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS") Is Nothing Then
            item.PATHWAYS_WORKEXP_DETAILS.SetValue(STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS.Text)
        Else
            item.PATHWAYS_WORKEXP_DETAILS.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_WORKEXP_DETAILS"))
        End If
        item.PATHWAYS_PARTTIMEJOBS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS") Is Nothing Then
            item.PATHWAYS_PARTTIMEJOBS.SetValue(STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS.Text)
        Else
            item.PATHWAYS_PARTTIMEJOBS.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_PARTTIMEJOBS"))
        End If
        item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SelectedItem) Then
            item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SetValue(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SelectedItem.Value)
        Else
            item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.Value = Nothing
        End If
        item.PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems.CopyFrom(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_FLAG.Items)
        Try
        item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE") Is Nothing Then
            item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.SetValue(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE.Text)
        Else
            item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("PATHWAYS_ENDYEAR_INTENTIONS_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"PATHWAYS ENDYEAR INTENTIONS DATE","d/m/yyyy"))
        End Try
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SelectedItem) Then
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SetValue(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SelectedItem.Value)
        Else
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.Value = Nothing
        End If
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems.CopyFrom(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.Items)
        Try
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE") Is Nothing Then
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.SetValue(STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.Text)
        Else
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"PATHWAYS ENDYEAR INTENTIONS LOGGED DATE","d/m/yyyy"))
        End Try
        item.REVIEW_PROGRESS_END_SEM1.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1") Is Nothing Then
            item.REVIEW_PROGRESS_END_SEM1.SetValue(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.Text)
        Else
            item.REVIEW_PROGRESS_END_SEM1.SetValue(ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1"))
        End If
        item.REVIEW_PROGRESS_END_SEM2.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2") Is Nothing Then
            item.REVIEW_PROGRESS_END_SEM2.SetValue(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.Text)
        Else
            item.REVIEW_PROGRESS_END_SEM2.SetValue(ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2"))
        End If
        item.hidden_LastUpdatedBy.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1hidden_LastUpdatedBy.UniqueID))
        item.hidden_LastUpdatedBy.SetValue(STUDENT_PROFILE1hidden_LastUpdatedBy.Value)
        Try
        item.hidden_LastUpdatedWhen.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1hidden_LastUpdatedWhen.UniqueID))
        item.hidden_LastUpdatedWhen.SetValue(STUDENT_PROFILE1hidden_LastUpdatedWhen.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("hidden_LastUpdatedWhen",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LastUpdatedWhen","yyyy-mm-dd H:nn"))
        End Try
        item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.UniqueID))
        item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value)
        item.ASSESS_ENGLANG_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_ENGLANG_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_LP") Is Nothing Then
            item.ASSESS_ENGLANG_LP.SetValue(STUDENT_PROFILE1ASSESS_ENGLANG_LP.Text)
        Else
            item.ASSESS_ENGLANG_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_LP"))
        End If
        item.ASSESS_ENGLANG_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_ENGLANG_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_RL") Is Nothing Then
            item.ASSESS_ENGLANG_RL.SetValue(STUDENT_PROFILE1ASSESS_ENGLANG_RL.Text)
        Else
            item.ASSESS_ENGLANG_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_RL"))
        End If
        item.ASSESS_MATH_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_MATH_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_LP") Is Nothing Then
            item.ASSESS_MATH_LP.SetValue(STUDENT_PROFILE1ASSESS_MATH_LP.Text)
        Else
            item.ASSESS_MATH_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_LP"))
        End If
        item.ASSESS_MATH_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_MATH_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_RL") Is Nothing Then
            item.ASSESS_MATH_RL.SetValue(STUDENT_PROFILE1ASSESS_MATH_RL.Text)
        Else
            item.ASSESS_MATH_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_RL"))
        End If
        item.ASSESS_PATSCIENCE_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_LP") Is Nothing Then
            item.ASSESS_PATSCIENCE_LP.SetValue(STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.Text)
        Else
            item.ASSESS_PATSCIENCE_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_LP"))
        End If
        item.ASSESS_PATSCIENCE_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_RL") Is Nothing Then
            item.ASSESS_PATSCIENCE_RL.SetValue(STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.Text)
        Else
            item.ASSESS_PATSCIENCE_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_RL"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_NAME2.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_NAME2.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_NAME2.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME2"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT2"))
        End If
        If STUDENT_PROFILE1cbENROL_FILE_CHECKED.Checked Then
            item.cbENROL_FILE_CHECKED.Value = (item.cbENROL_FILE_CHECKEDCheckedValue.Value)
        Else
            item.cbENROL_FILE_CHECKED.Value = (item.cbENROL_FILE_CHECKEDUncheckedValue.Value)
        End If
        item.Hidden_COMM_CONTACT_TYPE_MULTI.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.UniqueID))
        item.Hidden_COMM_CONTACT_TYPE_MULTI.SetValue(STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value)
        If STUDENT_PROFILE1cbConfidentialDocuments.Checked Then
            item.cbConfidentialDocuments.Value = (item.cbConfidentialDocumentsCheckedValue.Value)
        Else
            item.cbConfidentialDocuments.Value = (item.cbConfidentialDocumentsUncheckedValue.Value)
        End If
        If STUDENT_PROFILE1cbRiskFactors.Checked Then
            item.cbRiskFactors.Value = (item.cbRiskFactorsCheckedValue.Value)
        Else
            item.cbRiskFactors.Value = (item.cbRiskFactorsUncheckedValue.Value)
        End If
        If Not IsNothing(STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI.SelectedItem) Then
            item.COMM_INTAKE_CONTACT_TYPE_MULTI.SetValue(STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI.SelectedItem.Value)
        Else
            item.COMM_INTAKE_CONTACT_TYPE_MULTI.Value = Nothing
        End If
        item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.CopyFrom(STUDENT_PROFILE1COMM_INTAKE_CONTACT_TYPE_MULTI.Items)
        item.SUPPORT_KEY_PROFESSIONAL_ROLE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_ROLE.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_ROLE.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_ROLE2.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_ROLE2.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_ROLE2.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE2"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_NAME3.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_NAME3.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_NAME3.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_NAME3"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_ROLE3.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_ROLE3.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_ROLE3.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_ROLE3"))
        End If
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3") Is Nothing Then
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.SetValue(STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3.Text)
        Else
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.SetValue(ControlCustomValues("STUDENT_PROFILE1SUPPORT_KEY_PROFESSIONAL_CONTACT3"))
        End If
        If STUDENT_PROFILE1SUPPORT_DOCS_YOUNG_ADULT1.Checked Then
            item.SUPPORT_DOCS_YOUNG_ADULT1.Value = (item.SUPPORT_DOCS_YOUNG_ADULT1CheckedValue.Value)
        Else
            item.SUPPORT_DOCS_YOUNG_ADULT1.Value = (item.SUPPORT_DOCS_YOUNG_ADULT1UncheckedValue.Value)
        End If
        If EnableValidation Then
            item.Validate(STUDENT_PROFILE1Data)
        End If
        STUDENT_PROFILE1Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_PROFILE1 LoadItemFromRequest method

'Record Form STUDENT_PROFILE1 GetRedirectUrl method @3-27A371B3

    Protected Function GetSTUDENT_PROFILE1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_PROFILE1 GetRedirectUrl method

'Record Form STUDENT_PROFILE1 ShowErrors method @3-E7481D71

    Protected Sub STUDENT_PROFILE1ShowErrors()
        STUDENT_PROFILE1error_BackgroundInfo.Text = ""
        STUDENT_PROFILE1error_ReasonsEnrol.Text = ""
        STUDENT_PROFILE1error_StudentWellbeing.Text = ""
        STUDENT_PROFILE1error_ReturnMainstream.Text = ""
        STUDENT_PROFILE1error_ReturningStudent.Text = ""
        STUDENT_PROFILE1error_StudentWellbeing2.Text = ""
        STUDENT_PROFILE1error_PrevPathways.Text = ""
        STUDENT_PROFILE1error_HobbiesInterests.Text = ""
        STUDENT_PROFILE1error_CommsVisit.Text = ""
        STUDENT_PROFILE1error_ContactType.Text = ""
        STUDENT_PROFILE1error_CarerContactMethod.Text = ""
        STUDENT_PROFILE1error_SupervisorRole.Text = ""
        STUDENT_PROFILE1error_AddCarerInfo.Text = ""
        STUDENT_PROFILE1error_Workspace.Text = ""
        STUDENT_PROFILE1error_OrgHardware.Text = ""
        STUDENT_PROFILE1error_OrgInternet.Text = ""
        STUDENT_PROFILE1error_OrgPrevSchools.Text = ""
        STUDENT_PROFILE1error_OrgAcademic.Text = ""
        STUDENT_PROFILE1error_LPDone.Text = ""
        STUDENT_PROFILE1error_LearnDetails.Text = ""
        STUDENT_PROFILE1error_LearnGoals.Text = ""
        STUDENT_PROFILE1error_SpecialProvision.Text = ""
        STUDENT_PROFILE1error_Goals.Text = ""
        STUDENT_PROFILE1error_GoalsMidyear.Text = ""
        STUDENT_PROFILE1error_WorkExp910.Text = ""
        STUDENT_PROFILE1error_PartTimeJobs.Text = ""
        STUDENT_PROFILE1error_EndYearDisc.Text = ""
        STUDENT_PROFILE1error_EndYearLogged.Text = ""
        STUDENT_PROFILE1error_ProgressSem1.Text = ""
        STUDENT_PROFILE1error_ProgressSem2.Text = ""
        STUDENT_PROFILE1error_AssessData.Text = ""
        STUDENT_PROFILE1error_KeyProfSupports.Text = ""
        STUDENT_PROFILE1error_SupportDocs.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_PROFILE1Errors.Count - 1
        Select Case STUDENT_PROFILE1Errors.AllKeys(i)
            Case "BACKGROUND_INFO"
                If STUDENT_PROFILE1error_BackgroundInfo.Text <> "" Then  STUDENT_PROFILE1error_BackgroundInfo.Text &= "<br>"
                STUDENT_PROFILE1error_BackgroundInfo.Text = STUDENT_PROFILE1error_BackgroundInfo.Text & STUDENT_PROFILE1Errors(i)
            Case "ENROL_REASONS"
                If STUDENT_PROFILE1error_ReasonsEnrol.Text <> "" Then  STUDENT_PROFILE1error_ReasonsEnrol.Text &= "<br>"
                STUDENT_PROFILE1error_ReasonsEnrol.Text = STUDENT_PROFILE1error_ReasonsEnrol.Text & STUDENT_PROFILE1Errors(i)
            Case "WELLBEING_INCLUSION_CONCERNS"
                If STUDENT_PROFILE1error_StudentWellbeing.Text <> "" Then  STUDENT_PROFILE1error_StudentWellbeing.Text &= "<br>"
                STUDENT_PROFILE1error_StudentWellbeing.Text = STUDENT_PROFILE1error_StudentWellbeing.Text & STUDENT_PROFILE1Errors(i)
            Case "EXPECT_RETURN_TO_SCHOOL"
                If STUDENT_PROFILE1error_ReturnMainstream.Text <> "" Then  STUDENT_PROFILE1error_ReturnMainstream.Text &= "<br>"
                STUDENT_PROFILE1error_ReturnMainstream.Text = STUDENT_PROFILE1error_ReturnMainstream.Text & STUDENT_PROFILE1Errors(i)
            Case "RETURN_STUDENT"
                If STUDENT_PROFILE1error_ReturningStudent.Text <> "" Then  STUDENT_PROFILE1error_ReturningStudent.Text &= "<br>"
                STUDENT_PROFILE1error_ReturningStudent.Text = STUDENT_PROFILE1error_ReturningStudent.Text & STUDENT_PROFILE1Errors(i)
            Case "KNOWN_WELLBEING"
                If STUDENT_PROFILE1error_StudentWellbeing2.Text <> "" Then  STUDENT_PROFILE1error_StudentWellbeing2.Text &= "<br>"
                STUDENT_PROFILE1error_StudentWellbeing2.Text = STUDENT_PROFILE1error_StudentWellbeing2.Text & STUDENT_PROFILE1Errors(i)
            Case "KNOWN_PATHWAYS"
                If STUDENT_PROFILE1error_PrevPathways.Text <> "" Then  STUDENT_PROFILE1error_PrevPathways.Text &= "<br>"
                STUDENT_PROFILE1error_PrevPathways.Text = STUDENT_PROFILE1error_PrevPathways.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_DOCS_AGENCY_REFERRAL"
                If STUDENT_PROFILE1error_SupportDocs.Text <> "" Then  STUDENT_PROFILE1error_SupportDocs.Text &= "<br>"
                STUDENT_PROFILE1error_SupportDocs.Text = STUDENT_PROFILE1error_SupportDocs.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_DOCS_SCHOOL_REFERRAL"
                If STUDENT_PROFILE1error_SupportDocs.Text <> "" Then  STUDENT_PROFILE1error_SupportDocs.Text &= "<br>"
                STUDENT_PROFILE1error_SupportDocs.Text = STUDENT_PROFILE1error_SupportDocs.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_DOCS_YOUNG_ADULT"
                If STUDENT_PROFILE1error_SupportDocs.Text <> "" Then  STUDENT_PROFILE1error_SupportDocs.Text &= "<br>"
                STUDENT_PROFILE1error_SupportDocs.Text = STUDENT_PROFILE1error_SupportDocs.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_DOCS_OTHER"
                If STUDENT_PROFILE1error_SupportDocs.Text <> "" Then  STUDENT_PROFILE1error_SupportDocs.Text &= "<br>"
                STUDENT_PROFILE1error_SupportDocs.Text = STUDENT_PROFILE1error_SupportDocs.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_NAME"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_CONTACT"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "ENGAGEMENT_HOBBIES_INTERESTS"
                If STUDENT_PROFILE1error_HobbiesInterests.Text <> "" Then  STUDENT_PROFILE1error_HobbiesInterests.Text &= "<br>"
                STUDENT_PROFILE1error_HobbiesInterests.Text = STUDENT_PROFILE1error_HobbiesInterests.Text & STUDENT_PROFILE1Errors(i)
            Case "COMM_VISIT_FLAG"
                If STUDENT_PROFILE1error_CommsVisit.Text <> "" Then  STUDENT_PROFILE1error_CommsVisit.Text &= "<br>"
                STUDENT_PROFILE1error_CommsVisit.Text = STUDENT_PROFILE1error_CommsVisit.Text & STUDENT_PROFILE1Errors(i)
            Case "COMM_VISIT_DATE"
                If STUDENT_PROFILE1error_CommsVisit.Text <> "" Then  STUDENT_PROFILE1error_CommsVisit.Text &= "<br>"
                STUDENT_PROFILE1error_CommsVisit.Text = STUDENT_PROFILE1error_CommsVisit.Text & STUDENT_PROFILE1Errors(i)
            Case "COMM_CONTACT_TYPE_OTHER"
                If STUDENT_PROFILE1error_ContactType.Text <> "" Then  STUDENT_PROFILE1error_ContactType.Text &= "<br>"
                STUDENT_PROFILE1error_ContactType.Text = STUDENT_PROFILE1error_ContactType.Text & STUDENT_PROFILE1Errors(i)
            Case "CARER_CONTACT_METHOD"
                If STUDENT_PROFILE1error_CarerContactMethod.Text <> "" Then  STUDENT_PROFILE1error_CarerContactMethod.Text &= "<br>"
                STUDENT_PROFILE1error_CarerContactMethod.Text = STUDENT_PROFILE1error_CarerContactMethod.Text & STUDENT_PROFILE1Errors(i)
            Case "CARER_SUPERVISOR_NAME"
                If STUDENT_PROFILE1error_CarerContactMethod.Text <> "" Then  STUDENT_PROFILE1error_CarerContactMethod.Text &= "<br>"
                STUDENT_PROFILE1error_CarerContactMethod.Text = STUDENT_PROFILE1error_CarerContactMethod.Text & STUDENT_PROFILE1Errors(i)
            Case "CARER_SUPERVISOR_ROLE"
                If STUDENT_PROFILE1error_SupervisorRole.Text <> "" Then  STUDENT_PROFILE1error_SupervisorRole.Text &= "<br>"
                STUDENT_PROFILE1error_SupervisorRole.Text = STUDENT_PROFILE1error_SupervisorRole.Text & STUDENT_PROFILE1Errors(i)
            Case "CARER_ADDITIONAL"
                If STUDENT_PROFILE1error_AddCarerInfo.Text <> "" Then  STUDENT_PROFILE1error_AddCarerInfo.Text &= "<br>"
                STUDENT_PROFILE1error_AddCarerInfo.Text = STUDENT_PROFILE1error_AddCarerInfo.Text & STUDENT_PROFILE1Errors(i)
            Case "ORGANISATION_WHENWHERE"
                If STUDENT_PROFILE1error_Workspace.Text <> "" Then  STUDENT_PROFILE1error_Workspace.Text &= "<br>"
                STUDENT_PROFILE1error_Workspace.Text = STUDENT_PROFILE1error_Workspace.Text & STUDENT_PROFILE1Errors(i)
            Case "ORGANISATION_HARDWARE"
                If STUDENT_PROFILE1error_OrgHardware.Text <> "" Then  STUDENT_PROFILE1error_OrgHardware.Text &= "<br>"
                STUDENT_PROFILE1error_OrgHardware.Text = STUDENT_PROFILE1error_OrgHardware.Text & STUDENT_PROFILE1Errors(i)
            Case "ORGANISATION_ACCESS_INTERNET"
                If STUDENT_PROFILE1error_OrgInternet.Text <> "" Then  STUDENT_PROFILE1error_OrgInternet.Text &= "<br>"
                STUDENT_PROFILE1error_OrgInternet.Text = STUDENT_PROFILE1error_OrgInternet.Text & STUDENT_PROFILE1Errors(i)
            Case "ORGANISATION_PREVIOUS_SCHOOL"
                If STUDENT_PROFILE1error_OrgPrevSchools.Text <> "" Then  STUDENT_PROFILE1error_OrgPrevSchools.Text &= "<br>"
                STUDENT_PROFILE1error_OrgPrevSchools.Text = STUDENT_PROFILE1error_OrgPrevSchools.Text & STUDENT_PROFILE1Errors(i)
            Case "ORGANISATION_ACADEMIC_HISTORY"
                If STUDENT_PROFILE1error_OrgAcademic.Text <> "" Then  STUDENT_PROFILE1error_OrgAcademic.Text &= "<br>"
                STUDENT_PROFILE1error_OrgAcademic.Text = STUDENT_PROFILE1error_OrgAcademic.Text & STUDENT_PROFILE1Errors(i)
            Case "LAUNCH_PAD_DONE"
                If STUDENT_PROFILE1error_LPDone.Text <> "" Then  STUDENT_PROFILE1error_LPDone.Text &= "<br>"
                STUDENT_PROFILE1error_LPDone.Text = STUDENT_PROFILE1error_LPDone.Text & STUDENT_PROFILE1Errors(i)
            Case "LAUNCH_PAD_DONE_DATE"
                If STUDENT_PROFILE1error_LPDone.Text <> "" Then  STUDENT_PROFILE1error_LPDone.Text &= "<br>"
                STUDENT_PROFILE1error_LPDone.Text = STUDENT_PROFILE1error_LPDone.Text & STUDENT_PROFILE1Errors(i)
            Case "LEARNING_PROGRAM_DETAILS"
                If STUDENT_PROFILE1error_LearnDetails.Text <> "" Then  STUDENT_PROFILE1error_LearnDetails.Text &= "<br>"
                STUDENT_PROFILE1error_LearnDetails.Text = STUDENT_PROFILE1error_LearnDetails.Text & STUDENT_PROFILE1Errors(i)
            Case "LEARNING_GOALS"
                If STUDENT_PROFILE1error_LearnGoals.Text <> "" Then  STUDENT_PROFILE1error_LearnGoals.Text &= "<br>"
                STUDENT_PROFILE1error_LearnGoals.Text = STUDENT_PROFILE1error_LearnGoals.Text & STUDENT_PROFILE1Errors(i)
            Case "SPECIAL_PROVISION_DETAILS"
                If STUDENT_PROFILE1error_SpecialProvision.Text <> "" Then  STUDENT_PROFILE1error_SpecialProvision.Text &= "<br>"
                STUDENT_PROFILE1error_SpecialProvision.Text = STUDENT_PROFILE1error_SpecialProvision.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_CAREER_GOALS"
                If STUDENT_PROFILE1error_Goals.Text <> "" Then  STUDENT_PROFILE1error_Goals.Text &= "<br>"
                STUDENT_PROFILE1error_Goals.Text = STUDENT_PROFILE1error_Goals.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_CAREER_GOALS_MIDYEAR"
                If STUDENT_PROFILE1error_GoalsMidyear.Text <> "" Then  STUDENT_PROFILE1error_GoalsMidyear.Text &= "<br>"
                STUDENT_PROFILE1error_GoalsMidyear.Text = STUDENT_PROFILE1error_GoalsMidyear.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"
                If STUDENT_PROFILE1error_GoalsMidyear.Text <> "" Then  STUDENT_PROFILE1error_GoalsMidyear.Text &= "<br>"
                STUDENT_PROFILE1error_GoalsMidyear.Text = STUDENT_PROFILE1error_GoalsMidyear.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_WORKEXP_FLAG"
                If STUDENT_PROFILE1error_WorkExp910.Text <> "" Then  STUDENT_PROFILE1error_WorkExp910.Text &= "<br>"
                STUDENT_PROFILE1error_WorkExp910.Text = STUDENT_PROFILE1error_WorkExp910.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_WORKEXP_DETAILS"
                If STUDENT_PROFILE1error_WorkExp910.Text <> "" Then  STUDENT_PROFILE1error_WorkExp910.Text &= "<br>"
                STUDENT_PROFILE1error_WorkExp910.Text = STUDENT_PROFILE1error_WorkExp910.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_PARTTIMEJOBS"
                If STUDENT_PROFILE1error_PartTimeJobs.Text <> "" Then  STUDENT_PROFILE1error_PartTimeJobs.Text &= "<br>"
                STUDENT_PROFILE1error_PartTimeJobs.Text = STUDENT_PROFILE1error_PartTimeJobs.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_ENDYEAR_INTENTIONS_FLAG"
                If STUDENT_PROFILE1error_EndYearDisc.Text <> "" Then  STUDENT_PROFILE1error_EndYearDisc.Text &= "<br>"
                STUDENT_PROFILE1error_EndYearDisc.Text = STUDENT_PROFILE1error_EndYearDisc.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_ENDYEAR_INTENTIONS_DATE"
                If STUDENT_PROFILE1error_EndYearDisc.Text <> "" Then  STUDENT_PROFILE1error_EndYearDisc.Text &= "<br>"
                STUDENT_PROFILE1error_EndYearDisc.Text = STUDENT_PROFILE1error_EndYearDisc.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"
                If STUDENT_PROFILE1error_EndYearLogged.Text <> "" Then  STUDENT_PROFILE1error_EndYearLogged.Text &= "<br>"
                STUDENT_PROFILE1error_EndYearLogged.Text = STUDENT_PROFILE1error_EndYearLogged.Text & STUDENT_PROFILE1Errors(i)
            Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"
                If STUDENT_PROFILE1error_EndYearLogged.Text <> "" Then  STUDENT_PROFILE1error_EndYearLogged.Text &= "<br>"
                STUDENT_PROFILE1error_EndYearLogged.Text = STUDENT_PROFILE1error_EndYearLogged.Text & STUDENT_PROFILE1Errors(i)
            Case "REVIEW_PROGRESS_END_SEM1"
                If STUDENT_PROFILE1error_ProgressSem1.Text <> "" Then  STUDENT_PROFILE1error_ProgressSem1.Text &= "<br>"
                STUDENT_PROFILE1error_ProgressSem1.Text = STUDENT_PROFILE1error_ProgressSem1.Text & STUDENT_PROFILE1Errors(i)
            Case "REVIEW_PROGRESS_END_SEM2"
                If STUDENT_PROFILE1error_ProgressSem2.Text <> "" Then  STUDENT_PROFILE1error_ProgressSem2.Text &= "<br>"
                STUDENT_PROFILE1error_ProgressSem2.Text = STUDENT_PROFILE1error_ProgressSem2.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_ENGLANG_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_ENGLANG_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_MATH_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_MATH_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_PATSCIENCE_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_PATSCIENCE_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_NAME2"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_CONTACT2"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_ROLE"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_ROLE2"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_NAME3"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_ROLE3"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_KEY_PROFESSIONAL_CONTACT3"
                If STUDENT_PROFILE1error_KeyProfSupports.Text <> "" Then  STUDENT_PROFILE1error_KeyProfSupports.Text &= "<br>"
                STUDENT_PROFILE1error_KeyProfSupports.Text = STUDENT_PROFILE1error_KeyProfSupports.Text & STUDENT_PROFILE1Errors(i)
            Case "SUPPORT_DOCS_YOUNG_ADULT1"
                If STUDENT_PROFILE1error_SupportDocs.Text <> "" Then  STUDENT_PROFILE1error_SupportDocs.Text &= "<br>"
                STUDENT_PROFILE1error_SupportDocs.Text = STUDENT_PROFILE1error_SupportDocs.Text & STUDENT_PROFILE1Errors(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_PROFILE1Errors(i)
        End Select
        Next i
        STUDENT_PROFILE1Error.Visible = True
        STUDENT_PROFILE1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_PROFILE1 ShowErrors method

'Record Form STUDENT_PROFILE1 Insert Operation @3-366E01D9

    Protected Sub STUDENT_PROFILE1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        Dim ExecuteFlag As Boolean = True
        STUDENT_PROFILE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_PROFILE1 Insert Operation

'Button Button_Insert OnClick. @5-3CEEB04E
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Insert" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @5-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Button Button_Insert1 OnClick. @85-E3C1CF40
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Insert1" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert1 OnClick.

'Button Button_Insert1 OnClick tail. @85-477CF3C9
        End If
'End Button Button_Insert1 OnClick tail.

'Button Button_Insert2 OnClick. @90-AA771A43
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Insert2" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert2 OnClick.

'Button Button_Insert2 OnClick tail. @90-477CF3C9
        End If
'End Button Button_Insert2 OnClick tail.

'Record STUDENT_PROFILE1 Event BeforeInsert. Action Retrieve Value for Control @103-D34DEBEE
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_PROFILE1 Event BeforeInsert. Action Retrieve Value for Control

'Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code @104-73254650
    ' -------------------------
     '15-Dec-2016|EA|string together the selected checkbox list items and store them
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = (checkItemsDis.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code

'Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code @212-73254650
    ' -------------------------
     '22-Mar-2018|EA|string together the selected checkbox list items and store them
    ' COMM_CONTACT_TYPE_MULTI
	checkItemsDis = "0,"

	For Each thisItemDis In STUDENT_PROFILE1COMM_CONTACT_TYPE.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value = (checkItemsDis.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code

'Record Form STUDENT_PROFILE1 BeforeInsert tail @3-DE5ECC82
    STUDENT_PROFILE1Parameters()
    STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
    If STUDENT_PROFILE1Operations.AllowInsert Then
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_PROFILE1Data.InsertItem(item)
            Catch ex As Exception
                STUDENT_PROFILE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_PROFILE1 BeforeInsert tail

'Record STUDENT_PROFILE1 Event AfterInsert. Action Custom Code @221-73254650
    ' -------------------------
    If (STUDENT_PROFILE1Errors.Count > 0 or ErrorFlag = True) Then
    	STUDENT_PROFILE1Errors.Add("STUDENT_PROFILE1","Check for errors! Scroll down page to check for errors! (eg: dates need full 4-digit years)")
    	HttpContext.Current.Session("notifymessage") = ""
    Else
    	HttpContext.Current.Session("notifymessage") = "Student Profile has been Added"
    End If
    ' -------------------------
'End Record STUDENT_PROFILE1 Event AfterInsert. Action Custom Code

'Record Form STUDENT_PROFILE1 AfterInsert tail  @3-4B48C80E
        End If
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 AfterInsert tail 

'Record Form STUDENT_PROFILE1 Update Operation @3-8FBAC437

    Protected Sub STUDENT_PROFILE1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_PROFILE1 Update Operation

'Button Button_Update OnClick. @6-B0DCA211
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Update" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Button Button_Update1 OnClick. @87-1899B137
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Update1" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update1 OnClick.

'Button Button_Update1 OnClick tail. @87-477CF3C9
        End If
'End Button Button_Update1 OnClick tail.

'Button Button_Update2 OnClick. @92-512F6434
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Update2" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update2 OnClick.

'Button Button_Update2 OnClick tail. @92-477CF3C9
        End If
'End Button Button_Update2 OnClick tail.

'Record STUDENT_PROFILE1 Event BeforeUpdate. Action Retrieve Value for Control @98-D34DEBEE
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_PROFILE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code @101-73254650
    ' -------------------------
    '15-Dec-2016|EA|string together the selected checkbox list items and store them
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = (checkItemsDis.TrimEnd(","C))

    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code

'Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code @213-73254650
    ' -------------------------
    '22-Mar-2018|EA|string together the selected checkbox list items and store them
    ' COMM_CONTACT_TYPE_MULTI
	checkItemsDis = "0,"

	For Each thisItemDis In STUDENT_PROFILE1COMM_CONTACT_TYPE.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value = (checkItemsDis.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_PROFILE1 Before Update tail @3-EB86AAF9
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
        If STUDENT_PROFILE1Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_PROFILE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_PROFILE1Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_PROFILE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_PROFILE1 Before Update tail

'Record STUDENT_PROFILE1 Event AfterUpdate. Action Custom Code @220-73254650
    ' -------------------------
    If (STUDENT_PROFILE1Errors.Count > 0 or ErrorFlag = True) Then
    	STUDENT_PROFILE1Errors.Add("STUDENT_PROFILE1","Check for errors! Scroll down page to check for errors! (eg: dates need full 4-digit years)")
    	HttpContext.Current.Session("notifymessage") = ""
    Else
    	HttpContext.Current.Session("notifymessage") = "Student Profile has been Updated"
    End If
     
    ' -------------------------
'End Record STUDENT_PROFILE1 Event AfterUpdate. Action Custom Code

'Record Form STUDENT_PROFILE1 Update Operation tail @3-4B48C80E
        End If
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 Update Operation tail

'Record Form STUDENT_PROFILE1 Delete Operation @3-342CBEA9
    Protected Sub STUDENT_PROFILE1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_PROFILE1 Delete Operation

'Record Form BeforeDelete tail @3-01F6ADAA
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-DF249C59
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_PROFILE1 Cancel Operation @3-E37D77E4

    Protected Sub STUDENT_PROFILE1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_PROFILE1LoadItemFromRequest(item, False)
'End Record Form STUDENT_PROFILE1 Cancel Operation

'Button Button_Cancel OnClick. @7-87226ED9
    If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Cancel" Then
        RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @7-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Button Button_Cancel1 OnClick. @89-EE3C3DEE
    If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Cancel1" Then
        RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
'End Button Button_Cancel1 OnClick.

'Button Button_Cancel1 OnClick tail. @89-477CF3C9
    End If
'End Button Button_Cancel1 OnClick tail.

'Button Button_Cancel2 OnClick. @94-8838E8DE
    If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Cancel2" Then
        RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
'End Button Button_Cancel2 OnClick.

'Button Button_Cancel2 OnClick tail. @94-477CF3C9
    End If
'End Button Button_Cancel2 OnClick tail.

'Record Form STUDENT_PROFILE1 Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_PROFILE1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-892E08E5
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_ProfileContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_PROFILE1Data = New STUDENT_PROFILE1DataProvider()
        STUDENT_PROFILE1Operations = New FormSupportedOperations(False, True, True, True, False)
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

