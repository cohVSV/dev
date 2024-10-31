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

Namespace DECV_PROD2007.Subject_CourseDev_maint 'Namespace @1-8A0210C7

'Forms Definition @1-5B0484AB
Public Class [Subject_CourseDev_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-3B64C015
    Protected SUBJECT_TEACHER_SUBJECT_SData As SUBJECT_TEACHER_SUBJECT_SDataProvider
    Protected SUBJECT_TEACHER_SUBJECT_SCurrentRowNumber As Integer
    Protected SUBJECT_TEACHER_SUBJECT_SIsSubmitted As Boolean = False
    Protected SUBJECT_TEACHER_SUBJECT_SErrors As New NameValueCollection()
    Protected SUBJECT_TEACHER_SUBJECT_SOperations As FormSupportedOperations
    Protected SUBJECT_TEACHER_SUBJECT_SDataItem As SUBJECT_TEACHER_SUBJECT_SItem
    Protected SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1Name As String
    Protected SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1DateControl As String
    Protected SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWName As String
    Protected SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWDateControl As String
    Protected SUBJECT_SUBJECT_TEACHERData As SUBJECT_SUBJECT_TEACHERDataProvider
    Protected SUBJECT_SUBJECT_TEACHERErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECT_SUBJECT_TEACHEROperations As FormSupportedOperations
    Protected SUBJECT_SUBJECT_TEACHERIsSubmitted As Boolean = False
    Protected SUBJECT_TEACHERData As SUBJECT_TEACHERDataProvider
    Protected SUBJECT_TEACHERErrors As NameValueCollection = New NameValueCollection()
    Protected SUBJECT_TEACHEROperations As FormSupportedOperations
    Protected SUBJECT_TEACHERIsSubmitted As Boolean = False
    Protected SUBJECT_TEACHERDatePicker_StartDateName As String
    Protected SUBJECT_TEACHERDatePicker_StartDateDateControl As String
    Protected SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEName As String
    Protected SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEDateControl As String
    Protected Subject_CourseDev_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-8E922297
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SUBJECT_TEACHER_SUBJECT_SBind()
            SUBJECT_SUBJECT_TEACHERShow()
            SUBJECT_TEACHERShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Bind @3-9A49928A
    Protected Sub SUBJECT_TEACHER_SUBJECT_SBind()
        If SUBJECT_TEACHER_SUBJECT_SOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT_TEACHER_SUBJECT_S",GetType(SUBJECT_TEACHER_SUBJECT_SDataProvider.SortFields), 80, 100)
        End If
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Bind

'EditableGrid Form SUBJECT_TEACHER_SUBJECT_S BeforeShow tail @3-0D534324
        SUBJECT_TEACHER_SUBJECT_SParameters()
        SUBJECT_TEACHER_SUBJECT_SData.SortField = CType(ViewState("SUBJECT_TEACHER_SUBJECT_SSortField"), SUBJECT_TEACHER_SUBJECT_SDataProvider.SortFields)
        SUBJECT_TEACHER_SUBJECT_SData.SortDir = CType(ViewState("SUBJECT_TEACHER_SUBJECT_SSortDir"), SortDirections)
        SUBJECT_TEACHER_SUBJECT_SData.PageNumber = CType(ViewState("SUBJECT_TEACHER_SUBJECT_SPageNumber"), Integer)
        SUBJECT_TEACHER_SUBJECT_SData.RecordsPerPage = CType(ViewState("SUBJECT_TEACHER_SUBJECT_SPageSize"), Integer)
        SUBJECT_TEACHER_SUBJECT_SRepeater.DataSource = SUBJECT_TEACHER_SUBJECT_SData.GetResultSet(PagesCount, SUBJECT_TEACHER_SUBJECT_SOperations)
        ViewState("SUBJECT_TEACHER_SUBJECT_SPagesCount") = PagesCount
        ViewState("SUBJECT_TEACHER_SUBJECT_SFormState") = New Hashtable()
        ViewState("SUBJECT_TEACHER_SUBJECT_SRowState") = New Hashtable()
        SUBJECT_TEACHER_SUBJECT_SRepeater.DataBind()
        Dim item As SUBJECT_TEACHER_SUBJECT_SItem = SUBJECT_TEACHER_SUBJECT_SDataItem
        If IsNothing(item) Then item = New SUBJECT_TEACHER_SUBJECT_SItem()
        FooterIndex = SUBJECT_TEACHER_SUBJECT_SRepeater.Controls.Count - 1
        Dim Sorter_SUBJECT_ABBREVSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("Sorter_SUBJECT_ABBREVSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCAFFOLD_COURSEDEV_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("Sorter_SCAFFOLD_COURSEDEV_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("Sorter_SCAFFOLD_COURSEDEV_UPDATEDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Navigator1Navigator As DECV_PROD2007.Controls.Navigator = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(FooterIndex).FindControl("Navigator1Navigator"),DECV_PROD2007.Controls.Navigator)
        Navigator1Navigator.PageSizes = new Integer() {80,250,500}
        If PagesCount < 2 Then Navigator1Navigator.Visible = False
        Dim SUBJECT_TEACHER_SUBJECT_SButtonUpdate As System.Web.UI.WebControls.Button = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHER_SUBJECT_SButtonUpdate"),System.Web.UI.WebControls.Button)
        Dim SUBJECT_TEACHER_SUBJECT_SButtonCancel As System.Web.UI.WebControls.Button = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(FooterIndex).FindControl("SUBJECT_TEACHER_SUBJECT_SButtonCancel"),System.Web.UI.WebControls.Button)
        Dim SUBJECT_TEACHER_SUBJECT_STotalRecords As System.Web.UI.WebControls.Literal = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("SUBJECT_TEACHER_SUBJECT_STotalRecords"),System.Web.UI.WebControls.Literal)


        SUBJECT_TEACHER_SUBJECT_STotalRecords.Text = Server.HtmlEncode(item.TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        SUBJECT_TEACHER_SUBJECT_SButtonUpdate.Visible = SUBJECT_TEACHER_SUBJECT_SOperations.Editable
        If Not CType(SUBJECT_TEACHER_SUBJECT_SRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If SUBJECT_TEACHER_SUBJECT_SErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("SUBJECT_TEACHER_SUBJECT_SError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In SUBJECT_TEACHER_SUBJECT_SErrors
                ErrorLabel.Text += SUBJECT_TEACHER_SUBJECT_SErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form SUBJECT_TEACHER_SUBJECT_S BeforeShow tail

'Label TotalRecords Event BeforeShow. Action Retrieve number of records @199-26CA9613
            SUBJECT_TEACHER_SUBJECT_STotalRecords.Text = SUBJECT_TEACHER_SUBJECT_SData.RecordCount.ToString()
'End Label TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Bind tail @3-949CE3A2
        SUBJECT_TEACHER_SUBJECT_SShowErrors(New ArrayList(CType(SUBJECT_TEACHER_SUBJECT_SRepeater.DataSource, ICollection)), SUBJECT_TEACHER_SUBJECT_SRepeater.Items)
    End Sub
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Bind tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Table Parameters @3-6EF60629
    Protected Sub SUBJECT_TEACHER_SUBJECT_SParameters()
        Try
        Dim item As new SUBJECT_TEACHER_SUBJECT_SItem
            SUBJECT_TEACHER_SUBJECT_SData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.Urls_SUBJECT_ID = IntegerParameter.GetParam("s_SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSCAFFOLD_COURSEDEV_FLAG = IntegerParameter.GetParam(item.SCAFFOLD_COURSEDEV_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSCAFFOLD_COURSEDEV_UPDATED = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_UPDATED.Value, ParameterSourceType.Control, Settings.DateFormat, Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSUBJECT_TEACHER_STAFF_ID = TextParameter.GetParam(item.SUBJECT_TEACHER_STAFF_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSUBJECT_TEACHER_SUBJECT_ID = IntegerParameter.GetParam(item.SUBJECT_TEACHER_SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSCAFFOLD_COURSEDEV_STARTDATE = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_STARTDATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSCAFFOLD_COURSEDEV_ENDDATE = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_ENDDATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.Expr328 = TextParameter.GetParam(dbutility.userid.tostring.toupper, ParameterSourceType.Expression, "", Nothing, false)
            SUBJECT_TEACHER_SUBJECT_SData.CtrlSCAFFOLD_COURSEDEV_MODIFIER = TextParameter.GetParam(item.SCAFFOLD_COURSEDEV_MODIFIER.Value, ParameterSourceType.Control, "", "", false)
        Catch
            Dim ParentControls As ControlCollection = SUBJECT_TEACHER_SUBJECT_SRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(SUBJECT_TEACHER_SUBJECT_SRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid SUBJECT_TEACHER_SUBJECT_S: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Table Parameters

'EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemDataBound event @3-9EF6E3D0
    Protected Sub SUBJECT_TEACHER_SUBJECT_SItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As SUBJECT_TEACHER_SUBJECT_SItem = DirectCast(e.Item.DataItem, SUBJECT_TEACHER_SUBJECT_SItem)
        Dim Item as SUBJECT_TEACHER_SUBJECT_SItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECT_TEACHER_SUBJECT_SCurrentRowNumber = SUBJECT_TEACHER_SUBJECT_SCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHER_SUBJECT_SFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHER_SUBJECT_SRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("STAFF_IDField:" & e.Item.ItemIndex, DataItem.STAFF_IDField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV").UniqueID) = DataItem.SUBJECT_ABBREV.Value
            ViewState(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE").UniqueID) = DataItem.SUBJECT_TITLE.Value
            ViewState(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SFIRSTNAME").UniqueID) = DataItem.FIRSTNAME.Value
            ViewState(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated").UniqueID) = DataItem.lblScaffoldLastUpdated.Value
            Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHER_SUBJECT_SFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SFIRSTNAME"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG"),System.Web.UI.WebControls.RadioButtonList)
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim SUBJECT_TEACHER_SUBJECT_SSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSURNAME"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated"),System.Web.UI.WebControls.Literal)
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER"),System.Web.UI.WebControls.TextBox)
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE"),System.Web.UI.WebControls.TextBox)
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE"),System.Web.UI.WebControls.TextBox)
            Dim SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1"),System.Web.UI.WebControls.PlaceHolder)
            Dim SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW"),System.Web.UI.WebControls.PlaceHolder)
            CType(Page,CCPage).ControlAttributes.Add(SUBJECT_TEACHER_SUBJECT_SRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECT_TEACHER_SUBJECT_SCurrentRowNumber), AttributeOption.Multiple)
            DataItem.SCAFFOLD_COURSEDEV_FLAGItems.SetSelection(DataItem.SCAFFOLD_COURSEDEV_FLAG.GetFormattedValue())
            SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.SelectedIndex = -1
            DataItem.SCAFFOLD_COURSEDEV_FLAGItems.CopyTo(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.Items, True)
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1Name = "SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1"
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1DateControl = e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE").ClientID
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1.DataBind()
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWName = "SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW"
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATWDateControl = e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE").ClientID
            SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW.DataBind()
        End If
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemDataBound event

'SUBJECT_TEACHER_SUBJECT_S control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End SUBJECT_TEACHER_SUBJECT_S control Before Show

'Get Control @36-52E19B2F
            Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED"),System.Web.UI.HtmlControls.HtmlInputHidden)
'End Get Control

'Hidden SCAFFOLD_COURSEDEV_UPDATED Event BeforeShow. Action Retrieve Value for Control @44-F6800B93
            SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Hidden SCAFFOLD_COURSEDEV_UPDATED Event BeforeShow. Action Retrieve Value for Control

'SUBJECT_TEACHER_SUBJECT_S control Before Show tail @3-477CF3C9
        End If
'End SUBJECT_TEACHER_SUBJECT_S control Before Show tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeShowRow event @3-D185B17D
        If Not IsNothing(Item) Then SUBJECT_TEACHER_SUBJECT_SDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeShowRow event

'EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeShowRow event tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemDataBound event tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S GetRedirectUrl method @3-F09ED779
    Protected Function GetSUBJECT_TEACHER_SUBJECT_SRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetSUBJECT_TEACHER_SUBJECT_SRedirectUrl(ByVal redirectString As String) As String
        Return GetSUBJECT_TEACHER_SUBJECT_SRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S GetRedirectUrl method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S ShowErrors method @3-596A183D
    Protected Function SUBJECT_TEACHER_SUBJECT_SShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).IsUpdated Then col(CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).RowId).Visible = False
            If (CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).errors.Count - 1
                Select CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), SUBJECT_TEACHER_SUBJECT_SItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S ShowErrors method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemCommand event @3-12C113B5
    Protected Sub SUBJECT_TEACHER_SUBJECT_SItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = SUBJECT_TEACHER_SUBJECT_SRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S ItemCommand event

'Button ButtonUpdate OnClick. @114-2DC145A8
        If Ctype(e.CommandSource,Control).ID = "SUBJECT_TEACHER_SUBJECT_SButtonUpdate" Then
            RedirectUrl  = GetSUBJECT_TEACHER_SUBJECT_SRedirectUrl("", "")
            EnableValidation  = true
'End Button ButtonUpdate OnClick.

'Button ButtonUpdate OnClick tail. @114-477CF3C9
        End If
'End Button ButtonUpdate OnClick tail.

'Button ButtonCancel OnClick. @115-216C42EB
        If Ctype(e.CommandSource,Control).ID = "SUBJECT_TEACHER_SUBJECT_SButtonCancel" Then
            RedirectUrl  = GetSUBJECT_TEACHER_SUBJECT_SRedirectUrl("", "")
            EnableValidation  = false
'End Button ButtonCancel OnClick.

'Button ButtonCancel OnClick tail. @115-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button ButtonCancel OnClick tail.

'EditableGrid Form SUBJECT_TEACHER_SUBJECT_S ItemCommand event tail @3-C829A266
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("SUBJECT_TEACHER_SUBJECT_SSortDir"), SortDirections) = SortDirections._Asc And ViewState("SUBJECT_TEACHER_SUBJECT_SSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("SUBJECT_TEACHER_SUBJECT_SSortDir") = SortDirections._Desc
                Else
                    ViewState("SUBJECT_TEACHER_SUBJECT_SSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("SUBJECT_TEACHER_SUBJECT_SSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As SUBJECT_TEACHER_SUBJECT_SDataProvider.SortFields = 0
            ViewState("SUBJECT_TEACHER_SUBJECT_SSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("SUBJECT_TEACHER_SUBJECT_SPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("SUBJECT_TEACHER_SUBJECT_SPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("SUBJECT_TEACHER_SUBJECT_SPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECT_TEACHER_SUBJECT_SPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            SUBJECT_TEACHER_SUBJECT_SIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = SUBJECT_TEACHER_SUBJECT_SRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHER_SUBJECT_SFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("SUBJECT_TEACHER_SUBJECT_SRowState"), Hashtable)
            SUBJECT_TEACHER_SUBJECT_SParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHER_SUBJECT_SFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SFIRSTNAME"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG"),System.Web.UI.WebControls.RadioButtonList)
                    Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim SUBJECT_TEACHER_SUBJECT_SSURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSURNAME"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated"),System.Web.UI.WebControls.Literal)
                    Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER"),System.Web.UI.WebControls.TextBox)
                    Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE"),System.Web.UI.WebControls.TextBox)
                    Dim SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE"),System.Web.UI.WebControls.TextBox)
                    Dim SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1 As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_STARTDATE1"),System.Web.UI.WebControls.PlaceHolder)
                    Dim SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW As System.Web.UI.WebControls.PlaceHolder = DirectCast(col(i).FindControl("SUBJECT_TEACHER_SUBJECT_SDatePicker_SCAFFOLD_COURSEDEV_ENDDATW"),System.Web.UI.WebControls.PlaceHolder)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As SUBJECT_TEACHER_SUBJECT_SItem = New SUBJECT_TEACHER_SUBJECT_SItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.STAFF_IDField.Value = formState("STAFF_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_ABBREV.Value = ViewState(SUBJECT_TEACHER_SUBJECT_SSUBJECT_ABBREV.UniqueID)
                    item.SUBJECT_TITLE.Value = ViewState(SUBJECT_TEACHER_SUBJECT_SSUBJECT_TITLE.UniqueID)
                    item.FIRSTNAME.Value = ViewState(SUBJECT_TEACHER_SUBJECT_SFIRSTNAME.UniqueID)
                    item.SURNAME.Value = ViewState(SUBJECT_TEACHER_SUBJECT_SSURNAME.UniqueID)
                    item.lblScaffoldLastUpdated.Value = ViewState(SUBJECT_TEACHER_SUBJECT_SlblScaffoldLastUpdated.UniqueID)
                    Try
                    item.SCAFFOLD_COURSEDEV_FLAG.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.UniqueID))
                    If Not IsNothing(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.SelectedItem) Then
                        item.SCAFFOLD_COURSEDEV_FLAG.SetValue(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.SelectedItem.Value)
                    Else
                        item.SCAFFOLD_COURSEDEV_FLAG.Value = Nothing
                    End If
                    item.SCAFFOLD_COURSEDEV_FLAGItems.CopyFrom(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_FLAG.Items)
                    Catch ex As ArgumentException
                    item.errors.Add("SCAFFOLD_COURSEDEV_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"SCAFFOLD COURSE DEV?"))
                    End Try
                    Try
                    item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED.UniqueID))
                    item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_UPDATED.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("SCAFFOLD_COURSEDEV_UPDATED",String.Format(Resources.strings.CCS_IncorrectFormat,"SCAFFOLD COURSEDEV UPDATED","dd/mm/yyyy h:nn AM/PM"))
                    End Try
                    item.SUBJECT_TEACHER_STAFF_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID.UniqueID))
                    item.SUBJECT_TEACHER_STAFF_ID.SetValue(SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_STAFF_ID.Value)
                    Try
                    item.SUBJECT_TEACHER_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID.UniqueID))
                    item.SUBJECT_TEACHER_SUBJECT_ID.SetValue(SUBJECT_TEACHER_SUBJECT_SSUBJECT_TEACHER_SUBJECT_ID.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("SUBJECT_TEACHER_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT TEACHER SUBJECT ID"))
                    End Try
                    item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER.UniqueID))
                    If ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER") Is Nothing Then
                        item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER.Text)
                    Else
                        item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_MODIFIER"))
                    End If
                    Try
                    item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE.UniqueID))
                    If ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE") Is Nothing Then
                        item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE.Text)
                    Else
                        item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_STARTDATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("SCAFFOLD_COURSEDEV_STARTDATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Date From","d/m/yyyy"))
                    End Try
                    Try
                    item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE.UniqueID))
                    If ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE") Is Nothing Then
                        item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE.Text)
                    Else
                        item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(ControlCustomValues("SUBJECT_TEACHER_SUBJECT_SSCAFFOLD_COURSEDEV_ENDDATE"))
                    End If
                    Catch ex As ArgumentException
                    item.errors.Add("SCAFFOLD_COURSEDEV_ENDDATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Date To","d/m/yyyy"))
                    End Try
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(SUBJECT_TEACHER_SUBJECT_SData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form SUBJECT_TEACHER_SUBJECT_S ItemCommand event tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Update @3-53C06AD6
            If BindAllowed Then
                Try
                    SUBJECT_TEACHER_SUBJECT_SParameters()
                    SUBJECT_TEACHER_SUBJECT_SData.Update(items, SUBJECT_TEACHER_SUBJECT_SOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(SUBJECT_TEACHER_SUBJECT_SRepeater.Controls(0).FindControl("SUBJECT_TEACHER_SUBJECT_SError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Update

'EditableGrid SUBJECT_TEACHER_SUBJECT_S After Update @3-EB977FDB
                End Try
                If SUBJECT_TEACHER_SUBJECT_SShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                SUBJECT_TEACHER_SUBJECT_SShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                SUBJECT_TEACHER_SUBJECT_SBind()
            End If
        End Sub
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S After Update

'Record Form SUBJECT_SUBJECT_TEACHER Parameters @40-3F66F8B0

    Protected Sub SUBJECT_SUBJECT_TEACHERParameters()
        Dim item As new SUBJECT_SUBJECT_TEACHERItem
        Try
        Catch e As Exception
            SUBJECT_SUBJECT_TEACHERErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Parameters

'Record Form SUBJECT_SUBJECT_TEACHER Show method @40-4BAC87D3
    Protected Sub SUBJECT_SUBJECT_TEACHERShow()
        If SUBJECT_SUBJECT_TEACHEROperations.None Then
            SUBJECT_SUBJECT_TEACHERHolder.Visible = False
            Return
        End If
        Dim item As SUBJECT_SUBJECT_TEACHERItem = SUBJECT_SUBJECT_TEACHERItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECT_SUBJECT_TEACHEROperations.AllowRead
        item.ClearParametersHref = "Subject_CourseDev_maint.aspx"
        SUBJECT_SUBJECT_TEACHERErrors.Add(item.errors)
        If SUBJECT_SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
            Return
        End If
'End Record Form SUBJECT_SUBJECT_TEACHER Show method

'Record Form SUBJECT_SUBJECT_TEACHER BeforeShow tail @40-86EF8904
        SUBJECT_SUBJECT_TEACHERParameters()
        SUBJECT_SUBJECT_TEACHERData.FillItem(item, IsInsertMode)
        SUBJECT_SUBJECT_TEACHERHolder.DataBind()
        SUBJECT_SUBJECT_TEACHERButtonResetDevToTeachers.Visible=Not (IsInsertMode) AndAlso SUBJECT_SUBJECT_TEACHEROperations.AllowUpdate
        SUBJECT_SUBJECT_TEACHERButtonResetDevToNo.Visible=Not (IsInsertMode) AndAlso SUBJECT_SUBJECT_TEACHEROperations.AllowDelete
        SUBJECT_SUBJECT_TEACHERClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        SUBJECT_SUBJECT_TEACHERClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword;s_SUBJECT_ID", ViewState)
        SUBJECT_SUBJECT_TEACHERs_keyword.Text=item.s_keyword.GetFormattedValue()
        SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Items(0).Selected = True
        item.s_SUBJECT_IDItems.SetSelection(item.s_SUBJECT_ID.GetFormattedValue())
        If Not item.s_SUBJECT_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.SelectedIndex = -1
        End If
        item.s_SUBJECT_IDItems.CopyTo(SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Items)
'End Record Form SUBJECT_SUBJECT_TEACHER BeforeShow tail

'Record Form SUBJECT_SUBJECT_TEACHER Show method tail @40-B38DBBBA
        If SUBJECT_SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        End If
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER Show method tail

'Record Form SUBJECT_SUBJECT_TEACHER LoadItemFromRequest method @40-46B4557F

    Protected Sub SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item As SUBJECT_SUBJECT_TEACHERItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERs_keyword.UniqueID))
        If ControlCustomValues("SUBJECT_SUBJECT_TEACHERs_keyword") Is Nothing Then
            item.s_keyword.SetValue(SUBJECT_SUBJECT_TEACHERs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("SUBJECT_SUBJECT_TEACHERs_keyword"))
        End If
        Try
        item.s_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.UniqueID))
        item.s_SUBJECT_ID.SetValue(SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Value)
        item.s_SUBJECT_IDItems.CopyFrom(SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Items)
        Catch ae As ArgumentException
            SUBJECT_SUBJECT_TEACHERErrors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Subject"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECT_SUBJECT_TEACHERData)
        End If
        SUBJECT_SUBJECT_TEACHERErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECT_SUBJECT_TEACHER LoadItemFromRequest method

'Record Form SUBJECT_SUBJECT_TEACHER GetRedirectUrl method @40-2EEC9BB1

    Protected Function GetSUBJECT_SUBJECT_TEACHERRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Subject_CourseDev_maint.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECT_SUBJECT_TEACHER GetRedirectUrl method

'Record Form SUBJECT_SUBJECT_TEACHER ShowErrors method @40-B2BE0C3D

    Protected Sub SUBJECT_SUBJECT_TEACHERShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECT_SUBJECT_TEACHERErrors.Count - 1
        Select Case SUBJECT_SUBJECT_TEACHERErrors.AllKeys(i)
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

'Record Form SUBJECT_SUBJECT_TEACHER Update Operation @40-06382B33

    Protected Sub SUBJECT_SUBJECT_TEACHER_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT_SUBJECT_TEACHER Update Operation

'Button ButtonResetDevToTeachers OnClick. @121-FDEADBAE
        If CType(sender,Control).ID = "SUBJECT_SUBJECT_TEACHERButtonResetDevToTeachers" Then
            RedirectUrl = GetSUBJECT_SUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = False
'End Button ButtonResetDevToTeachers OnClick.

'Button ButtonResetDevToTeachers OnClick tail. @121-477CF3C9
        End If
'End Button ButtonResetDevToTeachers OnClick tail.

'Record Form SUBJECT_SUBJECT_TEACHER Before Update tail @40-D92C41A1
        SUBJECT_SUBJECT_TEACHERParameters()
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
        If SUBJECT_SUBJECT_TEACHEROperations.AllowUpdate Then
        ErrorFlag = (SUBJECT_SUBJECT_TEACHERErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                SUBJECT_SUBJECT_TEACHERData.UpdateItem(item)
            Catch ex As Exception
                SUBJECT_SUBJECT_TEACHERErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form SUBJECT_SUBJECT_TEACHER Before Update tail

'Record Form SUBJECT_SUBJECT_TEACHER Update Operation tail @40-54671CEE
        End If
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

'Button ButtonResetDevToNo OnClick. @120-5AF2A07A
        If CType(sender,Control).ID = "SUBJECT_SUBJECT_TEACHERButtonResetDevToNo" Then
            RedirectUrl = GetSUBJECT_SUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = False
'End Button ButtonResetDevToNo OnClick.

'Button ButtonResetDevToNo OnClick tail. @120-477CF3C9
        End If
'End Button ButtonResetDevToNo OnClick tail.

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

'Record Form SUBJECT_SUBJECT_TEACHER Search Operation @40-C55EF4B3
    Protected Sub SUBJECT_SUBJECT_TEACHER_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECT_SUBJECT_TEACHERIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        SUBJECT_SUBJECT_TEACHERLoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT_SUBJECT_TEACHER Search Operation

'Button Button_DoSearch OnClick. @42-B1ECBE8C
        If CType(sender,Control).ID = "SUBJECT_SUBJECT_TEACHERButton_DoSearch" Then
            RedirectUrl = GetSUBJECT_SUBJECT_TEACHERRedirectUrl("", "s_keyword;s_SUBJECT_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @42-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECT_SUBJECT_TEACHER Search Operation tail @40-1C8AA071
        ErrorFlag = SUBJECT_SUBJECT_TEACHERErrors.Count > 0
        If ErrorFlag Then
            SUBJECT_SUBJECT_TEACHERShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(SUBJECT_SUBJECT_TEACHERs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(SUBJECT_SUBJECT_TEACHERs_keyword.Text) & "&"), "")
            For Each li In SUBJECT_SUBJECT_TEACHERs_SUBJECT_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SUBJECT_ID=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form SUBJECT_SUBJECT_TEACHER Search Operation tail

'Record Form SUBJECT_TEACHER Parameters @93-FBF06044

    Protected Sub SUBJECT_TEACHERParameters()
        Dim item As new SUBJECT_TEACHERItem
        Try
            SUBJECT_TEACHERData.UrlSUBJECT_ID = TextParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            SUBJECT_TEACHERData.CtrlSUBJECT_ID = IntegerParameter.GetParam(item.SUBJECT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHERData.CtrlSTAFF_ID = TextParameter.GetParam(item.STAFF_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHERData.CtrlSCAFFOLD_COURSEDEV_FLAG = IntegerParameter.GetParam(item.SCAFFOLD_COURSEDEV_FLAG.Value, ParameterSourceType.Control, "", Nothing, false)
            SUBJECT_TEACHERData.CtrlSCAFFOLD_COURSEDEV_UPDATED = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_UPDATED.Value, ParameterSourceType.Control, Settings.DateFormat, Nothing, false)
            SUBJECT_TEACHERData.Expr200 = TextParameter.GetParam(dbutility.userid.tostring.toupper, ParameterSourceType.Expression, "", "unknown", false)
            SUBJECT_TEACHERData.Expr201 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            SUBJECT_TEACHERData.Expr202 = FloatParameter.GetParam("0.00", ParameterSourceType.Expression, "", Nothing, false)
            SUBJECT_TEACHERData.Expr203 = IntegerParameter.GetParam("0", ParameterSourceType.Expression, "", Nothing, false)
            SUBJECT_TEACHERData.CtrlSCAFFOLD_COURSEDEV_STARTDATE = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_STARTDATE.Value, ParameterSourceType.Control, "d\/M\/yyyy", Nothing, false)
            SUBJECT_TEACHERData.CtrlSCAFFOLD_COURSEDEV_ENDDATE = DateParameter.GetParam(item.SCAFFOLD_COURSEDEV_ENDDATE.Value, ParameterSourceType.Control, "d\/M\/yyyy", Nothing, false)
            SUBJECT_TEACHERData.CtrlSCAFFOLD_COURSEDEV_MODIFIER = TextParameter.GetParam(item.SCAFFOLD_COURSEDEV_MODIFIER.Value, ParameterSourceType.Control, "", Nothing, false)
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

'Record Form SUBJECT_TEACHER BeforeShow tail @93-8E5F27B6
        SUBJECT_TEACHERParameters()
        SUBJECT_TEACHERData.FillItem(item, IsInsertMode)
        SUBJECT_TEACHERHolder.DataBind()
        SUBJECT_TEACHERButtonInsert.Visible=IsInsertMode AndAlso SUBJECT_TEACHEROperations.AllowInsert
        SUBJECT_TEACHERSUBJECT_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECT_TEACHERSUBJECT_ID.Items(0).Selected = True
        item.SUBJECT_IDItems.SetSelection(item.SUBJECT_ID.GetFormattedValue())
        If Not item.SUBJECT_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECT_TEACHERSUBJECT_ID.SelectedIndex = -1
        End If
        item.SUBJECT_IDItems.CopyTo(SUBJECT_TEACHERSUBJECT_ID.Items)
        SUBJECT_TEACHERSTAFF_ID.Items.Add(new ListItem("Select Value",""))
        SUBJECT_TEACHERSTAFF_ID.Items(0).Selected = True
        item.STAFF_IDItems.SetSelection(item.STAFF_ID.GetFormattedValue())
        If Not item.STAFF_IDItems.GetSelectedItem() Is Nothing Then
            SUBJECT_TEACHERSTAFF_ID.SelectedIndex = -1
        End If
        item.STAFF_IDItems.CopyTo(SUBJECT_TEACHERSTAFF_ID.Items)
        SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED.Value = item.SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue()
        SUBJECT_TEACHERSCAFFOLD_COURSEDEV_FLAG.Value = item.SCAFFOLD_COURSEDEV_FLAG.GetFormattedValue()
        SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE.Text=item.SCAFFOLD_COURSEDEV_STARTDATE.GetFormattedValue()
        SUBJECT_TEACHERDatePicker_StartDateName = "SUBJECT_TEACHERDatePicker_StartDate"
        SUBJECT_TEACHERDatePicker_StartDateDateControl = SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE.ClientID
        SUBJECT_TEACHERDatePicker_StartDate.DataBind()
        SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER.Text=item.SCAFFOLD_COURSEDEV_MODIFIER.GetFormattedValue()
        SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE.Text=item.SCAFFOLD_COURSEDEV_ENDDATE.GetFormattedValue()
        SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEName = "SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE"
        SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATEDateControl = SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE.ClientID
        SUBJECT_TEACHERDatePicker_SCAFFOLD_COURSEDEV_ENDDATE.DataBind()
'End Record Form SUBJECT_TEACHER BeforeShow tail

'ListBox SUBJECT_ID Event BeforeShow. Action Retrieve Value for Control @95-6C320908
            SUBJECT_TEACHERSUBJECT_ID.Value = (New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID"))).GetFormattedValue()
'End ListBox SUBJECT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden SCAFFOLD_COURSEDEV_UPDATED Event BeforeShow. Action Retrieve Value for Control @221-9A405245
            SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Hidden SCAFFOLD_COURSEDEV_UPDATED Event BeforeShow. Action Retrieve Value for Control

'Record Form SUBJECT_TEACHER Show method tail @93-5AA94184
        If SUBJECT_TEACHERErrors.Count > 0 Then
            SUBJECT_TEACHERShowErrors()
        End If
    End Sub
'End Record Form SUBJECT_TEACHER Show method tail

'Record Form SUBJECT_TEACHER LoadItemFromRequest method @93-30ADB7A1

    Protected Sub SUBJECT_TEACHERLoadItemFromRequest(item As SUBJECT_TEACHERItem, ByVal EnableValidation As Boolean)
        Try
        item.SUBJECT_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSUBJECT_ID.UniqueID))
        item.SUBJECT_ID.SetValue(SUBJECT_TEACHERSUBJECT_ID.Value)
        item.SUBJECT_IDItems.CopyFrom(SUBJECT_TEACHERSUBJECT_ID.Items)
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
        End Try
        item.STAFF_ID.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSTAFF_ID.UniqueID))
        item.STAFF_ID.SetValue(SUBJECT_TEACHERSTAFF_ID.Value)
        item.STAFF_IDItems.CopyFrom(SUBJECT_TEACHERSTAFF_ID.Items)
        Try
        item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED.UniqueID))
        item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_UPDATED.Value)
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("SCAFFOLD_COURSEDEV_UPDATED",String.Format(Resources.strings.CCS_IncorrectFormat,"SCAFFOLD COURSEDEV UPDATED","dd/mm/yyyy h:nn AM/PM"))
        End Try
        Try
        item.SCAFFOLD_COURSEDEV_FLAG.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_FLAG.UniqueID))
        item.SCAFFOLD_COURSEDEV_FLAG.SetValue(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_FLAG.Value)
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("SCAFFOLD_COURSEDEV_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"SCAFFOLD COURSEDEV FLAG"))
        End Try
        Try
        item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE.UniqueID))
        If ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE") Is Nothing Then
            item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE.Text)
        Else
            item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_STARTDATE"))
        End If
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("SCAFFOLD_COURSEDEV_STARTDATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Date From","d/m/yyyy"))
        End Try
        item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER.UniqueID))
        If ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER") Is Nothing Then
            item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER.Text)
        Else
            item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_MODIFIER"))
        End If
        Try
        item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty = IsNothing(Request.Form(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE.UniqueID))
        If ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE") Is Nothing Then
            item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE.Text)
        Else
            item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(ControlCustomValues("SUBJECT_TEACHERSCAFFOLD_COURSEDEV_ENDDATE"))
        End If
        Catch ae As ArgumentException
            SUBJECT_TEACHERErrors.Add("SCAFFOLD_COURSEDEV_ENDDATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Date To","d/m/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(SUBJECT_TEACHERData)
        End If
        SUBJECT_TEACHERErrors.Add(item.errors)
    End Sub
'End Record Form SUBJECT_TEACHER LoadItemFromRequest method

'Record Form SUBJECT_TEACHER GetRedirectUrl method @93-239D9DF2

    Protected Function GetSUBJECT_TEACHERRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
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

'Button ButtonInsert OnClick. @111-4765BB89
        If CType(sender,Control).ID = "SUBJECT_TEACHERButtonInsert" Then
            RedirectUrl = GetSUBJECT_TEACHERRedirectUrl("", "")
            EnableValidation  = True
'End Button ButtonInsert OnClick.

'Button ButtonInsert OnClick tail. @111-477CF3C9
        End If
'End Button ButtonInsert OnClick tail.

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
 '           End Try
 '       End If
'End Record Form SUBJECT_TEACHER BeforeInsert tail

'Record SUBJECT_TEACHER Event AfterInsert. Action Custom Code @266-73254650
	    ' -------------------------
			    ' 21-Apr-2016|EA| catch error if Primary Key conflict, and then update the existing
			    ' record to 'Yes' to assume that's what the user wanted.
			    'If ErrorFlag and Not IsNothing(ex) Then
			    	If ex.Message.Contains("Violation of PRIMARY KEY constraint 'PK_SUBJECT_TEACHER'") Then
				    	' so update the teacher for the staffid and subjectid
				      	Dim NewDaoUpdate As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				    	Dim Sql As String = "UPDATE SUBJECT_TEACHER SET SCAFFOLD_COURSEDEV_FLAG=1, SCAFFOLD_COURSEDEV_UPDATED=getdate(), LAST_ALTERED_DATE=getdate(), LAST_ALTERED_BY="& NewDaoUpdate.ToSql(dbutility.userid.tostring.toupper,FieldType._Text)  & _
				  			" WHERE STAFF_ID = "& NewDaoUpdate.ToSql(item.STAFF_ID.Value,FieldType._Text) &" AND SUBJECT_ID="& NewDaoUpdate.ToSql(item.SUBJECT_ID.Value,FieldType._Integer)
				  		NewDaoUpdate.RunSql(Sql)
				  		ErrorFlag=False
				  		SUBJECT_TEACHERErrors.Clear
			    	End If
			    'End If
		' reposition the End Try and End if from Try-Catch to get access to exception
            End Try
        End If
    ' -------------------------
'End Record SUBJECT_TEACHER Event AfterInsert. Action Custom Code

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

'Record Form SUBJECT_TEACHER Cancel Operation @93-7F9923A0

    Protected Sub SUBJECT_TEACHER_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        SUBJECT_TEACHERIsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECT_TEACHERLoadItemFromRequest(item, False)
'End Record Form SUBJECT_TEACHER Cancel Operation

'Button ButtonCancel OnClick. @112-B2BF4AC3
    If CType(sender,Control).ID = "SUBJECT_TEACHERButtonCancel" Then
        RedirectUrl = GetSUBJECT_TEACHERRedirectUrl("", "")
'End Button ButtonCancel OnClick.

'Button ButtonCancel OnClick tail. @112-477CF3C9
    End If
'End Button ButtonCancel OnClick tail.

'Record Form SUBJECT_TEACHER Cancel Operation tail @93-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECT_TEACHER Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-E589967F
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Subject_CourseDev_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECT_TEACHER_SUBJECT_SData = New SUBJECT_TEACHER_SUBJECT_SDataProvider()
        SUBJECT_TEACHER_SUBJECT_SOperations = New FormSupportedOperations(False, True, False, True, False)
        SUBJECT_SUBJECT_TEACHERData = New SUBJECT_SUBJECT_TEACHERDataProvider()
        SUBJECT_SUBJECT_TEACHEROperations = New FormSupportedOperations(False, True, False, True, True)
        SUBJECT_TEACHERData = New SUBJECT_TEACHERDataProvider()
        SUBJECT_TEACHEROperations = New FormSupportedOperations(False, False, True, False, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
'End OnInit Event Body

'Page Subject_CourseDev_maint Event AfterInitialize. Action Custom Code @267-73254650
    ' -------------------------
    '5-May-2016|EA| specifically check for Security Function 'L' separately from Groups
    Dim GlobalERAFunc as new GlobalERA.GlobalERAClass()

    If Not(GlobalERAFunc.CheckUserAccessGroups("L", e)) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
    End If
    ' -------------------------
'End Page Subject_CourseDev_maint Event AfterInitialize. Action Custom Code

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

