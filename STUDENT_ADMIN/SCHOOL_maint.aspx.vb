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

Namespace DECV_PROD2007.SCHOOL_maint 'Namespace @1-76D3DFEE

'Forms Definition @1-B3091430
Public Class [SCHOOL_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C7A9AC2A
    Protected SCHOOLData As SCHOOLDataProvider
    Protected SCHOOLErrors As NameValueCollection = New NameValueCollection()
    Protected SCHOOLOperations As FormSupportedOperations
    Protected SCHOOLIsSubmitted As Boolean = False
    Protected ADDRESS_PostalData As ADDRESS_PostalDataProvider
    Protected ADDRESS_PostalOperations As FormSupportedOperations
    Protected SCHOOL_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-D777C8F9
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.linkSchoolListHref = "SCHOOL_list.aspx"
            PageData.FillItem(item)
            linkSchoolList.InnerText += item.linkSchoolList.GetFormattedValue().Replace(vbCrLf,"")
            linkSchoolList.HRef = item.linkSchoolListHref+item.linkSchoolListHrefParameters.ToString("GET","", ViewState)
            linkSchoolList.DataBind()
            SCHOOLShow()
            ADDRESS_PostalBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SCHOOL Parameters @2-050B17D4

    Protected Sub SCHOOLParameters()
        Dim item As new SCHOOLItem
        Try
            SCHOOLData.UrlSCHOOL_ID = FloatParameter.GetParam("SCHOOL_ID", ParameterSourceType.URL, "", Nothing, false)
            SCHOOLData.CtrlSCHOOL_ID = TextParameter.GetParam(item.SCHOOL_ID.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            SCHOOLErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SCHOOL Parameters

'Record Form SCHOOL Show method @2-CBEF436E
    Protected Sub SCHOOLShow()
        If SCHOOLOperations.None Then
            SCHOOLHolder.Visible = False
            Return
        End If
        Dim item As SCHOOLItem = SCHOOLItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SCHOOLOperations.AllowRead
        item.ADDRESS_IDHref = "SCHOOL_ADDRESS_maint.aspx"
        SCHOOLErrors.Add(item.errors)
        If SCHOOLErrors.Count > 0 Then
            SCHOOLShowErrors()
            Return
        End If
'End Record Form SCHOOL Show method

'Record Form SCHOOL BeforeShow tail @2-89FEC443
        SCHOOLParameters()
        SCHOOLData.FillItem(item, IsInsertMode)
        SCHOOLHolder.DataBind()
        SCHOOLButton_Insert.Visible=IsInsertMode AndAlso SCHOOLOperations.AllowInsert
        SCHOOLButton_Update.Visible=Not (IsInsertMode) AndAlso SCHOOLOperations.AllowUpdate
        SCHOOLButton_Delete.Visible=Not (IsInsertMode) AndAlso SCHOOLOperations.AllowDelete
        SCHOOLSCHOOL_NAME.Text=item.SCHOOL_NAME.GetFormattedValue()
        SCHOOLREGION_ID.Items.Add(new ListItem("Select Value",""))
        SCHOOLREGION_ID.Items(0).Selected = True
        item.REGION_IDItems.SetSelection(item.REGION_ID.GetFormattedValue())
        If Not item.REGION_IDItems.GetSelectedItem() Is Nothing Then
            SCHOOLREGION_ID.SelectedIndex = -1
        End If
        item.REGION_IDItems.CopyTo(SCHOOLREGION_ID.Items)
        SCHOOLSCHOOL_TYPE_CODE.Items.Add(new ListItem("Select Value",""))
        SCHOOLSCHOOL_TYPE_CODE.Items(0).Selected = True
        item.SCHOOL_TYPE_CODEItems.SetSelection(item.SCHOOL_TYPE_CODE.GetFormattedValue())
        If Not item.SCHOOL_TYPE_CODEItems.GetSelectedItem() Is Nothing Then
            SCHOOLSCHOOL_TYPE_CODE.SelectedIndex = -1
        End If
        item.SCHOOL_TYPE_CODEItems.CopyTo(SCHOOLSCHOOL_TYPE_CODE.Items)
        SCHOOLPRINCIPAL.Text=item.PRINCIPAL.GetFormattedValue()
        SCHOOLVBOSNUMBER.Text=item.VBOSNUMBER.GetFormattedValue()
        item.METRO_CATEGORYItems.SetSelection(item.METRO_CATEGORY.GetFormattedValue())
        SCHOOLMETRO_CATEGORY.SelectedIndex = -1
        item.METRO_CATEGORYItems.CopyTo(SCHOOLMETRO_CATEGORY.Items)
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            SCHOOLSTATUS.Checked = True
        End If
        SCHOOLADDRESS_ID.InnerText += item.ADDRESS_ID.GetFormattedValue().Replace(vbCrLf,"")
        SCHOOLADDRESS_ID.HRef = item.ADDRESS_IDHref+item.ADDRESS_IDHrefParameters.ToString("GET","", ViewState)
        SCHOOLSCHOOL_ID.Text=item.SCHOOL_ID.GetFormattedValue()
        SCHOOLlbl_SaveBeforeAddress.Text = item.lbl_SaveBeforeAddress.GetFormattedValue()
        SCHOOLLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        SCHOOLLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        SCHOOLlbl_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.lbl_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLlbl_LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lbl_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLSchoolID_view.Text = Server.HtmlEncode(item.SchoolID_view.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLHidden_address_id.Value = item.Hidden_address_id.GetFormattedValue()
        SCHOOLlblAddressID.Text = Server.HtmlEncode(item.lblAddressID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLlblDebug.Text = Server.HtmlEncode(item.lblDebug.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form SCHOOL BeforeShow tail

'Label lblDebug Event BeforeShow. Action Retrieve Value for Control @62-F5D99D63
            SCHOOLlblDebug.Text = (New TextField("", System.Web.HttpContext.Current.Session("debugmsg"))).GetFormattedValue()
'End Label lblDebug Event BeforeShow. Action Retrieve Value for Control

'Record SCHOOL Event BeforeShow. Action Custom Code @24-73254650
    ' -------------------------
    ' ERA: 18-Dec-2008|EA| added textbox for input and this switches between label and textbox on form status
		SCHOOLSCHOOL_ID.visible=IsInsertMode AndAlso SCHOOLOperations.AllowInsert
		SCHOOLSchoolID_view.visible=Not (IsInsertMode) AndAlso SCHOOLOperations.AllowUpdate
		' and the Address link/label should change on mode
		SCHOOLlbl_SaveBeforeAddress.visible=IsInsertMode AndAlso SCHOOLOperations.AllowInsert
		SCHOOLADDRESS_ID.visible=Not (IsInsertMode) AndAlso SCHOOLOperations.AllowUpdate
    ' -------------------------
'End Record SCHOOL Event BeforeShow. Action Custom Code

'Record Form SCHOOL Show method tail @2-98B9B4AD
        If SCHOOLErrors.Count > 0 Then
            SCHOOLShowErrors()
        End If
    End Sub
'End Record Form SCHOOL Show method tail

'Record Form SCHOOL LoadItemFromRequest method @2-033A8B6A

    Protected Sub SCHOOLLoadItemFromRequest(item As SCHOOLItem, ByVal EnableValidation As Boolean)
        item.SCHOOL_NAME.IsEmpty = IsNothing(Request.Form(SCHOOLSCHOOL_NAME.UniqueID))
        If ControlCustomValues("SCHOOLSCHOOL_NAME") Is Nothing Then
            item.SCHOOL_NAME.SetValue(SCHOOLSCHOOL_NAME.Text)
        Else
            item.SCHOOL_NAME.SetValue(ControlCustomValues("SCHOOLSCHOOL_NAME"))
        End If
        Try
        item.REGION_ID.IsEmpty = IsNothing(Request.Form(SCHOOLREGION_ID.UniqueID))
        item.REGION_ID.SetValue(SCHOOLREGION_ID.Value)
        item.REGION_IDItems.CopyFrom(SCHOOLREGION_ID.Items)
        Catch ae As ArgumentException
            SCHOOLErrors.Add("REGION_ID",String.Format(Resources.strings.CCS_IncorrectValue,"REGION ID"))
        End Try
        item.SCHOOL_TYPE_CODE.IsEmpty = IsNothing(Request.Form(SCHOOLSCHOOL_TYPE_CODE.UniqueID))
        item.SCHOOL_TYPE_CODE.SetValue(SCHOOLSCHOOL_TYPE_CODE.Value)
        item.SCHOOL_TYPE_CODEItems.CopyFrom(SCHOOLSCHOOL_TYPE_CODE.Items)
        item.PRINCIPAL.IsEmpty = IsNothing(Request.Form(SCHOOLPRINCIPAL.UniqueID))
        If ControlCustomValues("SCHOOLPRINCIPAL") Is Nothing Then
            item.PRINCIPAL.SetValue(SCHOOLPRINCIPAL.Text)
        Else
            item.PRINCIPAL.SetValue(ControlCustomValues("SCHOOLPRINCIPAL"))
        End If
        Try
        item.VBOSNUMBER.IsEmpty = IsNothing(Request.Form(SCHOOLVBOSNUMBER.UniqueID))
        If ControlCustomValues("SCHOOLVBOSNUMBER") Is Nothing Then
            item.VBOSNUMBER.SetValue(SCHOOLVBOSNUMBER.Text)
        Else
            item.VBOSNUMBER.SetValue(ControlCustomValues("SCHOOLVBOSNUMBER"))
        End If
        Catch ae As ArgumentException
            SCHOOLErrors.Add("VBOSNUMBER",String.Format(Resources.strings.CCS_IncorrectValue,"VBOS NUMBER"))
        End Try
        Try
        item.METRO_CATEGORY.IsEmpty = IsNothing(Request.Form(SCHOOLMETRO_CATEGORY.UniqueID))
        If Not IsNothing(SCHOOLMETRO_CATEGORY.SelectedItem) Then
            item.METRO_CATEGORY.SetValue(SCHOOLMETRO_CATEGORY.SelectedItem.Value)
        Else
            item.METRO_CATEGORY.Value = Nothing
        End If
        item.METRO_CATEGORYItems.CopyFrom(SCHOOLMETRO_CATEGORY.Items)
        Catch ae As ArgumentException
            SCHOOLErrors.Add("METRO_CATEGORY",String.Format(Resources.strings.CCS_IncorrectValue,"METRO CATEGORY"))
        End Try
        If SCHOOLSTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        item.SCHOOL_ID.IsEmpty = IsNothing(Request.Form(SCHOOLSCHOOL_ID.UniqueID))
        If ControlCustomValues("SCHOOLSCHOOL_ID") Is Nothing Then
            item.SCHOOL_ID.SetValue(SCHOOLSCHOOL_ID.Text)
        Else
            item.SCHOOL_ID.SetValue(ControlCustomValues("SCHOOLSCHOOL_ID"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(SCHOOLLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(SCHOOLLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(SCHOOLLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(SCHOOLLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            SCHOOLErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.Hidden_address_id.IsEmpty = IsNothing(Request.Form(SCHOOLHidden_address_id.UniqueID))
        item.Hidden_address_id.SetValue(SCHOOLHidden_address_id.Value)
        If EnableValidation Then
            item.Validate(SCHOOLData)
        End If
        SCHOOLErrors.Add(item.errors)
    End Sub
'End Record Form SCHOOL LoadItemFromRequest method

'Record Form SCHOOL GetRedirectUrl method @2-6C2DA557

    Protected Function GetSCHOOLRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SCHOOL GetRedirectUrl method

'Record Form SCHOOL ShowErrors method @2-9891BC58

    Protected Sub SCHOOLShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SCHOOLErrors.Count - 1
        Select Case SCHOOLErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SCHOOLErrors(i)
        End Select
        Next i
        SCHOOLError.Visible = True
        SCHOOLErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SCHOOL ShowErrors method

'Record Form SCHOOL Insert Operation @2-AE2C61BD

    Protected Sub SCHOOL_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLItem = New SCHOOLItem()
        Dim ExecuteFlag As Boolean = True
        SCHOOLIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOL Insert Operation

'Button Button_Insert OnClick. @3-515C9EAE
        If CType(sender,Control).ID = "SCHOOLButton_Insert" Then
            RedirectUrl = GetSCHOOLRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form SCHOOL BeforeInsert tail @2-7BDCDF11
    SCHOOLParameters()
    SCHOOLLoadItemFromRequest(item, EnableValidation)
    If SCHOOLOperations.AllowInsert Then
        ErrorFlag=(SCHOOLErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOLData.InsertItem(item)
            Catch ex As Exception
                SCHOOLErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOL BeforeInsert tail

'Record SCHOOL Event AfterInsert. Action Save Variable Value @63-DF7398AF
        HttpContext.Current.Session("notifymessage") = "School has been Added"
'End Record SCHOOL Event AfterInsert. Action Save Variable Value

'Record SCHOOL Event AfterInsert. Action Custom Code @68-73254650
    ' -------------------------
    'Oct-2018|EA| get schoolID entered and show record has been added

    If IsNothing(Request.QueryString("SCHOOL_ID")) Or Request.QueryString("SCHOOL_ID") = "" Then  
    	Dim params As New LinkParameterCollection()
    	params.Add("SCHOOL_ID",SCHOOLSCHOOL_ID.Text)
    	RedirectUrl = (Request.Url.AbsolutePath + params.ToString("GET","SCHOOL_ID"))
	End If

    ' -------------------------
'End Record SCHOOL Event AfterInsert. Action Custom Code

'Record Form SCHOOL AfterInsert tail  @2-330A14D5
        End If
        ErrorFlag=(SCHOOLErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOL AfterInsert tail 

'Record Form SCHOOL Update Operation @2-7AE05337

    Protected Sub SCHOOL_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLItem = New SCHOOLItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SCHOOLIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOL Update Operation

'Button Button_Update OnClick. @4-BB66C65B
        If CType(sender,Control).ID = "SCHOOLButton_Update" Then
            RedirectUrl = GetSCHOOLRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record SCHOOL Event BeforeUpdate. Action Retrieve Value for Control @57-064FC39D
        SCHOOLLAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record SCHOOL Event BeforeUpdate. Action Retrieve Value for Control

'Record SCHOOL Event BeforeUpdate. Action Retrieve Value for Control @58-C157B336
        SCHOOLLAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record SCHOOL Event BeforeUpdate. Action Retrieve Value for Control

'Record Form SCHOOL Before Update tail @2-CC8F62CE
        SCHOOLParameters()
        SCHOOLLoadItemFromRequest(item, EnableValidation)
        If SCHOOLOperations.AllowUpdate Then
        ErrorFlag = (SCHOOLErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOLData.UpdateItem(item)
            Catch ex As Exception
                SCHOOLErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOL Before Update tail

'Record SCHOOL Event AfterUpdate. Action Save Variable Value @64-F94F748D
        HttpContext.Current.Session("notifymessage") = "School has been Updated"
'End Record SCHOOL Event AfterUpdate. Action Save Variable Value

'Record Form SCHOOL Update Operation tail @2-330A14D5
        End If
        ErrorFlag=(SCHOOLErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOL Update Operation tail

'Record Form SCHOOL Delete Operation @2-5C7C6FF9
    Protected Sub SCHOOL_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SCHOOLIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SCHOOLItem = New SCHOOLItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SCHOOL Delete Operation

'Button Button_Delete OnClick. @5-84B58528
        If CType(sender,Control).ID = "SCHOOLButton_Delete" Then
            RedirectUrl = GetSCHOOLRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-F27E3762
        SCHOOLParameters()
        SCHOOLLoadItemFromRequest(item, EnableValidation)
        If SCHOOLOperations.AllowDelete Then
        ErrorFlag = (SCHOOLErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOLData.DeleteItem(item)
            Catch ex As Exception
                SCHOOLErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-BE8A88D2
        End If
        If ErrorFlag Then
            SCHOOLShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SCHOOL Cancel Operation @2-D69F9987

    Protected Sub SCHOOL_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLItem = New SCHOOLItem()
        SCHOOLIsSubmitted = True
        Dim RedirectUrl As String = ""
        SCHOOLLoadItemFromRequest(item, True)
'End Record Form SCHOOL Cancel Operation

'Record Form SCHOOL Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SCHOOL Cancel Operation tail

'Report ADDRESS_Postal Bind @29-B26FE14A
    Protected Sub ADDRESS_PostalBind()
        If Not ADDRESS_PostalOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"ADDRESS_Postal",GetType(ADDRESS_PostalDataProvider.SortFields), 0, 100)
        End If
'End Report ADDRESS_Postal Bind

'Report Form ADDRESS_Postal BeforeShow tail @29-769F34A4
        ADDRESS_PostalParameters
        ADDRESS_PostalData.SortField = CType(ViewState("ADDRESS_PostalSortField"),ADDRESS_PostalDataProvider.SortFields)
        ADDRESS_PostalData.SortDir = CType(ViewState("ADDRESS_PostalSortDir"),SortDirections)
        ADDRESS_Postal.DataSource = ADDRESS_PostalData.GetResultSet(ADDRESS_PostalOperations)
        ADDRESS_Postal.DataBind()
'End Report Form ADDRESS_Postal BeforeShow tail

	End Sub 'Report ADDRESS_Postal Bind tail @29-E31F8E2A

'Report ADDRESS_Postal Table Parameters @29-A158130D

    Protected Sub ADDRESS_PostalParameters()
        Try
            ADDRESS_PostalData.Expr54 = FloatParameter.GetParam(SCHOOLHidden_address_id.value, ParameterSourceType.Expression, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=ADDRESS_Postal.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ADDRESS_Postal)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ADDRESS_Postal: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report ADDRESS_Postal Table Parameters

'Report ADDRESS_Postal BeforeShowSection event @29-66ABC929
    Protected Sub ADDRESS_PostalBeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As ADDRESS_PostalItem  = CType(e.Item.DataItem, ADDRESS_PostalItem)
        Dim Item As ADDRESS_PostalItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New ADDRESS_PostalItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "Detail"
                Dim ADDRESS_PostalADDRESSEE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDRESSEE"),ReportLabel)
                Dim ADDRESS_PostalAGENT As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalAGENT"),ReportLabel)
                Dim ADDRESS_PostalADDR1 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDR1"),ReportLabel)
                Dim ADDRESS_PostalADDR2 As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDR2"),ReportLabel)
                Dim ADDRESS_PostalSUBURB_TOWN As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalSUBURB_TOWN"),ReportLabel)
                Dim ADDRESS_PostalSTATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalSTATE"),ReportLabel)
                Dim ADDRESS_PostalPOSTCODE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPOSTCODE"),ReportLabel)
                Dim ADDRESS_PostalCOUNTRY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalCOUNTRY"),ReportLabel)
                Dim ADDRESS_PostalPHONE_A As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPHONE_A"),ReportLabel)
                Dim ADDRESS_PostalPHONE_B As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalPHONE_B"),ReportLabel)
                Dim ADDRESS_PostalFAX As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalFAX"),ReportLabel)
                Dim ADDRESS_PostalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_PostalEMAIL_ADDRESS2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS2"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim ADDRESS_PostalLAST_ALTERED_BY As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalLAST_ALTERED_BY"),ReportLabel)
                Dim ADDRESS_PostalLAST_ALTERED_DATE As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalLAST_ALTERED_DATE"),ReportLabel)
                Dim ADDRESS_PostalADDRESS_ID As ReportLabel = DirectCast(e.Item.FindControl("ADDRESS_PostalADDRESS_ID"),ReportLabel)
                ADDRESS_PostalEMAIL_ADDRESS.HRef = "mailto:" + DataItem.EMAIL_ADDRESSHref & DataItem.EMAIL_ADDRESSHrefParameters.ToString("None","", ViewState)
                ADDRESS_PostalEMAIL_ADDRESS2.HRef = "mailto:" + DataItem.EMAIL_ADDRESS2Href & DataItem.EMAIL_ADDRESS2HrefParameters.ToString("None","", ViewState)
            Case "Report_Footer"
            Case "Page_Footer"
        End Select
'End Report ADDRESS_Postal BeforeShowSection event

		Select e.Item.name 'BeforeShow events @29-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @32-D5562AB6

'Get EMAIL_ADDRESS control @44-714929C8
                Dim ADDRESS_PostalEMAIL_ADDRESS As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS control

'Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code @45-73254650
    ' -------------------------
    ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	DataItem.email_addresshrefparameters.add("subject",("<insert subject>").ToString())
	if not IsDBNull(dataitem.email_addresshref) then
		ADDRESS_PostalEMAIL_ADDRESS.HRef = "mailto:" + trim(DataItem.email_addresshref) & DataItem.email_addresshrefparameters.tostring("None","", ViewState)
	end if
    ' -------------------------
'End Link EMAIL_ADDRESS Event BeforeShow. Action Custom Code

'Get EMAIL_ADDRESS2 control @46-D61CA748
                Dim ADDRESS_PostalEMAIL_ADDRESS2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ADDRESS_PostalEMAIL_ADDRESS2"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get EMAIL_ADDRESS2 control

'Link EMAIL_ADDRESS2 Event BeforeShow. Action Custom Code @47-73254650
    ' -------------------------
    ' ERA: Feb-2009|EA| trim the email address of excess spaces (damn char fields) and add parameters of subject email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
    ' 13-Feb-2020|EA| adjust DECV to VSV
	DataItem.email_address2hrefparameters.add("subject",("VSV Accounts").ToString())
	if not IsDBNull(dataitem.email_address2href) then
		ADDRESS_PostalEMAIL_ADDRESS2.HRef = "mailto:" + trim(DataItem.email_address2href) & DataItem.email_address2hrefparameters.tostring("None","", ViewState)
	end if

    ' -------------------------
'End Link EMAIL_ADDRESS2 Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @29-3508C6CC

    End Sub 'Section ADDRESS_Postal BeforeShow events tail @29-E31F8E2A

'Report ADDRESS_Postal ItemCommand event @29-39CD30DB
    Protected Sub ADDRESS_PostalItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ADDRESS_PostalSortDir"),SortDirections) = SortDirections._Asc And ViewState("ADDRESS_PostalSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ADDRESS_PostalSortDir")=SortDirections._Desc
                Else
                    ViewState("ADDRESS_PostalSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ADDRESS_PostalSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ADDRESS_PostalDataProvider.SortFields = 0
            ViewState("ADDRESS_PostalSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ADDRESS_PostalPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ADDRESS_Postal.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ADDRESS_PostalBind
        End If
    End Sub
'End Report ADDRESS_Postal ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-B40CB6DA
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SCHOOL_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOLData = New SCHOOLDataProvider()
        SCHOOLOperations = New FormSupportedOperations(False, True, True, True, True)
        ADDRESS_PostalData = new ADDRESS_PostalDataProvider()
        ADDRESS_PostalOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler ADDRESS_Postal.BeforeShowSection, AddressOf Me.ADDRESS_PostalBeforeShowSection
        If Request("ViewMode") Is Nothing Then ADDRESS_Postal.ViewMode= ReportViewMode.Web
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

