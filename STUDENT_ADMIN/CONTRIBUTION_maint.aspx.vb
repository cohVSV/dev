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

Namespace DECV_PROD2007.CONTRIBUTION_maint 'Namespace @1-8D65252F

'Forms Definition @1-7446C656
Public Class [CONTRIBUTION_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-980F9885
    Protected CONTRIBUTIONData As CONTRIBUTIONDataProvider
    Protected CONTRIBUTIONErrors As NameValueCollection = New NameValueCollection()
    Protected CONTRIBUTIONOperations As FormSupportedOperations
    Protected CONTRIBUTIONIsSubmitted As Boolean = False
    Protected CONTRIBUTION_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-EF2B5C32
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "CONTRIBUTION_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            CONTRIBUTIONShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form CONTRIBUTION Parameters @2-E5FBEDE5

    Protected Sub CONTRIBUTIONParameters()
        Dim item As new CONTRIBUTIONItem
        Try
            CONTRIBUTIONData.UrlCATEGORY_CODE = TextParameter.GetParam("CATEGORY_CODE", ParameterSourceType.URL, "", Nothing, false)
            CONTRIBUTIONData.UrlSCHOOL_TYPE_CODE = TextParameter.GetParam("SCHOOL_TYPE_CODE", ParameterSourceType.URL, "", Nothing, false)
            CONTRIBUTIONData.UrlCAMPUS_CODE = TextParameter.GetParam("CAMPUS_CODE", ParameterSourceType.URL, "", Nothing, false)
            CONTRIBUTIONData.UrlFROM_YEAR_LEVEL = IntegerParameter.GetParam("FROM_YEAR_LEVEL", ParameterSourceType.URL, "", Nothing, false)
            CONTRIBUTIONData.UrlTO_YEAR_LEVEL = IntegerParameter.GetParam("TO_YEAR_LEVEL", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            CONTRIBUTIONErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form CONTRIBUTION Parameters

'Record Form CONTRIBUTION Show method @2-A53EEDF1
    Protected Sub CONTRIBUTIONShow()
        If CONTRIBUTIONOperations.None Then
            CONTRIBUTIONHolder.Visible = False
            Return
        End If
        Dim item As CONTRIBUTIONItem = CONTRIBUTIONItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not CONTRIBUTIONOperations.AllowRead
        CONTRIBUTIONErrors.Add(item.errors)
        If CONTRIBUTIONErrors.Count > 0 Then
            CONTRIBUTIONShowErrors()
            Return
        End If
'End Record Form CONTRIBUTION Show method

'Record Form CONTRIBUTION BeforeShow tail @2-2292914F
        CONTRIBUTIONParameters()
        CONTRIBUTIONData.FillItem(item, IsInsertMode)
        CONTRIBUTIONHolder.DataBind()
        CONTRIBUTIONButton_Insert.Visible=IsInsertMode AndAlso CONTRIBUTIONOperations.AllowInsert
        CONTRIBUTIONButton_Update.Visible=Not (IsInsertMode) AndAlso CONTRIBUTIONOperations.AllowUpdate
        CONTRIBUTIONButton_Delete.Visible=Not (IsInsertMode) AndAlso CONTRIBUTIONOperations.AllowDelete
        CONTRIBUTIONSCHOOL_TYPE_CODE.Items.Add(new ListItem("Select Value",""))
        CONTRIBUTIONSCHOOL_TYPE_CODE.Items(0).Selected = True
        item.SCHOOL_TYPE_CODEItems.SetSelection(item.SCHOOL_TYPE_CODE.GetFormattedValue())
        If Not item.SCHOOL_TYPE_CODEItems.GetSelectedItem() Is Nothing Then
            CONTRIBUTIONSCHOOL_TYPE_CODE.SelectedIndex = -1
        End If
        item.SCHOOL_TYPE_CODEItems.CopyTo(CONTRIBUTIONSCHOOL_TYPE_CODE.Items)
        item.CAMPUS_CODEItems.SetSelection(item.CAMPUS_CODE.GetFormattedValue())
        CONTRIBUTIONCAMPUS_CODE.SelectedIndex = -1
        item.CAMPUS_CODEItems.CopyTo(CONTRIBUTIONCAMPUS_CODE.Items)
        CONTRIBUTIONFROM_YEAR_LEVEL.Text=item.FROM_YEAR_LEVEL.GetFormattedValue()
        CONTRIBUTIONTO_YEAR_LEVEL.Text=item.TO_YEAR_LEVEL.GetFormattedValue()
        If item.PER_SUBJECT_FLAGCheckedValue.Value.Equals(item.PER_SUBJECT_FLAG.Value) Then
            CONTRIBUTIONPER_SUBJECT_FLAG.Checked = True
        End If
        CONTRIBUTIONDEFAULT_CONTRIBUTION.Text=item.DEFAULT_CONTRIBUTION.GetFormattedValue()
        CONTRIBUTIONDISCOUNT_AMOUNT.Text=item.DISCOUNT_AMOUNT.GetFormattedValue()
        CONTRIBUTIONLAST_ALTERED_BY.Text=item.LAST_ALTERED_BY.GetFormattedValue()
        CONTRIBUTIONLAST_ALTERED_DATE.Text=item.LAST_ALTERED_DATE.GetFormattedValue()
        CONTRIBUTIONCATEGORY.Text=item.CATEGORY.GetFormattedValue()
'End Record Form CONTRIBUTION BeforeShow tail

'Record Form CONTRIBUTION Show method tail @2-C5CC80D7
        If CONTRIBUTIONErrors.Count > 0 Then
            CONTRIBUTIONShowErrors()
        End If
    End Sub
'End Record Form CONTRIBUTION Show method tail

'Record Form CONTRIBUTION LoadItemFromRequest method @2-162F9E21

    Protected Sub CONTRIBUTIONLoadItemFromRequest(item As CONTRIBUTIONItem, ByVal EnableValidation As Boolean)
        item.SCHOOL_TYPE_CODE.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONSCHOOL_TYPE_CODE.UniqueID))
        item.SCHOOL_TYPE_CODE.SetValue(CONTRIBUTIONSCHOOL_TYPE_CODE.Value)
        item.SCHOOL_TYPE_CODEItems.CopyFrom(CONTRIBUTIONSCHOOL_TYPE_CODE.Items)
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONCAMPUS_CODE.UniqueID))
        If Not IsNothing(CONTRIBUTIONCAMPUS_CODE.SelectedItem) Then
            item.CAMPUS_CODE.SetValue(CONTRIBUTIONCAMPUS_CODE.SelectedItem.Value)
        Else
            item.CAMPUS_CODE.Value = Nothing
        End If
        item.CAMPUS_CODEItems.CopyFrom(CONTRIBUTIONCAMPUS_CODE.Items)
        Try
        item.FROM_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONFROM_YEAR_LEVEL.UniqueID))
        If ControlCustomValues("CONTRIBUTIONFROM_YEAR_LEVEL") Is Nothing Then
            item.FROM_YEAR_LEVEL.SetValue(CONTRIBUTIONFROM_YEAR_LEVEL.Text)
        Else
            item.FROM_YEAR_LEVEL.SetValue(ControlCustomValues("CONTRIBUTIONFROM_YEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            CONTRIBUTIONErrors.Add("FROM_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"FROM YEAR LEVEL"))
        End Try
        Try
        item.TO_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONTO_YEAR_LEVEL.UniqueID))
        If ControlCustomValues("CONTRIBUTIONTO_YEAR_LEVEL") Is Nothing Then
            item.TO_YEAR_LEVEL.SetValue(CONTRIBUTIONTO_YEAR_LEVEL.Text)
        Else
            item.TO_YEAR_LEVEL.SetValue(ControlCustomValues("CONTRIBUTIONTO_YEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            CONTRIBUTIONErrors.Add("TO_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"TO YEAR LEVEL"))
        End Try
        If CONTRIBUTIONPER_SUBJECT_FLAG.Checked Then
            item.PER_SUBJECT_FLAG.Value = (item.PER_SUBJECT_FLAGCheckedValue.Value)
        Else
            item.PER_SUBJECT_FLAG.Value = (item.PER_SUBJECT_FLAGUncheckedValue.Value)
        End If
        Try
        item.DEFAULT_CONTRIBUTION.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONDEFAULT_CONTRIBUTION.UniqueID))
        If ControlCustomValues("CONTRIBUTIONDEFAULT_CONTRIBUTION") Is Nothing Then
            item.DEFAULT_CONTRIBUTION.SetValue(CONTRIBUTIONDEFAULT_CONTRIBUTION.Text)
        Else
            item.DEFAULT_CONTRIBUTION.SetValue(ControlCustomValues("CONTRIBUTIONDEFAULT_CONTRIBUTION"))
        End If
        Catch ae As ArgumentException
            CONTRIBUTIONErrors.Add("DEFAULT_CONTRIBUTION",String.Format(Resources.strings.CCS_IncorrectValue,"DEFAULT CONTRIBUTION"))
        End Try
        Try
        item.DISCOUNT_AMOUNT.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONDISCOUNT_AMOUNT.UniqueID))
        If ControlCustomValues("CONTRIBUTIONDISCOUNT_AMOUNT") Is Nothing Then
            item.DISCOUNT_AMOUNT.SetValue(CONTRIBUTIONDISCOUNT_AMOUNT.Text)
        Else
            item.DISCOUNT_AMOUNT.SetValue(ControlCustomValues("CONTRIBUTIONDISCOUNT_AMOUNT"))
        End If
        Catch ae As ArgumentException
            CONTRIBUTIONErrors.Add("DISCOUNT_AMOUNT",String.Format(Resources.strings.CCS_IncorrectValue,"DISCOUNT AMOUNT"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONLAST_ALTERED_BY.UniqueID))
        If ControlCustomValues("CONTRIBUTIONLAST_ALTERED_BY") Is Nothing Then
            item.LAST_ALTERED_BY.SetValue(CONTRIBUTIONLAST_ALTERED_BY.Text)
        Else
            item.LAST_ALTERED_BY.SetValue(ControlCustomValues("CONTRIBUTIONLAST_ALTERED_BY"))
        End If
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONLAST_ALTERED_DATE.UniqueID))
        If ControlCustomValues("CONTRIBUTIONLAST_ALTERED_DATE") Is Nothing Then
            item.LAST_ALTERED_DATE.SetValue(CONTRIBUTIONLAST_ALTERED_DATE.Text)
        Else
            item.LAST_ALTERED_DATE.SetValue(ControlCustomValues("CONTRIBUTIONLAST_ALTERED_DATE"))
        End If
        Catch ae As ArgumentException
            CONTRIBUTIONErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        item.CATEGORY.IsEmpty = IsNothing(Request.Form(CONTRIBUTIONCATEGORY.UniqueID))
        If ControlCustomValues("CONTRIBUTIONCATEGORY") Is Nothing Then
            item.CATEGORY.SetValue(CONTRIBUTIONCATEGORY.Text)
        Else
            item.CATEGORY.SetValue(ControlCustomValues("CONTRIBUTIONCATEGORY"))
        End If
        If EnableValidation Then
            item.Validate(CONTRIBUTIONData)
        End If
        CONTRIBUTIONErrors.Add(item.errors)
    End Sub
'End Record Form CONTRIBUTION LoadItemFromRequest method

'Record Form CONTRIBUTION GetRedirectUrl method @2-586C713C

    Protected Function GetCONTRIBUTIONRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "CONTRIBUTION_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form CONTRIBUTION GetRedirectUrl method

'Record Form CONTRIBUTION ShowErrors method @2-4CD9E5EE

    Protected Sub CONTRIBUTIONShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To CONTRIBUTIONErrors.Count - 1
        Select Case CONTRIBUTIONErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & CONTRIBUTIONErrors(i)
        End Select
        Next i
        CONTRIBUTIONError.Visible = True
        CONTRIBUTIONErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form CONTRIBUTION ShowErrors method

'Record Form CONTRIBUTION Insert Operation @2-ED4CD5F6

    Protected Sub CONTRIBUTION_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        Dim ExecuteFlag As Boolean = True
        CONTRIBUTIONIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CONTRIBUTION Insert Operation

'Button Button_Insert OnClick. @3-358F130B
        If CType(sender,Control).ID = "CONTRIBUTIONButton_Insert" Then
            RedirectUrl = GetCONTRIBUTIONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form CONTRIBUTION BeforeInsert tail @2-ED03038B
    CONTRIBUTIONParameters()
    CONTRIBUTIONLoadItemFromRequest(item, EnableValidation)
    If CONTRIBUTIONOperations.AllowInsert Then
        ErrorFlag=(CONTRIBUTIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                CONTRIBUTIONData.InsertItem(item)
            Catch ex As Exception
                CONTRIBUTIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form CONTRIBUTION BeforeInsert tail

'Record Form CONTRIBUTION AfterInsert tail  @2-DAA4E59D
        End If
        ErrorFlag=(CONTRIBUTIONErrors.Count > 0)
        If ErrorFlag Then
            CONTRIBUTIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CONTRIBUTION AfterInsert tail 

'Record Form CONTRIBUTION Update Operation @2-CFF5D176

    Protected Sub CONTRIBUTION_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        CONTRIBUTIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CONTRIBUTION Update Operation

'Button Button_Update OnClick. @4-43505218
        If CType(sender,Control).ID = "CONTRIBUTIONButton_Update" Then
            RedirectUrl = GetCONTRIBUTIONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form CONTRIBUTION Before Update tail @2-657D4568
        CONTRIBUTIONParameters()
        CONTRIBUTIONLoadItemFromRequest(item, EnableValidation)
        If CONTRIBUTIONOperations.AllowUpdate Then
        ErrorFlag = (CONTRIBUTIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                CONTRIBUTIONData.UpdateItem(item)
            Catch ex As Exception
                CONTRIBUTIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form CONTRIBUTION Before Update tail

'Record Form CONTRIBUTION Update Operation tail @2-DAA4E59D
        End If
        ErrorFlag=(CONTRIBUTIONErrors.Count > 0)
        If ErrorFlag Then
            CONTRIBUTIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CONTRIBUTION Update Operation tail

'Record Form CONTRIBUTION Delete Operation @2-DBACD257
    Protected Sub CONTRIBUTION_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        CONTRIBUTIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form CONTRIBUTION Delete Operation

'Button Button_Delete OnClick. @5-BA898BC2
        If CType(sender,Control).ID = "CONTRIBUTIONButton_Delete" Then
            RedirectUrl = GetCONTRIBUTIONRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-40DC87D1
        CONTRIBUTIONParameters()
        CONTRIBUTIONLoadItemFromRequest(item, EnableValidation)
        If CONTRIBUTIONOperations.AllowDelete Then
        ErrorFlag = (CONTRIBUTIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                CONTRIBUTIONData.DeleteItem(item)
            Catch ex As Exception
                CONTRIBUTIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-25595DE2
        End If
        If ErrorFlag Then
            CONTRIBUTIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form CONTRIBUTION Cancel Operation @2-BB1FF8B8

    Protected Sub CONTRIBUTION_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CONTRIBUTIONItem = New CONTRIBUTIONItem()
        CONTRIBUTIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        CONTRIBUTIONLoadItemFromRequest(item, False)
'End Record Form CONTRIBUTION Cancel Operation

'Button Buttoncancel OnClick. @18-3A4CC694
    If CType(sender,Control).ID = "CONTRIBUTIONButtoncancel" Then
        RedirectUrl = GetCONTRIBUTIONRedirectUrl("CONTRIBUTION_list.aspx", "")
'End Button Buttoncancel OnClick.

'Button Buttoncancel OnClick tail. @18-477CF3C9
    End If
'End Button Buttoncancel OnClick tail.

'Record Form CONTRIBUTION Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form CONTRIBUTION Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-5687B245
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        CONTRIBUTION_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        CONTRIBUTIONData = New CONTRIBUTIONDataProvider()
        CONTRIBUTIONOperations = New FormSupportedOperations(False, True, True, True, True)
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

