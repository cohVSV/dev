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

Namespace DECV_PROD2007.services.Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1 'Namespace @1-63A756D6

'Forms Definition @1-B024147C
Public Class [Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1A6C46FE
    Protected STUDENT_CARER_CONTACT5Data As STUDENT_CARER_CONTACT5DataProvider
    Protected STUDENT_CARER_CONTACT5Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT5CurrentRowNumber As Integer
    Protected Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-77A97200
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CARER_CONTACT5Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_CARER_CONTACT5 Bind @2-DBDDBCC4

    Protected Sub STUDENT_CARER_CONTACT5Bind()
        If Not STUDENT_CARER_CONTACT5Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT5",GetType(STUDENT_CARER_CONTACT5DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT5 Bind

'Grid Form STUDENT_CARER_CONTACT5 BeforeShow tail @2-7AE5E98C
        STUDENT_CARER_CONTACT5Parameters()
        STUDENT_CARER_CONTACT5Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT5SortField"),STUDENT_CARER_CONTACT5DataProvider.SortFields)
        STUDENT_CARER_CONTACT5Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT5SortDir"),SortDirections)
        STUDENT_CARER_CONTACT5Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT5PageNumber"))
        STUDENT_CARER_CONTACT5Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT5PageSize"))
        STUDENT_CARER_CONTACT5Repeater.DataSource = STUDENT_CARER_CONTACT5Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT5Operations)
        ViewState("STUDENT_CARER_CONTACT5PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT5Item = New STUDENT_CARER_CONTACT5Item()
        STUDENT_CARER_CONTACT5Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT5Repeater.Controls.Count - 1

'End Grid Form STUDENT_CARER_CONTACT5 BeforeShow tail

'Grid STUDENT_CARER_CONTACT5 Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT5 Bind tail

'Grid STUDENT_CARER_CONTACT5 Table Parameters @2-B464431B

    Protected Sub STUDENT_CARER_CONTACT5Parameters()
        Try
            STUDENT_CARER_CONTACT5Data.PostSTUDENT_CARER_CONTACT4SURNAME = TextParameter.GetParam("STUDENT_CARER_CONTACT4SURNAME", ParameterSourceType.Form, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT5Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT5Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT5: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT5 Table Parameters

'Grid STUDENT_CARER_CONTACT5 ItemDataBound event @2-BA65CA0B

    Protected Sub STUDENT_CARER_CONTACT5ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT5Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT5Item)
        Dim Item as STUDENT_CARER_CONTACT5Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT5Item() = CType(STUDENT_CARER_CONTACT5Repeater.DataSource, STUDENT_CARER_CONTACT5Item())
        Dim STUDENT_CARER_CONTACT5DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT5IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT5CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT5Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT5CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT5super_name As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5super_name"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_CARER_CONTACT5 ItemDataBound event

'Grid STUDENT_CARER_CONTACT5 ItemDataBound event tail @2-585B13FD
        If STUDENT_CARER_CONTACT5IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT5CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT5Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT5ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT5 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT5 ItemCommand event @2-8D9B44FC

    Protected Sub STUDENT_CARER_CONTACT5ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT5Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT5SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT5SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT5SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT5SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT5SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT5DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT5SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT5PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT5Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT5 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-2AF572F1
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Carer_maintainext_STUDENT_CARER_CONTACT4_SURNAME_PTAutocomplete1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CARER_CONTACT5Data = New STUDENT_CARER_CONTACT5DataProvider()
        STUDENT_CARER_CONTACT5Operations = New FormSupportedOperations(False, True, False, False, False)
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

