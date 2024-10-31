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

Namespace DECV_PROD2007.Student_SubjectStatus_Maintain 'Namespace @1-28174ECF

'Forms Definition @1-8AFE78F5
Public Class [Student_SubjectStatus_MaintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-84315056
    Protected Student_SubjectStatus_searchData As Student_SubjectStatus_searchDataProvider
    Protected Student_SubjectStatus_searchErrors As NameValueCollection = New NameValueCollection()
    Protected Student_SubjectStatus_searchOperations As FormSupportedOperations
    Protected Student_SubjectStatus_searchIsSubmitted As Boolean = False
    Protected Student_SubjectStatus_ResultData As Student_SubjectStatus_ResultDataProvider
    Protected Student_SubjectStatus_ResultCurrentRowNumber As Integer
    Protected Student_SubjectStatus_ResultIsSubmitted As Boolean = False
    Protected Student_SubjectStatus_ResultErrors As New NameValueCollection()
    Protected Student_SubjectStatus_ResultOperations As FormSupportedOperations
    Protected Student_SubjectStatus_ResultDataItem As Student_SubjectStatus_ResultItem
    Protected Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEName As String
    Protected Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEDateControl As String
    Protected Student_SubjectStatus_MaintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E2CAA2C8
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Student_SubjectStatus_searchShow()
            Student_SubjectStatus_ResultBind()
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel1 Event BeforeShow. Action Hide-Show Component @76-6C2FC11A
        Dim Urlflagdone_76_1 As IntegerField = New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("flagdone"))
        Dim ExprParam2_76_2 As IntegerField = New IntegerField("", (1))
        If FieldBase.EqualOp(Urlflagdone_76_1, ExprParam2_76_2) Then
            Panel1.Visible = True
        End If
'End Panel Panel1 Event BeforeShow. Action Hide-Show Component

'Page Student_SubjectStatus_Maintain Event BeforeShow. Action Hide-Show Component @103-6081EB10
        Dim Urlhidden_Staff_ID_103_1 As TextField = New TextField("""", System.Web.HttpContext.Current.Request.QueryString("hidden_Staff_ID"))
        Dim ExprParam2_103_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urlhidden_Staff_ID_103_1, ExprParam2_103_2) Then
            Student_SubjectStatus_ResultRepeater.Visible = False
        End If
'End Page Student_SubjectStatus_Maintain Event BeforeShow. Action Hide-Show Component

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form Student_SubjectStatus_search Parameters @3-1AB38798

    Protected Sub Student_SubjectStatus_searchParameters()
        Dim item As new Student_SubjectStatus_searchItem
        Try
            Student_SubjectStatus_searchData.Urlhidden_Staff_id = TextParameter.GetParam("hidden_Staff_id", ParameterSourceType.URL, "", Trim(session("UserID").toupper), false)
        Catch e As Exception
            Student_SubjectStatus_searchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form Student_SubjectStatus_search Parameters

'Record Form Student_SubjectStatus_search Show method @3-F4B5A092
    Protected Sub Student_SubjectStatus_searchShow()
        If Student_SubjectStatus_searchOperations.None Then
            Student_SubjectStatus_searchHolder.Visible = False
            Return
        End If
        Dim item As Student_SubjectStatus_searchItem = Student_SubjectStatus_searchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not Student_SubjectStatus_searchOperations.AllowRead
        item.ClearParametersHref = "Student_SubjectStatus_Maintain.aspx"
        item.s_Staff_ID.SetValue(Trim(session("UserID").toupper))
        Student_SubjectStatus_searchErrors.Add(item.errors)
        If Student_SubjectStatus_searchErrors.Count > 0 Then
            Student_SubjectStatus_searchShowErrors()
            Return
        End If
'End Record Form Student_SubjectStatus_search Show method

'Record Form Student_SubjectStatus_search BeforeShow tail @3-FDB956F4
        Student_SubjectStatus_searchParameters()
        Student_SubjectStatus_searchData.FillItem(item, IsInsertMode)
        Student_SubjectStatus_searchHolder.DataBind()
        Student_SubjectStatus_searchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        Student_SubjectStatus_searchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_STAFF_SUBJECT_ID;s_STUDENT_ID;flagdone;List_Staff_ID;selected_STAFF_SUBJECT_ID;hidden_Staff_id;s_DefaultingFlag", ViewState)
        Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Items.Add(new ListItem("Select a subject",""))
        Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Items(0).Selected = True
        item.s_STAFF_SUBJECT_IDItems.SetSelection(item.s_STAFF_SUBJECT_ID.GetFormattedValue())
        If Not item.s_STAFF_SUBJECT_IDItems.GetSelectedItem() Is Nothing Then
            Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.SelectedIndex = -1
        End If
        item.s_STAFF_SUBJECT_IDItems.CopyTo(Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Items)
        Student_SubjectStatus_searchs_Staff_ID.Text = Server.HtmlEncode(item.s_Staff_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_SubjectStatus_searchList_Staff_ID.Items.Add(new ListItem("Select Staff Member First",""))
        Student_SubjectStatus_searchList_Staff_ID.Items(0).Selected = True
        item.List_Staff_IDItems.SetSelection(item.List_Staff_ID.GetFormattedValue())
        If Not item.List_Staff_IDItems.GetSelectedItem() Is Nothing Then
            Student_SubjectStatus_searchList_Staff_ID.SelectedIndex = -1
        End If
        item.List_Staff_IDItems.CopyTo(Student_SubjectStatus_searchList_Staff_ID.Items)
        Student_SubjectStatus_searchhidden_Staff_id.Value = item.hidden_Staff_id.GetFormattedValue()
        Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Items.Add(new ListItem("Click 'Search' to fill this list, then select Subject",""))
        Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Items(0).Selected = True
        item.selected_STAFF_SUBJECT_IDItems.SetSelection(item.selected_STAFF_SUBJECT_ID.GetFormattedValue())
        If Not item.selected_STAFF_SUBJECT_IDItems.GetSelectedItem() Is Nothing Then
            Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.SelectedIndex = -1
        End If
        item.selected_STAFF_SUBJECT_IDItems.CopyTo(Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Items)
        item.s_DefaultingFlagItems.SetSelection(item.s_DefaultingFlag.GetFormattedValue())
        Student_SubjectStatus_searchs_DefaultingFlag.SelectedIndex = -1
        item.s_DefaultingFlagItems.CopyTo(Student_SubjectStatus_searchs_DefaultingFlag.Items)
'End Record Form Student_SubjectStatus_search BeforeShow tail

'Record Student_SubjectStatus_search Event BeforeShow. Action Custom Code @81-73254650
    ' -------------------------
    ' ERA: hide some items if Teacher, show if LPLT etc
    ' -------------------------
		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
            Student_SubjectStatus_searchs_Staff_ID.visible = false
			Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.visible = false
			Student_SubjectStatus_searchList_Staff_ID.visible = true
			Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.visible = true
		else
		 	Student_SubjectStatus_searchs_Staff_ID.visible = true
			Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.visible = true
			Student_SubjectStatus_searchList_Staff_ID.visible = false
			Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.visible = false
    	End If
'End Record Student_SubjectStatus_search Event BeforeShow. Action Custom Code

'Record Form Student_SubjectStatus_search Show method tail @3-58519489
        If Student_SubjectStatus_searchErrors.Count > 0 Then
            Student_SubjectStatus_searchShowErrors()
        End If
    End Sub
'End Record Form Student_SubjectStatus_search Show method tail

'Record Form Student_SubjectStatus_search LoadItemFromRequest method @3-02C6AE2B

    Protected Sub Student_SubjectStatus_searchLoadItemFromRequest(item As Student_SubjectStatus_searchItem, ByVal EnableValidation As Boolean)
        item.s_STAFF_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.UniqueID))
        item.s_STAFF_SUBJECT_ID.SetValue(Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Value)
        item.s_STAFF_SUBJECT_IDItems.CopyFrom(Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Items)
        item.List_Staff_ID.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_searchList_Staff_ID.UniqueID))
        item.List_Staff_ID.SetValue(Student_SubjectStatus_searchList_Staff_ID.Value)
        item.List_Staff_IDItems.CopyFrom(Student_SubjectStatus_searchList_Staff_ID.Items)
        item.hidden_Staff_id.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_searchhidden_Staff_id.UniqueID))
        item.hidden_Staff_id.SetValue(Student_SubjectStatus_searchhidden_Staff_id.Value)
        item.selected_STAFF_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.UniqueID))
        item.selected_STAFF_SUBJECT_ID.SetValue(Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Value)
        item.selected_STAFF_SUBJECT_IDItems.CopyFrom(Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Items)
        item.s_DefaultingFlag.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_searchs_DefaultingFlag.UniqueID))
        If Not IsNothing(Student_SubjectStatus_searchs_DefaultingFlag.SelectedItem) Then
            item.s_DefaultingFlag.SetValue(Student_SubjectStatus_searchs_DefaultingFlag.SelectedItem.Value)
        Else
            item.s_DefaultingFlag.Value = Nothing
        End If
        item.s_DefaultingFlagItems.CopyFrom(Student_SubjectStatus_searchs_DefaultingFlag.Items)
        If EnableValidation Then
            item.Validate(Student_SubjectStatus_searchData)
        End If
        Student_SubjectStatus_searchErrors.Add(item.errors)
    End Sub
'End Record Form Student_SubjectStatus_search LoadItemFromRequest method

'Record Form Student_SubjectStatus_search GetRedirectUrl method @3-A6C21310

    Protected Function GetStudent_SubjectStatus_searchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_SubjectStatus_Maintain.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form Student_SubjectStatus_search GetRedirectUrl method

'Record Form Student_SubjectStatus_search ShowErrors method @3-DB612B29

    Protected Sub Student_SubjectStatus_searchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To Student_SubjectStatus_searchErrors.Count - 1
        Select Case Student_SubjectStatus_searchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & Student_SubjectStatus_searchErrors(i)
        End Select
        Next i
        Student_SubjectStatus_searchError.Visible = True
        Student_SubjectStatus_searchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form Student_SubjectStatus_search ShowErrors method

'Record Form Student_SubjectStatus_search Insert Operation @3-28E23A62

    Protected Sub Student_SubjectStatus_search_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        Student_SubjectStatus_searchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Student_SubjectStatus_search Insert Operation

'Record Form Student_SubjectStatus_search BeforeInsert tail @3-124A145A
    Student_SubjectStatus_searchParameters()
    Student_SubjectStatus_searchLoadItemFromRequest(item, EnableValidation)
'End Record Form Student_SubjectStatus_search BeforeInsert tail

'Record Form Student_SubjectStatus_search AfterInsert tail  @3-7B08734C
        ErrorFlag=(Student_SubjectStatus_searchErrors.Count > 0)
        If ErrorFlag Then
            Student_SubjectStatus_searchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Student_SubjectStatus_search AfterInsert tail 

'Record Form Student_SubjectStatus_search Update Operation @3-00F43C58

    Protected Sub Student_SubjectStatus_search_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        Student_SubjectStatus_searchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form Student_SubjectStatus_search Update Operation

'Record Form Student_SubjectStatus_search Before Update tail @3-124A145A
        Student_SubjectStatus_searchParameters()
        Student_SubjectStatus_searchLoadItemFromRequest(item, EnableValidation)
'End Record Form Student_SubjectStatus_search Before Update tail

'Record Form Student_SubjectStatus_search Update Operation tail @3-7B08734C
        ErrorFlag=(Student_SubjectStatus_searchErrors.Count > 0)
        If ErrorFlag Then
            Student_SubjectStatus_searchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Student_SubjectStatus_search Update Operation tail

'Record Form Student_SubjectStatus_search Delete Operation @3-81DE1470
    Protected Sub Student_SubjectStatus_search_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        Student_SubjectStatus_searchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form Student_SubjectStatus_search Delete Operation

'Record Form BeforeDelete tail @3-124A145A
        Student_SubjectStatus_searchParameters()
        Student_SubjectStatus_searchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @3-CF0D72D2
        If ErrorFlag Then
            Student_SubjectStatus_searchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form Student_SubjectStatus_search Cancel Operation @3-7F1763D6

    Protected Sub Student_SubjectStatus_search_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        Student_SubjectStatus_searchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Student_SubjectStatus_searchLoadItemFromRequest(item, True)
'End Record Form Student_SubjectStatus_search Cancel Operation

'Record Form Student_SubjectStatus_search Cancel Operation tail @3-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form Student_SubjectStatus_search Cancel Operation tail

'Record Form Student_SubjectStatus_search Search Operation @3-A1BECECA
    Protected Sub Student_SubjectStatus_search_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        Student_SubjectStatus_searchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As Student_SubjectStatus_searchItem = New Student_SubjectStatus_searchItem()
        Student_SubjectStatus_searchLoadItemFromRequest(item, EnableValidation)
'End Record Form Student_SubjectStatus_search Search Operation

'Button Button_DoSearch OnClick. @5-2CFBAEB7
        If CType(sender,Control).ID = "Student_SubjectStatus_searchButton_DoSearch" Then
            RedirectUrl = GetStudent_SubjectStatus_searchRedirectUrl("", "flagdone;s_STAFF_SUBJECT_ID;List_Staff_ID;hidden_Staff_id;selected_STAFF_SUBJECT_ID;s_DefaultingFlag")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @5-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form Student_SubjectStatus_search Search Operation tail @3-6898A603
        ErrorFlag = Student_SubjectStatus_searchErrors.Count > 0
        If ErrorFlag Then
            Student_SubjectStatus_searchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In Student_SubjectStatus_searchs_STAFF_SUBJECT_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_STAFF_SUBJECT_ID=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In Student_SubjectStatus_searchList_Staff_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "List_Staff_ID=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            Params = Params & IIf(Student_SubjectStatus_searchhidden_Staff_id.Value <> "",("hidden_Staff_id=" & Server.UrlEncode(Student_SubjectStatus_searchhidden_Staff_id.Value) & "&"), "")
            For Each li In Student_SubjectStatus_searchselected_STAFF_SUBJECT_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "selected_STAFF_SUBJECT_ID=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In Student_SubjectStatus_searchs_DefaultingFlag.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_DefaultingFlag=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form Student_SubjectStatus_search Search Operation tail

'EditableGrid Student_SubjectStatus_Result Bind @13-CBBDDA9B
    Protected Sub Student_SubjectStatus_ResultBind()
        If Student_SubjectStatus_ResultOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Student_SubjectStatus_Result",GetType(Student_SubjectStatus_ResultDataProvider.SortFields), 50, 100)
        End If
'End EditableGrid Student_SubjectStatus_Result Bind

'EditableGrid Form Student_SubjectStatus_Result BeforeShow tail @13-47FE1557
        Student_SubjectStatus_ResultParameters()
        Student_SubjectStatus_ResultData.SortField = CType(ViewState("Student_SubjectStatus_ResultSortField"), Student_SubjectStatus_ResultDataProvider.SortFields)
        Student_SubjectStatus_ResultData.SortDir = CType(ViewState("Student_SubjectStatus_ResultSortDir"), SortDirections)
        Student_SubjectStatus_ResultData.PageNumber = CType(ViewState("Student_SubjectStatus_ResultPageNumber"), Integer)
        Student_SubjectStatus_ResultData.RecordsPerPage = CType(ViewState("Student_SubjectStatus_ResultPageSize"), Integer)
        Student_SubjectStatus_ResultRepeater.DataSource = Student_SubjectStatus_ResultData.GetResultSet(PagesCount, Student_SubjectStatus_ResultOperations)
        ViewState("Student_SubjectStatus_ResultPagesCount") = PagesCount
        ViewState("Student_SubjectStatus_ResultFormState") = New Hashtable()
        ViewState("Student_SubjectStatus_ResultRowState") = New Hashtable()
        Student_SubjectStatus_ResultRepeater.DataBind()
        Dim item As Student_SubjectStatus_ResultItem = Student_SubjectStatus_ResultDataItem
        If IsNothing(item) Then item = New Student_SubjectStatus_ResultItem()
        FooterIndex = Student_SubjectStatus_ResultRepeater.Controls.Count - 1
        Dim Script As Literal = CType(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var Student_SubjectStatus_ResultStaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "Student_SubjectStatus_ResultStaticElementsID = new Array ("
        Elements.Text += "var Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecordsID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords").ClientID + """),"
        Elements.Text += "var Student_SubjectStatus_ResultButton_SubmitID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("Student_SubjectStatus_ResultButton_Submit").ClientID + """),"
        Elements.Text += "var Student_SubjectStatus_ResultCancelID=2;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("Student_SubjectStatus_ResultCancel").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Elements.Text &= "var Student_SubjectStatus_ResultEmptyRows = 0;" + vbCrLf
        Script.Text &= "Student_SubjectStatus_ResultElements = new Array ("
        Elements.Text &= "var Student_SubjectStatus_ResultDEFAULTING_STATUS_IDID=0;" + vbCrLf
        Elements.Text &= "var Student_SubjectStatus_ResultWARNING_LETTER_IdID=1;" + vbCrLf
        Elements.Text &= "var Student_SubjectStatus_ResultWARNING_SENT_DATEID=2;" + vbCrLf
        Elements.Text &= "var Student_SubjectStatus_ResultHidden_DefaultingStatusID=3;" + vbCrLf
        Elements.Text &= "var Student_SubjectStatus_ResultDEFAULTING_STATUS_DATEID=4;" + vbCrLf
        Dim col As Control
        For Each col In Student_SubjectStatus_ResultRepeater.Controls
            If CType(col, RepeaterItem).ItemType = ListItemType.Item Or CType(col, RepeaterItem).ItemType = ListItemType.AlternatingItem Then
                Dim arr as String = ""
                arr += "document.getElementById(""" & col.FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_ID").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("Student_SubjectStatus_ResultWARNING_LETTER_Id").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("Student_SubjectStatus_ResultWARNING_SENT_DATE").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("Student_SubjectStatus_ResultHidden_DefaultingStatus").ClientID & """),"
                arr += "document.getElementById(""" & col.FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE").ClientID & """),"
                Script.Text += vbCrLf + "new Array(" + arr.TrimEnd(New Char() {","}) + "),"
            End If
        Next col
        Script.Text = Script.Text.TrimEnd(New Char() {","}) + ");"
        Dim Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSMT_SUBMISSIONSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_ASSMT_SUBMISSIONSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {10,25,50,80,100}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Student_SubjectStatus_ResultButton_Submit As System.Web.UI.WebControls.Button = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("Student_SubjectStatus_ResultButton_Submit"),System.Web.UI.WebControls.Button)
        Dim Student_SubjectStatus_ResultCancel As System.Web.UI.WebControls.Button = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("Student_SubjectStatus_ResultCancel"),System.Web.UI.WebControls.Button)
        Dim Sorter_WARNING_LETTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_WARNING_LETTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Warning_Sent_DateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_Warning_Sent_DateSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DEFAULTING_STATUS_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_DEFAULTING_STATUS_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DEFAULTING_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Sorter_DEFAULTING_STATUSSorter"),DECV_PROD2007.Controls.Sorter)


        Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords.Text = Server.HtmlEncode(item.Student_SubjectStatus_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Student_SubjectStatus_ResultButton_Submit.Visible = Student_SubjectStatus_ResultOperations.Editable
        If Not CType(Student_SubjectStatus_ResultRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            Student_SubjectStatus_ResultRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If Student_SubjectStatus_ResultErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Student_SubjectStatus_ResultError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In Student_SubjectStatus_ResultErrors
                ErrorLabel.Text += Student_SubjectStatus_ResultErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form Student_SubjectStatus_Result BeforeShow tail

'Label Student_SubjectStatus_TotalRecords Event BeforeShow. Action Retrieve number of records @15-3D1D73E8
            Student_SubjectStatus_ResultStudent_SubjectStatus_TotalRecords.Text = Student_SubjectStatus_ResultData.RecordCount.ToString()
'End Label Student_SubjectStatus_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid Student_SubjectStatus_Result Event BeforeShow. Action Custom Code @117-73254650
    ' -------------------------
    ' ERA: Hide Submit and Cancel buttons if no records
	If PagesCount = 0 Then
		Student_SubjectStatus_ResultButton_Submit.Visible = False
		Student_SubjectStatus_ResultCancel.Visible = False
	End if

    ' -------------------------
'End EditableGrid Student_SubjectStatus_Result Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL       ' ERA: only display if something to display, and not if initial open
'DEL  	'if (isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STUDENT_ID) and isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_SUBJECT_ID) and isnothing(ASSIGNMENT_SUBMISSION_STU1Data.Urls_STUDENT_SUBJECT_STAFF_ID)) then
'DEL  	'	ASSIGNMENT_SUBMISSION_STU1Repeater.visible=false
'DEL      'end if
'DEL      ' -------------------------


'EditableGrid Student_SubjectStatus_Result Bind tail @13-8EAE8623
        Student_SubjectStatus_ResultShowErrors(New ArrayList(CType(Student_SubjectStatus_ResultRepeater.DataSource, ICollection)), Student_SubjectStatus_ResultRepeater.Items)
    End Sub
'End EditableGrid Student_SubjectStatus_Result Bind tail

'EditableGrid Student_SubjectStatus_Result Table Parameters @13-F88201F5
    Protected Sub Student_SubjectStatus_ResultParameters()
        Try
        Dim item As new Student_SubjectStatus_ResultItem
            Student_SubjectStatus_ResultData.Urlhidden_Staff_id = TextParameter.GetParam("hidden_Staff_id", ParameterSourceType.URL, "", Trim(session("UserID").toupper), false)
            Student_SubjectStatus_ResultData.Urls_DefaultingFlag = TextParameter.GetParam("s_DefaultingFlag", ParameterSourceType.URL, "", "[D]", false)
            Student_SubjectStatus_ResultData.Urls_STAFF_SUBJECT_ID = IntegerParameter.GetParam("s_STAFF_SUBJECT_ID", ParameterSourceType.URL, "", 0, false)
            Student_SubjectStatus_ResultData.Urlselected_STAFF_SUBJECT_ID = IntegerParameter.GetParam("selected_STAFF_SUBJECT_ID", ParameterSourceType.URL, "", 0, false)
            Student_SubjectStatus_ResultData.CtrlDEFAULTING_STATUS_ID = TextParameter.GetParam(item.DEFAULTING_STATUS_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            Student_SubjectStatus_ResultData.CtrlWARNING_LETTER_Id = TextParameter.GetParam(item.WARNING_LETTER_Id.Value, ParameterSourceType.Control, "", Nothing, false)
            Student_SubjectStatus_ResultData.CtrlWARNING_SENT_DATE = DateParameter.GetParam(item.WARNING_SENT_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
            Student_SubjectStatus_ResultData.CtrlDEFAULTING_STATUS_DATE = DateParameter.GetParam(item.DEFAULTING_STATUS_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yy", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = Student_SubjectStatus_ResultRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(Student_SubjectStatus_ResultRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid Student_SubjectStatus_Result: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid Student_SubjectStatus_Result Table Parameters

'EditableGrid Student_SubjectStatus_Result ItemDataBound event @13-8960732C
    Protected Sub Student_SubjectStatus_ResultItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As Student_SubjectStatus_ResultItem = DirectCast(e.Item.DataItem, Student_SubjectStatus_ResultItem)
        Dim Item as Student_SubjectStatus_ResultItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Student_SubjectStatus_ResultCurrentRowNumber = Student_SubjectStatus_ResultCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("Student_SubjectStatus_ResultFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("Student_SubjectStatus_ResultRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultSS_SUBJECT_ID").UniqueID) = DataItem.SS_SUBJECT_ID.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultSS_STUDENT_ID").UniqueID) = DataItem.SS_STUDENT_ID.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultSUBJ_ENROL_STATUS").UniqueID) = DataItem.SUBJ_ENROL_STATUS.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS").UniqueID) = DataItem.NUM_OF_ASSIGNMENTS.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentName").UniqueID) = DataItem.lbl_StudentName.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Letter").UniqueID) = DataItem.Lbl_Warning_Letter.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Sent_Date").UniqueID) = DataItem.Lbl_Warning_Sent_Date.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentEmail").UniqueID) = DataItem.lbl_StudentEmail.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_Resultlabel_ALERTS").UniqueID) = DataItem.label_ALERTS.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultlblDefaultingStatusDate").UniqueID) = DataItem.lblDefaultingStatusDate.Value
            ViewState(e.Item.FindControl("Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS").UniqueID) = DataItem.LIST_OF_ASSIGNMENTS.Value
            Dim Student_SubjectStatus_ResultSS_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultSS_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultSS_STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultSS_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Student_SubjectStatus_ResultSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultDEFAULTING_STATUS_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_ID"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim Student_SubjectStatus_Resultlbl_StudentName As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentName"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultLbl_Warning_Letter As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Letter"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultLbl_Warning_Sent_Date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Sent_Date"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultWARNING_LETTER_Id As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultWARNING_LETTER_Id"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim Student_SubjectStatus_ResultWARNING_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultWARNING_SENT_DATE"),System.Web.UI.WebControls.TextBox)
            Dim Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE"),System.Web.UI.WebControls.PlaceHolder)
            Dim Student_SubjectStatus_Resultlbl_StudentEmail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentEmail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Student_SubjectStatus_Resultlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlabel_ALERTS"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultlblDefaultingStatusDate As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultlblDefaultingStatusDate"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultHidden_DefaultingStatus As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultHidden_DefaultingStatus"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS"),System.Web.UI.WebControls.Literal)
            Dim Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
            CType(Page,CCPage).ControlAttributes.Add(Student_SubjectStatus_ResultRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Student_SubjectStatus_ResultCurrentRowNumber), AttributeOption.Multiple)
            DataItem.SS_STUDENT_IDHref = "StudentSummary.aspx"
            DataItem.SS_STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((Datetime.Today.Year).ToString()))
            Student_SubjectStatus_ResultSS_STUDENT_ID.HRef = DataItem.SS_STUDENT_IDHref & DataItem.SS_STUDENT_IDHrefParameters.ToString("GET","", ViewState)
            Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.Items.Add(new ListItem("Select Value",""))
            Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.Items(0).Selected = True
            DataItem.DEFAULTING_STATUS_IDItems.SetSelection(DataItem.DEFAULTING_STATUS_ID.GetFormattedValue())
            If Not DataItem.DEFAULTING_STATUS_IDItems.GetSelectedItem() Is Nothing Then
                Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.SelectedIndex = -1
            End If
            DataItem.DEFAULTING_STATUS_IDItems.CopyTo(Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.Items)
            Student_SubjectStatus_ResultWARNING_LETTER_Id.Items.Add(new ListItem("Select Value",""))
            Student_SubjectStatus_ResultWARNING_LETTER_Id.Items(0).Selected = True
            DataItem.WARNING_LETTER_IdItems.SetSelection(DataItem.WARNING_LETTER_Id.GetFormattedValue())
            If Not DataItem.WARNING_LETTER_IdItems.GetSelectedItem() Is Nothing Then
                Student_SubjectStatus_ResultWARNING_LETTER_Id.SelectedIndex = -1
            End If
            DataItem.WARNING_LETTER_IdItems.CopyTo(Student_SubjectStatus_ResultWARNING_LETTER_Id.Items)
            Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEName = "Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE"
            Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATEDateControl = e.Item.FindControl("Student_SubjectStatus_ResultWARNING_SENT_DATE").ClientID
            Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE.DataBind()
            DataItem.lbl_StudentEmailHref = ""
            Student_SubjectStatus_Resultlbl_StudentEmail.HRef = DataItem.lbl_StudentEmailHref & DataItem.lbl_StudentEmailHrefParameters.ToString("GET","", ViewState)
        End If
'End EditableGrid Student_SubjectStatus_Result ItemDataBound event

'Student_SubjectStatus_Result control Before Show @13-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End Student_SubjectStatus_Result control Before Show

'Get Control @72-FBB494E2
            Dim Student_SubjectStatus_Resultlbl_StudentName As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentName"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label lbl_StudentName Event BeforeShow. Action DLookup @73-CF0D01A4
            Student_SubjectStatus_Resultlbl_StudentName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "dbo.ProperCase(RTRIM(dbo.STUDENT.FIRST_NAME))+ ' ' + RTRIM(dbo.STUDENT.SURNAME) " & " FROM " & "STUDENT" & " WHERE " & "STUDENT_ID = " & Item.SS_STUDENT_ID.Value))).GetFormattedValue("")
'End Label lbl_StudentName Event BeforeShow. Action DLookup

'Get Control @119-25C3E645
            Dim Student_SubjectStatus_Resultlbl_StudentEmail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlbl_StudentEmail"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link lbl_StudentEmail Event BeforeShow. Action DLookup @120-8BF2EE77
            Student_SubjectStatus_Resultlbl_StudentEmail.InnerHtml = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "isnull(STUDENT_EMAIL,'')" & " FROM " & "STUDENT" & " WHERE " & "STUDENT_ID = " & Item.SS_STUDENT_ID.Value))).GetFormattedValue("")
'End Link lbl_StudentEmail Event BeforeShow. Action DLookup

'Link lbl_StudentEmail Event BeforeShow. Action Custom Code @121-73254650
    ' -------------------------
 	' ERA: March 2012 make it an email mailto link 
	if (Student_SubjectStatus_Resultlbl_StudentEmail.InnerHtml <> "") then
		Student_SubjectStatus_Resultlbl_StudentEmail.HRef = "mailto:" + Student_SubjectStatus_Resultlbl_StudentEmail.InnerHtml + ""
	end if
    ' -------------------------
'End Link lbl_StudentEmail Event BeforeShow. Action Custom Code

'Get Control @122-00C59211
            Dim Student_SubjectStatus_Resultlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_Resultlabel_ALERTS"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label label_ALERTS Event BeforeShow. Action Declare Variable @123-E947C756
            Dim intAlerts As Int64 = 0
'End Label label_ALERTS Event BeforeShow. Action Declare Variable

'Label label_ALERTS Event BeforeShow. Action DLookup @124-991445B0
            intAlerts = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(student_id)" & " FROM " & "view_StudentSummary_Alerts" & " WHERE " & "STUDENT_ID = " & Item.SS_STUDENT_ID.Value & ""))).Value, Int64)
'End Label label_ALERTS Event BeforeShow. Action DLookup

'Label label_ALERTS Event BeforeShow. Action Custom Code @125-73254650
    ' -------------------------
	Student_SubjectStatus_Resultlabel_ALERTS.Visible = false
	Student_SubjectStatus_Resultlabel_ALERTS.Text = "<font color='red'><b>Alert!</b></font>"

    if (intAlerts > 0) then
		Student_SubjectStatus_Resultlabel_ALERTS.Visible = true
	end if
    ' -------------------------
'End Label label_ALERTS Event BeforeShow. Action Custom Code

'Get Control @127-9D5F19E5
            Dim Student_SubjectStatus_ResultHidden_DefaultingStatus As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultHidden_DefaultingStatus"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden Hidden_DefaultingStatus Event BeforeShow. Action Retrieve Value for Control @136-0F884890
            Student_SubjectStatus_ResultHidden_DefaultingStatus.Value = (New TextField("", (DataItem.DEFAULTING_STATUS_ID.GetFormattedValue()))).GetFormattedValue()
'End Hidden Hidden_DefaultingStatus Event BeforeShow. Action Retrieve Value for Control

'Student_SubjectStatus_Result control Before Show tail @13-477CF3C9
        End If
'End Student_SubjectStatus_Result control Before Show tail

'EditableGrid Student_SubjectStatus_Result BeforeShowRow event @13-59F67308
        If Not IsNothing(Item) Then Student_SubjectStatus_ResultDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid Student_SubjectStatus_Result BeforeShowRow event

'EditableGrid Student_SubjectStatus_Result Event BeforeShowRow. Action Custom Code @115-73254650
    ' -------------------------
		Dim Warning_Letter_label As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Letter"),System.Web.UI.WebControls.Literal)
        Dim Warning_Sent_Date_label As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLbl_Warning_Sent_Date"),System.Web.UI.WebControls.Literal)
		Dim WARNING_LETTER_Id_dropdown As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultWARNING_LETTER_Id"),System.Web.UI.HtmlControls.HtmlSelect)
		Dim WARNING_SENT_DATE_texbox As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultWARNING_SENT_DATE"),System.Web.UI.WebControls.TextBox)
		Dim WARNING_SENT_DATE_datepicker As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE"),System.Web.UI.WebControls.PlaceHolder)

		'ERA: 7-May-2012|EA| remove all but System (Group 9) ability to *change* the Warning Letter Fields
		'   (removes Principals(2), Admin (3), Enrolment (6), and Leading Teachers (7))
		' Leading Teachers etc can still view any Teacher, and can update 'Defaulting Status' as needed.
		'If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
		If (DBUtility.AuthorizeUser(New String(){"9"})) Then
        	Warning_Letter_label.visible=false
			Warning_Sent_Date_label.visible = false
			WARNING_LETTER_Id_dropdown.visible = true
			WARNING_SENT_DATE_texbox.visible = true
			WARNING_SENT_DATE_datepicker.visible = true
		else
			Warning_Letter_label.visible = true
			Warning_Sent_Date_label.visible = true
			WARNING_LETTER_Id_dropdown.visible = false
			WARNING_SENT_DATE_texbox.visible = false
			WARNING_SENT_DATE_datepicker.visible = false
		end if

    ' -------------------------
'End EditableGrid Student_SubjectStatus_Result Event BeforeShowRow. Action Custom Code

'EditableGrid Student_SubjectStatus_Result Event BeforeShowRow. Action Custom Code @132-73254650
    ' -------------------------
    'ERA: 1-May-2014|EA| unfuddle #636 get list of assignments from user function using student_id and subject_id
    Dim Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS"),System.Web.UI.WebControls.Literal)
    Dim ListOfAssignments as string = "<em>none</em>"
    ListOfAssignments = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT dbo.AssignmentSubmissionList("& Item.SS_STUDENT_ID.Value & "," & Item.SS_SUBJECT_ID.Value & ")"))).GetFormattedValue()
    ListOfAssignments = ListOfAssignments.Replace("[","<u class='fade'>").replace("]","</u>")
    Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS.Text = ListOfAssignments
    
    ' -------------------------
'End EditableGrid Student_SubjectStatus_Result Event BeforeShowRow. Action Custom Code

'DEL      ' -------------------------
'DEL      'WARNING_SENT_DATE
'DEL  	If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			Student_SubjectStatus_ResultLbl_Warning_Letter.visible=false
'DEL  			Student_SubjectStatus_ResultWarning_letter.visible=true
'DEL  	else
'DEL  		Student_SubjectStatus_ResultLbl_Warning_Letter.visible=true
'DEL  		Student_SubjectStatus_ResultWarning_letter.visible=false
'DEL  	end if
'DEL      ' -------------------------


'EditableGrid Student_SubjectStatus_Result BeforeShowRow event tail @13-477CF3C9
        End If
'End EditableGrid Student_SubjectStatus_Result BeforeShowRow event tail

'EditableGrid Student_SubjectStatus_Result ItemDataBound event tail @13-E31F8E2A
    End Sub
'End EditableGrid Student_SubjectStatus_Result ItemDataBound event tail

'EditableGrid Student_SubjectStatus_Result GetRedirectUrl method @13-91E4EF91
    Protected Function GetStudent_SubjectStatus_ResultRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetStudent_SubjectStatus_ResultRedirectUrl(ByVal redirectString As String) As String
        Return GetStudent_SubjectStatus_ResultRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid Student_SubjectStatus_Result GetRedirectUrl method

'EditableGrid Student_SubjectStatus_Result ShowErrors method @13-789C0650
    Protected Function Student_SubjectStatus_ResultShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), Student_SubjectStatus_ResultItem).IsUpdated Then col(CType(items(i), Student_SubjectStatus_ResultItem).RowId).Visible = False
            If (CType(items(i), Student_SubjectStatus_ResultItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), Student_SubjectStatus_ResultItem).errors.Count - 1
                Select CType(items(i), Student_SubjectStatus_ResultItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), Student_SubjectStatus_ResultItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), Student_SubjectStatus_ResultItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), Student_SubjectStatus_ResultItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid Student_SubjectStatus_Result ShowErrors method

'EditableGrid Student_SubjectStatus_Result ItemCommand event @13-7E7045DB
    Protected Sub Student_SubjectStatus_ResultItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = Student_SubjectStatus_ResultRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid Student_SubjectStatus_Result ItemCommand event

'Button Button_Submit OnClick. @36-BFAA91AC
        If Ctype(e.CommandSource,Control).ID = "Student_SubjectStatus_ResultButton_Submit" Then
            RedirectUrl  = GetStudent_SubjectStatus_ResultRedirectUrl("Student_SubjectStatus_Maintain.aspx", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @36-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @38-B93B7244
        If Ctype(e.CommandSource,Control).ID = "Student_SubjectStatus_ResultCancel" Then
            RedirectUrl  = GetStudent_SubjectStatus_ResultRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @38-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form Student_SubjectStatus_Result ItemCommand event tail @13-64FCF39D
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("Student_SubjectStatus_ResultSortDir"), SortDirections) = SortDirections._Asc And ViewState("Student_SubjectStatus_ResultSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("Student_SubjectStatus_ResultSortDir") = SortDirections._Desc
                Else
                    ViewState("Student_SubjectStatus_ResultSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("Student_SubjectStatus_ResultSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As Student_SubjectStatus_ResultDataProvider.SortFields = 0
            ViewState("Student_SubjectStatus_ResultSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("Student_SubjectStatus_ResultPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("Student_SubjectStatus_ResultPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("Student_SubjectStatus_ResultPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Student_SubjectStatus_ResultPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            Student_SubjectStatus_ResultIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = Student_SubjectStatus_ResultRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("Student_SubjectStatus_ResultFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("Student_SubjectStatus_ResultRowState"), Hashtable)
            Student_SubjectStatus_ResultParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim Student_SubjectStatus_ResultSS_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultSS_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultSS_STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultSS_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim Student_SubjectStatus_ResultSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultDEFAULTING_STATUS_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_ID"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim Student_SubjectStatus_Resultlbl_StudentName As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_Resultlbl_StudentName"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultLbl_Warning_Letter As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultLbl_Warning_Letter"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultLbl_Warning_Sent_Date As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultLbl_Warning_Sent_Date"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultWARNING_LETTER_Id As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultWARNING_LETTER_Id"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim Student_SubjectStatus_ResultWARNING_SENT_DATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultWARNING_SENT_DATE"),System.Web.UI.WebControls.TextBox)
                    Dim Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultDatePicker_WARNING_SENT_DATE"),System.Web.UI.WebControls.PlaceHolder)
                    Dim Student_SubjectStatus_Resultlbl_StudentEmail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("Student_SubjectStatus_Resultlbl_StudentEmail"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim Student_SubjectStatus_Resultlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_Resultlabel_ALERTS"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultlblDefaultingStatusDate As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultlblDefaultingStatusDate"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultHidden_DefaultingStatus As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultHidden_DefaultingStatus"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS"),System.Web.UI.WebControls.Literal)
                    Dim Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As Student_SubjectStatus_ResultItem = New Student_SubjectStatus_ResultItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.SS_SUBJECT_ID.Value = ViewState(Student_SubjectStatus_ResultSS_SUBJECT_ID.UniqueID)
                    item.SS_STUDENT_ID.Value = ViewState(Student_SubjectStatus_ResultSS_STUDENT_ID.UniqueID)
                    item.SUBJ_ENROL_STATUS.Value = ViewState(Student_SubjectStatus_ResultSUBJ_ENROL_STATUS.UniqueID)
                    item.NUM_OF_ASSIGNMENTS.Value = ViewState(Student_SubjectStatus_ResultNUM_OF_ASSIGNMENTS.UniqueID)
                    item.lbl_StudentName.Value = ViewState(Student_SubjectStatus_Resultlbl_StudentName.UniqueID)
                    item.Lbl_Warning_Letter.Value = ViewState(Student_SubjectStatus_ResultLbl_Warning_Letter.UniqueID)
                    item.Lbl_Warning_Sent_Date.Value = ViewState(Student_SubjectStatus_ResultLbl_Warning_Sent_Date.UniqueID)
                    item.lbl_StudentEmail.Value = ViewState(Student_SubjectStatus_Resultlbl_StudentEmail.UniqueID)
                    item.label_ALERTS.Value = ViewState(Student_SubjectStatus_Resultlabel_ALERTS.UniqueID)
                    item.lblDefaultingStatusDate.Value = ViewState(Student_SubjectStatus_ResultlblDefaultingStatusDate.UniqueID)
                    item.LIST_OF_ASSIGNMENTS.Value = ViewState(Student_SubjectStatus_ResultLIST_OF_ASSIGNMENTS.UniqueID)
                    item.DEFAULTING_STATUS_ID.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.UniqueID))
                    item.DEFAULTING_STATUS_ID.SetValue(Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.Value)
                    item.DEFAULTING_STATUS_IDItems.CopyFrom(Student_SubjectStatus_ResultDEFAULTING_STATUS_ID.Items)
                    item.WARNING_LETTER_Id.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_ResultWARNING_LETTER_Id.UniqueID))
                    item.WARNING_LETTER_Id.SetValue(Student_SubjectStatus_ResultWARNING_LETTER_Id.Value)
                    item.WARNING_LETTER_IdItems.CopyFrom(Student_SubjectStatus_ResultWARNING_LETTER_Id.Items)
                    Try
                    item.WARNING_SENT_DATE.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_ResultWARNING_SENT_DATE.UniqueID))
                    If ControlCustomValues("Student_SubjectStatus_ResultWARNING_SENT_DATE") Is Nothing Then
                        item.WARNING_SENT_DATE.SetValue(Student_SubjectStatus_ResultWARNING_SENT_DATE.Text)
                    Else
                        item.WARNING_SENT_DATE.SetValue(ControlCustomValues("Student_SubjectStatus_ResultWARNING_SENT_DATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("WARNING_SENT_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"WARNING_SENT_DATE","dd/mm/yy"))
                    End Try
                    item.Hidden_DefaultingStatus.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_ResultHidden_DefaultingStatus.UniqueID))
                    item.Hidden_DefaultingStatus.SetValue(Student_SubjectStatus_ResultHidden_DefaultingStatus.Value)
                    Try
                    item.DEFAULTING_STATUS_DATE.IsEmpty = IsNothing(Request.Form(Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE.UniqueID))
                    item.DEFAULTING_STATUS_DATE.SetValue(Student_SubjectStatus_ResultDEFAULTING_STATUS_DATE.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("DEFAULTING_STATUS_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Send Warning Letter Date","dd/mm/yy"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(Student_SubjectStatus_ResultData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form Student_SubjectStatus_Result ItemCommand event tail

'EditableGrid Student_SubjectStatus_Result Update @13-AB0AAF8F
            If BindAllowed Then
                Try
                    Student_SubjectStatus_ResultParameters()
                    Student_SubjectStatus_ResultData.Update(items, Student_SubjectStatus_ResultOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(Student_SubjectStatus_ResultRepeater.Controls(0).FindControl("Student_SubjectStatus_ResultError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
                Finally
'End EditableGrid Student_SubjectStatus_Result Update

'EditableGrid Student_SubjectStatus_Result Event AfterSubmit. Action Custom Code @74-73254650
    ' -------------------------
    ' ERA: 30-July-2010|EA| set flag for successful update as user feedback
				If IsNothing(Request.QueryString("flagdone")) Or Request.QueryString("flagdone") = "" Then  
    				Dim params As New LinkParameterCollection()
    				params.Add("flagdone","1")
    				Response.Redirect(Request.Url.AbsolutePath + params.ToString("GET","flagdone"))
  				End If
    ' -------------------------
'End EditableGrid Student_SubjectStatus_Result Event AfterSubmit. Action Custom Code

'EditableGrid Student_SubjectStatus_Result After Update @13-DEC90BF9
                End Try
                If Student_SubjectStatus_ResultShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                Student_SubjectStatus_ResultShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                Student_SubjectStatus_ResultBind()
            End If
        End Sub
'End EditableGrid Student_SubjectStatus_Result After Update

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-EE2C6E51
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_SubjectStatus_MaintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Student_SubjectStatus_searchData = New Student_SubjectStatus_searchDataProvider()
        Student_SubjectStatus_searchOperations = New FormSupportedOperations(False, True, True, True, True)
        Student_SubjectStatus_ResultData = New Student_SubjectStatus_ResultDataProvider()
        Student_SubjectStatus_ResultOperations = New FormSupportedOperations(False, True, False, True, False)
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

