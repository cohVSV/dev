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

Namespace DECV_PROD2007.Student_GreenLetters_maint 'Namespace @1-AC1F8100

'Forms Definition @1-56A7EE3A
Public Class [Student_GreenLetters_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1E580BF7
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestCurrentRowNumber As Integer
    Protected viewMaintainSearchRequestIsSubmitted As Boolean = False
    Protected viewMaintainSearchRequestErrors As New NameValueCollection()
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestDataItem As viewMaintainSearchRequestItem
    Protected viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1Name As String
    Protected viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1DateControl As String
    Protected viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1Name As String
    Protected viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1DateControl As String
    Protected viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1Name As String
    Protected viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1DateControl As String
    Protected GREEN_AMBER_RED_LETTERS_vData As GREEN_AMBER_RED_LETTERS_vDataProvider
    Protected GREEN_AMBER_RED_LETTERS_vErrors As NameValueCollection = New NameValueCollection()
    Protected GREEN_AMBER_RED_LETTERS_vOperations As FormSupportedOperations
    Protected GREEN_AMBER_RED_LETTERS_vIsSubmitted As Boolean = False
    Protected GREEN_AMBER_RED_LETTERSData As GREEN_AMBER_RED_LETTERSDataProvider
    Protected GREEN_AMBER_RED_LETTERSErrors As NameValueCollection = New NameValueCollection()
    Protected GREEN_AMBER_RED_LETTERSOperations As FormSupportedOperations
    Protected GREEN_AMBER_RED_LETTERSIsSubmitted As Boolean = False
    Protected GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1Name As String
    Protected GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1DateControl As String
    Protected Student_GreenLetters_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-45F8BE97
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewMaintainSearchRequestBind()
            GREEN_AMBER_RED_LETTERS_vShow()
            GREEN_AMBER_RED_LETTERSShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_GreenLetters_maint Event BeforeShow. Action Custom Code @207-73254650
    ' -------------------------
    '21-May-2015|EA testing notification
    Page.ClientScript.RegisterStartupScript(GetType(Page), "notificationScript", (Convert.ToString("<script>$(function() {$.notifyBar({html: 'SMAP! Here We Go!',delay: 2000,animationSpeed: 'normal'});});</script>")))
    ' -------------------------
'End Page Student_GreenLetters_maint Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid viewMaintainSearchRequest Bind @3-3D681A8E
    Protected Sub viewMaintainSearchRequestBind()
        If viewMaintainSearchRequestOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest",GetType(viewMaintainSearchRequestDataProvider.SortFields), 20, 100)
        End If
'End EditableGrid viewMaintainSearchRequest Bind

'EditableGrid Form viewMaintainSearchRequest BeforeShow tail @3-50E12CF0
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestData.SortField = CType(ViewState("viewMaintainSearchRequestSortField"), viewMaintainSearchRequestDataProvider.SortFields)
        viewMaintainSearchRequestData.SortDir = CType(ViewState("viewMaintainSearchRequestSortDir"), SortDirections)
        viewMaintainSearchRequestData.PageNumber = CType(ViewState("viewMaintainSearchRequestPageNumber"), Integer)
        viewMaintainSearchRequestData.RecordsPerPage = CType(ViewState("viewMaintainSearchRequestPageSize"), Integer)
        viewMaintainSearchRequestRepeater.DataSource = viewMaintainSearchRequestData.GetResultSet(PagesCount, viewMaintainSearchRequestOperations)
        ViewState("viewMaintainSearchRequestPagesCount") = PagesCount
        ViewState("viewMaintainSearchRequestFormState") = New Hashtable()
        ViewState("viewMaintainSearchRequestRowState") = New Hashtable()
        viewMaintainSearchRequestRepeater.DataBind()
        Dim item As viewMaintainSearchRequestItem = viewMaintainSearchRequestDataItem
        If IsNothing(item) Then item = New viewMaintainSearchRequestItem()
        FooterIndex = viewMaintainSearchRequestRepeater.Controls.Count - 1
        Dim viewMaintainSearchRequestviewMaintainSearchRequest_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("viewMaintainSearchRequestviewMaintainSearchRequest_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PASTORAL_CARE_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_PASTORAL_CARE_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_ADDED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_FIRST_ADDED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GREEN_LETTER_SENT_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_GREEN_LETTER_SENT_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GREEN_LETTER_SENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_GREEN_LETTER_SENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_AMBER_LETTER_SENT_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_AMBER_LETTER_SENT_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_AMBER_LETTER_SENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_AMBER_LETTER_SENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RED_LETTER_SENT_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_RED_LETTER_SENT_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RED_LETTER_SENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_RED_LETTER_SENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {20,50,100,250,500}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim viewMaintainSearchRequestButton_Submit As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequestButton_Submit"),System.Web.UI.WebControls.Button)
        Dim viewMaintainSearchRequestCancel As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequestCancel"),System.Web.UI.WebControls.Button)
        Dim Sorter_LAST_ALTERED_DATE1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATE1Sorter"),DECV_PROD2007.Controls.Sorter)


        viewMaintainSearchRequestviewMaintainSearchRequest_TotalRecords.Text = Server.HtmlEncode(item.viewMaintainSearchRequest_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewMaintainSearchRequestButton_Submit.Visible = viewMaintainSearchRequestOperations.Editable
        If Not CType(viewMaintainSearchRequestRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If viewMaintainSearchRequestErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("viewMaintainSearchRequestError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In viewMaintainSearchRequestErrors
                ErrorLabel.Text += viewMaintainSearchRequestErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form viewMaintainSearchRequest BeforeShow tail

'Label viewMaintainSearchRequest_TotalRecords Event BeforeShow. Action Retrieve number of records @15-060627AF
            viewMaintainSearchRequestviewMaintainSearchRequest_TotalRecords.Text = viewMaintainSearchRequestData.RecordCount.ToString()
'End Label viewMaintainSearchRequest_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid viewMaintainSearchRequest Bind tail @3-C5CBE602
        viewMaintainSearchRequestShowErrors(New ArrayList(CType(viewMaintainSearchRequestRepeater.DataSource, ICollection)), viewMaintainSearchRequestRepeater.Items)
    End Sub
'End EditableGrid viewMaintainSearchRequest Bind tail

'EditableGrid viewMaintainSearchRequest Table Parameters @3-FB8EB431
    Protected Sub viewMaintainSearchRequestParameters()
        Try
        Dim item As new viewMaintainSearchRequestItem
            viewMaintainSearchRequestData.Urls_STAFF_ID = TextParameter.GetParam("s_STAFF_ID", ParameterSourceType.URL, "", "", false)
            viewMaintainSearchRequestData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            viewMaintainSearchRequestData.Urls_SUBSCHOOL = TextParameter.GetParam("s_SUBSCHOOL", ParameterSourceType.URL, "", "F-9", false)
            viewMaintainSearchRequestData.CtrlGREEN_LETTER_SENT_FLAG = TextParameter.GetParam(item.GREEN_LETTER_SENT_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            viewMaintainSearchRequestData.CtrlGREEN_LETTER_SENT_DATE = DateParameter.GetParam(item.GREEN_LETTER_SENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            viewMaintainSearchRequestData.CtrlAMBER_LETTER_SENT_FLAG = TextParameter.GetParam(item.AMBER_LETTER_SENT_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            viewMaintainSearchRequestData.CtrlAMBER_LETTER_SENT_DATE = DateParameter.GetParam(item.AMBER_LETTER_SENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            viewMaintainSearchRequestData.CtrlRED_LETTER_SENT_FLAG = TextParameter.GetParam(item.RED_LETTER_SENT_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            viewMaintainSearchRequestData.CtrlRED_LETTER_SENT_DATE = DateParameter.GetParam(item.RED_LETTER_SENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            viewMaintainSearchRequestData.Expr114 = TextParameter.GetParam(NOW(), ParameterSourceType.Expression, "", NOW(), false)
            viewMaintainSearchRequestData.Expr117 = TextParameter.GetParam(DBUtility.UserID.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = viewMaintainSearchRequestRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(viewMaintainSearchRequestRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid viewMaintainSearchRequest: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid viewMaintainSearchRequest Table Parameters

'EditableGrid viewMaintainSearchRequest ItemDataBound event @3-9D0771E6
    Protected Sub viewMaintainSearchRequestItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As viewMaintainSearchRequestItem = DirectCast(e.Item.DataItem, viewMaintainSearchRequestItem)
        Dim Item as viewMaintainSearchRequestItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequestCurrentRowNumber = viewMaintainSearchRequestCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequestFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequestRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("IDField:" & e.Item.ItemIndex, DataItem.IDField.Value)
            ViewState(e.Item.FindControl("viewMaintainSearchRequestSTUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestSURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestFIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestYEAR_LEVEL").UniqueID) = DataItem.YEAR_LEVEL.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestPASTORAL_CARE_ID").UniqueID) = DataItem.PASTORAL_CARE_ID.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestFIRST_ADDED_DATE").UniqueID) = DataItem.FIRST_ADDED_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestLAST_ALTERED_BY").UniqueID) = DataItem.LAST_ALTERED_BY.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequestLAST_ALTERED_DATE").UniqueID) = DataItem.LAST_ALTERED_DATE.Value
            Dim viewMaintainSearchRequestSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequestSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestPASTORAL_CARE_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestPASTORAL_CARE_ID"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestFIRST_ADDED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestFIRST_ADDED_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
            Dim viewMaintainSearchRequestGREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
            Dim viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
            Dim viewMaintainSearchRequestAMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
            Dim viewMaintainSearchRequestRED_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
            Dim viewMaintainSearchRequestRED_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
            Dim viewMaintainSearchRequestLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
            Dim viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
            Dim viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
            Dim viewMaintainSearchRequesthidden_DaysSince_Green As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequesthidden_DaysSince_Green"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim viewMaintainSearchRequesthidden_DaysSince_Amber As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequesthidden_DaysSince_Amber"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim viewMaintainSearchRequestLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequestRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequestCurrentRowNumber), AttributeOption.Multiple)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            viewMaintainSearchRequestSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","", ViewState)
            DataItem.GREEN_LETTER_SENT_FLAGItems.SetSelection(DataItem.GREEN_LETTER_SENT_FLAG.GetFormattedValue())
            viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.SelectedIndex = -1
            DataItem.GREEN_LETTER_SENT_FLAGItems.CopyTo(viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.Items)
            DataItem.AMBER_LETTER_SENT_FLAGItems.SetSelection(DataItem.AMBER_LETTER_SENT_FLAG.GetFormattedValue())
            viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.SelectedIndex = -1
            DataItem.AMBER_LETTER_SENT_FLAGItems.CopyTo(viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.Items)
            DataItem.RED_LETTER_SENT_FLAGItems.SetSelection(DataItem.RED_LETTER_SENT_FLAG.GetFormattedValue())
            viewMaintainSearchRequestRED_LETTER_SENT_FLAG.SelectedIndex = -1
            DataItem.RED_LETTER_SENT_FLAGItems.CopyTo(viewMaintainSearchRequestRED_LETTER_SENT_FLAG.Items)
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                viewMaintainSearchRequestCheckBox_Delete.Checked = True
            End If
            viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1Name = "viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1"
            viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1DateControl = e.Item.FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_DATE").ClientID
            viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1.DataBind()
            viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1Name = "viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1"
            viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1DateControl = e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE").ClientID
            viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.DataBind()
            viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1Name = "viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1"
            viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1DateControl = e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_DATE").ClientID
            viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.DataBind()
        End If
'End EditableGrid viewMaintainSearchRequest ItemDataBound event

'viewMaintainSearchRequest control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End viewMaintainSearchRequest control Before Show

'Get Control @38-8C2A7D37
            Dim viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton GREEN_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code @137-73254650
    ' -------------------------
    viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.RepeatDirection = RepeatDirection.Vertical
    ' -------------------------
'End RadioButton GREEN_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code

'Get Control @41-01E0C136
            Dim viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton AMBER_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code @136-73254650
    ' -------------------------
    viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.RepeatDirection = RepeatDirection.Vertical
    ' -------------------------
'End RadioButton AMBER_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code

'Get Control @44-3539EFC8
            Dim viewMaintainSearchRequestRED_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton RED_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code @135-73254650
    ' -------------------------
    viewMaintainSearchRequestRED_LETTER_SENT_FLAG.RepeatDirection = RepeatDirection.Vertical
    ' -------------------------
'End RadioButton RED_LETTER_SENT_FLAG Event BeforeShow. Action Custom Code

'viewMaintainSearchRequest control Before Show tail @3-477CF3C9
        End If
'End viewMaintainSearchRequest control Before Show tail

'EditableGrid viewMaintainSearchRequest BeforeShowRow event @3-9E067462
        If Not IsNothing(Item) Then viewMaintainSearchRequestDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid viewMaintainSearchRequest BeforeShowRow event

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Declare Variable @118-BD9E6078
            Dim intDaysSince_Green As Int64 = 0
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Declare Variable

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Declare Variable @119-9F21D0C8
            Dim intDaysSince_Amber As Int64 = 0
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Declare Variable

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Custom Code @120-73254650
    ' -------------------------
    ' for some reason this part of the code needs to have the fields re-Dimmed (or initialised for first open)
    Dim viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
    Dim viewMaintainSearchRequestAMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
    Dim viewMaintainSearchRequestRED_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
    Dim viewMaintainSearchRequestRED_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRED_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
    Dim viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
    Dim viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
    Dim viewMaintainSearchRequesthidden_DaysSince_Green As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequesthidden_DaysSince_Green"),System.Web.UI.HtmlControls.HtmlInputHidden)
    Dim viewMaintainSearchRequesthidden_DaysSince_Amber As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequesthidden_DaysSince_Amber"),System.Web.UI.HtmlControls.HtmlInputHidden)
        
    ' -------------------------
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Custom Code

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Save Control Value @104-E0F0D44D
            If Not IsNothing(viewMaintainSearchRequesthidden_DaysSince_Green) Then intDaysSince_Green=viewMaintainSearchRequesthidden_DaysSince_Green.Value
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Save Control Value

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Save Control Value @105-6C4BFF36
            If Not IsNothing(viewMaintainSearchRequesthidden_DaysSince_Amber) Then intDaysSince_Amber=viewMaintainSearchRequesthidden_DaysSince_Amber.Value
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Save Control Value

'EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Custom Code @73-73254650
    ' -------------------------
    '9-Mar-2015|EA| check days since last letter sent:
    '17-Mar-2016|EA| check if the Amber sent date is already there and show it, even if not 10 days yet
    '		Show AMBER only after today = Green Date + 10 days AND there is not a date already there (in case sent early)
    '		Show RED only after today = Amber Date + 10 days
    	if (intDaysSince_Green < 10 and viewMaintainSearchRequestAMBER_LETTER_SENT_DATE.Text = "") then
    		' hide AMBER (and RED)
    		viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.Visible = false
    		viewMaintainSearchRequestAMBER_LETTER_SENT_DATE.Visible = false
    		viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.Visible = false
    		viewMaintainSearchRequestRED_LETTER_SENT_FLAG.Visible = false
    		viewMaintainSearchRequestRED_LETTER_SENT_DATE.Visible = false
    		viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.Visible = false
    	else
    		' show AMBER
    		viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.Visible = true
    		viewMaintainSearchRequestAMBER_LETTER_SENT_DATE.Visible = true
    		viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1.Visible = true
    	end if
    	
    	if (intDaysSince_Amber < 10) then
    		'hide RED
    		viewMaintainSearchRequestRED_LETTER_SENT_FLAG.Visible = false
    		viewMaintainSearchRequestRED_LETTER_SENT_DATE.Visible = false
    		viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.Visible = false
    	else
    		viewMaintainSearchRequestRED_LETTER_SENT_FLAG.Visible = true
    		viewMaintainSearchRequestRED_LETTER_SENT_DATE.Visible = true
    		viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1.Visible = true
    	end if
    	
    	
    ' -------------------------
'End EditableGrid viewMaintainSearchRequest Event BeforeShowRow. Action Custom Code

'EditableGrid viewMaintainSearchRequest BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid viewMaintainSearchRequest BeforeShowRow event tail

'EditableGrid viewMaintainSearchRequest ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid viewMaintainSearchRequest ItemDataBound event tail

'EditableGrid viewMaintainSearchRequest GetRedirectUrl method @3-7CD4912A
    Protected Function GetviewMaintainSearchRequestRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetviewMaintainSearchRequestRedirectUrl(ByVal redirectString As String) As String
        Return GetviewMaintainSearchRequestRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid viewMaintainSearchRequest GetRedirectUrl method

'EditableGrid viewMaintainSearchRequest ShowErrors method @3-96084C75
    Protected Function viewMaintainSearchRequestShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), viewMaintainSearchRequestItem).IsUpdated Then col(CType(items(i), viewMaintainSearchRequestItem).RowId).Visible = False
            If (CType(items(i), viewMaintainSearchRequestItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), viewMaintainSearchRequestItem).errors.Count - 1
                Select CType(items(i), viewMaintainSearchRequestItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), viewMaintainSearchRequestItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), viewMaintainSearchRequestItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), viewMaintainSearchRequestItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid viewMaintainSearchRequest ShowErrors method

'EditableGrid viewMaintainSearchRequest ItemCommand event @3-A9D504D4
    Protected Sub viewMaintainSearchRequestItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = viewMaintainSearchRequestRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid viewMaintainSearchRequest ItemCommand event

'Button Button_Submit OnClick. @51-9FCC7620
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequestButton_Submit" Then
            RedirectUrl  = GetviewMaintainSearchRequestRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @51-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @52-A88B9A11
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequestCancel" Then
            RedirectUrl  = GetviewMaintainSearchRequestRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @52-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form viewMaintainSearchRequest ItemCommand event tail @3-E0411EE9
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("viewMaintainSearchRequestSortDir"), SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequestSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("viewMaintainSearchRequestSortDir") = SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequestSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequestSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As viewMaintainSearchRequestDataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequestSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequestPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("viewMaintainSearchRequestPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("viewMaintainSearchRequestPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequestPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            viewMaintainSearchRequestIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = viewMaintainSearchRequestRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequestFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequestRowState"), Hashtable)
            viewMaintainSearchRequestParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim viewMaintainSearchRequestSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequestSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequestSURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestSURNAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestFIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestPASTORAL_CARE_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestPASTORAL_CARE_ID"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestFIRST_ADDED_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestFIRST_ADDED_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
                    Dim viewMaintainSearchRequestGREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("viewMaintainSearchRequestGREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
                    Dim viewMaintainSearchRequestAMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim viewMaintainSearchRequestRED_LETTER_SENT_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("viewMaintainSearchRequestRED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.RadioButtonList)
                    Dim viewMaintainSearchRequestRED_LETTER_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("viewMaintainSearchRequestRED_LETTER_SENT_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim viewMaintainSearchRequestLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequestCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("viewMaintainSearchRequestCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("viewMaintainSearchRequestDatePicker_GREEN_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
                    Dim viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("viewMaintainSearchRequestDatePicker_AMBER_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
                    Dim viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("viewMaintainSearchRequestDatePicker_RED_LETTER_SENT_DATE1"),System.Web.UI.WebControls.PlaceHolder)
                    Dim viewMaintainSearchRequesthidden_DaysSince_Green As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("viewMaintainSearchRequesthidden_DaysSince_Green"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim viewMaintainSearchRequesthidden_DaysSince_Amber As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("viewMaintainSearchRequesthidden_DaysSince_Amber"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim viewMaintainSearchRequestLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequestLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.IDField.Value = formState("IDField:" & col(i).ItemIndex)
                    item.STUDENT_ID.Value = ViewState(viewMaintainSearchRequestSTUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(viewMaintainSearchRequestSURNAME.UniqueID)
                    item.FIRST_NAME.Value = ViewState(viewMaintainSearchRequestFIRST_NAME.UniqueID)
                    item.YEAR_LEVEL.Value = ViewState(viewMaintainSearchRequestYEAR_LEVEL.UniqueID)
                    item.PASTORAL_CARE_ID.Value = ViewState(viewMaintainSearchRequestPASTORAL_CARE_ID.UniqueID)
                    item.FIRST_ADDED_DATE.Value = ViewState(viewMaintainSearchRequestFIRST_ADDED_DATE.UniqueID)
                    item.LAST_ALTERED_BY.Value = ViewState(viewMaintainSearchRequestLAST_ALTERED_BY.UniqueID)
                    item.LAST_ALTERED_DATE.Value = ViewState(viewMaintainSearchRequestLAST_ALTERED_DATE.UniqueID)
                    item.GREEN_LETTER_SENT_FLAG.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.UniqueID))
                    If Not IsNothing(viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.SelectedItem) Then
                        item.GREEN_LETTER_SENT_FLAG.SetValue(viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.SelectedItem.Value)
                    Else
                        item.GREEN_LETTER_SENT_FLAG.Value = Nothing
                    End If
                    item.GREEN_LETTER_SENT_FLAGItems.CopyFrom(viewMaintainSearchRequestGREEN_LETTER_SENT_FLAG.Items)
                    Try
                    item.GREEN_LETTER_SENT_DATE.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestGREEN_LETTER_SENT_DATE.UniqueID))
                    If ControlCustomValues("viewMaintainSearchRequestGREEN_LETTER_SENT_DATE") Is Nothing Then
                        item.GREEN_LETTER_SENT_DATE.SetValue(viewMaintainSearchRequestGREEN_LETTER_SENT_DATE.Text)
                    Else
                        item.GREEN_LETTER_SENT_DATE.SetValue(ControlCustomValues("viewMaintainSearchRequestGREEN_LETTER_SENT_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("GREEN_LETTER_SENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"GREEN LETTER SENT DATE","dd/mm/yyyy"))
                    End Try
                    item.AMBER_LETTER_SENT_FLAG.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.UniqueID))
                    If Not IsNothing(viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.SelectedItem) Then
                        item.AMBER_LETTER_SENT_FLAG.SetValue(viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.SelectedItem.Value)
                    Else
                        item.AMBER_LETTER_SENT_FLAG.Value = Nothing
                    End If
                    item.AMBER_LETTER_SENT_FLAGItems.CopyFrom(viewMaintainSearchRequestAMBER_LETTER_SENT_FLAG.Items)
                    Try
                    item.AMBER_LETTER_SENT_DATE.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestAMBER_LETTER_SENT_DATE.UniqueID))
                    If ControlCustomValues("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE") Is Nothing Then
                        item.AMBER_LETTER_SENT_DATE.SetValue(viewMaintainSearchRequestAMBER_LETTER_SENT_DATE.Text)
                    Else
                        item.AMBER_LETTER_SENT_DATE.SetValue(ControlCustomValues("viewMaintainSearchRequestAMBER_LETTER_SENT_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("AMBER_LETTER_SENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"AMBER LETTER SENT DATE","dd/mm/yyyy"))
                    End Try
                    item.RED_LETTER_SENT_FLAG.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestRED_LETTER_SENT_FLAG.UniqueID))
                    If Not IsNothing(viewMaintainSearchRequestRED_LETTER_SENT_FLAG.SelectedItem) Then
                        item.RED_LETTER_SENT_FLAG.SetValue(viewMaintainSearchRequestRED_LETTER_SENT_FLAG.SelectedItem.Value)
                    Else
                        item.RED_LETTER_SENT_FLAG.Value = Nothing
                    End If
                    item.RED_LETTER_SENT_FLAGItems.CopyFrom(viewMaintainSearchRequestRED_LETTER_SENT_FLAG.Items)
                    Try
                    item.RED_LETTER_SENT_DATE.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestRED_LETTER_SENT_DATE.UniqueID))
                    If ControlCustomValues("viewMaintainSearchRequestRED_LETTER_SENT_DATE") Is Nothing Then
                        item.RED_LETTER_SENT_DATE.SetValue(viewMaintainSearchRequestRED_LETTER_SENT_DATE.Text)
                    Else
                        item.RED_LETTER_SENT_DATE.SetValue(ControlCustomValues("viewMaintainSearchRequestRED_LETTER_SENT_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("RED_LETTER_SENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"RED LETTER SENT DATE","dd/mm/yyyy"))
                    End Try
                    Try
                    item.hidden_DaysSince_Green.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequesthidden_DaysSince_Green.UniqueID))
                    item.hidden_DaysSince_Green.SetValue(viewMaintainSearchRequesthidden_DaysSince_Green.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("hidden_DaysSince_Green",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_DaysSince_Green"))
                    End Try
                    Try
                    item.hidden_DaysSince_Amber.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequesthidden_DaysSince_Amber.UniqueID))
                    item.hidden_DaysSince_Amber.SetValue(viewMaintainSearchRequesthidden_DaysSince_Amber.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("hidden_DaysSince_Amber",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_DaysSince_Amber"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(viewMaintainSearchRequestData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form viewMaintainSearchRequest ItemCommand event tail

'EditableGrid viewMaintainSearchRequest Update @3-68D9CAFA
            If BindAllowed Then
                Try
                    viewMaintainSearchRequestParameters()
                    viewMaintainSearchRequestData.Update(items, viewMaintainSearchRequestOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(viewMaintainSearchRequestRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(viewMaintainSearchRequestRepeater.Controls(0).FindControl("viewMaintainSearchRequestError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
                Finally
'End EditableGrid viewMaintainSearchRequest Update

'EditableGrid viewMaintainSearchRequest Event AfterSubmit. Action Custom Code @176-73254650
    ' -------------------------
    ' 7-May-2015|EA| run the stored proc to add the Green Letters after Submit
    		Dim AddComments as SpCommand
			AddComments=new SpCommand("spi_GreenLetter_AddComments;1",Settings.connDECVPRODSQL2005DataAccessObject)
			CType(AddComments,SpCommand).AddParameter("@RETURN_VALUE",0,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
			CType(AddComments,SpCommand).AddParameter("@UpdateFlag",1,ParameterType._Int,ParameterDirection.Input,0,0,10)
			Dim result As Object = Nothing
			
			Try
				result = AddComments.ExecuteNonQuery()
				' return_value = IntegerParameter.GetParam(CType(ExtraInsert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
			Catch ee As Exception
				If Not IsNothing(ee) Then viewMaintainSearchRequestErrors.Add("Parameters",ee.Message)
			End Try
    
    ' -------------------------
'End EditableGrid viewMaintainSearchRequest Event AfterSubmit. Action Custom Code

'EditableGrid viewMaintainSearchRequest After Update @3-6BBE6A8C
                End Try
                If viewMaintainSearchRequestShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                viewMaintainSearchRequestShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                viewMaintainSearchRequestBind()
            End If
        End Sub
'End EditableGrid viewMaintainSearchRequest After Update

'Record Form GREEN_AMBER_RED_LETTERS_v Parameters @53-3817DA3B

    Protected Sub GREEN_AMBER_RED_LETTERS_vParameters()
        Dim item As new GREEN_AMBER_RED_LETTERS_vItem
        Try
        Catch e As Exception
            GREEN_AMBER_RED_LETTERS_vErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v Parameters

'Record Form GREEN_AMBER_RED_LETTERS_v Show method @53-7486864F
    Protected Sub GREEN_AMBER_RED_LETTERS_vShow()
        If GREEN_AMBER_RED_LETTERS_vOperations.None Then
            GREEN_AMBER_RED_LETTERS_vHolder.Visible = False
            Return
        End If
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = GREEN_AMBER_RED_LETTERS_vItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not GREEN_AMBER_RED_LETTERS_vOperations.AllowRead
        GREEN_AMBER_RED_LETTERS_vErrors.Add(item.errors)
        If GREEN_AMBER_RED_LETTERS_vErrors.Count > 0 Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
            Return
        End If
'End Record Form GREEN_AMBER_RED_LETTERS_v Show method

'Record Form GREEN_AMBER_RED_LETTERS_v BeforeShow tail @53-304B2A3F
        GREEN_AMBER_RED_LETTERS_vParameters()
        GREEN_AMBER_RED_LETTERS_vData.FillItem(item, IsInsertMode)
        GREEN_AMBER_RED_LETTERS_vHolder.DataBind()
        GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Items.Add(new ListItem("Select Value",""))
        GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Items(0).Selected = True
        item.s_STAFF_IDItems.SetSelection(item.s_STAFF_ID.GetFormattedValue())
        If Not item.s_STAFF_IDItems.GetSelectedItem() Is Nothing Then
            GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.SelectedIndex = -1
        End If
        item.s_STAFF_IDItems.CopyTo(GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Items)
        GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        item.s_SUBSCHOOLItems.SetSelection(item.s_SUBSCHOOL.GetFormattedValue())
        GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.SelectedIndex = -1
        item.s_SUBSCHOOLItems.CopyTo(GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.Items)
'End Record Form GREEN_AMBER_RED_LETTERS_v BeforeShow tail

'Record Form GREEN_AMBER_RED_LETTERS_v Show method tail @53-8AE125ED
        If GREEN_AMBER_RED_LETTERS_vErrors.Count > 0 Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v Show method tail

'Record Form GREEN_AMBER_RED_LETTERS_v LoadItemFromRequest method @53-C5CE2A75

    Protected Sub GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item As GREEN_AMBER_RED_LETTERS_vItem, ByVal EnableValidation As Boolean)
        item.s_STAFF_ID.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.UniqueID))
        item.s_STAFF_ID.SetValue(GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Value)
        item.s_STAFF_IDItems.CopyFrom(GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Items)
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID.UniqueID))
        If ControlCustomValues("GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            GREEN_AMBER_RED_LETTERS_vErrors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.s_SUBSCHOOL.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.UniqueID))
        If Not IsNothing(GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.SelectedItem) Then
            item.s_SUBSCHOOL.SetValue(GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.SelectedItem.Value)
        Else
            item.s_SUBSCHOOL.Value = Nothing
        End If
        item.s_SUBSCHOOLItems.CopyFrom(GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.Items)
        If EnableValidation Then
            item.Validate(GREEN_AMBER_RED_LETTERS_vData)
        End If
        GREEN_AMBER_RED_LETTERS_vErrors.Add(item.errors)
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v LoadItemFromRequest method

'Record Form GREEN_AMBER_RED_LETTERS_v GetRedirectUrl method @53-F2565FAA

    Protected Function GetGREEN_AMBER_RED_LETTERS_vRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_GreenLetters_maint.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form GREEN_AMBER_RED_LETTERS_v GetRedirectUrl method

'Record Form GREEN_AMBER_RED_LETTERS_v ShowErrors method @53-DDC9E940

    Protected Sub GREEN_AMBER_RED_LETTERS_vShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To GREEN_AMBER_RED_LETTERS_vErrors.Count - 1
        Select Case GREEN_AMBER_RED_LETTERS_vErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & GREEN_AMBER_RED_LETTERS_vErrors(i)
        End Select
        Next i
        GREEN_AMBER_RED_LETTERS_vError.Visible = True
        GREEN_AMBER_RED_LETTERS_vErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v ShowErrors method

'Record Form GREEN_AMBER_RED_LETTERS_v Insert Operation @53-7918BEB6

    Protected Sub GREEN_AMBER_RED_LETTERS_v_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        GREEN_AMBER_RED_LETTERS_vIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GREEN_AMBER_RED_LETTERS_v Insert Operation

'Record Form GREEN_AMBER_RED_LETTERS_v BeforeInsert tail @53-77199731
    GREEN_AMBER_RED_LETTERS_vParameters()
    GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item, EnableValidation)
'End Record Form GREEN_AMBER_RED_LETTERS_v BeforeInsert tail

'Record Form GREEN_AMBER_RED_LETTERS_v AfterInsert tail  @53-6CEA0696
        ErrorFlag=(GREEN_AMBER_RED_LETTERS_vErrors.Count > 0)
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v AfterInsert tail 

'Record Form GREEN_AMBER_RED_LETTERS_v Update Operation @53-693D0373

    Protected Sub GREEN_AMBER_RED_LETTERS_v_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        GREEN_AMBER_RED_LETTERS_vIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GREEN_AMBER_RED_LETTERS_v Update Operation

'Record Form GREEN_AMBER_RED_LETTERS_v Before Update tail @53-77199731
        GREEN_AMBER_RED_LETTERS_vParameters()
        GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item, EnableValidation)
'End Record Form GREEN_AMBER_RED_LETTERS_v Before Update tail

'Record Form GREEN_AMBER_RED_LETTERS_v Update Operation tail @53-6CEA0696
        ErrorFlag=(GREEN_AMBER_RED_LETTERS_vErrors.Count > 0)
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v Update Operation tail

'Record Form GREEN_AMBER_RED_LETTERS_v Delete Operation @53-33170390
    Protected Sub GREEN_AMBER_RED_LETTERS_v_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        GREEN_AMBER_RED_LETTERS_vIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form GREEN_AMBER_RED_LETTERS_v Delete Operation

'Record Form BeforeDelete tail @53-77199731
        GREEN_AMBER_RED_LETTERS_vParameters()
        GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @53-238F8B2B
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form GREEN_AMBER_RED_LETTERS_v Cancel Operation @53-347F8F3D

    Protected Sub GREEN_AMBER_RED_LETTERS_v_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        GREEN_AMBER_RED_LETTERS_vIsSubmitted = True
        Dim RedirectUrl As String = ""
        GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item, True)
'End Record Form GREEN_AMBER_RED_LETTERS_v Cancel Operation

'Record Form GREEN_AMBER_RED_LETTERS_v Cancel Operation tail @53-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS_v Cancel Operation tail

'Record Form GREEN_AMBER_RED_LETTERS_v Search Operation @53-08C5EAD6
    Protected Sub GREEN_AMBER_RED_LETTERS_v_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        GREEN_AMBER_RED_LETTERS_vIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As GREEN_AMBER_RED_LETTERS_vItem = New GREEN_AMBER_RED_LETTERS_vItem()
        GREEN_AMBER_RED_LETTERS_vLoadItemFromRequest(item, EnableValidation)
'End Record Form GREEN_AMBER_RED_LETTERS_v Search Operation

'Button Button_DoSearch OnClick. @54-3BF8028E
        If CType(sender,Control).ID = "GREEN_AMBER_RED_LETTERS_vButton_DoSearch" Then
            RedirectUrl = GetGREEN_AMBER_RED_LETTERS_vRedirectUrl("", "s_STAFF_ID;s_STUDENT_ID;s_SUBSCHOOL")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @54-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form GREEN_AMBER_RED_LETTERS_v Search Operation tail @53-AC87C82C
        ErrorFlag = GREEN_AMBER_RED_LETTERS_vErrors.Count > 0
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERS_vShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In GREEN_AMBER_RED_LETTERS_vs_STAFF_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_STAFF_ID=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            Params = Params & IIf(GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(GREEN_AMBER_RED_LETTERS_vs_STUDENT_ID.Text) & "&"), "")
            For Each li In GREEN_AMBER_RED_LETTERS_vs_SUBSCHOOL.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SUBSCHOOL=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form GREEN_AMBER_RED_LETTERS_v Search Operation tail

'Record Form GREEN_AMBER_RED_LETTERS Parameters @177-4EB608FA

    Protected Sub GREEN_AMBER_RED_LETTERSParameters()
        Dim item As new GREEN_AMBER_RED_LETTERSItem
        Try
            GREEN_AMBER_RED_LETTERSData.UrlID = IntegerParameter.GetParam("ID", ParameterSourceType.URL, "", Nothing, false)
            GREEN_AMBER_RED_LETTERSData.CtrlSTUDENT_ID = TextParameter.GetParam(item.STUDENT_ID.Value, ParameterSourceType.Control, "", "", false)
            GREEN_AMBER_RED_LETTERSData.CtrlGREEN_LETTER_SENT_FLAG = TextParameter.GetParam(item.GREEN_LETTER_SENT_FLAG.Value, ParameterSourceType.Control, "", "", false)
            GREEN_AMBER_RED_LETTERSData.CtrlGREEN_LETTER_SENT_DATE = DateParameter.GetParam(item.GREEN_LETTER_SENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Today(), false)
            GREEN_AMBER_RED_LETTERSData.CtrlLAST_ALTERED_BY = TextParameter.GetParam(item.LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", "", false)
        Catch e As Exception
            GREEN_AMBER_RED_LETTERSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS Parameters

'Record Form GREEN_AMBER_RED_LETTERS Show method @177-73BF6B8A
    Protected Sub GREEN_AMBER_RED_LETTERSShow()
        If GREEN_AMBER_RED_LETTERSOperations.None Then
            GREEN_AMBER_RED_LETTERSHolder.Visible = False
            Return
        End If
        Dim item As GREEN_AMBER_RED_LETTERSItem = GREEN_AMBER_RED_LETTERSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not GREEN_AMBER_RED_LETTERSOperations.AllowRead
        GREEN_AMBER_RED_LETTERSErrors.Add(item.errors)
        If GREEN_AMBER_RED_LETTERSErrors.Count > 0 Then
            GREEN_AMBER_RED_LETTERSShowErrors()
            Return
        End If
'End Record Form GREEN_AMBER_RED_LETTERS Show method

'Record Form GREEN_AMBER_RED_LETTERS BeforeShow tail @177-34A1A9A9
        GREEN_AMBER_RED_LETTERSParameters()
        GREEN_AMBER_RED_LETTERSData.FillItem(item, IsInsertMode)
        GREEN_AMBER_RED_LETTERSHolder.DataBind()
        GREEN_AMBER_RED_LETTERSButton_Insert.Visible=IsInsertMode AndAlso GREEN_AMBER_RED_LETTERSOperations.AllowInsert
        GREEN_AMBER_RED_LETTERSSTUDENT_ID.Text=item.STUDENT_ID.GetFormattedValue()
        item.GREEN_LETTER_SENT_FLAGItems.SetSelection(item.GREEN_LETTER_SENT_FLAG.GetFormattedValue())
        GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.SelectedIndex = -1
        item.GREEN_LETTER_SENT_FLAGItems.CopyTo(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.Items)
        GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE.Text=item.GREEN_LETTER_SENT_DATE.GetFormattedValue()
        GREEN_AMBER_RED_LETTERSLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1Name = "GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1"
        GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1DateControl = GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE.ClientID
        GREEN_AMBER_RED_LETTERSDatePicker_GREEN_LETTER_SENT_DATE1.DataBind()
'End Record Form GREEN_AMBER_RED_LETTERS BeforeShow tail

'Record Form GREEN_AMBER_RED_LETTERS Show method tail @177-1E1A4EBB
        If GREEN_AMBER_RED_LETTERSErrors.Count > 0 Then
            GREEN_AMBER_RED_LETTERSShowErrors()
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS Show method tail

'Record Form GREEN_AMBER_RED_LETTERS LoadItemFromRequest method @177-035127B1

    Protected Sub GREEN_AMBER_RED_LETTERSLoadItemFromRequest(item As GREEN_AMBER_RED_LETTERSItem, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERSSTUDENT_ID.UniqueID))
        If ControlCustomValues("GREEN_AMBER_RED_LETTERSSTUDENT_ID") Is Nothing Then
            item.STUDENT_ID.SetValue(GREEN_AMBER_RED_LETTERSSTUDENT_ID.Text)
        Else
            item.STUDENT_ID.SetValue(ControlCustomValues("GREEN_AMBER_RED_LETTERSSTUDENT_ID"))
        End If
        Catch ae As ArgumentException
            GREEN_AMBER_RED_LETTERSErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.GREEN_LETTER_SENT_FLAG.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.UniqueID))
        If Not IsNothing(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.SelectedItem) Then
            item.GREEN_LETTER_SENT_FLAG.SetValue(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.SelectedItem.Value)
        Else
            item.GREEN_LETTER_SENT_FLAG.Value = Nothing
        End If
        item.GREEN_LETTER_SENT_FLAGItems.CopyFrom(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_FLAG.Items)
        Try
        item.GREEN_LETTER_SENT_DATE.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE.UniqueID))
        If ControlCustomValues("GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE") Is Nothing Then
            item.GREEN_LETTER_SENT_DATE.SetValue(GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE.Text)
        Else
            item.GREEN_LETTER_SENT_DATE.SetValue(ControlCustomValues("GREEN_AMBER_RED_LETTERSGREEN_LETTER_SENT_DATE"))
        End If
        Catch ae As ArgumentException
            GREEN_AMBER_RED_LETTERSErrors.Add("GREEN_LETTER_SENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"GREEN LETTER SENT DATE","dd/mm/yyyy"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(GREEN_AMBER_RED_LETTERSLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(GREEN_AMBER_RED_LETTERSLAST_ALTERED_BY.Value)
        If EnableValidation Then
            item.Validate(GREEN_AMBER_RED_LETTERSData)
        End If
        GREEN_AMBER_RED_LETTERSErrors.Add(item.errors)
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS LoadItemFromRequest method

'Record Form GREEN_AMBER_RED_LETTERS GetRedirectUrl method @177-002C20CF

    Protected Function GetGREEN_AMBER_RED_LETTERSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form GREEN_AMBER_RED_LETTERS GetRedirectUrl method

'Record Form GREEN_AMBER_RED_LETTERS ShowErrors method @177-209612E8

    Protected Sub GREEN_AMBER_RED_LETTERSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To GREEN_AMBER_RED_LETTERSErrors.Count - 1
        Select Case GREEN_AMBER_RED_LETTERSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & GREEN_AMBER_RED_LETTERSErrors(i)
        End Select
        Next i
        GREEN_AMBER_RED_LETTERSError.Visible = True
        GREEN_AMBER_RED_LETTERSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS ShowErrors method

'Record Form GREEN_AMBER_RED_LETTERS Insert Operation @177-3A1263FC

    Protected Sub GREEN_AMBER_RED_LETTERS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERSItem = New GREEN_AMBER_RED_LETTERSItem()
        Dim ExecuteFlag As Boolean = True
        GREEN_AMBER_RED_LETTERSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GREEN_AMBER_RED_LETTERS Insert Operation

'Button Button_Insert OnClick. @179-874B6EBB
        If CType(sender,Control).ID = "GREEN_AMBER_RED_LETTERSButton_Insert" Then
            RedirectUrl = GetGREEN_AMBER_RED_LETTERSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @179-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form GREEN_AMBER_RED_LETTERS BeforeInsert tail @177-014DF617
    GREEN_AMBER_RED_LETTERSParameters()
    GREEN_AMBER_RED_LETTERSLoadItemFromRequest(item, EnableValidation)
    If GREEN_AMBER_RED_LETTERSOperations.AllowInsert Then
        ErrorFlag=(GREEN_AMBER_RED_LETTERSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                GREEN_AMBER_RED_LETTERSData.InsertItem(item)
            Catch ex As Exception
                GREEN_AMBER_RED_LETTERSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form GREEN_AMBER_RED_LETTERS BeforeInsert tail

'Record GREEN_AMBER_RED_LETTERS Event AfterInsert. Action Custom Code @206-73254650
    ' -------------------------
    '21-May-2015|EA| try notification
    'if (Not ErrorFlag) then
    Page.ClientScript.RegisterStartupScript(GetType(Page), "notificationScript", (Convert.ToString("<script>$(function () {$.notifyBar({html: 'Student Added!',delay: 2000,animationSpeed: 'normal'});});</script>")))
    'modERAGlobals.ShowNotification(Page, "Student Added")
    'modERAGlobals.ShowNotificationWithClass(Page, "Student Added","success")
    'end if
    ' -------------------------
'End Record GREEN_AMBER_RED_LETTERS Event AfterInsert. Action Custom Code

'Record GREEN_AMBER_RED_LETTERS Event AfterInsert. Action Custom Code @208-73254650
    ' -------------------------
     '12-Nov-2015|EA|When adding student and Green Letter is sent, then add the comment. (similar code to After Edittable Grid Submit)
     Dim AddComments as SpCommand
			AddComments=new SpCommand("spi_GreenLetter_AddComments;1",Settings.connDECVPRODSQL2005DataAccessObject)
			CType(AddComments,SpCommand).AddParameter("@RETURN_VALUE",0,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
			CType(AddComments,SpCommand).AddParameter("@UpdateFlag",1,ParameterType._Int,ParameterDirection.Input,0,0,10)
			Dim result As Object = Nothing
			
			Try
				result = AddComments.ExecuteNonQuery()
				' return_value = IntegerParameter.GetParam(CType(ExtraInsert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
			Catch ee As Exception
				If Not IsNothing(ee) Then GREEN_AMBER_RED_LETTERSErrors.Add("Parameters",ee.Message)
			End Try
    ' -------------------------
'End Record GREEN_AMBER_RED_LETTERS Event AfterInsert. Action Custom Code

'Record Form GREEN_AMBER_RED_LETTERS AfterInsert tail  @177-E844966C
        End If
        ErrorFlag=(GREEN_AMBER_RED_LETTERSErrors.Count > 0)
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS AfterInsert tail 

'Record Form GREEN_AMBER_RED_LETTERS Update Operation @177-8A27434A

    Protected Sub GREEN_AMBER_RED_LETTERS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERSItem = New GREEN_AMBER_RED_LETTERSItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        GREEN_AMBER_RED_LETTERSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GREEN_AMBER_RED_LETTERS Update Operation

'Record Form GREEN_AMBER_RED_LETTERS Before Update tail @177-91CEB9DB
        GREEN_AMBER_RED_LETTERSParameters()
        GREEN_AMBER_RED_LETTERSLoadItemFromRequest(item, EnableValidation)
'End Record Form GREEN_AMBER_RED_LETTERS Before Update tail

'Record Form GREEN_AMBER_RED_LETTERS Update Operation tail @177-1529C106
        ErrorFlag=(GREEN_AMBER_RED_LETTERSErrors.Count > 0)
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS Update Operation tail

'Record Form GREEN_AMBER_RED_LETTERS Delete Operation @177-59BCA9E3
    Protected Sub GREEN_AMBER_RED_LETTERS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        GREEN_AMBER_RED_LETTERSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As GREEN_AMBER_RED_LETTERSItem = New GREEN_AMBER_RED_LETTERSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form GREEN_AMBER_RED_LETTERS Delete Operation

'Record Form BeforeDelete tail @177-91CEB9DB
        GREEN_AMBER_RED_LETTERSParameters()
        GREEN_AMBER_RED_LETTERSLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @177-6D49364E
        If ErrorFlag Then
            GREEN_AMBER_RED_LETTERSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form GREEN_AMBER_RED_LETTERS Cancel Operation @177-4F6C5A91

    Protected Sub GREEN_AMBER_RED_LETTERS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GREEN_AMBER_RED_LETTERSItem = New GREEN_AMBER_RED_LETTERSItem()
        GREEN_AMBER_RED_LETTERSIsSubmitted = True
        Dim RedirectUrl As String = ""
        GREEN_AMBER_RED_LETTERSLoadItemFromRequest(item, False)
'End Record Form GREEN_AMBER_RED_LETTERS Cancel Operation

'Button Button_Cancel OnClick. @180-AE8BD9DE
    If CType(sender,Control).ID = "GREEN_AMBER_RED_LETTERSButton_Cancel" Then
        RedirectUrl = GetGREEN_AMBER_RED_LETTERSRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @180-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form GREEN_AMBER_RED_LETTERS Cancel Operation tail @177-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form GREEN_AMBER_RED_LETTERS Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-73A8B4DE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_GreenLetters_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, False, True, False)
        GREEN_AMBER_RED_LETTERS_vData = New GREEN_AMBER_RED_LETTERS_vDataProvider()
        GREEN_AMBER_RED_LETTERS_vOperations = New FormSupportedOperations(False, True, True, True, True)
        GREEN_AMBER_RED_LETTERSData = New GREEN_AMBER_RED_LETTERSDataProvider()
        GREEN_AMBER_RED_LETTERSOperations = New FormSupportedOperations(False, False, True, False, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","8","9","11"})) Then
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


