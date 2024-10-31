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

Namespace DECV_PROD2007.StudentEnrolment_AddNewStudent 'Namespace @1-F65D17CF

'Forms Definition @1-3D9F25F6
Public Class [StudentEnrolment_AddNewStudentPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-21EA2812
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTIsSubmitted As Boolean = False
    Protected STUDENTDatePicker_BIRTH_DATEName As String
    Protected STUDENTDatePicker_BIRTH_DATEDateControl As String
    Protected StudentEnrolment_AddNewStudentContentMeta As String
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

'Record Form STUDENT Parameters @2-ADDD80A7

    Protected Sub STUDENTParameters()
        Dim item As new STUDENTItem
        Try
            STUDENTData.Expr6 = FloatParameter.GetParam(0, ParameterSourceType.Expression, "", Nothing, false)
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

'Record STUDENT Event BeforeSelect. Action Declare Variable @75-DA403A9A
        Dim tmpStudentID As Int64
'End Record STUDENT Event BeforeSelect. Action Declare Variable

'Record STUDENT Event BeforeSelect. Action Retrieve Value for Variable @77-0F1C0A2D
        tmpStudentID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Record STUDENT Event BeforeSelect. Action Retrieve Value for Variable

'Record STUDENT Event BeforeSelect. Action Custom Code @76-73254650
    ' -------------------------
    ' ERA: collect the studentID from the querystring into the tmpStudentID
	' If it's empty then create new one from TEMP_STUDENT_ENROLMENT
	If IsNothing(Request.QueryString("STUDENT_ID")) OR Request.QueryString("STUDENT_ID") = "" Then  
		Dim Request As HttpRequest = HttpContext.Current.Request

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
                  NewDao.DateFormat = "mdy"
              End If

              trans = NewDao.NativeConnection.BeginTransaction()
              cmd = NewDao.NativeConnection.CreateCommand

              cmd.CommandType = CommandType.Text
              cmd.Transaction = trans

              Dim strSQL As String = ""
				strSQL = "insert TEMP_STUDENT_ENROLMENT(ENROLMENT_YEAR, DECV_BALANCE, NUMBER_OF_FULL_SUBJECTS) " & _ 
        			"VALUES  ("& NewDao.ToSql(Request.QueryString("ENROLMENT_YEAR"),FieldType._Integer) &",0,0)"

				cmd.CommandText = strSQL
				cmd.ExecuteNonQuery()
				STUDENTlblErrorMessages.Text += "<hr>" & strSQL

				cmd.CommandText = "SELECT @@IDENTITY"
				tmpStudentID = CLng(cmd.ExecuteScalar())
				STUDENTlblErrorMessages.Text += "<hr> Done retrieval of Student ID [" & tmpStudentID.tostring() & "]"

              trans.Commit()

          Catch ex As Exception
              trans.Rollback()
              STUDENTlblErrorMessages.Text += "<br><font color=red>An <b>ERROR</b> occured when setting up this Student. Check the error message below.</font>"
              STUDENTlblErrorMessages.Text += "<br>Error: " & ex.Message.ToString
              STUDENTlblErrorMessages.Visible = True
          Finally
              If NewDao.NativeConnection.State = ConnectionState.Open Then
                  NewDao.NativeConnection.Close()
              End If
          End Try

	end if

    ' -------------------------
'End Record STUDENT Event BeforeSelect. Action Custom Code

'Record Form STUDENT BeforeShow tail @2-84FB18B5
        STUDENTParameters()
        STUDENTData.FillItem(item, IsInsertMode)
        STUDENTHolder.DataBind()
        STUDENTButton_Insert.Visible=IsInsertMode AndAlso STUDENTOperations.AllowInsert
        STUDENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
        STUDENTlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTEnrolDate.Text=item.EnrolDate.GetFormattedValue()
        STUDENTSURNAME.Text=item.SURNAME.GetFormattedValue()
        STUDENTFIRST_NAME.Text=item.FIRST_NAME.GetFormattedValue()
        STUDENTMIDDLE_NAME.Text=item.MIDDLE_NAME.GetFormattedValue()
        STUDENTBIRTH_DATE.Text=item.BIRTH_DATE.GetFormattedValue()
        STUDENTDatePicker_BIRTH_DATEName = "STUDENTDatePicker_BIRTH_DATE"
        STUDENTDatePicker_BIRTH_DATEDateControl = STUDENTBIRTH_DATE.ClientID
        STUDENTDatePicker_BIRTH_DATE.DataBind()
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
        STUDENTListBox_SubCategory.Items.Add(new ListItem("Select Value",""))
        STUDENTListBox_SubCategory.Items(0).Selected = True
        item.ListBox_SubCategoryItems.SetSelection(item.ListBox_SubCategory.GetFormattedValue())
        If Not item.ListBox_SubCategoryItems.GetSelectedItem() Is Nothing Then
            STUDENTListBox_SubCategory.SelectedIndex = -1
        End If
        item.ListBox_SubCategoryItems.CopyTo(STUDENTListBox_SubCategory.Items)
        STUDENTATTENDING_SCHOOL_ID.Text=item.ATTENDING_SCHOOL_ID.GetFormattedValue()
        STUDENTlblAttendingSchoolName.Text = Server.HtmlEncode(item.lblAttendingSchoolName.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTHOME_SCHOOL_ID.Text=item.HOME_SCHOOL_ID.GetFormattedValue()
        STUDENTlblHomeSchoolName.Text = Server.HtmlEncode(item.lblHomeSchoolName.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTCATEGORY_CODE.Text=item.CATEGORY_CODE.GetFormattedValue()
        STUDENTSUBCATEGORY_CODE.Text=item.SUBCATEGORY_CODE.GetFormattedValue()
        STUDENTEnrolmentCategoryTemp.Text=item.EnrolmentCategoryTemp.GetFormattedValue()
        STUDENTlblErrorMessages.Text = Server.HtmlEncode(item.lblErrorMessages.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STUDENT BeforeShow tail

'TextBox SURNAME Event BeforeShow. Action Retrieve Value for Control @83-3753EE28
            STUDENTSURNAME.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SURNAME"))).GetFormattedValue()
'End TextBox SURNAME Event BeforeShow. Action Retrieve Value for Control

'TextBox FIRST_NAME Event BeforeShow. Action Retrieve Value for Control @84-5CA8EA9C
            STUDENTFIRST_NAME.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_FIRST_NAME"))).GetFormattedValue()
'End TextBox FIRST_NAME Event BeforeShow. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL      'ERA: change listbox to match Full Title from Enrolment_Categories, which is temporarily stored in the EnrolmentCategoryTemp field
'DEL  	'	for just this purpose
'DEL  	STUDENTlblAttendingSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'DEL  	STUDENTlblHomeSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.HOME_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'DEL  	STUDENTEnrolmentCategoryTemp.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SUBCATEGORY_FULL_TITLE)" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "CATEGORY_CODE='" & item.CATEGORY_CODE.GetFormattedValue() & "' AND SUBCATEGORY_CODE='" & item.SUBCATEGORY_CODE.GetFormattedValue() & "'"))).GetFormattedValue()
'DEL  
'DEL  	STUDENTListBox_SubCategory.Value = STUDENTEnrolmentCategoryTemp.Text
'DEL      ' -------------------------


'Record Form STUDENT Show method tail @2-F9DBAD9A
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT Show method tail

'Record Form STUDENT LoadItemFromRequest method @2-B1B27766

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
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STUDENTSURNAME.UniqueID))
        If ControlCustomValues("STUDENTSURNAME") Is Nothing Then
            item.SURNAME.SetValue(STUDENTSURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STUDENTSURNAME"))
        End If
        item.FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENTFIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENTFIRST_NAME") Is Nothing Then
            item.FIRST_NAME.SetValue(STUDENTFIRST_NAME.Text)
        Else
            item.FIRST_NAME.SetValue(ControlCustomValues("STUDENTFIRST_NAME"))
        End If
        item.MIDDLE_NAME.IsEmpty = IsNothing(Request.Form(STUDENTMIDDLE_NAME.UniqueID))
        If ControlCustomValues("STUDENTMIDDLE_NAME") Is Nothing Then
            item.MIDDLE_NAME.SetValue(STUDENTMIDDLE_NAME.Text)
        Else
            item.MIDDLE_NAME.SetValue(ControlCustomValues("STUDENTMIDDLE_NAME"))
        End If
        Try
        item.BIRTH_DATE.IsEmpty = IsNothing(Request.Form(STUDENTBIRTH_DATE.UniqueID))
        If ControlCustomValues("STUDENTBIRTH_DATE") Is Nothing Then
            item.BIRTH_DATE.SetValue(STUDENTBIRTH_DATE.Text)
        Else
            item.BIRTH_DATE.SetValue(ControlCustomValues("STUDENTBIRTH_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("BIRTH_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE OF BIRTH","dd/mm/yyyy"))
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
        Try
        item.EnrolYear.IsEmpty = IsNothing(Request.Form(STUDENTEnrolYear.UniqueID))
        If ControlCustomValues("STUDENTEnrolYear") Is Nothing Then
            item.EnrolYear.SetValue(STUDENTEnrolYear.Text)
        Else
            item.EnrolYear.SetValue(ControlCustomValues("STUDENTEnrolYear"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("EnrolYear",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.ListBox_SubCategory.IsEmpty = IsNothing(Request.Form(STUDENTListBox_SubCategory.UniqueID))
        item.ListBox_SubCategory.SetValue(STUDENTListBox_SubCategory.Value)
        item.ListBox_SubCategoryItems.CopyFrom(STUDENTListBox_SubCategory.Items)
        Try
        item.ATTENDING_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENTATTENDING_SCHOOL_ID.UniqueID))
        If ControlCustomValues("STUDENTATTENDING_SCHOOL_ID") Is Nothing Then
            item.ATTENDING_SCHOOL_ID.SetValue(STUDENTATTENDING_SCHOOL_ID.Text)
        Else
            item.ATTENDING_SCHOOL_ID.SetValue(ControlCustomValues("STUDENTATTENDING_SCHOOL_ID"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ATTENDING SCHOOL ID"))
        End Try
        Try
        item.HOME_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENTHOME_SCHOOL_ID.UniqueID))
        If ControlCustomValues("STUDENTHOME_SCHOOL_ID") Is Nothing Then
            item.HOME_SCHOOL_ID.SetValue(STUDENTHOME_SCHOOL_ID.Text)
        Else
            item.HOME_SCHOOL_ID.SetValue(ControlCustomValues("STUDENTHOME_SCHOOL_ID"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"HOME SCHOOL ID"))
        End Try
        item.CATEGORY_CODE.IsEmpty = IsNothing(Request.Form(STUDENTCATEGORY_CODE.UniqueID))
        If ControlCustomValues("STUDENTCATEGORY_CODE") Is Nothing Then
            item.CATEGORY_CODE.SetValue(STUDENTCATEGORY_CODE.Text)
        Else
            item.CATEGORY_CODE.SetValue(ControlCustomValues("STUDENTCATEGORY_CODE"))
        End If
        item.SUBCATEGORY_CODE.IsEmpty = IsNothing(Request.Form(STUDENTSUBCATEGORY_CODE.UniqueID))
        If ControlCustomValues("STUDENTSUBCATEGORY_CODE") Is Nothing Then
            item.SUBCATEGORY_CODE.SetValue(STUDENTSUBCATEGORY_CODE.Text)
        Else
            item.SUBCATEGORY_CODE.SetValue(ControlCustomValues("STUDENTSUBCATEGORY_CODE"))
        End If
        item.EnrolmentCategoryTemp.IsEmpty = IsNothing(Request.Form(STUDENTEnrolmentCategoryTemp.UniqueID))
        If ControlCustomValues("STUDENTEnrolmentCategoryTemp") Is Nothing Then
            item.EnrolmentCategoryTemp.SetValue(STUDENTEnrolmentCategoryTemp.Text)
        Else
            item.EnrolmentCategoryTemp.SetValue(ControlCustomValues("STUDENTEnrolmentCategoryTemp"))
        End If
        If EnableValidation Then
            item.Validate(STUDENTData)
        End If
        STUDENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT LoadItemFromRequest method

'Record Form STUDENT GetRedirectUrl method @2-B089872F

    Protected Function GetSTUDENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentEnrolment_AddNewStudent.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
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

'Record Form STUDENT Insert Operation @2-14FA6976

    Protected Sub STUDENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Insert Operation

'Button Button_Insert OnClick. @3-0BE051F2
        If CType(sender,Control).ID = "STUDENTButton_Insert" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT Event BeforeInsert. Action DLookup @59-95EB92AF
        STUDENTCATEGORY_CODE.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeInsert. Action DLookup

'Record STUDENT Event BeforeInsert. Action DLookup @60-50CFF682
        STUDENTSUBCATEGORY_CODE.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeInsert. Action DLookup

'Record Form STUDENT BeforeInsert tail @2-4976F38F
    STUDENTParameters()
    STUDENTLoadItemFromRequest(item, EnableValidation)
    If STUDENTOperations.AllowInsert Then
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENTData.InsertItem(item)
            Catch ex As Exception
                STUDENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT BeforeInsert tail

'Record Form STUDENT AfterInsert tail  @2-C6B64346
        End If
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

'Button Button_Update OnClick. @4-C6DD6D39
        If CType(sender,Control).ID = "STUDENTButton_Update" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT Event BeforeUpdate. Action DLookup @57-95EB92AF
        STUDENTCATEGORY_CODE.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action DLookup

'Record STUDENT Event BeforeUpdate. Action DLookup @58-50CFF682
        STUDENTSUBCATEGORY_CODE.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action DLookup

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

'Button Button_Cancel OnClick. @5-2667087A
    If CType(sender,Control).ID = "STUDENTButton_Cancel" Then
        RedirectUrl = GetSTUDENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @5-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-00BB6B55
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_AddNewStudentContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, True, True, False)
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

