Option Strict On
Option Explicit On

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
Imports System.Data.SqlClient
Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

'End Using Statements

Namespace DECV_PROD2007.Student_EACL 'Namespace @1-7D1311FF

   'Forms Definition @1-C773AEAB
   Public Class [Student_EACLPage]
      Inherits CCPage
      'End Forms Definition

      'Forms Objects @1-550D6040
      Protected Student_EACLContentMeta As String
      'End Forms Objects

      'Page_Load Event @1-A2D2CF1E
      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
         'End Page_Load Event

         'Page_Load Event BeforeIsPostBack @1-E9EA7548
         Dim item As PageItem = PageItem.CreateFromHttpRequest()
         ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
         If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf, "")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref.ToString() & item.Link_BacktosummaryHrefParameters.ToString("GET", "", ViewState)
            Link_Backtosummary.DataBind()
         End If
         'End Page_Load Event BeforeIsPostBack


         If (Not IsPostBack) Then
            InitialiseAuthorisedControls()
            InitialiseTextBoxControls()

            Dim earlyAssessment = LoadStudentEarlyAssessment(StudentID, EnrolmentYear)
            Dim riskFactors = LoadStudentAssessmentRiskFactors(earlyAssessment.EarlyAssessmentID)

            InitialiseStaffLists(earlyAssessment)

            InitialiseFormControls(earlyAssessment, riskFactors)
         End If
      End Sub 'Page_Load Event tail @1-E31F8E2A


      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

      End Sub 'Page_Unload Event tail @1-E31F8E2A

      'OnInit Event @1-7CD4ED69
#Region " Web Form Designer Generated Code "
      Protected Overrides Sub OnInit(ByVal e As EventArgs)
         'End OnInit Event

         'OnInit Event Body @1-83FDEAE2
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         Student_EACLContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
         If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName)
         End If
         InitializeComponent()
         MyBase.OnInit(e)
         If Not (User.Identity.IsAuthenticated) Then
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


      ' ---------------------------------------------------------------------------------------
      ' Begin items developed in Visual Studio using standard ASP.NET Web Forms
      ' ---------------------------------------------------------------------------------------


      ' ---------------------------------------------------------------------------------------
      ' Begin page variables
      ' ---------------------------------------------------------------------------------------

      Private Const EnrolmentYearRolloverThresholdMonth = 10

      Friend Const RiskFactorCheckBoxName = "cbStudentRiskFactor"
      Friend Const RiskFactorIDAttribute = "data-riskFactorID"
      Friend Const RiskFactorCategoryAttribute = "data-riskFactorCategory"
      Private Const VSVSchoolID = 16261D
      Private Const NALADID = "N-A"

      Private Const DisabilityRiskFactorID = 12
      Private Const SelfHarmRiskFactorID = 23
      Private Const AmberLetterRiskFactorID = 34
      Private Const RedLetterRiskFactorID = 35
      Private Const PreviouslyHomeSchooledRiskFactorID = 32
      Private Const SharedEnrolmentRiskFactorID = 33

      Private Const SelfHarmValue = ",Suicide risk"
      Private Const PreviousHomeSchoolCategory = "OTHER"
      Private Const PreviousHomeSchoolSubCategory = "PREVHOME"

      Private Const ImportantCommentType = "IMPORTANT_COMMENT"
      Private Const CoordinatorCommentType = "COORD_DECISION"
      Private Const EACLCommentPrefix = "[EACL]"


      Friend Shared ReadOnly RiskCategorySortOrder As IReadOnlyDictionary(Of String, Integer) =
         New Dictionary(Of String, Integer) From {{"Learning", 1}, {"Inclusion", 2}, {"Engagement", 3}, {"Wellbeing", 4}, {"Enrolment", 5}}


      Private ReadOnly Property SignedInUserID As String
         Get
            Return DBUtility.UserId.ToString().Trim().ToUpper()
         End Get
      End Property


      Private ReadOnly Property IsHigherAuthorisedUser As Boolean
         Get
            Dim strHigherGroups As String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups")
            Dim arrHigherGroups As String() = strHigherGroups.Split(","c)
            Return DBUtility.AuthorizeUser(arrHigherGroups)
         End Get
      End Property


      Private ReadOnly Property StudentID As Decimal
         Get
            Return Decimal.Parse(Request.QueryString("STUDENT_ID"))
         End Get
      End Property


      Private ReadOnly Property EnrolmentYear As Integer
         Get
            Return Integer.Parse(Request.QueryString("ENROLMENT_YEAR"))
         End Get
      End Property


      Public Property EarlyAssessmentID As Integer?
         Get
            If (ViewState("EarlyAssessmentID") IsNot Nothing) Then
               Return DirectCast(ViewState("EarlyAssessmentID"), Integer)
            Else
               Return Nothing
            End If
         End Get
         Set(value As Integer?)
            ViewState("EarlyAssessmentID") = value
         End Set
      End Property



      ' ---------------------------------------------------------------------------------------
      ' Begin page methods
      ' ---------------------------------------------------------------------------------------


      ' Data binding complete, repeater will be populated with controls
      Protected Overrides Sub OnPreRenderComplete(e As EventArgs)
         MyBase.OnPreRenderComplete(e)

         If (Not IsHigherAuthorisedUser) Then
            Common.SetChildControlsEnabled(upStudentEACL.Controls, False)
         Else
            InitialiseStaffDropdown(ddlLearningAdvisorID)
            InitialiseStaffDropdown(ddlSSGFacilitator)
         End If
      End Sub


      Private Sub InitialiseStaffDropdown(staffDropdown As DropDownList)
         ' 17 Feb 2022|RW| Remove UNASSIGN from the list of possible options for assigning a Learning Advisor (which can end up being auto-synced to the LP teacher)
         ' However if the current selection is already set to that value it must be left as-is to prevent the ASP.NET item binding error.
         ' Annoyingly we can't simply invoke staffDropdown.Items.Remove("UNASSIGN") - only seems to work if both the name and value are matched..?
         ' At this time the system value "N-A" is not removed as an option, as setting the LADV to it will not result in the Launch Pad
         ' teacher also being set to N-A.
         ' The LADV Coordinator also may need to temporarily switch assignments back to N-A during the early period of LADV management.
         Dim itemsToRemoveIfNotSelected = {"UNASSIGN"}
         Dim itemIndex = 0
         While (itemIndex < staffDropdown.Items.Count)
            Dim listItem = staffDropdown.Items(itemIndex)
            Dim itemValue = listItem.Value.Trim().ToUpper()
            Dim itemRemoved = False
            If ((Not listItem.Selected) AndAlso itemsToRemoveIfNotSelected.Contains(itemValue)) Then
               staffDropdown.Items.RemoveAt(itemIndex)
               itemRemoved = True
            End If

            If (Not itemRemoved) Then
               itemIndex += 1
            End If
         End While
      End Sub


      Private Sub InitialiseAuthorisedControls()
         ' The PreRender event above handles the initialisation of controls for readonly users
         If (IsHigherAuthorisedUser) Then
            Panel_MenuStudentMaintain.Visible = True
            ddlLearningAdvisorID.Attributes("onchange") = "learningAdvisorChanged(this);"
            btnUpdateLearningAdvisor.Visible = True
            btnSaveEACL.Visible = True
         End If
      End Sub


      Private Sub InitialiseTextBoxControls()
         Dim textBoxControls As List(Of TextBox) = New List(Of TextBox)
         Common.GetControlList(Page.Form.Controls, textBoxControls)

         For Each textBox In textBoxControls
            If (textBox.MaxLength > 0) Then
               textBox.Attributes("maxlength") = textBox.MaxLength.ToString()
            End If

            textBox.Attributes.Add("oninput", "resizeTextBox(this);")
         Next
      End Sub


      Private Sub InitialiseStaffLists(earlyAssessment As StudentEarlyAssessment)
         sqldsLearningAdvisorID.SelectCommand = GenerateStaffListDataSourceSQL(earlyAssessment.LearningAdvisorID)
         sqldsSSGFacilitator.SelectCommand = GenerateStaffListDataSourceSQL(earlyAssessment.SSGFacilitatorID)
      End Sub


      Private Sub InitialiseFormControls(earlyAssessment As StudentEarlyAssessment, riskFactors As List(Of StudentRiskFactor))
         CheckForEnrolmentYearRollover()

         With earlyAssessment
            litPageTitle.Text = .StudentName & " - Early Assessment Checklist"

            ltStudentName.Text = .StudentName
            ltYearLevel.Text = .YearLevel
            ltSchoolsShared.Text = .SchoolsShared
            ddlLearningAdvisorID.SelectedValue = .LearningAdvisorID
            ddlSSGFacilitator.SelectedValue = .SSGFacilitatorID
            rblLearningPlan.SelectedValue = .LearningPlan

            cbOoHC.Checked = .OutOfHomeCare
            If (.OutOfHomeCare) Then
               ltOoHCDetails.Text = GenerateListItemsHtml(.OutOfHomeCareDetails)
            End If

            cbATSI.Checked = .ATSI

            cbPSDFunded.Checked = .PSDFunded
            If (.PSDFundingDetails.Count > 0) Then ltPSDDetails.Text = GenerateListItemsHtml(.PSDFundingDetails)
            cbNCCDFunded.Checked = .NCCDFunded
            hidNCCDFundingLevel.Value = .NCCDFundingLevel.ToString()
            If (.NCCDFundingDetails.Count > 0) Then ltNCCDDetails.Text = GenerateListItemsHtml(.NCCDFundingDetails)

            cbYouthJustice.Checked = .YouthJustice
            If (.YouthJustice) Then ltYouthJusticeDetails.Text = GenerateListItemsHtml(.YouthJusticeDetails)

            If (.EarlyAssessmentID.HasValue()) Then
               ' We're initialising the form using previously saved details
               ' Set the ViewState EarlyAssessmentID here
               EarlyAssessmentID = .EarlyAssessmentID

               cbAcademicLag.Checked = .AcademicLag.Value
               txtNotes.Text = .Notes

               ltEACreatedByDate.Text = Common.GetDateDisplay(.CreatedDate) & " by " & .CreatedByName
               ltEAUpdatedByDate.Text = Common.GetDateDisplay(.UpdatedDate) & " by " & .UpdatedByName
            End If
         End With

         InitialiseRiskFactorFormControls(earlyAssessment, riskFactors)
      End Sub


      Sub CheckForEnrolmentYearRollover()
         ' When staff are creating EACLs late in the year, it's very likely that they're intending to edit the student's EACL for the upcoming enrolment year
         ' Perform a simple check and display a warning and link to the upcoming year's EACL...
         If ((Date.Today().Month >= EnrolmentYearRolloverThresholdMonth) AndAlso (EnrolmentYear = Date.Today.Year)) Then
            Dim nextYear = (EnrolmentYear + 1)

            '... but only if the student's enrolment for the next year has been created on the database 
            Dim nextYearEACL = LoadStudentEarlyAssessment(StudentID, nextYear)
            If (nextYearEACL IsNot Nothing) then
               Dim builder As New StringBuilder(500)
               Dim pathForNextYear = HttpContext.Current.Request.Url.PathAndQuery.Replace("ENROLMENT_YEAR=" & EnrolmentYear.ToString(), "ENROLMENT_YEAR=" & nextYear.ToString())
               With builder
                  .Append("<div class=""warning"">")
                  .Append($"This is the {EnrolmentYear} enrolment year Early Assessment Checklist for this student.<br/>")
                  .Append($"<a href=""{pathForNextYear}"">Click here</a> to go to their {nextYear} Early Assessment Checklist.")
                  .Append("</div")
               End With

               ltEnrolmentYearWarning.Text = builder.ToString()
            End If
         End If
      End Sub


      Function GenerateListItemsHtml(items As List(Of String)) As String
         If (items.Count = 0) Then
            Return ""
         End If

         Dim builder As New StringBuilder(200)
         builder.Append("<ul style=""margin-left: 15px; margin-top: 15px;"">")
         For Each item In items
            builder.Append("<li><em>")
            builder.Append(item)
            builder.Append("</em></li>")
         Next
         builder.Append("</ul>")

         Return builder.ToString()
      End Function


      Function GeneratePreselectionNoticeHtml() As String
         Return "<p style=""font-style: italic;"">This item has been preselected for this student</p>"
      End Function


      Private Sub InitialiseRiskFactorFormControls(earlyAssessment As StudentEarlyAssessment, riskFactors As List(Of StudentRiskFactor))
         InitialiseRiskFactors(earlyAssessment, riskFactors)

         riskFactors.Sort()
         Dim lastRiskFactorCategory As String = Nothing
         For Each riskFactor As StudentRiskFactor In riskFactors
            If (Not riskFactor.RiskCategory.Equals(lastRiskFactorCategory)) Then
               riskFactor.IsHeaderRow = True
               lastRiskFactorCategory = riskFactor.RiskCategory
            End If
         Next

         rptEACL.DataSource = riskFactors
         rptEACL.DataBind()
      End Sub


      Private Sub InitialiseRiskFactors(earlyAssessment As StudentEarlyAssessment, riskFactorList As List(Of StudentRiskFactor))
         Dim riskFactors = New Dictionary(Of Integer, StudentRiskFactor)(riskFactorList.Count)
         For Each riskFactor As StudentRiskFactor In riskFactorList
            riskFactors(riskFactor.RiskFactorID) = riskFactor
         Next

         AddDisabilityInformation(earlyAssessment, riskFactors(DisabilityRiskFactorID))

         If (Not earlyAssessment.EarlyAssessmentID.HasValue()) Then
            ' Preselect values only for new forms
            With earlyAssessment
               PreselectRiskFactor(earlyAssessment, riskFactors(DisabilityRiskFactorID), .PractitionerDiagnosedDisabilities.Length > 0)
               PreselectRiskFactor(earlyAssessment, riskFactors(SelfHarmRiskFactorID), .PractitionerDiagnosedPrimaryIssues.Contains(SelfHarmValue))
               PreselectRiskFactor(earlyAssessment, riskFactors(AmberLetterRiskFactorID), .AmberLetterSentLastYear)
               PreselectRiskFactor(earlyAssessment, riskFactors(RedLetterRiskFactorID), .RedLetterSendLastYear)
               PreselectRiskFactor(earlyAssessment, riskFactors(PreviouslyHomeSchooledRiskFactorID), (.EnrolmentCategory.Equals(PreviousHomeSchoolCategory) AndAlso
                                                                                                   .EnrolmentSubcategory.Equals(PreviousHomeSchoolSubCategory)))
               'PreselectRiskFactor(earlyAssessment, riskFactors(SharedEnrolmentRiskFactorID), Something here once I get a definitive answer on what the criteria is for a shared enrolment)
            End With
         End If
      End Sub


      Private Sub PreselectRiskFactor(earlyAssessment As StudentEarlyAssessment, riskFactor As StudentRiskFactor, isPreselected As Boolean)
         If (isPreselected) Then
            riskFactor.IsSelected = True
            riskFactor.IsPreselected = True
         End If
      End Sub


      Private Sub AddDisabilityInformation(earlyAssessment As StudentEarlyAssessment, riskFactor As StudentRiskFactor)
         If (earlyAssessment.PractitionerDiagnosedDisabilities.Length > 0) Then
            riskFactor.AdditionalInformation.Add(earlyAssessment.PractitionerDiagnosedDisabilities)
         End If
      End Sub


      Function GenerateRiskFactorDisplayHeader(studentRiskFactor As StudentRiskFactor) As String
         Return $"<tr class=""Header {studentRiskFactor.RiskCategory}"">
                     <th colspan=""3"">
                           <span>{studentRiskFactor.RiskCategory}</span>
                     </th>
                  </tr>
                  <tr class=""Caption {studentRiskFactor.RiskCategory}"">
                     <td colspan=""2"">
                        <strong>Risk Factor</strong>
                     </td>
                     <td>
                        <strong>Actions</strong>
                     </td>
                  </tr>"
      End Function


      Function GenerateRiskFactorActionsDisplay(riskFactorActions As List(Of RiskFactorAction)) As String
         Dim actionDisplay = New StringBuilder()
         actionDisplay.Append("<ul>")
         For Each action As RiskFactorAction In riskFactorActions
            actionDisplay.Append("<li>")
            actionDisplay.Append(action.DisplayText)
            actionDisplay.Append("</li>")
         Next
         actionDisplay.Append("</ul>")

         Return actionDisplay.ToString()
      End Function


      Protected Sub btnUpdateLearningAdvisor_Click(sender As Object, e As EventArgs) Handles btnUpdateLearningAdvisor.Click
         SaveStudentLearningAdvisor()
      End Sub


      Protected Sub btnSaveEACL_Click(sender As Object, e As EventArgs) Handles btnSaveEACL.Click
         SaveStudentEarlyAssessment()
      End Sub


      Private Sub SaveStudentLearningAdvisor()
         Dim earlyAssessment = PopulateEarlyAssessment()
         SaveStudentLearningAdvisor(earlyAssessment, SignedInUserID)
      End Sub


      Private Sub SaveStudentEarlyAssessment()
         Dim earlyAssessment = PopulateEarlyAssessment()
         Dim riskFactors = PopulateSelectedRiskFactors()

         SaveEarlyAssessment(earlyAssessment, riskFactors, IsHigherAuthorisedUser, SignedInUserID)

         If (Not EarlyAssessmentID.HasValue()) Then
            ' Set the ViewState EarlyAssessmentID, to ensure the integrity of further saves
            EarlyAssessmentID = earlyAssessment.EarlyAssessmentID

            ltEACreatedByDate.Text = Common.GetDateDisplay(Date.Now()) & " by " & SignedInUserID
         End If

         ltEAUpdatedByDate.Text = Common.GetDateDisplay(Date.Now()) & " by " & SignedInUserID
      End Sub


      Private Function PopulateEarlyAssessment() As StudentEarlyAssessment
         Dim earlyAssessment = New StudentEarlyAssessment()
         With earlyAssessment
            .StudentID = StudentID
            .EnrolmentYear = EnrolmentYear

            .EarlyAssessmentID = EarlyAssessmentID
            .AcademicLag = cbAcademicLag.Checked
            .Notes = txtNotes.Text.Trim()

            .LearningAdvisorID = ddlLearningAdvisorID.SelectedValue
            .SSGFacilitatorID = ddlSSGFacilitator.SelectedValue
            .LearningPlan = rblLearningPlan.SelectedValue
         End With

         Return earlyAssessment
      End Function


      Private Function PopulateSelectedRiskFactors() As List(Of Integer)
         Dim selectedRiskFactors As New List(Of Integer)()

         Dim checkboxes As New List(Of CheckBox)()
         Common.GetControlList(rptEACL.Controls, checkboxes, RiskFactorCheckBoxName)

         For Each checkbox As CheckBox In checkboxes
            If (checkbox.Checked) Then
               selectedRiskFactors.Add(Integer.Parse(checkbox.Attributes(RiskFactorIDAttribute)))
            End If
         Next

         Return selectedRiskFactors
      End Function


      Sub RedirectToUrl(url As String)
         Response.Redirect(url, False)
         Context.ApplicationInstance.CompleteRequest()
      End Sub


      ' ---------------------------------------------------------------------------------------
      ' Begin data types. View and model details are combined
      ' ---------------------------------------------------------------------------------------


      Class StudentEarlyAssessment
         Friend StudentID As Decimal
         Friend EnrolmentCategory As String
         Friend EnrolmentSubcategory As String
         Friend EnrolmentYear As Integer
         Friend StudentName As String
         Friend YearLevel As String
         Friend EnrolmentStatus As String
         Friend HomeSchoolID As Decimal?
         Friend SchoolsShared As String
         Friend SSGFacilitatorID As String  ' Student Support Group Facilitator

         Friend LearningAdvisorID As String
         Friend LearningPlan As String

         Friend OutOfHomeCare As Boolean
         Friend OutOfHomeCareDetails As New List(Of String)()
         Friend ATSI As Boolean
         Friend PSDFunded As Boolean
         Friend PSDFundingDetails As New List(Of String)()
         Friend NCCDFunded As Boolean
         Friend NCCDFundingLevel As Integer
         Friend NCCDFundingDetails As New List(Of String)()
         Friend YouthJustice As Boolean
         Friend YouthJusticeDetails As New List(Of String)()

         Friend PractitionerDiagnosedPrimaryIssues As String
         Friend PractitionerDiagnosedDisabilities As String
         Friend AmberLetterSentLastYear As Boolean
         Friend RedLetterSendLastYear As Boolean

         Friend EarlyAssessmentID As Integer?
         Friend AcademicLag As Boolean?
         Friend Notes As String
         Friend CreatedByName As String
         Friend CreatedDate As Date?
         Friend UpdatedByName As String
         Friend UpdatedDate As Date?
      End Class


      Class StudentRiskFactor
         Implements IComparable(Of StudentRiskFactor)
         Friend RiskFactorID As Integer
         Friend RiskCategory As String
         Friend DisplayText As String
         Friend DisplayOrder As Integer

         Friend AdditionalInformation As New List(Of String)()
         '         Friend Weighting As Integer
         '         Friend RolloverApplies As Boolean

         Friend Actions As List(Of RiskFactorAction) = New List(Of RiskFactorAction)

         Friend IsSelected As Boolean
         Friend IsPreselected As Boolean
         Friend IsHeaderRow As Boolean


         Public Function CompareTo(other As StudentRiskFactor) As Integer Implements IComparable(Of StudentRiskFactor).CompareTo
            ' Sort by the defined risk category display order above, and then by the risk factor ID (ie. oldest items first)
            Dim categoryComparison = RiskCategorySortOrder(RiskCategory).CompareTo(RiskCategorySortOrder(other.RiskCategory))
            Return If(categoryComparison <> 0, categoryComparison, DisplayOrder.CompareTo(other.DisplayOrder))
         End Function
      End Class


      Class RiskFactorAction
         Public DisplayText As String
         Public Url As String
      End Class


      ' ---------------------------------------------------------------------------------------
      ' Begin data access
      ' ---------------------------------------------------------------------------------------


      Private Function GenerateStaffListDataSourceSQL(assignedStaffID As String) As String
         ' An error will occur if we try to select a non-existent item in the dropdown list
         ' This can occur if we only retrieve active staff members: a staff member can become inactive, but still be assigned in the database for the dropdown field
         ' So, tweak the SQL to retrieve staff who are either active or who match the assigned ID
         Dim staffFilter = If(assignedStaffID.Length > 0, $"((stf.STATUS = 'true') or (stf.STAFF_ID = '{assignedStaffID}'))", "(stf.STATUS = 'true')")
         Return $"select
                     rtrim(stf.STAFF_ID) as STAFF_ID,
                     dbo.ProperCase(concat(rtrim(stf.FIRSTNAME), ' ', rtrim(stf.SURNAME))) as StaffName
                  from
                     dbo.STAFF as stf
                  where
                     {staffFilter}
                     and (stf.STAFF_ID not like 'NSUBMIT%')
                  order by stf.FIRSTNAME, stf.SURNAME;"
      End Function


      Private Function LoadStudentEarlyAssessment(studentID As Decimal, enrolmentYear As Integer) As StudentEarlyAssessment
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()

               command.CommandType = CommandType.Text
               command.Parameters.AddWithValue("@studentID", studentID)
               command.Parameters.AddWithValue("@enrolmentYear", enrolmentYear)

               command.CommandText = "select
                                       s.STUDENT_ID as StudentID,
                                       rtrim(s.CATEGORY_CODE) as Category,
                                       rtrim(s.SUBCATEGORY_CODE) as Subcategory,
                                       se.ENROLMENT_YEAR as EnrolmentYear,
                                       se.ENROLMENT_STATUS as EnrolmentStatus,
                                       concat(isnull(nullif(s.PREFERRED_NAME, ''), rtrim(s.FIRST_NAME)), ' ', rtrim(s.SURNAME)) as StudentName,
                                       se.YEAR_LEVEL as YearLevel,
                                       s.HOME_SCHOOL_ID as HomeSchoolID,
                                       dbo.ProperCase(rtrim(sch.SCHOOL_NAME)) as HomeSchoolName,
                                       rtrim(se.PASTORAL_CARE_ID) as LearningAdvisorID,
                                       rtrim(se.SSG_FACILITATOR_ID) as SSGFacilitatorID,
                                       se.LEARNING_PROGRAM as LearningPlan,
                                       scd.HOUSEHOLD_STATUS as HouseholdStatus,
                                       scd.KOORITORRESFLAG as ATSIStatus,
                                       smd.PSD_FUNDING_ELIGIBLE as PSDFundingEligible,
                                       smd.PSD_FUNDING_CATEGORY as PSDFundingCategory,
                                       smd.PSD_FUNDING_LEVEL as PSDFundingLevel,
                                       smd.NCCD_FUNDING_APPROVED as NCCDFundingApproved,
                                       smd.NCCD_FUNDING_CATEGORY as NCCDFundingCategory,
                                       vnfc.NCCDFundingCategoryDisplayText,
                                       smd.NCCD_FUNDING_LEVEL as NCCDFundingLevel,
                                       vnfl.NCCDFundingLevelDisplayText,
                                       scd.YOUTH_JUSTICE_INVOLVEMENT as YouthJustice,
                                       scd.YOUTH_JUSTICE_INVOLVEMENT_DETAILS as YouthJusticeDetails,
                                       smd.PRACTITIONER_PRIMARY_ISSUES as PractitionerPrimaryIssues,
                                       smd.PRACTITIONER_DISABILITIES as PractitionerDisabilities,
                                       garlly.AMBER_LETTER_SENT_FLAG as AmberLetterSentLastYear,
                                       garlly.RED_LETTER_SENT_FLAG as RedLetterSentLastYear,
                                       eas.EarlyAssessmentID,
                                       eas.AcademicLag,
                                       eas.Notes as EarlyAssessmentNotes,
                                       dbo.ProperCase(concat(rtrim(cb.FIRSTNAME), ' ', rtrim(cb.SURNAME))) as EarlyAssessmentCreatedBy,
                                       eas.CreatedDate as EarlyAssessmentCreatedDate,
                                       dbo.ProperCase(concat(rtrim(ub.FIRSTNAME), ' ', rtrim(ub.SURNAME))) as EarlyAssessmentUpdatedBy,
                                       eas.UpdatedDate as EarlyAssessmentUpdatedDate
                                     from
                                       dbo.STUDENT as s
                                       inner join dbo.STUDENT_ENROLMENT as se
                                          on (
                                                (se.STUDENT_ID = s.STUDENT_ID)
                                                and (se.ENROLMENT_YEAR = @enrolmentYear)
                                             )
                                       left join dbo.SCHOOL as sch
                                          on (sch.SCHOOL_ID = s.HOME_SCHOOL_ID)
                                       left join dbo.STAFF as lad
                                          on (lad.STAFF_ID = se.PASTORAL_CARE_ID)
                                       left join dbo.STUDENT_CENSUS_DATA as scd
                                          on (scd.STUDENT_ID = s.STUDENT_ID)
                                       left join dbo.STUDENT_MEDICAL_DETAILS as smd
                                          on (smd.STUDENT_ID = s.STUDENT_ID)
                                       left join dbo.vwNCCDFundingCategory as vnfc
                                          on (vnfc.NCCDFundingCategoryValue = smd.NCCD_FUNDING_CATEGORY)
                                       left join dbo.vwNCCDFundingLevel as vnfl
                                          on (vnfl.NCCDFundingLevelValue = smd.NCCD_FUNDING_LEVEL)
                                       left join dbo.GREEN_AMBER_RED_LETTERS as garlly
                                          on (
                                                (garlly.STUDENT_ID = s.STUDENT_ID)
                                                and (garlly.ENROLMENT_YEAR = (@enrolmentYear - 1))
                                             )
                                       left join dbo.EARLY_ASSESSMENT_STUDENT as eas
                                          on (
                                                (eas.IsDeleted = 'false')
                                                and (eas.STUDENT_ID = s.STUDENT_ID)
                                                and (eas.ENROLMENT_YEAR = se.ENROLMENT_YEAR)
                                             )
                                       left join dbo.STAFF as cb
                                          on (cb.STAFF_ID = eas.CreatedBy)
                                       left join dbo.STAFF as ub
                                          on (ub.STAFF_ID = eas.UpdatedBy)
                                     where
                                       (s.STUDENT_ID = @studentID);"

               Dim reader = command.ExecuteReader()
               If (reader.Read()) Then
                  Dim yearLevel = reader.Value(Of Short?)("YearLevel")
                  Dim homeSchoolID = reader.Value(Of Decimal?)("HomeSchoolID")
                  Dim homeSchool = reader("HomeSchoolName").ToString()
                  Dim learningAdvisorID = reader("LearningAdvisorID").ToString()
                  Dim learningPlan = reader("LearningPlan").ToString()

                  Dim householdStatus = reader.Value(Of Decimal?)("HouseholdStatus").GetValueOrDefault(-1)
                  Dim atsiStatus = reader("ATSIStatus").ToString()
                  Dim psdFundingApproved = reader.Value(Of Boolean?)("PSDFundingEligible").GetValueOrDefault(False)
                  Dim psdFundingCategories = reader("PSDFundingCategory").ToString().Trim({"0"c, ","c})
                  Dim psdFundingLevel = reader("PSDFundingLevel").ToString()
                  Dim nccdFundingApproved = reader.Value(Of Boolean?)("NCCDFundingApproved").GetValueOrDefault(False)
                  Dim nccdFundingCategoryValue = reader.Value(Of Byte?)("NCCDFundingCategory").GetValueOrDefault(0)
                  Dim nccdFundingCategoryDisplayText = reader("NCCDFundingCategoryDisplayText").ToString()
                  Dim nccdFundingLevelValue = reader.Value(Of Byte?)("NCCDFundingLevel").GetValueOrDefault(0)
                  Dim nccdFundingLevelDisplayText = reader("NCCDFundingLevelDisplayText").ToString()
                  Dim youthJustice = reader.Value(Of Boolean?)("YouthJustice").GetValueOrDefault(False)
                  Dim diagnosedPrimaryIssues = reader("PractitionerPrimaryIssues").ToString().Trim({"0"c, ","c})
                  Dim diagnosedDisabilities = reader("PractitionerDisabilities").ToString().Trim({"0"c, ","c})
                  Dim amberLetterSentLastYear = reader("AmberLetterSentLastYear").ToString()
                  Dim redLetterSendLastYear = reader("RedLetterSentLastYear").ToString()

                  Return New StudentEarlyAssessment() With
                  {
                     .StudentID = studentID,
                     .EnrolmentCategory = reader("Category").ToString(),
                     .EnrolmentSubcategory = reader("Subcategory").ToString(),
                     .EnrolmentYear = enrolmentYear,
                     .StudentName = reader("StudentName").ToString(),
                     .YearLevel = If(yearLevel = 0, "Foundation", "Year " & yearLevel.ToString()),
                     .SchoolsShared = If(VSVSchoolID = homeSchoolID, homeSchool, "Virtual School Victoria and " & homeSchool),
                     .LearningAdvisorID = learningAdvisorID,
                     .SSGFacilitatorID = reader("SSGFacilitatorID").ToString(),
                     .LearningPlan = If(learningPlan.Equals("PLP") OrElse learningPlan.Equals("PLSP"), learningPlan, ""),
                     .OutOfHomeCare = ((householdStatus = 3) OrElse (householdStatus = 6) OrElse (householdStatus = 7)),
                     .OutOfHomeCareDetails = GetOutOfHomeCareDetails(householdStatus),
                     .ATSI = (atsiStatus.Equals("K") OrElse atsiStatus.Equals("T") OrElse atsiStatus.Equals("B")),
                     .PSDFunded = psdFundingApproved OrElse (Not psdFundingCategories.Equals("")),
                     .PSDFundingDetails = GetPSDFundingDetails(psdFundingCategories, psdFundingLevel),
                     .NCCDFunded = nccdFundingApproved OrElse (nccdFundingCategoryValue <> 0),
                     .NCCDFundingLevel = nccdFundingLevelValue,
                     .NCCDFundingDetails = GetNCCDFundingDetails(nccdFundingCategoryDisplayText, nccdFundingLevelDisplayText),
                     .YouthJustice = youthJustice,
                     .YouthJusticeDetails = GetYouthJusticeDetails(reader.Value(Of String)("YouthJusticeDetails")),
                     .PractitionerDiagnosedPrimaryIssues = diagnosedPrimaryIssues,
                     .PractitionerDiagnosedDisabilities = diagnosedDisabilities,
                     .AmberLetterSentLastYear = amberLetterSentLastYear.Equals("Y"),
                     .RedLetterSendLastYear = redLetterSendLastYear.Equals("Y"),
                     .EarlyAssessmentID = reader.Value(Of Integer?)("EarlyAssessmentID"),
                     .AcademicLag = reader.Value(Of Boolean?)("AcademicLag"),
                     .Notes = reader("EarlyAssessmentNotes").ToString(),
                     .CreatedByName = reader("EarlyAssessmentCreatedBy").ToString(),
                     .CreatedDate = reader.Value(Of Date?)("EarlyAssessmentCreatedDate"),
                     .UpdatedByName = reader("EarlyAssessmentUpdatedBy").ToString(),
                     .UpdatedDate = reader.Value(Of Date?)("EarlyAssessmentUpdatedDate")
                  }
               End If
            End Using
         End Using

         Return Nothing
      End Function


      Private Function GetOutOfHomeCareDetails(householdStatus As Decimal) As List(Of String)
         Select Case householdStatus
            Case 3
               Return New List(Of String)() From {"Informal"}
            Case 6
               Return New List(Of String)() From {"Statutory/Court-ordered"}
            Case 7
               Return New List(Of String)() From {"Permanent Care"}
            Case Else
               Return New List(Of String)()
         End Select
      End Function


      Private Function GetPSDFundingDetails(psdFundingCategories As String, psdFundingLevel As String) As List(Of String)
         Dim details As New List(Of String)()
         If (psdFundingCategories.Length > 0) Then details.Add("PSD categories: " & psdFundingCategories)
         If (psdFundingLevel.Length > 0) Then details.Add(psdFundingLevel & " PSD funding")
         Return details
      End Function


      Private Function GetNCCDFundingDetails(nccdFundingCategory As String, nccdFundingLevel As String) As List(Of String)
         Dim details As New List(Of String)()
         If (nccdFundingCategory.Length > 0) Then details.Add("NCCD category: " & nccdFundingCategory)
         If (nccdFundingLevel.Length > 0) Then details.Add(nccdFundingLevel & " NCCD funding level")
         Return details
      End Function


      Private Function GetYouthJusticeDetails(youthJusticeDetails As String) As List(Of String)
         If (Not String.IsNullOrEmpty(youthJusticeDetails)) Then
            Return New List(Of String)() From {youthJusticeDetails}
         Else
            Return New List(Of String)()
         End If
      End Function


      Private Function LoadStudentAssessmentRiskFactors(earlyAssessmentID As Integer?) As List(Of StudentRiskFactor)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.Parameters.AddWithValue("@earlyAssessmentID", If(earlyAssessmentID, SqlInt32.Null))

               'Retrieve the risk factors And associated actions that are either
               ' - currently marked as active
               ' - Or, linked to the specified student assessment (optional, may be null)
               ' 
               ' This logic is intended to ensure that risk factors will still appear when retrieving historical student early assessments,
               ' even if the risk factors have since been deactivated
               ' 
               ' The query has an explicit order by clause to facilitate attaching actions to the associated risk factors
               command.CommandText = "with
                                    SelectedRisks (RiskFactorID) as -- Previously selected risk factors
                                    (
                                       select
                                          easrf.RiskFactorID
                                          --easrf.AdditionalStrategies
                                        from
                                          dbo.EARLY_ASSESSMENT_STUDENT_RISK_FACTOR as easrf
                                        where
                                          (easrf.IsDeleted = 'false')
                                          and (easrf.EarlyAssessmentID = @earlyAssessmentID)
                                    )
                                  select
                                     earf.RiskFactorID,
                                     earf.RiskCategory,
                                     earf.RiskFactorDisplayText,
                                     earf.RiskFactorDisplayOrder,
                                     --earf.RolloverApplies,
                                     eaa.ActionDisplayText,
                                     cast(iif(SelectedRisks.RiskFactorID is null, 'false', 'true') as bit) as IsSelected
                                     --SelectedRisks.AdditionalStrategies
                                   from
                                     dbo.EARLY_ASSESSMENT_RISK_FACTOR as earf
                                     left join dbo.EARLY_ASSESSMENT_RISK_FACTOR_ACTION as earfa
                                        on (
                                              (earfa.RiskFactorID = earf.RiskFactorID)
                                              and (earfa.IsDeleted = 'false')
                                           )
                                     left join dbo.EARLY_ASSESSMENT_ACTION as eaa
                                        on (
                                              (eaa.ActionID = earfa.ActionID)
                                              and (eaa.IsDeleted = 'false')
                                              and (eaa.IsAvailable = 'true')
                                           )
                                     left join SelectedRisks
                                        on (SelectedRisks.RiskFactorID = earf.RiskFactorID)
                                   where
                                     (earf.IsDeleted = 'false')
                                     and
                                     (
                                        -- Either it's available for selection, or it's been previously selected
                                        (earf.IsAvailable = 'true')
                                        or (SelectedRisks.RiskFactorID is not null)
                                     )
                                   order by
                                     earf.RiskFactorID,
                                     earfa.RiskFactorActionID;"

               Dim riskFactors = New List(Of StudentRiskFactor)()
               Dim reader = command.ExecuteReader()
               Dim riskFactor As StudentRiskFactor = Nothing
               Dim lastRiskFactorID As Integer?

               While (reader.Read())
                  Dim riskFactorID = reader.Value(Of Integer)("RiskFactorID")
                  If (Not riskFactorID.Equals(lastRiskFactorID)) Then
                     riskFactor = New StudentRiskFactor() With
                     {
                        .RiskFactorID = riskFactorID,
                        .RiskCategory = reader("RiskCategory").ToString(),
                        .DisplayText = reader("RiskFactorDisplayText").ToString(),
                        .DisplayOrder = reader.Value(Of Byte)("RiskFactorDisplayOrder"),
                        .IsSelected = reader.Value(Of Boolean)("IsSelected")
                     }

                     riskFactors.Add(riskFactor)
                     lastRiskFactorID = riskFactorID
                  End If

                  ' The actions have been sorted in order of risk factor ID, so we can add them to the current risk factor object
                  ' without using a hashtable
                  riskFactor.Actions.Add(New RiskFactorAction() With
                  {
                     .DisplayText = reader.Value(Of String)("ActionDisplayText")
                  })
               End While

               Return riskFactors
            End Using
         End Using
      End Function


      Private Sub SaveStudentLearningAdvisor(earlyAssessment As StudentEarlyAssessment, updatedBy As String)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using transaction = connection.BeginTransaction("Save Student Learning Advisor")
               Using command = connection.CreateCommand()
                  command.Transaction = transaction

                  If (earlyAssessment.LearningAdvisorID.Length > 0) Then
                     SaveStudentLearningAdvisor(earlyAssessment, updatedBy, connection, transaction)
                  End If

                  transaction.Commit()
               End Using
            End Using
         End Using
      End Sub


      Private Sub SaveEarlyAssessment(earlyAssessment As StudentEarlyAssessment, selectedRiskFactors As List(Of Integer),
                                      updateHigherLevelAccessItems As Boolean, updatedBy As String)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using transaction = connection.BeginTransaction("Save Student EACL")
               Using command = connection.CreateCommand()
                  command.Transaction = transaction

                  If (earlyAssessment.EarlyAssessmentID.HasValue()) Then
                     UpdateEarlyAssessmentMasterRecord(earlyAssessment, updatedBy, connection, transaction)
                  Else
                     ' Create a new early assessment
                     ' Side-effect: the new early assessment ID will be assigned to the StudentEarlyAssessment record
                     InsertEarlyAssessmentMasterRecord(earlyAssessment, updatedBy, connection, transaction)
                  End If

                  SaveRiskFactors(earlyAssessment.EarlyAssessmentID.Value, selectedRiskFactors, updatedBy, connection, transaction)

                  If (updateHigherLevelAccessItems) Then
                     If (earlyAssessment.LearningAdvisorID.Length > 0) Then
                        SaveStudentLearningAdvisor(earlyAssessment, updatedBy, connection, transaction)
                     End If

                     SaveStudentSSGFacilitator(earlyAssessment, updatedBy, connection, transaction)
                     SaveStudentLearningPlan(earlyAssessment, updatedBy, connection, transaction)
                  End If

                  transaction.Commit()
               End Using
            End Using
         End Using
      End Sub


      ' Side-effect: the new early assessment ID will be assigned to the StudentEarlyAssessment record
      Private Sub InsertEarlyAssessmentMasterRecord(earlyAssessment As StudentEarlyAssessment, updatedBy As String,
                                                    connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", earlyAssessment.StudentID)
            command.Parameters.AddWithValue("@enrolmentYear", earlyAssessment.EnrolmentYear)
            command.Parameters.AddWithValue("@academicLag", earlyAssessment.AcademicLag)
            command.Parameters.AddWithNull("@notes", earlyAssessment.Notes)
            command.Parameters.AddWithNull("@updatedBy", updatedBy)

            command.CommandType = CommandType.Text
            command.CommandText = "insert dbo.EARLY_ASSESSMENT_STUDENT
                                    (
                                       STUDENT_ID,
                                       ENROLMENT_YEAR,
                                       AcademicLag,
                                       Notes,
                                       CreatedBy,
                                       UpdatedBy
                                    )
                                    output Inserted.EarlyAssessmentID
                                    values
                                    (
                                       @studentID,
                                       @enrolmentYear,
                                       @academicLag,
                                       @notes,
                                       @updatedBy,
                                       @updatedBy
                                    );"
            Dim result = command.ExecuteScalar()
            ' Set the assessment ID on the object to the newly inserted record's ID
            earlyAssessment.EarlyAssessmentID = DirectCast(result, Integer)
         End Using

         If (earlyAssessment.Notes.Length > 0) Then
            SaveCommentRecord(earlyAssessment.StudentID, ImportantCommentType, EACLCommentPrefix & " " & earlyAssessment.Notes, updatedBy, connection, transaction)
         End If

         SaveAuditRecord(earlyAssessment, "EACLI", Nothing, updatedBy, connection, transaction)
      End Sub


      Private Sub UpdateEarlyAssessmentMasterRecord(earlyAssessment As StudentEarlyAssessment, updatedBy As String,
                                                    connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@earlyAssessmentID", earlyAssessment.EarlyAssessmentID)
            command.Parameters.AddWithValue("@academicLag", earlyAssessment.AcademicLag)
            command.Parameters.AddWithNull("@notes", earlyAssessment.Notes)
            command.Parameters.AddWithNull("@updatedBy", updatedBy)

            command.CommandType = CommandType.Text
            command.CommandText = "update
                                    dbo.EARLY_ASSESSMENT_STUDENT
                                  set
                                    AcademicLag = @academicLag,
                                    Notes = @notes,
                                    UpdatedBy = @updatedBy,
                                    UpdatedDate = getdate()
                                  output
                                    Deleted.AcademicLag as OldAcademicLag,
                                    Deleted.Notes as OldNotes
                                  where
                                    (EarlyAssessmentID = @earlyAssessmentID)
                                    and ((isnull(@academicLag, '') <> isnull(AcademicLag, ''))
                                      or (isnull(@notes, '') <> isnull(Notes, '')));"

            Using reader = command.ExecuteReader()
               If (reader.Read()) Then
                  ' At least one field has changed and the record has been updated
                  ' The previous flag for academic lag is currently unused, but capture it here in case there's an identified need for auditing
                  Dim oldAcademicLag = reader.Value(Of Boolean?)("OldAcademicLag")
                  Dim oldNotes = reader("OldNotes").ToString()

                  ' Close the reader to prevent errors during other updates
                  reader.Close()

                  If ((earlyAssessment.Notes.Length > 0) AndAlso (Not earlyAssessment.Notes.Equals(oldNotes))) Then
                     SaveCommentRecord(earlyAssessment.StudentID, ImportantCommentType, EACLCommentPrefix & " " & earlyAssessment.Notes, updatedBy, connection, transaction)
                  End If

                  SaveAuditRecord(earlyAssessment, "EACLU", Nothing, updatedBy, connection, transaction)
               End If
            End Using
         End Using
      End Sub


      Private Sub SaveRiskFactors(earlyAssessmentID As Integer, selectedRiskFactorIDs As List(Of Integer), updatedBy As String,
                                  connection As SqlConnection, transaction As SqlTransaction)
         ' Convert the raw list of selected risk factor objects into a T-SQL compatible structured list of SqlDataRecords of type dbo.TVP_IntSet
         Dim selectedRiskFactorTVP As New List(Of SqlDataRecord)()
         Dim sqlMetadata As SqlMetaData() = {New SqlMetaData("ID", SqlDbType.Int)}

         For Each riskFactorID In selectedRiskFactorIDs
            Dim sqlDataRecord = New SqlDataRecord(sqlMetadata)
            sqlDataRecord.SetInt32(0, riskFactorID)
            selectedRiskFactorTVP.Add(sqlDataRecord)
         Next

         SaveRiskFactors(earlyAssessmentID, selectedRiskFactorTVP, updatedBy, connection, transaction)
      End Sub


      Private Sub SaveRiskFactors(earlyAssessmentID As Integer, riskFactorTVP As List(Of SqlDataRecord), updatedBy As String,
                                  connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@earlyAssessmentID", earlyAssessmentID)
            If (riskFactorTVP.Count > 0) Then
               command.Parameters.Add(New SqlParameter("@riskFactorIDs", SqlDbType.Structured) With {.TypeName = "dbo.TVP_IntSet", .Value = riskFactorTVP})
            Else
               command.Parameters.Add(New SqlParameter("@riskFactorIDs", SqlDbType.Structured) With {.TypeName = "dbo.TVP_IntSet", .Value = Nothing})
            End If
            command.Parameters.AddWithValue("@updatedBy", updatedBy)

            ' Use a merge statement to "sync" the existing state of the assessment's risk factors with the updated list of selected risk factors
            ' Link the set of proposed active IDs to the master table to validate that the IDs are valid
            ' Also validate that the list of proposed IDs are currently active and not logically deleted
            ' Note: the "when not matched by source" clause in combination with this validation allows the possibility of applying current risk factor rules to
            ' historical records, if they are again saved
            ' Mark as active the IDs that have previously been active but are no longer active, and are in the new set of active IDs
            ' Mark as deleted the IDs that are still active but are no longer in the set of active IDs
            ' Add the other IDs that don't already exist
            command.CommandText = "merge into dbo.EARLY_ASSESSMENT_STUDENT_RISK_FACTOR as easrf
                                       using (@riskFactorIDs as selectedRiskFactors
                                             -- Link the incoming risk factors to the master table to validate that they exist
                                             -- Also validate that the risk factor is active
                                             inner join dbo.EARLY_ASSESSMENT_RISK_FACTOR as earf
                                                on (earf.RiskFactorID = selectedRiskFactors.ID)
                                                   and (earf.IsAvailable = 'true')
                                                   and (earf.IsDeleted = 'false'))
                                       on (
                                             (selectedRiskFactors.ID = easrf.RiskFactorID)
                                             and (easrf.EarlyAssessmentID = @earlyAssessmentID)
                                          )
                                       -- The risk factor has previously been selected and written but is marked as deleted - undelete it
                                       when matched and (easrf.IsDeleted = 'true') then update set
                                                                                           easrf.IsDeleted = 'false',
                                                                                           easrf.UpdatedBy = @updatedBy,
                                                                                           easrf.UpdatedDate = getdate()
                                       -- The risk factor on the database is not amongst the updated set of selected risk factors - mark as deleted
                                       when not matched by source and (easrf.EarlyAssessmentID = @earlyAssessmentID)
                                                                     and (easrf.IsDeleted = 'false') then update set
                                                                                                          easrf.IsDeleted = 'true',
                                                                                                          easrf.UpdatedBy = @updatedBy,
                                                                                                          easrf.UpdatedDate = getdate()
                                       -- The risk factor doesn't exist for the assessment - add it
                                       when not matched then insert
                                                             (
                                                                EarlyAssessmentID,
                                                                RiskFactorID,
                                                                CreatedBy,
                                                                UpdatedBy
                                                             )
                                                             values
                                                             (
                                                                @earlyAssessmentID,
                                                                selectedRiskFactors.ID,
                                                                @updatedBy,
                                                                @updatedBy
                                                             );"
            command.ExecuteNonQuery()
         End Using
      End Sub


      Private Sub SaveStudentLearningAdvisor(earlyAssessment As StudentEarlyAssessment, updatedBy As String,
                                                  connection As SqlConnection, transaction As SqlTransaction)
         Dim result = Nothing
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", earlyAssessment.StudentID)
            command.Parameters.AddWithValue("@enrolmentYear", earlyAssessment.EnrolmentYear)
            command.Parameters.AddWithNull("@learningAdvisorID", earlyAssessment.LearningAdvisorID)
            command.Parameters.AddWithNull("@updatedBy", updatedBy)

            'Tread carefully with the allocation date, as it's used to trigger mailouts of welcome letters
            'Only update its timestamp if the Learning Advisor is changing from 'N-A' to something else

            ' Also note the workaround for not being able to directly return the results of an output clause
            ' when there are triggers enabled
            command.CommandType = CommandType.Text
            command.CommandText = $"declare @t table (OldLearningAdvisorID char(8));

                                     update
                                       dbo.STUDENT_ENROLMENT
                                     set
                                       PASTORAL_CARE_ID = @learningAdvisorID,
                                       PASTORAL_ALLOC_DATE = iif((PASTORAL_CARE_ID = '{NALADID}') and (@learningAdvisorID <> '{NALADID}'),
                                                                 getdate(),
                                                                 PASTORAL_ALLOC_DATE),
                                       PASTORAL_ALLOC_BY = @updatedBy
                                     output Deleted.PASTORAL_CARE_ID as OldLearningAdvisorID
                                       into @t
                                     where
                                       (STUDENT_ID = @studentID)
                                       and (ENROLMENT_YEAR = @enrolmentYear)
                                       and isnull(@learningAdvisorID, '') <> isnull(PASTORAL_CARE_ID, '');
                                     
                                     select rtrim(isnull(OldLearningAdvisorID, '')) from @t;"

            ' Result will be null if there was no update
            result = command.ExecuteScalar()
         End Using

         If (result IsNot Nothing) Then
            Dim oldLearningAdvisorID = DirectCast(result, String)
            If (Not earlyAssessment.LearningAdvisorID.Equals(oldLearningAdvisorID)) Then
               SaveAuditRecord(earlyAssessment, "LAU", $"Updated from '{oldLearningAdvisorID}' to '{earlyAssessment.LearningAdvisorID}'", updatedBy, connection, transaction)
            End If
         End If
      End Sub


      Private Sub SaveStudentSSGFacilitator(earlyAssessment As StudentEarlyAssessment, updatedBy As String,
                                                 connection As SqlConnection, transaction As SqlTransaction)
         Dim result = Nothing
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", earlyAssessment.StudentID)
            command.Parameters.AddWithValue("@enrolmentYear", earlyAssessment.EnrolmentYear)
            command.Parameters.AddWithNull("@ssgFacilitatorID", earlyAssessment.SSGFacilitatorID)

            command.CommandType = CommandType.Text
            command.CommandText = "declare @t table (OldSSGFacilitatorID char(8));

                                  update
                                    dbo.STUDENT_ENROLMENT
                                  set
                                    SSG_FACILITATOR_ID = @ssgFacilitatorID
                                  output Deleted.SSG_FACILITATOR_ID as OldSSGFacilitatorID
                                    into @t
                                  where
                                    (STUDENT_ID = @studentID)
                                    and (ENROLMENT_YEAR = @enrolmentYear)
                                    and isnull(@ssgFacilitatorID, '') <> isnull(SSG_FACILITATOR_ID, '');

                                  select rtrim(isnull(OldSSGFacilitatorID, '')) from @t;"

            ' Result will be null if there was no update
            result = command.ExecuteScalar()
         End Using

         If (result IsNot Nothing) Then
            Dim oldSSGFacilitatorID = DirectCast(result, String)
            If (Not earlyAssessment.SSGFacilitatorID.Equals(oldSSGFacilitatorID)) Then
               SaveAuditRecord(earlyAssessment, "SSGFU", $"Updated from '{oldSSGFacilitatorID}' to '{earlyAssessment.SSGFacilitatorID}'", updatedBy, connection, transaction)
            End If
         End If
      End Sub


      Private Sub SaveStudentLearningPlan(earlyAssessment As StudentEarlyAssessment, updatedBy As String,
                                                 connection As SqlConnection, transaction As SqlTransaction)
         Dim result = Nothing
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", earlyAssessment.StudentID)
            command.Parameters.AddWithValue("@enrolmentYear", earlyAssessment.EnrolmentYear)
            command.Parameters.AddWithNull("@learningPlan", earlyAssessment.LearningPlan)

            command.CommandType = CommandType.Text
            command.CommandText = "declare @t table (OldLearningPlan char(8));

                                  update
                                    dbo.STUDENT_ENROLMENT
                                  set
                                    LEARNING_PROGRAM = @learningPlan
                                  output Deleted.LEARNING_PROGRAM as OldLearningPlan
                                    into @t
                                  where
                                    (STUDENT_ID = @studentID)
                                    and (ENROLMENT_YEAR = @enrolmentYear)
                                    and isnull(@learningPlan, '') <> isnull(LEARNING_PROGRAM, '');

                                  select rtrim(isnull(OldLearningPlan, '')) from @t;"

            ' Result will be null if there was no update
            result = command.ExecuteScalar()
         End Using

         If (result IsNot Nothing) Then
            Dim oldLearningPlan = DirectCast(result, String)
            If (Not earlyAssessment.LearningPlan.Equals(oldLearningPlan)) Then
               SaveCommentRecord(earlyAssessment.StudentID, CoordinatorCommentType, $"Personal Learning Plan changed to [{earlyAssessment.LearningPlan}]", updatedBy, connection, transaction)
               SaveAuditRecord(earlyAssessment, "LPU", $"Updated from '{oldLearningPlan}' to '{earlyAssessment.LearningPlan}'", updatedBy, connection, transaction)
            End If
         End If
      End Sub


      Private Sub SaveCommentRecord(studentID As Decimal, commentType As String, comment As String, updatedBy As String,
                                    connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", studentID)
            command.Parameters.AddWithNull("@commentType", commentType)
            command.Parameters.AddWithNull("@comment", comment)
            command.Parameters.AddWithNull("@updatedBy", updatedBy)

            command.CommandType = CommandType.Text
            command.CommandText = "insert into dbo.STUDENT_COMMENT
                                    (
                                       COMMENT_ID,
                                       STUDENT_ID,
                                       COMMENT,
                                       LAST_ALTERED_BY,
                                       LAST_ALTERED_DATE,
                                       ACTIVE_STATUS,
                                       COMMENT_TYPE
                                    )
                                    values
                                    (
                                       (
                                          select (max(sc.COMMENT_ID) + 1) from dbo.STUDENT_COMMENT as sc
                                       ),
                                       @studentID,
                                       @comment,
                                       @updatedBy,
                                       getdate(),
                                       'A',
                                       @commentType
                                    );"

            command.ExecuteNonQuery()
         End Using
      End Sub


      Private Sub SaveAuditRecord(earlyAssessment As StudentEarlyAssessment, actionCode As String, actionDetails As String,
                                                  updatedBy As String, connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@studentID", earlyAssessment.StudentID)
            command.Parameters.AddWithValue("@enrolmentYear", earlyAssessment.EnrolmentYear)
            command.Parameters.AddWithNull("@actionCode", actionCode)
            command.Parameters.AddWithNull("@actionDetails", actionDetails)
            command.Parameters.AddWithNull("@updatedBy", updatedBy)

            command.CommandType = CommandType.Text
            command.CommandText = "insert into dbo.EARLY_ASSESSMENT_AUDIT
                                    (
                                       StudentID,
                                       EnrolmentYear,
                                       ActionCode,
                                       ActionDetails,
                                       UpdatedBy
                                    )
                                    values
                                    (
                                       @studentID,
                                       @enrolmentYear,
                                       @actionCode,
                                       @actionDetails,
                                       @updatedBy
                                    );"

            command.ExecuteNonQuery()
         End Using
      End Sub



      'Page class tail @1-DD082417
   End Class


End Namespace
'End Page class tail

