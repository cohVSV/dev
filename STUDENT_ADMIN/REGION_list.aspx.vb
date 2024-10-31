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

Namespace DECV_PROD2007.REGION_list 'Namespace @1-639AF3B4

'Forms Definition @1-0023CA84
Public Class [REGION_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C7C63203
    Protected REGIONData As REGIONDataProvider
    Protected REGIONOperations As FormSupportedOperations
    Protected REGIONCurrentRowNumber As Integer
    Protected REGION_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-88A0EFFE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            REGIONBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid REGION Bind @2-BE32D263

    Protected Sub REGIONBind()
        If Not REGIONOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"REGION",GetType(REGIONDataProvider.SortFields), 20, 100)
        End If
'End Grid REGION Bind

'Grid Form REGION BeforeShow tail @2-232C04B5
        REGIONData.SortField = CType(ViewState("REGIONSortField"),REGIONDataProvider.SortFields)
        REGIONData.SortDir = CType(ViewState("REGIONSortDir"),SortDirections)
        REGIONData.PageNumber = CInt(ViewState("REGIONPageNumber"))
        REGIONData.RecordsPerPage = CInt(ViewState("REGIONPageSize"))
        REGIONRepeater.DataSource = REGIONData.GetResultSet(PagesCount, REGIONOperations)
        ViewState("REGIONPagesCount") = PagesCount
        Dim item As REGIONItem = New REGIONItem()
        REGIONRepeater.DataBind
        FooterIndex = REGIONRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            REGIONRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim REGIONREGION_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(REGIONRepeater.Controls(FooterIndex).FindControl("REGIONREGION_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_REGION_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_REGION_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_REGION_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_REGION_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FAXSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_FAXSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_EMAIL_ADDRESSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_EMAIL_ADDRESSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBURB_TOWNSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REGIONRepeater.Controls(0).FindControl("Sorter_SUBURB_TOWNSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(REGIONRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.REGION_InsertHref = "REGION_maint.aspx"
        REGIONREGION_Insert.InnerText += item.REGION_Insert.GetFormattedValue().Replace(vbCrLf,"")
        REGIONREGION_Insert.HRef = item.REGION_InsertHref+item.REGION_InsertHrefParameters.ToString("GET","REGION_ID", ViewState)
'End Grid Form REGION BeforeShow tail

'Grid REGION Bind tail @2-E31F8E2A
    End Sub
'End Grid REGION Bind tail

'Grid REGION ItemDataBound event @2-1631C1BD

    Protected Sub REGIONItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as REGIONItem = CType(e.Item.DataItem,REGIONItem)
        Dim Item as REGIONItem = DataItem
        Dim FormDataSource As REGIONItem() = CType(REGIONRepeater.DataSource, REGIONItem())
        Dim REGIONDataRows As Integer = FormDataSource.Length
        Dim REGIONIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            REGIONCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(REGIONRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, REGIONCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim REGIONREGION_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONREGION_NAME"),System.Web.UI.WebControls.Literal)
            Dim REGIONPHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONPHONE"),System.Web.UI.WebControls.Literal)
            Dim REGIONFAX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONFAX"),System.Web.UI.WebControls.Literal)
            Dim REGIONEMAIL_ADDRESS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONEMAIL_ADDRESS"),System.Web.UI.WebControls.Literal)
            Dim REGIONSUBURB_TOWN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONSUBURB_TOWN"),System.Web.UI.WebControls.Literal)
            Dim REGIONSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONSTATUS"),System.Web.UI.WebControls.Literal)
            Dim REGIONREGION_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("REGIONREGION_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim REGIONID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONID"),System.Web.UI.WebControls.Literal)
            DataItem.REGION_IDHref = "REGION_maint.aspx"
            REGIONREGION_ID.HRef = DataItem.REGION_IDHref & DataItem.REGION_IDHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim REGIONAlt_REGION_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONAlt_REGION_NAME"),System.Web.UI.WebControls.Literal)
            Dim REGIONAlt_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONAlt_PHONE"),System.Web.UI.WebControls.Literal)
            Dim REGIONAlt_FAX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONAlt_FAX"),System.Web.UI.WebControls.Literal)
            Dim REGIONAlt_EMAIL_ADDRESS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONAlt_EMAIL_ADDRESS"),System.Web.UI.WebControls.Literal)
            Dim REGIONAlt_SUBURB_TOWN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONAlt_SUBURB_TOWN"),System.Web.UI.WebControls.Literal)
            Dim REGIONSTATUS1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONSTATUS1"),System.Web.UI.WebControls.Literal)
            Dim REGIONAlt_REGION_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("REGIONAlt_REGION_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim REGIONID1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REGIONID1"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_REGION_IDHref = "REGION_maint.aspx"
            REGIONAlt_REGION_ID.HRef = DataItem.Alt_REGION_IDHref & DataItem.Alt_REGION_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid REGION ItemDataBound event

'Grid REGION ItemDataBound event tail @2-0C77D4B1
        If REGIONIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(REGIONCurrentRowNumber, ListItemType.AlternatingItem)
                REGIONRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(REGIONCurrentRowNumber, ListItemType.Item)
                REGIONRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            REGIONItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid REGION ItemDataBound event tail

'Grid REGION ItemCommand event @2-15103028

    Protected Sub REGIONItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= REGIONRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("REGIONSortDir"),SortDirections) = SortDirections._Asc And ViewState("REGIONSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("REGIONSortDir")=SortDirections._Desc
                Else
                    ViewState("REGIONSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("REGIONSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As REGIONDataProvider.SortFields = 0
            ViewState("REGIONSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("REGIONPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("REGIONPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("REGIONPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("REGIONPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            REGIONBind
        End If
    End Sub
'End Grid REGION ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-D8CA6AD2
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        REGION_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        REGIONData = New REGIONDataProvider()
        REGIONOperations = New FormSupportedOperations(False, True, False, False, False)
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

