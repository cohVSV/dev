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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse 'Namespace @1-8BAAC521

'Forms Definition @1-B77436A1
Public Class [Staff_Inductions_ByCoursePage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2183BCE9
    Protected STAFF_INDUCTIONS_COURSESData As STAFF_INDUCTIONS_COURSESDataProvider
    Protected STAFF_INDUCTIONS_COURSESOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESCurrentRowNumber As Integer
    Protected STAFF_INDUCTIONS_COURSESSearchData As STAFF_INDUCTIONS_COURSESSearchDataProvider
    Protected STAFF_INDUCTIONS_COURSESSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_COURSESSearchOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESSearchIsSubmitted As Boolean = False
    Protected STAFF_INDUCTIONS_COURSES1Data As STAFF_INDUCTIONS_COURSES1DataProvider
    Protected STAFF_INDUCTIONS_COURSES1Errors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_COURSES1Operations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSES1IsSubmitted As Boolean = False
    Protected STAFF_INDUCTIONS_PROGRESSData As STAFF_INDUCTIONS_PROGRESSDataProvider
    Protected STAFF_INDUCTIONS_PROGRESSCurrentRowNumber As Integer
    Protected STAFF_INDUCTIONS_PROGRESSIsSubmitted As Boolean = False
    Protected STAFF_INDUCTIONS_PROGRESSErrors As New NameValueCollection()
    Protected STAFF_INDUCTIONS_PROGRESSOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_PROGRESSDataItem As STAFF_INDUCTIONS_PROGRESSItem
    Protected STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName As String
    Protected STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl As String
    Protected Staff_Inductions_ByCourseContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-62DABEDE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STAFF_INDUCTIONS_COURSESBind
            STAFF_INDUCTIONS_COURSESSearchShow()
            STAFF_INDUCTIONS_COURSES1Show()
            STAFF_INDUCTIONS_PROGRESSBind()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STAFF_INDUCTIONS_COURSES Bind @3-F328B9D7

    Protected Sub STAFF_INDUCTIONS_COURSESBind()
        If Not STAFF_INDUCTIONS_COURSESOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF_INDUCTIONS_COURSES",GetType(STAFF_INDUCTIONS_COURSESDataProvider.SortFields), 30, 100)
        End If
'End Grid STAFF_INDUCTIONS_COURSES Bind

'Grid Form STAFF_INDUCTIONS_COURSES BeforeShow tail @3-CFD57A38
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESData.SortField = CType(ViewState("STAFF_INDUCTIONS_COURSESSortField"),STAFF_INDUCTIONS_COURSESDataProvider.SortFields)
        STAFF_INDUCTIONS_COURSESData.SortDir = CType(ViewState("STAFF_INDUCTIONS_COURSESSortDir"),SortDirections)
        STAFF_INDUCTIONS_COURSESData.PageNumber = CInt(ViewState("STAFF_INDUCTIONS_COURSESPageNumber"))
        STAFF_INDUCTIONS_COURSESData.RecordsPerPage = CInt(ViewState("STAFF_INDUCTIONS_COURSESPageSize"))
        STAFF_INDUCTIONS_COURSESRepeater.DataSource = STAFF_INDUCTIONS_COURSESData.GetResultSet(PagesCount, STAFF_INDUCTIONS_COURSESOperations)
        ViewState("STAFF_INDUCTIONS_COURSESPagesCount") = PagesCount
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        STAFF_INDUCTIONS_COURSESRepeater.DataBind
        FooterIndex = STAFF_INDUCTIONS_COURSESRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STAFF_INDUCTIONS_COURSESRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_idSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_idSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_INDUCTION_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_INDUCTION_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STAFF_INDUCTIONS_COURSESLink1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(FooterIndex).FindControl("STAFF_INDUCTIONS_COURSESLink1"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.Link1Href = "Staff_Inductions_ByCourse.aspx"
        STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords.Text = Server.HtmlEncode(item.STAFF_INDUCTIONS_COURSES_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_COURSESLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSESLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","ind_id", ViewState)
'End Grid Form STAFF_INDUCTIONS_COURSES BeforeShow tail

'Label STAFF_INDUCTIONS_COURSES_TotalRecords Event BeforeShow. Action Retrieve number of records @9-851A0854
            STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords.Text = STAFF_INDUCTIONS_COURSESData.RecordCount.ToString()
'End Label STAFF_INDUCTIONS_COURSES_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid STAFF_INDUCTIONS_COURSES Bind tail @3-E31F8E2A
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES Bind tail

'Grid STAFF_INDUCTIONS_COURSES Table Parameters @3-6A04275F

    Protected Sub STAFF_INDUCTIONS_COURSESParameters()
        Try
            STAFF_INDUCTIONS_COURSESData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STAFF_INDUCTIONS_COURSESRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STAFF_INDUCTIONS_COURSESRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STAFF_INDUCTIONS_COURSES: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES Table Parameters

'Grid STAFF_INDUCTIONS_COURSES ItemDataBound event @3-0D4CE99B

    Protected Sub STAFF_INDUCTIONS_COURSESItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STAFF_INDUCTIONS_COURSESItem = CType(e.Item.DataItem,STAFF_INDUCTIONS_COURSESItem)
        Dim Item as STAFF_INDUCTIONS_COURSESItem = DataItem
        Dim FormDataSource As STAFF_INDUCTIONS_COURSESItem() = CType(STAFF_INDUCTIONS_COURSESRepeater.DataSource, STAFF_INDUCTIONS_COURSESItem())
        Dim STAFF_INDUCTIONS_COURSESDataRows As Integer = FormDataSource.Length
        Dim STAFF_INDUCTIONS_COURSESIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFF_INDUCTIONS_COURSESCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STAFF_INDUCTIONS_COURSESRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFF_INDUCTIONS_COURSESCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STAFF_INDUCTIONS_COURSESid As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESid"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STAFF_INDUCTIONS_COURSESINDUCTION_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESINDUCTION_TITLE"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSESSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESSTATUS"),System.Web.UI.WebControls.Literal)
            DataItem.idHref = "Staff_Inductions_ByCourse.aspx"
            STAFF_INDUCTIONS_COURSESid.HRef = DataItem.idHref & DataItem.idHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF_INDUCTIONS_COURSES ItemDataBound event

'Grid STAFF_INDUCTIONS_COURSES ItemDataBound event tail @3-6BE37B05
        If STAFF_INDUCTIONS_COURSESIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STAFF_INDUCTIONS_COURSESCurrentRowNumber, ListItemType.Item)
            STAFF_INDUCTIONS_COURSESRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STAFF_INDUCTIONS_COURSESItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES ItemDataBound event tail

'Grid STAFF_INDUCTIONS_COURSES ItemCommand event @3-9CD8112B

    Protected Sub STAFF_INDUCTIONS_COURSESItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STAFF_INDUCTIONS_COURSESRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STAFF_INDUCTIONS_COURSESSortDir"),SortDirections) = SortDirections._Asc And ViewState("STAFF_INDUCTIONS_COURSESSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STAFF_INDUCTIONS_COURSESSortDir")=SortDirections._Desc
                Else
                    ViewState("STAFF_INDUCTIONS_COURSESSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STAFF_INDUCTIONS_COURSESSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STAFF_INDUCTIONS_COURSESDataProvider.SortFields = 0
            ViewState("STAFF_INDUCTIONS_COURSESSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STAFF_INDUCTIONS_COURSESPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STAFF_INDUCTIONS_COURSESPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STAFF_INDUCTIONS_COURSESPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFF_INDUCTIONS_COURSESPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STAFF_INDUCTIONS_COURSESBind
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES ItemCommand event

'Record Form STAFF_INDUCTIONS_COURSESSearch Parameters @4-321ED5C3

    Protected Sub STAFF_INDUCTIONS_COURSESSearchParameters()
        Dim item As new STAFF_INDUCTIONS_COURSESSearchItem
        Try
        Catch e As Exception
            STAFF_INDUCTIONS_COURSESSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Parameters

'Record Form STAFF_INDUCTIONS_COURSESSearch Show method @4-2387BBB4
    Protected Sub STAFF_INDUCTIONS_COURSESSearchShow()
        If STAFF_INDUCTIONS_COURSESSearchOperations.None Then
            STAFF_INDUCTIONS_COURSESSearchHolder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = STAFF_INDUCTIONS_COURSESSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_COURSESSearchOperations.AllowRead
        item.ClearParametersHref = "Staff_Inductions_ByCourse.aspx"
        STAFF_INDUCTIONS_COURSESSearchErrors.Add(item.errors)
        If STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_COURSESSearch Show method

'Record Form STAFF_INDUCTIONS_COURSESSearch BeforeShow tail @4-071811F9
        STAFF_INDUCTIONS_COURSESSearchParameters()
        STAFF_INDUCTIONS_COURSESSearchData.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_COURSESSearchHolder.DataBind()
        STAFF_INDUCTIONS_COURSESSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSESSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        STAFF_INDUCTIONS_COURSESSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form STAFF_INDUCTIONS_COURSESSearch BeforeShow tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Show method tail @4-A0FDB316
        If STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Show method tail

'Record Form STAFF_INDUCTIONS_COURSESSearch LoadItemFromRequest method @4-DF9E2DA6

    Protected Sub STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item As STAFF_INDUCTIONS_COURSESSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESSearchs_keyword.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSESSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(STAFF_INDUCTIONS_COURSESSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSESSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_COURSESSearchData)
        End If
        STAFF_INDUCTIONS_COURSESSearchErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_COURSESSearch GetRedirectUrl method @4-9E476FDE

    Protected Function GetSTAFF_INDUCTIONS_COURSESSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_Inductions_ByCourse.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_INDUCTIONS_COURSESSearch GetRedirectUrl method

'Record Form STAFF_INDUCTIONS_COURSESSearch ShowErrors method @4-69C130E4

    Protected Sub STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_INDUCTIONS_COURSESSearchErrors.Count - 1
        Select Case STAFF_INDUCTIONS_COURSESSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_INDUCTIONS_COURSESSearchErrors(i)
        End Select
        Next i
        STAFF_INDUCTIONS_COURSESSearchError.Visible = True
        STAFF_INDUCTIONS_COURSESSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch ShowErrors method

'Record Form STAFF_INDUCTIONS_COURSESSearch Insert Operation @4-DEF89003

    Protected Sub STAFF_INDUCTIONS_COURSESSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        STAFF_INDUCTIONS_COURSESSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSESSearch Insert Operation

'Record Form STAFF_INDUCTIONS_COURSESSearch BeforeInsert tail @4-89A72F37
    STAFF_INDUCTIONS_COURSESSearchParameters()
    STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSESSearch BeforeInsert tail

'Record Form STAFF_INDUCTIONS_COURSESSearch AfterInsert tail  @4-05074509
        ErrorFlag=(STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch AfterInsert tail 

'Record Form STAFF_INDUCTIONS_COURSESSearch Update Operation @4-47D72768

    Protected Sub STAFF_INDUCTIONS_COURSESSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSESSearch Update Operation

'Record Form STAFF_INDUCTIONS_COURSESSearch Before Update tail @4-89A72F37
        STAFF_INDUCTIONS_COURSESSearchParameters()
        STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSESSearch Before Update tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Update Operation tail @4-05074509
        ErrorFlag=(STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Update Operation tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Delete Operation @4-F8B2E8BF
    Protected Sub STAFF_INDUCTIONS_COURSESSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_INDUCTIONS_COURSESSearch Delete Operation

'Record Form BeforeDelete tail @4-89A72F37
        STAFF_INDUCTIONS_COURSESSearchParameters()
        STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-B3FAD23F
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Cancel Operation @4-7E27D35E

    Protected Sub STAFF_INDUCTIONS_COURSESSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        STAFF_INDUCTIONS_COURSESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item, True)
'End Record Form STAFF_INDUCTIONS_COURSESSearch Cancel Operation

'Record Form STAFF_INDUCTIONS_COURSESSearch Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Cancel Operation tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation @4-6170C02D
    Protected Sub STAFF_INDUCTIONS_COURSESSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STAFF_INDUCTIONS_COURSESSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = New STAFF_INDUCTIONS_COURSESSearchItem()
        STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation

'Button Button_DoSearch OnClick. @6-8C0466D4
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESSearchButton_DoSearch" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @6-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation tail @4-FAEDC697
        ErrorFlag = STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STAFF_INDUCTIONS_COURSESSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(STAFF_INDUCTIONS_COURSESSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation tail

'Record Form STAFF_INDUCTIONS_COURSES1 Parameters @21-A4C72B38

    Protected Sub STAFF_INDUCTIONS_COURSES1Parameters()
        Dim item As new STAFF_INDUCTIONS_COURSES1Item
        Try
            STAFF_INDUCTIONS_COURSES1Data.Urlind_id = IntegerParameter.GetParam("ind_id", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STAFF_INDUCTIONS_COURSES1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 Parameters

'Record Form STAFF_INDUCTIONS_COURSES1 Show method @21-AD695E6E
    Protected Sub STAFF_INDUCTIONS_COURSES1Show()
        If STAFF_INDUCTIONS_COURSES1Operations.None Then
            STAFF_INDUCTIONS_COURSES1Holder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_COURSES1Item = STAFF_INDUCTIONS_COURSES1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_COURSES1Operations.AllowRead
        STAFF_INDUCTIONS_COURSES1Errors.Add(item.errors)
        If STAFF_INDUCTIONS_COURSES1Errors.Count > 0 Then
            STAFF_INDUCTIONS_COURSES1ShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_COURSES1 Show method

'Record Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail @21-977C6ECD
        STAFF_INDUCTIONS_COURSES1Parameters()
        STAFF_INDUCTIONS_COURSES1Data.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_COURSES1Holder.DataBind()
        STAFF_INDUCTIONS_COURSES1Button_Insert.Visible=IsInsertMode AndAlso STAFF_INDUCTIONS_COURSES1Operations.AllowInsert
        STAFF_INDUCTIONS_COURSES1Button_Update.Visible=Not (IsInsertMode) AndAlso STAFF_INDUCTIONS_COURSES1Operations.AllowUpdate
        STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE.Text=item.INDUCTION_TITLE.GetFormattedValue()
        STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION.Text=item.INDUCTION_DESCRIPTION.GetFormattedValue()
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        STAFF_INDUCTIONS_COURSES1STATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(STAFF_INDUCTIONS_COURSES1STATUS.Items)
        STAFF_INDUCTIONS_COURSES1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_COURSES1Hidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STAFF_INDUCTIONS_COURSES1Hidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STAFF_INDUCTIONS_COURSES1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail

'Hidden Hidden_last_altered_by Event BeforeShow. Action Retrieve Value for Control @32-848B17A4
            STAFF_INDUCTIONS_COURSES1Hidden_last_altered_by.Value = (New TextField("", (DBUtility.UserLogin.ToUpper()))).GetFormattedValue()
'End Hidden Hidden_last_altered_by Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_last_altered_date Event BeforeShow. Action Retrieve Value for Control @34-668C98B7
            STAFF_INDUCTIONS_COURSES1Hidden_last_altered_date.Value = (New TextField("", (Now()))).GetFormattedValue()
'End Hidden Hidden_last_altered_date Event BeforeShow. Action Retrieve Value for Control

'Record STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code @60-73254650
    ' -------------------------
    'Hide the Editable grid if record is in the insert mode
  	If IsInsertMode Then 
		STAFF_INDUCTIONS_PROGRESSRepeater.Visible = false
  	End If
    ' -------------------------
'End Record STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code

'Record Form STAFF_INDUCTIONS_COURSES1 Show method tail @21-A81A13AE
        If STAFF_INDUCTIONS_COURSES1Errors.Count > 0 Then
            STAFF_INDUCTIONS_COURSES1ShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 Show method tail

'Record Form STAFF_INDUCTIONS_COURSES1 LoadItemFromRequest method @21-CAF1EB39

    Protected Sub STAFF_INDUCTIONS_COURSES1LoadItemFromRequest(item As STAFF_INDUCTIONS_COURSES1Item, ByVal EnableValidation As Boolean)
        item.INDUCTION_TITLE.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE") Is Nothing Then
            item.INDUCTION_TITLE.SetValue(STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE.Text)
        Else
            item.INDUCTION_TITLE.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE"))
        End If
        item.INDUCTION_DESCRIPTION.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION") Is Nothing Then
            item.INDUCTION_DESCRIPTION.SetValue(STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION.Text)
        Else
            item.INDUCTION_DESCRIPTION.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSES1INDUCTION_DESCRIPTION"))
        End If
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSES1STATUS.UniqueID))
        If Not IsNothing(STAFF_INDUCTIONS_COURSES1STATUS.SelectedItem) Then
            item.STATUS.SetValue(STAFF_INDUCTIONS_COURSES1STATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(STAFF_INDUCTIONS_COURSES1STATUS.Items)
        Catch ae As ArgumentException
            STAFF_INDUCTIONS_COURSES1Errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSES1Hidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STAFF_INDUCTIONS_COURSES1Hidden_last_altered_by.Value)
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSES1Hidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STAFF_INDUCTIONS_COURSES1Hidden_last_altered_date.Value)
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_COURSES1Data)
        End If
        STAFF_INDUCTIONS_COURSES1Errors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_COURSES1 GetRedirectUrl method @21-54478ABA

    Protected Function GetSTAFF_INDUCTIONS_COURSES1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_INDUCTIONS_COURSES1 GetRedirectUrl method

'Record Form STAFF_INDUCTIONS_COURSES1 ShowErrors method @21-69D077B2

    Protected Sub STAFF_INDUCTIONS_COURSES1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_INDUCTIONS_COURSES1Errors.Count - 1
        Select Case STAFF_INDUCTIONS_COURSES1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_INDUCTIONS_COURSES1Errors(i)
        End Select
        Next i
        STAFF_INDUCTIONS_COURSES1Error.Visible = True
        STAFF_INDUCTIONS_COURSES1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 ShowErrors method

'Record Form STAFF_INDUCTIONS_COURSES1 Insert Operation @21-804F8061

    Protected Sub STAFF_INDUCTIONS_COURSES1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        Dim ExecuteFlag As Boolean = True
        STAFF_INDUCTIONS_COURSES1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES1 Insert Operation

'Button Button_Insert OnClick. @22-D82B8453
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSES1Button_Insert" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSES1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @22-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSES1 BeforeInsert tail @21-D16B16C5
    STAFF_INDUCTIONS_COURSES1Parameters()
    STAFF_INDUCTIONS_COURSES1LoadItemFromRequest(item, EnableValidation)
    If STAFF_INDUCTIONS_COURSES1Operations.AllowInsert Then
        ErrorFlag=(STAFF_INDUCTIONS_COURSES1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_COURSES1Data.InsertItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_COURSES1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_COURSES1 BeforeInsert tail

'Record STAFF_INDUCTIONS_COURSES1 Event AfterInsert. Action Custom Code @61-73254650
    ' -------------------------
    'ERA: Sept 2010
	'Select last insert ind_id 
	'Redirect user to this page with this parameter so we get the edittable grid again

	Dim LastID As string  = (new TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT max(id) FROM staff_inductions_courses WHERE induction_title=" & "'" & STAFF_INDUCTIONS_COURSES1induction_title.Text & "'" ))).GetFormattedValue("")
	If RedirectUrl.IndexOf("?")=-1 Then
		RedirectUrl = RedirectUrl & "?ind_id=" & LastID
	else 
		RedirectUrl = RedirectUrl & "&ind_id=" & LastID
	End If
    ' -------------------------
'End Record STAFF_INDUCTIONS_COURSES1 Event AfterInsert. Action Custom Code

'Record Form STAFF_INDUCTIONS_COURSES1 AfterInsert tail  @21-E2FEEEAA
        End If
        ErrorFlag=(STAFF_INDUCTIONS_COURSES1Errors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSES1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 AfterInsert tail 

'Record Form STAFF_INDUCTIONS_COURSES1 Update Operation @21-E398B8B9

    Protected Sub STAFF_INDUCTIONS_COURSES1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSES1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES1 Update Operation

'Button Button_Update OnClick. @23-1DD05C7A
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSES1Button_Update" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSES1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @23-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSES1 Before Update tail @21-8BD78DFB
        STAFF_INDUCTIONS_COURSES1Parameters()
        STAFF_INDUCTIONS_COURSES1LoadItemFromRequest(item, EnableValidation)
        If STAFF_INDUCTIONS_COURSES1Operations.AllowUpdate Then
        ErrorFlag = (STAFF_INDUCTIONS_COURSES1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_COURSES1Data.UpdateItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_COURSES1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_COURSES1 Before Update tail

'Record Form STAFF_INDUCTIONS_COURSES1 Update Operation tail @21-E2FEEEAA
        End If
        ErrorFlag=(STAFF_INDUCTIONS_COURSES1Errors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSES1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 Update Operation tail

'Record Form STAFF_INDUCTIONS_COURSES1 Delete Operation @21-257D2DA5
    Protected Sub STAFF_INDUCTIONS_COURSES1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSES1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_INDUCTIONS_COURSES1 Delete Operation

'Record Form BeforeDelete tail @21-8A2157AA
        STAFF_INDUCTIONS_COURSES1Parameters()
        STAFF_INDUCTIONS_COURSES1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @21-B641CD78
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSES1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_INDUCTIONS_COURSES1 Cancel Operation @21-3241580D

    Protected Sub STAFF_INDUCTIONS_COURSES1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        STAFF_INDUCTIONS_COURSES1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_INDUCTIONS_COURSES1LoadItemFromRequest(item, False)
'End Record Form STAFF_INDUCTIONS_COURSES1 Cancel Operation

'Button Button_Cancel OnClick. @24-2128D5FA
    If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSES1Button_Cancel" Then
        RedirectUrl = GetSTAFF_INDUCTIONS_COURSES1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @24-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSES1 Cancel Operation tail @21-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES1 Cancel Operation tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS Bind @36-A1CB5FC2
    Protected Sub STAFF_INDUCTIONS_PROGRESSBind()
        If STAFF_INDUCTIONS_PROGRESSOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF_INDUCTIONS_PROGRESS",GetType(STAFF_INDUCTIONS_PROGRESSDataProvider.SortFields), 40, 100)
        End If
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Bind

'EditableGrid Form STAFF_INDUCTIONS_PROGRESS BeforeShow tail @36-B29099B1
        STAFF_INDUCTIONS_PROGRESSParameters()
        STAFF_INDUCTIONS_PROGRESSData.SortField = CType(ViewState("STAFF_INDUCTIONS_PROGRESSSortField"), STAFF_INDUCTIONS_PROGRESSDataProvider.SortFields)
        STAFF_INDUCTIONS_PROGRESSData.SortDir = CType(ViewState("STAFF_INDUCTIONS_PROGRESSSortDir"), SortDirections)
        STAFF_INDUCTIONS_PROGRESSData.PageNumber = CType(ViewState("STAFF_INDUCTIONS_PROGRESSPageNumber"), Integer)
        STAFF_INDUCTIONS_PROGRESSData.RecordsPerPage = CType(ViewState("STAFF_INDUCTIONS_PROGRESSPageSize"), Integer)
        STAFF_INDUCTIONS_PROGRESSRepeater.DataSource = STAFF_INDUCTIONS_PROGRESSData.GetResultSet(PagesCount, STAFF_INDUCTIONS_PROGRESSOperations)
        ViewState("STAFF_INDUCTIONS_PROGRESSPagesCount") = PagesCount
        ViewState("STAFF_INDUCTIONS_PROGRESSFormState") = New Hashtable()
        ViewState("STAFF_INDUCTIONS_PROGRESSRowState") = New Hashtable()
        STAFF_INDUCTIONS_PROGRESSRepeater.DataBind()
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = STAFF_INDUCTIONS_PROGRESSDataItem
        If IsNothing(item) Then item = New STAFF_INDUCTIONS_PROGRESSItem()
        FooterIndex = STAFF_INDUCTIONS_PROGRESSRepeater.Controls.Count - 1
        Dim STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DATE_COMPLETEDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("Sorter_DATE_COMPLETEDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STAFF_INDUCTIONS_PROGRESSButton_Submit As System.Web.UI.WebControls.Button = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(FooterIndex).FindControl("STAFF_INDUCTIONS_PROGRESSButton_Submit"),System.Web.UI.WebControls.Button)
        Dim STAFF_INDUCTIONS_PROGRESSCancel As System.Web.UI.WebControls.Button = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(FooterIndex).FindControl("STAFF_INDUCTIONS_PROGRESSCancel"),System.Web.UI.WebControls.Button)


        STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_TotalRecords.Text = Server.HtmlEncode(item.STAFF_INDUCTIONS_PROGRESS_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_PROGRESSButton_Submit.Visible = STAFF_INDUCTIONS_PROGRESSOperations.Editable
        If Not CType(STAFF_INDUCTIONS_PROGRESSRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            STAFF_INDUCTIONS_PROGRESSRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If STAFF_INDUCTIONS_PROGRESSErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("STAFF_INDUCTIONS_PROGRESSError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In STAFF_INDUCTIONS_PROGRESSErrors
                ErrorLabel.Text += STAFF_INDUCTIONS_PROGRESSErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form STAFF_INDUCTIONS_PROGRESS BeforeShow tail

'Label STAFF_INDUCTIONS_PROGRESS_TotalRecords Event BeforeShow. Action Retrieve number of records @39-B81737ED
            STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_TotalRecords.Text = STAFF_INDUCTIONS_PROGRESSData.RecordCount.ToString()
'End Label STAFF_INDUCTIONS_PROGRESS_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid STAFF_INDUCTIONS_PROGRESS Bind tail @36-7310B838
        STAFF_INDUCTIONS_PROGRESSShowErrors(New ArrayList(CType(STAFF_INDUCTIONS_PROGRESSRepeater.DataSource, ICollection)), STAFF_INDUCTIONS_PROGRESSRepeater.Items)
    End Sub
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Bind tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS Table Parameters @36-D5CCAAF3
    Protected Sub STAFF_INDUCTIONS_PROGRESSParameters()
        Try
        Dim item As new STAFF_INDUCTIONS_PROGRESSItem
            STAFF_INDUCTIONS_PROGRESSData.Urlind_id = IntegerParameter.GetParam("ind_id", ParameterSourceType.URL, "", -1, false)
        Catch
            Dim ParentControls As ControlCollection = STAFF_INDUCTIONS_PROGRESSRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(STAFF_INDUCTIONS_PROGRESSRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid STAFF_INDUCTIONS_PROGRESS: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Table Parameters

'EditableGrid STAFF_INDUCTIONS_PROGRESS ItemDataBound event @36-1E9E1B24
    Protected Sub STAFF_INDUCTIONS_PROGRESSItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As STAFF_INDUCTIONS_PROGRESSItem = DirectCast(e.Item.DataItem, STAFF_INDUCTIONS_PROGRESSItem)
        Dim Item as STAFF_INDUCTIONS_PROGRESSItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFF_INDUCTIONS_PROGRESSCurrentRowNumber = STAFF_INDUCTIONS_PROGRESSCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("STAFF_INDUCTIONS_PROGRESSFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("STAFF_INDUCTIONS_PROGRESSRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            Dim STAFF_INDUCTIONS_PROGRESSSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STAFF_INDUCTIONS_PROGRESSSTATUS As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSSTATUS"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED"),System.Web.UI.WebControls.TextBox)
            Dim STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED"),System.Web.UI.WebControls.PlaceHolder)
            Dim STAFF_INDUCTIONS_PROGRESSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim STAFF_INDUCTIONS_PROGRESSinduction_id As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSinduction_id"),System.Web.UI.HtmlControls.HtmlInputHidden)
            CType(Page,CCPage).ControlAttributes.Add(STAFF_INDUCTIONS_PROGRESSRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFF_INDUCTIONS_PROGRESSCurrentRowNumber), AttributeOption.Multiple)
            STAFF_INDUCTIONS_PROGRESSSTAFF_ID.Items.Add(new ListItem("Select Value",""))
            STAFF_INDUCTIONS_PROGRESSSTAFF_ID.Items(0).Selected = True
            DataItem.STAFF_IDItems.SetSelection(DataItem.STAFF_ID.GetFormattedValue())
            If Not DataItem.STAFF_IDItems.GetSelectedItem() Is Nothing Then
                STAFF_INDUCTIONS_PROGRESSSTAFF_ID.SelectedIndex = -1
            End If
            DataItem.STAFF_IDItems.CopyTo(STAFF_INDUCTIONS_PROGRESSSTAFF_ID.Items)
            STAFF_INDUCTIONS_PROGRESSSTATUS.Items.Add(new ListItem("Select Value",""))
            STAFF_INDUCTIONS_PROGRESSSTATUS.Items(0).Selected = True
            DataItem.STATUSItems.SetSelection(DataItem.STATUS.GetFormattedValue())
            If Not DataItem.STATUSItems.GetSelectedItem() Is Nothing Then
                STAFF_INDUCTIONS_PROGRESSSTATUS.SelectedIndex = -1
            End If
            DataItem.STATUSItems.CopyTo(STAFF_INDUCTIONS_PROGRESSSTATUS.Items)
            STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName = "STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED"
            STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl = e.Item.FindControl("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED").ClientID
            STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.DataBind()
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                STAFF_INDUCTIONS_PROGRESSCheckBox_Delete.Checked = True
            End If
        End If
'End EditableGrid STAFF_INDUCTIONS_PROGRESS ItemDataBound event

'EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeShowRow event @36-41CE7B5B
        If Not IsNothing(Item) Then STAFF_INDUCTIONS_PROGRESSDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeShowRow event

'EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeShowRow event tail @36-477CF3C9
        End If
'End EditableGrid STAFF_INDUCTIONS_PROGRESS BeforeShowRow event tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS ItemDataBound event tail @36-E31F8E2A
    End Sub
'End EditableGrid STAFF_INDUCTIONS_PROGRESS ItemDataBound event tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS GetRedirectUrl method @36-053CE9C9
    Protected Function GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl(ByVal redirectString As String) As String
        Return GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid STAFF_INDUCTIONS_PROGRESS GetRedirectUrl method

'EditableGrid STAFF_INDUCTIONS_PROGRESS ShowErrors method @36-FD727CAC
    Protected Function STAFF_INDUCTIONS_PROGRESSShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).IsUpdated Then col(CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).RowId).Visible = False
            If (CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).errors.Count - 1
                Select CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), STAFF_INDUCTIONS_PROGRESSItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid STAFF_INDUCTIONS_PROGRESS ShowErrors method

'EditableGrid STAFF_INDUCTIONS_PROGRESS ItemCommand event @36-795A3E62
    Protected Sub STAFF_INDUCTIONS_PROGRESSItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = STAFF_INDUCTIONS_PROGRESSRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid STAFF_INDUCTIONS_PROGRESS ItemCommand event

'Button Button_Submit OnClick. @53-1AA21501
        If Ctype(e.CommandSource,Control).ID = "STAFF_INDUCTIONS_PROGRESSButton_Submit" Then
            RedirectUrl  = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @53-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @54-A397D539
        If Ctype(e.CommandSource,Control).ID = "STAFF_INDUCTIONS_PROGRESSCancel" Then
            RedirectUrl  = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @54-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form STAFF_INDUCTIONS_PROGRESS ItemCommand event tail @36-085C5C87
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("STAFF_INDUCTIONS_PROGRESSSortDir"), SortDirections) = SortDirections._Asc And ViewState("STAFF_INDUCTIONS_PROGRESSSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("STAFF_INDUCTIONS_PROGRESSSortDir") = SortDirections._Desc
                Else
                    ViewState("STAFF_INDUCTIONS_PROGRESSSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("STAFF_INDUCTIONS_PROGRESSSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As STAFF_INDUCTIONS_PROGRESSDataProvider.SortFields = 0
            ViewState("STAFF_INDUCTIONS_PROGRESSSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("STAFF_INDUCTIONS_PROGRESSPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("STAFF_INDUCTIONS_PROGRESSPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("STAFF_INDUCTIONS_PROGRESSPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFF_INDUCTIONS_PROGRESSPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            STAFF_INDUCTIONS_PROGRESSIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = STAFF_INDUCTIONS_PROGRESSRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("STAFF_INDUCTIONS_PROGRESSFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("STAFF_INDUCTIONS_PROGRESSRowState"), Hashtable)
            STAFF_INDUCTIONS_PROGRESSParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim STAFF_INDUCTIONS_PROGRESSSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim STAFF_INDUCTIONS_PROGRESSSTATUS As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSSTATUS"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED"),System.Web.UI.WebControls.TextBox)
                    Dim STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED"),System.Web.UI.WebControls.PlaceHolder)
                    Dim STAFF_INDUCTIONS_PROGRESSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim STAFF_INDUCTIONS_PROGRESSinduction_id As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSinduction_id"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.IsDeleted = (CType(col(i).FindControl("STAFF_INDUCTIONS_PROGRESSCheckBox_Delete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.STAFF_ID.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSSTAFF_ID.UniqueID))
                    item.STAFF_ID.SetValue(STAFF_INDUCTIONS_PROGRESSSTAFF_ID.Value)
                    item.STAFF_IDItems.CopyFrom(STAFF_INDUCTIONS_PROGRESSSTAFF_ID.Items)
                    item.STATUS.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSSTATUS.UniqueID))
                    item.STATUS.SetValue(STAFF_INDUCTIONS_PROGRESSSTATUS.Value)
                    item.STATUSItems.CopyFrom(STAFF_INDUCTIONS_PROGRESSSTATUS.Items)
                    Try
                    item.DATE_COMPLETED.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.UniqueID))
                    If ControlCustomValues("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED") Is Nothing Then
                        item.DATE_COMPLETED.SetValue(STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.Text)
                    Else
                        item.DATE_COMPLETED.SetValue(ControlCustomValues("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("DATE_COMPLETED",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE COMPLETED","dd/mm/yyyy"))
                    End Try
                    Try
                    item.induction_id.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSinduction_id.UniqueID))
                    item.induction_id.SetValue(STAFF_INDUCTIONS_PROGRESSinduction_id.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("induction_id",String.Format(Resources.strings.CCS_IncorrectValue,"Induction Id"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(STAFF_INDUCTIONS_PROGRESSData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form STAFF_INDUCTIONS_PROGRESS ItemCommand event tail

'EditableGrid STAFF_INDUCTIONS_PROGRESS Event OnValidate. Action Custom Code @62-73254650
    ' -------------------------
    'ERA: check for duplicate Staff ID
		' check that a staff member hasn't been added twice.
		Dim	temp As NameValueCollection	= new NameValueCollection()
		Dim j As Integer
		for j = 0 To  items.Count -1 

			Dim myitem As STAFF_INDUCTIONS_PROGRESSItem  = DirectCast(items(j),STAFF_INDUCTIONS_PROGRESSItem)
			If IsNothing(myitem.STAFF_ID.Value) Then 
				temp.Add("e" & j,"")
			else 
				temp.Add(myitem.STAFF_ID.GetFormattedValue(),"")
			End If
			If temp.Count < j + 1 Then 
				myitem.errors.Add("STAFF_ID","A Staff Member cannot be added twice.")
				temp.Add("separator","separator")
				BindAllowed = false
			End If
		Next j
    ' -------------------------
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Event OnValidate. Action Custom Code

'EditableGrid STAFF_INDUCTIONS_PROGRESS Update @36-0E7F9770
            If BindAllowed Then
                Try
                    STAFF_INDUCTIONS_PROGRESSParameters()
                    STAFF_INDUCTIONS_PROGRESSData.Update(items, STAFF_INDUCTIONS_PROGRESSOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(STAFF_INDUCTIONS_PROGRESSRepeater.Controls(0).FindControl("STAFF_INDUCTIONS_PROGRESSError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid STAFF_INDUCTIONS_PROGRESS Update

'EditableGrid STAFF_INDUCTIONS_PROGRESS After Update @36-A8979290
                End Try
                If STAFF_INDUCTIONS_PROGRESSShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                STAFF_INDUCTIONS_PROGRESSShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                STAFF_INDUCTIONS_PROGRESSBind()
            End If
        End Sub
'End EditableGrid STAFF_INDUCTIONS_PROGRESS After Update

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A4A160C4
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_Inductions_ByCourseContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_INDUCTIONS_COURSESData = New STAFF_INDUCTIONS_COURSESDataProvider()
        STAFF_INDUCTIONS_COURSESOperations = New FormSupportedOperations(False, True, False, False, False)
        STAFF_INDUCTIONS_COURSESSearchData = New STAFF_INDUCTIONS_COURSESSearchDataProvider()
        STAFF_INDUCTIONS_COURSESSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STAFF_INDUCTIONS_COURSES1Data = New STAFF_INDUCTIONS_COURSES1DataProvider()
        STAFF_INDUCTIONS_COURSES1Operations = New FormSupportedOperations(False, True, True, True, False)
        STAFF_INDUCTIONS_PROGRESSData = New STAFF_INDUCTIONS_PROGRESSDataProvider()
        STAFF_INDUCTIONS_PROGRESSOperations = New FormSupportedOperations(False, True, True, True, True)
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

