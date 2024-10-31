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

Namespace DECV_PROD2007.Update_Utilities 'Namespace @1-3CBD21D6

'Forms Definition @1-A4144296
Public Class [Update_UtilitiesPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-9723FAC3
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected Update_UtilitiesContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-8AE98F52
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.lblModified.SetValue(System.IO.File.GetLastWriteTime(Request.PhysicalPath).ToString("dd MMM yy HH:mm"))
            PageData.FillItem(item)
            lblModified.Text = Server.HtmlEncode(item.lblModified.GetFormattedValue()).Replace(vbCrLf,"<br>")
            UpdateFormShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Update_Utilities Event BeforeShow. Action Custom Code @86-73254650
    ' -------------------------
    ' ERA: clear the lblSelections field so messages don't carry over when run again
	If Not IsPostBack Then
		UpdateFormlblSelections.Text = ""
    End If
    ' -------------------------
'End Page Update_Utilities Event BeforeShow. Action Custom Code

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

'Record Form UpdateForm BeforeShow tail @53-314729BF
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormtxtEnrolYear1.Text=item.txtEnrolYear1.GetFormattedValue()
        UpdateFormtxtEnrolYear2.Text=item.txtEnrolYear2.GetFormattedValue()
        If item.semester_1CheckedValue.Value.Equals(item.semester_1.Value) Then
            UpdateFormsemester_1.Checked = True
        End If
        If item.semester_2CheckedValue.Value.Equals(item.semester_2.Value) Then
            UpdateFormsemester_2.Checked = True
        End If
        If item.semester_bothCheckedValue.Value.Equals(item.semester_both.Value) Then
            UpdateFormsemester_both.Checked = True
        End If
        UpdateFormtxtGrace.Text=item.txtGrace.GetFormattedValue()
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
        If item.CheckBox_AllCheckedValue.Value.Equals(item.CheckBox_All.Value) Then
            UpdateFormCheckBox_All.Checked = True
        End If
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form UpdateForm BeforeShow tail

'Record Form UpdateForm Show method tail @53-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @53-A63C0430

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        Try
        item.txtEnrolYear1.IsEmpty = IsNothing(Request.Form(UpdateFormtxtEnrolYear1.UniqueID))
        If ControlCustomValues("UpdateFormtxtEnrolYear1") Is Nothing Then
            item.txtEnrolYear1.SetValue(UpdateFormtxtEnrolYear1.Text)
        Else
            item.txtEnrolYear1.SetValue(ControlCustomValues("UpdateFormtxtEnrolYear1"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("txtEnrolYear1",String.Format(Resources.strings.CCS_IncorrectValue,"txtEnrolYear1"))
        End Try
        Try
        item.txtEnrolYear2.IsEmpty = IsNothing(Request.Form(UpdateFormtxtEnrolYear2.UniqueID))
        If ControlCustomValues("UpdateFormtxtEnrolYear2") Is Nothing Then
            item.txtEnrolYear2.SetValue(UpdateFormtxtEnrolYear2.Text)
        Else
            item.txtEnrolYear2.SetValue(ControlCustomValues("UpdateFormtxtEnrolYear2"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("txtEnrolYear2",String.Format(Resources.strings.CCS_IncorrectValue,"txtEnrolYear2"))
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
        item.txtGrace.IsEmpty = IsNothing(Request.Form(UpdateFormtxtGrace.UniqueID))
        If ControlCustomValues("UpdateFormtxtGrace") Is Nothing Then
            item.txtGrace.SetValue(UpdateFormtxtGrace.Text)
        Else
            item.txtGrace.SetValue(ControlCustomValues("UpdateFormtxtGrace"))
        End If
        Catch ae As ArgumentException
            UpdateFormErrors.Add("txtGrace",String.Format(Resources.strings.CCS_IncorrectValue,"txtGrace"))
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
        If UpdateFormCheckBox_All.Checked Then
            item.CheckBox_All.Value = (item.CheckBox_AllCheckedValue.Value)
        Else
            item.CheckBox_All.Value = (item.CheckBox_AllUncheckedValue.Value)
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

'Button Button_DoUpdate1 OnClick Handler @75-568ADEE6
    Protected Sub UpdateForm_Button_DoUpdate1_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate1 OnClick Handler


'Button Button_DoUpdate1 Event OnClick. Action Custom Code @76-73254650
    ' -------------------------
		If (item.txtEnrolYear1.Value Is Nothing) OrElse item.txtEnrolYear1.Value.ToString()="" Then
			UpdateFormErrors.Add("txtEnrolYear1",String.Format("The [Enrolment Year] is required.","txtEnrolYear1"))
		End If

		ErrorFlag = (UpdateFormErrors.Count > 0)
      If (not ErrorFlag) Then

          'actually send the requested changes to the SQL string
          Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
          'ERA: 14-Nov-2013|EA| change from OleDB to SQL for updates
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

				' bl**dy US default date formats
				strSQL = "set dateformat dmy"
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				'UpdateFormlblSelections.Text += "<hr>" & strSQL
				cmd.ExecuteNonQuery()


				strSQL = "finished_student " & item.txtenrolyear1.getformattedvalue & ", 'D'"
              	cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandText = strSQL
				cmd.ExecuteNonQuery()
				UpdateFormlblSelections.Text += "<hr>" & strSQL

              trans.Commit()
              UpdateFormlblSelections.Text += "<br><font color=red>Update Finished Students was performed successfully for Enrolment Year " & item.txtenrolyear1.getformattedvalue &"</font>"

          Catch ex As Exception
              trans.Rollback()
              UpdateFormlblSelections.Text += "<br><font color=red>Update Finished Students <b>FAILED</b> for Enrolment Year " & item.txtenrolyear1.getformattedvalue &"</font>"
              UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
              UpdateFormlblSelections.Visible = True
          Finally
              If NewDao.NativeConnection.State = ConnectionState.Open Then
                  NewDao.NativeConnection.Close()
              End If
          End Try

      End If

    ' -------------------------
'End Button Button_DoUpdate1 Event OnClick. Action Custom Code

'Button Button_DoUpdate1 OnClick Handler tail @75-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        'Else
        '    Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate1 OnClick Handler tail

'Button Button_DoUpdate3 OnClick Handler @79-63CBDC6F
    Protected Sub UpdateForm_Button_DoUpdate3_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate3 OnClick Handler

'Button Button_DoUpdate3 Event OnClick. Action Custom Code @81-73254650
    ' -------------------------
    'ERA: run the time fraction update

        If (not ErrorFlag) Then
                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                 'ERA: 14-Nov-2013|EA| change from OleDB to SQL for updates
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

					' run the stored procedure for updating the Time Fraction
					strSQL = "tf_updater"
					cmd.CommandType = CommandType.StoredProcedure
					cmd.CommandText = strSQL
					cmd.ExecuteNonQuery()
					UpdateFormlblSelections.Text += "<hr>" & strSQL

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=red>Time Fraction Update was performed successfully</font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Time Fraction Update <b>FAILED</b> for the reason below.</font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If
    ' -------------------------
'End Button Button_DoUpdate3 Event OnClick. Action Custom Code

'Button Button_DoUpdate3 OnClick Handler tail @79-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
      '  Else
      '      Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate3 OnClick Handler tail

'Button Button_DoUpdate2 OnClick Handler @45-94D3DE0B
    Protected Sub UpdateForm_Button_DoUpdate2_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button Button_DoUpdate2 OnClick Handler

'Button Button_DoUpdate2 Event OnClick. Action Custom Code @52-73254650
    ' -------------------------
    'ERA: sort through the selected subjects
		' check for semester tick 

		If (item.txtenrolyear2.Value Is Nothing) OrElse item.txtEnrolYear2.Value.ToString()="" Then
		UpdateFormErrors.Add("txtEnrolYear2",String.Format("The [Enrolment Year] is required.","txtEnrolYear2"))
		End If

		If (item.txtGrace.Value Is Nothing) OrElse item.txtGrace.Value.ToString()="" Then
		UpdateFormErrors.Add("txtGrace",String.Format("The [Grace Period] is required.","txtGrace"))
		End If

    	'ERA: better handling of multi select checkbox - SEMESTERS

		If ((item.semester_1.value = false) AND (item.semester_2.value = false) AND (item.semester_both.value = false)) Then
			UpdateFormErrors.Add("semester_both","At least one Semester checkbox must be ticked.")
    	End If

	    'ERA: better handling of multi select checkbox - Year Levels
		If ((item.checkbox0.value = false) AND (item.checkbox1.value = false) AND (item.checkbox2.value = false) AND (item.checkbox3.value = false) AND (item.checkbox4.value = false) AND (item.checkbox5.value = false) AND (item.checkbox6.value = false) AND (item.checkbox7.value = false) AND (item.checkbox8.value = false) AND (item.checkbox9.value = false) AND (item.checkbox10.value = false) AND (item.checkbox11.value = false) AND (item.checkbox12.value = false)) Then
			UpdateFormErrors.Add("checkbox0","At least one Year Level checkbox must be ticked.")
    	End If

		ErrorFlag = (UpdateFormErrors.Count > 0)	' check again after further error checks

  	If (not ErrorFlag) Then

     ' handle the various semesters into a single string
      Dim semester_str As String = "["
      If (item.semester_1.Value) Then
          semester_str += "1"
      End If

      If (item.semester_2.Value) Then
          semester_str += "2"
      End If

      If (item.semester_both.Value) Then
          semester_str += "B"
      End If
      semester_str += "]"

	' handle the yearlevels checkboxes into a single string
      Dim year_level_str As String = ""
		If (item.CheckBox0.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox1.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox2.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox3.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox4.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox5.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox6.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox7.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox8.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox9.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox10.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox11.Value) Then 
			year_level_str += "1," 
		else 
			year_level_str += "0," 
		end if
		If (item.CheckBox12.Value) Then 
			year_level_str += "1" 
		else 
			year_level_str += "0" 
		end if

      ' ensure the date is in yyyy-MM-dd format for standard SQL
          'set as local variable
          'Dim GBformat As New CultureInfo("en-GB", True)
          'Dim strDateTemp As String = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(item.despatchdate.Value, GBformat))

          'actually send the requested changes to the SQL string
          Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
          'ERA: 14-Nov-2013|EA| change from OleDB to SQL for updates
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
				'Dim tmpUsername As String

				' bl**dy US default date formats
				'strSQL = "set dateformat dmy"
				'cmd.CommandType = CommandType.Text
				'cmd.CommandText = strSQL
				''UpdateFormlblSelections.Text += "<hr>" & strSQL
				'cmd.ExecuteNonQuery()

				strSQL = "exec submission_status " & item.txtenrolyear2.getformattedvalue & " ,'" & semester_str & "' , 'D', " & year_level_str &", " & item.txtgrace.getformattedvalue
				'cmd.CommandType = CommandType.StoredProcedure
				cmd.CommandType = CommandType.Text
				cmd.CommandText = strSQL
				'UpdateFormlblSelections.Text += "<hr>SQL:" & strSQL
				cmd.ExecuteNonQuery()

              trans.Commit()
              UpdateFormlblSelections.Text += "<br><font color=green>Update Submission Status was performed successfully for Enrolment Year " & item.txtenrolyear2.getformattedvalue &"</font>"

          Catch ex As Exception
              trans.Rollback()
              UpdateFormlblSelections.Text += "<br><font color=red>Update Submission Status <b>FAILED</b> for Enrolment Year " & item.txtenrolyear2.getformattedvalue &"</font>"
              UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
			  UpdateFormlblSelections.Text += "<br>SQL: {" & cmd.CommandText.Tostring & "}"
              UpdateFormlblSelections.Visible = True
          Finally
              If NewDao.NativeConnection.State = ConnectionState.Open Then
                  NewDao.NativeConnection.Close()
              End If
          End Try

      End If
    ' -------------------------
'End Button Button_DoUpdate2 Event OnClick. Action Custom Code

'Button Button_DoUpdate2 OnClick Handler tail @45-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        'Else
        '    Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoUpdate2 OnClick Handler tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-5DC5DD1A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Update_UtilitiesContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
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

