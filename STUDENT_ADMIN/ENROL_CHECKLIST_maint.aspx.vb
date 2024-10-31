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

Namespace DECV_PROD2007.ENROL_CHECKLIST_maint 'Namespace @1-BAB6F809

'Forms Definition @1-7F2F837F
Public Class [ENROL_CHECKLIST_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-975A354B
    Protected ENROL_CHECKLISTSearchData As ENROL_CHECKLISTSearchDataProvider
    Protected ENROL_CHECKLISTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected ENROL_CHECKLISTSearchOperations As FormSupportedOperations
    Protected ENROL_CHECKLISTSearchIsSubmitted As Boolean = False
    Protected ENROL_CHECKLISTData As ENROL_CHECKLISTDataProvider
    Protected ENROL_CHECKLISTOperations As FormSupportedOperations
    Protected ENROL_CHECKLISTCurrentRowNumber As Integer
    Protected ENROL_CHECKLIST1Data As ENROL_CHECKLIST1DataProvider
    Protected ENROL_CHECKLIST1Errors As NameValueCollection = New NameValueCollection()
    Protected ENROL_CHECKLIST1Operations As FormSupportedOperations
    Protected ENROL_CHECKLIST1IsSubmitted As Boolean = False
    Protected ENROL_CHECKLIST_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A77CFDD1
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ENROL_CHECKLISTSearchShow()
            ENROL_CHECKLISTBind
            ENROL_CHECKLIST1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form ENROL_CHECKLISTSearch Parameters @20-AA1FCAB9

    Protected Sub ENROL_CHECKLISTSearchParameters()
        Dim item As new ENROL_CHECKLISTSearchItem
        Try
        Catch e As Exception
            ENROL_CHECKLISTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ENROL_CHECKLISTSearch Parameters

'Record Form ENROL_CHECKLISTSearch Show method @20-3EBB077B
    Protected Sub ENROL_CHECKLISTSearchShow()
        If ENROL_CHECKLISTSearchOperations.None Then
            ENROL_CHECKLISTSearchHolder.Visible = False
            Return
        End If
        Dim item As ENROL_CHECKLISTSearchItem = ENROL_CHECKLISTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ENROL_CHECKLISTSearchOperations.AllowRead
        item.ClearParametersHref = "ENROL_CHECKLIST_maint.aspx"
        ENROL_CHECKLISTSearchErrors.Add(item.errors)
        If ENROL_CHECKLISTSearchErrors.Count > 0 Then
            ENROL_CHECKLISTSearchShowErrors()
            Return
        End If
'End Record Form ENROL_CHECKLISTSearch Show method

'Record Form ENROL_CHECKLISTSearch BeforeShow tail @20-FE7EDB44
        ENROL_CHECKLISTSearchParameters()
        ENROL_CHECKLISTSearchData.FillItem(item, IsInsertMode)
        ENROL_CHECKLISTSearchHolder.DataBind()
        ENROL_CHECKLISTSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        ENROL_CHECKLISTSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        ENROL_CHECKLISTSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form ENROL_CHECKLISTSearch BeforeShow tail

'Record Form ENROL_CHECKLISTSearch Show method tail @20-64C9189A
        If ENROL_CHECKLISTSearchErrors.Count > 0 Then
            ENROL_CHECKLISTSearchShowErrors()
        End If
    End Sub
'End Record Form ENROL_CHECKLISTSearch Show method tail

'Record Form ENROL_CHECKLISTSearch LoadItemFromRequest method @20-BBFD6883

    Protected Sub ENROL_CHECKLISTSearchLoadItemFromRequest(item As ENROL_CHECKLISTSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLISTSearchs_keyword.UniqueID))
        If ControlCustomValues("ENROL_CHECKLISTSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(ENROL_CHECKLISTSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("ENROL_CHECKLISTSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(ENROL_CHECKLISTSearchData)
        End If
        ENROL_CHECKLISTSearchErrors.Add(item.errors)
    End Sub
'End Record Form ENROL_CHECKLISTSearch LoadItemFromRequest method

'Record Form ENROL_CHECKLISTSearch GetRedirectUrl method @20-EB7AD74A

    Protected Function GetENROL_CHECKLISTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "ENROL_CHECKLIST_maint.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ENROL_CHECKLISTSearch GetRedirectUrl method

'Record Form ENROL_CHECKLISTSearch ShowErrors method @20-F45495D8

    Protected Sub ENROL_CHECKLISTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ENROL_CHECKLISTSearchErrors.Count - 1
        Select Case ENROL_CHECKLISTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ENROL_CHECKLISTSearchErrors(i)
        End Select
        Next i
        ENROL_CHECKLISTSearchError.Visible = True
        ENROL_CHECKLISTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ENROL_CHECKLISTSearch ShowErrors method

'Record Form ENROL_CHECKLISTSearch Insert Operation @20-27D8692C

    Protected Sub ENROL_CHECKLISTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
        ENROL_CHECKLISTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROL_CHECKLISTSearch Insert Operation

'Record Form ENROL_CHECKLISTSearch BeforeInsert tail @20-CF8A5C2E
    ENROL_CHECKLISTSearchParameters()
    ENROL_CHECKLISTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ENROL_CHECKLISTSearch BeforeInsert tail

'Record Form ENROL_CHECKLISTSearch AfterInsert tail  @20-6D90007B
        ErrorFlag=(ENROL_CHECKLISTSearchErrors.Count > 0)
        If ErrorFlag Then
            ENROL_CHECKLISTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROL_CHECKLISTSearch AfterInsert tail 

'Record Form ENROL_CHECKLISTSearch Update Operation @20-9A058F89

    Protected Sub ENROL_CHECKLISTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ENROL_CHECKLISTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROL_CHECKLISTSearch Update Operation

'Record Form ENROL_CHECKLISTSearch Before Update tail @20-CF8A5C2E
        ENROL_CHECKLISTSearchParameters()
        ENROL_CHECKLISTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ENROL_CHECKLISTSearch Before Update tail

'Record Form ENROL_CHECKLISTSearch Update Operation tail @20-6D90007B
        ErrorFlag=(ENROL_CHECKLISTSearchErrors.Count > 0)
        If ErrorFlag Then
            ENROL_CHECKLISTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROL_CHECKLISTSearch Update Operation tail

'Record Form ENROL_CHECKLISTSearch Delete Operation @20-915E1E50
    Protected Sub ENROL_CHECKLISTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ENROL_CHECKLISTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ENROL_CHECKLISTSearch Delete Operation

'Record Form BeforeDelete tail @20-CF8A5C2E
        ENROL_CHECKLISTSearchParameters()
        ENROL_CHECKLISTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @20-C641239F
        If ErrorFlag Then
            ENROL_CHECKLISTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ENROL_CHECKLISTSearch Cancel Operation @20-1B397E99

    Protected Sub ENROL_CHECKLISTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
        ENROL_CHECKLISTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        ENROL_CHECKLISTSearchLoadItemFromRequest(item, True)
'End Record Form ENROL_CHECKLISTSearch Cancel Operation

'Record Form ENROL_CHECKLISTSearch Cancel Operation tail @20-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ENROL_CHECKLISTSearch Cancel Operation tail

'Record Form ENROL_CHECKLISTSearch Search Operation @20-23E6F33B
    Protected Sub ENROL_CHECKLISTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        ENROL_CHECKLISTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As ENROL_CHECKLISTSearchItem = New ENROL_CHECKLISTSearchItem()
        ENROL_CHECKLISTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ENROL_CHECKLISTSearch Search Operation

'Button Button_DoSearch OnClick. @22-E0246AA9
        If CType(sender,Control).ID = "ENROL_CHECKLISTSearchButton_DoSearch" Then
            RedirectUrl = GetENROL_CHECKLISTSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @22-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form ENROL_CHECKLISTSearch Search Operation tail @20-BE2B6E6A
        ErrorFlag = ENROL_CHECKLISTSearchErrors.Count > 0
        If ErrorFlag Then
            ENROL_CHECKLISTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(ENROL_CHECKLISTSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(ENROL_CHECKLISTSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROL_CHECKLISTSearch Search Operation tail

'Grid ENROL_CHECKLIST Bind @24-4113352A

    Protected Sub ENROL_CHECKLISTBind()
        If Not ENROL_CHECKLISTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ENROL_CHECKLIST",GetType(ENROL_CHECKLISTDataProvider.SortFields), 20, 100)
        End If
'End Grid ENROL_CHECKLIST Bind

'Grid Form ENROL_CHECKLIST BeforeShow tail @24-A0BB8C9C
        ENROL_CHECKLISTParameters()
        ENROL_CHECKLISTData.SortField = CType(ViewState("ENROL_CHECKLISTSortField"),ENROL_CHECKLISTDataProvider.SortFields)
        ENROL_CHECKLISTData.SortDir = CType(ViewState("ENROL_CHECKLISTSortDir"),SortDirections)
        ENROL_CHECKLISTData.PageNumber = CInt(ViewState("ENROL_CHECKLISTPageNumber"))
        ENROL_CHECKLISTData.RecordsPerPage = CInt(ViewState("ENROL_CHECKLISTPageSize"))
        ENROL_CHECKLISTRepeater.DataSource = ENROL_CHECKLISTData.GetResultSet(PagesCount, ENROL_CHECKLISTOperations)
        ViewState("ENROL_CHECKLISTPagesCount") = PagesCount
        Dim item As ENROL_CHECKLISTItem = New ENROL_CHECKLISTItem()
        ENROL_CHECKLISTRepeater.DataBind
        FooterIndex = ENROL_CHECKLISTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            ENROL_CHECKLISTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim ENROL_CHECKLISTENROL_CHECKLIST_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(ENROL_CHECKLISTRepeater.Controls(FooterIndex).FindControl("ENROL_CHECKLISTENROL_CHECKLIST_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim ENROL_CHECKLISTENROL_CHECKLIST_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("ENROL_CHECKLISTENROL_CHECKLIST_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CATEGORIES_REQUIREDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_CATEGORIES_REQUIREDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ACTIVESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_ACTIVESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ENROL_CHECKLISTRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ENROL_CHECKLISTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.ENROL_CHECKLIST_InsertHref = "ENROL_CHECKLIST_maint.aspx"
        ENROL_CHECKLISTENROL_CHECKLIST_Insert.InnerText += item.ENROL_CHECKLIST_Insert.GetFormattedValue().Replace(vbCrLf,"")
        ENROL_CHECKLISTENROL_CHECKLIST_Insert.HRef = item.ENROL_CHECKLIST_InsertHref+item.ENROL_CHECKLIST_InsertHrefParameters.ToString("GET","ID", ViewState)
        ENROL_CHECKLISTENROL_CHECKLIST_TotalRecords.Text = Server.HtmlEncode(item.ENROL_CHECKLIST_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form ENROL_CHECKLIST BeforeShow tail

'Label ENROL_CHECKLIST_TotalRecords Event BeforeShow. Action Retrieve number of records @29-24DE5597
            ENROL_CHECKLISTENROL_CHECKLIST_TotalRecords.Text = ENROL_CHECKLISTData.RecordCount.ToString()
'End Label ENROL_CHECKLIST_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid ENROL_CHECKLIST Bind tail @24-E31F8E2A
    End Sub
'End Grid ENROL_CHECKLIST Bind tail

'Grid ENROL_CHECKLIST Table Parameters @24-513DAEC2

    Protected Sub ENROL_CHECKLISTParameters()
        Try
            ENROL_CHECKLISTData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ENROL_CHECKLISTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ENROL_CHECKLISTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ENROL_CHECKLIST: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid ENROL_CHECKLIST Table Parameters

'Grid ENROL_CHECKLIST ItemDataBound event @24-B85DB8A8

    Protected Sub ENROL_CHECKLISTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ENROL_CHECKLISTItem = CType(e.Item.DataItem,ENROL_CHECKLISTItem)
        Dim Item as ENROL_CHECKLISTItem = DataItem
        Dim FormDataSource As ENROL_CHECKLISTItem() = CType(ENROL_CHECKLISTRepeater.DataSource, ENROL_CHECKLISTItem())
        Dim ENROL_CHECKLISTDataRows As Integer = FormDataSource.Length
        Dim ENROL_CHECKLISTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ENROL_CHECKLISTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ENROL_CHECKLISTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ENROL_CHECKLISTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ENROL_CHECKLISTID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ENROL_CHECKLISTID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim ENROL_CHECKLISTDESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROL_CHECKLISTDESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim ENROL_CHECKLISTCATEGORIES_REQUIRED As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROL_CHECKLISTCATEGORIES_REQUIRED"),System.Web.UI.WebControls.Literal)
            Dim ENROL_CHECKLISTACTIVE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROL_CHECKLISTACTIVE"),System.Web.UI.WebControls.Literal)
            Dim ENROL_CHECKLISTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROL_CHECKLISTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ENROL_CHECKLISTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ENROL_CHECKLISTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.IDHref = ""
            ENROL_CHECKLISTID.HRef = DataItem.IDHref & DataItem.IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid ENROL_CHECKLIST ItemDataBound event

'Grid ENROL_CHECKLIST ItemDataBound event tail @24-F7C1B543
        If ENROL_CHECKLISTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(ENROL_CHECKLISTCurrentRowNumber, ListItemType.Item)
            ENROL_CHECKLISTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            ENROL_CHECKLISTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ENROL_CHECKLIST ItemDataBound event tail

'Grid ENROL_CHECKLIST ItemCommand event @24-B95958D0

    Protected Sub ENROL_CHECKLISTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ENROL_CHECKLISTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ENROL_CHECKLISTSortDir"),SortDirections) = SortDirections._Asc And ViewState("ENROL_CHECKLISTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ENROL_CHECKLISTSortDir")=SortDirections._Desc
                Else
                    ViewState("ENROL_CHECKLISTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ENROL_CHECKLISTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ENROL_CHECKLISTDataProvider.SortFields = 0
            ViewState("ENROL_CHECKLISTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ENROL_CHECKLISTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ENROL_CHECKLISTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ENROL_CHECKLISTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ENROL_CHECKLISTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ENROL_CHECKLISTBind
        End If
    End Sub
'End Grid ENROL_CHECKLIST ItemCommand event

'Record Form ENROL_CHECKLIST1 Parameters @53-D5CAB7BA

    Protected Sub ENROL_CHECKLIST1Parameters()
        Dim item As new ENROL_CHECKLIST1Item
        Try
            ENROL_CHECKLIST1Data.UrlID = IntegerParameter.GetParam("ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            ENROL_CHECKLIST1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ENROL_CHECKLIST1 Parameters

'Record Form ENROL_CHECKLIST1 Show method @53-1EA74221
    Protected Sub ENROL_CHECKLIST1Show()
        If ENROL_CHECKLIST1Operations.None Then
            ENROL_CHECKLIST1Holder.Visible = False
            Return
        End If
        Dim item As ENROL_CHECKLIST1Item = ENROL_CHECKLIST1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ENROL_CHECKLIST1Operations.AllowRead
        ENROL_CHECKLIST1Errors.Add(item.errors)
        If ENROL_CHECKLIST1Errors.Count > 0 Then
            ENROL_CHECKLIST1ShowErrors()
            Return
        End If
'End Record Form ENROL_CHECKLIST1 Show method

'Record Form ENROL_CHECKLIST1 BeforeShow tail @53-2C05E146
        ENROL_CHECKLIST1Parameters()
        ENROL_CHECKLIST1Data.FillItem(item, IsInsertMode)
        ENROL_CHECKLIST1Holder.DataBind()
        ENROL_CHECKLIST1Button_Insert.Visible=IsInsertMode AndAlso ENROL_CHECKLIST1Operations.AllowInsert
        ENROL_CHECKLIST1Button_Update.Visible=Not (IsInsertMode) AndAlso ENROL_CHECKLIST1Operations.AllowUpdate
        ENROL_CHECKLIST1DESCRIPTION.Text=item.DESCRIPTION.GetFormattedValue()
        ENROL_CHECKLIST1CATEGORIES_REQUIRED.Text=item.CATEGORIES_REQUIRED.GetFormattedValue()
        ENROL_CHECKLIST1CATEGORIES_OPTIONAL.Text=item.CATEGORIES_OPTIONAL.GetFormattedValue()
        ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE.Text=item.CATEGORIES_NOTAPPLICABLE.GetFormattedValue()
        item.ACTIVEItems.SetSelection(item.ACTIVE.GetFormattedValue())
        ENROL_CHECKLIST1ACTIVE.SelectedIndex = -1
        item.ACTIVEItems.CopyTo(ENROL_CHECKLIST1ACTIVE.Items, True)
        ENROL_CHECKLIST1LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        ENROL_CHECKLIST1LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        ENROL_CHECKLIST1lblLastAlteredBy.Text = Server.HtmlEncode(item.lblLastAlteredBy.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ENROL_CHECKLIST1lblLastAlteredWhen.Text = Server.HtmlEncode(item.lblLastAlteredWhen.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form ENROL_CHECKLIST1 BeforeShow tail

'Record Form ENROL_CHECKLIST1 Show method tail @53-26242ECE
        If ENROL_CHECKLIST1Errors.Count > 0 Then
            ENROL_CHECKLIST1ShowErrors()
        End If
    End Sub
'End Record Form ENROL_CHECKLIST1 Show method tail

'Record Form ENROL_CHECKLIST1 LoadItemFromRequest method @53-7860C326

    Protected Sub ENROL_CHECKLIST1LoadItemFromRequest(item As ENROL_CHECKLIST1Item, ByVal EnableValidation As Boolean)
        item.DESCRIPTION.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1DESCRIPTION.UniqueID))
        If ControlCustomValues("ENROL_CHECKLIST1DESCRIPTION") Is Nothing Then
            item.DESCRIPTION.SetValue(ENROL_CHECKLIST1DESCRIPTION.Text)
        Else
            item.DESCRIPTION.SetValue(ControlCustomValues("ENROL_CHECKLIST1DESCRIPTION"))
        End If
        item.CATEGORIES_REQUIRED.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1CATEGORIES_REQUIRED.UniqueID))
        If ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_REQUIRED") Is Nothing Then
            item.CATEGORIES_REQUIRED.SetValue(ENROL_CHECKLIST1CATEGORIES_REQUIRED.Text)
        Else
            item.CATEGORIES_REQUIRED.SetValue(ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_REQUIRED"))
        End If
        item.CATEGORIES_OPTIONAL.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1CATEGORIES_OPTIONAL.UniqueID))
        If ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_OPTIONAL") Is Nothing Then
            item.CATEGORIES_OPTIONAL.SetValue(ENROL_CHECKLIST1CATEGORIES_OPTIONAL.Text)
        Else
            item.CATEGORIES_OPTIONAL.SetValue(ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_OPTIONAL"))
        End If
        item.CATEGORIES_NOTAPPLICABLE.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE.UniqueID))
        If ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE") Is Nothing Then
            item.CATEGORIES_NOTAPPLICABLE.SetValue(ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE.Text)
        Else
            item.CATEGORIES_NOTAPPLICABLE.SetValue(ControlCustomValues("ENROL_CHECKLIST1CATEGORIES_NOTAPPLICABLE"))
        End If
        item.ACTIVE.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1ACTIVE.UniqueID))
        If Not IsNothing(ENROL_CHECKLIST1ACTIVE.SelectedItem) Then
            item.ACTIVE.SetValue(ENROL_CHECKLIST1ACTIVE.SelectedItem.Value)
        Else
            item.ACTIVE.Value = Nothing
        End If
        item.ACTIVEItems.CopyFrom(ENROL_CHECKLIST1ACTIVE.Items)
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(ENROL_CHECKLIST1LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(ENROL_CHECKLIST1LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(ENROL_CHECKLIST1LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            ENROL_CHECKLIST1Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        If EnableValidation Then
            item.Validate(ENROL_CHECKLIST1Data)
        End If
        ENROL_CHECKLIST1Errors.Add(item.errors)
    End Sub
'End Record Form ENROL_CHECKLIST1 LoadItemFromRequest method

'Record Form ENROL_CHECKLIST1 GetRedirectUrl method @53-D112C57D

    Protected Function GetENROL_CHECKLIST1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ENROL_CHECKLIST1 GetRedirectUrl method

'Record Form ENROL_CHECKLIST1 ShowErrors method @53-AE5E9878

    Protected Sub ENROL_CHECKLIST1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ENROL_CHECKLIST1Errors.Count - 1
        Select Case ENROL_CHECKLIST1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ENROL_CHECKLIST1Errors(i)
        End Select
        Next i
        ENROL_CHECKLIST1Error.Visible = True
        ENROL_CHECKLIST1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ENROL_CHECKLIST1 ShowErrors method

'Record Form ENROL_CHECKLIST1 Insert Operation @53-A0BEA057

    Protected Sub ENROL_CHECKLIST1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLIST1Item = New ENROL_CHECKLIST1Item()
        Dim ExecuteFlag As Boolean = True
        ENROL_CHECKLIST1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROL_CHECKLIST1 Insert Operation

'Button Button_Insert OnClick. @55-CF73B6C3
        If CType(sender,Control).ID = "ENROL_CHECKLIST1Button_Insert" Then
            RedirectUrl = GetENROL_CHECKLIST1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @55-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form ENROL_CHECKLIST1 BeforeInsert tail @53-2F98F982
    ENROL_CHECKLIST1Parameters()
    ENROL_CHECKLIST1LoadItemFromRequest(item, EnableValidation)
    If ENROL_CHECKLIST1Operations.AllowInsert Then
        ErrorFlag=(ENROL_CHECKLIST1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ENROL_CHECKLIST1Data.InsertItem(item)
            Catch ex As Exception
                ENROL_CHECKLIST1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ENROL_CHECKLIST1 BeforeInsert tail

'Record ENROL_CHECKLIST1 Event AfterInsert. Action Save Variable Value @79-A7EBABD6
        HttpContext.Current.Session("notifymessage") = "Item has been Added"
'End Record ENROL_CHECKLIST1 Event AfterInsert. Action Save Variable Value

'Record Form ENROL_CHECKLIST1 AfterInsert tail  @53-E22A29D2
        End If
        ErrorFlag=(ENROL_CHECKLIST1Errors.Count > 0)
        If ErrorFlag Then
            ENROL_CHECKLIST1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROL_CHECKLIST1 AfterInsert tail 

'Record Form ENROL_CHECKLIST1 Update Operation @53-9835373E

    Protected Sub ENROL_CHECKLIST1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLIST1Item = New ENROL_CHECKLIST1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        ENROL_CHECKLIST1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROL_CHECKLIST1 Update Operation

'Button Button_Update OnClick. @56-4341A49C
        If CType(sender,Control).ID = "ENROL_CHECKLIST1Button_Update" Then
            RedirectUrl = GetENROL_CHECKLIST1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @56-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record ENROL_CHECKLIST1 Event BeforeUpdate. Action Retrieve Value for Control @77-BE74C295
        ENROL_CHECKLIST1LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record ENROL_CHECKLIST1 Event BeforeUpdate. Action Retrieve Value for Control

'Record ENROL_CHECKLIST1 Event BeforeUpdate. Action Retrieve Value for Control @78-CF340005
        ENROL_CHECKLIST1LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record ENROL_CHECKLIST1 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form ENROL_CHECKLIST1 Before Update tail @53-1A409FF9
        ENROL_CHECKLIST1Parameters()
        ENROL_CHECKLIST1LoadItemFromRequest(item, EnableValidation)
        If ENROL_CHECKLIST1Operations.AllowUpdate Then
        ErrorFlag = (ENROL_CHECKLIST1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ENROL_CHECKLIST1Data.UpdateItem(item)
            Catch ex As Exception
                ENROL_CHECKLIST1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ENROL_CHECKLIST1 Before Update tail

'Record ENROL_CHECKLIST1 Event AfterUpdate. Action Save Variable Value @80-B862AFBC
        HttpContext.Current.Session("notifymessage") = "Item has been Updated"
'End Record ENROL_CHECKLIST1 Event AfterUpdate. Action Save Variable Value

'Record Form ENROL_CHECKLIST1 Update Operation tail @53-E22A29D2
        End If
        ErrorFlag=(ENROL_CHECKLIST1Errors.Count > 0)
        If ErrorFlag Then
            ENROL_CHECKLIST1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROL_CHECKLIST1 Update Operation tail

'Record Form ENROL_CHECKLIST1 Delete Operation @53-FCB2A6DF
    Protected Sub ENROL_CHECKLIST1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ENROL_CHECKLIST1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ENROL_CHECKLIST1Item = New ENROL_CHECKLIST1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ENROL_CHECKLIST1 Delete Operation

'Record Form BeforeDelete tail @53-B22E6B8F
        ENROL_CHECKLIST1Parameters()
        ENROL_CHECKLIST1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @53-E1003B9A
        If ErrorFlag Then
            ENROL_CHECKLIST1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ENROL_CHECKLIST1 Cancel Operation @53-753DD1D4

    Protected Sub ENROL_CHECKLIST1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROL_CHECKLIST1Item = New ENROL_CHECKLIST1Item()
        ENROL_CHECKLIST1IsSubmitted = True
        Dim RedirectUrl As String = ""
        ENROL_CHECKLIST1LoadItemFromRequest(item, False)
'End Record Form ENROL_CHECKLIST1 Cancel Operation

'Button Button_Cancel OnClick. @57-05ED0E11
    If CType(sender,Control).ID = "ENROL_CHECKLIST1Button_Cancel" Then
        RedirectUrl = GetENROL_CHECKLIST1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @57-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form ENROL_CHECKLIST1 Cancel Operation tail @53-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ENROL_CHECKLIST1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-80289AB5
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ENROL_CHECKLIST_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ENROL_CHECKLISTSearchData = New ENROL_CHECKLISTSearchDataProvider()
        ENROL_CHECKLISTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        ENROL_CHECKLISTData = New ENROL_CHECKLISTDataProvider()
        ENROL_CHECKLISTOperations = New FormSupportedOperations(False, True, False, False, False)
        ENROL_CHECKLIST1Data = New ENROL_CHECKLIST1DataProvider()
        ENROL_CHECKLIST1Operations = New FormSupportedOperations(False, True, True, True, False)
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

