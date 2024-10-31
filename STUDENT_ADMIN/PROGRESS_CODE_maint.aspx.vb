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

Namespace DECV_PROD2007.PROGRESS_CODE_maint 'Namespace @1-3DC361EA

'Forms Definition @1-6C6C5DFD
Public Class [PROGRESS_CODE_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2DC34E4C
    Protected PROGRESS_CODEData As PROGRESS_CODEDataProvider
    Protected PROGRESS_CODEErrors As NameValueCollection = New NameValueCollection()
    Protected PROGRESS_CODEOperations As FormSupportedOperations
    Protected PROGRESS_CODEIsSubmitted As Boolean = False
    Protected PROGRESS_CODE_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-1BF0F696
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            PROGRESS_CODEShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form PROGRESS_CODE Parameters @2-74933FC4

    Protected Sub PROGRESS_CODEParameters()
        Dim item As new PROGRESS_CODEItem
        Try
            PROGRESS_CODEData.UrlPROGRESS_CODE = TextParameter.GetParam("PROGRESS_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            PROGRESS_CODEErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form PROGRESS_CODE Parameters

'Record Form PROGRESS_CODE Show method @2-1D1DF4AD
    Protected Sub PROGRESS_CODEShow()
        If PROGRESS_CODEOperations.None Then
            PROGRESS_CODEHolder.Visible = False
            Return
        End If
        Dim item As PROGRESS_CODEItem = PROGRESS_CODEItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not PROGRESS_CODEOperations.AllowRead
        PROGRESS_CODEErrors.Add(item.errors)
        If PROGRESS_CODEErrors.Count > 0 Then
            PROGRESS_CODEShowErrors()
            Return
        End If
'End Record Form PROGRESS_CODE Show method

'Record Form PROGRESS_CODE BeforeShow tail @2-EA6CE25F
        PROGRESS_CODEParameters()
        PROGRESS_CODEData.FillItem(item, IsInsertMode)
        PROGRESS_CODEHolder.DataBind()
        PROGRESS_CODEButton_Insert.Visible=IsInsertMode AndAlso PROGRESS_CODEOperations.AllowInsert
        PROGRESS_CODEButton_Update.Visible=Not (IsInsertMode) AndAlso PROGRESS_CODEOperations.AllowUpdate
        PROGRESS_CODEButton_Delete.Visible=Not (IsInsertMode) AndAlso PROGRESS_CODEOperations.AllowDelete
        PROGRESS_CODEPROGRESS_CODE_TITLE.Text=item.PROGRESS_CODE_TITLE.GetFormattedValue()
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            PROGRESS_CODESTATUS.Checked = True
        End If
        PROGRESS_CODELAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        PROGRESS_CODELAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form PROGRESS_CODE BeforeShow tail

'Record Form PROGRESS_CODE Show method tail @2-C8EA0891
        If PROGRESS_CODEErrors.Count > 0 Then
            PROGRESS_CODEShowErrors()
        End If
    End Sub
'End Record Form PROGRESS_CODE Show method tail

'Record Form PROGRESS_CODE LoadItemFromRequest method @2-F52D6CB4

    Protected Sub PROGRESS_CODELoadItemFromRequest(item As PROGRESS_CODEItem, ByVal EnableValidation As Boolean)
        item.PROGRESS_CODE_TITLE.IsEmpty = IsNothing(Request.Form(PROGRESS_CODEPROGRESS_CODE_TITLE.UniqueID))
        If ControlCustomValues("PROGRESS_CODEPROGRESS_CODE_TITLE") Is Nothing Then
            item.PROGRESS_CODE_TITLE.SetValue(PROGRESS_CODEPROGRESS_CODE_TITLE.Text)
        Else
            item.PROGRESS_CODE_TITLE.SetValue(ControlCustomValues("PROGRESS_CODEPROGRESS_CODE_TITLE"))
        End If
        If PROGRESS_CODESTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(PROGRESS_CODELAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("PROGRESS_CODELAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(PROGRESS_CODELAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("PROGRESS_CODELAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(PROGRESS_CODELAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("PROGRESS_CODELAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(PROGRESS_CODELAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("PROGRESS_CODELAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            PROGRESS_CODEErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(PROGRESS_CODEData)
        End If
        PROGRESS_CODEErrors.Add(item.errors)
    End Sub
'End Record Form PROGRESS_CODE LoadItemFromRequest method

'Record Form PROGRESS_CODE GetRedirectUrl method @2-BD9CC55E

    Protected Function GetPROGRESS_CODERedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "PROGRESS_CODE_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form PROGRESS_CODE GetRedirectUrl method

'Record Form PROGRESS_CODE ShowErrors method @2-26AD8C5D

    Protected Sub PROGRESS_CODEShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To PROGRESS_CODEErrors.Count - 1
        Select Case PROGRESS_CODEErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & PROGRESS_CODEErrors(i)
        End Select
        Next i
        PROGRESS_CODEError.Visible = True
        PROGRESS_CODEErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form PROGRESS_CODE ShowErrors method

'Record Form PROGRESS_CODE Insert Operation @2-DA71D21C

    Protected Sub PROGRESS_CODE_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        Dim ExecuteFlag As Boolean = True
        PROGRESS_CODEIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form PROGRESS_CODE Insert Operation

'Button Button_Insert OnClick. @3-289836E2
        If CType(sender,Control).ID = "PROGRESS_CODEButton_Insert" Then
            RedirectUrl = GetPROGRESS_CODERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form PROGRESS_CODE BeforeInsert tail @2-7FEEAC18
    PROGRESS_CODEParameters()
    PROGRESS_CODELoadItemFromRequest(item, EnableValidation)
    If PROGRESS_CODEOperations.AllowInsert Then
        ErrorFlag=(PROGRESS_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                PROGRESS_CODEData.InsertItem(item)
            Catch ex As Exception
                PROGRESS_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form PROGRESS_CODE BeforeInsert tail

'Record Form PROGRESS_CODE AfterInsert tail  @2-4C6E3E70
        End If
        ErrorFlag=(PROGRESS_CODEErrors.Count > 0)
        If ErrorFlag Then
            PROGRESS_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form PROGRESS_CODE AfterInsert tail 

'Record Form PROGRESS_CODE Update Operation @2-317D44DA

    Protected Sub PROGRESS_CODE_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        PROGRESS_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form PROGRESS_CODE Update Operation

'Button Button_Update OnClick. @4-AC50A87D
        If CType(sender,Control).ID = "PROGRESS_CODEButton_Update" Then
            RedirectUrl = GetPROGRESS_CODERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form PROGRESS_CODE Before Update tail @2-C5AF09A5
        PROGRESS_CODEParameters()
        PROGRESS_CODELoadItemFromRequest(item, EnableValidation)
        If PROGRESS_CODEOperations.AllowUpdate Then
        ErrorFlag = (PROGRESS_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                PROGRESS_CODEData.UpdateItem(item)
            Catch ex As Exception
                PROGRESS_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form PROGRESS_CODE Before Update tail

'Record Form PROGRESS_CODE Update Operation tail @2-4C6E3E70
        End If
        ErrorFlag=(PROGRESS_CODEErrors.Count > 0)
        If ErrorFlag Then
            PROGRESS_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form PROGRESS_CODE Update Operation tail

'Record Form PROGRESS_CODE Delete Operation @2-5A5BFBE0
    Protected Sub PROGRESS_CODE_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        PROGRESS_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form PROGRESS_CODE Delete Operation

'Button Button_Delete OnClick. @5-333A1C8B
        If CType(sender,Control).ID = "PROGRESS_CODEButton_Delete" Then
            RedirectUrl = GetPROGRESS_CODERedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-5E84FFDC
        PROGRESS_CODEParameters()
        PROGRESS_CODELoadItemFromRequest(item, EnableValidation)
        If PROGRESS_CODEOperations.AllowDelete Then
        ErrorFlag = (PROGRESS_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                PROGRESS_CODEData.DeleteItem(item)
            Catch ex As Exception
                PROGRESS_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-39652BB9
        End If
        If ErrorFlag Then
            PROGRESS_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form PROGRESS_CODE Cancel Operation @2-2EBEE625

    Protected Sub PROGRESS_CODE_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As PROGRESS_CODEItem = New PROGRESS_CODEItem()
        PROGRESS_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        PROGRESS_CODELoadItemFromRequest(item, True)
'End Record Form PROGRESS_CODE Cancel Operation

'Record Form PROGRESS_CODE Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form PROGRESS_CODE Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-E859582D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        PROGRESS_CODE_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        PROGRESS_CODEData = New PROGRESS_CODEDataProvider()
        PROGRESS_CODEOperations = New FormSupportedOperations(False, True, True, True, True)
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

