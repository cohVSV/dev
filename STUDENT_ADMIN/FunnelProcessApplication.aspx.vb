' Notes:
' - The GraphQL Client library can supposedly use either NewtonSoft JSON or Microsoft's System.Text.Json for the deserialisation of the GraphQL response,
'     however the module using System.Text.Json seemed to have some issues with deserialising Guids from Funnel. And it did so without raising errors.
'     I didn't spend much time trying to drill down to the cause, because the NewtonSoft library seems to work without issue.


Option Strict On
Option Explicit On


'Using Statements @1-82FB19C3
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Data
Imports F23.StringSimilarity
Imports GraphQL
Imports GraphQL.Client.Http
Imports GraphQL.Client.Serializer.Newtonsoft
'End Using Statements


Namespace DECV_PROD2007.FunnelProcessApplication 'Namespace @1-D9B31808

   'Forms Definition @1-3A21A3F9
   Public Class [FunnelProcessApplicationPage]
      Inherits CCPage
      'End Forms Definition

      'Forms Objects @1-B7F60287
      Protected FunnelProcessApplicationContentMeta As String
      'End Forms Objects

      'Page_Load Event @1-A2D2CF1E
      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
         'End Page_Load Event

         'Page_Load Event BeforeIsPostBack @1-E9EA7548
         Dim item As PageItem = PageItem.CreateFromHttpRequest()
         ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
         If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
         End If
         'End Page_Load Event BeforeIsPostBack

         PageLoad()

      End Sub 'Page_Load Event tail @1-E31F8E2A

      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

      End Sub 'Page_Unload Event tail @1-E31F8E2A

      'OnInit Event @1-7CD4ED69
#Region " Web Form Designer Generated Code "
      Protected Overrides Sub OnInit(ByVal e As EventArgs)
         'End OnInit Event

         'OnInit Event Body @1-E06F3765
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         FunnelProcessApplicationContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
         If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName)
         End If
         InitializeComponent()
         MyBase.OnInit(e)
         If Not (DBUtility.AuthorizeUser(New String() {"4", "6", "9"})) Then
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


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin items developed in Visual Studio using standard ASP.NET Web Forms
      ' --------------------------------------------------------------------------------------------------------------------------------------


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin constants
      ' --------------------------------------------------------------------------------------------------------------------------------------

      ' API access constants
      Const ProxyConfigurationSettingKey = "DECVWebProxy"
      Const APIEndpointConfigurationSettingKey = "FunnelAPIEndpoint"
      Const AccessTokenConfigurationSettingKey = "FunnelAPIAccessToken"
      Const FunnelLeadBaseUrl = "https://vsv-au-vic-691.app.digistorm.com/admin/crm/leads/"

      ' Enrolment business rule constants
      Const UpcomingEnrolmentYearRolloverMonth = 10
      Friend Shared ReadOnly CurrentEnrolmentYear As Decimal = GetEnrolmentYearForDate(Today)
      Const ExistingStudentMaximumEnrolmentYearSpan = 5
      Shared ReadOnly MinimumDataMatchEnrolmentYear As Decimal = (CurrentEnrolmentYear - ExistingStudentMaximumEnrolmentYearSpan)
      Const MaximumDamerauLevenshteinDistance = 1
      Const MinimumCandidateMatchScore = 2
      Const MinimumStartOfEnrolmentYearAgeForStudentAddressee = 16

      ' Funnel object constants
      Const AccountEnumsOwner = "Account"
      Const LeadEnumsOwner = "Lead"
      Const ParentCarerEnumsOwner = "Guardian"

      ReadOnly ApplicationSubmittedStageID As Guid = New Guid("2d1c4115-6f88-49c4-8bf6-a027eea7f92e")
      ReadOnly ApplicationCompletedStageID As Guid = New Guid("e7bdd4c7-6ab3-4232-83ab-eff677c0d706")
      ReadOnly ApplicationAcceptedStageID As Guid = New Guid("f42c37c6-b151-4c76-8765-2b28def1901c")
      Const DirectEnrolmentTypeID = "ENUM_FE39D7F0_CED0_4541_81D0_29D4EADE433D"
      Const SchoolEnrolmentTypeID = "ENUM_EB15DD39_BB35_4356_B137_5EF65D758436"
      Const FullEnrolmentTypeID = "ENUM_FCC06445_A79D_4027_90D7_4110564D0777"
      Const SharedEnrolmentTypeID = "ENUM_851C4EBD_2567_402B_9D59_B061F852E97E"

      Const PipelineStagesEnumName = "pipeline_stages"
      Const EnrolmentFormEnumName = "student_enrolment_type"
      Const EnrolmentCategoryEnumName = "enrolment_category"
      Const IsSharedEnrolmentEnumName = "enrolment_type"
      Const SalutationsEnumName = "salutations"
      Const GendersEnumName = "core_gender"
      Const YearLevelsEnumName = "year_levels"
      Const ResidentialAddressSameAsPostalEnumName = "address_in_australia_same_as_postal"
      Const RelationshipEnumName = "child_guardian_relationships"
      Const SchoolConnectionsEnumName = "school_connections"
      Const SchoolsEnumName = "feeder_schools"
      Const NameOfHomeSchoolEnumName = "name_of_school"
      Const PrivacyConsentEnumName = "consent_to_access_student_records"

      ' Funnel enums - medical
      Const HearingImpairedEnumName = "deaf_or_hearing_impaired"
      Const VisionImpairedEnumName = "blind_or_vision_impaired"
      Const ASDAspergersEnumName = "diagnosed_with_asd_aspergers_syndrome"
      Const IntellectualDisabilityEnumName = "intellectual_disability"
      Const PhysicalDisabilityEnumName = "physical_disability"
      Const SevereBehaviouralDisorderEnumName = "severe_behavioural_disorder"
      Const SevereLanguageDisorderEnumName = "severe_language_disorder"
      Const MentalHealthConditionEnumName = "diagnosed_mental_health_condition"
      Const HasAllergyHistoryEnumName = "any_history_of_allergies"
      Const AnaphylaxisEnumName = "diagnosed_as_at_risk_of_anaphylaxis"
      Const DiagnosedWithAsthmaEnumName = "diagnosed_with_asthma"
      Const DiagnosedWithDiabetesEnumName = "diagnosed_with_diabetes"
      Const DiagnosedWithEpilepsyEnumName = "diagnosed_with_epilepsy"
      Const DiagnosedWithAnyOtherConditionsEnumName = "diagnosed_with_any_other_condition"
      Const OtherMedicalIssuesEnumName = "medical_issues_vsv_should_be_aware_of"

      ' Funnel enums - census
      Const StudentCountryOfBirthEnumName = "country_of_birth"
      Const StudentSpeakNonEnglishAtHomeEnumName = "mainly_speak_a_language_other_than_english_at_home"
      Const StudentSpeakEnglishEnumName = "do_you_speak_english"
      Const StudentFirstHomeLanguageEnumName = "language_if_other_than_english"
      Const IndigenousStatusEnumName = "indigenous_status"
      Const ResidentialStatusEnumName = "residential_status"
      Const HouseholdStatusEnumName = "living_arrangement"
      Const PreviousSchoolEnumName = "" ' TODO: Determine what's needed for the schools
      Const RestrictAccessAtRiskEnumName = "at_risk"
      Const RestrictAccessAlertEnumName = "is_there_an_access_alert"
      Const RestrictAccessTypeEnumName = "access_type"
      Const RestrictActivityAlertEnumName = "activity_alert"

      ReadOnly MotherRelationshipValues As IReadOnlyCollection(Of Guid) = New HashSet(Of Guid) From {New Guid("418fd5c8-0688-4fae-949e-29614e6241d0"), ' Mother
                                                                                                  New Guid("65fa734c-cfbc-4d54-a382-121ad5601ab4"), ' Stepmother
                                                                                                  New Guid("e8de4195-bc85-46a1-aa1c-86389be0d7e3")} ' Adoptive mother

      ReadOnly FatherRelationshipValues As IReadOnlyCollection(Of Guid) = New HashSet(Of Guid) From {New Guid("4c383360-ff95-4a32-8f84-8b50c99635ef"), ' Father
                                                                                                  New Guid("47978c71-b80a-444b-86f4-a8accf29c216"), ' Stepfather
                                                                                                  New Guid("87338d27-9169-4a74-a1a6-f52b80d51bcd")} ' Adoptive father

      Const ParentCarerCountryOfBirthEnumName = "country_of_birth"
      Const ParentCarerSpeakNonEnglishAtHomeEnumName = "language_other_than_english_spoken_at_home"
      Const ParentCarerLanguageEnumName = "language_other_than_english"
      Const ParentCarerSchoolEducationEnumName = "school_education"
      Const ParentCarerNonSchoolEducationEnumName = "qualification"
      Const ParentCarerOccupationGroupEnumName = "occupation_group"

      Const PostalAddressLabel = "Postal"
      Const ResidentialAddressLabel = "Residential"
      Const MobilePhoneNumberLabel = "Mobile"
      Const HomePhoneNumberLabel = "Home"
      Const WorkPhoneNumberLabel = "Work"

      ' Student database constants
      Const AppliedStudentStatusValue = "Applied"
      Const AcceptedStudentStatusValue = "Accepted"
      Const RejectedStudentStatusValue = "Rejected"

      Const RejectedDuplicateReasonID = "Duplicate"
      Const RejectedIncompleteReasonID = "Incomplete"
      Const RejectedLateReasonID = "Late"
      Const RejectedErroneousReasonID = "Erroneous"
      Const RejectedOtherReasonID = "Other"

      Friend Const NoStudentID = -1D

      Const ExistingStudentEnrolmentErrorID = 5
      Const ExistingStudentFinishedStudiesID = 6
      Const GenderOtherCode = "X"
      Const GenderSelfDescribedDefault = "Not specified"

      Const SchoolCategoryCode = "SCHOOL"
      Const SchoolSubcategoryCode = "NORMAL"
      Const SchoolEnrolmentDisplayName = "School - Normal"
      Const SportsPerformanceCategoryCode = "SPORTSPERF"
      Const VSVSchoolID = 16261D
      Const VSVSchoolDisplayName = "Virtual School Victoria"

      Const AustraliaAlpha2Code = "AU"
      Const EnglishLanguageCode = 1201S
      Const TemporaryResidentCode = "T"
      Const VisaSubClassMaximumValue = 999

      Const ParentCarerAConnectionType = "CARER_ID_PARENT_A"
      Const ParentCarerBConnectionType = "CARER_ID_PARENT_B"
      Const SchoolSupervisorConnectionType = "CARER_ID_SCHOOL_SUPERVISOR"
      Const SchoolSupervisorRelationshipCode = "SS"
      Const AgencySupervisorRelationshipCode = "XA"
      Const SportsSupervisorRelationshipCode = "XS"

      'Page constants
      Const PageTitle = "Process Funnel Application"

      Const FieldNameCellWidthPixels = 300
      Const FieldValueCellWidthPixels = 325

      Const RendererInitialCapacity = 2000

      Const BoldCssClass = "bold"
      Const MatchCssClass = "match"
      Const MatchWithPossibleDataErrorCssClass = "matchWithPossibleDataError"
      Const ModifiedCssClass = "modified"
      Const ModifiedWithTruncationCssClass = "modifiedWithTruncation"
      Const InvalidValueCssClass = "invalidValue"
      Const WarningCssClass = "warningMessage"
      Const SuccessCssClass = "successMessage"

      Const BrowseApplicationsPageUrl = "FunnelBrowseApplications.aspx"
      Const BrowseApplicationsPageUpdateStatusParameter = "updateStatus"
      Const BrowseApplicationsPageUpdateTimestampParameter = "updateTime"


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin page properties
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private ReadOnly Property SignedInUserID As String
         Get
            Return DBUtility.UserId.ToString().Trim().ToUpper()
         End Get
      End Property


      Private ReadOnly Property LeadUUID As Guid
         Get
            Return New Guid(Request.QueryString("leadUUID"))
         End Get
      End Property


      Property DestinationStudentID As Decimal
         Get
            Return DirectCast(ViewState("DestinationStudentID"), Decimal)
         End Get

         Set(value As Decimal)
            ViewState("DestinationStudentID") = value
         End Set
      End Property


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin common data methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Shared Function GetEnrolmentYearForDate(theDate As Date) As Decimal
         Return 2022D
         ' TODO: Revert to this expression after testing has finished:
         'Return If(theDate.Month < UpcomingEnrolmentYearRolloverMonth, theDate.Year, theDate.Year + 1)
      End Function


      Private Shared Function IsNewStudent(studentID As Decimal?) As Boolean
         Return studentID.HasValue
      End Function


      Private Shared Function GetFullCategoryCode(categoryCode As String, subcategoryCode As String) As String
         Return categoryCode & "|||" & subcategoryCode
      End Function


      Private Shared Function IsSchoolBasedCategoryCode(categoryCode As String) As Boolean
         Return categoryCode.Equals(SchoolCategoryCode)
      End Function


      Private Shared Function IsSportsPerformanceCategoryCode(categoryCode As String) As Boolean
         Return categoryCode.Equals(SportsPerformanceCategoryCode)
      End Function


      Private Shared Function GetAgeAtDate(dateOfBirth As Date, Optional atDate As Date? = Nothing) As Integer
         Dim atDateLocal = If(atDate?.Date, Date.Now)
         Dim birthdayOffset = If((dateOfBirth.Month > atDateLocal.Month) OrElse ((dateOfBirth.Month = atDateLocal.Month) AndAlso (dateOfBirth.Day > atDateLocal.Day)), 1, 0)
         Return (atDateLocal.Year - dateOfBirth.Year) - birthdayOffset
      End Function


      Private Shared Function FormatPhoneNumber(phoneNumber As String) As String
         If (phoneNumber?.StartsWith("+614")) Then
            ' An Australian mobile
            Dim formattedNumber = phoneNumber.Replace("+614", "04")
            If (formattedNumber.Length = 10) Then
               formattedNumber = formattedNumber.Insert(4, " ")
               formattedNumber = formattedNumber.Insert(8, " ")
            End If

            Return formattedNumber
         ElseIf (phoneNumber?.StartsWith("+613")) Then
            ' A Victorian landline
            Dim formattedNumber = phoneNumber.Replace("+613", "03")
            If (formattedNumber.Length = 10) Then
               formattedNumber = formattedNumber.Insert(2, " ")
               formattedNumber = formattedNumber.Insert(7, " ")
            End If

            Return formattedNumber
         Else
            ' Otherwise make no assumptions about the format and leave it as is
            Return phoneNumber
         End If
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin page methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Sub PageLoad()
         ' CCPage.OnInit will be invoked prior to this, and will authorise the user for enrolments permissions: groups 4, 6, and 9.
         If Not Page.IsPostBack Then
            RegisterAsyncTask(New PageAsyncTask(AddressOf InitialiseFunnelStudentImportPage))
         End If
      End Sub


      ' - From chat with Matt on 18 May, the application can have pipeline status "submitted" which means that referral forms can still be pending, but
      '     we don't want that to necessarily stop them from being put into the SDB
      '     However, this may prove to be problematic since the referrals details (supervisor, practitioner, agency) will presumably be unavailable?
      Private Async Function InitialiseFunnelStudentImportPage() As Task
         Try
            Dim applicantKeyDetails = Await GetApplicantKeyDetailsAsync(LeadUUID)

            Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
               connection.Open()

               Dim importStatus = GetFunnelLeadImportStatus(LeadUUID, connection)
               DestinationStudentID = If(importStatus?.AcceptedStudentID IsNot Nothing, importStatus.AcceptedStudentID.Value, NoStudentID)

               If (applicantKeyDetails Is Nothing) Then
                  ' The Funnel details are unavailable. The lead may or may not have existed previously.
                  ' Either way, we can't use Funnel information to display any details, and the user cannot take any action.
                  If (importStatus Is Nothing) Then
                     InitialiseUnknownLeadDisplay()
                  Else
                     InitialiseDeletedLeadDisplay(importStatus)
                  End If
               Else
                  ' Populate the key details with the live information retrieved from Funnel
                  Dim keyDetailMappings = GetApplicantKeyDetailMappings(applicantKeyDetails, connection)
                  InitialiseApplicantKeyDetailsControls(applicantKeyDetails, keyDetailMappings, importStatus)

                  ' Check that the student hasn't already been processed
                  ' If we later wish to refine rules around importing Funnel leads more than once, this is the right starting place to tweak the logic
                  ' We would need to check the individual import dates, ie. ApplicationSubmittedImportedDate and ApplicationCompletedImportedDate
                  If (importStatus?.Status.Equals(AppliedStudentStatusValue)) Then
                     Dim funnelEnrolmentYear = GetEnrolmentYearForDate(applicantKeyDetails.created_at.Value)
                     If (funnelEnrolmentYear <> CurrentEnrolmentYear) Then
                        ' The Funnel entry belongs to a previous enrolment year
                        InitialiseApplicantDetailsInvalidEnrolmentYear(applicantKeyDetails.created_at.Value, funnelEnrolmentYear)
                     ElseIf ((Not applicantKeyDetails.pipeline_stage.uuid.Equals(ApplicationCompletedStageID)) AndAlso
                        (Not applicantKeyDetails.pipeline_stage.uuid.Equals(ApplicationSubmittedStageID))) Then
                        ' The Funnel entry's pipeline stage isn't either "Application Submitted" or "Application Completed"
                        InitialiseApplicantDetailsInvalidFunnelStage()
                     Else
                        InitialiseRejectApplicationDialog()

                        ' The entry can be imported. Look for matching existing students
                        Dim minimumEnrolmentYear = (CurrentEnrolmentYear - ExistingStudentMaximumEnrolmentYearSpan)

                        ' Perform a preliminary sweep: retrieve students who have enrolled within the last few years and
                        ' where there is an EXACT match against one or more of these items:
                        ' - Date of birth
                        ' - Surname
                        ' - Email
                        Dim preliminaryMatches = GetPreliminaryMatchingExistingStudents(applicantKeyDetails.child, minimumEnrolmentYear, connection)

                        ' Refine the shortlist to realistic matches using a basic match scoring system
                        Dim candidateMatches = GetMatchingExistingStudents(applicantKeyDetails, preliminaryMatches)
                        If (candidateMatches.Count > 0) Then
                           ' There are potential matches. Show the existing student selection form
                           InitialiseExistingStudentSelectionView(applicantKeyDetails, candidateMatches)
                        Else
                           ' Skip to the import display view
                           Await InitialisePreviewUpdateViewAsync(importStatus)
                        End If
                     End If
                  End If
               End If
            End Using
         Catch ex As Exception
            ShowErrorMessage(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
         End Try
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin common page methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Shared Function GeneratePageTitle(Optional applicantName As String = Nothing) As String
         Return If(applicantName Is Nothing, applicantName & " - " & PageTitle, PageTitle)
      End Function


      Private Shared Function GenerateFunnelLeadPageLink(leadUUID As String) As String
         Return $"{FunnelLeadBaseUrl}{leadUUID}"
      End Function


      Private Shared Function YesNoNull(value As Boolean?) As String
         Select Case value
            Case True
               Return "Yes"
            Case False
               Return "No"
            Case Else
               Return Nothing
         End Select
      End Function


      Private Shared Function GenerateDivMessage(message As String, cssClass As String) As String
         Dim builder As New StringBuilder(RendererInitialCapacity)
         With builder
            If (cssClass Is Nothing) Then
               .Append("<div style='margin-top: 10px;'>")
            Else

               .Append($"<div class='{cssClass}' style='margin-top: 10px;'>")
            End If
            .Append(message)
            .Append("</div>")
         End With

         Return builder.ToString()
      End Function


      Private Sub ShowStatusMessage(message As String, Optional cssClass As String = SuccessCssClass)
         mvFunnelSDBImport.SetActiveView(viewStatus)

         divFunnelStudentImportStatusMessage.InnerText = message
         divFunnelStudentImportStatusMessage.Attributes("class") = cssClass
      End Sub


      Private Sub ShowErrorMessage(message As String)
         litErrorDialogMessage.Text = message
         Dim script = $"showDialog('divErrorDialog');"
         ScriptManager.RegisterStartupScript(upFunnelStudentImport, upFunnelStudentImport.GetType(), "ShowErrorDialog", script, True)
      End Sub


      Private Sub RedirectToUrl(url As String)
         Response.Redirect(url, False)
         Context.ApplicationInstance.CompleteRequest()
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel lead key details HTML rendering
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Sub InitialiseUnknownLeadDisplay()
         ltPageTitle.Text = GeneratePageTitle()
         divApplicantAlert.InnerHtml = "Unknown Funnel applicant lead ID. The lead either does not exist or has been deleted without being processed."
         divApplicantAlert.Visible = True
      End Sub


      Private Sub InitialiseDeletedLeadDisplay(importStatus As FunnelLeadSDBImportStatus)
         With importStatus
            ltPageTitle.Text = GeneratePageTitle(.ApplicantName)
            ltApplicantName.Text = .ApplicantName
            divApplicantAlert.InnerHtml = "This applicant lead has been deleted from Funnel."
            divApplicantAlert.Visible = True
            ltApplicantEnrolmentForm.Text = .FunnelEnrolmentFormDisplayName
            ltApplicantEnrolmentCategory.Text = .FunnelEnrolmentCategoryDisplayName
            ltApplicantYearLevel.Text = .FunnelYearLevelDisplayName
            ltApplicantFunnelStage.Text = .FunnelPipelineStageDisplayName
         End With

         InitialiseImportStatusControl(importStatus)
      End Sub


      Private Sub InitialiseImportStatusControl(importStatus As FunnelLeadSDBImportStatus)
         With importStatus
            Select Case .Status
               Case AppliedStudentStatusValue
                  ltApplicantImportStatus.Text = "This applicant has not yet been processed"
               Case AcceptedStudentStatusValue
                  Dim sdbUrl = Common.GenerateStudentSummaryPageLink(.AcceptedStudentID.ToString(), .FunnelTargetEnrolmentYear.ToString())
                  Dim sdbLinkHtml = $"<a href='{sdbUrl}' target='_blank'>{ .AcceptedStudentID}</a>"
                  Dim newOrExistingStudent = If(.AcceptedExistingStudent, "(an existing student)", "(a new student)")
                  Dim actionedDate = Common.GetDateTimeDisplay(.ActionedDate, True)
                  Dim statusText = $"<p>Accepted as student ID {sdbLinkHtml} {newOrExistingStudent} for the { .FunnelTargetEnrolmentYear} enrolment year.</p>"
                  statusText &= $"<p>Processed { actionedDate} by { .ActionedBy} when the application was at the { .ActionedPipelineStageDisplayName} stage in Funnel.</p>"
                  divApplicantImportStatusMessage.InnerHtml = statusText
                  divApplicantImportStatusMessage.Visible = True
               Case RejectedStudentStatusValue
                  Dim rejectionReasonText As String
                  If (Not .RejectedReasonID.Equals(RejectedOtherReasonID)) Then
                     rejectionReasonText = "<p>Reason: " & .RejectedReasonID & " enrolment application.</p>"
                     If (Not String.IsNullOrEmpty(.RejectedReasonOther)) Then
                        rejectionReasonText &= "<p>" & HttpUtility.HtmlEncode(.RejectedReasonOther) & "</p>"
                     End If
                  Else
                     rejectionReasonText = "<p>Other reason for rejecting the application: " & HttpUtility.HtmlEncode(.RejectedReasonOther) & "</p>"
                  End If

                  Dim actionedDate = Common.GetDateTimeDisplay(.ActionedDate, True)
                  Dim statusText = $"<p>Rejected { actionedDate} by { .ActionedBy} when it was at the { .ActionedPipelineStageDisplayName} stage in Funnel.<p/>{rejectionReasonText}"
                  divApplicantImportStatusMessage.InnerHtml = statusText
                  divApplicantImportStatusMessage.Visible = True
            End Select
         End With
      End Sub


      Private Sub InitialiseApplicantKeyDetailsControls(applicantKeyDetails As Lead, keyDetailMappings As FunnelSDBKeyDetailMappings, importStatus As FunnelLeadSDBImportStatus)
         With applicantKeyDetails.child
            ltApplicantPreviousVSVStudentID.Text = applicantKeyDetails.custom_properties.previous_vsv_no
            Dim applicantName = .first_name & " " & .last_name
            Dim preferredName As String = Nothing
            If (Not String.Equals(applicantKeyDetails.custom_properties.preferred_name, .first_name, StringComparison.CurrentCultureIgnoreCase)) Then
               preferredName = applicantKeyDetails.custom_properties.preferred_name

               If (Not String.IsNullOrEmpty(preferredName)) Then
                  applicantName &= " (" & preferredName & ")"
               End If
            End If
            ltPageTitle.Text = GeneratePageTitle(applicantName)
            hlApplicantFunnelLink.Text = applicantName
            hlApplicantFunnelLink.NavigateUrl = GenerateFunnelLeadPageLink(applicantKeyDetails.uuid.ToString())
            ltApplicantEnrolmentForm.Text = keyDetailMappings.EnrolmentFormTypeDisplayName
            If (IsSchoolBasedEnrolmentApplication(applicantKeyDetails.custom_properties.student_enrolment_type)) Then
               ltApplicantEnrolmentCategory.Text = SchoolEnrolmentDisplayName
               ltApplicantIsSharedEnrolment.Text = "No"
            Else
               ltApplicantEnrolmentCategory.Text = keyDetailMappings.EnrolmentCategoryDisplayName
               ltApplicantIsSharedEnrolment.Text = YesNoNull(IsSharedEnrolmentApplication(applicantKeyDetails.custom_properties.enrolment_type))
            End If
            If (IsSchoolBasedEnrolmentApplication(applicantKeyDetails.custom_properties.student_enrolment_type) OrElse
             IsSharedEnrolmentApplication(applicantKeyDetails.custom_properties.enrolment_type)) Then
               ltApplicantHomeSchool.Text = keyDetailMappings.HomeSchoolDisplayName
            Else
               ltApplicantHomeSchool.Text = VSVSchoolDisplayName
            End If
            ltApplicantYearLevel.Text = applicantKeyDetails.proposed_year_level.name
            ltApplicantFunnelStage.Text = applicantKeyDetails.pipeline_stage.name

            InitialiseImportStatusControl(importStatus)
         End With
      End Sub


      Private Sub InitialiseApplicantDetailsInvalidEnrolmentYear(funnelCreatedDate As Date, funnelEnrolmentYear As Decimal)
         Dim alertText As New StringBuilder(RendererInitialCapacity)
         alertText.Append($"The applicant's targeted enrolment year of {funnelEnrolmentYear} conflicts with the current enrolment period year of {CurrentEnrolmentYear}, ")
         alertText.Append("and the application cannot be imported into the student database.<br/><br/>")
         alertText.Append($"The enrolment application was created in Funnel on {funnelCreatedDate:d MMM yyyy}")

         divEnrolmentYearAlert.InnerHtml = alertText.ToString()
         divEnrolmentYearAlert.Visible = True
      End Sub


      Private Sub InitialiseApplicantDetailsInvalidFunnelStage()
         Dim alertText As New StringBuilder(RendererInitialCapacity)
         alertText.Append($"The applicant lead in Funnel must be at the ""Application Submitted"" or ""Application Completed"" phase")
         alertText.Append(" to be imported into the student database.")

         divApplicantFunnelStageAlert.InnerHtml = alertText.ToString()
         divApplicantFunnelStageAlert.Visible = True
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin application rejection page methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Sub InitialiseRejectApplicationDialog()
         ddlRejectReasonID.Items.Add(New ListItem("Duplicate enrolment application", RejectedDuplicateReasonID))
         ddlRejectReasonID.Items.Add(New ListItem("Incomplete enrolment application", RejectedIncompleteReasonID))
         ddlRejectReasonID.Items.Add(New ListItem("Late enrolment application", RejectedLateReasonID))
         ddlRejectReasonID.Items.Add(New ListItem("Erroneous enrolment application", RejectedErroneousReasonID))
         ddlRejectReasonID.Items.Add(New ListItem("Other (please specify)", RejectedOtherReasonID))
      End Sub


      Protected Sub cvRejectReasonOther_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles cvRejectReasonOther.ServerValidate
         args.IsValid = (Not ddlRejectReasonID.SelectedValue.Equals("")) AndAlso
            Not (ddlRejectReasonID.SelectedValue.Equals("Other") AndAlso String.IsNullOrWhiteSpace(txtRejectApplicationReasonOther.Text))
      End Sub


      Protected Sub btnRejectApplication_Click(sender As Object, e As EventArgs) Handles btnConfirmRejectApplication.Click
         If (Page.IsValid()) Then
            RegisterAsyncTask(New PageAsyncTask(AddressOf RejectApplication))
         End If
      End Sub


      Private Async Function RejectApplication() As Task
         Try
            ' Retrieve the pipeline stage again, as it may have changed
            Dim applicantKeyDetails = Await GetApplicantKeyDetailsAsync(LeadUUID)
            If (applicantKeyDetails?.pipeline_stage.uuid IsNot Nothing) Then
               Dim applicationRejectionStatus = PopulateRejectedApplicationStatus(SignedInUserID, applicantKeyDetails.pipeline_stage.uuid.Value)
               If (RejectFunnelLead(LeadUUID, applicationRejectionStatus)) Then
                  RedirectToUrl(Request.RawUrl)
               Else
                  ShowErrorMessage("Failed to update the application status in the student database.")
               End If
            Else
               ShowErrorMessage("Failed to update the application status in the student database: could not retrieve the record details from Funnel.")
            End If
         Catch ex As Exception
            ShowErrorMessage(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
         End Try
      End Function


      Private Function PopulateRejectedApplicationStatus(actionedBy As String, funnelPipelineStageID As Guid) As FunnelLeadSDBImportStatus
         Dim applicationRejectionStatus As New FunnelLeadSDBImportStatus()
         With applicationRejectionStatus
            .Status = RejectedStudentStatusValue
            .RejectedReasonID = ddlRejectReasonID.SelectedValue
            .RejectedReasonOther = txtRejectApplicationReasonOther.Text.Trim()
            .ActionedBy = actionedBy
            .ActionedDate = Date.Now
            .ActionedPipelineStageID = funnelPipelineStageID
         End With

         Return applicationRejectionStatus
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin existing student selection HTML rendering
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Sub InitialiseExistingStudentSelectionView(applicantKeyDetails As Lead, existingStudents As List(Of SDBStudentMatch))
         With applicantKeyDetails.child
            If (Not String.IsNullOrEmpty(applicantKeyDetails.custom_properties.previous_vsv_no)) Then
               Dim previousVSVNumber = applicantKeyDetails.custom_properties.previous_vsv_no.Trim()
               previousVSVNumber = previousVSVNumber.Substring(0, Math.Min(10, previousVSVNumber.Length))
               ltESApplicantPreviousVSVNumber.Text = previousVSVNumber
            End If

            ltESApplicantFirstName.Text = .first_name
            ltESApplicantPreferredName.Text = applicantKeyDetails.custom_properties.preferred_name
            ltESApplicantMiddleName.Text = .middle_name
            ltESApplicantSurname.Text = .last_name
            ltESApplicantDateOfBirth.Text = .date_of_birth.Value.ToString("d MMM yyyy")
            ltESApplicantEmail.Text = .email
            ltESApplicantMobile.Text = GetPhoneNumber(.phone_numbers, MobilePhoneNumberLabel)

            rbExistingStudentIDNone.Value = NoStudentID.ToString()
         End With

         ' Place the best matches at the top of the list, then bind the list to the ListView
         existingStudents.Sort()
         lvExistingStudentSelection.DataSource = existingStudents
         lvExistingStudentSelection.DataBind()

         mvFunnelSDBImport.SetActiveView(viewExistingStudentSelection)
      End Sub


      Function GenerateMatchingStudentElementHtml(element As String, fieldMatchStrength As FieldMatchStrength) As String
         Dim builder As New StringBuilder(RendererInitialCapacity)
         Dim cssClass = GetFieldMatchStrengthCssClass(fieldMatchStrength)
         With builder
            If (cssClass.Length = 0) Then
               .Append("<td>")
            Else
               .Append($"<td class='{cssClass}'>")
            End If
            .Append(element)
            .Append("</td>")
         End With

         Return builder.ToString()
      End Function


      Private Function GetFieldMatchStrengthCssClass(fieldMatchStrength As FieldMatchStrength) As String
         Select Case fieldMatchStrength
            Case FieldMatchStrength.NoData, FieldMatchStrength.NoMatch
               Return ""
            Case FieldMatchStrength.Match
               Return MatchCssClass
            Case FieldMatchStrength.MatchWithPossibleDataError
               Return MatchWithPossibleDataErrorCssClass
            Case Else
               Return ""
         End Select
      End Function


      Function GenerateMatchingStudentEnrolmentStatus(studentMatch As SDBStudentMatch) As String
         With studentMatch
            If (.LEYEnrolmentStatus = "E") Then
               Return "Currently enrolled"
            ElseIf (.LEYEnrolmentStatus = "N") Then
               If (.LEYWithdrawalReasonID?.Equals(ExistingStudentFinishedStudiesID)) Then
                  Return "Finished course"
               ElseIf (.LEYWithdrawalDate.HasValue) Then
                  Return "Withdrawal on " & .LEYWithdrawalDate.Value.ToString("d MMM yyyy")
               Else
                  Return "Not enrolled - no withdrawal date"
               End If
            Else
               Return .LEYEnrolmentStatus
            End If
         End With
      End Function


      Protected Sub btnESCancel_Click(sender As Object, e As EventArgs) Handles btnESCancel.Click
         RedirectToUrl(BrowseApplicationsPageUrl)
      End Sub


      Protected Sub btnESPreviewImport_Click(sender As Object, e As EventArgs) Handles btnESPreviewImport.Click
         If (Page.IsValid()) Then
            Try
               DestinationStudentID = Decimal.Parse(Request.Form("rbgnExistingStudentID"))

               Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
                  connection.Open()
                  Dim importStatus = GetFunnelLeadImportStatus(LeadUUID, connection)

                  RegisterAsyncTask(New PageAsyncTask(Function() InitialisePreviewUpdateViewAsync(importStatus)))
               End Using
            Catch ex As Exception
               ShowErrorMessage(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            End Try
         End If
      End Sub


      Private Sub ValidateExistingStudentIDSelection()
         If (DestinationStudentID = NoStudentID) Then
            Return
         Else
            ' TODO: Perform some server side validation here, and call it in the method above
            ' - Has the student already been imported?
            ' - Save the possible candidate IDs to viewstate. Is the selected ID amongst them?
            ' - Does the selected student already have an existing record for the current enrolment year?
         End If
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin import preview HTML rendering
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Async Function InitialisePreviewUpdateViewAsync(importStatus As FunnelLeadSDBImportStatus) As Task
         mvFunnelSDBImport.SetActiveView(viewPreviewUpdate)

         Try
            Dim applicantEnrolmentDetails = Await GetApplicantEnrolmentDetailsAsync(LeadUUID)

            Dim existingRecordSet As SDBStudentRecordSet
            Dim enrolmentMappings As FunnelSDBMappings
            Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
               connection.Open()

               ' Populate the key details with the live information retrieved from Funnel
               enrolmentMappings = GetApplicantEnrolmentMappings(applicantEnrolmentDetails, connection)

               If (Not DestinationStudentID.Equals(NoStudentID)) Then
                  existingRecordSet = GetExistingStudentRecordSet(DestinationStudentID, MinimumDataMatchEnrolmentYear, connection)
               Else
                  existingRecordSet = New SDBStudentRecordSet()
               End If

               ' Attempt to match parent/carers to existing parent/carer (only) records, if the details have been provided in Funnel and there's not already a linked carer ID
               ' This will mostly apply to new students but it's also possible for returning students without carer records
               ' It's also not essential, and more of a convenience and data cleanliness feature
               If (existingRecordSet.ParentCarerA Is Nothing) Then
                  existingRecordSet.ParentCarerA = GetMatchingCarer(applicantEnrolmentDetails, CarerContactType.ParentCarerA, MinimumDataMatchEnrolmentYear,
                                                                 existingRecordSet.Student?.StudentID, connection)
               End If

               If (existingRecordSet.ParentCarerB Is Nothing) Then
                  existingRecordSet.ParentCarerB = GetMatchingCarer(applicantEnrolmentDetails, CarerContactType.ParentCarerB, MinimumDataMatchEnrolmentYear,
                                                                 existingRecordSet.Student?.StudentID, connection)
               End If
            End Using

            Dim funnelRecordSet = PopulateFunnelStudentRecordSet(CurrentEnrolmentYear, applicantEnrolmentDetails, enrolmentMappings, existingRecordSet)

            RenderStudentDetailsUpdatePreview(funnelRecordSet.Student, existingRecordSet.Student)
            RenderEnrolmentUpdatePreview(funnelRecordSet.Enrolment)
            RenderPostalAddressUpdatePreview(funnelRecordSet.Student, funnelRecordSet.PostalAddress, existingRecordSet.PostalAddress)
            RenderResidentialAddressUpdatePreview(funnelRecordSet.Student, funnelRecordSet.ResidentialAddress, existingRecordSet.ResidentialAddress)
            RenderParentCarerUpdatePreview(funnelRecordSet.ParentCarerA, CarerContactType.ParentCarerA, ltPreviewParentCarerATableContent, existingRecordSet.ParentCarerA)
            RenderParentCarerUpdatePreview(funnelRecordSet.ParentCarerB, CarerContactType.ParentCarerB, ltPreviewParentCarerBTableContent, existingRecordSet.ParentCarerB)
            RenderStudentMedicalDetailsUpdatePreview(funnelRecordSet.MedicalDetails, existingRecordSet.MedicalDetails)
            RenderStudentCensusDetailsUpdatePreview(funnelRecordSet.CensusDetails, existingRecordSet.CensusDetails)

         Catch ex As Exception
            ShowErrorMessage(ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
         End Try
      End Function


      Private Function GetMatchingCarer(applicantEnrolmentDetails As Lead, carerContactType As CarerContactType, minimumDataMatchEnrolmentYear As Decimal,
                                     existingStudentID As Decimal?, connection As SqlConnection) As SDBStudentCarerContact
         Dim carerContact = GetCarerContactKeyDetailsFromFunnel(applicantEnrolmentDetails, carerContactType)
         If (carerContact IsNot Nothing) Then
            ' Attempt to match against existing parent/carers on all of the first name, surname, and email fields
            ' It's more important to be sure of having a correct match than it is to have any match at all
            ' Only parent/carer records will be checked. Supervisor relationships are disregarded
            Dim existingCarerID = GetFirstMatchingSDBCarerContactID(carerContact.FirstName, carerContact.Surname, carerContact.Email, connection, CarerContactMatchType.ParentCarer)
            If (existingCarerID IsNot Nothing) Then
               ' Fetch the contact details, and at the same time retrieve links to any other students
               Dim matchedRecord = GetSDBCarerContact(existingCarerID.Value, minimumDataMatchEnrolmentYear, connection, CarerContactMatchType.ParentCarer, existingStudentID)
               If (matchedRecord IsNot Nothing) Then
                  matchedRecord.IsMatchedRecord = True
               End If

               Return matchedRecord
            End If
         End If

         Return Nothing
      End Function


      Private Sub RenderStudentDetailsUpdatePreview(funnelStudent As SDBStudent, Optional existingStudent As SDBStudent = Nothing)
         With funnelStudent
            Dim renderer As New StudentImportPreviewRenderer(.RecordModificationStatus)
            renderer.RenderTableStandardHeaderText("student details")
            renderer.RenderTableHeaderColumns()

            If (.RecordModificationStatus.RecordModificationType = RecordModificationType.Insert) Then
               renderer.RenderFieldRow(NameOf(.StudentID), "Student ID", "A new ID will be created")
            Else
               renderer.RenderFieldRow(NameOf(.StudentID), "Student ID", .StudentID.ToString(), existingStudent?.StudentID.ToString())
            End If

            renderer.RenderFieldRow(NameOf(.FirstName), "First name", .FirstName, existingStudent?.FirstName)
            renderer.RenderFieldRow(NameOf(.PreferredName), "Preferred name", .PreferredName, existingStudent?.PreferredName)
            renderer.RenderFieldRow(NameOf(.MiddleName), "Middle name(s)", .MiddleName, existingStudent?.MiddleName)
            renderer.RenderFieldRow(NameOf(.Surname), "Surname", .Surname, existingStudent?.Surname)
            renderer.RenderFieldRow(NameOf(.DateOfBirth), "Date of birth", Common.GetDateDisplay(.DateOfBirth), Common.GetDateDisplay(existingStudent?.DateOfBirth))
            renderer.RenderFieldRow(NameOf(.Gender), "Gender", .GenderDisplayName, existingStudent?.GenderDisplayName)
            renderer.RenderFieldRow(NameOf(.GenderSelfDescribed), "Gender if self described", .GenderSelfDescribed, existingStudent?.GenderSelfDescribed)
            renderer.RenderFieldRow(NameOf(.StudentEmail), "Email", .StudentEmail, existingStudent?.StudentEmail)
            renderer.RenderFieldRow(NameOf(.StudentMobile), "Mobile", .StudentMobile, existingStudent?.StudentMobile)

            ' Using the combined category codes to detect any changes, while displaying the human readable names
            renderer.RenderFieldRow(NameOf(.FullCategoryCode), "Enrolment category", .EnrolmentCategoryDisplayName, existingStudent?.EnrolmentCategoryDisplayName)

            renderer.RenderFieldRow(NameOf(.AttendingSchoolID), "Attending school", .AttendingSchoolDisplayName, existingStudent?.AttendingSchoolDisplayName)
            renderer.RenderFieldRow(NameOf(.HomeSchoolID), "Home school", .HomeSchoolDisplayName, existingStudent?.HomeSchoolDisplayName)

            renderer.RenderFieldRow(NameOf(.VCAANumber), "VCAA number", .VCAANumber, existingStudent?.VCAANumber)
            renderer.RenderFieldRow(NameOf(.EnrolmentComments), "Reason for enrolment", .EnrolmentComments, existingStudent?.EnrolmentComments)

            ltPreviewStudentDetailsTableContent.Text = renderer.ToHtml()
         End With
      End Sub


      Private Sub RenderEnrolmentUpdatePreview(funnelStudentEnrolment As SDBStudentEnrolment)
         With funnelStudentEnrolment
            Dim renderer As New StudentImportPreviewRenderer(.RecordModificationStatus)
            renderer.RenderTableStandardHeaderText("enrolment")
            renderer.RenderTableHeaderColumns()

            renderer.RenderFieldRow(NameOf(.EnrolmentYear), "Enrolment year", .EnrolmentYear.ToString())
            renderer.RenderFieldRow(NameOf(.YearLevel), "Year level", .YearLevelDisplayName)
            renderer.RenderFieldRow(NameOf(.EnrolmentDate), "Enrolment date", Common.GetDateDisplay(.EnrolmentDate))
            renderer.RenderFieldRow(NameOf(.EnrolmentStatus), "Enrolment status", .EnrolmentStatus)

            ' TODO: Supervisor details, including for shared non-school enrolments
            ' TODO: eligible for funding, taking the student age and school into account

            renderer.RenderFieldRow(NameOf(.PrivacyConsent), "Consent to access student records", .PrivacyConsentDisplayName)

            ltPreviewEnrolmentTableContent.Text = renderer.ToHtml()
         End With
      End Sub


      Private Sub RenderPostalAddressUpdatePreview(funnelStudent As SDBStudent, funnelPostalAddress As SDBAddress, Optional existingPostalAddress As SDBAddress = Nothing)
         Dim modificationStatus = If(funnelPostalAddress?.RecordModificationStatus, RecordModificationStatus.NoRecordModification)
         Dim renderer As New StudentImportPreviewRenderer(modificationStatus)

         If (IsSchoolBasedCategoryCode(funnelStudent.CategoryCode)) Then
            Dim schoolDisplayName = funnelStudent.HomeSchoolDisplayName
            renderer.RenderTableCustomHeaderText($"The student's postal address will be the same as that of their home school of {schoolDisplayName}.")
         ElseIf (funnelPostalAddress Is Nothing) Then
            renderer.RenderTableCustomHeaderText("No postal address has been provided", WarningCssClass)
            ' TODO: Consider preventing the enrolment from being processed in this case, and changing the wording accordingly
         Else
            If (existingPostalAddress?.LinkedSchoolID IsNot Nothing) Then
               Dim schoolDisplayName = existingPostalAddress.LinkedSchoolDisplayName
               renderer.RenderTableCustomHeaderText($"The student's existing postal address is linked to a school ({schoolDisplayName}). A new postal address record will be created.", WarningCssClass)
            Else
               renderer.RenderTableStandardHeaderText("postal address")
            End If

            renderer.RenderTableHeaderColumns()
            RenderAddressDetails(renderer, funnelPostalAddress, existingPostalAddress)
         End If

         ltPreviewPostalAddressTableContent.Text = renderer.ToHtml()
      End Sub


      Private Sub RenderAddressDetails(renderer As StudentImportPreviewRenderer, funnelAddress As SDBAddress, Optional existingAddress As SDBAddress = Nothing)
         With funnelAddress
            renderer.RenderFieldRow(NameOf(.Addressee), "Addressee", .Addressee, existingAddress?.Addressee)
            renderer.RenderFieldRow(NameOf(.Agent), "Agent", .Agent, existingAddress?.Agent)
            renderer.RenderFieldRow(NameOf(.AddressLineOne), "Line 1", .AddressLineOne, existingAddress?.AddressLineOne)
            renderer.RenderFieldRow(NameOf(.AddressLineTwo), "Line 2", .AddressLineTwo, existingAddress?.AddressLineTwo)
            renderer.RenderFieldRow(NameOf(.SuburbTown), "Suburb / Town", .SuburbTown, existingAddress?.SuburbTown)
            renderer.RenderFieldRow(NameOf(.Postcode), "Postcode", .Postcode, existingAddress?.Postcode)
            renderer.RenderFieldRow(NameOf(.State), "State", .State, existingAddress?.State)
            renderer.RenderFieldRow(NameOf(.Country), "Country", .Country, existingAddress?.Country)
            renderer.RenderFieldRow(NameOf(.PhoneNumberOne), "Home phone", .PhoneNumberOne, existingAddress?.PhoneNumberOne)
            renderer.RenderFieldRow(NameOf(.PhoneNumberTwo), "Phone 2 / mobile", .PhoneNumberTwo, existingAddress?.PhoneNumberTwo)
            renderer.RenderFieldRow(NameOf(.EmailAddressOne), "Email address", .EmailAddressOne, existingAddress?.EmailAddressOne)
            ' Don't display the 2nd email address
         End With
      End Sub


      Private Sub RenderResidentialAddressUpdatePreview(funnelStudent As SDBStudent, funnelResidentialAddress As SDBAddress, Optional existingResidentialAddress As SDBAddress = Nothing)
         Dim renderer As StudentImportPreviewRenderer
         If (funnelStudent.ResidentialAddressSameAsPostalAddress) Then
            renderer = New StudentImportPreviewRenderer(RecordModificationStatus.NoRecordModification)
            renderer.RenderTableCustomHeaderText("The student's residential address will be the same as their postal address.")
         ElseIf (funnelResidentialAddress Is Nothing) Then
            renderer = New StudentImportPreviewRenderer(RecordModificationStatus.NoRecordModification)
            renderer.RenderTableCustomHeaderText("No residential address has been provided.", WarningCssClass)
            ' TODO: Consider preventing the enrolment from being processed in this case, and changing the wording accordingly
         Else
            If (existingResidentialAddress?.LinkedSchoolID IsNot Nothing) Then
               funnelResidentialAddress.RecordModificationStatus.RecordModificationType = RecordModificationType.Insert
               renderer = New StudentImportPreviewRenderer(funnelResidentialAddress.RecordModificationStatus)
               Dim schoolDisplayName = existingResidentialAddress.LinkedSchoolDisplayName
               renderer.RenderTableCustomHeaderText($"The student's existing residential address is linked to a school ({schoolDisplayName}). A new residential address record will be created.", WarningCssClass)
            Else
               Dim modificationStatus = funnelResidentialAddress.RecordModificationStatus
               renderer = New StudentImportPreviewRenderer(modificationStatus)
               renderer.RenderTableStandardHeaderText("residential address")
            End If

            renderer.RenderTableHeaderColumns()
            RenderAddressDetails(renderer, funnelResidentialAddress, existingResidentialAddress)
         End If

         ltPreviewResidentialAddressTableContent.Text = renderer.ToHtml()
      End Sub


      Private Sub RenderParentCarerUpdatePreview(parentCarer As SDBStudentCarerContact, parentCarerType As CarerContactType,
                                              outputTextControl As ITextControl,
                                              Optional existingParentCarer As SDBStudentCarerContact = Nothing)
         With parentCarer
            Dim modificationStatus = If(?.RecordModificationStatus, RecordModificationStatus.NoRecordModification)
            Dim renderer As New StudentImportPreviewRenderer(modificationStatus)

            Dim parentCarerTypeDisplayName As String = If(parentCarerType = CarerContactType.ParentCarerA, "parent/carer A", "parent/carer B")

            If (parentCarer Is Nothing) Then
               Dim cssClass = If(parentCarerType = CarerContactType.ParentCarerA, WarningCssClass, Nothing)
               renderer.RenderTableCustomHeaderText($"No {parentCarerTypeDisplayName} has been provided.", cssClass)
            Else
               If (existingParentCarer IsNot Nothing) Then
                  Dim builder As New StringBuilder(RendererInitialCapacity)

                  If (existingParentCarer.IsMatchedRecord) Then
                     builder.Append("A matching parent/carer has been found in the database based on the details entered in Funnel, ")
                     builder.Append($"and will be linked to this student as their {parentCarerTypeDisplayName}.<br/>")
                     builder.Append("Any updates to the linked parent/carer will be highlighted below.")
                  Else
                     builder.Append(renderer.GetTableStandardHeaderText(parentCarerTypeDisplayName))
                  End If

                  If (existingParentCarer.StudentConnections.Count > 0) Then
                     Dim student = existingParentCarer.StudentConnections(0)
                     Dim studentPageLink = Common.GenerateStudentSummaryPageLink(student.StudentID.ToString(), student.EnrolmentYear.ToString())
                     builder.Append("<br/><br/>")
                     builder.Append($"The parent/carer is also linked to <a href='{studentPageLink}' target='_blank'>{student.Name} - ID {student.StudentID}</a>")
                     If (existingParentCarer.StudentConnections.Count > 1) Then
                        builder.Append($" and { existingParentCarer.StudentConnections.Count - 1} other student(s).")
                     Else
                        builder.Append(".")
                     End If
                  End If

                  renderer.RenderTableCustomHeaderText(builder.ToString())
               Else
                  renderer.RenderTableStandardHeaderText(parentCarerTypeDisplayName)
               End If

               renderer.RenderTableHeaderColumns()

               renderer.RenderFieldRow(NameOf(.Salutation), "Title", .Salutation, existingParentCarer?.Salutation)
               renderer.RenderFieldRow(NameOf(.Surname), "Surname", .Surname, existingParentCarer?.Surname)
               renderer.RenderFieldRow(NameOf(.FirstName), "First name", .FirstName, existingParentCarer?.FirstName)
               renderer.RenderFieldRow(NameOf(.Relationship), "Relationship", .RelationshipDisplayName, existingParentCarer?.RelationshipDisplayName)
               renderer.RenderFieldRow(NameOf(.HomePhone), "Home phone", .HomePhone, existingParentCarer?.HomePhone)
               renderer.RenderFieldRow(NameOf(.WorkPhone), "Work phone", .WorkPhone, existingParentCarer?.WorkPhone)
               renderer.RenderFieldRow(NameOf(.Mobile), "Mobile", .Mobile, existingParentCarer?.Mobile)
               renderer.RenderFieldRow(NameOf(.Email), "Email", .Email, existingParentCarer?.Email)

            End If

            outputTextControl.Text = renderer.ToHtml()
         End With
      End Sub


      Private Sub RenderStudentMedicalDetailsUpdatePreview(funnelMedicalDetails As SDBStudentMedicalDetails,
                                                        Optional existingMedicalDetails As SDBStudentMedicalDetails = Nothing)
         With funnelMedicalDetails
            Dim renderer As New StudentImportPreviewRenderer(.RecordModificationStatus)
            renderer.RenderTableStandardHeaderText("medical details")
            renderer.RenderTableHeaderColumns()

            renderer.RenderFieldRow(NameOf(.HearingImpaired), "Deaf or hearing impaired", YesNoNull(.HearingImpaired), YesNoNull(existingMedicalDetails?.HearingImpaired))
            renderer.RenderFieldRow(NameOf(.VisionImpaired), "Blind or vision impaired", YesNoNull(.VisionImpaired), YesNoNull(existingMedicalDetails?.VisionImpaired))
            renderer.RenderFieldRow(NameOf(.ASDAspergers), "Diagnosed with ASD or Asperger's", YesNoNull(.ASDAspergers), YesNoNull(existingMedicalDetails?.ASDAspergers))
            renderer.RenderFieldRow(NameOf(.IntellectualDisability), "Intellectual disability", YesNoNull(.IntellectualDisability), YesNoNull(existingMedicalDetails?.IntellectualDisability))
            renderer.RenderFieldRow(NameOf(.PhysicalDisability), "Physical disability", YesNoNull(.PhysicalDisability), YesNoNull(existingMedicalDetails?.PhysicalDisability))
            renderer.RenderFieldRow(NameOf(.SevereBehaviouralDisorder), "Severe behavioural disorder", YesNoNull(.SevereBehaviouralDisorder), YesNoNull(existingMedicalDetails?.SevereBehaviouralDisorder))
            renderer.RenderFieldRow(NameOf(.SevereLanguageDisorder), "Severe language disorder", YesNoNull(.SevereLanguageDisorder), YesNoNull(existingMedicalDetails?.SevereLanguageDisorder))
            renderer.RenderFieldRow(NameOf(.MentalHealthCondition), "Diagnosed mental health condition", YesNoNull(.MentalHealthCondition), YesNoNull(existingMedicalDetails?.MentalHealthCondition))
            renderer.RenderFieldRow(NameOf(.MentalHealthConditionDescription), "Description of diagnosed mental health condition", .MentalHealthConditionDescription, existingMedicalDetails?.MentalHealthConditionDescription)
            renderer.RenderFieldRow(NameOf(.HasAllergyHistory), "History of allergies", YesNoNull(.HasAllergyHistory), YesNoNull(existingMedicalDetails?.HasAllergyHistory))
            renderer.RenderFieldRow(NameOf(.AllergyHistoryDescription), "Description of allergy history", .AllergyHistoryDescription, existingMedicalDetails?.AllergyHistoryDescription)
            renderer.RenderFieldRow(NameOf(.Anaphylaxis), "Diagnosed as at risk of anaphylaxis", YesNoNull(.Anaphylaxis), YesNoNull(existingMedicalDetails?.Anaphylaxis))
            renderer.RenderFieldRow(NameOf(.DiagnosedWithAsthma), "Diagnosed with asthma", YesNoNull(.DiagnosedWithAsthma), YesNoNull(existingMedicalDetails?.DiagnosedWithAsthma))
            renderer.RenderFieldRow(NameOf(.DiagnosedWithDiabetes), "Diagnosed with diabetes", YesNoNull(.DiagnosedWithDiabetes), YesNoNull(existingMedicalDetails?.DiagnosedWithDiabetes))
            renderer.RenderFieldRow(NameOf(.DiagnosedWithEpilepsy), "Diagnosed with epilepsy", YesNoNull(.DiagnosedWithEpilepsy), YesNoNull(existingMedicalDetails?.DiagnosedWithEpilepsy))
            renderer.RenderFieldRow(NameOf(.DiagnosedWithAnyOtherConditions), "Diagnosed with any other conditions", YesNoNull(.DiagnosedWithAnyOtherConditions), YesNoNull(existingMedicalDetails?.DiagnosedWithAnyOtherConditions))
            renderer.RenderFieldRow(NameOf(.OtherDiagnosedConditionsDescription), "Description of other diagnosed conditions", .OtherDiagnosedConditionsDescription, existingMedicalDetails?.OtherDiagnosedConditionsDescription)
            renderer.RenderFieldRow(NameOf(.OtherMedicalIssuesDescription), "Description of other medical issues", .OtherMedicalIssuesDescription, existingMedicalDetails?.OtherMedicalIssuesDescription)

            ltPreviewMedicalDetailsTableContent.Text = renderer.ToHtml()
         End With
      End Sub


      Private Sub RenderStudentCensusDetailsUpdatePreview(funnelCensusDetails As SDBStudentCensusData, Optional existingCensusDetails As SDBStudentCensusData = Nothing)
         With funnelCensusDetails
            Dim renderer As New StudentImportPreviewRenderer(.RecordModificationStatus)
            renderer.RenderTableStandardHeaderText("census details")
            renderer.RenderTableHeaderColumns()

            renderer.RenderFieldRow(NameOf(.CountryOfBirth), "Country of birth", .CountryOfBirthDisplayName, existingCensusDetails?.CountryOfBirthDisplayName)
            renderer.RenderFieldRow(NameOf(.FirstHomeLanguage), "First home language", .FirstHomeLanguageDisplayName, existingCensusDetails?.FirstHomeLanguageDisplayName)
            renderer.RenderFieldRow(NameOf(.OtherHomeLanguage), "Other home language", .OtherHomeLanguageDisplayName, existingCensusDetails?.OtherHomeLanguageDisplayName)
            renderer.RenderFieldRow(NameOf(.IndigenousStatus), "Indigenous status", .IndigenousStatusDisplayName, existingCensusDetails?.IndigenousStatusDisplayName)
            renderer.RenderFieldRow(NameOf(.ResidentialStatus), "Residential status", .ResidentialStatusDisplayName, existingCensusDetails?.ResidentialStatusDisplayName)
            renderer.RenderFieldRow(NameOf(.VisaSubClass), "Visa subclass", .VisaSubClassInputText, existingCensusDetails?.VisaSubClass?.ToString())
            renderer.RenderFieldRow(NameOf(.VisaSector), "Visa sector", .VisaSector, existingCensusDetails?.VisaSector)
            renderer.RenderFieldRow(NameOf(.VisaStatisticalCode), "Visa statistical code", .VisaStatisticalCode, existingCensusDetails?.VisaStatisticalCode)
            renderer.RenderFieldRow(NameOf(.DateArrivedInAustralia), "Date arrived in Australia", Common.GetDateDisplay(.DateArrivedInAustralia),
                                 Common.GetDateDisplay(existingCensusDetails?.DateArrivedInAustralia))
            renderer.RenderFieldRow(NameOf(.DateStartedInAustralia), "Date started in Australia", Common.GetDateDisplay(.DateStartedInAustralia),
                                 Common.GetDateDisplay(existingCensusDetails?.DateStartedInAustralia))
            renderer.RenderFieldRow(NameOf(.HouseholdStatus), "Household status", .HouseholdStatusDisplayName, existingCensusDetails?.HouseholdStatusDisplayName)
            renderer.RenderFieldRow(NameOf(.RestrictAccessAtRisk), "At risk", YesNoNull(.RestrictAccessAtRisk), YesNoNull(existingCensusDetails?.RestrictAccessAtRisk))
            renderer.RenderFieldRow(NameOf(.RestrictAccessAlert), "Access alert", YesNoNull(.RestrictAccessAlert), YesNoNull(existingCensusDetails?.RestrictAccessAlert))
            renderer.RenderFieldRow(NameOf(.RestrictAccessType), "Access type", .RestrictAccessType, existingCensusDetails?.RestrictAccessType)
            renderer.RenderFieldRow(NameOf(.RestrictAccessDescription), "Description of access restriction", .RestrictAccessDescription, existingCensusDetails?.RestrictAccessDescription)
            renderer.RenderFieldRow(NameOf(.RestrictActivityAlert), "Activity alert", YesNoNull(.RestrictActivityAlert), YesNoNull(existingCensusDetails?.RestrictActivityAlert))
            renderer.RenderFieldRow(NameOf(.RestrictActivityDescription), "Description of activity restriction", .RestrictActivityDescription, existingCensusDetails?.RestrictActivityDescription)

            renderer.RenderFieldRow(NameOf(.PreviousSchoolID), "Previous school", .PreviousSchoolDisplayName, existingCensusDetails?.PreviousSchoolDisplayName)
            renderer.RenderFieldRow(NameOf(.DateLastAttendedSchool), "Date last attended school", Common.GetDateDisplay(.DateLastAttendedSchool), Common.GetDateDisplay(existingCensusDetails?.DateLastAttendedSchool))

            RenderParentCensusDetails(renderer, .MotherCensusData, CarerContactType.Mother, existingCensusDetails?.MotherCensusData)
            RenderParentCensusDetails(renderer, .FatherCensusData, CarerContactType.Father, existingCensusDetails?.FatherCensusData)

            ltPreviewCensusDetailsTableContent.Text = renderer.ToHtml()
         End With
      End Sub


      Private Sub RenderParentCensusDetails(baseRenderer As StudentImportPreviewRenderer, funnelParentCensusDetails As SDBParentCensusData,
                                         parentType As CarerContactType, Optional existingParentCensusDetails As SDBParentCensusData = Nothing)
         Dim parentTypeLabelPrefix = If(parentType = CarerContactType.Mother, "Mother's ", "Father's ")
         Dim parentCensusRenderer As New StudentImportPreviewRenderer(funnelParentCensusDetails.RecordModificationStatus)

         With funnelParentCensusDetails
            parentCensusRenderer.RenderFieldRow(NameOf(.CountryOfBirth), parentTypeLabelPrefix & "country of birth", .CountryOfBirthDisplayName, existingParentCensusDetails?.CountryOfBirthDisplayName)
            parentCensusRenderer.RenderFieldRow(NameOf(.Language), parentTypeLabelPrefix & "spoken language at home other than English", .LanguageDisplayName, existingParentCensusDetails?.LanguageDisplayName)
            parentCensusRenderer.RenderFieldRow(NameOf(.SchoolEducation), parentTypeLabelPrefix & "highest year of primary or secondary education completed", .SchoolEducationDisplayName, existingParentCensusDetails?.SchoolEducationDisplayName)
            parentCensusRenderer.RenderFieldRow(NameOf(.NonSchoolEducation), parentTypeLabelPrefix & "highest qualification completed", .NonSchoolEducationDisplayName, existingParentCensusDetails?.NonSchoolEducationDisplayName)
            parentCensusRenderer.RenderFieldRow(NameOf(.OccupationGroup), parentTypeLabelPrefix & "occupation group", .OccupationGroupDisplayName, existingParentCensusDetails?.OccupationGroupDisplayName)
         End With

         baseRenderer.RenderChildContent(parentCensusRenderer)
      End Sub


      Class StudentImportPreviewRenderer
         Private RecordModificationStatus As RecordModificationStatus
         Private htmlBuilder As New StringBuilder(RendererInitialCapacity)


         Sub New(recordModificationStatus As RecordModificationStatus)
            Me.RecordModificationStatus = recordModificationStatus
         End Sub


         Shared Function GetPreviewTableStyleMarkup() As String
            Return $"style='width: {FieldNameCellWidthPixels + (FieldValueCellWidthPixels * 2)}px'"
         End Function


         Sub RenderTableCustomCellHtml(html As String)
            With htmlBuilder
               .Append("<tr class='Controls'>")
               .Append($"<td colspan='{GetColumnSpan()}' >")

               .Append(html)

               .Append("</td>")
               .Append("</tr>")
            End With

         End Sub


         Sub RenderTableStandardHeaderText(recordLabel As String)
            With htmlBuilder
               .Append("<tr class='Controls'>")
               .Append($"<td colspan='{GetColumnSpan()}'>")
               .Append("<p>")

               .Append(GetTableStandardHeaderText(recordLabel))

               .Append("</p>")
               .Append("</td>")
               .Append("</tr>")
            End With
         End Sub


         Function GetTableStandardHeaderText(recordLabel As String) As String
            If (RecordModificationStatus.RecordModificationType = RecordModificationType.Insert) Then
               Return $"A new {recordLabel} record will be created."
            ElseIf (RecordModificationStatus.RecordModificationType = RecordModificationType.Update) Then
               Return $"The student's existing {recordLabel} record will be updated."
            Else
               Return Nothing
            End If
         End Function


         Sub RenderTableCustomHeaderText(headerText As String, Optional cssClasses As String = Nothing)
            With htmlBuilder
               .Append("<tr class='Controls'>")
               .Append($"<td colspan='{GetColumnSpan()}'>")
               If (cssClasses Is Nothing) Then
                  .Append("<p>")
               Else
                  .Append($"<p class='{cssClasses}'>")
               End If

               .Append(headerText)

               .Append("</p>")
               .Append("</td>")
               .Append("</tr>")
            End With
         End Sub


         Sub RenderTableHeaderColumns()
            With htmlBuilder
               .Append("<colgroup>")
               .Append($"<col style='width: {FieldNameCellWidthPixels}px;' />")
               If (RecordModificationStatus.RecordModificationType = RecordModificationType.Update) Then
                  .Append($"<col style='width: {FieldValueCellWidthPixels}px;' />")
                  .Append($"<col style='width: {FieldValueCellWidthPixels}px;' />")
               Else
                  .Append($"<col style='width: {FieldValueCellWidthPixels * 2}px;' />")
               End If
               .Append("</colgroup>")

               .Append("<tr class='Caption'>")
               .Append("<th></th>")
               .Append("<th>New Value</th>")
               If (RecordModificationStatus.RecordModificationType = RecordModificationType.Update) Then
                  .Append("<th>Existing Value</th>")
               End If
               .Append("</tr>")
            End With
         End Sub


         Sub RenderFieldRow(fieldName As String, fieldDisplayName As String, fieldValue As String, Optional existingFieldValue As String = Nothing)
            Dim fieldModificationStatus As FieldModificationStatus = FieldModificationStatus.NoModification
            Dim cssClass As String = Nothing
            Dim noteText As String = Nothing
            Dim noteHtml As String = Nothing

            If (RecordModificationStatus.FieldModificationStatus.ContainsKey(fieldName)) Then
               fieldModificationStatus = RecordModificationStatus.FieldModificationStatus(fieldName)
               cssClass = GetFieldModificationStatusCssClass(fieldModificationStatus.FieldModificationType)
               noteText = GetFieldModificationStatusNote(fieldModificationStatus)
               If (noteText IsNot Nothing) Then
                  noteHtml = GenerateDivMessage(noteText, cssClass)
               End If
            End If

            With htmlBuilder
               .Append("<tr class='Row PreviewUpdate'>")

               ' Display name
               .Append("<td>")
               .Append(fieldDisplayName)
               .Append("</td>")

               ' New or updated value
               If (cssClass Is Nothing) Then
                  .Append($"<td>")
               Else
                  .Append($"<td class='{cssClass}'>")
               End If
               .Append(fieldValue)
               If (noteHtml IsNot Nothing) Then
                  .Append(noteHtml)
               End If
               .Append("</td>")

               ' Existing value
               If (RecordModificationStatus.RecordModificationType = RecordModificationType.Update) Then
                  .Append("<td>")
                  .Append(existingFieldValue)
                  .Append("</td>")
               End If

               .Append("</tr>")
            End With
         End Sub


         Sub RenderChildContent(childContentRenderer As StudentImportPreviewRenderer)
            htmlBuilder.Append(childContentRenderer.ToHtml())
         End Sub


         Private Function GetColumnSpan() As Integer
            Select Case RecordModificationStatus.RecordModificationType
               Case RecordModificationType.NoModification, RecordModificationType.Insert
                  Return 2
               Case RecordModificationType.Update
                  Return 3
               Case Else
                  Return 1
            End Select
         End Function


         Private Function GetFieldModificationStatusCssClass(fieldModificationType As FieldModificationType) As String
            If (RecordModificationStatus.RecordModificationType = RecordModificationType.Update) Then
               Select Case fieldModificationType
                  Case FieldModificationType.Modification
                     Return ModifiedCssClass
                  Case FieldModificationType.ModificationWithTruncation
                     Return ModifiedWithTruncationCssClass
                  Case FieldModificationType.Invalid
                     Return InvalidValueCssClass
                  Case Else
                     Return Nothing
               End Select
            Else
               ' Don't apply CSS styling to inserted fields unless the values are invalid or truncated
               Select Case fieldModificationType
                  Case FieldModificationType.ModificationWithTruncation
                     Return ModifiedWithTruncationCssClass
                  Case FieldModificationType.Invalid
                     Return InvalidValueCssClass
                  Case Else
                     Return Nothing
               End Select
            End If
         End Function


         Private Function GetFieldModificationStatusNote(fieldModificationStatus As FieldModificationStatus) As String
            Select Case fieldModificationStatus.FieldModificationType
               Case FieldModificationType.ModificationWithTruncation
                  Return $"<hr>This item will be shortened to the value shown above so that it can be imported into the student database.
                        The original value in Funnel is:<br/>""{fieldModificationStatus.PreTruncatedValue}"""
               Case FieldModificationType.Invalid
                  Return "<hr>The value for this item is invalid in the student database."
               Case Else
                  Return Nothing
            End Select
         End Function


         Function ToHtml() As String
            Return htmlBuilder.ToString()
         End Function
      End Class


      Protected Sub btnPreviewImportCancel_Click(sender As Object, e As EventArgs) Handles btnPreviewImportCancel.Click
         RedirectToUrl(BrowseApplicationsPageUrl)
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel data types
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Enum PipelineStageType
         Enquiry
         ApplicationInProgress
         ApplicationSubmitted
         ApplicationComplete
         Accepted
      End Enum


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Response types for specific queries
      ' --------------------------------------------------------------------------------------------------------------------------------------

      Public Class AccountResponseType
         Public Property Account As Account
      End Class


      Public Class LeadsResponseType
         Public Property leads As Leads
      End Class


      Public Class LeadResponseType
         Public Property lead As Lead
      End Class


      Public Class FilesResponseType
         Public Property files As Files
      End Class


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Funnel object containers
      ' --------------------------------------------------------------------------------------------------------------------------------------

      Public Class Account
         Public Property child_guardian_relationships As List(Of Relationship)
         Public Property feeder_schools As List(Of School)
         Public Property genders As List(Of Gender)
         Public Property pipeline As Pipeline
         Public Property salutations As List(Of Salutation)
         Public Property school_connections As List(Of SchoolConnection)
         Public Property year_levels As List(Of YearLevel)

         Public Property custom_property_definitions As List(Of CustomPropertyGroup)
      End Class


      Public Class Address
         Public Property label As String
         Public Property name As String
         Public Property line_1 As String
         Public Property line_2 As String
         Public Property locality As String
         Public Property administrative_area As String
         Public Property postal_code As String
         Public Property country_code As String
      End Class


      Public Class Attachments
         Public uuid As Guid?
         Public name As String
      End Class


      Public Class Child
         Public Property uuid As Guid?
         Public Property first_name As String 'M
         Public Property middle_name As String
         Public Property last_name As String 'M
         Public Property date_of_birth As Date? 'M
         Public Property gender As Gender 'M
         Public Property email As String 'M
         Public Property phone_numbers As List(Of PhoneNumber) 'M - at least one type is mandatory and it defaults to mobile

         Public Property addresses As List(Of Address) ' M - postal is mandatory
         Public Property guardians As List(Of Guardian)
         Public Property created_at As Date?
         Public Property updated_at As Date?

         ' Not needed?
         Public Property visa As Visa
      End Class


      Public Class ChildGuardianPivot
         Public Property _id As String
         Public Property is_primary As Boolean
         Public Property relationship As Relationship 'M
         Public Property disallow_comms As Boolean
         Public Property disallow_comms_reason As String
      End Class


      Public Class CustomProperty
         Public Property name As String
         Public Property description As String
         Public Property type As String
         Public Property options As List(Of CustomPropertyOption)
      End Class


      Public Class CustomPropertyGroup
         Public Property owner As String
         Public Property properties As List(Of CustomProperty)
      End Class


      Public Class CustomPropertyOption
         Public Property value As String
         Public Property title As String
      End Class


      Public Class Files
         Public Property files As List(Of File)
      End Class


      Public Class File
         Public Property uuid As Guid?
         Public Property name As String
         Public Property url As String
      End Class


      Public Class Gender
         Public Property uuid As Guid?
         Public Property name As String
      End Class


      Public Class Guardian
         Public Property uuid As Guid?
         Public Property salutation As Salutation 'M
         Public Property first_name As String 'M
         Public Property last_name As String 'M
         Public Property date_of_birth As Date?
         Public Property gender As Gender
         Public Property email As String 'M
         Public Property phone_numbers As List(Of PhoneNumber) 'M for at least one, default is mobile; it looks like multiples of the same type (eg. mobile) are accepted
         Public Property visa As Visa
         Public Property pivot As ChildGuardianPivot
         Public Property custom_properties As GuardianCustomProperties

         Public Property created_at As Date?
         Public Property updated_at As Date?

      End Class


      Public Class GuardianCustomProperties
         Public Property country_of_birth As String 'M, because Australia is preselected
         Public Property language_other_than_english_spoken_at_home As String 'M
         Public Property language_other_than_english As String
         Public Property occupation_group As String
         Public Property qualification As String 'M
         Public Property school_education As String 'M


         'Custom properties that are mandatory:
         ' language_other_than_english_spoken_at_home
         ' - If Yes, language_other_than_english is not mandatory
         ' qualification
         ' school_education
      End Class


      Public Class Lead
         Public Property uuid As Guid?

         Public Property child As Child
         Public Property proposed_entry_year As String
         Public Property proposed_year_level As YearLevel 'M
         Public Property pipeline_stage As PipelineStage

         Public Property school_connections As List(Of SchoolConnection)
         Public Property feeder_school As School 'M, should this be mandatory?

         Public Property custom_properties As LeadCustomProperties

         Public Property attachments As List(Of Attachments)

         Public Property created_save As LeadSave
         Public Property created_at As Date?
         Public Property updated_at As Date?
         Public Property seen_at As Date?
         Public Property imported_at As Date?
      End Class


      Public Class LeadCustomProperties
         Public Property access_type As String
         Public Property activity_alert As String 'M
         Public Property address_in_australia_same_as_postal As String 'M
         Public Property agency_referral_email As String
         Public Property agency_referral_name As String
         Public Property any_history_of_allergies As String 'M
         Public Property assessment_details As String
         Public Property at_risk As String 'M
         Public Property blind_or_vision_impaired As String 'M
         Public Property consent_to_access_student_records As String 'M
         Public Property consent_to_use_student_work As String 'M, need to check how the signatures are driven by this, they seem to prompt unconditionally
         Public Property contacts_to_support_the_enrolment As String
         Public Property core_gender As String
         Public Property country_of_birth As String ' M, Australia is preselected
         Public Property date_last_attended_school As Date?
         Public Property deaf_or_hearing_impaired As String 'M
         Public Property describe_any_access_restrictions As String
         Public Property describe_the_activity_restriction As String
         Public Property description_of_diagnosed_condition As String
         Public Property diagnosed_as_at_risk_of_anaphylaxis As String 'M
         Public Property diagnosed_mental_health_condition As String 'M
         Public Property diagnosed_mental_health_condition_details_d As String
         Public Property diagnosed_with_any_other_condition As String 'M
         Public Property diagnosed_with_asd_aspergers_syndrome As String 'M
         Public Property diagnosed_with_asthma As String 'M
         Public Property diagnosed_with_diabetes As String 'M
         Public Property diagnosed_with_epilepsy As String 'M
         Public Property do_you_speak_english As String 'M
         Public Property emergency_contacts As String 'M for at least one
         Public Property enrolment_category As String 'M
         Public Property enrolment_type As String 'M
         Public Property family_members As String ' Not mandatory when other_family_members_attending_the_vsv is true
         Public Property history_with_allergies As String
         Public Property immunisation_history_statement As String
         Public Property indigenous_status As String 'M
         Public Property intellectual_disability As String 'M
         Public Property is_there_an_access_alert As String 'M
         Public Property language_if_other_than_english As String
         Public Property language_you_wish_to_study As String
         Public Property last_enrolled_year_level_or_grade As String
         Public Property legal_guardian_agreement As String 'M
         Public Property length_of_enrolment_at_current_school As String
         Public Property living_arrangement As String 'M
         Public Property mainly_speak_a_language_other_than_english_at_home As String 'M
         Public Property medical_issues_vsv_should_be_aware_of As String 'M
         Public Property medical_issues_which_vsv_should_be_aware_of_description As String
         Public Property medical_management_plan As String
         Public Property most_recent_school_reports As String 'M
         Public Property name_of_school As String
         Public Property other_experience_with_the_language As String
         Public Property other_family_members_attending_the_vsv As String 'M
         Public Property parent_carer_concession_or_health_care_card As String
         Public Property past_enrolment As String 'M
         Public Property past_teacher_name As String
         Public Property past_teacher_phone_number As String
         Public Property physical_disability As String 'M
         Public Property preferred_name As String
         Public Property previously_studied_the_language As String
         Public Property previous_vsv_no As String
         Public Property proof_of_age As String 'M
         Public Property referral_type As String 'M
         Public Property residential_status As String 'M
         Public Property semester_1_subject_selection_for_year_10 As String
         Public Property semester_1_subject_selection_for_year_7 As String
         Public Property semester_1_subject_selection_for_year_8 As String
         Public Property semester_1_subject_selection_for_year_9 As String
         Public Property semester_2_subject_selection_for_year_10 As String
         Public Property semester_2_subject_selection_for_year_7 As String
         Public Property semester_2_subject_selection_for_year_8 As String
         Public Property semester_2_subject_selection_for_year_9 As String
         Public Property severe_behavioural_disorder As String 'M
         Public Property severe_language_disorder As String 'M
         Public Property specialist_assessments As String ' NM, but when an option is selected, assessment_details is also NM
         Public Property specialist_referral_email As String
         Public Property specialist_referral_name As String
         Public Property student_enrolment_type As String
         Public Property student_in_schools_semester_1_subject_selection As String
         Public Property student_in_schools_semester_2_subject_selection As String
         Public Property study_a_language_other_than_english As String 'M
         Public Property support_from_programs_or_services As String
         Public Property vcaa_no As String
         Public Property visa_expiry_date As String
         Public Property visa_sector As String
         Public Property visa_sub_class As String
         Public Property vsn As String
         Public Property why_are_you_enrolling_at_vsv As String 'M

         ' Mandatory lead custom properties:
         ' At least one emergency_contact, and these details:
         ' - name, relationship, and mobile (hardcoded to that type). Home number is optional
         ' at_risk
         ' is_there_an_access_alert
         ' - When this is selected, only the suboption access_alert_attachment is mandatory. access_type and describe_any_access_restrictions are optional
         ' activity_alert
         ' - When this is selected, the suboption describe_the_activity_restriction is mandatory
         ' enrolment_category
         ' - When certain values for this are selected, the subption referral_type becomes available and is mandatory
         ' - But, the name and email details for specialist or agency are NOT mandatory
         ' past_enrolment
         ' - When this is selected, the suboption is non-mandatory
         ' address_in_australia_same_as_postal
         ' - When this is selected, the residential ("Home") address is mandatory
         ' residential_status
         ' - When this is selected, the visa sub class and expiry date are non-mandatory
         ' mainly_speak_a_language_other_than_english_at_home
         ' - When this is selected, the suboption language_if_other_than_english is non-mandatory
         ' study_a_language_other_than_english
         ' - When this is selected, the suboptions language_you_wish_to_study, previously_studied_the_language, and other_experience_with_the_language are not mandatory
         ' has_allergies???
         ' - Same as mental health, it has a suboption for the description which is non-mandatory
         ' anaphylaxis??
         ' diagnosed_with_any_other_condition
         ' - The suboption description_of_diagnosed_condition is non-mandatory
         ' medical_issues_vsv_should_be_aware_of
         ' The suboption medical_issues_which_vsv_should_be_aware_of_description is non-mandatory
      End Class


      Public Class LeadSave
         Public Property source_type As String
         Public Property created_at As Date?
         Public Property updated_at As Date?
      End Class


      Public Class Leads
         Public Property data As List(Of Lead)
         Public Property paginatorInfo As PaginatorInfo
      End Class


      Public Class LeadsData
         Public Property data As List(Of Lead)
      End Class


      Public Class PhoneNumber
         Public Property label As String
         Public Property number As String
      End Class


      Public Class Pipeline
         Public Property name As String
         Public Property description As String
         Public Property stages As List(Of PipelineStage)
      End Class


      Public Class PipelineStage
         Public Property uuid As Guid?
         Public Property name As String
         Public Property win_probability As Single
      End Class


      Public Class Relationship
         Public uuid As Guid?
         Public name As String
      End Class


      Public Class Salutation
         Public uuid As Guid?
         Public name As String
      End Class


      Public Class School
         Public Property uuid As Guid?
         Public Property name As String
         Public Property external_id As Integer?

         Public Property addresses As List(Of Address)
         Public Property year_levels As List(Of YearLevel)
      End Class


      Public Class SchoolConnection
         Public Property uuid As Guid?
         Public Property name As String
      End Class


      Public Class Visa
         Public Property uuid As Guid?
         Public Property name As String
      End Class


      Public Class YearLevel
         Public Property uuid As Guid?
         Public Property name As String
      End Class


      Public Class PaginatorInfo
         Public Property currentPage As Integer
         Public Property lastPage As Integer
         Public Property count As Integer
         Public Property firstItem As Integer
         Public Property lastItem As Integer
         Public Property hasMorePages As Boolean

         Public Property total As Integer
         Public Property perPage As Integer
      End Class


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel access methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Async Function GetApplicantKeyDetailsAsync(uuid As Guid) As Task(Of Lead)
         Dim applicantKeyDetailsQuery = GetApplicantKeyDetailsQuery(uuid)
         Dim applicantKeyDetailsQueryResponse = Await ExecuteGraphQLQueryAsync(Of LeadResponseType)(applicantKeyDetailsQuery)
         If (applicantKeyDetailsQueryResponse.Errors IsNot Nothing) Then
            Throw New Exception("An error occurred while retrieving the applicant key details from Funnel: " & applicantKeyDetailsQueryResponse.Errors.ToString())
         End If

         ' TODO: Confirm that Funnel protects against script injection
         ' If it doesn't, perform some sanitising here
         Dim applicantKeyDetails = applicantKeyDetailsQueryResponse.Data.lead

         Return applicantKeyDetails
      End Function


      Private Async Function GetApplicantEnrolmentDetailsAsync(uuid As Guid) As Task(Of Lead)
         Dim applicantEnrolmentDetailsQuery = GetApplicantEnrolmentDetailsQuery(uuid)
         Dim applicantEnrolmentDetailsQueryResponse = Await ExecuteGraphQLQueryAsync(Of LeadResponseType)(applicantEnrolmentDetailsQuery)
         If (applicantEnrolmentDetailsQueryResponse.Errors IsNot Nothing) Then
            Throw New Exception("An error occurred while retrieving the applicant enrolment details from Funnel: " & applicantEnrolmentDetailsQueryResponse.Errors.ToString())
         End If

         ' TODO: Confirm that Funnel protects against script injection
         ' If it doesn't, perform some sanitising here
         Dim applicantEnrolmentDetails = applicantEnrolmentDetailsQueryResponse.Data.lead

         Return applicantEnrolmentDetails
      End Function


      Private Async Function ExecuteGraphQLQueryAsync(Of T)(queryText As String) As Task(Of GraphQLResponse(Of T))
         Dim proxy = New WebProxy() With {.Address = New Uri(ConfigurationManager.AppSettings(ProxyConfigurationSettingKey)),
                                      .BypassProxyOnLocal = True,
                                       .UseDefaultCredentials = True}
         Dim clientHandler = New HttpClientHandler() With {.Proxy = proxy}
         Dim httpClient = New HttpClient(clientHandler, False)
         httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ConfigurationManager.AppSettings(AccessTokenConfigurationSettingKey)}")
         Dim options = New GraphQLHttpClientOptions() With {.EndPoint = New Uri(ConfigurationManager.AppSettings(APIEndpointConfigurationSettingKey))}
         Dim graphQLClient = New GraphQLHttpClient(options, New NewtonsoftJsonSerializer(), httpClient)
         Dim request = New GraphQLHttpRequest(queryText)

         Return Await graphQLClient.SendQueryAsync(Of T)(request)
      End Function


      Private Function GetApplicantKeyDetailsQuery(uuid As Guid) As String
         Return "query GetLeadKeyDetails {
                 lead(uuid: """ & uuid.ToString() & """) {
                   uuid
                   proposed_entry_year
                   custom_properties {
                     core_gender
                     preferred_name
                     previous_vsv_no
                     enrolment_category
                     student_enrolment_type
                     name_of_school
                     enrolment_type
                   }
                   proposed_year_level {
                     uuid
                     name
                   }
                   pipeline_stage {
                     uuid
                     name
                   }
                   child {
                     first_name
                     middle_name
                     last_name
                     date_of_birth
                     gender {
                       uuid
                       name
                     }
                     phone_numbers {
                       label
                       number
                     }
                     email
                     created_at
                     updated_at
                   }
                   feeder_school {
                     uuid
                     name
                   }
                   created_at
                   created_save {
                     source_type
                     created_at
                     updated_at
                   }
                   updated_at
                   seen_at
                   imported_at
                 }
               }"
      End Function


      Private Function GetApplicantEnrolmentDetailsQuery(uuid As Guid) As String
         Return "query GetLeadCompleteDetails {
                 lead(uuid: """ & uuid.ToString() & """) {
                   uuid

                   proposed_entry_year
                   custom_properties {
                     core_gender
                     preferred_name
                     enrolment_category
                     student_enrolment_type
                     name_of_school
                     enrolment_type
                     consent_to_access_student_records
                     address_in_australia_same_as_postal
                     vcaa_no
                     why_are_you_enrolling_at_vsv

                     # Medical
                     deaf_or_hearing_impaired
                     blind_or_vision_impaired
                     diagnosed_with_asd_aspergers_syndrome
                     intellectual_disability
                     physical_disability
                     severe_behavioural_disorder
                     severe_language_disorder
                     diagnosed_mental_health_condition
                     diagnosed_mental_health_condition_details_d
                     any_history_of_allergies
                     history_with_allergies
                     diagnosed_as_at_risk_of_anaphylaxis
                     diagnosed_with_asthma
                     diagnosed_with_diabetes
                     diagnosed_with_epilepsy
                     diagnosed_with_any_other_condition
                     description_of_diagnosed_condition
                     medical_issues_vsv_should_be_aware_of
                     medical_issues_which_vsv_should_be_aware_of_description

                     # Census
                     country_of_birth
                     mainly_speak_a_language_other_than_english_at_home
                     language_if_other_than_english
                     do_you_speak_english
                     indigenous_status
                     residential_status
                     visa_sub_class
                     visa_sector
                     living_arrangement
                     at_risk
                     is_there_an_access_alert
                     access_type
                     describe_any_access_restrictions
                     activity_alert
                     describe_the_activity_restriction
                     date_last_attended_school
                   }
                   proposed_year_level {
                     uuid
                     name
                   }
                   pipeline_stage {
                     uuid
                     name
                   }
                   child {
                     first_name
                     middle_name
                     last_name
                     date_of_birth
                     gender {
                       uuid
                       name
                     }
                     phone_numbers {
                       label
                       number
                     }
                     email

                     addresses {
                       label
                       line_1
                       line_2
                       locality
                       postal_code
                       administrative_area
                       country_code
                     }

                     created_at
                     updated_at

                     guardians {
                       salutation {
                         uuid
                         name
                       }
                       first_name
                       last_name
                       email
                       phone_numbers {
                         label
                         number
                       }
                       pivot {
                         is_primary
                         relationship {
                           uuid
                           name
                         }
                       }
                       custom_properties {
                         # Census
                         country_of_birth
                         language_other_than_english_spoken_at_home
                         language_other_than_english
                         school_education
                         qualification
                         occupation_group
                       }
                     }

                     form_entries {
                       uuid
                       form {
                         uuid
                         title
                         type
                       }
                       payments {
                         uuid
                         currency
                       }
                     }
                   }
                   school_connections {
                     uuid
                     name
                   }
                   feeder_school {
                     uuid
                     name
                   }
                   created_at
                   created_save {
                     source_type
                     created_at
                     updated_at
                   }
                   updated_at
                   seen_at
                   imported_at
                 }
               }"
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel common methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function IsSchoolBasedEnrolmentApplication(enrolmentFormTypeID As String) As Boolean
         Return SchoolEnrolmentTypeID.Equals(enrolmentFormTypeID)
      End Function


      Private Function IsSharedEnrolmentApplication(isSharedEnrolmentID As String) As Boolean
         Return SharedEnrolmentTypeID.Equals(isSharedEnrolmentID)
      End Function


      Private Function GetStudentLegalName(student As Child) As String
         Return student.first_name & " " & student.last_name
      End Function


      Private Function GetPhoneNumber(phoneNumbers As List(Of PhoneNumber), phoneType As String) As String
         ' Funnel permits multiple phone numbers of the same type. Return the first match.
         For Each phoneNumber In If(phoneNumbers, Enumerable.Empty(Of PhoneNumber))
            If (phoneNumber.label.Equals(phoneType)) Then
               Return FormatPhoneNumber(phoneNumber.number)
            End If
         Next

         Return Nothing
      End Function


      Private Function GetParentCarerLegalName(guardian As Guardian) As String
         Return guardian.first_name & " " & guardian.last_name
      End Function


      Private Function GetParentCarer(guardians As List(Of Guardian), carerContactType As CarerContactType) As Guardian
         For Each guardian In If(guardians, Enumerable.Empty(Of Guardian))
            Select Case carerContactType
               Case CarerContactType.ParentCarerA
                  If (guardian.pivot.is_primary) Then
                     Return guardian
                  End If
               Case CarerContactType.ParentCarerB
                  If (Not guardian.pivot.is_primary) Then
                     Return guardian
                  End If
               Case CarerContactType.Mother
                  If ((guardian.pivot.relationship?.uuid IsNot Nothing) AndAlso MotherRelationshipValues.Contains(guardian.pivot.relationship.uuid.Value)) Then
                     Return guardian
                  End If
               Case CarerContactType.Father
                  If ((guardian.pivot.relationship?.uuid IsNot Nothing) AndAlso FatherRelationshipValues.Contains(guardian.pivot.relationship.uuid.Value)) Then
                     Return guardian
                  End If
            End Select
         Next

         Return Nothing
      End Function


      Private Function GetAddressee(student As Child) As String
         Dim studentAgeAtStartOfEnrolmentYear = GetAgeAtDate(student.date_of_birth.Value, New Date(Decimal.ToInt32(CurrentEnrolmentYear), 1, 1))
         If (studentAgeAtStartOfEnrolmentYear >= MinimumStartOfEnrolmentYearAgeForStudentAddressee) Then
            Return GetStudentLegalName(student)
         Else
            Dim parentCarerA = GetParentCarer(student.guardians, CarerContactType.ParentCarerA)
            If (parentCarerA IsNot Nothing) Then
               Return GetParentCarerLegalName(parentCarerA)
            Else
               ' No parent/carer A: fall back to using the student's name
               Return GetStudentLegalName(student)
            End If
         End If
      End Function


      Private Function GetAddress(addresses As List(Of Address), addressLabel As String) As Address
         For Each address In If(addresses, Enumerable.Empty(Of Address))
            If (address.label.Equals(addressLabel)) Then
               Return address
            End If
         Next

         Return Nothing
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel to SDB mapping objects
      '
      ' These classes contain the SDB compatible codes after being translated from Funnel enums
      ' The fields are all assigned SDB codes, with the exception of the xxxDisplayName fields which are sourced from Funnel and only to be used for display purposes
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Class FunnelSDBKeyDetailMappings
         Friend EnrolmentFormTypeDisplayName As String
         Friend EnrolmentCategory As String
         Friend EnrolmentSubcategory As String
         Friend EnrolmentCategoryDisplayName As String
         Friend HomeSchoolDisplayName As String
      End Class


      Class FunnelSDBMappings
         Friend EnrolmentCategoryDisplayName As String
         Friend EnrolmentCategory As String
         Friend EnrolmentSubcategory As String

         Friend YearLevel As Short?

         Friend Gender As String
         Friend GenderSelfDescribed As String
         Friend PrivacyConsent As Boolean?

         Friend PostalAddressCountry As String
         Friend ResidentialAddressSameAsPostalAddress As Boolean?
         Friend ResidentialAddressCountry As String

         Friend HomeSchoolID As Decimal?
         Friend HomeSchoolDisplayName As String
         Friend HomeSchoolPostalAddressID As Decimal?

         ' Medical mappings
         Friend HearingImpaired As Boolean? ' M deaf_or_hearing_impaired
         Friend VisionImpaired As Boolean? ' M blind_or_vision_impaired
         Friend ASDAspergers As Boolean? ' M diagnosed_with_asd_aspergers_syndrome
         Friend IntellectualDisability As Boolean? ' M intellectual_disability
         Friend PhysicalDisability As Boolean? ' M physical_disability
         Friend SevereBehaviouralDisorder As Boolean? ' M severe_behavioural_disorder
         Friend SevereLanguageDisorder As Boolean? ' M severe_language_disorder
         Friend MentalHealthCondition As Boolean? ' M diagnosed_mental_health_condition
         Friend HasAllergyHistory As Boolean? ' M any_history_of_allergies
         Friend Anaphylaxis As Boolean? ' M diagnosed_as_at_risk_of_anaphylaxis
         Friend DiagnosedWithAsthma As Boolean? ' M diagnosed_with_asthma
         Friend DiagnosedWithDiabetes As Boolean? ' M diagnosed_with_diabetes
         Friend DiagnosedWithEpilepsy As Boolean? ' M diagnosed_with_epilepsy
         Friend DiagnosedWithAnyOtherConditions As Boolean? ' M diagnosed_with_any_other_condition
         Friend OtherMedicalIssues As Boolean? ' M medical_issues_vsv_should_be_aware_of

         ' Census mappings
         Friend CountryOfBirth As Short?
         Friend CountryOfBirthDisplayName As String
         Friend SpeakNonEnglishAtHome As Boolean?
         Friend SpeakEnglish As Boolean?
         Friend FirstHomeLanguage As Short?
         Friend FirstHomeLanguageDisplayName As String
         Friend IndigenousStatus As String ' indigenous_status
         Friend IndigenousStatusDisplayName As String
         Friend ResidentialStatus As String ' residential_status
         Friend ResidentialStatusDisplayName As String
         Friend HouseholdStatus As Decimal? ' Lookup of living_arrangement
         Friend HouseholdStatusDisplayName As String
         Friend RestrictAccessAtRisk As Boolean?
         Friend RestrictAccessAlert As Boolean?
         Friend RestrictAccessType As String
         Friend RestrictActivityAlert As Boolean?
         Friend PreviousSchoolID As Decimal?
         Friend PreviousSchoolDisplayName As String

         Friend MotherCensusMappings As FunnelSDBParentCensusMappings
         Friend FatherCensusMappings As FunnelSDBParentCensusMappings

         Friend ParentCarerAMappings As FunnelSDBCarerContactMappings
         Friend ParentCarerBMappings As FunnelSDBCarerContactMappings
      End Class


      Class FunnelSDBParentCensusMappings
         Friend CountryOfBirth As Short?
         Friend CountryOfBirthDisplayName As String
         Friend SpeakNonEnglishAtHome As Boolean?
         Friend Language As Short?
         Friend LanguageDisplayName As String
         Friend SchoolEducation As String
         Friend SchoolEducationDisplayName As String
         Friend NonSchoolEducation As String
         Friend NonSchoolEducationDisplayName As String
         Friend OccupationGroup As String
         Friend OccupationGroupDisplayName As String
      End Class


      Class FunnelSDBCarerContactMappings
         Friend Salutation As String
         Friend Relationship As String
         Friend RelationshipDisplayName As String
      End Class


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel to SDB data capture methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function GetFunnelEnumDisplayName(enumOwner As String, enumName As String, enumValue As String, connection As SqlConnection) As String
         Dim funnelDisplayName As String = Nothing
         Dim sdbPrimaryValue As String = Nothing
         Dim sdbSecondaryValue As String = Nothing

         GetFunnelEnumMapping(enumOwner, enumName, enumValue, funnelDisplayName, sdbPrimaryValue, sdbSecondaryValue, connection)

         Return funnelDisplayName
      End Function


      Private Function GetFunnelEnumSDBValue(Of T)(enumOwner As String, enumName As String, enumValue As String,
                                        connection As SqlConnection) As T
         Dim funnelDisplayName As String = Nothing
         Dim sdbPrimaryValue As T = Nothing
         Dim sdbSecondaryValue As String = Nothing

         GetFunnelEnumMapping(enumOwner, enumName, enumValue, funnelDisplayName, sdbPrimaryValue, sdbSecondaryValue, connection)

         Return sdbPrimaryValue
      End Function


      Private Sub GetFunnelEnumDisplayNameSDBValue(Of T)(enumOwner As String, enumName As String, enumValue As String,
                                                      ByRef funnelDisplayName As String, ByRef sdbPrimaryValue As T, connection As SqlConnection)
         Dim sdbSecondaryValue As String = Nothing
         GetFunnelEnumMapping(enumOwner, enumName, enumValue, funnelDisplayName, sdbPrimaryValue, sdbSecondaryValue, connection)
      End Sub


      Private Sub GetFunnelEnumMapping(Of T1, T2)(enumOwner As String, enumName As String, enumValue As String,
                                        ByRef funnelDisplayName As String, ByRef sdbPrimaryValue As T1, ByRef sdbSecondaryValue As T2,
                                        connection As SqlConnection)
         If (enumValue IsNot Nothing) Then
            Using command = connection.CreateCommand()

               command.Parameters.AddWithValue("@enumOwner", enumOwner)
               command.Parameters.AddWithValue("@enumName", enumName)
               command.Parameters.AddWithValue("@enumValue", enumValue)
               command.CommandType = CommandType.Text
               command.CommandText = "select
                                       fem.Label,
                                       fem.SDBPrimaryValue,
                                       fem.SDBSecondaryValue
                                     from
                                       dbo.FUNNEL_ENUM_MAPPING as fem
                                     where
                                       (fem.Owner = @enumOwner)
                                       and (fem.Name = @enumName)
                                       and (fem.Value = @enumValue);"

               Using reader = command.ExecuteReader()
                  If (reader.Read()) Then
                     funnelDisplayName = reader.Value(Of String)("Label")

                     If (reader("SDBPrimaryValue") IsNot DBNull.Value) Then
                        ' The SDB mapping is not null so it does have a value, but Convert.ChangeType does not handle Nullable types, eg. Boolean?
                        ' So, check for Nullable types and if needed convert to the underlying generic type instead, eg. Boolean
                        ' Another win for .NET and reified generic types
                        Dim primaryValueType = GetType(T1)
                        Dim primaryValueUnderlyingType = Nullable.GetUnderlyingType(primaryValueType)
                        If (primaryValueUnderlyingType Is Nothing) Then
                           sdbPrimaryValue = DirectCast(Convert.ChangeType(reader("SDBPrimaryValue"), primaryValueType), T1)
                        Else
                           sdbPrimaryValue = DirectCast(Convert.ChangeType(reader("SDBPrimaryValue"), primaryValueUnderlyingType), T1)
                        End If
                     Else
                        ' Supposedly the closest VB.NET equivalent to C#'s default(T1)
                        sdbPrimaryValue = CType(Nothing, T1)
                     End If

                     If (reader("SDBSecondaryValue") IsNot DBNull.Value) Then
                        Dim secondaryValueType = GetType(T2)
                        Dim secondaryValueUnderlyingType = Nullable.GetUnderlyingType(secondaryValueType)
                        If (secondaryValueUnderlyingType Is Nothing) Then
                           sdbSecondaryValue = DirectCast(Convert.ChangeType(reader("SDBSecondaryValue"), secondaryValueType), T2)
                        Else
                           sdbSecondaryValue = DirectCast(Convert.ChangeType(reader("SDBSecondaryValue"), secondaryValueUnderlyingType), T2)
                        End If
                     Else
                        sdbSecondaryValue = CType(Nothing, T2)
                     End If
                  Else
                     Throw New Exception($"Funnel mapping not found. Owner: {enumOwner}, Name: {enumName}, Value: {enumValue}")
                  End If
               End Using
            End Using
         Else
            funnelDisplayName = Nothing
            sdbPrimaryValue = CType(Nothing, T1)
            sdbSecondaryValue = CType(Nothing, T2)
         End If
      End Sub


      Private Function GetApplicantKeyDetailMappings(applicantKeyDetails As Lead, connection As SqlConnection) As FunnelSDBKeyDetailMappings
         Dim keyDetailMappings As New FunnelSDBKeyDetailMappings()

         With keyDetailMappings
            .EnrolmentFormTypeDisplayName = GetFunnelEnumDisplayName(LeadEnumsOwner, EnrolmentFormEnumName, applicantKeyDetails.custom_properties.student_enrolment_type, connection)
            GetFunnelEnumMapping(LeadEnumsOwner, EnrolmentCategoryEnumName, applicantKeyDetails.custom_properties.enrolment_category, .EnrolmentCategoryDisplayName,
                              .EnrolmentCategory, .EnrolmentSubcategory, connection)
            If (IsSchoolBasedEnrolmentApplication(applicantKeyDetails.custom_properties.student_enrolment_type) OrElse
            IsSharedEnrolmentApplication(applicantKeyDetails.custom_properties.enrolment_type)) Then
               .HomeSchoolDisplayName = GetFunnelEnumDisplayName(LeadEnumsOwner, NameOfHomeSchoolEnumName, applicantKeyDetails.custom_properties.name_of_school, connection)
            End If
         End With

         Return keyDetailMappings
      End Function


      Private Function GetApplicantEnrolmentMappings(applicant As Lead, connection As SqlConnection) As FunnelSDBMappings
         Dim mappings As New FunnelSDBMappings()

         With mappings
            If (IsSchoolBasedEnrolmentApplication(applicant.custom_properties.student_enrolment_type)) Then
               ' TODO: Determine what's needed here for the other school-based subcategories: overseas and international
               .EnrolmentCategory = SchoolCategoryCode
               .EnrolmentSubcategory = SchoolSubcategoryCode
               .EnrolmentCategoryDisplayName = SchoolEnrolmentDisplayName
            Else
               GetFunnelEnumMapping(LeadEnumsOwner, EnrolmentCategoryEnumName, applicant.custom_properties.enrolment_category, .EnrolmentCategoryDisplayName,
                              .EnrolmentCategory, .EnrolmentSubcategory, connection)
            End If

            ' The year level and gender display names are captured directly in our Funnel data structure, so we don't need to grab them from the mappings table
            .YearLevel = GetFunnelEnumSDBValue(Of Short?)(AccountEnumsOwner, YearLevelsEnumName, applicant.proposed_year_level.uuid.ToString(), connection)
            .Gender = GetFunnelEnumSDBValue(Of String)(LeadEnumsOwner, GendersEnumName, applicant.custom_properties.core_gender, connection)
            .GenderSelfDescribed = If(Not .Gender.Equals(GenderOtherCode), Nothing, GenderSelfDescribedDefault)
            .PrivacyConsent = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, PrivacyConsentEnumName, applicant.custom_properties.consent_to_access_student_records, connection)

            Dim postalAddress = GetAddress(applicant.child.addresses, PostalAddressLabel)
            If (postalAddress IsNot Nothing) Then
               ' Custom addresses in Funnel may include null elements
               If (postalAddress.country_code?.Equals(AustraliaAlpha2Code)) Then
                  .PostalAddressCountry = "Australia"
               Else
                  .PostalAddressCountry = GetCountryAlpha2CodeDisplayName(postalAddress.country_code, connection)
               End If
            End If

            ' TODO: confirm for all enrolment categories that this is the correct way to pick up the home school ID from Funnel
            ' What about the external organisation, for sports/perf?
            If (IsSchoolBasedEnrolmentApplication(applicant.custom_properties.student_enrolment_type)) Then
               ' Students in schools will have their school's address as their postal address on the database
               ' And the Funnel "postal address" (including the country captured above) will end up being assigned to their residential address on the student database
               Dim schoolEmail As String = Nothing
               GetFunnelEnumMapping(LeadEnumsOwner, NameOfHomeSchoolEnumName, applicant.custom_properties.name_of_school, .HomeSchoolDisplayName,
                              schoolEmail, .HomeSchoolID, connection)
               If (.HomeSchoolID IsNot Nothing) Then
                  .HomeSchoolPostalAddressID = GetSDBSchoolAddressID(.HomeSchoolID.Value, connection)
               End If
            Else
               If (IsSharedEnrolmentApplication(applicant.custom_properties.enrolment_type)) Then
                  Dim schoolEmail As String = Nothing
                  GetFunnelEnumMapping(LeadEnumsOwner, NameOfHomeSchoolEnumName, applicant.custom_properties.name_of_school, .HomeSchoolDisplayName,
                              schoolEmail, .HomeSchoolID, connection)
               End If

               .ResidentialAddressSameAsPostalAddress = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, ResidentialAddressSameAsPostalEnumName,
                                                                                    applicant.custom_properties.address_in_australia_same_as_postal, connection)
               If ((Not .ResidentialAddressSameAsPostalAddress.HasValue) OrElse (Not .ResidentialAddressSameAsPostalAddress)) Then
                  Dim residentialAddress = GetAddress(applicant.child.addresses, ResidentialAddressLabel)
                  If (residentialAddress IsNot Nothing) Then
                     If (residentialAddress.country_code?.Equals(AustraliaAlpha2Code)) Then
                        .ResidentialAddressCountry = "Australia"
                     Else
                        .ResidentialAddressCountry = GetCountryAlpha2CodeDisplayName(residentialAddress.country_code, connection)
                     End If
                  End If
               End If
            End If

            ' Medical booleans
            .HearingImpaired = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, HearingImpairedEnumName, applicant.custom_properties.deaf_or_hearing_impaired, connection)
            .VisionImpaired = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, VisionImpairedEnumName, applicant.custom_properties.blind_or_vision_impaired, connection)
            .ASDAspergers = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, ASDAspergersEnumName, applicant.custom_properties.diagnosed_with_asd_aspergers_syndrome, connection)
            .IntellectualDisability = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, IntellectualDisabilityEnumName, applicant.custom_properties.intellectual_disability, connection)
            .PhysicalDisability = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, PhysicalDisabilityEnumName, applicant.custom_properties.physical_disability, connection)
            .SevereBehaviouralDisorder = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, SevereBehaviouralDisorderEnumName, applicant.custom_properties.severe_behavioural_disorder, connection)
            .SevereLanguageDisorder = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, SevereLanguageDisorderEnumName, applicant.custom_properties.severe_language_disorder, connection)
            .MentalHealthCondition = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, MentalHealthConditionEnumName, applicant.custom_properties.diagnosed_mental_health_condition, connection)
            .HasAllergyHistory = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, HasAllergyHistoryEnumName, applicant.custom_properties.any_history_of_allergies, connection)
            .Anaphylaxis = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, AnaphylaxisEnumName, applicant.custom_properties.diagnosed_as_at_risk_of_anaphylaxis, connection)
            .DiagnosedWithAsthma = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, DiagnosedWithAsthmaEnumName, applicant.custom_properties.diagnosed_with_asthma, connection)
            .DiagnosedWithDiabetes = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, DiagnosedWithDiabetesEnumName, applicant.custom_properties.diagnosed_with_diabetes, connection)
            .DiagnosedWithEpilepsy = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, DiagnosedWithEpilepsyEnumName, applicant.custom_properties.diagnosed_with_epilepsy, connection)
            .DiagnosedWithAnyOtherConditions = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, DiagnosedWithAnyOtherConditionsEnumName, applicant.custom_properties.diagnosed_with_any_other_condition, connection)
            .OtherMedicalIssues = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, OtherMedicalIssuesEnumName, applicant.custom_properties.medical_issues_vsv_should_be_aware_of, connection)

            ' Census values
            GetFunnelEnumDisplayNameSDBValue(LeadEnumsOwner, StudentCountryOfBirthEnumName, applicant.custom_properties.country_of_birth,
                                                .CountryOfBirthDisplayName, .CountryOfBirth, connection)
            .SpeakNonEnglishAtHome = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, StudentSpeakNonEnglishAtHomeEnumName, applicant.custom_properties.mainly_speak_a_language_other_than_english_at_home, connection)
            GetFunnelEnumDisplayNameSDBValue(LeadEnumsOwner, StudentFirstHomeLanguageEnumName, applicant.custom_properties.language_if_other_than_english,
                                                .FirstHomeLanguageDisplayName, .FirstHomeLanguage, connection)
            .SpeakEnglish = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, StudentSpeakEnglishEnumName, applicant.custom_properties.do_you_speak_english, connection)
            GetFunnelEnumDisplayNameSDBValue(LeadEnumsOwner, IndigenousStatusEnumName, applicant.custom_properties.indigenous_status,
                                                .IndigenousStatusDisplayName, .IndigenousStatus, connection)
            GetFunnelEnumDisplayNameSDBValue(LeadEnumsOwner, ResidentialStatusEnumName, applicant.custom_properties.residential_status,
                                                .ResidentialStatusDisplayName, .ResidentialStatus, connection)
            GetFunnelEnumDisplayNameSDBValue(LeadEnumsOwner, HouseholdStatusEnumName, applicant.custom_properties.living_arrangement,
                                                .HouseholdStatusDisplayName, .HouseholdStatus, connection)
            ' TODO: The previous school ID and display name
            .RestrictAccessAtRisk = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, RestrictAccessAtRiskEnumName, applicant.custom_properties.at_risk, connection)
            .RestrictAccessAlert = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, RestrictAccessAlertEnumName, applicant.custom_properties.is_there_an_access_alert, connection)
            .RestrictAccessType = GetFunnelEnumSDBValue(Of String)(LeadEnumsOwner, RestrictAccessTypeEnumName, applicant.custom_properties.access_type, connection)
            .RestrictActivityAlert = GetFunnelEnumSDBValue(Of Boolean?)(LeadEnumsOwner, RestrictActivityAlertEnumName, applicant.custom_properties.activity_alert, connection)

            ' Will also retrieve step-parents or adoptive parents of each type, if present
            Dim mother = GetParentCarer(applicant.child.guardians, CarerContactType.Mother)
            .MotherCensusMappings = GetParentCensusMappings(mother, connection)
            Dim father = GetParentCarer(applicant.child.guardians, CarerContactType.Father)
            .FatherCensusMappings = GetParentCensusMappings(father, connection)

            ' Parent/carers
            Dim primaryParentCarer = GetParentCarer(applicant.child.guardians, CarerContactType.ParentCarerA)
            .ParentCarerAMappings = GetParentCarerMappings(primaryParentCarer, connection)
            Dim secondaryParentCarer = GetParentCarer(applicant.child.guardians, CarerContactType.ParentCarerB)
            .ParentCarerBMappings = GetParentCarerMappings(secondaryParentCarer, connection)

            ' TODO: Grab any other mappings here
         End With

         Return mappings
      End Function


      Private Function GetParentCensusMappings(parent As Guardian, connection As SqlConnection) As FunnelSDBParentCensusMappings
         Dim censusMappings As New FunnelSDBParentCensusMappings()
         If (parent IsNot Nothing) Then
            With censusMappings
               GetFunnelEnumDisplayNameSDBValue(ParentCarerEnumsOwner, ParentCarerCountryOfBirthEnumName, parent.custom_properties.country_of_birth,
                                                .CountryOfBirthDisplayName, .CountryOfBirth, connection)
               .SpeakNonEnglishAtHome = GetFunnelEnumSDBValue(Of Boolean?)(ParentCarerEnumsOwner, ParentCarerSpeakNonEnglishAtHomeEnumName, parent.custom_properties.language_other_than_english_spoken_at_home, connection)
               GetFunnelEnumDisplayNameSDBValue(ParentCarerEnumsOwner, ParentCarerLanguageEnumName, parent.custom_properties.language_other_than_english,
                                                .LanguageDisplayName, .Language, connection)
               GetFunnelEnumDisplayNameSDBValue(ParentCarerEnumsOwner, ParentCarerSchoolEducationEnumName, parent.custom_properties.school_education,
                                                .SchoolEducationDisplayName, .SchoolEducation, connection)
               GetFunnelEnumDisplayNameSDBValue(ParentCarerEnumsOwner, ParentCarerNonSchoolEducationEnumName, parent.custom_properties.qualification,
                                                .NonSchoolEducationDisplayName, .NonSchoolEducation, connection)
               GetFunnelEnumDisplayNameSDBValue(ParentCarerEnumsOwner, ParentCarerOccupationGroupEnumName, parent.custom_properties.occupation_group,
                                                .OccupationGroupDisplayName, .OccupationGroup, connection)
            End With
         End If

         Return censusMappings
      End Function


      Private Function GetParentCarerMappings(parentCarer As Guardian, connection As SqlConnection) As FunnelSDBCarerContactMappings
         Dim carerContactMappings As New FunnelSDBCarerContactMappings()
         If (parentCarer IsNot Nothing) Then
            With carerContactMappings
               .Salutation = GetFunnelEnumSDBValue(Of String)(AccountEnumsOwner, SalutationsEnumName, parentCarer.salutation?.uuid.ToString(), connection)
               GetFunnelEnumDisplayNameSDBValue(AccountEnumsOwner, RelationshipEnumName, parentCarer.pivot.relationship?.uuid.ToString(),
                                                .RelationshipDisplayName, .Relationship, connection)
            End With
         End If

         Return carerContactMappings
      End Function


      Private Class FieldInspector
         Friend modificationStatus As RecordModificationStatus


         Sub New(modificationStatus As RecordModificationStatus)
            Me.modificationStatus = modificationStatus
         End Sub


         Function CheckFieldUpdate(Of T As Structure)(fieldName As String, sourceValue As T?, originalValue As T?) As T?
            modificationStatus.SetFieldModificationStatus(fieldName, If(Object.Equals(sourceValue, originalValue), FieldModificationStatus.NoModification, FieldModificationStatus.Modification))
            Return sourceValue
         End Function


         Function CheckFieldUpdate(fieldName As String, sourceValue As String, maximumLength As Integer, originalValue As String,
                                Optional comparisonType As StringComparison = StringComparison.CurrentCultureIgnoreCase) As String
            ' First check for the likely case of equality, and in addition treat nulls as equal to the empty string for the sake of displaying information...
            If (String.Equals(If(sourceValue, ""), If(originalValue, ""), comparisonType)) Then
               modificationStatus.SetFieldModificationStatus(fieldName, FieldModificationStatus.NoModification)
               ' .. But if the source value is null, be sure to return null
               Return sourceValue
            ElseIf (sourceValue IsNot Nothing) Then
               ' There's been a change: update the field but check for truncation
               Dim resultingStringLength = Math.Min(sourceValue.Length, maximumLength)
               If (sourceValue.Length = resultingStringLength) Then
                  modificationStatus.SetFieldModificationStatus(fieldName, FieldModificationStatus.Modification)
               Else
                  modificationStatus.SetFieldModificationStatus(fieldName, FieldModificationType.ModificationWithTruncation, sourceValue)
               End If
               Return sourceValue.Substring(0, resultingStringLength)
            Else
               ' The source value is null, and we know it's different to the original value
               modificationStatus.SetFieldModificationStatus(fieldName, FieldModificationStatus.Modification)
               Return Nothing
            End If
         End Function


         Function CheckFieldUpdate(fieldName As String, sourceValue As Date?, originalValue As Date?) As Date?
            ' We're only interested in the date component of the field
            modificationStatus.SetFieldModificationStatus(fieldName, If(Object.Equals(sourceValue?.Date, originalValue?.Date), FieldModificationStatus.NoModification, FieldModificationStatus.Modification))
            Return sourceValue?.Date
         End Function
      End Class


      Private Function PopulateFunnelStudentRecordSet(enrolmentYear As Decimal, applicantDetails As Lead, funnelMappings As FunnelSDBMappings,
                                                   Optional existingStudentRecord As SDBStudentRecordSet = Nothing) As SDBStudentRecordSet
         Dim funnelRecordSet As New SDBStudentRecordSet()
         With funnelRecordSet
            .Student = PopulateSDBStudentFromFunnel(applicantDetails, funnelMappings, existingStudentRecord?.Student?.StudentID, existingStudent:=existingStudentRecord?.Student)
            .Enrolment = PopulateSDBStudentEnrolmentFromFunnel(applicantDetails, funnelMappings, enrolmentYear:=enrolmentYear)

            If (IsSchoolBasedCategoryCode(.Student.CategoryCode)) Then
               ' School-based students have their school's address as their postal address...
               ' ...and the postal address that they enter in Funnel needs to be set as their residential address, to match up with the existing scheme
               .ResidentialAddress = PopulateSDBAddressFromFunnel(applicantDetails, funnelMappings, PostalAddressLabel, funnelMappings.PostalAddressCountry,
                                                               existingAddress:=existingStudentRecord?.ResidentialAddress)
            Else
               .PostalAddress = PopulateSDBAddressFromFunnel(applicantDetails, funnelMappings, PostalAddressLabel, funnelMappings.PostalAddressCountry,
                                                          existingAddress:=existingStudentRecord?.PostalAddress)
               If ((Not funnelMappings.ResidentialAddressSameAsPostalAddress.HasValue) OrElse (Not funnelMappings.ResidentialAddressSameAsPostalAddress)) Then
                  .ResidentialAddress = PopulateSDBAddressFromFunnel(applicantDetails, funnelMappings, ResidentialAddressLabel, funnelMappings.ResidentialAddressCountry,
                                                                  existingAddress:=existingStudentRecord?.ResidentialAddress)
               End If
            End If

            Dim parentCarerA = GetParentCarer(applicantDetails.child.guardians, CarerContactType.ParentCarerA)
            If (parentCarerA IsNot Nothing) Then
               .ParentCarerA = PopulateSDBStudentCarerContactFromFunnel(parentCarerA, funnelMappings.ParentCarerAMappings, existingCarerContact:=existingStudentRecord?.ParentCarerA)
            End If
            Dim parentCarerB = GetParentCarer(applicantDetails.child.guardians, CarerContactType.ParentCarerB)
            If (parentCarerB IsNot Nothing) Then
               .ParentCarerB = PopulateSDBStudentCarerContactFromFunnel(parentCarerB, funnelMappings.ParentCarerBMappings, existingCarerContact:=existingStudentRecord?.ParentCarerB)
            End If

            .MedicalDetails = PopulateSDBStudentMedicalDetailsFromFunnel(applicantDetails, funnelMappings, existingMedicalDetails:=existingStudentRecord?.MedicalDetails)
            .CensusDetails = PopulateSDBStudentCensusDetailsFromFunnel(applicantDetails, funnelMappings, existingCensusDetails:=existingStudentRecord?.CensusDetails)
         End With

         Return funnelRecordSet
      End Function


      Private Function PopulateSDBStudentFromFunnel(applicantDetails As Lead, funnelMappings As FunnelSDBMappings, Optional studentID As Decimal? = Nothing,
                                                 Optional postalAddressID As Decimal? = Nothing, Optional residentialAddressID As Decimal? = Nothing,
                                                 Optional updatedBy As String = Nothing, Optional existingStudent As SDBStudent = Nothing) As SDBStudent
         Dim student = New SDBStudent()
         With student
            .RecordModificationStatus.RecordModificationType = If(existingStudent IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .StudentID = studentID

            .FirstName = fieldInspector.CheckFieldUpdate(NameOf(.FirstName), applicantDetails.child.first_name, 30, existingStudent?.FirstName)
            Dim preferredName As String = Nothing
            If (Not String.Equals(applicantDetails.custom_properties.preferred_name, applicantDetails.child.first_name, StringComparison.CurrentCultureIgnoreCase)) Then
               preferredName = applicantDetails.custom_properties.preferred_name
            End If
            .PreferredName = fieldInspector.CheckFieldUpdate(NameOf(.PreferredName), preferredName, 50, existingStudent?.PreferredName)
            .MiddleName = fieldInspector.CheckFieldUpdate(NameOf(.MiddleName), applicantDetails.child.middle_name, 30, existingStudent?.MiddleName)
            .Surname = fieldInspector.CheckFieldUpdate(NameOf(.Surname), applicantDetails.child.last_name, 30, existingStudent?.Surname)
            .DateOfBirth = fieldInspector.CheckFieldUpdate(NameOf(.DateOfBirth), applicantDetails.child.date_of_birth, existingStudent?.DateOfBirth)
            .Gender = fieldInspector.CheckFieldUpdate(NameOf(.Gender), funnelMappings.Gender, 1, existingStudent?.Gender)
            .GenderDisplayName = applicantDetails.child.gender.name
            .GenderSelfDescribed = fieldInspector.CheckFieldUpdate(NameOf(.GenderSelfDescribed), funnelMappings.GenderSelfDescribed, 30, existingStudent?.GenderSelfDescribed)
            ' Note: Length 250 on student table, but only 60 on the address table where it will also be stored
            .StudentEmail = fieldInspector.CheckFieldUpdate(NameOf(.StudentEmail), applicantDetails.child.email, 60, existingStudent?.StudentEmail)
            .StudentMobile = fieldInspector.CheckFieldUpdate(NameOf(.StudentMobile), GetPhoneNumber(applicantDetails.child.phone_numbers, MobilePhoneNumberLabel), 15, existingStudent?.StudentMobile)

            .CategoryCode = fieldInspector.CheckFieldUpdate(NameOf(.CategoryCode), funnelMappings.EnrolmentCategory, 10, existingStudent?.CategoryCode)
            .SubcategoryCode = fieldInspector.CheckFieldUpdate(NameOf(.SubcategoryCode), funnelMappings.EnrolmentSubcategory, 10, existingStudent?.SubcategoryCode)
            Dim funnelFullCategoryCode = GetFullCategoryCode(.CategoryCode, .SubcategoryCode)
            .FullCategoryCode = fieldInspector.CheckFieldUpdate(NameOf(.FullCategoryCode), funnelFullCategoryCode, Integer.MaxValue, existingStudent?.FullCategoryCode)
            .EnrolmentCategoryDisplayName = funnelMappings.EnrolmentCategoryDisplayName

            If (IsSchoolBasedEnrolmentApplication(applicantDetails.custom_properties.student_enrolment_type)) Then
               .HomeSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.HomeSchoolID), funnelMappings.HomeSchoolID, existingStudent?.HomeSchoolID)
               .HomeSchoolDisplayName = funnelMappings.HomeSchoolDisplayName
               ' The attending school will be the same as the home school
               .AttendingSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.AttendingSchoolID), funnelMappings.HomeSchoolID, existingStudent?.AttendingSchoolID)
               .AttendingSchoolDisplayName = funnelMappings.HomeSchoolDisplayName
            ElseIf (IsSharedEnrolmentApplication(applicantDetails.custom_properties.enrolment_type)) Then
               ' TODO: Confirm that we're retrieving the correct home school ID here from Funnel, for shared enrolments
               .HomeSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.HomeSchoolID), funnelMappings.HomeSchoolID, existingStudent?.HomeSchoolID)
               .HomeSchoolDisplayName = funnelMappings.HomeSchoolDisplayName
               .AttendingSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.AttendingSchoolID), VSVSchoolID, existingStudent?.AttendingSchoolID)
               .AttendingSchoolDisplayName = VSVSchoolDisplayName
            Else
               .HomeSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.HomeSchoolID), VSVSchoolID, existingStudent?.HomeSchoolID)
               .HomeSchoolDisplayName = VSVSchoolDisplayName
               .AttendingSchoolID = fieldInspector.CheckFieldUpdate(NameOf(.AttendingSchoolID), VSVSchoolID, existingStudent?.AttendingSchoolID)
               .AttendingSchoolDisplayName = VSVSchoolDisplayName
            End If

            .PostalAddressID = postalAddressID
            .ResidentialAddressID = residentialAddressID

            ' TODO: Validate the VCAA number; captured by school-based form only; exactly 9 characters in length - 8 numeric, one letter; look at the old online enrolments system as a reference for validating it
            .VCAANumber = fieldInspector.CheckFieldUpdate(NameOf(.VCAANumber), applicantDetails.custom_properties.vcaa_no, 10, existingStudent?.VCAANumber)

            .EnrolmentComments = fieldInspector.CheckFieldUpdate(NameOf(.EnrolmentComments), applicantDetails.custom_properties.why_are_you_enrolling_at_vsv, 255, existingStudent?.EnrolmentComments)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return student
      End Function


      Private Function PopulateSDBStudentEnrolmentFromFunnel(applicantDetails As Lead, funnelMappings As FunnelSDBMappings,
                                                          Optional studentID As Decimal? = Nothing, Optional enrolmentYear As Decimal? = Nothing,
                                                          Optional updatedBy As String = Nothing) As SDBStudentEnrolment
         Dim enrolment As New SDBStudentEnrolment()
         With enrolment
            .RecordModificationStatus.RecordModificationType = RecordModificationType.Insert
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .StudentID = studentID
            .EnrolmentYear = enrolmentYear

            .YearLevel = funnelMappings.YearLevel
            .YearLevelDisplayName = applicantDetails.proposed_year_level.name

            'Friend SchoolSupervisorID As Integer? ' TODO: Find out how this will need to be updated. Only once the Principal's Referral Form has been completed, and supervisor details attached to the Lead?
            ' If that's how it works: need to detect when to reuse the same carer ID for different students from the same school, ie. avoid duplicates

            'Friend ReceiptNumber As String   ' TODO: Find out what we need to set here, as there are some invoicing reports that depend on this field; maximum 10 chars
            'Friend EligibleForFunding As Boolean?   ' TODO: Apply logic for this field; TAFE students and > age 21 are ineligible. Any other criteria to consider?

            .PrivacyConsent = fieldInspector.CheckFieldUpdate(NameOf(.PrivacyConsent), funnelMappings.PrivacyConsent, Nothing)
            .PrivacyConsentDisplayName = YesNoNull(.PrivacyConsent)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return enrolment
      End Function


      Private Function PopulateSDBAddressFromFunnel(applicantDetails As Lead, funnelMappings As FunnelSDBMappings, addressTypeLabel As String, addressCountry As String,
                                                 Optional addressID As Decimal? = Nothing, Optional updatedBy As String = Nothing,
                                                 Optional existingAddress As SDBAddress = Nothing) As SDBAddress
         Dim funnelAddress = GetAddress(applicantDetails.child.addresses, addressTypeLabel)
         If (funnelAddress Is Nothing) Then
            Return Nothing
         End If

         Dim address = New SDBAddress()
         With address
            If (existingAddress?.LinkedSchoolID IsNot Nothing) Then
               ' Don't update the address when it's linked to a school. Force a new address record to be created
               .RecordModificationStatus.RecordModificationType = RecordModificationType.Insert
            Else
               .RecordModificationStatus.RecordModificationType = If(existingAddress IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            End If
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .AddressID = addressID

            .Addressee = fieldInspector.CheckFieldUpdate(NameOf(.Addressee), GetAddressee(applicantDetails.child), 60, existingAddress?.Addressee)

            ' TODO: AGENT field. Check circumstances for writing to the agent field, including if/when we should write c/o parent
            ' Agent is maxlength 60

            .AddressLineOne = fieldInspector.CheckFieldUpdate(NameOf(.AddressLineOne), funnelAddress.line_1, 50, existingAddress?.AddressLineOne)
            .AddressLineTwo = fieldInspector.CheckFieldUpdate(NameOf(.AddressLineTwo), funnelAddress.line_2, 50, existingAddress?.AddressLineTwo)
            .SuburbTown = fieldInspector.CheckFieldUpdate(NameOf(.SuburbTown), funnelAddress.locality, 30, existingAddress?.SuburbTown)
            .Postcode = fieldInspector.CheckFieldUpdate(NameOf(.Postcode), funnelAddress.postal_code, 10, existingAddress?.Postcode)
            .State = fieldInspector.CheckFieldUpdate(NameOf(.State), funnelAddress.administrative_area, 20, existingAddress?.State)

            .Country = fieldInspector.CheckFieldUpdate(NameOf(.Country), addressCountry, 20, existingAddress?.Country)

            ' The existing data for direct enrolments addresses (postal and residential) suggests that phone A is usually parent carer A's home phome,
            ' while phone B Is the student's mobile
            ' One of our goals should be to present the enrolments staff with as few highlighted record differences to consider as possible
            ' In the existing VSV-based student data there are plenty of blanks for both numbers against, so it's clearly not a critical function
            Dim phoneNumberOne As String = Nothing
            Dim phoneNumberTwo As String = Nothing
            Dim parentCarerA = GetParentCarer(applicantDetails.child.guardians, CarerContactType.ParentCarerA)
            If (parentCarerA IsNot Nothing) Then
               phoneNumberOne = GetPhoneNumber(parentCarerA.phone_numbers, HomePhoneNumberLabel)
            End If
            phoneNumberTwo = GetPhoneNumber(applicantDetails.child.phone_numbers, MobilePhoneNumberLabel)
            .PhoneNumberOne = fieldInspector.CheckFieldUpdate(NameOf(.PhoneNumberOne), phoneNumberOne, 15, existingAddress?.PhoneNumberOne)
            .PhoneNumberTwo = fieldInspector.CheckFieldUpdate(NameOf(.PhoneNumberTwo), phoneNumberTwo, 15, existingAddress?.PhoneNumberTwo)

            ' And for emails, it's the reverse: use the student email as the primary, and parent carer A's email as the secondary
            .EmailAddressOne = fieldInspector.CheckFieldUpdate(NameOf(.EmailAddressOne), applicantDetails.child.email, 60, existingAddress?.EmailAddressOne)
            .EmailAddressTwo = fieldInspector.CheckFieldUpdate(NameOf(.EmailAddressTwo), parentCarerA?.email, 50, existingAddress?.EmailAddressTwo)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return address
      End Function


      Private Function GetCarerContactKeyDetailsFromFunnel(applicantDetails As Lead, carerContactType As CarerContactType) As SDBStudentCarerContact
         Dim carerContact = GetParentCarer(applicantDetails.child.guardians, carerContactType)
         If (carerContact IsNot Nothing) Then
            Dim sdbCarerContact = New SDBStudentCarerContact()
            With sdbCarerContact
               .FirstName = carerContact.first_name
               .Surname = carerContact.last_name
               .Email = carerContact.email
            End With

            Return sdbCarerContact
         End If

         Return Nothing
      End Function


      Private Function PopulateSDBStudentCarerContactFromFunnel(funnelCarerContact As Guardian, carerContactMappings As FunnelSDBCarerContactMappings,
                                                             Optional carerContactID As Decimal? = Nothing, Optional updatedBy As String = Nothing,
                                                             Optional existingCarerContact As SDBStudentCarerContact = Nothing) As SDBStudentCarerContact
         ' TODO: Supervisor contact types - their position and title
         Dim carerContact As New SDBStudentCarerContact()
         With carerContact
            .RecordModificationStatus.RecordModificationType = If(existingCarerContact IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .CarerID = carerContactID

            .Salutation = fieldInspector.CheckFieldUpdate(NameOf(.Salutation), carerContactMappings.Salutation, 10, existingCarerContact?.Salutation)
            .FirstName = fieldInspector.CheckFieldUpdate(NameOf(.FirstName), funnelCarerContact.first_name, 30, existingCarerContact?.FirstName)
            .Surname = fieldInspector.CheckFieldUpdate(NameOf(.Surname), funnelCarerContact.last_name, 30, existingCarerContact?.Surname)
            .Relationship = fieldInspector.CheckFieldUpdate(NameOf(.Relationship), carerContactMappings.Relationship, 2, existingCarerContact?.Relationship)
            .RelationshipDisplayName = carerContactMappings.RelationshipDisplayName

            Dim mobilePhone = GetPhoneNumber(funnelCarerContact.phone_numbers, MobilePhoneNumberLabel)
            Dim homePhone = GetPhoneNumber(funnelCarerContact.phone_numbers, HomePhoneNumberLabel)
            Dim workPhone = GetPhoneNumber(funnelCarerContact.phone_numbers, WorkPhoneNumberLabel)

            .Mobile = fieldInspector.CheckFieldUpdate(NameOf(.Mobile), mobilePhone, 20, existingCarerContact?.Mobile)
            .HomePhone = fieldInspector.CheckFieldUpdate(NameOf(.HomePhone), homePhone, 20, existingCarerContact?.HomePhone)
            .WorkPhone = fieldInspector.CheckFieldUpdate(NameOf(.WorkPhone), workPhone, 20, existingCarerContact?.WorkPhone)
            .Email = fieldInspector.CheckFieldUpdate(NameOf(.Email), funnelCarerContact.email, 250, existingCarerContact?.Email)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return carerContact
      End Function


      Private Function PopulateSDBStudentMedicalDetailsFromFunnel(applicantDetails As Lead, funnelMappings As FunnelSDBMappings, Optional studentID As Decimal? = Nothing,
                                                               Optional updatedBy As String = Nothing,
                                                               Optional existingMedicalDetails As SDBStudentMedicalDetails = Nothing) As SDBStudentMedicalDetails
         Dim medicalDetails As New SDBStudentMedicalDetails()
         With medicalDetails
            .RecordModificationStatus.RecordModificationType = If(existingMedicalDetails IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .StudentID = studentID

            .HearingImpaired = fieldInspector.CheckFieldUpdate(NameOf(.HearingImpaired), funnelMappings.HearingImpaired, existingMedicalDetails?.HearingImpaired)
            .VisionImpaired = fieldInspector.CheckFieldUpdate(NameOf(.VisionImpaired), funnelMappings.VisionImpaired, existingMedicalDetails?.VisionImpaired)
            .ASDAspergers = fieldInspector.CheckFieldUpdate(NameOf(.ASDAspergers), funnelMappings.ASDAspergers, existingMedicalDetails?.ASDAspergers)
            .IntellectualDisability = fieldInspector.CheckFieldUpdate(NameOf(.IntellectualDisability), funnelMappings.IntellectualDisability, existingMedicalDetails?.IntellectualDisability)
            .PhysicalDisability = fieldInspector.CheckFieldUpdate(NameOf(.PhysicalDisability), funnelMappings.PhysicalDisability, existingMedicalDetails?.PhysicalDisability)
            .SevereBehaviouralDisorder = fieldInspector.CheckFieldUpdate(NameOf(.SevereBehaviouralDisorder), funnelMappings.SevereBehaviouralDisorder, existingMedicalDetails?.SevereBehaviouralDisorder)
            .SevereLanguageDisorder = fieldInspector.CheckFieldUpdate(NameOf(.SevereLanguageDisorder), funnelMappings.SevereLanguageDisorder, existingMedicalDetails?.SevereLanguageDisorder)
            .MentalHealthCondition = fieldInspector.CheckFieldUpdate(NameOf(.MentalHealthCondition), funnelMappings.MentalHealthCondition, existingMedicalDetails?.MentalHealthCondition)
            .MentalHealthConditionDescription = fieldInspector.CheckFieldUpdate(NameOf(.MentalHealthConditionDescription), applicantDetails.custom_properties.diagnosed_mental_health_condition_details_d,
            200, existingMedicalDetails?.MentalHealthConditionDescription)
            .HasAllergyHistory = fieldInspector.CheckFieldUpdate(NameOf(.HasAllergyHistory), funnelMappings.HasAllergyHistory, existingMedicalDetails?.HasAllergyHistory)
            .AllergyHistoryDescription = fieldInspector.CheckFieldUpdate(NameOf(.AllergyHistoryDescription), applicantDetails.custom_properties.history_with_allergies,
            200, existingMedicalDetails?.AllergyHistoryDescription)
            .Anaphylaxis = fieldInspector.CheckFieldUpdate(NameOf(.Anaphylaxis), funnelMappings.Anaphylaxis, existingMedicalDetails?.Anaphylaxis)
            .DiagnosedWithAsthma = fieldInspector.CheckFieldUpdate(NameOf(.DiagnosedWithAsthma), funnelMappings.DiagnosedWithAsthma, existingMedicalDetails?.DiagnosedWithAsthma)
            .DiagnosedWithDiabetes = fieldInspector.CheckFieldUpdate(NameOf(.DiagnosedWithDiabetes), funnelMappings.DiagnosedWithDiabetes, existingMedicalDetails?.DiagnosedWithDiabetes)
            .DiagnosedWithEpilepsy = fieldInspector.CheckFieldUpdate(NameOf(.DiagnosedWithEpilepsy), funnelMappings.DiagnosedWithEpilepsy, existingMedicalDetails?.DiagnosedWithEpilepsy)
            .DiagnosedWithAnyOtherConditions = fieldInspector.CheckFieldUpdate(NameOf(.DiagnosedWithAnyOtherConditions), funnelMappings.DiagnosedWithAnyOtherConditions, existingMedicalDetails?.DiagnosedWithAnyOtherConditions)
            .OtherDiagnosedConditionsDescription = fieldInspector.CheckFieldUpdate(NameOf(.OtherDiagnosedConditionsDescription), applicantDetails.custom_properties.description_of_diagnosed_condition,
            200, existingMedicalDetails?.OtherDiagnosedConditionsDescription)
            .OtherMedicalIssuesDescription = fieldInspector.CheckFieldUpdate(NameOf(.OtherMedicalIssuesDescription), applicantDetails.custom_properties.medical_issues_which_vsv_should_be_aware_of_description,
            200, existingMedicalDetails?.OtherMedicalIssuesDescription)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return medicalDetails
      End Function


      Private Function PopulateSDBStudentCensusDetailsFromFunnel(applicantDetails As Lead, funnelMappings As FunnelSDBMappings, Optional studentID As Decimal? = Nothing,
                                                              Optional updatedBy As String = Nothing,
                                                              Optional existingCensusDetails As SDBStudentCensusData = Nothing) As SDBStudentCensusData
         Dim censusDetails As New SDBStudentCensusData()
         With censusDetails
            .RecordModificationStatus.RecordModificationType = If(existingCensusDetails IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .StudentID = studentID

            .CountryOfBirth = fieldInspector.CheckFieldUpdate(NameOf(.CountryOfBirth), funnelMappings.CountryOfBirth, existingCensusDetails?.CountryOfBirth)
            .CountryOfBirthDisplayName = funnelMappings.CountryOfBirthDisplayName

            If (funnelMappings.SpeakNonEnglishAtHome AndAlso (funnelMappings.FirstHomeLanguage IsNot Nothing)) Then
               .FirstHomeLanguage = fieldInspector.CheckFieldUpdate(NameOf(.FirstHomeLanguage), funnelMappings.FirstHomeLanguage, existingCensusDetails?.FirstHomeLanguage)
               .FirstHomeLanguageDisplayName = funnelMappings.FirstHomeLanguageDisplayName

               If (funnelMappings.SpeakEnglish) Then
                  ' Student speaks English as a second language
                  .OtherHomeLanguage = fieldInspector.CheckFieldUpdate(NameOf(.OtherHomeLanguage), EnglishLanguageCode, existingCensusDetails?.OtherHomeLanguage)
                  .OtherHomeLanguageDisplayName = "English"
               End If
            Else
               ' Student speaks English as their first language; leave the other language code blank
               ' Will also fall back to English if a contradictory or empty combination of values is selected, due to nullable type handling
               .FirstHomeLanguage = fieldInspector.CheckFieldUpdate(NameOf(.FirstHomeLanguage), EnglishLanguageCode, existingCensusDetails?.FirstHomeLanguage)
               .FirstHomeLanguageDisplayName = "English"
            End If

            .IndigenousStatus = fieldInspector.CheckFieldUpdate(NameOf(.IndigenousStatus), funnelMappings.IndigenousStatus, 1, existingCensusDetails?.IndigenousStatus)
            .IndigenousStatusDisplayName = funnelMappings.IndigenousStatusDisplayName

            .ResidentialStatus = fieldInspector.CheckFieldUpdate(NameOf(.ResidentialStatus), funnelMappings.ResidentialStatus, 1, existingCensusDetails?.ResidentialStatus)
            .ResidentialStatusDisplayName = funnelMappings.ResidentialStatusDisplayName

            If (.ResidentialStatus?.Equals(TemporaryResidentCode)) Then
               .VisaSubClassInputText = applicantDetails.custom_properties.visa_sub_class
               Dim visaSubClassParsedValue As UShort
               If (UShort.TryParse(.VisaSubClassInputText, visaSubClassParsedValue) AndAlso (visaSubClassParsedValue <= VisaSubClassMaximumValue)) Then
                  Dim visaSubClass As Decimal = visaSubClassParsedValue
                  .VisaSubClass = fieldInspector.CheckFieldUpdate(NameOf(.VisaSubClass), visaSubClass, existingCensusDetails?.VisaSubClass)
               Else
                  .RecordModificationStatus.SetFieldModificationStatus(NameOf(.VisaSubClass), FieldModificationType.Invalid)
                  ' TODO: Prevent the process from going any further. The invalid item for the lead needs to be amended in Funnel.
               End If

               .VisaSector = fieldInspector.CheckFieldUpdate(NameOf(.VisaSector), applicantDetails.custom_properties.visa_sector, 50, existingCensusDetails?.VisaSector)
               ' The statistical code needs to be set to 1 for temporary residents, to keep the census page happy
               .VisaStatisticalCode = "1"

               ' And per Anthea's advice on how these legacy fields are currently handled, set them to yesterday
               ' As above, the census page will squeal if they're blank for a non-permanent resident
               .DateArrivedInAustralia = Date.Now.AddDays(-1)
               .DateStartedInAustralia = .DateArrivedInAustralia
            End If

            .HouseholdStatus = fieldInspector.CheckFieldUpdate(NameOf(.HouseholdStatus), funnelMappings.HouseholdStatus, existingCensusDetails?.HouseholdStatus)
            .HouseholdStatusDisplayName = funnelMappings.HouseholdStatusDisplayName

            .RestrictAccessAtRisk = fieldInspector.CheckFieldUpdate(NameOf(.RestrictAccessAtRisk), funnelMappings.RestrictAccessAtRisk, existingCensusDetails?.RestrictAccessAtRisk)
            .RestrictAccessAlert = fieldInspector.CheckFieldUpdate(NameOf(.RestrictAccessAlert), funnelMappings.RestrictAccessAlert, existingCensusDetails?.RestrictAccessAlert)
            .RestrictAccessType = fieldInspector.CheckFieldUpdate(NameOf(.RestrictAccessType), funnelMappings.RestrictAccessType, 200, existingCensusDetails?.RestrictAccessType)
            .RestrictAccessDescription = fieldInspector.CheckFieldUpdate(NameOf(.RestrictAccessDescription), applicantDetails.custom_properties.describe_any_access_restrictions, 200, existingCensusDetails?.RestrictAccessDescription)
            .RestrictActivityAlert = fieldInspector.CheckFieldUpdate(NameOf(.RestrictActivityAlert), funnelMappings.RestrictActivityAlert, existingCensusDetails?.RestrictActivityAlert)
            .RestrictActivityDescription = fieldInspector.CheckFieldUpdate(NameOf(.RestrictActivityDescription), applicantDetails.custom_properties.describe_the_activity_restriction, 200, existingCensusDetails?.RestrictActivityDescription)

            ' TODO: The previous school ID and display name
            .DateLastAttendedSchool = fieldInspector.CheckFieldUpdate(NameOf(.DateLastAttendedSchool), applicantDetails.custom_properties.date_last_attended_school, existingCensusDetails?.DateLastAttendedSchool)

            .MotherCensusData = PopulateSDBParentCensusDetailsFromFunnel(funnelMappings.MotherCensusMappings, existingCensusDetails?.MotherCensusData)
            .FatherCensusData = PopulateSDBParentCensusDetailsFromFunnel(funnelMappings.FatherCensusMappings, existingCensusDetails?.FatherCensusData)

            .LastAlteredBy = updatedBy
            .LastAlteredDate = Date.Now()
         End With

         Return censusDetails
      End Function


      Private Function PopulateSDBParentCensusDetailsFromFunnel(parentMappings As FunnelSDBParentCensusMappings,
                                                             Optional existingCensusDetails As SDBParentCensusData = Nothing) As SDBParentCensusData
         Dim parentCensusData As New SDBParentCensusData()
         With parentCensusData
            .RecordModificationStatus.RecordModificationType = If(existingCensusDetails IsNot Nothing, RecordModificationType.Update, RecordModificationType.Insert)
            Dim fieldInspector As New FieldInspector(.RecordModificationStatus)

            .CountryOfBirth = fieldInspector.CheckFieldUpdate(NameOf(.CountryOfBirth), parentMappings.CountryOfBirth, existingCensusDetails?.CountryOfBirth)
            .CountryOfBirthDisplayName = parentMappings.CountryOfBirthDisplayName

            If (parentMappings.SpeakNonEnglishAtHome AndAlso (parentMappings.Language IsNot Nothing)) Then
               .Language = fieldInspector.CheckFieldUpdate(NameOf(.Language), parentMappings.Language, existingCensusDetails?.Language)
               .LanguageDisplayName = parentMappings.LanguageDisplayName
            Else
               ' Will also fall back to English if a contradictory or empty combination of values is selected, due to nullable type handling
               .Language = fieldInspector.CheckFieldUpdate(NameOf(.Language), EnglishLanguageCode, existingCensusDetails?.Language)
               .LanguageDisplayName = "English"
            End If

            .SchoolEducation = fieldInspector.CheckFieldUpdate(NameOf(.SchoolEducation), parentMappings.SchoolEducation, 1, existingCensusDetails?.SchoolEducation)
            .SchoolEducationDisplayName = parentMappings.SchoolEducationDisplayName

            .NonSchoolEducation = fieldInspector.CheckFieldUpdate(NameOf(.NonSchoolEducation), parentMappings.NonSchoolEducation, 1, existingCensusDetails?.NonSchoolEducation)
            .NonSchoolEducationDisplayName = parentMappings.NonSchoolEducationDisplayName

            .OccupationGroup = fieldInspector.CheckFieldUpdate(NameOf(.OccupationGroup), parentMappings.OccupationGroup, 1, existingCensusDetails?.OccupationGroup)
            .OccupationGroupDisplayName = parentMappings.OccupationGroupDisplayName
         End With

         Return parentCensusData
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin SDB objects
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Class FunnelLeadSDBImportStatus
         ' The name is to be used for display purposes only here
         Friend ApplicantName As String

         Friend FunnelTargetEnrolmentYear As Decimal
         Friend FunnelPipelineStageDisplayName As String
         Friend FunnelEnrolmentFormDisplayName As String
         Friend FunnelEnrolmentCategoryDisplayName As String
         Friend FunnelIsSharedEnrolment As Boolean
         Friend FunnelYearLevelDisplayName As String

         Friend Status As String

         Friend AcceptedStudentID As Decimal?
         Friend AcceptedExistingStudent As Boolean

         Friend RejectedReasonID As String
         Friend RejectedReasonOther As String

         Friend ActionedBy As String
         Friend ActionedDate As Date?
         Friend ActionedPipelineStageID As Guid?
         Friend ActionedPipelineStageDisplayName As String
      End Class


      Enum FieldMatchStrength
         NoData
         NoMatch
         MatchWithPossibleDataError
         Match
      End Enum


      Class SDBStudentMatch
         Implements IComparable(Of SDBStudentMatch)

         Friend StudentID As Decimal
         Friend FirstName As String
         Friend PreferredName As String
         Friend MiddleName As String
         Friend Surname As String
         Friend DateOfBirth As Date
         Friend Email As String
         Friend Mobile As String

         Friend EnrolmentCategory As String
         Friend HomeSchool As String

         Friend LastEnrolmentYear As Decimal
         Friend LEYYearLevel As String
         Friend LEYEnrolmentDate As Date
         Friend LEYEnrolmentStatus As String
         Friend LEYWithdrawalDate As Date?
         Friend LEYWithdrawalReasonID As Decimal?

         Friend FirstNameMatchStrength As FieldMatchStrength
         Friend PreferredNameMatchStrength As FieldMatchStrength
         Friend MiddleNameMatchStrength As FieldMatchStrength
         Friend SurnameMatchStrength As FieldMatchStrength
         Friend DateOfBirthMatchStrength As FieldMatchStrength
         Friend GenderMatchStrength As FieldMatchStrength
         Friend EmailMatchStrength As FieldMatchStrength
         Friend MobileMatchStrength As FieldMatchStrength

         Friend StudentMatchStrengthScore As Integer


         Public Function CompareTo(other As SDBStudentMatch) As Integer Implements IComparable(Of SDBStudentMatch).CompareTo
            ' Sort by strongest matches first, then by student ID
            Dim matchStrengthComparison = -StudentMatchStrengthScore.CompareTo(other.StudentMatchStrengthScore)
            Return If(matchStrengthComparison <> 0, matchStrengthComparison, StudentID.CompareTo(other.StudentID))
         End Function
      End Class


      Enum RecordModificationType
         NoModification
         Insert
         Update
      End Enum


      Class RecordModificationStatus
         Friend RecordModificationType As RecordModificationType = RecordModificationType.NoModification
         Friend ReadOnly FieldModificationStatus As New Dictionary(Of String, FieldModificationStatus)

         Friend Shared ReadOnly NoRecordModification As RecordModificationStatus = New RecordModificationStatus()


         Sub SetFieldModificationStatus(field As String, modificationStatus As FieldModificationStatus)
            FieldModificationStatus(field) = modificationStatus
         End Sub


         Sub SetFieldModificationStatus(field As String, fieldModificationType As FieldModificationType)
            FieldModificationStatus(field) = New FieldModificationStatus(fieldModificationType)
         End Sub


         Sub SetFieldModificationStatus(field As String, fieldModificationType As FieldModificationType, preTruncatedValue As String)
            FieldModificationStatus(field) = New FieldModificationStatus(fieldModificationType, preTruncatedValue)
         End Sub
      End Class


      Enum FieldModificationType
         NoModification
         Modification
         ModificationWithTruncation
         ModificationWithUnsupportedCharacters
         Invalid
      End Enum


      Class FieldModificationStatus
         Friend ReadOnly FieldModificationType As FieldModificationType
         Friend ReadOnly PreTruncatedValue As String

         ' Shared, commonly used instances
         Friend Shared ReadOnly NoModification As FieldModificationStatus = New FieldModificationStatus(FieldModificationType.NoModification)
         Friend Shared ReadOnly Modification As FieldModificationStatus = New FieldModificationStatus(FieldModificationType.Modification)


         Sub New(fieldModificationType As FieldModificationType)
            Me.FieldModificationType = fieldModificationType
         End Sub


         Sub New(fieldModificationType As FieldModificationType, preTruncatedValue As String)
            Me.FieldModificationType = fieldModificationType
            Me.PreTruncatedValue = preTruncatedValue
         End Sub
      End Class


      Enum SDBEnrolmentCategory
         School
         MedicalPhysical
         MedicalSocialEmotional
         TravelDomestic
         TravelOverseas
         Sport
         DanceArts
         YoungAdult
         Distance
         PreviouslyHomeSchooled
         Other
      End Enum


      Class SDBStudent
         Friend StudentID As Decimal?
         Friend FirstName As String
         Friend PreferredName As String
         Friend MiddleName As String
         Friend Surname As String
         Friend DateOfBirth As Date?
         Friend Gender As String
         Friend GenderSelfDescribed As String
         Friend StudentEmail As String
         Friend StudentMobile As String

         Friend CategoryCode As String
         Friend SubcategoryCode As String
         Friend FullCategoryCode As String ' Combined convenience field for detecting any category code changes

         Friend PostalAddressID As Decimal? ' Identity from SDB address after inserting the postal address
         Friend ResidentialAddressID As Decimal? ' If Lead.CP.address_in_australia_same_as_postal then use above otherwise insert; need to consider how an update will affect this logic
         Friend ResidentialAddressSameAsPostalAddress As Boolean
         Friend SACAddressID As Decimal? ' TODO: This is an unknown for now, it might not be there in Funnel

         Friend HomeSchoolID As Decimal?
         Friend AttendingSchoolID As Decimal?
         Friend ExtraOrganisationID As String ' Yes, this is a varchar in the database...

         Friend ParentCarerAID As Integer? ' Note: These IDs are decimals on the carer contact table
         Friend ParentCarerBID As Integer?

         Friend VCAANumber As String
         Friend EnrolmentComments As String

         ' Non-Funnel fields that need to override database defaults on insert
         Friend VSNEnrolledBefore As String = "Y"

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' Display names
         Friend EnrolmentCategoryDisplayName As String
         Friend GenderDisplayName As String
         Friend HomeSchoolDisplayName As String
         Friend AttendingSchoolDisplayName As String
         Friend ExtraOrganisationDisplayName As String

         ' TODO:
         ' Matt had mentioned the need for the SAC address to Timothy during a form review meeting, but I'm not sure that it was being added
         ' Need to set the ORGANISATION_SCHOOL_ID for sportsperf students


         ReadOnly Property IsNew As Boolean
            Get
               Return (StudentID Is Nothing)
            End Get
         End Property
      End Class


      Class SDBAddress
         Friend AddressID As Decimal?
         Friend Addressee As String
         Friend Agent As String
         Friend AddressLineOne As String
         Friend AddressLineTwo As String
         Friend SuburbTown As String
         Friend Postcode As String
         Friend State As String
         Friend Country As String
         Friend PhoneNumberOne As String
         Friend PhoneNumberTwo As String
         Friend EmailAddressOne As String
         Friend EmailAddressTwo As String

         ' Non-Funnel fields that need to override database defaults on insert
         Friend FaxNumber As String

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' School-based students usually have their postal address set to that of their school
         ' It's also rare but possible for students to have their residential address linked to a school, eg. international students
         ' In these instances, we want to provide a safeguard against updating the address details
         Friend LinkedSchoolID As Decimal?
         Friend LinkedSchoolDisplayName As String
      End Class


      Enum CarerContactType
         ParentCarerA
         ParentCarerB
         Mother
         Father
         SchoolBasedSchoolSupervisor
         SACSupervisor
         AgencySupervisor
      End Enum


      Enum CarerContactMatchType
         ParentCarer
         Supervisor
      End Enum


      Class SDBStudentCarerContact
         Friend CarerID As Decimal? ' Carer may already exist
         Friend Salutation As String
         Friend Surname As String
         Friend FirstName As String
         Friend Relationship As String ' In the case of school supervisors it will need to be SS
         Friend HomePhone As String
         Friend WorkPhone As String
         Friend Mobile As String
         Friend Email As String
         Friend SupervisorPosition As String ' Check length 50; TODO: investigate further how this might need to be restricted on Funnel to set lookup values
         Friend SupervisorPositionOther As String ' TODO: As above, and check length 50

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' Display names
         Friend RelationshipDisplayName As String

         Friend StudentConnections As New List(Of SDBStudentCarerContactConnection)

         Friend IsMatchedRecord As Boolean

         ' TODO:
         ' Check how and when to do the matches on existing supervisors
         ' We might also need to get Digistorm to add lookup values for the supervisor types
         ' Investigate again what the existing school supervisor sync process does during online enrolments: sp_toOnlineEnrol_syncSchoolSupervisors
         ' How will agency supervisors (sportsperf) need to be handled?
         ' For shared enrolments (non-school-based), one of the entries added to this table is their school supervisor, and the relationship needs to be "SS"
      End Class


      Class SDBStudentCarerContactConnection
         Friend StudentID As Decimal
         Friend EnrolmentYear As Decimal
         Friend ConnectionType As String
         Friend Name As String
         Friend EnrolmentCategoryDisplayName As String
         Friend YearLevelDisplayName As String
         Friend EnrolmentStatus As String


         Friend Function GetConnectionTypeDisplayName(relationshipDisplayName As String) As String
            Select Case ConnectionType
               Case ParentCarerAConnectionType
                  Return "Parent/Carer A"
               Case ParentCarerBConnectionType
                  Return "Parent/Carer B"
               Case SchoolSupervisorConnectionType
                  Return relationshipDisplayName
            End Select

            Return Nothing
         End Function
      End Class


      Class SDBStudentEnrolment
         ' Records are only to be inserted into this table by the enrolment process, and not updated
         Friend StudentID As Decimal?
         Friend YearLevel As Short?

         Friend SchoolSupervisorID As Integer? ' TODO: Find out how this will need to be updated. Only once the Principal's Referral Form has been completed, and supervisor details attached to the Lead?
         ' If that's how it works, I might need to detect when to reuse the same carer ID for different students from the same school
         ' Don't forget that this ID also needs to be set for non-school-based shared enrolments

         Friend ReceiptNumber As String   ' TODO: Find out what we need to set here, as there are some invoicing reports that depend on this field; maximum 10 chars
         Friend EligibleForFunding As Boolean?   ' TODO: Apply logic for this field; TAFE students and > age 21 are ineligible
         Friend PrivacyConsent As Boolean?

         ' Non-Funnel fields that need to override database defaults on insert
         Friend EnrolmentYear As Decimal? = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend EnrolmentDate As Date = Date.Now
         Friend EnrolmentStatus As String = "E"
         Friend Campus As String = "D"
         Friend LearningAdvisorID As String = "N-A"
         Friend SubSchool As String
         Friend DECVBalance As Decimal
         Friend VSLBalance As Decimal
         Friend DocsLastReviewedDate As Date = Date.Now

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' Display names
         Friend YearLevelDisplayName As String
         Friend PrivacyConsentDisplayName As String
      End Class


      Class SDBStudentMedicalDetails
         Friend StudentID As Decimal?

         Friend HearingImpaired As Boolean?
         Friend VisionImpaired As Boolean?
         Friend ASDAspergers As Boolean?
         Friend IntellectualDisability As Boolean?
         Friend PhysicalDisability As Boolean?
         Friend SevereBehaviouralDisorder As Boolean?
         Friend SevereLanguageDisorder As Boolean?
         Friend MentalHealthCondition As Boolean?
         Friend MentalHealthConditionDescription As String ' Check length 200; diagnosed_mental_health_condition_details_d
         Friend HasAllergyHistory As Boolean?
         Friend AllergyHistoryDescription As String ' Check length 200; history_with_allergies
         Friend Anaphylaxis As Boolean?
         Friend DiagnosedWithAsthma As Boolean?
         Friend DiagnosedWithDiabetes As Boolean?
         Friend DiagnosedWithEpilepsy As Boolean?
         Friend DiagnosedWithAnyOtherConditions As Boolean?
         Friend OtherDiagnosedConditionsDescription As String ' Check length 200; description_of_diagnosed_condition
         Friend OtherMedicalIssuesDescription As String ' Check length 200; medical_issues_which_vsv_should_be_aware_of_description

         ' Non-Funnel fields that need to override database defaults on insert
         Friend PractitionerLastAlteredBy As String
         Friend PractitionerLastAlteredDate As Date?

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' TODO:
         ' Tread carefully with what's being overwritten in the case of record updates
         ' The practitioner referral forms, the fields for PSD and NCCD funding, etc
      End Class


      Class SDBStudentCensusData
         Friend StudentID As Decimal?

         Friend CountryOfBirth As Short?
         Friend FirstHomeLanguage As Short?
         Friend OtherHomeLanguage As Short?
         Friend IndigenousStatus As String
         Friend ResidentialStatus As String
         Friend VisaSubClass As Decimal?
         Friend VisaSector As String
         Friend VisaStatisticalCode As String
         Friend DateArrivedInAustralia As Date?
         Friend DateStartedInAustralia As Date?
         Friend HouseholdStatus As Decimal?
         Friend RestrictAccessAtRisk As Boolean?
         Friend RestrictAccessAlert As Boolean?
         Friend RestrictAccessType As String
         Friend RestrictAccessDescription As String
         Friend RestrictActivityAlert As Boolean?
         Friend RestrictActivityDescription As String

         Friend PreviousSchoolID As Decimal?
         Friend DateLastAttendedSchool As Date?

         Friend MotherCensusData As SDBParentCensusData
         Friend FatherCensusData As SDBParentCensusData

         ' Non-Funnel fields that need to override database defaults on insert
         Friend AllowanceCode As Short = 1

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' Display names
         Friend VisaSubClassInputText As String
         Friend CountryOfBirthDisplayName As String
         Friend FirstHomeLanguageDisplayName As String
         Friend OtherHomeLanguageDisplayName As String
         Friend IndigenousStatusDisplayName As String
         Friend ResidentialStatusDisplayName As String
         Friend HouseholdStatusDisplayName As String
         Friend PreviousSchoolDisplayName As String
      End Class


      Class SDBParentCensusData
         Friend CountryOfBirth As Short?
         Friend Language As Short?
         Friend SchoolEducation As String
         Friend NonSchoolEducation As String
         Friend OccupationGroup As String

         Friend RecordModificationStatus As New RecordModificationStatus()

         ' Display names
         Friend CountryOfBirthDisplayName As String
         Friend LanguageDisplayName As String
         Friend SchoolEducationDisplayName As String
         Friend NonSchoolEducationDisplayName As String
         Friend OccupationGroupDisplayName As String
      End Class


      Class SDBStudentEquipment
         Friend StudentID As Decimal?

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         ' Let the defaults handle everything else
      End Class


      Class SDBStudentComment
         Friend StudentID As Decimal?
         Friend Comment As String = "Online enrolment reason: " ' Check overall length 500
         Friend CommentType As String = "ENROLMENT"
         Friend ActiveStatus As String = "A"

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date
      End Class


      Class SDBStudentSubject
         Friend StudentID As Decimal?
         Friend EnrolmentYear As Decimal = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend SubjectID As Integer
         Friend StaffID As String = "N-A"
         Friend Semester As String
         Friend SubjectEnrolmentStatus As String = "P"
         Friend EnrolmentDate As Date
         Friend CourseDistribution As String

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         ' TODO:
         ' Confirm the needs for the CourseDistribution field; Leftmost char needs to be taken from the SDB subject VALID_COURSE_DISTRIBUTION
      End Class


      Class SDBStudentSubjectInterim
         Friend StudentID As Decimal?
         Friend EnrolmentYear As Decimal = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend SubjectID As Integer

         Friend LastAlteredBy As String = "ONLINE"
         Friend LastAlteredDate As Date

         ' Let the defaults handle everything else
      End Class


      Class SDBStudentSubjectFinal
         Friend StudentID As Decimal?
         Friend EnrolmentYear As Decimal = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend SubjectID As Integer

         Friend LastAlteredBy As String = "ONLINE"
         Friend LastAlteredDate As Date

         ' Let the defaults handle everything else
      End Class


      Class SDBTXN
         Friend StudentID As Decimal?
         Friend EnrolmentYear As Decimal = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend TxnCode As String = "C" ' Contribution due
         Friend CampusCode As String = "D"
         Friend TxnDate As Date
         Friend CrDrFlag As String = "D" ' Debit
         Friend Amount As Decimal
         Friend Comments As String = "Online Enrolment"

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date
      End Class


      Class SDBBookDespatch
         Friend StudentID As Decimal?
         Friend EnrolmentYear As Decimal = FunnelProcessApplicationPage.CurrentEnrolmentYear
         Friend SubjectID As Integer
         Friend BookID As Short
         Friend DespatchStatus As String = "T"
         Friend DespatchDate As Date?

         Friend LastAlteredBy As String
         Friend LastAlteredDate As Date

         ' TODO: Investigate again the existing sp_toOnlineEnrol_addBookDespatch which every time syncs this information for ALL online enrolments for the year (!)
      End Class


      Class SDBStudentRecordSet
         Friend Student As SDBStudent
         Friend Enrolment As SDBStudentEnrolment
         Friend PostalAddress As SDBAddress
         Friend ResidentialAddress As SDBAddress
         Friend ParentCarerA As SDBStudentCarerContact
         Friend ParentCarerB As SDBStudentCarerContact
         Friend MedicalDetails As SDBStudentMedicalDetails
         Friend CensusDetails As SDBStudentCensusData

         Friend Equipment As SDBStudentEquipment
         Friend Comment As SDBStudentComment
         Friend BookDespatch As SDBBookDespatch
      End Class


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin SDB access methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel lead status methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function GetFunnelLeadImportStatus(uuid As Guid, connection As SqlConnection) As FunnelLeadSDBImportStatus
         Using command = connection.CreateCommand()

            command.Parameters.AddWithValue("@leadUUID", uuid)
            command.CommandType = CommandType.Text
            command.CommandText = "select
                                       concat(vfl.FirstName, ' ', vfl.Surname) as ApplicantName,
                                       vfl.FunnelTargetEnrolmentYear,
                                       vfl.FunnelPipelineStage,
                                       vfl.FunnelEnrolmentForm,
                                       vfl.FunnelEnrolmentCategory,
                                       vfl.FunnelIsSharedEnrolmentID,
                                       vfl.FunnelYearLevel,
                                       vfl.Status,
                                       vfl.AcceptedStudentID,
                                       vfl.RejectedReasonID,
                                       vfl.RejectedReasonOther,
                                       vfl.ActionedBy,
                                       vfl.ActionedDate,
                                       vfl.ActionedPipelineStageID,
                                       vfl.ActionedPipelineStage,
                                       cast(iif((vfl.AcceptedStudentID is not null)
                                                and exists
                                                    (
                                                       select
                                                          *
                                                        from
                                                          dbo.STUDENT_ENROLMENT as se
                                                        where
                                                          (se.STUDENT_ID = vfl.AcceptedStudentID)
                                                          and (se.ENROLMENT_YEAR < vfl.FunnelTargetEnrolmentYear)
                                                    ),
                                               'true',
                                               'false') as bit) as AcceptedExistingStudent
                                     from
                                       dbo.vwFunnelLead as vfl
                                     where
                                       (vfl.FunnelLeadUUID = @leadUUID);"

            Using reader = command.ExecuteReader()
               If reader.Read() Then
                  Dim importStatus As New FunnelLeadSDBImportStatus()
                  With importStatus
                     .ApplicantName = reader.Value(Of String)("ApplicantName")
                     .FunnelTargetEnrolmentYear = reader.Value(Of Decimal)("FunnelTargetEnrolmentYear")
                     .FunnelPipelineStageDisplayName = reader.Value(Of String)("FunnelPipelineStage")
                     .FunnelEnrolmentFormDisplayName = reader.Value(Of String)("FunnelEnrolmentForm")
                     .FunnelEnrolmentCategoryDisplayName = reader.Value(Of String)("FunnelEnrolmentCategory")
                     .FunnelIsSharedEnrolment = IsSharedEnrolmentApplication(reader.Value(Of String)("FunnelIsSharedEnrolmentID"))
                     .FunnelYearLevelDisplayName = reader.Value(Of String)("FunnelYearLevel")
                     .Status = reader.Value(Of String)("Status")
                     .AcceptedStudentID = reader.Value(Of Decimal?)("AcceptedStudentID")
                     .AcceptedExistingStudent = reader.Value(Of Boolean)("AcceptedExistingStudent")
                     .RejectedReasonID = reader.Value(Of String)("RejectedReasonID")
                     .RejectedReasonOther = reader.Value(Of String)("RejectedReasonOther")
                     .ActionedBy = reader.Value(Of String)("ActionedBy")
                     .ActionedDate = reader.Value(Of Date?)("ActionedDate")
                     .ActionedPipelineStageID = reader.Value(Of Guid?)("ActionedPipelineStageID")
                     .ActionedPipelineStageDisplayName = reader.Value(Of String)("ActionedPipelineStage")
                  End With

                  Return importStatus
               End If
            End Using
         End Using

         Return Nothing
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel lead rejection methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function RejectFunnelLead(uuid As Guid, rejectedApplicationStatus As FunnelLeadSDBImportStatus) As Boolean
         Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()

               With rejectedApplicationStatus
                  command.Parameters.AddWithValue("@leadUUID", uuid)
                  command.Parameters.AddWithValue("@status", .Status)
                  command.Parameters.AddWithValue("@rejectedReasonID", .RejectedReasonID)
                  command.Parameters.AddWithNull("@rejectedReasonOther", .RejectedReasonOther)
                  command.Parameters.AddWithValue("@actionedBy", .ActionedBy)
                  command.Parameters.AddWithValue("@actionedDate", .ActionedDate)
                  command.Parameters.AddWithValue("@actionedPipelineStageID", .ActionedPipelineStageID)

                  command.CommandType = CommandType.Text
                  command.CommandText = "update
                                             fl
                                           set
                                             fl.Status = @status,
                                             fl.RejectedReasonID = @rejectedReasonID,
                                             fl.RejectedReasonOther = @rejectedReasonOther,
                                             fl.ActionedBy = @actionedBy,
                                             fl.ActionedDate = @actionedDate,
                                             fl.ActionedPipelineStageID = @actionedPipelineStageID
                                           from
                                             dbo.FUNNEL_LEAD as fl
                                           where
                                             (fl.FunnelLeadUUID = @leadUUID);"

                  Return (command.ExecuteNonQuery() > 0)
               End With
            End Using
         End Using
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin Funnel lead data matching methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function GetPreliminaryMatchingExistingStudents(applicant As Child, minimumEnrolmentYear As Decimal, connection As SqlConnection) As List(Of SDBStudentMatch)
         Using command = connection.CreateCommand()

            command.Parameters.AddWithNull("@surname", applicant.last_name)
            command.Parameters.AddWithNull("@dateOfBirth", applicant.date_of_birth)
            command.Parameters.AddWithNull("@email", applicant.email)
            command.Parameters.AddWithValue("@minimumEnrolmentYear", minimumEnrolmentYear)
            command.CommandType = CommandType.Text
            command.CommandText = $"with
                                 StudentKeyDetails as
                                    (
                                       select
                                          st.STUDENT_ID as StudentID,
                                          st.FIRST_NAME as FirstName,
                                          st.PREFERRED_NAME as PreferredName,
                                          st.SURNAME as Surname,
                                          st.MIDDLE_NAME as MiddleName,
                                          st.BIRTH_DATE as DateOfBirth,
                                          st.STUDENT_EMAIL as Email,
                                          st.STUDENT_MOBILE as Mobile,
                                          isnull(dbo.ProperCase(ec.SUBCATEGORY_FULL_TITLE), 'Other') as EnrolmentCategory,
                                          dbo.ProperCase(sch.SCHOOL_NAME) as HomeSchool,
                                          se.ENROLMENT_YEAR as EnrolmentYear,
                                          vyl.YearLevel,
                                          se.ENROLMENT_DATE as EnrolmentDate,
                                          se.ENROLMENT_STATUS as EnrolmentStatus,
                                          se.WITHDRAWAL_DATE as WithdrawalDate,
                                          se.WITHDRAWAL_REASON_ID as WithdrawalReasonID,
                                          row_number() over (partition by st.STUDENT_ID order by se.ENROLMENT_YEAR desc) as EnrolmentYearRowNumber
                                        from
                                          dbo.STUDENT as st
                                          inner join dbo.STUDENT_ENROLMENT as se
                                             on (se.STUDENT_ID = st.STUDENT_ID)
                                          left join dbo.ENROLMENT_CATEGORY as ec
                                             on (
                                                   (ec.CATEGORY_CODE = st.CATEGORY_CODE)
                                                   and (ec.SUBCATEGORY_CODE = st.SUBCATEGORY_CODE)
                                                )
                                          left join dbo.vwYearLevel as vyl
                                             on (vyl.YearLevelID = se.YEAR_LEVEL)
                                          left join dbo.SCHOOL as sch
                                             on (sch.SCHOOL_ID = st.HOME_SCHOOL_ID)
                                        where
                                          (st.STUDENT_ID not in (select vts.TestStudentID from dbo.vwTestStudent as vts))
                                          and (se.ENROLMENT_YEAR >= @minimumEnrolmentYear)
                                          and
                                          (
                                             (st.BIRTH_DATE = @dateOfBirth)
                                             or (st.SURNAME = @surname)
                                             or (st.STUDENT_EMAIL = @email)
                                          )
                                          and
                                          (
                                             (se.WITHDRAWAL_REASON_ID is null)
                                             or (se.WITHDRAWAL_REASON_ID <> {ExistingStudentEnrolmentErrorID})
                                          )
                                    )
                               select * from StudentKeyDetails where (StudentKeyDetails.EnrolmentYearRowNumber = 1);"

            Dim matchingStudents As New List(Of SDBStudentMatch)
            Using reader = command.ExecuteReader()
               While (reader.Read())
                  Dim student As New SDBStudentMatch() With
            {
               .StudentID = reader.Value(Of Decimal)("StudentID"),
               .FirstName = reader.Value(Of String)("FirstName")?.Trim(),
               .PreferredName = reader.Value(Of String)("PreferredName")?.Trim(),
               .Surname = reader.Value(Of String)("Surname")?.Trim(),
               .MiddleName = reader.Value(Of String)("MiddleName")?.Trim(),
               .DateOfBirth = reader.Value(Of Date)("DateOfBirth"),
               .Email = reader.Value(Of String)("Email")?.Trim(),
               .Mobile = FormatPhoneNumber(reader.Value(Of String)("Mobile")?.Trim()),
               .EnrolmentCategory = reader.Value(Of String)("EnrolmentCategory")?.Trim(),
               .HomeSchool = reader.Value(Of String)("HomeSchool")?.Trim(),
               .LastEnrolmentYear = reader.Value(Of Decimal)("EnrolmentYear"),
               .LEYYearLevel = reader.Value(Of String)("YearLevel"),
               .LEYEnrolmentDate = reader.Value(Of Date)("EnrolmentDate"),
               .LEYEnrolmentStatus = reader.Value(Of String)("EnrolmentStatus"),
               .LEYWithdrawalDate = reader.Value(Of Date?)("WithdrawalDate"),
               .LEYWithdrawalReasonID = reader.Value(Of Decimal?)("WithdrawalReasonID")
            }

                  matchingStudents.Add(student)
               End While

               Return matchingStudents
            End Using
         End Using
      End Function


      Private Function GetMatchingExistingStudents(applicantKeyDetails As Lead, preliminaryMatches As List(Of SDBStudentMatch)) As List(Of SDBStudentMatch)
         Dim applicant = applicantKeyDetails.child
         Dim matchingStudents As New List(Of SDBStudentMatch)

         ' Normalise the applicant key fields for matching
         Dim applicantFirstName = If(applicant.first_name?.Trim().ToUpper(), "")
         Dim applicantPreferredName = If(applicantKeyDetails.custom_properties.preferred_name?.Trim().ToUpper(), "")
         Dim applicantSurname = If(applicant.last_name?.Trim().ToUpper(), "")
         Dim applicantMiddleName = If(applicant.middle_name?.Trim().ToUpper(), "")
         Dim applicantEmail = If(applicant.email?.Trim().ToUpper(), "")
         Dim applicantMobile = If(GetPhoneNumber(applicant.phone_numbers, MobilePhoneNumberLabel), "")

         For Each student In preliminaryMatches
            ' Normalise the candidate match student key fields
            Dim studentFirstName = If(student.FirstName?.ToUpper(), "")
            Dim studentPreferredName = If(student.PreferredName?.ToUpper(), "")
            Dim studentSurname = If(student.Surname?.ToUpper(), "")
            Dim studentMiddleName = If(student.MiddleName?.ToUpper(), "")
            Dim studentEmail = If(student.Email?.ToUpper(), "")
            Dim studentMobile = If(student.Mobile, "")

            ' Assign a maximum of one point for first name or preferred name match
            ' We do need to consider all permutations here, since the preferred name of either or both records might be blank
            ApplyFieldMatchPointScore(applicantFirstName, studentFirstName, student, student.FirstNameMatchStrength)
            If (Not IsAnyMatch(student.FirstNameMatchStrength)) Then
               ApplyFieldMatchPointScore(applicantPreferredName, studentPreferredName, student, student.PreferredNameMatchStrength)
               If (Not IsAnyMatch(student.PreferredNameMatchStrength)) Then
                  ApplyFieldMatchPointScore(applicantFirstName, studentPreferredName, student, student.PreferredNameMatchStrength)
                  If (Not IsAnyMatch(student.PreferredNameMatchStrength)) Then
                     ApplyFieldMatchPointScore(applicantPreferredName, studentFirstName, student, student.FirstNameMatchStrength)
                  End If
               End If
            End If

            ApplyFieldMatchPointScore(applicantSurname, studentSurname, student, student.SurnameMatchStrength)
            ApplyFieldMatchPointScore(applicantMiddleName, studentMiddleName, student, student.MiddleNameMatchStrength)
            ApplyFieldMatchPointScore(applicantEmail, studentEmail, student, student.EmailMatchStrength)
            ApplyFieldMatchPointScore(applicantMobile, studentMobile, student, student.MobileMatchStrength)

            ApplyFieldMatchPointScore(applicant.date_of_birth, student.DateOfBirth, student, student.DateOfBirthMatchStrength)

            ' If the first name (or preferred name) and surname didn't match, try swapping them; if they then match exactly or approximately,
            ' mark them as a possible data error
            ' Note that both need to match for us to consider it a transposed match and apply the scoring
            ' Other name mismatches are also possible but this is the most likely case
            If ((Not IsAnyMatch(student.FirstNameMatchStrength)) AndAlso
               (Not IsAnyMatch(student.SurnameMatchStrength)) AndAlso
               (Not IsAnyMatch(student.PreferredNameMatchStrength)) AndAlso
               IsAnyMatch(GetFieldMatchStrength(applicantSurname, studentFirstName)) AndAlso
               IsAnyMatch(GetFieldMatchStrength(applicantFirstName, studentSurname))) Then
               student.FirstNameMatchStrength = FieldMatchStrength.MatchWithPossibleDataError
               student.SurnameMatchStrength = FieldMatchStrength.MatchWithPossibleDataError
               student.StudentMatchStrengthScore += 2
            End If

            If (student.StudentMatchStrengthScore >= MinimumCandidateMatchScore) Then
               ' We've found a candidate matching student - add them to the list to display
               matchingStudents.Add(student)
            End If
         Next

         Return matchingStudents
      End Function


      Private Function IsAnyMatch(fieldMatchStrength As FieldMatchStrength) As Boolean
         Return (fieldMatchStrength = FieldMatchStrength.Match) OrElse (fieldMatchStrength = FieldMatchStrength.MatchWithPossibleDataError)
      End Function


      Private Sub ApplyFieldMatchPointScore(fieldOne As String, fieldTwo As String, student As SDBStudentMatch, ByRef matchStrength As FieldMatchStrength)
         matchStrength = GetFieldMatchStrength(fieldOne, fieldTwo)
         If (IsAnyMatch(matchStrength)) Then
            student.StudentMatchStrengthScore += 1
         End If
      End Sub


      Private Function GetFieldMatchStrength(fieldOne As String, fieldTwo As String) As FieldMatchStrength
         If ((fieldOne.Length = 0) AndAlso (fieldTwo.Length = 0)) Then
            Return FieldMatchStrength.NoData
         ElseIf ((fieldOne.Length = 0) OrElse (fieldTwo.Length = 0)) Then
            Return FieldMatchStrength.NoMatch
         ElseIf (fieldOne.Equals(fieldTwo)) Then
            Return FieldMatchStrength.Match
         ElseIf (New Damerau().Distance(fieldOne, fieldTwo) <= MaximumDamerauLevenshteinDistance) Then
            ' Fuzzy matching here using Damerau-Levenshtein distance
            ' The minimum number of edits, inserts, deletions, or character transpositions needed to make two strings identical
            Return FieldMatchStrength.MatchWithPossibleDataError
         Else
            Return FieldMatchStrength.NoMatch
         End If
      End Function


      Private Sub ApplyFieldMatchPointScore(fieldOne As Date?, fieldTwo As Date?, student As SDBStudentMatch, ByRef matchStrength As FieldMatchStrength)
         If ((Not fieldOne.HasValue()) AndAlso (Not fieldTwo.HasValue())) Then
            matchStrength = FieldMatchStrength.NoData
         ElseIf ((Not fieldOne.HasValue()) OrElse (Not fieldTwo.HasValue())) Then
            matchStrength = FieldMatchStrength.NoMatch
         ElseIf (fieldOne.Equals(fieldTwo)) Then
            matchStrength = FieldMatchStrength.Match
            student.StudentMatchStrengthScore += 1
         ElseIf (fieldOne.Value.Day <= 12) Then
            ' Attempt a transposed day/month match, which is only possible if the day is within a valid month range
            Dim reversedFieldOne = New Date(fieldOne.Value.Year, fieldOne.Value.Day, fieldOne.Value.Month)
            If (reversedFieldOne.Equals(fieldTwo)) Then
               matchStrength = FieldMatchStrength.MatchWithPossibleDataError
               student.StudentMatchStrengthScore += 1
            Else
               matchStrength = FieldMatchStrength.NoMatch
            End If
         Else
            matchStrength = FieldMatchStrength.NoMatch
         End If
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin SDB student record retrieval methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function GetExistingStudentRecordSet(studentID As Decimal, minimumDataMatchEnrolmentYear As Decimal, connection As SqlConnection) As SDBStudentRecordSet
         Dim existingRecordSet As New SDBStudentRecordSet()
         With existingRecordSet
            .Student = GetSDBStudent(studentID, connection)
            If (.Student.PostalAddressID IsNot Nothing) Then
               .PostalAddress = GetSDBAddress(.Student.PostalAddressID.Value, connection)
            End If
            If (.Student.ResidentialAddressID IsNot Nothing) Then
               .ResidentialAddress = GetSDBAddress(.Student.ResidentialAddressID.Value, connection)
            End If
            If (.Student.ParentCarerAID IsNot Nothing) Then
               .ParentCarerA = GetSDBCarerContact(.Student.ParentCarerAID.Value, minimumDataMatchEnrolmentYear, connection, CarerContactMatchType.ParentCarer, .Student.StudentID)
            End If
            If (.Student.ParentCarerBID IsNot Nothing) Then
               .ParentCarerB = GetSDBCarerContact(.Student.ParentCarerBID.Value, minimumDataMatchEnrolmentYear, connection, CarerContactMatchType.ParentCarer, .Student.StudentID)
            End If
            .MedicalDetails = GetSDBStudentMedicalDetails(studentID, connection)
            .CensusDetails = GetSDBStudentCensusDetails(studentID, connection)
         End With

         Return existingRecordSet
      End Function


      Private Function GetSDBStudent(studentID As Decimal, connection As SqlConnection) As SDBStudent
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@studentID", studentID)
            command.CommandType = CommandType.Text
            command.CommandText = "select
                                    st.STUDENT_ID as StudentID,
                                    st.FIRST_NAME as FirstName,
                                    st.PREFERRED_NAME as PreferredName,
                                    st.MIDDLE_NAME as MiddleName,
                                    st.SURNAME as Surname,
                                    st.BIRTH_DATE as DateOfBirth,
                                    st.SEX as Gender,
                                    st.SEX_SELF_DESCRIBED as GenderSelfDescribed,
                                    st.STUDENT_EMAIL as StudentEmail,
                                    st.STUDENT_MOBILE as StudentMobile,
                                    st.CATEGORY_CODE as CategoryCode,
                                    st.SUBCATEGORY_CODE as SubcategoryCode,
                                    st.POSTAL_ADDRESS_ID as PostalAddressID,
                                    st.CURR_RESID_ADDRESS_ID as ResidentialAddressID,
                                    st.ORIG_RESID_ADDRESS_ID as SACAddressID,
                                    st.CARER_ID_PARENT_A as ParentCarerAID,
                                    st.CARER_ID_PARENT_B as ParentCarerBID,
                                    st.ATTENDING_SCHOOL_ID as AttendingSchoolID,
                                    st.HOME_SCHOOL_ID as HomeSchoolID,
                                    st.ORGANISATION_SCHOOL_ID as ExtraOrganisationID,
                                    st.VCE_CANDIDATE_NUMBER as VCAANumber,
                                    st.ENROLMENT_COMMENTS as EnrolmentComments,
                                    dbo.ProperCase(ec.SUBCATEGORY_FULL_TITLE) as EnrolmentCategoryDisplayName,
                                    vwg.Gender as GenderDisplayName,
                                    dbo.ProperCase(atsch.SCHOOL_NAME) as AttendingSchoolDisplayName,
                                    dbo.ProperCase(hsch.SCHOOL_NAME) as HomeSchoolDisplayName,
                                    eosch.SCHOOL_NAME as ExtraOrganisationDisplayName
                                  from
                                    dbo.STUDENT as st
                                    left join dbo.ENROLMENT_CATEGORY as ec
                                       on (
                                             (ec.CATEGORY_CODE = st.CATEGORY_CODE)
                                             and (ec.SUBCATEGORY_CODE = st.SUBCATEGORY_CODE)
                                          )
                                    left join dbo.vwGender as vwg
                                       on (vwg.GenderID = st.SEX)
                                    left join dbo.SCHOOL as atsch
                                       on (atsch.SCHOOL_ID = st.ATTENDING_SCHOOL_ID)
                                    left join dbo.SCHOOL as hsch
                                       on (hsch.SCHOOL_ID = st.HOME_SCHOOL_ID)
                                    left join dbo.SCHOOL as eosch
                                       on (eosch.SCHOOL_ID = st.ORGANISATION_SCHOOL_ID)
                                  where
                                    (st.STUDENT_ID = @studentID);"

            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim student As New SDBStudent()
                  With student
                     .StudentID = reader.Value(Of Decimal?)("StudentID")
                     .FirstName = reader.Value(Of String)("FirstName")?.Trim()
                     .PreferredName = reader.Value(Of String)("PreferredName")?.Trim()
                     .MiddleName = reader.Value(Of String)("MiddleName")?.Trim()
                     .Surname = reader.Value(Of String)("Surname")?.Trim()
                     .DateOfBirth = reader.Value(Of Date?)("DateOfBirth")
                     .Gender = reader.Value(Of String)("Gender")?.Trim()
                     .GenderSelfDescribed = reader.Value(Of String)("GenderSelfDescribed")?.Trim()
                     .StudentEmail = reader.Value(Of String)("StudentEmail")?.Trim()
                     .StudentMobile = FormatPhoneNumber(reader.Value(Of String)("StudentMobile")?.Trim())
                     .CategoryCode = reader.Value(Of String)("CategoryCode")?.Trim()
                     .SubcategoryCode = reader.Value(Of String)("SubcategoryCode")?.Trim()
                     .FullCategoryCode = GetFullCategoryCode(.CategoryCode, .SubcategoryCode)
                     .PostalAddressID = reader.Value(Of Decimal?)("PostalAddressID")
                     .ResidentialAddressID = reader.Value(Of Decimal?)("ResidentialAddressID")
                     .ResidentialAddressSameAsPostalAddress = (.PostalAddressID.HasValue() AndAlso .PostalAddressID.Equals(.ResidentialAddressID))
                     .SACAddressID = reader.Value(Of Decimal?)("SACAddressID")
                     .ParentCarerAID = reader.Value(Of Integer?)("ParentCarerAID")
                     .ParentCarerBID = reader.Value(Of Integer?)("ParentCarerBID")
                     .AttendingSchoolID = reader.Value(Of Decimal?)("AttendingSchoolID")
                     .HomeSchoolID = reader.Value(Of Decimal?)("HomeSchoolID")
                     .ExtraOrganisationID = reader.Value(Of String)("ExtraOrganisationID")
                     .VCAANumber = reader.Value(Of String)("VCAANumber")?.Trim()
                     .EnrolmentComments = reader.Value(Of String)("EnrolmentComments")?.Trim()
                     .EnrolmentCategoryDisplayName = reader.Value(Of String)("EnrolmentCategoryDisplayName")?.Trim()
                     .GenderDisplayName = reader.Value(Of String)("GenderDisplayName")
                     .AttendingSchoolDisplayName = reader.Value(Of String)("AttendingSchoolDisplayName")?.Trim()
                     .HomeSchoolDisplayName = reader.Value(Of String)("HomeSchoolDisplayName")?.Trim()
                     .ExtraOrganisationDisplayName = reader.Value(Of String)("ExtraOrganisationDisplayName")?.Trim()
                  End With

                  Return student
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetSDBAddress(addressID As Decimal, connection As SqlConnection) As SDBAddress
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@addressID", addressID)
            command.CommandType = CommandType.Text
            command.CommandText = "with
                                    LinkedSchool as
                                       (
                                          select top 1
                                             sch.ADDRESS_ID as AddressID,
                                             sch.SCHOOL_ID as LinkedSchoolID,
                                             dbo.ProperCase(rtrim(sch.SCHOOL_NAME)) as LinkedSchoolDisplayName
                                           from
                                             dbo.SCHOOL as sch
                                           where
                                             (sch.ADDRESS_ID = @addressID)
                                             and (sch.STATUS = 1)
                                       )
                                  select
                                     addr.ADDRESS_ID as AddressID,
                                     addr.ADDRESSEE as Addressee,
                                     addr.AGENT as Agent,
                                     addr.ADDR1 as AddressLineOne,
                                     addr.ADDR2 as AddressLineTwo,
                                     addr.SUBURB_TOWN as SuburbTown,
                                     addr.POSTCODE as Postcode,
                                     addr.STATE as State,
                                     addr.COUNTRY as Country,
                                     addr.PHONE_A as PhoneNumberOne,
                                     addr.PHONE_B as PhoneNumberTwo,
                                     addr.EMAIL_ADDRESS as EmailAddressOne,
                                     addr.EMAIL_ADDRESS2 as EmailAddressTwo,
                                     ls.LinkedSchoolID,
                                     ls.LinkedSchoolDisplayName
                                   from
                                     dbo.ADDRESS as addr
                                     left join LinkedSchool as ls
                                        on (ls.AddressID = addr.ADDRESS_ID)
                                   where
                                     addr.ADDRESS_ID = @addressID;"

            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim address As New SDBAddress()
                  With address
                     .AddressID = reader.Value(Of Decimal?)("AddressID")
                     .Addressee = reader.Value(Of String)("Addressee")?.Trim()
                     .Agent = reader.Value(Of String)("Agent")?.Trim()
                     .AddressLineOne = reader.Value(Of String)("AddressLineOne")?.Trim()
                     .AddressLineTwo = reader.Value(Of String)("AddressLineTwo")?.Trim()
                     .SuburbTown = reader.Value(Of String)("SuburbTown")?.Trim()
                     .Postcode = reader.Value(Of String)("Postcode")?.Trim()
                     .State = reader.Value(Of String)("State")?.Trim()
                     .Country = reader.Value(Of String)("Country")?.Trim()
                     .PhoneNumberOne = FormatPhoneNumber(reader.Value(Of String)("PhoneNumberOne")?.Trim())
                     .PhoneNumberTwo = FormatPhoneNumber(reader.Value(Of String)("PhoneNumberTwo")?.Trim())
                     .EmailAddressOne = reader.Value(Of String)("EmailAddressOne")?.Trim()
                     .EmailAddressTwo = reader.Value(Of String)("EmailAddressTwo")?.Trim()
                     .LinkedSchoolID = reader.Value(Of Decimal?)("LinkedSchoolID")
                     .LinkedSchoolDisplayName = reader.Value(Of String)("LinkedSchoolDisplayName")
                  End With

                  Return address
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetSDBCarerContact(carerContactID As Decimal, studentConnectionsMinimumEnrolmentYear As Decimal, connection As SqlConnection,
                                       Optional studentConnectionsContactMatchType As CarerContactMatchType = Nothing,
                                       Optional studentConnectionsExcludeStudentID As Decimal? = Nothing) As SDBStudentCarerContact

         ' Retrieve the carer contact details for the ID provided, in addition to the details of any students that they've been linked to since studentConnectionMinimumEnrolmentYear
         ' This query makes use of vwStudentCarerContact, which provides a combined view of carer contacts against students for each enrolment year
         ' The view includes a column CARER_TYPE indicating what type of connection the contact has with the student: parent a or b, or school supervisor
         ' That information combined with the carer relationship field (including agency supervisors etc) should allows us to determine exactly what type of contact
         ' they are for the student
         ' The base carer fields are written to the object container, with each student contact being written to a list attached to the same container
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@carerContactID", carerContactID)
            command.Parameters.AddWithValue("@studentConnectionMinimumEnrolmentYear", studentConnectionsMinimumEnrolmentYear)

            Dim carerContactTypeClause As String = Nothing
            Select Case studentConnectionsContactMatchType
               Case CarerContactMatchType.ParentCarer
                  carerContactTypeClause = $"and (vscc.CARER_TYPE in ('{ParentCarerAConnectionType}', '{ParentCarerBConnectionType}'))"
               Case CarerContactMatchType.Supervisor
                  carerContactTypeClause = $"and (vscc.CARER_TYPE = '{SchoolSupervisorConnectionType}')"
            End Select

            Dim excludeStudentIDClause As String = Nothing
            If (studentConnectionsExcludeStudentID IsNot Nothing) Then
               excludeStudentIDClause = $"and (vscc.STUDENT_ID <> {studentConnectionsExcludeStudentID})"
            End If

            command.CommandType = CommandType.Text
            command.CommandText = $"with
                                    CarerStudentConnections as
                                       (
                                          select
                                             vscc.CARER_ID as CarerID,
                                             vscc.STUDENT_ID as StudentID,
                                             vscc.ENROLMENT_YEAR as StudentEnrolmentYear,
                                             row_number() over (partition by vscc.STUDENT_ID order by vscc.ENROLMENT_YEAR desc) as StudentEnrolmentYearRowNumber,
                                             vscc.CARER_TYPE as StudentCarerConnectionType,
                                             concat(rtrim(st.FIRST_NAME), ' ', rtrim(st.SURNAME)) as StudentName,
                                             dbo.ProperCase(ec.SUBCATEGORY_FULL_TITLE) as StudentEnrolmentCategoryDisplayName,
                                             vyl.YearLevel as StudentYearLevelDisplayName,
                                             vscc.ENROLMENT_STATUS as StudentEnrolmentStatus
                                           from
                                             dbo.vwStudentCarerContact as vscc
                                             inner join dbo.STUDENT as st
                                                on (st.STUDENT_ID = vscc.STUDENT_ID)
                                             inner join dbo.STUDENT_ENROLMENT as se
                                                on (
                                                      (se.STUDENT_ID = vscc.STUDENT_ID)
                                                      and (se.ENROLMENT_YEAR = vscc.ENROLMENT_YEAR)
                                                   )
                                             left join dbo.ENROLMENT_CATEGORY as ec
                                                on (
                                                      (ec.CATEGORY_CODE = st.CATEGORY_CODE)
                                                      and (ec.SUBCATEGORY_CODE = st.SUBCATEGORY_CODE)
                                                   )
                                             left join dbo.vwYearLevel as vyl
                                                on (vyl.YearLevelID = se.YEAR_LEVEL)
                                           where
                                             (vscc.STUDENT_ID not in (select vts.TestStudentID from dbo.vwTestStudent as vts))
                                             and (vscc.ENROLMENT_YEAR >= @studentConnectionMinimumEnrolmentYear)
                                             and (vscc.CARER_ID = @carerContactID)
                                             {carerContactTypeClause}
                                             {excludeStudentIDClause}
                                       )
                                  select
                                     scc.CARER_ID as CarerID,
                                     scc.TITLE as Salutation,
                                     scc.SURNAME as Surname,
                                     scc.FIRST_NAME as FirstName,
                                     scc.RELATIONSHIP as Relationship,
                                     scc.HOME_PHONE as HomePhone,
                                     scc.WORK_PHONE as WorkPhone,
                                     scc.MOBILE as Mobile,
                                     scc.EMAIL as Email,
                                     scc.SUPERVISOR_POSITION as SupervisorPosition,
                                     scc.SUPERVISOR_POSITION_OTHER as SupervisorPositionOther,
                                     lur.RelationshipType as RelationshipDisplayName,
                                     csc.StudentID,
                                     csc.StudentEnrolmentYear,
                                     csc.StudentCarerConnectionType,
                                     csc.StudentName,
                                     csc.StudentEnrolmentCategoryDisplayName,
                                     csc.StudentYearLevelDisplayName,
                                     csc.StudentEnrolmentStatus
                                   from
                                     dbo.STUDENT_CARER_CONTACT as scc
                                     left join dbo.vwRelationshipType as lur
                                        on (lur.RelationshipTypeID = scc.RELATIONSHIP)
                                     left join CarerStudentConnections as csc
                                        on (
                                              (csc.CarerID = scc.CARER_ID)
                                              and (csc.StudentEnrolmentYearRowNumber = 1)
                                           )
                                   where
                                     (scc.CARER_ID = @carerContactID)
                                   order by
                                     csc.StudentEnrolmentYear desc,
                                     csc.StudentID;"

            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim carerContact As New SDBStudentCarerContact()
                  With carerContact
                     .CarerID = reader.Value(Of Decimal?)("CarerID")
                     .Salutation = reader.Value(Of String)("Salutation")?.Trim()
                     .Surname = reader.Value(Of String)("Surname")?.Trim()
                     .FirstName = reader.Value(Of String)("FirstName")?.Trim()
                     .Relationship = reader.Value(Of String)("Relationship")?.Trim()
                     .HomePhone = FormatPhoneNumber(reader.Value(Of String)("HomePhone")?.Trim())
                     .WorkPhone = FormatPhoneNumber(reader.Value(Of String)("WorkPhone")?.Trim())
                     .Mobile = FormatPhoneNumber(reader.Value(Of String)("Mobile")?.Trim())
                     .Email = reader.Value(Of String)("Email")?.Trim()
                     .SupervisorPosition = reader.Value(Of String)("SupervisorPosition")?.Trim()
                     .SupervisorPositionOther = reader.Value(Of String)("SupervisorPositionOther")?.Trim()
                     .RelationshipDisplayName = reader.Value(Of String)("RelationshipDisplayName")
                  End With

                  If (reader.Value(Of Decimal?)("StudentID") IsNot Nothing) Then
                     Do
                        Dim studentConnection As New SDBStudentCarerContactConnection()
                        With studentConnection
                           .StudentID = reader.Value(Of Decimal)("StudentID")
                           .EnrolmentYear = reader.Value(Of Decimal)("StudentEnrolmentYear")
                           .ConnectionType = reader.Value(Of String)("StudentCarerConnectionType")
                           .Name = reader.Value(Of String)("StudentName")?.Trim()
                           .EnrolmentCategoryDisplayName = reader.Value(Of String)("StudentEnrolmentCategoryDisplayName")?.Trim()
                           .YearLevelDisplayName = reader.Value(Of String)("StudentYearLevelDisplayName")
                           .EnrolmentStatus = reader.Value(Of String)("StudentEnrolmentStatus")
                        End With

                        carerContact.StudentConnections.Add(studentConnection)
                     Loop While (reader.Read())
                  End If

                  Return carerContact
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetFirstMatchingSDBCarerContactID(firstName As String, surname As String, email As String, connection As SqlConnection,
                                                      Optional carerContactMatchType As CarerContactMatchType = Nothing) As Decimal?
         Dim carerContactTypeClause As String = Nothing
         Dim supervisorRelationshipList = $"'{SchoolSupervisorRelationshipCode}', '{AgencySupervisorRelationshipCode}', '{SportsSupervisorRelationshipCode}'"
         Select Case carerContactMatchType
            Case CarerContactMatchType.ParentCarer
               carerContactTypeClause = $"and (scc.RELATIONSHIP not in ({supervisorRelationshipList}))"
            Case CarerContactMatchType.Supervisor
               carerContactTypeClause = $"and (scc.RELATIONSHIP in ({supervisorRelationshipList}))"
         End Select

         Using command = connection.CreateCommand()
            command.Parameters.AddWithNull("@firstName", firstName)
            command.Parameters.AddWithNull("@surname", surname)
            command.Parameters.AddWithNull("@email", email)
            command.CommandType = CommandType.Text
            command.CommandText = $"select top 1
                                    scc.CARER_ID as CarerID
                                  from
                                    dbo.STUDENT_CARER_CONTACT as scc
                                  where
                                    (scc.FIRST_NAME = @firstName)
                                    and (scc.SURNAME = @surname)
                                    and (scc.EMAIL = @email)
                                    {carerContactTypeClause}
                                  order by
                                    scc.CARER_ID desc;"

            Dim result = command.ExecuteScalar()
            If (TypeOf result Is Decimal?) Then
               Return DirectCast(result, Decimal?)
            End If
         End Using

         Return Nothing
      End Function


      Private Function GetSDBStudentMedicalDetails(studentID As Decimal, connection As SqlConnection) As SDBStudentMedicalDetails
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@studentID", studentID)
            command.CommandType = CommandType.Text
            command.CommandText = "select
                                    smd.STUDENT_ID as StudentID,
                                    smd.HEARING as HearingImpaired,
                                    smd.VISION as VisionImpaired,
                                    smd.ASDASPERGERS as ASDAspergers,
                                    smd.INTELLECTUAL as IntellectualDisability,
                                    smd.PHYSICAL as PhysicalDisability,
                                    smd.BEHAVIOURAL as SevereBehaviouralDisorder,
                                    smd.LANGUAGE as SevereLanguageDisorder,
                                    smd.MENTALHEALTH as MentalHealthCondition,
                                    smd.MENTALHEALTH_HISTORY as MentalHealthConditionDescription,
                                    smd.HASALLERGYHISTORY as HasAllergyHistory,
                                    smd.ALLERGYHISTORY as AllergyHistoryDescription,
                                    smd.ANAPHYLAXIS as Anaphylaxis,
                                    smd.DIAGNOSED_ASTHMA as DiagnosedWithAsthma,
                                    smd.DIAGNOSED_DIABETES as DiagnosedWithDiabetes,
                                    smd.DIAGNOSED_EPILEPSY as DiagnosedWithEpilepsy,
                                    smd.HASOTHERCONDITIONS as DiagnosedWithAnyOtherConditions,
                                    smd.OTHERCONDITIONS as OtherDiagnosedConditionsDescription,
                                    smd.OTHERMEDICALISSUES as OtherMedicalIssuesDescription
                                  from
                                    dbo.STUDENT_MEDICAL_DETAILS as smd
                                  where
                                    smd.STUDENT_ID = @studentID;"
            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim medicalDetails As New SDBStudentMedicalDetails()
                  With medicalDetails
                     .StudentID = reader.Value(Of Decimal?)("StudentID")
                     .HearingImpaired = reader.Value(Of Boolean?)("HearingImpaired")
                     .VisionImpaired = reader.Value(Of Boolean?)("VisionImpaired")
                     .ASDAspergers = reader.Value(Of Boolean?)("ASDAspergers")
                     .IntellectualDisability = reader.Value(Of Boolean?)("IntellectualDisability")
                     .PhysicalDisability = reader.Value(Of Boolean?)("PhysicalDisability")
                     .SevereBehaviouralDisorder = reader.Value(Of Boolean?)("SevereBehaviouralDisorder")
                     .SevereLanguageDisorder = reader.Value(Of Boolean?)("SevereLanguageDisorder")
                     .MentalHealthCondition = reader.Value(Of Boolean?)("MentalHealthCondition")
                     .MentalHealthConditionDescription = reader.Value(Of String)("MentalHealthConditionDescription")?.Trim()
                     .HasAllergyHistory = reader.Value(Of Boolean?)("HasAllergyHistory")
                     .AllergyHistoryDescription = reader.Value(Of String)("AllergyHistoryDescription")?.Trim()
                     .Anaphylaxis = reader.Value(Of Boolean?)("Anaphylaxis")
                     .DiagnosedWithAsthma = reader.Value(Of Boolean?)("DiagnosedWithAsthma")
                     .DiagnosedWithDiabetes = reader.Value(Of Boolean?)("DiagnosedWithDiabetes")
                     .DiagnosedWithEpilepsy = reader.Value(Of Boolean?)("DiagnosedWithEpilepsy")
                     .DiagnosedWithAnyOtherConditions = reader.Value(Of Boolean?)("DiagnosedWithAnyOtherConditions")
                     .OtherDiagnosedConditionsDescription = reader.Value(Of String)("OtherDiagnosedConditionsDescription")?.Trim()
                     .OtherMedicalIssuesDescription = reader.Value(Of String)("OtherMedicalIssuesDescription")?.Trim()
                  End With

                  Return medicalDetails
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetSDBStudentCensusDetails(studentID As Decimal, connection As SqlConnection) As SDBStudentCensusData
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@studentID", studentID)
            command.CommandType = CommandType.Text
            command.CommandText = "select
                                    scd.STUDENT_ID as StudentID,
                                    scd.COUNTRY_OF_BIRTH as CountryOfBirth,
                                    scd.FIRST_HOME_LANGUAGE as FirstHomeLanguage,
                                    scd.OTHER_HOME_LANGUAGE as OtherHomeLanguage,
                                    scd.KOORITORRESFLAG as IndigenousStatus,
                                    scd.RESIDENTIAL_STATUS as ResidentialStatus,
                                    scd.VISA_SUB_CLASS as VisaSubClass,
                                    scd.VISA_STATISTICAL_CODE as VisaStatisticalCode,
                                    scd.VISA_SECTOR as VisaSector,
                                    scd.DATE_ARRIVED_IN_AUST as DateArrivedInAustralia,
                                    scd.DATE_STARTED_IN_AUST as DateStartedInAustralia,
                                    scd.HOUSEHOLD_STATUS as HouseholdStatus,
                                    scd.RESTRICT_ACCESS_ATRISK as RestrictAccessAtRisk,
                                    scd.RESTRICT_ACCESS_ALERT as RestrictAccessAlert,
                                    scd.RESTRICT_ACCESS_TYPE as RestrictAccessType,
                                    scd.RESTRICT_ACCESS_DESCRIPTION as RestrictAccessDescription,
                                    scd.RESTRICT_ACTIVITY_ALERT as RestrictActivityAlert,
                                    scd.RESTRICT_ACTIVITY_DESCRIPTION as RestrictActivityDescription,
                                    scd.PREVIOUS_SCHOOL_ID as PreviousSchoolID,
                                    scd.DATE_LAST_ATTENDED_SCHOOL as DateLastAttendedSchool,
                                    scd.MOTHERS_COB as MotherCountryOfBirth,
                                    scd.MOTHER_LANGUAGE as MotherLanguage,
                                    scd.MOTHER_EDUCATION_SCHOOL as MotherSchoolEducation,
                                    scd.MOTHER_EDUCATION_NONSCHOOL as MotherNonSchoolEducation,
                                    scd.MOTHER_OCCUPATIONGROUP as MotherOccupationGroup,
                                    scd.FATHERS_COB as FatherCountryOfBirth,
                                    scd.FATHER_LANGUAGE as FatherLanguage,
                                    scd.FATHER_EDUCATION_SCHOOL as FatherSchoolEducation,
                                    scd.FATHER_EDUCATION_NONSCHOOL as FatherNonSchoolEducation,
                                    scd.FATHER_OCCUPATIONGROUP as FatherOccupationGroup,
                                    dbo.ProperCase(stcob.COUNTRY_NAME) as CountryOfBirthDisplayName,
                                    stfl.LANG_DESCRIPTION as FirstHomeLanguageDisplayName,
                                    stol.LANG_DESCRIPTION as OtherHomeLanguageDisplayName,
                                    stis.IndigenousStatus as IndigenousStatusDisplayName,
                                    strs.ResidentialStatus as ResidentialStatusDisplayName,
                                    sths.HouseholdStatusDisplayText as HouseholdStatusDisplayName,
                                    dbo.ProperCase(stps.SCHOOL_NAME) as PreviousSchoolDisplayName,
                                    dbo.ProperCase(mcob.COUNTRY_NAME) as MotherCountryOfBirthDisplayName,
                                    ml.LANG_DESCRIPTION as MotherLanguageDisplayName,
                                    mse.ParentSchoolEducation as MotherSchoolEducationDisplayName,
                                    mq.ParentQualification as MotherNonSchoolEducationDisplayName,
                                    mog.ParentOccupationGroup as MotherOccupationGroupDisplayName,
                                    dbo.ProperCase(fcob.COUNTRY_NAME) as FatherCountryOfBirthDisplayName,
                                    fl.LANG_DESCRIPTION as FatherLanguageDisplayName,
                                    fse.ParentSchoolEducation as FatherSchoolEducationDisplayName,
                                    fq.ParentQualification as FatherNonSchoolEducationDisplayName,
                                    fog.ParentOccupationGroup as FatherOccupationGroupDisplayName
                                  from
                                    dbo.STUDENT_CENSUS_DATA as scd
                                    left join dbo.COUNTRY_OF_BIRTH as stcob
                                       on (stcob.COUNTRY_ID = scd.COUNTRY_OF_BIRTH)
                                    left join dbo.vwLanguage as stfl
                                       on (stfl.LANG_CODE = scd.FIRST_HOME_LANGUAGE)
                                    left join dbo.vwLanguage as stol
                                       on (stol.LANG_CODE = scd.OTHER_HOME_LANGUAGE)
                                    left join dbo.vwIndigenousStatus as stis
                                       on (stis.IndigenousStatusID = scd.KOORITORRESFLAG)
                                    left join dbo.vwResidentialStatus as strs
                                       on (strs.ResidentialStatusID = scd.RESIDENTIAL_STATUS)
                                    left join dbo.vwHouseholdStatus as sths
                                       on (sths.HouseholdStatusValue = scd.HOUSEHOLD_STATUS)
                                    left join dbo.SCHOOL as stps
                                       on (stps.SCHOOL_ID = scd.PREVIOUS_SCHOOL_ID)
                                    left join dbo.COUNTRY_OF_BIRTH as mcob
                                       on (mcob.COUNTRY_ID = scd.MOTHERS_COB)
                                    left join dbo.vwLanguage as ml
                                       on (ml.LANG_CODE = scd.MOTHER_LANGUAGE)
                                    left join dbo.vwParentSchoolEducation as mse
                                       on (mse.ParentSchoolEducationID = scd.MOTHER_EDUCATION_SCHOOL)
                                    left join dbo.vwParentQualification as mq
                                       on (mq.ParentQualificationID = scd.MOTHER_EDUCATION_NONSCHOOL)
                                    left join dbo.vwParentOccupationGroup as mog
                                       on (mog.ParentOccupationGroupID = scd.MOTHER_OCCUPATIONGROUP)
                                    left join dbo.COUNTRY_OF_BIRTH as fcob
                                       on (fcob.COUNTRY_ID = scd.FATHERS_COB)
                                    left join dbo.vwLanguage as fl
                                       on (fl.LANG_CODE = scd.FATHER_LANGUAGE)
                                    left join dbo.vwParentSchoolEducation as fse
                                       on (fse.ParentSchoolEducationID = scd.FATHER_EDUCATION_SCHOOL)
                                    left join dbo.vwParentQualification as fq
                                       on (fq.ParentQualificationID = scd.FATHER_EDUCATION_NONSCHOOL)
                                    left join dbo.vwParentOccupationGroup as fog
                                       on (fog.ParentOccupationGroupID = scd.FATHER_OCCUPATIONGROUP)
                                  where
                                    scd.STUDENT_ID = @studentID;"

            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim censusDetails As New SDBStudentCensusData()
                  With censusDetails
                     .StudentID = reader.Value(Of Decimal?)("StudentID")
                     .CountryOfBirth = reader.Value(Of Short?)("CountryOfBirth")
                     .FirstHomeLanguage = reader.Value(Of Short?)("FirstHomeLanguage")
                     .OtherHomeLanguage = reader.Value(Of Short?)("OtherHomeLanguage")
                     .IndigenousStatus = reader.Value(Of String)("IndigenousStatus")?.Trim()
                     .ResidentialStatus = reader.Value(Of String)("ResidentialStatus")?.Trim()
                     .VisaSubClass = reader.Value(Of Decimal?)("VisaSubClass")
                     .VisaStatisticalCode = reader.Value(Of String)("VisaStatisticalCode")?.Trim()
                     .VisaSector = reader.Value(Of String)("VisaSector")?.Trim()
                     .DateArrivedInAustralia = reader.Value(Of Date?)("DateArrivedInAustralia")
                     .DateStartedInAustralia = reader.Value(Of Date?)("DateStartedInAustralia")
                     .HouseholdStatus = reader.Value(Of Decimal?)("HouseholdStatus")
                     .RestrictAccessAtRisk = reader.Value(Of Boolean?)("RestrictAccessAtRisk")
                     .RestrictAccessAlert = reader.Value(Of Boolean?)("RestrictAccessAlert")
                     .RestrictAccessType = reader.Value(Of String)("RestrictAccessType")?.Trim()
                     .RestrictAccessDescription = reader.Value(Of String)("RestrictAccessDescription")?.Trim()
                     .RestrictActivityAlert = reader.Value(Of Boolean?)("RestrictActivityAlert")
                     .RestrictActivityDescription = reader.Value(Of String)("RestrictActivityDescription")?.Trim()
                     .PreviousSchoolID = reader.Value(Of Decimal?)("PreviousSchoolID")
                     .DateLastAttendedSchool = reader.Value(Of Date?)("DateLastAttendedSchool")

                     .CountryOfBirthDisplayName = reader.Value(Of String)("CountryOfBirthDisplayName")?.Trim()
                     .FirstHomeLanguageDisplayName = reader.Value(Of String)("FirstHomeLanguageDisplayName")
                     .OtherHomeLanguageDisplayName = reader.Value(Of String)("OtherHomeLanguageDisplayName")
                     .IndigenousStatusDisplayName = reader.Value(Of String)("IndigenousStatusDisplayName")
                     .ResidentialStatusDisplayName = reader.Value(Of String)("ResidentialStatusDisplayName")
                     .HouseholdStatusDisplayName = reader.Value(Of String)("HouseholdStatusDisplayName")
                     .PreviousSchoolDisplayName = reader.Value(Of String)("PreviousSchoolDisplayName")
                  End With

                  censusDetails.MotherCensusData = New SDBParentCensusData()
                  With censusDetails.MotherCensusData
                     .CountryOfBirth = reader.Value(Of Short?)("MotherCountryOfBirth")
                     .Language = reader.Value(Of Short?)("MotherLanguage")
                     .SchoolEducation = reader.Value(Of String)("MotherSchoolEducation")?.Trim()
                     .NonSchoolEducation = reader.Value(Of String)("MotherNonSchoolEducation")?.Trim()
                     .OccupationGroup = reader.Value(Of String)("MotherOccupationGroup")?.Trim()
                     .CountryOfBirthDisplayName = reader.Value(Of String)("MotherCountryOfBirthDisplayName")?.Trim()
                     .LanguageDisplayName = reader.Value(Of String)("MotherLanguageDisplayName")
                     .SchoolEducationDisplayName = reader.Value(Of String)("MotherSchoolEducationDisplayName")
                     .NonSchoolEducationDisplayName = reader.Value(Of String)("MotherNonSchoolEducationDisplayName")
                     .OccupationGroupDisplayName = reader.Value(Of String)("MotherOccupationGroupDisplayName")
                  End With

                  censusDetails.FatherCensusData = New SDBParentCensusData()
                  With censusDetails.FatherCensusData
                     .CountryOfBirth = reader.Value(Of Short?)("FatherCountryOfBirth")
                     .Language = reader.Value(Of Short?)("FatherLanguage")
                     .SchoolEducation = reader.Value(Of String)("FatherSchoolEducation")?.Trim()
                     .NonSchoolEducation = reader.Value(Of String)("FatherNonSchoolEducation")?.Trim()
                     .OccupationGroup = reader.Value(Of String)("FatherOccupationGroup")?.Trim()
                     .CountryOfBirthDisplayName = reader.Value(Of String)("FatherCountryOfBirthDisplayName")?.Trim()
                     .LanguageDisplayName = reader.Value(Of String)("FatherLanguageDisplayName")
                     .SchoolEducationDisplayName = reader.Value(Of String)("FatherSchoolEducationDisplayName")
                     .NonSchoolEducationDisplayName = reader.Value(Of String)("FatherNonSchoolEducationDisplayName")
                     .OccupationGroupDisplayName = reader.Value(Of String)("FatherOccupationGroupDisplayName")
                  End With

                  Return censusDetails
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetSDBSchoolAddressID(schoolID As Decimal, connection As SqlConnection) As Decimal?
         Using command = connection.CreateCommand()
            command.Parameters.AddWithValue("@schoolID", schoolID)
            command.CommandType = CommandType.Text
            command.CommandText = "select sch.ADDRESS_ID from dbo.SCHOOL as sch where (sch.SCHOOL_ID = @schoolID);"

            Dim result = command.ExecuteScalar()
            If (TypeOf result Is Decimal?) Then
               Return DirectCast(result, Decimal?)
            End If
         End Using

         Return Nothing
      End Function


      Private Function GetCountryAlpha2CodeDisplayName(countryAlpha2Code As String, connection As SqlConnection) As String
         If (countryAlpha2Code IsNot Nothing) Then
            Using command = connection.CreateCommand()

               command.Parameters.AddWithValue("@countryAlpha2Code", countryAlpha2Code)
               command.CommandType = CommandType.Text
               command.CommandText = "select
                                    vwca2c.Country
                                  from
                                    dbo.vwCountryAlpha2Code as vwca2c
                                  where
                                    (vwca2c.CountryAlpha2Code = @countryAlpha2Code);"

               Return TryCast(command.ExecuteScalar(), String)
            End Using
         End If

         Return Nothing
      End Function


      Private Sub UpdateStudentCarerContact(carerContact As SDBStudentCarerContact, connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            With carerContact
               command.Parameters.AddWithNull("@carerID", .CarerID)  ' The carer ID will be null for a new record; in that case the merge below will perform an insert
               command.Parameters.AddWithNull("@salutation", .Salutation)  ' AddWithNull is an extension method that ensures a DBNull when the .NET object is null
               command.Parameters.AddWithNull("@surname", .Surname)        ' It does the same thing for empty strings
               command.Parameters.AddWithNull("@firstName", .FirstName)
               command.Parameters.AddWithNull("@relationship", .Relationship)
               command.Parameters.AddWithNull("@homePhone", .HomePhone)
               command.Parameters.AddWithNull("@workPhone", .WorkPhone)
               command.Parameters.AddWithNull("@mobile", .Mobile)
               command.Parameters.AddWithNull("@email", .Email)
               command.Parameters.AddWithNull("@supervisorPosition", .SupervisorPosition)
               command.Parameters.AddWithNull("@supervisorPositionOther", .SupervisorPositionOther)
               command.Parameters.AddWithNull("@lastAlteredBy", .LastAlteredBy)
            End With

            command.CommandType = CommandType.Text
            command.CommandText = "merge into dbo.STUDENT_CARER_CONTACT as scc
                                    using
                                    (select @carerID as carerID) as src
                                    on (scc.CARER_ID = src.carerID)
                                    when matched then update set
                                                         scc.TITLE = @salutation,
                                                         scc.SURNAME = @surname,
                                                         scc.FIRST_NAME = @firstName,
                                                         scc.RELATIONSHIP = @relationship,
                                                         scc.HOME_PHONE = @homePhone,
                                                         scc.WORK_PHONE = @workPhone,
                                                         scc.MOBILE = @mobile,
                                                         scc.EMAIL = @email,
                                                         scc.SUPERVISOR_POSITION = @supervisorPosition,
                                                         scc.SUPERVISOR_POSITION_OTHER = @supervisorPositionOther,
                                                         scc.LAST_ALTERED_BY = @lastAlteredBy,
                                                         scc.LAST_ALTERED_DATE = getdate()
                                    when not matched then insert
                                                          (
                                                             TITLE,
                                                             SURNAME,
                                                             FIRST_NAME,
                                                             RELATIONSHIP,
                                                             HOME_PHONE,
                                                             WORK_PHONE,
                                                             MOBILE,
                                                             EMAIL,
                                                             SUPERVISOR_POSITION,
                                                             SUPERVISOR_POSITION_OTHER,
                                                             LAST_ALTERED_BY,
                                                             LAST_ALTERED_DATE
                                                          )
                                                          values
                                                          (
                                                             @salutation,
                                                             @surname,
                                                             @firstName,
                                                             @relationship,
                                                             @homePhone,
                                                             @workPhone,
                                                             @mobile,
                                                             @email,
                                                             @supervisorPosition,
                                                             @supervisorPositionOther,
                                                             @lastAlteredBy,
                                                             getdate()
                                                          )
                                    -- Return the updated or inserted carer ID.
                                    output
                                       Inserted.CARER_ID;"

            ' If there was no update (eg. non-null but erroneous carer ID) the cast below will fail and the error will bubble up to the caller,
            ' ideally falling outside of the SqlTransaction's "Using" clause, where the transaction will then be disposed without Commit() being invoked.
            ' If that occurs the entire transaction (including all prior database updates that have been attached to it)
            ' will be rolled back automatically.
            carerContact.CarerID = DirectCast(command.ExecuteScalar(), Decimal)
         End Using
      End Sub


      'Page class tail @1-DD082417

   End Class
End Namespace
'End Page class tail

