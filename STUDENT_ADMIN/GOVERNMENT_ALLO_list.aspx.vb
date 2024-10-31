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

Namespace DECV_PROD2007.GOVERNMENT_ALLO_list 'Namespace @1-9855ADA5

'Forms Definition @1-BF4665BD
Public Class [GOVERNMENT_ALLO_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-4617F640
    Protected GOVERNMENT_ALLOWANCEData As GOVERNMENT_ALLOWANCEDataProvider
    Protected GOVERNMENT_ALLOWANCEOperations As FormSupportedOperations
    Protected GOVERNMENT_ALLOWANCECurrentRowNumber As Integer
    Protected GOVERNMENT_ALLO_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-5373FC98
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            GOVERNMENT_ALLOWANCEBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid GOVERNMENT_ALLOWANCE Bind @2-547BE01D

    Protected Sub GOVERNMENT_ALLOWANCEBind()
        If Not GOVERNMENT_ALLOWANCEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"GOVERNMENT_ALLOWANCE",GetType(GOVERNMENT_ALLOWANCEDataProvider.SortFields), 20, 100)
        End If
'End Grid GOVERNMENT_ALLOWANCE Bind

'Grid Form GOVERNMENT_ALLOWANCE BeforeShow tail @2-0393DD28
        GOVERNMENT_ALLOWANCEData.SortField = CType(ViewState("GOVERNMENT_ALLOWANCESortField"),GOVERNMENT_ALLOWANCEDataProvider.SortFields)
        GOVERNMENT_ALLOWANCEData.SortDir = CType(ViewState("GOVERNMENT_ALLOWANCESortDir"),SortDirections)
        GOVERNMENT_ALLOWANCEData.PageNumber = CInt(ViewState("GOVERNMENT_ALLOWANCEPageNumber"))
        GOVERNMENT_ALLOWANCEData.RecordsPerPage = CInt(ViewState("GOVERNMENT_ALLOWANCEPageSize"))
        GOVERNMENT_ALLOWANCERepeater.DataSource = GOVERNMENT_ALLOWANCEData.GetResultSet(PagesCount, GOVERNMENT_ALLOWANCEOperations)
        ViewState("GOVERNMENT_ALLOWANCEPagesCount") = PagesCount
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        GOVERNMENT_ALLOWANCERepeater.DataBind
        FooterIndex = GOVERNMENT_ALLOWANCERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            GOVERNMENT_ALLOWANCERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim GOVERNMENT_ALLOWANCEGOVERNMENT_ALLOWANCE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(FooterIndex).FindControl("GOVERNMENT_ALLOWANCEGOVERNMENT_ALLOWANCE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_ALLOWANCE_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(0).FindControl("Sorter_ALLOWANCE_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ALLOWANCE_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(0).FindControl("Sorter_ALLOWANCE_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ALLOWANCE_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(0).FindControl("Sorter_ALLOWANCE_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(GOVERNMENT_ALLOWANCERepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.GOVERNMENT_ALLOWANCE_InsertHref = "GOVERNMENT_ALLO_maint.aspx"
        GOVERNMENT_ALLOWANCEGOVERNMENT_ALLOWANCE_Insert.InnerText += item.GOVERNMENT_ALLOWANCE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        GOVERNMENT_ALLOWANCEGOVERNMENT_ALLOWANCE_Insert.HRef = item.GOVERNMENT_ALLOWANCE_InsertHref+item.GOVERNMENT_ALLOWANCE_InsertHrefParameters.ToString("GET","ALLOWANCE_CODE", ViewState)
'End Grid Form GOVERNMENT_ALLOWANCE BeforeShow tail

'Grid GOVERNMENT_ALLOWANCE Bind tail @2-E31F8E2A
    End Sub
'End Grid GOVERNMENT_ALLOWANCE Bind tail

'Grid GOVERNMENT_ALLOWANCE ItemDataBound event @2-C2EEA03C

    Protected Sub GOVERNMENT_ALLOWANCEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as GOVERNMENT_ALLOWANCEItem = CType(e.Item.DataItem,GOVERNMENT_ALLOWANCEItem)
        Dim Item as GOVERNMENT_ALLOWANCEItem = DataItem
        Dim FormDataSource As GOVERNMENT_ALLOWANCEItem() = CType(GOVERNMENT_ALLOWANCERepeater.DataSource, GOVERNMENT_ALLOWANCEItem())
        Dim GOVERNMENT_ALLOWANCEDataRows As Integer = FormDataSource.Length
        Dim GOVERNMENT_ALLOWANCEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            GOVERNMENT_ALLOWANCECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(GOVERNMENT_ALLOWANCERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, GOVERNMENT_ALLOWANCECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim GOVERNMENT_ALLOWANCEALLOWANCE_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEALLOWANCE_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim GOVERNMENT_ALLOWANCEALLOWANCE_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEALLOWANCE_TITLE"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.ALLOWANCE_CODEHref = "GOVERNMENT_ALLO_maint.aspx"
            GOVERNMENT_ALLOWANCEALLOWANCE_CODE.HRef = DataItem.ALLOWANCE_CODEHref & DataItem.ALLOWANCE_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_TITLE"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GOVERNMENT_ALLOWANCEAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_ALLOWANCE_CODEHref = "GOVERNMENT_ALLO_maint.aspx"
            GOVERNMENT_ALLOWANCEAlt_ALLOWANCE_CODE.HRef = DataItem.Alt_ALLOWANCE_CODEHref & DataItem.Alt_ALLOWANCE_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid GOVERNMENT_ALLOWANCE ItemDataBound event

'Grid GOVERNMENT_ALLOWANCE ItemDataBound event tail @2-26EF8BC3
        If GOVERNMENT_ALLOWANCEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(GOVERNMENT_ALLOWANCECurrentRowNumber, ListItemType.AlternatingItem)
                GOVERNMENT_ALLOWANCERepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(GOVERNMENT_ALLOWANCECurrentRowNumber, ListItemType.Item)
                GOVERNMENT_ALLOWANCERepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            GOVERNMENT_ALLOWANCEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid GOVERNMENT_ALLOWANCE ItemDataBound event tail

'Grid GOVERNMENT_ALLOWANCE ItemCommand event @2-44AFC428

    Protected Sub GOVERNMENT_ALLOWANCEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= GOVERNMENT_ALLOWANCERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("GOVERNMENT_ALLOWANCESortDir"),SortDirections) = SortDirections._Asc And ViewState("GOVERNMENT_ALLOWANCESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("GOVERNMENT_ALLOWANCESortDir")=SortDirections._Desc
                Else
                    ViewState("GOVERNMENT_ALLOWANCESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("GOVERNMENT_ALLOWANCESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As GOVERNMENT_ALLOWANCEDataProvider.SortFields = 0
            ViewState("GOVERNMENT_ALLOWANCESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("GOVERNMENT_ALLOWANCEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("GOVERNMENT_ALLOWANCEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("GOVERNMENT_ALLOWANCEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("GOVERNMENT_ALLOWANCEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            GOVERNMENT_ALLOWANCEBind
        End If
    End Sub
'End Grid GOVERNMENT_ALLOWANCE ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-AFF65613
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        GOVERNMENT_ALLO_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        GOVERNMENT_ALLOWANCEData = New GOVERNMENT_ALLOWANCEDataProvider()
        GOVERNMENT_ALLOWANCEOperations = New FormSupportedOperations(False, True, False, False, False)
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

