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

Namespace DECV_PROD2007.Student_Subject_maintain 'Namespace @1-A87903AA

'Forms Definition @1-859C77F7
Public Class [Student_Subject_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C10FC5EC
    Protected AddSubjectData As AddSubjectDataProvider
    Protected AddSubjectErrors As NameValueCollection = New NameValueCollection()
    Protected AddSubjectOperations As FormSupportedOperations
    Protected AddSubjectIsSubmitted As Boolean = False
    Protected PrimarySubjectM3Data As PrimarySubjectM3DataProvider
    Protected PrimarySubjectM3Errors As NameValueCollection = New NameValueCollection()
    Protected PrimarySubjectM3Operations As FormSupportedOperations
    Protected PrimarySubjectM3IsSubmitted As Boolean = False
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTIsSubmitted As Boolean = False
    Protected CORESUBJECTSData As CORESUBJECTSDataProvider
    Protected CORESUBJECTSCurrentRowNumber As Integer
    Protected CORESUBJECTSIsSubmitted As Boolean = False
    Protected CORESUBJECTSErrors As New NameValueCollection()
    Protected CORESUBJECTSOperations As FormSupportedOperations
    Protected CORESUBJECTSDataItem As CORESUBJECTSItem
    Protected NewGrid1Data As NewGrid1DataProvider
    Protected NewGrid1Operations As FormSupportedOperations
    Protected NewGrid1CurrentRowNumber As Integer
    Protected Student_Subject_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E32D2E71
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.lblModified.SetValue(System.IO.File.GetLastWriteTime(Request.PhysicalPath).ToString("dd MMM yy HH:mm"))
            PageData.FillItem(item)
            button_PopupSubjectList.DataBind()
            lblModified.Text = Server.HtmlEncode(item.lblModified.GetFormattedValue()).Replace(vbCrLf,"<br>")
            AddSubjectShow()
            PrimarySubjectM3Show()
            STUDENTShow()
            CORESUBJECTSBind()
            NewGrid1Bind
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_Subject_maintain Event BeforeShow. Action Declare Variable @113-E1222779
    Dim tmp_STUDENT_ID As Int64 = -1
'End Page Student_Subject_maintain Event BeforeShow. Action Declare Variable

'Page Student_Subject_maintain Event BeforeShow. Action Declare Variable @114-019CEDDC
    Dim tmp_ENROLMENT_YEAR As Int64 = Year(Now())
'End Page Student_Subject_maintain Event BeforeShow. Action Declare Variable

'Page Student_Subject_maintain Event BeforeShow. Action Declare Variable @297-022ED4C9
    Dim tmp_YEAR_LEVEL As Int64 = 0
'End Page Student_Subject_maintain Event BeforeShow. Action Declare Variable

'Page Student_Subject_maintain Event BeforeShow. Action Retrieve Value for Variable @111-4C331B92
    tmp_STUDENT_ID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Page Student_Subject_maintain Event BeforeShow. Action Retrieve Value for Variable

'Page Student_Subject_maintain Event BeforeShow. Action Retrieve Value for Variable @112-C75B978D
    tmp_ENROLMENT_YEAR = System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR")
'End Page Student_Subject_maintain Event BeforeShow. Action Retrieve Value for Variable

'Page Student_Subject_maintain Event BeforeShow. Action DLookup @106-FF2C2C26
    tmp_YEAR_LEVEL = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "YEAR_LEVEL" & " FROM " & "STUDENT_ENROLMENT" & " WHERE " & "STUDENT_ID = " & tmp_STUDENT_ID.ToString()  & " AND ENROLMENT_YEAR= " & tmp_ENROLMENT_YEAR.ToString()))).Value, Int64)
'End Page Student_Subject_maintain Event BeforeShow. Action DLookup

'Page Student_Subject_maintain Event BeforeShow. Action Hide-Show Component @107-A50D3F8B
        If (tmp_YEAR_LEVEL > 6) Then
            PrimarySubjectM3Holder.Visible = False
        End If
'End Page Student_Subject_maintain Event BeforeShow. Action Hide-Show Component

'Page Student_Subject_maintain Event BeforeShow. Action Hide-Show Component @299-95CB607E
        If (tmp_YEAR_LEVEL < 7 or tmp_YEAR_LEVEL > 10) Then
            CORESUBJECTSRepeater.Visible = False
        End If
'End Page Student_Subject_maintain Event BeforeShow. Action Hide-Show Component

    End Sub 'Page_Load Event tail @1-E31F8E2A

'Button button_PopupSubjectList OnClick Handler @42-E65B54C7
Protected Sub button_PopupSubjectList_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
'End Button button_PopupSubjectList OnClick Handler

'Button button_PopupSubjectList OnClick Handler tail @42-E31F8E2A
End Sub
'End Button button_PopupSubjectList OnClick Handler tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form AddSubject Parameters @28-F2D04657

    Protected Sub AddSubjectParameters()
        Dim item As new AddSubjectItem
        Try
        Catch e As Exception
            AddSubjectErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form AddSubject Parameters

'Record Form AddSubject Show method @28-E70BE74C
    Protected Sub AddSubjectShow()
        If AddSubjectOperations.None Then
            AddSubjectHolder.Visible = False
            Return
        End If
        Dim item As AddSubjectItem = AddSubjectItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not AddSubjectOperations.AllowRead
        AddSubjectErrors.Add(item.errors)
        If AddSubjectErrors.Count > 0 Then
            AddSubjectShowErrors()
            Return
        End If
'End Record Form AddSubject Show method

'Record Form AddSubject BeforeShow tail @28-9C2FAD4D
        AddSubjectParameters()
        AddSubjectData.FillItem(item, IsInsertMode)
        AddSubjectHolder.DataBind()
        AddSubjectsubject_id.Text=item.subject_id.GetFormattedValue()
        AddSubjectsemester.Items.Add(new ListItem("Select Value",""))
        AddSubjectsemester.Items(0).Selected = True
        item.semesterItems.SetSelection(item.semester.GetFormattedValue())
        If Not item.semesterItems.GetSelectedItem() Is Nothing Then
            AddSubjectsemester.SelectedIndex = -1
        End If
        item.semesterItems.CopyTo(AddSubjectsemester.Items)
        AddSubjectsubj_enrol_date.Text=item.subj_enrol_date.GetFormattedValue()
        AddSubjecthidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        AddSubjecthidden_ENROLMENT_YEAR.Value = item.hidden_ENROLMENT_YEAR.GetFormattedValue()
        AddSubjectlblMessage.Text = Server.HtmlEncode(item.lblMessage.GetFormattedValue()).Replace(vbCrLf,"<br>")
        AddSubjectListBox_SubjectYearLevel.Items.Add(new ListItem("Select Value",""))
        AddSubjectListBox_SubjectYearLevel.Items(0).Selected = True
        item.ListBox_SubjectYearLevelItems.SetSelection(item.ListBox_SubjectYearLevel.GetFormattedValue())
        If Not item.ListBox_SubjectYearLevelItems.GetSelectedItem() Is Nothing Then
            AddSubjectListBox_SubjectYearLevel.SelectedIndex = -1
        End If
        item.ListBox_SubjectYearLevelItems.CopyTo(AddSubjectListBox_SubjectYearLevel.Items)
        AddSubjectListBox_Subject.Items.Add(new ListItem("Select Value",""))
        AddSubjectListBox_Subject.Items(0).Selected = True
        item.ListBox_SubjectItems.SetSelection(item.ListBox_Subject.GetFormattedValue())
        If Not item.ListBox_SubjectItems.GetSelectedItem() Is Nothing Then
            AddSubjectListBox_Subject.SelectedIndex = -1
        End If
        item.ListBox_SubjectItems.CopyTo(AddSubjectListBox_Subject.Items)
        AddSubjectcourse_distribution.Value = item.course_distribution.GetFormattedValue()
        AddSubjectHidden_CustomProgram.Value = item.Hidden_CustomProgram.GetFormattedValue()
'End Record Form AddSubject BeforeShow tail

'Record AddSubject Event BeforeShow. Action Retrieve Value for Control @38-3288605D
            AddSubjecthidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record AddSubject Event BeforeShow. Action Retrieve Value for Control

'Record AddSubject Event BeforeShow. Action Retrieve Value for Control @39-E313E073
            AddSubjecthidden_ENROLMENT_YEAR.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record AddSubject Event BeforeShow. Action Retrieve Value for Control

'Record Form AddSubject Show method tail @28-2F72C0C4
        If AddSubjectErrors.Count > 0 Then
            AddSubjectShowErrors()
        End If
    End Sub
'End Record Form AddSubject Show method tail

'Record Form AddSubject LoadItemFromRequest method @28-728199CF

    Protected Sub AddSubjectLoadItemFromRequest(item As AddSubjectItem, ByVal EnableValidation As Boolean)
        Try
        item.subject_id.IsEmpty = IsNothing(Request.Form(AddSubjectsubject_id.UniqueID))
        If ControlCustomValues("AddSubjectsubject_id") Is Nothing Then
            item.subject_id.SetValue(AddSubjectsubject_id.Text)
        Else
            item.subject_id.SetValue(ControlCustomValues("AddSubjectsubject_id"))
        End If
        Catch ae As ArgumentException
            AddSubjectErrors.Add("subject_id",String.Format(Resources.strings.CCS_IncorrectValue,"Subject ID"))
        End Try
        item.semester.IsEmpty = IsNothing(Request.Form(AddSubjectsemester.UniqueID))
        item.semester.SetValue(AddSubjectsemester.Value)
        item.semesterItems.CopyFrom(AddSubjectsemester.Items)
        Try
        item.subj_enrol_date.IsEmpty = IsNothing(Request.Form(AddSubjectsubj_enrol_date.UniqueID))
        If ControlCustomValues("AddSubjectsubj_enrol_date") Is Nothing Then
            item.subj_enrol_date.SetValue(AddSubjectsubj_enrol_date.Text)
        Else
            item.subj_enrol_date.SetValue(ControlCustomValues("AddSubjectsubj_enrol_date"))
        End If
        Catch ae As ArgumentException
            AddSubjectErrors.Add("subj_enrol_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrolment Date","dd/mm/yyyy"))
        End Try
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(AddSubjecthidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(AddSubjecthidden_STUDENT_ID.Value)
        item.hidden_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(AddSubjecthidden_ENROLMENT_YEAR.UniqueID))
        item.hidden_ENROLMENT_YEAR.SetValue(AddSubjecthidden_ENROLMENT_YEAR.Value)
        item.ListBox_SubjectYearLevel.IsEmpty = IsNothing(Request.Form(AddSubjectListBox_SubjectYearLevel.UniqueID))
        item.ListBox_SubjectYearLevel.SetValue(AddSubjectListBox_SubjectYearLevel.Value)
        item.ListBox_SubjectYearLevelItems.CopyFrom(AddSubjectListBox_SubjectYearLevel.Items)
        item.ListBox_Subject.IsEmpty = IsNothing(Request.Form(AddSubjectListBox_Subject.UniqueID))
        item.ListBox_Subject.SetValue(AddSubjectListBox_Subject.Value)
        item.ListBox_SubjectItems.CopyFrom(AddSubjectListBox_Subject.Items)
        item.course_distribution.IsEmpty = IsNothing(Request.Form(AddSubjectcourse_distribution.UniqueID))
        item.course_distribution.SetValue(AddSubjectcourse_distribution.Value)
        Try
        item.Hidden_CustomProgram.IsEmpty = IsNothing(Request.Form(AddSubjectHidden_CustomProgram.UniqueID))
        item.Hidden_CustomProgram.SetValue(AddSubjectHidden_CustomProgram.Value)
        Catch ae As ArgumentException
            AddSubjectErrors.Add("Hidden_CustomProgram",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_CustomProgram"))
        End Try
        If EnableValidation Then
            item.Validate(AddSubjectData)
        End If
        AddSubjectErrors.Add(item.errors)
    End Sub
'End Record Form AddSubject LoadItemFromRequest method

'Record Form AddSubject GetRedirectUrl method @28-474AA917

    Protected Function GetAddSubjectRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Subject_maintain.aspx"
        Dim p As String = parameters.ToString("GET","SUBJECT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form AddSubject GetRedirectUrl method

'Record Form AddSubject ShowErrors method @28-575842B0

    Protected Sub AddSubjectShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To AddSubjectErrors.Count - 1
        Select Case AddSubjectErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & AddSubjectErrors(i)
        End Select
        Next i
        AddSubjectError.Visible = True
        AddSubjectErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form AddSubject ShowErrors method

'Record Form AddSubject Insert Operation @28-BFCC00F9

    Protected Sub AddSubject_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddSubjectItem = New AddSubjectItem()
        AddSubjectIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AddSubject Insert Operation

'Record Form AddSubject BeforeInsert tail @28-87E6A090
    AddSubjectParameters()
    AddSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form AddSubject BeforeInsert tail

'Record Form AddSubject AfterInsert tail  @28-B54B6604
        ErrorFlag=(AddSubjectErrors.Count > 0)
        If ErrorFlag Then
            AddSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AddSubject AfterInsert tail 

'Record Form AddSubject Update Operation @28-3214EB35

    Protected Sub AddSubject_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddSubjectItem = New AddSubjectItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        AddSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AddSubject Update Operation

'Record Form AddSubject Before Update tail @28-87E6A090
        AddSubjectParameters()
        AddSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form AddSubject Before Update tail

'Record Form AddSubject Update Operation tail @28-B54B6604
        ErrorFlag=(AddSubjectErrors.Count > 0)
        If ErrorFlag Then
            AddSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AddSubject Update Operation tail

'Record Form AddSubject Delete Operation @28-DB6BC0F9
    Protected Sub AddSubject_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        AddSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As AddSubjectItem = New AddSubjectItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form AddSubject Delete Operation

'Record Form BeforeDelete tail @28-87E6A090
        AddSubjectParameters()
        AddSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @28-318051C2
        If ErrorFlag Then
            AddSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form AddSubject Cancel Operation @28-2A70D455

    Protected Sub AddSubject_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddSubjectItem = New AddSubjectItem()
        AddSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        AddSubjectLoadItemFromRequest(item, True)
'End Record Form AddSubject Cancel Operation

'Record Form AddSubject Cancel Operation tail @28-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form AddSubject Cancel Operation tail

'Button ButtonAdd OnClick Handler @30-D2418D70
    Protected Sub AddSubject_ButtonAdd_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetAddSubjectRedirectUrl("", "")
        Dim item As New AddSubjectItem
        AddSubjectLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (AddSubjectErrors.Count > 0)
'End Button ButtonAdd OnClick Handler

'Button ButtonAdd Event OnClick. Action Custom Code @40-73254650
    ' -------------------------
'ERA: sort through the selected subjects
		' check for semester tick 

  	If (not ErrorFlag) Then

          'actually send the requested changes to the SQL string
          Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

		  'April-2013|EA| finally convert to SQL connection following move to DECV-DB
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

              cmd.Transaction = trans

				Dim strSQL As String = ""
				Dim tmpUsername As String		' NOTE: quotes added HERE not in SQL string
				If (Session("UserID").ToString = "") Then
					tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
				Else
					tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
				End If

			   ' work out the subject_status_rule() from dynamo functions in Sybase app
                Dim strsubj_enrol_status As String = "C"
                Dim intMonth As Int64 = (Month(Now()))
                '18-June-2014|EA| adjust 'rollover date' depending on VCE/Non-VCE subject id
				Dim dateVCERollover = New Date(Now.Year, 6, 15)
				Dim dateNonVCERollover = New Date(Now.Year, 7, 1)
				Dim dateNewPending = New Date(Now.Year, 1, 28)	'29-Jan-2017|EA| new date, for now;30-Jan-2018|EA| back to 28 Jan...
				Dim boolVCESubject as Boolean = Iif((item.subject_id.getformattedvalue >= 500 and item.subject_id.getformattedvalue < 900), true, false)

                If (item.semester.Value = "1" Or item.semester.Value = "B") Then
                    'Jan-2013|EA| change so that VCE (subject ID >=500) will be 'C', but all others will be 'P', instead of 'C' for all
					'if (item.subject_id.getformattedvalue >= 500 or intMonth < 7) then
					'29-Sept-2016|EA|reinstate P for Sem 1 as enrolments starting from 3 Oct 2016
					if (intMonth < 7 and (Today >= dateNewPending)) then
						strsubj_enrol_status = "C"
					else
						strsubj_enrol_status = "P"
					end if
					' end jan-2013
                ElseIf (item.semester.Value = "2") Then
					'June-2012|EA| adjust starting Month from 7 to 6 (unfuddle #471)
					'Sept-2012|EA| adjust BACK to original 1-July to reverse previous change (unfuddle #471)
					'18-June-2014|EA| adjust depending on Date and VCE/NonVCE subject id
					'  so that VCE (500-899) are C from 15 June (see dates above) otherwise 'C' in July (non-VCE) (ufuddle #648, #471 again)
					' the date setup above can be re-typed if needed or gathered from config or database
					'27-Oct-2016|EA|ensure 'P' for Term 2 all year except for June-Sept as next-year enrolments starting from 3 Oct 2016 (unfuddle #774)
					strsubj_enrol_status = "P"	'default
					'If (boolVCESubject and (Today > dateVCERollover And intMonth <= 10)) or ((not boolVCESubject) and (Today > dateNonVCERollover And intMonth <= 10)) Then
					If (intMonth >= 6 And intMonth < 10) Then
                    	strsubj_enrol_status = "C"
                    End If
                End If

				' bl**dy US default date formats
				strSQL = "set dateformat dmy"
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				AddSubjectlblMessage.Text += "<hr>" & strSQL
				cmd.ExecuteNonQuery()

				' insert into STUDENT_SUBJECT
				'22-Nov-2019|EA| change 'NA' to 'N-A' (ticket #21024)
				strSQL = "insert STUDENT_SUBJECT(STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID,STAFF_ID, SEMESTER "
				strSQL += " , ENROLMENT_DATE, SUBJ_ENROL_STATUS, VBOS_REGISTERED,APPEARS_ON_VASS, NUM_ASSMT_SUBMISSIONS, EXTENSION_OF_VCE_UNIT, COURSE_DISTRIBUTION,LAST_ALTERED_BY, LAST_ALTERED_DATE) "
				strSQL += " values(" & item.hidden_student_id.getformattedvalue & "," & item.hidden_ENROLMENT_YEAR.getformattedvalue & "," & item.subject_id.getformattedvalue & ",'N-A','" & item.semester.getformattedvalue & "' "
				strSQL += " ,'" & item.subj_enrol_date.getformattedvalue & "', '" & strsubj_enrol_status & "',1,0,0,0 ,'" & item.course_distribution.getformattedvalue & "'," & tmpUsername & ", getdate())"
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				AddSubjectlblMessage.Text += "<hr>SQL:" & strSQL
				cmd.ExecuteNonQuery()

				' update the record with the teacher record into STUDENT_SUBJECT
				strSQL = "update STUDENT_SUBJECT set STAFF_ID=SUBJECT.DEFAULT_TEACHER_ID from STUDENT_SUBJECT , SUBJECT  "
				strSQL += " where STUDENT_SUBJECT.SUBJECT_ID=" & item.subject_id.getformattedvalue & " and STUDENT_SUBJECT.STUDENT_ID="& item.hidden_student_id.getformattedvalue &" and STUDENT_SUBJECT.ENROLMENT_YEAR = "& item.hidden_ENROLMENT_YEAR.getformattedvalue & " and STUDENT_SUBJECT.SUBJECT_ID=SUBJECT.SUBJECT_ID "
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				AddSubjectlblMessage.Text += "<hr>SQL:" & strSQL
				cmd.ExecuteNonQuery()

    			'/* Insert STUD_SUBJ_FINAL Table */
				strSQL = "insert STUD_SUBJ_FINAL (STUDENT_ID,ENROLMENT_YEAR,SUBJECT_ID,LAST_ALTERED_BY, LAST_ALTERED_DATE) "
				strSQL += " values(" & item.hidden_student_id.getformattedvalue & "," & item.hidden_ENROLMENT_YEAR.getformattedvalue & "," & item.subject_id.getformattedvalue & "," & tmpUsername & ", getdate())"
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				AddSubjectlblMessage.Text += "<hr>SQL:" & strSQL
				cmd.ExecuteNonQuery()

				'/* Insert STUD_SUB_INTERIM Table */
				strSQL = "insert STUD_SUB_INTERIM (STUDENT_ID,ENROLMENT_YEAR,SUBJECT_ID,LAST_ALTERED_BY, LAST_ALTERED_DATE) "
				strSQL += " values(" & item.hidden_student_id.getformattedvalue & "," & item.hidden_ENROLMENT_YEAR.getformattedvalue & "," & item.subject_id.getformattedvalue & "," & tmpUsername & ", getdate())"
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				AddSubjectlblMessage.Text += "<hr>SQL:" & strSQL
				cmd.ExecuteNonQuery()


				' get the MAX_BOOKS and insert records for each book
				Dim intMAX_BOOKS As Int64 = 0
				Dim intBookCounter As Int64 = 0
				
				intMAX_BOOKS = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select MAX_BOOKS from SUBJECT where SUBJECT_ID=" & item.subject_id.getformattedvalue ))).Value, Int64)

				'2-Dec-2010|EA| start counting at 10 for Units 10-18 in Primary (unfuddle #344)
				Dim intCountFrom as Int64 = 1

				Dim aUnits10to18() as Integer = {3,5,13,17,23,27,34,37,45,47,53,56,62,66}	' Subject ID of Primary Units 10-18 - MUST BE SORTED Ascending
				Dim iSubjectID as integer = Convert.ToInt32(item.subject_id.getformattedvalue)

				If (Array.IndexOf(aUnits10to18, iSubjectID) > 0) Then
					intCountFrom = 10
					intMAX_BOOKS += (intCountFrom - 1)		' move the Max Books up too
				end if
				' end 2-Dec

				if (intMAX_BOOKS > 0) then
					for intBookCounter = intCountFrom to intMAX_BOOKS		' adjust from '1 to intMAX_BOOKS'
						strSQL = "insert BOOK_DESPATCH (STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID, BOOK_ID, DESPATCH_STATUS, LAST_ALTERED_BY, LAST_ALTERED_DATE) "
						strSQL += " values(" & item.hidden_student_id.getformattedvalue & "," & item.hidden_ENROLMENT_YEAR.getformattedvalue & "," & item.subject_id.getformattedvalue & "," & intBookCounter.ToString() & ", 'T', " & tmpUsername & ", getdate())"
						cmd.CommandType = CommandType.Text
						cmd.CommandText = strSQL
						AddSubjectlblMessage.Text += "<hr>SQL:" & strSQL
						cmd.ExecuteNonQuery()
					next
				end if 

              trans.Commit()
              AddSubjectlblMessage.Text += "<br><font color=red>Subject ID " & item.subject_id.getformattedvalue & " Added</font>"

          Catch ex As Exception
              
              AddSubjectlblMessage.Text += "<br><font color=red>Add Subject <b>FAILED</b> for Subject ID " & item.subject_id.getformattedvalue & "</font>"
              AddSubjectlblMessage.Text += "<br>Error: " & ex.Message.ToString
              AddSubjectlblMessage.Visible = True
			  ErrorFlag = true
			  trans.Rollback()
          Finally
              If NewDao.NativeConnection.State = ConnectionState.Open Then
                  NewDao.NativeConnection.Close()
              End If
          End Try

      End If
    ' -------------------------
'End Button ButtonAdd Event OnClick. Action Custom Code

'Button ButtonAdd OnClick Handler tail @30-318051C2
        If ErrorFlag Then
            AddSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button ButtonAdd OnClick Handler tail

'Record Form PrimarySubjectM3 Parameters @66-31E1008F

    Protected Sub PrimarySubjectM3Parameters()
        Dim item As new PrimarySubjectM3Item
        Try
            PrimarySubjectM3Data.Ctrlhidden_STUDENT_ID = IntegerParameter.GetParam(item.hidden_STUDENT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.Ctrlhidden_ENROLMENT_YEAR = IntegerParameter.GetParam(item.hidden_ENROLMENT_YEAR.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.CtrlGrade = IntegerParameter.GetParam(item.Grade.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.ExprKey158 = TextParameter.GetParam("B", ParameterSourceType.Expression, "", "B", false)
            PrimarySubjectM3Data.CtrlEnrolDate = DateParameter.GetParam(item.EnrolDate.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            PrimarySubjectM3Data.CtrlGrade1 = IntegerParameter.GetParam(item.Grade1.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.ExprKey161 = TextParameter.GetParam("B", ParameterSourceType.Expression, "", "B", false)
            PrimarySubjectM3Data.CtrlEnrolDate1 = DateParameter.GetParam(item.EnrolDate1.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            PrimarySubjectM3Data.CtrlGrade3 = IntegerParameter.GetParam(item.Grade3.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.ExprKey164 = TextParameter.GetParam("B", ParameterSourceType.Expression, "", "B", false)
            PrimarySubjectM3Data.CtrlEnrolDate3 = DateParameter.GetParam(item.EnrolDate3.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            PrimarySubjectM3Data.CtrlGrade2 = IntegerParameter.GetParam(item.Grade2.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.ExprKey167 = TextParameter.GetParam("B", ParameterSourceType.Expression, "", "B", false)
            PrimarySubjectM3Data.CtrlEnrolDate2 = DateParameter.GetParam(item.EnrolDate2.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            PrimarySubjectM3Data.CtrlGrade4 = IntegerParameter.GetParam(item.Grade4.Value, ParameterSourceType.Control, "", Nothing, false)
            PrimarySubjectM3Data.ExprKey170 = TextParameter.GetParam("B", ParameterSourceType.Expression, "", "B", false)
            PrimarySubjectM3Data.CtrlEnrolDate4 = DateParameter.GetParam(item.EnrolDate4.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            PrimarySubjectM3Data.ExprKey172 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            PrimarySubjectM3Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form PrimarySubjectM3 Parameters

'Record Form PrimarySubjectM3 Show method @66-4C27DF16
    Protected Sub PrimarySubjectM3Show()
        If PrimarySubjectM3Operations.None Then
            PrimarySubjectM3Holder.Visible = False
            Return
        End If
        Dim item As PrimarySubjectM3Item = PrimarySubjectM3Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not PrimarySubjectM3Operations.AllowRead
        PrimarySubjectM3Errors.Add(item.errors)
        If PrimarySubjectM3Errors.Count > 0 Then
            PrimarySubjectM3ShowErrors()
            Return
        End If
'End Record Form PrimarySubjectM3 Show method

'Record Form PrimarySubjectM3 BeforeShow tail @66-29BF5BF2
        PrimarySubjectM3Parameters()
        PrimarySubjectM3Data.FillItem(item, IsInsertMode)
        PrimarySubjectM3Holder.DataBind()
        PrimarySubjectM3Button_Insert.Visible=IsInsertMode AndAlso PrimarySubjectM3Operations.AllowInsert
        PrimarySubjectM3Grade.Items.Add(new ListItem("Select Value",""))
        PrimarySubjectM3Grade.Items(0).Selected = True
        item.GradeItems.SetSelection(item.Grade.GetFormattedValue())
        If Not item.GradeItems.GetSelectedItem() Is Nothing Then
            PrimarySubjectM3Grade.SelectedIndex = -1
        End If
        item.GradeItems.CopyTo(PrimarySubjectM3Grade.Items)
        PrimarySubjectM3EnrolDate.Text=item.EnrolDate.GetFormattedValue()
        PrimarySubjectM3hidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        PrimarySubjectM3hidden_ENROLMENT_YEAR.Value = item.hidden_ENROLMENT_YEAR.GetFormattedValue()
        item.Grade1Items.SetSelection(item.Grade1.GetFormattedValue())
        PrimarySubjectM3Grade1.SelectedIndex = -1
        item.Grade1Items.CopyTo(PrimarySubjectM3Grade1.Items)
        item.Grade2Items.SetSelection(item.Grade2.GetFormattedValue())
        PrimarySubjectM3Grade2.SelectedIndex = -1
        item.Grade2Items.CopyTo(PrimarySubjectM3Grade2.Items)
        item.Grade3Items.SetSelection(item.Grade3.GetFormattedValue())
        PrimarySubjectM3Grade3.SelectedIndex = -1
        item.Grade3Items.CopyTo(PrimarySubjectM3Grade3.Items)
        PrimarySubjectM3EnrolDate1.Text=item.EnrolDate1.GetFormattedValue()
        PrimarySubjectM3EnrolDate2.Text=item.EnrolDate2.GetFormattedValue()
        PrimarySubjectM3EnrolDate3.Text=item.EnrolDate3.GetFormattedValue()
        PrimarySubjectM3EnrolDate4.Text=item.EnrolDate4.GetFormattedValue()
        item.Grade4Items.SetSelection(item.Grade4.GetFormattedValue())
        PrimarySubjectM3Grade4.SelectedIndex = -1
        item.Grade4Items.CopyTo(PrimarySubjectM3Grade4.Items)
        item.Grade5Items.SetSelection(item.Grade5.GetFormattedValue())
        PrimarySubjectM3Grade5.SelectedIndex = -1
        item.Grade5Items.CopyTo(PrimarySubjectM3Grade5.Items)
        item.Grade6Items.SetSelection(item.Grade6.GetFormattedValue())
        PrimarySubjectM3Grade6.SelectedIndex = -1
        item.Grade6Items.CopyTo(PrimarySubjectM3Grade6.Items)
        item.Grade7Items.SetSelection(item.Grade7.GetFormattedValue())
        PrimarySubjectM3Grade7.SelectedIndex = -1
        item.Grade7Items.CopyTo(PrimarySubjectM3Grade7.Items)
        item.Grade8Items.SetSelection(item.Grade8.GetFormattedValue())
        PrimarySubjectM3Grade8.SelectedIndex = -1
        item.Grade8Items.CopyTo(PrimarySubjectM3Grade8.Items)
        item.Grade9Items.SetSelection(item.Grade9.GetFormattedValue())
        PrimarySubjectM3Grade9.SelectedIndex = -1
        item.Grade9Items.CopyTo(PrimarySubjectM3Grade9.Items)
        item.Grade10Items.SetSelection(item.Grade10.GetFormattedValue())
        PrimarySubjectM3Grade10.SelectedIndex = -1
        item.Grade10Items.CopyTo(PrimarySubjectM3Grade10.Items)
        item.Grade11Items.SetSelection(item.Grade11.GetFormattedValue())
        PrimarySubjectM3Grade11.SelectedIndex = -1
        item.Grade11Items.CopyTo(PrimarySubjectM3Grade11.Items)
        item.Grade12Items.SetSelection(item.Grade12.GetFormattedValue())
        PrimarySubjectM3Grade12.SelectedIndex = -1
        item.Grade12Items.CopyTo(PrimarySubjectM3Grade12.Items)
'End Record Form PrimarySubjectM3 BeforeShow tail

'RadioButton Grade1 Event BeforeShow. Action Custom Code @89-73254650
    ' -------------------------
	' ERA: 30-Aug-2010|EA| change to vertical flow
	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
	PrimarySubjectM3Grade1.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade1.RepeatColumns = 1
	PrimarySubjectM3Grade1.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade1 Event BeforeShow. Action Custom Code

'RadioButton Grade2 Event BeforeShow. Action Custom Code @91-73254650
    ' -------------------------
    	' ERA: 30-Aug-2010|EA| change to vertical flow
	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
	PrimarySubjectM3Grade2.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade2.RepeatColumns = 1
	PrimarySubjectM3Grade2.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade2 Event BeforeShow. Action Custom Code

'RadioButton Grade3 Event BeforeShow. Action Custom Code @93-73254650
    ' -------------------------
	' ERA: 30-Aug-2010|EA| change to vertical flow
	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
	PrimarySubjectM3Grade3.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade3.RepeatColumns = 1
	PrimarySubjectM3Grade3.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade3 Event BeforeShow. Action Custom Code

'RadioButton Grade4 Event BeforeShow. Action Custom Code @103-73254650
    ' -------------------------
	' ERA: 30-Aug-2010|EA| change to vertical flow
	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
	PrimarySubjectM3Grade4.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade4.RepeatColumns = 1
	PrimarySubjectM3Grade4.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade4 Event BeforeShow. Action Custom Code

'RadioButton Grade5 Event BeforeShow. Action Custom Code @264-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade5.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade5.RepeatColumns = 1
	PrimarySubjectM3Grade5.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade5 Event BeforeShow. Action Custom Code

'RadioButton Grade6 Event BeforeShow. Action Custom Code @265-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade6.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade6.RepeatColumns = 1
	PrimarySubjectM3Grade6.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade6 Event BeforeShow. Action Custom Code

'RadioButton Grade7 Event BeforeShow. Action Custom Code @267-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade7.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade7.RepeatColumns = 1
	PrimarySubjectM3Grade7.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade7 Event BeforeShow. Action Custom Code

'RadioButton Grade8 Event BeforeShow. Action Custom Code @269-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade8.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade8.RepeatColumns = 1
	PrimarySubjectM3Grade8.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade8 Event BeforeShow. Action Custom Code

'RadioButton Grade9 Event BeforeShow. Action Custom Code @271-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade9.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade9.RepeatColumns = 1
	PrimarySubjectM3Grade9.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade9 Event BeforeShow. Action Custom Code

'RadioButton Grade10 Event BeforeShow. Action Custom Code @273-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade10.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade10.RepeatColumns = 1
	PrimarySubjectM3Grade10.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade10 Event BeforeShow. Action Custom Code

'RadioButton Grade11 Event BeforeShow. Action Custom Code @275-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade11.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade11.RepeatColumns = 1
	PrimarySubjectM3Grade11.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade11 Event BeforeShow. Action Custom Code

'RadioButton Grade12 Event BeforeShow. Action Custom Code @277-73254650
    ' -------------------------
    '10 Nov-2016|EA| new fields
    PrimarySubjectM3Grade12.RepeatDirection = RepeatDirection.Vertical
	PrimarySubjectM3Grade12.RepeatColumns = 1
	PrimarySubjectM3Grade12.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton Grade12 Event BeforeShow. Action Custom Code

'Record PrimarySubjectM3 Event BeforeShow. Action Retrieve Value for Control @109-8AD0C2E5
            PrimarySubjectM3hidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record PrimarySubjectM3 Event BeforeShow. Action Retrieve Value for Control

'Record PrimarySubjectM3 Event BeforeShow. Action Retrieve Value for Control @110-F65E2669
            PrimarySubjectM3hidden_ENROLMENT_YEAR.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record PrimarySubjectM3 Event BeforeShow. Action Retrieve Value for Control

'Record PrimarySubjectM3 Event BeforeShow. Action Declare Variable @132-9E0AD76B
            Dim tmp_YEAR_LEVEL As Int64 = -1
'End Record PrimarySubjectM3 Event BeforeShow. Action Declare Variable

'Record PrimarySubjectM3 Event BeforeShow. Action DLookup @133-FFB20B93
            tmp_YEAR_LEVEL = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "YEAR_LEVEL" & " FROM " & "STUDENT_ENROLMENT" & " WHERE " & "STUDENT_ID = " & PrimarySubjectM3hidden_STUDENT_ID.Value  & " AND ENROLMENT_YEAR= " & PrimarySubjectM3hidden_ENROLMENT_YEAR.Value))).Value, Int64)
'End Record PrimarySubjectM3 Event BeforeShow. Action DLookup

'Record PrimarySubjectM3 Event BeforeShow. Action Custom Code @134-73254650
    ' -------------------------
    'ERA - select the grade level from the listbox
		if (tmp_YEAR_LEVEL >=-1 and tmp_YEAR_LEVEL <= 6) then
			PrimarySubjectM3Grade.selectedIndex = tmp_YEAR_LEVEL+1
		end if
    ' -------------------------
'End Record PrimarySubjectM3 Event BeforeShow. Action Custom Code

'Record PrimarySubjectM3 Event BeforeShow. Action Custom Code @278-73254650
    ' -------------------------
    '
    	if (tmp_YEAR_LEVEL >=-1 and tmp_YEAR_LEVEL <= 6) then
    		' direct match to years
			PrimarySubjectM3Grade1.selectedIndex = tmp_YEAR_LEVEL
			PrimarySubjectM3Grade2.selectedIndex = tmp_YEAR_LEVEL
			PrimarySubjectM3Grade3.selectedIndex = tmp_YEAR_LEVEL
			PrimarySubjectM3Grade4.selectedIndex = tmp_YEAR_LEVEL
			'F-2 are ok, and 3-6 select None 
			PrimarySubjectM3Grade5.selectedIndex = tmp_YEAR_LEVEL
			PrimarySubjectM3Grade6.selectedIndex = tmp_YEAR_LEVEL
			' 3-6 only should be -3
			if (tmp_YEAR_LEVEL >=3 and tmp_YEAR_LEVEL <= 6) then
				PrimarySubjectM3Grade7.selectedIndex = tmp_YEAR_LEVEL-3
				PrimarySubjectM3Grade8.selectedIndex = tmp_YEAR_LEVEL-3
				PrimarySubjectM3Grade9.selectedIndex = tmp_YEAR_LEVEL-3
				PrimarySubjectM3Grade10.selectedIndex = tmp_YEAR_LEVEL-3
				PrimarySubjectM3Grade11.selectedIndex = tmp_YEAR_LEVEL-3
				PrimarySubjectM3Grade12.selectedIndex = tmp_YEAR_LEVEL-3
			else
				PrimarySubjectM3Grade7.selectedIndex = 0
				PrimarySubjectM3Grade8.selectedIndex = 0
				PrimarySubjectM3Grade9.selectedIndex = 0
				PrimarySubjectM3Grade10.selectedIndex = 0
				PrimarySubjectM3Grade11.selectedIndex = 0
				PrimarySubjectM3Grade12.selectedIndex = 0
			end if
			
			
		end if
    ' -------------------------
'End Record PrimarySubjectM3 Event BeforeShow. Action Custom Code

'Record Form PrimarySubjectM3 Show method tail @66-F600036A
        If PrimarySubjectM3Errors.Count > 0 Then
            PrimarySubjectM3ShowErrors()
        End If
    End Sub
'End Record Form PrimarySubjectM3 Show method tail

'Record Form PrimarySubjectM3 LoadItemFromRequest method @66-B1F4CC9B

    Protected Sub PrimarySubjectM3LoadItemFromRequest(item As PrimarySubjectM3Item, ByVal EnableValidation As Boolean)
        item.Grade.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade.UniqueID))
        item.Grade.SetValue(PrimarySubjectM3Grade.Value)
        item.GradeItems.CopyFrom(PrimarySubjectM3Grade.Items)
        Try
        item.EnrolDate.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3EnrolDate.UniqueID))
        If ControlCustomValues("PrimarySubjectM3EnrolDate") Is Nothing Then
            item.EnrolDate.SetValue(PrimarySubjectM3EnrolDate.Text)
        Else
            item.EnrolDate.SetValue(ControlCustomValues("PrimarySubjectM3EnrolDate"))
        End If
        Catch ae As ArgumentException
            PrimarySubjectM3Errors.Add("EnrolDate",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrol Date - Primary Year","dd/mm/yyyy"))
        End Try
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3hidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(PrimarySubjectM3hidden_STUDENT_ID.Value)
        item.hidden_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3hidden_ENROLMENT_YEAR.UniqueID))
        item.hidden_ENROLMENT_YEAR.SetValue(PrimarySubjectM3hidden_ENROLMENT_YEAR.Value)
        item.Grade1.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade1.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade1.SelectedItem) Then
            item.Grade1.SetValue(PrimarySubjectM3Grade1.SelectedItem.Value)
        Else
            item.Grade1.Value = Nothing
        End If
        item.Grade1Items.CopyFrom(PrimarySubjectM3Grade1.Items)
        item.Grade2.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade2.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade2.SelectedItem) Then
            item.Grade2.SetValue(PrimarySubjectM3Grade2.SelectedItem.Value)
        Else
            item.Grade2.Value = Nothing
        End If
        item.Grade2Items.CopyFrom(PrimarySubjectM3Grade2.Items)
        item.Grade3.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade3.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade3.SelectedItem) Then
            item.Grade3.SetValue(PrimarySubjectM3Grade3.SelectedItem.Value)
        Else
            item.Grade3.Value = Nothing
        End If
        item.Grade3Items.CopyFrom(PrimarySubjectM3Grade3.Items)
        Try
        item.EnrolDate1.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3EnrolDate1.UniqueID))
        If ControlCustomValues("PrimarySubjectM3EnrolDate1") Is Nothing Then
            item.EnrolDate1.SetValue(PrimarySubjectM3EnrolDate1.Text)
        Else
            item.EnrolDate1.SetValue(ControlCustomValues("PrimarySubjectM3EnrolDate1"))
        End If
        Catch ae As ArgumentException
            PrimarySubjectM3Errors.Add("EnrolDate1",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrol Date - English","dd/mm/yyyy"))
        End Try
        Try
        item.EnrolDate2.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3EnrolDate2.UniqueID))
        If ControlCustomValues("PrimarySubjectM3EnrolDate2") Is Nothing Then
            item.EnrolDate2.SetValue(PrimarySubjectM3EnrolDate2.Text)
        Else
            item.EnrolDate2.SetValue(ControlCustomValues("PrimarySubjectM3EnrolDate2"))
        End If
        Catch ae As ArgumentException
            PrimarySubjectM3Errors.Add("EnrolDate2",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrol Date - English","dd/mm/yyyy"))
        End Try
        Try
        item.EnrolDate3.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3EnrolDate3.UniqueID))
        If ControlCustomValues("PrimarySubjectM3EnrolDate3") Is Nothing Then
            item.EnrolDate3.SetValue(PrimarySubjectM3EnrolDate3.Text)
        Else
            item.EnrolDate3.SetValue(ControlCustomValues("PrimarySubjectM3EnrolDate3"))
        End If
        Catch ae As ArgumentException
            PrimarySubjectM3Errors.Add("EnrolDate3",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrol Date - Maths","dd/mm/yyyy"))
        End Try
        Try
        item.EnrolDate4.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3EnrolDate4.UniqueID))
        If ControlCustomValues("PrimarySubjectM3EnrolDate4") Is Nothing Then
            item.EnrolDate4.SetValue(PrimarySubjectM3EnrolDate4.Text)
        Else
            item.EnrolDate4.SetValue(ControlCustomValues("PrimarySubjectM3EnrolDate4"))
        End If
        Catch ae As ArgumentException
            PrimarySubjectM3Errors.Add("EnrolDate4",String.Format(Resources.strings.CCS_IncorrectFormat,"Enrol Date - Maths","dd/mm/yyyy"))
        End Try
        item.Grade4.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade4.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade4.SelectedItem) Then
            item.Grade4.SetValue(PrimarySubjectM3Grade4.SelectedItem.Value)
        Else
            item.Grade4.Value = Nothing
        End If
        item.Grade4Items.CopyFrom(PrimarySubjectM3Grade4.Items)
        item.Grade5.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade5.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade5.SelectedItem) Then
            item.Grade5.SetValue(PrimarySubjectM3Grade5.SelectedItem.Value)
        Else
            item.Grade5.Value = Nothing
        End If
        item.Grade5Items.CopyFrom(PrimarySubjectM3Grade5.Items)
        item.Grade6.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade6.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade6.SelectedItem) Then
            item.Grade6.SetValue(PrimarySubjectM3Grade6.SelectedItem.Value)
        Else
            item.Grade6.Value = Nothing
        End If
        item.Grade6Items.CopyFrom(PrimarySubjectM3Grade6.Items)
        item.Grade7.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade7.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade7.SelectedItem) Then
            item.Grade7.SetValue(PrimarySubjectM3Grade7.SelectedItem.Value)
        Else
            item.Grade7.Value = Nothing
        End If
        item.Grade7Items.CopyFrom(PrimarySubjectM3Grade7.Items)
        item.Grade8.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade8.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade8.SelectedItem) Then
            item.Grade8.SetValue(PrimarySubjectM3Grade8.SelectedItem.Value)
        Else
            item.Grade8.Value = Nothing
        End If
        item.Grade8Items.CopyFrom(PrimarySubjectM3Grade8.Items)
        item.Grade9.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade9.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade9.SelectedItem) Then
            item.Grade9.SetValue(PrimarySubjectM3Grade9.SelectedItem.Value)
        Else
            item.Grade9.Value = Nothing
        End If
        item.Grade9Items.CopyFrom(PrimarySubjectM3Grade9.Items)
        item.Grade10.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade10.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade10.SelectedItem) Then
            item.Grade10.SetValue(PrimarySubjectM3Grade10.SelectedItem.Value)
        Else
            item.Grade10.Value = Nothing
        End If
        item.Grade10Items.CopyFrom(PrimarySubjectM3Grade10.Items)
        item.Grade11.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade11.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade11.SelectedItem) Then
            item.Grade11.SetValue(PrimarySubjectM3Grade11.SelectedItem.Value)
        Else
            item.Grade11.Value = Nothing
        End If
        item.Grade11Items.CopyFrom(PrimarySubjectM3Grade11.Items)
        item.Grade12.IsEmpty = IsNothing(Request.Form(PrimarySubjectM3Grade12.UniqueID))
        If Not IsNothing(PrimarySubjectM3Grade12.SelectedItem) Then
            item.Grade12.SetValue(PrimarySubjectM3Grade12.SelectedItem.Value)
        Else
            item.Grade12.Value = Nothing
        End If
        item.Grade12Items.CopyFrom(PrimarySubjectM3Grade12.Items)
        If EnableValidation Then
            item.Validate(PrimarySubjectM3Data)
        End If
        PrimarySubjectM3Errors.Add(item.errors)
    End Sub
'End Record Form PrimarySubjectM3 LoadItemFromRequest method

'Record Form PrimarySubjectM3 GetRedirectUrl method @66-48357061

    Protected Function GetPrimarySubjectM3RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Subject_maintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form PrimarySubjectM3 GetRedirectUrl method

'Record Form PrimarySubjectM3 ShowErrors method @66-BC7A7184

    Protected Sub PrimarySubjectM3ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To PrimarySubjectM3Errors.Count - 1
        Select Case PrimarySubjectM3Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & PrimarySubjectM3Errors(i)
        End Select
        Next i
        PrimarySubjectM3Error.Visible = True
        PrimarySubjectM3ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form PrimarySubjectM3 ShowErrors method

'Record Form PrimarySubjectM3 Insert Operation @66-B0B0E8E6

    Protected Sub PrimarySubjectM3_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PrimarySubjectM3Item = New PrimarySubjectM3Item()
        Dim ExecuteFlag As Boolean = True
        PrimarySubjectM3IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form PrimarySubjectM3 Insert Operation

'Button Button_Insert OnClick. @70-CCDB7369
        If CType(sender,Control).ID = "PrimarySubjectM3Button_Insert" Then
            RedirectUrl = GetPrimarySubjectM3RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @70-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form PrimarySubjectM3 BeforeInsert tail @66-54F7807E
    PrimarySubjectM3Parameters()
    PrimarySubjectM3LoadItemFromRequest(item, EnableValidation)
    If PrimarySubjectM3Operations.AllowInsert Then
        ErrorFlag=(PrimarySubjectM3Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                PrimarySubjectM3Data.InsertItem(item)
            Catch ex As Exception
                PrimarySubjectM3Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form PrimarySubjectM3 BeforeInsert tail

'Record PrimarySubjectM3 Event AfterInsert. Action Custom Code @200-73254650
    ' -------------------------
    'ERA:21-Nov-2013|EA| collect the ticked extra subject checkboxes and do an insert for each
    '	, using the value as the subject ID (will already have Student Id, and can default Date to today)

	' go through each tickbox and  do the insert for each on, using the new Sub that does the loading.
	'  The 'item' is the data structure from the form, set up above in the Insert code.
	' The new Sub is at the end of this file, before the End Namespace.
	'Semester 1 subjects
	'ERA:21-Nov-2014|EA| (yes 1 year since last changes) make the Semester variable, but default to '1'
	' also add subjects Year 4 - Geography and Arts Inquiry; 5 - Geography (replaces Handwriting)
	'
	'17-Nov-2016|EA| (unfuddle #783) remove the Primary 3-6 tickboxes and replace with 4 new groups
	' and so remove all the extra tickbox coding.
	
	dim tmpSubjectID, tmpStudentID, tmpEnrolYear, retval as Integer
	dim tmpSem1 as Char = "1"
	dim tmpSem2 as Char = "2"
	tmpStudentID = item.hidden_STUDENT_ID.GetFormattedValue()
	tmpEnrolYear = item.hidden_ENROLMENT_YEAR.GetFormattedValue()
	'tmpSemester = "1"	//21-Nov-2014|EA| use rbSemesterLeft instead (is 1,2)
	'tmpSemester = item.rbSemesterLeft.GetFormattedValue()
	dim tmpError as string = "Errors: "
	
	Dim tmpUsername As String
	If (Session("UserID").ToString = "") Then
		tmpUsername = Left(Session.SessionID.ToString, 8)
	Else
		tmpUsername = (Session("UserID").ToString)
	End If
	
	' don't need to check each one, but will, and can send subject ID to the stored proc
	' The Unchecked value is '0' so can check without needing to compare to Checked value
' ** sample retained in case needed for any other tickbox subjects **
'		If PrimarySubjectM3cbExtra_49_History.Checked Then
'            tmpSubjectID = (item.cbExtra_49_HistoryCheckedValue.Value)
'            retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSemester, tmpUsername)
'            tmpError = tmpError & "49his(" & tmpSubjectID & " : " & retval & ") "
'        End If

	'17-Nov-2016|EA| Integrated (F-2) Sem 1 & 2 (control name Grade5 & 6)
	If (PrimarySubjectM3Grade5.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade5.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem1, tmpUsername)
		tmpError = tmpError & "Integrated1(" & tmpSubjectID & " : " & retval & ") "
	End If

	If (PrimarySubjectM3Grade6.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade6.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem2, tmpUsername)
		tmpError = tmpError & "Integrated2(" & tmpSubjectID & " : " & retval & ") "
	End If

	'17-Nov-2016|EA| Human / Arts (3-6) Sem 1 & 2 (control name Grade7 & 8)
	If (PrimarySubjectM3Grade7.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade7.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem1, tmpUsername)
		tmpError = tmpError & "HumArts1(" & tmpSubjectID & " : " & retval & ") "
	End If

	If (PrimarySubjectM3Grade8.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade8.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem2, tmpUsername)
		tmpError = tmpError & "HumArts2(" & tmpSubjectID & " : " & retval & ") "
	End If

	'17-Nov-2016|EA| Science/Design (3-6) Sem 1 & 2 (control name Grade9 & 10)
	If (PrimarySubjectM3Grade9.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade9.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem1, tmpUsername)
		tmpError = tmpError & "Science1(" & tmpSubjectID & " : " & retval & ") "
	End If

	If (PrimarySubjectM3Grade10.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade10.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem2, tmpUsername)
		tmpError = tmpError & "Science2(" & tmpSubjectID & " : " & retval & ") "
	End If

	'17-Nov-2016|EA| Health & PE (3-6) Sem 1 & 2 (control name Grade11 & 12)
	If (PrimarySubjectM3Grade11.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade11.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem1, tmpUsername)
		tmpError = tmpError & "HPE1(" & tmpSubjectID & " : " & retval & ") "
	End If

	If (PrimarySubjectM3Grade12.SelectedItem.Value > 0) Then
		tmpSubjectID = PrimarySubjectM3Grade12.SelectedItem.Value
		retval = ExtraInsertItem(tmpStudentID, tmpEnrolYear, tmpSubjectID, tmpSem2, tmpUsername)
		tmpError = tmpError & "HPE2(" & tmpSubjectID & " : " & retval & ") "
	End If

      ' may need to change retval to be 0 if no errors and 1 or -1 if errors and check for != 0
      'PrimarySubjectM3Errors.Add("Form","Extra : " & tmpError)
	    
    ' -------------------------
'End Record PrimarySubjectM3 Event AfterInsert. Action Custom Code

'Record Form PrimarySubjectM3 AfterInsert tail  @66-E6684CAE
        End If
        ErrorFlag=(PrimarySubjectM3Errors.Count > 0)
        If ErrorFlag Then
            PrimarySubjectM3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form PrimarySubjectM3 AfterInsert tail 

'Record Form PrimarySubjectM3 Update Operation @66-AD0217A3

    Protected Sub PrimarySubjectM3_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PrimarySubjectM3Item = New PrimarySubjectM3Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        PrimarySubjectM3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form PrimarySubjectM3 Update Operation

'Record Form PrimarySubjectM3 Before Update tail @66-402661B5
        PrimarySubjectM3Parameters()
        PrimarySubjectM3LoadItemFromRequest(item, EnableValidation)
'End Record Form PrimarySubjectM3 Before Update tail

'Record Form PrimarySubjectM3 Update Operation tail @66-4FCBC485
        ErrorFlag=(PrimarySubjectM3Errors.Count > 0)
        If ErrorFlag Then
            PrimarySubjectM3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form PrimarySubjectM3 Update Operation tail

'Record Form PrimarySubjectM3 Delete Operation @66-21DEDFF9
    Protected Sub PrimarySubjectM3_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        PrimarySubjectM3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As PrimarySubjectM3Item = New PrimarySubjectM3Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form PrimarySubjectM3 Delete Operation

'Record Form BeforeDelete tail @66-402661B5
        PrimarySubjectM3Parameters()
        PrimarySubjectM3LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @66-5C574CA4
        If ErrorFlag Then
            PrimarySubjectM3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form PrimarySubjectM3 Cancel Operation @66-7A58E41A

    Protected Sub PrimarySubjectM3_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PrimarySubjectM3Item = New PrimarySubjectM3Item()
        PrimarySubjectM3IsSubmitted = True
        Dim RedirectUrl As String = ""
        PrimarySubjectM3LoadItemFromRequest(item, True)
'End Record Form PrimarySubjectM3 Cancel Operation

'Record Form PrimarySubjectM3 Cancel Operation tail @66-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form PrimarySubjectM3 Cancel Operation tail

'Record Form STUDENT Parameters @232-669F6334

    Protected Sub STUDENTParameters()
        Dim item As new STUDENTItem
        Try
            STUDENTData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENTData.SesUserId = TextParameter.GetParam("UserId", ParameterSourceType.Session, "", Nothing, false)
        Catch e As Exception
            STUDENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT Parameters

'Record Form STUDENT Show method @232-37C1ACAF
    Protected Sub STUDENTShow()
        If STUDENTOperations.None Then
            STUDENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENTItem = STUDENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENTOperations.AllowRead
        STUDENTErrors.Add(item.errors)
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
            Return
        End If
'End Record Form STUDENT Show method

'Record Form STUDENT BeforeShow tail @232-C190D925
        STUDENTParameters()
        STUDENTData.FillItem(item, IsInsertMode)
        STUDENTHolder.DataBind()
        STUDENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
        STUDENTSURNAME.Text = Server.HtmlEncode(item.SURNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTFIRST_NAME.Text = Server.HtmlEncode(item.FIRST_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STUDENT BeforeShow tail

'Record STUDENT Event BeforeShow. Action Declare Variable @238-77A22F62
            Dim tmpNonCustomCount As Int64 = 0
'End Record STUDENT Event BeforeShow. Action Declare Variable

'Record STUDENT Event BeforeShow. Action Declare Variable @239-404A0B8F
            Dim tmpStudentID As Int64 = 0
'End Record STUDENT Event BeforeShow. Action Declare Variable

'Record STUDENT Event BeforeShow. Action Retrieve Value for Variable @240-0F1C0A2D
            tmpStudentID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Record STUDENT Event BeforeShow. Action Retrieve Value for Variable

'Record STUDENT Event BeforeShow. Action DLookup @241-D5FAC1EF
            tmpNonCustomCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "STUDENT_SUBJECT" & " WHERE " & "MODULE_CUSTOMPROGRAM is null AND SUBJ_ENROL_STATUS in ('C','D') AND ENROLMENT_YEAR=YEAR(getdate()) AND STUDENT_ID = " & tmpStudentID & " "))).Value, Int64)
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action Custom Code @242-73254650
    ' -------------------------
    'ERA: Feb-2014|EA| hide the All No CLP button if there are none to update
	if (tmpNonCustomCount = 0 or NewGrid1Data.RecordCount = 0) then
		STUDENTHolder.Visible = false
	end if
    ' -------------------------
'End Record STUDENT Event BeforeShow. Action Custom Code

'Record Form STUDENT Show method tail @232-F9DBAD9A
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT Show method tail

'Record Form STUDENT LoadItemFromRequest method @232-5D9FCB8D

    Protected Sub STUDENTLoadItemFromRequest(item As STUDENTItem, ByVal EnableValidation As Boolean)
        If EnableValidation Then
            item.Validate(STUDENTData)
        End If
        STUDENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT LoadItemFromRequest method

'Record Form STUDENT GetRedirectUrl method @232-CB42CCCA

    Protected Function GetSTUDENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Subject_maintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT GetRedirectUrl method

'Record Form STUDENT ShowErrors method @232-0193A443

    Protected Sub STUDENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENTErrors.Count - 1
        Select Case STUDENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENTErrors(i)
        End Select
        Next i
        STUDENTError.Visible = True
        STUDENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT ShowErrors method

'Record Form STUDENT Insert Operation @232-E5B35CBF

    Protected Sub STUDENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Insert Operation

'Record Form STUDENT BeforeInsert tail @232-9400BDAA
    STUDENTParameters()
    STUDENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT BeforeInsert tail

'Record Form STUDENT AfterInsert tail  @232-98ACA329
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT AfterInsert tail 

'Record Form STUDENT Update Operation @232-5F39C5C9

    Protected Sub STUDENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Update Operation

'Button Button_Update OnClick. @234-C6DD6D39
        If CType(sender,Control).ID = "STUDENTButton_Update" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @234-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT Before Update tail @232-6A432CC4
        STUDENTParameters()
        STUDENTLoadItemFromRequest(item, EnableValidation)
        If STUDENTOperations.AllowUpdate Then
        ErrorFlag = (STUDENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENTData.UpdateItem(item)
            Catch ex As Exception
                STUDENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT Before Update tail

'Record Form STUDENT Update Operation tail @232-C6B64346
        End If
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT Update Operation tail

'Record Form STUDENT Delete Operation @232-31D1E637
    Protected Sub STUDENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT Delete Operation

'Record Form BeforeDelete tail @232-9400BDAA
        STUDENTParameters()
        STUDENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @232-73926DB1
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT Cancel Operation @232-CCB3062A

    Protected Sub STUDENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENTLoadItemFromRequest(item, True)
'End Record Form STUDENT Cancel Operation

'Record Form STUDENT Cancel Operation tail @232-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT Cancel Operation tail

'EditableGrid CORESUBJECTS Bind @283-4055077B
    Protected Sub CORESUBJECTSBind()
        If CORESUBJECTSOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"CORESUBJECTS",GetType(CORESUBJECTSDataProvider.SortFields), 30, 100)
        End If
'End EditableGrid CORESUBJECTS Bind

'EditableGrid Form CORESUBJECTS BeforeShow tail @283-26B0D15B
        CORESUBJECTSParameters()
        CORESUBJECTSData.SortField = CType(ViewState("CORESUBJECTSSortField"), CORESUBJECTSDataProvider.SortFields)
        CORESUBJECTSData.SortDir = CType(ViewState("CORESUBJECTSSortDir"), SortDirections)
        CORESUBJECTSData.PageNumber = CType(ViewState("CORESUBJECTSPageNumber"), Integer)
        CORESUBJECTSData.RecordsPerPage = CType(ViewState("CORESUBJECTSPageSize"), Integer)
        CORESUBJECTSRepeater.DataSource = CORESUBJECTSData.GetResultSet(PagesCount, CORESUBJECTSOperations)
        ViewState("CORESUBJECTSPagesCount") = PagesCount
        ViewState("CORESUBJECTSFormState") = New Hashtable()
        ViewState("CORESUBJECTSRowState") = New Hashtable()
        CORESUBJECTSRepeater.DataBind()
        Dim item As CORESUBJECTSItem = CORESUBJECTSDataItem
        If IsNothing(item) Then item = New CORESUBJECTSItem()
        FooterIndex = CORESUBJECTSRepeater.Controls.Count - 1
        Dim CORESUBJECTSButton_Submit As System.Web.UI.WebControls.Button = DirectCast(CORESUBJECTSRepeater.Controls(FooterIndex).FindControl("CORESUBJECTSButton_Submit"),System.Web.UI.WebControls.Button)


        CORESUBJECTSButton_Submit.Visible = CORESUBJECTSOperations.Editable
        If Not CType(CORESUBJECTSRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            CORESUBJECTSRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If CORESUBJECTSErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(CORESUBJECTSRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(CORESUBJECTSRepeater.Controls(0).FindControl("CORESUBJECTSError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In CORESUBJECTSErrors
                ErrorLabel.Text += CORESUBJECTSErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form CORESUBJECTS BeforeShow tail

'EditableGrid CORESUBJECTS Bind tail @283-0F716C9B
        CORESUBJECTSShowErrors(New ArrayList(CType(CORESUBJECTSRepeater.DataSource, ICollection)), CORESUBJECTSRepeater.Items)
    End Sub
'End EditableGrid CORESUBJECTS Bind tail

'EditableGrid CORESUBJECTS Table Parameters @283-36617E9B
    Protected Sub CORESUBJECTSParameters()
        Try
        Dim item As new CORESUBJECTSItem
            CORESUBJECTSData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            CORESUBJECTSData.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            CORESUBJECTSData.CtrlDEFAULT_SEMESTER = TextParameter.GetParam(item.DEFAULT_SEMESTER.Value, ParameterSourceType.Control, "", Nothing, false)
            CORESUBJECTSData.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", Nothing, false)
            CORESUBJECTSData.ExprKey182 = IntegerParameter.GetParam(1, ParameterSourceType.Expression, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = CORESUBJECTSRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(CORESUBJECTSRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid CORESUBJECTS: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid CORESUBJECTS Table Parameters

'EditableGrid CORESUBJECTS ItemDataBound event @283-FC223FAA
    Protected Sub CORESUBJECTSItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As CORESUBJECTSItem = DirectCast(e.Item.DataItem, CORESUBJECTSItem)
        Dim Item as CORESUBJECTSItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            CORESUBJECTSCurrentRowNumber = CORESUBJECTSCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("CORESUBJECTSFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("CORESUBJECTSRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("CORESUBJECTSSUBJECT_ID").UniqueID) = DataItem.SUBJECT_ID.Value
            ViewState(e.Item.FindControl("CORESUBJECTSSUBJECT_ABBREV").UniqueID) = DataItem.SUBJECT_ABBREV.Value
            ViewState(e.Item.FindControl("CORESUBJECTSSUBJECT_TITLE").UniqueID) = DataItem.SUBJECT_TITLE.Value
            ViewState(e.Item.FindControl("CORESUBJECTSYEAR_LEVEL").UniqueID) = DataItem.YEAR_LEVEL.Value
            ViewState(e.Item.FindControl("CORESUBJECTSCORE_YEARLEVELS").UniqueID) = DataItem.CORE_YEARLEVELS.Value
            ViewState(e.Item.FindControl("CORESUBJECTSlblClass").UniqueID) = DataItem.lblClass.Value
            Dim CORESUBJECTSSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim CORESUBJECTSSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim CORESUBJECTSSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim CORESUBJECTSYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim CORESUBJECTSCORE_YEARLEVELS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSCORE_YEARLEVELS"),System.Web.UI.WebControls.Literal)
            Dim CORESUBJECTSDEFAULT_SEMESTER As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("CORESUBJECTSDEFAULT_SEMESTER"),System.Web.UI.WebControls.RadioButtonList)
            Dim CORESUBJECTSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("CORESUBJECTSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim CORESUBJECTSlblClass As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("CORESUBJECTSlblClass"),System.Web.UI.WebControls.Literal)
            If Not Item.RawData Is Nothing
            CType(Page,CCPage).ControlAttributes.Add(CORESUBJECTSCheckBox_Delete,New CCSControlAttribute("CoreYearLevels", FieldType._Text, item.RawData("CORE_YEARLEVELS")))
            End If
            CType(Page,CCPage).ControlAttributes.Add(CORESUBJECTSRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, CORESUBJECTSCurrentRowNumber), AttributeOption.Multiple)
            DataItem.DEFAULT_SEMESTERItems.SetSelection(DataItem.DEFAULT_SEMESTER.GetFormattedValue())
            CORESUBJECTSDEFAULT_SEMESTER.SelectedIndex = -1
            DataItem.DEFAULT_SEMESTERItems.CopyTo(CORESUBJECTSDEFAULT_SEMESTER.Items, True)
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                CORESUBJECTSCheckBox_Delete.Checked = True
            End If
        End If
'End EditableGrid CORESUBJECTS ItemDataBound event

'CORESUBJECTS control Before Show @283-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End CORESUBJECTS control Before Show

'Get Control @292-0ECEAFE6
            Dim CORESUBJECTSDEFAULT_SEMESTER As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("CORESUBJECTSDEFAULT_SEMESTER"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton DEFAULT_SEMESTER Event BeforeShow. Action Custom Code @325-73254650
    ' -------------------------
    '4-Mar-2019|EA| for handling small number of 'B', only change to 'B' (and only 'B') and autoselect
    	if (DataItem.DEFAULT_SEMESTER.GetFormattedValue() = "B") then
            CORESUBJECTSDEFAULT_SEMESTER.Items.Clear()
            CORESUBJECTSDEFAULT_SEMESTER.Items.Add(new ListItem("Both Semesters", "B"))
            CORESUBJECTSDEFAULT_SEMESTER.Items.FindByValue("B").Selected = true
    	end if

    ' -------------------------
'End RadioButton DEFAULT_SEMESTER Event BeforeShow. Action Custom Code

'RadioButton DEFAULT_SEMESTER Event BeforeShow. Action Custom Code @332-73254650
    ' -------------------------
     '6-Mar-2019|EA| and if a child subject then disable semester selection
     if (DataItem.lblClass.GetFormattedValue() = "AltRow GroupChild") then
		ControlAttributes.Add(CORESUBJECTSDEFAULT_SEMESTER, New CCSControlAttribute("disabled", FieldType._Text, "true"))
  	End If
    ' -------------------------
'End RadioButton DEFAULT_SEMESTER Event BeforeShow. Action Custom Code

'Get Control @294-FED7D19C
            Dim CORESUBJECTSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("CORESUBJECTSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
'End Get Control

'CheckBox CheckBox_Delete Event BeforeShow. Action Custom Code @331-73254650
    ' -------------------------
    '6-Mar-2019|EA|if this is a child, then set checked 'disabled' but ticked
    if (DataItem.lblClass.GetFormattedValue() = "AltRow GroupChild") then
		'ControlAttributes.Add(CORESUBJECTSCheckBox_Delete, New CCSControlAttribute("disabled", FieldType._Text, "true"))
		CORESUBJECTSCheckBox_Delete.visible = false
    End If

    ' -------------------------
'End CheckBox CheckBox_Delete Event BeforeShow. Action Custom Code

'CORESUBJECTS control Before Show tail @283-477CF3C9
        End If
'End CORESUBJECTS control Before Show tail

'EditableGrid CORESUBJECTS BeforeShowRow event @283-1570B8D7
        If Not IsNothing(Item) Then CORESUBJECTSDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid CORESUBJECTS BeforeShowRow event

'EditableGrid CORESUBJECTS Event BeforeShowRow. Action Custom Code @298-73254650
    ' -------------------------
    ' 30-Mar-2017|EA| if subject_id = 0 then don't allow 'delete' (Enrol)
    Dim CORESUBJECTSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("CORESUBJECTSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
    Dim CORESUBJECTSDEFAULT_SEMESTER As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("CORESUBJECTSDEFAULT_SEMESTER"),System.Web.UI.WebControls.RadioButtonList)
    if (DataItem.SUBJECT_ID.Value = "0") then
    	CORESUBJECTSCheckBox_Delete.Visible = false
    	CORESUBJECTSDEFAULT_SEMESTER.Visible = false
    end if
    ' -------------------------
'End EditableGrid CORESUBJECTS Event BeforeShowRow. Action Custom Code

'EditableGrid CORESUBJECTS BeforeShowRow event tail @283-477CF3C9
        End If
'End EditableGrid CORESUBJECTS BeforeShowRow event tail

'EditableGrid CORESUBJECTS ItemDataBound event tail @283-E31F8E2A
    End Sub
'End EditableGrid CORESUBJECTS ItemDataBound event tail

'EditableGrid CORESUBJECTS GetRedirectUrl method @283-AC53C974
    Protected Function GetCORESUBJECTSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetCORESUBJECTSRedirectUrl(ByVal redirectString As String) As String
        Return GetCORESUBJECTSRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid CORESUBJECTS GetRedirectUrl method

'EditableGrid CORESUBJECTS ShowErrors method @283-A74B5C29
    Protected Function CORESUBJECTSShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), CORESUBJECTSItem).IsUpdated Then col(CType(items(i), CORESUBJECTSItem).RowId).Visible = False
            If (CType(items(i), CORESUBJECTSItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), CORESUBJECTSItem).errors.Count - 1
                Select CType(items(i), CORESUBJECTSItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), CORESUBJECTSItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), CORESUBJECTSItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), CORESUBJECTSItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid CORESUBJECTS ShowErrors method

'EditableGrid CORESUBJECTS ItemCommand event @283-61B5A8D6
    Protected Sub CORESUBJECTSItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = CORESUBJECTSRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid CORESUBJECTS ItemCommand event

'Button Button_Submit OnClick. @295-62CE00F5
        If Ctype(e.CommandSource,Control).ID = "CORESUBJECTSButton_Submit" Then
            RedirectUrl  = GetCORESUBJECTSRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @295-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'EditableGrid Form CORESUBJECTS ItemCommand event tail @283-F75012A6
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("CORESUBJECTSSortDir"), SortDirections) = SortDirections._Asc And ViewState("CORESUBJECTSSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("CORESUBJECTSSortDir") = SortDirections._Desc
                Else
                    ViewState("CORESUBJECTSSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("CORESUBJECTSSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As CORESUBJECTSDataProvider.SortFields = 0
            ViewState("CORESUBJECTSSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("CORESUBJECTSPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("CORESUBJECTSPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("CORESUBJECTSPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("CORESUBJECTSPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            CORESUBJECTSIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = CORESUBJECTSRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("CORESUBJECTSFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("CORESUBJECTSRowState"), Hashtable)
            CORESUBJECTSParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim CORESUBJECTSSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSSUBJECT_ID"),System.Web.UI.WebControls.Literal)
                    Dim CORESUBJECTSSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
                    Dim CORESUBJECTSSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
                    Dim CORESUBJECTSYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
                    Dim CORESUBJECTSCORE_YEARLEVELS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSCORE_YEARLEVELS"),System.Web.UI.WebControls.Literal)
                    Dim CORESUBJECTSDEFAULT_SEMESTER As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("CORESUBJECTSDEFAULT_SEMESTER"),System.Web.UI.WebControls.RadioButtonList)
                    Dim CORESUBJECTSCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("CORESUBJECTSCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim CORESUBJECTSlblClass As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("CORESUBJECTSlblClass"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As CORESUBJECTSItem = New CORESUBJECTSItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("CORESUBJECTSCheckBox_Delete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.SUBJECT_ID.Value = ViewState(CORESUBJECTSSUBJECT_ID.UniqueID)
                    item.SUBJECT_ABBREV.Value = ViewState(CORESUBJECTSSUBJECT_ABBREV.UniqueID)
                    item.SUBJECT_TITLE.Value = ViewState(CORESUBJECTSSUBJECT_TITLE.UniqueID)
                    item.YEAR_LEVEL.Value = ViewState(CORESUBJECTSYEAR_LEVEL.UniqueID)
                    item.CORE_YEARLEVELS.Value = ViewState(CORESUBJECTSCORE_YEARLEVELS.UniqueID)
                    item.lblClass.Value = ViewState(CORESUBJECTSlblClass.UniqueID)
                    item.DEFAULT_SEMESTER.IsEmpty = IsNothing(Request.Form(CORESUBJECTSDEFAULT_SEMESTER.UniqueID))
                    If Not IsNothing(CORESUBJECTSDEFAULT_SEMESTER.SelectedItem) Then
                        item.DEFAULT_SEMESTER.SetValue(CORESUBJECTSDEFAULT_SEMESTER.SelectedItem.Value)
                    Else
                        item.DEFAULT_SEMESTER.Value = Nothing
                    End If
                    item.DEFAULT_SEMESTERItems.CopyFrom(CORESUBJECTSDEFAULT_SEMESTER.Items)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(CORESUBJECTSData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form CORESUBJECTS ItemCommand event tail

'EditableGrid CORESUBJECTS Update @283-8E6BA449
            If BindAllowed Then
                Try
                    CORESUBJECTSParameters()
                    CORESUBJECTSData.Update(items, CORESUBJECTSOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(CORESUBJECTSRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(CORESUBJECTSRepeater.Controls(0).FindControl("CORESUBJECTSError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid CORESUBJECTS Update

'EditableGrid CORESUBJECTS After Update @283-4DF8CFB4
                End Try
                If CORESUBJECTSShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                CORESUBJECTSShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                CORESUBJECTSBind()
            End If
        End Sub
'End EditableGrid CORESUBJECTS After Update

'Grid NewGrid1 Bind @3-644FBF6C

    Protected Sub NewGrid1Bind()
        If Not NewGrid1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"NewGrid1",GetType(NewGrid1DataProvider.SortFields), 80, 100)
        End If
'End Grid NewGrid1 Bind

'Grid Form NewGrid1 BeforeShow tail @3-1279D7B8
        NewGrid1Parameters()
        NewGrid1Data.SortField = CType(ViewState("NewGrid1SortField"),NewGrid1DataProvider.SortFields)
        NewGrid1Data.SortDir = CType(ViewState("NewGrid1SortDir"),SortDirections)
        NewGrid1Data.PageNumber = CInt(ViewState("NewGrid1PageNumber"))
        NewGrid1Data.RecordsPerPage = CInt(ViewState("NewGrid1PageSize"))
        NewGrid1Repeater.DataSource = NewGrid1Data.GetResultSet(PagesCount, NewGrid1Operations)
        ViewState("NewGrid1PagesCount") = PagesCount
        Dim item As NewGrid1Item = New NewGrid1Item()
        If Not Item.RawData Is Nothing
        CType(Page,CCPage).ControlAttributes.Add(NewGrid1Repeater,New CCSControlAttribute("rowStyle", FieldType._Text, item.RawData("grouprowtype")))
        End If
        NewGrid1Repeater.DataBind
        FooterIndex = NewGrid1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            NewGrid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim NewGrid1lblSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(NewGrid1Repeater.Controls(0).FindControl("NewGrid1lblSTUDENT_ID"),System.Web.UI.WebControls.Literal)
        Dim NewGrid1lblENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(NewGrid1Repeater.Controls(0).FindControl("NewGrid1lblENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
        Dim NewGrid1NewGrid1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(NewGrid1Repeater.Controls(0).FindControl("NewGrid1NewGrid1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(NewGrid1Repeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Enrolment_DateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(NewGrid1Repeater.Controls(0).FindControl("Sorter_Enrolment_DateSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_End_DateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(NewGrid1Repeater.Controls(0).FindControl("Sorter_End_DateSorter"),DECV_PROD2007.Controls.Sorter)

        NewGrid1lblSTUDENT_ID.Text = Server.HtmlEncode(item.lblSTUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        NewGrid1lblENROLMENT_YEAR.Text = Server.HtmlEncode(item.lblENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        NewGrid1NewGrid1_TotalRecords.Text = Server.HtmlEncode(item.NewGrid1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form NewGrid1 BeforeShow tail

'Label NewGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records @7-610BEFE1
            NewGrid1NewGrid1_TotalRecords.Text = NewGrid1Data.RecordCount.ToString()
'End Label NewGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid NewGrid1 Event BeforeShow. Action Retrieve Value for Control @26-44D3AE8F
        NewGrid1lblSTUDENT_ID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Grid NewGrid1 Event BeforeShow. Action Retrieve Value for Control

'Grid NewGrid1 Event BeforeShow. Action Retrieve Value for Control @27-3B02B67A
        NewGrid1lblENROLMENT_YEAR.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Grid NewGrid1 Event BeforeShow. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL   'ERA: Apr-2013|EA| hide the All No CLP button if there are none to update
'DEL  	if (tmpNonCustomCount > 0 or  NewGrid1Data.RecordCount = 0) then
'DEL  		NewGrid1buttonNoCLP.Visible = false
'DEL  	end if
'DEL      ' -------------------------


'Grid NewGrid1 Bind tail @3-E31F8E2A
    End Sub
'End Grid NewGrid1 Bind tail

'Grid NewGrid1 Table Parameters @3-97DD3880

    Protected Sub NewGrid1Parameters()
        Try
            NewGrid1Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
            NewGrid1Data.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=NewGrid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(NewGrid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid NewGrid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid NewGrid1 Table Parameters

'Grid NewGrid1 ItemDataBound event @3-F7D58E96

    Protected Sub NewGrid1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as NewGrid1Item = CType(e.Item.DataItem,NewGrid1Item)
        Dim Item as NewGrid1Item = DataItem
        Dim FormDataSource As NewGrid1Item() = CType(NewGrid1Repeater.DataSource, NewGrid1Item())
        Dim NewGrid1DataRows As Integer = FormDataSource.Length
        Dim NewGrid1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            NewGrid1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(NewGrid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, NewGrid1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim NewGrid1SUBJECT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("NewGrid1SUBJECT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim NewGrid1SUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1SUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1Course_Distribution As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1Course_Distribution"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1SEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1SEMESTER"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1SUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1SUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1Enrolment_Date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1Enrolment_Date"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1End_Date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1End_Date"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1CUSTOM_LP_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1CUSTOM_LP_display"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1NEXT_MODULE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1NEXT_MODULE"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1TeacherID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1TeacherID"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1NON_SUBMITTING_FLAG_display As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1NON_SUBMITTING_FLAG_display"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1SUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim NewGrid1lblClass As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewGrid1lblClass"),System.Web.UI.WebControls.Literal)
            DataItem.SUBJECT_IDHref = "StudentSubject_Details_maintain.aspx"
            NewGrid1SUBJECT_ID.HRef = DataItem.SUBJECT_IDHref & DataItem.SUBJECT_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid NewGrid1 ItemDataBound event

'Grid NewGrid1 BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid NewGrid1 BeforeShowRow event

'Grid NewGrid1 Event BeforeShowRow. Action Declare Variable @311-90E67614
            Dim tmpGroupType As String = ""
'End Grid NewGrid1 Event BeforeShowRow. Action Declare Variable

'Grid NewGrid1 Event BeforeShowRow. Action Custom Code @305-73254650
    ' -------------------------
    '21-Nov-2018|EA| add grouprowtype to any row style using modified plain set row, by removing altrow
    		'Dim styles15 As String() = Regex.Split("Row;","(?<!\\);")
            'Dim styleIndex15 As Integer = (NewGrid1CurrentRowNumber - 1) Mod styles15.Length
            'Dim rawStyle15 As String = styles15(styleIndex15).Replace("\;",";")
            
            Dim rawStyle15 As String = "Row "
'            rawStyle15 = rawStyle15 & NewGrid1Data.grouprowtype.Value
'            If rawStyle15.IndexOf("=") = -1 And rawStyle15.IndexOf(":") > -1 Then
'                rawStyle15 = "style=""" + rawStyle15 + """"
'            ElseIf rawStyle15.IndexOf("=") = -1 And rawStyle15.IndexOf(":") = -1 And rawStyle15 <> "" Then
'                rawStyle15 = "class=""" + rawStyle15 + """"
'            End If
'            CType(Page,CCPage).ControlAttributes.Add(NewGrid1Repeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle15), AttributeOption.Multiple)
'            CType(Page,CCPage).ControlAttributes.Add(NewGrid1Repeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle15), AttributeOption.Multiple)
    ' -------------------------
'End Grid NewGrid1 Event BeforeShowRow. Action Custom Code

'Grid NewGrid1 BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid NewGrid1 BeforeShowRow event tail

'Grid NewGrid1 ItemDataBound event tail @3-D04DE5D4
        If NewGrid1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(NewGrid1CurrentRowNumber, ListItemType.Item)
            NewGrid1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            NewGrid1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid NewGrid1 ItemDataBound event tail

'Grid NewGrid1 ItemCommand event @3-47EC0C7A

    Protected Sub NewGrid1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= NewGrid1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("NewGrid1SortDir"),SortDirections) = SortDirections._Asc And ViewState("NewGrid1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("NewGrid1SortDir")=SortDirections._Desc
                Else
                    ViewState("NewGrid1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("NewGrid1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As NewGrid1DataProvider.SortFields = 0
            ViewState("NewGrid1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("NewGrid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("NewGrid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("NewGrid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("NewGrid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            NewGrid1Bind
        End If
    End Sub
'End Grid NewGrid1 ItemCommand event

'RadioButton Grade4 Event BeforeShow. Action Custom Code @103'End RadioButton Grade4 Event BeforeShow. Action Custom Code

'RadioButton Grade2 Event BeforeShow. Action Custom Code @91'End RadioButton Grade2 Event BeforeShow. Action Custom Code

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-DA109D0F
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Subject_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        AddSubjectData = New AddSubjectDataProvider()
        AddSubjectOperations = New FormSupportedOperations(False, True, True, True, True)
        PrimarySubjectM3Data = New PrimarySubjectM3DataProvider()
        PrimarySubjectM3Operations = New FormSupportedOperations(False, False, True, False, False)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, False, True, False)
        CORESUBJECTSData = New CORESUBJECTSDataProvider()
        CORESUBJECTSOperations = New FormSupportedOperations(False, True, False, False, True)
        NewGrid1Data = New NewGrid1DataProvider()
        NewGrid1Operations = New FormSupportedOperations(False, True, False, False, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'ERA: Extra function for inserting Extra subjects
	Public Function ExtraInsertItem(ByVal pStudentID as Integer, ByVal pEnrolmentYear as Integer, ByVal pExtraSubjectid as Integer, ByVal pExtraSemester as Char, ByVal pUsername as Char) As String
		'21-Nov-2013|EA| Special version for inserting Extra subjects - based on the generated 'InsertItem' code.
		if (pExtraSubjectid > 0 and pExtraSemester <> "") then
			
			Dim ExtraInsert as SpCommand
			ExtraInsert=new SpCommand("spi_ins_PrimarySubjects_extras;1",Settings.connDECVPRODSQL2005DataAccessObject)
			CType(ExtraInsert,SpCommand).AddParameter("@RETURN_VALUE",0,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
			CType(ExtraInsert,SpCommand).AddParameter("@StudentID",pStudentID,ParameterType._Int,ParameterDirection.Input,0,0,10)
			CType(ExtraInsert,SpCommand).AddParameter("@EnrolmentYear",pEnrolmentYear,ParameterType._Int,ParameterDirection.Input,0,0,10)
			CType(ExtraInsert,SpCommand).AddParameter("@ExtraSubjectID", pExtraSubjectid,ParameterType._Int,ParameterDirection.Input,10,0,10)			' get Subject ID
			CType(ExtraInsert,SpCommand).AddParameter("@ExtraSemester", pExtraSemester ,ParameterType._Char,ParameterDirection.Input,1,0,10)			'calc based on checkbox
			' keep ExprKey172 as it is User ID, and declared in main Custom Insert code
			CType(ExtraInsert,SpCommand).AddParameter("@UserID", pUsername,ParameterType._Char,ParameterDirection.Input,8,0,10)
			Dim result As Object = Nothing
			Dim E As Exception = Nothing
			Try
				result = ExtraInsert.ExecuteNonQuery()
				' return_value = IntegerParameter.GetParam(CType(ExtraInsert.Parameters("@RETURN_VALUE"),IDataParameter).Value)
			Catch ee As Exception
				E = ee
			Finally
				'If Not IsNothing(E) Then Throw E
				If Not IsNothing(E) Then PrimarySubjectM3Errors.Add("Parameters",E.Message)
			End Try
			
			Return CType(result, Integer)
			
		else
			Return -99	'nothing done
		end if
	End Function	



'--------------------------------------

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

