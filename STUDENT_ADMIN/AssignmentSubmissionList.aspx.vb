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
'End Using Statements

Imports System.Data.SqlClient
Imports System.Collections.ObjectModel
Imports System.Activities.Expressions

Namespace DECV_PROD2007.AssignmentSubmissionList 'Namespace @1-3B38056F

   'Forms Definition @1-2B81BB9F
   Public Class [AssignmentSubmissionListPage]
      Inherits CCPage
      'End Forms Definition

      'Forms Objects @1-A6561AE1
      Protected AssignmentSubmissionListContentMeta As String
      'End Forms Objects

      'Page_Load Event @1-A2D2CF1E
      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
         'End Page_Load Event


         'Page_Load Event BeforeIsPostBack @1-48927019
         Dim item As PageItem = PageItem.CreateFromHttpRequest()
         ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
         If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            item.link_MenuHref = "Menu.aspx"
            item.Link_SearchRequestHref = "MaintainSearchRequest.aspx"
            item.link_AssignmentsHref = "AssignmentSubmissionList.aspx"
            item.Link10Href = "Send_SMS_maintain.aspx"
            item.Link6Href = "Student_Future_Intentions.aspx"
            item.Link5Href = "Student_Comments_maintain.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf, "")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref.ToString() & item.Link_BacktosummaryHrefParameters.ToString("GET", "", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf, "")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref.ToString() & item.Link_BacktoPastoralListHrefParameters.ToString("None", "", ViewState)
            Link_BacktoPastoralList.DataBind()
            link_Menu.InnerText += item.link_Menu.GetFormattedValue().Replace(vbCrLf, "")
            link_Menu.HRef = item.link_MenuHref.ToString() & item.link_MenuHrefParameters.ToString("None", "", ViewState)
            link_Menu.DataBind()
            Link_SearchRequest.InnerText += item.Link_SearchRequest.GetFormattedValue().Replace(vbCrLf, "")
            Link_SearchRequest.HRef = item.Link_SearchRequestHref.ToString() & item.Link_SearchRequestHrefParameters.ToString("GET", "", ViewState)
            Link_SearchRequest.DataBind()
            link_Assignments.InnerText += item.link_Assignments.GetFormattedValue().Replace(vbCrLf, "")
            link_Assignments.HRef = item.link_AssignmentsHref.ToString() & item.link_AssignmentsHrefParameters.ToString("GET", "", ViewState)
            link_Assignments.DataBind()
            Link10.InnerText += item.Link10.GetFormattedValue().Replace(vbCrLf, "")
            Link10.HRef = item.Link10Href.ToString() & item.Link10HrefParameters.ToString("GET", "", ViewState)
            Link10.DataBind()
            Link6.InnerText += item.Link6.GetFormattedValue().Replace(vbCrLf, "")
            Link6.HRef = item.Link6Href.ToString() & item.Link6HrefParameters.ToString("GET", "", ViewState)
            Link6.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf, "")
            Link5.HRef = item.Link5Href.ToString() & item.Link5HrefParameters.ToString("GET", "", ViewState)
            Link5.DataBind()
         End If
         'End Page_Load Event BeforeIsPostBack

         'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @48-73254650
         ' -------------------------
         'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
         '23-July-2015|EA| convert to global setting incase we need to add a new group in future
         Dim strHigherGroups As String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups")
         Dim arrHigherGroups As String() = strHigherGroups.Split(","c)
         'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
         If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MenuStudentMaintain.Visible = True
         End If
         ' -------------------------
         'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

         If (Not IsPostBack) Then
            Dim studentDetails = LoadStudentDetails(StudentID, EnrolmentYear)
            Dim studentSubjects = LoadStudentSubjects(StudentID, EnrolmentYear)

            InitialiseStudentDetails(studentDetails)
            InitialiseStudentSubjects(studentSubjects)
            InitialiseLastLoginDisplay(studentSubjects)
            InitialiseActivityViewDefaults(studentDetails)
         End If

         RefreshActivityListQuery()

      End Sub 'Page_Load Event tail @1-E31F8E2A

      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

      End Sub 'Page_Unload Event tail @1-E31F8E2A

      'OnInit Event @1-7CD4ED69
#Region " Web Form Designer Generated Code "
      Protected Overrides Sub OnInit(ByVal e As EventArgs)
         'End OnInit Event

         'OnInit Event Body @1-D1F021BC
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         AssignmentSubmissionListContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
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
      ' |RW|16/8/2020
      ' Begin items developed in Visual Studio using standard ASP.NET Web Forms
      ' ---------------------------------------------------------------------------------------


      ' ---------------------------------------------------------------------------------------
      ' Begin page variables
      ' ---------------------------------------------------------------------------------------

      Private Const SiteLoginActivityID = 0
      Private Const SiteLoginSubjectID = 0
      Private Const EmailDomain = "vsv.vic.edu.au"

      ' TODO: Refine the labels to more accurate descriptions as needed
      Private ReadOnly ActivityTypeDisplayNames As New ReadOnlyDictionary(Of String, String)(New Dictionary(Of String, String)() From
                                                                                             {{"assign", "Assignment"},
                                                                                             {"attendance", "Attendance"},
                                                                                             {"book", "Learning Activity"},
                                                                                             {"chat", "Chat"},
                                                                                             {"choice", "Poll"},
                                                                                             {"data", "Data"},
                                                                                             {"facetoface", "Face to Face"},
                                                                                             {"feedback", "Feedback"},
                                                                                             {"folder", "Folder"},
                                                                                             {"forum", "Forum"},
                                                                                             {"geogebra", "Geogebra"},
                                                                                             {"glossary", "Glossary"},
                                                                                             {"hvp", "Interactive Content"},
                                                                                             {"label", "Label"},
                                                                                             {"lesson", "Lesson"},
                                                                                             {"lightboxgallery", "Lightbox Gallery"},
                                                                                             {"login", "Login"},
                                                                                             {"oublog", "Blog"},
                                                                                             {"page", "Page"},
                                                                                             {"questionnaire", "Questionnaire"},
                                                                                             {"quiz", "Quiz"},
                                                                                             {"resource", "Resource"},
                                                                                             {"scorm", "SCORM Package"},
                                                                                             {"subpage", "Subpage"},
                                                                                             {"url", "URL"},
                                                                                             {"wiki", "Wiki"},
                                                                                             {"workshop", "Workshop"}})

      ' These activity types can have LMS links displayed
      Private ReadOnly LinkableActivityTypes As New ReadOnlyCollection(Of String)({"assign", "book", "choice", "facetoface", "feedback", "folder", "forum",
                                                                                  "geogebra", "glossary", "hvp", "lesson", "lightboxgallery", "oublog", "page",
                                                                                  "questionnaire", "quiz", "resource", "scorm", "subpage", "url", "workshop"})

      ' These activity types are applicable for having return dates, others can be marked as 'N/A'
      Private ReadOnly ReturnableActivityTypes As New ReadOnlyCollection(Of String)({"assign", "quiz", "scorm", "hvp"})

      Private ReadOnly ExcludedActivityTypes As New ReadOnlyCollection(Of String)({"login"})



      ReadOnly Property StudentID As Decimal
         Get
            Return Decimal.Parse(Request.QueryString("STUDENT_ID"))
         End Get
      End Property


      ReadOnly Property EnrolmentYear As Integer
         Get
            Return Integer.Parse(Request.QueryString("ENROLMENT_YEAR"))
         End Get
      End Property


      Private ReadOnly Property SignedInUserID As String
         Get
            Return DBUtility.UserId.ToString().Trim().ToUpper()
         End Get
      End Property


      Private Property SubjectIDs As String
         Get
            Return If(ViewState("SubjectIDs")?.ToString(), "")
         End Get
         Set(value As String)
            ViewState("SubjectIDs") = value
         End Set
      End Property


      Private Property ActiveSubjectIDs As String
         Get
            Return If(ViewState("ActiveSubjectIDs")?.ToString(), "")
         End Get
         Set(value As String)
            ViewState("ActiveSubjectIDs") = value
         End Set
      End Property


      Private Property MySubjectIDs As String
         Get
            Return If(ViewState("MySubjectIDs")?.ToString(), "")
         End Get
         Set(value As String)
            ViewState("MySubjectIDs") = value
         End Set
      End Property


      Private Property MyActiveSubjectIDs As String
         Get
            Return If(ViewState("MyActiveSubjectIDs")?.ToString(), "")
         End Get
         Set(value As String)
            ViewState("MyActiveSubjectIDs") = value
         End Set
      End Property


      ' ---------------------------------------------------------------------------------------
      ' Begin data types. View and model details are combined
      ' ---------------------------------------------------------------------------------------

      Class StudentDetails
         Friend StudentName As String
         Friend LearningAdvisorID As String
         Friend LearningAdvisorName As String
      End Class


      Class StudentSubject
         Implements IComparable(Of StudentSubject)

         Friend SubjectID As Integer
         Friend SubjectTitle As String
         Friend SubjectTeacherID As String
         Friend SubjectEnrolmentStatus As String
         Friend SubjectWithdrawalDate As Date?
         Friend LastLoginDate As Date?


         Friend ReadOnly Property IsSubjectActive As Boolean
            Get
               Return (SubjectEnrolmentStatus.Equals("C"))
            End Get
         End Property


         Public Function CompareTo(other As StudentSubject) As Integer Implements IComparable(Of StudentSubject).CompareTo
            Return SubjectTitle.CompareTo(other.SubjectTitle)
         End Function
      End Class


      Class StudentActivityLastLogin
         Friend ActivityID As Integer
         Friend SubjectID As Integer
         Friend LastLoginDate As Date?
      End Class


      ' ---------------------------------------------------------------------------------------
      ' Begin page methods
      ' ---------------------------------------------------------------------------------------


      Private Sub InitialiseStudentDetails(studentDetails As StudentDetails)
         litPageTitle.Text = $"Student {studentDetails.StudentName} - VSV Online Activity"
         litStudentName.Text = studentDetails.StudentName
         litLearningAdvisorName.Text = studentDetails.LearningAdvisorName
      End Sub


      ' Initialise the collections of subject IDs for the selected student and enrolment year
      ' This will also include the subject's active status as well as information telling us whether the currently signed in user is the teacher
      Private Sub InitialiseStudentSubjects(studentSubjects As List(Of StudentSubject))
         Dim allSubjectIDsSB = New StringBuilder(100)
         Dim activeSubjectIDsSB = New StringBuilder(100)
         Dim mySubjectIDsSB = New StringBuilder(100)
         Dim myActiveSubjectIDsDB = New StringBuilder(100)
         Dim mySubjectNamesSB = New StringBuilder(100)

         For Each studentSubject In studentSubjects
            With (studentSubject)
               allSubjectIDsSB.Append(.SubjectID)
               allSubjectIDsSB.Append(","c)

               If (.IsSubjectActive) Then
                  activeSubjectIDsSB.Append(.SubjectID)
                  activeSubjectIDsSB.Append(","c)
               End If

               ' Add each of the subjects explicitly to the subject filter dropdown
               ddlSubjects.Items.Add(New ListItem(.SubjectTitle, .SubjectID.ToString()))

               If (.SubjectTeacherID.Equals(SignedInUserID)) Then
                  mySubjectIDsSB.Append(.SubjectID)
                  mySubjectIDsSB.Append(","c)
                  mySubjectNamesSB.Append(.SubjectTitle)
                  mySubjectNamesSB.Append(", ")

                  If (.IsSubjectActive) Then
                     myActiveSubjectIDsDB.Append(.SubjectID)
                     myActiveSubjectIDsDB.Append(","c)
                  End If
               End If

            End With
         Next

         ' Populate the ViewState subject ID variables, for later reference when applying filtering
         SubjectIDs = allSubjectIDsSB.ToString().TrimEnd({","c})
         ActiveSubjectIDs = activeSubjectIDsSB.ToString().TrimEnd({","c})
         MySubjectIDs = mySubjectIDsSB.ToString().TrimEnd({","c})
         MyActiveSubjectIDs = myActiveSubjectIDsDB.ToString().TrimEnd({","c})

         litMySubjectNames.Text = mySubjectNamesSB.ToString().TrimEnd({" "c, ","c})
      End Sub


      ' Side-effect of this method to the parameter: adds last login to StudentSubject objects, and sorts them by subject name
      Private Sub InitialiseLastLoginDisplay(studentSubjects As List(Of StudentSubject))
         Dim studentSubjectDictionary = studentSubjects.ToDictionary(Function(ss) ss.SubjectID, Function(ss) ss)
         Dim studentSubjectLastLogins = LoadStudentLastLogins(StudentID, EnrolmentYear, SubjectIDs)

         Dim studentSubject As StudentSubject = Nothing
         For Each subject In studentSubjectLastLogins
            If (subject.ActivityID = SiteLoginActivityID) Then
               litLastLMSLogin.Text = Common.GetDateTimeDisplay(subject.LastLoginDate)
            ElseIf studentSubjectDictionary.TryGetValue(subject.SubjectID, studentSubject) Then
               studentSubject.LastLoginDate = subject.LastLoginDate
            End If
         Next

         studentSubjects.Sort()
         lvSubjectLastLogin.DataSource = studentSubjects
         lvSubjectLastLogin.DataBind()
      End Sub


      Private Sub InitialiseActivityViewDefaults(studentDetails As StudentDetails)
         If (studentDetails.LearningAdvisorID.Equals(SignedInUserID)) Then
            ' By default learning advisors of the student view the activity in date received order
            ddlSortBy.SelectedValue = "DRCV"
         Else
            ' By default teachers of the student and others view the activity by subject
            ddlSortBy.SelectedValue = "SBJDRCV"

            ' In addition if the teacher is not the student's learning advisor, apply a default filter to the taught subjects only
            If (Not MySubjectIDs.Equals("")) Then
               ddlSubjects.SelectedValue = "MS"
            End If
         End If
      End Sub


      Private Sub RefreshActivityListQuery()
         sqldsStudentActivity.SelectCommand = GenerateStudentActivityListSQL()
      End Sub


      Private Function GenerateStudentActivityListSQL() As String
         Dim baseQuery = $"select
                              vsa.ActivityId,
                              vsa.CourseIdNum as SubjectID,
                              cast(vsa.CourseName as varchar(100)) as Subject,
                              vsa.ActivityType,
                              cast(vsa.ActivityName as varchar(100)) as Activity,
                              isnull(vsa.LastSubmissionDate, vsa.LastReturnDate) as LastReceived,
                              vsa.LastReturnDate as LastReturned,
                              vsa.StaffUsername as ReturnedBy,
                              vsa.Mark
                            from
                              dbo.vwStudentActivity as vsa
                            where
                              (vsa.StudentUsername = concat(cast(@studentID as varchar(10)), '@{EmailDomain}'))
                              and (((vsa.LastSubmissionDate >= datefromparts(@enrolmentYear, 1, 1)) and (vsa.LastSubmissionDate < datefromparts(@enrolmentYear + 1, 1, 1)))
                                or ((vsa.LastReturnDate >= datefromparts(@enrolmentYear, 1, 1)) and (vsa.LastReturnDate < datefromparts(@enrolmentYear + 1, 1, 1))))
                              and not ((vsa.ActivityType = 'attendance') and (isnull(try_cast(vsa.Mark as decimal(4, 2)), 1) = 0))"

         Dim activitySQL = baseQuery

         ' At the very least the activities need to be filtered to the student's subjects in the selected enrolment year, which may be none
         Dim filterSubjectIDs = SubjectIDs

         If (ddlSubjects.SelectedValue.Equals("AS")) Then
            filterSubjectIDs = ActiveSubjectIDs
         ElseIf (ddlSubjects.SelectedValue.Equals("MS")) Then
            filterSubjectIDs = MySubjectIDs
         ElseIf (ddlSubjects.SelectedValue.Equals("MAS")) Then
            filterSubjectIDs = MyActiveSubjectIDs
         ElseIf (Not (ddlSubjects.SelectedValue.Equals("") OrElse (ddlSubjects.SelectedValue.Equals("-")))) Then
            ' A specific subject ID has been selected
            filterSubjectIDs = ddlSubjects.SelectedValue
         End If
         If (filterSubjectIDs.Equals("")) Then
            ' No subjects to filter to, which may happen if the student is not attached to any subjects for the year
            ' In this circumstance nothing should be shown, and let the query optimiser know it
            activitySQL &= " and (0 = 1)"
         Else
            activitySQL &= $" and (vsa.CourseIdNum in ({filterSubjectIDs}))"
         End If

         If (Not ddlActivity.SelectedValue.Equals("")) Then
            ' Always pass a client-editable string as a database parameter
            activitySQL &= $" and (vsa.ActivityType = @activityType)"
         End If

         If (ddlSubmissions.SelectedValue.Equals("RO")) Then
            activitySQL &= " and (vsa.LastReturnDate is not null)"
         ElseIf (ddlSubmissions.SelectedValue.Equals("UR")) Then
            activitySQL &= " and (vsa.LastReturnDate is null)"

            If (ddlActivity.SelectedValue.Equals("")) Then
               ' The user has selected to view unreturned items only - but don't display the activities for which a return doesn't even apply
               activitySQL &= $" and (vsa.ActivityType in ('{String.Join("', '", ReturnableActivityTypes)}'))"
            ElseIf (Not ReturnableActivityTypes.Contains(ddlActivity.SelectedValue)) Then
               ' A special case - the user has selected to filter to an activity type that doesn't have returnable activities
               ' AND they only want to see unreturned activities
               ' In this instance again show nothing and let the query optimiser know it
               activitySQL &= " and (0 = 1)"
            End If
         End If

         If (ddlTimeFrame.SelectedValue.Equals("LF")) Then
            Dim twoWeeksAgoSQL = Date.Now.AddDays(-14).ToString("yyyyMMdd")
            activitySQL &= $" and ((vsa.LastSubmissionDate >= '{twoWeeksAgoSQL}') or (vsa.LastReturnDate >= '{twoWeeksAgoSQL}'))"
         ElseIf (ddlTimeFrame.SelectedValue.Equals("LM")) Then
            Dim oneMonthAgoSQL = Date.Now.AddMonths(-1).ToString("yyyyMMdd")
            activitySQL &= $" and ((vsa.LastSubmissionDate >= '{oneMonthAgoSQL}') or (vsa.LastReturnDate >= '{oneMonthAgoSQL}'))"
         End If

         activitySQL &= $" and (vsa.ActivityType not in ('{String.Join("', '", ExcludedActivityTypes)}'))"

         If (ddlSortBy.SelectedValue.Equals("DRCV")) Then
            activitySQL &= " order by LastReceived"
         ElseIf (ddlSortBy.SelectedValue.Equals("DRTN")) Then
            activitySQL &= " order by LastReturned"
         Else
            activitySQL &= " order by Subject, LastReceived"
         End If

         Return activitySQL
      End Function


      Function GenerateSubjectEnrolmentStatus(studentSubject As StudentSubject) As String
         If ((Not studentSubject.IsSubjectActive) AndAlso (studentSubject.SubjectWithdrawalDate.HasValue())) Then
            Return $"{studentSubject.SubjectEnrolmentStatus} ({Common.GetDateDisplay(studentSubject.SubjectWithdrawalDate)})"
         Else
            Return studentSubject.SubjectEnrolmentStatus
         End If
      End Function


      Function GetLMSActivityTypeDisplayName(activityType As String) As String
         Dim displayName As String = activityType
         If (ActivityTypeDisplayNames.TryGetValue(activityType, displayName)) Then
            Return displayName
         Else
            ' Tidy up the other display names as and if they're requested
            Return activityType
         End If
      End Function


      Function GenerateLMSActivityHTML(activityID As String, activityType As String, activityName As String) As String
         If (activityType.Equals("login")) Then
            ' A hack to pretty up the login display labels. TODO: See if they can be cleaned up at the source
            activityName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(activityName)
         End If

         Dim activityTypeDisplayName = GetLMSActivityTypeDisplayName(activityType)
         Dim activityTypeIcon = GetLMSIconLink(activityType)
         Dim activityImage = $"<img class=""ActivityIcon"" title=""{activityTypeDisplayName}"" src=""{activityTypeIcon}"">"
         Dim activityHTML As String

         If (LinkableActivityTypes.Contains(activityType)) Then
            Dim activityHref = $"https://lms.vsvonline.vic.edu.au/mod/{activityType}/view.php?id={activityID}"
            activityHTML = $"<a href=""{activityHref}"" target=""_blank"" title=""Open the VSV Online activity in a new browser window"">{activityImage}{activityName}</a>"
         Else
            activityHTML = $"{activityImage}{activityName}"
         End If

         Return activityHTML
      End Function


      Function GetLMSIconLink(activityType As String) As String
         Dim baseImageFolder = ResolveClientUrl("~/images/LMS/")
         Dim imageFile As String = Nothing

         Select Case activityType
            Case "login"
               imageFile = "login.png"
            Case "oublog"
               imageFile = "oublog.png"
            Case "subpage"
               imageFile = "subpage.gif"
            Case Else
               imageFile = activityType & ".svg"
         End Select

         Return baseImageFolder & imageFile
      End Function


      Function GenerateLMSActivityLink(activityID As String, activityType As String) As String
         Return $"https://lms.vsvonline.vic.edu.au/mod/{activityType}/view.php?id={activityID}"
      End Function


      Function GetReturnedDisplayDate(activityType As String, lastReturned As String) As String
         If (Not lastReturned.Equals("")) Then
            ' If there is a return date, display it regardless of whether we think it usually applies for that activity type
            Return lastReturned
         ElseIf ReturnableActivityTypes.Contains(activityType) Then
            ' Activity/item types that can be returned, but haven't been - display a blank
            Return ""
         Else
            Return "N/A"
         End If
      End Function


      Function GetReturnedByID(staffUsername As String) As String
         Dim atCharIndex = staffUsername.IndexOf("@"c)
         If (atCharIndex <> -1) Then
            Return staffUsername.Substring(0, atCharIndex).ToUpper()
         Else
            Return staffUsername
         End If
      End Function


      Protected Sub ddlSubjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubjects.SelectedIndexChanged
         lvStudentActivity.DataBind()
      End Sub


      Protected Sub ddlActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlActivity.SelectedIndexChanged
         lvStudentActivity.DataBind()
      End Sub


      Protected Sub ddlSubmissions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubmissions.SelectedIndexChanged
         lvStudentActivity.DataBind()
      End Sub


      Protected Sub ddlTimeFrame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTimeFrame.SelectedIndexChanged
         lvStudentActivity.DataBind()
      End Sub


      Protected Sub ddlSortBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSortBy.SelectedIndexChanged
         lvStudentActivity.DataBind()
      End Sub


      ' ---------------------------------------------------------------------------------------
      ' Begin data access
      ' ---------------------------------------------------------------------------------------


      Private Function LoadStudentDetails(studentID As Decimal, enrolmentYear As Integer) As StudentDetails
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.CommandText = "select
                                       concat(isnull(nullif(s.PREFERRED_NAME, ''), rtrim(s.FIRST_NAME)), ' ', rtrim(s.SURNAME)) as StudentName,
                                       se.PASTORAL_CARE_ID as LearningAdvisorID,
                                       case se.PASTORAL_CARE_ID
                                          when 'NO_SST' then 'None'
                                          when 'N-A' then 'N/A'
                                          else dbo.ProperCase(concat(rtrim(la.FIRSTNAME), ' ', rtrim(la.SURNAME)))
                                       end as LearningAdvisorName
                                       from
                                       dbo.STUDENT as s
                                       inner join dbo.STUDENT_ENROLMENT as se
                                          on (se.STUDENT_ID = s.STUDENT_ID)
                                       left join dbo.STAFF as la
                                          on (la.STAFF_ID = se.PASTORAL_CARE_ID)
                                       where
                                       (se.STUDENT_ID = @studentID)
                                       and (se.ENROLMENT_YEAR = @enrolmentYear);"

               With command.Parameters
                  .AddWithValue("@studentID", studentID)
                  .AddWithValue("@enrolmentYear", enrolmentYear)
               End With

               Dim reader = command.ExecuteReader()
               If reader.Read() Then
                  Return New StudentDetails() With
                  {
                     .StudentName = reader("StudentName").ToString(),
                     .LearningAdvisorID = reader("LearningAdvisorID").ToString().Trim().ToUpper(),
                     .LearningAdvisorName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(reader("LearningAdvisorName").ToString().ToLower())
                  }
               Else
                  Return Nothing
               End If
            End Using
         End Using
      End Function


      Private Function LoadStudentSubjects(studentID As Decimal, enrolmentYear As Integer) As List(Of StudentSubject)
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.CommandText = "select
                                       ss.SUBJECT_ID as SubjectID,
                                       sbj.SUBJECT_TITLE as SubjectTitle,
                                       ss.STAFF_ID as SubjectTeacherID,
                                       ss.SUBJ_ENROL_STATUS as SubjectEnrolmentStatus,
                                       ss.WITHDRAWAL_DATE as SubjectWithdrawalDate
                                       from
                                       dbo.STUDENT_ENROLMENT as se
                                       inner join dbo.STUDENT_SUBJECT as ss
                                          on (
                                                (ss.STUDENT_ID = se.STUDENT_ID)
                                                and (ss.ENROLMENT_YEAR = se.ENROLMENT_YEAR)
                                             )
                                       inner join dbo.SUBJECT as sbj
                                          on (sbj.SUBJECT_ID = ss.SUBJECT_ID)
                                       where
                                       (se.STUDENT_ID = @studentID)
                                       and (se.ENROLMENT_YEAR = @enrolmentYear)
                                       order by
                                       SubjectTitle;"

               With command.Parameters
                  .AddWithValue("@studentID", studentID)
                  .AddWithValue("@enrolmentYear", enrolmentYear)
               End With

               Dim studentSubjectDetails As New List(Of StudentSubject)()
               Dim reader = command.ExecuteReader()
               While (reader.Read())
                  studentSubjectDetails.Add(New StudentSubject() With
                  {
                     .SubjectID = reader.Value(Of Integer)("SubjectID"),
                     .SubjectTitle = reader("SubjectTitle").ToString().Trim(),
                     .SubjectTeacherID = reader("SubjectTeacherID").ToString().Trim().ToUpper(),
                     .SubjectEnrolmentStatus = reader("SubjectEnrolmentStatus").ToString(),
                     .SubjectWithdrawalDate = reader.Value(Of Date?)("SubjectWithdrawalDate")
                  })
               End While

               Return studentSubjectDetails
            End Using
         End Using
      End Function


      Private Function LoadStudentLastLogins(studentID As Decimal, enrolmentYear As Integer, subjectIDs As String) As List(Of StudentActivityLastLogin)
         Dim filterSubjectIDs = subjectIDs
         If (filterSubjectIDs.Length > 0) Then
            filterSubjectIDs &= ", " & SiteLoginSubjectID.ToString()
         Else
            filterSubjectIDs = SiteLoginSubjectID.ToString()
         End If

         Using connection As New SqlConnection(Settings.connDECVAPIPRODConnection.Connection)
            connection.Open()

            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.CommandText = $"select
                                          *
                                        from
                                        (
                                           select
                                              s.ActivityId,
                                              s.CourseIdNum as SubjectID,
                                              s.EnteredDate as LastLoginDate,
                                              row_number() over (partition by s.CourseIdNum order by s.EnteredDate desc) as LoginNumberDesc
                                            from
                                              dbo.Submissions as s
                                            where
                                              (s.StudentUsername = concat(cast(@studentID as varchar(10)), '@{EmailDomain}'))
                                              and ((s.EnteredDate >= datefromparts(@enrolmentYear, 1, 1)) and (s.EnteredDate < datefromparts(@enrolmentYear + 1, 1, 1)))
                                              and (s.ActivityType = 'login')
                                              and (s.CourseIdNum in ({filterSubjectIDs}))
                                        ) as SubjectLogins
                                        where
                                          (SubjectLogins.LoginNumberDesc = 1);"

               With command.Parameters
                  .AddWithValue("@studentID", studentID)
                  .AddWithValue("@enrolmentYear", enrolmentYear)
               End With

               Dim lastLogins As New List(Of StudentActivityLastLogin)()
               Dim reader = command.ExecuteReader()
               While (reader.Read())
                  lastLogins.Add(New StudentActivityLastLogin() With
                  {
                     .ActivityID = reader.Value(Of Integer)("ActivityId"),
                     .SubjectID = reader.Value(Of Integer)("SubjectID"),
                     .LastLoginDate = reader.Value(Of Date?)("LastLoginDate")
                  })
               End While

               Return lastLogins
            End Using
         End Using
      End Function


      'Page class tail @1-DD082417
   End Class
End Namespace
'End Page class tail

