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

Namespace DECV_PROD2007.COUNTRY_OF_BIRT_maint 'Namespace @1-3A298D3E

'Forms Definition @1-1AE73C31
Public Class [COUNTRY_OF_BIRT_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F408F0BC
    Protected COUNTRY_OF_BIRTHData As COUNTRY_OF_BIRTHDataProvider
    Protected COUNTRY_OF_BIRTHErrors As NameValueCollection = New NameValueCollection()
    Protected COUNTRY_OF_BIRTHOperations As FormSupportedOperations
    Protected COUNTRY_OF_BIRTHIsSubmitted As Boolean = False
    Protected COUNTRY_OF_BIRT_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A4BA0F0E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            COUNTRY_OF_BIRTHShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form COUNTRY_OF_BIRTH Parameters @2-6765E316

    Protected Sub COUNTRY_OF_BIRTHParameters()
        Dim item As new COUNTRY_OF_BIRTHItem
        Try
            COUNTRY_OF_BIRTHData.UrlCOUNTRY_ID = IntegerParameter.GetParam("COUNTRY_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            COUNTRY_OF_BIRTHErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form COUNTRY_OF_BIRTH Parameters

'Record Form COUNTRY_OF_BIRTH Show method @2-BB5DFB28
    Protected Sub COUNTRY_OF_BIRTHShow()
        If COUNTRY_OF_BIRTHOperations.None Then
            COUNTRY_OF_BIRTHHolder.Visible = False
            Return
        End If
        Dim item As COUNTRY_OF_BIRTHItem = COUNTRY_OF_BIRTHItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not COUNTRY_OF_BIRTHOperations.AllowRead
        COUNTRY_OF_BIRTHErrors.Add(item.errors)
        If COUNTRY_OF_BIRTHErrors.Count > 0 Then
            COUNTRY_OF_BIRTHShowErrors()
            Return
        End If
'End Record Form COUNTRY_OF_BIRTH Show method

'Record Form COUNTRY_OF_BIRTH BeforeShow tail @2-C49362EB
        COUNTRY_OF_BIRTHParameters()
        COUNTRY_OF_BIRTHData.FillItem(item, IsInsertMode)
        COUNTRY_OF_BIRTHHolder.DataBind()
        COUNTRY_OF_BIRTHButton_Insert.Visible=IsInsertMode AndAlso COUNTRY_OF_BIRTHOperations.AllowInsert
        COUNTRY_OF_BIRTHButton_Update.Visible=Not (IsInsertMode) AndAlso COUNTRY_OF_BIRTHOperations.AllowUpdate
        COUNTRY_OF_BIRTHButton_Delete.Visible=Not (IsInsertMode) AndAlso COUNTRY_OF_BIRTHOperations.AllowDelete
        COUNTRY_OF_BIRTHCOUNTRY_NAME.Text=item.COUNTRY_NAME.GetFormattedValue()
        COUNTRY_OF_BIRTHLAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        COUNTRY_OF_BIRTHLAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form COUNTRY_OF_BIRTH BeforeShow tail

'Record Form COUNTRY_OF_BIRTH Show method tail @2-8BFE91D6
        If COUNTRY_OF_BIRTHErrors.Count > 0 Then
            COUNTRY_OF_BIRTHShowErrors()
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTH Show method tail

'Record Form COUNTRY_OF_BIRTH LoadItemFromRequest method @2-4F2946BF

    Protected Sub COUNTRY_OF_BIRTHLoadItemFromRequest(item As COUNTRY_OF_BIRTHItem, ByVal EnableValidation As Boolean)
        item.COUNTRY_NAME.IsEmpty = IsNothing(Request.Form(COUNTRY_OF_BIRTHCOUNTRY_NAME.UniqueID))
        If ControlCustomValues("COUNTRY_OF_BIRTHCOUNTRY_NAME") Is Nothing Then
            item.COUNTRY_NAME.SetValue(COUNTRY_OF_BIRTHCOUNTRY_NAME.Text)
        Else
            item.COUNTRY_NAME.SetValue(ControlCustomValues("COUNTRY_OF_BIRTHCOUNTRY_NAME"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(COUNTRY_OF_BIRTHLAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("COUNTRY_OF_BIRTHLAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(COUNTRY_OF_BIRTHLAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("COUNTRY_OF_BIRTHLAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(COUNTRY_OF_BIRTHLAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("COUNTRY_OF_BIRTHLAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(COUNTRY_OF_BIRTHLAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("COUNTRY_OF_BIRTHLAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            COUNTRY_OF_BIRTHErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(COUNTRY_OF_BIRTHData)
        End If
        COUNTRY_OF_BIRTHErrors.Add(item.errors)
    End Sub
'End Record Form COUNTRY_OF_BIRTH LoadItemFromRequest method

'Record Form COUNTRY_OF_BIRTH GetRedirectUrl method @2-FFE3F17D

    Protected Function GetCOUNTRY_OF_BIRTHRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "COUNTRY_OF_BIRT_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form COUNTRY_OF_BIRTH GetRedirectUrl method

'Record Form COUNTRY_OF_BIRTH ShowErrors method @2-D239C850

    Protected Sub COUNTRY_OF_BIRTHShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To COUNTRY_OF_BIRTHErrors.Count - 1
        Select Case COUNTRY_OF_BIRTHErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & COUNTRY_OF_BIRTHErrors(i)
        End Select
        Next i
        COUNTRY_OF_BIRTHError.Visible = True
        COUNTRY_OF_BIRTHErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form COUNTRY_OF_BIRTH ShowErrors method

'Record Form COUNTRY_OF_BIRTH Insert Operation @2-7B34A7D5

    Protected Sub COUNTRY_OF_BIRTH_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        Dim ExecuteFlag As Boolean = True
        COUNTRY_OF_BIRTHIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COUNTRY_OF_BIRTH Insert Operation

'Button Button_Insert OnClick. @3-01C2A3EC
        If CType(sender,Control).ID = "COUNTRY_OF_BIRTHButton_Insert" Then
            RedirectUrl = GetCOUNTRY_OF_BIRTHRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form COUNTRY_OF_BIRTH BeforeInsert tail @2-737FBEB8
    COUNTRY_OF_BIRTHParameters()
    COUNTRY_OF_BIRTHLoadItemFromRequest(item, EnableValidation)
    If COUNTRY_OF_BIRTHOperations.AllowInsert Then
        ErrorFlag=(COUNTRY_OF_BIRTHErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                COUNTRY_OF_BIRTHData.InsertItem(item)
            Catch ex As Exception
                COUNTRY_OF_BIRTHErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form COUNTRY_OF_BIRTH BeforeInsert tail

'Record Form COUNTRY_OF_BIRTH AfterInsert tail  @2-0F792F85
        End If
        ErrorFlag=(COUNTRY_OF_BIRTHErrors.Count > 0)
        If ErrorFlag Then
            COUNTRY_OF_BIRTHShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTH AfterInsert tail 

'Record Form COUNTRY_OF_BIRTH Update Operation @2-F3B3FE7C

    Protected Sub COUNTRY_OF_BIRTH_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        COUNTRY_OF_BIRTHIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COUNTRY_OF_BIRTH Update Operation

'Button Button_Update OnClick. @4-8DF0B1B3
        If CType(sender,Control).ID = "COUNTRY_OF_BIRTHButton_Update" Then
            RedirectUrl = GetCOUNTRY_OF_BIRTHRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form COUNTRY_OF_BIRTH Before Update tail @2-46A7D8C3
        COUNTRY_OF_BIRTHParameters()
        COUNTRY_OF_BIRTHLoadItemFromRequest(item, EnableValidation)
        If COUNTRY_OF_BIRTHOperations.AllowUpdate Then
        ErrorFlag = (COUNTRY_OF_BIRTHErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                COUNTRY_OF_BIRTHData.UpdateItem(item)
            Catch ex As Exception
                COUNTRY_OF_BIRTHErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form COUNTRY_OF_BIRTH Before Update tail

'Record Form COUNTRY_OF_BIRTH Update Operation tail @2-0F792F85
        End If
        ErrorFlag=(COUNTRY_OF_BIRTHErrors.Count > 0)
        If ErrorFlag Then
            COUNTRY_OF_BIRTHShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTH Update Operation tail

'Record Form COUNTRY_OF_BIRTH Delete Operation @2-4C4BC6C4
    Protected Sub COUNTRY_OF_BIRTH_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        COUNTRY_OF_BIRTHIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form COUNTRY_OF_BIRTH Delete Operation

'Button Button_Delete OnClick. @5-7D0E4F9E
        If CType(sender,Control).ID = "COUNTRY_OF_BIRTHButton_Delete" Then
            RedirectUrl = GetCOUNTRY_OF_BIRTHRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-8860A968
        COUNTRY_OF_BIRTHParameters()
        COUNTRY_OF_BIRTHLoadItemFromRequest(item, EnableValidation)
        If COUNTRY_OF_BIRTHOperations.AllowDelete Then
        ErrorFlag = (COUNTRY_OF_BIRTHErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                COUNTRY_OF_BIRTHData.DeleteItem(item)
            Catch ex As Exception
                COUNTRY_OF_BIRTHErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-CD4E5638
        End If
        If ErrorFlag Then
            COUNTRY_OF_BIRTHShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form COUNTRY_OF_BIRTH Cancel Operation @2-C6194C1C

    Protected Sub COUNTRY_OF_BIRTH_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        COUNTRY_OF_BIRTHIsSubmitted = True
        Dim RedirectUrl As String = ""
        COUNTRY_OF_BIRTHLoadItemFromRequest(item, True)
'End Record Form COUNTRY_OF_BIRTH Cancel Operation

'Record Form COUNTRY_OF_BIRTH Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form COUNTRY_OF_BIRTH Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-C9B84F24
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        COUNTRY_OF_BIRT_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        COUNTRY_OF_BIRTHData = New COUNTRY_OF_BIRTHDataProvider()
        COUNTRY_OF_BIRTHOperations = New FormSupportedOperations(False, True, True, True, True)
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

