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

Namespace DECV_PROD2007.StudentAmendments_Results 'Namespace @1-AB35CC4E

'Forms Definition @1-1B043883
Public Class [StudentAmendments_ResultsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-CA2C8CF4
    Protected UpdateFormData As UpdateFormDataProvider
    Protected UpdateFormErrors As NameValueCollection = New NameValueCollection()
    Protected UpdateFormOperations As FormSupportedOperations
    Protected UpdateFormIsSubmitted As Boolean = False
    Protected GridStudentListData As GridStudentListDataProvider
    Protected GridStudentListOperations As FormSupportedOperations
    Protected GridStudentListCurrentRowNumber As Integer
    Protected StudentAmendments_ResultsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-55B9CF80
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "StudentAmendment.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
            Link1.DataBind()
            UpdateFormShow()
            GridStudentListBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form UpdateForm Parameters @57-FB1FC6A7

    Protected Sub UpdateFormParameters()
        Dim item As new UpdateFormItem
        Try
            UpdateFormData.Urls_SUBJECT_ID = IntegerParameter.GetParam("s_SUBJECT_ID", ParameterSourceType.URL, "", 0, false)
        Catch e As Exception
            UpdateFormErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form UpdateForm Parameters

'Record Form UpdateForm Show method @57-1A16F80A
    Protected Sub UpdateFormShow()
        If UpdateFormOperations.None Then
            UpdateFormHolder.Visible = False
            Return
        End If
        Dim item As UpdateFormItem = UpdateFormItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not UpdateFormOperations.AllowRead
        UpdateFormErrors.Add(item.errors)
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
            Return
        End If
'End Record Form UpdateForm Show method

'Record Form UpdateForm BeforeShow tail @57-6D44BE0D
        UpdateFormParameters()
        UpdateFormData.FillItem(item, IsInsertMode)
        UpdateFormHolder.DataBind()
        UpdateFormlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblEnrolmentYear.Text = Server.HtmlEncode(item.lblEnrolmentYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblRowsPerPage.Text = Server.HtmlEncode(item.lblRowsPerPage.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlblYearLevel.Text = Server.HtmlEncode(item.lblYearLevel.GetFormattedValue()).Replace(vbCrLf,"<br>")
        UpdateFormlistTeacher.Items.Add(new ListItem("Select Value",""))
        UpdateFormlistTeacher.Items(0).Selected = True
        item.listTeacherItems.SetSelection(item.listTeacher.GetFormattedValue())
        If Not item.listTeacherItems.GetSelectedItem() Is Nothing Then
            UpdateFormlistTeacher.SelectedIndex = -1
        End If
        item.listTeacherItems.CopyTo(UpdateFormlistTeacher.Items)
        UpdateFormlblSelections.Text = Server.HtmlEncode(item.lblSelections.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form UpdateForm BeforeShow tail

'Record UpdateForm Event BeforeShow. Action Retrieve Value for Control @71-0F289618
            UpdateFormlblStudentID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_STUDENT_ID_lowest"))).GetFormattedValue()
'End Record UpdateForm Event BeforeShow. Action Retrieve Value for Control

'Record UpdateForm Event BeforeShow. Action Retrieve Value for Control @75-0F5C2245
            UpdateFormlblEnrolmentYear.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_ENROLMENT_YEAR"))).GetFormattedValue()
'End Record UpdateForm Event BeforeShow. Action Retrieve Value for Control

'Record UpdateForm Event BeforeShow. Action Retrieve Value for Control @76-9A22DBE4
            UpdateFormlblRowsPerPage.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("listRowsPerPage"))).GetFormattedValue()
'End Record UpdateForm Event BeforeShow. Action Retrieve Value for Control

'Record UpdateForm Event BeforeShow. Action Declare Variable @119-54C8AC9A
            Dim strDisplayYearLevel As String = ""
'End Record UpdateForm Event BeforeShow. Action Declare Variable

'Record UpdateForm Event BeforeShow. Action Retrieve Value for Variable @112-76A5CA9E
            strDisplayYearLevel = System.Web.HttpContext.Current.Request.QueryString("s_YEAR_LEVEL")
'End Record UpdateForm Event BeforeShow. Action Retrieve Value for Variable

'Record UpdateForm Event BeforeShow. Action Custom Code @113-73254650
    ' -------------------------
    ' ERA: convert the s_YEAR_LEVEL (which may be '99') into display value (ALL)
	if (strDisplayYearLevel="99") then
		strDisplayYearLevel = "All Year Levels"
	end if
    ' -------------------------
'End Record UpdateForm Event BeforeShow. Action Custom Code

'Record UpdateForm Event BeforeShow. Action Retrieve Value for Control @114-06AFEB40
            UpdateFormlblYearLevel.Text = (New TextField("", strDisplayYearLevel)).GetFormattedValue()
'End Record UpdateForm Event BeforeShow. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL  	'ERA: collect SUBJECT_TITLE
'DEL  	Dim tmpSubjectID As String 
'DEL  	tmpSubjectID = UpdateFormlblSubjectID.Text
'DEL  	If (Not tmpSubjectID = "") Then
'DEL  		UpdateFormlblSubjectTitle.Text = (New TextField("", Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("select isnull(SUBJECT_TITLE,'') from SUBJECT where SUBJECT_ID=" & tmpSubjectID))).GetFormattedValue("")
'DEL  	End If
'DEL  
'DEL      ' -------------------------


'Record Form UpdateForm Show method tail @57-8DD284E7
        If UpdateFormErrors.Count > 0 Then
            UpdateFormShowErrors()
        End If
    End Sub
'End Record Form UpdateForm Show method tail

'Record Form UpdateForm LoadItemFromRequest method @57-F1BDF37A

    Protected Sub UpdateFormLoadItemFromRequest(item As UpdateFormItem, ByVal EnableValidation As Boolean)
        item.listTeacher.IsEmpty = IsNothing(Request.Form(UpdateFormlistTeacher.UniqueID))
        item.listTeacher.SetValue(UpdateFormlistTeacher.Value)
        item.listTeacherItems.CopyFrom(UpdateFormlistTeacher.Items)
        If EnableValidation Then
            item.Validate(UpdateFormData)
        End If
        UpdateFormErrors.Add(item.errors)
    End Sub
'End Record Form UpdateForm LoadItemFromRequest method

'Record Form UpdateForm GetRedirectUrl method @57-E63A1AD3

    Protected Function GetUpdateFormRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form UpdateForm GetRedirectUrl method

'Record Form UpdateForm ShowErrors method @57-52F4A342

    Protected Sub UpdateFormShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To UpdateFormErrors.Count - 1
        Select Case UpdateFormErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & UpdateFormErrors(i)
        End Select
        Next i
        UpdateFormError.Visible = True
        UpdateFormErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form UpdateForm ShowErrors method

'Record Form UpdateForm Insert Operation @57-337A0C41

    Protected Sub UpdateForm_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Insert Operation

'Record Form UpdateForm BeforeInsert tail @57-B633AE71
    UpdateFormParameters()
    UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm BeforeInsert tail

'Record Form UpdateForm AfterInsert tail  @57-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm AfterInsert tail 

'Record Form UpdateForm Update Operation @57-26B5347A

    Protected Sub UpdateForm_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UpdateForm Update Operation

'Record Form UpdateForm Before Update tail @57-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form UpdateForm Before Update tail

'Record Form UpdateForm Update Operation tail @57-5C89AAEA
        ErrorFlag=(UpdateFormErrors.Count > 0)
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UpdateForm Update Operation tail

'Record Form UpdateForm Delete Operation @57-339A2861
    Protected Sub UpdateForm_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As UpdateFormItem = New UpdateFormItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form UpdateForm Delete Operation

'Record Form BeforeDelete tail @57-B633AE71
        UpdateFormParameters()
        UpdateFormLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @57-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form UpdateForm Cancel Operation @57-062247BE

    Protected Sub UpdateForm_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UpdateFormItem = New UpdateFormItem()
        UpdateFormIsSubmitted = True
        Dim RedirectUrl As String = ""
        UpdateFormLoadItemFromRequest(item, True)
'End Record Form UpdateForm Cancel Operation

'Record Form UpdateForm Cancel Operation tail @57-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form UpdateForm Cancel Operation tail

'Button button_DoTeacher OnClick Handler @64-4D75E177
    Protected Sub UpdateForm_button_DoTeacher_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetUpdateFormRedirectUrl("", "")
        Dim item As New UpdateFormItem
        UpdateFormLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (UpdateFormErrors.Count > 0)
'End Button button_DoTeacher OnClick Handler

'Button button_DoTeacher Event OnClick. Action Custom Code @94-73254650
    ' -------------------------
      'ERA: sort through the selected subjects
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strStudentID as string

        If (not ErrorFlag) Then

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject

                'Dim trans As OleDb.OleDbTransaction    ' LN: 8/11/2013
                'Dim cmd As OleDb.OleDbCommand          ' LN: 8/11/2013
                Dim trans As SqlClient.SqlTransaction   ' LN: 8/11/2013
                Dim cmd As SqlClient.SqlCommand         ' LN: 8/11/2013

   				Try
					UpdateFormlblSelections.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""
					Dim tmpUsername As String
					 If (Session("UserID").ToString = "") Then
                        tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    
					dim tmpPastoralID as string = ""
					if item.listTeacher.value = "[none]" then
						' value '[none]' is to change back to NULL
						tmpPastoralID = "null"
					else
						tmpPastoralID = NewDao.ToSql(item.listTeacher.value, FieldType._Text, true)
                    End If

                    For Each repItem In GridStudentListRepeater.Items
                        chkBoxed = repItem.FindControl("GridStudentListcbox")
                        If chkBoxed.Checked Then
                            strStudentID = CType(repItem.FindControl("GridStudentListStudent_ID"), Literal).Text
                            If strStudentID <> "" Then
								strSQL = "update STUDENT_ENROLMENT "
							    strSQL += " set PASTORAL_CARE_ID=" & tmpPastoralID & " "
								'strSQL += " , LAST_ALTERED_BY=" & tmpUsername & " "
								'strSQL += " , LAST_ALTERED_DATE=getdate() "
								strSQL += "where STUDENT_ID= " & NewDao.ToSql(strStudentID, FieldType._Integer) & " "
                                strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(Me.UpdateFormlblEnrolmentYear.Text, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                cmd.ExecuteNonQuery()

                                'UpdateFormlblSelections.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

                    trans.Commit()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student/Pastoral Care ID Update performed successfully for Pastoral Care ID " & item.listTeacher.getformattedvalue() & "</font>"

                Catch ex As Exception
                    trans.Rollback()
                    UpdateFormlblSelections.Text += "<br><font color=red>Student/Pastoral Care ID Update <b>FAILED</b> for Pastoral Care ID " & item.listTeacher.getformattedvalue()  & "</font>"
                    UpdateFormlblSelections.Text += "<br>Error: " & ex.Message.ToString
                    UpdateFormlblSelections.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

            End If

    ' -------------------------
'End Button button_DoTeacher Event OnClick. Action Custom Code

'Button button_DoTeacher OnClick Handler tail @64-1FF43032
        If ErrorFlag Then
            UpdateFormShowErrors()
        'Else
        '    Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button button_DoTeacher OnClick Handler tail


'Grid GridStudentList Bind @2-F216CD8C

    Protected Sub GridStudentListBind()
        If Not GridStudentListOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"GridStudentList",GetType(GridStudentListDataProvider.SortFields), 80, 100)
        End If
'End Grid GridStudentList Bind

'Grid Form GridStudentList BeforeShow tail @2-0675D912
        GridStudentListParameters()
        GridStudentListData.SortField = CType(ViewState("GridStudentListSortField"),GridStudentListDataProvider.SortFields)
        GridStudentListData.SortDir = CType(ViewState("GridStudentListSortDir"),SortDirections)
        GridStudentListData.PageNumber = CInt(ViewState("GridStudentListPageNumber"))
        GridStudentListData.RecordsPerPage = CInt(ViewState("GridStudentListPageSize"))
        GridStudentListRepeater.DataSource = GridStudentListData.GetResultSet(PagesCount, GridStudentListOperations)
        ViewState("GridStudentListPagesCount") = PagesCount
        Dim item As GridStudentListItem = New GridStudentListItem()
        GridStudentListRepeater.DataBind
        FooterIndex = GridStudentListRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            GridStudentListRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(GridStudentListRepeater.Controls(0).FindControl("GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(GridStudentListRepeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(GridStudentListRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords.Text = Server.HtmlEncode(item.STUD_SUB_INTERIM_STUD_SUB_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form GridStudentList BeforeShow tail

'Label STUD_SUB_INTERIM_STUD_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records @34-4E91E0C4
            GridStudentListSTUD_SUB_INTERIM_STUD_SUB_TotalRecords.Text = GridStudentListData.RecordCount.ToString()
'End Label STUD_SUB_INTERIM_STUD_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid GridStudentList Bind tail @2-E31F8E2A
    End Sub
'End Grid GridStudentList Bind tail

'Grid GridStudentList Table Parameters @2-2AA47525

    Protected Sub GridStudentListParameters()
        Try
            GridStudentListData.Urls_STUDENT_ID_lowest = IntegerParameter.GetParam("s_STUDENT_ID_lowest", ParameterSourceType.URL, "", 10000, false)
            GridStudentListData.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)
            GridStudentListData.Urls_ENROL_STATUS = TextParameter.GetParam("s_ENROL_STATUS", ParameterSourceType.URL, "", "[CEPD]", false)
            GridStudentListData.Urls_YEAR_LEVEL = TextParameter.GetParam("s_YEAR_LEVEL", ParameterSourceType.URL, "", 99, false)

        Catch
            Dim ParentControls As ControlCollection=GridStudentListRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(GridStudentListRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid GridStudentList: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid GridStudentList Table Parameters

'Grid GridStudentList ItemDataBound event @2-1312A668

    Protected Sub GridStudentListItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as GridStudentListItem = CType(e.Item.DataItem,GridStudentListItem)
        Dim Item as GridStudentListItem = DataItem
        Dim FormDataSource As GridStudentListItem() = CType(GridStudentListRepeater.DataSource, GridStudentListItem())
        Dim GridStudentListDataRows As Integer = FormDataSource.Length
        Dim GridStudentListIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            GridStudentListCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(GridStudentListRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, GridStudentListCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim GridStudentListcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("GridStudentListcbox"),System.Web.UI.WebControls.CheckBox)
            Dim GridStudentListSTUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSTUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSURNAME"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListSUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim GridStudentListSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("GridStudentListSTAFF_ID"),System.Web.UI.WebControls.Literal)
            If DataItem.cboxCheckedValue.Value.Equals(DataItem.cbox.Value) Then
                GridStudentListcbox.Checked = True
            End If
        End If
'End Grid GridStudentList ItemDataBound event

'Grid GridStudentList BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid GridStudentList BeforeShowRow event

'Grid GridStudentList Event BeforeShowRow. Action Set Row Style @44-1F92F588
            Dim styles44 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex44 As Integer = (GridStudentListCurrentRowNumber - 1) Mod styles44.Length
            Dim rawStyle44 As String = styles44(styleIndex44).Replace("\;",";")
            If rawStyle44.IndexOf("=") = -1 And rawStyle44.IndexOf(":") > -1 Then
                rawStyle44 = "style=""" + rawStyle44 + """"
            ElseIf rawStyle44.IndexOf("=") = -1 And rawStyle44.IndexOf(":") = -1 And rawStyle44 <> "" Then
                rawStyle44 = "class=""" + rawStyle44 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(GridStudentListRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle44), AttributeOption.Multiple)
'End Grid GridStudentList Event BeforeShowRow. Action Set Row Style

'Grid GridStudentList BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid GridStudentList BeforeShowRow event tail

'Grid GridStudentList ItemDataBound event tail @2-5FA60C23
        If GridStudentListIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(GridStudentListCurrentRowNumber, ListItemType.Item)
            GridStudentListRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            GridStudentListItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid GridStudentList ItemDataBound event tail

'Grid GridStudentList ItemCommand event @2-04985BC2

    Protected Sub GridStudentListItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= GridStudentListRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("GridStudentListSortDir"),SortDirections) = SortDirections._Asc And ViewState("GridStudentListSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("GridStudentListSortDir")=SortDirections._Desc
                Else
                    ViewState("GridStudentListSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("GridStudentListSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As GridStudentListDataProvider.SortFields = 0
            ViewState("GridStudentListSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("GridStudentListPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("GridStudentListPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("GridStudentListPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("GridStudentListPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            GridStudentListBind
        End If
    End Sub
'End Grid GridStudentList ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-096BA40D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentAmendments_ResultsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        UpdateFormData = New UpdateFormDataProvider()
        UpdateFormOperations = New FormSupportedOperations(False, True, True, True, True)
        GridStudentListData = New GridStudentListDataProvider()
        GridStudentListOperations = New FormSupportedOperations(False, True, False, False, False)
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

