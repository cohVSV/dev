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

Namespace DECV_PROD2007.REF_MODULE_CODES 'Namespace @1-33F3CD35

'Forms Definition @1-310E2BD0
Public Class [REF_MODULE_CODESPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EAF987A8
    Protected REF_MODULE_CODES1Data As REF_MODULE_CODES1DataProvider
    Protected REF_MODULE_CODES1Operations As FormSupportedOperations
    Protected REF_MODULE_CODES1CurrentRowNumber As Integer
    Protected REF_MODULE_CODESSearchData As REF_MODULE_CODESSearchDataProvider
    Protected REF_MODULE_CODESSearchErrors As NameValueCollection = New NameValueCollection()
    Protected REF_MODULE_CODESSearchOperations As FormSupportedOperations
    Protected REF_MODULE_CODESSearchIsSubmitted As Boolean = False
    Protected REF_MODULE_CODES2Data As REF_MODULE_CODES2DataProvider
    Protected REF_MODULE_CODES2Errors As NameValueCollection = New NameValueCollection()
    Protected REF_MODULE_CODES2Operations As FormSupportedOperations
    Protected REF_MODULE_CODES2IsSubmitted As Boolean = False
    Protected REF_MODULE_CODESContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CA728ABC
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.REF_MODULE_CODES1_InsertHref = "REF_MODULE_CODES.aspx"
            PageData.FillItem(item)
            REF_MODULE_CODES1_Insert.InnerText += item.REF_MODULE_CODES1_Insert.GetFormattedValue().Replace(vbCrLf,"")
            REF_MODULE_CODES1_Insert.HRef = item.REF_MODULE_CODES1_InsertHref+item.REF_MODULE_CODES1_InsertHrefParameters.ToString("GET","MODULE_CODE", ViewState)
            REF_MODULE_CODES1_Insert.DataBind()
            REF_MODULE_CODES1Bind
            REF_MODULE_CODESSearchShow()
            REF_MODULE_CODES2Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

'BeforeOutput Event @1-E563A382
Private Sub BeforeOutput(MainHTML As String, responseStream As Stream, ByRef Result As Boolean)
Result  = True
'End BeforeOutput Event

'BeforeOutput Event tail @1-E31F8E2A
End Sub
'End BeforeOutput Event tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid REF_MODULE_CODES1 Bind @9-136743D2

    Protected Sub REF_MODULE_CODES1Bind()
        If Not REF_MODULE_CODES1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"REF_MODULE_CODES1",GetType(REF_MODULE_CODES1DataProvider.SortFields), 40, 100)
        End If
'End Grid REF_MODULE_CODES1 Bind

'Grid Form REF_MODULE_CODES1 BeforeShow tail @9-B295FA67
        REF_MODULE_CODES1Parameters()
        REF_MODULE_CODES1Data.SortField = CType(ViewState("REF_MODULE_CODES1SortField"),REF_MODULE_CODES1DataProvider.SortFields)
        REF_MODULE_CODES1Data.SortDir = CType(ViewState("REF_MODULE_CODES1SortDir"),SortDirections)
        REF_MODULE_CODES1Data.PageNumber = CInt(ViewState("REF_MODULE_CODES1PageNumber"))
        REF_MODULE_CODES1Data.RecordsPerPage = CInt(ViewState("REF_MODULE_CODES1PageSize"))
        REF_MODULE_CODES1Repeater.DataSource = REF_MODULE_CODES1Data.GetResultSet(PagesCount, REF_MODULE_CODES1Operations)
        ViewState("REF_MODULE_CODES1PagesCount") = PagesCount
        Dim item As REF_MODULE_CODES1Item = New REF_MODULE_CODES1Item()
        REF_MODULE_CODES1Repeater.DataBind
        FooterIndex = REF_MODULE_CODES1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            REF_MODULE_CODES1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim REF_MODULE_CODES1REF_MODULE_CODES1_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(REF_MODULE_CODES1Repeater.Controls(FooterIndex).FindControl("REF_MODULE_CODES1REF_MODULE_CODES1_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim REF_MODULE_CODES1REF_MODULE_CODES1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("REF_MODULE_CODES1REF_MODULE_CODES1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_MODULE_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_MODULE_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MODULE_LABELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_MODULE_LABELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEMESTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_SEMESTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PRIMARY_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_PRIMARY_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(REF_MODULE_CODES1Repeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(REF_MODULE_CODES1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.REF_MODULE_CODES1_InsertHref = "REF_MODULE_CODES.aspx"
        REF_MODULE_CODES1REF_MODULE_CODES1_Insert.InnerText += item.REF_MODULE_CODES1_Insert.GetFormattedValue().Replace(vbCrLf,"")
        REF_MODULE_CODES1REF_MODULE_CODES1_Insert.HRef = item.REF_MODULE_CODES1_InsertHref+item.REF_MODULE_CODES1_InsertHrefParameters.ToString("GET","MODULE_CODE", ViewState)
        REF_MODULE_CODES1REF_MODULE_CODES1_TotalRecords.Text = Server.HtmlEncode(item.REF_MODULE_CODES1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form REF_MODULE_CODES1 BeforeShow tail

'Label REF_MODULE_CODES1_TotalRecords Event BeforeShow. Action Retrieve number of records @12-31A3DD20
            REF_MODULE_CODES1REF_MODULE_CODES1_TotalRecords.Text = REF_MODULE_CODES1Data.RecordCount.ToString()
'End Label REF_MODULE_CODES1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid REF_MODULE_CODES1 Bind tail @9-E31F8E2A
    End Sub
'End Grid REF_MODULE_CODES1 Bind tail

'Grid REF_MODULE_CODES1 Table Parameters @9-08FF1A81

    Protected Sub REF_MODULE_CODES1Parameters()
        Try
            REF_MODULE_CODES1Data.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=REF_MODULE_CODES1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(REF_MODULE_CODES1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid REF_MODULE_CODES1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid REF_MODULE_CODES1 Table Parameters

'Grid REF_MODULE_CODES1 ItemDataBound event @9-72395044

    Protected Sub REF_MODULE_CODES1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as REF_MODULE_CODES1Item = CType(e.Item.DataItem,REF_MODULE_CODES1Item)
        Dim Item as REF_MODULE_CODES1Item = DataItem
        Dim FormDataSource As REF_MODULE_CODES1Item() = CType(REF_MODULE_CODES1Repeater.DataSource, REF_MODULE_CODES1Item())
        Dim REF_MODULE_CODES1DataRows As Integer = FormDataSource.Length
        Dim REF_MODULE_CODES1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            REF_MODULE_CODES1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(REF_MODULE_CODES1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, REF_MODULE_CODES1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim REF_MODULE_CODES1Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("REF_MODULE_CODES1Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim REF_MODULE_CODES1MODULE_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1MODULE_CODE"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1MODULE_LABEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1MODULE_LABEL"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1SEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1SEMESTER"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1PRIMARY_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1PRIMARY_FLAG"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1STATUS"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim REF_MODULE_CODES1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("REF_MODULE_CODES1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "REF_MODULE_CODES.aspx"
            REF_MODULE_CODES1Detail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid REF_MODULE_CODES1 ItemDataBound event

'Grid REF_MODULE_CODES1 ItemDataBound event tail @9-8F3B89CE
        If REF_MODULE_CODES1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(REF_MODULE_CODES1CurrentRowNumber, ListItemType.Item)
            REF_MODULE_CODES1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            REF_MODULE_CODES1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid REF_MODULE_CODES1 ItemDataBound event tail

'Grid REF_MODULE_CODES1 ItemCommand event @9-F839F198

    Protected Sub REF_MODULE_CODES1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= REF_MODULE_CODES1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("REF_MODULE_CODES1SortDir"),SortDirections) = SortDirections._Asc And ViewState("REF_MODULE_CODES1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("REF_MODULE_CODES1SortDir")=SortDirections._Desc
                Else
                    ViewState("REF_MODULE_CODES1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("REF_MODULE_CODES1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As REF_MODULE_CODES1DataProvider.SortFields = 0
            ViewState("REF_MODULE_CODES1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("REF_MODULE_CODES1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("REF_MODULE_CODES1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("REF_MODULE_CODES1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("REF_MODULE_CODES1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            REF_MODULE_CODES1Bind
        End If
    End Sub
'End Grid REF_MODULE_CODES1 ItemCommand event

'Record Form REF_MODULE_CODESSearch Parameters @40-0BF4C8F8

    Protected Sub REF_MODULE_CODESSearchParameters()
        Dim item As new REF_MODULE_CODESSearchItem
        Try
        Catch e As Exception
            REF_MODULE_CODESSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form REF_MODULE_CODESSearch Parameters

'Record Form REF_MODULE_CODESSearch Show method @40-A9FB8916
    Protected Sub REF_MODULE_CODESSearchShow()
        If REF_MODULE_CODESSearchOperations.None Then
            REF_MODULE_CODESSearchHolder.Visible = False
            Return
        End If
        Dim item As REF_MODULE_CODESSearchItem = REF_MODULE_CODESSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not REF_MODULE_CODESSearchOperations.AllowRead
        item.ClearParametersHref = "REF_MODULE_CODES.aspx"
        REF_MODULE_CODESSearchErrors.Add(item.errors)
        If REF_MODULE_CODESSearchErrors.Count > 0 Then
            REF_MODULE_CODESSearchShowErrors()
            Return
        End If
'End Record Form REF_MODULE_CODESSearch Show method

'Record Form REF_MODULE_CODESSearch BeforeShow tail @40-F197C300
        REF_MODULE_CODESSearchParameters()
        REF_MODULE_CODESSearchData.FillItem(item, IsInsertMode)
        REF_MODULE_CODESSearchHolder.DataBind()
        REF_MODULE_CODESSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        REF_MODULE_CODESSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        REF_MODULE_CODESSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form REF_MODULE_CODESSearch BeforeShow tail

'Record Form REF_MODULE_CODESSearch Show method tail @40-7653D8B6
        If REF_MODULE_CODESSearchErrors.Count > 0 Then
            REF_MODULE_CODESSearchShowErrors()
        End If
    End Sub
'End Record Form REF_MODULE_CODESSearch Show method tail

'Record Form REF_MODULE_CODESSearch LoadItemFromRequest method @40-86F22276

    Protected Sub REF_MODULE_CODESSearchLoadItemFromRequest(item As REF_MODULE_CODESSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODESSearchs_keyword.UniqueID))
        If ControlCustomValues("REF_MODULE_CODESSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(REF_MODULE_CODESSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("REF_MODULE_CODESSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(REF_MODULE_CODESSearchData)
        End If
        REF_MODULE_CODESSearchErrors.Add(item.errors)
    End Sub
'End Record Form REF_MODULE_CODESSearch LoadItemFromRequest method

'Record Form REF_MODULE_CODESSearch GetRedirectUrl method @40-3AD76678

    Protected Function GetREF_MODULE_CODESSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "REF_MODULE_CODES.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form REF_MODULE_CODESSearch GetRedirectUrl method

'Record Form REF_MODULE_CODESSearch ShowErrors method @40-8775F584

    Protected Sub REF_MODULE_CODESSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To REF_MODULE_CODESSearchErrors.Count - 1
        Select Case REF_MODULE_CODESSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & REF_MODULE_CODESSearchErrors(i)
        End Select
        Next i
        REF_MODULE_CODESSearchError.Visible = True
        REF_MODULE_CODESSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form REF_MODULE_CODESSearch ShowErrors method

'Record Form REF_MODULE_CODESSearch Insert Operation @40-749E78E5

    Protected Sub REF_MODULE_CODESSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
        REF_MODULE_CODESSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REF_MODULE_CODESSearch Insert Operation

'Record Form REF_MODULE_CODESSearch BeforeInsert tail @40-43489384
    REF_MODULE_CODESSearchParameters()
    REF_MODULE_CODESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form REF_MODULE_CODESSearch BeforeInsert tail

'Record Form REF_MODULE_CODESSearch AfterInsert tail  @40-4BA3C06E
        ErrorFlag=(REF_MODULE_CODESSearchErrors.Count > 0)
        If ErrorFlag Then
            REF_MODULE_CODESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REF_MODULE_CODESSearch AfterInsert tail 

'Record Form REF_MODULE_CODESSearch Update Operation @40-C47630DD

    Protected Sub REF_MODULE_CODESSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        REF_MODULE_CODESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REF_MODULE_CODESSearch Update Operation

'Record Form REF_MODULE_CODESSearch Before Update tail @40-43489384
        REF_MODULE_CODESSearchParameters()
        REF_MODULE_CODESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form REF_MODULE_CODESSearch Before Update tail

'Record Form REF_MODULE_CODESSearch Update Operation tail @40-4BA3C06E
        ErrorFlag=(REF_MODULE_CODESSearchErrors.Count > 0)
        If ErrorFlag Then
            REF_MODULE_CODESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REF_MODULE_CODESSearch Update Operation tail

'Record Form REF_MODULE_CODESSearch Delete Operation @40-6037C528
    Protected Sub REF_MODULE_CODESSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        REF_MODULE_CODESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form REF_MODULE_CODESSearch Delete Operation

'Record Form BeforeDelete tail @40-43489384
        REF_MODULE_CODESSearchParameters()
        REF_MODULE_CODESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @40-8C111383
        If ErrorFlag Then
            REF_MODULE_CODESSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form REF_MODULE_CODESSearch Cancel Operation @40-A3363BBA

    Protected Sub REF_MODULE_CODESSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
        REF_MODULE_CODESSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        REF_MODULE_CODESSearchLoadItemFromRequest(item, True)
'End Record Form REF_MODULE_CODESSearch Cancel Operation

'Record Form REF_MODULE_CODESSearch Cancel Operation tail @40-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form REF_MODULE_CODESSearch Cancel Operation tail

'Record Form REF_MODULE_CODESSearch Search Operation @40-91EA9534
    Protected Sub REF_MODULE_CODESSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        REF_MODULE_CODESSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As REF_MODULE_CODESSearchItem = New REF_MODULE_CODESSearchItem()
        REF_MODULE_CODESSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form REF_MODULE_CODESSearch Search Operation

'Button Button_DoSearch OnClick. @42-EAB69BE9
        If CType(sender,Control).ID = "REF_MODULE_CODESSearchButton_DoSearch" Then
            RedirectUrl = GetREF_MODULE_CODESSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @42-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form REF_MODULE_CODESSearch Search Operation tail @40-961E3D1C
        ErrorFlag = REF_MODULE_CODESSearchErrors.Count > 0
        If ErrorFlag Then
            REF_MODULE_CODESSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(REF_MODULE_CODESSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(REF_MODULE_CODESSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REF_MODULE_CODESSearch Search Operation tail

'Record Form REF_MODULE_CODES2 Parameters @45-F079904D

    Protected Sub REF_MODULE_CODES2Parameters()
        Dim item As new REF_MODULE_CODES2Item
        Try
            REF_MODULE_CODES2Data.UrlMODULE_CODE = TextParameter.GetParam("MODULE_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            REF_MODULE_CODES2Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form REF_MODULE_CODES2 Parameters

'Record Form REF_MODULE_CODES2 Show method @45-7DE77C70
    Protected Sub REF_MODULE_CODES2Show()
        If REF_MODULE_CODES2Operations.None Then
            REF_MODULE_CODES2Holder.Visible = False
            Return
        End If
        Dim item As REF_MODULE_CODES2Item = REF_MODULE_CODES2Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not REF_MODULE_CODES2Operations.AllowRead
        REF_MODULE_CODES2Errors.Add(item.errors)
        If REF_MODULE_CODES2Errors.Count > 0 Then
            REF_MODULE_CODES2ShowErrors()
            Return
        End If
'End Record Form REF_MODULE_CODES2 Show method

'Record Form REF_MODULE_CODES2 BeforeShow tail @45-0919F6CD
        REF_MODULE_CODES2Parameters()
        REF_MODULE_CODES2Data.FillItem(item, IsInsertMode)
        REF_MODULE_CODES2Holder.DataBind()
        REF_MODULE_CODES2Button_Insert.Visible=IsInsertMode AndAlso REF_MODULE_CODES2Operations.AllowInsert
        REF_MODULE_CODES2Button_Update.Visible=Not (IsInsertMode) AndAlso REF_MODULE_CODES2Operations.AllowUpdate
        REF_MODULE_CODES2MODULE_CODE.Text=item.MODULE_CODE.GetFormattedValue()
        REF_MODULE_CODES2MODULE_LABEL.Text=item.MODULE_LABEL.GetFormattedValue()
        item.PRIMARY_FLAGItems.SetSelection(item.PRIMARY_FLAG.GetFormattedValue())
        REF_MODULE_CODES2PRIMARY_FLAG.SelectedIndex = -1
        item.PRIMARY_FLAGItems.CopyTo(REF_MODULE_CODES2PRIMARY_FLAG.Items, True)
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        REF_MODULE_CODES2STATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(REF_MODULE_CODES2STATUS.Items, True)
        REF_MODULE_CODES2SEMESTER.Value = item.SEMESTER.GetFormattedValue()
        REF_MODULE_CODES2LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        REF_MODULE_CODES2LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        REF_MODULE_CODES2lblMODULE_CODE.Text = Server.HtmlEncode(item.lblMODULE_CODE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form REF_MODULE_CODES2 BeforeShow tail

'Record REF_MODULE_CODES2 Event BeforeShow. Action Hide-Show Component @59-FAB61AEA
        Dim IsEditMode_59_1 As BooleanField = New BooleanField(Settings.BoolFormat,Not IsInsertMode)
        Dim ExprParam2_59_2 As BooleanField = New BooleanField(Settings.BoolFormat, (true))
        If FieldBase.EqualOp(IsEditMode_59_1, ExprParam2_59_2) Then
            REF_MODULE_CODES2lblMODULE_CODE.Visible = True
        End If
'End Record REF_MODULE_CODES2 Event BeforeShow. Action Hide-Show Component

'Record REF_MODULE_CODES2 Event BeforeShow. Action Hide-Show Component @60-61B48E77
        Dim IsEditMode_60_1 As BooleanField = New BooleanField(Settings.BoolFormat,Not IsInsertMode)
        Dim ExprParam2_60_2 As BooleanField = New BooleanField(Settings.BoolFormat, (true))
        If FieldBase.EqualOp(IsEditMode_60_1, ExprParam2_60_2) Then
            REF_MODULE_CODES2MODULE_CODE.Visible = False
        End If
'End Record REF_MODULE_CODES2 Event BeforeShow. Action Hide-Show Component

'Record Form REF_MODULE_CODES2 Show method tail @45-F4C23DBF
        If REF_MODULE_CODES2Errors.Count > 0 Then
            REF_MODULE_CODES2ShowErrors()
        End If
    End Sub
'End Record Form REF_MODULE_CODES2 Show method tail

'Record Form REF_MODULE_CODES2 LoadItemFromRequest method @45-7855C8B3

    Protected Sub REF_MODULE_CODES2LoadItemFromRequest(item As REF_MODULE_CODES2Item, ByVal EnableValidation As Boolean)
        item.MODULE_CODE.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2MODULE_CODE.UniqueID))
        If ControlCustomValues("REF_MODULE_CODES2MODULE_CODE") Is Nothing Then
            item.MODULE_CODE.SetValue(REF_MODULE_CODES2MODULE_CODE.Text)
        Else
            item.MODULE_CODE.SetValue(ControlCustomValues("REF_MODULE_CODES2MODULE_CODE"))
        End If
        item.MODULE_LABEL.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2MODULE_LABEL.UniqueID))
        If ControlCustomValues("REF_MODULE_CODES2MODULE_LABEL") Is Nothing Then
            item.MODULE_LABEL.SetValue(REF_MODULE_CODES2MODULE_LABEL.Text)
        Else
            item.MODULE_LABEL.SetValue(ControlCustomValues("REF_MODULE_CODES2MODULE_LABEL"))
        End If
        Try
        item.PRIMARY_FLAG.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2PRIMARY_FLAG.UniqueID))
        If Not IsNothing(REF_MODULE_CODES2PRIMARY_FLAG.SelectedItem) Then
            item.PRIMARY_FLAG.SetValue(REF_MODULE_CODES2PRIMARY_FLAG.SelectedItem.Value)
        Else
            item.PRIMARY_FLAG.Value = Nothing
        End If
        item.PRIMARY_FLAGItems.CopyFrom(REF_MODULE_CODES2PRIMARY_FLAG.Items)
        Catch ae As ArgumentException
            REF_MODULE_CODES2Errors.Add("PRIMARY_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"PRIMARY FLAG"))
        End Try
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2STATUS.UniqueID))
        If Not IsNothing(REF_MODULE_CODES2STATUS.SelectedItem) Then
            item.STATUS.SetValue(REF_MODULE_CODES2STATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(REF_MODULE_CODES2STATUS.Items)
        Catch ae As ArgumentException
            REF_MODULE_CODES2Errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        Try
        item.SEMESTER.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2SEMESTER.UniqueID))
        item.SEMESTER.SetValue(REF_MODULE_CODES2SEMESTER.Value)
        Catch ae As ArgumentException
            REF_MODULE_CODES2Errors.Add("SEMESTER",String.Format(Resources.strings.CCS_IncorrectValue,"SEMESTER"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(REF_MODULE_CODES2LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(REF_MODULE_CODES2LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(REF_MODULE_CODES2LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            REF_MODULE_CODES2Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(REF_MODULE_CODES2Data)
        End If
        REF_MODULE_CODES2Errors.Add(item.errors)
    End Sub
'End Record Form REF_MODULE_CODES2 LoadItemFromRequest method

'Record Form REF_MODULE_CODES2 GetRedirectUrl method @45-41CB901B

    Protected Function GetREF_MODULE_CODES2RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form REF_MODULE_CODES2 GetRedirectUrl method

'Record Form REF_MODULE_CODES2 ShowErrors method @45-EFA17C36

    Protected Sub REF_MODULE_CODES2ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To REF_MODULE_CODES2Errors.Count - 1
        Select Case REF_MODULE_CODES2Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & REF_MODULE_CODES2Errors(i)
        End Select
        Next i
        REF_MODULE_CODES2Error.Visible = True
        REF_MODULE_CODES2ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form REF_MODULE_CODES2 ShowErrors method

'Record Form REF_MODULE_CODES2 Insert Operation @45-EE67B79A

    Protected Sub REF_MODULE_CODES2_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODES2Item = New REF_MODULE_CODES2Item()
        Dim ExecuteFlag As Boolean = True
        REF_MODULE_CODES2IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REF_MODULE_CODES2 Insert Operation

'Button Button_Insert OnClick. @46-82E9D3D1
        If CType(sender,Control).ID = "REF_MODULE_CODES2Button_Insert" Then
            RedirectUrl = GetREF_MODULE_CODES2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @46-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form REF_MODULE_CODES2 BeforeInsert tail @45-2D528CFF
    REF_MODULE_CODES2Parameters()
    REF_MODULE_CODES2LoadItemFromRequest(item, EnableValidation)
    If REF_MODULE_CODES2Operations.AllowInsert Then
        ErrorFlag=(REF_MODULE_CODES2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                REF_MODULE_CODES2Data.InsertItem(item)
            Catch ex As Exception
                REF_MODULE_CODES2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form REF_MODULE_CODES2 BeforeInsert tail

'Record Form REF_MODULE_CODES2 AfterInsert tail  @45-F8237F25
        End If
        ErrorFlag=(REF_MODULE_CODES2Errors.Count > 0)
        If ErrorFlag Then
            REF_MODULE_CODES2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REF_MODULE_CODES2 AfterInsert tail 

'Record Form REF_MODULE_CODES2 Update Operation @45-EADFFA5C

    Protected Sub REF_MODULE_CODES2_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODES2Item = New REF_MODULE_CODES2Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        REF_MODULE_CODES2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REF_MODULE_CODES2 Update Operation

'Button Button_Update OnClick. @47-79B1ADA6
        If CType(sender,Control).ID = "REF_MODULE_CODES2Button_Update" Then
            RedirectUrl = GetREF_MODULE_CODES2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @47-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record REF_MODULE_CODES2 Event BeforeUpdate. Action Retrieve Value for Control @57-EDFBCD4E
        REF_MODULE_CODES2LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserId.ToUpper()))).GetFormattedValue()
'End Record REF_MODULE_CODES2 Event BeforeUpdate. Action Retrieve Value for Control

'Record REF_MODULE_CODES2 Event BeforeUpdate. Action Retrieve Value for Control @58-9AB8DE5E
        REF_MODULE_CODES2LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy", (Now()))).GetFormattedValue()
'End Record REF_MODULE_CODES2 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form REF_MODULE_CODES2 Before Update tail @45-B9622527
        REF_MODULE_CODES2Parameters()
        REF_MODULE_CODES2LoadItemFromRequest(item, EnableValidation)
        If REF_MODULE_CODES2Operations.AllowUpdate Then
        ErrorFlag = (REF_MODULE_CODES2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                REF_MODULE_CODES2Data.UpdateItem(item)
            Catch ex As Exception
                REF_MODULE_CODES2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form REF_MODULE_CODES2 Before Update tail

'Record Form REF_MODULE_CODES2 Update Operation tail @45-F8237F25
        End If
        ErrorFlag=(REF_MODULE_CODES2Errors.Count > 0)
        If ErrorFlag Then
            REF_MODULE_CODES2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REF_MODULE_CODES2 Update Operation tail

'Record Form REF_MODULE_CODES2 Delete Operation @45-F1D3088A
    Protected Sub REF_MODULE_CODES2_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        REF_MODULE_CODES2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As REF_MODULE_CODES2Item = New REF_MODULE_CODES2Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form REF_MODULE_CODES2 Delete Operation

'Record Form BeforeDelete tail @45-D60DC850
        REF_MODULE_CODES2Parameters()
        REF_MODULE_CODES2LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @45-0A6A8AA9
        If ErrorFlag Then
            REF_MODULE_CODES2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form REF_MODULE_CODES2 Cancel Operation @45-AC29EED3

    Protected Sub REF_MODULE_CODES2_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REF_MODULE_CODES2Item = New REF_MODULE_CODES2Item()
        REF_MODULE_CODES2IsSubmitted = True
        Dim RedirectUrl As String = ""
        REF_MODULE_CODES2LoadItemFromRequest(item, False)
'End Record Form REF_MODULE_CODES2 Cancel Operation

'Button Button_Cancel OnClick. @48-78107494
    If CType(sender,Control).ID = "REF_MODULE_CODES2Button_Cancel" Then
        RedirectUrl = GetREF_MODULE_CODES2RedirectUrl("", "MODULE_CODE")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @48-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form REF_MODULE_CODES2 Cancel Operation tail @45-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form REF_MODULE_CODES2 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F9A83594
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        REF_MODULE_CODESContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        REF_MODULE_CODES1Data = New REF_MODULE_CODES1DataProvider()
        REF_MODULE_CODES1Operations = New FormSupportedOperations(False, True, False, False, False)
        REF_MODULE_CODESSearchData = New REF_MODULE_CODESSearchDataProvider()
        REF_MODULE_CODESSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        REF_MODULE_CODES2Data = New REF_MODULE_CODES2DataProvider()
        REF_MODULE_CODES2Operations = New FormSupportedOperations(False, True, True, True, False)
        Dim filter As New ResponseFilter(Response.Filter)
        AddHandler filter.OnFilterClose, AddressOf Me.BeforeOutput
        Response.Filter = filter
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

