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

Namespace DECV_PROD2007.Student_Medical_maintain 'Namespace @1-EC9EAE95

'Forms Definition @1-E0F767AD
Public Class [Student_Medical_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-772199ED
    Protected STUDENT_MEDICAL_DETAILSData As STUDENT_MEDICAL_DETAILSDataProvider
    Protected STUDENT_MEDICAL_DETAILSErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_MEDICAL_DETAILSOperations As FormSupportedOperations
    Protected STUDENT_MEDICAL_DETAILSIsSubmitted As Boolean = False
    Protected STUDENT_MEDICAL_DETAILS1Data As STUDENT_MEDICAL_DETAILS1DataProvider
    Protected STUDENT_MEDICAL_DETAILS1Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_MEDICAL_DETAILS1Operations As FormSupportedOperations
    Protected STUDENT_MEDICAL_DETAILS1IsSubmitted As Boolean = False
    Protected Student_Medical_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-8FEC3A98
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_MEDICAL_DETAILSShow()
            STUDENT_MEDICAL_DETAILS1Show()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_Medical_maintain Event BeforeShow. Action Custom Code @33-73254650
    ' -------------------------
    '23-July-2015|EA| only show the Diagnosis Confirmed link if they are Wellbeing officers 'W'
    ' needs to be here so we get the e system events like the Menu page
    ' NOTE the ERAFunction_CheckUserAccessGroups is included near the bottom of this page
    '12-May-2016|EA| adjusted to use Global function instead of on each page
    'STUDENT_MEDICAL_DETAILSLink_DiagnosisConfirmed.visible = ERAFunction_CheckUserAccessGroups("W", e)
    Dim GlobalERAFunc as new GlobalERA.GlobalERAClass()
    STUDENT_MEDICAL_DETAILSLink_DiagnosisConfirmed.visible = GlobalERAFunc.CheckUserAccessGroups("W", e)
    
    ' -------------------------
'End Page Student_Medical_maintain Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_MEDICAL_DETAILS Parameters @3-A16AD540

    Protected Sub STUDENT_MEDICAL_DETAILSParameters()
        Dim item As new STUDENT_MEDICAL_DETAILSItem
        Try
            STUDENT_MEDICAL_DETAILSData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_MEDICAL_DETAILSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS Parameters

'Record Form STUDENT_MEDICAL_DETAILS Show method @3-575453CA
    Protected Sub STUDENT_MEDICAL_DETAILSShow()
        If STUDENT_MEDICAL_DETAILSOperations.None Then
            STUDENT_MEDICAL_DETAILSHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_MEDICAL_DETAILSItem = STUDENT_MEDICAL_DETAILSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_MEDICAL_DETAILSOperations.AllowRead
        item.Link_DiagnosisConfirmedHref = "Student_DiagnosisConfirmed_maintain.aspx"
        STUDENT_MEDICAL_DETAILSErrors.Add(item.errors)
        If STUDENT_MEDICAL_DETAILSErrors.Count > 0 Then
            STUDENT_MEDICAL_DETAILSShowErrors()
            Return
        End If
'End Record Form STUDENT_MEDICAL_DETAILS Show method

'Record Form STUDENT_MEDICAL_DETAILS BeforeShow tail @3-8972A071
        STUDENT_MEDICAL_DETAILSParameters()
        STUDENT_MEDICAL_DETAILSData.FillItem(item, IsInsertMode)
        STUDENT_MEDICAL_DETAILSHolder.DataBind()
        STUDENT_MEDICAL_DETAILSButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_MEDICAL_DETAILSOperations.AllowUpdate
        STUDENT_MEDICAL_DETAILSLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_MEDICAL_DETAILSLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        item.HEARINGItems.SetSelection(item.HEARING.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSHEARING.SelectedIndex = -1
        item.HEARINGItems.CopyTo(STUDENT_MEDICAL_DETAILSHEARING.Items)
        item.VISIONItems.SetSelection(item.VISION.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSVISION.SelectedIndex = -1
        item.VISIONItems.CopyTo(STUDENT_MEDICAL_DETAILSVISION.Items)
        item.ASDASPERGERSItems.SetSelection(item.ASDASPERGERS.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSASDASPERGERS.SelectedIndex = -1
        item.ASDASPERGERSItems.CopyTo(STUDENT_MEDICAL_DETAILSASDASPERGERS.Items)
        item.INTELLECTUALItems.SetSelection(item.INTELLECTUAL.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSINTELLECTUAL.SelectedIndex = -1
        item.INTELLECTUALItems.CopyTo(STUDENT_MEDICAL_DETAILSINTELLECTUAL.Items)
        item.PHYSICALItems.SetSelection(item.PHYSICAL.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSPHYSICAL.SelectedIndex = -1
        item.PHYSICALItems.CopyTo(STUDENT_MEDICAL_DETAILSPHYSICAL.Items)
        item.BEHAVIOURALItems.SetSelection(item.BEHAVIOURAL.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSBEHAVIOURAL.SelectedIndex = -1
        item.BEHAVIOURALItems.CopyTo(STUDENT_MEDICAL_DETAILSBEHAVIOURAL.Items)
        item.LANGUAGEItems.SetSelection(item.LANGUAGE.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSLANGUAGE.SelectedIndex = -1
        item.LANGUAGEItems.CopyTo(STUDENT_MEDICAL_DETAILSLANGUAGE.Items)
        item.HASALLERGYHISTORYItems.SetSelection(item.HASALLERGYHISTORY.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.SelectedIndex = -1
        item.HASALLERGYHISTORYItems.CopyTo(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.Items)
        item.ANAPHYLAXISItems.SetSelection(item.ANAPHYLAXIS.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSANAPHYLAXIS.SelectedIndex = -1
        item.ANAPHYLAXISItems.CopyTo(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.Items)
        item.HASOTHERCONDITIONSItems.SetSelection(item.HASOTHERCONDITIONS.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.SelectedIndex = -1
        item.HASOTHERCONDITIONSItems.CopyTo(STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.Items)
        STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES.Text=item.OTHERMEDICALISSUES.GetFormattedValue()
        STUDENT_MEDICAL_DETAILSALLERGYHISTORY.Text=item.ALLERGYHISTORY.GetFormattedValue()
        STUDENT_MEDICAL_DETAILSOTHERCONDITIONS.Text=item.OTHERCONDITIONS.GetFormattedValue()
        item.MENTALHEALTHItems.SetSelection(item.MENTALHEALTH.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSMENTALHEALTH.SelectedIndex = -1
        item.MENTALHEALTHItems.CopyTo(STUDENT_MEDICAL_DETAILSMENTALHEALTH.Items)
        STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY.Text=item.MENTALHEALTH_HISTORY.GetFormattedValue()
        STUDENT_MEDICAL_DETAILShidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.Value = item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("cbPSD_FUNDING_CATEGORY")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("cbPSD_FUNDING_CATEGORY").GetUpperBound(0)
                item.cbPSD_FUNDING_CATEGORYItems.SetSelection(Request.QueryString.GetValues("cbPSD_FUNDING_CATEGORY")(i))
            Next i
        End If
        item.cbPSD_FUNDING_CATEGORYItems.SetSelection(item.cbPSD_FUNDING_CATEGORY.Value)
        STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.SelectedIndex = -1
        item.cbPSD_FUNDING_CATEGORYItems.CopyTo(STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.Items)
        STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER.Text=item.PSD_FUNDING_OTHER.GetFormattedValue()
        item.PSD_FUNDING_ELIGIBLEItems.SetSelection(item.PSD_FUNDING_ELIGIBLE.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.SelectedIndex = -1
        item.PSD_FUNDING_ELIGIBLEItems.CopyTo(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.Items)
        STUDENT_MEDICAL_DETAILShidden_PSD_FUNDING_CATEGORY.Value = item.hidden_PSD_FUNDING_CATEGORY.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("cbRECEIVED_SUPPORT_PROGRAMS_SERVICES")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("cbRECEIVED_SUPPORT_PROGRAMS_SERVICES").GetUpperBound(0)
                item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.SetSelection(Request.QueryString.GetValues("cbRECEIVED_SUPPORT_PROGRAMS_SERVICES")(i))
            Next i
        End If
        item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.SetSelection(item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Value)
        STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.SelectedIndex = -1
        item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.CopyTo(STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Items)
        STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.Text=item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.GetFormattedValue()
        item.ALLERGIES_FLAGItems.SetSelection(item.ALLERGIES_FLAG.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.SelectedIndex = -1
        item.ALLERGIES_FLAGItems.CopyTo(STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.Items)
        item.ANAPHYLAXIS_FLAGItems.SetSelection(item.ANAPHYLAXIS_FLAG.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.SelectedIndex = -1
        item.ANAPHYLAXIS_FLAGItems.CopyTo(STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.Items)
        STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Items.Add(new ListItem("Select Value",""))
        STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Items(0).Selected = True
        item.lbDiagnosedConditionsItems.SetSelection(item.lbDiagnosedConditions.GetFormattedValue())
        If Not item.lbDiagnosedConditionsItems.GetSelectedItem() Is Nothing Then
            STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.SelectedIndex = -1
        End If
        item.lbDiagnosedConditionsItems.CopyTo(STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Items)
        STUDENT_MEDICAL_DETAILSSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_MEDICAL_DETAILSLink_DiagnosisConfirmed.InnerText += item.Link_DiagnosisConfirmed.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_MEDICAL_DETAILSLink_DiagnosisConfirmed.HRef = item.Link_DiagnosisConfirmedHref+item.Link_DiagnosisConfirmedHrefParameters.ToString("GET","", ViewState)
        item.DIAGNOSED_ASTHMAItems.SetSelection(item.DIAGNOSED_ASTHMA.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.SelectedIndex = -1
        item.DIAGNOSED_ASTHMAItems.CopyTo(STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.Items)
        item.MANAGE_PLAN_ASTHMAItems.SetSelection(item.MANAGE_PLAN_ASTHMA.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.SelectedIndex = -1
        item.MANAGE_PLAN_ASTHMAItems.CopyTo(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.Items)
        item.DIAGNOSED_DIABETESItems.SetSelection(item.DIAGNOSED_DIABETES.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.SelectedIndex = -1
        item.DIAGNOSED_DIABETESItems.CopyTo(STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.Items)
        item.MANAGE_PLAN_DIABETESItems.SetSelection(item.MANAGE_PLAN_DIABETES.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.SelectedIndex = -1
        item.MANAGE_PLAN_DIABETESItems.CopyTo(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.Items)
        item.DIAGNOSED_EPILEPSYItems.SetSelection(item.DIAGNOSED_EPILEPSY.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.SelectedIndex = -1
        item.DIAGNOSED_EPILEPSYItems.CopyTo(STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.Items)
        item.MANAGE_PLAN_EPILEPSYItems.SetSelection(item.MANAGE_PLAN_EPILEPSY.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.SelectedIndex = -1
        item.MANAGE_PLAN_EPILEPSYItems.CopyTo(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.Items)
        item.PSD_FUNDING_LEVELItems.SetSelection(item.PSD_FUNDING_LEVEL.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.SelectedIndex = -1
        item.PSD_FUNDING_LEVELItems.CopyTo(STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.Items)
        item.PSD_FUNDING_ASSESSEDItems.SetSelection(item.PSD_FUNDING_ASSESSED.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.SelectedIndex = -1
        item.PSD_FUNDING_ASSESSEDItems.CopyTo(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.Items)
        item.NCCD_FUNDING_ELIGIBLEItems.SetSelection(item.NCCD_FUNDING_ELIGIBLE.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.SelectedIndex = -1
        item.NCCD_FUNDING_ELIGIBLEItems.CopyTo(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.Items)
        item.NCCD_FUNDING_CATEGORYItems.SetSelection(item.NCCD_FUNDING_CATEGORY.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.SelectedIndex = -1
        item.NCCD_FUNDING_CATEGORYItems.CopyTo(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.Items)
        item.NCCD_FUNDING_LEVELItems.SetSelection(item.NCCD_FUNDING_LEVEL.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.SelectedIndex = -1
        item.NCCD_FUNDING_LEVELItems.CopyTo(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.Items)
        item.DI_ASSESSEDItems.SetSelection(item.DI_ASSESSED.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSDI_ASSESSED.SelectedIndex = -1
        item.DI_ASSESSEDItems.CopyTo(STUDENT_MEDICAL_DETAILSDI_ASSESSED.Items)
        item.DI_APPROVEDItems.SetSelection(item.DI_APPROVED.GetFormattedValue())
        STUDENT_MEDICAL_DETAILSDI_APPROVED.SelectedIndex = -1
        item.DI_APPROVEDItems.CopyTo(STUDENT_MEDICAL_DETAILSDI_APPROVED.Items)
'End Record Form STUDENT_MEDICAL_DETAILS BeforeShow tail

'Hidden hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @25-F74012BA
            STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES Event BeforeShow. Action Retrieve Value for Control @101-F74012BA
            STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES Event BeforeShow. Action Retrieve Value for Control

'Hidden hidden_PSD_FUNDING_CATEGORY Event BeforeShow. Action Retrieve Value for Control @117-F74012BA
            STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden hidden_PSD_FUNDING_CATEGORY Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code @96-73254650
    ' -------------------------
    ' change layout 
	STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.RepeatColumns = 2
	STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code @99-73254650
    ' -------------------------
    ' Oct 2018|EA| add new fields for 2019 Enrolment
    ' Received Support Programs checkbox list
	if (item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.Value <> "0,") then
		' split up the string into an array
		Dim checkItemsPQ As String() = item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemPQ As String = ""

		For Each thisItemPQ In checkItemsPQ
			' set that item as checked
			item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.SetSelection(thisItemPQ)
		Next

		' and display
		STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Items.Clear()
    	item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.CopyTo(STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Items)
	end if
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code @119-73254650
    ' -------------------------
    ' change layout 
	STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.RepeatColumns = 3
	STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.RepeatLayout = RepeatLayout.Table

    STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.RepeatColumns = 2
	STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.RepeatDirection = RepeatDirection.Vertical
    STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.RepeatLayout = RepeatLayout.Table
    
    '25-Oct-2018|EA| add new fields for 2019 Enrolment
    ' PSD_FUNDING_CATEGORY checkbox list
	if (item.hidden_PSD_FUNDING_CATEGORY.Value <> "0,") then
		' split up the string into an array
		Dim checkItemsPSD As String() = item.hidden_PSD_FUNDING_CATEGORY.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemPSD As String = ""

		For Each thisItemPSD In checkItemsPSD
			' set that item as checked
			item.cbPSD_FUNDING_CATEGORYItems.SetSelection(thisItemPSD)
		Next

		' and display
		STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.Items.Clear()
    	item.cbPSD_FUNDING_CATEGORYItems.CopyTo(STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.Items)
	end if
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeShow. Action Custom Code

'Record Form STUDENT_MEDICAL_DETAILS Show method tail @3-9D762FB1
        If STUDENT_MEDICAL_DETAILSErrors.Count > 0 Then
            STUDENT_MEDICAL_DETAILSShowErrors()
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS Show method tail

'Record Form STUDENT_MEDICAL_DETAILS LoadItemFromRequest method @3-D54F8236

    Protected Sub STUDENT_MEDICAL_DETAILSLoadItemFromRequest(item As STUDENT_MEDICAL_DETAILSItem, ByVal EnableValidation As Boolean)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(STUDENT_MEDICAL_DETAILShidden_STUDENT_ID.Value)
        Try
        item.HEARING.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSHEARING.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSHEARING.SelectedItem) Then
            item.HEARING.SetValue(STUDENT_MEDICAL_DETAILSHEARING.SelectedItem.Value)
        Else
            item.HEARING.Value = Nothing
        End If
        item.HEARINGItems.CopyFrom(STUDENT_MEDICAL_DETAILSHEARING.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("HEARING",String.Format(Resources.strings.CCS_IncorrectValue,"Deaf or Hearing Impaired"))
        End Try
        Try
        item.VISION.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSVISION.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSVISION.SelectedItem) Then
            item.VISION.SetValue(STUDENT_MEDICAL_DETAILSVISION.SelectedItem.Value)
        Else
            item.VISION.Value = Nothing
        End If
        item.VISIONItems.CopyFrom(STUDENT_MEDICAL_DETAILSVISION.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("VISION",String.Format(Resources.strings.CCS_IncorrectValue,"Blind or Vision Impaired"))
        End Try
        Try
        item.ASDASPERGERS.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSASDASPERGERS.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSASDASPERGERS.SelectedItem) Then
            item.ASDASPERGERS.SetValue(STUDENT_MEDICAL_DETAILSASDASPERGERS.SelectedItem.Value)
        Else
            item.ASDASPERGERS.Value = Nothing
        End If
        item.ASDASPERGERSItems.CopyFrom(STUDENT_MEDICAL_DETAILSASDASPERGERS.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("ASDASPERGERS",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed with ASD/Aspergers"))
        End Try
        Try
        item.INTELLECTUAL.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSINTELLECTUAL.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSINTELLECTUAL.SelectedItem) Then
            item.INTELLECTUAL.SetValue(STUDENT_MEDICAL_DETAILSINTELLECTUAL.SelectedItem.Value)
        Else
            item.INTELLECTUAL.Value = Nothing
        End If
        item.INTELLECTUALItems.CopyFrom(STUDENT_MEDICAL_DETAILSINTELLECTUAL.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("INTELLECTUAL",String.Format(Resources.strings.CCS_IncorrectValue,"Intellectual Disability"))
        End Try
        Try
        item.PHYSICAL.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSPHYSICAL.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSPHYSICAL.SelectedItem) Then
            item.PHYSICAL.SetValue(STUDENT_MEDICAL_DETAILSPHYSICAL.SelectedItem.Value)
        Else
            item.PHYSICAL.Value = Nothing
        End If
        item.PHYSICALItems.CopyFrom(STUDENT_MEDICAL_DETAILSPHYSICAL.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("PHYSICAL",String.Format(Resources.strings.CCS_IncorrectValue,"Physical Disability"))
        End Try
        Try
        item.BEHAVIOURAL.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSBEHAVIOURAL.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSBEHAVIOURAL.SelectedItem) Then
            item.BEHAVIOURAL.SetValue(STUDENT_MEDICAL_DETAILSBEHAVIOURAL.SelectedItem.Value)
        Else
            item.BEHAVIOURAL.Value = Nothing
        End If
        item.BEHAVIOURALItems.CopyFrom(STUDENT_MEDICAL_DETAILSBEHAVIOURAL.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("BEHAVIOURAL",String.Format(Resources.strings.CCS_IncorrectValue,"Severe Behavioural Disorder"))
        End Try
        Try
        item.LANGUAGE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSLANGUAGE.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSLANGUAGE.SelectedItem) Then
            item.LANGUAGE.SetValue(STUDENT_MEDICAL_DETAILSLANGUAGE.SelectedItem.Value)
        Else
            item.LANGUAGE.Value = Nothing
        End If
        item.LANGUAGEItems.CopyFrom(STUDENT_MEDICAL_DETAILSLANGUAGE.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("LANGUAGE",String.Format(Resources.strings.CCS_IncorrectValue,"Severe Language Disorder"))
        End Try
        Try
        item.HASALLERGYHISTORY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.SelectedItem) Then
            item.HASALLERGYHISTORY.SetValue(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.SelectedItem.Value)
        Else
            item.HASALLERGYHISTORY.Value = Nothing
        End If
        item.HASALLERGYHISTORYItems.CopyFrom(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("HASALLERGYHISTORY",String.Format(Resources.strings.CCS_IncorrectValue,"History of Allergies"))
        End Try
        Try
        item.ANAPHYLAXIS.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.SelectedItem) Then
            item.ANAPHYLAXIS.SetValue(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.SelectedItem.Value)
        Else
            item.ANAPHYLAXIS.Value = Nothing
        End If
        item.ANAPHYLAXISItems.CopyFrom(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("ANAPHYLAXIS",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed at Risk of Anaphylaxis"))
        End Try
        Try
        item.HASOTHERCONDITIONS.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.SelectedItem) Then
            item.HASOTHERCONDITIONS.SetValue(STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.SelectedItem.Value)
        Else
            item.HASOTHERCONDITIONS.Value = Nothing
        End If
        item.HASOTHERCONDITIONSItems.CopyFrom(STUDENT_MEDICAL_DETAILSHASOTHERCONDITIONS.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("HASOTHERCONDITIONS",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed with any other condition"))
        End Try
        item.OTHERMEDICALISSUES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES") Is Nothing Then
            item.OTHERMEDICALISSUES.SetValue(STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES.Text)
        Else
            item.OTHERMEDICALISSUES.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSOTHERMEDICALISSUES"))
        End If
        item.ALLERGYHISTORY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSALLERGYHISTORY.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSALLERGYHISTORY") Is Nothing Then
            item.ALLERGYHISTORY.SetValue(STUDENT_MEDICAL_DETAILSALLERGYHISTORY.Text)
        Else
            item.ALLERGYHISTORY.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSALLERGYHISTORY"))
        End If
        item.OTHERCONDITIONS.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSOTHERCONDITIONS.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSOTHERCONDITIONS") Is Nothing Then
            item.OTHERCONDITIONS.SetValue(STUDENT_MEDICAL_DETAILSOTHERCONDITIONS.Text)
        Else
            item.OTHERCONDITIONS.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSOTHERCONDITIONS"))
        End If
        Try
        item.MENTALHEALTH.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSMENTALHEALTH.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSMENTALHEALTH.SelectedItem) Then
            item.MENTALHEALTH.SetValue(STUDENT_MEDICAL_DETAILSMENTALHEALTH.SelectedItem.Value)
        Else
            item.MENTALHEALTH.Value = Nothing
        End If
        item.MENTALHEALTHItems.CopyFrom(STUDENT_MEDICAL_DETAILSMENTALHEALTH.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("MENTALHEALTH",String.Format(Resources.strings.CCS_IncorrectValue,"Mental Health Condition?"))
        End Try
        item.MENTALHEALTH_HISTORY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY") Is Nothing Then
            item.MENTALHEALTH_HISTORY.SetValue(STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY.Text)
        Else
            item.MENTALHEALTH_HISTORY.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSMENTALHEALTH_HISTORY"))
        End If
        item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILShidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.UniqueID))
        item.hidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.SetValue(STUDENT_MEDICAL_DETAILShidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.Value)
        If Not IsNothing(STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.SelectedItem) Then
            item.cbPSD_FUNDING_CATEGORY.SetValue(STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.SelectedItem.Value)
        Else
            item.cbPSD_FUNDING_CATEGORY.Value = Nothing
        End If
        item.cbPSD_FUNDING_CATEGORYItems.CopyFrom(STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.Items)
        item.PSD_FUNDING_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER") Is Nothing Then
            item.PSD_FUNDING_OTHER.SetValue(STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER.Text)
        Else
            item.PSD_FUNDING_OTHER.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSPSD_FUNDING_OTHER"))
        End If
        Try
        item.PSD_FUNDING_ELIGIBLE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.SelectedItem) Then
            item.PSD_FUNDING_ELIGIBLE.SetValue(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.SelectedItem.Value)
        Else
            item.PSD_FUNDING_ELIGIBLE.Value = Nothing
        End If
        item.PSD_FUNDING_ELIGIBLEItems.CopyFrom(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("PSD_FUNDING_ELIGIBLE",String.Format(Resources.strings.CCS_IncorrectValue,"PSD Eligibility (Approved by DET)"))
        End Try
        item.hidden_PSD_FUNDING_CATEGORY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILShidden_PSD_FUNDING_CATEGORY.UniqueID))
        item.hidden_PSD_FUNDING_CATEGORY.SetValue(STUDENT_MEDICAL_DETAILShidden_PSD_FUNDING_CATEGORY.Value)
        If Not IsNothing(STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.SelectedItem) Then
            item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICES.SetValue(STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.SelectedItem.Value)
        Else
            item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Value = Nothing
        End If
        item.cbRECEIVED_SUPPORT_PROGRAMS_SERVICESItems.CopyFrom(STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Items)
        item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER") Is Nothing Then
            item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.SetValue(STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.Text)
        Else
            item.RECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILSRECEIVED_SUPPORT_PROGRAMS_SERVICES_OTHER"))
        End If
        item.ALLERGIES_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.SelectedItem) Then
            item.ALLERGIES_FLAG.SetValue(STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.SelectedItem.Value)
        Else
            item.ALLERGIES_FLAG.Value = Nothing
        End If
        item.ALLERGIES_FLAGItems.CopyFrom(STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.Items)
        item.ANAPHYLAXIS_FLAG.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.SelectedItem) Then
            item.ANAPHYLAXIS_FLAG.SetValue(STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.SelectedItem.Value)
        Else
            item.ANAPHYLAXIS_FLAG.Value = Nothing
        End If
        item.ANAPHYLAXIS_FLAGItems.CopyFrom(STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.Items)
        item.lbDiagnosedConditions.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.UniqueID))
        item.lbDiagnosedConditions.SetValue(STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Value)
        item.lbDiagnosedConditionsItems.CopyFrom(STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Items)
        Try
        item.DIAGNOSED_ASTHMA.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.SelectedItem) Then
            item.DIAGNOSED_ASTHMA.SetValue(STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.SelectedItem.Value)
        Else
            item.DIAGNOSED_ASTHMA.Value = Nothing
        End If
        item.DIAGNOSED_ASTHMAItems.CopyFrom(STUDENT_MEDICAL_DETAILSDIAGNOSED_ASTHMA.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("DIAGNOSED_ASTHMA",String.Format(Resources.strings.CCS_IncorrectValue,"Student Diagnosed with Asthma"))
        End Try
        Try
        item.MANAGE_PLAN_ASTHMA.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.SelectedItem) Then
            item.MANAGE_PLAN_ASTHMA.SetValue(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.SelectedItem.Value)
        Else
            item.MANAGE_PLAN_ASTHMA.Value = Nothing
        End If
        item.MANAGE_PLAN_ASTHMAItems.CopyFrom(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_ASTHMA.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("MANAGE_PLAN_ASTHMA",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed Asthma - Management Plan?"))
        End Try
        Try
        item.DIAGNOSED_DIABETES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.SelectedItem) Then
            item.DIAGNOSED_DIABETES.SetValue(STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.SelectedItem.Value)
        Else
            item.DIAGNOSED_DIABETES.Value = Nothing
        End If
        item.DIAGNOSED_DIABETESItems.CopyFrom(STUDENT_MEDICAL_DETAILSDIAGNOSED_DIABETES.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("DIAGNOSED_DIABETES",String.Format(Resources.strings.CCS_IncorrectValue,"Student Diagnosed with Diabetes"))
        End Try
        Try
        item.MANAGE_PLAN_DIABETES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.SelectedItem) Then
            item.MANAGE_PLAN_DIABETES.SetValue(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.SelectedItem.Value)
        Else
            item.MANAGE_PLAN_DIABETES.Value = Nothing
        End If
        item.MANAGE_PLAN_DIABETESItems.CopyFrom(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_DIABETES.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("MANAGE_PLAN_DIABETES",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed Diabetes - Management Plan?"))
        End Try
        Try
        item.DIAGNOSED_EPILEPSY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.SelectedItem) Then
            item.DIAGNOSED_EPILEPSY.SetValue(STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.SelectedItem.Value)
        Else
            item.DIAGNOSED_EPILEPSY.Value = Nothing
        End If
        item.DIAGNOSED_EPILEPSYItems.CopyFrom(STUDENT_MEDICAL_DETAILSDIAGNOSED_EPILEPSY.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("DIAGNOSED_EPILEPSY",String.Format(Resources.strings.CCS_IncorrectValue,"Student Diagnosed with Epilepsy"))
        End Try
        Try
        item.MANAGE_PLAN_EPILEPSY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.SelectedItem) Then
            item.MANAGE_PLAN_EPILEPSY.SetValue(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.SelectedItem.Value)
        Else
            item.MANAGE_PLAN_EPILEPSY.Value = Nothing
        End If
        item.MANAGE_PLAN_EPILEPSYItems.CopyFrom(STUDENT_MEDICAL_DETAILSMANAGE_PLAN_EPILEPSY.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("MANAGE_PLAN_EPILEPSY",String.Format(Resources.strings.CCS_IncorrectValue,"Diagnosed Epilepsy - Management Plan?"))
        End Try
        item.PSD_FUNDING_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.SelectedItem) Then
            item.PSD_FUNDING_LEVEL.SetValue(STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.SelectedItem.Value)
        Else
            item.PSD_FUNDING_LEVEL.Value = Nothing
        End If
        item.PSD_FUNDING_LEVELItems.CopyFrom(STUDENT_MEDICAL_DETAILSPSD_FUNDING_LEVEL.Items)
        Try
        item.PSD_FUNDING_ASSESSED.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.SelectedItem) Then
            item.PSD_FUNDING_ASSESSED.SetValue(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.SelectedItem.Value)
        Else
            item.PSD_FUNDING_ASSESSED.Value = Nothing
        End If
        item.PSD_FUNDING_ASSESSEDItems.CopyFrom(STUDENT_MEDICAL_DETAILSPSD_FUNDING_ASSESSED.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("PSD_FUNDING_ASSESSED",String.Format(Resources.strings.CCS_IncorrectValue,"PSD Eligibility (Assessed by DET)"))
        End Try
        Try
        item.NCCD_FUNDING_ELIGIBLE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.SelectedItem) Then
            item.NCCD_FUNDING_ELIGIBLE.SetValue(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.SelectedItem.Value)
        Else
            item.NCCD_FUNDING_ELIGIBLE.Value = Nothing
        End If
        item.NCCD_FUNDING_ELIGIBLEItems.CopyFrom(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("NCCD_FUNDING_ELIGIBLE",String.Format(Resources.strings.CCS_IncorrectValue,"NCCD Eligibility"))
        End Try
        Try
        item.NCCD_FUNDING_CATEGORY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.SelectedItem) Then
            item.NCCD_FUNDING_CATEGORY.SetValue(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.SelectedItem.Value)
        Else
            item.NCCD_FUNDING_CATEGORY.Value = Nothing
        End If
        item.NCCD_FUNDING_CATEGORYItems.CopyFrom(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_CATEGORY.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("NCCD_FUNDING_CATEGORY",String.Format(Resources.strings.CCS_IncorrectValue,"NCCD Category"))
        End Try
        Try
        item.NCCD_FUNDING_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.SelectedItem) Then
            item.NCCD_FUNDING_LEVEL.SetValue(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.SelectedItem.Value)
        Else
            item.NCCD_FUNDING_LEVEL.Value = Nothing
        End If
        item.NCCD_FUNDING_LEVELItems.CopyFrom(STUDENT_MEDICAL_DETAILSNCCD_FUNDING_LEVEL.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("NCCD_FUNDING_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"Level of NCCD funding approved"))
        End Try
        Try
        item.DI_ASSESSED.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSDI_ASSESSED.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSDI_ASSESSED.SelectedItem) Then
            item.DI_ASSESSED.SetValue(STUDENT_MEDICAL_DETAILSDI_ASSESSED.SelectedItem.Value)
        Else
            item.DI_ASSESSED.Value = Nothing
        End If
        item.DI_ASSESSEDItems.CopyFrom(STUDENT_MEDICAL_DETAILSDI_ASSESSED.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("DI_ASSESSED",String.Format(Resources.strings.CCS_IncorrectValue,"DI ASSESSED"))
        End Try
        Try
        item.DI_APPROVED.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILSDI_APPROVED.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILSDI_APPROVED.SelectedItem) Then
            item.DI_APPROVED.SetValue(STUDENT_MEDICAL_DETAILSDI_APPROVED.SelectedItem.Value)
        Else
            item.DI_APPROVED.Value = Nothing
        End If
        item.DI_APPROVEDItems.CopyFrom(STUDENT_MEDICAL_DETAILSDI_APPROVED.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILSErrors.Add("DI_APPROVED",String.Format(Resources.strings.CCS_IncorrectValue,"DI PPROVED"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_MEDICAL_DETAILSData)
        End If
        STUDENT_MEDICAL_DETAILSErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS LoadItemFromRequest method

'Record Form STUDENT_MEDICAL_DETAILS GetRedirectUrl method @3-5F14727D

    Protected Function GetSTUDENT_MEDICAL_DETAILSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_MEDICAL_DETAILS GetRedirectUrl method

'Record Form STUDENT_MEDICAL_DETAILS ShowErrors method @3-8629DBF4

    Protected Sub STUDENT_MEDICAL_DETAILSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_MEDICAL_DETAILSErrors.Count - 1
        Select Case STUDENT_MEDICAL_DETAILSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_MEDICAL_DETAILSErrors(i)
        End Select
        Next i
        STUDENT_MEDICAL_DETAILSError.Visible = True
        STUDENT_MEDICAL_DETAILSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS ShowErrors method

'Record Form STUDENT_MEDICAL_DETAILS Insert Operation @3-35140A64

    Protected Sub STUDENT_MEDICAL_DETAILS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILSItem = New STUDENT_MEDICAL_DETAILSItem()
        STUDENT_MEDICAL_DETAILSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_MEDICAL_DETAILS Insert Operation

'Record Form STUDENT_MEDICAL_DETAILS BeforeInsert tail @3-D16751BD
    STUDENT_MEDICAL_DETAILSParameters()
    STUDENT_MEDICAL_DETAILSLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_MEDICAL_DETAILS BeforeInsert tail

'Record Form STUDENT_MEDICAL_DETAILS AfterInsert tail  @3-C28C4677
        ErrorFlag=(STUDENT_MEDICAL_DETAILSErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS AfterInsert tail 

'Record Form STUDENT_MEDICAL_DETAILS Update Operation @3-1398EAEE

    Protected Sub STUDENT_MEDICAL_DETAILS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILSItem = New STUDENT_MEDICAL_DETAILSItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_MEDICAL_DETAILSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_MEDICAL_DETAILS Update Operation

'Button Button_Update OnClick. @121-C48E3F58
        If CType(sender,Control).ID = "STUDENT_MEDICAL_DETAILSButton_Update" Then
            RedirectUrl = GetSTUDENT_MEDICAL_DETAILSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @121-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Retrieve Value for Control @18-18C039D5
        STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserId.ToUpper()))).GetFormattedValue()
'End Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Retrieve Value for Control @20-7C879D00
        STUDENT_MEDICAL_DETAILShidden_LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code @47-73254650
    ' -------------------------
    '17-Sept-2015|EA|bunch of reports rely on the 'old' Allergy_flag, Anaphylaxis_flag, and lbDiagnosedCondition
    ' so will need to update those fields when the new 2016 fields are changed
    STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.SelectedIndex = -1
    If Not IsNothing(STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.SelectedItem) Then
    	If (STUDENT_MEDICAL_DETAILSHASALLERGYHISTORY.SelectedItem.Value = 1) THEN
    		STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.Items.FindByValue("Y").Selected = True
    	Else
    		STUDENT_MEDICAL_DETAILSALLERGIES_FLAG.Items.FindByValue("N").Selected = True
    	End If
    End If
    STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.SelectedIndex = -1
    If Not IsNothing(STUDENT_MEDICAL_DETAILSANAPHYLAXIS.SelectedItem) Then
	    If (STUDENT_MEDICAL_DETAILSANAPHYLAXIS.SelectedItem.Value = 1) THEN
	    	STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.Items.FindByValue("Y").Selected = True
	    Else
	    	STUDENT_MEDICAL_DETAILSANAPHYLAXIS_FLAG.Items.FindByValue("N").Selected = True
	    End If
    End If
    If Not IsNothing(STUDENT_MEDICAL_DETAILSASDASPERGERS.SelectedItem) Then
	    If (STUDENT_MEDICAL_DETAILSASDASPERGERS.SelectedItem.Value = 1) THEN
	    	STUDENT_MEDICAL_DETAILSlbDiagnosedConditions.Value = "ASD"
	    End If
    End If    
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code @102-73254650
    ' -------------------------
    'Oct-2018|EA| expanded Received Support program from 1 to 12, combine the selected array items then join to string
	Dim checkItemsPQ as String = "0,"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STUDENT_MEDICAL_DETAILScbRECEIVED_SUPPORT_PROGRAMS_SERVICES.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_MEDICAL_DETAILShidden_RECEIVED_SUPPORT_PROGRAMS_SERVICES.Value = (checkItemsPQ.TrimEnd(","C))
	
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code @118-73254650
    ' -------------------------
	'25-Oct-2018|EA| added PSD_FUNDING_CATEGORY options, combine the selected array items then join to string
	checkItemsPQ = "0,"

	For Each thisItemPQ In STUDENT_MEDICAL_DETAILScbPSD_FUNDING_CATEGORY.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_MEDICAL_DETAILShidden_PSD_FUNDING_CATEGORY.Value = (checkItemsPQ.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_MEDICAL_DETAILS Before Update tail @3-43A8EFB3
        STUDENT_MEDICAL_DETAILSParameters()
        STUDENT_MEDICAL_DETAILSLoadItemFromRequest(item, EnableValidation)
        If STUDENT_MEDICAL_DETAILSOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_MEDICAL_DETAILSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_MEDICAL_DETAILSData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_MEDICAL_DETAILSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_MEDICAL_DETAILS Before Update tail

'Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Declare Variable @95-E8BC5541
        Dim tmpProgSupport As String = ""
'End Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Declare Variable

'Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Declare Variable @108-ADF6B2A1
        Dim tmpHearVisionImpaired As String = ""
'End Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Declare Variable

'Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Custom Code @93-73254650
    ' -------------------------
     '12-Mar-2018|EA| Send email to wellbeing if Program for Student with Disability is ticked (sd #10503, unf #825)
     '16-Oct-2018|EA| added Hearing/Vision flag
     '26-Jul-2020|RW| Expand the criteria for triggering a PSD email alert as per Rob M's request
     '26-Oct-2020|RW| Rob M indicated that the emails should now only be sent for school referral PSD (and now NCCD) information
     '04-Nov-2020|RW| Rob M asked that the email alerts only be triggered for PSD or NCCD approval (and not other PSD indicators), so reversing the 26-Jul request
     '                SD #27747
    
    If ExecuteFlag And (Not ErrorFlag) Then 

      Dim hasPSDOrNCCDSupport = (STUDENT_MEDICAL_DETAILSPSD_FUNDING_ELIGIBLE.SelectedValue = "1") OrElse
                          (STUDENT_MEDICAL_DETAILSNCCD_FUNDING_ELIGIBLE.SelectedValue = "1")

		tmpHearVisionImpaired += If(STUDENT_MEDICAL_DETAILSHEARING.SelectedItem.Value = 1, " Deaf/Hearing ","")
		tmpHearVisionImpaired += If(STUDENT_MEDICAL_DETAILSVISION.SelectedItem.Value = 1, " Blind/Vision ","")
			
		if (hasPSDOrNCCDSupport OrElse tmpHearVisionImpaired <> "") Then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim wellbeingEmail = "wellbeing@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, wellbeingEmail)
          Dim studentID = Request.QueryString("STUDENT_ID")
          Dim enrolmentYear = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())

	     Dim MessageFrom As String = "pcsupport@vsv.vic.edu.au"
	     Dim MessageTo As String = emailRecipient
	     'MessageTo = "eric@eratechnology.net.au"	'debug
	     ' MessageTo = "leking@distance.vic.edu.au"	'debug
	     Dim MessageSubject As String = ""
			Dim MessageBody As String = ""
			
			if (hasPSDOrNCCDSupport) then
				MessageSubject = $"{emailTestMarker}Auto Student DB Advice - Medical - PSD or NCCD"
				MessageBody = $"{emailTestMarker}<br />This student's school referral indicates that they have received and/or are eligible for PSD and/or NCCD support funding.<br>" & _
					$"<br />Student ID : <a href='{Common.GenerateStudentMedicalPageLink(studentID, enrolmentYear)}'>{studentID}</a>" & _
					"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
					"<br /><em>Note: this may simply be a change to the Medical details form, not the PSD or NCCD selections only. You may have already been notified of this Student</em> "  & _
					"<br><br>---- that is all ----"
				
		   		Dim ThisEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
		        ThisEmail.IsBodyHtml = True
		        Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
		        EmailServer.Send(ThisEmail)
			end if
	        
	        if (tmpHearVisionImpaired <> "") then
				MessageSubject = $"{emailTestMarker}Auto Student DB Advice - Medical - "+tmpHearVisionImpaired+" Impairment"
				MessageBody = $"{emailTestMarker}<br/>This Student's Medical > options ticked for "+tmpHearVisionImpaired+" Impairment(s) to be aware of.<br>" & _
					$"<br />Student ID : <a href='{Common.GenerateStudentMedicalPageLink(studentID, enrolmentYear)}'>{studentID}</a>" & _
					"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
					"<br /><em>Note: this may simply be a change to the Medical details form, not the Hearing/Vision tickboxes only. You may have already been notified of this Student</em> "  & _
					"<br><br>---- that is all ----"
				
		   		Dim ThisEmail2 As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
		        ThisEmail2.IsBodyHtml = True
		        Dim EmailServer2 As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
		        EmailServer2.Send(ThisEmail2)
			end if
	    
		end if
	
	End If
' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Custom Code @168-73254650
    ' -------------------------
    'Sept-2019|EA| check 0 errors before showing update:
    if (STUDENT_MEDICAL_DETAILSErrors.Count = 0) then
    	HttpContext.Current.Session("notifymessage") = "Student Medical has been Updated"
    end if
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS Event AfterUpdate. Action Custom Code

'Record Form STUDENT_MEDICAL_DETAILS Update Operation tail @3-3FE1111D
        End If
        ErrorFlag=(STUDENT_MEDICAL_DETAILSErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS Update Operation tail

'Record Form STUDENT_MEDICAL_DETAILS Delete Operation @3-DD3BBE9F
    Protected Sub STUDENT_MEDICAL_DETAILS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_MEDICAL_DETAILSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_MEDICAL_DETAILSItem = New STUDENT_MEDICAL_DETAILSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_MEDICAL_DETAILS Delete Operation

'Record Form BeforeDelete tail @3-D16751BD
        STUDENT_MEDICAL_DETAILSParameters()
        STUDENT_MEDICAL_DETAILSLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-81B8FEDF
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_MEDICAL_DETAILS Cancel Operation @3-285A91F1

    Protected Sub STUDENT_MEDICAL_DETAILS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILSItem = New STUDENT_MEDICAL_DETAILSItem()
        STUDENT_MEDICAL_DETAILSIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_MEDICAL_DETAILSLoadItemFromRequest(item, False)
'End Record Form STUDENT_MEDICAL_DETAILS Cancel Operation

'Button Button_Cancel OnClick. @122-3E6A05BD
    If CType(sender,Control).ID = "STUDENT_MEDICAL_DETAILSButton_Cancel" Then
        RedirectUrl = GetSTUDENT_MEDICAL_DETAILSRedirectUrl("StudentSummary.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @122-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_MEDICAL_DETAILS Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS Cancel Operation tail

'Record Form STUDENT_MEDICAL_DETAILS1 Parameters @55-50D21BAA

    Protected Sub STUDENT_MEDICAL_DETAILS1Parameters()
        Dim item As new STUDENT_MEDICAL_DETAILS1Item
        Try
            STUDENT_MEDICAL_DETAILS1Data.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_MEDICAL_DETAILS1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 Parameters

'Record Form STUDENT_MEDICAL_DETAILS1 Show method @55-F20F662B
    Protected Sub STUDENT_MEDICAL_DETAILS1Show()
        If STUDENT_MEDICAL_DETAILS1Operations.None Then
            STUDENT_MEDICAL_DETAILS1Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_MEDICAL_DETAILS1Item = STUDENT_MEDICAL_DETAILS1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_MEDICAL_DETAILS1Operations.AllowRead
        STUDENT_MEDICAL_DETAILS1Errors.Add(item.errors)
        If STUDENT_MEDICAL_DETAILS1Errors.Count > 0 Then
            STUDENT_MEDICAL_DETAILS1ShowErrors()
            Return
        End If
'End Record Form STUDENT_MEDICAL_DETAILS1 Show method

'Record Form STUDENT_MEDICAL_DETAILS1 BeforeShow tail @55-CD63D527
        STUDENT_MEDICAL_DETAILS1Parameters()
        STUDENT_MEDICAL_DETAILS1Data.FillItem(item, IsInsertMode)
        STUDENT_MEDICAL_DETAILS1Holder.DataBind()
        STUDENT_MEDICAL_DETAILS1Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_MEDICAL_DETAILS1Operations.AllowUpdate
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION.Text=item.PRACTITIONER_ORGANISATION.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.Items.Add(new ListItem("Select Value",""))
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.Items(0).Selected = True
        item.PRACTITIONER_DISCIPLINEItems.SetSelection(item.PRACTITIONER_DISCIPLINE.GetFormattedValue())
        If Not item.PRACTITIONER_DISCIPLINEItems.GetSelectedItem() Is Nothing Then
            STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.SelectedIndex = -1
        End If
        item.PRACTITIONER_DISCIPLINEItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.Items)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER.Text=item.PRACTITIONER_DISCIPLINE_OTHER.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("PRACTITIONER_PRIMARY_ISSUES")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("PRACTITIONER_PRIMARY_ISSUES").GetUpperBound(0)
                item.PRACTITIONER_PRIMARY_ISSUESItems.SetSelection(Request.QueryString.GetValues("PRACTITIONER_PRIMARY_ISSUES")(i))
            Next i
        End If
        item.PRACTITIONER_PRIMARY_ISSUESItems.SetSelection(item.PRACTITIONER_PRIMARY_ISSUES.Value)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.SelectedIndex = -1
        item.PRACTITIONER_PRIMARY_ISSUESItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.Items)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER.Text=item.PRACTITIONER_PRIMARY_OTHER.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_BY.Value = item.PRACTITIONER_LAST_MODIFIED_BY.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_DATE.Value = item.PRACTITIONER_LAST_MODIFIED_DATE.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.Value = item.Hidden_PRIMARY_ISSUES.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1lblLAST_MODIFIED_BY.Text = Server.HtmlEncode(item.lblLAST_MODIFIED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_MEDICAL_DETAILS1lblLAST_MODIFIED_DATE.Text = Server.HtmlEncode(item.lblLAST_MODIFIED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.PRACTITIONER_ORGTYPEItems.SetSelection(item.PRACTITIONER_ORGTYPE.GetFormattedValue())
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.SelectedIndex = -1
        item.PRACTITIONER_ORGTYPEItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.Items)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER.Text=item.PRACTITIONER_ORGTYPE_OTHER.GetFormattedValue()
        STUDENT_MEDICAL_DETAILS1Hidden_DISABILITIES.Value = item.Hidden_DISABILITIES.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("PRACTITIONER_DISABILITIES")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("PRACTITIONER_DISABILITIES").GetUpperBound(0)
                item.PRACTITIONER_DISABILITIESItems.SetSelection(Request.QueryString.GetValues("PRACTITIONER_DISABILITIES")(i))
            Next i
        End If
        item.PRACTITIONER_DISABILITIESItems.SetSelection(item.PRACTITIONER_DISABILITIES.Value)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.SelectedIndex = -1
        item.PRACTITIONER_DISABILITIESItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.Items)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS.Text=item.PRACTITIONER_DISABILITY_DETAILS.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("PRACTITIONER_REC_CLASS_ATTENDANCE")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("PRACTITIONER_REC_CLASS_ATTENDANCE").GetUpperBound(0)
                item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.SetSelection(Request.QueryString.GetValues("PRACTITIONER_REC_CLASS_ATTENDANCE")(i))
            Next i
        End If
        item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.SetSelection(item.PRACTITIONER_REC_CLASS_ATTENDANCE.Value)
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.SelectedIndex = -1
        item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.Items)
        STUDENT_MEDICAL_DETAILS1Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.Value = item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.GetFormattedValue()
        item.PRACTITIONER_REC_WORKLOADItems.SetSelection(item.PRACTITIONER_REC_WORKLOAD.GetFormattedValue())
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.SelectedIndex = -1
        item.PRACTITIONER_REC_WORKLOADItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.Items)
        item.PRACTITIONER_REC_CARER_AS_SUPERVISORItems.SetSelection(item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.GetFormattedValue())
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.SelectedIndex = -1
        item.PRACTITIONER_REC_CARER_AS_SUPERVISORItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.Items)
'End Record Form STUDENT_MEDICAL_DETAILS1 BeforeShow tail

'CheckBoxList PRACTITIONER_PRIMARY_ISSUES Event BeforeShow. Action Custom Code @88-73254650
    ' -------------------------
    ' change layout 
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.RepeatColumns = 3
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End CheckBoxList PRACTITIONER_PRIMARY_ISSUES Event BeforeShow. Action Custom Code

'RadioButton PRACTITIONER_ORGTYPE Event BeforeShow. Action Custom Code @139-73254650
    ' -------------------------
    'Sept-2019|EA| change layout 
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.RepeatColumns = 4
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton PRACTITIONER_ORGTYPE Event BeforeShow. Action Custom Code

'CheckBoxList PRACTITIONER_DISABILITIES Event BeforeShow. Action Custom Code @261-73254650
    STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.RepeatColumns = 3
    STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.RepeatDirection = RepeatDirection.Horizontal
    STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.RepeatLayout = RepeatLayout.Table
'End CheckBoxList PRACTITIONER_DISABILITIES Event BeforeShow. Action Custom Code

'CheckBoxList PRACTITIONER_REC_CLASS_ATTENDANCE Event BeforeShow. Action Custom Code @259-73254650
   ' 17 Mar 2022|RW| Set class attendance recommendation layout
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.RepeatColumns = 1
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.RepeatDirection = RepeatDirection.Vertical
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.RepeatLayout = RepeatLayout.Table
'End CheckBoxList PRACTITIONER_REC_CLASS_ATTENDANCE Event BeforeShow. Action Custom Code

'RadioButton PRACTITIONER_REC_WORKLOAD Event BeforeShow. Action Custom Code @266-73254650
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.RepeatColumns = 1
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.RepeatDirection = RepeatDirection.Vertical
   STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.RepeatLayout = RepeatLayout.Table
'End RadioButton PRACTITIONER_REC_WORKLOAD Event BeforeShow. Action Custom Code


'Record STUDENT_MEDICAL_DETAILS1 Event BeforeShow. Action Custom Code @69-73254650
    ' -------------------------
    ' Oct 2016|EA| add new fields for 2017 Enrolment
    ' Primary Issues checkbox list
    
	if (item.Hidden_PRIMARY_ISSUES.Value <> "0,") then
		' split up the string into an array
		Dim checkItemsPQ As String() = item.Hidden_PRIMARY_ISSUES.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemPQ As String = ""

		For Each thisItemPQ In checkItemsPQ
			' set that item as checked
			item.PRACTITIONER_PRIMARY_ISSUESItems.SetSelection(thisItemPQ)
		Next

		' and display
		STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.Items.Clear()
    	item.PRACTITIONER_PRIMARY_ISSUESItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.Items)
	end if
	
	'16-Sep-2020|RW| Added support for disability items
	if (item.Hidden_DISABILITIES.Value <> "0,") then
		Dim checkItemsDD As String() = item.Hidden_DISABILITIES.Value.Split(New Char() {","c})
		Dim thisItemDD As String = ""

		For Each thisItemDD In checkItemsDD
			item.PRACTITIONER_DISABILITIESItems.SetSelection(thisItemDD)
		Next

		STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.Items.Clear()
    	item.PRACTITIONER_DISABILITIESItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.Items)
	end if
	
	'17 Mar 2022|RW| Added support for recommended class attendance items
	if (item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.Value <> "0,") then
		Dim checkItemsCA = item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.Value.Split(New Char() {","c})

		For Each thisItemCA In checkItemsCA
			item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.SetSelection(thisItemCA)
		Next

		STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.Items.Clear()
    	item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.CopyTo(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.Items)
	end if

    '-------------------------
'End Record STUDENT_MEDICAL_DETAILS1 Event BeforeShow. Action Custom Code


'Record Form STUDENT_MEDICAL_DETAILS1 Show method tail @55-CFCF96BC
        If STUDENT_MEDICAL_DETAILS1Errors.Count > 0 Then
            STUDENT_MEDICAL_DETAILS1ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 Show method tail

'Record Form STUDENT_MEDICAL_DETAILS1 LoadItemFromRequest method @55-5E57F00C

    Protected Sub STUDENT_MEDICAL_DETAILS1LoadItemFromRequest(item As STUDENT_MEDICAL_DETAILS1Item, ByVal EnableValidation As Boolean)
        item.PRACTITIONER_ORGANISATION.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION") Is Nothing Then
            item.PRACTITIONER_ORGANISATION.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION.Text)
        Else
            item.PRACTITIONER_ORGANISATION.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGANISATION"))
        End If
        item.PRACTITIONER_DISCIPLINE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.UniqueID))
        item.PRACTITIONER_DISCIPLINE.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.Value)
        item.PRACTITIONER_DISCIPLINEItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE.Items)
        item.PRACTITIONER_DISCIPLINE_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER") Is Nothing Then
            item.PRACTITIONER_DISCIPLINE_OTHER.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER.Text)
        Else
            item.PRACTITIONER_DISCIPLINE_OTHER.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISCIPLINE_OTHER"))
        End If
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.SelectedItem) Then
            item.PRACTITIONER_PRIMARY_ISSUES.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.SelectedItem.Value)
        Else
            item.PRACTITIONER_PRIMARY_ISSUES.Value = Nothing
        End If
        item.PRACTITIONER_PRIMARY_ISSUESItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.Items)
        item.PRACTITIONER_PRIMARY_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER") Is Nothing Then
            item.PRACTITIONER_PRIMARY_OTHER.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER.Text)
        Else
            item.PRACTITIONER_PRIMARY_OTHER.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_OTHER"))
        End If
        item.PRACTITIONER_LAST_MODIFIED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_BY.UniqueID))
        item.PRACTITIONER_LAST_MODIFIED_BY.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_BY.Value)
        Try
        item.PRACTITIONER_LAST_MODIFIED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_DATE.UniqueID))
        item.PRACTITIONER_LAST_MODIFIED_DATE.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILS1Errors.Add("PRACTITIONER_LAST_MODIFIED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"PRACTITIONER LAST MODIFIED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.Hidden_PRIMARY_ISSUES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.UniqueID))
        item.Hidden_PRIMARY_ISSUES.SetValue(STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.Value)
        item.PRACTITIONER_ORGTYPE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.SelectedItem) Then
            item.PRACTITIONER_ORGTYPE.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.SelectedItem.Value)
        Else
            item.PRACTITIONER_ORGTYPE.Value = Nothing
        End If
        item.PRACTITIONER_ORGTYPEItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE.Items)
        item.PRACTITIONER_ORGTYPE_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER") Is Nothing Then
            item.PRACTITIONER_ORGTYPE_OTHER.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER.Text)
        Else
            item.PRACTITIONER_ORGTYPE_OTHER.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_ORGTYPE_OTHER"))
        End If
        item.Hidden_DISABILITIES.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1Hidden_DISABILITIES.UniqueID))
        item.Hidden_DISABILITIES.SetValue(STUDENT_MEDICAL_DETAILS1Hidden_DISABILITIES.Value)
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.SelectedItem) Then
            item.PRACTITIONER_DISABILITIES.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.SelectedItem.Value)
        Else
            item.PRACTITIONER_DISABILITIES.Value = Nothing
        End If
        item.PRACTITIONER_DISABILITIESItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.Items)
        item.PRACTITIONER_DISABILITY_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS") Is Nothing Then
            item.PRACTITIONER_DISABILITY_DETAILS.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS.Text)
        Else
            item.PRACTITIONER_DISABILITY_DETAILS.SetValue(ControlCustomValues("STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITY_DETAILS"))
        End If
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.SelectedItem) Then
            item.PRACTITIONER_REC_CLASS_ATTENDANCE.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.SelectedItem.Value)
        Else
            item.PRACTITIONER_REC_CLASS_ATTENDANCE.Value = Nothing
        End If
        item.PRACTITIONER_REC_CLASS_ATTENDANCEItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.Items)
        item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.UniqueID))
        item.Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.SetValue(STUDENT_MEDICAL_DETAILS1Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.Value)
        item.PRACTITIONER_REC_WORKLOAD.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.SelectedItem) Then
            item.PRACTITIONER_REC_WORKLOAD.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.SelectedItem.Value)
        Else
            item.PRACTITIONER_REC_WORKLOAD.Value = Nothing
        End If
        item.PRACTITIONER_REC_WORKLOADItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_WORKLOAD.Items)
        Try
        item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.IsEmpty = IsNothing(Request.Form(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.UniqueID))
        If Not IsNothing(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.SelectedItem) Then
            item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.SetValue(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.SelectedItem.Value)
        Else
            item.PRACTITIONER_REC_CARER_AS_SUPERVISOR.Value = Nothing
        End If
        item.PRACTITIONER_REC_CARER_AS_SUPERVISORItems.CopyFrom(STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CARER_AS_SUPERVISOR.Items)
        Catch ae As ArgumentException
            STUDENT_MEDICAL_DETAILS1Errors.Add("PRACTITIONER_REC_CARER_AS_SUPERVISOR",String.Format(Resources.strings.CCS_IncorrectValue,"PRACTITIONER_REC_CARER_AS_SUPERVISOR"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_MEDICAL_DETAILS1Data)
        End If
        STUDENT_MEDICAL_DETAILS1Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 LoadItemFromRequest method

'Record Form STUDENT_MEDICAL_DETAILS1 GetRedirectUrl method @55-58CF5812

    Protected Function GetSTUDENT_MEDICAL_DETAILS1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_MEDICAL_DETAILS1 GetRedirectUrl method

'Record Form STUDENT_MEDICAL_DETAILS1 ShowErrors method @55-069725AB

    Protected Sub STUDENT_MEDICAL_DETAILS1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_MEDICAL_DETAILS1Errors.Count - 1
        Select Case STUDENT_MEDICAL_DETAILS1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_MEDICAL_DETAILS1Errors(i)
        End Select
        Next i
        STUDENT_MEDICAL_DETAILS1Error.Visible = True
        STUDENT_MEDICAL_DETAILS1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 ShowErrors method

'Record Form STUDENT_MEDICAL_DETAILS1 Insert Operation @55-26A64475

    Protected Sub STUDENT_MEDICAL_DETAILS1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILS1Item = New STUDENT_MEDICAL_DETAILS1Item()
        STUDENT_MEDICAL_DETAILS1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_MEDICAL_DETAILS1 Insert Operation

'Record Form STUDENT_MEDICAL_DETAILS1 BeforeInsert tail @55-6D86D04F
    STUDENT_MEDICAL_DETAILS1Parameters()
    STUDENT_MEDICAL_DETAILS1LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_MEDICAL_DETAILS1 BeforeInsert tail

'Record Form STUDENT_MEDICAL_DETAILS1 AfterInsert tail  @55-8D5D4891
        ErrorFlag=(STUDENT_MEDICAL_DETAILS1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 AfterInsert tail 

'Record Form STUDENT_MEDICAL_DETAILS1 Update Operation @55-412355ED

    Protected Sub STUDENT_MEDICAL_DETAILS1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILS1Item = New STUDENT_MEDICAL_DETAILS1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_MEDICAL_DETAILS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_MEDICAL_DETAILS1 Update Operation

'Button Button_Update OnClick. @57-FA189C04
        If CType(sender,Control).ID = "STUDENT_MEDICAL_DETAILS1Button_Update" Then
            RedirectUrl = GetSTUDENT_MEDICAL_DETAILS1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @57-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Retrieve Value for Control @84-3B32D398
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_BY.Value = (New TextField("", (DBUtility.UserId.ToUpper()))).GetFormattedValue()
'End Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Retrieve Value for Control @85-6C499156
        STUDENT_MEDICAL_DETAILS1PRACTITIONER_LAST_MODIFIED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (NOW()))).GetFormattedValue()
'End Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Custom Code @90-73254650
    ' -------------------------
    ' combine the selected array items then join to string
	Dim checkItemsPQ as String = "0,"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STUDENT_MEDICAL_DETAILS1PRACTITIONER_PRIMARY_ISSUES.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.Value = (checkItemsPQ.TrimEnd(","C))
	
	'16-Sep-2020|RW| Added support for disability items
	Dim checkItemsDis As String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_MEDICAL_DETAILS1PRACTITIONER_DISABILITIES.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next
	STUDENT_MEDICAL_DETAILS1Hidden_DISABILITIES.Value = (checkItemsDis.TrimEnd(","C))
	
	'17 Mar 2022|RW| Added support for recommended class attendance items
	Dim checkItemsCA = "0,"

	For Each thisItemCA In STUDENT_MEDICAL_DETAILS1PRACTITIONER_REC_CLASS_ATTENDANCE.Items
		if thisItemCA.Selected then
			checkItemsCA += (thisItemCA.Value) + ","
		end if
	Next
	STUDENT_MEDICAL_DETAILS1Hidden_PRACTITIONER_REC_CLASS_ATTENDANCE.Value = (checkItemsCA.TrimEnd(","C))
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS1 Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_MEDICAL_DETAILS1 Before Update tail @55-10D588F7
        STUDENT_MEDICAL_DETAILS1Parameters()
        STUDENT_MEDICAL_DETAILS1LoadItemFromRequest(item, EnableValidation)
        If STUDENT_MEDICAL_DETAILS1Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_MEDICAL_DETAILS1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_MEDICAL_DETAILS1Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_MEDICAL_DETAILS1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_MEDICAL_DETAILS1 Before Update tail

'Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Declare Variable @124-4E9EBD0D
        Dim tmpRiskFlag As String = ""
'End Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Declare Variable

'Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Custom Code @123-73254650
    ' -------------------------
    '20-May-2019|EA| Send email to wellbeing if Issues is "Suicide risk" is ticked
    '26-Oct-2020|RW| Added some conditional email handling to help switch between environments

    If ExecuteFlag And (Not ErrorFlag) Then 
    	' get the value of the checkbox, or leave a blankstring if null
		If Not IsNothing(STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.Value) Then
        	tmpRiskFlag = if(STUDENT_MEDICAL_DETAILS1Hidden_PRIMARY_ISSUES.Value.Contains("Suicide risk"), "Suicide risk","")
        End If
    		
    	if (tmpRiskFlag <> "") then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim wellbeingEmail = "wellbeing@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, wellbeingEmail)
          Dim studentID = Request.QueryString("STUDENT_ID")
          Dim enrolmentYear = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())

			Dim MessageFrom As String = "pcsupport@vsv.vic.edu.au"
			Dim MessageTo As String = emailRecipient
			'MessageTo = "eric@eratechnology.net.au"	'debug
			' MessageTo = "leking@distance.vic.edu.au"	'debug
			Dim MessageSubject As String = ""
			Dim MessageBody As String = ""
			
			if (tmpRiskFlag <> "") then
				MessageSubject = $"{emailTestMarker} Auto Student DB Advice - Medical - Referral of Student at Risk"
				'MessageSubject = "*** TEST TEST ***" & MessageSubject  'debug
				MessageBody = $"{emailTestMarker}<br />This student's Medical > Practitioner Referral has <strong>" & tmpRiskFlag.ToUpper() & "</strong> selected.<br>" & _
					$"<br />Student ID : <a href='{Common.GenerateStudentMedicalPageLink(studentID, enrolmentYear)}'>{studentID}</a>" & _
					"<br /><br />Updated By/When : " & item.PRACTITIONER_LAST_MODIFIED_BY.getformattedvalue & " / " & item.PRACTITIONER_LAST_MODIFIED_DATE.getformattedvalue & "</strong>" & _
					"<br /><em>Note: this may simply by a change to the Medical details form, not the tickbox only. You may have already been notified of this student</em> "  & _
					"<br><br>---- that is all ----"
				
		   		Dim ThisEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
		        ThisEmail.IsBodyHtml = True
		        Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
		        EmailServer.Send(ThisEmail)
			end if
	       
		end if

	End If
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Custom Code

'Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Custom Code @169-73254650
    ' -------------------------
     'Sept-2019|EA| check 0 errors before showing update:
    if (STUDENT_MEDICAL_DETAILS1Errors.Count = 0) then
		HttpContext.Current.Session("notifymessage") = "Practitioner Referral has been Updated"
    end if
    ' -------------------------
'End Record STUDENT_MEDICAL_DETAILS1 Event AfterUpdate. Action Custom Code

'Record Form STUDENT_MEDICAL_DETAILS1 Update Operation tail @55-E740F286
        End If
        ErrorFlag=(STUDENT_MEDICAL_DETAILS1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 Update Operation tail

'Record Form STUDENT_MEDICAL_DETAILS1 Delete Operation @55-430FD4BA
    Protected Sub STUDENT_MEDICAL_DETAILS1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_MEDICAL_DETAILS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_MEDICAL_DETAILS1Item = New STUDENT_MEDICAL_DETAILS1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_MEDICAL_DETAILS1 Delete Operation

'Record Form BeforeDelete tail @55-6D86D04F
        STUDENT_MEDICAL_DETAILS1Parameters()
        STUDENT_MEDICAL_DETAILS1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @55-50643FBE
        If ErrorFlag Then
            STUDENT_MEDICAL_DETAILS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_MEDICAL_DETAILS1 Cancel Operation @55-2C759149

    Protected Sub STUDENT_MEDICAL_DETAILS1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_MEDICAL_DETAILS1Item = New STUDENT_MEDICAL_DETAILS1Item()
        STUDENT_MEDICAL_DETAILS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_MEDICAL_DETAILS1LoadItemFromRequest(item, False)
'End Record Form STUDENT_MEDICAL_DETAILS1 Cancel Operation

'Button Button_Cancel OnClick. @58-9D362533
    If CType(sender,Control).ID = "STUDENT_MEDICAL_DETAILS1Button_Cancel" Then
        RedirectUrl = GetSTUDENT_MEDICAL_DETAILS1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @58-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_MEDICAL_DETAILS1 Cancel Operation tail @55-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_MEDICAL_DETAILS1 Cancel Operation tail

'May 2016|EA| not needed as part of GlobalERAClass.vb
'public Shared Function ERAFunction_CheckUserAccessGroups(byval strAccessGroup as string, ByVal e As System.EventArgs) as boolean
	'ERA: 23-July-2015|EA| copied from Menu - IF THIS FUNCTION IS NEEDED ON ANOTHER PAGE, MOVE IT TO A GLOBAL LOCATION  
  ' global ish function to get a string of Function Codes for this User's Group
  ' Mainly used with ERAFunction_CheckAccessCodes to set visible to true/false
'	dim retval as boolean = false

'	if (not String.IsNullOrEmpty(strAccessGroup)) then
'		dim tmpsessGroup as string = HttpContext.Current.Session("AccessGroups")
'		if (instr(tmpsessGroup, strAccessGroup) > 0) then
'			retval = true
'		else
'			retval = false
'		end if
'	end if
'	return retval
'end function


'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-749644AE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Medical_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_MEDICAL_DETAILSData = New STUDENT_MEDICAL_DETAILSDataProvider()
        STUDENT_MEDICAL_DETAILSOperations = New FormSupportedOperations(False, True, False, True, False)
        STUDENT_MEDICAL_DETAILS1Data = New STUDENT_MEDICAL_DETAILS1DataProvider()
        STUDENT_MEDICAL_DETAILS1Operations = New FormSupportedOperations(False, True, False, True, False)
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

