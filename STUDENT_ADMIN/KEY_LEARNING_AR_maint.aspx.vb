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

Namespace DECV_PROD2007.KEY_LEARNING_AR_maint 'Namespace @1-D71543C1

'Forms Definition @1-7670B60D
Public Class [KEY_LEARNING_AR_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-012EFEA1
    Protected KEY_LEARNING_AREAData As KEY_LEARNING_AREADataProvider
    Protected KEY_LEARNING_AREAErrors As NameValueCollection = New NameValueCollection()
    Protected KEY_LEARNING_AREAOperations As FormSupportedOperations
    Protected KEY_LEARNING_AREAIsSubmitted As Boolean = False
    Protected KEY_LEARNING_AR_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-9F3D577B
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            KEY_LEARNING_AREAShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form KEY_LEARNING_AREA Parameters @2-B2E365A7

    Protected Sub KEY_LEARNING_AREAParameters()
        Dim item As new KEY_LEARNING_AREAItem
        Try
            KEY_LEARNING_AREAData.UrlKLA_ID = FloatParameter.GetParam("KLA_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            KEY_LEARNING_AREAErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form KEY_LEARNING_AREA Parameters

'Record Form KEY_LEARNING_AREA Show method @2-D0593E39
    Protected Sub KEY_LEARNING_AREAShow()
        If KEY_LEARNING_AREAOperations.None Then
            KEY_LEARNING_AREAHolder.Visible = False
            Return
        End If
        Dim item As KEY_LEARNING_AREAItem = KEY_LEARNING_AREAItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not KEY_LEARNING_AREAOperations.AllowRead
        KEY_LEARNING_AREAErrors.Add(item.errors)
        If KEY_LEARNING_AREAErrors.Count > 0 Then
            KEY_LEARNING_AREAShowErrors()
            Return
        End If
'End Record Form KEY_LEARNING_AREA Show method

'Record Form KEY_LEARNING_AREA BeforeShow tail @2-6C2D85F5
        KEY_LEARNING_AREAParameters()
        KEY_LEARNING_AREAData.FillItem(item, IsInsertMode)
        KEY_LEARNING_AREAHolder.DataBind()
        KEY_LEARNING_AREAButton_Insert.Visible=IsInsertMode AndAlso KEY_LEARNING_AREAOperations.AllowInsert
        KEY_LEARNING_AREAButton_Update.Visible=Not (IsInsertMode) AndAlso KEY_LEARNING_AREAOperations.AllowUpdate
        KEY_LEARNING_AREAButton_Delete.Visible=Not (IsInsertMode) AndAlso KEY_LEARNING_AREAOperations.AllowDelete
        KEY_LEARNING_AREAKEY_LEARNING_AREA.Text=item.KEY_LEARNING_AREA.GetFormattedValue()
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            KEY_LEARNING_AREASTATUS.Checked = True
        End If
        KEY_LEARNING_AREALAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        KEY_LEARNING_AREALAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form KEY_LEARNING_AREA BeforeShow tail

'Record Form KEY_LEARNING_AREA Show method tail @2-A17D00AF
        If KEY_LEARNING_AREAErrors.Count > 0 Then
            KEY_LEARNING_AREAShowErrors()
        End If
    End Sub
'End Record Form KEY_LEARNING_AREA Show method tail

'Record Form KEY_LEARNING_AREA LoadItemFromRequest method @2-81D5380F

    Protected Sub KEY_LEARNING_AREALoadItemFromRequest(item As KEY_LEARNING_AREAItem, ByVal EnableValidation As Boolean)
        item.KEY_LEARNING_AREA.IsEmpty = IsNothing(Request.Form(KEY_LEARNING_AREAKEY_LEARNING_AREA.UniqueID))
        If ControlCustomValues("KEY_LEARNING_AREAKEY_LEARNING_AREA") Is Nothing Then
            item.KEY_LEARNING_AREA.SetValue(KEY_LEARNING_AREAKEY_LEARNING_AREA.Text)
        Else
            item.KEY_LEARNING_AREA.SetValue(ControlCustomValues("KEY_LEARNING_AREAKEY_LEARNING_AREA"))
        End If
        If KEY_LEARNING_AREASTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(KEY_LEARNING_AREALAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("KEY_LEARNING_AREALAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(KEY_LEARNING_AREALAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("KEY_LEARNING_AREALAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(KEY_LEARNING_AREALAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("KEY_LEARNING_AREALAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(KEY_LEARNING_AREALAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("KEY_LEARNING_AREALAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            KEY_LEARNING_AREAErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(KEY_LEARNING_AREAData)
        End If
        KEY_LEARNING_AREAErrors.Add(item.errors)
    End Sub
'End Record Form KEY_LEARNING_AREA LoadItemFromRequest method

'Record Form KEY_LEARNING_AREA GetRedirectUrl method @2-5D3C79AC

    Protected Function GetKEY_LEARNING_AREARedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "KEY_LEARNING_AR_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form KEY_LEARNING_AREA GetRedirectUrl method

'Record Form KEY_LEARNING_AREA ShowErrors method @2-0D7B049D

    Protected Sub KEY_LEARNING_AREAShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To KEY_LEARNING_AREAErrors.Count - 1
        Select Case KEY_LEARNING_AREAErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & KEY_LEARNING_AREAErrors(i)
        End Select
        Next i
        KEY_LEARNING_AREAError.Visible = True
        KEY_LEARNING_AREAErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form KEY_LEARNING_AREA ShowErrors method

'Record Form KEY_LEARNING_AREA Insert Operation @2-7AAD4130

    Protected Sub KEY_LEARNING_AREA_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        Dim ExecuteFlag As Boolean = True
        KEY_LEARNING_AREAIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form KEY_LEARNING_AREA Insert Operation

'Button Button_Insert OnClick. @3-567A6180
        If CType(sender,Control).ID = "KEY_LEARNING_AREAButton_Insert" Then
            RedirectUrl = GetKEY_LEARNING_AREARedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form KEY_LEARNING_AREA BeforeInsert tail @2-85CED86D
    KEY_LEARNING_AREAParameters()
    KEY_LEARNING_AREALoadItemFromRequest(item, EnableValidation)
    If KEY_LEARNING_AREAOperations.AllowInsert Then
        ErrorFlag=(KEY_LEARNING_AREAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                KEY_LEARNING_AREAData.InsertItem(item)
            Catch ex As Exception
                KEY_LEARNING_AREAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form KEY_LEARNING_AREA BeforeInsert tail

'Record Form KEY_LEARNING_AREA AfterInsert tail  @2-BFCF6EFE
        End If
        ErrorFlag=(KEY_LEARNING_AREAErrors.Count > 0)
        If ErrorFlag Then
            KEY_LEARNING_AREAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form KEY_LEARNING_AREA AfterInsert tail 

'Record Form KEY_LEARNING_AREA Update Operation @2-A315FDA4

    Protected Sub KEY_LEARNING_AREA_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        KEY_LEARNING_AREAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form KEY_LEARNING_AREA Update Operation

'Button Button_Update OnClick. @4-AD221FF7
        If CType(sender,Control).ID = "KEY_LEARNING_AREAButton_Update" Then
            RedirectUrl = GetKEY_LEARNING_AREARedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form KEY_LEARNING_AREA Before Update tail @2-11FE71B5
        KEY_LEARNING_AREAParameters()
        KEY_LEARNING_AREALoadItemFromRequest(item, EnableValidation)
        If KEY_LEARNING_AREAOperations.AllowUpdate Then
        ErrorFlag = (KEY_LEARNING_AREAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                KEY_LEARNING_AREAData.UpdateItem(item)
            Catch ex As Exception
                KEY_LEARNING_AREAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form KEY_LEARNING_AREA Before Update tail

'Record Form KEY_LEARNING_AREA Update Operation tail @2-BFCF6EFE
        End If
        ErrorFlag=(KEY_LEARNING_AREAErrors.Count > 0)
        If ErrorFlag Then
            KEY_LEARNING_AREAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form KEY_LEARNING_AREA Update Operation tail

'Record Form KEY_LEARNING_AREA Delete Operation @2-367F486A
    Protected Sub KEY_LEARNING_AREA_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        KEY_LEARNING_AREAIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form KEY_LEARNING_AREA Delete Operation

'Button Button_Delete OnClick. @5-28BC8659
        If CType(sender,Control).ID = "KEY_LEARNING_AREAButton_Delete" Then
            RedirectUrl = GetKEY_LEARNING_AREARedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-7242D769
        KEY_LEARNING_AREAParameters()
        KEY_LEARNING_AREALoadItemFromRequest(item, EnableValidation)
        If KEY_LEARNING_AREAOperations.AllowDelete Then
        ErrorFlag = (KEY_LEARNING_AREAErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                KEY_LEARNING_AREAData.DeleteItem(item)
            Catch ex As Exception
                KEY_LEARNING_AREAErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-6B76818D
        End If
        If ErrorFlag Then
            KEY_LEARNING_AREAShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form KEY_LEARNING_AREA Cancel Operation @2-E4A64E07

    Protected Sub KEY_LEARNING_AREA_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
        KEY_LEARNING_AREAIsSubmitted = True
        Dim RedirectUrl As String = ""
        KEY_LEARNING_AREALoadItemFromRequest(item, True)
'End Record Form KEY_LEARNING_AREA Cancel Operation

'Record Form KEY_LEARNING_AREA Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form KEY_LEARNING_AREA Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-9A437784
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        KEY_LEARNING_AR_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        KEY_LEARNING_AREAData = New KEY_LEARNING_AREADataProvider()
        KEY_LEARNING_AREAOperations = New FormSupportedOperations(False, True, True, True, True)
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

