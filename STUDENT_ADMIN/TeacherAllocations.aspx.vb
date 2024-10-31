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

Namespace DECV_PROD2007.TeacherAllocations 'Namespace @1-22B4ACEA

'Forms Definition @1-79A88C69
Public Class [TeacherAllocationsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-94FE3684
    Protected TeacherAllocations_SearchData As TeacherAllocations_SearchDataProvider
    Protected TeacherAllocations_SearchErrors As NameValueCollection = New NameValueCollection()
    Protected TeacherAllocations_SearchOperations As FormSupportedOperations
    Protected TeacherAllocations_SearchIsSubmitted As Boolean = False
    Protected TeacherAllocationsContentMeta As String
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

'Record Form TeacherAllocations_Search Show method @3-6A0787B7
    Protected Sub TeacherAllocations_SearchShow()
        If TeacherAllocations_SearchOperations.None Then
            TeacherAllocations_SearchHolder.Visible = False
            Return
        End If
        Dim item As TeacherAllocations_SearchItem = TeacherAllocations_SearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TeacherAllocations_SearchOperations.AllowRead
        item.link_popupSubjectListHref = "#"
        TeacherAllocations_SearchErrors.Add(item.errors)
        If TeacherAllocations_SearchErrors.Count > 0 Then
            TeacherAllocations_SearchShowErrors()
            Return
        End If
'End Record Form TeacherAllocations_Search Show method

'Record Form TeacherAllocations_Search BeforeShow tail @3-435D6548
        TeacherAllocations_SearchParameters()
        TeacherAllocations_SearchData.FillItem(item, IsInsertMode)
        TeacherAllocations_SearchHolder.DataBind()
        TeacherAllocations_Searchs_SUBJECT_ID.Text=item.s_SUBJECT_ID.GetFormattedValue()
        TeacherAllocations_Searchlink_popupSubjectList.InnerText += item.link_popupSubjectList.GetFormattedValue().Replace(vbCrLf,"")
        TeacherAllocations_Searchlink_popupSubjectList.HRef = item.link_popupSubjectListHref+item.link_popupSubjectListHrefParameters.ToString("GET","", ViewState)
        TeacherAllocations_Searchs_STAFF_ID.Items.Add(new ListItem("Select Value",""))
        TeacherAllocations_Searchs_STAFF_ID.Items(0).Selected = True
        item.s_STAFF_IDItems.SetSelection(item.s_STAFF_ID.GetFormattedValue())
        If Not item.s_STAFF_IDItems.GetSelectedItem() Is Nothing Then
            TeacherAllocations_Searchs_STAFF_ID.SelectedIndex = -1
        End If
        item.s_STAFF_IDItems.CopyTo(TeacherAllocations_Searchs_STAFF_ID.Items)
        TeacherAllocations_Searchs_SEMESTER.Items.Add(new ListItem("Select Value",""))
        TeacherAllocations_Searchs_SEMESTER.Items(0).Selected = True
        item.s_SEMESTERItems.SetSelection(item.s_SEMESTER.GetFormattedValue())
        If Not item.s_SEMESTERItems.GetSelectedItem() Is Nothing Then
            TeacherAllocations_Searchs_SEMESTER.SelectedIndex = -1
        End If
        item.s_SEMESTERItems.CopyTo(TeacherAllocations_Searchs_SEMESTER.Items)
        item.s_SUBJ_ENROL_STATUSItems.SetSelection(item.s_SUBJ_ENROL_STATUS.GetFormattedValue())
        TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedIndex = -1
        item.s_SUBJ_ENROL_STATUSItems.CopyTo(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items)
        item.s_APPEARS_ON_VASSItems.SetSelection(item.s_APPEARS_ON_VASS.GetFormattedValue())
        TeacherAllocations_Searchs_APPEARS_ON_VASS.SelectedIndex = -1
        item.s_APPEARS_ON_VASSItems.CopyTo(TeacherAllocations_Searchs_APPEARS_ON_VASS.Items)
        TeacherAllocations_Searchs_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
'End Record Form TeacherAllocations_Search BeforeShow tail

'Record Form TeacherAllocations_Search Show method tail @3-D9BBFAA7
        If TeacherAllocations_SearchErrors.Count > 0 Then
            TeacherAllocations_SearchShowErrors()
        End If
    End Sub
'End Record Form TeacherAllocations_Search Show method tail

'Record Form TeacherAllocations_Search LoadItemFromRequest method @3-7AF54BF5

    Protected Sub TeacherAllocations_SearchLoadItemFromRequest(item As TeacherAllocations_SearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_SUBJECT_ID.UniqueID))
        If ControlCustomValues("TeacherAllocations_Searchs_SUBJECT_ID") Is Nothing Then
            item.s_SUBJECT_ID.SetValue(TeacherAllocations_Searchs_SUBJECT_ID.Text)
        Else
            item.s_SUBJECT_ID.SetValue(ControlCustomValues("TeacherAllocations_Searchs_SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            TeacherAllocations_SearchErrors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Subject ID"))
        End Try
        item.s_STAFF_ID.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_STAFF_ID.UniqueID))
        item.s_STAFF_ID.SetValue(TeacherAllocations_Searchs_STAFF_ID.Value)
        item.s_STAFF_IDItems.CopyFrom(TeacherAllocations_Searchs_STAFF_ID.Items)
        item.s_SEMESTER.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_SEMESTER.UniqueID))
        item.s_SEMESTER.SetValue(TeacherAllocations_Searchs_SEMESTER.Value)
        item.s_SEMESTERItems.CopyFrom(TeacherAllocations_Searchs_SEMESTER.Items)
        item.s_SUBJ_ENROL_STATUS.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.UniqueID))
        If Not IsNothing(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedItem) Then
            item.s_SUBJ_ENROL_STATUS.SetValue(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.SelectedItem.Value)
        Else
            item.s_SUBJ_ENROL_STATUS.Value = Nothing
        End If
        item.s_SUBJ_ENROL_STATUSItems.CopyFrom(TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items)
        item.s_APPEARS_ON_VASS.IsEmpty = IsNothing(Request.Form(TeacherAllocations_Searchs_APPEARS_ON_VASS.UniqueID))
        If Not IsNothing(TeacherAllocations_Searchs_APPEARS_ON_VASS.SelectedItem) Then
            item.s_APPEARS_ON_VASS.SetValue(TeacherAllocations_Searchs_APPEARS_ON_VASS.SelectedItem.Value)
        Else
            item.s_APPEARS_ON_VASS.Value = Nothing
        End If
        item.s_APPEARS_ON_VASSItems.CopyFrom(TeacherAllocations_Searchs_APPEARS_ON_VASS.Items)
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

'Record Form TeacherAllocations_Search GetRedirectUrl method @3-D1D28599

    Protected Function GetTeacherAllocations_SearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "TeacherAllocations_Results.aspx"
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

'Button Button_DoSearch OnClick. @4-F81B810A
        If CType(sender,Control).ID = "TeacherAllocations_SearchButton_DoSearch" Then
            RedirectUrl = GetTeacherAllocations_SearchRedirectUrl("", "s_SUBJECT_ID;s_STAFF_ID;s_SEMESTER;s_SUBJ_ENROL_STATUS;s_APPEARS_ON_VASS;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @4-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form TeacherAllocations_Search Search Operation tail @3-048AB881
        ErrorFlag = TeacherAllocations_SearchErrors.Count > 0
        If ErrorFlag Then
            TeacherAllocations_SearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(TeacherAllocations_Searchs_SUBJECT_ID.Text <> "",("s_SUBJECT_ID=" & Server.UrlEncode(TeacherAllocations_Searchs_SUBJECT_ID.Text) & "&"), "")
            For Each li In TeacherAllocations_Searchs_STAFF_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_STAFF_ID=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In TeacherAllocations_Searchs_SEMESTER.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SEMESTER=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In TeacherAllocations_Searchs_SUBJ_ENROL_STATUS.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SUBJ_ENROL_STATUS=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In TeacherAllocations_Searchs_APPEARS_ON_VASS.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_APPEARS_ON_VASS=" & Server.UrlEncode(li.Value) & "&"
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

'OnInit Event Body @1-977D0121
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        TeacherAllocationsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        TeacherAllocations_SearchData = New TeacherAllocations_SearchDataProvider()
        TeacherAllocations_SearchOperations = New FormSupportedOperations(False, True, True, True, True)
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

