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

Namespace DECV_PROD2007.StudentDetails_maintain 'Namespace @1-65C4BA7C

'Forms Definition @1-14240FAA
Public Class [StudentDetails_maintainPage]
Inherits CCPage
'End Forms Definition

'ERA: for running stored procs
	Public ExprKey122 As IntegerParameter
    Public UrlSTUDENT_ID As IntegerParameter
	'7-Feb-2010|EricA|created for Student Files setup - 
	public strLocURL as String			'for URL link in common URL format
	public strLocCreate as String		' local address on DECV-DB1 server for Create

'Forms Objects @1-12873692
    Protected STUDENTData As STUDENTDataProvider
    Protected STUDENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTOperations As FormSupportedOperations
    Protected STUDENTIsSubmitted As Boolean = False
    Protected STUDENTDatePicker_BIRTH_DATEName As String
    Protected STUDENTDatePicker_BIRTH_DATEDateControl As String
    Protected StudentDetails_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page StudentDetails_maintain Event OnInitializeView. Action Custom Code @192-73254650
    ' -------------------------
   	'7-Feb-2010|EricA|created for Student Files setup - 
	'''strLocURL = "file:////decv-db1/Student_Admin_Student_data$/"	'for URL link in common URL format
	'''strLocCreate = "g:\Student_Admin_Student_data\"				' local address on DECV-DB1 server for Create
	
	'4-Dec-2014|EA| convert the locations to web.config values as several pages (Summary and StudentDetails_maintain) and have been getting out of sync (unfuddle #683)
	strLocURL = System.Configuration.ConfigurationManager.AppSettings("StudentFolderLocalURL") 'for URL link in common URL format
    strLocCreate = System.Configuration.ConfigurationManager.AppSettings("StudentFolderLocalCreatePath")             ' local address on DECV-DB server for Create
	
    ' -------------------------
'End Page StudentDetails_maintain Event OnInitializeView. Action Custom Code
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

'Record Form STUDENT Parameters @2-C5FE451F

    Protected Sub STUDENTParameters()
        Dim item As new STUDENTItem
        Try
            STUDENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT Parameters

'Record Form STUDENT Show method @2-7E32435A
    Protected Sub STUDENTShow()
        If STUDENTOperations.None Then
            STUDENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENTItem = STUDENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENTOperations.AllowRead
        item.link_showstudentfolderHref = ""
        STUDENTErrors.Add(item.errors)
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
            Return
        End If
'End Record Form STUDENT Show method

'Record Form STUDENT BeforeShow tail @2-E258E3DE
        STUDENTParameters()
        STUDENTData.FillItem(item, IsInsertMode)
        STUDENTHolder.DataBind()
        CType(Page,CCPage).ControlAttributes.Add(STUDENTSEX_SELF_DESCRIBED,New CCSControlAttribute("placeholder", FieldType._Text, ("Specify, if self-described")))
        CType(Page,CCPage).ControlAttributes.Add(STUDENTPRONOUN_OTHER,New CCSControlAttribute("placeholder", FieldType._Text, ("Specify, if other")))
        STUDENTButton_Insert.Visible=IsInsertMode AndAlso STUDENTOperations.AllowInsert
        STUDENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
        STUDENTButton_CreateStudentWorkFolder.Visible=Not (IsInsertMode) AndAlso STUDENTOperations.AllowUpdate
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
        STUDENTlink_showstudentfolder.InnerText += item.link_showstudentfolder.GetFormattedValue().Replace(vbCrLf,"")
        STUDENTlink_showstudentfolder.HRef = Settings.ServerURL +item.link_showstudentfolderHref+item.link_showstudentfolderHrefParameters.ToString("None","", ViewState)
        STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value = item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()
        STUDENTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENThidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENTlabelContactPCSupport.Text = item.labelContactPCSupport.GetFormattedValue()
        STUDENThidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        STUDENTlabel_StudentFilesCreated.Text = Server.HtmlEncode(item.label_StudentFilesCreated.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENTlist_REGION.Items.Add(new ListItem("Select Value",""))
        STUDENTlist_REGION.Items(0).Selected = True
        item.list_REGIONItems.SetSelection(item.list_REGION.GetFormattedValue())
        If Not item.list_REGIONItems.GetSelectedItem() Is Nothing Then
            STUDENTlist_REGION.SelectedIndex = -1
        End If
        item.list_REGIONItems.CopyTo(STUDENTlist_REGION.Items)
        STUDENTVCE_CANDIDATE_NUMBER.Text=item.VCE_CANDIDATE_NUMBER.GetFormattedValue()
        STUDENTSTUDENT_EMAIL.Text=item.STUDENT_EMAIL.GetFormattedValue()
        STUDENTSTUDENT_MOBILE.Text=item.STUDENT_MOBILE.GetFormattedValue()
        STUDENTHidden_CURR_RESID_ADDRESS_ID.Value = item.Hidden_CURR_RESID_ADDRESS_ID.GetFormattedValue()
        If item.cbPORTAL_ACCESSCheckedValue.Value.Equals(item.cbPORTAL_ACCESS.Value) Then
            STUDENTcbPORTAL_ACCESS.Checked = True
        End If
        STUDENTlistORG_SCHOOL_ID.Items.Add(new ListItem("Select Value",""))
        STUDENTlistORG_SCHOOL_ID.Items.Add(new ListItem("- none -","0"))
        STUDENTlistORG_SCHOOL_ID.Items(1).Selected = True
        item.listORG_SCHOOL_IDItems.SetSelection(item.listORG_SCHOOL_ID.GetFormattedValue())
        If Not item.listORG_SCHOOL_IDItems.GetSelectedItem() Is Nothing Then
            STUDENTlistORG_SCHOOL_ID.SelectedIndex = -1
        End If
        item.listORG_SCHOOL_IDItems.CopyTo(STUDENTlistORG_SCHOOL_ID.Items)
        STUDENTSEX_SELF_DESCRIBED.Text=item.SEX_SELF_DESCRIBED.GetFormattedValue()
        item.SEX_BIRTHItems.SetSelection(item.SEX_BIRTH.GetFormattedValue())
        STUDENTSEX_BIRTH.SelectedIndex = -1
        item.SEX_BIRTHItems.CopyTo(STUDENTSEX_BIRTH.Items)
        STUDENTPRONOUN_OTHER.Text=item.PRONOUN_OTHER.GetFormattedValue()
        STUDENTlist_Pronoun.Items.Add(new ListItem("Select Value",""))
        STUDENTlist_Pronoun.Items(0).Selected = True
        item.list_PronounItems.SetSelection(item.list_Pronoun.GetFormattedValue())
        If Not item.list_PronounItems.GetSelectedItem() Is Nothing Then
            STUDENTlist_Pronoun.SelectedIndex = -1
        End If
        item.list_PronounItems.CopyTo(STUDENTlist_Pronoun.Items)
'End Record Form STUDENT BeforeShow tail

'TextBox SURNAME Event BeforeShow. Action Custom Code @82-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| trim the Surname 
	STUDENTSURNAME.Text=RTrim(item.SURNAME.GetFormattedValue())
    ' -------------------------
'End TextBox SURNAME Event BeforeShow. Action Custom Code

'TextBox FIRST_NAME Event BeforeShow. Action Custom Code @83-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| trim the Firstname 
    STUDENTFIRST_NAME.Text=RTrim(item.FIRST_NAME.GetFormattedValue())
    ' -------------------------
'End TextBox FIRST_NAME Event BeforeShow. Action Custom Code

'TextBox MIDDLE_NAME Event BeforeShow. Action Custom Code @84-73254650
    ' -------------------------
	'ERA: 4-Apr-2011|EA| trim the VCE Candidate number 
    STUDENTVCE_CANDIDATE_NUMBER.Text=RTrim(item.VCE_CANDIDATE_NUMBER.GetFormattedValue())
    ' -------------------------
'End TextBox MIDDLE_NAME Event BeforeShow. Action Custom Code

'Hidden hidden_old_ATTENDING_SCHOOL_ID Event BeforeShow. Action Retrieve Value for Control @67-C95A8300
            STUDENThidden_old_ATTENDING_SCHOOL_ID.Value = (New FloatField("#0.00", (item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Hidden hidden_old_ATTENDING_SCHOOL_ID Event BeforeShow. Action Retrieve Value for Control

'Link link_showstudentfolder Event BeforeShow. Action Declare Variable @115-C272DBC2
            Dim tmpStudentID As String = "0unknown"
'End Link link_showstudentfolder Event BeforeShow. Action Declare Variable

'Link link_showstudentfolder Event BeforeShow. Action Save Control Value @117-D43BF6F3
            tmpStudentID=STUDENTlblStudentID.Text
'End Link link_showstudentfolder Event BeforeShow. Action Save Control Value

'Link link_showstudentfolder Event BeforeShow. Action Custom Code @121-73254650
    ' -------------------------
    'ERA: 5-Feb-2010 set the link with out the strange extra bits
	dim tmpHrefURL as string = strLocURL & tmpStudentID
	STUDENTlink_showstudentfolder.HRef = tmpHrefURL.tostring()
    ' -------------------------
'End Link link_showstudentfolder Event BeforeShow. Action Custom Code

'TextBox VCE_CANDIDATE_NUMBER Event BeforeShow. Action Custom Code @198-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| trim the Surname 
	'STUDENTSURNAME.Text=RTrim(item.SURNAME.GetFormattedValue())
    ' -------------------------
'End TextBox VCE_CANDIDATE_NUMBER Event BeforeShow. Action Custom Code

'TextBox STUDENT_EMAIL Event BeforeShow. Action Custom Code @212-73254650
    ' -------------------------
    'ERA: 8-May-2014|EA| trim the Email address as well, unfuddle #619
	STUDENTSTUDENT_EMAIL.Text=RTrim(item.STUDENT_EMAIL.GetFormattedValue())
    ' -------------------------
'End TextBox STUDENT_EMAIL Event BeforeShow. Action Custom Code


'Record STUDENT Event BeforeShow. Action DLookup @41-6738A58A
            STUDENTlblAttendingSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action DLookup @42-32AD3C4D
            STUDENTlblHomeSchoolName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.HOME_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action DLookup @56-C010A0E7
            STUDENTEnrolmentCategoryTemp.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SUBCATEGORY_FULL_TITLE)" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "CATEGORY_CODE='" & item.CATEGORY_CODE.GetFormattedValue() & "' AND SUBCATEGORY_CODE='" & item.SUBCATEGORY_CODE.GetFormattedValue() & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeShow. Action DLookup

'Record STUDENT Event BeforeShow. Action Custom Code @63-73254650
    ' -------------------------
    'ERA: change listbox to match Full Title from Enrolment_Categories, which is temporarily stored in the EnrolmentCategoryTemp field
	'	for just this purpose
	STUDENTListBox_SubCategory.Value = STUDENTEnrolmentCategoryTemp.Value
    ' -------------------------
'End Record STUDENT Event BeforeShow. Action Custom Code

'Record STUDENT Event BeforeShow. Action Custom Code @120-73254650
    ' -------------------------
    'ERA: 5-Feb-2010|EA| extend normal show-hide code into a larger check for existance of actual folder, and set all the Visible in a single IF
		STUDENTlabelContactPCSupport.visible = false	' usually not to be shown unless problems, below
		dim tmpHrefCheck as string = strLocCreate & tmpStudentID

		' if there is no Date created then never done and so should be created
		if (item.hidden_DATE_STUDENTFOLDER_CREATED.GetFormattedValue()<>"") then 
		    STUDENTButton_CreateStudentWorkFolder.visible = false
			' so likely that folder exists, so double check
			if (System.IO.Directory.Exists(tmpHrefCheck)) then
				STUDENTlink_showstudentfolder.visible = true
			else
				STUDENTlink_showstudentfolder.visible = false	'debug, should be false
				STUDENTlabelContactPCSupport.visible = true
			end if
        End If

    ' -------------------------
'End Record STUDENT Event BeforeShow. Action Custom Code

'Record Form STUDENT Show method tail @2-F9DBAD9A
        If STUDENTErrors.Count > 0 Then
            STUDENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT Show method tail

'Record Form STUDENT LoadItemFromRequest method @2-C2AB4D1A

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
        item.list_REGION.IsEmpty = IsNothing(Request.Form(STUDENTlist_REGION.UniqueID))
        item.list_REGION.SetValue(STUDENTlist_REGION.Value)
        item.list_REGIONItems.CopyFrom(STUDENTlist_REGION.Items)
        item.VCE_CANDIDATE_NUMBER.IsEmpty = IsNothing(Request.Form(STUDENTVCE_CANDIDATE_NUMBER.UniqueID))
        If ControlCustomValues("STUDENTVCE_CANDIDATE_NUMBER") Is Nothing Then
            item.VCE_CANDIDATE_NUMBER.SetValue(STUDENTVCE_CANDIDATE_NUMBER.Text)
        Else
            item.VCE_CANDIDATE_NUMBER.SetValue(ControlCustomValues("STUDENTVCE_CANDIDATE_NUMBER"))
        End If
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
        If STUDENTcbPORTAL_ACCESS.Checked Then
            item.cbPORTAL_ACCESS.Value = (item.cbPORTAL_ACCESSCheckedValue.Value)
        Else
            item.cbPORTAL_ACCESS.Value = (item.cbPORTAL_ACCESSUncheckedValue.Value)
        End If
        item.listORG_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENTlistORG_SCHOOL_ID.UniqueID))
        item.listORG_SCHOOL_ID.SetValue(STUDENTlistORG_SCHOOL_ID.Value)
        item.listORG_SCHOOL_IDItems.CopyFrom(STUDENTlistORG_SCHOOL_ID.Items)
        item.SEX_SELF_DESCRIBED.IsEmpty = IsNothing(Request.Form(STUDENTSEX_SELF_DESCRIBED.UniqueID))
        If ControlCustomValues("STUDENTSEX_SELF_DESCRIBED") Is Nothing Then
            item.SEX_SELF_DESCRIBED.SetValue(STUDENTSEX_SELF_DESCRIBED.Text)
        Else
            item.SEX_SELF_DESCRIBED.SetValue(ControlCustomValues("STUDENTSEX_SELF_DESCRIBED"))
        End If
        item.SEX_BIRTH.IsEmpty = IsNothing(Request.Form(STUDENTSEX_BIRTH.UniqueID))
        If Not IsNothing(STUDENTSEX_BIRTH.SelectedItem) Then
            item.SEX_BIRTH.SetValue(STUDENTSEX_BIRTH.SelectedItem.Value)
        Else
            item.SEX_BIRTH.Value = Nothing
        End If
        item.SEX_BIRTHItems.CopyFrom(STUDENTSEX_BIRTH.Items)
        item.PRONOUN_OTHER.IsEmpty = IsNothing(Request.Form(STUDENTPRONOUN_OTHER.UniqueID))
        If ControlCustomValues("STUDENTPRONOUN_OTHER") Is Nothing Then
            item.PRONOUN_OTHER.SetValue(STUDENTPRONOUN_OTHER.Text)
        Else
            item.PRONOUN_OTHER.SetValue(ControlCustomValues("STUDENTPRONOUN_OTHER"))
        End If
        item.list_Pronoun.IsEmpty = IsNothing(Request.Form(STUDENTlist_Pronoun.UniqueID))
        item.list_Pronoun.SetValue(STUDENTlist_Pronoun.Value)
        item.list_PronounItems.CopyFrom(STUDENTlist_Pronoun.Items)
        If EnableValidation Then
            item.Validate(STUDENTData)
        End If
        STUDENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT LoadItemFromRequest method

'Record Form STUDENT GetRedirectUrl method @2-55CA8389

    Protected Function GetSTUDENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
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

'Button Button_Insert OnClick. @3-045BFD4E
        If CType(sender,Control).ID = "STUDENTButton_Insert" Then
            RedirectUrl = GetSTUDENTRedirectUrl("StudentSummary.aspx", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT Event BeforeInsert. Action DLookup @59-80D9E180
        STUDENTCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeInsert. Action DLookup

'Record STUDENT Event BeforeInsert. Action DLookup @60-86753990
        STUDENTSUBCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
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

'Button Button_Update OnClick. @4-462C9EFA
        If CType(sender,Control).ID = "STUDENTButton_Update" Then
            RedirectUrl = GetSTUDENTRedirectUrl("StudentSummary.aspx", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Button Button_CreateStudentWorkFolder OnClick. @171-AB8CA8D9
        If CType(sender,Control).ID = "STUDENTButton_CreateStudentWorkFolder" Then
            RedirectUrl = GetSTUDENTRedirectUrl("StudentDetails_maintain.aspx", "")
            EnableValidation  = True
'End Button Button_CreateStudentWorkFolder OnClick.

'Button Button_CreateStudentWorkFolder Event OnClick. Action Declare Variable @187-C29D4D97
        Dim tmpSTUDENT_ID As String = "0unknown"
'End Button Button_CreateStudentWorkFolder Event OnClick. Action Declare Variable

'Button Button_CreateStudentWorkFolder Event OnClick. Action Retrieve Value for Variable @186-35B1CF2E
        tmpSTUDENT_ID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Button Button_CreateStudentWorkFolder Event OnClick. Action Retrieve Value for Variable

'Button Button_CreateStudentWorkFolder Event OnClick. Action Custom Code @185-73254650
    ' -------------------------
	    'ERA: get the URL student Id and create the student folder
		' per code from Vikas
		' strLocCreate is public for page
		Try
			if (Directory.Exists(strLocCreate & tmpSTUDENT_ID)) then 
			else
		    	Directory.CreateDirectory(strLocCreate & tmpSTUDENT_ID)
				'STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value = (New DateField(Settings.DateFormat, (now()))).GetFormattedValue()
			end if

		Catch ex As Exception
	    	Response.Write("Erics Nice Error Catch:" & ex.Message.ToString())
		Finally
	    End Try
    ' -------------------------
'End Button Button_CreateStudentWorkFolder Event OnClick. Action Custom Code



'Button Button_CreateStudentWorkFolder Event OnClick. Action Retrieve Value for Control @191-C941E4C2
        STUDENThidden_DATE_STUDENTFOLDER_CREATED.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Button Button_CreateStudentWorkFolder Event OnClick. Action Retrieve Value for Control

'Button Button_CreateStudentWorkFolder OnClick tail. @171-477CF3C9
        End If
'End Button Button_CreateStudentWorkFolder OnClick tail.

'Record STUDENT Event BeforeUpdate. Action Custom Code @193-73254650
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

'Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control @99-DD295D03
        STUDENThidden_LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control @100-301CF505
        STUDENThidden_LAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT Event BeforeUpdate. Action DLookup @57-80D9E180
        STUDENTCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "CATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
'End Record STUDENT Event BeforeUpdate. Action DLookup

'Record STUDENT Event BeforeUpdate. Action DLookup @58-86753990
        STUDENTSUBCATEGORY_CODE.Value = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBCATEGORY_CODE" & " FROM " & "ENROLMENT_CATEGORY" & " WHERE " & "SUBCATEGORY_FULL_TITLE='" & STUDENTListBox_SubCategory.Value & "'"))).GetFormattedValue()
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

'Record STUDENT Event AfterUpdate. Action Custom Code @66-73254650
' -------------------------
				' ERA: Aug 2008|EA| if the Attending school ID has changed during this update, 
                '	change the destination and add a flag to the querystring (flagattendingschool)
                '	for RedirectUrl to throw user to Address screen to update Address
                If (Not (item.hidden_old_ATTENDING_SCHOOL_ID.IsEmpty)) And (Not ErrorFlag) Then
                    'check if not same
                    If (item.hidden_old_ATTENDING_SCHOOL_ID.Value <> item.ATTENDING_SCHOOL_ID.Value) Then
                        'RedirectUrl=GetSTUDENTRedirectUrl("Student_Address_maintain.aspx", "flagattendingschool")
                        Dim params As New LinkParameterCollection()
                        Dim p2 As String '= params.ToString("GET", "flagattendingschool", ViewState)

                        params.Add("flagattendingschool", "1")
                        p2 = params.ToString("GET", "flagattendingschool")
                        If p2 = "" Then p2 = "?"
                        p2 = p2.Replace("&amp;", "&")
                        'RedirectUrl = "Student_Address_maintain.aspx" + p2
						'code updated by Vikas
						RedirectUrl = "Student_Address_Panels_maintain.aspx" + p2

                        ' TODO: changes needed to change postal address id - if attending school changed then
                        ' change ADDRESSID to the Attending sChool's Address ID, if moving TO DECV then 
                        ' clear the student's postal_address_id to force a new record

                        '[spu_UpdateStudentAttendingSchoolAddress] 
                        Dim UpdateAttendingSchoolAddress = New SpCommand("spu_UpdateStudentAttendingSchoolAddress;1", Settings.connDECVPRODSQL2005DataAccessObject)
                        UpdateAttendingSchoolAddress.Parameters.Clear()
                        CType(UpdateAttendingSchoolAddress, SpCommand).AddParameter("@RETURN_VALUE", ExprKey122, ParameterType._Int, ParameterDirection.ReturnValue, 0, 0, 10)
                        CType(UpdateAttendingSchoolAddress, SpCommand).AddParameter("@STUDENT_ID", STUDENTData.UrlSTUDENT_ID, ParameterType._Int, ParameterDirection.Input, 0, 0, 10)
                        CType(UpdateAttendingSchoolAddress, SpCommand).AddParameter("@ATTENDING_SCHOOL_ID", item.ATTENDING_SCHOOL_ID, ParameterType._Int, ParameterDirection.Input, 0, 0, 10)
                        CType(UpdateAttendingSchoolAddress, SpCommand).AddParameter("@LAST_ALTERED_BY", DBUtility.UserId, ParameterType._Char, ParameterDirection.Input, 8, 0, 10)

                        Dim resultUASA As Object = 0

                        Try
                            resultUASA = UpdateAttendingSchoolAddress.Execute()
                            ExprKey122 = IntegerParameter.GetParam(CType(UpdateAttendingSchoolAddress.Parameters("@RETURN_VALUE"), IDataParameter).Value, CObj(0))

                        Catch ex As Exception
                            STUDENTErrors.Add("DataProvider", ex.Message)
                            ErrorFlag = True
                        End Try
                    End If
                End If

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

'OnInit Event Body @1-E3621E38
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentDetails_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENTData = New STUDENTDataProvider()
        STUDENTOperations = New FormSupportedOperations(False, True, True, True, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
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

