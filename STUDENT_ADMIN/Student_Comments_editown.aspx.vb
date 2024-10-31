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

Namespace DECV_PROD2007.Student_Comments_editown 'Namespace @1-0A43FC7B

'Forms Definition @1-C0E5E948
Public Class [Student_Comments_editownPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-55EFA86C
    Protected EditCommentsData As EditCommentsDataProvider
    Protected EditCommentsErrors As NameValueCollection = New NameValueCollection()
    Protected EditCommentsOperations As FormSupportedOperations
    Protected EditCommentsIsSubmitted As Boolean = False
    Protected Student_Comments_editownContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-CDF41147
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf,"")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref+item.Link_BacktoPastoralListHrefParameters.ToString("None","", ViewState)
            Link_BacktoPastoralList.DataBind()
            EditCommentsShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form EditComments Parameters @5-0736FCE5

    Protected Sub EditCommentsParameters()
        Dim item As new EditCommentsItem
        Try
            EditCommentsData.UrlCOMMENT_ID = IntegerParameter.GetParam("COMMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            EditCommentsData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            EditCommentsErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form EditComments Parameters

'Record Form EditComments Show method @5-9A4272A8
    Protected Sub EditCommentsShow()
        If EditCommentsOperations.None Then
            EditCommentsHolder.Visible = False
            Return
        End If
        Dim item As EditCommentsItem = EditCommentsItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not EditCommentsOperations.AllowRead
        EditCommentsErrors.Add(item.errors)
        If EditCommentsErrors.Count > 0 Then
            EditCommentsShowErrors()
            Return
        End If
'End Record Form EditComments Show method

'Record Form EditComments BeforeShow tail @5-7D153A07
        EditCommentsParameters()
        EditCommentsData.FillItem(item, IsInsertMode)
        EditCommentsHolder.DataBind()
        EditCommentsButton_Update.Visible=Not (IsInsertMode) AndAlso EditCommentsOperations.AllowUpdate
        EditCommentsButton_Delete.Visible=Not (IsInsertMode) AndAlso EditCommentsOperations.AllowDelete
        EditCommentsCOMMENT.Text=item.COMMENT.GetFormattedValue()
        EditCommentshidden_LAST_ALTERED_BY.Value = item.hidden_LAST_ALTERED_BY.GetFormattedValue()
        EditCommentshidden_LAST_ALTERED_DATE.Value = item.hidden_LAST_ALTERED_DATE.GetFormattedValue()
        EditCommentsACTIVE_STATUS.Value = item.ACTIVE_STATUS.GetFormattedValue()
        EditCommentsCOMMENT_TYPE.Value = item.COMMENT_TYPE.GetFormattedValue()
        EditCommentsSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        EditCommentslblSTUDENT_ID.Text = Server.HtmlEncode(item.lblSTUDENT_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditCommentslblCommentType.Text = Server.HtmlEncode(item.lblCommentType.GetFormattedValue()).Replace(vbCrLf,"<br>")
        EditCommentslbSpecialCommentType.Items.Add(new ListItem("Select Value",""))
        EditCommentslbSpecialCommentType.Items(0).Selected = True
        item.lbSpecialCommentTypeItems.SetSelection(item.lbSpecialCommentType.GetFormattedValue())
        If Not item.lbSpecialCommentTypeItems.GetSelectedItem() Is Nothing Then
            EditCommentslbSpecialCommentType.SelectedIndex = -1
        End If
        item.lbSpecialCommentTypeItems.CopyTo(EditCommentslbSpecialCommentType.Items)
'End Record Form EditComments BeforeShow tail

'TextArea COMMENT Event BeforeShow. Action Retrieve Value for Control @21-6F576605
            EditCommentsCOMMENT.Text = (New TextField("", (rtrim(item.COMMENT.GetFormattedValue())))).GetFormattedValue()
'End TextArea COMMENT Event BeforeShow. Action Retrieve Value for Control

'ListBox lbSpecialCommentType Event BeforeShow. Action Declare Variable @30-C4D11F5B
            Dim tmpCommentType As String = "0"
'End ListBox lbSpecialCommentType Event BeforeShow. Action Declare Variable

'ListBox lbSpecialCommentType Event BeforeShow. Action Save Control Value @29-0E85F0E8
            tmpCommentType=EditCommentsCOMMENT_TYPE.Value
'End ListBox lbSpecialCommentType Event BeforeShow. Action Save Control Value

'ListBox lbSpecialCommentType Event BeforeShow. Action Retrieve Value for Control @28-DE3693AC
            EditCommentslbSpecialCommentType.Value = (New TextField("", tmpCommentType)).GetFormattedValue()
'End ListBox lbSpecialCommentType Event BeforeShow. Action Retrieve Value for Control

'Record EditComments Event BeforeShow. Action Custom Code @27-73254650
    ' -------------------------
       ' ERA: 13-Aug-2010|EA| check if special groups of users and if so then show the Special Comment Type Label and drop-down
	' currently these groups: 2:PRINCIPALS; 3:ADMINISTRATORS; 6:ENROLMENT OFFICERS; 7:LEADING TEACHERS;9:SYSTEM;
	'	(unfuddle #200)
	'dim asPossibleTypes() as string = {"PROFILE", "anothertype"}
	'if Array.IndexOf(asPossibleTypes,(Dataitem.comment_type.value.toupper())) <> -1 then
	'	Grid_DisplayCommentslink_editcomment.visible=false
	'end if
	If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) and (tmpCommentType ="RESTRICTED" or tmpCommentType ="ALERT" or tmpCommentType ="WELLBEING") Then
            EditCommentslbSpecialCommentType.visible = true
			EditCommentslblCommentType.visible = true
	else
			EditCommentslbSpecialCommentType.visible = false
			EditCommentslblCommentType.visible = false
    End If
    ' -------------------------
'End Record EditComments Event BeforeShow. Action Custom Code

'Record Form EditComments Show method tail @5-CC872358
        If EditCommentsErrors.Count > 0 Then
            EditCommentsShowErrors()
        End If
    End Sub
'End Record Form EditComments Show method tail

'Record Form EditComments LoadItemFromRequest method @5-388C7847

    Protected Sub EditCommentsLoadItemFromRequest(item As EditCommentsItem, ByVal EnableValidation As Boolean)
        item.COMMENT.IsEmpty = IsNothing(Request.Form(EditCommentsCOMMENT.UniqueID))
        If ControlCustomValues("EditCommentsCOMMENT") Is Nothing Then
            item.COMMENT.SetValue(EditCommentsCOMMENT.Text)
        Else
            item.COMMENT.SetValue(ControlCustomValues("EditCommentsCOMMENT"))
        End If
        item.hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(EditCommentshidden_LAST_ALTERED_BY.UniqueID))
        item.hidden_LAST_ALTERED_BY.SetValue(EditCommentshidden_LAST_ALTERED_BY.Value)
        Try
        item.hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(EditCommentshidden_LAST_ALTERED_DATE.UniqueID))
        item.hidden_LAST_ALTERED_DATE.SetValue(EditCommentshidden_LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            EditCommentsErrors.Add("hidden_LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","yyyy-mm-dd H:nn"))
        End Try
        item.ACTIVE_STATUS.IsEmpty = IsNothing(Request.Form(EditCommentsACTIVE_STATUS.UniqueID))
        item.ACTIVE_STATUS.SetValue(EditCommentsACTIVE_STATUS.Value)
        item.COMMENT_TYPE.IsEmpty = IsNothing(Request.Form(EditCommentsCOMMENT_TYPE.UniqueID))
        item.COMMENT_TYPE.SetValue(EditCommentsCOMMENT_TYPE.Value)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(EditCommentsSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(EditCommentsSTUDENT_ID.Value)
        Catch ae As ArgumentException
            EditCommentsErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.lbSpecialCommentType.IsEmpty = IsNothing(Request.Form(EditCommentslbSpecialCommentType.UniqueID))
        item.lbSpecialCommentType.SetValue(EditCommentslbSpecialCommentType.Value)
        item.lbSpecialCommentTypeItems.CopyFrom(EditCommentslbSpecialCommentType.Items)
        If EnableValidation Then
            item.Validate(EditCommentsData)
        End If
        EditCommentsErrors.Add(item.errors)
    End Sub
'End Record Form EditComments LoadItemFromRequest method

'Record Form EditComments GetRedirectUrl method @5-6FD7BE3C

    Protected Function GetEditCommentsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Comments_maintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form EditComments GetRedirectUrl method

'Record Form EditComments ShowErrors method @5-A691C141

    Protected Sub EditCommentsShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To EditCommentsErrors.Count - 1
        Select Case EditCommentsErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & EditCommentsErrors(i)
        End Select
        Next i
        EditCommentsError.Visible = True
        EditCommentsErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form EditComments ShowErrors method

'Record Form EditComments Insert Operation @5-6FF34F25

    Protected Sub EditComments_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditCommentsItem = New EditCommentsItem()
        EditCommentsIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditComments Insert Operation

'Record Form EditComments BeforeInsert tail @5-7EF3A766
    EditCommentsParameters()
    EditCommentsLoadItemFromRequest(item, EnableValidation)
'End Record Form EditComments BeforeInsert tail

'Record Form EditComments AfterInsert tail  @5-BB80F62F
        ErrorFlag=(EditCommentsErrors.Count > 0)
        If ErrorFlag Then
            EditCommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditComments AfterInsert tail 

'Record Form EditComments Update Operation @5-D1AD5DBB

    Protected Sub EditComments_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditCommentsItem = New EditCommentsItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditCommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form EditComments Update Operation

'Button Button_Update OnClick. @6-F1D11DEA
        If CType(sender,Control).ID = "EditCommentsButton_Update" Then
            RedirectUrl = GetEditCommentsRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record EditComments Event BeforeUpdate. Action Retrieve Value for Control @18-6655E98F
        EditCommentshidden_LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring.toupper))).GetFormattedValue()
'End Record EditComments Event BeforeUpdate. Action Retrieve Value for Control

'Record EditComments Event BeforeUpdate. Action Retrieve Value for Control @19-48043642
        EditCommentshidden_LAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record EditComments Event BeforeUpdate. Action Retrieve Value for Control

'Record EditComments Event BeforeUpdate. Action Custom Code @31-73254650
    ' -------------------------
	' ERA: check for lbSpecialCommentType - if '0' then no change to hidden_COMMENT_TYPE, else then use lbSpecialCommentType
	' 	and set ALERT_TYPE to '1'
	' Also will need to change the Edit own comment page to allow reset/change of comment type from Alert etc to Regular

	' update the form objects so they will be loaded in the STUDENT_COMMENTLoadItemFromRequest below.
	if (not String.Equals(EditCommentslbSpecialCommentType.Value,"0")) then
		EditCommentsCOMMENT_TYPE.Value = EditCommentslbSpecialCommentType.Value	
	end if
    ' -------------------------
'End Record EditComments Event BeforeUpdate. Action Custom Code

'Record Form EditComments Before Update tail @5-2FC74DE8
        EditCommentsParameters()
        EditCommentsLoadItemFromRequest(item, EnableValidation)
        If EditCommentsOperations.AllowUpdate Then
        ErrorFlag = (EditCommentsErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditCommentsData.UpdateItem(item)
            Catch ex As Exception
                EditCommentsErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form EditComments Before Update tail

'Record Form EditComments Update Operation tail @5-3FCB9730
        End If
        ErrorFlag=(EditCommentsErrors.Count > 0)
        If ErrorFlag Then
            EditCommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form EditComments Update Operation tail

'Record Form EditComments Delete Operation @5-F62B8054
    Protected Sub EditComments_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        EditCommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As EditCommentsItem = New EditCommentsItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form EditComments Delete Operation

'Button Button_Delete OnClick. @7-E98899BD
        If CType(sender,Control).ID = "EditCommentsButton_Delete" Then
            RedirectUrl = GetEditCommentsRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @7-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @5-0A668F51
        EditCommentsParameters()
        EditCommentsLoadItemFromRequest(item, EnableValidation)
        If EditCommentsOperations.AllowDelete Then
        ErrorFlag = (EditCommentsErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                EditCommentsData.DeleteItem(item)
            Catch ex As Exception
                EditCommentsErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @5-6174768B
        End If
        If ErrorFlag Then
            EditCommentsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form EditComments Cancel Operation @5-BCD1955D

    Protected Sub EditComments_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As EditCommentsItem = New EditCommentsItem()
        EditCommentsIsSubmitted = True
        Dim RedirectUrl As String = ""
        EditCommentsLoadItemFromRequest(item, False)
'End Record Form EditComments Cancel Operation

'Button Button_Cancel OnClick. @9-1AC812EF
    If CType(sender,Control).ID = "EditCommentsButton_Cancel" Then
        RedirectUrl = GetEditCommentsRedirectUrl("Student_Comments_maintain.aspx", "COMMENT_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @9-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form EditComments Cancel Operation tail @5-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form EditComments Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-7ECC8715
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Comments_editownContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        EditCommentsData = New EditCommentsDataProvider()
        EditCommentsOperations = New FormSupportedOperations(False, True, False, True, True)
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

