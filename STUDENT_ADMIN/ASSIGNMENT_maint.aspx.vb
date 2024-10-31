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

Namespace DECV_PROD2007.ASSIGNMENT_maint 'Namespace @1-49643D26

'Forms Definition @1-4083C351
Public Class [ASSIGNMENT_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1D830BAD
    Protected Assignment_maintData As Assignment_maintDataProvider
    Protected Assignment_maintErrors As NameValueCollection = New NameValueCollection()
    Protected Assignment_maintOperations As FormSupportedOperations
    Protected Assignment_maintIsSubmitted As Boolean = False
    Protected ASSIGNMENT_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-DD52C371
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "ASSIGNMENT_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","ASSIGNMENT_ID", ViewState)
            Link1.DataBind()
            Assignment_maintShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form Assignment_maint Parameters @3-1A48A04C

    Protected Sub Assignment_maintParameters()
        Dim item As new Assignment_maintItem
        Try
            Assignment_maintData.UrlASSIGNMENT_ID = IntegerParameter.GetParam("ASSIGNMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            Assignment_maintData.UrlSUBJECT_ID = TextParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            Assignment_maintData.Ctrlhidden_SUBJECT_ID = IntegerParameter.GetParam(item.hidden_SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            Assignment_maintData.CtrltxtASSIGNMENT_ID = IntegerParameter.GetParam(item.txtASSIGNMENT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            Assignment_maintData.CtrltxtASSIGNMENT_DESCRIPTION = TextParameter.GetParam(item.txtASSIGNMENT_DESCRIPTION.Value, ParameterSourceType.Control, "", Nothing, false)
            Assignment_maintData.CtrlradioSTATUS = BooleanParameter.GetParam(item.radioSTATUS.Value, ParameterSourceType.Control, "Yes;No", Nothing, false)
            Assignment_maintData.Ctrlhidden_LAST_ALTERED_BY = TextParameter.GetParam(item.hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            Assignment_maintData.Ctrlhidden_LAST_ALTERED_DATE = DateParameter.GetParam(item.hidden_LAST_ALTERED_DATE.Value, ParameterSourceType.Control, Settings.DateFormat, Nothing, false)
        Catch e As Exception
            Assignment_maintErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form Assignment_maint Parameters

'Record Form Assignment_maint Show method @3-FC2895BD
    Protected Sub Assignment_maintShow()
        If Assignment_maintOperations.None Then
            Assignment_maintHolder.Visible = False
            Return
        End If
        Dim item As Assignment_maintItem = Assignment_maintItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not Assignment_maintOperations.AllowRead
        item.hidden_LAST_ALTERED_BY.SetValue(DBUtility.UserId.ToString())
        Assignment_maintErrors.Add(item.errors)
        If Assignment_maintErrors.Count > 0 Then
            Assignment_maintShowErrors()
            Return
        End If
'End Record Form Assignment_maint Show method

'Record Form Assignment_maint BeforeShow tail @3-FCC44195
        Assignment_maintParameters()
        Assignment_maintData.FillItem(item, IsInsertMode)
        Assignment_maintHolder.DataBind()
        Assignment_maintButton_Insert.Visible=IsInsertMode AndAlso Assignment_maintOperations.AllowInsert
        Assignment_maintButton_Update.Visible=Not (IsInsertMode) AndAlso Assignment_maintOperations.AllowUpdate
        Assignment_maintlblSubjectID.Text = Server.HtmlEncode(item.lblSubjectID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Assignment_maintlblSubjectName.Text = Server.HtmlEncode(item.lblSubjectName.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Assignment_mainttxtASSIGNMENT_ID.Text=item.txtASSIGNMENT_ID.GetFormattedValue()
        Assignment_mainttxtASSIGNMENT_DESCRIPTION.Text=item.txtASSIGNMENT_DESCRIPTION.GetFormattedValue()
        item.radioSTATUSItems.SetSelection(item.radioSTATUS.GetFormattedValue())
        Assignment_maintradioSTATUS.SelectedIndex = -1
        item.radioSTATUSItems.CopyTo(Assignment_maintradioSTATUS.Items)
        Assignment_maintlblLAST_ALTERED_BY.Text = Server.HtmlEncode(item.lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Assignment_maintlblLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Assignment_mainthidden_SUBJECT_ID.Value = item.hidden_SUBJECT_ID.GetFormattedValue()
        Assignment_mainthidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        Assignment_mainthidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form Assignment_maint BeforeShow tail

'Label lblSubjectName Event BeforeShow. Action Declare Variable @12-24705C7F
            Dim tmpSubjectID As Double = 0
'End Label lblSubjectName Event BeforeShow. Action Declare Variable

'Label lblSubjectName Event BeforeShow. Action Retrieve Value for Variable @18-B6E0589D
            tmpSubjectID = System.Web.HttpContext.Current.Request.QueryString("SUBJECT_ID")
'End Label lblSubjectName Event BeforeShow. Action Retrieve Value for Variable

'Label lblSubjectName Event BeforeShow. Action DLookup @19-6B2043D2
            Assignment_maintlblSubjectName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBJECT_TITLE" & " FROM " & "SUBJECT" & " WHERE " & "SUBJECT_ID = " & tmpSubjectID.ToString))).GetFormattedValue("")
'End Label lblSubjectName Event BeforeShow. Action DLookup

'Label lblSubjectName Event BeforeShow. Action Retrieve Value for Control @20-4B9B74FA
            Assignment_maintlblSubjectID.Text = (New TextField("", tmpSubjectID)).GetFormattedValue()
'End Label lblSubjectName Event BeforeShow. Action Retrieve Value for Control

'TextBox txtASSIGNMENT_DESCRIPTION Event BeforeShow. Action Custom Code @39-73254650
    ' -------------------------
    'ERA: 8-May-2014|EA| trim the Description of excess spaces unfuddle #581
	Assignment_mainttxtASSIGNMENT_DESCRIPTION.Text= RTrim(item.txtASSIGNMENT_DESCRIPTION.GetFormattedValue())
    ' -------------------------
'End TextBox txtASSIGNMENT_DESCRIPTION Event BeforeShow. Action Custom Code

'Record Form Assignment_maint Show method tail @3-646F9276
        If Assignment_maintErrors.Count > 0 Then
            Assignment_maintShowErrors()
        End If
    End Sub
'End Record Form Assignment_maint Show method tail

'Record Form Assignment_maint LoadItemFromRequest method @3-AC807108

    Protected Sub Assignment_maintLoadItemFromRequest(item As Assignment_maintItem, ByVal EnableValidation As Boolean)
        Try
        item.txtASSIGNMENT_ID.IsEmpty = IsNothing(Request.Form(Assignment_mainttxtASSIGNMENT_ID.UniqueID))
        If ControlCustomValues("Assignment_mainttxtASSIGNMENT_ID") Is Nothing Then
            item.txtASSIGNMENT_ID.SetValue(Assignment_mainttxtASSIGNMENT_ID.Text)
        Else
            item.txtASSIGNMENT_ID.SetValue(ControlCustomValues("Assignment_mainttxtASSIGNMENT_ID"))
        End If
        Catch ae As ArgumentException
            Assignment_maintErrors.Add("txtASSIGNMENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Assignment ID"))
        End Try
        item.txtASSIGNMENT_DESCRIPTION.IsEmpty = IsNothing(Request.Form(Assignment_mainttxtASSIGNMENT_DESCRIPTION.UniqueID))
        If ControlCustomValues("Assignment_mainttxtASSIGNMENT_DESCRIPTION") Is Nothing Then
            item.txtASSIGNMENT_DESCRIPTION.SetValue(Assignment_mainttxtASSIGNMENT_DESCRIPTION.Text)
        Else
            item.txtASSIGNMENT_DESCRIPTION.SetValue(ControlCustomValues("Assignment_mainttxtASSIGNMENT_DESCRIPTION"))
        End If
        Try
        item.radioSTATUS.IsEmpty = IsNothing(Request.Form(Assignment_maintradioSTATUS.UniqueID))
        If Not IsNothing(Assignment_maintradioSTATUS.SelectedItem) Then
            item.radioSTATUS.SetValue(Assignment_maintradioSTATUS.SelectedItem.Value)
        Else
            item.radioSTATUS.Value = Nothing
        End If
        item.radioSTATUSItems.CopyFrom(Assignment_maintradioSTATUS.Items)
        Catch ae As ArgumentException
            Assignment_maintErrors.Add("radioSTATUS",String.Format(Resources.strings.CCS_IncorrectValue,"Status"))
        End Try
        item.hidden_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(Assignment_mainthidden_SUBJECT_ID.UniqueID))
        item.hidden_SUBJECT_ID.SetValue(Assignment_mainthidden_SUBJECT_ID.Value)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(Assignment_mainthidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(Assignment_mainthidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(Assignment_mainthidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(Assignment_mainthidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            Assignment_maintErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(Assignment_maintData)
        End If
        Assignment_maintErrors.Add(item.errors)
    End Sub
'End Record Form Assignment_maint LoadItemFromRequest method

'Record Form Assignment_maint GetRedirectUrl method @3-39198B0E

    Protected Function GetAssignment_maintRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "ASSIGNMENT_list.aspx"
        Dim p As String = parameters.ToString("GET","ASSIGNMENT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form Assignment_maint GetRedirectUrl method

'Record Form Assignment_maint ShowErrors method @3-0E4BCE04

    Protected Sub Assignment_maintShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To Assignment_maintErrors.Count - 1
        Select Case Assignment_maintErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & Assignment_maintErrors(i)
        End Select
        Next i
        Assignment_maintError.Visible = True
        Assignment_maintErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form Assignment_maint ShowErrors method

'Record Form Assignment_maint Insert Operation @3-CD460E6F

    Protected Sub Assignment_maint_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Assignment_maintItem = New Assignment_maintItem()
        Dim ExecuteFlag As Boolean = True
        Assignment_maintIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Assignment_maint Insert Operation

'Button Button_Insert OnClick. @7-26026B8B
        If CType(sender,Control).ID = "Assignment_maintButton_Insert" Then
            RedirectUrl = GetAssignment_maintRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @7-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form Assignment_maint BeforeInsert tail @3-495E268A
    Assignment_maintParameters()
    Assignment_maintLoadItemFromRequest(item, EnableValidation)
    If Assignment_maintOperations.AllowInsert Then
        ErrorFlag=(Assignment_maintErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                Assignment_maintData.InsertItem(item)
            Catch ex As Exception
                Assignment_maintErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form Assignment_maint BeforeInsert tail

'Record Form Assignment_maint AfterInsert tail  @3-3D18736F
        End If
        ErrorFlag=(Assignment_maintErrors.Count > 0)
        If ErrorFlag Then
            Assignment_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Assignment_maint AfterInsert tail 

'Record Form Assignment_maint Update Operation @3-2CA38E1A

    Protected Sub Assignment_maint_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Assignment_maintItem = New Assignment_maintItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        Assignment_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Assignment_maint Update Operation

'Button Button_Update OnClick. @8-AA3079D4
        If CType(sender,Control).ID = "Assignment_maintButton_Update" Then
            RedirectUrl = GetAssignment_maintRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @8-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form Assignment_maint Before Update tail @3-7C8640F1
        Assignment_maintParameters()
        Assignment_maintLoadItemFromRequest(item, EnableValidation)
        If Assignment_maintOperations.AllowUpdate Then
        ErrorFlag = (Assignment_maintErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                Assignment_maintData.UpdateItem(item)
            Catch ex As Exception
                Assignment_maintErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form Assignment_maint Before Update tail

'Record Form Assignment_maint Update Operation tail @3-3D18736F
        End If
        ErrorFlag=(Assignment_maintErrors.Count > 0)
        If ErrorFlag Then
            Assignment_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Assignment_maint Update Operation tail

'Record Form Assignment_maint Delete Operation @3-561ECB85
    Protected Sub Assignment_maint_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        Assignment_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As Assignment_maintItem = New Assignment_maintItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form Assignment_maint Delete Operation

'Record Form BeforeDelete tail @3-BCFBF5B3
        Assignment_maintParameters()
        Assignment_maintLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-EDBE4A85
        If ErrorFlag Then
            Assignment_maintShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form Assignment_maint Cancel Operation @3-B75E4717

    Protected Sub Assignment_maint_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Assignment_maintItem = New Assignment_maintItem()
        Assignment_maintIsSubmitted = True
        Dim RedirectUrl As String = ""
        Assignment_maintLoadItemFromRequest(item, False)
'End Record Form Assignment_maint Cancel Operation

'Button Button_Cancel OnClick. @9-EA78E2BF
    If CType(sender,Control).ID = "Assignment_maintButton_Cancel" Then
        RedirectUrl = GetAssignment_maintRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @9-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form Assignment_maint Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form Assignment_maint Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-BCE4ABAD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ASSIGNMENT_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Assignment_maintData = New Assignment_maintDataProvider()
        Assignment_maintOperations = New FormSupportedOperations(False, True, True, True, False)
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

