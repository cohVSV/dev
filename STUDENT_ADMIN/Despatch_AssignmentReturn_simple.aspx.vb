Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
Partial Class Despatch_AssignmentReturn_simple
    Inherits CCPage 'Inherits System.Web.UI.Page

    'Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.AssignmentReturnreceiptdate.Text = DateTime.Today.ToString("dd/MM/yyyy")
			'Me.hidden_AddNewReturn_flag.Value= "0"
			Me.hidden_AddNewReturn_flag.Checked = false
            'Me.AssignmentReturnstudentid.Attributes.Add("onkeydown", "if ((event.which && event.which ==13) || (event.keyCode && event.keyCode == 13)){document.Form1.AssignmentReturnsubjectid.focus();return false;} else return true; ")
            Me.Form.DefaultFocus = "AssignmentReturnstudentid"
			if not isnothing(System.Web.HttpContext.Current.session("UserID")) then
            	Me.AssignmentReturnStaffID.Text = System.Web.HttpContext.Current.session("UserID").ToString
			end if
        End If
        ' check validation on all fields
        ValidateForm(sender, e)

    End Sub

    Protected Sub AssignmentReturnButton_Insert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReturnButton_Insert.Click
        'System.Web.HttpContext.Current.Session("sessSTAFFID") = AssignmentReturnStaffID.Text.ToString
        ' check all the fields
        ValidateForm(sender, e)

    End Sub

    Protected Sub ValidateForm(ByVal sender As Object, ByVal e As System.EventArgs)
        ' if all the fields are existing then we can validate
        If (Me.AssignmentReturnStaffID.Text.ToString = "" _
            Or Me.AssignmentReturnstudentid.Text.ToString = "" _
            Or Me.AssignmentReturnMarkerID.Text.ToString = "" _
            Or Me.AssignmentReturnsubjectid.Text.ToString = "") Then
            ' no-op as not complete
            'Console.Write("No Validation yet")
        Else
            ' validate if the values exist
            Dim intStaffCount As Int64 = -1
            Dim intSubjectCount As Int64 = -1
            Dim intAssignmentCount As Int64 = -1
            Dim intStudentSubjectCount As Int64 = -1
			Dim intReceiptedCount As Int64 = -1
			dim dateLastReturnedDate as Datetime
            Dim strMsgString As String = ""
			Dim strMsgNewRec As String = ""
            Me.ltlMessage.Text = ""

            Dim flagCheckStudentSubject As Boolean = False   'flag for checking Student AND Subject if the Student check and Subject Check are OK

			dim intNewReturnflag as integer = 0
			if (Me.hidden_AddNewReturn_flag.Checked) then
				intNewReturnflag = 1
			else
				intNewReturnflag = 0
			end if

            ' split the subject+assignment into subject and assignment pieces
            Dim stringToSplit As String = ""
            Dim tmpSubject As String = ""
            Dim tmpAssignment As String = ""

            If Not (IsNothing(AssignmentReturnsubjectid.Text) OrElse AssignmentReturnsubjectid.Text.ToString() = "") Then
                stringToSplit = AssignmentReturnsubjectid.Text.ToString()
                tmpSubject = (stringToSplit.Remove(stringToSplit.Length - 2, 2))
                tmpAssignment = (stringToSplit.Substring(stringToSplit.Length - 2, 2))
            End If

            '1) check staff	ID
            If Not (IsNothing(AssignmentReturnStaffID.Text) OrElse AssignmentReturnStaffID.Text.ToString() = "") Then
                intStaffCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & AssignmentReturnStaffID.Text.ToString() & "'"))).Value, Int64)
                If (intStaffCount <= 0) Then
                    strMsgString += "\nThis STAFF ID does not exist in the database."
                    flagCheckStudentSubject = False
                Else
                    flagCheckStudentSubject = True
                End If
            End If

            '2a) check if subject exists

            If Not (IsNothing(tmpSubject) OrElse tmpSubject = "") Then
                intAssignmentCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM subject WHERE SUBJECT_ID= " & tmpSubject.ToString() & " AND STATUS =1"))).Value, Int64)
                If (intAssignmentCount <= 0) Then
                    strMsgString += "\nThe entered SUBJECT ID (" & tmpSubject.ToString & ") does not exist."
                    flagCheckStudentSubject = False
                Else
                    flagCheckStudentSubject = True
                    '2b) check assignment exists for subject, now that Subject exists
                    intAssignmentCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM assignment WHERE SUBJECT_ID= " & tmpSubject.ToString() & " AND ASSIGNMENT_ID= " & tmpAssignment.ToString() & " AND STATUS =1"))).Value, Int64)
                    If (intAssignmentCount <= 0) Then
                        strMsgString += "\nThe entered ASSIGNMENT ID (" & tmpAssignment.ToString & ") does not exist for this SUBJECT."
                    End If
                End If
            Else
                ' if Subject is blank then don't even try to check subject/student combo
                flagCheckStudentSubject = False
            End If ' not (IsNothing(tmpSubject) OrElse tmpSubject ="")

            '2b) check Marker ID (same way as staff ID)
            If Not (IsNothing(AssignmentReturnMarkerID.Text) OrElse AssignmentReturnMarkerID.Text.ToString() = "") Then
                intStaffCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & AssignmentReturnMarkerID.Text.ToString() & "'"))).Value, Int64)
                If (intStaffCount <= 0) Then
                    strMsgString += "\nThis MARKER ID does not exist in the database."
                    flagCheckStudentSubject = False
                Else
                    flagCheckStudentSubject = True
                End If
            End If

            '3) check student/subject combo exists if certain of the above haven't failed
            If (flagCheckStudentSubject) And (Not (IsNothing(AssignmentReturnstudentid.Text) OrElse AssignmentReturnstudentid.Text.ToString() = "")) Then
                intStudentSubjectCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_subject WHERE ENROLMENT_YEAR= year(getdate()) AND STUDENT_ID= " & AssignmentReturnstudentid.Text.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " "))).Value, Int64)
                If (intStudentSubjectCount <= 0) Then
                    strMsgString += "\nThe entered STUDENT is not enrolled for this SUBJECT (" & tmpSubject.ToString & ")."
                End If
            End If

			'4) check if this has been entered previously
            If (Me.hidden_AddNewReturn_flag.Checked = false) and (strMsgString = "") Then
				intReceiptedCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM ASSIGNMENT_SUBMISSION WHERE ENROLMENT_YEAR= year(getdate()) AND STUDENT_ID= " & AssignmentReturnstudentid.Text.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " AND ASSIGNMENT_ID= " & tmpAssignment.ToString() & " AND SUBMISSION_ID=(SELECT MAX(SUBMISSION_ID) FROM ASSIGNMENT_SUBMISSION WHERE STUDENT_ID= " & AssignmentReturnstudentid.Text.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " AND ASSIGNMENT_ID= " & tmpAssignment.ToString() & ") AND RETURNED_DATE IS NULL AND STAFF_ID=''"))).Value, Int64)

				If (intReceiptedCount = 0) Then
					' no records to be updated so get
                	dateLastReturnedDate = CType((New DateField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT isnull(max(RETURNED_DATE),'') FROM ASSIGNMENT_SUBMISSION WHERE ENROLMENT_YEAR= year(getdate()) AND STUDENT_ID= " & AssignmentReturnstudentid.Text.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " AND ASSIGNMENT_ID= " & tmpAssignment.ToString() & " "))).Value, DateTime)
                	'Dim dateNullDate As DateTime    ' gets a nothing date
                	'If Not (DateTime.Compare(dateLastReturnedDate, dateNullDate) = 0) Then
						If  dateLastReturnedDate.ToString("dd/MM/yyyy hh:mm") = "01/01/1900 12:00" then
							strMsgString  += "\nSubject " & tmpSubject.ToString() & " with Assignment " & tmpAssignment.ToString() & " has Never Been Receipted.\n\nTick the [Insert Return if not Receipted?] then click [Do Return] to add a new Record"
						Else
							strMsgString  += "\nSubject " & tmpSubject.ToString() & " with Assignment " & tmpAssignment.ToString() & " has already been Returned at " & dateLastReturnedDate.ToString("dd/MM/yyyy hh:mm") & "\n\nTick the [Insert Return if not Receipted?] then click [Do Return] to add a new Record"
						End if
                    	'strMsgNewRec = "var conf = confirm('Subject " & tmpSubject.ToString() & " with Assignment " & tmpAssignment.ToString() & " as already been Returned at " & dateLastReturnedDate.ToString("dd/MM/yyyy hh:mm") & "\n\n Press Enter/OK to add a new Record, or Escape/Cancel to ignore.');if (conf){document.Form1.hidden_AddNewReturn_flag.Checked=true;document.Form1.submit();}"
                    	'strMsgNewRec = "var delthing = if(confirm('Subject " & tmpSubject.ToString() & " with Assignment " & tmpAssignment.ToString() & " as already been Returned at " & dateLastReturnedDate.ToString() & "\n\n Press Enter/OK to add a new Record, or Escape/Cancel to ignore.')){document.Form1.hidden_AddNewReturn_flag.Value='1';document.Form1.submit();}else{return false;};"
                	'End If
				end if
            End If

            '5) if no problems  then send insert to stored proc
            'strMsgString = ""   ' DEBUG
            If Not (strMsgString = "") Then
                'errors so return to client.
                strMsgString = "alert('" + strMsgString + "\n\nPlease check ');"
                If (Not ClientScript.IsStartupScriptRegistered("ReturnAlert")) Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "ReturnAlert", strMsgString, True)
                End If
	
				' also reset all the fields so we don't get multiple submits
				if intReceiptedCount <> 0 then
					Me.AssignmentReturnstudentid.Text = ""
                	Me.AssignmentReturnsubjectid.Text = ""
					Me.AssignmentReturnmarkerid.Text = ""
					Me.hidden_AddNewReturn_flag.Checked = false
                	Me.AssignmentReturnstudentid.Focus()
				end if

            Else

				' show message for forcing update
				'If ( not (strMsgNewRec = "")) Then
				'	If (Not ClientScript.IsStartupScriptRegistered("ReturnNewRecordAlert")) Then
                '		ClientScript.RegisterStartupScript(Me.GetType(), "ReturnNewRecordAlert", strMsgNewRec, True)
	            '    End If
				'Else

	                ' if all OK then save to the stored proc
	                'actually send the requested changes to the SQL string
	                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
	                Dim param As New DECV_PROD2007.Data.ParameterCollection

	                'System.Web.HttpContext.Current.Session("sessSTAFFID") = AssignmentReturnStaffID.Text.ToString

	                Try
	                    ' a little more formal than the Sybase 'begin trans' statement
	                    If (Not NewDao.NativeConnection.State.Open) Then
	                        NewDao.NativeConnection.Open()
	                        NewDao.DateFormat = "dmy"
	                    End If

	                    Dim strSQL As String = ""
                    

	                    ' put the parameters together 
	                    'param.Clear()
	                    'param.Add("@pnStudentID", CType(Me.AssignmentReturnstudentid.Text, OleDbDao))
	                    'param.Add("@pnEnrolmentYear", Year(DateTime.Today()))
	                    'param.Add("@psiSubjectID", CType(tmpSubject, Integer))
	                    'param.Add("@psiAssignmentID", CType(tmpAssignment, Integer))
	                    'param.Add("@last_altered_by", tmpUsername)

	                    ' put parameters into the stored proc and run it and get any id back
	                    'Dim intRetVal As Integer = NewDao.RunSP("sp_upd_assignment_receipt", param)
					
	                    strSQL = "exec sp_upd_assignment_return_Combined " & Me.AssignmentReturnstudentid.Text.ToString() _
	                        & " ," & Year(DateTime.Today()) & " ," & tmpSubject.ToString & " , " & tmpAssignment.ToString _
	                        & ", '" & AssignmentReturnMarkerID.Text.ToString & "', '" & AssignmentReturnStaffID.Text.ToString & "'" _
							& ", " & intNewReturnflag.ToString() & " "
						

	                    ' debug
	                    ltlMessage.Text += "<br>DEBUG: strSQL:" & strSQL.ToString
	                    Dim intRetVal As Integer = NewDao.ExecuteNonQuery(strSQL)

	                    ltlMessage.Text += "<br><font color=green>Assignment Return successful</font>"
	                    ' debug
	                    ltlMessage.Text += "<br>DEBUG: intRetVal:" & intRetVal.ToString

	                Catch ex As Exception
	                    ltlMessage.Text += "<br><font color=red>Assignment Return <b>FAILED</b> for STUDENT ID (" & Me.AssignmentReturnstudentid.Text.ToString & ") and SUBJECT (" & tmpSubject.ToString & ") and ASSIGNMENT (" & tmpAssignment.ToString & ").</font>"
	                    ltlMessage.Text += "<br>Error: " & ex.Message.ToString
	                    ltlMessage.Visible = True
	                Finally
	                    If NewDao.NativeConnection.State.Open Then
	                        NewDao.NativeConnection.Close()
	                    End If
	                End Try

	                ' reset the form 
	                Me.AssignmentReturnstudentid.Text = ""
	                Me.AssignmentReturnsubjectid.Text = ""
					Me.AssignmentReturnmarkerid.Text = ""
					Me.hidden_AddNewReturn_flag.Checked = false
	                Me.AssignmentReturnstudentid.Focus()

				'End If

            End If

        End If


    End Sub
    Protected Sub AssignmentReturnstudentid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReturnstudentid.TextChanged
        ' ERA: after Student Changed then move to Subject field
        Page.SetFocus(Me.AssignmentReturnsubjectid)
    End Sub
	Protected Sub AssignmentReturnsubjectid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReturnsubjectid.TextChanged
        ' ERA: after Student Changed then move to Subject field
        Page.SetFocus(Me.AssignmentReturnMarkerID)
    End Sub
End Class
