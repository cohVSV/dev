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

Namespace DECV_PROD2007.PROGRESS_CODE_list 'Namespace @1-EF7E784B

'Forms Definition @1-8D1D9798
Public Class [PROGRESS_CODE_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-40E2A705
    Protected PROGRESS_CODEData As PROGRESS_CODEDataProvider
    Protected PROGRESS_CODEOperations As FormSupportedOperations
    Protected PROGRESS_CODECurrentRowNumber As Integer
    Protected PROGRESS_CODE_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-DCED123C
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            PROGRESS_CODEBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid PROGRESS_CODE Bind @2-DC7146BF

    Protected Sub PROGRESS_CODEBind()
        If Not PROGRESS_CODEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"PROGRESS_CODE",GetType(PROGRESS_CODEDataProvider.SortFields), 20, 100)
        End If
'End Grid PROGRESS_CODE Bind

'Grid Form PROGRESS_CODE BeforeShow tail @2-CB95961B
        PROGRESS_CODEData.SortField = CType(ViewState("PROGRESS_CODESortField"),PROGRESS_CODEDataProvider.SortFields)
        PROGRESS_CODEData.SortDir = CType(ViewState("PROGRESS_CODESortDir"),SortDirections)
        PROGRESS_CODEData.PageNumber = CInt(ViewState("PROGRESS_CODEPageNumber"))
        PROGRESS_CODEData.RecordsPerPage = CInt(ViewState("PROGRESS_CODEPageSize"))
        PROGRESS_CODERepeater.DataSource = PROGRESS_CODEData.GetResultSet(PagesCount, PROGRESS_CODEOperations)
        ViewState("PROGRESS_CODEPagesCount") = PagesCount
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        PROGRESS_CODERepeater.DataBind
        FooterIndex = PROGRESS_CODERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            PROGRESS_CODERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim PROGRESS_CODEPROGRESS_CODE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(PROGRESS_CODERepeater.Controls(FooterIndex).FindControl("PROGRESS_CODEPROGRESS_CODE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_PROGRESS_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(PROGRESS_CODERepeater.Controls(0).FindControl("Sorter_PROGRESS_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PROGRESS_CODE_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(PROGRESS_CODERepeater.Controls(0).FindControl("Sorter_PROGRESS_CODE_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(PROGRESS_CODERepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(PROGRESS_CODERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(PROGRESS_CODERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(PROGRESS_CODERepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.PROGRESS_CODE_InsertHref = "PROGRESS_CODE_maint.aspx"
        PROGRESS_CODEPROGRESS_CODE_Insert.InnerText += item.PROGRESS_CODE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        PROGRESS_CODEPROGRESS_CODE_Insert.HRef = item.PROGRESS_CODE_InsertHref+item.PROGRESS_CODE_InsertHrefParameters.ToString("GET","PROGRESS_CODE", ViewState)
'End Grid Form PROGRESS_CODE BeforeShow tail

'Grid PROGRESS_CODE Bind tail @2-E31F8E2A
    End Sub
'End Grid PROGRESS_CODE Bind tail

'Grid PROGRESS_CODE ItemDataBound event @2-C187600E

    Protected Sub PROGRESS_CODEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as PROGRESS_CODEItem = CType(e.Item.DataItem,PROGRESS_CODEItem)
        Dim Item as PROGRESS_CODEItem = DataItem
        Dim FormDataSource As PROGRESS_CODEItem() = CType(PROGRESS_CODERepeater.DataSource, PROGRESS_CODEItem())
        Dim PROGRESS_CODEDataRows As Integer = FormDataSource.Length
        Dim PROGRESS_CODEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            PROGRESS_CODECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(PROGRESS_CODERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, PROGRESS_CODECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim PROGRESS_CODEPROGRESS_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("PROGRESS_CODEPROGRESS_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim PROGRESS_CODEPROGRESS_CODE_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODEPROGRESS_CODE_TITLE"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODESTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODESTATUS"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.PROGRESS_CODEHref = "PROGRESS_CODE_maint.aspx"
            PROGRESS_CODEPROGRESS_CODE.HRef = DataItem.PROGRESS_CODEHref & DataItem.PROGRESS_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim PROGRESS_CODEAlt_PROGRESS_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("PROGRESS_CODEAlt_PROGRESS_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim PROGRESS_CODEAlt_PROGRESS_CODE_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODEAlt_PROGRESS_CODE_TITLE"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODEAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODEAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODEAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODEAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim PROGRESS_CODEAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("PROGRESS_CODEAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_PROGRESS_CODEHref = "PROGRESS_CODE_maint.aspx"
            PROGRESS_CODEAlt_PROGRESS_CODE.HRef = DataItem.Alt_PROGRESS_CODEHref & DataItem.Alt_PROGRESS_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid PROGRESS_CODE ItemDataBound event

'Grid PROGRESS_CODE ItemDataBound event tail @2-F68D8410
        If PROGRESS_CODEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(PROGRESS_CODECurrentRowNumber, ListItemType.AlternatingItem)
                PROGRESS_CODERepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(PROGRESS_CODECurrentRowNumber, ListItemType.Item)
                PROGRESS_CODERepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            PROGRESS_CODEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid PROGRESS_CODE ItemDataBound event tail

'Grid PROGRESS_CODE ItemCommand event @2-E3C5CD77

    Protected Sub PROGRESS_CODEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= PROGRESS_CODERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("PROGRESS_CODESortDir"),SortDirections) = SortDirections._Asc And ViewState("PROGRESS_CODESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("PROGRESS_CODESortDir")=SortDirections._Desc
                Else
                    ViewState("PROGRESS_CODESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("PROGRESS_CODESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As PROGRESS_CODEDataProvider.SortFields = 0
            ViewState("PROGRESS_CODESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("PROGRESS_CODEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("PROGRESS_CODEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("PROGRESS_CODEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("PROGRESS_CODEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            PROGRESS_CODEBind
        End If
    End Sub
'End Grid PROGRESS_CODE ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F868E66E
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        PROGRESS_CODE_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        PROGRESS_CODEData = New PROGRESS_CODEDataProvider()
        PROGRESS_CODEOperations = New FormSupportedOperations(False, True, False, False, False)
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

