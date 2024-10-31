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

Namespace DECV_PROD2007.TXN_CODE_maint 'Namespace @1-35C93230

'Forms Definition @1-5D6E3432
Public Class [TXN_CODE_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-566D420C
    Protected TXN_CODEData As TXN_CODEDataProvider
    Protected TXN_CODEErrors As NameValueCollection = New NameValueCollection()
    Protected TXN_CODEOperations As FormSupportedOperations
    Protected TXN_CODEIsSubmitted As Boolean = False
    Protected TXN_CODE_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-C84D8659
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            TXN_CODEShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form TXN_CODE Parameters @2-70CAB6E4

    Protected Sub TXN_CODEParameters()
        Dim item As new TXN_CODEItem
        Try
            TXN_CODEData.UrlTXN_CODE = TextParameter.GetParam("TXN_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            TXN_CODEErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form TXN_CODE Parameters

'Record Form TXN_CODE Show method @2-C53628EE
    Protected Sub TXN_CODEShow()
        If TXN_CODEOperations.None Then
            TXN_CODEHolder.Visible = False
            Return
        End If
        Dim item As TXN_CODEItem = TXN_CODEItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TXN_CODEOperations.AllowRead
        TXN_CODEErrors.Add(item.errors)
        If TXN_CODEErrors.Count > 0 Then
            TXN_CODEShowErrors()
            Return
        End If
'End Record Form TXN_CODE Show method

'Record Form TXN_CODE BeforeShow tail @2-35FA2E50
        TXN_CODEParameters()
        TXN_CODEData.FillItem(item, IsInsertMode)
        TXN_CODEHolder.DataBind()
        TXN_CODEButton_Insert.Visible=IsInsertMode AndAlso TXN_CODEOperations.AllowInsert
        TXN_CODEButton_Update.Visible=Not (IsInsertMode) AndAlso TXN_CODEOperations.AllowUpdate
        TXN_CODEButton_Delete.Visible=Not (IsInsertMode) AndAlso TXN_CODEOperations.AllowDelete
        TXN_CODETXN_TYPE.Text=item.TXN_TYPE.GetFormattedValue()
        TXN_CODECR_DR_FLAG.Text=item.CR_DR_FLAG.GetFormattedValue()
        TXN_CODEDESCRIPTION.Text=item.DESCRIPTION.GetFormattedValue()
        TXN_CODELAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        TXN_CODELAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form TXN_CODE BeforeShow tail

'Record Form TXN_CODE Show method tail @2-EAB64A94
        If TXN_CODEErrors.Count > 0 Then
            TXN_CODEShowErrors()
        End If
    End Sub
'End Record Form TXN_CODE Show method tail

'Record Form TXN_CODE LoadItemFromRequest method @2-9BE06769

    Protected Sub TXN_CODELoadItemFromRequest(item As TXN_CODEItem, ByVal EnableValidation As Boolean)
        item.TXN_TYPE.IsEmpty = IsNothing(Request.Form(TXN_CODETXN_TYPE.UniqueID))
        If ControlCustomValues("TXN_CODETXN_TYPE") Is Nothing Then
            item.TXN_TYPE.SetValue(TXN_CODETXN_TYPE.Text)
        Else
            item.TXN_TYPE.SetValue(ControlCustomValues("TXN_CODETXN_TYPE"))
        End If
        item.CR_DR_FLAG.IsEmpty = IsNothing(Request.Form(TXN_CODECR_DR_FLAG.UniqueID))
        If ControlCustomValues("TXN_CODECR_DR_FLAG") Is Nothing Then
            item.CR_DR_FLAG.SetValue(TXN_CODECR_DR_FLAG.Text)
        Else
            item.CR_DR_FLAG.SetValue(ControlCustomValues("TXN_CODECR_DR_FLAG"))
        End If
        item.DESCRIPTION.IsEmpty = IsNothing(Request.Form(TXN_CODEDESCRIPTION.UniqueID))
        If ControlCustomValues("TXN_CODEDESCRIPTION") Is Nothing Then
            item.DESCRIPTION.SetValue(TXN_CODEDESCRIPTION.Text)
        Else
            item.DESCRIPTION.SetValue(ControlCustomValues("TXN_CODEDESCRIPTION"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(TXN_CODELAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("TXN_CODELAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(TXN_CODELAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("TXN_CODELAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(TXN_CODELAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("TXN_CODELAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(TXN_CODELAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("TXN_CODELAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            TXN_CODEErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(TXN_CODEData)
        End If
        TXN_CODEErrors.Add(item.errors)
    End Sub
'End Record Form TXN_CODE LoadItemFromRequest method

'Record Form TXN_CODE GetRedirectUrl method @2-11883302

    Protected Function GetTXN_CODERedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "TXN_CODE_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form TXN_CODE GetRedirectUrl method

'Record Form TXN_CODE ShowErrors method @2-E2AB4436

    Protected Sub TXN_CODEShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To TXN_CODEErrors.Count - 1
        Select Case TXN_CODEErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & TXN_CODEErrors(i)
        End Select
        Next i
        TXN_CODEError.Visible = True
        TXN_CODEErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form TXN_CODE ShowErrors method

'Record Form TXN_CODE Insert Operation @2-F09F67DE

    Protected Sub TXN_CODE_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        Dim ExecuteFlag As Boolean = True
        TXN_CODEIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN_CODE Insert Operation

'Button Button_Insert OnClick. @3-D5FE6BB2
        If CType(sender,Control).ID = "TXN_CODEButton_Insert" Then
            RedirectUrl = GetTXN_CODERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form TXN_CODE BeforeInsert tail @2-68C2CD17
    TXN_CODEParameters()
    TXN_CODELoadItemFromRequest(item, EnableValidation)
    If TXN_CODEOperations.AllowInsert Then
        ErrorFlag=(TXN_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN_CODEData.InsertItem(item)
            Catch ex As Exception
                TXN_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form TXN_CODE BeforeInsert tail

'Record Form TXN_CODE AfterInsert tail  @2-B5201408
        End If
        ErrorFlag=(TXN_CODEErrors.Count > 0)
        If ErrorFlag Then
            TXN_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN_CODE AfterInsert tail 

'Record Form TXN_CODE Update Operation @2-DBB28260

    Protected Sub TXN_CODE_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        TXN_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN_CODE Update Operation

'Button Button_Update OnClick. @4-D9854DB6
        If CType(sender,Control).ID = "TXN_CODEButton_Update" Then
            RedirectUrl = GetTXN_CODERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form TXN_CODE Before Update tail @2-D211F315
        TXN_CODEParameters()
        TXN_CODELoadItemFromRequest(item, EnableValidation)
        If TXN_CODEOperations.AllowUpdate Then
        ErrorFlag = (TXN_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN_CODEData.UpdateItem(item)
            Catch ex As Exception
                TXN_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form TXN_CODE Before Update tail

'Record Form TXN_CODE Update Operation tail @2-B5201408
        End If
        ErrorFlag=(TXN_CODEErrors.Count > 0)
        If ErrorFlag Then
            TXN_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN_CODE Update Operation tail

'Record Form TXN_CODE Delete Operation @2-B71B0CDD
    Protected Sub TXN_CODE_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        TXN_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form TXN_CODE Delete Operation

'Button Button_Delete OnClick. @5-9EF012AE
        If CType(sender,Control).ID = "TXN_CODEButton_Delete" Then
            RedirectUrl = GetTXN_CODERedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-08DFDCB3
        TXN_CODEParameters()
        TXN_CODELoadItemFromRequest(item, EnableValidation)
        If TXN_CODEOperations.AllowDelete Then
        ErrorFlag = (TXN_CODEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN_CODEData.DeleteItem(item)
            Catch ex As Exception
                TXN_CODEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-C1FA9AFA
        End If
        If ErrorFlag Then
            TXN_CODEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form TXN_CODE Cancel Operation @2-27C5D03D

    Protected Sub TXN_CODE_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        TXN_CODEIsSubmitted = True
        Dim RedirectUrl As String = ""
        TXN_CODELoadItemFromRequest(item, True)
'End Record Form TXN_CODE Cancel Operation

'Record Form TXN_CODE Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form TXN_CODE Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-48737444
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        TXN_CODE_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        TXN_CODEData = New TXN_CODEDataProvider()
        TXN_CODEOperations = New FormSupportedOperations(False, True, True, True, True)
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

