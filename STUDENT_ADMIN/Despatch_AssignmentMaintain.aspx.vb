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

Namespace DECV_PROD2007.Despatch_AssignmentMaintain 'Namespace @1-E954D949

'Forms Definition @1-71FA79D5
Public Class [Despatch_AssignmentMaintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F3953698
    Protected ASSIGNMENT_SUBMISSION_STU1Data As ASSIGNMENT_SUBMISSION_STU1DataProvider
    Protected ASSIGNMENT_SUBMISSION_STU1CurrentRowNumber As Integer
    Protected ASSIGNMENT_SUBMISSION_STU1IsSubmitted As Boolean = False
    Protected ASSIGNMENT_SUBMISSION_STU1Errors As New NameValueCollection()
    Protected ASSIGNMENT_SUBMISSION_STU1Operations As FormSupportedOperations
    Protected ASSIGNMENT_SUBMISSION_STU1DataItem As ASSIGNMENT_SUBMISSION_STU1Item
    Protected ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEName As String
    Protected ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEDateControl As String
    Protected ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEName As String
    Protected ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEDateControl As String
    Protected ASSIGNMENT_SUBMISSION_STUData As ASSIGNMENT_SUBMISSION_STUDataProvider
    Protected ASSIGNMENT_SUBMISSION_STUErrors As NameValueCollection = New NameValueCollection()
    Protected ASSIGNMENT_SUBMISSION_STUOperations As FormSupportedOperations
    Protected ASSIGNMENT_SUBMISSION_STUIsSubmitted As Boolean = False
    Protected Despatch_AssignmentMaintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-613E1244
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ASSIGNMENT_SUBMISSION_STU1Bind()
            ASSIGNMENT_SUBMISSION_STUShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Bind @3-F5D0A2CD
    Protected Sub ASSIGNMENT_SUBMISSION_STU1Bind()
        If ASSIGNMENT_SUBMISSION_STU1Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ASSIGNMENT_SUBMISSION_STU1",GetType(ASSIGNMENT_SUBMISSION_STU1DataProvider.SortFields), 50, 100)
        End If
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Bind

'EditableGrid Form ASSIGNMENT_SUBMISSION_STU1 BeforeShow tail @3-3AD6AEB5
        ASSIGNMENT_SUBMISSION_STU1Parameters()
        ASSIGNMENT_SUBMISSION_STU1Data.SortField = CType(ViewState("ASSIGNMENT_SUBMISSION_STU1SortField"), ASSIGNMENT_SUBMISSION_STU1DataProvider.SortFields)
        ASSIGNMENT_SUBMISSION_STU1Data.SortDir = CType(ViewState("ASSIGNMENT_SUBMISSION_STU1SortDir"), SortDirections)
        ASSIGNMENT_SUBMISSION_STU1Data.PageNumber = CType(ViewState("ASSIGNMENT_SUBMISSION_STU1PageNumber"), Integer)
        ASSIGNMENT_SUBMISSION_STU1Data.RecordsPerPage = CType(ViewState("ASSIGNMENT_SUBMISSION_STU1PageSize"), Integer)
        ASSIGNMENT_SUBMISSION_STU1Repeater.DataSource = ASSIGNMENT_SUBMISSION_STU1Data.GetResultSet(PagesCount, ASSIGNMENT_SUBMISSION_STU1Operations)
        ViewState("ASSIGNMENT_SUBMISSION_STU1PagesCount") = PagesCount
        ViewState("ASSIGNMENT_SUBMISSION_STU1FormState") = New Hashtable()
        ViewState("ASSIGNMENT_SUBMISSION_STU1RowState") = New Hashtable()
        ASSIGNMENT_SUBMISSION_STU1Repeater.DataBind()
        Dim item As ASSIGNMENT_SUBMISSION_STU1Item = ASSIGNMENT_SUBMISSION_STU1DataItem
        If IsNothing(item) Then item = New ASSIGNMENT_SUBMISSION_STU1Item()
        FooterIndex = ASSIGNMENT_SUBMISSION_STU1Repeater.Controls.Count - 1
        Dim Script As Literal = CType(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var ASSIGNMENT_SUBMISSION_STU1StaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "ASSIGNMENT_SUBMISSION_STU1StaticElementsID = new Array ("
        Elements.Text += "var ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecordsID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords").ClientID + """),"
        Elements.Text += "var ASSIGNMENT_SUBMISSION_STU1Button_SubmitID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("ASSIGNMENT_SUBMISSION_STU1Button_Submit").ClientID + """),"
        Elements.Text += "var ASSIGNMENT_SUBMISSION_STU1CancelID=2;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("ASSIGNMENT_SUBMISSION_STU1Cancel").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1EmptyRows = 0;" + vbCrLf
        Script.Text &= "ASSIGNMENT_SUBMISSION_STU1Elements = new Array ("
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATEID=0;" + vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1RETURNED_DATEID=1;" + vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_IDID=2;" + vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1COMMENTSID=3;" + vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1checkboxDeleteID=4;" + vbCrLf
        Elements.Text &= "var ASSIGNMENT_SUBMISSION_STU1DeleteControl = 4;" + vbCrLf
        Dim col As Control
        For Each col In ASSIGNMENT_SUBMISSION_STU1Repeater.Controls
            If CType(col, RepeaterItem).ItemType = ListItemType.Item Or CType(col, RepeaterItem).ItemType = ListItemType.AlternatingItem Then
                Dim arr as String = ""
                arr += "document.getElementById(""" & col.FindControl("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("ASSIGNMENT_SUBMISSION_STU1COMMENTS").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("ASSIGNMENT_SUBMISSION_STU1checkboxDelete").ClientID & """),"
                Script.Text += vbCrLf + "new Array(" + arr.TrimEnd(New Char() {","}) + "),"
            End If
        Next col
        Script.Text = Script.Text.TrimEnd(New Char() {","}) + ");"
        Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_ASSIGNMENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBMISSION_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_SUBMISSION_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RECEIVED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_RECEIVED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RETURNED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_RETURNED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_SUBMISSION_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENTSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("Sorter_COMMENTSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim ASSIGNMENT_SUBMISSION_STU1Button_Submit As System.Web.UI.WebControls.Button = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("ASSIGNMENT_SUBMISSION_STU1Button_Submit"),System.Web.UI.WebControls.Button)
        Dim ASSIGNMENT_SUBMISSION_STU1Cancel As System.Web.UI.WebControls.Button = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("ASSIGNMENT_SUBMISSION_STU1Cancel"),System.Web.UI.WebControls.Button)


        ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords.Text = Server.HtmlEncode(item.ASSIGNMENT_SUBMISSION_STU1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSION_STU1Button_Submit.Visible = ASSIGNMENT_SUBMISSION_STU1Operations.Editable
        If Not CType(ASSIGNMENT_SUBMISSION_STU1Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If ASSIGNMENT_SUBMISSION_STU1Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_STU1Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In ASSIGNMENT_SUBMISSION_STU1Errors
                ErrorLabel.Text += ASSIGNMENT_SUBMISSION_STU1Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form ASSIGNMENT_SUBMISSION_STU1 BeforeShow tail

'Label ASSIGNMENT_SUBMISSION_STU1_TotalRecords Event BeforeShow. Action Retrieve number of records @48-50A8FA6C
            ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STU1_TotalRecords.Text = ASSIGNMENT_SUBMISSION_STU1Data.RecordCount.ToString()
'End Label ASSIGNMENT_SUBMISSION_STU1_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Event BeforeShow. Action Custom Code @91-73254650
    ' -------------------------
     ' ERA: only display if something to display, and not if initial open
	if (isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STUDENT_ID) and isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_SUBJECT_ID) and isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STAFF_ID)) then
		ASSIGNMENT_SUBMISSION_STU1Repeater.visible=false
    end if
    ' -------------------------
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Event BeforeShow. Action Custom Code

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Bind tail @3-BD4CBCFF
        ASSIGNMENT_SUBMISSION_STU1ShowErrors(New ArrayList(CType(ASSIGNMENT_SUBMISSION_STU1Repeater.DataSource, ICollection)), ASSIGNMENT_SUBMISSION_STU1Repeater.Items)
    End Sub
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Bind tail

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Table Parameters @3-F6D4C940
    Protected Sub ASSIGNMENT_SUBMISSION_STU1Parameters()
        Try
        Dim item As new ASSIGNMENT_SUBMISSION_STU1Item
            ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_SUBJECT_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_SUBJECT_ID = IntegerParameter.GetParam("s_STUDENT_SUBJECT_SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STAFF_ID = TextParameter.GetParam("s_STUDENT_SUBJECT_STAFF_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSION_STU1Data.CtrlRECEIVED_DATE = DateParameter.GetParam(item.RECEIVED_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            ASSIGNMENT_SUBMISSION_STU1Data.CtrlRETURNED_DATE = DateParameter.GetParam(item.RETURNED_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            ASSIGNMENT_SUBMISSION_STU1Data.CtrlASSIGNMENT_SUBMISSION_STAFF_ID = TextParameter.GetParam(item.ASSIGNMENT_SUBMISSION_STAFF_ID.Value, ParameterSourceType.Control, "", "        ", false)
            ASSIGNMENT_SUBMISSION_STU1Data.CtrlCOMMENTS = TextParameter.GetParam(item.COMMENTS.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = ASSIGNMENT_SUBMISSION_STU1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(ASSIGNMENT_SUBMISSION_STU1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid ASSIGNMENT_SUBMISSION_STU1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Table Parameters

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemDataBound event @3-D40BA615
    Protected Sub ASSIGNMENT_SUBMISSION_STU1ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As ASSIGNMENT_SUBMISSION_STU1Item = DirectCast(e.Item.DataItem, ASSIGNMENT_SUBMISSION_STU1Item)
        Dim Item as ASSIGNMENT_SUBMISSION_STU1Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ASSIGNMENT_SUBMISSION_STU1CurrentRowNumber = ASSIGNMENT_SUBMISSION_STU1CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("ASSIGNMENT_SUBMISSION_STU1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ASSIGNMENT_SUBMISSION_STU1RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            formState.Add("ASSIGNMENT_IDField:" & e.Item.ItemIndex, DataItem.ASSIGNMENT_IDField.Value)
            formState.Add("SUBMISSION_IDField:" & e.Item.ItemIndex, DataItem.SUBMISSION_IDField.Value)
            formState.Add("ASSIGNMENT_SUBMISSION_STUDENT_IDField:" & e.Item.ItemIndex, DataItem.ASSIGNMENT_SUBMISSION_STUDENT_IDField.Value)
            formState.Add("ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField.Value)
            formState.Add("ASSIGNMENT_SUBMISSION_SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.ASSIGNMENT_SUBMISSION_SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID").UniqueID) = DataItem.ASSIGNMENT_SUBMISSION_SUBJECT_ID.Value
            ViewState(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID").UniqueID) = DataItem.ASSIGNMENT_SUBMISSION_STUDENT_ID.Value
            ViewState(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID").UniqueID) = DataItem.ASSIGNMENT_ID.Value
            ViewState(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID").UniqueID) = DataItem.SUBMISSION_ID.Value
            Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE"),System.Web.UI.WebControls.TextBox)
            Dim ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE"),System.Web.UI.WebControls.PlaceHolder)
            Dim ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE"),System.Web.UI.WebControls.TextBox)
            Dim ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE"),System.Web.UI.WebControls.PlaceHolder)
            Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim ASSIGNMENT_SUBMISSION_STU1COMMENTS As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1COMMENTS"),System.Web.UI.WebControls.TextBox)
            Dim ASSIGNMENT_SUBMISSION_STU1checkboxDelete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1checkboxDelete"),System.Web.UI.WebControls.CheckBox)
            CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENT_SUBMISSION_STU1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ASSIGNMENT_SUBMISSION_STU1CurrentRowNumber), AttributeOption.Multiple)
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEName = "ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE"
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATEDateControl = e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE").ClientID
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE.DataBind()
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEName = "ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE"
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATEDateControl = e.Item.FindControl("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE").ClientID
            ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE.DataBind()
            ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.Items.Add(new ListItem("Select Value",""))
            ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.Items(0).Selected = True
            DataItem.ASSIGNMENT_SUBMISSION_STAFF_IDItems.SetSelection(DataItem.ASSIGNMENT_SUBMISSION_STAFF_ID.GetFormattedValue())
            If Not DataItem.ASSIGNMENT_SUBMISSION_STAFF_IDItems.GetSelectedItem() Is Nothing Then
                ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.SelectedIndex = -1
            End If
            DataItem.ASSIGNMENT_SUBMISSION_STAFF_IDItems.CopyTo(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.Items)
            If DataItem.checkboxDeleteCheckedValue.Value.Equals(DataItem.checkboxDelete.Value) Then
                ASSIGNMENT_SUBMISSION_STU1checkboxDelete.Checked = True
            End If
        End If
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemDataBound event

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeShowRow event @3-45FA994D
        If Not IsNothing(Item) Then ASSIGNMENT_SUBMISSION_STU1DataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeShowRow event

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeShowRow event tail

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemDataBound event tail

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 GetRedirectUrl method @3-CCFC11D9
    Protected Function GetASSIGNMENT_SUBMISSION_STU1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetASSIGNMENT_SUBMISSION_STU1RedirectUrl(ByVal redirectString As String) As String
        Return GetASSIGNMENT_SUBMISSION_STU1RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 GetRedirectUrl method

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 ShowErrors method @3-1E4AA41F
    Protected Function ASSIGNMENT_SUBMISSION_STU1ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).IsUpdated Then col(CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).RowId).Visible = False
            If (CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).errors.Count - 1
                Select CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), ASSIGNMENT_SUBMISSION_STU1Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 ShowErrors method

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemCommand event @3-5B6A13AC
    Protected Sub ASSIGNMENT_SUBMISSION_STU1ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = ASSIGNMENT_SUBMISSION_STU1Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 ItemCommand event

'Button Button_Submit OnClick. @73-8DE3FB6C
        If Ctype(e.CommandSource,Control).ID = "ASSIGNMENT_SUBMISSION_STU1Button_Submit" Then
            RedirectUrl  = GetASSIGNMENT_SUBMISSION_STU1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @73-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @75-9C26E2C0
        If Ctype(e.CommandSource,Control).ID = "ASSIGNMENT_SUBMISSION_STU1Cancel" Then
            RedirectUrl  = GetASSIGNMENT_SUBMISSION_STU1RedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @75-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form ASSIGNMENT_SUBMISSION_STU1 ItemCommand event tail @3-11201C9A
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("ASSIGNMENT_SUBMISSION_STU1SortDir"), SortDirections) = SortDirections._Asc And ViewState("ASSIGNMENT_SUBMISSION_STU1SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("ASSIGNMENT_SUBMISSION_STU1SortDir") = SortDirections._Desc
                Else
                    ViewState("ASSIGNMENT_SUBMISSION_STU1SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("ASSIGNMENT_SUBMISSION_STU1SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As ASSIGNMENT_SUBMISSION_STU1DataProvider.SortFields = 0
            ViewState("ASSIGNMENT_SUBMISSION_STU1SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("ASSIGNMENT_SUBMISSION_STU1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("ASSIGNMENT_SUBMISSION_STU1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("ASSIGNMENT_SUBMISSION_STU1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ASSIGNMENT_SUBMISSION_STU1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            ASSIGNMENT_SUBMISSION_STU1IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = ASSIGNMENT_SUBMISSION_STU1Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("ASSIGNMENT_SUBMISSION_STU1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ASSIGNMENT_SUBMISSION_STU1RowState"), Hashtable)
            ASSIGNMENT_SUBMISSION_STU1Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1DatePicker_RECEIVED_DATE"),System.Web.UI.WebControls.PlaceHolder)
                    Dim ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1DatePicker_RETURNED_DATE"),System.Web.UI.WebControls.PlaceHolder)
                    Dim ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim ASSIGNMENT_SUBMISSION_STU1COMMENTS As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1COMMENTS"),System.Web.UI.WebControls.TextBox)
                    Dim ASSIGNMENT_SUBMISSION_STU1checkboxDelete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1checkboxDelete"),System.Web.UI.WebControls.CheckBox)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As ASSIGNMENT_SUBMISSION_STU1Item = New ASSIGNMENT_SUBMISSION_STU1Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.ASSIGNMENT_IDField.Value = formState("ASSIGNMENT_IDField:" & col(i).ItemIndex)
                    item.SUBMISSION_IDField.Value = formState("SUBMISSION_IDField:" & col(i).ItemIndex)
                    item.ASSIGNMENT_SUBMISSION_STUDENT_IDField.Value = formState("ASSIGNMENT_SUBMISSION_STUDENT_IDField:" & col(i).ItemIndex)
                    item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField.Value = formState("ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField.Value = formState("ASSIGNMENT_SUBMISSION_SUBJECT_IDField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("ASSIGNMENT_SUBMISSION_STU1checkboxDelete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.ASSIGNMENT_SUBMISSION_SUBJECT_ID.Value = ViewState(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_SUBJECT_ID.UniqueID)
                    item.ASSIGNMENT_SUBMISSION_STUDENT_ID.Value = ViewState(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STUDENT_ID.UniqueID)
                    item.ASSIGNMENT_ID.Value = ViewState(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_ID.UniqueID)
                    item.SUBMISSION_ID.Value = ViewState(ASSIGNMENT_SUBMISSION_STU1SUBMISSION_ID.UniqueID)
                    Try
                    item.RECEIVED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE.UniqueID))
                    If ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE") Is Nothing Then
                        item.RECEIVED_DATE.SetValue(ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE.Text)
                    Else
                        item.RECEIVED_DATE.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1RECEIVED_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("RECEIVED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"RECEIVED DATE","dd/mm/yy"))
                    End Try
                    Try
                    item.RETURNED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE.UniqueID))
                    If ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE") Is Nothing Then
                        item.RETURNED_DATE.SetValue(ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE.Text)
                    Else
                        item.RETURNED_DATE.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1RETURNED_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("RETURNED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"RETURNED DATE","dd/mm/yy"))
                    End Try
                    item.ASSIGNMENT_SUBMISSION_STAFF_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.UniqueID))
                    item.ASSIGNMENT_SUBMISSION_STAFF_ID.SetValue(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.Value)
                    item.ASSIGNMENT_SUBMISSION_STAFF_IDItems.CopyFrom(ASSIGNMENT_SUBMISSION_STU1ASSIGNMENT_SUBMISSION_STAFF_ID.Items)
                    item.COMMENTS.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STU1COMMENTS.UniqueID))
                    If ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1COMMENTS") Is Nothing Then
                        item.COMMENTS.SetValue(ASSIGNMENT_SUBMISSION_STU1COMMENTS.Text)
                    Else
                        item.COMMENTS.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSION_STU1COMMENTS"))
                    End If
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(ASSIGNMENT_SUBMISSION_STU1Data) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form ASSIGNMENT_SUBMISSION_STU1 ItemCommand event tail

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Update @3-6D48CC7D
            If BindAllowed Then
                Try
                    ASSIGNMENT_SUBMISSION_STU1Parameters()
                    ASSIGNMENT_SUBMISSION_STU1Data.Update(items, ASSIGNMENT_SUBMISSION_STU1Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(ASSIGNMENT_SUBMISSION_STU1Repeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_STU1Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Update

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 After Update @3-F533C2DB
                End Try
                If ASSIGNMENT_SUBMISSION_STU1ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                ASSIGNMENT_SUBMISSION_STU1ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                ASSIGNMENT_SUBMISSION_STU1Bind()
            End If
        End Sub
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 After Update

'Record Form ASSIGNMENT_SUBMISSION_STU Parameters @33-C4507E63

    Protected Sub ASSIGNMENT_SUBMISSION_STUParameters()
        Dim item As new ASSIGNMENT_SUBMISSION_STUItem
        Try
        Catch e As Exception
            ASSIGNMENT_SUBMISSION_STUErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU Parameters

'Record Form ASSIGNMENT_SUBMISSION_STU Show method @33-553E19BD
    Protected Sub ASSIGNMENT_SUBMISSION_STUShow()
        If ASSIGNMENT_SUBMISSION_STUOperations.None Then
            ASSIGNMENT_SUBMISSION_STUHolder.Visible = False
            Return
        End If
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = ASSIGNMENT_SUBMISSION_STUItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ASSIGNMENT_SUBMISSION_STUOperations.AllowRead
        item.ClearParametersHref = "Despatch_AssignmentMaintain.aspx"
        ASSIGNMENT_SUBMISSION_STUErrors.Add(item.errors)
        If ASSIGNMENT_SUBMISSION_STUErrors.Count > 0 Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
            Return
        End If
'End Record Form ASSIGNMENT_SUBMISSION_STU Show method

'Record Form ASSIGNMENT_SUBMISSION_STU BeforeShow tail @33-466B2733
        ASSIGNMENT_SUBMISSION_STUParameters()
        ASSIGNMENT_SUBMISSION_STUData.FillItem(item, IsInsertMode)
        ASSIGNMENT_SUBMISSION_STUHolder.DataBind()
        ASSIGNMENT_SUBMISSION_STUClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        ASSIGNMENT_SUBMISSION_STUClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_STUDENT_SUBJECT_STUDENT_ID;s_STUDENT_SUBJECT_SUBJECT_ID;s_STUDENT_SUBJECT_STAFF_ID", ViewState)
        ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.Text=item.s_STUDENT_SUBJECT_STUDENT_ID.GetFormattedValue()
        ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID.Text=item.s_STUDENT_SUBJECT_SUBJECT_ID.GetFormattedValue()
        ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Items.Add(new ListItem("Select Value",""))
        ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Items(0).Selected = True
        item.s_STUDENT_SUBJECT_STAFF_IDItems.SetSelection(item.s_STUDENT_SUBJECT_STAFF_ID.GetFormattedValue())
        If Not item.s_STUDENT_SUBJECT_STAFF_IDItems.GetSelectedItem() Is Nothing Then
            ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.SelectedIndex = -1
        End If
        item.s_STUDENT_SUBJECT_STAFF_IDItems.CopyTo(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Items)
'End Record Form ASSIGNMENT_SUBMISSION_STU BeforeShow tail

'Record Form ASSIGNMENT_SUBMISSION_STU Show method tail @33-3AED4B32
        If ASSIGNMENT_SUBMISSION_STUErrors.Count > 0 Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU Show method tail

'Record Form ASSIGNMENT_SUBMISSION_STU LoadItemFromRequest method @33-1690EA7F

    Protected Sub ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item As ASSIGNMENT_SUBMISSION_STUItem, ByVal EnableValidation As Boolean)
        Try
        item.s_STUDENT_SUBJECT_STUDENT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.UniqueID))
        If ControlCustomValues("ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_SUBJECT_STUDENT_ID.SetValue(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.Text)
        Else
            item.s_STUDENT_SUBJECT_STUDENT_ID.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSION_STUErrors.Add("s_STUDENT_SUBJECT_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"s_STUDENT_SUBJECT_STUDENT_ID"))
        End Try
        Try
        item.s_STUDENT_SUBJECT_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID.UniqueID))
        If ControlCustomValues("ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID") Is Nothing Then
            item.s_STUDENT_SUBJECT_SUBJECT_ID.SetValue(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID.Text)
        Else
            item.s_STUDENT_SUBJECT_SUBJECT_ID.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSION_STUErrors.Add("s_STUDENT_SUBJECT_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"s_STUDENT_SUBJECT_SUBJECT_ID"))
        End Try
        item.s_STUDENT_SUBJECT_STAFF_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.UniqueID))
        item.s_STUDENT_SUBJECT_STAFF_ID.SetValue(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Value)
        item.s_STUDENT_SUBJECT_STAFF_IDItems.CopyFrom(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Items)
        If EnableValidation Then
            item.Validate(ASSIGNMENT_SUBMISSION_STUData)
        End If
        ASSIGNMENT_SUBMISSION_STUErrors.Add(item.errors)
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU LoadItemFromRequest method

'Record Form ASSIGNMENT_SUBMISSION_STU GetRedirectUrl method @33-191165AA

    Protected Function GetASSIGNMENT_SUBMISSION_STURedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Despatch_AssignmentMaintain.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ASSIGNMENT_SUBMISSION_STU GetRedirectUrl method

'Record Form ASSIGNMENT_SUBMISSION_STU ShowErrors method @33-F4C66637

    Protected Sub ASSIGNMENT_SUBMISSION_STUShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ASSIGNMENT_SUBMISSION_STUErrors.Count - 1
        Select Case ASSIGNMENT_SUBMISSION_STUErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ASSIGNMENT_SUBMISSION_STUErrors(i)
        End Select
        Next i
        ASSIGNMENT_SUBMISSION_STUError.Visible = True
        ASSIGNMENT_SUBMISSION_STUErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU ShowErrors method

'Record Form ASSIGNMENT_SUBMISSION_STU Insert Operation @33-1B632F4D

    Protected Sub ASSIGNMENT_SUBMISSION_STU_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        ASSIGNMENT_SUBMISSION_STUIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENT_SUBMISSION_STU Insert Operation

'Record Form ASSIGNMENT_SUBMISSION_STU BeforeInsert tail @33-597685A4
    ASSIGNMENT_SUBMISSION_STUParameters()
    ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENT_SUBMISSION_STU BeforeInsert tail

'Record Form ASSIGNMENT_SUBMISSION_STU AfterInsert tail  @33-C6F3B050
        ErrorFlag=(ASSIGNMENT_SUBMISSION_STUErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU AfterInsert tail 

'Record Form ASSIGNMENT_SUBMISSION_STU Update Operation @33-5CC0E7ED

    Protected Sub ASSIGNMENT_SUBMISSION_STU_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ASSIGNMENT_SUBMISSION_STUIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENT_SUBMISSION_STU Update Operation

'Record Form ASSIGNMENT_SUBMISSION_STU Before Update tail @33-597685A4
        ASSIGNMENT_SUBMISSION_STUParameters()
        ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENT_SUBMISSION_STU Before Update tail

'Record Form ASSIGNMENT_SUBMISSION_STU Update Operation tail @33-C6F3B050
        ErrorFlag=(ASSIGNMENT_SUBMISSION_STUErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU Update Operation tail

'Record Form ASSIGNMENT_SUBMISSION_STU Delete Operation @33-F22AF440
    Protected Sub ASSIGNMENT_SUBMISSION_STU_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ASSIGNMENT_SUBMISSION_STUIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ASSIGNMENT_SUBMISSION_STU Delete Operation

'Record Form BeforeDelete tail @33-597685A4
        ASSIGNMENT_SUBMISSION_STUParameters()
        ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @33-4146E092
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ASSIGNMENT_SUBMISSION_STU Cancel Operation @33-D3CDA29B

    Protected Sub ASSIGNMENT_SUBMISSION_STU_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        ASSIGNMENT_SUBMISSION_STUIsSubmitted = True
        Dim RedirectUrl As String = ""
        ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item, True)
'End Record Form ASSIGNMENT_SUBMISSION_STU Cancel Operation

'Record Form ASSIGNMENT_SUBMISSION_STU Cancel Operation tail @33-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION_STU Cancel Operation tail

'Record Form ASSIGNMENT_SUBMISSION_STU Search Operation @33-A8EECC5F
    Protected Sub ASSIGNMENT_SUBMISSION_STU_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        ASSIGNMENT_SUBMISSION_STUIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        ASSIGNMENT_SUBMISSION_STULoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENT_SUBMISSION_STU Search Operation

'Button Button_DoSearch OnClick. @35-7F44F944
        If CType(sender,Control).ID = "ASSIGNMENT_SUBMISSION_STUButton_DoSearch" Then
            RedirectUrl = GetASSIGNMENT_SUBMISSION_STURedirectUrl("", "s_STUDENT_SUBJECT_STUDENT_ID;s_STUDENT_SUBJECT_SUBJECT_ID;s_STUDENT_SUBJECT_STAFF_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @35-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form ASSIGNMENT_SUBMISSION_STU Search Operation tail @33-C39280F3
        ErrorFlag = ASSIGNMENT_SUBMISSION_STUErrors.Count > 0
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSION_STUShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.Text <> "",("s_STUDENT_SUBJECT_STUDENT_ID=" & Server.UrlEncode(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID.Text <> "",("s_STUDENT_SUBJECT_SUBJECT_ID=" & Server.UrlEncode(ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_SUBJECT_ID.Text) & "&"), "")
            For Each li In ASSIGNMENT_SUBMISSION_STUs_STUDENT_SUBJECT_STAFF_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_STUDENT_SUBJECT_STAFF_ID=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form ASSIGNMENT_SUBMISSION_STU Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-18B55F16
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Despatch_AssignmentMaintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ASSIGNMENT_SUBMISSION_STU1Data = New ASSIGNMENT_SUBMISSION_STU1DataProvider()
        ASSIGNMENT_SUBMISSION_STU1Operations = New FormSupportedOperations(False, True, False, True, True)
        ASSIGNMENT_SUBMISSION_STUData = New ASSIGNMENT_SUBMISSION_STUDataProvider()
        ASSIGNMENT_SUBMISSION_STUOperations = New FormSupportedOperations(False, True, True, True, True)
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

