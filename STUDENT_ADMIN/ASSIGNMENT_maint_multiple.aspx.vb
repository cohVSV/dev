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

Namespace DECV_PROD2007.ASSIGNMENT_maint_multiple 'Namespace @1-93FAB6B3

'Forms Definition @1-B65EC778
Public Class [ASSIGNMENT_maint_multiplePage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C3DD3FCE
    Protected ASSIGNMENTData As ASSIGNMENTDataProvider
    Protected ASSIGNMENTCurrentRowNumber As Integer
    Protected ASSIGNMENTIsSubmitted As Boolean = False
    Protected ASSIGNMENTErrors As New NameValueCollection()
    Protected ASSIGNMENTOperations As FormSupportedOperations
    Protected ASSIGNMENTDataItem As ASSIGNMENTItem
    Protected ASSIGNMENTSearchData As ASSIGNMENTSearchDataProvider
    Protected ASSIGNMENTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected ASSIGNMENTSearchOperations As FormSupportedOperations
    Protected ASSIGNMENTSearchIsSubmitted As Boolean = False
    Protected ASSIGNMENT_maint_multipleContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-1F5044EB
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            ASSIGNMENTBind()
            ASSIGNMENTSearchShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid ASSIGNMENT Bind @3-E375EF55
    Protected Sub ASSIGNMENTBind()
        If ASSIGNMENTOperations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ASSIGNMENT",GetType(ASSIGNMENTDataProvider.SortFields), 50, 100)
        End If
'End EditableGrid ASSIGNMENT Bind

'EditableGrid Form ASSIGNMENT BeforeShow tail @3-D18E2C87
        ASSIGNMENTParameters()
        ASSIGNMENTData.SortField = CType(ViewState("ASSIGNMENTSortField"), ASSIGNMENTDataProvider.SortFields)
        ASSIGNMENTData.SortDir = CType(ViewState("ASSIGNMENTSortDir"), SortDirections)
        ASSIGNMENTData.PageNumber = CType(ViewState("ASSIGNMENTPageNumber"), Integer)
        ASSIGNMENTData.RecordsPerPage = CType(ViewState("ASSIGNMENTPageSize"), Integer)
        ASSIGNMENTRepeater.DataSource = ASSIGNMENTData.GetResultSet(PagesCount, ASSIGNMENTOperations)
        ViewState("ASSIGNMENTPagesCount") = PagesCount
        ViewState("ASSIGNMENTFormState") = New Hashtable()
        ViewState("ASSIGNMENTRowState") = New Hashtable()
        ASSIGNMENTRepeater.DataBind()
        Dim item As ASSIGNMENTItem = ASSIGNMENTDataItem
        If IsNothing(item) Then item = New ASSIGNMENTItem()
        FooterIndex = ASSIGNMENTRepeater.Controls.Count - 1
        Dim ASSIGNMENTASSIGNMENT_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTASSIGNMENT_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_ASSIGNMENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {50,100,250}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim ASSIGNMENTButton_Submit As System.Web.UI.WebControls.Button = DirectCast(ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("ASSIGNMENTButton_Submit"),System.Web.UI.WebControls.Button)
        Dim ASSIGNMENTCancel As System.Web.UI.WebControls.Button = DirectCast(ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("ASSIGNMENTCancel"),System.Web.UI.WebControls.Button)
        Dim Sorter_SpecialTypeSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("Sorter_SpecialTypeSorter"),DECV_PROD2007.Controls.Sorter)


        ASSIGNMENTASSIGNMENT_TotalRecords.Text = Server.HtmlEncode(item.ASSIGNMENT_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENTButton_Submit.Visible = ASSIGNMENTOperations.Editable
        If Not CType(ASSIGNMENTRepeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If ASSIGNMENTErrors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTError"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In ASSIGNMENTErrors
                ErrorLabel.Text += ASSIGNMENTErrors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form ASSIGNMENT BeforeShow tail

'Label ASSIGNMENT_TotalRecords Event BeforeShow. Action Retrieve number of records @15-A359E2AD
            ASSIGNMENTASSIGNMENT_TotalRecords.Text = ASSIGNMENTData.RecordCount.ToString()
'End Label ASSIGNMENT_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component @107-7D0311F2
        If true Then
            ASSIGNMENTRepeater.Visible = False
        End If
'End EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component

'EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component @105-0063B894
        Dim Urls_SUBJECT_ID_105_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID"))
        Dim ExprParam2_105_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(Urls_SUBJECT_ID_105_1, ExprParam2_105_2) Then
            ASSIGNMENTRepeater.Visible = True
        End If
'End EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component

'EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component @108-9AC6B0BF
        Dim Urls_DESCRIPTION_108_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_DESCRIPTION"))
        Dim ExprParam2_108_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(Urls_DESCRIPTION_108_1, ExprParam2_108_2) Then
            ASSIGNMENTRepeater.Visible = True
        End If
'End EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component

'EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component @140-6270C3C7
        Dim Urls_SUBJECT_ID_list_140_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID_list"))
        Dim ExprParam2_140_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(Urls_SUBJECT_ID_list_140_1, ExprParam2_140_2) Then
            ASSIGNMENTRepeater.Visible = True
        End If
'End EditableGrid ASSIGNMENT Event BeforeShow. Action Hide-Show Component

'EditableGrid ASSIGNMENT Bind tail @3-CAC7E306
        ASSIGNMENTShowErrors(New ArrayList(CType(ASSIGNMENTRepeater.DataSource, ICollection)), ASSIGNMENTRepeater.Items)
    End Sub
'End EditableGrid ASSIGNMENT Bind tail

'EditableGrid ASSIGNMENT Table Parameters @3-C4D2224C
    Protected Sub ASSIGNMENTParameters()
        Try
        Dim item As new ASSIGNMENTItem
            ASSIGNMENTData.Urls_SUBJECT_ID = IntegerParameter.GetParam("s_SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENTData.Urls_SUBJECT_ID_list = IntegerParameter.GetParam("s_SUBJECT_ID_list", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENTData.Urls_DESCRIPTION = TextParameter.GetParam("s_DESCRIPTION", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENTData.CtrlDESCRIPTION = TextParameter.GetParam(item.DESCRIPTION.Value, ParameterSourceType.Control, "", Nothing, false)
            ASSIGNMENTData.CtrlSTATUS = BooleanParameter.GetParam(item.STATUS.Value, ParameterSourceType.Control, Settings.BoolFormat, Nothing, false)
            ASSIGNMENTData.Expr65 = TextParameter.GetParam(DBUtility.UserID.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
            ASSIGNMENTData.Expr66 = TextParameter.GetParam(Now(), ParameterSourceType.Expression, "", Nothing, false)
            ASSIGNMENTData.CtrlRadioButtonSpecialType = TextParameter.GetParam(item.RadioButtonSpecialType.Value, ParameterSourceType.Control, "", "", false)
        Catch
            Dim ParentControls As ControlCollection = ASSIGNMENTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(ASSIGNMENTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid ASSIGNMENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid ASSIGNMENT Table Parameters

'EditableGrid ASSIGNMENT ItemDataBound event @3-20C404A5
    Protected Sub ASSIGNMENTItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As ASSIGNMENTItem = DirectCast(e.Item.DataItem, ASSIGNMENTItem)
        Dim Item as ASSIGNMENTItem = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ASSIGNMENTCurrentRowNumber = ASSIGNMENTCurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("ASSIGNMENTFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ASSIGNMENTRowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("ASSIGNMENT_IDField:" & e.Item.ItemIndex, DataItem.ASSIGNMENT_IDField.Value)
            formState.Add("SUBJECT_IDField:" & e.Item.ItemIndex, DataItem.SUBJECT_IDField.Value)
            ViewState(e.Item.FindControl("ASSIGNMENTSUBJECT_ID").UniqueID) = DataItem.SUBJECT_ID.Value
            ViewState(e.Item.FindControl("ASSIGNMENTASSIGNMENT_ID").UniqueID) = DataItem.ASSIGNMENT_ID.Value
            ViewState(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_DATE").UniqueID) = DataItem.LAST_ALTERED_DATE.Value
            ViewState(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_BY").UniqueID) = DataItem.LAST_ALTERED_BY.Value
            Dim ASSIGNMENTSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTSUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTDESCRIPTION As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("ASSIGNMENTDESCRIPTION"),System.Web.UI.WebControls.TextBox)
            Dim ASSIGNMENTSTATUS As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("ASSIGNMENTSTATUS"),System.Web.UI.WebControls.RadioButtonList)
            Dim ASSIGNMENTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTHidden_LAST_ALTERED_BY As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("ASSIGNMENTHidden_LAST_ALTERED_BY"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim ASSIGNMENTHidden_LAST_ALTERED_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("ASSIGNMENTHidden_LAST_ALTERED_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim ASSIGNMENTRadioButtonSpecialType As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("ASSIGNMENTRadioButtonSpecialType"),System.Web.UI.WebControls.RadioButtonList)
            CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ASSIGNMENTCurrentRowNumber), AttributeOption.Multiple)
            DataItem.STATUSItems.SetSelection(DataItem.STATUS.GetFormattedValue())
            ASSIGNMENTSTATUS.SelectedIndex = -1
            DataItem.STATUSItems.CopyTo(ASSIGNMENTSTATUS.Items, True)
            DataItem.RadioButtonSpecialTypeItems.SetSelection(DataItem.RadioButtonSpecialType.GetFormattedValue())
            ASSIGNMENTRadioButtonSpecialType.SelectedIndex = -1
            DataItem.RadioButtonSpecialTypeItems.CopyTo(ASSIGNMENTRadioButtonSpecialType.Items, True)
        End If
'End EditableGrid ASSIGNMENT ItemDataBound event

'ASSIGNMENT control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End ASSIGNMENT control Before Show

'Get Control @124-0D8B92E7
            Dim ASSIGNMENTRadioButtonSpecialType As System.Web.UI.WebControls.RadioButtonList = DirectCast(e.Item.FindControl("ASSIGNMENTRadioButtonSpecialType"),System.Web.UI.WebControls.RadioButtonList)
'End Get Control

'RadioButton RadioButtonSpecialType Event BeforeShow. Action Custom Code @125-73254650
    ' -------------------------
    'ASSIGNMENTRadioButtonSpecialType.RepeatColumns = 2
    ASSIGNMENTRadioButtonSpecialType.RepeatDirection = RepeatDirection.Horizontal
	'ASSIGNMENTRadioButtonSpecialType.RepeatLayout = RepeatLayout.Table
    ' -------------------------
'End RadioButton RadioButtonSpecialType Event BeforeShow. Action Custom Code

'ASSIGNMENT control Before Show tail @3-477CF3C9
        End If
'End ASSIGNMENT control Before Show tail

'EditableGrid ASSIGNMENT BeforeShowRow event @3-E73717D3
        If Not IsNothing(Item) Then ASSIGNMENTDataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid ASSIGNMENT BeforeShowRow event

'EditableGrid ASSIGNMENT BeforeShowRow event tail @3-477CF3C9
        End If
'End EditableGrid ASSIGNMENT BeforeShowRow event tail

'EditableGrid ASSIGNMENT ItemDataBound event tail @3-E31F8E2A
    End Sub
'End EditableGrid ASSIGNMENT ItemDataBound event tail

'EditableGrid ASSIGNMENT GetRedirectUrl method @3-E62674B2
    Protected Function GetASSIGNMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
    Protected Function GetASSIGNMENTRedirectUrl(ByVal redirectString As String) As String
        Return GetASSIGNMENTRedirectUrl(redirectString ,"")
    End Function
'End EditableGrid ASSIGNMENT GetRedirectUrl method

'EditableGrid ASSIGNMENT ShowErrors method @3-B49667E1
    Protected Function ASSIGNMENTShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), ASSIGNMENTItem).IsUpdated Then col(CType(items(i), ASSIGNMENTItem).RowId).Visible = False
            If (CType(items(i), ASSIGNMENTItem).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), ASSIGNMENTItem).errors.Count - 1
                Select CType(items(i), ASSIGNMENTItem).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), ASSIGNMENTItem).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), ASSIGNMENTItem).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), ASSIGNMENTItem).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid ASSIGNMENT ShowErrors method

'EditableGrid ASSIGNMENT ItemCommand event @3-DFBF2BEC
    Protected Sub ASSIGNMENTItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = ASSIGNMENTRepeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid ASSIGNMENT ItemCommand event

'Button Button_Submit OnClick. @34-A7C0C80E
        If Ctype(e.CommandSource,Control).ID = "ASSIGNMENTButton_Submit" Then
            RedirectUrl  = GetASSIGNMENTRedirectUrl("", "")
            EnableValidation  = true
'End Button Button_Submit OnClick.

'Button Button_Submit OnClick tail. @34-477CF3C9
        End If
'End Button Button_Submit OnClick tail.

'Button Cancel OnClick. @36-A6C2123A
        If Ctype(e.CommandSource,Control).ID = "ASSIGNMENTCancel" Then
            RedirectUrl  = GetASSIGNMENTRedirectUrl("", "")
            EnableValidation  = false
'End Button Cancel OnClick.

'Button Cancel OnClick tail. @36-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Cancel OnClick tail.

'EditableGrid Form ASSIGNMENT ItemCommand event tail @3-8048EB69
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("ASSIGNMENTSortDir"), SortDirections) = SortDirections._Asc And ViewState("ASSIGNMENTSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("ASSIGNMENTSortDir") = SortDirections._Desc
                Else
                    ViewState("ASSIGNMENTSortDir") = SortDirections._Asc
                End If
            Else
                ViewState("ASSIGNMENTSortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As ASSIGNMENTDataProvider.SortFields = 0
            ViewState("ASSIGNMENTSortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("ASSIGNMENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("ASSIGNMENTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("ASSIGNMENTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ASSIGNMENTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            ASSIGNMENTIsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = ASSIGNMENTRepeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("ASSIGNMENTFormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("ASSIGNMENTRowState"), Hashtable)
            ASSIGNMENTParameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim ASSIGNMENTSUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENTSUBJECT_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENTASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENTASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENTDESCRIPTION As System.Web.UI.WebControls.TextBox = DirectCast(col(i).FindControl("ASSIGNMENTDESCRIPTION"),System.Web.UI.WebControls.TextBox)
                    Dim ASSIGNMENTSTATUS As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("ASSIGNMENTSTATUS"),System.Web.UI.WebControls.RadioButtonList)
                    Dim ASSIGNMENTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("ASSIGNMENTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
                    Dim ASSIGNMENTHidden_LAST_ALTERED_BY As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("ASSIGNMENTHidden_LAST_ALTERED_BY"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim ASSIGNMENTHidden_LAST_ALTERED_DATE As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("ASSIGNMENTHidden_LAST_ALTERED_DATE"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim ASSIGNMENTRadioButtonSpecialType As System.Web.UI.WebControls.RadioButtonList = DirectCast(col(i).FindControl("ASSIGNMENTRadioButtonSpecialType"),System.Web.UI.WebControls.RadioButtonList)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As ASSIGNMENTItem = New ASSIGNMENTItem()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.ASSIGNMENT_IDField.Value = formState("ASSIGNMENT_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_IDField.Value = formState("SUBJECT_IDField:" & col(i).ItemIndex)
                    item.SUBJECT_ID.Value = ViewState(ASSIGNMENTSUBJECT_ID.UniqueID)
                    item.ASSIGNMENT_ID.Value = ViewState(ASSIGNMENTASSIGNMENT_ID.UniqueID)
                    item.LAST_ALTERED_DATE.Value = ViewState(ASSIGNMENTLAST_ALTERED_DATE.UniqueID)
                    item.LAST_ALTERED_BY.Value = ViewState(ASSIGNMENTLAST_ALTERED_BY.UniqueID)
                    item.DESCRIPTION.IsEmpty = IsNothing(Request.Form(ASSIGNMENTDESCRIPTION.UniqueID))
                    If ControlCustomValues("ASSIGNMENTDESCRIPTION") Is Nothing Then
                        item.DESCRIPTION.SetValue(ASSIGNMENTDESCRIPTION.Text)
                    Else
                        item.DESCRIPTION.SetValue(ControlCustomValues("ASSIGNMENTDESCRIPTION"))
                    End If
                    Try
                    item.STATUS.IsEmpty = IsNothing(Request.Form(ASSIGNMENTSTATUS.UniqueID))
                    If Not IsNothing(ASSIGNMENTSTATUS.SelectedItem) Then
                        item.STATUS.SetValue(ASSIGNMENTSTATUS.SelectedItem.Value)
                    Else
                        item.STATUS.Value = Nothing
                    End If
                    item.STATUSItems.CopyFrom(ASSIGNMENTSTATUS.Items)
                    Catch ex As ArgumentException
                    item.errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
                    End Try
                    item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(ASSIGNMENTHidden_LAST_ALTERED_BY.UniqueID))
                    item.Hidden_LAST_ALTERED_BY.SetValue(ASSIGNMENTHidden_LAST_ALTERED_BY.Value)
                    item.Hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENTHidden_LAST_ALTERED_DATE.UniqueID))
                    item.Hidden_LAST_ALTERED_DATE.SetValue(ASSIGNMENTHidden_LAST_ALTERED_DATE.Value)
                    item.RadioButtonSpecialType.IsEmpty = IsNothing(Request.Form(ASSIGNMENTRadioButtonSpecialType.UniqueID))
                    If Not IsNothing(ASSIGNMENTRadioButtonSpecialType.SelectedItem) Then
                        item.RadioButtonSpecialType.SetValue(ASSIGNMENTRadioButtonSpecialType.SelectedItem.Value)
                    Else
                        item.RadioButtonSpecialType.Value = Nothing
                    End If
                    item.RadioButtonSpecialTypeItems.CopyFrom(ASSIGNMENTRadioButtonSpecialType.Items)
                    items.Add(item)

                    If EnableValidation AndAlso Not item.IsEmptyItem And Not item.IsDeleted Then
                        BindAllowed = item.Validate(ASSIGNMENTData) And BindAllowed
                    End If
                End If
            Next i
'End EditableGrid Form ASSIGNMENT ItemCommand event tail

'EditableGrid ASSIGNMENT Update @3-A7AB5495
            If BindAllowed Then
                Try
                    ASSIGNMENTParameters()
                    ASSIGNMENTData.Update(items, ASSIGNMENTOperations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(ASSIGNMENTRepeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTError"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid ASSIGNMENT Update

'EditableGrid ASSIGNMENT After Update @3-0B5D39DD
                End Try
                If ASSIGNMENTShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                ASSIGNMENTShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                ASSIGNMENTBind()
            End If
        End Sub
'End EditableGrid ASSIGNMENT After Update

'Record Form ASSIGNMENTSearch Parameters @37-6BAADD0B

    Protected Sub ASSIGNMENTSearchParameters()
        Dim item As new ASSIGNMENTSearchItem
        Try
        Catch e As Exception
            ASSIGNMENTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ASSIGNMENTSearch Parameters

'Record Form ASSIGNMENTSearch Show method @37-D3C119BB
    Protected Sub ASSIGNMENTSearchShow()
        If ASSIGNMENTSearchOperations.None Then
            ASSIGNMENTSearchHolder.Visible = False
            Return
        End If
        Dim item As ASSIGNMENTSearchItem = ASSIGNMENTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ASSIGNMENTSearchOperations.AllowRead
        ASSIGNMENTSearchErrors.Add(item.errors)
        If ASSIGNMENTSearchErrors.Count > 0 Then
            ASSIGNMENTSearchShowErrors()
            Return
        End If
'End Record Form ASSIGNMENTSearch Show method

'Record Form ASSIGNMENTSearch BeforeShow tail @37-208D7D2F
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchData.FillItem(item, IsInsertMode)
        ASSIGNMENTSearchHolder.DataBind()
        ASSIGNMENTSearchs_SUBJECT_ID.Text=item.s_SUBJECT_ID.GetFormattedValue()
        ASSIGNMENTSearchs_DESCRIPTION.Text=item.s_DESCRIPTION.GetFormattedValue()
        ASSIGNMENTSearchs_SUBJECT_ID_list.Items.Add(new ListItem("Select Value",""))
        ASSIGNMENTSearchs_SUBJECT_ID_list.Items(0).Selected = True
        item.s_SUBJECT_ID_listItems.SetSelection(item.s_SUBJECT_ID_list.GetFormattedValue())
        If Not item.s_SUBJECT_ID_listItems.GetSelectedItem() Is Nothing Then
            ASSIGNMENTSearchs_SUBJECT_ID_list.SelectedIndex = -1
        End If
        item.s_SUBJECT_ID_listItems.CopyTo(ASSIGNMENTSearchs_SUBJECT_ID_list.Items)
'End Record Form ASSIGNMENTSearch BeforeShow tail

'Record Form ASSIGNMENTSearch Show method tail @37-0CEBD826
        If ASSIGNMENTSearchErrors.Count > 0 Then
            ASSIGNMENTSearchShowErrors()
        End If
    End Sub
'End Record Form ASSIGNMENTSearch Show method tail

'Record Form ASSIGNMENTSearch LoadItemFromRequest method @37-ACDE1B3E

    Protected Sub ASSIGNMENTSearchLoadItemFromRequest(item As ASSIGNMENTSearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENTSearchs_SUBJECT_ID.UniqueID))
        If ControlCustomValues("ASSIGNMENTSearchs_SUBJECT_ID") Is Nothing Then
            item.s_SUBJECT_ID.SetValue(ASSIGNMENTSearchs_SUBJECT_ID.Text)
        Else
            item.s_SUBJECT_ID.SetValue(ControlCustomValues("ASSIGNMENTSearchs_SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            ASSIGNMENTSearchErrors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
        End Try
        item.s_DESCRIPTION.IsEmpty = IsNothing(Request.Form(ASSIGNMENTSearchs_DESCRIPTION.UniqueID))
        If ControlCustomValues("ASSIGNMENTSearchs_DESCRIPTION") Is Nothing Then
            item.s_DESCRIPTION.SetValue(ASSIGNMENTSearchs_DESCRIPTION.Text)
        Else
            item.s_DESCRIPTION.SetValue(ControlCustomValues("ASSIGNMENTSearchs_DESCRIPTION"))
        End If
        Try
        item.s_SUBJECT_ID_list.IsEmpty = IsNothing(Request.Form(ASSIGNMENTSearchs_SUBJECT_ID_list.UniqueID))
        item.s_SUBJECT_ID_list.SetValue(ASSIGNMENTSearchs_SUBJECT_ID_list.Value)
        item.s_SUBJECT_ID_listItems.CopyFrom(ASSIGNMENTSearchs_SUBJECT_ID_list.Items)
        Catch ae As ArgumentException
            ASSIGNMENTSearchErrors.Add("s_SUBJECT_ID_list",String.Format(Resources.strings.CCS_IncorrectValue,"Subject"))
        End Try
        If EnableValidation Then
            item.Validate(ASSIGNMENTSearchData)
        End If
        ASSIGNMENTSearchErrors.Add(item.errors)
    End Sub
'End Record Form ASSIGNMENTSearch LoadItemFromRequest method

'Record Form ASSIGNMENTSearch GetRedirectUrl method @37-AEFA8BC2

    Protected Function GetASSIGNMENTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "ASSIGNMENT_maint_multiple.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ASSIGNMENTSearch GetRedirectUrl method

'Record Form ASSIGNMENTSearch ShowErrors method @37-0B228DF4

    Protected Sub ASSIGNMENTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ASSIGNMENTSearchErrors.Count - 1
        Select Case ASSIGNMENTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ASSIGNMENTSearchErrors(i)
        End Select
        Next i
        ASSIGNMENTSearchError.Visible = True
        ASSIGNMENTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ASSIGNMENTSearch ShowErrors method

'Record Form ASSIGNMENTSearch Insert Operation @37-1589C885

    Protected Sub ASSIGNMENTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENTSearch Insert Operation

'Record Form ASSIGNMENTSearch BeforeInsert tail @37-A64950C7
    ASSIGNMENTSearchParameters()
    ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch BeforeInsert tail

'Record Form ASSIGNMENTSearch AfterInsert tail  @37-C5746470
        ErrorFlag=(ASSIGNMENTSearchErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENTSearch AfterInsert tail 

'Record Form ASSIGNMENTSearch Update Operation @37-019318B4

    Protected Sub ASSIGNMENTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENTSearch Update Operation

'Record Form ASSIGNMENTSearch Before Update tail @37-A64950C7
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch Before Update tail

'Record Form ASSIGNMENTSearch Update Operation tail @37-C5746470
        ErrorFlag=(ASSIGNMENTSearchErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENTSearch Update Operation tail

'Record Form ASSIGNMENTSearch Delete Operation @37-3815AB8A
    Protected Sub ASSIGNMENTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ASSIGNMENTSearch Delete Operation

'Record Form BeforeDelete tail @37-A64950C7
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @37-C750D8B6
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ASSIGNMENTSearch Cancel Operation @37-38BA0E91

    Protected Sub ASSIGNMENTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        ASSIGNMENTSearchLoadItemFromRequest(item, True)
'End Record Form ASSIGNMENTSearch Cancel Operation

'Record Form ASSIGNMENTSearch Cancel Operation tail @37-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ASSIGNMENTSearch Cancel Operation tail

'Record Form ASSIGNMENTSearch Search Operation @37-6C57EEC8
    Protected Sub ASSIGNMENTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        ASSIGNMENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch Search Operation

'Button Button_DoSearch OnClick. @38-6B1286FA
        If CType(sender,Control).ID = "ASSIGNMENTSearchButton_DoSearch" Then
            RedirectUrl = GetASSIGNMENTSearchRedirectUrl("", "s_SUBJECT_ID;s_DESCRIPTION;s_SUBJECT_ID_list")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @38-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form ASSIGNMENTSearch Search Operation tail @37-7A1C5664
        ErrorFlag = ASSIGNMENTSearchErrors.Count > 0
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(ASSIGNMENTSearchs_SUBJECT_ID.Text <> "",("s_SUBJECT_ID=" & Server.UrlEncode(ASSIGNMENTSearchs_SUBJECT_ID.Text) & "&"), "")
            Params = Params & IIf(ASSIGNMENTSearchs_DESCRIPTION.Text <> "",("s_DESCRIPTION=" & Server.UrlEncode(ASSIGNMENTSearchs_DESCRIPTION.Text) & "&"), "")
            For Each li In ASSIGNMENTSearchs_SUBJECT_ID_list.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_SUBJECT_ID_list=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form ASSIGNMENTSearch Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-85F6B923
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ASSIGNMENT_maint_multipleContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ASSIGNMENTData = New ASSIGNMENTDataProvider()
        ASSIGNMENTOperations = New FormSupportedOperations(False, True, False, True, False)
        ASSIGNMENTSearchData = New ASSIGNMENTSearchDataProvider()
        ASSIGNMENTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(DBUtility.AuthorizeUser(New String(){"4","6","7","9"})) Then
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

