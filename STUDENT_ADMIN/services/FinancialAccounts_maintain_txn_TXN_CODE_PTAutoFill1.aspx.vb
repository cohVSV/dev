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

Namespace DECV_PROD2007.services.FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1 'Namespace @1-BA2D417A

'Forms Definition @1-4E9FE161
Public Class [FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-5F81EEE8
    Protected TXN_CODEData As TXN_CODEDataProvider
    Protected TXN_CODEOperations As FormSupportedOperations
    Protected TXN_CODECurrentRowNumber As Integer
    Protected FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B65EE35D
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            TXN_CODEBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid TXN_CODE Bind @2-6A0A225D

    Protected Sub TXN_CODEBind()
        If Not TXN_CODEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"TXN_CODE",GetType(TXN_CODEDataProvider.SortFields), 10, 100)
        End If
'End Grid TXN_CODE Bind

'Grid Form TXN_CODE BeforeShow tail @2-C03E2ACB
        TXN_CODEParameters()
        TXN_CODEData.SortField = CType(ViewState("TXN_CODESortField"),TXN_CODEDataProvider.SortFields)
        TXN_CODEData.SortDir = CType(ViewState("TXN_CODESortDir"),SortDirections)
        TXN_CODEData.PageNumber = CInt(ViewState("TXN_CODEPageNumber"))
        TXN_CODEData.RecordsPerPage = CInt(ViewState("TXN_CODEPageSize"))
        TXN_CODERepeater.DataSource = TXN_CODEData.GetResultSet(PagesCount, TXN_CODEOperations)
        ViewState("TXN_CODEPagesCount") = PagesCount
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        TXN_CODERepeater.DataBind
        FooterIndex = TXN_CODERepeater.Controls.Count - 1

'End Grid Form TXN_CODE BeforeShow tail

'Grid TXN_CODE Bind tail @2-E31F8E2A
    End Sub
'End Grid TXN_CODE Bind tail

'Grid TXN_CODE Table Parameters @2-A0367492

    Protected Sub TXN_CODEParameters()
        Try
            TXN_CODEData.Urlkeyword = TextParameter.GetParam("keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=TXN_CODERepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(TXN_CODERepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid TXN_CODE: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid TXN_CODE Table Parameters

'Grid TXN_CODE ItemDataBound event @2-88AADE10

    Protected Sub TXN_CODEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as TXN_CODEItem = CType(e.Item.DataItem,TXN_CODEItem)
        Dim Item as TXN_CODEItem = DataItem
        Dim FormDataSource As TXN_CODEItem() = CType(TXN_CODERepeater.DataSource, TXN_CODEItem())
        Dim TXN_CODEDataRows As Integer = FormDataSource.Length
        Dim TXN_CODEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            TXN_CODECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(TXN_CODERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, TXN_CODECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim TXN_CODETXN_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODETXN_CODE"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODECR_DR_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODECR_DR_FLAG"),System.Web.UI.WebControls.Literal)
        End If
'End Grid TXN_CODE ItemDataBound event

'Grid TXN_CODE ItemDataBound event tail @2-8F030ACB
        If TXN_CODEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(TXN_CODECurrentRowNumber, ListItemType.Item)
            TXN_CODERepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            TXN_CODEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid TXN_CODE ItemDataBound event tail

'Grid TXN_CODE ItemCommand event @2-52B7A15F

    Protected Sub TXN_CODEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= TXN_CODERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("TXN_CODESortDir"),SortDirections) = SortDirections._Asc And ViewState("TXN_CODESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("TXN_CODESortDir")=SortDirections._Desc
                Else
                    ViewState("TXN_CODESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("TXN_CODESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As TXN_CODEDataProvider.SortFields = 0
            ViewState("TXN_CODESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("TXN_CODEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("TXN_CODEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("TXN_CODEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("TXN_CODEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            TXN_CODEBind
        End If
    End Sub
'End Grid TXN_CODE ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4A63177B
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        TXN_CODEData = New TXN_CODEDataProvider()
        TXN_CODEOperations = New FormSupportedOperations(False, True, False, False, False)
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

