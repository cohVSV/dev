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

Namespace DECV_PROD2007.StudentEnrolmentDetails_maintain 'Namespace @1-B3DCCE1A

'Forms Definition @1-362FE59D
Public Class [StudentEnrolmentDetails_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-A767430E
    Protected STUDENT_ENROLMENTData As STUDENT_ENROLMENTDataProvider
    Protected STUDENT_ENROLMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_ENROLMENTOperations As FormSupportedOperations
    Protected STUDENT_ENROLMENTIsSubmitted As Boolean = False
    Protected STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName As String
    Protected STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl As String
    Protected STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName As String
    Protected STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl As String
    Protected StudentEnrolmentDetails_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-BEB39D3B
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_ENROLMENTShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_ENROLMENT Parameters @2-4BDF985F

    Protected Sub STUDENT_ENROLMENTParameters()
        Dim item As new STUDENT_ENROLMENTItem
        Try
            STUDENT_ENROLMENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_ENROLMENTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_ENROLMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_ENROLMENT Parameters

'Record Form STUDENT_ENROLMENT Show method @2-01993FE5
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

'Record Form STUDENT_ENROLMENT BeforeShow tail @2-F9359764
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTData.FillItem(item, IsInsertMode)
        STUDENT_ENROLMENTHolder.DataBind()
        STUDENT_ENROLMENTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_ENROLMENTOperations.AllowInsert
        STUDENT_ENROLMENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_ENROLMENTOperations.AllowUpdate
        STUDENT_ENROLMENTPASTORAL_CARE_ID.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTPASTORAL_CARE_ID.Items(0).Selected = True
        item.PASTORAL_CARE_IDItems.SetSelection(item.PASTORAL_CARE_ID.GetFormattedValue())
        If Not item.PASTORAL_CARE_IDItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTPASTORAL_CARE_ID.SelectedIndex = -1
        End If
        item.PASTORAL_CARE_IDItems.CopyTo(STUDENT_ENROLMENTPASTORAL_CARE_ID.Items)
        STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE.Text=item.DOCS_LAST_REVIEWED_DATE.GetFormattedValue()
        item.NEW_DOCS_REQUIREDItems.SetSelection(item.NEW_DOCS_REQUIRED.GetFormattedValue())
        STUDENT_ENROLMENTNEW_DOCS_REQUIRED.SelectedIndex = -1
        item.NEW_DOCS_REQUIREDItems.CopyTo(STUDENT_ENROLMENTNEW_DOCS_REQUIRED.Items)
        STUDENT_ENROLMENTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
        STUDENT_ENROLMENTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTHidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STUDENT_ENROLMENTHidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.Items(0).Selected = True
        item.YEAR_LEVEL_REPORTINGItems.SetSelection(item.YEAR_LEVEL_REPORTING.GetFormattedValue())
        If Not item.YEAR_LEVEL_REPORTINGItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.SelectedIndex = -1
        End If
        item.YEAR_LEVEL_REPORTINGItems.CopyTo(STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.Items)
        STUDENT_ENROLMENThidden_yearlevel_original.Value = item.hidden_yearlevel_original.GetFormattedValue()
        STUDENT_ENROLMENThidden_yearlevel_original1.Value = item.hidden_yearlevel_original1.GetFormattedValue()
        STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID.Value = item.Hidden_PASTORAL_CARE_ID.GetFormattedValue()
        STUDENT_ENROLMENTPASTORAL_ALLOC_BY.Value = item.PASTORAL_ALLOC_BY.GetFormattedValue()
        STUDENT_ENROLMENTPASTORAL_ALLOC_DATE.Value = item.PASTORAL_ALLOC_DATE.GetFormattedValue()
        STUDENT_ENROLMENTLAd_ALLOC_BY.Text = Server.HtmlEncode(item.LAd_ALLOC_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTLAd_ALLOC_DATE.Text = Server.HtmlEncode(item.LAd_ALLOC_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTATAR_REQUIRED.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTATAR_REQUIRED.Items(0).Selected = True
        item.ATAR_REQUIREDItems.SetSelection(item.ATAR_REQUIRED.GetFormattedValue())
        If Not item.ATAR_REQUIREDItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTATAR_REQUIRED.SelectedIndex = -1
        End If
        item.ATAR_REQUIREDItems.CopyTo(STUDENT_ENROLMENTATAR_REQUIRED.Items)
        item.PRIVACY_PERMISSIONItems.SetSelection(item.PRIVACY_PERMISSION.GetFormattedValue())
        STUDENT_ENROLMENTPRIVACY_PERMISSION.SelectedIndex = -1
        item.PRIVACY_PERMISSIONItems.CopyTo(STUDENT_ENROLMENTPRIVACY_PERMISSION.Items)
        item.INTERVIEW_INTAKE_DONEItems.SetSelection(item.INTERVIEW_INTAKE_DONE.GetFormattedValue())
        STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.SelectedIndex = -1
        item.INTERVIEW_INTAKE_DONEItems.CopyTo(STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.Items)
        STUDENT_ENROLMENTRECEIPT_NO.Text=item.RECEIPT_NO.GetFormattedValue()
        STUDENT_ENROLMENTlbEXIT_DESTINATION.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTlbEXIT_DESTINATION.Items(0).Selected = True
        item.lbEXIT_DESTINATIONItems.SetSelection(item.lbEXIT_DESTINATION.GetFormattedValue())
        If Not item.lbEXIT_DESTINATIONItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTlbEXIT_DESTINATION.SelectedIndex = -1
        End If
        item.lbEXIT_DESTINATIONItems.CopyTo(STUDENT_ENROLMENTlbEXIT_DESTINATION.Items)
        STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items(0).Selected = True
        item.WITHDRAWAL_REASON_IDItems.SetSelection(item.WITHDRAWAL_REASON_ID.GetFormattedValue())
        If Not item.WITHDRAWAL_REASON_IDItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.SelectedIndex = -1
        End If
        item.WITHDRAWAL_REASON_IDItems.CopyTo(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items)
        STUDENT_ENROLMENTlist_Region.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTlist_Region.Items(0).Selected = True
        item.list_RegionItems.SetSelection(item.list_Region.GetFormattedValue())
        If Not item.list_RegionItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTlist_Region.SelectedIndex = -1
        End If
        item.list_RegionItems.CopyTo(STUDENT_ENROLMENTlist_Region.Items)
        STUDENT_ENROLMENTregion_approval_number.Text=item.region_approval_number.GetFormattedValue()
        item.ELIGIBLE_FOR_FUNDINGItems.SetSelection(item.ELIGIBLE_FOR_FUNDING.GetFormattedValue())
        STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.SelectedIndex = -1
        item.ELIGIBLE_FOR_FUNDINGItems.CopyTo(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.Items)
        item.PAID_ON_ENROLMENTItems.SetSelection(item.PAID_ON_ENROLMENT.GetFormattedValue())
        STUDENT_ENROLMENTPAID_ON_ENROLMENT.SelectedIndex = -1
        item.PAID_ON_ENROLMENTItems.CopyTo(STUDENT_ENROLMENTPAID_ON_ENROLMENT.Items)
        item.ELIGIBLE_FOR_DISCOUNTItems.SetSelection(item.ELIGIBLE_FOR_DISCOUNT.GetFormattedValue())
        STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.SelectedIndex = -1
        item.ELIGIBLE_FOR_DISCOUNTItems.CopyTo(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.Items)
        STUDENT_ENROLMENTENROLMENT_YEAR.Text = Server.HtmlEncode(item.ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTYEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTYEAR_LEVEL.Items(0).Selected = True
        item.YEAR_LEVELItems.SetSelection(item.YEAR_LEVEL.GetFormattedValue())
        If Not item.YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTYEAR_LEVEL.SelectedIndex = -1
        End If
        item.YEAR_LEVELItems.CopyTo(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        STUDENT_ENROLMENTENROLMENT_STATUS.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTENROLMENT_STATUS.Items(0).Selected = True
        item.ENROLMENT_STATUSItems.SetSelection(item.ENROLMENT_STATUS.GetFormattedValue())
        If Not item.ENROLMENT_STATUSItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTENROLMENT_STATUS.SelectedIndex = -1
        End If
        item.ENROLMENT_STATUSItems.CopyTo(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName = "STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE"
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl = STUDENT_ENROLMENTWITHDRAWAL_DATE.ClientID
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.DataBind()
        STUDENT_ENROLMENTWITHDRAWAL_DATE.Text=item.WITHDRAWAL_DATE.GetFormattedValue()
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName = "STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE"
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl = STUDENT_ENROLMENTENROLMENT_DATE.ClientID
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.DataBind()
        STUDENT_ENROLMENTENROLMENT_DATE.Text=item.ENROLMENT_DATE.GetFormattedValue()
        STUDENT_ENROLMENTSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.PERSONAL_LEARNING_PLANItems.SetSelection(item.PERSONAL_LEARNING_PLAN.GetFormattedValue())
        STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.SelectedIndex = -1
        item.PERSONAL_LEARNING_PLANItems.CopyTo(STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.Items)
        STUDENT_ENROLMENTHidden_LearningPlan.Value = item.Hidden_LearningPlan.GetFormattedValue()
        STUDENT_ENROLMENTHidden_EnrolmentStatus.Value = item.Hidden_EnrolmentStatus.GetFormattedValue()
        STUDENT_ENROLMENTHidden_Privacy.Value = item.Hidden_Privacy.GetFormattedValue()
        STUDENT_ENROLMENTSSG_FACILITATOR_ID.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTSSG_FACILITATOR_ID.Items(0).Selected = True
        item.SSG_FACILITATOR_IDItems.SetSelection(item.SSG_FACILITATOR_ID.GetFormattedValue())
        If Not item.SSG_FACILITATOR_IDItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTSSG_FACILITATOR_ID.SelectedIndex = -1
        End If
        item.SSG_FACILITATOR_IDItems.CopyTo(STUDENT_ENROLMENTSSG_FACILITATOR_ID.Items)
'End Record Form STUDENT_ENROLMENT BeforeShow tail

'ListBox PASTORAL_CARE_ID Event BeforeShow. Action Custom Code @437-73254650
         ' 17 Feb 2022|RW| Remove some values from the list of possible options for assigning a Learning Advisor (which can end up being auto-synced to the LP teacher)
         ' However if the current selection is already set to that value, eg. UNASSIGN, it must be left as-is.
         ' At this time the system value "N-A" is not removed as an option, as setting the LADV to it will not result in the Launch Pad
         ' teacher also being set to N-A.
         ' The LADV Coordinator also may need to temporarily switch assignments back to N-A during the early period of LADV management.
         Dim itemsToRemoveIfNotSelected = {"UNASSIGN"}
         Dim itemIndex = 0
         While (itemIndex < STUDENT_ENROLMENTPASTORAL_CARE_ID.Items.Count)
            Dim listItem = STUDENT_ENROLMENTPASTORAL_CARE_ID.Items(itemIndex)
            Dim itemValue = listItem.Value.Trim().ToUpper()
            Dim itemRemoved = False
            If ((Not listItem.Selected) AndAlso
                  (itemsToRemoveIfNotSelected.Contains(itemValue) OrElse itemValue.StartsWith("NSUBMIT"))) Then
               STUDENT_ENROLMENTPASTORAL_CARE_ID.Items.RemoveAt(itemIndex)
               itemRemoved = True
            End If

            If (Not itemRemoved) Then
               itemIndex += 1
            End If
         End While
'End ListBox PASTORAL_CARE_ID Event BeforeShow. Action Custom Code

'Hidden hidden_yearlevel_original Event BeforeShow. Action Retrieve Value for Control @219-0980E76B
            STUDENT_ENROLMENThidden_yearlevel_original.Value = (New TextField("", (item.YEAR_LEVEL.GetFormattedValue()))).GetFormattedValue()
'End Hidden hidden_yearlevel_original Event BeforeShow. Action Retrieve Value for Control

'Hidden hidden_yearlevel_original1 Event BeforeShow. Action Retrieve Value for Control @222-18F4E4D6
            STUDENT_ENROLMENThidden_yearlevel_original1.Value = (New TextField("", (item.YEAR_LEVEL_REPORTING.GetFormattedValue()))).GetFormattedValue()
'End Hidden hidden_yearlevel_original1 Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_PASTORAL_CARE_ID Event BeforeShow. Action Retrieve Value for Control @237-F3B2A124
            STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID.Value = (New TextField("", (item.PASTORAL_CARE_ID.GetFormattedValue()))).GetFormattedValue()
'End Hidden Hidden_PASTORAL_CARE_ID Event BeforeShow. Action Retrieve Value for Control

'RadioButton PRIVACY_PERMISSION Event BeforeShow. Action Custom Code @398-73254650
    ' -------------------------
    STUDENT_ENROLMENTHidden_Privacy.Value = (New TextField("", (item.PRIVACY_PERMISSION.GetFormattedValue()))).GetFormattedValue()
    ' -------------------------
'End RadioButton PRIVACY_PERMISSION Event BeforeShow. Action Custom Code

'ListBox ENROLMENT_STATUS Event BeforeShow. Action Custom Code @395-73254650
    ' -------------------------
     '20-Feb-2020|EA| set the value so it can be used later for adding comment when changed
    STUDENT_ENROLMENTHidden_EnrolmentStatus.Value = item.ENROLMENT_STATUS.GetFormattedValue()
    ' -------------------------
'End ListBox ENROLMENT_STATUS Event BeforeShow. Action Custom Code

'RadioButton PERSONAL_LEARNING_PLAN Event BeforeShow. Action Custom Code @319-73254650
    ' -------------------------
    '28-Nov-2019|EA| new PLP/PLSP (sd #20337)
    STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.RepeatDirection= RepeatDirection.Vertical
    ' and set the value so it can be used later
    STUDENT_ENROLMENTHidden_LearningPlan.Value = item.PERSONAL_LEARNING_PLAN.GetFormattedValue()
    ' -------------------------
'End RadioButton PERSONAL_LEARNING_PLAN Event BeforeShow. Action Custom Code

'Record Form STUDENT_ENROLMENT Show method tail @2-ECC726FD
        If STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_ENROLMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT Show method tail

'Record Form STUDENT_ENROLMENT LoadItemFromRequest method @2-442D0A7C

    Protected Sub STUDENT_ENROLMENTLoadItemFromRequest(item As STUDENT_ENROLMENTItem, ByVal EnableValidation As Boolean)
        item.PASTORAL_CARE_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPASTORAL_CARE_ID.UniqueID))
        item.PASTORAL_CARE_ID.SetValue(STUDENT_ENROLMENTPASTORAL_CARE_ID.Value)
        item.PASTORAL_CARE_IDItems.CopyFrom(STUDENT_ENROLMENTPASTORAL_CARE_ID.Items)
        Try
        item.DOCS_LAST_REVIEWED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE") Is Nothing Then
            item.DOCS_LAST_REVIEWED_DATE.SetValue(STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE.Text)
        Else
            item.DOCS_LAST_REVIEWED_DATE.SetValue(ControlCustomValues("STUDENT_ENROLMENTDOCS_LAST_REVIEWED_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("DOCS_LAST_REVIEWED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"DOCS_LAST_REVIEWED_DATE","dd/mm/yy"))
        End Try
        Try
        item.NEW_DOCS_REQUIRED.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTNEW_DOCS_REQUIRED.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTNEW_DOCS_REQUIRED.SelectedItem) Then
            item.NEW_DOCS_REQUIRED.SetValue(STUDENT_ENROLMENTNEW_DOCS_REQUIRED.SelectedItem.Value)
        Else
            item.NEW_DOCS_REQUIRED.Value = Nothing
        End If
        item.NEW_DOCS_REQUIREDItems.CopyFrom(STUDENT_ENROLMENTNEW_DOCS_REQUIRED.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("NEW_DOCS_REQUIRED",String.Format(Resources.strings.CCS_IncorrectValue,"NEW_DOCS_REQUIRED"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STUDENT_ENROLMENTHidden_last_altered_by.Value)
        Try
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STUDENT_ENROLMENTHidden_last_altered_date.Value)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("Hidden_last_altered_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_last_altered_date","yyyy-mm-dd H:nn"))
        End Try
        Try
        item.YEAR_LEVEL_REPORTING.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.UniqueID))
        item.YEAR_LEVEL_REPORTING.SetValue(STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.Value)
        item.YEAR_LEVEL_REPORTINGItems.CopyFrom(STUDENT_ENROLMENTYEAR_LEVEL_REPORTING.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("YEAR_LEVEL_REPORTING",String.Format(Resources.strings.CCS_IncorrectValue,"REPORTING YEAR LEVEL"))
        End Try
        item.hidden_yearlevel_original.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENThidden_yearlevel_original.UniqueID))
        item.hidden_yearlevel_original.SetValue(STUDENT_ENROLMENThidden_yearlevel_original.Value)
        item.hidden_yearlevel_original1.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENThidden_yearlevel_original1.UniqueID))
        item.hidden_yearlevel_original1.SetValue(STUDENT_ENROLMENThidden_yearlevel_original1.Value)
        item.Hidden_PASTORAL_CARE_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID.UniqueID))
        item.Hidden_PASTORAL_CARE_ID.SetValue(STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID.Value)
        item.PASTORAL_ALLOC_BY.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPASTORAL_ALLOC_BY.UniqueID))
        item.PASTORAL_ALLOC_BY.SetValue(STUDENT_ENROLMENTPASTORAL_ALLOC_BY.Value)
        Try
        item.PASTORAL_ALLOC_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPASTORAL_ALLOC_DATE.UniqueID))
        item.PASTORAL_ALLOC_DATE.SetValue(STUDENT_ENROLMENTPASTORAL_ALLOC_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("PASTORAL_ALLOC_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"PASTORAL_ALLOC_DATE","yyyy-mm-dd H:nn"))
        End Try
        item.ATAR_REQUIRED.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTATAR_REQUIRED.UniqueID))
        item.ATAR_REQUIRED.SetValue(STUDENT_ENROLMENTATAR_REQUIRED.Value)
        item.ATAR_REQUIREDItems.CopyFrom(STUDENT_ENROLMENTATAR_REQUIRED.Items)
        Try
        item.PRIVACY_PERMISSION.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPRIVACY_PERMISSION.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTPRIVACY_PERMISSION.SelectedItem) Then
            item.PRIVACY_PERMISSION.SetValue(STUDENT_ENROLMENTPRIVACY_PERMISSION.SelectedItem.Value)
        Else
            item.PRIVACY_PERMISSION.Value = Nothing
        End If
        item.PRIVACY_PERMISSIONItems.CopyFrom(STUDENT_ENROLMENTPRIVACY_PERMISSION.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("PRIVACY_PERMISSION",String.Format(Resources.strings.CCS_IncorrectValue,"PRIVACY PERMISSION"))
        End Try
        Try
        item.INTERVIEW_INTAKE_DONE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.SelectedItem) Then
            item.INTERVIEW_INTAKE_DONE.SetValue(STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.SelectedItem.Value)
        Else
            item.INTERVIEW_INTAKE_DONE.Value = Nothing
        End If
        item.INTERVIEW_INTAKE_DONEItems.CopyFrom(STUDENT_ENROLMENTINTERVIEW_INTAKE_DONE.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("INTERVIEW_INTAKE_DONE",String.Format(Resources.strings.CCS_IncorrectValue,"INTERVIEW INTAKE DONE?"))
        End Try
        item.RECEIPT_NO.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTRECEIPT_NO.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTRECEIPT_NO") Is Nothing Then
            item.RECEIPT_NO.SetValue(STUDENT_ENROLMENTRECEIPT_NO.Text)
        Else
            item.RECEIPT_NO.SetValue(ControlCustomValues("STUDENT_ENROLMENTRECEIPT_NO"))
        End If
        Try
        item.lbEXIT_DESTINATION.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTlbEXIT_DESTINATION.UniqueID))
        item.lbEXIT_DESTINATION.SetValue(STUDENT_ENROLMENTlbEXIT_DESTINATION.Value)
        item.lbEXIT_DESTINATIONItems.CopyFrom(STUDENT_ENROLMENTlbEXIT_DESTINATION.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("lbEXIT_DESTINATION",String.Format(Resources.strings.CCS_IncorrectValue,"EXIT DESTINATION"))
        End Try
        Try
        item.WITHDRAWAL_REASON_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.UniqueID))
        item.WITHDRAWAL_REASON_ID.SetValue(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Value)
        item.WITHDRAWAL_REASON_IDItems.CopyFrom(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("WITHDRAWAL_REASON_ID",String.Format(Resources.strings.CCS_IncorrectValue,"WITHDRAWAL REASON ID"))
        End Try
        item.list_Region.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTlist_Region.UniqueID))
        item.list_Region.SetValue(STUDENT_ENROLMENTlist_Region.Value)
        item.list_RegionItems.CopyFrom(STUDENT_ENROLMENTlist_Region.Items)
        item.region_approval_number.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTregion_approval_number.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTregion_approval_number") Is Nothing Then
            item.region_approval_number.SetValue(STUDENT_ENROLMENTregion_approval_number.Text)
        Else
            item.region_approval_number.SetValue(ControlCustomValues("STUDENT_ENROLMENTregion_approval_number"))
        End If
        Try
        item.ELIGIBLE_FOR_FUNDING.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.SelectedItem) Then
            item.ELIGIBLE_FOR_FUNDING.SetValue(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.SelectedItem.Value)
        Else
            item.ELIGIBLE_FOR_FUNDING.Value = Nothing
        End If
        item.ELIGIBLE_FOR_FUNDINGItems.CopyFrom(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("ELIGIBLE_FOR_FUNDING",String.Format(Resources.strings.CCS_IncorrectValue,"ELIGIBLE_FOR_FUNDING"))
        End Try
        Try
        item.PAID_ON_ENROLMENT.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPAID_ON_ENROLMENT.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTPAID_ON_ENROLMENT.SelectedItem) Then
            item.PAID_ON_ENROLMENT.SetValue(STUDENT_ENROLMENTPAID_ON_ENROLMENT.SelectedItem.Value)
        Else
            item.PAID_ON_ENROLMENT.Value = Nothing
        End If
        item.PAID_ON_ENROLMENTItems.CopyFrom(STUDENT_ENROLMENTPAID_ON_ENROLMENT.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("PAID_ON_ENROLMENT",String.Format(Resources.strings.CCS_IncorrectValue,"PAID_ON_ENROLMENT"))
        End Try
        Try
        item.ELIGIBLE_FOR_DISCOUNT.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.SelectedItem) Then
            item.ELIGIBLE_FOR_DISCOUNT.SetValue(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.SelectedItem.Value)
        Else
            item.ELIGIBLE_FOR_DISCOUNT.Value = Nothing
        End If
        item.ELIGIBLE_FOR_DISCOUNTItems.CopyFrom(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("ELIGIBLE_FOR_DISCOUNT",String.Format(Resources.strings.CCS_IncorrectValue,"ELIGIBLE_FOR_DISCOUNT"))
        End Try
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTYEAR_LEVEL.UniqueID))
        item.YEAR_LEVEL.SetValue(STUDENT_ENROLMENTYEAR_LEVEL.Value)
        item.YEAR_LEVELItems.CopyFrom(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.ENROLMENT_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_STATUS.UniqueID))
        item.ENROLMENT_STATUS.SetValue(STUDENT_ENROLMENTENROLMENT_STATUS.Value)
        item.ENROLMENT_STATUSItems.CopyFrom(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        Try
        item.WITHDRAWAL_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTWITHDRAWAL_DATE.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTWITHDRAWAL_DATE") Is Nothing Then
            item.WITHDRAWAL_DATE.SetValue(STUDENT_ENROLMENTWITHDRAWAL_DATE.Text)
        Else
            item.WITHDRAWAL_DATE.SetValue(ControlCustomValues("STUDENT_ENROLMENTWITHDRAWAL_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("WITHDRAWAL_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"WITHDRAWAL DATE","dd/mm/yy"))
        End Try
        Try
        item.ENROLMENT_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_DATE.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTENROLMENT_DATE") Is Nothing Then
            item.ENROLMENT_DATE.SetValue(STUDENT_ENROLMENTENROLMENT_DATE.Text)
        Else
            item.ENROLMENT_DATE.SetValue(ControlCustomValues("STUDENT_ENROLMENTENROLMENT_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("ENROLMENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"ENROLMENT DATE","dd/mm/yy"))
        End Try
        item.PERSONAL_LEARNING_PLAN.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.SelectedItem) Then
            item.PERSONAL_LEARNING_PLAN.SetValue(STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.SelectedItem.Value)
        Else
            item.PERSONAL_LEARNING_PLAN.Value = Nothing
        End If
        item.PERSONAL_LEARNING_PLANItems.CopyFrom(STUDENT_ENROLMENTPERSONAL_LEARNING_PLAN.Items)
        item.Hidden_LearningPlan.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_LearningPlan.UniqueID))
        item.Hidden_LearningPlan.SetValue(STUDENT_ENROLMENTHidden_LearningPlan.Value)
        item.Hidden_EnrolmentStatus.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_EnrolmentStatus.UniqueID))
        item.Hidden_EnrolmentStatus.SetValue(STUDENT_ENROLMENTHidden_EnrolmentStatus.Value)
        item.Hidden_Privacy.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTHidden_Privacy.UniqueID))
        item.Hidden_Privacy.SetValue(STUDENT_ENROLMENTHidden_Privacy.Value)
        item.SSG_FACILITATOR_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTSSG_FACILITATOR_ID.UniqueID))
        item.SSG_FACILITATOR_ID.SetValue(STUDENT_ENROLMENTSSG_FACILITATOR_ID.Value)
        item.SSG_FACILITATOR_IDItems.CopyFrom(STUDENT_ENROLMENTSSG_FACILITATOR_ID.Items)
        If EnableValidation Then
            item.Validate(STUDENT_ENROLMENTData)
        End If
        STUDENT_ENROLMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_ENROLMENT LoadItemFromRequest method

'Record Form STUDENT_ENROLMENT GetRedirectUrl method @2-C0967373

    Protected Function GetSTUDENT_ENROLMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_ENROLMENT GetRedirectUrl method

'Record Form STUDENT_ENROLMENT ShowErrors method @2-E76A22EF

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

'Record Form STUDENT_ENROLMENT Insert Operation @2-808B86DE

    Protected Sub STUDENT_ENROLMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        STUDENT_ENROLMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT Insert Operation

'Button Button_Insert OnClick. @3-84FB2BE8
        If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Insert" Then
            RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_ENROLMENT BeforeInsert tail @2-5B58CAB2
    STUDENT_ENROLMENTParameters()
    STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_ENROLMENT BeforeInsert tail

'Record Form STUDENT_ENROLMENT AfterInsert tail  @2-44396D32
        ErrorFlag=(STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT AfterInsert tail 

'Record Form STUDENT_ENROLMENT Update Operation @2-3B065CD3

    Protected Sub STUDENT_ENROLMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT Update Operation

'Button Button_Update OnClick. @4-7FA3559F
        If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Update" Then
            RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @172-17BBB9F9
        STUDENT_ENROLMENTHidden_last_altered_by.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @173-C1B3B5CD
        STUDENT_ENROLMENTHidden_last_altered_date.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Custom Code @276-73254650
    ' -------------------------
    '9-Aug-2018|EA| if the LAd has changed (compare Pastoral card ID listbox to hidden copy)
    ' then update the Pastoral Card Updated By/When	
	if (STUDENT_ENROLMENTPASTORAL_CARE_ID.Value <> STUDENT_ENROLMENTHidden_PASTORAL_CARE_ID.Value) then
    ' -------------------------
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Custom Code

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @277-DBFCF675
        STUDENT_ENROLMENTPASTORAL_ALLOC_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control @278-82C79FD2
        STUDENT_ENROLMENTPASTORAL_ALLOC_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_ENROLMENT Event BeforeUpdate. Action Custom Code @279-73254650
    ' -------------------------
    '9-Aug-2018|EA| if the LAd has changed	
	end if
    ' -------------------------
'End Record STUDENT_ENROLMENT Event BeforeUpdate. Action Custom Code


'Record Form STUDENT_ENROLMENT Before Update tail @2-C85BE3DE
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

'Record STUDENT_ENROLMENT Event AfterUpdate. Action Custom Code @220-73254650
    ' -------------------------
      'ERA: 2-Apr-2012|EA| per unfuddle #453, send email to PCSupport advising that an update has been made 
	  ' on the Student Enrolment page, where the YEAR_LEVEL or YEAR_LEVEL_REPORTING has changed, so that
	  ' changes can be made to Markbook if needed
	' Code from codecharge help "Enhancing Application Functionality with Programming Events (C# and VB.Net)" Step 4.
   ' 04-Nov-2020|RW| Minor changes here to conditionally handle emails across dev, test, and production environments
	
	
	If ExecuteFlag And (Not ErrorFlag) Then 
		
		if ((item.YEAR_LEVEL.getformattedvalue() <> item.hidden_yearlevel_original.getformattedvalue()) or (item.YEAR_LEVEL_REPORTING.getformattedvalue() <> item.hidden_yearlevel_original1.getformattedvalue())) then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim pcSupportEmail = "pcsupport@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, pcSupportEmail)
			Dim MessageFrom As String = "reports@vsv.vic.edu.au"
		'	newMessage.To = "eaffleck@distance.vic.edu.au"	'debug
		'	newMessage.To = "lnigro@distance.vic.edu.au"	'debug
			Dim MessageTo As String = emailRecipient
		
			Dim MessageSubject As String = "Auto Student DB Advice - Changes made to Student Enrolment Years"
			Dim MessageBody As String = "This Student's Year Levels have been <em>updated</em> in the Student Admin Database.<br><br> " & _
				"<br />Student ID : <strong>" & STUDENT_ENROLMENTData.UrlSTUDENT_ID.tostring() & "</strong> "  & _
				"<br />Old / New YEAR LEVEL : <strong>" & item.hidden_yearlevel_original.getformattedvalue() & " / " & item.YEAR_LEVEL.getformattedvalue() & "</strong>" & _
				"<br />Old / New YEAR LEVEL Reporting : <strong>" & item.hidden_yearlevel_original1.getformattedvalue() & " / " &  item.YEAR_LEVEL_REPORTING.getformattedvalue() & "</strong>" & _
				"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
				"<br><br>---- that is all ----"
			' send to the internal DECV Exchange Server - MADE GENERIC April 2012

            Dim TestEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
            TestEmail.IsBodyHtml = True
            Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))

            EmailServer.Send(TestEmail)
		end if

		'Feb-2020|EA| add comment if the Learning program changes
		if (item.Hidden_LearningPlan.GetFormattedValue() <> item.PERSONAL_LEARNING_PLAN.GetFormattedValue()) then 
			Try
				Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				Dim Sql As String = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) "  & _
									" SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(STUDENT_ENROLMENTData.UrlSTUDENT_ID.tostring(), FieldType._Text, True) & ", 'Personal Learning Plan changed to ["& item.PERSONAL_LEARNING_PLAN.GetFormattedValue() & "]', "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'COORD_DECISION'"
				'response.write(Sql.ToUpper)
				'response.end
				NewDao.RunSql(Sql)
	        Catch ex As Exception
	            STUDENT_ENROLMENTErrors.Add("Comment Insert","Error inserting PLP Comment: " & ex.Message)
	            ErrorFlag = True
	        End Try
		end if
		
	  	'Feb-2020|EA| add comment if the Enrolment Status changed
		if (item.Hidden_EnrolmentStatus.GetFormattedValue() <> item.ENROLMENT_STATUS.GetFormattedValue()) then 
			Try
				Dim NewDao2 As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				Dim Sql2 As String = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) "  & _
									" SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao2.ToSql(STUDENT_ENROLMENTData.UrlSTUDENT_ID.tostring(), FieldType._Text, True) & ", 'Enrolment Status changed to ["& item.ENROLMENT_STATUS.GetFormattedValue() & "] WD Reason ID:["& item.WITHDRAWAL_REASON_ID.GetFormattedValue() & "]', "& NewDao2.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'AutoLog'"

				NewDao2.RunSql(Sql2)
	        Catch ex As Exception
	            STUDENT_ENROLMENTErrors.Add("Comment Insert","Error inserting Enrol Status Comment: " & ex.Message)
	            ErrorFlag = True
	        End Try
		end if

		'Feb-2020|EA| add comment if the Privacy Permission Status changed
		if (item.PRIVACY_PERMISSION.GetFormattedValue() = "No" AND (item.Hidden_Privacy.GetFormattedValue() <> item.PRIVACY_PERMISSION.GetFormattedValue())) then 
			Try
				Dim NewDao3 As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				Dim Sql3 As String = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) "  & _
									" SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao3.ToSql(STUDENT_ENROLMENTData.UrlSTUDENT_ID.tostring(), FieldType._Text, True) & ", 'Do Not Share Personal/Health details outside VSV (Enquiries to TL Wellbeing) Privacy Permission ["& item.PRIVACY_PERMISSION.GetFormattedValue() & "]', "& NewDao3.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'AutoLog'"

				NewDao3.RunSql(Sql3)
	        Catch ex As Exception
	            STUDENT_ENROLMENTErrors.Add("Comment Insert","Error inserting Privacy Comment: " & ex.Message)
	            ErrorFlag = True
	        End Try
		end if


		HttpContext.Current.Session("notifymessage") = "Student Enrolment has been Updated"

	End If
    ' -------------------------
'End Record STUDENT_ENROLMENT Event AfterUpdate. Action Custom Code

'Record Form STUDENT_ENROLMENT Update Operation tail @2-D12A32EA
        End If
        ErrorFlag=(STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT Update Operation tail

'Record Form STUDENT_ENROLMENT Delete Operation @2-9953013B
    Protected Sub STUDENT_ENROLMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_ENROLMENT Delete Operation

'Record Form BeforeDelete tail @2-5B58CAB2
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-D5C63583
        If ErrorFlag Then
            STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_ENROLMENT Cancel Operation @2-5C40A49E

    Protected Sub STUDENT_ENROLMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENTItem = New STUDENT_ENROLMENTItem()
        STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_ENROLMENTLoadItemFromRequest(item, False)
'End Record Form STUDENT_ENROLMENT Cancel Operation

'Button Button_Cancel OnClick. @5-2685CE38
    If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("StudentSummary.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @5-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_ENROLMENT Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_ENROLMENT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A5D068AD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolmentDetails_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_ENROLMENTData = New STUDENT_ENROLMENTDataProvider()
        STUDENT_ENROLMENTOperations = New FormSupportedOperations(False, True, False, True, False)
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

