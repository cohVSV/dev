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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse_list 'Namespace @1-A84709B5

'Forms Definition @1-C26CA9CE
Public Class [Staff_Inductions_ByCourse_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-88F5542A
    Protected STAFF_INDUCTIONS_COURSESData As STAFF_INDUCTIONS_COURSESDataProvider
    Protected STAFF_INDUCTIONS_COURSESOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESCurrentRowNumber As Integer
    Protected STAFF_INDUCTIONS_COURSESSearchData As STAFF_INDUCTIONS_COURSESSearchDataProvider
    Protected STAFF_INDUCTIONS_COURSESSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_COURSESSearchOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESSearchIsSubmitted As Boolean = False
    Protected Staff_Inductions_ByCourse_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-21796D0F
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_AddNEwHref = "Staff_Inductions_ByCourse_maint.aspx"
            PageData.FillItem(item)
            Link_AddNEw.InnerText += item.Link_AddNEw.GetFormattedValue().Replace(vbCrLf,"")
            Link_AddNEw.HRef = item.Link_AddNEwHref+item.Link_AddNEwHrefParameters.ToString("GET","id", ViewState)
            Link_AddNEw.DataBind()
            STAFF_INDUCTIONS_COURSESBind
            STAFF_INDUCTIONS_COURSESSearchShow()
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

'Grid Form STAFF_INDUCTIONS_COURSES BeforeShow tail @3-A5D1514F
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
        Dim Sorter_INDUCTION_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_INDUCTION_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_INDUCTION_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_INDUCTION_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_INDUCTIONS_COURSESRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords.Text = Server.HtmlEncode(item.STAFF_INDUCTIONS_COURSES_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form STAFF_INDUCTIONS_COURSES BeforeShow tail

'Label STAFF_INDUCTIONS_COURSES_TotalRecords Event BeforeShow. Action Retrieve number of records @10-851A0854
            STAFF_INDUCTIONS_COURSESSTAFF_INDUCTIONS_COURSES_TotalRecords.Text = STAFF_INDUCTIONS_COURSESData.RecordCount.ToString()
'End Label STAFF_INDUCTIONS_COURSES_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid STAFF_INDUCTIONS_COURSES Bind tail @3-E31F8E2A
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES Bind tail

'Grid STAFF_INDUCTIONS_COURSES Table Parameters @3-584FF5D9

    Protected Sub STAFF_INDUCTIONS_COURSESParameters()
        Try
            STAFF_INDUCTIONS_COURSESData.Urls_INDUCTION_TITLE = TextParameter.GetParam("s_INDUCTION_TITLE", ParameterSourceType.URL, "", Nothing, false)
            STAFF_INDUCTIONS_COURSESData.Urls_STATUS = IntegerParameter.GetParam("s_STATUS", ParameterSourceType.URL, "", Nothing, false)

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

'Grid STAFF_INDUCTIONS_COURSES ItemDataBound event @3-3C5F7E54

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
            Dim STAFF_INDUCTIONS_COURSESINDUCTION_TITLE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESINDUCTION_TITLE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSESSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESSTATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSESLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSESLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.idHref = "Staff_Inductions_ByCourse_maint.aspx"
            STAFF_INDUCTIONS_COURSESid.HRef = DataItem.idHref & DataItem.idHrefParameters.ToString("GET","", ViewState)
            DataItem.INDUCTION_TITLEHref = "Staff_Inductions_ByCourse_maint.aspx"
            STAFF_INDUCTIONS_COURSESINDUCTION_TITLE.HRef = DataItem.INDUCTION_TITLEHref & DataItem.INDUCTION_TITLEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF_INDUCTIONS_COURSES ItemDataBound event

'STAFF_INDUCTIONS_COURSES control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STAFF_INDUCTIONS_COURSES control Before Show

'Get Control @22-449D2165
            Dim STAFF_INDUCTIONS_COURSESSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSESSTATUS"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label STATUS Event BeforeShow. Action Custom Code @28-73254650
    ' -------------------------
    'ERA: show a nice label
	if STAFF_INDUCTIONS_COURSESSTATUS.Text="1" then
		STAFF_INDUCTIONS_COURSESSTATUS.Text = "Active"
	else
		STAFF_INDUCTIONS_COURSESSTATUS.Text ="Indolent"
	end if 
    ' -------------------------
'End Label STATUS Event BeforeShow. Action Custom Code

'STAFF_INDUCTIONS_COURSES control Before Show tail @3-477CF3C9
        End If
'End STAFF_INDUCTIONS_COURSES control Before Show tail

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

'Record Form STAFF_INDUCTIONS_COURSESSearch Show method @4-BE955FBA
    Protected Sub STAFF_INDUCTIONS_COURSESSearchShow()
        If STAFF_INDUCTIONS_COURSESSearchOperations.None Then
            STAFF_INDUCTIONS_COURSESSearchHolder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_COURSESSearchItem = STAFF_INDUCTIONS_COURSESSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_COURSESSearchOperations.AllowRead
        item.ClearParametersHref = "Staff_Inductions_ByCourse_list.aspx"
        STAFF_INDUCTIONS_COURSESSearchErrors.Add(item.errors)
        If STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_COURSESSearch Show method

'Record Form STAFF_INDUCTIONS_COURSESSearch BeforeShow tail @4-B05BC597
        STAFF_INDUCTIONS_COURSESSearchParameters()
        STAFF_INDUCTIONS_COURSESSearchData.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_COURSESSearchHolder.DataBind()
        STAFF_INDUCTIONS_COURSESSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSESSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_INDUCTION_TITLE;s_STATUS", ViewState)
        STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE.Text=item.s_INDUCTION_TITLE.GetFormattedValue()
        item.s_STATUSItems.SetSelection(item.s_STATUS.GetFormattedValue())
        STAFF_INDUCTIONS_COURSESSearchs_STATUS.SelectedIndex = -1
        item.s_STATUSItems.CopyTo(STAFF_INDUCTIONS_COURSESSearchs_STATUS.Items)
'End Record Form STAFF_INDUCTIONS_COURSESSearch BeforeShow tail

'Record Form STAFF_INDUCTIONS_COURSESSearch Show method tail @4-A0FDB316
        If STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch Show method tail

'Record Form STAFF_INDUCTIONS_COURSESSearch LoadItemFromRequest method @4-B4EADD58

    Protected Sub STAFF_INDUCTIONS_COURSESSearchLoadItemFromRequest(item As STAFF_INDUCTIONS_COURSESSearchItem, ByVal EnableValidation As Boolean)
        item.s_INDUCTION_TITLE.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE") Is Nothing Then
            item.s_INDUCTION_TITLE.SetValue(STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE.Text)
        Else
            item.s_INDUCTION_TITLE.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE"))
        End If
        Try
        item.s_STATUS.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESSearchs_STATUS.UniqueID))
        If Not IsNothing(STAFF_INDUCTIONS_COURSESSearchs_STATUS.SelectedItem) Then
            item.s_STATUS.SetValue(STAFF_INDUCTIONS_COURSESSearchs_STATUS.SelectedItem.Value)
        Else
            item.s_STATUS.Value = Nothing
        End If
        item.s_STATUSItems.CopyFrom(STAFF_INDUCTIONS_COURSESSearchs_STATUS.Items)
        Catch ae As ArgumentException
            STAFF_INDUCTIONS_COURSESSearchErrors.Add("s_STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"s_STATUS"))
        End Try
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_COURSESSearchData)
        End If
        STAFF_INDUCTIONS_COURSESSearchErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSESSearch LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_COURSESSearch GetRedirectUrl method @4-C6047384

    Protected Function GetSTAFF_INDUCTIONS_COURSESSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_Inductions_ByCourse_list.aspx"
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

'Button Button_DoSearch OnClick. @6-BFAF8662
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESSearchButton_DoSearch" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESSearchRedirectUrl("", "s_INDUCTION_TITLE;s_STATUS")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @6-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation tail @4-583A12A3
        ErrorFlag = STAFF_INDUCTIONS_COURSESSearchErrors.Count > 0
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE.Text <> "",("s_INDUCTION_TITLE=" & Server.UrlEncode(STAFF_INDUCTIONS_COURSESSearchs_INDUCTION_TITLE.Text) & "&"), "")
            For Each li In STAFF_INDUCTIONS_COURSESSearchs_STATUS.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_STATUS=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form STAFF_INDUCTIONS_COURSESSearch Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-BEF6BA6B
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_Inductions_ByCourse_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_INDUCTIONS_COURSESData = New STAFF_INDUCTIONS_COURSESDataProvider()
        STAFF_INDUCTIONS_COURSESOperations = New FormSupportedOperations(False, True, False, False, False)
        STAFF_INDUCTIONS_COURSESSearchData = New STAFF_INDUCTIONS_COURSESSearchDataProvider()
        STAFF_INDUCTIONS_COURSESSearchOperations = New FormSupportedOperations(False, True, True, True, True)
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

