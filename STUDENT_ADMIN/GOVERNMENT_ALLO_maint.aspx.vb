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

Namespace DECV_PROD2007.GOVERNMENT_ALLO_maint 'Namespace @1-7A068540

'Forms Definition @1-275AD248
Public Class [GOVERNMENT_ALLO_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-62761229
    Protected GOVERNMENT_ALLOWANCEData As GOVERNMENT_ALLOWANCEDataProvider
    Protected GOVERNMENT_ALLOWANCEErrors As NameValueCollection = New NameValueCollection()
    Protected GOVERNMENT_ALLOWANCEOperations As FormSupportedOperations
    Protected GOVERNMENT_ALLOWANCEIsSubmitted As Boolean = False
    Protected GOVERNMENT_ALLO_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-9629CF9A
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            GOVERNMENT_ALLOWANCEShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form GOVERNMENT_ALLOWANCE Parameters @2-A91CCA87

    Protected Sub GOVERNMENT_ALLOWANCEParameters()
        Dim item As new GOVERNMENT_ALLOWANCEItem
        Try
            GOVERNMENT_ALLOWANCEData.UrlALLOWANCE_CODE = IntegerParameter.GetParam("ALLOWANCE_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            GOVERNMENT_ALLOWANCEErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE Parameters

'Record Form GOVERNMENT_ALLOWANCE Show method @2-4E1B9603
    Protected Sub GOVERNMENT_ALLOWANCEShow()
        If GOVERNMENT_ALLOWANCEOperations.None Then
            GOVERNMENT_ALLOWANCEHolder.Visible = False
            Return
        End If
        Dim item As GOVERNMENT_ALLOWANCEItem = GOVERNMENT_ALLOWANCEItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not GOVERNMENT_ALLOWANCEOperations.AllowRead
        GOVERNMENT_ALLOWANCEErrors.Add(item.errors)
        If GOVERNMENT_ALLOWANCEErrors.Count > 0 Then
            GOVERNMENT_ALLOWANCEShowErrors()
            Return
        End If
'End Record Form GOVERNMENT_ALLOWANCE Show method

'Record Form GOVERNMENT_ALLOWANCE BeforeShow tail @2-4D52B53F
        GOVERNMENT_ALLOWANCEParameters()
        GOVERNMENT_ALLOWANCEData.FillItem(item, IsInsertMode)
        GOVERNMENT_ALLOWANCEHolder.DataBind()
        GOVERNMENT_ALLOWANCEButton_Insert.Visible=IsInsertMode AndAlso GOVERNMENT_ALLOWANCEOperations.AllowInsert
        GOVERNMENT_ALLOWANCEButton_Update.Visible=Not (IsInsertMode) AndAlso GOVERNMENT_ALLOWANCEOperations.AllowUpdate
        GOVERNMENT_ALLOWANCEButton_Delete.Visible=Not (IsInsertMode) AndAlso GOVERNMENT_ALLOWANCEOperations.AllowDelete
        GOVERNMENT_ALLOWANCEALLOWANCE_TITLE.Text=item.ALLOWANCE_TITLE.GetFormattedValue()
        GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION.Text=item.ALLOWANCE_DESCRIPTION.GetFormattedValue()
        GOVERNMENT_ALLOWANCELAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        GOVERNMENT_ALLOWANCELAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form GOVERNMENT_ALLOWANCE BeforeShow tail

'Record Form GOVERNMENT_ALLOWANCE Show method tail @2-A881921A
        If GOVERNMENT_ALLOWANCEErrors.Count > 0 Then
            GOVERNMENT_ALLOWANCEShowErrors()
        End If
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE Show method tail

'Record Form GOVERNMENT_ALLOWANCE LoadItemFromRequest method @2-36B08917

    Protected Sub GOVERNMENT_ALLOWANCELoadItemFromRequest(item As GOVERNMENT_ALLOWANCEItem, ByVal EnableValidation As Boolean)
        item.ALLOWANCE_TITLE.IsEmpty = IsNothing(Request.Form(GOVERNMENT_ALLOWANCEALLOWANCE_TITLE.UniqueID))
        If ControlCustomValues("GOVERNMENT_ALLOWANCEALLOWANCE_TITLE") Is Nothing Then
            item.ALLOWANCE_TITLE.SetValue(GOVERNMENT_ALLOWANCEALLOWANCE_TITLE.Text)
        Else
            item.ALLOWANCE_TITLE.SetValue(ControlCustomValues("GOVERNMENT_ALLOWANCEALLOWANCE_TITLE"))
        End If
        item.ALLOWANCE_DESCRIPTION.IsEmpty = IsNothing(Request.Form(GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION.UniqueID))
        If ControlCustomValues("GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION") Is Nothing Then
            item.ALLOWANCE_DESCRIPTION.SetValue(GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION.Text)
        Else
            item.ALLOWANCE_DESCRIPTION.SetValue(ControlCustomValues("GOVERNMENT_ALLOWANCEALLOWANCE_DESCRIPTION"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(GOVERNMENT_ALLOWANCELAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("GOVERNMENT_ALLOWANCELAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(GOVERNMENT_ALLOWANCELAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("GOVERNMENT_ALLOWANCELAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(GOVERNMENT_ALLOWANCELAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("GOVERNMENT_ALLOWANCELAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(GOVERNMENT_ALLOWANCELAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("GOVERNMENT_ALLOWANCELAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            GOVERNMENT_ALLOWANCEErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(GOVERNMENT_ALLOWANCEData)
        End If
        GOVERNMENT_ALLOWANCEErrors.Add(item.errors)
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE LoadItemFromRequest method

'Record Form GOVERNMENT_ALLOWANCE GetRedirectUrl method @2-DF9334EC

    Protected Function GetGOVERNMENT_ALLOWANCERedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "GOVERNMENT_ALLO_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form GOVERNMENT_ALLOWANCE GetRedirectUrl method

'Record Form GOVERNMENT_ALLOWANCE ShowErrors method @2-5A59C0B0

    Protected Sub GOVERNMENT_ALLOWANCEShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To GOVERNMENT_ALLOWANCEErrors.Count - 1
        Select Case GOVERNMENT_ALLOWANCEErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & GOVERNMENT_ALLOWANCEErrors(i)
        End Select
        Next i
        GOVERNMENT_ALLOWANCEError.Visible = True
        GOVERNMENT_ALLOWANCEErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE ShowErrors method

'Record Form GOVERNMENT_ALLOWANCE Insert Operation @2-44784D65

    Protected Sub GOVERNMENT_ALLOWANCE_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        Dim ExecuteFlag As Boolean = True
        GOVERNMENT_ALLOWANCEIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GOVERNMENT_ALLOWANCE Insert Operation

'Button Button_Insert OnClick. @3-4AC3F7F8
        If CType(sender,Control).ID = "GOVERNMENT_ALLOWANCEButton_Insert" Then
            RedirectUrl = GetGOVERNMENT_ALLOWANCERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form GOVERNMENT_ALLOWANCE BeforeInsert tail @2-EF7B4856
    GOVERNMENT_ALLOWANCEParameters()
    GOVERNMENT_ALLOWANCELoadItemFromRequest(item, EnableValidation)
    If GOVERNMENT_ALLOWANCEOperations.AllowInsert Then
        ErrorFlag=(GOVERNMENT_ALLOWANCEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                GOVERNMENT_ALLOWANCEData.InsertItem(item)
            Catch ex As Exception
                GOVERNMENT_ALLOWANCEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form GOVERNMENT_ALLOWANCE BeforeInsert tail

'Record Form GOVERNMENT_ALLOWANCE AfterInsert tail  @2-295F989B
        End If
        ErrorFlag=(GOVERNMENT_ALLOWANCEErrors.Count > 0)
        If ErrorFlag Then
            GOVERNMENT_ALLOWANCEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE AfterInsert tail 

'Record Form GOVERNMENT_ALLOWANCE Update Operation @2-81657900

    Protected Sub GOVERNMENT_ALLOWANCE_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        GOVERNMENT_ALLOWANCEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form GOVERNMENT_ALLOWANCE Update Operation

'Button Button_Update OnClick. @4-CF710468
        If CType(sender,Control).ID = "GOVERNMENT_ALLOWANCEButton_Update" Then
            RedirectUrl = GetGOVERNMENT_ALLOWANCERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form GOVERNMENT_ALLOWANCE Before Update tail @2-BA7C0B7D
        GOVERNMENT_ALLOWANCEParameters()
        GOVERNMENT_ALLOWANCELoadItemFromRequest(item, EnableValidation)
        If GOVERNMENT_ALLOWANCEOperations.AllowUpdate Then
        ErrorFlag = (GOVERNMENT_ALLOWANCEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                GOVERNMENT_ALLOWANCEData.UpdateItem(item)
            Catch ex As Exception
                GOVERNMENT_ALLOWANCEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form GOVERNMENT_ALLOWANCE Before Update tail

'Record Form GOVERNMENT_ALLOWANCE Update Operation tail @2-295F989B
        End If
        ErrorFlag=(GOVERNMENT_ALLOWANCEErrors.Count > 0)
        If ErrorFlag Then
            GOVERNMENT_ALLOWANCEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE Update Operation tail

'Record Form GOVERNMENT_ALLOWANCE Delete Operation @2-87C7A4C3
    Protected Sub GOVERNMENT_ALLOWANCE_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        GOVERNMENT_ALLOWANCEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form GOVERNMENT_ALLOWANCE Delete Operation

'Button Button_Delete OnClick. @5-45CEF59F
        If CType(sender,Control).ID = "GOVERNMENT_ALLOWANCEButton_Delete" Then
            RedirectUrl = GetGOVERNMENT_ALLOWANCERedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-70C17B33
        GOVERNMENT_ALLOWANCEParameters()
        GOVERNMENT_ALLOWANCELoadItemFromRequest(item, EnableValidation)
        If GOVERNMENT_ALLOWANCEOperations.AllowDelete Then
        ErrorFlag = (GOVERNMENT_ALLOWANCEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                GOVERNMENT_ALLOWANCEData.DeleteItem(item)
            Catch ex As Exception
                GOVERNMENT_ALLOWANCEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-8F93D45E
        End If
        If ErrorFlag Then
            GOVERNMENT_ALLOWANCEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form GOVERNMENT_ALLOWANCE Cancel Operation @2-737FCADE

    Protected Sub GOVERNMENT_ALLOWANCE_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
        GOVERNMENT_ALLOWANCEIsSubmitted = True
        Dim RedirectUrl As String = ""
        GOVERNMENT_ALLOWANCELoadItemFromRequest(item, True)
'End Record Form GOVERNMENT_ALLOWANCE Cancel Operation

'Record Form GOVERNMENT_ALLOWANCE Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form GOVERNMENT_ALLOWANCE Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-32D546FD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        GOVERNMENT_ALLO_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        GOVERNMENT_ALLOWANCEData = New GOVERNMENT_ALLOWANCEDataProvider()
        GOVERNMENT_ALLOWANCEOperations = New FormSupportedOperations(False, True, True, True, True)
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

