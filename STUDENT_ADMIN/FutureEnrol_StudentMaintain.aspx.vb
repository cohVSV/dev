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

Namespace DECV_PROD2007.FutureEnrol_StudentMaintain 'Namespace @1-DFE5374F

'Forms Definition @1-1AFAC9B5
Public Class [FutureEnrol_StudentMaintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-6D1EE263
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTIsSubmitted As Boolean = False
    Protected STUDENTDatePicker_BIRTH_DATEName As String
    Protected STUDENTDatePicker_BIRTH_DATEDateControl As String
    Protected STUDENT_ENROLMENTData As STUDENT_ENROLMENTDataProvider
    Protected STUDENT_ENROLMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_ENROLMENTOperations As FormSupportedOperations
    Protected STUDENT_ENROLMENTIsSubmitted As Boolean = False
    Protected EditableGrid1Data As EditableGrid1DataProvider
    Protected EditableGrid1CurrentRowNumber As Integer
    Protected EditableGrid1IsSubmitted As Boolean = False
    Protected EditableGrid1Errors As New NameValueCollection()
    Protected EditableGrid1Operations As FormSupportedOperations
    Protected EditableGrid1DataItem As EditableGrid1Item
    Protected STUDENT_COMMENTData As STUDENT_COMMENTDataProvider
    Protected STUDENT_COMMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_COMMENTOperations As FormSupportedOperations
    Protected STUDENT_COMMENTIsSubmitted As Boolean = False
    Protected Grid_DisplayCommentsData As Grid_DisplayCommentsDataProvider
    Protected Grid_DisplayCommentsOperations As FormSupportedOperations
    Protected Grid_DisplayCommentsCurrentRowNumber As Integer
    Protected FutureEnrol_StudentMaintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-5EA26BD5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENTShow()
            STUDENT_ENROLMENTShow()
            EditableGrid1Bind()
            STUDENT_COMMENTShow()
            Grid_DisplayCommentsBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT Parameters @3-935DE674

    Protected Sub STUDENTParameters()
        Dim item As new STUDENTItem
        Try
            STUDENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)
        Catch e As Exception
            STUDENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT Parameters

'Record Form STUDENT Show method @3-37C1ACAF
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

'Record Form STUDENT BeforeShow tail @3-72C10BC8
        STUDENTParameters()
        STUDENTData.FillItem(item, IsInsertMode)
        STUDENTHolder.DataBind()
        STUDENTButton_Insert.Visible=IsInsertMode AndAlso STUDENTOperations.AllowInsert
        STUDENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
        STUDENTlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
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
        STUDENTCATEGORY_CODE.Value = item.CATEGORY_CODE.GetFormattedValue()
        STUDENTSUBCATEGORY_CODE.Value = item.SUBCATEGORY_CODE.GetFormattedValue()
        STUDENTEnrolmentCategoryTemp.Value = item.EnrolmentCategoryTemp.GetFormattedValue()
        STUDENThidden_old_ATTENDING_SCHOOL_ID.Value = item.hidden_old_ATTENDING_SCHOOL_ID.GetFormattedValue()
        STUDENTVSN.Text=item.VSN.GetFormattedValue()
        STUDENTPREFERRED_NAME.Text=item.PREFERRED_NAME.GetFormattedValue()
        STUDENTENROLLEDBEFORE.Value = item.ENROLLEDBEFORE.GetFormattedValue()
        STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value = item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()
        STUDENTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENThidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENThidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        STUDENTSTUDENT_EMAIL.Text=item.STUDENT_EMAIL.GetFormattedValue()
        STUDENTSTUDENT_MOBILE.Text=item.STUDENT_MOBILE.GetFormattedValue()
        STUDENTHidden_CURR_RESID_ADDRESS_ID.Value = item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue()
        STUDENTlistORG_SCHOOL_ID.Items.Add(new ListItem("Select Value",""))
        STUDENTlistORG_SCHOOL_ID.Items.Add(new ListItem("- none -","0"))
        STUDENTlistORG_SCHOOL_ID.Items(1).Selected = True
        item.listORG_SCHOOL_IDItems.SetSelection(item.listORG_SCHOOL_ID.GetFormattedValue())
        If Not item.listORG_SCHOOL_IDItems.GetSelectedItem() Is Nothing Then
            STUDENTlistORG_SCHOOL_ID.SelectedIndex = -1
        End If
        item.listORG_SCHOOL_IDItems.CopyTo(STUDENTlistORG_SCHOOL_ID.Items)
        STUDENTVCE_CANDIDATE_NUMBER.Text=item.VCE_CANDIDATE_NUMBER.GetFormattedValue()
'End Record Form STUDENT BeforeShow tail

'TextBox SURNAME Event BeforeShow. Action Custom Code @6-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| trim the Surname 
	STUDENTSURNAME.Text=RTrim(item.SURNAME.GetFormattedValue())
    ' -------------------------
'End TextBox SURNAME Event BeforeShow. Action Custom Code

'TextBox FIRST_NAME Event BeforeShow. Action Custom Code @8-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| trim the Firstname 
    STUDENTFIRST_NAME.Text=RTrim(item.FIRST_NAME.GetFormattedValue())
    ' -------------------------
'End TextBox FIRST_NAME Event BeforeShow. Action Custom Code

'TextBox MIDDLE_NAME Event BeforeShow. Action Custom Code @10-73254650
    ' -------------------------
	'ERA: 4-Apr-2011|EA| trim the VCE Candidate number 
    STUDENTVCE_CANDIDATE_NUMBER.Text=RTrim(item.VCE_CANDIDATE_NUMBER.GetFormattedValue())
    ' -------------------------
'End TextBox MIDDLE_NAME Event BeforeShow. Action Custom Code

'Hidden hidden_old_ATTENDING_SCHOOL_ID Event BeforeShow. Action Retrieve Value for Control @34-C95A8300
            STUDENThidden_old_ATTENDING_SCHOOL_ID.Value = (New FloatField("#0.00", (item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Hidden hidden_old_ATTENDING_SCHOOL_ID Event BeforeShow. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL      'ERA: 5-Feb-2010 set the link with out the strange extra bits
'DEL  	dim tmpHrefURL as string = strLocURL & tmpStudentID
'DEL  	STUDENTlink_showstudentfolder.HRef = tmpHrefURL.tostring()
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      'ERA: 28-Aug-2009|EA| trim the Surname 
'DEL  	'STUDENTSURNAME.Text=RTrim(item.SURNAME.GetFormattedValue())
'DEL      ' -------------------------


'TextBox STUDENT_EMAIL Event BeforeShow. Action Custom Code @64-73254650
    ' -------------------------
    'ERA: 8-May-2014|EA| trim the Email address as well, unfuddle #619
	STUDENTSTUDENT_EMAIL.Text=RTrim(item.STUDENT_EMAIL.GetFormattedValue())
    ' -------------------------
'End TextBox STUDENT_EMAIL Event BeforeShow. Action Custom Code

'TextBox VCE_CANDIDATE_NUMBER Event BeforeShow. Action Custom Code @132-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End TextBox VCE_CANDIDATE_NUMBER Event BeforeShow. Action Custom Code

'Record STUDENT Event BeforeShow. Action DLookup @77-6738A58A
            STUDENTlblAttendingSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action DLookup @78-32AD3C4D
            STUDENTlblHomeSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.HOME_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action DLookup @79-C010A0E7
            STUDENTEnrolmentCategoryTemp.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SUBCATEGORY_FULL_TITLE)" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "CATEGORY_CODE='" & item.CATEGORY_CODE.GetFormattedValue() & "' AND SUBCATEGORY_CODE='" & item.SUBCATEGORY_CODE.GetFormattedValue() & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action Custom Code @80-73254650
    ' -------------------------
    'ERA: change listbox to match Full Title from Enrolment_Categories, which is temporarily stored in the EnrolmentCategoryTemp field
	'	for just this purpose
	STUDENTListBox_SubCategory.Value = STUDENTEnrolmentCategoryTemp.Value
    ' -------------------------
'End Record STUDENT Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      'ERA: 5-Feb-2010|EA| extend normal show-hide code into a larger check for existance of actual folder, and set all the Visible in a single IF
'DEL  		STUDENTlabelContactPCSupport.visible = false	' usually not to be shown unless problems, below
'DEL  		dim tmpHrefCheck as string = strLocCreate & tmpStudentID
'DEL  
'DEL  		' if there is no Date created then never done and so should be created
'DEL  		if (item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()<>"") then 
'DEL  		    STUDENTButton_CreateStudentWorkFolder.visible = false
'DEL  			' so likely that folder exists, so double check
'DEL  			if (System.IO.Directory.Exists(tmpHrefCheck)) then
'DEL  				STUDENTlink_showstudentfolder.visible = true
'DEL  			else
'DEL  				STUDENTlink_showstudentfolder.visible = false	'debug, should be false
'DEL  				STUDENTlabelContactPCSupport.visible = true
'DEL  			end if
'DEL          End If
'DEL  
'DEL      ' -------------------------


'Record Form STUDENT Show method tail @3-F9DBAD9A
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT Show method tail

'Record Form STUDENT LoadItemFromRequest method @3-8A5725CB

    Protected Sub STUDENTLoadItemFromRequest(item As STUDENTItem, ByVal EnableValidation As Boolean)
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
            STUDENTErrors.Add("BIRTH_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"BIRTH DATE","dd/mm/yyyy"))
        End Try
        item.SEX.IsEmpty = IsNothing(Request.Form(STUDENTSEX.UniqueID))
        If Not IsNothing(STUDENTSEX.SelectedItem) Then
            item.SEX.SetValue(STUDENTSEX.SelectedItem.Value)
        Else
            item.SEX.Value = Nothing
        End If
        item.SEXItems.CopyFrom(STUDENTSEX.Items)
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
            STUDENTErrors.Add("ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectFormat,"ATTENDING SCHOOL ID","#0.00"))
        End Try
        Try
        item.HOME_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENTHOME_SCHOOL_ID.UniqueID))
        If ControlCustomValues("STUDENTHOME_SCHOOL_ID") Is Nothing Then
            item.HOME_SCHOOL_ID.SetValue(STUDENTHOME_SCHOOL_ID.Text)
        Else
            item.HOME_SCHOOL_ID.SetValue(ControlCustomValues("STUDENTHOME_SCHOOL_ID"))
        End If
        Catch ae As ArgumentException
            STUDENTErrors.Add("HOME_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectFormat,"HOME SCHOOL ID","#0.00"))
        End Try
        item.CATEGORY_CODE.IsEmpty = IsNothing(Request.Form(STUDENTCATEGORY_CODE.UniqueID))
        item.CATEGORY_CODE.SetValue(STUDENTCATEGORY_CODE.Value)
        item.SUBCATEGORY_CODE.IsEmpty = IsNothing(Request.Form(STUDENTSUBCATEGORY_CODE.UniqueID))
        item.SUBCATEGORY_CODE.SetValue(STUDENTSUBCATEGORY_CODE.Value)
        item.EnrolmentCategoryTemp.IsEmpty = IsNothing(Request.Form(STUDENTEnrolmentCategoryTemp.UniqueID))
        item.EnrolmentCategoryTemp.SetValue(STUDENTEnrolmentCategoryTemp.Value)
        Try
        item.hidden_old_ATTENDING_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENThidden_old_ATTENDING_SCHOOL_ID.UniqueID))
        item.hidden_old_ATTENDING_SCHOOL_ID.SetValue(STUDENThidden_old_ATTENDING_SCHOOL_ID.Value)
        Catch ae As ArgumentException
            STUDENTErrors.Add("hidden_old_ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_old_ATTENDING_SCHOOL_ID","#0.00"))
        End Try
        item.VSN.IsEmpty = IsNothing(Request.Form(STUDENTVSN.UniqueID))
        If ControlCustomValues("STUDENTVSN") Is Nothing Then
            item.VSN.SetValue(STUDENTVSN.Text)
        Else
            item.VSN.SetValue(ControlCustomValues("STUDENTVSN"))
        End If
        item.PREFERRED_NAME.IsEmpty = IsNothing(Request.Form(STUDENTPREFERRED_NAME.UniqueID))
        If ControlCustomValues("STUDENTPREFERRED_NAME") Is Nothing Then
            item.PREFERRED_NAME.SetValue(STUDENTPREFERRED_NAME.Text)
        Else
            item.PREFERRED_NAME.SetValue(ControlCustomValues("STUDENTPREFERRED_NAME"))
        End If
        item.ENROLLEDBEFORE.IsEmpty = IsNothing(Request.Form(STUDENTENROLLEDBEFORE.UniqueID))
        item.ENROLLEDBEFORE.SetValue(STUDENTENROLLEDBEFORE.Value)
        Try
        item.hidden_DATE_STUDENTFOLDER_CREATED.IsEmpty = IsNothing(Request.Form(STUDENThidden_DATE_STUDENTFOLDER_CREATED.UniqueID))
        item.hidden_DATE_STUDENTFOLDER_CREATED.SetValue(STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value)
        Catch ae As ArgumentException
            STUDENTErrors.Add("hidden_DATE_STUDENTFOLDER_CREATED",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_DATE_STUDENTFOLDER_CREATED","yyyy-mm-dd H:nn"))
        End Try
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENThidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(STUDENThidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENThidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(STUDENThidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENTErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","yyyy-mm-dd H:nn"))
        End Try
        item.STUDENT_EMAIL.IsEmpty = IsNothing(Request.Form(STUDENTSTUDENT_EMAIL.UniqueID))
        If ControlCustomValues("STUDENTSTUDENT_EMAIL") Is Nothing Then
            item.STUDENT_EMAIL.SetValue(STUDENTSTUDENT_EMAIL.Text)
        Else
            item.STUDENT_EMAIL.SetValue(ControlCustomValues("STUDENTSTUDENT_EMAIL"))
        End If
        item.STUDENT_MOBILE.IsEmpty = IsNothing(Request.Form(STUDENTSTUDENT_MOBILE.UniqueID))
        If ControlCustomValues("STUDENTSTUDENT_MOBILE") Is Nothing Then
            item.STUDENT_MOBILE.SetValue(STUDENTSTUDENT_MOBILE.Text)
        Else
            item.STUDENT_MOBILE.SetValue(ControlCustomValues("STUDENTSTUDENT_MOBILE"))
        End If
        item.Hidden_CURR_RESID_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(STUDENTHidden_CURR_RESID_ADDRESS_ID.UniqueID))
        item.Hidden_CURR_RESID_ADDRESS_ID.SetValue(STUDENTHidden_CURR_RESID_ADDRESS_ID.Value)
        item.listORG_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENTlistORG_SCHOOL_ID.UniqueID))
        item.listORG_SCHOOL_ID.SetValue(STUDENTlistORG_SCHOOL_ID.Value)
        item.listORG_SCHOOL_IDItems.CopyFrom(STUDENTlistORG_SCHOOL_ID.Items)
        item.VCE_CANDIDATE_NUMBER.IsEmpty = IsNothing(Request.Form(STUDENTVCE_CANDIDATE_NUMBER.UniqueID))
        If ControlCustomValues("STUDENTVCE_CANDIDATE_NUMBER") Is Nothing Then
            item.VCE_CANDIDATE_NUMBER.SetValue(STUDENTVCE_CANDIDATE_NUMBER.Text)
        Else
            item.VCE_CANDIDATE_NUMBER.SetValue(ControlCustomValues("STUDENTVCE_CANDIDATE_NUMBER"))
        End If
        If EnableValidation Then
            item.Validate(STUDENTData)
        End If
        STUDENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT LoadItemFromRequest method

'Record Form STUDENT GetRedirectUrl method @3-EEDCA0F7

    Protected Function GetSTUDENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FutureEnrol_StudentMaintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT GetRedirectUrl method

'Record Form STUDENT ShowErrors method @3-0193A443

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

'Record Form STUDENT Insert Operation @3-14FA6976

    Protected Sub STUDENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Insert Operation

'Button Button_Insert OnClick. @25-0BE051F2
        If CType(sender,Control).ID = "STUDENTButton_Insert" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @25-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT Event BeforeInsert. Action DLookup @87-80D9E180
        STUDENTCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeInsert. Action DLookup

'Record STUDENT Event BeforeInsert. Action DLookup @88-86753990
        STUDENTSUBCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeInsert. Action DLookup

'Record Form STUDENT BeforeInsert tail @3-4976F38F
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

'Record Form STUDENT AfterInsert tail  @3-C6B64346
        End If
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT AfterInsert tail 

'Record Form STUDENT Update Operation @3-5F39C5C9

    Protected Sub STUDENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT Update Operation

'Button Button_Update OnClick. @26-C6DD6D39
        If CType(sender,Control).ID = "STUDENTButton_Update" Then
            RedirectUrl = GetSTUDENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @26-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'DEL      ' -------------------------
'DEL  	    'ERA: get the URL student Id and create the student folder
'DEL  		' per code from Vikas
'DEL  		' strLocCreate is public for page
'DEL  		Try
'DEL  			if (Directory.Exists(strLocCreate & tmpSTUDENT_ID)) then 
'DEL  			else
'DEL  		    	Directory.CreateDirectory(strLocCreate & tmpSTUDENT_ID)
'DEL  				'STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value = (New DateField(Settings.DateFormat, (now()))).GetFormattedValue()
'DEL  			end if
'DEL  
'DEL  		Catch ex As Exception
'DEL  	    	Response.Write("Erics Nice Error Catch:" & ex.Message.ToString())
'DEL  		Finally
'DEL  	    End Try
'DEL      ' -------------------------

'Record STUDENT Event BeforeUpdate. Action Custom Code @82-73254650
    ' -------------------------
    'ERA: 26-Feb-2010 |EA| modify the First, Middle,Preferred,  Surname to UPPER case. unfuddle 
	'ERA: 25-Nov-2011 |EA| remove the auto-upper case, per request (unfuddle #423)
	'STUDENTSURNAME.Text = UCase(STUDENTSURNAME.Text)
	'STUDENTFIRST_NAME.Text = UCase(STUDENTFIRST_NAME.Text)
	'STUDENTMIDDLE_NAME.Text = UCase(STUDENTMIDDLE_NAME.Text)
	'STUDENTPREFERRED_NAME.Text = UCase(STUDENTPREFERRED_NAME.Text)
	'4-Apr-2011|EA| added VCE Candidate number just in case
	STUDENTVCE_CANDIDATE_NUMBER.Text = UCase(STUDENTVCE_CANDIDATE_NUMBER.Text)
	
    ' -------------------------
'End Record STUDENT Event BeforeUpdate. Action Custom Code

'Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control @83-DD295D03
        STUDENThidden_LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control @84-301CF505
        STUDENThidden_LAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT Event BeforeUpdate. Action DLookup @85-80D9E180
        STUDENTCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action DLookup

'Record STUDENT Event BeforeUpdate. Action DLookup @86-86753990
        STUDENTSUBCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action DLookup

'Record Form STUDENT Before Update tail @3-6A432CC4
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

'Record STUDENT Event AfterUpdate. Action Save Variable Value @219-7F6B717D
        HttpContext.Current.Session("notifymessage") = "Student Record Updated"
'End Record STUDENT Event AfterUpdate. Action Save Variable Value

'Record Form STUDENT Update Operation tail @3-C6B64346
        End If
        ErrorFlag=(STUDENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT Update Operation tail

'Record Form STUDENT Delete Operation @3-31D1E637
    Protected Sub STUDENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENTItem = New STUDENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT Delete Operation

'Record Form BeforeDelete tail @3-9400BDAA
        STUDENTParameters()
        STUDENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-73926DB1
        If ErrorFlag Then
            STUDENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT Cancel Operation @3-4BEF842D

    Protected Sub STUDENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTItem = New STUDENTItem()
        STUDENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENTLoadItemFromRequest(item, False)
'End Record Form STUDENT Cancel Operation

'Button Button_Cancel OnClick. @29-2667087A
    If CType(sender,Control).ID = "STUDENTButton_Cancel" Then
        RedirectUrl = GetSTUDENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @29-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT Cancel Operation tail

'Record Form STUDENT_ENROLMENT Parameters @134-B4432813

    Protected Sub STUDENT_ENROLMENTParameters()
        Dim item As new STUDENT_ENROLMENTItem
        Try
            STUDENT_ENROLMENTData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_ENROLMENTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_ENROLMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_ENROLMENT Parameters

'Record Form STUDENT_ENROLMENT Show method @134-01993FE5
    Protected Sub STUDENT_ENROLMENTShow()
        If STUDENT_ENROLMENTOperations.None Then
            STUDENT_ENROLMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_ENROLMENTItem = STUDENT_ENROLMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_ENROLMENTOperations.AllowRead
        STUDENT_ENROLMENTErrors.Add(item.errors)
        If STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_ENROLMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_ENROLMENT Show method

'Record Form STUDENT_ENROLMENT BeforeShow tail @134-2A4F998E
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTData.FillItem(item, IsInsertMode)
        STUDENT_ENROLMENTHolder.DataBind()
        STUDENT_ENROLMENTButton_Add.Visible=IsInsertMode AndAlso STUDENT_ENROLMENTOperations.AllowInsert
        STUDENT_ENROLMENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_ENROLMENTOperations.AllowUpdate
        STUDENT_ENROLMENTlblENROLMENT_YEAR.Text = Server.HtmlEncode(item.lblENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTENROLMENT_STATUS.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTENROLMENT_STATUS.Items(0).Selected = True
        item.ENROLMENT_STATUSItems.SetSelection(item.ENROLMENT_STATUS.GetFormattedValue())
        If Not item.ENROLMENT_STATUSItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTENROLMENT_STATUS.SelectedIndex = -1
        End If
        item.ENROLMENT_STATUSItems.CopyTo(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        STUDENT_ENROLMENTENROLMENT_DATE.Text=item.ENROLMENT_DATE.GetFormattedValue()
        STUDENT_ENROLMENTLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        STUDENT_ENROLMENTLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_ENROLMENTYEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTYEAR_LEVEL.Items(0).Selected = True
        item.YEAR_LEVELItems.SetSelection(item.YEAR_LEVEL.GetFormattedValue())
        If Not item.YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTYEAR_LEVEL.SelectedIndex = -1
        End If
        item.YEAR_LEVELItems.CopyTo(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        STUDENT_ENROLMENTLAST_ALTERED_BY1.Text = Server.HtmlEncode(item.LAST_ALTERED_BY1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTLAST_ALTERED_DATE1.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_ENROLMENTENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
'End Record Form STUDENT_ENROLMENT BeforeShow tail

'Label lblENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control @252-5E4891C7
            STUDENT_ENROLMENTlblENROLMENT_YEAR.Text = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Label lblENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control

'Hidden STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @249-6364978B
            STUDENT_ENROLMENTSTUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden ENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control @251-E64DA63D
            STUDENT_ENROLMENTENROLMENT_YEAR.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Hidden ENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_ENROLMENT Show method tail @134-ECC726FD
        If STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_ENROLMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT Show method tail

'Record Form STUDENT_ENROLMENT LoadItemFromRequest method @134-E663BDF4

    Protected Sub STUDENT_ENROLMENTLoadItemFromRequest(item As STUDENT_ENROLMENTItem, ByVal EnableValidation As Boolean)
        item.ENROLMENT_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_STATUS.UniqueID))
        item.ENROLMENT_STATUS.SetValue(STUDENT_ENROLMENTENROLMENT_STATUS.Value)
        item.ENROLMENT_STATUSItems.CopyFrom(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        Try
        item.ENROLMENT_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_DATE.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTENROLMENT_DATE") Is Nothing Then
            item.ENROLMENT_DATE.SetValue(STUDENT_ENROLMENTENROLMENT_DATE.Text)
        Else
            item.ENROLMENT_DATE.SetValue(ControlCustomValues("STUDENT_ENROLMENTENROLMENT_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("ENROLMENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"ENROLMENT DATE","dd/mm/yyyy"))
        End Try
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(STUDENT_ENROLMENTLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","yyyy-mm-dd H:nn"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(STUDENT_ENROLMENTLAST_ALTERED_BY.Value)
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTYEAR_LEVEL.UniqueID))
        item.YEAR_LEVEL.SetValue(STUDENT_ENROLMENTYEAR_LEVEL.Value)
        item.YEAR_LEVELItems.CopyFrom(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_ENROLMENTSTUDENT_ID.Value)
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(STUDENT_ENROLMENTENROLMENT_YEAR.Value)
        If EnableValidation Then
            item.Validate(STUDENT_ENROLMENTData)
        End If
        STUDENT_ENROLMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_ENROLMENT LoadItemFromRequest method

'Record Form STUDENT_ENROLMENT GetRedirectUrl method @134-C0967373

    Protected Function GetSTUDENT_ENROLMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_ENROLMENT GetRedirectUrl method

'Record Form STUDENT_ENROLMENT ShowErrors method @134-E76A22EF

    Protected Sub STUDENT_ENROLMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_ENROLMENTErrors.Count - 1
        Select Case STUDENT_ENROLMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_ENROLMENTErrors(i)
        End Select
        Next i
        STUDENT_ENROLMENTError.Visible = True
        STUDENT_ENROLMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_ENROLMENT ShowErrors method

'Record Form STUDENT_ENROLMENT Insert Operation @134-75D92E30

    Protected Sub STUDENT_ENROLMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_ENROLMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT Insert Operation

'Button Button_Add OnClick. @180-31C744F7
        If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Add" Then
            RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Add OnClick.

'Button Button_Add OnClick tail. @180-477CF3C9
        End If
'End Button Button_Add OnClick tail.

'Record Form STUDENT_ENROLMENT BeforeInsert tail @134-5C6B4A06
    STUDENT_ENROLMENTParameters()
    STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
    If STUDENT_ENROLMENTOperations.AllowInsert Then
        ErrorFlag=(STUDENT_ENROLMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_ENROLMENTData.InsertItem(item)
            Catch ex As Exception
                STUDENT_ENROLMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_ENROLMENT BeforeInsert tail

'Record Form STUDENT_ENROLMENT AfterInsert tail  @134-D12A32EA
        End If
        ErrorFlag=(STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT AfterInsert tail 

'Record Form STUDENT_ENROLMENT Update Operation @134-3B065CD3

    Protected Sub STUDENT_ENROLMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT Update Operation

'Button Button_Update OnClick. @181-7FA3559F
        If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Update" Then
            RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @181-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @182-59CD05FF
        STUDENT_ENROLMENTLAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserID.ToUpper))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @183-D8ABD013
        STUDENT_ENROLMENTLAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_ENROLMENT Before Update tail @134-C85BE3DE
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
        If STUDENT_ENROLMENTOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_ENROLMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_ENROLMENTData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_ENROLMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_ENROLMENT Before Update tail

'Record STUDENT_ENROLMENT Event AfterUpdate. Action Save Variable Value @218-61954E7E
        HttpContext.Current.Session("notifymessage") = "Student Enrolment Record Updated"
'End Record STUDENT_ENROLMENT Event AfterUpdate. Action Save Variable Value

'Record Form STUDENT_ENROLMENT Update Operation tail @134-D12A32EA
        End If
        ErrorFlag=(STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT Update Operation tail

'Record Form STUDENT_ENROLMENT Delete Operation @134-9953013B
    Protected Sub STUDENT_ENROLMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_ENROLMENT Delete Operation

'Record Form BeforeDelete tail @134-5B58CAB2
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @134-D5C63583
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_ENROLMENT Cancel Operation @134-D42DF6B4

    Protected Sub STUDENT_ENROLMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_ENROLMENTLoadItemFromRequest(item, True)
'End Record Form STUDENT_ENROLMENT Cancel Operation

'Record Form STUDENT_ENROLMENT Cancel Operation tail @134-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_ENROLMENT Cancel Operation tail

'EditableGrid EditableGrid1 Bind @184-B0C9C18B
    Protected Sub EditableGrid1Bind()
        If EditableGrid1Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"EditableGrid1",GetType(EditableGrid1DataProvider.SortFields), 25, 100)
        End If
'End EditableGrid EditableGrid1 Bind

'EditableGrid Form EditableGrid1 BeforeShow tail @184-0FD831D5
        EditableGrid1Parameters()
        EditableGrid1Data.SortField = CType(ViewState("EditableGrid1SortField"), EditableGrid1DataProvider.SortFields)
        EditableGrid1Data.SortDir = CType(ViewState("EditableGrid1SortDir"), SortDirections)
        EditableGrid1Data.PageNumber = CType(ViewState("EditableGrid1PageNumber"), Integer)
        EditableGrid1Data.RecordsPerPage = CType(ViewState("EditableGrid1PageSize"), Integer)
        EditableGrid1Repeater.DataSource = EditableGrid1Data.GetResultSet(PagesCount, EditableGrid1Operations)
        ViewState("EditableGrid1PagesCount") = PagesCount
        ViewState("EditableGrid1FormState") = New Hashtable()
        ViewState("EditableGrid1RowState") = New Hashtable()
        EditableGrid1Repeater.DataBind()
        Dim item As EditableGrid1Item = EditableGrid1DataItem
        If IsNothing(item) Then item = New EditableGrid1Item()
        FooterIndex = EditableGrid1Repeater.Controls.Count - 1
        Dim EditableGrid1Button_Submit As System.Web.UI.WebControls.Button = DirectCast(EditableGrid1Repeater.Controls(FooterIndex).FindControl("EditableGrid1Button_Submit"),System.Web.UI.WebControls.Button)
        Dim EditableGrid1Cancel As System.Web.UI.WebControls.Button = DirectCast(EditableGrid1Repeater.Controls(FooterIndex).FindControl("EditableGrid1Cancel"),System.Web.UI.WebControls.Button)
        Dim EditableGrid1Button_LoadChecklist As System.Web.UI.WebControls.Button = DirectCast(EditableGrid1Repeater.Controls(FooterIndex).FindControl("EditableGrid1Button_LoadChecklist"),System.Web.UI.WebControls.Button)


        EditableGrid1Button_Submit.Visible = EditableGrid1Operations.Editable
        If Not CType(EditableGrid1Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            EditableGrid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If EditableGrid1Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(EditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(EditableGrid1Repeater.Controls(0).FindControl("EditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In EditableGrid1Errors
                ErrorLabel.Text += EditableGrid1Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form EditableGrid1 BeforeShow tail

'EditableGrid EditableGrid1 Bind tail @184-F48D4C57
        EditableGrid1ShowErrors(New ArrayList(CType(EditableGrid1Repeater.DataSource, ICollection)), EditableGrid1Repeater.Items)
    End Sub
'End EditableGrid EditableGrid1 Bind tail

'EditableGrid EditableGrid1 Table Parameters @184-8E35259D
    Protected Sub EditableGrid1Parameters()
        Try
        Dim item As new EditableGrid1Item
            EditableGrid1Data.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            EditableGrid1Data.Ctrloption_received = TextParameter.GetParam(item.option_received.Value, ParameterSourceType.Control, "", Nothing, false)
            EditableGrid1Data.Ctrlnotes_public = TextParameter.GetParam(item.notes_public.Value, ParameterSourceType.Control, "", Nothing, false)
            EditableGrid1Data.Expr203 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            EditableGrid1Data.Expr204 = TextParameter.GetParam(DBUtility.UserID.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
            EditableGrid1Data.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = EditableGrid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(EditableGrid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid EditableGrid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid EditableGrid1 Table Parameters

'EditableGrid EditableGrid1 ItemDataBound event @184-3D01E33E
    Protected Sub EditableGrid1ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As EditableGrid1Item = DirectCast(e.Item.DataItem, EditableGrid1Item)
        Dim Item as EditableGrid1Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            EditableGrid1CurrentRowNumber = EditableGrid1CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("EditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditableGrid1RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("idField:" & e.Item.ItemIndex, DataItem.idField.Value)
            ViewState(e.Item.FindControl("EditableGrid1id").UniqueID) = DataItem.id.Value
            ViewState(e.Item.FindControl("EditableGrid1description").UniqueID) = DataItem.description.Value
            ViewState(e.Item.FindControl("EditableGrid1lblWhen").UniqueID) = DataItem.lblWhen.Value
            ViewState(e.Item.FindControl("EditableGrid1lblWho").UniqueID) = DataItem.lblWho.Value
            Dim EditableGrid1id As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1id"),System.Web.UI.WebControls.Literal)
            Dim EditableGrid1description As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1description"),System.Web.UI.WebControls.Literal)
            Dim EditableGrid1option_received As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("EditableGrid1option_received"),System.Web.UI.WebControls.RadioButtonList)
            Dim EditableGrid1notes_public As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("EditableGrid1notes_public"),System.Web.UI.WebControls.TextBox)
            Dim EditableGrid1last_altered_when As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("EditableGrid1last_altered_when"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim EditableGrid1CheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("EditableGrid1CheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim EditableGrid1lblWhen As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1lblWhen"),System.Web.UI.WebControls.Literal)
            Dim EditableGrid1last_altered_by As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("EditableGrid1last_altered_by"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim EditableGrid1lblWho As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditableGrid1lblWho"),System.Web.UI.WebControls.Literal)
            Dim EditableGrid1hidden_hashchanges As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("EditableGrid1hidden_hashchanges"),System.Web.UI.HtmlControls.HtmlInputHidden)
            CType(Page,CCPage).ControlAttributes.Add(EditableGrid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, EditableGrid1CurrentRowNumber), AttributeOption.Multiple)
            DataItem.option_receivedItems.SetSelection(DataItem.option_received.GetFormattedValue())
            EditableGrid1option_received.SelectedIndex = -1
            DataItem.option_receivedItems.CopyTo(EditableGrid1option_received.Items, True)
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                EditableGrid1CheckBox_Delete.Checked = True
            End If
        End If
'End EditableGrid EditableGrid1 ItemDataBound event

'EditableGrid1 control Before Show @184-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid1 control Before Show

'Get Control @209-BC85BE1A
            Dim EditableGrid1hidden_hashchanges As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("EditableGrid1hidden_hashchanges"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control


'Hidden hidden_hashchanges Event BeforeShow. Action Custom Code @210-73254650
    ' -------------------------
      '26-Nov-2018|EA| simple string of items to allow compare before update so only changed items are updated.
      EditableGrid1hidden_hashchanges.Value=DataItem.idField.Value & DataItem.option_received.GetFormattedValue()& DataItem.notes_public.Value
    ' -------------------------
'End Hidden hidden_hashchanges Event BeforeShow. Action Custom Code

'EditableGrid1 control Before Show tail @184-477CF3C9
        End If
'End EditableGrid1 control Before Show tail

'EditableGrid EditableGrid1 BeforeShowRow event @184-5B819080
        If Not IsNothing(Item) Then EditableGrid1DataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid EditableGrid1 BeforeShowRow event

'EditableGrid EditableGrid1 BeforeShowRow event tail @184-477CF3C9
        End If
'End EditableGrid EditableGrid1 BeforeShowRow event tail

'EditableGrid EditableGrid1 ItemDataBound event tail @184-E31F8E2A
    End Sub
'End EditableGrid EditableGrid1 ItemDataBound event tail

'EditableGrid EditableGrid1 GetRedirectUrl method @184-9FE0ED8C
    Protected Function GetEditableGrid1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetEditableGrid1RedirectUrl(ByVal redirectString As String) As String
        Return GetEditableGrid1RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid EditableGrid1 GetRedirectUrl method

'EditableGrid EditableGrid1 ShowErrors method @184-37DAE1CF
    Protected Function EditableGrid1ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), EditableGrid1Item).IsUpdated Then col(CType(items(i), EditableGrid1Item).RowId).Visible = False
            If (CType(items(i), EditableGrid1Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), EditableGrid1Item).errors.Count - 1
                Select CType(items(i), EditableGrid1Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), EditableGrid1Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), EditableGrid1Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), EditableGrid1Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid EditableGrid1 ShowErrors method

'EditableGrid EditableGrid1 ItemCommand event @184-659AF02B
    Protected Sub EditableGrid1ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = EditableGrid1Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid EditableGrid1 ItemCommand event

'Button Button_Submit OnClick. @194-C339CCA2
        If Ctype(e.CommandSource,Control).ID = "EditableGrid1Button_Submit" Then
            RedirectUrl  = GetEditableGrid1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @194-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @195-2776B4A7
        If Ctype(e.CommandSource,Control).ID = "EditableGrid1Cancel" Then
            RedirectUrl  = GetEditableGrid1RedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @195-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'Button Button_LoadChecklist OnClick. @253-C13C86A9
        If Ctype(e.CommandSource,Control).ID = "EditableGrid1Button_LoadChecklist" Then
            RedirectUrl  = GetEditableGrid1RedirectUrl("", "")
            EnableValidation  = false
'End Button Button_LoadChecklist OnClick.

'Button Button_LoadChecklist Event OnClick. Action Custom Code @254-73254650
    ' -------------------------
		    ' 5-Dec-2018|EA| when clicked, will attempt to load Enrolment Category Checklist   
		    dim tmpStudentID as integer = CInt(Request.QueryString("STUDENT_ID"))
		    dim tmpEnrolYear as integer = CInt(Request.QueryString("ENROLMENT_YEAR"))
		    
		    if (tmpStudentID > 90000 AND tmpEnrolYear > 2018) then
		    	dim tmpEnrolCategory as string = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT CATEGORY_CODE FROM STUDENT WHERE STUDENT_ID="+tmpStudentID.ToString))).Value, String)
				if (tmpEnrolCategory <>"") then
					' pass into Proc to create other stubs as needed		
					dim stubSQL as string = ""
						stubSQL = "INSERT INTO [dbo].STUDENT_ENROL_CHECKLIST (STUDENT_ID, ENROLMENT_YEAR, ENROL_CHECKLIST_ID, OPTION_RECEIVED ,[LAST_ALTERED_BY],[LAST_ALTERED_WHEN]) "
			  			stubSQL += " SELECT "+tmpStudentID.ToString+", "+tmpEnrolYear.ToString+", ID, 'W' , '"+DBUtility.UserID.ToUpper+"', getdate() "
			  			stubSQL += " FROM ENROL_CHECKLIST where active='Y' "
			  			stubSQL += " and (isnull(categories_required,'ALL')='ALL' or categories_required='' or categories_required='"+tmpEnrolCategory+"')"
						stubSQL += " order by id" 
					dim stubReturn as integer = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteNonQuery(stubSQL)
				end if	    	
		    end if	
    ' -------------------------
'End Button Button_LoadChecklist Event OnClick. Action Custom Code

'Button Button_LoadChecklist OnClick tail. @253-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Button_LoadChecklist OnClick tail.

'EditableGrid Form EditableGrid1 ItemCommand event tail @184-638838BA
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("EditableGrid1SortDir"), SortDirections) = SortDirections._Asc And ViewState("EditableGrid1SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("EditableGrid1SortDir") = SortDirections._Desc
                Else
                    ViewState("EditableGrid1SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("EditableGrid1SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As EditableGrid1DataProvider.SortFields = 0
            ViewState("EditableGrid1SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("EditableGrid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("EditableGrid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("EditableGrid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("EditableGrid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            EditableGrid1IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = EditableGrid1Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("EditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditableGrid1RowState"), Hashtable)
            EditableGrid1Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim EditableGrid1id As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1id"),System.Web.UI.WebControls.Literal)
                    Dim EditableGrid1description As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1description"),System.Web.UI.WebControls.Literal)
                    Dim EditableGrid1option_received As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("EditableGrid1option_received"),System.Web.UI.WebControls.RadioButtonList)
                    Dim EditableGrid1notes_public As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("EditableGrid1notes_public"),System.Web.UI.WebControls.TextBox)
                    Dim EditableGrid1last_altered_when As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("EditableGrid1last_altered_when"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim EditableGrid1CheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("EditableGrid1CheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim EditableGrid1lblWhen As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1lblWhen"),System.Web.UI.WebControls.Literal)
                    Dim EditableGrid1last_altered_by As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("EditableGrid1last_altered_by"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim EditableGrid1lblWho As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditableGrid1lblWho"),System.Web.UI.WebControls.Literal)
                    Dim EditableGrid1hidden_hashchanges As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("EditableGrid1hidden_hashchanges"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As EditableGrid1Item = New EditableGrid1Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.idField.Value = formState("idField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("EditableGrid1CheckBox_Delete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.id.Value = ViewState(EditableGrid1id.UniqueID)
                    item.description.Value = ViewState(EditableGrid1description.UniqueID)
                    item.lblWhen.Value = ViewState(EditableGrid1lblWhen.UniqueID)
                    item.lblWho.Value = ViewState(EditableGrid1lblWho.UniqueID)
                    item.option_received.IsEmpty = IsNothing(Request.Form(EditableGrid1option_received.UniqueID))
                    If Not IsNothing(EditableGrid1option_received.SelectedItem) Then
                        item.option_received.SetValue(EditableGrid1option_received.SelectedItem.Value)
                    Else
                        item.option_received.Value = Nothing
                    End If
                    item.option_receivedItems.CopyFrom(EditableGrid1option_received.Items)
                    item.notes_public.IsEmpty = IsNothing(Request.Form(EditableGrid1notes_public.UniqueID))
                    If ControlCustomValues("EditableGrid1notes_public") Is Nothing Then
                        item.notes_public.SetValue(EditableGrid1notes_public.Text)
                    Else
                        item.notes_public.SetValue(ControlCustomValues("EditableGrid1notes_public"))
                    End If
                    Try
                    item.last_altered_when.IsEmpty = IsNothing(Request.Form(EditableGrid1last_altered_when.UniqueID))
                    item.last_altered_when.SetValue(EditableGrid1last_altered_when.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("last_altered_when",String.Format(Resources.strings.CCS_IncorrectFormat,"Last Altered When","dd/mm/yyyy h:nn AM/PM"))
                    End Try
                    item.last_altered_by.IsEmpty = IsNothing(Request.Form(EditableGrid1last_altered_by.UniqueID))
                    item.last_altered_by.SetValue(EditableGrid1last_altered_by.Value)
                    item.hidden_hashchanges.IsEmpty = IsNothing(Request.Form(EditableGrid1hidden_hashchanges.UniqueID))
                    item.hidden_hashchanges.SetValue(EditableGrid1hidden_hashchanges.Value)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(EditableGrid1Data) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form EditableGrid1 ItemCommand event tail

'EditableGrid EditableGrid1 Event OnValidate. Action Custom Code @215-73254650
    ' -------------------------
    'Nov-2018|EA| show a message if any errors below this
    'Dim EditableGrid1lblCheckErrors As System.Web.UI.WebControls.Literal = CType(EditableGrid1.FindControl("EditableGrid1description"),System.Web.UI.WebControls.Literal)
    'EditableGrid1lblCheckErrors.Visible=false
    if (EditableGrid1Errors.Count > 0) then
    	'EditableGrid1lblCheckErrors.Visible=true
    	response.write(EditableGrid1Errors.Count)
    	response.[end]
    end if
    ' -------------------------
'End EditableGrid EditableGrid1 Event OnValidate. Action Custom Code

'EditableGrid EditableGrid1 Update @184-E40FE86D
            If BindAllowed Then
                Try
                    EditableGrid1Parameters()
                    EditableGrid1Data.Update(items, EditableGrid1Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(EditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(EditableGrid1Repeater.Controls(0).FindControl("EditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
                Finally
'End EditableGrid EditableGrid1 Update

'EditableGrid EditableGrid1 Event AfterSubmit. Action Save Variable Value @217-85FBBDFB
            HttpContext.Current.Session("notifymessage") = "Enrol Checklist updated"
'End EditableGrid EditableGrid1 Event AfterSubmit. Action Save Variable Value

'EditableGrid EditableGrid1 After Update @184-8005DFA8
                End Try
                If EditableGrid1ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                EditableGrid1ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                EditableGrid1Bind()
            End If
        End Sub
'End EditableGrid EditableGrid1 After Update

'Record Form STUDENT_COMMENT Parameters @255-70491353

    Protected Sub STUDENT_COMMENTParameters()
        Dim item As new STUDENT_COMMENTItem
        Try
            STUDENT_COMMENTData.UrlCOMMENT_ID = IntegerParameter.GetParam("COMMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_COMMENTData.CtrlSTUDENT_ID = TextParameter.GetParam(item.STUDENT_ID.Value, ParameterSourceType.Control, "", "", false)
            STUDENT_COMMENTData.CtrlCOMMENT = TextParameter.GetParam(item.COMMENT.Value, ParameterSourceType.Control, "", "", false)
            STUDENT_COMMENTData.Expr281 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)
            STUDENT_COMMENTData.CtrlHidden_CommentType = TextParameter.GetParam(item.Hidden_CommentType.Value, ParameterSourceType.Control, "", "REGULAR", false)
        Catch e As Exception
            STUDENT_COMMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_COMMENT Parameters

'Record Form STUDENT_COMMENT Show method @255-E9AA1622
    Protected Sub STUDENT_COMMENTShow()
        If STUDENT_COMMENTOperations.None Then
            STUDENT_COMMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_COMMENTItem = STUDENT_COMMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_COMMENTOperations.AllowRead
        STUDENT_COMMENTErrors.Add(item.errors)
        If STUDENT_COMMENTErrors.Count > 0 Then
            STUDENT_COMMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_COMMENT Show method

'Record Form STUDENT_COMMENT BeforeShow tail @255-D5834965
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTData.FillItem(item, IsInsertMode)
        STUDENT_COMMENTHolder.DataBind()
        STUDENT_COMMENTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_COMMENTOperations.AllowInsert
        STUDENT_COMMENTlblSTUDENT_ID.Text = Server.HtmlEncode(item.lblSTUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_COMMENTCOMMENT.Text=item.COMMENT.GetFormattedValue()
        STUDENT_COMMENTSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_COMMENThidden_STATUS.Value = item.hidden_STATUS.GetFormattedValue()
        STUDENT_COMMENTHidden_CommentType.Value = item.Hidden_CommentType.GetFormattedValue()
        STUDENT_COMMENTlblCommentType.Text = Server.HtmlEncode(item.lblCommentType.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_COMMENTlbSpecialCommentType.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbSpecialCommentType.Items(0).Selected = True
        item.lbSpecialCommentTypeItems.SetSelection(item.lbSpecialCommentType.GetFormattedValue())
        If Not item.lbSpecialCommentTypeItems.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbSpecialCommentType.SelectedIndex = -1
        End If
        item.lbSpecialCommentTypeItems.CopyTo(STUDENT_COMMENTlbSpecialCommentType.Items)
        STUDENT_COMMENTlbSpecialCommentType1.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbSpecialCommentType1.Items(0).Selected = True
        item.lbSpecialCommentType1Items.SetSelection(item.lbSpecialCommentType1.GetFormattedValue())
        If Not item.lbSpecialCommentType1Items.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbSpecialCommentType1.SelectedIndex = -1
        End If
        item.lbSpecialCommentType1Items.CopyTo(STUDENT_COMMENTlbSpecialCommentType1.Items)
        STUDENT_COMMENTlbCannedResponses.Items.Add(new ListItem("Select Value",""))
        STUDENT_COMMENTlbCannedResponses.Items(0).Selected = True
        item.lbCannedResponsesItems.SetSelection(item.lbCannedResponses.GetFormattedValue())
        If Not item.lbCannedResponsesItems.GetSelectedItem() Is Nothing Then
            STUDENT_COMMENTlbCannedResponses.SelectedIndex = -1
        End If
        item.lbCannedResponsesItems.CopyTo(STUDENT_COMMENTlbCannedResponses.Items)
'End Record Form STUDENT_COMMENT BeforeShow tail

'ListBox lbCannedResponses Event BeforeShow. Action Custom Code @100-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End ListBox lbCannedResponses Event BeforeShow. Action Custom Code

'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @273-50767707
            STUDENT_COMMENTSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @274-A6DAAB77
            STUDENT_COMMENTlblSTUDENT_ID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_COMMENT Event BeforeShow. Action Custom Code @275-73254650
            ' -------------------------
            ' ERA: 13-Aug-2010|EA| check if special groups of users and if so then show the Special Comment Type Label and drop-down
            ' currently these groups: 2:PRINCIPALS; 3:ADMINISTRATORS; 6:ENROLMENT OFFICERS; 7:LEADING TEACHERS;9:SYSTEM;
            '	(unfuddle #200)
            ' ERA: 28-Jan-2011|EA| added new drop-down for regular teachers etc, to allow adding of Contact Types.
            '	(unfuddle #356)
            '23-July-2015|EA| added Wellbeing to the Power Groups!
            '27-Aug-2015|EA| convert to global setting incase we need to add a new group in future
			dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
			dim arrHigherGroups as String() = strHigherGroups.split(",")
			If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            'If (DBUtility.AuthorizeUser(New String() {"2", "3", "6", "7", "9","12"})) Then
                STUDENT_COMMENTlblCommentType.visible = True
                STUDENT_COMMENTlbSpecialCommentType.visible = True
                STUDENT_COMMENTlbSpecialCommentType1.visible = False    '28-Jan

            Else
                STUDENT_COMMENTlblCommentType.visible = False
                STUDENT_COMMENTlbSpecialCommentType.visible = False
                STUDENT_COMMENTlbSpecialCommentType1.visible = True     '28-Jan
            End If
            ' -------------------------
            'End Record STUDENT_COMMENT Event BeforeShow. Action Custom Code

'Record Form STUDENT_COMMENT Show method tail @255-D9280E89
        If STUDENT_COMMENTErrors.Count > 0 Then
            STUDENT_COMMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_COMMENT Show method tail

'Record Form STUDENT_COMMENT LoadItemFromRequest method @255-9AA4E5E4

    Protected Sub STUDENT_COMMENTLoadItemFromRequest(item As STUDENT_COMMENTItem, ByVal EnableValidation As Boolean)
        item.COMMENT.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTCOMMENT.UniqueID))
        If ControlCustomValues("STUDENT_COMMENTCOMMENT") Is Nothing Then
            item.COMMENT.SetValue(STUDENT_COMMENTCOMMENT.Text)
        Else
            item.COMMENT.SetValue(ControlCustomValues("STUDENT_COMMENTCOMMENT"))
        End If
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_COMMENTSTUDENT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_COMMENTErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.hidden_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENThidden_STATUS.UniqueID))
        item.hidden_STATUS.SetValue(STUDENT_COMMENThidden_STATUS.Value)
        item.Hidden_CommentType.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTHidden_CommentType.UniqueID))
        item.Hidden_CommentType.SetValue(STUDENT_COMMENTHidden_CommentType.Value)
        item.lbSpecialCommentType.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbSpecialCommentType.UniqueID))
        item.lbSpecialCommentType.SetValue(STUDENT_COMMENTlbSpecialCommentType.Value)
        item.lbSpecialCommentTypeItems.CopyFrom(STUDENT_COMMENTlbSpecialCommentType.Items)
        item.lbSpecialCommentType1.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbSpecialCommentType1.UniqueID))
        item.lbSpecialCommentType1.SetValue(STUDENT_COMMENTlbSpecialCommentType1.Value)
        item.lbSpecialCommentType1Items.CopyFrom(STUDENT_COMMENTlbSpecialCommentType1.Items)
        item.lbCannedResponses.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbCannedResponses.UniqueID))
        item.lbCannedResponses.SetValue(STUDENT_COMMENTlbCannedResponses.Value)
        item.lbCannedResponsesItems.CopyFrom(STUDENT_COMMENTlbCannedResponses.Items)
        If EnableValidation Then
            item.Validate(STUDENT_COMMENTData)
        End If
        STUDENT_COMMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_COMMENT LoadItemFromRequest method

'Record Form STUDENT_COMMENT GetRedirectUrl method @255-86827CC1

    Protected Function GetSTUDENT_COMMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_COMMENT GetRedirectUrl method

'Record Form STUDENT_COMMENT ShowErrors method @255-C5038092

    Protected Sub STUDENT_COMMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_COMMENTErrors.Count - 1
        Select Case STUDENT_COMMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_COMMENTErrors(i)
        End Select
        Next i
        STUDENT_COMMENTError.Visible = True
        STUDENT_COMMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_COMMENT ShowErrors method

'Record Form STUDENT_COMMENT Insert Operation @255-56B36828

    Protected Sub STUDENT_COMMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_COMMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_COMMENT Insert Operation

'Button Button_Insert OnClick. @258-454288B2
        If CType(sender,Control).ID = "STUDENT_COMMENTButton_Insert" Then
            RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @258-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT_COMMENT Event BeforeInsert. Action Custom Code @276-73254650
            ' -------------------------
            ' ERA: check for lbSpecialCommentType - if '0' then no change to hidden_COMMENT_TYPE, else then use lbSpecialCommentType
            ' 	and set ALERT_TYPE to '1'
            ' Also will need to change the Edit own comment page to allow reset/change of comment type from Alert etc to Regular

            ' ERA: 28-Jan-2011|EA| added selection of new drop-down for regular teachers etc, to allow adding of Contact Types.
            '	(unfuddle #356)
            '27-Aug-2015|EA| convert to global setting incase we need to add a new group in future
			dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
			dim arrHigherGroups as String() = strHigherGroups.split(",")
			If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            'If (DBUtility.AuthorizeUser(New String() {"2", "3", "6", "7", "9"})) Then
                ' update the form objects so they will be loaded in the STUDENT_COMMENTLoadItemFromRequest below.
                If (Not String.Equals(STUDENT_COMMENTlbSpecialCommentType.Value, "0")) Then
                    STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType.Value
                End If
            Else
                'regular teachers
                If (Not String.Equals(STUDENT_COMMENTlbSpecialCommentType1.Value, "0")) Then
                    STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType1.Value
                End If
            End If  'end 28-Jan

            '2-3-2011|EA| put in a failsafe that if comment type is not set, then make it 'REGULAR' 
            If (STUDENT_COMMENTHidden_CommentType.Value = "") Then
                STUDENT_COMMENTHidden_CommentType.Value = "REGULAR"
            End If

            ' -------------------------

            'End Record STUDENT_COMMENT Event BeforeInsert. Action Custom Code

'Record Form STUDENT_COMMENT BeforeInsert tail @255-425B34D4
    STUDENT_COMMENTParameters()
    STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
    If STUDENT_COMMENTOperations.AllowInsert Then
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_COMMENTData.InsertItem(item)
            Catch ex As Exception
                STUDENT_COMMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_COMMENT BeforeInsert tail

'DEL                  ' -------------------------
'DEL                  '7-Apr-2011|EA| (unfuddle #386) if there comment type is 'ALERT' or 'RESTRICTED' then email the associated teachers 
'DEL                  Dim alertTypes() As String = {"ALERT", "RESTRICTED", "anothertype"}
'DEL                  If Array.IndexOf(alertTypes, (item.Hidden_CommentType.Value)) <> -1 Then
'DEL                      Dim strTeacherStaffIDList As String = ""
'DEL                      Dim strStudentCommentLink As String = ""
'DEL  
'DEL                      ' get list of Teachers and current user and add to Select
'DEL                      Dim tmpENROLYEAR As String = ""
'DEL                      tmpENROLYEAR = Convert.ToString(Year(Now()))
'DEL  
'DEL                      strTeacherStaffIDList = CType((New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("declare @sCsv2 varchar(1000); set @sCsv2 = '';select @sCsv2 = @sCsv2 + T1.email+',' from (select distinct rtrim(staff_id)+'@distance.vic.edu.au' as email from STUDENT_SUBJECT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & "and staff_id not like 'nsubmit%' and STAFF_ID not in ('N-A','NA')) as T1; select @sCsv2;"))).Value, String)
'DEL                      ' add in Pastoral Care Teacher 
'DEL                      'ERA: 2013-09-18|EA|exclude any non-SST codes like 'N-A' and 'NO_SST' as they are not real (unfuddle #552)
'DEL                      'strTeacherStaffIDList += CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select rtrim(isnull(PASTORAL_CARE_ID,'N-A'))+'@distance.vic.edu.au,' from STUDENT_ENROLMENT where ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & " "))).Value, String)
'DEL                      strTeacherStaffIDList += CType((New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select rtrim(PASTORAL_CARE_ID)+'@distance.vic.edu.au' from STUDENT_ENROLMENT where PASTORAL_CARE_ID is not null AND PASTORAL_CARE_ID not in ('N-A','NA','NO_SST') and ENROLMENT_YEAR = " & tmpENROLYEAR & " and STUDENT_ID = " & item.STUDENT_ID.GetFormattedValue() & " and PASTORAL_CARE_ID not like 'nsubmit%' "))).Value, String)
'DEL  
'DEL                      'DEBUG - Remove after testing
'DEL                      'strTeacherStaffIDList = "'eaffleck@gmail.com','pcsupport@distance.vic.edu.au'"
'DEL                      'strTeacherStaffIDList = "lnigro@yahoo.com,lnigro@distance.vic.edu.au,pcsupport@distance.vic.edu.au"
'DEL  
'DEL  
'DEL                      If (strTeacherStaffIDList.Length() > 5) Then
'DEL                          Dim strMessageBody As String = ""
'DEL                          strMessageBody += "<h2 color='red'>Alert/Restricted Comment Added for Student</h2> <em>" & item.COMMENT.GetFormattedValue() & "</em>"
'DEL                          strMessageBody += "<p>Added by Staff ID: " & DBUtility.UserLogin.ToUpper & "</p>"
'DEL  
'DEL                          'work out the link to the student comment page	
'DEL                          ' get from web.config settings - ServerUrl
'DEL                          strStudentCommentLink = Settings.ServerURL & "Student_Comments_maintain.aspx?STUDENT_ID=" & Server.UrlEncode(item.STUDENT_ID.Value) & "&ENROLMENT_YEAR=" & Server.UrlEncode(tmpENROLYEAR)
'DEL  
'DEL                          strMessageBody += "<p><a href='" & strStudentCommentLink & "'>go to Comments for <b>" & tmpStudentName & "</b></a></p>"
'DEL  
'DEL                          '    Dim message As System.Web.Mail.MailMessage = New System.Web.Mail.MailMessage()
'DEL                          '    message.From = "PCSupport@distance.vic.edu.au"
'DEL                          '	message.To = strTeacherStaffIDList
'DEL                          '	message.Subject = item.hidden_commenttype.value & " Comment Added for Student " & tmpStudentName & " (Student ID: " & item.student_id.value & ")"
'DEL                          '   message.Body = strMessageBody
'DEL                          '   message.BodyFormat = System.Web.Mail.MailFormat.HTML
'DEL                          '	'ERA: 7-May-2012|EA| fix Mail server to use configuration- missed in April Generic changes.
'DEL                          '    'System.Web.Mail.SmtpMail.SmtpServer = "decv-ex1.distance.vic.edu.au"
'DEL                          '	System.Web.Mail.SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings("smtp_servername")
'DEL                          '    System.Web.Mail.SmtpMail.Send(message)
'DEL  						
'DEL                          ' ERA: 31-Oct-2013|LN| Assign From and To from the MailMessage contructor.
'DEL                          Dim config As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
'DEL                          Dim mailSettings As System.Net.Configuration.MailSettingsSectionGroup = CType(config.GetSectionGroup("system.net/mailSettings"), System.Net.Configuration.MailSettingsSectionGroup)
'DEL                          Dim fromString As String = mailSettings.Smtp.From
'DEL  
'DEL                          'ERA: 4-Oct-2013|EA| fix Mail server to use web.config System.Net.Mail configuration.
'DEL                          'Dim message As New System.Net.Mail.MailMessage(fromString, strTeacherStaffIDList)
'DEL                          Dim message As New System.Net.Mail.MailMessage()
'DEL                          
'DEL                          Dim mailaddr As New System.Net.Mail.MailAddress(fromString, fromString)
'DEL  
'DEL  						message.From = mailaddr
'DEL  
'DEL                          Dim recipients as string() = strTeacherStaffIDList.Split(",")
'DEL                          Dim recipient as String
'DEL                          '23-July-2015|EA| fix if no email addressess (unfuddle #721)
'DEL                          If recipients.length > 0 then
'DEL  	                        For Each recipient in recipients
'DEL  	                        	message.To.Add(recipient)
'DEL  	                        Next
'DEL  	                        
'DEL  	                        'Dim recipients As New System.Net.Mail.MailAddressCollection  '(strTeacherStaffIDList)   // Commented by ERA: 31-Oct-2013|LN|
'DEL  	                        'recipients.Add(strTeacherStaffIDList)                                                  // Commented by ERA: 31-Oct-2013|LN|
'DEL  	                        'message.From = "PCSupport@distance.vic.edu.au"	' in web.config
'DEL  	
'DEL  	                        'message.To.Add(recipients)  // Commented by ERA: 31-Oct-2013|LN|
'DEL  	                        message.Subject = item.Hidden_CommentType.Value & " Comment Added for Student " & tmpStudentName & " (Student ID: " & item.STUDENT_ID.Value & ")"
'DEL  	                        message.Body = strMessageBody
'DEL  	                        message.IsBodyHtml = True
'DEL  	                        Dim mailclient As New System.Net.Mail.SmtpClient()
'DEL                          mailclient.Send(message)
'DEL                          End If
'DEL                      End If
'DEL  
'DEL                  End If
'DEL                  ' -------------------------


'Record Form STUDENT_COMMENT AfterInsert tail  @255-A6CFA8F7
        End If
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT AfterInsert tail 

'Record Form STUDENT_COMMENT Update Operation @255-A7C84435

    Protected Sub STUDENT_COMMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_COMMENT Update Operation

'Record Form STUDENT_COMMENT Before Update tail @255-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_COMMENT Before Update tail

'Record Form STUDENT_COMMENT Update Operation tail @255-5A342A24
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT Update Operation tail

'Record Form STUDENT_COMMENT Delete Operation @255-11975DEB
    Protected Sub STUDENT_COMMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_COMMENT Delete Operation

'Record Form BeforeDelete tail @255-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @255-A1B786F7
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_COMMENT Cancel Operation @255-CE7ECF6B

    Protected Sub STUDENT_COMMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_COMMENTLoadItemFromRequest(item, False)
'End Record Form STUDENT_COMMENT Cancel Operation

'Button Button_Cancel OnClick. @259-318107BC
    If CType(sender,Control).ID = "STUDENT_COMMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @259-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_COMMENT Cancel Operation tail @255-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_COMMENT Cancel Operation tail

'Grid Grid_DisplayComments Bind @288-6B7945D8

    Protected Sub Grid_DisplayCommentsBind()
        If Not Grid_DisplayCommentsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_DisplayComments",GetType(Grid_DisplayCommentsDataProvider.SortFields), 30, 100)
        End If
'End Grid Grid_DisplayComments Bind

'Grid Form Grid_DisplayComments BeforeShow tail @288-BA5BFEF1
        Grid_DisplayCommentsParameters()
        Grid_DisplayCommentsData.SortField = CType(ViewState("Grid_DisplayCommentsSortField"),Grid_DisplayCommentsDataProvider.SortFields)
        Grid_DisplayCommentsData.SortDir = CType(ViewState("Grid_DisplayCommentsSortDir"),SortDirections)
        Grid_DisplayCommentsData.PageNumber = CInt(ViewState("Grid_DisplayCommentsPageNumber"))
        Grid_DisplayCommentsData.RecordsPerPage = CInt(ViewState("Grid_DisplayCommentsPageSize"))
        Grid_DisplayCommentsRepeater.DataSource = Grid_DisplayCommentsData.GetResultSet(PagesCount, Grid_DisplayCommentsOperations)
        ViewState("Grid_DisplayCommentsPagesCount") = PagesCount
        Dim item As Grid_DisplayCommentsItem = New Grid_DisplayCommentsItem()
        Grid_DisplayCommentsRepeater.DataBind
        FooterIndex = Grid_DisplayCommentsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_DisplayCommentsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Navigator1Navigator As DECV_PROD2007.Controls.Navigator = DirectCast(Grid_DisplayCommentsRepeater.Controls(FooterIndex).FindControl("Navigator1Navigator"),DECV_PROD2007.Controls.Navigator)
        Navigator1Navigator.PageSizes = new Integer() {10,30,100,500}
        If PagesCount < 2 Then Navigator1Navigator.Visible = False

'End Grid Form Grid_DisplayComments BeforeShow tail

'Grid Grid_DisplayComments Bind tail @288-E31F8E2A
    End Sub
'End Grid Grid_DisplayComments Bind tail

'Grid Grid_DisplayComments Table Parameters @288-D58083C3

    Protected Sub Grid_DisplayCommentsParameters()
        Try
            Grid_DisplayCommentsData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=Grid_DisplayCommentsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_DisplayCommentsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_DisplayComments: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_DisplayComments Table Parameters

'Grid Grid_DisplayComments ItemDataBound event @288-F373FC94

    Protected Sub Grid_DisplayCommentsItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_DisplayCommentsItem = CType(e.Item.DataItem,Grid_DisplayCommentsItem)
        Dim Item as Grid_DisplayCommentsItem = DataItem
        Dim FormDataSource As Grid_DisplayCommentsItem() = CType(Grid_DisplayCommentsRepeater.DataSource, Grid_DisplayCommentsItem())
        Dim Grid_DisplayCommentsDataRows As Integer = FormDataSource.Length
        Dim Grid_DisplayCommentsIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_DisplayCommentsCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_DisplayCommentsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_DisplayCommentsCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_DisplayCommentsCOMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsCOMMENT"),System.Web.UI.WebControls.Literal)
            Dim Grid_DisplayCommentsLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim Grid_DisplayCommentsLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim Grid_DisplayCommentsCOMMENT_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_DisplayCommentsCOMMENT_TYPE"),System.Web.UI.WebControls.Literal)
            Dim Grid_DisplayCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayCommentslink_editcomment"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.link_editcommentHref = "Student_Comments_editown.aspx"
            Grid_DisplayCommentslink_editcomment.HRef = DataItem.link_editcommentHref & DataItem.link_editcommentHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid Grid_DisplayComments ItemDataBound event

'Grid Grid_DisplayComments BeforeShowRow event @288-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid_DisplayComments BeforeShowRow event

'Grid Grid_DisplayComments Event BeforeShowRow. Action Custom Code @295-73254650
                ' -------------------------
                'ERA: change colour of row depending on comment type

                Dim comment_row As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("displaycomments_row"), System.Web.UI.HtmlControls.HtmlTableRow)

                If (DataItem.COMMENT_TYPE.Value = "REGULAR") Then
                    comment_row.Attributes("Class") = "Row"

                ElseIf (DataItem.COMMENT_TYPE.Value = "PASTORAL") Then
                    comment_row.Attributes("Class") = "AltRow"
                    'ERA: 13-Aug-2010|EA new *page based* styles for highlighting special comments
                ElseIf (DataItem.COMMENT_TYPE.Value = "ALERT") Then
                    comment_row.Attributes("Class") = "AlertRed"

                ElseIf (DataItem.COMMENT_TYPE.Value = "RESTRICTED") Then
                    comment_row.Attributes("Class") = "AlertRed"

                ElseIf (DataItem.COMMENT_TYPE.Value = "WELLBEING") Then
                    comment_row.Attributes("Class") = "AlertGreen"

                ElseIf (DataItem.COMMENT_TYPE.Value = "COORD_DECISION") Then
                    '10-Aug-2012|EA| added for Coordinator Decisions
                    comment_row.Attributes("Class") = "CoordAmber"

                ElseIf (DataItem.COMMENT_TYPE.Value = "MODIFIED_SUBJECT") Then
                    '14-Feb-2013|EA| added for Modified Subject
                    comment_row.Attributes("Class") = "CoordAmber"

                ElseIf (DataItem.COMMENT_TYPE.Value = "ENROLMENT") Then
                    '31-Oct-2013|LN| added for Enrolment
                    comment_row.Attributes("Class") = "LightMauve"
                    
                ElseIf (DataItem.COMMENT_TYPE.Value = "PATHWAYS") Then
                    '14-May-2014|EA| added for Pathways Decision (unfuddle #638)
                    comment_row.Attributes("Class") = "Pathways"
                    
                Else
                    comment_row.Attributes("Class") = "Row"
                End If

                'ERA: Aug 2009 - and display the 'edit' link only if the current user is the LAST_ALTERED_BY field
                Dim Grid_DisplayCommentslink_editcomment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_DisplayCommentslink_editcomment"), System.Web.UI.HtmlControls.HtmlAnchor)

                If (DataItem.LAST_ALTERED_BY.Value.ToUpper() = DBUtility.UserId.ToString.ToUpper()) Then
                    Grid_DisplayCommentslink_editcomment.Visible = True
                Else
                    Grid_DisplayCommentslink_editcomment.Visible = False
                End If

                '11-Feb-2013|EA| display 'edit' on Public comments if user is in special groups (ADMINISTRATORS:3; ENROLMENT OFFICERS:6; SYSTEM:9)
                ' But not overriding next exclusion for certain possibleTypes (as might want certain types locked)
                If (DBUtility.AuthorizeUser(New String() {"3", "6", "9"})) Then
                    Grid_DisplayCommentslink_editcomment.Visible = True
                End If

                '19-Feb-2010|EA| additional turn off Edit for general Comment Types - add more as needed
                Dim asPossibleTypes() As String = {"PROFILE", "anothertype"}
                If Array.IndexOf(asPossibleTypes, (DataItem.COMMENT_TYPE.Value.toupper())) <> -1 Then
                    Grid_DisplayCommentslink_editcomment.Visible = False
                End If

                ' -------------------------
                'End Grid Grid_DisplayComments Event BeforeShowRow. Action Custom Code

'Grid Grid_DisplayComments BeforeShowRow event tail @288-477CF3C9
        End If
'End Grid Grid_DisplayComments BeforeShowRow event tail

'Grid Grid_DisplayComments ItemDataBound event tail @288-BFD38A06
        If Grid_DisplayCommentsIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_DisplayCommentsCurrentRowNumber, ListItemType.Item)
            Grid_DisplayCommentsRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_DisplayCommentsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_DisplayComments ItemDataBound event tail

'Grid Grid_DisplayComments ItemCommand event @288-9F92F65C

    Protected Sub Grid_DisplayCommentsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_DisplayCommentsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_DisplayCommentsSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_DisplayCommentsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_DisplayCommentsSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_DisplayCommentsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_DisplayCommentsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_DisplayCommentsDataProvider.SortFields = 0
            ViewState("Grid_DisplayCommentsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_DisplayCommentsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_DisplayCommentsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_DisplayCommentsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_DisplayCommentsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_DisplayCommentsBind
        End If
    End Sub
'End Grid Grid_DisplayComments ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A7978CFD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FutureEnrol_StudentMaintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, True, True, False)
        STUDENT_ENROLMENTData = New STUDENT_ENROLMENTDataProvider()
        STUDENT_ENROLMENTOperations = New FormSupportedOperations(False, True, True, True, False)
        EditableGrid1Data = New EditableGrid1DataProvider()
        EditableGrid1Operations = New FormSupportedOperations(False, True, False, True, True)
        STUDENT_COMMENTData = New STUDENT_COMMENTDataProvider()
        STUDENT_COMMENTOperations = New FormSupportedOperations(False, False, True, False, False)
        Grid_DisplayCommentsData = New Grid_DisplayCommentsDataProvider()
        Grid_DisplayCommentsOperations = New FormSupportedOperations(False, True, False, False, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","6","9","11"})) Then
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

