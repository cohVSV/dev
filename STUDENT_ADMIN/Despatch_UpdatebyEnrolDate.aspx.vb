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

Namespace DECV_PROD2007.Despatch_UpdatebyEnrolDate 'Namespace @1-E5F7FD0F

'Forms Definition @1-1CD5BEEA
Public Class [Despatch_UpdatebyEnrolDatePage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-25772FA8
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected Despatch_UpdatebyEnrolDateContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-0DB18A7A
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            UpdateFormShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

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

'Record Form UpdateForm BeforeShow tail @53-720DB5A6
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormstudentdatefrom.Text=item.studentdatefrom.GetFormattedValue()
        UpdateFormstudentdateto.Text=item.studentdateto.GetFormattedValue()
        If item.semester_1CheckedValue.Value.Equals(item.semester_1.Value) Then
            UpdateFormsemester_1.Checked = True
        End If
        If item.semester_2CheckedValue.Value.Equals(item.semester_2.Value) Then
            UpdateFormsemester_2.Checked = True
        End If
        If item.semester_bothCheckedValue.Value.Equals(item.semester_both.Value) Then
            UpdateFormsemester_both.Checked = True
        End If
        UpdateFormdespatchdate.Text=item.despatchdate.GetFormattedValue()
        UpdateFormbook_range_from.Text=item.book_range_from.GetFormattedValue()
        UpdateFormbook_range_to.Text=item.book_range_to.GetFormattedValue()
        If item.CheckBox0CheckedValue.Value.Equals(item.CheckBox0.Value) Then
            UpdateFormCheckBox0.Checked = True
        End If
        If item.CheckBox1CheckedValue.Value.Equals(item.CheckBox1.Value) Then
            UpdateFormCheckBox1.Checked = True
        End If
        If item.CheckBox2CheckedValue.Value.Equals(item.CheckBox2.Value) Then
            UpdateFormCheckBox2.Checked = True
        End If
        If item.CheckBox3CheckedValue.Value.Equals(item.CheckBox3.Value) Then
            UpdateFormCheckBox3.Checked = True
        End If
        If item.CheckBox4CheckedValue.Value.Equals(item.CheckBox4.Value) Then
            UpdateFormCheckBox4.Checked = True
        End If
        If item.CheckBox5CheckedValue.Value.Equals(item.CheckBox5.Value) Then
            UpdateFormCheckBox5.Checked = True
        End If
        If item.CheckBox6CheckedValue.Value.Equals(item.CheckBox6.Value) Then
            UpdateFormCheckBox6.Checked = True
        End If
        If item.CheckBox7CheckedValue.Value.Equals(item.CheckBox7.Value) Then
            UpdateFormCheckBox7.Checked = True
        End If
        If item.CheckBox8CheckedValue.Value.Equals(item.CheckBox8.Value) Then
            UpdateFormCheckBox8.Checked = True
        End If
        If item.CheckBox9CheckedValue.Value.Equals(item.CheckBox9.Value) Then
            UpdateFormCheckBox9.Checked = True
        End If
        If item.CheckBox10CheckedValue.Value.Equals(item.CheckBox10.Value) Then
            UpdateFormCheckBox10.Checked = True
        End If
        If item.CheckBox11CheckedValue.Value.Equals(item.CheckBox11.Value) Then
            UpdateFormCheckBox11.Checked = True
        End If
        If item.CheckBox12CheckedValue.Value.Equals(item.CheckBox12.Value) Then
            UpdateFormCheckBox12.Checked = True
        End If
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form UpdateForm BeforeShow tail

'Record Form UpdateForm Show method tail @53-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @53-0A0A9261

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        Try
        item.studentdatefrom.IsEmpty = IsNothing(Request.Form(UpdateFormstudentdatefrom.UniqueID))
        If ControlCustomValues("UpdateFormstudentdatefrom") Is Nothing Then
            item.studentdatefrom.SetValue(UpdateFormstudentdatefrom.Text)
        Else
            item.studentdatefrom.SetValue(ControlCustomValues("UpdateFormstudentdatefrom"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("studentdatefrom",String.Format(Resources.strings.CCS_IncorrectFormat,"Despatch Date for Students FROM","dd/mm/yyyy"))
        End Try
        Try
        item.studentdateto.IsEmpty = IsNothing(Request.Form(UpdateFormstudentdateto.UniqueID))
        If ControlCustomValues("UpdateFormstudentdateto") Is Nothing Then
            item.studentdateto.SetValue(UpdateFormstudentdateto.Text)
        Else
            item.studentdateto.SetValue(ControlCustomValues("UpdateFormstudentdateto"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("studentdateto",String.Format(Resources.strings.CCS_IncorrectFormat,"Despatch Date for Students TO","dd/mm/yyyy"))
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
        If UpdateFormCheckBox0.Checked Then
            item.CheckBox0.Value = (item.CheckBox0CheckedValue.Value)
        Else
            item.CheckBox0.Value = (item.CheckBox0UncheckedValue.Value)
        End If
        If UpdateFormCheckBox1.Checked Then
            item.CheckBox1.Value = (item.CheckBox1CheckedValue.Value)
        Else
            item.CheckBox1.Value = (item.CheckBox1UncheckedValue.Value)
        End If
        If UpdateFormCheckBox2.Checked Then
            item.CheckBox2.Value = (item.CheckBox2CheckedValue.Value)
        Else
            item.CheckBox2.Value = (item.CheckBox2UncheckedValue.Value)
        End If
        If UpdateFormCheckBox3.Checked Then
            item.CheckBox3.Value = (item.CheckBox3CheckedValue.Value)
        Else
            item.CheckBox3.Value = (item.CheckBox3UncheckedValue.Value)
        End If
        If UpdateFormCheckBox4.Checked Then
            item.CheckBox4.Value = (item.CheckBox4CheckedValue.Value)
        Else
            item.CheckBox4.Value = (item.CheckBox4UncheckedValue.Value)
        End If
        If UpdateFormCheckBox5.Checked Then
            item.CheckBox5.Value = (item.CheckBox5CheckedValue.Value)
        Else
            item.CheckBox5.Value = (item.CheckBox5UncheckedValue.Value)
        End If
        If UpdateFormCheckBox6.Checked Then
            item.CheckBox6.Value = (item.CheckBox6CheckedValue.Value)
        Else
            item.CheckBox6.Value = (item.CheckBox6UncheckedValue.Value)
        End If
        If UpdateFormCheckBox7.Checked Then
            item.CheckBox7.Value = (item.CheckBox7CheckedValue.Value)
        Else
            item.CheckBox7.Value = (item.CheckBox7UncheckedValue.Value)
        End If
        If UpdateFormCheckBox8.Checked Then
            item.CheckBox8.Value = (item.CheckBox8CheckedValue.Value)
        Else
            item.CheckBox8.Value = (item.CheckBox8UncheckedValue.Value)
        End If
        If UpdateFormCheckBox9.Checked Then
            item.CheckBox9.Value = (item.CheckBox9CheckedValue.Value)
        Else
            item.CheckBox9.Value = (item.CheckBox9UncheckedValue.Value)
        End If
        If UpdateFormCheckBox10.Checked Then
            item.CheckBox10.Value = (item.CheckBox10CheckedValue.Value)
        Else
            item.CheckBox10.Value = (item.CheckBox10UncheckedValue.Value)
        End If
        If UpdateFormCheckBox11.Checked Then
            item.CheckBox11.Value = (item.CheckBox11CheckedValue.Value)
        Else
            item.CheckBox11.Value = (item.CheckBox11UncheckedValue.Value)
        End If
        If UpdateFormCheckBox12.Checked Then
            item.CheckBox12.Value = (item.CheckBox12CheckedValue.Value)
        Else
            item.CheckBox12.Value = (item.CheckBox12UncheckedValue.Value)
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
			 ' handle the yearlevels checkboxes into a single string
            Dim year_level_str As String = "("
                If (item.CheckBox0.Value) Then year_level_str += "0,"
                If (item.CheckBox1.Value) Then year_level_str += "1,"
                If (item.CheckBox2.Value) Then year_level_str += "2,"
                If (item.CheckBox3.Value) Then year_level_str += "3,"
                If (item.CheckBox4.Value) Then year_level_str += "4,"
                If (item.CheckBox5.Value) Then year_level_str += "5,"
                If (item.CheckBox6.Value) Then year_level_str += "6,"
                If (item.CheckBox7.Value) Then year_level_str += "7,"
                If (item.CheckBox8.Value) Then year_level_str += "8,"
                If (item.CheckBox9.Value) Then year_level_str += "9,"
                If (item.CheckBox10.Value) Then year_level_str += "10,"
                If (item.CheckBox11.Value) Then year_level_str += "11,"
                If (item.CheckBox12.Value) Then year_level_str += "12,"
            year_level_str += "99)"

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
					Dim tmpUsername As String
                     If (Session("UserID").ToString = "") Then
                        tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If

					' bl**dy US default date formats
					strSQL = "set dateformat dmy"
					cmd.CommandText = strSQL
					'UpdateFormlblSelections.Text += "<hr>" & strSQL
					cmd.ExecuteNonQuery()

					' delete any from the temp table 
					strSQL = "delete from TEMP_STUD_SUBJ where USERNAME=" & tmpUsername & " "
					cmd.CommandText = strSQL
					'UpdateFormlblSelections.Text += "<hr>" & strSQL
					cmd.ExecuteNonQuery()
					

					' now put this data into the TEMP_STUD_SUBJ table
					strSQL = "insert TEMP_STUD_SUBJ (STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID, USERNAME) "
					strSQL += " select STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID ," & tmpUsername & " "
					strSQL += " from STUDENT_SUBJECT "
					strSQL += " where ENROLMENT_DATE between '" & item.studentdatefrom.getformattedValue() & "' and '" & item.studentdateto.getformattedValue() & "' and "
					strSQL += " SUBJECT_ID in (select SUBJECT_ID from SUBJECT where YEAR_LEVEL in " & year_level_str & " and CAMPUS_CODE ='D') and "
					strSQL += " SUBJ_ENROL_STATUS in  ('C','E','P','D') and "
					strSQL += " SEMESTER in " & semester_str & " "
					cmd.CommandText = strSQL
					'UpdateFormlblSelections.Text += "<hr>" & strSQL
					cmd.ExecuteNonQuery()
					

					' update it
					strSQL = "update BOOK_DESPATCH set DESPATCH_STATUS='S' , DESPATCH_DATE='" & item.despatchdate.getformattedValue() & "' "
					strSQL += "from BOOK_DESPATCH a, TEMP_STUD_SUBJ b "
					strSQL += "where a.DESPATCH_STATUS='T' "
					strSQL += " and a.BOOK_ID between " & NewDao.ToSql(item.book_range_from.Value, FieldType._Integer) & " and " & NewDao.ToSql(item.book_range_to.Value, FieldType._Integer) & " "
					strSQL += " and b.USERNAME=" & tmpUsername & " "
					strSQL += " and a.STUDENT_ID=b.STUDENT_ID and a.ENROLMENT_YEAR=b.ENROLMENT_YEAR and a.SUBJECT_ID=b.SUBJECT_ID"
					cmd.CommandText = strSQL
					'UpdateFormlblSelections.Text += "<hr>" & strSQL
					cmd.ExecuteNonQuery()
					

                	' delete any from the temp table 
					strSQL = "delete from TEMP_STUD_SUBJ where USERNAME= " & tmpUsername & " "
					cmd.CommandText = strSQL
					cmd.ExecuteNonQuery()
					'UpdateFormlblSelections.Text += "<hr>" & strSQL

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=red>Despatch Run Update was performed successfully for Enrolment Date Range '" & item.studentdatefrom.getformattedvalue &"' to '" & item.studentdateto.getformattedvalue &"'</font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Despatch Run Update <b>FAILED</b> for Enrolment Date Range '" & item.studentdatefrom.getformattedvalue &"' to '" & item.studentdateto.getformattedvalue &"'</font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
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

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-EBCA47EE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Despatch_UpdatebyEnrolDateContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        UpdateFormData = New UpdateFormDataProvider()
        UpdateFormOperations = New FormSupportedOperations(False, True, True, True, True)
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

