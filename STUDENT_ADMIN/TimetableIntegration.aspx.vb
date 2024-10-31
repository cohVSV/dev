Option Strict On
Option Explicit On

'Using Statements @1-82FB19C3
Imports System.Data
Imports System.Data.SqlClient
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Data
'End Using Statements


Namespace DECV_PROD2007.TimetableIntegration 'Namespace @1-A4D216CB

   'Forms Definition @1-421ABA17
   Public Class [TimetableIntegrationPage]
      Inherits CCPage
      'End Forms Definition

      'Forms Objects @1-8F944A91
      Protected TimetableIntegrationContentMeta As String
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

         If (Not IsHigherAuthorisedUser) Then
            RedirectToUrl(Settings.ServerURL)
         End If

         If (Not Page.IsPostBack) Then
            InitialiseControls()
         End If

         RefreshDataQueries()

      End Sub 'Page_Load Event tail @1-E31F8E2A

      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

      End Sub 'Page_Unload Event tail @1-E31F8E2A


      'OnInit Event @1-7CD4ED69
#Region " Web Form Designer Generated Code "
      Protected Overrides Sub OnInit(ByVal e As EventArgs)
         'End OnInit Event

         'OnInit Event Body @1-21A2DD9A
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         TimetableIntegrationContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
         If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName)
         End If
         InitializeComponent()
         MyBase.OnInit(e)
         If Not (DBUtility.AuthorizeUser(New String() {"3", "6", "7", "9"})) Then
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

      Private Const MaximumUploadFileSizeBytes = 2000000
      Private Const StaleTimetableDataThresholdDays = 7
      Public Const MaximumUpdatePreviewRows = 200

      ' This flag applies to both the data check and the update queries
      ' When true, changes can only be made for currently enrolled students where the subject enrolment is also active
      Private Const ProcessCurrentEnrolmentsOnly = True

      ' This flag only applies to the data check; unchanged subjects are never updated
      ' It makes sense to ignore them when displaying data quality issues, as they have no bearing on the outcome
      Private Const ProcessChangedSubjectsOnly = True


      Private ReadOnly Property SessionID As String
         Get
            Return Session.SessionID
         End Get
      End Property


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



      ' ---------------------------------------------------------------------------------------
      ' Begin page methods
      ' ---------------------------------------------------------------------------------------

      Private Sub InitialiseControls()
         InitialiseEnrolmentYear()
         InitialiseSemester()
         InitialiseYearLevels()
      End Sub


      Private Sub InitialiseEnrolmentYear()
         ddlEnrolmentYear.Items.Add(Date.Today.Year.ToString())
         If (Date.Today.Month >= 10) Then
            ddlEnrolmentYear.Items.Add((Date.Today.Year + 1).ToString())
         End If
      End Sub


      Public Sub InitialiseSemester()
         rblSemester.SelectedValue = If(Month(Date.Today) < 6, "1", "2")
      End Sub


      Public Sub InitialiseYearLevels()
         Dim listItem As New ListItem("F", "0")
         listItem.Selected = True
         cblYearLevels.Items.Add(listItem)

         For yearLevel As Integer = 1 To 12
            listItem = New ListItem(yearLevel.ToString(), yearLevel.ToString())
            listItem.Selected = True
            cblYearLevels.Items.Add(listItem)
         Next
      End Sub


      Private Sub RefreshDataQueries()
         RefreshDataCheckQuery()
         RefreshPreviewUpdateQuery()
      End Sub


      Private Sub btnUploadExportNext_Click(sender As Object, e As EventArgs) Handles btnUploadExportNext.Click
         Try
            StageTimetableData()
            InitialiseDataCheckView()
         Catch ex As Exception
            btnUploadExportNext.Text = "Check Export File"
            ShowDivMessage(divUploadExportError, "An error has occurred:" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
         End Try
      End Sub


      Private Sub StageTimetableData()
         If (fuTTExportFile.HasFile) Then
            Dim uploadedFile = fuTTExportFile.PostedFile
            If (uploadedFile.ContentLength > MaximumUploadFileSizeBytes) Then
               Throw New ArgumentOutOfRangeException($"The Timetable export file size of {uploadedFile.ContentLength} bytes is larger than the safeguard maximum of {MaximumUploadFileSizeBytes} bytes")
            End If

            Dim fileBytes(uploadedFile.ContentLength - 1) As Byte
            uploadedFile.InputStream.Read(fileBytes, 0, uploadedFile.ContentLength)

            Dim fileText = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length)
            Dim records = ParseRecords(fileText)
            Dim table = GenerateDataTable(records, SessionID, SignedInUserID)
            StageTimetableData(table, SessionID, StaleTimetableDataThresholdDays)

            ' The file upload including metadata won't be preserved after postback processing, so capture the export filename here
            ltExportFileSummary.Text = fuTTExportFile.FileName
         End If
      End Sub


      Private Sub InitialiseDataCheckView()
         'Removing And re-adding the parameter forces the requery, in the case where the export file has been changed
         ReplaceSQLParameter(sqldsCheckData.SelectParameters, New WebControls.Parameter("sessionID", DbType.String, Session.SessionID))
         ReplaceSQLParameter(sqldsCheckData.SelectParameters, New WebControls.Parameter("currentEnrolmentsOnly", DbType.Boolean, ProcessCurrentEnrolmentsOnly.ToString()))
         ReplaceSQLParameter(sqldsCheckData.SelectParameters, New WebControls.Parameter("changedSubjectsOnly", DbType.Boolean, ProcessChangedSubjectsOnly.ToString()))

         dpCheckData.SetPageProperties(0, dpCheckData.MaximumRows, True)

         mvTimetableImport.SetActiveView(viewCheckData)
      End Sub


      Protected Sub lvCheckData_DataBound(sender As Object, e As EventArgs) Handles lvCheckData.DataBound
         ltTotalIssuesIdentified.Text = dpCheckData.TotalRowCount.ToString()
      End Sub


      Private Sub RefreshDataCheckQuery()
         Dim yearLevels = GetSelectedYearLevels()
         sqldsCheckData.SelectCommand = GenerateDataCheckSQL(yearLevels)
      End Sub


      Private Function GetSelectedYearLevels() As String
         Dim yearLevelsList = GetSelectedCheckBoxValues(cblYearLevels)
         For Each yearLevel In yearLevelsList
            ' The year levels will be jammed in as a raw comma delimited string, so validate them and protect against SQL injection
            Integer.Parse(yearLevel)
         Next

         ' Add a dummy value to ensure a minimum length of 1
         yearLevelsList.Add("-1")
         Return String.Join(", ", yearLevelsList)
      End Function


      Protected Sub btnCheckDataPreview_Click(sender As Object, e As EventArgs) Handles btnCheckDataPreview.Click
         InitialisePreviewUpdateView()
      End Sub


      Private Sub InitialisePreviewUpdateView()
         'Removing And re-adding the parameter forces the requery, in the case where the export file has been changed
         ReplaceSQLParameter(sqldsPreviewUpdate.SelectParameters, New WebControls.Parameter("sessionID", DbType.String, Session.SessionID))
         ReplaceSQLParameter(sqldsPreviewUpdate.SelectParameters, New WebControls.Parameter("currentEnrolmentsOnly", DbType.Boolean, ProcessCurrentEnrolmentsOnly.ToString()))

         dpPreviewUpdate.SetPageProperties(0, dpPreviewUpdate.MaximumRows, True)

         Dim enrolmentYear = Integer.Parse(ddlEnrolmentYear.SelectedValue)
         Dim semester = rblSemester.SelectedValue
         Dim yearLevels = GetSelectedYearLevels()

         Dim updatesPending = GetTotalUpdatesPending(SessionID, enrolmentYear, semester, yearLevels, ProcessCurrentEnrolmentsOnly)
         ltTotalUpdatesPending.Text = updatesPending.ToString()
         ltTotalUpdatesPendingSummary.Text = updatesPending.ToString()

         btnPreviewUpdate.Visible = (updatesPending > 0)

         mvTimetableImport.SetActiveView(viewPreviewUpdate)
      End Sub


      Private Sub RefreshPreviewUpdateQuery()
         Dim yearLevels = GetSelectedYearLevels()
         sqldsPreviewUpdate.SelectCommand = GeneratePreviewUpdateSQL(yearLevels, MaximumUpdatePreviewRows)
      End Sub


      Protected Sub btnPreviewUpdateBack_Click(sender As Object, e As EventArgs) Handles btnPreviewUpdateBack.Click
         InitialiseDataCheckView()
      End Sub


      Protected Sub btnPreviewUpdate_Click(sender As Object, e As EventArgs) Handles btnPreviewUpdate.Click
         InitialiseSummaryConfirmationView()
      End Sub


      Private Sub InitialiseSummaryConfirmationView()
         ltEnrolmentYearSummary.Text = ddlEnrolmentYear.SelectedValue
         ltSubjectSemestersSummary.Text = rblSemester.SelectedItem.Text

         Dim yearLevelsList = GetSelectedCheckBoxValues(cblYearLevels)
         If (yearLevelsList.Remove("0")) Then
            yearLevelsList.Insert(0, "F")
         End If
         ltYearLevelsSummary.Text = String.Join(", ", yearLevelsList)

         mvTimetableImport.SetActiveView(viewSummaryConfirmation)
      End Sub


      Protected Sub btnSummaryConfirmationBack_Click(sender As Object, e As EventArgs) Handles btnSummaryConfirmationBack.Click
         InitialisePreviewUpdateView()
      End Sub


      Protected Sub btnSummaryConfirmationApply_Click(sender As Object, e As EventArgs) Handles btnSummaryConfirmationApply.Click
         Try
            Dim enrolmentYear = Integer.Parse(ddlEnrolmentYear.SelectedValue)
            Dim semester = rblSemester.SelectedValue
            Dim yearLevels = GetSelectedYearLevels()

            ApplyTimetableDataUpdate(SessionID, enrolmentYear, semester, yearLevels, ProcessCurrentEnrolmentsOnly, SignedInUserID)

            InitialiseUpdateSummaryView()
         Catch ex As Exception
            btnSummaryConfirmationApply.Text = "Apply Updates"
            ShowDivMessage(divSummaryConfirmationError, "An error has occurred:" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
         End Try
      End Sub


      Private Sub InitialiseUpdateSummaryView()
         mvTimetableImport.SetActiveView(viewUpdateSummary)
      End Sub


      Protected Sub btnReturnToMainPage_Click(sender As Object, e As EventArgs) Handles btnReturnToMainPage.Click
         RedirectToUrl(Settings.ServerURL)
      End Sub


      Private Sub CancelUpdate_Click(sender As Object, e As EventArgs) Handles btnUploadExportCancel.Click, btnCheckDataCancel.Click,
                                                                               btnPreviewUpdateCancel.Click, btnSummaryConfirmationCancel.Click
         Try
            ClearSessionData(SessionID)
         Catch ex As Exception
            ' Best effort
         End Try

         RedirectToUrl(Settings.ServerURL)
      End Sub


      Private Sub ReplaceSQLParameter(parameters As WebControls.ParameterCollection, parameter As WebControls.Parameter)
         Dim existingParameter = parameters(parameter.Name)
         If (existingParameter IsNot Nothing) Then
            parameters.Remove(existingParameter)
         End If
         parameters.Add(parameter)
      End Sub


      Private Function GetSelectedCheckBoxValues(checkboxList As CheckBoxList) As List(Of String)
         Dim values = New List(Of String)()

         For Each listItem As ListItem In checkboxList.Items
            If (listItem.Selected) Then
               values.Add(listItem.Value)
            End If
         Next

         Return values
      End Function


      Sub ShowDivMessage(divElement As HtmlGenericControl, message As String)
         divElement.InnerText = message
         divElement.Style("display") = "block"
      End Sub


      Sub RedirectToUrl(url As String)
         Response.Redirect(url, False)
         Context.ApplicationInstance.CompleteRequest()
      End Sub


      ' ---------------------------------------------------------------------------------------
      ' Begin data types. View and model details are combined
      ' ---------------------------------------------------------------------------------------


      ' Use string types for the incoming data, as there could be anything and we want to be able to show type mismatches
      Class TimetableRecord
         Friend LineNumber As Integer
         Friend StudentID As String
         Friend SubjectID As String
         Friend StaffID As String
         Friend ClassCode As String
      End Class


      ' ---------------------------------------------------------------------------------------
      ' Begin data access
      ' ---------------------------------------------------------------------------------------


      Private Function ParseRecords(inputText As String) As List(Of TimetableRecord)
         Dim records = New List(Of TimetableRecord)
         Dim fileText = inputText.Replace("""", "")
         Dim fileLines = fileText.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

         Dim lineTokens As String()
         Dim line As String = ""
         Dim lineNumber = 1

         Try
            For Each line In fileLines
               lineTokens = line.Split({","c}, StringSplitOptions.None)

               records.Add(New TimetableRecord() With
                        {.LineNumber = lineNumber,
                         .StudentID = CleanInputString(lineTokens(0)),
                         .SubjectID = CleanInputString(lineTokens(1)),
                         .ClassCode = CleanInputString(lineTokens(2)),
                         .StaffID = CleanInputString(lineTokens(3))})

               lineNumber += 1
            Next

            Return records
         Catch ex As Exception
            Throw New Exception($"An error occurred while processing line {lineNumber}: {line}", ex)
         End Try

         Return Nothing
      End Function


      Private Function CleanInputString(value As String) As String
         Return If(String.IsNullOrEmpty(value.Trim()), Nothing, value.Trim().ToUpperInvariant())
      End Function


      Private Function GenerateDataTable(records As List(Of TimetableRecord), sessionID As String, username As String) As DataTable
         Dim table As New DataTable()
         table.Columns.Add("TimetableImportID", GetType(Integer))
         table.Columns.Add("SessionID", GetType(String))
         table.Columns.Add("LineNumber", GetType(Integer))
         table.Columns.Add("STUDENT_ID", GetType(String))
         table.Columns.Add("SUBJECT_ID", GetType(String))
         table.Columns.Add("CLASS_CODE", GetType(String))
         table.Columns.Add("STAFF_ID", GetType(String))
         table.Columns.Add("LAST_ALTERED_BY", GetType(String))

         For Each record In records
            Dim newRow = table.NewRow()
            newRow("SessionID") = sessionID
            newRow("LineNumber") = record.LineNumber
            newRow("STUDENT_ID") = record.StudentID
            newRow("SUBJECT_ID") = record.SubjectID
            newRow("CLASS_CODE") = record.ClassCode
            newRow("STAFF_ID") = record.StaffID
            newRow("LAST_ALTERED_BY") = username

            table.Rows.Add(newRow)
         Next

         Return table
      End Function


      Private Sub StageTimetableData(table As DataTable, sessionID As String, staleTimetableDataThreshold As Integer)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using transaction = connection.BeginTransaction("Stage Timetable Data")
               ClearStaleData(staleTimetableDataThreshold, connection, transaction)
               ClearSessionData(sessionID, connection, transaction)
               BulkLoadTimetableData(table, connection, transaction)

               transaction.Commit()
            End Using
         End Using
      End Sub


      Private Sub ClearStaleData(staleTimetableDataThreshold As Integer, connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@staleDataThresholdDays", staleTimetableDataThreshold)
            command.CommandType = CommandType.Text
            command.CommandText = "delete from
                                    dbo.TIMETABLE_IMPORT
                                       where
                                       LAST_ALTERED_DATE < dateadd(day, -@staleDataThresholdDays, getdate());"
            command.ExecuteNonQuery()
         End Using
      End Sub


      Private Sub ClearSessionData(sessionID As String, connection As SqlConnection, transaction As SqlTransaction)
         Using command = connection.CreateCommand()
            command.Transaction = transaction

            command.Parameters.AddWithValue("@sessionID", sessionID)
            command.CommandType = CommandType.Text
            command.CommandText = "delete from dbo.TIMETABLE_IMPORT where (SessionID = @sessionID);"
            command.ExecuteNonQuery()
         End Using
      End Sub


      Private Sub BulkLoadTimetableData(table As DataTable, connection As SqlConnection, transaction As SqlTransaction)
         Using bulkCopy As New SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction)
            bulkCopy.DestinationTableName = "dbo.TIMETABLE_IMPORT"
            bulkCopy.WriteToServer(table)
         End Using
      End Sub


      Private Function GenerateTimetableImportCTESQL() As String
         Return "with
                  TimetableImport as
                     (
                        /* The timetable data for the session ID, with added int-converted IDs for the student ID and subject ID
                           We still want to have the raw string values for those as well so that they can be displayed
                        */
                        select
                           try_cast(tti.STUDENT_ID as int) as StudentIDInt,
                           tti.STUDENT_ID,
                           try_cast(tti.SUBJECT_ID as int) as SubjectIDInt,
                           tti.SUBJECT_ID,
                           tti.CLASS_CODE,
                           tti.STAFF_ID
                         from
                           dbo.TIMETABLE_IMPORT as tti
                         where
                           (tti.SessionID = @sessionID)
                     ) "
      End Function


      Private Function GenerateDataCheckSQL(yearLevels As String) As String
         Return GenerateTimetableImportCTESQL() &
                $"select
                      --tti.LineNumber,
                      tti.STUDENT_ID,
                      se.ENROLMENT_STATUS,
                      concat(rtrim(st.FIRST_NAME), ' ', rtrim(st.SURNAME)) as StudentName,
                      case
                         when se.YEAR_LEVEL <> 0 then cast(se.YEAR_LEVEL as varchar(20))
                         when se.YEAR_LEVEL = 0 then 'F'
                      end as YearLevel,
                      tti.SUBJECT_ID,
                      rtrim(sbj.SUBJECT_TITLE) as SubjectTitle,
                      ss.SEMESTER,
                      ss.STAFF_ID as PreviousStaffID,
                      tti.STAFF_ID as NewStaffID,
                      ss.CLASS_CODE as PreviousClassCode,
                      tti.CLASS_CODE as NewClassCode,
                      case
                         when
                         (
                            (tti.STUDENT_ID is null)
                            or (st.STUDENT_ID is null)
                         ) then 'Missing or invalid Student ID'
                         when (se.STUDENT_ID is null) then 'No student enrolment record for this year'
                         when
                         (
                            (tti.SUBJECT_ID is null)
                            or (sbj.SUBJECT_ID is null)
                         ) then 'Missing or invalid Subject ID'
                         when
                         (
                            -- Ignore the staff errors for Launch Pad subjects, and the update process will do likewise
                            -- Staff allocations for those are handled separately by the student database
                            (tti.SubjectIDInt not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                            and
                            (
                               (tti.STAFF_ID is null)
                               or (newstf.STAFF_ID is null)
                               or (tti.STAFF_ID in ('N-A', 'NO_SST'))
                               or (newstf.STATUS <> 1)
                            )
                         ) then 'Missing, unknown, invalid, or inactive Teacher ID'
                         when
                         (
                            (tti.SubjectIDInt in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                            and (tti.STAFF_ID is not null)
                         ) then 'Launch Pad teacher and class allocation will be skipped'
                         when (tti.CLASS_CODE is null) then 'Missing class code'
                         when
                         (
                            (tti.SubjectIDInt not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                            and (ss.STUDENT_ID is null)
                         ) then 'No matching student subject enrolment in the student database'
                         else 'Other'
                      end as NoUpdateReason
                    from
                      TimetableImport as tti
                      left join dbo.STUDENT as st
                         on (st.STUDENT_ID = tti.StudentIDInt)
                      left join dbo.STUDENT_ENROLMENT as se
                         on (
                               (se.STUDENT_ID = tti.StudentIDInt)
                               and (se.ENROLMENT_YEAR = @enrolmentYear)
                            )
                      left join dbo.STUDENT_SUBJECT as ss
                         on (
                               (ss.STUDENT_ID = se.STUDENT_ID)
                               and (ss.SUBJECT_ID = tti.SubjectIDInt)
                               and (ss.ENROLMENT_YEAR = se.ENROLMENT_YEAR)
                            )
                      left join dbo.SUBJECT as sbj
                         on (sbj.SUBJECT_ID = tti.SubjectIDInt)
                      left join dbo.STAFF as newstf
                         on (newstf.STAFF_ID = tti.STAFF_ID)
                    where
                      /* There's a hierarchy of data quality possibilities that we need to work through.
                         The goal is to pick up the data quality issues at the same time as honoring the semester and year level filters once we're able to test for them.
                         We've omitted the semester and year levels in the left joins above so that our query will pick up instead of filter out these data quality issues.
                         The first possibility though is that the subject ID is missing or is unknown, in which case we can't determine the semester or subject year level.
         
                         Exception: missing or invalid subject ID
                      */
                      (tti.SUBJECT_ID is null)
                      or (sbj.SUBJECT_ID is null)
                      or
                      (
                         -- Assertion: The subject ID is valid.
                         (sbj.YEAR_LEVEL in ({yearLevels}))
                         and
                         (
                            -- Assertion: the subject year level is within the range that we're interested in.
                            (
                               -- Exception: Missing or invalid student ID
                               (tti.STUDENT_ID is null)
                               or (st.STUDENT_ID is null)
                            )
                            or -- Exception: No enrolment record for the year
                            (se.STUDENT_ID is null)
                            or
                            (
                               -- Assertion: The student exists and has an enrolment record for the year; apply other checks now that we know this is true
                               (
                                  -- Parameter check: from here onwards show only exceptions for current student enrolments?
                                  (@currentEnrolmentsOnly = 'false')
                                  or (se.ENROLMENT_STATUS = 'E')
                               )
                               and
                               (
                                  -- Assertion: The student is currently enrolled or, we want to pick up withdrawals as well
                                  (
                                     /* There's no matching student subject enrolment for the import record.
                                        This case needs to be handled separately to the remainder of cases because we don't yet want to enforce the semester filter.
                                        The Timetabler may accumulate entries between semesters and we don't want the semester 1 student enrolments in the export
                                        appearing as exceptions during semester 2. But, pick up the exception if the student isn't enrolled in the subject for any semester.

                                        Exception: The student has no enrolment in the subject in the year.
                                     */
                                     (tti.SubjectIDInt not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                                     and (ss.STUDENT_ID is null)
                                  )
                                  or
                                  (
                                     /* Assertion: The student subject exists for the enrolment year.
                                                            Check that semester matches our filter.
                                                            This needs to hold true for the remainder of the checks.
                                                         */
                                     (ss.SEMESTER in ('B', @semester))
                                     and
                                     (
                                        -- Parameter check: from here onwards show only exceptions for current subject enrolments?
                                        (@currentEnrolmentsOnly = 'false')
                                        or (ss.SUBJ_ENROL_STATUS in ('P', 'C', 'D'))
                                     )
                                     and
                                     (
                                        /* Parameter check: show exceptions only where the teacher or class code has changed?
                                                               Unlike the update query, we are interested in records where the import teacher or class code may be null,
                                                               so wrap them in an isnull to avoid misses due to comparisons against null
                                                            */
                                        (@changedSubjectsOnly = 'false')
                                        or (isnull(ss.STAFF_ID, '') <> isnull(tti.STAFF_ID, ''))
                                        or (isnull(ss.CLASS_CODE, '') <> isnull(tti.CLASS_CODE, ''))
                                     )
                                     and
                                     (
                                        /* Assertion: All filters have been applied and there is a match for the student subject.
                                                               If @currentEnrolmentsOnly is true, the student is currently enrolled at the school and in the subject.
                                                               If @changedSubjectsOnly is true, either the import teacher ID or the class code have changed,
                                                               compared to the values on the student database.

                                                               Exception: Missing class code
                                                            */
                                        (tti.CLASS_CODE is null)
                                        or
                                        (
                                           -- Exception: Non-LP subject with missing, unknown, invalid, or inactive teacher
                                           (tti.SubjectIDInt not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                                           and
                                           (
                                              (tti.STAFF_ID is null)
                                              or (newstf.STAFF_ID is null)
                                              or (tti.STAFF_ID in ('N-A', 'NO_SST'))
                                              or (newstf.STATUS <> 1)
                                           )
                                        )
                                        or
                                        (
                                           -- Exception: LP subject with teacher assignment, will be skipped
                                           (tti.SubjectIDInt in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                                           and (tti.STAFF_ID is not null)
                                        )
                                     )
                                  )
                               )
                            )
                         )
                      )
                    order by
                      SubjectTitle,
                      st.SURNAME,
                      st.FIRST_NAME;"
      End Function


      Private Function GetTotalUpdatesPending(sessionID As String, enrolmentYear As Integer, semester As String,
                                              yearLevels As String, currentEnrolmentsOnly As Boolean) As Integer
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               With command
                  .Parameters.AddWithValue("@sessionID", sessionID)
                  .Parameters.AddWithValue("@enrolmentYear", enrolmentYear)
                  .Parameters.AddWithValue("@semester", semester)
                  .Parameters.AddWithValue("@currentEnrolmentsOnly", currentEnrolmentsOnly)

                  .CommandType = CommandType.Text
                  .CommandText = GeneratePreviewUpdateRecordCountSQL(yearLevels)

                  Return DirectCast(.ExecuteScalar(), Integer)
               End With
            End Using
         End Using
      End Function


      Private Function GeneratePreviewUpdateRecordCountSQL(yearLevels As String) As String
         Return GenerateTimetableImportCTESQL() & " select count(*) " & GenerateUpdateSQLBody(yearLevels) & ";"
      End Function


      Private Function GeneratePreviewUpdateSQL(yearLevels As String, Optional recordLimit As Integer? = Nothing) As String
         Return GenerateTimetableImportCTESQL() &
                $" select {If(recordLimit.HasValue(), "top " & recordLimit.Value.ToString(), "")}
                     ss.STUDENT_ID,
                     concat(rtrim(st.FIRST_NAME), ' ', rtrim(st.SURNAME)) as StudentName,
                     iif(se.YEAR_LEVEL <> 0, cast(se.YEAR_LEVEL as varchar(20)), 'F') as YearLevel,
                     ss.SUBJECT_ID,
                     rtrim(sbj.SUBJECT_TITLE) as SubjectTitle,
                     ss.SEMESTER,
                     ss.STAFF_ID as PreviousStaffID,
                     tti.STAFF_ID as NewStaffID,
                     ss.CLASS_CODE as PreviousClassCode,
                     tti.CLASS_CODE as NewClassCode " &
                  GenerateUpdateSQLBody(yearLevels) &
                  " order by
                     SubjectTitle,
                     st.SURNAME,
                     st.FIRST_NAME;"
      End Function


      Private Function GenerateUpdateSQLBody(yearLevels As String) As String
         Return $"from
                   TimetableImport as tti
                   inner join dbo.STUDENT as st
                      on (st.STUDENT_ID = tti.StudentIDInt)
                   inner join dbo.STUDENT_ENROLMENT as se
                      on (se.STUDENT_ID = st.STUDENT_ID)
                   inner join dbo.STUDENT_SUBJECT as ss
                      on (
                            (ss.STUDENT_ID = se.STUDENT_ID)
                            and (ss.ENROLMENT_YEAR = se.ENROLMENT_YEAR)
                            and (ss.SUBJECT_ID = tti.SubjectIDInt)
                         )
                   inner join dbo.SUBJECT as sbj
                      on (sbj.SUBJECT_ID = ss.SUBJECT_ID)
                   inner join dbo.STAFF as newstf
                      on (newstf.STAFF_ID = tti.STAFF_ID)
                 where
                   (se.ENROLMENT_YEAR = @enrolmentYear)
                   and (ss.SEMESTER in ('B', @semester))
                   and (sbj.YEAR_LEVEL in ({yearLevels}))
                   and
                   (
                      (@currentEnrolmentsOnly = 'false')
                      or
                      (
                         (se.ENROLMENT_STATUS = 'E')
                         and (ss.SUBJ_ENROL_STATUS in ('P', 'C', 'D'))
                      )
                   )
                   and (ss.SUBJECT_ID not in (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)))
                   and (tti.STAFF_ID is not null)
                   and (tti.STAFF_ID not in ('N-A', 'NO_SST'))
                   and (newstf.STATUS = 1)
                   and (tti.CLASS_CODE is not null)
                   and
                   (
                      -- The teacher or the class code has changed
                      -- Also we are excluding import updates to null values, as per the checks above
                      (isnull(ss.STAFF_ID, '') <> tti.STAFF_ID)
                      or (isnull(ss.CLASS_CODE, '') <> tti.CLASS_CODE)
                   )"
      End Function


      Private Sub ApplyTimetableDataUpdate(sessionID As String, enrolmentYear As Integer, semester As String,
                                              yearLevels As String, currentEnrolmentsOnly As Boolean, username As String)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               With command
                  .Parameters.AddWithValue("@sessionID", sessionID)
                  .Parameters.AddWithValue("@enrolmentYear", enrolmentYear)
                  .Parameters.AddWithValue("@semester", semester)
                  .Parameters.AddWithValue("@currentEnrolmentsOnly", currentEnrolmentsOnly)
                  .Parameters.AddWithNull("@updatedBy", username)

                  .CommandType = CommandType.Text
                  .CommandText = GenerateUpdateSQL(yearLevels)

                  .ExecuteNonQuery()
               End With
            End Using

         End Using
      End Sub


      Private Function GenerateUpdateSQL(yearLevels As String) As String
         Return GenerateTimetableImportCTESQL() &
                $"update
                     ss
                   set
                     ss.STAFF_ID = tti.STAFF_ID,
                     ss.CLASS_CODE = tti.CLASS_CODE,
                     ss.LAST_ALTERED_BY = @updatedBy,
                     ss.LAST_ALTERED_DATE = getdate() " &
                  GenerateUpdateSQLBody(yearLevels) & ";"
      End Function


      Private Sub ClearSessionData(sessionID As String)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using transaction = connection.BeginTransaction("Clear Timetable Session Data")
               ClearSessionData(sessionID, connection, transaction)
               transaction.Commit()
            End Using
         End Using
      End Sub


      'Page class tail @1-DD082417

   End Class
End Namespace
'End Page class tail

