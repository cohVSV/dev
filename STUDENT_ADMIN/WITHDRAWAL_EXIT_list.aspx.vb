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

Namespace DECV_PROD2007.WITHDRAWAL_EXIT_list 'Namespace @1-403F2FB2

'Forms Definition @1-EBFB6A76
Public Class [WITHDRAWAL_EXIT_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-D5C9CCED
    Protected WITHDRAWAL_EXIT_DESTINATIData As WITHDRAWAL_EXIT_DESTINATIDataProvider
    Protected WITHDRAWAL_EXIT_DESTINATIOperations As FormSupportedOperations
    Protected WITHDRAWAL_EXIT_DESTINATICurrentRowNumber As Integer
    Protected WITHDRAWAL_EXIT_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-10530C43
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_AddNewHref = "WITHDRAWAL_EXIT_maint.aspx"
            PageData.FillItem(item)
            Link_AddNew.InnerText += item.Link_AddNew.GetFormattedValue().Replace(vbCrLf,"")
            Link_AddNew.HRef = item.Link_AddNewHref+item.Link_AddNewHrefParameters.ToString("GET","WD_DEST_ID", ViewState)
            Link_AddNew.DataBind()
            WITHDRAWAL_EXIT_DESTINATIBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid WITHDRAWAL_EXIT_DESTINATI Bind @2-910087B9

    Protected Sub WITHDRAWAL_EXIT_DESTINATIBind()
        If Not WITHDRAWAL_EXIT_DESTINATIOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"WITHDRAWAL_EXIT_DESTINATI",GetType(WITHDRAWAL_EXIT_DESTINATIDataProvider.SortFields), 40, 100)
        End If
'End Grid WITHDRAWAL_EXIT_DESTINATI Bind

'Grid Form WITHDRAWAL_EXIT_DESTINATI BeforeShow tail @2-A0B81197
        WITHDRAWAL_EXIT_DESTINATIData.SortField = CType(ViewState("WITHDRAWAL_EXIT_DESTINATISortField"),WITHDRAWAL_EXIT_DESTINATIDataProvider.SortFields)
        WITHDRAWAL_EXIT_DESTINATIData.SortDir = CType(ViewState("WITHDRAWAL_EXIT_DESTINATISortDir"),SortDirections)
        WITHDRAWAL_EXIT_DESTINATIData.PageNumber = CInt(ViewState("WITHDRAWAL_EXIT_DESTINATIPageNumber"))
        WITHDRAWAL_EXIT_DESTINATIData.RecordsPerPage = CInt(ViewState("WITHDRAWAL_EXIT_DESTINATIPageSize"))
        WITHDRAWAL_EXIT_DESTINATIRepeater.DataSource = WITHDRAWAL_EXIT_DESTINATIData.GetResultSet(PagesCount, WITHDRAWAL_EXIT_DESTINATIOperations)
        ViewState("WITHDRAWAL_EXIT_DESTINATIPagesCount") = PagesCount
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        WITHDRAWAL_EXIT_DESTINATIRepeater.DataBind
        FooterIndex = WITHDRAWAL_EXIT_DESTINATIRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim WITHDRAWAL_EXIT_DESTINATIWITHDRAWAL_EXIT_DESTINATI_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(FooterIndex).FindControl("WITHDRAWAL_EXIT_DESTINATIWITHDRAWAL_EXIT_DESTINATI_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_WD_DEST_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_WD_DEST_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_EXIT_DESTINATION_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_EXIT_DESTINATION_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DISPLAY_ORDERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_DISPLAY_ORDERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GROUPINGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_GROUPINGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(WITHDRAWAL_EXIT_DESTINATIRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.WITHDRAWAL_EXIT_DESTINATI_InsertHref = "WITHDRAWAL_EXIT_maint.aspx"
        WITHDRAWAL_EXIT_DESTINATIWITHDRAWAL_EXIT_DESTINATI_Insert.InnerText += item.WITHDRAWAL_EXIT_DESTINATI_Insert.GetFormattedValue().Replace(vbCrLf,"")
        WITHDRAWAL_EXIT_DESTINATIWITHDRAWAL_EXIT_DESTINATI_Insert.HRef = item.WITHDRAWAL_EXIT_DESTINATI_InsertHref+item.WITHDRAWAL_EXIT_DESTINATI_InsertHrefParameters.ToString("GET","WD_DEST_ID", ViewState)
'End Grid Form WITHDRAWAL_EXIT_DESTINATI BeforeShow tail

'Navigator Navigator Event BeforeShow. Action Hide-Show Component @34-01425DA8
        Dim TotalPages_34_1 As IntegerField = New IntegerField("",WITHDRAWAL_EXIT_DESTINATIData.PagesCount)
        Dim ExprParam2_34_2 As IntegerField = New IntegerField("", (2))
        If Not TotalPages_34_1.Value Is Nothing And Not ExprParam2_34_2.Value Is Nothing And FieldBase.LessThan(TotalPages_34_1, ExprParam2_34_2) Then
            NavigatorNavigator.Visible = False
        End If
'End Navigator Navigator Event BeforeShow. Action Hide-Show Component

'Grid WITHDRAWAL_EXIT_DESTINATI Bind tail @2-E31F8E2A
    End Sub
'End Grid WITHDRAWAL_EXIT_DESTINATI Bind tail

'Grid WITHDRAWAL_EXIT_DESTINATI ItemDataBound event @2-E13A8C89

    Protected Sub WITHDRAWAL_EXIT_DESTINATIItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as WITHDRAWAL_EXIT_DESTINATIItem = CType(e.Item.DataItem,WITHDRAWAL_EXIT_DESTINATIItem)
        Dim Item as WITHDRAWAL_EXIT_DESTINATIItem = DataItem
        Dim FormDataSource As WITHDRAWAL_EXIT_DESTINATIItem() = CType(WITHDRAWAL_EXIT_DESTINATIRepeater.DataSource, WITHDRAWAL_EXIT_DESTINATIItem())
        Dim WITHDRAWAL_EXIT_DESTINATIDataRows As Integer = FormDataSource.Length
        Dim WITHDRAWAL_EXIT_DESTINATIIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            WITHDRAWAL_EXIT_DESTINATICurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(WITHDRAWAL_EXIT_DESTINATIRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, WITHDRAWAL_EXIT_DESTINATICurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim WITHDRAWAL_EXIT_DESTINATIDetail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIDetail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim WITHDRAWAL_EXIT_DESTINATIWD_DEST_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIWD_DEST_ID"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIGROUPING As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIGROUPING"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "WITHDRAWAL_EXIT_maint.aspx"
            WITHDRAWAL_EXIT_DESTINATIDetail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_WD_DEST_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_WD_DEST_ID"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_EXIT_DESTINATION_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_EXIT_DESTINATION_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_DISPLAY_ORDER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_DISPLAY_ORDER"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_GROUPING As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_GROUPING"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("WITHDRAWAL_EXIT_DESTINATIAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_DetailHref = "WITHDRAWAL_EXIT_maint.aspx"
            WITHDRAWAL_EXIT_DESTINATIAlt_Detail.HRef = DataItem.Alt_DetailHref & DataItem.Alt_DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid WITHDRAWAL_EXIT_DESTINATI ItemDataBound event

'Grid WITHDRAWAL_EXIT_DESTINATI ItemDataBound event tail @2-6C2A5B6F
        If WITHDRAWAL_EXIT_DESTINATIIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(WITHDRAWAL_EXIT_DESTINATICurrentRowNumber, ListItemType.AlternatingItem)
                WITHDRAWAL_EXIT_DESTINATIRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(WITHDRAWAL_EXIT_DESTINATICurrentRowNumber, ListItemType.Item)
                WITHDRAWAL_EXIT_DESTINATIRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            WITHDRAWAL_EXIT_DESTINATIItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid WITHDRAWAL_EXIT_DESTINATI ItemDataBound event tail

'Grid WITHDRAWAL_EXIT_DESTINATI ItemCommand event @2-35879A99

    Protected Sub WITHDRAWAL_EXIT_DESTINATIItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= WITHDRAWAL_EXIT_DESTINATIRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("WITHDRAWAL_EXIT_DESTINATISortDir"),SortDirections) = SortDirections._Asc And ViewState("WITHDRAWAL_EXIT_DESTINATISortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("WITHDRAWAL_EXIT_DESTINATISortDir")=SortDirections._Desc
                Else
                    ViewState("WITHDRAWAL_EXIT_DESTINATISortDir")=SortDirections._Asc
                End If
            Else
                ViewState("WITHDRAWAL_EXIT_DESTINATISortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As WITHDRAWAL_EXIT_DESTINATIDataProvider.SortFields = 0
            ViewState("WITHDRAWAL_EXIT_DESTINATISortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("WITHDRAWAL_EXIT_DESTINATIPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("WITHDRAWAL_EXIT_DESTINATIPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("WITHDRAWAL_EXIT_DESTINATIPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("WITHDRAWAL_EXIT_DESTINATIPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            WITHDRAWAL_EXIT_DESTINATIBind
        End If
    End Sub
'End Grid WITHDRAWAL_EXIT_DESTINATI ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-64E2BA7D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        WITHDRAWAL_EXIT_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        WITHDRAWAL_EXIT_DESTINATIData = New WITHDRAWAL_EXIT_DESTINATIDataProvider()
        WITHDRAWAL_EXIT_DESTINATIOperations = New FormSupportedOperations(False, True, False, False, False)
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

