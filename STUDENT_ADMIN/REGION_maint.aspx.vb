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

Namespace DECV_PROD2007.REGION_maint 'Namespace @1-104D6AEC

'Forms Definition @1-78E03FEF
Public Class [REGION_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1F3EF372
    Protected REGIONData As REGIONDataProvider
    Protected REGIONErrors As NameValueCollection = New NameValueCollection()
    Protected REGIONOperations As FormSupportedOperations
    Protected REGIONIsSubmitted As Boolean = False
    Protected REGION_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-268C8F11
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "REGION_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            REGIONShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form REGION Parameters @2-8DE788F9

    Protected Sub REGIONParameters()
        Dim item As new REGIONItem
        Try
            REGIONData.UrlREGION_ID = FloatParameter.GetParam("REGION_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            REGIONErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form REGION Parameters

'Record Form REGION Show method @2-631BB9B2
    Protected Sub REGIONShow()
        If REGIONOperations.None Then
            REGIONHolder.Visible = False
            Return
        End If
        Dim item As REGIONItem = REGIONItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not REGIONOperations.AllowRead
        REGIONErrors.Add(item.errors)
        If REGIONErrors.Count > 0 Then
            REGIONShowErrors()
            Return
        End If
'End Record Form REGION Show method

'Record Form REGION BeforeShow tail @2-4E10CABA
        REGIONParameters()
        REGIONData.FillItem(item, IsInsertMode)
        REGIONHolder.DataBind()
        REGIONButton_Insert.Visible=IsInsertMode AndAlso REGIONOperations.AllowInsert
        REGIONButton_Update.Visible=Not (IsInsertMode) AndAlso REGIONOperations.AllowUpdate
        REGIONButton_Delete.Visible=Not (IsInsertMode) AndAlso REGIONOperations.AllowDelete
        REGIONREGION_NAME.Text=item.REGION_NAME.GetFormattedValue()
        REGIONPHONE.Text=item.PHONE.GetFormattedValue()
        REGIONFAX.Text=item.FAX.GetFormattedValue()
        REGIONEMAIL_ADDRESS.Text=item.EMAIL_ADDRESS.GetFormattedValue()
        REGIONADDR1.Text=item.ADDR1.GetFormattedValue()
        REGIONADDR2.Text=item.ADDR2.GetFormattedValue()
        REGIONSUBURB_TOWN.Text=item.SUBURB_TOWN.GetFormattedValue()
        REGIONPOSTCODE.Text=item.POSTCODE.GetFormattedValue()
        REGIONLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        REGIONLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        item.RadioButtonStatusItems.SetSelection(item.RadioButtonStatus.GetFormattedValue())
        REGIONRadioButtonStatus.SelectedIndex = -1
        item.RadioButtonStatusItems.CopyTo(REGIONRadioButtonStatus.Items)
        REGIONPARENT_REGION_ID.Items.Add(new ListItem("No Parent Region","0"))
        REGIONPARENT_REGION_ID.Items(0).Selected = True
        item.PARENT_REGION_IDItems.SetSelection(item.PARENT_REGION_ID.GetFormattedValue())
        If Not item.PARENT_REGION_IDItems.GetSelectedItem() Is Nothing Then
            REGIONPARENT_REGION_ID.SelectedIndex = -1
        End If
        item.PARENT_REGION_IDItems.CopyTo(REGIONPARENT_REGION_ID.Items)
        REGIONREGION_ID.Text=item.REGION_ID.GetFormattedValue()
        REGIONlblREGION_ID.Text = Server.HtmlEncode(item.lblREGION_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        REGIONlabel_Last_altered_by.Text = Server.HtmlEncode(item.label_Last_altered_by.GetFormattedValue()).Replace(vbCrLf,"<br>")
        REGIONlabel_last_altered_date.Text = Server.HtmlEncode(item.label_last_altered_date.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form REGION BeforeShow tail

'TextBox REGION_ID Event BeforeShow. Action Hide-Show Component @27-0AB714AD
        Dim IsEditMode_27_1 As BooleanField = New BooleanField(Settings.BoolFormat,Not IsInsertMode)
        Dim ExprParam2_27_2 As BooleanField = New BooleanField(Settings.BoolFormat, (true))
        If FieldBase.EqualOp(IsEditMode_27_1, ExprParam2_27_2) Then
            REGIONREGION_ID.Visible = False
        End If
'End TextBox REGION_ID Event BeforeShow. Action Hide-Show Component

'Record Form REGION Show method tail @2-F0FD8EA0
        If REGIONErrors.Count > 0 Then
            REGIONShowErrors()
        End If
    End Sub
'End Record Form REGION Show method tail

'Record Form REGION LoadItemFromRequest method @2-EDE8B300

    Protected Sub REGIONLoadItemFromRequest(item As REGIONItem, ByVal EnableValidation As Boolean)
        item.REGION_NAME.IsEmpty = IsNothing(Request.Form(REGIONREGION_NAME.UniqueID))
        If ControlCustomValues("REGIONREGION_NAME") Is Nothing Then
            item.REGION_NAME.SetValue(REGIONREGION_NAME.Text)
        Else
            item.REGION_NAME.SetValue(ControlCustomValues("REGIONREGION_NAME"))
        End If
        item.PHONE.IsEmpty = IsNothing(Request.Form(REGIONPHONE.UniqueID))
        If ControlCustomValues("REGIONPHONE") Is Nothing Then
            item.PHONE.SetValue(REGIONPHONE.Text)
        Else
            item.PHONE.SetValue(ControlCustomValues("REGIONPHONE"))
        End If
        item.FAX.IsEmpty = IsNothing(Request.Form(REGIONFAX.UniqueID))
        If ControlCustomValues("REGIONFAX") Is Nothing Then
            item.FAX.SetValue(REGIONFAX.Text)
        Else
            item.FAX.SetValue(ControlCustomValues("REGIONFAX"))
        End If
        item.EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(REGIONEMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("REGIONEMAIL_ADDRESS") Is Nothing Then
            item.EMAIL_ADDRESS.SetValue(REGIONEMAIL_ADDRESS.Text)
        Else
            item.EMAIL_ADDRESS.SetValue(ControlCustomValues("REGIONEMAIL_ADDRESS"))
        End If
        item.ADDR1.IsEmpty = IsNothing(Request.Form(REGIONADDR1.UniqueID))
        If ControlCustomValues("REGIONADDR1") Is Nothing Then
            item.ADDR1.SetValue(REGIONADDR1.Text)
        Else
            item.ADDR1.SetValue(ControlCustomValues("REGIONADDR1"))
        End If
        item.ADDR2.IsEmpty = IsNothing(Request.Form(REGIONADDR2.UniqueID))
        If ControlCustomValues("REGIONADDR2") Is Nothing Then
            item.ADDR2.SetValue(REGIONADDR2.Text)
        Else
            item.ADDR2.SetValue(ControlCustomValues("REGIONADDR2"))
        End If
        item.SUBURB_TOWN.IsEmpty = IsNothing(Request.Form(REGIONSUBURB_TOWN.UniqueID))
        If ControlCustomValues("REGIONSUBURB_TOWN") Is Nothing Then
            item.SUBURB_TOWN.SetValue(REGIONSUBURB_TOWN.Text)
        Else
            item.SUBURB_TOWN.SetValue(ControlCustomValues("REGIONSUBURB_TOWN"))
        End If
        item.POSTCODE.IsEmpty = IsNothing(Request.Form(REGIONPOSTCODE.UniqueID))
        If ControlCustomValues("REGIONPOSTCODE") Is Nothing Then
            item.POSTCODE.SetValue(REGIONPOSTCODE.Text)
        Else
            item.POSTCODE.SetValue(ControlCustomValues("REGIONPOSTCODE"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(REGIONLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(REGIONLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(REGIONLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(REGIONLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            REGIONErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","GeneralDate"))
        End Try
        item.RadioButtonStatus.IsEmpty = IsNothing(Request.Form(REGIONRadioButtonStatus.UniqueID))
        If Not IsNothing(REGIONRadioButtonStatus.SelectedItem) Then
            item.RadioButtonStatus.SetValue(REGIONRadioButtonStatus.SelectedItem.Value)
        Else
            item.RadioButtonStatus.Value = Nothing
        End If
        item.RadioButtonStatusItems.CopyFrom(REGIONRadioButtonStatus.Items)
        Try
        item.PARENT_REGION_ID.IsEmpty = IsNothing(Request.Form(REGIONPARENT_REGION_ID.UniqueID))
        item.PARENT_REGION_ID.SetValue(REGIONPARENT_REGION_ID.Value)
        item.PARENT_REGION_IDItems.CopyFrom(REGIONPARENT_REGION_ID.Items)
        Catch ae As ArgumentException
            REGIONErrors.Add("PARENT_REGION_ID",String.Format(Resources.strings.CCS_IncorrectValue,"PARENT_REGION_ID"))
        End Try
        Try
        item.REGION_ID.IsEmpty = IsNothing(Request.Form(REGIONREGION_ID.UniqueID))
        If ControlCustomValues("REGIONREGION_ID") Is Nothing Then
            item.REGION_ID.SetValue(REGIONREGION_ID.Text)
        Else
            item.REGION_ID.SetValue(ControlCustomValues("REGIONREGION_ID"))
        End If
        Catch ae As ArgumentException
            REGIONErrors.Add("REGION_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Region ID"))
        End Try
        If EnableValidation Then
            item.Validate(REGIONData)
        End If
        REGIONErrors.Add(item.errors)
    End Sub
'End Record Form REGION LoadItemFromRequest method

'Record Form REGION GetRedirectUrl method @2-E108C268

    Protected Function GetREGIONRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "REGION_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form REGION GetRedirectUrl method

'Record Form REGION ShowErrors method @2-24FBD10D

    Protected Sub REGIONShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To REGIONErrors.Count - 1
        Select Case REGIONErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & REGIONErrors(i)
        End Select
        Next i
        REGIONError.Visible = True
        REGIONErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form REGION ShowErrors method

'Record Form REGION Insert Operation @2-427CBFED

    Protected Sub REGION_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REGIONItem = New REGIONItem()
        Dim ExecuteFlag As Boolean = True
        REGIONIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REGION Insert Operation

'Button Button_Insert OnClick. @3-21BBE84B
        If CType(sender,Control).ID = "REGIONButton_Insert" Then
            RedirectUrl = GetREGIONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form REGION BeforeInsert tail @2-3C8B4AC6
    REGIONParameters()
    REGIONLoadItemFromRequest(item, EnableValidation)
    If REGIONOperations.AllowInsert Then
        ErrorFlag=(REGIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                REGIONData.InsertItem(item)
            Catch ex As Exception
                REGIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form REGION BeforeInsert tail

'Record Form REGION AfterInsert tail  @2-6A234B5C
        End If
        ErrorFlag=(REGIONErrors.Count > 0)
        If ErrorFlag Then
            REGIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REGION AfterInsert tail 

'Record Form REGION Update Operation @2-9BC8E96C

    Protected Sub REGION_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REGIONItem = New REGIONItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        REGIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form REGION Update Operation

'Button Button_Update OnClick. @4-CB81B0BE
        If CType(sender,Control).ID = "REGIONButton_Update" Then
            RedirectUrl = GetREGIONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record REGION Event BeforeUpdate. Action Custom Code @21-73254650
    ' -------------------------
    ' ERA: update last saved by and date
	'item.last_altered_by.value=(New TextField("", (DBUtility.UserId.ToString()))).GetFormattedValue()
	'item.last_altered_date.value=datetime.now
	'REGIONLAST_ALTERED_BY.value=DBUtility.UserId.ToString()
	'REGIONLAST_ALTERED_DATE.text=datetime.now.tostring()
	
    ' -------------------------
'End Record REGION Event BeforeUpdate. Action Custom Code

'Record REGION Event BeforeUpdate. Action Retrieve Value for Control @28-0EA1096C
        REGIONLAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserID.tostring()))).GetFormattedValue()
'End Record REGION Event BeforeUpdate. Action Retrieve Value for Control

'Record REGION Event BeforeUpdate. Action Retrieve Value for Control @29-B35DC583
        REGIONLAST_ALTERED_DATE.Value = (New DateField("G", (Now()))).GetFormattedValue()
'End Record REGION Event BeforeUpdate. Action Retrieve Value for Control

'Record Form REGION Before Update tail @2-8BD8F719
        REGIONParameters()
        REGIONLoadItemFromRequest(item, EnableValidation)
        If REGIONOperations.AllowUpdate Then
        ErrorFlag = (REGIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                REGIONData.UpdateItem(item)
            Catch ex As Exception
                REGIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form REGION Before Update tail

'Record Form REGION Update Operation tail @2-6A234B5C
        End If
        ErrorFlag=(REGIONErrors.Count > 0)
        If ErrorFlag Then
            REGIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form REGION Update Operation tail

'Record Form REGION Delete Operation @2-198D0327
    Protected Sub REGION_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        REGIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As REGIONItem = New REGIONItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form REGION Delete Operation

'Button Button_Delete OnClick. @5-54A574A9
        If CType(sender,Control).ID = "REGIONButton_Delete" Then
            RedirectUrl = GetREGIONRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-B529A2B5
        REGIONParameters()
        REGIONLoadItemFromRequest(item, EnableValidation)
        If REGIONOperations.AllowDelete Then
        ErrorFlag = (REGIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                REGIONData.DeleteItem(item)
            Catch ex As Exception
                REGIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-58EC1DED
        End If
        If ErrorFlag Then
            REGIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form REGION Cancel Operation @2-33275A8B

    Protected Sub REGION_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As REGIONItem = New REGIONItem()
        REGIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        REGIONLoadItemFromRequest(item, True)
'End Record Form REGION Cancel Operation

'Record Form REGION Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form REGION Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A3E0003D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        REGION_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        REGIONData = New REGIONDataProvider()
        REGIONOperations = New FormSupportedOperations(False, True, True, True, True)
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

