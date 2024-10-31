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

Namespace DECV_PROD2007.Student_Address_maintain 'Namespace @1-6E8BBD43

'Forms Definition @1-45F75FD0
Public Class [Student_Address_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-BC6B042E
    Protected viewStudentMaintain_AddreData As viewStudentMaintain_AddreDataProvider
    Protected viewStudentMaintain_AddreErrors As NameValueCollection = New NameValueCollection()
    Protected viewStudentMaintain_AddreOperations As FormSupportedOperations
    Protected viewStudentMaintain_AddreIsSubmitted As Boolean = False
    Protected Student_Address_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CD3C1A05
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewStudentMaintain_AddreShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form viewStudentMaintain_Addre Parameters @5-16E269CC

    Protected Sub viewStudentMaintain_AddreParameters()
        Dim item As new viewStudentMaintain_AddreItem
        Try
            viewStudentMaintain_AddreData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlATTENDING_SCHOOL_ID = IntegerParameter.GetParam(item.ATTENDING_SCHOOL_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPOSTAL_ADDRESS_ID = IntegerParameter.GetParam(item.POSTAL_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCURR_RESID_ADDRESS_ID = IntegerParameter.GetParam(item.CURR_RESID_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlORIG_RESID_ADDRESS_ID = IntegerParameter.GetParam(item.ORIG_RESID_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.Ctrlflag_same_as_school = IntegerParameter.GetParam(item.flag_same_as_school.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.Ctrlflag_same_as_school_old = IntegerParameter.GetParam(item.flag_same_as_school_old.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostAdd_ADDRESS_ID = IntegerParameter.GetParam(item.PostAdd_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_ADDRESSEE = TextParameter.GetParam(item.Postal_ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_AGENT = TextParameter.GetParam(item.Postal_AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_ADDR1 = TextParameter.GetParam(item.Postal_ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_ADDR2 = TextParameter.GetParam(item.Postal_ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_SUBURB_TOWN = TextParameter.GetParam(item.Postal_SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_POSTCODE = TextParameter.GetParam(item.Postal_POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_STATE = TextParameter.GetParam(item.Postal_STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_COUNTRY = TextParameter.GetParam(item.Postal_COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_PHONE_A = TextParameter.GetParam(item.Postal_PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_PHONE_B = TextParameter.GetParam(item.Postal_PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_FAX = TextParameter.GetParam(item.Postal_FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_EMAIL_ADDRESS = TextParameter.GetParam(item.Postal_EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlPostal_EMAIL_ADDRESS2 = TextParameter.GetParam(item.Postal_EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.Ctrlcbox_same_as_postal = IntegerParameter.GetParam(item.cbox_same_as_postal.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.Sesflag_same_as_postal_old = IntegerParameter.GetParam("flag_same_as_postal_old", ParameterSourceType.Session, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_ADDRESS_ID = IntegerParameter.GetParam(item.Curr_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_ADDRESSEE = TextParameter.GetParam(item.Curr_ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_AGENT = TextParameter.GetParam(item.Curr_AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_ADDR1 = TextParameter.GetParam(item.Curr_ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_ADDR2 = TextParameter.GetParam(item.Curr_ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_SUBURB_TOWN = TextParameter.GetParam(item.Curr_SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_POSTCODE = TextParameter.GetParam(item.Curr_POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_STATE = TextParameter.GetParam(item.Curr_STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_COUNTRY = TextParameter.GetParam(item.Curr_COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_PHONE_A = TextParameter.GetParam(item.Curr_PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_PHONE_B = TextParameter.GetParam(item.Curr_PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_FAX = TextParameter.GetParam(item.Curr_FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_EMAIL_ADDRESS = TextParameter.GetParam(item.Curr_EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlCurr_EMAIL_ADDRESS2 = TextParameter.GetParam(item.Curr_EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_ADDRESS_ID = IntegerParameter.GetParam(item.Orig_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_ADDRESSEE = TextParameter.GetParam(item.Orig_ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_AGENT = TextParameter.GetParam(item.Orig_AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_ADDR1 = TextParameter.GetParam(item.Orig_ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_ADDR2 = TextParameter.GetParam(item.Orig_ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_SUBURB_TOWN = TextParameter.GetParam(item.Orig_SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_POSTCODE = TextParameter.GetParam(item.Orig_POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_STATE = TextParameter.GetParam(item.Orig_STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_COUNTRY = TextParameter.GetParam(item.Orig_COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_PHONE_A = TextParameter.GetParam(item.Orig_PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_PHONE_B = TextParameter.GetParam(item.Orig_PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_FAX = TextParameter.GetParam(item.Orig_FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_EMAIL_ADDRESS = TextParameter.GetParam(item.Orig_EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.CtrlOrig_EMAIL_ADDRESS2 = TextParameter.GetParam(item.Orig_EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            viewStudentMaintain_AddreData.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", Nothing, false)
        Catch e As Exception
            viewStudentMaintain_AddreErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewStudentMaintain_Addre Parameters

'Record Form viewStudentMaintain_Addre Show method @5-0C5F9A53
    Protected Sub viewStudentMaintain_AddreShow()
        If viewStudentMaintain_AddreOperations.None Then
            viewStudentMaintain_AddreHolder.Visible = False
            Return
        End If
        Dim item As viewStudentMaintain_AddreItem = viewStudentMaintain_AddreItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewStudentMaintain_AddreOperations.AllowRead
        item.this_LAST_ALTERED_BY.SetValue(session("UserID"))
        viewStudentMaintain_AddreErrors.Add(item.errors)
        If viewStudentMaintain_AddreErrors.Count > 0 Then
            viewStudentMaintain_AddreShowErrors()
            Return
        End If
'End Record Form viewStudentMaintain_Addre Show method

'Record Form viewStudentMaintain_Addre BeforeShow tail @5-9F989CC1
        viewStudentMaintain_AddreParameters()
        viewStudentMaintain_AddreData.FillItem(item, IsInsertMode)
        viewStudentMaintain_AddreHolder.DataBind()
        viewStudentMaintain_AddreButton_Update1.Visible=Not (IsInsertMode) AndAlso viewStudentMaintain_AddreOperations.AllowUpdate
        viewStudentMaintain_AddreButton_Update.Visible=Not (IsInsertMode) AndAlso viewStudentMaintain_AddreOperations.AllowUpdate
        viewStudentMaintain_AddrelblMessage.Text = Server.HtmlEncode(item.lblMessage.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        If item.cbox_same_as_schoolCheckedValue.Value.Equals(item.cbox_same_as_school.Value) Then
            viewStudentMaintain_Addrecbox_same_as_school.Checked = True
        End If
        viewStudentMaintain_AddrePostAdd_ADDRESS_ID.Text=item.PostAdd_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_AddrePostal_ADDRESSEE.Text=item.Postal_ADDRESSEE.GetFormattedValue()
        viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig.Text=item.PostAdd_ADDRESS_ID_orig.GetFormattedValue()
        viewStudentMaintain_AddrePostal_AGENT.Text=item.Postal_AGENT.GetFormattedValue()
        viewStudentMaintain_AddrePostal_ADDR1.Text=item.Postal_ADDR1.GetFormattedValue()
        viewStudentMaintain_AddrePostal_ADDR2.Text=item.Postal_ADDR2.GetFormattedValue()
        viewStudentMaintain_AddrePostal_SUBURB_TOWN.Text=item.Postal_SUBURB_TOWN.GetFormattedValue()
        viewStudentMaintain_AddrePostal_STATE.Text=item.Postal_STATE.GetFormattedValue()
        viewStudentMaintain_AddrePostal_POSTCODE.Text=item.Postal_POSTCODE.GetFormattedValue()
        viewStudentMaintain_AddrePostal_COUNTRY.Text=item.Postal_COUNTRY.GetFormattedValue()
        viewStudentMaintain_AddrePostal_PHONE_A.Text=item.Postal_PHONE_A.GetFormattedValue()
        viewStudentMaintain_AddrePostal_PHONE_B.Text=item.Postal_PHONE_B.GetFormattedValue()
        viewStudentMaintain_AddrePostal_FAX.Text=item.Postal_FAX.GetFormattedValue()
        viewStudentMaintain_AddrePostal_EMAIL_ADDRESS.Text=item.Postal_EMAIL_ADDRESS.GetFormattedValue()
        viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2.Text=item.Postal_EMAIL_ADDRESS2.GetFormattedValue()
        viewStudentMaintain_AddrePostal_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.Postal_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddrePostal_LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.Postal_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        If item.cbox_same_as_postalCheckedValue.Value.Equals(item.cbox_same_as_postal.Value) Then
            viewStudentMaintain_Addrecbox_same_as_postal.Checked = True
        End If
        viewStudentMaintain_AddreCurr_ADDRESS_ID.Value = item.Curr_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_AddreCurr_ADDRESSEE.Text=item.Curr_ADDRESSEE.GetFormattedValue()
        viewStudentMaintain_AddreCurr_ADDRESS_ID_orig.Value = item.Curr_ADDRESS_ID_orig.GetFormattedValue()
        viewStudentMaintain_AddreCurr_AGENT.Text=item.Curr_AGENT.GetFormattedValue()
        viewStudentMaintain_AddreCurr_ADDR1.Text=item.Curr_ADDR1.GetFormattedValue()
        viewStudentMaintain_AddreCurr_ADDR2.Text=item.Curr_ADDR2.GetFormattedValue()
        viewStudentMaintain_AddreCurr_SUBURB_TOWN.Text=item.Curr_SUBURB_TOWN.GetFormattedValue()
        viewStudentMaintain_AddreCurr_STATE.Text=item.Curr_STATE.GetFormattedValue()
        viewStudentMaintain_AddreCurr_POSTCODE.Text=item.Curr_POSTCODE.GetFormattedValue()
        viewStudentMaintain_AddreCurr_COUNTRY.Text=item.Curr_COUNTRY.GetFormattedValue()
        viewStudentMaintain_AddreCurr_PHONE_A.Text=item.Curr_PHONE_A.GetFormattedValue()
        viewStudentMaintain_AddreCurr_PHONE_B.Text=item.Curr_PHONE_B.GetFormattedValue()
        viewStudentMaintain_AddreCurr_FAX.Text=item.Curr_FAX.GetFormattedValue()
        viewStudentMaintain_AddreCurr_EMAIL_ADDRESS.Text=item.Curr_EMAIL_ADDRESS.GetFormattedValue()
        viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2.Text=item.Curr_EMAIL_ADDRESS2.GetFormattedValue()
        viewStudentMaintain_AddreCurr_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.Curr_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreCurr_LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.Curr_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreOrig_ADDRESS_ID.Value = item.Orig_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_AddreOrig_ADDRESSEE.Text=item.Orig_ADDRESSEE.GetFormattedValue()
        viewStudentMaintain_AddreOrig_ADDRESS_ID_orig.Value = item.Orig_ADDRESS_ID_orig.GetFormattedValue()
        viewStudentMaintain_AddreOrig_AGENT.Text=item.Orig_AGENT.GetFormattedValue()
        viewStudentMaintain_AddreOrig_ADDR1.Text=item.Orig_ADDR1.GetFormattedValue()
        viewStudentMaintain_AddreOrig_ADDR2.Text=item.Orig_ADDR2.GetFormattedValue()
        viewStudentMaintain_AddreOrig_SUBURB_TOWN.Text=item.Orig_SUBURB_TOWN.GetFormattedValue()
        viewStudentMaintain_AddreOrig_STATE.Text=item.Orig_STATE.GetFormattedValue()
        viewStudentMaintain_AddreOrig_POSTCODE.Text=item.Orig_POSTCODE.GetFormattedValue()
        viewStudentMaintain_AddreOrig_COUNTRY.Text=item.Orig_COUNTRY.GetFormattedValue()
        viewStudentMaintain_AddreOrig_PHONE_A.Text=item.Orig_PHONE_A.GetFormattedValue()
        viewStudentMaintain_AddreOrig_PHONE_B.Text=item.Orig_PHONE_B.GetFormattedValue()
        viewStudentMaintain_AddreOrig_FAX.Text=item.Orig_FAX.GetFormattedValue()
        viewStudentMaintain_AddreOrig_EMAIL_ADDRESS.Text=item.Orig_EMAIL_ADDRESS.GetFormattedValue()
        viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2.Text=item.Orig_EMAIL_ADDRESS2.GetFormattedValue()
        viewStudentMaintain_AddreOrig_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.Orig_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreOrig_LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.Orig_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreATTENDING_SCHOOL_ID.Value = item.ATTENDING_SCHOOL_ID.GetFormattedValue()
        viewStudentMaintain_AddreCURR_RESID_ADDRESS_ID.Value = item.CURR_RESID_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_AddreORIG_RESID_ADDRESS_ID.Value = item.ORIG_RESID_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown.Text=item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.GetFormattedValue()
        viewStudentMaintain_AddrePOSTAL_ADDRESS_ID.Text=item.POSTAL_ADDRESS_ID.GetFormattedValue()
        viewStudentMaintain_Addreflag_same_as_school_old.Text=item.flag_same_as_school_old.GetFormattedValue()
        viewStudentMaintain_Addreflag_same_as_school.Text=item.flag_same_as_school.GetFormattedValue()
        viewStudentMaintain_Addrethis_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.this_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        viewStudentMaintain_AddreajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
'End Record Form viewStudentMaintain_Addre BeforeShow tail

'Record viewStudentMaintain_Addre Event BeforeShow. Action Custom Code @120-73254650
    ' -------------------------
    ' ERA: April 2008|EA| set up some flags for 'same as school' and same as postal checkboxes, with the '_old' ones being the on-load values
	' Feb-2009|EA| added as temp storage so it can be retreived and set into PostalAddress ID when ticking box
	Dim attending_school_address_id As Int64 = 0
	if not (item.ATTENDING_SCHOOL_ID.GetFormattedValue = "") then
		attending_school_address_id = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "ADDRESS_ID" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID = " & item.ATTENDING_SCHOOL_ID.GetFormattedValue()))).Value, Int64)
	end if

	'Feb-2009|EA| added as temp storage so it can be retreived and set into PostalAddress ID when ticking box
	item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.value=attending_school_address_id
	viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown.Text=item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.GetFormattedValue()

	if (attending_school_address_id = item.postadd_address_id.value) then
		item.cbox_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)
		HttpContext.Current.Session("flag_same_as_school_old") = (item.cbox_same_as_schoolCheckedValue.Value)
		item.flag_same_as_school_old.value= (item.cbox_same_as_schoolCheckedValue.Value)
		item.flag_same_as_school.value= (item.cbox_same_as_schoolCheckedValue.Value)
	else
		item.cbox_same_as_school.Value = (item.cbox_same_as_schooluncheckedvalue.value)
		HttpContext.Current.Session("flag_same_as_school_old") = (item.cbox_same_as_schooluncheckedvalue.Value)
		item.flag_same_as_school_old.value= (item.cbox_same_as_schooluncheckedvalue.Value)
		item.flag_same_as_school.value= (item.cbox_same_as_schooluncheckedvalue.Value)
	end if

	if (item.curr_address_id.value = item.postadd_address_id.value) then
		item.cbox_same_as_postal.Value = (item.cbox_same_as_postalcheckedvalue.value)
		HttpContext.Current.Session("flag_same_as_postal_old") = (item.cbox_same_as_postalcheckedvalue.Value)
	else
		item.cbox_same_as_postal.Value = (item.cbox_same_as_postaluncheckedvalue.value)
		HttpContext.Current.Session("flag_same_as_postal_old") = (item.cbox_same_as_postaluncheckedvalue.Value)
	end if

	' and set the checkboxes for Same As School and Same as Postal from the values above
	If item.cbox_same_as_schoolCheckedValue.Value.Equals(item.cbox_same_as_school.Value) Then
            viewStudentMaintain_Addrecbox_same_as_school.Checked = True
			viewStudentMaintain_Addreflag_same_as_school_old.Text=item.flag_same_as_school_old.GetFormattedValue()
			viewStudentMaintain_Addreflag_same_as_school.Text=item.flag_same_as_school.GetFormattedValue()
    End If
	If item.cbox_same_as_postalCheckedValue.Value.Equals(item.cbox_same_as_postal.Value) Then
            viewStudentMaintain_Addrecbox_same_as_postal.Checked = True
    End If

    ' -------------------------
'End Record viewStudentMaintain_Addre Event BeforeShow. Action Custom Code

'Record Form viewStudentMaintain_Addre Show method tail @5-EB980BB4
        If viewStudentMaintain_AddreErrors.Count > 0 Then
            viewStudentMaintain_AddreShowErrors()
        End If
    End Sub
'End Record Form viewStudentMaintain_Addre Show method tail

'Record Form viewStudentMaintain_Addre LoadItemFromRequest method @5-16FCDD16

    Protected Sub viewStudentMaintain_AddreLoadItemFromRequest(item As viewStudentMaintain_AddreItem, ByVal EnableValidation As Boolean)
        If viewStudentMaintain_Addrecbox_same_as_school.Checked Then
            item.cbox_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)
        Else
            item.cbox_same_as_school.Value = (item.cbox_same_as_schoolUncheckedValue.Value)
        End If
        Try
        item.PostAdd_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostAdd_ADDRESS_ID.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostAdd_ADDRESS_ID") Is Nothing Then
            item.PostAdd_ADDRESS_ID.SetValue(viewStudentMaintain_AddrePostAdd_ADDRESS_ID.Text)
        Else
            item.PostAdd_ADDRESS_ID.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostAdd_ADDRESS_ID"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("PostAdd_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Post Add ADDRESS ID"))
        End Try
        item.Postal_ADDRESSEE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_ADDRESSEE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_ADDRESSEE") Is Nothing Then
            item.Postal_ADDRESSEE.SetValue(viewStudentMaintain_AddrePostal_ADDRESSEE.Text)
        Else
            item.Postal_ADDRESSEE.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_ADDRESSEE"))
        End If
        Try
        item.PostAdd_ADDRESS_ID_orig.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig") Is Nothing Then
            item.PostAdd_ADDRESS_ID_orig.SetValue(viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig.Text)
        Else
            item.PostAdd_ADDRESS_ID_orig.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostAdd_ADDRESS_ID_orig"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("PostAdd_ADDRESS_ID_orig",String.Format(Resources.strings.CCS_IncorrectValue,"Post Add ADDRESS ID"))
        End Try
        item.Postal_AGENT.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_AGENT.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_AGENT") Is Nothing Then
            item.Postal_AGENT.SetValue(viewStudentMaintain_AddrePostal_AGENT.Text)
        Else
            item.Postal_AGENT.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_AGENT"))
        End If
        item.Postal_ADDR1.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_ADDR1.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_ADDR1") Is Nothing Then
            item.Postal_ADDR1.SetValue(viewStudentMaintain_AddrePostal_ADDR1.Text)
        Else
            item.Postal_ADDR1.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_ADDR1"))
        End If
        item.Postal_ADDR2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_ADDR2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_ADDR2") Is Nothing Then
            item.Postal_ADDR2.SetValue(viewStudentMaintain_AddrePostal_ADDR2.Text)
        Else
            item.Postal_ADDR2.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_ADDR2"))
        End If
        item.Postal_SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_SUBURB_TOWN.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_SUBURB_TOWN") Is Nothing Then
            item.Postal_SUBURB_TOWN.SetValue(viewStudentMaintain_AddrePostal_SUBURB_TOWN.Text)
        Else
            item.Postal_SUBURB_TOWN.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_SUBURB_TOWN"))
        End If
        item.Postal_STATE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_STATE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_STATE") Is Nothing Then
            item.Postal_STATE.SetValue(viewStudentMaintain_AddrePostal_STATE.Text)
        Else
            item.Postal_STATE.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_STATE"))
        End If
        item.Postal_POSTCODE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_POSTCODE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_POSTCODE") Is Nothing Then
            item.Postal_POSTCODE.SetValue(viewStudentMaintain_AddrePostal_POSTCODE.Text)
        Else
            item.Postal_POSTCODE.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_POSTCODE"))
        End If
        item.Postal_COUNTRY.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_COUNTRY.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_COUNTRY") Is Nothing Then
            item.Postal_COUNTRY.SetValue(viewStudentMaintain_AddrePostal_COUNTRY.Text)
        Else
            item.Postal_COUNTRY.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_COUNTRY"))
        End If
        item.Postal_PHONE_A.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_PHONE_A.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_PHONE_A") Is Nothing Then
            item.Postal_PHONE_A.SetValue(viewStudentMaintain_AddrePostal_PHONE_A.Text)
        Else
            item.Postal_PHONE_A.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_PHONE_A"))
        End If
        item.Postal_PHONE_B.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_PHONE_B.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_PHONE_B") Is Nothing Then
            item.Postal_PHONE_B.SetValue(viewStudentMaintain_AddrePostal_PHONE_B.Text)
        Else
            item.Postal_PHONE_B.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_PHONE_B"))
        End If
        item.Postal_FAX.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_FAX.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_FAX") Is Nothing Then
            item.Postal_FAX.SetValue(viewStudentMaintain_AddrePostal_FAX.Text)
        Else
            item.Postal_FAX.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_FAX"))
        End If
        item.Postal_EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_EMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS") Is Nothing Then
            item.Postal_EMAIL_ADDRESS.SetValue(viewStudentMaintain_AddrePostal_EMAIL_ADDRESS.Text)
        Else
            item.Postal_EMAIL_ADDRESS.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS"))
        End If
        item.Postal_EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2") Is Nothing Then
            item.Postal_EMAIL_ADDRESS2.SetValue(viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2.Text)
        Else
            item.Postal_EMAIL_ADDRESS2.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostal_EMAIL_ADDRESS2"))
        End If
        If viewStudentMaintain_Addrecbox_same_as_postal.Checked Then
            item.cbox_same_as_postal.Value = (item.cbox_same_as_postalCheckedValue.Value)
        Else
            item.cbox_same_as_postal.Value = (item.cbox_same_as_postalUncheckedValue.Value)
        End If
        Try
        item.Curr_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_ADDRESS_ID.UniqueID))
        item.Curr_ADDRESS_ID.SetValue(viewStudentMaintain_AddreCurr_ADDRESS_ID.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("Curr_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Curr ADDRESS ID"))
        End Try
        item.Curr_ADDRESSEE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_ADDRESSEE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_ADDRESSEE") Is Nothing Then
            item.Curr_ADDRESSEE.SetValue(viewStudentMaintain_AddreCurr_ADDRESSEE.Text)
        Else
            item.Curr_ADDRESSEE.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_ADDRESSEE"))
        End If
        Try
        item.Curr_ADDRESS_ID_orig.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_ADDRESS_ID_orig.UniqueID))
        item.Curr_ADDRESS_ID_orig.SetValue(viewStudentMaintain_AddreCurr_ADDRESS_ID_orig.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("Curr_ADDRESS_ID_orig",String.Format(Resources.strings.CCS_IncorrectValue,"Curr ADDRESS ID"))
        End Try
        item.Curr_AGENT.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_AGENT.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_AGENT") Is Nothing Then
            item.Curr_AGENT.SetValue(viewStudentMaintain_AddreCurr_AGENT.Text)
        Else
            item.Curr_AGENT.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_AGENT"))
        End If
        item.Curr_ADDR1.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_ADDR1.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_ADDR1") Is Nothing Then
            item.Curr_ADDR1.SetValue(viewStudentMaintain_AddreCurr_ADDR1.Text)
        Else
            item.Curr_ADDR1.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_ADDR1"))
        End If
        item.Curr_ADDR2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_ADDR2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_ADDR2") Is Nothing Then
            item.Curr_ADDR2.SetValue(viewStudentMaintain_AddreCurr_ADDR2.Text)
        Else
            item.Curr_ADDR2.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_ADDR2"))
        End If
        item.Curr_SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_SUBURB_TOWN.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_SUBURB_TOWN") Is Nothing Then
            item.Curr_SUBURB_TOWN.SetValue(viewStudentMaintain_AddreCurr_SUBURB_TOWN.Text)
        Else
            item.Curr_SUBURB_TOWN.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_SUBURB_TOWN"))
        End If
        item.Curr_STATE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_STATE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_STATE") Is Nothing Then
            item.Curr_STATE.SetValue(viewStudentMaintain_AddreCurr_STATE.Text)
        Else
            item.Curr_STATE.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_STATE"))
        End If
        item.Curr_POSTCODE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_POSTCODE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_POSTCODE") Is Nothing Then
            item.Curr_POSTCODE.SetValue(viewStudentMaintain_AddreCurr_POSTCODE.Text)
        Else
            item.Curr_POSTCODE.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_POSTCODE"))
        End If
        item.Curr_COUNTRY.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_COUNTRY.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_COUNTRY") Is Nothing Then
            item.Curr_COUNTRY.SetValue(viewStudentMaintain_AddreCurr_COUNTRY.Text)
        Else
            item.Curr_COUNTRY.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_COUNTRY"))
        End If
        item.Curr_PHONE_A.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_PHONE_A.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_PHONE_A") Is Nothing Then
            item.Curr_PHONE_A.SetValue(viewStudentMaintain_AddreCurr_PHONE_A.Text)
        Else
            item.Curr_PHONE_A.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_PHONE_A"))
        End If
        item.Curr_PHONE_B.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_PHONE_B.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_PHONE_B") Is Nothing Then
            item.Curr_PHONE_B.SetValue(viewStudentMaintain_AddreCurr_PHONE_B.Text)
        Else
            item.Curr_PHONE_B.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_PHONE_B"))
        End If
        item.Curr_FAX.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_FAX.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_FAX") Is Nothing Then
            item.Curr_FAX.SetValue(viewStudentMaintain_AddreCurr_FAX.Text)
        Else
            item.Curr_FAX.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_FAX"))
        End If
        item.Curr_EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_EMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_EMAIL_ADDRESS") Is Nothing Then
            item.Curr_EMAIL_ADDRESS.SetValue(viewStudentMaintain_AddreCurr_EMAIL_ADDRESS.Text)
        Else
            item.Curr_EMAIL_ADDRESS.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_EMAIL_ADDRESS"))
        End If
        item.Curr_EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2") Is Nothing Then
            item.Curr_EMAIL_ADDRESS2.SetValue(viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2.Text)
        Else
            item.Curr_EMAIL_ADDRESS2.SetValue(ControlCustomValues("viewStudentMaintain_AddreCurr_EMAIL_ADDRESS2"))
        End If
        Try
        item.Orig_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_ADDRESS_ID.UniqueID))
        item.Orig_ADDRESS_ID.SetValue(viewStudentMaintain_AddreOrig_ADDRESS_ID.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("Orig_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Orig ADDRESS ID"))
        End Try
        item.Orig_ADDRESSEE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_ADDRESSEE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_ADDRESSEE") Is Nothing Then
            item.Orig_ADDRESSEE.SetValue(viewStudentMaintain_AddreOrig_ADDRESSEE.Text)
        Else
            item.Orig_ADDRESSEE.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_ADDRESSEE"))
        End If
        Try
        item.Orig_ADDRESS_ID_orig.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_ADDRESS_ID_orig.UniqueID))
        item.Orig_ADDRESS_ID_orig.SetValue(viewStudentMaintain_AddreOrig_ADDRESS_ID_orig.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("Orig_ADDRESS_ID_orig",String.Format(Resources.strings.CCS_IncorrectValue,"Orig ADDRESS ID"))
        End Try
        item.Orig_AGENT.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_AGENT.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_AGENT") Is Nothing Then
            item.Orig_AGENT.SetValue(viewStudentMaintain_AddreOrig_AGENT.Text)
        Else
            item.Orig_AGENT.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_AGENT"))
        End If
        item.Orig_ADDR1.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_ADDR1.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_ADDR1") Is Nothing Then
            item.Orig_ADDR1.SetValue(viewStudentMaintain_AddreOrig_ADDR1.Text)
        Else
            item.Orig_ADDR1.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_ADDR1"))
        End If
        item.Orig_ADDR2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_ADDR2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_ADDR2") Is Nothing Then
            item.Orig_ADDR2.SetValue(viewStudentMaintain_AddreOrig_ADDR2.Text)
        Else
            item.Orig_ADDR2.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_ADDR2"))
        End If
        item.Orig_SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_SUBURB_TOWN.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_SUBURB_TOWN") Is Nothing Then
            item.Orig_SUBURB_TOWN.SetValue(viewStudentMaintain_AddreOrig_SUBURB_TOWN.Text)
        Else
            item.Orig_SUBURB_TOWN.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_SUBURB_TOWN"))
        End If
        item.Orig_STATE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_STATE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_STATE") Is Nothing Then
            item.Orig_STATE.SetValue(viewStudentMaintain_AddreOrig_STATE.Text)
        Else
            item.Orig_STATE.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_STATE"))
        End If
        item.Orig_POSTCODE.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_POSTCODE.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_POSTCODE") Is Nothing Then
            item.Orig_POSTCODE.SetValue(viewStudentMaintain_AddreOrig_POSTCODE.Text)
        Else
            item.Orig_POSTCODE.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_POSTCODE"))
        End If
        item.Orig_COUNTRY.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_COUNTRY.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_COUNTRY") Is Nothing Then
            item.Orig_COUNTRY.SetValue(viewStudentMaintain_AddreOrig_COUNTRY.Text)
        Else
            item.Orig_COUNTRY.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_COUNTRY"))
        End If
        item.Orig_PHONE_A.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_PHONE_A.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_PHONE_A") Is Nothing Then
            item.Orig_PHONE_A.SetValue(viewStudentMaintain_AddreOrig_PHONE_A.Text)
        Else
            item.Orig_PHONE_A.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_PHONE_A"))
        End If
        item.Orig_PHONE_B.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_PHONE_B.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_PHONE_B") Is Nothing Then
            item.Orig_PHONE_B.SetValue(viewStudentMaintain_AddreOrig_PHONE_B.Text)
        Else
            item.Orig_PHONE_B.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_PHONE_B"))
        End If
        item.Orig_FAX.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_FAX.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_FAX") Is Nothing Then
            item.Orig_FAX.SetValue(viewStudentMaintain_AddreOrig_FAX.Text)
        Else
            item.Orig_FAX.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_FAX"))
        End If
        item.Orig_EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_EMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_EMAIL_ADDRESS") Is Nothing Then
            item.Orig_EMAIL_ADDRESS.SetValue(viewStudentMaintain_AddreOrig_EMAIL_ADDRESS.Text)
        Else
            item.Orig_EMAIL_ADDRESS.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_EMAIL_ADDRESS"))
        End If
        item.Orig_EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2") Is Nothing Then
            item.Orig_EMAIL_ADDRESS2.SetValue(viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2.Text)
        Else
            item.Orig_EMAIL_ADDRESS2.SetValue(ControlCustomValues("viewStudentMaintain_AddreOrig_EMAIL_ADDRESS2"))
        End If
        Try
        item.ATTENDING_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreATTENDING_SCHOOL_ID.UniqueID))
        item.ATTENDING_SCHOOL_ID.SetValue(viewStudentMaintain_AddreATTENDING_SCHOOL_ID.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("ATTENDING_SCHOOL_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ATTENDING SCHOOL ID"))
        End Try
        Try
        item.CURR_RESID_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreCURR_RESID_ADDRESS_ID.UniqueID))
        item.CURR_RESID_ADDRESS_ID.SetValue(viewStudentMaintain_AddreCURR_RESID_ADDRESS_ID.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("CURR_RESID_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"CURR RESID ADDRESS ID"))
        End Try
        Try
        item.ORIG_RESID_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddreORIG_RESID_ADDRESS_ID.UniqueID))
        item.ORIG_RESID_ADDRESS_ID.SetValue(viewStudentMaintain_AddreORIG_RESID_ADDRESS_ID.Value)
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("ORIG_RESID_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ORIG RESID ADDRESS ID"))
        End Try
        Try
        item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown") Is Nothing Then
            item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.SetValue(viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown.Text)
        Else
            item.PostAdd_SCHOOL_ADDRESS_ID_ifknown.SetValue(ControlCustomValues("viewStudentMaintain_AddrePostAdd_SCHOOL_ADDRESS_ID_ifknown"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("PostAdd_SCHOOL_ADDRESS_ID_ifknown",String.Format(Resources.strings.CCS_IncorrectValue,"Post Add ADDRESS ID"))
        End Try
        Try
        item.POSTAL_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_AddrePOSTAL_ADDRESS_ID.UniqueID))
        If ControlCustomValues("viewStudentMaintain_AddrePOSTAL_ADDRESS_ID") Is Nothing Then
            item.POSTAL_ADDRESS_ID.SetValue(viewStudentMaintain_AddrePOSTAL_ADDRESS_ID.Text)
        Else
            item.POSTAL_ADDRESS_ID.SetValue(ControlCustomValues("viewStudentMaintain_AddrePOSTAL_ADDRESS_ID"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("POSTAL_ADDRESS_ID",String.Format(Resources.strings.CCS_IncorrectValue,"POSTAL ADDRESS ID"))
        End Try
        Try
        item.flag_same_as_school_old.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_Addreflag_same_as_school_old.UniqueID))
        If ControlCustomValues("viewStudentMaintain_Addreflag_same_as_school_old") Is Nothing Then
            item.flag_same_as_school_old.SetValue(viewStudentMaintain_Addreflag_same_as_school_old.Text)
        Else
            item.flag_same_as_school_old.SetValue(ControlCustomValues("viewStudentMaintain_Addreflag_same_as_school_old"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("flag_same_as_school_old",String.Format(Resources.strings.CCS_IncorrectValue,"flag_same_as_school_old"))
        End Try
        Try
        item.flag_same_as_school.IsEmpty = IsNothing(Request.Form(viewStudentMaintain_Addreflag_same_as_school.UniqueID))
        If ControlCustomValues("viewStudentMaintain_Addreflag_same_as_school") Is Nothing Then
            item.flag_same_as_school.SetValue(viewStudentMaintain_Addreflag_same_as_school.Text)
        Else
            item.flag_same_as_school.SetValue(ControlCustomValues("viewStudentMaintain_Addreflag_same_as_school"))
        End If
        Catch ae As ArgumentException
            viewStudentMaintain_AddreErrors.Add("flag_same_as_school",String.Format(Resources.strings.CCS_IncorrectValue,"flag_same_as_school"))
        End Try
        If EnableValidation Then
            item.Validate(viewStudentMaintain_AddreData)
        End If
        viewStudentMaintain_AddreErrors.Add(item.errors)
    End Sub
'End Record Form viewStudentMaintain_Addre LoadItemFromRequest method

'Record Form viewStudentMaintain_Addre GetRedirectUrl method @5-8A252D15

    Protected Function GetviewStudentMaintain_AddreRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","flagattendingschool;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewStudentMaintain_Addre GetRedirectUrl method

'Record Form viewStudentMaintain_Addre ShowErrors method @5-849CAF90

    Protected Sub viewStudentMaintain_AddreShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewStudentMaintain_AddreErrors.Count - 1
        Select Case viewStudentMaintain_AddreErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewStudentMaintain_AddreErrors(i)
        End Select
        Next i
        viewStudentMaintain_AddreError.Visible = True
        viewStudentMaintain_AddreErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewStudentMaintain_Addre ShowErrors method

'Record Form viewStudentMaintain_Addre Insert Operation @5-9AFDF165

    Protected Sub viewStudentMaintain_Addre_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentMaintain_AddreItem = New viewStudentMaintain_AddreItem()
        viewStudentMaintain_AddreIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentMaintain_Addre Insert Operation

'Record Form viewStudentMaintain_Addre BeforeInsert tail @5-2BA89DC7
    viewStudentMaintain_AddreParameters()
    viewStudentMaintain_AddreLoadItemFromRequest(item, EnableValidation)
'End Record Form viewStudentMaintain_Addre BeforeInsert tail

'Record Form viewStudentMaintain_Addre AfterInsert tail  @5-7DF17090
        ErrorFlag=(viewStudentMaintain_AddreErrors.Count > 0)
        If ErrorFlag Then
            viewStudentMaintain_AddreShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentMaintain_Addre AfterInsert tail 

'Record Form viewStudentMaintain_Addre Update Operation @5-59C46D08

    Protected Sub viewStudentMaintain_Addre_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentMaintain_AddreItem = New viewStudentMaintain_AddreItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        viewStudentMaintain_AddreIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewStudentMaintain_Addre Update Operation

'Button Button_Update1 OnClick. @62-195D4948
        If CType(sender,Control).ID = "viewStudentMaintain_AddreButton_Update1" Then
            RedirectUrl = GetviewStudentMaintain_AddreRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update1 OnClick.

'Button Button_Update1 OnClick tail. @62-477CF3C9
        End If
'End Button Button_Update1 OnClick tail.

'Button Button_Update OnClick. @6-9B50C11C
        If CType(sender,Control).ID = "viewStudentMaintain_AddreButton_Update" Then
            RedirectUrl = GetviewStudentMaintain_AddreRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record viewStudentMaintain_Addre Event BeforeUpdate. Action Custom Code @159-73254650
    ' -------------------------
    'ERA: debug the same as school flag
	 If viewStudentMaintain_Addrecbox_same_as_school.Checked Then
            item.flag_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)
     Else
            item.flag_same_as_school.Value = (item.cbox_same_as_schoolUncheckedValue.Value)
     End If
	'viewStudentMaintain_AddreErrors.Add("debug","Same as school flag item: "& item.flag_same_as_school.getformattedValue() )
	'viewStudentMaintain_AddreErrors.Add("debug","Same as school flag text: "& viewStudentMaintain_Addreflag_same_as_school.Text)
	'viewStudentMaintain_AddreErrors.Add("debug","Same as school flag Control : "& (ControlCustomValues("viewStudentMaintain_Addreflag_same_as_school")) )
	'viewStudentMaintain_AddreErrors.Add("debug","Same as school flag OLD: "& item.flag_same_as_school_old.getformattedValue())

    ' -------------------------
'End Record viewStudentMaintain_Addre Event BeforeUpdate. Action Custom Code

'Record Form viewStudentMaintain_Addre Before Update tail @5-B46DD313
        viewStudentMaintain_AddreParameters()
        viewStudentMaintain_AddreLoadItemFromRequest(item, EnableValidation)
        If viewStudentMaintain_AddreOperations.AllowUpdate Then
        ErrorFlag = (viewStudentMaintain_AddreErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                viewStudentMaintain_AddreData.UpdateItem(item)
            Catch ex As Exception
                viewStudentMaintain_AddreErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form viewStudentMaintain_Addre Before Update tail

'Record viewStudentMaintain_Addre Event AfterUpdate. Action Custom Code @124-73254650
    ' -------------------------
    ' ERA: advise user of completed update
	if (viewStudentMaintain_AddreErrors.Count =0) then
		viewStudentMaintain_AddrelblMessage.Text = "Update Completed"
	end if
    ' -------------------------
'End Record viewStudentMaintain_Addre Event AfterUpdate. Action Custom Code

'Record Form viewStudentMaintain_Addre Update Operation tail @5-53C6C489
        End If
        ErrorFlag=(viewStudentMaintain_AddreErrors.Count > 0)
        If ErrorFlag Then
            viewStudentMaintain_AddreShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewStudentMaintain_Addre Update Operation tail

'Record Form viewStudentMaintain_Addre Delete Operation @5-ABD80D9A
    Protected Sub viewStudentMaintain_Addre_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewStudentMaintain_AddreIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewStudentMaintain_AddreItem = New viewStudentMaintain_AddreItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewStudentMaintain_Addre Delete Operation

'Record Form BeforeDelete tail @5-2BA89DC7
        viewStudentMaintain_AddreParameters()
        viewStudentMaintain_AddreLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @5-5FB50CB7
        If ErrorFlag Then
            viewStudentMaintain_AddreShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewStudentMaintain_Addre Cancel Operation @5-2CCC81DD

    Protected Sub viewStudentMaintain_Addre_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewStudentMaintain_AddreItem = New viewStudentMaintain_AddreItem()
        viewStudentMaintain_AddreIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewStudentMaintain_AddreLoadItemFromRequest(item, False)
'End Record Form viewStudentMaintain_Addre Cancel Operation

'Button Button_Cancel1 OnClick. @63-99796A77
    If CType(sender,Control).ID = "viewStudentMaintain_AddreButton_Cancel1" Then
        RedirectUrl = GetviewStudentMaintain_AddreRedirectUrl("", "")
'End Button Button_Cancel1 OnClick.

'Button Button_Cancel1 OnClick tail. @63-477CF3C9
    End If
'End Button Button_Cancel1 OnClick tail.

'Button Button_Cancel OnClick. @7-606BA801
    If CType(sender,Control).ID = "viewStudentMaintain_AddreButton_Cancel" Then
        RedirectUrl = GetviewStudentMaintain_AddreRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @7-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form viewStudentMaintain_Addre Cancel Operation tail @5-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewStudentMaintain_Addre Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A802C992
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Address_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewStudentMaintain_AddreData = New viewStudentMaintain_AddreDataProvider()
        viewStudentMaintain_AddreOperations = New FormSupportedOperations(False, True, False, True, False)
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

