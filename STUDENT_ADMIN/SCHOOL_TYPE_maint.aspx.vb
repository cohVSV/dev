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

Namespace DECV_PROD2007.SCHOOL_TYPE_maint 'Namespace @1-EB2F49B1

'Forms Definition @1-4E1D1BE3
Public Class [SCHOOL_TYPE_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-7A818022
    Protected SCHOOL_TYPEData As SCHOOL_TYPEDataProvider
    Protected SCHOOL_TYPEErrors As NameValueCollection = New NameValueCollection()
    Protected SCHOOL_TYPEOperations As FormSupportedOperations
    Protected SCHOOL_TYPEIsSubmitted As Boolean = False
    Protected SCHOOL_TYPE_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-1AC53DDC
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "SCHOOL_TYPE_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            SCHOOL_TYPEShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SCHOOL_TYPE Parameters @2-2388EDE3

    Protected Sub SCHOOL_TYPEParameters()
        Dim item As new SCHOOL_TYPEItem
        Try
            SCHOOL_TYPEData.UrlSCHOOL_TYPE_CODE = TextParameter.GetParam("SCHOOL_TYPE_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            SCHOOL_TYPEErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SCHOOL_TYPE Parameters

'Record Form SCHOOL_TYPE Show method @2-99CEECCC
    Protected Sub SCHOOL_TYPEShow()
        If SCHOOL_TYPEOperations.None Then
            SCHOOL_TYPEHolder.Visible = False
            Return
        End If
        Dim item As SCHOOL_TYPEItem = SCHOOL_TYPEItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SCHOOL_TYPEOperations.AllowRead
        SCHOOL_TYPEErrors.Add(item.errors)
        If SCHOOL_TYPEErrors.Count > 0 Then
            SCHOOL_TYPEShowErrors()
            Return
        End If
'End Record Form SCHOOL_TYPE Show method

'Record Form SCHOOL_TYPE BeforeShow tail @2-717B4BFB
        SCHOOL_TYPEParameters()
        SCHOOL_TYPEData.FillItem(item, IsInsertMode)
        SCHOOL_TYPEHolder.DataBind()
        SCHOOL_TYPEButton_Insert.Visible=IsInsertMode AndAlso SCHOOL_TYPEOperations.AllowInsert
        SCHOOL_TYPEButton_Update.Visible=Not (IsInsertMode) AndAlso SCHOOL_TYPEOperations.AllowUpdate
        SCHOOL_TYPEButton_Delete.Visible=Not (IsInsertMode) AndAlso SCHOOL_TYPEOperations.AllowDelete
        SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION.Text=item.SCHOOL_TYPE_DESCRIPTION.GetFormattedValue()
        SCHOOL_TYPElbl_SchoolTypeCode.Text = Server.HtmlEncode(item.lbl_SchoolTypeCode.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOL_TYPESCHOOL_TYPE_CODE.Text=item.SCHOOL_TYPE_CODE.GetFormattedValue()
        SCHOOL_TYPElbl_LAST_ALTERED_BY.Text = Server.HtmlEncode(item.lbl_LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOL_TYPElbl_LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lbl_LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SCHOOL_TYPELAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        SCHOOL_TYPELAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form SCHOOL_TYPE BeforeShow tail

'Record SCHOOL_TYPE Event BeforeShow. Action Custom Code @16-73254650
    ' -------------------------
    ' ERA: swap between Textbox (if New record) or lable if not
	If (IsInsertMode) Then
   		SCHOOL_TYPElbl_SchoolTypeCode.visible = false
  	Else 
    	SCHOOL_TYPESCHOOL_TYPE_CODE.visible = false
  	End if
    ' -------------------------
'End Record SCHOOL_TYPE Event BeforeShow. Action Custom Code

'Record Form SCHOOL_TYPE Show method tail @2-7798ABAC
        If SCHOOL_TYPEErrors.Count > 0 Then
            SCHOOL_TYPEShowErrors()
        End If
    End Sub
'End Record Form SCHOOL_TYPE Show method tail

'Record Form SCHOOL_TYPE LoadItemFromRequest method @2-DF0A47DE

    Protected Sub SCHOOL_TYPELoadItemFromRequest(item As SCHOOL_TYPEItem, ByVal EnableValidation As Boolean)
        item.SCHOOL_TYPE_DESCRIPTION.IsEmpty = IsNothing(Request.Form(SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION.UniqueID))
        If ControlCustomValues("SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION") Is Nothing Then
            item.SCHOOL_TYPE_DESCRIPTION.SetValue(SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION.Text)
        Else
            item.SCHOOL_TYPE_DESCRIPTION.SetValue(ControlCustomValues("SCHOOL_TYPESCHOOL_TYPE_DESCRIPTION"))
        End If
        item.SCHOOL_TYPE_CODE.IsEmpty = IsNothing(Request.Form(SCHOOL_TYPESCHOOL_TYPE_CODE.UniqueID))
        If ControlCustomValues("SCHOOL_TYPESCHOOL_TYPE_CODE") Is Nothing Then
            item.SCHOOL_TYPE_CODE.SetValue(SCHOOL_TYPESCHOOL_TYPE_CODE.Text)
        Else
            item.SCHOOL_TYPE_CODE.SetValue(ControlCustomValues("SCHOOL_TYPESCHOOL_TYPE_CODE"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(SCHOOL_TYPELAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(SCHOOL_TYPELAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(SCHOOL_TYPELAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(SCHOOL_TYPELAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            SCHOOL_TYPEErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        If EnableValidation Then
            item.Validate(SCHOOL_TYPEData)
        End If
        SCHOOL_TYPEErrors.Add(item.errors)
    End Sub
'End Record Form SCHOOL_TYPE LoadItemFromRequest method

'Record Form SCHOOL_TYPE GetRedirectUrl method @2-4A095CE9

    Protected Function GetSCHOOL_TYPERedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "SCHOOL_TYPE_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SCHOOL_TYPE GetRedirectUrl method

'Record Form SCHOOL_TYPE ShowErrors method @2-29DA2379

    Protected Sub SCHOOL_TYPEShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SCHOOL_TYPEErrors.Count - 1
        Select Case SCHOOL_TYPEErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SCHOOL_TYPEErrors(i)
        End Select
        Next i
        SCHOOL_TYPEError.Visible = True
        SCHOOL_TYPEErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SCHOOL_TYPE ShowErrors method

'Record Form SCHOOL_TYPE Insert Operation @2-E46C6C6A

    Protected Sub SCHOOL_TYPE_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        Dim ExecuteFlag As Boolean = True
        SCHOOL_TYPEIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOL_TYPE Insert Operation

'Button Button_Insert OnClick. @3-0758C8F3
        If CType(sender,Control).ID = "SCHOOL_TYPEButton_Insert" Then
            RedirectUrl = GetSCHOOL_TYPERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form SCHOOL_TYPE BeforeInsert tail @2-17A98D25
    SCHOOL_TYPEParameters()
    SCHOOL_TYPELoadItemFromRequest(item, EnableValidation)
    If SCHOOL_TYPEOperations.AllowInsert Then
        ErrorFlag=(SCHOOL_TYPEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOL_TYPEData.InsertItem(item)
            Catch ex As Exception
                SCHOOL_TYPEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOL_TYPE BeforeInsert tail

'Record Form SCHOOL_TYPE AfterInsert tail  @2-8FBB25E7
        End If
        ErrorFlag=(SCHOOL_TYPEErrors.Count > 0)
        If ErrorFlag Then
            SCHOOL_TYPEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOL_TYPE AfterInsert tail 

'Record Form SCHOOL_TYPE Update Operation @2-6449209E

    Protected Sub SCHOOL_TYPE_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SCHOOL_TYPEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOL_TYPE Update Operation

'Button Button_Update OnClick. @4-04584BB3
        If CType(sender,Control).ID = "SCHOOL_TYPEButton_Update" Then
            RedirectUrl = GetSCHOOL_TYPERedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record SCHOOL_TYPE Event BeforeUpdate. Action Retrieve Value for Control @19-F5737B78
        SCHOOL_TYPELAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserId.ToString()))).GetFormattedValue()
'End Record SCHOOL_TYPE Event BeforeUpdate. Action Retrieve Value for Control

'Record SCHOOL_TYPE Event BeforeUpdate. Action Retrieve Value for Control @20-423A3DD4
        SCHOOL_TYPELAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record SCHOOL_TYPE Event BeforeUpdate. Action Retrieve Value for Control

'Record Form SCHOOL_TYPE Before Update tail @2-CDAFCCBD
        SCHOOL_TYPEParameters()
        SCHOOL_TYPELoadItemFromRequest(item, EnableValidation)
        If SCHOOL_TYPEOperations.AllowUpdate Then
        ErrorFlag = (SCHOOL_TYPEErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SCHOOL_TYPEData.UpdateItem(item)
            Catch ex As Exception
                SCHOOL_TYPEErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SCHOOL_TYPE Before Update tail

'Record Form SCHOOL_TYPE Update Operation tail @2-8FBB25E7
        End If
        ErrorFlag=(SCHOOL_TYPEErrors.Count > 0)
        If ErrorFlag Then
            SCHOOL_TYPEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOL_TYPE Update Operation tail

'Record Form SCHOOL_TYPE Delete Operation @2-69EEE643
    Protected Sub SCHOOL_TYPE_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SCHOOL_TYPEIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SCHOOL_TYPE Delete Operation

'Button Button_Delete OnClick. @5-7476AA47
        If CType(sender,Control).ID = "SCHOOL_TYPEButton_Delete" Then
            RedirectUrl = GetSCHOOL_TYPERedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-1B26A771
        SCHOOL_TYPEParameters()
        SCHOOL_TYPELoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-480364DA
        If ErrorFlag Then
            SCHOOL_TYPEShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SCHOOL_TYPE Cancel Operation @2-AE388B5B

    Protected Sub SCHOOL_TYPE_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
        SCHOOL_TYPEIsSubmitted = True
        Dim RedirectUrl As String = ""
        SCHOOL_TYPELoadItemFromRequest(item, True)
'End Record Form SCHOOL_TYPE Cancel Operation

'Button Button_Cancel OnClick. @12-37087EF8
    If CType(sender,Control).ID = "SCHOOL_TYPEButton_Cancel" Then
        RedirectUrl = GetSCHOOL_TYPERedirectUrl("SCHOOL_TYPE_list.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @12-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form SCHOOL_TYPE Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SCHOOL_TYPE Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-CBDE6672
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SCHOOL_TYPE_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOL_TYPEData = New SCHOOL_TYPEDataProvider()
        SCHOOL_TYPEOperations = New FormSupportedOperations(False, True, True, True, False)
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

