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

Namespace DECV_PROD2007.PastoralTeacher_StudentList 'Namespace @1-43F91F7E

'Forms Definition @1-2D78E341
Public Class [PastoralTeacher_StudentListPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-747C1DCE
    Protected viewMaintainSearchRequest1Data As viewMaintainSearchRequest1DataProvider
    Protected viewMaintainSearchRequest1CurrentRowNumber As Integer
    Protected viewMaintainSearchRequest1IsSubmitted As Boolean = False
    Protected viewMaintainSearchRequest1Errors As New NameValueCollection()
    Protected viewMaintainSearchRequest1Operations As FormSupportedOperations
    Protected viewMaintainSearchRequest1DataItem As viewMaintainSearchRequest1Item
    Protected viewMaintainSearchRequest2Data As viewMaintainSearchRequest2DataProvider
    Protected viewMaintainSearchRequest2CurrentRowNumber As Integer
    Protected viewMaintainSearchRequest2IsSubmitted As Boolean = False
    Protected viewMaintainSearchRequest2Errors As New NameValueCollection()
    Protected viewMaintainSearchRequest2Operations As FormSupportedOperations
    Protected viewMaintainSearchRequest2DataItem As viewMaintainSearchRequest2Item
    Protected PastoralTeacher_StudentListContentMeta As String
'End Forms Objects

'ERA: 21-Mar-2013|EA| additional global variables for tracking if No CLP or Gree Letter buttons need to be shown.
Dim tmpGreenLetterCount as Int64 = 0
Dim tmpNoCLPCount as Int64 = 0
'ERA: end of global variable

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-3B5F1685
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewMaintainSearchRequest1Bind()
            viewMaintainSearchRequest2Bind()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid viewMaintainSearchRequest1 Bind @51-78F0D6A9
    Protected Sub viewMaintainSearchRequest1Bind()
        If viewMaintainSearchRequest1Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest1",GetType(viewMaintainSearchRequest1DataProvider.SortFields), 100, 100)
        End If
'End EditableGrid viewMaintainSearchRequest1 Bind

'EditableGrid Form viewMaintainSearchRequest1 BeforeShow tail @51-3261F8A9
        viewMaintainSearchRequest1Parameters()
        viewMaintainSearchRequest1Data.SortField = CType(ViewState("viewMaintainSearchRequest1SortField"), viewMaintainSearchRequest1DataProvider.SortFields)
        viewMaintainSearchRequest1Data.SortDir = CType(ViewState("viewMaintainSearchRequest1SortDir"), SortDirections)
        viewMaintainSearchRequest1Data.PageNumber = CType(ViewState("viewMaintainSearchRequest1PageNumber"), Integer)
        viewMaintainSearchRequest1Data.RecordsPerPage = CType(ViewState("viewMaintainSearchRequest1PageSize"), Integer)
        viewMaintainSearchRequest1Repeater.DataSource = viewMaintainSearchRequest1Data.GetResultSet(PagesCount, viewMaintainSearchRequest1Operations)
        ViewState("viewMaintainSearchRequest1PagesCount") = PagesCount
        ViewState("viewMaintainSearchRequest1FormState") = New Hashtable()
        ViewState("viewMaintainSearchRequest1RowState") = New Hashtable()
        viewMaintainSearchRequest1Repeater.DataBind()
        Dim item As viewMaintainSearchRequest1Item = viewMaintainSearchRequest1DataItem
        If IsNothing(item) Then item = New viewMaintainSearchRequest1Item()
        FooterIndex = viewMaintainSearchRequest1Repeater.Controls.Count - 1
        Dim Script As Literal = CType(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var viewMaintainSearchRequest1StaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "viewMaintainSearchRequest1StaticElementsID = new Array ("
        Elements.Text += "var viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecordsID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest1Button_SubmitID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest1Button_Submit").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest1lblPastoralIDID=2;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1lblPastoralID").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest1Button_Submit1ID=3;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest1Button_Submit1").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Dim viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim viewMaintainSearchRequest1Button_Submit As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest1Button_Submit"),System.Web.UI.WebControls.Button)
        Dim viewMaintainSearchRequest1lblPastoralID As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1lblPastoralID"),System.Web.UI.WebControls.Literal)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim viewMaintainSearchRequest1Button_Submit1 As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest1Button_Submit1"),System.Web.UI.WebControls.Button)

        item.lblPastoralID.SetValue((session("UserID").toupper))

        viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = Server.HtmlEncode(item.viewMaintainSearchRequest1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewMaintainSearchRequest1lblPastoralID.Text = Server.HtmlEncode(item.lblPastoralID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewMaintainSearchRequest1Button_Submit.Visible = viewMaintainSearchRequest1Operations.Editable
        viewMaintainSearchRequest1Button_Submit1.Visible = viewMaintainSearchRequest1Operations.Editable
        If Not CType(viewMaintainSearchRequest1Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If viewMaintainSearchRequest1Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In viewMaintainSearchRequest1Errors
                ErrorLabel.Text += viewMaintainSearchRequest1Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form viewMaintainSearchRequest1 BeforeShow tail

'Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records @54-822AFFB6
            viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = viewMaintainSearchRequest1Data.RecordCount.ToString()
'End Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Button Button_Submit Event BeforeShow. Action Hide-Show Component @98-A0F60A40
        Dim TotalRecords_98_1 As IntegerField = New IntegerField("",viewMaintainSearchRequest1Data.RecordCount)
        Dim ExprParam2_98_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(TotalRecords_98_1, ExprParam2_98_2) Then
            viewMaintainSearchRequest1Button_Submit.Visible = False
        End If
'End Button Button_Submit Event BeforeShow. Action Hide-Show Component

'Button Button_Submit Event BeforeShow. Action Hide-Show Component @127-6C2DE716
        Dim ExprParam1_127_1 As IntegerField = New IntegerField("", (tmpNoCLPCount))
        Dim ExprParam2_127_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(ExprParam1_127_1, ExprParam2_127_2) Then
            viewMaintainSearchRequest1Button_Submit.Visible = False
        End If
'End Button Button_Submit Event BeforeShow. Action Hide-Show Component

'Button Button_Submit1 Event BeforeShow. Action Hide-Show Component @123-68B873D5
        Dim TotalRecords_123_1 As IntegerField = New IntegerField("",viewMaintainSearchRequest1Data.RecordCount)
        Dim ExprParam2_123_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(TotalRecords_123_1, ExprParam2_123_2) Then
            viewMaintainSearchRequest1Button_Submit1.Visible = False
        End If
'End Button Button_Submit1 Event BeforeShow. Action Hide-Show Component

'Button Button_Submit1 Event BeforeShow. Action Hide-Show Component @126-E6974D45
        Dim ExprParam1_126_1 As IntegerField = New IntegerField("", (tmpGreenLetterCount))
        Dim ExprParam2_126_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(ExprParam1_126_1, ExprParam2_126_2) Then
            viewMaintainSearchRequest1Button_Submit1.Visible = False
        End If
'End Button Button_Submit1 Event BeforeShow. Action Hide-Show Component

'EditableGrid viewMaintainSearchRequest1 Bind tail @51-411441E0
        viewMaintainSearchRequest1ShowErrors(New ArrayList(CType(viewMaintainSearchRequest1Repeater.DataSource, ICollection)), viewMaintainSearchRequest1Repeater.Items)
    End Sub
'End EditableGrid viewMaintainSearchRequest1 Bind tail

'EditableGrid viewMaintainSearchRequest1 Table Parameters @51-2365BC6A
    Protected Sub viewMaintainSearchRequest1Parameters()
        Try
        Dim item As new viewMaintainSearchRequest1Item
            viewMaintainSearchRequest1Data.CtrlrbGreenLetterSend = TextParameter.GetParam(item.rbGreenLetterSend.Value, ParameterSourceType.Control, "", Nothing, false)
            viewMaintainSearchRequest1Data.Expr134 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            viewMaintainSearchRequest1Data.SesUserId = TextParameter.GetParam("UserId", ParameterSourceType.Session, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = viewMaintainSearchRequest1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(viewMaintainSearchRequest1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid viewMaintainSearchRequest1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid viewMaintainSearchRequest1 Table Parameters

'EditableGrid viewMaintainSearchRequest1 ItemDataBound event @51-F767E864
    Protected Sub viewMaintainSearchRequest1ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As viewMaintainSearchRequest1Item = DirectCast(e.Item.DataItem, viewMaintainSearchRequest1Item)
        Dim Item as viewMaintainSearchRequest1Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequest1CurrentRowNumber = viewMaintainSearchRequest1CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest1RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1STUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1SURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1FIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1YEAR_LEVEL").UniqueID) = DataItem.YEAR_LEVEL.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_STATUS").UniqueID) = DataItem.ENROLMENT_STATUS.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1link_IntakeDone").UniqueID) = DataItem.link_IntakeDone.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1link_PathwaysDone").UniqueID) = DataItem.link_PathwaysDone.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_DATE").UniqueID) = DataItem.ENROLMENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1lblNewStudent").UniqueID) = DataItem.lblNewStudent.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1Link1").UniqueID) = DataItem.Link1.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1lblGreenLetter").UniqueID) = DataItem.lblGreenLetter.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG").UniqueID) = DataItem.GREEN_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE").UniqueID) = DataItem.GREEN_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG").UniqueID) = DataItem.AMBER_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE").UniqueID) = DataItem.AMBER_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_FLAG").UniqueID) = DataItem.RED_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_DATE").UniqueID) = DataItem.RED_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1MandatedCohort").UniqueID) = DataItem.MandatedCohort.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest1LearningPlan").UniqueID) = DataItem.LearningPlan.Value
            Dim viewMaintainSearchRequest1STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1link_IntakeDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1link_IntakeDone"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest1link_PathwaysDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1link_PathwaysDone"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest1ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1lblNewStudent"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1hidden_days_since_enrolment As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1hidden_days_since_enrolment"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim viewMaintainSearchRequest1rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
            Dim viewMaintainSearchRequest1Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest1lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1lblGreenLetter"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1RED_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1RED_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1MandatedCohort As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1MandatedCohort"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1LearningPlan As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1LearningPlan"),System.Web.UI.WebControls.Literal)
            CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequest1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequest1CurrentRowNumber), AttributeOption.Multiple)
            DataItem.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            viewMaintainSearchRequest1STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","", ViewState)
            DataItem.link_IntakeDoneHref = "Student_Comments_maintain.aspx"
            DataItem.link_IntakeDoneHrefParameters.Add("showinterviewpanel",System.Web.HttpUtility.UrlEncode((1).ToString()))
            viewMaintainSearchRequest1link_IntakeDone.HRef = DataItem.link_IntakeDoneHref & DataItem.link_IntakeDoneHrefParameters.ToString("GET","", ViewState)
            DataItem.link_PathwaysDoneHref = "Student_Comments_maintain.aspx"
            DataItem.link_PathwaysDoneHrefParameters.Add("showprofilepanel",System.Web.HttpUtility.UrlEncode((1).ToString()))
            viewMaintainSearchRequest1link_PathwaysDone.HRef = DataItem.link_PathwaysDoneHref & DataItem.link_PathwaysDoneHrefParameters.ToString("GET","", ViewState)
            DataItem.lblNewStudent.SetValue("<font color=green>New!</font>")
            viewMaintainSearchRequest1lblNewStudent.Text = DataItem.lblNewStudent.GetFormattedValue()
            DataItem.rbGreenLetterSendItems.SetSelection(DataItem.rbGreenLetterSend.GetFormattedValue())
            viewMaintainSearchRequest1rbGreenLetterSend.SelectedIndex = -1
            DataItem.rbGreenLetterSendItems.CopyTo(viewMaintainSearchRequest1rbGreenLetterSend.Items)
            DataItem.Link1Href = "StudentSummary.aspx"
            viewMaintainSearchRequest1Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
        End If
'End EditableGrid viewMaintainSearchRequest1 ItemDataBound event

'viewMaintainSearchRequest1 control Before Show @51-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End viewMaintainSearchRequest1 control Before Show


'Get Control @109-58357BDE
            Dim viewMaintainSearchRequest1lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1lblNewStudent"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label lblNewStudent Event BeforeShow. Action Custom Code @113-73254650
    ' -------------------------
    'ERA: force the New Label to hide if over 3weeks since enrolment (normal Hide-Show component wasn't working
        if (Item.hidden_days_since_enrolment.Value > 20) then
			viewMaintainSearchRequest1lblNewStudent.Visible = False
        End If

    ' -------------------------
'End Label lblNewStudent Event BeforeShow. Action Custom Code

'Get Control @114-F4E9AFDA
            Dim viewMaintainSearchRequest1rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton rbGreenLetterSend Event BeforeShow. Action Declare Variable @115-DDE1188D
            Dim tmpCountDefaulting As Int64 = 0
'End RadioButton rbGreenLetterSend Event BeforeShow. Action Declare Variable

'DEL              'tmpCountDefaulting = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "[STUDENT_SUBJECT]" & " WHERE " & "SUBJECT_ID not in (921,922,923,924,931,932,933) AND SUBJ_ENROL_STATUS = 'D' AND ENROLMENT_YEAR=YEAR(getdate()) and (defaulting_status_date is null or datediff(day,defaulting_status_date, getdate()) > 140) AND STUDENT_ID =" & DataItem.student_id.GetFormattedValue()))).Value, Int64)


'RadioButton rbGreenLetterSend Event BeforeShow. Action Custom Code @117-73254650
    ' -------------------------
    '28-Feb-2014|EA|move from above, for easier changes - adjust to check for
    'tmpCountDefaulting = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "[STUDENT_SUBJECT]" & " WHERE " & "SUBJECT_ID not in (921,922,923,924,931,932,933) AND SUBJ_ENROL_STATUS = 'D' AND ENROLMENT_YEAR=YEAR(getdate()) and (defaulting_status_date is null or datediff(day,defaulting_status_date, getdate()) > 140) AND STUDENT_ID =" & DataItem.student_id.GetFormattedValue()))).Value, Int64)
    '23/4/2014|LN| 21 days if 'A'('No - Do not Send'). 140 days if 'I'/'Yes - Send Warning'
    'tmpCountDefaulting = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "[STUDENT_SUBJECT]" & " WHERE " & "SUBJECT_ID not in (921,922,923,924,931,932,933) AND SUBJ_ENROL_STATUS = 'D' AND ENROLMENT_YEAR=YEAR(getdate()) and ( (defaulting_status_date is null or (datediff(day,defaulting_status_date, getdate()) > 140) and defaulting_status = 'I' ) or (defaulting_status_date is null or (datediff(day,defaulting_status_date, getdate()) > 21) and defaulting_status = 'A' ) ) AND STUDENT_ID = " & DataItem.student_id.GetFormattedValue()))).Value, Int64)

	'4-Aug-2016|EA| massive re-write of the rules to simplify them per Allira S (unfuddle #762)
	' to include:
	'    - show for F-10 yearlevel, if > 14 days since enrolment, NO check for Defaulting Subjects
	'    - don't show if 11-12, or if already received Green Letter this year, or if YES selected
	'    - if NO selected then don't show for 7 days
	'
	' All previous code not needed has been removed after committing to Repo
    

    '19/2/2015|LN| Instead of changing code every year, just change these common parameters.
    Dim DelayOnSelectionNo As String = "7"      '19/2/2015|LN| 
    
    
    
    ' LN:23/2/2016 Added one year to disable.
    'Dim GreenLetterEndDate As Date = New Date(Now().Year, 11, 7)    '19/2/2015|LN| 
    '15/7/2015|LN|  1/3/2016|LN  26-Feb-2018|EA| adjust to 5 March and also line 1040ish; 
    '20-Feb-2020|EA| adjust to 20 Feb per John Vit and also line 1040ish; 
    Dim Sem1GreenLetterStartDate As Date = New Date(Now().Year, 2, 19)   
    Dim Sem2GreenLetterEndDate As Date = New Date(Now().Year, 11, 25)     '15/7/2015|LN| 

 	Dim viewMaintainSearchRequest1lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1lblGreenLetter"),System.Web.UI.WebControls.Literal)
 	viewMaintainSearchRequest1lblGreenLetter.Visible = True
	Dim tmpGreenLetterDoneFlag As Int64 = 0

  ' LN: 15/7/2015 If student has ever received a green letter this year then they are omitted from selection.
    Dim sqlGreenLetterEver = " SELECT count(*) FROM GREEN_AMBER_RED_LETTERS WHERE YEAR(GREEN_LETTER_SENT_DATE) = YEAR(getdate()) AND GREEN_LETTER_SENT_FLAG='Y' AND STUDENT_ID = " & DataItem.STUDENT_ID.GetFormattedValue() ' LN: 15/7/2015 
    Dim GreenLetterEver As Int64 = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(sqlGreenLetterEver))).Value, Int64) ' LN: 15/7/2015 

	If (GreenLetterEver = 0 ) then
		' only check others if no green letter sent otherwise can skip stright to Hide

		'check if recent (last 7 days) since chose No (Active) and hide if any
	     Dim sqlRecentActive = "SELECT count(*) FROM [STUDENT_SUBJECT] "  
	     sqlRecentActive += " WHERE SUBJECT_ID NOT IN (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)) " 
	     sqlRecentActive += " AND SUBJ_ENROL_STATUS in ('D','C') AND ENROLMENT_YEAR=YEAR(getdate()) "
	     sqlRecentActive += " AND ((datediff(day,defaulting_status_date, getdate()) > " + DelayOnSelectionNo + ") OR defaulting_status_date IS NULL)  " 
	     sqlRecentActive += " AND STUDENT_ID = " & DataItem.STUDENT_ID.GetFormattedValue()
	
	     Dim tmpRecentActiveFlag as Int64 = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(sqlRecentActive))).Value, Int64) 
	
		' show if F-10, Enroled 14 days ago, and not Recently 'Active' already
		'16-July-2017|EA|adjust year from 0-10 to 0-12
		 viewMaintainSearchRequest1rbGreenLetterSend.Visible = False	' turn off for all unless following valid
 	  	 If ((tmpRecentActiveFlag > 0) And (Item.hidden_days_since_enrolment.Value >= 14) And (Item.YEAR_LEVEL.Value >= 0 And Item.YEAR_LEVEL.Value <= 12)) And ((Sem1GreenLetterStartDate <= Now() And Now() <= Sem2GreenLetterEndDate) ) Then 
            viewMaintainSearchRequest1rbGreenLetterSend.Visible = True
            viewMaintainSearchRequest1lblGreenLetter.Visible = False
            tmpGreenLetterCount += 1        '21-Mar-2013|EA| set counter to show button
 	  	 End If  	 
   	Else
   		' Green letter sent this year so hide
  		viewMaintainSearchRequest1rbGreenLetterSend.Visible = False
  		viewMaintainSearchRequest1lblGreenLetter.Visible = True
	End If
	
                ' -------------------------
                'End RadioButton rbGreenLetterSend Event BeforeShow. Action Custom Code

                'viewMaintainSearchRequest1 control Before Show tail @51-477CF3C9
            End If
            'End viewMaintainSearchRequest1 control Before Show tail

            'EditableGrid viewMaintainSearchRequest1 BeforeShowRow event @51-4A26197D
            If Not IsNothing(Item) Then viewMaintainSearchRequest1DataItem = Item
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'End EditableGrid viewMaintainSearchRequest1 BeforeShowRow event

                'EditableGrid viewMaintainSearchRequest1 BeforeShowRow event tail @51-477CF3C9
            End If
            'End EditableGrid viewMaintainSearchRequest1 BeforeShowRow event tail

            'EditableGrid viewMaintainSearchRequest1 ItemDataBound event tail @51-E31F8E2A
    End Sub
'End EditableGrid viewMaintainSearchRequest1 ItemDataBound event tail

'EditableGrid viewMaintainSearchRequest1 GetRedirectUrl method @51-71E6001F
    Protected Function GetviewMaintainSearchRequest1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetviewMaintainSearchRequest1RedirectUrl(ByVal redirectString As String) As String
        Return GetviewMaintainSearchRequest1RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid viewMaintainSearchRequest1 GetRedirectUrl method

'EditableGrid viewMaintainSearchRequest1 ShowErrors method @51-C3B803E3
    Protected Function viewMaintainSearchRequest1ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), viewMaintainSearchRequest1Item).IsUpdated Then col(CType(items(i), viewMaintainSearchRequest1Item).RowId).Visible = False
            If (CType(items(i), viewMaintainSearchRequest1Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), viewMaintainSearchRequest1Item).errors.Count - 1
                Select CType(items(i), viewMaintainSearchRequest1Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), viewMaintainSearchRequest1Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), viewMaintainSearchRequest1Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), viewMaintainSearchRequest1Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid viewMaintainSearchRequest1 ShowErrors method

'EditableGrid viewMaintainSearchRequest1 ItemCommand event @51-1F93301A
    Protected Sub viewMaintainSearchRequest1ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = viewMaintainSearchRequest1Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid viewMaintainSearchRequest1 ItemCommand event

'Button Button_Submit OnClick. @70-0F2EE1BC
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequest1Button_Submit" Then
            RedirectUrl  = GetviewMaintainSearchRequest1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @70-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Button_Submit1 OnClick. @121-CA7563C2
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequest1Button_Submit1" Then
            RedirectUrl  = GetviewMaintainSearchRequest1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit1 OnClick.

'Button Button_Submit1 OnClick tail. @121-477CF3C9
        End If
'End Button Button_Submit1 OnClick tail.

'EditableGrid Form viewMaintainSearchRequest1 ItemCommand event tail @51-D2EAE55B
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("viewMaintainSearchRequest1SortDir"), SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequest1SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("viewMaintainSearchRequest1SortDir") = SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequest1SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequest1SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As viewMaintainSearchRequest1DataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequest1SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequest1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("viewMaintainSearchRequest1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("viewMaintainSearchRequest1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequest1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            viewMaintainSearchRequest1IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = viewMaintainSearchRequest1Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest1RowState"), Hashtable)
            viewMaintainSearchRequest1Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim viewMaintainSearchRequest1STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest1STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1SURNAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1FIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1link_IntakeDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest1link_IntakeDone"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest1link_PathwaysDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest1link_PathwaysDone"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest1ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1lblNewStudent"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1hidden_days_since_enrolment As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("viewMaintainSearchRequest1hidden_days_since_enrolment"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim viewMaintainSearchRequest1rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("viewMaintainSearchRequest1rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
                    Dim viewMaintainSearchRequest1Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest1Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest1lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1lblGreenLetter"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1RED_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1RED_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1RED_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1MandatedCohort As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1MandatedCohort"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest1LearningPlan As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest1LearningPlan"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As viewMaintainSearchRequest1Item = New viewMaintainSearchRequest1Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.STUDENT_ID.Value = ViewState(viewMaintainSearchRequest1STUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(viewMaintainSearchRequest1SURNAME.UniqueID)
                    item.FIRST_NAME.Value = ViewState(viewMaintainSearchRequest1FIRST_NAME.UniqueID)
                    item.YEAR_LEVEL.Value = ViewState(viewMaintainSearchRequest1YEAR_LEVEL.UniqueID)
                    item.ENROLMENT_STATUS.Value = ViewState(viewMaintainSearchRequest1ENROLMENT_STATUS.UniqueID)
                    item.link_IntakeDone.Value = ViewState(viewMaintainSearchRequest1link_IntakeDone.UniqueID)
                    item.link_PathwaysDone.Value = ViewState(viewMaintainSearchRequest1link_PathwaysDone.UniqueID)
                    item.ENROLMENT_DATE.Value = ViewState(viewMaintainSearchRequest1ENROLMENT_DATE.UniqueID)
                    item.lblNewStudent.Value = ViewState(viewMaintainSearchRequest1lblNewStudent.UniqueID)
                    item.Link1.Value = ViewState(viewMaintainSearchRequest1Link1.UniqueID)
                    item.lblGreenLetter.Value = ViewState(viewMaintainSearchRequest1lblGreenLetter.UniqueID)
                    item.GREEN_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest1GREEN_LETTER_SENT_FLAG.UniqueID)
                    item.GREEN_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest1GREEN_LETTER_SENT_DATE.UniqueID)
                    item.AMBER_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest1AMBER_LETTER_SENT_FLAG.UniqueID)
                    item.AMBER_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest1AMBER_LETTER_SENT_DATE.UniqueID)
                    item.RED_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest1RED_LETTER_SENT_FLAG.UniqueID)
                    item.RED_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest1RED_LETTER_SENT_DATE.UniqueID)
                    item.MandatedCohort.Value = ViewState(viewMaintainSearchRequest1MandatedCohort.UniqueID)
                    item.LearningPlan.Value = ViewState(viewMaintainSearchRequest1LearningPlan.UniqueID)
                    Try
                    item.hidden_days_since_enrolment.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequest1hidden_days_since_enrolment.UniqueID))
                    item.hidden_days_since_enrolment.SetValue(viewMaintainSearchRequest1hidden_days_since_enrolment.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("hidden_days_since_enrolment",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_days_since_enrolment"))
                    End Try
                    item.rbGreenLetterSend.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequest1rbGreenLetterSend.UniqueID))
                    If Not IsNothing(viewMaintainSearchRequest1rbGreenLetterSend.SelectedItem) Then
                        item.rbGreenLetterSend.SetValue(viewMaintainSearchRequest1rbGreenLetterSend.SelectedItem.Value)
                    Else
                        item.rbGreenLetterSend.Value = Nothing
                    End If
                    item.rbGreenLetterSendItems.CopyFrom(viewMaintainSearchRequest1rbGreenLetterSend.Items)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(viewMaintainSearchRequest1Data) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form viewMaintainSearchRequest1 ItemCommand event tail

'EditableGrid viewMaintainSearchRequest1 Update @51-E9F6B302
            If BindAllowed Then
                Try
                    viewMaintainSearchRequest1Parameters()
                    viewMaintainSearchRequest1Data.Update(items, viewMaintainSearchRequest1Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid viewMaintainSearchRequest1 Update

'EditableGrid viewMaintainSearchRequest1 After Update @51-FF7A4C95
                End Try
                If viewMaintainSearchRequest1ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                viewMaintainSearchRequest1ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                viewMaintainSearchRequest1Bind()
            End If
        End Sub
'End EditableGrid viewMaintainSearchRequest1 After Update

'EditableGrid viewMaintainSearchRequest2 Bind @161-8465070B
    Protected Sub viewMaintainSearchRequest2Bind()
        If viewMaintainSearchRequest2Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest2",GetType(viewMaintainSearchRequest2DataProvider.SortFields), 100, 100)
        End If
'End EditableGrid viewMaintainSearchRequest2 Bind

'EditableGrid Form viewMaintainSearchRequest2 BeforeShow tail @161-049001D8
        viewMaintainSearchRequest2Parameters()
        viewMaintainSearchRequest2Data.SortField = CType(ViewState("viewMaintainSearchRequest2SortField"), viewMaintainSearchRequest2DataProvider.SortFields)
        viewMaintainSearchRequest2Data.SortDir = CType(ViewState("viewMaintainSearchRequest2SortDir"), SortDirections)
        viewMaintainSearchRequest2Data.PageNumber = CType(ViewState("viewMaintainSearchRequest2PageNumber"), Integer)
        viewMaintainSearchRequest2Data.RecordsPerPage = CType(ViewState("viewMaintainSearchRequest2PageSize"), Integer)
        viewMaintainSearchRequest2Repeater.DataSource = viewMaintainSearchRequest2Data.GetResultSet(PagesCount, viewMaintainSearchRequest2Operations)
        ViewState("viewMaintainSearchRequest2PagesCount") = PagesCount
        ViewState("viewMaintainSearchRequest2FormState") = New Hashtable()
        ViewState("viewMaintainSearchRequest2RowState") = New Hashtable()
        viewMaintainSearchRequest2Repeater.DataBind()
        Dim item As viewMaintainSearchRequest2Item = viewMaintainSearchRequest2DataItem
        If IsNothing(item) Then item = New viewMaintainSearchRequest2Item()
        FooterIndex = viewMaintainSearchRequest2Repeater.Controls.Count - 1
        Dim Script As Literal = CType(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var viewMaintainSearchRequest2StaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "viewMaintainSearchRequest2StaticElementsID = new Array ("
        Elements.Text += "var viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecordsID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest2Button_SubmitID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest2Button_Submit").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest2lblPastoralIDID=2;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2lblPastoralID").ClientID + """),"
        Elements.Text += "var viewMaintainSearchRequest2Button_Submit1ID=3;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest2Button_Submit1").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Dim viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim viewMaintainSearchRequest2Button_Submit As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest2Button_Submit"),System.Web.UI.WebControls.Button)
        Dim viewMaintainSearchRequest2lblPastoralID As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2lblPastoralID"),System.Web.UI.WebControls.Literal)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LADIDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_LADIDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CATEGORY_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_CATEGORY_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim viewMaintainSearchRequest2Button_Submit1 As System.Web.UI.WebControls.Button = DirectCast(viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("viewMaintainSearchRequest2Button_Submit1"),System.Web.UI.WebControls.Button)

        item.lblPastoralID.SetValue((session("UserID").toupper))

        viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords.Text = Server.HtmlEncode(item.viewMaintainSearchRequest1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewMaintainSearchRequest2lblPastoralID.Text = Server.HtmlEncode(item.lblPastoralID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewMaintainSearchRequest2Button_Submit.Visible = viewMaintainSearchRequest2Operations.Editable
        viewMaintainSearchRequest2Button_Submit1.Visible = viewMaintainSearchRequest2Operations.Editable
        If Not CType(viewMaintainSearchRequest2Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If viewMaintainSearchRequest2Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In viewMaintainSearchRequest2Errors
                ErrorLabel.Text += viewMaintainSearchRequest2Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form viewMaintainSearchRequest2 BeforeShow tail

'Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records @282-442AFC96
            viewMaintainSearchRequest2viewMaintainSearchRequest1_TotalRecords.Text = viewMaintainSearchRequest2Data.RecordCount.ToString()
'End Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Button Button_Submit Event BeforeShow. Action Hide-Show Component @284-3070BC0C
        Dim TotalRecords_284_1 As IntegerField = New IntegerField("",viewMaintainSearchRequest2Data.RecordCount)
        Dim ExprParam2_284_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(TotalRecords_284_1, ExprParam2_284_2) Then
            viewMaintainSearchRequest2Button_Submit.Visible = False
        End If
'End Button Button_Submit Event BeforeShow. Action Hide-Show Component

'Button Button_Submit Event BeforeShow. Action Hide-Show Component @285-F21E0B10
        Dim ExprParam1_285_1 As IntegerField = New IntegerField("", (tmpNoCLPCount))
        Dim ExprParam2_285_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(ExprParam1_285_1, ExprParam2_285_2) Then
            viewMaintainSearchRequest2Button_Submit.Visible = False
        End If
'End Button Button_Submit Event BeforeShow. Action Hide-Show Component

'Button Button_Submit1 Event BeforeShow. Action Hide-Show Component @287-81528454
        Dim TotalRecords_287_1 As IntegerField = New IntegerField("",viewMaintainSearchRequest2Data.RecordCount)
        Dim ExprParam2_287_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(TotalRecords_287_1, ExprParam2_287_2) Then
            viewMaintainSearchRequest2Button_Submit1.Visible = False
        End If
'End Button Button_Submit1 Event BeforeShow. Action Hide-Show Component

'Button Button_Submit1 Event BeforeShow. Action Hide-Show Component @288-F8E40189
        Dim ExprParam1_288_1 As IntegerField = New IntegerField("", (tmpGreenLetterCount))
        Dim ExprParam2_288_2 As IntegerField = New IntegerField("", (0))
        If FieldBase.EqualOp(ExprParam1_288_1, ExprParam2_288_2) Then
            viewMaintainSearchRequest2Button_Submit1.Visible = False
        End If
'End Button Button_Submit1 Event BeforeShow. Action Hide-Show Component

'EditableGrid viewMaintainSearchRequest2 Bind tail @161-0361C426
        viewMaintainSearchRequest2ShowErrors(New ArrayList(CType(viewMaintainSearchRequest2Repeater.DataSource, ICollection)), viewMaintainSearchRequest2Repeater.Items)
    End Sub
'End EditableGrid viewMaintainSearchRequest2 Bind tail

'EditableGrid viewMaintainSearchRequest2 Table Parameters @161-39D83CB9
    Protected Sub viewMaintainSearchRequest2Parameters()
        Try
        Dim item As new viewMaintainSearchRequest2Item
            viewMaintainSearchRequest2Data.CtrlrbGreenLetterSend = TextParameter.GetParam(item.rbGreenLetterSend.Value, ParameterSourceType.Control, "", Nothing, false)
            viewMaintainSearchRequest2Data.Expr234 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            viewMaintainSearchRequest2Data.SesUserId = TextParameter.GetParam("UserId", ParameterSourceType.Session, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = viewMaintainSearchRequest2Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(viewMaintainSearchRequest2Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid viewMaintainSearchRequest2: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid viewMaintainSearchRequest2 Table Parameters

'EditableGrid viewMaintainSearchRequest2 ItemDataBound event @161-FE03EAFA
    Protected Sub viewMaintainSearchRequest2ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As viewMaintainSearchRequest2Item = DirectCast(e.Item.DataItem, viewMaintainSearchRequest2Item)
        Dim Item as viewMaintainSearchRequest2Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequest2CurrentRowNumber = viewMaintainSearchRequest2CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest2FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest2RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2STUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2SURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2FIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2YEAR_LEVEL").UniqueID) = DataItem.YEAR_LEVEL.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2ENROLMENT_STATUS").UniqueID) = DataItem.ENROLMENT_STATUS.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2link_IntakeDone").UniqueID) = DataItem.link_IntakeDone.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2link_PathwaysDone").UniqueID) = DataItem.link_PathwaysDone.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2ENROLMENT_DATE").UniqueID) = DataItem.ENROLMENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2lblNewStudent").UniqueID) = DataItem.lblNewStudent.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2Link1").UniqueID) = DataItem.Link1.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2LAD").UniqueID) = DataItem.LAD.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2CATEGORY_CODE").UniqueID) = DataItem.CATEGORY_CODE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2lblGreenLetter").UniqueID) = DataItem.lblGreenLetter.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG").UniqueID) = DataItem.GREEN_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE").UniqueID) = DataItem.GREEN_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG").UniqueID) = DataItem.AMBER_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE").UniqueID) = DataItem.AMBER_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_FLAG").UniqueID) = DataItem.RED_LETTER_SENT_FLAG.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_DATE").UniqueID) = DataItem.RED_LETTER_SENT_DATE.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2MandatedCohort").UniqueID) = DataItem.MandatedCohort.Value
            ViewState(e.Item.FindControl("viewMaintainSearchRequest2LearningPlan").UniqueID) = DataItem.LearningPlan.Value
            Dim viewMaintainSearchRequest2STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest2SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2SURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2link_IntakeDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2link_IntakeDone"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest2link_PathwaysDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2link_PathwaysDone"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest2ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2lblNewStudent"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2hidden_days_since_enrolment As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2hidden_days_since_enrolment"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim viewMaintainSearchRequest2Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest2LAD As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2LAD"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2CATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2CATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
            Dim viewMaintainSearchRequest2lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2lblGreenLetter"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2RED_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2RED_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2MandatedCohort As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2MandatedCohort"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2LearningPlan As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2LearningPlan"),System.Web.UI.WebControls.Literal)
            CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequest2Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequest2CurrentRowNumber), AttributeOption.Multiple)
            DataItem.STUDENT_IDHref = "Student_Comments_maintain.aspx"
            viewMaintainSearchRequest2STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","", ViewState)
            DataItem.link_IntakeDoneHref = "Student_Comments_maintain.aspx"
            DataItem.link_IntakeDoneHrefParameters.Add("showinterviewpanel",System.Web.HttpUtility.UrlEncode((1).ToString()))
            viewMaintainSearchRequest2link_IntakeDone.HRef = DataItem.link_IntakeDoneHref & DataItem.link_IntakeDoneHrefParameters.ToString("GET","", ViewState)
            DataItem.link_PathwaysDoneHref = "Student_Comments_maintain.aspx"
            DataItem.link_PathwaysDoneHrefParameters.Add("showprofilepanel",System.Web.HttpUtility.UrlEncode((1).ToString()))
            viewMaintainSearchRequest2link_PathwaysDone.HRef = DataItem.link_PathwaysDoneHref & DataItem.link_PathwaysDoneHrefParameters.ToString("GET","", ViewState)
            DataItem.lblNewStudent.SetValue("<font color=green>New!</font>")
            viewMaintainSearchRequest2lblNewStudent.Text = DataItem.lblNewStudent.GetFormattedValue()
            DataItem.Link1Href = "StudentSummary.aspx"
            viewMaintainSearchRequest2Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
            DataItem.rbGreenLetterSendItems.SetSelection(DataItem.rbGreenLetterSend.GetFormattedValue())
            viewMaintainSearchRequest2rbGreenLetterSend.SelectedIndex = -1
            DataItem.rbGreenLetterSendItems.CopyTo(viewMaintainSearchRequest2rbGreenLetterSend.Items)
        End If
'End EditableGrid viewMaintainSearchRequest2 ItemDataBound event

'viewMaintainSearchRequest2 control Before Show @161-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End viewMaintainSearchRequest2 control Before Show



'Get Control @204-4FF201E3
            Dim viewMaintainSearchRequest2lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2lblNewStudent"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label lblNewStudent Event BeforeShow. Action Custom Code @286-73254650
      ' -------------------------
      'ERA: force the New Label to hide if over 3weeks since enrolment (normal Hide-Show component wasn't working
          if (Item.hidden_days_since_enrolment.Value > 20) then
  			viewMaintainSearchRequest2lblNewStudent.Visible = False
          End If
  
      ' -------------------------
'End Label lblNewStudent Event BeforeShow. Action Custom Code

'Get Control @258-4836D30E
            Dim viewMaintainSearchRequest2rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control


'RadioButton rbGreenLetterSend Event BeforeShow. Action Declare Variable @289-DDE1188D
            Dim tmpCountDefaulting As Int64 = 0
'End RadioButton rbGreenLetterSend Event BeforeShow. Action Declare Variable

'RadioButton rbGreenLetterSend Event BeforeShow. Action Custom Code @290-73254650
      ' -------------------------
      '28-Feb-2014|EA|move from above, for easier changes - adjust to check for
      'tmpCountDefaulting = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "[STUDENT_SUBJECT]" & " WHERE " & "SUBJECT_ID not in (921,922,923,924,931,932,933) AND SUBJ_ENROL_STATUS = 'D' AND ENROLMENT_YEAR=YEAR(getdate()) and (defaulting_status_date is null or datediff(day,defaulting_status_date, getdate()) > 140) AND STUDENT_ID =" & DataItem.student_id.GetFormattedValue()))).Value, Int64)
      '23/4/2014|LN| 21 days if 'A'('No - Do not Send'). 140 days if 'I'/'Yes - Send Warning'
      'tmpCountDefaulting = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "[STUDENT_SUBJECT]" & " WHERE " & "SUBJECT_ID not in (921,922,923,924,931,932,933) AND SUBJ_ENROL_STATUS = 'D' AND ENROLMENT_YEAR=YEAR(getdate()) and ( (defaulting_status_date is null or (datediff(day,defaulting_status_date, getdate()) > 140) and defaulting_status = 'I' ) or (defaulting_status_date is null or (datediff(day,defaulting_status_date, getdate()) > 21) and defaulting_status = 'A' ) ) AND STUDENT_ID = " & DataItem.student_id.GetFormattedValue()))).Value, Int64)
  
  	'4-Aug-2016|EA| massive re-write of the rules to simplify them per Allira S (unfuddle #762)
  	' to include:
  	'    - show for F-10 yearlevel, if > 14 days since enrolment, NO check for Defaulting Subjects
  	'    - don't show if 11-12, or if already received Green Letter this year, or if YES selected
  	'    - if NO selected then don't show for 7 days
  	'
  	' All previous code not needed has been removed after committing to Repo
      '16-July-2017|EA| duplicated LAd Green Letter to Single subject - need to change
      '	viewMaintainSearchRequest1 to viewMaintainSearchRequest2 
  
      '19/2/2015|LN| Instead of changing code every year, just change these common parameters.
      Dim DelayOnSelectionNo As String = "7"      '19/2/2015|LN| 
      
      
      
      ' LN:23/2/2016 Added one year to disable.
      'Dim GreenLetterEndDate As Date = New Date(Now().Year, 11, 7)    '19/2/2015|LN| 
      '15/7/2015|LN|  1/3/2016|LN    26-Feb-2018|EA| adjust to 5 March and also line 425ish
      '20-Feb-2020|EA| adjust to 20 Feb per John Vit  and also line 425ish
      Dim Sem1GreenLetterStartDate As Date = New Date(Now().Year, 2, 19)
      Dim Sem2GreenLetterEndDate As Date = New Date(Now().Year, 11, 25)     '15/7/2015|LN| 
  
   	Dim viewMaintainSearchRequest2lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2lblGreenLetter"),System.Web.UI.WebControls.Literal)
   	viewMaintainSearchRequest2lblGreenLetter.Visible = True
  	Dim tmpGreenLetterDoneFlag As Int64 = 0
  
    ' LN: 15/7/2015 If student has ever received a green letter this year then they are omitted from selection.
      Dim sqlGreenLetterEver = " SELECT count(*) FROM GREEN_AMBER_RED_LETTERS WHERE YEAR(GREEN_LETTER_SENT_DATE) = YEAR(getdate()) AND GREEN_LETTER_SENT_FLAG='Y' AND STUDENT_ID = " & DataItem.STUDENT_ID.GetFormattedValue() ' LN: 15/7/2015 
      Dim GreenLetterEver As Int64 = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(sqlGreenLetterEver))).Value, Int64) ' LN: 15/7/2015 
  
  	If (GreenLetterEver = 0 ) then
  		' only check others if no green letter sent otherwise can skip stright to Hide
  
  		'check if recent (last 7 days) since chose No (Active) and hide if any
  	     Dim sqlRecentActive = "SELECT count(*) FROM [STUDENT_SUBJECT] "  
  	     sqlRecentActive += " WHERE SUBJECT_ID NOT IN (select vis.IntroductorySubjectID from dbo.vwIntroductorySubject as vis where (vis.IntroductorySubjectStatus = 1)) " 
  	     sqlRecentActive += " AND SUBJ_ENROL_STATUS in ('D','C') AND ENROLMENT_YEAR=YEAR(getdate()) "
  	     sqlRecentActive += " AND ((datediff(day,defaulting_status_date, getdate()) > " + DelayOnSelectionNo + ") OR defaulting_status_date IS NULL)  " 
  	     sqlRecentActive += " AND STUDENT_ID = " & DataItem.STUDENT_ID.GetFormattedValue()
  	
  	     Dim tmpRecentActiveFlag as Int64 = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar(sqlRecentActive))).Value, Int64) 
  	
  		' show if F-10, Enroled 14 days ago, and not Recently 'Active' already
  		'16-July-2017|EA|adjust year from 0-10 to 0-12
  		 viewMaintainSearchRequest2rbGreenLetterSend.Visible = False	' turn off for all unless following valid
   	  	 If ((tmpRecentActiveFlag > 0) And (Item.hidden_days_since_enrolment.Value >= 14) And (Item.YEAR_LEVEL.Value >= 0 And Item.YEAR_LEVEL.Value <= 12)) And ((Sem1GreenLetterStartDate <= Now() And Now() <= Sem2GreenLetterEndDate) ) Then 
              viewMaintainSearchRequest2rbGreenLetterSend.Visible = True
              viewMaintainSearchRequest2lblGreenLetter.Visible = False
              tmpGreenLetterCount += 1        '21-Mar-2013|EA| set counter to show button
   	  	 End If  	 
     	Else
     		' Green letter sent this year so hide
    		viewMaintainSearchRequest2rbGreenLetterSend.Visible = False
    		viewMaintainSearchRequest2lblGreenLetter.Visible = True
  	End If
  	
      ' -------------------------
'End RadioButton rbGreenLetterSend Event BeforeShow. Action Custom Code



'viewMaintainSearchRequest2 control Before Show tail @161-477CF3C9
        End If
'End viewMaintainSearchRequest2 control Before Show tail

'EditableGrid viewMaintainSearchRequest2 BeforeShowRow event @161-8EF81D7A
        If Not IsNothing(Item) Then viewMaintainSearchRequest2DataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid viewMaintainSearchRequest2 BeforeShowRow event

'EditableGrid viewMaintainSearchRequest2 BeforeShowRow event tail @161-477CF3C9
        End If
'End EditableGrid viewMaintainSearchRequest2 BeforeShowRow event tail

'EditableGrid viewMaintainSearchRequest2 ItemDataBound event tail @161-E31F8E2A
    End Sub
'End EditableGrid viewMaintainSearchRequest2 ItemDataBound event tail

'EditableGrid viewMaintainSearchRequest2 GetRedirectUrl method @161-A55E32B1
    Protected Function GetviewMaintainSearchRequest2RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetviewMaintainSearchRequest2RedirectUrl(ByVal redirectString As String) As String
        Return GetviewMaintainSearchRequest2RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid viewMaintainSearchRequest2 GetRedirectUrl method

'EditableGrid viewMaintainSearchRequest2 ShowErrors method @161-4FC49242
    Protected Function viewMaintainSearchRequest2ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), viewMaintainSearchRequest2Item).IsUpdated Then col(CType(items(i), viewMaintainSearchRequest2Item).RowId).Visible = False
            If (CType(items(i), viewMaintainSearchRequest2Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), viewMaintainSearchRequest2Item).errors.Count - 1
                Select CType(items(i), viewMaintainSearchRequest2Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), viewMaintainSearchRequest2Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), viewMaintainSearchRequest2Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), viewMaintainSearchRequest2Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid viewMaintainSearchRequest2 ShowErrors method

'EditableGrid viewMaintainSearchRequest2 ItemCommand event @161-136E47F8
    Protected Sub viewMaintainSearchRequest2ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = viewMaintainSearchRequest2Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid viewMaintainSearchRequest2 ItemCommand event

'Button Button_Submit OnClick. @177-E14C5533
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequest2Button_Submit" Then
            RedirectUrl  = GetviewMaintainSearchRequest2RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @177-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Button_Submit1 OnClick. @255-7E6998ED
        If Ctype(e.CommandSource,Control).ID = "viewMaintainSearchRequest2Button_Submit1" Then
            RedirectUrl  = GetviewMaintainSearchRequest2RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit1 OnClick.

'Button Button_Submit1 OnClick tail. @255-477CF3C9
        End If
'End Button Button_Submit1 OnClick tail.

'EditableGrid Form viewMaintainSearchRequest2 ItemCommand event tail @161-D2154736
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("viewMaintainSearchRequest2SortDir"), SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequest2SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("viewMaintainSearchRequest2SortDir") = SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequest2SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequest2SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As viewMaintainSearchRequest2DataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequest2SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequest2PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("viewMaintainSearchRequest2PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("viewMaintainSearchRequest2PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequest2PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            viewMaintainSearchRequest2IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = viewMaintainSearchRequest2Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest2FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("viewMaintainSearchRequest2RowState"), Hashtable)
            viewMaintainSearchRequest2Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim viewMaintainSearchRequest2STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest2STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest2SURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2SURNAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2FIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2link_IntakeDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest2link_IntakeDone"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest2link_PathwaysDone As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest2link_PathwaysDone"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest2ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2lblNewStudent As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2lblNewStudent"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2hidden_days_since_enrolment As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("viewMaintainSearchRequest2hidden_days_since_enrolment"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim viewMaintainSearchRequest2Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("viewMaintainSearchRequest2Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim viewMaintainSearchRequest2LAD As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2LAD"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2CATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2CATEGORY_CODE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2rbGreenLetterSend As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("viewMaintainSearchRequest2rbGreenLetterSend"),System.Web.UI.WebControls.RadioButtonList)
                    Dim viewMaintainSearchRequest2lblGreenLetter As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2lblGreenLetter"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2RED_LETTER_SENT_FLAG As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_FLAG"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2RED_LETTER_SENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2RED_LETTER_SENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2MandatedCohort As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2MandatedCohort"),System.Web.UI.WebControls.Literal)
                    Dim viewMaintainSearchRequest2LearningPlan As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("viewMaintainSearchRequest2LearningPlan"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As viewMaintainSearchRequest2Item = New viewMaintainSearchRequest2Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.STUDENT_ID.Value = ViewState(viewMaintainSearchRequest2STUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(viewMaintainSearchRequest2SURNAME.UniqueID)
                    item.FIRST_NAME.Value = ViewState(viewMaintainSearchRequest2FIRST_NAME.UniqueID)
                    item.YEAR_LEVEL.Value = ViewState(viewMaintainSearchRequest2YEAR_LEVEL.UniqueID)
                    item.ENROLMENT_STATUS.Value = ViewState(viewMaintainSearchRequest2ENROLMENT_STATUS.UniqueID)
                    item.link_IntakeDone.Value = ViewState(viewMaintainSearchRequest2link_IntakeDone.UniqueID)
                    item.link_PathwaysDone.Value = ViewState(viewMaintainSearchRequest2link_PathwaysDone.UniqueID)
                    item.ENROLMENT_DATE.Value = ViewState(viewMaintainSearchRequest2ENROLMENT_DATE.UniqueID)
                    item.lblNewStudent.Value = ViewState(viewMaintainSearchRequest2lblNewStudent.UniqueID)
                    item.Link1.Value = ViewState(viewMaintainSearchRequest2Link1.UniqueID)
                    item.LAD.Value = ViewState(viewMaintainSearchRequest2LAD.UniqueID)
                    item.CATEGORY_CODE.Value = ViewState(viewMaintainSearchRequest2CATEGORY_CODE.UniqueID)
                    item.lblGreenLetter.Value = ViewState(viewMaintainSearchRequest2lblGreenLetter.UniqueID)
                    item.GREEN_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest2GREEN_LETTER_SENT_FLAG.UniqueID)
                    item.GREEN_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest2GREEN_LETTER_SENT_DATE.UniqueID)
                    item.AMBER_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest2AMBER_LETTER_SENT_FLAG.UniqueID)
                    item.AMBER_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest2AMBER_LETTER_SENT_DATE.UniqueID)
                    item.RED_LETTER_SENT_FLAG.Value = ViewState(viewMaintainSearchRequest2RED_LETTER_SENT_FLAG.UniqueID)
                    item.RED_LETTER_SENT_DATE.Value = ViewState(viewMaintainSearchRequest2RED_LETTER_SENT_DATE.UniqueID)
                    item.MandatedCohort.Value = ViewState(viewMaintainSearchRequest2MandatedCohort.UniqueID)
                    item.LearningPlan.Value = ViewState(viewMaintainSearchRequest2LearningPlan.UniqueID)
                    Try
                    item.hidden_days_since_enrolment.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequest2hidden_days_since_enrolment.UniqueID))
                    item.hidden_days_since_enrolment.SetValue(viewMaintainSearchRequest2hidden_days_since_enrolment.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("hidden_days_since_enrolment",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_days_since_enrolment"))
                    End Try
                    item.rbGreenLetterSend.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequest2rbGreenLetterSend.UniqueID))
                    If Not IsNothing(viewMaintainSearchRequest2rbGreenLetterSend.SelectedItem) Then
                        item.rbGreenLetterSend.SetValue(viewMaintainSearchRequest2rbGreenLetterSend.SelectedItem.Value)
                    Else
                        item.rbGreenLetterSend.Value = Nothing
                    End If
                    item.rbGreenLetterSendItems.CopyFrom(viewMaintainSearchRequest2rbGreenLetterSend.Items)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(viewMaintainSearchRequest2Data) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form viewMaintainSearchRequest2 ItemCommand event tail

'EditableGrid viewMaintainSearchRequest2 Update @161-B4CAC0D3
            If BindAllowed Then
                Try
                    viewMaintainSearchRequest2Parameters()
                    viewMaintainSearchRequest2Data.Update(items, viewMaintainSearchRequest2Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("viewMaintainSearchRequest2Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid viewMaintainSearchRequest2 Update

'EditableGrid viewMaintainSearchRequest2 After Update @161-DB2DE371
                End Try
                If viewMaintainSearchRequest2ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                viewMaintainSearchRequest2ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                viewMaintainSearchRequest2Bind()
            End If
        End Sub
'End EditableGrid viewMaintainSearchRequest2 After Update

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A22AFB38
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        PastoralTeacher_StudentListContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewMaintainSearchRequest1Data = New viewMaintainSearchRequest1DataProvider()
        viewMaintainSearchRequest1Operations = New FormSupportedOperations(True, True, False, True, False)
        viewMaintainSearchRequest2Data = New viewMaintainSearchRequest2DataProvider()
        viewMaintainSearchRequest2Operations = New FormSupportedOperations(True, True, False, True, False)
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

