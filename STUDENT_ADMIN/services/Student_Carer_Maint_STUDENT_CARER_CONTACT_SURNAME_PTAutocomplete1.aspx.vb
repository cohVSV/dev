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

Namespace DECV_PROD2007.services.Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1 'Namespace @1-AE9B0B93

'Forms Definition @1-9C4FB0BD
Public Class [Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-68A50F1B
    Protected STUDENT_CARER_CONTACT1Data As STUDENT_CARER_CONTACT1DataProvider
    Protected STUDENT_CARER_CONTACT1Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT1CurrentRowNumber As Integer
    Protected Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-7E42D27A
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CARER_CONTACT1Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_CARER_CONTACT1 Bind @2-1F123A14

    Protected Sub STUDENT_CARER_CONTACT1Bind()
        If Not STUDENT_CARER_CONTACT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT1",GetType(STUDENT_CARER_CONTACT1DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT1 Bind

'Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail @2-EA1025A2
        STUDENT_CARER_CONTACT1Parameters()
        STUDENT_CARER_CONTACT1Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT1SortField"),STUDENT_CARER_CONTACT1DataProvider.SortFields)
        STUDENT_CARER_CONTACT1Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections)
        STUDENT_CARER_CONTACT1Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT1PageNumber"))
        STUDENT_CARER_CONTACT1Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT1PageSize"))
        STUDENT_CARER_CONTACT1Repeater.DataSource = STUDENT_CARER_CONTACT1Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT1Operations)
        ViewState("STUDENT_CARER_CONTACT1PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
        STUDENT_CARER_CONTACT1Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1

'End Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail

'Grid STUDENT_CARER_CONTACT1 Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Bind tail

'Grid STUDENT_CARER_CONTACT1 Table Parameters @2-09443252

    Protected Sub STUDENT_CARER_CONTACT1Parameters()
        Try
            STUDENT_CARER_CONTACT1Data.Expr115 = TextParameter.GetParam("SS", ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT1Data.PostSTUDENT_CARER_CONTACTSURNAME = TextParameter.GetParam("STUDENT_CARER_CONTACTSURNAME", ParameterSourceType.Form, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Table Parameters

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event @2-F55E235A

    Protected Sub STUDENT_CARER_CONTACT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT1Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT1Item)
        Dim Item as STUDENT_CARER_CONTACT1Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT1Item() = CType(STUDENT_CARER_CONTACT1Repeater.DataSource, STUDENT_CARER_CONTACT1Item())
        Dim STUDENT_CARER_CONTACT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1EMAIL"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail @2-348AA5A8
        If STUDENT_CARER_CONTACT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT1CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT1 ItemCommand event @2-AAD04B91

    Protected Sub STUDENT_CARER_CONTACT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT1DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT1Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F723E681
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Carer_Maint_STUDENT_CARER_CONTACT_SURNAME_PTAutocomplete1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CARER_CONTACT1Data = New STUDENT_CARER_CONTACT1DataProvider()
        STUDENT_CARER_CONTACT1Operations = New FormSupportedOperations(False, True, False, False, False)
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

