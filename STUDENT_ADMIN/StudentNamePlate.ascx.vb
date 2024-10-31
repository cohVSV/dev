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

Namespace DECV_PROD2007.StudentNamePlate 'Namespace @1-59EF69EE

'Forms Definition @1-4A0776D6
Public Class [StudentNamePlatePage]
Inherits CCUserControl
'End Forms Definition

'Forms Objects @1-801D4450
    Protected viewStudentSummary_DetailData As viewStudentSummary_DetailDataProvider
    Protected viewStudentSummary_DetailOperations As FormSupportedOperations
    Protected StudentNamePlateContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B7EB609B
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewStudentSummary_DetailBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Report viewStudentSummary_Detail Bind @2-5DEB5F00
    Protected Sub viewStudentSummary_DetailBind()
        If Not viewStudentSummary_DetailOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"viewStudentSummary_Detail",GetType(viewStudentSummary_DetailDataProvider.SortFields), 0, 100)
        End If
'End Report viewStudentSummary_Detail Bind

'Report Form viewStudentSummary_Detail BeforeShow tail @2-C6EBA37A
        viewStudentSummary_DetailParameters
        viewStudentSummary_DetailData.SortField = CType(ViewState("viewStudentSummary_DetailSortField"),viewStudentSummary_DetailDataProvider.SortFields)
        viewStudentSummary_DetailData.SortDir = CType(ViewState("viewStudentSummary_DetailSortDir"),SortDirections)
        viewStudentSummary_Detail.DataSource = viewStudentSummary_DetailData.GetResultSet(viewStudentSummary_DetailOperations)
        viewStudentSummary_Detail.DataBind()
'End Report Form viewStudentSummary_Detail BeforeShow tail

	End Sub 'Report viewStudentSummary_Detail Bind tail @2-E31F8E2A

'Report viewStudentSummary_Detail Table Parameters @2-29BB51E4

    Protected Sub viewStudentSummary_DetailParameters()
        Try
            viewStudentSummary_DetailData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewStudentSummary_DetailData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)

        Catch
            Dim ParentControls As ControlCollection=viewStudentSummary_Detail.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewStudentSummary_Detail)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewStudentSummary_Detail: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report viewStudentSummary_Detail Table Parameters

'Report viewStudentSummary_Detail BeforeItemDataBound event @2-CC98FD53
    Protected Sub viewStudentSummary_DetailBeforeItemDataBound(Sender As Object , e As BeforeItemDataBoundEventArgs )
        e.DataItem("lblATAR_REQUIRED").SetValue("")
    End Sub
'End Report viewStudentSummary_Detail BeforeItemDataBound event

'Report viewStudentSummary_Detail BeforeShowSection event @2-187CDF3D
    Protected Sub viewStudentSummary_DetailBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As viewStudentSummary_DetailItem  = CType(e.Item.DataItem, viewStudentSummary_DetailItem)
        Dim Item As viewStudentSummary_DetailItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New viewStudentSummary_DetailItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Detail"
                Dim viewStudentSummary_Detailfirst_name As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Detailfirst_name"),ReportLabel)
                Dim viewStudentSummary_Detailsurname As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Detailsurname"),ReportLabel)
                Dim viewStudentSummary_DetailSTUDENT_ID As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailSTUDENT_ID"),ReportLabel)
                Dim viewStudentSummary_Detailsubcategory_full_title As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_Detailsubcategory_full_title"),ReportLabel)
                Dim viewStudentSummary_DetailGENDER As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailGENDER"),ReportLabel)
                Dim viewStudentSummary_DetailBIRTH_DATE As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailBIRTH_DATE"),ReportLabel)
                Dim viewStudentSummary_DetailAGE As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailAGE"),ReportLabel)
                Dim viewStudentSummary_DetailENROLMENT_STATUS As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailENROLMENT_STATUS"),ReportLabel)
                Dim viewStudentSummary_DetailYEAR_LEVEL As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailYEAR_LEVEL"),ReportLabel)
                Dim viewStudentSummary_DetailATAR_REQUIRED As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailATAR_REQUIRED"),ReportLabel)
                Dim viewStudentSummary_DetaillblATAR_REQUIRED As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetaillblATAR_REQUIRED"),ReportLabel)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report viewStudentSummary_Detail BeforeShowSection event

		Select e.Item.name 'BeforeShow events @2-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @17-D5562AB6

'Get ATAR_REQUIRED control @36-F1E0AAC5
                Dim viewStudentSummary_DetailATAR_REQUIRED As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailATAR_REQUIRED"),ReportLabel)
'End Get ATAR_REQUIRED control

'ReportLabel ATAR_REQUIRED Event BeforeShow. Action Custom Code @38-73254650
    ' -------------------------
    ' Hide if not Year 12 and not N
	Dim viewStudentSummary_DetailYEAR_LEVEL As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetailYEAR_LEVEL"),ReportLabel)
	Dim viewStudentSummary_DetaillblATAR_REQUIRED As ReportLabel = DirectCast(e.Item.FindControl("viewStudentSummary_DetaillblATAR_REQUIRED"),ReportLabel)
	if ((viewStudentSummary_DetailYEAR_LEVEL.Text <> "12") or (viewStudentSummary_DetailATAR_REQUIRED.Text <> "N")) then
		viewStudentSummary_DetailATAR_REQUIRED.Visible = False
		viewStudentSummary_DetaillblATAR_REQUIRED.Visible = False
	end if
    ' -------------------------
'End ReportLabel ATAR_REQUIRED Event BeforeShow. Action Custom Code


		End Select 'BeforeShow events @2-3508C6CC

    End Sub 'Section viewStudentSummary_Detail BeforeShow events tail @2-E31F8E2A

'Report viewStudentSummary_Detail ItemCommand event @2-59C4FECD
    Protected Sub viewStudentSummary_DetailItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewStudentSummary_DetailSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewStudentSummary_DetailSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewStudentSummary_DetailSortDir")=SortDirections._Desc
                Else
                    ViewState("viewStudentSummary_DetailSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewStudentSummary_DetailSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewStudentSummary_DetailDataProvider.SortFields = 0
            ViewState("viewStudentSummary_DetailSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewStudentSummary_DetailPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            viewStudentSummary_Detail.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewStudentSummary_DetailBind
        End If
    End Sub
'End Report viewStudentSummary_Detail ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-1FB3F886
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentNamePlateContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        viewStudentSummary_DetailData = new viewStudentSummary_DetailDataProvider()
        viewStudentSummary_DetailOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler viewStudentSummary_Detail.BeforeItemDataBound, AddressOf Me.viewStudentSummary_DetailBeforeItemDataBound
        AddHandler viewStudentSummary_Detail.BeforeShowSection, AddressOf Me.viewStudentSummary_DetailBeforeShowSection
        If Request("ViewMode") Is Nothing Then viewStudentSummary_Detail.ViewMode= ReportViewMode.Web
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

