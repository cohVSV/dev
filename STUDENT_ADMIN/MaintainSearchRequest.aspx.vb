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

Namespace DECV_PROD2007.MaintainSearchRequest 'Namespace @1-74A53512

'Forms Definition @1-371D550F
Public Class [MaintainSearchRequestPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-8B81211F
    Protected viewMaintainSearchRequestSearchData As viewMaintainSearchRequestSearchDataProvider
    Protected viewMaintainSearchRequestSearchErrors As NameValueCollection = New NameValueCollection()
    Protected viewMaintainSearchRequestSearchOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestSearchIsSubmitted As Boolean = False
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestCurrentRowNumber As Integer
    Protected MaintainSearchRequestContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-ACD4448E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewMaintainSearchRequestSearchShow()
            viewMaintainSearchRequestBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form viewMaintainSearchRequestSearch Parameters @5-2C0CE1CA

    Protected Sub viewMaintainSearchRequestSearchParameters()
        Dim item As new viewMaintainSearchRequestSearchItem
        Try
        Catch e As Exception
            viewMaintainSearchRequestSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewMaintainSearchRequestSearch Parameters

'Record Form viewMaintainSearchRequestSearch Show method @5-734165B5
    Protected Sub viewMaintainSearchRequestSearchShow()
        If viewMaintainSearchRequestSearchOperations.None Then
            viewMaintainSearchRequestSearchHolder.Visible = False
            Return
        End If
        Dim item As viewMaintainSearchRequestSearchItem = viewMaintainSearchRequestSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewMaintainSearchRequestSearchOperations.AllowRead
        item.ClearParametersHref = "MaintainSearchRequest.aspx"
        item.Link1Href = "MaintainSearchRequest_Advanced.aspx"
        item.Link2Href = "MaintainSearchRequest_Primary.aspx"
        viewMaintainSearchRequestSearchErrors.Add(item.errors)
        If viewMaintainSearchRequestSearchErrors.Count > 0 Then
            viewMaintainSearchRequestSearchShowErrors()
            Return
        End If
'End Record Form viewMaintainSearchRequestSearch Show method

'Record Form viewMaintainSearchRequestSearch BeforeShow tail @5-88F1B3E9
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchData.FillItem(item, IsInsertMode)
        viewMaintainSearchRequestSearchHolder.DataBind()
        viewMaintainSearchRequestSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        viewMaintainSearchRequestSearchs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
        viewMaintainSearchRequestSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_STUDENT_ID;s_RECEIPT_NO;s_ENROLMENT_YEAR", ViewState)
        viewMaintainSearchRequestSearchLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestSearchLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState)
        viewMaintainSearchRequestSearchLink2.InnerText += item.Link2.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestSearchLink2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("GET","", ViewState)
'End Record Form viewMaintainSearchRequestSearch BeforeShow tail

'TextBox s_ENROLMENT_YEAR Event BeforeShow. Action Custom Code @48-73254650
    ' -------------------------
    If ((Date.Now.Month >= 10) AndAlso Session(Common.GroupIDSessionID)?.ToString().Equals("6")) Then
       ' For enrolments staff, set the default year to the upcoming enrolment year once the intake period (currently October) has been reached.
       viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.Text = (Date.Now.Year + 1).ToString()
    End If
    ' -------------------------
'End TextBox s_ENROLMENT_YEAR Event BeforeShow. Action Custom Code

'Button Button_DoAddEnrolYearSearch Event BeforeShow. Action Hide-Show Component @39-A4B3557D
        Dim UrlshowAdd_39_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("showAdd"))
        Dim ExprParam2_39_2 As TextField = New TextField("", ("1"))
        If FieldBase.NotEqualOp(UrlshowAdd_39_1, ExprParam2_39_2) Then
            viewMaintainSearchRequestSearchButton_DoAddEnrolYearSearch.Visible = False
        End If
'End Button Button_DoAddEnrolYearSearch Event BeforeShow. Action Hide-Show Component


'Record Form viewMaintainSearchRequestSearch Show method tail @5-7E05ECE5
        If viewMaintainSearchRequestSearchErrors.Count > 0 Then
            viewMaintainSearchRequestSearchShowErrors()
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch Show method tail

'Record Form viewMaintainSearchRequestSearch LoadItemFromRequest method @5-D51BF0F9

    Protected Sub viewMaintainSearchRequestSearchLoadItemFromRequest(item As viewMaintainSearchRequestSearchItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestSearchs_SURNAME.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequestSearchs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(viewMaintainSearchRequestSearchs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("viewMaintainSearchRequestSearchs_SURNAME"))
        End If
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestSearchs_STUDENT_ID.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequestSearchs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(viewMaintainSearchRequestSearchs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("viewMaintainSearchRequestSearchs_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            viewMaintainSearchRequestSearchErrors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequestSearchs_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewMaintainSearchRequestSearchs_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            viewMaintainSearchRequestSearchErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"s_ENROLMENT_YEAR"))
        End Try
        If EnableValidation Then
            item.Validate(viewMaintainSearchRequestSearchData)
        End If
        viewMaintainSearchRequestSearchErrors.Add(item.errors)
    End Sub
'End Record Form viewMaintainSearchRequestSearch LoadItemFromRequest method

'Record Form viewMaintainSearchRequestSearch GetRedirectUrl method @5-DBCB0FF0

    Protected Function GetviewMaintainSearchRequestSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "MaintainSearchRequest.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewMaintainSearchRequestSearch GetRedirectUrl method

'Record Form viewMaintainSearchRequestSearch ShowErrors method @5-F8D37C92

    Protected Sub viewMaintainSearchRequestSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewMaintainSearchRequestSearchErrors.Count - 1
        Select Case viewMaintainSearchRequestSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewMaintainSearchRequestSearchErrors(i)
        End Select
        Next i
        viewMaintainSearchRequestSearchError.Visible = True
        viewMaintainSearchRequestSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewMaintainSearchRequestSearch ShowErrors method

'Record Form viewMaintainSearchRequestSearch Insert Operation @5-1A28279F

    Protected Sub viewMaintainSearchRequestSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequestSearch Insert Operation

'Record Form viewMaintainSearchRequestSearch BeforeInsert tail @5-6D659926
    viewMaintainSearchRequestSearchParameters()
    viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequestSearch BeforeInsert tail

'Record Form viewMaintainSearchRequestSearch AfterInsert tail  @5-6270FCD4
        ErrorFlag=(viewMaintainSearchRequestSearchErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch AfterInsert tail 

'Record Form viewMaintainSearchRequestSearch Update Operation @5-CD83C997

    Protected Sub viewMaintainSearchRequestSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequestSearch Update Operation

'Record Form viewMaintainSearchRequestSearch Before Update tail @5-6D659926
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequestSearch Before Update tail

'Record Form viewMaintainSearchRequestSearch Update Operation tail @5-6270FCD4
        ErrorFlag=(viewMaintainSearchRequestSearchErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch Update Operation tail

'Record Form viewMaintainSearchRequestSearch Delete Operation @5-14E19741
    Protected Sub viewMaintainSearchRequestSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewMaintainSearchRequestSearch Delete Operation

'Record Form BeforeDelete tail @5-6D659926
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @5-204E12B9
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewMaintainSearchRequestSearch Cancel Operation @5-352C7F64

    Protected Sub viewMaintainSearchRequestSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, True)
'End Record Form viewMaintainSearchRequestSearch Cancel Operation

'Record Form viewMaintainSearchRequestSearch Cancel Operation tail @5-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewMaintainSearchRequestSearch Cancel Operation tail

'Record Form viewMaintainSearchRequestSearch Search Operation @5-57BFFD36
    Protected Sub viewMaintainSearchRequestSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
		'ERA: value to save the exist param into
		dim tmpExistParam as string = "exist=2"
'End Record Form viewMaintainSearchRequestSearch Search Operation

'Button Button_DoAddEnrolYearSearch OnClick. @35-46C7D4FB
        If CType(sender,Control).ID = "viewMaintainSearchRequestSearchButton_DoAddEnrolYearSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestSearchRedirectUrl("", "s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoAddEnrolYearSearch OnClick.

'Button Button_DoAddEnrolYearSearch Event OnClick. Action Custom Code @36-73254650
    ' -------------------------
    ' ERA: add an 'exist=1' parameter to URL querystring to flow through to the search 
	' code is actually added 30 lines below, with this stub kept here for ease of finding it
			tmpExistParam = "exist=1"
    ' -------------------------
'End Button Button_DoAddEnrolYearSearch Event OnClick. Action Custom Code

'Button Button_DoAddEnrolYearSearch OnClick tail. @35-477CF3C9
        End If
'End Button Button_DoAddEnrolYearSearch OnClick tail.

'Button Button_DoSearch OnClick. @7-825BEA2B
        If CType(sender,Control).ID = "viewMaintainSearchRequestSearchButton_DoSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestSearchRedirectUrl("", "s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch Event OnClick. Action Custom Code @38-73254650
    ' -------------------------
    ' ERA: add an 'exist=2' parameter to URL querystring to flow through to the search 
	' code is actually added 30 lines below, with this stub kept here for ease of finding it
			tmpExistParam = "exist=2"
    ' -------------------------
'End Button Button_DoSearch Event OnClick. Action Custom Code

'Button Button_DoSearch OnClick tail. @7-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewMaintainSearchRequestSearch Search Operation tail @5-43C2007E
        ErrorFlag = viewMaintainSearchRequestSearchErrors.Count > 0
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewMaintainSearchRequestSearchs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_SURNAME.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequestSearchs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_STUDENT_ID.Text) & "&"), "")
			'18-Dec-2009|EA| removed Receipt No due to no-one using it. unfuddle #192
            'Params = Params & IIf(viewMaintainSearchRequestSearchs_RECEIPT_NO.Text <> "",("s_RECEIPT_NO=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_RECEIPT_NO.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_ENROLMENT_YEAR.Text) & "&"), "")
			' ERA: add an 'exist=1 or 2' parameter to URL querystring to flow through to the search 
			Params = Params & tmpExistParam

            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch Search Operation tail

'Grid viewMaintainSearchRequest Bind @3-1CB25094

    Protected Sub viewMaintainSearchRequestBind()
        If Not viewMaintainSearchRequestOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest",GetType(viewMaintainSearchRequestDataProvider.SortFields), 25, 100)
        End If
'End Grid viewMaintainSearchRequest Bind

'Grid Form viewMaintainSearchRequest BeforeShow tail @3-6F955D0C
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestData.SortField = CType(ViewState("viewMaintainSearchRequestSortField"),viewMaintainSearchRequestDataProvider.SortFields)
        viewMaintainSearchRequestData.SortDir = CType(ViewState("viewMaintainSearchRequestSortDir"),SortDirections)
        viewMaintainSearchRequestData.PageNumber = CInt(ViewState("viewMaintainSearchRequestPageNumber"))
        viewMaintainSearchRequestData.RecordsPerPage = CInt(ViewState("viewMaintainSearchRequestPageSize"))
        viewMaintainSearchRequestRepeater.DataSource = viewMaintainSearchRequestData.GetResultSet(PagesCount, viewMaintainSearchRequestOperations)
        ViewState("viewMaintainSearchRequestPagesCount") = PagesCount
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestRepeater.DataBind
        FooterIndex = viewMaintainSearchRequestRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RECEIPT_NOSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_RECEIPT_NOSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form viewMaintainSearchRequest BeforeShow tail

'Grid viewMaintainSearchRequest Event BeforeShow. Action Custom Code @32-73254650
    ' -------------------------
    ' ERA: only display if something to display, and not if initial open
	'18-Dec-2009|EA| removed Receipt No due to no-one using it. unfuddle #192
	'if (isnothing(viewMaintainSearchRequestData.Urls_SURNAME) and isnothing(viewmaintainsearchrequestdata.urls_receipt_no) and isnothing(viewmaintainsearchrequestdata.urls_student_id)) then
	if (isnothing(viewMaintainSearchRequestData.Urls_SURNAME) and isnothing(viewmaintainsearchrequestdata.urls_student_id)) then
		viewMaintainSearchRequestRepeater.visible = false
    end if

    ' -------------------------
'End Grid viewMaintainSearchRequest Event BeforeShow. Action Custom Code

'Grid viewMaintainSearchRequest Bind tail @3-E31F8E2A
    End Sub
'End Grid viewMaintainSearchRequest Bind tail

'Grid viewMaintainSearchRequest Table Parameters @3-9DDEF77F

    Protected Sub viewMaintainSearchRequestParameters()
        Try
            viewMaintainSearchRequestData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequestData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequestData.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewMaintainSearchRequestRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewMaintainSearchRequestRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewMaintainSearchRequest: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewMaintainSearchRequest Table Parameters

'Grid viewMaintainSearchRequest ItemDataBound event @3-4CF3FFC2

    Protected Sub viewMaintainSearchRequestItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewMaintainSearchRequestItem = CType(e.Item.DataItem,viewMaintainSearchRequestItem)
        Dim Item as viewMaintainSearchRequestItem = DataItem
        Dim FormDataSource As viewMaintainSearchRequestItem() = CType(viewMaintainSearchRequestRepeater.DataSource, viewMaintainSearchRequestItem())
        Dim viewMaintainSearchRequestDataRows As Integer = FormDataSource.Length
        Dim viewMaintainSearchRequestIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequestCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequestRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequestCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewMaintainSearchRequestSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequestRECEIPT_NO As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestRECEIPT_NO"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            viewMaintainSearchRequestSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","s_SURNAME;s_ENROLMENT_YEAR;skip", ViewState)
        End If
'End Grid viewMaintainSearchRequest ItemDataBound event

'viewMaintainSearchRequest control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End viewMaintainSearchRequest control Before Show

'Get Control @23-77A5474D
            Dim viewMaintainSearchRequestSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link STUDENT_ID Event BeforeShow. Action Custom Code @37-73254650
    ' -------------------------
    ' ERA: change the hyperlink depending on if the exist=1 
	'	(if 1 then StudentEnrolment_AddStudent else leave as is: Student Summary)
	If Request.QueryString("exist") = "1" Then 
		DataItem.STUDENT_IDHref = "StudentEnrolment_AddNewYear.aspx"
		viewMaintainSearchRequestSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","", ViewState)
	end if
    ' -------------------------
'End Link STUDENT_ID Event BeforeShow. Action Custom Code

'viewMaintainSearchRequest control Before Show tail @3-477CF3C9
        End If
'End viewMaintainSearchRequest control Before Show tail

'Grid viewMaintainSearchRequest ItemDataBound event tail @3-C2522D63
        If viewMaintainSearchRequestIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewMaintainSearchRequestCurrentRowNumber, ListItemType.Item)
            viewMaintainSearchRequestRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewMaintainSearchRequestItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewMaintainSearchRequest ItemDataBound event tail

'Grid viewMaintainSearchRequest ItemCommand event @3-23C75A20

    Protected Sub viewMaintainSearchRequestItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewMaintainSearchRequestRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewMaintainSearchRequestSortDir"),SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequestSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewMaintainSearchRequestSortDir")=SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequestSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequestSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewMaintainSearchRequestDataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequestSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequestPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewMaintainSearchRequestPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewMaintainSearchRequestPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequestPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewMaintainSearchRequestBind
        End If
    End Sub
'End Grid viewMaintainSearchRequest ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-EF9C206D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MaintainSearchRequestContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewMaintainSearchRequestSearchData = New viewMaintainSearchRequestSearchDataProvider()
        viewMaintainSearchRequestSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, False, False, False)
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

