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

Namespace DECV_PROD2007.FinancialAccounts_comments_maintain 'Namespace @1-5A29E4EE

'Forms Definition @1-4253E524
Public Class [FinancialAccounts_comments_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-0C5D2005
    Protected txnData As txnDataProvider
    Protected txnErrors As NameValueCollection = New NameValueCollection()
    Protected txnOperations As FormSupportedOperations
    Protected txnIsSubmitted As Boolean = False
    Protected FinancialAccounts_comments_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CDDFD251
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BackHref = "FinancialAccounts_maintain.aspx"
            PageData.FillItem(item)
            Link_Back.InnerText += item.Link_Back.GetFormattedValue().Replace(vbCrLf,"")
            Link_Back.HRef = item.Link_BackHref+item.Link_BackHrefParameters.ToString("GET","", ViewState)
            Link_Back.DataBind()
            txnShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form txn Parameters @3-88CA27DD

    Protected Sub txnParameters()
        Dim item As new txnItem
        Try
            txnData.UrlTXN_ID = FloatParameter.GetParam("TXN_ID", ParameterSourceType.URL, "", Nothing, false)
            txnData.CtrlTXN_ID = FloatParameter.GetParam(item.TXN_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            txnData.SesUserID = TextParameter.GetParam("UserID", ParameterSourceType.Session, "", Nothing, false)
            txnData.Expr23 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            txnData.CtrlCOMMENTS = TextParameter.GetParam(item.COMMENTS.Value, ParameterSourceType.Control, "", Nothing, false)
            txnData.CtrlRECEIPT_NO = TextParameter.GetParam(item.RECEIPT_NO.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            txnErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form txn Parameters

'Record Form txn Show method @3-C79FE585
    Protected Sub txnShow()
        If txnOperations.None Then
            txnHolder.Visible = False
            Return
        End If
        Dim item As txnItem = txnItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not txnOperations.AllowRead
        txnErrors.Add(item.errors)
        If txnErrors.Count > 0 Then
            txnShowErrors()
            Return
        End If
'End Record Form txn Show method

'Record Form txn BeforeShow tail @3-37CE5BCD
        txnParameters()
        txnData.FillItem(item, IsInsertMode)
        txnHolder.DataBind()
        txnButton_Update.Visible=Not (IsInsertMode) AndAlso txnOperations.AllowUpdate
        txnTXN_ID.Value = item.TXN_ID.GetFormattedValue()
        txnSTUDENT_ID.Text = Server.HtmlEncode(item.STUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnENROLMENT_YEAR.Text = Server.HtmlEncode(item.ENROLMENT_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnTRANS_DATE.Text = Server.HtmlEncode(item.TRANS_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnTRANS_CODE.Text = Server.HtmlEncode(item.TRANS_CODE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnAMOUNT.Text = Server.HtmlEncode(item.AMOUNT.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnCR_DR_FLAG.Text = Server.HtmlEncode(item.CR_DR_FLAG.GetFormattedValue()).Replace(vbCrLf,"<br>")
        txnCOMMENTS.Text=item.COMMENTS.GetFormattedValue()
        txnRECEIPT_NO.Text=item.RECEIPT_NO.GetFormattedValue()
'End Record Form txn BeforeShow tail

'Record Form txn Show method tail @3-F95F995F
        If txnErrors.Count > 0 Then
            txnShowErrors()
        End If
    End Sub
'End Record Form txn Show method tail

'Record Form txn LoadItemFromRequest method @3-62959547

    Protected Sub txnLoadItemFromRequest(item As txnItem, ByVal EnableValidation As Boolean)
        Try
        item.TXN_ID.IsEmpty = IsNothing(Request.Form(txnTXN_ID.UniqueID))
        item.TXN_ID.SetValue(txnTXN_ID.Value)
        Catch ae As ArgumentException
            txnErrors.Add("TXN_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Transaction ID"))
        End Try
        item.COMMENTS.IsEmpty = IsNothing(Request.Form(txnCOMMENTS.UniqueID))
        If ControlCustomValues("txnCOMMENTS") Is Nothing Then
            item.COMMENTS.SetValue(txnCOMMENTS.Text)
        Else
            item.COMMENTS.SetValue(ControlCustomValues("txnCOMMENTS"))
        End If
        item.RECEIPT_NO.IsEmpty = IsNothing(Request.Form(txnRECEIPT_NO.UniqueID))
        If ControlCustomValues("txnRECEIPT_NO") Is Nothing Then
            item.RECEIPT_NO.SetValue(txnRECEIPT_NO.Text)
        Else
            item.RECEIPT_NO.SetValue(ControlCustomValues("txnRECEIPT_NO"))
        End If
        If EnableValidation Then
            item.Validate(txnData)
        End If
        txnErrors.Add(item.errors)
    End Sub
'End Record Form txn LoadItemFromRequest method

'Record Form txn GetRedirectUrl method @3-01F60621

    Protected Function GettxnRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FinancialAccounts_maintain.aspx"
        Dim p As String = parameters.ToString("GET","TXN_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form txn GetRedirectUrl method

'Record Form txn ShowErrors method @3-791E75B0

    Protected Sub txnShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To txnErrors.Count - 1
        Select Case txnErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & txnErrors(i)
        End Select
        Next i
        txnError.Visible = True
        txnErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form txn ShowErrors method

'Record Form txn Insert Operation @3-11CFB799

    Protected Sub txn_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        txnIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Insert Operation

'Record Form txn BeforeInsert tail @3-E6529729
    txnParameters()
    txnLoadItemFromRequest(item, EnableValidation)
'End Record Form txn BeforeInsert tail

'Record Form txn AfterInsert tail  @3-D1CD6F2C
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn AfterInsert tail 

'Record Form txn Update Operation @3-DE80C356

    Protected Sub txn_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Update Operation

'Button Button_Update OnClick. @4-28D3DDE8
        If CType(sender,Control).ID = "txnButton_Update" Then
            RedirectUrl = GettxnRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form txn Before Update tail @3-54400267
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
        If txnOperations.AllowUpdate Then
        ErrorFlag = (txnErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                txnData.UpdateItem(item)
            Catch ex As Exception
                txnErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form txn Before Update tail

'Record Form txn Update Operation tail @3-B92F6AE8
        End If
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn Update Operation tail

'Record Form txn Delete Operation @3-72AB614A
    Protected Sub txn_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As txnItem = New txnItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form txn Delete Operation

'Record Form BeforeDelete tail @3-E6529729
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-E92D4CBE
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form txn Cancel Operation @3-56F1D758

    Protected Sub txn_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        txnLoadItemFromRequest(item, False)
'End Record Form txn Cancel Operation

'Button Button_Cancel OnClick. @19-85E518DA
    If CType(sender,Control).ID = "txnButton_Cancel" Then
        RedirectUrl = GettxnRedirectUrl("FinancialAccounts_maintain.aspx", "TXN_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @19-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form txn Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form txn Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-DE181E31
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FinancialAccounts_comments_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        txnData = New txnDataProvider()
        txnOperations = New FormSupportedOperations(False, True, False, True, False)
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

