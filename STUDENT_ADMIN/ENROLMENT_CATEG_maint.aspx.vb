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

Namespace DECV_PROD2007.ENROLMENT_CATEG_maint 'Namespace @1-9FDAD2BE

'Forms Definition @1-5E9E79F1
Public Class [ENROLMENT_CATEG_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EC819038
    Protected ENROLMENT_CATEGORYData As ENROLMENT_CATEGORYDataProvider
    Protected ENROLMENT_CATEGORYErrors As NameValueCollection = New NameValueCollection()
    Protected ENROLMENT_CATEGORYOperations As FormSupportedOperations
    Protected ENROLMENT_CATEGORYIsSubmitted As Boolean = False
    Protected ENROLMENT_CATEG_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-FEDFF1A0
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "ENROLMENT_CATEG_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            ENROLMENT_CATEGORYShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form ENROLMENT_CATEGORY Parameters @2-7A21F781

    Protected Sub ENROLMENT_CATEGORYParameters()
        Dim item As new ENROLMENT_CATEGORYItem
        Try
            ENROLMENT_CATEGORYData.UrlSUBCATEGORY_CODE = TextParameter.GetParam("SUBCATEGORY_CODE", ParameterSourceType.URL, "", Nothing, false)
            ENROLMENT_CATEGORYData.UrlCATEGORY_CODE = TextParameter.GetParam("CATEGORY_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            ENROLMENT_CATEGORYErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ENROLMENT_CATEGORY Parameters

'Record Form ENROLMENT_CATEGORY Show method @2-595DEEB6
    Protected Sub ENROLMENT_CATEGORYShow()
        If ENROLMENT_CATEGORYOperations.None Then
            ENROLMENT_CATEGORYHolder.Visible = False
            Return
        End If
        Dim item As ENROLMENT_CATEGORYItem = ENROLMENT_CATEGORYItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ENROLMENT_CATEGORYOperations.AllowRead
        ENROLMENT_CATEGORYErrors.Add(item.errors)
        If ENROLMENT_CATEGORYErrors.Count > 0 Then
            ENROLMENT_CATEGORYShowErrors()
            Return
        End If
'End Record Form ENROLMENT_CATEGORY Show method

'Record Form ENROLMENT_CATEGORY BeforeShow tail @2-183D6EF9
        ENROLMENT_CATEGORYParameters()
        ENROLMENT_CATEGORYData.FillItem(item, IsInsertMode)
        ENROLMENT_CATEGORYHolder.DataBind()
        ENROLMENT_CATEGORYButton_Insert.Visible=IsInsertMode AndAlso ENROLMENT_CATEGORYOperations.AllowInsert
        ENROLMENT_CATEGORYButton_Update.Visible=Not (IsInsertMode) AndAlso ENROLMENT_CATEGORYOperations.AllowUpdate
        ENROLMENT_CATEGORYButton_Delete.Visible=Not (IsInsertMode) AndAlso ENROLMENT_CATEGORYOperations.AllowDelete
        ENROLMENT_CATEGORYCATEGORY_CODE.Text=item.CATEGORY_CODE.GetFormattedValue()
        ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE.Text=item.SUBCATEGORY_FULL_TITLE.GetFormattedValue()
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            ENROLMENT_CATEGORYSTATUS.Checked = True
        End If
        ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text=item.SUBCATEGORY_CODE.GetFormattedValue()
        ENROLMENT_CATEGORYLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        ENROLMENT_CATEGORYLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        ENROLMENT_CATEGORYlblLAST_ALTERED_BY.Text = Server.HtmlEncode(item.lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ENROLMENT_CATEGORYlblLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form ENROLMENT_CATEGORY BeforeShow tail

'Record Form ENROLMENT_CATEGORY Show method tail @2-33AF441F
        If ENROLMENT_CATEGORYErrors.Count > 0 Then
            ENROLMENT_CATEGORYShowErrors()
        End If
    End Sub
'End Record Form ENROLMENT_CATEGORY Show method tail

'Record Form ENROLMENT_CATEGORY LoadItemFromRequest method @2-EFD4E996

    Protected Sub ENROLMENT_CATEGORYLoadItemFromRequest(item As ENROLMENT_CATEGORYItem, ByVal EnableValidation As Boolean)
        item.CATEGORY_CODE.IsEmpty = IsNothing(Request.Form(ENROLMENT_CATEGORYCATEGORY_CODE.UniqueID))
        If ControlCustomValues("ENROLMENT_CATEGORYCATEGORY_CODE") Is Nothing Then
            item.CATEGORY_CODE.SetValue(ENROLMENT_CATEGORYCATEGORY_CODE.Text)
        Else
            item.CATEGORY_CODE.SetValue(ControlCustomValues("ENROLMENT_CATEGORYCATEGORY_CODE"))
        End If
        item.SUBCATEGORY_FULL_TITLE.IsEmpty = IsNothing(Request.Form(ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE.UniqueID))
        If ControlCustomValues("ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE") Is Nothing Then
            item.SUBCATEGORY_FULL_TITLE.SetValue(ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE.Text)
        Else
            item.SUBCATEGORY_FULL_TITLE.SetValue(ControlCustomValues("ENROLMENT_CATEGORYSUBCATEGORY_FULL_TITLE"))
        End If
        If ENROLMENT_CATEGORYSTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        item.SUBCATEGORY_CODE.IsEmpty = IsNothing(Request.Form(ENROLMENT_CATEGORYSUBCATEGORY_CODE.UniqueID))
        If ControlCustomValues("ENROLMENT_CATEGORYSUBCATEGORY_CODE") Is Nothing Then
            item.SUBCATEGORY_CODE.SetValue(ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text)
        Else
            item.SUBCATEGORY_CODE.SetValue(ControlCustomValues("ENROLMENT_CATEGORYSUBCATEGORY_CODE"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(ENROLMENT_CATEGORYLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(ENROLMENT_CATEGORYLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(ENROLMENT_CATEGORYLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(ENROLMENT_CATEGORYLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            ENROLMENT_CATEGORYErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        If EnableValidation Then
            item.Validate(ENROLMENT_CATEGORYData)
        End If
        ENROLMENT_CATEGORYErrors.Add(item.errors)
    End Sub
'End Record Form ENROLMENT_CATEGORY LoadItemFromRequest method

'Record Form ENROLMENT_CATEGORY GetRedirectUrl method @2-D3840684

    Protected Function GetENROLMENT_CATEGORYRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "ENROLMENT_CATEG_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ENROLMENT_CATEGORY GetRedirectUrl method

'Record Form ENROLMENT_CATEGORY ShowErrors method @2-E0C89E36

    Protected Sub ENROLMENT_CATEGORYShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ENROLMENT_CATEGORYErrors.Count - 1
        Select Case ENROLMENT_CATEGORYErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ENROLMENT_CATEGORYErrors(i)
        End Select
        Next i
        ENROLMENT_CATEGORYError.Visible = True
        ENROLMENT_CATEGORYErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ENROLMENT_CATEGORY ShowErrors method

'Record Form ENROLMENT_CATEGORY Insert Operation @2-D6B2EB59

    Protected Sub ENROLMENT_CATEGORY_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        Dim ExecuteFlag As Boolean = True
        ENROLMENT_CATEGORYIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROLMENT_CATEGORY Insert Operation

'Button Button_Insert OnClick. @3-01190821
        If CType(sender,Control).ID = "ENROLMENT_CATEGORYButton_Insert" Then
            RedirectUrl = GetENROLMENT_CATEGORYRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form ENROLMENT_CATEGORY BeforeInsert tail @2-A1926087
    ENROLMENT_CATEGORYParameters()
    ENROLMENT_CATEGORYLoadItemFromRequest(item, EnableValidation)
    If ENROLMENT_CATEGORYOperations.AllowInsert Then
        ErrorFlag=(ENROLMENT_CATEGORYErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ENROLMENT_CATEGORYData.InsertItem(item)
            Catch ex As Exception
                ENROLMENT_CATEGORYErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ENROLMENT_CATEGORY BeforeInsert tail

'Record Form ENROLMENT_CATEGORY AfterInsert tail  @2-831E1455
        End If
        ErrorFlag=(ENROLMENT_CATEGORYErrors.Count > 0)
        If ErrorFlag Then
            ENROLMENT_CATEGORYShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROLMENT_CATEGORY AfterInsert tail 

'Record Form ENROLMENT_CATEGORY Update Operation @2-9C999C4C

    Protected Sub ENROLMENT_CATEGORY_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        ENROLMENT_CATEGORYIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ENROLMENT_CATEGORY Update Operation

'Button Button_Update OnClick. @4-CF83B4C0
        If CType(sender,Control).ID = "ENROLMENT_CATEGORYButton_Update" Then
            RedirectUrl = GetENROLMENT_CATEGORYRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control @19-59B5C48B
        ENROLMENT_CATEGORYLAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserId.ToUpper()))).GetFormattedValue()
'End Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control

'Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control @20-3DF2605E
        ENROLMENT_CATEGORYLAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control

'Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control @24-84F2B2E6
        ENROLMENT_CATEGORYCATEGORY_CODE.Text = (New TextField("", ((ENROLMENT_CATEGORYCATEGORY_CODE.Text.ToUpper())))).GetFormattedValue()
'End Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control

'Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control @25-85F721C3
        ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text = (New TextField("", ((ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text.ToUpper())))).GetFormattedValue()
'End Record ENROLMENT_CATEGORY Event BeforeUpdate. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL      ' ERA: convert the CATEGORY_CODE and SUBCATEGORY_CODE into uppercase
'DEL          'item.category_code.setvalue(item.category_code.value.ToUpper())
'DEL  		ENROLMENT_CATEGORYCATEGORY_CODE.Text=(ENROLMENT_CATEGORYCATEGORY_CODE.Text.ToUpper())
'DEL  		ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text=(ENROLMENT_CATEGORYSUBCATEGORY_CODE.Text.ToUpper())
'DEL  		'item.subcategory_code.setvalue(item.subcategory_code.value.ToUpper())
'DEL      ' -------------------------


'Record Form ENROLMENT_CATEGORY Before Update tail @2-1CBE42E3
        ENROLMENT_CATEGORYParameters()
        ENROLMENT_CATEGORYLoadItemFromRequest(item, EnableValidation)
        If ENROLMENT_CATEGORYOperations.AllowUpdate Then
        ErrorFlag = (ENROLMENT_CATEGORYErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ENROLMENT_CATEGORYData.UpdateItem(item)
            Catch ex As Exception
                ENROLMENT_CATEGORYErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ENROLMENT_CATEGORY Before Update tail

'Record Form ENROLMENT_CATEGORY Update Operation tail @2-831E1455
        End If
        ErrorFlag=(ENROLMENT_CATEGORYErrors.Count > 0)
        If ErrorFlag Then
            ENROLMENT_CATEGORYShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ENROLMENT_CATEGORY Update Operation tail

'Record Form ENROLMENT_CATEGORY Delete Operation @2-E0E74732
    Protected Sub ENROLMENT_CATEGORY_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ENROLMENT_CATEGORYIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ENROLMENT_CATEGORY Delete Operation

'Button Button_Delete OnClick. @5-304D431B
        If CType(sender,Control).ID = "ENROLMENT_CATEGORYButton_Delete" Then
            RedirectUrl = GetENROLMENT_CATEGORYRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-8BF919D4
        ENROLMENT_CATEGORYParameters()
        ENROLMENT_CATEGORYLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-4353ACC1
        If ErrorFlag Then
            ENROLMENT_CATEGORYShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ENROLMENT_CATEGORY Cancel Operation @2-FDE8F751

    Protected Sub ENROLMENT_CATEGORY_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
        ENROLMENT_CATEGORYIsSubmitted = True
        Dim RedirectUrl As String = ""
        ENROLMENT_CATEGORYLoadItemFromRequest(item, True)
'End Record Form ENROLMENT_CATEGORY Cancel Operation

'Button Button_Cancel OnClick. @17-D8554C8E
    If CType(sender,Control).ID = "ENROLMENT_CATEGORYButton_Cancel" Then
        RedirectUrl = GetENROLMENT_CATEGORYRedirectUrl("ENROLMENT_CATEG_list.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @17-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form ENROLMENT_CATEGORY Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ENROLMENT_CATEGORY Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-0A5ECC7E
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ENROLMENT_CATEG_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ENROLMENT_CATEGORYData = New ENROLMENT_CATEGORYDataProvider()
        ENROLMENT_CATEGORYOperations = New FormSupportedOperations(False, True, True, True, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

