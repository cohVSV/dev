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

Namespace DECV_PROD2007.Student_ClassList_Extender 'Namespace @1-8F3521FF

'Forms Definition @1-26B27D0F
Public Class [Student_ClassList_ExtenderPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-42D11DCF
    Protected CLASS_LIST_PanelData As CLASS_LIST_PanelDataProvider
    Protected CLASS_LIST_PanelErrors As NameValueCollection = New NameValueCollection()
    Protected CLASS_LIST_PanelOperations As FormSupportedOperations
    Protected CLASS_LIST_PanelIsSubmitted As Boolean = False
    Protected EditGrid_ExtendStudentsData As EditGrid_ExtendStudentsDataProvider
    Protected EditGrid_ExtendStudentsCurrentRowNumber As Integer
    Protected EditGrid_ExtendStudentsIsSubmitted As Boolean = False
    Protected EditGrid_ExtendStudentsErrors As New NameValueCollection()
    Protected EditGrid_ExtendStudentsOperations As FormSupportedOperations
    Protected EditGrid_ExtendStudentsDataItem As EditGrid_ExtendStudentsItem
    Protected Student_ClassList_ExtenderContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-4476E3D3
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            CLASS_LIST_PanelShow()
            EditGrid_ExtendStudentsBind()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form CLASS_LIST_Panel Parameters @4-DB1C0136

    Protected Sub CLASS_LIST_PanelParameters()
        Dim item As new CLASS_LIST_PanelItem
        Try
            CLASS_LIST_PanelData.Expr263 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)
        Catch e As Exception
            CLASS_LIST_PanelErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form CLASS_LIST_Panel Parameters

'Record Form CLASS_LIST_Panel Show method @4-BCAE2FE3
    Protected Sub CLASS_LIST_PanelShow()
        If CLASS_LIST_PanelOperations.None Then
            CLASS_LIST_PanelHolder.Visible = False
            Return
        End If
        Dim item As CLASS_LIST_PanelItem = CLASS_LIST_PanelItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not CLASS_LIST_PanelOperations.AllowRead
        item.ClearParametersHref = "Student_ClassList_Extender.aspx"
        CLASS_LIST_PanelErrors.Add(item.errors)
        If CLASS_LIST_PanelErrors.Count > 0 Then
            CLASS_LIST_PanelShowErrors()
            Return
        End If
'End Record Form CLASS_LIST_Panel Show method

'Record Form CLASS_LIST_Panel BeforeShow tail @4-4DA37A9E
        CLASS_LIST_PanelParameters()
        CLASS_LIST_PanelData.FillItem(item, IsInsertMode)
        CLASS_LIST_PanelHolder.DataBind()
        CLASS_LIST_PanelList_Subject_id.Items.Add(new ListItem("Select Subject",""))
        CLASS_LIST_PanelList_Subject_id.Items(0).Selected = True
        item.List_Subject_idItems.SetSelection(item.List_Subject_id.GetFormattedValue())
        If Not item.List_Subject_idItems.GetSelectedItem() Is Nothing Then
            CLASS_LIST_PanelList_Subject_id.SelectedIndex = -1
        End If
        item.List_Subject_idItems.CopyTo(CLASS_LIST_PanelList_Subject_id.Items)
        CLASS_LIST_PanelClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        CLASS_LIST_PanelClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("None","List_Subject_id", ViewState)
'End Record Form CLASS_LIST_Panel BeforeShow tail

'DEL      ' -------------------------
'DEL  	' change layout slightly if Elevated user.
'DEL  	'2-Feb-2011|EA| look for 'showall' flag, and then test for elevated
'DEL  	CLASS_LIST_PanelLabel_Elevated.visible = false
'DEL  	CLASS_LIST_PanelButton_DoSearch_AllStudents.visible = false
'DEL  
'DEL  	If ((DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"}))) Then
'DEL  			' show 'Show All Students' button
'DEL  			CLASS_LIST_PanelButton_DoSearch_AllStudents.visible = true
'DEL  	end if
'DEL  
'DEL  	If ((showallflag="1") and (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"}))) Then
'DEL  			' show 'Show All Students' button
'DEL  			CLASS_LIST_PanelLabel_Elevated.visible = true
'DEL  	end if
'DEL      ' -------------------------



'Record Form CLASS_LIST_Panel Show method tail @4-EC53BD92
        If CLASS_LIST_PanelErrors.Count > 0 Then
            CLASS_LIST_PanelShowErrors()
        End If
    End Sub
'End Record Form CLASS_LIST_Panel Show method tail

'Record Form CLASS_LIST_Panel LoadItemFromRequest method @4-36670C52

    Protected Sub CLASS_LIST_PanelLoadItemFromRequest(item As CLASS_LIST_PanelItem, ByVal EnableValidation As Boolean)
        item.List_Subject_id.IsEmpty = IsNothing(Request.Form(CLASS_LIST_PanelList_Subject_id.UniqueID))
        item.List_Subject_id.SetValue(CLASS_LIST_PanelList_Subject_id.Value)
        item.List_Subject_idItems.CopyFrom(CLASS_LIST_PanelList_Subject_id.Items)
        If EnableValidation Then
            item.Validate(CLASS_LIST_PanelData)
        End If
        CLASS_LIST_PanelErrors.Add(item.errors)
    End Sub
'End Record Form CLASS_LIST_Panel LoadItemFromRequest method

'Record Form CLASS_LIST_Panel GetRedirectUrl method @4-EE4A5111

    Protected Function GetCLASS_LIST_PanelRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_ClassList_Extender.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form CLASS_LIST_Panel GetRedirectUrl method

'Record Form CLASS_LIST_Panel ShowErrors method @4-036D5B27

    Protected Sub CLASS_LIST_PanelShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To CLASS_LIST_PanelErrors.Count - 1
        Select Case CLASS_LIST_PanelErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & CLASS_LIST_PanelErrors(i)
        End Select
        Next i
        CLASS_LIST_PanelError.Visible = True
        CLASS_LIST_PanelErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form CLASS_LIST_Panel ShowErrors method

'Record Form CLASS_LIST_Panel Insert Operation @4-8E83205F

    Protected Sub CLASS_LIST_Panel_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        CLASS_LIST_PanelIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CLASS_LIST_Panel Insert Operation

'Record Form CLASS_LIST_Panel BeforeInsert tail @4-E4F9C3D8
    CLASS_LIST_PanelParameters()
    CLASS_LIST_PanelLoadItemFromRequest(item, EnableValidation)
'End Record Form CLASS_LIST_Panel BeforeInsert tail

'Record Form CLASS_LIST_Panel AfterInsert tail  @4-8635C7B3
        ErrorFlag=(CLASS_LIST_PanelErrors.Count > 0)
        If ErrorFlag Then
            CLASS_LIST_PanelShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CLASS_LIST_Panel AfterInsert tail 

'Record Form CLASS_LIST_Panel Update Operation @4-1C131010

    Protected Sub CLASS_LIST_Panel_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        CLASS_LIST_PanelIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form CLASS_LIST_Panel Update Operation

'Record Form CLASS_LIST_Panel Before Update tail @4-E4F9C3D8
        CLASS_LIST_PanelParameters()
        CLASS_LIST_PanelLoadItemFromRequest(item, EnableValidation)
'End Record Form CLASS_LIST_Panel Before Update tail

'Record Form CLASS_LIST_Panel Update Operation tail @4-8635C7B3
        ErrorFlag=(CLASS_LIST_PanelErrors.Count > 0)
        If ErrorFlag Then
            CLASS_LIST_PanelShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form CLASS_LIST_Panel Update Operation tail

'Record Form CLASS_LIST_Panel Delete Operation @4-82A82CCB
    Protected Sub CLASS_LIST_Panel_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        CLASS_LIST_PanelIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form CLASS_LIST_Panel Delete Operation

'Record Form BeforeDelete tail @4-E4F9C3D8
        CLASS_LIST_PanelParameters()
        CLASS_LIST_PanelLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-BCAEF929
        If ErrorFlag Then
            CLASS_LIST_PanelShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form CLASS_LIST_Panel Cancel Operation @4-51D58891

    Protected Sub CLASS_LIST_Panel_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        CLASS_LIST_PanelIsSubmitted = True
        Dim RedirectUrl As String = ""
        CLASS_LIST_PanelLoadItemFromRequest(item, True)
'End Record Form CLASS_LIST_Panel Cancel Operation

'Record Form CLASS_LIST_Panel Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form CLASS_LIST_Panel Cancel Operation tail

'Record Form CLASS_LIST_Panel Search Operation @4-E505298B
    Protected Sub CLASS_LIST_Panel_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        CLASS_LIST_PanelIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As CLASS_LIST_PanelItem = New CLASS_LIST_PanelItem()
        CLASS_LIST_PanelLoadItemFromRequest(item, EnableValidation)
'End Record Form CLASS_LIST_Panel Search Operation

'Button Button_DoSearch OnClick. @80-F77D788E
        If CType(sender,Control).ID = "CLASS_LIST_PanelButton_DoSearch" Then
            RedirectUrl = GetCLASS_LIST_PanelRedirectUrl("", "showall;List_Subject_id")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @80-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'DEL      	' -------------------------
'DEL   		If IsNothing(Request.QueryString("showall")) Then  
'DEL  			RedirectUrl = RedirectUrl + "&showall=1"
'DEL    		End If
'DEL      ' -------------------------

'Record Form CLASS_LIST_Panel Search Operation tail @4-456E630C
        ErrorFlag = CLASS_LIST_PanelErrors.Count > 0
        If ErrorFlag Then
            CLASS_LIST_PanelShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In CLASS_LIST_PanelList_Subject_id.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "List_Subject_id=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form CLASS_LIST_Panel Search Operation tail

'DEL      ' -------------------------
'DEL      
'DEL  If IsNothing(Request.QueryString("Semester_Checked")) Or Request.QueryString("Semester_Checked") = "" Then  
'DEL  
'DEL      Dim params As New LinkParameterCollection()
'DEL      params.Add("Semester_Checked",Semester_Enrolment_SearchSemester_Checked.Value)
'DEL      params.Add("Subj_Enrol_Status_Checked",Semester_Enrolment_SearchSubj_Enrol_Status_Checked.Value)
'DEL      if (Semester_Enrolment_SearchSemester_1.checked)
'DEL  				params.Add("Semester_1","No")
'DEL      end if
'DEL  	if (Semester_Enrolment_SearchSemester_2.checked)
'DEL  				params.Add("Semester_2","No")
'DEL  				end if
'DEL  	if (Semester_Enrolment_SearchSubject_Status_C.checked)
'DEL  				params.Add("Subject_Status_C","No")
'DEL  				end if
'DEL  	if (Semester_Enrolment_SearchSubject_Status_D.checked)
'DEL  				params.Add("Subject_Status_D","No")
'DEL  				end if
'DEL  	if (Semester_Enrolment_SearchSubject_Status_E.checked)
'DEL  				params.Add("Subject_Status_E","No")
'DEL  				end if
'DEL  	if (Semester_Enrolment_SearchSubject_Status_F.checked)
'DEL  				params.Add("Subject_Status_F","No")
'DEL  				end if
'DEL   	if (Semester_Enrolment_SearchSubject_Status_F.checked)
'DEL  				params.Add("Subject_Status_W","No")
'DEL  				end if
'DEL      Response.Redirect(Request.Url.AbsolutePath + params.ToString("GET","Semester_Checked"))
'DEL                  End If
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: 8-Dec-2010 : string the name, subject and some other bits together, TAB delimited for copy to clipboard (then paste to Excel)
'DEL  		Students_GridHidden_clipboardtext.Value = DataItem.STUDENT_ID.GetFormattedValue() + ControlChars.Tab + trim(DataItem.FIRST_NAME.GetFormattedValue()) + " " + trim(DataItem.SURNAME.GetFormattedValue()) + ControlChars.Tab + DataItem.SUBJECT_ABBREV.GetFormattedValue()
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	Students_Gridlabel_ALERTS.Visible = false
'DEL  	Students_Gridlabel_ALERTS.Text = "<font color='red'><b>Alert!</b></font>"
'DEL  
'DEL      if (intAlerts > 0) then
'DEL  		Students_Gridlabel_ALERTS.Visible = true
'DEL  	end if
'DEL      ' -------------------------

'EditableGrid EditGrid_ExtendStudents Bind @210-40DD08E8
    Protected Sub EditGrid_ExtendStudentsBind()
        If EditGrid_ExtendStudentsOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"EditGrid_ExtendStudents",GetType(EditGrid_ExtendStudentsDataProvider.SortFields), 120, 120)
        End If
'End EditableGrid EditGrid_ExtendStudents Bind

'EditableGrid Form EditGrid_ExtendStudents BeforeShow tail @210-12DB966B
        EditGrid_ExtendStudentsParameters()
        EditGrid_ExtendStudentsData.SortField = CType(ViewState("EditGrid_ExtendStudentsSortField"), EditGrid_ExtendStudentsDataProvider.SortFields)
        EditGrid_ExtendStudentsData.SortDir = CType(ViewState("EditGrid_ExtendStudentsSortDir"), SortDirections)
        EditGrid_ExtendStudentsData.PageNumber = CType(ViewState("EditGrid_ExtendStudentsPageNumber"), Integer)
        EditGrid_ExtendStudentsData.RecordsPerPage = CType(ViewState("EditGrid_ExtendStudentsPageSize"), Integer)
        EditGrid_ExtendStudentsRepeater.DataSource = EditGrid_ExtendStudentsData.GetResultSet(PagesCount, EditGrid_ExtendStudentsOperations)
        ViewState("EditGrid_ExtendStudentsPagesCount") = PagesCount
        ViewState("EditGrid_ExtendStudentsFormState") = New Hashtable()
        ViewState("EditGrid_ExtendStudentsRowState") = New Hashtable()
        EditGrid_ExtendStudentsRepeater.DataBind()
        Dim item As EditGrid_ExtendStudentsItem = EditGrid_ExtendStudentsDataItem
        If IsNothing(item) Then item = New EditGrid_ExtendStudentsItem()
        FooterIndex = EditGrid_ExtendStudentsRepeater.Controls.Count - 1
        Dim Script As Literal = CType(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("FormScript"), Literal)
        Dim Elements As Literal = CType(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("ElementsID"), Literal)
        Elements.Text += "var EditGrid_ExtendStudentsStaticElementsID;" + vbCrLf
        Dim StaticElementsID As String = "EditGrid_ExtendStudentsStaticElementsID = new Array ("
        Elements.Text += "var EditGrid_ExtendStudentsButton_SubmitID=0;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + EditGrid_ExtendStudentsRepeater.Controls(FooterIndex).FindControl("EditGrid_ExtendStudentsButton_Submit").ClientID + """),"
        Elements.Text += "var EditGrid_ExtendStudentslblHintExtendID=1;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentslblHintExtend").ClientID + """),"
        Elements.Text += "var EditGrid_ExtendStudentslblHintPendingID=2;" + vbCrLf
        StaticElementsID += "document.getElementById(""" + EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentslblHintPending").ClientID + """)"
        Script.Text += StaticElementsID + ");"+ vbCrLf
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEMESTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_SEMESTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAdSorter As DECV_PROD2007.Controls.Sorter = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("Sorter_LAdSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim EditGrid_ExtendStudentsButton_Submit As System.Web.UI.WebControls.Button = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(FooterIndex).FindControl("EditGrid_ExtendStudentsButton_Submit"),System.Web.UI.WebControls.Button)
        Dim EditGrid_ExtendStudentslblHintExtend As System.Web.UI.WebControls.Literal = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentslblHintExtend"),System.Web.UI.WebControls.Literal)
        Dim EditGrid_ExtendStudentslblHintPending As System.Web.UI.WebControls.Literal = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentslblHintPending"),System.Web.UI.WebControls.Literal)


        EditGrid_ExtendStudentslblHintExtend.Text = item.lblHintExtend.GetFormattedValue()
        EditGrid_ExtendStudentslblHintPending.Text = item.lblHintPending.GetFormattedValue()
        EditGrid_ExtendStudentsButton_Submit.Visible = EditGrid_ExtendStudentsOperations.Editable
        If Not CType(EditGrid_ExtendStudentsRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            EditGrid_ExtendStudentsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If EditGrid_ExtendStudentsErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentsError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In EditGrid_ExtendStudentsErrors
                ErrorLabel.Text += EditGrid_ExtendStudentsErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form EditGrid_ExtendStudents BeforeShow tail

'EditableGrid EditGrid_ExtendStudents Event BeforeShow. Action Hide-Show Component @257-5902195C
        Dim UrlList_Subject_id_257_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("List_Subject_id"))
        Dim ExprParam2_257_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlList_Subject_id_257_1, ExprParam2_257_2) Then
            EditGrid_ExtendStudentsRepeater.Visible = False
        End If
'End EditableGrid EditGrid_ExtendStudents Event BeforeShow. Action Hide-Show Component

'EditableGrid EditGrid_ExtendStudents Event BeforeShow. Action Custom Code @261-73254650
    ' -------------------------
    '17-May-2018|EA| show some hints for Extending subject and Pending (sem 2)
    ' can use the above URL parameter
    EditGrid_ExtendStudentslblHintExtend.Text = "No Extending subject found."
    EditGrid_ExtendStudentslblHintPending.Text = "No Linked subject found."

    if (EditGrid_ExtendStudentsRepeater.Visible = True) Then
    	if not isnothing(UrlList_Subject_id_257_1) then
			Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject   	
			EditGrid_ExtendStudentslblHintExtend.Text = ""
	        EditGrid_ExtendStudentslblHintPending.Text = ""
	    	
	    	Dim tmpSQL As String = "select s1.subject_id, s1.linked_subject_id, s1.extendable_FLAG " & _
	    		" , rtrim(s1.subject_title) + ' (' + s1.subject_abbrev + ') will be Extended ' as displaytext_sub1 " & _
				" , isnull(rtrim(s2.subject_title) + ' (' + s2.subject_abbrev + ') will be Pending', 'No linked subject.') as displaytext_sub2 " & _
				" from subject s1 left outer join subject s2 on s1.linked_subject_id = s2.subject_id " & _
				" where s1.status = 1 and s1.extendABLE_FLAG = 1 and s1.default_semester ='1' " & _
				"  and s1.subject_id = " & NewDao.ToSql(System.Web.HttpContext.Current.Request.QueryString("List_Subject_id"),FieldType._Integer) & ""
				
			Dim [Select] As New SqlCommand(tmpSQL, NewDao)
	   		Dim newDr As DataRowCollection = [Select].Execute().Tables(0).Rows
	   		if newDr.Count > 0 then
	   			' returned a value, only pull first one
				EditGrid_ExtendStudentslblHintExtend.Text = newDr(0)("displaytext_sub1").ToString()
				EditGrid_ExtendStudentslblHintPending.Text = newDr(0)("displaytext_sub2").ToString()
	   		end if  

		
    	end if
    end if
    ' -------------------------
'End EditableGrid EditGrid_ExtendStudents Event BeforeShow. Action Custom Code

'EditableGrid EditGrid_ExtendStudents Bind tail @210-CC4A2AE9
        EditGrid_ExtendStudentsShowErrors(New ArrayList(CType(EditGrid_ExtendStudentsRepeater.DataSource, ICollection)), EditGrid_ExtendStudentsRepeater.Items)
    End Sub
'End EditableGrid EditGrid_ExtendStudents Bind tail

'EditableGrid EditGrid_ExtendStudents Table Parameters @210-B67148F4
    Protected Sub EditGrid_ExtendStudentsParameters()
        Try
        Dim item As new EditGrid_ExtendStudentsItem
            EditGrid_ExtendStudentsData.UrlList_Subject_id = IntegerParameter.GetParam("List_Subject_id", ParameterSourceType.URL, "", 0, false)
            EditGrid_ExtendStudentsData.Expr281 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "ZZZ", false)
            EditGrid_ExtendStudentsData.ExprKey4 = TextParameter.GetParam(DBUtility.UserId.ToString(), ParameterSourceType.Expression, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = EditGrid_ExtendStudentsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(EditGrid_ExtendStudentsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid EditGrid_ExtendStudents: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid EditGrid_ExtendStudents Table Parameters

'EditableGrid EditGrid_ExtendStudents ItemDataBound event @210-45BC2AD0
    Protected Sub EditGrid_ExtendStudentsItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As EditGrid_ExtendStudentsItem = DirectCast(e.Item.DataItem, EditGrid_ExtendStudentsItem)
        Dim Item as EditGrid_ExtendStudentsItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            EditGrid_ExtendStudentsCurrentRowNumber = EditGrid_ExtendStudentsCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("EditGrid_ExtendStudentsFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditGrid_ExtendStudentsRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("SEMESTERField:" & e.Item.ItemIndex, DataItem.SEMESTERField.Value)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsSTUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsSURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsFIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsSUBJ_ENROL_STATUS").UniqueID) = DataItem.SUBJ_ENROL_STATUS.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsSEMESTER").UniqueID) = DataItem.SEMESTER.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentsLAd").UniqueID) = DataItem.LAd.Value
            ViewState(e.Item.FindControl("EditGrid_ExtendStudentslblCnt").UniqueID) = DataItem.lblCnt.Value
            Dim EditGrid_ExtendStudentsSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsSTUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsSURNAME"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsLAd As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsLAd"),System.Web.UI.WebControls.Literal)
            Dim EditGrid_ExtendStudentsCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentsCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
            Dim EditGrid_ExtendStudentslblCnt As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentslblCnt"),System.Web.UI.WebControls.Literal)
            CType(Page,CCPage).ControlAttributes.Add(EditGrid_ExtendStudentsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, EditGrid_ExtendStudentsCurrentRowNumber), AttributeOption.Multiple)
            If DataItem.CheckBox_DeleteCheckedValue.Value.Equals(DataItem.CheckBox_Delete.Value) Then
                EditGrid_ExtendStudentsCheckBox_Delete.Checked = True
            End If
        End If
'End EditableGrid EditGrid_ExtendStudents ItemDataBound event

'EditGrid_ExtendStudents control Before Show @210-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditGrid_ExtendStudents control Before Show

'Get Control @243-AC2C6D95
            Dim EditGrid_ExtendStudentslblCnt As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("EditGrid_ExtendStudentslblCnt"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label lblCnt Event BeforeShow. Action Retrieve Value for Control @244-987BA5CD
            EditGrid_ExtendStudentslblCnt.Text = (New IntegerField("", EditGrid_ExtendStudentsCurrentRowNumber)).GetFormattedValue()
'End Label lblCnt Event BeforeShow. Action Retrieve Value for Control

'EditGrid_ExtendStudents control Before Show tail @210-477CF3C9
        End If
'End EditGrid_ExtendStudents control Before Show tail

'EditableGrid EditGrid_ExtendStudents BeforeShowRow event @210-46ACAF46
        If Not IsNothing(Item) Then EditGrid_ExtendStudentsDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid EditGrid_ExtendStudents BeforeShowRow event

'EditableGrid EditGrid_ExtendStudents BeforeShowRow event tail @210-477CF3C9
        End If
'End EditableGrid EditGrid_ExtendStudents BeforeShowRow event tail

'EditableGrid EditGrid_ExtendStudents ItemDataBound event tail @210-E31F8E2A
    End Sub
'End EditableGrid EditGrid_ExtendStudents ItemDataBound event tail

'EditableGrid EditGrid_ExtendStudents GetRedirectUrl method @210-90663D5B
    Protected Function GetEditGrid_ExtendStudentsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetEditGrid_ExtendStudentsRedirectUrl(ByVal redirectString As String) As String
        Return GetEditGrid_ExtendStudentsRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid EditGrid_ExtendStudents GetRedirectUrl method

'EditableGrid EditGrid_ExtendStudents ShowErrors method @210-632845D1
    Protected Function EditGrid_ExtendStudentsShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), EditGrid_ExtendStudentsItem).IsUpdated Then col(CType(items(i), EditGrid_ExtendStudentsItem).RowId).Visible = False
            If (CType(items(i), EditGrid_ExtendStudentsItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), EditGrid_ExtendStudentsItem).errors.Count - 1
                Select CType(items(i), EditGrid_ExtendStudentsItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), EditGrid_ExtendStudentsItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), EditGrid_ExtendStudentsItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), EditGrid_ExtendStudentsItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid EditGrid_ExtendStudents ShowErrors method

'EditableGrid EditGrid_ExtendStudents ItemCommand event @210-A2C27C1E
    Protected Sub EditGrid_ExtendStudentsItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = EditGrid_ExtendStudentsRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid EditGrid_ExtendStudents ItemCommand event

'Button Button_Submit OnClick. @241-B87A54B2
        If Ctype(e.CommandSource,Control).ID = "EditGrid_ExtendStudentsButton_Submit" Then
            RedirectUrl  = GetEditGrid_ExtendStudentsRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @241-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'EditableGrid Form EditGrid_ExtendStudents ItemCommand event tail @210-C8EE6998
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("EditGrid_ExtendStudentsSortDir"), SortDirections) = SortDirections._Asc And ViewState("EditGrid_ExtendStudentsSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("EditGrid_ExtendStudentsSortDir") = SortDirections._Desc
                Else
                    ViewState("EditGrid_ExtendStudentsSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("EditGrid_ExtendStudentsSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As EditGrid_ExtendStudentsDataProvider.SortFields = 0
            ViewState("EditGrid_ExtendStudentsSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("EditGrid_ExtendStudentsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("EditGrid_ExtendStudentsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("EditGrid_ExtendStudentsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("EditGrid_ExtendStudentsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            EditGrid_ExtendStudentsIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = EditGrid_ExtendStudentsRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("EditGrid_ExtendStudentsFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("EditGrid_ExtendStudentsRowState"), Hashtable)
            EditGrid_ExtendStudentsParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim EditGrid_ExtendStudentsSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsSTUDENT_ID"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsSURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsSURNAME"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsFIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsSEMESTER"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsLAd As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsLAd"),System.Web.UI.WebControls.Literal)
                    Dim EditGrid_ExtendStudentsCheckBox_Delete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("EditGrid_ExtendStudentsCheckBox_Delete"),System.Web.UI.WebControls.CheckBox)
                    Dim EditGrid_ExtendStudentslblCnt As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("EditGrid_ExtendStudentslblCnt"),System.Web.UI.WebControls.Literal)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As EditGrid_ExtendStudentsItem = New EditGrid_ExtendStudentsItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.SEMESTERField.Value = formState("SEMESTERField:" & col(i).ItemIndex)
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("EditGrid_ExtendStudentsCheckBox_Delete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.STUDENT_ID.Value = ViewState(EditGrid_ExtendStudentsSTUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(EditGrid_ExtendStudentsSURNAME.UniqueID)
                    item.FIRST_NAME.Value = ViewState(EditGrid_ExtendStudentsFIRST_NAME.UniqueID)
                    item.SUBJ_ENROL_STATUS.Value = ViewState(EditGrid_ExtendStudentsSUBJ_ENROL_STATUS.UniqueID)
                    item.SEMESTER.Value = ViewState(EditGrid_ExtendStudentsSEMESTER.UniqueID)
                    item.LAd.Value = ViewState(EditGrid_ExtendStudentsLAd.UniqueID)
                    item.lblCnt.Value = ViewState(EditGrid_ExtendStudentslblCnt.UniqueID)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(EditGrid_ExtendStudentsData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form EditGrid_ExtendStudents ItemCommand event tail

'EditableGrid EditGrid_ExtendStudents Update @210-1026CD78
            If BindAllowed Then
                Try
                    EditGrid_ExtendStudentsParameters()
                    EditGrid_ExtendStudentsData.Update(items, EditGrid_ExtendStudentsOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(EditGrid_ExtendStudentsRepeater.Controls(0).FindControl("EditGrid_ExtendStudentsError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid EditGrid_ExtendStudents Update

'EditableGrid EditGrid_ExtendStudents After Update @210-9AB3E8BD
                End Try
                If EditGrid_ExtendStudentsShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                EditGrid_ExtendStudentsShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                EditGrid_ExtendStudentsBind()
            End If
        End Sub
'End EditableGrid EditGrid_ExtendStudents After Update

'DEL      ' -------------------------
'DEL      ' 2-3-2011|EA| change to horizontal layout
'DEL  	STUDENT_COMMENTlbSpecialCommentType1.RepeatDirection = RepeatDirection.Horizontal
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	' ERA: check for lbSpecialCommentType - if '0' then no change to hidden_COMMENT_TYPE, else then use lbSpecialCommentType
'DEL  	' 	and set ALERT_TYPE to '1'
'DEL  	' Also will need to change the Edit own comment page to allow reset/change of comment type from Alert etc to Regular
'DEL  
'DEL  	' ERA: 28-Jan-2011|EA| added selection of new drop-down for regular teachers etc, to allow adding of Contact Types.
'DEL  	'	(unfuddle #356)
'DEL  	If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  		' update the form objects so they will be loaded in the STUDENT_COMMENTLoadItemFromRequest below.
'DEL  		if (not String.Equals(STUDENT_COMMENTlbSpecialCommentType.Value,"0")) then
'DEL  			STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType.Value	
'DEL  		end if
'DEL  	else
'DEL  		'regular teachers
'DEL  		if (not String.Equals(STUDENT_COMMENTlbSpecialCommentType1.Value,"0")) then
'DEL  			STUDENT_COMMENTHidden_CommentType.Value = STUDENT_COMMENTlbSpecialCommentType1.Value	
'DEL  		end if
'DEL  	end if	'end 28-Jan
'DEL  
'DEL      ' -------------------------
'DEL

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4EE6C1DE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_ClassList_ExtenderContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        CLASS_LIST_PanelData = New CLASS_LIST_PanelDataProvider()
        CLASS_LIST_PanelOperations = New FormSupportedOperations(False, True, True, True, True)
        EditGrid_ExtendStudentsData = New EditGrid_ExtendStudentsDataProvider()
        EditGrid_ExtendStudentsOperations = New FormSupportedOperations(False, True, False, False, True)
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

