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

Namespace DECV_PROD2007.Student_CensusTAFE_maintain 'Namespace @1-FDC600AB

'Forms Definition @1-7D625F17
Public Class [Student_CensusTAFE_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F9F788F9
    Protected STUDENT_CENSUS_DATAData As STUDENT_CENSUS_DATADataProvider
    Protected STUDENT_CENSUS_DATAErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CENSUS_DATAOperations As FormSupportedOperations
    Protected STUDENT_CENSUS_DATAIsSubmitted As Boolean = False
    Protected Student_CensusTAFE_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-411B47B8
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CENSUS_DATAShow()
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

'Record Form STUDENT_CENSUS_DATA Show method @2-FEF45582
    Protected Sub STUDENT_CENSUS_DATAShow()
        If STUDENT_CENSUS_DATAOperations.None Then
            STUDENT_CENSUS_DATAHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_CENSUS_DATAItem = STUDENT_CENSUS_DATAItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CENSUS_DATAOperations.AllowRead
        item.Link_gotoCensusPageHref = "Student_Census_maintain.aspx"
        item.Link_gotoCensusPageHrefParameters.Add("override",System.Web.HttpUtility.UrlEncode((1).ToString()))
        STUDENT_CENSUS_DATAErrors.Add(item.errors)
        If STUDENT_CENSUS_DATAErrors.Count > 0 Then
            STUDENT_CENSUS_DATAShowErrors()
            Return
        End If
'End Record Form STUDENT_CENSUS_DATA Show method

'Record Form STUDENT_CENSUS_DATA BeforeShow tail @2-9F8A3AF8
        STUDENT_CENSUS_DATAParameters()
        STUDENT_CENSUS_DATAData.FillItem(item, IsInsertMode)
        STUDENT_CENSUS_DATAHolder.DataBind()
        STUDENT_CENSUS_DATAButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CENSUS_DATAOperations.AllowUpdate
        STUDENT_CENSUS_DATASTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAPREVIOUS_SCHOOL_ID.Text=item.PREVIOUS_SCHOOL_ID.GetFormattedValue()
        STUDENT_CENSUS_DATADISABILITY_ID.Text=item.DISABILITY_ID.GetFormattedValue()
        STUDENT_CENSUS_DATALAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATALAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAHidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STUDENT_CENSUS_DATAHidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STUDENT_CENSUS_DATASCHOOL_NAME.Text=item.SCHOOL_NAME.GetFormattedValue()
        STUDENT_CENSUS_DATAlblPREVIOUS_SCHOOL_NAME.Text = Server.HtmlEncode(item.lblPREVIOUS_SCHOOL_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
        STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT.Text=item.DISABILITY_OTHER_TEXT.GetFormattedValue()
        item.RadioButton_EnglishProficiencyItems.SetSelection(item.RadioButton_EnglishProficiency.GetFormattedValue())
        STUDENT_CENSUS_DATARadioButton_EnglishProficiency.SelectedIndex = -1
        item.RadioButton_EnglishProficiencyItems.CopyTo(STUDENT_CENSUS_DATARadioButton_EnglishProficiency.Items)
        STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.Text=item.DATE_LAST_ATTENDED_SCHOOL.GetFormattedValue()
        item.HIGHEST_SCHOOL_LEVELItems.SetSelection(item.HIGHEST_SCHOOL_LEVEL.GetFormattedValue())
        STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.SelectedIndex = -1
        item.HIGHEST_SCHOOL_LEVELItems.CopyTo(STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.Items)
        If (Not IsNothing(Request.QueryString("CheckBoxList_Disability")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("CheckBoxList_Disability").GetUpperBound(0)
                item.CheckBoxList_DisabilityItems.SetSelection(Request.QueryString.GetValues("CheckBoxList_Disability")(i))
            Next i
        End If
        item.CheckBoxList_DisabilityItems.SetSelection(item.CheckBoxList_Disability.Value)
        STUDENT_CENSUS_DATACheckBoxList_Disability.SelectedIndex = -1
        item.CheckBoxList_DisabilityItems.CopyTo(STUDENT_CENSUS_DATACheckBoxList_Disability.Items)
        item.RadioButton_Employment_StatusItems.SetSelection(item.RadioButton_Employment_Status.GetFormattedValue())
        STUDENT_CENSUS_DATARadioButton_Employment_Status.SelectedIndex = -1
        item.RadioButton_Employment_StatusItems.CopyTo(STUDENT_CENSUS_DATARadioButton_Employment_Status.Items)
        item.RadioButton_Reason_for_StudyItems.SetSelection(item.RadioButton_Reason_for_Study.GetFormattedValue())
        STUDENT_CENSUS_DATARadioButton_Reason_for_Study.SelectedIndex = -1
        item.RadioButton_Reason_for_StudyItems.CopyTo(STUDENT_CENSUS_DATARadioButton_Reason_for_Study.Items)
        If (Not IsNothing(Request.QueryString("CheckBoxList_PriorQualifications")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("CheckBoxList_PriorQualifications").GetUpperBound(0)
                item.CheckBoxList_PriorQualificationsItems.SetSelection(Request.QueryString.GetValues("CheckBoxList_PriorQualifications")(i))
            Next i
        End If
        item.CheckBoxList_PriorQualificationsItems.SetSelection(item.CheckBoxList_PriorQualifications.Value)
        STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.SelectedIndex = -1
        item.CheckBoxList_PriorQualificationsItems.CopyTo(STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.Items)
        STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT.Text=item.PRIORQUALIFICATIONS_OTHER_TEXT.GetFormattedValue()
        STUDENT_CENSUS_DATAlblCheckDisability.Text = Server.HtmlEncode(item.lblCheckDisability.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CENSUS_DATAHidden_DisabilityList.Value = item.Hidden_DisabilityList.GetFormattedValue()
        STUDENT_CENSUS_DATAHidden_PriorQualificationsList.Value = item.Hidden_PriorQualificationsList.GetFormattedValue()
        STUDENT_CENSUS_DATALink_gotoCensusPage.InnerText += item.Link_gotoCensusPage.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CENSUS_DATALink_gotoCensusPage.HRef = item.Link_gotoCensusPageHref+item.Link_gotoCensusPageHrefParameters.ToString("GET","", ViewState)
'End Record Form STUDENT_CENSUS_DATA BeforeShow tail

'Label lblPREVIOUS_SCHOOL_NAME Event BeforeShow. Action Custom Code @96-73254650
    ' -------------------------
    'ERA:
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

'RadioButton HIGHEST_SCHOOL_LEVEL Event BeforeShow. Action Custom Code @105-73254650
    ' -------------------------
	'6-Apr-2011|EA| change layout of Completed school level radio, into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.RepeatColumns = 2
	STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.RepeatLayout = RepeatLayout.Table
	'STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton HIGHEST_SCHOOL_LEVEL Event BeforeShow. Action Custom Code

'CheckBoxList CheckBoxList_Disability Event BeforeShow. Action Custom Code @100-73254650
    ' -------------------------
    '6-Apr-2011|EA| change layout of Disability checkboxes, into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATACheckBoxList_Disability.RepeatColumns = 2
	STUDENT_CENSUS_DATACheckBoxList_Disability.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATACheckBoxList_Disability.RepeatLayout = RepeatLayout.Table
	'STUDENT_CENSUS_DATACheckBoxList_Disability.TextAlign = TextAlign.Right
    ' -------------------------
'End CheckBoxList CheckBoxList_Disability Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Employment_Status Event BeforeShow. Action Custom Code @107-73254650
    ' -------------------------
	'6-Apr-2011|EA| change layout of Employment Status radio, into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATARadioButton_Employment_Status.RepeatColumns = 2
	STUDENT_CENSUS_DATARadioButton_Employment_Status.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATARadioButton_Employment_Status.RepeatLayout = RepeatLayout.Table
	'STUDENT_CENSUS_DATARadioButton_Employment_Status.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Employment_Status Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Reason_for_Study Event BeforeShow. Action Custom Code @109-73254650
    ' -------------------------
     '6-Apr-2011|EA| change layout of Reason for Study radio, into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATARadioButton_Reason_for_Study.RepeatColumns = 2
	STUDENT_CENSUS_DATARadioButton_Reason_for_Study.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATARadioButton_Reason_for_Study.RepeatLayout = RepeatLayout.Table
	'STUDENT_CENSUS_DATARadioButton_Reason_for_Study.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Reason_for_Study Event BeforeShow. Action Custom Code

'CheckBoxList CheckBoxList_PriorQualifications Event BeforeShow. Action Custom Code @111-73254650
    ' -------------------------
    '11-Apr-2011|EA| change layout of PriorQualifications checkboxes, into 2 columns, repeat horiz, left align.
	STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.RepeatColumns = 2
	STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.RepeatLayout = RepeatLayout.Table
	'STUDENT_CENSUS_DATACheckBoxList_Disability.TextAlign = TextAlign.Right
    ' -------------------------
'End CheckBoxList CheckBoxList_PriorQualifications Event BeforeShow. Action Custom Code

'Label lblCheckDisability Event BeforeShow. Action Retrieve Value for Control @116-CC8F0E7F
            STUDENT_CENSUS_DATAlblCheckDisability.Text = (New TextField("", (item.CheckBoxList_Disability.Value))).GetFormattedValue()
'End Label lblCheckDisability Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_CENSUS_DATA Event BeforeShow. Action Custom Code @114-73254650
    ' -------------------------
    '11-Apr-2011|EA| check the checkbox lists for Disability 
	' using example code from ExamplePack 1. Steps through options and checks all that apply.
	' Main change is we use list of items not from database

'	' split up the string into an array
	'Dim checkItemsDis As String() = item.CheckBoxList_Disability.Value.Split(New Char() {","c})

	if (item.Hidden_DisabilityList.Value <> "0" and item.Hidden_DisabilityList.Value <> "0,") then

		Dim checkItemsDis As String() = item.Hidden_DisabilityList.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis As String = ""
		For Each thisItemDis In checkItemsDis
			' set that item as checked
			item.CheckBoxList_DisabilityItems.SetSelection(thisItemDis)
		Next
		' and display
		STUDENT_CENSUS_DATACheckBoxList_Disability.Items.Clear()
	    item.CheckBoxList_DisabilityItems.CopyTo(STUDENT_CENSUS_DATACheckBoxList_Disability.Items)
	end if
 
    ' -------------------------
'End Record STUDENT_CENSUS_DATA Event BeforeShow. Action Custom Code

'Record STUDENT_CENSUS_DATA Event BeforeShow. Action Custom Code @117-73254650
    ' -------------------------

    '11-Apr-2011|EA| check the checkbox lists for Prior Qualification
	' using example code from ExamplePack 1. Steps through options and checks all that apply.
	' Main change is we use list of items not from database

	if (item.Hidden_PriorQualificationsList.Value <> "0" and item.Hidden_PriorQualificationsList.Value <> "0,") then

		' split up the string into an array
		Dim checkItemsPQ As String() = item.Hidden_PriorQualificationsList.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemPQ As String = ""

		For Each thisItemPQ In checkItemsPQ
			' set that item as checked
			item.CheckBoxList_PriorQualificationsItems.SetSelection(thisItemPQ)
		Next

		' and display
		STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.Items.Clear()
    	item.CheckBoxList_PriorQualificationsItems.CopyTo(STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.Items)
	end if
 
    ' -------------------------
'End Record STUDENT_CENSUS_DATA Event BeforeShow. Action Custom Code

'Record Form STUDENT_CENSUS_DATA Show method tail @2-F6A88156
        If STUDENT_CENSUS_DATAErrors.Count > 0 Then
            STUDENT_CENSUS_DATAShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CENSUS_DATA Show method tail

'Record Form STUDENT_CENSUS_DATA LoadItemFromRequest method @2-358C7E41

    Protected Sub STUDENT_CENSUS_DATALoadItemFromRequest(item As STUDENT_CENSUS_DATAItem, ByVal EnableValidation As Boolean)
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
        item.DISABILITY_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADISABILITY_ID.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_ID") Is Nothing Then
            item.DISABILITY_ID.SetValue(STUDENT_CENSUS_DATADISABILITY_ID.Text)
        Else
            item.DISABILITY_ID.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_ID"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DISABILITY_ID",String.Format(Resources.strings.CCS_IncorrectValue,"DISABILITY ID"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STUDENT_CENSUS_DATAHidden_last_altered_by.Value)
        Try
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STUDENT_CENSUS_DATAHidden_last_altered_date.Value)
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("Hidden_last_altered_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_last_altered_date","yyyy-mm-dd H:nn"))
        End Try
        item.SCHOOL_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATASCHOOL_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATASCHOOL_NAME") Is Nothing Then
            item.SCHOOL_NAME.SetValue(STUDENT_CENSUS_DATASCHOOL_NAME.Text)
        Else
            item.SCHOOL_NAME.SetValue(ControlCustomValues("STUDENT_CENSUS_DATASCHOOL_NAME"))
        End If
        item.DISABILITY_OTHER_TEXT.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT") Is Nothing Then
            item.DISABILITY_OTHER_TEXT.SetValue(STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT.Text)
        Else
            item.DISABILITY_OTHER_TEXT.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADISABILITY_OTHER_TEXT"))
        End If
        item.RadioButton_EnglishProficiency.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATARadioButton_EnglishProficiency.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATARadioButton_EnglishProficiency.SelectedItem) Then
            item.RadioButton_EnglishProficiency.SetValue(STUDENT_CENSUS_DATARadioButton_EnglishProficiency.SelectedItem.Value)
        Else
            item.RadioButton_EnglishProficiency.Value = Nothing
        End If
        item.RadioButton_EnglishProficiencyItems.CopyFrom(STUDENT_CENSUS_DATARadioButton_EnglishProficiency.Items)
        Try
        item.DATE_LAST_ATTENDED_SCHOOL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL") Is Nothing Then
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL.Text)
        Else
            item.DATE_LAST_ATTENDED_SCHOOL.SetValue(ControlCustomValues("STUDENT_CENSUS_DATADATE_LAST_ATTENDED_SCHOOL"))
        End If
        Catch ae As ArgumentException
            STUDENT_CENSUS_DATAErrors.Add("DATE_LAST_ATTENDED_SCHOOL",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE LAST ATTENDED SCHOOL","dd/mm/yyyy"))
        End Try
        item.HIGHEST_SCHOOL_LEVEL.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.SelectedItem) Then
            item.HIGHEST_SCHOOL_LEVEL.SetValue(STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.SelectedItem.Value)
        Else
            item.HIGHEST_SCHOOL_LEVEL.Value = Nothing
        End If
        item.HIGHEST_SCHOOL_LEVELItems.CopyFrom(STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.Items)
        If Not IsNothing(STUDENT_CENSUS_DATACheckBoxList_Disability.SelectedItem) Then
            item.CheckBoxList_Disability.SetValue(STUDENT_CENSUS_DATACheckBoxList_Disability.SelectedItem.Value)
        Else
            item.CheckBoxList_Disability.Value = Nothing
        End If
        item.CheckBoxList_DisabilityItems.CopyFrom(STUDENT_CENSUS_DATACheckBoxList_Disability.Items)
        item.RadioButton_Employment_Status.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATARadioButton_Employment_Status.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATARadioButton_Employment_Status.SelectedItem) Then
            item.RadioButton_Employment_Status.SetValue(STUDENT_CENSUS_DATARadioButton_Employment_Status.SelectedItem.Value)
        Else
            item.RadioButton_Employment_Status.Value = Nothing
        End If
        item.RadioButton_Employment_StatusItems.CopyFrom(STUDENT_CENSUS_DATARadioButton_Employment_Status.Items)
        item.RadioButton_Reason_for_Study.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATARadioButton_Reason_for_Study.UniqueID))
        If Not IsNothing(STUDENT_CENSUS_DATARadioButton_Reason_for_Study.SelectedItem) Then
            item.RadioButton_Reason_for_Study.SetValue(STUDENT_CENSUS_DATARadioButton_Reason_for_Study.SelectedItem.Value)
        Else
            item.RadioButton_Reason_for_Study.Value = Nothing
        End If
        item.RadioButton_Reason_for_StudyItems.CopyFrom(STUDENT_CENSUS_DATARadioButton_Reason_for_Study.Items)
        If Not IsNothing(STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.SelectedItem) Then
            item.CheckBoxList_PriorQualifications.SetValue(STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.SelectedItem.Value)
        Else
            item.CheckBoxList_PriorQualifications.Value = Nothing
        End If
        item.CheckBoxList_PriorQualificationsItems.CopyFrom(STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.Items)
        item.PRIORQUALIFICATIONS_OTHER_TEXT.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT.UniqueID))
        If ControlCustomValues("STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT") Is Nothing Then
            item.PRIORQUALIFICATIONS_OTHER_TEXT.SetValue(STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT.Text)
        Else
            item.PRIORQUALIFICATIONS_OTHER_TEXT.SetValue(ControlCustomValues("STUDENT_CENSUS_DATAPRIORQUALIFICATIONS_OTHER_TEXT"))
        End If
        item.Hidden_DisabilityList.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_DisabilityList.UniqueID))
        item.Hidden_DisabilityList.SetValue(STUDENT_CENSUS_DATAHidden_DisabilityList.Value)
        item.Hidden_PriorQualificationsList.IsEmpty = IsNothing(Request.Form(STUDENT_CENSUS_DATAHidden_PriorQualificationsList.UniqueID))
        item.Hidden_PriorQualificationsList.SetValue(STUDENT_CENSUS_DATAHidden_PriorQualificationsList.Value)
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

'Record Form STUDENT_CENSUS_DATA ShowErrors method @2-65602E5C

    Protected Sub STUDENT_CENSUS_DATAShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CENSUS_DATAErrors.Count - 1
        Select Case STUDENT_CENSUS_DATAErrors.AllKeys(i)
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

'Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Custom Code @113-73254650
    ' -------------------------
    ' ERA: get the "Disability" and "Prior Qualifications" checkboxes that have been selected, and make comma-delimited strings for saving.
	' combine the selected array items then join to string
	Dim checkItemsPQ as String = "0,"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STUDENT_CENSUS_DATACheckBoxList_PriorQualifications.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	'debug
	'checkItemsPQ = "008,410,514"
	'response.write(checkItemsPQ)

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_CENSUS_DATAHidden_PriorQualificationsList.Value = (checkItemsPQ.TrimEnd(","C))
	
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_CENSUS_DATACheckBoxList_Disability.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	'debug
	'checkItemsDis = "11,13,15"
	'response.write(checkItemsDis)

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_CENSUS_DATAHidden_DisabilityList.Value = (checkItemsDis.TrimEnd(","C))
	
    ' -------------------------
'End Record STUDENT_CENSUS_DATA Event BeforeUpdate. Action Custom Code

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

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-DCFE7900
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_CensusTAFE_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CENSUS_DATAData = New STUDENT_CENSUS_DATADataProvider()
        STUDENT_CENSUS_DATAOperations = New FormSupportedOperations(False, True, False, True, False)
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

