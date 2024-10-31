'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
'End Using Statements

Namespace DECV_PROD2007.Menu 'Namespace @1-EEF91852

'Page Data Class @1-224A09ED
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblUserID As TextField
    Public lblHeadingEnrolment As TextField
    Public lblHeadingDespatch As TextField
    Public link_EnrolNewStudent As TextField
    Public link_EnrolNewStudentHref As Object
    Public link_EnrolNewStudentHrefParameters As LinkParameterCollection
    Public linkdespatch_1 As TextField
    Public linkdespatch_1Href As Object
    Public linkdespatch_1HrefParameters As LinkParameterCollection
    Public link_ModifyEnrolmentDetails As TextField
    Public link_ModifyEnrolmentDetailsHref As Object
    Public link_ModifyEnrolmentDetailsHrefParameters As LinkParameterCollection
    Public linkdespatch_2 As TextField
    Public linkdespatch_2Href As Object
    Public linkdespatch_2HrefParameters As LinkParameterCollection
    Public lblHeadingTeachers As TextField
    Public link_TeacgerAllocations As TextField
    Public link_TeacgerAllocationsHref As Object
    Public link_TeacgerAllocationsHrefParameters As LinkParameterCollection
    Public link_SubjectWithdrawals As TextField
    Public link_SubjectWithdrawalsHref As Object
    Public link_SubjectWithdrawalsHrefParameters As LinkParameterCollection
    Public link_StudentAmendments As TextField
    Public link_StudentAmendmentsHref As Object
    Public link_StudentAmendmentsHrefParameters As LinkParameterCollection
    Public SCHOOL_list As TextField
    Public SCHOOL_listHref As Object
    Public SCHOOL_listHrefParameters As LinkParameterCollection
    Public ASSIGNMENT_link As TextField
    Public ASSIGNMENT_linkHref As Object
    Public ASSIGNMENT_linkHrefParameters As LinkParameterCollection
    Public COUNTRY_OF_BIRT_list As TextField
    Public COUNTRY_OF_BIRT_listHref As Object
    Public COUNTRY_OF_BIRT_listHrefParameters As LinkParameterCollection
    Public STAFF_list As TextField
    Public STAFF_listHref As Object
    Public STAFF_listHrefParameters As LinkParameterCollection
    Public CONTRIBUTION_list As TextField
    Public CONTRIBUTION_listHref As Object
    Public CONTRIBUTION_listHrefParameters As LinkParameterCollection
    Public GOVERNMENT_ALLO_list As TextField
    Public GOVERNMENT_ALLO_listHref As Object
    Public GOVERNMENT_ALLO_listHrefParameters As LinkParameterCollection
    Public Link5 As TextField
    Public Link5Href As Object
    Public Link5HrefParameters As LinkParameterCollection
    Public ENROLMENT_CATEG_list As TextField
    Public ENROLMENT_CATEG_listHref As Object
    Public ENROLMENT_CATEG_listHrefParameters As LinkParameterCollection
    Public KEY_LEARNING_AR_list As TextField
    Public KEY_LEARNING_AR_listHref As Object
    Public KEY_LEARNING_AR_listHrefParameters As LinkParameterCollection
    Public PROGRESS_CODE_list As TextField
    Public PROGRESS_CODE_listHref As Object
    Public PROGRESS_CODE_listHrefParameters As LinkParameterCollection
    Public LANGUAGE_list As TextField
    Public LANGUAGE_listHref As Object
    Public LANGUAGE_listHrefParameters As LinkParameterCollection
    Public REGION_list As TextField
    Public REGION_listHref As Object
    Public REGION_listHrefParameters As LinkParameterCollection
    Public SCHOOL_TYPE_list As TextField
    Public SCHOOL_TYPE_listHref As Object
    Public SCHOOL_TYPE_listHrefParameters As LinkParameterCollection
    Public TXN_CODE_list As TextField
    Public TXN_CODE_listHref As Object
    Public TXN_CODE_listHrefParameters As LinkParameterCollection
    Public Link4 As TextField
    Public Link4Href As Object
    Public Link4HrefParameters As LinkParameterCollection
    Public WITHDRAWAL_REAS_list As TextField
    Public WITHDRAWAL_REAS_listHref As Object
    Public WITHDRAWAL_REAS_listHrefParameters As LinkParameterCollection
    Public lblLastLogin As TextField
    Public FTE_RULES_list As TextField
    Public FTE_RULES_listHref As Object
    Public FTE_RULES_listHrefParameters As LinkParameterCollection
    Public WITHDRAWAL_EXIT_list As TextField
    Public WITHDRAWAL_EXIT_listHref As Object
    Public WITHDRAWAL_EXIT_listHrefParameters As LinkParameterCollection
    Public STAFF_STUDENT_SUPERVISORS_link As TextField
    Public STAFF_STUDENT_SUPERVISORS_linkHref As Object
    Public STAFF_STUDENT_SUPERVISORS_linkHrefParameters As LinkParameterCollection
    Public link_ManageStaffInductions As TextField
    Public link_ManageStaffInductionsHref As Object
    Public link_ManageStaffInductionsHrefParameters As LinkParameterCollection
    Public lblSMTP_Server As TextField
    Public MODULES_REF_link As TextField
    Public MODULES_REF_linkHref As Object
    Public MODULES_REF_linkHrefParameters As LinkParameterCollection
    Public COMMENT_TYPE_maint As TextField
    Public COMMENT_TYPE_maintHref As Object
    Public COMMENT_TYPE_maintHrefParameters As LinkParameterCollection
    Public link_TeacherMyPastoral As TextField
    Public link_TeacherMyPastoralHref As Object
    Public link_TeacherMyPastoralHrefParameters As LinkParameterCollection
    Public linkdespatch_3 As TextField
    Public linkdespatch_3Href As Object
    Public linkdespatch_3HrefParameters As LinkParameterCollection
    Public link_TeleformsEnrolments As TextField
    Public link_TeleformsEnrolmentsHref As Object
    Public link_TeleformsEnrolmentsHrefParameters As LinkParameterCollection
    Public linkdespatch_4 As TextField
    Public linkdespatch_4Href As Object
    Public linkdespatch_4HrefParameters As LinkParameterCollection
    Public linkdespatch_5 As TextField
    Public linkdespatch_5Href As Object
    Public linkdespatch_5HrefParameters As LinkParameterCollection
    Public link_VSREnrolments As TextField
    Public link_VSREnrolmentsHref As Object
    Public link_VSREnrolmentsHrefParameters As LinkParameterCollection
    Public link_ModifyEnrolmentDetails_AddressSearch As TextField
    Public link_ModifyEnrolmentDetails_AddressSearchHref As Object
    Public link_ModifyEnrolmentDetails_AddressSearchHrefParameters As LinkParameterCollection
    Public link_TeacherMyClassLists As TextField
    Public link_TeacherMyClassListsHref As Object
    Public link_TeacherMyClassListsHrefParameters As LinkParameterCollection
    Public link_ManageStaffInductions1 As TextField
    Public link_ManageStaffInductions1Href As Object
    Public link_ManageStaffInductions1HrefParameters As LinkParameterCollection
    Public link_ViewStaffInductions As TextField
    Public link_ViewStaffInductionsHref As Object
    Public link_ViewStaffInductionsHrefParameters As LinkParameterCollection
    Public linkdespatch_6 As TextField
    Public linkdespatch_6Href As Object
    Public linkdespatch_6HrefParameters As LinkParameterCollection
    Public lblUserLevel As TextField
    Public lblAccessGroups As TextField
    Public link_TeacherMyCommentSearch As TextField
    Public link_TeacherMyCommentSearchHref As Object
    Public link_TeacherMyCommentSearchHrefParameters As LinkParameterCollection
    Public link_ManageSubjectTeacherAllocations As TextField
    Public link_ManageSubjectTeacherAllocationsHref As Object
    Public link_ManageSubjectTeacherAllocationsHrefParameters As LinkParameterCollection
    Public link_ManageAssignmentDescriptions As TextField
    Public link_ManageAssignmentDescriptionsHref As Object
    Public link_ManageAssignmentDescriptionsHrefParameters As LinkParameterCollection
    Public lblHeadingCoords As TextField
    Public link_GreenLetters As TextField
    Public link_GreenLettersHref As Object
    Public link_GreenLettersHrefParameters As LinkParameterCollection
    Public link_ManageSubjectTeacherCourseDevs As TextField
    Public link_ManageSubjectTeacherCourseDevsHref As Object
    Public link_ManageSubjectTeacherCourseDevsHrefParameters As LinkParameterCollection
    Public link_UnallocatedStudentTeachers As TextField
    Public link_UnallocatedStudentTeachersHref As Object
    Public link_UnallocatedStudentTeachersHrefParameters As LinkParameterCollection
    Public link_SchoolEdit As TextField
    Public link_SchoolEditHref As Object
    Public link_SchoolEditHrefParameters As LinkParameterCollection
    Public link_ManageSubjectTeacherCRT As TextField
    Public link_ManageSubjectTeacherCRTHref As Object
    Public link_ManageSubjectTeacherCRTHrefParameters As LinkParameterCollection
    Public Link_ManageLAd As TextField
    Public Link_ManageLAdHref As Object
    Public Link_ManageLAdHrefParameters As LinkParameterCollection
    Public link_TeacherMyDefaulting As TextField
    Public link_TeacherMyDefaultingHref As Object
    Public link_TeacherMyDefaultingHrefParameters As LinkParameterCollection
    Public link_TeacherMyClassListsExtender As TextField
    Public link_TeacherMyClassListsExtenderHref As Object
    Public link_TeacherMyClassListsExtenderHrefParameters As LinkParameterCollection
    Public link_TimetableIntegration As TextField
    Public link_TimetableIntegrationHref As Object
    Public link_TimetableIntegrationHrefParameters As LinkParameterCollection
    Public Sub New()
        lblUserID = New TextField("", Nothing)
        lblHeadingEnrolment = New TextField("", "Enrolment Details")
        lblHeadingDespatch = New TextField("", "Despatch")
        link_EnrolNewStudent = New TextField("",Nothing)
        link_EnrolNewStudentHrefParameters = New LinkParameterCollection()
        linkdespatch_1 = New TextField("",Nothing)
        linkdespatch_1HrefParameters = New LinkParameterCollection()
        link_ModifyEnrolmentDetails = New TextField("",Nothing)
        link_ModifyEnrolmentDetailsHrefParameters = New LinkParameterCollection()
        linkdespatch_2 = New TextField("",Nothing)
        linkdespatch_2HrefParameters = New LinkParameterCollection()
        lblHeadingTeachers = New TextField("", "Teachers")
        link_TeacgerAllocations = New TextField("",Nothing)
        link_TeacgerAllocationsHrefParameters = New LinkParameterCollection()
        link_SubjectWithdrawals = New TextField("",Nothing)
        link_SubjectWithdrawalsHrefParameters = New LinkParameterCollection()
        link_StudentAmendments = New TextField("",Nothing)
        link_StudentAmendmentsHrefParameters = New LinkParameterCollection()
        SCHOOL_list = New TextField("",Nothing)
        SCHOOL_listHrefParameters = New LinkParameterCollection()
        ASSIGNMENT_link = New TextField("",Nothing)
        ASSIGNMENT_linkHrefParameters = New LinkParameterCollection()
        COUNTRY_OF_BIRT_list = New TextField("",Nothing)
        COUNTRY_OF_BIRT_listHrefParameters = New LinkParameterCollection()
        STAFF_list = New TextField("",Nothing)
        STAFF_listHrefParameters = New LinkParameterCollection()
        CONTRIBUTION_list = New TextField("",Nothing)
        CONTRIBUTION_listHrefParameters = New LinkParameterCollection()
        GOVERNMENT_ALLO_list = New TextField("",Nothing)
        GOVERNMENT_ALLO_listHrefParameters = New LinkParameterCollection()
        Link5 = New TextField("",Nothing)
        Link5HrefParameters = New LinkParameterCollection()
        ENROLMENT_CATEG_list = New TextField("",Nothing)
        ENROLMENT_CATEG_listHrefParameters = New LinkParameterCollection()
        KEY_LEARNING_AR_list = New TextField("",Nothing)
        KEY_LEARNING_AR_listHrefParameters = New LinkParameterCollection()
        PROGRESS_CODE_list = New TextField("",Nothing)
        PROGRESS_CODE_listHrefParameters = New LinkParameterCollection()
        LANGUAGE_list = New TextField("",Nothing)
        LANGUAGE_listHrefParameters = New LinkParameterCollection()
        REGION_list = New TextField("",Nothing)
        REGION_listHrefParameters = New LinkParameterCollection()
        SCHOOL_TYPE_list = New TextField("",Nothing)
        SCHOOL_TYPE_listHrefParameters = New LinkParameterCollection()
        TXN_CODE_list = New TextField("",Nothing)
        TXN_CODE_listHrefParameters = New LinkParameterCollection()
        Link4 = New TextField("",Nothing)
        Link4HrefParameters = New LinkParameterCollection()
        WITHDRAWAL_REAS_list = New TextField("",Nothing)
        WITHDRAWAL_REAS_listHrefParameters = New LinkParameterCollection()
        lblLastLogin = New TextField("", Nothing)
        FTE_RULES_list = New TextField("",Nothing)
        FTE_RULES_listHrefParameters = New LinkParameterCollection()
        WITHDRAWAL_EXIT_list = New TextField("",Nothing)
        WITHDRAWAL_EXIT_listHrefParameters = New LinkParameterCollection()
        STAFF_STUDENT_SUPERVISORS_link = New TextField("",Nothing)
        STAFF_STUDENT_SUPERVISORS_linkHrefParameters = New LinkParameterCollection()
        link_ManageStaffInductions = New TextField("",Nothing)
        link_ManageStaffInductionsHrefParameters = New LinkParameterCollection()
        lblSMTP_Server = New TextField("", "none")
        MODULES_REF_link = New TextField("",Nothing)
        MODULES_REF_linkHrefParameters = New LinkParameterCollection()
        COMMENT_TYPE_maint = New TextField("",Nothing)
        COMMENT_TYPE_maintHrefParameters = New LinkParameterCollection()
        link_TeacherMyPastoral = New TextField("",Nothing)
        link_TeacherMyPastoralHrefParameters = New LinkParameterCollection()
        linkdespatch_3 = New TextField("",Nothing)
        linkdespatch_3HrefParameters = New LinkParameterCollection()
        link_TeleformsEnrolments = New TextField("",Nothing)
        link_TeleformsEnrolmentsHrefParameters = New LinkParameterCollection()
        linkdespatch_4 = New TextField("",Nothing)
        linkdespatch_4HrefParameters = New LinkParameterCollection()
        linkdespatch_5 = New TextField("",Nothing)
        linkdespatch_5HrefParameters = New LinkParameterCollection()
        link_VSREnrolments = New TextField("",Nothing)
        link_VSREnrolmentsHrefParameters = New LinkParameterCollection()
        link_ModifyEnrolmentDetails_AddressSearch = New TextField("",Nothing)
        link_ModifyEnrolmentDetails_AddressSearchHrefParameters = New LinkParameterCollection()
        link_TeacherMyClassLists = New TextField("",Nothing)
        link_TeacherMyClassListsHrefParameters = New LinkParameterCollection()
        link_ManageStaffInductions1 = New TextField("",Nothing)
        link_ManageStaffInductions1HrefParameters = New LinkParameterCollection()
        link_ViewStaffInductions = New TextField("",Nothing)
        link_ViewStaffInductionsHrefParameters = New LinkParameterCollection()
        linkdespatch_6 = New TextField("",Nothing)
        linkdespatch_6HrefParameters = New LinkParameterCollection()
        lblUserLevel = New TextField("", Nothing)
        lblAccessGroups = New TextField("", Nothing)
        link_TeacherMyCommentSearch = New TextField("",Nothing)
        link_TeacherMyCommentSearchHrefParameters = New LinkParameterCollection()
        link_ManageSubjectTeacherAllocations = New TextField("",Nothing)
        link_ManageSubjectTeacherAllocationsHrefParameters = New LinkParameterCollection()
        link_ManageAssignmentDescriptions = New TextField("",Nothing)
        link_ManageAssignmentDescriptionsHrefParameters = New LinkParameterCollection()
        lblHeadingCoords = New TextField("", "Coordinators")
        link_GreenLetters = New TextField("",Nothing)
        link_GreenLettersHrefParameters = New LinkParameterCollection()
        link_ManageSubjectTeacherCourseDevs = New TextField("",Nothing)
        link_ManageSubjectTeacherCourseDevsHrefParameters = New LinkParameterCollection()
        link_UnallocatedStudentTeachers = New TextField("",Nothing)
        link_UnallocatedStudentTeachersHrefParameters = New LinkParameterCollection()
        link_SchoolEdit = New TextField("",Nothing)
        link_SchoolEditHrefParameters = New LinkParameterCollection()
        link_ManageSubjectTeacherCRT = New TextField("",Nothing)
        link_ManageSubjectTeacherCRTHrefParameters = New LinkParameterCollection()
        Link_ManageLAd = New TextField("",Nothing)
        Link_ManageLAdHrefParameters = New LinkParameterCollection()
        link_TeacherMyDefaulting = New TextField("",Nothing)
        link_TeacherMyDefaultingHrefParameters = New LinkParameterCollection()
        link_TeacherMyClassListsExtender = New TextField("",Nothing)
        link_TeacherMyClassListsExtenderHrefParameters = New LinkParameterCollection()
        link_TimetableIntegration = New TextField("",Nothing)
        link_TimetableIntegrationHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.lblUserID.SetValue(DBUtility.GetInitialValue("lblUserID"))
        item.lblHeadingEnrolment.SetValue(DBUtility.GetInitialValue("lblHeadingEnrolment"))
        item.lblHeadingDespatch.SetValue(DBUtility.GetInitialValue("lblHeadingDespatch"))
        item.link_EnrolNewStudent.SetValue(DBUtility.GetInitialValue("link_EnrolNewStudent"))
        item.linkdespatch_1.SetValue(DBUtility.GetInitialValue("linkdespatch_1"))
        item.link_ModifyEnrolmentDetails.SetValue(DBUtility.GetInitialValue("link_ModifyEnrolmentDetails"))
        item.linkdespatch_2.SetValue(DBUtility.GetInitialValue("linkdespatch_2"))
        item.lblHeadingTeachers.SetValue(DBUtility.GetInitialValue("lblHeadingTeachers"))
        item.link_TeacgerAllocations.SetValue(DBUtility.GetInitialValue("link_TeacgerAllocations"))
        item.link_SubjectWithdrawals.SetValue(DBUtility.GetInitialValue("link_SubjectWithdrawals"))
        item.link_StudentAmendments.SetValue(DBUtility.GetInitialValue("link_StudentAmendments"))
        item.SCHOOL_list.SetValue(DBUtility.GetInitialValue("SCHOOL_list"))
        item.ASSIGNMENT_link.SetValue(DBUtility.GetInitialValue("ASSIGNMENT_link"))
        item.COUNTRY_OF_BIRT_list.SetValue(DBUtility.GetInitialValue("COUNTRY_OF_BIRT_list"))
        item.STAFF_list.SetValue(DBUtility.GetInitialValue("STAFF_list"))
        item.CONTRIBUTION_list.SetValue(DBUtility.GetInitialValue("CONTRIBUTION_list"))
        item.GOVERNMENT_ALLO_list.SetValue(DBUtility.GetInitialValue("GOVERNMENT_ALLO_list"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        item.ENROLMENT_CATEG_list.SetValue(DBUtility.GetInitialValue("ENROLMENT_CATEG_list"))
        item.KEY_LEARNING_AR_list.SetValue(DBUtility.GetInitialValue("KEY_LEARNING_AR_list"))
        item.PROGRESS_CODE_list.SetValue(DBUtility.GetInitialValue("PROGRESS_CODE_list"))
        item.LANGUAGE_list.SetValue(DBUtility.GetInitialValue("LANGUAGE_list"))
        item.REGION_list.SetValue(DBUtility.GetInitialValue("REGION_list"))
        item.SCHOOL_TYPE_list.SetValue(DBUtility.GetInitialValue("SCHOOL_TYPE_list"))
        item.TXN_CODE_list.SetValue(DBUtility.GetInitialValue("TXN_CODE_list"))
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"))
        item.WITHDRAWAL_REAS_list.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REAS_list"))
        item.lblLastLogin.SetValue(DBUtility.GetInitialValue("lblLastLogin"))
        item.FTE_RULES_list.SetValue(DBUtility.GetInitialValue("FTE_RULES_list"))
        item.WITHDRAWAL_EXIT_list.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_EXIT_list"))
        item.STAFF_STUDENT_SUPERVISORS_link.SetValue(DBUtility.GetInitialValue("STAFF_STUDENT_SUPERVISORS_link"))
        item.link_ManageStaffInductions.SetValue(DBUtility.GetInitialValue("link_ManageStaffInductions"))
        item.lblSMTP_Server.SetValue(DBUtility.GetInitialValue("lblSMTP_Server"))
        item.MODULES_REF_link.SetValue(DBUtility.GetInitialValue("MODULES_REF_link"))
        item.COMMENT_TYPE_maint.SetValue(DBUtility.GetInitialValue("COMMENT_TYPE_maint"))
        item.link_TeacherMyPastoral.SetValue(DBUtility.GetInitialValue("link_TeacherMyPastoral"))
        item.linkdespatch_3.SetValue(DBUtility.GetInitialValue("linkdespatch_3"))
        item.link_TeleformsEnrolments.SetValue(DBUtility.GetInitialValue("link_TeleformsEnrolments"))
        item.linkdespatch_4.SetValue(DBUtility.GetInitialValue("linkdespatch_4"))
        item.linkdespatch_5.SetValue(DBUtility.GetInitialValue("linkdespatch_5"))
        item.link_VSREnrolments.SetValue(DBUtility.GetInitialValue("link_VSREnrolments"))
        item.link_ModifyEnrolmentDetails_AddressSearch.SetValue(DBUtility.GetInitialValue("link_ModifyEnrolmentDetails_AddressSearch"))
        item.link_TeacherMyClassLists.SetValue(DBUtility.GetInitialValue("link_TeacherMyClassLists"))
        item.link_ManageStaffInductions1.SetValue(DBUtility.GetInitialValue("link_ManageStaffInductions1"))
        item.link_ViewStaffInductions.SetValue(DBUtility.GetInitialValue("link_ViewStaffInductions"))
        item.linkdespatch_6.SetValue(DBUtility.GetInitialValue("linkdespatch_6"))
        item.lblUserLevel.SetValue(DBUtility.GetInitialValue("lblUserLevel"))
        item.lblAccessGroups.SetValue(DBUtility.GetInitialValue("lblAccessGroups"))
        item.link_TeacherMyCommentSearch.SetValue(DBUtility.GetInitialValue("link_TeacherMyCommentSearch"))
        item.link_ManageSubjectTeacherAllocations.SetValue(DBUtility.GetInitialValue("link_ManageSubjectTeacherAllocations"))
        item.link_ManageAssignmentDescriptions.SetValue(DBUtility.GetInitialValue("link_ManageAssignmentDescriptions"))
        item.lblHeadingCoords.SetValue(DBUtility.GetInitialValue("lblHeadingCoords"))
        item.link_GreenLetters.SetValue(DBUtility.GetInitialValue("link_GreenLetters"))
        item.link_ManageSubjectTeacherCourseDevs.SetValue(DBUtility.GetInitialValue("link_ManageSubjectTeacherCourseDevs"))
        item.link_UnallocatedStudentTeachers.SetValue(DBUtility.GetInitialValue("link_UnallocatedStudentTeachers"))
        item.link_SchoolEdit.SetValue(DBUtility.GetInitialValue("link_SchoolEdit"))
        item.link_ManageSubjectTeacherCRT.SetValue(DBUtility.GetInitialValue("link_ManageSubjectTeacherCRT"))
        item.Link_ManageLAd.SetValue(DBUtility.GetInitialValue("Link_ManageLAd"))
        item.link_TeacherMyDefaulting.SetValue(DBUtility.GetInitialValue("link_TeacherMyDefaulting"))
        item.link_TeacherMyClassListsExtender.SetValue(DBUtility.GetInitialValue("link_TeacherMyClassListsExtender"))
        item.link_TimetableIntegration.SetValue(DBUtility.GetInitialValue("link_TimetableIntegration"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblUserID"
                    Return lblUserID
                Case "lblHeadingEnrolment"
                    Return lblHeadingEnrolment
                Case "lblHeadingDespatch"
                    Return lblHeadingDespatch
                Case "link_EnrolNewStudent"
                    Return link_EnrolNewStudent
                Case "linkdespatch_1"
                    Return linkdespatch_1
                Case "link_ModifyEnrolmentDetails"
                    Return link_ModifyEnrolmentDetails
                Case "linkdespatch_2"
                    Return linkdespatch_2
                Case "lblHeadingTeachers"
                    Return lblHeadingTeachers
                Case "link_TeacgerAllocations"
                    Return link_TeacgerAllocations
                Case "link_SubjectWithdrawals"
                    Return link_SubjectWithdrawals
                Case "link_StudentAmendments"
                    Return link_StudentAmendments
                Case "SCHOOL_list"
                    Return SCHOOL_list
                Case "ASSIGNMENT_link"
                    Return ASSIGNMENT_link
                Case "COUNTRY_OF_BIRT_list"
                    Return COUNTRY_OF_BIRT_list
                Case "STAFF_list"
                    Return STAFF_list
                Case "CONTRIBUTION_list"
                    Return CONTRIBUTION_list
                Case "GOVERNMENT_ALLO_list"
                    Return GOVERNMENT_ALLO_list
                Case "Link5"
                    Return Link5
                Case "ENROLMENT_CATEG_list"
                    Return ENROLMENT_CATEG_list
                Case "KEY_LEARNING_AR_list"
                    Return KEY_LEARNING_AR_list
                Case "PROGRESS_CODE_list"
                    Return PROGRESS_CODE_list
                Case "LANGUAGE_list"
                    Return LANGUAGE_list
                Case "REGION_list"
                    Return REGION_list
                Case "SCHOOL_TYPE_list"
                    Return SCHOOL_TYPE_list
                Case "TXN_CODE_list"
                    Return TXN_CODE_list
                Case "Link4"
                    Return Link4
                Case "WITHDRAWAL_REAS_list"
                    Return WITHDRAWAL_REAS_list
                Case "lblLastLogin"
                    Return lblLastLogin
                Case "FTE_RULES_list"
                    Return FTE_RULES_list
                Case "WITHDRAWAL_EXIT_list"
                    Return WITHDRAWAL_EXIT_list
                Case "STAFF_STUDENT_SUPERVISORS_link"
                    Return STAFF_STUDENT_SUPERVISORS_link
                Case "link_ManageStaffInductions"
                    Return link_ManageStaffInductions
                Case "lblSMTP_Server"
                    Return lblSMTP_Server
                Case "MODULES_REF_link"
                    Return MODULES_REF_link
                Case "COMMENT_TYPE_maint"
                    Return COMMENT_TYPE_maint
                Case "link_TeacherMyPastoral"
                    Return link_TeacherMyPastoral
                Case "linkdespatch_3"
                    Return linkdespatch_3
                Case "link_TeleformsEnrolments"
                    Return link_TeleformsEnrolments
                Case "linkdespatch_4"
                    Return linkdespatch_4
                Case "linkdespatch_5"
                    Return linkdespatch_5
                Case "link_VSREnrolments"
                    Return link_VSREnrolments
                Case "link_ModifyEnrolmentDetails_AddressSearch"
                    Return link_ModifyEnrolmentDetails_AddressSearch
                Case "link_TeacherMyClassLists"
                    Return link_TeacherMyClassLists
                Case "link_ManageStaffInductions1"
                    Return link_ManageStaffInductions1
                Case "link_ViewStaffInductions"
                    Return link_ViewStaffInductions
                Case "linkdespatch_6"
                    Return linkdespatch_6
                Case "lblUserLevel"
                    Return lblUserLevel
                Case "lblAccessGroups"
                    Return lblAccessGroups
                Case "link_TeacherMyCommentSearch"
                    Return link_TeacherMyCommentSearch
                Case "link_ManageSubjectTeacherAllocations"
                    Return link_ManageSubjectTeacherAllocations
                Case "link_ManageAssignmentDescriptions"
                    Return link_ManageAssignmentDescriptions
                Case "lblHeadingCoords"
                    Return lblHeadingCoords
                Case "link_GreenLetters"
                    Return link_GreenLetters
                Case "link_ManageSubjectTeacherCourseDevs"
                    Return link_ManageSubjectTeacherCourseDevs
                Case "link_UnallocatedStudentTeachers"
                    Return link_UnallocatedStudentTeachers
                Case "link_SchoolEdit"
                    Return link_SchoolEdit
                Case "link_ManageSubjectTeacherCRT"
                    Return link_ManageSubjectTeacherCRT
                Case "Link_ManageLAd"
                    Return Link_ManageLAd
                Case "link_TeacherMyDefaulting"
                    Return link_TeacherMyDefaulting
                Case "link_TeacherMyClassListsExtender"
                    Return link_TeacherMyClassListsExtender
                Case "link_TimetableIntegration"
                    Return link_TimetableIntegration
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblUserID"
                    lblUserID = CType(value, TextField)
                Case "lblHeadingEnrolment"
                    lblHeadingEnrolment = CType(value, TextField)
                Case "lblHeadingDespatch"
                    lblHeadingDespatch = CType(value, TextField)
                Case "link_EnrolNewStudent"
                    link_EnrolNewStudent = CType(value, TextField)
                Case "linkdespatch_1"
                    linkdespatch_1 = CType(value, TextField)
                Case "link_ModifyEnrolmentDetails"
                    link_ModifyEnrolmentDetails = CType(value, TextField)
                Case "linkdespatch_2"
                    linkdespatch_2 = CType(value, TextField)
                Case "lblHeadingTeachers"
                    lblHeadingTeachers = CType(value, TextField)
                Case "link_TeacgerAllocations"
                    link_TeacgerAllocations = CType(value, TextField)
                Case "link_SubjectWithdrawals"
                    link_SubjectWithdrawals = CType(value, TextField)
                Case "link_StudentAmendments"
                    link_StudentAmendments = CType(value, TextField)
                Case "SCHOOL_list"
                    SCHOOL_list = CType(value, TextField)
                Case "ASSIGNMENT_link"
                    ASSIGNMENT_link = CType(value, TextField)
                Case "COUNTRY_OF_BIRT_list"
                    COUNTRY_OF_BIRT_list = CType(value, TextField)
                Case "STAFF_list"
                    STAFF_list = CType(value, TextField)
                Case "CONTRIBUTION_list"
                    CONTRIBUTION_list = CType(value, TextField)
                Case "GOVERNMENT_ALLO_list"
                    GOVERNMENT_ALLO_list = CType(value, TextField)
                Case "Link5"
                    Link5 = CType(value, TextField)
                Case "ENROLMENT_CATEG_list"
                    ENROLMENT_CATEG_list = CType(value, TextField)
                Case "KEY_LEARNING_AR_list"
                    KEY_LEARNING_AR_list = CType(value, TextField)
                Case "PROGRESS_CODE_list"
                    PROGRESS_CODE_list = CType(value, TextField)
                Case "LANGUAGE_list"
                    LANGUAGE_list = CType(value, TextField)
                Case "REGION_list"
                    REGION_list = CType(value, TextField)
                Case "SCHOOL_TYPE_list"
                    SCHOOL_TYPE_list = CType(value, TextField)
                Case "TXN_CODE_list"
                    TXN_CODE_list = CType(value, TextField)
                Case "Link4"
                    Link4 = CType(value, TextField)
                Case "WITHDRAWAL_REAS_list"
                    WITHDRAWAL_REAS_list = CType(value, TextField)
                Case "lblLastLogin"
                    lblLastLogin = CType(value, TextField)
                Case "FTE_RULES_list"
                    FTE_RULES_list = CType(value, TextField)
                Case "WITHDRAWAL_EXIT_list"
                    WITHDRAWAL_EXIT_list = CType(value, TextField)
                Case "STAFF_STUDENT_SUPERVISORS_link"
                    STAFF_STUDENT_SUPERVISORS_link = CType(value, TextField)
                Case "link_ManageStaffInductions"
                    link_ManageStaffInductions = CType(value, TextField)
                Case "lblSMTP_Server"
                    lblSMTP_Server = CType(value, TextField)
                Case "MODULES_REF_link"
                    MODULES_REF_link = CType(value, TextField)
                Case "COMMENT_TYPE_maint"
                    COMMENT_TYPE_maint = CType(value, TextField)
                Case "link_TeacherMyPastoral"
                    link_TeacherMyPastoral = CType(value, TextField)
                Case "linkdespatch_3"
                    linkdespatch_3 = CType(value, TextField)
                Case "link_TeleformsEnrolments"
                    link_TeleformsEnrolments = CType(value, TextField)
                Case "linkdespatch_4"
                    linkdespatch_4 = CType(value, TextField)
                Case "linkdespatch_5"
                    linkdespatch_5 = CType(value, TextField)
                Case "link_VSREnrolments"
                    link_VSREnrolments = CType(value, TextField)
                Case "link_ModifyEnrolmentDetails_AddressSearch"
                    link_ModifyEnrolmentDetails_AddressSearch = CType(value, TextField)
                Case "link_TeacherMyClassLists"
                    link_TeacherMyClassLists = CType(value, TextField)
                Case "link_ManageStaffInductions1"
                    link_ManageStaffInductions1 = CType(value, TextField)
                Case "link_ViewStaffInductions"
                    link_ViewStaffInductions = CType(value, TextField)
                Case "linkdespatch_6"
                    linkdespatch_6 = CType(value, TextField)
                Case "lblUserLevel"
                    lblUserLevel = CType(value, TextField)
                Case "lblAccessGroups"
                    lblAccessGroups = CType(value, TextField)
                Case "link_TeacherMyCommentSearch"
                    link_TeacherMyCommentSearch = CType(value, TextField)
                Case "link_ManageSubjectTeacherAllocations"
                    link_ManageSubjectTeacherAllocations = CType(value, TextField)
                Case "link_ManageAssignmentDescriptions"
                    link_ManageAssignmentDescriptions = CType(value, TextField)
                Case "lblHeadingCoords"
                    lblHeadingCoords = CType(value, TextField)
                Case "link_GreenLetters"
                    link_GreenLetters = CType(value, TextField)
                Case "link_ManageSubjectTeacherCourseDevs"
                    link_ManageSubjectTeacherCourseDevs = CType(value, TextField)
                Case "link_UnallocatedStudentTeachers"
                    link_UnallocatedStudentTeachers = CType(value, TextField)
                Case "link_SchoolEdit"
                    link_SchoolEdit = CType(value, TextField)
                Case "link_ManageSubjectTeacherCRT"
                    link_ManageSubjectTeacherCRT = CType(value, TextField)
                Case "Link_ManageLAd"
                    Link_ManageLAd = CType(value, TextField)
                Case "link_TeacherMyDefaulting"
                    link_TeacherMyDefaulting = CType(value, TextField)
                Case "link_TeacherMyClassListsExtender"
                    link_TeacherMyClassListsExtender = CType(value, TextField)
                Case "link_TimetableIntegration"
                    link_TimetableIntegration = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

End Class
'End Page Data Class

'Page Data Provider Class @1-E3544B64
Public Class PageDataProvider
Dim j As Integer
'End Page Data Provider Class

'Page Data Provider Class Constructor @1-12B526DF
    Public Sub New()
    End Sub
'End Page Data Provider Class Constructor

'Page Data Provider Class GetResultSet Method @1-F73C4626
    Public Sub FillItem(ByVal item As PageItem)
'End Page Data Provider Class GetResultSet Method

'Page Data Provider Class GetResultSet Method tail @1-E31F8E2A
    End Sub
'End Page Data Provider Class GetResultSet Method tail

'Page Data Provider class Tail @1-A61BA892
End Class
'End Page Data Provider class Tail

'Record MenuSearch Item Class @75-95D82A1B
Public Class MenuSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New TextField("", year(now()))
    End Sub

    Public Shared Function CreateFromHttpRequest() As MenuSearchItem
        Dim item As MenuSearchItem = New MenuSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

    Public Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public Property IsDeleted() As Boolean
        Get
            Return _isDeleted
        End Get
        Set
            _isDeleted = Value
        End Set
    End Property

    Public Sub Validate(ByVal provider As MenuSearchDataProvider)
'End Record MenuSearch Item Class

'TextBox STUDENT_ID Event OnValidate. Action Regular Expression Validation @79-2EA50278
        If Not (STUDENT_ID.Value Is Nothing) Then
            Dim mask As Regex = New Regex("^\d{5,6}$",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(STUDENT_ID.Value.ToString()).Success)
                errors.Add("STUDENT_ID",String.Format("Student ID is 5-6 digits only.","Student ID"))
            End If
        End If
'End TextBox STUDENT_ID Event OnValidate. Action Regular Expression Validation

'Record MenuSearch Item Class tail @75-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record MenuSearch Item Class tail

'Record MenuSearch Data Provider Class @75-0A456764
Public Class MenuSearchDataProvider
Inherits RecordDataProviderBase
'End Record MenuSearch Data Provider Class

'Record MenuSearch Data Provider Class Variables @75-493A1E78
    Protected item As MenuSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record MenuSearch Data Provider Class Variables

'Record MenuSearch Data Provider Class GetResultSet Method @75-743A9987

    Public Sub FillItem(ByVal item As MenuSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record MenuSearch Data Provider Class GetResultSet Method

'Record MenuSearch BeforeBuildSelect @75-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record MenuSearch BeforeBuildSelect

'Record MenuSearch AfterExecuteSelect @75-79426A21
        End If
            IsInsertMode = True
'End Record MenuSearch AfterExecuteSelect

'Record MenuSearch AfterExecuteSelect tail @75-E31F8E2A
    End Sub
'End Record MenuSearch AfterExecuteSelect tail

'Record MenuSearch Data Provider Class @75-A61BA892
End Class

'End Record MenuSearch Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

