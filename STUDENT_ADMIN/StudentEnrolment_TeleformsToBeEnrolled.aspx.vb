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

Namespace DECV_PROD2007.StudentEnrolment_TeleformsToBeEnrolled 'Namespace @1-1BF0C137

'Forms Definition @1-6D039294
Public Class [StudentEnrolment_TeleformsToBeEnrolledPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-DA83A225
    Protected NewEditableGrid1Data As NewEditableGrid1DataProvider
    Protected NewEditableGrid1CurrentRowNumber As Integer
    Protected NewEditableGrid1IsSubmitted As Boolean = False
    Protected NewEditableGrid1Errors As New NameValueCollection()
    Protected NewEditableGrid1Operations As FormSupportedOperations
    Protected NewEditableGrid1DataItem As NewEditableGrid1Item
    Protected TMP_STUDENTSearchData As TMP_STUDENTSearchDataProvider
    Protected TMP_STUDENTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected TMP_STUDENTSearchOperations As FormSupportedOperations
    Protected TMP_STUDENTSearchIsSubmitted As Boolean = False
    Protected StudentEnrolment_TeleformsToBeEnrolledContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-BCDB7D8F
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            NewEditableGrid1Bind()
            TMP_STUDENTSearchShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

'BeforeOutput Event @1-E563A382
Private Sub BeforeOutput(MainHTML As String, responseStream As Stream, ByRef Result As Boolean)
Result  = True
'End BeforeOutput Event

'UpdatePanel UpdatePanel PageBeforeOutput @4-372512B2
        If CType(HttpContext.Current.Items("UpdatePanel"),String) = "Panel1" Then
            Utility.WriteUpdatePanelContent(MainHTML, "Panel1")
            Result = False
        End If
'End UpdatePanel UpdatePanel PageBeforeOutput

'BeforeOutput Event tail @1-E31F8E2A
End Sub
'End BeforeOutput Event tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'EditableGrid NewEditableGrid1 Bind @5-F8DD1853
    Protected Sub NewEditableGrid1Bind()
        If NewEditableGrid1Operations.None Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"NewEditableGrid1",GetType(NewEditableGrid1DataProvider.SortFields), 40, 100)
        End If
'End EditableGrid NewEditableGrid1 Bind

'EditableGrid Form NewEditableGrid1 BeforeShow tail @5-0174A8BB
        NewEditableGrid1Parameters()
        NewEditableGrid1Data.SortField = CType(ViewState("NewEditableGrid1SortField"), NewEditableGrid1DataProvider.SortFields)
        NewEditableGrid1Data.SortDir = CType(ViewState("NewEditableGrid1SortDir"), SortDirections)
        NewEditableGrid1Data.PageNumber = CType(ViewState("NewEditableGrid1PageNumber"), Integer)
        NewEditableGrid1Data.RecordsPerPage = CType(ViewState("NewEditableGrid1PageSize"), Integer)
        NewEditableGrid1Repeater.DataSource = NewEditableGrid1Data.GetResultSet(PagesCount, NewEditableGrid1Operations)
        ViewState("NewEditableGrid1PagesCount") = PagesCount
        ViewState("NewEditableGrid1FormState") = New Hashtable()
        ViewState("NewEditableGrid1RowState") = New Hashtable()
        NewEditableGrid1Repeater.DataBind()
        Dim item As NewEditableGrid1Item = NewEditableGrid1DataItem
        If IsNothing(item) Then item = New NewEditableGrid1Item()
        FooterIndex = NewEditableGrid1Repeater.Controls.Count - 1
        Dim NewEditableGrid1NewEditableGrid1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(NewEditableGrid1Repeater.Controls(0).FindControl("NewEditableGrid1NewEditableGrid1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(NewEditableGrid1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False


        NewEditableGrid1NewEditableGrid1_TotalRecords.Text = Server.HtmlEncode(item.NewEditableGrid1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        If Not CType(NewEditableGrid1Repeater.DataSource,IEnumerable).GetEnumerator().MoveNext() Then
            NewEditableGrid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        If NewEditableGrid1Errors.Count > 0 Then
            Dim ErrorLabel As System.Web.UI.WebControls.Label = DirectCast(NewEditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"),System.Web.UI.WebControls.Label)
            Dim RowError As PlaceHolder = DirectCast(NewEditableGrid1Repeater.Controls(0).FindControl("NewEditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
            RowError.Visible = True
            Dim msg As String
            For Each msg In NewEditableGrid1Errors
                ErrorLabel.Text += NewEditableGrid1Errors(msg) + "<br/>"
            Next
        End If
'End EditableGrid Form NewEditableGrid1 BeforeShow tail

'Label NewEditableGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records @23-F1A7DCFD
            NewEditableGrid1NewEditableGrid1_TotalRecords.Text = NewEditableGrid1Data.RecordCount.ToString()
'End Label NewEditableGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records

'EditableGrid NewEditableGrid1 Bind tail @5-CF4D854F
        NewEditableGrid1ShowErrors(New ArrayList(CType(NewEditableGrid1Repeater.DataSource, ICollection)), NewEditableGrid1Repeater.Items)
    End Sub
'End EditableGrid NewEditableGrid1 Bind tail

'EditableGrid NewEditableGrid1 Table Parameters @5-512AAE5A
    Protected Sub NewEditableGrid1Parameters()
        Try
        Dim item As new NewEditableGrid1Item
            NewEditableGrid1Data.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
        Catch
            Dim ParentControls As ControlCollection = NewEditableGrid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer = ParentControls.IndexOf(NewEditableGrid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage As Literal = New Literal()
            ErrorMessage.Text = "Error in Grid NewEditableGrid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
	End Sub
	
'End EditableGrid NewEditableGrid1 Table Parameters

'EditableGrid NewEditableGrid1 ItemDataBound event @5-3E36D277
    Protected Sub NewEditableGrid1ItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
        Dim DataItem As NewEditableGrid1Item = DirectCast(e.Item.DataItem, NewEditableGrid1Item)
        Dim Item as NewEditableGrid1Item = DataItem
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            NewEditableGrid1CurrentRowNumber = NewEditableGrid1CurrentRowNumber + 1
            DataItem.RowId = e.Item.ItemIndex
            Dim formState As Hashtable = DirectCast(ViewState("NewEditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("NewEditableGrid1RowState"), Hashtable)
            rowState.Add(e.Item.ItemIndex, DataItem.IsNew)
            formState.Add("TMP_STUDENT_IDField:" & e.Item.ItemIndex, DataItem.TMP_STUDENT_IDField.Value)
            ViewState(e.Item.FindControl("NewEditableGrid1STUDENT_ID").UniqueID) = DataItem.STUDENT_ID.Value
            ViewState(e.Item.FindControl("NewEditableGrid1SURNAME").UniqueID) = DataItem.SURNAME.Value
            ViewState(e.Item.FindControl("NewEditableGrid1FIRST_NAME").UniqueID) = DataItem.FIRST_NAME.Value
            ViewState(e.Item.FindControl("NewEditableGrid1BIRTH_DATE").UniqueID) = DataItem.BIRTH_DATE.Value
            ViewState(e.Item.FindControl("NewEditableGrid1CATEGORY_CODE").UniqueID) = DataItem.CATEGORY_CODE.Value
            ViewState(e.Item.FindControl("NewEditableGrid1LAST_ALTERED_DATE").UniqueID) = DataItem.LAST_ALTERED_DATE.Value
            ViewState(e.Item.FindControl("NewEditableGrid1TELEFORM_STATUS").UniqueID) = DataItem.TELEFORM_STATUS.Value
            ViewState(e.Item.FindControl("NewEditableGrid1SUBCATEGORY_CODE").UniqueID) = DataItem.SUBCATEGORY_CODE.Value
            Dim NewEditableGrid1STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1STUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1BIRTH_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1BIRTH_DATE"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1CATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1CATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1TELEFORM_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1TELEFORM_STATUS"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1TMP_STUDENT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("NewEditableGrid1TMP_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim NewEditableGrid1SUBCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("NewEditableGrid1SUBCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim NewEditableGrid1Button1 As System.Web.UI.WebControls.Button = DirectCast(e.Item.FindControl("NewEditableGrid1Button1"),System.Web.UI.WebControls.Button)
            CType(Page,CCPage).ControlAttributes.Add(NewEditableGrid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, NewEditableGrid1CurrentRowNumber), AttributeOption.Multiple)
        End If
'End EditableGrid NewEditableGrid1 ItemDataBound event

'EditableGrid NewEditableGrid1 BeforeShowRow event @5-675B6A0A
        If Not IsNothing(Item) Then NewEditableGrid1DataItem = Item
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End EditableGrid NewEditableGrid1 BeforeShowRow event

'EditableGrid NewEditableGrid1 BeforeShowRow event tail @5-477CF3C9
        End If
'End EditableGrid NewEditableGrid1 BeforeShowRow event tail

'EditableGrid NewEditableGrid1 ItemDataBound event tail @5-E31F8E2A
    End Sub
'End EditableGrid NewEditableGrid1 ItemDataBound event tail

'EditableGrid NewEditableGrid1 GetRedirectUrl method @5-748A6004
    Protected Function GetNewEditableGrid1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        If Not IsNothing(HttpContext.Current.Items("UpdatePanel")) Then
            p += "&FormFilter=" & HttpContext.Current.Items("UpdatePanel")
            p = p.Replace("?&","?")
        End If
        Return redirect + p
    End Function
    Protected Function GetNewEditableGrid1RedirectUrl(ByVal redirectString As String) As String
        Return GetNewEditableGrid1RedirectUrl(redirectString ,"")
    End Function
'End EditableGrid NewEditableGrid1 GetRedirectUrl method

'EditableGrid NewEditableGrid1 ShowErrors method @5-C49F6F2B
    Protected Function NewEditableGrid1ShowErrors(ByVal items As ArrayList, ByVal col As RepeaterItemCollection) As Boolean
        Dim result As Boolean = True
        Dim i As Integer
        For i=0 To items.Count - 1
            If CType(items(i), NewEditableGrid1Item).IsUpdated Then col(CType(items(i), NewEditableGrid1Item).RowId).Visible = False
            If (CType(items(i), NewEditableGrid1Item).errors.Count > 0) Then
                result = False
                Dim DefaultMessage As String = ""
                Dim j As Integer
                For j = 0 To CType(items(i), NewEditableGrid1Item).errors.Count - 1
                Select CType(items(i), NewEditableGrid1Item).errors.AllKeys(j)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage &= CType(items(i), NewEditableGrid1Item).errors(j)
                End Select
                Next j
                Dim Err As System.Web.UI.WebControls.Label = CType(col(CType(items(i), NewEditableGrid1Item).RowId).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                col(CType(items(i), NewEditableGrid1Item).RowId).FindControl("RowError").Visible = True
                Err.Text = DefaultMessage
            End If
        Next i
        Return result
    End Function
'End EditableGrid NewEditableGrid1 ShowErrors method

'EditableGrid NewEditableGrid1 ItemCommand event @5-E496B00C
    Protected Sub NewEditableGrid1ItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
        Dim FooterIndex  As Integer = NewEditableGrid1Repeater.Controls.Count - 1
        Dim BindAllowed As Boolean = False
        Dim EnableValidation As Boolean = False
        Dim RedirectUrl As String = ""
'End EditableGrid NewEditableGrid1 ItemCommand event

'Button Button1 OnClick. @39-2DB780BE
        If Ctype(e.CommandSource,Control).ID = "NewEditableGrid1Button1" Then
            RedirectUrl  = GetNewEditableGrid1RedirectUrl("", "")
            EnableValidation  = true
'End Button Button1 OnClick.

'Button Button1 OnClick tail. @39-C5B109C5
            Response.Redirect(RedirectUrl)
        End If
'End Button Button1 OnClick tail.

'EditableGrid Form NewEditableGrid1 ItemCommand event tail @5-9D89E21F
        If e.CommandName= "Sort" Then
            If(CType(e.CommandArgument, SorterState) = SorterState.None) Then
                If(CType(ViewState("NewEditableGrid1SortDir"), SortDirections) = SortDirections._Asc And ViewState("NewEditableGrid1SortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field) Then
                    ViewState("NewEditableGrid1SortDir") = SortDirections._Desc
                Else
                    ViewState("NewEditableGrid1SortDir") = SortDirections._Asc
                End If
            Else
                ViewState("NewEditableGrid1SortDir") = CType((CType(e.CommandSource, Controls.Sorter).State), Integer)
            End If
            Dim sf As NewEditableGrid1DataProvider.SortFields = 0
            ViewState("NewEditableGrid1SortField") = [Enum].Parse(SF.GetType(),CType(e.CommandSource, Controls.Sorter).Field)
            ViewState("NewEditableGrid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName = "Navigate" Then
            ViewState("NewEditableGrid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If

        If e.CommandName = "ChangePageSize" Then
            ViewState("NewEditableGrid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("NewEditableGrid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If

        If (e.CommandName = "Submit") Then
            NewEditableGrid1IsSubmitted = True
            BindAllowed = True
            Dim col As RepeaterItemCollection = NewEditableGrid1Repeater.Items
            Dim items As ArrayList = New ArrayList()
            Dim formState As Hashtable = DirectCast(ViewState("NewEditableGrid1FormState"), Hashtable)
            Dim rowState As Hashtable = DirectCast(ViewState("NewEditableGrid1RowState"), Hashtable)
            NewEditableGrid1Parameters()
            Dim i As Integer
            For i = 0 To col.Count - 1
                If(col(i).ItemType = ListItemType.Item Or col(i).ItemType = ListItemType.AlternatingItem) Then
                    Dim NewEditableGrid1STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1STUDENT_ID"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1SURNAME"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1FIRST_NAME"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1BIRTH_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1BIRTH_DATE"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1CATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1CATEGORY_CODE"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1TELEFORM_STATUS As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1TELEFORM_STATUS"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1TMP_STUDENT_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(col(i).FindControl("NewEditableGrid1TMP_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
                    Dim NewEditableGrid1SUBCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(col(i).FindControl("NewEditableGrid1SUBCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
                    Dim NewEditableGrid1Button1 As System.Web.UI.WebControls.Button = DirectCast(col(i).FindControl("NewEditableGrid1Button1"),System.Web.UI.WebControls.Button)
                    col(i).FindControl("RowError").Visible = False
                    Dim item As NewEditableGrid1Item = New NewEditableGrid1Item()
                    item.RowId = col(i).ItemIndex
                    item.IsUpdated = Not(col(i).Visible)
                    item.IsNew = CBool(rowState(col(i).ItemIndex))
                    item.TMP_STUDENT_IDField.Value = formState("TMP_STUDENT_IDField:" & col(i).ItemIndex)
                    item.STUDENT_ID.Value = ViewState(NewEditableGrid1STUDENT_ID.UniqueID)
                    item.SURNAME.Value = ViewState(NewEditableGrid1SURNAME.UniqueID)
                    item.FIRST_NAME.Value = ViewState(NewEditableGrid1FIRST_NAME.UniqueID)
                    item.BIRTH_DATE.Value = ViewState(NewEditableGrid1BIRTH_DATE.UniqueID)
                    item.CATEGORY_CODE.Value = ViewState(NewEditableGrid1CATEGORY_CODE.UniqueID)
                    item.LAST_ALTERED_DATE.Value = ViewState(NewEditableGrid1LAST_ALTERED_DATE.UniqueID)
                    item.TELEFORM_STATUS.Value = ViewState(NewEditableGrid1TELEFORM_STATUS.UniqueID)
                    item.SUBCATEGORY_CODE.Value = ViewState(NewEditableGrid1SUBCATEGORY_CODE.UniqueID)
                    Try
                    item.TMP_STUDENT_ID.IsEmpty = IsNothing(Request.Form(NewEditableGrid1TMP_STUDENT_ID.UniqueID))
                    item.TMP_STUDENT_ID.SetValue(NewEditableGrid1TMP_STUDENT_ID.Value)
                    Catch ex As ArgumentException
                    item.errors.Add("TMP_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ID"))
                    End Try
                    items.Add(item)

                End If
            Next i
'End EditableGrid Form NewEditableGrid1 ItemCommand event tail

'EditableGrid NewEditableGrid1 Update @5-16164A43
            If BindAllowed Then
                Try
                    NewEditableGrid1Parameters()
                    NewEditableGrid1Data.Update(items, NewEditableGrid1Operations)
                Catch ex As Exception
                    Dim Error_ As System.Web.UI.WebControls.Label = CType(NewEditableGrid1Repeater.Controls(0).FindControl("ErrorLabel"), System.Web.UI.WebControls.Label)
                    Dim RowError As PlaceHolder = Ctype(NewEditableGrid1Repeater.Controls(0).FindControl("NewEditableGrid1Error"), System.Web.UI.WebControls.PlaceHolder)
                    RowError.Visible = True
                    Error_.Text = "DataProvider:" & ex.Message
                    BindAllowed = False
'End EditableGrid NewEditableGrid1 Update

'EditableGrid NewEditableGrid1 After Update @5-A3A46ED6
                End Try
                If NewEditableGrid1ShowErrors(items, col) Then
                    Response.Redirect(RedirectUrl)
                Else
                    BindAllowed = False
                End If
            Else
                NewEditableGrid1ShowErrors(items, col)
            End If
            End If
            If BindAllowed Then
                NewEditableGrid1Bind()
            End If
        End Sub
'End EditableGrid NewEditableGrid1 After Update

'Record Form TMP_STUDENTSearch Parameters @18-78973FBB

    Protected Sub TMP_STUDENTSearchParameters()
        Dim item As new TMP_STUDENTSearchItem
        Try
        Catch e As Exception
            TMP_STUDENTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form TMP_STUDENTSearch Parameters

'Record Form TMP_STUDENTSearch Show method @18-1A7BA7FA
    Protected Sub TMP_STUDENTSearchShow()
        If TMP_STUDENTSearchOperations.None Then
            TMP_STUDENTSearchHolder.Visible = False
            Return
        End If
        Dim item As TMP_STUDENTSearchItem = TMP_STUDENTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TMP_STUDENTSearchOperations.AllowRead
        TMP_STUDENTSearchErrors.Add(item.errors)
        If TMP_STUDENTSearchErrors.Count > 0 Then
            TMP_STUDENTSearchShowErrors()
            Return
        End If
'End Record Form TMP_STUDENTSearch Show method

'Record Form TMP_STUDENTSearch BeforeShow tail @18-7AE912D4
        TMP_STUDENTSearchParameters()
        TMP_STUDENTSearchData.FillItem(item, IsInsertMode)
        TMP_STUDENTSearchHolder.DataBind()
        TMP_STUDENTSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form TMP_STUDENTSearch BeforeShow tail

'Record Form TMP_STUDENTSearch Show method tail @18-F2BD5050
        If TMP_STUDENTSearchErrors.Count > 0 Then
            TMP_STUDENTSearchShowErrors()
        End If
    End Sub
'End Record Form TMP_STUDENTSearch Show method tail

'Record Form TMP_STUDENTSearch LoadItemFromRequest method @18-9323E6B5

    Protected Sub TMP_STUDENTSearchLoadItemFromRequest(item As TMP_STUDENTSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(TMP_STUDENTSearchs_keyword.UniqueID))
        If ControlCustomValues("TMP_STUDENTSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(TMP_STUDENTSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("TMP_STUDENTSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(TMP_STUDENTSearchData)
        End If
        TMP_STUDENTSearchErrors.Add(item.errors)
    End Sub
'End Record Form TMP_STUDENTSearch LoadItemFromRequest method

'Record Form TMP_STUDENTSearch GetRedirectUrl method @18-BE3A20E8

    Protected Function GetTMP_STUDENTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "StudentEnrolment_TeleformsToBeEnrolled.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        If Not IsNothing(HttpContext.Current.Items("UpdatePanel")) Then
            p += "&FormFilter=" & HttpContext.Current.Items("UpdatePanel")
            p = p.Replace("?&","?")
        End If
        Return redirect + p
    End Function
'End Record Form TMP_STUDENTSearch GetRedirectUrl method

'Record Form TMP_STUDENTSearch ShowErrors method @18-48A67E70

    Protected Sub TMP_STUDENTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To TMP_STUDENTSearchErrors.Count - 1
        Select Case TMP_STUDENTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & TMP_STUDENTSearchErrors(i)
        End Select
        Next i
        TMP_STUDENTSearchError.Visible = True
        TMP_STUDENTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form TMP_STUDENTSearch ShowErrors method

'Record Form TMP_STUDENTSearch Insert Operation @18-B60A0BF6

    Protected Sub TMP_STUDENTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
        TMP_STUDENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TMP_STUDENTSearch Insert Operation

'Record Form TMP_STUDENTSearch BeforeInsert tail @18-2798A5AE
    TMP_STUDENTSearchParameters()
    TMP_STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TMP_STUDENTSearch BeforeInsert tail

'Record Form TMP_STUDENTSearch AfterInsert tail  @18-95643421
        ErrorFlag=(TMP_STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            TMP_STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TMP_STUDENTSearch AfterInsert tail 

'Record Form TMP_STUDENTSearch Update Operation @18-30ED63E4

    Protected Sub TMP_STUDENTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        TMP_STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TMP_STUDENTSearch Update Operation

'Record Form TMP_STUDENTSearch Before Update tail @18-2798A5AE
        TMP_STUDENTSearchParameters()
        TMP_STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TMP_STUDENTSearch Before Update tail

'Record Form TMP_STUDENTSearch Update Operation tail @18-95643421
        ErrorFlag=(TMP_STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            TMP_STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TMP_STUDENTSearch Update Operation tail

'Record Form TMP_STUDENTSearch Delete Operation @18-0D62F707
    Protected Sub TMP_STUDENTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        TMP_STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form TMP_STUDENTSearch Delete Operation

'Record Form BeforeDelete tail @18-2798A5AE
        TMP_STUDENTSearchParameters()
        TMP_STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @18-9903586D
        If ErrorFlag Then
            TMP_STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form TMP_STUDENTSearch Cancel Operation @18-CEC2AE80

    Protected Sub TMP_STUDENTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
        TMP_STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        TMP_STUDENTSearchLoadItemFromRequest(item, True)
'End Record Form TMP_STUDENTSearch Cancel Operation

'Record Form TMP_STUDENTSearch Cancel Operation tail @18-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form TMP_STUDENTSearch Cancel Operation tail

'Record Form TMP_STUDENTSearch Search Operation @18-3DA6AF36
    Protected Sub TMP_STUDENTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        TMP_STUDENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As TMP_STUDENTSearchItem = New TMP_STUDENTSearchItem()
        TMP_STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form TMP_STUDENTSearch Search Operation

'Button Button_DoSearch OnClick. @19-3C42DCCC
        If CType(sender,Control).ID = "TMP_STUDENTSearchButton_DoSearch" Then
            RedirectUrl = GetTMP_STUDENTSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @19-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form TMP_STUDENTSearch Search Operation tail @18-698C5AB2
        ErrorFlag = TMP_STUDENTSearchErrors.Count > 0
        If ErrorFlag Then
            TMP_STUDENTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(TMP_STUDENTSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(TMP_STUDENTSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TMP_STUDENTSearch Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'UpdatePanel UpdatePanel Initialize @4-15E371C0
        If "Panel1" = Request("FormFilter") Then
            HttpContext.Current.Items.Add("UpdatePanel", "Panel1")
        End If
'End UpdatePanel UpdatePanel Initialize

'OnInit Event Body @1-BB4423F7
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_TeleformsToBeEnrolledContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        NewEditableGrid1Data = New NewEditableGrid1DataProvider()
        NewEditableGrid1Operations = New FormSupportedOperations(False, True, False, True, False)
        TMP_STUDENTSearchData = New TMP_STUDENTSearchDataProvider()
        TMP_STUDENTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        Dim filter As New ResponseFilter(Response.Filter)
        AddHandler filter.OnFilterClose, AddressOf Me.BeforeOutput
        Response.Filter = filter
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

