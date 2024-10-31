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

Namespace DECV_PROD2007.LANGUAGE_maint 'Namespace @1-2B78B408

'Forms Definition @1-03635DB4
Public Class [LANGUAGE_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2D022514
    Protected LANGUAGEData As LANGUAGEDataProvider
    Protected LANGUAGEErrors As NameValueCollection = New NameValueCollection()
    Protected LANGUAGEOperations As FormSupportedOperations
    Protected LANGUAGEIsSubmitted As Boolean = False
    Protected LANGUAGE_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-81F33701
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            LANGUAGEShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form LANGUAGE Parameters @2-60193449

    Protected Sub LANGUAGEParameters()
        Dim item As new LANGUAGEItem
        Try
            LANGUAGEData.UrlLANG_CODE = IntegerParameter.GetParam("LANG_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            LANGUAGEErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form LANGUAGE Parameters

'Record Form LANGUAGE Show method @2-9B173525
    Protected Sub LANGUAGEShow()
        If LANGUAGEOperations.None Then
            LANGUAGEHolder.Visible = False
            Return
        End If
        Dim item As LANGUAGEItem = LANGUAGEItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not LANGUAGEOperations.AllowRead
        LANGUAGEErrors.Add(item.errors)
        If LANGUAGEErrors.Count > 0 Then
            LANGUAGEShowErrors()
            Return
        End If
'End Record Form LANGUAGE Show method

'Record Form LANGUAGE BeforeShow tail @2-8C23319B
        LANGUAGEParameters()
        LANGUAGEData.FillItem(item, IsInsertMode)
        LANGUAGEHolder.DataBind()
        LANGUAGEButton_Insert.Visible=IsInsertMode AndAlso LANGUAGEOperations.AllowInsert
        LANGUAGEButton_Update.Visible=Not (IsInsertMode) AndAlso LANGUAGEOperations.AllowUpdate
        LANGUAGEButton_Delete.Visible=Not (IsInsertMode) AndAlso LANGUAGEOperations.AllowDelete
        LANGUAGELANG_DESCRIPTION.Text=item.LANG_DESCRIPTION.GetFormattedValue()
        LANGUAGELAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        LANGUAGELAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        LANGUAGElabel_Last_altered_by.Text = Server.HtmlEncode(item.label_Last_altered_by.GetFormattedValue()).Replace(vbCrLf,"<br>")
        LANGUAGElabel_last_altered_date.Text = Server.HtmlEncode(item.label_last_altered_date.GetFormattedValue()).Replace(vbCrLf,"<br>")
        LANGUAGELANG_CODE.Text=item.LANG_CODE.GetFormattedValue()
'End Record Form LANGUAGE BeforeShow tail

'TextBox LANG_DESCRIPTION Event BeforeShow. Action Retrieve Value for Control @19-30BF2758
            LANGUAGELANG_DESCRIPTION.Text = (New TextField("", (LANGUAGELANG_DESCRIPTION.Text.Trim()))).GetFormattedValue()
'End TextBox LANG_DESCRIPTION Event BeforeShow. Action Retrieve Value for Control

'Record Form LANGUAGE Show method tail @2-53AB50FE
        If LANGUAGEErrors.Count > 0 Then
            LANGUAGEShowErrors()
        End If
    End Sub
'End Record Form LANGUAGE Show method tail

'Record Form LANGUAGE LoadItemFromRequest method @2-362AA741

    Protected Sub LANGUAGELoadItemFromRequest(item As LANGUAGEItem, ByVal EnableValidation As Boolean)
        item.LANG_DESCRIPTION.IsEmpty = IsNothing(Request.Form(LANGUAGELANG_DESCRIPTION.UniqueID))
        If ControlCustomValues("LANGUAGELANG_DESCRIPTION") Is Nothing Then
            item.LANG_DESCRIPTION.SetValue(LANGUAGELANG_DESCRIPTION.Text)
        Else
            item.LANG_DESCRIPTION.SetValue(ControlCustomValues("LANGUAGELANG_DESCRIPTION"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(LANGUAGELAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(LANGUAGELAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(LANGUAGELAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(LANGUAGELAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            LANGUAGEErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","GeneralDate"))
        End Try
        Try
        item.LANG_CODE.IsEmpty = IsNothing(Request.Form(LANGUAGELANG_CODE.UniqueID))
        If ControlCustomValues("LANGUAGELANG_CODE") Is Nothing Then
            item.LANG_CODE.SetValue(LANGUAGELANG_CODE.Text)
        Else
            item.LANG_CODE.SetValue(ControlCustomValues("LANGUAGELANG_CODE"))
        End If
        Catch ae As ArgumentException
            LANGUAGEErrors.Add("LANG_CODE",String.Format(Resources.strings.CCS_IncorrectValue,"Language Code"))
        End Try
        If EnableValidation Then
            item.Validate(LANGUAGEData)
        End If
        LANGUAGEErrors.Add(item.errors)
    End Sub
'End Record Form LANGUAGE LoadItemFromRequest method

'Record Form LANGUAGE GetRedirectUrl method @2-F07D4F50

    Protected Function GetLANGUAGERedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "LANGUAGE_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form LANGUAGE GetRedirectUrl method

'Record Form LANGUAGE ShowErrors method @2-9BFC5359

    Protected Sub LANGUAGEShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To LANGUAGEErrors.Count - 1
        Select Case LANGUAGEErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & LANGUAGEErrors(i)
        End Select
        Next i
        LANGUAGEError.Visible = True
        LANGUAGEErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form LANGUAGE ShowErrors method

'Record Form LANGUAGE Insert Operation @2-4F325185

    Protected Sub LANGUAGE_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        Dim ExecuteFlag As Boolean = True
        LANGUAGEIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form LANGUAGE Insert Operation

'Button Button_Insert OnClick. @3-C4E193AB
        If CType(sender,Control).ID = "LANGUAGEButton_Insert" Then
            RedirectUrl = GetLANGUAGERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form LANGUAGE BeforeInsert tail @2-C7B90D4D
    LANGUAGEParameters()
    LANGUAGELoadItemFromRequest(item, EnableValidation)
    If LANGUAGEOperations.AllowInsert Then
        ErrorFlag=(LANGUAGEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                LANGUAGEData.InsertItem(item)
            Catch ex As Exception
                LANGUAGEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form LANGUAGE BeforeInsert tail

'Record Form LANGUAGE AfterInsert tail  @2-D3CF0772
        End If
        ErrorFlag=(LANGUAGEErrors.Count > 0)
        If ErrorFlag Then
            LANGUAGEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form LANGUAGE AfterInsert tail 

'Record Form LANGUAGE Update Operation @2-82E275F2

    Protected Sub LANGUAGE_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        LANGUAGEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form LANGUAGE Update Operation

'Button Button_Update OnClick. @4-C89AB5AF
        If CType(sender,Control).ID = "LANGUAGEButton_Update" Then
            RedirectUrl = GetLANGUAGERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record LANGUAGE Event BeforeUpdate. Action Retrieve Value for Control @17-080AB64E
        LANGUAGELAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserID.tostring()))).GetFormattedValue()
'End Record LANGUAGE Event BeforeUpdate. Action Retrieve Value for Control

'Record LANGUAGE Event BeforeUpdate. Action Retrieve Value for Control @18-89C69299
        LANGUAGELAST_ALTERED_DATE.Value = (New DateField("G", (Now()))).GetFormattedValue()
'End Record LANGUAGE Event BeforeUpdate. Action Retrieve Value for Control

'Record Form LANGUAGE Before Update tail @2-7D6A334F
        LANGUAGEParameters()
        LANGUAGELoadItemFromRequest(item, EnableValidation)
        If LANGUAGEOperations.AllowUpdate Then
        ErrorFlag = (LANGUAGEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                LANGUAGEData.UpdateItem(item)
            Catch ex As Exception
                LANGUAGEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form LANGUAGE Before Update tail

'Record Form LANGUAGE Update Operation tail @2-D3CF0772
        End If
        ErrorFlag=(LANGUAGEErrors.Count > 0)
        If ErrorFlag Then
            LANGUAGEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form LANGUAGE Update Operation tail

'Record Form LANGUAGE Delete Operation @2-7E0EF128
    Protected Sub LANGUAGE_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        LANGUAGEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form LANGUAGE Delete Operation

'Button Button_Delete OnClick. @5-FA8AA596
        If CType(sender,Control).ID = "LANGUAGEButton_Delete" Then
            RedirectUrl = GetLANGUAGERedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-EFFEA90F
        LANGUAGEParameters()
        LANGUAGELoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-9C7483F8
        If ErrorFlag Then
            LANGUAGEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form LANGUAGE Cancel Operation @2-58BDF7F1

    Protected Sub LANGUAGE_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        LANGUAGEIsSubmitted = True
        Dim RedirectUrl As String = ""
        LANGUAGELoadItemFromRequest(item, False)
'End Record Form LANGUAGE Cancel Operation

'Button Button_Cancel OnClick. @20-9D567431
    If CType(sender,Control).ID = "LANGUAGEButton_Cancel" Then
        RedirectUrl = GetLANGUAGERedirectUrl("LANGUAGE_list.aspx", "LANG_CODE")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @20-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form LANGUAGE Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form LANGUAGE Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-39ACCA85
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        LANGUAGE_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        LANGUAGEData = New LANGUAGEDataProvider()
        LANGUAGEOperations = New FormSupportedOperations(False, True, True, True, False)
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

