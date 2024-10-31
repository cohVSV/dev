Option Strict On
Option Explicit On


'Using Statements @1-82FB19C3
Imports System.Data
Imports System.Data.SqlClient
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Data
'End Using Statements


Namespace DECV_PROD2007.FunnelBrowseApplications 'Namespace @1-38F110FB

   'Forms Definition @1-2E57F6EB
   Public Class [FunnelBrowseApplicationsPage]
      Inherits CCPage
      'End Forms Definition

      'Forms Objects @1-A3805795
      Protected FunnelBrowseApplicationsContentMeta As String
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

         'OnInit Event Body @1-5C6BC548
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         FunnelBrowseApplicationsContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
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

      Friend Shared ReadOnly CurrentEnrolmentYear As Decimal = GetEnrolmentYearForDate(Today)
      Const UpcomingEnrolmentYearRolloverMonth = 10

      Const FirstFunnelEnrolmentYear = 2021D
      Const MaximumSearchItemsReturned = 25
      Const ResultsPerPage = 10  'TODO: Bump this up to a sensible value once there's a large number of Funnel leads coming through

      Const FunnelLeadBaseUrl = "https://vsv-au-vic-691.app.digistorm.com/admin/crm/leads/"
      Const AccountEnumsOwner = "Account"
      Const LeadEnumsOwner = "Lead"
      ReadOnly ApplicationSubmittedStageID As Guid = New Guid("2d1c4115-6f88-49c4-8bf6-a027eea7f92e")
      ReadOnly ApplicationCompletedStageID As Guid = New Guid("e7bdd4c7-6ab3-4232-83ab-eff677c0d706")
      ReadOnly ApplicationAcceptedStageID As Guid = New Guid("f42c37c6-b151-4c76-8765-2b28def1901c")
      Const SchoolEnrolmentTypeID = "ENUM_EB15DD39_BB35_4356_B137_5EF65D758436"
      Const EnrolmentFormEnumName = "student_enrolment_type"
      Const EnrolmentCategoryEnumName = "enrolment_category"
      Const YearLevelsEnumName = "year_levels"
      Const SharedEnrolmentTypeID = "ENUM_851C4EBD_2567_402B_9D59_B061F852E97E"
      Const FullEnrolmentTypeID = "ENUM_FCC06445_A79D_4027_90D7_4110564D0777"

      Const AppliedStudentStatusValue = "Applied"
      Const AcceptedStudentStatusValue = "Accepted"
      Const RejectedStudentStatusValue = "Rejected"

      Const ProcessApplicationPage = "FunnelProcessApplication.aspx"
      Const ProcessApplicationPageApplicationIDParameterName = "leadUUID"

      Const EnrolmentYearFilterKey = "enrolmentYear"
      Const PipelineStageFilterKey = "pipelineStageID"
      Const EnrolmentFormFilterKey = "enrolmentFormID"
      Const EnrolmentCategoryFilterKey = "enrolmentCategoryID"
      Const IsSharedEnrolmentFilterKey = "isSharedEnrolmentID"
      Const YearLevelFilterKey = "yearLevelID"
      Const HomeSchoolFilterKey = "homeSchoolID"
      Const HomeSchoolDisplayNameFilterKey = "homeSchoolDisplayName"
      Const NameStartsWithFilterKey = "nameStartsWith"
      Const StatusFilterKey = "status"

      ReadOnly InitialFilterValues As IReadOnlyDictionary(Of String, String) = New Dictionary(Of String, String) From {{EnrolmentYearFilterKey, CurrentEnrolmentYear.ToString()},
                                                                                                                     {PipelineStageFilterKey, ""},
                                                                                                                     {EnrolmentFormFilterKey, ""},
                                                                                                                     {EnrolmentCategoryFilterKey, ""},
                                                                                                                     {IsSharedEnrolmentFilterKey, ""},
                                                                                                                     {YearLevelFilterKey, ""},
                                                                                                                     {HomeSchoolFilterKey, ""},
                                                                                                                     {HomeSchoolDisplayNameFilterKey, ""},
                                                                                                                     {NameStartsWithFilterKey, ""},
                                                                                                                     {StatusFilterKey, AppliedStudentStatusValue}}

      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin page properties
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private ReadOnly Property SignedInUserID As String
         Get
            Return DBUtility.UserId.ToString().Trim().ToUpper()
         End Get
      End Property


      Property SavedFilterSelections As Dictionary(Of String, String)
         Get
            Return DirectCast(ViewState("FilterSelections"), Dictionary(Of String, String))
         End Get

         Set(value As Dictionary(Of String, String))
            ViewState("FilterSelections") = value
         End Set
      End Property


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin types
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Public Class School
         Public Property SchoolID As Decimal
         Public Property SchoolName As String
      End Class


      Private Class ApplicationComment
         Friend FunnelLeadUUID As Guid?
         Friend ApplicantName As String
         Friend Comment As String
         Friend CommentLastUpdatedBy As String
         Friend CommentLastUpdatedByDisplayName As String
         Friend CommentLastUpdatedDate As Date?
      End Class


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin common methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Shared Function GetEnrolmentYearForDate(theDate As Date) As Decimal
         Return If(theDate.Month < UpcomingEnrolmentYearRolloverMonth, theDate.Year, theDate.Year + 1)
      End Function


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin page methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Sub PageLoad()
         ' CCPage.OnInit will be invoked prior to this, and will authorise the user for enrolments permissions: groups 4, 6, and 9.

         If Not Page.IsPostBack Then
            InitialiseFormControls()
         Else
            CheckForFilterChanges()
         End If

         RefreshFunnelApplicationsListSQL()
      End Sub


      Private Sub InitialiseFormControls()
         InitialiseEnrolmentYearControl()
         InitialisePipelineStageControl()
         InitialiseControlDataSource(sqldsEnrolmentForm, LeadEnumsOwner, EnrolmentFormEnumName)
         InitialiseControlDataSource(sqldsEnrolmentCategory, LeadEnumsOwner, EnrolmentCategoryEnumName)
         InitialiseSharedEnrolmentControl()
         InitialiseControlDataSource(sqldsYearLevel, AccountEnumsOwner, YearLevelsEnumName)
         InitialiseImportStatusControl()

         dpFunnelApplications.PageSize = ResultsPerPage

         ResetFilter()
         ResetPageNumber()
      End Sub


      Private Sub InitialiseEnrolmentYearControl()
         For enrolmentYear As Decimal = FirstFunnelEnrolmentYear To CurrentEnrolmentYear
            ddlEnrolmentYear.Items.Add(enrolmentYear.ToString())
         Next
      End Sub


      Private Sub InitialisePipelineStageControl()
         ddlPipelineStage.Items.Add(New ListItem("Submitted", ApplicationSubmittedStageID.ToString()))
         ddlPipelineStage.Items.Add(New ListItem("Completed", ApplicationCompletedStageID.ToString()))
         ddlPipelineStage.Items.Add(New ListItem("Accepted", ApplicationAcceptedStageID.ToString()))
      End Sub


      Private Sub InitialiseControlDataSource(dataSource As SqlDataSource, enumOwner As String, enumName As String)
         dataSource.SelectParameters.Add("enumOwner", enumOwner)
         dataSource.SelectParameters.Add("enumName", enumName)
         dataSource.SelectCommand = GetFunnelEnumValuesSql()
      End Sub


      Private Sub InitialiseSharedEnrolmentControl()
         ddlIsSharedEnrolment.Items.Add(New ListItem("Shared", SharedEnrolmentTypeID))
         ddlIsSharedEnrolment.Items.Add(New ListItem("Full", FullEnrolmentTypeID))
      End Sub


      Private Sub InitialiseImportStatusControl()
         ddlStatus.Items.Add(New ListItem("Applied", AppliedStudentStatusValue))
         ddlStatus.Items.Add(New ListItem("Accepted", AcceptedStudentStatusValue))
         ddlStatus.Items.Add(New ListItem("Rejected", RejectedStudentStatusValue))

         ddlStatus.SelectedValue = AppliedStudentStatusValue
      End Sub


      Private Sub ResetFilter()
         ' Copy the initial filter values to the saved filter
         Dim savedFilter As New Dictionary(Of String, String)
         Dim initialFilter = InitialFilterValues

         For Each item In initialFilter
            savedFilter(item.Key) = item.Value
         Next

         SavedFilterSelections = savedFilter

         ' And apply those values to the controls
         SetFilterControls(savedFilter)
      End Sub


      Private Function GetFilterFromControls() As Dictionary(Of String, String)
         Dim values As New Dictionary(Of String, String)()
         values(EnrolmentYearFilterKey) = ddlEnrolmentYear.SelectedValue
         values(PipelineStageFilterKey) = ddlPipelineStage.SelectedValue
         values(EnrolmentFormFilterKey) = ddlEnrolmentForm.SelectedValue
         values(EnrolmentCategoryFilterKey) = ddlEnrolmentCategory.SelectedValue
         values(IsSharedEnrolmentFilterKey) = ddlIsSharedEnrolment.SelectedValue
         values(YearLevelFilterKey) = ddlYearLevel.SelectedValue
         values(NameStartsWithFilterKey) = txtApplicantNameStartsWith.Text
         values(HomeSchoolFilterKey) = hidHomeSchoolID.Value
         values(HomeSchoolDisplayNameFilterKey) = txtHomeSchool.Text
         values(StatusFilterKey) = ddlStatus.SelectedValue

         Return values
      End Function


      Private Sub SetFilterControls(filterValues As Dictionary(Of String, String))
         ddlEnrolmentYear.SelectedValue = filterValues(EnrolmentYearFilterKey)
         ddlPipelineStage.SelectedValue = filterValues(PipelineStageFilterKey)
         ddlEnrolmentForm.SelectedValue = filterValues(EnrolmentFormFilterKey)
         ddlEnrolmentCategory.SelectedValue = filterValues(EnrolmentCategoryFilterKey)
         ddlIsSharedEnrolment.SelectedValue = filterValues(IsSharedEnrolmentFilterKey)
         ddlYearLevel.SelectedValue = filterValues(YearLevelFilterKey)
         txtApplicantNameStartsWith.Text = filterValues(NameStartsWithFilterKey)
         hidHomeSchoolID.Value = filterValues(HomeSchoolFilterKey)
         txtHomeSchool.Text = filterValues(HomeSchoolDisplayNameFilterKey)
         ddlStatus.SelectedValue = filterValues(StatusFilterKey)
      End Sub


      Private Sub ResetPageNumber(Optional databind As Boolean = False)
         dpFunnelApplications.SetPageProperties(0, ResultsPerPage, databind)
      End Sub


      Private Sub CheckForFilterChanges()
         ' When the filter changes, we need to reset the ListView page to the first page
         ' Otherwise it's likely that the user will see a blank list of results if they've already navigated beyond the first page
         Dim savedFilter = SavedFilterSelections
         Dim newFilterSelections = GetFilterFromControls()
         ' Return false if there are differences in the key/value pairs between the two filter collections; assuming in this case they have the same set of keys
         If (savedFilter.Except(newFilterSelections).Any()) Then
            SavedFilterSelections = newFilterSelections
            ResetPageNumber()
         End If
      End Sub


      Private Sub RefreshFunnelApplicationsListSQL()
         sqldsFunnelApplications.SelectCommand = GetFunnelApplicationsListSQL()
      End Sub


      Protected Sub btnResetFilters_Click(sender As Object, e As EventArgs) Handles btnResetFilters.Click
         ResetFilter()
         ResetPageNumber(True)
      End Sub


      Friend Function GetApplicantName(firstName As String, surname As String) As String
         Return firstName & " " & surname
      End Function


      Friend Function GenerateFunnelApplicantOutput(leadUUID As Guid, firstName As String, surname As String) As String
         Return $"<a href='{GenerateFunnelApplicantUrl(leadUUID.ToString())}' target=_blank>{GetApplicantName(firstName, surname)}</a>"
      End Function


      Private Function GenerateFunnelApplicantUrl(leadUUID As String) As String
         Return $"{FunnelLeadBaseUrl}{leadUUID}"
      End Function


      Friend Function GenerateStatusOutput(funnelLeadUUID As String, status As String, actionedBy As String, actionedDate As String, acceptedStudentID As String, enrolmentYear As String) As String
         Dim processApplicationUrl = GenerateProcessApplicationLink(funnelLeadUUID)

         Select Case status
            Case AppliedStudentStatusValue
               Dim processApplicationLink = $"<a href='{processApplicationUrl}'>Process application</a>"
               Return "Applied - " & processApplicationLink
            Case AcceptedStudentStatusValue
               Dim processApplicationLink = $"<a href='{processApplicationUrl}'>Accepted</a>"
               If (acceptedStudentID.Length > 0) Then
                  Dim studentSummaryUrl = Common.GenerateStudentSummaryPageLink(acceptedStudentID, enrolmentYear)
                  Dim studentSummaryLink = $"<a href='{studentSummaryUrl}' target='_blank'>{acceptedStudentID}</a>"
                  Return $"{processApplicationLink} {actionedDate} - Student ID {studentSummaryLink}"
               Else
                  Return $"{processApplicationLink} {actionedDate} - No Student ID recorded"
               End If
            Case RejectedStudentStatusValue
               Dim processApplicationLink = $"<a href='{processApplicationUrl}'>Rejected</a>"
               Return $"{processApplicationLink} {actionedDate}"
            Case Else
               Return ""
         End Select
      End Function


      Friend Function GenerateProcessApplicationLink(funnelLeadUUID As String) As String
         Return ProcessApplicationPage & "?" & ProcessApplicationPageApplicationIDParameterName & "=" & funnelLeadUUID
      End Function


      Friend Function GenerateApplicationCommentOutput(comment As String, commentLastUpdatedByDisplayName As String, commentLastUpdatedDateTime As String) As String
         If ((comment?.Length > 0) AndAlso (commentLastUpdatedDateTime.Length > 0)) Then
            Dim builder As New StringBuilder(1000)
            Dim encodedComment = """" & HttpUtility.HtmlEncode(comment) & """" & vbCrLf & vbCrLf & $"- Last updated " & commentLastUpdatedDateTime & " by " & commentLastUpdatedByDisplayName
            builder.Append($"<span style='padding-left: 10px;' class='ApplicationComment' title='{encodedComment}'>")
            builder.Append("""...""")
            builder.Append("</span>")

            Return builder.ToString()
         End If

         Return Nothing
      End Function


      Protected Sub btnApplicationComment_Command(sender As Object, e As CommandEventArgs) Handles lvFunnelApplications.ItemCommand
         If (e.CommandName.Equals("EditApplicationComment")) Then
            Dim eventArgs = DirectCast(e, ListViewCommandEventArgs)
            Dim link = DirectCast(eventArgs.CommandSource, LinkButton)
            Dim leadUUID = link.Attributes("data-LeadUUID")
            DisplayApplicationComment(leadUUID)
         End If
      End Sub


      Private Sub DisplayApplicationComment(leadUUID As String)
         Dim applicationComments = GetApplicationComment(New Guid(leadUUID))
         With applicationComments
            hidApplicationCommentLeadUUID.Value = .FunnelLeadUUID.ToString()
            litApplicationCommentApplicantName.Text = .ApplicantName
            txtApplicationComment.Text = .Comment
            If ((.Comment?.Length > 0) AndAlso (.CommentLastUpdatedDate IsNot Nothing)) Then
               litApplicationCommentLastUpdated.Text = $"Last updated {Common.GetDateTimeDisplay(.CommentLastUpdatedDate, True)} by { .CommentLastUpdatedByDisplayName}"
            Else
               litApplicationCommentLastUpdated.Text = ""
            End If
         End With

         ' Disable automatic refreshes of the applicants list while the user is editing or viewing the comment
         tmFunnelApplicationsRefresh.Enabled = False

         Dim script = $"showApplicationCommentDialog();"
         ScriptManager.RegisterStartupScript(upFunnelApplications, upFunnelApplications.GetType(), "EditApplicationComment", script, True)
      End Sub


      Protected Sub btnSaveComment_Click(sender As Object, e As EventArgs) Handles btnSaveComment.Click
         Dim applicationComment As New ApplicationComment()
         With applicationComment
            .FunnelLeadUUID = New Guid(hidApplicationCommentLeadUUID.Value)
            .Comment = txtApplicationComment.Text
            .CommentLastUpdatedBy = SignedInUserID
         End With

         SaveApplicationComment(applicationComment)

         lvFunnelApplications.DataBind()
         tmFunnelApplicationsRefresh.Enabled = True
      End Sub


      Protected Sub btnCancelComment_Click(sender As Object, e As EventArgs) Handles btnCancelComment.Click
         tmFunnelApplicationsRefresh.Enabled = True
         ' No other steps needed. The partial update of the update panel will cause the UI to reset to a point where the dialog is closed.
      End Sub

      Protected Sub tmFunnelApplicationsRefresh_Tick(sender As Object, e As EventArgs) Handles tmFunnelApplicationsRefresh.Tick
         lvFunnelApplications.DataBind()
      End Sub


      ' --------------------------------------------------------------------------------------------------------------------------------------
      ' Begin SDB access methods
      ' --------------------------------------------------------------------------------------------------------------------------------------


      Private Function GetFunnelApplicationsListSQL() As String
         Return $"select
                  vfl.FunnelLeadUUID,
                  vfl.FunnelTargetEnrolmentYear,
                  vfl.FunnelPipelineStageID,
                  vfl.FunnelPipelineStage,
                  vfl.FunnelEnrolmentFormID,
                  vfl.FunnelEnrolmentForm,
                  vfl.FunnelEnrolmentCategoryID,
                  vfl.FunnelEnrolmentCategory,
                  vfl.FunnelSDBEnrolmentCategoryCode,
                  vfl.FunnelSDBEnrolmentSubcategoryCode,
                  vfl.FunnelIsSharedEnrolmentID,
                  vfl.FunnelYearLevelID,
                  vfl.FunnelYearLevel,
                  vfl.FunnelSDBYearLevel,
                  vfl.FirstName,
                  vfl.Surname,
                  vfl.HomeSchoolID,
                  rtrim(dbo.ProperCase(sch.SCHOOL_NAME)) as HomeSchool,
                  vfl.FunnelCreatedDate,
                  vfl.FunnelUpdatedDate,
                  vfl.Comment,
                  vfl.CommentLastUpdatedBy,
                  dbo.ProperCase(concat(rtrim(cstf.FIRSTNAME), ' ', rtrim(cstf.SURNAME))) as CommentLastUpdatedByDisplayName,
                  vfl.CommentLastUpdatedDate,
                  vfl.Status,
                  vfl.ActionedBy,
                  vfl.ActionedDate,
                  vfl.ActionedPipelineStageID,
                  vfl.AcceptedStudentID
                from
                  dbo.vwFunnelLead as vfl
                  left join dbo.SCHOOL as sch
                        on (sch.SCHOOL_ID = vfl.HomeSchoolID)
                  left join dbo.STAFF as cstf
                        on (cstf.STAFF_ID = vfl.CommentLastUpdatedBy)
                where
                  (vfl.FunnelTargetEnrolmentYear = @enrolmentYear)
                  and
                  (
                     (@pipelineStageID is null)
                     or (vfl.FunnelPipelineStageID = @pipelineStageID)
                  )
                  and
                  (
                     (@enrolmentFormID is null)
                     or (vfl.FunnelEnrolmentFormID = @enrolmentFormID)
                  )
                  and
                  (
                     (@enrolmentCategoryID is null)
                     or (@enrolmentFormID = '{SchoolEnrolmentTypeID}')
                     or (vfl.FunnelEnrolmentCategoryID = @enrolmentCategoryID)
                  )
                  and
                  (
                     (@isSharedEnrolmentID is null)
                     or (@enrolmentFormID = '{SchoolEnrolmentTypeID}')
                     or (vfl.FunnelIsSharedEnrolmentID = @isSharedEnrolmentID)
                  )
                  and
                  (
                     (@yearLevelID is null)
                     or (vfl.FunnelYearLevelID = @yearLevelID)
                  )
                  and
                  (
                     (@nameStartsWith is null)
                     or (vfl.FirstName like @nameStartsWith + '%')
                     or (vfl.Surname like @nameStartsWith + '%')
                  )
                  and
                  (
                     (@homeSchoolID is null)
                     or (vfl.HomeSchoolID = @homeSchoolID)
                  )
                  and
                  (
                     (@status is null)
                     or (vfl.Status = @status)
                  )
                order by
                  vfl.FunnelUpdatedDate desc;"
      End Function


      Private Function GetFunnelEnumValuesSql() As String
         Return "select
                  fem.Value,
                  fem.Label
                from
                  dbo.FUNNEL_ENUM_MAPPING as fem
                where
                  (fem.Owner = @enumOwner)
                  and (fem.Name = @enumName)
                order by fem.SDBDisplayOrder;"
      End Function


      <System.Web.Services.WebMethod()>
      Public Shared Function GetMatchingSchools(schoolName As String) As List(Of School)
         If (schoolName?.Length < 3) Then
            Return Nothing
         End If

         Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()

               command.Parameters.AddWithValue("@schoolName", schoolName)
               command.CommandType = CommandType.Text
               command.CommandText = $"select top {MaximumSearchItemsReturned}
                                       sch.SCHOOL_ID as SchoolID,
                                       dbo.ProperCase(rtrim(sch.SCHOOL_NAME)) as SchoolName
                                     from
                                       dbo.SCHOOL as sch
                                     where
                                       (sch.STATUS = 1)
                                       and (sch.SCHOOL_ID < 90000.00)
                                       and sch.SCHOOL_ID not in (16261.00, 9985.00, 19950.00, 19950.10) -- VSV, Unknown Census Default, Home schooled x 2
                                       and (sch.SCHOOL_NAME like '%' + @schoolName + '%'); -- Not using a prefix-only search with supporting index, for now"

               Dim schoolList As New List(Of School)()
               Using reader = command.ExecuteReader()
                  While (reader.Read())
                     Dim school = New School() With
                  {.SchoolID = reader.Value(Of Decimal)("SchoolID"),
                  .SchoolName = reader.Value(Of String)("SchoolName")
                  }
                     schoolList.Add(school)
                  End While

                  Return schoolList
               End Using
            End Using
         End Using
      End Function


      Private Function GetApplicationComment(leadUUID As Guid) As ApplicationComment
         Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()

               command.Parameters.AddWithValue("@leadUUID", leadUUID.ToString())
               command.CommandType = CommandType.Text
               command.CommandText = "select
                                       fl.FunnelLeadUUID,
                                       concat(fl.FirstName, ' ', fl.Surname) as ApplicantName,
                                       fl.Comment,
                                       fl.CommentLastUpdatedBy,
                                       dbo.ProperCase(concat(rtrim(stf.FIRSTNAME), ' ', rtrim(stf.SURNAME))) as CommentLastUpdatedByDisplayName,
                                       fl.CommentLastUpdatedDate
                                     from
                                       dbo.FUNNEL_LEAD as fl
                                       left join dbo.STAFF as stf
                                          on (stf.STAFF_ID = fl.CommentLastUpdatedBy)
                                    where fl.FunnelLeadUUID = @leadUUID;"

               Using reader = command.ExecuteReader()
                  If (reader.Read()) Then
                     Dim applicationComment As New ApplicationComment()
                     With applicationComment
                        .FunnelLeadUUID = reader.Value(Of Guid?)("FunnelLeadUUID")
                        .ApplicantName = reader.Value(Of String)("ApplicantName")
                        .Comment = reader.Value(Of String)("Comment")
                        .CommentLastUpdatedBy = reader.Value(Of String)("CommentLastUpdatedBy")
                        .CommentLastUpdatedByDisplayName = reader.Value(Of String)("CommentLastUpdatedByDisplayName")
                        .CommentLastUpdatedDate = reader.Value(Of Date?)("CommentLastUpdatedDate")
                     End With

                     Return applicationComment
                  End If
               End Using
            End Using
         End Using

         Return Nothing
      End Function


      Private Sub SaveApplicationComment(applicantComment As ApplicationComment)
         Using connection = New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()

               command.Parameters.AddWithValue("@leadUUID", applicantComment.FunnelLeadUUID)
               command.Parameters.AddWithNull("@comment", applicantComment.Comment)
               command.Parameters.AddWithNull("@updatedBy", applicantComment.CommentLastUpdatedBy)
               command.CommandType = CommandType.Text
               command.CommandText = "update
                                       fl
                                     set
                                       fl.Comment = @comment,
                                       fl.CommentLastUpdatedBy = @updatedBy,
                                       fl.CommentLastUpdatedDate = getdate()
                                     from
                                       dbo.FUNNEL_LEAD as fl
                                     where
                                       (fl.FunnelLeadUUID = @leadUUID)
                                       and (isnull(fl.Comment, '') <> isnull(@comment, ''));"

               command.ExecuteNonQuery()
            End Using
         End Using
      End Sub

      'Page class tail @1-DD082417
   End Class
End Namespace
'End Page class tail