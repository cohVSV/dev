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

Namespace DECV_PROD2007.Staff_LAdAllocation_maint 'Namespace @1-27B9FC2B

'Forms Definition @1-E9AC56A8
Public Class [Staff_LAdAllocation_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-8FD2EEA2
    Protected ManageLADsData As ManageLADsDataProvider
    Protected ManageLADsCurrentRowNumber As Integer
    Protected ManageLADsIsSubmitted As Boolean = False
    Protected ManageLADsErrors As New NameValueCollection()
    Protected ManageLADsOperations As FormSupportedOperations
    Protected ManageLADsDataItem As ManageLADsItem
    Protected SUBJECT_SUBJECT_TEACHERData As SUBJECT_SUBJECT_TEACHERDataProvider
    Protected SUBJECT_SUBJECT_TEACHERErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECT_SUBJECT_TEACHEROperations As FormSupportedOperations
    Protected SUBJECT_SUBJECT_TEACHERIsSubmitted As Boolean = False
    Protected SUBJECT_TEACHERData As SUBJECT_TEACHERDataProvider
    Protected SUBJECT_TEACHERErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECT_TEACHEROperations As FormSupportedOperations
    Protected SUBJECT_TEACHERIsSubmitted As Boolean = False
    Protected Staff_LAdAllocation_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-ACDBA90E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ManageLADsBind()
            SUBJECT_SUBJECT_TEACHERShow()
            SUBJECT_TEACHERShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid ManageLADs Bind @3-F6B1651C
    Protected Sub ManageLADsBind()
        If ManageLADsOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ManageLADs",GetType(ManageLADsDataProvider.SortFields), 200, 100)
        End If
'End EditableGrid ManageLADs Bind

'EditableGrid Form ManageLADs BeforeShow tail @3-AD5FF2C4
        ManageLADsParameters()
        ManageLADsData.SortField = CType(ViewState("ManageLADsSortField"), ManageLADsDataProvider.SortFields)
        ManageLADsData.SortDir = CType(ViewState("ManageLADsSortDir"), SortDirections)
        ManageLADsData.PageNumber = CType(ViewState("ManageLADsPageNumber"), Integer)
        ManageLADsData.RecordsPerPage = CType(ViewState("ManageLADsPageSize"), Integer)
        ManageLADsRepeater.DataSource = ManageLADsData.GetResultSet(PagesCount, ManageLADsOperations)
        ViewState("ManageLADsPagesCount") = PagesCount
        ViewState("ManageLADsFormState") = New Hashtable()
        ViewState("ManageLADsRowState") = New Hashtable()
        ManageLADsRepeater.DataBind()
        Dim item As ManageLADsItem = ManageLADsDataItem
        If IsNothing(item) Then item = New ManageLADsItem()
        FooterIndex = ManageLADsRepeater.Controls.Count - 1
        Dim Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ManageLADsRepeater.Controls(0).FindControl("Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim ManageLADsTotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ManageLADsRepeater.Controls(0).FindControl("ManageLADsTotalRecords"),System.Web.UI.WebControls.Literal)
        Dim ManageLADsbuttonUpdate As System.Web.UI.WebControls.Button = DirectCast(ManageLADsRepeater.Controls(FooterIndex).FindControl("ManageLADsbuttonUpdate"),System.Web.UI.WebControls.Button)
        Dim ManageLADsbuttonCancel As System.Web.UI.WebControls.Button = DirectCast(ManageLADsRepeater.Controls(FooterIndex).FindControl("ManageLADsbuttonCancel"),System.Web.UI.WebControls.Button)


        ManageLADsTotalRecords.Text = Server.HtmlEncode(item.TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ManageLADsbuttonUpdate.Visible = ManageLADsOperations.Editable
        If Not CType(ManageLADsRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            ManageLADsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If ManageLADsErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(ManageLADsRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(ManageLADsRepeater.Controls(0).FindControl("ManageLADsError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In ManageLADsErrors
                ErrorLabel.Text += ManageLADsErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form ManageLADs BeforeShow tail

'Label TotalRecords Event BeforeShow. Action Retrieve number of records @554-BFEDAC61
            ManageLADsTotalRecords.Text = ManageLADsData.RecordCount.ToString()
'End Label TotalRecords Event BeforeShow. Action Retrieve number of records

'DEL      ' -------------------------
'DEL      'ERA: make it nice and vertical
'DEL  	SUBJECT_TEACHER_SUBJECT_SrbAllocatable.RepeatDirection = RepeatDirection.Vertical
'DEL      ' -------------------------

'EditableGrid ManageLADs Bind tail @3-EA95642F
        ManageLADsShowErrors(New ArrayList(CType(ManageLADsRepeater.DataSource, ICollection)), ManageLADsRepeater.Items)
    End Sub
'End EditableGrid ManageLADs Bind tail

'EditableGrid ManageLADs Table Parameters @3-998956EC
    Protected Sub ManageLADsParameters()
        Try
        Dim item As new ManageLADsItem
            ManageLADsData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
            ManageLADsData.UrlrbShow = IntegerParameter.GetParam("rbShow", ParameterSourceType.URL, "", 0, false)
            ManageLADsData.Expr398 = DateParameter.GetParam(NOW(), ParameterSourceType.Expression, Settings.DateFormat, NOW(), false)
            ManageLADsData.CtrlLAD_MAX_ALLOC = IntegerParameter.GetParam(item.LAD_MAX_ALLOC.Value, ParameterSourceType.Control, "0;(0)", 0, false)
            ManageLADsData.Expr497 = TextParameter.GetParam(dbutility.userid.tostring.toupper, ParameterSourceType.Expression, "", "unknown", false)
            ManageLADsData.CtrlradioYEAR_LEVEL = IntegerParameter.GetParam(item.radioYEAR_LEVEL.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = ManageLADsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(ManageLADsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid ManageLADs: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid ManageLADs Table Parameters

'EditableGrid ManageLADs ItemDataBound event @3-30128FD1
    Protected Sub ManageLADsItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As ManageLADsItem = DirectCast(e.Item.DataItem, ManageLADsItem)
        Dim Item as ManageLADsItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ManageLADsCurrentRowNumber = ManageLADsCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("ManageLADsFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ManageLADsRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STAFF_IDField:" & e.Item.ItemIndex, DataItem.STAFF_IDField.Value)
            formState.Add("idField:" & e.Item.ItemIndex, DataItem.idField.Value)
            ViewState(e.Item.FindControl("ManageLADsFIRSTNAME").UniqueID) = DataItem.FIRSTNAME.Value
            ViewState(e.Item.FindControl("ManageLADsSURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("ManageLADslblLastUpdated").UniqueID) = DataItem.lblLastUpdated.Value
            ViewState(e.Item.FindControl("ManageLADslblStaffID").UniqueID) = DataItem.lblStaffID.Value
            Dim ManageLADsFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ManageLADsFIRSTNAME"),System.Web.UI.WebControls.Literal)
            Dim ManageLADsSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ManageLADsSURNAME"),System.Web.UI.WebControls.Literal)
            Dim ManageLADslblLastUpdated As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ManageLADslblLastUpdated"),System.Web.UI.WebControls.Literal)
            Dim ManageLADsLAD_MAX_ALLOC As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("ManageLADsLAD_MAX_ALLOC"),System.Web.UI.WebControls.TextBox)
            Dim ManageLADscheckDelete As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("ManageLADscheckDelete"),System.Web.UI.WebControls.CheckBox)
            Dim ManageLADslblStaffID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ManageLADslblStaffID"),System.Web.UI.WebControls.Literal)
            Dim ManageLADsradioYEAR_LEVEL As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("ManageLADsradioYEAR_LEVEL"),System.Web.UI.WebControls.RadioButtonList)
            CType(Page,CCPage).ControlAttributes.Add(ManageLADsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ManageLADsCurrentRowNumber), AttributeOption.Multiple)
            If DataItem.checkDeleteCheckedValue.Value.Equals(DataItem.checkDelete.Value) Then
                ManageLADscheckDelete.Checked = True
            End If
            DataItem.radioYEAR_LEVELItems.SetSelection(DataItem.radioYEAR_LEVEL.GetFormattedValue())
            ManageLADsradioYEAR_LEVEL.SelectedIndex = -1
            DataItem.radioYEAR_LEVELItems.CopyTo(ManageLADsradioYEAR_LEVEL.Items)
        End If
'End EditableGrid ManageLADs ItemDataBound event

'EditableGrid ManageLADs BeforeShowRow event @3-F98323FF
        If Not IsNothing(Item) Then ManageLADsDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid ManageLADs BeforeShowRow event

'EditableGrid ManageLADs BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid ManageLADs BeforeShowRow event tail

'EditableGrid ManageLADs ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid ManageLADs ItemDataBound event tail

'EditableGrid ManageLADs GetRedirectUrl method @3-5409B4AD
    Protected Function GetManageLADsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_LAdAllocation_maint.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetManageLADsRedirectUrl(ByVal redirectString As String) As String
        Return GetManageLADsRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid ManageLADs GetRedirectUrl method

'EditableGrid ManageLADs ShowErrors method @3-17505DAA
    Protected Function ManageLADsShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), ManageLADsItem).IsUpdated Then col(CType(items(i), ManageLADsItem).RowId).Visible = False
            If (CType(items(i), ManageLADsItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), ManageLADsItem).errors.Count - 1
                Select CType(items(i), ManageLADsItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), ManageLADsItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), ManageLADsItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), ManageLADsItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid ManageLADs ShowErrors method

'EditableGrid ManageLADs ItemCommand event @3-F5FF6488
    Protected Sub ManageLADsItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = ManageLADsRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid ManageLADs ItemCommand event

'Button buttonUpdate OnClick. @557-7A53C744
        If Ctype(e.CommandSource,Control).ID = "ManageLADsbuttonUpdate" Then
            RedirectUrl  = GetManageLADsRedirectUrl("", "")
            EnableValidation  = true
'End Button buttonUpdate OnClick.

'Button buttonUpdate OnClick tail. @557-477CF3C9
        End If
'End Button buttonUpdate OnClick tail.

'Button buttonCancel OnClick. @558-6F2CB1C1
        If Ctype(e.CommandSource,Control).ID = "ManageLADsbuttonCancel" Then
            RedirectUrl  = GetManageLADsRedirectUrl("", "")
            EnableValidation  = false
'End Button buttonCancel OnClick.

'Button buttonCancel OnClick tail. @558-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button buttonCancel OnClick tail.

'EditableGrid Form ManageLADs ItemCommand event tail @3-2D745B69
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("ManageLADsSortDir"), SortDirections) = SortDirections._Asc And ViewState("ManageLADsSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("ManageLADsSortDir") = SortDirections._Desc
                Else
                    ViewState("ManageLADsSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("ManageLADsSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As ManageLADsDataProvider.SortFields = 0
            ViewState("ManageLADsSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("ManageLADsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("ManageLADsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("ManageLADsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ManageLADsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            ManageLADsIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = ManageLADsRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("ManageLADsFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ManageLADsRowState"), Hashtable)
            ManageLADsParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim ManageLADsFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ManageLADsFIRSTNAME"),System.Web.UI.WebControls.Literal)
                    Dim ManageLADsSURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ManageLADsSURNAME"),System.Web.UI.WebControls.Literal)
                    Dim ManageLADslblLastUpdated As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ManageLADslblLastUpdated"),System.Web.UI.WebControls.Literal)
                    Dim ManageLADsLAD_MAX_ALLOC As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("ManageLADsLAD_MAX_ALLOC"),System.Web.UI.WebControls.TextBox)
                    Dim ManageLADscheckDelete As System.Web.UI.WebControls.CheckBox = DirectCast(col(i).FindControl("ManageLADscheckDelete"),System.Web.UI.WebControls.CheckBox)
                    Dim ManageLADslblStaffID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ManageLADslblStaffID"),System.Web.UI.WebControls.Literal)
                    Dim ManageLADsradioYEAR_LEVEL As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("ManageLADsradioYEAR_LEVEL"),System.Web.UI.WebControls.RadioButtonList)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As ManageLADsItem = New ManageLADsItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STAFF_IDField.Value = formState("STAFF_IDField:" & col(i).ItemIndex)
                    item.idField.Value = formState("idField:" & col(i).ItemIndex)
                    item.IsDeleted = (CType(col(i).FindControl("ManageLADscheckDelete"), System.Web.UI.WebControls.CheckBox)).Checked
                    item.FIRSTNAME.Value = ViewState(ManageLADsFIRSTNAME.UniqueID)
                    item.SURNAME.Value = ViewState(ManageLADsSURNAME.UniqueID)
                    item.lblLastUpdated.Value = ViewState(ManageLADslblLastUpdated.UniqueID)
                    item.lblStaffID.Value = ViewState(ManageLADslblStaffID.UniqueID)
                    Try
                    item.LAD_MAX_ALLOC.IsEmpty = IsNothing(Request.Form(ManageLADsLAD_MAX_ALLOC.UniqueID))
                    If ControlCustomValues("ManageLADsLAD_MAX_ALLOC") Is Nothing Then
                        item.LAD_MAX_ALLOC.SetValue(ManageLADsLAD_MAX_ALLOC.Text)
                    Else
                        item.LAD_MAX_ALLOC.SetValue(ControlCustomValues("ManageLADsLAD_MAX_ALLOC"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("LAD_MAX_ALLOC",String.Format(Resources.strings.CCS_IncorrectFormat,"Max. Students","0;(0)"))
                    End Try
                    item.radioYEAR_LEVEL.IsEmpty = IsNothing(Request.Form(ManageLADsradioYEAR_LEVEL.UniqueID))
                    If Not IsNothing(ManageLADsradioYEAR_LEVEL.SelectedItem) Then
                        item.radioYEAR_LEVEL.SetValue(ManageLADsradioYEAR_LEVEL.SelectedItem.Value)
                    Else
                        item.radioYEAR_LEVEL.Value = Nothing
                    End If
                    item.radioYEAR_LEVELItems.CopyFrom(ManageLADsradioYEAR_LEVEL.Items)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(ManageLADsData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form ManageLADs ItemCommand event tail

'EditableGrid ManageLADs Update @3-EDAE5F40
            If BindAllowed Then
                Try
                    ManageLADsParameters()
                    ManageLADsData.Update(items, ManageLADsOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(ManageLADsRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(ManageLADsRepeater.Controls(0).FindControl("ManageLADsError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
                Finally
'End EditableGrid ManageLADs Update

'EditableGrid ManageLADs Event AfterSubmit. Action Save Variable Value @555-7777DD0F
            HttpContext.Current.Session("notifymessage") = "Items have been Updated"
'End EditableGrid ManageLADs Event AfterSubmit. Action Save Variable Value

'EditableGrid ManageLADs After Update @3-01E463DB
                End Try
                If ManageLADsShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                ManageLADsShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                ManageLADsBind()
            End If
        End Sub
'End EditableGrid ManageLADs After Update

'Record Form SUBJECT_SUBJECT_TEACHER Parameters @40-FE3161A2

    Protected Sub SUBJECT_SUBJECT_TEACHERParameters()
        Dim item As new SUBJECT_SUBJECT_TEACHERItem
        Try
            SUBJECT_SUBJECT_TEACHERData.Ctrlmaxstudents = IntegerParameter.GetParam(item.maxstudents.Value, ParameterSourceType.Control, "", 14, false)
        Catch e As Exception
            SUBJECT_SUBJECT_TEACHERErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Parameters

'Record Form SUBJECT_SUBJECT_TEACHER Show method @40-9E7EE112
    Protected Sub SUBJECT_SUBJECT_TEACHERShow()
        If SUBJECT_SUBJECT_TEACHEROperations.None Then
            SUBJECT_SUBJECT_TEACHERHolder.Visible = False
            Return
        End If
        Dim item As SUBJECT_SUBJECT_TEACHERItem = SUBJECT_SUBJECT_TEACHERItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECT_SUBJECT_TEACHEROperations.AllowRead
        item.ClearParametersHref = "Staff_LAdAllocation_maint.aspx"
        SUBJECT_SUBJECT_TEACHERErrors.Add(item.errors)
        If SUBJECT_SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
            Return
        End If
'End Record Form SUBJECT_SUBJECT_TEACHER Show method

'Record Form SUBJECT_SUBJECT_TEACHER BeforeShow tail @40-BCE9AB9F
        SUBJECT_SUBJECT_TEACHERParameters()
        SUBJECT_SUBJECT_TEACHERData.FillItem(item, IsInsertMode)
        SUBJECT_SUBJECT_TEACHERHolder.DataBind()
        SUBJECT_SUBJECT_TEACHERButtonResetLAdsMax.Visible=Not (IsInsertMode) AndAlso SUBJECT_SUBJECT_TEACHEROperations.AllowDelete
        SUBJECT_SUBJECT_TEACHERClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        SUBJECT_SUBJECT_TEACHERClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword;rbShow", ViewState)
        SUBJECT_SUBJECT_TEACHERs_keyword.Text=item.s_keyword.GetFormattedValue()
        item.rbConfirmItems.SetSelection(item.rbConfirm.GetFormattedValue())
        SUBJECT_SUBJECT_TEACHERrbConfirm.SelectedIndex = -1
        item.rbConfirmItems.CopyTo(SUBJECT_SUBJECT_TEACHERrbConfirm.Items)
        SUBJECT_SUBJECT_TEACHERlblConfirmError.Text = Server.HtmlEncode(item.lblConfirmError.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.rbShowItems.SetSelection(item.rbShow.GetFormattedValue())
        SUBJECT_SUBJECT_TEACHERrbShow.SelectedIndex = -1
        item.rbShowItems.CopyTo(SUBJECT_SUBJECT_TEACHERrbShow.Items)
        SUBJECT_SUBJECT_TEACHERmaxstudents.Text=item.maxstudents.GetFormattedValue()
'End Record Form SUBJECT_SUBJECT_TEACHER BeforeShow tail

'Record Form SUBJECT_SUBJECT_TEACHER Show method tail @40-B38DBBBA
        If SUBJECT_SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        End If
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Show method tail

'Record Form SUBJECT_SUBJECT_TEACHER LoadItemFromRequest method @40-29730E23

    Protected Sub SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item As SUBJECT_SUBJECT_TEACHERItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERs_keyword.UniqueID))
        If ControlCustomValues("SUBJECT_SUBJECT_TEACHERs_keyword") Is Nothing Then
            item.s_keyword.SetValue(SUBJECT_SUBJECT_TEACHERs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("SUBJECT_SUBJECT_TEACHERs_keyword"))
        End If
        Try
        item.rbConfirm.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERrbConfirm.UniqueID))
        If Not IsNothing(SUBJECT_SUBJECT_TEACHERrbConfirm.SelectedItem) Then
            item.rbConfirm.SetValue(SUBJECT_SUBJECT_TEACHERrbConfirm.SelectedItem.Value)
        Else
            item.rbConfirm.Value = Nothing
        End If
        item.rbConfirmItems.CopyFrom(SUBJECT_SUBJECT_TEACHERrbConfirm.Items)
        Catch ae As ArgumentException
            SUBJECT_SUBJECT_TEACHERErrors.Add("rbConfirm",String.Format(Resources.strings.CCS_IncorrectValue,"Confirm Reset"))
        End Try
        Try
        item.rbShow.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERrbShow.UniqueID))
        If Not IsNothing(SUBJECT_SUBJECT_TEACHERrbShow.SelectedItem) Then
            item.rbShow.SetValue(SUBJECT_SUBJECT_TEACHERrbShow.SelectedItem.Value)
        Else
            item.rbShow.Value = Nothing
        End If
        item.rbShowItems.CopyFrom(SUBJECT_SUBJECT_TEACHERrbShow.Items)
        Catch ae As ArgumentException
            SUBJECT_SUBJECT_TEACHERErrors.Add("rbShow",String.Format(Resources.strings.CCS_IncorrectValue,"Search Show..."))
        End Try
        Try
        item.maxstudents.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERmaxstudents.UniqueID))
        If ControlCustomValues("SUBJECT_SUBJECT_TEACHERmaxstudents") Is Nothing Then
            item.maxstudents.SetValue(SUBJECT_SUBJECT_TEACHERmaxstudents.Text)
        Else
            item.maxstudents.SetValue(ControlCustomValues("SUBJECT_SUBJECT_TEACHERmaxstudents"))
        End If
        Catch ae As ArgumentException
            SUBJECT_SUBJECT_TEACHERErrors.Add("maxstudents",String.Format(Resources.strings.CCS_IncorrectValue,"Reset Max Students"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECT_SUBJECT_TEACHERData)
        End If
        SUBJECT_SUBJECT_TEACHERErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER LoadItemFromRequest method

'Record Form SUBJECT_SUBJECT_TEACHER GetRedirectUrl method @40-9FC58B29

    Protected Function GetSUBJECT_SUBJECT_TEACHERRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_LAdAllocation_maint.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECT_SUBJECT_TEACHER GetRedirectUrl method

'Record Form SUBJECT_SUBJECT_TEACHER ShowErrors method @40-3D779CB9

    Protected Sub SUBJECT_SUBJECT_TEACHERShowErrors()
        SUBJECT_SUBJECT_TEACHERlblConfirmError.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECT_SUBJECT_TEACHERErrors.Count - 1
        Select Case SUBJECT_SUBJECT_TEACHERErrors.AllKeys(i)
            Case "rbConfirm"
                If SUBJECT_SUBJECT_TEACHERlblConfirmError.Text <> "" Then  SUBJECT_SUBJECT_TEACHERlblConfirmError.Text &= "<br>"
                SUBJECT_SUBJECT_TEACHERlblConfirmError.Text = SUBJECT_SUBJECT_TEACHERlblConfirmError.Text & SUBJECT_SUBJECT_TEACHERErrors(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECT_SUBJECT_TEACHERErrors(i)
        End Select
        Next i
        SUBJECT_SUBJECT_TEACHERError.Visible = True
        SUBJECT_SUBJECT_TEACHERErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER ShowErrors method

'Record Form SUBJECT_SUBJECT_TEACHER Insert Operation @40-D66DA851

    Protected Sub SUBJECT_SUBJECT_TEACHER_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT_SUBJECT_TEACHER Insert Operation

'Record Form SUBJECT_SUBJECT_TEACHER BeforeInsert tail @40-8503135B
    SUBJECT_SUBJECT_TEACHERParameters()
    SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT_SUBJECT_TEACHER BeforeInsert tail

'Record Form SUBJECT_SUBJECT_TEACHER AfterInsert tail  @40-A90A4B84
        ErrorFlag=(SUBJECT_SUBJECT_TEACHERErrors.Count > 0)
        If ErrorFlag Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER AfterInsert tail 

'Record Form SUBJECT_SUBJECT_TEACHER Update Operation @40-D1FB9E39

    Protected Sub SUBJECT_SUBJECT_TEACHER_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT_SUBJECT_TEACHER Update Operation

'Record Form SUBJECT_SUBJECT_TEACHER Before Update tail @40-8503135B
        SUBJECT_SUBJECT_TEACHERParameters()
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT_SUBJECT_TEACHER Before Update tail

'Record Form SUBJECT_SUBJECT_TEACHER Update Operation tail @40-A90A4B84
        ErrorFlag=(SUBJECT_SUBJECT_TEACHERErrors.Count > 0)
        If ErrorFlag Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Update Operation tail

'Record Form SUBJECT_SUBJECT_TEACHER Delete Operation @40-9E0D9098
    Protected Sub SUBJECT_SUBJECT_TEACHER_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECT_SUBJECT_TEACHER Delete Operation

'Button ButtonResetLAdsMax OnClick. @120-3D40E5EA
        If CType(sender,Control).ID = "SUBJECT_SUBJECT_TEACHERButtonResetLAdsMax" Then
            RedirectUrl = GetSUBJECT_SUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = True
'End Button ButtonResetLAdsMax OnClick.

'Button ButtonResetLAdsMax OnClick tail. @120-477CF3C9
        End If
'End Button ButtonResetLAdsMax OnClick tail.

'Record Form BeforeDelete tail @40-C34CD361
        SUBJECT_SUBJECT_TEACHERParameters()
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
        If SUBJECT_SUBJECT_TEACHEROperations.AllowDelete Then
        ErrorFlag = (SUBJECT_SUBJECT_TEACHERErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SUBJECT_SUBJECT_TEACHERData.DeleteItem(item)
            Catch ex As Exception
                SUBJECT_SUBJECT_TEACHERErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record SUBJECT_SUBJECT_TEACHER Event AfterDelete. Action Save Variable Value @559-68F84031
        HttpContext.Current.Session("notifymessage") = "Boom! LAds reset!"
'End Record SUBJECT_SUBJECT_TEACHER Event AfterDelete. Action Save Variable Value

'Record Form AfterDelete tail @40-C89DA2D9
        End If
        If ErrorFlag Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECT_SUBJECT_TEACHER Cancel Operation @40-669D0601

    Protected Sub SUBJECT_SUBJECT_TEACHER_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, True)
'End Record Form SUBJECT_SUBJECT_TEACHER Cancel Operation

'Record Form SUBJECT_SUBJECT_TEACHER Cancel Operation tail @40-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Cancel Operation tail

'Record Form SUBJECT_SUBJECT_TEACHER Search Operation @40-A5E1FD74
    Protected Sub SUBJECT_SUBJECT_TEACHER_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT_SUBJECT_TEACHER Search Operation

'Button Button_DoSearch OnClick. @42-9702E9BA
        If CType(sender,Control).ID = "SUBJECT_SUBJECT_TEACHERButton_DoSearch" Then
            RedirectUrl = GetSUBJECT_SUBJECT_TEACHERRedirectUrl("", "s_keyword;rbConfirm;rbShow;maxstudents")
            EnableValidation  = False
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @42-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECT_SUBJECT_TEACHER Search Operation tail @40-257B28A6
        ErrorFlag = SUBJECT_SUBJECT_TEACHERErrors.Count > 0
        If ErrorFlag Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(SUBJECT_SUBJECT_TEACHERs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(SUBJECT_SUBJECT_TEACHERs_keyword.Text) & "&"), "")
            For Each li In SUBJECT_SUBJECT_TEACHERrbConfirm.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "rbConfirm=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In SUBJECT_SUBJECT_TEACHERrbShow.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "rbShow=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            Params = Params & IIf(SUBJECT_SUBJECT_TEACHERmaxstudents.Text <> "",("maxstudents=" & Server.UrlEncode(SUBJECT_SUBJECT_TEACHERmaxstudents.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Search Operation tail

'Record Form SUBJECT_TEACHER Parameters @93-4D604EF3

    Protected Sub SUBJECT_TEACHERParameters()
        Dim item As new SUBJECT_TEACHERItem
        Try
            SUBJECT_TEACHERData.CtrlSTAFF_ID = TextParameter.GetParam(item.STAFF_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHERData.Expr200 = TextParameter.GetParam(dbutility.userid.tostring.toupper, ParameterSourceType.Expression, "", "unknown", false)
            SUBJECT_TEACHERData.Expr201 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            SUBJECT_TEACHERData.CtrlLAD_MAX_ALLOC = IntegerParameter.GetParam(item.LAD_MAX_ALLOC.Value, ParameterSourceType.Control, "", 12, false)
            SUBJECT_TEACHERData.CtrlradioYEAR_LEVEL = IntegerParameter.GetParam(item.radioYEAR_LEVEL.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            SUBJECT_TEACHERErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECT_TEACHER Parameters

'Record Form SUBJECT_TEACHER Show method @93-348F9BEB
    Protected Sub SUBJECT_TEACHERShow()
        If SUBJECT_TEACHEROperations.None Then
            SUBJECT_TEACHERHolder.Visible = False
            Return
        End If
        Dim item As SUBJECT_TEACHERItem = SUBJECT_TEACHERItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECT_TEACHEROperations.AllowRead
        SUBJECT_TEACHERErrors.Add(item.errors)
        If SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_TEACHERShowErrors()
            Return
        End If
'End Record Form SUBJECT_TEACHER Show method

'Record Form SUBJECT_TEACHER BeforeShow tail @93-BFD45C80
        SUBJECT_TEACHERParameters()
        SUBJECT_TEACHERData.FillItem(item, IsInsertMode)
        SUBJECT_TEACHERHolder.DataBind()
        SUBJECT_TEACHERbuttonAdd.Visible=IsInsertMode AndAlso SUBJECT_TEACHEROperations.AllowInsert
        SUBJECT_TEACHERSTAFF_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECT_TEACHERSTAFF_ID.Items(0).Selected = True
        item.STAFF_IDItems.SetSelection(item.STAFF_ID.GetFormattedValue())
        If Not item.STAFF_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECT_TEACHERSTAFF_ID.SelectedIndex = -1
        End If
        item.STAFF_IDItems.CopyTo(SUBJECT_TEACHERSTAFF_ID.Items)
        SUBJECT_TEACHERLAD_MAX_ALLOC.Text=item.LAD_MAX_ALLOC.GetFormattedValue()
        item.radioYEAR_LEVELItems.SetSelection(item.radioYEAR_LEVEL.GetFormattedValue())
        SUBJECT_TEACHERradioYEAR_LEVEL.SelectedIndex = -1
        item.radioYEAR_LEVELItems.CopyTo(SUBJECT_TEACHERradioYEAR_LEVEL.Items)
'End Record Form SUBJECT_TEACHER BeforeShow tail

'DEL      ' -------------------------
'DEL      'ERA: make it nice and vertical
'DEL  	SUBJECT_TEACHERrbAllocatable.RepeatDirection = RepeatDirection.Vertical
'DEL      ' -------------------------


'Record Form SUBJECT_TEACHER Show method tail @93-5AA94184
        If SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_TEACHERShowErrors()
        End If
    End Sub
'End Record Form SUBJECT_TEACHER Show method tail

'Record Form SUBJECT_TEACHER LoadItemFromRequest method @93-C271588C

    Protected Sub SUBJECT_TEACHERLoadItemFromRequest(item As SUBJECT_TEACHERItem, ByVal EnableValidation As Boolean)
        item.STAFF_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSTAFF_ID.UniqueID))
        item.STAFF_ID.SetValue(SUBJECT_TEACHERSTAFF_ID.Value)
        item.STAFF_IDItems.CopyFrom(SUBJECT_TEACHERSTAFF_ID.Items)
        Try
        item.LAD_MAX_ALLOC.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERLAD_MAX_ALLOC.UniqueID))
        If ControlCustomValues("SUBJECT_TEACHERLAD_MAX_ALLOC") Is Nothing Then
            item.LAD_MAX_ALLOC.SetValue(SUBJECT_TEACHERLAD_MAX_ALLOC.Text)
        Else
            item.LAD_MAX_ALLOC.SetValue(ControlCustomValues("SUBJECT_TEACHERLAD_MAX_ALLOC"))
        End If
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("LAD_MAX_ALLOC",String.Format(Resources.strings.CCS_IncorrectFormat,"Max. Students","0;(0)"))
        End Try
        item.radioYEAR_LEVEL.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERradioYEAR_LEVEL.UniqueID))
        If Not IsNothing(SUBJECT_TEACHERradioYEAR_LEVEL.SelectedItem) Then
            item.radioYEAR_LEVEL.SetValue(SUBJECT_TEACHERradioYEAR_LEVEL.SelectedItem.Value)
        Else
            item.radioYEAR_LEVEL.Value = Nothing
        End If
        item.radioYEAR_LEVELItems.CopyFrom(SUBJECT_TEACHERradioYEAR_LEVEL.Items)
        If EnableValidation Then
            item.Validate(SUBJECT_TEACHERData)
        End If
        SUBJECT_TEACHERErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECT_TEACHER LoadItemFromRequest method

'Record Form SUBJECT_TEACHER GetRedirectUrl method @93-42D195AD

    Protected Function GetSUBJECT_TEACHERRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_LAdAllocation_maint.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECT_TEACHER GetRedirectUrl method

'Record Form SUBJECT_TEACHER ShowErrors method @93-327DA2C7

    Protected Sub SUBJECT_TEACHERShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECT_TEACHERErrors.Count - 1
        Select Case SUBJECT_TEACHERErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECT_TEACHERErrors(i)
        End Select
        Next i
        SUBJECT_TEACHERError.Visible = True
        SUBJECT_TEACHERErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECT_TEACHER ShowErrors method

'Record Form SUBJECT_TEACHER Insert Operation @93-E94EB255

    Protected Sub SUBJECT_TEACHER_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        Dim ExecuteFlag As Boolean = True
        SUBJECT_TEACHERIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT_TEACHER Insert Operation

'Button buttonAdd OnClick. @500-78C3683F
        If CType(sender,Control).ID = "SUBJECT_TEACHERbuttonAdd" Then
            RedirectUrl = GetSUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = True
'End Button buttonAdd OnClick.

'Button buttonAdd OnClick tail. @500-477CF3C9
        End If
'End Button buttonAdd OnClick tail.

'Record Form SUBJECT_TEACHER BeforeInsert tail @93-7F5A70DD
    SUBJECT_TEACHERParameters()
    SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
    If SUBJECT_TEACHEROperations.AllowInsert Then
        ErrorFlag=(SUBJECT_TEACHERErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SUBJECT_TEACHERData.InsertItem(item)
            Catch ex As Exception
                SUBJECT_TEACHERErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SUBJECT_TEACHER BeforeInsert tail



'DEL      ' -------------------------
'DEL       		' 28-Apr-2016|EA| catch error if Primary Key conflict, and then update the existing
'DEL  			    ' record to 'Yes' to assume that's what the user wanted. (unfuddle #755)
'DEL  			    ' (using Same method as in Subject_CourseDev_maint)
'DEL  			    'If ErrorFlag and Not IsNothing(ex) Then
'DEL  			    	If ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.STAFF_LAD_ALLOCATION'") Then
'DEL  				    	' so update the teacher for the staffid and subjectid
'DEL  				      	Dim NewDaoUpdate As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL  				    	Dim Sql As String = "UPDATE STAFF_LAD_ALLOCATION SET LAST_ALTERED_DATE=getdate(), LAST_ALTERED_BY="& NewDaoUpdate.ToSql(dbutility.userid.tostring.toupper,FieldType._Text)  & _
'DEL  				    		" , LAD_MAX_ALLOC = "& NewDaoUpdate.ToSql(item.LAD_MAX_ALLOC.Value,FieldType._Integer) & _
'DEL  				  			" WHERE STAFF_ID = "& NewDaoUpdate.ToSql(item.STAFF_ID.Value,FieldType._Text)
'DEL  				  		NewDaoUpdate.RunSql(Sql)
'DEL  				  		ErrorFlag=False
'DEL  				  		SUBJECT_TEACHERErrors.Clear
'DEL  			    	End If
'DEL  			    'End If
'DEL  		' reposition the End Try and End if from Try-Catch to get access to exception
'DEL              End Try
'DEL          End If
'DEL      ' -------------------------


'Record SUBJECT_TEACHER Event AfterInsert. Action Save Variable Value @556-A7EBABD6
        HttpContext.Current.Session("notifymessage") = "Item has been Added"
'End Record SUBJECT_TEACHER Event AfterInsert. Action Save Variable Value

'Record Form SUBJECT_TEACHER AfterInsert tail  @93-04930E68
        End If
        ErrorFlag=(SUBJECT_TEACHERErrors.Count > 0)
        If ErrorFlag Then
            SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT_TEACHER AfterInsert tail 

'Record Form SUBJECT_TEACHER Update Operation @93-54FAC146

    Protected Sub SUBJECT_TEACHER_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT_TEACHER Update Operation

'Record Form SUBJECT_TEACHER Before Update tail @93-42F056F8
        SUBJECT_TEACHERParameters()
        SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT_TEACHER Before Update tail

'Record Form SUBJECT_TEACHER Update Operation tail @93-F8688CBB
        ErrorFlag=(SUBJECT_TEACHERErrors.Count > 0)
        If ErrorFlag Then
            SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT_TEACHER Update Operation tail

'Record Form SUBJECT_TEACHER Delete Operation @93-64955001
    Protected Sub SUBJECT_TEACHER_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECT_TEACHER Delete Operation

'Record Form BeforeDelete tail @93-42F056F8
        SUBJECT_TEACHERParameters()
        SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @93-82BEEBC7
        If ErrorFlag Then
            SUBJECT_TEACHERShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECT_TEACHER Cancel Operation @93-D4CD7743

    Protected Sub SUBJECT_TEACHER_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECT_TEACHERLoadItemFromRequest(item, True)
'End Record Form SUBJECT_TEACHER Cancel Operation

'Record Form SUBJECT_TEACHER Cancel Operation tail @93-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECT_TEACHER Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-F663CE58
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_LAdAllocation_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ManageLADsData = New ManageLADsDataProvider()
        ManageLADsOperations = New FormSupportedOperations(False, True, False, True, True)
        SUBJECT_SUBJECT_TEACHERData = New SUBJECT_SUBJECT_TEACHERDataProvider()
        SUBJECT_SUBJECT_TEACHEROperations = New FormSupportedOperations(False, True, False, False, True)
        SUBJECT_TEACHERData = New SUBJECT_TEACHERDataProvider()
        SUBJECT_TEACHEROperations = New FormSupportedOperations(False, False, True, False, False)
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

