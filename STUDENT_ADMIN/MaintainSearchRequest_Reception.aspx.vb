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

Namespace DECV_PROD2007.MaintainSearchRequest_Reception 'Namespace @1-22CC6F09

'Forms Definition @1-EF57F058
Public Class [MaintainSearchRequest_ReceptionPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-1F04F5CF
    Protected viewMaintainSearchRequest1Data As viewMaintainSearchRequest1DataProvider
    Protected viewMaintainSearchRequest1Operations As FormSupportedOperations
    Protected viewMaintainSearchRequest1CurrentRowNumber As Integer
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestErrors As NameValueCollection = New NameValueCollection()
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestIsSubmitted As Boolean = False
    Protected viewMaintainSearchRequest2Data As viewMaintainSearchRequest2DataProvider
    Protected viewMaintainSearchRequest2Operations As FormSupportedOperations
    Protected viewMaintainSearchRequest2CurrentRowNumber As Integer
    Protected MaintainSearchRequest_ReceptionContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-F004BAB5
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewMaintainSearchRequest1Bind
            viewMaintainSearchRequestShow()
            viewMaintainSearchRequest2Bind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid viewMaintainSearchRequest1 Bind @3-992F77B9

    Protected Sub viewMaintainSearchRequest1Bind()
        If Not viewMaintainSearchRequest1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest1",GetType(viewMaintainSearchRequest1DataProvider.SortFields), 50, 100)
        End If
'End Grid viewMaintainSearchRequest1 Bind

'Grid Form viewMaintainSearchRequest1 BeforeShow tail @3-D906C015
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
        Dim Sorter_Postal_ADDR1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Postal_ADDR1Sorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Postal_SUBURB_TOWNSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Postal_SUBURB_TOWNSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Postal_PHONE_ASorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Postal_PHONE_ASorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Postal_EMAIL_ADDRESSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Postal_EMAIL_ADDRESSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Curr_ADDR1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Curr_ADDR1Sorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Curr_SUBURB_TOWNSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Curr_SUBURB_TOWNSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Curr_PHONE_ASorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Curr_PHONE_ASorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_Curr_EMAIL_ADDRESSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest1Repeater.Controls(0).FindControl("Sorter_Curr_EMAIL_ADDRESSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewMaintainSearchRequest1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {10,50,100,250,500}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = Server.HtmlEncode(item.viewMaintainSearchRequest1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form viewMaintainSearchRequest1 BeforeShow tail

'Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records @12-822AFFB6
            viewMaintainSearchRequest1viewMaintainSearchRequest1_TotalRecords.Text = viewMaintainSearchRequest1Data.RecordCount.ToString()
'End Label viewMaintainSearchRequest1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid viewMaintainSearchRequest1 Event BeforeShow. Action Custom Code @70-73254650
    ' -------------------------
     ' ERA: 23-Aug-2010|EA| Hide results panel if nothing entered.
	if (IsNothing(viewMaintainSearchRequest1Data.Urls_FIRST_NAME) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_ADDR1) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_PHONE_A) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_EMAIL_ADDRESS)) then
		viewMaintainSearchRequest1Repeater.visible = false
    end if
    ' -------------------------
'End Grid viewMaintainSearchRequest1 Event BeforeShow. Action Custom Code

'Grid viewMaintainSearchRequest1 Bind tail @3-E31F8E2A
    End Sub
'End Grid viewMaintainSearchRequest1 Bind tail

'Grid viewMaintainSearchRequest1 Table Parameters @3-782C1C03

    Protected Sub viewMaintainSearchRequest1Parameters()
        Try
            viewMaintainSearchRequest1Data.Urls_FIRST_NAME = TextParameter.GetParam("s_FIRST_NAME", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest1Data.Urls_Postal_ADDR1 = TextParameter.GetParam("s_Postal_ADDR1", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest1Data.Urls_Postal_PHONE_A = TextParameter.GetParam("s_Postal_PHONE_A", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest1Data.Urls_Postal_EMAIL_ADDRESS = TextParameter.GetParam("s_Postal_EMAIL_ADDRESS", ParameterSourceType.URL, "", Nothing, false)

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

'Grid viewMaintainSearchRequest1 ItemDataBound event @3-C7757179

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
            Dim viewMaintainSearchRequest1Postal_ADDR1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_ADDR1"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_SUBURB_TOWN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_SUBURB_TOWN"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_PHONE_A As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_PHONE_A"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_EMAIL_ADDRESS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_EMAIL_ADDRESS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_ADDR1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_ADDR1"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_SUBURB_TOWN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_SUBURB_TOWN"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_PHONE_A As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_PHONE_A"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_EMAIL_ADDRESS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_EMAIL_ADDRESS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_ADDR2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_ADDR2"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_PHONE_B As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_PHONE_B"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_EMAIL_ADDRESS2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_EMAIL_ADDRESS2"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_ADDR2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_ADDR2"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_PHONE_B As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_PHONE_B"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_EMAIL_ADDRESS2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_EMAIL_ADDRESS2"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Postal_POSTCODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Postal_POSTCODE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1Curr_POSTCODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1Curr_POSTCODE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1STUDENT_MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1STUDENT_MOBILE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest1STUDENT_EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest1STUDENT_EMAIL"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            DataItem.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((Now.Year()).ToString()))
            viewMaintainSearchRequest1STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","", ViewState)
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

'Record Form viewMaintainSearchRequest Show method @4-6B51F8EF
    Protected Sub viewMaintainSearchRequestShow()
        If viewMaintainSearchRequestOperations.None Then
            viewMaintainSearchRequestHolder.Visible = False
            Return
        End If
        Dim item As viewMaintainSearchRequestItem = viewMaintainSearchRequestItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewMaintainSearchRequestOperations.AllowRead
        item.ClearParametersHref = "MaintainSearchRequest_Reception.aspx"
        item.Link1Href = "MaintainSearchRequest.aspx"
        viewMaintainSearchRequestErrors.Add(item.errors)
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
            Return
        End If
'End Record Form viewMaintainSearchRequest Show method

'Record Form viewMaintainSearchRequest BeforeShow tail @4-9558D1D1
        viewMaintainSearchRequestParameters()
        viewMaintainSearchRequestData.FillItem(item, IsInsertMode)
        viewMaintainSearchRequestHolder.DataBind()
        viewMaintainSearchRequests_FIRST_NAME.Text=item.s_FIRST_NAME.GetFormattedValue()
        viewMaintainSearchRequests_Postal_ADDR1.Text=item.s_Postal_ADDR1.GetFormattedValue()
        viewMaintainSearchRequests_Postal_PHONE_A.Text=item.s_Postal_PHONE_A.GetFormattedValue()
        viewMaintainSearchRequests_Postal_EMAIL_ADDRESS.Text=item.s_Postal_EMAIL_ADDRESS.GetFormattedValue()
        viewMaintainSearchRequestClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_FIRST_NAME;s_Postal_ADDR1;s_Postal_PHONE_A;s_Postal_EMAIL_ADDRESS", ViewState)
        viewMaintainSearchRequestLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState)
'End Record Form viewMaintainSearchRequest BeforeShow tail

'Record Form viewMaintainSearchRequest Show method tail @4-D3A5B4A7
        If viewMaintainSearchRequestErrors.Count > 0 Then
            viewMaintainSearchRequestShowErrors()
        End If
    End Sub
'End Record Form viewMaintainSearchRequest Show method tail

'Record Form viewMaintainSearchRequest LoadItemFromRequest method @4-559894F3

    Protected Sub viewMaintainSearchRequestLoadItemFromRequest(item As viewMaintainSearchRequestItem, ByVal EnableValidation As Boolean)
        item.s_FIRST_NAME.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_FIRST_NAME.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_FIRST_NAME") Is Nothing Then
            item.s_FIRST_NAME.SetValue(viewMaintainSearchRequests_FIRST_NAME.Text)
        Else
            item.s_FIRST_NAME.SetValue(ControlCustomValues("viewMaintainSearchRequests_FIRST_NAME"))
        End If
        item.s_Postal_ADDR1.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_Postal_ADDR1.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_Postal_ADDR1") Is Nothing Then
            item.s_Postal_ADDR1.SetValue(viewMaintainSearchRequests_Postal_ADDR1.Text)
        Else
            item.s_Postal_ADDR1.SetValue(ControlCustomValues("viewMaintainSearchRequests_Postal_ADDR1"))
        End If
        item.s_Postal_PHONE_A.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_Postal_PHONE_A.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_Postal_PHONE_A") Is Nothing Then
            item.s_Postal_PHONE_A.SetValue(viewMaintainSearchRequests_Postal_PHONE_A.Text)
        Else
            item.s_Postal_PHONE_A.SetValue(ControlCustomValues("viewMaintainSearchRequests_Postal_PHONE_A"))
        End If
        item.s_Postal_EMAIL_ADDRESS.IsEmpty = IsNothing(Request.Form(viewMaintainSearchRequests_Postal_EMAIL_ADDRESS.UniqueID))
        If ControlCustomValues("viewMaintainSearchRequests_Postal_EMAIL_ADDRESS") Is Nothing Then
            item.s_Postal_EMAIL_ADDRESS.SetValue(viewMaintainSearchRequests_Postal_EMAIL_ADDRESS.Text)
        Else
            item.s_Postal_EMAIL_ADDRESS.SetValue(ControlCustomValues("viewMaintainSearchRequests_Postal_EMAIL_ADDRESS"))
        End If
        If EnableValidation Then
            item.Validate(viewMaintainSearchRequestData)
        End If
        viewMaintainSearchRequestErrors.Add(item.errors)
    End Sub
'End Record Form viewMaintainSearchRequest LoadItemFromRequest method

'Record Form viewMaintainSearchRequest GetRedirectUrl method @4-DFFAA027

    Protected Function GetviewMaintainSearchRequestRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "MaintainSearchRequest_Reception.aspx"
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

'Button Button_DoSearch OnClick. @6-0E2F2D9C
        If CType(sender,Control).ID = "viewMaintainSearchRequestButton_DoSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestRedirectUrl("", "s_FIRST_NAME;s_Postal_ADDR1;s_Postal_PHONE_A;s_Postal_EMAIL_ADDRESS")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @6-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewMaintainSearchRequest Search Operation tail @4-A1226DF0
        ErrorFlag = viewMaintainSearchRequestErrors.Count > 0
        If ErrorFlag Then
            viewMaintainSearchRequestShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewMaintainSearchRequests_FIRST_NAME.Text <> "",("s_FIRST_NAME=" & Server.UrlEncode(viewMaintainSearchRequests_FIRST_NAME.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_Postal_ADDR1.Text <> "",("s_Postal_ADDR1=" & Server.UrlEncode(viewMaintainSearchRequests_Postal_ADDR1.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_Postal_PHONE_A.Text <> "",("s_Postal_PHONE_A=" & Server.UrlEncode(viewMaintainSearchRequests_Postal_PHONE_A.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequests_Postal_EMAIL_ADDRESS.Text <> "",("s_Postal_EMAIL_ADDRESS=" & Server.UrlEncode(viewMaintainSearchRequests_Postal_EMAIL_ADDRESS.Text) & "&"), "")
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

'Grid viewMaintainSearchRequest2 Bind @86-9302B6D4

    Protected Sub viewMaintainSearchRequest2Bind()
        If Not viewMaintainSearchRequest2Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest2",GetType(viewMaintainSearchRequest2DataProvider.SortFields), 50, 100)
        End If
'End Grid viewMaintainSearchRequest2 Bind

'Grid Form viewMaintainSearchRequest2 BeforeShow tail @86-07E489B3
        viewMaintainSearchRequest2Parameters()
        viewMaintainSearchRequest2Data.SortField = CType(ViewState("viewMaintainSearchRequest2SortField"),viewMaintainSearchRequest2DataProvider.SortFields)
        viewMaintainSearchRequest2Data.SortDir = CType(ViewState("viewMaintainSearchRequest2SortDir"),SortDirections)
        viewMaintainSearchRequest2Data.PageNumber = CInt(ViewState("viewMaintainSearchRequest2PageNumber"))
        viewMaintainSearchRequest2Data.RecordsPerPage = CInt(ViewState("viewMaintainSearchRequest2PageSize"))
        viewMaintainSearchRequest2Repeater.DataSource = viewMaintainSearchRequest2Data.GetResultSet(PagesCount, viewMaintainSearchRequest2Operations)
        ViewState("viewMaintainSearchRequest2PagesCount") = PagesCount
        Dim item As viewMaintainSearchRequest2Item = New viewMaintainSearchRequest2Item()
        viewMaintainSearchRequest2Repeater.DataBind
        FooterIndex = viewMaintainSearchRequest2Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RELATIONSHIPSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_RELATIONSHIPSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_HOME_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_HOME_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_WORK_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_WORK_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MOBILESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_MOBILESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_EMAILSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequest2Repeater.Controls(0).FindControl("Sorter_EMAILSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewMaintainSearchRequest2Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {10,50,100,250,500}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form viewMaintainSearchRequest2 BeforeShow tail

'Grid viewMaintainSearchRequest2 Event BeforeShow. Action Custom Code @112-73254650
    ' -------------------------
    ' ERA: 20-Aug-2012|EA| Hide results panel if nothing entered (ie: same as Contact panel)
	if (IsNothing(viewMaintainSearchRequest1Data.Urls_FIRST_NAME) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_ADDR1) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_PHONE_A) and IsNothing(viewMaintainSearchRequest1Data.Urls_Postal_EMAIL_ADDRESS)) then
		viewMaintainSearchRequest2Repeater.visible = false
    end if
    ' -------------------------
'End Grid viewMaintainSearchRequest2 Event BeforeShow. Action Custom Code

'Grid viewMaintainSearchRequest2 Bind tail @86-E31F8E2A
    End Sub
'End Grid viewMaintainSearchRequest2 Bind tail

'Grid viewMaintainSearchRequest2 Table Parameters @86-716A86FF

    Protected Sub viewMaintainSearchRequest2Parameters()
        Try
            viewMaintainSearchRequest2Data.Urls_FIRST_NAME = TextParameter.GetParam("s_FIRST_NAME", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest2Data.Urls_POSTAL_PHONE_A = TextParameter.GetParam("s_POSTAL_PHONE_A", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequest2Data.Urls_POSTAL_EMAIL_ADDRESS = TextParameter.GetParam("s_POSTAL_EMAIL_ADDRESS", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewMaintainSearchRequest2Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewMaintainSearchRequest2Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewMaintainSearchRequest2: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewMaintainSearchRequest2 Table Parameters

'Grid viewMaintainSearchRequest2 ItemDataBound event @86-47FFC610

    Protected Sub viewMaintainSearchRequest2ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewMaintainSearchRequest2Item = CType(e.Item.DataItem,viewMaintainSearchRequest2Item)
        Dim Item as viewMaintainSearchRequest2Item = DataItem
        Dim FormDataSource As viewMaintainSearchRequest2Item() = CType(viewMaintainSearchRequest2Repeater.DataSource, viewMaintainSearchRequest2Item())
        Dim viewMaintainSearchRequest2DataRows As Integer = FormDataSource.Length
        Dim viewMaintainSearchRequest2IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewMaintainSearchRequest2CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewMaintainSearchRequest2Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewMaintainSearchRequest2CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewMaintainSearchRequest2STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim viewMaintainSearchRequest2SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2SURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2RELATIONSHIP As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2RELATIONSHIP"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2MOBILE"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequest2EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequest2EMAIL"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            DataItem.STUDENT_IDHrefParameters.Add("ENROLMENT_YEAR",System.Web.HttpUtility.UrlEncode((Now.Year()).ToString()))
            viewMaintainSearchRequest2STUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","", ViewState)
        End If
'End Grid viewMaintainSearchRequest2 ItemDataBound event

'Grid viewMaintainSearchRequest2 ItemDataBound event tail @86-4F9B7753
        If viewMaintainSearchRequest2IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewMaintainSearchRequest2CurrentRowNumber, ListItemType.Item)
            viewMaintainSearchRequest2Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewMaintainSearchRequest2ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewMaintainSearchRequest2 ItemDataBound event tail

'Grid viewMaintainSearchRequest2 ItemCommand event @86-08B44135

    Protected Sub viewMaintainSearchRequest2ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewMaintainSearchRequest2Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewMaintainSearchRequest2SortDir"),SortDirections) = SortDirections._Asc And ViewState("viewMaintainSearchRequest2SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewMaintainSearchRequest2SortDir")=SortDirections._Desc
                Else
                    ViewState("viewMaintainSearchRequest2SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewMaintainSearchRequest2SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewMaintainSearchRequest2DataProvider.SortFields = 0
            ViewState("viewMaintainSearchRequest2SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewMaintainSearchRequest2PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewMaintainSearchRequest2PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewMaintainSearchRequest2PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewMaintainSearchRequest2PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewMaintainSearchRequest2Bind
        End If
    End Sub
'End Grid viewMaintainSearchRequest2 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-92E5A0EC
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MaintainSearchRequest_ReceptionContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewMaintainSearchRequest1Data = New viewMaintainSearchRequest1DataProvider()
        viewMaintainSearchRequest1Operations = New FormSupportedOperations(False, True, False, False, False)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, True, True, True)
        viewMaintainSearchRequest2Data = New viewMaintainSearchRequest2DataProvider()
        viewMaintainSearchRequest2Operations = New FormSupportedOperations(False, True, False, False, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","8","9","11","12"})) Then
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

