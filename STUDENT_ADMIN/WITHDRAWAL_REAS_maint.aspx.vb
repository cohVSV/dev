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

Namespace DECV_PROD2007.WITHDRAWAL_REAS_maint 'Namespace @1-77B27089

'Forms Definition @1-54C56D3A
Public Class [WITHDRAWAL_REAS_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-4FD16099
    Protected WITHDRAWAL_REASONData As WITHDRAWAL_REASONDataProvider
    Protected WITHDRAWAL_REASONErrors As NameValueCollection = New NameValueCollection()
    Protected WITHDRAWAL_REASONOperations As FormSupportedOperations
    Protected WITHDRAWAL_REASONIsSubmitted As Boolean = False
    Protected WITHDRAWAL_REAS_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-AD90BAB2
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            WITHDRAWAL_REASONShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form WITHDRAWAL_REASON Parameters @2-73510861

    Protected Sub WITHDRAWAL_REASONParameters()
        Dim item As new WITHDRAWAL_REASONItem
        Try
            WITHDRAWAL_REASONData.UrlWITHDRAWAL_REASON_ID = FloatParameter.GetParam("WITHDRAWAL_REASON_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            WITHDRAWAL_REASONErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form WITHDRAWAL_REASON Parameters

'Record Form WITHDRAWAL_REASON Show method @2-81E397D6
    Protected Sub WITHDRAWAL_REASONShow()
        If WITHDRAWAL_REASONOperations.None Then
            WITHDRAWAL_REASONHolder.Visible = False
            Return
        End If
        Dim item As WITHDRAWAL_REASONItem = WITHDRAWAL_REASONItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not WITHDRAWAL_REASONOperations.AllowRead
        WITHDRAWAL_REASONErrors.Add(item.errors)
        If WITHDRAWAL_REASONErrors.Count > 0 Then
            WITHDRAWAL_REASONShowErrors()
            Return
        End If
'End Record Form WITHDRAWAL_REASON Show method

'Record Form WITHDRAWAL_REASON BeforeShow tail @2-B9196E11
        WITHDRAWAL_REASONParameters()
        WITHDRAWAL_REASONData.FillItem(item, IsInsertMode)
        WITHDRAWAL_REASONHolder.DataBind()
        WITHDRAWAL_REASONButton_Insert.Visible=IsInsertMode AndAlso WITHDRAWAL_REASONOperations.AllowInsert
        WITHDRAWAL_REASONButton_Update.Visible=Not (IsInsertMode) AndAlso WITHDRAWAL_REASONOperations.AllowUpdate
        WITHDRAWAL_REASONButton_Delete.Visible=Not (IsInsertMode) AndAlso WITHDRAWAL_REASONOperations.AllowDelete
        WITHDRAWAL_REASONWITHDRAWAL_REASON.Text=item.WITHDRAWAL_REASON.GetFormattedValue()
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            WITHDRAWAL_REASONSTATUS.Checked = True
        End If
        WITHDRAWAL_REASONLAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        WITHDRAWAL_REASONLAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form WITHDRAWAL_REASON BeforeShow tail

'Record Form WITHDRAWAL_REASON Show method tail @2-69DB4344
        If WITHDRAWAL_REASONErrors.Count > 0 Then
            WITHDRAWAL_REASONShowErrors()
        End If
    End Sub
'End Record Form WITHDRAWAL_REASON Show method tail

'Record Form WITHDRAWAL_REASON LoadItemFromRequest method @2-32D27968

    Protected Sub WITHDRAWAL_REASONLoadItemFromRequest(item As WITHDRAWAL_REASONItem, ByVal EnableValidation As Boolean)
        item.WITHDRAWAL_REASON.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_REASONWITHDRAWAL_REASON.UniqueID))
        If ControlCustomValues("WITHDRAWAL_REASONWITHDRAWAL_REASON") Is Nothing Then
            item.WITHDRAWAL_REASON.SetValue(WITHDRAWAL_REASONWITHDRAWAL_REASON.Text)
        Else
            item.WITHDRAWAL_REASON.SetValue(ControlCustomValues("WITHDRAWAL_REASONWITHDRAWAL_REASON"))
        End If
        If WITHDRAWAL_REASONSTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_REASONLAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("WITHDRAWAL_REASONLAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(WITHDRAWAL_REASONLAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("WITHDRAWAL_REASONLAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(WITHDRAWAL_REASONLAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("WITHDRAWAL_REASONLAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(WITHDRAWAL_REASONLAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("WITHDRAWAL_REASONLAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            WITHDRAWAL_REASONErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(WITHDRAWAL_REASONData)
        End If
        WITHDRAWAL_REASONErrors.Add(item.errors)
    End Sub
'End Record Form WITHDRAWAL_REASON LoadItemFromRequest method

'Record Form WITHDRAWAL_REASON GetRedirectUrl method @2-C1347A91

    Protected Function GetWITHDRAWAL_REASONRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "WITHDRAWAL_REAS_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form WITHDRAWAL_REASON GetRedirectUrl method

'Record Form WITHDRAWAL_REASON ShowErrors method @2-DB672EDA

    Protected Sub WITHDRAWAL_REASONShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To WITHDRAWAL_REASONErrors.Count - 1
        Select Case WITHDRAWAL_REASONErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & WITHDRAWAL_REASONErrors(i)
        End Select
        Next i
        WITHDRAWAL_REASONError.Visible = True
        WITHDRAWAL_REASONErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form WITHDRAWAL_REASON ShowErrors method

'Record Form WITHDRAWAL_REASON Insert Operation @2-78AEA80E

    Protected Sub WITHDRAWAL_REASON_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        Dim ExecuteFlag As Boolean = True
        WITHDRAWAL_REASONIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form WITHDRAWAL_REASON Insert Operation

'Button Button_Insert OnClick. @3-090CD334
        If CType(sender,Control).ID = "WITHDRAWAL_REASONButton_Insert" Then
            RedirectUrl = GetWITHDRAWAL_REASONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form WITHDRAWAL_REASON BeforeInsert tail @2-E741E542
    WITHDRAWAL_REASONParameters()
    WITHDRAWAL_REASONLoadItemFromRequest(item, EnableValidation)
    If WITHDRAWAL_REASONOperations.AllowInsert Then
        ErrorFlag=(WITHDRAWAL_REASONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                WITHDRAWAL_REASONData.InsertItem(item)
            Catch ex As Exception
                WITHDRAWAL_REASONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form WITHDRAWAL_REASON BeforeInsert tail

'Record Form WITHDRAWAL_REASON AfterInsert tail  @2-3B60BB3B
        End If
        ErrorFlag=(WITHDRAWAL_REASONErrors.Count > 0)
        If ErrorFlag Then
            WITHDRAWAL_REASONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form WITHDRAWAL_REASON AfterInsert tail 

'Record Form WITHDRAWAL_REASON Update Operation @2-9695677A

    Protected Sub WITHDRAWAL_REASON_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        WITHDRAWAL_REASONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form WITHDRAWAL_REASON Update Operation

'Button Button_Update OnClick. @4-F254AD43
        If CType(sender,Control).ID = "WITHDRAWAL_REASONButton_Update" Then
            RedirectUrl = GetWITHDRAWAL_REASONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form WITHDRAWAL_REASON Before Update tail @2-73714C9A
        WITHDRAWAL_REASONParameters()
        WITHDRAWAL_REASONLoadItemFromRequest(item, EnableValidation)
        If WITHDRAWAL_REASONOperations.AllowUpdate Then
        ErrorFlag = (WITHDRAWAL_REASONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                WITHDRAWAL_REASONData.UpdateItem(item)
            Catch ex As Exception
                WITHDRAWAL_REASONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form WITHDRAWAL_REASON Before Update tail

'Record Form WITHDRAWAL_REASON Update Operation tail @2-3B60BB3B
        End If
        ErrorFlag=(WITHDRAWAL_REASONErrors.Count > 0)
        If ErrorFlag Then
            WITHDRAWAL_REASONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form WITHDRAWAL_REASON Update Operation tail

'Record Form WITHDRAWAL_REASON Delete Operation @2-8EB64771
    Protected Sub WITHDRAWAL_REASON_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        WITHDRAWAL_REASONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form WITHDRAWAL_REASON Delete Operation

'Button Button_Delete OnClick. @5-E4EF877E
        If CType(sender,Control).ID = "WITHDRAWAL_REASONButton_Delete" Then
            RedirectUrl = GetWITHDRAWAL_REASONRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-10CDEA46
        WITHDRAWAL_REASONParameters()
        WITHDRAWAL_REASONLoadItemFromRequest(item, EnableValidation)
        If WITHDRAWAL_REASONOperations.AllowDelete Then
        ErrorFlag = (WITHDRAWAL_REASONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                WITHDRAWAL_REASONData.DeleteItem(item)
            Catch ex As Exception
                WITHDRAWAL_REASONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-D09F4F30
        End If
        If ErrorFlag Then
            WITHDRAWAL_REASONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form WITHDRAWAL_REASON Cancel Operation @2-4E17795E

    Protected Sub WITHDRAWAL_REASON_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As WITHDRAWAL_REASONItem = New WITHDRAWAL_REASONItem()
        WITHDRAWAL_REASONIsSubmitted = True
        Dim RedirectUrl As String = ""
        WITHDRAWAL_REASONLoadItemFromRequest(item, True)
'End Record Form WITHDRAWAL_REASON Cancel Operation

'Record Form WITHDRAWAL_REASON Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form WITHDRAWAL_REASON Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-D24D9E49
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        WITHDRAWAL_REAS_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        WITHDRAWAL_REASONData = New WITHDRAWAL_REASONDataProvider()
        WITHDRAWAL_REASONOperations = New FormSupportedOperations(False, True, True, True, True)
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

