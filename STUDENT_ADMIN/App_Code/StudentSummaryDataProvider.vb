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

Namespace DECV_PROD2007.StudentSummary 'Namespace @1-3B0EC2E2

'Page Data Class @1-793A52B8
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public link_Menu As TextField
    Public link_MenuHref As Object
    Public link_MenuHrefParameters As LinkParameterCollection
    Public Link_SearchRequest As TextField
    Public Link_SearchRequestHref As Object
    Public Link_SearchRequestHrefParameters As LinkParameterCollection
    Public link_Assignments As TextField
    Public link_AssignmentsHref As Object
    Public link_AssignmentsHrefParameters As LinkParameterCollection
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Link3 As TextField
    Public Link3Href As Object
    Public Link3HrefParameters As LinkParameterCollection
    Public Link2 As TextField
    Public Link2Href As Object
    Public Link2HrefParameters As LinkParameterCollection
    Public Link4 As TextField
    Public Link4Href As Object
    Public Link4HrefParameters As LinkParameterCollection
    Public Link5 As TextField
    Public Link5Href As Object
    Public Link5HrefParameters As LinkParameterCollection
    Public Link10 As TextField
    Public Link10Href As Object
    Public Link10HrefParameters As LinkParameterCollection
    Public Link6 As TextField
    Public Link6Href As Object
    Public Link6HrefParameters As LinkParameterCollection
    Public lblModified As TextField
    Public Link8 As TextField
    Public Link8Href As Object
    Public Link8HrefParameters As LinkParameterCollection
    Public Link7 As TextField
    Public Link7Href As Object
    Public Link7HrefParameters As LinkParameterCollection
    Public Link9 As TextField
    Public Link9Href As Object
    Public Link9HrefParameters As LinkParameterCollection
    Public Sub New()
        link_Menu = New TextField("",Nothing)
        link_MenuHrefParameters = New LinkParameterCollection()
        Link_SearchRequest = New TextField("",Nothing)
        Link_SearchRequestHrefParameters = New LinkParameterCollection()
        link_Assignments = New TextField("",Nothing)
        link_AssignmentsHrefParameters = New LinkParameterCollection()
        Link1 = New TextField("",Nothing)
        Link1HrefParameters = New LinkParameterCollection()
        Link3 = New TextField("",Nothing)
        Link3HrefParameters = New LinkParameterCollection()
        Link2 = New TextField("",Nothing)
        Link2HrefParameters = New LinkParameterCollection()
        Link4 = New TextField("",Nothing)
        Link4HrefParameters = New LinkParameterCollection()
        Link5 = New TextField("",Nothing)
        Link5HrefParameters = New LinkParameterCollection()
        Link10 = New TextField("",Nothing)
        Link10HrefParameters = New LinkParameterCollection()
        Link6 = New TextField("",Nothing)
        Link6HrefParameters = New LinkParameterCollection()
        lblModified = New TextField("", Nothing)
        Link8 = New TextField("",Nothing)
        Link8HrefParameters = New LinkParameterCollection()
        Link7 = New TextField("",Nothing)
        Link7HrefParameters = New LinkParameterCollection()
        Link9 = New TextField("",Nothing)
        Link9HrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.link_Menu.SetValue(DBUtility.GetInitialValue("link_Menu"))
        item.Link_SearchRequest.SetValue(DBUtility.GetInitialValue("Link_SearchRequest"))
        item.link_Assignments.SetValue(DBUtility.GetInitialValue("link_Assignments"))
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        item.Link3.SetValue(DBUtility.GetInitialValue("Link3"))
        item.Link2.SetValue(DBUtility.GetInitialValue("Link2"))
        item.Link4.SetValue(DBUtility.GetInitialValue("Link4"))
        item.Link5.SetValue(DBUtility.GetInitialValue("Link5"))
        item.Link10.SetValue(DBUtility.GetInitialValue("Link10"))
        item.Link6.SetValue(DBUtility.GetInitialValue("Link6"))
        item.lblModified.SetValue(DBUtility.GetInitialValue("lblModified"))
        item.Link8.SetValue(DBUtility.GetInitialValue("Link8"))
        item.Link7.SetValue(DBUtility.GetInitialValue("Link7"))
        item.Link9.SetValue(DBUtility.GetInitialValue("Link9"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "link_Menu"
                    Return link_Menu
                Case "Link_SearchRequest"
                    Return Link_SearchRequest
                Case "link_Assignments"
                    Return link_Assignments
                Case "Link1"
                    Return Link1
                Case "Link3"
                    Return Link3
                Case "Link2"
                    Return Link2
                Case "Link4"
                    Return Link4
                Case "Link5"
                    Return Link5
                Case "Link10"
                    Return Link10
                Case "Link6"
                    Return Link6
                Case "lblModified"
                    Return lblModified
                Case "Link8"
                    Return Link8
                Case "Link7"
                    Return Link7
                Case "Link9"
                    Return Link9
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "link_Menu"
                    link_Menu = CType(value, TextField)
                Case "Link_SearchRequest"
                    Link_SearchRequest = CType(value, TextField)
                Case "link_Assignments"
                    link_Assignments = CType(value, TextField)
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "Link3"
                    Link3 = CType(value, TextField)
                Case "Link2"
                    Link2 = CType(value, TextField)
                Case "Link4"
                    Link4 = CType(value, TextField)
                Case "Link5"
                    Link5 = CType(value, TextField)
                Case "Link10"
                    Link10 = CType(value, TextField)
                Case "Link6"
                    Link6 = CType(value, TextField)
                Case "lblModified"
                    lblModified = CType(value, TextField)
                Case "Link8"
                    Link8 = CType(value, TextField)
                Case "Link7"
                    Link7 = CType(value, TextField)
                Case "Link9"
                    Link9 = CType(value, TextField)
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

'Record viewStudentSummary_Detail Item Class @4-D9D6C4CF
Public Class viewStudentSummary_DetailItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public Student_id As TextField
    Public enrolment_date As TextField
    Public withdrawal_date As TextField
    Public ENROLMENT_STATUS As TextField
    Public WithdrawalReason As TextField
    Public WITHDRAWAL_REASON_ID As FloatField
    Public surname As TextField
    Public first_name As TextField
    Public middle_name As TextField
    Public SEX As TextField
    Public YEAR_LEVEL As IntegerField
    Public EnrolmentYear As TextField
    Public receipt_no As TextField
    Public subcategory_full_title As TextField
    Public attending_school_name As TextField
    Public ATTENDING_SCHOOL_ID As FloatField
    Public home_school_name As TextField
    Public HOME_SCHOOL_ID As FloatField
    Public POSTAL_ADDRESS_ID As FloatField
    Public CURR_RESID_ADDRESS_ID As FloatField
    Public ORIG_RESID_ADDRESS_ID As FloatField
    Public lblHomeSchooled As TextField
    Public VSN As TextField
    Public VSR_Enrolled As TextField
    Public birth_date As TextField
    Public preferred_name As TextField
    Public lblWd_Exit_Destination As TextField
    Public WD_EXIT_DESTINATION As TextField
    Public hidden_DATE_STUDENTFOLDER_CREATED As DateField
    Public label_Age As TextField
    Public link_create_teacheremails As TextField
    Public link_create_teacheremailsHref As Object
    Public link_create_teacheremailsHrefParameters As LinkParameterCollection
    Public STUDENT_EMAIL As TextField
    Public STUDENT_EMAILHref As Object
    Public STUDENT_EMAILHrefParameters As LinkParameterCollection
    Public STUDENT_MOBILE As TextField
    Public lblATARNotRequired As TextField
    Public ATAR_REQUIRED As TextField
    Public link_create_parentemails As TextField
    Public link_create_parentemailsHref As Object
    Public link_create_parentemailsHrefParameters As LinkParameterCollection
    Public PORTAL_ACCESS As TextField
    Public lblPortalAccessRestricted As TextField
    Public lblSharedEnrolment As TextField
    Public cake As TextField
    Public PASTORAL_CARE_ID As TextField
    Public lblAreaDisplay As TextField
    Public lblRegionDisplay As TextField
    Public lblEnrolStatus As TextField
    Public org_school_name As TextField
    Public ORGANISATION_SCHOOL_ID As FloatField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public lblPLP As TextField
    Public LEARNING_PROGRAM_text As TextField
    Public link_showstudentreports As TextField
    Public link_showstudentreportsHref As Object
    Public link_showstudentreportsHrefParameters As LinkParameterCollection
    Public labelContactWho1 As TextField
    Public link_showstudentfolder As TextField
    Public link_showstudentfolderHref As Object
    Public link_showstudentfolderHrefParameters As LinkParameterCollection
    Public labelContactWho As TextField
    Public SSG_FACILITATOR_ID As TextField
    Public LinkLearningAdvisorEmail As TextField
    Public LinkLearningAdvisorEmailHref As Object
    Public LinkLearningAdvisorEmailHrefParameters As LinkParameterCollection
    Public hidden_SEX_SELF_DESCRIBED As TextField
    Public Pronouns As TextField
    Public FunnelLink As TextField
    Public FunnelLinkHref As Object
    Public FunnelLinkHrefParameters As LinkParameterCollection
    Public FilesLink As TextField
    Public FilesLinkHref As Object
    Public FilesLinkHrefParameters As LinkParameterCollection
    Public FunnelUUID As TextField
    Public ReferralsLink As TextField
    Public ReferralsLinkHref As Object
    Public ReferralsLinkHrefParameters As LinkParameterCollection
    Public Sub New()
    Student_id = New TextField("", Nothing)
    enrolment_date = New TextField("dd/mm/yyyy", Nothing)
    withdrawal_date = New TextField("dd/mm/yyyy", Nothing)
    ENROLMENT_STATUS = New TextField("", Nothing)
    WithdrawalReason = New TextField("", Nothing)
    WITHDRAWAL_REASON_ID = New FloatField("", Nothing)
    surname = New TextField("", Nothing)
    first_name = New TextField("", Nothing)
    middle_name = New TextField("", Nothing)
    SEX = New TextField("", Nothing)
    YEAR_LEVEL = New IntegerField("", Nothing)
    EnrolmentYear = New TextField("", Nothing)
    receipt_no = New TextField("", Nothing)
    subcategory_full_title = New TextField("", Nothing)
    attending_school_name = New TextField("", Nothing)
    ATTENDING_SCHOOL_ID = New FloatField("", Nothing)
    home_school_name = New TextField("", Nothing)
    HOME_SCHOOL_ID = New FloatField("", Nothing)
    POSTAL_ADDRESS_ID = New FloatField("", Nothing)
    CURR_RESID_ADDRESS_ID = New FloatField("", Nothing)
    ORIG_RESID_ADDRESS_ID = New FloatField("", Nothing)
    lblHomeSchooled = New TextField("", "<em>Home Schooled</em>")
    VSN = New TextField("", "Unknown")
    VSR_Enrolled = New TextField("", "False")
    birth_date = New TextField("dd/mm/yyyy", Nothing)
    preferred_name = New TextField("", Nothing)
    lblWd_Exit_Destination = New TextField("", Nothing)
    WD_EXIT_DESTINATION = New TextField("", Nothing)
    hidden_DATE_STUDENTFOLDER_CREATED = New DateField("yyyy-MM-dd H\:mm", Nothing)
    label_Age = New TextField("", Nothing)
    link_create_teacheremails = New TextField("",Nothing)
    link_create_teacheremailsHrefParameters = New LinkParameterCollection()
    STUDENT_EMAIL = New TextField("",Nothing)
    STUDENT_EMAILHrefParameters = New LinkParameterCollection()
    STUDENT_MOBILE = New TextField("", Nothing)
    lblATARNotRequired = New TextField("", "<font color='#FF0000'><strong>ATAR NOT Required</strong></font>")
    ATAR_REQUIRED = New TextField("", Nothing)
    link_create_parentemails = New TextField("",Nothing)
    link_create_parentemailsHrefParameters = New LinkParameterCollection()
    PORTAL_ACCESS = New TextField("", Nothing)
    lblPortalAccessRestricted = New TextField("", "<font color='#FF0000'><strong>Not On Portal</strong></font>")
    lblSharedEnrolment = New TextField("", "<font color='#FF0000'><strong>Shared Enrolment</strong></font>")
    cake = New TextField("", "&#x1f382;")
    PASTORAL_CARE_ID = New TextField("", Nothing)
    lblAreaDisplay = New TextField("", "unknown")
    lblRegionDisplay = New TextField("", "unknown")
    lblEnrolStatus = New TextField("", "E")
    org_school_name = New TextField("", Nothing)
    ORGANISATION_SCHOOL_ID = New FloatField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
    lblPLP = New TextField("", Nothing)
    LEARNING_PROGRAM_text = New TextField("", Nothing)
    link_showstudentreports = New TextField("",Nothing)
    link_showstudentreportsHrefParameters = New LinkParameterCollection()
    labelContactWho1 = New TextField("", "<em>Contact your Leading Teacher to create Student Files</em>")
    link_showstudentfolder = New TextField("",Nothing)
    link_showstudentfolderHrefParameters = New LinkParameterCollection()
    labelContactWho = New TextField("", "<em>Contact your Leading Teacher to create Student Files</em>")
    SSG_FACILITATOR_ID = New TextField("", Nothing)
    LinkLearningAdvisorEmail = New TextField("",Nothing)
    LinkLearningAdvisorEmailHrefParameters = New LinkParameterCollection()
    hidden_SEX_SELF_DESCRIBED = New TextField("", Nothing)
    Pronouns = New TextField("", Nothing)
    FunnelLink = New TextField("",Nothing)
    FunnelLinkHrefParameters = New LinkParameterCollection()
    FilesLink = New TextField("",Nothing)
    FilesLinkHrefParameters = New LinkParameterCollection()
    FunnelUUID = New TextField("", Nothing)
    ReferralsLink = New TextField("",Nothing)
    ReferralsLinkHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As viewStudentSummary_DetailItem
        Dim item As viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
        If Not IsNothing(DBUtility.GetInitialValue("Student_id")) Then
        item.Student_id.SetValue(DBUtility.GetInitialValue("Student_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("enrolment_date")) Then
        item.enrolment_date.SetValue(DBUtility.GetInitialValue("enrolment_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("withdrawal_date")) Then
        item.withdrawal_date.SetValue(DBUtility.GetInitialValue("withdrawal_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_STATUS")) Then
        item.ENROLMENT_STATUS.SetValue(DBUtility.GetInitialValue("ENROLMENT_STATUS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WithdrawalReason")) Then
        item.WithdrawalReason.SetValue(DBUtility.GetInitialValue("WithdrawalReason"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID")) Then
        item.WITHDRAWAL_REASON_ID.SetValue(DBUtility.GetInitialValue("WITHDRAWAL_REASON_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("surname")) Then
        item.surname.SetValue(DBUtility.GetInitialValue("surname"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("first_name")) Then
        item.first_name.SetValue(DBUtility.GetInitialValue("first_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("middle_name")) Then
        item.middle_name.SetValue(DBUtility.GetInitialValue("middle_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SEX")) Then
        item.SEX.SetValue(DBUtility.GetInitialValue("SEX"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("YEAR_LEVEL")) Then
        item.YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("EnrolmentYear")) Then
        item.EnrolmentYear.SetValue(DBUtility.GetInitialValue("EnrolmentYear"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("receipt_no")) Then
        item.receipt_no.SetValue(DBUtility.GetInitialValue("receipt_no"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("subcategory_full_title")) Then
        item.subcategory_full_title.SetValue(DBUtility.GetInitialValue("subcategory_full_title"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("attending_school_name")) Then
        item.attending_school_name.SetValue(DBUtility.GetInitialValue("attending_school_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID")) Then
        item.ATTENDING_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("ATTENDING_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("home_school_name")) Then
        item.home_school_name.SetValue(DBUtility.GetInitialValue("home_school_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("HOME_SCHOOL_ID")) Then
        item.HOME_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("HOME_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("POSTAL_ADDRESS_ID")) Then
        item.POSTAL_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("POSTAL_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CURR_RESID_ADDRESS_ID")) Then
        item.CURR_RESID_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("CURR_RESID_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORIG_RESID_ADDRESS_ID")) Then
        item.ORIG_RESID_ADDRESS_ID.SetValue(DBUtility.GetInitialValue("ORIG_RESID_ADDRESS_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblHomeSchooled")) Then
        item.lblHomeSchooled.SetValue(DBUtility.GetInitialValue("lblHomeSchooled"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VSN")) Then
        item.VSN.SetValue(DBUtility.GetInitialValue("VSN"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("VSR_Enrolled")) Then
        item.VSR_Enrolled.SetValue(DBUtility.GetInitialValue("VSR_Enrolled"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("birth_date")) Then
        item.birth_date.SetValue(DBUtility.GetInitialValue("birth_date"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("preferred_name")) Then
        item.preferred_name.SetValue(DBUtility.GetInitialValue("preferred_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblWd_Exit_Destination")) Then
        item.lblWd_Exit_Destination.SetValue(DBUtility.GetInitialValue("lblWd_Exit_Destination"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("WD_EXIT_DESTINATION")) Then
        item.WD_EXIT_DESTINATION.SetValue(DBUtility.GetInitialValue("WD_EXIT_DESTINATION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_DATE_STUDENTFOLDER_CREATED")) Then
        item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(DBUtility.GetInitialValue("hidden_DATE_STUDENTFOLDER_CREATED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("label_Age")) Then
        item.label_Age.SetValue(DBUtility.GetInitialValue("label_Age"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_create_teacheremails")) Then
        item.link_create_teacheremails.SetValue(DBUtility.GetInitialValue("link_create_teacheremails"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_EMAIL")) Then
        item.STUDENT_EMAIL.SetValue(DBUtility.GetInitialValue("STUDENT_EMAIL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_MOBILE")) Then
        item.STUDENT_MOBILE.SetValue(DBUtility.GetInitialValue("STUDENT_MOBILE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblATARNotRequired")) Then
        item.lblATARNotRequired.SetValue(DBUtility.GetInitialValue("lblATARNotRequired"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ATAR_REQUIRED")) Then
        item.ATAR_REQUIRED.SetValue(DBUtility.GetInitialValue("ATAR_REQUIRED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_create_parentemails")) Then
        item.link_create_parentemails.SetValue(DBUtility.GetInitialValue("link_create_parentemails"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PORTAL_ACCESS")) Then
        item.PORTAL_ACCESS.SetValue(DBUtility.GetInitialValue("PORTAL_ACCESS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblPortalAccessRestricted")) Then
        item.lblPortalAccessRestricted.SetValue(DBUtility.GetInitialValue("lblPortalAccessRestricted"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblSharedEnrolment")) Then
        item.lblSharedEnrolment.SetValue(DBUtility.GetInitialValue("lblSharedEnrolment"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("cake")) Then
        item.cake.SetValue(DBUtility.GetInitialValue("cake"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("PASTORAL_CARE_ID")) Then
        item.PASTORAL_CARE_ID.SetValue(DBUtility.GetInitialValue("PASTORAL_CARE_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblAreaDisplay")) Then
        item.lblAreaDisplay.SetValue(DBUtility.GetInitialValue("lblAreaDisplay"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblRegionDisplay")) Then
        item.lblRegionDisplay.SetValue(DBUtility.GetInitialValue("lblRegionDisplay"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblEnrolStatus")) Then
        item.lblEnrolStatus.SetValue(DBUtility.GetInitialValue("lblEnrolStatus"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("org_school_name")) Then
        item.org_school_name.SetValue(DBUtility.GetInitialValue("org_school_name"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ORGANISATION_SCHOOL_ID")) Then
        item.ORGANISATION_SCHOOL_ID.SetValue(DBUtility.GetInitialValue("ORGANISATION_SCHOOL_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Link1")) Then
        item.Link1.SetValue(DBUtility.GetInitialValue("Link1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblPLP")) Then
        item.lblPLP.SetValue(DBUtility.GetInitialValue("lblPLP"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LEARNING_PROGRAM_text")) Then
        item.LEARNING_PROGRAM_text.SetValue(DBUtility.GetInitialValue("LEARNING_PROGRAM_text"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_showstudentreports")) Then
        item.link_showstudentreports.SetValue(DBUtility.GetInitialValue("link_showstudentreports"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("labelContactWho1")) Then
        item.labelContactWho1.SetValue(DBUtility.GetInitialValue("labelContactWho1"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("link_showstudentfolder")) Then
        item.link_showstudentfolder.SetValue(DBUtility.GetInitialValue("link_showstudentfolder"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("labelContactWho")) Then
        item.labelContactWho.SetValue(DBUtility.GetInitialValue("labelContactWho"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SSG_FACILITATOR_ID")) Then
        item.SSG_FACILITATOR_ID.SetValue(DBUtility.GetInitialValue("SSG_FACILITATOR_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LinkLearningAdvisorEmail")) Then
        item.LinkLearningAdvisorEmail.SetValue(DBUtility.GetInitialValue("LinkLearningAdvisorEmail"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("hidden_SEX_SELF_DESCRIBED")) Then
        item.hidden_SEX_SELF_DESCRIBED.SetValue(DBUtility.GetInitialValue("hidden_SEX_SELF_DESCRIBED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Pronouns")) Then
        item.Pronouns.SetValue(DBUtility.GetInitialValue("Pronouns"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FunnelLink")) Then
        item.FunnelLink.SetValue(DBUtility.GetInitialValue("FunnelLink"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FilesLink")) Then
        item.FilesLink.SetValue(DBUtility.GetInitialValue("FilesLink"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FunnelUUID")) Then
        item.FunnelUUID.SetValue(DBUtility.GetInitialValue("FunnelUUID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ReferralsLink")) Then
        item.ReferralsLink.SetValue(DBUtility.GetInitialValue("ReferralsLink"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Student_id"
                    Return Student_id
                Case "enrolment_date"
                    Return enrolment_date
                Case "withdrawal_date"
                    Return withdrawal_date
                Case "ENROLMENT_STATUS"
                    Return ENROLMENT_STATUS
                Case "WithdrawalReason"
                    Return WithdrawalReason
                Case "WITHDRAWAL_REASON_ID"
                    Return WITHDRAWAL_REASON_ID
                Case "surname"
                    Return surname
                Case "first_name"
                    Return first_name
                Case "middle_name"
                    Return middle_name
                Case "SEX"
                    Return SEX
                Case "YEAR_LEVEL"
                    Return YEAR_LEVEL
                Case "EnrolmentYear"
                    Return EnrolmentYear
                Case "receipt_no"
                    Return receipt_no
                Case "subcategory_full_title"
                    Return subcategory_full_title
                Case "attending_school_name"
                    Return attending_school_name
                Case "ATTENDING_SCHOOL_ID"
                    Return ATTENDING_SCHOOL_ID
                Case "home_school_name"
                    Return home_school_name
                Case "HOME_SCHOOL_ID"
                    Return HOME_SCHOOL_ID
                Case "POSTAL_ADDRESS_ID"
                    Return POSTAL_ADDRESS_ID
                Case "CURR_RESID_ADDRESS_ID"
                    Return CURR_RESID_ADDRESS_ID
                Case "ORIG_RESID_ADDRESS_ID"
                    Return ORIG_RESID_ADDRESS_ID
                Case "lblHomeSchooled"
                    Return lblHomeSchooled
                Case "VSN"
                    Return VSN
                Case "VSR_Enrolled"
                    Return VSR_Enrolled
                Case "birth_date"
                    Return birth_date
                Case "preferred_name"
                    Return preferred_name
                Case "lblWd_Exit_Destination"
                    Return lblWd_Exit_Destination
                Case "WD_EXIT_DESTINATION"
                    Return WD_EXIT_DESTINATION
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    Return hidden_DATE_STUDENTFOLDER_CREATED
                Case "label_Age"
                    Return label_Age
                Case "link_create_teacheremails"
                    Return link_create_teacheremails
                Case "STUDENT_EMAIL"
                    Return STUDENT_EMAIL
                Case "STUDENT_MOBILE"
                    Return STUDENT_MOBILE
                Case "lblATARNotRequired"
                    Return lblATARNotRequired
                Case "ATAR_REQUIRED"
                    Return ATAR_REQUIRED
                Case "link_create_parentemails"
                    Return link_create_parentemails
                Case "PORTAL_ACCESS"
                    Return PORTAL_ACCESS
                Case "lblPortalAccessRestricted"
                    Return lblPortalAccessRestricted
                Case "lblSharedEnrolment"
                    Return lblSharedEnrolment
                Case "cake"
                    Return cake
                Case "PASTORAL_CARE_ID"
                    Return PASTORAL_CARE_ID
                Case "lblAreaDisplay"
                    Return lblAreaDisplay
                Case "lblRegionDisplay"
                    Return lblRegionDisplay
                Case "lblEnrolStatus"
                    Return lblEnrolStatus
                Case "org_school_name"
                    Return org_school_name
                Case "ORGANISATION_SCHOOL_ID"
                    Return ORGANISATION_SCHOOL_ID
                Case "Link1"
                    Return Link1
                Case "lblPLP"
                    Return lblPLP
                Case "LEARNING_PROGRAM_text"
                    Return LEARNING_PROGRAM_text
                Case "link_showstudentreports"
                    Return link_showstudentreports
                Case "labelContactWho1"
                    Return labelContactWho1
                Case "link_showstudentfolder"
                    Return link_showstudentfolder
                Case "labelContactWho"
                    Return labelContactWho
                Case "SSG_FACILITATOR_ID"
                    Return SSG_FACILITATOR_ID
                Case "LinkLearningAdvisorEmail"
                    Return LinkLearningAdvisorEmail
                Case "hidden_SEX_SELF_DESCRIBED"
                    Return hidden_SEX_SELF_DESCRIBED
                Case "Pronouns"
                    Return Pronouns
                Case "FunnelLink"
                    Return FunnelLink
                Case "FilesLink"
                    Return FilesLink
                Case "FunnelUUID"
                    Return FunnelUUID
                Case "ReferralsLink"
                    Return ReferralsLink
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Student_id"
                    Student_id = CType(value, TextField)
                Case "enrolment_date"
                    enrolment_date = CType(value, TextField)
                Case "withdrawal_date"
                    withdrawal_date = CType(value, TextField)
                Case "ENROLMENT_STATUS"
                    ENROLMENT_STATUS = CType(value, TextField)
                Case "WithdrawalReason"
                    WithdrawalReason = CType(value, TextField)
                Case "WITHDRAWAL_REASON_ID"
                    WITHDRAWAL_REASON_ID = CType(value, FloatField)
                Case "surname"
                    surname = CType(value, TextField)
                Case "first_name"
                    first_name = CType(value, TextField)
                Case "middle_name"
                    middle_name = CType(value, TextField)
                Case "SEX"
                    SEX = CType(value, TextField)
                Case "YEAR_LEVEL"
                    YEAR_LEVEL = CType(value, IntegerField)
                Case "EnrolmentYear"
                    EnrolmentYear = CType(value, TextField)
                Case "receipt_no"
                    receipt_no = CType(value, TextField)
                Case "subcategory_full_title"
                    subcategory_full_title = CType(value, TextField)
                Case "attending_school_name"
                    attending_school_name = CType(value, TextField)
                Case "ATTENDING_SCHOOL_ID"
                    ATTENDING_SCHOOL_ID = CType(value, FloatField)
                Case "home_school_name"
                    home_school_name = CType(value, TextField)
                Case "HOME_SCHOOL_ID"
                    HOME_SCHOOL_ID = CType(value, FloatField)
                Case "POSTAL_ADDRESS_ID"
                    POSTAL_ADDRESS_ID = CType(value, FloatField)
                Case "CURR_RESID_ADDRESS_ID"
                    CURR_RESID_ADDRESS_ID = CType(value, FloatField)
                Case "ORIG_RESID_ADDRESS_ID"
                    ORIG_RESID_ADDRESS_ID = CType(value, FloatField)
                Case "lblHomeSchooled"
                    lblHomeSchooled = CType(value, TextField)
                Case "VSN"
                    VSN = CType(value, TextField)
                Case "VSR_Enrolled"
                    VSR_Enrolled = CType(value, TextField)
                Case "birth_date"
                    birth_date = CType(value, TextField)
                Case "preferred_name"
                    preferred_name = CType(value, TextField)
                Case "lblWd_Exit_Destination"
                    lblWd_Exit_Destination = CType(value, TextField)
                Case "WD_EXIT_DESTINATION"
                    WD_EXIT_DESTINATION = CType(value, TextField)
                Case "hidden_DATE_STUDENTFOLDER_CREATED"
                    hidden_DATE_STUDENTFOLDER_CREATED = CType(value, DateField)
                Case "label_Age"
                    label_Age = CType(value, TextField)
                Case "link_create_teacheremails"
                    link_create_teacheremails = CType(value, TextField)
                Case "STUDENT_EMAIL"
                    STUDENT_EMAIL = CType(value, TextField)
                Case "STUDENT_MOBILE"
                    STUDENT_MOBILE = CType(value, TextField)
                Case "lblATARNotRequired"
                    lblATARNotRequired = CType(value, TextField)
                Case "ATAR_REQUIRED"
                    ATAR_REQUIRED = CType(value, TextField)
                Case "link_create_parentemails"
                    link_create_parentemails = CType(value, TextField)
                Case "PORTAL_ACCESS"
                    PORTAL_ACCESS = CType(value, TextField)
                Case "lblPortalAccessRestricted"
                    lblPortalAccessRestricted = CType(value, TextField)
                Case "lblSharedEnrolment"
                    lblSharedEnrolment = CType(value, TextField)
                Case "cake"
                    cake = CType(value, TextField)
                Case "PASTORAL_CARE_ID"
                    PASTORAL_CARE_ID = CType(value, TextField)
                Case "lblAreaDisplay"
                    lblAreaDisplay = CType(value, TextField)
                Case "lblRegionDisplay"
                    lblRegionDisplay = CType(value, TextField)
                Case "lblEnrolStatus"
                    lblEnrolStatus = CType(value, TextField)
                Case "org_school_name"
                    org_school_name = CType(value, TextField)
                Case "ORGANISATION_SCHOOL_ID"
                    ORGANISATION_SCHOOL_ID = CType(value, FloatField)
                Case "Link1"
                    Link1 = CType(value, TextField)
                Case "lblPLP"
                    lblPLP = CType(value, TextField)
                Case "LEARNING_PROGRAM_text"
                    LEARNING_PROGRAM_text = CType(value, TextField)
                Case "link_showstudentreports"
                    link_showstudentreports = CType(value, TextField)
                Case "labelContactWho1"
                    labelContactWho1 = CType(value, TextField)
                Case "link_showstudentfolder"
                    link_showstudentfolder = CType(value, TextField)
                Case "labelContactWho"
                    labelContactWho = CType(value, TextField)
                Case "SSG_FACILITATOR_ID"
                    SSG_FACILITATOR_ID = CType(value, TextField)
                Case "LinkLearningAdvisorEmail"
                    LinkLearningAdvisorEmail = CType(value, TextField)
                Case "hidden_SEX_SELF_DESCRIBED"
                    hidden_SEX_SELF_DESCRIBED = CType(value, TextField)
                Case "Pronouns"
                    Pronouns = CType(value, TextField)
                Case "FunnelLink"
                    FunnelLink = CType(value, TextField)
                Case "FilesLink"
                    FilesLink = CType(value, TextField)
                Case "FunnelUUID"
                    FunnelUUID = CType(value, TextField)
                Case "ReferralsLink"
                    ReferralsLink = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As viewStudentSummary_DetailDataProvider)
'End Record viewStudentSummary_Detail Item Class

'Record viewStudentSummary_Detail Item Class tail @4-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record viewStudentSummary_Detail Item Class tail

'Record viewStudentSummary_Detail Data Provider Class @4-24B8487D
Public Class viewStudentSummary_DetailDataProvider
Inherits RecordDataProviderBase
'End Record viewStudentSummary_Detail Data Provider Class

'Record viewStudentSummary_Detail Data Provider Class Variables @4-AE11F7C4
    Public Urlstudent_id As FloatParameter
    Public UrlENROLMENT_YEAR As FloatParameter
    Protected item As viewStudentSummary_DetailItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record viewStudentSummary_Detail Data Provider Class Variables

'Record viewStudentSummary_Detail Data Provider Class Constructor @4-2E5FF74D

    Public Sub New()
        Select_=new TableCommand("SELECT Region, Area, rtrim(surname) AS surname, rtrim(first_name) AS first_name, " & vbCrLf & _
          "STUDENT_ID, middle_name, birth_date, SEX, " & vbCrLf & _
          "subcategory_full_title," & vbCrLf & _
          "ATTENDING_SCHOOL_ID, attending_school_name, HOME_SCHOOL_ID, home_school_name, YEAR_LEVEL, " & vbCrLf & _
          "receipt_no, ENROLMENT_YEAR, enrolment_date," & vbCrLf & _
          "withdrawal_date, ENROLLEDBEFORE, VSN, " & vbCrLf & _
          "PREFERRED_NAME, ENROLMENT_STATUS, WITHDRAWAL_REASON_ID, PASTORAL_CARE_ID, " & vbCrLf & _
          "WITHDRAWAL_EXIT_DESTINATION," & vbCrLf & _
          "DATE_STUDENTFOLDER_CREATED, Age, STUDENT_EMAIL, " & vbCrLf & _
          "STUDENT_MOBILE, ATAR_REQUIRED, PORTAL_ACCESS, POSTAL_ADDRESS_ID, " & vbCrLf & _
          "CURR_RESID_ADDRESS_ID," & vbCrLf & _
          "ORIG_RESID_ADDRESS_ID, ORGANISATION_SCHOOL_ID, org_school_name, " & vbCrLf & _
          "LEARNING_PROGRAM_text, LEARNING_PROGRAM, SSG_FACILITATOR_ID," & vbCrLf & _
          "AgeNow, SEX_SELF_DESCRIBED, Pronouns, " & vbCrLf & _
          "FUNNEL_UUID " & vbCrLf & _
          "FROM viewStudentSummary_Details LEFT JOIN (ADDRESS LEFT JOIN POSTCODE_AREAS_REGIONS ON" & vbCrLf & _
          "ADDRESS.POSTCODE = POSTCODE_AREAS_REGIONS.Postcode) ON" & vbCrLf & _
          "viewStudentSummary_Details.CURR_RESID_ADDRESS_ID = ADDRESS.ADDRESS_ID {SQL_Where} {SQL_Ord" & _
          "erBy}", New String(){"student_id1282","And","ENROLMENT_YEAR1283"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record viewStudentSummary_Detail Data Provider Class Constructor

'Record viewStudentSummary_Detail Data Provider Class LoadParams Method @4-C4E7D325

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlstudent_id) Or IsNothing(UrlENROLMENT_YEAR))
    End Function
'End Record viewStudentSummary_Detail Data Provider Class LoadParams Method

'Record viewStudentSummary_Detail Data Provider Class CheckUnique Method @4-EC588046

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As viewStudentSummary_DetailItem) As Boolean
        Return True
    End Function
'End Record viewStudentSummary_Detail Data Provider Class CheckUnique Method

'Record viewStudentSummary_Detail Data Provider Class GetResultSet Method @4-7F3D6DB7

    Public Sub FillItem(ByVal item As viewStudentSummary_DetailItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record viewStudentSummary_Detail Data Provider Class GetResultSet Method

'Record viewStudentSummary_Detail BeforeBuildSelect @4-4BB7D3B9
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("student_id1282",Urlstudent_id, "","viewStudentSummary_Details.STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR1283",UrlENROLMENT_YEAR, "","viewStudentSummary_Details.ENROLMENT_YEAR",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record viewStudentSummary_Detail BeforeBuildSelect

'Record viewStudentSummary_Detail BeforeExecuteSelect @4-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record viewStudentSummary_Detail BeforeExecuteSelect

'DEL      ' -------------------------
'DEL      ' ERA:28-Feb-2011|EA| set number of records found for redirecting if no students
'DEL  	intStudentCount = dr.Count
'DEL      ' -------------------------


'Record viewStudentSummary_Detail AfterExecuteSelect @4-1628C1E1
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.Student_id.SetValue(dr(i)("student_id"),"")
            item.enrolment_date.SetValue(dr(i)("enrolment_date"),"")
            item.withdrawal_date.SetValue(dr(i)("withdrawal_date"),"")
            item.ENROLMENT_STATUS.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.WITHDRAWAL_REASON_ID.SetValue(dr(i)("WITHDRAWAL_REASON_ID"),"")
            item.surname.SetValue(dr(i)("surname"),"")
            item.first_name.SetValue(dr(i)("first_name"),"")
            item.middle_name.SetValue(dr(i)("middle_name"),"")
            item.SEX.SetValue(dr(i)("SEX"),"")
            item.YEAR_LEVEL.SetValue(dr(i)("YEAR_LEVEL"),"")
            item.EnrolmentYear.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.receipt_no.SetValue(dr(i)("receipt_no"),"")
            item.subcategory_full_title.SetValue(dr(i)("subcategory_full_title"),"")
            item.attending_school_name.SetValue(dr(i)("attending_school_name"),"")
            item.ATTENDING_SCHOOL_ID.SetValue(dr(i)("ATTENDING_SCHOOL_ID"),"")
            item.home_school_name.SetValue(dr(i)("home_school_name"),"")
            item.HOME_SCHOOL_ID.SetValue(dr(i)("HOME_SCHOOL_ID"),"")
            item.POSTAL_ADDRESS_ID.SetValue(dr(i)("POSTAL_ADDRESS_ID"),"")
            item.CURR_RESID_ADDRESS_ID.SetValue(dr(i)("CURR_RESID_ADDRESS_ID"),"")
            item.ORIG_RESID_ADDRESS_ID.SetValue(dr(i)("ORIG_RESID_ADDRESS_ID"),"")
            item.VSN.SetValue(dr(i)("VSN"),"")
            item.VSR_Enrolled.SetValue(dr(i)("EnrolledBefore"),"")
            item.birth_date.SetValue(dr(i)("birth_date"),"")
            item.preferred_name.SetValue(dr(i)("PREFERRED_NAME"),"")
            item.WD_EXIT_DESTINATION.SetValue(dr(i)("WITHDRAWAL_EXIT_DESTINATION"),"")
            item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(dr(i)("DATE_STUDENTFOLDER_CREATED"),Select_.DateFormat)
            item.label_Age.SetValue(dr(i)("AgeNow"),"")
            item.link_create_teacheremailsHref = ""
            item.STUDENT_EMAIL.SetValue(dr(i)("STUDENT_EMAIL"),"")
            item.STUDENT_EMAILHref = dr(i)("STUDENT_EMAIL")
            item.STUDENT_MOBILE.SetValue(dr(i)("STUDENT_MOBILE"),"")
            item.ATAR_REQUIRED.SetValue(dr(i)("ATAR_REQUIRED"),"")
            item.link_create_parentemailsHref = ""
            item.PORTAL_ACCESS.SetValue(dr(i)("PORTAL_ACCESS"),"")
            item.PASTORAL_CARE_ID.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.lblAreaDisplay.SetValue(dr(i)("Area"),"")
            item.lblRegionDisplay.SetValue(dr(i)("Region"),"")
            item.lblEnrolStatus.SetValue(dr(i)("ENROLMENT_STATUS"),"")
            item.org_school_name.SetValue(dr(i)("org_school_name"),"")
            item.ORGANISATION_SCHOOL_ID.SetValue(dr(i)("ORGANISATION_SCHOOL_ID"),"")
            item.Link1Href = "http://intranet/Reports/Pages/Folder.aspx?ItemPath=%2fNightly+Reports"
            item.lblPLP.SetValue(dr(i)("LEARNING_PROGRAM"),"")
            item.LEARNING_PROGRAM_text.SetValue(dr(i)("LEARNING_PROGRAM_text"),"")
            item.link_showstudentreportsHref = ""
            item.link_showstudentfolderHref = ""
            item.SSG_FACILITATOR_ID.SetValue(dr(i)("SSG_FACILITATOR_ID"),"")
            item.LinkLearningAdvisorEmail.SetValue(dr(i)("PASTORAL_CARE_ID"),"")
            item.LinkLearningAdvisorEmailHref = dr(i)("PASTORAL_CARE_ID")
            item.hidden_SEX_SELF_DESCRIBED.SetValue(dr(i)("SEX_SELF_DESCRIBED"),"")
            item.Pronouns.SetValue(dr(i)("Pronouns"),"")
            item.FunnelLinkHref = "https://vsv-au-vic-691.app.digistorm.com/admin/crm/leads"
            item.FilesLinkHref = "http://vsv-app02:65003/"
            item.FunnelUUID.SetValue(dr(i)("Funnel_UUID"),"")
            item.ReferralsLinkHref = "Referrals.aspx"
        Else
            IsInsertMode = True
        End If
'End Record viewStudentSummary_Detail AfterExecuteSelect

'Record viewStudentSummary_Detail AfterExecuteSelect tail @4-E31F8E2A
    End Sub
'End Record viewStudentSummary_Detail AfterExecuteSelect tail

'Record viewStudentSummary_Detail Data Provider Class @4-A61BA892
End Class

'End Record viewStudentSummary_Detail Data Provider Class

'Grid viewStudentSummary_SubjectList Item Class @36-A796CBE1
Public Class viewStudentSummary_SubjectListItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ID As IntegerField
    Public SUBJECT_TITLE As TextField
    Public SEMESTER As TextField
    Public SUBJ_ENROL_STATUS As TextField
    Public enrolment_date As DateField
    Public withdrawal_date As DateField
    Public NUM_ASSMT_SUBMISSIONS As IntegerField
    Public STAFF_ID As TextField
    Public INTERIM_PROGRESS_CODE As TextField
    Public FINAL_PROGRESS_CODE As TextField
    Public CUSTOM_LP_display As TextField
    Public EXTENSION_OF_VCE_UNIT_display As TextField
    Public NON_SUBMITTING_FLAG_display As TextField
    Public SUBJECT_ABBREV As TextField
    Public CLASS_CODE As TextField
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    SEMESTER = New TextField("", Nothing)
    SUBJ_ENROL_STATUS = New TextField("", Nothing)
    enrolment_date = New DateField("dd\/MM\/yyyy", Nothing)
    withdrawal_date = New DateField("dd\/MM\/yyyy", Nothing)
    NUM_ASSMT_SUBMISSIONS = New IntegerField("", Nothing)
    STAFF_ID = New TextField("", Nothing)
    INTERIM_PROGRESS_CODE = New TextField("", Nothing)
    FINAL_PROGRESS_CODE = New TextField("", Nothing)
    CUSTOM_LP_display = New TextField("", Nothing)
    EXTENSION_OF_VCE_UNIT_display = New TextField("", Nothing)
    NON_SUBMITTING_FLAG_display = New TextField("", Nothing)
    SUBJECT_ABBREV = New TextField("", Nothing)
    CLASS_CODE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return Me.SUBJECT_ID
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "SEMESTER"
                    Return Me.SEMESTER
                Case "SUBJ_ENROL_STATUS"
                    Return Me.SUBJ_ENROL_STATUS
                Case "enrolment_date"
                    Return Me.enrolment_date
                Case "withdrawal_date"
                    Return Me.withdrawal_date
                Case "NUM_ASSMT_SUBMISSIONS"
                    Return Me.NUM_ASSMT_SUBMISSIONS
                Case "STAFF_ID"
                    Return Me.STAFF_ID
                Case "INTERIM_PROGRESS_CODE"
                    Return Me.INTERIM_PROGRESS_CODE
                Case "FINAL_PROGRESS_CODE"
                    Return Me.FINAL_PROGRESS_CODE
                Case "CUSTOM_LP_display"
                    Return Me.CUSTOM_LP_display
                Case "EXTENSION_OF_VCE_UNIT_display"
                    Return Me.EXTENSION_OF_VCE_UNIT_display
                Case "NON_SUBMITTING_FLAG_display"
                    Return Me.NON_SUBMITTING_FLAG_display
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "CLASS_CODE"
                    Return Me.CLASS_CODE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    Me.SUBJECT_ID = CType(Value,IntegerField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "SEMESTER"
                    Me.SEMESTER = CType(Value,TextField)
                Case "SUBJ_ENROL_STATUS"
                    Me.SUBJ_ENROL_STATUS = CType(Value,TextField)
                Case "enrolment_date"
                    Me.enrolment_date = CType(Value,DateField)
                Case "withdrawal_date"
                    Me.withdrawal_date = CType(Value,DateField)
                Case "NUM_ASSMT_SUBMISSIONS"
                    Me.NUM_ASSMT_SUBMISSIONS = CType(Value,IntegerField)
                Case "STAFF_ID"
                    Me.STAFF_ID = CType(Value,TextField)
                Case "INTERIM_PROGRESS_CODE"
                    Me.INTERIM_PROGRESS_CODE = CType(Value,TextField)
                Case "FINAL_PROGRESS_CODE"
                    Me.FINAL_PROGRESS_CODE = CType(Value,TextField)
                Case "CUSTOM_LP_display"
                    Me.CUSTOM_LP_display = CType(Value,TextField)
                Case "EXTENSION_OF_VCE_UNIT_display"
                    Me.EXTENSION_OF_VCE_UNIT_display = CType(Value,TextField)
                Case "NON_SUBMITTING_FLAG_display"
                    Me.NON_SUBMITTING_FLAG_display = CType(Value,TextField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "CLASS_CODE"
                    Me.CLASS_CODE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid viewStudentSummary_SubjectList Item Class

'Grid viewStudentSummary_SubjectList Data Provider Class Header @36-A1889D10
Public Class viewStudentSummary_SubjectListDataProvider
Inherits GridDataProviderBase
'End Grid viewStudentSummary_SubjectList Data Provider Class Header

'Grid viewStudentSummary_SubjectList Data Provider Class Variables @36-F884FF7B

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"SUBJECT_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"SUBJECT_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
    Public Urlstudent_id  As IntegerParameter
    Public Urlenrolment_year  As FloatParameter
'End Grid viewStudentSummary_SubjectList Data Provider Class Variables

'Grid viewStudentSummary_SubjectList Data Provider Class GetResultSet Method @36-02FB5A20

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} RTRIM(subject_title) AS SUBJECT_TITLE_trimmed, " & vbCrLf & _
          "SUBJECT_ID, SEMESTER, SUBJ_ENROL_STATUS, NUM_ASSMT_SUBMISSIONS, STAFF_ID, " & vbCrLf & _
          "INTERIM_PROGRESS_CODE," & vbCrLf & _
          "FINAL_PROGRESS_CODE, MODULE_CUSTOMPROGRAM, MODULE_NEXTMODULE, " & vbCrLf & _
          "MODULE_CUSTOMPROGRAM_display, EXTENSION_OF_VCE_UNIT_display," & vbCrLf & _
          "NON_SUBMITTING_FLAG, " & vbCrLf & _
          "NON_SUBMITTING_FLAG_display, SUBJECT_ABBREV, enrolment_date2, withdrawal_date2, " & vbCrLf & _
          "CLASS_CODE " & vbCrLf & _
          "FROM viewStudentSummary_SubjectList {SQL_Where} {SQL_OrderBy}", New String(){"student_id1190","And","enrolment_year1191","And","expr1192"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM viewStudentSummary_SubjectList", New String(){"student_id1190","And","enrolment_year1191","And","expr1192"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid viewStudentSummary_SubjectList Data Provider Class GetResultSet Method

'Grid viewStudentSummary_SubjectList Data Provider Class GetResultSet Method @36-B21AF8B4
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As viewStudentSummary_SubjectListItem()
'End Grid viewStudentSummary_SubjectList Data Provider Class GetResultSet Method

'Before build Select @36-00C2A1EF
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("student_id1190",Urlstudent_id, "","student_id",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("enrolment_year1191",Urlenrolment_year, "","enrolment_year",Condition.Equal,False)
        Select_.Parameters.Add("expr1192","(parent_subject_id <= 0)")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @36-6CA6D9AA
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As viewStudentSummary_SubjectListItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @36-88FE743C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewStudentSummary_SubjectListItem(dr.Count-1) {}
'End After execute Select

'After execute Select @36-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @36-3595F0D4
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewStudentSummary_SubjectListItem = New viewStudentSummary_SubjectListItem()
                item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
                item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE_trimmed"),"")
                item.SEMESTER.SetValue(dr(i)("SEMESTER"),"")
                item.SUBJ_ENROL_STATUS.SetValue(dr(i)("SUBJ_ENROL_STATUS"),"")
                item.enrolment_date.SetValue(dr(i)("enrolment_date2"),Select_.DateFormat)
                item.withdrawal_date.SetValue(dr(i)("withdrawal_date2"),Select_.DateFormat)
                item.NUM_ASSMT_SUBMISSIONS.SetValue(dr(i)("NUM_ASSMT_SUBMISSIONS"),"")
                item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
                item.INTERIM_PROGRESS_CODE.SetValue(dr(i)("INTERIM_PROGRESS_CODE"),"")
                item.FINAL_PROGRESS_CODE.SetValue(dr(i)("FINAL_PROGRESS_CODE"),"")
                item.CUSTOM_LP_display.SetValue(dr(i)("MODULE_CUSTOMPROGRAM_display"),"")
                item.EXTENSION_OF_VCE_UNIT_display.SetValue(dr(i)("EXTENSION_OF_VCE_UNIT_display"),"")
                item.NON_SUBMITTING_FLAG_display.SetValue(dr(i)("NON_SUBMITTING_FLAG_display"),"")
                item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
                item.CLASS_CODE.SetValue(dr(i)("CLASS_CODE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @36-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_COMMENT Item Class @50-39C09FB2
Public Class STUDENT_COMMENTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public COMMENT_TYPE As TextField
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    COMMENT_TYPE = New TextField("", "unknown")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT"
                    Return Me.COMMENT
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_COMMENT Item Class

'Grid STUDENT_COMMENT Data Provider Class Header @50-19CB4552
Public Class STUDENT_COMMENTDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_COMMENT Data Provider Class Header

'Grid STUDENT_COMMENT Data Provider Class Variables @50-09E75BD1

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid STUDENT_COMMENT Data Provider Class Variables

'Grid STUDENT_COMMENT Data Provider Class GetResultSet Method @50-B4796F75

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} COMMENT, LAST_ALTERED_BY, LAST_ALTERED_DATE, " & vbCrLf & _
          "COMMENT_TYPE, COMMENT_ID " & vbCrLf & _
          "FROM STUDENT_COMMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID769","And","expr770","And","expr771"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_COMMENT", New String(){"STUDENT_ID769","And","expr770","And","expr771"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_COMMENT Data Provider Class GetResultSet Method

'Grid STUDENT_COMMENT Data Provider Class GetResultSet Method @50-295CB1EA
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_COMMENTItem()
'End Grid STUDENT_COMMENT Data Provider Class GetResultSet Method

'Before build Select @50-7548313D
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID769",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        Select_.Parameters.Add("expr770","(COMMENT_TYPE not like 'CONTACT%')")
        Select_.Parameters.Add("expr771","(ACTIVE_STATUS = 'A')")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @50-3447EB04
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_COMMENTItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @50-DC6801F3
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_COMMENTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @50-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @50-23AFA651
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @50-A61BA892
End Class
'End Grid Data Provider tail

'Report viewStudentSummary_Enrolm Item Class @185-ECBBE38B
Public Class viewStudentSummary_EnrolmItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public eligible_for_discount_desc As TextField
    Public paid_on_enrolment_desc As TextField
    Public full_time_desc As TextField
    Public os_full_fee_paying_desc As TextField
    Public address_review_flag_desc As TextField
    Public eligible_for_funding_desc As TextField
    Public vce_candidate_number As TextField
    Public bulletin_number As TextField
    Public last_reviewed_date As TextField
    Public new_docs_required_desc As TextField
    Public enrolment_comments As TextField
    Public Sub New()
    eligible_for_discount_desc = New TextField("", Nothing)
    paid_on_enrolment_desc = New TextField("", Nothing)
    full_time_desc = New TextField("", Nothing)
    os_full_fee_paying_desc = New TextField("", Nothing)
    address_review_flag_desc = New TextField("", Nothing)
    eligible_for_funding_desc = New TextField("", Nothing)
    vce_candidate_number = New TextField("", Nothing)
    bulletin_number = New TextField("", Nothing)
    last_reviewed_date = New TextField("", Nothing)
    new_docs_required_desc = New TextField("", Nothing)
    enrolment_comments = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "eligible_for_discount_desc"
                    Return Me.eligible_for_discount_desc
                Case "paid_on_enrolment_desc"
                    Return Me.paid_on_enrolment_desc
                Case "full_time_desc"
                    Return Me.full_time_desc
                Case "os_full_fee_paying_desc"
                    Return Me.os_full_fee_paying_desc
                Case "address_review_flag_desc"
                    Return Me.address_review_flag_desc
                Case "eligible_for_funding_desc"
                    Return Me.eligible_for_funding_desc
                Case "vce_candidate_number"
                    Return Me.vce_candidate_number
                Case "bulletin_number"
                    Return Me.bulletin_number
                Case "last_reviewed_date"
                    Return Me.last_reviewed_date
                Case "new_docs_required_desc"
                    Return Me.new_docs_required_desc
                Case "enrolment_comments"
                    Return Me.enrolment_comments
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "eligible_for_discount_desc"
                    Me.eligible_for_discount_desc = CType(Value,TextField)
                Case "paid_on_enrolment_desc"
                    Me.paid_on_enrolment_desc = CType(Value,TextField)
                Case "full_time_desc"
                    Me.full_time_desc = CType(Value,TextField)
                Case "os_full_fee_paying_desc"
                    Me.os_full_fee_paying_desc = CType(Value,TextField)
                Case "address_review_flag_desc"
                    Me.address_review_flag_desc = CType(Value,TextField)
                Case "eligible_for_funding_desc"
                    Me.eligible_for_funding_desc = CType(Value,TextField)
                Case "vce_candidate_number"
                    Me.vce_candidate_number = CType(Value,TextField)
                Case "bulletin_number"
                    Me.bulletin_number = CType(Value,TextField)
                Case "last_reviewed_date"
                    Me.last_reviewed_date = CType(Value,TextField)
                Case "new_docs_required_desc"
                    Me.new_docs_required_desc = CType(Value,TextField)
                Case "enrolment_comments"
                    Me.enrolment_comments = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report viewStudentSummary_Enrolm Item Class

'Report viewStudentSummary_Enrolm Data Provider Class Header @185-8F500050
Public Class viewStudentSummary_EnrolmDataProvider
Inherits GridDataProviderBase
'End Report viewStudentSummary_Enrolm Data Provider Class Header

'Report viewStudentSummary_Enrolm Data Provider Class Variables @185-249200FE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As FloatParameter
    Public UrlENROLMENT_YEAR  As FloatParameter
'End Report viewStudentSummary_Enrolm Data Provider Class Variables

'Report viewStudentSummary_Enrolm Data Provider Class GetResultSet Method @185-61990792

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM viewStudentSummary_EnrolmentMisc {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID205","And","ENROLMENT_YEAR206"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report viewStudentSummary_Enrolm Data Provider Class GetResultSet Method

'Report viewStudentSummary_Enrolm Data Provider Class GetResultSet Method @185-180732F3
    Public Function GetResultSet(ops As FormSupportedOperations) As viewStudentSummary_EnrolmItem()
'End Report viewStudentSummary_Enrolm Data Provider Class GetResultSet Method

'Before build Select @185-555D225F
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID205",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("ENROLMENT_YEAR206",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @185-D991B1CD
        Dim ds As DataSet = Nothing
        Dim result(-1) As viewStudentSummary_EnrolmItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @185-1BD0681D
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewStudentSummary_EnrolmItem(dr.Count-1) {}
'End After execute Select

'After execute Select @185-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @185-EF96F043
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewStudentSummary_EnrolmItem = New viewStudentSummary_EnrolmItem()
                item.eligible_for_discount_desc.SetValue(dr(i)("eligible_for_discount_desc"),"")
                item.paid_on_enrolment_desc.SetValue(dr(i)("paid_on_enrolment_desc"),"")
                item.full_time_desc.SetValue(dr(i)("full_time_desc"),"")
                item.os_full_fee_paying_desc.SetValue(dr(i)("os_full_fee_paying_desc"),"")
                item.address_review_flag_desc.SetValue(dr(i)("address_review_flag_desc"),"")
                item.eligible_for_funding_desc.SetValue(dr(i)("eligible_for_funding_desc"),"")
                item.vce_candidate_number.SetValue(dr(i)("vce_candidate_number"),"")
                item.bulletin_number.SetValue(dr(i)("bulletin_number"),"")
                item.last_reviewed_date.SetValue(dr(i)("last_reviewed_date"),"")
                item.new_docs_required_desc.SetValue(dr(i)("new_docs_required_desc"),"")
                item.enrolment_comments.SetValue(dr(i)("enrolment_comments"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @185-A61BA892
End Class
'End Report Data Provider tail

'Report ADDRESS_Postal Item Class @60-EB72FCD8
Public Class ADDRESS_PostalItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_A As TextField
    Public PHONE_B As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public ADDRESS_ID As FloatField
    Public ImageLink_GoogleMaps_postal As TextField
    Public ImageLink_GoogleMaps_postalHref As Object
    Public ImageLink_GoogleMaps_postalHrefParameters As LinkParameterCollection
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    ADDRESS_ID = New FloatField("", Nothing)
    ImageLink_GoogleMaps_postal = New TextField("",Nothing)
    ImageLink_GoogleMaps_postalHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ADDRESSEE"
                    Return Me.ADDRESSEE
                Case "AGENT"
                    Return Me.AGENT
                Case "ADDR1"
                    Return Me.ADDR1
                Case "ADDR2"
                    Return Me.ADDR2
                Case "SUBURB_TOWN"
                    Return Me.SUBURB_TOWN
                Case "STATE"
                    Return Me.STATE
                Case "POSTCODE"
                    Return Me.POSTCODE
                Case "COUNTRY"
                    Return Me.COUNTRY
                Case "PHONE_A"
                    Return Me.PHONE_A
                Case "PHONE_B"
                    Return Me.PHONE_B
                Case "FAX"
                    Return Me.FAX
                Case "EMAIL_ADDRESS"
                    Return Me.EMAIL_ADDRESS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "ADDRESS_ID"
                    Return Me.ADDRESS_ID
                Case "ImageLink_GoogleMaps_postal"
                    Return Me.ImageLink_GoogleMaps_postal
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESSEE"
                    Me.ADDRESSEE = CType(Value,TextField)
                Case "AGENT"
                    Me.AGENT = CType(Value,TextField)
                Case "ADDR1"
                    Me.ADDR1 = CType(Value,TextField)
                Case "ADDR2"
                    Me.ADDR2 = CType(Value,TextField)
                Case "SUBURB_TOWN"
                    Me.SUBURB_TOWN = CType(Value,TextField)
                Case "STATE"
                    Me.STATE = CType(Value,TextField)
                Case "POSTCODE"
                    Me.POSTCODE = CType(Value,TextField)
                Case "COUNTRY"
                    Me.COUNTRY = CType(Value,TextField)
                Case "PHONE_A"
                    Me.PHONE_A = CType(Value,TextField)
                Case "PHONE_B"
                    Me.PHONE_B = CType(Value,TextField)
                Case "FAX"
                    Me.FAX = CType(Value,TextField)
                Case "EMAIL_ADDRESS"
                    Me.EMAIL_ADDRESS = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "ADDRESS_ID"
                    Me.ADDRESS_ID = CType(Value,FloatField)
                Case "ImageLink_GoogleMaps_postal"
                    Me.ImageLink_GoogleMaps_postal = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report ADDRESS_Postal Item Class

'Report ADDRESS_Postal Data Provider Class Header @60-75A0F020
Public Class ADDRESS_PostalDataProvider
Inherits GridDataProviderBase
'End Report ADDRESS_Postal Data Provider Class Header

'Report ADDRESS_Postal Data Provider Class Variables @60-7789BC61

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public Expr84  As FloatParameter
'End Report ADDRESS_Postal Data Provider Class Variables

'Report ADDRESS_Postal Data Provider Class GetResultSet Method @60-16E86DE9

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"(","expr84",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report ADDRESS_Postal Data Provider Class GetResultSet Method

'Report ADDRESS_Postal Data Provider Class GetResultSet Method @60-D5808DD3
    Public Function GetResultSet(ops As FormSupportedOperations) As ADDRESS_PostalItem()
'End Report ADDRESS_Postal Data Provider Class GetResultSet Method

'Before build Select @60-CA08ED31
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr84",Expr84, "","ADDRESS_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @60-D6E0CFE2
        Dim ds As DataSet = Nothing
        Dim result(-1) As ADDRESS_PostalItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @60-F13C0720
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ADDRESS_PostalItem(dr.Count-1) {}
'End After execute Select

'After execute Select @60-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @60-C976E55C
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ADDRESS_PostalItem = New ADDRESS_PostalItem()
                item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
                item.AGENT.SetValue(dr(i)("AGENT"),"")
                item.ADDR1.SetValue(dr(i)("ADDR1"),"")
                item.ADDR2.SetValue(dr(i)("ADDR2"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.STATE.SetValue(dr(i)("STATE"),"")
                item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
                item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
                item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
                item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.ADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
                item.ImageLink_GoogleMaps_postalHref = "http://maps.google.com.au/maps?f=q&source=s_q&hl=en&geocode=&ie=UTF8&z=14"
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @60-A61BA892
End Class
'End Report Data Provider tail

'Report ADDRESS_Current Item Class @121-F8A3CFB0
Public Class ADDRESS_CurrentItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_A As TextField
    Public PHONE_B As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public ADDRESS_ID As FloatField
    Public ImageLink_GoogleMaps_current As TextField
    Public ImageLink_GoogleMaps_currentHref As Object
    Public ImageLink_GoogleMaps_currentHrefParameters As LinkParameterCollection
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    ADDRESS_ID = New FloatField("", Nothing)
    ImageLink_GoogleMaps_current = New TextField("",Nothing)
    ImageLink_GoogleMaps_currentHrefParameters = New LinkParameterCollection()
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ADDRESSEE"
                    Return Me.ADDRESSEE
                Case "AGENT"
                    Return Me.AGENT
                Case "ADDR1"
                    Return Me.ADDR1
                Case "ADDR2"
                    Return Me.ADDR2
                Case "SUBURB_TOWN"
                    Return Me.SUBURB_TOWN
                Case "STATE"
                    Return Me.STATE
                Case "POSTCODE"
                    Return Me.POSTCODE
                Case "COUNTRY"
                    Return Me.COUNTRY
                Case "PHONE_A"
                    Return Me.PHONE_A
                Case "PHONE_B"
                    Return Me.PHONE_B
                Case "FAX"
                    Return Me.FAX
                Case "EMAIL_ADDRESS"
                    Return Me.EMAIL_ADDRESS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "ADDRESS_ID"
                    Return Me.ADDRESS_ID
                Case "ImageLink_GoogleMaps_current"
                    Return Me.ImageLink_GoogleMaps_current
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESSEE"
                    Me.ADDRESSEE = CType(Value,TextField)
                Case "AGENT"
                    Me.AGENT = CType(Value,TextField)
                Case "ADDR1"
                    Me.ADDR1 = CType(Value,TextField)
                Case "ADDR2"
                    Me.ADDR2 = CType(Value,TextField)
                Case "SUBURB_TOWN"
                    Me.SUBURB_TOWN = CType(Value,TextField)
                Case "STATE"
                    Me.STATE = CType(Value,TextField)
                Case "POSTCODE"
                    Me.POSTCODE = CType(Value,TextField)
                Case "COUNTRY"
                    Me.COUNTRY = CType(Value,TextField)
                Case "PHONE_A"
                    Me.PHONE_A = CType(Value,TextField)
                Case "PHONE_B"
                    Me.PHONE_B = CType(Value,TextField)
                Case "FAX"
                    Me.FAX = CType(Value,TextField)
                Case "EMAIL_ADDRESS"
                    Me.EMAIL_ADDRESS = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "ADDRESS_ID"
                    Me.ADDRESS_ID = CType(Value,FloatField)
                Case "ImageLink_GoogleMaps_current"
                    Me.ImageLink_GoogleMaps_current = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report ADDRESS_Current Item Class

'Report ADDRESS_Current Data Provider Class Header @121-D9FAEDC8
Public Class ADDRESS_CurrentDataProvider
Inherits GridDataProviderBase
'End Report ADDRESS_Current Data Provider Class Header

'Report ADDRESS_Current Data Provider Class Variables @121-698DA33C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public Expr144  As FloatParameter
'End Report ADDRESS_Current Data Provider Class Variables

'Report ADDRESS_Current Data Provider Class GetResultSet Method @121-30024135

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"(","expr144",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report ADDRESS_Current Data Provider Class GetResultSet Method

'Report ADDRESS_Current Data Provider Class GetResultSet Method @121-352A7A2B
    Public Function GetResultSet(ops As FormSupportedOperations) As ADDRESS_CurrentItem()
'End Report ADDRESS_Current Data Provider Class GetResultSet Method

'Before build Select @121-1E23A518
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr144",Expr144, "","ADDRESS_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @121-1BA74085
        Dim ds As DataSet = Nothing
        Dim result(-1) As ADDRESS_CurrentItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @121-0631CBC5
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ADDRESS_CurrentItem(dr.Count-1) {}
'End After execute Select

'After execute Select @121-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @121-A453617F
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ADDRESS_CurrentItem = New ADDRESS_CurrentItem()
                item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
                item.AGENT.SetValue(dr(i)("AGENT"),"")
                item.ADDR1.SetValue(dr(i)("ADDR1"),"")
                item.ADDR2.SetValue(dr(i)("ADDR2"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.STATE.SetValue(dr(i)("STATE"),"")
                item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
                item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
                item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
                item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.ADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
                item.ImageLink_GoogleMaps_currentHref = "http://maps.google.com.au/maps?f=q&source=s_q&hl=en&geocode=&ie=UTF8&z=14"
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @121-A61BA892
End Class
'End Report Data Provider tail

'Report STUDENT_CENSUS_DATA Item Class @85-6EA21E70
Public Class STUDENT_CENSUS_DATAItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COUNTRY_OF_BIRTH As TextField
    Public DATE_STARTED_IN_AUST As DateField
    Public FIRST_HOME_LANGUAGE As TextField
    Public OTHER_HOME_LANGUAGE As TextField
    Public MOTHERS_COB As TextField
    Public FATHERS_COB As TextField
    Public MOTHER_LANGUAGE As TextField
    Public FATHER_LANGUAGE As TextField
    Public MOTHER_EDUCATION_SCHOOL As TextField
    Public FATHER_EDUCATION_SCHOOL As TextField
    Public MOTHER_EDUCATION_NONSCHOOL As TextField
    Public FATHER_EDUCATION_NONSCHOOL As TextField
    Public MOTHER_OCCUPATIONGROUP As TextField
    Public FATHER_OCCUPATIONGROUP As TextField
    Public ALLOWANCE_TITLE As TextField
    Public KOORITORRESFLAG As TextField
    Public RESIDENTIAL_STATUS As TextField
    Public DATE_ARRIVED_IN_AUST As DateField
    Public VISA_SUB_CLASS As FloatField
    Public VISA_STATISTICAL_CODE As TextField
    Public PREVIOUS_SCHOOL_ID As FloatField
    Public FAMILY_OSG As FloatField
    Public HOUSEHOLD_STATUS As TextField
    Public DISABILITY_ID As FloatField
    Public REPEATING_YEAR As TextField
    Public OTHER_SCHOOL_TF As FloatField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public STUDENT_ID As FloatField
    Public Sub New()
    COUNTRY_OF_BIRTH = New TextField("", Nothing)
    DATE_STARTED_IN_AUST = New DateField("dd\/MM\/yyyy", Nothing)
    FIRST_HOME_LANGUAGE = New TextField("", Nothing)
    OTHER_HOME_LANGUAGE = New TextField("", Nothing)
    MOTHERS_COB = New TextField("", Nothing)
    FATHERS_COB = New TextField("", Nothing)
    MOTHER_LANGUAGE = New TextField("", Nothing)
    FATHER_LANGUAGE = New TextField("", Nothing)
    MOTHER_EDUCATION_SCHOOL = New TextField("", Nothing)
    FATHER_EDUCATION_SCHOOL = New TextField("", Nothing)
    MOTHER_EDUCATION_NONSCHOOL = New TextField("", Nothing)
    FATHER_EDUCATION_NONSCHOOL = New TextField("", Nothing)
    MOTHER_OCCUPATIONGROUP = New TextField("", Nothing)
    FATHER_OCCUPATIONGROUP = New TextField("", Nothing)
    ALLOWANCE_TITLE = New TextField("", Nothing)
    KOORITORRESFLAG = New TextField("", Nothing)
    RESIDENTIAL_STATUS = New TextField("", Nothing)
    DATE_ARRIVED_IN_AUST = New DateField("dd\/MM\/yyyy", Nothing)
    VISA_SUB_CLASS = New FloatField("", Nothing)
    VISA_STATISTICAL_CODE = New TextField("", Nothing)
    PREVIOUS_SCHOOL_ID = New FloatField("", Nothing)
    FAMILY_OSG = New FloatField("", Nothing)
    HOUSEHOLD_STATUS = New TextField("", Nothing)
    DISABILITY_ID = New FloatField("", Nothing)
    REPEATING_YEAR = New TextField("", Nothing)
    OTHER_SCHOOL_TF = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COUNTRY_OF_BIRTH"
                    Return Me.COUNTRY_OF_BIRTH
                Case "DATE_STARTED_IN_AUST"
                    Return Me.DATE_STARTED_IN_AUST
                Case "FIRST_HOME_LANGUAGE"
                    Return Me.FIRST_HOME_LANGUAGE
                Case "OTHER_HOME_LANGUAGE"
                    Return Me.OTHER_HOME_LANGUAGE
                Case "MOTHERS_COB"
                    Return Me.MOTHERS_COB
                Case "FATHERS_COB"
                    Return Me.FATHERS_COB
                Case "MOTHER_LANGUAGE"
                    Return Me.MOTHER_LANGUAGE
                Case "FATHER_LANGUAGE"
                    Return Me.FATHER_LANGUAGE
                Case "MOTHER_EDUCATION_SCHOOL"
                    Return Me.MOTHER_EDUCATION_SCHOOL
                Case "FATHER_EDUCATION_SCHOOL"
                    Return Me.FATHER_EDUCATION_SCHOOL
                Case "MOTHER_EDUCATION_NONSCHOOL"
                    Return Me.MOTHER_EDUCATION_NONSCHOOL
                Case "FATHER_EDUCATION_NONSCHOOL"
                    Return Me.FATHER_EDUCATION_NONSCHOOL
                Case "MOTHER_OCCUPATIONGROUP"
                    Return Me.MOTHER_OCCUPATIONGROUP
                Case "FATHER_OCCUPATIONGROUP"
                    Return Me.FATHER_OCCUPATIONGROUP
                Case "ALLOWANCE_TITLE"
                    Return Me.ALLOWANCE_TITLE
                Case "KOORITORRESFLAG"
                    Return Me.KOORITORRESFLAG
                Case "RESIDENTIAL_STATUS"
                    Return Me.RESIDENTIAL_STATUS
                Case "DATE_ARRIVED_IN_AUST"
                    Return Me.DATE_ARRIVED_IN_AUST
                Case "VISA_SUB_CLASS"
                    Return Me.VISA_SUB_CLASS
                Case "VISA_STATISTICAL_CODE"
                    Return Me.VISA_STATISTICAL_CODE
                Case "PREVIOUS_SCHOOL_ID"
                    Return Me.PREVIOUS_SCHOOL_ID
                Case "FAMILY_OSG"
                    Return Me.FAMILY_OSG
                Case "HOUSEHOLD_STATUS"
                    Return Me.HOUSEHOLD_STATUS
                Case "DISABILITY_ID"
                    Return Me.DISABILITY_ID
                Case "REPEATING_YEAR"
                    Return Me.REPEATING_YEAR
                Case "OTHER_SCHOOL_TF"
                    Return Me.OTHER_SCHOOL_TF
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COUNTRY_OF_BIRTH"
                    Me.COUNTRY_OF_BIRTH = CType(Value,TextField)
                Case "DATE_STARTED_IN_AUST"
                    Me.DATE_STARTED_IN_AUST = CType(Value,DateField)
                Case "FIRST_HOME_LANGUAGE"
                    Me.FIRST_HOME_LANGUAGE = CType(Value,TextField)
                Case "OTHER_HOME_LANGUAGE"
                    Me.OTHER_HOME_LANGUAGE = CType(Value,TextField)
                Case "MOTHERS_COB"
                    Me.MOTHERS_COB = CType(Value,TextField)
                Case "FATHERS_COB"
                    Me.FATHERS_COB = CType(Value,TextField)
                Case "MOTHER_LANGUAGE"
                    Me.MOTHER_LANGUAGE = CType(Value,TextField)
                Case "FATHER_LANGUAGE"
                    Me.FATHER_LANGUAGE = CType(Value,TextField)
                Case "MOTHER_EDUCATION_SCHOOL"
                    Me.MOTHER_EDUCATION_SCHOOL = CType(Value,TextField)
                Case "FATHER_EDUCATION_SCHOOL"
                    Me.FATHER_EDUCATION_SCHOOL = CType(Value,TextField)
                Case "MOTHER_EDUCATION_NONSCHOOL"
                    Me.MOTHER_EDUCATION_NONSCHOOL = CType(Value,TextField)
                Case "FATHER_EDUCATION_NONSCHOOL"
                    Me.FATHER_EDUCATION_NONSCHOOL = CType(Value,TextField)
                Case "MOTHER_OCCUPATIONGROUP"
                    Me.MOTHER_OCCUPATIONGROUP = CType(Value,TextField)
                Case "FATHER_OCCUPATIONGROUP"
                    Me.FATHER_OCCUPATIONGROUP = CType(Value,TextField)
                Case "ALLOWANCE_TITLE"
                    Me.ALLOWANCE_TITLE = CType(Value,TextField)
                Case "KOORITORRESFLAG"
                    Me.KOORITORRESFLAG = CType(Value,TextField)
                Case "RESIDENTIAL_STATUS"
                    Me.RESIDENTIAL_STATUS = CType(Value,TextField)
                Case "DATE_ARRIVED_IN_AUST"
                    Me.DATE_ARRIVED_IN_AUST = CType(Value,DateField)
                Case "VISA_SUB_CLASS"
                    Me.VISA_SUB_CLASS = CType(Value,FloatField)
                Case "VISA_STATISTICAL_CODE"
                    Me.VISA_STATISTICAL_CODE = CType(Value,TextField)
                Case "PREVIOUS_SCHOOL_ID"
                    Me.PREVIOUS_SCHOOL_ID = CType(Value,FloatField)
                Case "FAMILY_OSG"
                    Me.FAMILY_OSG = CType(Value,FloatField)
                Case "HOUSEHOLD_STATUS"
                    Me.HOUSEHOLD_STATUS = CType(Value,TextField)
                Case "DISABILITY_ID"
                    Me.DISABILITY_ID = CType(Value,FloatField)
                Case "REPEATING_YEAR"
                    Me.REPEATING_YEAR = CType(Value,TextField)
                Case "OTHER_SCHOOL_TF"
                    Me.OTHER_SCHOOL_TF = CType(Value,FloatField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report STUDENT_CENSUS_DATA Item Class

'Report STUDENT_CENSUS_DATA Data Provider Class Header @85-591AF277
Public Class STUDENT_CENSUS_DATADataProvider
Inherits GridDataProviderBase
'End Report STUDENT_CENSUS_DATA Data Provider Class Header

'Report STUDENT_CENSUS_DATA Data Provider Class Variables @85-78257C01

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As FloatParameter
'End Report STUDENT_CENSUS_DATA Data Provider Class Variables

'Report STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method @85-4A84184F

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM viewStudentSummary_CensusData {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID149"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method

'Report STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method @85-5C0F8033
    Public Function GetResultSet(ops As FormSupportedOperations) As STUDENT_CENSUS_DATAItem()
'End Report STUDENT_CENSUS_DATA Data Provider Class GetResultSet Method

'Before build Select @85-66EDA967
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID149",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @85-42B4C39B
        Dim ds As DataSet = Nothing
        Dim result(-1) As STUDENT_CENSUS_DATAItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @85-2157091F
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CENSUS_DATAItem(dr.Count-1) {}
'End After execute Select

'After execute Select @85-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @85-9BE7544D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
                item.COUNTRY_OF_BIRTH.SetValue(dr(i)("student_country_of_birth_desc"),"")
                item.DATE_STARTED_IN_AUST.SetValue(dr(i)("DATE_STARTED_IN_AUST"),Select_.DateFormat)
                item.FIRST_HOME_LANGUAGE.SetValue(dr(i)("first_home_language_desc"),"")
                item.OTHER_HOME_LANGUAGE.SetValue(dr(i)("other_home_language_desc"),"")
                item.MOTHERS_COB.SetValue(dr(i)("mother_country_of_birth_desc"),"")
                item.FATHERS_COB.SetValue(dr(i)("father_country_of_birth_desc"),"")
                item.MOTHER_LANGUAGE.SetValue(dr(i)("mother_language_desc"),"")
                item.FATHER_LANGUAGE.SetValue(dr(i)("father_language_desc"),"")
                item.MOTHER_EDUCATION_SCHOOL.SetValue(dr(i)("mother_education_school_desc"),"")
                item.FATHER_EDUCATION_SCHOOL.SetValue(dr(i)("father_education_school_desc"),"")
                item.MOTHER_EDUCATION_NONSCHOOL.SetValue(dr(i)("mother_education_nonschool_desc"),"")
                item.FATHER_EDUCATION_NONSCHOOL.SetValue(dr(i)("father_education_nonschool_desc"),"")
                item.MOTHER_OCCUPATIONGROUP.SetValue(dr(i)("mother_occupation_desc"),"")
                item.FATHER_OCCUPATIONGROUP.SetValue(dr(i)("father_occupation_desc"),"")
                item.ALLOWANCE_TITLE.SetValue(dr(i)("ALLOWANCE_TITLE"),"")
                item.KOORITORRESFLAG.SetValue(dr(i)("KooriTorres_desc"),"")
                item.RESIDENTIAL_STATUS.SetValue(dr(i)("residential_desc"),"")
                item.DATE_ARRIVED_IN_AUST.SetValue(dr(i)("DATE_ARRIVED_IN_AUST"),Select_.DateFormat)
                item.VISA_SUB_CLASS.SetValue(dr(i)("VISA_SUB_CLASS"),"")
                item.VISA_STATISTICAL_CODE.SetValue(dr(i)("VISA_STATISTICAL_CODE"),"")
                item.PREVIOUS_SCHOOL_ID.SetValue(dr(i)("PREVIOUS_SCHOOL_ID"),"")
                item.FAMILY_OSG.SetValue(dr(i)("FAMILY_OSG"),"")
                item.HOUSEHOLD_STATUS.SetValue(dr(i)("household_status_desc"),"")
                item.DISABILITY_ID.SetValue(dr(i)("DISABILITY_ID"),"")
                item.REPEATING_YEAR.SetValue(dr(i)("repeating_year_desc"),"")
                item.OTHER_SCHOOL_TF.SetValue(dr(i)("OTHER_SCHOOL_TF"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @85-A61BA892
End Class
'End Report Data Provider tail

'Report STUDENT_EQUIPMENT Item Class @150-37835A2F
Public Class STUDENT_EQUIPMENTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public STUDENT_ID As FloatField
    Public HAS_DER_PC As TextField
    Public ACCESS_COMPUTER As TextField
    Public ACCESS_INTERNET As TextField
    Public ACCESS_WORKEXAMPLES As TextField
    Public Sub New()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    HAS_DER_PC = New TextField("", Nothing)
    ACCESS_COMPUTER = New TextField("", "U")
    ACCESS_INTERNET = New TextField("", "U")
    ACCESS_WORKEXAMPLES = New TextField("", "U")
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "HAS_DER_PC"
                    Return Me.HAS_DER_PC
                Case "ACCESS_COMPUTER"
                    Return Me.ACCESS_COMPUTER
                Case "ACCESS_INTERNET"
                    Return Me.ACCESS_INTERNET
                Case "ACCESS_WORKEXAMPLES"
                    Return Me.ACCESS_WORKEXAMPLES
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "HAS_DER_PC"
                    Me.HAS_DER_PC = CType(Value,TextField)
                Case "ACCESS_COMPUTER"
                    Me.ACCESS_COMPUTER = CType(Value,TextField)
                Case "ACCESS_INTERNET"
                    Me.ACCESS_INTERNET = CType(Value,TextField)
                Case "ACCESS_WORKEXAMPLES"
                    Me.ACCESS_WORKEXAMPLES = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report STUDENT_EQUIPMENT Item Class

'Report STUDENT_EQUIPMENT Data Provider Class Header @150-2E14A4D6
Public Class STUDENT_EQUIPMENTDataProvider
Inherits GridDataProviderBase
'End Report STUDENT_EQUIPMENT Data Provider Class Header

'Report STUDENT_EQUIPMENT Data Provider Class Variables @150-78257C01

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As FloatParameter
'End Report STUDENT_EQUIPMENT Data Provider Class Variables

'Report STUDENT_EQUIPMENT Data Provider Class GetResultSet Method @150-1D4E87B7

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_EQUIPMENT {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID165"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report STUDENT_EQUIPMENT Data Provider Class GetResultSet Method

'Report STUDENT_EQUIPMENT Data Provider Class GetResultSet Method @150-CF56F1CB
    Public Function GetResultSet(ops As FormSupportedOperations) As STUDENT_EQUIPMENTItem()
'End Report STUDENT_EQUIPMENT Data Provider Class GetResultSet Method

'Before build Select @150-201F867C
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID165",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @150-5F173539
        Dim ds As DataSet = Nothing
        Dim result(-1) As STUDENT_EQUIPMENTItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @150-4861B3BC
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_EQUIPMENTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @150-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @150-5064187A
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.HAS_DER_PC.SetValue(dr(i)("HAS_DER_PC"),"")
                item.ACCESS_COMPUTER.SetValue(dr(i)("ACCESS_COMPUTER_2010"),"")
                item.ACCESS_INTERNET.SetValue(dr(i)("ACCESS_INTERNET_2010"),"")
                item.ACCESS_WORKEXAMPLES.SetValue(dr(i)("ACCESS_WORKEXAMPLES"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @150-A61BA892
End Class
'End Report Data Provider tail

'Report viewStudentSummary_Medica Item Class @167-185BD05E
Public Class viewStudentSummary_MedicaItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public immun_certificate_desc As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public allergies_flag_desc As TextField
    Public anaphylaxis_flag_desc As TextField
    Public anaphylaxis_warning As TextField
    Public STUDENT_ID As FloatField
    Public immun_diptheria_desc As TextField
    Public immun_tetanus_desc As TextField
    Public immun_polio_desc As TextField
    Public immun_measles_desc As TextField
    Public immun_mumps_desc As TextField
    Public DIAGNOSED_CONDITION As TextField
    Public HASOTHERCONDITIONS_desc As TextField
    Public OTHERCONDITIONS As TextField
    Public all_medical_conditions_desc As TextField
    Public Sub New()
    immun_certificate_desc = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    allergies_flag_desc = New TextField("", Nothing)
    anaphylaxis_flag_desc = New TextField("", Nothing)
    anaphylaxis_warning = New TextField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    immun_diptheria_desc = New TextField("", Nothing)
    immun_tetanus_desc = New TextField("", Nothing)
    immun_polio_desc = New TextField("", Nothing)
    immun_measles_desc = New TextField("", Nothing)
    immun_mumps_desc = New TextField("", Nothing)
    DIAGNOSED_CONDITION = New TextField("", Nothing)
    HASOTHERCONDITIONS_desc = New TextField("", Nothing)
    OTHERCONDITIONS = New TextField("", Nothing)
    all_medical_conditions_desc = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "immun_certificate_desc"
                    Return Me.immun_certificate_desc
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "allergies_flag_desc"
                    Return Me.allergies_flag_desc
                Case "anaphylaxis_flag_desc"
                    Return Me.anaphylaxis_flag_desc
                Case "anaphylaxis_warning"
                    Return Me.anaphylaxis_warning
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "immun_diptheria_desc"
                    Return Me.immun_diptheria_desc
                Case "immun_tetanus_desc"
                    Return Me.immun_tetanus_desc
                Case "immun_polio_desc"
                    Return Me.immun_polio_desc
                Case "immun_measles_desc"
                    Return Me.immun_measles_desc
                Case "immun_mumps_desc"
                    Return Me.immun_mumps_desc
                Case "DIAGNOSED_CONDITION"
                    Return Me.DIAGNOSED_CONDITION
                Case "HASOTHERCONDITIONS_desc"
                    Return Me.HASOTHERCONDITIONS_desc
                Case "OTHERCONDITIONS"
                    Return Me.OTHERCONDITIONS
                Case "all_medical_conditions_desc"
                    Return Me.all_medical_conditions_desc
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "immun_certificate_desc"
                    Me.immun_certificate_desc = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "allergies_flag_desc"
                    Me.allergies_flag_desc = CType(Value,TextField)
                Case "anaphylaxis_flag_desc"
                    Me.anaphylaxis_flag_desc = CType(Value,TextField)
                Case "anaphylaxis_warning"
                    Me.anaphylaxis_warning = CType(Value,TextField)
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "immun_diptheria_desc"
                    Me.immun_diptheria_desc = CType(Value,TextField)
                Case "immun_tetanus_desc"
                    Me.immun_tetanus_desc = CType(Value,TextField)
                Case "immun_polio_desc"
                    Me.immun_polio_desc = CType(Value,TextField)
                Case "immun_measles_desc"
                    Me.immun_measles_desc = CType(Value,TextField)
                Case "immun_mumps_desc"
                    Me.immun_mumps_desc = CType(Value,TextField)
                Case "DIAGNOSED_CONDITION"
                    Me.DIAGNOSED_CONDITION = CType(Value,TextField)
                Case "HASOTHERCONDITIONS_desc"
                    Me.HASOTHERCONDITIONS_desc = CType(Value,TextField)
                Case "OTHERCONDITIONS"
                    Me.OTHERCONDITIONS = CType(Value,TextField)
                Case "all_medical_conditions_desc"
                    Me.all_medical_conditions_desc = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report viewStudentSummary_Medica Item Class

'Report viewStudentSummary_Medica Data Provider Class Header @167-7D3BA639
Public Class viewStudentSummary_MedicaDataProvider
Inherits GridDataProviderBase
'End Report viewStudentSummary_Medica Data Provider Class Header

'Report viewStudentSummary_Medica Data Provider Class Variables @167-78257C01

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public UrlSTUDENT_ID  As FloatParameter
'End Report viewStudentSummary_Medica Data Provider Class Variables

'Report viewStudentSummary_Medica Data Provider Class GetResultSet Method @167-42FD356F

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM viewStudentSummary_Medical {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID503"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report viewStudentSummary_Medica Data Provider Class GetResultSet Method

'Report viewStudentSummary_Medica Data Provider Class GetResultSet Method @167-7A0033B4
    Public Function GetResultSet(ops As FormSupportedOperations) As viewStudentSummary_MedicaItem()
'End Report viewStudentSummary_Medica Data Provider Class GetResultSet Method

'Before build Select @167-7916B8AC
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID503",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @167-0FADDDB8
        Dim ds As DataSet = Nothing
        Dim result(-1) As viewStudentSummary_MedicaItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @167-0EEC5BF9
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New viewStudentSummary_MedicaItem(dr.Count-1) {}
'End After execute Select

'After execute Select @167-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @167-6AD6C036
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as viewStudentSummary_MedicaItem = New viewStudentSummary_MedicaItem()
                item.immun_certificate_desc.SetValue(dr(i)("immun_certificate_desc"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.allergies_flag_desc.SetValue(dr(i)("allergies_flag_desc"),"")
                item.anaphylaxis_flag_desc.SetValue(dr(i)("anaphylaxis_flag_desc"),"")
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.immun_diptheria_desc.SetValue(dr(i)("immun_diptheria_desc"),"")
                item.immun_tetanus_desc.SetValue(dr(i)("immun_tetanus_desc"),"")
                item.immun_polio_desc.SetValue(dr(i)("immun_polio_desc"),"")
                item.immun_measles_desc.SetValue(dr(i)("immun_measles_desc"),"")
                item.immun_mumps_desc.SetValue(dr(i)("immun_mumps_desc"),"")
                item.DIAGNOSED_CONDITION.SetValue(dr(i)("DIAGNOSED_CONDITION"),"")
                item.HASOTHERCONDITIONS_desc.SetValue(dr(i)("HASOTHERCONDITIONS_desc"),"")
                item.OTHERCONDITIONS.SetValue(dr(i)("OTHERCONDITIONS"),"")
                item.all_medical_conditions_desc.SetValue(dr(i)("all_medical_conditions_desc"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @167-A61BA892
End Class
'End Report Data Provider tail

'Report ADDRESS_Original Item Class @248-2D30C4E8
Public Class ADDRESS_OriginalItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ADDRESSEE As TextField
    Public AGENT As TextField
    Public ADDR1 As TextField
    Public ADDR2 As TextField
    Public SUBURB_TOWN As TextField
    Public STATE As TextField
    Public POSTCODE As TextField
    Public COUNTRY As TextField
    Public PHONE_A As TextField
    Public PHONE_B As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public EMAIL_ADDRESSHref As Object
    Public EMAIL_ADDRESSHrefParameters As LinkParameterCollection
    Public EMAIL_ADDRESS2 As TextField
    Public EMAIL_ADDRESS2Href As Object
    Public EMAIL_ADDRESS2HrefParameters As LinkParameterCollection
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public ADDRESS_ID As FloatField
    Public Sub New()
    ADDRESSEE = New TextField("", Nothing)
    AGENT = New TextField("", Nothing)
    ADDR1 = New TextField("", Nothing)
    ADDR2 = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    STATE = New TextField("", Nothing)
    POSTCODE = New TextField("", Nothing)
    COUNTRY = New TextField("", Nothing)
    PHONE_A = New TextField("", Nothing)
    PHONE_B = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("",Nothing)
    EMAIL_ADDRESSHrefParameters = New LinkParameterCollection()
    EMAIL_ADDRESS2 = New TextField("",Nothing)
    EMAIL_ADDRESS2HrefParameters = New LinkParameterCollection()
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy H\:mm", Nothing)
    ADDRESS_ID = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ADDRESSEE"
                    Return Me.ADDRESSEE
                Case "AGENT"
                    Return Me.AGENT
                Case "ADDR1"
                    Return Me.ADDR1
                Case "ADDR2"
                    Return Me.ADDR2
                Case "SUBURB_TOWN"
                    Return Me.SUBURB_TOWN
                Case "STATE"
                    Return Me.STATE
                Case "POSTCODE"
                    Return Me.POSTCODE
                Case "COUNTRY"
                    Return Me.COUNTRY
                Case "PHONE_A"
                    Return Me.PHONE_A
                Case "PHONE_B"
                    Return Me.PHONE_B
                Case "FAX"
                    Return Me.FAX
                Case "EMAIL_ADDRESS"
                    Return Me.EMAIL_ADDRESS
                Case "EMAIL_ADDRESS2"
                    Return Me.EMAIL_ADDRESS2
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "ADDRESS_ID"
                    Return Me.ADDRESS_ID
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ADDRESSEE"
                    Me.ADDRESSEE = CType(Value,TextField)
                Case "AGENT"
                    Me.AGENT = CType(Value,TextField)
                Case "ADDR1"
                    Me.ADDR1 = CType(Value,TextField)
                Case "ADDR2"
                    Me.ADDR2 = CType(Value,TextField)
                Case "SUBURB_TOWN"
                    Me.SUBURB_TOWN = CType(Value,TextField)
                Case "STATE"
                    Me.STATE = CType(Value,TextField)
                Case "POSTCODE"
                    Me.POSTCODE = CType(Value,TextField)
                Case "COUNTRY"
                    Me.COUNTRY = CType(Value,TextField)
                Case "PHONE_A"
                    Me.PHONE_A = CType(Value,TextField)
                Case "PHONE_B"
                    Me.PHONE_B = CType(Value,TextField)
                Case "FAX"
                    Me.FAX = CType(Value,TextField)
                Case "EMAIL_ADDRESS"
                    Me.EMAIL_ADDRESS = CType(Value,TextField)
                Case "EMAIL_ADDRESS2"
                    Me.EMAIL_ADDRESS2 = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "ADDRESS_ID"
                    Me.ADDRESS_ID = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Report ADDRESS_Original Item Class

'Report ADDRESS_Original Data Provider Class Header @248-E16F28EA
Public Class ADDRESS_OriginalDataProvider
Inherits GridDataProviderBase
'End Report ADDRESS_Original Data Provider Class Header

'Report ADDRESS_Original Data Provider Class Variables @248-00CF84BC

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public Expr273  As FloatParameter
'End Report ADDRESS_Original Data Provider Class Variables

'Report ADDRESS_Original Data Provider Class GetResultSet Method @248-AB1E8B16

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM ADDRESS {SQL_Where} {SQL_OrderBy}", New String(){"(","expr273",")"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Report ADDRESS_Original Data Provider Class GetResultSet Method

'Report ADDRESS_Original Data Provider Class GetResultSet Method @248-35EC27EB
    Public Function GetResultSet(ops As FormSupportedOperations) As ADDRESS_OriginalItem()
'End Report ADDRESS_Original Data Provider Class GetResultSet Method

'Before build Select @248-BFE689A0
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("expr273",Expr273, "","ADDRESS_ID",Condition.Equal,False)
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @248-D4C5C94B
        Dim ds As DataSet = Nothing
        Dim result(-1) As ADDRESS_OriginalItem
        If ops.AllowRead Then
            Try
                    ds=ExecuteSelect()
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @248-143184F3
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ADDRESS_OriginalItem(dr.Count-1) {}
'End After execute Select

'After execute Select @248-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @248-933779C0
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ADDRESS_OriginalItem = New ADDRESS_OriginalItem()
                item.ADDRESSEE.SetValue(dr(i)("ADDRESSEE"),"")
                item.AGENT.SetValue(dr(i)("AGENT"),"")
                item.ADDR1.SetValue(dr(i)("ADDR1"),"")
                item.ADDR2.SetValue(dr(i)("ADDR2"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.STATE.SetValue(dr(i)("STATE"),"")
                item.POSTCODE.SetValue(dr(i)("POSTCODE"),"")
                item.COUNTRY.SetValue(dr(i)("COUNTRY"),"")
                item.PHONE_A.SetValue(dr(i)("PHONE_A"),"")
                item.PHONE_B.SetValue(dr(i)("PHONE_B"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.EMAIL_ADDRESSHref = dr(i)("EMAIL_ADDRESS")
                item.EMAIL_ADDRESS2.SetValue(dr(i)("EMAIL_ADDRESS2"),"")
                item.EMAIL_ADDRESS2Href = dr(i)("EMAIL_ADDRESS2")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.ADDRESS_ID.SetValue(dr(i)("ADDRESS_ID"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Return result 
    End Function
'End After execute Select tail

'Report Data Provider tail @248-A61BA892
End Class
'End Report Data Provider tail

'Grid view_StudentSummary_Alert Item Class @314-390E2B65
Public Class view_StudentSummary_AlertItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT_TYPE As TextField
    Public Comment As TextField
    Public lblDate_Updated As DateField
    Public Sub New()
    COMMENT_TYPE = New TextField("", Nothing)
    Comment = New TextField("", Nothing)
    lblDate_Updated = New DateField("dd MMM yy", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "Comment"
                    Return Me.Comment
                Case "lblDate_Updated"
                    Return Me.lblDate_Updated
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "Comment"
                    Me.Comment = CType(Value,TextField)
                Case "lblDate_Updated"
                    Me.lblDate_Updated = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid view_StudentSummary_Alert Item Class

'Grid view_StudentSummary_Alert Data Provider Class Header @314-BDD19FF3
Public Class view_StudentSummary_AlertDataProvider
Inherits GridDataProviderBase
'End Grid view_StudentSummary_Alert Data Provider Class Header

'Grid view_StudentSummary_Alert Data Provider Class Variables @314-354EADC1

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 12
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As FloatParameter
'End Grid view_StudentSummary_Alert Data Provider Class Variables

'Grid view_StudentSummary_Alert Data Provider Class GetResultSet Method @314-AE96962D

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} COMMENT_TYPE, Comment, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM view_StudentSummary_Alerts {SQL_Where} {SQL_OrderBy}", New String(){"STUDENT_ID318"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM view_StudentSummary_Alerts", New String(){"STUDENT_ID318"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid view_StudentSummary_Alert Data Provider Class GetResultSet Method

'Grid view_StudentSummary_Alert Data Provider Class GetResultSet Method @314-238FC575
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As view_StudentSummary_AlertItem()
'End Grid view_StudentSummary_Alert Data Provider Class GetResultSet Method

'Before build Select @314-61895550
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("STUDENT_ID318",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @314-428771F8
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As view_StudentSummary_AlertItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @314-D2E5B8C8
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New view_StudentSummary_AlertItem(dr.Count-1) {}
'End After execute Select

'After execute Select @314-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @314-3A8F5994
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as view_StudentSummary_AlertItem = New view_StudentSummary_AlertItem()
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.Comment.SetValue(dr(i)("Comment"),"")
                item.lblDate_Updated.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @314-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_CARER_CONTACT Item Class @342-3B9231D5
Public Class STUDENT_CARER_CONTACTItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT Item Class

'Grid STUDENT_CARER_CONTACT Data Provider Class Header @342-63448F4C
Public Class STUDENT_CARER_CONTACTDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT Data Provider Class Header

'Grid STUDENT_CARER_CONTACT Data Provider Class Variables @342-C435E36D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
'End Grid STUDENT_CARER_CONTACT Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method @342-2B865740

    Public Sub New()
        Select_=new SqlCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_A from STUDENT WHERE STUDENT_ID = {STUDENT_ID}))",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_A from STUDENT WHERE STUDENT_ID = {STUDENT_ID})))" & _
          " cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method @342-7A95E8D5
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACTItem()
'End Grid STUDENT_CARER_CONTACT Data Provider Class GetResultSet Method

'Before build Select @342-29E282D2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @342-51870128
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACTItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @342-5A1D65E1
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACTItem(dr.Count-1) {}
'End After execute Select

'After execute Select @342-79D6687E
            Dim j As Integer
'End After execute Select

'ListBox RELATIONSHIP AfterExecuteSelect @345-FE0A4158
            Dim RELATIONSHIPItems As ItemCollection = New ItemCollection()
            
RELATIONSHIPItems.Add("PA","Parent")
RELATIONSHIPItems.Add("SP","Step-Parent")
RELATIONSHIPItems.Add("AP","Adoptive Parent")
RELATIONSHIPItems.Add("FP","Foster Parent")
RELATIONSHIPItems.Add("GP","Grand Parent")
RELATIONSHIPItems.Add("HF","Host Family")
RELATIONSHIPItems.Add("RE","Relative")
RELATIONSHIPItems.Add("FR","Friend")
RELATIONSHIPItems.Add("SE","Self")
RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'After execute Select tail @342-381A7299
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.RELATIONSHIPItems = CType(RELATIONSHIPItems.Clone(), ItemCollection)
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @342-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_CARER_CONTACT1 Item Class @362-FB703E70
Public Class STUDENT_CARER_CONTACT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public HOME_PHONE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public RELATIONSHIP As TextField
    Public RELATIONSHIPItems As ItemCollection
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    HOME_PHONE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    RELATIONSHIP = New TextField("", Nothing)
    RELATIONSHIPItems = New ItemCollection()
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "HOME_PHONE"
                    Return Me.HOME_PHONE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "RELATIONSHIP"
                    Return Me.RELATIONSHIP
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "HOME_PHONE"
                    Me.HOME_PHONE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "RELATIONSHIP"
                    Me.RELATIONSHIP = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT1 Item Class

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Header @362-6E6284C0
Public Class STUDENT_CARER_CONTACT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables @362-C435E36D

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @362-C37BBEA9

    Public Sub New()
        Select_=new SqlCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_B from STUDENT WHERE STUDENT_ID = {STUDENT_ID} ))",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * " & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP <> 'SS' ) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_PARENT_B from STUDENT WHERE STUDENT_ID = {STUDENT_ID} ))" & _
          ") cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method @362-F66EA6DA
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT1Item()
'End Grid STUDENT_CARER_CONTACT1 Data Provider Class GetResultSet Method

'Before build Select @362-29E282D2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @362-D71C6FAD
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT1Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @362-B169A5C1
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @362-79D6687E
            Dim j As Integer
'End After execute Select

'ListBox RELATIONSHIP AfterExecuteSelect @236-FE0A4158
            Dim RELATIONSHIPItems As ItemCollection = New ItemCollection()
            
RELATIONSHIPItems.Add("PA","Parent")
RELATIONSHIPItems.Add("SP","Step-Parent")
RELATIONSHIPItems.Add("AP","Adoptive Parent")
RELATIONSHIPItems.Add("FP","Foster Parent")
RELATIONSHIPItems.Add("GP","Grand Parent")
RELATIONSHIPItems.Add("HF","Host Family")
RELATIONSHIPItems.Add("RE","Relative")
RELATIONSHIPItems.Add("FR","Friend")
RELATIONSHIPItems.Add("SE","Self")
RELATIONSHIPItems.Add("OT","Other")
'End ListBox RELATIONSHIP AfterExecuteSelect

'After execute Select tail @362-FCEF2FBE
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.HOME_PHONE.SetValue(dr(i)("HOME_PHONE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RELATIONSHIP.SetValue(dr(i)("RELATIONSHIP"),"")
                item.RELATIONSHIPItems = CType(RELATIONSHIPItems.Clone(), ItemCollection)
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @362-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_CARER_CONTACT2 Item Class @381-504A38F9
Public Class STUDENT_CARER_CONTACT2Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public CARER_ID As FloatField
    Public TITLE As TextField
    Public WORK_PHONE As TextField
    Public MOBILE As TextField
    Public EMAIL As TextField
    Public EMAILHref As Object
    Public EMAILHrefParameters As LinkParameterCollection
    Public SURNAME As TextField
    Public FIRST_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public SUPERVISOR_POSITION As TextField
    Public SUPERVISOR_POSITION_OTHER As TextField
    Public PORTAL_LAST_LOGIN_DATE As DateField
    Public Supervisortype As TextField
    Public Sub New()
    CARER_ID = New FloatField("", Nothing)
    TITLE = New TextField("", Nothing)
    WORK_PHONE = New TextField("", Nothing)
    MOBILE = New TextField("", Nothing)
    EMAIL = New TextField("",Nothing)
    EMAILHrefParameters = New LinkParameterCollection()
    SURNAME = New TextField("", Nothing)
    FIRST_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    SUPERVISOR_POSITION = New TextField("", Nothing)
    SUPERVISOR_POSITION_OTHER = New TextField("", Nothing)
    PORTAL_LAST_LOGIN_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Supervisortype = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "CARER_ID"
                    Return Me.CARER_ID
                Case "TITLE"
                    Return Me.TITLE
                Case "WORK_PHONE"
                    Return Me.WORK_PHONE
                Case "MOBILE"
                    Return Me.MOBILE
                Case "EMAIL"
                    Return Me.EMAIL
                Case "SURNAME"
                    Return Me.SURNAME
                Case "FIRST_NAME"
                    Return Me.FIRST_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "SUPERVISOR_POSITION"
                    Return Me.SUPERVISOR_POSITION
                Case "SUPERVISOR_POSITION_OTHER"
                    Return Me.SUPERVISOR_POSITION_OTHER
                Case "PORTAL_LAST_LOGIN_DATE"
                    Return Me.PORTAL_LAST_LOGIN_DATE
                Case "Supervisortype"
                    Return Me.Supervisortype
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "CARER_ID"
                    Me.CARER_ID = CType(Value,FloatField)
                Case "TITLE"
                    Me.TITLE = CType(Value,TextField)
                Case "WORK_PHONE"
                    Me.WORK_PHONE = CType(Value,TextField)
                Case "MOBILE"
                    Me.MOBILE = CType(Value,TextField)
                Case "EMAIL"
                    Me.EMAIL = CType(Value,TextField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,TextField)
                Case "FIRST_NAME"
                    Me.FIRST_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "SUPERVISOR_POSITION"
                    Me.SUPERVISOR_POSITION = CType(Value,TextField)
                Case "SUPERVISOR_POSITION_OTHER"
                    Me.SUPERVISOR_POSITION_OTHER = CType(Value,TextField)
                Case "PORTAL_LAST_LOGIN_DATE"
                    Me.PORTAL_LAST_LOGIN_DATE = CType(Value,DateField)
                Case "Supervisortype"
                    Me.Supervisortype = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_CARER_CONTACT2 Item Class

'Grid STUDENT_CARER_CONTACT2 Data Provider Class Header @381-8D2B3362
Public Class STUDENT_CARER_CONTACT2DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class Header

'Grid STUDENT_CARER_CONTACT2 Data Provider Class Variables @381-053163ED

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As TextParameter
    Public UrlENROLMENT_YEAR  As TextParameter
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class Variables

'Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method @381-3E3CBF39

    Public Sub New()
        Select_=new SqlCommand("SELECT * , dbo.CarerTypeLabel(Relationship) as Supervisortype" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP in ('SS','XS','XA','XB' )) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_SCHOOL_SUPERVISOR from STUDENT_ENROLMENT WHERE STUDENT_I" & _
          "D = {STUDENT_ID} AND ENROLMENT_YEAR = {ENROLMENT_YEAR}))",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT * , dbo.CarerTypeLabel(Relationship) as Supervisortype" & vbCrLf & _
          "FROM STUDENT_CARER_CONTACT" & vbCrLf & _
          "WHERE ( RELATIONSHIP in ('SS','XS','XA','XB' )) " & vbCrLf & _
          "AND ( CARER_ID = (SELECT CARER_ID_SCHOOL_SUPERVISOR from STUDENT_ENROLMENT WHERE STUDENT_I" & _
          "D = {STUDENT_ID} AND ENROLMENT_YEAR = {ENROLMENT_YEAR}))) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method

'Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method @381-C786BC47
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_CARER_CONTACT2Item()
'End Grid STUDENT_CARER_CONTACT2 Data Provider Class GetResultSet Method

'Before build Select @381-A84CD653
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",UrlENROLMENT_YEAR, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @381-B95B0F30
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_CARER_CONTACT2Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @381-123F2368
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_CARER_CONTACT2Item(dr.Count-1) {}
'End After execute Select

'After execute Select @381-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @381-E2D34737
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_CARER_CONTACT2Item = New STUDENT_CARER_CONTACT2Item()
                item.CARER_ID.SetValue(dr(i)("CARER_ID"),"")
                item.TITLE.SetValue(dr(i)("TITLE"),"")
                item.WORK_PHONE.SetValue(dr(i)("WORK_PHONE"),"")
                item.MOBILE.SetValue(dr(i)("MOBILE"),"")
                item.EMAIL.SetValue(dr(i)("EMAIL"),"")
                item.EMAILHref = dr(i)("EMAIL")
                item.SURNAME.SetValue(dr(i)("SURNAME"),"")
                item.FIRST_NAME.SetValue(dr(i)("FIRST_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.SUPERVISOR_POSITION.SetValue(dr(i)("SUPERVISOR_POSITION"),"")
                item.SUPERVISOR_POSITION_OTHER.SetValue(dr(i)("SUPERVISOR_POSITION_OTHER"),"")
                item.PORTAL_LAST_LOGIN_DATE.SetValue(dr(i)("PORTAL_LAST_LOGIN_DATE"),Select_.DateFormat)
                item.Supervisortype.SetValue(dr(i)("Supervisortype"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @381-A61BA892
End Class
'End Grid Data Provider tail

'Grid Grid_FamilyGroup Item Class @459-FA51D384
Public Class Grid_FamilyGroupItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public STUDENT_ID As FloatField
    Public STUDENT_IDHref As Object
    Public STUDENT_IDHrefParameters As LinkParameterCollection
    Public first_name As TextField
    Public surname As TextField
    Public last_enrol_year As FloatField
    Public Sub New()
    STUDENT_ID = New FloatField("",Nothing)
    STUDENT_IDHrefParameters = New LinkParameterCollection()
    first_name = New TextField("", Nothing)
    surname = New TextField("", Nothing)
    last_enrol_year = New FloatField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return Me.STUDENT_ID
                Case "first_name"
                    Return Me.first_name
                Case "surname"
                    Return Me.surname
                Case "last_enrol_year"
                    Return Me.last_enrol_year
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    Me.STUDENT_ID = CType(Value,FloatField)
                Case "first_name"
                    Me.first_name = CType(Value,TextField)
                Case "surname"
                    Me.surname = CType(Value,TextField)
                Case "last_enrol_year"
                    Me.last_enrol_year = CType(Value,FloatField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_FamilyGroup Item Class

'Grid Grid_FamilyGroup Data Provider Class Header @459-7B26D613
Public Class Grid_FamilyGroupDataProvider
Inherits GridDataProviderBase
'End Grid Grid_FamilyGroup Data Provider Class Header

'Grid Grid_FamilyGroup Data Provider Class Variables @459-B9638A4A

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"surname, first_name"}
    Private SortFieldsNamesDesc As String() = New string() {"surname, first_name"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public UrlSTUDENT_ID  As IntegerParameter
'End Grid Grid_FamilyGroup Data Provider Class Variables

'Grid Grid_FamilyGroup Data Provider Class GetResultSet Method @459-8F6D14AC

    Public Sub New()
        Select_=new SqlCommand("select distinct TOP {SqlParam_endRecord} student_id, first_name, surname, last_enrol_year" & vbCrLf & _
          "from view_FamilyGrouping" & vbCrLf & _
          "where  Student_id <> {STUDENT_ID}" & vbCrLf & _
          "	and CARER_ID_PARENT_AB in (select CARER_ID_PARENT_AB from view_FamilyGrouping where Stude" & _
          "nt_id = {STUDENT_ID}) {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select distinct student_id, first_name, surname, last_enrol_year" & vbCrLf & _
          "from view_FamilyGrouping" & vbCrLf & _
          "where  Student_id <> {STUDENT_ID}" & vbCrLf & _
          "	and CARER_ID_PARENT_AB in (select CARER_ID_PARENT_AB from view_FamilyGrouping where Stude" & _
          "nt_id = {STUDENT_ID})) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_FamilyGroup Data Provider Class GetResultSet Method

'Grid Grid_FamilyGroup Data Provider Class GetResultSet Method @459-C24496AF
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_FamilyGroupItem()
'End Grid Grid_FamilyGroup Data Provider Class GetResultSet Method

'Before build Select @459-29E282D2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",UrlSTUDENT_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @459-228044E3
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_FamilyGroupItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @459-F46B69EB
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_FamilyGroupItem(dr.Count-1) {}
'End After execute Select

'After execute Select @459-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @459-271BC38D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_FamilyGroupItem = New Grid_FamilyGroupItem()
                item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
                item.STUDENT_IDHref = "StudentSummary.aspx"
                item.STUDENT_IDHrefParameters.Add("STUDENT_ID",System.Web.HttpUtility.UrlEncode(dr(i)("STUDENT_ID").ToString()))
                item.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode(dr(i)("last_enrol_year").ToString()))
                item.first_name.SetValue(dr(i)("first_name"),"")
                item.surname.SetValue(dr(i)("surname"),"")
                item.last_enrol_year.SetValue(dr(i)("last_enrol_year"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @459-A61BA892
End Class
'End Grid Data Provider tail

'Grid STUDENT_COMMENT1 Item Class @1334-7AED1BC7
Public Class STUDENT_COMMENT1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COMMENT As TextField
    Public COMMENT_TYPE As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    COMMENT = New TextField("", Nothing)
    COMMENT_TYPE = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COMMENT"
                    Return Me.COMMENT
                Case "COMMENT_TYPE"
                    Return Me.COMMENT_TYPE
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "COMMENT"
                    Me.COMMENT = CType(Value,TextField)
                Case "COMMENT_TYPE"
                    Me.COMMENT_TYPE = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_COMMENT1 Item Class

'Grid STUDENT_COMMENT1 Data Provider Class Header @1334-94173669
Public Class STUDENT_COMMENT1DataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_COMMENT1 Data Provider Class Header

'Grid STUDENT_COMMENT1 Data Provider Class Variables @1334-66AB4643

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"LAST_ALTERED_DATE desc"}
    Private SortFieldsNamesDesc As String() = New string() {"LAST_ALTERED_DATE desc"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public UrlStudent_ID  As IntegerParameter
'End Grid STUDENT_COMMENT1 Data Provider Class Variables

'Grid STUDENT_COMMENT1 Data Provider Class GetResultSet Method @1334-EF9D1792

    Public Sub New()
        Select_=new SqlCommand("SELECT TOP {SqlParam_endRecord} COMMENT, LAST_ALTERED_BY, LAST_ALTERED_DATE, COMMENT_TYPE " & vbCrLf & _
          "FROM STUDENT_COMMENT" & vbCrLf & _
          "WHERE Student_ID = {Student_ID}" & vbCrLf & _
          "AND COMMENT_TYPE in ('MODIFIED_SUBJECT', 'CUSTOM_LEARNING', 'REASONABLE_ADJUSTMEN') {SQL_O" & _
          "rderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (SELECT COMMENT, LAST_ALTERED_BY, LAST_ALTERED_DATE, COMMENT_TYPE " & vbCrLf & _
          "FROM STUDENT_COMMENT" & vbCrLf & _
          "WHERE Student_ID = {Student_ID}" & vbCrLf & _
          "AND COMMENT_TYPE in ('MODIFIED_SUBJECT', 'CUSTOM_LEARNING', 'REASONABLE_ADJUSTMEN')) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid STUDENT_COMMENT1 Data Provider Class GetResultSet Method

'Grid STUDENT_COMMENT1 Data Provider Class GetResultSet Method @1334-405B42BE
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_COMMENT1Item()
'End Grid STUDENT_COMMENT1 Data Provider Class GetResultSet Method

'Before build Select @1334-DB6EBA68
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("Student_ID",UrlStudent_ID, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @1334-E5A1C3A4
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_COMMENT1Item
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @1334-4256A1ED
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_COMMENT1Item(dr.Count-1) {}
'End After execute Select

'After execute Select @1334-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @1334-3F671D42
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_COMMENT1Item = New STUDENT_COMMENT1Item()
                item.COMMENT.SetValue(dr(i)("COMMENT"),"")
                item.COMMENT_TYPE.SetValue(dr(i)("COMMENT_TYPE"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @1334-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

