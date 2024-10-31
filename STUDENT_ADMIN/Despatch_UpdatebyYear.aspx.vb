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

Namespace DECV_PROD2007.Despatch_UpdatebyYear 'Namespace @1-CC8ED6E9

'Forms Definition @1-99CC554E
Public Class [Despatch_UpdatebyYearPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-4E0095CD
    Protected SUBJECTSearchData As SUBJECTSearchDataProvider
    Protected SUBJECTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECTSearchOperations As FormSupportedOperations
    Protected SUBJECTSearchIsSubmitted As Boolean = False
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTCurrentRowNumber As Integer
    Protected Despatch_UpdatebyYearContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CB4C26FF
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECTSearchShow()
            UpdateFormShow()
            SUBJECTBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SUBJECTSearch Parameters @8-0DBBE141

    Protected Sub SUBJECTSearchParameters()
        Dim item As new SUBJECTSearchItem
        Try
        Catch e As Exception
            SUBJECTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECTSearch Parameters

'Record Form SUBJECTSearch Show method @8-3B0884E5
    Protected Sub SUBJECTSearchShow()
        If SUBJECTSearchOperations.None Then
            SUBJECTSearchHolder.Visible = False
            Return
        End If
        Dim item As SUBJECTSearchItem = SUBJECTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECTSearchOperations.AllowRead
        SUBJECTSearchErrors.Add(item.errors)
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
            Return
        End If
'End Record Form SUBJECTSearch Show method

'Record Form SUBJECTSearch BeforeShow tail @8-3D245F11
        SUBJECTSearchParameters()
        SUBJECTSearchData.FillItem(item, IsInsertMode)
        SUBJECTSearchHolder.DataBind()
        SUBJECTSearchs_YEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        SUBJECTSearchs_YEAR_LEVEL.Items(0).Selected = True
        item.s_YEAR_LEVELItems.SetSelection(item.s_YEAR_LEVEL.GetFormattedValue())
        If Not item.s_YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            SUBJECTSearchs_YEAR_LEVEL.SelectedIndex = -1
        End If
        item.s_YEAR_LEVELItems.CopyTo(SUBJECTSearchs_YEAR_LEVEL.Items)
'End Record Form SUBJECTSearch BeforeShow tail

'Record Form SUBJECTSearch Show method tail @8-2B15C3B5
        If SUBJECTSearchErrors.Count > 0 Then
            SUBJECTSearchShowErrors()
        End If
    End Sub
'End Record Form SUBJECTSearch Show method tail

'Record Form SUBJECTSearch LoadItemFromRequest method @8-66214D85

    Protected Sub SUBJECTSearchLoadItemFromRequest(item As SUBJECTSearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(SUBJECTSearchs_YEAR_LEVEL.UniqueID))
        item.s_YEAR_LEVEL.SetValue(SUBJECTSearchs_YEAR_LEVEL.Value)
        item.s_YEAR_LEVELItems.CopyFrom(SUBJECTSearchs_YEAR_LEVEL.Items)
        Catch ae As ArgumentException
            SUBJECTSearchErrors.Add("s_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"s_YEAR_LEVEL"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECTSearchData)
        End If
        SUBJECTSearchErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECTSearch LoadItemFromRequest method

'Record Form SUBJECTSearch GetRedirectUrl method @8-6F6A32A2

    Protected Function GetSUBJECTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Despatch_UpdatebyYear.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECTSearch GetRedirectUrl method

'Record Form SUBJECTSearch ShowErrors method @8-1BBB8726

    Protected Sub SUBJECTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECTSearchErrors.Count - 1
        Select Case SUBJECTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECTSearchErrors(i)
        End Select
        Next i
        SUBJECTSearchError.Visible = True
        SUBJECTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECTSearch ShowErrors method

'Record Form SUBJECTSearch Insert Operation @8-33FDEC64

    Protected Sub SUBJECTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Insert Operation

'Record Form SUBJECTSearch BeforeInsert tail @8-8EC67B0F
    SUBJECTSearchParameters()
    SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch BeforeInsert tail

'Record Form SUBJECTSearch AfterInsert tail  @8-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch AfterInsert tail 

'Record Form SUBJECTSearch Update Operation @8-CEA8EC00

    Protected Sub SUBJECTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECTSearch Update Operation

'Record Form SUBJECTSearch Before Update tail @8-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Before Update tail

'Record Form SUBJECTSearch Update Operation tail @8-442D8E1A
        ErrorFlag=(SUBJECTSearchErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECTSearch Update Operation tail

'Record Form SUBJECTSearch Delete Operation @8-7B81E740
    Protected Sub SUBJECTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECTSearch Delete Operation

'Record Form BeforeDelete tail @8-8EC67B0F
        SUBJECTSearchParameters()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @8-D8B6C6AE
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECTSearch Cancel Operation @8-2C955275

    Protected Sub SUBJECTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECTSearchLoadItemFromRequest(item, True)
'End Record Form SUBJECTSearch Cancel Operation

'Record Form SUBJECTSearch Cancel Operation tail @8-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECTSearch Cancel Operation tail

'Record Form SUBJECTSearch Search Operation @8-8AD27A71
    Protected Sub SUBJECTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        SUBJECTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECTSearch Search Operation

'Button Button_DoSearch OnClick. @9-B124E65B
        If CType(sender,Control).ID = "SUBJECTSearchButton_DoSearch" Then
            RedirectUrl = GetSUBJECTSearchRedirectUrl("", "s_YEAR_LEVEL")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch Event OnClick. Action Custom Code @30-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Button Button_DoSearch Event OnClick. Action Custom Code

'Button Button_DoSearch OnClick tail. @9-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECTSearch Search Operation tail @8-DA31D073
        ErrorFlag = SUBJECTSearchErrors.Count > 0
        If ErrorFlag Then
            SUBJECTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In SUBJECTSearchs_YEAR_LEVEL.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_YEAR_LEVEL=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form SUBJECTSearch Search Operation tail

'Record Form UpdateForm Parameters @53-0689F491

    Protected Sub UpdateFormParameters()
        Dim item As new UpdateFormItem
        Try
        Catch e As Exception
            UpdateFormErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form UpdateForm Parameters

'Record Form UpdateForm Show method @53-1A16F80A
    Protected Sub UpdateFormShow()
        If UpdateFormOperations.None Then
            UpdateFormHolder.Visible = False
            Return
        End If
        Dim item As UpdateFormItem = UpdateFormItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not UpdateFormOperations.AllowRead
        UpdateFormErrors.Add(item.errors)
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
            Return
        End If
'End Record Form UpdateForm Show method

'Record Form UpdateForm BeforeShow tail @53-D06F43D1
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormlblYearLevel2.Text = Server.HtmlEncode(item.lblYearLevel2.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormdespatchdate.Text=item.despatchdate.GetFormattedValue()
        UpdateFormbook_range_from.Text=item.book_range_from.GetFormattedValue()
        UpdateFormbook_range_to.Text=item.book_range_to.GetFormattedValue()
        If item.semester_1CheckedValue.Value.Equals(item.semester_1.Value) Then
            UpdateFormsemester_1.Checked = True
        End If
        If item.semester_2CheckedValue.Value.Equals(item.semester_2.Value) Then
            UpdateFormsemester_2.Checked = True
        End If
        If item.semester_bothCheckedValue.Value.Equals(item.semester_both.Value) Then
            UpdateFormsemester_both.Checked = True
        End If
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form UpdateForm BeforeShow tail

'Label lblYearLevel2 Event BeforeShow. Action Retrieve Value for Control @57-C00EBBA0
            UpdateFormlblYearLevel2.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL"))).GetFormattedValue()
'End Label lblYearLevel2 Event BeforeShow. Action Retrieve Value for Control

'Record UpdateForm Event BeforeShow. Action Hide-Show Component @54-EF8430E6
        Dim Urls_YEAR_LEVEL_54_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL"))
        Dim ExprParam2_54_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_YEAR_LEVEL_54_1, ExprParam2_54_2) Then
            UpdateFormHolder.Visible = False
        End If
'End Record UpdateForm Event BeforeShow. Action Hide-Show Component

'Record Form UpdateForm Show method tail @53-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @53-FF401DC4

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        Try
        item.despatchdate.IsEmpty = IsNothing(Request.Form(UpdateFormdespatchdate.UniqueID))
        If ControlCustomValues("UpdateFormdespatchdate") Is Nothing Then
            item.despatchdate.SetValue(UpdateFormdespatchdate.Text)
        Else
            item.despatchdate.SetValue(ControlCustomValues("UpdateFormdespatchdate"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("despatchdate",String.Format(Resources.strings.CCS_IncorrectFormat,"Despatch Date","dd/mm/yyyy"))
        End Try
        Try
        item.book_range_from.IsEmpty = IsNothing(Request.Form(UpdateFormbook_range_from.UniqueID))
        If ControlCustomValues("UpdateFormbook_range_from") Is Nothing Then
            item.book_range_from.SetValue(UpdateFormbook_range_from.Text)
        Else
            item.book_range_from.SetValue(ControlCustomValues("UpdateFormbook_range_from"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("book_range_from",String.Format(Resources.strings.CCS_IncorrectValue,"Book Range From"))
        End Try
        Try
        item.book_range_to.IsEmpty = IsNothing(Request.Form(UpdateFormbook_range_to.UniqueID))
        If ControlCustomValues("UpdateFormbook_range_to") Is Nothing Then
            item.book_range_to.SetValue(UpdateFormbook_range_to.Text)
        Else
            item.book_range_to.SetValue(ControlCustomValues("UpdateFormbook_range_to"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("book_range_to",String.Format(Resources.strings.CCS_IncorrectValue,"Book Range To"))
        End Try
        If UpdateFormsemester_1.Checked Then
            item.semester_1.Value = (item.semester_1CheckedValue.Value)
        Else
            item.semester_1.Value = (item.semester_1UncheckedValue.Value)
        End If
        If UpdateFormsemester_2.Checked Then
            item.semester_2.Value = (item.semester_2CheckedValue.Value)
        Else
            item.semester_2.Value = (item.semester_2UncheckedValue.Value)
        End If
        If UpdateFormsemester_both.Checked Then
            item.semester_both.Value = (item.semester_bothCheckedValue.Value)
        Else
            item.semester_both.Value = (item.semester_bothUncheckedValue.Value)
        End If
        If EnableValidation Then
            item.Validate(UpdateFormData)
        End If
        UpdateFormErrors.Add(item.errors)
    End Sub
'End Record Form UpdateForm LoadItemFromRequest method

'Record Form UpdateForm GetRedirectUrl method @53-E63A1AD3

    Protected Function GetUpdateFormRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form UpdateForm GetRedirectUrl method

'Record Form UpdateForm ShowErrors method @53-52F4A342

    Protected Sub UpdateFormShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To UpdateFormErrors.Count - 1
        Select Case UpdateFormErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & UpdateFormErrors(i)
        End Select
        Next i
        UpdateFormError.Visible = True
        UpdateFormErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form UpdateForm ShowErrors method

'Record Form UpdateForm Insert Operation @53-337A0C41

    Protected Sub UpdateForm_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Insert Operation

'Record Form UpdateForm BeforeInsert tail @53-B633AE71
    UpdateFormParameters()
    UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm BeforeInsert tail

'Record Form UpdateForm AfterInsert tail  @53-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm AfterInsert tail 

'Record Form UpdateForm Update Operation @53-26B5347A

    Protected Sub UpdateForm_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Update Operation

'Record Form UpdateForm Before Update tail @53-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm Before Update tail

'Record Form UpdateForm Update Operation tail @53-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm Update Operation tail

'Record Form UpdateForm Delete Operation @53-339A2861
    Protected Sub UpdateForm_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form UpdateForm Delete Operation

'Record Form BeforeDelete tail @53-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @53-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form UpdateForm Cancel Operation @53-062247BE

    Protected Sub UpdateForm_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        UpdateFormLoadItemFromRequest(item, True)
'End Record Form UpdateForm Cancel Operation

'Record Form UpdateForm Cancel Operation tail @53-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form UpdateForm Cancel Operation tail

'Button Button_DoUpdate OnClick Handler @45-E5D60DA0
    Protected Sub UpdateForm_Button_DoUpdate_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate OnClick Handler

'Button Button_DoUpdate Event OnClick. Action Custom Code @52-73254650
    ' -------------------------
      'ERA: sort through the selected subjects
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strSubjectID as string
		'	UpdateFormlblSelections.Text = "<br>Date: " & item.despatchdate.value
		'	UpdateFormlblSelections.Text += "<br>Books from " & item.book_range_from.getformattedvalue() & " to " & item.book_range_to.getformattedvalue() 
		'	UpdateFormlblSelections.Text += "<br>Semester1: " & item.semester_1.value
		'	UpdateFormlblSelections.Text += "<br>Semester2: " & item.semester_2.value
		'	UpdateFormlblSelections.Text += "<br>SemesterB: " & item.semester_both.value
        '   UpdateFormlblSelections.Text += "<br>Subjects selected:<br><br>"
  		'	for each repItem in SUBJECTRepeater.items
  		'		chkBoxed = repItem.FindControl("SUBJECTcbox")
  		'		if chkBoxed.checked then
  		'			strSubjectID = ctype(repItem.FindControl("SUBJECTSubject_ID"),Literal).Text
        '           UpdateFormlblSelections.Text += "<br>Subjects ID: " & strSubjectID.ToString
        '       End If
        '   Next
        If (not ErrorFlag) Then

	           ' handle the various semesters into a single string
            Dim semester_str As String = "("
            If (item.semester_1.Value) Then
                semester_str += "'1'"
                If (item.semester_2.Value Or item.semester_both.Value) Then
                    semester_str += ","
                End If
            End If

            If (item.semester_2.Value) Then
                semester_str += "'2'"
                If (item.semester_both.Value) Then
                    semester_str += ","
                End If
            End If

            If (item.semester_both.Value) Then
                semester_str += "'B'"
            End If
            semester_str += ")"


                ' ensure the date is in yyyy-MM-dd format for standard SQL
                'set as local variable
                'Dim GBformat As New CultureInfo("en-GB", True)
                'Dim strDateTemp As String = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(item.despatchdate.Value, GBformat))

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

                ' LN: 7/2/2014 Switch from OleDB to SQLClient.
                'Dim trans As OleDb.OleDbTransaction
                'Dim cmd As OleDb.OleDbCommand
                Dim trans As SqlClient.SqlTransaction
                Dim cmd As SqlClient.SqlCommand

                Try
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "dmy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""

					' bl**dy US default date formats
					strSQL = "set dateformat dmy"
					cmd.CommandType = CommandType.Text
					cmd.CommandText = strSQL
					'UpdateFormlblSelections.Text += "<hr>" & strSQL
					cmd.ExecuteNonQuery()

                    For Each repItem In SUBJECTRepeater.Items
                        chkBoxed = repItem.FindControl("SUBJECTcbox")
                        If chkBoxed.Checked Then
                            strSubjectID = CType(repItem.FindControl("SUBJECTSubject_ID"), Literal).Text
                            If strSubjectID <> "" Then
                                'NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer)
                                strSQL = "update BOOK_DESPATCH set DESPATCH_STATUS='S' "
                                'strSQL += ", DESPATCH_DATE=" & NewDao.ToSql(item.despatchdate.value, FieldType._Date) & " "
                                strSQL += ", DESPATCH_DATE='" & item.despatchdate.getformattedvalue() & "' "
                                strSQL += " from BOOK_DESPATCH a, STUDENT_SUBJECT b "
                                strSQL += " where b.SUBJ_ENROL_STATUS in ('C','E', 'P', 'D') and a.DESPATCH_STATUS='T' "
                                strSQL += " and b.SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and b.SEMESTER in " & semester_str & " "
                                strSQL += " and a.BOOK_ID between " & NewDao.ToSql(item.book_range_from.Value, FieldType._Integer) & " and " & NewDao.ToSql(item.book_range_to.Value, FieldType._Integer) & " "
                                strSQL += " and a.STUDENT_ID=b.STUDENT_ID and a.ENROLMENT_YEAR=b.ENROLMENT_YEAR and a.SUBJECT_ID=b.SUBJECT_ID "
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()
                                'UpdateFormlblSelections.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=red>Despatch Run Update was performed successfully for Year Level " & Me.UpdateFormlblYearLevel2.Text & "</font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Despatch Run Update <b>FAILED</b> for Year Level " & Me.UpdateFormlblYearLevel2.Text & "</font>"
                    UpdateFormlblSelections.Text += "Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button Button_DoUpdate Event OnClick. Action Custom Code

'Button Button_DoUpdate OnClick Handler tail @45-1FF43032
'ERA: don't redirect
        If ErrorFlag Then
            UpdateFormShowErrors()
        'Else
         '   Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate OnClick Handler tail

'Grid SUBJECT Bind @3-8BE7C752

    Protected Sub SUBJECTBind()
        If Not SUBJECTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT",GetType(SUBJECTDataProvider.SortFields), 80, 100)
        End If
'End Grid SUBJECT Bind

'Grid Form SUBJECT BeforeShow tail @3-57DD48C9
        SUBJECTParameters()
        SUBJECTData.SortField = CType(ViewState("SUBJECTSortField"),SUBJECTDataProvider.SortFields)
        SUBJECTData.SortDir = CType(ViewState("SUBJECTSortDir"),SortDirections)
        SUBJECTData.PageNumber = CInt(ViewState("SUBJECTPageNumber"))
        SUBJECTData.RecordsPerPage = CInt(ViewState("SUBJECTPageSize"))
        SUBJECTRepeater.DataSource = SUBJECTData.GetResultSet(PagesCount, SUBJECTOperations)
        ViewState("SUBJECTPagesCount") = PagesCount
        Dim item As SUBJECTItem = New SUBJECTItem()
        SUBJECTRepeater.DataBind
        FooterIndex = SUBJECTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SUBJECTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim SUBJECTlblYearLevel As System.Web.UI.WebControls.Literal = DirectCast(SUBJECTRepeater.Controls(0).FindControl("SUBJECTlblYearLevel"),System.Web.UI.WebControls.Literal)
        Dim SUBJECTSUBJECT_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(SUBJECTRepeater.Controls(0).FindControl("SUBJECTSUBJECT_TotalRecords"),System.Web.UI.WebControls.Literal)

        SUBJECTlblYearLevel.Text = Server.HtmlEncode(item.lblYearLevel.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SUBJECTSUBJECT_TotalRecords.Text = Server.HtmlEncode(item.SUBJECT_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form SUBJECT BeforeShow tail

'Label lblYearLevel Event BeforeShow. Action Retrieve Value for Control @43-2D2DD55D
            SUBJECTlblYearLevel.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL"))).GetFormattedValue()
'End Label lblYearLevel Event BeforeShow. Action Retrieve Value for Control

'Label SUBJECT_TotalRecords Event BeforeShow. Action Retrieve number of records @12-D68F1E16
            SUBJECTSUBJECT_TotalRecords.Text = SUBJECTData.RecordCount.ToString()
'End Label SUBJECT_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid SUBJECT Event BeforeShow. Action Hide-Show Component @32-F39170EC
        Dim Urls_YEAR_LEVEL_32_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL"))
        Dim ExprParam2_32_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_YEAR_LEVEL_32_1, ExprParam2_32_2) Then
            SUBJECTRepeater.Visible = False
        End If
'End Grid SUBJECT Event BeforeShow. Action Hide-Show Component

'Grid SUBJECT Bind tail @3-E31F8E2A
    End Sub
'End Grid SUBJECT Bind tail

'Grid SUBJECT Table Parameters @3-364B2BD6

    Protected Sub SUBJECTParameters()
        Try
            SUBJECTData.Urls_YEAR_LEVEL = IntegerParameter.GetParam("s_YEAR_LEVEL", ParameterSourceType.URL, "", -1, false)

        Catch
            Dim ParentControls As ControlCollection=SUBJECTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SUBJECTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SUBJECT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SUBJECT Table Parameters

'Grid SUBJECT ItemDataBound event @3-6823F95E

    Protected Sub SUBJECTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SUBJECTItem = CType(e.Item.DataItem,SUBJECTItem)
        Dim Item as SUBJECTItem = DataItem
        Dim FormDataSource As SUBJECTItem() = CType(SUBJECTRepeater.DataSource, SUBJECTItem())
        Dim SUBJECTDataRows As Integer = FormDataSource.Length
        Dim SUBJECTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SUBJECTcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("SUBJECTcbox"),System.Web.UI.WebControls.CheckBox)
            Dim SUBJECTSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTDEFAULT_SEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTDEFAULT_SEMESTER"),System.Web.UI.WebControls.Literal)
            If DataItem.cboxCheckedValue.Value.Equals(DataItem.cbox.Value) Then
                SUBJECTcbox.Checked = True
            End If
        End If
'End Grid SUBJECT ItemDataBound event

'Grid SUBJECT BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid SUBJECT BeforeShowRow event

'Grid SUBJECT Event BeforeShowRow. Action Set Row Style @17-DF8BE80B
            Dim styles17 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex17 As Integer = (SUBJECTCurrentRowNumber - 1) Mod styles17.Length
            Dim rawStyle17 As String = styles17(styleIndex17).Replace("\;",";")
            If rawStyle17.IndexOf("=") = -1 And rawStyle17.IndexOf(":") > -1 Then
                rawStyle17 = "style=""" + rawStyle17 + """"
            ElseIf rawStyle17.IndexOf("=") = -1 And rawStyle17.IndexOf(":") = -1 And rawStyle17 <> "" Then
                rawStyle17 = "class=""" + rawStyle17 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle17), AttributeOption.Multiple)
'End Grid SUBJECT Event BeforeShowRow. Action Set Row Style

'Grid SUBJECT BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid SUBJECT BeforeShowRow event tail

'Grid SUBJECT ItemDataBound event tail @3-2D28AE0B
        If SUBJECTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SUBJECTCurrentRowNumber, ListItemType.Item)
            SUBJECTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SUBJECTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SUBJECT ItemDataBound event tail

'Grid SUBJECT ItemCommand event @3-0DD9B41C

    Protected Sub SUBJECTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SUBJECTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SUBJECTSortDir"),SortDirections) = SortDirections._Asc And ViewState("SUBJECTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SUBJECTSortDir")=SortDirections._Desc
                Else
                    ViewState("SUBJECTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SUBJECTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SUBJECTDataProvider.SortFields = 0
            ViewState("SUBJECTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SUBJECTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SUBJECTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SUBJECTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SUBJECTBind
        End If
    End Sub
'End Grid SUBJECT ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4D1FF749
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Despatch_UpdatebyYearContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTSearchData = New SUBJECTSearchDataProvider()
        SUBJECTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        UpdateFormData = New UpdateFormDataProvider()
        UpdateFormOperations = New FormSupportedOperations(False, True, True, True, True)
        SUBJECTData = New SUBJECTDataProvider()
        SUBJECTOperations = New FormSupportedOperations(False, True, False, False, False)
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

