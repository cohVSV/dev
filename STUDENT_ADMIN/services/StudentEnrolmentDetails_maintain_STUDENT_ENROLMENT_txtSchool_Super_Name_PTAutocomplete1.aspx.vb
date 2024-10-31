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

Namespace DECV_PROD2007.services.StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1 'Namespace @1-2DC1A281

'Forms Definition @1-23BF17A7
Public Class [StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1Page]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-98C8B8E7
    Protected STUDENT_ENROLMENT1Data As STUDENT_ENROLMENT1DataProvider
    Protected STUDENT_ENROLMENT1Operations As FormSupportedOperations
    Protected STUDENT_ENROLMENT1CurrentRowNumber As Integer
    Protected StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1ContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-7BFC3736
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_ENROLMENT1Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_ENROLMENT1 Bind @2-788044B2

    Protected Sub STUDENT_ENROLMENT1Bind()
        If Not STUDENT_ENROLMENT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_ENROLMENT1",GetType(STUDENT_ENROLMENT1DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_ENROLMENT1 Bind

'Grid Form STUDENT_ENROLMENT1 BeforeShow tail @2-69B22C98
        STUDENT_ENROLMENT1Parameters()
        STUDENT_ENROLMENT1Data.SortField = CType(ViewState("STUDENT_ENROLMENT1SortField"),STUDENT_ENROLMENT1DataProvider.SortFields)
        STUDENT_ENROLMENT1Data.SortDir = CType(ViewState("STUDENT_ENROLMENT1SortDir"),SortDirections)
        STUDENT_ENROLMENT1Data.PageNumber = CInt(ViewState("STUDENT_ENROLMENT1PageNumber"))
        STUDENT_ENROLMENT1Data.RecordsPerPage = CInt(ViewState("STUDENT_ENROLMENT1PageSize"))
        STUDENT_ENROLMENT1Repeater.DataSource = STUDENT_ENROLMENT1Data.GetResultSet(PagesCount, STUDENT_ENROLMENT1Operations)
        ViewState("STUDENT_ENROLMENT1PagesCount") = PagesCount
        Dim item As STUDENT_ENROLMENT1Item = New STUDENT_ENROLMENT1Item()
        STUDENT_ENROLMENT1Repeater.DataBind
        FooterIndex = STUDENT_ENROLMENT1Repeater.Controls.Count - 1

'End Grid Form STUDENT_ENROLMENT1 BeforeShow tail

'Grid STUDENT_ENROLMENT1 Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_ENROLMENT1 Bind tail

'Grid STUDENT_ENROLMENT1 Table Parameters @2-C2FD7C59

    Protected Sub STUDENT_ENROLMENT1Parameters()
        Try
            STUDENT_ENROLMENT1Data.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", YEAR(today()), false)
            STUDENT_ENROLMENT1Data.Urlkeyword = TextParameter.GetParam("keyword", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_ENROLMENT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_ENROLMENT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_ENROLMENT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_ENROLMENT1 Table Parameters

'Grid STUDENT_ENROLMENT1 ItemDataBound event @2-42E54A93

    Protected Sub STUDENT_ENROLMENT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_ENROLMENT1Item = CType(e.Item.DataItem,STUDENT_ENROLMENT1Item)
        Dim Item as STUDENT_ENROLMENT1Item = DataItem
        Dim FormDataSource As STUDENT_ENROLMENT1Item() = CType(STUDENT_ENROLMENT1Repeater.DataSource, STUDENT_ENROLMENT1Item())
        Dim STUDENT_ENROLMENT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_ENROLMENT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_ENROLMENT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_ENROLMENT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_ENROLMENT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_ENROLMENT1SCHOOL_SUPERVISOR_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT1SCHOOL_SUPERVISOR_NAME"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_ENROLMENT1 ItemDataBound event

'Grid STUDENT_ENROLMENT1 ItemDataBound event tail @2-139149DB
        If STUDENT_ENROLMENT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_ENROLMENT1CurrentRowNumber, ListItemType.Item)
            STUDENT_ENROLMENT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_ENROLMENT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_ENROLMENT1 ItemDataBound event tail

'Grid STUDENT_ENROLMENT1 ItemCommand event @2-E0AD0947

    Protected Sub STUDENT_ENROLMENT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_ENROLMENT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_ENROLMENT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_ENROLMENT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_ENROLMENT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_ENROLMENT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_ENROLMENT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_ENROLMENT1DataProvider.SortFields = 0
            ViewState("STUDENT_ENROLMENT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_ENROLMENT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_ENROLMENT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_ENROLMENT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_ENROLMENT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_ENROLMENT1Bind
        End If
    End Sub
'End Grid STUDENT_ENROLMENT1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3F11F706
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolmentDetails_maintain_STUDENT_ENROLMENT_txtSchool_Super_Name_PTAutocomplete1ContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_ENROLMENT1Data = New STUDENT_ENROLMENT1DataProvider()
        STUDENT_ENROLMENT1Operations = New FormSupportedOperations(False, True, False, False, False)
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

