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

Namespace DECV_PROD2007.services.CountAssignmentsPending 'Namespace @1-9DA69843

'Forms Definition @1-3EDE0525
Public Class [CountAssignmentsPendingPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C0AFFC81
    Protected ASSIGNMENT_SUBMISSIONData As ASSIGNMENT_SUBMISSIONDataProvider
    Protected ASSIGNMENT_SUBMISSIONOperations As FormSupportedOperations
    Protected ASSIGNMENT_SUBMISSIONCurrentRowNumber As Integer
    Protected CountAssignmentsPendingContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-650218E1
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ASSIGNMENT_SUBMISSIONBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid ASSIGNMENT_SUBMISSION Bind @2-CFEB9224

    Protected Sub ASSIGNMENT_SUBMISSIONBind()
        If Not ASSIGNMENT_SUBMISSIONOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ASSIGNMENT_SUBMISSION",GetType(ASSIGNMENT_SUBMISSIONDataProvider.SortFields), 50, 100)
        End If
'End Grid ASSIGNMENT_SUBMISSION Bind

'Grid Form ASSIGNMENT_SUBMISSION BeforeShow tail @2-C9762A53
        ASSIGNMENT_SUBMISSIONParameters()
        ASSIGNMENT_SUBMISSIONData.SortField = CType(ViewState("ASSIGNMENT_SUBMISSIONSortField"),ASSIGNMENT_SUBMISSIONDataProvider.SortFields)
        ASSIGNMENT_SUBMISSIONData.SortDir = CType(ViewState("ASSIGNMENT_SUBMISSIONSortDir"),SortDirections)
        ASSIGNMENT_SUBMISSIONData.PageNumber = CInt(ViewState("ASSIGNMENT_SUBMISSIONPageNumber"))
        ASSIGNMENT_SUBMISSIONData.RecordsPerPage = CInt(ViewState("ASSIGNMENT_SUBMISSIONPageSize"))
        ASSIGNMENT_SUBMISSIONRepeater.DataSource = ASSIGNMENT_SUBMISSIONData.GetResultSet(PagesCount, ASSIGNMENT_SUBMISSIONOperations)
        ViewState("ASSIGNMENT_SUBMISSIONPagesCount") = PagesCount
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        ASSIGNMENT_SUBMISSIONRepeater.DataBind
        FooterIndex = ASSIGNMENT_SUBMISSIONRepeater.Controls.Count - 1

'End Grid Form ASSIGNMENT_SUBMISSION BeforeShow tail

'Grid ASSIGNMENT_SUBMISSION Bind tail @2-E31F8E2A
    End Sub
'End Grid ASSIGNMENT_SUBMISSION Bind tail

'Grid ASSIGNMENT_SUBMISSION Table Parameters @2-4EBA1BF4

    Protected Sub ASSIGNMENT_SUBMISSIONParameters()
        Try
            ASSIGNMENT_SUBMISSIONData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", 501, false)
            ASSIGNMENT_SUBMISSIONData.UrlSTAFF_ID = TextParameter.GetParam("STAFF_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ASSIGNMENT_SUBMISSIONRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ASSIGNMENT_SUBMISSIONRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ASSIGNMENT_SUBMISSION: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid ASSIGNMENT_SUBMISSION Table Parameters

'Grid ASSIGNMENT_SUBMISSION ItemDataBound event @2-B9D171E1

    Protected Sub ASSIGNMENT_SUBMISSIONItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ASSIGNMENT_SUBMISSIONItem = CType(e.Item.DataItem,ASSIGNMENT_SUBMISSIONItem)
        Dim Item as ASSIGNMENT_SUBMISSIONItem = DataItem
        Dim FormDataSource As ASSIGNMENT_SUBMISSIONItem() = CType(ASSIGNMENT_SUBMISSIONRepeater.DataSource, ASSIGNMENT_SUBMISSIONItem())
        Dim ASSIGNMENT_SUBMISSIONDataRows As Integer = FormDataSource.Length
        Dim ASSIGNMENT_SUBMISSIONIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ASSIGNMENT_SUBMISSIONCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENT_SUBMISSIONRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ASSIGNMENT_SUBMISSIONCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ASSIGNMENT_SUBMISSIONSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONSTUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONSUBMISSION_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONSUBMISSION_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONRECEIVED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONRECEIVED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONRETURNED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONRETURNED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
        End If
'End Grid ASSIGNMENT_SUBMISSION ItemDataBound event

'Grid ASSIGNMENT_SUBMISSION ItemDataBound event tail @2-A8ACB295
        If ASSIGNMENT_SUBMISSIONIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(ASSIGNMENT_SUBMISSIONCurrentRowNumber, ListItemType.Item)
            ASSIGNMENT_SUBMISSIONRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            ASSIGNMENT_SUBMISSIONItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ASSIGNMENT_SUBMISSION ItemDataBound event tail

'Grid ASSIGNMENT_SUBMISSION ItemCommand event @2-37BF2055

    Protected Sub ASSIGNMENT_SUBMISSIONItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ASSIGNMENT_SUBMISSIONRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ASSIGNMENT_SUBMISSIONSortDir"),SortDirections) = SortDirections._Asc And ViewState("ASSIGNMENT_SUBMISSIONSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ASSIGNMENT_SUBMISSIONSortDir")=SortDirections._Desc
                Else
                    ViewState("ASSIGNMENT_SUBMISSIONSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ASSIGNMENT_SUBMISSIONSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ASSIGNMENT_SUBMISSIONDataProvider.SortFields = 0
            ViewState("ASSIGNMENT_SUBMISSIONSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ASSIGNMENT_SUBMISSIONPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ASSIGNMENT_SUBMISSIONPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ASSIGNMENT_SUBMISSIONPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ASSIGNMENT_SUBMISSIONPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ASSIGNMENT_SUBMISSIONBind
        End If
    End Sub
'End Grid ASSIGNMENT_SUBMISSION ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-779474FB
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        CountAssignmentsPendingContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        ASSIGNMENT_SUBMISSIONData = New ASSIGNMENT_SUBMISSIONDataProvider()
        ASSIGNMENT_SUBMISSIONOperations = New FormSupportedOperations(False, True, False, False, False)
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

