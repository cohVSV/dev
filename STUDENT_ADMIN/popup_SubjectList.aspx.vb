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

Namespace DECV_PROD2007.popup_SubjectList 'Namespace @1-696687C0

'Forms Definition @1-0B57975B
Public Class [popup_SubjectListPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EEE38A95
    Protected SUBJECTSearchData As SUBJECTSearchDataProvider
    Protected SUBJECTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECTSearchOperations As FormSupportedOperations
    Protected SUBJECTSearchIsSubmitted As Boolean = False
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTCurrentRowNumber As Integer
    Protected popup_SubjectListContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-395886FC
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECTSearchShow()
            SUBJECTBind
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

'Record Form SUBJECTSearch BeforeShow tail @10-3D245F11
        SUBJECTSearchParameters()
        SUBJECTSearchData.FillItem(item, IsInsertMode)
        SUBJECTSearchHolder.DataBind()
        SUBJECTSearchs_YEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        SUBJECTSearchs_YEAR_LEVEL.Items(0).Selected = True
        item.s_YEAR_LEVELItems.SetSelection(item.s_YEAR_LEVEL.GetFormattedValue())
        If Not item.s_YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            SUBJECTSearchs_YEAR_LEVEL.SelectedIndex = -1
        End If
        item.s_YEAR_LEVELItems.CopyTo(SUBJECTSearchs_YEAR_LEVEL.Items)
'End Record Form SUBJECTSearch BeforeShow tail

'Record Form SUBJECTSearch Show method tail @10-2B15C3B5
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
        End If
    End Sub
'End Record Form SUBJECTSearch Show method tail

'Record Form SUBJECTSearch LoadItemFromRequest method @10-755985E1

    Protected Sub SUBJECTSearchLoadItemFromRequest(item As SUBJECTSearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(SUBJECTSearchs_YEAR_LEVEL.UniqueID))
        item.s_YEAR_LEVEL.SetValue(SUBJECTSearchs_YEAR_LEVEL.Value)
        item.s_YEAR_LEVELItems.CopyFrom(SUBJECTSearchs_YEAR_LEVEL.Items)
        Catch ae As ArgumentException
            SUBJECTSearchErrors.Add("s_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"Year Level"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECTSearchData)
        End If
        SUBJECTSearchErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECTSearch LoadItemFromRequest method

'Record Form SUBJECTSearch GetRedirectUrl method @10-4D0F361A

    Protected Function GetSUBJECTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "popup_SubjectList.aspx"
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

'Button Button_DoSearch OnClick. @11-B124E65B
        If CType(sender,Control).ID = "SUBJECTSearchButton_DoSearch" Then
            RedirectUrl = GetSUBJECTSearchRedirectUrl("", "s_YEAR_LEVEL")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @11-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECTSearch Search Operation tail @10-DA31D073
        ErrorFlag = SUBJECTSearchErrors.Count > 0
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In SUBJECTSearchs_YEAR_LEVEL.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_YEAR_LEVEL=" & Server.UrlEncode(li.Value) & "&"
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

'Grid SUBJECT Bind @2-FA75635C

    Protected Sub SUBJECTBind()
        If Not SUBJECTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT",GetType(SUBJECTDataProvider.SortFields), 30, 100)
        End If
'End Grid SUBJECT Bind

'Grid Form SUBJECT BeforeShow tail @2-3BC13186
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
        If PagesCount = 0 Then
            SUBJECTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(SUBJECTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form SUBJECT BeforeShow tail

'Grid SUBJECT Event BeforeShow. Action Hide-Show Component @21-A7CCE026
        Dim Urls_YEAR_LEVEL_21_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL"))
        Dim ExprParam2_21_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_YEAR_LEVEL_21_1, ExprParam2_21_2) Then
            SUBJECTRepeater.Visible = False
        End If
'End Grid SUBJECT Event BeforeShow. Action Hide-Show Component

'Grid SUBJECT Event BeforeShow. Action Custom Code @30-73254650
    ' -------------------------
    'ERA: hide Navigator if less than 2 pages returned
	if PagesCount < 2 then NavigatorNavigator.visible = false
    ' -------------------------
'End Grid SUBJECT Event BeforeShow. Action Custom Code

'Grid SUBJECT Bind tail @2-E31F8E2A
    End Sub
'End Grid SUBJECT Bind tail

'Grid SUBJECT Table Parameters @2-5EED8374

    Protected Sub SUBJECTParameters()
        Try
            SUBJECTData.UrlYEAR_LEVEL = IntegerParameter.GetParam("YEAR_LEVEL", ParameterSourceType.URL, "", Nothing, false)
            SUBJECTData.Urls_YEAR_LEVEL = IntegerParameter.GetParam("s_YEAR_LEVEL", ParameterSourceType.URL, "", Nothing, false)

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

'Grid SUBJECT ItemDataBound event @2-0DFE1BC0

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
            Dim SUBJECTSUBJECT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SUBJECTSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            DataItem.SUBJECT_IDHref = ""
            SUBJECTSUBJECT_ID.HRef = DataItem.SUBJECT_IDHref & DataItem.SUBJECT_IDHrefParameters.ToString("GET","", ViewState)
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

'OnInit Event Body @1-4888FE80
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        popup_SubjectListContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTSearchData = New SUBJECTSearchDataProvider()
        SUBJECTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
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

