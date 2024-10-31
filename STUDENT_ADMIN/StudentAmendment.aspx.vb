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

Namespace DECV_PROD2007.StudentAmendment 'Namespace @1-B9580602

'Forms Definition @1-2E2CB2DA
Public Class [StudentAmendmentPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-28CE53FF
    Protected TeacherAllocations_SearchData As TeacherAllocations_SearchDataProvider
    Protected TeacherAllocations_SearchErrors As NameValueCollection = New NameValueCollection()
    Protected TeacherAllocations_SearchOperations As FormSupportedOperations
    Protected TeacherAllocations_SearchIsSubmitted As Boolean = False
    Protected StudentAmendmentContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-0E1FAF4E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            TeacherAllocations_SearchShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form TeacherAllocations_Search Parameters @3-3683057E

    Protected Sub TeacherAllocations_SearchParameters()
        Dim item As new TeacherAllocations_SearchItem
        Try
        Catch e As Exception
            TeacherAllocations_SearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form TeacherAllocations_Search Parameters

'Record Form TeacherAllocations_Search Show method @3-EE69C951
    Protected Sub TeacherAllocations_SearchShow()
        If TeacherAllocations_SearchOperations.None Then
            TeacherAllocations_SearchHolder.Visible = False
            Return
        End If
        Dim item As TeacherAllocations_SearchItem = TeacherAllocations_SearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TeacherAllocations_SearchOperations.AllowRead
        TeacherAllocations_SearchErrors.Add(item.errors)
        If TeacherAllocations_SearchErrors.Count > 0 Then
            TeacherAllocations_SearchShowErrors()
            Return
        End If
'End Record Form TeacherAllocations_Search Show method

'Record Form TeacherAllocations_Search BeforeShow tail @3-48A4173E
        TeacherAllocations_SearchParameters()
        TeacherAllocations_SearchData.FillItem(item, IsInsertMode)
        TeacherAllocations_SearchHolder.DataBind()
        TeacherAllocations_Searchs_STUDENT_ID_lowest.Text=item.s_STUDENT_ID_lowest.GetFormattedValue()
        TeacherAllocations_SearchlistRowsPerPage.Items.Add(new ListItem("Select Value",""))
        TeacherAllocations_SearchlistRowsPerPage.Items(0).Selected = True
        item.listRowsPerPageItems.SetSelection(item.listRowsPerPage.GetFormattedValue())
        If Not item.listRowsPerPageItems.GetSelectedItem() Is Nothing Then
            TeacherAllocations_SearchlistRowsPerPage.SelectedIndex = -1
        End If
        item.listRowsPerPageItems.CopyTo(TeacherAllocations_SearchlistRowsPerPage.Items)
        TeacherAllocations_Searchs_YEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        TeacherAllocations_Searchs_YEAR_LEVEL.Items(0).Selected = True
        item.s_YEAR_LEVELItems.SetSelection(item.s_YEAR_LEVEL.GetFormattedValue())
        If Not item.s_YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            TeacherAllocations_Searchs_YEAR_LEVEL.SelectedIndex = -1
        End If
        item.s_YEAR_LEVELItems.CopyTo(TeacherAllocations_Searchs_YEAR_LEVEL.Items)
        item.s_SUBJ_ENROL_STATUSItems.SetSelection(item.s_SUBJ_ENROL_STATUS.GetFormattedValue())
        TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedIndex = -1
        item.s_SUBJ_ENROL_STATUSItems.CopyTo(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items)
        TeacherAllocations_Searchs_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
'End Record Form TeacherAllocations_Search BeforeShow tail

'TextBox s_STUDENT_ID_lowest Event BeforeShow. Action DLookup @17-C6CF1698
            TeacherAllocations_Searchs_STUDENT_ID_lowest.Text = (New FloatField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "min(STUDENT_ID)" & " FROM " & "STUDENT"))).GetFormattedValue("")
'End TextBox s_STUDENT_ID_lowest Event BeforeShow. Action DLookup

'Record Form TeacherAllocations_Search Show method tail @3-D9BBFAA7
        If TeacherAllocations_SearchErrors.Count > 0 Then
            TeacherAllocations_SearchShowErrors()
        End If
    End Sub
'End Record Form TeacherAllocations_Search Show method tail

'Record Form TeacherAllocations_Search LoadItemFromRequest method @3-4EC4E2E4

    Protected Sub TeacherAllocations_SearchLoadItemFromRequest(item As TeacherAllocations_SearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_STUDENT_ID_lowest.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_STUDENT_ID_lowest.UniqueID))
        If ControlCustomValues("TeacherAllocations_Searchs_STUDENT_ID_lowest") Is Nothing Then
            item.s_STUDENT_ID_lowest.SetValue(TeacherAllocations_Searchs_STUDENT_ID_lowest.Text)
        Else
            item.s_STUDENT_ID_lowest.SetValue(ControlCustomValues("TeacherAllocations_Searchs_STUDENT_ID_lowest"))
        End If
        Catch ae As ArgumentException
            TeacherAllocations_SearchErrors.Add("s_STUDENT_ID_lowest",String.Format(Resources.strings.CCS_IncorrectValue,"lowest Student ID"))
        End Try
        Try
        item.listRowsPerPage.IsEmpty = IsNothing(Request.Form(TeacherAllocations_SearchlistRowsPerPage.UniqueID))
        item.listRowsPerPage.SetValue(TeacherAllocations_SearchlistRowsPerPage.Value)
        item.listRowsPerPageItems.CopyFrom(TeacherAllocations_SearchlistRowsPerPage.Items)
        Catch ae As ArgumentException
            TeacherAllocations_SearchErrors.Add("listRowsPerPage",String.Format(Resources.strings.CCS_IncorrectValue,"listRowsPerPage"))
        End Try
        Try
        item.s_YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_YEAR_LEVEL.UniqueID))
        item.s_YEAR_LEVEL.SetValue(TeacherAllocations_Searchs_YEAR_LEVEL.Value)
        item.s_YEAR_LEVELItems.CopyFrom(TeacherAllocations_Searchs_YEAR_LEVEL.Items)
        Catch ae As ArgumentException
            TeacherAllocations_SearchErrors.Add("s_YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"Year Level"))
        End Try
        item.s_SUBJ_ENROL_STATUS.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.UniqueID))
        If Not IsNothing(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedItem) Then
            item.s_SUBJ_ENROL_STATUS.SetValue(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedItem.Value)
        Else
            item.s_SUBJ_ENROL_STATUS.Value = Nothing
        End If
        item.s_SUBJ_ENROL_STATUSItems.CopyFrom(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items)
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("TeacherAllocations_Searchs_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(TeacherAllocations_Searchs_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("TeacherAllocations_Searchs_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            TeacherAllocations_SearchErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"Enrolment Year"))
        End Try
        If EnableValidation Then
            item.Validate(TeacherAllocations_SearchData)
        End If
        TeacherAllocations_SearchErrors.Add(item.errors)
    End Sub
'End Record Form TeacherAllocations_Search LoadItemFromRequest method

'Record Form TeacherAllocations_Search GetRedirectUrl method @3-2E015049

    Protected Function GetTeacherAllocations_SearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentAmendments_Results.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form TeacherAllocations_Search GetRedirectUrl method

'Record Form TeacherAllocations_Search ShowErrors method @3-697283C3

    Protected Sub TeacherAllocations_SearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To TeacherAllocations_SearchErrors.Count - 1
        Select Case TeacherAllocations_SearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & TeacherAllocations_SearchErrors(i)
        End Select
        Next i
        TeacherAllocations_SearchError.Visible = True
        TeacherAllocations_SearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form TeacherAllocations_Search ShowErrors method

'Record Form TeacherAllocations_Search Insert Operation @3-03464F10

    Protected Sub TeacherAllocations_Search_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        TeacherAllocations_SearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TeacherAllocations_Search Insert Operation

'Record Form TeacherAllocations_Search BeforeInsert tail @3-00EEBC9B
    TeacherAllocations_SearchParameters()
    TeacherAllocations_SearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TeacherAllocations_Search BeforeInsert tail

'Record Form TeacherAllocations_Search AfterInsert tail  @3-5F1A7B1C
        ErrorFlag=(TeacherAllocations_SearchErrors.Count > 0)
        If ErrorFlag Then
            TeacherAllocations_SearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TeacherAllocations_Search AfterInsert tail 

'Record Form TeacherAllocations_Search Update Operation @3-1D06FD68

    Protected Sub TeacherAllocations_Search_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        TeacherAllocations_SearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TeacherAllocations_Search Update Operation

'Record Form TeacherAllocations_Search Before Update tail @3-00EEBC9B
        TeacherAllocations_SearchParameters()
        TeacherAllocations_SearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TeacherAllocations_Search Before Update tail

'Record Form TeacherAllocations_Search Update Operation tail @3-5F1A7B1C
        ErrorFlag=(TeacherAllocations_SearchErrors.Count > 0)
        If ErrorFlag Then
            TeacherAllocations_SearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TeacherAllocations_Search Update Operation tail

'Record Form TeacherAllocations_Search Delete Operation @3-E3B991F2
    Protected Sub TeacherAllocations_Search_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        TeacherAllocations_SearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form TeacherAllocations_Search Delete Operation

'Record Form BeforeDelete tail @3-00EEBC9B
        TeacherAllocations_SearchParameters()
        TeacherAllocations_SearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-C7CEEC17
        If ErrorFlag Then
            TeacherAllocations_SearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form TeacherAllocations_Search Cancel Operation @3-F6D34828

    Protected Sub TeacherAllocations_Search_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        TeacherAllocations_SearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        TeacherAllocations_SearchLoadItemFromRequest(item, True)
'End Record Form TeacherAllocations_Search Cancel Operation

'Record Form TeacherAllocations_Search Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form TeacherAllocations_Search Cancel Operation tail

'Record Form TeacherAllocations_Search Search Operation @3-0C59E70B
    Protected Sub TeacherAllocations_Search_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        TeacherAllocations_SearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As TeacherAllocations_SearchItem = New TeacherAllocations_SearchItem()
        TeacherAllocations_SearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TeacherAllocations_Search Search Operation

'Button Button_DoSearch OnClick. @4-6E01B69C
        If CType(sender,Control).ID = "TeacherAllocations_SearchButton_DoSearch" Then
            RedirectUrl = GetTeacherAllocations_SearchRedirectUrl("", "s_STUDENT_ID_lowest;listRowsPerPage;s_YEAR_LEVEL;s_SUBJ_ENROL_STATUS;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @4-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form TeacherAllocations_Search Search Operation tail @3-740FF686
        ErrorFlag = TeacherAllocations_SearchErrors.Count > 0
        If ErrorFlag Then
            TeacherAllocations_SearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(TeacherAllocations_Searchs_STUDENT_ID_lowest.Text <> "",("s_STUDENT_ID_lowest=" & Server.UrlEncode(TeacherAllocations_Searchs_STUDENT_ID_lowest.Text) & "&"), "")
            For Each li In TeacherAllocations_SearchlistRowsPerPage.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "listRowsPerPage=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In TeacherAllocations_Searchs_YEAR_LEVEL.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_YEAR_LEVEL=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SUBJ_ENROL_STATUS=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            Params = Params & IIf(TeacherAllocations_Searchs_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(TeacherAllocations_Searchs_ENROLMENT_YEAR.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TeacherAllocations_Search Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4CEF31E9
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentAmendmentContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        TeacherAllocations_SearchData = New TeacherAllocations_SearchDataProvider()
        TeacherAllocations_SearchOperations = New FormSupportedOperations(False, True, True, True, True)
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

