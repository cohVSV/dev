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

Namespace DECV_PROD2007.CONTRIBUTION_list 'Namespace @1-99A29F31

'Forms Definition @1-10C14B4F
Public Class [CONTRIBUTION_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-447C2EC3
    Protected CONTRIBUTIONData As CONTRIBUTIONDataProvider
    Protected CONTRIBUTIONOperations As FormSupportedOperations
    Protected CONTRIBUTIONCurrentRowNumber As Integer
    Protected CONTRIBUTION1Data As CONTRIBUTION1DataProvider
    Protected CONTRIBUTION1Errors As NameValueCollection = New NameValueCollection()
    Protected CONTRIBUTION1Operations As FormSupportedOperations
    Protected CONTRIBUTION1IsSubmitted As Boolean = False
    Protected CONTRIBUTION_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-9E9C2AC5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Contrib_insertHref = "CONTRIBUTION_maint.aspx"
            PageData.FillItem(item)
            Contrib_insert.InnerText += item.Contrib_insert.GetFormattedValue().Replace(vbCrLf,"")
            Contrib_insert.HRef = item.Contrib_insertHref+item.Contrib_insertHrefParameters.ToString("GET","CATEGORY_CODE", ViewState)
            Contrib_insert.DataBind()
            CONTRIBUTIONBind
            CONTRIBUTION1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid CONTRIBUTION Bind @2-AB64F95B

    Protected Sub CONTRIBUTIONBind()
        If Not CONTRIBUTIONOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"CONTRIBUTION",GetType(CONTRIBUTIONDataProvider.SortFields), 30, 100)
        End If
'End Grid CONTRIBUTION Bind

'Grid Form CONTRIBUTION BeforeShow tail @2-AF6C040D
        CONTRIBUTIONParameters()
        CONTRIBUTIONData.SortField = CType(ViewState("CONTRIBUTIONSortField"),CONTRIBUTIONDataProvider.SortFields)
        CONTRIBUTIONData.SortDir = CType(ViewState("CONTRIBUTIONSortDir"),SortDirections)
        CONTRIBUTIONData.PageNumber = CInt(ViewState("CONTRIBUTIONPageNumber"))
        CONTRIBUTIONData.RecordsPerPage = CInt(ViewState("CONTRIBUTIONPageSize"))
        CONTRIBUTIONRepeater.DataSource = CONTRIBUTIONData.GetResultSet(PagesCount, CONTRIBUTIONOperations)
        ViewState("CONTRIBUTIONPagesCount") = PagesCount
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        CONTRIBUTIONRepeater.DataBind
        FooterIndex = CONTRIBUTIONRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            CONTRIBUTIONRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim CONTRIBUTIONCONTRIBUTION_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(CONTRIBUTIONRepeater.Controls(FooterIndex).FindControl("CONTRIBUTIONCONTRIBUTION_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_CATEGORY_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_CATEGORY_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCHOOL_TYPE_CODE1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_SCHOOL_TYPE_CODE1Sorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CAMPUS_CODE1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_CAMPUS_CODE1Sorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FROM_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_FROM_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TO_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_TO_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PER_SUBJECT_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_PER_SUBJECT_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DEFAULT_CONTRIBUTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_DEFAULT_CONTRIBUTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DISCOUNT_AMOUNTSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_DISCOUNT_AMOUNTSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(CONTRIBUTIONRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(CONTRIBUTIONRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.CONTRIBUTION_InsertHref = "CONTRIBUTION_maint.aspx"
        CONTRIBUTIONCONTRIBUTION_Insert.InnerText += item.CONTRIBUTION_Insert.GetFormattedValue().Replace(vbCrLf,"")
        CONTRIBUTIONCONTRIBUTION_Insert.HRef = item.CONTRIBUTION_InsertHref+item.CONTRIBUTION_InsertHrefParameters.ToString("GET","CATEGORY_CODE", ViewState)
'End Grid Form CONTRIBUTION BeforeShow tail

'Grid CONTRIBUTION Bind tail @2-E31F8E2A
    End Sub
'End Grid CONTRIBUTION Bind tail

'Grid CONTRIBUTION Table Parameters @2-3FAF711C

    Protected Sub CONTRIBUTIONParameters()
        Try
            CONTRIBUTIONData.Urls_CATEGORY_CODE = TextParameter.GetParam("s_CATEGORY_CODE", ParameterSourceType.URL, "", Nothing, false)
            CONTRIBUTIONData.Urls_CAMPUS_CODE = TextParameter.GetParam("s_CAMPUS_CODE", ParameterSourceType.URL, "", "[D]", false)

        Catch
            Dim ParentControls As ControlCollection=CONTRIBUTIONRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(CONTRIBUTIONRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid CONTRIBUTION: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid CONTRIBUTION Table Parameters

'Grid CONTRIBUTION ItemDataBound event @2-F3E6E9ED

    Protected Sub CONTRIBUTIONItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as CONTRIBUTIONItem = CType(e.Item.DataItem,CONTRIBUTIONItem)
        Dim Item as CONTRIBUTIONItem = DataItem
        Dim FormDataSource As CONTRIBUTIONItem() = CType(CONTRIBUTIONRepeater.DataSource, CONTRIBUTIONItem())
        Dim CONTRIBUTIONDataRows As Integer = FormDataSource.Length
        Dim CONTRIBUTIONIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CONTRIBUTIONCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(CONTRIBUTIONRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, CONTRIBUTIONCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim CONTRIBUTIONCATEGORY_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("CONTRIBUTIONCATEGORY_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim CONTRIBUTIONSCHOOL_TYPE_CODE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONSCHOOL_TYPE_CODE1"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONCAMPUS_CODE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONCAMPUS_CODE1"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONFROM_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONFROM_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONTO_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONTO_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONPER_SUBJECT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONPER_SUBJECT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONDEFAULT_CONTRIBUTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONDEFAULT_CONTRIBUTION"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONDISCOUNT_AMOUNT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONDISCOUNT_AMOUNT"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.CATEGORY_CODEHref = "CONTRIBUTION_maint.aspx"
            CONTRIBUTIONCATEGORY_CODE.HRef = DataItem.CATEGORY_CODEHref & DataItem.CATEGORY_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim CONTRIBUTIONAlt_CATEGORY_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_CATEGORY_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim CONTRIBUTIONAlt_SCHOOL_TYPE_CODE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_SCHOOL_TYPE_CODE1"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_CAMPUS_CODE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_CAMPUS_CODE1"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_FROM_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_FROM_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_TO_YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_TO_YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_PER_SUBJECT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_PER_SUBJECT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_DEFAULT_CONTRIBUTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_DEFAULT_CONTRIBUTION"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_DISCOUNT_AMOUNT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_DISCOUNT_AMOUNT"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim CONTRIBUTIONAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CONTRIBUTIONAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_CATEGORY_CODEHref = "CONTRIBUTION_maint.aspx"
            CONTRIBUTIONAlt_CATEGORY_CODE.HRef = DataItem.Alt_CATEGORY_CODEHref & DataItem.Alt_CATEGORY_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid CONTRIBUTION ItemDataBound event

'Grid CONTRIBUTION ItemDataBound event tail @2-2760A724
        If CONTRIBUTIONIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(CONTRIBUTIONCurrentRowNumber, ListItemType.AlternatingItem)
                CONTRIBUTIONRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(CONTRIBUTIONCurrentRowNumber, ListItemType.Item)
                CONTRIBUTIONRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            CONTRIBUTIONItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid CONTRIBUTION ItemDataBound event tail

'Grid CONTRIBUTION ItemCommand event @2-A1006A3F

    Protected Sub CONTRIBUTIONItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= CONTRIBUTIONRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("CONTRIBUTIONSortDir"),SortDirections) = SortDirections._Asc And ViewState("CONTRIBUTIONSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("CONTRIBUTIONSortDir")=SortDirections._Desc
                Else
                    ViewState("CONTRIBUTIONSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("CONTRIBUTIONSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As CONTRIBUTIONDataProvider.SortFields = 0
            ViewState("CONTRIBUTIONSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("CONTRIBUTIONPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("CONTRIBUTIONPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("CONTRIBUTIONPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("CONTRIBUTIONPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            CONTRIBUTIONBind
        End If
    End Sub
'End Grid CONTRIBUTION ItemCommand event

'Record Form CONTRIBUTION1 Parameters @57-AF59F57A

    Protected Sub CONTRIBUTION1Parameters()
        Dim item As new CONTRIBUTION1Item
        Try
        Catch e As Exception
            CONTRIBUTION1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form CONTRIBUTION1 Parameters

'Record Form CONTRIBUTION1 Show method @57-BEEC67CC
    Protected Sub CONTRIBUTION1Show()
        If CONTRIBUTION1Operations.None Then
            CONTRIBUTION1Holder.Visible = False
            Return
        End If
        Dim item As CONTRIBUTION1Item = CONTRIBUTION1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not CONTRIBUTION1Operations.AllowRead
        CONTRIBUTION1Errors.Add(item.errors)
        If CONTRIBUTION1Errors.Count > 0 Then
            CONTRIBUTION1ShowErrors()
            Return
        End If
'End Record Form CONTRIBUTION1 Show method

'Record Form CONTRIBUTION1 BeforeShow tail @57-E8A33918
        CONTRIBUTION1Parameters()
        CONTRIBUTION1Data.FillItem(item, IsInsertMode)
        CONTRIBUTION1Holder.DataBind()
        CONTRIBUTION1s_CATEGORY_CODE.Text=item.s_CATEGORY_CODE.GetFormattedValue()
        item.s_CAMPUS_CODEItems.SetSelection(item.s_CAMPUS_CODE.GetFormattedValue())
        CONTRIBUTION1s_CAMPUS_CODE.SelectedIndex = -1
        item.s_CAMPUS_CODEItems.CopyTo(CONTRIBUTION1s_CAMPUS_CODE.Items)
'End Record Form CONTRIBUTION1 BeforeShow tail

'Record Form CONTRIBUTION1 Show method tail @57-3E606E03
        If CONTRIBUTION1Errors.Count > 0 Then
            CONTRIBUTION1ShowErrors()
        End If
    End Sub
'End Record Form CONTRIBUTION1 Show method tail

'Record Form CONTRIBUTION1 LoadItemFromRequest method @57-4964EA00

    Protected Sub CONTRIBUTION1LoadItemFromRequest(item As CONTRIBUTION1Item, ByVal EnableValidation As Boolean)
        item.s_CATEGORY_CODE.IsEmpty = IsNothing(Request.Form(CONTRIBUTION1s_CATEGORY_CODE.UniqueID))
        If ControlCustomValues("CONTRIBUTION1s_CATEGORY_CODE") Is Nothing Then
            item.s_CATEGORY_CODE.SetValue(CONTRIBUTION1s_CATEGORY_CODE.Text)
        Else
            item.s_CATEGORY_CODE.SetValue(ControlCustomValues("CONTRIBUTION1s_CATEGORY_CODE"))
        End If
        item.s_CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(CONTRIBUTION1s_CAMPUS_CODE.UniqueID))
        If Not IsNothing(CONTRIBUTION1s_CAMPUS_CODE.SelectedItem) Then
            item.s_CAMPUS_CODE.SetValue(CONTRIBUTION1s_CAMPUS_CODE.SelectedItem.Value)
        Else
            item.s_CAMPUS_CODE.Value = Nothing
        End If
        item.s_CAMPUS_CODEItems.CopyFrom(CONTRIBUTION1s_CAMPUS_CODE.Items)
        If EnableValidation Then
            item.Validate(CONTRIBUTION1Data)
        End If
        CONTRIBUTION1Errors.Add(item.errors)
    End Sub
'End Record Form CONTRIBUTION1 LoadItemFromRequest method

'Record Form CONTRIBUTION1 GetRedirectUrl method @57-AAD0C2F9

    Protected Function GetCONTRIBUTION1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "CONTRIBUTION_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form CONTRIBUTION1 GetRedirectUrl method

'Record Form CONTRIBUTION1 ShowErrors method @57-B4C9F6BC

    Protected Sub CONTRIBUTION1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To CONTRIBUTION1Errors.Count - 1
        Select Case CONTRIBUTION1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & CONTRIBUTION1Errors(i)
        End Select
        Next i
        CONTRIBUTION1Error.Visible = True
        CONTRIBUTION1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form CONTRIBUTION1 ShowErrors method

'Record Form CONTRIBUTION1 Insert Operation @57-40D74E58

    Protected Sub CONTRIBUTION1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        CONTRIBUTION1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CONTRIBUTION1 Insert Operation

'Record Form CONTRIBUTION1 BeforeInsert tail @57-DFEF7D53
    CONTRIBUTION1Parameters()
    CONTRIBUTION1LoadItemFromRequest(item, EnableValidation)
'End Record Form CONTRIBUTION1 BeforeInsert tail

'Record Form CONTRIBUTION1 AfterInsert tail  @57-CB8C83F2
        ErrorFlag=(CONTRIBUTION1Errors.Count > 0)
        If ErrorFlag Then
            CONTRIBUTION1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CONTRIBUTION1 AfterInsert tail 

'Record Form CONTRIBUTION1 Update Operation @57-5DD1A067

    Protected Sub CONTRIBUTION1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        CONTRIBUTION1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CONTRIBUTION1 Update Operation

'Record Form CONTRIBUTION1 Before Update tail @57-DFEF7D53
        CONTRIBUTION1Parameters()
        CONTRIBUTION1LoadItemFromRequest(item, EnableValidation)
'End Record Form CONTRIBUTION1 Before Update tail

'Record Form CONTRIBUTION1 Update Operation tail @57-CB8C83F2
        ErrorFlag=(CONTRIBUTION1Errors.Count > 0)
        If ErrorFlag Then
            CONTRIBUTION1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CONTRIBUTION1 Update Operation tail

'Record Form CONTRIBUTION1 Delete Operation @57-3FA7299F
    Protected Sub CONTRIBUTION1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        CONTRIBUTION1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form CONTRIBUTION1 Delete Operation

'Record Form BeforeDelete tail @57-DFEF7D53
        CONTRIBUTION1Parameters()
        CONTRIBUTION1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @57-7D808AF5
        If ErrorFlag Then
            CONTRIBUTION1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form CONTRIBUTION1 Cancel Operation @57-418A5022

    Protected Sub CONTRIBUTION1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        CONTRIBUTION1IsSubmitted = True
        Dim RedirectUrl As String = ""
        CONTRIBUTION1LoadItemFromRequest(item, True)
'End Record Form CONTRIBUTION1 Cancel Operation

'Record Form CONTRIBUTION1 Cancel Operation tail @57-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form CONTRIBUTION1 Cancel Operation tail

'Record Form CONTRIBUTION1 Search Operation @57-C6766EED
    Protected Sub CONTRIBUTION1_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        CONTRIBUTION1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As CONTRIBUTION1Item = New CONTRIBUTION1Item()
        CONTRIBUTION1LoadItemFromRequest(item, EnableValidation)
'End Record Form CONTRIBUTION1 Search Operation

'Button Button_DoSearch OnClick. @58-8C668E96
        If CType(sender,Control).ID = "CONTRIBUTION1Button_DoSearch" Then
            RedirectUrl = GetCONTRIBUTION1RedirectUrl("", "s_CATEGORY_CODE;s_CAMPUS_CODE")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @58-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form CONTRIBUTION1 Search Operation tail @57-DCC8837D
        ErrorFlag = CONTRIBUTION1Errors.Count > 0
        If ErrorFlag Then
            CONTRIBUTION1ShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(CONTRIBUTION1s_CATEGORY_CODE.Text <> "",("s_CATEGORY_CODE=" & Server.UrlEncode(CONTRIBUTION1s_CATEGORY_CODE.Text) & "&"), "")
            For Each li In CONTRIBUTION1s_CAMPUS_CODE.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_CAMPUS_CODE=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form CONTRIBUTION1 Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F15C0820
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        CONTRIBUTION_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        CONTRIBUTIONData = New CONTRIBUTIONDataProvider()
        CONTRIBUTIONOperations = New FormSupportedOperations(False, True, False, False, False)
        CONTRIBUTION1Data = New CONTRIBUTION1DataProvider()
        CONTRIBUTION1Operations = New FormSupportedOperations(False, True, True, True, True)
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

