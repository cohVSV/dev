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

Namespace DECV_PROD2007.MaintainSearchRequest_Primary 'Namespace @1-2DF64896

'Forms Definition @1-33A3CF82
Public Class [MaintainSearchRequest_PrimaryPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EEEDA98F
    Protected viewPrimaryTeacherSearchR1Data As viewPrimaryTeacherSearchR1DataProvider
    Protected viewPrimaryTeacherSearchR1Operations As FormSupportedOperations
    Protected viewPrimaryTeacherSearchR1CurrentRowNumber As Integer
    Protected viewPrimaryTeacherSearchRData As viewPrimaryTeacherSearchRDataProvider
    Protected viewPrimaryTeacherSearchRErrors As NameValueCollection = New NameValueCollection()
    Protected viewPrimaryTeacherSearchROperations As FormSupportedOperations
    Protected viewPrimaryTeacherSearchRIsSubmitted As Boolean = False
    Protected MaintainSearchRequest_PrimaryContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-C3D21411
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            viewPrimaryTeacherSearchR1Bind
            viewPrimaryTeacherSearchRShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid viewPrimaryTeacherSearchR1 Bind @3-7CAB1DE9

    Protected Sub viewPrimaryTeacherSearchR1Bind()
        If Not viewPrimaryTeacherSearchR1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewPrimaryTeacherSearchR1",GetType(viewPrimaryTeacherSearchR1DataProvider.SortFields), 50, 100)
        End If
'End Grid viewPrimaryTeacherSearchR1 Bind

'Grid Form viewPrimaryTeacherSearchR1 BeforeShow tail @3-B8ED502D
        viewPrimaryTeacherSearchR1Parameters()
        viewPrimaryTeacherSearchR1Data.SortField = CType(ViewState("viewPrimaryTeacherSearchR1SortField"),viewPrimaryTeacherSearchR1DataProvider.SortFields)
        viewPrimaryTeacherSearchR1Data.SortDir = CType(ViewState("viewPrimaryTeacherSearchR1SortDir"),SortDirections)
        viewPrimaryTeacherSearchR1Data.PageNumber = CInt(ViewState("viewPrimaryTeacherSearchR1PageNumber"))
        viewPrimaryTeacherSearchR1Data.RecordsPerPage = CInt(ViewState("viewPrimaryTeacherSearchR1PageSize"))
        viewPrimaryTeacherSearchR1Repeater.DataSource = viewPrimaryTeacherSearchR1Data.GetResultSet(PagesCount, viewPrimaryTeacherSearchR1Operations)
        ViewState("viewPrimaryTeacherSearchR1PagesCount") = PagesCount
        Dim item As viewPrimaryTeacherSearchR1Item = New viewPrimaryTeacherSearchR1Item()
        viewPrimaryTeacherSearchR1Repeater.DataBind
        FooterIndex = viewPrimaryTeacherSearchR1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            viewPrimaryTeacherSearchR1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PASTORAL_CARE_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_PASTORAL_CARE_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewPrimaryTeacherSearchR1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)

'End Grid Form viewPrimaryTeacherSearchR1 BeforeShow tail

'Grid viewPrimaryTeacherSearchR1 Event BeforeShow. Action Custom Code @40-73254650
    ' -------------------------
	' ERA: '20-feb-2010|EA| only display if something to display, and not if initial open
	if (isnothing(viewPrimaryTeacherSearchR1Data.Urls_SURNAME) and isnothing(viewPrimaryTeacherSearchR1Data.urls_student_id)) then
		viewPrimaryTeacherSearchR1Repeater.visible = false
    end if
    ' -------------------------
'End Grid viewPrimaryTeacherSearchR1 Event BeforeShow. Action Custom Code

'Grid viewPrimaryTeacherSearchR1 Bind tail @3-E31F8E2A
    End Sub
'End Grid viewPrimaryTeacherSearchR1 Bind tail

'Grid viewPrimaryTeacherSearchR1 Table Parameters @3-CFE222EA

    Protected Sub viewPrimaryTeacherSearchR1Parameters()
        Try
            viewPrimaryTeacherSearchR1Data.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            viewPrimaryTeacherSearchR1Data.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewPrimaryTeacherSearchR1Data.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=viewPrimaryTeacherSearchR1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(viewPrimaryTeacherSearchR1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid viewPrimaryTeacherSearchR1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid viewPrimaryTeacherSearchR1 Table Parameters

'Grid viewPrimaryTeacherSearchR1 ItemDataBound event @3-36192077

    Protected Sub viewPrimaryTeacherSearchR1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as viewPrimaryTeacherSearchR1Item = CType(e.Item.DataItem,viewPrimaryTeacherSearchR1Item)
        Dim Item as viewPrimaryTeacherSearchR1Item = DataItem
        Dim FormDataSource As viewPrimaryTeacherSearchR1Item() = CType(viewPrimaryTeacherSearchR1Repeater.DataSource, viewPrimaryTeacherSearchR1Item())
        Dim viewPrimaryTeacherSearchR1DataRows As Integer = FormDataSource.Length
        Dim viewPrimaryTeacherSearchR1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            viewPrimaryTeacherSearchR1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(viewPrimaryTeacherSearchR1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, viewPrimaryTeacherSearchR1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim viewPrimaryTeacherSearchR1STUDENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1STUDENT_ID"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1ENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1ENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1STAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1STAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1PASTORAL_CARE_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1PASTORAL_CARE_ID"),System.Web.UI.WebControls.Literal)
            Dim viewPrimaryTeacherSearchR1ENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewPrimaryTeacherSearchR1ENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
        End If
'End Grid viewPrimaryTeacherSearchR1 ItemDataBound event

'Grid viewPrimaryTeacherSearchR1 ItemDataBound event tail @3-8E61BCEC
        If viewPrimaryTeacherSearchR1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(viewPrimaryTeacherSearchR1CurrentRowNumber, ListItemType.Item)
            viewPrimaryTeacherSearchR1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            viewPrimaryTeacherSearchR1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid viewPrimaryTeacherSearchR1 ItemDataBound event tail

'Grid viewPrimaryTeacherSearchR1 ItemCommand event @3-E8B3C081

    Protected Sub viewPrimaryTeacherSearchR1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= viewPrimaryTeacherSearchR1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("viewPrimaryTeacherSearchR1SortDir"),SortDirections) = SortDirections._Asc And ViewState("viewPrimaryTeacherSearchR1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("viewPrimaryTeacherSearchR1SortDir")=SortDirections._Desc
                Else
                    ViewState("viewPrimaryTeacherSearchR1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("viewPrimaryTeacherSearchR1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As viewPrimaryTeacherSearchR1DataProvider.SortFields = 0
            ViewState("viewPrimaryTeacherSearchR1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("viewPrimaryTeacherSearchR1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("viewPrimaryTeacherSearchR1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("viewPrimaryTeacherSearchR1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("viewPrimaryTeacherSearchR1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            viewPrimaryTeacherSearchR1Bind
        End If
    End Sub
'End Grid viewPrimaryTeacherSearchR1 ItemCommand event

'Record Form viewPrimaryTeacherSearchR Parameters @4-679B0342

    Protected Sub viewPrimaryTeacherSearchRParameters()
        Dim item As new viewPrimaryTeacherSearchRItem
        Try
        Catch e As Exception
            viewPrimaryTeacherSearchRErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewPrimaryTeacherSearchR Parameters

'Record Form viewPrimaryTeacherSearchR Show method @4-A9B1A238
    Protected Sub viewPrimaryTeacherSearchRShow()
        If viewPrimaryTeacherSearchROperations.None Then
            viewPrimaryTeacherSearchRHolder.Visible = False
            Return
        End If
        Dim item As viewPrimaryTeacherSearchRItem = viewPrimaryTeacherSearchRItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewPrimaryTeacherSearchROperations.AllowRead
        item.ClearParametersHref = "MaintainSearchRequest_Primary.aspx"
        item.Link1Href = "MaintainSearchRequest.aspx"
        viewPrimaryTeacherSearchRErrors.Add(item.errors)
        If viewPrimaryTeacherSearchRErrors.Count > 0 Then
            viewPrimaryTeacherSearchRShowErrors()
            Return
        End If
'End Record Form viewPrimaryTeacherSearchR Show method

'Record Form viewPrimaryTeacherSearchR BeforeShow tail @4-ACF266E9
        viewPrimaryTeacherSearchRParameters()
        viewPrimaryTeacherSearchRData.FillItem(item, IsInsertMode)
        viewPrimaryTeacherSearchRHolder.DataBind()
        viewPrimaryTeacherSearchRs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        viewPrimaryTeacherSearchRs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        viewPrimaryTeacherSearchRs_ENROLMENT_YEAR.Text=item.s_ENROLMENT_YEAR.GetFormattedValue()
        viewPrimaryTeacherSearchRClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewPrimaryTeacherSearchRClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR", ViewState)
        viewPrimaryTeacherSearchRLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        viewPrimaryTeacherSearchRLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("None","", ViewState)
'End Record Form viewPrimaryTeacherSearchR BeforeShow tail

'Record Form viewPrimaryTeacherSearchR Show method tail @4-68AA7BEC
        If viewPrimaryTeacherSearchRErrors.Count > 0 Then
            viewPrimaryTeacherSearchRShowErrors()
        End If
    End Sub
'End Record Form viewPrimaryTeacherSearchR Show method tail

'Record Form viewPrimaryTeacherSearchR LoadItemFromRequest method @4-338186C6

    Protected Sub viewPrimaryTeacherSearchRLoadItemFromRequest(item As viewPrimaryTeacherSearchRItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(viewPrimaryTeacherSearchRs_SURNAME.UniqueID))
        If ControlCustomValues("viewPrimaryTeacherSearchRs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(viewPrimaryTeacherSearchRs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("viewPrimaryTeacherSearchRs_SURNAME"))
        End If
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewPrimaryTeacherSearchRs_STUDENT_ID.UniqueID))
        If ControlCustomValues("viewPrimaryTeacherSearchRs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(viewPrimaryTeacherSearchRs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("viewPrimaryTeacherSearchRs_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            viewPrimaryTeacherSearchRErrors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"s_STUDENT_ID"))
        End Try
        Try
        item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewPrimaryTeacherSearchRs_ENROLMENT_YEAR.UniqueID))
        If ControlCustomValues("viewPrimaryTeacherSearchRs_ENROLMENT_YEAR") Is Nothing Then
            item.s_ENROLMENT_YEAR.SetValue(viewPrimaryTeacherSearchRs_ENROLMENT_YEAR.Text)
        Else
            item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewPrimaryTeacherSearchRs_ENROLMENT_YEAR"))
        End If
        Catch ae As ArgumentException
            viewPrimaryTeacherSearchRErrors.Add("s_ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"s_ENROLMENT_YEAR"))
        End Try
        If EnableValidation Then
            item.Validate(viewPrimaryTeacherSearchRData)
        End If
        viewPrimaryTeacherSearchRErrors.Add(item.errors)
    End Sub
'End Record Form viewPrimaryTeacherSearchR LoadItemFromRequest method

'Record Form viewPrimaryTeacherSearchR GetRedirectUrl method @4-0487224E

    Protected Function GetviewPrimaryTeacherSearchRRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "MaintainSearchRequest_Primary.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewPrimaryTeacherSearchR GetRedirectUrl method

'Record Form viewPrimaryTeacherSearchR ShowErrors method @4-495CE60A

    Protected Sub viewPrimaryTeacherSearchRShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To viewPrimaryTeacherSearchRErrors.Count - 1
        Select Case viewPrimaryTeacherSearchRErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & viewPrimaryTeacherSearchRErrors(i)
        End Select
        Next i
        viewPrimaryTeacherSearchRError.Visible = True
        viewPrimaryTeacherSearchRErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form viewPrimaryTeacherSearchR ShowErrors method

'Record Form viewPrimaryTeacherSearchR Insert Operation @4-6C20AC02

    Protected Sub viewPrimaryTeacherSearchR_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        viewPrimaryTeacherSearchRIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewPrimaryTeacherSearchR Insert Operation

'Record Form viewPrimaryTeacherSearchR BeforeInsert tail @4-0359E609
    viewPrimaryTeacherSearchRParameters()
    viewPrimaryTeacherSearchRLoadItemFromRequest(item, EnableValidation)
'End Record Form viewPrimaryTeacherSearchR BeforeInsert tail

'Record Form viewPrimaryTeacherSearchR AfterInsert tail  @4-F5A97428
        ErrorFlag=(viewPrimaryTeacherSearchRErrors.Count > 0)
        If ErrorFlag Then
            viewPrimaryTeacherSearchRShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewPrimaryTeacherSearchR AfterInsert tail 

'Record Form viewPrimaryTeacherSearchR Update Operation @4-FB5088B5

    Protected Sub viewPrimaryTeacherSearchR_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewPrimaryTeacherSearchRIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewPrimaryTeacherSearchR Update Operation

'Record Form viewPrimaryTeacherSearchR Before Update tail @4-0359E609
        viewPrimaryTeacherSearchRParameters()
        viewPrimaryTeacherSearchRLoadItemFromRequest(item, EnableValidation)
'End Record Form viewPrimaryTeacherSearchR Before Update tail

'Record Form viewPrimaryTeacherSearchR Update Operation tail @4-F5A97428
        ErrorFlag=(viewPrimaryTeacherSearchRErrors.Count > 0)
        If ErrorFlag Then
            viewPrimaryTeacherSearchRShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewPrimaryTeacherSearchR Update Operation tail

'Record Form viewPrimaryTeacherSearchR Delete Operation @4-320C56DA
    Protected Sub viewPrimaryTeacherSearchR_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewPrimaryTeacherSearchRIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewPrimaryTeacherSearchR Delete Operation

'Record Form BeforeDelete tail @4-0359E609
        viewPrimaryTeacherSearchRParameters()
        viewPrimaryTeacherSearchRLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-9E2598CC
        If ErrorFlag Then
            viewPrimaryTeacherSearchRShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewPrimaryTeacherSearchR Cancel Operation @4-63564738

    Protected Sub viewPrimaryTeacherSearchR_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        viewPrimaryTeacherSearchRIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewPrimaryTeacherSearchRLoadItemFromRequest(item, True)
'End Record Form viewPrimaryTeacherSearchR Cancel Operation

'Record Form viewPrimaryTeacherSearchR Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewPrimaryTeacherSearchR Cancel Operation tail

'Record Form viewPrimaryTeacherSearchR Search Operation @4-F3519196
    Protected Sub viewPrimaryTeacherSearchR_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewPrimaryTeacherSearchRIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewPrimaryTeacherSearchRItem = New viewPrimaryTeacherSearchRItem()
        viewPrimaryTeacherSearchRLoadItemFromRequest(item, EnableValidation)
'End Record Form viewPrimaryTeacherSearchR Search Operation

'Button Button_DoSearch OnClick. @6-546BAA23
        If CType(sender,Control).ID = "viewPrimaryTeacherSearchRButton_DoSearch" Then
            RedirectUrl = GetviewPrimaryTeacherSearchRRedirectUrl("", "s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @6-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewPrimaryTeacherSearchR Search Operation tail @4-D862FDFA
        ErrorFlag = viewPrimaryTeacherSearchRErrors.Count > 0
        If ErrorFlag Then
            viewPrimaryTeacherSearchRShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewPrimaryTeacherSearchRs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(viewPrimaryTeacherSearchRs_SURNAME.Text) & "&"), "")
            Params = Params & IIf(viewPrimaryTeacherSearchRs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(viewPrimaryTeacherSearchRs_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(viewPrimaryTeacherSearchRs_ENROLMENT_YEAR.Text <> "",("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewPrimaryTeacherSearchRs_ENROLMENT_YEAR.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewPrimaryTeacherSearchR Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A6D10E1A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        MaintainSearchRequest_PrimaryContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        viewPrimaryTeacherSearchR1Data = New viewPrimaryTeacherSearchR1DataProvider()
        viewPrimaryTeacherSearchR1Operations = New FormSupportedOperations(False, True, False, False, False)
        viewPrimaryTeacherSearchRData = New viewPrimaryTeacherSearchRDataProvider()
        viewPrimaryTeacherSearchROperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","8","9","11"})) Then
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

