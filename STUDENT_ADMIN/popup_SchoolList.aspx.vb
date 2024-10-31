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

Namespace DECV_PROD2007.popup_SchoolList 'Namespace @1-7596C9DF

'Forms Definition @1-4C8A8152
Public Class [popup_SchoolListPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-7D0958FE
    Protected SUBJECTSearchData As SUBJECTSearchDataProvider
    Protected SUBJECTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECTSearchOperations As FormSupportedOperations
    Protected SUBJECTSearchIsSubmitted As Boolean = False
    Protected SCHOOLData As SCHOOLDataProvider
    Protected SCHOOLOperations As FormSupportedOperations
    Protected SCHOOLCurrentRowNumber As Integer
    Protected popup_SchoolListContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-6973BFBE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECTSearchShow()
            SCHOOLBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SUBJECTSearch Parameters @10-0DBBE141

    Protected Sub SUBJECTSearchParameters()
        Dim item As new SUBJECTSearchItem
        Try
        Catch e As Exception
            SUBJECTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECTSearch Parameters

'Record Form SUBJECTSearch Show method @10-3B0884E5
    Protected Sub SUBJECTSearchShow()
        If SUBJECTSearchOperations.None Then
            SUBJECTSearchHolder.Visible = False
            Return
        End If
        Dim item As SUBJECTSearchItem = SUBJECTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECTSearchOperations.AllowRead
        SUBJECTSearchErrors.Add(item.errors)
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
            Return
        End If
'End Record Form SUBJECTSearch Show method

'Record Form SUBJECTSearch BeforeShow tail @10-3C5FF522
        SUBJECTSearchParameters()
        SUBJECTSearchData.FillItem(item, IsInsertMode)
        SUBJECTSearchHolder.DataBind()
        SUBJECTSearchs_SEARCH_ALPHA.Items.Add(new ListItem("Select Value",""))
        SUBJECTSearchs_SEARCH_ALPHA.Items(0).Selected = True
        item.s_SEARCH_ALPHAItems.SetSelection(item.s_SEARCH_ALPHA.GetFormattedValue())
        If Not item.s_SEARCH_ALPHAItems.GetSelectedItem() Is Nothing Then
            SUBJECTSearchs_SEARCH_ALPHA.SelectedIndex = -1
        End If
        item.s_SEARCH_ALPHAItems.CopyTo(SUBJECTSearchs_SEARCH_ALPHA.Items)
'End Record Form SUBJECTSearch BeforeShow tail

'Record Form SUBJECTSearch Show method tail @10-2B15C3B5
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
        End If
    End Sub
'End Record Form SUBJECTSearch Show method tail

'Record Form SUBJECTSearch LoadItemFromRequest method @10-B8C71458

    Protected Sub SUBJECTSearchLoadItemFromRequest(item As SUBJECTSearchItem, ByVal EnableValidation As Boolean)
        item.s_SEARCH_ALPHA.IsEmpty = IsNothing(Request.Form(SUBJECTSearchs_SEARCH_ALPHA.UniqueID))
        item.s_SEARCH_ALPHA.SetValue(SUBJECTSearchs_SEARCH_ALPHA.Value)
        item.s_SEARCH_ALPHAItems.CopyFrom(SUBJECTSearchs_SEARCH_ALPHA.Items)
        If EnableValidation Then
            item.Validate(SUBJECTSearchData)
        End If
        SUBJECTSearchErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECTSearch LoadItemFromRequest method

'Record Form SUBJECTSearch GetRedirectUrl method @10-317F8695

    Protected Function GetSUBJECTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "popup_SchoolList.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECTSearch GetRedirectUrl method

'Record Form SUBJECTSearch ShowErrors method @10-1BBB8726

    Protected Sub SUBJECTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECTSearchErrors.Count - 1
        Select Case SUBJECTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECTSearchErrors(i)
        End Select
        Next i
        SUBJECTSearchError.Visible = True
        SUBJECTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECTSearch ShowErrors method

'Record Form SUBJECTSearch Insert Operation @10-33FDEC64

    Protected Sub SUBJECTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Insert Operation

'Record Form SUBJECTSearch BeforeInsert tail @10-8EC67B0F
    SUBJECTSearchParameters()
    SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch BeforeInsert tail

'Record Form SUBJECTSearch AfterInsert tail  @10-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch AfterInsert tail 

'Record Form SUBJECTSearch Update Operation @10-CEA8EC00

    Protected Sub SUBJECTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Update Operation

'Record Form SUBJECTSearch Before Update tail @10-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Before Update tail

'Record Form SUBJECTSearch Update Operation tail @10-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch Update Operation tail

'Record Form SUBJECTSearch Delete Operation @10-7B81E740
    Protected Sub SUBJECTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECTSearch Delete Operation

'Record Form BeforeDelete tail @10-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @10-D8B6C6AE
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECTSearch Cancel Operation @10-2C955275

    Protected Sub SUBJECTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECTSearchLoadItemFromRequest(item, True)
'End Record Form SUBJECTSearch Cancel Operation

'Record Form SUBJECTSearch Cancel Operation tail @10-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECTSearch Cancel Operation tail

'Record Form SUBJECTSearch Search Operation @10-8AD27A71
    Protected Sub SUBJECTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Search Operation

'Button Button_DoSearch OnClick. @11-C073CFC6
        If CType(sender,Control).ID = "SUBJECTSearchButton_DoSearch" Then
            RedirectUrl = GetSUBJECTSearchRedirectUrl("", "s_SEARCH_ALPHA")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @11-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECTSearch Search Operation tail @10-4336E2EA
        ErrorFlag = SUBJECTSearchErrors.Count > 0
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In SUBJECTSearchs_SEARCH_ALPHA.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SEARCH_ALPHA=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch Search Operation tail

'DEL      ' -------------------------
'DEL      'ERA: hide Navigator if less than 2 pages returned
'DEL  	if PagesCount < 2 then NavigatorNavigator.visible = false
'DEL      ' -------------------------

'Grid SCHOOL Bind @2-B34B304A

    Protected Sub SCHOOLBind()
        If Not SCHOOLOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SCHOOL",GetType(SCHOOLDataProvider.SortFields), 50, 100)
        End If
'End Grid SCHOOL Bind

'Grid Form SCHOOL BeforeShow tail @2-BB02E7B4
        SCHOOLParameters()
        SCHOOLData.SortField = CType(ViewState("SCHOOLSortField"),SCHOOLDataProvider.SortFields)
        SCHOOLData.SortDir = CType(ViewState("SCHOOLSortDir"),SortDirections)
        SCHOOLData.PageNumber = CInt(ViewState("SCHOOLPageNumber"))
        SCHOOLData.RecordsPerPage = CInt(ViewState("SCHOOLPageSize"))
        SCHOOLRepeater.DataSource = SCHOOLData.GetResultSet(PagesCount, SCHOOLOperations)
        ViewState("SCHOOLPagesCount") = PagesCount
        Dim item As SCHOOLItem = New SCHOOLItem()
        SCHOOLRepeater.DataBind
        FooterIndex = SCHOOLRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SCHOOLRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(SCHOOLRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form SCHOOL BeforeShow tail

'Grid SCHOOL Event BeforeShow. Action Hide-Show Component @21-2756FB86
        Dim Urls_SEARCH_ALPHA_21_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SEARCH_ALPHA"))
        Dim ExprParam2_21_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SEARCH_ALPHA_21_1, ExprParam2_21_2) Then
            SCHOOLRepeater.Visible = False
        End If
'End Grid SCHOOL Event BeforeShow. Action Hide-Show Component

'Grid SCHOOL Bind tail @2-E31F8E2A
    End Sub
'End Grid SCHOOL Bind tail

'Grid SCHOOL Table Parameters @2-9D55771C

    Protected Sub SCHOOLParameters()
        Try
            SCHOOLData.Urls_SEARCH_ALPHA = TextParameter.GetParam("s_SEARCH_ALPHA", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=SCHOOLRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SCHOOLRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SCHOOL: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SCHOOL Table Parameters

'Grid SCHOOL ItemDataBound event @2-5BB06542

    Protected Sub SCHOOLItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SCHOOLItem = CType(e.Item.DataItem,SCHOOLItem)
        Dim Item as SCHOOLItem = DataItem
        Dim FormDataSource As SCHOOLItem() = CType(SCHOOLRepeater.DataSource, SCHOOLItem())
        Dim SCHOOLDataRows As Integer = FormDataSource.Length
        Dim SCHOOLIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SCHOOLCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SCHOOLRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SCHOOLCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SCHOOLSCHOOL_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCHOOLSCHOOL_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SCHOOLSCHOOL_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLSCHOOL_TITLE"),System.Web.UI.WebControls.Literal)
            DataItem.SCHOOL_IDHref = ""
            SCHOOLSCHOOL_ID.HRef = DataItem.SCHOOL_IDHref & DataItem.SCHOOL_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid SCHOOL ItemDataBound event

'Grid SCHOOL ItemDataBound event tail @2-0BAF0BDC
        If SCHOOLIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SCHOOLCurrentRowNumber, ListItemType.Item)
            SCHOOLRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SCHOOLItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SCHOOL ItemDataBound event tail

'Grid SCHOOL ItemCommand event @2-8E658108

    Protected Sub SCHOOLItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SCHOOLRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SCHOOLSortDir"),SortDirections) = SortDirections._Asc And ViewState("SCHOOLSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SCHOOLSortDir")=SortDirections._Desc
                Else
                    ViewState("SCHOOLSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SCHOOLSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SCHOOLDataProvider.SortFields = 0
            ViewState("SCHOOLSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SCHOOLPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SCHOOLPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SCHOOLPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SCHOOLPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SCHOOLBind
        End If
    End Sub
'End Grid SCHOOL ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-640B1402
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        popup_SchoolListContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTSearchData = New SUBJECTSearchDataProvider()
        SUBJECTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        SCHOOLData = New SCHOOLDataProvider()
        SCHOOLOperations = New FormSupportedOperations(False, True, False, False, False)
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

