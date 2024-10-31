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

Namespace DECV_PROD2007.Staff_Inductions_ByStaff 'Namespace @1-A4B3C417

'Forms Definition @1-9A6C4C8E
Public Class [Staff_Inductions_ByStaffPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-E2CF14E6
    Protected STAFF_INDUCTIONS_COURSES1Data As STAFF_INDUCTIONS_COURSES1DataProvider
    Protected STAFF_INDUCTIONS_COURSES1Operations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSES1CurrentRowNumber As Integer
    Protected STAFF_INDUCTIONS_COURSESData As STAFF_INDUCTIONS_COURSESDataProvider
    Protected STAFF_INDUCTIONS_COURSESErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_INDUCTIONS_COURSESOperations As FormSupportedOperations
    Protected STAFF_INDUCTIONS_COURSESIsSubmitted As Boolean = False
    Protected Staff_Inductions_ByStaffContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-2EE7F9FE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STAFF_INDUCTIONS_COURSES1Bind
            STAFF_INDUCTIONS_COURSESShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STAFF_INDUCTIONS_COURSES1 Bind @3-FDE75338

    Protected Sub STAFF_INDUCTIONS_COURSES1Bind()
        If Not STAFF_INDUCTIONS_COURSES1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF_INDUCTIONS_COURSES1",GetType(STAFF_INDUCTIONS_COURSES1DataProvider.SortFields), 30, 100)
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 Bind

'Grid Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail @3-9E5DE968
        STAFF_INDUCTIONS_COURSES1Parameters()
        STAFF_INDUCTIONS_COURSES1Data.SortField = CType(ViewState("STAFF_INDUCTIONS_COURSES1SortField"),STAFF_INDUCTIONS_COURSES1DataProvider.SortFields)
        STAFF_INDUCTIONS_COURSES1Data.SortDir = CType(ViewState("STAFF_INDUCTIONS_COURSES1SortDir"),SortDirections)
        STAFF_INDUCTIONS_COURSES1Data.PageNumber = CInt(ViewState("STAFF_INDUCTIONS_COURSES1PageNumber"))
        STAFF_INDUCTIONS_COURSES1Data.RecordsPerPage = CInt(ViewState("STAFF_INDUCTIONS_COURSES1PageSize"))
        STAFF_INDUCTIONS_COURSES1Repeater.DataSource = STAFF_INDUCTIONS_COURSES1Data.GetResultSet(PagesCount, STAFF_INDUCTIONS_COURSES1Operations)
        ViewState("STAFF_INDUCTIONS_COURSES1PagesCount") = PagesCount
        Dim item As STAFF_INDUCTIONS_COURSES1Item = New STAFF_INDUCTIONS_COURSES1Item()
        STAFF_INDUCTIONS_COURSES1Repeater.DataBind
        FooterIndex = STAFF_INDUCTIONS_COURSES1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STAFF_INDUCTIONS_COURSES1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_STAFF_INDUCTIONS_PROGRESS_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DATE_COMPLETEDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_DATE_COMPLETEDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_staffnameSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_staffnameSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_INDUCTION_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("Sorter_INDUCTION_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STAFF_INDUCTIONS_COURSES1linkNewInduction As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(FooterIndex).FindControl("STAFF_INDUCTIONS_COURSES1linkNewInduction"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim STAFF_INDUCTIONS_COURSES1linkNewInduction1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("STAFF_INDUCTIONS_COURSES1linkNewInduction1"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim STAFF_INDUCTIONS_COURSES1Panel_header_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(STAFF_INDUCTIONS_COURSES1Repeater.Controls(0).FindControl("STAFF_INDUCTIONS_COURSES1Panel_header_editbutton"),System.Web.UI.WebControls.PlaceHolder)

        item.linkNewInductionHref = "Staff_Inductions_ByStaff_maint.aspx"
        item.linkNewInduction1Href = "Staff_Inductions_ByStaff_maint.aspx"
        STAFF_INDUCTIONS_COURSES1linkNewInduction.InnerText += item.linkNewInduction.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSES1linkNewInduction.HRef = item.linkNewInductionHref+item.linkNewInductionHrefParameters.ToString("GET","STAFF_INDUCTIONS_PROGRESS_id", ViewState)
        STAFF_INDUCTIONS_COURSES1linkNewInduction1.InnerText += item.linkNewInduction1.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSES1linkNewInduction1.HRef = item.linkNewInduction1Href+item.linkNewInduction1HrefParameters.ToString("GET","STAFF_INDUCTIONS_PROGRESS_id", ViewState)
'End Grid Form STAFF_INDUCTIONS_COURSES1 BeforeShow tail

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Hide-Show Component @110-FC61E2F8
        Dim Urls_View_StaffList_Active_Inactive_staff_ID_110_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_View_StaffList_Active_Inactive_staff_ID"))
        Dim ExprParam2_110_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_View_StaffList_Active_Inactive_staff_ID_110_1, ExprParam2_110_2) Then
            STAFF_INDUCTIONS_COURSES1Repeater.Visible = False
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Hide-Show Component

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code @111-73254650
    ' -------------------------
	' also hide the Add New and 'edit' for Teachers
 		If (DBUtility.AuthorizeUser(New String(){"2","3","4","7","9"})) Then
			STAFF_INDUCTIONS_COURSES1linkNewInduction.visible = True
			STAFF_INDUCTIONS_COURSES1linkNewInduction1.visible = True
			STAFF_INDUCTIONS_COURSES1Panel_header_editbutton.visible = True
		else
			STAFF_INDUCTIONS_COURSES1linkNewInduction.visible = false
			STAFF_INDUCTIONS_COURSES1linkNewInduction1.visible = false
			STAFF_INDUCTIONS_COURSES1Panel_header_editbutton.visible = false
    	End If
    ' -------------------------
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShow. Action Custom Code

'Grid STAFF_INDUCTIONS_COURSES1 Bind tail @3-E31F8E2A
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Bind tail

'Grid STAFF_INDUCTIONS_COURSES1 Table Parameters @3-7B841296

    Protected Sub STAFF_INDUCTIONS_COURSES1Parameters()
        Try
            STAFF_INDUCTIONS_COURSES1Data.Urls_View_StaffList_Active_Inactive_staff_ID = TextParameter.GetParam("s_View_StaffList_Active_Inactive_staff_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STAFF_INDUCTIONS_COURSES1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STAFF_INDUCTIONS_COURSES1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STAFF_INDUCTIONS_COURSES1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 Table Parameters

'Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event @3-172C02D3

    Protected Sub STAFF_INDUCTIONS_COURSES1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STAFF_INDUCTIONS_COURSES1Item = CType(e.Item.DataItem,STAFF_INDUCTIONS_COURSES1Item)
        Dim Item as STAFF_INDUCTIONS_COURSES1Item = DataItem
        Dim FormDataSource As STAFF_INDUCTIONS_COURSES1Item() = CType(STAFF_INDUCTIONS_COURSES1Repeater.DataSource, STAFF_INDUCTIONS_COURSES1Item())
        Dim STAFF_INDUCTIONS_COURSES1DataRows As Integer = FormDataSource.Length
        Dim STAFF_INDUCTIONS_COURSES1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFF_INDUCTIONS_COURSES1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STAFF_INDUCTIONS_COURSES1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFF_INDUCTIONS_COURSES1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1STAFF_INDUCTIONS_PROGRESS_STATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1DATE_COMPLETED As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1DATE_COMPLETED"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1staffname As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1staffname"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1INDUCTION_TITLE"),System.Web.UI.WebControls.Literal)
            Dim STAFF_INDUCTIONS_COURSES1Panel_data_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Panel_data_editbutton"),System.Web.UI.WebControls.PlaceHolder)
            Dim STAFF_INDUCTIONS_COURSES1Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.Link1Href = "Staff_Inductions_ByStaff_maint.aspx"
            STAFF_INDUCTIONS_COURSES1Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event

'Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event

'Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShowRow. Action Custom Code @121-73254650
    ' -------------------------
    	' also hide the Add New and 'edit' for Teachers
 		If (DBUtility.AuthorizeUser(New String(){"2","3","4","7","9"})) Then
			Dim panel_editbutton As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("STAFF_INDUCTIONS_COURSES1Panel_data_editbutton"),System.Web.UI.WebControls.PlaceHolder)
			panel_editbutton.visible = True
    	End If
    ' -------------------------
'End Grid STAFF_INDUCTIONS_COURSES1 Event BeforeShowRow. Action Custom Code

'Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid STAFF_INDUCTIONS_COURSES1 BeforeShowRow event tail

'Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event tail @3-00C0539C
        If STAFF_INDUCTIONS_COURSES1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STAFF_INDUCTIONS_COURSES1CurrentRowNumber, ListItemType.Item)
            STAFF_INDUCTIONS_COURSES1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STAFF_INDUCTIONS_COURSES1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 ItemDataBound event tail

'Grid STAFF_INDUCTIONS_COURSES1 ItemCommand event @3-CA556B65

    Protected Sub STAFF_INDUCTIONS_COURSES1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STAFF_INDUCTIONS_COURSES1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STAFF_INDUCTIONS_COURSES1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STAFF_INDUCTIONS_COURSES1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=SortDirections._Desc
                Else
                    ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STAFF_INDUCTIONS_COURSES1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STAFF_INDUCTIONS_COURSES1DataProvider.SortFields = 0
            ViewState("STAFF_INDUCTIONS_COURSES1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STAFF_INDUCTIONS_COURSES1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFF_INDUCTIONS_COURSES1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STAFF_INDUCTIONS_COURSES1Bind
        End If
    End Sub
'End Grid STAFF_INDUCTIONS_COURSES1 ItemCommand event

'Record Form STAFF_INDUCTIONS_COURSES Parameters @16-3DABADC5

    Protected Sub STAFF_INDUCTIONS_COURSESParameters()
        Dim item As new STAFF_INDUCTIONS_COURSESItem
        Try
        Catch e As Exception
            STAFF_INDUCTIONS_COURSESErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Parameters

'Record Form STAFF_INDUCTIONS_COURSES Show method @16-D932B668
    Protected Sub STAFF_INDUCTIONS_COURSESShow()
        If STAFF_INDUCTIONS_COURSESOperations.None Then
            STAFF_INDUCTIONS_COURSESHolder.Visible = False
            Return
        End If
        Dim item As STAFF_INDUCTIONS_COURSESItem = STAFF_INDUCTIONS_COURSESItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_INDUCTIONS_COURSESOperations.AllowRead
        item.ClearParametersHref = "Staff_Inductions_ByStaff.aspx"
        STAFF_INDUCTIONS_COURSESErrors.Add(item.errors)
        If STAFF_INDUCTIONS_COURSESErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESShowErrors()
            Return
        End If
'End Record Form STAFF_INDUCTIONS_COURSES Show method

'Record Form STAFF_INDUCTIONS_COURSES BeforeShow tail @16-97D5EE30
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESData.FillItem(item, IsInsertMode)
        STAFF_INDUCTIONS_COURSESHolder.DataBind()
        STAFF_INDUCTIONS_COURSESClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_INDUCTIONS_COURSESClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_View_StaffList_Active_Inactive_staff_ID", ViewState)
        STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Items.Add(new ListItem("Select Value",""))
        STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Items(0).Selected = True
        item.s_View_StaffList_Active_Inactive_staff_IDItems.SetSelection(item.s_View_StaffList_Active_Inactive_staff_ID.GetFormattedValue())
        If Not item.s_View_StaffList_Active_Inactive_staff_IDItems.GetSelectedItem() Is Nothing Then
            STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.SelectedIndex = -1
        End If
        item.s_View_StaffList_Active_Inactive_staff_IDItems.CopyTo(STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Items)
        STAFF_INDUCTIONS_COURSESlabel_TeacherID.Text = Server.HtmlEncode(item.label_TeacherID.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STAFF_INDUCTIONS_COURSES BeforeShow tail

'Record STAFF_INDUCTIONS_COURSES Event BeforeShow. Action Custom Code @109-73254650
    ' -------------------------
	' ERA: hide some items if Teacher, show if 2:PRINCIPALS; 3:ADMINISTRATORS; 4:DATA ENTRY OPERATORS; 6:ENROLMENT OFFICERS; 7:LEADING TEACHERS; 9:SYSTEM
    ' -------------------------
		If (DBUtility.AuthorizeUser(New String(){"2","3","4","7","9"})) Then
			STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.visible = True
			STAFF_INDUCTIONS_COURSESlabel_TeacherID.visible = false
		else
			STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.visible = false
			STAFF_INDUCTIONS_COURSESlabel_TeacherID.visible = true
			STAFF_INDUCTIONS_COURSESClearParameters.visible = false
			
    	End If
    ' -------------------------
'End Record STAFF_INDUCTIONS_COURSES Event BeforeShow. Action Custom Code

'Record Form STAFF_INDUCTIONS_COURSES Show method tail @16-5454F67D
        If STAFF_INDUCTIONS_COURSESErrors.Count > 0 Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Show method tail

'Record Form STAFF_INDUCTIONS_COURSES LoadItemFromRequest method @16-9355107B

    Protected Sub STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item As STAFF_INDUCTIONS_COURSESItem, ByVal EnableValidation As Boolean)
        item.s_View_StaffList_Active_Inactive_staff_ID.IsEmpty = IsNothing(Request.Form(STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.UniqueID))
        item.s_View_StaffList_Active_Inactive_staff_ID.SetValue(STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Value)
        item.s_View_StaffList_Active_Inactive_staff_IDItems.CopyFrom(STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Items)
        If EnableValidation Then
            item.Validate(STAFF_INDUCTIONS_COURSESData)
        End If
        STAFF_INDUCTIONS_COURSESErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES LoadItemFromRequest method

'Record Form STAFF_INDUCTIONS_COURSES GetRedirectUrl method @16-8AEF3CE0

    Protected Function GetSTAFF_INDUCTIONS_COURSESRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Staff_Inductions_ByStaff.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_INDUCTIONS_COURSES GetRedirectUrl method

'Record Form STAFF_INDUCTIONS_COURSES ShowErrors method @16-241B4AFF

    Protected Sub STAFF_INDUCTIONS_COURSESShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_INDUCTIONS_COURSESErrors.Count - 1
        Select Case STAFF_INDUCTIONS_COURSESErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_INDUCTIONS_COURSESErrors(i)
        End Select
        Next i
        STAFF_INDUCTIONS_COURSESError.Visible = True
        STAFF_INDUCTIONS_COURSESErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES ShowErrors method

'Record Form STAFF_INDUCTIONS_COURSES Insert Operation @16-AC52CBC6

    Protected Sub STAFF_INDUCTIONS_COURSES_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES Insert Operation

'Record Form STAFF_INDUCTIONS_COURSES BeforeInsert tail @16-E20CD880
    STAFF_INDUCTIONS_COURSESParameters()
    STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSES BeforeInsert tail

'Record Form STAFF_INDUCTIONS_COURSES AfterInsert tail  @16-5E4A5F54
        ErrorFlag=(STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES AfterInsert tail 

'Record Form STAFF_INDUCTIONS_COURSES Update Operation @16-44604355

    Protected Sub STAFF_INDUCTIONS_COURSES_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_INDUCTIONS_COURSES Update Operation

'Record Form STAFF_INDUCTIONS_COURSES Before Update tail @16-E20CD880
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSES Before Update tail

'Record Form STAFF_INDUCTIONS_COURSES Update Operation tail @16-5E4A5F54
        ErrorFlag=(STAFF_INDUCTIONS_COURSESErrors.Count > 0)
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Update Operation tail

'Record Form STAFF_INDUCTIONS_COURSES Delete Operation @16-F9DB744D
    Protected Sub STAFF_INDUCTIONS_COURSES_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_INDUCTIONS_COURSES Delete Operation

'Record Form BeforeDelete tail @16-E20CD880
        STAFF_INDUCTIONS_COURSESParameters()
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @16-C7163990
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_INDUCTIONS_COURSES Cancel Operation @16-B3960A2B

    Protected Sub STAFF_INDUCTIONS_COURSES_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, True)
'End Record Form STAFF_INDUCTIONS_COURSES Cancel Operation

'Record Form STAFF_INDUCTIONS_COURSES Cancel Operation tail @16-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_INDUCTIONS_COURSES Cancel Operation tail

'Record Form STAFF_INDUCTIONS_COURSES Search Operation @16-28F2267F
    Protected Sub STAFF_INDUCTIONS_COURSES_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STAFF_INDUCTIONS_COURSESIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STAFF_INDUCTIONS_COURSESItem = New STAFF_INDUCTIONS_COURSESItem()
        STAFF_INDUCTIONS_COURSESLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_INDUCTIONS_COURSES Search Operation

'Button Button_DoSearch OnClick. @18-964BC30B
        If CType(sender,Control).ID = "STAFF_INDUCTIONS_COURSESButton_DoSearch" Then
            RedirectUrl = GetSTAFF_INDUCTIONS_COURSESRedirectUrl("", "s_View_StaffList_Active_Inactive_staff_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @18-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STAFF_INDUCTIONS_COURSES Search Operation tail @16-BE924D6F
        ErrorFlag = STAFF_INDUCTIONS_COURSESErrors.Count > 0
        If ErrorFlag Then
            STAFF_INDUCTIONS_COURSESShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            For Each li In STAFF_INDUCTIONS_COURSESs_View_StaffList_Active_Inactive_staff_ID.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_View_StaffList_Active_Inactive_staff_ID=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form STAFF_INDUCTIONS_COURSES Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-FBE7CC18
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Staff_Inductions_ByStaffContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_INDUCTIONS_COURSES1Data = New STAFF_INDUCTIONS_COURSES1DataProvider()
        STAFF_INDUCTIONS_COURSES1Operations = New FormSupportedOperations(False, True, False, False, False)
        STAFF_INDUCTIONS_COURSESData = New STAFF_INDUCTIONS_COURSESDataProvider()
        STAFF_INDUCTIONS_COURSESOperations = New FormSupportedOperations(False, True, True, True, True)
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

