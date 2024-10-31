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

Namespace DECV_PROD2007.SUBJECT_maint 'Namespace @1-9790DE0A

'Forms Definition @1-A80EAF84
Public Class [SUBJECT_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-5F5B6195
    Protected NewRecord1Data As NewRecord1DataProvider
    Protected NewRecord1Errors As NameValueCollection = New NameValueCollection()
    Protected NewRecord1Operations As FormSupportedOperations
    Protected NewRecord1IsSubmitted As Boolean = False
    Protected SUBJECT_TEACHERData As SUBJECT_TEACHERDataProvider
    Protected SUBJECT_TEACHERCurrentRowNumber As Integer
    Protected SUBJECT_TEACHERIsSubmitted As Boolean = False
    Protected SUBJECT_TEACHERErrors As New NameValueCollection()
    Protected SUBJECT_TEACHEROperations As FormSupportedOperations
    Protected SUBJECT_TEACHERDataItem As SUBJECT_TEACHERItem
    Protected SUBJECT_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-83CF8541
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "SUBJECT_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","SUBJECT_ID", ViewState)
            Link1.DataBind()
            NewRecord1Show()
            SUBJECT_TEACHERBind()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form NewRecord1 Parameters @29-DB1BF7F8

    Protected Sub NewRecord1Parameters()
        Dim item As new NewRecord1Item
        Try
            NewRecord1Data.Expr68 = TextParameter.GetParam(DBUtility.UserId.ToString(), ParameterSourceType.Expression, "", "unknown", false)
            NewRecord1Data.Expr69 = DateParameter.GetParam(DateTime.Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            NewRecord1Data.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            NewRecord1Data.CtrlSUBJECT_ID = IntegerParameter.GetParam(item.SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlSUBJECT_ABBREV = TextParameter.GetParam(item.SUBJECT_ABBREV.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlSUBJECT_TITLE = TextParameter.GetParam(item.SUBJECT_TITLE.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlCAMPUS_CODE = TextParameter.GetParam(item.CAMPUS_CODE.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlYEAR_LEVEL = IntegerParameter.GetParam(item.YEAR_LEVEL.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlDEFAULT_SEMESTER = TextParameter.GetParam(item.DEFAULT_SEMESTER.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlDEFAULT_TEACHER_ID = TextParameter.GetParam(item.DEFAULT_TEACHER_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlSUB_SCHOOL = TextParameter.GetParam(item.SUB_SCHOOL.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlKLA_ID = FloatParameter.GetParam(item.KLA_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlCSF_CLASS_LEVEL = IntegerParameter.GetParam(item.CSF_CLASS_LEVEL.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlMAX_BOOKS = IntegerParameter.GetParam(item.MAX_BOOKS.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlDESCRIPTION_LINE1 = TextParameter.GetParam(item.DESCRIPTION_LINE1.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlDESCRIPTION_LINE2 = TextParameter.GetParam(item.DESCRIPTION_LINE2.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlSTATUS = BooleanParameter.GetParam(item.STATUS.Value, ParameterSourceType.Control, Settings.BoolFormat, Nothing, false)
            NewRecord1Data.Expr86 = TextParameter.GetParam(DBUtility.UserId.ToString(), ParameterSourceType.Expression, "", "unknown", false)
            NewRecord1Data.Expr87 = DateParameter.GetParam(DateTime.Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            NewRecord1Data.Ctrlhidden_VALID_COURSE_DISTRIBUTION = TextParameter.GetParam(item.hidden_VALID_COURSE_DISTRIBUTION.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlSUBJECT_TITLE_NEW = TextParameter.GetParam(item.SUBJECT_TITLE_NEW.Value, ParameterSourceType.Control, "", Nothing, false)
            NewRecord1Data.CtrlCORE_YEARLEVELS = TextParameter.GetParam(item.CORE_YEARLEVELS.Value, ParameterSourceType.Control, "", "", false)
            NewRecord1Data.CtrlrbCORE_SUBJECT_FLAG = IntegerParameter.GetParam(item.rbCORE_SUBJECT_FLAG.Value, ParameterSourceType.Control, "", 0, false)
            NewRecord1Data.CtrlLINKED_SUBJECT_ID = IntegerParameter.GetParam(item.LINKED_SUBJECT_ID.Value, ParameterSourceType.Control, "", 0, false)
            NewRecord1Data.CtrlcheckEXTENDABLE_SUBJECT = IntegerParameter.GetParam(item.checkEXTENDABLE_SUBJECT.Value, ParameterSourceType.Control, "", 0, false)
            NewRecord1Data.CtrlALLOCATE_STUDENTS_MAX = IntegerParameter.GetParam(item.ALLOCATE_STUDENTS_MAX.Value, ParameterSourceType.Control, "", 0, false)
            NewRecord1Data.CtrllistParentGroupSubject = IntegerParameter.GetParam(item.listParentGroupSubject.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            NewRecord1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form NewRecord1 Parameters

'Record Form NewRecord1 Show method @29-9BE48317
    Protected Sub NewRecord1Show()
        If NewRecord1Operations.None Then
            NewRecord1Holder.Visible = False
            Return
        End If
        Dim item As NewRecord1Item = NewRecord1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not NewRecord1Operations.AllowRead
        NewRecord1Errors.Add(item.errors)
        If NewRecord1Errors.Count > 0 Then
            NewRecord1ShowErrors()
            Return
        End If
'End Record Form NewRecord1 Show method

'Record Form NewRecord1 BeforeShow tail @29-00A25B12
        NewRecord1Parameters()
        NewRecord1Data.FillItem(item, IsInsertMode)
        NewRecord1Holder.DataBind()
        NewRecord1Button_Insert.Visible=IsInsertMode AndAlso NewRecord1Operations.AllowInsert
        NewRecord1Button_Update.Visible=Not (IsInsertMode) AndAlso NewRecord1Operations.AllowUpdate
        NewRecord1SUBJECT_ID.Text=item.SUBJECT_ID.GetFormattedValue()
        NewRecord1SUBJECT_ABBREV.Text=item.SUBJECT_ABBREV.GetFormattedValue()
        NewRecord1SUBJECT_TITLE.Text=item.SUBJECT_TITLE.GetFormattedValue()
        NewRecord1YEAR_LEVEL.Text=item.YEAR_LEVEL.GetFormattedValue()
        NewRecord1DEFAULT_SEMESTER.Items.Add(new ListItem("Select Value",""))
        NewRecord1DEFAULT_SEMESTER.Items(0).Selected = True
        item.DEFAULT_SEMESTERItems.SetSelection(item.DEFAULT_SEMESTER.GetFormattedValue())
        If Not item.DEFAULT_SEMESTERItems.GetSelectedItem() Is Nothing Then
            NewRecord1DEFAULT_SEMESTER.SelectedIndex = -1
        End If
        item.DEFAULT_SEMESTERItems.CopyTo(NewRecord1DEFAULT_SEMESTER.Items)
        NewRecord1DEFAULT_TEACHER_ID.Items.Add(new ListItem("Select Value",""))
        NewRecord1DEFAULT_TEACHER_ID.Items(0).Selected = True
        item.DEFAULT_TEACHER_IDItems.SetSelection(item.DEFAULT_TEACHER_ID.GetFormattedValue())
        If Not item.DEFAULT_TEACHER_IDItems.GetSelectedItem() Is Nothing Then
            NewRecord1DEFAULT_TEACHER_ID.SelectedIndex = -1
        End If
        item.DEFAULT_TEACHER_IDItems.CopyTo(NewRecord1DEFAULT_TEACHER_ID.Items)
        NewRecord1SUB_SCHOOL.Text=item.SUB_SCHOOL.GetFormattedValue()
        NewRecord1KLA_ID.Items.Add(new ListItem("Select Value",""))
        NewRecord1KLA_ID.Items(0).Selected = True
        item.KLA_IDItems.SetSelection(item.KLA_ID.GetFormattedValue())
        If Not item.KLA_IDItems.GetSelectedItem() Is Nothing Then
            NewRecord1KLA_ID.SelectedIndex = -1
        End If
        item.KLA_IDItems.CopyTo(NewRecord1KLA_ID.Items)
        NewRecord1CSF_CLASS_LEVEL.Text=item.CSF_CLASS_LEVEL.GetFormattedValue()
        NewRecord1MAX_BOOKS.Text=item.MAX_BOOKS.GetFormattedValue()
        If item.cbx_COURSE_BCheckedValue.Value.Equals(item.cbx_COURSE_B.Value) Then
            NewRecord1cbx_COURSE_B.Checked = True
        End If
        If item.cbx_COURSE_CCheckedValue.Value.Equals(item.cbx_COURSE_C.Value) Then
            NewRecord1cbx_COURSE_C.Checked = True
        End If
        If item.cbx_COURSE_ECheckedValue.Value.Equals(item.cbx_COURSE_E.Value) Then
            NewRecord1cbx_COURSE_E.Checked = True
        End If
        If item.cbx_COURSE_ICheckedValue.Value.Equals(item.cbx_COURSE_I.Value) Then
            NewRecord1cbx_COURSE_I.Checked = True
        End If
        NewRecord1DESCRIPTION_LINE1.Text=item.DESCRIPTION_LINE1.GetFormattedValue()
        NewRecord1DESCRIPTION_LINE2.Text=item.DESCRIPTION_LINE2.GetFormattedValue()
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        NewRecord1STATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(NewRecord1STATUS.Items)
        NewRecord1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        NewRecord1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        NewRecord1hidden_VALID_COURSE_DISTRIBUTION.Value = item.hidden_VALID_COURSE_DISTRIBUTION.GetFormattedValue()
        NewRecord1hidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        NewRecord1hidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        NewRecord1SUBJECT_TITLE_NEW.Text=item.SUBJECT_TITLE_NEW.GetFormattedValue()
        NewRecord1CAMPUS_CODE.Items.Add(new ListItem("Select Value",""))
        NewRecord1CAMPUS_CODE.Items(0).Selected = True
        item.CAMPUS_CODEItems.SetSelection(item.CAMPUS_CODE.GetFormattedValue())
        If Not item.CAMPUS_CODEItems.GetSelectedItem() Is Nothing Then
            NewRecord1CAMPUS_CODE.SelectedIndex = -1
        End If
        item.CAMPUS_CODEItems.CopyTo(NewRecord1CAMPUS_CODE.Items)
        NewRecord1CORE_YEARLEVELS.Items.Add(new ListItem("Not set",""))
        NewRecord1CORE_YEARLEVELS.Items(0).Selected = True
        item.CORE_YEARLEVELSItems.SetSelection(item.CORE_YEARLEVELS.GetFormattedValue())
        If Not item.CORE_YEARLEVELSItems.GetSelectedItem() Is Nothing Then
            NewRecord1CORE_YEARLEVELS.SelectedIndex = -1
        End If
        item.CORE_YEARLEVELSItems.CopyTo(NewRecord1CORE_YEARLEVELS.Items)
        item.rbCORE_SUBJECT_FLAGItems.SetSelection(item.rbCORE_SUBJECT_FLAG.GetFormattedValue())
        NewRecord1rbCORE_SUBJECT_FLAG.SelectedIndex = -1
        item.rbCORE_SUBJECT_FLAGItems.CopyTo(NewRecord1rbCORE_SUBJECT_FLAG.Items)
        NewRecord1LINKED_SUBJECT_ID.Text=item.LINKED_SUBJECT_ID.GetFormattedValue()
        If item.checkEXTENDABLE_SUBJECTCheckedValue.Value.Equals(item.checkEXTENDABLE_SUBJECT.Value) Then
            NewRecord1checkEXTENDABLE_SUBJECT.Checked = True
        End If
        NewRecord1ALLOCATE_STUDENTS_MAX.Text=item.ALLOCATE_STUDENTS_MAX.GetFormattedValue()
        NewRecord1listParentGroupSubject.Items.Add(new ListItem("No grouping (default)","0"))
        item.listParentGroupSubjectItems.SetSelection(item.listParentGroupSubject.GetFormattedValue())
        If Not item.listParentGroupSubjectItems.GetSelectedItem() Is Nothing Then
            NewRecord1listParentGroupSubject.SelectedIndex = -1
        End If
        item.listParentGroupSubjectItems.CopyTo(NewRecord1listParentGroupSubject.Items)
'End Record Form NewRecord1 BeforeShow tail

'TextBox SUBJECT_TITLE Event BeforeShow. Action Retrieve Value for Control @141-8724CE9C
            NewRecord1SUBJECT_TITLE.Text = (New TextField("", (trim(NewRecord1SUBJECT_TITLE.Text)))).GetFormattedValue()
'End TextBox SUBJECT_TITLE Event BeforeShow. Action Retrieve Value for Control

'Record NewRecord1 Event BeforeShow. Action Custom Code @53-73254650
    ' -------------------------
    'ERA: 23 June 2008 - split out the VALID_COURSE_DISTRIBUTION into separate values and tick the checkboxes	
	if instr(item.hidden_valid_course_distribution.value,"B") then
		item.cbx_course_b.value= item.cbx_course_bcheckedvalue.value
		NewRecord1cbx_COURSE_B.Checked = True
	end if
	if instr(item.hidden_valid_course_distribution.value,"C") then
		item.cbx_course_c.value= item.cbx_course_ccheckedvalue.value
		NewRecord1cbx_COURSE_C.Checked = True
	end if
	if instr(item.hidden_valid_course_distribution.value,"E") then
		item.cbx_course_e.value= item.cbx_course_echeckedvalue.value
		NewRecord1cbx_COURSE_E.Checked = True
	end if
	if instr(item.hidden_valid_course_distribution.value,"I") then
		item.cbx_course_i.value= item.cbx_course_icheckedvalue.value
		NewRecord1cbx_COURSE_I.Checked = True
	end if
    ' -------------------------
'End Record NewRecord1 Event BeforeShow. Action Custom Code

'Record Form NewRecord1 Show method tail @29-057F9BB0
        If NewRecord1Errors.Count > 0 Then
            NewRecord1ShowErrors()
        End If
    End Sub
'End Record Form NewRecord1 Show method tail

'Record Form NewRecord1 LoadItemFromRequest method @29-1D354233

    Protected Sub NewRecord1LoadItemFromRequest(item As NewRecord1Item, ByVal EnableValidation As Boolean)
        Try
        item.SUBJECT_ID.IsEmpty = IsNothing(Request.Form(NewRecord1SUBJECT_ID.UniqueID))
        If ControlCustomValues("NewRecord1SUBJECT_ID") Is Nothing Then
            item.SUBJECT_ID.SetValue(NewRecord1SUBJECT_ID.Text)
        Else
            item.SUBJECT_ID.SetValue(ControlCustomValues("NewRecord1SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
        End Try
        item.SUBJECT_ABBREV.IsEmpty = IsNothing(Request.Form(NewRecord1SUBJECT_ABBREV.UniqueID))
        If ControlCustomValues("NewRecord1SUBJECT_ABBREV") Is Nothing Then
            item.SUBJECT_ABBREV.SetValue(NewRecord1SUBJECT_ABBREV.Text)
        Else
            item.SUBJECT_ABBREV.SetValue(ControlCustomValues("NewRecord1SUBJECT_ABBREV"))
        End If
        item.SUBJECT_TITLE.IsEmpty = IsNothing(Request.Form(NewRecord1SUBJECT_TITLE.UniqueID))
        If ControlCustomValues("NewRecord1SUBJECT_TITLE") Is Nothing Then
            item.SUBJECT_TITLE.SetValue(NewRecord1SUBJECT_TITLE.Text)
        Else
            item.SUBJECT_TITLE.SetValue(ControlCustomValues("NewRecord1SUBJECT_TITLE"))
        End If
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(NewRecord1YEAR_LEVEL.UniqueID))
        If ControlCustomValues("NewRecord1YEAR_LEVEL") Is Nothing Then
            item.YEAR_LEVEL.SetValue(NewRecord1YEAR_LEVEL.Text)
        Else
            item.YEAR_LEVEL.SetValue(ControlCustomValues("NewRecord1YEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.DEFAULT_SEMESTER.IsEmpty = IsNothing(Request.Form(NewRecord1DEFAULT_SEMESTER.UniqueID))
        item.DEFAULT_SEMESTER.SetValue(NewRecord1DEFAULT_SEMESTER.Value)
        item.DEFAULT_SEMESTERItems.CopyFrom(NewRecord1DEFAULT_SEMESTER.Items)
        item.DEFAULT_TEACHER_ID.IsEmpty = IsNothing(Request.Form(NewRecord1DEFAULT_TEACHER_ID.UniqueID))
        item.DEFAULT_TEACHER_ID.SetValue(NewRecord1DEFAULT_TEACHER_ID.Value)
        item.DEFAULT_TEACHER_IDItems.CopyFrom(NewRecord1DEFAULT_TEACHER_ID.Items)
        item.SUB_SCHOOL.IsEmpty = IsNothing(Request.Form(NewRecord1SUB_SCHOOL.UniqueID))
        If ControlCustomValues("NewRecord1SUB_SCHOOL") Is Nothing Then
            item.SUB_SCHOOL.SetValue(NewRecord1SUB_SCHOOL.Text)
        Else
            item.SUB_SCHOOL.SetValue(ControlCustomValues("NewRecord1SUB_SCHOOL"))
        End If
        Try
        item.KLA_ID.IsEmpty = IsNothing(Request.Form(NewRecord1KLA_ID.UniqueID))
        item.KLA_ID.SetValue(NewRecord1KLA_ID.Value)
        item.KLA_IDItems.CopyFrom(NewRecord1KLA_ID.Items)
        Catch ae As ArgumentException
            NewRecord1Errors.Add("KLA_ID",String.Format(Resources.strings.CCS_IncorrectValue,"KLA ID"))
        End Try
        Try
        item.CSF_CLASS_LEVEL.IsEmpty = IsNothing(Request.Form(NewRecord1CSF_CLASS_LEVEL.UniqueID))
        If ControlCustomValues("NewRecord1CSF_CLASS_LEVEL") Is Nothing Then
            item.CSF_CLASS_LEVEL.SetValue(NewRecord1CSF_CLASS_LEVEL.Text)
        Else
            item.CSF_CLASS_LEVEL.SetValue(ControlCustomValues("NewRecord1CSF_CLASS_LEVEL"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("CSF_CLASS_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"CSF CLASS LEVEL"))
        End Try
        Try
        item.MAX_BOOKS.IsEmpty = IsNothing(Request.Form(NewRecord1MAX_BOOKS.UniqueID))
        If ControlCustomValues("NewRecord1MAX_BOOKS") Is Nothing Then
            item.MAX_BOOKS.SetValue(NewRecord1MAX_BOOKS.Text)
        Else
            item.MAX_BOOKS.SetValue(ControlCustomValues("NewRecord1MAX_BOOKS"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("MAX_BOOKS",String.Format(Resources.strings.CCS_IncorrectValue,"MAX BOOKS"))
        End Try
        If NewRecord1cbx_COURSE_B.Checked Then
            item.cbx_COURSE_B.Value = (item.cbx_COURSE_BCheckedValue.Value)
        Else
            item.cbx_COURSE_B.Value = (item.cbx_COURSE_BUncheckedValue.Value)
        End If
        If NewRecord1cbx_COURSE_C.Checked Then
            item.cbx_COURSE_C.Value = (item.cbx_COURSE_CCheckedValue.Value)
        Else
            item.cbx_COURSE_C.Value = (item.cbx_COURSE_CUncheckedValue.Value)
        End If
        If NewRecord1cbx_COURSE_E.Checked Then
            item.cbx_COURSE_E.Value = (item.cbx_COURSE_ECheckedValue.Value)
        Else
            item.cbx_COURSE_E.Value = (item.cbx_COURSE_EUncheckedValue.Value)
        End If
        If NewRecord1cbx_COURSE_I.Checked Then
            item.cbx_COURSE_I.Value = (item.cbx_COURSE_ICheckedValue.Value)
        Else
            item.cbx_COURSE_I.Value = (item.cbx_COURSE_IUncheckedValue.Value)
        End If
        item.DESCRIPTION_LINE1.IsEmpty = IsNothing(Request.Form(NewRecord1DESCRIPTION_LINE1.UniqueID))
        If ControlCustomValues("NewRecord1DESCRIPTION_LINE1") Is Nothing Then
            item.DESCRIPTION_LINE1.SetValue(NewRecord1DESCRIPTION_LINE1.Text)
        Else
            item.DESCRIPTION_LINE1.SetValue(ControlCustomValues("NewRecord1DESCRIPTION_LINE1"))
        End If
        item.DESCRIPTION_LINE2.IsEmpty = IsNothing(Request.Form(NewRecord1DESCRIPTION_LINE2.UniqueID))
        If ControlCustomValues("NewRecord1DESCRIPTION_LINE2") Is Nothing Then
            item.DESCRIPTION_LINE2.SetValue(NewRecord1DESCRIPTION_LINE2.Text)
        Else
            item.DESCRIPTION_LINE2.SetValue(ControlCustomValues("NewRecord1DESCRIPTION_LINE2"))
        End If
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(NewRecord1STATUS.UniqueID))
        If Not IsNothing(NewRecord1STATUS.SelectedItem) Then
            item.STATUS.SetValue(NewRecord1STATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(NewRecord1STATUS.Items)
        Catch ae As ArgumentException
            NewRecord1Errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        item.hidden_VALID_COURSE_DISTRIBUTION.IsEmpty = IsNothing(Request.Form(NewRecord1hidden_VALID_COURSE_DISTRIBUTION.UniqueID))
        item.hidden_VALID_COURSE_DISTRIBUTION.SetValue(NewRecord1hidden_VALID_COURSE_DISTRIBUTION.Value)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(NewRecord1hidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(NewRecord1hidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(NewRecord1hidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(NewRecord1hidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            NewRecord1Errors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","yyyy-mm-dd H:nn"))
        End Try
        item.SUBJECT_TITLE_NEW.IsEmpty = IsNothing(Request.Form(NewRecord1SUBJECT_TITLE_NEW.UniqueID))
        If ControlCustomValues("NewRecord1SUBJECT_TITLE_NEW") Is Nothing Then
            item.SUBJECT_TITLE_NEW.SetValue(NewRecord1SUBJECT_TITLE_NEW.Text)
        Else
            item.SUBJECT_TITLE_NEW.SetValue(ControlCustomValues("NewRecord1SUBJECT_TITLE_NEW"))
        End If
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(NewRecord1CAMPUS_CODE.UniqueID))
        item.CAMPUS_CODE.SetValue(NewRecord1CAMPUS_CODE.Value)
        item.CAMPUS_CODEItems.CopyFrom(NewRecord1CAMPUS_CODE.Items)
        item.CORE_YEARLEVELS.IsEmpty = IsNothing(Request.Form(NewRecord1CORE_YEARLEVELS.UniqueID))
        item.CORE_YEARLEVELS.SetValue(NewRecord1CORE_YEARLEVELS.Value)
        item.CORE_YEARLEVELSItems.CopyFrom(NewRecord1CORE_YEARLEVELS.Items)
        item.rbCORE_SUBJECT_FLAG.IsEmpty = IsNothing(Request.Form(NewRecord1rbCORE_SUBJECT_FLAG.UniqueID))
        If Not IsNothing(NewRecord1rbCORE_SUBJECT_FLAG.SelectedItem) Then
            item.rbCORE_SUBJECT_FLAG.SetValue(NewRecord1rbCORE_SUBJECT_FLAG.SelectedItem.Value)
        Else
            item.rbCORE_SUBJECT_FLAG.Value = Nothing
        End If
        item.rbCORE_SUBJECT_FLAGItems.CopyFrom(NewRecord1rbCORE_SUBJECT_FLAG.Items)
        Try
        item.LINKED_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(NewRecord1LINKED_SUBJECT_ID.UniqueID))
        If ControlCustomValues("NewRecord1LINKED_SUBJECT_ID") Is Nothing Then
            item.LINKED_SUBJECT_ID.SetValue(NewRecord1LINKED_SUBJECT_ID.Text)
        Else
            item.LINKED_SUBJECT_ID.SetValue(ControlCustomValues("NewRecord1LINKED_SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("LINKED_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"LINKED SUBJECT ID"))
        End Try
        If NewRecord1checkEXTENDABLE_SUBJECT.Checked Then
            item.checkEXTENDABLE_SUBJECT.Value = (item.checkEXTENDABLE_SUBJECTCheckedValue.Value)
        Else
            item.checkEXTENDABLE_SUBJECT.Value = (item.checkEXTENDABLE_SUBJECTUncheckedValue.Value)
        End If
        Try
        item.ALLOCATE_STUDENTS_MAX.IsEmpty = IsNothing(Request.Form(NewRecord1ALLOCATE_STUDENTS_MAX.UniqueID))
        If ControlCustomValues("NewRecord1ALLOCATE_STUDENTS_MAX") Is Nothing Then
            item.ALLOCATE_STUDENTS_MAX.SetValue(NewRecord1ALLOCATE_STUDENTS_MAX.Text)
        Else
            item.ALLOCATE_STUDENTS_MAX.SetValue(ControlCustomValues("NewRecord1ALLOCATE_STUDENTS_MAX"))
        End If
        Catch ae As ArgumentException
            NewRecord1Errors.Add("ALLOCATE_STUDENTS_MAX",String.Format(Resources.strings.CCS_IncorrectFormat,"MAX STUDENT_ALLOCATION","0;(0)"))
        End Try
        Try
        item.listParentGroupSubject.IsEmpty = IsNothing(Request.Form(NewRecord1listParentGroupSubject.UniqueID))
        item.listParentGroupSubject.SetValue(NewRecord1listParentGroupSubject.Value)
        item.listParentGroupSubjectItems.CopyFrom(NewRecord1listParentGroupSubject.Items)
        Catch ae As ArgumentException
            NewRecord1Errors.Add("listParentGroupSubject",String.Format(Resources.strings.CCS_IncorrectValue,"Parent / Full Year Grouping"))
        End Try
        If EnableValidation Then
            item.Validate(NewRecord1Data)
        End If
        NewRecord1Errors.Add(item.errors)
    End Sub
'End Record Form NewRecord1 LoadItemFromRequest method

'Record Form NewRecord1 GetRedirectUrl method @29-A0F57816

    Protected Function GetNewRecord1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form NewRecord1 GetRedirectUrl method

'Record Form NewRecord1 ShowErrors method @29-7E438983

    Protected Sub NewRecord1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To NewRecord1Errors.Count - 1
        Select Case NewRecord1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & NewRecord1Errors(i)
        End Select
        Next i
        NewRecord1Error.Visible = True
        NewRecord1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form NewRecord1 ShowErrors method

'Record Form NewRecord1 Insert Operation @29-8D873598

    Protected Sub NewRecord1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        Dim ExecuteFlag As Boolean = True
        NewRecord1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewRecord1 Insert Operation

'Button Button_Insert OnClick. @30-9D14A7FE
        If CType(sender,Control).ID = "NewRecord1Button_Insert" Then
            RedirectUrl = GetNewRecord1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @30-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form NewRecord1 BeforeInsert tail @29-EC09CF6D
    NewRecord1Parameters()
    NewRecord1LoadItemFromRequest(item, EnableValidation)
    If NewRecord1Operations.AllowInsert Then
        ErrorFlag=(NewRecord1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                NewRecord1Data.InsertItem(item)
            Catch ex As Exception
                NewRecord1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form NewRecord1 BeforeInsert tail

'Record NewRecord1 Event AfterInsert. Action Save Variable Value @176-A7EBABD6
        HttpContext.Current.Session("notifymessage") = "Item has been Added"
'End Record NewRecord1 Event AfterInsert. Action Save Variable Value

'Record Form NewRecord1 AfterInsert tail  @29-7400E42E
        End If
        ErrorFlag=(NewRecord1Errors.Count > 0)
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewRecord1 AfterInsert tail 

'Record Form NewRecord1 Update Operation @29-BA55B91E

    Protected Sub NewRecord1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewRecord1 Update Operation

'Button Button_Update OnClick. @31-2B75EB7C
        If CType(sender,Control).ID = "NewRecord1Button_Update" Then
            RedirectUrl = GetNewRecord1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @31-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record NewRecord1 Event BeforeUpdate. Action Retrieve Value for Control @138-EB5740F3
        NewRecord1hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserId.ToUpper))).GetFormattedValue()
'End Record NewRecord1 Event BeforeUpdate. Action Retrieve Value for Control

'Record NewRecord1 Event BeforeUpdate. Action Retrieve Value for Control @139-7516BB66
        NewRecord1hidden_LAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record NewRecord1 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form NewRecord1 Before Update tail @29-06CD2447
        NewRecord1Parameters()
        NewRecord1LoadItemFromRequest(item, EnableValidation)
        If NewRecord1Operations.AllowUpdate Then
        ErrorFlag = (NewRecord1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                NewRecord1Data.UpdateItem(item)
            Catch ex As Exception
                NewRecord1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form NewRecord1 Before Update tail

'Record NewRecord1 Event AfterUpdate. Action Custom Code @135-73254650
    ' -------------------------
    'ERA: 27-Feb-2012|EA| per unfuddle #428, send email to PCSupport advising that an update has been made on the Subject
	'	form (and to the Subject data) which might affect Janison depending on what changed)
	' Code from codecharge help "Enhancing Application Functionality with Programming Events (C# and VB.Net)" Step 4.
	'ERA: 30-May-2014|EA| found error upon sending email, which didn't get caught in 2013 updates
	
	If ExecuteFlag And (Not ErrorFlag) Then 
  		'ERA: 30-May-2014|EA| replace the entire email sending section because why would .NET make the updates compatible??????
	
	'	Dim newMessage As New System.Web.Mail.MailMessage()
	'	newMessage.From = "reports@distance.vic.edu.au"
	'	newMessage.To = "pcsupport@distance.vic.edu.au"
	'	newMessage.Subject = "Auto Student DB Advice - Changes made to Subjects!"
	'	newMessage.BodyFormat = System.Web.Mail.MailFormat.Html
	'	newMessage.Body = "This Subject has been <em>updated</em> in the Student Admin Database.<br><br> " & _
	'		"<br />Subject Abbrev/ID : <strong>" & item.subject_abbrev.getformattedvalue & " / " & item.subject_id.getformattedvalue & "</strong>" & _
	'		"<br />Subject Title : <strong>" & item.subject_title.getformattedvalue & "</strong>" & _
	'		"<br />Status (Active?) : <strong>" & item.status.getformattedvalue & "</strong>" & _
	'		"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
	'		"<br /><em>Note: This information does not reflect the actual field(s) updated, just that the Subject has been updated. Even just clicking 'Update' without changing anything.</em>" & _
	' 		"<br><br>---- that is all ----"
	'	' send to the internal DECV Exchange Server - MADE GENERIC April 2012
	'	System.Web.Mail.SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings("smtp_servername")
	'	System.Web.Mail.SmtpMail.Send(newMessage)
		
		Dim MessageFrom As String = "reports@vsv.vic.edu.au"
		Dim MessageTo As String = "pcsupport@vsv.vic.edu.au"
		
		Dim MessageSubject As String = "Auto Student DB Advice - Changes made to Subjects!"
		Dim MessageBody As String = "This Subject has been <em>updated</em> in the Student Admin Database.<br><br> " & _
				"<br />Subject Abbrev/ID : <strong>" & item.subject_abbrev.getformattedvalue & " / " & item.subject_id.getformattedvalue & "</strong>" & _
				"<br />Subject Title : <strong>" & item.subject_title.getformattedvalue & "</strong>" & _
				"<br />Status (Active?) : <strong>" & item.status.getformattedvalue & "</strong>" & _
				"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
				"<br /><em>Note: This information does not reflect the actual field(s) updated, just that the Subject has been updated. Even just clicking 'Update' without changing anything.</em>" & _
		 		"<br><br>---- that is all ----"
			
		Dim TestEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
        TestEmail.IsBodyHtml = True
        Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
        EmailServer.Send(TestEmail)
		
	End If

    ' -------------------------
'End Record NewRecord1 Event AfterUpdate. Action Custom Code

'Record NewRecord1 Event AfterUpdate. Action Save Variable Value @165-B862AFBC
        HttpContext.Current.Session("notifymessage") = "Item has been Updated"
'End Record NewRecord1 Event AfterUpdate. Action Save Variable Value

'Record Form NewRecord1 Update Operation tail @29-7400E42E
        End If
        ErrorFlag=(NewRecord1Errors.Count > 0)
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewRecord1 Update Operation tail

'Record Form NewRecord1 Delete Operation @29-5A13493F
    Protected Sub NewRecord1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As NewRecord1Item = New NewRecord1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form NewRecord1 Delete Operation

'Record Form BeforeDelete tail @29-9F2E905D
        NewRecord1Parameters()
        NewRecord1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @29-FCE96B73
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form NewRecord1 Cancel Operation @29-6ED935D6

    Protected Sub NewRecord1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        NewRecord1LoadItemFromRequest(item, False)
'End Record Form NewRecord1 Cancel Operation

'Button Button_Cancel OnClick. @32-7446A70B
    If CType(sender,Control).ID = "NewRecord1Button_Cancel" Then
        RedirectUrl = GetNewRecord1RedirectUrl("SUBJECT_list.aspx", "SUBJECT_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @32-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form NewRecord1 Cancel Operation tail @29-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form NewRecord1 Cancel Operation tail

'EditableGrid SUBJECT_TEACHER Bind @96-66675767
    Protected Sub SUBJECT_TEACHERBind()
        If SUBJECT_TEACHEROperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT_TEACHER",GetType(SUBJECT_TEACHERDataProvider.SortFields), 10, 100)
        End If
'End EditableGrid SUBJECT_TEACHER Bind

'EditableGrid Form SUBJECT_TEACHER BeforeShow tail @96-2B52708A
        SUBJECT_TEACHERParameters()
        SUBJECT_TEACHERData.SortField = CType(ViewState("SUBJECT_TEACHERSortField"), SUBJECT_TEACHERDataProvider.SortFields)
        SUBJECT_TEACHERData.SortDir = CType(ViewState("SUBJECT_TEACHERSortDir"), SortDirections)
        SUBJECT_TEACHERData.PageNumber = CType(ViewState("SUBJECT_TEACHERPageNumber"), Integer)
        SUBJECT_TEACHERData.RecordsPerPage = CType(ViewState("SUBJECT_TEACHERPageSize"), Integer)
        SUBJECT_TEACHERRepeater.DataSource = SUBJECT_TEACHERData.GetResultSet(PagesCount, SUBJECT_TEACHEROperations)
        ViewState("SUBJECT_TEACHERPagesCount") = PagesCount
        ViewState("SUBJECT_TEACHERFormState") = New Hashtable()
        ViewState("SUBJECT_TEACHERRowState") = New Hashtable()
        SUBJECT_TEACHERRepeater.DataBind()
        Dim item As SUBJECT_TEACHERItem = SUBJECT_TEACHERDataItem
        If IsNothing(item) Then item = New SUBJECT_TEACHERItem()
        FooterIndex = SUBJECT_TEACHERRepeater.Controls.Count - 1
        Dim Script As Literal = CType(SUBJECT_TEACHERRepeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(SUBJECT_TEACHERRepeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var SUBJECT_TEACHERStaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "SUBJECT_TEACHERStaticElementsID = new Array ("
        Elements.Text += "var SUBJECT_TEACHERButton_SubmitID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + SUBJECT_TEACHERRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHERButton_Submit").ClientID + """),"
        Elements.Text += "var SUBJECT_TEACHERCancelID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + SUBJECT_TEACHERRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHERCancel").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Dim SUBJECT_TEACHERButton_Submit As System.Web.UI.WebControls.Button = DirectCast(SUBJECT_TEACHERRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHERButton_Submit"),System.Web.UI.WebControls.Button)
        Dim SUBJECT_TEACHERCancel As System.Web.UI.WebControls.Button = DirectCast(SUBJECT_TEACHERRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHERCancel"),System.Web.UI.WebControls.Button)


        SUBJECT_TEACHERButton_Submit.Visible = SUBJECT_TEACHEROperations.Editable
        If Not CType(SUBJECT_TEACHERRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            SUBJECT_TEACHERRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If SUBJECT_TEACHERErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(SUBJECT_TEACHERRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(SUBJECT_TEACHERRepeater.Controls(0).FindControl("SUBJECT_TEACHERError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In SUBJECT_TEACHERErrors
                ErrorLabel.Text += SUBJECT_TEACHERErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form SUBJECT_TEACHER BeforeShow tail

'EditableGrid SUBJECT_TEACHER Bind tail @96-3048D8B5
        SUBJECT_TEACHERShowErrors(New ArrayList(CType(SUBJECT_TEACHERRepeater.DataSource, ICollection)), SUBJECT_TEACHERRepeater.Items)
    End Sub
'End EditableGrid SUBJECT_TEACHER Bind tail

'EditableGrid SUBJECT_TEACHER Table Parameters @96-C18D591F
    Protected Sub SUBJECT_TEACHERParameters()
        Try
        Dim item As new SUBJECT_TEACHERItem
            SUBJECT_TEACHERData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = SUBJECT_TEACHERRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(SUBJECT_TEACHERRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid SUBJECT_TEACHER: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid SUBJECT_TEACHER Table Parameters

'EditableGrid SUBJECT_TEACHER ItemDataBound event @96-18EDDBFF
    Protected Sub SUBJECT_TEACHERItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As SUBJECT_TEACHERItem = DirectCast(e.Item.DataItem, SUBJECT_TEACHERItem)
        Dim Item as SUBJECT_TEACHERItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECT_TEACHERCurrentRowNumber = SUBJECT_TEACHERCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHERFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHERRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            formState.Add("STAFF_IDField:" & e.Item.ItemIndex, DataItem.STAFF_IDField.Value)
            ViewState(e.Item.FindControl("SUBJECT_TEACHERlblLAST_ALTERED_BY").UniqueID) = DataItem.lblLAST_ALTERED_BY.Value
            ViewState(e.Item.FindControl("SUBJECT_TEACHERlblLAST_ALTERED_DATE").UniqueID) = DataItem.lblLAST_ALTERED_DATE.Value
            Dim SUBJECT_TEACHERSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("SUBJECT_TEACHERSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim SUBJECT_TEACHERSUBJECT_TIMEFRACTION As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("SUBJECT_TEACHERSUBJECT_TIMEFRACTION"),System.Web.UI.WebControls.TextBox)
            Dim SUBJECT_TEACHERALLOCATABLE_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("SUBJECT_TEACHERALLOCATABLE_FLAG"),System.Web.UI.WebControls.RadioButtonList)
            Dim SUBJECT_TEACHERCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("SUBJECT_TEACHERCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim SUBJECT_TEACHERLAST_ALTERED_BY As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERLAST_ALTERED_BY"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim SUBJECT_TEACHERlblLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHERlblLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHERSUBJECT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERSUBJECT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim SUBJECT_TEACHERlblLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHERlblLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHERLAST_ALTERED_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERLAST_ALTERED_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
            CType(Page,CCPage).ControlAttributes.Add(SUBJECT_TEACHERRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECT_TEACHERCurrentRowNumber), AttributeOption.Multiple)
            SUBJECT_TEACHERSTAFF_ID.Items.Add(new ListItem("Select Value",""))
            SUBJECT_TEACHERSTAFF_ID.Items(0).Selected = True
            DataItem.STAFF_IDItems.SetSelection(DataItem.STAFF_ID.GetFormattedValue())
            If Not DataItem.STAFF_IDItems.GetSelectedItem() Is Nothing Then
                SUBJECT_TEACHERSTAFF_ID.SelectedIndex = -1
            End If
            DataItem.STAFF_IDItems.CopyTo(SUBJECT_TEACHERSTAFF_ID.Items)
            DataItem.ALLOCATABLE_FLAGItems.SetSelection(DataItem.ALLOCATABLE_FLAG.GetFormattedValue())
            SUBJECT_TEACHERALLOCATABLE_FLAG.SelectedIndex = -1
            DataItem.ALLOCATABLE_FLAGItems.CopyTo(SUBJECT_TEACHERALLOCATABLE_FLAG.Items)
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                SUBJECT_TEACHERCheckBox_Delete.Checked = True
            End If
        End If
'End EditableGrid SUBJECT_TEACHER ItemDataBound event

'SUBJECT_TEACHER control Before Show @96-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End SUBJECT_TEACHER control Before Show

'Get Control @113-BF3532EE
            Dim SUBJECT_TEACHERALLOCATABLE_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("SUBJECT_TEACHERALLOCATABLE_FLAG"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton ALLOCATABLE_FLAG Event BeforeShow. Action Custom Code @124-73254650
    ' -------------------------
    'ERA: make it nice and vertical
	SUBJECT_TEACHERALLOCATABLE_FLAG.RepeatDirection = RepeatDirection.Vertical
    ' -------------------------
'End RadioButton ALLOCATABLE_FLAG Event BeforeShow. Action Custom Code

'Get Control @114-DECC6B50
            Dim SUBJECT_TEACHERLAST_ALTERED_BY As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERLAST_ALTERED_BY"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control @128-E9DB05A1
            SUBJECT_TEACHERLAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control

'Get Control @110-09F5BA93
            Dim SUBJECT_TEACHERSUBJECT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERSUBJECT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden SUBJECT_ID Event BeforeShow. Action Retrieve Value for Control @127-4D826422
            SUBJECT_TEACHERSUBJECT_ID.Value = (New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("SUBJECT_ID"))).GetFormattedValue()
'End Hidden SUBJECT_ID Event BeforeShow. Action Retrieve Value for Control

'Get Control @115-FA4ECFC7
            Dim SUBJECT_TEACHERLAST_ALTERED_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHERLAST_ALTERED_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control @129-52B2E3DE
            SUBJECT_TEACHERLAST_ALTERED_DATE.Value = (New DateField(Settings.DateFormat, (Now()))).GetFormattedValue()
'End Hidden LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control

'SUBJECT_TEACHER control Before Show tail @96-477CF3C9
        End If
'End SUBJECT_TEACHER control Before Show tail

'EditableGrid SUBJECT_TEACHER BeforeShowRow event @96-0B9500A9
        If Not IsNothing(Item) Then SUBJECT_TEACHERDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid SUBJECT_TEACHER BeforeShowRow event

'DEL      ' -------------------------
'DEL      'ERA: change colour of row depending on if the Teacher can be allocated to
'DEL      
'DEL      Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("teacher_row"),System.Web.UI.HtmlControls.HtmlTableRow)
'DEL  
'DEL  	If (SUBJECT_TEACHERDataItem.ALLOCATABLE_FLAG.value = "0") Then
'DEL        comment_row.Attributes("Class") = "AltRow"
'DEL      Else
'DEL        comment_row.Attributes("Class") = "Row"
'DEL      End if 
'DEL  
'DEL      ' -------------------------


'EditableGrid SUBJECT_TEACHER BeforeShowRow event tail @96-477CF3C9
        End If
'End EditableGrid SUBJECT_TEACHER BeforeShowRow event tail

'EditableGrid SUBJECT_TEACHER ItemDataBound event tail @96-E31F8E2A
    End Sub
'End EditableGrid SUBJECT_TEACHER ItemDataBound event tail

'EditableGrid SUBJECT_TEACHER GetRedirectUrl method @96-35D2C5C3
    Protected Function GetSUBJECT_TEACHERRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetSUBJECT_TEACHERRedirectUrl(ByVal redirectString As String) As String
        Return GetSUBJECT_TEACHERRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid SUBJECT_TEACHER GetRedirectUrl method

'EditableGrid SUBJECT_TEACHER ShowErrors method @96-AD894DD4
    Protected Function SUBJECT_TEACHERShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), SUBJECT_TEACHERItem).IsUpdated Then col(CType(items(i), SUBJECT_TEACHERItem).RowId).Visible = False
            If (CType(items(i), SUBJECT_TEACHERItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), SUBJECT_TEACHERItem).errors.Count - 1
                Select CType(items(i), SUBJECT_TEACHERItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), SUBJECT_TEACHERItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), SUBJECT_TEACHERItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), SUBJECT_TEACHERItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid SUBJECT_TEACHER ShowErrors method

'EditableGrid SUBJECT_TEACHER ItemCommand event @96-B2B50FFD
    Protected Sub SUBJECT_TEACHERItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = SUBJECT_TEACHERRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid SUBJECT_TEACHER ItemCommand event

'Button Button_Submit OnClick. @117-27C07436
        If Ctype(e.CommandSource,Control).ID = "SUBJECT_TEACHERButton_Submit" Then
            RedirectUrl  = GetSUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @117-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @119-4281793A
        If Ctype(e.CommandSource,Control).ID = "SUBJECT_TEACHERCancel" Then
            RedirectUrl  = GetSUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @119-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form SUBJECT_TEACHER ItemCommand event tail @96-17C6DAEE
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("SUBJECT_TEACHERSortDir"), SortDirections) = SortDirections._Asc And ViewState("SUBJECT_TEACHERSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("SUBJECT_TEACHERSortDir") = SortDirections._Desc
                Else
                    ViewState("SUBJECT_TEACHERSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("SUBJECT_TEACHERSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As SUBJECT_TEACHERDataProvider.SortFields = 0
            ViewState("SUBJECT_TEACHERSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("SUBJECT_TEACHERPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("SUBJECT_TEACHERPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("SUBJECT_TEACHERPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECT_TEACHERPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            SUBJECT_TEACHERIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = SUBJECT_TEACHERRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHERFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHERRowState"), Hashtable)
            SUBJECT_TEACHERParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim SUBJECT_TEACHERSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("SUBJECT_TEACHERSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim SUBJECT_TEACHERSUBJECT_TIMEFRACTION As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("SUBJECT_TEACHERSUBJECT_TIMEFRACTION"),System.Web.UI.WebControls.TextBox)
                    Dim SUBJECT_TEACHERALLOCATABLE_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("SUBJECT_TEACHERALLOCATABLE_FLAG"),System.Web.UI.WebControls.RadioButtonList)
                    Dim SUBJECT_TEACHERCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("SUBJECT_TEACHERCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim SUBJECT_TEACHERLAST_ALTERED_BY As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHERLAST_ALTERED_BY"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim SUBJECT_TEACHERlblLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHERlblLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHERSUBJECT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHERSUBJECT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim SUBJECT_TEACHERlblLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHERlblLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHERLAST_ALTERED_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHERLAST_ALTERED_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.STAFF_IDField.Value = formState("STAFF_IDField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("SUBJECT_TEACHERCheckBox_Delete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.lblLAST_ALTERED_BY.Value = ViewState(SUBJECT_TEACHERlblLAST_ALTERED_BY.UniqueID)
                    item.lblLAST_ALTERED_DATE.Value = ViewState(SUBJECT_TEACHERlblLAST_ALTERED_DATE.UniqueID)
                    item.STAFF_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSTAFF_ID.UniqueID))
                    item.STAFF_ID.SetValue(SUBJECT_TEACHERSTAFF_ID.Value)
                    item.STAFF_IDItems.CopyFrom(SUBJECT_TEACHERSTAFF_ID.Items)
                    Try
                    item.SUBJECT_TIMEFRACTION.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSUBJECT_TIMEFRACTION.UniqueID))
                    If ControlCustomValues("SUBJECT_TEACHERSUBJECT_TIMEFRACTION") Is Nothing Then
                        item.SUBJECT_TIMEFRACTION.SetValue(SUBJECT_TEACHERSUBJECT_TIMEFRACTION.Text)
                    Else
                        item.SUBJECT_TIMEFRACTION.SetValue(ControlCustomValues("SUBJECT_TEACHERSUBJECT_TIMEFRACTION"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("SUBJECT_TIMEFRACTION",String.Format(Resources.strings.CCS_IncorrectFormat,"SUBJECT TIMEFRACTION","0.00"))
                    End Try
                    Try
                    item.ALLOCATABLE_FLAG.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERALLOCATABLE_FLAG.UniqueID))
                    If Not IsNothing(SUBJECT_TEACHERALLOCATABLE_FLAG.SelectedItem) Then
                        item.ALLOCATABLE_FLAG.SetValue(SUBJECT_TEACHERALLOCATABLE_FLAG.SelectedItem.Value)
                    Else
                        item.ALLOCATABLE_FLAG.Value = Nothing
                    End If
                    item.ALLOCATABLE_FLAGItems.CopyFrom(SUBJECT_TEACHERALLOCATABLE_FLAG.Items)
                    Catch ex As ArgumentException
                    item.errors.Add("ALLOCATABLE_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"ALLOCATABLE FLAG"))
                    End Try
                    item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERLAST_ALTERED_BY.UniqueID))
                    item.LAST_ALTERED_BY.SetValue(SUBJECT_TEACHERLAST_ALTERED_BY.Value)
                    Try
                    item.SUBJECT_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSUBJECT_ID.UniqueID))
                    item.SUBJECT_ID.SetValue(SUBJECT_TEACHERSUBJECT_ID.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
                    End Try
                    Try
                    item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERLAST_ALTERED_DATE.UniqueID))
                    item.LAST_ALTERED_DATE.SetValue(SUBJECT_TEACHERLAST_ALTERED_DATE.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(SUBJECT_TEACHERData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form SUBJECT_TEACHER ItemCommand event tail

'EditableGrid SUBJECT_TEACHER Update @96-1A57FD6D
            If BindAllowed Then
                Try
                    SUBJECT_TEACHERParameters()
                    SUBJECT_TEACHERData.Update(items, SUBJECT_TEACHEROperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(SUBJECT_TEACHERRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(SUBJECT_TEACHERRepeater.Controls(0).FindControl("SUBJECT_TEACHERError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid SUBJECT_TEACHER Update

'EditableGrid SUBJECT_TEACHER After Update @96-56E24EE7
                End Try
                If SUBJECT_TEACHERShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                SUBJECT_TEACHERShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                SUBJECT_TEACHERBind()
            End If
        End Sub
'End EditableGrid SUBJECT_TEACHER After Update

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-47D6BEA5
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SUBJECT_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        NewRecord1Data = New NewRecord1DataProvider()
        NewRecord1Operations = New FormSupportedOperations(False, True, True, True, False)
        SUBJECT_TEACHERData = New SUBJECT_TEACHERDataProvider()
        SUBJECT_TEACHEROperations = New FormSupportedOperations(False, True, True, True, True)
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

