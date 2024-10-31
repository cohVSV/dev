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

Namespace DECV_PROD2007.services.Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1 'Namespace @1-F16BE63B

'Forms Definition @1-2FCE1AFD
Public Class [Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-DFFF12C0
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTCurrentRowNumber As Integer
    Protected Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-DEB86AE7
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECTBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SUBJECT Bind @2-94C9BFCD

    Protected Sub SUBJECTBind()
        If Not SUBJECTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT",GetType(SUBJECTDataProvider.SortFields), 0, 500)
        End If
'End Grid SUBJECT Bind

'Grid Form SUBJECT BeforeShow tail @2-4BEA2148
        SUBJECTParameters()
        SUBJECTData.SortField = CType(ViewState("SUBJECTSortField"),SUBJECTDataProvider.SortFields)
        SUBJECTData.SortDir = CType(ViewState("SUBJECTSortDir"),SortDirections)
        SUBJECTData.PageNumber = CInt(ViewState("SUBJECTPageNumber"))
        SUBJECTData.RecordsPerPage = CInt(ViewState("SUBJECTPageSize"))
        SUBJECTRepeater.DataSource = SUBJECTData.GetResultSet(PagesCount, SUBJECTOperations)
        ViewState("SUBJECTPagesCount") = PagesCount
        Dim item As SUBJECTItem = New SUBJECTItem()
        SUBJECTRepeater.DataBind
        FooterIndex = SUBJECTRepeater.Controls.Count - 1

'End Grid Form SUBJECT BeforeShow tail

'Grid SUBJECT Bind tail @2-E31F8E2A
    End Sub
'End Grid SUBJECT Bind tail

'Grid SUBJECT Table Parameters @2-31D73E79

    Protected Sub SUBJECTParameters()
        Try
            SUBJECTData.Urlkeyword = IntegerParameter.GetParam("keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=SUBJECTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SUBJECTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SUBJECT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SUBJECT Table Parameters

'Grid SUBJECT ItemDataBound event @2-AE4EB9EC

    Protected Sub SUBJECTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SUBJECTItem = CType(e.Item.DataItem,SUBJECTItem)
        Dim Item as SUBJECTItem = DataItem
        Dim FormDataSource As SUBJECTItem() = CType(SUBJECTRepeater.DataSource, SUBJECTItem())
        Dim SUBJECTDataRows As Integer = FormDataSource.Length
        Dim SUBJECTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SUBJECTSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTsubject_displaytext As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTsubject_displaytext"),System.Web.UI.WebControls.Literal)
        End If
'End Grid SUBJECT ItemDataBound event

'Grid SUBJECT ItemDataBound event tail @2-2D28AE0B
        If SUBJECTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SUBJECTCurrentRowNumber, ListItemType.Item)
            SUBJECTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SUBJECTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SUBJECT ItemDataBound event tail

'Grid SUBJECT ItemCommand event @2-0DD9B41C

    Protected Sub SUBJECTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SUBJECTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SUBJECTSortDir"),SortDirections) = SortDirections._Asc And ViewState("SUBJECTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SUBJECTSortDir")=SortDirections._Desc
                Else
                    ViewState("SUBJECTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SUBJECTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SUBJECTDataProvider.SortFields = 0
            ViewState("SUBJECTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SUBJECTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SUBJECTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SUBJECTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SUBJECTBind
        End If
    End Sub
'End Grid SUBJECT ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-BA06AB0E
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Subject_maintain_AddSubject_ListBox_Subject_PTDependentListBox1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTData = New SUBJECTDataProvider()
        SUBJECTOperations = New FormSupportedOperations(False, True, False, False, False)
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

