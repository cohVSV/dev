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

Namespace DECV_PROD2007.UploadFile 'Namespace @1-09503904

'Forms Definition @1-44D7BA0E
Public Class [UploadFilePage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1E89E002
    Protected NewRecord1Data As NewRecord1DataProvider
    Protected NewRecord1Errors As NameValueCollection = New NameValueCollection()
    Protected NewRecord1Operations As FormSupportedOperations
    Protected NewRecord1IsSubmitted As Boolean = False
    Protected UploadFileContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-3B88DC46
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            NewRecord1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form NewRecord1 Parameters @2-F5D5F81C

    Protected Sub NewRecord1Parameters()
        Dim item As new NewRecord1Item
        Try
        Catch e As Exception
            NewRecord1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form NewRecord1 Parameters

'Record Form NewRecord1 Show method @2-9BE48317
    Protected Sub NewRecord1Show()
        If NewRecord1Operations.None Then
            NewRecord1Holder.Visible = False
            Return
        End If
        Dim item As NewRecord1Item = NewRecord1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not NewRecord1Operations.AllowRead
        NewRecord1Errors.Add(item.errors)
        If NewRecord1Errors.Count > 0 Then
            NewRecord1ShowErrors()
            Return
        End If
'End Record Form NewRecord1 Show method

'Record Form NewRecord1 BeforeShow tail @2-F2F4D53C
        NewRecord1Parameters()
        NewRecord1Data.FillItem(item, IsInsertMode)
        NewRecord1Holder.DataBind()
        NewRecord1Button_Insert.Visible=IsInsertMode AndAlso NewRecord1Operations.AllowInsert
        NewRecord1Button_Update.Visible=Not (IsInsertMode) AndAlso NewRecord1Operations.AllowUpdate
        NewRecord1Button_Delete.Visible=Not (IsInsertMode) AndAlso NewRecord1Operations.AllowDelete
        Try
            NewRecord1upload1.TemporaryFolder = "%TEMP"
        Catch ex As System.IO.DirectoryNotFoundException
            NewRecord1Errors.Add("upload1",String.Format(Resources.strings.CCS_TempFolderNotFound,"upload1"))
        Catch ex As System.Security.SecurityException
            NewRecord1Errors.Add("upload1",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"upload1"))
        End Try
        NewRecord1upload1.FileSizeLimit = 100000
        Try
            NewRecord1upload1.Text=item.upload1.GetFormattedValue()
        Catch ex As System.IO.FileNotFoundException
            Dim FileName As String = item.upload1.GetFormattedValue()
            item.errors.Add("upload1",String.Format(Resources.strings.CCS_FileNotFound,Item.upload1.GetFormattedValue(),"upload1"))
        End Try
'End Record Form NewRecord1 BeforeShow tail

'Record Form NewRecord1 Show method tail @2-057F9BB0
        If NewRecord1Errors.Count > 0 Then
            NewRecord1ShowErrors()
        End If
    End Sub
'End Record Form NewRecord1 Show method tail

'Record Form NewRecord1 LoadItemFromRequest method @2-92795A03

    Protected Sub NewRecord1LoadItemFromRequest(item As NewRecord1Item, ByVal EnableValidation As Boolean)
        Try
            NewRecord1upload1.ValidateFile()
            item.upload1.SetValue(NewRecord1upload1.Text)
        Catch ex As InvalidOperationException 
            If ex.Message = "The file type is not allowed." Then
                NewRecord1Errors.Add("upload1",String.Format(Resources.strings.CCS_WrongType,"upload1"))
            End If
            If ex.Message = "The file is too large." Then
                NewRecord1Errors.Add("upload1",String.Format(Resources.strings.CCS_LargeFile,"upload1"))
            End If
        End Try
        item.upload1.IsEmpty = NewRecord1upload1.IsEmpty
        If EnableValidation Then
            item.Validate(NewRecord1Data)
        End If
        NewRecord1Errors.Add(item.errors)
    End Sub
'End Record Form NewRecord1 LoadItemFromRequest method

'Record Form NewRecord1 GetRedirectUrl method @2-A0F57816

    Protected Function GetNewRecord1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form NewRecord1 GetRedirectUrl method

'Record Form NewRecord1 ShowErrors method @2-7E438983

    Protected Sub NewRecord1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To NewRecord1Errors.Count - 1
        Select Case NewRecord1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & NewRecord1Errors(i)
        End Select
        Next i
        NewRecord1Error.Visible = True
        NewRecord1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form NewRecord1 ShowErrors method

'Record Form NewRecord1 Insert Operation @2-D9315C37

    Protected Sub NewRecord1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        NewRecord1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewRecord1 Insert Operation

'Button Button_Insert OnClick. @4-9D14A7FE
        If CType(sender,Control).ID = "NewRecord1Button_Insert" Then
            RedirectUrl = GetNewRecord1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @4-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form NewRecord1 BeforeInsert tail @2-9F2E905D
    NewRecord1Parameters()
    NewRecord1LoadItemFromRequest(item, EnableValidation)
'End Record Form NewRecord1 BeforeInsert tail

'Record Form NewRecord1 AfterInsert tail  @2-FCF02A3F
        ErrorFlag=(NewRecord1Errors.Count > 0)
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewRecord1 AfterInsert tail 

'Record Form NewRecord1 Update Operation @2-D38BB37D

    Protected Sub NewRecord1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewRecord1 Update Operation

'Button Button_Update OnClick. @5-2B75EB7C
        If CType(sender,Control).ID = "NewRecord1Button_Update" Then
            RedirectUrl = GetNewRecord1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form NewRecord1 Before Update tail @2-9F2E905D
        NewRecord1Parameters()
        NewRecord1LoadItemFromRequest(item, EnableValidation)
'End Record Form NewRecord1 Before Update tail

'Record Form NewRecord1 Update Operation tail @2-ABCE9298
            If Not(ErrorFlag) Then
                NewRecord1upload1.SaveFile()
            End If
        ErrorFlag=(NewRecord1Errors.Count > 0)
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewRecord1 Update Operation tail

'Record Form NewRecord1 Delete Operation @2-5A13493F
    Protected Sub NewRecord1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As NewRecord1Item = New NewRecord1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form NewRecord1 Delete Operation

'Button Button_Delete OnClick. @6-A64F5B1A
        If CType(sender,Control).ID = "NewRecord1Button_Delete" Then
            RedirectUrl = GetNewRecord1RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @6-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-9F2E905D
        NewRecord1Parameters()
        NewRecord1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-0BB9E895
            If Not(ErrorFlag) Then
                NewRecord1upload1.DeleteFile()
            End If
        If ErrorFlag Then
            NewRecord1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form NewRecord1 Cancel Operation @2-95D05D98

    Protected Sub NewRecord1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewRecord1Item = New NewRecord1Item()
        NewRecord1IsSubmitted = True
        Dim RedirectUrl As String = ""
        NewRecord1LoadItemFromRequest(item, True)
'End Record Form NewRecord1 Cancel Operation

'Record Form NewRecord1 Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form NewRecord1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-8679E2DC
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        UploadFileContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        NewRecord1Data = New NewRecord1DataProvider()
        NewRecord1Operations = New FormSupportedOperations(False, True, True, True, True)
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

