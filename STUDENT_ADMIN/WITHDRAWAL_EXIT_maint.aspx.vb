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

Namespace DECV_PROD2007.WITHDRAWAL_EXIT_maint 'Namespace @1-F90D6A05

'Forms Definition @1-2BB8747F
Public Class [WITHDRAWAL_EXIT_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-38E80FA9
    Protected WITHDRAWAL_EXIT_DESTINATIData As WITHDRAWAL_EXIT_DESTINATIDataProvider
    Protected WITHDRAWAL_EXIT_DESTINATIErrors As NameValueCollection = New NameValueCollection()
    Protected WITHDRAWAL_EXIT_DESTINATIOperations As FormSupportedOperations
    Protected WITHDRAWAL_EXIT_DESTINATIIsSubmitted As Boolean = False
    Protected WITHDRAWAL_EXIT_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-F705EE9D
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "WITHDRAWAL_EXIT_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            WITHDRAWAL_EXIT_DESTINATIShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form WITHDRAWAL_EXIT_DESTINATI Parameters @2-09190FBB

    Protected Sub WITHDRAWAL_EXIT_DESTINATIParameters()
        Dim item As new WITHDRAWAL_EXIT_DESTINATIItem
        Try
            WITHDRAWAL_EXIT_DESTINATIData.UrlWD_DEST_ID = FloatParameter.GetParam("WD_DEST_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            WITHDRAWAL_EXIT_DESTINATIErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI Parameters

'Record Form WITHDRAWAL_EXIT_DESTINATI Show method @2-ADA6A401
    Protected Sub WITHDRAWAL_EXIT_DESTINATIShow()
        If WITHDRAWAL_EXIT_DESTINATIOperations.None Then
            WITHDRAWAL_EXIT_DESTINATIHolder.Visible = False
            Return
        End If
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = WITHDRAWAL_EXIT_DESTINATIItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not WITHDRAWAL_EXIT_DESTINATIOperations.AllowRead
        WITHDRAWAL_EXIT_DESTINATIErrors.Add(item.errors)
        If WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0 Then
            WITHDRAWAL_EXIT_DESTINATIShowErrors()
            Return
        End If
'End Record Form WITHDRAWAL_EXIT_DESTINATI Show method

'Record Form WITHDRAWAL_EXIT_DESTINATI BeforeShow tail @2-DD135F99
        WITHDRAWAL_EXIT_DESTINATIParameters()
        WITHDRAWAL_EXIT_DESTINATIData.FillItem(item, IsInsertMode)
        WITHDRAWAL_EXIT_DESTINATIHolder.DataBind()
        WITHDRAWAL_EXIT_DESTINATIButton_Insert.Visible=IsInsertMode AndAlso WITHDRAWAL_EXIT_DESTINATIOperations.AllowInsert
        WITHDRAWAL_EXIT_DESTINATIButton_Update.Visible=Not (IsInsertMode) AndAlso WITHDRAWAL_EXIT_DESTINATIOperations.AllowUpdate
        WITHDRAWAL_EXIT_DESTINATIButton_Delete.Visible=Not (IsInsertMode) AndAlso WITHDRAWAL_EXIT_DESTINATIOperations.AllowDelete
        WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION.Text=item.EXIT_DESTINATION_DESCRIPTION.GetFormattedValue()
        WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER.Text=item.DISPLAY_ORDER.GetFormattedValue()
        WITHDRAWAL_EXIT_DESTINATIGROUPING.Items.Add(new ListItem("Select Value",""))
        WITHDRAWAL_EXIT_DESTINATIGROUPING.Items(0).Selected = True
        item.GROUPINGItems.SetSelection(item.GROUPING.GetFormattedValue())
        If Not item.GROUPINGItems.GetSelectedItem() Is Nothing Then
            WITHDRAWAL_EXIT_DESTINATIGROUPING.SelectedIndex = -1
        End If
        item.GROUPINGItems.CopyTo(WITHDRAWAL_EXIT_DESTINATIGROUPING.Items)
        WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        WITHDRAWAL_EXIT_DESTINATIlblLAST_ALTERED_BY.Text = Server.HtmlEncode(item.lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        WITHDRAWAL_EXIT_DESTINATIlblLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form WITHDRAWAL_EXIT_DESTINATI BeforeShow tail

'Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control @18-14B4B6A0
            WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper()))).GetFormattedValue()
'End Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control

'Hidden LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control @19-F11E9ED8
            WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Hidden LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control

'Record Form WITHDRAWAL_EXIT_DESTINATI Show method tail @2-1933CEF5
        If WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0 Then
            WITHDRAWAL_EXIT_DESTINATIShowErrors()
        End If
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI Show method tail

'Record Form WITHDRAWAL_EXIT_DESTINATI LoadItemFromRequest method @2-3DF72268

    Protected Sub WITHDRAWAL_EXIT_DESTINATILoadItemFromRequest(item As WITHDRAWAL_EXIT_DESTINATIItem, ByVal EnableValidation As Boolean)
        item.EXIT_DESTINATION_DESCRIPTION.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION.UniqueID))
        If ControlCustomValues("WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION") Is Nothing Then
            item.EXIT_DESTINATION_DESCRIPTION.SetValue(WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION.Text)
        Else
            item.EXIT_DESTINATION_DESCRIPTION.SetValue(ControlCustomValues("WITHDRAWAL_EXIT_DESTINATIEXIT_DESTINATION_DESCRIPTION"))
        End If
        Try
        item.DISPLAY_ORDER.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER.UniqueID))
        If ControlCustomValues("WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER") Is Nothing Then
            item.DISPLAY_ORDER.SetValue(WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER.Text)
        Else
            item.DISPLAY_ORDER.SetValue(ControlCustomValues("WITHDRAWAL_EXIT_DESTINATIDISPLAY_ORDER"))
        End If
        Catch ae As ArgumentException
            WITHDRAWAL_EXIT_DESTINATIErrors.Add("DISPLAY_ORDER",String.Format(Resources.strings.CCS_IncorrectValue,"DISPLAY ORDER"))
        End Try
        item.GROUPING.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_EXIT_DESTINATIGROUPING.UniqueID))
        item.GROUPING.SetValue(WITHDRAWAL_EXIT_DESTINATIGROUPING.Value)
        item.GROUPINGItems.CopyFrom(WITHDRAWAL_EXIT_DESTINATIGROUPING.Items)
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(WITHDRAWAL_EXIT_DESTINATILAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            WITHDRAWAL_EXIT_DESTINATIErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        If EnableValidation Then
            item.Validate(WITHDRAWAL_EXIT_DESTINATIData)
        End If
        WITHDRAWAL_EXIT_DESTINATIErrors.Add(item.errors)
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI LoadItemFromRequest method

'Record Form WITHDRAWAL_EXIT_DESTINATI GetRedirectUrl method @2-E68780F7

    Protected Function GetWITHDRAWAL_EXIT_DESTINATIRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "WITHDRAWAL_EXIT_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form WITHDRAWAL_EXIT_DESTINATI GetRedirectUrl method

'Record Form WITHDRAWAL_EXIT_DESTINATI ShowErrors method @2-6224D024

    Protected Sub WITHDRAWAL_EXIT_DESTINATIShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To WITHDRAWAL_EXIT_DESTINATIErrors.Count - 1
        Select Case WITHDRAWAL_EXIT_DESTINATIErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & WITHDRAWAL_EXIT_DESTINATIErrors(i)
        End Select
        Next i
        WITHDRAWAL_EXIT_DESTINATIError.Visible = True
        WITHDRAWAL_EXIT_DESTINATIErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI ShowErrors method

'Record Form WITHDRAWAL_EXIT_DESTINATI Insert Operation @2-56C2ACBC

    Protected Sub WITHDRAWAL_EXIT_DESTINATI_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        Dim ExecuteFlag As Boolean = True
        WITHDRAWAL_EXIT_DESTINATIIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form WITHDRAWAL_EXIT_DESTINATI Insert Operation

'Button Button_Insert OnClick. @3-62F138DB
        If CType(sender,Control).ID = "WITHDRAWAL_EXIT_DESTINATIButton_Insert" Then
            RedirectUrl = GetWITHDRAWAL_EXIT_DESTINATIRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form WITHDRAWAL_EXIT_DESTINATI BeforeInsert tail @2-11FB56F6
    WITHDRAWAL_EXIT_DESTINATIParameters()
    WITHDRAWAL_EXIT_DESTINATILoadItemFromRequest(item, EnableValidation)
    If WITHDRAWAL_EXIT_DESTINATIOperations.AllowInsert Then
        ErrorFlag=(WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                WITHDRAWAL_EXIT_DESTINATIData.InsertItem(item)
            Catch ex As Exception
                WITHDRAWAL_EXIT_DESTINATIErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form WITHDRAWAL_EXIT_DESTINATI BeforeInsert tail

'Record Form WITHDRAWAL_EXIT_DESTINATI AfterInsert tail  @2-2E7409FB
        End If
        ErrorFlag=(WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0)
        If ErrorFlag Then
            WITHDRAWAL_EXIT_DESTINATIShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI AfterInsert tail 

'Record Form WITHDRAWAL_EXIT_DESTINATI Update Operation @2-D09DF485

    Protected Sub WITHDRAWAL_EXIT_DESTINATI_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        WITHDRAWAL_EXIT_DESTINATIIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form WITHDRAWAL_EXIT_DESTINATI Update Operation

'Button Button_Update OnClick. @4-A70AE0F2
        If CType(sender,Control).ID = "WITHDRAWAL_EXIT_DESTINATIButton_Update" Then
            RedirectUrl = GetWITHDRAWAL_EXIT_DESTINATIRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form WITHDRAWAL_EXIT_DESTINATI Before Update tail @2-4B47CDC8
        WITHDRAWAL_EXIT_DESTINATIParameters()
        WITHDRAWAL_EXIT_DESTINATILoadItemFromRequest(item, EnableValidation)
        If WITHDRAWAL_EXIT_DESTINATIOperations.AllowUpdate Then
        ErrorFlag = (WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                WITHDRAWAL_EXIT_DESTINATIData.UpdateItem(item)
            Catch ex As Exception
                WITHDRAWAL_EXIT_DESTINATIErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form WITHDRAWAL_EXIT_DESTINATI Before Update tail

'Record Form WITHDRAWAL_EXIT_DESTINATI Update Operation tail @2-2E7409FB
        End If
        ErrorFlag=(WITHDRAWAL_EXIT_DESTINATIErrors.Count > 0)
        If ErrorFlag Then
            WITHDRAWAL_EXIT_DESTINATIShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI Update Operation tail

'Record Form WITHDRAWAL_EXIT_DESTINATI Delete Operation @2-442D1124
    Protected Sub WITHDRAWAL_EXIT_DESTINATI_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        WITHDRAWAL_EXIT_DESTINATIIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form WITHDRAWAL_EXIT_DESTINATI Delete Operation

'Button Button_Delete OnClick. @5-B99EFDDE
        If CType(sender,Control).ID = "WITHDRAWAL_EXIT_DESTINATIButton_Delete" Then
            RedirectUrl = GetWITHDRAWAL_EXIT_DESTINATIRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-2CA7BC82
        WITHDRAWAL_EXIT_DESTINATIParameters()
        WITHDRAWAL_EXIT_DESTINATILoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-FFB6EEAB
        If ErrorFlag Then
            WITHDRAWAL_EXIT_DESTINATIShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form WITHDRAWAL_EXIT_DESTINATI Cancel Operation @2-333AAE5F

    Protected Sub WITHDRAWAL_EXIT_DESTINATI_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
        WITHDRAWAL_EXIT_DESTINATIIsSubmitted = True
        Dim RedirectUrl As String = ""
        WITHDRAWAL_EXIT_DESTINATILoadItemFromRequest(item, True)
'End Record Form WITHDRAWAL_EXIT_DESTINATI Cancel Operation

'Record Form WITHDRAWAL_EXIT_DESTINATI Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form WITHDRAWAL_EXIT_DESTINATI Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-81374069
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        WITHDRAWAL_EXIT_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        WITHDRAWAL_EXIT_DESTINATIData = New WITHDRAWAL_EXIT_DESTINATIDataProvider()
        WITHDRAWAL_EXIT_DESTINATIOperations = New FormSupportedOperations(False, True, True, True, False)
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

