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

Namespace DECV_PROD2007.Student_Comments_Search 'Namespace @1-43FFF762

'Forms Definition @1-12EB30B9
Public Class [Student_Comments_SearchPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-6C4AD9FB
    Protected Grid_CommentsResultsData As Grid_CommentsResultsDataProvider
    Protected Grid_CommentsResultsOperations As FormSupportedOperations
    Protected Grid_CommentsResultsCurrentRowNumber As Integer
    Protected Search_CommentsData As Search_CommentsDataProvider
    Protected Search_CommentsErrors As NameValueCollection = New NameValueCollection()
    Protected Search_CommentsOperations As FormSupportedOperations
    Protected Search_CommentsIsSubmitted As Boolean = False
    Protected Grid_CommentsResults1Data As Grid_CommentsResults1DataProvider
    Protected Grid_CommentsResults1Operations As FormSupportedOperations
    Protected Grid_CommentsResults1CurrentRowNumber As Integer
    Protected Student_Comments_SearchContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A1CAF156
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Grid_CommentsResultsBind
            Search_CommentsShow()
            Grid_CommentsResults1Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid Grid_CommentsResults Bind @2-A45213EA

    Protected Sub Grid_CommentsResultsBind()
        If Not Grid_CommentsResultsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_CommentsResults",GetType(Grid_CommentsResultsDataProvider.SortFields), 50, 100)
        End If
'End Grid Grid_CommentsResults Bind

'Grid Form Grid_CommentsResults BeforeShow tail @2-503F0078
        Grid_CommentsResultsParameters()
        Grid_CommentsResultsData.SortField = CType(ViewState("Grid_CommentsResultsSortField"),Grid_CommentsResultsDataProvider.SortFields)
        Grid_CommentsResultsData.SortDir = CType(ViewState("Grid_CommentsResultsSortDir"),SortDirections)
        Grid_CommentsResultsData.PageNumber = CInt(ViewState("Grid_CommentsResultsPageNumber"))
        Grid_CommentsResultsData.RecordsPerPage = CInt(ViewState("Grid_CommentsResultsPageSize"))
        Grid_CommentsResultsRepeater.DataSource = Grid_CommentsResultsData.GetResultSet(PagesCount, Grid_CommentsResultsOperations)
        ViewState("Grid_CommentsResultsPagesCount") = PagesCount
        Dim item As Grid_CommentsResultsItem = New Grid_CommentsResultsItem()
        Grid_CommentsResultsRepeater.DataBind
        FooterIndex = Grid_CommentsResultsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_CommentsResultsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Grid_CommentsResultsGrid1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Grid_CommentsResultsGrid1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENTSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Sorter_COMMENTSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENT_TYPESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Sorter_COMMENT_TYPESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(Grid_CommentsResultsRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Grid_CommentsResultslblMostRecent50 As System.Web.UI.WebControls.Literal = DirectCast(Grid_CommentsResultsRepeater.Controls(0).FindControl("Grid_CommentsResultslblMostRecent50"),System.Web.UI.WebControls.Literal)

        Grid_CommentsResultsGrid1_TotalRecords.Text = Server.HtmlEncode(item.Grid1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Grid_CommentsResultslblMostRecent50.Text = item.lblMostRecent50.GetFormattedValue()
'End Grid Form Grid_CommentsResults BeforeShow tail

'Label Grid1_TotalRecords Event BeforeShow. Action Retrieve number of records @7-FF96C86C
            Grid_CommentsResultsGrid1_TotalRecords.Text = Grid_CommentsResultsData.RecordCount.ToString()
'End Label Grid1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid Grid_CommentsResults Event BeforeShow. Action Hide-Show Component @33-FF6A74D4
        Dim Urls_keywords_33_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_keywords"))
        Dim ExprParam2_33_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(Urls_keywords_33_1, ExprParam2_33_2) Then
            Grid_CommentsResultsRepeater.Visible = False
        End If
'End Grid Grid_CommentsResults Event BeforeShow. Action Hide-Show Component

'Grid Grid_CommentsResults Bind tail @2-E31F8E2A
    End Sub
'End Grid Grid_CommentsResults Bind tail

'Grid Grid_CommentsResults Table Parameters @2-F953150C

    Protected Sub Grid_CommentsResultsParameters()
        Try
            Grid_CommentsResultsData.Expr60 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=Grid_CommentsResultsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_CommentsResultsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_CommentsResults: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_CommentsResults Table Parameters

'Grid Grid_CommentsResults ItemDataBound event @2-3E55B632

    Protected Sub Grid_CommentsResultsItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_CommentsResultsItem = CType(e.Item.DataItem,Grid_CommentsResultsItem)
        Dim Item as Grid_CommentsResultsItem = DataItem
        Dim FormDataSource As Grid_CommentsResultsItem() = CType(Grid_CommentsResultsRepeater.DataSource, Grid_CommentsResultsItem())
        Dim Grid_CommentsResultsDataRows As Integer = FormDataSource.Length
        Dim Grid_CommentsResultsIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_CommentsResultsCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_CommentsResultsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_CommentsResultsCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_CommentsResultsSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_CommentsResultsSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid_CommentsResultsCOMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResultsCOMMENT"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResultsLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResultsLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResultsLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResultsLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResultsCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResultsCOMMENT_TYPE"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            DataItem.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((Year(Now())).ToString()))
            Grid_CommentsResultsSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","ENROLMENT_YEAR;STUDENT_ID", ViewState)
        End If
'End Grid Grid_CommentsResults ItemDataBound event

'Grid Grid_CommentsResults ItemDataBound event tail @2-01334166
        If Grid_CommentsResultsIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_CommentsResultsCurrentRowNumber, ListItemType.Item)
            Grid_CommentsResultsRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_CommentsResultsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_CommentsResults ItemDataBound event tail

'Grid Grid_CommentsResults ItemCommand event @2-3D312630

    Protected Sub Grid_CommentsResultsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_CommentsResultsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_CommentsResultsSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_CommentsResultsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_CommentsResultsSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_CommentsResultsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_CommentsResultsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_CommentsResultsDataProvider.SortFields = 0
            ViewState("Grid_CommentsResultsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_CommentsResultsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_CommentsResultsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_CommentsResultsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_CommentsResultsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_CommentsResultsBind
        End If
    End Sub
'End Grid Grid_CommentsResults ItemCommand event

'Record Form Search_Comments Parameters @19-48B79919

    Protected Sub Search_CommentsParameters()
        Dim item As new Search_CommentsItem
        Try
        Catch e As Exception
            Search_CommentsErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form Search_Comments Parameters

'Record Form Search_Comments Show method @19-148C5146
    Protected Sub Search_CommentsShow()
        If Search_CommentsOperations.None Then
            Search_CommentsHolder.Visible = False
            Return
        End If
        Dim item As Search_CommentsItem = Search_CommentsItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not Search_CommentsOperations.AllowRead
        item.ClearParametersHref = "Student_Comments_Search.aspx"
        item.linkAirHeadHref = "Student_Comments_Search.aspx"
        Search_CommentsErrors.Add(item.errors)
        If Search_CommentsErrors.Count > 0 Then
            Search_CommentsShowErrors()
            Return
        End If
'End Record Form Search_Comments Show method

'Record Form Search_Comments BeforeShow tail @19-B33BDB21
        Search_CommentsParameters()
        Search_CommentsData.FillItem(item, IsInsertMode)
        Search_CommentsHolder.DataBind()
        Search_Commentss_keywords.Text=item.s_keywords.GetFormattedValue()
        Search_Commentss_monthsago.Items.Add(new ListItem("Select Value",""))
        Search_Commentss_monthsago.Items(0).Selected = True
        item.s_monthsagoItems.SetSelection(item.s_monthsago.GetFormattedValue())
        If Not item.s_monthsagoItems.GetSelectedItem() Is Nothing Then
            Search_Commentss_monthsago.SelectedIndex = -1
        End If
        item.s_monthsagoItems.CopyTo(Search_Commentss_monthsago.Items)
        Search_CommentsClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        Search_CommentsClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("None","s_keywords;s_monthsago", ViewState)
        Search_CommentslinkAirHead.InnerText += item.linkAirHead.GetFormattedValue().Replace(vbCrLf,"")
        Search_CommentslinkAirHead.HRef = item.linkAirHeadHref+item.linkAirHeadHrefParameters.ToString("GET","s_keywords;s_monthsago", ViewState)
'End Record Form Search_Comments BeforeShow tail

'Record Form Search_Comments Show method tail @19-39BDA4C8
        If Search_CommentsErrors.Count > 0 Then
            Search_CommentsShowErrors()
        End If
    End Sub
'End Record Form Search_Comments Show method tail

'Record Form Search_Comments LoadItemFromRequest method @19-7A391599

    Protected Sub Search_CommentsLoadItemFromRequest(item As Search_CommentsItem, ByVal EnableValidation As Boolean)
        item.s_keywords.IsEmpty = IsNothing(Request.Form(Search_Commentss_keywords.UniqueID))
        If ControlCustomValues("Search_Commentss_keywords") Is Nothing Then
            item.s_keywords.SetValue(Search_Commentss_keywords.Text)
        Else
            item.s_keywords.SetValue(ControlCustomValues("Search_Commentss_keywords"))
        End If
        Try
        item.s_monthsago.IsEmpty = IsNothing(Request.Form(Search_Commentss_monthsago.UniqueID))
        item.s_monthsago.SetValue(Search_Commentss_monthsago.Value)
        item.s_monthsagoItems.CopyFrom(Search_Commentss_monthsago.Items)
        Catch ae As ArgumentException
            Search_CommentsErrors.Add("s_monthsago",String.Format(Resources.strings.CCS_IncorrectValue,"Months ago"))
        End Try
        If EnableValidation Then
            item.Validate(Search_CommentsData)
        End If
        Search_CommentsErrors.Add(item.errors)
    End Sub
'End Record Form Search_Comments LoadItemFromRequest method

'Record Form Search_Comments GetRedirectUrl method @19-3F2DDA2F

    Protected Function GetSearch_CommentsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Comments_Search.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form Search_Comments GetRedirectUrl method

'Record Form Search_Comments ShowErrors method @19-583725C8

    Protected Sub Search_CommentsShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To Search_CommentsErrors.Count - 1
        Select Case Search_CommentsErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & Search_CommentsErrors(i)
        End Select
        Next i
        Search_CommentsError.Visible = True
        Search_CommentsErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form Search_Comments ShowErrors method

'Record Form Search_Comments Insert Operation @19-367E02D9

    Protected Sub Search_Comments_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        Search_CommentsIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Search_Comments Insert Operation

'Record Form Search_Comments BeforeInsert tail @19-8A6F29CC
    Search_CommentsParameters()
    Search_CommentsLoadItemFromRequest(item, EnableValidation)
'End Record Form Search_Comments BeforeInsert tail

'Record Form Search_Comments AfterInsert tail  @19-60A84B6A
        ErrorFlag=(Search_CommentsErrors.Count > 0)
        If ErrorFlag Then
            Search_CommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Search_Comments AfterInsert tail 

'Record Form Search_Comments Update Operation @19-E20DBE2D

    Protected Sub Search_Comments_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        Search_CommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Search_Comments Update Operation

'Record Form Search_Comments Before Update tail @19-8A6F29CC
        Search_CommentsParameters()
        Search_CommentsLoadItemFromRequest(item, EnableValidation)
'End Record Form Search_Comments Before Update tail

'Record Form Search_Comments Update Operation tail @19-60A84B6A
        ErrorFlag=(Search_CommentsErrors.Count > 0)
        If ErrorFlag Then
            Search_CommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Search_Comments Update Operation tail

'Record Form Search_Comments Delete Operation @19-617BBD45
    Protected Sub Search_Comments_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        Search_CommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form Search_Comments Delete Operation

'Record Form BeforeDelete tail @19-8A6F29CC
        Search_CommentsParameters()
        Search_CommentsLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @19-4310BD15
        If ErrorFlag Then
            Search_CommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form Search_Comments Cancel Operation @19-04EBB5F0

    Protected Sub Search_Comments_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        Search_CommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Search_CommentsLoadItemFromRequest(item, True)
'End Record Form Search_Comments Cancel Operation

'Record Form Search_Comments Cancel Operation tail @19-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form Search_Comments Cancel Operation tail

'Record Form Search_Comments Search Operation @19-B2B0540A
    Protected Sub Search_Comments_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        Search_CommentsIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As Search_CommentsItem = New Search_CommentsItem()
        Search_CommentsLoadItemFromRequest(item, EnableValidation)
'End Record Form Search_Comments Search Operation

'Button Button_DoSearch OnClick. @20-A2E5DF1A
        If CType(sender,Control).ID = "Search_CommentsButton_DoSearch" Then
            RedirectUrl = GetSearch_CommentsRedirectUrl("", "s_keywords;s_monthsago")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @20-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form Search_Comments Search Operation tail @19-D08360FC
        ErrorFlag = Search_CommentsErrors.Count > 0
        If ErrorFlag Then
            Search_CommentsShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(Search_Commentss_keywords.Text <> "",("s_keywords=" & Server.UrlEncode(Search_Commentss_keywords.Text) & "&"), "")
            For Each li In Search_Commentss_monthsago.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_monthsago=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form Search_Comments Search Operation tail

'Grid Grid_CommentsResults1 Bind @38-E0B775F0

    Protected Sub Grid_CommentsResults1Bind()
        If Not Grid_CommentsResults1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_CommentsResults1",GetType(Grid_CommentsResults1DataProvider.SortFields), 50, 100)
        End If
'End Grid Grid_CommentsResults1 Bind

'Grid Form Grid_CommentsResults1 BeforeShow tail @38-8D3608A1
        Grid_CommentsResults1Parameters()
        Grid_CommentsResults1Data.SortField = CType(ViewState("Grid_CommentsResults1SortField"),Grid_CommentsResults1DataProvider.SortFields)
        Grid_CommentsResults1Data.SortDir = CType(ViewState("Grid_CommentsResults1SortDir"),SortDirections)
        Grid_CommentsResults1Data.PageNumber = CInt(ViewState("Grid_CommentsResults1PageNumber"))
        Grid_CommentsResults1Data.RecordsPerPage = CInt(ViewState("Grid_CommentsResults1PageSize"))
        Grid_CommentsResults1Repeater.DataSource = Grid_CommentsResults1Data.GetResultSet(PagesCount, Grid_CommentsResults1Operations)
        ViewState("Grid_CommentsResults1PagesCount") = PagesCount
        Dim item As Grid_CommentsResults1Item = New Grid_CommentsResults1Item()
        Grid_CommentsResults1Repeater.DataBind
        FooterIndex = Grid_CommentsResults1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_CommentsResults1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Grid_CommentsResults1Grid1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Grid_CommentsResults1Grid1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENTSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Sorter_COMMENTSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENT_TYPESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid_CommentsResults1Repeater.Controls(0).FindControl("Sorter_COMMENT_TYPESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(Grid_CommentsResults1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        Grid_CommentsResults1Grid1_TotalRecords.Text = Server.HtmlEncode(item.Grid1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form Grid_CommentsResults1 BeforeShow tail

'Label Grid1_TotalRecords Event BeforeShow. Action Retrieve number of records @40-07A66DCC
            Grid_CommentsResults1Grid1_TotalRecords.Text = Grid_CommentsResults1Data.RecordCount.ToString()
'End Label Grid1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid Grid_CommentsResults1 Event BeforeShow. Action Hide-Show Component @56-549B79A8
        Dim Urls_keywords_56_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_keywords"))
        Dim ExprParam2_56_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_keywords_56_1, ExprParam2_56_2) Then
            Grid_CommentsResults1Repeater.Visible = False
        End If
'End Grid Grid_CommentsResults1 Event BeforeShow. Action Hide-Show Component

'Grid Grid_CommentsResults1 Bind tail @38-E31F8E2A
    End Sub
'End Grid Grid_CommentsResults1 Bind tail

'Grid Grid_CommentsResults1 Table Parameters @38-9D975824

    Protected Sub Grid_CommentsResults1Parameters()
        Try
            Grid_CommentsResults1Data.Urls_keywords = TextParameter.GetParam("s_keywords", ParameterSourceType.URL, "", "z", false)
            Grid_CommentsResults1Data.Urls_monthsago = IntegerParameter.GetParam("s_monthsago", ParameterSourceType.URL, "", -1, false)
            Grid_CommentsResults1Data.Expr67 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=Grid_CommentsResults1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_CommentsResults1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_CommentsResults1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_CommentsResults1 Table Parameters

'Grid Grid_CommentsResults1 ItemDataBound event @38-3E11B464

    Protected Sub Grid_CommentsResults1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_CommentsResults1Item = CType(e.Item.DataItem,Grid_CommentsResults1Item)
        Dim Item as Grid_CommentsResults1Item = DataItem
        Dim FormDataSource As Grid_CommentsResults1Item() = CType(Grid_CommentsResults1Repeater.DataSource, Grid_CommentsResults1Item())
        Dim Grid_CommentsResults1DataRows As Integer = FormDataSource.Length
        Dim Grid_CommentsResults1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_CommentsResults1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_CommentsResults1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_CommentsResults1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_CommentsResults1STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_CommentsResults1STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid_CommentsResults1COMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResults1COMMENT"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResults1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResults1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResults1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResults1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim Grid_CommentsResults1COMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_CommentsResults1COMMENT_TYPE"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            DataItem.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((Year(Now())).ToString()))
            Grid_CommentsResults1STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","ENROLMENT_YEAR;STUDENT_ID", ViewState)
        End If
'End Grid Grid_CommentsResults1 ItemDataBound event

'Grid Grid_CommentsResults1 ItemDataBound event tail @38-D9364361
        If Grid_CommentsResults1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_CommentsResults1CurrentRowNumber, ListItemType.Item)
            Grid_CommentsResults1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_CommentsResults1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_CommentsResults1 ItemDataBound event tail

'Grid Grid_CommentsResults1 ItemCommand event @38-B78720D3

    Protected Sub Grid_CommentsResults1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_CommentsResults1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_CommentsResults1SortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_CommentsResults1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_CommentsResults1SortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_CommentsResults1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_CommentsResults1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_CommentsResults1DataProvider.SortFields = 0
            ViewState("Grid_CommentsResults1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_CommentsResults1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_CommentsResults1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_CommentsResults1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_CommentsResults1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_CommentsResults1Bind
        End If
    End Sub
'End Grid Grid_CommentsResults1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-226B7E4C
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Comments_SearchContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Grid_CommentsResultsData = New Grid_CommentsResultsDataProvider()
        Grid_CommentsResultsOperations = New FormSupportedOperations(False, True, False, False, False)
        Search_CommentsData = New Search_CommentsDataProvider()
        Search_CommentsOperations = New FormSupportedOperations(False, True, True, True, True)
        Grid_CommentsResults1Data = New Grid_CommentsResults1DataProvider()
        Grid_CommentsResults1Operations = New FormSupportedOperations(False, True, False, False, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

