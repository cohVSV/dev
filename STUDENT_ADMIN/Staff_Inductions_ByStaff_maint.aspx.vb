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

Namespace DECV_PROD2007.Staff_Inductions_ByStaff_maint 'Namespace @1-96C25348

'Forms Definition @1-0E8B3D4C
Public Class [Staff_Inductions_ByStaff_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-DCA5797C
    Protected STAFF_INDUCTIONS_PROGRESSData As STAFF_INDUCTIONS_PROGRESSDataProvider
    Protected STAFF_INDUCTIONS_PROGRESSErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_PROGRESSOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_PROGRESSIsSubmitted As Boolean = False
    Protected STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName As String
    Protected STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl As String
    Protected Staff_Inductions_ByStaff_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-04D4E432
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.link_backtolistHref = "Staff_Inductions_ByStaff.aspx"
            PageData.FillItem(item)
            link_backtolist.InnerText += item.link_backtolist.GetFormattedValue().Replace(vbCrLf,"")
            link_backtolist.HRef = item.link_backtolistHref+item.link_backtolistHrefParameters.ToString("GET","", ViewState)
            link_backtolist.DataBind()
            STAFF_INDUCTIONS_PROGRESSShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'DEL      ' -------------------------
'DEL  	' also hide the Add New for Teachers
'DEL   		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			STAFF_INDUCTIONS_COURSES1linkNewInduction.visible = True
'DEL  		else
'DEL  			STAFF_INDUCTIONS_COURSES1linkNewInduction.visible = false			
'DEL      	End If
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	' ERA: hide some items if Teacher, show if LPLT etc
'DEL      ' -------------------------
'DEL  		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.visible = True
'DEL  			STAFF_INDUCTIONS_COURSESlabel_TeacherID.visible = false
'DEL  		else
'DEL  			STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.visible = false
'DEL  			STAFF_INDUCTIONS_COURSESlabel_TeacherID.visible = true
'DEL  			STAFF_INDUCTIONS_COURSESClearParameters.visible = false
'DEL  			
'DEL      	End If
'DEL      ' -------------------------

'Record Form STAFF_INDUCTIONS_PROGRESS Parameters @35-0D7BADE9

    Protected Sub STAFF_INDUCTIONS_PROGRESSParameters()
        Dim item As new STAFF_INDUCTIONS_PROGRESSItem
        Try
            STAFF_INDUCTIONS_PROGRESSData.UrlSTAFF_INDUCTIONS_PROGRESS_id = TextParameter.GetParam("STAFF_INDUCTIONS_PROGRESS_id", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STAFF_INDUCTIONS_PROGRESSErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS Parameters

'Record Form STAFF_INDUCTIONS_PROGRESS Show method @35-A0E9DF55
    Protected Sub STAFF_INDUCTIONS_PROGRESSShow()
        If STAFF_INDUCTIONS_PROGRESSOperations.None Then
            STAFF_INDUCTIONS_PROGRESSHolder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = STAFF_INDUCTIONS_PROGRESSItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_PROGRESSOperations.AllowRead
        item.Link1_DavidHref = "#"
        STAFF_INDUCTIONS_PROGRESSErrors.Add(item.errors)
        If STAFF_INDUCTIONS_PROGRESSErrors.Count > 0 Then
            STAFF_INDUCTIONS_PROGRESSShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_PROGRESS Show method

'Record Form STAFF_INDUCTIONS_PROGRESS BeforeShow tail @35-0A5C12D8
        STAFF_INDUCTIONS_PROGRESSParameters()
        STAFF_INDUCTIONS_PROGRESSData.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_PROGRESSHolder.DataBind()
        STAFF_INDUCTIONS_PROGRESSButton_Insert.Visible=IsInsertMode AndAlso STAFF_INDUCTIONS_PROGRESSOperations.AllowInsert
        STAFF_INDUCTIONS_PROGRESSButton_Update.Visible=Not (IsInsertMode) AndAlso STAFF_INDUCTIONS_PROGRESSOperations.AllowUpdate
        STAFF_INDUCTIONS_PROGRESSButton_Delete.Visible=Not (IsInsertMode) AndAlso STAFF_INDUCTIONS_PROGRESSOperations.AllowDelete
        STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.Items.Add(new ListItem("Select Value",""))
        STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.Items(0).Selected = True
        item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.SetSelection(item.STAFF_INDUCTIONS_PROGRESS_STATUS.GetFormattedValue())
        If Not item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.GetSelectedItem() Is Nothing Then
            STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.SelectedIndex = -1
        End If
        item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.CopyTo(STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.Items)
        STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.Text=item.DATE_COMPLETED.GetFormattedValue()
        STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDName = "STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED"
        STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETEDDateControl = STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.ClientID
        STAFF_INDUCTIONS_PROGRESSDatePicker_DATE_COMPLETED.DataBind()
        STAFF_INDUCTIONS_PROGRESSHidden_last_altered_by.Value = item.Hidden_last_altered_by.GetFormattedValue()
        STAFF_INDUCTIONS_PROGRESSHidden_last_altered_date.Value = item.Hidden_last_altered_date.GetFormattedValue()
        STAFF_INDUCTIONS_PROGRESSHidden_STAFF_ID.Value = item.Hidden_STAFF_ID.GetFormattedValue()
        STAFF_INDUCTIONS_PROGRESSlbl_STAFF_ID.Text = Server.HtmlEncode(item.lbl_STAFF_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.Items.Add(new ListItem("Select Value",""))
        STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.Items(0).Selected = True
        item.listbox_InductionCoursesItems.SetSelection(item.listbox_InductionCourses.GetFormattedValue())
        If Not item.listbox_InductionCoursesItems.GetSelectedItem() Is Nothing Then
            STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.SelectedIndex = -1
        End If
        item.listbox_InductionCoursesItems.CopyTo(STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.Items)
        STAFF_INDUCTIONS_PROGRESSLAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_PROGRESSLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_INDUCTIONS_PROGRESSLink1_David.InnerText += item.Link1_David.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_PROGRESSLink1_David.HRef = item.Link1_DavidHref+item.Link1_DavidHrefParameters.ToString("None","", ViewState)
'End Record Form STAFF_INDUCTIONS_PROGRESS BeforeShow tail

'Hidden Hidden_last_altered_by Event BeforeShow. Action Retrieve Value for Control @57-C51516EC
            STAFF_INDUCTIONS_PROGRESSHidden_last_altered_by.Value = (New TextField("", (DBUtility.UserLogin.ToUpper()))).GetFormattedValue()
'End Hidden Hidden_last_altered_by Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_last_altered_date Event BeforeShow. Action Retrieve Value for Control @59-EAA51153
            STAFF_INDUCTIONS_PROGRESSHidden_last_altered_date.Value = (New TextField("", (Now()))).GetFormattedValue()
'End Hidden Hidden_last_altered_date Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_STAFF_ID Event BeforeShow. Action Retrieve Value for Control @71-1B054E56
            STAFF_INDUCTIONS_PROGRESSHidden_STAFF_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_View_StaffList_Active_Inactive_staff_ID"))).GetFormattedValue()
'End Hidden Hidden_STAFF_ID Event BeforeShow. Action Retrieve Value for Control

'Label lbl_STAFF_ID Event BeforeShow. Action Retrieve Value for Control @108-1B2BA2CD
            STAFF_INDUCTIONS_PROGRESSlbl_STAFF_ID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_View_StaffList_Active_Inactive_staff_ID"))).GetFormattedValue()
'End Label lbl_STAFF_ID Event BeforeShow. Action Retrieve Value for Control

'Record STAFF_INDUCTIONS_PROGRESS Event BeforeShow. Action Hide-Show Component @114-976FABE6
        If DBUtility.UserLogin.ToUpper() = "DRICHARD" Then
            STAFF_INDUCTIONS_PROGRESSLink1_David.Visible = True
        End If
'End Record STAFF_INDUCTIONS_PROGRESS Event BeforeShow. Action Hide-Show Component

'Record Form STAFF_INDUCTIONS_PROGRESS Show method tail @35-44FBF5FA
        If STAFF_INDUCTIONS_PROGRESSErrors.Count > 0 Then
            STAFF_INDUCTIONS_PROGRESSShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS Show method tail

'Record Form STAFF_INDUCTIONS_PROGRESS LoadItemFromRequest method @35-CAD1FF57

    Protected Sub STAFF_INDUCTIONS_PROGRESSLoadItemFromRequest(item As STAFF_INDUCTIONS_PROGRESSItem, ByVal EnableValidation As Boolean)
        item.STAFF_INDUCTIONS_PROGRESS_STATUS.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.UniqueID))
        item.STAFF_INDUCTIONS_PROGRESS_STATUS.SetValue(STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.Value)
        item.STAFF_INDUCTIONS_PROGRESS_STATUSItems.CopyFrom(STAFF_INDUCTIONS_PROGRESSSTAFF_INDUCTIONS_PROGRESS_STATUS.Items)
        Try
        item.DATE_COMPLETED.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.UniqueID))
        If ControlCustomValues("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED") Is Nothing Then
            item.DATE_COMPLETED.SetValue(STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED.Text)
        Else
            item.DATE_COMPLETED.SetValue(ControlCustomValues("STAFF_INDUCTIONS_PROGRESSDATE_COMPLETED"))
        End If
        Catch ae As ArgumentException
            STAFF_INDUCTIONS_PROGRESSErrors.Add("DATE_COMPLETED",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE COMPLETED","dd/mm/yyyy"))
        End Try
        item.Hidden_last_altered_by.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSHidden_last_altered_by.UniqueID))
        item.Hidden_last_altered_by.SetValue(STAFF_INDUCTIONS_PROGRESSHidden_last_altered_by.Value)
        item.Hidden_last_altered_date.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSHidden_last_altered_date.UniqueID))
        item.Hidden_last_altered_date.SetValue(STAFF_INDUCTIONS_PROGRESSHidden_last_altered_date.Value)
        item.Hidden_STAFF_ID.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSHidden_STAFF_ID.UniqueID))
        item.Hidden_STAFF_ID.SetValue(STAFF_INDUCTIONS_PROGRESSHidden_STAFF_ID.Value)
        item.listbox_InductionCourses.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.UniqueID))
        item.listbox_InductionCourses.SetValue(STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.Value)
        item.listbox_InductionCoursesItems.CopyFrom(STAFF_INDUCTIONS_PROGRESSlistbox_InductionCourses.Items)
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_PROGRESSData)
        End If
        STAFF_INDUCTIONS_PROGRESSErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_PROGRESS GetRedirectUrl method @35-1822A388

    Protected Function GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_Inductions_ByStaff.aspx"
        Dim p As String = parameters.ToString("GET","STAFF_INDUCTIONS_PROGRESS_id;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_INDUCTIONS_PROGRESS GetRedirectUrl method

'Record Form STAFF_INDUCTIONS_PROGRESS ShowErrors method @35-F0D0C6E6

    Protected Sub STAFF_INDUCTIONS_PROGRESSShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_INDUCTIONS_PROGRESSErrors.Count - 1
        Select Case STAFF_INDUCTIONS_PROGRESSErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_INDUCTIONS_PROGRESSErrors(i)
        End Select
        Next i
        STAFF_INDUCTIONS_PROGRESSError.Visible = True
        STAFF_INDUCTIONS_PROGRESSErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS ShowErrors method

'Record Form STAFF_INDUCTIONS_PROGRESS Insert Operation @35-6B88B54C

    Protected Sub STAFF_INDUCTIONS_PROGRESS_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
        Dim ExecuteFlag As Boolean = True
        STAFF_INDUCTIONS_PROGRESSIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_PROGRESS Insert Operation

'Button Button_Insert OnClick. @36-65B68912
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_PROGRESSButton_Insert" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @36-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STAFF_INDUCTIONS_PROGRESS BeforeInsert tail @35-E18620D5
    STAFF_INDUCTIONS_PROGRESSParameters()
    STAFF_INDUCTIONS_PROGRESSLoadItemFromRequest(item, EnableValidation)
    If STAFF_INDUCTIONS_PROGRESSOperations.AllowInsert Then
        ErrorFlag=(STAFF_INDUCTIONS_PROGRESSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_PROGRESSData.InsertItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_PROGRESSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_PROGRESS BeforeInsert tail

'Record Form STAFF_INDUCTIONS_PROGRESS AfterInsert tail  @35-44C4FD74
        End If
        ErrorFlag=(STAFF_INDUCTIONS_PROGRESSErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_PROGRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS AfterInsert tail 

'Record Form STAFF_INDUCTIONS_PROGRESS Update Operation @35-D1A4DBC4

    Protected Sub STAFF_INDUCTIONS_PROGRESS_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_PROGRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_PROGRESS Update Operation

'Button Button_Update OnClick. @37-A04D513B
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_PROGRESSButton_Update" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @37-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STAFF_INDUCTIONS_PROGRESS Before Update tail @35-BB3ABBEB
        STAFF_INDUCTIONS_PROGRESSParameters()
        STAFF_INDUCTIONS_PROGRESSLoadItemFromRequest(item, EnableValidation)
        If STAFF_INDUCTIONS_PROGRESSOperations.AllowUpdate Then
        ErrorFlag = (STAFF_INDUCTIONS_PROGRESSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_PROGRESSData.UpdateItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_PROGRESSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_INDUCTIONS_PROGRESS Before Update tail

'Record Form STAFF_INDUCTIONS_PROGRESS Update Operation tail @35-44C4FD74
        End If
        ErrorFlag=(STAFF_INDUCTIONS_PROGRESSErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_PROGRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS Update Operation tail

'Record Form STAFF_INDUCTIONS_PROGRESS Delete Operation @35-AB5BFCFA
    Protected Sub STAFF_INDUCTIONS_PROGRESS_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_PROGRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_INDUCTIONS_PROGRESS Delete Operation

'Button Button_Delete OnClick. @38-5B21C07B
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_PROGRESSButton_Delete" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @38-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @35-D9CFA93A
        STAFF_INDUCTIONS_PROGRESSParameters()
        STAFF_INDUCTIONS_PROGRESSLoadItemFromRequest(item, EnableValidation)
        If STAFF_INDUCTIONS_PROGRESSOperations.AllowDelete Then
        ErrorFlag = (STAFF_INDUCTIONS_PROGRESSErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_INDUCTIONS_PROGRESSData.DeleteItem(item)
            Catch ex As Exception
                STAFF_INDUCTIONS_PROGRESSErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @35-BDE65276
        End If
        If ErrorFlag Then
            STAFF_INDUCTIONS_PROGRESSShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_INDUCTIONS_PROGRESS Cancel Operation @35-CA134608

    Protected Sub STAFF_INDUCTIONS_PROGRESS_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_PROGRESSItem = New STAFF_INDUCTIONS_PROGRESSItem()
        STAFF_INDUCTIONS_PROGRESSIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_INDUCTIONS_PROGRESSLoadItemFromRequest(item, False)
'End Record Form STAFF_INDUCTIONS_PROGRESS Cancel Operation

'Button Button_Cancel OnClick. @40-8141F7BB
    If CType(sender,Control).ID = "STAFF_INDUCTIONS_PROGRESSButton_Cancel" Then
        RedirectUrl = GetSTAFF_INDUCTIONS_PROGRESSRedirectUrl("Staff_Inductions_ByStaff.aspx", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @40-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STAFF_INDUCTIONS_PROGRESS Cancel Operation tail @35-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_INDUCTIONS_PROGRESS Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-B56730FD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_Inductions_ByStaff_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_INDUCTIONS_PROGRESSData = New STAFF_INDUCTIONS_PROGRESSDataProvider()
        STAFF_INDUCTIONS_PROGRESSOperations = New FormSupportedOperations(False, True, True, True, True)
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

