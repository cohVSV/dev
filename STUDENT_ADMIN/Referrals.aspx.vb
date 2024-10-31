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
Imports System.Net.Http
Imports System.Threading.Tasks

Namespace DECV_PROD2007.Referrals

   Public Class ReferralField
      Public Property Question As String
      Public Property Answer As String

      Public Sub New(question As String, answer As String)
         Me.Question = question
         Me.Answer = answer
      End Sub

   End Class

   Public Class [ReferralsPage]
      Inherits CCPage

      Protected ReferralsContentMeta As String
      Protected ReferralFields As List(Of ReferralField) = New List(Of ReferralField)
      Protected YARFFields As List(Of ReferralField) = New List(Of ReferralField)
      Protected PARFFields As List(Of ReferralField) = New List(Of ReferralField)
      Protected CoachSportsFields As List(Of ReferralField) = New List(Of ReferralField)
      Protected SportsSchoolFields As List(Of ReferralField) = New List(Of ReferralField)
      Protected TravelEmployerFields As List(Of ReferralField) = New List(Of ReferralField)

      Protected FunnelUid As String

      Private ReadOnly Property StudentID As Decimal
         Get
            Dim id = Request.QueryString("STUDENT_ID")
            id = If(String.IsNullOrWhiteSpace(id), "66236", id)

            Return Decimal.Parse(id)
         End Get
      End Property


      Private ReadOnly Property EnrolmentYear As Integer
         Get
            Dim year = Request.QueryString("ENROLMENT_YEAR")
            year = If(String.IsNullOrWhiteSpace(year), "2024", year)

            Return Decimal.Parse(year)
         End Get
      End Property

      Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

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


         If Not IsPostBack Then
            LoadData()


         End If

      End Sub

      Private Sub LoadData()
         ImportReferralsButton.Visible = False
         UuidTextBox.Visible = False
         SaveUuidButton.Visible = False
         uuidLabel.Visible = False
         Debug.WriteLine(User.ToString())
         Debug.WriteLine(User.Identity.Name)
         Dim funnelUuIdCorrect = CheckFunnelUuid()
         If (Not funnelUuIdCorrect)
            uuidLabel.Text = "No Funnel ID found for this student. Please open a service desk ticket to get this issue fixed."
            uuidLabel.Visible = True
            If User.Identity.Name = "lgordon"
               UuidTextBox.Visible = True
               SaveUuidButton.Visible = True
            End If
            Return
         End If

         Dim referralsLoadedFromDB = LoadReferrals()
         If Not referralsLoadedFromDB
            uuidLabel.Text = $"No referral forms found for this student({FunnelUid}). Please open a service desk ticket to get this issue fixed."
            uuidLabel.Visible = True
            'ImportReferralsButton.Visible = True
            Return
         End If
      End Sub

      Private Function CheckFunnelUuid() As Boolean
         Dim studentQuery = $"select top 1 * from student where student_id = {StudentID}"
         Using studentConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            studentConnection.Open()
            Using studentCommand = studentConnection.CreateCommand()
               studentCommand.CommandType = CommandType.Text
               studentCommand.CommandText = studentQuery
               Dim reader = studentCommand.ExecuteReader()
               If reader.Read()
                  FunnelUid = If(IsDBNull(reader("FUNNEL_UUID")), Nothing, reader("FUNNEL_UUID"))
                  Dim STUDENT_ID = If(IsDBNull(reader("STUDENT_ID")), "", reader("STUDENT_ID"))
               End If
            End Using
         End Using

         Return FunnelUid IsNot Nothing
      End Function

      Private Function LoadReferrals() As Boolean
         Dim srfQuery = $"select top 1 * from REFERRAL_SCHOOL where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"
         Dim yarfQuery = $"select top 1 * from REFERRAL_YOUNG_ADULT where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"
         Dim parfQuery = $"select top 1 * from REFERRAL_PRACTITIONER_AGENCY where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"
         Dim coachSportsQuery = $"select top 1 * from REFERRAL_COACH_SPORTS_ASSOCIATION where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"
         Dim sportsSchoolQuery = $"select top 1 * from REFERRAL_SPORTS_SCHOOL where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"
         Dim travelEmployerQuery = $"select top 1 * from REFERRAL_TRAVEL_EMPLOYER where ENROLMENT_YEAR = {EnrolmentYear} and STUDENT_ID = {StudentID}"

         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()
            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.CommandText = srfQuery
               Dim reader = command.ExecuteReader()

               If (reader.Read()) Then
                  For i = 0 To reader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(reader(i)), "", reader(i))
                     Dim key = CleanupName(reader.GetName(i))
                     ReferralFields.Add(New ReferralField(key, val))
                  Next

               End If
               reader.Close()
            End Using
            connection.Close()
         End Using
         lvReferral.DataSource = ReferralFields
         lvReferral.DataBind()

         Using yarfConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            yarfConnection.Open()
            Using yarfCommand = yarfConnection.CreateCommand()
               yarfCommand.CommandType = CommandType.Text
               yarfCommand.CommandText = yarfQuery
               Dim yarfReader = yarfCommand.ExecuteReader()

               If (yarfReader.Read()) Then
                  For i = 0 To yarfReader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(yarfReader(i)), "", yarfReader(i))
                     Dim key = CleanupName(yarfReader.GetName(i))
                     YARFFields.Add(New ReferralField(key, val))
                  Next
               End If
            End Using
         End Using
         lvYARF.DataSource = YARFFields
         lvYARF.DataBind()



         Using parfConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            parfConnection.Open()
            Using parfCommand = parfConnection.CreateCommand()
               parfCommand.CommandType = CommandType.Text
               parfCommand.CommandText = parfQuery
               Dim parfReader = parfCommand.ExecuteReader()

               If (parfReader.Read()) Then
                  For i = 0 To parfReader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(parfReader(i)), "", parfReader(i))
                     Dim key = CleanupName(parfReader.GetName(i))
                     PARFFields.Add(New ReferralField(key, val))
                  Next
               End If
            End Using
         End Using
         lvPARF.DataSource = PARFFields
         lvPARF.DataBind()

         Using coachSportsConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            coachSportsConnection.Open()
            Using coachSportsCommand = coachSportsConnection.CreateCommand()
               coachSportsCommand.CommandType = CommandType.Text
               coachSportsCommand.CommandText = coachSportsQuery
               Dim coachSportsReader = coachSportsCommand.ExecuteReader()

               If (coachSportsReader.Read()) Then
                  For i = 0 To coachSportsReader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(coachSportsReader(i)), "", coachSportsReader(i))
                     Dim key = CleanupName(coachSportsReader.GetName(i))
                     CoachSportsFields.Add(New ReferralField(key, val))
                  Next
               End If
            End Using
         End Using
         lvCoachSports.DataSource = CoachSportsFields
         lvCoachSports.DataBind()

         Using sportsSchoolConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            sportsSchoolConnection.Open()
            Using sportsSchoolCommand = sportsSchoolConnection.CreateCommand()
               sportsSchoolCommand.CommandType = CommandType.Text
               sportsSchoolCommand.CommandText = sportsSchoolQuery
               Dim sportsSchoolReader = sportsSchoolCommand.ExecuteReader()

               If (sportsSchoolReader.Read()) Then
                  For i = 0 To sportsSchoolReader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(sportsSchoolReader(i)), "", sportsSchoolReader(i))
                     Dim key = CleanupName(sportsSchoolReader.GetName(i))
                     SportsSchoolFields.Add(New ReferralField(key, val))
                  Next
               End If
            End Using
         End Using
         lvSportsSchool.DataSource = SportsSchoolFields
         lvSportsSchool.DataBind()

         Using travelEmployerConnection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            travelEmployerConnection.Open()
            Using travelEmployerCommand = travelEmployerConnection.CreateCommand()
               travelEmployerCommand.CommandType = CommandType.Text
               travelEmployerCommand.CommandText = travelEmployerQuery
               Dim travelEmployerReader = travelEmployerCommand.ExecuteReader()

               If (travelEmployerReader.Read()) Then
                  For i = 0 To travelEmployerReader.FieldCount - 1 Step 1
                     Dim val = If(IsDBNull(travelEmployerReader(i)), "", travelEmployerReader(i))
                     Dim key = CleanupName(travelEmployerReader.GetName(i))
                     TravelEmployerFields.Add(New ReferralField(key, val))
                  Next
               End If
            End Using
         End Using
         lvTravelEmployer.DataSource = TravelEmployerFields
         lvTravelEmployer.DataBind()

         If TravelEmployerFields.Any() Or CoachSportsFields.Any() Or PARFFields.Any() Or ReferralFields.Any() Or SportsSchoolFields.Any() Or YARFFields.Any()
            Return True
         End If

         Return False
      End Function



      Private Function CleanupName(v As String) As Object
         Dim niceName = v.Replace("_", " ").ToLower()
         Dim firstChar = niceName.First
         niceName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(niceName)
         Return niceName

      End Function

      Protected Overrides Sub OnUnload(ByVal e As System.EventArgs)

      End Sub

#Region " Web Form Designer Generated Code "
      Protected Overrides Sub OnInit(ByVal e As EventArgs)
         ClientScript.GetPostBackEventReference(Me, "")
         Utility.SetThreadCulture()
         PageStyleName = Utility.GetPageStyle()
         ReferralsContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
         If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName)
         End If
         InitializeComponent()
         MyBase.OnInit(e)

         PageStyleName = Server.UrlEncode(PageStyleName)
      End Sub

      Private Sub InitializeComponent()
      End Sub
#End Region

      Protected Sub ShowHideClicked(sender As Object, e As EventArgs)
         ImportReferralsButton.Visible = Not ImportReferralsButton.Visible

      End Sub

      Protected Sub SaveUuidClicked(sender As Object, e As EventArgs)
         FunnelUid = UuidTextBox.Text
         Dim updateQuery = $"update student set FUNNEL_UUID = '{FunnelUid}' where student_id = {StudentID}"
         Using connection As New SqlConnection(Settings.connDECVPRODSQL2005Connection.Connection)
            connection.Open()
            Using command = connection.CreateCommand()
               command.CommandType = CommandType.Text
               command.CommandText = updateQuery
               Dim travelEmployerReader = command.ExecuteReader()

               
            End Using
         End Using


         'SaveUuidButton.Visible = False
         'UuidTextBox.Visible = False
         'uuidLabel.Visible = true
         'uuidLabel.Text = "testing save feature"
         'Debug.WriteLine(FunnelUid)
         LoadData()
      End Sub


      Protected Async Sub ImportReferralsClicked(sender As Object, e As EventArgs)
         'Dim client = New HttpClient()
         'Await client.GetAsync($"http://vsv-app02:65001/api/SpReferalTest?uuid={FunnelUid}")

      End Sub
   End Class
End Namespace

