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

Namespace DECV_PROD2007.StudentSubject_TeachersNotYetAllocated 'Namespace @1-F0CA9757

'Forms Definition @1-A864A745
Public Class [StudentSubject_TeachersNotYetAllocatedPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1036FA32
    Protected view_Class_ListData As view_Class_ListDataProvider
    Protected view_Class_ListCurrentRowNumber As Integer
    Protected view_Class_ListIsSubmitted As Boolean = False
    Protected view_Class_ListErrors As New NameValueCollection()
    Protected view_Class_ListOperations As FormSupportedOperations
    Protected view_Class_ListDataItem As view_Class_ListItem
    Protected view_Class_ListSearchData As view_Class_ListSearchDataProvider
    Protected view_Class_ListSearchErrors As NameValueCollection = New NameValueCollection()
    Protected view_Class_ListSearchOperations As FormSupportedOperations
    Protected view_Class_ListSearchIsSubmitted As Boolean = False
    Protected ForceRunData As ForceRunDataProvider
    Protected ForceRunErrors As NameValueCollection = New NameValueCollection()
    Protected ForceRunOperations As FormSupportedOperations
    Protected ForceRunIsSubmitted As Boolean = False
    Protected StudentSubject_TeachersNotYetAllocatedContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B251D8F4
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            view_Class_ListBind()
            view_Class_ListSearchShow()
            ForceRunShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid view_Class_List Bind @3-A05A5BE9
    Protected Sub view_Class_ListBind()
        If view_Class_ListOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"view_Class_List",GetType(view_Class_ListDataProvider.SortFields), 40, 200)
        End If
'End EditableGrid view_Class_List Bind

'EditableGrid Form view_Class_List BeforeShow tail @3-180560D4
        view_Class_ListParameters()
        view_Class_ListData.SortField = CType(ViewState("view_Class_ListSortField"), view_Class_ListDataProvider.SortFields)
        view_Class_ListData.SortDir = CType(ViewState("view_Class_ListSortDir"), SortDirections)
        view_Class_ListData.PageNumber = CType(ViewState("view_Class_ListPageNumber"), Integer)
        view_Class_ListData.RecordsPerPage = CType(ViewState("view_Class_ListPageSize"), Integer)
        view_Class_ListRepeater.DataSource = view_Class_ListData.GetResultSet(PagesCount, view_Class_ListOperations)
        ViewState("view_Class_ListPagesCount") = PagesCount
        ViewState("view_Class_ListFormState") = New Hashtable()
        ViewState("view_Class_ListRowState") = New Hashtable()
        view_Class_ListRepeater.DataBind()
        Dim item As view_Class_ListItem = view_Class_ListDataItem
        If IsNothing(item) Then item = New view_Class_ListItem()
        FooterIndex = view_Class_ListRepeater.Controls.Count - 1
        Dim view_Class_Listview_Class_List_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("view_Class_Listview_Class_List_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCHOOL_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_SCHOOL_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEMESTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_SEMESTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(view_Class_ListRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {40,200,500}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim view_Class_ListButton_Submit As System.Web.UI.WebControls.Button = DirectCast(view_Class_ListRepeater.Controls(FooterIndex).FindControl("view_Class_ListButton_Submit"),System.Web.UI.WebControls.Button)
        Dim view_Class_ListCancel As System.Web.UI.WebControls.Button = DirectCast(view_Class_ListRepeater.Controls(FooterIndex).FindControl("view_Class_ListCancel"),System.Web.UI.WebControls.Button)
        Dim SorterYEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("SorterYEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim view_Class_ListlblStudentSubjectTeacherListHeading As System.Web.UI.WebControls.Literal = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("view_Class_ListlblStudentSubjectTeacherListHeading"),System.Web.UI.WebControls.Literal)

        item.lblStudentSubjectTeacherListHeading.SetValue(If(Request.QueryString?("rbSearchType")?.Equals("C"), "Student Subject Teacher Allocations", "Students with Unallocated Subject Teachers"))

        view_Class_Listview_Class_List_TotalRecords.Text = Server.HtmlEncode(item.view_Class_List_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        view_Class_ListlblStudentSubjectTeacherListHeading.Text = Server.HtmlEncode(item.lblStudentSubjectTeacherListHeading.GetFormattedValue()).Replace(vbCrLf,"<br>")
        view_Class_ListButton_Submit.Visible = view_Class_ListOperations.Editable
        If Not CType(view_Class_ListRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            view_Class_ListRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If view_Class_ListErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(view_Class_ListRepeater.Controls(0).FindControl("view_Class_ListError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In view_Class_ListErrors
                ErrorLabel.Text += view_Class_ListErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form view_Class_List BeforeShow tail

'Label view_Class_List_TotalRecords Event BeforeShow. Action Retrieve number of records @35-9EA5E738
            view_Class_Listview_Class_List_TotalRecords.Text = view_Class_ListData.RecordCount.ToString()
'End Label view_Class_List_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid view_Class_List Bind tail @3-C545B916
        view_Class_ListShowErrors(New ArrayList(CType(view_Class_ListRepeater.DataSource, ICollection)), view_Class_ListRepeater.Items)
    End Sub
'End EditableGrid view_Class_List Bind tail

'EditableGrid view_Class_List Table Parameters @3-F3D8B274
    Protected Sub view_Class_ListParameters()
        Try
        Dim item As new view_Class_ListItem
            view_Class_ListData.Urls_SEMESTER = TextParameter.GetParam("s_SEMESTER", ParameterSourceType.URL, "", "", false)
            view_Class_ListData.UrlradioYearLevel = IntegerParameter.GetParam("radioYearLevel", ParameterSourceType.URL, "", 0, false)
            view_Class_ListData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", "", false)
            view_Class_ListData.UrlrbSearchType = TextParameter.GetParam("rbSearchType", ParameterSourceType.URL, "", "", false)
            view_Class_ListData.UrlddlSubject = IntegerParameter.GetParam("ddlSubject", ParameterSourceType.URL, "", 0, false)
            view_Class_ListData.CtrlSTAFF_ID = TextParameter.GetParam(item.STAFF_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            view_Class_ListData.Expr78 = TextParameter.GetParam(Session("UserID").Tostring(), ParameterSourceType.Expression, "", Nothing, false)
            view_Class_ListData.Expr79 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = view_Class_ListRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(view_Class_ListRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid view_Class_List: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid view_Class_List Table Parameters

'EditableGrid view_Class_List ItemDataBound event @3-8B96F3A7
    Protected Sub view_Class_ListItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As view_Class_ListItem = DirectCast(e.Item.DataItem, view_Class_ListItem)
        Dim Item as view_Class_ListItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            view_Class_ListCurrentRowNumber = view_Class_ListCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("view_Class_ListFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("view_Class_ListRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STUDENT_IDField:" & e.Item.ItemIndex, DataItem.STUDENT_IDField.Value)
            formState.Add("ENROLMENT_YEARField:" & e.Item.ItemIndex, DataItem.ENROLMENT_YEARField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            formState.Add("SEMESTERField:" & e.Item.ItemIndex, DataItem.SEMESTERField.Value)
            ViewState(e.Item.FindControl("view_Class_ListSTUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("view_Class_ListSURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("view_Class_ListSCHOOL_NAME").UniqueID) = DataItem.SCHOOL_NAME.Value
            ViewState(e.Item.FindControl("view_Class_ListSEMESTER").UniqueID) = DataItem.SEMESTER.Value
            ViewState(e.Item.FindControl("view_Class_ListSUBJECT_TITLE").UniqueID) = DataItem.SUBJECT_TITLE.Value
            ViewState(e.Item.FindControl("view_Class_ListSUBJ_ENROL_STATUS").UniqueID) = DataItem.SUBJ_ENROL_STATUS.Value
            ViewState(e.Item.FindControl("view_Class_ListENROLMENT_DATE").UniqueID) = DataItem.ENROLMENT_DATE.Value
            ViewState(e.Item.FindControl("view_Class_ListFIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("view_Class_ListSUBJECT_ABBREV").UniqueID) = DataItem.SUBJECT_ABBREV.Value
            ViewState(e.Item.FindControl("view_Class_Listlink_ShowCurrentEnrolment").UniqueID) = DataItem.link_ShowCurrentEnrolment.Value
            ViewState(e.Item.FindControl("view_Class_ListlblWarnFull").UniqueID) = DataItem.lblWarnFull.Value
            ViewState(e.Item.FindControl("view_Class_ListYEAR_LEVEL").UniqueID) = DataItem.YEAR_LEVEL.Value
            Dim view_Class_ListSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("view_Class_ListSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim view_Class_ListSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListSURNAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListSCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListSCHOOL_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("view_Class_ListSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim view_Class_ListSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListSUBJECT_ABBREV As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("view_Class_ListSUBJECT_ABBREV"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim view_Class_Listlink_ShowCurrentEnrolment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("view_Class_Listlink_ShowCurrentEnrolment"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim view_Class_ListlblWarnFull As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListlblWarnFull"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim view_Class_ListhidPreviousStaffID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("view_Class_ListhidPreviousStaffID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            CType(Page,CCPage).ControlAttributes.Add(view_Class_ListRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, view_Class_ListCurrentRowNumber), AttributeOption.Multiple)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            view_Class_ListSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","", ViewState)
            view_Class_ListSTAFF_ID.Items.Add(new ListItem("Select Value",""))
            view_Class_ListSTAFF_ID.Items(0).Selected = True
            DataItem.STAFF_IDItems.SetSelection(DataItem.STAFF_ID.GetFormattedValue())
            If Not DataItem.STAFF_IDItems.GetSelectedItem() Is Nothing Then
                view_Class_ListSTAFF_ID.SelectedIndex = -1
            End If
            DataItem.STAFF_IDItems.CopyTo(view_Class_ListSTAFF_ID.Items)
            DataItem.SUBJECT_ABBREVHref = "SUBJECT_maint.aspx"
            view_Class_ListSUBJECT_ABBREV.HRef = DataItem.SUBJECT_ABBREVHref & DataItem.SUBJECT_ABBREVHrefParameters.ToString("GET","", ViewState)
            DataItem.link_ShowCurrentEnrolmentHref = "StudentSubject_TeacherStats.aspx"
            view_Class_Listlink_ShowCurrentEnrolment.HRef = DataItem.link_ShowCurrentEnrolmentHref & DataItem.link_ShowCurrentEnrolmentHrefParameters.ToString("GET","", ViewState)
        End If
'End EditableGrid view_Class_List ItemDataBound event

'EditableGrid view_Class_List BeforeShowRow event @3-582E5773
        If Not IsNothing(Item) Then view_Class_ListDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid view_Class_List BeforeShowRow event

'EditableGrid view_Class_List Event BeforeShowRow. Action Custom Code @77-73254650
    ' -------------------------
    ' 'ERA: Jan-2012|EA| for each row, need to select the relevant list of Teachers for this subject.
			' cannot use the method from Codecharge forums as it uses ASP/PHP and relies on seperate methods to 
			'	prepare and collect the ListItems, while .NET does the collection at the same time at the Results Set.
			' So! get the code from the DataProvider that populates the listbox, and repurpose it here.
			' -------------------------
			' get the STAFF_ID ListBox for filling and clear it out
			Dim view_Class_ListSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("view_Class_ListSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
			view_Class_ListSTAFF_ID.Items.Clear
			view_Class_ListSTAFF_ID.Items.Add(new ListItem("Select Value",""))

		    ' set the parameter Expr68 as the Subject ID for the Row so the drop-down shows the list of available teachers
			'Expr68 = IntegerParameter.GetParam(501, ParameterSourceType.Expression, "", 1, false)
			'ACTUALLY - CAN USE THE BUILT IN METHODS - JUST *TYPE* the CONTROL/FIELD NAME IN.
			Dim STAFF_IDDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
			Dim STAFF_IDSqlCommand As New SQLCommand("select SUBJECT_TEACHER.STAFF_ID as [STAFF_ID]" & vbCrLf & _
		          "	, SUBJECT_TEACHER.STAFF_ID + '  ('+convert(varchar(5),convert(numeric(4,1),SUBJECT_TEACHER.SUBJECT_TIMEFRACTION))+')' as [displayvalue]" & vbCrLf & _
		          "from subject inner join SUBJECT_TEACHER on subject.SUBJECT_ID = SUBJECT_TEACHER.SUBJECT_ID" & vbCrLf & _
		          "where subject.status = 1" & vbCrLf & _
		          "	and SUBJECT_TEACHER.ALLOCATABLE_FLAG = 1 and SUBJECT.DEFAULT_TEACHER_ID in ('N-A','NA')" & vbCrLf & _
		          "	and SUBJECT.SUBJECT_ID=" & STAFF_IDDao.tosql(item.SUBJECT_IDField.Value, FieldType._Integer) & "", STAFF_IDDao)

		    Dim ListBoxSource as DataRowCollection = STAFF_IDSqlCommand.Execute().Tables(0).Rows

			' loop through results and put into Listbox Items
            Dim j as Integer
            Dim selectedIndex = 0
            Dim currentStaffID = Item.STAFF_ID.Value.ToString().Trim().ToUpper()
            Dim excludedStaff As HashSet(Of String) = New HashSet(Of String) From {"N-A", "NO_SST"}
            Dim staffAdded As New HashSet(Of String)()

		    For j=0 To ListBoxSource.Count-1 
		        Dim Key As String = ListBoxSource(j)("STAFF_ID").ToString()
		        Dim DisplayVal As Object = ListBoxSource(j)("displayvalue").ToString()
				  view_Class_ListSTAFF_ID.Items.Add(New ListItem(DisplayVal, Key))

              ' 26 Nov 2021|RW| Now that allocated student subjects are being retrieved as well, select the staff member if they're currently allocated.
              If (Key.Trim().Equals(currentStaffID, StringComparison.CurrentCultureIgnoreCase)) Then
                  selectedIndex = view_Class_ListSTAFF_ID.Items.Count - 1
              End If

              staffAdded.Add(Key.Trim().ToUpper())
		    Next j
          
          ' Is the currently allocated staff member missing from the list of designated teachers for the subject? If so, add them to the dropdown and select them.
          If ((currentStaffID.Length > 0) AndAlso (Not excludedStaff.Contains(currentStaffID)) AndAlso (Not staffAdded.Contains(currentStaffID))) Then
              view_Class_ListSTAFF_ID.Items.Add(New ListItem(currentStaffID & " (---)", currentStaffID))
              selectedIndex = view_Class_ListSTAFF_ID.Items.Count - 1
          End If

          view_Class_ListSTAFF_ID.SelectedIndex = selectedIndex
    ' -------------------------
'End EditableGrid view_Class_List Event BeforeShowRow. Action Custom Code

'EditableGrid view_Class_List Event BeforeShowRow. Action Custom Code @142-73254650
    ' -------------------------
'ERA: 10-Feb-2012|EA| do a lookup for display of asterisk if over 90% full for subject
		' note that the Sum for Current count is +1 to stop DIV/0 errors
		'ERA: 25-Jun-2012|EA| add 'P'ending to lookup, to count allocations prior to Sem 2 rollover
		' 11-June-2015|EA| and ignore any NON-SUBMIT students
		'10Dec-2015|EA| adjust students per maximum per John V. where it fits with subject id: P-2:30; 3-4:28;5-6:24 (use 28 fo roverall);7-10:96;11:84;12:68; where possible (unfuddle #735)
		'	 and change enrolment year to '(case when month(getdate()) = 12 then YEAR(getdate())+1 else YEAR(getdate()) end )' to auto select next year in December
		'27-March-2018|EA| adjust calculation to use the subject.allocation_max_students field for all subjects instead of hard coded
		Dim view_Class_ListlblWarnFull As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("view_Class_ListlblWarnFull"),System.Web.UI.WebControls.Literal)
		Dim WARNING_SqlCommand As String = "select isnull(convert(numeric(6,4),((sum(T1.[Current Student Count])+1)/(sum(T1.[FTE_StudentMax])+1))),0.00) " & vbCrLf & _
						" from (select  (subject.allocate_students_max*SUBJECT_TEACHER.SUBJECT_TIMEFRACTION)  as [FTE_StudentMax] " & vbCrLf & _
						" , COUNT(student_id) as [Current Student Count] " & vbCrLf & _
						"	from STUDENT_SUBJECT inner join SUBJECT_TEACHER  " & vbCrLf & _
						"		on STUDENT_SUBJECT.SUBJECT_ID = SUBJECT_TEACHER.SUBJECT_ID " & vbCrLf & _
						"			and STUDENT_SUBJECT.STAFF_ID=SUBJECT_TEACHER.STAFF_ID " & vbCrLf & _
						"			and SUBJECT_TEACHER.ALLOCATABLE_FLAG=1 " & vbCrLf & _
						"		join subject on student_subject.subject_id = subject.subject_id " & vbCrLf & _
						"	where ENROLMENT_YEAR=(case when month(getdate()) = 12 then YEAR(getdate())+1 else YEAR(getdate()) end ) AND subj_enrol_status in ('C','D','E','P') " & vbCrLf & _
						"       and (STUDENT_SUBJECT.NON_SUBMITTING_FLAG is null or STUDENT_SUBJECT.NON_SUBMITTING_FLAG =0) " & vbCrLf & _
						"		and STUDENT_SUBJECT.SEMESTER = " & STAFF_IDDao.tosql(item.SEMESTERField.Value, FieldType._Text) & "" & vbCrLf & _
						"		and STUDENT_SUBJECT.SUBJECT_ID = " & STAFF_IDDao.tosql(item.SUBJECT_IDField.Value, FieldType._Integer) & "" & vbCrLf & _
						"	group by STUDENT_SUBJECT.SUBJECT_ID, STUDENT_SUBJECT.STAFF_ID, SUBJECT_TEACHER.SUBJECT_TIMEFRACTION, subject.allocate_students_max " & vbCrLf & _
						"	) as T1 "

		dim tmpPercFull as single = (New FloatField("",STAFF_IDDao.ExecuteScalar(WARNING_SqlCommand))).GetFormattedValue("")

		view_Class_ListlblWarnFull.Text=""

		if (tmpPercFull >= 1.1) then
			' more than 10% over and make it more obvious with an !
			view_Class_ListlblWarnFull.Text="<font color='RED'>FULL!</font>"
		else if (tmpPercFull >= 1.0) then
			' over 100% then is FULL
			view_Class_ListlblWarnFull.Text="<font color='RED'>FULL</font>"
		else if (tmpPercFull >= 0.9) then
			' over 90% then getting close
			view_Class_ListlblWarnFull.Text="<font color='RED'>" & tmpPercFull.ToString("##.0%") & "</font>"
		else if (tmpPercFull >= 0.8) then
			' start to show warning if over 80%
			view_Class_ListlblWarnFull.Text="<font color='#cc99cc'>" & tmpPercFull.ToString("##.0%") & "</font>"
		end if
    ' -------------------------
'End EditableGrid view_Class_List Event BeforeShowRow. Action Custom Code

'EditableGrid view_Class_List BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid view_Class_List BeforeShowRow event tail

'EditableGrid view_Class_List ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid view_Class_List ItemDataBound event tail

'EditableGrid view_Class_List GetRedirectUrl method @3-59E8B920
    Protected Function Getview_Class_ListRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function Getview_Class_ListRedirectUrl(ByVal redirectString As String) As String
        Return Getview_Class_ListRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid view_Class_List GetRedirectUrl method

'EditableGrid view_Class_List ShowErrors method @3-4E514608
    Protected Function view_Class_ListShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), view_Class_ListItem).IsUpdated Then col(CType(items(i), view_Class_ListItem).RowId).Visible = False
            If (CType(items(i), view_Class_ListItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), view_Class_ListItem).errors.Count - 1
                Select CType(items(i), view_Class_ListItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), view_Class_ListItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), view_Class_ListItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), view_Class_ListItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid view_Class_List ShowErrors method

'EditableGrid view_Class_List ItemCommand event @3-103EB08C
    Protected Sub view_Class_ListItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = view_Class_ListRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid view_Class_List ItemCommand event

'Button Button_Submit OnClick. @65-F7D46DB8
        If Ctype(e.CommandSource,Control).ID = "view_Class_ListButton_Submit" Then
            RedirectUrl  = Getview_Class_ListRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @65-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @138-A3C32221
        If Ctype(e.CommandSource,Control).ID = "view_Class_ListCancel" Then
            RedirectUrl  = Getview_Class_ListRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @138-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form view_Class_List ItemCommand event tail @3-FC666E31
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("view_Class_ListSortDir"), SortDirections) = SortDirections._Asc And ViewState("view_Class_ListSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("view_Class_ListSortDir") = SortDirections._Desc
                Else
                    ViewState("view_Class_ListSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("view_Class_ListSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As view_Class_ListDataProvider.SortFields = 0
            ViewState("view_Class_ListSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("view_Class_ListPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("view_Class_ListPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("view_Class_ListPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("view_Class_ListPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            view_Class_ListIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = view_Class_ListRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("view_Class_ListFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("view_Class_ListRowState"), Hashtable)
            view_Class_ListParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim view_Class_ListSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("view_Class_ListSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim view_Class_ListSURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListSURNAME"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListSCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListSCHOOL_NAME"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListSEMESTER"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListSTAFF_ID As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(col(i).FindControl("view_Class_ListSTAFF_ID"),System.Web.UI.HtmlControls.HtmlSelect)
                    Dim view_Class_ListSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListFIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListSUBJECT_ABBREV As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("view_Class_ListSUBJECT_ABBREV"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim view_Class_Listlink_ShowCurrentEnrolment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(col(i).FindControl("view_Class_Listlink_ShowCurrentEnrolment"),System.Web.UI.HtmlControls.HtmlAnchor)
                    Dim view_Class_ListlblWarnFull As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListlblWarnFull"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("view_Class_ListYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
                    Dim view_Class_ListhidPreviousStaffID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("view_Class_ListhidPreviousStaffID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As view_Class_ListItem = New view_Class_ListItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STUDENT_IDField.Value = formState("STUDENT_IDField:" & col(i).ItemIndex)
                    item.ENROLMENT_YEARField.Value = formState("ENROLMENT_YEARField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.SEMESTERField.Value = formState("SEMESTERField:" & col(i).ItemIndex)
                    item.STUDENT_ID.Value = ViewState(view_Class_ListSTUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(view_Class_ListSURNAME.UniqueID)
                    item.SCHOOL_NAME.Value = ViewState(view_Class_ListSCHOOL_NAME.UniqueID)
                    item.SEMESTER.Value = ViewState(view_Class_ListSEMESTER.UniqueID)
                    item.SUBJECT_TITLE.Value = ViewState(view_Class_ListSUBJECT_TITLE.UniqueID)
                    item.SUBJ_ENROL_STATUS.Value = ViewState(view_Class_ListSUBJ_ENROL_STATUS.UniqueID)
                    item.ENROLMENT_DATE.Value = ViewState(view_Class_ListENROLMENT_DATE.UniqueID)
                    item.FIRST_NAME.Value = ViewState(view_Class_ListFIRST_NAME.UniqueID)
                    item.SUBJECT_ABBREV.Value = ViewState(view_Class_ListSUBJECT_ABBREV.UniqueID)
                    item.link_ShowCurrentEnrolment.Value = ViewState(view_Class_Listlink_ShowCurrentEnrolment.UniqueID)
                    item.lblWarnFull.Value = ViewState(view_Class_ListlblWarnFull.UniqueID)
                    item.YEAR_LEVEL.Value = ViewState(view_Class_ListYEAR_LEVEL.UniqueID)
                    item.STAFF_ID.IsEmpty = IsNothing(Request.Form(view_Class_ListSTAFF_ID.UniqueID))
                    item.STAFF_ID.SetValue(view_Class_ListSTAFF_ID.Value)
                    item.STAFF_IDItems.CopyFrom(view_Class_ListSTAFF_ID.Items)
                    item.hidPreviousStaffID.IsEmpty = IsNothing(Request.Form(view_Class_ListhidPreviousStaffID.UniqueID))
                    item.hidPreviousStaffID.SetValue(view_Class_ListhidPreviousStaffID.Value)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(view_Class_ListData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form view_Class_List ItemCommand event tail

'EditableGrid view_Class_List Update @3-464C29C0
            If BindAllowed Then
                Try
                    view_Class_ListParameters()
                    view_Class_ListData.Update(items, view_Class_ListOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(view_Class_ListRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(view_Class_ListRepeater.Controls(0).FindControl("view_Class_ListError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid view_Class_List Update

'EditableGrid view_Class_List After Update @3-392CD231
                End Try
                If view_Class_ListShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                view_Class_ListShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                view_Class_ListBind()
            End If
        End Sub
'End EditableGrid view_Class_List After Update

'Record Form view_Class_ListSearch Parameters @25-EF5F47DC

    Protected Sub view_Class_ListSearchParameters()
        Dim item As new view_Class_ListSearchItem
        Try
        Catch e As Exception
            view_Class_ListSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form view_Class_ListSearch Parameters

'Record Form view_Class_ListSearch Show method @25-8DFA7981
    Protected Sub view_Class_ListSearchShow()
        If view_Class_ListSearchOperations.None Then
            view_Class_ListSearchHolder.Visible = False
            Return
        End If
        Dim item As view_Class_ListSearchItem = view_Class_ListSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not view_Class_ListSearchOperations.AllowRead
        item.ClearParametersHref = "StudentSubject_TeachersNotYetAllocated.aspx"
        view_Class_ListSearchErrors.Add(item.errors)
        If view_Class_ListSearchErrors.Count > 0 Then
            view_Class_ListSearchShowErrors()
            Return
        End If
'End Record Form view_Class_ListSearch Show method

'Record Form view_Class_ListSearch BeforeShow tail @25-AF3F4307
        view_Class_ListSearchParameters()
        view_Class_ListSearchData.FillItem(item, IsInsertMode)
        view_Class_ListSearchHolder.DataBind()
        view_Class_ListSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        view_Class_ListSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_SEMESTER;radioYearLevel;rbSearchType;ddlSubject", ViewState)
        view_Class_ListSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        view_Class_ListSearchradioYearLevel.Items.Add(new ListItem("Select Value",""))
        view_Class_ListSearchradioYearLevel.Items(0).Selected = True
        item.radioYearLevelItems.SetSelection(item.radioYearLevel.GetFormattedValue())
        If Not item.radioYearLevelItems.GetSelectedItem() Is Nothing Then
            view_Class_ListSearchradioYearLevel.SelectedIndex = -1
        End If
        item.radioYearLevelItems.CopyTo(view_Class_ListSearchradioYearLevel.Items)
        item.rbSearchTypeItems.SetSelection(item.rbSearchType.GetFormattedValue())
        view_Class_ListSearchrbSearchType.SelectedIndex = -1
        item.rbSearchTypeItems.CopyTo(view_Class_ListSearchrbSearchType.Items)
        view_Class_ListSearchddlSubject.Items.Add(new ListItem("Select Value",""))
        view_Class_ListSearchddlSubject.Items(0).Selected = True
        item.ddlSubjectItems.SetSelection(item.ddlSubject.GetFormattedValue())
        If Not item.ddlSubjectItems.GetSelectedItem() Is Nothing Then
            view_Class_ListSearchddlSubject.SelectedIndex = -1
        End If
        item.ddlSubjectItems.CopyTo(view_Class_ListSearchddlSubject.Items)
        item.s_SEMESTERItems.SetSelection(item.s_SEMESTER.GetFormattedValue())
        view_Class_ListSearchs_SEMESTER.SelectedIndex = -1
        item.s_SEMESTERItems.CopyTo(view_Class_ListSearchs_SEMESTER.Items)
'End Record Form view_Class_ListSearch BeforeShow tail

'Record Form view_Class_ListSearch Show method tail @25-2C21E126
        If view_Class_ListSearchErrors.Count > 0 Then
            view_Class_ListSearchShowErrors()
        End If
    End Sub
'End Record Form view_Class_ListSearch Show method tail

'Record Form view_Class_ListSearch LoadItemFromRequest method @25-89DF9322

    Protected Sub view_Class_ListSearchLoadItemFromRequest(item As view_Class_ListSearchItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(view_Class_ListSearchs_SURNAME.UniqueID))
        If ControlCustomValues("view_Class_ListSearchs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(view_Class_ListSearchs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("view_Class_ListSearchs_SURNAME"))
        End If
        Try
        item.radioYearLevel.IsEmpty = IsNothing(Request.Form(view_Class_ListSearchradioYearLevel.UniqueID))
        item.radioYearLevel.SetValue(view_Class_ListSearchradioYearLevel.Value)
        item.radioYearLevelItems.CopyFrom(view_Class_ListSearchradioYearLevel.Items)
        Catch ae As ArgumentException
            view_Class_ListSearchErrors.Add("radioYearLevel",String.Format(Resources.strings.CCS_IncorrectValue,"radioYearLevel"))
        End Try
        item.rbSearchType.IsEmpty = IsNothing(Request.Form(view_Class_ListSearchrbSearchType.UniqueID))
        If Not IsNothing(view_Class_ListSearchrbSearchType.SelectedItem) Then
            item.rbSearchType.SetValue(view_Class_ListSearchrbSearchType.SelectedItem.Value)
        Else
            item.rbSearchType.Value = Nothing
        End If
        item.rbSearchTypeItems.CopyFrom(view_Class_ListSearchrbSearchType.Items)
        Try
        item.ddlSubject.IsEmpty = IsNothing(Request.Form(view_Class_ListSearchddlSubject.UniqueID))
        item.ddlSubject.SetValue(view_Class_ListSearchddlSubject.Value)
        item.ddlSubjectItems.CopyFrom(view_Class_ListSearchddlSubject.Items)
        Catch ae As ArgumentException
            view_Class_ListSearchErrors.Add("ddlSubject",String.Format(Resources.strings.CCS_IncorrectValue,"Subject"))
        End Try
        item.s_SEMESTER.IsEmpty = IsNothing(Request.Form(view_Class_ListSearchs_SEMESTER.UniqueID))
        If Not IsNothing(view_Class_ListSearchs_SEMESTER.SelectedItem) Then
            item.s_SEMESTER.SetValue(view_Class_ListSearchs_SEMESTER.SelectedItem.Value)
        Else
            item.s_SEMESTER.Value = Nothing
        End If
        item.s_SEMESTERItems.CopyFrom(view_Class_ListSearchs_SEMESTER.Items)
        If EnableValidation Then
            item.Validate(view_Class_ListSearchData)
        End If
        view_Class_ListSearchErrors.Add(item.errors)
    End Sub
'End Record Form view_Class_ListSearch LoadItemFromRequest method

'Record Form view_Class_ListSearch GetRedirectUrl method @25-677D8DEF

    Protected Function Getview_Class_ListSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentSubject_TeachersNotYetAllocated.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form view_Class_ListSearch GetRedirectUrl method

'Record Form view_Class_ListSearch ShowErrors method @25-38774C48

    Protected Sub view_Class_ListSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To view_Class_ListSearchErrors.Count - 1
        Select Case view_Class_ListSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & view_Class_ListSearchErrors(i)
        End Select
        Next i
        view_Class_ListSearchError.Visible = True
        view_Class_ListSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form view_Class_ListSearch ShowErrors method

'Record Form view_Class_ListSearch Insert Operation @25-E7E6ED47

    Protected Sub view_Class_ListSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        view_Class_ListSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form view_Class_ListSearch Insert Operation

'Record Form view_Class_ListSearch BeforeInsert tail @25-2C8CC4A3
    view_Class_ListSearchParameters()
    view_Class_ListSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form view_Class_ListSearch BeforeInsert tail

'Record Form view_Class_ListSearch AfterInsert tail  @25-F4B468AB
        ErrorFlag=(view_Class_ListSearchErrors.Count > 0)
        If ErrorFlag Then
            view_Class_ListSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form view_Class_ListSearch AfterInsert tail 

'Record Form view_Class_ListSearch Update Operation @25-01C226C8

    Protected Sub view_Class_ListSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        view_Class_ListSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form view_Class_ListSearch Update Operation

'Record Form view_Class_ListSearch Before Update tail @25-2C8CC4A3
        view_Class_ListSearchParameters()
        view_Class_ListSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form view_Class_ListSearch Before Update tail

'Record Form view_Class_ListSearch Update Operation tail @25-F4B468AB
        ErrorFlag=(view_Class_ListSearchErrors.Count > 0)
        If ErrorFlag Then
            view_Class_ListSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form view_Class_ListSearch Update Operation tail

'Record Form view_Class_ListSearch Delete Operation @25-4C6B099A
    Protected Sub view_Class_ListSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        view_Class_ListSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form view_Class_ListSearch Delete Operation

'Record Form BeforeDelete tail @25-2C8CC4A3
        view_Class_ListSearchParameters()
        view_Class_ListSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @25-97CE1402
        If ErrorFlag Then
            view_Class_ListSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form view_Class_ListSearch Cancel Operation @25-DD51BAB9

    Protected Sub view_Class_ListSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        view_Class_ListSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        view_Class_ListSearchLoadItemFromRequest(item, True)
'End Record Form view_Class_ListSearch Cancel Operation

'Record Form view_Class_ListSearch Cancel Operation tail @25-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form view_Class_ListSearch Cancel Operation tail

'Record Form view_Class_ListSearch Search Operation @25-E0B9DEF1
    Protected Sub view_Class_ListSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        view_Class_ListSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As view_Class_ListSearchItem = New view_Class_ListSearchItem()
        view_Class_ListSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form view_Class_ListSearch Search Operation

'Button Button_DoSearch OnClick. @27-8FB5A593
        If CType(sender,Control).ID = "view_Class_ListSearchButton_DoSearch" Then
            RedirectUrl = Getview_Class_ListSearchRedirectUrl("", "s_SURNAME;radioYearLevel;rbSearchType;ddlSubject;s_SEMESTER")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @27-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form view_Class_ListSearch Search Operation tail @25-B535F085
        ErrorFlag = view_Class_ListSearchErrors.Count > 0
        If ErrorFlag Then
            view_Class_ListSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(view_Class_ListSearchs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(view_Class_ListSearchs_SURNAME.Text) & "&"), "")
            For Each li In view_Class_ListSearchradioYearLevel.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "radioYearLevel=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In view_Class_ListSearchrbSearchType.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "rbSearchType=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In view_Class_ListSearchddlSubject.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "ddlSubject=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In view_Class_ListSearchs_SEMESTER.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SEMESTER=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form view_Class_ListSearch Search Operation tail

'Record Form ForceRun Parameters @163-3957E0E5

    Protected Sub ForceRunParameters()
        Dim item As new ForceRunItem
        Try
            ForceRunData.CtrllistBatchSize = IntegerParameter.GetParam(item.listBatchSize.Value, ParameterSourceType.Control, "", 200, false)
            ForceRunData.ExprKey80 = IntegerParameter.GetParam(1, ParameterSourceType.Expression, "", 1, false)
            ForceRunData.CtrlcheckVCEOnly = IntegerParameter.GetParam(item.checkVCEOnly.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            ForceRunErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ForceRun Parameters

'Record Form ForceRun Show method @163-D377BECC
    Protected Sub ForceRunShow()
        If ForceRunOperations.None Then
            ForceRunHolder.Visible = False
            Return
        End If
        Dim item As ForceRunItem = ForceRunItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ForceRunOperations.AllowRead
        ForceRunErrors.Add(item.errors)
        If ForceRunErrors.Count > 0 Then
            ForceRunShowErrors()
            Return
        End If
'End Record Form ForceRun Show method

'Record Form ForceRun BeforeShow tail @163-9E6D39E5
        ForceRunParameters()
        ForceRunData.FillItem(item, IsInsertMode)
        ForceRunHolder.DataBind()
        ForceRunButton_Update.Visible=Not (IsInsertMode) AndAlso ForceRunOperations.AllowUpdate
        item.listBatchSizeItems.SetSelection(item.listBatchSize.GetFormattedValue())
        If Not item.listBatchSizeItems.GetSelectedItem() Is Nothing Then
            ForceRunlistBatchSize.SelectedIndex = -1
        End If
        item.listBatchSizeItems.CopyTo(ForceRunlistBatchSize.Items)
        If item.checkVCEOnlyCheckedValue.Value.Equals(item.checkVCEOnly.Value) Then
            ForceRuncheckVCEOnly.Checked = True
        End If
'End Record Form ForceRun BeforeShow tail

'Record Form ForceRun Show method tail @163-FB21571B
        If ForceRunErrors.Count > 0 Then
            ForceRunShowErrors()
        End If
    End Sub
'End Record Form ForceRun Show method tail

'Record Form ForceRun LoadItemFromRequest method @163-33CB6B2A

    Protected Sub ForceRunLoadItemFromRequest(item As ForceRunItem, ByVal EnableValidation As Boolean)
        Try
        item.listBatchSize.IsEmpty = IsNothing(Request.Form(ForceRunlistBatchSize.UniqueID))
        item.listBatchSize.SetValue(ForceRunlistBatchSize.Value)
        item.listBatchSizeItems.CopyFrom(ForceRunlistBatchSize.Items)
        Catch ae As ArgumentException
            ForceRunErrors.Add("listBatchSize",String.Format(Resources.strings.CCS_IncorrectValue,"Batch Size"))
        End Try
        If ForceRuncheckVCEOnly.Checked Then
            item.checkVCEOnly.Value = (item.checkVCEOnlyCheckedValue.Value)
        Else
            item.checkVCEOnly.Value = (item.checkVCEOnlyUncheckedValue.Value)
        End If
        If EnableValidation Then
            item.Validate(ForceRunData)
        End If
        ForceRunErrors.Add(item.errors)
    End Sub
'End Record Form ForceRun LoadItemFromRequest method

'Record Form ForceRun GetRedirectUrl method @163-8BAA40F8

    Protected Function GetForceRunRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ForceRun GetRedirectUrl method

'Record Form ForceRun ShowErrors method @163-FE3A1AA4

    Protected Sub ForceRunShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ForceRunErrors.Count - 1
        Select Case ForceRunErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ForceRunErrors(i)
        End Select
        Next i
        ForceRunError.Visible = True
        ForceRunErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ForceRun ShowErrors method

'Record Form ForceRun Insert Operation @163-9674C1E3

    Protected Sub ForceRun_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ForceRunItem = New ForceRunItem()
        ForceRunIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ForceRun Insert Operation

'Record Form ForceRun BeforeInsert tail @163-83BE8AB8
    ForceRunParameters()
    ForceRunLoadItemFromRequest(item, EnableValidation)
'End Record Form ForceRun BeforeInsert tail

'Record Form ForceRun AfterInsert tail  @163-740C1A42
        ErrorFlag=(ForceRunErrors.Count > 0)
        If ErrorFlag Then
            ForceRunShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ForceRun AfterInsert tail 

'Record Form ForceRun Update Operation @163-CAFED4A6

    Protected Sub ForceRun_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ForceRunItem = New ForceRunItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        ForceRunIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ForceRun Update Operation

'Button Button_Update OnClick. @166-1E899055
        If CType(sender,Control).ID = "ForceRunButton_Update" Then
            RedirectUrl = GetForceRunRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @166-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form ForceRun Before Update tail @163-DD2BBCA5
        ForceRunParameters()
        ForceRunLoadItemFromRequest(item, EnableValidation)
        If ForceRunOperations.AllowUpdate Then
        ErrorFlag = (ForceRunErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ForceRunData.UpdateItem(item)
            Catch ex As Exception
                ForceRunErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ForceRun Before Update tail

'Record ForceRun Event AfterUpdate. Action Save Variable Value @167-60F89FD9
        HttpContext.Current.Session("notifymessage") = "Manual Allocation Run completed"
'End Record ForceRun Event AfterUpdate. Action Save Variable Value

'Record Form ForceRun Update Operation tail @163-3663D148
        End If
        ErrorFlag=(ForceRunErrors.Count > 0)
        If ErrorFlag Then
            ForceRunShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ForceRun Update Operation tail

'Record Form ForceRun Delete Operation @163-6526983B
    Protected Sub ForceRun_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ForceRunIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ForceRunItem = New ForceRunItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ForceRun Delete Operation

'Record Form BeforeDelete tail @163-83BE8AB8
        ForceRunParameters()
        ForceRunLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @163-14AF4F84
        If ErrorFlag Then
            ForceRunShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ForceRun Cancel Operation @163-CBC88590

    Protected Sub ForceRun_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ForceRunItem = New ForceRunItem()
        ForceRunIsSubmitted = True
        Dim RedirectUrl As String = ""
        ForceRunLoadItemFromRequest(item, True)
'End Record Form ForceRun Cancel Operation

'Record Form ForceRun Cancel Operation tail @163-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ForceRun Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-DC8B204A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentSubject_TeachersNotYetAllocatedContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        view_Class_ListData = New view_Class_ListDataProvider()
        view_Class_ListOperations = New FormSupportedOperations(False, True, False, True, False)
        view_Class_ListSearchData = New view_Class_ListSearchDataProvider()
        view_Class_ListSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        ForceRunData = New ForceRunDataProvider()
        ForceRunOperations = New FormSupportedOperations(False, True, False, True, False)
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

