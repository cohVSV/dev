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

Namespace DECV_PROD2007.StudentEnrolmentDetails_maintain_backup 'Namespace @1-6D4DF947

'Forms Definition @1-3DFA663B
Public Class [StudentEnrolmentDetails_maintain_backupPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-B65994EF
    Protected STUDENT_ENROLMENTData As STUDENT_ENROLMENTDataProvider
    Protected STUDENT_ENROLMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_ENROLMENTOperations As FormSupportedOperations
    Protected STUDENT_ENROLMENTIsSubmitted As Boolean = False
    Protected STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName As String
    Protected STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl As String
    Protected STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName As String
    Protected STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl As String
    Protected StudentEnrolmentDetails_maintain_backupContentMeta As String
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

'Record Form STUDENT_ENROLMENT Parameters @2-FAF2EB19

    Protected Sub STUDENT_ENROLMENTParameters()
        Dim item As new STUDENT_ENROLMENTItem
        Try
            STUDENT_ENROLMENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_ENROLMENTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlENROLMENT_DATE = DateParameter.GetParam(item.ENROLMENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            STUDENT_ENROLMENTData.CtrlWITHDRAWAL_DATE = DateParameter.GetParam(item.WITHDRAWAL_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            STUDENT_ENROLMENTData.CtrlENROLMENT_STATUS = TextParameter.GetParam(item.ENROLMENT_STATUS.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlWITHDRAWAL_REASON_ID = FloatParameter.GetParam(item.WITHDRAWAL_REASON_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlYEAR_LEVEL = IntegerParameter.GetParam(item.YEAR_LEVEL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlCAMPUS = TextParameter.GetParam(item.CAMPUS.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlRECEIPT_NO = TextParameter.GetParam(item.RECEIPT_NO.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlELIGIBLE_FOR_DISCOUNT = TextParameter.GetParam(item.ELIGIBLE_FOR_DISCOUNT.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlPAID_ON_ENROLMENT = TextParameter.GetParam(item.PAID_ON_ENROLMENT.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlFULL_TIME_STUDENT = TextParameter.GetParam(item.FULL_TIME_STUDENT.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlOS_FULL_FEE_PAYING = TextParameter.GetParam(item.OS_FULL_FEE_PAYING.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlADDRESS_REVIEW_FLAG = TextParameter.GetParam(item.ADDRESS_REVIEW_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlELIGIBLE_FOR_FUNDING = TextParameter.GetParam(item.ELIGIBLE_FOR_FUNDING.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlVCE_CANDIDATE_NO = TextParameter.GetParam(item.VCE_CANDIDATE_NO.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlBULLETIN_NO = TextParameter.GetParam(item.BULLETIN_NO.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlSUB_SCHOOL = TextParameter.GetParam(item.SUB_SCHOOL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlPASTORAL_CARE_ID = TextParameter.GetParam(item.PASTORAL_CARE_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlDOCS_LAST_REVIEWED_DATE = DateParameter.GetParam(item.DOCS_LAST_REVIEWED_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            STUDENT_ENROLMENTData.CtrlNEW_DOCS_REQUIRED = TextParameter.GetParam(item.NEW_DOCS_REQUIRED.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_ENROLMENTData.CtrlENROLMENT_COMMENTS = TextParameter.GetParam(item.ENROLMENT_COMMENTS.Value, ParameterSourceType.Control, "", Nothing, false)
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

'Record Form STUDENT_ENROLMENT BeforeShow tail @2-07B893F9
        STUDENT_ENROLMENTParameters()
        STUDENT_ENROLMENTData.FillItem(item, IsInsertMode)
        STUDENT_ENROLMENTHolder.DataBind()
        STUDENT_ENROLMENTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_ENROLMENTOperations.AllowInsert
        STUDENT_ENROLMENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_ENROLMENTOperations.AllowUpdate
        STUDENT_ENROLMENTSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTENROLMENT_DATE.Text=item.ENROLMENT_DATE.GetFormattedValue()
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEName = "STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE"
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATEDateControl = STUDENT_ENROLMENTENROLMENT_DATE.ClientID
        STUDENT_ENROLMENTDatePicker_ENROLMENT_DATE.DataBind()
        STUDENT_ENROLMENTWITHDRAWAL_DATE.Text=item.WITHDRAWAL_DATE.GetFormattedValue()
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEName = "STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE"
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATEDateControl = STUDENT_ENROLMENTWITHDRAWAL_DATE.ClientID
        STUDENT_ENROLMENTDatePicker_WITHDRAWAL_DATE.DataBind()
        STUDENT_ENROLMENTENROLMENT_STATUS.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTENROLMENT_STATUS.Items(0).Selected = True
        item.ENROLMENT_STATUSItems.SetSelection(item.ENROLMENT_STATUS.GetFormattedValue())
        If Not item.ENROLMENT_STATUSItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTENROLMENT_STATUS.SelectedIndex = -1
        End If
        item.ENROLMENT_STATUSItems.CopyTo(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items(0).Selected = True
        item.WITHDRAWAL_REASON_IDItems.SetSelection(item.WITHDRAWAL_REASON_ID.GetFormattedValue())
        If Not item.WITHDRAWAL_REASON_IDItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.SelectedIndex = -1
        End If
        item.WITHDRAWAL_REASON_IDItems.CopyTo(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items)
        STUDENT_ENROLMENTYEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        STUDENT_ENROLMENTYEAR_LEVEL.Items(0).Selected = True
        item.YEAR_LEVELItems.SetSelection(item.YEAR_LEVEL.GetFormattedValue())
        If Not item.YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            STUDENT_ENROLMENTYEAR_LEVEL.SelectedIndex = -1
        End If
        item.YEAR_LEVELItems.CopyTo(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        STUDENT_ENROLMENTENROLMENT_YEAR.Text = Server.HtmlEncode(item.ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.CAMPUSItems.SetSelection(item.CAMPUS.GetFormattedValue())
        STUDENT_ENROLMENTCAMPUS.SelectedIndex = -1
        item.CAMPUSItems.CopyTo(STUDENT_ENROLMENTCAMPUS.Items)
        STUDENT_ENROLMENTRECEIPT_NO.Text=item.RECEIPT_NO.GetFormattedValue()
        item.ELIGIBLE_FOR_DISCOUNTItems.SetSelection(item.ELIGIBLE_FOR_DISCOUNT.GetFormattedValue())
        STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.SelectedIndex = -1
        item.ELIGIBLE_FOR_DISCOUNTItems.CopyTo(STUDENT_ENROLMENTELIGIBLE_FOR_DISCOUNT.Items)
        item.PAID_ON_ENROLMENTItems.SetSelection(item.PAID_ON_ENROLMENT.GetFormattedValue())
        STUDENT_ENROLMENTPAID_ON_ENROLMENT.SelectedIndex = -1
        item.PAID_ON_ENROLMENTItems.CopyTo(STUDENT_ENROLMENTPAID_ON_ENROLMENT.Items)
        item.FULL_TIME_STUDENTItems.SetSelection(item.FULL_TIME_STUDENT.GetFormattedValue())
        STUDENT_ENROLMENTFULL_TIME_STUDENT.SelectedIndex = -1
        item.FULL_TIME_STUDENTItems.CopyTo(STUDENT_ENROLMENTFULL_TIME_STUDENT.Items)
        item.OS_FULL_FEE_PAYINGItems.SetSelection(item.OS_FULL_FEE_PAYING.GetFormattedValue())
        STUDENT_ENROLMENTOS_FULL_FEE_PAYING.SelectedIndex = -1
        item.OS_FULL_FEE_PAYINGItems.CopyTo(STUDENT_ENROLMENTOS_FULL_FEE_PAYING.Items)
        item.ADDRESS_REVIEW_FLAGItems.SetSelection(item.ADDRESS_REVIEW_FLAG.GetFormattedValue())
        STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.SelectedIndex = -1
        item.ADDRESS_REVIEW_FLAGItems.CopyTo(STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.Items)
        item.ELIGIBLE_FOR_FUNDINGItems.SetSelection(item.ELIGIBLE_FOR_FUNDING.GetFormattedValue())
        STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.SelectedIndex = -1
        item.ELIGIBLE_FOR_FUNDINGItems.CopyTo(STUDENT_ENROLMENTELIGIBLE_FOR_FUNDING.Items)
        STUDENT_ENROLMENTVCE_CANDIDATE_NO.Text=item.VCE_CANDIDATE_NO.GetFormattedValue()
        STUDENT_ENROLMENTBULLETIN_NO.Text=item.BULLETIN_NO.GetFormattedValue()
        STUDENT_ENROLMENTSUB_SCHOOL.Text=item.SUB_SCHOOL.GetFormattedValue()
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
        STUDENT_ENROLMENTENROLMENT_COMMENTS.Text=item.ENROLMENT_COMMENTS.GetFormattedValue()
        STUDENT_ENROLMENTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_ENROLMENTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STUDENT_ENROLMENT BeforeShow tail

'Record Form STUDENT_ENROLMENT Show method tail @2-ECC726FD
        If STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_ENROLMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT Show method tail

'Record Form STUDENT_ENROLMENT LoadItemFromRequest method @2-8296BFC1

    Protected Sub STUDENT_ENROLMENTLoadItemFromRequest(item As STUDENT_ENROLMENTItem, ByVal EnableValidation As Boolean)
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
        item.ENROLMENT_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_STATUS.UniqueID))
        item.ENROLMENT_STATUS.SetValue(STUDENT_ENROLMENTENROLMENT_STATUS.Value)
        item.ENROLMENT_STATUSItems.CopyFrom(STUDENT_ENROLMENTENROLMENT_STATUS.Items)
        Try
        item.WITHDRAWAL_REASON_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.UniqueID))
        item.WITHDRAWAL_REASON_ID.SetValue(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Value)
        item.WITHDRAWAL_REASON_IDItems.CopyFrom(STUDENT_ENROLMENTWITHDRAWAL_REASON_ID.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("WITHDRAWAL_REASON_ID",String.Format(Resources.strings.CCS_IncorrectValue,"WITHDRAWAL REASON ID"))
        End Try
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTYEAR_LEVEL.UniqueID))
        item.YEAR_LEVEL.SetValue(STUDENT_ENROLMENTYEAR_LEVEL.Value)
        item.YEAR_LEVELItems.CopyFrom(STUDENT_ENROLMENTYEAR_LEVEL.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.CAMPUS.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTCAMPUS.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTCAMPUS.SelectedItem) Then
            item.CAMPUS.SetValue(STUDENT_ENROLMENTCAMPUS.SelectedItem.Value)
        Else
            item.CAMPUS.Value = Nothing
        End If
        item.CAMPUSItems.CopyFrom(STUDENT_ENROLMENTCAMPUS.Items)
        item.RECEIPT_NO.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTRECEIPT_NO.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTRECEIPT_NO") Is Nothing Then
            item.RECEIPT_NO.SetValue(STUDENT_ENROLMENTRECEIPT_NO.Text)
        Else
            item.RECEIPT_NO.SetValue(ControlCustomValues("STUDENT_ENROLMENTRECEIPT_NO"))
        End If
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
        item.FULL_TIME_STUDENT.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTFULL_TIME_STUDENT.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTFULL_TIME_STUDENT.SelectedItem) Then
            item.FULL_TIME_STUDENT.SetValue(STUDENT_ENROLMENTFULL_TIME_STUDENT.SelectedItem.Value)
        Else
            item.FULL_TIME_STUDENT.Value = Nothing
        End If
        item.FULL_TIME_STUDENTItems.CopyFrom(STUDENT_ENROLMENTFULL_TIME_STUDENT.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("FULL_TIME_STUDENT",String.Format(Resources.strings.CCS_IncorrectValue,"FULL_TIME_STUDENT"))
        End Try
        Try
        item.OS_FULL_FEE_PAYING.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTOS_FULL_FEE_PAYING.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTOS_FULL_FEE_PAYING.SelectedItem) Then
            item.OS_FULL_FEE_PAYING.SetValue(STUDENT_ENROLMENTOS_FULL_FEE_PAYING.SelectedItem.Value)
        Else
            item.OS_FULL_FEE_PAYING.Value = Nothing
        End If
        item.OS_FULL_FEE_PAYINGItems.CopyFrom(STUDENT_ENROLMENTOS_FULL_FEE_PAYING.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("OS_FULL_FEE_PAYING",String.Format(Resources.strings.CCS_IncorrectValue,"OS_FULL_FEE_PAYING"))
        End Try
        Try
        item.ADDRESS_REVIEW_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.UniqueID))
        If Not IsNothing(STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.SelectedItem) Then
            item.ADDRESS_REVIEW_FLAG.SetValue(STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.SelectedItem.Value)
        Else
            item.ADDRESS_REVIEW_FLAG.Value = Nothing
        End If
        item.ADDRESS_REVIEW_FLAGItems.CopyFrom(STUDENT_ENROLMENTADDRESS_REVIEW_FLAG.Items)
        Catch ae As ArgumentException
            STUDENT_ENROLMENTErrors.Add("ADDRESS_REVIEW_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"ADDRESS_REVIEW_FLAG"))
        End Try
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
        item.VCE_CANDIDATE_NO.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTVCE_CANDIDATE_NO.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTVCE_CANDIDATE_NO") Is Nothing Then
            item.VCE_CANDIDATE_NO.SetValue(STUDENT_ENROLMENTVCE_CANDIDATE_NO.Text)
        Else
            item.VCE_CANDIDATE_NO.SetValue(ControlCustomValues("STUDENT_ENROLMENTVCE_CANDIDATE_NO"))
        End If
        item.BULLETIN_NO.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTBULLETIN_NO.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTBULLETIN_NO") Is Nothing Then
            item.BULLETIN_NO.SetValue(STUDENT_ENROLMENTBULLETIN_NO.Text)
        Else
            item.BULLETIN_NO.SetValue(ControlCustomValues("STUDENT_ENROLMENTBULLETIN_NO"))
        End If
        item.SUB_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTSUB_SCHOOL.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTSUB_SCHOOL") Is Nothing Then
            item.SUB_SCHOOL.SetValue(STUDENT_ENROLMENTSUB_SCHOOL.Text)
        Else
            item.SUB_SCHOOL.SetValue(ControlCustomValues("STUDENT_ENROLMENTSUB_SCHOOL"))
        End If
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
        item.ENROLMENT_COMMENTS.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENTENROLMENT_COMMENTS.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENTENROLMENT_COMMENTS") Is Nothing Then
            item.ENROLMENT_COMMENTS.SetValue(STUDENT_ENROLMENTENROLMENT_COMMENTS.Text)
        Else
            item.ENROLMENT_COMMENTS.SetValue(ControlCustomValues("STUDENT_ENROLMENTENROLMENT_COMMENTS"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_ENROLMENTData)
        End If
        STUDENT_ENROLMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_ENROLMENT LoadItemFromRequest method

'Record Form STUDENT_ENROLMENT GetRedirectUrl method @2-55ADAE3F

    Protected Function GetSTUDENT_ENROLMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentSummary.aspx"
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

'Button Button_Cancel OnClick. @5-5EA24C96
    If CType(sender,Control).ID = "STUDENT_ENROLMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_ENROLMENTRedirectUrl("", "")
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

'OnInit Event Body @1-AB0FAF18
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolmentDetails_maintain_backupContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
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

