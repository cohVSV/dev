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

Namespace DECV_PROD2007.services.Student_ClassList_Export 'Namespace @1-71C4C79C

'Forms Definition @1-9958EEA9
Public Class [Student_ClassList_ExportPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-856FB4EC
    Protected view_Class_Contact_List_0Data As view_Class_Contact_List_0DataProvider
    Protected view_Class_Contact_List_0Operations As FormSupportedOperations
    Protected view_Class_Contact_List_0CurrentRowNumber As Integer
    Protected Student_ClassList_ExportContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E29ED9CD
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            view_Class_Contact_List_0Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid view_Class_Contact_List_0 Bind @2-37EC8AB9

    Protected Sub view_Class_Contact_List_0Bind()
        If Not view_Class_Contact_List_0Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"view_Class_Contact_List_0",GetType(view_Class_Contact_List_0DataProvider.SortFields), 10, 100)
        End If
'End Grid view_Class_Contact_List_0 Bind

'Grid Form view_Class_Contact_List_0 BeforeShow tail @2-5BDE6D0C
        view_Class_Contact_List_0Data.SortField = CType(ViewState("view_Class_Contact_List_0SortField"),view_Class_Contact_List_0DataProvider.SortFields)
        view_Class_Contact_List_0Data.SortDir = CType(ViewState("view_Class_Contact_List_0SortDir"),SortDirections)
        view_Class_Contact_List_0Data.PageNumber = CInt(ViewState("view_Class_Contact_List_0PageNumber"))
        view_Class_Contact_List_0Data.RecordsPerPage = CInt(ViewState("view_Class_Contact_List_0PageSize"))
        view_Class_Contact_List_0Repeater.DataSource = view_Class_Contact_List_0Data.GetResultSet(PagesCount, view_Class_Contact_List_0Operations)
        ViewState("view_Class_Contact_List_0PagesCount") = PagesCount
        Dim item As view_Class_Contact_List_0Item = New view_Class_Contact_List_0Item()
        view_Class_Contact_List_0Repeater.DataBind
        FooterIndex = view_Class_Contact_List_0Repeater.Controls.Count - 1

'End Grid Form view_Class_Contact_List_0 BeforeShow tail

'Grid view_Class_Contact_List_0 Bind tail @2-E31F8E2A
    End Sub
'End Grid view_Class_Contact_List_0 Bind tail

'Grid view_Class_Contact_List_0 ItemDataBound event @2-8835F208

    Protected Sub view_Class_Contact_List_0ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as view_Class_Contact_List_0Item = CType(e.Item.DataItem,view_Class_Contact_List_0Item)
        Dim Item as view_Class_Contact_List_0Item = DataItem
        Dim FormDataSource As view_Class_Contact_List_0Item() = CType(view_Class_Contact_List_0Repeater.DataSource, view_Class_Contact_List_0Item())
        Dim view_Class_Contact_List_0DataRows As Integer = FormDataSource.Length
        Dim view_Class_Contact_List_0IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            view_Class_Contact_List_0CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(view_Class_Contact_List_0Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, view_Class_Contact_List_0CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim view_Class_Contact_List_0STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0STUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0Alert As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0Alert"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SURNAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0LAd As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0LAd"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PHONE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PHONE1"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0EMAIL1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0EMAIL1"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PHONE2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PHONE2"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0EMAIL2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0EMAIL2"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SCHOOL_SUPERVISOR_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SCHOOL_SUPERVISOR_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_PHONE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0SCHOOL_SUPERVISOR_EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_EMAIL"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0STAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0STAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PARENT_A_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PARENT_A_MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_MOBILE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PARENT_A_HOMEPHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_HOMEPHONE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0PARENT_A_EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_EMAIL"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_Contact_List_0YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_Contact_List_0YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
        End If
'End Grid view_Class_Contact_List_0 ItemDataBound event

'Grid view_Class_Contact_List_0 BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid view_Class_Contact_List_0 BeforeShowRow event

'Grid view_Class_Contact_List_0 Event BeforeShowRow. Action Format JSON @182-3611EEDF
        CType(e.Item.FindControl("view_Class_Contact_List_0Alert"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0Alert"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SURNAME"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SURNAME"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0FIRST_NAME"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0FIRST_NAME"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0LAd"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0LAd"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PHONE1"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PHONE1"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0EMAIL1"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0EMAIL1"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PHONE2"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PHONE2"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0EMAIL2"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0EMAIL2"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_NAME"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_NAME"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_NAME"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_NAME"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_PHONE"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_PHONE"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_EMAIL"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0SCHOOL_SUPERVISOR_EMAIL"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0STAFF_ID"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0STAFF_ID"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_NAME"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_NAME"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_MOBILE"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_MOBILE"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_HOMEPHONE"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_HOMEPHONE"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_EMAIL"),System.Web.UI.WebControls.Literal).Text = CType(e.Item.FindControl("view_Class_Contact_List_0PARENT_A_EMAIL"),System.Web.UI.WebControls.Literal).Text.Replace("""", "\""").Replace("\","\\")
        
'End Grid view_Class_Contact_List_0 Event BeforeShowRow. Action Format JSON

'Grid view_Class_Contact_List_0 BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid view_Class_Contact_List_0 BeforeShowRow event tail

'Grid view_Class_Contact_List_0 ItemDataBound event tail @2-B4322892
        If view_Class_Contact_List_0IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(view_Class_Contact_List_0CurrentRowNumber, ListItemType.Item)
            view_Class_Contact_List_0Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            view_Class_Contact_List_0ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid view_Class_Contact_List_0 ItemDataBound event tail

'Grid view_Class_Contact_List_0 ItemCommand event @2-C0329518

    Protected Sub view_Class_Contact_List_0ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= view_Class_Contact_List_0Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("view_Class_Contact_List_0SortDir"),SortDirections) = SortDirections._Asc And ViewState("view_Class_Contact_List_0SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("view_Class_Contact_List_0SortDir")=SortDirections._Desc
                Else
                    ViewState("view_Class_Contact_List_0SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("view_Class_Contact_List_0SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As view_Class_Contact_List_0DataProvider.SortFields = 0
            ViewState("view_Class_Contact_List_0SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("view_Class_Contact_List_0PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("view_Class_Contact_List_0PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("view_Class_Contact_List_0PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("view_Class_Contact_List_0PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            view_Class_Contact_List_0Bind
        End If
    End Sub
'End Grid view_Class_Contact_List_0 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F5C2B063
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_ClassList_ExportContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        view_Class_Contact_List_0Data = New view_Class_Contact_List_0DataProvider()
        view_Class_Contact_List_0Operations = New FormSupportedOperations(False, True, False, False, False)
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

