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

Namespace DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1 'Namespace @1-75D6E4A3

'Forms Definition @1-84C057C6
Public Class [StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-E13AD01D
    Protected SELECT_distinct_SCHOOL_SUData As SELECT_distinct_SCHOOL_SUDataProvider
    Protected SELECT_distinct_SCHOOL_SUOperations As FormSupportedOperations
    Protected SELECT_distinct_SCHOOL_SUCurrentRowNumber As Integer
    Protected StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-BF36726E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SELECT_distinct_SCHOOL_SUBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SELECT_distinct_SCHOOL_SU Bind @2-D302F938

    Protected Sub SELECT_distinct_SCHOOL_SUBind()
        If Not SELECT_distinct_SCHOOL_SUOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SELECT_distinct_SCHOOL_SU",GetType(SELECT_distinct_SCHOOL_SUDataProvider.SortFields), 10, 100)
        End If
'End Grid SELECT_distinct_SCHOOL_SU Bind

'Grid Form SELECT_distinct_SCHOOL_SU BeforeShow tail @2-889A5AC8
        SELECT_distinct_SCHOOL_SUData.SortField = CType(ViewState("SELECT_distinct_SCHOOL_SUSortField"),SELECT_distinct_SCHOOL_SUDataProvider.SortFields)
        SELECT_distinct_SCHOOL_SUData.SortDir = CType(ViewState("SELECT_distinct_SCHOOL_SUSortDir"),SortDirections)
        SELECT_distinct_SCHOOL_SUData.PageNumber = CInt(ViewState("SELECT_distinct_SCHOOL_SUPageNumber"))
        SELECT_distinct_SCHOOL_SUData.RecordsPerPage = CInt(ViewState("SELECT_distinct_SCHOOL_SUPageSize"))
        SELECT_distinct_SCHOOL_SURepeater.DataSource = SELECT_distinct_SCHOOL_SUData.GetResultSet(PagesCount, SELECT_distinct_SCHOOL_SUOperations)
        ViewState("SELECT_distinct_SCHOOL_SUPagesCount") = PagesCount
        Dim item As SELECT_distinct_SCHOOL_SUItem = New SELECT_distinct_SCHOOL_SUItem()
        SELECT_distinct_SCHOOL_SURepeater.DataBind
        FooterIndex = SELECT_distinct_SCHOOL_SURepeater.Controls.Count - 1

'End Grid Form SELECT_distinct_SCHOOL_SU BeforeShow tail

'Grid SELECT_distinct_SCHOOL_SU Bind tail @2-E31F8E2A
    End Sub
'End Grid SELECT_distinct_SCHOOL_SU Bind tail

'Grid SELECT_distinct_SCHOOL_SU ItemDataBound event @2-99CB81AD

    Protected Sub SELECT_distinct_SCHOOL_SUItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SELECT_distinct_SCHOOL_SUItem = CType(e.Item.DataItem,SELECT_distinct_SCHOOL_SUItem)
        Dim Item as SELECT_distinct_SCHOOL_SUItem = DataItem
        Dim FormDataSource As SELECT_distinct_SCHOOL_SUItem() = CType(SELECT_distinct_SCHOOL_SURepeater.DataSource, SELECT_distinct_SCHOOL_SUItem())
        Dim SELECT_distinct_SCHOOL_SUDataRows As Integer = FormDataSource.Length
        Dim SELECT_distinct_SCHOOL_SUIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SELECT_distinct_SCHOOL_SUCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SELECT_distinct_SCHOOL_SURepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SELECT_distinct_SCHOOL_SUCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_NAME"),System.Web.UI.WebControls.Literal)
            Dim SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_PHONE"),System.Web.UI.WebControls.Literal)
            Dim SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SELECT_distinct_SCHOOL_SUSCHOOL_SUPERVISOR_EMAIL"),System.Web.UI.WebControls.Literal)
        End If
'End Grid SELECT_distinct_SCHOOL_SU ItemDataBound event

'Grid SELECT_distinct_SCHOOL_SU ItemDataBound event tail @2-6E520804
        If SELECT_distinct_SCHOOL_SUIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SELECT_distinct_SCHOOL_SUCurrentRowNumber, ListItemType.Item)
            SELECT_distinct_SCHOOL_SURepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SELECT_distinct_SCHOOL_SUItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SELECT_distinct_SCHOOL_SU ItemDataBound event tail

'Grid SELECT_distinct_SCHOOL_SU ItemCommand event @2-B472D8B9

    Protected Sub SELECT_distinct_SCHOOL_SUItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SELECT_distinct_SCHOOL_SURepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SELECT_distinct_SCHOOL_SUSortDir"),SortDirections) = SortDirections._Asc And ViewState("SELECT_distinct_SCHOOL_SUSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SELECT_distinct_SCHOOL_SUSortDir")=SortDirections._Desc
                Else
                    ViewState("SELECT_distinct_SCHOOL_SUSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SELECT_distinct_SCHOOL_SUSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SELECT_distinct_SCHOOL_SUDataProvider.SortFields = 0
            ViewState("SELECT_distinct_SCHOOL_SUSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SELECT_distinct_SCHOOL_SUPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SELECT_distinct_SCHOOL_SUPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SELECT_distinct_SCHOOL_SUPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SELECT_distinct_SCHOOL_SUPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SELECT_distinct_SCHOOL_SUBind
        End If
    End Sub
'End Grid SELECT_distinct_SCHOOL_SU ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A1F616B0
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutoFill1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        SELECT_distinct_SCHOOL_SUData = New SELECT_distinct_SCHOOL_SUDataProvider()
        SELECT_distinct_SCHOOL_SUOperations = New FormSupportedOperations(False, True, False, False, False)
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

