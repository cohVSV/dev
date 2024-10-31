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

Namespace DECV_PROD2007.Student_Census_maintain 'Namespace @1-9C5EB2CF

'Forms Definition @1-CEE56FBE
Public Class [Student_Census_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-60C9EC20
    Protected STUDENT_CENSUS_DATAData As STUDENT_CENSUS_DATADataProvider
    Protected STUDENT_CENSUS_DATAErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CENSUS_DATAOperations As FormSupportedOperations
    Protected STUDENT_CENSUS_DATAIsSubmitted As Boolean = False
    Protected STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTName As String
    Protected STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTDateControl As String
    Protected STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTName As String
    Protected STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTDateControl As String
    Protected STUDENT_CENSUS_DATA1Data As STUDENT_CENSUS_DATA1DataProvider
    Protected STUDENT_CENSUS_DATA1Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CENSUS_DATA1Operations As FormSupportedOperations
    Protected STUDENT_CENSUS_DATA1IsSubmitted As Boolean = False
    Protected Student_Census_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-8E5E65F5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CENSUS_DATAShow()
            STUDENT_CENSUS_DATA1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_CENSUS_DATA Parameters @2-1636607A

    Protected Sub STUDENT_CENSUS_DATAParameters()
        Dim item As new STUDENT_CENSUS_DATAItem
        Try
            STUDENT_CENSUS_DATAData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_CENSUS_DATAErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CENSUS_DATA Parameters

'Record Form STUDENT_CENSUS_DATA Show method @2-0980A056
    Protected Sub STUDENT_CENSUS_DATAShow()
        If STUDENT_CENSUS_DATAOperations.None Then
            STUDENT_CENSUS_DATAHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_CENSUS_DATAItem = STUDENT_CENSUS_DATAItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CENSUS_DATAOperations.AllowRead
        item.Link_gotoTAFECensusPageHref = "Student_CensusTAFE_maintain.aspx"
        STUDENT_CENSUS_DATAErrors.Add(item.errors)
        If STUDENT_CENSUS_DATAErrors.Count > 0 Then
            STUDENT_CENSUS_DATAShowErrors()
            Return
        End If
'End Record Form STUDENT_CENSUS_DATA Show method

'Record Form STUDENT_CENSUS_DATA BeforeShow tail @2-3C8C75D3
        STUDENT_CENSUS_DATAParameters()
        STUDENT_CENSUS_DATAData.FillItem(item, IsInsertMode)
        STUDENT_CENSUS_DATAHolder.DataBind()
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS,New CCSControlAttribute("placeholder", FieldType._Text, ("Please specify if Yes")))
        STUDENT_CENSUS_DATAButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CENSUS_DATAOperations.AllowUpdate
        STUDENT_CENSUS_DATASTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.Items(0).Selected = True
        item.COUNTRY_OF_BIRTHItems.SetSelection(item.COUNTRY_OF_BIRTH.GetFormattedValue())
        If Not item.COUNTRY_OF_BIRTHItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.SelectedIndex = -1
        End If
        item.COUNTRY_OF_BIRTHItems.CopyTo(STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.Items)
        STUDENT_CENSUS_DATAMOTHERS_COB.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAMOTHERS_COB.Items(0).Selected = True
        item.MOTHERS_COBItems.SetSelection(item.MOTHERS_COB.GetFormattedValue())
        If Not item.MOTHERS_COBItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAMOTHERS_COB.SelectedIndex = -1
        End If
        item.MOTHERS_COBItems.CopyTo(STUDENT_CENSUS_DATAMOTHERS_COB.Items)
        STUDENT_CENSUS_DATADATE_STARTED_IN_AUST.Text=item.DATE_STARTED_IN_AUST.GetFormattedValue()
        STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTName = "STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST"
        STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUSTDateControl = STUDENT_CENSUS_DATADATE_STARTED_IN_AUST.ClientID
        STUDENT_CENSUS_DATADatePicker_DATE_STARTED_IN_AUST.DataBind()
        STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.Items(0).Selected = True
        item.FIRST_HOME_LANGUAGEItems.SetSelection(item.FIRST_HOME_LANGUAGE.GetFormattedValue())
        If Not item.FIRST_HOME_LANGUAGEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.SelectedIndex = -1
        End If
        item.FIRST_HOME_LANGUAGEItems.CopyTo(STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.Items)
        STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.Items(0).Selected = True
        item.OTHER_HOME_LANGUAGEItems.SetSelection(item.OTHER_HOME_LANGUAGE.GetFormattedValue())
        If Not item.OTHER_HOME_LANGUAGEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.SelectedIndex = -1
        End If
        item.OTHER_HOME_LANGUAGEItems.CopyTo(STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.Items)
        STUDENT_CENSUS_DATAMOTHER_LANGUAGE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAMOTHER_LANGUAGE.Items(0).Selected = True
        item.MOTHER_LANGUAGEItems.SetSelection(item.MOTHER_LANGUAGE.GetFormattedValue())
        If Not item.MOTHER_LANGUAGEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAMOTHER_LANGUAGE.SelectedIndex = -1
        End If
        item.MOTHER_LANGUAGEItems.CopyTo(STUDENT_CENSUS_DATAMOTHER_LANGUAGE.Items)
        item.MOTHER_EDUCATION_SCHOOLItems.SetSelection(item.MOTHER_EDUCATION_SCHOOL.GetFormattedValue())
        STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.SelectedIndex = -1
        item.MOTHER_EDUCATION_SCHOOLItems.CopyTo(STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.Items)
        item.MOTHER_EDUCATION_NONSCHOOLItems.SetSelection(item.MOTHER_EDUCATION_NONSCHOOL.GetFormattedValue())
        STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.SelectedIndex = -1
        item.MOTHER_EDUCATION_NONSCHOOLItems.CopyTo(STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.Items)
        STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.Items(0).Selected = True
        item.MOTHER_OCCUPATIONGROUPItems.SetSelection(item.MOTHER_OCCUPATIONGROUP.GetFormattedValue())
        If Not item.MOTHER_OCCUPATIONGROUPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.SelectedIndex = -1
        End If
        item.MOTHER_OCCUPATIONGROUPItems.CopyTo(STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.Items)
        STUDENT_CENSUS_DATAALLOWANCE_CODE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAALLOWANCE_CODE.Items(0).Selected = True
        item.ALLOWANCE_CODEItems.SetSelection(item.ALLOWANCE_CODE.GetFormattedValue())
        If Not item.ALLOWANCE_CODEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAALLOWANCE_CODE.SelectedIndex = -1
        End If
        item.ALLOWANCE_CODEItems.CopyTo(STUDENT_CENSUS_DATAALLOWANCE_CODE.Items)
        item.KOORITORRESFLAGItems.SetSelection(item.KOORITORRESFLAG.GetFormattedValue())
        STUDENT_CENSUS_DATAKOORITORRESFLAG.SelectedIndex = -1
        item.KOORITORRESFLAGItems.CopyTo(STUDENT_CENSUS_DATAKOORITORRESFLAG.Items)
        item.RESIDENTIAL_STATUSItems.SetSelection(item.RESIDENTIAL_STATUS.GetFormattedValue())
        STUDENT_CENSUS_DATARESIDENTIAL_STATUS.SelectedIndex = -1
        item.RESIDENTIAL_STATUSItems.CopyTo(STUDENT_CENSUS_DATARESIDENTIAL_STATUS.Items)
        STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST.Text=item.DATE_ARRIVED_IN_AUST.GetFormattedValue()
        STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTName = "STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST"
        STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUSTDateControl = STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST.ClientID
        STUDENT_CENSUS_DATADatePicker_DATE_ARRIVED_IN_AUST.DataBind()
        STUDENT_CENSUS_DATAVISA_SUB_CLASS.Text=item.VISA_SUB_CLASS.GetFormattedValue()
        STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE.Text=item.VISA_STATISTICAL_CODE.GetFormattedValue()
        STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID.Text=item.PREVIOUS_SCHOOL_ID.GetFormattedValue()
        STUDENT_CENSUS_DATAFAMILY_OSG.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAFAMILY_OSG.Items(0).Selected = True
        item.FAMILY_OSGItems.SetSelection(item.FAMILY_OSG.GetFormattedValue())
        If Not item.FAMILY_OSGItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAFAMILY_OSG.SelectedIndex = -1
        End If
        item.FAMILY_OSGItems.CopyTo(STUDENT_CENSUS_DATAFAMILY_OSG.Items)
        item.HOUSEHOLD_STATUSItems.SetSelection(item.HOUSEHOLD_STATUS.GetFormattedValue())
        STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.SelectedIndex = -1
        item.HOUSEHOLD_STATUSItems.CopyTo(STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.Items)
        STUDENT_CENSUS_DATADISABILITY_ID.Text=item.DISABILITY_ID.GetFormattedValue()
        item.REPEATING_YEARItems.SetSelection(item.REPEATING_YEAR.GetFormattedValue())
        STUDENT_CENSUS_DATAREPEATING_YEAR.SelectedIndex = -1
        item.REPEATING_YEARItems.CopyTo(STUDENT_CENSUS_DATAREPEATING_YEAR.Items)
        STUDENT_CENSUS_DATAOTHER_SCHOOL_TF.Text=item.OTHER_SCHOOL_TF.GetFormattedValue()
        STUDENT_CENSUS_DATALAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATALAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAHidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STUDENT_CENSUS_DATAHidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STUDENT_CENSUS_DATAFATHER_LANGUAGE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAFATHER_LANGUAGE.Items(0).Selected = True
        item.FATHER_LANGUAGEItems.SetSelection(item.FATHER_LANGUAGE.GetFormattedValue())
        If Not item.FATHER_LANGUAGEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAFATHER_LANGUAGE.SelectedIndex = -1
        End If
        item.FATHER_LANGUAGEItems.CopyTo(STUDENT_CENSUS_DATAFATHER_LANGUAGE.Items)
        STUDENT_CENSUS_DATAFATHERS_COB.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAFATHERS_COB.Items(0).Selected = True
        item.FATHERS_COBItems.SetSelection(item.FATHERS_COB.GetFormattedValue())
        If Not item.FATHERS_COBItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAFATHERS_COB.SelectedIndex = -1
        End If
        item.FATHERS_COBItems.CopyTo(STUDENT_CENSUS_DATAFATHERS_COB.Items)
        item.FATHER_EDUCATION_SCHOOLItems.SetSelection(item.FATHER_EDUCATION_SCHOOL.GetFormattedValue())
        STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.SelectedIndex = -1
        item.FATHER_EDUCATION_SCHOOLItems.CopyTo(STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.Items)
        item.FATHER_EDUCATION_NONSCHOOLItems.SetSelection(item.FATHER_EDUCATION_NONSCHOOL.GetFormattedValue())
        STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.SelectedIndex = -1
        item.FATHER_EDUCATION_NONSCHOOLItems.CopyTo(STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.Items)
        STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.Items(0).Selected = True
        item.FATHER_OCCUPATIONGROUPItems.SetSelection(item.FATHER_OCCUPATIONGROUP.GetFormattedValue())
        If Not item.FATHER_OCCUPATIONGROUPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.SelectedIndex = -1
        End If
        item.FATHER_OCCUPATIONGROUPItems.CopyTo(STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.Items)
        STUDENT_CENSUS_DATASCHOOL_NAME.Text=item.SCHOOL_NAME.GetFormattedValue()
        STUDENT_CENSUS_DATAlblPREVIOUS_SCHOOL_NAME.Text = Server.HtmlEncode(item.lblPREVIOUS_SCHOOL_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
        STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.Text=item.DATE_LAST_ATTENDED_SCHOOL.GetFormattedValue()
        STUDENT_CENSUS_DATALink_gotoTAFECensusPage.InnerText += item.Link_gotoTAFECensusPage.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CENSUS_DATALink_gotoTAFECensusPage.HRef = item.Link_gotoTAFECensusPageHref+item.Link_gotoTAFECensusPageHrefParameters.ToString("GET","override", ViewState)
        STUDENT_CENSUS_DATAHidden_household_status.Value = item.Hidden_household_status.GetFormattedValue()
        STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = item.ResidentialStatusErrormessage.GetFormattedValue()
        STUDENT_CENSUS_DATAHidden_KoorieTorresFlag.Value = item.Hidden_KoorieTorresFlag.GetFormattedValue()
        STUDENT_CENSUS_DATACRIS_ID.Text=item.CRIS_ID.GetFormattedValue()
        item.YOUTH_JUSTICE_INVOLVEMENTItems.SetSelection(item.YOUTH_JUSTICE_INVOLVEMENT.GetFormattedValue())
        STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.SelectedIndex = -1
        item.YOUTH_JUSTICE_INVOLVEMENTItems.CopyTo(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.Items, True)
        STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS.Text=item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.GetFormattedValue()
        STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag.Value = item.Hidden_YouthJusticeInvolvementFlag.GetFormattedValue()
'End Record Form STUDENT_CENSUS_DATA BeforeShow tail

'RadioButton MOTHER_EDUCATION_SCHOOL Event BeforeShow. Action Custom Code @109-73254650
    ' -------------------------
	'8-Dec-2011|EA| change layout into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.RepeatColumns = 2
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton MOTHER_EDUCATION_SCHOOL Event BeforeShow. Action Custom Code

'RadioButton MOTHER_EDUCATION_NONSCHOOL Event BeforeShow. Action Custom Code @111-73254650
    ' -------------------------
     '8-Dec-2011|EA| change layout into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.RepeatColumns = 2
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton MOTHER_EDUCATION_NONSCHOOL Event BeforeShow. Action Custom Code

'TextBox VISA_STATISTICAL_CODE Event BeforeShow. Action Custom Code @63-73254650
    ' -------------------------
	' ERA: trim spaces out of char(4) field as it's mucking up the form
    STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE.Text = (STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE.Text.Trim())
	STUDENT_CENSUS_DATAVISA_SUB_CLASS.Text = (STUDENT_CENSUS_DATAVISA_SUB_CLASS.Text.Trim())
    ' -------------------------
'End TextBox VISA_STATISTICAL_CODE Event BeforeShow. Action Custom Code

'RadioButton HOUSEHOLD_STATUS Event BeforeShow. Action Custom Code @113-73254650
    ' -------------------------
      '8-Dec-2011|EA| change layout into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.RepeatColumns = 2
	STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton HOUSEHOLD_STATUS Event BeforeShow. Action Custom Code

'RadioButton FATHER_EDUCATION_SCHOOL Event BeforeShow. Action Custom Code @110-73254650
    ' -------------------------
    '8-Dec-2011|EA| change layout into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.RepeatColumns = 2
	STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton FATHER_EDUCATION_SCHOOL Event BeforeShow. Action Custom Code

'RadioButton FATHER_EDUCATION_NONSCHOOL Event BeforeShow. Action Custom Code @112-73254650
    ' -------------------------
  	'8-Dec-2011|EA| change layout into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.RepeatColumns = 2
	STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton FATHER_EDUCATION_NONSCHOOL Event BeforeShow. Action Custom Code

'Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action Custom Code @96-73254650
    ' -------------------------
    if not (item.PREVIOUS_SCHOOL_ID.GetFormattedValue() = "") then
    ' -------------------------
'End Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action Custom Code

'Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action DLookup @95-33B95E84
            STUDENT_CENSUS_DATAlblPREVIOUS_SCHOOL_NAME.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME) as [SCHOOL_NAME]" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.PREVIOUS_SCHOOL_ID.GetFormattedValue()))).GetFormattedValue("")
'End Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action DLookup

'Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action Custom Code @97-73254650
    ' -------------------------
    end if
    ' -------------------------
'End Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action Custom Code

'Link Link_gotoTAFECensusPage Event BeforeShow. Action Hide-Show Component @108-1E96C252
        Dim Urloverride_108_1 As IntegerField = New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("override"))
        Dim ExprParam2_108_2 As IntegerField = New IntegerField("", (1))
        If FieldBase.EqualOp(Urloverride_108_1, ExprParam2_108_2) Then
            STUDENT_CENSUS_DATALink_gotoTAFECensusPage.Visible = True
        End If
'End Link Link_gotoTAFECensusPage Event BeforeShow. Action Hide-Show Component

'Hidden Hidden_household_status Event BeforeShow. Action Custom Code @120-73254650
    ' -------------------------
    'if not (item.HOUSEHOLD_STATUS.GetFormattedValue() = "") then
    	dim tmpHouseholdstatus as string
    	tmpHouseholdstatus=item.HOUSEHOLD_STATUS.GetFormattedValue()
    'end if
    ' -------------------------
'End Hidden Hidden_household_status Event BeforeShow. Action Custom Code

'Hidden Hidden_household_status Event BeforeShow. Action Retrieve Value for Control @116-5F23431B
            STUDENT_CENSUS_DATAHidden_household_status.Value = (New TextField("", tmpHouseholdstatus)).GetFormattedValue()
'End Hidden Hidden_household_status Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_KoorieTorresFlag Event BeforeShow. Action Custom Code @127-73254650
    ' -------------------------
    'Aug-2019|EA| get Koorie/Torres flag on load for checking changes later
    dim tmpKoorieTorresFlag as string
    	tmpKoorieTorresFlag=item.KOORITORRESFLAG.GetFormattedValue()
    ' -------------------------
'End Hidden Hidden_KoorieTorresFlag Event BeforeShow. Action Custom Code



'Hidden Hidden_KoorieTorresFlag Event BeforeShow. Action Retrieve Value for Control @126-A8BDD790
            STUDENT_CENSUS_DATAHidden_KoorieTorresFlag.Value = (New TextField("", tmpKoorieTorresFlag)).GetFormattedValue()
'End Hidden Hidden_KoorieTorresFlag Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_YouthJusticeInvolvementFlag Event BeforeShow. Action Custom Code @198-73254650
    ' -------------------------
    '14 Oct 2021|RW| Save existing Youth Justice involvement status, to allow detection of changes during update
    dim tmpYouthJusticeFlag = item.YOUTH_JUSTICE_INVOLVEMENT.GetFormattedValue()
    ' -------------------------
'End Hidden Hidden_YouthJusticeInvolvementFlag Event BeforeShow. Action Custom Code

'Hidden Hidden_YouthJusticeInvolvementFlag Event BeforeShow. Action Retrieve Value for Control @199-4B05E49B
            STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag.Value = (New BooleanField(Settings.BoolFormat, tmpYouthJusticeFlag)).GetFormattedValue()
'End Hidden Hidden_YouthJusticeInvolvementFlag Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_CENSUS_DATA Show method tail @2-F6A88156
        If STUDENT_CENSUS_DATAErrors.Count > 0 Then
            STUDENT_CENSUS_DATAShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA Show method tail

'Record Form STUDENT_CENSUS_DATA LoadItemFromRequest method @2-D6CDBB1D

    Protected Sub STUDENT_CENSUS_DATALoadItemFromRequest(item As STUDENT_CENSUS_DATAItem, ByVal EnableValidation As Boolean)
        Try
        item.COUNTRY_OF_BIRTH.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.UniqueID))
        item.COUNTRY_OF_BIRTH.SetValue(STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.Value)
        item.COUNTRY_OF_BIRTHItems.CopyFrom(STUDENT_CENSUS_DATACOUNTRY_OF_BIRTH.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("COUNTRY_OF_BIRTH",String.Format(Resources.strings.CCS_IncorrectValue,"Student COUNTRY OF BIRTH"))
        End Try
        Try
        item.MOTHERS_COB.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAMOTHERS_COB.UniqueID))
        item.MOTHERS_COB.SetValue(STUDENT_CENSUS_DATAMOTHERS_COB.Value)
        item.MOTHERS_COBItems.CopyFrom(STUDENT_CENSUS_DATAMOTHERS_COB.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("MOTHERS_COB",String.Format(Resources.strings.CCS_IncorrectValue,"MOTHERS COUNTRY OF BIRTH"))
        End Try
        Try
        item.DATE_STARTED_IN_AUST.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADATE_STARTED_IN_AUST.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADATE_STARTED_IN_AUST") Is Nothing Then
            item.DATE_STARTED_IN_AUST.SetValue(STUDENT_CENSUS_DATADATE_STARTED_IN_AUST.Text)
        Else
            item.DATE_STARTED_IN_AUST.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADATE_STARTED_IN_AUST"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DATE_STARTED_IN_AUST",String.Format(Resources.strings.CCS_IncorrectFormat,"Student DATE STARTED IN AUST","d/m/yyyy"))
        End Try
        Try
        item.FIRST_HOME_LANGUAGE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.UniqueID))
        item.FIRST_HOME_LANGUAGE.SetValue(STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.Value)
        item.FIRST_HOME_LANGUAGEItems.CopyFrom(STUDENT_CENSUS_DATAFIRST_HOME_LANGUAGE.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("FIRST_HOME_LANGUAGE",String.Format(Resources.strings.CCS_IncorrectValue,"Student FIRST LANGUAGE"))
        End Try
        Try
        item.OTHER_HOME_LANGUAGE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.UniqueID))
        item.OTHER_HOME_LANGUAGE.SetValue(STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.Value)
        item.OTHER_HOME_LANGUAGEItems.CopyFrom(STUDENT_CENSUS_DATAOTHER_HOME_LANGUAGE.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("OTHER_HOME_LANGUAGE",String.Format(Resources.strings.CCS_IncorrectValue,"Student OTHER LANGUAGE"))
        End Try
        Try
        item.MOTHER_LANGUAGE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAMOTHER_LANGUAGE.UniqueID))
        item.MOTHER_LANGUAGE.SetValue(STUDENT_CENSUS_DATAMOTHER_LANGUAGE.Value)
        item.MOTHER_LANGUAGEItems.CopyFrom(STUDENT_CENSUS_DATAMOTHER_LANGUAGE.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("MOTHER_LANGUAGE",String.Format(Resources.strings.CCS_IncorrectValue,"MOTHER LANGUAGE"))
        End Try
        item.MOTHER_EDUCATION_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.SelectedItem) Then
            item.MOTHER_EDUCATION_SCHOOL.SetValue(STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.SelectedItem.Value)
        Else
            item.MOTHER_EDUCATION_SCHOOL.Value = Nothing
        End If
        item.MOTHER_EDUCATION_SCHOOLItems.CopyFrom(STUDENT_CENSUS_DATAMOTHER_EDUCATION_SCHOOL.Items)
        item.MOTHER_EDUCATION_NONSCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.SelectedItem) Then
            item.MOTHER_EDUCATION_NONSCHOOL.SetValue(STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.SelectedItem.Value)
        Else
            item.MOTHER_EDUCATION_NONSCHOOL.Value = Nothing
        End If
        item.MOTHER_EDUCATION_NONSCHOOLItems.CopyFrom(STUDENT_CENSUS_DATAMOTHER_EDUCATION_NONSCHOOL.Items)
        item.MOTHER_OCCUPATIONGROUP.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.UniqueID))
        item.MOTHER_OCCUPATIONGROUP.SetValue(STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.Value)
        item.MOTHER_OCCUPATIONGROUPItems.CopyFrom(STUDENT_CENSUS_DATAMOTHER_OCCUPATIONGROUP.Items)
        Try
        item.ALLOWANCE_CODE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAALLOWANCE_CODE.UniqueID))
        item.ALLOWANCE_CODE.SetValue(STUDENT_CENSUS_DATAALLOWANCE_CODE.Value)
        item.ALLOWANCE_CODEItems.CopyFrom(STUDENT_CENSUS_DATAALLOWANCE_CODE.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("ALLOWANCE_CODE",String.Format(Resources.strings.CCS_IncorrectValue,"ALLOWANCE CODE"))
        End Try
        item.KOORITORRESFLAG.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAKOORITORRESFLAG.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAKOORITORRESFLAG.SelectedItem) Then
            item.KOORITORRESFLAG.SetValue(STUDENT_CENSUS_DATAKOORITORRESFLAG.SelectedItem.Value)
        Else
            item.KOORITORRESFLAG.Value = Nothing
        End If
        item.KOORITORRESFLAGItems.CopyFrom(STUDENT_CENSUS_DATAKOORITORRESFLAG.Items)
        item.RESIDENTIAL_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATARESIDENTIAL_STATUS.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATARESIDENTIAL_STATUS.SelectedItem) Then
            item.RESIDENTIAL_STATUS.SetValue(STUDENT_CENSUS_DATARESIDENTIAL_STATUS.SelectedItem.Value)
        Else
            item.RESIDENTIAL_STATUS.Value = Nothing
        End If
        item.RESIDENTIAL_STATUSItems.CopyFrom(STUDENT_CENSUS_DATARESIDENTIAL_STATUS.Items)
        Try
        item.DATE_ARRIVED_IN_AUST.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST") Is Nothing Then
            item.DATE_ARRIVED_IN_AUST.SetValue(STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST.Text)
        Else
            item.DATE_ARRIVED_IN_AUST.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADATE_ARRIVED_IN_AUST"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DATE_ARRIVED_IN_AUST",String.Format(Resources.strings.CCS_IncorrectFormat,"Student DATE ARRIVED IN AUST","d/m/yyyy"))
        End Try
        Try
        item.VISA_SUB_CLASS.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAVISA_SUB_CLASS.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAVISA_SUB_CLASS") Is Nothing Then
            item.VISA_SUB_CLASS.SetValue(STUDENT_CENSUS_DATAVISA_SUB_CLASS.Text)
        Else
            item.VISA_SUB_CLASS.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAVISA_SUB_CLASS"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("VISA_SUB_CLASS",String.Format(Resources.strings.CCS_IncorrectValue,"Student VISA SUB CLASS"))
        End Try
        item.VISA_STATISTICAL_CODE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE") Is Nothing Then
            item.VISA_STATISTICAL_CODE.SetValue(STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE.Text)
        Else
            item.VISA_STATISTICAL_CODE.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAVISA_STATISTICAL_CODE"))
        End If
        Try
        item.PREVIOUS_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID") Is Nothing Then
            item.PREVIOUS_SCHOOL_ID.SetValue(STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID.Text)
        Else
            item.PREVIOUS_SCHOOL_ID.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("PREVIOUS_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"PREVIOUS SCHOOL ID"))
        End Try
        Try
        item.FAMILY_OSG.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFAMILY_OSG.UniqueID))
        item.FAMILY_OSG.SetValue(STUDENT_CENSUS_DATAFAMILY_OSG.Value)
        item.FAMILY_OSGItems.CopyFrom(STUDENT_CENSUS_DATAFAMILY_OSG.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("FAMILY_OSG",String.Format(Resources.strings.CCS_IncorrectValue,"FAMILY OCCUPATION GROUP"))
        End Try
        Try
        item.HOUSEHOLD_STATUS.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.SelectedItem) Then
            item.HOUSEHOLD_STATUS.SetValue(STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.SelectedItem.Value)
        Else
            item.HOUSEHOLD_STATUS.Value = Nothing
        End If
        item.HOUSEHOLD_STATUSItems.CopyFrom(STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("HOUSEHOLD_STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"LIVING ARRANGEMENTS / HOUSEHOLD STATUS"))
        End Try
        Try
        item.DISABILITY_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADISABILITY_ID.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_ID") Is Nothing Then
            item.DISABILITY_ID.SetValue(STUDENT_CENSUS_DATADISABILITY_ID.Text)
        Else
            item.DISABILITY_ID.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_ID"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DISABILITY_ID",String.Format(Resources.strings.CCS_IncorrectValue,"DISABILITY ID"))
        End Try
        Try
        item.REPEATING_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAREPEATING_YEAR.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAREPEATING_YEAR.SelectedItem) Then
            item.REPEATING_YEAR.SetValue(STUDENT_CENSUS_DATAREPEATING_YEAR.SelectedItem.Value)
        Else
            item.REPEATING_YEAR.Value = Nothing
        End If
        item.REPEATING_YEARItems.CopyFrom(STUDENT_CENSUS_DATAREPEATING_YEAR.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("REPEATING_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"REPEATING YEAR"))
        End Try
        Try
        item.OTHER_SCHOOL_TF.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAOTHER_SCHOOL_TF.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAOTHER_SCHOOL_TF") Is Nothing Then
            item.OTHER_SCHOOL_TF.SetValue(STUDENT_CENSUS_DATAOTHER_SCHOOL_TF.Text)
        Else
            item.OTHER_SCHOOL_TF.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAOTHER_SCHOOL_TF"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("OTHER_SCHOOL_TF",String.Format(Resources.strings.CCS_IncorrectValue,"OTHER SCHOOL TIME FRACTION"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STUDENT_CENSUS_DATAHidden_last_altered_by.Value)
        Try
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STUDENT_CENSUS_DATAHidden_last_altered_date.Value)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("Hidden_last_altered_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_last_altered_date","yyyy-mm-dd H:nn"))
        End Try
        Try
        item.FATHER_LANGUAGE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFATHER_LANGUAGE.UniqueID))
        item.FATHER_LANGUAGE.SetValue(STUDENT_CENSUS_DATAFATHER_LANGUAGE.Value)
        item.FATHER_LANGUAGEItems.CopyFrom(STUDENT_CENSUS_DATAFATHER_LANGUAGE.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("FATHER_LANGUAGE",String.Format(Resources.strings.CCS_IncorrectValue,"FATHER LANGUAGE"))
        End Try
        Try
        item.FATHERS_COB.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFATHERS_COB.UniqueID))
        item.FATHERS_COB.SetValue(STUDENT_CENSUS_DATAFATHERS_COB.Value)
        item.FATHERS_COBItems.CopyFrom(STUDENT_CENSUS_DATAFATHERS_COB.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("FATHERS_COB",String.Format(Resources.strings.CCS_IncorrectValue,"FATHERS COUNTRY OF BIRTH"))
        End Try
        item.FATHER_EDUCATION_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.SelectedItem) Then
            item.FATHER_EDUCATION_SCHOOL.SetValue(STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.SelectedItem.Value)
        Else
            item.FATHER_EDUCATION_SCHOOL.Value = Nothing
        End If
        item.FATHER_EDUCATION_SCHOOLItems.CopyFrom(STUDENT_CENSUS_DATAFATHER_EDUCATION_SCHOOL.Items)
        item.FATHER_EDUCATION_NONSCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.SelectedItem) Then
            item.FATHER_EDUCATION_NONSCHOOL.SetValue(STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.SelectedItem.Value)
        Else
            item.FATHER_EDUCATION_NONSCHOOL.Value = Nothing
        End If
        item.FATHER_EDUCATION_NONSCHOOLItems.CopyFrom(STUDENT_CENSUS_DATAFATHER_EDUCATION_NONSCHOOL.Items)
        item.FATHER_OCCUPATIONGROUP.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.UniqueID))
        item.FATHER_OCCUPATIONGROUP.SetValue(STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.Value)
        item.FATHER_OCCUPATIONGROUPItems.CopyFrom(STUDENT_CENSUS_DATAFATHER_OCCUPATIONGROUP.Items)
        item.SCHOOL_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATASCHOOL_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATASCHOOL_NAME") Is Nothing Then
            item.SCHOOL_NAME.SetValue(STUDENT_CENSUS_DATASCHOOL_NAME.Text)
        Else
            item.SCHOOL_NAME.SetValue(ControlCustomValues("STUDENT_CENSUS_DATASCHOOL_NAME"))
        End If
        Try
        item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL") Is Nothing Then
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.Text)
        Else
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DATE_LAST_ATTENDED_SCHOOL",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE LAST ATTENDED SCHOOL","d/m/yyyy"))
        End Try
        item.Hidden_household_status.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_household_status.UniqueID))
        item.Hidden_household_status.SetValue(STUDENT_CENSUS_DATAHidden_household_status.Value)
        item.Hidden_KoorieTorresFlag.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_KoorieTorresFlag.UniqueID))
        item.Hidden_KoorieTorresFlag.SetValue(STUDENT_CENSUS_DATAHidden_KoorieTorresFlag.Value)
        item.CRIS_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATACRIS_ID.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATACRIS_ID") Is Nothing Then
            item.CRIS_ID.SetValue(STUDENT_CENSUS_DATACRIS_ID.Text)
        Else
            item.CRIS_ID.SetValue(ControlCustomValues("STUDENT_CENSUS_DATACRIS_ID"))
        End If
        Try
        item.YOUTH_JUSTICE_INVOLVEMENT.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.SelectedItem) Then
            item.YOUTH_JUSTICE_INVOLVEMENT.SetValue(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.SelectedItem.Value)
        Else
            item.YOUTH_JUSTICE_INVOLVEMENT.Value = Nothing
        End If
        item.YOUTH_JUSTICE_INVOLVEMENTItems.CopyFrom(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("YOUTH_JUSTICE_INVOLVEMENT",String.Format(Resources.strings.CCS_IncorrectValue,"Youth Justice involvement?"))
        End Try
        item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS") Is Nothing Then
            item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.SetValue(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS.Text)
        Else
            item.YOUTH_JUSTICE_INVOLVEMENT_DETAILS.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT_DETAILS"))
        End If
        Try
        item.Hidden_YouthJusticeInvolvementFlag.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag.UniqueID))
        item.Hidden_YouthJusticeInvolvementFlag.SetValue(STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag.Value)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("Hidden_YouthJusticeInvolvementFlag",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_YouthJusticeInvolvementFlag"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_CENSUS_DATAData)
        End If
        STUDENT_CENSUS_DATAErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CENSUS_DATA LoadItemFromRequest method

'Record Form STUDENT_CENSUS_DATA GetRedirectUrl method @2-9ACED4C7

    Protected Function GetSTUDENT_CENSUS_DATARedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CENSUS_DATA GetRedirectUrl method

'Record Form STUDENT_CENSUS_DATA ShowErrors method @2-F4792A1A

    Protected Sub STUDENT_CENSUS_DATAShowErrors()
        STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CENSUS_DATAErrors.Count - 1
        Select Case STUDENT_CENSUS_DATAErrors.AllKeys(i)
            Case "DATE_STARTED_IN_AUST"
                If STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text <> "" Then  STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text &= "<br>"
                STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text & STUDENT_CENSUS_DATAErrors(i)
            Case "DATE_ARRIVED_IN_AUST"
                If STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text <> "" Then  STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text &= "<br>"
                STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text & STUDENT_CENSUS_DATAErrors(i)
            Case "VISA_SUB_CLASS"
                If STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text <> "" Then  STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text &= "<br>"
                STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text & STUDENT_CENSUS_DATAErrors(i)
            Case "VISA_STATISTICAL_CODE"
                If STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text <> "" Then  STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text &= "<br>"
                STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text = STUDENT_CENSUS_DATAResidentialStatusErrormessage.Text & STUDENT_CENSUS_DATAErrors(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CENSUS_DATAErrors(i)
        End Select
        Next i
        STUDENT_CENSUS_DATAError.Visible = True
        STUDENT_CENSUS_DATAErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CENSUS_DATA ShowErrors method

'Record Form STUDENT_CENSUS_DATA Insert Operation @2-993FEF4B

    Protected Sub STUDENT_CENSUS_DATA_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        STUDENT_CENSUS_DATAIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CENSUS_DATA Insert Operation

'Record Form STUDENT_CENSUS_DATA BeforeInsert tail @2-FA4B514B
    STUDENT_CENSUS_DATAParameters()
    STUDENT_CENSUS_DATALoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CENSUS_DATA BeforeInsert tail

'Record Form STUDENT_CENSUS_DATA AfterInsert tail  @2-D50AC6D6
        ErrorFlag=(STUDENT_CENSUS_DATAErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CENSUS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA AfterInsert tail 

'Record Form STUDENT_CENSUS_DATA Update Operation @2-0E3EC6C1

    Protected Sub STUDENT_CENSUS_DATA_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CENSUS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CENSUS_DATA Update Operation

'Button Button_Update OnClick. @3-3977A0CD
        If CType(sender,Control).ID = "STUDENT_CENSUS_DATAButton_Update" Then
            RedirectUrl = GetSTUDENT_CENSUS_DATARedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @3-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Retrieve Value for Control @66-17DB183E
        STUDENT_CENSUS_DATAHidden_last_altered_by.Value = (New TextField("", (dbutility.userid.toupper()))).GetFormattedValue()
'End Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Retrieve Value for Control @67-7095D266
        STUDENT_CENSUS_DATAHidden_last_altered_date.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_CENSUS_DATA Before Update tail @2-FA7BB3A1
        STUDENT_CENSUS_DATAParameters()
        STUDENT_CENSUS_DATALoadItemFromRequest(item, EnableValidation)
        If STUDENT_CENSUS_DATAOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_CENSUS_DATAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CENSUS_DATAData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CENSUS_DATAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CENSUS_DATA Before Update tail

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable @121-0065F875
        Dim tmpHouseNow As String = 0
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable @122-3DB859F4
        Dim tmpHouseOrig As String = 0
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value @118-023906C6
        tmpHouseNow=STUDENT_CENSUS_DATAHOUSEHOLD_STATUS.SelectedItem.Value
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value @119-2EC28AFD
        tmpHouseOrig=STUDENT_CENSUS_DATAHidden_household_status.Value
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code @117-73254650
    ' -------------------------
    '19-Nov-2015|EA| Send email to wellbeing if Out of Home (Household Status) is now 3, if originally NOT = 3 at loading
    '12-Nov-2019|EA| change from wellbeing@distance.vic.edu.au to oohc@vsv.vic.edu.au (#19914)
    '26-Oct-2020|RW| OoHC has been split into three categories, so I've updated the auto-email alert criteria to cover that
    '26-Oct-2020|RW| Added some conditional email handling to help switch between environments

    If ExecuteFlag And (Not ErrorFlag) Then 
      Dim isOoHC = (tmpHouseNow = "3") OrElse (tmpHouseNow = "6") OrElse (tmpHouseNow = "7")
    	if (isOoHC AndAlso (tmpHouseOrig <> tmpHouseNow)) then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim ooHCEmail = "oohc@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, ooHCEmail)
          Dim studentID = Request.QueryString("STUDENT_ID")
          Dim enrolmentYear = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())

			Dim MessageFrom As String = "pcsupport@vsv.vic.edu.au"
			Dim MessageTo As String = emailRecipient
			'MessageTo = "eaffleck@gmail.com.au"	'debug
			
			Dim MessageSubject As String = $"{emailTestMarker}Auto Student DB Advice - Out of Home Living arrangements"
			Dim MessageBody As String = $"{emailTestMarker}<br/>This student's Census > Living Arrangments have been <em>updated</em> to be 'Out of Home'.<br><br> " & _
				$"<br />Student ID : <a href='{Common.GenerateStudentCensusPageLink(studentID, enrolmentYear)}'>{studentID}</a>" & _
				"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
				"<br><br>---- that is all ----"
			
	   		Dim ThisEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
	        ThisEmail.IsBodyHtml = True
	        Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
	        EmailServer.Send(ThisEmail)
	        'response.write(MessageBody)
	        'response.end
	    
		end if

	End If

    ' -------------------------
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable @128-324FC609
        Dim tmpKooriNow As String = ""
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable @129-76709C30
        Dim tmpKooriOrig As String = ""
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Declare Variable

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value @130-197B54EA
        tmpKooriOrig=STUDENT_CENSUS_DATAHidden_KoorieTorresFlag.Value
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value @131-9F986EB4
        tmpKooriNow=STUDENT_CENSUS_DATAKOORITORRESFLAG.SelectedItem.Value
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Save Control Value

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code @132-73254650
    ' -------------------------
    '3-Aug-2019|EA| send email if KoorieTorresFlag changed from N to non-N (sd ticket #19353)
    '26-Oct-2020|RW| Added some conditional email handling to help switch between environments

    If ExecuteFlag And (Not ErrorFlag) Then 
    	if (tmpKooriNow <> "N" And tmpKooriOrig <> tmpKooriNow) then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim atsiEmail = "marrung@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, atsiEmail)
          Dim studentID = Request.QueryString("STUDENT_ID")
          Dim enrolmentYear = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())

			Dim MessageFrom As String = "pcsupport@vsv.vic.edu.au"
			Dim MessageTo As String = emailRecipient
			'MessageTo = "eric@eratechnology.net.au"	'debug
			
			Dim MessageSubject As String = $"{emailTestMarker}Auto Student DB Advice - Indigenous Cultural Inclusion"
			Dim MessageBody As String = $"{emailTestMarker}<br/>This student's Census details have been <em>updated</em> to be of 'Aboriginal/Koori/Torres Strait Islander' origin (value: " & tmpKooriNow & ")<br><br> " & _
				$"<br />Student ID : <a href='{Common.GenerateStudentCensusPageLink(studentID, enrolmentYear)}'>{studentID}</a>" & _
				"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>" & _
				"<br><br>---- that is all ----"
			
	   		Dim ThisEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
	        ThisEmail.IsBodyHtml = True
	        Dim EmailServer As New System.Net.Mail.SmtpClient(System.Configuration.ConfigurationSettings.AppSettings("smtp_servername"))
	        EmailServer.Send(ThisEmail)
	        'response.write(MessageBody)
	        'response.end
	    
		end if

	End If
    ' -------------------------
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code

'Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code @196-73254650
	Dim youthJusticeExisting = STUDENT_CENSUS_DATAHidden_YouthJusticeInvolvementFlag.Value
	Dim youthJusticeNew = If(STUDENT_CENSUS_DATAYOUTH_JUSTICE_INVOLVEMENT.SelectedItem?.Value, "No")
	
	If (ExecuteFlag AndAlso (Not ErrorFlag) AndAlso youthJusticeNew.Equals("Yes") AndAlso (Not youthJusticeNew.Equals(youthJusticeExisting))) Then
          Dim environment = ConfigurationManager.AppSettings("Environment")
          Dim developmentEmail = ConfigurationManager.AppSettings("DevelopmentEmail")
          Dim wellbeingEmail = "wellbeing@vsv.vic.edu.au"
          Dim emailTestMarker = If("Staging".Equals(environment), "[Test Email] ", "")
          Dim emailRecipient = If("Development".Equals(environment), developmentEmail, wellbeingEmail)
          Dim studentID = Request.QueryString("STUDENT_ID")
          Dim studentName = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select concat(isnull(nullif(st.PREFERRED_NAME, ''), rtrim(st.FIRST_NAME)), ' ', rtrim(st.SURNAME), ' (', cast(st.STUDENT_ID as varchar(20)), ')') as StudentName from dbo.STUDENT as st where (st.STUDENT_ID = " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"), FieldType._Text, True) & ")").ToString()
          Dim enrolmentYear = If(Request.QueryString("ENROLMENT_YEAR"), Date.Today.Year.ToString())

			Dim MessageFrom As String = "pcsupport@vsv.vic.edu.au"
			Dim MessageTo As String = emailRecipient
			
			Dim MessageSubject As String = $"{emailTestMarker}Auto Student DB Advice - Youth Justice Involvement"
			Dim MessageBody As String = $"{emailTestMarker}<br/>This is an automated email to advise that a student's census details have been updated to indicate Youth Justice involvement.<br><br> " &
				$"<br />Student : <a href='{Common.GenerateStudentCensusPageLink(studentID, enrolmentYear)}'>{studentName}</a>" &
				"<br /><br />Updated By/When : " & item.hidden_last_altered_by.getformattedvalue & " / " & item.hidden_last_altered_date.getformattedvalue & "</strong>"
			
	   		Dim ThisEmail As New System.Net.Mail.MailMessage(MessageFrom, MessageTo, MessageSubject, MessageBody)
	        ThisEmail.IsBodyHtml = True
	        Dim EmailServer As New System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings("smtp_servername"))
	        EmailServer.Send(ThisEmail)
	End If
'End Record STUDENT_CENSUS_DATA Event AfterUpdate. Action Custom Code

'Record Form STUDENT_CENSUS_DATA Update Operation tail @2-B0801874
        End If
        ErrorFlag=(STUDENT_CENSUS_DATAErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CENSUS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA Update Operation tail

'Record Form STUDENT_CENSUS_DATA Delete Operation @2-396AB5B2
    Protected Sub STUDENT_CENSUS_DATA_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CENSUS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CENSUS_DATA Delete Operation

'Record Form BeforeDelete tail @2-FA4B514B
        STUDENT_CENSUS_DATAParameters()
        STUDENT_CENSUS_DATALoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-3DD93998
        If ErrorFlag Then
            STUDENT_CENSUS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CENSUS_DATA Cancel Operation @2-69DC8666

    Protected Sub STUDENT_CENSUS_DATA_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATAItem = New STUDENT_CENSUS_DATAItem()
        STUDENT_CENSUS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CENSUS_DATALoadItemFromRequest(item, False)
'End Record Form STUDENT_CENSUS_DATA Cancel Operation

'Button Button_Cancel OnClick. @4-423C05D1
    If CType(sender,Control).ID = "STUDENT_CENSUS_DATAButton_Cancel" Then
        RedirectUrl = GetSTUDENT_CENSUS_DATARedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @4-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CENSUS_DATA Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CENSUS_DATA Cancel Operation tail

'Record Form STUDENT_CENSUS_DATA1 Parameters @133-EB220BCC

    Protected Sub STUDENT_CENSUS_DATA1Parameters()
        Dim item As new STUDENT_CENSUS_DATA1Item
        Try
            STUDENT_CENSUS_DATA1Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_CENSUS_DATA1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 Parameters

'Record Form STUDENT_CENSUS_DATA1 Show method @133-195C43B2
    Protected Sub STUDENT_CENSUS_DATA1Show()
        If STUDENT_CENSUS_DATA1Operations.None Then
            STUDENT_CENSUS_DATA1Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_CENSUS_DATA1Item = STUDENT_CENSUS_DATA1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CENSUS_DATA1Operations.AllowRead
        STUDENT_CENSUS_DATA1Errors.Add(item.errors)
        If STUDENT_CENSUS_DATA1Errors.Count > 0 Then
            STUDENT_CENSUS_DATA1ShowErrors()
            Return
        End If
'End Record Form STUDENT_CENSUS_DATA1 Show method

'Record Form STUDENT_CENSUS_DATA1 BeforeShow tail @133-AAEFC3D5
        STUDENT_CENSUS_DATA1Parameters()
        STUDENT_CENSUS_DATA1Data.FillItem(item, IsInsertMode)
        STUDENT_CENSUS_DATA1Holder.DataBind()
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION,New CCSControlAttribute("maxlength", FieldType._Text, ("190")))
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION,New CCSControlAttribute("maxlength", FieldType._Text, ("190")))
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION,New CCSControlAttribute("maxlength", FieldType._Text, ("190")))
        STUDENT_CENSUS_DATA1Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CENSUS_DATA1Operations.AllowUpdate
        STUDENT_CENSUS_DATA1STUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.RESTRICT_ACCESS_ATRISKItems.SetSelection(item.RESTRICT_ACCESS_ATRISK.GetFormattedValue())
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.SelectedIndex = -1
        item.RESTRICT_ACCESS_ATRISKItems.CopyTo(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.Items, True)
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION.Text=item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.GetFormattedValue()
        item.RESTRICT_ACCESS_ALERTItems.SetSelection(item.RESTRICT_ACCESS_ALERT.GetFormattedValue())
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.SelectedIndex = -1
        item.RESTRICT_ACCESS_ALERTItems.CopyTo(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.Items, True)
        item.RESTRICT_ACCESS_ALERT_RECEIVEDItems.SetSelection(item.RESTRICT_ACCESS_ALERT_RECEIVED.GetFormattedValue())
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.SelectedIndex = -1
        item.RESTRICT_ACCESS_ALERT_RECEIVEDItems.CopyTo(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.Items, True)
        item.RESTRICT_ACCESS_TYPEItems.SetSelection(item.RESTRICT_ACCESS_TYPE.GetFormattedValue())
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.SelectedIndex = -1
        item.RESTRICT_ACCESS_TYPEItems.CopyTo(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.Items, True)
        STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION.Text=item.RESTRICT_ACCESS_DESCRIPTION.GetFormattedValue()
        item.RESTRICT_ACTIVITY_ALERTItems.SetSelection(item.RESTRICT_ACTIVITY_ALERT.GetFormattedValue())
        STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.SelectedIndex = -1
        item.RESTRICT_ACTIVITY_ALERTItems.CopyTo(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.Items, True)
        STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION.Text=item.RESTRICT_ACTIVITY_DESCRIPTION.GetFormattedValue()
'End Record Form STUDENT_CENSUS_DATA1 BeforeShow tail

'RadioButton RESTRICT_ACCESS_TYPE Event BeforeShow. Action Custom Code @149-73254650
    ' -------------------------
       ' change layout 
		STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.RepeatColumns = 4
		STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.RepeatDirection = RepeatDirection.Horizontal
		STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton RESTRICT_ACCESS_TYPE Event BeforeShow. Action Custom Code

'Record Form STUDENT_CENSUS_DATA1 Show method tail @133-D6F26426
        If STUDENT_CENSUS_DATA1Errors.Count > 0 Then
            STUDENT_CENSUS_DATA1ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 Show method tail

'Record Form STUDENT_CENSUS_DATA1 LoadItemFromRequest method @133-4D0D3E23

    Protected Sub STUDENT_CENSUS_DATA1LoadItemFromRequest(item As STUDENT_CENSUS_DATA1Item, ByVal EnableValidation As Boolean)
        Try
        item.RESTRICT_ACCESS_ATRISK.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.SelectedItem) Then
            item.RESTRICT_ACCESS_ATRISK.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.SelectedItem.Value)
        Else
            item.RESTRICT_ACCESS_ATRISK.Value = Nothing
        End If
        item.RESTRICT_ACCESS_ATRISKItems.CopyFrom(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATA1Errors.Add("RESTRICT_ACCESS_ATRISK",String.Format(Resources.strings.CCS_IncorrectValue,"Is the Student AT RISK?"))
        End Try
        item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION") Is Nothing Then
            item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION.Text)
        Else
            item.RESTRICT_ACCESS_ATRISK_DESCRIPTION.SetValue(ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ATRISK_DESCRIPTION"))
        End If
        Try
        item.RESTRICT_ACCESS_ALERT.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.SelectedItem) Then
            item.RESTRICT_ACCESS_ALERT.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.SelectedItem.Value)
        Else
            item.RESTRICT_ACCESS_ALERT.Value = Nothing
        End If
        item.RESTRICT_ACCESS_ALERTItems.CopyFrom(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATA1Errors.Add("RESTRICT_ACCESS_ALERT",String.Format(Resources.strings.CCS_IncorrectValue,"Is there an ACCESS ALERT for the student?"))
        End Try
        Try
        item.RESTRICT_ACCESS_ALERT_RECEIVED.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.SelectedItem) Then
            item.RESTRICT_ACCESS_ALERT_RECEIVED.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.SelectedItem.Value)
        Else
            item.RESTRICT_ACCESS_ALERT_RECEIVED.Value = Nothing
        End If
        item.RESTRICT_ACCESS_ALERT_RECEIVEDItems.CopyFrom(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_ALERT_RECEIVED.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATA1Errors.Add("RESTRICT_ACCESS_ALERT_RECEIVED",String.Format(Resources.strings.CCS_IncorrectValue,"Has ACCESS ALERT been RECEIVED?"))
        End Try
        item.RESTRICT_ACCESS_TYPE.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.SelectedItem) Then
            item.RESTRICT_ACCESS_TYPE.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.SelectedItem.Value)
        Else
            item.RESTRICT_ACCESS_TYPE.Value = Nothing
        End If
        item.RESTRICT_ACCESS_TYPEItems.CopyFrom(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_TYPE.Items)
        item.RESTRICT_ACCESS_DESCRIPTION.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION") Is Nothing Then
            item.RESTRICT_ACCESS_DESCRIPTION.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION.Text)
        Else
            item.RESTRICT_ACCESS_DESCRIPTION.SetValue(ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACCESS_DESCRIPTION"))
        End If
        Try
        item.RESTRICT_ACTIVITY_ALERT.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.SelectedItem) Then
            item.RESTRICT_ACTIVITY_ALERT.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.SelectedItem.Value)
        Else
            item.RESTRICT_ACTIVITY_ALERT.Value = Nothing
        End If
        item.RESTRICT_ACTIVITY_ALERTItems.CopyFrom(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_ALERT.Items)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATA1Errors.Add("RESTRICT_ACTIVITY_ALERT",String.Format(Resources.strings.CCS_IncorrectValue,"Is there an ACTIVITY ALERT for the Student?"))
        End Try
        item.RESTRICT_ACTIVITY_DESCRIPTION.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION") Is Nothing Then
            item.RESTRICT_ACTIVITY_DESCRIPTION.SetValue(STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION.Text)
        Else
            item.RESTRICT_ACTIVITY_DESCRIPTION.SetValue(ControlCustomValues("STUDENT_CENSUS_DATA1RESTRICT_ACTIVITY_DESCRIPTION"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_CENSUS_DATA1Data)
        End If
        STUDENT_CENSUS_DATA1Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 LoadItemFromRequest method

'Record Form STUDENT_CENSUS_DATA1 GetRedirectUrl method @133-73BED826

    Protected Function GetSTUDENT_CENSUS_DATA1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CENSUS_DATA1 GetRedirectUrl method

'Record Form STUDENT_CENSUS_DATA1 ShowErrors method @133-DA9D28BD

    Protected Sub STUDENT_CENSUS_DATA1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CENSUS_DATA1Errors.Count - 1
        Select Case STUDENT_CENSUS_DATA1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CENSUS_DATA1Errors(i)
        End Select
        Next i
        STUDENT_CENSUS_DATA1Error.Visible = True
        STUDENT_CENSUS_DATA1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 ShowErrors method

'Record Form STUDENT_CENSUS_DATA1 Insert Operation @133-2A9972C4

    Protected Sub STUDENT_CENSUS_DATA1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATA1Item = New STUDENT_CENSUS_DATA1Item()
        STUDENT_CENSUS_DATA1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CENSUS_DATA1 Insert Operation

'Record Form STUDENT_CENSUS_DATA1 BeforeInsert tail @133-563347B0
    STUDENT_CENSUS_DATA1Parameters()
    STUDENT_CENSUS_DATA1LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CENSUS_DATA1 BeforeInsert tail

'Record Form STUDENT_CENSUS_DATA1 AfterInsert tail  @133-ED7022B9
        ErrorFlag=(STUDENT_CENSUS_DATA1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CENSUS_DATA1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 AfterInsert tail 

'Record Form STUDENT_CENSUS_DATA1 Update Operation @133-B69074AA

    Protected Sub STUDENT_CENSUS_DATA1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATA1Item = New STUDENT_CENSUS_DATA1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CENSUS_DATA1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CENSUS_DATA1 Update Operation

'Button Button_Update OnClick. @135-45992FA7
        If CType(sender,Control).ID = "STUDENT_CENSUS_DATA1Button_Update" Then
            RedirectUrl = GetSTUDENT_CENSUS_DATA1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @135-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT_CENSUS_DATA1 Before Update tail @133-481C4D6A
        STUDENT_CENSUS_DATA1Parameters()
        STUDENT_CENSUS_DATA1LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CENSUS_DATA1Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_CENSUS_DATA1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CENSUS_DATA1Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CENSUS_DATA1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CENSUS_DATA1 Before Update tail

'Record STUDENT_CENSUS_DATA1 Event AfterUpdate. Action Custom Code @148-73254650
    ' -------------------------
    'Oct 2020 new fields for 2020
    If (Not ErrorFlag) Then
       HttpContext.Current.Session("notifymessage") = "Item has been Updated"
    End If
    ' -------------------------
'End Record STUDENT_CENSUS_DATA1 Event AfterUpdate. Action Custom Code

'Record Form STUDENT_CENSUS_DATA1 Update Operation tail @133-102A668B
        End If
        ErrorFlag=(STUDENT_CENSUS_DATA1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CENSUS_DATA1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 Update Operation tail

'Record Form STUDENT_CENSUS_DATA1 Delete Operation @133-D8642671
    Protected Sub STUDENT_CENSUS_DATA1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CENSUS_DATA1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CENSUS_DATA1Item = New STUDENT_CENSUS_DATA1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CENSUS_DATA1 Delete Operation

'Record Form BeforeDelete tail @133-563347B0
        STUDENT_CENSUS_DATA1Parameters()
        STUDENT_CENSUS_DATA1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @133-B8608A4A
        If ErrorFlag Then
            STUDENT_CENSUS_DATA1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CENSUS_DATA1 Cancel Operation @133-450CEA76

    Protected Sub STUDENT_CENSUS_DATA1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CENSUS_DATA1Item = New STUDENT_CENSUS_DATA1Item()
        STUDENT_CENSUS_DATA1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CENSUS_DATA1LoadItemFromRequest(item, False)
'End Record Form STUDENT_CENSUS_DATA1 Cancel Operation

'Button Button_Cancel OnClick. @136-1CBE1310
    If CType(sender,Control).ID = "STUDENT_CENSUS_DATA1Button_Cancel" Then
        RedirectUrl = GetSTUDENT_CENSUS_DATA1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @136-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CENSUS_DATA1 Cancel Operation tail @133-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CENSUS_DATA1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-0A61F354
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Census_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CENSUS_DATAData = New STUDENT_CENSUS_DATADataProvider()
        STUDENT_CENSUS_DATAOperations = New FormSupportedOperations(False, True, False, True, False)
        STUDENT_CENSUS_DATA1Data = New STUDENT_CENSUS_DATA1DataProvider()
        STUDENT_CENSUS_DATA1Operations = New FormSupportedOperations(False, True, False, True, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'Page Student_Census_maintain Event AfterInitialize. Action Declare Variable @100-A42DCDB7
        Dim enrolCategory As String = ""
'End Page Student_Census_maintain Event AfterInitialize. Action Declare Variable

'Page Student_Census_maintain Event AfterInitialize. Action Declare Variable @105-2F95196C
        Dim tmpOverride As Int64 = 0
'End Page Student_Census_maintain Event AfterInitialize. Action Declare Variable

'Page Student_Census_maintain Event AfterInitialize. Action Declare Variable @106-8C94C996
        Dim tmpStudentID As String = ""
'End Page Student_Census_maintain Event AfterInitialize. Action Declare Variable

'Page Student_Census_maintain Event AfterInitialize. Action Retrieve Value for Variable @103-08015B6A
        tmpOverride = System.Web.HttpContext.Current.Request.QueryString("override")
'End Page Student_Census_maintain Event AfterInitialize. Action Retrieve Value for Variable

'Page Student_Census_maintain Event AfterInitialize. Action Retrieve Value for Variable @104-0F1C0A2D
        tmpStudentID = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
'End Page Student_Census_maintain Event AfterInitialize. Action Retrieve Value for Variable

'Page Student_Census_maintain Event AfterInitialize. Action DLookup @101-4AACE840
        enrolCategory = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim([CATEGORY_CODE])" & " FROM " & "STUDENT" & " WHERE " & "CATEGORY_CODE = 'TAFE' and STUDENT_ID = " & tmpStudentID.ToString()))).Value, String)
'End Page Student_Census_maintain Event AfterInitialize. Action DLookup

'Page Student_Census_maintain Event AfterInitialize. Action Custom Code @102-73254650
    ' -------------------------
    ' ERA: if enrolCategory = "TAFE" and url override <> 1 then redirect to Student_CensusTAFE_maintain
	if (enrolCategory = "TAFE" and tmpOverride <> 1) then
		Response.Redirect("Student_CensusTAFE_maintain.aspx" & "?" & Request("QUERY_STRING"))
	end if
    ' -------------------------
'End Page Student_Census_maintain Event AfterInitialize. Action Custom Code

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

