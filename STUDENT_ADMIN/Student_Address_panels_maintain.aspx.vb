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

Namespace DECV_PROD2007.Student_Address_panels_maintain 'Namespace @1-9416EEF5

'Forms Definition @1-90BBE0F2
Public Class [Student_Address_panels_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-85D48DA5
    Protected ADDRESS2Data As ADDRESS2DataProvider
    Protected ADDRESS2Errors As NameValueCollection = New NameValueCollection()
    Protected ADDRESS2Operations As FormSupportedOperations
    Protected ADDRESS2IsSubmitted As Boolean = False
    Protected EditAddress2Data As EditAddress2DataProvider
    Protected EditAddress2Errors As NameValueCollection = New NameValueCollection()
    Protected EditAddress2Operations As FormSupportedOperations
    Protected EditAddress2IsSubmitted As Boolean = False
    Protected ADDRESSData As ADDRESSDataProvider
    Protected ADDRESSErrors As NameValueCollection = New NameValueCollection()
    Protected ADDRESSOperations As FormSupportedOperations
    Protected ADDRESSIsSubmitted As Boolean = False
    Protected EditAddressData As EditAddressDataProvider
    Protected EditAddressErrors As NameValueCollection = New NameValueCollection()
    Protected EditAddressOperations As FormSupportedOperations
    Protected EditAddressIsSubmitted As Boolean = False
    Protected EditAddress1Data As EditAddress1DataProvider
    Protected EditAddress1Errors As NameValueCollection = New NameValueCollection()
    Protected EditAddress1Operations As FormSupportedOperations
    Protected EditAddress1IsSubmitted As Boolean = False
    Protected ADDRESS1Data As ADDRESS1DataProvider
    Protected ADDRESS1Errors As NameValueCollection = New NameValueCollection()
    Protected ADDRESS1Operations As FormSupportedOperations
    Protected ADDRESS1IsSubmitted As Boolean = False
    Protected Student_Address_panels_maintainContentMeta As String
'End Forms Objects

	'ERA: set page level variables for student and address IDs
 	protected tmpstudent_id As Int64 = 0
	protected pagepostal_address_id As Int64
	protected pagecurrent_address_id As Int64
	protected pageoriginal_address_id As Int64

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A20454D9
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
     If Not IsPostBack Then
            'Dim PageData As PageDataProvider = New PageDataProvider()
            'PageData.FillItem(item)
            'ADDRESS2Show()
            'EditAddress2Show()
            'ADDRESSShow()
            'EditAddressShow()
            'EditAddress1Show()
            'ADDRESS1Show()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_Address_panels_maintain Event BeforeShow. Action Custom Code @310-73254650
    ' -------------------------

   

    tmpstudent_id = System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID")
	if (tmpstudent_id <> 0) then
		pagepostal_address_id = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "postal_address_id" & " FROM " & "student" & " WHERE " & "student_id=" & tmpstudent_id.tostring))).Value, Int64)
		pagecurrent_address_id = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "curr_resid_address_id" & " FROM " & "student" & " WHERE " & "student_id=" & tmpstudent_id.tostring))).Value, Int64)
		pageoriginal_address_id = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "orig_resid_address_id" & " FROM " & "student" & " WHERE " & "student_id=" & tmpstudent_id.tostring))).Value, Int64)
	end if

    ' ERA: set all EditAddressX panels to hidden,get the 'editmode'

	If Not IsPostBack Then
				Dim PageData As PageDataProvider = New PageDataProvider()
            	PageData.FillItem(item)
                Dim urleditmode As String
                urleditmode = System.Web.HttpContext.Current.Request.QueryString("editmode")

				if urleditmode=nothing then urleditmode=""

                If urleditmode.ToUpper.Equals("POSTAL") Then
					ADDRESSHolder.visible=false			'postal display
                    EditAddressShow()                   'postal Edit
                    ADDRESS1Show()                      'current display
                    EditAddress1Holder.visible = False  'current Edit
                    ADDRESS2Show()                      'original/SAC display
                    EditAddress2Holder.visible = False  'original/SAC Edit

                ElseIf urleditmode.ToUpper.Equals("CURRENT") Then
                    ADDRESSShow()                       'postal display
                    EditAddressHolder.visible = False   'postal Edit
					ADDRESS1Holder.visible=false			'current display
                    EditAddress1Show()                  'current Edit
                    ADDRESS2Show()                      'original/SAC display
                    EditAddress2Holder.visible = False  'original/SAC Edit

                ElseIf urleditmode.ToUpper.Equals("ORIGINAL") Then

                    ADDRESSShow()                       'postal display
                    EditAddressHolder.visible = False   'postal Edit
                    ADDRESS1Show()                      'current display
                    EditAddress1Holder.visible = False  'current Edit
					ADDRESS2Holder.visible=false		'original/SAC display
                    EditAddress2Show()                  'original/SAC Edit

                Else
                    ADDRESSShow()                       'postal display
                    EditAddressHolder.visible = False   'postal Edit
                    ADDRESS1Show()                      'current display
                    EditAddress1Holder.visible = False  'current Edit
                    ADDRESS2Show()                      'original/SAC display
                    EditAddress2Holder.visible = False  'original/SAC Edit
                End If
            End If

    ' -------------------------
'End Page Student_Address_panels_maintain Event BeforeShow. Action Custom Code


    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form ADDRESS2 Parameters @220-BE251D1B

    Protected Sub ADDRESS2Parameters()
        Dim item As new ADDRESS2Item
        Try
            ADDRESS2Data.Expr238 = FloatParameter.GetParam(pageoriginal_address_id, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            ADDRESS2Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ADDRESS2 Parameters

'Record Form ADDRESS2 Show method @220-3774CC35
    Protected Sub ADDRESS2Show()
        If ADDRESS2Operations.None Then
            ADDRESS2Holder.Visible = False
            Return
        End If
        Dim item As ADDRESS2Item = ADDRESS2Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ADDRESS2Operations.AllowRead
        item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.Link_EditOrigSACHref = "Student_Address_panels_maintain.aspx"
        item.Link_EditOrigSACHrefParameters.Add("editmode",System.Web.HttpUtility.UrlEncode(("original").ToString()))
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        ADDRESS2Errors.Add(item.errors)
        If ADDRESS2Errors.Count > 0 Then
            ADDRESS2ShowErrors()
            Return
        End If
'End Record Form ADDRESS2 Show method

'Record Form ADDRESS2 BeforeShow tail @220-F976602C
        ADDRESS2Parameters()
        ADDRESS2Data.FillItem(item, IsInsertMode)
        ADDRESS2Holder.DataBind()
        ADDRESS2ADDRESSEE.Text = Server.HtmlEncode(item.ADDRESSEE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2AGENT.Text = Server.HtmlEncode(item.AGENT.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2ADDR1.Text = Server.HtmlEncode(item.ADDR1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2ADDR2.Text = Server.HtmlEncode(item.ADDR2.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2SUBURB_TOWN.Text = Server.HtmlEncode(item.SUBURB_TOWN.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2PHONE_A.Text = Server.HtmlEncode(item.PHONE_A.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2FAX.Text = Server.HtmlEncode(item.FAX.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2EMAIL_ADDRESS.InnerText += item.EMAIL_ADDRESS.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS2EMAIL_ADDRESS.HRef = "mailto:" + item.EMAIL_ADDRESSHref+item.EMAIL_ADDRESSHrefParameters.ToString("GET","", ViewState)
        ADDRESS2EMAIL_ADDRESS2.InnerText += item.EMAIL_ADDRESS2.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS2EMAIL_ADDRESS2.HRef = "mailto:" + item.EMAIL_ADDRESS2Href+item.EMAIL_ADDRESS2HrefParameters.ToString("GET","", ViewState)
        ADDRESS2LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2STATE.Text = Server.HtmlEncode(item.STATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2POSTCODE.Text = Server.HtmlEncode(item.POSTCODE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2COUNTRY.Text = Server.HtmlEncode(item.COUNTRY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2PHONE_B.Text = Server.HtmlEncode(item.PHONE_B.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2Link_EditOrigSAC.InnerText += item.Link_EditOrigSAC.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS2Link_EditOrigSAC.HRef = item.Link_EditOrigSACHref+item.Link_EditOrigSACHrefParameters.ToString("GET","", ViewState)
        ADDRESS2lblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS2Link_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS2Link_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
'End Record Form ADDRESS2 BeforeShow tail

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @324-73254650
    ' -------------------------
    ' ERA: trim and format for nice links
	item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
    item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
	if not IsDBNull(item.email_addresshref) then
		ADDRESS2EMAIL_ADDRESS.HRef = "mailto:" + trim(item.EMAIL_ADDRESSHref) & item.EMAIL_ADDRESSHrefParameters.tostring("None","", ViewState)
	end if
	if not IsDBNull(item.email_address2href) then
		ADDRESS2EMAIL_ADDRESS2.HRef = "mailto:" + trim(item.EMAIL_ADDRESS2Href) & item.EMAIL_ADDRESS2HrefParameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'Record Form ADDRESS2 Show method tail @220-28399812
        If ADDRESS2Errors.Count > 0 Then
            ADDRESS2ShowErrors()
        End If
    End Sub
'End Record Form ADDRESS2 Show method tail

'Record Form ADDRESS2 LoadItemFromRequest method @220-5E12A1E3

    Protected Sub ADDRESS2LoadItemFromRequest(item As ADDRESS2Item, ByVal EnableValidation As Boolean)
        If EnableValidation Then
            item.Validate(ADDRESS2Data)
        End If
        ADDRESS2Errors.Add(item.errors)
    End Sub
'End Record Form ADDRESS2 LoadItemFromRequest method

'Record Form ADDRESS2 GetRedirectUrl method @220-DE4E907C

    Protected Function GetADDRESS2RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ADDRESS2 GetRedirectUrl method

'Record Form ADDRESS2 ShowErrors method @220-DE02FD8D

    Protected Sub ADDRESS2ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ADDRESS2Errors.Count - 1
        Select Case ADDRESS2Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ADDRESS2Errors(i)
        End Select
        Next i
        ADDRESS2Error.Visible = True
        ADDRESS2ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ADDRESS2 ShowErrors method

'Record Form ADDRESS2 Insert Operation @220-5938AF85

    Protected Sub ADDRESS2_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS2Item = New ADDRESS2Item()
        ADDRESS2IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS2 Insert Operation

'Record Form ADDRESS2 BeforeInsert tail @220-D1AB4350
    ADDRESS2Parameters()
    ADDRESS2LoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS2 BeforeInsert tail

'Record Form ADDRESS2 AfterInsert tail  @220-78A0E86F
        ErrorFlag=(ADDRESS2Errors.Count > 0)
        If ErrorFlag Then
            ADDRESS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS2 AfterInsert tail 

'Record Form ADDRESS2 Update Operation @220-68A730EF

    Protected Sub ADDRESS2_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS2Item = New ADDRESS2Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ADDRESS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS2 Update Operation

'Record Form ADDRESS2 Before Update tail @220-D1AB4350
        ADDRESS2Parameters()
        ADDRESS2LoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS2 Before Update tail

'Record Form ADDRESS2 Update Operation tail @220-78A0E86F
        ErrorFlag=(ADDRESS2Errors.Count > 0)
        If ErrorFlag Then
            ADDRESS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS2 Update Operation tail

'Record Form ADDRESS2 Delete Operation @220-80D8FF7D
    Protected Sub ADDRESS2_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ADDRESS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ADDRESS2Item = New ADDRESS2Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ADDRESS2 Delete Operation

'Record Form BeforeDelete tail @220-D1AB4350
        ADDRESS2Parameters()
        ADDRESS2LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @220-886EBE6D
        If ErrorFlag Then
            ADDRESS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ADDRESS2 Cancel Operation @220-C4BC1896

    Protected Sub ADDRESS2_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS2Item = New ADDRESS2Item()
        ADDRESS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        ADDRESS2LoadItemFromRequest(item, True)
'End Record Form ADDRESS2 Cancel Operation

'Record Form ADDRESS2 Cancel Operation tail @220-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ADDRESS2 Cancel Operation tail

'Record Form EditAddress2 Parameters @241-D437D5CD

    Protected Sub EditAddress2Parameters()
        Dim item As new EditAddress2Item
        Try
            EditAddress2Data.Expr261 = FloatParameter.GetParam(pageoriginal_address_id, ParameterSourceType.Expression, "", Nothing, false)
            EditAddress2Data.ExprKey434 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", 0, false)
            EditAddress2Data.ExprKey435 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", 0, false)
            EditAddress2Data.ExprKey447 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", Nothing, false)
            EditAddress2Data.ExprKey448 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", 0, false)
            EditAddress2Data.CtrlADDRESSEE = TextParameter.GetParam(item.ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlAGENT = TextParameter.GetParam(item.AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlADDR1 = TextParameter.GetParam(item.ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlADDR2 = TextParameter.GetParam(item.ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlSUBURB_TOWN = TextParameter.GetParam(item.SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlPOSTCODE = TextParameter.GetParam(item.POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlSTATE = TextParameter.GetParam(item.STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlCOUNTRY = TextParameter.GetParam(item.COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlPHONE_A = TextParameter.GetParam(item.PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlPHONE_B = TextParameter.GetParam(item.PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlFAX = TextParameter.GetParam(item.FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlEMAIL_ADDRESS = TextParameter.GetParam(item.EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.CtrlEMAIL_ADDRESS2 = TextParameter.GetParam(item.EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress2Data.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", "unknown", false)
            EditAddress2Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
            EditAddress2Data.Ctrlhidden_ADDRESS_ID = TextParameter.GetParam(item.hidden_ADDRESS_ID.Value, ParameterSourceType.Control, "", "", false)
        Catch e As Exception
            EditAddress2Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form EditAddress2 Parameters

'Record Form EditAddress2 Show method @241-12D6ABF7
    Protected Sub EditAddress2Show()
        If EditAddress2Operations.None Then
            EditAddress2Holder.Visible = False
            Return
        End If
        Dim item As EditAddress2Item = EditAddress2Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not EditAddress2Operations.AllowRead
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        item.Link_carer2Href = "Student_Carer_maintainext.aspx"
        EditAddress2Errors.Add(item.errors)
        If EditAddress2Errors.Count > 0 Then
            EditAddress2ShowErrors()
            Return
        End If
'End Record Form EditAddress2 Show method

'Record Form EditAddress2 BeforeShow tail @241-7E1BFD7D
        EditAddress2Parameters()
        EditAddress2Data.FillItem(item, IsInsertMode)
        EditAddress2Holder.DataBind()
        EditAddress2Button_Insert.Visible=IsInsertMode AndAlso EditAddress2Operations.AllowInsert
        EditAddress2Button_Update.Visible=Not (IsInsertMode) AndAlso EditAddress2Operations.AllowUpdate
        EditAddress2Button_Delete.Visible=Not (IsInsertMode) AndAlso EditAddress2Operations.AllowDelete
        EditAddress2ADDRESSEE.Text=item.ADDRESSEE.GetFormattedValue()
        EditAddress2AGENT.Text=item.AGENT.GetFormattedValue()
        EditAddress2ADDR1.Text=item.ADDR1.GetFormattedValue()
        EditAddress2ADDR2.Text=item.ADDR2.GetFormattedValue()
        EditAddress2SUBURB_TOWN.Text=item.SUBURB_TOWN.GetFormattedValue()
        EditAddress2POSTCODE.Text=item.POSTCODE.GetFormattedValue()
        EditAddress2PHONE_A.Text=item.PHONE_A.GetFormattedValue()
        EditAddress2FAX.Text=item.FAX.GetFormattedValue()
        EditAddress2EMAIL_ADDRESS.Text=item.EMAIL_ADDRESS.GetFormattedValue()
        EditAddress2EMAIL_ADDRESS2.Text=item.EMAIL_ADDRESS2.GetFormattedValue()
        EditAddress2LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddress2LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddress2STATE.Text=item.STATE.GetFormattedValue()
        EditAddress2COUNTRY.Text=item.COUNTRY.GetFormattedValue()
        EditAddress2PHONE_B.Text=item.PHONE_B.GetFormattedValue()
        EditAddress2lblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddress2hidden_ADDRESS_ID.Value = item.hidden_ADDRESS_ID.GetFormattedValue()
        EditAddress2Link_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        EditAddress2Link_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
        EditAddress2Link_carer2.InnerText += item.Link_carer2.GetFormattedValue().Replace(vbCrLf,"")
        EditAddress2Link_carer2.HRef = item.Link_carer2Href+item.Link_carer2HrefParameters.ToString("GET","", ViewState)
'End Record Form EditAddress2 BeforeShow tail

'Record EditAddress2 Event BeforeShow. Action Retrieve Value for Control @403-74E1D56B
            EditAddress2hidden_ADDRESS_ID.Value = (New TextField("", pageoriginal_address_id)).GetFormattedValue()
'End Record EditAddress2 Event BeforeShow. Action Retrieve Value for Control

'Record EditAddress2 Event BeforeShow. Action Custom Code @362-73254650
    ' -------------------------
    'ERA: 13-Feb-2012|EA| if the hidden_ADDRESS_ID is the same as the school ID, then do not allow the Update function
	'If (EditAddress2hidden_ADDRESS_ID.Value = me.editaddressdata.ctrlhidden_school_address_id.value) Then
		'me.editaddress2_update = false  ' LN: 7/11/2013
		'RemoveHandler Me.editaddress2_update, AddressOf EditAddress2_Update ' LN: 7/11/2013 Changed above.
		' Can't get it to work.
	'End If
    ' -------------------------
'End Record EditAddress2 Event BeforeShow. Action Custom Code

'Record Form EditAddress2 Show method tail @241-43CBEEC0
        If EditAddress2Errors.Count > 0 Then
            EditAddress2ShowErrors()
        End If
    End Sub
'End Record Form EditAddress2 Show method tail

'Record Form EditAddress2 LoadItemFromRequest method @241-22F56B91

    Protected Sub EditAddress2LoadItemFromRequest(item As EditAddress2Item, ByVal EnableValidation As Boolean)
        item.ADDRESSEE.IsEmpty = IsNothing(Request.Form(EditAddress2ADDRESSEE.UniqueID))
        If ControlCustomValues("EditAddress2ADDRESSEE") Is Nothing Then
            item.ADDRESSEE.SetValue(EditAddress2ADDRESSEE.Text)
        Else
            item.ADDRESSEE.SetValue(ControlCustomValues("EditAddress2ADDRESSEE"))
        End If
        item.AGENT.IsEmpty = IsNothing(Request.Form(EditAddress2AGENT.UniqueID))
        If ControlCustomValues("EditAddress2AGENT") Is Nothing Then
            item.AGENT.SetValue(EditAddress2AGENT.Text)
        Else
            item.AGENT.SetValue(ControlCustomValues("EditAddress2AGENT"))
        End If
        item.ADDR1.IsEmpty = IsNothing(Request.Form(EditAddress2ADDR1.UniqueID))
        If ControlCustomValues("EditAddress2ADDR1") Is Nothing Then
            item.ADDR1.SetValue(EditAddress2ADDR1.Text)
        Else
            item.ADDR1.SetValue(ControlCustomValues("EditAddress2ADDR1"))
        End If
        item.ADDR2.IsEmpty = IsNothing(Request.Form(EditAddress2ADDR2.UniqueID))
        If ControlCustomValues("EditAddress2ADDR2") Is Nothing Then
            item.ADDR2.SetValue(EditAddress2ADDR2.Text)
        Else
            item.ADDR2.SetValue(ControlCustomValues("EditAddress2ADDR2"))
        End If
        item.SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(EditAddress2SUBURB_TOWN.UniqueID))
        If ControlCustomValues("EditAddress2SUBURB_TOWN") Is Nothing Then
            item.SUBURB_TOWN.SetValue(EditAddress2SUBURB_TOWN.Text)
        Else
            item.SUBURB_TOWN.SetValue(ControlCustomValues("EditAddress2SUBURB_TOWN"))
        End If
        item.POSTCODE.IsEmpty = IsNothing(Request.Form(EditAddress2POSTCODE.UniqueID))
        If ControlCustomValues("EditAddress2POSTCODE") Is Nothing Then
            item.POSTCODE.SetValue(EditAddress2POSTCODE.Text)
        Else
            item.POSTCODE.SetValue(ControlCustomValues("EditAddress2POSTCODE"))
        End If
        item.PHONE_A.IsEmpty = IsNothing(Request.Form(EditAddress2PHONE_A.UniqueID))
        If ControlCustomValues("EditAddress2PHONE_A") Is Nothing Then
            item.PHONE_A.SetValue(EditAddress2PHONE_A.Text)
        Else
            item.PHONE_A.SetValue(ControlCustomValues("EditAddress2PHONE_A"))
        End If
        item.FAX.IsEmpty = IsNothing(Request.Form(EditAddress2FAX.UniqueID))
        If ControlCustomValues("EditAddress2FAX") Is Nothing Then
            item.FAX.SetValue(EditAddress2FAX.Text)
        Else
            item.FAX.SetValue(ControlCustomValues("EditAddress2FAX"))
        End If
        item.EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(EditAddress2EMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("EditAddress2EMAIL_ADDRESS") Is Nothing Then
            item.EMAIL_ADDRESS.SetValue(EditAddress2EMAIL_ADDRESS.Text)
        Else
            item.EMAIL_ADDRESS.SetValue(ControlCustomValues("EditAddress2EMAIL_ADDRESS"))
        End If
        item.EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(EditAddress2EMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("EditAddress2EMAIL_ADDRESS2") Is Nothing Then
            item.EMAIL_ADDRESS2.SetValue(EditAddress2EMAIL_ADDRESS2.Text)
        Else
            item.EMAIL_ADDRESS2.SetValue(ControlCustomValues("EditAddress2EMAIL_ADDRESS2"))
        End If
        item.STATE.IsEmpty = IsNothing(Request.Form(EditAddress2STATE.UniqueID))
        If ControlCustomValues("EditAddress2STATE") Is Nothing Then
            item.STATE.SetValue(EditAddress2STATE.Text)
        Else
            item.STATE.SetValue(ControlCustomValues("EditAddress2STATE"))
        End If
        item.COUNTRY.IsEmpty = IsNothing(Request.Form(EditAddress2COUNTRY.UniqueID))
        If ControlCustomValues("EditAddress2COUNTRY") Is Nothing Then
            item.COUNTRY.SetValue(EditAddress2COUNTRY.Text)
        Else
            item.COUNTRY.SetValue(ControlCustomValues("EditAddress2COUNTRY"))
        End If
        item.PHONE_B.IsEmpty = IsNothing(Request.Form(EditAddress2PHONE_B.UniqueID))
        If ControlCustomValues("EditAddress2PHONE_B") Is Nothing Then
            item.PHONE_B.SetValue(EditAddress2PHONE_B.Text)
        Else
            item.PHONE_B.SetValue(ControlCustomValues("EditAddress2PHONE_B"))
        End If
        item.hidden_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddress2hidden_ADDRESS_ID.UniqueID))
        item.hidden_ADDRESS_ID.SetValue(EditAddress2hidden_ADDRESS_ID.Value)
        If EnableValidation Then
            item.Validate(EditAddress2Data)
        End If
        EditAddress2Errors.Add(item.errors)
    End Sub
'End Record Form EditAddress2 LoadItemFromRequest method

'Record Form EditAddress2 GetRedirectUrl method @241-77DD20CF

    Protected Function GetEditAddress2RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form EditAddress2 GetRedirectUrl method

'Record Form EditAddress2 ShowErrors method @241-175346F4

    Protected Sub EditAddress2ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To EditAddress2Errors.Count - 1
        Select Case EditAddress2Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & EditAddress2Errors(i)
        End Select
        Next i
        EditAddress2Error.Visible = True
        EditAddress2ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form EditAddress2 ShowErrors method

'Record Form EditAddress2 Insert Operation @241-3CA862BF

    Protected Sub EditAddress2_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress2Item = New EditAddress2Item()
        Dim ExecuteFlag As Boolean = True
        EditAddress2IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress2 Insert Operation

'Button Button_Insert OnClick. @242-F2E03E03
        If CType(sender,Control).ID = "EditAddress2Button_Insert" Then
            RedirectUrl = GetEditAddress2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @242-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form EditAddress2 BeforeInsert tail @241-4B79168F
    EditAddress2Parameters()
    EditAddress2LoadItemFromRequest(item, EnableValidation)
    If EditAddress2Operations.AllowInsert Then
        ErrorFlag=(EditAddress2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddress2Data.InsertItem(item)
            Catch ex As Exception
                EditAddress2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress2 BeforeInsert tail

'Record Form EditAddress2 AfterInsert tail  @241-AD73CAB7
        End If
        ErrorFlag=(EditAddress2Errors.Count > 0)
        If ErrorFlag Then
            EditAddress2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress2 AfterInsert tail 

'Record Form EditAddress2 Update Operation @241-86D8C6BB

    Protected Sub EditAddress2_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress2Item = New EditAddress2Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditAddress2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress2 Update Operation

'Button Button_Update OnClick. @243-843F7F10
        If CType(sender,Control).ID = "EditAddress2Button_Update" Then
            RedirectUrl = GetEditAddress2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @243-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form EditAddress2 Before Update tail @241-C307506C
        EditAddress2Parameters()
        EditAddress2LoadItemFromRequest(item, EnableValidation)
        If EditAddress2Operations.AllowUpdate Then
        ErrorFlag = (EditAddress2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddress2Data.UpdateItem(item)
            Catch ex As Exception
                EditAddress2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress2 Before Update tail

'Record EditAddress2 Event AfterUpdate. Action Custom Code @359-73254650
    ' -------------------------
    ' ERA: after save, get the address id and update the student record
	'NOT NEEDED for original - it's either an update (and we have the ID) 
	'	or an INSERT sorted in the After Insert

    ' -------------------------
'End Record EditAddress2 Event AfterUpdate. Action Custom Code

'Record Form EditAddress2 Update Operation tail @241-AD73CAB7
        End If
        ErrorFlag=(EditAddress2Errors.Count > 0)
        If ErrorFlag Then
            EditAddress2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress2 Update Operation tail

'Record Form EditAddress2 Delete Operation @241-78A621C3
    Protected Sub EditAddress2_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditAddress2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As EditAddress2Item = New EditAddress2Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form EditAddress2 Delete Operation

'Button Button_Delete OnClick. @244-B4956CDD
        If CType(sender,Control).ID = "EditAddress2Button_Delete" Then
            RedirectUrl = GetEditAddress2RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @244-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @241-E6A692D5
        EditAddress2Parameters()
        EditAddress2LoadItemFromRequest(item, EnableValidation)
        If EditAddress2Operations.AllowDelete Then
        ErrorFlag = (EditAddress2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddress2Data.DeleteItem(item)
            Catch ex As Exception
                EditAddress2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @241-708ED6D8
        End If
        If ErrorFlag Then
            EditAddress2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form EditAddress2 Cancel Operation @241-E073266D

    Protected Sub EditAddress2_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress2Item = New EditAddress2Item()
        EditAddress2IsSubmitted = True
        Dim RedirectUrl As String = ""
        EditAddress2LoadItemFromRequest(item, False)
'End Record Form EditAddress2 Cancel Operation

'Button Button_Cancel OnClick. @245-2D882E30
    If CType(sender,Control).ID = "EditAddress2Button_Cancel" Then
        RedirectUrl = GetEditAddress2RedirectUrl("", "editmode")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @245-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form EditAddress2 Cancel Operation tail @241-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form EditAddress2 Cancel Operation tail

'Record Form ADDRESS Parameters @31-5E02D3EF

    Protected Sub ADDRESSParameters()
        Dim item As new ADDRESSItem
        Try
            ADDRESSData.Expr146 = FloatParameter.GetParam(pagepostal_address_id, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            ADDRESSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ADDRESS Parameters

'Record Form ADDRESS Show method @31-5EDE58FB
    Protected Sub ADDRESSShow()
        If ADDRESSOperations.None Then
            ADDRESSHolder.Visible = False
            Return
        End If
        Dim item As ADDRESSItem = ADDRESSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ADDRESSOperations.AllowRead
        item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.Link_EditPostalHref = "Student_Address_panels_maintain.aspx"
        item.Link_EditPostalHrefParameters.Add("editmode",System.Web.HttpUtility.UrlEncode(("postal").ToString()))
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        ADDRESSErrors.Add(item.errors)
        If ADDRESSErrors.Count > 0 Then
            ADDRESSShowErrors()
            Return
        End If
'End Record Form ADDRESS Show method

'Record Form ADDRESS BeforeShow tail @31-CD3CC7BA
        ADDRESSParameters()
        ADDRESSData.FillItem(item, IsInsertMode)
        ADDRESSHolder.DataBind()
        ADDRESSADDRESSEE.Text = Server.HtmlEncode(item.ADDRESSEE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSAGENT.Text = Server.HtmlEncode(item.AGENT.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSADDR1.Text = Server.HtmlEncode(item.ADDR1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSADDR2.Text = Server.HtmlEncode(item.ADDR2.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSSUBURB_TOWN.Text = Server.HtmlEncode(item.SUBURB_TOWN.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSPHONE_A.Text = Server.HtmlEncode(item.PHONE_A.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSFAX.Text = Server.HtmlEncode(item.FAX.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSEMAIL_ADDRESS.InnerText += item.EMAIL_ADDRESS.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESSEMAIL_ADDRESS.HRef = "mailto:" + item.EMAIL_ADDRESSHref+item.EMAIL_ADDRESSHrefParameters.ToString("GET","", ViewState)
        ADDRESSEMAIL_ADDRESS2.InnerText += item.EMAIL_ADDRESS2.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESSEMAIL_ADDRESS2.HRef = "mailto:" + item.EMAIL_ADDRESS2Href+item.EMAIL_ADDRESS2HrefParameters.ToString("GET","", ViewState)
        ADDRESSLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSSTATE.Text = Server.HtmlEncode(item.STATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSPOSTCODE.Text = Server.HtmlEncode(item.POSTCODE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSCOUNTRY.Text = Server.HtmlEncode(item.COUNTRY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSPHONE_B.Text = Server.HtmlEncode(item.PHONE_B.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSLink_EditPostal.InnerText += item.Link_EditPostal.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESSLink_EditPostal.HRef = item.Link_EditPostalHref+item.Link_EditPostalHrefParameters.ToString("GET","editmode", ViewState)
        ADDRESSlblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESSLink_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESSLink_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
        ADDRESSlblEmailType.Text = Server.HtmlEncode(item.lblEmailType.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form ADDRESS BeforeShow tail

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @325-73254650
    ' -------------------------
    ' ERA: trim and format for nice links
	item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
    item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
	if not IsDBNull(item.email_addresshref) then
		ADDRESSEMAIL_ADDRESS.HRef = "mailto:" + trim(item.EMAIL_ADDRESSHref) & item.EMAIL_ADDRESSHrefParameters.tostring("None","", ViewState)
	end if
	if not IsDBNull(item.email_address2href) then
		ADDRESSEMAIL_ADDRESS2.HRef = "mailto:" + trim(item.EMAIL_ADDRESS2Href) & item.EMAIL_ADDRESS2HrefParameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'Label lblEmailType Event BeforeShow. Action Custom Code @477-73254650
    ' -------------------------
    'ERA: 5-May-2011|bit of a cheat - if postal_address_id < XXX or ADDRESSADDRESSEE.Text contains 'PRINCIPAL' then assume School and hide label showing 'Student'
	if (pagepostal_address_id <= 700 ) or (ADDRESSADDRESSEE.Text.Contains("PRINCIPAL")) then
		ADDRESSlblEmailType.visible = false
	end if
    ' -------------------------
'End Label lblEmailType Event BeforeShow. Action Custom Code

'Record ADDRESS Event BeforeShow. Action Hide-Show Component @309-85D0916A
        Dim Urleditmode_309_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("editmode"))
        Dim ExprParam2_309_2 As TextField = New TextField("", ("postal"))
        If FieldBase.EqualOp(Urleditmode_309_1, ExprParam2_309_2) Then
            ADDRESSHolder.Visible = False
        End If
'End Record ADDRESS Event BeforeShow. Action Hide-Show Component

'Record Form ADDRESS Show method tail @31-CB863EFB
        If ADDRESSErrors.Count > 0 Then
            ADDRESSShowErrors()
        End If
    End Sub
'End Record Form ADDRESS Show method tail

'Record Form ADDRESS LoadItemFromRequest method @31-467EB21A

    Protected Sub ADDRESSLoadItemFromRequest(item As ADDRESSItem, ByVal EnableValidation As Boolean)
        If EnableValidation Then
            item.Validate(ADDRESSData)
        End If
        ADDRESSErrors.Add(item.errors)
    End Sub
'End Record Form ADDRESS LoadItemFromRequest method

'Record Form ADDRESS GetRedirectUrl method @31-BD35DFB0

    Protected Function GetADDRESSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;flagattendingschool;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ADDRESS GetRedirectUrl method

'Record Form ADDRESS ShowErrors method @31-E1038B74

    Protected Sub ADDRESSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ADDRESSErrors.Count - 1
        Select Case ADDRESSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ADDRESSErrors(i)
        End Select
        Next i
        ADDRESSError.Visible = True
        ADDRESSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ADDRESS ShowErrors method

'Record Form ADDRESS Insert Operation @31-54A26148

    Protected Sub ADDRESS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESSItem = New ADDRESSItem()
        ADDRESSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS Insert Operation

'Record Form ADDRESS BeforeInsert tail @31-BC443600
    ADDRESSParameters()
    ADDRESSLoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS BeforeInsert tail

'Record Form ADDRESS AfterInsert tail  @31-0568CA8A
        ErrorFlag=(ADDRESSErrors.Count > 0)
        If ErrorFlag Then
            ADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS AfterInsert tail 

'Record Form ADDRESS Update Operation @31-DB6F82F3

    Protected Sub ADDRESS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESSItem = New ADDRESSItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS Update Operation

'Record Form ADDRESS Before Update tail @31-BC443600
        ADDRESSParameters()
        ADDRESSLoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS Before Update tail

'Record Form ADDRESS Update Operation tail @31-0568CA8A
        ErrorFlag=(ADDRESSErrors.Count > 0)
        If ErrorFlag Then
            ADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS Update Operation tail

'Record Form ADDRESS Delete Operation @31-F07DD132
    Protected Sub ADDRESS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ADDRESSItem = New ADDRESSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ADDRESS Delete Operation

'Record Form BeforeDelete tail @31-BC443600
        ADDRESSParameters()
        ADDRESSLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @31-AFED81DB
        If ErrorFlag Then
            ADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ADDRESS Cancel Operation @31-35B99CDF

    Protected Sub ADDRESS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESSItem = New ADDRESSItem()
        ADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        ADDRESSLoadItemFromRequest(item, True)
'End Record Form ADDRESS Cancel Operation

'Record Form ADDRESS Cancel Operation tail @31-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ADDRESS Cancel Operation tail

'Record Form EditAddress Parameters @10-9455A1A6

    Protected Sub EditAddressParameters()
        Dim item As new EditAddressItem
        Try
            EditAddressData.Expr171 = FloatParameter.GetParam(pagepostal_address_id, ParameterSourceType.Expression, "", Nothing, false)
            EditAddressData.Ctrlcbox_same_as_school = IntegerParameter.GetParam(item.cbox_same_as_school.Value, ParameterSourceType.Control, "", 0, false)
            EditAddressData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            EditAddressData.Ctrlhidden_ADDRESS_ID = IntegerParameter.GetParam(item.hidden_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.Ctrlhidden_SCHOOL_ADDRESS_ID = IntegerParameter.GetParam(item.hidden_SCHOOL_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.Ctrlhidden_flag_same_as = IntegerParameter.GetParam(item.hidden_flag_same_as.Value, ParameterSourceType.Control, "", 0, false)
            EditAddressData.CtrlADDRESSEE = TextParameter.GetParam(item.ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlAGENT = TextParameter.GetParam(item.AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlADDR1 = TextParameter.GetParam(item.ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlADDR2 = TextParameter.GetParam(item.ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlSUBURB_TOWN = TextParameter.GetParam(item.SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlPOSTCODE = TextParameter.GetParam(item.POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlSTATE = TextParameter.GetParam(item.STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlCOUNTRY = TextParameter.GetParam(item.COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlPHONE_A = TextParameter.GetParam(item.PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlPHONE_B = TextParameter.GetParam(item.PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlFAX = TextParameter.GetParam(item.FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlEMAIL_ADDRESS = TextParameter.GetParam(item.EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.CtrlEMAIL_ADDRESS2 = TextParameter.GetParam(item.EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddressData.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", "unknown", false)
        Catch e As Exception
            EditAddressErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form EditAddress Parameters

'Record Form EditAddress Show method @10-991BF71F
    Protected Sub EditAddressShow()
        If EditAddressOperations.None Then
            EditAddressHolder.Visible = False
            Return
        End If
        Dim item As EditAddressItem = EditAddressItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not EditAddressOperations.AllowRead
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        EditAddressErrors.Add(item.errors)
        If EditAddressErrors.Count > 0 Then
            EditAddressShowErrors()
            Return
        End If
'End Record Form EditAddress Show method

'Record Form EditAddress BeforeShow tail @10-4677DA60
        EditAddressParameters()
        EditAddressData.FillItem(item, IsInsertMode)
        EditAddressHolder.DataBind()
        EditAddressButton_Insert.Visible=IsInsertMode AndAlso EditAddressOperations.AllowInsert
        EditAddressButton_Update.Visible=Not (IsInsertMode) AndAlso EditAddressOperations.AllowUpdate
        EditAddressButton_Delete.Visible=Not (IsInsertMode) AndAlso EditAddressOperations.AllowDelete
        EditAddressADDRESSEE.Text=item.ADDRESSEE.GetFormattedValue()
        EditAddressAGENT.Text=item.AGENT.GetFormattedValue()
        EditAddressADDR1.Text=item.ADDR1.GetFormattedValue()
        EditAddressADDR2.Text=item.ADDR2.GetFormattedValue()
        EditAddressSUBURB_TOWN.Text=item.SUBURB_TOWN.GetFormattedValue()
        EditAddressPOSTCODE.Text=item.POSTCODE.GetFormattedValue()
        EditAddressPHONE_A.Text=item.PHONE_A.GetFormattedValue()
        EditAddressFAX.Text=item.FAX.GetFormattedValue()
        EditAddressEMAIL_ADDRESS.Text=item.EMAIL_ADDRESS.GetFormattedValue()
        EditAddressEMAIL_ADDRESS2.Text=item.EMAIL_ADDRESS2.GetFormattedValue()
        EditAddressLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddressLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddressSTATE.Text=item.STATE.GetFormattedValue()
        EditAddressCOUNTRY.Text=item.COUNTRY.GetFormattedValue()
        EditAddressPHONE_B.Text=item.PHONE_B.GetFormattedValue()
        EditAddresslblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        If item.cbox_same_as_schoolCheckedValue.Value.Equals(item.cbox_same_as_school.Value) Then
            EditAddresscbox_same_as_school.Checked = True
        End If
        EditAddresshidden_SCHOOL_ADDRESS_ID.Value = item.hidden_SCHOOL_ADDRESS_ID.GetFormattedValue()
        EditAddresshidden_flag_same_as.Value = item.hidden_flag_same_as.GetFormattedValue()
        EditAddressHidden_AddressHash.Value = item.Hidden_AddressHash.GetFormattedValue()
        EditAddressLink_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        EditAddressLink_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
        EditAddresshidden_ADDRESS_ID.Value = item.hidden_ADDRESS_ID.GetFormattedValue()
        EditAddresslblChangeAttendingSchool.Text = Server.HtmlEncode(item.lblChangeAttendingSchool.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddresshidden_CURRENT_ADDRESS_ID.Value = item.hidden_CURRENT_ADDRESS_ID.GetFormattedValue()
'End Record Form EditAddress BeforeShow tail

'Hidden Hidden_AddressHash Event BeforeShow. Action Custom Code @459-73254650
    ' -------------------------
    'ERA: 28-Aug-2009|EA| get a Security.Utility.MD5() of ADDR1, ADDR2, SUBURB_TOWN and POSTCODE (State and Country kinda useless as if we haven't got it already then these changing won't help)
	dim addresshash as string = ""
	addresshash += Security.securityutility.md5(RTrim(EditAddressADDR1.Text) + RTrim(EditAddressADDR2.Text) + RTrim(EditAddressSUBURB_TOWN.Text) + RTrim(EditAddressPOSTCODE.Text))
	item.Hidden_AddressHash.setvalue(addresshash)
 	EditAddressHidden_AddressHash.Value = item.Hidden_AddressHash.GetFormattedValue()
    ' -------------------------
'End Hidden Hidden_AddressHash Event BeforeShow. Action Custom Code

'Label lblChangeAttendingSchool Event BeforeShow. Action Hide-Show Component @481-E58B92BA
        Dim Urlflagattendingschool_481_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("flagattendingschool"))
        Dim ExprParam2_481_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urlflagattendingschool_481_1, ExprParam2_481_2) Then
            EditAddresslblChangeAttendingSchool.Visible = False
        End If
'End Label lblChangeAttendingSchool Event BeforeShow. Action Hide-Show Component

'Record EditAddress Event BeforeShow. Action Retrieve Value for Control @342-A2365FD9
            EditAddresshidden_ADDRESS_ID.Value = (New TextField("", pagepostal_address_id)).GetFormattedValue()
'End Record EditAddress Event BeforeShow. Action Retrieve Value for Control

'Record EditAddress Event BeforeShow. Action Retrieve Value for Control @483-D340169A
            EditAddresshidden_CURRENT_ADDRESS_ID.Value = (New TextField("", pagecurrent_address_id)).GetFormattedValue()
'End Record EditAddress Event BeforeShow. Action Retrieve Value for Control

'Record EditAddress Event BeforeShow. Action Custom Code @328-73254650
    ' -------------------------
    	Dim attending_school_address_id As Int64 = 0
		'pagepostal_address_id
		
		if not (tmpstudent_id=0) then
			attending_school_address_id = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select top 1 ADDRESS_ID from SCHOOL where SCHOOL_ID in (select attending_school_id from student where student_id = " & tmpstudent_id.tostring & ")"))).Value, Int64)
	
			'Feb-2009|EA| added as temp storage so it can be retreived and set into PostalAddress ID when ticking box
	
			item.hidden_school_address_id.value = attending_school_address_id
			EditAddresshidden_SCHOOL_ADDRESS_ID.value=item.hidden_SCHOOL_ADDRESS_ID.GetFormattedValue()

			' and set the checkboxes for Same As School and Same as Postal from the values above
			If (EditAddresshidden_SCHOOL_ADDRESS_ID.value = EditAddresshidden_ADDRESS_ID.value) Then
			'if (attending_school_address_id.tostring=item.hidden_address_id.value) then
				item.cbox_same_as_school.setvalue(item.cbox_same_as_schoolCheckedValue.Value)
				EditAddresscbox_same_as_school.Checked = true
				'EditAddresshidden_flag_same_as.value="1"	' hidden
				EditAddresshidden_flag_same_as.value="1"	'debug textbox
			else
				item.cbox_same_as_school.setvalue(item.cbox_same_as_schooluncheckedvalue.value)
				EditAddresscbox_same_as_school.Checked = false
				'EditAddresshidden_flag_same_as.value="0"
				EditAddresshidden_flag_same_as.value="0"
			end if
		end if
    ' -------------------------
'End Record EditAddress Event BeforeShow. Action Custom Code

'Record Form EditAddress Show method tail @10-70D5D818
        If EditAddressErrors.Count > 0 Then
            EditAddressShowErrors()
        End If
    End Sub
'End Record Form EditAddress Show method tail

'Record Form EditAddress LoadItemFromRequest method @10-631DA63D

    Protected Sub EditAddressLoadItemFromRequest(item As EditAddressItem, ByVal EnableValidation As Boolean)
        item.ADDRESSEE.IsEmpty = IsNothing(Request.Form(EditAddressADDRESSEE.UniqueID))
        If ControlCustomValues("EditAddressADDRESSEE") Is Nothing Then
            item.ADDRESSEE.SetValue(EditAddressADDRESSEE.Text)
        Else
            item.ADDRESSEE.SetValue(ControlCustomValues("EditAddressADDRESSEE"))
        End If
        item.AGENT.IsEmpty = IsNothing(Request.Form(EditAddressAGENT.UniqueID))
        If ControlCustomValues("EditAddressAGENT") Is Nothing Then
            item.AGENT.SetValue(EditAddressAGENT.Text)
        Else
            item.AGENT.SetValue(ControlCustomValues("EditAddressAGENT"))
        End If
        item.ADDR1.IsEmpty = IsNothing(Request.Form(EditAddressADDR1.UniqueID))
        If ControlCustomValues("EditAddressADDR1") Is Nothing Then
            item.ADDR1.SetValue(EditAddressADDR1.Text)
        Else
            item.ADDR1.SetValue(ControlCustomValues("EditAddressADDR1"))
        End If
        item.ADDR2.IsEmpty = IsNothing(Request.Form(EditAddressADDR2.UniqueID))
        If ControlCustomValues("EditAddressADDR2") Is Nothing Then
            item.ADDR2.SetValue(EditAddressADDR2.Text)
        Else
            item.ADDR2.SetValue(ControlCustomValues("EditAddressADDR2"))
        End If
        item.SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(EditAddressSUBURB_TOWN.UniqueID))
        If ControlCustomValues("EditAddressSUBURB_TOWN") Is Nothing Then
            item.SUBURB_TOWN.SetValue(EditAddressSUBURB_TOWN.Text)
        Else
            item.SUBURB_TOWN.SetValue(ControlCustomValues("EditAddressSUBURB_TOWN"))
        End If
        item.POSTCODE.IsEmpty = IsNothing(Request.Form(EditAddressPOSTCODE.UniqueID))
        If ControlCustomValues("EditAddressPOSTCODE") Is Nothing Then
            item.POSTCODE.SetValue(EditAddressPOSTCODE.Text)
        Else
            item.POSTCODE.SetValue(ControlCustomValues("EditAddressPOSTCODE"))
        End If
        item.PHONE_A.IsEmpty = IsNothing(Request.Form(EditAddressPHONE_A.UniqueID))
        If ControlCustomValues("EditAddressPHONE_A") Is Nothing Then
            item.PHONE_A.SetValue(EditAddressPHONE_A.Text)
        Else
            item.PHONE_A.SetValue(ControlCustomValues("EditAddressPHONE_A"))
        End If
        item.FAX.IsEmpty = IsNothing(Request.Form(EditAddressFAX.UniqueID))
        If ControlCustomValues("EditAddressFAX") Is Nothing Then
            item.FAX.SetValue(EditAddressFAX.Text)
        Else
            item.FAX.SetValue(ControlCustomValues("EditAddressFAX"))
        End If
        item.EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(EditAddressEMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("EditAddressEMAIL_ADDRESS") Is Nothing Then
            item.EMAIL_ADDRESS.SetValue(EditAddressEMAIL_ADDRESS.Text)
        Else
            item.EMAIL_ADDRESS.SetValue(ControlCustomValues("EditAddressEMAIL_ADDRESS"))
        End If
        item.EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(EditAddressEMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("EditAddressEMAIL_ADDRESS2") Is Nothing Then
            item.EMAIL_ADDRESS2.SetValue(EditAddressEMAIL_ADDRESS2.Text)
        Else
            item.EMAIL_ADDRESS2.SetValue(ControlCustomValues("EditAddressEMAIL_ADDRESS2"))
        End If
        item.STATE.IsEmpty = IsNothing(Request.Form(EditAddressSTATE.UniqueID))
        If ControlCustomValues("EditAddressSTATE") Is Nothing Then
            item.STATE.SetValue(EditAddressSTATE.Text)
        Else
            item.STATE.SetValue(ControlCustomValues("EditAddressSTATE"))
        End If
        item.COUNTRY.IsEmpty = IsNothing(Request.Form(EditAddressCOUNTRY.UniqueID))
        If ControlCustomValues("EditAddressCOUNTRY") Is Nothing Then
            item.COUNTRY.SetValue(EditAddressCOUNTRY.Text)
        Else
            item.COUNTRY.SetValue(ControlCustomValues("EditAddressCOUNTRY"))
        End If
        item.PHONE_B.IsEmpty = IsNothing(Request.Form(EditAddressPHONE_B.UniqueID))
        If ControlCustomValues("EditAddressPHONE_B") Is Nothing Then
            item.PHONE_B.SetValue(EditAddressPHONE_B.Text)
        Else
            item.PHONE_B.SetValue(ControlCustomValues("EditAddressPHONE_B"))
        End If
        If EditAddresscbox_same_as_school.Checked Then
            item.cbox_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)
        Else
            item.cbox_same_as_school.Value = (item.cbox_same_as_schoolUncheckedValue.Value)
        End If
        item.hidden_SCHOOL_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddresshidden_SCHOOL_ADDRESS_ID.UniqueID))
        item.hidden_SCHOOL_ADDRESS_ID.SetValue(EditAddresshidden_SCHOOL_ADDRESS_ID.Value)
        Try
        item.hidden_flag_same_as.IsEmpty = IsNothing(Request.Form(EditAddresshidden_flag_same_as.UniqueID))
        item.hidden_flag_same_as.SetValue(EditAddresshidden_flag_same_as.Value)
        Catch ae As ArgumentException
            EditAddressErrors.Add("hidden_flag_same_as",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_flag_same_as"))
        End Try
        item.Hidden_AddressHash.IsEmpty = IsNothing(Request.Form(EditAddressHidden_AddressHash.UniqueID))
        item.Hidden_AddressHash.SetValue(EditAddressHidden_AddressHash.Value)
        item.hidden_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddresshidden_ADDRESS_ID.UniqueID))
        item.hidden_ADDRESS_ID.SetValue(EditAddresshidden_ADDRESS_ID.Value)
        item.hidden_CURRENT_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddresshidden_CURRENT_ADDRESS_ID.UniqueID))
        item.hidden_CURRENT_ADDRESS_ID.SetValue(EditAddresshidden_CURRENT_ADDRESS_ID.Value)
        If EnableValidation Then
            item.Validate(EditAddressData)
        End If
        EditAddressErrors.Add(item.errors)
    End Sub
'End Record Form EditAddress LoadItemFromRequest method

'Record Form EditAddress GetRedirectUrl method @10-04C45FB8

    Protected Function GetEditAddressRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;flagattendingschool;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form EditAddress GetRedirectUrl method

'Record Form EditAddress ShowErrors method @10-1675AA54

    Protected Sub EditAddressShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To EditAddressErrors.Count - 1
        Select Case EditAddressErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & EditAddressErrors(i)
        End Select
        Next i
        EditAddressError.Visible = True
        EditAddressErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form EditAddress ShowErrors method

'Record Form EditAddress Insert Operation @10-A1F4FE49

    Protected Sub EditAddress_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddressItem = New EditAddressItem()
        Dim ExecuteFlag As Boolean = True
        EditAddressIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress Insert Operation

'Button Button_Insert OnClick. @11-5E31162E
        If CType(sender,Control).ID = "EditAddressButton_Insert" Then
            RedirectUrl = GetEditAddressRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @11-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form EditAddress BeforeInsert tail @10-A82538D6
    EditAddressParameters()
    EditAddressLoadItemFromRequest(item, EnableValidation)
    If EditAddressOperations.AllowInsert Then
        ErrorFlag=(EditAddressErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddressData.InsertItem(item)
            Catch ex As Exception
                EditAddressErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress BeforeInsert tail

'Record Form EditAddress AfterInsert tail  @10-CFB69020
        End If
        ErrorFlag=(EditAddressErrors.Count > 0)
        If ErrorFlag Then
            EditAddressShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress AfterInsert tail 

'Record Form EditAddress Update Operation @10-9D0C341C

    Protected Sub EditAddress_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddressItem = New EditAddressItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditAddressIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress Update Operation

'Button Button_Update OnClick. @12-5D31956E
        If CType(sender,Control).ID = "EditAddressButton_Update" Then
            RedirectUrl = GetEditAddressRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @12-477CF3C9
        End If
'End Button Button_Update OnClick tail.

            'Record EditAddress Event BeforeUpdate. Action Custom Code @457-73254650
            Response.Write("item.ADDR1: " & item.ADDR1.Value)
    ' -------------------------
    'Mar 2009 - Debug the values going to the database as the stored proc is not working

'	EditAddressErrors.Add("Debug","School ID: [" & EditAddresshidden_SCHOOL_ADDRESS_ID.Text & "]")	
'	EditAddressErrors.Add("Debug","Address ID: [" & EditAddresshidden_ADDRESS_ID.Text & "]")	
'	EditAddressErrors.Add("Debug","same as flag: [" & EditAddresshidden_flag_same_as.Text & "]")	
'	EditAddressErrors.Add("Debug","Addressee: [" & EditAddressADDRESSEE.Text & "]")
'	EditAddressErrors.Add("Debug","Agent: [" & EditAddressAGENT.Text & "]")
'	EditAddressErrors.Add("Debug","Addr1: [" & EditAddressADDR1.Text & "]")
'	EditAddressErrors.Add("Debug","Addr2: [" & EditAddressADDR2.Text & "]")
'	EditAddressErrors.Add("Debug","Suburb Town: [" & EditAddressSUBURB_TOWN.Text & "]")
'	EditAddressErrors.Add("Debug","State: [" & EditAddressSTATE.Text & "]")
'	EditAddressErrors.Add("Debug","Country: [" & EditAddressCOUNTRY.Text & "]")
'	EditAddressErrors.Add("Debug","Phone 1: [" & EditAddressPHONE_A.Text & "]")
'	EditAddressErrors.Add("Debug","Phone 2: [" & EditAddressPHONE_B.Text & "]")
'	EditAddressErrors.Add("Debug","Fax: [" & EditAddressFAX.Text & "]")
'	EditAddressErrors.Add("Debug","Email 1: [" & EditAddressEMAIL_ADDRESS.Text & "]")
'	EditAddressErrors.Add("Debug","Email 2: [" & EditAddressEMAIL_ADDRESS2.Text & "]")
'

 	'ERA: 28-Aug-2009|EA| detect if the Postal Address fields that affect the Barcode generation from Hopewise has changed
	' (get a Security.Utility.MD5() of ADDR1, ADDR2, SUBURB_TOWN and POSTCODE)
	'dim addresshashcheck_postal as string = ""
	'addresshashcheck_postal += Security.securityutility.md5(RTrim(EditAddressADDR1.Text) + RTrim(EditAddressADDR2.Text) + RTrim(EditAddressSUBURB_TOWN.Text) + RTrim(EditAddressPOSTCODE.Text))
	'if (String.Compare(addresshashcheck_postal.text, item.Hidden_AddressHash.GetFormattedValue()) != 0) then
	'	' set barcode to blank
	'end if
	'' NOT NEEDED - will do it all in the stored proc that does the updates - spu_UpdateStudentAddress_Postalpanel, spu_UpdateStudentAddress_Currentpanel, spu_UpdateStudentAddress_Originalpanel

    ' -------------------------
'End Record EditAddress Event BeforeUpdate. Action Custom Code




'Record Form EditAddress Before Update tail @10-7223794E
        EditAddressParameters()
        EditAddressLoadItemFromRequest(item, EnableValidation)
        If EditAddressOperations.AllowUpdate Then
        ErrorFlag = (EditAddressErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddressData.UpdateItem(item)
            Catch ex As Exception
                EditAddressErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress Before Update tail

'DEL      ' -------------------------
'DEL  	    ' ERA: after save, get the address id and update the student record
'DEL  		if (tmpstudent_id <> 0) and (not ErrorFlag) then
'DEL  			dim thisaddressid as int64
'DEL  			if (item.cbox_same_as_school.Value = (item.cbox_same_as_schoolCheckedValue.Value)) then
'DEL  				thisaddressid = item.hidden_school_address_id.getformattedvalue()
'DEL  			else
'DEL  				thisaddressid = item.hidden_address_id.getformattedvalue()
'DEL  			end if
'DEL  			ErrorFlag = not updateSTUDENTAddressID(1,thisaddressid, tmpstudent_id)	' 1=Postal;2=CurrResid;3=OrigResid
'DEL  		end if
'DEL  	
'DEL      ' -------------------------


'Record Form EditAddress Update Operation tail @10-CFB69020
        End If
        ErrorFlag=(EditAddressErrors.Count > 0)
        If ErrorFlag Then
            EditAddressShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress Update Operation tail

'Record Form EditAddress Delete Operation @10-2B2AB8E2
    Protected Sub EditAddress_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        EditAddressIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As EditAddressItem = New EditAddressItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form EditAddress Delete Operation

'Button Button_Delete OnClick. @13-8C4D6DF0
        If CType(sender,Control).ID = "EditAddressButton_Delete" Then
            RedirectUrl = GetEditAddressRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @13-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @10-55D3FC74
        EditAddressParameters()
        EditAddressLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @10-24D6F32F
        If ErrorFlag Then
            EditAddressShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form EditAddress Cancel Operation @10-B525A3F6

    Protected Sub EditAddress_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddressItem = New EditAddressItem()
        EditAddressIsSubmitted = True
        Dim RedirectUrl As String = ""
        EditAddressLoadItemFromRequest(item, False)
'End Record Form EditAddress Cancel Operation

'Button Button_Cancel OnClick. @14-DB7D7DE2
    If CType(sender,Control).ID = "EditAddressButton_Cancel" Then
        RedirectUrl = GetEditAddressRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @14-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form EditAddress Cancel Operation tail @10-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form EditAddress Cancel Operation tail

'Record Form EditAddress1 Parameters @195-528CE8AB

    Protected Sub EditAddress1Parameters()
        Dim item As new EditAddress1Item
        Try
            EditAddress1Data.Expr215 = FloatParameter.GetParam(pagecurrent_address_id, ParameterSourceType.Expression, "", Nothing, false)
            EditAddress1Data.Ctrlcbox_same_as_postal = IntegerParameter.GetParam(item.cbox_same_as_postal.Value, ParameterSourceType.Control, "", 0, false)
            EditAddress1Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            EditAddress1Data.Ctrlhidden_ADDRESS_ID = IntegerParameter.GetParam(item.hidden_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.Ctrlhidden_postal_ADDRESS_ID = IntegerParameter.GetParam(item.hidden_postal_ADDRESS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.Ctrlhidden_flag_same_as = IntegerParameter.GetParam(item.hidden_flag_same_as.Value, ParameterSourceType.Control, "", 0, false)
            EditAddress1Data.CtrlADDRESSEE = TextParameter.GetParam(item.ADDRESSEE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlAGENT = TextParameter.GetParam(item.AGENT.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlADDR1 = TextParameter.GetParam(item.ADDR1.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlADDR2 = TextParameter.GetParam(item.ADDR2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlSUBURB_TOWN = TextParameter.GetParam(item.SUBURB_TOWN.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlPOSTCODE = TextParameter.GetParam(item.POSTCODE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlSTATE = TextParameter.GetParam(item.STATE.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlCOUNTRY = TextParameter.GetParam(item.COUNTRY.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlPHONE_A = TextParameter.GetParam(item.PHONE_A.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlPHONE_B = TextParameter.GetParam(item.PHONE_B.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlFAX = TextParameter.GetParam(item.FAX.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlEMAIL_ADDRESS = TextParameter.GetParam(item.EMAIL_ADDRESS.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.CtrlEMAIL_ADDRESS2 = TextParameter.GetParam(item.EMAIL_ADDRESS2.Value, ParameterSourceType.Control, "", Nothing, false)
            EditAddress1Data.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", "unknown", false)
        Catch e As Exception
            EditAddress1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form EditAddress1 Parameters

'Record Form EditAddress1 Show method @195-E906F640
    Protected Sub EditAddress1Show()
        If EditAddress1Operations.None Then
            EditAddress1Holder.Visible = False
            Return
        End If
        Dim item As EditAddress1Item = EditAddress1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not EditAddress1Operations.AllowRead
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        item.Link_carer2Href = "StudentDetails_maintain.aspx"
        EditAddress1Errors.Add(item.errors)
        If EditAddress1Errors.Count > 0 Then
            EditAddress1ShowErrors()
            Return
        End If
'End Record Form EditAddress1 Show method

'Record Form EditAddress1 BeforeShow tail @195-E390140F
        EditAddress1Parameters()
        EditAddress1Data.FillItem(item, IsInsertMode)
        EditAddress1Holder.DataBind()
        EditAddress1Button_Insert.Visible=IsInsertMode AndAlso EditAddress1Operations.AllowInsert
        EditAddress1Button_Update.Visible=Not (IsInsertMode) AndAlso EditAddress1Operations.AllowUpdate
        EditAddress1Button_Delete.Visible=Not (IsInsertMode) AndAlso EditAddress1Operations.AllowDelete
        EditAddress1ADDRESSEE.Text=item.ADDRESSEE.GetFormattedValue()
        EditAddress1AGENT.Text=item.AGENT.GetFormattedValue()
        EditAddress1ADDR1.Text=item.ADDR1.GetFormattedValue()
        EditAddress1ADDR2.Text=item.ADDR2.GetFormattedValue()
        EditAddress1SUBURB_TOWN.Text=item.SUBURB_TOWN.GetFormattedValue()
        EditAddress1POSTCODE.Text=item.POSTCODE.GetFormattedValue()
        EditAddress1PHONE_A.Text=item.PHONE_A.GetFormattedValue()
        EditAddress1FAX.Text=item.FAX.GetFormattedValue()
        EditAddress1EMAIL_ADDRESS.Value = item.EMAIL_ADDRESS.GetFormattedValue()
        EditAddress1EMAIL_ADDRESS2.Text=item.EMAIL_ADDRESS2.GetFormattedValue()
        EditAddress1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddress1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditAddress1STATE.Text=item.STATE.GetFormattedValue()
        EditAddress1COUNTRY.Text=item.COUNTRY.GetFormattedValue()
        EditAddress1PHONE_B.Text=item.PHONE_B.GetFormattedValue()
        EditAddress1lblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        If item.cbox_same_as_postalCheckedValue.Value.Equals(item.cbox_same_as_postal.Value) Then
            EditAddress1cbox_same_as_postal.Checked = True
        End If
        EditAddress1hidden_postal_ADDRESS_ID.Value = item.hidden_postal_ADDRESS_ID.GetFormattedValue()
        EditAddress1hidden_ADDRESS_ID.Value = item.hidden_ADDRESS_ID.GetFormattedValue()
        EditAddress1hidden_flag_same_as.Value = item.hidden_flag_same_as.GetFormattedValue()
        EditAddress1Link_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        EditAddress1Link_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
        EditAddress1Link_carer2.InnerText += item.Link_carer2.GetFormattedValue().Replace(vbCrLf,"")
        EditAddress1Link_carer2.HRef = item.Link_carer2Href+item.Link_carer2HrefParameters.ToString("GET","", ViewState)
'End Record Form EditAddress1 BeforeShow tail

'Record EditAddress1 Event BeforeShow. Action Retrieve Value for Control @344-C02E5185
            EditAddress1hidden_ADDRESS_ID.Value = (New TextField("", pagecurrent_address_id)).GetFormattedValue()
'End Record EditAddress1 Event BeforeShow. Action Retrieve Value for Control

'Record EditAddress1 Event BeforeShow. Action Custom Code @331-73254650
    ' -------------------------
	'ERA: set the 'same as postal checbox on display
     'Dim attending_school_address_id As Int64 = 0
	' use pagepostal_address_id for checking rather than a lookup
		if not (tmpstudent_id=0) then
			'Feb-2009|EA| set the checkboxes for Same As School and Same as Postal from the values above
			if (pagepostal_address_id = pagecurrent_address_id) then
				item.cbox_same_as_postal.setvalue(item.cbox_same_as_postalCheckedValue.Value)
				EditAddress1cbox_same_as_postal.Checked = True
				EditAddress1hidden_flag_same_as.value="1"	' hidden
				'EditAddress1hidden_flag_same_as.Text="1"	'debug textbox
			else
				item.cbox_same_as_postal.setvalue(item.cbox_same_as_postalUncheckedValue.value)
				EditAddress1cbox_same_as_postal.Checked = false
				EditAddress1hidden_flag_same_as.value="0"
				'EditAddress1hidden_flag_same_as.Text="0"
			end if
			'EditAddress1hidden_ADDRESS_ID.Text = item.ADDRESS_ID.GetFormattedValue()
			EditAddress1hidden_postal_ADDRESS_ID.value = pagepostal_address_id.tostring()
		end if
    ' -------------------------
'End Record EditAddress1 Event BeforeShow. Action Custom Code

'Record Form EditAddress1 Show method tail @195-193BBD32
        If EditAddress1Errors.Count > 0 Then
            EditAddress1ShowErrors()
        End If
    End Sub
'End Record Form EditAddress1 Show method tail

'Record Form EditAddress1 LoadItemFromRequest method @195-53BAEEBE

    Protected Sub EditAddress1LoadItemFromRequest(item As EditAddress1Item, ByVal EnableValidation As Boolean)
        item.ADDRESSEE.IsEmpty = IsNothing(Request.Form(EditAddress1ADDRESSEE.UniqueID))
        If ControlCustomValues("EditAddress1ADDRESSEE") Is Nothing Then
            item.ADDRESSEE.SetValue(EditAddress1ADDRESSEE.Text)
        Else
            item.ADDRESSEE.SetValue(ControlCustomValues("EditAddress1ADDRESSEE"))
        End If
        item.AGENT.IsEmpty = IsNothing(Request.Form(EditAddress1AGENT.UniqueID))
        If ControlCustomValues("EditAddress1AGENT") Is Nothing Then
            item.AGENT.SetValue(EditAddress1AGENT.Text)
        Else
            item.AGENT.SetValue(ControlCustomValues("EditAddress1AGENT"))
        End If
        item.ADDR1.IsEmpty = IsNothing(Request.Form(EditAddress1ADDR1.UniqueID))
        If ControlCustomValues("EditAddress1ADDR1") Is Nothing Then
            item.ADDR1.SetValue(EditAddress1ADDR1.Text)
        Else
            item.ADDR1.SetValue(ControlCustomValues("EditAddress1ADDR1"))
        End If
        item.ADDR2.IsEmpty = IsNothing(Request.Form(EditAddress1ADDR2.UniqueID))
        If ControlCustomValues("EditAddress1ADDR2") Is Nothing Then
            item.ADDR2.SetValue(EditAddress1ADDR2.Text)
        Else
            item.ADDR2.SetValue(ControlCustomValues("EditAddress1ADDR2"))
        End If
        item.SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(EditAddress1SUBURB_TOWN.UniqueID))
        If ControlCustomValues("EditAddress1SUBURB_TOWN") Is Nothing Then
            item.SUBURB_TOWN.SetValue(EditAddress1SUBURB_TOWN.Text)
        Else
            item.SUBURB_TOWN.SetValue(ControlCustomValues("EditAddress1SUBURB_TOWN"))
        End If
        item.POSTCODE.IsEmpty = IsNothing(Request.Form(EditAddress1POSTCODE.UniqueID))
        If ControlCustomValues("EditAddress1POSTCODE") Is Nothing Then
            item.POSTCODE.SetValue(EditAddress1POSTCODE.Text)
        Else
            item.POSTCODE.SetValue(ControlCustomValues("EditAddress1POSTCODE"))
        End If
        item.PHONE_A.IsEmpty = IsNothing(Request.Form(EditAddress1PHONE_A.UniqueID))
        If ControlCustomValues("EditAddress1PHONE_A") Is Nothing Then
            item.PHONE_A.SetValue(EditAddress1PHONE_A.Text)
        Else
            item.PHONE_A.SetValue(ControlCustomValues("EditAddress1PHONE_A"))
        End If
        item.FAX.IsEmpty = IsNothing(Request.Form(EditAddress1FAX.UniqueID))
        If ControlCustomValues("EditAddress1FAX") Is Nothing Then
            item.FAX.SetValue(EditAddress1FAX.Text)
        Else
            item.FAX.SetValue(ControlCustomValues("EditAddress1FAX"))
        End If
        item.EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(EditAddress1EMAIL_ADDRESS.UniqueID))
        item.EMAIL_ADDRESS.SetValue(EditAddress1EMAIL_ADDRESS.Value)
        item.EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(EditAddress1EMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("EditAddress1EMAIL_ADDRESS2") Is Nothing Then
            item.EMAIL_ADDRESS2.SetValue(EditAddress1EMAIL_ADDRESS2.Text)
        Else
            item.EMAIL_ADDRESS2.SetValue(ControlCustomValues("EditAddress1EMAIL_ADDRESS2"))
        End If
        item.STATE.IsEmpty = IsNothing(Request.Form(EditAddress1STATE.UniqueID))
        If ControlCustomValues("EditAddress1STATE") Is Nothing Then
            item.STATE.SetValue(EditAddress1STATE.Text)
        Else
            item.STATE.SetValue(ControlCustomValues("EditAddress1STATE"))
        End If
        item.COUNTRY.IsEmpty = IsNothing(Request.Form(EditAddress1COUNTRY.UniqueID))
        If ControlCustomValues("EditAddress1COUNTRY") Is Nothing Then
            item.COUNTRY.SetValue(EditAddress1COUNTRY.Text)
        Else
            item.COUNTRY.SetValue(ControlCustomValues("EditAddress1COUNTRY"))
        End If
        item.PHONE_B.IsEmpty = IsNothing(Request.Form(EditAddress1PHONE_B.UniqueID))
        If ControlCustomValues("EditAddress1PHONE_B") Is Nothing Then
            item.PHONE_B.SetValue(EditAddress1PHONE_B.Text)
        Else
            item.PHONE_B.SetValue(ControlCustomValues("EditAddress1PHONE_B"))
        End If
        If EditAddress1cbox_same_as_postal.Checked Then
            item.cbox_same_as_postal.Value = (item.cbox_same_as_postalCheckedValue.Value)
        Else
            item.cbox_same_as_postal.Value = (item.cbox_same_as_postalUncheckedValue.Value)
        End If
        item.hidden_postal_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddress1hidden_postal_ADDRESS_ID.UniqueID))
        item.hidden_postal_ADDRESS_ID.SetValue(EditAddress1hidden_postal_ADDRESS_ID.Value)
        item.hidden_ADDRESS_ID.IsEmpty = IsNothing(Request.Form(EditAddress1hidden_ADDRESS_ID.UniqueID))
        item.hidden_ADDRESS_ID.SetValue(EditAddress1hidden_ADDRESS_ID.Value)
        Try
        item.hidden_flag_same_as.IsEmpty = IsNothing(Request.Form(EditAddress1hidden_flag_same_as.UniqueID))
        item.hidden_flag_same_as.SetValue(EditAddress1hidden_flag_same_as.Value)
        Catch ae As ArgumentException
            EditAddress1Errors.Add("hidden_flag_same_as",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_flag_same_as"))
        End Try
        If EnableValidation Then
            item.Validate(EditAddress1Data)
        End If
        EditAddress1Errors.Add(item.errors)
    End Sub
'End Record Form EditAddress1 LoadItemFromRequest method

'Record Form EditAddress1 GetRedirectUrl method @195-FFF7BAB7

    Protected Function GetEditAddress1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form EditAddress1 GetRedirectUrl method

'Record Form EditAddress1 ShowErrors method @195-B04AFC11

    Protected Sub EditAddress1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To EditAddress1Errors.Count - 1
        Select Case EditAddress1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & EditAddress1Errors(i)
        End Select
        Next i
        EditAddress1Error.Visible = True
        EditAddress1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form EditAddress1 ShowErrors method

'Record Form EditAddress1 Insert Operation @195-8C5EE0EB

    Protected Sub EditAddress1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress1Item = New EditAddress1Item()
        Dim ExecuteFlag As Boolean = True
        EditAddress1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress1 Insert Operation

'Button Button_Insert OnClick. @196-C4DEEB08
        If CType(sender,Control).ID = "EditAddress1Button_Insert" Then
            RedirectUrl = GetEditAddress1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @196-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form EditAddress1 BeforeInsert tail @195-128F63CB
    EditAddress1Parameters()
    EditAddress1LoadItemFromRequest(item, EnableValidation)
    If EditAddress1Operations.AllowInsert Then
        ErrorFlag=(EditAddress1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddress1Data.InsertItem(item)
            Catch ex As Exception
                EditAddress1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress1 BeforeInsert tail

'Record Form EditAddress1 AfterInsert tail  @195-EC9A91A5
        End If
        ErrorFlag=(EditAddress1Errors.Count > 0)
        If ErrorFlag Then
            EditAddress1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress1 AfterInsert tail 

'Record Form EditAddress1 Update Operation @195-BC4CF38A

    Protected Sub EditAddress1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress1Item = New EditAddress1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditAddress1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditAddress1 Update Operation

'Button Button_Update OnClick. @197-B201AA1B
        If CType(sender,Control).ID = "EditAddress1Button_Update" Then
            RedirectUrl = GetEditAddress1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @197-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'DEL      ' -------------------------
'DEL      ' ERA: convert the 'on' or 'off' default settings of checkbox to 1/0
'DEL  	if (EditAddress1cbox_same_as_postal.Checked = true) then
'DEL  		item.cbox_same_as_postal.Value = 1
'DEL  	else
'DEL  		item.cbox_same_as_postal.Value = 0
'DEL  	end if
'DEL      ' -------------------------


'Record Form EditAddress1 Before Update tail @195-9AF12528
        EditAddress1Parameters()
        EditAddress1LoadItemFromRequest(item, EnableValidation)
        If EditAddress1Operations.AllowUpdate Then
        ErrorFlag = (EditAddress1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditAddress1Data.UpdateItem(item)
            Catch ex As Exception
                EditAddress1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditAddress1 Before Update tail

'DEL      ' -------------------------
'DEL       ' ERA: after save, get the address id and update the student record
'DEL  		if (tmpstudent_id <> 0) and (not ErrorFlag) then
'DEL  			dim thisaddressid as int64
'DEL  			if (item.cbox_same_as_postal.Value = (item.cbox_same_as_postalCheckedValue.Value)) then
'DEL  				thisaddressid = item.hidden_postal_address_id.getformattedvalue()
'DEL  				' and if the Original Address is already blank then copy the original Curr Resid to the Original Resid
'DEL  				if (pageoriginal_address_id=0) then
'DEL  					ErrorFlag = not updateSTUDENTAddressID(3, pagecurrent_address_id, tmpstudent_id)	' 1=Postal;2=CurrResid;3=OrigResid
'DEL  				end if
'DEL  			else
'DEL  				thisaddressid = item.hidden_address_id.getformattedvalue()
'DEL  			end if
'DEL  			ErrorFlag = not updateSTUDENTAddressID(2,thisaddressid, tmpstudent_id)	' 1=Postal;2=CurrResid;3=OrigResid
'DEL  		end if
'DEL      ' -------------------------


'Record Form EditAddress1 Update Operation tail @195-EC9A91A5
        End If
        ErrorFlag=(EditAddress1Errors.Count > 0)
        If ErrorFlag Then
            EditAddress1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditAddress1 Update Operation tail

'Record Form EditAddress1 Delete Operation @195-FA51C3E5
    Protected Sub EditAddress1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        EditAddress1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As EditAddress1Item = New EditAddress1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form EditAddress1 Delete Operation

'Button Button_Delete OnClick. @198-23718B80
        If CType(sender,Control).ID = "EditAddress1Button_Delete" Then
            RedirectUrl = GetEditAddress1RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @198-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @195-091B1FBD
        EditAddress1Parameters()
        EditAddress1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @195-ED7CA3AF
        If ErrorFlag Then
            EditAddress1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form EditAddress1 Cancel Operation @195-3EF9412E

    Protected Sub EditAddress1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditAddress1Item = New EditAddress1Item()
        EditAddress1IsSubmitted = True
        Dim RedirectUrl As String = ""
        EditAddress1LoadItemFromRequest(item, False)
'End Record Form EditAddress1 Cancel Operation

'Button Button_Cancel OnClick. @199-B770F10E
    If CType(sender,Control).ID = "EditAddress1Button_Cancel" Then
        RedirectUrl = GetEditAddress1RedirectUrl("", "editmode")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @199-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form EditAddress1 Cancel Operation tail @195-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form EditAddress1 Cancel Operation tail

'Record Form ADDRESS1 Parameters @174-5662986D

    Protected Sub ADDRESS1Parameters()
        Dim item As new ADDRESS1Item
        Try
            ADDRESS1Data.Expr192 = FloatParameter.GetParam(pagecurrent_address_id, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            ADDRESS1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ADDRESS1 Parameters

'Record Form ADDRESS1 Show method @174-6C351608
    Protected Sub ADDRESS1Show()
        If ADDRESS1Operations.None Then
            ADDRESS1Holder.Visible = False
            Return
        End If
        Dim item As ADDRESS1Item = ADDRESS1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ADDRESS1Operations.AllowRead
        item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
        item.Link_EditCurrentHref = "Student_Address_panels_maintain.aspx"
        item.Link_EditCurrentHrefParameters.Add("editmode",System.Web.HttpUtility.UrlEncode(("current").ToString()))
        item.Link_carer1Href = "Student_Carer_maintainext.aspx"
        item.Link_carer2Href = "StudentDetails_maintain.aspx"
        ADDRESS1Errors.Add(item.errors)
        If ADDRESS1Errors.Count > 0 Then
            ADDRESS1ShowErrors()
            Return
        End If
'End Record Form ADDRESS1 Show method

'Record Form ADDRESS1 BeforeShow tail @174-76D6BAB6
        ADDRESS1Parameters()
        ADDRESS1Data.FillItem(item, IsInsertMode)
        ADDRESS1Holder.DataBind()
        ADDRESS1ADDRESSEE.Text = Server.HtmlEncode(item.ADDRESSEE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1AGENT.Text = Server.HtmlEncode(item.AGENT.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1ADDR1.Text = Server.HtmlEncode(item.ADDR1.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1ADDR2.Text = Server.HtmlEncode(item.ADDR2.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1SUBURB_TOWN.Text = Server.HtmlEncode(item.SUBURB_TOWN.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1PHONE_A.Text = Server.HtmlEncode(item.PHONE_A.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1FAX.Text = Server.HtmlEncode(item.FAX.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1EMAIL_ADDRESS.InnerText += item.EMAIL_ADDRESS.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS1EMAIL_ADDRESS.HRef = "mailto:" + item.EMAIL_ADDRESSHref+item.EMAIL_ADDRESSHrefParameters.ToString("GET","", ViewState)
        ADDRESS1EMAIL_ADDRESS2.InnerText += item.EMAIL_ADDRESS2.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS1EMAIL_ADDRESS2.HRef = "mailto:" + item.EMAIL_ADDRESS2Href+item.EMAIL_ADDRESS2HrefParameters.ToString("GET","", ViewState)
        ADDRESS1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1STATE.Text = Server.HtmlEncode(item.STATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1POSTCODE.Text = Server.HtmlEncode(item.POSTCODE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1COUNTRY.Text = Server.HtmlEncode(item.COUNTRY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1PHONE_B.Text = Server.HtmlEncode(item.PHONE_B.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1Link_EditCurrent.InnerText += item.Link_EditCurrent.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS1Link_EditCurrent.HRef = item.Link_EditCurrentHref+item.Link_EditCurrentHrefParameters.ToString("GET","", ViewState)
        ADDRESS1lblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ADDRESS1Link_carer1.InnerText += item.Link_carer1.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS1Link_carer1.HRef = item.Link_carer1Href+item.Link_carer1HrefParameters.ToString("GET","", ViewState)
        ADDRESS1Link_carer2.InnerText += item.Link_carer2.GetFormattedValue().Replace(vbCrLf,"")
        ADDRESS1Link_carer2.HRef = item.Link_carer2Href+item.Link_carer2HrefParameters.ToString("GET","", ViewState)
'End Record Form ADDRESS1 BeforeShow tail

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @326-73254650
    ' -------------------------
     ' ERA: trim and format for nice links
	item.EMAIL_ADDRESSHrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
    item.EMAIL_ADDRESS2HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("<insert subject>").ToString()))
	if not IsDBNull(item.email_addresshref) then
		ADDRESS1EMAIL_ADDRESS.HRef = "mailto:" + trim(item.EMAIL_ADDRESSHref) & item.EMAIL_ADDRESSHrefParameters.tostring("None","", ViewState)
	end if
	if not IsDBNull(item.email_address2href) then
		ADDRESS1EMAIL_ADDRESS2.HRef = "mailto:" + trim(item.EMAIL_ADDRESS2Href) & item.EMAIL_ADDRESS2HrefParameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'Record Form ADDRESS1 Show method tail @174-27051D68
        If ADDRESS1Errors.Count > 0 Then
            ADDRESS1ShowErrors()
        End If
    End Sub
'End Record Form ADDRESS1 Show method tail

'Record Form ADDRESS1 LoadItemFromRequest method @174-E28EA22F

    Protected Sub ADDRESS1LoadItemFromRequest(item As ADDRESS1Item, ByVal EnableValidation As Boolean)
        If EnableValidation Then
            item.Validate(ADDRESS1Data)
        End If
        ADDRESS1Errors.Add(item.errors)
    End Sub
'End Record Form ADDRESS1 LoadItemFromRequest method

'Record Form ADDRESS1 GetRedirectUrl method @174-56640A04

    Protected Function GetADDRESS1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Address_panels_maintain.aspx"
        Dim p As String = parameters.ToString("GET","editmode;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ADDRESS1 GetRedirectUrl method

'Record Form ADDRESS1 ShowErrors method @174-75DDD03C

    Protected Sub ADDRESS1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ADDRESS1Errors.Count - 1
        Select Case ADDRESS1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ADDRESS1Errors(i)
        End Select
        Next i
        ADDRESS1Error.Visible = True
        ADDRESS1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ADDRESS1 ShowErrors method

'Record Form ADDRESS1 Insert Operation @174-B0F5491A

    Protected Sub ADDRESS1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS1Item = New ADDRESS1Item()
        ADDRESS1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS1 Insert Operation

'Record Form ADDRESS1 BeforeInsert tail @174-E94AE739
    ADDRESS1Parameters()
    ADDRESS1LoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS1 BeforeInsert tail

'Record Form ADDRESS1 AfterInsert tail  @174-1D9368DD
        ErrorFlag=(ADDRESS1Errors.Count > 0)
        If ErrorFlag Then
            ADDRESS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS1 AfterInsert tail 

'Record Form ADDRESS1 Update Operation @174-D8D8572D

    Protected Sub ADDRESS1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS1Item = New ADDRESS1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ADDRESS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ADDRESS1 Update Operation

'Record Form ADDRESS1 Before Update tail @174-E94AE739
        ADDRESS1Parameters()
        ADDRESS1LoadItemFromRequest(item, EnableValidation)
'End Record Form ADDRESS1 Before Update tail

'Record Form ADDRESS1 Update Operation tail @174-1D9368DD
        ErrorFlag=(ADDRESS1Errors.Count > 0)
        If ErrorFlag Then
            ADDRESS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ADDRESS1 Update Operation tail

'Record Form ADDRESS1 Delete Operation @174-3D7E01BD
    Protected Sub ADDRESS1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ADDRESS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ADDRESS1Item = New ADDRESS1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ADDRESS1 Delete Operation

'Record Form BeforeDelete tail @174-E94AE739
        ADDRESS1Parameters()
        ADDRESS1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @174-5727AED8
        If ErrorFlag Then
            ADDRESS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ADDRESS1 Cancel Operation @174-E5E9AC4B

    Protected Sub ADDRESS1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ADDRESS1Item = New ADDRESS1Item()
        ADDRESS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        ADDRESS1LoadItemFromRequest(item, True)
'End Record Form ADDRESS1 Cancel Operation

'Record Form ADDRESS1 Cancel Operation tail @174-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ADDRESS1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-57D9CB8E
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Address_panels_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ADDRESS2Data = New ADDRESS2DataProvider()
        ADDRESS2Operations = New FormSupportedOperations(False, True, False, False, False)
        EditAddress2Data = New EditAddress2DataProvider()
        EditAddress2Operations = New FormSupportedOperations(False, True, True, True, True)
        ADDRESSData = New ADDRESSDataProvider()
        ADDRESSOperations = New FormSupportedOperations(False, True, False, False, False)
        EditAddressData = New EditAddressDataProvider()
        EditAddressOperations = New FormSupportedOperations(False, True, True, True, False)
        EditAddress1Data = New EditAddress1DataProvider()
        EditAddress1Operations = New FormSupportedOperations(False, True, True, True, False)
        ADDRESS1Data = New ADDRESS1DataProvider()
        ADDRESS1Operations = New FormSupportedOperations(False, True, False, False, False)
'End OnInit Event Body

'Page Student_Address_panels_maintain Event AfterInitialize. Action Custom Code @311-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Page Student_Address_panels_maintain Event AfterInitialize. Action Custom Code

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


'ERA: common functions for updating STUDENT table with postal/current/orig address details
protected function updateSTUDENTAddressID(byval addresstype as Int64, byval addressid as Int64, byval studentid as Int64) as boolean
	dim retval as boolean = false
	Dim E As Exception = Nothing
	dim addresscolumn as string =""
	'expect addressType to be the field to be updated - POSTAL_ADDRESS_ID, CURR_RESID_ADDRESS_ID, ORIG_RESID_ADDRESS_ID
	if addresstype=1 then 
		addresscolumn="POSTAL_ADDRESS_ID"
	elseif addresstype=2 then
		addresscolumn="CURR_RESID_ADDRESS_ID"
	elseif addresstype=3 then
		addresscolumn="ORIG_RESID_ADDRESS_ID"
	else
		addresscolumn=""
		addresstype=0
	end if

	If (studentid > 0) and (addresstype <>0) and (addresscolumn <> "") Then
		Try
			dim taskCmd As SqlCommand = New SqlCommand("UPDATE STUDENT set " & addresscolumn.tostring() & " = " & addressid.tostring() & " WHERE STUDENT_ID = " & studentid.tostring() & "", Settings.connDECVPRODSQL2005DataAccessObject)
			taskCmd.ExecuteScalar()
        Catch ee As Exception
			E = ee
		Finally
	        If Not IsNothing(E) Then Throw E
        End Try
	End if

	return retval
end function




'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

