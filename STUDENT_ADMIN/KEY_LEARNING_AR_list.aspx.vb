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

Namespace DECV_PROD2007.KEY_LEARNING_AR_list 'Namespace @1-EC1B6ACF

'Forms Definition @1-4B221A8C
Public Class [KEY_LEARNING_AR_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-4E520566
    Protected KEY_LEARNING_AREAData As KEY_LEARNING_AREADataProvider
    Protected KEY_LEARNING_AREAOperations As FormSupportedOperations
    Protected KEY_LEARNING_AREACurrentRowNumber As Integer
    Protected KEY_LEARNING_AR_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E0C882BB
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            KEY_LEARNING_AREABind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid KEY_LEARNING_AREA Bind @2-391E0193

    Protected Sub KEY_LEARNING_AREABind()
        If Not KEY_LEARNING_AREAOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"KEY_LEARNING_AREA",GetType(KEY_LEARNING_AREADataProvider.SortFields), 20, 100)
        End If
'End Grid KEY_LEARNING_AREA Bind

'Grid Form KEY_LEARNING_AREA BeforeShow tail @2-9D025F43
        KEY_LEARNING_AREAData.SortField = CType(ViewState("KEY_LEARNING_AREASortField"),KEY_LEARNING_AREADataProvider.SortFields)
        KEY_LEARNING_AREAData.SortDir = CType(ViewState("KEY_LEARNING_AREASortDir"),SortDirections)
        KEY_LEARNING_AREAData.PageNumber = CInt(ViewState("KEY_LEARNING_AREAPageNumber"))
        KEY_LEARNING_AREAData.RecordsPerPage = CInt(ViewState("KEY_LEARNING_AREAPageSize"))
        KEY_LEARNING_AREARepeater.DataSource = KEY_LEARNING_AREAData.GetResultSet(PagesCount, KEY_LEARNING_AREAOperations)
        ViewState("KEY_LEARNING_AREAPagesCount") = PagesCount
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        KEY_LEARNING_AREARepeater.DataBind
        FooterIndex = KEY_LEARNING_AREARepeater.Controls.Count - 1
        If PagesCount = 0 Then
            KEY_LEARNING_AREARepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim KEY_LEARNING_AREAKEY_LEARNING_AREA_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(KEY_LEARNING_AREARepeater.Controls(FooterIndex).FindControl("KEY_LEARNING_AREAKEY_LEARNING_AREA_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_KLA_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(KEY_LEARNING_AREARepeater.Controls(0).FindControl("Sorter_KLA_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_KEY_LEARNING_AREASorter As DECV_PROD2007.Controls.Sorter = DirectCast(KEY_LEARNING_AREARepeater.Controls(0).FindControl("Sorter_KEY_LEARNING_AREASorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(KEY_LEARNING_AREARepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(KEY_LEARNING_AREARepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(KEY_LEARNING_AREARepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(KEY_LEARNING_AREARepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.KEY_LEARNING_AREA_InsertHref = "KEY_LEARNING_AR_maint.aspx"
        KEY_LEARNING_AREAKEY_LEARNING_AREA_Insert.InnerText += item.KEY_LEARNING_AREA_Insert.GetFormattedValue().Replace(vbCrLf,"")
        KEY_LEARNING_AREAKEY_LEARNING_AREA_Insert.HRef = item.KEY_LEARNING_AREA_InsertHref+item.KEY_LEARNING_AREA_InsertHrefParameters.ToString("GET","KLA_ID", ViewState)
'End Grid Form KEY_LEARNING_AREA BeforeShow tail

'Grid KEY_LEARNING_AREA Bind tail @2-E31F8E2A
    End Sub
'End Grid KEY_LEARNING_AREA Bind tail

'Grid KEY_LEARNING_AREA ItemDataBound event @2-0DE8EA68

    Protected Sub KEY_LEARNING_AREAItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as KEY_LEARNING_AREAItem = CType(e.Item.DataItem,KEY_LEARNING_AREAItem)
        Dim Item as KEY_LEARNING_AREAItem = DataItem
        Dim FormDataSource As KEY_LEARNING_AREAItem() = CType(KEY_LEARNING_AREARepeater.DataSource, KEY_LEARNING_AREAItem())
        Dim KEY_LEARNING_AREADataRows As Integer = FormDataSource.Length
        Dim KEY_LEARNING_AREAIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            KEY_LEARNING_AREACurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(KEY_LEARNING_AREARepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, KEY_LEARNING_AREACurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim KEY_LEARNING_AREAKLA_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAKLA_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim KEY_LEARNING_AREAKEY_LEARNING_AREA As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAKEY_LEARNING_AREA"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREASTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREASTATUS"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREALAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREALAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREALAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREALAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.KLA_IDHref = "KEY_LEARNING_AR_maint.aspx"
            KEY_LEARNING_AREAKLA_ID.HRef = DataItem.KLA_IDHref & DataItem.KLA_IDHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim KEY_LEARNING_AREAAlt_KLA_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAAlt_KLA_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim KEY_LEARNING_AREAAlt_KEY_LEARNING_AREA As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAAlt_KEY_LEARNING_AREA"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREAAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREAAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim KEY_LEARNING_AREAAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("KEY_LEARNING_AREAAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_KLA_IDHref = "KEY_LEARNING_AR_maint.aspx"
            KEY_LEARNING_AREAAlt_KLA_ID.HRef = DataItem.Alt_KLA_IDHref & DataItem.Alt_KLA_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid KEY_LEARNING_AREA ItemDataBound event

'Grid KEY_LEARNING_AREA ItemDataBound event tail @2-991BD10F
        If KEY_LEARNING_AREAIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(KEY_LEARNING_AREACurrentRowNumber, ListItemType.AlternatingItem)
                KEY_LEARNING_AREARepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(KEY_LEARNING_AREACurrentRowNumber, ListItemType.Item)
                KEY_LEARNING_AREARepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            KEY_LEARNING_AREAItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid KEY_LEARNING_AREA ItemDataBound event tail

'Grid KEY_LEARNING_AREA ItemCommand event @2-C1A9F169

    Protected Sub KEY_LEARNING_AREAItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= KEY_LEARNING_AREARepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("KEY_LEARNING_AREASortDir"),SortDirections) = SortDirections._Asc And ViewState("KEY_LEARNING_AREASortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("KEY_LEARNING_AREASortDir")=SortDirections._Desc
                Else
                    ViewState("KEY_LEARNING_AREASortDir")=SortDirections._Asc
                End If
            Else
                ViewState("KEY_LEARNING_AREASortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As KEY_LEARNING_AREADataProvider.SortFields = 0
            ViewState("KEY_LEARNING_AREASortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("KEY_LEARNING_AREAPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("KEY_LEARNING_AREAPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("KEY_LEARNING_AREAPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("KEY_LEARNING_AREAPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            KEY_LEARNING_AREABind
        End If
    End Sub
'End Grid KEY_LEARNING_AREA ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-CC3E4A85
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        KEY_LEARNING_AR_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        KEY_LEARNING_AREAData = New KEY_LEARNING_AREADataProvider()
        KEY_LEARNING_AREAOperations = New FormSupportedOperations(False, True, False, False, False)
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

