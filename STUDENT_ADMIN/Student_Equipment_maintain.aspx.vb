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

Namespace DECV_PROD2007.Student_Equipment_maintain 'Namespace @1-76AAA24A

'Forms Definition @1-C6BD6F6B
Public Class [Student_Equipment_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-034C0140
    Protected STUDENT_EQUIPMENTData As STUDENT_EQUIPMENTDataProvider
    Protected STUDENT_EQUIPMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_EQUIPMENTOperations As FormSupportedOperations
    Protected STUDENT_EQUIPMENTIsSubmitted As Boolean = False
    Protected Student_Equipment_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E97160C5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_EQUIPMENTShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_EQUIPMENT Parameters @2-1C6F643D

    Protected Sub STUDENT_EQUIPMENTParameters()
        Dim item As new STUDENT_EQUIPMENTItem
        Try
            STUDENT_EQUIPMENTData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_EQUIPMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_EQUIPMENT Parameters

'Record Form STUDENT_EQUIPMENT Show method @2-00FDE07A
    Protected Sub STUDENT_EQUIPMENTShow()
        If STUDENT_EQUIPMENTOperations.None Then
            STUDENT_EQUIPMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_EQUIPMENTItem = STUDENT_EQUIPMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_EQUIPMENTOperations.AllowRead
        STUDENT_EQUIPMENTErrors.Add(item.errors)
        If STUDENT_EQUIPMENTErrors.Count > 0 Then
            STUDENT_EQUIPMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_EQUIPMENT Show method

'Record Form STUDENT_EQUIPMENT BeforeShow tail @2-F16B3AFF
        STUDENT_EQUIPMENTParameters()
        STUDENT_EQUIPMENTData.FillItem(item, IsInsertMode)
        STUDENT_EQUIPMENTHolder.DataBind()
        STUDENT_EQUIPMENTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_EQUIPMENTOperations.AllowUpdate
        item.HAS_COMPUTERItems.SetSelection(item.HAS_COMPUTER.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_COMPUTER.SelectedIndex = -1
        item.HAS_COMPUTERItems.CopyTo(STUDENT_EQUIPMENTHAS_COMPUTER.Items)
        item.HAS_VCRItems.SetSelection(item.HAS_VCR.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_VCR.SelectedIndex = -1
        item.HAS_VCRItems.CopyTo(STUDENT_EQUIPMENTHAS_VCR.Items)
        item.HAS_DVDItems.SetSelection(item.HAS_DVD.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_DVD.SelectedIndex = -1
        item.HAS_DVDItems.CopyTo(STUDENT_EQUIPMENTHAS_DVD.Items)
        item.HAS_INTERNET_ACCESSItems.SetSelection(item.HAS_INTERNET_ACCESS.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.SelectedIndex = -1
        item.HAS_INTERNET_ACCESSItems.CopyTo(STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.Items)
        STUDENT_EQUIPMENTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_EQUIPMENTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.HAS_BROADBANDItems.SetSelection(item.HAS_BROADBAND.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_BROADBAND.SelectedIndex = -1
        item.HAS_BROADBANDItems.CopyTo(STUDENT_EQUIPMENTHAS_BROADBAND.Items)
        If item.NEWSLETTER_BYMAILCheckedValue.Value.Equals(item.NEWSLETTER_BYMAIL.Value) Then
            STUDENT_EQUIPMENTNEWSLETTER_BYMAIL.Checked = True
        End If
        STUDENT_EQUIPMENTHidden_lastalteredby.Value = item.Hidden_lastalteredby.GetFormattedValue()
        STUDENT_EQUIPMENTHidden_lastaltereddate.Value = item.Hidden_lastaltereddate.GetFormattedValue()
        item.SHARES_COMPUTERItems.SetSelection(item.SHARES_COMPUTER.GetFormattedValue())
        STUDENT_EQUIPMENTSHARES_COMPUTER.SelectedIndex = -1
        item.SHARES_COMPUTERItems.CopyTo(STUDENT_EQUIPMENTSHARES_COMPUTER.Items)
        item.LIMITED_INTERNET_ACCESSItems.SetSelection(item.LIMITED_INTERNET_ACCESS.GetFormattedValue())
        STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.SelectedIndex = -1
        item.LIMITED_INTERNET_ACCESSItems.CopyTo(STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.Items)
        item.HAS_DER_PCItems.SetSelection(item.HAS_DER_PC.GetFormattedValue())
        STUDENT_EQUIPMENTHAS_DER_PC.SelectedIndex = -1
        item.HAS_DER_PCItems.CopyTo(STUDENT_EQUIPMENTHAS_DER_PC.Items)
        STUDENT_EQUIPMENTlblStudentNo.Text = Server.HtmlEncode(item.lblStudentNo.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.ACCESS_COMPUTERItems.SetSelection(item.ACCESS_COMPUTER.GetFormattedValue())
        STUDENT_EQUIPMENTACCESS_COMPUTER.SelectedIndex = -1
        item.ACCESS_COMPUTERItems.CopyTo(STUDENT_EQUIPMENTACCESS_COMPUTER.Items)
        item.ACCESS_INTERNETItems.SetSelection(item.ACCESS_INTERNET.GetFormattedValue())
        STUDENT_EQUIPMENTACCESS_INTERNET.SelectedIndex = -1
        item.ACCESS_INTERNETItems.CopyTo(STUDENT_EQUIPMENTACCESS_INTERNET.Items)
        item.ACCESS_WORKEXAMPLES_radioItems.SetSelection(item.ACCESS_WORKEXAMPLES_radio.GetFormattedValue())
        STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.SelectedIndex = -1
        item.ACCESS_WORKEXAMPLES_radioItems.CopyTo(STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.Items)
'End Record Form STUDENT_EQUIPMENT BeforeShow tail

'Record Form STUDENT_EQUIPMENT Show method tail @2-F2263E37
        If STUDENT_EQUIPMENTErrors.Count > 0 Then
            STUDENT_EQUIPMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_EQUIPMENT Show method tail

'Record Form STUDENT_EQUIPMENT LoadItemFromRequest method @2-A6312C40

    Protected Sub STUDENT_EQUIPMENTLoadItemFromRequest(item As STUDENT_EQUIPMENTItem, ByVal EnableValidation As Boolean)
        item.HAS_COMPUTER.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_COMPUTER.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_COMPUTER.SelectedItem) Then
            item.HAS_COMPUTER.SetValue(STUDENT_EQUIPMENTHAS_COMPUTER.SelectedItem.Value)
        Else
            item.HAS_COMPUTER.Value = Nothing
        End If
        item.HAS_COMPUTERItems.CopyFrom(STUDENT_EQUIPMENTHAS_COMPUTER.Items)
        item.HAS_VCR.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_VCR.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_VCR.SelectedItem) Then
            item.HAS_VCR.SetValue(STUDENT_EQUIPMENTHAS_VCR.SelectedItem.Value)
        Else
            item.HAS_VCR.Value = Nothing
        End If
        item.HAS_VCRItems.CopyFrom(STUDENT_EQUIPMENTHAS_VCR.Items)
        item.HAS_DVD.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_DVD.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_DVD.SelectedItem) Then
            item.HAS_DVD.SetValue(STUDENT_EQUIPMENTHAS_DVD.SelectedItem.Value)
        Else
            item.HAS_DVD.Value = Nothing
        End If
        item.HAS_DVDItems.CopyFrom(STUDENT_EQUIPMENTHAS_DVD.Items)
        item.HAS_INTERNET_ACCESS.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.SelectedItem) Then
            item.HAS_INTERNET_ACCESS.SetValue(STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.SelectedItem.Value)
        Else
            item.HAS_INTERNET_ACCESS.Value = Nothing
        End If
        item.HAS_INTERNET_ACCESSItems.CopyFrom(STUDENT_EQUIPMENTHAS_INTERNET_ACCESS.Items)
        item.HAS_BROADBAND.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_BROADBAND.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_BROADBAND.SelectedItem) Then
            item.HAS_BROADBAND.SetValue(STUDENT_EQUIPMENTHAS_BROADBAND.SelectedItem.Value)
        Else
            item.HAS_BROADBAND.Value = Nothing
        End If
        item.HAS_BROADBANDItems.CopyFrom(STUDENT_EQUIPMENTHAS_BROADBAND.Items)
        If STUDENT_EQUIPMENTNEWSLETTER_BYMAIL.Checked Then
            item.NEWSLETTER_BYMAIL.Value = (item.NEWSLETTER_BYMAILCheckedValue.Value)
        Else
            item.NEWSLETTER_BYMAIL.Value = (item.NEWSLETTER_BYMAILUncheckedValue.Value)
        End If
        item.Hidden_lastalteredby.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHidden_lastalteredby.UniqueID))
        item.Hidden_lastalteredby.SetValue(STUDENT_EQUIPMENTHidden_lastalteredby.Value)
        Try
        item.Hidden_lastaltereddate.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHidden_lastaltereddate.UniqueID))
        item.Hidden_lastaltereddate.SetValue(STUDENT_EQUIPMENTHidden_lastaltereddate.Value)
        Catch ae As ArgumentException
            STUDENT_EQUIPMENTErrors.Add("Hidden_lastaltereddate",String.Format(Resources.strings.CCS_IncorrectFormat,"Hidden_lastaltereddate","yyyy-mm-dd H:nn"))
        End Try
        item.SHARES_COMPUTER.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTSHARES_COMPUTER.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTSHARES_COMPUTER.SelectedItem) Then
            item.SHARES_COMPUTER.SetValue(STUDENT_EQUIPMENTSHARES_COMPUTER.SelectedItem.Value)
        Else
            item.SHARES_COMPUTER.Value = Nothing
        End If
        item.SHARES_COMPUTERItems.CopyFrom(STUDENT_EQUIPMENTSHARES_COMPUTER.Items)
        item.LIMITED_INTERNET_ACCESS.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.SelectedItem) Then
            item.LIMITED_INTERNET_ACCESS.SetValue(STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.SelectedItem.Value)
        Else
            item.LIMITED_INTERNET_ACCESS.Value = Nothing
        End If
        item.LIMITED_INTERNET_ACCESSItems.CopyFrom(STUDENT_EQUIPMENTLIMITED_INTERNET_ACCESS.Items)
        item.HAS_DER_PC.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTHAS_DER_PC.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTHAS_DER_PC.SelectedItem) Then
            item.HAS_DER_PC.SetValue(STUDENT_EQUIPMENTHAS_DER_PC.SelectedItem.Value)
        Else
            item.HAS_DER_PC.Value = Nothing
        End If
        item.HAS_DER_PCItems.CopyFrom(STUDENT_EQUIPMENTHAS_DER_PC.Items)
        item.ACCESS_COMPUTER.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTACCESS_COMPUTER.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTACCESS_COMPUTER.SelectedItem) Then
            item.ACCESS_COMPUTER.SetValue(STUDENT_EQUIPMENTACCESS_COMPUTER.SelectedItem.Value)
        Else
            item.ACCESS_COMPUTER.Value = Nothing
        End If
        item.ACCESS_COMPUTERItems.CopyFrom(STUDENT_EQUIPMENTACCESS_COMPUTER.Items)
        item.ACCESS_INTERNET.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTACCESS_INTERNET.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTACCESS_INTERNET.SelectedItem) Then
            item.ACCESS_INTERNET.SetValue(STUDENT_EQUIPMENTACCESS_INTERNET.SelectedItem.Value)
        Else
            item.ACCESS_INTERNET.Value = Nothing
        End If
        item.ACCESS_INTERNETItems.CopyFrom(STUDENT_EQUIPMENTACCESS_INTERNET.Items)
        item.ACCESS_WORKEXAMPLES_radio.IsEmpty = IsNothing(Request.Form(STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.UniqueID))
        If Not IsNothing(STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.SelectedItem) Then
            item.ACCESS_WORKEXAMPLES_radio.SetValue(STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.SelectedItem.Value)
        Else
            item.ACCESS_WORKEXAMPLES_radio.Value = Nothing
        End If
        item.ACCESS_WORKEXAMPLES_radioItems.CopyFrom(STUDENT_EQUIPMENTACCESS_WORKEXAMPLES_radio.Items)
        If EnableValidation Then
            item.Validate(STUDENT_EQUIPMENTData)
        End If
        STUDENT_EQUIPMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_EQUIPMENT LoadItemFromRequest method

'Record Form STUDENT_EQUIPMENT GetRedirectUrl method @2-5A92C4EF

    Protected Function GetSTUDENT_EQUIPMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_EQUIPMENT GetRedirectUrl method

'Record Form STUDENT_EQUIPMENT ShowErrors method @2-E6C3279E

    Protected Sub STUDENT_EQUIPMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_EQUIPMENTErrors.Count - 1
        Select Case STUDENT_EQUIPMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_EQUIPMENTErrors(i)
        End Select
        Next i
        STUDENT_EQUIPMENTError.Visible = True
        STUDENT_EQUIPMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_EQUIPMENT ShowErrors method

'Record Form STUDENT_EQUIPMENT Insert Operation @2-D1880367

    Protected Sub STUDENT_EQUIPMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
        STUDENT_EQUIPMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_EQUIPMENT Insert Operation

'Record Form STUDENT_EQUIPMENT BeforeInsert tail @2-EE3BC381
    STUDENT_EQUIPMENTParameters()
    STUDENT_EQUIPMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_EQUIPMENT BeforeInsert tail

'Record Form STUDENT_EQUIPMENT AfterInsert tail  @2-B68ECD96
        ErrorFlag=(STUDENT_EQUIPMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_EQUIPMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_EQUIPMENT AfterInsert tail 

'Record Form STUDENT_EQUIPMENT Update Operation @2-E0509EAD

    Protected Sub STUDENT_EQUIPMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_EQUIPMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_EQUIPMENT Update Operation

'Button Button_Update OnClick. @3-39046060
        If CType(sender,Control).ID = "STUDENT_EQUIPMENTButton_Update" Then
            RedirectUrl = GetSTUDENT_EQUIPMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @3-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_EQUIPMENT Event BeforeUpdate. Action Retrieve Value for Control @18-46709779
        STUDENT_EQUIPMENTHidden_lastalteredby.Value = (New TextField("", (DBUtility.UserId.ToUpper()))).GetFormattedValue()
'End Record STUDENT_EQUIPMENT Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_EQUIPMENT Event BeforeUpdate. Action Retrieve Value for Control @19-201D1279
        STUDENT_EQUIPMENTHidden_lastaltereddate.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_EQUIPMENT Event BeforeUpdate. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL      ' ERA: 1-Dec-2008|EA| update last altered by and date
'DEL    		item.hidden_lastalteredby.setvalue(dbutility.userid.tostring)
'DEL  		item.hidden_lastaltereddate.setvalue(datetime.now, "yyyy-MM-dd H\:mm")
'DEL  	
'DEL      ' -------------------------


'Record Form STUDENT_EQUIPMENT Before Update tail @2-B6513EC6
        STUDENT_EQUIPMENTParameters()
        STUDENT_EQUIPMENTLoadItemFromRequest(item, EnableValidation)
        If STUDENT_EQUIPMENTOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_EQUIPMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_EQUIPMENTData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_EQUIPMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_EQUIPMENT Before Update tail

'Record Form STUDENT_EQUIPMENT Update Operation tail @2-239D924E
        End If
        ErrorFlag=(STUDENT_EQUIPMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_EQUIPMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_EQUIPMENT Update Operation tail

'Record Form STUDENT_EQUIPMENT Delete Operation @2-F124D450
    Protected Sub STUDENT_EQUIPMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_EQUIPMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_EQUIPMENT Delete Operation

'Record Form BeforeDelete tail @2-EE3BC381
        STUDENT_EQUIPMENTParameters()
        STUDENT_EQUIPMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-C2F90D43
        If ErrorFlag Then
            STUDENT_EQUIPMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_EQUIPMENT Cancel Operation @2-3D97440F

    Protected Sub STUDENT_EQUIPMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_EQUIPMENTItem = New STUDENT_EQUIPMENTItem()
        STUDENT_EQUIPMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_EQUIPMENTLoadItemFromRequest(item, False)
'End Record Form STUDENT_EQUIPMENT Cancel Operation

'Button Button_Cancel OnClick. @4-5B9B52F8
    If CType(sender,Control).ID = "STUDENT_EQUIPMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_EQUIPMENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @4-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_EQUIPMENT Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_EQUIPMENT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3BA58620
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Equipment_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_EQUIPMENTData = New STUDENT_EQUIPMENTDataProvider()
        STUDENT_EQUIPMENTOperations = New FormSupportedOperations(False, True, False, True, False)
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

