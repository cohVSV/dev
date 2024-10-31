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

Namespace DECV_PROD2007.ENROLMENT_CATEG_list 'Namespace @1-91BC5E68

'Forms Definition @1-A75578B4
Public Class [ENROLMENT_CATEG_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-7C2302A9
    Protected ENROLMENT_CATEGORYData As ENROLMENT_CATEGORYDataProvider
    Protected ENROLMENT_CATEGORYOperations As FormSupportedOperations
    Protected ENROLMENT_CATEGORYCurrentRowNumber As Integer
    Protected ENROLMENT_CATEG_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B3C1E733
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.link_addnewsubcategoryHref = "ENROLMENT_CATEG_maint.aspx"
            PageData.FillItem(item)
            link_addnewsubcategory.InnerText += item.link_addnewsubcategory.GetFormattedValue().Replace(vbCrLf,"")
            link_addnewsubcategory.HRef = item.link_addnewsubcategoryHref+item.link_addnewsubcategoryHrefParameters.ToString("GET","SUBCATEGORY_CODE;CATEGORY_CODE", ViewState)
            link_addnewsubcategory.DataBind()
            ENROLMENT_CATEGORYBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid ENROLMENT_CATEGORY Bind @2-F631295E

    Protected Sub ENROLMENT_CATEGORYBind()
        If Not ENROLMENT_CATEGORYOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ENROLMENT_CATEGORY",GetType(ENROLMENT_CATEGORYDataProvider.SortFields), 40, 100)
        End If
'End Grid ENROLMENT_CATEGORY Bind

'Grid Form ENROLMENT_CATEGORY BeforeShow tail @2-E29812CC
        ENROLMENT_CATEGORYData.SortField = CType(ViewState("ENROLMENT_CATEGORYSortField"),ENROLMENT_CATEGORYDataProvider.SortFields)
        ENROLMENT_CATEGORYData.SortDir = CType(ViewState("ENROLMENT_CATEGORYSortDir"),SortDirections)
        ENROLMENT_CATEGORYData.PageNumber = CInt(ViewState("ENROLMENT_CATEGORYPageNumber"))
        ENROLMENT_CATEGORYData.RecordsPerPage = CInt(ViewState("ENROLMENT_CATEGORYPageSize"))
        ENROLMENT_CATEGORYRepeater.DataSource = ENROLMENT_CATEGORYData.GetResultSet(PagesCount, ENROLMENT_CATEGORYOperations)
        ViewState("ENROLMENT_CATEGORYPagesCount") = PagesCount
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        ENROLMENT_CATEGORYRepeater.DataBind
        FooterIndex = ENROLMENT_CATEGORYRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            ENROLMENT_CATEGORYRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim ENROLMENT_CATEGORYENROLMENT_CATEGORY_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(FooterIndex).FindControl("ENROLMENT_CATEGORYENROLMENT_CATEGORY_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_CATEGORY_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_CATEGORY_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBCATEGORY_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_SUBCATEGORY_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBCATEGORY_FULL_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_SUBCATEGORY_FULL_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ENROLMENT_CATEGORYRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.ENROLMENT_CATEGORY_InsertHref = "ENROLMENT_CATEG_maint.aspx"
        ENROLMENT_CATEGORYENROLMENT_CATEGORY_Insert.InnerText += item.ENROLMENT_CATEGORY_Insert.GetFormattedValue().Replace(vbCrLf,"")
        ENROLMENT_CATEGORYENROLMENT_CATEGORY_Insert.HRef = item.ENROLMENT_CATEGORY_InsertHref+item.ENROLMENT_CATEGORY_InsertHrefParameters.ToString("GET","SUBCATEGORY_CODE;CATEGORY_CODE", ViewState)
'End Grid Form ENROLMENT_CATEGORY BeforeShow tail

'Grid ENROLMENT_CATEGORY Bind tail @2-E31F8E2A
    End Sub
'End Grid ENROLMENT_CATEGORY Bind tail

'Grid ENROLMENT_CATEGORY ItemDataBound event @2-BA311947

    Protected Sub ENROLMENT_CATEGORYItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ENROLMENT_CATEGORYItem = CType(e.Item.DataItem,ENROLMENT_CATEGORYItem)
        Dim Item as ENROLMENT_CATEGORYItem = DataItem
        Dim FormDataSource As ENROLMENT_CATEGORYItem() = CType(ENROLMENT_CATEGORYRepeater.DataSource, ENROLMENT_CATEGORYItem())
        Dim ENROLMENT_CATEGORYDataRows As Integer = FormDataSource.Length
        Dim ENROLMENT_CATEGORYIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ENROLMENT_CATEGORYCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ENROLMENT_CATEGORYRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ENROLMENT_CATEGORYCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim ENROLMENT_CATEGORYCATEGORY_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYCATEGORY_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim ENROLMENT_CATEGORYSUBCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYSUBCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYSTATUS"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.CATEGORY_CODEHref = "ENROLMENT_CATEG_maint.aspx"
            ENROLMENT_CATEGORYCATEGORY_CODE.HRef = DataItem.CATEGORY_CODEHref & DataItem.CATEGORY_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ENROLMENT_CATEGORYAlt_CATEGORY_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_CATEGORY_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim ENROLMENT_CATEGORYAlt_SUBCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_SUBCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYAlt_SUBCATEGORY_FULL_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_SUBCATEGORY_FULL_TITLE"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ENROLMENT_CATEGORYAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROLMENT_CATEGORYAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_CATEGORY_CODEHref = "ENROLMENT_CATEG_maint.aspx"
            ENROLMENT_CATEGORYAlt_CATEGORY_CODE.HRef = DataItem.Alt_CATEGORY_CODEHref & DataItem.Alt_CATEGORY_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid ENROLMENT_CATEGORY ItemDataBound event

'Grid ENROLMENT_CATEGORY ItemDataBound event tail @2-93CFAC9C
        If ENROLMENT_CATEGORYIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(ENROLMENT_CATEGORYCurrentRowNumber, ListItemType.AlternatingItem)
                ENROLMENT_CATEGORYRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(ENROLMENT_CATEGORYCurrentRowNumber, ListItemType.Item)
                ENROLMENT_CATEGORYRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            ENROLMENT_CATEGORYItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ENROLMENT_CATEGORY ItemDataBound event tail

'Grid ENROLMENT_CATEGORY ItemCommand event @2-F5CAEADF

    Protected Sub ENROLMENT_CATEGORYItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ENROLMENT_CATEGORYRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ENROLMENT_CATEGORYSortDir"),SortDirections) = SortDirections._Asc And ViewState("ENROLMENT_CATEGORYSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ENROLMENT_CATEGORYSortDir")=SortDirections._Desc
                Else
                    ViewState("ENROLMENT_CATEGORYSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ENROLMENT_CATEGORYSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ENROLMENT_CATEGORYDataProvider.SortFields = 0
            ViewState("ENROLMENT_CATEGORYSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ENROLMENT_CATEGORYPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ENROLMENT_CATEGORYPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ENROLMENT_CATEGORYPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ENROLMENT_CATEGORYPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ENROLMENT_CATEGORYBind
        End If
    End Sub
'End Grid ENROLMENT_CATEGORY ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-46B3528A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ENROLMENT_CATEG_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ENROLMENT_CATEGORYData = New ENROLMENT_CATEGORYDataProvider()
        ENROLMENT_CATEGORYOperations = New FormSupportedOperations(False, True, False, False, False)
        If Not(User.Identity.IsAuthenticated) Then
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

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

