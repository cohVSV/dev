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

Namespace DECV_PROD2007.Student_Profile_PLSP 'Namespace @1-48F539BB

'Forms Definition @1-B392F93C
Public Class [Student_Profile_PLSPPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-BCCB3807
    Protected STUDENT_PROFILE1Data As STUDENT_PROFILE1DataProvider
    Protected STUDENT_PROFILE1Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_PROFILE1Operations As FormSupportedOperations
    Protected STUDENT_PROFILE1IsSubmitted As Boolean = False
    Protected Student_Profile_PLSPContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-BF79242D
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            STUDENT_PROFILE1Show()
    End If
'End Page_Load Event BeforeIsPostBack

'DEL      ' -------------------------
'DEL      '29-Jan-2017|EA|ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
'DEL      'convert to global setting incase we need to add a new group in future
'DEL  	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
'DEL  	dim arrHigherGroups as String() = strHigherGroups.split(",")
'DEL  	If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
'DEL  	    Panel_MenuStudentMaintain.visible = true
'DEL  	End If
'DEL      ' -------------------------

'Page Student_Profile_PLSP Event BeforeShow. Action Custom Code @123-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Page Student_Profile_PLSP Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_PROFILE1 Parameters @3-75A9012D

    Protected Sub STUDENT_PROFILE1Parameters()
        Dim item As new STUDENT_PROFILE1Item
        Try
            STUDENT_PROFILE1Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_PROFILE1Data.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_PROFILE1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_PROFILE1 Parameters

'Record Form STUDENT_PROFILE1 Show method @3-946850F5
    Protected Sub STUDENT_PROFILE1Show()
        If STUDENT_PROFILE1Operations.None Then
            STUDENT_PROFILE1Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_PROFILE1Item = STUDENT_PROFILE1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_PROFILE1Operations.AllowRead
        STUDENT_PROFILE1Errors.Add(item.errors)
        If STUDENT_PROFILE1Errors.Count > 0 Then
            STUDENT_PROFILE1ShowErrors()
            Return
        End If
'End Record Form STUDENT_PROFILE1 Show method

'Record Form STUDENT_PROFILE1 BeforeShow tail @3-D380A6B9
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1Data.FillItem(item, IsInsertMode)
        STUDENT_PROFILE1Holder.DataBind()
        STUDENT_PROFILE1Button_Insert.Visible=IsInsertMode AndAlso STUDENT_PROFILE1Operations.AllowInsert
        STUDENT_PROFILE1Button_Insert2.Visible=IsInsertMode AndAlso STUDENT_PROFILE1Operations.AllowInsert
        STUDENT_PROFILE1Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_PROFILE1Operations.AllowUpdate
        STUDENT_PROFILE1Button_Update2.Visible=Not (IsInsertMode) AndAlso STUDENT_PROFILE1Operations.AllowUpdate
        STUDENT_PROFILE1STUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_PROFILE1ENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        STUDENT_PROFILE1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.LAUNCH_PAD_DONEItems.SetSelection(item.LAUNCH_PAD_DONE.GetFormattedValue())
        STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedIndex = -1
        item.LAUNCH_PAD_DONEItems.CopyTo(STUDENT_PROFILE1LAUNCH_PAD_DONE.Items, True)
        STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.Text=item.LAUNCH_PAD_DONE_DATE.GetFormattedValue()
        STUDENT_PROFILE1LEARNING_PROGRAM.Value = item.LEARNING_PROGRAM.GetFormattedValue()
        STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.Text=item.LEARNING_PROGRAM_DETAILS.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("LEARNING_PROGRAM_CONSULT")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("LEARNING_PROGRAM_CONSULT").GetUpperBound(0)
                item.LEARNING_PROGRAM_CONSULTItems.SetSelection(Request.QueryString.GetValues("LEARNING_PROGRAM_CONSULT")(i))
            Next i
        End If
        item.LEARNING_PROGRAM_CONSULTItems.SetSelection(item.LEARNING_PROGRAM_CONSULT.Value)
        STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedIndex = -1
        item.LEARNING_PROGRAM_CONSULTItems.CopyTo(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
        item.SPECIAL_PROVISION_FLAGItems.SetSelection(item.SPECIAL_PROVISION_FLAG.GetFormattedValue())
        STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedIndex = -1
        item.SPECIAL_PROVISION_FLAGItems.CopyTo(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.Items, True)
        STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.Text=item.SPECIAL_PROVISION_DETAILS.GetFormattedValue()
        STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.Text=item.REVIEW_PROGRESS_END_SEM1.GetFormattedValue()
        STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.Text=item.REVIEW_PROGRESS_END_SEM2.GetFormattedValue()
        STUDENT_PROFILE1lblLearningProgram.Text = item.lblLearningProgram.GetFormattedValue()
        STUDENT_PROFILE1lblStudentID.Text = item.lblStudentID.GetFormattedValue()
        STUDENT_PROFILE1lblEnrolYear.Text = Server.HtmlEncode(item.lblEnrolYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_BY1.Text = Server.HtmlEncode(item.LAST_ALTERED_BY1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1LAST_ALTERED_DATE1.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_PROFILE1hidden_LastUpdatedBy.Value = item.hidden_LastUpdatedBy.GetFormattedValue()
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = item.hidden_LastUpdatedWhen.GetFormattedValue()
        STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = item.Hidden_LEARNING_PROGRAM_CONSULT.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_ENGLANG_LP.Text=item.ASSESS_ENGLANG_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_ENGLANG_RL.Text=item.ASSESS_ENGLANG_RL.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_MATH_LP.Text=item.ASSESS_MATH_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_MATH_RL.Text=item.ASSESS_MATH_RL.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.Text=item.ASSESS_PATSCIENCE_LP.GetFormattedValue()
        STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.Text=item.ASSESS_PATSCIENCE_RL.GetFormattedValue()
        STUDENT_PROFILE1error_AssessData.Text = item.error_AssessData.GetFormattedValue()
        STUDENT_PROFILE1error_LearnDetails.Text = item.error_LearnDetails.GetFormattedValue()
        STUDENT_PROFILE1error_LearnGoals.Text = item.error_LearnGoals.GetFormattedValue()
        STUDENT_PROFILE1error_SpecialProvision.Text = item.error_SpecialProvision.GetFormattedValue()
        STUDENT_PROFILE1error_ProgressSem1.Text = item.error_ProgressSem1.GetFormattedValue()
        STUDENT_PROFILE1error_ProgressSem2.Text = item.error_ProgressSem2.GetFormattedValue()
        If item.cbENROL_FILE_CHECKEDCheckedValue.Value.Equals(item.cbENROL_FILE_CHECKED.Value) Then
            STUDENT_PROFILE1cbENROL_FILE_CHECKED.Checked = True
        End If
        STUDENT_PROFILE1error_LPDone.Text = item.error_LPDone.GetFormattedValue()
'End Record Form STUDENT_PROFILE1 BeforeShow tail

'DEL      ' -------------------------
'DEL      'change layout 
'DEL  	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatColumns = 1
'DEL  	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatDirection = RepeatDirection.Vertical
'DEL  	'STUDENT_PROFILE1COMM_CONTACT_TYPE.RepeatLayout = RepeatLayout.Flow
'DEL  	
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL       '22-Mar-2018|EA| tick the Contact Types
'DEL  
'DEL  	if (item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0" and item.Hidden_COMM_CONTACT_TYPE_MULTI.Value <> "0,") then
'DEL  
'DEL  		Dim checkItemsDis2 As String() = item.Hidden_COMM_CONTACT_TYPE_MULTI.Value.Split(New Char() {","c})
'DEL  	'	' loop through checkboxitems and compare against the array
'DEL  		Dim thisItemDis2 As String = ""
'DEL  		For Each thisItemDis2 In checkItemsDis2
'DEL  			' set that item as checked
'DEL  			item.COMM_CONTACT_TYPEItems.SetSelection(thisItemDis2)
'DEL  		Next
'DEL  		' and display
'DEL  		STUDENT_PROFILE1COMM_CONTACT_TYPE.Items.Clear()
'DEL  	    item.COMM_CONTACT_TYPEItems.CopyTo(STUDENT_PROFILE1COMM_CONTACT_TYPE.Items)
'DEL  	end if
'DEL      
'DEL      ' -------------------------


'Hidden LEARNING_PROGRAM Event BeforeShow. Action Declare Variable @201-584C1CC6
            Dim intCLPCount As Int64 = 0
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action Declare Variable

'Hidden LEARNING_PROGRAM Event BeforeShow. Action DLookup @199-16EE4444
            intCLPCount = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(*)" & " FROM " & "view_StudentsOnACLP" & " WHERE " & "StudentId = "&STUDENT_PROFILE1Data.UrlSTUDENT_ID.tostring()))).Value, Int64)
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action DLookup

'Hidden LEARNING_PROGRAM Event BeforeShow. Action Custom Code @200-73254650
    ' -------------------------
    '8-Feb-2018|EA| count student custom subjects and change label accordingly  (ticket 10637)
    if (intCLPCount > 0) then
    	STUDENT_PROFILE1LEARNING_PROGRAM.Value = "Customised"
    	STUDENT_PROFILE1lblLearningProgram.Text = "<span style='color:white;background-color:orange'><strong>Customised</strong></span>"
    else
    	STUDENT_PROFILE1LEARNING_PROGRAM.Value = "Standard"
    	STUDENT_PROFILE1lblLearningProgram.Text = "Standard"
    end if
    ' -------------------------
'End Hidden LEARNING_PROGRAM Event BeforeShow. Action Custom Code

'CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code @105-73254650
    ' -------------------------
    'change layout 
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatColumns = 1
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatDirection = RepeatDirection.Vertical
	STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.RepeatLayout = RepeatLayout.Flow
	
    ' -------------------------
'End CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code

'CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code @99-73254650
    ' -------------------------
     '15-Dec-2016|EA| tick the Learning Program Consultation
     ' item.LEARNING_PROGRAM_CONSULTItems.SetSelection(item.LEARNING_PROGRAM_CONSULT.Value)
      ' STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.

	if (item.Hidden_LEARNING_PROGRAM_CONSULT.Value <> "0" and item.Hidden_LEARNING_PROGRAM_CONSULT.Value <> "0,") then

		Dim checkItemsDis As String() = item.Hidden_LEARNING_PROGRAM_CONSULT.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis As String = ""
		For Each thisItemDis In checkItemsDis
			' set that item as checked
			item.LEARNING_PROGRAM_CONSULTItems.SetSelection(thisItemDis)
		Next
		' and display
		STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items.Clear()
	    item.LEARNING_PROGRAM_CONSULTItems.CopyTo(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
	end if
    ' -------------------------
'End CheckBoxList LEARNING_PROGRAM_CONSULT Event BeforeShow. Action Custom Code

'Hidden hidden_LastUpdatedBy Event BeforeShow. Action Retrieve Value for Control @126-F1E0820D
            STUDENT_PROFILE1hidden_LastUpdatedBy.Value = (New TextField("", (DBUtility.UserID.ToUpper))).GetFormattedValue()
'End Hidden hidden_LastUpdatedBy Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_PROFILE1 Show method tail @3-5901EE9C
        If STUDENT_PROFILE1Errors.Count > 0 Then
            STUDENT_PROFILE1ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 Show method tail

'Record Form STUDENT_PROFILE1 LoadItemFromRequest method @3-CAF15CBF

    Protected Sub STUDENT_PROFILE1LoadItemFromRequest(item As STUDENT_PROFILE1Item, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1STUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_PROFILE1STUDENT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(STUDENT_PROFILE1ENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.LAUNCH_PAD_DONE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LAUNCH_PAD_DONE.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedItem) Then
            item.LAUNCH_PAD_DONE.SetValue(STUDENT_PROFILE1LAUNCH_PAD_DONE.SelectedItem.Value)
        Else
            item.LAUNCH_PAD_DONE.Value = Nothing
        End If
        item.LAUNCH_PAD_DONEItems.CopyFrom(STUDENT_PROFILE1LAUNCH_PAD_DONE.Items)
        Try
        item.LAUNCH_PAD_DONE_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE") Is Nothing Then
            item.LAUNCH_PAD_DONE_DATE.SetValue(STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE.Text)
        Else
            item.LAUNCH_PAD_DONE_DATE.SetValue(ControlCustomValues("STUDENT_PROFILE1LAUNCH_PAD_DONE_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("LAUNCH_PAD_DONE_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAUNCH PAD DONE DATE","d/m/yyyy"))
        End Try
        item.LEARNING_PROGRAM.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LEARNING_PROGRAM.UniqueID))
        item.LEARNING_PROGRAM.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM.Value)
        item.LEARNING_PROGRAM_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS") Is Nothing Then
            item.LEARNING_PROGRAM_DETAILS.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS.Text)
        Else
            item.LEARNING_PROGRAM_DETAILS.SetValue(ControlCustomValues("STUDENT_PROFILE1LEARNING_PROGRAM_DETAILS"))
        End If
        If Not IsNothing(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedItem) Then
            item.LEARNING_PROGRAM_CONSULT.SetValue(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.SelectedItem.Value)
        Else
            item.LEARNING_PROGRAM_CONSULT.Value = Nothing
        End If
        item.LEARNING_PROGRAM_CONSULTItems.CopyFrom(STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items)
        item.SPECIAL_PROVISION_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.UniqueID))
        If Not IsNothing(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedItem) Then
            item.SPECIAL_PROVISION_FLAG.SetValue(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.SelectedItem.Value)
        Else
            item.SPECIAL_PROVISION_FLAG.Value = Nothing
        End If
        item.SPECIAL_PROVISION_FLAGItems.CopyFrom(STUDENT_PROFILE1SPECIAL_PROVISION_FLAG.Items)
        item.SPECIAL_PROVISION_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS") Is Nothing Then
            item.SPECIAL_PROVISION_DETAILS.SetValue(STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS.Text)
        Else
            item.SPECIAL_PROVISION_DETAILS.SetValue(ControlCustomValues("STUDENT_PROFILE1SPECIAL_PROVISION_DETAILS"))
        End If
        item.REVIEW_PROGRESS_END_SEM1.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1") Is Nothing Then
            item.REVIEW_PROGRESS_END_SEM1.SetValue(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1.Text)
        Else
            item.REVIEW_PROGRESS_END_SEM1.SetValue(ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM1"))
        End If
        item.REVIEW_PROGRESS_END_SEM2.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2") Is Nothing Then
            item.REVIEW_PROGRESS_END_SEM2.SetValue(STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2.Text)
        Else
            item.REVIEW_PROGRESS_END_SEM2.SetValue(ControlCustomValues("STUDENT_PROFILE1REVIEW_PROGRESS_END_SEM2"))
        End If
        item.hidden_LastUpdatedBy.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1hidden_LastUpdatedBy.UniqueID))
        item.hidden_LastUpdatedBy.SetValue(STUDENT_PROFILE1hidden_LastUpdatedBy.Value)
        Try
        item.hidden_LastUpdatedWhen.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1hidden_LastUpdatedWhen.UniqueID))
        item.hidden_LastUpdatedWhen.SetValue(STUDENT_PROFILE1hidden_LastUpdatedWhen.Value)
        Catch ae As ArgumentException
            STUDENT_PROFILE1Errors.Add("hidden_LastUpdatedWhen",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LastUpdatedWhen","yyyy-mm-dd H:nn"))
        End Try
        item.Hidden_LEARNING_PROGRAM_CONSULT.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.UniqueID))
        item.Hidden_LEARNING_PROGRAM_CONSULT.SetValue(STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value)
        item.ASSESS_ENGLANG_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_ENGLANG_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_LP") Is Nothing Then
            item.ASSESS_ENGLANG_LP.SetValue(STUDENT_PROFILE1ASSESS_ENGLANG_LP.Text)
        Else
            item.ASSESS_ENGLANG_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_LP"))
        End If
        item.ASSESS_ENGLANG_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_ENGLANG_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_RL") Is Nothing Then
            item.ASSESS_ENGLANG_RL.SetValue(STUDENT_PROFILE1ASSESS_ENGLANG_RL.Text)
        Else
            item.ASSESS_ENGLANG_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_ENGLANG_RL"))
        End If
        item.ASSESS_MATH_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_MATH_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_LP") Is Nothing Then
            item.ASSESS_MATH_LP.SetValue(STUDENT_PROFILE1ASSESS_MATH_LP.Text)
        Else
            item.ASSESS_MATH_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_LP"))
        End If
        item.ASSESS_MATH_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_MATH_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_RL") Is Nothing Then
            item.ASSESS_MATH_RL.SetValue(STUDENT_PROFILE1ASSESS_MATH_RL.Text)
        Else
            item.ASSESS_MATH_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_MATH_RL"))
        End If
        item.ASSESS_PATSCIENCE_LP.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_LP") Is Nothing Then
            item.ASSESS_PATSCIENCE_LP.SetValue(STUDENT_PROFILE1ASSESS_PATSCIENCE_LP.Text)
        Else
            item.ASSESS_PATSCIENCE_LP.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_LP"))
        End If
        item.ASSESS_PATSCIENCE_RL.IsEmpty = IsNothing(Request.Form(STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.UniqueID))
        If ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_RL") Is Nothing Then
            item.ASSESS_PATSCIENCE_RL.SetValue(STUDENT_PROFILE1ASSESS_PATSCIENCE_RL.Text)
        Else
            item.ASSESS_PATSCIENCE_RL.SetValue(ControlCustomValues("STUDENT_PROFILE1ASSESS_PATSCIENCE_RL"))
        End If
        If STUDENT_PROFILE1cbENROL_FILE_CHECKED.Checked Then
            item.cbENROL_FILE_CHECKED.Value = (item.cbENROL_FILE_CHECKEDCheckedValue.Value)
        Else
            item.cbENROL_FILE_CHECKED.Value = (item.cbENROL_FILE_CHECKEDUncheckedValue.Value)
        End If
        If EnableValidation Then
            item.Validate(STUDENT_PROFILE1Data)
        End If
        STUDENT_PROFILE1Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_PROFILE1 LoadItemFromRequest method

'Record Form STUDENT_PROFILE1 GetRedirectUrl method @3-27A371B3

    Protected Function GetSTUDENT_PROFILE1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_PROFILE1 GetRedirectUrl method

'Record Form STUDENT_PROFILE1 ShowErrors method @3-22D82E7B

    Protected Sub STUDENT_PROFILE1ShowErrors()
        STUDENT_PROFILE1error_LPDone.Text = ""
        STUDENT_PROFILE1error_LearnDetails.Text = ""
        STUDENT_PROFILE1error_SpecialProvision.Text = ""
        STUDENT_PROFILE1error_ProgressSem1.Text = ""
        STUDENT_PROFILE1error_ProgressSem2.Text = ""
        STUDENT_PROFILE1error_AssessData.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_PROFILE1Errors.Count - 1
        Select Case STUDENT_PROFILE1Errors.AllKeys(i)
            Case "LAUNCH_PAD_DONE"
                If STUDENT_PROFILE1error_LPDone.Text <> "" Then  STUDENT_PROFILE1error_LPDone.Text &= "<br>"
                STUDENT_PROFILE1error_LPDone.Text = STUDENT_PROFILE1error_LPDone.Text & STUDENT_PROFILE1Errors(i)
            Case "LAUNCH_PAD_DONE_DATE"
                If STUDENT_PROFILE1error_LPDone.Text <> "" Then  STUDENT_PROFILE1error_LPDone.Text &= "<br>"
                STUDENT_PROFILE1error_LPDone.Text = STUDENT_PROFILE1error_LPDone.Text & STUDENT_PROFILE1Errors(i)
            Case "LEARNING_PROGRAM_DETAILS"
                If STUDENT_PROFILE1error_LearnDetails.Text <> "" Then  STUDENT_PROFILE1error_LearnDetails.Text &= "<br>"
                STUDENT_PROFILE1error_LearnDetails.Text = STUDENT_PROFILE1error_LearnDetails.Text & STUDENT_PROFILE1Errors(i)
            Case "SPECIAL_PROVISION_DETAILS"
                If STUDENT_PROFILE1error_SpecialProvision.Text <> "" Then  STUDENT_PROFILE1error_SpecialProvision.Text &= "<br>"
                STUDENT_PROFILE1error_SpecialProvision.Text = STUDENT_PROFILE1error_SpecialProvision.Text & STUDENT_PROFILE1Errors(i)
            Case "REVIEW_PROGRESS_END_SEM1"
                If STUDENT_PROFILE1error_ProgressSem1.Text <> "" Then  STUDENT_PROFILE1error_ProgressSem1.Text &= "<br>"
                STUDENT_PROFILE1error_ProgressSem1.Text = STUDENT_PROFILE1error_ProgressSem1.Text & STUDENT_PROFILE1Errors(i)
            Case "REVIEW_PROGRESS_END_SEM2"
                If STUDENT_PROFILE1error_ProgressSem2.Text <> "" Then  STUDENT_PROFILE1error_ProgressSem2.Text &= "<br>"
                STUDENT_PROFILE1error_ProgressSem2.Text = STUDENT_PROFILE1error_ProgressSem2.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_ENGLANG_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_ENGLANG_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_MATH_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_MATH_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_PATSCIENCE_LP"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case "ASSESS_PATSCIENCE_RL"
                If STUDENT_PROFILE1error_AssessData.Text <> "" Then  STUDENT_PROFILE1error_AssessData.Text &= "<br>"
                STUDENT_PROFILE1error_AssessData.Text = STUDENT_PROFILE1error_AssessData.Text & STUDENT_PROFILE1Errors(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_PROFILE1Errors(i)
        End Select
        Next i
        STUDENT_PROFILE1Error.Visible = True
        STUDENT_PROFILE1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_PROFILE1 ShowErrors method

'Record Form STUDENT_PROFILE1 Insert Operation @3-366E01D9

    Protected Sub STUDENT_PROFILE1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        Dim ExecuteFlag As Boolean = True
        STUDENT_PROFILE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_PROFILE1 Insert Operation

'Button Button_Insert OnClick. @5-3CEEB04E
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Insert" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @5-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Button Button_Insert2 OnClick. @90-AA771A43
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Insert2" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert2 OnClick.

'Button Button_Insert2 OnClick tail. @90-477CF3C9
        End If
'End Button Button_Insert2 OnClick tail.

'Record STUDENT_PROFILE1 Event BeforeInsert. Action Retrieve Value for Control @103-D34DEBEE
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_PROFILE1 Event BeforeInsert. Action Retrieve Value for Control

'Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code @104-73254650
    ' -------------------------
     '15-Dec-2016|EA|string together the selected checkbox list items and store them
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = (checkItemsDis.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeInsert. Action Custom Code

'DEL      ' -------------------------
'DEL       '22-Mar-2018|EA|string together the selected checkbox list items and store them
'DEL      ' COMM_CONTACT_TYPE_MULTI
'DEL  	checkItemsDis = "0,"
'DEL  
'DEL  	For Each thisItemDis In STUDENT_PROFILE1COMM_CONTACT_TYPE.Items
'DEL  		if thisItemDis.Selected then
'DEL  			checkItemsDis += (thisItemDis.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value = (checkItemsDis.TrimEnd(","C))
'DEL      ' -------------------------


'Record Form STUDENT_PROFILE1 BeforeInsert tail @3-DE5ECC82
    STUDENT_PROFILE1Parameters()
    STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
    If STUDENT_PROFILE1Operations.AllowInsert Then
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_PROFILE1Data.InsertItem(item)
            Catch ex As Exception
                STUDENT_PROFILE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_PROFILE1 BeforeInsert tail

'Record STUDENT_PROFILE1 Event AfterInsert. Action Custom Code @221-73254650
    ' -------------------------
    If (STUDENT_PROFILE1Errors.Count > 0 or ErrorFlag = True) Then
    	STUDENT_PROFILE1Errors.Add("STUDENT_PROFILE1","Check for errors! Scroll down page to check for errors! (eg: dates need full 4-digit years)")
    	HttpContext.Current.Session("notifymessage") = ""
    Else
    	HttpContext.Current.Session("notifymessage") = "Student Profile has been Added"
    End If
    ' -------------------------
'End Record STUDENT_PROFILE1 Event AfterInsert. Action Custom Code

'Record Form STUDENT_PROFILE1 AfterInsert tail  @3-4B48C80E
        End If
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 AfterInsert tail 

'Record Form STUDENT_PROFILE1 Update Operation @3-8FBAC437

    Protected Sub STUDENT_PROFILE1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_PROFILE1 Update Operation

'Button Button_Update OnClick. @6-B0DCA211
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Update" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Button Button_Update2 OnClick. @92-512F6434
        If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Update2" Then
            RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update2 OnClick.

'Button Button_Update2 OnClick tail. @92-477CF3C9
        End If
'End Button Button_Update2 OnClick tail.

'Record STUDENT_PROFILE1 Event BeforeUpdate. Action Retrieve Value for Control @98-D34DEBEE
        STUDENT_PROFILE1hidden_LastUpdatedWhen.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_PROFILE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code @101-73254650
    ' -------------------------
    '15-Dec-2016|EA|string together the selected checkbox list items and store them
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_PROFILE1LEARNING_PROGRAM_CONSULT.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_PROFILE1Hidden_LEARNING_PROGRAM_CONSULT.Value = (checkItemsDis.TrimEnd(","C))

    ' -------------------------
'End Record STUDENT_PROFILE1 Event BeforeUpdate. Action Custom Code

'DEL      ' -------------------------
'DEL      '22-Mar-2018|EA|string together the selected checkbox list items and store them
'DEL      ' COMM_CONTACT_TYPE_MULTI
'DEL  	checkItemsDis = "0,"
'DEL  
'DEL  	For Each thisItemDis In STUDENT_PROFILE1COMM_CONTACT_TYPE.Items
'DEL  		if thisItemDis.Selected then
'DEL  			checkItemsDis += (thisItemDis.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_PROFILE1Hidden_COMM_CONTACT_TYPE_MULTI.Value = (checkItemsDis.TrimEnd(","C))
'DEL      ' -------------------------


'Record Form STUDENT_PROFILE1 Before Update tail @3-EB86AAF9
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
        If STUDENT_PROFILE1Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_PROFILE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_PROFILE1Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_PROFILE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_PROFILE1 Before Update tail

'Record STUDENT_PROFILE1 Event AfterUpdate. Action Custom Code @220-73254650
    ' -------------------------
    If (STUDENT_PROFILE1Errors.Count > 0 or ErrorFlag = True) Then
    	STUDENT_PROFILE1Errors.Add("STUDENT_PROFILE1","Check for errors! Scroll down page to check for errors! (eg: dates need full 4-digit years)")
    	HttpContext.Current.Session("notifymessage") = ""
    Else
    	HttpContext.Current.Session("notifymessage") = "Student Profile has been Updated"
    End If
     
    ' -------------------------
'End Record STUDENT_PROFILE1 Event AfterUpdate. Action Custom Code

'Record Form STUDENT_PROFILE1 Update Operation tail @3-4B48C80E
        End If
        ErrorFlag=(STUDENT_PROFILE1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_PROFILE1 Update Operation tail

'Record Form STUDENT_PROFILE1 Delete Operation @3-342CBEA9
    Protected Sub STUDENT_PROFILE1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_PROFILE1 Delete Operation

'Record Form BeforeDelete tail @3-01F6ADAA
        STUDENT_PROFILE1Parameters()
        STUDENT_PROFILE1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-DF249C59
        If ErrorFlag Then
            STUDENT_PROFILE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_PROFILE1 Cancel Operation @3-E37D77E4

    Protected Sub STUDENT_PROFILE1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_PROFILE1Item = New STUDENT_PROFILE1Item()
        STUDENT_PROFILE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_PROFILE1LoadItemFromRequest(item, False)
'End Record Form STUDENT_PROFILE1 Cancel Operation

'Button Button_Cancel OnClick. @7-87226ED9
    If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Cancel" Then
        RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @7-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Button Button_Cancel2 OnClick. @94-8838E8DE
    If CType(sender,Control).ID = "STUDENT_PROFILE1Button_Cancel2" Then
        RedirectUrl = GetSTUDENT_PROFILE1RedirectUrl("", "")
'End Button Button_Cancel2 OnClick.

'Button Button_Cancel2 OnClick tail. @94-477CF3C9
    End If
'End Button Button_Cancel2 OnClick tail.

'Record Form STUDENT_PROFILE1 Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_PROFILE1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3952F87C
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Profile_PLSPContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_PROFILE1Data = New STUDENT_PROFILE1DataProvider()
        STUDENT_PROFILE1Operations = New FormSupportedOperations(False, True, True, True, False)
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

