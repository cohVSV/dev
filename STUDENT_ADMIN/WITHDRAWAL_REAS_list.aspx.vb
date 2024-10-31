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

Namespace DECV_PROD2007.WITHDRAWAL_REAS_list 'Namespace @1-41CA5A2F

'Forms Definition @1-FCEF943A
Public Class [WITHDRAWAL_REAS_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-228612BF
    Protected WITHDRAWAL_REASONData As WITHDRAWAL_REASONDataProvider
    Protected WITHDRAWAL_REASONOperations As FormSupportedOperations
    Protected WITHDRAWAL_REASONCurrentRowNumber As Integer
    Protected WITHDRAWAL_REAS_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-0B413279
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            WITHDRAWAL_REASONBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid WITHDRAWAL_REASON Bind @2-2A61F396

    Protected Sub WITHDRAWAL_REASONBind()
        If Not WITHDRAWAL_REASONOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"WITHDRAWAL_REASON",GetType(WITHDRAWAL_REASONDataProvider.SortFields), 20, 100)
        End If
'End Grid WITHDRAWAL_REASON Bind

'Grid Form WITHDRAWAL_REASON BeforeShow tail @2-10A805CA
        WITHDRAWAL_REASONData.SortField = CType(ViewState("WITHDRAWAL_REASONSortField"),WITHDRAWAL_REASONDataProvider.SortFields)
        WITHDRAWAL_REASONData.SortDir = CType(ViewState("WITHDRAWAL_REASONSortDir"),SortDirections)
        WITHDRAWAL_REASONData.PageNumber = CInt(ViewState("WITHDRAWAL_REASONPageNumber"))
        WITHDRAWAL_REASONData.RecordsPerPage = CInt(ViewState("WITHDRAWAL_REASONPageSize"))
        WITHDRAWAL_REASONRepeater.DataSource = WITHDRAWAL_REASONData.GetResultSet(PagesCount, WITHDRAWAL_REASONOperations)
        ViewState("WITHDRAWAL_REASONPagesCount") = PagesCount
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        WITHDRAWAL_REASONRepeater.DataBind
        FooterIndex = WITHDRAWAL_REASONRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            WITHDRAWAL_REASONRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim WITHDRAWAL_REASONWITHDRAWAL_REASON_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(WITHDRAWAL_REASONRepeater.Controls(FooterIndex).FindControl("WITHDRAWAL_REASONWITHDRAWAL_REASON_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_WITHDRAWAL_REASON_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_REASONRepeater.Controls(0).FindControl("Sorter_WITHDRAWAL_REASON_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_WITHDRAWAL_REASONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_REASONRepeater.Controls(0).FindControl("Sorter_WITHDRAWAL_REASONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_REASONRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_REASONRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_REASONRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(WITHDRAWAL_REASONRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.WITHDRAWAL_REASON_InsertHref = "WITHDRAWAL_REAS_maint.aspx"
        WITHDRAWAL_REASONWITHDRAWAL_REASON_Insert.InnerText += item.WITHDRAWAL_REASON_Insert.GetFormattedValue().Replace(vbCrLf,"")
        WITHDRAWAL_REASONWITHDRAWAL_REASON_Insert.HRef = item.WITHDRAWAL_REASON_InsertHref+item.WITHDRAWAL_REASON_InsertHrefParameters.ToString("GET","WITHDRAWAL_REASON_ID", ViewState)
'End Grid Form WITHDRAWAL_REASON BeforeShow tail

'Grid WITHDRAWAL_REASON Bind tail @2-E31F8E2A
    End Sub
'End Grid WITHDRAWAL_REASON Bind tail

'Grid WITHDRAWAL_REASON ItemDataBound event @2-694DB76F

    Protected Sub WITHDRAWAL_REASONItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as WITHDRAWAL_REASONItem = CType(e.Item.DataItem,WITHDRAWAL_REASONItem)
        Dim Item as WITHDRAWAL_REASONItem = DataItem
        Dim FormDataSource As WITHDRAWAL_REASONItem() = CType(WITHDRAWAL_REASONRepeater.DataSource, WITHDRAWAL_REASONItem())
        Dim WITHDRAWAL_REASONDataRows As Integer = FormDataSource.Length
        Dim WITHDRAWAL_REASONIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            WITHDRAWAL_REASONCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(WITHDRAWAL_REASONRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, WITHDRAWAL_REASONCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim WITHDRAWAL_REASONWITHDRAWAL_REASON_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONWITHDRAWAL_REASON_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim WITHDRAWAL_REASONWITHDRAWAL_REASON As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONWITHDRAWAL_REASON"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONSTATUS"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.WITHDRAWAL_REASON_IDHref = "WITHDRAWAL_REAS_maint.aspx"
            WITHDRAWAL_REASONWITHDRAWAL_REASON_ID.HRef = DataItem.WITHDRAWAL_REASON_IDHref & DataItem.WITHDRAWAL_REASON_IDHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_REASONAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_REASONAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_WITHDRAWAL_REASON_IDHref = "WITHDRAWAL_REAS_maint.aspx"
            WITHDRAWAL_REASONAlt_WITHDRAWAL_REASON_ID.HRef = DataItem.Alt_WITHDRAWAL_REASON_IDHref & DataItem.Alt_WITHDRAWAL_REASON_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid WITHDRAWAL_REASON ItemDataBound event

'Grid WITHDRAWAL_REASON ItemDataBound event tail @2-62D72ECD
        If WITHDRAWAL_REASONIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(WITHDRAWAL_REASONCurrentRowNumber, ListItemType.AlternatingItem)
                WITHDRAWAL_REASONRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(WITHDRAWAL_REASONCurrentRowNumber, ListItemType.Item)
                WITHDRAWAL_REASONRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            WITHDRAWAL_REASONItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid WITHDRAWAL_REASON ItemDataBound event tail

'Grid WITHDRAWAL_REASON ItemCommand event @2-1F8BC44D

    Protected Sub WITHDRAWAL_REASONItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= WITHDRAWAL_REASONRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("WITHDRAWAL_REASONSortDir"),SortDirections) = SortDirections._Asc And ViewState("WITHDRAWAL_REASONSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("WITHDRAWAL_REASONSortDir")=SortDirections._Desc
                Else
                    ViewState("WITHDRAWAL_REASONSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("WITHDRAWAL_REASONSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As WITHDRAWAL_REASONDataProvider.SortFields = 0
            ViewState("WITHDRAWAL_REASONSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("WITHDRAWAL_REASONPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("WITHDRAWAL_REASONPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("WITHDRAWAL_REASONPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("WITHDRAWAL_REASONPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            WITHDRAWAL_REASONBind
        End If
    End Sub
'End Grid WITHDRAWAL_REASON ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-433D1B14
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        WITHDRAWAL_REAS_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        WITHDRAWAL_REASONData = New WITHDRAWAL_REASONDataProvider()
        WITHDRAWAL_REASONOperations = New FormSupportedOperations(False, True, False, False, False)
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

