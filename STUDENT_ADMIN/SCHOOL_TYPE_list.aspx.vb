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

Namespace DECV_PROD2007.SCHOOL_TYPE_list 'Namespace @1-D5F5CBEB

'Forms Definition @1-FE4D302E
Public Class [SCHOOL_TYPE_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-0088F275
    Protected SCHOOL_TYPEData As SCHOOL_TYPEDataProvider
    Protected SCHOOL_TYPEOperations As FormSupportedOperations
    Protected SCHOOL_TYPECurrentRowNumber As Integer
    Protected SCHOOL_TYPE_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-C43D7510
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SCHOOL_TYPEBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SCHOOL_TYPE Bind @2-DC3A9EB8

    Protected Sub SCHOOL_TYPEBind()
        If Not SCHOOL_TYPEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SCHOOL_TYPE",GetType(SCHOOL_TYPEDataProvider.SortFields), 20, 100)
        End If
'End Grid SCHOOL_TYPE Bind

'Grid Form SCHOOL_TYPE BeforeShow tail @2-964772CD
        SCHOOL_TYPEData.SortField = CType(ViewState("SCHOOL_TYPESortField"),SCHOOL_TYPEDataProvider.SortFields)
        SCHOOL_TYPEData.SortDir = CType(ViewState("SCHOOL_TYPESortDir"),SortDirections)
        SCHOOL_TYPEData.PageNumber = CInt(ViewState("SCHOOL_TYPEPageNumber"))
        SCHOOL_TYPEData.RecordsPerPage = CInt(ViewState("SCHOOL_TYPEPageSize"))
        SCHOOL_TYPERepeater.DataSource = SCHOOL_TYPEData.GetResultSet(PagesCount, SCHOOL_TYPEOperations)
        ViewState("SCHOOL_TYPEPagesCount") = PagesCount
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        SCHOOL_TYPERepeater.DataBind
        FooterIndex = SCHOOL_TYPERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SCHOOL_TYPERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim SCHOOL_TYPESCHOOL_TYPE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(SCHOOL_TYPERepeater.Controls(FooterIndex).FindControl("SCHOOL_TYPESCHOOL_TYPE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_SCHOOL_TYPE_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOL_TYPERepeater.Controls(0).FindControl("Sorter_SCHOOL_TYPE_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCHOOL_TYPE_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOL_TYPERepeater.Controls(0).FindControl("Sorter_SCHOOL_TYPE_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOL_TYPERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOL_TYPERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(SCHOOL_TYPERepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.SCHOOL_TYPE_InsertHref = "SCHOOL_TYPE_maint.aspx"
        SCHOOL_TYPESCHOOL_TYPE_Insert.InnerText += item.SCHOOL_TYPE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        SCHOOL_TYPESCHOOL_TYPE_Insert.HRef = item.SCHOOL_TYPE_InsertHref+item.SCHOOL_TYPE_InsertHrefParameters.ToString("GET","SCHOOL_TYPE_CODE", ViewState)
'End Grid Form SCHOOL_TYPE BeforeShow tail

'Grid SCHOOL_TYPE Bind tail @2-E31F8E2A
    End Sub
'End Grid SCHOOL_TYPE Bind tail

'Grid SCHOOL_TYPE ItemDataBound event @2-62F17A71

    Protected Sub SCHOOL_TYPEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SCHOOL_TYPEItem = CType(e.Item.DataItem,SCHOOL_TYPEItem)
        Dim Item as SCHOOL_TYPEItem = DataItem
        Dim FormDataSource As SCHOOL_TYPEItem() = CType(SCHOOL_TYPERepeater.DataSource, SCHOOL_TYPEItem())
        Dim SCHOOL_TYPEDataRows As Integer = FormDataSource.Length
        Dim SCHOOL_TYPEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SCHOOL_TYPECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SCHOOL_TYPERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SCHOOL_TYPECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim SCHOOL_TYPESCHOOL_TYPE_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCHOOL_TYPESCHOOL_TYPE_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim SCHOOL_TYPELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim SCHOOL_TYPELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.SCHOOL_TYPE_CODEHref = "SCHOOL_TYPE_maint.aspx"
            SCHOOL_TYPESCHOOL_TYPE_CODE.HRef = DataItem.SCHOOL_TYPE_CODEHref & DataItem.SCHOOL_TYPE_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SCHOOL_TYPEAlt_SCHOOL_TYPE_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCHOOL_TYPEAlt_SCHOOL_TYPE_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SCHOOL_TYPEAlt_SCHOOL_TYPE_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPEAlt_SCHOOL_TYPE_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim SCHOOL_TYPEAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPEAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim SCHOOL_TYPEAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOL_TYPEAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_SCHOOL_TYPE_CODEHref = "SCHOOL_TYPE_maint.aspx"
            SCHOOL_TYPEAlt_SCHOOL_TYPE_CODE.HRef = DataItem.Alt_SCHOOL_TYPE_CODEHref & DataItem.Alt_SCHOOL_TYPE_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid SCHOOL_TYPE ItemDataBound event

'Grid SCHOOL_TYPE ItemDataBound event tail @2-E68ADEDD
        If SCHOOL_TYPEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(SCHOOL_TYPECurrentRowNumber, ListItemType.AlternatingItem)
                SCHOOL_TYPERepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(SCHOOL_TYPECurrentRowNumber, ListItemType.Item)
                SCHOOL_TYPERepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            SCHOOL_TYPEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SCHOOL_TYPE ItemDataBound event tail

'Grid SCHOOL_TYPE ItemCommand event @2-CD918216

    Protected Sub SCHOOL_TYPEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SCHOOL_TYPERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SCHOOL_TYPESortDir"),SortDirections) = SortDirections._Asc And ViewState("SCHOOL_TYPESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SCHOOL_TYPESortDir")=SortDirections._Desc
                Else
                    ViewState("SCHOOL_TYPESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SCHOOL_TYPESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SCHOOL_TYPEDataProvider.SortFields = 0
            ViewState("SCHOOL_TYPESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SCHOOL_TYPEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SCHOOL_TYPEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SCHOOL_TYPEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SCHOOL_TYPEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SCHOOL_TYPEBind
        End If
    End Sub
'End Grid SCHOOL_TYPE ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-6BAD3DD2
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SCHOOL_TYPE_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOL_TYPEData = New SCHOOL_TYPEDataProvider()
        SCHOOL_TYPEOperations = New FormSupportedOperations(False, True, False, False, False)
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

