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

Namespace DECV_PROD2007.Student_DiagnosisConfirmed_maintain 'Namespace @1-6FBCFF09

'Forms Definition @1-F8B62599
Public Class [Student_DiagnosisConfirmed_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-FAB2DCDE
    Protected STUDENT_DIAGNOSIS_DATAData As STUDENT_DIAGNOSIS_DATADataProvider
    Protected STUDENT_DIAGNOSIS_DATAErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_DIAGNOSIS_DATAOperations As FormSupportedOperations
    Protected STUDENT_DIAGNOSIS_DATAIsSubmitted As Boolean = False
    Protected Student_DiagnosisConfirmed_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-1F9AC8AB
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_DIAGNOSIS_DATAShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_DIAGNOSIS_DATA Parameters @2-26E2012B

    Protected Sub STUDENT_DIAGNOSIS_DATAParameters()
        Dim item As new STUDENT_DIAGNOSIS_DATAItem
        Try
            STUDENT_DIAGNOSIS_DATAData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_DIAGNOSIS_DATAData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)
        Catch e As Exception
            STUDENT_DIAGNOSIS_DATAErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA Parameters

'Record Form STUDENT_DIAGNOSIS_DATA Show method @2-DCFF6DDA
    Protected Sub STUDENT_DIAGNOSIS_DATAShow()
        If STUDENT_DIAGNOSIS_DATAOperations.None Then
            STUDENT_DIAGNOSIS_DATAHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_DIAGNOSIS_DATAItem = STUDENT_DIAGNOSIS_DATAItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_DIAGNOSIS_DATAOperations.AllowRead
        STUDENT_DIAGNOSIS_DATAErrors.Add(item.errors)
        If STUDENT_DIAGNOSIS_DATAErrors.Count > 0 Then
            STUDENT_DIAGNOSIS_DATAShowErrors()
            Return
        End If
'End Record Form STUDENT_DIAGNOSIS_DATA Show method

'Record Form STUDENT_DIAGNOSIS_DATA BeforeShow tail @2-71B6A859
        STUDENT_DIAGNOSIS_DATAParameters()
        STUDENT_DIAGNOSIS_DATAData.FillItem(item, IsInsertMode)
        STUDENT_DIAGNOSIS_DATAHolder.DataBind()
        STUDENT_DIAGNOSIS_DATAButton_Insert.Visible=IsInsertMode AndAlso STUDENT_DIAGNOSIS_DATAOperations.AllowInsert
        STUDENT_DIAGNOSIS_DATAButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_DIAGNOSIS_DATAOperations.AllowUpdate
        STUDENT_DIAGNOSIS_DATASTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS.Text=item.WELLBEING_COMMENTS.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATALAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_DIAGNOSIS_DATALAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER.Text=item.STUDENT_INCLUSION_OTHER.GetFormattedValue()
        item.RadioButton_ReferredByItems.SetSelection(item.RadioButton_ReferredBy.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.SelectedIndex = -1
        item.RadioButton_ReferredByItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.Items)
        If (Not IsNothing(Request.QueryString("SUPPORT_AT_ENROLMENT_TYPE")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("SUPPORT_AT_ENROLMENT_TYPE").GetUpperBound(0)
                item.SUPPORT_AT_ENROLMENT_TYPEItems.SetSelection(Request.QueryString.GetValues("SUPPORT_AT_ENROLMENT_TYPE")(i))
            Next i
        End If
        item.SUPPORT_AT_ENROLMENT_TYPEItems.SetSelection(item.SUPPORT_AT_ENROLMENT_TYPE.Value)
        STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.SelectedIndex = -1
        item.SUPPORT_AT_ENROLMENT_TYPEItems.CopyTo(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items)
        If (Not IsNothing(Request.QueryString("CheckBoxList_Wellbeing")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("CheckBoxList_Wellbeing").GetUpperBound(0)
                item.CheckBoxList_WellbeingItems.SetSelection(Request.QueryString.GetValues("CheckBoxList_Wellbeing")(i))
            Next i
        End If
        item.CheckBoxList_WellbeingItems.SetSelection(item.CheckBoxList_Wellbeing.Value)
        STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.SelectedIndex = -1
        item.CheckBoxList_WellbeingItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items)
        item.RadioButton_ReactivationItems.SetSelection(item.RadioButton_Reactivation.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.SelectedIndex = -1
        item.RadioButton_ReactivationItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.Items)
        item.RadioButton_Previous_EnrolItems.SetSelection(item.RadioButton_Previous_Enrol.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.SelectedIndex = -1
        item.RadioButton_Previous_EnrolItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.Items)
        If (Not IsNothing(Request.QueryString("CheckBoxList_Inclusion")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("CheckBoxList_Inclusion").GetUpperBound(0)
                item.CheckBoxList_InclusionItems.SetSelection(Request.QueryString.GetValues("CheckBoxList_Inclusion")(i))
            Next i
        End If
        item.CheckBoxList_InclusionItems.SetSelection(item.CheckBoxList_Inclusion.Value)
        STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.SelectedIndex = -1
        item.CheckBoxList_InclusionItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items)
        STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER.Text=item.STUDENT_WELLBEING_OTHER.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value = item.Hidden_WellbeingList.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value = item.Hidden_InclusionList.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAlist_REGION.Items.Add(new ListItem("Select Value",""))
        STUDENT_DIAGNOSIS_DATAlist_REGION.Items(0).Selected = True
        item.list_REGIONItems.SetSelection(item.list_REGION.GetFormattedValue())
        If Not item.list_REGIONItems.GetSelectedItem() Is Nothing Then
            STUDENT_DIAGNOSIS_DATAlist_REGION.SelectedIndex = -1
        End If
        item.list_REGIONItems.CopyTo(STUDENT_DIAGNOSIS_DATAlist_REGION.Items)
        item.RadioButton_SupportItems.SetSelection(item.RadioButton_Support.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Support.SelectedIndex = -1
        item.RadioButton_SupportItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Support.Items)
        STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value = item.Hidden_SupportList.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAHidden_enrolyear.Value = item.Hidden_enrolyear.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAHidden_StudentId.Value = item.Hidden_StudentId.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STUDENT_DIAGNOSIS_DATAENROLMENT_YEAR.Text = Server.HtmlEncode(item.ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.RadioButton_ReferralItems.SetSelection(item.RadioButton_Referral.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Referral.SelectedIndex = -1
        item.RadioButton_ReferralItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Referral.Items)
        item.RadioButton_InclusionItems.SetSelection(item.RadioButton_Inclusion.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.SelectedIndex = -1
        item.RadioButton_InclusionItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.Items)
        item.RadioButton_WellbeingItems.SetSelection(item.RadioButton_Wellbeing.GetFormattedValue())
        STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.SelectedIndex = -1
        item.RadioButton_WellbeingItems.CopyTo(STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.Items)
'End Record Form STUDENT_DIAGNOSIS_DATA BeforeShow tail

'RadioButton RadioButton_ReferredBy Event BeforeShow. Action Custom Code @131-73254650
    ' -------------------------
    '16/7/2015|EA| change layout of Referred by
    STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatColumns = 3
	STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatDirection = RepeatDirection.Vertical
	STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatLayout = RepeatLayout.Table
	'STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_ReferredBy Event BeforeShow. Action Custom Code

'CheckBoxList SUPPORT_AT_ENROLMENT_TYPE Event BeforeShow. Action Custom Code @105-73254650
    ' -------------------------
  	'6-Apr-2011|EA| change layout of Completed school level radio, into 2 columns, repeat horiz, left align.
  	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatColumns = 3
  	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatDirection = RepeatDirection.Vertical
  	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatLayout = RepeatLayout.Table
  	'STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.TextAlign = TextAlign.Right
    ' -------------------------
'End CheckBoxList SUPPORT_AT_ENROLMENT_TYPE Event BeforeShow. Action Custom Code

'CheckBoxList CheckBoxList_Wellbeing Event BeforeShow. Action Custom Code @100-73254650
    ' -------------------------
    '16/7/2015|EA| change layout of Disability checkboxes, into 2 columns, repeat horiz, left align.
	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatColumns = 3
	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatDirection = RepeatDirection.Vertical
	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatLayout = RepeatLayout.Table
	'STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.TextAlign = TextAlign.Right
    ' -------------------------
'End CheckBoxList CheckBoxList_Wellbeing Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Reactivation Event BeforeShow. Action Custom Code @107-73254650
    ' -------------------------
	'16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatLayout = RepeatLayout.Flow
	'STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Reactivation Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Previous_Enrol Event BeforeShow. Action Custom Code @109-73254650
    ' -------------------------
     '16/7/2015|EA| change layout
	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatLayout = RepeatLayout.Flow
	'STUDENT_CENSUS_DATARadioButton_Reason_for_Study.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Previous_Enrol Event BeforeShow. Action Custom Code

'CheckBoxList CheckBoxList_Inclusion Event BeforeShow. Action Custom Code @111-73254650
    ' -------------------------
    '16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatDirection = RepeatDirection.Vertical
	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatLayout = RepeatLayout.Table
	'STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.TextAlign = TextAlign.Right
    ' -------------------------
'End CheckBoxList CheckBoxList_Inclusion Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Support Event BeforeShow. Action Custom Code @133-73254650
    ' -------------------------
	'16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatColumns = 3
	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatLayout = RepeatLayout.Flow
	'STUDENT_DIAGNOSIS_DATARadioButton_Support.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Support Event BeforeShow. Action Custom Code


'Hidden Hidden_enrolyear Event BeforeShow. Action Retrieve Value for Control @147-D61B4146
            STUDENT_DIAGNOSIS_DATAHidden_enrolyear.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Hidden Hidden_enrolyear Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_StudentId Event BeforeShow. Action Retrieve Value for Control @141-C5ABF311
            STUDENT_DIAGNOSIS_DATAHidden_StudentId.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden Hidden_StudentId Event BeforeShow. Action Retrieve Value for Control

'RadioButton RadioButton_Referral Event BeforeShow. Action Custom Code @171-73254650
    ' -------------------------
	'16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatLayout = RepeatLayout.Flow
	'STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Referral Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Inclusion Event BeforeShow. Action Custom Code @178-73254650
    ' -------------------------
	'16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatLayout = RepeatLayout.Flow
	'STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Inclusion Event BeforeShow. Action Custom Code

'RadioButton RadioButton_Wellbeing Event BeforeShow. Action Custom Code @180-73254650
    ' -------------------------
	'16/7/2015|EA| change layout 
	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatColumns = 2
	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatDirection = RepeatDirection.Horizontal
	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatLayout = RepeatLayout.Flow
	'STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.TextAlign = TextAlign.Right
    ' -------------------------
'End RadioButton RadioButton_Wellbeing Event BeforeShow. Action Custom Code

'Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code @114-73254650
    ' -------------------------
    '11-Apr-2011|EA| check the checkbox lists for Wellbeing 
	' using example code from ExamplePack 1. Steps through options and checks all that apply.
	' Main change is we use list of items not from database

	if (item.Hidden_WellbeingList.Value <> "0" and item.Hidden_WellbeingList.Value <> "0,") then

		Dim checkItemsDis As String() = item.Hidden_WellbeingList.Value.Split(New Char() {","c})
	'	' loop through checkboxitems and compare against the array
		Dim thisItemDis As String = ""
		For Each thisItemDis In checkItemsDis
			' set that item as checked
			item.CheckBoxList_WellbeingItems.SetSelection(thisItemDis)
		Next
		' and display
		STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items.Clear()
	    item.CheckBoxList_WellbeingItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items)
	end if
 
    ' -------------------------
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code

'Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code @117-73254650
    ' -------------------------

    '11-Apr-2011|EA| check the checkbox lists for Inclusion
	
	if (item.Hidden_InclusionList.Value <> "0" and item.Hidden_InclusionList.Value <> "0,") then

		' split up the string into an array
		Dim checkItemsPQ As String() = item.Hidden_InclusionList.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemPQ As String = ""

		For Each thisItemPQ In checkItemsPQ
			' set that item as checked
			item.CheckBoxList_InclusionItems.SetSelection(thisItemPQ)
		Next

		' and display
		STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items.Clear()
    	item.CheckBoxList_InclusionItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items)
	end if
 
    ' -------------------------
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code

'Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code @138-73254650
    ' -------------------------
     '16/7/2015|EA| check the checkbox lists for Support
     '17/9/2015|EA| fix as was pointing to the Yes/No radio button
	
	if (item.Hidden_SupportList.Value <> "0" and item.Hidden_SupportList.Value <> "0,") then

		' split up the string into an array
		Dim checkItemsSup As String() = item.Hidden_SupportList.Value.Split(New Char() {","c})
		' loop through checkboxitems and compare against the array
		Dim thisItemSup As String = ""

		For Each thisItemSup In checkItemsSup
			' set that item as checked
			item.SUPPORT_AT_ENROLMENT_TYPEItems.SetSelection(thisItemSup)
		Next

		' and display
		STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items.Clear()
    	item.SUPPORT_AT_ENROLMENT_TYPEItems.CopyTo(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items)
	end if
 
    ' -------------------------
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeShow. Action Custom Code

'Record Form STUDENT_DIAGNOSIS_DATA Show method tail @2-90F6B11F
        If STUDENT_DIAGNOSIS_DATAErrors.Count > 0 Then
            STUDENT_DIAGNOSIS_DATAShowErrors()
        End If
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA Show method tail

'Record Form STUDENT_DIAGNOSIS_DATA LoadItemFromRequest method @2-2F1C5A70

    Protected Sub STUDENT_DIAGNOSIS_DATALoadItemFromRequest(item As STUDENT_DIAGNOSIS_DATAItem, ByVal EnableValidation As Boolean)
        item.WELLBEING_COMMENTS.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS.UniqueID))
        If ControlCustomValues("STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS") Is Nothing Then
            item.WELLBEING_COMMENTS.SetValue(STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS.Text)
        Else
            item.WELLBEING_COMMENTS.SetValue(ControlCustomValues("STUDENT_DIAGNOSIS_DATAWELLBEING_COMMENTS"))
        End If
        Try
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STUDENT_DIAGNOSIS_DATAHidden_last_altered_date.Value)
        Catch ae As ArgumentException
            STUDENT_DIAGNOSIS_DATAErrors.Add("Hidden_last_altered_date",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_last_altered_date","yyyy-mm-dd H:nn"))
        End Try
        item.STUDENT_INCLUSION_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER") Is Nothing Then
            item.STUDENT_INCLUSION_OTHER.SetValue(STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER.Text)
        Else
            item.STUDENT_INCLUSION_OTHER.SetValue(ControlCustomValues("STUDENT_DIAGNOSIS_DATASTUDENT_INCLUSION_OTHER"))
        End If
        item.RadioButton_ReferredBy.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.SelectedItem) Then
            item.RadioButton_ReferredBy.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.SelectedItem.Value)
        Else
            item.RadioButton_ReferredBy.Value = Nothing
        End If
        item.RadioButton_ReferredByItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.Items)
        If Not IsNothing(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.SelectedItem) Then
            item.SUPPORT_AT_ENROLMENT_TYPE.SetValue(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.SelectedItem.Value)
        Else
            item.SUPPORT_AT_ENROLMENT_TYPE.Value = Nothing
        End If
        item.SUPPORT_AT_ENROLMENT_TYPEItems.CopyFrom(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items)
        If Not IsNothing(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.SelectedItem) Then
            item.CheckBoxList_Wellbeing.SetValue(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.SelectedItem.Value)
        Else
            item.CheckBoxList_Wellbeing.Value = Nothing
        End If
        item.CheckBoxList_WellbeingItems.CopyFrom(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items)
        item.RadioButton_Reactivation.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.SelectedItem) Then
            item.RadioButton_Reactivation.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.SelectedItem.Value)
        Else
            item.RadioButton_Reactivation.Value = Nothing
        End If
        item.RadioButton_ReactivationItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.Items)
        item.RadioButton_Previous_Enrol.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.SelectedItem) Then
            item.RadioButton_Previous_Enrol.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.SelectedItem.Value)
        Else
            item.RadioButton_Previous_Enrol.Value = Nothing
        End If
        item.RadioButton_Previous_EnrolItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.Items)
        If Not IsNothing(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.SelectedItem) Then
            item.CheckBoxList_Inclusion.SetValue(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.SelectedItem.Value)
        Else
            item.CheckBoxList_Inclusion.Value = Nothing
        End If
        item.CheckBoxList_InclusionItems.CopyFrom(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items)
        item.STUDENT_WELLBEING_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER") Is Nothing Then
            item.STUDENT_WELLBEING_OTHER.SetValue(STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER.Text)
        Else
            item.STUDENT_WELLBEING_OTHER.SetValue(ControlCustomValues("STUDENT_DIAGNOSIS_DATASTUDENT_WELLBEING_OTHER"))
        End If
        item.Hidden_WellbeingList.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.UniqueID))
        item.Hidden_WellbeingList.SetValue(STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value)
        item.Hidden_InclusionList.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_InclusionList.UniqueID))
        item.Hidden_InclusionList.SetValue(STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value)
        item.list_REGION.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAlist_REGION.UniqueID))
        item.list_REGION.SetValue(STUDENT_DIAGNOSIS_DATAlist_REGION.Value)
        item.list_REGIONItems.CopyFrom(STUDENT_DIAGNOSIS_DATAlist_REGION.Items)
        item.RadioButton_Support.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Support.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Support.SelectedItem) Then
            item.RadioButton_Support.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Support.SelectedItem.Value)
        Else
            item.RadioButton_Support.Value = Nothing
        End If
        item.RadioButton_SupportItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Support.Items)
        item.Hidden_SupportList.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_SupportList.UniqueID))
        item.Hidden_SupportList.SetValue(STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value)
        Try
        item.Hidden_enrolyear.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_enrolyear.UniqueID))
        item.Hidden_enrolyear.SetValue(STUDENT_DIAGNOSIS_DATAHidden_enrolyear.Value)
        Catch ae As ArgumentException
            STUDENT_DIAGNOSIS_DATAErrors.Add("Hidden_enrolyear",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_enrolyear"))
        End Try
        Try
        item.Hidden_StudentId.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_StudentId.UniqueID))
        item.Hidden_StudentId.SetValue(STUDENT_DIAGNOSIS_DATAHidden_StudentId.Value)
        Catch ae As ArgumentException
            STUDENT_DIAGNOSIS_DATAErrors.Add("Hidden_StudentId",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_StudentId"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATAHidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STUDENT_DIAGNOSIS_DATAHidden_last_altered_by.Value)
        item.RadioButton_Referral.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Referral.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Referral.SelectedItem) Then
            item.RadioButton_Referral.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Referral.SelectedItem.Value)
        Else
            item.RadioButton_Referral.Value = Nothing
        End If
        item.RadioButton_ReferralItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Referral.Items)
        item.RadioButton_Inclusion.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.SelectedItem) Then
            item.RadioButton_Inclusion.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.SelectedItem.Value)
        Else
            item.RadioButton_Inclusion.Value = Nothing
        End If
        item.RadioButton_InclusionItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.Items)
        item.RadioButton_Wellbeing.IsEmpty = IsNothing(Request.Form(STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.UniqueID))
        If Not IsNothing(STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.SelectedItem) Then
            item.RadioButton_Wellbeing.SetValue(STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.SelectedItem.Value)
        Else
            item.RadioButton_Wellbeing.Value = Nothing
        End If
        item.RadioButton_WellbeingItems.CopyFrom(STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.Items)
        If EnableValidation Then
            item.Validate(STUDENT_DIAGNOSIS_DATAData)
        End If
        STUDENT_DIAGNOSIS_DATAErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA LoadItemFromRequest method

'Record Form STUDENT_DIAGNOSIS_DATA GetRedirectUrl method @2-72B7695F

    Protected Function GetSTUDENT_DIAGNOSIS_DATARedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_DIAGNOSIS_DATA GetRedirectUrl method

'Record Form STUDENT_DIAGNOSIS_DATA ShowErrors method @2-4E81C1DD

    Protected Sub STUDENT_DIAGNOSIS_DATAShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_DIAGNOSIS_DATAErrors.Count - 1
        Select Case STUDENT_DIAGNOSIS_DATAErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_DIAGNOSIS_DATAErrors(i)
        End Select
        Next i
        STUDENT_DIAGNOSIS_DATAError.Visible = True
        STUDENT_DIAGNOSIS_DATAErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA ShowErrors method

'Record Form STUDENT_DIAGNOSIS_DATA Insert Operation @2-0C249134

    Protected Sub STUDENT_DIAGNOSIS_DATA_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_DIAGNOSIS_DATAItem = New STUDENT_DIAGNOSIS_DATAItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_DIAGNOSIS_DATAIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_DIAGNOSIS_DATA Insert Operation

'Button Button_Insert OnClick. @134-2FAA2E88
        If CType(sender,Control).ID = "STUDENT_DIAGNOSIS_DATAButton_Insert" Then
            RedirectUrl = GetSTUDENT_DIAGNOSIS_DATARedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @134-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Retrieve Value for Control @149-C8DC6560
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_by.Value = (New TextField("", (dbutility.userid.toupper()))).GetFormattedValue()
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Retrieve Value for Control

'Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Retrieve Value for Control @150-8F615C2B
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_date.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Retrieve Value for Control

'Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Custom Code @151-73254650
    ' -------------------------
   ' ERA: get the "Wellbeing" and "Inclusions" checkboxes that have been selected, and make comma-delimited strings for saving.
	' combine the selected array items then join to string
	Dim checkItemsPQ as String = "0,"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value = (checkItemsPQ.TrimEnd(","C))
	
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value = (checkItemsDis.TrimEnd(","C))
	
	'17/09/2015|EA| fix instead of using rediobutton code which was wrong
	Dim checkItemsSup as String = "0,"
	Dim thisItemSup As ListItem

	For Each thisItemSup In STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items
		if thisItemSup.Selected then
			checkItemsSup += (thisItemSup.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value = (checkItemsSup.TrimEnd(","C))
	
    ' -------------------------
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeInsert. Action Custom Code

'Record Form STUDENT_DIAGNOSIS_DATA BeforeInsert tail @2-E5EE88BD
    STUDENT_DIAGNOSIS_DATAParameters()
    STUDENT_DIAGNOSIS_DATALoadItemFromRequest(item, EnableValidation)
    If STUDENT_DIAGNOSIS_DATAOperations.AllowInsert Then
        ErrorFlag=(STUDENT_DIAGNOSIS_DATAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_DIAGNOSIS_DATAData.InsertItem(item)
            Catch ex As Exception
                STUDENT_DIAGNOSIS_DATAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_DIAGNOSIS_DATA BeforeInsert tail

'Record Form STUDENT_DIAGNOSIS_DATA AfterInsert tail  @2-45EFBE73
        End If
        ErrorFlag=(STUDENT_DIAGNOSIS_DATAErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_DIAGNOSIS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA AfterInsert tail 

'Record Form STUDENT_DIAGNOSIS_DATA Update Operation @2-DD4EE0E7

    Protected Sub STUDENT_DIAGNOSIS_DATA_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_DIAGNOSIS_DATAItem = New STUDENT_DIAGNOSIS_DATAItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_DIAGNOSIS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_DIAGNOSIS_DATA Update Operation

'Button Button_Update OnClick. @3-7A5F8286
        If CType(sender,Control).ID = "STUDENT_DIAGNOSIS_DATAButton_Update" Then
            RedirectUrl = GetSTUDENT_DIAGNOSIS_DATARedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @3-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Retrieve Value for Control @66-C8DC6560
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_by.Value = (New TextField("", (dbutility.userid.toupper()))).GetFormattedValue()
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Retrieve Value for Control @67-8F615C2B
        STUDENT_DIAGNOSIS_DATAHidden_last_altered_date.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Custom Code @113-73254650
    ' -------------------------
    ' ERA: get the "Wellbeing" and "Inclusions" checkboxes that have been selected, and make comma-delimited strings for saving.
	' combine the selected array items then join to string
	Dim checkItemsPQ as String = "0,"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value = (checkItemsPQ.TrimEnd(","C))
	
	Dim checkItemsDis as String = "0,"
	Dim thisItemDis As ListItem

	For Each thisItemDis In STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items
		if thisItemDis.Selected then
			checkItemsDis += (thisItemDis.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value = (checkItemsDis.TrimEnd(","C))
	
	
	'17/09/2015|EA| fix instead of using rediobutton code which was wrong		
	Dim checkItemsSup as String = "0,"
	Dim thisItemSup As ListItem

	For Each thisItemSup In STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items
		if thisItemSup.Selected then
			checkItemsSup += (thisItemSup.Value) + ","
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value = (checkItemsSup.TrimEnd(","C))
		
    ' -------------------------
'End Record STUDENT_DIAGNOSIS_DATA Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_DIAGNOSIS_DATA Before Update tail @2-6D69BC6B
        STUDENT_DIAGNOSIS_DATAParameters()
        STUDENT_DIAGNOSIS_DATALoadItemFromRequest(item, EnableValidation)
        If STUDENT_DIAGNOSIS_DATAOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_DIAGNOSIS_DATAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_DIAGNOSIS_DATAData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_DIAGNOSIS_DATAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_DIAGNOSIS_DATA Before Update tail

'Record Form STUDENT_DIAGNOSIS_DATA Update Operation tail @2-45EFBE73
        End If
        ErrorFlag=(STUDENT_DIAGNOSIS_DATAErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_DIAGNOSIS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA Update Operation tail

'Record Form STUDENT_DIAGNOSIS_DATA Delete Operation @2-B2BAADE0
    Protected Sub STUDENT_DIAGNOSIS_DATA_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_DIAGNOSIS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_DIAGNOSIS_DATAItem = New STUDENT_DIAGNOSIS_DATAItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_DIAGNOSIS_DATA Delete Operation

'Record Form BeforeDelete tail @2-61092C2B
        STUDENT_DIAGNOSIS_DATAParameters()
        STUDENT_DIAGNOSIS_DATALoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-EF3B48D0
        If ErrorFlag Then
            STUDENT_DIAGNOSIS_DATAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_DIAGNOSIS_DATA Cancel Operation @2-F6FA403A

    Protected Sub STUDENT_DIAGNOSIS_DATA_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_DIAGNOSIS_DATAItem = New STUDENT_DIAGNOSIS_DATAItem()
        STUDENT_DIAGNOSIS_DATAIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_DIAGNOSIS_DATALoadItemFromRequest(item, False)
'End Record Form STUDENT_DIAGNOSIS_DATA Cancel Operation

'Button Button_Cancel OnClick. @4-5846947E
    If CType(sender,Control).ID = "STUDENT_DIAGNOSIS_DATAButton_Cancel" Then
        RedirectUrl = GetSTUDENT_DIAGNOSIS_DATARedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @4-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_DIAGNOSIS_DATA Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_DIAGNOSIS_DATA Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F39872C8
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_DiagnosisConfirmed_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_DIAGNOSIS_DATAData = New STUDENT_DIAGNOSIS_DATADataProvider()
        STUDENT_DIAGNOSIS_DATAOperations = New FormSupportedOperations(False, True, True, True, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","12"})) Then
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

