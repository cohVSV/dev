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

Namespace DECV_PROD2007.SCHOOL_ADDRESS_maint 'Namespace @1-DE74577D

'Forms Definition @1-D3D0A6AB
Public Class [SCHOOL_ADDRESS_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-B85EC493
    Protected SCHOOLADDRESSData As SCHOOLADDRESSDataProvider
    Protected SCHOOLADDRESSErrors As NameValueCollection = New NameValueCollection()
    Protected SCHOOLADDRESSOperations As FormSupportedOperations
    Protected SCHOOLADDRESSIsSubmitted As Boolean = False
    Protected SCHOOL_ADDRESS_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B4A78569
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SCHOOLADDRESSShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SCHOOLADDRESS Parameters @3-20EC62B1

    Protected Sub SCHOOLADDRESSParameters()
        Dim item As new SCHOOLADDRESSItem
        Try
            SCHOOLADDRESSData.UrlADDRESS_ID = FloatParameter.GetParam("ADDRESS_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            SCHOOLADDRESSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SCHOOLADDRESS Parameters

'Record Form SCHOOLADDRESS Show method @3-D83872DF
    Protected Sub SCHOOLADDRESSShow()
        If SCHOOLADDRESSOperations.None Then
            SCHOOLADDRESSHolder.Visible = False
            Return
        End If
        Dim item As SCHOOLADDRESSItem = SCHOOLADDRESSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SCHOOLADDRESSOperations.AllowRead
        item.linkSchoolMaintHref = "SCHOOL_maint.aspx"
        item.linkSchoolMaintHrefParameters.Add("SCHOOL_ID",Request.QueryString,"SCHOOL_ID")
        SCHOOLADDRESSErrors.Add(item.errors)
        If SCHOOLADDRESSErrors.Count > 0 Then
            SCHOOLADDRESSShowErrors()
            Return
        End If
'End Record Form SCHOOLADDRESS Show method

'Record Form SCHOOLADDRESS BeforeShow tail @3-0968674D
        SCHOOLADDRESSParameters()
        SCHOOLADDRESSData.FillItem(item, IsInsertMode)
        SCHOOLADDRESSHolder.DataBind()
        SCHOOLADDRESSButton_Insert.Visible=IsInsertMode AndAlso SCHOOLADDRESSOperations.AllowInsert
        SCHOOLADDRESSButton_Update.Visible=Not (IsInsertMode) AndAlso SCHOOLADDRESSOperations.AllowUpdate
        SCHOOLADDRESSButton_Delete.Visible=Not (IsInsertMode) AndAlso SCHOOLADDRESSOperations.AllowDelete
        SCHOOLADDRESSADDRESSEE.Text=item.ADDRESSEE.GetFormattedValue()
        SCHOOLADDRESSAGENT.Text=item.AGENT.GetFormattedValue()
        SCHOOLADDRESSADDR1.Text=item.ADDR1.GetFormattedValue()
        SCHOOLADDRESSADDR2.Text=item.ADDR2.GetFormattedValue()
        SCHOOLADDRESSSUBURB_TOWN.Text=item.SUBURB_TOWN.GetFormattedValue()
        SCHOOLADDRESSPOSTCODE.Text=item.POSTCODE.GetFormattedValue()
        SCHOOLADDRESSPHONE_A.Text=item.PHONE_A.GetFormattedValue()
        SCHOOLADDRESSFAX.Text=item.FAX.GetFormattedValue()
        SCHOOLADDRESSEMAIL_ADDRESS.Text=item.EMAIL_ADDRESS.GetFormattedValue()
        SCHOOLADDRESSEMAIL_ADDRESS2.Text=item.EMAIL_ADDRESS2.GetFormattedValue()
        SCHOOLADDRESSLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSlblSCHOOLNAME.Text = Server.HtmlEncode(item.lblSCHOOLNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSlblSCHOOLNO.Text = Server.HtmlEncode(item.lblSCHOOLNO.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSSTATE.Text=item.STATE.GetFormattedValue()
        SCHOOLADDRESSCOUNTRY.Text=item.COUNTRY.GetFormattedValue()
        SCHOOLADDRESSPHONE_B.Text=item.PHONE_B.GetFormattedValue()
        SCHOOLADDRESSLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSlinkSchoolMaint.InnerText += item.linkSchoolMaint.GetFormattedValue().Replace(vbCrLf,"")
        SCHOOLADDRESSlinkSchoolMaint.HRef = item.linkSchoolMaintHref+item.linkSchoolMaintHrefParameters.ToString("GET","", ViewState)
        SCHOOLADDRESSlblADDRESS_ID.Text = Server.HtmlEncode(item.lblADDRESS_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSHidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        SCHOOLADDRESSHidden_LAST_ALTERED_DATE.Value = item.Hidden_LAST_ALTERED_DATE.GetFormattedValue()
        SCHOOLADDRESSlblDebug.Text = Server.HtmlEncode(item.lblDebug.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOLADDRESSHiddenSCHOOLNO.Value = item.HiddenSCHOOLNO.GetFormattedValue()
'End Record Form SCHOOLADDRESS BeforeShow tail

'Label lblDebug Event BeforeShow. Action Retrieve Value for Control @53-ECB92905
            SCHOOLADDRESSlblDebug.Text = (New TextField("", System.Web.HttpContext.Current.Session("debugmsg"))).GetFormattedValue()
'End Label lblDebug Event BeforeShow. Action Retrieve Value for Control

'Record SCHOOLADDRESS Event BeforeShow. Action Declare Variable @30-C2EA7663
            Dim tmpSCHOOLID As String = "-1"
'End Record SCHOOLADDRESS Event BeforeShow. Action Declare Variable

'Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Variable @29-865E37CA
            tmpSCHOOLID = System.Web.HttpContext.Current.Request.QueryString("SCHOOL_ID")
'End Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Variable

'Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Control @27-F0ECD732
            SCHOOLADDRESSlblSCHOOLNO.Text = (New TextField("", tmpSCHOOLID)).GetFormattedValue()
'End Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Control

'Record SCHOOLADDRESS Event BeforeShow. Action DLookup @28-C3408CAC
            SCHOOLADDRESSlblSCHOOLNAME.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "rtrim(SCHOOL_NAME)" & " FROM " & "SCHOOL" & " WHERE " & "SCHOOL_ID='" & tmpSCHOOLID.tostring & "'"))).GetFormattedValue()
'End Record SCHOOLADDRESS Event BeforeShow. Action DLookup

'Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Control @52-5DB48908
            SCHOOLADDRESSHiddenSCHOOLNO.Value = (New TextField("", tmpSCHOOLID)).GetFormattedValue()
'End Record SCHOOLADDRESS Event BeforeShow. Action Retrieve Value for Control

'Record SCHOOLADDRESS Event BeforeShow. Action Custom Code @32-73254650
    ' -------------------------
    ' ERA: add SCHOOL_ID to link
	'dim tmpSchoolLink as New LinkParameterCollection()
      
    ' -------------------------
'End Record SCHOOLADDRESS Event BeforeShow. Action Custom Code

'Record Form SCHOOLADDRESS Show method tail @3-34D489C3
        If SCHOOLADDRESSErrors.Count > 0 Then
            SCHOOLADDRESSShowErrors()
        End If
    End Sub
'End Record Form SCHOOLADDRESS Show method tail

'Record Form SCHOOLADDRESS LoadItemFromRequest method @3-06C38DB1

    Protected Sub SCHOOLADDRESSLoadItemFromRequest(item As SCHOOLADDRESSItem, ByVal EnableValidation As Boolean)
        item.ADDRESSEE.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSADDRESSEE.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSADDRESSEE") Is Nothing Then
            item.ADDRESSEE.SetValue(SCHOOLADDRESSADDRESSEE.Text)
        Else
            item.ADDRESSEE.SetValue(ControlCustomValues("SCHOOLADDRESSADDRESSEE"))
        End If
        item.AGENT.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSAGENT.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSAGENT") Is Nothing Then
            item.AGENT.SetValue(SCHOOLADDRESSAGENT.Text)
        Else
            item.AGENT.SetValue(ControlCustomValues("SCHOOLADDRESSAGENT"))
        End If
        item.ADDR1.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSADDR1.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSADDR1") Is Nothing Then
            item.ADDR1.SetValue(SCHOOLADDRESSADDR1.Text)
        Else
            item.ADDR1.SetValue(ControlCustomValues("SCHOOLADDRESSADDR1"))
        End If
        item.ADDR2.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSADDR2.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSADDR2") Is Nothing Then
            item.ADDR2.SetValue(SCHOOLADDRESSADDR2.Text)
        Else
            item.ADDR2.SetValue(ControlCustomValues("SCHOOLADDRESSADDR2"))
        End If
        item.SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSSUBURB_TOWN.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSSUBURB_TOWN") Is Nothing Then
            item.SUBURB_TOWN.SetValue(SCHOOLADDRESSSUBURB_TOWN.Text)
        Else
            item.SUBURB_TOWN.SetValue(ControlCustomValues("SCHOOLADDRESSSUBURB_TOWN"))
        End If
        item.POSTCODE.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSPOSTCODE.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSPOSTCODE") Is Nothing Then
            item.POSTCODE.SetValue(SCHOOLADDRESSPOSTCODE.Text)
        Else
            item.POSTCODE.SetValue(ControlCustomValues("SCHOOLADDRESSPOSTCODE"))
        End If
        item.PHONE_A.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSPHONE_A.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSPHONE_A") Is Nothing Then
            item.PHONE_A.SetValue(SCHOOLADDRESSPHONE_A.Text)
        Else
            item.PHONE_A.SetValue(ControlCustomValues("SCHOOLADDRESSPHONE_A"))
        End If
        item.FAX.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSFAX.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSFAX") Is Nothing Then
            item.FAX.SetValue(SCHOOLADDRESSFAX.Text)
        Else
            item.FAX.SetValue(ControlCustomValues("SCHOOLADDRESSFAX"))
        End If
        item.EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSEMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSEMAIL_ADDRESS") Is Nothing Then
            item.EMAIL_ADDRESS.SetValue(SCHOOLADDRESSEMAIL_ADDRESS.Text)
        Else
            item.EMAIL_ADDRESS.SetValue(ControlCustomValues("SCHOOLADDRESSEMAIL_ADDRESS"))
        End If
        item.EMAIL_ADDRESS2.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSEMAIL_ADDRESS2.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSEMAIL_ADDRESS2") Is Nothing Then
            item.EMAIL_ADDRESS2.SetValue(SCHOOLADDRESSEMAIL_ADDRESS2.Text)
        Else
            item.EMAIL_ADDRESS2.SetValue(ControlCustomValues("SCHOOLADDRESSEMAIL_ADDRESS2"))
        End If
        item.STATE.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSSTATE.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSSTATE") Is Nothing Then
            item.STATE.SetValue(SCHOOLADDRESSSTATE.Text)
        Else
            item.STATE.SetValue(ControlCustomValues("SCHOOLADDRESSSTATE"))
        End If
        item.COUNTRY.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSCOUNTRY.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSCOUNTRY") Is Nothing Then
            item.COUNTRY.SetValue(SCHOOLADDRESSCOUNTRY.Text)
        Else
            item.COUNTRY.SetValue(ControlCustomValues("SCHOOLADDRESSCOUNTRY"))
        End If
        item.PHONE_B.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSPHONE_B.UniqueID))
        If ControlCustomValues("SCHOOLADDRESSPHONE_B") Is Nothing Then
            item.PHONE_B.SetValue(SCHOOLADDRESSPHONE_B.Text)
        Else
            item.PHONE_B.SetValue(ControlCustomValues("SCHOOLADDRESSPHONE_B"))
        End If
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSHidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(SCHOOLADDRESSHidden_LAST_ALTERED_BY.Value)
        Try
        item.Hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSHidden_LAST_ALTERED_DATE.UniqueID))
        item.Hidden_LAST_ALTERED_DATE.SetValue(SCHOOLADDRESSHidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            SCHOOLADDRESSErrors.Add("Hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_LAST_ALTERED_DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.HiddenSCHOOLNO.IsEmpty = IsNothing(Request.Form(SCHOOLADDRESSHiddenSCHOOLNO.UniqueID))
        item.HiddenSCHOOLNO.SetValue(SCHOOLADDRESSHiddenSCHOOLNO.Value)
        If EnableValidation Then
            item.Validate(SCHOOLADDRESSData)
        End If
        SCHOOLADDRESSErrors.Add(item.errors)
    End Sub
'End Record Form SCHOOLADDRESS LoadItemFromRequest method

'Record Form SCHOOLADDRESS GetRedirectUrl method @3-9B6A56B7

    Protected Function GetSCHOOLADDRESSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "SCHOOL_maint.aspx"
        Dim p As String = parameters.ToString("GET","ADDRESS_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SCHOOLADDRESS GetRedirectUrl method

'Record Form SCHOOLADDRESS ShowErrors method @3-9FCCD6BD

    Protected Sub SCHOOLADDRESSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SCHOOLADDRESSErrors.Count - 1
        Select Case SCHOOLADDRESSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SCHOOLADDRESSErrors(i)
        End Select
        Next i
        SCHOOLADDRESSError.Visible = True
        SCHOOLADDRESSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SCHOOLADDRESS ShowErrors method

'Record Form SCHOOLADDRESS Insert Operation @3-8A3D4D89

    Protected Sub SCHOOLADDRESS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLADDRESSItem = New SCHOOLADDRESSItem()
        Dim ExecuteFlag As Boolean = True
        SCHOOLADDRESSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOLADDRESS Insert Operation

'Button Button_Insert OnClick. @4-C315E6B7
        If CType(sender,Control).ID = "SCHOOLADDRESSButton_Insert" Then
            RedirectUrl = GetSCHOOLADDRESSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @4-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form SCHOOLADDRESS BeforeInsert tail @3-3BA15EC5
    SCHOOLADDRESSParameters()
    SCHOOLADDRESSLoadItemFromRequest(item, EnableValidation)
    If SCHOOLADDRESSOperations.AllowInsert Then
        ErrorFlag=(SCHOOLADDRESSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOLADDRESSData.InsertItem(item)
            Catch ex As Exception
                SCHOOLADDRESSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOLADDRESS BeforeInsert tail

'Record SCHOOLADDRESS Event AfterInsert. Action Custom Code @38-73254650
    ' -------------------------
 	' 19-Mar-2009|EA| after a new Address is entered then also go back and update the Address_ID in the School record    	             
 	' do an update if the SCHOOL_ID and ADDRESS_ID are valid
 	' 12-Aug-2018|EA| rejigged to a) work and b) not need so many moving variables
 	'Dim tmpSCHOOLID As String = ""
    'tmpSCHOOLID=item.HiddenSCHOOLNO.Value
 	
 		If ExecuteFlag And (Not ErrorFlag) Then 
   			Dim NewDaoUpdateAddress As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
 			'AARRGGHH! - LAST_ALTERED_DATE is Custom type T_DATE and only has HH:MM - no SS, so need to go back 1 minute (and a bit) to get it!!!
 			'13-Nov-2018|EA| adjust check to 5 minutes as not picking up schools
 			Dim Sql As String = "update sch set sch.address_id = ad.address_id " & _
 				 "from school sch inner join address ad on convert(varchar(15),sch.school_id) = ad.barcode " & _
 				 " and sch.address_id is null and ad.LAST_ALTERED_DATE >= dateadd(minute, -5, getdate()) " 
 			NewDaoUpdateAddress.RunSql(Sql)
 			'HttpContext.Current.Session("debugmsg") = Sql
			'Dim addressid As String
			'addressid = Convert.ToString(Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select top 1 address_id  from address where barcode ='18276.10' and LAST_ALTERED_DATE >= dateadd(second, -65, getdate())"))
   			'HttpContext.Current.Session("debugmsg") = addressid
			
   			'debug
   			'SCHOOLADDRESSErrors.Add("AfterInsert",Sql)
 			'ErrorFlag = True
        End If
    ' -------------------------
'End Record SCHOOLADDRESS Event AfterInsert. Action Custom Code

'Record SCHOOLADDRESS Event AfterInsert. Action Save Variable Value @54-3AF27965
        HttpContext.Current.Session("notifymessage") = "School Address has been Added to School"
'End Record SCHOOLADDRESS Event AfterInsert. Action Save Variable Value

'Record Form SCHOOLADDRESS AfterInsert tail  @3-3E7C9D27
        End If
        ErrorFlag=(SCHOOLADDRESSErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOLADDRESS AfterInsert tail 

'Record Form SCHOOLADDRESS Update Operation @3-B0BD4328

    Protected Sub SCHOOLADDRESS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLADDRESSItem = New SCHOOLADDRESSItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SCHOOLADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOLADDRESS Update Operation

'Button Button_Update OnClick. @5-47DD7828
        If CType(sender,Control).ID = "SCHOOLADDRESSButton_Update" Then
            RedirectUrl = GetSCHOOLADDRESSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record SCHOOLADDRESS Event BeforeUpdate. Action Retrieve Value for Control @44-6F6AA94E
        SCHOOLADDRESSHidden_LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record SCHOOLADDRESS Event BeforeUpdate. Action Retrieve Value for Control

'Record SCHOOLADDRESS Event BeforeUpdate. Action Retrieve Value for Control @45-DEE41532
        SCHOOLADDRESSHidden_LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record SCHOOLADDRESS Event BeforeUpdate. Action Retrieve Value for Control

'Record Form SCHOOLADDRESS Before Update tail @3-81E0FB78
        SCHOOLADDRESSParameters()
        SCHOOLADDRESSLoadItemFromRequest(item, EnableValidation)
        If SCHOOLADDRESSOperations.AllowUpdate Then
        ErrorFlag = (SCHOOLADDRESSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOLADDRESSData.UpdateItem(item)
            Catch ex As Exception
                SCHOOLADDRESSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOLADDRESS Before Update tail

'Record SCHOOLADDRESS Event AfterUpdate. Action Save Variable Value @55-AF1ED972
        HttpContext.Current.Session("notifymessage") = "School Address has been Updated"
'End Record SCHOOLADDRESS Event AfterUpdate. Action Save Variable Value

'Record Form SCHOOLADDRESS Update Operation tail @3-3E7C9D27
        End If
        ErrorFlag=(SCHOOLADDRESSErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOLADDRESS Update Operation tail

'Record Form SCHOOLADDRESS Delete Operation @3-DF978504
    Protected Sub SCHOOLADDRESS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SCHOOLADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SCHOOLADDRESSItem = New SCHOOLADDRESSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SCHOOLADDRESS Delete Operation

'Button Button_Delete OnClick. @6-28D03420
        If CType(sender,Control).ID = "SCHOOLADDRESSButton_Delete" Then
            RedirectUrl = GetSCHOOLADDRESSRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @6-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @3-995E6AF8
        SCHOOLADDRESSParameters()
        SCHOOLADDRESSLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-344A1897
        If ErrorFlag Then
            SCHOOLADDRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SCHOOLADDRESS Cancel Operation @3-43FE7D9B

    Protected Sub SCHOOLADDRESS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLADDRESSItem = New SCHOOLADDRESSItem()
        SCHOOLADDRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        SCHOOLADDRESSLoadItemFromRequest(item, False)
'End Record Form SCHOOLADDRESS Cancel Operation

'Button Button_Cancel OnClick. @8-FB4D4109
    If CType(sender,Control).ID = "SCHOOLADDRESSButton_Cancel" Then
        RedirectUrl = GetSCHOOLADDRESSRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @8-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form SCHOOLADDRESS Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SCHOOLADDRESS Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4D29A06E
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SCHOOL_ADDRESS_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOLADDRESSData = New SCHOOLADDRESSDataProvider()
        SCHOOLADDRESSOperations = New FormSupportedOperations(False, True, True, True, False)
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

