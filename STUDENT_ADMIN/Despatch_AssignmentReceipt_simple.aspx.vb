Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls

Partial Class Despatch_AssignmentReceipt_simple
    Inherits CCPage 'Inherits System.Web.UI.Page

    'Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.AssignmentReceiptreceiptdate.Text = DateTime.Today.ToString("dd/MM/yyyy")
            'Me.AssignmentReceiptstudentid.Attributes.Add("onkeydown", "if ((event.which && event.which ==13) || (event.keyCode && event.keyCode == 13)){document.Form1.AssignmentReceiptsubjectid.focus();return false;} else return true; ")
            Me.Form.DefaultFocus = "AssignmentReceiptstudentid"
			if not isnothing(System.Web.HttpContext.Current.session("UserID")) then
            	Me.AssignmentReceiptStaffID.Text = System.Web.HttpContext.Current.session("UserID").ToString
			end if
        End If
        ' check validation on all fields
        ValidateForm(sender, e)

    End Sub

    Protected Sub AssignmentReceiptButton_Insert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReceiptButton_Insert.Click
        'System.Web.HttpContext.Current.Session("sessSTAFFID") = AssignmentReceiptStaffID.Text
        ' check all the fields
        ValidateForm(sender, e)

    End Sub
    Protected Sub ValidateForm(ByVal sender As Object, ByVal e As System.EventArgs)
        ' if all the fields are existing then we can validate
        If (Me.AssignmentReceiptStaffID.Text.ToString = "" _
            Or Me.AssignmentReceiptstudentid.Text.ToString = "" _
            Or Me.AssignmentReceiptsubjectid.Text.ToString = "") Then
            ' no-op as not complete
            'Console.Write("No Validation yet")
        Else
            ' validate if the values exist
            Dim intStaffCount As Int64 = -1
            Dim intSubjectCount As Int64 = -1
            Dim intAssignmentCount As Int64 = -1
            Dim intStudentSubjectCount As Int64 = -1
            Dim strMsgString As String = ""
            Dim strMsgString2 As String = ""
            Me.ltlMessage.Text = ""

            Dim flagCheckStudentSubject As Boolean = False   'flag for checking Student AND Subject if the Student check and Subject Check are OK

            ' split the subject+assignment into subject and assignment pieces
            Dim stringToSplit As String = ""
            Dim tmpSubject As String = ""
            Dim tmpAssignment As String = ""

            If Not (IsNothing(AssignmentReceiptsubjectid.Text) OrElse AssignmentReceiptsubjectid.Text.ToString() = "") Then
                stringToSplit = AssignmentReceiptsubjectid.Text.ToString()
                tmpSubject = (stringToSplit.Remove(stringToSplit.Length - 2, 2))
                tmpAssignment = (stringToSplit.Substring(stringToSplit.Length - 2, 2))
            End If

            '1) check staff	ID
            If Not (IsNothing(AssignmentReceiptStaffID.Text) OrElse AssignmentReceiptStaffID.Text.ToString() = "") Then
                intStaffCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & AssignmentReceiptStaffID.Text.ToString() & "'"))).Value, Int64)
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

			
			'2b) check F-6 special assignments against array of ones to reject, unless first 
			'	char is 'Z' from unfuddle #810
			Dim flagCheckRejects as Boolean = true
			Dim flagRejectFailed as Boolean = false
			'If stringToSplit containst "Z" and Cint(tmpSubject) < 200 Then
			'		flagCheckRejects = false
			'End If
			If (flagCheckStudentSubject and flagCheckRejects) Then
				Dim arrRejects() as String = {"300","301","302","303","304","305","306","307","308","309","310","311","312","313","314","315","316",
					"700","701","702","703","704","705","706","707","708","709","710","711","712","713","714","715","716",
					"500","501","502","503","504","505","506","507","508","509","510","511","512","513","514","515","516",
					"1200","1201","1202","1203","1204","1205","1206","1207","1208","1209","1210","1211","1212","1213","1214","1215","1216",
					"1900","1901","1902","1903","1904","1905","1906","1907","1908","1909","1910","1911","1912","1913","1914","1915","1916",
					"1700","1701","1702","1703","1704","1705","1706","1707","1708","1709","1710","1711","1712","1713","1714","1715","1716",
					"2300","2301","2302","2303","2304","2305","2306","2307","2308","2309","2310","2311","2312","2313","2314","2315","2316",
					"2400","2401","2402","2403","2404","2405","2406","2407","2408","2409","2410","2411","2412","2413","2414","2415","2416",
					"2700","2701","2702","2703","2704","2705","2706","2707","2708","2709","2710","2711","2712","2713","2714","2715","2716",
					"3400","3401","3402","3403","3404","3405","3406","3407","3408","3409","3410","3411","3412","3413","3414","3415","3416",
					"3700","3701","3702","3703","3704","3705","3706","3707","3708","3709","3710","3711","3712","3713","3714","3715","3716",
					"4500","4501","4502","4503","4504","4505","4506","4507","4508","4509","4510","4511","4512","4513","4514","4515","4516",
					"4700","4701","4702","4703","4704","4705","4706","4707","4708","4709","4710","4711","4712","4713","4714","4715","4716",
					"5300","5301","5302","5303","5304","5305","5306","5307","5308","5309","5310","5311","5312","5313","5314","5315","5316",
					"5600","5601","5602","5603","5604","5605","5606","5607","5608","5609","5610","5611","5612","5613","5614","5615","5616",
					"6200","6201","6202","6203","6204","6205","6206","6207","6208","6209","6210","6211","6212","6213","6214","6215","6216"}
				
				If arrRejects.Contains(stringToSplit) Then
					strMsgString += "\nWHOA! That assignment has been Marked with the F-6 Plague and cannot be checked in. Unclean!! (" & stringToSplit.ToString & ")."
					flagCheckStudentSubject = False
					flagRejectFailed = true
				End If
				
			End If

            '3) check student/subject combo exists if certain of the above haven't failed
            If (flagCheckStudentSubject) And (Not (IsNothing(AssignmentReceiptstudentid.Text) OrElse AssignmentReceiptstudentid.Text.ToString() = "")) Then
                intStudentSubjectCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM student_subject WHERE ENROLMENT_YEAR= year(getdate()) AND STUDENT_ID= " & AssignmentReceiptstudentid.Text.ToString() & " AND SUBJECT_ID= " & tmpSubject.ToString() & " "))).Value, Int64)
                If (intStudentSubjectCount <= 0) Then
                    strMsgString += "\nThe entered STUDENT is not enrolled for this SUBJECT (" & tmpSubject.ToString & ")."
                End If
            End If

            '4) if no problems  then send insert to stored proc
            'strMsgString = ""   ' DEBUG
            If Not (strMsgString = "") Then
                'errors so return to client.
                if flagRejectFailed then 
                	strMsgString2 = "audio.play();"
                End If
                strMsgString = strMsgString2 + " var msgalert='" + strMsgString + "\n\nPlease check ';"
                
                If (Not ClientScript.IsStartupScriptRegistered("ReceiptAlert")) Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "ReceiptAlert", strMsgString, True)
                End If
            Else
                ' if all OK then save to the stored proc
                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                Dim param As New DECV_PROD2007.Data.ParameterCollection

                'System.Web.HttpContext.Current.Session("sessSTAFFID") = AssignmentReceiptStaffID.Text

                Try
                    ' a little more formal than the Sybase 'begin trans' statement
                    If (Not NewDao.NativeConnection.State.Open) Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "dmy"
                    End If

                    Dim strSQL As String = ""

                    ' put the parameters together 
                    'param.Clear()
                    'param.Add("@pnStudentID", CType(Me.AssignmentReceiptstudentid.Text, OleDbDao))
                    'param.Add("@pnEnrolmentYear", Year(DateTime.Today()))
                    'param.Add("@psiSubjectID", CType(tmpSubject, Integer))
                    'param.Add("@psiAssignmentID", CType(tmpAssignment, Integer))
                    'param.Add("@last_altered_by", AssignmentReceiptStaffID.Text.ToString())

                    ' put parameters into the stored proc and run it and get any id back
                    'Dim intRetVal As Integer = NewDao.RunSP("sp_upd_assignment_receipt", param)

                    strSQL = "exec sp_upd_assignment_receipt " & Me.AssignmentReceiptstudentid.Text.ToString() _
                        & " ," & Year(DateTime.Today()) & " ," & tmpSubject.ToString & " , " & tmpAssignment.ToString _
                        & ", '" & AssignmentReceiptStaffID.Text.ToString & "'"

                    ' debug
                    'ltlMessage.Text += "<br>DEBUG: strSQL:" & strSQL.ToString
                    Dim intRetVal As Integer = NewDao.ExecuteNonQuery(strSQL)

                    ltlMessage.Text += "<br><font color=green><h2>Assignment Receipt successful</h2></font>"
                    ' debug
                    ltlMessage.Text += "<br>DEBUG: intRetVal:" & intRetVal.ToString & " DEBUG: stringToSplit:" & stringToSplit.ToString

                Catch ex As Exception
                    ltlMessage.Text += "<br><font color=red>Assignment Receipt <b>FAILED</b> for STUDENT ID (" & Me.AssignmentReceiptstudentid.Text.ToString & ") and SUBJECT (" & tmpSubject.ToString & ") and ASSIGNMENT (" & tmpAssignment.ToString & ").</font>"
                    ltlMessage.Text += "<br>Error: " & ex.Message.ToString
                    ltlMessage.Visible = True
                Finally
                    If NewDao.NativeConnection.State.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

                ' reset the form 
                Me.AssignmentReceiptstudentid.Text = ""
                Me.AssignmentReceiptsubjectid.Text = ""
                Me.AssignmentReceiptstudentid.Focus()

            End If

        End If


    End Sub
    Protected Sub AssignmentReceiptstudentid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReceiptstudentid.TextChanged
        ' ERA: after Student Changed then move to Subject field
        Page.SetFocus(Me.AssignmentReceiptsubjectid)
    End Sub

End Class
