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

Namespace DECV_PROD2007.Menu 'Namespace @1-EEF91852

'Forms Definition @1-6B51C1CB
Public Class [MenuPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-87F21349
    Protected MenuSearchData As MenuSearchDataProvider
    Protected MenuSearchErrors As NameValueCollection = New NameValueCollection()
    Protected MenuSearchOperations As FormSupportedOperations
    Protected MenuSearchIsSubmitted As Boolean = False
    Protected MenuContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-7AD7A0FD
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.lblUserID.SetValue(session("UserLogin").ToUpper)
            item.link_EnrolNewStudentHref = "StudentEnrolment_InitialCheck.aspx"
            item.linkdespatch_1Href = "Despatch_AssignmentReceipt_simple.aspx"
            item.link_ModifyEnrolmentDetailsHref = "MaintainSearchRequest.aspx"
            item.linkdespatch_2Href = "Despatch_AssignmentReturn_simple.aspx"
            item.link_TeacgerAllocationsHref = "TeacherAllocations.aspx"
            item.link_SubjectWithdrawalsHref = "Subject_Withdrawals.aspx"
            item.link_StudentAmendmentsHref = "StudentAmendment.aspx"
            item.SCHOOL_listHref = "SCHOOL_list.aspx"
            item.ASSIGNMENT_linkHref = "ASSIGNMENT_list.aspx"
            item.COUNTRY_OF_BIRT_listHref = "COUNTRY_OF_BIRT_list.aspx"
            item.STAFF_listHref = "STAFF_list.aspx"
            item.CONTRIBUTION_listHref = "CONTRIBUTION_list.aspx"
            item.GOVERNMENT_ALLO_listHref = "GOVERNMENT_ALLO_list.aspx"
            item.Link5Href = "SUBJECT_list.aspx"
            item.ENROLMENT_CATEG_listHref = "ENROLMENT_CATEG_list.aspx"
            item.KEY_LEARNING_AR_listHref = "KEY_LEARNING_AR_list.aspx"
            item.PROGRESS_CODE_listHref = "PROGRESS_CODE_list.aspx"
            item.LANGUAGE_listHref = "LANGUAGE_list.aspx"
            item.REGION_listHref = "REGION_list.aspx"
            item.SCHOOL_TYPE_listHref = "SCHOOL_TYPE_list.aspx"
            item.TXN_CODE_listHref = "TXN_CODE_list.aspx"
            item.Link4Href = "Update_Utilities.aspx"
            item.WITHDRAWAL_REAS_listHref = "WITHDRAWAL_REAS_list.aspx"
            item.FTE_RULES_listHref = "FTE_RULES_list.aspx"
            item.WITHDRAWAL_EXIT_listHref = "WITHDRAWAL_EXIT_list.aspx"
            item.STAFF_STUDENT_SUPERVISORS_linkHref = "STAFF_STUDENT_SUPERVISORS.aspx"
            item.link_ManageStaffInductionsHref = "Staff_Inductions_ByCourse_list.aspx"
            item.lblSMTP_Server.SetValue(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
            item.MODULES_REF_linkHref = "REF_MODULE_CODES.aspx"
            item.COMMENT_TYPE_maintHref = "COMMENT_TYPE_maint.aspx"
            item.link_TeacherMyPastoralHref = "PastoralTeacher_StudentList.aspx"
            item.linkdespatch_3Href = "Despatch_UpdatebyYear.aspx"
            item.link_TeleformsEnrolmentsHref = "OnlineEnrolmentStatus.aspx"
            item.linkdespatch_4Href = "Despatch_UpdatebyEnrolDate.aspx"
            item.linkdespatch_5Href = "Despatch_AssignmentMaintain.aspx"
            item.link_VSREnrolmentsHref = "VSREnrolment.aspx"
            item.link_ModifyEnrolmentDetails_AddressSearchHref = "MaintainSearchRequest_Reception.aspx"
            item.link_TeacherMyClassListsHref = "Student_ClassList_Reports.aspx"
            item.link_ManageStaffInductions1Href = "Staff_Inductions_ByCourse_list.aspx"
            item.link_ViewStaffInductionsHref = "Staff_Inductions_ByStaff.aspx"
            item.linkdespatch_6Href = "Student_Exit_Track.aspx"
            item.lblUserLevel.SetValue(session("GroupID"))
            item.lblAccessGroups.SetValue(session("AccessGroups"))
            item.link_TeacherMyCommentSearchHref = "Student_Comments_Search.aspx"
            item.link_ManageSubjectTeacherAllocationsHref = "Subject_TeacherAllocations_maint.aspx"
            item.link_ManageAssignmentDescriptionsHref = "ASSIGNMENT_maint_multiple.aspx"
            item.link_GreenLettersHref = "Student_GreenLetters_maint.aspx"
            item.link_ManageSubjectTeacherCourseDevsHref = "Subject_CourseDev_maint.aspx"
            item.link_UnallocatedStudentTeachersHref = "StudentSubject_TeachersNotYetAllocated.aspx"
            item.link_SchoolEditHref = "SCHOOL_list.aspx"
            item.link_ManageSubjectTeacherCRTHref = "Subject_CRT_maint.aspx"
            item.Link_ManageLAdHref = "Staff_LAdAllocation_maint.aspx"
            item.link_TeacherMyDefaultingHref = "Student_SubjectStatus_Maintain.aspx"
            item.link_TeacherMyClassListsExtenderHref = "Student_ClassList_Extender.aspx"
            item.link_TimetableIntegrationHref = "TimetableIntegration.aspx"
            PageData.FillItem(item)
            lblUserID.Text = Server.HtmlEncode(item.lblUserID.GetFormattedValue()).Replace(vbCrLf,"<br>")
            lblHeadingEnrolment.Text = Server.HtmlEncode(item.lblHeadingEnrolment.GetFormattedValue()).Replace(vbCrLf,"<br>")
            lblHeadingDespatch.Text = Server.HtmlEncode(item.lblHeadingDespatch.GetFormattedValue()).Replace(vbCrLf,"<br>")
            link_EnrolNewStudent.InnerText += item.link_EnrolNewStudent.GetFormattedValue().Replace(vbCrLf,"")
            link_EnrolNewStudent.HRef = item.link_EnrolNewStudentHref+item.link_EnrolNewStudentHrefParameters.ToString("None","STUDENT_ID", ViewState)
            link_EnrolNewStudent.DataBind()
            linkdespatch_1.InnerText += item.linkdespatch_1.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_1.HRef = item.linkdespatch_1Href+item.linkdespatch_1HrefParameters.ToString("GET","", ViewState)
            linkdespatch_1.DataBind()
            link_ModifyEnrolmentDetails.InnerText += item.link_ModifyEnrolmentDetails.GetFormattedValue().Replace(vbCrLf,"")
            link_ModifyEnrolmentDetails.HRef = item.link_ModifyEnrolmentDetailsHref+item.link_ModifyEnrolmentDetailsHrefParameters.ToString("None","", ViewState)
            link_ModifyEnrolmentDetails.DataBind()
            linkdespatch_2.InnerText += item.linkdespatch_2.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_2.HRef = item.linkdespatch_2Href+item.linkdespatch_2HrefParameters.ToString("GET","", ViewState)
            linkdespatch_2.DataBind()
            lblHeadingTeachers.Text = Server.HtmlEncode(item.lblHeadingTeachers.GetFormattedValue()).Replace(vbCrLf,"<br>")
            link_TeacgerAllocations.InnerText += item.link_TeacgerAllocations.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacgerAllocations.HRef = item.link_TeacgerAllocationsHref+item.link_TeacgerAllocationsHrefParameters.ToString("None","", ViewState)
            link_TeacgerAllocations.DataBind()
            link_SubjectWithdrawals.InnerText += item.link_SubjectWithdrawals.GetFormattedValue().Replace(vbCrLf,"")
            link_SubjectWithdrawals.HRef = item.link_SubjectWithdrawalsHref+item.link_SubjectWithdrawalsHrefParameters.ToString("None","s_STUDENT_ID", ViewState)
            link_SubjectWithdrawals.DataBind()
            link_StudentAmendments.InnerText += item.link_StudentAmendments.GetFormattedValue().Replace(vbCrLf,"")
            link_StudentAmendments.HRef = item.link_StudentAmendmentsHref+item.link_StudentAmendmentsHrefParameters.ToString("None","", ViewState)
            link_StudentAmendments.DataBind()
            SCHOOL_list.InnerText += item.SCHOOL_list.GetFormattedValue().Replace(vbCrLf,"")
            SCHOOL_list.HRef = item.SCHOOL_listHref+item.SCHOOL_listHrefParameters.ToString("None","", ViewState)
            SCHOOL_list.DataBind()
            ASSIGNMENT_link.InnerText += item.ASSIGNMENT_link.GetFormattedValue().Replace(vbCrLf,"")
            ASSIGNMENT_link.HRef = item.ASSIGNMENT_linkHref+item.ASSIGNMENT_linkHrefParameters.ToString("None","", ViewState)
            ASSIGNMENT_link.DataBind()
            COUNTRY_OF_BIRT_list.InnerText += item.COUNTRY_OF_BIRT_list.GetFormattedValue().Replace(vbCrLf,"")
            COUNTRY_OF_BIRT_list.HRef = item.COUNTRY_OF_BIRT_listHref+item.COUNTRY_OF_BIRT_listHrefParameters.ToString("None","", ViewState)
            COUNTRY_OF_BIRT_list.DataBind()
            STAFF_list.InnerText += item.STAFF_list.GetFormattedValue().Replace(vbCrLf,"")
            STAFF_list.HRef = item.STAFF_listHref+item.STAFF_listHrefParameters.ToString("None","", ViewState)
            STAFF_list.DataBind()
            CONTRIBUTION_list.InnerText += item.CONTRIBUTION_list.GetFormattedValue().Replace(vbCrLf,"")
            CONTRIBUTION_list.HRef = item.CONTRIBUTION_listHref+item.CONTRIBUTION_listHrefParameters.ToString("None","", ViewState)
            CONTRIBUTION_list.DataBind()
            GOVERNMENT_ALLO_list.InnerText += item.GOVERNMENT_ALLO_list.GetFormattedValue().Replace(vbCrLf,"")
            GOVERNMENT_ALLO_list.HRef = item.GOVERNMENT_ALLO_listHref+item.GOVERNMENT_ALLO_listHrefParameters.ToString("None","", ViewState)
            GOVERNMENT_ALLO_list.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf,"")
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("GET","", ViewState)
            Link5.DataBind()
            ENROLMENT_CATEG_list.InnerText += item.ENROLMENT_CATEG_list.GetFormattedValue().Replace(vbCrLf,"")
            ENROLMENT_CATEG_list.HRef = item.ENROLMENT_CATEG_listHref+item.ENROLMENT_CATEG_listHrefParameters.ToString("None","", ViewState)
            ENROLMENT_CATEG_list.DataBind()
            KEY_LEARNING_AR_list.InnerText += item.KEY_LEARNING_AR_list.GetFormattedValue().Replace(vbCrLf,"")
            KEY_LEARNING_AR_list.HRef = item.KEY_LEARNING_AR_listHref+item.KEY_LEARNING_AR_listHrefParameters.ToString("None","", ViewState)
            KEY_LEARNING_AR_list.DataBind()
            PROGRESS_CODE_list.InnerText += item.PROGRESS_CODE_list.GetFormattedValue().Replace(vbCrLf,"")
            PROGRESS_CODE_list.HRef = item.PROGRESS_CODE_listHref+item.PROGRESS_CODE_listHrefParameters.ToString("None","", ViewState)
            PROGRESS_CODE_list.DataBind()
            LANGUAGE_list.InnerText += item.LANGUAGE_list.GetFormattedValue().Replace(vbCrLf,"")
            LANGUAGE_list.HRef = item.LANGUAGE_listHref+item.LANGUAGE_listHrefParameters.ToString("None","", ViewState)
            LANGUAGE_list.DataBind()
            REGION_list.InnerText += item.REGION_list.GetFormattedValue().Replace(vbCrLf,"")
            REGION_list.HRef = item.REGION_listHref+item.REGION_listHrefParameters.ToString("None","", ViewState)
            REGION_list.DataBind()
            SCHOOL_TYPE_list.InnerText += item.SCHOOL_TYPE_list.GetFormattedValue().Replace(vbCrLf,"")
            SCHOOL_TYPE_list.HRef = item.SCHOOL_TYPE_listHref+item.SCHOOL_TYPE_listHrefParameters.ToString("None","", ViewState)
            SCHOOL_TYPE_list.DataBind()
            TXN_CODE_list.InnerText += item.TXN_CODE_list.GetFormattedValue().Replace(vbCrLf,"")
            TXN_CODE_list.HRef = item.TXN_CODE_listHref+item.TXN_CODE_listHrefParameters.ToString("None","", ViewState)
            TXN_CODE_list.DataBind()
            Link4.InnerText += item.Link4.GetFormattedValue().Replace(vbCrLf,"")
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("GET","", ViewState)
            Link4.DataBind()
            WITHDRAWAL_REAS_list.InnerText += item.WITHDRAWAL_REAS_list.GetFormattedValue().Replace(vbCrLf,"")
            WITHDRAWAL_REAS_list.HRef = item.WITHDRAWAL_REAS_listHref+item.WITHDRAWAL_REAS_listHrefParameters.ToString("None","", ViewState)
            WITHDRAWAL_REAS_list.DataBind()
            lblLastLogin.Text = Server.HtmlEncode(item.lblLastLogin.GetFormattedValue()).Replace(vbCrLf,"<br>")
            FTE_RULES_list.InnerText += item.FTE_RULES_list.GetFormattedValue().Replace(vbCrLf,"")
            FTE_RULES_list.HRef = item.FTE_RULES_listHref+item.FTE_RULES_listHrefParameters.ToString("None","", ViewState)
            FTE_RULES_list.DataBind()
            WITHDRAWAL_EXIT_list.InnerText += item.WITHDRAWAL_EXIT_list.GetFormattedValue().Replace(vbCrLf,"")
            WITHDRAWAL_EXIT_list.HRef = item.WITHDRAWAL_EXIT_listHref+item.WITHDRAWAL_EXIT_listHrefParameters.ToString("None","", ViewState)
            WITHDRAWAL_EXIT_list.DataBind()
            STAFF_STUDENT_SUPERVISORS_link.InnerText += item.STAFF_STUDENT_SUPERVISORS_link.GetFormattedValue().Replace(vbCrLf,"")
            STAFF_STUDENT_SUPERVISORS_link.HRef = item.STAFF_STUDENT_SUPERVISORS_linkHref+item.STAFF_STUDENT_SUPERVISORS_linkHrefParameters.ToString("GET","", ViewState)
            STAFF_STUDENT_SUPERVISORS_link.DataBind()
            link_ManageStaffInductions.InnerText += item.link_ManageStaffInductions.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageStaffInductions.HRef = item.link_ManageStaffInductionsHref+item.link_ManageStaffInductionsHrefParameters.ToString("GET","", ViewState)
            link_ManageStaffInductions.DataBind()
            lblSMTP_Server.Text = Server.HtmlEncode(item.lblSMTP_Server.GetFormattedValue()).Replace(vbCrLf,"<br>")
            MODULES_REF_link.InnerText += item.MODULES_REF_link.GetFormattedValue().Replace(vbCrLf,"")
            MODULES_REF_link.HRef = item.MODULES_REF_linkHref+item.MODULES_REF_linkHrefParameters.ToString("GET","", ViewState)
            MODULES_REF_link.DataBind()
            COMMENT_TYPE_maint.InnerText += item.COMMENT_TYPE_maint.GetFormattedValue().Replace(vbCrLf,"")
            COMMENT_TYPE_maint.HRef = item.COMMENT_TYPE_maintHref+item.COMMENT_TYPE_maintHrefParameters.ToString("None","", ViewState)
            COMMENT_TYPE_maint.DataBind()
            link_TeacherMyPastoral.InnerText += item.link_TeacherMyPastoral.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacherMyPastoral.HRef = item.link_TeacherMyPastoralHref+item.link_TeacherMyPastoralHrefParameters.ToString("GET","", ViewState)
            link_TeacherMyPastoral.DataBind()
            linkdespatch_3.InnerText += item.linkdespatch_3.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_3.HRef = item.linkdespatch_3Href+item.linkdespatch_3HrefParameters.ToString("GET","s_YEAR_LEVEL", ViewState)
            linkdespatch_3.DataBind()
            link_TeleformsEnrolments.InnerText += item.link_TeleformsEnrolments.GetFormattedValue().Replace(vbCrLf,"")
            link_TeleformsEnrolments.HRef = item.link_TeleformsEnrolmentsHref+item.link_TeleformsEnrolmentsHrefParameters.ToString("None","", ViewState)
            link_TeleformsEnrolments.DataBind()
            linkdespatch_4.InnerText += item.linkdespatch_4.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_4.HRef = item.linkdespatch_4Href+item.linkdespatch_4HrefParameters.ToString("GET","s_YEAR_LEVEL", ViewState)
            linkdespatch_4.DataBind()
            linkdespatch_5.InnerText += item.linkdespatch_5.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_5.HRef = item.linkdespatch_5Href+item.linkdespatch_5HrefParameters.ToString("GET","s_YEAR_LEVEL", ViewState)
            linkdespatch_5.DataBind()
            link_VSREnrolments.InnerText += item.link_VSREnrolments.GetFormattedValue().Replace(vbCrLf,"")
            link_VSREnrolments.HRef = item.link_VSREnrolmentsHref+item.link_VSREnrolmentsHrefParameters.ToString("None","", ViewState)
            link_VSREnrolments.DataBind()
            link_ModifyEnrolmentDetails_AddressSearch.InnerText += item.link_ModifyEnrolmentDetails_AddressSearch.GetFormattedValue().Replace(vbCrLf,"")
            link_ModifyEnrolmentDetails_AddressSearch.HRef = item.link_ModifyEnrolmentDetails_AddressSearchHref+item.link_ModifyEnrolmentDetails_AddressSearchHrefParameters.ToString("None","", ViewState)
            link_ModifyEnrolmentDetails_AddressSearch.DataBind()
            link_TeacherMyClassLists.InnerText += item.link_TeacherMyClassLists.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacherMyClassLists.HRef = item.link_TeacherMyClassListsHref+item.link_TeacherMyClassListsHrefParameters.ToString("GET","", ViewState)
            link_TeacherMyClassLists.DataBind()
            link_ManageStaffInductions1.InnerText += item.link_ManageStaffInductions1.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageStaffInductions1.HRef = item.link_ManageStaffInductions1Href+item.link_ManageStaffInductions1HrefParameters.ToString("GET","", ViewState)
            link_ManageStaffInductions1.DataBind()
            link_ViewStaffInductions.InnerText += item.link_ViewStaffInductions.GetFormattedValue().Replace(vbCrLf,"")
            link_ViewStaffInductions.HRef = item.link_ViewStaffInductionsHref+item.link_ViewStaffInductionsHrefParameters.ToString("GET","", ViewState)
            link_ViewStaffInductions.DataBind()
            linkdespatch_6.InnerText += item.linkdespatch_6.GetFormattedValue().Replace(vbCrLf,"")
            linkdespatch_6.HRef = item.linkdespatch_6Href+item.linkdespatch_6HrefParameters.ToString("None","s_STUDENT_ID;s_ENROLMENT_YEAR", ViewState)
            linkdespatch_6.DataBind()
            lblUserLevel.Text = Server.HtmlEncode(item.lblUserLevel.GetFormattedValue()).Replace(vbCrLf,"<br>")
            lblAccessGroups.Text = Server.HtmlEncode(item.lblAccessGroups.GetFormattedValue()).Replace(vbCrLf,"<br>")
            link_TeacherMyCommentSearch.InnerText += item.link_TeacherMyCommentSearch.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacherMyCommentSearch.HRef = item.link_TeacherMyCommentSearchHref+item.link_TeacherMyCommentSearchHrefParameters.ToString("GET","", ViewState)
            link_TeacherMyCommentSearch.DataBind()
            link_ManageSubjectTeacherAllocations.InnerText += item.link_ManageSubjectTeacherAllocations.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageSubjectTeacherAllocations.HRef = item.link_ManageSubjectTeacherAllocationsHref+item.link_ManageSubjectTeacherAllocationsHrefParameters.ToString("GET","", ViewState)
            link_ManageSubjectTeacherAllocations.DataBind()
            link_ManageAssignmentDescriptions.InnerText += item.link_ManageAssignmentDescriptions.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageAssignmentDescriptions.HRef = item.link_ManageAssignmentDescriptionsHref+item.link_ManageAssignmentDescriptionsHrefParameters.ToString("GET","", ViewState)
            link_ManageAssignmentDescriptions.DataBind()
            lblHeadingCoords.Text = Server.HtmlEncode(item.lblHeadingCoords.GetFormattedValue()).Replace(vbCrLf,"<br>")
            link_GreenLetters.InnerText += item.link_GreenLetters.GetFormattedValue().Replace(vbCrLf,"")
            link_GreenLetters.HRef = item.link_GreenLettersHref+item.link_GreenLettersHrefParameters.ToString("None","", ViewState)
            link_GreenLetters.DataBind()
            link_ManageSubjectTeacherCourseDevs.InnerText += item.link_ManageSubjectTeacherCourseDevs.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageSubjectTeacherCourseDevs.HRef = item.link_ManageSubjectTeacherCourseDevsHref+item.link_ManageSubjectTeacherCourseDevsHrefParameters.ToString("GET","", ViewState)
            link_ManageSubjectTeacherCourseDevs.DataBind()
            link_UnallocatedStudentTeachers.InnerText += item.link_UnallocatedStudentTeachers.GetFormattedValue().Replace(vbCrLf,"")
            link_UnallocatedStudentTeachers.HRef = item.link_UnallocatedStudentTeachersHref+item.link_UnallocatedStudentTeachersHrefParameters.ToString("GET","", ViewState)
            link_UnallocatedStudentTeachers.DataBind()
            link_SchoolEdit.InnerText += item.link_SchoolEdit.GetFormattedValue().Replace(vbCrLf,"")
            link_SchoolEdit.HRef = item.link_SchoolEditHref+item.link_SchoolEditHrefParameters.ToString("None","", ViewState)
            link_SchoolEdit.DataBind()
            link_ManageSubjectTeacherCRT.InnerText += item.link_ManageSubjectTeacherCRT.GetFormattedValue().Replace(vbCrLf,"")
            link_ManageSubjectTeacherCRT.HRef = item.link_ManageSubjectTeacherCRTHref+item.link_ManageSubjectTeacherCRTHrefParameters.ToString("GET","", ViewState)
            link_ManageSubjectTeacherCRT.DataBind()
            Link_ManageLAd.InnerText += item.Link_ManageLAd.GetFormattedValue().Replace(vbCrLf,"")
            Link_ManageLAd.HRef = item.Link_ManageLAdHref+item.Link_ManageLAdHrefParameters.ToString("GET","", ViewState)
            Link_ManageLAd.DataBind()
            link_TeacherMyDefaulting.InnerText += item.link_TeacherMyDefaulting.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacherMyDefaulting.HRef = item.link_TeacherMyDefaultingHref+item.link_TeacherMyDefaultingHrefParameters.ToString("GET","", ViewState)
            link_TeacherMyDefaulting.DataBind()
            link_TeacherMyClassListsExtender.InnerText += item.link_TeacherMyClassListsExtender.GetFormattedValue().Replace(vbCrLf,"")
            link_TeacherMyClassListsExtender.HRef = item.link_TeacherMyClassListsExtenderHref+item.link_TeacherMyClassListsExtenderHrefParameters.ToString("GET","", ViewState)
            link_TeacherMyClassListsExtender.DataBind()
            link_TimetableIntegration.InnerText += item.link_TimetableIntegration.GetFormattedValue().Replace(vbCrLf,"")
            link_TimetableIntegration.HRef = item.link_TimetableIntegrationHref+item.link_TimetableIntegrationHrefParameters.ToString("None","", ViewState)
            link_TimetableIntegration.DataBind()
            MenuSearchShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Label lblLastLogin Event BeforeShow. Action Retrieve Value for Control @58-02F6D473
    If Not IsNothing(System.Web.HttpContext.Current.Request.Cookies("DECV_PROD2008Login")) Then
    lblLastLogin.Text = (New TextField("", System.Web.HttpContext.Current.Request.Cookies("DECV_PROD2008Login").Value)).GetFormattedValue()
    End If
'End Label lblLastLogin Event BeforeShow. Action Retrieve Value for Control

'Page Menu Event BeforeShow. Action Custom Code @51-73254650
    ' -------------------------
	' ERA: Collect this user's list of Access Groups and put into Session Var "AccessGroups"
	if Session("AccessGroups") = "" then
		Session("AccessGroups") = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("exec sps_GetUserAccessFunctions " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(session("UserID").ToString(), FieldType._Text, true))
	end if

	Dim GlobalERAFunc as new GlobalERA.GlobalERAClass()

    ' ERA: display the various links based on Security Groups (functions in Header file)
	' Add New enrolment
	link_EnrolNewStudent.visible = GlobalERAFunc.CheckUserAccessGroups("A", e)
	'link_TeleformsEnrolments.visible = ERAFunction_CheckUserAccessGroups("A", e)  ' LN: 7/11/2013 No longer required.
	link_TeleformsEnrolments.visible = link_EnrolNewStudent.visible	' 20-Oct-2016|EA| replaced Teleforms with Online enrolment
	' 2009/11/30 - Eric - added new Menu item for VSR enrolments
	link_VSREnrolments.visible = GlobalERAFunc.CheckUserAccessGroups("A", e)
	'9-Nov-2017|EA| add link to Schools updating for Enrolments Staff.
	link_SchoolEdit.visible = link_EnrolNewStudent.visible
	'30-Jan-2018|EA| also add LAd Allocations for Enrolments staff 
	link_ManageLAd.visible =  link_EnrolNewStudent.visible
	
	' check Despatch
	lblHeadingDespatch.visible = GlobalERAFunc.CheckUserAccessGroups("D", e)
	linkdespatch_1.visible = lblHeadingDespatch.visible
	linkdespatch_2.visible = lblHeadingDespatch.visible
	linkdespatch_3.visible = lblHeadingDespatch.visible
	linkdespatch_4.visible = lblHeadingDespatch.visible
	linkdespatch_5.visible = lblHeadingDespatch.visible		'5/Sept/2008|EA| added new function
	linkdespatch_6.visible = lblHeadingDespatch.visible		'14/Oct/2010|EA| added for Despatch to track exit interviews
				

	'Teacher Links
	link_TeacgerAllocations.visible = GlobalERAFunc.CheckUserAccessGroups("T", e) 
	link_SubjectWithdrawals.visible = GlobalERAFunc.CheckUserAccessGroups("S", e)
	link_StudentAmendments.visible = GlobalERAFunc.CheckUserAccessGroups("M", e)
	'8-May-2014|EA| added so DATA ENTRY OPERATORS/ENROLMENT OFFICERS/LEADING TEACHERS/SYSTEM users can adjust Assignment Descriptions, unfuddle #581
	' Deliberately left DESPATCH off list as they shouldn't need to be loaded with this, the Leading/Enrolment staff can do
	' and the Data Entry staff can enter as I suspect they will be
	link_ManageAssignmentDescriptions.Visible = GlobalERAFunc.CheckUserAccessGroups("S", e)
	
	'5-Sept-2008|EA| added to show 'My Pastoral Students'
	link_TeacherMyPastoral.visible = GlobalERAFunc.CheckUserAccessGroups("T", e)
	'Aug-2010|EA| added to show 'My Defaulting Students' - NOT LIVE AT 20-SEPT-2010
	'link_TeacherMyDefaulting.visible = ERAFunction_CheckUserAccessGroups("T", e)
	link_TeacherMyDefaulting.visible = false	'23-July-2015|EA| replaced with SMAP
	'Sept-2010|EA| added to show 'My Class Lists'
	link_TeacherMyClassLists.visible = link_TeacherMyDefaulting.visible
	'31-Oct-2011|EA| added to show 'My Comment Search'
	link_TeacherMyClassLists.visible = True					'21-August-2015|JD| added (should not be linked to mydefaulting menu item)
	'link_TeacherMyClassLists.visible = link_TeacherMyDefaulting.visible	'21-August-2015|JD| removed
	'linkreports1.visible = ERAFunction_CheckUserAccessGroups("R", e)	'8-April-2013|EA| removed
	' 21-June-2018|EA| added link for Extenders
	link_TeacherMyClassListsExtender.Visible = link_TeacherMyClassLists.visible

	linkdespatch_6.visible = GlobalERAFunc.CheckUserAccessGroups("M", e)	'18/Feb/2011|EA| added so Leading Teachers (esp. Carol Ford) can Maintain exit interviews. unfuddle #342

	' 24-Aug-2010|EA| added Contact search for Receiption/Despatch/Enrolments
	' 10-Sept-2010|EA| allow Address search for all users
	link_ModifyEnrolmentDetails_AddressSearch.visible = True	'(lblHeadingDespatch.visible) or (link_EnrolNewStudent.visible)
	'8-Oct-2010|EA| new for staff to view Inductions
	link_ViewStaffInductions.Visible = true
	' 11-Oct-2010|EA| for testing only - as some users cannot see entire Control Panel
	link_ManageStaffInductions1.visible = GlobalERAFunc.CheckUserAccessGroups("I", e)
	' 19-Dec-2011|EA| added link_ManageSubjectTeacherAllocations for Leading Teachers to have access to change Teacher allocations
	link_ManageSubjectTeacherAllocations.visible = GlobalERAFunc.CheckUserAccessGroups("S", e)
	' 1-2-2012|EA| added link to Unallocated Students, as same level as ManageSubjectTeacherAllocations
	link_UnallocatedStudentTeachers.visible = link_ManageSubjectTeacherAllocations.visible
	'9-Mar-2017|EA| added link to Manage CRT Teachers for subjects, like CourseDevs, as same level as ManageSubjectTeacherAllocations (#797)
	link_ManageSubjectTeacherCRT.visible = link_ManageSubjectTeacherAllocations.visible

	Panel_controltables.Visible = GlobalERAFunc.CheckUserAccessGroups("C", e)

	'16-Jan-2012|EA| so Teachers do not bulk-allocate, then disable this until start of March (allows 4-5 weeks)
	'11-Feb-2016|EA| changed per request to delay until 1 Feb
	if (DateTime.Now.Month < 2) then
		link_TeacgerAllocations.visible = False

		'6-Feb-2012|EA| but turn back on for Leading Teachers so they can use it. 
		' LN: 3/12/2013 Moved within condition so normal teacher privileges can also work.
		link_TeacgerAllocations.visible = link_ManageSubjectTeacherAllocations.visible
	end if

	' 09-Mar-2015|EA| new Green Letter management - intially for Coords (Supervisors) etc
	link_GreenLetters.visible = GlobalERAFunc.CheckUserAccessGroups("S", e)

	' 23-Nov-2016|LN| Allow Enrolments to edit Schools -removed by Eric as this was overriding the above setting, and 'E' is NOT a valid security function.
	'link_SchoolEdit.visible = GlobalERAFunc.CheckUserAccessGroups("E", e)

	'7-May-2015|EA| manage Course Development that is fed into Scaffold (new security_function 'L')
	link_ManageSubjectTeacherCourseDevs.visible = GlobalERAFunc.CheckUserAccessGroups("L", e)

	'12 Mar 2021|RW| Add the Timetable Integration option
	link_TimetableIntegration.Visible = link_ManageSubjectTeacherAllocations.Visible

    ' -------------------------
'End Page Menu Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'DEL      ' -------------------------
'DEL      '4-Mar-2011|EA| force the default button on the Submit
'DEL  	Form.DefaultButton = viewMaintainSearchRequestButton_DoSearch.UniqueID
'DEL      ' -------------------------

'Record Form MenuSearch Parameters @75-3109AE7E

    Protected Sub MenuSearchParameters()
        Dim item As new MenuSearchItem
        Try
        Catch e As Exception
            MenuSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form MenuSearch Parameters

'Record Form MenuSearch Show method @75-A7AC4277
    Protected Sub MenuSearchShow()
        If MenuSearchOperations.None Then
            MenuSearchHolder.Visible = False
            Return
        End If
        Dim item As MenuSearchItem = MenuSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not MenuSearchOperations.AllowRead
        MenuSearchErrors.Add(item.errors)
        If MenuSearchErrors.Count > 0 Then
            MenuSearchShowErrors()
            Return
        End If
'End Record Form MenuSearch Show method

'Record Form MenuSearch BeforeShow tail @75-8ADB0F1B
        MenuSearchParameters()
        MenuSearchData.FillItem(item, IsInsertMode)
        MenuSearchHolder.DataBind()
        MenuSearchSTUDENT_ID.Text=item.STUDENT_ID.GetFormattedValue()
        MenuSearchENROLMENT_YEAR.Text=item.ENROLMENT_YEAR.GetFormattedValue()
'End Record Form MenuSearch BeforeShow tail

'Record Form MenuSearch Show method tail @75-49930B2E
        If MenuSearchErrors.Count > 0 Then
            MenuSearchShowErrors()
        End If
    End Sub
'End Record Form MenuSearch Show method tail

'Record Form MenuSearch LoadItemFromRequest method @75-D267BC6B

    Protected Sub MenuSearchLoadItemFromRequest(item As MenuSearchItem, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(MenuSearchSTUDENT_ID.UniqueID))
        If ControlCustomValues("MenuSearchSTUDENT_ID") Is Nothing Then
            item.STUDENT_ID.SetValue(MenuSearchSTUDENT_ID.Text)
        Else
            item.STUDENT_ID.SetValue(ControlCustomValues("MenuSearchSTUDENT_ID"))
        End If
        Catch ae As ArgumentException
            MenuSearchErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Student ID"))
        End Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(MenuSearchENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("MenuSearchENROLMENT_YEAR") Is Nothing Then
            item.ENROLMENT_YEAR.SetValue(MenuSearchENROLMENT_YEAR.Text)
        Else
            item.ENROLMENT_YEAR.SetValue(ControlCustomValues("MenuSearchENROLMENT_YEAR"))
        End If
        If EnableValidation Then
            item.Validate(MenuSearchData)
        End If
        MenuSearchErrors.Add(item.errors)
    End Sub
'End Record Form MenuSearch LoadItemFromRequest method

'Record Form MenuSearch GetRedirectUrl method @75-86BBD54D

    Protected Function GetMenuSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentSummary.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form MenuSearch GetRedirectUrl method

'Record Form MenuSearch ShowErrors method @75-D2391B1F

    Protected Sub MenuSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To MenuSearchErrors.Count - 1
        Select Case MenuSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & MenuSearchErrors(i)
        End Select
        Next i
        MenuSearchError.Visible = True
        MenuSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form MenuSearch ShowErrors method

'Record Form MenuSearch Insert Operation @75-782EC53C

    Protected Sub MenuSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As MenuSearchItem = New MenuSearchItem()
        MenuSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form MenuSearch Insert Operation

'Record Form MenuSearch BeforeInsert tail @75-63B90257
    MenuSearchParameters()
    MenuSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form MenuSearch BeforeInsert tail

'Record Form MenuSearch AfterInsert tail  @75-BAAE13F5
        ErrorFlag=(MenuSearchErrors.Count > 0)
        If ErrorFlag Then
            MenuSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form MenuSearch AfterInsert tail 

'Record Form MenuSearch Update Operation @75-556AAEAA

    Protected Sub MenuSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As MenuSearchItem = New MenuSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        MenuSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form MenuSearch Update Operation

'Record Form MenuSearch Before Update tail @75-63B90257
        MenuSearchParameters()
        MenuSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form MenuSearch Before Update tail

'Record Form MenuSearch Update Operation tail @75-BAAE13F5
        ErrorFlag=(MenuSearchErrors.Count > 0)
        If ErrorFlag Then
            MenuSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form MenuSearch Update Operation tail

'Record Form MenuSearch Delete Operation @75-AC2D7659
    Protected Sub MenuSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        MenuSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As MenuSearchItem = New MenuSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form MenuSearch Delete Operation

'Record Form BeforeDelete tail @75-63B90257
        MenuSearchParameters()
        MenuSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @75-1E8AB45F
        If ErrorFlag Then
            MenuSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form MenuSearch Cancel Operation @75-93EECD22

    Protected Sub MenuSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As MenuSearchItem = New MenuSearchItem()
        MenuSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        MenuSearchLoadItemFromRequest(item, True)
'End Record Form MenuSearch Cancel Operation

'Record Form MenuSearch Cancel Operation tail @75-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form MenuSearch Cancel Operation tail

'Record Form MenuSearch Search Operation @75-864D2211
    Protected Sub MenuSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        MenuSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As MenuSearchItem = New MenuSearchItem()
        MenuSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form MenuSearch Search Operation

'Button Button_DoSearch OnClick. @76-5C0B7CD3
        If CType(sender,Control).ID = "MenuSearchButton_DoSearch" Then
            RedirectUrl = GetMenuSearchRedirectUrl("", "STUDENT_ID;ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @76-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form MenuSearch Search Operation tail @75-3D1B7059
        ErrorFlag = MenuSearchErrors.Count > 0
        If ErrorFlag Then
            MenuSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(MenuSearchSTUDENT_ID.Text <> "",("STUDENT_ID=" & Server.UrlEncode(MenuSearchSTUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(MenuSearchENROLMENT_YEAR.Text <> "",("ENROLMENT_YEAR=" & Server.UrlEncode(MenuSearchENROLMENT_YEAR.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form MenuSearch Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3114255B
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MenuContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        MenuSearchData = New MenuSearchDataProvider()
        MenuSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'Page Menu Event AfterInitialize. Action Custom Code @98-73254650
    ' -------------------------
      ' 9 Aug 2021|RW| Periodically refresh the user's permissions, for this main page only
      '                When using integrated Windows auth there's no longer the usual signing out and back in process to do this
      ' Some notes about the built-in CodeCharge session variables used to identify the user:
      ' DBUtility.UserId maps to Session("UserID"), which in turn is populated from the char(8) STAFF_ID field. This detail is important because that
      '   session variable will contain trailing spaces when the staff member's ID is less than 8 characters long. Within this application there are
      '   existing references and comparisons to DBUtility.UserId which may now rely on the trailing spaces to be present for equality. At this point it's
      '   safest to leave this side effect as-is. Instead of for example, mapping that variable to point to LOGIN_ID (a varchar(8) - no trailing spaces).
      ' DBUtility.UserLogin maps to Session("UserLogin"), which in turn is was previously set to the raw login text entered into the username field.
      ' Now, it's fed from the Windows login username.
      ' To see how those variables are populated, check out MembershipProvider.ValidateUser and also DataUtility.CheckUser, which is called during the above
      ' call to MyBase.OnInit(e) when the session variables time out.

      Dim signedInUserID = DBUtility.UserId?.ToString().Trim()
      Dim timeSinceLastAuthentication As TimeSpan
      If (TypeOf Session(Common.PermissionsLastRefreshTimeSessionID) Is Date) Then
         timeSinceLastAuthentication = (Date.Now - DirectCast(Session(Common.PermissionsLastRefreshTimeSessionID), Date))
      Else
         timeSinceLastAuthentication = TimeSpan.MaxValue
      End If
      If (User.Identity.IsAuthenticated AndAlso (signedInUserID IsNot Nothing) AndAlso
            (timeSinceLastAuthentication >= TimeSpan.FromMinutes(Common.PermissionsMaximumRefreshFrequencyMinutes))) Then
         Dim credentials = Common.GetStudentDatabaseUserCredentials(signedInUserID)
         If (credentials?.Status) Then
            ' Student database group and security functions
            Session(Common.GroupIDSessionID) = credentials.GroupID
            Session(Common.AccessGroupsSessionID) = credentials.SecurityFunctions

            ' Active Directory groups
            Dim securityGroups = Common.GetUserSecurityGroups(signedInUserID).Select(Function(group) group.SamAccountName).ToHashSet()
            Session(Common.ActiveDirectoryGroupsSessionID) = securityGroups

            Session(Common.PermissionsLastRefreshTimeSessionID) = Date.Now
         End If
      End If
    ' -------------------------
'End Page Menu Event AfterInitialize. Action Custom Code

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

