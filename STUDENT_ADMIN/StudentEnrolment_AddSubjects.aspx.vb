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

Namespace DECV_PROD2007.StudentEnrolment_AddSubjects 'Namespace @1-6BEA715E

'Forms Definition @1-9172C60A
Public Class [StudentEnrolment_AddSubjectsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-203EB256
    Protected SubjectListData As SubjectListDataProvider
    Protected SubjectListOperations As FormSupportedOperations
    Protected SubjectListCurrentRowNumber As Integer
    Protected AddNewSubjectData As AddNewSubjectDataProvider
    Protected AddNewSubjectErrors As NameValueCollection = New NameValueCollection()
    Protected AddNewSubjectOperations As FormSupportedOperations
    Protected AddNewSubjectIsSubmitted As Boolean = False
    Protected StudentEnrolment_AddSubjectsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-324388B6
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            button_PopupSubjectList.DataBind()
            SubjectListBind
            AddNewSubjectShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

'Button button_PopupSubjectList OnClick Handler @22-E65B54C7
Protected Sub button_PopupSubjectList_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
'End Button button_PopupSubjectList OnClick Handler

'Button button_PopupSubjectList OnClick Handler tail @22-E31F8E2A
End Sub
'End Button button_PopupSubjectList OnClick Handler tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SubjectList Bind @3-DCD46352

    Protected Sub SubjectListBind()
        If Not SubjectListOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SubjectList",GetType(SubjectListDataProvider.SortFields), 80, 100)
        End If
'End Grid SubjectList Bind

'Grid Form SubjectList BeforeShow tail @3-66627E5A
        SubjectListParameters()
        SubjectListData.SortField = CType(ViewState("SubjectListSortField"),SubjectListDataProvider.SortFields)
        SubjectListData.SortDir = CType(ViewState("SubjectListSortDir"),SortDirections)
        SubjectListData.PageNumber = CInt(ViewState("SubjectListPageNumber"))
        SubjectListData.RecordsPerPage = CInt(ViewState("SubjectListPageSize"))
        SubjectListRepeater.DataSource = SubjectListData.GetResultSet(PagesCount, SubjectListOperations)
        ViewState("SubjectListPagesCount") = PagesCount
        Dim item As SubjectListItem = New SubjectListItem()
        SubjectListRepeater.DataBind
        FooterIndex = SubjectListRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SubjectListRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim SubjectListlbldisplay_STUDENTID As System.Web.UI.WebControls.Literal = DirectCast(SubjectListRepeater.Controls(0).FindControl("SubjectListlbldisplay_STUDENTID"),System.Web.UI.WebControls.Literal)
        Dim SubjectListlbldisplay_ENROL_YEAR As System.Web.UI.WebControls.Literal = DirectCast(SubjectListRepeater.Controls(0).FindControl("SubjectListlbldisplay_ENROL_YEAR"),System.Web.UI.WebControls.Literal)
        Dim SubjectListlbldisplay_YEARLEVEL As System.Web.UI.WebControls.Literal = DirectCast(SubjectListRepeater.Controls(0).FindControl("SubjectListlbldisplay_YEARLEVEL"),System.Web.UI.WebControls.Literal)

        SubjectListlbldisplay_STUDENTID.Text = Server.HtmlEncode(item.lbldisplay_STUDENTID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SubjectListlbldisplay_ENROL_YEAR.Text = Server.HtmlEncode(item.lbldisplay_ENROL_YEAR.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SubjectListlbldisplay_YEARLEVEL.Text = Server.HtmlEncode(item.lbldisplay_YEARLEVEL.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form SubjectList BeforeShow tail

'Grid SubjectList Event BeforeShow. Action Retrieve Value for Control @29-D41962B1
        SubjectListlbldisplay_STUDENTID.Text = (New TextField("", System.Web.HttpContext.Current.Session("tmpSTUDENT_ID"))).GetFormattedValue()
'End Grid SubjectList Event BeforeShow. Action Retrieve Value for Control

'Grid SubjectList Event BeforeShow. Action Retrieve Value for Control @30-87DC875B
        SubjectListlbldisplay_ENROL_YEAR.Text = (New TextField("", System.Web.HttpContext.Current.Session("tmpENROLMENT_YEAR"))).GetFormattedValue()
'End Grid SubjectList Event BeforeShow. Action Retrieve Value for Control

'Grid SubjectList Event BeforeShow. Action Retrieve Value for Control @31-55118B74
        SubjectListlbldisplay_YEARLEVEL.Text = (New TextField("", System.Web.HttpContext.Current.Session("tmpYEAR_LEVEL"))).GetFormattedValue()
'End Grid SubjectList Event BeforeShow. Action Retrieve Value for Control

'Grid SubjectList Bind tail @3-E31F8E2A
    End Sub
'End Grid SubjectList Bind tail

'Grid SubjectList Table Parameters @3-5A2B67D2

    Protected Sub SubjectListParameters()
        Try
            SubjectListData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            SubjectListData.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)

        Catch
            Dim ParentControls As ControlCollection=SubjectListRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SubjectListRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SubjectList: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SubjectList Table Parameters

'Grid SubjectList ItemDataBound event @3-E1331E88

    Protected Sub SubjectListItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SubjectListItem = CType(e.Item.DataItem,SubjectListItem)
        Dim Item as SubjectListItem = DataItem
        Dim FormDataSource As SubjectListItem() = CType(SubjectListRepeater.DataSource, SubjectListItem())
        Dim SubjectListDataRows As Integer = FormDataSource.Length
        Dim SubjectListIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SubjectListCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SubjectListRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SubjectListCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SubjectListSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SubjectListSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim SubjectListSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SubjectListSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SubjectListCOURSE_DISTRIBUTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SubjectListCOURSE_DISTRIBUTION"),System.Web.UI.WebControls.Literal)
            Dim SubjectListSEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SubjectListSEMESTER"),System.Web.UI.WebControls.Literal)
            Dim SubjectListENROL_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SubjectListENROL_DATE"),System.Web.UI.WebControls.Literal)
            Dim SubjectListcbox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("SubjectListcbox"),System.Web.UI.WebControls.CheckBox)
            If DataItem.cboxCheckedValue.Value.Equals(DataItem.cbox.Value) Then
                SubjectListcbox.Checked = True
            End If
        End If
'End Grid SubjectList ItemDataBound event

'Grid SubjectList ItemDataBound event tail @3-0444F536
        If SubjectListIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SubjectListCurrentRowNumber, ListItemType.Item)
            SubjectListRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SubjectListItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SubjectList ItemDataBound event tail

'Grid SubjectList ItemCommand event @3-4450E09E

    Protected Sub SubjectListItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SubjectListRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SubjectListSortDir"),SortDirections) = SortDirections._Asc And ViewState("SubjectListSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SubjectListSortDir")=SortDirections._Desc
                Else
                    ViewState("SubjectListSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SubjectListSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SubjectListDataProvider.SortFields = 0
            ViewState("SubjectListSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SubjectListPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SubjectListPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SubjectListPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SubjectListPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SubjectListBind
        End If
    End Sub
'End Grid SubjectList ItemCommand event

'Record Form AddNewSubject Parameters @11-BAF13C10

    Protected Sub AddNewSubjectParameters()
        Dim item As new AddNewSubjectItem
        Try
        Catch e As Exception
            AddNewSubjectErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form AddNewSubject Parameters

'Record Form AddNewSubject Show method @11-FFCCC92D
    Protected Sub AddNewSubjectShow()
        If AddNewSubjectOperations.None Then
            AddNewSubjectHolder.Visible = False
            Return
        End If
        Dim item As AddNewSubjectItem = AddNewSubjectItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not AddNewSubjectOperations.AllowRead
        AddNewSubjectErrors.Add(item.errors)
        If AddNewSubjectErrors.Count > 0 Then
            AddNewSubjectShowErrors()
            Return
        End If
'End Record Form AddNewSubject Show method

'Record Form AddNewSubject BeforeShow tail @11-8357952C
        AddNewSubjectParameters()
        AddNewSubjectData.FillItem(item, IsInsertMode)
        AddNewSubjectHolder.DataBind()
        AddNewSubjects_SUBJECT_ID.Text=item.s_SUBJECT_ID.GetFormattedValue()
        AddNewSubjectlbladdSUBJECT_TITLE.Text = Server.HtmlEncode(item.lbladdSUBJECT_TITLE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        AddNewSubjectaddCOURSE_DISTRIBUTION.Items.Add(new ListItem("Select Value",""))
        AddNewSubjectaddCOURSE_DISTRIBUTION.Items(0).Selected = True
        item.addCOURSE_DISTRIBUTIONItems.SetSelection(item.addCOURSE_DISTRIBUTION.GetFormattedValue())
        If Not item.addCOURSE_DISTRIBUTIONItems.GetSelectedItem() Is Nothing Then
            AddNewSubjectaddCOURSE_DISTRIBUTION.SelectedIndex = -1
        End If
        item.addCOURSE_DISTRIBUTIONItems.CopyTo(AddNewSubjectaddCOURSE_DISTRIBUTION.Items)
        AddNewSubjectaddSEMESTER.Items.Add(new ListItem("Select Value",""))
        AddNewSubjectaddSEMESTER.Items(0).Selected = True
        item.addSEMESTERItems.SetSelection(item.addSEMESTER.GetFormattedValue())
        If Not item.addSEMESTERItems.GetSelectedItem() Is Nothing Then
            AddNewSubjectaddSEMESTER.SelectedIndex = -1
        End If
        item.addSEMESTERItems.CopyTo(AddNewSubjectaddSEMESTER.Items)
        AddNewSubjectaddENROL_DATE.Text=item.addENROL_DATE.GetFormattedValue()
        AddNewSubjecthidden_STUDENT_ID.Value = item.hidden_STUDENT_ID.GetFormattedValue()
        AddNewSubjecthidden_ENROLMENT_YEAR.Value = item.hidden_ENROLMENT_YEAR.GetFormattedValue()
        AddNewSubjecthidden_YEARLEVEL.Value = item.hidden_YEARLEVEL.GetFormattedValue()
        AddNewSubjectlblMessages.Text = Server.HtmlEncode(item.lblMessages.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form AddNewSubject BeforeShow tail

'Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control @39-7A44289F
            AddNewSubjecthidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control

'Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control @40-A2DD5660
            AddNewSubjecthidden_ENROLMENT_YEAR.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control

'Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control @41-69404008
            AddNewSubjecthidden_YEARLEVEL.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("YEAR_LEVEL"))).GetFormattedValue()
'End Record AddNewSubject Event BeforeShow. Action Retrieve Value for Control

'Record Form AddNewSubject Show method tail @11-A78EDEEF
        If AddNewSubjectErrors.Count > 0 Then
            AddNewSubjectShowErrors()
        End If
    End Sub
'End Record Form AddNewSubject Show method tail

'Record Form AddNewSubject LoadItemFromRequest method @11-69F5CEAB

    Protected Sub AddNewSubjectLoadItemFromRequest(item As AddNewSubjectItem, ByVal EnableValidation As Boolean)
        item.s_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(AddNewSubjects_SUBJECT_ID.UniqueID))
        If ControlCustomValues("AddNewSubjects_SUBJECT_ID") Is Nothing Then
            item.s_SUBJECT_ID.SetValue(AddNewSubjects_SUBJECT_ID.Text)
        Else
            item.s_SUBJECT_ID.SetValue(ControlCustomValues("AddNewSubjects_SUBJECT_ID"))
        End If
        item.addCOURSE_DISTRIBUTION.IsEmpty = IsNothing(Request.Form(AddNewSubjectaddCOURSE_DISTRIBUTION.UniqueID))
        item.addCOURSE_DISTRIBUTION.SetValue(AddNewSubjectaddCOURSE_DISTRIBUTION.Value)
        item.addCOURSE_DISTRIBUTIONItems.CopyFrom(AddNewSubjectaddCOURSE_DISTRIBUTION.Items)
        item.addSEMESTER.IsEmpty = IsNothing(Request.Form(AddNewSubjectaddSEMESTER.UniqueID))
        item.addSEMESTER.SetValue(AddNewSubjectaddSEMESTER.Value)
        item.addSEMESTERItems.CopyFrom(AddNewSubjectaddSEMESTER.Items)
        item.addENROL_DATE.IsEmpty = IsNothing(Request.Form(AddNewSubjectaddENROL_DATE.UniqueID))
        If ControlCustomValues("AddNewSubjectaddENROL_DATE") Is Nothing Then
            item.addENROL_DATE.SetValue(AddNewSubjectaddENROL_DATE.Text)
        Else
            item.addENROL_DATE.SetValue(ControlCustomValues("AddNewSubjectaddENROL_DATE"))
        End If
        item.hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(AddNewSubjecthidden_STUDENT_ID.UniqueID))
        item.hidden_STUDENT_ID.SetValue(AddNewSubjecthidden_STUDENT_ID.Value)
        item.hidden_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(AddNewSubjecthidden_ENROLMENT_YEAR.UniqueID))
        item.hidden_ENROLMENT_YEAR.SetValue(AddNewSubjecthidden_ENROLMENT_YEAR.Value)
        item.hidden_YEARLEVEL.IsEmpty = IsNothing(Request.Form(AddNewSubjecthidden_YEARLEVEL.UniqueID))
        item.hidden_YEARLEVEL.SetValue(AddNewSubjecthidden_YEARLEVEL.Value)
        If EnableValidation Then
            item.Validate(AddNewSubjectData)
        End If
        AddNewSubjectErrors.Add(item.errors)
    End Sub
'End Record Form AddNewSubject LoadItemFromRequest method

'Record Form AddNewSubject GetRedirectUrl method @11-9A3D28BC

    Protected Function GetAddNewSubjectRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form AddNewSubject GetRedirectUrl method

'Record Form AddNewSubject ShowErrors method @11-CC963593

    Protected Sub AddNewSubjectShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To AddNewSubjectErrors.Count - 1
        Select Case AddNewSubjectErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & AddNewSubjectErrors(i)
        End Select
        Next i
        AddNewSubjectError.Visible = True
        AddNewSubjectErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form AddNewSubject ShowErrors method

'Record Form AddNewSubject Insert Operation @11-60BBD320

    Protected Sub AddNewSubject_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddNewSubjectItem = New AddNewSubjectItem()
        AddNewSubjectIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AddNewSubject Insert Operation

'Record Form AddNewSubject BeforeInsert tail @11-ACE33452
    AddNewSubjectParameters()
    AddNewSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form AddNewSubject BeforeInsert tail

'Record Form AddNewSubject AfterInsert tail  @11-79D1A889
        ErrorFlag=(AddNewSubjectErrors.Count > 0)
        If ErrorFlag Then
            AddNewSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AddNewSubject AfterInsert tail 

'Record Form AddNewSubject Update Operation @11-563A6F38

    Protected Sub AddNewSubject_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddNewSubjectItem = New AddNewSubjectItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        AddNewSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form AddNewSubject Update Operation

'Record Form AddNewSubject Before Update tail @11-ACE33452
        AddNewSubjectParameters()
        AddNewSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form AddNewSubject Before Update tail

'Record Form AddNewSubject Update Operation tail @11-79D1A889
        ErrorFlag=(AddNewSubjectErrors.Count > 0)
        If ErrorFlag Then
            AddNewSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AddNewSubject Update Operation tail

'Record Form AddNewSubject Delete Operation @11-BB29F977
    Protected Sub AddNewSubject_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        AddNewSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As AddNewSubjectItem = New AddNewSubjectItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form AddNewSubject Delete Operation

'Record Form BeforeDelete tail @11-ACE33452
        AddNewSubjectParameters()
        AddNewSubjectLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @11-02326F7A
        If ErrorFlag Then
            AddNewSubjectShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form AddNewSubject Cancel Operation @11-1E171CCF

    Protected Sub AddNewSubject_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As AddNewSubjectItem = New AddNewSubjectItem()
        AddNewSubjectIsSubmitted = True
        Dim RedirectUrl As String = ""
        AddNewSubjectLoadItemFromRequest(item, True)
'End Record Form AddNewSubject Cancel Operation

'Record Form AddNewSubject Cancel Operation tail @11-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form AddNewSubject Cancel Operation tail

'Button Button_DoAdd OnClick Handler @32-F343B901
    Protected Sub AddNewSubject_Button_DoAdd_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetAddNewSubjectRedirectUrl("", "")
        Dim item As New AddNewSubjectItem
        AddNewSubjectLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (AddNewSubjectErrors.Count > 0)
'End Button Button_DoAdd OnClick Handler

'Button Button_DoAdd Event OnClick. Action Custom Code @33-73254650
    ' -------------------------
    ' ERA: do insert of Subject with extra bits in transaction
	      'ERA: sort through the selected subjects

  		dim strSubjectID as string

        If (not ErrorFlag) Then

                ' ensure the date is in yyyy-MM-dd format for standard SQL
                'set as local variable
                'Dim GBformat As New CultureInfo("en-GB", True)
                'Dim strDateTemp As String = String.Format("{0:yyyy-MM-dd}", DateTime.Parse(item.despatchdate.Value, GBformat))

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                Dim trans As OleDb.OleDbTransaction
                Dim cmd As OleDb.OleDbCommand

   				Try
					AddNewSubjectlblMessages.Text =""
                    ' a little more formal than the Sybase 'begin trans' statement
                    If NewDao.NativeConnection.State <> ConnectionState.Open Then
                        NewDao.NativeConnection.Open()
                        'NewDao.DateFormat = "mdy"
                    End If

                    trans = NewDao.NativeConnection.BeginTransaction()
                    cmd = NewDao.NativeConnection.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Transaction = trans

                    Dim strSQL As String = ""
					Dim intTmpBookMax as integer = 0
					Dim intTmpBookCounter as integer = 1

					Dim tmpUsername As String
					 If (Session("UserID").ToString = "") Then
                        tmpUsername = "'" & Left(Session.SessionID.ToString, 8) & "'"
                    Else
                        tmpUsername = NewDao.ToSql(Session("UserID").ToString, FieldType._Text, True)
                    End If
                    
                    ' work out the subject_status_rule() from dynamo functions in Sybase app
                    Dim strsubj_enrol_status As String = "C"
                    Dim intMonth As Int64 = (Month(Now()))

                    If (item.addSEMESTER.Value = "1" Or item.addSEMESTER.Value = "B") Then
                        strsubj_enrol_status = "C"
                    ElseIf (item.addSEMESTER.Value = "2") Then
                        If intMonth >= 7 And intMonth <= 10 Then
                            strsubj_enrol_status = "C"
                        Else
                            strsubj_enrol_status = "P"
                        End If
                    End If

					strSubjectID = NewDao.ToSql(Me.AddNewSubjects_SUBJECT_ID.Text, FieldType._Integer)
                    If strSubjectID <> "" Then
						' add to TMP table

                             'NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer)
								strSQL = "insert TEMP_STUDENT_SUBJECT (STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID "
								strSQL += ", STAFF_ID, SEMESTER, ENROLMENT_DATE "
								strSQL += ", SUBJ_ENROL_STATUS, VBOS_REGISTERED, APPEARS_ON_VASS, NUM_ASSMT_SUBMISSIONS, EXTENSION_OF_VCE_UNIT "
								strSQL += ", COURSE_DISTRIBUTION, LAST_ALTERED_BY, LAST_ALTERED_DATE) "
    							 strSQL += "	values(" & NewDao.ToSql(Me.AddNewSubjecthidden_STUDENT_ID.Value, FieldType._Integer) & "," & NewDao.ToSql(Me.AddNewSubjecthidden_ENROLMENT_YEAR.Value, FieldType._Integer) & "," & strSubjectID & " "
		                        strSQL += ", 'DUMMY','" & NewDao.ToSql(Me.AddNewSubjectaddSEMESTER.Value, FieldType._Text) & "','" & NewDao.ToSql(Me.AddNewSubjectaddENROL_DATE.Text, FieldType._Text) & "'"
        		                strSQL += ", '" + strsubj_enrol_status + "',1,0,0,0 "
                		        strSQL += ", '" & NewDao.ToSql(Me.AddNewSubjectaddCOURSE_DISTRIBUTION.Value, FieldType._Text) & "', " & tmpUsername & ", getdate())"

                                cmd.CommandText = strSQL
                                'cmd.ExecuteNonQuery()
								AddNewSubjectlblMessages.Text += "<hr>0:TESTING WITHOUT SAVING: " & strSQL
								AddNewSubjectlblMessages.Text += "<hr>1: " & strSQL

								' and remove it from the temp table for all years (in original code - seems superflouous)
								strSQL = "update TEMP_STUDENT_SUBJECT set a.STAFF_ID=b.DEFAULT_TEACHER_ID from TEMP_STUDENT_SUBJECT a, SUBJECT b "
								strSQL += " where a.SUBJECT_ID=b.SUBJECT_ID "
								strSQL += " and a.SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and a.STUDENT_ID= " & NewDao.ToSql(Me.AddNewSubjecthidden_STUDENT_ID.value, FieldType._Integer) & " "
                                strSQL += " and a.ENROLMENT_YEAR= " & NewDao.ToSql(Me.AddNewSubjecthidden_ENROLMENT_YEAR.value, FieldType._Integer) & " "
	                            cmd.CommandText = strSQL
                                'cmd.ExecuteNonQuery()
                                AddNewSubjectlblMessages.Text += "<hr>2: " & strSQL

								' now update the Books list
								strSQL = "select MAX_BOOKS from SUBJECT  "
								strSQL += " where SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
	                            cmd.CommandText = strSQL
								intTmpBookMax = cmd.ExecuteScalar()

								for intTmpBookCounter = 1 to intTmpBookCounter
									strSQL = "insert TEMP_BOOK_DESPATCH (STUDENT_ID, ENROLMENT_YEAR, SUBJECT_ID, BOOK_ID, DESPATCH_STATUS, LAST_ALTERED_BY, LAST_ALTERED_DATE) "
									strSQL += "	values(" & NewDao.ToSql(Me.AddNewSubjecthidden_STUDENT_ID.value, FieldType._Integer) & "," & NewDao.ToSql(Me.AddNewSubjecthidden_ENROLMENT_YEAR.value, FieldType._Integer) & "," & strSubjectID &" "
    								strSQL += ", " & NewDao.ToSql(intTmpBookCounter, FieldType._Integer) & ",'T', " & tmpUsername & ", getdate())"
		                            cmd.CommandText = strSQL
	                                'cmd.ExecuteNonQuery()
	                                AddNewSubjectlblMessages.Text += "<hr>3:" & strSQL

								next 
							
                    End If

                    trans.Commit()
                    AddNewSubjectlblMessages.Text += "<br><font color=red>Student Subject Add performed successfully for Subject ID " & Me.AddNewSubjects_SUBJECT_ID.text & "</font>"

                Catch ex As Exception
                    trans.Rollback()
                    AddNewSubjectlblMessages.Text += "<br><font color=red>Student Subject Add <b>FAILED</b> for Subject ID " & Me.AddNewSubjects_SUBJECT_ID.text & "</font>"
                    AddNewSubjectlblMessages.Text += "<br>Error: " & ex.Message.ToString
                    AddNewSubjectlblMessages.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

         End If

    ' -------------------------
'End Button Button_DoAdd Event OnClick. Action Custom Code

'Button Button_DoAdd OnClick Handler tail @32-C7CEEC17
        If ErrorFlag Then
            AddNewSubjectShowErrors()
        'Else
        '    Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoAdd OnClick Handler tail

'Button Button_DoDelete OnClick Handler @35-32258E69
    Protected Sub AddNewSubject_Button_DoDelete_OnClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim RedirectUrl As String = GetAddNewSubjectRedirectUrl("", "")
        Dim item As New AddNewSubjectItem
        AddNewSubjectLoadItemFromRequest(item, True)
        Dim ErrorFlag As Boolean = (AddNewSubjectErrors.Count > 0)
'End Button Button_DoDelete OnClick Handler

'Button Button_DoDelete Event OnClick. Action Custom Code @37-73254650
    ' -------------------------
    	      'ERA: sort through the selected subjects
  		dim repItem as RepeaterItem
  		dim chkBoxed as Checkbox
  		dim strSubjectID as string

        If (not ErrorFlag) Then

                'actually send the requested changes to the SQL string
                Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
                Dim trans As OleDb.OleDbTransaction
                Dim cmd As OleDb.OleDbCommand

   				Try
					AddNewSubjectlblMessages.Text =""
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

                    For Each repItem In SubjectListRepeater.Items
                        chkBoxed = repItem.FindControl("SubjectListcbox")
                        If chkBoxed.Checked Then
                            strSubjectID = CType(repItem.FindControl("SubjectListlbldisplay_SUBJECTID"), Literal).Text
                            If strSubjectID <> "" Then
                                'NewDao.ToSql(Request.QueryString("task_id"),FieldType._Integer)
								strSQL = "delete from TEMP_BOOK_DESPATCH "
								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and STUDENT_ID= " & NewDao.ToSql(item.hidden_STUDENT_ID.value, FieldType._Integer) & " "
                                strSQL += " and ENROLMENT_YEAR= " & NewDao.ToSql(item.hidden_ENROLMENT_YEAR.value, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                'cmd.ExecuteNonQuery()
								AddNewSubjectlblMessages.Text += "<hr>" & strSQL

								' and remove it from the temp table for all years (in original code - seems superflouous)
								strSQL = "delete from TEMP_BOOK_DESPATCH "
								strSQL += "where SUBJECT_ID= " & NewDao.ToSql(strSubjectID, FieldType._Integer) & " "
                                strSQL += " and STUDENT_ID= " & NewDao.ToSql(item.hidden_STUDENT_ID.value, FieldType._Integer) & " "
                                cmd.CommandText = strSQL
                                'cmd.ExecuteNonQuery()

                                AddNewSubjectlblMessages.Text += "<hr>" & strSQL
                            End If
                        End If
                    Next

                    trans.Commit()
                    AddNewSubjectlblMessages.Text += "<br><font color=red>Student Subject Delete performed successfully for Student ID " & Me.AddNewSubjecthidden_STUDENT_ID.value & "</font>"

                Catch ex As Exception
                    trans.Rollback()
                    AddNewSubjectlblMessages.Text += "<br><font color=red>Student Subject Delete <b>FAILED</b> for Student ID " & Me.AddNewSubjecthidden_STUDENT_ID.value & "</font>"
                    AddNewSubjectlblMessages.Text += "<br>Error: " & ex.Message.ToString
                    AddNewSubjectlblMessages.Visible = True
                Finally
                    If NewDao.NativeConnection.State = ConnectionState.Open Then
                        NewDao.NativeConnection.Close()
                    End If
                End Try

         End If

    ' -------------------------
'End Button Button_DoDelete Event OnClick. Action Custom Code

'Button Button_DoDelete OnClick Handler tail @35-C7CEEC17
        If ErrorFlag Then
            AddNewSubjectShowErrors()
        'Else
        '    Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Button Button_DoDelete OnClick Handler tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-350CC5DC
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_AddSubjectsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SubjectListData = New SubjectListDataProvider()
        SubjectListOperations = New FormSupportedOperations(False, True, False, False, False)
        AddNewSubjectData = New AddNewSubjectDataProvider()
        AddNewSubjectOperations = New FormSupportedOperations(False, True, True, True, True)
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

