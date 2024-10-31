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

Namespace DECV_PROD2007.services.getAddressDetailsForAutoFill 'Namespace @1-311181A1

'Forms Definition @1-558C06C0
Public Class [getAddressDetailsForAutoFillPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-D09DBF88
    Protected ADDRESSData As ADDRESSDataProvider
    Protected ADDRESSOperations As FormSupportedOperations
    Protected ADDRESSCurrentRowNumber As Integer
    Protected getAddressDetailsForAutoFillContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-184AD40E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ADDRESSBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid ADDRESS Bind @2-6C7A4A19

    Protected Sub ADDRESSBind()
        If Not ADDRESSOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ADDRESS",GetType(ADDRESSDataProvider.SortFields), 10, 100)
        End If
'End Grid ADDRESS Bind

'Grid Form ADDRESS BeforeShow tail @2-AE0E1BA5
        ADDRESSParameters()
        ADDRESSData.SortField = CType(ViewState("ADDRESSSortField"),ADDRESSDataProvider.SortFields)
        ADDRESSData.SortDir = CType(ViewState("ADDRESSSortDir"),SortDirections)
        ADDRESSData.PageNumber = CInt(ViewState("ADDRESSPageNumber"))
        ADDRESSData.RecordsPerPage = CInt(ViewState("ADDRESSPageSize"))
        ADDRESSRepeater.DataSource = ADDRESSData.GetResultSet(PagesCount, ADDRESSOperations)
        ViewState("ADDRESSPagesCount") = PagesCount
        Dim item As ADDRESSItem = New ADDRESSItem()
        ADDRESSRepeater.DataBind
        FooterIndex = ADDRESSRepeater.Controls.Count - 1

'End Grid Form ADDRESS BeforeShow tail

'Grid ADDRESS Bind tail @2-E31F8E2A
    End Sub
'End Grid ADDRESS Bind tail

'Grid ADDRESS Table Parameters @2-8B565FE7

    Protected Sub ADDRESSParameters()
        Try
            ADDRESSData.Urlkeyword = FloatParameter.GetParam("keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ADDRESSRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ADDRESSRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ADDRESS: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid ADDRESS Table Parameters

'Grid ADDRESS ItemDataBound event @2-810D882C

    Protected Sub ADDRESSItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ADDRESSItem = CType(e.Item.DataItem,ADDRESSItem)
        Dim Item as ADDRESSItem = DataItem
        Dim FormDataSource As ADDRESSItem() = CType(ADDRESSRepeater.DataSource, ADDRESSItem())
        Dim ADDRESSDataRows As Integer = FormDataSource.Length
        Dim ADDRESSIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ADDRESSCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ADDRESSRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ADDRESSCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ADDRESSADDRESS_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSADDRESS_ID"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSADDRESSEE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSADDRESSEE"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSAGENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSAGENT"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSADDR1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSADDR1"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSADDR2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSADDR2"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSSUBURB_TOWN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSSUBURB_TOWN"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSPOSTCODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSPOSTCODE"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSSTATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSSTATE"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSCOUNTRY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSCOUNTRY"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSPHONE_A As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSPHONE_A"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSPHONE_B As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSPHONE_B"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSFAX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSFAX"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSEMAIL_ADDRESS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSEMAIL_ADDRESS"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ADDRESSEMAIL_ADDRESS2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ADDRESSEMAIL_ADDRESS2"),System.Web.UI.WebControls.Literal)
        End If
'End Grid ADDRESS ItemDataBound event

'Grid ADDRESS ItemDataBound event tail @2-E69C2DE9
        If ADDRESSIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(ADDRESSCurrentRowNumber, ListItemType.Item)
            ADDRESSRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            ADDRESSItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ADDRESS ItemDataBound event tail

'Grid ADDRESS ItemCommand event @2-9652CBA2

    Protected Sub ADDRESSItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ADDRESSRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ADDRESSSortDir"),SortDirections) = SortDirections._Asc And ViewState("ADDRESSSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ADDRESSSortDir")=SortDirections._Desc
                Else
                    ViewState("ADDRESSSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ADDRESSSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ADDRESSDataProvider.SortFields = 0
            ViewState("ADDRESSSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ADDRESSPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ADDRESSPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ADDRESSPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ADDRESSPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ADDRESSBind
        End If
    End Sub
'End Grid ADDRESS ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-6460DAD8
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        getAddressDetailsForAutoFillContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        ADDRESSData = New ADDRESSDataProvider()
        ADDRESSOperations = New FormSupportedOperations(False, True, False, False, False)
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

