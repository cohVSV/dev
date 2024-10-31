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

Namespace DECV_PROD2007.StudentSubject_TeacherStats 'Namespace @1-50F518C9

'Forms Definition @1-7348151D
Public Class [StudentSubject_TeacherStatsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-6D53E1AE
    Protected rptTeacherAllocationData As rptTeacherAllocationDataProvider
    Protected rptTeacherAllocationOperations As FormSupportedOperations
    Protected StudentSubject_TeacherStatsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-2C3EE9E4
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            rptTeacherAllocationBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Report rptTeacherAllocation Bind @4-9248765B
    Protected Sub rptTeacherAllocationBind()
        If Not rptTeacherAllocationOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"rptTeacherAllocation",GetType(rptTeacherAllocationDataProvider.SortFields), 0, 100)
        End If
'End Report rptTeacherAllocation Bind

'Report Form rptTeacherAllocation BeforeShow tail @4-B7A3CF3A
        rptTeacherAllocationParameters
        rptTeacherAllocationData.SortField = CType(ViewState("rptTeacherAllocationSortField"),rptTeacherAllocationDataProvider.SortFields)
        rptTeacherAllocationData.SortDir = CType(ViewState("rptTeacherAllocationSortDir"),SortDirections)
        rptTeacherAllocation.DataSource = rptTeacherAllocationData.GetResultSet(rptTeacherAllocationOperations)
        rptTeacherAllocation.DataBind()
'End Report Form rptTeacherAllocation BeforeShow tail

	End Sub 'Report rptTeacherAllocation Bind tail @4-E31F8E2A

'Report rptTeacherAllocation Table Parameters @4-5FFDD381

    Protected Sub rptTeacherAllocationParameters()
        Try
            rptTeacherAllocationData.Urlsubject_id = TextParameter.GetParam("subject_id", ParameterSourceType.URL, "", 0, false)
            rptTeacherAllocationData.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Date.Today.Year, false)

        Catch
            Dim ParentControls As ControlCollection=rptTeacherAllocation.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(rptTeacherAllocation)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid rptTeacherAllocation: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report rptTeacherAllocation Table Parameters

'Report rptTeacherAllocation OnCalculate event @4-D010471D
    Protected Sub rptTeacherAllocationOnCalculate(Sender As Object , e As OnCalculateEventArgs)
    Dim item As rptTeacherAllocationItem = CType(e.Item.DataItem,rptTeacherAllocationItem)  'Read-Only
'End Report rptTeacherAllocation OnCalculate event

'Section Report_Footer OnCalculate event header @13-3C155983
    If e.SectionName = "Report_Footer" Then
    Dim rptTeacherAllocationNoRecords As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("rptTeacherAllocationNoRecords"),System.Web.UI.WebControls.PlaceHolder)
    Dim rptTeacherAllocationTotalSum_SUBJECT_TIMEFRACTION As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_SUBJECT_TIMEFRACTION"),ReportLabel)
    Dim rptTeacherAllocationTotalSum_FTE_StudentMax As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_FTE_StudentMax"),ReportLabel)
    Dim rptTeacherAllocationTotalSum_Current_Student_Count As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_Current_Student_Count"),ReportLabel)
    Dim rptTeacherAllocationlblTotalAllocationPercentage As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblTotalAllocationPercentage"),ReportLabel)
'End Section Report_Footer OnCalculate event header

'Section Report_Footer Event OnCalculate. Action Custom Code @30-73254650
    Dim totalTeacherAllocationMax As Integer
    Dim totalStudentCount As Integer
    If (Integer.TryParse(rptTeacherAllocationTotalSum_FTE_StudentMax.Text, totalTeacherAllocationMax) AndAlso
        Integer.TryParse(rptTeacherAllocationTotalSum_Current_Student_Count.Text, totalStudentCount) AndAlso
        (totalTeacherAllocationMax > 0)) Then
       rptTeacherAllocationlblTotalAllocationPercentage.Text = (totalStudentCount / totalTeacherAllocationMax).ToString("P0")
    End If
'End Section Report_Footer Event OnCalculate. Action Custom Code

    Exit Sub 'Report Report_Footer OnCalculate event footer1 @13-835F35D5

    End If 'Report Report_Footer OnCalculate event footer @13-477CF3C9

	End Sub 'Report rptTeacherAllocation OnCalculate event tail @4-E31F8E2A

'Report rptTeacherAllocation BeforeShowSection event @4-0B61D9CA
    Protected Sub rptTeacherAllocationBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As rptTeacherAllocationItem  = CType(e.Item.DataItem, rptTeacherAllocationItem)
        Dim Item As rptTeacherAllocationItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New rptTeacherAllocationItem()
        Select e.Item.name
            Case "Report_Header"
                Dim rptTeacherAllocationlblEnrolmentYear As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblEnrolmentYear"),ReportLabel)
                Dim rptTeacherAllocationlblSubjectAbbreviation As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblSubjectAbbreviation"),ReportLabel)
            Case "Page_Header"
            Case "SEMESTER_Header"
                Dim rptTeacherAllocationSEMESTER As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationSEMESTER"),ReportLabel)
            Case "Detail"
                Dim rptTeacherAllocationSTAFF_ID As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationSTAFF_ID"),ReportLabel)
                Dim rptTeacherAllocationSUBJECT_TIMEFRACTION As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationSUBJECT_TIMEFRACTION"),ReportLabel)
                Dim rptTeacherAllocationFTE_StudentMax As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationFTE_StudentMax"),ReportLabel)
                Dim rptTeacherAllocationCurrent_Student_Count As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationCurrent_Student_Count"),ReportLabel)
                Dim rptTeacherAllocationPercentage As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationPercentage"),ReportLabel)
            Case "SEMESTER_Footer"
            Case "Report_Footer"
                Dim rptTeacherAllocationTotalSum_SUBJECT_TIMEFRACTION As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_SUBJECT_TIMEFRACTION"),ReportLabel)
                Dim rptTeacherAllocationTotalSum_FTE_StudentMax As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_FTE_StudentMax"),ReportLabel)
                Dim rptTeacherAllocationTotalSum_Current_Student_Count As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationTotalSum_Current_Student_Count"),ReportLabel)
                Dim rptTeacherAllocationlblTotalAllocationPercentage As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblTotalAllocationPercentage"),ReportLabel)
            Case "Page_Footer"
        End Select
'End Report rptTeacherAllocation BeforeShowSection event

		Select e.Item.name 'BeforeShow events @4-4EF46BEF

			case "Report_Header": 'Section Report_Header BeforeShow events @7-8BA77810

'Get lblEnrolmentYear control @31-8DA9F4BE
                Dim rptTeacherAllocationlblEnrolmentYear As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblEnrolmentYear"),ReportLabel)
'End Get lblEnrolmentYear control

'ReportLabel lblEnrolmentYear Event BeforeShow. Action Custom Code @33-73254650
	rptTeacherAllocationlblEnrolmentYear.Text = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())
'End ReportLabel lblEnrolmentYear Event BeforeShow. Action Custom Code

'Get lblSubjectAbbreviation control @32-C4CF8827
                Dim rptTeacherAllocationlblSubjectAbbreviation As ReportLabel = DirectCast(e.Item.FindControl("rptTeacherAllocationlblSubjectAbbreviation"),ReportLabel)
'End Get lblSubjectAbbreviation control

'ReportLabel lblSubjectAbbreviation Event BeforeShow. Action Custom Code @34-73254650
	rptTeacherAllocationlblSubjectAbbreviation.Text = If(Request.QueryString("SUBJECT_ABBREV"), "")
'End ReportLabel lblSubjectAbbreviation Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @4-3508C6CC



    End Sub 'Section rptTeacherAllocation BeforeShow events tail @4-E31F8E2A

'Report rptTeacherAllocation ItemCommand event @4-FD971225
    Protected Sub rptTeacherAllocationItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("rptTeacherAllocationSortDir"),SortDirections) = SortDirections._Asc And ViewState("rptTeacherAllocationSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("rptTeacherAllocationSortDir")=SortDirections._Desc
                Else
                    ViewState("rptTeacherAllocationSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("rptTeacherAllocationSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As rptTeacherAllocationDataProvider.SortFields = 0
            ViewState("rptTeacherAllocationSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("rptTeacherAllocationPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            rptTeacherAllocation.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            rptTeacherAllocationBind
        End If
    End Sub
'End Report rptTeacherAllocation ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F2531B48
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentSubject_TeacherStatsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        rptTeacherAllocationData = new rptTeacherAllocationDataProvider()
        rptTeacherAllocationOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler rptTeacherAllocation.OnCalculate, AddressOf Me.rptTeacherAllocationOnCalculate
        AddHandler rptTeacherAllocation.BeforeShowSection, AddressOf Me.rptTeacherAllocationBeforeShowSection
        rptTeacherAllocation.Groups.Add("SEMESTER","SEMESTERGroupField")
        If Request("ViewMode") Is Nothing Then rptTeacherAllocation.ViewMode= ReportViewMode.Web
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

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

