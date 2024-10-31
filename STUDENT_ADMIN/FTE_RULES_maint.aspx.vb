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

Namespace DECV_PROD2007.FTE_RULES_maint 'Namespace @1-5D46EE36

'Forms Definition @1-62E0445E
Public Class [FTE_RULES_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-BAD8CC82
    Protected FTE_RULESData As FTE_RULESDataProvider
    Protected FTE_RULESErrors As NameValueCollection = New NameValueCollection()
    Protected FTE_RULESOperations As FormSupportedOperations
    Protected FTE_RULESIsSubmitted As Boolean = False
    Protected FTE_RULES_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-5B2C63EE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            FTE_RULESShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form FTE_RULES Parameters @2-47EC36F9

    Protected Sub FTE_RULESParameters()
        Dim item As new FTE_RULESItem
        Try
            FTE_RULESData.UrlUNIT = IntegerParameter.GetParam("UNIT", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            FTE_RULESErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form FTE_RULES Parameters

'Record Form FTE_RULES Show method @2-CB6B03A0
    Protected Sub FTE_RULESShow()
        If FTE_RULESOperations.None Then
            FTE_RULESHolder.Visible = False
            Return
        End If
        Dim item As FTE_RULESItem = FTE_RULESItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not FTE_RULESOperations.AllowRead
        FTE_RULESErrors.Add(item.errors)
        If FTE_RULESErrors.Count > 0 Then
            FTE_RULESShowErrors()
            Return
        End If
'End Record Form FTE_RULES Show method

'Record Form FTE_RULES BeforeShow tail @2-E2968DF5
        FTE_RULESParameters()
        FTE_RULESData.FillItem(item, IsInsertMode)
        FTE_RULESHolder.DataBind()
        FTE_RULESButton_Insert.Visible=IsInsertMode AndAlso FTE_RULESOperations.AllowInsert
        FTE_RULESButton_Update.Visible=Not (IsInsertMode) AndAlso FTE_RULESOperations.AllowUpdate
        FTE_RULESButton_Delete.Visible=Not (IsInsertMode) AndAlso FTE_RULESOperations.AllowDelete
        FTE_RULESFROM_YEAR_LEVEL.Text=item.FROM_YEAR_LEVEL.GetFormattedValue()
        FTE_RULESTO_YEAR_LEVEL.Text=item.TO_YEAR_LEVEL.GetFormattedValue()
        FTE_RULESFTE.Text=item.FTE.GetFormattedValue()
        If item.FULLTIME_FLAGCheckedValue.Value.Equals(item.FULLTIME_FLAG.Value) Then
            FTE_RULESFULLTIME_FLAG.Checked = True
        End If
        FTE_RULESLAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        FTE_RULESLAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form FTE_RULES BeforeShow tail

'Record Form FTE_RULES Show method tail @2-75D153E5
        If FTE_RULESErrors.Count > 0 Then
            FTE_RULESShowErrors()
        End If
    End Sub
'End Record Form FTE_RULES Show method tail

'Record Form FTE_RULES LoadItemFromRequest method @2-304684AB

    Protected Sub FTE_RULESLoadItemFromRequest(item As FTE_RULESItem, ByVal EnableValidation As Boolean)
        Try
        item.FROM_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(FTE_RULESFROM_YEAR_LEVEL.UniqueID))
        If ControlCustomValues("FTE_RULESFROM_YEAR_LEVEL") Is Nothing Then
            item.FROM_YEAR_LEVEL.SetValue(FTE_RULESFROM_YEAR_LEVEL.Text)
        Else
            item.FROM_YEAR_LEVEL.SetValue(ControlCustomValues("FTE_RULESFROM_YEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            FTE_RULESErrors.Add("FROM_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"FROM YEAR LEVEL"))
        End Try
        Try
        item.TO_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(FTE_RULESTO_YEAR_LEVEL.UniqueID))
        If ControlCustomValues("FTE_RULESTO_YEAR_LEVEL") Is Nothing Then
            item.TO_YEAR_LEVEL.SetValue(FTE_RULESTO_YEAR_LEVEL.Text)
        Else
            item.TO_YEAR_LEVEL.SetValue(ControlCustomValues("FTE_RULESTO_YEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            FTE_RULESErrors.Add("TO_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"TO YEAR LEVEL"))
        End Try
        Try
        item.FTE.IsEmpty = IsNothing(Request.Form(FTE_RULESFTE.UniqueID))
        If ControlCustomValues("FTE_RULESFTE") Is Nothing Then
            item.FTE.SetValue(FTE_RULESFTE.Text)
        Else
            item.FTE.SetValue(ControlCustomValues("FTE_RULESFTE"))
        End If
        Catch ae As ArgumentException
            FTE_RULESErrors.Add("FTE",String.Format(Resources.strings.CCS_IncorrectValue,"FTE"))
        End Try
        If FTE_RULESFULLTIME_FLAG.Checked Then
            item.FULLTIME_FLAG.Value = (item.FULLTIME_FLAGCheckedValue.Value)
        Else
            item.FULLTIME_FLAG.Value = (item.FULLTIME_FLAGUncheckedValue.Value)
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(FTE_RULESLAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("FTE_RULESLAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(FTE_RULESLAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("FTE_RULESLAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(FTE_RULESLAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("FTE_RULESLAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(FTE_RULESLAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("FTE_RULESLAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            FTE_RULESErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(FTE_RULESData)
        End If
        FTE_RULESErrors.Add(item.errors)
    End Sub
'End Record Form FTE_RULES LoadItemFromRequest method

'Record Form FTE_RULES GetRedirectUrl method @2-0BD3A8E6

    Protected Function GetFTE_RULESRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FTE_RULES_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form FTE_RULES GetRedirectUrl method

'Record Form FTE_RULES ShowErrors method @2-8AC44939

    Protected Sub FTE_RULESShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To FTE_RULESErrors.Count - 1
        Select Case FTE_RULESErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & FTE_RULESErrors(i)
        End Select
        Next i
        FTE_RULESError.Visible = True
        FTE_RULESErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form FTE_RULES ShowErrors method

'Record Form FTE_RULES Insert Operation @2-AF9EA72D

    Protected Sub FTE_RULES_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        Dim ExecuteFlag As Boolean = True
        FTE_RULESIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form FTE_RULES Insert Operation

'Button Button_Insert OnClick. @3-1F32304F
        If CType(sender,Control).ID = "FTE_RULESButton_Insert" Then
            RedirectUrl = GetFTE_RULESRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form FTE_RULES BeforeInsert tail @2-82D702D7
    FTE_RULESParameters()
    FTE_RULESLoadItemFromRequest(item, EnableValidation)
    If FTE_RULESOperations.AllowInsert Then
        ErrorFlag=(FTE_RULESErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                FTE_RULESData.InsertItem(item)
            Catch ex As Exception
                FTE_RULESErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form FTE_RULES BeforeInsert tail

'Record Form FTE_RULES AfterInsert tail  @2-BE6738A7
        End If
        ErrorFlag=(FTE_RULESErrors.Count > 0)
        If ErrorFlag Then
            FTE_RULESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form FTE_RULES AfterInsert tail 

'Record Form FTE_RULES Update Operation @2-70398966

    Protected Sub FTE_RULES_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        FTE_RULESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form FTE_RULES Update Operation

'Button Button_Update OnClick. @4-18538F70
        If CType(sender,Control).ID = "FTE_RULESButton_Update" Then
            RedirectUrl = GetFTE_RULESRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form FTE_RULES Before Update tail @2-FB6EE2F7
        FTE_RULESParameters()
        FTE_RULESLoadItemFromRequest(item, EnableValidation)
        If FTE_RULESOperations.AllowUpdate Then
        ErrorFlag = (FTE_RULESErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                FTE_RULESData.UpdateItem(item)
            Catch ex As Exception
                FTE_RULESErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form FTE_RULES Before Update tail

'Record Form FTE_RULES Update Operation tail @2-BE6738A7
        End If
        ErrorFlag=(FTE_RULESErrors.Count > 0)
        If ErrorFlag Then
            FTE_RULESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form FTE_RULES Update Operation tail

'Record Form FTE_RULES Delete Operation @2-17F40693
    Protected Sub FTE_RULES_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        FTE_RULESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form FTE_RULES Delete Operation

'Button Button_Delete OnClick. @5-B49331BC
        If CType(sender,Control).ID = "FTE_RULESButton_Delete" Then
            RedirectUrl = GetFTE_RULESRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-977F32BF
        FTE_RULESParameters()
        FTE_RULESLoadItemFromRequest(item, EnableValidation)
        If FTE_RULESOperations.AllowDelete Then
        ErrorFlag = (FTE_RULESErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                FTE_RULESData.DeleteItem(item)
            Catch ex As Exception
                FTE_RULESErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-14F81749
        End If
        If ErrorFlag Then
            FTE_RULESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form FTE_RULES Cancel Operation @2-1562A2EB

    Protected Sub FTE_RULES_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        FTE_RULESIsSubmitted = True
        Dim RedirectUrl As String = ""
        FTE_RULESLoadItemFromRequest(item, True)
'End Record Form FTE_RULES Cancel Operation

'Record Form FTE_RULES Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form FTE_RULES Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3FDA3668
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FTE_RULES_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        FTE_RULESData = New FTE_RULESDataProvider()
        FTE_RULESOperations = New FormSupportedOperations(False, True, True, True, True)
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

