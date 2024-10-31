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

Namespace DECV_PROD2007.Student_ClassList_Reports 'Namespace @1-73F3783D

'Forms Definition @1-B1F36978
Public Class [Student_ClassList_ReportsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-68482116
    Protected CLASS_LIST_PanelData As CLASS_LIST_PanelDataProvider
    Protected CLASS_LIST_PanelErrors As NameValueCollection = New NameValueCollection()
    Protected CLASS_LIST_PanelOperations As FormSupportedOperations
    Protected CLASS_LIST_PanelIsSubmitted As Boolean = False
    Protected Students_GridData As Students_GridDataProvider
    Protected Students_GridOperations As FormSupportedOperations
    Protected Students_GridCurrentRowNumber As Integer
    Protected STUDENT_COMMENTData As STUDENT_COMMENTDataProvider
    Protected STUDENT_COMMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_COMMENTOperations As FormSupportedOperations
    Protected STUDENT_COMMENTIsSubmitted As Boolean = False
    Protected Student_ClassList_ReportsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-622D0460
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.LinkExportToExcelHref = "Student_ClassList_Reports_Export.aspx"
            item.Link_ShowBulkCommentHref = ""
            PageData.FillItem(item)
            LinkExportToExcel.InnerText += item.LinkExportToExcel.GetFormattedValue().Replace(vbCrLf,"")
            LinkExportToExcel.HRef = item.LinkExportToExcelHref+item.LinkExportToExcelHrefParameters.ToString("GET","", ViewState)
            LinkExportToExcel.DataBind()
            Link_ShowBulkComment.InnerText += item.Link_ShowBulkComment.GetFormattedValue().Replace(vbCrLf,"")
            Link_ShowBulkComment.HRef = item.Link_ShowBulkCommentHref+item.Link_ShowBulkCommentHrefParameters.ToString("None","", ViewState)
            Link_ShowBulkComment.DataBind()
            CLASS_LIST_PanelShow()
            Students_GridBind
            STUDENT_COMMENTShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_ClassList_Reports Event BeforeShow. Action Hide-Show Component @69-E859F5DF
        Dim UrlList_Subject_id_69_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("List_Subject_id"))
        Dim ExprParam2_69_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlList_Subject_id_69_1, ExprParam2_69_2) Then
            Students_GridRepeater.Visible = False
        End If
'End Page Student_ClassList_Reports Event BeforeShow. Action Hide-Show Component

'Page Student_ClassList_Reports Event BeforeShow. Action Custom Code @123-73254650
    ' -------------------------
	' ERA: show Excel Link if records, and Comment link
	LinkExportToExcel.Visible = (Students_GridRepeater.Visible)  and (ViewState("Students_GridPagesCount") > 0)
	Link_ShowBulkComment.Visible = (Students_GridRepeater.Visible) and (ViewState("Students_GridPagesCount") > 0)
	STUDENT_COMMENTHolder.Visible =  Students_GridRepeater.Visible

    ' -------------------------
'End Page Student_ClassList_Reports Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL  	' ERA: set the Staff ID depending on security level
'DEL  	' 7-Feb-2011|EA| fix to change STAFF_ID to all, if right level, AND to include in SQL so conflict between WHERE and ORDER BY works
'DEL  	dim thisstaffid as string = ""
'DEL  	If (showallflag="1") Then
'DEL  
'DEL  		' check for elevated
'DEL  		If (DBUtility.AuthorizeUser(New String(){"2","3","6","7","9"})) Then
'DEL  			' show all
'DEL  			thisstaffid = ""
'DEL  		else
'DEL  			thisstaffid = DBUtility.UserLogin.ToUpper
'DEL  		end if
'DEL  	else
'DEL  		thisstaffid = DBUtility.UserLogin.ToUpper
'DEL  	end if
'DEL      ' -------------------------


    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form CLASS_LIST_Panel Parameters @4-1C2CD72C

    Protected Sub CLASS_LIST_PanelParameters()
        Dim item As new CLASS_LIST_PanelItem
        Try
            CLASS_LIST_PanelData.Expr143 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", "", false)
        Catch e As Exception
            CLASS_LIST_PanelErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form CLASS_LIST_Panel Parameters

'Record Form CLASS_LIST_Panel Show method @4-03629F14
    Protected Sub CLASS_LIST_PanelShow()
        If CLASS_LIST_PanelOperations.None Then
            CLASS_LIST_PanelHolder.Visible = False
            Return
        End If
        Dim item As CLASS_LIST_PanelItem = CLASS_LIST_PanelItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not CLASS_LIST_PanelOperations.AllowRead
        item.ClearParametersHref = "Student_ClassList_Reports.aspx"
        CLASS_LIST_PanelErrors.Add(item.errors)
        If CLASS_LIST_PanelErrors.Count > 0 Then
            CLASS_LIST_PanelShowErrors()
            Return
        End If
'End Record Form CLASS_LIST_Panel Show method

'Record Form CLASS_LIST_Panel BeforeShow tail @4-CC2237E9
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
        item.List_SEMESTERItems.SetSelection(item.List_SEMESTER.GetFormattedValue())
        If Not item.List_SEMESTERItems.GetSelectedItem() Is Nothing Then
            CLASS_LIST_PanelList_SEMESTER.SelectedIndex = -1
        End If
        item.List_SEMESTERItems.CopyTo(CLASS_LIST_PanelList_SEMESTER.Items)
        CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Items.Add(new ListItem("Select Subject Enrolment Status",""))
        CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Items(0).Selected = True
        item.List_SUBJECT_ENROL_STATUSItems.SetSelection(item.List_SUBJECT_ENROL_STATUS.GetFormattedValue())
        If Not item.List_SUBJECT_ENROL_STATUSItems.GetSelectedItem() Is Nothing Then
            CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.SelectedIndex = -1
        End If
        item.List_SUBJECT_ENROL_STATUSItems.CopyTo(CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Items)
        CLASS_LIST_PanelClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        CLASS_LIST_PanelClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("None","List_Subject_id,List_SUBJECT_ENROL_STATUS,List_SEMESTER", ViewState)
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

'Record Form CLASS_LIST_Panel LoadItemFromRequest method @4-DB99A404

    Protected Sub CLASS_LIST_PanelLoadItemFromRequest(item As CLASS_LIST_PanelItem, ByVal EnableValidation As Boolean)
        item.List_Subject_id.IsEmpty = IsNothing(Request.Form(CLASS_LIST_PanelList_Subject_id.UniqueID))
        item.List_Subject_id.SetValue(CLASS_LIST_PanelList_Subject_id.Value)
        item.List_Subject_idItems.CopyFrom(CLASS_LIST_PanelList_Subject_id.Items)
        item.List_SEMESTER.IsEmpty = IsNothing(Request.Form(CLASS_LIST_PanelList_SEMESTER.UniqueID))
        item.List_SEMESTER.SetValue(CLASS_LIST_PanelList_SEMESTER.Value)
        item.List_SEMESTERItems.CopyFrom(CLASS_LIST_PanelList_SEMESTER.Items)
        item.List_SUBJECT_ENROL_STATUS.IsEmpty = IsNothing(Request.Form(CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.UniqueID))
        item.List_SUBJECT_ENROL_STATUS.SetValue(CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Value)
        item.List_SUBJECT_ENROL_STATUSItems.CopyFrom(CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Items)
        If EnableValidation Then
            item.Validate(CLASS_LIST_PanelData)
        End If
        CLASS_LIST_PanelErrors.Add(item.errors)
    End Sub
'End Record Form CLASS_LIST_Panel LoadItemFromRequest method

'Record Form CLASS_LIST_Panel GetRedirectUrl method @4-8153349D

    Protected Function GetCLASS_LIST_PanelRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_ClassList_Reports.aspx"
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

'Button Button_DoSearch OnClick. @80-5A28F657
        If CType(sender,Control).ID = "CLASS_LIST_PanelButton_DoSearch" Then
            RedirectUrl = GetCLASS_LIST_PanelRedirectUrl("", "showall;List_Subject_id;List_SEMESTER;List_SUBJECT_ENROL_STATUS")
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

'Record Form CLASS_LIST_Panel Search Operation tail @4-7F33A861
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
            For Each li In CLASS_LIST_PanelList_SEMESTER.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "List_SEMESTER=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In CLASS_LIST_PanelList_SUBJECT_ENROL_STATUS.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "List_SUBJECT_ENROL_STATUS=" & Server.UrlEncode(li.Value) & "&"
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

'Grid Students_Grid Bind @25-D8CD1BCF

    Protected Sub Students_GridBind()
        If Not Students_GridOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Students_Grid",GetType(Students_GridDataProvider.SortFields), 100, 150)
        End If
'End Grid Students_Grid Bind

'Grid Form Students_Grid BeforeShow tail @25-8F3B835E
        Students_GridParameters()
        Students_GridData.SortField = CType(ViewState("Students_GridSortField"),Students_GridDataProvider.SortFields)
        Students_GridData.SortDir = CType(ViewState("Students_GridSortDir"),SortDirections)
        Students_GridData.PageNumber = CInt(ViewState("Students_GridPageNumber"))
        Students_GridData.RecordsPerPage = CInt(ViewState("Students_GridPageSize"))
        Students_GridRepeater.DataSource = Students_GridData.GetResultSet(PagesCount, Students_GridOperations)
        ViewState("Students_GridPagesCount") = PagesCount
        Dim item As Students_GridItem = New Students_GridItem()
        Students_GridRepeater.DataBind
        FooterIndex = Students_GridRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Students_GridRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCHOOL_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SCHOOL_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ATTENDING_SCHOOL_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_ATTENDING_SCHOOL_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_ABBREVSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SUBJECT_ABBREVSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEMESTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_SEMESTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(Students_GridRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Students_GridSTUDENT_ClassList_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(Students_GridRepeater.Controls(0).FindControl("Students_GridSTUDENT_ClassList_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_CLASS_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Students_GridRepeater.Controls(0).FindControl("Sorter_CLASS_CODESorter"),DECV_PROD2007.Controls.Sorter)

        Students_GridSTUDENT_ClassList_TotalRecords.Text = Server.HtmlEncode(item.STUDENT_ClassList_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form Students_Grid BeforeShow tail

'Label STUDENT_ClassList_TotalRecords Event BeforeShow. Action Retrieve number of records @190-30493AEE
            Students_GridSTUDENT_ClassList_TotalRecords.Text = Students_GridData.RecordCount.ToString()
'End Label STUDENT_ClassList_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid Students_Grid Bind tail @25-E31F8E2A
    End Sub
'End Grid Students_Grid Bind tail

'Grid Students_Grid Table Parameters @25-A5A1F9F2

    Protected Sub Students_GridParameters()
        Try
            Students_GridData.UrlList_Subject_id = IntegerParameter.GetParam("List_Subject_id", ParameterSourceType.URL, "", Nothing, false)
            Students_GridData.UrlList_SEMESTER = TextParameter.GetParam("List_SEMESTER", ParameterSourceType.URL, "", Nothing, false)
            Students_GridData.UrlList_SUBJECT_ENROL_STATUS = TextParameter.GetParam("List_SUBJECT_ENROL_STATUS", ParameterSourceType.URL, "", Nothing, false)
            Students_GridData.Expr203 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=Students_GridRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Students_GridRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Students_Grid: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Students_Grid Table Parameters

'Grid Students_Grid ItemDataBound event @25-6E7F6220

    Protected Sub Students_GridItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Students_GridItem = CType(e.Item.DataItem,Students_GridItem)
        Dim Item as Students_GridItem = DataItem
        Dim FormDataSource As Students_GridItem() = CType(Students_GridRepeater.DataSource, Students_GridItem())
        Dim Students_GridDataRows As Integer = FormDataSource.Length
        Dim Students_GridIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Students_GridCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Students_GridRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Students_GridCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Students_GridSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSURNAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSCHOOL_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridATTENDING_SCHOOL_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridATTENDING_SCHOOL_ID"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridClippyLink1 As System.Web.UI.WebControls.HyperLink = DirectCast(e.Item.FindControl("Students_GridClippyLink1"),System.Web.UI.WebControls.HyperLink)
            Dim Students_GridENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim Students_GridHidden_clipboardtext As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Students_GridHidden_clipboardtext"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim Students_GridLink1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridLink1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_Gridlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_Gridlabel_ALERTS"),System.Web.UI.WebControls.Literal)
            Dim Students_GridlblCnt As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridlblCnt"),System.Web.UI.WebControls.Literal)
            Dim Students_GridStandardLearningProgram As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridStandardLearningProgram"),System.Web.UI.WebControls.Literal)
            Dim Students_GridCLASS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridCLASS_CODE"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            Students_GridSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","s_SURNAME;s_ENROLMENT_YEAR", ViewState)
            DataItem.ClippyLink1Href = ""
            Students_GridClippyLink1.ImageUrl += DataItem.ClippyLink1.GetFormattedValue()
            Students_GridClippyLink1.NavigateUrl = DataItem.ClippyLink1Href & DataItem.ClippyLink1HrefParameters.ToString("None","", ViewState).Replace("&amp;", "&")
            DataItem.Link1Href = "Student_Comments_maintain.aspx"
            Students_GridLink1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("None","showprofilepanel", ViewState)
        End If
'End Grid Students_Grid ItemDataBound event

'Students_Grid control Before Show @25-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End Students_Grid control Before Show

'Get Control @121-6E7BFB45
            Dim Students_GridHidden_clipboardtext As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Students_GridHidden_clipboardtext"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden Hidden_clipboardtext Event BeforeShow. Action Custom Code @122-73254650
    ' -------------------------
    ' ERA: 8-Dec-2010 : string the name, subject and some other bits together, TAB delimited for copy to clipboard (then paste to Excel)
		Students_GridHidden_clipboardtext.Value = DataItem.STUDENT_ID.GetFormattedValue() + ControlChars.Tab + trim(DataItem.FIRST_NAME.GetFormattedValue()) + " " + trim(DataItem.SURNAME.GetFormattedValue()) + ControlChars.Tab + DataItem.SUBJECT_ABBREV.GetFormattedValue()
    ' -------------------------
'End Hidden Hidden_clipboardtext Event BeforeShow. Action Custom Code

'Get Control @144-4FC3D295
            Dim Students_Gridlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_Gridlabel_ALERTS"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label label_ALERTS Event BeforeShow. Action Declare Variable @151-E947C756
            Dim intAlerts As Int64 = 0
'End Label label_ALERTS Event BeforeShow. Action Declare Variable

'Label label_ALERTS Event BeforeShow. Action DLookup @152-D4836CAE
            intAlerts = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(student_id)" & " FROM " & "view_StudentSummary_Alerts" & " WHERE " & "STUDENT_ID = " &  DataItem.STUDENT_ID.GetFormattedValue() & ""))).Value, Int64)
'End Label label_ALERTS Event BeforeShow. Action DLookup

'Label label_ALERTS Event BeforeShow. Action Custom Code @157-73254650
    ' -------------------------
	Students_Gridlabel_ALERTS.Visible = false
	Students_Gridlabel_ALERTS.Text = "<font color='red'><b>Alert!</b></font>"

    if (intAlerts > 0) then
		Students_Gridlabel_ALERTS.Visible = true
	end if
    ' -------------------------
'End Label label_ALERTS Event BeforeShow. Action Custom Code

'Get Control @191-0BB74591
            Dim Students_GridlblCnt As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridlblCnt"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label lblCnt Event BeforeShow. Action Retrieve Value for Control @192-69B90E3D
            Students_GridlblCnt.Text = (New IntegerField("", Students_GridCurrentRowNumber)).GetFormattedValue()
'End Label lblCnt Event BeforeShow. Action Retrieve Value for Control

'Students_Grid control Before Show tail @25-477CF3C9
        End If
'End Students_Grid control Before Show tail

'Grid Students_Grid ItemDataBound event tail @25-036507A9
        If Students_GridIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Students_GridCurrentRowNumber, ListItemType.Item)
            Students_GridRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Students_GridItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Students_Grid ItemDataBound event tail

'Grid Students_Grid ItemCommand event @25-65BA42CA

    Protected Sub Students_GridItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Students_GridRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Students_GridSortDir"),SortDirections) = SortDirections._Asc And ViewState("Students_GridSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Students_GridSortDir")=SortDirections._Desc
                Else
                    ViewState("Students_GridSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Students_GridSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Students_GridDataProvider.SortFields = 0
            ViewState("Students_GridSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Students_GridPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Students_GridPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Students_GridPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Students_GridPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Students_GridBind
        End If
    End Sub
'End Grid Students_Grid ItemCommand event

'Record Form STUDENT_COMMENT Parameters @13-3A9FD672

    Protected Sub STUDENT_COMMENTParameters()
        Dim item As new STUDENT_COMMENTItem
        Try
            STUDENT_COMMENTData.UrlCOMMENT_ID = IntegerParameter.GetParam("COMMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_COMMENTData.Ctrlhidden_SUBJECT_ID = IntegerParameter.GetParam(item.hidden_SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_COMMENTData.Ctrlhidden_ENROLSTATUS = TextParameter.GetParam(item.hidden_ENROLSTATUS.Value, ParameterSourceType.Control, "", "[C,D,E]", false)
            STUDENT_COMMENTData.CtrlHidden_SEMESTER = TextParameter.GetParam(item.Hidden_SEMESTER.Value, ParameterSourceType.Control, "", "[1,2,B]", false)
            STUDENT_COMMENTData.CtrllbSpecialCommentType1 = TextParameter.GetParam(item.lbSpecialCommentType1.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_COMMENTData.CtrlCOMMENT = TextParameter.GetParam(item.COMMENT.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_COMMENTData.ExprKey195 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            STUDENT_COMMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_COMMENT Parameters

'Record Form STUDENT_COMMENT Show method @13-E9AA1622
    Protected Sub STUDENT_COMMENTShow()
        If STUDENT_COMMENTOperations.None Then
            STUDENT_COMMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_COMMENTItem = STUDENT_COMMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_COMMENTOperations.AllowRead
        STUDENT_COMMENTErrors.Add(item.errors)
        If STUDENT_COMMENTErrors.Count > 0 Then
            STUDENT_COMMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_COMMENT Show method

'Record Form STUDENT_COMMENT BeforeShow tail @13-E85400F5
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTData.FillItem(item, IsInsertMode)
        STUDENT_COMMENTHolder.DataBind()
        STUDENT_COMMENTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_COMMENTOperations.AllowInsert
        STUDENT_COMMENTCOMMENT.Text=item.COMMENT.GetFormattedValue()
        STUDENT_COMMENThidden_SUBJECT_ID.Value = item.hidden_SUBJECT_ID.GetFormattedValue()
        STUDENT_COMMENThidden_ENROLSTATUS.Value = item.hidden_ENROLSTATUS.GetFormattedValue()
        item.lbSpecialCommentType1Items.SetSelection(item.lbSpecialCommentType1.GetFormattedValue())
        STUDENT_COMMENTlbSpecialCommentType1.SelectedIndex = -1
        item.lbSpecialCommentType1Items.CopyTo(STUDENT_COMMENTlbSpecialCommentType1.Items)
        STUDENT_COMMENTHidden_SEMESTER.Value = item.Hidden_SEMESTER.GetFormattedValue()
'End Record Form STUDENT_COMMENT BeforeShow tail

'RadioButton lbSpecialCommentType1 Event BeforeShow. Action Custom Code @173-73254650
    ' -------------------------
    ' 2-3-2011|EA| change to horizontal layout
	STUDENT_COMMENTlbSpecialCommentType1.RepeatDirection = RepeatDirection.Horizontal
    ' -------------------------
'End RadioButton lbSpecialCommentType1 Event BeforeShow. Action Custom Code

'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @26-15D71214
            STUDENT_COMMENThidden_SUBJECT_ID.Value = (New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("List_SUBJECT_ID"))).GetFormattedValue()
'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @27-C9097293
            STUDENT_COMMENThidden_ENROLSTATUS.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("List_SUBJECT_ENROL_STATUS"))).GetFormattedValue()
'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control @174-BCB5565D
            STUDENT_COMMENTHidden_SEMESTER.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("List_SEMESTER"))).GetFormattedValue()
'End Record STUDENT_COMMENT Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_COMMENT Show method tail @13-D9280E89
        If STUDENT_COMMENTErrors.Count > 0 Then
            STUDENT_COMMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_COMMENT Show method tail

'Record Form STUDENT_COMMENT LoadItemFromRequest method @13-404CF1BA

    Protected Sub STUDENT_COMMENTLoadItemFromRequest(item As STUDENT_COMMENTItem, ByVal EnableValidation As Boolean)
        item.COMMENT.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTCOMMENT.UniqueID))
        If ControlCustomValues("STUDENT_COMMENTCOMMENT") Is Nothing Then
            item.COMMENT.SetValue(STUDENT_COMMENTCOMMENT.Text)
        Else
            item.COMMENT.SetValue(ControlCustomValues("STUDENT_COMMENTCOMMENT"))
        End If
        Try
        item.hidden_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENThidden_SUBJECT_ID.UniqueID))
        item.hidden_SUBJECT_ID.SetValue(STUDENT_COMMENThidden_SUBJECT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_COMMENTErrors.Add("hidden_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"hidden_SUBJECT_ID"))
        End Try
        item.hidden_ENROLSTATUS.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENThidden_ENROLSTATUS.UniqueID))
        item.hidden_ENROLSTATUS.SetValue(STUDENT_COMMENThidden_ENROLSTATUS.Value)
        item.lbSpecialCommentType1.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTlbSpecialCommentType1.UniqueID))
        If Not IsNothing(STUDENT_COMMENTlbSpecialCommentType1.SelectedItem) Then
            item.lbSpecialCommentType1.SetValue(STUDENT_COMMENTlbSpecialCommentType1.SelectedItem.Value)
        Else
            item.lbSpecialCommentType1.Value = Nothing
        End If
        item.lbSpecialCommentType1Items.CopyFrom(STUDENT_COMMENTlbSpecialCommentType1.Items)
        item.Hidden_SEMESTER.IsEmpty = IsNothing(Request.Form(STUDENT_COMMENTHidden_SEMESTER.UniqueID))
        item.Hidden_SEMESTER.SetValue(STUDENT_COMMENTHidden_SEMESTER.Value)
        If EnableValidation Then
            item.Validate(STUDENT_COMMENTData)
        End If
        STUDENT_COMMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_COMMENT LoadItemFromRequest method

'Record Form STUDENT_COMMENT GetRedirectUrl method @13-86827CC1

    Protected Function GetSTUDENT_COMMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_COMMENT GetRedirectUrl method

'Record Form STUDENT_COMMENT ShowErrors method @13-C5038092

    Protected Sub STUDENT_COMMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_COMMENTErrors.Count - 1
        Select Case STUDENT_COMMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_COMMENTErrors(i)
        End Select
        Next i
        STUDENT_COMMENTError.Visible = True
        STUDENT_COMMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_COMMENT ShowErrors method

'Record Form STUDENT_COMMENT Insert Operation @13-56B36828

    Protected Sub STUDENT_COMMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_COMMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_COMMENT Insert Operation

'Button Button_Insert OnClick. @14-454288B2
        If CType(sender,Control).ID = "STUDENT_COMMENTButton_Insert" Then
            RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @14-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

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


'Record Form STUDENT_COMMENT BeforeInsert tail @13-425B34D4
    STUDENT_COMMENTParameters()
    STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
    If STUDENT_COMMENTOperations.AllowInsert Then
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_COMMENTData.InsertItem(item)
            Catch ex As Exception
                STUDENT_COMMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_COMMENT BeforeInsert tail

'Record Form STUDENT_COMMENT AfterInsert tail  @13-A6CFA8F7
        End If
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT AfterInsert tail 

'Record Form STUDENT_COMMENT Update Operation @13-A7C84435

    Protected Sub STUDENT_COMMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_COMMENT Update Operation

'Record Form STUDENT_COMMENT Before Update tail @13-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_COMMENT Before Update tail

'Record Form STUDENT_COMMENT Update Operation tail @13-5A342A24
        ErrorFlag=(STUDENT_COMMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_COMMENT Update Operation tail

'Record Form STUDENT_COMMENT Delete Operation @13-11975DEB
    Protected Sub STUDENT_COMMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_COMMENT Delete Operation

'Record Form BeforeDelete tail @13-EF4B79F8
        STUDENT_COMMENTParameters()
        STUDENT_COMMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @13-A1B786F7
        If ErrorFlag Then
            STUDENT_COMMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_COMMENT Cancel Operation @13-CE7ECF6B

    Protected Sub STUDENT_COMMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_COMMENTItem = New STUDENT_COMMENTItem()
        STUDENT_COMMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_COMMENTLoadItemFromRequest(item, False)
'End Record Form STUDENT_COMMENT Cancel Operation

'Button Button_Cancel OnClick. @15-318107BC
    If CType(sender,Control).ID = "STUDENT_COMMENTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_COMMENTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @15-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_COMMENT Cancel Operation tail @13-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_COMMENT Cancel Operation tail


'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-EB17124D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_ClassList_ReportsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        CLASS_LIST_PanelData = New CLASS_LIST_PanelDataProvider()
        CLASS_LIST_PanelOperations = New FormSupportedOperations(False, True, True, True, True)
        Students_GridData = New Students_GridDataProvider()
        Students_GridOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_COMMENTData = New STUDENT_COMMENTDataProvider()
        STUDENT_COMMENTOperations = New FormSupportedOperations(False, False, True, False, False)
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

