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

Namespace DECV_PROD2007.Student_VSN_History 'Namespace @1-1B9A654A

'Forms Definition @1-B45E4E72
Public Class [Student_VSN_HistoryPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-8684EA20
    Protected viewSearchVSNHistoryData As viewSearchVSNHistoryDataProvider
    Protected viewSearchVSNHistoryErrors As NameValueCollection = New NameValueCollection()
    Protected viewSearchVSNHistoryOperations As FormSupportedOperations
    Protected viewSearchVSNHistoryIsSubmitted As Boolean = False
    Protected viewVSNTransactionsData As viewVSNTransactionsDataProvider
    Protected viewVSNTransactionsOperations As FormSupportedOperations
    Protected viewVSNTransactionsCurrentRowNumber As Integer
    Protected Student_VSN_HistoryContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-008B336B
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewSearchVSNHistoryShow()
            viewVSNTransactionsBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form viewSearchVSNHistory Parameters @2-75108B80

    Protected Sub viewSearchVSNHistoryParameters()
        Dim item As new viewSearchVSNHistoryItem
        Try
        Catch e As Exception
            viewSearchVSNHistoryErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewSearchVSNHistory Parameters

'Record Form viewSearchVSNHistory Show method @2-B9CA06EE
    Protected Sub viewSearchVSNHistoryShow()
        If viewSearchVSNHistoryOperations.None Then
            viewSearchVSNHistoryHolder.Visible = False
            Return
        End If
        Dim item As viewSearchVSNHistoryItem = viewSearchVSNHistoryItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewSearchVSNHistoryOperations.AllowRead
        item.ClearParametersHref = "MaintainSearchRequest.aspx"
        viewSearchVSNHistoryErrors.Add(item.errors)
        If viewSearchVSNHistoryErrors.Count > 0 Then
            viewSearchVSNHistoryShowErrors()
            Return
        End If
'End Record Form viewSearchVSNHistory Show method

'Record Form viewSearchVSNHistory BeforeShow tail @2-54824BB4
        viewSearchVSNHistoryParameters()
        viewSearchVSNHistoryData.FillItem(item, IsInsertMode)
        viewSearchVSNHistoryHolder.DataBind()
        viewSearchVSNHistorys_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        viewSearchVSNHistorys_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        viewSearchVSNHistorys_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
        viewSearchVSNHistoryClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewSearchVSNHistoryClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_STUDENT_ID;s_RECEIPT_NO;s_ENROLMENT_YEAR", ViewState)
        viewSearchVSNHistorys_STUDENT_VSN.Text=item.s_STUDENT_VSN.GetFormattedValue()
'End Record Form viewSearchVSNHistory BeforeShow tail

'Record Form viewSearchVSNHistory Show method tail @2-B9ABF628
        If viewSearchVSNHistoryErrors.Count > 0 Then
            viewSearchVSNHistoryShowErrors()
        End If
    End Sub
'End Record Form viewSearchVSNHistory Show method tail

'Record Form viewSearchVSNHistory LoadItemFromRequest method @2-34BEB024

    Protected Sub viewSearchVSNHistoryLoadItemFromRequest(item As viewSearchVSNHistoryItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(viewSearchVSNHistorys_SURNAME.UniqueID))
        If ControlCustomValues("viewSearchVSNHistorys_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(viewSearchVSNHistorys_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("viewSearchVSNHistorys_SURNAME"))
        End If
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewSearchVSNHistorys_STUDENT_ID.UniqueID))
        If ControlCustomValues("viewSearchVSNHistorys_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(viewSearchVSNHistorys_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("viewSearchVSNHistorys_STUDENT_ID"))
        End If
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewSearchVSNHistorys_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("viewSearchVSNHistorys_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(viewSearchVSNHistorys_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewSearchVSNHistorys_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            viewSearchVSNHistoryErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"s_ENROLMENT_YEAR"))
        End Try
        item.s_STUDENT_VSN.IsEmpty = IsNothing(Request.Form(viewSearchVSNHistorys_STUDENT_VSN.UniqueID))
        If ControlCustomValues("viewSearchVSNHistorys_STUDENT_VSN") Is Nothing Then
            item.s_STUDENT_VSN.SetValue(viewSearchVSNHistorys_STUDENT_VSN.Text)
        Else
            item.s_STUDENT_VSN.SetValue(ControlCustomValues("viewSearchVSNHistorys_STUDENT_VSN"))
        End If
        If EnableValidation Then
            item.Validate(viewSearchVSNHistoryData)
        End If
        viewSearchVSNHistoryErrors.Add(item.errors)
    End Sub
'End Record Form viewSearchVSNHistory LoadItemFromRequest method

'Record Form viewSearchVSNHistory GetRedirectUrl method @2-1C9E9E0A

    Protected Function GetviewSearchVSNHistoryRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_VSN_History.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewSearchVSNHistory GetRedirectUrl method

'Record Form viewSearchVSNHistory ShowErrors method @2-EF779D0D

    Protected Sub viewSearchVSNHistoryShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewSearchVSNHistoryErrors.Count - 1
        Select Case viewSearchVSNHistoryErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewSearchVSNHistoryErrors(i)
        End Select
        Next i
        viewSearchVSNHistoryError.Visible = True
        viewSearchVSNHistoryErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewSearchVSNHistory ShowErrors method

'Record Form viewSearchVSNHistory Insert Operation @2-B1C33F34

    Protected Sub viewSearchVSNHistory_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
        viewSearchVSNHistoryIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewSearchVSNHistory Insert Operation

'Record Form viewSearchVSNHistory BeforeInsert tail @2-0D67E79C
    viewSearchVSNHistoryParameters()
    viewSearchVSNHistoryLoadItemFromRequest(item, EnableValidation)
'End Record Form viewSearchVSNHistory BeforeInsert tail

'Record Form viewSearchVSNHistory AfterInsert tail  @2-75CEE009
        ErrorFlag=(viewSearchVSNHistoryErrors.Count > 0)
        If ErrorFlag Then
            viewSearchVSNHistoryShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewSearchVSNHistory AfterInsert tail 

'Record Form viewSearchVSNHistory Update Operation @2-7879CE80

    Protected Sub viewSearchVSNHistory_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewSearchVSNHistoryIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewSearchVSNHistory Update Operation

'Record Form viewSearchVSNHistory Before Update tail @2-0D67E79C
        viewSearchVSNHistoryParameters()
        viewSearchVSNHistoryLoadItemFromRequest(item, EnableValidation)
'End Record Form viewSearchVSNHistory Before Update tail

'Record Form viewSearchVSNHistory Update Operation tail @2-75CEE009
        ErrorFlag=(viewSearchVSNHistoryErrors.Count > 0)
        If ErrorFlag Then
            viewSearchVSNHistoryShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewSearchVSNHistory Update Operation tail

'Record Form viewSearchVSNHistory Delete Operation @2-188592E0
    Protected Sub viewSearchVSNHistory_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewSearchVSNHistoryIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewSearchVSNHistory Delete Operation

'Record Form BeforeDelete tail @2-0D67E79C
        viewSearchVSNHistoryParameters()
        viewSearchVSNHistoryLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-55DB68CA
        If ErrorFlag Then
            viewSearchVSNHistoryShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewSearchVSNHistory Cancel Operation @2-BD88B877

    Protected Sub viewSearchVSNHistory_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
        viewSearchVSNHistoryIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewSearchVSNHistoryLoadItemFromRequest(item, True)
'End Record Form viewSearchVSNHistory Cancel Operation

'Record Form viewSearchVSNHistory Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewSearchVSNHistory Cancel Operation tail

'Record Form viewSearchVSNHistory Search Operation @2-9C31F9FE
    Protected Sub viewSearchVSNHistory_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewSearchVSNHistoryIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewSearchVSNHistoryItem = New viewSearchVSNHistoryItem()
        viewSearchVSNHistoryLoadItemFromRequest(item, EnableValidation)
'End Record Form viewSearchVSNHistory Search Operation

'Button Button_DoSearch OnClick. @7-9878350D
        If CType(sender,Control).ID = "viewSearchVSNHistoryButton_DoSearch" Then
            RedirectUrl = GetviewSearchVSNHistoryRedirectUrl("", "s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR;s_STUDENT_VSN")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch Event OnClick. Action Custom Code @8-73254650
                ' -------------------------
                ' ERA: add an 'exist=2' parameter to URL querystring to flow through to the search 
                ' code is actually added 30 lines below, with this stub kept here for ease of finding it
                Dim tmpExistParam As String = "exist=2"
                ' -------------------------
                'End Button Button_DoSearch Event OnClick. Action Custom Code

'Button Button_DoSearch OnClick tail. @7-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewSearchVSNHistory Search Operation tail @2-0EF2BDAB
        ErrorFlag = viewSearchVSNHistoryErrors.Count > 0
        If ErrorFlag Then
            viewSearchVSNHistoryShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewSearchVSNHistorys_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(viewSearchVSNHistorys_SURNAME.Text) & "&"), "")
            Params = Params & IIf(viewSearchVSNHistorys_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(viewSearchVSNHistorys_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(viewSearchVSNHistorys_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewSearchVSNHistorys_ENROLMENT_YEAR.Text) & "&"), "")
            Params = Params & IIf(viewSearchVSNHistorys_STUDENT_VSN.Text <> "",("s_STUDENT_VSN=" & Server.UrlEncode(viewSearchVSNHistorys_STUDENT_VSN.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewSearchVSNHistory Search Operation tail

'Grid viewVSNTransactions Bind @11-40B6D041

    Protected Sub viewVSNTransactionsBind()
        If Not viewVSNTransactionsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewVSNTransactions",GetType(viewVSNTransactionsDataProvider.SortFields), 25, 100)
        End If
'End Grid viewVSNTransactions Bind

'Grid Form viewVSNTransactions BeforeShow tail @11-DD21FA7F
        viewVSNTransactionsParameters()
        viewVSNTransactionsData.SortField = CType(ViewState("viewVSNTransactionsSortField"),viewVSNTransactionsDataProvider.SortFields)
        viewVSNTransactionsData.SortDir = CType(ViewState("viewVSNTransactionsSortDir"),SortDirections)
        viewVSNTransactionsData.PageNumber = CInt(ViewState("viewVSNTransactionsPageNumber"))
        viewVSNTransactionsData.RecordsPerPage = CInt(ViewState("viewVSNTransactionsPageSize"))
        viewVSNTransactionsRepeater.DataSource = viewVSNTransactionsData.GetResultSet(PagesCount, viewVSNTransactionsOperations)
        ViewState("viewVSNTransactionsPagesCount") = PagesCount
        Dim item As viewVSNTransactionsItem = New viewVSNTransactionsItem()
        viewVSNTransactionsRepeater.DataBind
        FooterIndex = viewVSNTransactionsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewVSNTransactionsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewVSNTransactionsRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Sorter_LastNameSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_LastNameSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRSTNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_FIRSTNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MiddleNameSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_MiddleNameSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_BirthDateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_BirthDateSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GenderSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_GenderSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_VSN1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_VSN1Sorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_BatchIDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_BatchIDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SequenceNoSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_SequenceNoSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TypeSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_TypeSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MessageSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_MessageSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ExceptionIDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_ExceptionIDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_VSRRegisterrationDateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNTransactionsRepeater.Controls(0).FindControl("Sorter_VSRRegisterrationDateSorter"),DECV_PROD2007.Controls.Sorter)

'End Grid Form viewVSNTransactions BeforeShow tail

'Grid viewVSNTransactions Event BeforeShow. Action Custom Code @34-73254650
            ' -------------------------
            ' Vikas: only display if something to display, and not if initial open
            If (IsNothing(viewVSNTransactionsData.Urls_STUDENT_ID) And IsNothing(viewVSNTransactionsData.Urls_SURNAME)) And IsNothing(viewVSNTransactionsData.Urls_STUDENT_VSN) Then
                viewVSNTransactionsRepeater.Visible = False
            End If

            ' -------------------------
            'End Grid viewVSNTransactions Event BeforeShow. Action Custom Code

'Grid viewVSNTransactions Bind tail @11-E31F8E2A
    End Sub
'End Grid viewVSNTransactions Bind tail

'Grid viewVSNTransactions Table Parameters @11-5309328D

    Protected Sub viewVSNTransactionsParameters()
        Try
            viewVSNTransactionsData.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            viewVSNTransactionsData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewVSNTransactionsData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            viewVSNTransactionsData.Urls_STUDENT_VSN = TextParameter.GetParam("s_STUDENT_VSN", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewVSNTransactionsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewVSNTransactionsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewVSNTransactions: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewVSNTransactions Table Parameters

'Grid viewVSNTransactions ItemDataBound event @11-9CED8B12

    Protected Sub viewVSNTransactionsItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewVSNTransactionsItem = CType(e.Item.DataItem,viewVSNTransactionsItem)
        Dim Item as viewVSNTransactionsItem = DataItem
        Dim FormDataSource As viewVSNTransactionsItem() = CType(viewVSNTransactionsRepeater.DataSource, viewVSNTransactionsItem())
        Dim viewVSNTransactionsDataRows As Integer = FormDataSource.Length
        Dim viewVSNTransactionsIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewVSNTransactionsCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewVSNTransactionsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewVSNTransactionsCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewVSNTransactionsSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewVSNTransactionsSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewVSNTransactionsLastName As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsLastName"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsFIRSTNAME"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsMiddleName As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsMiddleName"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsBirthDate As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsBirthDate"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsVSN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsVSN"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsBatchID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsBatchID"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsSeqNum As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsSeqNum"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsType As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsType"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsMessage As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsMessage"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsVSRRegisterrationDate As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsVSRRegisterrationDate"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsExceptionID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsExceptionID"),System.Web.UI.WebControls.Literal)
            Dim viewVSNTransactionsSex As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNTransactionsSex"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            viewVSNTransactionsSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","s_SURNAME;s_ENROLMENT_YEAR", ViewState)
        End If
'End Grid viewVSNTransactions ItemDataBound event

'viewVSNTransactions control Before Show @11-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End viewVSNTransactions control Before Show

'Get Control @13-FAF473EC
            Dim viewVSNTransactionsSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewVSNTransactionsSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link STUDENT_ID Event BeforeShow. Action Custom Code @14-73254650
                ' -------------------------
                ' ERA: change the hyperlink depending on if the exist=1 
                '	(if 1 then StudentEnrolment_AddStudent else leave as is: Student Summary)
                If Request.QueryString("exist") = "1" Then
                    DataItem.STUDENT_IDHref = "StudentEnrolment_AddNewYear.aspx"
                    viewVSNTransactionsSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET", "", ViewState)
                End If
                ' -------------------------
                'End Link STUDENT_ID Event BeforeShow. Action Custom Code

'viewVSNTransactions control Before Show tail @11-477CF3C9
        End If
'End viewVSNTransactions control Before Show tail

'Grid viewVSNTransactions ItemDataBound event tail @11-F45BE103
        If viewVSNTransactionsIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewVSNTransactionsCurrentRowNumber, ListItemType.Item)
            viewVSNTransactionsRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewVSNTransactionsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewVSNTransactions ItemDataBound event tail

'Grid viewVSNTransactions ItemCommand event @11-C8BCDFCD

    Protected Sub viewVSNTransactionsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewVSNTransactionsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewVSNTransactionsSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewVSNTransactionsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewVSNTransactionsSortDir")=SortDirections._Desc
                Else
                    ViewState("viewVSNTransactionsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewVSNTransactionsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewVSNTransactionsDataProvider.SortFields = 0
            ViewState("viewVSNTransactionsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewVSNTransactionsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewVSNTransactionsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewVSNTransactionsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewVSNTransactionsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewVSNTransactionsBind
        End If
    End Sub
'End Grid viewVSNTransactions ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-2D0C29FE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_VSN_HistoryContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewSearchVSNHistoryData = New viewSearchVSNHistoryDataProvider()
        viewSearchVSNHistoryOperations = New FormSupportedOperations(False, True, True, True, True)
        viewVSNTransactionsData = New viewVSNTransactionsDataProvider()
        viewVSNTransactionsOperations = New FormSupportedOperations(False, True, False, False, False)
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

