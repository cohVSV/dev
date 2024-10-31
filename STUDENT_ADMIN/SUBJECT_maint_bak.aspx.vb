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

Namespace DECV_PROD2007.SUBJECT_maint_bak 'Namespace @1-A87F4933

'Forms Definition @1-ED197BC3
Public Class [SUBJECT_maint_bakPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-76EFA3F2
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTIsSubmitted As Boolean = False
    Protected SUBJECT_maint_bakContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A87BF994
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "SUBJECT_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            SUBJECTShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SUBJECT Parameters @2-B23250CA

    Protected Sub SUBJECTParameters()
        Dim item As new SUBJECTItem
        Try
            SUBJECTData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            SUBJECTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECT Parameters

'Record Form SUBJECT Show method @2-ED30189C
    Protected Sub SUBJECTShow()
        If SUBJECTOperations.None Then
            SUBJECTHolder.Visible = False
            Return
        End If
        Dim item As SUBJECTItem = SUBJECTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECTOperations.AllowRead
        SUBJECTErrors.Add(item.errors)
        If SUBJECTErrors.Count > 0 Then
            SUBJECTShowErrors()
            Return
        End If
'End Record Form SUBJECT Show method

'Record Form SUBJECT BeforeShow tail @2-F94D7FB5
        SUBJECTParameters()
        SUBJECTData.FillItem(item, IsInsertMode)
        SUBJECTHolder.DataBind()
        SUBJECTButton_Insert.Visible=IsInsertMode AndAlso SUBJECTOperations.AllowInsert
        SUBJECTButton_Update.Visible=Not (IsInsertMode) AndAlso SUBJECTOperations.AllowUpdate
        SUBJECTButton_Delete.Visible=Not (IsInsertMode) AndAlso SUBJECTOperations.AllowDelete
        SUBJECTtxtNewSubjectID.Text=item.txtNewSubjectID.GetFormattedValue()
        SUBJECTlblSubjectID.Text = Server.HtmlEncode(item.lblSubjectID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SUBJECTSUBJECT_ABBREV.Text=item.SUBJECT_ABBREV.GetFormattedValue()
        SUBJECTSUBJECT_TITLE.Text=item.SUBJECT_TITLE.GetFormattedValue()
        SUBJECTCAMPUS_CODE.Items.Add(new ListItem("Select Value",""))
        SUBJECTCAMPUS_CODE.Items(0).Selected = True
        item.CAMPUS_CODEItems.SetSelection(item.CAMPUS_CODE.GetFormattedValue())
        If Not item.CAMPUS_CODEItems.GetSelectedItem() Is Nothing Then
            SUBJECTCAMPUS_CODE.SelectedIndex = -1
        End If
        item.CAMPUS_CODEItems.CopyTo(SUBJECTCAMPUS_CODE.Items)
        SUBJECTYEAR_LEVEL.Text=item.YEAR_LEVEL.GetFormattedValue()
        SUBJECTDEFAULT_SEMESTER.Text=item.DEFAULT_SEMESTER.GetFormattedValue()
        SUBJECTDEFAULT_TEACHER_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECTDEFAULT_TEACHER_ID.Items(0).Selected = True
        item.DEFAULT_TEACHER_IDItems.SetSelection(item.DEFAULT_TEACHER_ID.GetFormattedValue())
        If Not item.DEFAULT_TEACHER_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECTDEFAULT_TEACHER_ID.SelectedIndex = -1
        End If
        item.DEFAULT_TEACHER_IDItems.CopyTo(SUBJECTDEFAULT_TEACHER_ID.Items)
        SUBJECTSUB_SCHOOL.Text=item.SUB_SCHOOL.GetFormattedValue()
        SUBJECTKLA_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECTKLA_ID.Items(0).Selected = True
        item.KLA_IDItems.SetSelection(item.KLA_ID.GetFormattedValue())
        If Not item.KLA_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECTKLA_ID.SelectedIndex = -1
        End If
        item.KLA_IDItems.CopyTo(SUBJECTKLA_ID.Items)
        SUBJECTCSF_CLASS_LEVEL.Text=item.CSF_CLASS_LEVEL.GetFormattedValue()
        SUBJECTMAX_BOOKS.Text=item.MAX_BOOKS.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("VALID_COURSE_DISTRIBUTION")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("VALID_COURSE_DISTRIBUTION").GetUpperBound(0)
                item.VALID_COURSE_DISTRIBUTIONItems.SetSelection(Request.QueryString.GetValues("VALID_COURSE_DISTRIBUTION")(i))
            Next i
        End If
        item.VALID_COURSE_DISTRIBUTIONItems.SetSelection(item.VALID_COURSE_DISTRIBUTION.Value)
        SUBJECTVALID_COURSE_DISTRIBUTION.SelectedIndex = -1
        item.VALID_COURSE_DISTRIBUTIONItems.CopyTo(SUBJECTVALID_COURSE_DISTRIBUTION.Items)
        SUBJECTDESCRIPTION_LINE1.Text=item.DESCRIPTION_LINE1.GetFormattedValue()
        SUBJECTDESCRIPTION_LINE2.Text=item.DESCRIPTION_LINE2.GetFormattedValue()
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        SUBJECTSTATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(SUBJECTSTATUS.Items)
        SUBJECTLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SUBJECTLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form SUBJECT BeforeShow tail

'Record Form SUBJECT Show method tail @2-FF6A7B6B
        If SUBJECTErrors.Count > 0 Then
            SUBJECTShowErrors()
        End If
    End Sub
'End Record Form SUBJECT Show method tail

'Record Form SUBJECT LoadItemFromRequest method @2-3156AE39

    Protected Sub SUBJECTLoadItemFromRequest(item As SUBJECTItem, ByVal EnableValidation As Boolean)
        item.txtNewSubjectID.IsEmpty = IsNothing(Request.Form(SUBJECTtxtNewSubjectID.UniqueID))
        If ControlCustomValues("SUBJECTtxtNewSubjectID") Is Nothing Then
            item.txtNewSubjectID.SetValue(SUBJECTtxtNewSubjectID.Text)
        Else
            item.txtNewSubjectID.SetValue(ControlCustomValues("SUBJECTtxtNewSubjectID"))
        End If
        item.SUBJECT_ABBREV.IsEmpty = IsNothing(Request.Form(SUBJECTSUBJECT_ABBREV.UniqueID))
        If ControlCustomValues("SUBJECTSUBJECT_ABBREV") Is Nothing Then
            item.SUBJECT_ABBREV.SetValue(SUBJECTSUBJECT_ABBREV.Text)
        Else
            item.SUBJECT_ABBREV.SetValue(ControlCustomValues("SUBJECTSUBJECT_ABBREV"))
        End If
        item.SUBJECT_TITLE.IsEmpty = IsNothing(Request.Form(SUBJECTSUBJECT_TITLE.UniqueID))
        If ControlCustomValues("SUBJECTSUBJECT_TITLE") Is Nothing Then
            item.SUBJECT_TITLE.SetValue(SUBJECTSUBJECT_TITLE.Text)
        Else
            item.SUBJECT_TITLE.SetValue(ControlCustomValues("SUBJECTSUBJECT_TITLE"))
        End If
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(SUBJECTCAMPUS_CODE.UniqueID))
        item.CAMPUS_CODE.SetValue(SUBJECTCAMPUS_CODE.Value)
        item.CAMPUS_CODEItems.CopyFrom(SUBJECTCAMPUS_CODE.Items)
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(SUBJECTYEAR_LEVEL.UniqueID))
        If ControlCustomValues("SUBJECTYEAR_LEVEL") Is Nothing Then
            item.YEAR_LEVEL.SetValue(SUBJECTYEAR_LEVEL.Text)
        Else
            item.YEAR_LEVEL.SetValue(ControlCustomValues("SUBJECTYEAR_LEVEL"))
        End If
        Catch ae As ArgumentException
            SUBJECTErrors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.DEFAULT_SEMESTER.IsEmpty = IsNothing(Request.Form(SUBJECTDEFAULT_SEMESTER.UniqueID))
        If ControlCustomValues("SUBJECTDEFAULT_SEMESTER") Is Nothing Then
            item.DEFAULT_SEMESTER.SetValue(SUBJECTDEFAULT_SEMESTER.Text)
        Else
            item.DEFAULT_SEMESTER.SetValue(ControlCustomValues("SUBJECTDEFAULT_SEMESTER"))
        End If
        item.DEFAULT_TEACHER_ID.IsEmpty = IsNothing(Request.Form(SUBJECTDEFAULT_TEACHER_ID.UniqueID))
        item.DEFAULT_TEACHER_ID.SetValue(SUBJECTDEFAULT_TEACHER_ID.Value)
        item.DEFAULT_TEACHER_IDItems.CopyFrom(SUBJECTDEFAULT_TEACHER_ID.Items)
        item.SUB_SCHOOL.IsEmpty = IsNothing(Request.Form(SUBJECTSUB_SCHOOL.UniqueID))
        If ControlCustomValues("SUBJECTSUB_SCHOOL") Is Nothing Then
            item.SUB_SCHOOL.SetValue(SUBJECTSUB_SCHOOL.Text)
        Else
            item.SUB_SCHOOL.SetValue(ControlCustomValues("SUBJECTSUB_SCHOOL"))
        End If
        Try
        item.KLA_ID.IsEmpty = IsNothing(Request.Form(SUBJECTKLA_ID.UniqueID))
        item.KLA_ID.SetValue(SUBJECTKLA_ID.Value)
        item.KLA_IDItems.CopyFrom(SUBJECTKLA_ID.Items)
        Catch ae As ArgumentException
            SUBJECTErrors.Add("KLA_ID",String.Format(Resources.strings.CCS_IncorrectValue,"KLA ID"))
        End Try
        Try
        item.CSF_CLASS_LEVEL.IsEmpty = IsNothing(Request.Form(SUBJECTCSF_CLASS_LEVEL.UniqueID))
        If ControlCustomValues("SUBJECTCSF_CLASS_LEVEL") Is Nothing Then
            item.CSF_CLASS_LEVEL.SetValue(SUBJECTCSF_CLASS_LEVEL.Text)
        Else
            item.CSF_CLASS_LEVEL.SetValue(ControlCustomValues("SUBJECTCSF_CLASS_LEVEL"))
        End If
        Catch ae As ArgumentException
            SUBJECTErrors.Add("CSF_CLASS_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"CSF CLASS LEVEL"))
        End Try
        Try
        item.MAX_BOOKS.IsEmpty = IsNothing(Request.Form(SUBJECTMAX_BOOKS.UniqueID))
        If ControlCustomValues("SUBJECTMAX_BOOKS") Is Nothing Then
            item.MAX_BOOKS.SetValue(SUBJECTMAX_BOOKS.Text)
        Else
            item.MAX_BOOKS.SetValue(ControlCustomValues("SUBJECTMAX_BOOKS"))
        End If
        Catch ae As ArgumentException
            SUBJECTErrors.Add("MAX_BOOKS",String.Format(Resources.strings.CCS_IncorrectValue,"MAX BOOKS"))
        End Try
        If Not IsNothing(SUBJECTVALID_COURSE_DISTRIBUTION.SelectedItem) Then
            item.VALID_COURSE_DISTRIBUTION.SetValue(SUBJECTVALID_COURSE_DISTRIBUTION.SelectedItem.Value)
        Else
            item.VALID_COURSE_DISTRIBUTION.Value = Nothing
        End If
        item.VALID_COURSE_DISTRIBUTIONItems.CopyFrom(SUBJECTVALID_COURSE_DISTRIBUTION.Items)
        item.DESCRIPTION_LINE1.IsEmpty = IsNothing(Request.Form(SUBJECTDESCRIPTION_LINE1.UniqueID))
        If ControlCustomValues("SUBJECTDESCRIPTION_LINE1") Is Nothing Then
            item.DESCRIPTION_LINE1.SetValue(SUBJECTDESCRIPTION_LINE1.Text)
        Else
            item.DESCRIPTION_LINE1.SetValue(ControlCustomValues("SUBJECTDESCRIPTION_LINE1"))
        End If
        item.DESCRIPTION_LINE2.IsEmpty = IsNothing(Request.Form(SUBJECTDESCRIPTION_LINE2.UniqueID))
        If ControlCustomValues("SUBJECTDESCRIPTION_LINE2") Is Nothing Then
            item.DESCRIPTION_LINE2.SetValue(SUBJECTDESCRIPTION_LINE2.Text)
        Else
            item.DESCRIPTION_LINE2.SetValue(ControlCustomValues("SUBJECTDESCRIPTION_LINE2"))
        End If
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(SUBJECTSTATUS.UniqueID))
        If Not IsNothing(SUBJECTSTATUS.SelectedItem) Then
            item.STATUS.SetValue(SUBJECTSTATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(SUBJECTSTATUS.Items)
        Catch ae As ArgumentException
            SUBJECTErrors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECTData)
        End If
        SUBJECTErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECT LoadItemFromRequest method

'Record Form SUBJECT GetRedirectUrl method @2-A66E0998

    Protected Function GetSUBJECTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "SUBJECT_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECT GetRedirectUrl method

'Record Form SUBJECT ShowErrors method @2-8FF2423C

    Protected Sub SUBJECTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECTErrors.Count - 1
        Select Case SUBJECTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECTErrors(i)
        End Select
        Next i
        SUBJECTError.Visible = True
        SUBJECTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECT ShowErrors method

'Record Form SUBJECT Insert Operation @2-D3300190

    Protected Sub SUBJECT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTItem = New SUBJECTItem()
        Dim ExecuteFlag As Boolean = True
        SUBJECTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT Insert Operation

'Button Button_Insert OnClick. @3-774AB612
        If CType(sender,Control).ID = "SUBJECTButton_Insert" Then
            RedirectUrl = GetSUBJECTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form SUBJECT BeforeInsert tail @2-EB1F6609
    SUBJECTParameters()
    SUBJECTLoadItemFromRequest(item, EnableValidation)
    If SUBJECTOperations.AllowInsert Then
        ErrorFlag=(SUBJECTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SUBJECTData.InsertItem(item)
            Catch ex As Exception
                SUBJECTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SUBJECT BeforeInsert tail

'Record Form SUBJECT AfterInsert tail  @2-66DFA1AD
        End If
        ErrorFlag=(SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT AfterInsert tail 

'Record Form SUBJECT Update Operation @2-119082CF

    Protected Sub SUBJECT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTItem = New SUBJECTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT Update Operation

'Button Button_Update OnClick. @4-BA778AD9
        If CType(sender,Control).ID = "SUBJECTButton_Update" Then
            RedirectUrl = GetSUBJECTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form SUBJECT Before Update tail @2-C82AB942
        SUBJECTParameters()
        SUBJECTLoadItemFromRequest(item, EnableValidation)
        If SUBJECTOperations.AllowUpdate Then
        ErrorFlag = (SUBJECTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SUBJECTData.UpdateItem(item)
            Catch ex As Exception
                SUBJECTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SUBJECT Before Update tail

'Record Form SUBJECT Update Operation tail @2-66DFA1AD
        End If
        ErrorFlag=(SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT Update Operation tail

'Record Form SUBJECT Delete Operation @2-5E0DCF02
    Protected Sub SUBJECT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECTItem = New SUBJECTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECT Delete Operation

'Button Button_Delete OnClick. @5-8E40D89D
        If CType(sender,Control).ID = "SUBJECTButton_Delete" Then
            RedirectUrl = GetSUBJECTRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-71A4C30F
        SUBJECTParameters()
        SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-493876B7
        If ErrorFlag Then
            SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECT Cancel Operation @2-7B3B82ED

    Protected Sub SUBJECT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECTItem = New SUBJECTItem()
        SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECTLoadItemFromRequest(item, True)
'End Record Form SUBJECT Cancel Operation

'Record Form SUBJECT Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-230DDEC3
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SUBJECT_maint_bakContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTData = New SUBJECTDataProvider()
        SUBJECTOperations = New FormSupportedOperations(False, True, True, True, False)
        If Not(DBUtility.AuthorizeUser(New String(){"1"})) Then
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

