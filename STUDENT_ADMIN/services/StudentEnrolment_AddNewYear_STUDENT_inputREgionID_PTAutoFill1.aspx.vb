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

Namespace DECV_PROD2007.services.StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1 'Namespace @1-73A4F02C

'Forms Definition @1-28FB19DD
Public Class [StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F6C09884
    Protected tblRegionEnrolmentsData As tblRegionEnrolmentsDataProvider
    Protected tblRegionEnrolmentsOperations As FormSupportedOperations
    Protected tblRegionEnrolmentsCurrentRowNumber As Integer
    Protected StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-3DF68CBB
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            tblRegionEnrolmentsBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid tblRegionEnrolments Bind @2-ECB4939E

    Protected Sub tblRegionEnrolmentsBind()
        If Not tblRegionEnrolmentsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"tblRegionEnrolments",GetType(tblRegionEnrolmentsDataProvider.SortFields), 10, 100)
        End If
'End Grid tblRegionEnrolments Bind

'Grid Form tblRegionEnrolments BeforeShow tail @2-659514B3
        tblRegionEnrolmentsParameters()
        tblRegionEnrolmentsData.SortField = CType(ViewState("tblRegionEnrolmentsSortField"),tblRegionEnrolmentsDataProvider.SortFields)
        tblRegionEnrolmentsData.SortDir = CType(ViewState("tblRegionEnrolmentsSortDir"),SortDirections)
        tblRegionEnrolmentsData.PageNumber = CInt(ViewState("tblRegionEnrolmentsPageNumber"))
        tblRegionEnrolmentsData.RecordsPerPage = CInt(ViewState("tblRegionEnrolmentsPageSize"))
        tblRegionEnrolmentsRepeater.DataSource = tblRegionEnrolmentsData.GetResultSet(PagesCount, tblRegionEnrolmentsOperations)
        ViewState("tblRegionEnrolmentsPagesCount") = PagesCount
        Dim item As tblRegionEnrolmentsItem = New tblRegionEnrolmentsItem()
        tblRegionEnrolmentsRepeater.DataBind
        FooterIndex = tblRegionEnrolmentsRepeater.Controls.Count - 1

'End Grid Form tblRegionEnrolments BeforeShow tail

'Grid tblRegionEnrolments Bind tail @2-E31F8E2A
    End Sub
'End Grid tblRegionEnrolments Bind tail

'Grid tblRegionEnrolments Table Parameters @2-D0AE536C

    Protected Sub tblRegionEnrolmentsParameters()
        Try
            tblRegionEnrolmentsData.Urlkeyword = IntegerParameter.GetParam("keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=tblRegionEnrolmentsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(tblRegionEnrolmentsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid tblRegionEnrolments: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid tblRegionEnrolments Table Parameters

'Grid tblRegionEnrolments ItemDataBound event @2-CCA90AA3

    Protected Sub tblRegionEnrolmentsItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as tblRegionEnrolmentsItem = CType(e.Item.DataItem,tblRegionEnrolmentsItem)
        Dim Item as tblRegionEnrolmentsItem = DataItem
        Dim FormDataSource As tblRegionEnrolmentsItem() = CType(tblRegionEnrolmentsRepeater.DataSource, tblRegionEnrolmentsItem())
        Dim tblRegionEnrolmentsDataRows As Integer = FormDataSource.Length
        Dim tblRegionEnrolmentsIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            tblRegionEnrolmentsCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(tblRegionEnrolmentsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, tblRegionEnrolmentsCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim tblRegionEnrolmentsid As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsid"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsFirstName As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsFirstName"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsSurname As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsSurname"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsDateBirth As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsDateBirth"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsSex As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsSex"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsYearLevel As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsYearLevel"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentslookupid As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentslookupid"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsEnrolNotes As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsEnrolNotes"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsEnrolCategory As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsEnrolCategory"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsApprovalPeriod As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsApprovalPeriod"),System.Web.UI.WebControls.Literal)
            Dim tblRegionEnrolmentsSchoolID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("tblRegionEnrolmentsSchoolID"),System.Web.UI.WebControls.Literal)
        End If
'End Grid tblRegionEnrolments ItemDataBound event

'Grid tblRegionEnrolments ItemDataBound event tail @2-83E12140
        If tblRegionEnrolmentsIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(tblRegionEnrolmentsCurrentRowNumber, ListItemType.Item)
            tblRegionEnrolmentsRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            tblRegionEnrolmentsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid tblRegionEnrolments ItemDataBound event tail

'Grid tblRegionEnrolments ItemCommand event @2-A4AD53F6

    Protected Sub tblRegionEnrolmentsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= tblRegionEnrolmentsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("tblRegionEnrolmentsSortDir"),SortDirections) = SortDirections._Asc And ViewState("tblRegionEnrolmentsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("tblRegionEnrolmentsSortDir")=SortDirections._Desc
                Else
                    ViewState("tblRegionEnrolmentsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("tblRegionEnrolmentsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As tblRegionEnrolmentsDataProvider.SortFields = 0
            ViewState("tblRegionEnrolmentsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("tblRegionEnrolmentsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("tblRegionEnrolmentsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("tblRegionEnrolmentsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("tblRegionEnrolmentsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            tblRegionEnrolmentsBind
        End If
    End Sub
'End Grid tblRegionEnrolments ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-74E6D30B
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_AddNewYear_STUDENT_inputREgionID_PTAutoFill1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        tblRegionEnrolmentsData = New tblRegionEnrolmentsDataProvider()
        tblRegionEnrolmentsOperations = New FormSupportedOperations(False, True, False, False, False)
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

