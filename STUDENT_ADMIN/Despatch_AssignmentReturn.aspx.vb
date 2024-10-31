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

Namespace DECV_PROD2007.Despatch_AssignmentReturn 'Namespace @1-B24195A7

'Forms Definition @1-74170A5B
Public Class [Despatch_AssignmentReturnPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F0BB0585
    Protected AssignmentReturnsData As AssignmentReturnsDataProvider
    Protected AssignmentReturnsErrors As NameValueCollection = New NameValueCollection()
    Protected AssignmentReturnsOperations As FormSupportedOperations
    Protected AssignmentReturnsIsSubmitted As Boolean = False
    Protected Despatch_AssignmentReturnContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E1890745
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            AssignmentReturnsShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form AssignmentReturns Parameters @3-853EAC7B

    Protected Sub AssignmentReturnsParameters()
        Dim item As new AssignmentReturnsItem
        Try
            AssignmentReturnsData.Ctrlstudentid = FloatParameter.GetParam(item.studentid.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReturnsData.CtrlENrolmentYear = FloatParameter.GetParam(item.ENrolmentYear.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReturnsData.Ctrlsubjectid = IntegerParameter.GetParam(item.subjectid.Value, ParameterSourceType.Control, "", Nothing, false)
            AssignmentReturnsData.ExprKey16 = IntegerParameter.GetParam(0, ParameterSourceType.Expression, "", Nothing, false)
            AssignmentReturnsData.Ctrlmarkerid = TextParameter.GetParam(item.markerid.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            AssignmentReturnsErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form AssignmentReturns Parameters

'Record Form AssignmentReturns Show method @3-89A2BFE8
    Protected Sub AssignmentReturnsShow()
        If AssignmentReturnsOperations.None Then
            AssignmentReturnsHolder.Visible = False
            Return
        End If
        Dim item As AssignmentReturnsItem = AssignmentReturnsItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not AssignmentReturnsOperations.AllowRead
        item.link_popupStudentSearchHref = "#"
        item.link_popupStudentSubjectSearchHref = "#"
        item.Link_ClearHref = "Despatch_AssignmentReturn.aspx"
        AssignmentReturnsErrors.Add(item.errors)
        If AssignmentReturnsErrors.Count > 0 Then
            AssignmentReturnsShowErrors()
            Return
        End If
'End Record Form AssignmentReturns Show method

'Record Form AssignmentReturns BeforeShow tail @3-402D3B18
        AssignmentReturnsParameters()
        AssignmentReturnsData.FillItem(item, IsInsertMode)
        AssignmentReturnsHolder.DataBind()
        AssignmentReturnsButton_Insert.Visible=IsInsertMode AndAlso AssignmentReturnsOperations.AllowInsert
        AssignmentReturnsstaffid.Text=item.staffid.GetFormattedValue()
        AssignmentReturnsstudentid.Text=item.studentid.GetFormattedValue()
        AssignmentReturnslink_popupStudentSearch.InnerText += item.link_popupStudentSearch.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReturnslink_popupStudentSearch.HRef = item.link_popupStudentSearchHref+item.link_popupStudentSearchHrefParameters.ToString("GET","", ViewState)
        AssignmentReturnssubjectid.Text=item.subjectid.GetFormattedValue()
        AssignmentReturnslink_popupStudentSubjectSearch.InnerText += item.link_popupStudentSubjectSearch.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReturnslink_popupStudentSubjectSearch.HRef = item.link_popupStudentSubjectSearchHref+item.link_popupStudentSubjectSearchHrefParameters.ToString("GET","", ViewState)
        AssignmentReturnsmarkerid.Text=item.markerid.GetFormattedValue()
        AssignmentReturnslblReceiptDate.Text = Server.HtmlEncode(item.lblReceiptDate.GetFormattedValue()).Replace(vbCrLf,"<br>")
        AssignmentReturnsENrolmentYear.Value = item.ENrolmentYear.GetFormattedValue()
        AssignmentReturnsLink_Clear.InnerText += item.Link_Clear.GetFormattedValue().Replace(vbCrLf,"")
        AssignmentReturnsLink_Clear.HRef = item.Link_ClearHref+item.Link_ClearHrefParameters.ToString("GET","studentid;subjectid;markerid;", ViewState)
'End Record Form AssignmentReturns BeforeShow tail

'TextBox staffid Event BeforeShow. Action Retrieve Value for Control @18-E7A13E3D
            AssignmentReturnsstaffid.Text = (New TextField("", System.Web.HttpContext.Current.Session("sessSTAFFID"))).GetFormattedValue()
'End TextBox staffid Event BeforeShow. Action Retrieve Value for Control

'Record Form AssignmentReturns Show method tail @3-DA961A5F
        If AssignmentReturnsErrors.Count > 0 Then
            AssignmentReturnsShowErrors()
        End If
    End Sub
'End Record Form AssignmentReturns Show method tail

'Record Form AssignmentReturns LoadItemFromRequest method @3-B1C26B8D

    Protected Sub AssignmentReturnsLoadItemFromRequest(item As AssignmentReturnsItem, ByVal EnableValidation As Boolean)
        item.staffid.IsEmpty = IsNothing(Request.Form(AssignmentReturnsstaffid.UniqueID))
        If ControlCustomValues("AssignmentReturnsstaffid") Is Nothing Then
            item.staffid.SetValue(AssignmentReturnsstaffid.Text)
        Else
            item.staffid.SetValue(ControlCustomValues("AssignmentReturnsstaffid"))
        End If
        item.studentid.IsEmpty = IsNothing(Request.Form(AssignmentReturnsstudentid.UniqueID))
        If ControlCustomValues("AssignmentReturnsstudentid") Is Nothing Then
            item.studentid.SetValue(AssignmentReturnsstudentid.Text)
        Else
            item.studentid.SetValue(ControlCustomValues("AssignmentReturnsstudentid"))
        End If
        item.subjectid.IsEmpty = IsNothing(Request.Form(AssignmentReturnssubjectid.UniqueID))
        If ControlCustomValues("AssignmentReturnssubjectid") Is Nothing Then
            item.subjectid.SetValue(AssignmentReturnssubjectid.Text)
        Else
            item.subjectid.SetValue(ControlCustomValues("AssignmentReturnssubjectid"))
        End If
        item.markerid.IsEmpty = IsNothing(Request.Form(AssignmentReturnsmarkerid.UniqueID))
        If ControlCustomValues("AssignmentReturnsmarkerid") Is Nothing Then
            item.markerid.SetValue(AssignmentReturnsmarkerid.Text)
        Else
            item.markerid.SetValue(ControlCustomValues("AssignmentReturnsmarkerid"))
        End If
        item.ENrolmentYear.IsEmpty = IsNothing(Request.Form(AssignmentReturnsENrolmentYear.UniqueID))
        item.ENrolmentYear.SetValue(AssignmentReturnsENrolmentYear.Value)
        If EnableValidation Then
            item.Validate(AssignmentReturnsData)
        End If
        AssignmentReturnsErrors.Add(item.errors)
    End Sub
'End Record Form AssignmentReturns LoadItemFromRequest method

'Record Form AssignmentReturns GetRedirectUrl method @3-3D1FE688

    Protected Function GetAssignmentReturnsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Despatch_AssignmentReturn.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form AssignmentReturns GetRedirectUrl method

'Record Form AssignmentReturns ShowErrors method @3-88DD0DD8

    Protected Sub AssignmentReturnsShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To AssignmentReturnsErrors.Count - 1
        Select Case AssignmentReturnsErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & AssignmentReturnsErrors(i)
        End Select
        Next i
        AssignmentReturnsError.Visible = True
        AssignmentReturnsErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form AssignmentReturns ShowErrors method

'Record Form AssignmentReturns Insert Operation @3-D9601736

    Protected Sub AssignmentReturns_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReturnsItem = New AssignmentReturnsItem()
        Dim ExecuteFlag As Boolean = True
        AssignmentReturnsIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AssignmentReturns Insert Operation

'Button Button_Insert OnClick. @9-AEFDBE0D
        If CType(sender,Control).ID = "AssignmentReturnsButton_Insert" Then
            RedirectUrl = GetAssignmentReturnsRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert Event OnClick. Action Save Control Value @19-94EE85B2
        System.Web.HttpContext.Current.Session("sessSTAFFID")=AssignmentReturnsstaffid.Text
'End Button Button_Insert Event OnClick. Action Save Control Value

'DEL      ' -------------------------
'DEL      'ERA: grab STAFFID from listbox and add to URL to allow default selection 
'DEL  	Dim params As New LinkParameterCollection()
'DEL      params.Add("StaffID",item.staffid.value)
'DEL      ' -------------------------


'Button Button_Insert OnClick tail. @9-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form AssignmentReturns BeforeInsert tail @3-ABFC5146
    AssignmentReturnsParameters()
    AssignmentReturnsLoadItemFromRequest(item, EnableValidation)
    If AssignmentReturnsOperations.AllowInsert Then
        ErrorFlag=(AssignmentReturnsErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                AssignmentReturnsData.InsertItem(item)
            Catch ex As Exception
                AssignmentReturnsErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form AssignmentReturns BeforeInsert tail

'Record Form AssignmentReturns AfterInsert tail  @3-FC6089B8
        End If
        ErrorFlag=(AssignmentReturnsErrors.Count > 0)
        If ErrorFlag Then
            AssignmentReturnsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AssignmentReturns AfterInsert tail 

'Record Form AssignmentReturns Update Operation @3-90DDF593

    Protected Sub AssignmentReturns_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReturnsItem = New AssignmentReturnsItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        AssignmentReturnsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AssignmentReturns Update Operation

'Record Form AssignmentReturns Before Update tail @3-687578B7
        AssignmentReturnsParameters()
        AssignmentReturnsLoadItemFromRequest(item, EnableValidation)
'End Record Form AssignmentReturns Before Update tail

'Record Form AssignmentReturns Update Operation tail @3-6973D660
        ErrorFlag=(AssignmentReturnsErrors.Count > 0)
        If ErrorFlag Then
            AssignmentReturnsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AssignmentReturns Update Operation tail

'Record Form AssignmentReturns Delete Operation @3-A31133C5
    Protected Sub AssignmentReturns_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        AssignmentReturnsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As AssignmentReturnsItem = New AssignmentReturnsItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form AssignmentReturns Delete Operation

'Record Form BeforeDelete tail @3-687578B7
        AssignmentReturnsParameters()
        AssignmentReturnsLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-CA74ABDA
        If ErrorFlag Then
            AssignmentReturnsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form AssignmentReturns Cancel Operation @3-D825EA4A

    Protected Sub AssignmentReturns_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AssignmentReturnsItem = New AssignmentReturnsItem()
        AssignmentReturnsIsSubmitted = True
        Dim RedirectUrl As String = ""
        AssignmentReturnsLoadItemFromRequest(item, True)
'End Record Form AssignmentReturns Cancel Operation

'Record Form AssignmentReturns Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form AssignmentReturns Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-905D5603
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Despatch_AssignmentReturnContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        AssignmentReturnsData = New AssignmentReturnsDataProvider()
        AssignmentReturnsOperations = New FormSupportedOperations(False, False, True, False, False)
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

