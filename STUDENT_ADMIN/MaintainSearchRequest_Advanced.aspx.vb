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

Namespace DECV_PROD2007.MaintainSearchRequest_Advanced 'Namespace @1-A103CBB7

'Forms Definition @1-54DF1EB8
Public Class [MaintainSearchRequest_AdvancedPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-76A85496
    Protected viewMaintainSearchRequest1Data As viewMaintainSearchRequest1DataProvider
    Protected viewMaintainSearchRequest1Operations As FormSupportedOperations
    Protected viewMaintainSearchRequest1CurrentRowNumber As Integer
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestErrors As NameValueCollection = New NameValueCollection()
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestIsSubmitted As Boolean = False
    Protected MaintainSearchRequest_AdvancedContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page MaintainSearchRequest_Advanced Event OnInitializeView. Action Custom Code @67-73254650
    ' -------------------------
	'ERA: Jan-2010|EA| if export set then export to Excel
    
  	If (Request.QueryString("export") = "1") Then
  		Dim ExportFileName As String
  		ExportFileName = "SchoolStudentList.xls"
  		'Hide the ExportToExcel Link
		LinkExportToExcel.visible = false
		'and hide the Search box
		viewMaintainSearchRequestHolder.Visible = False
		Header.visible = false
		'Footer.visible = false
  		'Set Content type to Excel
  		Response.ContentType = "application/vnd.ms-excel"
  		'Fix IE 5.0-5.5 bug with Content-Disposition=attachment
  		If  Request.ServerVariables.Get("HTTP_USER_AGENT").IndexOf("MSIE 5.5;") <> -1 Or _
  			Request.ServerVariables.Get("HTTP_USER_AGENT").IndexOf("MSIE 5.0;") <> -1 Then
  				Response.AddHeader("Content-Disposition", "filename=" & ExportFileName & ";")
  		Else
  				Response.AddHeader("Content-Disposition", "attachment; filename=" & ExportFileName & ";")
  		End If
  	End If
    ' -------------------------
'End Page MaintainSearchRequest_Advanced Event OnInitializeView. Action Custom Code

'Page_Load Event BeforeIsPostBack @1-5379C8A0
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.LinkExportToExcelHref = "MaintainSearchRequest_Advanced.aspx"
            item.LinkExportToExcelHrefParameters.Add("export",System.Web.HttpUtility.UrlEncode((1).ToString()))
            PageData.FillItem(item)
            LinkExportToExcel.InnerText += item.LinkExportToExcel.GetFormattedValue().Replace(vbCrLf,"")
            LinkExportToExcel.HRef = item.LinkExportToExcelHref+item.LinkExportToExcelHrefParameters.ToString("GET","", ViewState)
            LinkExportToExcel.DataBind()
            viewMaintainSearchRequest1Bind
            viewMaintainSearchRequestShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid viewMaintainSearchRequest1 Bind @3-8E891337

    Protected Sub viewMaintainSearchRequest1Bind()
        If Not viewMaintainSearchRequest1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest1",GetType(viewMaintainSearchRequest1DataProvider.SortFields), 500, 500)
        End If
'End Grid viewMaintainSearchRequest1 Bind

'Grid Form viewMaintainSearchRequest1 BeforeShow tail @3-8D25E649
        viewMaintainSearchRequest1Parameters()
        viewMaintainSearchRequest1Data.SortField = CType(ViewState("viewMaintainSearchRequest1SortField"),viewMaintainSearchRequest1DataProvider.SortFields)
        viewMaintainSearchRequest1Data.SortDir = CType(ViewState("viewMaintainSearchRequest1SortDir"),SortDirections)
        viewMaintainSearchRequest1Data.PageNumber = CInt(ViewState("viewMaintainSearchRequest1PageNumber"))
        viewMaintainSearchRequest1Data.RecordsPerPage = CInt(ViewState("viewMaintainSearchRequest1PageSize"))
        viewMaintainSearchRequest1Repeater.DataSource = viewMaintainSearchRequest1Data.GetResultSet(PagesCount, viewMaintainSearchRequest1Operations)
        ViewState("viewMaintainSearchRequest1PagesCount") = PagesCount
        Dim item As viewMaintainSearchRequest1Item = New viewMaintainSearchRequest1Item()
        viewMaintainSearchRequest1Repeater.DataBind
        FooterIndex = viewMaintainSearchRequest1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_HOME_SCHOOL_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_HOME_SCHOOL_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ATTENDING_SCHOOL_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ATTENDING_SCHOOL_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)

        viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = Server.HtmlEncode(item.viewMaintainSearchRequest1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form viewMaintainSearchRequest1 BeforeShow tail

'Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records @10-822AFFB6
            viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = viewMaintainSearchRequest1Data.RecordCount.ToString()
'End Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid viewMaintainSearchRequest1 Event BeforeShow. Action Custom Code @41-73254650
    ' -------------------------
	' ERA: only display if something to display, and not if initial open
	if (isnothing(viewMaintainSearchRequest1Data.Urls_HOME_SCHOOL_ID)) then
		viewMaintainSearchRequest1Repeater.visible = false
		LinkExportToExcel.visible = false
    end if

    ' -------------------------
'End Grid viewMaintainSearchRequest1 Event BeforeShow. Action Custom Code

'Grid viewMaintainSearchRequest1 Bind tail @3-E31F8E2A
    End Sub
'End Grid viewMaintainSearchRequest1 Bind tail

'Grid viewMaintainSearchRequest1 Table Parameters @3-45B445DF

    Protected Sub viewMaintainSearchRequest1Parameters()
        Try
            viewMaintainSearchRequest1Data.Urls_HOME_SCHOOL_ID = TextParameter.GetParam("s_HOME_SCHOOL_ID", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest1Data.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewMaintainSearchRequest1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewMaintainSearchRequest1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewMaintainSearchRequest1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewMaintainSearchRequest1 Table Parameters

'Grid viewMaintainSearchRequest1 ItemDataBound event @3-6B5A389F

    Protected Sub viewMaintainSearchRequest1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewMaintainSearchRequest1Item = CType(e.Item.DataItem,viewMaintainSearchRequest1Item)
        Dim Item as viewMaintainSearchRequest1Item = DataItem
        Dim FormDataSource As viewMaintainSearchRequest1Item() = CType(viewMaintainSearchRequest1Repeater.DataSource, viewMaintainSearchRequest1Item())
        Dim viewMaintainSearchRequest1DataRows As Integer = FormDataSource.Length
        Dim viewMaintainSearchRequest1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequest1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequest1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequest1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewMaintainSearchRequest1STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1HOME_SCHOOL_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1HOME_SCHOOL_ID"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ATTENDING_SCHOOL_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ATTENDING_SCHOOL_ID"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            viewMaintainSearchRequest1STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","s_HOME_SCHOOL_ID;s_ENROLMENT_YEAR", ViewState)
        End If
'End Grid viewMaintainSearchRequest1 ItemDataBound event

'Grid viewMaintainSearchRequest1 ItemDataBound event tail @3-01707A28
        If viewMaintainSearchRequest1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewMaintainSearchRequest1CurrentRowNumber, ListItemType.Item)
            viewMaintainSearchRequest1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewMaintainSearchRequest1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewMaintainSearchRequest1 ItemDataBound event tail

'Grid viewMaintainSearchRequest1 ItemCommand event @3-6A808BC9

    Protected Sub viewMaintainSearchRequest1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewMaintainSearchRequest1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewMaintainSearchRequest1SortDir"),SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequest1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewMaintainSearchRequest1SortDir")=SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequest1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequest1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewMaintainSearchRequest1DataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequest1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequest1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewMaintainSearchRequest1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewMaintainSearchRequest1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequest1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewMaintainSearchRequest1Bind
        End If
    End Sub
'End Grid viewMaintainSearchRequest1 ItemCommand event

'Record Form viewMaintainSearchRequest Parameters @4-80C4ACFE

    Protected Sub viewMaintainSearchRequestParameters()
        Dim item As new viewMaintainSearchRequestItem
        Try
        Catch e As Exception
            viewMaintainSearchRequestErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewMaintainSearchRequest Parameters

'Record Form viewMaintainSearchRequest Show method @4-9EAF39A1
    Protected Sub viewMaintainSearchRequestShow()
        If viewMaintainSearchRequestOperations.None Then
            viewMaintainSearchRequestHolder.Visible = False
            Return
        End If
        Dim item As viewMaintainSearchRequestItem = viewMaintainSearchRequestItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewMaintainSearchRequestOperations.AllowRead
        item.ClearParametersHref = "MaintainSearchRequest_Advanced.aspx"
        item.Link1Href = "MaintainSearchRequest.aspx"
        viewMaintainSearchRequestErrors.Add(item.errors)
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
            Return
        End If
'End Record Form viewMaintainSearchRequest Show method

'Record Form viewMaintainSearchRequest BeforeShow tail @4-DA0CC30F
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestData.FillItem(item, IsInsertMode)
        viewMaintainSearchRequestHolder.DataBind()
        viewMaintainSearchRequests_HOME_SCHOOL_ID.Text=item.s_HOME_SCHOOL_ID.GetFormattedValue()
        viewMaintainSearchRequests_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
        viewMaintainSearchRequests_SCHOOLNAME.Text=item.s_SCHOOLNAME.GetFormattedValue()
        viewMaintainSearchRequestClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_HOME_SCHOOL_ID;s_ENROLMENT_YEAR;s_SCHOOLNAME;export", ViewState)
        viewMaintainSearchRequesthidden_auto.Value = item.hidden_auto.GetFormattedValue()
        viewMaintainSearchRequestLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState)
'End Record Form viewMaintainSearchRequest BeforeShow tail

'TextBox s_ENROLMENT_YEAR Event BeforeShow. Action Custom Code @79-73254650
    ' -------------------------
    If ((Date.Now.Month >= 10) AndAlso Session(Common.GroupIDSessionID)?.ToString().Equals("6")) Then
       ' For enrolments staff, set the default year to the upcoming enrolment year once the intake period (currently October) has been reached.
       viewMaintainSearchRequests_ENROLMENT_YEAR.Text = (Date.Now.Year + 1).ToString()
    End If
    ' -------------------------
'End TextBox s_ENROLMENT_YEAR Event BeforeShow. Action Custom Code

'Record Form viewMaintainSearchRequest Show method tail @4-D3A5B4A7
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Show method tail

'Record Form viewMaintainSearchRequest LoadItemFromRequest method @4-6841D9CB

    Protected Sub viewMaintainSearchRequestLoadItemFromRequest(item As viewMaintainSearchRequestItem, ByVal EnableValidation As Boolean)
        item.s_HOME_SCHOOL_ID.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_HOME_SCHOOL_ID.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_HOME_SCHOOL_ID") Is Nothing Then
            item.s_HOME_SCHOOL_ID.SetValue(viewMaintainSearchRequests_HOME_SCHOOL_ID.Text)
        Else
            item.s_HOME_SCHOOL_ID.SetValue(ControlCustomValues("viewMaintainSearchRequests_HOME_SCHOOL_ID"))
        End If
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(viewMaintainSearchRequests_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewMaintainSearchRequests_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            viewMaintainSearchRequestErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.s_SCHOOLNAME.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_SCHOOLNAME.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_SCHOOLNAME") Is Nothing Then
            item.s_SCHOOLNAME.SetValue(viewMaintainSearchRequests_SCHOOLNAME.Text)
        Else
            item.s_SCHOOLNAME.SetValue(ControlCustomValues("viewMaintainSearchRequests_SCHOOLNAME"))
        End If
        item.hidden_auto.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequesthidden_auto.UniqueID))
        item.hidden_auto.SetValue(viewMaintainSearchRequesthidden_auto.Value)
        If EnableValidation Then
            item.Validate(viewMaintainSearchRequestData)
        End If
        viewMaintainSearchRequestErrors.Add(item.errors)
    End Sub
'End Record Form viewMaintainSearchRequest LoadItemFromRequest method

'Record Form viewMaintainSearchRequest GetRedirectUrl method @4-A7A908F4

    Protected Function GetviewMaintainSearchRequestRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "MaintainSearchRequest_Advanced.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewMaintainSearchRequest GetRedirectUrl method

'Record Form viewMaintainSearchRequest ShowErrors method @4-2271AF53

    Protected Sub viewMaintainSearchRequestShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewMaintainSearchRequestErrors.Count - 1
        Select Case viewMaintainSearchRequestErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewMaintainSearchRequestErrors(i)
        End Select
        Next i
        viewMaintainSearchRequestError.Visible = True
        viewMaintainSearchRequestErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewMaintainSearchRequest ShowErrors method

'Record Form viewMaintainSearchRequest Insert Operation @4-00993BC6

    Protected Sub viewMaintainSearchRequest_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequest Insert Operation

'Record Form viewMaintainSearchRequest BeforeInsert tail @4-CF511C3D
    viewMaintainSearchRequestParameters()
    viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest BeforeInsert tail

'Record Form viewMaintainSearchRequest AfterInsert tail  @4-1B133DD0
        ErrorFlag=(viewMaintainSearchRequestErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest AfterInsert tail 

'Record Form viewMaintainSearchRequest Update Operation @4-66525082

    Protected Sub viewMaintainSearchRequest_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequest Update Operation

'Record Form viewMaintainSearchRequest Before Update tail @4-CF511C3D
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest Before Update tail

'Record Form viewMaintainSearchRequest Update Operation tail @4-1B133DD0
        ErrorFlag=(viewMaintainSearchRequestErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Update Operation tail

'Record Form viewMaintainSearchRequest Delete Operation @4-BE5D2BAE
    Protected Sub viewMaintainSearchRequest_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewMaintainSearchRequest Delete Operation

'Record Form BeforeDelete tail @4-CF511C3D
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-0F56CE2C
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewMaintainSearchRequest Cancel Operation @4-60657F47

    Protected Sub viewMaintainSearchRequest_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewMaintainSearchRequestLoadItemFromRequest(item, True)
'End Record Form viewMaintainSearchRequest Cancel Operation

'Record Form viewMaintainSearchRequest Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewMaintainSearchRequest Cancel Operation tail

'Record Form viewMaintainSearchRequest Search Operation @4-136E5E10
    Protected Sub viewMaintainSearchRequest_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewMaintainSearchRequestIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewMaintainSearchRequestItem = New viewMaintainSearchRequestItem()
        viewMaintainSearchRequestLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequest Search Operation

'Button Button_DoSearch OnClick. @6-557E767F
        If CType(sender,Control).ID = "viewMaintainSearchRequestButton_DoSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestRedirectUrl("", "export;s_HOME_SCHOOL_ID;s_ENROLMENT_YEAR;s_SCHOOLNAME;hidden_auto")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @6-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewMaintainSearchRequest Search Operation tail @4-8B415353
        ErrorFlag = viewMaintainSearchRequestErrors.Count > 0
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewMaintainSearchRequests_HOME_SCHOOL_ID.Text <> "",("s_HOME_SCHOOL_ID=" & Server.UrlEncode(viewMaintainSearchRequests_HOME_SCHOOL_ID.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewMaintainSearchRequests_ENROLMENT_YEAR.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_SCHOOLNAME.Text <> "",("s_SCHOOLNAME=" & Server.UrlEncode(viewMaintainSearchRequests_SCHOOLNAME.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequesthidden_auto.Value <> "",("hidden_auto=" & Server.UrlEncode(viewMaintainSearchRequesthidden_auto.Value) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-541E81A6
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MaintainSearchRequest_AdvancedContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewMaintainSearchRequest1Data = New viewMaintainSearchRequest1DataProvider()
        viewMaintainSearchRequest1Operations = New FormSupportedOperations(False, True, False, False, False)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, True, True, True)
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

