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

Namespace DECV_PROD2007.Despatch_AssignmentReceipt 'Namespace @1-8B814235

'Forms Definition @1-A5B44C16
Public Class [Despatch_AssignmentReceiptPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2CB3F67E
    Protected AssignmentReceiptData As AssignmentReceiptDataProvider
    Protected AssignmentReceiptErrors As NameValueCollection = New NameValueCollection()
    Protected AssignmentReceiptOperations As FormSupportedOperations
    Protected AssignmentReceiptIsSubmitted As Boolean = False
    Protected Despatch_AssignmentReceiptContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-ADC61A85
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            AssignmentReceiptShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form AssignmentReceipt Parameters @3-8D5AB0DD

    Protected Sub AssignmentReceiptParameters()
        Dim item As new AssignmentReceiptItem
        Try
            AssignmentReceiptData.Ctrlstudentid = FloatParameter.GetParam(item.studentid.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReceiptData.CtrlENrolmentYear = FloatParameter.GetParam(item.ENrolmentYear.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReceiptData.Ctrlsubjectid = IntegerParameter.GetParam(item.subjectid.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReceiptData.ExprKey16 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            AssignmentReceiptErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form AssignmentReceipt Parameters

'Record Form AssignmentReceipt Show method @3-77EB5A65
    Protected Sub AssignmentReceiptShow()
        If AssignmentReceiptOperations.None Then
            AssignmentReceiptHolder.Visible = False
            Return
        End If
        Dim item As AssignmentReceiptItem = AssignmentReceiptItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not AssignmentReceiptOperations.AllowRead
        item.ENrolmentYear.SetValue(year(now()))
        item.link_popupStudentSearchHref = "#"
        item.link_popupStudentSubjectSearchHref = "#"
        item.Link1Href = "Despatch_AssignmentReceipt.aspx"
        AssignmentReceiptErrors.Add(item.errors)
        If AssignmentReceiptErrors.Count > 0 Then
            AssignmentReceiptShowErrors()
            Return
        End If
'End Record Form AssignmentReceipt Show method

'Record Form AssignmentReceipt BeforeShow tail @3-21EF1522
        AssignmentReceiptParameters()
        AssignmentReceiptData.FillItem(item, IsInsertMode)
        AssignmentReceiptHolder.DataBind()
        AssignmentReceiptButton_Insert.Visible=IsInsertMode AndAlso AssignmentReceiptOperations.AllowInsert
        AssignmentReceiptStaffID.Items.Add(new ListItem("Select Value",""))
        AssignmentReceiptStaffID.Items(0).Selected = True
        item.StaffIDItems.SetSelection(item.StaffID.GetFormattedValue())
        If Not item.StaffIDItems.GetSelectedItem() Is Nothing Then
            AssignmentReceiptStaffID.SelectedIndex = -1
        End If
        item.StaffIDItems.CopyTo(AssignmentReceiptStaffID.Items)
        AssignmentReceiptstudentid.Text=item.studentid.GetFormattedValue()
        AssignmentReceiptsubjectid.Text=item.subjectid.GetFormattedValue()
        AssignmentReceiptreceiptdate.Text = Server.HtmlEncode(item.receiptdate.GetFormattedValue()).Replace(vbCrLf,"<br>")
        AssignmentReceiptENrolmentYear.Value = item.ENrolmentYear.GetFormattedValue()
        AssignmentReceiptlink_popupStudentSearch.InnerText += item.link_popupStudentSearch.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReceiptlink_popupStudentSearch.HRef = item.link_popupStudentSearchHref+item.link_popupStudentSearchHrefParameters.ToString("GET","", ViewState)
        AssignmentReceiptlink_popupStudentSubjectSearch.InnerText += item.link_popupStudentSubjectSearch.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReceiptlink_popupStudentSubjectSearch.HRef = item.link_popupStudentSubjectSearchHref+item.link_popupStudentSubjectSearchHrefParameters.ToString("GET","", ViewState)
        AssignmentReceiptLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReceiptLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","studentid;subjectid;", ViewState)
'End Record Form AssignmentReceipt BeforeShow tail

'ListBox StaffID Event BeforeShow. Action Retrieve Value for Control @18-43C10AAE
            AssignmentReceiptStaffID.Value = (New TextField("", System.Web.HttpContext.Current.Session("sessSTAFFID"))).GetFormattedValue()
'End ListBox StaffID Event BeforeShow. Action Retrieve Value for Control

'Record Form AssignmentReceipt Show method tail @3-E3049C9E
        If AssignmentReceiptErrors.Count > 0 Then
            AssignmentReceiptShowErrors()
        End If
    End Sub
'End Record Form AssignmentReceipt Show method tail

'Record Form AssignmentReceipt LoadItemFromRequest method @3-A9A5EE69

    Protected Sub AssignmentReceiptLoadItemFromRequest(item As AssignmentReceiptItem, ByVal EnableValidation As Boolean)
        item.StaffID.IsEmpty = IsNothing(Request.Form(AssignmentReceiptStaffID.UniqueID))
        item.StaffID.SetValue(AssignmentReceiptStaffID.Value)
        item.StaffIDItems.CopyFrom(AssignmentReceiptStaffID.Items)
        item.studentid.IsEmpty = IsNothing(Request.Form(AssignmentReceiptstudentid.UniqueID))
        If ControlCustomValues("AssignmentReceiptstudentid") Is Nothing Then
            item.studentid.SetValue(AssignmentReceiptstudentid.Text)
        Else
            item.studentid.SetValue(ControlCustomValues("AssignmentReceiptstudentid"))
        End If
        item.subjectid.IsEmpty = IsNothing(Request.Form(AssignmentReceiptsubjectid.UniqueID))
        If ControlCustomValues("AssignmentReceiptsubjectid") Is Nothing Then
            item.subjectid.SetValue(AssignmentReceiptsubjectid.Text)
        Else
            item.subjectid.SetValue(ControlCustomValues("AssignmentReceiptsubjectid"))
        End If
        Try
        item.ENrolmentYear.IsEmpty = IsNothing(Request.Form(AssignmentReceiptENrolmentYear.UniqueID))
        item.ENrolmentYear.SetValue(AssignmentReceiptENrolmentYear.Value)
        Catch ae As ArgumentException
            AssignmentReceiptErrors.Add("ENrolmentYear",String.Format(Resources.strings.CCS_IncorrectValue,"ENrolmentYear"))
        End Try
        If EnableValidation Then
            item.Validate(AssignmentReceiptData)
        End If
        AssignmentReceiptErrors.Add(item.errors)
    End Sub
'End Record Form AssignmentReceipt LoadItemFromRequest method

'Record Form AssignmentReceipt GetRedirectUrl method @3-7EA89AC2

    Protected Function GetAssignmentReceiptRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","STUDENT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form AssignmentReceipt GetRedirectUrl method

'Record Form AssignmentReceipt ShowErrors method @3-3E49354A

    Protected Sub AssignmentReceiptShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To AssignmentReceiptErrors.Count - 1
        Select Case AssignmentReceiptErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & AssignmentReceiptErrors(i)
        End Select
        Next i
        AssignmentReceiptError.Visible = True
        AssignmentReceiptErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form AssignmentReceipt ShowErrors method

'Record Form AssignmentReceipt Insert Operation @3-2762C67C

    Protected Sub AssignmentReceipt_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReceiptItem = New AssignmentReceiptItem()
        Dim ExecuteFlag As Boolean = True
        AssignmentReceiptIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AssignmentReceipt Insert Operation

'Button Button_Insert OnClick. @8-9369B3FA
        If CType(sender,Control).ID = "AssignmentReceiptButton_Insert" Then
            RedirectUrl = GetAssignmentReceiptRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Insert OnClick.

'Button Button_Insert Event OnClick. Action Custom Code @19-73254650
	    ' -------------------------
	    'ERA: grab STAFFID from listbox and adde to URL to allow default selection 
		Dim params As New LinkParameterCollection()
	    params.Add("StaffID",item.staffid.value)
	    ' -------------------------
'End Button Button_Insert Event OnClick. Action Custom Code

'Button Button_Insert Event OnClick. Action Save Control Value @32-10FE5F42
        System.Web.HttpContext.Current.Session("sessSTAFFID")=AssignmentReceiptStaffID.Value
'End Button Button_Insert Event OnClick. Action Save Control Value

'Button Button_Insert OnClick tail. @8-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record AssignmentReceipt Event BeforeInsert. Action Custom Code @31-73254650
      ' -------------------------
      'ERA: only AllowInsert if all the fields are entered - this is different to the Validation checking which actually checks that everything is correct
	  If (IsNothing(item.staffid.Value) OrElse item.staffid.Value.ToString() ="") OR (IsNothing(item.studentid.Value) OrElse item.studentid.Value.ToString() ="") OR (IsNothing(item.subjectid.Value) OrElse item.subjectid.Value.ToString() ="") Then
           'AssignmentReceiptOperations.AllowInsert = false
			 AssignmentReceiptErrors.Add("","")
  	 	 else
 			'AssignmentReceiptOperations.AllowInsert = true
  	     End If
      ' -------------------------
'End Record AssignmentReceipt Event BeforeInsert. Action Custom Code

'Record Form AssignmentReceipt BeforeInsert tail @3-A0CD0271
    AssignmentReceiptParameters()
    AssignmentReceiptLoadItemFromRequest(item, EnableValidation)
    If AssignmentReceiptOperations.AllowInsert Then
        ErrorFlag=(AssignmentReceiptErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                AssignmentReceiptData.InsertItem(item)
            Catch ex As Exception
                AssignmentReceiptErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form AssignmentReceipt BeforeInsert tail

'Record Form AssignmentReceipt AfterInsert tail  @3-916053D0
        End If
        ErrorFlag=(AssignmentReceiptErrors.Count > 0)
        If ErrorFlag Then
            AssignmentReceiptShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AssignmentReceipt AfterInsert tail 

'Record Form AssignmentReceipt Update Operation @3-6AB1F3FF

    Protected Sub AssignmentReceipt_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReceiptItem = New AssignmentReceiptItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        AssignmentReceiptIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AssignmentReceipt Update Operation

'Record Form AssignmentReceipt Before Update tail @3-E51AD55E
        AssignmentReceiptParameters()
        AssignmentReceiptLoadItemFromRequest(item, EnableValidation)
'End Record Form AssignmentReceipt Before Update tail

'Record Form AssignmentReceipt Update Operation tail @3-04730C08
        ErrorFlag=(AssignmentReceiptErrors.Count > 0)
        If ErrorFlag Then
            AssignmentReceiptShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AssignmentReceipt Update Operation tail

'Record Form AssignmentReceipt Delete Operation @3-4C370247
    Protected Sub AssignmentReceipt_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        AssignmentReceiptIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As AssignmentReceiptItem = New AssignmentReceiptItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form AssignmentReceipt Delete Operation

'Record Form BeforeDelete tail @3-E51AD55E
        AssignmentReceiptParameters()
        AssignmentReceiptLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-57A19565
        If ErrorFlag Then
            AssignmentReceiptShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form AssignmentReceipt Cancel Operation @3-FC0B33E6

    Protected Sub AssignmentReceipt_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReceiptItem = New AssignmentReceiptItem()
        AssignmentReceiptIsSubmitted = True
        Dim RedirectUrl As String = ""
        AssignmentReceiptLoadItemFromRequest(item, True)
'End Record Form AssignmentReceipt Cancel Operation

'Record Form AssignmentReceipt Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form AssignmentReceipt Cancel Operation tail

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'ERA: specific for TextChanged field validation that don't seem to fit into CodeCharge event model
        Protected Sub AssignmentReceiptStaffID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReceiptStaffID.ServerChange
            ' ERA: do field validation for StaffID exists
            If (Me.AssignmentReceiptStaffID.Value.ToString <> "") Then
                Dim intStaffCount As Int64 = -1
                Dim strScript As String = ""

                '1) check staff	ID exists
                intStaffCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STAFF WHERE STAFF_ID = '" & AssignmentReceiptStaffID.Value.ToString() & "'"))).Value, Int64)
                If (intStaffCount <= 0) Then
                    'finishes server processing, returns to client.
                    strScript = "alert('This STAFF ID does not exist in the database\n\nPlease check ');"
                    If (Not ClientScript.IsStartupScriptRegistered("staffidAlert")) Then
                        ClientScript.RegisterStartupScript(Me.GetType(), "staffidAlert", strScript, True)
                        Me.AssignmentReceiptStaffID.Focus()
                    End If
                Else
                    Me.AssignmentReceiptstudentid.Focus()
                End If
            Else
                Me.AssignmentReceiptStaffID.Focus()
            End If

        End Sub
        'ERA: specific for TextChanged field validation that don't seem to fit into CodeCharge event model
        Protected Sub AssignmentReceiptstudentid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) 	Handles AssignmentReceiptstudentid.TextChanged
            ' ERA: do field validation for Student ID exists
            If (Me.AssignmentReceiptstudentid.Text.ToString <> "") Then
                Dim intCount As Int64 = -1
                Dim strScript As String = ""

                '1) check staff	ID exists
                intCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM STUDENT_SUBJECT WHERE ENROLMENT_YEAR= " & AssignmentReceiptENrolmentYear.Value.ToString() & " AND STUDENT_ID = '" & AssignmentReceiptstudentid.Text.ToString() & "'"))).Value, Int64)
                If (intCount <= 0) Then
                    'finishes server processing, returns to client.
                    strScript = "alert('This STUDENT ID does not exist in the database\n\nPlease check ');"
                    If (Not ClientScript.IsStartupScriptRegistered("studentidAlert")) Then
                        ClientScript.RegisterStartupScript(Me.GetType(), "studentidAlert", strScript, True)
                        Me.AssignmentReceiptstudentid.Focus()
                    End If
                Else
                    Me.AssignmentReceiptsubjectid.Focus()
                End If
            Else
                Me.AssignmentReceiptstudentid.Focus()
            End If

        End Sub

		'ERA: specific for TextChanged field validation that don't seem to fit into CodeCharge event model
        
		Protected Sub AssignmentReceiptSubject_ID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssignmentReceiptsubjectid.TextChanged
            ' ERA: split the entered subject+assignment id into subject and ass id

             If (Me.AssignmentReceiptsubjectid.Text.ToString <> "") Then
                Dim intCount As Int64 = -1
                Dim strMsgString As String = ""
                Dim strSubjectID As String = ""
                Dim strAssignmentID As String = ""

                Dim stringToSplit As String = Me.AssignmentReceiptsubjectid.Text
                If (stringToSplit.Length > 3) Then
                    strSubjectID = stringToSplit.Remove(stringToSplit.Length - 2, 2)
                    strAssignmentID = stringToSplit.Substring(stringToSplit.Length - 2, 2)
                End If

                If (strSubjectID.ToString <> "") Then
                    ' check that the combination of STUDENT_ID, SUBJECT_ID, ENROLMENT_YEAR, ASSIGNMENT_ID
                    intCount = CType((New IntegerField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT count(*) FROM ASSIGNMENT, STUDENT_SUBJECT WHERE (ASSIGNMENT.SUBJECT_ID=STUDENT_SUBJECT.SUBJECT_ID) AND STUDENT_SUBJECT.ENROLMENT_YEAR=year(getyear()) AND STUDENT_SUBJECT.STUDENT_ID = '" & AssignmentReceiptstudentid.Text.ToString() & "' AND ASSIGNMENT.SUBJECT_ID='" & strSubjectID.ToString() & "' AND ASSIGNMENT.ASSIGNMENT_ID='" & strAssignmentID.ToString() & "'"))).Value, Int64)
                    If (intCount <= 0) Then
                        'finishes server processing, returns to client.
                        strMsgString = "alert('This STUDENT + SUBJECT does not have this ASSIGNMENT Number\n\nPlease check ');"
                        If (Not ClientScript.IsStartupScriptRegistered("subjectidAlert")) Then
                            ClientScript.RegisterStartupScript(Me.GetType(), "subjectidAlert", strMsgString, True)
                        End If
                        ' put the split values into their boxes
                        Me.AssignmentReceiptsubjectid.Text = strSubjectID
                        'Me.AssignmentReceiptassignmentid.Text = strAssignmentID
                        Me.AssignmentReceiptsubjectid.Focus()
                    Else
                        ' if it exists then do the form update reset the form for the next one
                        AssignmentReceipt_Insert(sender, e)
                    End If
                End If

            Else
				' subject is now blank, so clear just in case
				me.assignmentreceiptsubjectid.text = ""
                Me.AssignmentReceiptsubjectid.Focus()
            End If

        End Sub
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-86DEF076
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Despatch_AssignmentReceiptContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        AssignmentReceiptData = New AssignmentReceiptDataProvider()
        AssignmentReceiptOperations = New FormSupportedOperations(False, False, True, False, False)
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

