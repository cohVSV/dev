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

Namespace DECV_PROD2007.Teleforms_Enrolments 'Namespace @1-9A8AF919

'Forms Definition @1-DE673A3D
Public Class [Teleforms_EnrolmentsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-967D3E7B
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected GridStudentListData As GridStudentListDataProvider
    Protected GridStudentListOperations As FormSupportedOperations
    Protected GridStudentListCurrentRowNumber As Integer
    Protected Teleforms_EnrolmentsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-5021A04F
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            lblDEBUG.Text = Server.HtmlEncode(item.lblDEBUG.GetFormattedValue()).Replace(vbCrLf,"<br>")
            UpdateFormShow()
            GridStudentListBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form UpdateForm Parameters @57-0689F491

    Protected Sub UpdateFormParameters()
        Dim item As new UpdateFormItem
        Try
        Catch e As Exception
            UpdateFormErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form UpdateForm Parameters

'Record Form UpdateForm Show method @57-E16098CD
    Protected Sub UpdateFormShow()
        If UpdateFormOperations.None Then
            UpdateFormHolder.Visible = False
            Return
        End If
        Dim item As UpdateFormItem = UpdateFormItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not UpdateFormOperations.AllowRead
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.UserId.ToString())
        UpdateFormErrors.Add(item.errors)
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
            Return
        End If
'End Record Form UpdateForm Show method

'Record Form UpdateForm BeforeShow tail @57-55BA1946
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormhidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form UpdateForm BeforeShow tail

'DEL      ' -------------------------
'DEL  	'ERA: collect SUBJECT_TITLE
'DEL  	Dim tmpSubjectID As String 
'DEL  	tmpSubjectID = UpdateFormlblSubjectID.Text
'DEL  	If (Not tmpSubjectID = "") Then
'DEL  		UpdateFormlblSubjectTitle.Text = (New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select isnull(SUBJECT_TITLE,'') from SUBJECT where SUBJECT_ID=" & tmpSubjectID))).GetFormattedValue("")
'DEL  	End If
'DEL  
'DEL      ' -------------------------


'Record Form UpdateForm Show method tail @57-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @57-26B5AE88

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(UpdateFormhidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(UpdateFormhidden_LAST_ALTERED_BY.Value)
        If EnableValidation Then
            item.Validate(UpdateFormData)
        End If
        UpdateFormErrors.Add(item.errors)
    End Sub
'End Record Form UpdateForm LoadItemFromRequest method

'Record Form UpdateForm GetRedirectUrl method @57-E63A1AD3

    Protected Function GetUpdateFormRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form UpdateForm GetRedirectUrl method

'Record Form UpdateForm ShowErrors method @57-52F4A342

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

'Record Form UpdateForm Insert Operation @57-337A0C41

    Protected Sub UpdateForm_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Insert Operation

'Record Form UpdateForm BeforeInsert tail @57-B633AE71
    UpdateFormParameters()
    UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm BeforeInsert tail

'Record Form UpdateForm AfterInsert tail  @57-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm AfterInsert tail 

'Record Form UpdateForm Update Operation @57-26B5347A

    Protected Sub UpdateForm_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Update Operation

'Record Form UpdateForm Before Update tail @57-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm Before Update tail

'Record Form UpdateForm Update Operation tail @57-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm Update Operation tail

'Record Form UpdateForm Delete Operation @57-339A2861
    Protected Sub UpdateForm_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form UpdateForm Delete Operation

'Record Form BeforeDelete tail @57-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @57-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form UpdateForm Cancel Operation @57-062247BE

    Protected Sub UpdateForm_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        UpdateFormLoadItemFromRequest(item, True)
'End Record Form UpdateForm Cancel Operation

'Record Form UpdateForm Cancel Operation tail @57-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form UpdateForm Cancel Operation tail

'Button button_DoDelete OnClick Handler @81-6992D3B6
    Protected Sub UpdateForm_button_DoDelete_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("Teleforms_Enrolments.aspx", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button button_DoDelete OnClick Handler

'Button button_DoDelete Event OnClick. Action Custom Code @112-73254650
    ' -------------------------
          'ERA: sort through the selected subjects
		  'ERA: 4-Dec-2008|EA| added to allow Enrolments to be removed from list
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strStudentID as string

        If (not ErrorFlag) Then

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                Dim trans As OleDb.OleDbTransaction
                Dim cmd As OleDb.OleDbCommand

   				Try
					UpdateFormlblSelections.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""
					Dim tmpUsername As String
					 If (Session("UserID").ToString = "") Then
                        tmpUsername = "'" & item.hidden_last_altered_by.getformattedvalue & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    

                 For Each repItem In GridStudentListRepeater.Items
                        chkBoxed = repItem.FindControl("GridStudentListcbox")
                        If chkBoxed.Checked Then
                            strStudentID = CType(repItem.FindControl("GridStudentListhidden_TMP_STUDENT_ID"), Literal).Text
                            If strStudentID <> "" Then
								strSQL = "update TMP_STUDENT "
							    strSQL += " set TELEFORM_STATUS = 'DELETED' , LAST_ALTERED_DATE=getdate() "
								strSQL += "where TMP_STUDENT_ID= " & NewDao.ToSql(strStudentID, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()

                                UpdateFormlblSelections.Text += "<hr>" & strSQL

                            End If
                        End If
                    Next

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=green>Students Delete performed successfully </font>"
					'27 June 2008|EA| refresh list to show latest updates and UNCHECK students
					Me.GridStudentListBind()

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Students Delete <b>FAILED</b></font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button button_DoDelete Event OnClick. Action Custom Code

'DEL          If ErrorFlag Then
'DEL              UpdateFormShowErrors()
'DEL          'Else
'DEL          '    Response.Redirect(RedirectUrl)
'DEL          End If
'DEL      End Sub




'DEL      ' -------------------------
'DEL        'ERA: sort through the selected subjects
'DEL    		dim repItem as RepeaterItem
'DEL    		dim chkBoxed as Checkbox
'DEL    		dim strStudentID as string
'DEL  
'DEL          If (not ErrorFlag) Then
'DEL  
'DEL                  'actually send the requested changes to the SQL string
'DEL                  Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL                  Dim trans As OleDb.OleDbTransaction
'DEL                  Dim cmd As OleDb.OleDbCommand
'DEL  
'DEL     				Try
'DEL  					UpdateFormlblSelections.Text =""
'DEL                      ' a little more formal than the Sybase 'begin trans' statement
'DEL                      If NewDao.NativeConnection.State <> ConnectionState.Open Then
'DEL                          NewDao.NativeConnection.Open()
'DEL                          NewDao.DateFormat = "mdy"
'DEL                      End If
'DEL  
'DEL                      trans = NewDao.NativeConnection.BeginTransaction()
'DEL                      cmd = NewDao.NativeConnection.CreateCommand
'DEL  
'DEL                      cmd.CommandType = CommandType.Text
'DEL                      cmd.Transaction = trans
'DEL  
'DEL                      Dim strSQL As String = ""
'DEL  					Dim tmpUsername As String
'DEL  					 If (Session("UserID").ToString = "") Then
'DEL                          tmpUsername = "'" & item.hidden_last_altered_by.getformattedvalue & "'"
'DEL                      Else
'DEL                          tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
'DEL                      End If
'DEL                      
'DEL  
'DEL                      For Each repItem In GridStudentListRepeater.Items
'DEL                          chkBoxed = repItem.FindControl("GridStudentListcbox")
'DEL                          If chkBoxed.Checked Then
'DEL                              strStudentID = CType(repItem.FindControl("GridStudentListStudent_ID"), Literal).Text
'DEL                              If strStudentID <> "" Then
'DEL  
'DEL  								strSQL = "update STUDENT_SUBJECT "
'DEL  							    strSQL += " set STAFF_ID=" & NewDao.ToSql(item.listTeacher.value, FieldType._Text, true) & " "
'DEL  								strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
'DEL  								strSQL += " , LAST_ALTERED_DATE=getdate() "
'DEL  								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(me.updateformlblSubjectID.text, FieldType._Integer) & " "
'DEL                                  strSQL += " and STUDENT_ID= " & NewDao.ToSql(strStudentID, FieldType._Integer) & " "
'DEL                                  strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolmentYear.Text, FieldType._Integer) & " "
'DEL                                  cmd.CommandText = strSQL
'DEL                                  cmd.ExecuteNonQuery()
'DEL  
'DEL                                  'UpdateFormlblSelections.Text += "<hr>" & strSQL
'DEL                              End If
'DEL                          End If
'DEL                      Next
'DEL  
'DEL                      trans.Commit()
'DEL                      UpdateFormlblSelections.Text += "<br><font color=green>Student/Teacher ID Update performed successfully for Teacher ID " & item.listTeacher.getformattedvalue() & "</font>"
'DEL  					
'DEL  					'27 June 2008|EA| refresh list to show latest updates and UNCHECK students
'DEL  					Me.GridStudentListBind()
'DEL  
'DEL                  Catch ex As Exception
'DEL                      trans.Rollback()
'DEL                      UpdateFormlblSelections.Text += "<br><font color=red>Student/Teacher ID Update <b>FAILED</b> for Teacher ID " & item.listTeacher.getformattedvalue()  & "</font>"
'DEL                      UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
'DEL                      UpdateFormlblSelections.Visible = True
'DEL                  Finally
'DEL                      If NewDao.NativeConnection.State = ConnectionState.Open Then
'DEL                          NewDao.NativeConnection.Close()
'DEL                      End If
'DEL                  End Try
'DEL  
'DEL              End If
'DEL  
'DEL      ' -------------------------


'DEL          If ErrorFlag Then
'DEL              UpdateFormShowErrors()
'DEL          'Else
'DEL          '    Response.Redirect(RedirectUrl)
'DEL          End If
'DEL      End Sub

'DEL      ' -------------------------
'DEL            'ERA: sort through the selected subjects
'DEL    		dim repItem as RepeaterItem
'DEL    		dim chkBoxed as Checkbox
'DEL    		dim strStudentID as string
'DEL  
'DEL          If (not ErrorFlag) Then
'DEL  
'DEL                  'actually send the requested changes to the SQL string
'DEL                  Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL                  Dim trans As OleDb.OleDbTransaction
'DEL                  Dim cmd As OleDb.OleDbCommand
'DEL  
'DEL     				Try
'DEL  					UpdateFormlblSelections.Text =""
'DEL                      ' a little more formal than the Sybase 'begin trans' statement
'DEL                      If NewDao.NativeConnection.State <> ConnectionState.Open Then
'DEL                          NewDao.NativeConnection.Open()
'DEL                          NewDao.DateFormat = "mdy"
'DEL                      End If
'DEL  
'DEL                      trans = NewDao.NativeConnection.BeginTransaction()
'DEL                      cmd = NewDao.NativeConnection.CreateCommand
'DEL  
'DEL                      cmd.CommandType = CommandType.Text
'DEL                      cmd.Transaction = trans
'DEL  
'DEL                      Dim strSQL As String = ""
'DEL  					Dim tmpUsername As String
'DEL  					 If (Session("UserID").ToString = "") Then
'DEL                          tmpUsername = "'" & item.hidden_last_altered_by.getformattedvalue & "'"
'DEL                      Else
'DEL                          tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
'DEL                      End If
'DEL                      
'DEL  
'DEL                      For Each repItem In GridStudentListRepeater.Items
'DEL                          chkBoxed = repItem.FindControl("GridStudentListcbox")
'DEL                          If chkBoxed.Checked Then
'DEL                              strStudentID = CType(repItem.FindControl("GridStudentListStudent_ID"), Literal).Text
'DEL                              If strStudentID <> "" Then
'DEL  								strSQL = "update STUDENT_SUBJECT "
'DEL  								strSQL += " set APPEARS_ON_VASS="& NewDao.ToSql(item.listappearsVASS.value, FieldType._Integer) & " "
'DEL  								strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
'DEL  								strSQL += " , LAST_ALTERED_DATE=getdate() "
'DEL  								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(me.updateformlblSubjectID.text, FieldType._Integer) & " "
'DEL                                  strSQL += " and STUDENT_ID= " & NewDao.ToSql(strStudentID, FieldType._Integer) & " "
'DEL                                  strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolmentYear.Text, FieldType._Integer) & " "
'DEL                                  cmd.CommandText = strSQL
'DEL                                  cmd.ExecuteNonQuery()
'DEL  
'DEL                                  'UpdateFormlblSelections.Text += "<hr>" & strSQL
'DEL                              End If
'DEL                          End If
'DEL                      Next
'DEL  
'DEL                      trans.Commit()
'DEL                      UpdateFormlblSelections.Text += "<br><font color=green>Student/Appears on VASS Update performed successfully for VASS Code " & item.listappearsVASS.getformattedvalue() & "</font>"
'DEL  					
'DEL  					'27 June 2008|EA| refresh list to show latest updates and UNCHECK students
'DEL  					Me.GridStudentListBind()
'DEL  
'DEL                  Catch ex As Exception
'DEL                      trans.Rollback()
'DEL                      UpdateFormlblSelections.Text += "<br><font color=red>Student/Appears on VASS Update <b>FAILED</b> for VASS Code " & item.listappearsVASS.getformattedvalue() & "</font>"
'DEL                      UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
'DEL                      UpdateFormlblSelections.Visible = True
'DEL                  Finally
'DEL                      If NewDao.NativeConnection.State = ConnectionState.Open Then
'DEL                          NewDao.NativeConnection.Close()
'DEL                      End If
'DEL                  End Try
'DEL  
'DEL              End If
'DEL  
'DEL      ' -------------------------


'DEL          If ErrorFlag Then
'DEL              UpdateFormShowErrors()
'DEL          'Else
'DEL          '    Response.Redirect(RedirectUrl)
'DEL          End If
'DEL      End Sub

'Button button_DoDelete OnClick Handler tail @81-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button button_DoDelete OnClick Handler tail

'Button button_DoEnrolment OnClick Handler @78-D0DF2A51
    Protected Sub UpdateForm_button_DoEnrolment_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("Teleforms_Enrolments.aspx", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button button_DoEnrolment OnClick Handler

'Button button_DoEnrolment Event OnClick. Action Custom Code @110-73254650
    ' -------------------------
          'ERA: sort through the selected subjects
		  'ERA: 4-Dec-2008|EA| added to allow Enrolments to be removed from list
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strStudentID as string

        If (not ErrorFlag) Then

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                Dim trans As OleDb.OleDbTransaction
                Dim cmd As OleDb.OleDbCommand

   				Try
					UpdateFormlblSelections.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""
					Dim tmpUsername As String
					 If (Session("UserID").ToString = "") Then
                        tmpUsername = "'" & item.hidden_last_altered_by.getformattedvalue & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    

                    For Each repItem In GridStudentListRepeater.Items
                        chkBoxed = repItem.FindControl("GridStudentListcbox")
                        If chkBoxed.Checked Then
                            strStudentID = CType(repItem.FindControl("GridStudentListhidden_TMP_STUDENT_ID"), Literal).Text
                            If strStudentID <> "" Then
								strSQL = "exec sp_cpyTMP_TABLE_TO_LIVE_Teleforms " & NewDao.ToSql(strStudentID, FieldType._Integer) & " "
								'cmd.CommandType=CommandType.StoredProcedure 
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()

                                'UpdateFormlblSelections.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=green>Student Enrolment performed successfully</font>"

					'27 June 2008|EA| refresh list to show latest updates and UNCHECK students
					Me.GridStudentListBind()

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student Enrolment Update <b>FAILED</b></font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button button_DoEnrolment Event OnClick. Action Custom Code

'DEL          If ErrorFlag Then
'DEL              UpdateFormShowErrors()
'DEL          'Else
'DEL          '    Response.Redirect(RedirectUrl)
'DEL          End If
'DEL      End Sub

'Button button_DoEnrolment OnClick Handler tail @78-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button button_DoEnrolment OnClick Handler tail

'Grid GridStudentList Bind @2-F216CD8C

    Protected Sub GridStudentListBind()
        If Not GridStudentListOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"GridStudentList",GetType(GridStudentListDataProvider.SortFields), 80, 100)
        End If
'End Grid GridStudentList Bind

'Grid Form GridStudentList BeforeShow tail @2-B8E5651F
        GridStudentListData.SortField = CType(ViewState("GridStudentListSortField"),GridStudentListDataProvider.SortFields)
        GridStudentListData.SortDir = CType(ViewState("GridStudentListSortDir"),SortDirections)
        GridStudentListData.PageNumber = CInt(ViewState("GridStudentListPageNumber"))
        GridStudentListData.RecordsPerPage = CInt(ViewState("GridStudentListPageSize"))
        GridStudentListRepeater.DataSource = GridStudentListData.GetResultSet(PagesCount, GridStudentListOperations)
        ViewState("GridStudentListPagesCount") = PagesCount
        Dim item As GridStudentListItem = New GridStudentListItem()
        GridStudentListRepeater.DataBind
        FooterIndex = GridStudentListRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            GridStudentListRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(GridStudentListRepeater.Controls(0).FindControl("GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_SUBJECT_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_STUDENT_SUBJECT_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(GridStudentListRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords.Text = Server.HtmlEncode(item.STUD_SUB_INTERIM_STUD_SUB_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form GridStudentList BeforeShow tail

'Label STUD_SUB_INTERIM_STUD_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records @34-4E91E0C4
            GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords.Text = GridStudentListData.RecordCount.ToString()
'End Label STUD_SUB_INTERIM_STUD_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid GridStudentList Bind tail @2-E31F8E2A
    End Sub
'End Grid GridStudentList Bind tail

'Grid GridStudentList ItemDataBound event @2-43510D8E

    Protected Sub GridStudentListItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as GridStudentListItem = CType(e.Item.DataItem,GridStudentListItem)
        Dim Item as GridStudentListItem = DataItem
        Dim FormDataSource As GridStudentListItem() = CType(GridStudentListRepeater.DataSource, GridStudentListItem())
        Dim GridStudentListDataRows As Integer = FormDataSource.Length
        Dim GridStudentListIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            GridStudentListCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(GridStudentListRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, GridStudentListCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim GridStudentListcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("GridStudentListcbox"),System.Web.UI.WebControls.CheckBox)
            Dim GridStudentListSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSTUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSURNAME"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListBIRTH_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListBIRTH_DATE"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListTELEFORM_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListTELEFORM_STATUS"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListhidden_TMP_STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListhidden_TMP_STUDENT_ID"),System.Web.UI.WebControls.Literal)
            If DataItem.cboxCheckedValue.Value.Equals(DataItem.cbox.Value) Then
                GridStudentListcbox.Checked = True
            End If
        End If
'End Grid GridStudentList ItemDataBound event

'GridStudentList control Before Show @2-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End GridStudentList control Before Show

'Get Control @55-0D83B47A
            Dim GridStudentListcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("GridStudentListcbox"),System.Web.UI.WebControls.CheckBox)
'End Get Control

'CheckBox cbox Event BeforeShow. Action Hide-Show Component @131-48CB789C
        Dim GridStudentListTELEFORM_STATUS2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListTELEFORM_STATUS"),System.Web.UI.WebControls.Literal)
        'Dim ExprParam2_131_2 As TextField = New TextField("", ("ENROLLED"))
        If (GridStudentListTELEFORM_STATUS2.text="ENROLLED") Then
            GridStudentListcbox.Visible = False
        End If
'End CheckBox cbox Event BeforeShow. Action Hide-Show Component

'GridStudentList control Before Show tail @2-477CF3C9
        End If
'End GridStudentList control Before Show tail


'Grid GridStudentList BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid GridStudentList BeforeShowRow event

'Grid GridStudentList Event BeforeShowRow. Action Custom Code @132-73254650
    ' -------------------------
    'ERA: 
		Dim GridStudentListTELEFORM_STATUS3 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListTELEFORM_STATUS"),System.Web.UI.WebControls.Literal)
		If ( (GridStudentListTELEFORM_STATUS3.text.indexof("UNENROLLED") > -1) AND (GridStudentListTELEFORM_STATUS3.text.indexof("(") > -1) ) Then
			'30-Jan-2009|EA| if UNENROLLED and an error code in brackets then put as reddish for .errorrow class
			CType(Page,CCPage).ControlAttributes.Add(GridStudentListRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, "class='errorrow'"), AttributeOption.Multiple)
		else
			Dim styles44 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex44 As Integer = (GridStudentListCurrentRowNumber - 1) Mod styles44.Length
            Dim rawStyle44 As String = styles44(styleIndex44).Replace("\;",";")
            If rawStyle44.IndexOf("=") = -1 And rawStyle44.IndexOf(":") > -1 Then
                rawStyle44 = "style=""" + rawStyle44 + """"
            ElseIf rawStyle44.IndexOf("=") = -1 And rawStyle44.IndexOf(":") = -1 And rawStyle44 <> "" Then
                rawStyle44 = "class=""" + rawStyle44 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(GridStudentListRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle44), AttributeOption.Multiple)
		End if
    ' -------------------------
'End Grid GridStudentList Event BeforeShowRow. Action Custom Code

'Grid GridStudentList BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid GridStudentList BeforeShowRow event tail

'Grid GridStudentList ItemDataBound event tail @2-5FA60C23
        If GridStudentListIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(GridStudentListCurrentRowNumber, ListItemType.Item)
            GridStudentListRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            GridStudentListItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid GridStudentList ItemDataBound event tail

'Grid GridStudentList ItemCommand event @2-04985BC2

    Protected Sub GridStudentListItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= GridStudentListRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("GridStudentListSortDir"),SortDirections) = SortDirections._Asc And ViewState("GridStudentListSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("GridStudentListSortDir")=SortDirections._Desc
                Else
                    ViewState("GridStudentListSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("GridStudentListSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As GridStudentListDataProvider.SortFields = 0
            ViewState("GridStudentListSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("GridStudentListPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("GridStudentListPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("GridStudentListPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("GridStudentListPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            GridStudentListBind
        End If
    End Sub
'End Grid GridStudentList ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-598A274A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Teleforms_EnrolmentsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        UpdateFormData = New UpdateFormDataProvider()
        UpdateFormOperations = New FormSupportedOperations(False, True, True, True, True)
        GridStudentListData = New GridStudentListDataProvider()
        GridStudentListOperations = New FormSupportedOperations(False, True, False, False, False)
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

