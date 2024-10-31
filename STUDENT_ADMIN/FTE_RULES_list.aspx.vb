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

Namespace DECV_PROD2007.FTE_RULES_list 'Namespace @1-DA7F71D4

'Forms Definition @1-DA8C0690
Public Class [FTE_RULES_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-AD98AFA2
    Protected FTE_RULESData As FTE_RULESDataProvider
    Protected FTE_RULESOperations As FormSupportedOperations
    Protected FTE_RULESCurrentRowNumber As Integer
    Protected FTE_RULES_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-F411F4BE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            FTE_RULESBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid FTE_RULES Bind @2-79F0C53D

    Protected Sub FTE_RULESBind()
        If Not FTE_RULESOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"FTE_RULES",GetType(FTE_RULESDataProvider.SortFields), 20, 100)
        End If
'End Grid FTE_RULES Bind

'Grid Form FTE_RULES BeforeShow tail @2-5182367E
        FTE_RULESData.SortField = CType(ViewState("FTE_RULESSortField"),FTE_RULESDataProvider.SortFields)
        FTE_RULESData.SortDir = CType(ViewState("FTE_RULESSortDir"),SortDirections)
        FTE_RULESData.PageNumber = CInt(ViewState("FTE_RULESPageNumber"))
        FTE_RULESData.RecordsPerPage = CInt(ViewState("FTE_RULESPageSize"))
        FTE_RULESRepeater.DataSource = FTE_RULESData.GetResultSet(PagesCount, FTE_RULESOperations)
        ViewState("FTE_RULESPagesCount") = PagesCount
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        FTE_RULESRepeater.DataBind
        FooterIndex = FTE_RULESRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            FTE_RULESRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim FTE_RULESFTE_RULES_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(FTE_RULESRepeater.Controls(FooterIndex).FindControl("FTE_RULESFTE_RULES_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_FROM_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_FROM_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TO_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_TO_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_UNITSorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_UNITSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FTESorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_FTESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FULLTIME_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_FULLTIME_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(FTE_RULESRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(FTE_RULESRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.FTE_RULES_InsertHref = "FTE_RULES_maint.aspx"
        FTE_RULESFTE_RULES_Insert.InnerText += item.FTE_RULES_Insert.GetFormattedValue().Replace(vbCrLf,"")
        FTE_RULESFTE_RULES_Insert.HRef = item.FTE_RULES_InsertHref+item.FTE_RULES_InsertHrefParameters.ToString("GET","UNIT", ViewState)
'End Grid Form FTE_RULES BeforeShow tail

'Grid FTE_RULES Bind tail @2-E31F8E2A
    End Sub
'End Grid FTE_RULES Bind tail

'Grid FTE_RULES ItemDataBound event @2-1C99C1FF

    Protected Sub FTE_RULESItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as FTE_RULESItem = CType(e.Item.DataItem,FTE_RULESItem)
        Dim Item as FTE_RULESItem = DataItem
        Dim FormDataSource As FTE_RULESItem() = CType(FTE_RULESRepeater.DataSource, FTE_RULESItem())
        Dim FTE_RULESDataRows As Integer = FormDataSource.Length
        Dim FTE_RULESIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            FTE_RULESCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(FTE_RULESRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, FTE_RULESCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim FTE_RULESFROM_YEAR_LEVEL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("FTE_RULESFROM_YEAR_LEVEL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim FTE_RULESTO_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESTO_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESUNIT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESUNIT"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESFTE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESFTE"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESFULLTIME_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESFULLTIME_FLAG"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.FROM_YEAR_LEVELHref = "FTE_RULES_maint.aspx"
            FTE_RULESFROM_YEAR_LEVEL.HRef = DataItem.FROM_YEAR_LEVELHref & DataItem.FROM_YEAR_LEVELHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim FTE_RULESAlt_FROM_YEAR_LEVEL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("FTE_RULESAlt_FROM_YEAR_LEVEL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim FTE_RULESAlt_TO_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_TO_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESAlt_UNIT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_UNIT"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESAlt_FTE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_FTE"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESAlt_FULLTIME_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_FULLTIME_FLAG"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim FTE_RULESAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("FTE_RULESAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_FROM_YEAR_LEVELHref = "FTE_RULES_maint.aspx"
            FTE_RULESAlt_FROM_YEAR_LEVEL.HRef = DataItem.Alt_FROM_YEAR_LEVELHref & DataItem.Alt_FROM_YEAR_LEVELHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid FTE_RULES ItemDataBound event

'Grid FTE_RULES ItemDataBound event tail @2-816AA0F0
        If FTE_RULESIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(FTE_RULESCurrentRowNumber, ListItemType.AlternatingItem)
                FTE_RULESRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(FTE_RULESCurrentRowNumber, ListItemType.Item)
                FTE_RULESRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            FTE_RULESItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid FTE_RULES ItemDataBound event tail

'Grid FTE_RULES ItemCommand event @2-AD58C827

    Protected Sub FTE_RULESItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= FTE_RULESRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("FTE_RULESSortDir"),SortDirections) = SortDirections._Asc And ViewState("FTE_RULESSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("FTE_RULESSortDir")=SortDirections._Desc
                Else
                    ViewState("FTE_RULESSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("FTE_RULESSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As FTE_RULESDataProvider.SortFields = 0
            ViewState("FTE_RULESSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("FTE_RULESPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("FTE_RULESPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("FTE_RULESPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("FTE_RULESPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            FTE_RULESBind
        End If
    End Sub
'End Grid FTE_RULES ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-1C8AF766
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FTE_RULES_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        FTE_RULESData = New FTE_RULESDataProvider()
        FTE_RULESOperations = New FormSupportedOperations(False, True, False, False, False)
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

