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

Namespace DECV_PROD2007.StudentEnrolment_AddNewYear 'Namespace @1-1A5EAD9A

'Forms Definition @1-4C488606
Public Class [StudentEnrolment_AddNewYearPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-47C9B052
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTIsSubmitted As Boolean = False
    Protected StudentEnrolment_AddNewYearContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-409EB2E2
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENTShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT Parameters @2-528C5890

    Protected Sub STUDENTParameters()
        Dim item As new STUDENTItem
        Try
            STUDENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 53767, false)
            STUDENTData.Ctrlhidden_STUDENT_ID = TextParameter.GetParam(item.hidden_STUDENT_ID.Value, ParameterSourceType.Control, "", "", false)
            STUDENTData.CtrlEnrolYear = IntegerParameter.GetParam(item.EnrolYear.Value, ParameterSourceType.Control, "", year(now()), false)
            STUDENTData.CtrllistYearLevel = IntegerParameter.GetParam(item.listYearLevel.Value, ParameterSourceType.Control, "", -1, false)
            STUDENTData.Ctrlhidden_LAST_ALTERED_BY = TextParameter.GetParam(item.hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", "unknown", false)
            STUDENTData.CtrlinputREgionID = TextParameter.GetParam(item.inputREgionID.Value, ParameterSourceType.Control, "", "", false)
            STUDENTData.CtrlPRIVACY_PERMISSION = BooleanParameter.GetParam(item.PRIVACY_PERMISSION.Value, ParameterSourceType.Control, Settings.BoolFormat, 0, false)
        Catch e As Exception
            STUDENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT Parameters

'Record Form STUDENT Show method @2-37C1ACAF
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

'DEL      ' -------------------------
'DEL      ' ERA: collect the studentID from the querystring into the tmpStudentID
'DEL  	' If it's empty then create new one from TEMP_STUDENT_ENROLMENT
'DEL  	If IsNothing(Request.QueryString("STUDENT_ID")) OR Request.QueryString("STUDENT_ID") = "" Then  
'DEL  		Dim Request As HttpRequest = HttpContext.Current.Request
'DEL  
'DEL            Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL            Dim trans As OleDb.OleDbTransaction
'DEL            Dim cmd As OleDb.OleDbCommand
'DEL  
'DEL            Try
'DEL                ' a little more formal than the Sybase 'begin trans' statement
'DEL                If NewDao.NativeConnection.State <> ConnectionState.Open Then
'DEL                    NewDao.NativeConnection.Open()
'DEL                    NewDao.DateFormat = "mdy"
'DEL                End If
'DEL  
'DEL                trans = NewDao.NativeConnection.BeginTransaction()
'DEL                cmd = NewDao.NativeConnection.CreateCommand
'DEL  
'DEL                cmd.CommandType = CommandType.Text
'DEL                cmd.Transaction = trans
'DEL  
'DEL                Dim strSQL As String = ""
'DEL  				strSQL = "insert TEMP_STUDENT_ENROLMENT(ENROLMENT_YEAR, DECV_BALANCE, NUMBER_OF_FULL_SUBJECTS) " & _ 
'DEL          			"VALUES  ("& NewDao.ToSql(Request.QueryString("ENROLMENT_YEAR"),FieldType._Integer) &",0,0)"
'DEL  
'DEL  				cmd.CommandText = strSQL
'DEL  				cmd.ExecuteNonQuery()
'DEL  				STUDENTlblErrorMessages.Text += "<hr>" & strSQL
'DEL  
'DEL  				cmd.CommandText = "SELECT @@IDENTITY"
'DEL  				tmpStudentID = CLng(cmd.ExecuteScalar())
'DEL  				STUDENTlblErrorMessages.Text += "<hr> Done retreival of Student ID [" & tmpStudentID.tostring() & "]"
'DEL  
'DEL                trans.Commit()
'DEL  
'DEL            Catch ex As Exception
'DEL                trans.Rollback()
'DEL                STUDENTlblErrorMessages.Text += "<br><font color=red>An <b>ERROR</b> occured when setting up this Student. Check the error message below.</font>"
'DEL                STUDENTlblErrorMessages.Text += "<br>Error: " & ex.Message.ToString
'DEL                STUDENTlblErrorMessages.Visible = True
'DEL            Finally
'DEL                If NewDao.NativeConnection.State = ConnectionState.Open Then
'DEL                    NewDao.NativeConnection.Close()
'DEL                End If
'DEL            End Try
'DEL  
'DEL  	end if
'DEL  
'DEL      ' -------------------------


'Record Form STUDENT BeforeShow tail @2-E0811121
        STUDENTParameters()
        STUDENTData.FillItem(item, IsInsertMode)
        STUDENTHolder.DataBind()
        STUDENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
        STUDENTlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTEnrolDate.Text=item.EnrolDate.GetFormattedValue()
        STUDENTSURNAME.Text = Server.HtmlEncode(item.SURNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTFIRST_NAME.Text = Server.HtmlEncode(item.FIRST_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTMIDDLE_NAME.Text = Server.HtmlEncode(item.MIDDLE_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTBIRTH_DATE.Text = Server.HtmlEncode(item.BIRTH_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.SEXItems.SetSelection(item.SEX.GetFormattedValue())
        STUDENTSEX.SelectedIndex = -1
        item.SEXItems.CopyTo(STUDENTSEX.Items)
        STUDENTlistYearLevel.Items.Add(new ListItem("Select Value",""))
        STUDENTlistYearLevel.Items(0).Selected = True
        item.listYearLevelItems.SetSelection(item.listYearLevel.GetFormattedValue())
        If Not item.listYearLevelItems.GetSelectedItem() Is Nothing Then
            STUDENTlistYearLevel.SelectedIndex = -1
        End If
        item.listYearLevelItems.CopyTo(STUDENTlistYearLevel.Items)
        STUDENTEnrolYear.Text=item.EnrolYear.GetFormattedValue()
        STUDENTcategory.Text = Server.HtmlEncode(item.category.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTsubcategory.Text = Server.HtmlEncode(item.subcategory.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTATTENDING_SCHOOL_ID.Text = Server.HtmlEncode(item.ATTENDING_SCHOOL_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTlblAttendingSchoolName.Text = Server.HtmlEncode(item.lblAttendingSchoolName.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTHOME_SCHOOL_ID.Text = Server.HtmlEncode(item.HOME_SCHOOL_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTlblHomeSchoolName.Text = Server.HtmlEncode(item.lblHomeSchoolName.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENThidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        STUDENThidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENTlblErrorMessages.Text = Server.HtmlEncode(item.lblErrorMessages.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTinputREgionID.Value = item.inputREgionID.GetFormattedValue()
        item.PRIVACY_PERMISSIONItems.SetSelection(item.PRIVACY_PERMISSION.GetFormattedValue())
        STUDENTPRIVACY_PERMISSION.SelectedIndex = -1
        item.PRIVACY_PERMISSIONItems.CopyTo(STUDENTPRIVACY_PERMISSION.Items)
        STUDENTSEX_SELF_DESCRIBED.Text=item.SEX_SELF_DESCRIBED.GetFormattedValue()
'End Record Form STUDENT BeforeShow tail

'Record STUDENT Event BeforeShow. Action Custom Code @63-73254650
    ' -------------------------
    'ERA: change listbox to match Full Title from Enrolment_Categories, which is temporarily stored in the EnrolmentCategoryTemp field
	'	for just this purpose
	if item.ATTENDING_SCHOOL_ID.GetFormattedValue() <> "" then
		STUDENTlblAttendingSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
	else
		STUDENTlblAttendingSchoolName.Text ="unknown"
	end if
	if item.HOME_SCHOOL_ID.GetFormattedValue() <> "" then
		STUDENTlblHomeSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.HOME_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
	else
		STUDENTlblHomeSchoolName.Text = "unknown"
	end if
	'STUDENTEnrolmentCategoryTemp.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SUBCATEGORY_FULL_TITLE)" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "CATEGORY_CODE='" & item.CATEGORY_CODE.GetFormattedValue() & "' AND SUBCATEGORY_CODE='" & item.SUBCATEGORY_CODE.GetFormattedValue() & "'"))).GetFormattedValue()

	'STUDENTListBox_SubCategory.Value = STUDENTEnrolmentCategoryTemp.Text
    ' -------------------------
'End Record STUDENT Event BeforeShow. Action Custom Code

'Record Form STUDENT Show method tail @2-F9DBAD9A
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT Show method tail

'Record Form STUDENT LoadItemFromRequest method @2-66641E3A

    Protected Sub STUDENTLoadItemFromRequest(item As STUDENTItem, ByVal EnableValidation As Boolean)
        Try
        item.EnrolDate.IsEmpty = IsNothing(Request.Form(STUDENTEnrolDate.UniqueID))
        If ControlCustomValues("STUDENTEnrolDate") Is Nothing Then
            item.EnrolDate.SetValue(STUDENTEnrolDate.Text)
        Else
            item.EnrolDate.SetValue(ControlCustomValues("STUDENTEnrolDate"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("EnrolDate",String.Format(Resources.strings.CCS_IncorrectFormat,"ENROLMENT DATE","dd/mm/yyyy"))
        End Try
        item.SEX.IsEmpty = IsNothing(Request.Form(STUDENTSEX.UniqueID))
        If Not IsNothing(STUDENTSEX.SelectedItem) Then
            item.SEX.SetValue(STUDENTSEX.SelectedItem.Value)
        Else
            item.SEX.Value = Nothing
        End If
        item.SEXItems.CopyFrom(STUDENTSEX.Items)
        item.listYearLevel.IsEmpty = IsNothing(Request.Form(STUDENTlistYearLevel.UniqueID))
        item.listYearLevel.SetValue(STUDENTlistYearLevel.Value)
        item.listYearLevelItems.CopyFrom(STUDENTlistYearLevel.Items)
        item.EnrolYear.IsEmpty = IsNothing(Request.Form(STUDENTEnrolYear.UniqueID))
        If ControlCustomValues("STUDENTEnrolYear") Is Nothing Then
            item.EnrolYear.SetValue(STUDENTEnrolYear.Text)
        Else
            item.EnrolYear.SetValue(ControlCustomValues("STUDENTEnrolYear"))
        End If
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENThidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(STUDENThidden_STUDENT_ID.Value)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENThidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(STUDENThidden_LAST_ALTERED_BY.Value)
        Try
        item.inputREgionID.IsEmpty = IsNothing(Request.Form(STUDENTinputREgionID.UniqueID))
        item.inputREgionID.SetValue(STUDENTinputREgionID.Value)
        Catch ae As ArgumentException
            STUDENTErrors.Add("inputREgionID",String.Format(Resources.strings.CCS_IncorrectValue,"REGION APPROVAL CODE"))
        End Try
        Try
        item.PRIVACY_PERMISSION.IsEmpty = IsNothing(Request.Form(STUDENTPRIVACY_PERMISSION.UniqueID))
        If Not IsNothing(STUDENTPRIVACY_PERMISSION.SelectedItem) Then
            item.PRIVACY_PERMISSION.SetValue(STUDENTPRIVACY_PERMISSION.SelectedItem.Value)
        Else
            item.PRIVACY_PERMISSION.Value = Nothing
        End If
        item.PRIVACY_PERMISSIONItems.CopyFrom(STUDENTPRIVACY_PERMISSION.Items)
        Catch ae As ArgumentException
            STUDENTErrors.Add("PRIVACY_PERMISSION",String.Format(Resources.strings.CCS_IncorrectValue,"PRIVACY PERMISSION"))
        End Try
        item.SEX_SELF_DESCRIBED.IsEmpty = IsNothing(Request.Form(STUDENTSEX_SELF_DESCRIBED.UniqueID))
        If ControlCustomValues("STUDENTSEX_SELF_DESCRIBED") Is Nothing Then
            item.SEX_SELF_DESCRIBED.SetValue(STUDENTSEX_SELF_DESCRIBED.Text)
        Else
            item.SEX_SELF_DESCRIBED.SetValue(ControlCustomValues("STUDENTSEX_SELF_DESCRIBED"))
        End If
        If EnableValidation Then
            item.Validate(STUDENTData)
        End If
        STUDENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT LoadItemFromRequest method

'Record Form STUDENT GetRedirectUrl method @2-67728A08

    Protected Function GetSTUDENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentSummary.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT GetRedirectUrl method

'Record Form STUDENT ShowErrors method @2-0193A443

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

'Record Form STUDENT Insert Operation @2-E5B35CBF

    Protected Sub STUDENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Insert Operation

'Record Form STUDENT BeforeInsert tail @2-9400BDAA
    STUDENTParameters()
    STUDENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT BeforeInsert tail

'Record Form STUDENT AfterInsert tail  @2-98ACA329
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT AfterInsert tail 

'Record Form STUDENT Update Operation @2-5F39C5C9

    Protected Sub STUDENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Update Operation

'Button Button_Update OnClick. @3-C6DD6D39
        If CType(sender,Control).ID = "STUDENTButton_Update" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @3-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT Before Update tail @2-6A432CC4
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

'Record STUDENT Event AfterUpdate. Action Custom Code @92-73254650
    ' -------------------------
	'27-Nov-2008|EA| also run the new iAchieve stored proc
	'25 Nov 2020|RW| Removing this SP call, which used to assign the ACER usernames and passwords on the STUDENT_ENROLMENT table
	'                Looks like it hasn't been needed since 2010
	'Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
  	'Dim Sql_iachieve As String = "exec spu_UpdateACERUserDetails "& NewDao.ToSql(item.hidden_student_id.getformattedvalue(),FieldType._Integer) &","&NewDao.ToSql(item.enrolyear.getformattedvalue(),FieldType._Integer) &" "
  	'NewDao.RunSql(Sql_iachieve)

    ' ERA: modify the redirect url to use the ENROLMENT_YEAR as entered by the User
  	
      	Dim enrolparams As New LinkParameterCollection()
      	enrolparams.Add("STUDENT_ID",item.hidden_student_id.getformattedvalue())
  		enrolparams.Add("ENROLMENT_YEAR",item.enrolyear.getformattedvalue())
        RedirectUrl = (GetSTUDENTRedirectUrl("", "STUDENT_ID;ENROLMENT_YEAR") + enrolparams.ToString("", ""))
        RedirectUrl = RedirectUrl.Replace( "??", "?")
    
    ' -------------------------
'End Record STUDENT Event AfterUpdate. Action Custom Code

'Record Form STUDENT Update Operation tail @2-C6B64346
        End If
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT Update Operation tail

'Record Form STUDENT Delete Operation @2-31D1E637
    Protected Sub STUDENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT Delete Operation

'Record Form BeforeDelete tail @2-9400BDAA
        STUDENTParameters()
        STUDENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-73926DB1
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT Cancel Operation @2-4BEF842D

    Protected Sub STUDENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENTLoadItemFromRequest(item, False)
'End Record Form STUDENT Cancel Operation

'Button Button_Cancel OnClick. @5-97E2F9F9
    If CType(sender,Control).ID = "STUDENTButton_Cancel" Then
        RedirectUrl = GetSTUDENTRedirectUrl("StudentEnrolment_InitialCheck.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @5-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT Cancel Operation tail

'DEL      ' -------------------------
'DEL      'ERA: change listbox to match Full Title from Enrolment_Categories, which is temporarily stored in the EnrolmentCategoryTemp field
'DEL  	'	for just this purpose
'DEL  	if item.ATTENDING_SCHOOL_ID.GetFormattedValue() <> "" then
'DEL  		STUDENTlblAttendingSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'DEL  	else
'DEL  		STUDENTlblAttendingSchoolName.Text ="unknown"
'DEL  	end if
'DEL  	if item.HOME_SCHOOL_ID.GetFormattedValue() <> "" then
'DEL  		STUDENTlblHomeSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.HOME_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'DEL  	else
'DEL  		STUDENTlblHomeSchoolName.Text = "unknown"
'DEL  	end if
'DEL  	'STUDENTEnrolmentCategoryTemp.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SUBCATEGORY_FULL_TITLE)" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "CATEGORY_CODE='" & item.CATEGORY_CODE.GetFormattedValue() & "' AND SUBCATEGORY_CODE='" & item.SUBCATEGORY_CODE.GetFormattedValue() & "'"))).GetFormattedValue()
'DEL  
'DEL  	'STUDENTListBox_SubCategory.Value = STUDENTEnrolmentCategoryTemp.Text
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	'27-Nov-2008|EA| also run the new iAchieve stored proc
'DEL  	Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL    	Dim Sql_iachieve As String = "exec spu_UpdateACERUserDetails "& NewDao.ToSql(item.hidden_student_id.getformattedvalue(),FieldType._Integer) &","&NewDao.ToSql(item.enrolyear.getformattedvalue(),FieldType._Integer) &" "
'DEL    	NewDao.RunSql(Sql_iachieve)
'DEL  
'DEL      ' ERA: modify the redirect url to use the ENROLMENT_YEAR as entered by the User
'DEL    	
'DEL        	Dim enrolparams As New LinkParameterCollection()
'DEL        	enrolparams.Add("STUDENT_ID",item.hidden_student_id.getformattedvalue())
'DEL    		enrolparams.Add("ENROLMENT_YEAR",item.enrolyear.getformattedvalue())
'DEL          RedirectUrl = (GetSTUDENTRedirectUrl("", "STUDENT_ID;ENROLMENT_YEAR") + enrolparams.ToString("", ""))
'DEL          RedirectUrl = RedirectUrl.Replace( "??", "?")
'DEL      
'DEL      ' -------------------------

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-B08EA527
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_AddNewYearContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, False, True, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9"})) Then
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

