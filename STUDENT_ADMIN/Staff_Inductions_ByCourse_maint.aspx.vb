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

Namespace DECV_PROD2007.Staff_Inductions_ByCourse_maint 'Namespace @1-67818780

'Forms Definition @1-EE2BD802
Public Class [Staff_Inductions_ByCourse_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-32D3CF6E
    Protected STAFF_INDUCTIONS_COURSESData As STAFF_INDUCTIONS_COURSESDataProvider
    Protected STAFF_INDUCTIONS_COURSESErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_COURSESOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESIsSubmitted As Boolean = False
    Protected STAFF_INDUCTIONS_COURSES1Data As STAFF_INDUCTIONS_COURSES1DataProvider
    Protected STAFF_INDUCTIONS_COURSES1Operations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSES1CurrentRowNumber As Integer
    Protected Staff_Inductions_ByCourse_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-AAD68F3E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.link_backtolistHref = "Staff_Inductions_ByCourse_list.aspx"
            PageData.FillItem(item)
            link_backtolist.InnerText += item.link_backtolist.GetFormattedValue().Replace(vbCrLf,"")
            link_backtolist.HRef = item.link_backtolistHref+item.link_backtolistHrefParameters.ToString("GET","", ViewState)
            link_backtolist.DataBind()
            STAFF_INDUCTIONS_COURSESShow()
            STAFF_INDUCTIONS_COURSES1Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STAFF_INDUCTIONS_COURSES Parameters @3-3BA5A226

    Protected Sub STAFF_INDUCTIONS_COURSESParameters()
        Dim item As new STAFF_INDUCTIONS_COURSESItem
        Try
            STAFF_INDUCTIONS_COURSESData.Urlid = IntegerParameter.GetParam("id", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STAFF_INDUCTIONS_COURSESErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Parameters

'Record Form STAFF_INDUCTIONS_COURSES Show method @3-03643646
    Protected Sub STAFF_INDUCTIONS_COURSESShow()
        If STAFF_INDUCTIONS_COURSESOperations.None Then
            STAFF_INDUCTIONS_COURSESHolder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_COURSESItem = STAFF_INDUCTIONS_COURSESItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_COURSESOperations.AllowRead
        STAFF_INDUCTIONS_COURSESErrors.Add(item.errors)
        If STAFF_INDUCTIONS_COURSESErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_COURSES Show method

'Record Form STAFF_INDUCTIONS_COURSES BeforeShow tail @3-24005CA0
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESData.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_COURSESHolder.DataBind()
        STAFF_INDUCTIONS_COURSESButton_Insert.Visible=IsInsertMode AndAlso STAFF_INDUCTIONS_COURSESOperations.AllowInsert
        STAFF_INDUCTIONS_COURSESButton_Update.Visible=Not (IsInsertMode) AndAlso STAFF_INDUCTIONS_COURSESOperations.AllowUpdate
        STAFF_INDUCTIONS_COURSESButton_Delete.Visible=Not (IsInsertMode) AndAlso STAFF_INDUCTIONS_COURSESOperations.AllowDelete
        STAFF_INDUCTIONS_COURSESINDUCTION_TITLE.Text=item.INDUCTION_TITLE.GetFormattedValue()
        STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION.Text=item.INDUCTION_DESCRIPTION.GetFormattedValue()
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        STAFF_INDUCTIONS_COURSESSTATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(STAFF_INDUCTIONS_COURSESSTATUS.Items)
        STAFF_INDUCTIONS_COURSESLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_COURSESLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form STAFF_INDUCTIONS_COURSES BeforeShow tail

'Record Form STAFF_INDUCTIONS_COURSES Show method tail @3-5454F67D
        If STAFF_INDUCTIONS_COURSESErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Show method tail

'Record Form STAFF_INDUCTIONS_COURSES LoadItemFromRequest method @3-614BB054

    Protected Sub STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item As STAFF_INDUCTIONS_COURSESItem, ByVal EnableValidation As Boolean)
        item.INDUCTION_TITLE.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESINDUCTION_TITLE.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSESINDUCTION_TITLE") Is Nothing Then
            item.INDUCTION_TITLE.SetValue(STAFF_INDUCTIONS_COURSESINDUCTION_TITLE.Text)
        Else
            item.INDUCTION_TITLE.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSESINDUCTION_TITLE"))
        End If
        item.INDUCTION_DESCRIPTION.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION") Is Nothing Then
            item.INDUCTION_DESCRIPTION.SetValue(STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION.Text)
        Else
            item.INDUCTION_DESCRIPTION.SetValue(ControlCustomValues("STAFF_INDUCTIONS_COURSESINDUCTION_DESCRIPTION"))
        End If
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESSTATUS.UniqueID))
        If Not IsNothing(STAFF_INDUCTIONS_COURSESSTATUS.SelectedItem) Then
            item.STATUS.SetValue(STAFF_INDUCTIONS_COURSESSTATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(STAFF_INDUCTIONS_COURSESSTATUS.Items)
        Catch ae As ArgumentException
            STAFF_INDUCTIONS_COURSESErrors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STAFF_INDUCTIONS_COURSESErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_COURSESData)
        End If
        STAFF_INDUCTIONS_COURSESErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_COURSES GetRedirectUrl method @3-F18AA868

    Protected Function GetSTAFF_INDUCTIONS_COURSESRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_Inductions_ByCourse_list.aspx"
        Dim p As String = parameters.ToString("GET","id;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_INDUCTIONS_COURSES GetRedirectUrl method

'Record Form STAFF_INDUCTIONS_COURSES ShowErrors method @3-241B4AFF

    Protected Sub STAFF_INDUCTIONS_COURSESShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_INDUCTIONS_COURSESErrors.Count - 1
        Select Case STAFF_INDUCTIONS_COURSESErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_INDUCTIONS_COURSESErrors(i)
        End Select
        Next i
        STAFF_INDUCTIONS_COURSESError.Visible = True
        STAFF_INDUCTIONS_COURSESErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES ShowErrors method

'Record Form STAFF_INDUCTIONS_COURSES Insert Operation @3-25423B2B

    Protected Sub STAFF_INDUCTIONS_COURSES_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        Dim ExecuteFlag As Boolean = True
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES Insert Operation

'Button Button_Insert OnClick. @4-B4D30CF3
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESButton_Insert" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @4-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STAFF_INDUCTIONS_COURSES Event BeforeInsert. Action Retrieve Value for Control @17-3549C753
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STAFF_INDUCTIONS_COURSES Event BeforeInsert. Action Retrieve Value for Control

'Record STAFF_INDUCTIONS_COURSES Event BeforeInsert. Action Retrieve Value for Control @20-1422E7DF
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record STAFF_INDUCTIONS_COURSES Event BeforeInsert. Action Retrieve Value for Control

'Record Form STAFF_INDUCTIONS_COURSES BeforeInsert tail @3-ACE5055D
    STAFF_INDUCTIONS_COURSESParameters()
    STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
    If STAFF_INDUCTIONS_COURSESOperations.AllowInsert Then
        ErrorFlag=(STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_COURSESData.InsertItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_COURSESErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_COURSES BeforeInsert tail

'Record Form STAFF_INDUCTIONS_COURSES AfterInsert tail  @3-3457E543
        End If
        ErrorFlag=(STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES AfterInsert tail 

'Record Form STAFF_INDUCTIONS_COURSES Update Operation @3-B6C588A1

    Protected Sub STAFF_INDUCTIONS_COURSES_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES Update Operation

'Button Button_Update OnClick. @5-F5309B4B
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESButton_Update" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STAFF_INDUCTIONS_COURSES Event BeforeUpdate. Action Retrieve Value for Control @18-3549C753
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STAFF_INDUCTIONS_COURSES Event BeforeUpdate. Action Retrieve Value for Control

'Record STAFF_INDUCTIONS_COURSES Event BeforeUpdate. Action Retrieve Value for Control @19-1422E7DF
        STAFF_INDUCTIONS_COURSEShidden_LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record STAFF_INDUCTIONS_COURSES Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STAFF_INDUCTIONS_COURSES Before Update tail @3-69545FDF
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
        If STAFF_INDUCTIONS_COURSESOperations.AllowUpdate Then
        ErrorFlag = (STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_COURSESData.UpdateItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_COURSESErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_COURSES Before Update tail

'Record Form STAFF_INDUCTIONS_COURSES Update Operation tail @3-3457E543
        End If
        ErrorFlag=(STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Update Operation tail

'Record Form STAFF_INDUCTIONS_COURSES Delete Operation @3-F9DB744D
    Protected Sub STAFF_INDUCTIONS_COURSES_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_INDUCTIONS_COURSES Delete Operation

'Button Button_Delete OnClick. @6-822F1AD1
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESButton_Delete" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @6-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @3-E20CD880
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-C7163990
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_INDUCTIONS_COURSES Cancel Operation @3-3C9791B7

    Protected Sub STAFF_INDUCTIONS_COURSES_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, False)
'End Record Form STAFF_INDUCTIONS_COURSES Cancel Operation

'Button Button_Cancel OnClick. @8-13DBD771
    If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESButton_Cancel" Then
        RedirectUrl = GetSTAFF_INDUCTIONS_COURSESRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @8-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSES Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Cancel Operation tail

'Grid STAFF_INDUCTIONS_COURSES1 Bind @21-FDE75338

    Protected Sub STAFF_INDUCTIONS_COURSES1Bind()
        If Not STAFF_INDUCTIONS_COURSES1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF_INDUCTIONS_COURSES1",GetType(STAFF_INDUCTIONS_COURSES1DataProvider.SortFields), 30, 100)
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 Bind

'Grid Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail @21-58403336
        STAFF_INDUCTIONS_COURSES1Parameters()
        STAFF_INDUCTIONS_COURSES1Data.SortField = CType(ViewState("STAFF_INDUCTIONS_COURSES1SortField"),STAFF_INDUCTIONS_COURSES1DataProvider.SortFields)
        STAFF_INDUCTIONS_COURSES1Data.SortDir = CType(ViewState("STAFF_INDUCTIONS_COURSES1SortDir"),SortDirections)
        STAFF_INDUCTIONS_COURSES1Data.PageNumber = CInt(ViewState("STAFF_INDUCTIONS_COURSES1PageNumber"))
        STAFF_INDUCTIONS_COURSES1Data.RecordsPerPage = CInt(ViewState("STAFF_INDUCTIONS_COURSES1PageSize"))
        STAFF_INDUCTIONS_COURSES1Repeater.DataSource = STAFF_INDUCTIONS_COURSES1Data.GetResultSet(PagesCount, STAFF_INDUCTIONS_COURSES1Operations)
        ViewState("STAFF_INDUCTIONS_COURSES1PagesCount") = PagesCount
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        STAFF_INDUCTIONS_COURSES1Repeater.DataBind
        FooterIndex = STAFF_INDUCTIONS_COURSES1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STAFF_INDUCTIONS_COURSES1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DATE_COMPLETEDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_DATE_COMPLETEDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_staffnameSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_staffnameSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_INDUCTION_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_INDUCTION_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STAFF_INDUCTIONS_COURSES1Panel_header_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("STAFF_INDUCTIONS_COURSES1Panel_header_editbutton"),System.Web.UI.WebControls.PlaceHolder)

'End Grid Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Hide-Show Component @37-8ADBD222
        Dim Urlid_37_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("id"))
        Dim ExprParam2_37_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urlid_37_1, ExprParam2_37_2) Then
            STAFF_INDUCTIONS_COURSES1Repeater.Visible = False
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Hide-Show Component

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code @38-73254650
    ' -------------------------
	' also hide the Add New and 'edit' for Teachers
 		If (DBUtility.AuthorizeUser(New String(){"2","3","4","7","9"})) Then
			STAFF_INDUCTIONS_COURSES1Panel_header_editbutton.visible = True
		else
			STAFF_INDUCTIONS_COURSES1Panel_header_editbutton.visible = false
    	End If
    ' -------------------------
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code

'Grid STAFF_INDUCTIONS_COURSES1 Bind tail @21-E31F8E2A
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Bind tail

'Grid STAFF_INDUCTIONS_COURSES1 Table Parameters @21-91B63A77

    Protected Sub STAFF_INDUCTIONS_COURSES1Parameters()
        Try
            STAFF_INDUCTIONS_COURSES1Data.Urlid = IntegerParameter.GetParam("id", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STAFF_INDUCTIONS_COURSES1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STAFF_INDUCTIONS_COURSES1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STAFF_INDUCTIONS_COURSES1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Table Parameters

'Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event @21-46CEC930

    Protected Sub STAFF_INDUCTIONS_COURSES1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STAFF_INDUCTIONS_COURSES1Item = CType(e.Item.DataItem,STAFF_INDUCTIONS_COURSES1Item)
        Dim Item as STAFF_INDUCTIONS_COURSES1Item = DataItem
        Dim FormDataSource As STAFF_INDUCTIONS_COURSES1Item() = CType(STAFF_INDUCTIONS_COURSES1Repeater.DataSource, STAFF_INDUCTIONS_COURSES1Item())
        Dim STAFF_INDUCTIONS_COURSES1DataRows As Integer = FormDataSource.Length
        Dim STAFF_INDUCTIONS_COURSES1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFF_INDUCTIONS_COURSES1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STAFF_INDUCTIONS_COURSES1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFF_INDUCTIONS_COURSES1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1DATE_COMPLETED As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1DATE_COMPLETED"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1staffname As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1staffname"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1Panel_data_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Panel_data_editbutton"),System.Web.UI.WebControls.PlaceHolder)
            Dim STAFF_INDUCTIONS_COURSES1Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.Link1Href = "Staff_Inductions_ByStaff.aspx"
            STAFF_INDUCTIONS_COURSES1Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event

'Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event @21-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShowRow. Action Custom Code @39-73254650
    ' -------------------------
    	' also hide the Add New and 'edit' for Teachers
 		If (DBUtility.AuthorizeUser(New String(){"2","3","4","7","9"})) Then
			Dim panel_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Panel_data_editbutton"),System.Web.UI.WebControls.PlaceHolder)
			panel_editbutton.visible = True
    	End If
    ' -------------------------
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShowRow. Action Custom Code

'Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event tail @21-477CF3C9
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event tail

'Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event tail @21-00C0539C
        If STAFF_INDUCTIONS_COURSES1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STAFF_INDUCTIONS_COURSES1CurrentRowNumber, ListItemType.Item)
            STAFF_INDUCTIONS_COURSES1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STAFF_INDUCTIONS_COURSES1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event tail

'Grid STAFF_INDUCTIONS_COURSES1 ItemCommand event @21-CA556B65

    Protected Sub STAFF_INDUCTIONS_COURSES1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STAFF_INDUCTIONS_COURSES1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STAFF_INDUCTIONS_COURSES1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STAFF_INDUCTIONS_COURSES1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=SortDirections._Desc
                Else
                    ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STAFF_INDUCTIONS_COURSES1DataProvider.SortFields = 0
            ViewState("STAFF_INDUCTIONS_COURSES1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STAFF_INDUCTIONS_COURSES1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STAFF_INDUCTIONS_COURSES1Bind
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-025BCE8D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_Inductions_ByCourse_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_INDUCTIONS_COURSESData = New STAFF_INDUCTIONS_COURSESDataProvider()
        STAFF_INDUCTIONS_COURSESOperations = New FormSupportedOperations(False, True, True, True, False)
        STAFF_INDUCTIONS_COURSES1Data = New STAFF_INDUCTIONS_COURSES1DataProvider()
        STAFF_INDUCTIONS_COURSES1Operations = New FormSupportedOperations(False, True, False, False, False)
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

