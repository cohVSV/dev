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
'Imports System.Datetime	'Aug-2018|EA| for date parsing

Namespace DECV_PROD2007.StudentSummary 'Namespace @1-3B0EC2E2

'Forms Definition @1-6D586B84
Public Class [StudentSummaryPage]
Inherits CCPage
'End Forms Definition

'ERA:
	'7-Feb-2010|EricA|created for Student Files setup - 
	public strLocURL as String			'for URL link in common URL format
	public strLocURL2 as String			'15-Aug-2013|EA|for URL link in common URL format - Student Reports
	public strLocCreate as String		' local address on DECV-DB1 server for Create

    ' 16 Sep 2021|RW| Added variables for student's name, using their preferred name if provided
    Private HasPreferredName As Boolean
    Private PreferredFirstName As String
    Private PreferredFullName As String

'Forms Objects @1-10067D31
    Protected viewStudentSummary_DetailData As viewStudentSummary_DetailDataProvider
    Protected viewStudentSummary_DetailErrors As NameValueCollection = New NameValueCollection()
    Protected viewStudentSummary_DetailOperations As FormSupportedOperations
    Protected viewStudentSummary_DetailIsSubmitted As Boolean = False
    Protected viewStudentSummary_SubjectListData As viewStudentSummary_SubjectListDataProvider
    Protected viewStudentSummary_SubjectListOperations As FormSupportedOperations
    Protected viewStudentSummary_SubjectListCurrentRowNumber As Integer
    Protected STUDENT_COMMENTData As STUDENT_COMMENTDataProvider
    Protected STUDENT_COMMENTOperations As FormSupportedOperations
    Protected STUDENT_COMMENTCurrentRowNumber As Integer
    Protected viewStudentSummary_EnrolmData As viewStudentSummary_EnrolmDataProvider
    Protected viewStudentSummary_EnrolmOperations As FormSupportedOperations
    Protected ADDRESS_PostalData As ADDRESS_PostalDataProvider
    Protected ADDRESS_PostalOperations As FormSupportedOperations
    Protected ADDRESS_CurrentData As ADDRESS_CurrentDataProvider
    Protected ADDRESS_CurrentOperations As FormSupportedOperations
    Protected STUDENT_CENSUS_DATAData As STUDENT_CENSUS_DATADataProvider
    Protected STUDENT_CENSUS_DATAOperations As FormSupportedOperations
    Protected STUDENT_EQUIPMENTData As STUDENT_EQUIPMENTDataProvider
    Protected STUDENT_EQUIPMENTOperations As FormSupportedOperations
    Protected viewStudentSummary_MedicaData As viewStudentSummary_MedicaDataProvider
    Protected viewStudentSummary_MedicaOperations As FormSupportedOperations
    Protected ADDRESS_OriginalData As ADDRESS_OriginalDataProvider
    Protected ADDRESS_OriginalOperations As FormSupportedOperations
    Protected view_StudentSummary_AlertData As view_StudentSummary_AlertDataProvider
    Protected view_StudentSummary_AlertOperations As FormSupportedOperations
    Protected view_StudentSummary_AlertCurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACTData As STUDENT_CARER_CONTACTDataProvider
    Protected STUDENT_CARER_CONTACTOperations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACTCurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT1Data As STUDENT_CARER_CONTACT1DataProvider
    Protected STUDENT_CARER_CONTACT1Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT1CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT2Data As STUDENT_CARER_CONTACT2DataProvider
    Protected STUDENT_CARER_CONTACT2Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT2CurrentRowNumber As Integer
    Protected Grid_FamilyGroupData As Grid_FamilyGroupDataProvider
    Protected Grid_FamilyGroupOperations As FormSupportedOperations
    Protected Grid_FamilyGroupCurrentRowNumber As Integer
    Protected STUDENT_COMMENT1Data As STUDENT_COMMENT1DataProvider
    Protected STUDENT_COMMENT1Operations As FormSupportedOperations
    Protected STUDENT_COMMENT1CurrentRowNumber As Integer
    Protected StudentSummaryContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page StudentSummary Event OnInitializeView. Action Custom Code @312-73254650
    ' -------------------------
    '11-Feb-2010|EricA|created for Student Files setup - 
    '''strLocURL = "file:////decv-db/Student_Admin_Student_data$/" 'for URL link in common URL format
    '''strLocCreate = "e:\Student_Admin_Student_data\"             ' local address on DECV-DB1 server for Create
	'15-Aug-2013|EA| added location for Student Reports (unfuddle #569)
	'''strLocURL2 = "http://Stud_Admin_Reports/"	'for URL link in common URL format (studentid and 'default.asp' will be added in code
	'4-Dec-2014|EA| convert the locations to web.config values as several pages (Summary and StudentDetails_maintain) and have been getting out of sync (unfuddle #683)
	strLocURL = System.Configuration.ConfigurationManager.AppSettings("StudentFolderLocalURL") 'for URL link in common URL format
    strLocCreate = System.Configuration.ConfigurationManager.AppSettings("StudentFolderLocalCreatePath")             ' local address on DECV-DB server for Create
	strLocURL2 = System.Configuration.ConfigurationManager.AppSettings("StudentFolderLocalReportsURL")	'for URL link in common URL format (studentid and 'default.asp' will be added in code)	
    ' -------------------------
'End Page StudentSummary Event OnInitializeView. Action Custom Code

'Page_Load Event BeforeIsPostBack @1-983E74B5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.link_MenuHref = "Menu.aspx"
            item.Link_SearchRequestHref = "MaintainSearchRequest.aspx"
            item.link_AssignmentsHref = "AssignmentSubmissionList.aspx"
            item.Link1Href = "StudentDetails_maintain.aspx"
            item.Link3Href = "Student_Subject_maintain.aspx"
            item.Link2Href = "StudentEnrolmentDetails_maintain.aspx"
            item.Link4Href = "FinancialAccounts_maintain.aspx"
            item.Link5Href = "Student_Comments_maintain.aspx"
            item.Link10Href = "Send_SMS_maintain.aspx"
            item.Link6Href = "Student_Future_Intentions.aspx"
            item.lblModified.SetValue(System.IO.File.GetLastWriteTime(Request.PhysicalPath).ToString("dd MMM yy HH:mm"))
            item.Link8Href = "Student_Profile.aspx"
            item.Link7Href = "Student_EACL.aspx"
            item.Link9Href = "Referrals.aspx"
            PageData.FillItem(item)
            link_Menu.InnerText += item.link_Menu.GetFormattedValue().Replace(vbCrLf,"")
            link_Menu.HRef = item.link_MenuHref+item.link_MenuHrefParameters.ToString("None","", ViewState)
            link_Menu.DataBind()
            Link_SearchRequest.InnerText += item.Link_SearchRequest.GetFormattedValue().Replace(vbCrLf,"")
            Link_SearchRequest.HRef = item.Link_SearchRequestHref+item.Link_SearchRequestHrefParameters.ToString("GET","", ViewState)
            Link_SearchRequest.DataBind()
            link_Assignments.InnerText += item.link_Assignments.GetFormattedValue().Replace(vbCrLf,"")
            link_Assignments.HRef = item.link_AssignmentsHref+item.link_AssignmentsHrefParameters.ToString("GET","", ViewState)
            link_Assignments.DataBind()
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            Link3.InnerText += item.Link3.GetFormattedValue().Replace(vbCrLf,"")
            Link3.HRef = item.Link3Href+item.Link3HrefParameters.ToString("GET","", ViewState)
            Link3.DataBind()
            Link2.InnerText += item.Link2.GetFormattedValue().Replace(vbCrLf,"")
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("GET","", ViewState)
            Link2.DataBind()
            Link4.InnerText += item.Link4.GetFormattedValue().Replace(vbCrLf,"")
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("GET","", ViewState)
            Link4.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf,"")
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("GET","", ViewState)
            Link5.DataBind()
            Link10.InnerText += item.Link10.GetFormattedValue().Replace(vbCrLf,"")
            Link10.HRef = item.Link10Href+item.Link10HrefParameters.ToString("GET","", ViewState)
            Link10.DataBind()
            Link6.InnerText += item.Link6.GetFormattedValue().Replace(vbCrLf,"")
            Link6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("GET","", ViewState)
            Link6.DataBind()
            lblModified.Text = Server.HtmlEncode(item.lblModified.GetFormattedValue()).Replace(vbCrLf,"<br>")
            Link8.InnerText += item.Link8.GetFormattedValue().Replace(vbCrLf,"")
            Link8.HRef = item.Link8Href+item.Link8HrefParameters.ToString("GET","", ViewState)
            Link8.DataBind()
            Link7.InnerText += item.Link7.GetFormattedValue().Replace(vbCrLf,"")
            Link7.HRef = item.Link7Href+item.Link7HrefParameters.ToString("GET","", ViewState)
            Link7.DataBind()
            Link9.InnerText += item.Link9.GetFormattedValue().Replace(vbCrLf,"")
            Link9.HRef = item.Link9Href+item.Link9HrefParameters.ToString("GET","", ViewState)
            Link9.DataBind()
            viewStudentSummary_DetailShow()
            viewStudentSummary_SubjectListBind
            STUDENT_COMMENTBind
            viewStudentSummary_EnrolmBind
            ADDRESS_PostalBind
            ADDRESS_CurrentBind
            STUDENT_CENSUS_DATABind
            STUDENT_EQUIPMENTBind
            viewStudentSummary_MedicaBind
            ADDRESS_OriginalBind
            view_StudentSummary_AlertBind
            STUDENT_CARER_CONTACTBind
            STUDENT_CARER_CONTACT1Bind
            STUDENT_CARER_CONTACT2Bind
            Grid_FamilyGroupBind
            STUDENT_COMMENT1Bind
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel_MaintainMenu Event BeforeShow. Action Custom Code @211-73254650
    ' -------------------------
    'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")
	 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MaintainMenu.visible = true
     End If
    ' -------------------------
'End Panel Panel_MaintainMenu Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form viewStudentSummary_Detail Parameters @4-978B600D

    Protected Sub viewStudentSummary_DetailParameters()
        Dim item As new viewStudentSummary_DetailItem
        Try
            viewStudentSummary_DetailData.Urlstudent_id = FloatParameter.GetParam("student_id", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_DetailData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)
        Catch e As Exception
            viewStudentSummary_DetailErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewStudentSummary_Detail Parameters

'Record Form viewStudentSummary_Detail Show method @4-7C7D230C
    Protected Sub viewStudentSummary_DetailShow()
        If viewStudentSummary_DetailOperations.None Then
            viewStudentSummary_DetailHolder.Visible = False
            Return
        End If
        Dim item As viewStudentSummary_DetailItem = viewStudentSummary_DetailItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewStudentSummary_DetailOperations.AllowRead
        item.link_create_teacheremailsHref = ""
        item.link_create_parentemailsHref = ""
        item.Link1Href = "http://intranet/Reports/Pages/Folder.aspx?ItemPath=%2fNightly+Reports"
        item.link_showstudentreportsHref = ""
        item.link_showstudentfolderHref = ""
        item.FunnelLinkHref = "https://vsv-au-vic-691.app.digistorm.com/admin/crm/leads"
        item.FilesLinkHref = "http://vsv-app02:65003/"
        item.ReferralsLinkHref = "Referrals.aspx"
        viewStudentSummary_DetailErrors.Add(item.errors)
        If viewStudentSummary_DetailErrors.Count > 0 Then
            viewStudentSummary_DetailShowErrors()
            Return
        End If
'End Record Form viewStudentSummary_Detail Show method

'Record Form viewStudentSummary_Detail BeforeShow tail @4-B426FE77
        viewStudentSummary_DetailParameters()
        viewStudentSummary_DetailData.FillItem(item, IsInsertMode)
        viewStudentSummary_DetailHolder.DataBind()
        viewStudentSummary_DetailStudent_id.Text = Server.HtmlEncode(item.Student_id.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailenrolment_date.Text = Server.HtmlEncode(item.enrolment_date.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailwithdrawal_date.Text = Server.HtmlEncode(item.withdrawal_date.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailENROLMENT_STATUS.Text = Server.HtmlEncode(item.ENROLMENT_STATUS.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailWithdrawalReason.Text = Server.HtmlEncode(item.WithdrawalReason.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailWITHDRAWAL_REASON_ID.Text = Server.HtmlEncode(item.WITHDRAWAL_REASON_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailsurname.Text = Server.HtmlEncode(item.surname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailfirst_name.Text = Server.HtmlEncode(item.first_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailmiddle_name.Text = Server.HtmlEncode(item.middle_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailSEX.Text = Server.HtmlEncode(item.SEX.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailYEAR_LEVEL.Text = Server.HtmlEncode(item.YEAR_LEVEL.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailEnrolmentYear.Text = Server.HtmlEncode(item.EnrolmentYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailreceipt_no.Text = Server.HtmlEncode(item.receipt_no.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailsubcategory_full_title.Text = Server.HtmlEncode(item.subcategory_full_title.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailattending_school_name.Text = Server.HtmlEncode(item.attending_school_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailATTENDING_SCHOOL_ID.Text = Server.HtmlEncode(item.ATTENDING_SCHOOL_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailhome_school_name.Text = Server.HtmlEncode(item.home_school_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailHOME_SCHOOL_ID.Text = Server.HtmlEncode(item.HOME_SCHOOL_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailPOSTAL_ADDRESS_ID.Text = Server.HtmlEncode(item.POSTAL_ADDRESS_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailCURR_RESID_ADDRESS_ID.Text = Server.HtmlEncode(item.CURR_RESID_ADDRESS_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailORIG_RESID_ADDRESS_ID.Text = Server.HtmlEncode(item.ORIG_RESID_ADDRESS_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblHomeSchooled.Text = item.lblHomeSchooled.GetFormattedValue()
        viewStudentSummary_DetailVSN.Text = Server.HtmlEncode(item.VSN.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailVSR_Enrolled.Text = Server.HtmlEncode(item.VSR_Enrolled.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailbirth_date.Text = Server.HtmlEncode(item.birth_date.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailpreferred_name.Text = Server.HtmlEncode(item.preferred_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblWd_Exit_Destination.Text = Server.HtmlEncode(item.lblWd_Exit_Destination.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailWD_EXIT_DESTINATION.Text = Server.HtmlEncode(item.WD_EXIT_DESTINATION.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailhidden_DATE_STUDENTFOLDER_CREATED.Value = item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()
        viewStudentSummary_Detaillabel_Age.Text = Server.HtmlEncode(item.label_Age.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detaillink_create_teacheremails.InnerText += item.link_create_teacheremails.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_Detaillink_create_teacheremails.HRef = item.link_create_teacheremailsHref+item.link_create_teacheremailsHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetailSTUDENT_EMAIL.InnerText += item.STUDENT_EMAIL.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailSTUDENT_EMAIL.HRef = item.STUDENT_EMAILHref+item.STUDENT_EMAILHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetailSTUDENT_MOBILE.Text = Server.HtmlEncode(item.STUDENT_MOBILE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblATARNotRequired.Text = item.lblATARNotRequired.GetFormattedValue()
        viewStudentSummary_DetailATAR_REQUIRED.Text = Server.HtmlEncode(item.ATAR_REQUIRED.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detaillink_create_parentemails.InnerText += item.link_create_parentemails.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_Detaillink_create_parentemails.HRef = item.link_create_parentemailsHref+item.link_create_parentemailsHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetailPORTAL_ACCESS.Text = Server.HtmlEncode(item.PORTAL_ACCESS.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblPortalAccessRestricted.Text = item.lblPortalAccessRestricted.GetFormattedValue()
        viewStudentSummary_DetaillblSharedEnrolment.Text = item.lblSharedEnrolment.GetFormattedValue()
        viewStudentSummary_Detailcake.Text = item.cake.GetFormattedValue()
        viewStudentSummary_DetailPASTORAL_CARE_ID.Text = Server.HtmlEncode(item.PASTORAL_CARE_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblAreaDisplay.Text = Server.HtmlEncode(item.lblAreaDisplay.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblRegionDisplay.Text = Server.HtmlEncode(item.lblRegionDisplay.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetaillblEnrolStatus.Text = Server.HtmlEncode(item.lblEnrolStatus.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detailorg_school_name.Text = Server.HtmlEncode(item.org_school_name.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailORGANISATION_SCHOOL_ID.Text = Server.HtmlEncode(item.ORGANISATION_SCHOOL_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetaillblPLP.Text = Server.HtmlEncode(item.lblPLP.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailLEARNING_PROGRAM_text.Text = Server.HtmlEncode(item.LEARNING_PROGRAM_text.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_Detaillink_showstudentreports.InnerText += item.link_showstudentreports.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_Detaillink_showstudentreports.HRef = Settings.ServerURL +item.link_showstudentreportsHref+item.link_showstudentreportsHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetaillabelContactWho1.Text = item.labelContactWho1.GetFormattedValue()
        viewStudentSummary_Detaillink_showstudentfolder.InnerText += item.link_showstudentfolder.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_Detaillink_showstudentfolder.HRef = Settings.ServerURL +item.link_showstudentfolderHref+item.link_showstudentfolderHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_DetaillabelContactWho.Text = item.labelContactWho.GetFormattedValue()
        viewStudentSummary_DetailSSG_FACILITATOR_ID.Text = Server.HtmlEncode(item.SSG_FACILITATOR_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailLinkLearningAdvisorEmail.InnerText += item.LinkLearningAdvisorEmail.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailLinkLearningAdvisorEmail.HRef = item.LinkLearningAdvisorEmailHref+item.LinkLearningAdvisorEmailHrefParameters.ToString("None","", ViewState)
        viewStudentSummary_Detailhidden_SEX_SELF_DESCRIBED.Value = item.hidden_SEX_SELF_DESCRIBED.GetFormattedValue()
        viewStudentSummary_DetailPronouns.Text = Server.HtmlEncode(item.Pronouns.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailFunnelLink.InnerText += item.FunnelLink.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailFunnelLink.HRef = item.FunnelLinkHref+item.FunnelLinkHrefParameters.ToString("GET","", ViewState)
        viewStudentSummary_DetailFilesLink.InnerText += item.FilesLink.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailFilesLink.HRef = item.FilesLinkHref+item.FilesLinkHrefParameters.ToString("GET","", ViewState)
        viewStudentSummary_DetailFunnelUUID.Text = Server.HtmlEncode(item.FunnelUUID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentSummary_DetailReferralsLink.InnerText += item.ReferralsLink.GetFormattedValue().Replace(vbCrLf,"")
        viewStudentSummary_DetailReferralsLink.HRef = item.ReferralsLinkHref+item.ReferralsLinkHrefParameters.ToString("GET","", ViewState)
'End Record Form viewStudentSummary_Detail BeforeShow tail

'Label ENROLMENT_STATUS Event BeforeShow. Action Custom Code @33-73254650
    ' -------------------------
 	' ERA: alter E / N to 'Enrolled'/'Not Enrolled'
 	'Aug-2018|EA| prepare for Future Enrolment (Before or Future)
	select case item.ENROLMENT_STATUS.getformattedvalue()
		case "E"
			viewStudentSummary_DetailENROLMENT_STATUS.Text = "Enrolled"
		case "N"
			viewStudentSummary_DetailENROLMENT_STATUS.Text = "Not enrolled"
		case "B"
			viewStudentSummary_DetailENROLMENT_STATUS.Text = "Future Enrolment"
		case "F"
			viewStudentSummary_DetailENROLMENT_STATUS.Text = "Future Enrolment"
		case else
			viewStudentSummary_DetailENROLMENT_STATUS.Text = "unknown"
	end select
    ' -------------------------
'End Label ENROLMENT_STATUS Event BeforeShow. Action Custom Code

'Label WithdrawalReason Event BeforeShow. Action Custom Code @32-73254650
    ' -------------------------
    ' ERA: retrieve Withdrawal Reason text from ID
	if (not (item.WITHDRAWAL_REASON_ID.value = nothing)) then
		viewStudentSummary_DetailWithdrawalReason.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT isnull(WITHDRAWAL_REASON,'') FROM WITHDRAWAL_REASON WHERE WITHDRAWAL_REASON_ID=" & item.WITHDRAWAL_REASON_ID.GetFormattedValue()))).GetFormattedValue("")
	end if
    ' -------------------------
'End Label WithdrawalReason Event BeforeShow. Action Custom Code

'Label first_name Event BeforeShow. Action Custom Code @1211-73254650
    ' 16 Sep 2021|RW| Set our page-wide variables for the name labels.
    ' It seems hacky to set it here in a BeforeShow event of an individual item, but I don't know of a better CodeCharge event to hook into
    If (item.preferred_name.GetFormattedValue().Trim().Length = 0)
        HasPreferredName = False
        PreferredFirstName = viewStudentSummary_Detailfirst_name.Text.Trim()
    Else
        HasPreferredName = True
        PreferredFirstName = viewStudentSummary_Detailpreferred_name.Text.Trim()
    End If
    PreferredFullName = PreferredFirstName & " " & viewStudentSummary_Detailsurname.Text.Trim()

    ' 16 Sep 2021|RW| Changed visual emphasis when a student has a preferred name; SD 34651
	If (Not HasPreferredName) Then
        viewStudentSummary_Detailfirst_name.Text = "<h2>" & viewStudentSummary_Detailfirst_name.Text.Trim() & "</h2>"
	End If
'End Label first_name Event BeforeShow. Action Custom Code

'Label SEX Event BeforeShow. Action Custom Code @28-73254650
    ' -------------------------
    ' ERA: alter M / F to 'Male'/'Female'
	select case item.sex.getformattedvalue()
		case "M"
			viewStudentSummary_DetailSEX.Text = "Male"
		case "F"
			viewStudentSummary_DetailSEX.Text = "Female"
		case else
            ' 16 Sep 2021|RW| Apply more emphasis to self-described gender students; SD 34651
			Dim selfDescribedGender = item.hidden_SEX_SELF_DESCRIBED.GetFormattedValue()
			viewStudentSummary_DetailSEX.Text = "<h2>" & If(selfDescribedGender.Length > 0, selfDescribedGender, "Not specified") & "</h2>"
	end select

    ' -------------------------
'End Label SEX Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL       ' ERA: alter 'D' to 'DECV' etc (although all should be DECV)
'DEL  	select case item.campus.getformattedvalue()
'DEL  		case "D"
'DEL  			viewStudentSummary_DetailCAMPUS.text = "DECV"
'DEL  		case "V"
'DEL  			viewStudentSummary_DetailCAMPUS.text = "VSL"
'DEL  		case "B"
'DEL  			viewStudentSummary_DetailCAMPUS.text = "DECV + VSL"
'DEL  		case else
'DEL  			viewStudentSummary_DetailCAMPUS.Text = "unknown"
'DEL  	end select
'DEL      ' -------------------------


'Label lblHomeSchooled Event BeforeShow. Action Hide-Show Component @284-AB50CC7B
        If (item.YEAR_LEVEL.GetFormattedValue() <> "30") Then
            viewStudentSummary_DetaillblHomeSchooled.Visible = False
        End If
'End Label lblHomeSchooled Event BeforeShow. Action Hide-Show Component

'Label VSN Event BeforeShow. Action Custom Code @287-73254650
    ' -------------------------
    ' '*Added By : Vikas Baweja
            'Date : 08/July/2009
            'Task : Implement VSN/VSR changes
            'code Starts here 
            If item.VSN.GetFormattedValue() = "" Then
                viewStudentSummary_DetailVSN.Text = "Unknown"
            Else
                viewStudentSummary_DetailVSN.Text = item.VSN.GetFormattedValue()
            End If
            'code ends here 
    ' -------------------------
'End Label VSN Event BeforeShow. Action Custom Code

'Label VSR_Enrolled Event BeforeShow. Action Custom Code @288-73254650
    ' -------------------------
    ' '*Added By : Vikas Baweja
            'Date : 08/July/2009
            'Task : Implement VSN/VSR changes
            'code Starts here 
            If item.VSR_Enrolled.GetFormattedValue() = "N" Then
                viewStudentSummary_DetailVSR_Enrolled.Text = "False"
            ElseIf item.VSR_Enrolled.GetFormattedValue() = "Y" Then
                viewStudentSummary_DetailVSR_Enrolled.Text = "True"
            End If
            'code ends here 
    ' -------------------------
'End Label VSR_Enrolled Event BeforeShow. Action Custom Code

'Label preferred_name Event BeforeShow. Action Custom Code @1212-73254650
    ' 16 Sep 2021|RW| Changed visual emphasis when a student has a preferred name; SD 34651
	If (HasPreferredName) Then
        viewStudentSummary_Detailpreferred_name.Text = "<h2>" & PreferredFirstName & "</h2>"
	End If
'End Label preferred_name Event BeforeShow. Action Custom Code

'Label lblWd_Exit_Destination Event BeforeShow. Action Custom Code @303-73254650
    ' -------------------------
    ' ERA: don't lookup if there is no WD Exit ID
	if (not (item.WD_EXIT_DESTINATION.value = nothing)) then
    ' -------------------------
'End Label lblWd_Exit_Destination Event BeforeShow. Action Custom Code



'Label lblWd_Exit_Destination Event BeforeShow. Action DLookup @299-AE34CACE
            viewStudentSummary_DetaillblWd_Exit_Destination.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "EXIT_DESTINATION_DESCRIPTION" & " FROM " & "WITHDRAWAL_EXIT_DESTINATION" & " WHERE " & "WD_DEST_ID = " & item.WD_EXIT_DESTINATION.GetFormattedValue()))).GetFormattedValue("")
'End Label lblWd_Exit_Destination Event BeforeShow. Action DLookup

'Label lblWd_Exit_Destination Event BeforeShow. Action Custom Code @304-73254650
    ' -------------------------
	' ERA: don't lookup if there is no WD Exit ID
	end if
    ' -------------------------
'End Label lblWd_Exit_Destination Event BeforeShow. Action Custom Code

'Link link_create_teacheremails Event BeforeShow. Action Declare Variable @408-C7C6ECB2
            Dim strTeacherEmailList As String = ""
'End Link link_create_teacheremails Event BeforeShow. Action Declare Variable

'Link link_create_teacheremails Event BeforeShow. Action Custom Code @409-73254650
    ' -------------------------
    ' ERA: to populate the DECV Email link, go and get a delimited list of subject emails
	' BUT only if  Enrolment Year=Current Year otherwise it will cause problems extracting list of teachers
	
	'4-Mar-2011|EA| let's add a little better handling if there is no ENROLMENT_YEAR
	dim tmpENROLYEAR as string = ""
	if (IsNothing(viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR)) then
		tmpENROLYEAR = Convert.ToString(Year(Now()))
	else
		tmpENROLYEAR = viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR.ToString
	end if

	'16-July-2009|EA| adjust from comma delimited to semi-colon for quicker validation in Outlook
	'7-Feb-2011|EA| copied from Student Enrolment (Misc) as that panel is being slowly deprecated
	'23-Apr-2015|EA| added subject status type of 'T' (Transitions) to the list so Teachers can get the emails (unfuddle #705)
	strTeacherEmailList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+';' from (select distinct rtrim(staff_id) + '@vsv.vic.edu.au' as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & viewStudentSummary_DetailData.UrlSTUDENT_ID.tostring & " and STAFF_ID !='N-A' and SUBJ_ENROL_STATUS in ('C','D','E','T')) as T1; select @sCsv2;"))).Value, String)
	' add the student support address to if needed

	if (strTeacherEmailList is nothing) then
		' or (strTeacherEmailList.length = 0) Then 
		viewStudentSummary_Detaillink_create_teacheremails.visible=false
	else

		if not (viewStudentSummary_DetailPASTORAL_CARE_ID.Text.trim="N-A") and not (strTeacherEmailList.contains(viewStudentSummary_DetailPASTORAL_CARE_ID.Text.Trim)) then
			strTeacherEmailList += viewStudentSummary_DetailPASTORAL_CARE_ID.Text.Trim + "@vsv.vic.edu.au"
		end if


      ' 1 Apr 2021|RW| Add the SSG Facilitator to the staff email mailto link
      Dim ssgFacilitatorID = viewStudentSummary_DetailSSG_FACILITATOR_ID.Text.Trim()
      Dim ssgFacilitatorEmail = ssgFacilitatorID & "@vsv.vic.edu.au"
      If ((Not ssgFacilitatorID.Equals("")) AndAlso (Not strTeacherEmailList.Contains(ssgFacilitatorEmail))) Then
         strTeacherEmailList &= ssgFacilitatorEmail
      End If

		'if the last char is a semi-colon then remove it
		Dim chArr1() As Char = {" ", ";"}
		strTeacherEmailList = strTeacherEmailList.TrimEnd(chArr1)

		' for Reports it is 'DataItem', for records it is 'item'
		item.link_create_teacheremailsHref = strTeacherEmailList.ToString

		' ERA: then add the parameters of student name and number to email mailto link DECV Subject Teacher email for [Firstname] [Surname] (DECV Student ID [StudentID])"
		'4-Mar-2019|EA| change DECV to VSV after name change (unf #848)
        ' 16 Sep 2021|RW| If it's been provided, use the student's preferred name in the email link
		 item.link_create_teacheremailsHrefParameters.Add("subject",("VSV Subject Teacher email for " & PreferredFullName & " (Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
		if not IsDBNull(item.link_create_teacheremailsHref) then
			viewStudentSummary_Detaillink_create_teacheremails.HRef = "mailto:" + item.link_create_teacheremailsHref & item.link_create_teacheremailsHrefParameters.ToString("None","", ViewState)
		else
			viewStudentSummary_Detaillink_create_teacheremails.visible=false
		end if
	end if

    ' -------------------------
'End Link link_create_teacheremails Event BeforeShow. Action Custom Code

'Link STUDENT_EMAIL Event BeforeShow. Action Custom Code @420-73254650
    ' -------------------------
    ' ERA: June 2011 add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
    ' ERA: Sept-2013|EA| changed subject 'Query from DECV for' to 'Message from DECV for' (unfuddle #521)
    '4-Mar-2019|EA| change DECV to VSV after name change (unf #848)
    ' 16 Sep 2021|RW| If it's been provided, use the student's preferred name in the email link
	item.student_emailHrefParameters.Add("subject",("Message from Virtual School Victoria for " & PreferredFullName & " (Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
	if not IsDBNull(item.student_emailhref) then
		viewStudentSummary_DetailSTUDENT_EMAIL.HRef = "mailto:" + item.student_emailhref & item.student_emailhrefparameters.ToString("None","", ViewState)
	end if

    ' -------------------------
'End Link STUDENT_EMAIL Event BeforeShow. Action Custom Code

'Label lblATARNotRequired Event BeforeShow. Action Hide-Show Component @423-46B838B7
        If (item.ATAR_REQUIRED.GetFormattedValue() <> "N") Then
            viewStudentSummary_DetaillblATARNotRequired.Visible = False
        End If
'End Label lblATARNotRequired Event BeforeShow. Action Hide-Show Component

'Link link_create_parentemails Event BeforeShow. Action Custom Code @477-73254650
    ' -------------------------
    ' ERA:27-Feb-2014|EA| added link similar to DECV Teachers, to populate the Student/Parent/Supervisor Email link, go and get a delimited list of subject emails
	'   per unfuddle #532
	
	'little better handling if there is no ENROLMENT_YEAR
	'dim tmpENROLYEAR as string = ""
	if (IsNothing(viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR)) then
		tmpENROLYEAR = Convert.ToString(Year(Now()))
	else
		tmpENROLYEAR = viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR.ToString
	end if

	'16-July-2009|EA| adjust from comma delimited to semi-colon for quicker validation in Outlook
	'7-Feb-2011|EA| copied from Student Enrolment (Misc) as that panel is being slowly deprecated
	'12-Dec-2018|EA| add EnrolYear to stored proc tmpENROLYEAR
	Dim strParentEmailList As String = ""
	'strParentEmailList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("EXEC [dbo].[sps_GetParentSupervisorEmailList] @StudentID = " & viewStudentSummary_DetailData.UrlSTUDENT_ID.tostring & ""))).Value, String)
	strParentEmailList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("EXEC [dbo].[sps_GetParentSupervisorEmailList] @StudentID = " & viewStudentSummary_DetailData.UrlSTUDENT_ID.tostring & ", @EnrolYear="&tmpENROLYEAR))).Value, String)
	' add the student support address to if needed

	if (strParentEmailList is nothing) then
		' or (strTeacherEmailList.length = 0) Then 
		viewStudentSummary_Detaillink_create_parentemails.visible=false
	else

		'if the last char is a semi-colon then remove it
		Dim chArr2() As Char = {" ", ";"}
		strParentEmailList = strParentEmailList.TrimEnd(chArr2)

		' for Reports it is 'DataItem', for records it is 'item'
		'strParentEmailList += "&enrolyear="&tmpENROLYEAR
		item.link_create_parentemailsHref = strParentEmailList.ToString

		' ERA: then add the parameters of student name and number to email mailto link DECV Subject Teacher email for [Firstname] [Surname] (DECV Student ID [StudentID])"
		'4-Mar-2019|EA| change DECV to VSV after name change (unf #848)
        ' 16 Sep 2021|RW| If it's been provided, use the student's preferred name in the email link
		 item.link_create_parentemailsHrefParameters.Add("subject",("Virtual School Victoria Email for " & PreferredFullName & " (Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
		if not IsDBNull(item.link_create_parentemailsHref) then
			viewStudentSummary_Detaillink_create_parentemails.HRef = "mailto:" + item.link_create_parentemailsHref & item.link_create_parentemailsHrefParameters.ToString("None","", ViewState)
		else
			viewStudentSummary_Detaillink_create_parentemails.visible=false
		end if
	end if

    ' -------------------------
'End Link link_create_parentemails Event BeforeShow. Action Custom Code

'Label lblPortalAccessRestricted Event BeforeShow. Action Hide-Show Component @516-4A603370
        If (item.PORTAL_ACCESS.GetFormattedValue() <> "N") Then
            viewStudentSummary_DetaillblPortalAccessRestricted.Visible = False
        End If
'End Label lblPortalAccessRestricted Event BeforeShow. Action Hide-Show Component

'Label lblSharedEnrolment Event BeforeShow. Action Hide-Show Component @518-83C6A06D
        If (item.ATTENDING_SCHOOL_ID.GetFormattedValue() = item.HOME_SCHOOL_ID.GetFormattedValue() ) Then
            viewStudentSummary_DetaillblSharedEnrolment.Visible = False
        End If
'End Label lblSharedEnrolment Event BeforeShow. Action Hide-Show Component

'Label cake Event BeforeShow. Action Custom Code @527-73254650
    ' -------------------------
    '7-Aug-2018|EA| display birthday cake if today is their birthday
    viewStudentSummary_Detailcake.Visible = False
    Dim today As new Date()
    Dim birthday As New Date()
    today = DateTime.Today()
    'birthday = DateTime.ParseExact(item.BIRTH_DATE.GetFormattedValue(), "dd/MM/yy", CultureInfo.InvariantCulture)
    Date.TryParseExact(item.BIRTH_DATE.GetFormattedValue(), "dd/MM/yy", CultureInfo.CurrentCulture, _
                      DateTimeStyles.None, birthday)
        
        If (today.Month = birthday.Month And today.Day = birthday.Day) Then
            'viewStudentSummary_Detailcake.Text = "Happy Birthday!"
            viewStudentSummary_Detailcake.Visible = True
        End If
    ' -------------------------
'End Label cake Event BeforeShow. Action Custom Code

'Link link_showstudentreports Event BeforeShow. Action Declare Variable @541-C272DBC2
            Dim tmpStudentID As String = "0unknown"
'End Link link_showstudentreports Event BeforeShow. Action Declare Variable

'Link link_showstudentreports Event BeforeShow. Action Save Control Value @450-042E0957
            tmpStudentID=viewStudentSummary_DetailStudent_id.Text
'End Link link_showstudentreports Event BeforeShow. Action Save Control Value

'Link link_showstudentreports Event BeforeShow. Action Custom Code @451-73254650
    ' -------------------------
    'ERA: 5-Feb-2010 set the link with out the strange extra bits
	'dim tmpHrefURL as string = strLocURL & tmpStudentID
	'viewStudentSummary_Detaillink_showstudentfolder.HRef = tmpHrefURL.tostring()
	'ERA: 15-Aug-2013|EA| added link to Reports
	'tmpHrefURL2 = strLocURL2 & tmpStudentID & "/default.asp"
	'viewStudentSummary_Detaillink_showstudentreports.HRef = tmpHrefURL2.tostring()

    ' -------------------------
'End Link link_showstudentreports Event BeforeShow. Action Custom Code



'Link link_showstudentfolder Event BeforeShow. Action Save Control Value @308-042E0957
            tmpStudentID=viewStudentSummary_DetailStudent_id.Text
'End Link link_showstudentfolder Event BeforeShow. Action Save Control Value

'Link link_showstudentfolder Event BeforeShow. Action Custom Code @309-73254650
    ' -------------------------
    'ERA: 5-Feb-2010 set the link with out the strange extra bits
	dim tmpHrefURL as string = strLocURL & tmpStudentID
	viewStudentSummary_Detaillink_showstudentfolder.HRef = tmpHrefURL.tostring()
	'ERA: 15-Aug-2013|EA| added link to Reports
	dim tmpHrefURL2 as string = strLocURL2 & tmpStudentID & "/default.asp"
	viewStudentSummary_Detaillink_showstudentreports.HRef = tmpHrefURL2.tostring()

    ' -------------------------
'End Link link_showstudentfolder Event BeforeShow. Action Custom Code

'Link LinkLearningAdvisorEmail Event BeforeShow. Action Custom Code @1116-73254650
    ' -------------------------
    ' 16 Sep 2021|RW| If it's been provided, use the student's preferred name in the email link
	item.LinkLearningAdvisorEmailHrefParameters.Add("subject",("VSV Learning Advisor email for " & PreferredFullName & " (Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
	Dim learningAdvisorID = item.LinkLearningAdvisorEmailHref.ToString().Trim().ToLower()
	if ((not IsDBNull(item.LinkLearningAdvisorEmailHref)) AndAlso (learningAdvisorID <> "no_sst") AndAlso (learningAdvisorID <> "n-a")) Then
		viewStudentSummary_DetailLinkLearningAdvisorEmail.HRef = "mailto:" & learningAdvisorID & "@vsv.vic.edu.au" & item.LinkLearningAdvisorEmailHrefParameters.ToString("None", "", ViewState)
		viewStudentSummary_DetailPASTORAL_CARE_ID.Visible = False
	Else
		viewStudentSummary_DetailPASTORAL_CARE_ID.Visible = True
		viewStudentSummary_DetailLinkLearningAdvisorEmail.Visible = False
	end if

    ' -------------------------
'End Link LinkLearningAdvisorEmail Event BeforeShow. Action Custom Code

'Link FunnelLink Event BeforeShow. Action Custom Code @1330-73254650
    ' -------------------------
    ' Write your own code here.
    ' 2023-11-27|LG| Create Link to funnel if we know the student's funnel ID
	Dim funnelId = item.FunnelUUID.Value
	If (String.IsNullOrWhiteSpace(funnelId))
		viewStudentSummary_DetailFunnelLink.Visible = False
		viewStudentSummary_DetailFilesLink.Visible = False
		viewStudentSummary_DetailReferralsLink.Visible = False
		viewStudentSummary_DetailFunnelUUID.Text = "No Funnel ID recorded for student. Files and Forms not available."
	Else
		viewStudentSummary_DetailFunnelUUID.Visible = False
		viewStudentSummary_DetailFunnelLink.HRef = $"http://vsv-app02:65004/lead_details/{item.FunnelUUID.Value.ToLower()}"
		viewStudentSummary_DetailFunnelLink.Target = "_blank"
		viewStudentSummary_DetailFilesLink.HRef = $"http://vsv-app02:65004/files/{item.FunnelUUID.Value.ToLower()}/page_title"
		viewStudentSummary_DetailFilesLink.Target = "_blank"
	End If
    ' -------------------------
'End Link FunnelLink Event BeforeShow. Action Custom Code

'Link FilesLink Event BeforeShow. Action Custom Code @1331-73254650
    ' -------------------------
    ' Write your own code here.
    'files link
    ' -------------------------
'End Link FilesLink Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      ' ERA: alter M / F to 'Male'/'Female'
'DEL  	select case item.sex.getformattedvalue()
'DEL  		case "M"
'DEL  			viewStudentSummary_DetailSEX.Text = "Male"
'DEL  		case "F"
'DEL  			viewStudentSummary_DetailSEX.Text = "Female"
'DEL  		case else
'DEL              ' 16 Sep 2021|RW| Apply more emphasis to self-described gender students; SD 34651
'DEL  			Dim selfDescribedGender = item.hidden_SEX_SELF_DESCRIBED.GetFormattedValue()
'DEL  			viewStudentSummary_DetailSEX.Text = "<h2>" & If(selfDescribedGender.Length > 0, selfDescribedGender, "Not specified") & "</h2>"
'DEL  	end select
'DEL  
'DEL      ' -------------------------


'Record viewStudentSummary_Detail Event BeforeShow. Action Custom Code @310-73254650
    ' -------------------------
 	'ERA: 11-Feb-2010|EA| extend normal show-hide code into a larger check for existance of actual folder, and set all the Visible in a single IF
	' From StudentDetails_maitain, but slightly simplified without [Create Folders] button
		dim tmpHrefCheck as string = strLocCreate & tmpStudentID

		' if there is no Date created then never done and so should be created
		if (item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()<>"") then 
			' so likely that folder exists, so double check
			if (System.IO.Directory.Exists(tmpHrefCheck)) then
				viewStudentSummary_Detaillink_showstudentfolder.visible = true
				viewStudentSummary_DetaillabelContactWho.visible = false
			else
				viewStudentSummary_Detaillink_showstudentfolder.visible = false	'debug: should be false
				viewStudentSummary_DetaillabelContactWho.Text = "<em>Contact PC Support for Student Files</em>"
				viewStudentSummary_DetaillabelContactWho.visible = true
			end if
		End If
		
	'ERA: 15-Aug-2013|EA| extend to check for Reports folder too but need to use URL
	' from http://www.dreamincode.net/forums/topic/137663-check-if-url-exists/

	Dim url As New System.Uri(viewStudentSummary_Detaillink_showstudentreports.HRef.ToString())
    Dim wRequest As System.Net.WebRequest
    wRequest = System.Net.WebRequest.Create(url)
    Dim wResponse As System.Net.WebResponse
	
    Try
        wResponse = wRequest.GetResponse()
        'Is the responding address the same as HostAddress to avoid false positive from an automatic redirect.
        If wResponse.ResponseUri.AbsoluteUri().toUpper() = viewStudentSummary_Detaillink_showstudentreports.HRef.toUpper() Then 'include query strings
			' show it and hide the error message
		    viewStudentSummary_Detaillink_showstudentreports.visible = true
			viewStudentSummary_DetaillabelContactWho1.visible = false
		else
			viewStudentSummary_Detaillink_showstudentreports.visible = true
			viewStudentSummary_DetaillabelContactWho1.Text = wResponse.ResponseUri.AbsoluteUri().toUpper()
			viewStudentSummary_DetaillabelContactWho1.visible = true
        End If
       wResponse.Close()
       wRequest = Nothing
   Catch ex As Exception
       wRequest = Nothing
		' hide the link and show the error 
		viewStudentSummary_Detaillink_showstudentreports.visible = false	'debug: should be false
		viewStudentSummary_DetaillabelContactWho1.Text = "<em>Student Reports not found</em>  <!--" & ex.tostring() & "-->"
		viewStudentSummary_DetaillabelContactWho1.visible = true 'debug: should be true
   End Try		
    ' -------------------------
'End Record viewStudentSummary_Detail Event BeforeShow. Action Custom Code

'Record Form viewStudentSummary_Detail Show method tail @4-47328033
        If viewStudentSummary_DetailErrors.Count > 0 Then
            viewStudentSummary_DetailShowErrors()
        End If
    End Sub
'End Record Form viewStudentSummary_Detail Show method tail

'Record Form viewStudentSummary_Detail LoadItemFromRequest method @4-1AF7C9D9

    Protected Sub viewStudentSummary_DetailLoadItemFromRequest(item As viewStudentSummary_DetailItem, ByVal EnableValidation As Boolean)
        Try
        item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Detailhidden_DATE_STUDENTFOLDER_CREATED.UniqueID))
        item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(viewStudentSummary_Detailhidden_DATE_STUDENTFOLDER_CREATED.Value)
        Catch ae As ArgumentException
            viewStudentSummary_DetailErrors.Add("hidden_DATE_STUDENTFOLDER_CREATED",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_DATE_STUDENTFOLDER_CREATED","yyyy-mm-dd H:nn"))
        End Try
        item.hidden_SEX_SELF_DESCRIBED.IsEmpty = IsNothing(Request.Form(viewStudentSummary_Detailhidden_SEX_SELF_DESCRIBED.UniqueID))
        item.hidden_SEX_SELF_DESCRIBED.SetValue(viewStudentSummary_Detailhidden_SEX_SELF_DESCRIBED.Value)
        If EnableValidation Then
            item.Validate(viewStudentSummary_DetailData)
        End If
        viewStudentSummary_DetailErrors.Add(item.errors)
    End Sub
'End Record Form viewStudentSummary_Detail LoadItemFromRequest method

'Record Form viewStudentSummary_Detail GetRedirectUrl method @4-437079B7

    Protected Function GetviewStudentSummary_DetailRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewStudentSummary_Detail GetRedirectUrl method

'Record Form viewStudentSummary_Detail ShowErrors method @4-962C34CF

    Protected Sub viewStudentSummary_DetailShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewStudentSummary_DetailErrors.Count - 1
        Select Case viewStudentSummary_DetailErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewStudentSummary_DetailErrors(i)
        End Select
        Next i
        viewStudentSummary_DetailError.Visible = True
        viewStudentSummary_DetailErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewStudentSummary_Detail ShowErrors method

'Record Form viewStudentSummary_Detail Insert Operation @4-54ACB4D3

    Protected Sub viewStudentSummary_Detail_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
        viewStudentSummary_DetailIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentSummary_Detail Insert Operation

'Record Form viewStudentSummary_Detail BeforeInsert tail @4-56867F00
    viewStudentSummary_DetailParameters()
    viewStudentSummary_DetailLoadItemFromRequest(item, EnableValidation)
'End Record Form viewStudentSummary_Detail BeforeInsert tail

'Record Form viewStudentSummary_Detail AfterInsert tail  @4-98DF0F27
        ErrorFlag=(viewStudentSummary_DetailErrors.Count > 0)
        If ErrorFlag Then
            viewStudentSummary_DetailShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentSummary_Detail AfterInsert tail 

'Record Form viewStudentSummary_Detail Update Operation @4-00261FE5

    Protected Sub viewStudentSummary_Detail_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewStudentSummary_DetailIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentSummary_Detail Update Operation

'Record Form viewStudentSummary_Detail Before Update tail @4-56867F00
        viewStudentSummary_DetailParameters()
        viewStudentSummary_DetailLoadItemFromRequest(item, EnableValidation)
'End Record Form viewStudentSummary_Detail Before Update tail

'Record Form viewStudentSummary_Detail Update Operation tail @4-98DF0F27
        ErrorFlag=(viewStudentSummary_DetailErrors.Count > 0)
        If ErrorFlag Then
            viewStudentSummary_DetailShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentSummary_Detail Update Operation tail

'Record Form viewStudentSummary_Detail Delete Operation @4-EA074C98
    Protected Sub viewStudentSummary_Detail_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewStudentSummary_DetailIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewStudentSummary_Detail Delete Operation

'Record Form BeforeDelete tail @4-56867F00
        viewStudentSummary_DetailParameters()
        viewStudentSummary_DetailLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-BE9D34E7
        If ErrorFlag Then
            viewStudentSummary_DetailShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewStudentSummary_Detail Cancel Operation @4-C07C787E

    Protected Sub viewStudentSummary_Detail_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentSummary_DetailItem = New viewStudentSummary_DetailItem()
        viewStudentSummary_DetailIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewStudentSummary_DetailLoadItemFromRequest(item, True)
'End Record Form viewStudentSummary_Detail Cancel Operation

'Record Form viewStudentSummary_Detail Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewStudentSummary_Detail Cancel Operation tail

'Grid viewStudentSummary_SubjectList Bind @36-C36F496D

    Protected Sub viewStudentSummary_SubjectListBind()
        If Not viewStudentSummary_SubjectListOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewStudentSummary_SubjectList",GetType(viewStudentSummary_SubjectListDataProvider.SortFields), 40, 100)
        End If
'End Grid viewStudentSummary_SubjectList Bind

'Grid Form viewStudentSummary_SubjectList BeforeShow tail @36-3B6F7CCA
        viewStudentSummary_SubjectListParameters()
        viewStudentSummary_SubjectListData.SortField = CType(ViewState("viewStudentSummary_SubjectListSortField"),viewStudentSummary_SubjectListDataProvider.SortFields)
        viewStudentSummary_SubjectListData.SortDir = CType(ViewState("viewStudentSummary_SubjectListSortDir"),SortDirections)
        viewStudentSummary_SubjectListData.PageNumber = CInt(ViewState("viewStudentSummary_SubjectListPageNumber"))
        viewStudentSummary_SubjectListData.RecordsPerPage = CInt(ViewState("viewStudentSummary_SubjectListPageSize"))
        viewStudentSummary_SubjectListRepeater.DataSource = viewStudentSummary_SubjectListData.GetResultSet(PagesCount, viewStudentSummary_SubjectListOperations)
        ViewState("viewStudentSummary_SubjectListPagesCount") = PagesCount
        Dim item As viewStudentSummary_SubjectListItem = New viewStudentSummary_SubjectListItem()
        viewStudentSummary_SubjectListRepeater.DataBind
        FooterIndex = viewStudentSummary_SubjectListRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewStudentSummary_SubjectListRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form viewStudentSummary_SubjectList BeforeShow tail

'Grid viewStudentSummary_SubjectList Bind tail @36-E31F8E2A
    End Sub
'End Grid viewStudentSummary_SubjectList Bind tail

'Grid viewStudentSummary_SubjectList Table Parameters @36-818DBE17

    Protected Sub viewStudentSummary_SubjectListParameters()
        Try
            viewStudentSummary_SubjectListData.Urlstudent_id = IntegerParameter.GetParam("student_id", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_SubjectListData.Urlenrolment_year = FloatParameter.GetParam("enrolment_year", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewStudentSummary_SubjectListRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewStudentSummary_SubjectListRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewStudentSummary_SubjectList: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewStudentSummary_SubjectList Table Parameters

'Grid viewStudentSummary_SubjectList ItemDataBound event @36-33399860

    Protected Sub viewStudentSummary_SubjectListItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewStudentSummary_SubjectListItem = CType(e.Item.DataItem,viewStudentSummary_SubjectListItem)
        Dim Item as viewStudentSummary_SubjectListItem = DataItem
        Dim FormDataSource As viewStudentSummary_SubjectListItem() = CType(viewStudentSummary_SubjectListRepeater.DataSource, viewStudentSummary_SubjectListItem())
        Dim viewStudentSummary_SubjectListDataRows As Integer = FormDataSource.Length
        Dim viewStudentSummary_SubjectListIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewStudentSummary_SubjectListCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewStudentSummary_SubjectListRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewStudentSummary_SubjectListCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewStudentSummary_SubjectListSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListenrolment_date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListenrolment_date"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListwithdrawal_date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListwithdrawal_date"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListNUM_ASSMT_SUBMISSIONS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListNUM_ASSMT_SUBMISSIONS"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListINTERIM_PROGRESS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListINTERIM_PROGRESS_CODE"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListFINAL_PROGRESS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListFINAL_PROGRESS_CODE"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListCUSTOM_LP_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListCUSTOM_LP_display"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListEXTENSION_OF_VCE_UNIT_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListEXTENSION_OF_VCE_UNIT_display"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListNON_SUBMITTING_FLAG_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListNON_SUBMITTING_FLAG_display"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim viewStudentSummary_SubjectListCLASS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewStudentSummary_SubjectListCLASS_CODE"),System.Web.UI.WebControls.Literal)
        End If
'End Grid viewStudentSummary_SubjectList ItemDataBound event

'Grid viewStudentSummary_SubjectList BeforeShowRow event @36-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid viewStudentSummary_SubjectList BeforeShowRow event

'Grid viewStudentSummary_SubjectList Event BeforeShowRow. Action Custom Code @445-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Grid viewStudentSummary_SubjectList Event BeforeShowRow. Action Custom Code

'Grid viewStudentSummary_SubjectList BeforeShowRow event tail @36-477CF3C9
        End If
'End Grid viewStudentSummary_SubjectList BeforeShowRow event tail

'Grid viewStudentSummary_SubjectList ItemDataBound event tail @36-67ED4BA8
        If viewStudentSummary_SubjectListIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewStudentSummary_SubjectListCurrentRowNumber, ListItemType.Item)
            viewStudentSummary_SubjectListRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewStudentSummary_SubjectListItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewStudentSummary_SubjectList ItemDataBound event tail

'Grid viewStudentSummary_SubjectList ItemCommand event @36-7C657C9D

    Protected Sub viewStudentSummary_SubjectListItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewStudentSummary_SubjectListRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewStudentSummary_SubjectListSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewStudentSummary_SubjectListSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewStudentSummary_SubjectListSortDir")=SortDirections._Desc
                Else
                    ViewState("viewStudentSummary_SubjectListSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewStudentSummary_SubjectListSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewStudentSummary_SubjectListDataProvider.SortFields = 0
            ViewState("viewStudentSummary_SubjectListSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewStudentSummary_SubjectListPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewStudentSummary_SubjectListPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewStudentSummary_SubjectListPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewStudentSummary_SubjectListPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewStudentSummary_SubjectListBind
        End If
    End Sub
'End Grid viewStudentSummary_SubjectList ItemCommand event

'Grid STUDENT_COMMENT Bind @50-A874B4FD

    Protected Sub STUDENT_COMMENTBind()
        If Not STUDENT_COMMENTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_COMMENT",GetType(STUDENT_COMMENTDataProvider.SortFields), 50, 100)
        End If
'End Grid STUDENT_COMMENT Bind

'Grid Form STUDENT_COMMENT BeforeShow tail @50-25ECE030
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTData.SortField = CType(ViewState("STUDENT_COMMENTSortField"),STUDENT_COMMENTDataProvider.SortFields)
        STUDENT_COMMENTData.SortDir = CType(ViewState("STUDENT_COMMENTSortDir"),SortDirections)
        STUDENT_COMMENTData.PageNumber = CInt(ViewState("STUDENT_COMMENTPageNumber"))
        STUDENT_COMMENTData.RecordsPerPage = CInt(ViewState("STUDENT_COMMENTPageSize"))
        STUDENT_COMMENTRepeater.DataSource = STUDENT_COMMENTData.GetResultSet(PagesCount, STUDENT_COMMENTOperations)
        ViewState("STUDENT_COMMENTPagesCount") = PagesCount
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        STUDENT_COMMENTRepeater.DataBind
        FooterIndex = STUDENT_COMMENTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_COMMENTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form STUDENT_COMMENT BeforeShow tail

'Grid STUDENT_COMMENT Bind tail @50-E31F8E2A
    End Sub
'End Grid STUDENT_COMMENT Bind tail

'Grid STUDENT_COMMENT Table Parameters @50-C66CAF61

    Protected Sub STUDENT_COMMENTParameters()
        Try
            STUDENT_COMMENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_COMMENTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_COMMENTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_COMMENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_COMMENT Table Parameters

'Grid STUDENT_COMMENT ItemDataBound event @50-C318BDEB

    Protected Sub STUDENT_COMMENTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_COMMENTItem = CType(e.Item.DataItem,STUDENT_COMMENTItem)
        Dim Item as STUDENT_COMMENTItem = DataItem
        Dim FormDataSource As STUDENT_COMMENTItem() = CType(STUDENT_COMMENTRepeater.DataSource, STUDENT_COMMENTItem())
        Dim STUDENT_COMMENTDataRows As Integer = FormDataSource.Length
        Dim STUDENT_COMMENTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_COMMENTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_COMMENTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_COMMENTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_COMMENTCOMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENTCOMMENT"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENTCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENTCOMMENT_TYPE"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_COMMENT ItemDataBound event

'Grid STUDENT_COMMENT ItemDataBound event tail @50-00EC0193
        If STUDENT_COMMENTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_COMMENTCurrentRowNumber, ListItemType.Item)
            STUDENT_COMMENTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_COMMENTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_COMMENT ItemDataBound event tail

'Grid STUDENT_COMMENT ItemCommand event @50-D4E452AA

    Protected Sub STUDENT_COMMENTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_COMMENTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_COMMENTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_COMMENTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_COMMENTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_COMMENTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_COMMENTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_COMMENTDataProvider.SortFields = 0
            ViewState("STUDENT_COMMENTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_COMMENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_COMMENTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_COMMENTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_COMMENTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_COMMENTBind
        End If
    End Sub
'End Grid STUDENT_COMMENT ItemCommand event

'Report viewStudentSummary_Enrolm Bind @185-BB225C5B
    Protected Sub viewStudentSummary_EnrolmBind()
        If Not viewStudentSummary_EnrolmOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"viewStudentSummary_Enrolm",GetType(viewStudentSummary_EnrolmDataProvider.SortFields), 0, 100)
        End If
'End Report viewStudentSummary_Enrolm Bind

'Report Form viewStudentSummary_Enrolm BeforeShow tail @185-951A6DEC
        viewStudentSummary_EnrolmParameters
        viewStudentSummary_EnrolmData.SortField = CType(ViewState("viewStudentSummary_EnrolmSortField"),viewStudentSummary_EnrolmDataProvider.SortFields)
        viewStudentSummary_EnrolmData.SortDir = CType(ViewState("viewStudentSummary_EnrolmSortDir"),SortDirections)
        viewStudentSummary_Enrolm.DataSource = viewStudentSummary_EnrolmData.GetResultSet(viewStudentSummary_EnrolmOperations)
        viewStudentSummary_Enrolm.DataBind()
'End Report Form viewStudentSummary_Enrolm BeforeShow tail

	End Sub 'Report viewStudentSummary_Enrolm Bind tail @185-E31F8E2A

'Report viewStudentSummary_Enrolm Table Parameters @185-B5CB844D

    Protected Sub viewStudentSummary_EnrolmParameters()
        Try
            viewStudentSummary_EnrolmData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewStudentSummary_Enrolm.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewStudentSummary_Enrolm)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewStudentSummary_Enrolm: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report viewStudentSummary_Enrolm Table Parameters

'Report viewStudentSummary_Enrolm BeforeShowSection event @185-C5F24EA3
    Protected Sub viewStudentSummary_EnrolmBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As viewStudentSummary_EnrolmItem  = CType(e.Item.DataItem, viewStudentSummary_EnrolmItem)
        Dim Item As viewStudentSummary_EnrolmItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New viewStudentSummary_EnrolmItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim viewStudentSummary_Enrolmeligible_for_discount_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmeligible_for_discount_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmpaid_on_enrolment_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmpaid_on_enrolment_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmfull_time_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmfull_time_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmos_full_fee_paying_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmos_full_fee_paying_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmaddress_review_flag_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmaddress_review_flag_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmeligible_for_funding_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmeligible_for_funding_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmvce_candidate_number As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmvce_candidate_number"),ReportLabel)
                Dim viewStudentSummary_Enrolmbulletin_number As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmbulletin_number"),ReportLabel)
                Dim viewStudentSummary_Enrolmlast_reviewed_date As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmlast_reviewed_date"),ReportLabel)
                Dim viewStudentSummary_Enrolmnew_docs_required_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmnew_docs_required_desc"),ReportLabel)
                Dim viewStudentSummary_Enrolmenrolment_comments As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Enrolmenrolment_comments"),ReportLabel)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report viewStudentSummary_Enrolm BeforeShowSection event

'DEL      ' -------------------------
'DEL      ' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL      ' ERA: Sept-2013|EA| changed subject 'Query from DECV for' to 'Message from DECV for' (unfuddle #521)
'DEL  	DataItem.school_supervisor_emailHrefParameters.Add("subject",("Message regarding Student " + viewStudentSummary_Detailfirst_name.Text.Trim +" " + viewStudentSummary_Detailsurname.Text.Trim + " (DECV Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
'DEL  	if not IsDBNull(dataitem.school_supervisor_emailhref) then
'DEL  		viewStudentSummary_Enrolmschool_supervisor_email.HRef = "mailto:" + DataItem.school_supervisor_emailHref & DataItem.school_supervisor_emailHrefParameters.ToString("None","", ViewState)
'DEL  	end if
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: Feb 2009|EA| trim Region Name
'DEL  	viewStudentSummary_Enrolmregion_name.text = viewStudentSummary_Enrolmregion_name.text.trim
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL      ' ERA: Sept-2013|EA| changed subject 'Query from DECV for' to 'Message from DECV for' (unfuddle #521)
'DEL  	DataItem.student_emailHrefParameters.Add("subject",("Message from DECV for " + viewStudentSummary_Detailfirst_name.Text.Trim +" " + viewStudentSummary_Detailsurname.Text.Trim + " (DECV Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
'DEL  	if not IsDBNull(dataitem.student_emailhref) then
'DEL  		viewStudentSummary_Enrolmstudent_email.HRef = "mailto:" + DataItem.student_emailhref & DataItem.student_emailhrefparameters.ToString("None","", ViewState)
'DEL  	end if
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL      ' ERA: Sept-2013|EA| changed subject 'Query from DECV for' to 'Message from DECV for' (unfuddle #521)
'DEL  	DataItem.parent_emailhrefparameters.Add("subject",("Message from DECV for " + viewStudentSummary_Detailfirst_name.Text.Trim +" " + viewStudentSummary_Detailsurname.Text.Trim + " (DECV Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
'DEL  	if not IsDBNull(dataitem.parent_emailhref) then
'DEL  		viewStudentSummary_Enrolmparent_email.HRef = "mailto:" + DataItem.parent_emailhref & DataItem.parent_emailhrefparameters.ToString("None","", ViewState)
'DEL  	end if
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: to populate the DECV Email link, go and get a delimited list of subject emails
'DEL  	' BUT only if  Enrolment Year=Current Year otherwise it will cause problems extracting list of teachers
'DEL  	'4-Mar-2011|EA| let's add a little better handling if there is no ENROLMENT_YEAR
'DEL  	dim tmpENROLYEAR as string = ""
'DEL  	if (IsNothing(viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR)) then
'DEL  		tmpENROLYEAR = Convert.ToString(Year(Now()))
'DEL  	else
'DEL  		tmpENROLYEAR = viewStudentSummary_EnrolmData.UrlENROLMENT_YEAR.ToString
'DEL  	end if
'DEL  
'DEL  	'16-July-2009|EA| adjust from comma delimited to semi-colon for quicker validation in Outlook
'DEL  	strTeacherEmailList = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+';' from (select distinct rtrim(staff_id) + '@distance.vic.edu.au' as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & viewStudentSummary_EnrolmData.UrlSTUDENT_ID.tostring & " and STAFF_ID !='N-A' and SUBJ_ENROL_STATUS in ('C','D','E')) as T1; select @sCsv2;"))).Value, String)
'DEL  	' add the student support address to if needed
'DEL  
'DEL  	if (strTeacherEmailList is nothing) then
'DEL  		' or (strTeacherEmailList.length = 0) Then 
'DEL  		viewStudentSummary_Enrolmlink_create_teacheremails.visible=false
'DEL  	else
'DEL  
'DEL  		if not (viewStudentSummary_DetailPASTORAL_CARE_ID.Text.trim="N-A") and not (strTeacherEmailList.contains(viewStudentSummary_DetailPASTORAL_CARE_ID.Text.Trim)) then
'DEL  			strTeacherEmailList += viewStudentSummary_DetailPASTORAL_CARE_ID.Text.Trim + "@distance.vic.edu.au"
'DEL  		end if
'DEL  
'DEL  		'if the last char is a semi-colon then remove it
'DEL  		Dim chArr1() As Char = {" ", ";"}
'DEL  		strTeacherEmailList = strTeacherEmailList.TrimEnd(chArr1)
'DEL  
'DEL  		DataItem.link_create_teacheremailsHref = strTeacherEmailList.ToString
'DEL  
'DEL  		' ERA: then add the parameters of student name and number to email mailto link DECV Subject Teacher email for [Firstname] [Surname] (DECV Student ID [StudentID])"
'DEL  		 DataItem.link_create_teacheremailsHrefParameters.Add("subject",("DECV Subject Teacher email for " + viewStudentSummary_Detailfirst_name.Text.Trim +" " + viewStudentSummary_Detailsurname.Text.Trim + " (DECV Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
'DEL  		if not IsDBNull(DataItem.link_create_teacheremailsHref) then
'DEL  			viewStudentSummary_Enrolmlink_create_teacheremails.HRef = "mailto:" + DataItem.link_create_teacheremailsHref & DataItem.link_create_teacheremailsHrefParameters.ToString("None","", ViewState)
'DEL  		else
'DEL  			viewStudentSummary_Enrolmlink_create_teacheremails.visible=false
'DEL  		end if
'DEL  	end if
'DEL  
'DEL      ' -------------------------


    End Sub 'Section viewStudentSummary_Enrolm BeforeShow events tail @185-E31F8E2A

'Report viewStudentSummary_Enrolm ItemCommand event @185-4E1E180A
    Protected Sub viewStudentSummary_EnrolmItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewStudentSummary_EnrolmSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewStudentSummary_EnrolmSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewStudentSummary_EnrolmSortDir")=SortDirections._Desc
                Else
                    ViewState("viewStudentSummary_EnrolmSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewStudentSummary_EnrolmSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewStudentSummary_EnrolmDataProvider.SortFields = 0
            ViewState("viewStudentSummary_EnrolmSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewStudentSummary_EnrolmPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            viewStudentSummary_Enrolm.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewStudentSummary_EnrolmBind
        End If
    End Sub
'End Report viewStudentSummary_Enrolm ItemCommand event

'Report ADDRESS_Postal Bind @60-B26FE14A
    Protected Sub ADDRESS_PostalBind()
        If Not ADDRESS_PostalOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"ADDRESS_Postal",GetType(ADDRESS_PostalDataProvider.SortFields), 0, 100)
        End If
'End Report ADDRESS_Postal Bind

'Report Form ADDRESS_Postal BeforeShow tail @60-769F34A4
        ADDRESS_PostalParameters
        ADDRESS_PostalData.SortField = CType(ViewState("ADDRESS_PostalSortField"),ADDRESS_PostalDataProvider.SortFields)
        ADDRESS_PostalData.SortDir = CType(ViewState("ADDRESS_PostalSortDir"),SortDirections)
        ADDRESS_Postal.DataSource = ADDRESS_PostalData.GetResultSet(ADDRESS_PostalOperations)
        ADDRESS_Postal.DataBind()
'End Report Form ADDRESS_Postal BeforeShow tail

	End Sub 'Report ADDRESS_Postal Bind tail @60-E31F8E2A

'Report ADDRESS_Postal Table Parameters @60-90B92264

    Protected Sub ADDRESS_PostalParameters()
        Try
            ADDRESS_PostalData.Expr84 = FloatParameter.GetParam(viewStudentSummary_DetailPOSTAL_ADDRESS_ID.Text, ParameterSourceType.Expression, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ADDRESS_Postal.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ADDRESS_Postal)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ADDRESS_Postal: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report ADDRESS_Postal Table Parameters

'Report ADDRESS_Postal BeforeShowSection event @60-6FD9B12C
    Protected Sub ADDRESS_PostalBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As ADDRESS_PostalItem  = CType(e.Item.DataItem, ADDRESS_PostalItem)
        Dim Item As ADDRESS_PostalItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New ADDRESS_PostalItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim ADDRESS_PostalADDRESSEE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDRESSEE"),ReportLabel)
                Dim ADDRESS_PostalAGENT As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalAGENT"),ReportLabel)
                Dim ADDRESS_PostalADDR1 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDR1"),ReportLabel)
                Dim ADDRESS_PostalADDR2 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDR2"),ReportLabel)
                Dim ADDRESS_PostalSUBURB_TOWN As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalSUBURB_TOWN"),ReportLabel)
                Dim ADDRESS_PostalSTATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalSTATE"),ReportLabel)
                Dim ADDRESS_PostalPOSTCODE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPOSTCODE"),ReportLabel)
                Dim ADDRESS_PostalCOUNTRY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalCOUNTRY"),ReportLabel)
                Dim ADDRESS_PostalPHONE_A As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPHONE_A"),ReportLabel)
                Dim ADDRESS_PostalPHONE_B As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPHONE_B"),ReportLabel)
                Dim ADDRESS_PostalFAX As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalFAX"),ReportLabel)
                Dim ADDRESS_PostalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_PostalLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalLAST_ALTERED_BY"),ReportLabel)
                Dim ADDRESS_PostalLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalLAST_ALTERED_DATE"),ReportLabel)
                Dim ADDRESS_PostalADDRESS_ID As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDRESS_ID"),ReportLabel)
                Dim ADDRESS_PostalImageLink_GoogleMaps_postal As System.Web.UI.WebControls.HyperLink = DirectCast(e.Item.FindControl("ADDRESS_PostalImageLink_GoogleMaps_postal"),System.Web.UI.WebControls.HyperLink)
                ADDRESS_PostalEMAIL_ADDRESS.HRef = "mailto:" + DataItem.EMAIL_ADDRESSHref & DataItem.EMAIL_ADDRESSHrefParameters.ToString("None","", ViewState)
                DataItem.ImageLink_GoogleMaps_postalHref = "http://maps.google.com.au/maps?f=q&source=s_q&hl=en&geocode=&ie=UTF8&z=14"
                ADDRESS_PostalImageLink_GoogleMaps_postal.ImageUrl += DataItem.ImageLink_GoogleMaps_postal.GetFormattedValue()
                ADDRESS_PostalImageLink_GoogleMaps_postal.NavigateUrl += DataItem.ImageLink_GoogleMaps_postalHref & DataItem.ImageLink_GoogleMaps_postalHrefParameters.ToString("None","", ViewState).Replace("&amp;", "&")
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report ADDRESS_Postal BeforeShowSection event

		Select e.Item.name 'BeforeShow events @60-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @63-D5562AB6

'Get EMAIL_ADDRESS control @78-714929C8
                Dim ADDRESS_PostalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS control

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @240-73254650
    ' -------------------------
    ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	DataItem.email_addresshrefparameters.add("subject",("<insert subject>").ToString())
	if not IsDBNull(dataitem.email_addresshref) then
		ADDRESS_PostalEMAIL_ADDRESS.HRef = "mailto:" + trim(DataItem.email_addresshref) & DataItem.email_addresshrefparameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL  	DataItem.email_address2hrefparameters.add("subject",("<insert subject>").ToString())
'DEL  	if not IsDBNull(dataitem.email_address2href) then
'DEL  		ADDRESS_PostalEMAIL_ADDRESS2.HRef = "mailto:" + trim(DataItem.email_address2href) & DataItem.email_address2hrefparameters.tostring("None","", ViewState)
'DEL  	end if
'DEL      ' -------------------------


'Get ImageLink_GoogleMaps_postal control @329-6BC0B9AC
                Dim ADDRESS_PostalImageLink_GoogleMaps_postal As System.Web.UI.WebControls.HyperLink = DirectCast(e.Item.FindControl("ADDRESS_PostalImageLink_GoogleMaps_postal"),System.Web.UI.WebControls.HyperLink)
'End Get ImageLink_GoogleMaps_postal control

'ImageLink ImageLink_GoogleMaps_postal Event BeforeShow. Action Custom Code @334-73254650
    ' -------------------------
    ' ERA: 23-Aug-2010|EA| append address 1+2, town, postcode to google map icon
	'ADDRESS_PostalImageLink_GoogleMaps_postal
	'DataItem.email_address2hrefparameters.add("subject",("<insert subject>").ToString())
	dim tmpFlagShowMap as boolean = true
	dim tmpAddressForMaps as string = ""

	tmpAddressForMaps = Dataitem.ADDR1.GetFormattedValue().Trim()

	if (DataItem.ADDR2.GetFormattedValue() <> "") then 
		tmpAddressForMaps += " " + DataItem.ADDR2.GetFormattedValue().Trim()
	end if

	if (DataItem.SUBURB_TOWN.GetFormattedValue() <> "") then 
		tmpAddressForMaps += "," + DataItem.SUBURB_TOWN.GetFormattedValue().Trim()
	else
		tmpFlagShowMap = false
	end if 
	
	if (DataItem.POSTCODE.GetFormattedValue() <> "") then 
		tmpAddressForMaps += "," + DataItem.POSTCODE.GetFormattedValue().Trim()
	else
		tmpFlagShowMap = false
	end if 
  	
	if (DataItem.COUNTRY.GetFormattedValue() <> "AUSTRALIA") then 
		tmpAddressForMaps += "," + DataItem.COUNTRY.GetFormattedValue().Trim()
	end if 


	tmpAddressForMaps=tmpAddressForMaps.replace(" ", "+")

	if (tmpAddressForMaps="") or (tmpFlagShowMap = false) then
		ADDRESS_PostalImageLink_GoogleMaps_postal.visible = false
	else
		ADDRESS_PostalImageLink_GoogleMaps_postal.NavigateUrl += "&q=" + tmpAddressForMaps.tostring()
	end if

    ' -------------------------
'End ImageLink ImageLink_GoogleMaps_postal Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @60-3508C6CC

    End Sub 'Section ADDRESS_Postal BeforeShow events tail @60-E31F8E2A

'Report ADDRESS_Postal ItemCommand event @60-39CD30DB
    Protected Sub ADDRESS_PostalItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ADDRESS_PostalSortDir"),SortDirections) = SortDirections._Asc And ViewState("ADDRESS_PostalSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ADDRESS_PostalSortDir")=SortDirections._Desc
                Else
                    ViewState("ADDRESS_PostalSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ADDRESS_PostalSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ADDRESS_PostalDataProvider.SortFields = 0
            ViewState("ADDRESS_PostalSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ADDRESS_PostalPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ADDRESS_Postal.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ADDRESS_PostalBind
        End If
    End Sub
'End Report ADDRESS_Postal ItemCommand event

'Report ADDRESS_Current Bind @121-E7FBF1B2
    Protected Sub ADDRESS_CurrentBind()
        If Not ADDRESS_CurrentOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"ADDRESS_Current",GetType(ADDRESS_CurrentDataProvider.SortFields), 0, 100)
        End If
'End Report ADDRESS_Current Bind

'Report Form ADDRESS_Current BeforeShow tail @121-A16A377C
        ADDRESS_CurrentParameters
        ADDRESS_CurrentData.SortField = CType(ViewState("ADDRESS_CurrentSortField"),ADDRESS_CurrentDataProvider.SortFields)
        ADDRESS_CurrentData.SortDir = CType(ViewState("ADDRESS_CurrentSortDir"),SortDirections)
        ADDRESS_Current.DataSource = ADDRESS_CurrentData.GetResultSet(ADDRESS_CurrentOperations)
        ADDRESS_Current.DataBind()
'End Report Form ADDRESS_Current BeforeShow tail

	End Sub 'Report ADDRESS_Current Bind tail @121-E31F8E2A

'Report ADDRESS_Current Table Parameters @121-D91E4C8C

    Protected Sub ADDRESS_CurrentParameters()
        Try
            ADDRESS_CurrentData.Expr144 = FloatParameter.GetParam(viewStudentSummary_DetailCURR_RESID_ADDRESS_ID.Text, ParameterSourceType.Expression, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=ADDRESS_Current.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ADDRESS_Current)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ADDRESS_Current: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report ADDRESS_Current Table Parameters

'Report ADDRESS_Current BeforeShowSection event @121-ABF0E6F8
    Protected Sub ADDRESS_CurrentBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As ADDRESS_CurrentItem  = CType(e.Item.DataItem, ADDRESS_CurrentItem)
        Dim Item As ADDRESS_CurrentItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New ADDRESS_CurrentItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim ADDRESS_CurrentADDRESSEE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentADDRESSEE"),ReportLabel)
                Dim ADDRESS_CurrentAGENT As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentAGENT"),ReportLabel)
                Dim ADDRESS_CurrentADDR1 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentADDR1"),ReportLabel)
                Dim ADDRESS_CurrentADDR2 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentADDR2"),ReportLabel)
                Dim ADDRESS_CurrentSUBURB_TOWN As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentSUBURB_TOWN"),ReportLabel)
                Dim ADDRESS_CurrentSTATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentSTATE"),ReportLabel)
                Dim ADDRESS_CurrentPOSTCODE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentPOSTCODE"),ReportLabel)
                Dim ADDRESS_CurrentCOUNTRY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentCOUNTRY"),ReportLabel)
                Dim ADDRESS_CurrentPHONE_A As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentPHONE_A"),ReportLabel)
                Dim ADDRESS_CurrentPHONE_B As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentPHONE_B"),ReportLabel)
                Dim ADDRESS_CurrentFAX As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentFAX"),ReportLabel)
                Dim ADDRESS_CurrentEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_CurrentEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_CurrentLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentLAST_ALTERED_BY"),ReportLabel)
                Dim ADDRESS_CurrentLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentLAST_ALTERED_DATE"),ReportLabel)
                Dim ADDRESS_CurrentADDRESS_ID As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_CurrentADDRESS_ID"),ReportLabel)
                Dim ADDRESS_CurrentImageLink_GoogleMaps_current As System.Web.UI.WebControls.HyperLink = DirectCast(e.Item.FindControl("ADDRESS_CurrentImageLink_GoogleMaps_current"),System.Web.UI.WebControls.HyperLink)
                ADDRESS_CurrentEMAIL_ADDRESS.HRef = "mailto:" + DataItem.EMAIL_ADDRESSHref & DataItem.EMAIL_ADDRESSHrefParameters.ToString("None","", ViewState)
                DataItem.ImageLink_GoogleMaps_currentHref = "http://maps.google.com.au/maps?f=q&source=s_q&hl=en&geocode=&ie=UTF8&z=14"
                ADDRESS_CurrentImageLink_GoogleMaps_current.ImageUrl += DataItem.ImageLink_GoogleMaps_current.GetFormattedValue()
                ADDRESS_CurrentImageLink_GoogleMaps_current.NavigateUrl += DataItem.ImageLink_GoogleMaps_currentHref & DataItem.ImageLink_GoogleMaps_currentHrefParameters.ToString("None","", ViewState).Replace("&amp;", "&")
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report ADDRESS_Current BeforeShowSection event

		Select e.Item.name 'BeforeShow events @121-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @124-D5562AB6

'Get EMAIL_ADDRESS control @136-41AD33DD
                Dim ADDRESS_CurrentEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_CurrentEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS control

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @242-73254650
    ' -------------------------
    ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	DataItem.email_addresshrefparameters.add("subject",("<insert subject>").ToString())
	if not IsDBNull(dataitem.email_addresshref) then
		ADDRESS_CurrentEMAIL_ADDRESS.HRef = "mailto:" + trim(DataItem.email_addresshref) & DataItem.email_addresshrefparameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL  	DataItem.email_address2hrefparameters.add("subject",("<insert subject>").ToString())
'DEL  	if not IsDBNull(item.email_address2href) then
'DEL  		ADDRESS_CurrentEMAIL_ADDRESS2.HRef = "mailto:" + trim(DataItem.email_address2href) & DataItem.email_address2hrefparameters.tostring("None","", ViewState)
'DEL  	end if
'DEL      ' -------------------------


'Get ImageLink_GoogleMaps_current control @335-05D2784D
                Dim ADDRESS_CurrentImageLink_GoogleMaps_current As System.Web.UI.WebControls.HyperLink = DirectCast(e.Item.FindControl("ADDRESS_CurrentImageLink_GoogleMaps_current"),System.Web.UI.WebControls.HyperLink)
'End Get ImageLink_GoogleMaps_current control

'ImageLink ImageLink_GoogleMaps_current Event BeforeShow. Action Custom Code @336-73254650
    ' -------------------------
    ' ERA: 23-Aug-2010|EA| append address 1+2, town, postcode to google map icon
	'ADDRESS_CurrentImageLink_GoogleMaps_current
	dim tmpFlagShowMap as boolean = true
	dim tmpAddressForMaps as string = ""

	tmpAddressForMaps = Dataitem.ADDR1.GetFormattedValue().Trim()

	if (DataItem.ADDR2.GetFormattedValue() <> "") then 
		tmpAddressForMaps += " " + DataItem.ADDR2.GetFormattedValue().Trim()
	end if

	if (DataItem.SUBURB_TOWN.GetFormattedValue() <> "") then 
		tmpAddressForMaps += "," + DataItem.SUBURB_TOWN.GetFormattedValue().Trim()
	else
		tmpFlagShowMap = false
	end if 
	
	if (DataItem.POSTCODE.GetFormattedValue() <> "") then 
		tmpAddressForMaps += "," + DataItem.POSTCODE.GetFormattedValue().Trim()
	else
		tmpFlagShowMap = false
	end if 

	if (DataItem.COUNTRY.GetFormattedValue() <> "AUSTRALIA") then 
		tmpAddressForMaps += "," + DataItem.COUNTRY.GetFormattedValue().Trim()
	end if 

	tmpAddressForMaps=tmpAddressForMaps.replace(" ", "+")

	if (tmpAddressForMaps="") or (tmpFlagShowMap = false) then
		ADDRESS_CurrentImageLink_GoogleMaps_current.visible = false
	else
		ADDRESS_CurrentImageLink_GoogleMaps_current.NavigateUrl += "&q=" + tmpAddressForMaps.tostring()
	end if

    ' -------------------------
'End ImageLink ImageLink_GoogleMaps_current Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @121-3508C6CC

    End Sub 'Section ADDRESS_Current BeforeShow events tail @121-E31F8E2A

'Report ADDRESS_Current ItemCommand event @121-9A439D33
    Protected Sub ADDRESS_CurrentItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ADDRESS_CurrentSortDir"),SortDirections) = SortDirections._Asc And ViewState("ADDRESS_CurrentSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ADDRESS_CurrentSortDir")=SortDirections._Desc
                Else
                    ViewState("ADDRESS_CurrentSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ADDRESS_CurrentSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ADDRESS_CurrentDataProvider.SortFields = 0
            ViewState("ADDRESS_CurrentSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ADDRESS_CurrentPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ADDRESS_Current.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ADDRESS_CurrentBind
        End If
    End Sub
'End Report ADDRESS_Current ItemCommand event

'Report STUDENT_CENSUS_DATA Bind @85-A2C394D9
    Protected Sub STUDENT_CENSUS_DATABind()
        If Not STUDENT_CENSUS_DATAOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CENSUS_DATA",GetType(STUDENT_CENSUS_DATADataProvider.SortFields), 0, 100)
        End If
'End Report STUDENT_CENSUS_DATA Bind

'Report Form STUDENT_CENSUS_DATA BeforeShow tail @85-9184559D
        STUDENT_CENSUS_DATAParameters
        STUDENT_CENSUS_DATAData.SortField = CType(ViewState("STUDENT_CENSUS_DATASortField"),STUDENT_CENSUS_DATADataProvider.SortFields)
        STUDENT_CENSUS_DATAData.SortDir = CType(ViewState("STUDENT_CENSUS_DATASortDir"),SortDirections)
        STUDENT_CENSUS_DATA.DataSource = STUDENT_CENSUS_DATAData.GetResultSet(STUDENT_CENSUS_DATAOperations)
        STUDENT_CENSUS_DATA.DataBind()
'End Report Form STUDENT_CENSUS_DATA BeforeShow tail

	End Sub 'Report STUDENT_CENSUS_DATA Bind tail @85-E31F8E2A

'Report STUDENT_CENSUS_DATA Table Parameters @85-A227CF71

    Protected Sub STUDENT_CENSUS_DATAParameters()
        Try
            STUDENT_CENSUS_DATAData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CENSUS_DATA.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CENSUS_DATA)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CENSUS_DATA: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report STUDENT_CENSUS_DATA Table Parameters

'Report STUDENT_CENSUS_DATA BeforeShowSection event @85-C37E211E
    Protected Sub STUDENT_CENSUS_DATABeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As STUDENT_CENSUS_DATAItem  = CType(e.Item.DataItem, STUDENT_CENSUS_DATAItem)
        Dim Item As STUDENT_CENSUS_DATAItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New STUDENT_CENSUS_DATAItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH"),ReportLabel)
                Dim STUDENT_CENSUS_DATADATE_STARTED_IN_AUST As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATADATE_STARTED_IN_AUST"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAMOTHERS_COB As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAMOTHERS_COB"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFATHERS_COB As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFATHERS_COB"),ReportLabel)
                Dim STUDENT_CENSUS_DATAMOTHER_LANGUAGE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAMOTHER_LANGUAGE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFATHER_LANGUAGE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFATHER_LANGUAGE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL"),ReportLabel)
                Dim STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL"),ReportLabel)
                Dim STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP"),ReportLabel)
                Dim STUDENT_CENSUS_DATAALLOWANCE_TITLE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAALLOWANCE_TITLE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAKOORITORRESFLAG As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAKOORITORRESFLAG"),ReportLabel)
                Dim STUDENT_CENSUS_DATARESIDENTIAL_STATUS As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATARESIDENTIAL_STATUS"),ReportLabel)
                Dim STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST"),ReportLabel)
                Dim STUDENT_CENSUS_DATAVISA_SUB_CLASS As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAVISA_SUB_CLASS"),ReportLabel)
                Dim STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE"),ReportLabel)
                Dim STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID"),ReportLabel)
                Dim STUDENT_CENSUS_DATAFAMILY_OSG As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAFAMILY_OSG"),ReportLabel)
                Dim STUDENT_CENSUS_DATAHOUSEHOLD_STATUS As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAHOUSEHOLD_STATUS"),ReportLabel)
                Dim STUDENT_CENSUS_DATADISABILITY_ID As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATADISABILITY_ID"),ReportLabel)
                Dim STUDENT_CENSUS_DATAREPEATING_YEAR As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAREPEATING_YEAR"),ReportLabel)
                Dim STUDENT_CENSUS_DATAOTHER_SCHOOL_TF As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATAOTHER_SCHOOL_TF"),ReportLabel)
                Dim STUDENT_CENSUS_DATALAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATALAST_ALTERED_BY"),ReportLabel)
                Dim STUDENT_CENSUS_DATALAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATALAST_ALTERED_DATE"),ReportLabel)
                Dim STUDENT_CENSUS_DATASTUDENT_ID As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_CENSUS_DATASTUDENT_ID"),ReportLabel)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report STUDENT_CENSUS_DATA BeforeShowSection event



    End Sub 'Section STUDENT_CENSUS_DATA BeforeShow events tail @85-E31F8E2A

'Report STUDENT_CENSUS_DATA ItemCommand event @85-FB84F20D
    Protected Sub STUDENT_CENSUS_DATAItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CENSUS_DATASortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CENSUS_DATASortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CENSUS_DATASortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CENSUS_DATASortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CENSUS_DATASortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CENSUS_DATADataProvider.SortFields = 0
            ViewState("STUDENT_CENSUS_DATASortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CENSUS_DATAPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            STUDENT_CENSUS_DATA.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CENSUS_DATABind
        End If
    End Sub
'End Report STUDENT_CENSUS_DATA ItemCommand event

'Report STUDENT_EQUIPMENT Bind @150-69B3B8CA
    Protected Sub STUDENT_EQUIPMENTBind()
        If Not STUDENT_EQUIPMENTOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_EQUIPMENT",GetType(STUDENT_EQUIPMENTDataProvider.SortFields), 0, 100)
        End If
'End Report STUDENT_EQUIPMENT Bind

'Report Form STUDENT_EQUIPMENT BeforeShow tail @150-DC107DF5
        STUDENT_EQUIPMENTParameters
        STUDENT_EQUIPMENTData.SortField = CType(ViewState("STUDENT_EQUIPMENTSortField"),STUDENT_EQUIPMENTDataProvider.SortFields)
        STUDENT_EQUIPMENTData.SortDir = CType(ViewState("STUDENT_EQUIPMENTSortDir"),SortDirections)
        STUDENT_EQUIPMENT.DataSource = STUDENT_EQUIPMENTData.GetResultSet(STUDENT_EQUIPMENTOperations)
        STUDENT_EQUIPMENT.DataBind()
'End Report Form STUDENT_EQUIPMENT BeforeShow tail

'Report STUDENT_EQUIPMENT Event BeforeShow. Action Hide-Show Component @528-F125EB7F
        If 1=1 Then
            STUDENT_EQUIPMENT.Visible = False
        End If
'End Report STUDENT_EQUIPMENT Event BeforeShow. Action Hide-Show Component

	End Sub 'Report STUDENT_EQUIPMENT Bind tail @150-E31F8E2A

'Report STUDENT_EQUIPMENT Table Parameters @150-ECDFB92B

    Protected Sub STUDENT_EQUIPMENTParameters()
        Try
            STUDENT_EQUIPMENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_EQUIPMENT.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_EQUIPMENT)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_EQUIPMENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report STUDENT_EQUIPMENT Table Parameters

'Report STUDENT_EQUIPMENT BeforeShowSection event @150-62260476
    Protected Sub STUDENT_EQUIPMENTBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As STUDENT_EQUIPMENTItem  = CType(e.Item.DataItem, STUDENT_EQUIPMENTItem)
        Dim Item As STUDENT_EQUIPMENTItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New STUDENT_EQUIPMENTItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim STUDENT_EQUIPMENTLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_EQUIPMENTLAST_ALTERED_BY"),ReportLabel)
                Dim STUDENT_EQUIPMENTLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_EQUIPMENTLAST_ALTERED_DATE"),ReportLabel)
                Dim STUDENT_EQUIPMENTSTUDENT_ID As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_EQUIPMENTSTUDENT_ID"),ReportLabel)
                Dim STUDENT_EQUIPMENTHAS_DER_PC As ReportLabel = DirectCast(e.Item.FindControl("STUDENT_EQUIPMENTHAS_DER_PC"),ReportLabel)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report STUDENT_EQUIPMENT BeforeShowSection event

    End Sub 'Section STUDENT_EQUIPMENT BeforeShow events tail @150-E31F8E2A

'Report STUDENT_EQUIPMENT ItemCommand event @150-F5951BE7
    Protected Sub STUDENT_EQUIPMENTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_EQUIPMENTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_EQUIPMENTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_EQUIPMENTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_EQUIPMENTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_EQUIPMENTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_EQUIPMENTDataProvider.SortFields = 0
            ViewState("STUDENT_EQUIPMENTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_EQUIPMENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            STUDENT_EQUIPMENT.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_EQUIPMENTBind
        End If
    End Sub
'End Report STUDENT_EQUIPMENT ItemCommand event

'Report viewStudentSummary_Medica Bind @167-05EC5B54
    Protected Sub viewStudentSummary_MedicaBind()
        If Not viewStudentSummary_MedicaOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"viewStudentSummary_Medica",GetType(viewStudentSummary_MedicaDataProvider.SortFields), 0, 100)
        End If
'End Report viewStudentSummary_Medica Bind

'Report Form viewStudentSummary_Medica BeforeShow tail @167-B3ABD178
        viewStudentSummary_MedicaParameters
        viewStudentSummary_MedicaData.SortField = CType(ViewState("viewStudentSummary_MedicaSortField"),viewStudentSummary_MedicaDataProvider.SortFields)
        viewStudentSummary_MedicaData.SortDir = CType(ViewState("viewStudentSummary_MedicaSortDir"),SortDirections)
        viewStudentSummary_Medica.DataSource = viewStudentSummary_MedicaData.GetResultSet(viewStudentSummary_MedicaOperations)
        viewStudentSummary_Medica.DataBind()
'End Report Form viewStudentSummary_Medica BeforeShow tail

	End Sub 'Report viewStudentSummary_Medica Bind tail @167-E31F8E2A

'Report viewStudentSummary_Medica Table Parameters @167-C4B957CD

    Protected Sub viewStudentSummary_MedicaParameters()
        Try
            viewStudentSummary_MedicaData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewStudentSummary_Medica.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewStudentSummary_Medica)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewStudentSummary_Medica: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report viewStudentSummary_Medica Table Parameters

'Report viewStudentSummary_Medica BeforeShowSection event @167-76924506
    Protected Sub viewStudentSummary_MedicaBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As viewStudentSummary_MedicaItem  = CType(e.Item.DataItem, viewStudentSummary_MedicaItem)
        Dim Item As viewStudentSummary_MedicaItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New viewStudentSummary_MedicaItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim viewStudentSummary_Medicaimmun_certificate_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_certificate_desc"),ReportLabel)
                Dim viewStudentSummary_MedicaLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaLAST_ALTERED_BY"),ReportLabel)
                Dim viewStudentSummary_MedicaLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaLAST_ALTERED_DATE"),ReportLabel)
                Dim viewStudentSummary_Medicaallergies_flag_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaallergies_flag_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaanaphylaxis_flag_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaanaphylaxis_flag_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaanaphylaxis_warning As System.Web.UI.WebControls.Image = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaanaphylaxis_warning"),System.Web.UI.WebControls.Image)
                Dim viewStudentSummary_MedicaSTUDENT_ID As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaSTUDENT_ID"),ReportLabel)
                Dim viewStudentSummary_Medicaimmun_diptheria_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_diptheria_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaimmun_tetanus_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_tetanus_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaimmun_polio_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_polio_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaimmun_measles_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_measles_desc"),ReportLabel)
                Dim viewStudentSummary_Medicaimmun_mumps_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaimmun_mumps_desc"),ReportLabel)
                Dim viewStudentSummary_MedicaDIAGNOSED_CONDITION As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaDIAGNOSED_CONDITION"),ReportLabel)
                Dim viewStudentSummary_MedicaHASOTHERCONDITIONS_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaHASOTHERCONDITIONS_desc"),ReportLabel)
                Dim viewStudentSummary_MedicaOTHERCONDITIONS As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_MedicaOTHERCONDITIONS"),ReportLabel)
                Dim viewStudentSummary_Medicaall_medical_conditions_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaall_medical_conditions_desc"),ReportLabel)
                viewStudentSummary_Medicaanaphylaxis_warning.ImageUrl += DataItem.anaphylaxis_warning.GetFormattedValue()
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report viewStudentSummary_Medica BeforeShowSection event

		Select e.Item.name 'BeforeShow events @167-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @170-D5562AB6

'Get anaphylaxis_warning control @292-6D157F1E
                Dim viewStudentSummary_Medicaanaphylaxis_warning As System.Web.UI.WebControls.Image = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaanaphylaxis_warning"),System.Web.UI.WebControls.Image)
'End Get anaphylaxis_warning control

'Image anaphylaxis_warning Event BeforeShow. Action Custom Code @297-73254650
    ' -------------------------
    ' ERA: Oct 2009|EA| make the warning image Visible if the Anaphylaxis = 'Yes'
	if (item.anaphylaxis_flag_desc.getformattedvalue()="Yes")
		viewStudentSummary_Medicaanaphylaxis_warning.ImageUrl ="images/warning.png"
		viewStudentSummary_Medicaanaphylaxis_warning.Visible = True
	else
		viewStudentSummary_Medicaanaphylaxis_warning.Visible = False
	End If
    ' -------------------------
'End Image anaphylaxis_warning Event BeforeShow. Action Custom Code

'Get all_medical_conditions_desc control @509-2F6EF2C9
                Dim viewStudentSummary_Medicaall_medical_conditions_desc As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Medicaall_medical_conditions_desc"),ReportLabel)
'End Get all_medical_conditions_desc control

'ReportLabel all_medical_conditions_desc Event BeforeShow. Action Retrieve Value for Control @510-E0C51F17
                viewStudentSummary_Medicaall_medical_conditions_desc.Text = (New TextField("", (viewStudentSummary_Medicaall_medical_conditions_desc.Text.Replace("|","<br>")))).GetFormattedValue()
'End ReportLabel all_medical_conditions_desc Event BeforeShow. Action Retrieve Value for Control

		End Select 'BeforeShow events @167-3508C6CC

    End Sub 'Section viewStudentSummary_Medica BeforeShow events tail @167-E31F8E2A

'Report viewStudentSummary_Medica ItemCommand event @167-BC271D90
    Protected Sub viewStudentSummary_MedicaItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewStudentSummary_MedicaSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewStudentSummary_MedicaSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewStudentSummary_MedicaSortDir")=SortDirections._Desc
                Else
                    ViewState("viewStudentSummary_MedicaSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewStudentSummary_MedicaSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewStudentSummary_MedicaDataProvider.SortFields = 0
            ViewState("viewStudentSummary_MedicaSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewStudentSummary_MedicaPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            viewStudentSummary_Medica.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewStudentSummary_MedicaBind
        End If
    End Sub
'End Report viewStudentSummary_Medica ItemCommand event

'Report ADDRESS_Original Bind @248-8A3B4F24
    Protected Sub ADDRESS_OriginalBind()
        If Not ADDRESS_OriginalOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"ADDRESS_Original",GetType(ADDRESS_OriginalDataProvider.SortFields), 0, 100)
        End If
'End Report ADDRESS_Original Bind

'Report Form ADDRESS_Original BeforeShow tail @248-171D6350
        ADDRESS_OriginalParameters
        ADDRESS_OriginalData.SortField = CType(ViewState("ADDRESS_OriginalSortField"),ADDRESS_OriginalDataProvider.SortFields)
        ADDRESS_OriginalData.SortDir = CType(ViewState("ADDRESS_OriginalSortDir"),SortDirections)
        ADDRESS_Original.DataSource = ADDRESS_OriginalData.GetResultSet(ADDRESS_OriginalOperations)
        ADDRESS_Original.DataBind()
'End Report Form ADDRESS_Original BeforeShow tail

	End Sub 'Report ADDRESS_Original Bind tail @248-E31F8E2A

'Report ADDRESS_Original Table Parameters @248-01779EBE

    Protected Sub ADDRESS_OriginalParameters()
        Try
            ADDRESS_OriginalData.Expr273 = FloatParameter.GetParam(viewStudentSummary_DetailORIG_RESID_ADDRESS_ID.Text, ParameterSourceType.Expression, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=ADDRESS_Original.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ADDRESS_Original)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ADDRESS_Original: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report ADDRESS_Original Table Parameters

'Report ADDRESS_Original BeforeShowSection event @248-FA2F0535
    Protected Sub ADDRESS_OriginalBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As ADDRESS_OriginalItem  = CType(e.Item.DataItem, ADDRESS_OriginalItem)
        Dim Item As ADDRESS_OriginalItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New ADDRESS_OriginalItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim ADDRESS_OriginalADDRESSEE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalADDRESSEE"),ReportLabel)
                Dim ADDRESS_OriginalAGENT As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalAGENT"),ReportLabel)
                Dim ADDRESS_OriginalADDR1 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalADDR1"),ReportLabel)
                Dim ADDRESS_OriginalADDR2 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalADDR2"),ReportLabel)
                Dim ADDRESS_OriginalSUBURB_TOWN As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalSUBURB_TOWN"),ReportLabel)
                Dim ADDRESS_OriginalSTATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalSTATE"),ReportLabel)
                Dim ADDRESS_OriginalPOSTCODE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalPOSTCODE"),ReportLabel)
                Dim ADDRESS_OriginalCOUNTRY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalCOUNTRY"),ReportLabel)
                Dim ADDRESS_OriginalPHONE_A As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalPHONE_A"),ReportLabel)
                Dim ADDRESS_OriginalPHONE_B As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalPHONE_B"),ReportLabel)
                Dim ADDRESS_OriginalFAX As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalFAX"),ReportLabel)
                Dim ADDRESS_OriginalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_OriginalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_OriginalEMAIL_ADDRESS2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_OriginalEMAIL_ADDRESS2"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_OriginalLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalLAST_ALTERED_BY"),ReportLabel)
                Dim ADDRESS_OriginalLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalLAST_ALTERED_DATE"),ReportLabel)
                Dim ADDRESS_OriginalADDRESS_ID As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_OriginalADDRESS_ID"),ReportLabel)
                ADDRESS_OriginalEMAIL_ADDRESS.HRef = "mailto:" + DataItem.EMAIL_ADDRESSHref & DataItem.EMAIL_ADDRESSHrefParameters.ToString("None","", ViewState)
                ADDRESS_OriginalEMAIL_ADDRESS2.HRef = "mailto:" + DataItem.EMAIL_ADDRESS2Href & DataItem.EMAIL_ADDRESS2HrefParameters.ToString("None","", ViewState)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report ADDRESS_Original BeforeShowSection event

		Select e.Item.name 'BeforeShow events @248-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @251-D5562AB6

'Get EMAIL_ADDRESS control @263-498E8369
                Dim ADDRESS_OriginalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_OriginalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS control

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @264-73254650
    ' -------------------------
    ' ERA: May-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	DataItem.email_addresshrefparameters.add("subject",("<insert subject>").ToString())
	if not IsDBNull(dataitem.email_addresshref) then
		ADDRESS_OriginalEMAIL_ADDRESS.HRef = "mailto:" + trim(DataItem.email_addresshref) & DataItem.email_addresshrefparameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'Get EMAIL_ADDRESS2 control @265-AF03F333
                Dim ADDRESS_OriginalEMAIL_ADDRESS2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_OriginalEMAIL_ADDRESS2"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS2 control

'Link EMAIL_ADDRESS2 Event BeforeShow. Action Custom Code @266-73254650
    ' -------------------------
    ' ERA: May-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	DataItem.email_address2hrefparameters.add("subject",("<insert subject>").ToString())
	if not IsDBNull(dataitem.email_address2href) then
		ADDRESS_OriginalEMAIL_ADDRESS2.HRef = "mailto:" + trim(DataItem.email_address2href) & DataItem.email_address2hrefparameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS2 Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @248-3508C6CC

    End Sub 'Section ADDRESS_Original BeforeShow events tail @248-E31F8E2A

'Report ADDRESS_Original ItemCommand event @248-EF3F88CC
    Protected Sub ADDRESS_OriginalItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ADDRESS_OriginalSortDir"),SortDirections) = SortDirections._Asc And ViewState("ADDRESS_OriginalSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ADDRESS_OriginalSortDir")=SortDirections._Desc
                Else
                    ViewState("ADDRESS_OriginalSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ADDRESS_OriginalSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ADDRESS_OriginalDataProvider.SortFields = 0
            ViewState("ADDRESS_OriginalSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ADDRESS_OriginalPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ADDRESS_Original.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ADDRESS_OriginalBind
        End If
    End Sub
'End Report ADDRESS_Original ItemCommand event

'Grid view_StudentSummary_Alert Bind @314-B51839B2

    Protected Sub view_StudentSummary_AlertBind()
        If Not view_StudentSummary_AlertOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"view_StudentSummary_Alert",GetType(view_StudentSummary_AlertDataProvider.SortFields), 12, 12)
        End If
'End Grid view_StudentSummary_Alert Bind

'Grid Form view_StudentSummary_Alert BeforeShow tail @314-24ED1648
        view_StudentSummary_AlertParameters()
        view_StudentSummary_AlertData.SortField = CType(ViewState("view_StudentSummary_AlertSortField"),view_StudentSummary_AlertDataProvider.SortFields)
        view_StudentSummary_AlertData.SortDir = CType(ViewState("view_StudentSummary_AlertSortDir"),SortDirections)
        view_StudentSummary_AlertData.PageNumber = CInt(ViewState("view_StudentSummary_AlertPageNumber"))
        view_StudentSummary_AlertData.RecordsPerPage = CInt(ViewState("view_StudentSummary_AlertPageSize"))
        view_StudentSummary_AlertRepeater.DataSource = view_StudentSummary_AlertData.GetResultSet(PagesCount, view_StudentSummary_AlertOperations)
        ViewState("view_StudentSummary_AlertPagesCount") = PagesCount
        Dim item As view_StudentSummary_AlertItem = New view_StudentSummary_AlertItem()
        CType(Page,CCPage).ControlAttributes.Add(view_StudentSummary_AlertRepeater,New CCSControlAttribute("numberOfColumns", FieldType._Text, (4)))
        view_StudentSummary_AlertRepeater.DataBind
        FooterIndex = view_StudentSummary_AlertRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            view_StudentSummary_AlertRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form view_StudentSummary_Alert BeforeShow tail

'Grid view_StudentSummary_Alert Event BeforeShow. Action Custom Code @326-73254650
    ' -------------------------
    ' ERA: 13-Aug-2010|EA| new Alerts banner - if nothing then don't show it
	If PagesCount = 0 Then 
    	view_StudentSummary_AlertRepeater.Visible = False
	End if

    ' -------------------------
'End Grid view_StudentSummary_Alert Event BeforeShow. Action Custom Code

'Grid view_StudentSummary_Alert Bind tail @314-E31F8E2A
    End Sub
'End Grid view_StudentSummary_Alert Bind tail

'Grid view_StudentSummary_Alert Table Parameters @314-CEE75C62

    Protected Sub view_StudentSummary_AlertParameters()
        Try
            view_StudentSummary_AlertData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=view_StudentSummary_AlertRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(view_StudentSummary_AlertRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid view_StudentSummary_Alert: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid view_StudentSummary_Alert Table Parameters

'Grid view_StudentSummary_Alert ItemDataBound event @314-4A929877

    Protected Sub view_StudentSummary_AlertItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as view_StudentSummary_AlertItem = CType(e.Item.DataItem,view_StudentSummary_AlertItem)
        Dim Item as view_StudentSummary_AlertItem = DataItem
        Dim FormDataSource As view_StudentSummary_AlertItem() = CType(view_StudentSummary_AlertRepeater.DataSource, view_StudentSummary_AlertItem())
        Dim view_StudentSummary_AlertDataRows As Integer = FormDataSource.Length
        Dim view_StudentSummary_AlertIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            view_StudentSummary_AlertCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(view_StudentSummary_AlertRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, view_StudentSummary_AlertCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim view_StudentSummary_AlertRowOpenTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("view_StudentSummary_AlertRowOpenTag"),System.Web.UI.WebControls.PlaceHolder)
            Dim view_StudentSummary_AlertRowComponents As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("view_StudentSummary_AlertRowComponents"),System.Web.UI.WebControls.PlaceHolder)
            Dim view_StudentSummary_AlertCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_StudentSummary_AlertCOMMENT_TYPE"),System.Web.UI.WebControls.Literal)
            Dim view_StudentSummary_AlertComment As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_StudentSummary_AlertComment"),System.Web.UI.WebControls.Literal)
            Dim view_StudentSummary_AlertlblDate_Updated As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_StudentSummary_AlertlblDate_Updated"),System.Web.UI.WebControls.Literal)
            Dim view_StudentSummary_AlertRowCloseTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("view_StudentSummary_AlertRowCloseTag"),System.Web.UI.WebControls.PlaceHolder)
        End If
'End Grid view_StudentSummary_Alert ItemDataBound event

'Grid view_StudentSummary_Alert BeforeShowRow event @314-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid view_StudentSummary_Alert BeforeShowRow event

'Grid view_StudentSummary_Alert Event BeforeShowRow. Action Gallery Layout @320-32A3EE58
            Utility.ManageGalleryPanels(e.Item, CInt(CType(Page,CCPage).ControlAttributes.GetAttribute("view_StudentSummary_AlertRepeater","numberOfColumns")), view_StudentSummary_AlertCurrentRowNumber, view_StudentSummary_AlertData.RecordsPerPage, "view_StudentSummary_AlertRowOpenTag", "view_StudentSummary_AlertRowCloseTag", "view_StudentSummary_AlertRowComponents", view_StudentSummary_AlertDataRows, view_StudentSummary_AlertIsForceIteration)
'End Grid view_StudentSummary_Alert Event BeforeShowRow. Action Gallery Layout

'Grid view_StudentSummary_Alert Event BeforeShowRow. Action Custom Code @446-73254650
    ' -------------------------
    '14-Feb-2013|EA| make different colours depending on Alert type
	'Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("view_StudentSummary_Alert_row"),System.Web.UI.HtmlControls.HtmlTableRow)
'  	if (DataItem.comment_type.value="ALERT") Then
'        comment_row.Attributes("Class") = "AlertRed"
'  	elseif (DataItem.comment_type.value="RESTRICTED") Then
'       comment_row.Attributes("Class") = "AlertRed" 
' 	elseif (DataItem.comment_type.value="WELLBEING") Then
'       comment_row.Attributes("Class") = "AlertGreen"
'   End if 

    ' -------------------------
'End Grid view_StudentSummary_Alert Event BeforeShowRow. Action Custom Code


'Grid view_StudentSummary_Alert BeforeShowRow event tail @314-477CF3C9
        End If
'End Grid view_StudentSummary_Alert BeforeShowRow event tail

'Grid view_StudentSummary_Alert ItemDataBound event tail @314-ECCABACB
        If view_StudentSummary_AlertIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(view_StudentSummary_AlertCurrentRowNumber, ListItemType.Item)
            view_StudentSummary_AlertRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            view_StudentSummary_AlertItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid view_StudentSummary_Alert ItemDataBound event tail

'Grid view_StudentSummary_Alert ItemCommand event @314-BC42A3FF

    Protected Sub view_StudentSummary_AlertItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= view_StudentSummary_AlertRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("view_StudentSummary_AlertSortDir"),SortDirections) = SortDirections._Asc And ViewState("view_StudentSummary_AlertSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("view_StudentSummary_AlertSortDir")=SortDirections._Desc
                Else
                    ViewState("view_StudentSummary_AlertSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("view_StudentSummary_AlertSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As view_StudentSummary_AlertDataProvider.SortFields = 0
            ViewState("view_StudentSummary_AlertSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("view_StudentSummary_AlertPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("view_StudentSummary_AlertPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("view_StudentSummary_AlertPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("view_StudentSummary_AlertPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            view_StudentSummary_AlertBind
        End If
    End Sub
'End Grid view_StudentSummary_Alert ItemCommand event

'Grid STUDENT_CARER_CONTACT Bind @342-040AEE34

    Protected Sub STUDENT_CARER_CONTACTBind()
        If Not STUDENT_CARER_CONTACTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT",GetType(STUDENT_CARER_CONTACTDataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT Bind

'Grid Form STUDENT_CARER_CONTACT BeforeShow tail @342-756F59E5
        STUDENT_CARER_CONTACTParameters()
        STUDENT_CARER_CONTACTData.SortField = CType(ViewState("STUDENT_CARER_CONTACTSortField"),STUDENT_CARER_CONTACTDataProvider.SortFields)
        STUDENT_CARER_CONTACTData.SortDir = CType(ViewState("STUDENT_CARER_CONTACTSortDir"),SortDirections)
        STUDENT_CARER_CONTACTData.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACTPageNumber"))
        STUDENT_CARER_CONTACTData.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACTPageSize"))
        STUDENT_CARER_CONTACTRepeater.DataSource = STUDENT_CARER_CONTACTData.GetResultSet(PagesCount, STUDENT_CARER_CONTACTOperations)
        ViewState("STUDENT_CARER_CONTACTPagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        STUDENT_CARER_CONTACTRepeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form STUDENT_CARER_CONTACT BeforeShow tail

'Grid STUDENT_CARER_CONTACT Bind tail @342-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT Bind tail

'Grid STUDENT_CARER_CONTACT Table Parameters @342-6D9B2426

    Protected Sub STUDENT_CARER_CONTACTParameters()
        Try
            STUDENT_CARER_CONTACTData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT Table Parameters

'Grid STUDENT_CARER_CONTACT ItemDataBound event @342-B7CEC2A2

    Protected Sub STUDENT_CARER_CONTACTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACTItem = CType(e.Item.DataItem,STUDENT_CARER_CONTACTItem)
        Dim Item as STUDENT_CARER_CONTACTItem = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACTItem() = CType(STUDENT_CARER_CONTACTRepeater.DataSource, STUDENT_CARER_CONTACTItem())
        Dim STUDENT_CARER_CONTACTDataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACTCARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTCARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTTITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTTITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTRELATIONSHIP As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTRELATIONSHIP"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STUDENT_CARER_CONTACTHOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTHOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTWORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTWORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTMOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTMOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTEMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTEMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACTSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTSURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACTRELATIONSHIP.Items.Add(new ListItem("Select Value",""))
            STUDENT_CARER_CONTACTRELATIONSHIP.Items(0).Selected = True
            DataItem.RELATIONSHIPItems.SetSelection(DataItem.RELATIONSHIP.GetFormattedValue())
            If Not DataItem.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
                STUDENT_CARER_CONTACTRELATIONSHIP.SelectedIndex = -1
            End If
            DataItem.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACTRELATIONSHIP.Items)
            STUDENT_CARER_CONTACTEMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT ItemDataBound event

'STUDENT_CARER_CONTACT control Before Show @342-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT control Before Show

'Get Control @349-14865EBD
            Dim STUDENT_CARER_CONTACTEMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTEMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL Event BeforeShow. Action Custom Code @350-73254650
    ' -------------------------
    'NOTE Form name ...Contact
    '4-Mar-2019|EA| change DECV to VSV after name change (unf #848)
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding Virtual School Victoria Student").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACTEMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if
    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT control Before Show tail @342-477CF3C9
        End If
'End STUDENT_CARER_CONTACT control Before Show tail

'Grid STUDENT_CARER_CONTACT ItemDataBound event tail @342-C1013562
        If STUDENT_CARER_CONTACTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACTCurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT ItemCommand event @342-0CA7373B

    Protected Sub STUDENT_CARER_CONTACTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACTDataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACTBind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT ItemCommand event

'Grid STUDENT_CARER_CONTACT1 Bind @362-1F123A14

    Protected Sub STUDENT_CARER_CONTACT1Bind()
        If Not STUDENT_CARER_CONTACT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT1",GetType(STUDENT_CARER_CONTACT1DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT1 Bind

'Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail @362-7700E431
        STUDENT_CARER_CONTACT1Parameters()
        STUDENT_CARER_CONTACT1Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT1SortField"),STUDENT_CARER_CONTACT1DataProvider.SortFields)
        STUDENT_CARER_CONTACT1Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections)
        STUDENT_CARER_CONTACT1Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT1PageNumber"))
        STUDENT_CARER_CONTACT1Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT1PageSize"))
        STUDENT_CARER_CONTACT1Repeater.DataSource = STUDENT_CARER_CONTACT1Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT1Operations)
        ViewState("STUDENT_CARER_CONTACT1PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
        STUDENT_CARER_CONTACT1Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail

'Grid STUDENT_CARER_CONTACT1 Bind tail @362-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Bind tail

'Grid STUDENT_CARER_CONTACT1 Table Parameters @362-6FD750E0

    Protected Sub STUDENT_CARER_CONTACT1Parameters()
        Try
            STUDENT_CARER_CONTACT1Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Table Parameters

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event @362-BFF40DBA

    Protected Sub STUDENT_CARER_CONTACT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT1Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT1Item)
        Dim Item as STUDENT_CARER_CONTACT1Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT1Item() = CType(STUDENT_CARER_CONTACT1Repeater.DataSource, STUDENT_CARER_CONTACT1Item())
        Dim STUDENT_CARER_CONTACT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT1CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1RELATIONSHIP As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1RELATIONSHIP"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACT1EMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
            STUDENT_CARER_CONTACT1RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
            STUDENT_CARER_CONTACT1RELATIONSHIP.Items(0).Selected = True
            DataItem.RELATIONSHIPItems.SetSelection(DataItem.RELATIONSHIP.GetFormattedValue())
            If Not DataItem.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
                STUDENT_CARER_CONTACT1RELATIONSHIP.SelectedIndex = -1
            End If
            DataItem.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT1RELATIONSHIP.Items)
        End If
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event

'STUDENT_CARER_CONTACT1 control Before Show @362-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT1 control Before Show

'Get Control @368-4A89D30C
            Dim STUDENT_CARER_CONTACT1EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL Event BeforeShow. Action Custom Code @369-73254650
    ' -------------------------
	' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	'NOTE Form name ...Contact1
	'4-Mar-2019|EA| change DECV to VSV after name change (unf #848)
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding Virtual School Victoria Student").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACT1EMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if
    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT1 control Before Show tail @362-477CF3C9
        End If
'End STUDENT_CARER_CONTACT1 control Before Show tail

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail @362-348AA5A8
        If STUDENT_CARER_CONTACT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT1CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT1 ItemCommand event @362-AAD04B91

    Protected Sub STUDENT_CARER_CONTACT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT1DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT1Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemCommand event

'Grid STUDENT_CARER_CONTACT2 Bind @381-4C4618C8

    Protected Sub STUDENT_CARER_CONTACT2Bind()
        If Not STUDENT_CARER_CONTACT2Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT2",GetType(STUDENT_CARER_CONTACT2DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT2 Bind

'Grid Form STUDENT_CARER_CONTACT2 BeforeShow tail @381-5CE656FC
        STUDENT_CARER_CONTACT2Parameters()
        STUDENT_CARER_CONTACT2Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT2SortField"),STUDENT_CARER_CONTACT2DataProvider.SortFields)
        STUDENT_CARER_CONTACT2Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT2SortDir"),SortDirections)
        STUDENT_CARER_CONTACT2Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT2PageNumber"))
        STUDENT_CARER_CONTACT2Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT2PageSize"))
        STUDENT_CARER_CONTACT2Repeater.DataSource = STUDENT_CARER_CONTACT2Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT2Operations)
        ViewState("STUDENT_CARER_CONTACT2PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT2Item = New STUDENT_CARER_CONTACT2Item()
        STUDENT_CARER_CONTACT2Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT2Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT2Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form STUDENT_CARER_CONTACT2 BeforeShow tail

'Grid STUDENT_CARER_CONTACT2 Bind tail @381-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Bind tail

'Grid STUDENT_CARER_CONTACT2 Table Parameters @381-DE3D0D94

    Protected Sub STUDENT_CARER_CONTACT2Parameters()
        Try
            STUDENT_CARER_CONTACT2Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
            STUDENT_CARER_CONTACT2Data.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Year(Now()), false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT2Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT2Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT2: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Table Parameters

'Grid STUDENT_CARER_CONTACT2 ItemDataBound event @381-97E6CFDC

    Protected Sub STUDENT_CARER_CONTACT2ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT2Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT2Item)
        Dim Item as STUDENT_CARER_CONTACT2Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT2Item() = CType(STUDENT_CARER_CONTACT2Repeater.DataSource, STUDENT_CARER_CONTACT2Item())
        Dim STUDENT_CARER_CONTACT2DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT2IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT2CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT2Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT2CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT2CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT2SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2SUPERVISOR_POSITION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SUPERVISOR_POSITION"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2Supervisortype As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2Supervisortype"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACT2EMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT2 ItemDataBound event

'STUDENT_CARER_CONTACT2 control Before Show @381-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT2 control Before Show

'Get Control @386-19D1C384
            Dim STUDENT_CARER_CONTACT2EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL Event BeforeShow. Action Custom Code @387-73254650
    ' -------------------------
	' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	'NOTE Form name ...Contact2
	' ERA: Sept-2013|EA| changed subject 'Query from DECV for' to 'Message from DECV for' (unfuddle #521)
    ' 16 Sep 2021|RW| If it's been provided, use the student's preferred name in the email link
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding Student " & PreferredFullName & " (Student ID " + viewStudentSummary_Detailstudent_id.Text.Trim +")").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACT2EMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if

    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT2 control Before Show tail @381-477CF3C9
        End If
'End STUDENT_CARER_CONTACT2 control Before Show tail

'Grid STUDENT_CARER_CONTACT2 ItemDataBound event tail @381-82B2D1A7
        If STUDENT_CARER_CONTACT2IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT2CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT2Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT2ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT2 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT2 ItemCommand event @381-2BC3CD4C

    Protected Sub STUDENT_CARER_CONTACT2ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT2Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT2SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT2SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT2SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT2SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT2SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT2DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT2SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT2PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT2Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT2 ItemCommand event

'DEL      ' -------------------------
'DEL      ' ERA: 14-Feb-2013|EA| new Modified Subject comments - if nothing then don't show it
'DEL  	If PagesCount = 0 Then 
'DEL      	Grid_Modified_CommentRepeater.Visible = False
'DEL  	End if
'DEL      ' -------------------------

'Grid Grid_FamilyGroup Bind @459-766ED78A

    Protected Sub Grid_FamilyGroupBind()
        If Not Grid_FamilyGroupOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_FamilyGroup",GetType(Grid_FamilyGroupDataProvider.SortFields), 20, 100)
        End If
'End Grid Grid_FamilyGroup Bind

'Grid Form Grid_FamilyGroup BeforeShow tail @459-5B393C61
        Grid_FamilyGroupParameters()
        Grid_FamilyGroupData.SortField = CType(ViewState("Grid_FamilyGroupSortField"),Grid_FamilyGroupDataProvider.SortFields)
        Grid_FamilyGroupData.SortDir = CType(ViewState("Grid_FamilyGroupSortDir"),SortDirections)
        Grid_FamilyGroupData.PageNumber = CInt(ViewState("Grid_FamilyGroupPageNumber"))
        Grid_FamilyGroupData.RecordsPerPage = CInt(ViewState("Grid_FamilyGroupPageSize"))
        Grid_FamilyGroupRepeater.DataSource = Grid_FamilyGroupData.GetResultSet(PagesCount, Grid_FamilyGroupOperations)
        ViewState("Grid_FamilyGroupPagesCount") = PagesCount
        Dim item As Grid_FamilyGroupItem = New Grid_FamilyGroupItem()
        CType(Page,CCPage).ControlAttributes.Add(Grid_FamilyGroupRepeater,New CCSControlAttribute("numberOfColumns", FieldType._Text, (1)))
        Grid_FamilyGroupRepeater.DataBind
        FooterIndex = Grid_FamilyGroupRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_FamilyGroupRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form Grid_FamilyGroup BeforeShow tail

'Grid Grid_FamilyGroup Bind tail @459-E31F8E2A
    End Sub
'End Grid Grid_FamilyGroup Bind tail

'Grid Grid_FamilyGroup Table Parameters @459-371FA5DF

    Protected Sub Grid_FamilyGroupParameters()
        Try
            Grid_FamilyGroupData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=Grid_FamilyGroupRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_FamilyGroupRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_FamilyGroup: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_FamilyGroup Table Parameters

'Grid Grid_FamilyGroup ItemDataBound event @459-866BAB1E

    Protected Sub Grid_FamilyGroupItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_FamilyGroupItem = CType(e.Item.DataItem,Grid_FamilyGroupItem)
        Dim Item as Grid_FamilyGroupItem = DataItem
        Dim FormDataSource As Grid_FamilyGroupItem() = CType(Grid_FamilyGroupRepeater.DataSource, Grid_FamilyGroupItem())
        Dim Grid_FamilyGroupDataRows As Integer = FormDataSource.Length
        Dim Grid_FamilyGroupIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_FamilyGroupCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_FamilyGroupRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_FamilyGroupCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_FamilyGroupRowOpenTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowOpenTag"),System.Web.UI.WebControls.PlaceHolder)
            Dim Grid_FamilyGroupRowComponents As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowComponents"),System.Web.UI.WebControls.PlaceHolder)
            Dim Grid_FamilyGroupSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_FamilyGroupSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid_FamilyGroupfirst_name As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGroupfirst_name"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGroupsurname As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGroupsurname"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGrouplast_enrol_year As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGrouplast_enrol_year"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGroupRowCloseTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowCloseTag"),System.Web.UI.WebControls.PlaceHolder)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            Grid_FamilyGroupSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","", ViewState)
        End If
'End Grid Grid_FamilyGroup ItemDataBound event

'Grid Grid_FamilyGroup BeforeShowRow event @459-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid_FamilyGroup BeforeShowRow event

'Grid Grid_FamilyGroup Event BeforeShowRow. Action Gallery Layout @469-04C8B05D
            Utility.ManageGalleryPanels(e.Item, CInt(CType(Page,CCPage).ControlAttributes.GetAttribute("Grid_FamilyGroupRepeater","numberOfColumns")), Grid_FamilyGroupCurrentRowNumber, Grid_FamilyGroupData.RecordsPerPage, "Grid_FamilyGroupRowOpenTag", "Grid_FamilyGroupRowCloseTag", "Grid_FamilyGroupRowComponents", Grid_FamilyGroupDataRows, Grid_FamilyGroupIsForceIteration)
'End Grid Grid_FamilyGroup Event BeforeShowRow. Action Gallery Layout

'Grid Grid_FamilyGroup BeforeShowRow event tail @459-477CF3C9
        End If
'End Grid Grid_FamilyGroup BeforeShowRow event tail

'Grid Grid_FamilyGroup ItemDataBound event tail @459-E964BC14
        If Grid_FamilyGroupIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_FamilyGroupCurrentRowNumber, ListItemType.Item)
            Grid_FamilyGroupRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_FamilyGroupItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_FamilyGroup ItemDataBound event tail

'Grid Grid_FamilyGroup ItemCommand event @459-FFA97CD5

    Protected Sub Grid_FamilyGroupItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_FamilyGroupRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_FamilyGroupSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_FamilyGroupSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_FamilyGroupSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_FamilyGroupSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_FamilyGroupSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_FamilyGroupDataProvider.SortFields = 0
            ViewState("Grid_FamilyGroupSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_FamilyGroupPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_FamilyGroupPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_FamilyGroupPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_FamilyGroupPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_FamilyGroupBind
        End If
    End Sub
'End Grid Grid_FamilyGroup ItemCommand event

'Grid STUDENT_COMMENT1 Bind @1334-AABB092C

    Protected Sub STUDENT_COMMENT1Bind()
        If Not STUDENT_COMMENT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_COMMENT1",GetType(STUDENT_COMMENT1DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_COMMENT1 Bind

'Grid Form STUDENT_COMMENT1 BeforeShow tail @1334-D254E3D8
        STUDENT_COMMENT1Parameters()
        STUDENT_COMMENT1Data.SortField = CType(ViewState("STUDENT_COMMENT1SortField"),STUDENT_COMMENT1DataProvider.SortFields)
        STUDENT_COMMENT1Data.SortDir = CType(ViewState("STUDENT_COMMENT1SortDir"),SortDirections)
        STUDENT_COMMENT1Data.PageNumber = CInt(ViewState("STUDENT_COMMENT1PageNumber"))
        STUDENT_COMMENT1Data.RecordsPerPage = CInt(ViewState("STUDENT_COMMENT1PageSize"))
        STUDENT_COMMENT1Repeater.DataSource = STUDENT_COMMENT1Data.GetResultSet(PagesCount, STUDENT_COMMENT1Operations)
        ViewState("STUDENT_COMMENT1PagesCount") = PagesCount
        Dim item As STUDENT_COMMENT1Item = New STUDENT_COMMENT1Item()
        STUDENT_COMMENT1Repeater.DataBind
        FooterIndex = STUDENT_COMMENT1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_COMMENT1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_COMMENT1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form STUDENT_COMMENT1 BeforeShow tail

'Grid STUDENT_COMMENT1 Bind tail @1334-E31F8E2A
    End Sub
'End Grid STUDENT_COMMENT1 Bind tail

'Grid STUDENT_COMMENT1 Table Parameters @1334-3681D292

    Protected Sub STUDENT_COMMENT1Parameters()
        Try
            STUDENT_COMMENT1Data.UrlStudent_ID = IntegerParameter.GetParam("Student_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_COMMENT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_COMMENT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_COMMENT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_COMMENT1 Table Parameters

'Grid STUDENT_COMMENT1 ItemDataBound event @1334-DCE7606C

    Protected Sub STUDENT_COMMENT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_COMMENT1Item = CType(e.Item.DataItem,STUDENT_COMMENT1Item)
        Dim Item as STUDENT_COMMENT1Item = DataItem
        Dim FormDataSource As STUDENT_COMMENT1Item() = CType(STUDENT_COMMENT1Repeater.DataSource, STUDENT_COMMENT1Item())
        Dim STUDENT_COMMENT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_COMMENT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_COMMENT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_COMMENT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_COMMENT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_COMMENT1COMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENT1COMMENT"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENT1COMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENT1COMMENT_TYPE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENT1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENT1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_COMMENT1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_COMMENT1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_COMMENT1 ItemDataBound event

'Grid STUDENT_COMMENT1 ItemDataBound event tail @1334-2CEF892D
        If STUDENT_COMMENT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_COMMENT1CurrentRowNumber, ListItemType.Item)
            STUDENT_COMMENT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_COMMENT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_COMMENT1 ItemDataBound event tail

'Grid STUDENT_COMMENT1 ItemCommand event @1334-A63EC70C

    Protected Sub STUDENT_COMMENT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_COMMENT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_COMMENT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_COMMENT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_COMMENT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_COMMENT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_COMMENT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_COMMENT1DataProvider.SortFields = 0
            ViewState("STUDENT_COMMENT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_COMMENT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_COMMENT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_COMMENT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_COMMENT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_COMMENT1Bind
        End If
    End Sub
'End Grid STUDENT_COMMENT1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-33BEE1AC
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentSummaryContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewStudentSummary_DetailData = New viewStudentSummary_DetailDataProvider()
        viewStudentSummary_DetailOperations = New FormSupportedOperations(False, True, False, False, False)
        viewStudentSummary_SubjectListData = New viewStudentSummary_SubjectListDataProvider()
        viewStudentSummary_SubjectListOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_COMMENTData = New STUDENT_COMMENTDataProvider()
        STUDENT_COMMENTOperations = New FormSupportedOperations(False, True, False, False, False)
        viewStudentSummary_EnrolmData = new viewStudentSummary_EnrolmDataProvider()
        viewStudentSummary_EnrolmOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler viewStudentSummary_Enrolm.BeforeShowSection, AddressOf Me.viewStudentSummary_EnrolmBeforeShowSection
        If Request("ViewMode") Is Nothing Then viewStudentSummary_Enrolm.ViewMode= ReportViewMode.Web
        ADDRESS_PostalData = new ADDRESS_PostalDataProvider()
        ADDRESS_PostalOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler ADDRESS_Postal.BeforeShowSection, AddressOf Me.ADDRESS_PostalBeforeShowSection
        If Request("ViewMode") Is Nothing Then ADDRESS_Postal.ViewMode= ReportViewMode.Web
        ADDRESS_CurrentData = new ADDRESS_CurrentDataProvider()
        ADDRESS_CurrentOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler ADDRESS_Current.BeforeShowSection, AddressOf Me.ADDRESS_CurrentBeforeShowSection
        If Request("ViewMode") Is Nothing Then ADDRESS_Current.ViewMode= ReportViewMode.Web
        STUDENT_CENSUS_DATAData = new STUDENT_CENSUS_DATADataProvider()
        STUDENT_CENSUS_DATAOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler STUDENT_CENSUS_DATA.BeforeShowSection, AddressOf Me.STUDENT_CENSUS_DATABeforeShowSection
        If Request("ViewMode") Is Nothing Then STUDENT_CENSUS_DATA.ViewMode= ReportViewMode.Web
        STUDENT_EQUIPMENTData = new STUDENT_EQUIPMENTDataProvider()
        STUDENT_EQUIPMENTOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler STUDENT_EQUIPMENT.BeforeShowSection, AddressOf Me.STUDENT_EQUIPMENTBeforeShowSection
        If Request("ViewMode") Is Nothing Then STUDENT_EQUIPMENT.ViewMode= ReportViewMode.Web
        viewStudentSummary_MedicaData = new viewStudentSummary_MedicaDataProvider()
        viewStudentSummary_MedicaOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler viewStudentSummary_Medica.BeforeShowSection, AddressOf Me.viewStudentSummary_MedicaBeforeShowSection
        If Request("ViewMode") Is Nothing Then viewStudentSummary_Medica.ViewMode= ReportViewMode.Web
        ADDRESS_OriginalData = new ADDRESS_OriginalDataProvider()
        ADDRESS_OriginalOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler ADDRESS_Original.BeforeShowSection, AddressOf Me.ADDRESS_OriginalBeforeShowSection
        If Request("ViewMode") Is Nothing Then ADDRESS_Original.ViewMode= ReportViewMode.Web
        view_StudentSummary_AlertData = New view_StudentSummary_AlertDataProvider()
        view_StudentSummary_AlertOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACTData = New STUDENT_CARER_CONTACTDataProvider()
        STUDENT_CARER_CONTACTOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT1Data = New STUDENT_CARER_CONTACT1DataProvider()
        STUDENT_CARER_CONTACT1Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT2Data = New STUDENT_CARER_CONTACT2DataProvider()
        STUDENT_CARER_CONTACT2Operations = New FormSupportedOperations(False, True, False, False, False)
        Grid_FamilyGroupData = New Grid_FamilyGroupDataProvider()
        Grid_FamilyGroupOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_COMMENT1Data = New STUDENT_COMMENT1DataProvider()
        STUDENT_COMMENT1Operations = New FormSupportedOperations(False, True, False, False, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","8","9","11","12"})) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'Page StudentSummary Event AfterInitialize. Action Declare Variable @410-C7EAD64F
        Dim skippy As Int64 = 0
'End Page StudentSummary Event AfterInitialize. Action Declare Variable

'Page StudentSummary Event AfterInitialize. Action Declare Variable @413-5BD93EAE
        Dim tmpSTUDENT_ID As Int64 = 0
'End Page StudentSummary Event AfterInitialize. Action Declare Variable

'Page StudentSummary Event AfterInitialize. Action Declare Variable @414-32161FAD
        Dim tmpENROLMENT_YEAR As Int64 = 0
'End Page StudentSummary Event AfterInitialize. Action Declare Variable

'Page StudentSummary Event AfterInitialize. Action Retrieve Value for Variable @415-35B1CF2E
        tmpSTUDENT_ID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Page StudentSummary Event AfterInitialize. Action Retrieve Value for Variable

'Page StudentSummary Event AfterInitialize. Action Retrieve Value for Variable @416-BE34445E
        tmpENROLMENT_YEAR = System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR")
'End Page StudentSummary Event AfterInitialize. Action Retrieve Value for Variable

'Page StudentSummary Event AfterInitialize. Action Custom Code @417-73254650
    ' -------------------------
    ' default the ENROLMENT YEAR if nothing supplied
	if (IsNothing(tmpENROLMENT_YEAR)) then tmpENROLMENT_YEAR = 0
	if (tmpENROLMENT_YEAR = 0) then 
		tmpENROLMENT_YEAR = year(now())
	end if
    ' -------------------------
'End Page StudentSummary Event AfterInitialize. Action Custom Code

'Page StudentSummary Event AfterInitialize. Action DLookup @411-C47CF06E
        skippy = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "STUDENT_ENROLMENT" & " WHERE " & "STUDENT_ID = " & tmpSTUDENT_ID.ToString() & " AND ENROLMENT_YEAR = " & tmpENROLMENT_YEAR.ToString()))).Value, Int64)
'End Page StudentSummary Event AfterInitialize. Action DLookup

'Page StudentSummary Event AfterInitialize. Action Custom Code @412-73254650
    ' -------------------------
	' 28-Feb-2011|EA| along with the above 5 lines, check if not 1 Student and redirect to search page
  	if (skippy <> 1) then
 		Response.Redirect("MaintainSearchRequest.aspx")
  	end if
    ' -------------------------
'End Page StudentSummary Event AfterInitialize. Action Custom Code

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

