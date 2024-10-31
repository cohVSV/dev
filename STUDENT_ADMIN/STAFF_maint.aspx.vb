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

Namespace DECV_PROD2007.STAFF_maint 'Namespace @1-4BB7664E

'Forms Definition @1-A3EA0632
Public Class [STAFF_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F0568D3F
    Protected STAFFData As STAFFDataProvider
    Protected STAFFErrors As NameValueCollection = New NameValueCollection()
    Protected STAFFOperations As FormSupportedOperations
    Protected STAFFIsSubmitted As Boolean = False
    Protected STAFF_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A5A57478
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "STAFF_list.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            STAFFShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STAFF Parameters @2-CD34F191

    Protected Sub STAFFParameters()
        Dim item As new STAFFItem
        Try
            STAFFData.UrlSTAFF_ID = TextParameter.GetParam("STAFF_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STAFFErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF Parameters

'Record Form STAFF Show method @2-0FA06F74
    Protected Sub STAFFShow()
        If STAFFOperations.None Then
            STAFFHolder.Visible = False
            Return
        End If
        Dim item As STAFFItem = STAFFItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFFOperations.AllowRead
        STAFFErrors.Add(item.errors)
        If STAFFErrors.Count > 0 Then
            STAFFShowErrors()
            Return
        End If
'End Record Form STAFF Show method

'Record Form STAFF BeforeShow tail @2-0097E22B
        STAFFParameters()
        STAFFData.FillItem(item, IsInsertMode)
        STAFFHolder.DataBind()
        STAFFButton_Insert.Visible=IsInsertMode AndAlso STAFFOperations.AllowInsert
        STAFFButton_Update.Visible=Not (IsInsertMode) AndAlso STAFFOperations.AllowUpdate
        STAFFButton_Delete.Visible=Not (IsInsertMode) AndAlso STAFFOperations.AllowDelete
        STAFFStaffID.Text=item.StaffID.GetFormattedValue()
        STAFFStaffID_view.Text = Server.HtmlEncode(item.StaffID_view.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFFSALUTATION.Text=item.SALUTATION.GetFormattedValue()
        STAFFSURNAME.Text=item.SURNAME.GetFormattedValue()
        STAFFFIRSTNAME.Text=item.FIRSTNAME.GetFormattedValue()
        STAFFMIDDLENAME.Text=item.MIDDLENAME.GetFormattedValue()
        If item.TEACHER_FLAGCheckedValue.Value.Equals(item.TEACHER_FLAG.Value) Then
            STAFFTEACHER_FLAG.Checked = True
        End If
        If item.STATUSCheckedValue.Value.Equals(item.STATUS.Value) Then
            STAFFSTATUS.Checked = True
        End If
        STAFFGROUP_ID.Items.Add(new ListItem("Select Value",""))
        STAFFGROUP_ID.Items(0).Selected = True
        item.GROUP_IDItems.SetSelection(item.GROUP_ID.GetFormattedValue())
        If Not item.GROUP_IDItems.GetSelectedItem() Is Nothing Then
            STAFFGROUP_ID.SelectedIndex = -1
        End If
        item.GROUP_IDItems.CopyTo(STAFFGROUP_ID.Items)
        STAFFlblLAST_ALTERED_BY.Text = Server.HtmlEncode(item.lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFFlblLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFFCAMPUS_CODE.Value = item.CAMPUS_CODE.GetFormattedValue()
        STAFFhidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        STAFFhidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        STAFFLoginID.Text=item.LoginID.GetFormattedValue()
        STAFFlblLoginID.Text = Server.HtmlEncode(item.lblLoginID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFFHidden_LOGIN_ID.Value = item.Hidden_LOGIN_ID.GetFormattedValue()
        If (Not IsNothing(Request.QueryString("CheckboxList_SECURITY_FUNCTIONS")))And IsInsertMode Then
            Dim i As Integer
            For i = 0 To Request.QueryString.GetValues("CheckboxList_SECURITY_FUNCTIONS").GetUpperBound(0)
                item.CheckboxList_SECURITY_FUNCTIONSItems.SetSelection(Request.QueryString.GetValues("CheckboxList_SECURITY_FUNCTIONS")(i))
            Next i
        End If
        item.CheckboxList_SECURITY_FUNCTIONSItems.SetSelection(item.CheckboxList_SECURITY_FUNCTIONS.Value)
        STAFFCheckboxList_SECURITY_FUNCTIONS.SelectedIndex = -1
        item.CheckboxList_SECURITY_FUNCTIONSItems.CopyTo(STAFFCheckboxList_SECURITY_FUNCTIONS.Items)
        STAFFHidden_SECURITY_FUNCTIONS.Value = item.Hidden_SECURITY_FUNCTIONS.GetFormattedValue()
'End Record Form STAFF BeforeShow tail

'Hidden hidden_LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control @28-910BBBB5
            STAFFhidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper()))).GetFormattedValue()
'End Hidden hidden_LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control

'Hidden hidden_LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control @27-EC87F722
            STAFFhidden_LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Hidden hidden_LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control

'CheckBoxList CheckboxList_SECURITY_FUNCTIONS Event BeforeShow. Action Custom Code @53-73254650
    ' -------------------------
    '5/5/2016|EA| change layout 
    STAFFCheckboxList_SECURITY_FUNCTIONS.RepeatColumns = 3
	STAFFCheckboxList_SECURITY_FUNCTIONS.RepeatDirection = RepeatDirection.Vertical
	STAFFCheckboxList_SECURITY_FUNCTIONS.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End CheckBoxList CheckboxList_SECURITY_FUNCTIONS Event BeforeShow. Action Custom Code

'Record STAFF Event BeforeShow. Action Custom Code @22-73254650
    ' -------------------------
    ' ERA: swap between Textbox (if New record) or lable if not
	' ERA: 1-April-2010|EA| also new Login ID fields - hidden unless Edit mode
	If (IsInsertMode) Then
   		STAFFStaffID_view.visible = false

		STAFFlblLoginID.visible = false
		STAFFLoginID.visible = false
		STAFFHidden_LOGIN_ID.visible = true
  	Else 
    	STAFFStaffID.visible = false

		STAFFlblLoginID.visible = true
		STAFFLoginID.visible = true
		STAFFHidden_LOGIN_ID.visible = false
  	End if

    ' -------------------------
'End Record STAFF Event BeforeShow. Action Custom Code

'Record STAFF Event BeforeShow. Action Custom Code @54-73254650
    ' -------------------------
    '5-May-2016|EA|check the selected security functions from the single string list
	
	if (item.Hidden_SECURITY_FUNCTIONS.Value <> "") then
		' split up the string into an array
		Dim checkItemsPQ As Char() = item.Hidden_SECURITY_FUNCTIONS.Value.ToCharArray()
		' loop through checkboxitems and compare against the array
		Dim thisItemPQ As String = ""

		For Each thisItemPQ In checkItemsPQ
			' set that item as checked
			item.CheckboxList_SECURITY_FUNCTIONSItems.SetSelection(thisItemPQ)
		Next

		' and display
		STAFFCheckboxList_SECURITY_FUNCTIONS.Items.Clear()
    	item.CheckboxList_SECURITY_FUNCTIONSItems.CopyTo(STAFFCheckboxList_SECURITY_FUNCTIONS.Items)
	end if
    ' -------------------------
'End Record STAFF Event BeforeShow. Action Custom Code

'Record Form STAFF Show method tail @2-82119BC3
        If STAFFErrors.Count > 0 Then
            STAFFShowErrors()
        End If
    End Sub
'End Record Form STAFF Show method tail

'Record Form STAFF LoadItemFromRequest method @2-CDE4CF31

    Protected Sub STAFFLoadItemFromRequest(item As STAFFItem, ByVal EnableValidation As Boolean)
        item.StaffID.IsEmpty = IsNothing(Request.Form(STAFFStaffID.UniqueID))
        If ControlCustomValues("STAFFStaffID") Is Nothing Then
            item.StaffID.SetValue(STAFFStaffID.Text)
        Else
            item.StaffID.SetValue(ControlCustomValues("STAFFStaffID"))
        End If
        item.SALUTATION.IsEmpty = IsNothing(Request.Form(STAFFSALUTATION.UniqueID))
        If ControlCustomValues("STAFFSALUTATION") Is Nothing Then
            item.SALUTATION.SetValue(STAFFSALUTATION.Text)
        Else
            item.SALUTATION.SetValue(ControlCustomValues("STAFFSALUTATION"))
        End If
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STAFFSURNAME.UniqueID))
        If ControlCustomValues("STAFFSURNAME") Is Nothing Then
            item.SURNAME.SetValue(STAFFSURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STAFFSURNAME"))
        End If
        item.FIRSTNAME.IsEmpty = IsNothing(Request.Form(STAFFFIRSTNAME.UniqueID))
        If ControlCustomValues("STAFFFIRSTNAME") Is Nothing Then
            item.FIRSTNAME.SetValue(STAFFFIRSTNAME.Text)
        Else
            item.FIRSTNAME.SetValue(ControlCustomValues("STAFFFIRSTNAME"))
        End If
        item.MIDDLENAME.IsEmpty = IsNothing(Request.Form(STAFFMIDDLENAME.UniqueID))
        If ControlCustomValues("STAFFMIDDLENAME") Is Nothing Then
            item.MIDDLENAME.SetValue(STAFFMIDDLENAME.Text)
        Else
            item.MIDDLENAME.SetValue(ControlCustomValues("STAFFMIDDLENAME"))
        End If
        If STAFFTEACHER_FLAG.Checked Then
            item.TEACHER_FLAG.Value = (item.TEACHER_FLAGCheckedValue.Value)
        Else
            item.TEACHER_FLAG.Value = (item.TEACHER_FLAGUncheckedValue.Value)
        End If
        If STAFFSTATUS.Checked Then
            item.STATUS.Value = (item.STATUSCheckedValue.Value)
        Else
            item.STATUS.Value = (item.STATUSUncheckedValue.Value)
        End If
        Try
        item.GROUP_ID.IsEmpty = IsNothing(Request.Form(STAFFGROUP_ID.UniqueID))
        item.GROUP_ID.SetValue(STAFFGROUP_ID.Value)
        item.GROUP_IDItems.CopyFrom(STAFFGROUP_ID.Items)
        Catch ae As ArgumentException
            STAFFErrors.Add("GROUP_ID",String.Format(Resources.strings.CCS_IncorrectValue,"GROUP ID"))
        End Try
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(STAFFCAMPUS_CODE.UniqueID))
        item.CAMPUS_CODE.SetValue(STAFFCAMPUS_CODE.Value)
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STAFFhidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(STAFFhidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STAFFhidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(STAFFhidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STAFFErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"hidden_LAST_ALTERED_DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.LoginID.IsEmpty = IsNothing(Request.Form(STAFFLoginID.UniqueID))
        If ControlCustomValues("STAFFLoginID") Is Nothing Then
            item.LoginID.SetValue(STAFFLoginID.Text)
        Else
            item.LoginID.SetValue(ControlCustomValues("STAFFLoginID"))
        End If
        item.Hidden_LOGIN_ID.IsEmpty = IsNothing(Request.Form(STAFFHidden_LOGIN_ID.UniqueID))
        item.Hidden_LOGIN_ID.SetValue(STAFFHidden_LOGIN_ID.Value)
        If Not IsNothing(STAFFCheckboxList_SECURITY_FUNCTIONS.SelectedItem) Then
            item.CheckboxList_SECURITY_FUNCTIONS.SetValue(STAFFCheckboxList_SECURITY_FUNCTIONS.SelectedItem.Value)
        Else
            item.CheckboxList_SECURITY_FUNCTIONS.Value = Nothing
        End If
        item.CheckboxList_SECURITY_FUNCTIONSItems.CopyFrom(STAFFCheckboxList_SECURITY_FUNCTIONS.Items)
        item.Hidden_SECURITY_FUNCTIONS.IsEmpty = IsNothing(Request.Form(STAFFHidden_SECURITY_FUNCTIONS.UniqueID))
        item.Hidden_SECURITY_FUNCTIONS.SetValue(STAFFHidden_SECURITY_FUNCTIONS.Value)
        If EnableValidation Then
            item.Validate(STAFFData)
        End If
        STAFFErrors.Add(item.errors)
    End Sub
'End Record Form STAFF LoadItemFromRequest method

'Record Form STAFF GetRedirectUrl method @2-CA56AE31

    Protected Function GetSTAFFRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "STAFF_list.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF GetRedirectUrl method

'Record Form STAFF ShowErrors method @2-0308DF83

    Protected Sub STAFFShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFFErrors.Count - 1
        Select Case STAFFErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFFErrors(i)
        End Select
        Next i
        STAFFError.Visible = True
        STAFFErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF ShowErrors method

'Record Form STAFF Insert Operation @2-EDBD8559

    Protected Sub STAFF_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFItem = New STAFFItem()
        Dim ExecuteFlag As Boolean = True
        STAFFIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF Insert Operation

'Button Button_Insert OnClick. @3-C043C802
        If CType(sender,Control).ID = "STAFFButton_Insert" Then
            RedirectUrl = GetSTAFFRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @3-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record STAFF Event BeforeInsert. Action Custom Code @29-73254650
    ' -------------------------
    ' ERA: convert main fields to upper case for consistancy
            Me.STAFFStaffID.Text = Me.STAFFStaffID.Text.ToUpper
            Me.STAFFSURNAME.Text = Me.STAFFSURNAME.Text.ToUpper
            Me.STAFFFIRSTNAME.Text = Me.STAFFFIRSTNAME.Text.ToUpper
            Me.STAFFSALUTATION.Text = Me.STAFFSALUTATION.Text.ToUpper
            Me.STAFFMIDDLENAME.Text = Me.STAFFMIDDLENAME.Text.ToUpper
    ' -------------------------
'End Record STAFF Event BeforeInsert. Action Custom Code

'Record STAFF Event BeforeInsert. Action Declare Variable @35-BBECE40D
        Dim tmpSTAFF_ID As String = ""
'End Record STAFF Event BeforeInsert. Action Declare Variable

'Record STAFF Event BeforeInsert. Action Save Control Value @37-53927EA6
        tmpSTAFF_ID=STAFFStaffID.Text
'End Record STAFF Event BeforeInsert. Action Save Control Value

'Record STAFF Event BeforeInsert. Action Retrieve Value for Control @38-A4AB8846
        STAFFHidden_LOGIN_ID.Value = (New TextField("", tmpSTAFF_ID)).GetFormattedValue()
'End Record STAFF Event BeforeInsert. Action Retrieve Value for Control

'Record STAFF Event BeforeInsert. Action Custom Code @56-73254650
    ' -------------------------
    '5-May-2016|EA| ERA: get the Security Functions checkboxes that have been selected
    '	, and make strings for saving.
	' combine the selected array items then join to string (default to 'Z' as nulls not allowed)
	Dim checkItemsPQ as String = "Z"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STAFFCheckboxList_SECURITY_FUNCTIONS.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ""
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STAFFHidden_SECURITY_FUNCTIONS.Value = (checkItemsPQ.TrimEnd(","C))
	
    ' -------------------------
'End Record STAFF Event BeforeInsert. Action Custom Code

'Record Form STAFF BeforeInsert tail @2-D6266C5E
    STAFFParameters()
    STAFFLoadItemFromRequest(item, EnableValidation)
    If STAFFOperations.AllowInsert Then
        ErrorFlag=(STAFFErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFFData.InsertItem(item)
            Catch ex As Exception
                STAFFErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF BeforeInsert tail

'Record Form STAFF AfterInsert tail  @2-9AB2CB76
        End If
        ErrorFlag=(STAFFErrors.Count > 0)
        If ErrorFlag Then
            STAFFShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF AfterInsert tail 

'Record Form STAFF Update Operation @2-BFFF754A

    Protected Sub STAFF_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFItem = New STAFFItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFFIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF Update Operation

'Button Button_Update OnClick. @4-2F5C0486
        If CType(sender,Control).ID = "STAFFButton_Update" Then
            RedirectUrl = GetSTAFFRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @4-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STAFF Event BeforeUpdate. Action Custom Code @30-73254650
    ' -------------------------
    ' ERA: convert main fields to upper case for consistancy
            'Me.STAFFStaffID.Text = Me.STAFFStaffID.Text.ToUpper
            Me.STAFFSURNAME.Text = Me.STAFFSURNAME.Text.ToUpper
            Me.STAFFFIRSTNAME.Text = Me.STAFFFIRSTNAME.Text.ToUpper
            Me.STAFFSALUTATION.Text = Me.STAFFSALUTATION.Text.ToUpper
            Me.STAFFMIDDLENAME.Text = Me.STAFFMIDDLENAME.Text.ToUpper
    ' -------------------------
'End Record STAFF Event BeforeUpdate. Action Custom Code

'Record STAFF Event BeforeUpdate. Action Custom Code @57-73254650
    ' -------------------------
     '5-May-2016|EA| ERA: get the Security Functions checkboxes that have been selected
    '	, and make strings for saving.
	' combine the selected array items then join to string (default to 'Z' as nulls not allowed)
	Dim checkItemsPQ as String = "Z"
	Dim thisItemPQ As ListItem

	For Each thisItemPQ In STAFFCheckboxList_SECURITY_FUNCTIONS.Items
		if thisItemPQ.Selected then
			checkItemsPQ += (thisItemPQ.Value) + ""
		end if
	Next

	' put in hidden field for collection in BeforeBuild Update
	STAFFHidden_SECURITY_FUNCTIONS.Value = (checkItemsPQ.TrimEnd(","C))
	
    ' -------------------------
'End Record STAFF Event BeforeUpdate. Action Custom Code

'DEL      ' -------------------------
'DEL     	' ERA: update hidden LAST_ALTERED_BY/DATE to current info when saving for Update 
'DEL  	'	(Insert is taken care of in field defaults, this just duplicates these for Update)
'DEL  	item.hidden_last_altered_by.value=DBUtility.UserLogin.ToUpper()
'DEL  	item.hidden_last_altered_date.value= Now()
'DEL  
'DEL      ' -------------------------


'Record Form STAFF Before Update tail @2-CD609693
        STAFFParameters()
        STAFFLoadItemFromRequest(item, EnableValidation)
        If STAFFOperations.AllowUpdate Then
        ErrorFlag = (STAFFErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFFData.UpdateItem(item)
            Catch ex As Exception
                STAFFErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF Before Update tail

'Record Form STAFF Update Operation tail @2-9AB2CB76
        End If
        ErrorFlag=(STAFFErrors.Count > 0)
        If ErrorFlag Then
            STAFFShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF Update Operation tail

'Record Form STAFF Delete Operation @2-3114E5B2
    Protected Sub STAFF_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFFIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFFItem = New STAFFItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF Delete Operation

'Button Button_Delete OnClick. @5-88A1CF8F
        If CType(sender,Control).ID = "STAFFButton_Delete" Then
            RedirectUrl = GetSTAFFRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @5-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-191EEF6F
        STAFFParameters()
        STAFFLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-B0EA6FE2
        If ErrorFlag Then
            STAFFShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF Cancel Operation @2-771923A7

    Protected Sub STAFF_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFItem = New STAFFItem()
        STAFFIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFFLoadItemFromRequest(item, True)
'End Record Form STAFF Cancel Operation

'Record Form STAFF Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-21799B66
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        STAFF_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFFData = New STAFFDataProvider()
        STAFFOperations = New FormSupportedOperations(False, True, True, True, False)
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

