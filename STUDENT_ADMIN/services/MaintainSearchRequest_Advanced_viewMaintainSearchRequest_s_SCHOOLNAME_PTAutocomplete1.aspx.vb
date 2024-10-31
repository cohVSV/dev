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

Namespace DECV_PROD2007.services.MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1 'Namespace @1-13CC6CAA

'Forms Definition @1-796C9E0C
Public Class [MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F2B033A4
    Protected SCHOOLData As SCHOOLDataProvider
    Protected SCHOOLOperations As FormSupportedOperations
    Protected SCHOOLCurrentRowNumber As Integer
    Protected MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-31B2A3B0
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SCHOOLBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SCHOOL Bind @2-B04D0B35

    Protected Sub SCHOOLBind()
        If Not SCHOOLOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SCHOOL",GetType(SCHOOLDataProvider.SortFields), 10, 100)
        End If
'End Grid SCHOOL Bind

'Grid Form SCHOOL BeforeShow tail @2-EFCF8910
        SCHOOLParameters()
        SCHOOLData.SortField = CType(ViewState("SCHOOLSortField"),SCHOOLDataProvider.SortFields)
        SCHOOLData.SortDir = CType(ViewState("SCHOOLSortDir"),SortDirections)
        SCHOOLData.PageNumber = CInt(ViewState("SCHOOLPageNumber"))
        SCHOOLData.RecordsPerPage = CInt(ViewState("SCHOOLPageSize"))
        SCHOOLRepeater.DataSource = SCHOOLData.GetResultSet(PagesCount, SCHOOLOperations)
        ViewState("SCHOOLPagesCount") = PagesCount
        Dim item As SCHOOLItem = New SCHOOLItem()
        SCHOOLRepeater.DataBind
        FooterIndex = SCHOOLRepeater.Controls.Count - 1

'End Grid Form SCHOOL BeforeShow tail

'Grid SCHOOL Bind tail @2-E31F8E2A
    End Sub
'End Grid SCHOOL Bind tail

'Grid SCHOOL Table Parameters @2-5B6C05E4

    Protected Sub SCHOOLParameters()
        Try
            SCHOOLData.PostviewMaintainSearchRequests_SCHOOLNAME = TextParameter.GetParam("viewMaintainSearchRequests_SCHOOLNAME", ParameterSourceType.Form, "", Nothing, false)
            SCHOOLData.PostSTUDENT_CENSUS_DATASCHOOL_NAME = TextParameter.GetParam("STUDENT_CENSUS_DATASCHOOL_NAME", ParameterSourceType.Form, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=SCHOOLRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SCHOOLRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SCHOOL: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SCHOOL Table Parameters

'Grid SCHOOL ItemDataBound event @2-A3036D86

    Protected Sub SCHOOLItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SCHOOLItem = CType(e.Item.DataItem,SCHOOLItem)
        Dim Item as SCHOOLItem = DataItem
        Dim FormDataSource As SCHOOLItem() = CType(SCHOOLRepeater.DataSource, SCHOOLItem())
        Dim SCHOOLDataRows As Integer = FormDataSource.Length
        Dim SCHOOLIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SCHOOLCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SCHOOLRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SCHOOLCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SCHOOLschool_name As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLschool_name"),System.Web.UI.WebControls.Literal)
        End If
'End Grid SCHOOL ItemDataBound event

'Grid SCHOOL ItemDataBound event tail @2-0BAF0BDC
        If SCHOOLIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SCHOOLCurrentRowNumber, ListItemType.Item)
            SCHOOLRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SCHOOLItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SCHOOL ItemDataBound event tail

'Grid SCHOOL ItemCommand event @2-8E658108

    Protected Sub SCHOOLItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SCHOOLRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SCHOOLSortDir"),SortDirections) = SortDirections._Asc And ViewState("SCHOOLSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SCHOOLSortDir")=SortDirections._Desc
                Else
                    ViewState("SCHOOLSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SCHOOLSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SCHOOLDataProvider.SortFields = 0
            ViewState("SCHOOLSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SCHOOLPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SCHOOLPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SCHOOLPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SCHOOLPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SCHOOLBind
        End If
    End Sub
'End Grid SCHOOL ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-78558EC0
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MaintainSearchRequest_Advanced_viewMaintainSearchRequest_s_SCHOOLNAME_PTAutocomplete1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOLData = New SCHOOLDataProvider()
        SCHOOLOperations = New FormSupportedOperations(False, True, False, False, False)
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

