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

Namespace DECV_PROD2007.Student_Profile 'Namespace @1-599E85AA

'Page Data Class @1-9DBCC9EC
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
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

'Record STUDENT_PROFILE1 Item Class @3-6CCACD30
Public Class STUDENT_PROFILE1Item
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public BACKGROUND_INFO As TextField
    Public ENROL_REASONS As TextField
    Public WELLBEING_INCLUSION_CONCERNS As TextField
    Public EXPECT_RETURN_TO_SCHOOL As TextField
    Public RETURN_STUDENT As TextField
    Public RETURN_STUDENTItems As ItemCollection
    Public KNOWN_WELLBEING As TextField
    Public KNOWN_WELLBEINGItems As ItemCollection
    Public KNOWN_INCLUSION As TextField
    Public KNOWN_INCLUSIONItems As ItemCollection
    Public KNOWN_PATHWAYS As TextField
    Public KNOWN_PATHWAYSItems As ItemCollection
    Public SUPPORT_DOCS_AGENCY_REFERRAL As TextField
    Public SUPPORT_DOCS_AGENCY_REFERRALCheckedValue As TextField
    Public SUPPORT_DOCS_AGENCY_REFERRALUncheckedValue As TextField
    Public SUPPORT_DOCS_SCHOOL_REFERRAL As TextField
    Public SUPPORT_DOCS_SCHOOL_REFERRALCheckedValue As TextField
    Public SUPPORT_DOCS_SCHOOL_REFERRALUncheckedValue As TextField
    Public SUPPORT_DOCS_YOUNG_ADULT As TextField
    Public SUPPORT_DOCS_YOUNG_ADULTCheckedValue As TextField
    Public SUPPORT_DOCS_YOUNG_ADULTUncheckedValue As TextField
    Public SUPPORT_DOCS_OTHER As TextField
    Public SUPPORT_KEY_PROFESSIONAL_NAME As TextField
    Public SUPPORT_KEY_PROFESSIONAL_CONTACT As TextField
    Public ENGAGEMENT_HOBBIES_INTERESTS As TextField
    Public COMM_VISIT_FLAG As TextField
    Public COMM_VISIT_FLAGItems As ItemCollection
    Public COMM_VISIT_DATE As DateField
    Public COMM_CONTACT_TYPE As TextField
    Public COMM_CONTACT_TYPEItems As ItemCollection
    Public COMM_CONTACT_TYPE_OTHER As TextField
    Public COMM_PHONE_CONTACT As TextField
    Public COMM_PHONE_CONTACTItems As ItemCollection
    Public CARER_CONTACT_METHOD As TextField
    Public CARER_SUPERVISOR_NAME As TextField
    Public CARER_SUPERVISOR_ROLE As TextField
    Public CARER_SUPERVISOR_ROLEItems As ItemCollection
    Public CARER_ADDITIONAL As TextField
    Public ORGANISATION_WHENWHERE As TextField
    Public ORGANISATION_TIMETABLE As TextField
    Public ORGANISATION_TIMETABLEItems As ItemCollection
    Public ORGANISATION_HARDWARE As TextField
    Public ORGANISATION_HARDWAREItems As ItemCollection
    Public ORGANISATION_ACCESS_INTERNET As TextField
    Public ORGANISATION_PREVIOUS_SCHOOL As TextField
    Public ORGANISATION_ACADEMIC_HISTORY As TextField
    Public ORGANISATION_RECENTREPORT_FILED As TextField
    Public ORGANISATION_RECENTREPORT_FILEDItems As ItemCollection
    Public LAUNCH_PAD_DONE As TextField
    Public LAUNCH_PAD_DONEItems As ItemCollection
    Public LAUNCH_PAD_DONE_DATE As DateField
    Public LEARNING_PROGRAM As TextField
    Public LEARNING_PROGRAM_DETAILS As TextField
    Public LEARNING_PROGRAM_CONSULT As TextField
    Public LEARNING_PROGRAM_CONSULTItems As ItemCollection
    Public LEARNING_GOALS As TextField
    Public SPECIAL_PROVISION_FLAG As TextField
    Public SPECIAL_PROVISION_FLAGItems As ItemCollection
    Public SPECIAL_PROVISION_DETAILS As TextField
    Public PATHWAYS_CAREER_PLAN_FLAG As TextField
    Public PATHWAYS_CAREER_PLAN_FLAGItems As ItemCollection
    Public PATHWAYS_CAREER_GOALS As TextField
    Public PATHWAYS_CAREER_GOALS_MIDYEAR As TextField
    Public PATHWAYS_CAREER_GOALS_MIDYEAR_DATE As DateField
    Public PATHWAYS_WORKEXP_FLAG As TextField
    Public PATHWAYS_WORKEXP_FLAGItems As ItemCollection
    Public PATHWAYS_WORKEXP_DETAILS As TextField
    Public PATHWAYS_PARTTIMEJOBS As TextField
    Public PATHWAYS_ENDYEAR_INTENTIONS_FLAG As TextField
    Public PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems As ItemCollection
    Public PATHWAYS_ENDYEAR_INTENTIONS_DATE As DateField
    Public PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG As TextField
    Public PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems As ItemCollection
    Public PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE As DateField
    Public REVIEW_PROGRESS_END_SEM1 As TextField
    Public REVIEW_PROGRESS_END_SEM2 As TextField
    Public lblLearningProgram As TextField
    Public lblStudentID As TextField
    Public lblEnrolYear As TextField
    Public LAST_ALTERED_BY1 As TextField
    Public LAST_ALTERED_DATE1 As DateField
    Public hidden_LastUpdatedBy As TextField
    Public hidden_LastUpdatedWhen As DateField
    Public Hidden_LEARNING_PROGRAM_CONSULT As TextField
    Public ASSESS_ENGLANG_LP As TextField
    Public ASSESS_ENGLANG_RL As TextField
    Public ASSESS_MATH_LP As TextField
    Public ASSESS_MATH_RL As TextField
    Public ASSESS_PATSCIENCE_LP As TextField
    Public ASSESS_PATSCIENCE_RL As TextField
    Public error_BackgroundInfo As TextField
    Public error_ReasonsEnrol As TextField
    Public error_StudentWellbeing As TextField
    Public error_ReturnMainstream As TextField
    Public error_ReturningStudent As TextField
    Public error_StudentWellbeing2 As TextField
    Public error_StudentInclusion As TextField
    Public error_PrevPathways As TextField
    Public error_SupportDocs As TextField
    Public error_HobbiesInterests As TextField
    Public error_CommsVisit As TextField
    Public error_ContactType As TextField
    Public error_CarerContactMethod As TextField
    Public error_SupervisorName As TextField
    Public error_SupervisorRole As TextField
    Public error_KeyProfSupports As TextField
    Public error_AddCarerInfo As TextField
    Public error_Workspace As TextField
    Public error_OrgHardware As TextField
    Public error_OrgInternet As TextField
    Public error_OrgPrevSchools As TextField
    Public error_OrgAcademic As TextField
    Public error_AssessData As TextField
    Public error_LearnDetails As TextField
    Public error_LearnGoals As TextField
    Public error_SpecialProvision As TextField
    Public error_Goals As TextField
    Public error_GoalsMidyear As TextField
    Public error_PartTimeJobs As TextField
    Public error_ProgressSem1 As TextField
    Public error_ProgressSem2 As TextField
    Public error_WorkExp910 As TextField
    Public error_EndYearDisc As TextField
    Public error_EndYearLogged As TextField
    Public SUPPORT_KEY_PROFESSIONAL_NAME2 As TextField
    Public SUPPORT_KEY_PROFESSIONAL_CONTACT2 As TextField
    Public cbENROL_FILE_CHECKED As TextField
    Public cbENROL_FILE_CHECKEDCheckedValue As TextField
    Public cbENROL_FILE_CHECKEDUncheckedValue As TextField
    Public Hidden_COMM_CONTACT_TYPE_MULTI As TextField
    Public error_LPDone As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public cbConfidentialDocuments As TextField
    Public cbConfidentialDocumentsCheckedValue As TextField
    Public cbConfidentialDocumentsUncheckedValue As TextField
    Public cbRiskFactors As BooleanField
    Public cbRiskFactorsCheckedValue As BooleanField
    Public cbRiskFactorsUncheckedValue As BooleanField
    Public COMM_INTAKE_CONTACT_TYPE_MULTI As TextField
    Public COMM_INTAKE_CONTACT_TYPE_MULTIItems As ItemCollection
    Public SUPPORT_KEY_PROFESSIONAL_ROLE As TextField
    Public SUPPORT_KEY_PROFESSIONAL_ROLE2 As TextField
    Public SUPPORT_KEY_PROFESSIONAL_NAME3 As TextField
    Public SUPPORT_KEY_PROFESSIONAL_ROLE3 As TextField
    Public SUPPORT_KEY_PROFESSIONAL_CONTACT3 As TextField
    Public SUPPORT_DOCS_YOUNG_ADULT1 As TextField
    Public SUPPORT_DOCS_YOUNG_ADULT1CheckedValue As TextField
    Public SUPPORT_DOCS_YOUNG_ADULT1UncheckedValue As TextField
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    BACKGROUND_INFO = New TextField("", Nothing)
    ENROL_REASONS = New TextField("", Nothing)
    WELLBEING_INCLUSION_CONCERNS = New TextField("", Nothing)
    EXPECT_RETURN_TO_SCHOOL = New TextField("", Nothing)
    RETURN_STUDENT = New TextField("", Nothing)
    RETURN_STUDENTItems = New ItemCollection()
    KNOWN_WELLBEING = New TextField("", Nothing)
    KNOWN_WELLBEINGItems = New ItemCollection()
    KNOWN_INCLUSION = New TextField("", Nothing)
    KNOWN_INCLUSIONItems = New ItemCollection()
    KNOWN_PATHWAYS = New TextField("", Nothing)
    KNOWN_PATHWAYSItems = New ItemCollection()
    SUPPORT_DOCS_AGENCY_REFERRAL = New TextField("", "N")
    SUPPORT_DOCS_AGENCY_REFERRALCheckedValue = New TextField("", "Y")
    SUPPORT_DOCS_AGENCY_REFERRALUncheckedValue = New TextField("", "N")
    SUPPORT_DOCS_SCHOOL_REFERRAL = New TextField("", "N")
    SUPPORT_DOCS_SCHOOL_REFERRALCheckedValue = New TextField("", "Y")
    SUPPORT_DOCS_SCHOOL_REFERRALUncheckedValue = New TextField("", "N")
    SUPPORT_DOCS_YOUNG_ADULT = New TextField("", "N")
    SUPPORT_DOCS_YOUNG_ADULTCheckedValue = New TextField("", "Y")
    SUPPORT_DOCS_YOUNG_ADULTUncheckedValue = New TextField("", "N")
    SUPPORT_DOCS_OTHER = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_NAME = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_CONTACT = New TextField("", Nothing)
    ENGAGEMENT_HOBBIES_INTERESTS = New TextField("", Nothing)
    COMM_VISIT_FLAG = New TextField("", Nothing)
    COMM_VISIT_FLAGItems = New ItemCollection()
    COMM_VISIT_DATE = New DateField("d\/M\/yyyy", Nothing)
    COMM_CONTACT_TYPE = New TextField("", Nothing)
    COMM_CONTACT_TYPEItems = New ItemCollection()
    COMM_CONTACT_TYPE_OTHER = New TextField("", Nothing)
    COMM_PHONE_CONTACT = New TextField("", Nothing)
    COMM_PHONE_CONTACTItems = New ItemCollection()
    CARER_CONTACT_METHOD = New TextField("", Nothing)
    CARER_SUPERVISOR_NAME = New TextField("", Nothing)
    CARER_SUPERVISOR_ROLE = New TextField("", Nothing)
    CARER_SUPERVISOR_ROLEItems = New ItemCollection()
    CARER_ADDITIONAL = New TextField("", Nothing)
    ORGANISATION_WHENWHERE = New TextField("", Nothing)
    ORGANISATION_TIMETABLE = New TextField("", Nothing)
    ORGANISATION_TIMETABLEItems = New ItemCollection()
    ORGANISATION_HARDWARE = New TextField("", Nothing)
    ORGANISATION_HARDWAREItems = New ItemCollection()
    ORGANISATION_ACCESS_INTERNET = New TextField("", Nothing)
    ORGANISATION_PREVIOUS_SCHOOL = New TextField("", Nothing)
    ORGANISATION_ACADEMIC_HISTORY = New TextField("", Nothing)
    ORGANISATION_RECENTREPORT_FILED = New TextField("", Nothing)
    ORGANISATION_RECENTREPORT_FILEDItems = New ItemCollection()
    LAUNCH_PAD_DONE = New TextField("", Nothing)
    LAUNCH_PAD_DONEItems = New ItemCollection()
    LAUNCH_PAD_DONE_DATE = New DateField("d\/M\/yyyy", Nothing)
    LEARNING_PROGRAM = New TextField("", Nothing)
    LEARNING_PROGRAM_DETAILS = New TextField("", Nothing)
    LEARNING_PROGRAM_CONSULT = New TextField("", Nothing)
    LEARNING_PROGRAM_CONSULTItems = New ItemCollection()
    LEARNING_GOALS = New TextField("", Nothing)
    SPECIAL_PROVISION_FLAG = New TextField("", Nothing)
    SPECIAL_PROVISION_FLAGItems = New ItemCollection()
    SPECIAL_PROVISION_DETAILS = New TextField("", Nothing)
    PATHWAYS_CAREER_PLAN_FLAG = New TextField("", Nothing)
    PATHWAYS_CAREER_PLAN_FLAGItems = New ItemCollection()
    PATHWAYS_CAREER_GOALS = New TextField("", Nothing)
    PATHWAYS_CAREER_GOALS_MIDYEAR = New TextField("", Nothing)
    PATHWAYS_CAREER_GOALS_MIDYEAR_DATE = New DateField("d\/M\/yyyy", Nothing)
    PATHWAYS_WORKEXP_FLAG = New TextField("", Nothing)
    PATHWAYS_WORKEXP_FLAGItems = New ItemCollection()
    PATHWAYS_WORKEXP_DETAILS = New TextField("", Nothing)
    PATHWAYS_PARTTIMEJOBS = New TextField("", Nothing)
    PATHWAYS_ENDYEAR_INTENTIONS_FLAG = New TextField("", Nothing)
    PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems = New ItemCollection()
    PATHWAYS_ENDYEAR_INTENTIONS_DATE = New DateField("d\/M\/yyyy", Nothing)
    PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG = New TextField("", Nothing)
    PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems = New ItemCollection()
    PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE = New DateField("d\/M\/yyyy", Nothing)
    REVIEW_PROGRESS_END_SEM1 = New TextField("", Nothing)
    REVIEW_PROGRESS_END_SEM2 = New TextField("", Nothing)
    lblLearningProgram = New TextField("", "not determined yet")
    lblStudentID = New TextField("", <font color='RED'>Not saved yet</font>)
    lblEnrolYear = New TextField("", Nothing)
    LAST_ALTERED_BY1 = New TextField("", Nothing)
    LAST_ALTERED_DATE1 = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    hidden_LastUpdatedBy = New TextField("", DBUtility.UserID.ToUpper)
    hidden_LastUpdatedWhen = New DateField("yyyy-MM-dd H\:mm", DateTime.Now)
    Hidden_LEARNING_PROGRAM_CONSULT = New TextField("", "0,")
    ASSESS_ENGLANG_LP = New TextField("", Nothing)
    ASSESS_ENGLANG_RL = New TextField("", Nothing)
    ASSESS_MATH_LP = New TextField("", Nothing)
    ASSESS_MATH_RL = New TextField("", Nothing)
    ASSESS_PATSCIENCE_LP = New TextField("", Nothing)
    ASSESS_PATSCIENCE_RL = New TextField("", Nothing)
    error_BackgroundInfo = New TextField("", Nothing)
    error_ReasonsEnrol = New TextField("", Nothing)
    error_StudentWellbeing = New TextField("", Nothing)
    error_ReturnMainstream = New TextField("", Nothing)
    error_ReturningStudent = New TextField("", Nothing)
    error_StudentWellbeing2 = New TextField("", Nothing)
    error_StudentInclusion = New TextField("", Nothing)
    error_PrevPathways = New TextField("", Nothing)
    error_SupportDocs = New TextField("", Nothing)
    error_HobbiesInterests = New TextField("", Nothing)
    error_CommsVisit = New TextField("", Nothing)
    error_ContactType = New TextField("", Nothing)
    error_CarerContactMethod = New TextField("", Nothing)
    error_SupervisorName = New TextField("", Nothing)
    error_SupervisorRole = New TextField("", Nothing)
    error_KeyProfSupports = New TextField("", Nothing)
    error_AddCarerInfo = New TextField("", Nothing)
    error_Workspace = New TextField("", Nothing)
    error_OrgHardware = New TextField("", Nothing)
    error_OrgInternet = New TextField("", Nothing)
    error_OrgPrevSchools = New TextField("", Nothing)
    error_OrgAcademic = New TextField("", Nothing)
    error_AssessData = New TextField("", Nothing)
    error_LearnDetails = New TextField("", Nothing)
    error_LearnGoals = New TextField("", Nothing)
    error_SpecialProvision = New TextField("", Nothing)
    error_Goals = New TextField("", Nothing)
    error_GoalsMidyear = New TextField("", Nothing)
    error_PartTimeJobs = New TextField("", Nothing)
    error_ProgressSem1 = New TextField("", Nothing)
    error_ProgressSem2 = New TextField("", Nothing)
    error_WorkExp910 = New TextField("", Nothing)
    error_EndYearDisc = New TextField("", Nothing)
    error_EndYearLogged = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_NAME2 = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_CONTACT2 = New TextField("", Nothing)
    cbENROL_FILE_CHECKED = New TextField("", "N")
    cbENROL_FILE_CHECKEDCheckedValue = New TextField("", "Y")
    cbENROL_FILE_CHECKEDUncheckedValue = New TextField("", "N")
    Hidden_COMM_CONTACT_TYPE_MULTI = New TextField("", "0,")
    error_LPDone = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    cbConfidentialDocuments = New TextField("", "N")
    cbConfidentialDocumentsCheckedValue = New TextField("", "Y")
    cbConfidentialDocumentsUncheckedValue = New TextField("", "N")
    cbRiskFactors = New BooleanField(Settings.BoolFormat, False)
    cbRiskFactorsCheckedValue = New BooleanField(Settings.BoolFormat, True)
    cbRiskFactorsUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    COMM_INTAKE_CONTACT_TYPE_MULTI = New TextField("", Nothing)
    COMM_INTAKE_CONTACT_TYPE_MULTIItems = New ItemCollection()
    SUPPORT_KEY_PROFESSIONAL_ROLE = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_ROLE2 = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_NAME3 = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_ROLE3 = New TextField("", Nothing)
    SUPPORT_KEY_PROFESSIONAL_CONTACT3 = New TextField("", Nothing)
    SUPPORT_DOCS_YOUNG_ADULT1 = New TextField("", "N")
    SUPPORT_DOCS_YOUNG_ADULT1CheckedValue = New TextField("", "Y")
    SUPPORT_DOCS_YOUNG_ADULT1UncheckedValue = New TextField("", "N")
    Link2 = New TextField("",Nothing)
    Link2HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As STUDENT_PROFILE1Item
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("BACKGROUND_INFO")) Then
        item.BACKGROUND_INFO.SetValue(DBUtility.GetInitialValue("BACKGROUND_INFO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROL_REASONS")) Then
        item.ENROL_REASONS.SetValue(DBUtility.GetInitialValue("ENROL_REASONS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WELLBEING_INCLUSION_CONCERNS")) Then
        item.WELLBEING_INCLUSION_CONCERNS.SetValue(DBUtility.GetInitialValue("WELLBEING_INCLUSION_CONCERNS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EXPECT_RETURN_TO_SCHOOL")) Then
        item.EXPECT_RETURN_TO_SCHOOL.SetValue(DBUtility.GetInitialValue("EXPECT_RETURN_TO_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RETURN_STUDENT")) Then
        item.RETURN_STUDENT.SetValue(DBUtility.GetInitialValue("RETURN_STUDENT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KNOWN_WELLBEING")) Then
        item.KNOWN_WELLBEING.SetValue(DBUtility.GetInitialValue("KNOWN_WELLBEING"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KNOWN_INCLUSION")) Then
        item.KNOWN_INCLUSION.SetValue(DBUtility.GetInitialValue("KNOWN_INCLUSION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("KNOWN_PATHWAYS")) Then
        item.KNOWN_PATHWAYS.SetValue(DBUtility.GetInitialValue("KNOWN_PATHWAYS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_DOCS_AGENCY_REFERRAL")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("SUPPORT_DOCS_AGENCY_REFERRAL")) Then
            item.SUPPORT_DOCS_AGENCY_REFERRAL.Value = item.SUPPORT_DOCS_AGENCY_REFERRALCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_DOCS_SCHOOL_REFERRAL")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("SUPPORT_DOCS_SCHOOL_REFERRAL")) Then
            item.SUPPORT_DOCS_SCHOOL_REFERRAL.Value = item.SUPPORT_DOCS_SCHOOL_REFERRALCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_DOCS_YOUNG_ADULT")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("SUPPORT_DOCS_YOUNG_ADULT")) Then
            item.SUPPORT_DOCS_YOUNG_ADULT.Value = item.SUPPORT_DOCS_YOUNG_ADULTCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_DOCS_OTHER")) Then
        item.SUPPORT_DOCS_OTHER.SetValue(DBUtility.GetInitialValue("SUPPORT_DOCS_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME")) Then
        item.SUPPORT_KEY_PROFESSIONAL_NAME.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT")) Then
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENGAGEMENT_HOBBIES_INTERESTS")) Then
        item.ENGAGEMENT_HOBBIES_INTERESTS.SetValue(DBUtility.GetInitialValue("ENGAGEMENT_HOBBIES_INTERESTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_VISIT_FLAG")) Then
        item.COMM_VISIT_FLAG.SetValue(DBUtility.GetInitialValue("COMM_VISIT_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_VISIT_DATE")) Then
        item.COMM_VISIT_DATE.SetValue(DBUtility.GetInitialValue("COMM_VISIT_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_CONTACT_TYPE")) Then
        item.COMM_CONTACT_TYPE.SetValue(DBUtility.GetInitialValue("COMM_CONTACT_TYPE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_CONTACT_TYPE_OTHER")) Then
        item.COMM_CONTACT_TYPE_OTHER.SetValue(DBUtility.GetInitialValue("COMM_CONTACT_TYPE_OTHER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_PHONE_CONTACT")) Then
        item.COMM_PHONE_CONTACT.SetValue(DBUtility.GetInitialValue("COMM_PHONE_CONTACT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CARER_CONTACT_METHOD")) Then
        item.CARER_CONTACT_METHOD.SetValue(DBUtility.GetInitialValue("CARER_CONTACT_METHOD"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CARER_SUPERVISOR_NAME")) Then
        item.CARER_SUPERVISOR_NAME.SetValue(DBUtility.GetInitialValue("CARER_SUPERVISOR_NAME"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CARER_SUPERVISOR_ROLE")) Then
        item.CARER_SUPERVISOR_ROLE.SetValue(DBUtility.GetInitialValue("CARER_SUPERVISOR_ROLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CARER_ADDITIONAL")) Then
        item.CARER_ADDITIONAL.SetValue(DBUtility.GetInitialValue("CARER_ADDITIONAL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_WHENWHERE")) Then
        item.ORGANISATION_WHENWHERE.SetValue(DBUtility.GetInitialValue("ORGANISATION_WHENWHERE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_TIMETABLE")) Then
        item.ORGANISATION_TIMETABLE.SetValue(DBUtility.GetInitialValue("ORGANISATION_TIMETABLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_HARDWARE")) Then
        item.ORGANISATION_HARDWARE.SetValue(DBUtility.GetInitialValue("ORGANISATION_HARDWARE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_ACCESS_INTERNET")) Then
        item.ORGANISATION_ACCESS_INTERNET.SetValue(DBUtility.GetInitialValue("ORGANISATION_ACCESS_INTERNET"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_PREVIOUS_SCHOOL")) Then
        item.ORGANISATION_PREVIOUS_SCHOOL.SetValue(DBUtility.GetInitialValue("ORGANISATION_PREVIOUS_SCHOOL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_ACADEMIC_HISTORY")) Then
        item.ORGANISATION_ACADEMIC_HISTORY.SetValue(DBUtility.GetInitialValue("ORGANISATION_ACADEMIC_HISTORY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_RECENTREPORT_FILED")) Then
        item.ORGANISATION_RECENTREPORT_FILED.SetValue(DBUtility.GetInitialValue("ORGANISATION_RECENTREPORT_FILED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAUNCH_PAD_DONE")) Then
        item.LAUNCH_PAD_DONE.SetValue(DBUtility.GetInitialValue("LAUNCH_PAD_DONE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAUNCH_PAD_DONE_DATE")) Then
        item.LAUNCH_PAD_DONE_DATE.SetValue(DBUtility.GetInitialValue("LAUNCH_PAD_DONE_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM")) Then
        item.LEARNING_PROGRAM.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM_DETAILS")) Then
        item.LEARNING_PROGRAM_DETAILS.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM_CONSULT")) Then
        item.LEARNING_PROGRAM_CONSULT.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM_CONSULT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_GOALS")) Then
        item.LEARNING_GOALS.SetValue(DBUtility.GetInitialValue("LEARNING_GOALS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SPECIAL_PROVISION_FLAG")) Then
        item.SPECIAL_PROVISION_FLAG.SetValue(DBUtility.GetInitialValue("SPECIAL_PROVISION_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SPECIAL_PROVISION_DETAILS")) Then
        item.SPECIAL_PROVISION_DETAILS.SetValue(DBUtility.GetInitialValue("SPECIAL_PROVISION_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_CAREER_PLAN_FLAG")) Then
        item.PATHWAYS_CAREER_PLAN_FLAG.SetValue(DBUtility.GetInitialValue("PATHWAYS_CAREER_PLAN_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS")) Then
        item.PATHWAYS_CAREER_GOALS.SetValue(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS_MIDYEAR")) Then
        item.PATHWAYS_CAREER_GOALS_MIDYEAR.SetValue(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS_MIDYEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS_MIDYEAR_DATE")) Then
        item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.SetValue(DBUtility.GetInitialValue("PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_WORKEXP_FLAG")) Then
        item.PATHWAYS_WORKEXP_FLAG.SetValue(DBUtility.GetInitialValue("PATHWAYS_WORKEXP_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_WORKEXP_DETAILS")) Then
        item.PATHWAYS_WORKEXP_DETAILS.SetValue(DBUtility.GetInitialValue("PATHWAYS_WORKEXP_DETAILS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_PARTTIMEJOBS")) Then
        item.PATHWAYS_PARTTIMEJOBS.SetValue(DBUtility.GetInitialValue("PATHWAYS_PARTTIMEJOBS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_FLAG")) Then
        item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SetValue(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_DATE")) Then
        item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.SetValue(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG")) Then
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SetValue(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE")) Then
        item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.SetValue(DBUtility.GetInitialValue("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM1")) Then
        item.REVIEW_PROGRESS_END_SEM1.SetValue(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM2")) Then
        item.REVIEW_PROGRESS_END_SEM2.SetValue(DBUtility.GetInitialValue("REVIEW_PROGRESS_END_SEM2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblLearningProgram")) Then
        item.lblLearningProgram.SetValue(DBUtility.GetInitialValue("lblLearningProgram"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolYear")) Then
        item.lblEnrolYear.SetValue(DBUtility.GetInitialValue("lblEnrolYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY1")) Then
        item.LAST_ALTERED_BY1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE1")) Then
        item.LAST_ALTERED_DATE1.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel2")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LastUpdatedBy")) Then
        item.hidden_LastUpdatedBy.SetValue(DBUtility.GetInitialValue("hidden_LastUpdatedBy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_LastUpdatedWhen")) Then
        item.hidden_LastUpdatedWhen.SetValue(DBUtility.GetInitialValue("hidden_LastUpdatedWhen"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_LEARNING_PROGRAM_CONSULT")) Then
        item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(DBUtility.GetInitialValue("Hidden_LEARNING_PROGRAM_CONSULT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_ENGLANG_LP")) Then
        item.ASSESS_ENGLANG_LP.SetValue(DBUtility.GetInitialValue("ASSESS_ENGLANG_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_ENGLANG_RL")) Then
        item.ASSESS_ENGLANG_RL.SetValue(DBUtility.GetInitialValue("ASSESS_ENGLANG_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_MATH_LP")) Then
        item.ASSESS_MATH_LP.SetValue(DBUtility.GetInitialValue("ASSESS_MATH_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_MATH_RL")) Then
        item.ASSESS_MATH_RL.SetValue(DBUtility.GetInitialValue("ASSESS_MATH_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_LP")) Then
        item.ASSESS_PATSCIENCE_LP.SetValue(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_LP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_RL")) Then
        item.ASSESS_PATSCIENCE_RL.SetValue(DBUtility.GetInitialValue("ASSESS_PATSCIENCE_RL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_BackgroundInfo")) Then
        item.error_BackgroundInfo.SetValue(DBUtility.GetInitialValue("error_BackgroundInfo"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ReasonsEnrol")) Then
        item.error_ReasonsEnrol.SetValue(DBUtility.GetInitialValue("error_ReasonsEnrol"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_StudentWellbeing")) Then
        item.error_StudentWellbeing.SetValue(DBUtility.GetInitialValue("error_StudentWellbeing"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ReturnMainstream")) Then
        item.error_ReturnMainstream.SetValue(DBUtility.GetInitialValue("error_ReturnMainstream"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ReturningStudent")) Then
        item.error_ReturningStudent.SetValue(DBUtility.GetInitialValue("error_ReturningStudent"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_StudentWellbeing2")) Then
        item.error_StudentWellbeing2.SetValue(DBUtility.GetInitialValue("error_StudentWellbeing2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_StudentInclusion")) Then
        item.error_StudentInclusion.SetValue(DBUtility.GetInitialValue("error_StudentInclusion"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_PrevPathways")) Then
        item.error_PrevPathways.SetValue(DBUtility.GetInitialValue("error_PrevPathways"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_SupportDocs")) Then
        item.error_SupportDocs.SetValue(DBUtility.GetInitialValue("error_SupportDocs"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_HobbiesInterests")) Then
        item.error_HobbiesInterests.SetValue(DBUtility.GetInitialValue("error_HobbiesInterests"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_CommsVisit")) Then
        item.error_CommsVisit.SetValue(DBUtility.GetInitialValue("error_CommsVisit"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ContactType")) Then
        item.error_ContactType.SetValue(DBUtility.GetInitialValue("error_ContactType"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_CarerContactMethod")) Then
        item.error_CarerContactMethod.SetValue(DBUtility.GetInitialValue("error_CarerContactMethod"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_SupervisorName")) Then
        item.error_SupervisorName.SetValue(DBUtility.GetInitialValue("error_SupervisorName"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_SupervisorRole")) Then
        item.error_SupervisorRole.SetValue(DBUtility.GetInitialValue("error_SupervisorRole"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_KeyProfSupports")) Then
        item.error_KeyProfSupports.SetValue(DBUtility.GetInitialValue("error_KeyProfSupports"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_AddCarerInfo")) Then
        item.error_AddCarerInfo.SetValue(DBUtility.GetInitialValue("error_AddCarerInfo"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_Workspace")) Then
        item.error_Workspace.SetValue(DBUtility.GetInitialValue("error_Workspace"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_OrgHardware")) Then
        item.error_OrgHardware.SetValue(DBUtility.GetInitialValue("error_OrgHardware"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_OrgInternet")) Then
        item.error_OrgInternet.SetValue(DBUtility.GetInitialValue("error_OrgInternet"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_OrgPrevSchools")) Then
        item.error_OrgPrevSchools.SetValue(DBUtility.GetInitialValue("error_OrgPrevSchools"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_OrgAcademic")) Then
        item.error_OrgAcademic.SetValue(DBUtility.GetInitialValue("error_OrgAcademic"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_AssessData")) Then
        item.error_AssessData.SetValue(DBUtility.GetInitialValue("error_AssessData"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LearnDetails")) Then
        item.error_LearnDetails.SetValue(DBUtility.GetInitialValue("error_LearnDetails"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LearnGoals")) Then
        item.error_LearnGoals.SetValue(DBUtility.GetInitialValue("error_LearnGoals"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_SpecialProvision")) Then
        item.error_SpecialProvision.SetValue(DBUtility.GetInitialValue("error_SpecialProvision"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_Goals")) Then
        item.error_Goals.SetValue(DBUtility.GetInitialValue("error_Goals"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_GoalsMidyear")) Then
        item.error_GoalsMidyear.SetValue(DBUtility.GetInitialValue("error_GoalsMidyear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_PartTimeJobs")) Then
        item.error_PartTimeJobs.SetValue(DBUtility.GetInitialValue("error_PartTimeJobs"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ProgressSem1")) Then
        item.error_ProgressSem1.SetValue(DBUtility.GetInitialValue("error_ProgressSem1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_ProgressSem2")) Then
        item.error_ProgressSem2.SetValue(DBUtility.GetInitialValue("error_ProgressSem2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_WorkExp910")) Then
        item.error_WorkExp910.SetValue(DBUtility.GetInitialValue("error_WorkExp910"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_EndYearDisc")) Then
        item.error_EndYearDisc.SetValue(DBUtility.GetInitialValue("error_EndYearDisc"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_EndYearLogged")) Then
        item.error_EndYearLogged.SetValue(DBUtility.GetInitialValue("error_EndYearLogged"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME2")) Then
        item.SUPPORT_KEY_PROFESSIONAL_NAME2.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT2")) Then
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbENROL_FILE_CHECKED")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbENROL_FILE_CHECKED")) Then
            item.cbENROL_FILE_CHECKED.Value = item.cbENROL_FILE_CHECKEDCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Hidden_COMM_CONTACT_TYPE_MULTI")) Then
        item.Hidden_COMM_CONTACT_TYPE_MULTI.SetValue(DBUtility.GetInitialValue("Hidden_COMM_CONTACT_TYPE_MULTI"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("error_LPDone")) Then
        item.error_LPDone.SetValue(DBUtility.GetInitialValue("error_LPDone"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbConfidentialDocuments")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbConfidentialDocuments")) Then
            item.cbConfidentialDocuments.Value = item.cbConfidentialDocumentsCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cbRiskFactors")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("cbRiskFactors")) Then
            item.cbRiskFactors.Value = item.cbRiskFactorsCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMM_INTAKE_CONTACT_TYPE_MULTI")) Then
        item.COMM_INTAKE_CONTACT_TYPE_MULTI.SetValue(DBUtility.GetInitialValue("COMM_INTAKE_CONTACT_TYPE_MULTI"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE")) Then
        item.SUPPORT_KEY_PROFESSIONAL_ROLE.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE2")) Then
        item.SUPPORT_KEY_PROFESSIONAL_ROLE2.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE2"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME3")) Then
        item.SUPPORT_KEY_PROFESSIONAL_NAME3.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_NAME3"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE3")) Then
        item.SUPPORT_KEY_PROFESSIONAL_ROLE3.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_ROLE3"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT3")) Then
        item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.SetValue(DBUtility.GetInitialValue("SUPPORT_KEY_PROFESSIONAL_CONTACT3"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SUPPORT_DOCS_YOUNG_ADULT1")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("SUPPORT_DOCS_YOUNG_ADULT1")) Then
            item.SUPPORT_DOCS_YOUNG_ADULT1.Value = item.SUPPORT_DOCS_YOUNG_ADULT1CheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link2")) Then
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"))
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
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "BACKGROUND_INFO"
                    Return BACKGROUND_INFO
                Case "ENROL_REASONS"
                    Return ENROL_REASONS
                Case "WELLBEING_INCLUSION_CONCERNS"
                    Return WELLBEING_INCLUSION_CONCERNS
                Case "EXPECT_RETURN_TO_SCHOOL"
                    Return EXPECT_RETURN_TO_SCHOOL
                Case "RETURN_STUDENT"
                    Return RETURN_STUDENT
                Case "KNOWN_WELLBEING"
                    Return KNOWN_WELLBEING
                Case "KNOWN_INCLUSION"
                    Return KNOWN_INCLUSION
                Case "KNOWN_PATHWAYS"
                    Return KNOWN_PATHWAYS
                Case "SUPPORT_DOCS_AGENCY_REFERRAL"
                    Return SUPPORT_DOCS_AGENCY_REFERRAL
                Case "SUPPORT_DOCS_SCHOOL_REFERRAL"
                    Return SUPPORT_DOCS_SCHOOL_REFERRAL
                Case "SUPPORT_DOCS_YOUNG_ADULT"
                    Return SUPPORT_DOCS_YOUNG_ADULT
                Case "SUPPORT_DOCS_OTHER"
                    Return SUPPORT_DOCS_OTHER
                Case "SUPPORT_KEY_PROFESSIONAL_NAME"
                    Return SUPPORT_KEY_PROFESSIONAL_NAME
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT"
                    Return SUPPORT_KEY_PROFESSIONAL_CONTACT
                Case "ENGAGEMENT_HOBBIES_INTERESTS"
                    Return ENGAGEMENT_HOBBIES_INTERESTS
                Case "COMM_VISIT_FLAG"
                    Return COMM_VISIT_FLAG
                Case "COMM_VISIT_DATE"
                    Return COMM_VISIT_DATE
                Case "COMM_CONTACT_TYPE"
                    Return COMM_CONTACT_TYPE
                Case "COMM_CONTACT_TYPE_OTHER"
                    Return COMM_CONTACT_TYPE_OTHER
                Case "COMM_PHONE_CONTACT"
                    Return COMM_PHONE_CONTACT
                Case "CARER_CONTACT_METHOD"
                    Return CARER_CONTACT_METHOD
                Case "CARER_SUPERVISOR_NAME"
                    Return CARER_SUPERVISOR_NAME
                Case "CARER_SUPERVISOR_ROLE"
                    Return CARER_SUPERVISOR_ROLE
                Case "CARER_ADDITIONAL"
                    Return CARER_ADDITIONAL
                Case "ORGANISATION_WHENWHERE"
                    Return ORGANISATION_WHENWHERE
                Case "ORGANISATION_TIMETABLE"
                    Return ORGANISATION_TIMETABLE
                Case "ORGANISATION_HARDWARE"
                    Return ORGANISATION_HARDWARE
                Case "ORGANISATION_ACCESS_INTERNET"
                    Return ORGANISATION_ACCESS_INTERNET
                Case "ORGANISATION_PREVIOUS_SCHOOL"
                    Return ORGANISATION_PREVIOUS_SCHOOL
                Case "ORGANISATION_ACADEMIC_HISTORY"
                    Return ORGANISATION_ACADEMIC_HISTORY
                Case "ORGANISATION_RECENTREPORT_FILED"
                    Return ORGANISATION_RECENTREPORT_FILED
                Case "LAUNCH_PAD_DONE"
                    Return LAUNCH_PAD_DONE
                Case "LAUNCH_PAD_DONE_DATE"
                    Return LAUNCH_PAD_DONE_DATE
                Case "LEARNING_PROGRAM"
                    Return LEARNING_PROGRAM
                Case "LEARNING_PROGRAM_DETAILS"
                    Return LEARNING_PROGRAM_DETAILS
                Case "LEARNING_PROGRAM_CONSULT"
                    Return LEARNING_PROGRAM_CONSULT
                Case "LEARNING_GOALS"
                    Return LEARNING_GOALS
                Case "SPECIAL_PROVISION_FLAG"
                    Return SPECIAL_PROVISION_FLAG
                Case "SPECIAL_PROVISION_DETAILS"
                    Return SPECIAL_PROVISION_DETAILS
                Case "PATHWAYS_CAREER_PLAN_FLAG"
                    Return PATHWAYS_CAREER_PLAN_FLAG
                Case "PATHWAYS_CAREER_GOALS"
                    Return PATHWAYS_CAREER_GOALS
                Case "PATHWAYS_CAREER_GOALS_MIDYEAR"
                    Return PATHWAYS_CAREER_GOALS_MIDYEAR
                Case "PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"
                    Return PATHWAYS_CAREER_GOALS_MIDYEAR_DATE
                Case "PATHWAYS_WORKEXP_FLAG"
                    Return PATHWAYS_WORKEXP_FLAG
                Case "PATHWAYS_WORKEXP_DETAILS"
                    Return PATHWAYS_WORKEXP_DETAILS
                Case "PATHWAYS_PARTTIMEJOBS"
                    Return PATHWAYS_PARTTIMEJOBS
                Case "PATHWAYS_ENDYEAR_INTENTIONS_FLAG"
                    Return PATHWAYS_ENDYEAR_INTENTIONS_FLAG
                Case "PATHWAYS_ENDYEAR_INTENTIONS_DATE"
                    Return PATHWAYS_ENDYEAR_INTENTIONS_DATE
                Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"
                    Return PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG
                Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"
                    Return PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE
                Case "REVIEW_PROGRESS_END_SEM1"
                    Return REVIEW_PROGRESS_END_SEM1
                Case "REVIEW_PROGRESS_END_SEM2"
                    Return REVIEW_PROGRESS_END_SEM2
                Case "lblLearningProgram"
                    Return lblLearningProgram
                Case "lblStudentID"
                    Return lblStudentID
                Case "lblEnrolYear"
                    Return lblEnrolYear
                Case "LAST_ALTERED_BY1"
                    Return LAST_ALTERED_BY1
                Case "LAST_ALTERED_DATE1"
                    Return LAST_ALTERED_DATE1
                Case "hidden_LastUpdatedBy"
                    Return hidden_LastUpdatedBy
                Case "hidden_LastUpdatedWhen"
                    Return hidden_LastUpdatedWhen
                Case "Hidden_LEARNING_PROGRAM_CONSULT"
                    Return Hidden_LEARNING_PROGRAM_CONSULT
                Case "ASSESS_ENGLANG_LP"
                    Return ASSESS_ENGLANG_LP
                Case "ASSESS_ENGLANG_RL"
                    Return ASSESS_ENGLANG_RL
                Case "ASSESS_MATH_LP"
                    Return ASSESS_MATH_LP
                Case "ASSESS_MATH_RL"
                    Return ASSESS_MATH_RL
                Case "ASSESS_PATSCIENCE_LP"
                    Return ASSESS_PATSCIENCE_LP
                Case "ASSESS_PATSCIENCE_RL"
                    Return ASSESS_PATSCIENCE_RL
                Case "error_BackgroundInfo"
                    Return error_BackgroundInfo
                Case "error_ReasonsEnrol"
                    Return error_ReasonsEnrol
                Case "error_StudentWellbeing"
                    Return error_StudentWellbeing
                Case "error_ReturnMainstream"
                    Return error_ReturnMainstream
                Case "error_ReturningStudent"
                    Return error_ReturningStudent
                Case "error_StudentWellbeing2"
                    Return error_StudentWellbeing2
                Case "error_StudentInclusion"
                    Return error_StudentInclusion
                Case "error_PrevPathways"
                    Return error_PrevPathways
                Case "error_SupportDocs"
                    Return error_SupportDocs
                Case "error_HobbiesInterests"
                    Return error_HobbiesInterests
                Case "error_CommsVisit"
                    Return error_CommsVisit
                Case "error_ContactType"
                    Return error_ContactType
                Case "error_CarerContactMethod"
                    Return error_CarerContactMethod
                Case "error_SupervisorName"
                    Return error_SupervisorName
                Case "error_SupervisorRole"
                    Return error_SupervisorRole
                Case "error_KeyProfSupports"
                    Return error_KeyProfSupports
                Case "error_AddCarerInfo"
                    Return error_AddCarerInfo
                Case "error_Workspace"
                    Return error_Workspace
                Case "error_OrgHardware"
                    Return error_OrgHardware
                Case "error_OrgInternet"
                    Return error_OrgInternet
                Case "error_OrgPrevSchools"
                    Return error_OrgPrevSchools
                Case "error_OrgAcademic"
                    Return error_OrgAcademic
                Case "error_AssessData"
                    Return error_AssessData
                Case "error_LearnDetails"
                    Return error_LearnDetails
                Case "error_LearnGoals"
                    Return error_LearnGoals
                Case "error_SpecialProvision"
                    Return error_SpecialProvision
                Case "error_Goals"
                    Return error_Goals
                Case "error_GoalsMidyear"
                    Return error_GoalsMidyear
                Case "error_PartTimeJobs"
                    Return error_PartTimeJobs
                Case "error_ProgressSem1"
                    Return error_ProgressSem1
                Case "error_ProgressSem2"
                    Return error_ProgressSem2
                Case "error_WorkExp910"
                    Return error_WorkExp910
                Case "error_EndYearDisc"
                    Return error_EndYearDisc
                Case "error_EndYearLogged"
                    Return error_EndYearLogged
                Case "SUPPORT_KEY_PROFESSIONAL_NAME2"
                    Return SUPPORT_KEY_PROFESSIONAL_NAME2
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT2"
                    Return SUPPORT_KEY_PROFESSIONAL_CONTACT2
                Case "cbENROL_FILE_CHECKED"
                    Return cbENROL_FILE_CHECKED
                Case "Hidden_COMM_CONTACT_TYPE_MULTI"
                    Return Hidden_COMM_CONTACT_TYPE_MULTI
                Case "error_LPDone"
                    Return error_LPDone
                Case "Link1"
                    Return Link1
                Case "cbConfidentialDocuments"
                    Return cbConfidentialDocuments
                Case "cbRiskFactors"
                    Return cbRiskFactors
                Case "COMM_INTAKE_CONTACT_TYPE_MULTI"
                    Return COMM_INTAKE_CONTACT_TYPE_MULTI
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE"
                    Return SUPPORT_KEY_PROFESSIONAL_ROLE
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE2"
                    Return SUPPORT_KEY_PROFESSIONAL_ROLE2
                Case "SUPPORT_KEY_PROFESSIONAL_NAME3"
                    Return SUPPORT_KEY_PROFESSIONAL_NAME3
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE3"
                    Return SUPPORT_KEY_PROFESSIONAL_ROLE3
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT3"
                    Return SUPPORT_KEY_PROFESSIONAL_CONTACT3
                Case "SUPPORT_DOCS_YOUNG_ADULT1"
                    Return SUPPORT_DOCS_YOUNG_ADULT1
                Case "Link2"
                    Return Link2
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "BACKGROUND_INFO"
                    BACKGROUND_INFO = CType(value, TextField)
                Case "ENROL_REASONS"
                    ENROL_REASONS = CType(value, TextField)
                Case "WELLBEING_INCLUSION_CONCERNS"
                    WELLBEING_INCLUSION_CONCERNS = CType(value, TextField)
                Case "EXPECT_RETURN_TO_SCHOOL"
                    EXPECT_RETURN_TO_SCHOOL = CType(value, TextField)
                Case "RETURN_STUDENT"
                    RETURN_STUDENT = CType(value, TextField)
                Case "KNOWN_WELLBEING"
                    KNOWN_WELLBEING = CType(value, TextField)
                Case "KNOWN_INCLUSION"
                    KNOWN_INCLUSION = CType(value, TextField)
                Case "KNOWN_PATHWAYS"
                    KNOWN_PATHWAYS = CType(value, TextField)
                Case "SUPPORT_DOCS_AGENCY_REFERRAL"
                    SUPPORT_DOCS_AGENCY_REFERRAL = CType(value, TextField)
                Case "SUPPORT_DOCS_SCHOOL_REFERRAL"
                    SUPPORT_DOCS_SCHOOL_REFERRAL = CType(value, TextField)
                Case "SUPPORT_DOCS_YOUNG_ADULT"
                    SUPPORT_DOCS_YOUNG_ADULT = CType(value, TextField)
                Case "SUPPORT_DOCS_OTHER"
                    SUPPORT_DOCS_OTHER = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_NAME"
                    SUPPORT_KEY_PROFESSIONAL_NAME = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT"
                    SUPPORT_KEY_PROFESSIONAL_CONTACT = CType(value, TextField)
                Case "ENGAGEMENT_HOBBIES_INTERESTS"
                    ENGAGEMENT_HOBBIES_INTERESTS = CType(value, TextField)
                Case "COMM_VISIT_FLAG"
                    COMM_VISIT_FLAG = CType(value, TextField)
                Case "COMM_VISIT_DATE"
                    COMM_VISIT_DATE = CType(value, DateField)
                Case "COMM_CONTACT_TYPE"
                    COMM_CONTACT_TYPE = CType(value, TextField)
                Case "COMM_CONTACT_TYPE_OTHER"
                    COMM_CONTACT_TYPE_OTHER = CType(value, TextField)
                Case "COMM_PHONE_CONTACT"
                    COMM_PHONE_CONTACT = CType(value, TextField)
                Case "CARER_CONTACT_METHOD"
                    CARER_CONTACT_METHOD = CType(value, TextField)
                Case "CARER_SUPERVISOR_NAME"
                    CARER_SUPERVISOR_NAME = CType(value, TextField)
                Case "CARER_SUPERVISOR_ROLE"
                    CARER_SUPERVISOR_ROLE = CType(value, TextField)
                Case "CARER_ADDITIONAL"
                    CARER_ADDITIONAL = CType(value, TextField)
                Case "ORGANISATION_WHENWHERE"
                    ORGANISATION_WHENWHERE = CType(value, TextField)
                Case "ORGANISATION_TIMETABLE"
                    ORGANISATION_TIMETABLE = CType(value, TextField)
                Case "ORGANISATION_HARDWARE"
                    ORGANISATION_HARDWARE = CType(value, TextField)
                Case "ORGANISATION_ACCESS_INTERNET"
                    ORGANISATION_ACCESS_INTERNET = CType(value, TextField)
                Case "ORGANISATION_PREVIOUS_SCHOOL"
                    ORGANISATION_PREVIOUS_SCHOOL = CType(value, TextField)
                Case "ORGANISATION_ACADEMIC_HISTORY"
                    ORGANISATION_ACADEMIC_HISTORY = CType(value, TextField)
                Case "ORGANISATION_RECENTREPORT_FILED"
                    ORGANISATION_RECENTREPORT_FILED = CType(value, TextField)
                Case "LAUNCH_PAD_DONE"
                    LAUNCH_PAD_DONE = CType(value, TextField)
                Case "LAUNCH_PAD_DONE_DATE"
                    LAUNCH_PAD_DONE_DATE = CType(value, DateField)
                Case "LEARNING_PROGRAM"
                    LEARNING_PROGRAM = CType(value, TextField)
                Case "LEARNING_PROGRAM_DETAILS"
                    LEARNING_PROGRAM_DETAILS = CType(value, TextField)
                Case "LEARNING_PROGRAM_CONSULT"
                    LEARNING_PROGRAM_CONSULT = CType(value, TextField)
                Case "LEARNING_GOALS"
                    LEARNING_GOALS = CType(value, TextField)
                Case "SPECIAL_PROVISION_FLAG"
                    SPECIAL_PROVISION_FLAG = CType(value, TextField)
                Case "SPECIAL_PROVISION_DETAILS"
                    SPECIAL_PROVISION_DETAILS = CType(value, TextField)
                Case "PATHWAYS_CAREER_PLAN_FLAG"
                    PATHWAYS_CAREER_PLAN_FLAG = CType(value, TextField)
                Case "PATHWAYS_CAREER_GOALS"
                    PATHWAYS_CAREER_GOALS = CType(value, TextField)
                Case "PATHWAYS_CAREER_GOALS_MIDYEAR"
                    PATHWAYS_CAREER_GOALS_MIDYEAR = CType(value, TextField)
                Case "PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"
                    PATHWAYS_CAREER_GOALS_MIDYEAR_DATE = CType(value, DateField)
                Case "PATHWAYS_WORKEXP_FLAG"
                    PATHWAYS_WORKEXP_FLAG = CType(value, TextField)
                Case "PATHWAYS_WORKEXP_DETAILS"
                    PATHWAYS_WORKEXP_DETAILS = CType(value, TextField)
                Case "PATHWAYS_PARTTIMEJOBS"
                    PATHWAYS_PARTTIMEJOBS = CType(value, TextField)
                Case "PATHWAYS_ENDYEAR_INTENTIONS_FLAG"
                    PATHWAYS_ENDYEAR_INTENTIONS_FLAG = CType(value, TextField)
                Case "PATHWAYS_ENDYEAR_INTENTIONS_DATE"
                    PATHWAYS_ENDYEAR_INTENTIONS_DATE = CType(value, DateField)
                Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"
                    PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG = CType(value, TextField)
                Case "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"
                    PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE = CType(value, DateField)
                Case "REVIEW_PROGRESS_END_SEM1"
                    REVIEW_PROGRESS_END_SEM1 = CType(value, TextField)
                Case "REVIEW_PROGRESS_END_SEM2"
                    REVIEW_PROGRESS_END_SEM2 = CType(value, TextField)
                Case "lblLearningProgram"
                    lblLearningProgram = CType(value, TextField)
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
                Case "lblEnrolYear"
                    lblEnrolYear = CType(value, TextField)
                Case "LAST_ALTERED_BY1"
                    LAST_ALTERED_BY1 = CType(value, TextField)
                Case "LAST_ALTERED_DATE1"
                    LAST_ALTERED_DATE1 = CType(value, DateField)
                Case "hidden_LastUpdatedBy"
                    hidden_LastUpdatedBy = CType(value, TextField)
                Case "hidden_LastUpdatedWhen"
                    hidden_LastUpdatedWhen = CType(value, DateField)
                Case "Hidden_LEARNING_PROGRAM_CONSULT"
                    Hidden_LEARNING_PROGRAM_CONSULT = CType(value, TextField)
                Case "ASSESS_ENGLANG_LP"
                    ASSESS_ENGLANG_LP = CType(value, TextField)
                Case "ASSESS_ENGLANG_RL"
                    ASSESS_ENGLANG_RL = CType(value, TextField)
                Case "ASSESS_MATH_LP"
                    ASSESS_MATH_LP = CType(value, TextField)
                Case "ASSESS_MATH_RL"
                    ASSESS_MATH_RL = CType(value, TextField)
                Case "ASSESS_PATSCIENCE_LP"
                    ASSESS_PATSCIENCE_LP = CType(value, TextField)
                Case "ASSESS_PATSCIENCE_RL"
                    ASSESS_PATSCIENCE_RL = CType(value, TextField)
                Case "error_BackgroundInfo"
                    error_BackgroundInfo = CType(value, TextField)
                Case "error_ReasonsEnrol"
                    error_ReasonsEnrol = CType(value, TextField)
                Case "error_StudentWellbeing"
                    error_StudentWellbeing = CType(value, TextField)
                Case "error_ReturnMainstream"
                    error_ReturnMainstream = CType(value, TextField)
                Case "error_ReturningStudent"
                    error_ReturningStudent = CType(value, TextField)
                Case "error_StudentWellbeing2"
                    error_StudentWellbeing2 = CType(value, TextField)
                Case "error_StudentInclusion"
                    error_StudentInclusion = CType(value, TextField)
                Case "error_PrevPathways"
                    error_PrevPathways = CType(value, TextField)
                Case "error_SupportDocs"
                    error_SupportDocs = CType(value, TextField)
                Case "error_HobbiesInterests"
                    error_HobbiesInterests = CType(value, TextField)
                Case "error_CommsVisit"
                    error_CommsVisit = CType(value, TextField)
                Case "error_ContactType"
                    error_ContactType = CType(value, TextField)
                Case "error_CarerContactMethod"
                    error_CarerContactMethod = CType(value, TextField)
                Case "error_SupervisorName"
                    error_SupervisorName = CType(value, TextField)
                Case "error_SupervisorRole"
                    error_SupervisorRole = CType(value, TextField)
                Case "error_KeyProfSupports"
                    error_KeyProfSupports = CType(value, TextField)
                Case "error_AddCarerInfo"
                    error_AddCarerInfo = CType(value, TextField)
                Case "error_Workspace"
                    error_Workspace = CType(value, TextField)
                Case "error_OrgHardware"
                    error_OrgHardware = CType(value, TextField)
                Case "error_OrgInternet"
                    error_OrgInternet = CType(value, TextField)
                Case "error_OrgPrevSchools"
                    error_OrgPrevSchools = CType(value, TextField)
                Case "error_OrgAcademic"
                    error_OrgAcademic = CType(value, TextField)
                Case "error_AssessData"
                    error_AssessData = CType(value, TextField)
                Case "error_LearnDetails"
                    error_LearnDetails = CType(value, TextField)
                Case "error_LearnGoals"
                    error_LearnGoals = CType(value, TextField)
                Case "error_SpecialProvision"
                    error_SpecialProvision = CType(value, TextField)
                Case "error_Goals"
                    error_Goals = CType(value, TextField)
                Case "error_GoalsMidyear"
                    error_GoalsMidyear = CType(value, TextField)
                Case "error_PartTimeJobs"
                    error_PartTimeJobs = CType(value, TextField)
                Case "error_ProgressSem1"
                    error_ProgressSem1 = CType(value, TextField)
                Case "error_ProgressSem2"
                    error_ProgressSem2 = CType(value, TextField)
                Case "error_WorkExp910"
                    error_WorkExp910 = CType(value, TextField)
                Case "error_EndYearDisc"
                    error_EndYearDisc = CType(value, TextField)
                Case "error_EndYearLogged"
                    error_EndYearLogged = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_NAME2"
                    SUPPORT_KEY_PROFESSIONAL_NAME2 = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT2"
                    SUPPORT_KEY_PROFESSIONAL_CONTACT2 = CType(value, TextField)
                Case "cbENROL_FILE_CHECKED"
                    cbENROL_FILE_CHECKED = CType(value, TextField)
                Case "Hidden_COMM_CONTACT_TYPE_MULTI"
                    Hidden_COMM_CONTACT_TYPE_MULTI = CType(value, TextField)
                Case "error_LPDone"
                    error_LPDone = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "cbConfidentialDocuments"
                    cbConfidentialDocuments = CType(value, TextField)
                Case "cbRiskFactors"
                    cbRiskFactors = CType(value, BooleanField)
                Case "COMM_INTAKE_CONTACT_TYPE_MULTI"
                    COMM_INTAKE_CONTACT_TYPE_MULTI = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE"
                    SUPPORT_KEY_PROFESSIONAL_ROLE = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE2"
                    SUPPORT_KEY_PROFESSIONAL_ROLE2 = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_NAME3"
                    SUPPORT_KEY_PROFESSIONAL_NAME3 = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_ROLE3"
                    SUPPORT_KEY_PROFESSIONAL_ROLE3 = CType(value, TextField)
                Case "SUPPORT_KEY_PROFESSIONAL_CONTACT3"
                    SUPPORT_KEY_PROFESSIONAL_CONTACT3 = CType(value, TextField)
                Case "SUPPORT_DOCS_YOUNG_ADULT1"
                    SUPPORT_DOCS_YOUNG_ADULT1 = CType(value, TextField)
                Case "Link2"
                    Link2 = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As STUDENT_PROFILE1DataProvider)
'End Record STUDENT_PROFILE1 Item Class

'STUDENT_ID validate @9-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @10-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'TextArea BACKGROUND_INFO Event OnValidate. Action Validate Maximum Length @142-0F3C3B68
        If Not (BACKGROUND_INFO.Value Is Nothing) AndAlso BACKGROUND_INFO.Value.ToString().Length > 400 Then
            errors.Add("BACKGROUND_INFO",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","BACKGROUND INFO","400"))
        End If
'End TextArea BACKGROUND_INFO Event OnValidate. Action Validate Maximum Length

'TextArea ENROL_REASONS Event OnValidate. Action Validate Maximum Length @143-D7735CE0
        If Not (ENROL_REASONS.Value Is Nothing) AndAlso ENROL_REASONS.Value.ToString().Length > 400 Then
            errors.Add("ENROL_REASONS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","ENROL REASONS","400"))
        End If
'End TextArea ENROL_REASONS Event OnValidate. Action Validate Maximum Length

'TextArea WELLBEING_INCLUSION_CONCERNS Event OnValidate. Action Validate Maximum Length @144-90AF3106
        If Not (WELLBEING_INCLUSION_CONCERNS.Value Is Nothing) AndAlso WELLBEING_INCLUSION_CONCERNS.Value.ToString().Length > 400 Then
            errors.Add("WELLBEING_INCLUSION_CONCERNS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","WELLBEING INCLUSION CONCERNS","400"))
        End If
'End TextArea WELLBEING_INCLUSION_CONCERNS Event OnValidate. Action Validate Maximum Length

'TextArea EXPECT_RETURN_TO_SCHOOL Event OnValidate. Action Validate Maximum Length @147-52E54DA0
        If Not (EXPECT_RETURN_TO_SCHOOL.Value Is Nothing) AndAlso EXPECT_RETURN_TO_SCHOOL.Value.ToString().Length > 400 Then
            errors.Add("EXPECT_RETURN_TO_SCHOOL",String.Format("Input cannot exceed 400 characters","EXPECT RETURN TO SCHOOL","400"))
        End If
'End TextArea EXPECT_RETURN_TO_SCHOOL Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_DOCS_OTHER Event OnValidate. Action Validate Maximum Length @145-48605964
        If Not (SUPPORT_DOCS_OTHER.Value Is Nothing) AndAlso SUPPORT_DOCS_OTHER.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_DOCS_OTHER",String.Format("Input cannot exceed 50 characters","SUPPORT DOCS OTHER","50"))
        End If
'End TextBox SUPPORT_DOCS_OTHER Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_NAME Event OnValidate. Action Validate Maximum Length @148-F006965C
        If Not (SUPPORT_KEY_PROFESSIONAL_NAME.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_NAME.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_NAME",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL NAME","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_NAME Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT Event OnValidate. Action Validate Maximum Length @149-FD5BD07E
        If Not (SUPPORT_KEY_PROFESSIONAL_CONTACT.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_CONTACT.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_CONTACT",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL CONTACT","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT Event OnValidate. Action Validate Maximum Length

'TextArea ENGAGEMENT_HOBBIES_INTERESTS Event OnValidate. Action Validate Maximum Length @150-C3A30DF4
        If Not (ENGAGEMENT_HOBBIES_INTERESTS.Value Is Nothing) AndAlso ENGAGEMENT_HOBBIES_INTERESTS.Value.ToString().Length > 400 Then
            errors.Add("ENGAGEMENT_HOBBIES_INTERESTS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","ENGAGEMENT HOBBIES INTERESTS","400"))
        End If
'End TextArea ENGAGEMENT_HOBBIES_INTERESTS Event OnValidate. Action Validate Maximum Length

'TextArea COMM_CONTACT_TYPE_OTHER Event OnValidate. Action Validate Maximum Length @151-F066D6AC
        If Not (COMM_CONTACT_TYPE_OTHER.Value Is Nothing) AndAlso COMM_CONTACT_TYPE_OTHER.Value.ToString().Length > 200 Then
            errors.Add("COMM_CONTACT_TYPE_OTHER",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","COMM CONTACT TYPE OTHER","200"))
        End If
'End TextArea COMM_CONTACT_TYPE_OTHER Event OnValidate. Action Validate Maximum Length

'TextArea CARER_CONTACT_METHOD Event OnValidate. Action Validate Maximum Length @152-4B5BE59C
        If Not (CARER_CONTACT_METHOD.Value Is Nothing) AndAlso CARER_CONTACT_METHOD.Value.ToString().Length > 50 Then
            errors.Add("CARER_CONTACT_METHOD",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","CARER CONTACT METHOD","50"))
        End If
'End TextArea CARER_CONTACT_METHOD Event OnValidate. Action Validate Maximum Length

'TextBox CARER_SUPERVISOR_NAME Event OnValidate. Action Validate Maximum Length @153-0C1C5147
        If Not (CARER_SUPERVISOR_NAME.Value Is Nothing) AndAlso CARER_SUPERVISOR_NAME.Value.ToString().Length > 50 Then
            errors.Add("CARER_SUPERVISOR_NAME",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","CARER SUPERVISOR NAME","50"))
        End If
'End TextBox CARER_SUPERVISOR_NAME Event OnValidate. Action Validate Maximum Length

'TextBox CARER_ADDITIONAL Event OnValidate. Action Validate Maximum Length @154-C16471B1
        If Not (CARER_ADDITIONAL.Value Is Nothing) AndAlso CARER_ADDITIONAL.Value.ToString().Length > 100 Then
            errors.Add("CARER_ADDITIONAL",String.Format("<span class='errormsg'> Input cannot exceed 100 characters</span>","CARER ADDITIONAL","100"))
        End If
'End TextBox CARER_ADDITIONAL Event OnValidate. Action Validate Maximum Length

'TextArea ORGANISATION_WHENWHERE Event OnValidate. Action Validate Maximum Length @157-51BF0889
        If Not (ORGANISATION_WHENWHERE.Value Is Nothing) AndAlso ORGANISATION_WHENWHERE.Value.ToString().Length > 200 Then
            errors.Add("ORGANISATION_WHENWHERE",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","ORGANISATION WHENWHERE","200"))
        End If
'End TextArea ORGANISATION_WHENWHERE Event OnValidate. Action Validate Maximum Length

'TextArea ORGANISATION_ACCESS_INTERNET Event OnValidate. Action Validate Maximum Length @158-A9B93BE6
        If Not (ORGANISATION_ACCESS_INTERNET.Value Is Nothing) AndAlso ORGANISATION_ACCESS_INTERNET.Value.ToString().Length > 200 Then
            errors.Add("ORGANISATION_ACCESS_INTERNET",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","ORGANISATION ACCESS INTERNET","200"))
        End If
'End TextArea ORGANISATION_ACCESS_INTERNET Event OnValidate. Action Validate Maximum Length

'TextArea ORGANISATION_PREVIOUS_SCHOOL Event OnValidate. Action Validate Maximum Length @159-369143FE
        If Not (ORGANISATION_PREVIOUS_SCHOOL.Value Is Nothing) AndAlso ORGANISATION_PREVIOUS_SCHOOL.Value.ToString().Length > 200 Then
            errors.Add("ORGANISATION_PREVIOUS_SCHOOL",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","ORGANISATION PREVIOUS SCHOOL","200"))
        End If
'End TextArea ORGANISATION_PREVIOUS_SCHOOL Event OnValidate. Action Validate Maximum Length

'TextArea ORGANISATION_ACADEMIC_HISTORY Event OnValidate. Action Validate Maximum Length @160-106F28F4
        If Not (ORGANISATION_ACADEMIC_HISTORY.Value Is Nothing) AndAlso ORGANISATION_ACADEMIC_HISTORY.Value.ToString().Length > 400 Then
            errors.Add("ORGANISATION_ACADEMIC_HISTORY",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","ORGANISATION ACADEMIC HISTORY","400"))
        End If
'End TextArea ORGANISATION_ACADEMIC_HISTORY Event OnValidate. Action Validate Maximum Length

'TextArea LEARNING_PROGRAM_DETAILS Event OnValidate. Action Validate Maximum Length @161-E60A5C88
        If Not (LEARNING_PROGRAM_DETAILS.Value Is Nothing) AndAlso LEARNING_PROGRAM_DETAILS.Value.ToString().Length > 200 Then
            errors.Add("LEARNING_PROGRAM_DETAILS",String.Format("<span class='errormsg'> Input cannot exceed 200 characters</span>","LEARNING PROGRAM DETAILS","200"))
        End If
'End TextArea LEARNING_PROGRAM_DETAILS Event OnValidate. Action Validate Maximum Length

'TextArea LEARNING_GOALS Event OnValidate. Action Validate Maximum Length @162-7DEB15A5
        If Not (LEARNING_GOALS.Value Is Nothing) AndAlso LEARNING_GOALS.Value.ToString().Length > 800 Then
            errors.Add("LEARNING_GOALS",String.Format("<span class='errormsg'> Input cannot exceed 800 characters</span>","LEARNING GOALS","800"))
        End If
'End TextArea LEARNING_GOALS Event OnValidate. Action Validate Maximum Length

'TextArea SPECIAL_PROVISION_DETAILS Event OnValidate. Action Validate Maximum Length @163-01195E52
        If Not (SPECIAL_PROVISION_DETAILS.Value Is Nothing) AndAlso SPECIAL_PROVISION_DETAILS.Value.ToString().Length > 400 Then
            errors.Add("SPECIAL_PROVISION_DETAILS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","SPECIAL PROVISION DETAILS","400"))
        End If
'End TextArea SPECIAL_PROVISION_DETAILS Event OnValidate. Action Validate Maximum Length

'TextArea PATHWAYS_CAREER_GOALS Event OnValidate. Action Validate Maximum Length @164-BA3D8676
        If Not (PATHWAYS_CAREER_GOALS.Value Is Nothing) AndAlso PATHWAYS_CAREER_GOALS.Value.ToString().Length > 800 Then
            errors.Add("PATHWAYS_CAREER_GOALS",String.Format("<span class='errormsg'> Input cannot exceed 800 characters</span>","PATHWAYS CAREER GOALS","800"))
        End If
'End TextArea PATHWAYS_CAREER_GOALS Event OnValidate. Action Validate Maximum Length

'TextArea PATHWAYS_CAREER_GOALS_MIDYEAR Event OnValidate. Action Validate Maximum Length @165-A1B86911
        If Not (PATHWAYS_CAREER_GOALS_MIDYEAR.Value Is Nothing) AndAlso PATHWAYS_CAREER_GOALS_MIDYEAR.Value.ToString().Length > 400 Then
            errors.Add("PATHWAYS_CAREER_GOALS_MIDYEAR",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","PATHWAYS CAREER GOALS MIDYEAR","400"))
        End If
'End TextArea PATHWAYS_CAREER_GOALS_MIDYEAR Event OnValidate. Action Validate Maximum Length

'TextArea PATHWAYS_WORKEXP_DETAILS Event OnValidate. Action Validate Maximum Length @166-17154DE7
        If Not (PATHWAYS_WORKEXP_DETAILS.Value Is Nothing) AndAlso PATHWAYS_WORKEXP_DETAILS.Value.ToString().Length > 400 Then
            errors.Add("PATHWAYS_WORKEXP_DETAILS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","PATHWAYS WORKEXP DETAILS","400"))
        End If
'End TextArea PATHWAYS_WORKEXP_DETAILS Event OnValidate. Action Validate Maximum Length

'TextArea PATHWAYS_PARTTIMEJOBS Event OnValidate. Action Validate Maximum Length @167-4E53FC6F
        If Not (PATHWAYS_PARTTIMEJOBS.Value Is Nothing) AndAlso PATHWAYS_PARTTIMEJOBS.Value.ToString().Length > 400 Then
            errors.Add("PATHWAYS_PARTTIMEJOBS",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","PATHWAYS PARTTIMEJOBS","400"))
        End If
'End TextArea PATHWAYS_PARTTIMEJOBS Event OnValidate. Action Validate Maximum Length

'TextArea REVIEW_PROGRESS_END_SEM1 Event OnValidate. Action Validate Maximum Length @168-B4D2E683
        If Not (REVIEW_PROGRESS_END_SEM1.Value Is Nothing) AndAlso REVIEW_PROGRESS_END_SEM1.Value.ToString().Length > 400 Then
            errors.Add("REVIEW_PROGRESS_END_SEM1",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","REVIEW PROGRESS END SEM1","400"))
        End If
'End TextArea REVIEW_PROGRESS_END_SEM1 Event OnValidate. Action Validate Maximum Length

'TextArea REVIEW_PROGRESS_END_SEM2 Event OnValidate. Action Validate Maximum Length @169-0D0F8261
        If Not (REVIEW_PROGRESS_END_SEM2.Value Is Nothing) AndAlso REVIEW_PROGRESS_END_SEM2.Value.ToString().Length > 400 Then
            errors.Add("REVIEW_PROGRESS_END_SEM2",String.Format("<span class='errormsg'> Input cannot exceed 400 characters</span>","REVIEW PROGRESS END SEM2","400"))
        End If
'End TextArea REVIEW_PROGRESS_END_SEM2 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_NAME2 Event OnValidate. Action Validate Maximum Length @189-8C0711F0
        If Not (SUPPORT_KEY_PROFESSIONAL_NAME2.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_NAME2.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_NAME2",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL NAME 2","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_NAME2 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT2 Event OnValidate. Action Validate Maximum Length @193-701221A7
        If Not (SUPPORT_KEY_PROFESSIONAL_CONTACT2.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_CONTACT2.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_CONTACT2",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL CONTACT 2","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT2 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_ROLE Event OnValidate. Action Validate Maximum Length @231-07B09235
        If Not (SUPPORT_KEY_PROFESSIONAL_ROLE.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_ROLE.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_ROLE",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL NAME","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_ROLE Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_ROLE2 Event OnValidate. Action Validate Maximum Length @233-08A86FC9
        If Not (SUPPORT_KEY_PROFESSIONAL_ROLE2.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_ROLE2.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_ROLE2",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL ROLE 2","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_ROLE2 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_NAME3 Event OnValidate. Action Validate Maximum Length @235-0DAE878A
        If Not (SUPPORT_KEY_PROFESSIONAL_NAME3.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_NAME3.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_NAME3",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL NAME 3","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_NAME3 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_ROLE3 Event OnValidate. Action Validate Maximum Length @239-8901F9B3
        If Not (SUPPORT_KEY_PROFESSIONAL_ROLE3.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_ROLE3.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_ROLE3",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL ROLE 3","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_ROLE3 Event OnValidate. Action Validate Maximum Length

'TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT3 Event OnValidate. Action Validate Maximum Length @243-0BFFD7C6
        If Not (SUPPORT_KEY_PROFESSIONAL_CONTACT3.Value Is Nothing) AndAlso SUPPORT_KEY_PROFESSIONAL_CONTACT3.Value.ToString().Length > 50 Then
            errors.Add("SUPPORT_KEY_PROFESSIONAL_CONTACT3",String.Format("<span class='errormsg'> Input cannot exceed 50 characters</span>","SUPPORT KEY PROFESSIONAL CONTACT 3","50"))
        End If
'End TextBox SUPPORT_KEY_PROFESSIONAL_CONTACT3 Event OnValidate. Action Validate Maximum Length

'Record STUDENT_PROFILE1 Event OnValidate. Action Custom Code @214-73254650
    ' -------------------------
      'Sept-2018|EA| if any Errors, then change text on main error BLAHBLAH
    If (errors.Count > 0) Then
    	errors.Add("Form",String.Format("Check errors! Scroll down {0} page to check for errors!","STUDENT_PROFILE1"))
    End If
    'errors.Add("STUDENT_PROFILE1",String.Format("Ummmm is this thing on?","STUDENT_PROFILE1"))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event OnValidate. Action Custom Code

'Record STUDENT_PROFILE1 Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record STUDENT_PROFILE1 Item Class tail

'Record STUDENT_PROFILE1 Data Provider Class @3-541A4E75
Public Class STUDENT_PROFILE1DataProvider
Inherits RecordDataProviderBase
'End Record STUDENT_PROFILE1 Data Provider Class

'Record STUDENT_PROFILE1 Data Provider Class Variables @3-4BE0A8E2
    Public UrlSTUDENT_ID As IntegerParameter
    Public UrlENROLMENT_YEAR As IntegerParameter
    Protected item As STUDENT_PROFILE1Item
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record STUDENT_PROFILE1 Data Provider Class Variables

'Record STUDENT_PROFILE1 Data Provider Class Constructor @3-A47F591C

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_PROFILE {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID206","And","ENROLMENT_YEAR207"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class Constructor

'Record STUDENT_PROFILE1 Data Provider Class LoadParams Method @3-79390024

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSTUDENT_ID) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record STUDENT_PROFILE1 Data Provider Class LoadParams Method

'Record STUDENT_PROFILE1 Data Provider Class CheckUnique Method @3-3A6AF9CA

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As STUDENT_PROFILE1Item) As Boolean
        Return True
    End Function
'End Record STUDENT_PROFILE1 Data Provider Class CheckUnique Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method @3-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class PrepareInsert Method tail

'Record STUDENT_PROFILE1 Data Provider Class Insert Method @3-1E441B92

    Public Function InsertItem(ByVal item As STUDENT_PROFILE1Item) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_PROFILE({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_PROFILE1 Data Provider Class Insert Method

'Record STUDENT_PROFILE1 Build insert @3-F787DAD3
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.BACKGROUND_INFO.IsEmpty Then
        allEmptyFlag = item.BACKGROUND_INFO.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "BACKGROUND_INFO,"
        valuesList = valuesList & Insert.Dao.ToSql(item.BACKGROUND_INFO.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROL_REASONS.IsEmpty Then
        allEmptyFlag = item.ENROL_REASONS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROL_REASONS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROL_REASONS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.WELLBEING_INCLUSION_CONCERNS.IsEmpty Then
        allEmptyFlag = item.WELLBEING_INCLUSION_CONCERNS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "WELLBEING_INCLUSION_CONCERNS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.WELLBEING_INCLUSION_CONCERNS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EXPECT_RETURN_TO_SCHOOL.IsEmpty Then
        allEmptyFlag = item.EXPECT_RETURN_TO_SCHOOL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "EXPECT_RETURN_TO_SCHOOL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.EXPECT_RETURN_TO_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RETURN_STUDENT.IsEmpty Then
        allEmptyFlag = item.RETURN_STUDENT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "RETURN_STUDENT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RETURN_STUDENT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_WELLBEING.IsEmpty Then
        allEmptyFlag = item.KNOWN_WELLBEING.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KNOWN_WELLBEING,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KNOWN_WELLBEING.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_INCLUSION.IsEmpty Then
        allEmptyFlag = item.KNOWN_INCLUSION.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KNOWN_INCLUSION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KNOWN_INCLUSION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_PATHWAYS.IsEmpty Then
        allEmptyFlag = item.KNOWN_PATHWAYS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "KNOWN_PATHWAYS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.KNOWN_PATHWAYS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_AGENCY_REFERRAL.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_AGENCY_REFERRAL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_DOCS_AGENCY_REFERRAL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_DOCS_AGENCY_REFERRAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_SCHOOL_REFERRAL.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_SCHOOL_REFERRAL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_DOCS_SCHOOL_REFERRAL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_DOCS_SCHOOL_REFERRAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_YOUNG_ADULT.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_YOUNG_ADULT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_DOCS_YOUNG_ADULT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_DOCS_YOUNG_ADULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_OTHER.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_OTHER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_DOCS_OTHER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_DOCS_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_CONTACT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENGAGEMENT_HOBBIES_INTERESTS.IsEmpty Then
        allEmptyFlag = item.ENGAGEMENT_HOBBIES_INTERESTS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENGAGEMENT_HOBBIES_INTERESTS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENGAGEMENT_HOBBIES_INTERESTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_VISIT_FLAG.IsEmpty Then
        allEmptyFlag = item.COMM_VISIT_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_VISIT_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_VISIT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_VISIT_DATE.IsEmpty Then
        allEmptyFlag = item.COMM_VISIT_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_VISIT_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_VISIT_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.COMM_CONTACT_TYPE.IsEmpty Then
        allEmptyFlag = item.COMM_CONTACT_TYPE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_CONTACT_TYPE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_CONTACT_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_CONTACT_TYPE_OTHER.IsEmpty Then
        allEmptyFlag = item.COMM_CONTACT_TYPE_OTHER.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_CONTACT_TYPE_OTHER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_CONTACT_TYPE_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_PHONE_CONTACT.IsEmpty Then
        allEmptyFlag = item.COMM_PHONE_CONTACT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_PHONE_CONTACT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_PHONE_CONTACT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_CONTACT_METHOD.IsEmpty Then
        allEmptyFlag = item.CARER_CONTACT_METHOD.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CARER_CONTACT_METHOD,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CARER_CONTACT_METHOD.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_SUPERVISOR_NAME.IsEmpty Then
        allEmptyFlag = item.CARER_SUPERVISOR_NAME.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CARER_SUPERVISOR_NAME,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CARER_SUPERVISOR_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_SUPERVISOR_ROLE.IsEmpty Then
        allEmptyFlag = item.CARER_SUPERVISOR_ROLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CARER_SUPERVISOR_ROLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CARER_SUPERVISOR_ROLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_ADDITIONAL.IsEmpty Then
        allEmptyFlag = item.CARER_ADDITIONAL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CARER_ADDITIONAL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CARER_ADDITIONAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_WHENWHERE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_WHENWHERE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_WHENWHERE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_WHENWHERE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_TIMETABLE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_TIMETABLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_TIMETABLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_TIMETABLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_HARDWARE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_HARDWARE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_HARDWARE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_HARDWARE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_ACCESS_INTERNET.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_ACCESS_INTERNET.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_ACCESS_INTERNET,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_ACCESS_INTERNET.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_PREVIOUS_SCHOOL.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_PREVIOUS_SCHOOL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_PREVIOUS_SCHOOL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_PREVIOUS_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_ACADEMIC_HISTORY.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_ACADEMIC_HISTORY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_ACADEMIC_HISTORY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_ACADEMIC_HISTORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_RECENTREPORT_FILED.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_RECENTREPORT_FILED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ORGANISATION_RECENTREPORT_FILED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ORGANISATION_RECENTREPORT_FILED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAUNCH_PAD_DONE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAUNCH_PAD_DONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE_DATE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAUNCH_PAD_DONE_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAUNCH_PAD_DONE_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LEARNING_PROGRAM.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEARNING_PROGRAM.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_PROGRAM_DETAILS.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM_DETAILS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM_DETAILS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEARNING_PROGRAM_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_GOALS.IsEmpty Then
        allEmptyFlag = item.LEARNING_GOALS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_GOALS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LEARNING_GOALS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SPECIAL_PROVISION_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SPECIAL_PROVISION_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_DETAILS.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_DETAILS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SPECIAL_PROVISION_DETAILS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SPECIAL_PROVISION_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_PLAN_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_PLAN_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_CAREER_PLAN_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_CAREER_PLAN_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_CAREER_GOALS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_CAREER_GOALS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS_MIDYEAR.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS_MIDYEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_CAREER_GOALS_MIDYEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_CAREER_GOALS_MIDYEAR.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_CAREER_GOALS_MIDYEAR_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.PATHWAYS_WORKEXP_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_WORKEXP_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_WORKEXP_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_WORKEXP_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_WORKEXP_DETAILS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_WORKEXP_DETAILS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_WORKEXP_DETAILS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_WORKEXP_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_PARTTIMEJOBS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_PARTTIMEJOBS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_PARTTIMEJOBS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_PARTTIMEJOBS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_ENDYEAR_INTENTIONS_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_ENDYEAR_INTENTIONS_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM1.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM1.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REVIEW_PROGRESS_END_SEM1,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM2.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "REVIEW_PROGRESS_END_SEM2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedBy.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedBy.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LastUpdatedBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedWhen.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedWhen.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.hidden_LastUpdatedWhen.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty Then
        allEmptyFlag = item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LEARNING_PROGRAM_CONSULT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_ENGLANG_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_ENGLANG_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_ENGLANG_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_ENGLANG_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_MATH_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_MATH_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_MATH_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_MATH_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_LP.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_PATSCIENCE_LP,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_PATSCIENCE_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_RL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ASSESS_PATSCIENCE_RL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ASSESS_PATSCIENCE_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_NAME2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_CONTACT2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbENROL_FILE_CHECKED.IsEmpty Then
        allEmptyFlag = item.cbENROL_FILE_CHECKED.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROL_FILE_CHECKED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.cbENROL_FILE_CHECKED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_COMM_CONTACT_TYPE_MULTI.IsEmpty Then
        allEmptyFlag = item.Hidden_COMM_CONTACT_TYPE_MULTI.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_CONTACT_TYPE_MULTI,"
        valuesList = valuesList & Insert.Dao.ToSql(item.Hidden_COMM_CONTACT_TYPE_MULTI.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbConfidentialDocuments.IsEmpty Then
        allEmptyFlag = item.cbConfidentialDocuments.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CONFIDENTIAL_DOCUMENTS_CHECKED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.cbConfidentialDocuments.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbRiskFactors.IsEmpty Then
        allEmptyFlag = item.cbRiskFactors.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "RISK_FACTORS_CHECKED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.cbRiskFactors.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.COMM_INTAKE_CONTACT_TYPE_MULTI.IsEmpty Then
        allEmptyFlag = item.COMM_INTAKE_CONTACT_TYPE_MULTI.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMM_INTAKE_CONTACT_TYPE_MULTI,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMM_INTAKE_CONTACT_TYPE_MULTI.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_ROLE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE2.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_ROLE2,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME3.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_NAME3,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE3.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_ROLE3,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_KEY_PROFESSIONAL_CONTACT3,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_YOUNG_ADULT1.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_YOUNG_ADULT1.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "SUPPORT_DOCS_SPORTS_PERFORMANCE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUPPORT_DOCS_YOUNG_ADULT1.GetFormattedValue(""),FieldType._Text) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record STUDENT_PROFILE1 Build insert

'Record STUDENT_PROFILE1 AfterExecuteInsert @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_PROFILE1 AfterExecuteInsert

'Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method @3-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method

'Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 Data Provider Class PrepareUpdate Method tail

'Record STUDENT_PROFILE1 Data Provider Class Update Method @3-F1B8AA58

    Public Function UpdateItem(ByVal item As STUDENT_PROFILE1Item) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE STUDENT_PROFILE SET {Values}", New String(){"STUDENT_ID206","And","ENROLMENT_YEAR207"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record STUDENT_PROFILE1 Data Provider Class Update Method

'DEL      ' -------------------------
'DEL        'Sept-2018|EA| if any Errors, then change text on main error BLAHBLAH
'DEL      If (errors.Count > 0) Then
'DEL      	errors.Add("Form",String.Format("BeforeBuildUpdate - Check errors! Scroll down {0} page to check for errors!","STUDENT_PROFILE1"))
'DEL      End If
'DEL      ' -------------------------


'Record STUDENT_PROFILE1 BeforeBuildUpdate @3-3A6DC659
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STUDENT_ID206",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ENROLMENT_YEAR207",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        valuesList = valuesList & "STUDENT_ID=" + Update.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROLMENT_YEAR=" + Update.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.BACKGROUND_INFO.IsEmpty Then
        allEmptyFlag = item.BACKGROUND_INFO.IsEmpty And allEmptyFlag
        valuesList = valuesList & "BACKGROUND_INFO=" + Update.Dao.ToSql(item.BACKGROUND_INFO.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENROL_REASONS.IsEmpty Then
        allEmptyFlag = item.ENROL_REASONS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROL_REASONS=" + Update.Dao.ToSql(item.ENROL_REASONS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.WELLBEING_INCLUSION_CONCERNS.IsEmpty Then
        allEmptyFlag = item.WELLBEING_INCLUSION_CONCERNS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "WELLBEING_INCLUSION_CONCERNS=" + Update.Dao.ToSql(item.WELLBEING_INCLUSION_CONCERNS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.EXPECT_RETURN_TO_SCHOOL.IsEmpty Then
        allEmptyFlag = item.EXPECT_RETURN_TO_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "EXPECT_RETURN_TO_SCHOOL=" + Update.Dao.ToSql(item.EXPECT_RETURN_TO_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RETURN_STUDENT.IsEmpty Then
        allEmptyFlag = item.RETURN_STUDENT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RETURN_STUDENT=" + Update.Dao.ToSql(item.RETURN_STUDENT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_WELLBEING.IsEmpty Then
        allEmptyFlag = item.KNOWN_WELLBEING.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KNOWN_WELLBEING=" + Update.Dao.ToSql(item.KNOWN_WELLBEING.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_INCLUSION.IsEmpty Then
        allEmptyFlag = item.KNOWN_INCLUSION.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KNOWN_INCLUSION=" + Update.Dao.ToSql(item.KNOWN_INCLUSION.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.KNOWN_PATHWAYS.IsEmpty Then
        allEmptyFlag = item.KNOWN_PATHWAYS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "KNOWN_PATHWAYS=" + Update.Dao.ToSql(item.KNOWN_PATHWAYS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_AGENCY_REFERRAL.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_AGENCY_REFERRAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_DOCS_AGENCY_REFERRAL=" + Update.Dao.ToSql(item.SUPPORT_DOCS_AGENCY_REFERRAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_SCHOOL_REFERRAL.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_SCHOOL_REFERRAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_DOCS_SCHOOL_REFERRAL=" + Update.Dao.ToSql(item.SUPPORT_DOCS_SCHOOL_REFERRAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_YOUNG_ADULT.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_YOUNG_ADULT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_DOCS_YOUNG_ADULT=" + Update.Dao.ToSql(item.SUPPORT_DOCS_YOUNG_ADULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_OTHER.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_DOCS_OTHER=" + Update.Dao.ToSql(item.SUPPORT_DOCS_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_NAME=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_CONTACT=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ENGAGEMENT_HOBBIES_INTERESTS.IsEmpty Then
        allEmptyFlag = item.ENGAGEMENT_HOBBIES_INTERESTS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENGAGEMENT_HOBBIES_INTERESTS=" + Update.Dao.ToSql(item.ENGAGEMENT_HOBBIES_INTERESTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_VISIT_FLAG.IsEmpty Then
        allEmptyFlag = item.COMM_VISIT_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_VISIT_FLAG=" + Update.Dao.ToSql(item.COMM_VISIT_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_VISIT_DATE.IsEmpty Then
        allEmptyFlag = item.COMM_VISIT_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_VISIT_DATE=" + Update.Dao.ToSql(item.COMM_VISIT_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.COMM_CONTACT_TYPE.IsEmpty Then
        allEmptyFlag = item.COMM_CONTACT_TYPE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_CONTACT_TYPE=" + Update.Dao.ToSql(item.COMM_CONTACT_TYPE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_CONTACT_TYPE_OTHER.IsEmpty Then
        allEmptyFlag = item.COMM_CONTACT_TYPE_OTHER.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_CONTACT_TYPE_OTHER=" + Update.Dao.ToSql(item.COMM_CONTACT_TYPE_OTHER.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMM_PHONE_CONTACT.IsEmpty Then
        allEmptyFlag = item.COMM_PHONE_CONTACT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_PHONE_CONTACT=" + Update.Dao.ToSql(item.COMM_PHONE_CONTACT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_CONTACT_METHOD.IsEmpty Then
        allEmptyFlag = item.CARER_CONTACT_METHOD.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CARER_CONTACT_METHOD=" + Update.Dao.ToSql(item.CARER_CONTACT_METHOD.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_SUPERVISOR_NAME.IsEmpty Then
        allEmptyFlag = item.CARER_SUPERVISOR_NAME.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CARER_SUPERVISOR_NAME=" + Update.Dao.ToSql(item.CARER_SUPERVISOR_NAME.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_SUPERVISOR_ROLE.IsEmpty Then
        allEmptyFlag = item.CARER_SUPERVISOR_ROLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CARER_SUPERVISOR_ROLE=" + Update.Dao.ToSql(item.CARER_SUPERVISOR_ROLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CARER_ADDITIONAL.IsEmpty Then
        allEmptyFlag = item.CARER_ADDITIONAL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CARER_ADDITIONAL=" + Update.Dao.ToSql(item.CARER_ADDITIONAL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_WHENWHERE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_WHENWHERE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_WHENWHERE=" + Update.Dao.ToSql(item.ORGANISATION_WHENWHERE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_TIMETABLE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_TIMETABLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_TIMETABLE=" + Update.Dao.ToSql(item.ORGANISATION_TIMETABLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_HARDWARE.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_HARDWARE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_HARDWARE=" + Update.Dao.ToSql(item.ORGANISATION_HARDWARE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_ACCESS_INTERNET.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_ACCESS_INTERNET.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_ACCESS_INTERNET=" + Update.Dao.ToSql(item.ORGANISATION_ACCESS_INTERNET.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_PREVIOUS_SCHOOL.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_PREVIOUS_SCHOOL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_PREVIOUS_SCHOOL=" + Update.Dao.ToSql(item.ORGANISATION_PREVIOUS_SCHOOL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_ACADEMIC_HISTORY.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_ACADEMIC_HISTORY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_ACADEMIC_HISTORY=" + Update.Dao.ToSql(item.ORGANISATION_ACADEMIC_HISTORY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ORGANISATION_RECENTREPORT_FILED.IsEmpty Then
        allEmptyFlag = item.ORGANISATION_RECENTREPORT_FILED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ORGANISATION_RECENTREPORT_FILED=" + Update.Dao.ToSql(item.ORGANISATION_RECENTREPORT_FILED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAUNCH_PAD_DONE=" + Update.Dao.ToSql(item.LAUNCH_PAD_DONE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAUNCH_PAD_DONE_DATE.IsEmpty Then
        allEmptyFlag = item.LAUNCH_PAD_DONE_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAUNCH_PAD_DONE_DATE=" + Update.Dao.ToSql(item.LAUNCH_PAD_DONE_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.LEARNING_PROGRAM.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM=" + Update.Dao.ToSql(item.LEARNING_PROGRAM.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_PROGRAM_DETAILS.IsEmpty Then
        allEmptyFlag = item.LEARNING_PROGRAM_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM_DETAILS=" + Update.Dao.ToSql(item.LEARNING_PROGRAM_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LEARNING_GOALS.IsEmpty Then
        allEmptyFlag = item.LEARNING_GOALS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_GOALS=" + Update.Dao.ToSql(item.LEARNING_GOALS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_FLAG.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SPECIAL_PROVISION_FLAG=" + Update.Dao.ToSql(item.SPECIAL_PROVISION_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SPECIAL_PROVISION_DETAILS.IsEmpty Then
        allEmptyFlag = item.SPECIAL_PROVISION_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SPECIAL_PROVISION_DETAILS=" + Update.Dao.ToSql(item.SPECIAL_PROVISION_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_PLAN_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_PLAN_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_CAREER_PLAN_FLAG=" + Update.Dao.ToSql(item.PATHWAYS_CAREER_PLAN_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_CAREER_GOALS=" + Update.Dao.ToSql(item.PATHWAYS_CAREER_GOALS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS_MIDYEAR.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS_MIDYEAR.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_CAREER_GOALS_MIDYEAR=" + Update.Dao.ToSql(item.PATHWAYS_CAREER_GOALS_MIDYEAR.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_CAREER_GOALS_MIDYEAR_DATE=" + Update.Dao.ToSql(item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.PATHWAYS_WORKEXP_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_WORKEXP_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_WORKEXP_FLAG=" + Update.Dao.ToSql(item.PATHWAYS_WORKEXP_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_WORKEXP_DETAILS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_WORKEXP_DETAILS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_WORKEXP_DETAILS=" + Update.Dao.ToSql(item.PATHWAYS_WORKEXP_DETAILS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_PARTTIMEJOBS.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_PARTTIMEJOBS.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_PARTTIMEJOBS=" + Update.Dao.ToSql(item.PATHWAYS_PARTTIMEJOBS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_ENDYEAR_INTENTIONS_FLAG=" + Update.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_ENDYEAR_INTENTIONS_DATE=" + Update.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG=" + Update.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.IsEmpty Then
        allEmptyFlag = item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE=" + Update.Dao.ToSql(item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM1.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM1.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REVIEW_PROGRESS_END_SEM1=" + Update.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.REVIEW_PROGRESS_END_SEM2.IsEmpty Then
        allEmptyFlag = item.REVIEW_PROGRESS_END_SEM2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "REVIEW_PROGRESS_END_SEM2=" + Update.Dao.ToSql(item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedBy.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedBy.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.hidden_LastUpdatedBy.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.hidden_LastUpdatedWhen.IsEmpty Then
        allEmptyFlag = item.hidden_LastUpdatedWhen.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.hidden_LastUpdatedWhen.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        If Not item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty Then
        allEmptyFlag = item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LEARNING_PROGRAM_CONSULT=" + Update.Dao.ToSql(item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_ENGLANG_LP=" + Update.Dao.ToSql(item.ASSESS_ENGLANG_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_ENGLANG_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_ENGLANG_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_ENGLANG_RL=" + Update.Dao.ToSql(item.ASSESS_ENGLANG_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_MATH_LP=" + Update.Dao.ToSql(item.ASSESS_MATH_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_MATH_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_MATH_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_MATH_RL=" + Update.Dao.ToSql(item.ASSESS_MATH_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_LP.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_LP.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_PATSCIENCE_LP=" + Update.Dao.ToSql(item.ASSESS_PATSCIENCE_LP.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.ASSESS_PATSCIENCE_RL.IsEmpty Then
        allEmptyFlag = item.ASSESS_PATSCIENCE_RL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ASSESS_PATSCIENCE_RL=" + Update.Dao.ToSql(item.ASSESS_PATSCIENCE_RL.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_NAME2=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_CONTACT2=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbENROL_FILE_CHECKED.IsEmpty Then
        allEmptyFlag = item.cbENROL_FILE_CHECKED.IsEmpty And allEmptyFlag
        valuesList = valuesList & "ENROL_FILE_CHECKED=" + Update.Dao.ToSql(item.cbENROL_FILE_CHECKED.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.Hidden_COMM_CONTACT_TYPE_MULTI.IsEmpty Then
        allEmptyFlag = item.Hidden_COMM_CONTACT_TYPE_MULTI.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_CONTACT_TYPE_MULTI=" + Update.Dao.ToSql(item.Hidden_COMM_CONTACT_TYPE_MULTI.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbConfidentialDocuments.IsEmpty Then
        allEmptyFlag = item.cbConfidentialDocuments.IsEmpty And allEmptyFlag
        valuesList = valuesList & "CONFIDENTIAL_DOCUMENTS_CHECKED=" + Update.Dao.ToSql(item.cbConfidentialDocuments.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.cbRiskFactors.IsEmpty Then
        allEmptyFlag = item.cbRiskFactors.IsEmpty And allEmptyFlag
        valuesList = valuesList & "RISK_FACTORS_CHECKED=" + Update.Dao.ToSql(item.cbRiskFactors.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.COMM_INTAKE_CONTACT_TYPE_MULTI.IsEmpty Then
        allEmptyFlag = item.COMM_INTAKE_CONTACT_TYPE_MULTI.IsEmpty And allEmptyFlag
        valuesList = valuesList & "COMM_INTAKE_CONTACT_TYPE_MULTI=" + Update.Dao.ToSql(item.COMM_INTAKE_CONTACT_TYPE_MULTI.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_ROLE=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE2.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE2.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_ROLE2=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE2.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_NAME3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_NAME3.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_NAME3=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_NAME3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_ROLE3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_ROLE3.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_ROLE3=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_ROLE3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.IsEmpty Then
        allEmptyFlag = item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_KEY_PROFESSIONAL_CONTACT3=" + Update.Dao.ToSql(item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.SUPPORT_DOCS_YOUNG_ADULT1.IsEmpty Then
        allEmptyFlag = item.SUPPORT_DOCS_YOUNG_ADULT1.IsEmpty And allEmptyFlag
        valuesList = valuesList & "SUPPORT_DOCS_SPORTS_PERFORMANCE=" + Update.Dao.ToSql(item.SUPPORT_DOCS_YOUNG_ADULT1.GetFormattedValue(""),FieldType._Text) & ","
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record STUDENT_PROFILE1 BeforeBuildUpdate

'Record STUDENT_PROFILE1 AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record STUDENT_PROFILE1 AfterExecuteUpdate

'Record STUDENT_PROFILE1 Data Provider Class GetResultSet Method @3-70A0AA4F

    Public Sub FillItem(ByVal item As STUDENT_PROFILE1Item, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record STUDENT_PROFILE1 Data Provider Class GetResultSet Method

'Record STUDENT_PROFILE1 BeforeBuildSelect @3-C7318EC1
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID206",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR207",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record STUDENT_PROFILE1 BeforeBuildSelect

'Record STUDENT_PROFILE1 BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record STUDENT_PROFILE1 BeforeExecuteSelect

'Record STUDENT_PROFILE1 AfterExecuteSelect @3-E8575BAC
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.BACKGROUND_INFO.SetValue(dr(i)("BACKGROUND_INFO"),"")
            item.ENROL_REASONS.SetValue(dr(i)("ENROL_REASONS"),"")
            item.WELLBEING_INCLUSION_CONCERNS.SetValue(dr(i)("WELLBEING_INCLUSION_CONCERNS"),"")
            item.EXPECT_RETURN_TO_SCHOOL.SetValue(dr(i)("EXPECT_RETURN_TO_SCHOOL"),"")
            item.RETURN_STUDENT.SetValue(dr(i)("RETURN_STUDENT"),"")
            item.KNOWN_WELLBEING.SetValue(dr(i)("KNOWN_WELLBEING"),"")
            item.KNOWN_INCLUSION.SetValue(dr(i)("KNOWN_INCLUSION"),"")
            item.KNOWN_PATHWAYS.SetValue(dr(i)("KNOWN_PATHWAYS"),"")
            item.SUPPORT_DOCS_AGENCY_REFERRAL.SetValue(dr(i)("SUPPORT_DOCS_AGENCY_REFERRAL"),"")
            item.SUPPORT_DOCS_SCHOOL_REFERRAL.SetValue(dr(i)("SUPPORT_DOCS_SCHOOL_REFERRAL"),"")
            item.SUPPORT_DOCS_YOUNG_ADULT.SetValue(dr(i)("SUPPORT_DOCS_YOUNG_ADULT"),"")
            item.SUPPORT_DOCS_OTHER.SetValue(dr(i)("SUPPORT_DOCS_OTHER"),"")
            item.SUPPORT_KEY_PROFESSIONAL_NAME.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_NAME"),"")
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_CONTACT"),"")
            item.ENGAGEMENT_HOBBIES_INTERESTS.SetValue(dr(i)("ENGAGEMENT_HOBBIES_INTERESTS"),"")
            item.COMM_VISIT_FLAG.SetValue(dr(i)("COMM_VISIT_FLAG"),"")
            item.COMM_VISIT_DATE.SetValue(dr(i)("COMM_VISIT_DATE"),Select_.DateFormat)
            item.COMM_CONTACT_TYPE.SetValue(dr(i)("COMM_CONTACT_TYPE"),"")
            item.COMM_CONTACT_TYPE_OTHER.SetValue(dr(i)("COMM_CONTACT_TYPE_OTHER"),"")
            item.COMM_PHONE_CONTACT.SetValue(dr(i)("COMM_PHONE_CONTACT"),"")
            item.CARER_CONTACT_METHOD.SetValue(dr(i)("CARER_CONTACT_METHOD"),"")
            item.CARER_SUPERVISOR_NAME.SetValue(dr(i)("CARER_SUPERVISOR_NAME"),"")
            item.CARER_SUPERVISOR_ROLE.SetValue(dr(i)("CARER_SUPERVISOR_ROLE"),"")
            item.CARER_ADDITIONAL.SetValue(dr(i)("CARER_ADDITIONAL"),"")
            item.ORGANISATION_WHENWHERE.SetValue(dr(i)("ORGANISATION_WHENWHERE"),"")
            item.ORGANISATION_TIMETABLE.SetValue(dr(i)("ORGANISATION_TIMETABLE"),"")
            item.ORGANISATION_HARDWARE.SetValue(dr(i)("ORGANISATION_HARDWARE"),"")
            item.ORGANISATION_ACCESS_INTERNET.SetValue(dr(i)("ORGANISATION_ACCESS_INTERNET"),"")
            item.ORGANISATION_PREVIOUS_SCHOOL.SetValue(dr(i)("ORGANISATION_PREVIOUS_SCHOOL"),"")
            item.ORGANISATION_ACADEMIC_HISTORY.SetValue(dr(i)("ORGANISATION_ACADEMIC_HISTORY"),"")
            item.ORGANISATION_RECENTREPORT_FILED.SetValue(dr(i)("ORGANISATION_RECENTREPORT_FILED"),"")
            item.LAUNCH_PAD_DONE.SetValue(dr(i)("LAUNCH_PAD_DONE"),"")
            item.LAUNCH_PAD_DONE_DATE.SetValue(dr(i)("LAUNCH_PAD_DONE_DATE"),Select_.DateFormat)
            item.LEARNING_PROGRAM.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.LEARNING_PROGRAM_DETAILS.SetValue(dr(i)("LEARNING_PROGRAM_DETAILS"),"")
            item.LEARNING_GOALS.SetValue(dr(i)("LEARNING_GOALS"),"")
            item.SPECIAL_PROVISION_FLAG.SetValue(dr(i)("SPECIAL_PROVISION_FLAG"),"")
            item.SPECIAL_PROVISION_DETAILS.SetValue(dr(i)("SPECIAL_PROVISION_DETAILS"),"")
            item.PATHWAYS_CAREER_PLAN_FLAG.SetValue(dr(i)("PATHWAYS_CAREER_PLAN_FLAG"),"")
            item.PATHWAYS_CAREER_GOALS.SetValue(dr(i)("PATHWAYS_CAREER_GOALS"),"")
            item.PATHWAYS_CAREER_GOALS_MIDYEAR.SetValue(dr(i)("PATHWAYS_CAREER_GOALS_MIDYEAR"),"")
            item.PATHWAYS_CAREER_GOALS_MIDYEAR_DATE.SetValue(dr(i)("PATHWAYS_CAREER_GOALS_MIDYEAR_DATE"),Select_.DateFormat)
            item.PATHWAYS_WORKEXP_FLAG.SetValue(dr(i)("PATHWAYS_WORKEXP_FLAG"),"")
            item.PATHWAYS_WORKEXP_DETAILS.SetValue(dr(i)("PATHWAYS_WORKEXP_DETAILS"),"")
            item.PATHWAYS_PARTTIMEJOBS.SetValue(dr(i)("PATHWAYS_PARTTIMEJOBS"),"")
            item.PATHWAYS_ENDYEAR_INTENTIONS_FLAG.SetValue(dr(i)("PATHWAYS_ENDYEAR_INTENTIONS_FLAG"),"")
            item.PATHWAYS_ENDYEAR_INTENTIONS_DATE.SetValue(dr(i)("PATHWAYS_ENDYEAR_INTENTIONS_DATE"),Select_.DateFormat)
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG.SetValue(dr(i)("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG"),"")
            item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE.SetValue(dr(i)("PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_DATE"),Select_.DateFormat)
            item.REVIEW_PROGRESS_END_SEM1.SetValue(dr(i)("REVIEW_PROGRESS_END_SEM1"),"")
            item.REVIEW_PROGRESS_END_SEM2.SetValue(dr(i)("REVIEW_PROGRESS_END_SEM2"),"")
            item.lblLearningProgram.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.lblStudentID.SetValue(dr(i)("STUDENT_ID"),"")
            item.lblEnrolYear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY1.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE1.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.hidden_LastUpdatedBy.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.hidden_LastUpdatedWhen.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
            item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(dr(i)("LEARNING_PROGRAM_CONSULT"),"")
            item.ASSESS_ENGLANG_LP.SetValue(dr(i)("ASSESS_ENGLANG_LP"),"")
            item.ASSESS_ENGLANG_RL.SetValue(dr(i)("ASSESS_ENGLANG_RL"),"")
            item.ASSESS_MATH_LP.SetValue(dr(i)("ASSESS_MATH_LP"),"")
            item.ASSESS_MATH_RL.SetValue(dr(i)("ASSESS_MATH_RL"),"")
            item.ASSESS_PATSCIENCE_LP.SetValue(dr(i)("ASSESS_PATSCIENCE_LP"),"")
            item.ASSESS_PATSCIENCE_RL.SetValue(dr(i)("ASSESS_PATSCIENCE_RL"),"")
            item.SUPPORT_KEY_PROFESSIONAL_NAME2.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_NAME2"),"")
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT2.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_CONTACT2"),"")
            item.cbENROL_FILE_CHECKED.SetValue(dr(i)("ENROL_FILE_CHECKED"),"")
            item.Hidden_COMM_CONTACT_TYPE_MULTI.SetValue(dr(i)("COMM_CONTACT_TYPE_MULTI"),"")
            item.Link1Href = "Student_EACL.aspx"
            item.cbConfidentialDocuments.SetValue(dr(i)("CONFIDENTIAL_DOCUMENTS_CHECKED"),"")
            item.cbRiskFactors.SetValue(dr(i)("RISK_FACTORS_CHECKED"),Select_.BoolFormat)
            item.COMM_INTAKE_CONTACT_TYPE_MULTI.SetValue(dr(i)("COMM_INTAKE_CONTACT_TYPE_MULTI"),"")
            item.SUPPORT_KEY_PROFESSIONAL_ROLE.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_ROLE"),"")
            item.SUPPORT_KEY_PROFESSIONAL_ROLE2.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_ROLE2"),"")
            item.SUPPORT_KEY_PROFESSIONAL_NAME3.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_NAME3"),"")
            item.SUPPORT_KEY_PROFESSIONAL_ROLE3.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_ROLE3"),"")
            item.SUPPORT_KEY_PROFESSIONAL_CONTACT3.SetValue(dr(i)("SUPPORT_KEY_PROFESSIONAL_CONTACT3"),"")
            item.SUPPORT_DOCS_YOUNG_ADULT1.SetValue(dr(i)("SUPPORT_DOCS_SPORTS_PERFORMANCE"),"")
            item.Link2Href = "Student_Medical_maintain.aspx"
        Else
            IsInsertMode = True
        End If
'End Record STUDENT_PROFILE1 AfterExecuteSelect

'ListBox RETURN_STUDENT AfterExecuteSelect @17-6A976C2E
        
item.RETURN_STUDENTItems.Add("Y","Yes")
item.RETURN_STUDENTItems.Add("N","No")
'End ListBox RETURN_STUDENT AfterExecuteSelect

'ListBox KNOWN_WELLBEING AfterExecuteSelect @18-2B488A52
        
item.KNOWN_WELLBEINGItems.Add("Y","Yes")
item.KNOWN_WELLBEINGItems.Add("N","No")
'End ListBox KNOWN_WELLBEING AfterExecuteSelect

'ListBox KNOWN_INCLUSION AfterExecuteSelect @19-E6E8A824
        
item.KNOWN_INCLUSIONItems.Add("Y","Yes")
item.KNOWN_INCLUSIONItems.Add("N","No")
'End ListBox KNOWN_INCLUSION AfterExecuteSelect

'ListBox KNOWN_PATHWAYS AfterExecuteSelect @20-D691B587
        
item.KNOWN_PATHWAYSItems.Add("Y","Yes")
item.KNOWN_PATHWAYSItems.Add("N","No")
'End ListBox KNOWN_PATHWAYS AfterExecuteSelect

'ListBox COMM_VISIT_FLAG AfterExecuteSelect @29-716850B3
        
item.COMM_VISIT_FLAGItems.Add("Y","Yes")
item.COMM_VISIT_FLAGItems.Add("N","No")
'End ListBox COMM_VISIT_FLAG AfterExecuteSelect

'ListBox COMM_CONTACT_TYPE AfterExecuteSelect @31-90E06F65
        
item.COMM_CONTACT_TYPEItems.Add("DECV/Student Visit","VSV/Student Visit")
item.COMM_CONTACT_TYPEItems.Add("Phone","Phone")
item.COMM_CONTACT_TYPEItems.Add("Email","Email")
item.COMM_CONTACT_TYPEItems.Add("Webex","Webex")
item.COMM_CONTACT_TYPEItems.Add("SMS","SMS")
item.COMM_CONTACT_TYPEItems.Add("Other","Other")
'End ListBox COMM_CONTACT_TYPE AfterExecuteSelect

'ListBox COMM_PHONE_CONTACT AfterExecuteSelect @33-BC3D50DB
        
item.COMM_PHONE_CONTACTItems.Add("Yes - Phone","Yes - Phone contact")
item.COMM_PHONE_CONTACTItems.Add("No - Has difficulty","No - Has difficulty")
item.COMM_PHONE_CONTACTItems.Add("No - overseas","No - overseas")
item.COMM_PHONE_CONTACTItems.Add("No - social phobia","No - social phobia")
item.COMM_PHONE_CONTACTItems.Add("No - other","No - other")
'End ListBox COMM_PHONE_CONTACT AfterExecuteSelect

'ListBox CARER_SUPERVISOR_ROLE AfterExecuteSelect @36-13F2DF9B
        
item.CARER_SUPERVISOR_ROLEItems.Add("Y","Yes")
item.CARER_SUPERVISOR_ROLEItems.Add("N","No")
'End ListBox CARER_SUPERVISOR_ROLE AfterExecuteSelect

'ListBox ORGANISATION_TIMETABLE AfterExecuteSelect @39-EB5F04EC
        
item.ORGANISATION_TIMETABLEItems.Add("Y","Yes")
item.ORGANISATION_TIMETABLEItems.Add("N","No")
'End ListBox ORGANISATION_TIMETABLE AfterExecuteSelect

'ListBox ORGANISATION_HARDWARE AfterExecuteSelect @40-F7FF717E
        
item.ORGANISATION_HARDWAREItems.Add("Desktop","Desktop")
item.ORGANISATION_HARDWAREItems.Add("Laptop","Laptop")
item.ORGANISATION_HARDWAREItems.Add("Tablet (iPad)","Tablet (iPad)")
item.ORGANISATION_HARDWAREItems.Add("Print","Print")
'End ListBox ORGANISATION_HARDWARE AfterExecuteSelect

'ListBox ORGANISATION_RECENTREPORT_FILED AfterExecuteSelect @44-8436E2ED
        
item.ORGANISATION_RECENTREPORT_FILEDItems.Add("Y","Yes")
item.ORGANISATION_RECENTREPORT_FILEDItems.Add("N","No")
'End ListBox ORGANISATION_RECENTREPORT_FILED AfterExecuteSelect

'ListBox LAUNCH_PAD_DONE AfterExecuteSelect @45-DE0E847B
        
item.LAUNCH_PAD_DONEItems.Add("Y","Yes")
item.LAUNCH_PAD_DONEItems.Add("N","No")
'End ListBox LAUNCH_PAD_DONE AfterExecuteSelect

'ListBox LEARNING_PROGRAM_CONSULT AfterExecuteSelect @49-6887ECAF
        
item.LEARNING_PROGRAM_CONSULTItems.Add("YearLevelCoord","Year Level Coordinator")
item.LEARNING_PROGRAM_CONSULTItems.Add("LeadingTeacher-StudentLearning","Leading Teacher - Student Learning")
item.LEARNING_PROGRAM_CONSULTItems.Add("StudentInclusion","Student Inclusion")
item.LEARNING_PROGRAM_CONSULTItems.Add("StudentWellbeing","Student Wellbeing")
'End ListBox LEARNING_PROGRAM_CONSULT AfterExecuteSelect

'ListBox SPECIAL_PROVISION_FLAG AfterExecuteSelect @51-F2D4EFA9
        
item.SPECIAL_PROVISION_FLAGItems.Add("Y","Yes")
item.SPECIAL_PROVISION_FLAGItems.Add("N","No")
'End ListBox SPECIAL_PROVISION_FLAG AfterExecuteSelect

'ListBox PATHWAYS_CAREER_PLAN_FLAG AfterExecuteSelect @53-1A6D7709
        
item.PATHWAYS_CAREER_PLAN_FLAGItems.Add("Y","Yes")
item.PATHWAYS_CAREER_PLAN_FLAGItems.Add("N","No")
'End ListBox PATHWAYS_CAREER_PLAN_FLAG AfterExecuteSelect

'ListBox PATHWAYS_WORKEXP_FLAG AfterExecuteSelect @57-942676D4
        
item.PATHWAYS_WORKEXP_FLAGItems.Add("Y","Yes")
item.PATHWAYS_WORKEXP_FLAGItems.Add("N","No")
'End ListBox PATHWAYS_WORKEXP_FLAG AfterExecuteSelect

'ListBox PATHWAYS_ENDYEAR_INTENTIONS_FLAG AfterExecuteSelect @60-C784FB64
        
item.PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems.Add("Y","Yes")
item.PATHWAYS_ENDYEAR_INTENTIONS_FLAGItems.Add("N","No")
'End ListBox PATHWAYS_ENDYEAR_INTENTIONS_FLAG AfterExecuteSelect

'ListBox PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG AfterExecuteSelect @62-AB0D0E37
        
item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems.Add("Y","Yes")
item.PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAGItems.Add("N","No")
'End ListBox PATHWAYS_ENDYEAR_INTENTIONS_LOGGED_FLAG AfterExecuteSelect

'ListBox COMM_INTAKE_CONTACT_TYPE_MULTI AfterExecuteSelect @227-BFAB2840
        
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("DECV/Student Visit","VSV/Student Visit")
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("Phone","Phone")
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("Email","Email")
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("Webex","Webex")
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("SMS","SMS")
item.COMM_INTAKE_CONTACT_TYPE_MULTIItems.Add("Other","Other")
'End ListBox COMM_INTAKE_CONTACT_TYPE_MULTI AfterExecuteSelect

'Record STUDENT_PROFILE1 AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record STUDENT_PROFILE1 AfterExecuteSelect tail

'Record STUDENT_PROFILE1 Data Provider Class @3-A61BA892
End Class

'End Record STUDENT_PROFILE1 Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

