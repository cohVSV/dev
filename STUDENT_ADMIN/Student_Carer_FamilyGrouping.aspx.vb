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

Namespace DECV_PROD2007.Student_Carer_FamilyGrouping 'Namespace @1-FC855C02

'Forms Definition @1-73583950
Public Class [Student_Carer_FamilyGroupingPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-04FBB064
    Protected STUDENT_CARER_CONTACT3Data As STUDENT_CARER_CONTACT3DataProvider
    Protected STUDENT_CARER_CONTACT3Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT3Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT3IsSubmitted As Boolean = False
    Protected viewMaintainSearchRequestData As viewMaintainSearchRequestDataProvider
    Protected viewMaintainSearchRequestOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestCurrentRowNumber As Integer
    Protected viewMaintainSearchRequestSearchData As viewMaintainSearchRequestSearchDataProvider
    Protected viewMaintainSearchRequestSearchErrors As NameValueCollection = New NameValueCollection()
    Protected viewMaintainSearchRequestSearchOperations As FormSupportedOperations
    Protected viewMaintainSearchRequestSearchIsSubmitted As Boolean = False
    Protected STUDENT_CARER_CONTACT4Data As STUDENT_CARER_CONTACT4DataProvider
    Protected STUDENT_CARER_CONTACT4Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT4Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT4IsSubmitted As Boolean = False
    Protected Grid_FamilyGroupData As Grid_FamilyGroupDataProvider
    Protected Grid_FamilyGroupOperations As FormSupportedOperations
    Protected Grid_FamilyGroupCurrentRowNumber As Integer
    Protected Student_Carer_FamilyGroupingContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-43D7D4C6
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CARER_CONTACT3Show()
            viewMaintainSearchRequestBind
            viewMaintainSearchRequestSearchShow()
            STUDENT_CARER_CONTACT4Show()
            Grid_FamilyGroupBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_CARER_CONTACT3 Parameters @4-004CB2B5

    Protected Sub STUDENT_CARER_CONTACT3Parameters()
        Dim item As new STUDENT_CARER_CONTACT3Item
        Try
            STUDENT_CARER_CONTACT3Data.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlHidden_STUDENT_ID_OTHER = FloatParameter.GetParam(item.Hidden_STUDENT_ID_OTHER.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlDupe_CARER_ID = IntegerParameter.GetParam(item.Dupe_CARER_ID.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            STUDENT_CARER_CONTACT3Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Parameters

'Record Form STUDENT_CARER_CONTACT3 Show method @4-6B025CB6
    Protected Sub STUDENT_CARER_CONTACT3Show()
        If STUDENT_CARER_CONTACT3Operations.None Then
            STUDENT_CARER_CONTACT3Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACT3Item = STUDENT_CARER_CONTACT3Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACT3Operations.AllowRead
        STUDENT_CARER_CONTACT3Errors.Add(item.errors)
        If STUDENT_CARER_CONTACT3Errors.Count > 0 Then
            STUDENT_CARER_CONTACT3ShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACT3 Show method

'Record Form STUDENT_CARER_CONTACT3 BeforeShow tail @4-B048CAF9
        STUDENT_CARER_CONTACT3Parameters()
        STUDENT_CARER_CONTACT3Data.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT3Holder.DataBind()
        STUDENT_CARER_CONTACT3Button_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACT3Operations.AllowInsert
        STUDENT_CARER_CONTACT3Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT3Operations.AllowUpdate
        STUDENT_CARER_CONTACT3Button_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT3Operations.AllowDelete
        STUDENT_CARER_CONTACT3RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT3RELATIONSHIP.Items(0).Selected = True
        item.RELATIONSHIPItems.SetSelection(item.RELATIONSHIP.GetFormattedValue())
        If Not item.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT3RELATIONSHIP.SelectedIndex = -1
        End If
        item.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT3RELATIONSHIP.Items)
        STUDENT_CARER_CONTACT3WORK_PHONE.Text = Server.HtmlEncode(item.WORK_PHONE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3MOBILE.Text = Server.HtmlEncode(item.MOBILE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3EMAIL.Text = Server.HtmlEncode(item.EMAIL.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value = item.Hidden_STUDENT_ID.GetFormattedValue()
        STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_CARER_CONTACT3FIRST_NAME.Text = Server.HtmlEncode(item.FIRST_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3SURNAME.Text = Server.HtmlEncode(item.SURNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3HOME_PHONE.Text = Server.HtmlEncode(item.HOME_PHONE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Hidden_STUDENT_ID_OTHER.Value = item.Hidden_STUDENT_ID_OTHER.GetFormattedValue()
        STUDENT_CARER_CONTACT3Student_Firstname.Text = Server.HtmlEncode(item.Student_Firstname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Student_Surname.Text = Server.HtmlEncode(item.Student_Surname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Dupe_CARER_ID.Value = item.Dupe_CARER_ID.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACT3 BeforeShow tail


'DEL      ' -------------------------
'DEL        ' ERA: Nov-2013|EA| add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL  		item.EMAILHrefParameters.Add("subject",("Message regarding DECV Student").ToString())
'DEL    		if not IsDBNull(item.EMAILHref) then
'DEL    			STUDENT_CARER_CONTACT3EMAIL.HRef = "mailto:" + item.EMAILHref & item.EMAILHrefParameters.ToString("None","", ViewState)
'DEL  	  	end if
'DEL      ' -------------------------


'Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @22-D3D960B1
            STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_STUDENT_ID_OTHER Event BeforeShow. Action Retrieve Value for Control @49-FA44BD81
            STUDENT_CARER_CONTACT3Hidden_STUDENT_ID_OTHER.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID_OTHER"))).GetFormattedValue()
'End Hidden Hidden_STUDENT_ID_OTHER Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component @238-BF885C38
        Dim UrlSTUDENT_ID_OTHER_238_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID_OTHER"))
        Dim ExprParam2_238_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlSTUDENT_ID_OTHER_238_1, ExprParam2_238_2) Then
            STUDENT_CARER_CONTACT3Button_Update.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT3 Show method tail @4-9A35F43C
        If STUDENT_CARER_CONTACT3Errors.Count > 0 Then
            STUDENT_CARER_CONTACT3ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Show method tail

'Record Form STUDENT_CARER_CONTACT3 LoadItemFromRequest method @4-D5139BDE

    Protected Sub STUDENT_CARER_CONTACT3LoadItemFromRequest(item As STUDENT_CARER_CONTACT3Item, ByVal EnableValidation As Boolean)
        item.RELATIONSHIP.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3RELATIONSHIP.UniqueID))
        item.RELATIONSHIP.SetValue(STUDENT_CARER_CONTACT3RELATIONSHIP.Value)
        item.RELATIONSHIPItems.CopyFrom(STUDENT_CARER_CONTACT3RELATIONSHIP.Items)
        item.Hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.UniqueID))
        item.Hidden_STUDENT_ID.SetValue(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value)
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value)
        item.Hidden_STUDENT_ID_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID_OTHER.UniqueID))
        item.Hidden_STUDENT_ID_OTHER.SetValue(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID_OTHER.Value)
        Try
        item.Dupe_CARER_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Dupe_CARER_ID.UniqueID))
        item.Dupe_CARER_ID.SetValue(STUDENT_CARER_CONTACT3Dupe_CARER_ID.Value)
        Catch ae As ArgumentException
            STUDENT_CARER_CONTACT3Errors.Add("Dupe_CARER_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Dupe_CARER_ID"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT3Data)
        End If
        STUDENT_CARER_CONTACT3Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT3 GetRedirectUrl method @4-2DAD4777

    Protected Function GetSTUDENT_CARER_CONTACT3RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_FamilyGrouping.aspx"
        Dim p As String = parameters.ToString("GET","STUDENT_ID_OTHER;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT3 GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT3 ShowErrors method @4-6E817C65

    Protected Sub STUDENT_CARER_CONTACT3ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACT3Errors.Count - 1
        Select Case STUDENT_CARER_CONTACT3Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACT3Errors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACT3Error.Visible = True
        STUDENT_CARER_CONTACT3ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 ShowErrors method

'Record Form STUDENT_CARER_CONTACT3 Insert Operation @4-86AB3C30

    Protected Sub STUDENT_CARER_CONTACT3_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT3 Insert Operation

'Button Button_Insert OnClick. @5-9621A83C
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @5-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT3 BeforeInsert tail @4-8821A67C
    STUDENT_CARER_CONTACT3Parameters()
    STUDENT_CARER_CONTACT3LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACT3 BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT3 AfterInsert tail  @4-C4BE7409
        ErrorFlag=(STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT3 Update Operation @4-0E52FABE

    Protected Sub STUDENT_CARER_CONTACT3_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT3 Update Operation

'Button Button_Update OnClick. @6-C3D40432
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @6-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Retrieve Value for Control @27-17EE561C
        STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Custom Code @194-73254650
    ' -------------------------
     ' ERA:13-Nov-2013|EA| write to STUDENT_CARER_FAMILY_LOG to track if problems (Which would never happen, right?)
     ' NOTE: This is the STUDENT_ID_OTHER that is being updated not the main student, using the 'old' carer id from the 'other' student -  as the 'Other' student is being updated to the 'main' carer, so we log the old one
    Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
    dim thisCarerID as string = STUDENT_CARER_CONTACT4Dupe_CARER_ID.Value
    if thisCarerID="" then thisCarerID = "0"
  	Dim Sql_BradyBunch As String = "INSERT INTO [STUDENT_CARER_FAMILY_LOG]([STUDENT_ID],[CARER_ID_OLD],[LAST_ALTERED_BY],[LAST_ALTERED_DATE]) " & _
     		" VALUES("& NewDao.ToSql(STUDENT_CARER_CONTACT3hidden_student_id_other.Value,FieldType._Integer) &","&NewDao.ToSql(thisCarerID,FieldType._Integer)&","&NewDao.ToSql(STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value,FieldType._Text) & ", GETDATE());"
  	NewDao.RunSql(Sql_BradyBunch)

    ' -------------------------
'End Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_CARER_CONTACT3 Before Update tail @4-EF02AA52
        STUDENT_CARER_CONTACT3Parameters()
        STUDENT_CARER_CONTACT3LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT3Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT3Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT3Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT3 Before Update tail

'DEL      ' -------------------------
'DEL      ' ERA:13-Nov-2013|EA| write to STUDENT_CARER_FAMILY_LOG to track if problems (Which would never happen, right?)
'DEL      Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL    	Dim Sql_BradyBunch As String = "INSERT  "& NewDao.ToSql(item.hidden_student_id.getformattedvalue(),FieldType._Integer) &","&NewDao.ToSql(item.enrolyear.getformattedvalue(),FieldType._Integer) &" "
'DEL    	NewDao.RunSql(Sql_BradyBunch)
'DEL  
'DEL      ' -------------------------


'Record Form STUDENT_CARER_CONTACT3 Update Operation tail @4-6A575A40
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Update Operation tail

'Record Form STUDENT_CARER_CONTACT3 Delete Operation @4-866706AA
    Protected Sub STUDENT_CARER_CONTACT3_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT3 Delete Operation

'Button Button_Delete OnClick. @7-D38CE750
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Delete" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @7-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @4-8821A67C
        STUDENT_CARER_CONTACT3Parameters()
        STUDENT_CARER_CONTACT3LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-1DCAD3B3
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT3 Cancel Operation @4-7947BB21

    Protected Sub STUDENT_CARER_CONTACT3_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT3LoadItemFromRequest(item, True)
'End Record Form STUDENT_CARER_CONTACT3 Cancel Operation

'Record Form STUDENT_CARER_CONTACT3 Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Cancel Operation tail

'Grid viewMaintainSearchRequest Bind @61-6B2C8264

    Protected Sub viewMaintainSearchRequestBind()
        If Not viewMaintainSearchRequestOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"viewMaintainSearchRequest",GetType(viewMaintainSearchRequestDataProvider.SortFields), 15, 100)
        End If
'End Grid viewMaintainSearchRequest Bind

'Grid Form viewMaintainSearchRequest BeforeShow tail @61-D14414B4
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
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PASTORAL_CARE_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewMaintainSearchRequestRepeater.Controls(0).FindControl("Sorter_PASTORAL_CARE_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewMaintainSearchRequestRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form viewMaintainSearchRequest BeforeShow tail

'Grid viewMaintainSearchRequest Event BeforeShow. Action Hide-Show Component @186-AA27FF52
        Dim UrlSTUDENT_ID_OTHER_186_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID_OTHER"))
        Dim ExprParam2_186_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(UrlSTUDENT_ID_OTHER_186_1, ExprParam2_186_2) Then
            viewMaintainSearchRequestRepeater.Visible = False
        End If
'End Grid viewMaintainSearchRequest Event BeforeShow. Action Hide-Show Component

'Grid viewMaintainSearchRequest Event BeforeShow. Action Custom Code @237-73254650
    ' -------------------------
    '13-Nov-2013|EA| hide the results if there are no search fields
	if (isnothing(viewMaintainSearchRequestData.Urls_SURNAME) and isnothing(viewmaintainsearchrequestdata.urls_student_id)) then
		viewMaintainSearchRequestRepeater.visible = false
    end if
    ' -------------------------
'End Grid viewMaintainSearchRequest Event BeforeShow. Action Custom Code

'Grid viewMaintainSearchRequest Bind tail @61-E31F8E2A
    End Sub
'End Grid viewMaintainSearchRequest Bind tail

'Grid viewMaintainSearchRequest Table Parameters @61-FA28B842

    Protected Sub viewMaintainSearchRequestParameters()
        Try
            viewMaintainSearchRequestData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequestData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            viewMaintainSearchRequestData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

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

'Grid viewMaintainSearchRequest ItemDataBound event @61-3332EB33

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
            Dim viewMaintainSearchRequestSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestSURNAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestENROLMENT_STATUS"),System.Web.UI.WebControls.Literal)
            Dim viewMaintainSearchRequestPASTORAL_CARE_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewMaintainSearchRequestPASTORAL_CARE_ID"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "Student_Carer_FamilyGrouping.aspx"
            viewMaintainSearchRequestSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET","s_SURNAME;s_STUDENT_ID", ViewState)
        End If
'End Grid viewMaintainSearchRequest ItemDataBound event

'Grid viewMaintainSearchRequest ItemDataBound event tail @61-C2522D63
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

'Grid viewMaintainSearchRequest ItemCommand event @61-23C75A20

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

'Record Form viewMaintainSearchRequestSearch Parameters @78-2C0CE1CA

    Protected Sub viewMaintainSearchRequestSearchParameters()
        Dim item As new viewMaintainSearchRequestSearchItem
        Try
        Catch e As Exception
            viewMaintainSearchRequestSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form viewMaintainSearchRequestSearch Parameters

'Record Form viewMaintainSearchRequestSearch Show method @78-CC540FCB
    Protected Sub viewMaintainSearchRequestSearchShow()
        If viewMaintainSearchRequestSearchOperations.None Then
            viewMaintainSearchRequestSearchHolder.Visible = False
            Return
        End If
        Dim item As viewMaintainSearchRequestSearchItem = viewMaintainSearchRequestSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not viewMaintainSearchRequestSearchOperations.AllowRead
        item.ClearParametersHref = "Student_Carer_FamilyGrouping.aspx"
        viewMaintainSearchRequestSearchErrors.Add(item.errors)
        If viewMaintainSearchRequestSearchErrors.Count > 0 Then
            viewMaintainSearchRequestSearchShowErrors()
            Return
        End If
'End Record Form viewMaintainSearchRequestSearch Show method

'Record Form viewMaintainSearchRequestSearch BeforeShow tail @78-C1549D63
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchData.FillItem(item, IsInsertMode)
        viewMaintainSearchRequestSearchHolder.DataBind()
        viewMaintainSearchRequestSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        viewMaintainSearchRequestSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_STUDENT_ID;STUDENT_ID_OTHER", ViewState)
        viewMaintainSearchRequestSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        viewMaintainSearchRequestSearchs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
'End Record Form viewMaintainSearchRequestSearch BeforeShow tail

'Record Form viewMaintainSearchRequestSearch Show method tail @78-7E05ECE5
        If viewMaintainSearchRequestSearchErrors.Count > 0 Then
            viewMaintainSearchRequestSearchShowErrors()
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch Show method tail

'Record Form viewMaintainSearchRequestSearch LoadItemFromRequest method @78-227F3D4A

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
        If EnableValidation Then
            item.Validate(viewMaintainSearchRequestSearchData)
        End If
        viewMaintainSearchRequestSearchErrors.Add(item.errors)
    End Sub
'End Record Form viewMaintainSearchRequestSearch LoadItemFromRequest method

'Record Form viewMaintainSearchRequestSearch GetRedirectUrl method @78-B55145EA

    Protected Function GetviewMaintainSearchRequestSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_FamilyGrouping.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form viewMaintainSearchRequestSearch GetRedirectUrl method

'Record Form viewMaintainSearchRequestSearch ShowErrors method @78-F8D37C92

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

'Record Form viewMaintainSearchRequestSearch Insert Operation @78-1A28279F

    Protected Sub viewMaintainSearchRequestSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequestSearch Insert Operation

'Record Form viewMaintainSearchRequestSearch BeforeInsert tail @78-6D659926
    viewMaintainSearchRequestSearchParameters()
    viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequestSearch BeforeInsert tail

'Record Form viewMaintainSearchRequestSearch AfterInsert tail  @78-6270FCD4
        ErrorFlag=(viewMaintainSearchRequestSearchErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch AfterInsert tail 

'Record Form viewMaintainSearchRequestSearch Update Operation @78-CD83C997

    Protected Sub viewMaintainSearchRequestSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form viewMaintainSearchRequestSearch Update Operation

'Record Form viewMaintainSearchRequestSearch Before Update tail @78-6D659926
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequestSearch Before Update tail

'Record Form viewMaintainSearchRequestSearch Update Operation tail @78-6270FCD4
        ErrorFlag=(viewMaintainSearchRequestSearchErrors.Count > 0)
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form viewMaintainSearchRequestSearch Update Operation tail

'Record Form viewMaintainSearchRequestSearch Delete Operation @78-14E19741
    Protected Sub viewMaintainSearchRequestSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form viewMaintainSearchRequestSearch Delete Operation

'Record Form BeforeDelete tail @78-6D659926
        viewMaintainSearchRequestSearchParameters()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @78-204E12B9
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form viewMaintainSearchRequestSearch Cancel Operation @78-352C7F64

    Protected Sub viewMaintainSearchRequestSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, True)
'End Record Form viewMaintainSearchRequestSearch Cancel Operation

'Record Form viewMaintainSearchRequestSearch Cancel Operation tail @78-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form viewMaintainSearchRequestSearch Cancel Operation tail

'Record Form viewMaintainSearchRequestSearch Search Operation @78-57BFFD36
    Protected Sub viewMaintainSearchRequestSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        viewMaintainSearchRequestSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As viewMaintainSearchRequestSearchItem = New viewMaintainSearchRequestSearchItem()
        viewMaintainSearchRequestSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form viewMaintainSearchRequestSearch Search Operation

'Button Button_DoSearch OnClick. @80-C1558B25
        If CType(sender,Control).ID = "viewMaintainSearchRequestSearchButton_DoSearch" Then
            RedirectUrl = GetviewMaintainSearchRequestSearchRedirectUrl("", "s_SURNAME;s_STUDENT_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @80-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form viewMaintainSearchRequestSearch Search Operation tail @78-5286B9FC
        ErrorFlag = viewMaintainSearchRequestSearchErrors.Count > 0
        If ErrorFlag Then
            viewMaintainSearchRequestSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(viewMaintainSearchRequestSearchs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_SURNAME.Text) & "&"), "")
            Params = Params & IIf(viewMaintainSearchRequestSearchs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(viewMaintainSearchRequestSearchs_STUDENT_ID.Text) & "&"), "")
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

'Record Form STUDENT_CARER_CONTACT4 Parameters @99-71986531

    Protected Sub STUDENT_CARER_CONTACT4Parameters()
        Dim item As new STUDENT_CARER_CONTACT4Item
        Try
            STUDENT_CARER_CONTACT4Data.UrlSTUDENT_ID_OTHER = FloatParameter.GetParam("STUDENT_ID_OTHER", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlHidden_STUDENT_ID = FloatParameter.GetParam(item.Hidden_STUDENT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlDupe_CARER_ID = IntegerParameter.GetParam(item.Dupe_CARER_ID.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            STUDENT_CARER_CONTACT4Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Parameters

'Record Form STUDENT_CARER_CONTACT4 Show method @99-6F5E23AF
    Protected Sub STUDENT_CARER_CONTACT4Show()
        If STUDENT_CARER_CONTACT4Operations.None Then
            STUDENT_CARER_CONTACT4Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACT4Item = STUDENT_CARER_CONTACT4Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACT4Operations.AllowRead
        STUDENT_CARER_CONTACT4Errors.Add(item.errors)
        If STUDENT_CARER_CONTACT4Errors.Count > 0 Then
            STUDENT_CARER_CONTACT4ShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACT4 Show method

'Record Form STUDENT_CARER_CONTACT4 BeforeShow tail @99-792FDFDA
        STUDENT_CARER_CONTACT4Parameters()
        STUDENT_CARER_CONTACT4Data.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT4Holder.DataBind()
        STUDENT_CARER_CONTACT4Button_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACT4Operations.AllowInsert
        STUDENT_CARER_CONTACT4Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT4Operations.AllowUpdate
        STUDENT_CARER_CONTACT4Button_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT4Operations.AllowDelete
        STUDENT_CARER_CONTACT4RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT4RELATIONSHIP.Items(0).Selected = True
        item.RELATIONSHIPItems.SetSelection(item.RELATIONSHIP.GetFormattedValue())
        If Not item.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT4RELATIONSHIP.SelectedIndex = -1
        End If
        item.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT4RELATIONSHIP.Items)
        STUDENT_CARER_CONTACT4WORK_PHONE.Text = Server.HtmlEncode(item.WORK_PHONE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4MOBILE.Text = Server.HtmlEncode(item.MOBILE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4EMAIL.Text = Server.HtmlEncode(item.EMAIL.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4Hidden_STUDENT_ID.Value = item.Hidden_STUDENT_ID.GetFormattedValue()
        STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_CARER_CONTACT4FIRST_NAME.Text = Server.HtmlEncode(item.FIRST_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4SURNAME.Text = Server.HtmlEncode(item.SURNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4HOME_PHONE.Text = Server.HtmlEncode(item.HOME_PHONE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4Hidden_STUDENT_ID_OTHER.Value = item.Hidden_STUDENT_ID_OTHER.GetFormattedValue()
        STUDENT_CARER_CONTACT4Student_Firstname.Text = Server.HtmlEncode(item.Student_Firstname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4Student_Surname.Text = Server.HtmlEncode(item.Student_Surname.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4Dupe_CARER_ID.Value = item.Dupe_CARER_ID.GetFormattedValue()
        STUDENT_CARER_CONTACT4lblNoCarer.Text = item.lblNoCarer.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACT4 BeforeShow tail

'DEL      ' -------------------------
'DEL        ' ERA: Nov-2013|EA| add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
'DEL  		item.EMAILHrefParameters.Add("subject",("Message regarding DECV Student").ToString())
'DEL    		if not IsDBNull(item.EMAILHref) then
'DEL    			STUDENT_CARER_CONTACT3EMAIL.HRef = "mailto:" + item.EMAILHref & item.EMAILHrefParameters.ToString("None","", ViewState)
'DEL  	  	end if
'DEL      ' -------------------------

'Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @184-4826AB28
            STUDENT_CARER_CONTACT4Hidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_STUDENT_ID_OTHER Event BeforeShow. Action Retrieve Value for Control @185-203DA5CF
            STUDENT_CARER_CONTACT4Hidden_STUDENT_ID_OTHER.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID_OTHER"))).GetFormattedValue()
'End Hidden Hidden_STUDENT_ID_OTHER Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Custom Code @281-73254650
    ' -------------------------
    'ERA: if no carer ID then change form to stop update and should hide button
    ' based on normal hide of button
     
     If (STUDENT_CARER_CONTACT4Dupe_CARER_ID.Value = "") Then
         STUDENT_CARER_CONTACT4Operations.AllowUpdate = false
         STUDENT_CARER_CONTACT4Button_Update.Visible= false
         STUDENT_CARER_CONTACT4lblNoCarer.Visible = true
     else
     	 STUDENT_CARER_CONTACT4lblNoCarer.Visible = false
	 End If
    ' -------------------------
'End Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Custom Code



'Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Hide-Show Component @179-B8FDD08E
        Dim UrlSTUDENT_ID_OTHER_179_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID_OTHER"))
        Dim ExprParam2_179_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlSTUDENT_ID_OTHER_179_1, ExprParam2_179_2) Then
            STUDENT_CARER_CONTACT4Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT4 Show method tail @99-B0440F22
        If STUDENT_CARER_CONTACT4Errors.Count > 0 Then
            STUDENT_CARER_CONTACT4ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Show method tail

'Record Form STUDENT_CARER_CONTACT4 LoadItemFromRequest method @99-7B07AF9B

    Protected Sub STUDENT_CARER_CONTACT4LoadItemFromRequest(item As STUDENT_CARER_CONTACT4Item, ByVal EnableValidation As Boolean)
        item.RELATIONSHIP.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4RELATIONSHIP.UniqueID))
        item.RELATIONSHIP.SetValue(STUDENT_CARER_CONTACT4RELATIONSHIP.Value)
        item.RELATIONSHIPItems.CopyFrom(STUDENT_CARER_CONTACT4RELATIONSHIP.Items)
        item.Hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Hidden_STUDENT_ID.UniqueID))
        item.Hidden_STUDENT_ID.SetValue(STUDENT_CARER_CONTACT4Hidden_STUDENT_ID.Value)
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value)
        item.Hidden_STUDENT_ID_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Hidden_STUDENT_ID_OTHER.UniqueID))
        item.Hidden_STUDENT_ID_OTHER.SetValue(STUDENT_CARER_CONTACT4Hidden_STUDENT_ID_OTHER.Value)
        Try
        item.Dupe_CARER_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Dupe_CARER_ID.UniqueID))
        item.Dupe_CARER_ID.SetValue(STUDENT_CARER_CONTACT4Dupe_CARER_ID.Value)
        Catch ae As ArgumentException
            STUDENT_CARER_CONTACT4Errors.Add("Dupe_CARER_ID",String.Format(Resources.strings.CCS_IncorrectValue,"Dupe_CARER_ID"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT4Data)
        End If
        STUDENT_CARER_CONTACT4Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT4 GetRedirectUrl method @99-B0F89D16

    Protected Function GetSTUDENT_CARER_CONTACT4RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_FamilyGrouping.aspx"
        Dim p As String = parameters.ToString("GET","STUDENT_ID_OTHER;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT4 GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT4 ShowErrors method @99-7B3C4534

    Protected Sub STUDENT_CARER_CONTACT4ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACT4Errors.Count - 1
        Select Case STUDENT_CARER_CONTACT4Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACT4Errors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACT4Error.Visible = True
        STUDENT_CARER_CONTACT4ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 ShowErrors method

'Record Form STUDENT_CARER_CONTACT4 Insert Operation @99-53E33EAF

    Protected Sub STUDENT_CARER_CONTACT4_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT4 Insert Operation

'Button Button_Insert OnClick. @100-8443596E
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @100-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT4 BeforeInsert tail @99-AE34F759
    STUDENT_CARER_CONTACT4Parameters()
    STUDENT_CARER_CONTACT4LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACT4 BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT4 AfterInsert tail  @99-5910B1C5
        ErrorFlag=(STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT4 Update Operation @99-6DBE9AB2

    Protected Sub STUDENT_CARER_CONTACT4_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT4 Update Operation

'Button Button_Update OnClick. @101-D1B6F560
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @101-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Retrieve Value for Control @180-D8C7BAF8
        STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Custom Code @195-73254650
    ' -------------------------
     ' ERA:13-Nov-2013|EA| write to STUDENT_CARER_FAMILY_LOG to track if problems (Which would never happen, right?)
     ' NOTE: This is the STUDENT_ID (Main) that is being updated not the Other student carer, using the carer ID of the main (form 3) student
    Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
    dim thisCarerID as string = STUDENT_CARER_CONTACT3Dupe_CARER_ID.Value
    if thisCarerID="" then thisCarerID = "0"
  	Dim Sql_BradyBunch As String = "INSERT INTO [STUDENT_CARER_FAMILY_LOG]([STUDENT_ID],[CARER_ID_OLD],[LAST_ALTERED_BY],[LAST_ALTERED_DATE]) " & _
     		" VALUES("& NewDao.ToSql(STUDENT_CARER_CONTACT4hidden_student_id.Value,FieldType._Integer) &","&NewDao.ToSql(thisCarerID,FieldType._Integer)&","&NewDao.ToSql(STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value,FieldType._Text) & ", GETDATE());"
  	NewDao.RunSql(Sql_BradyBunch)

    ' -------------------------
'End Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Custom Code

'Record Form STUDENT_CARER_CONTACT4 Before Update tail @99-C86DB9BE
        STUDENT_CARER_CONTACT4Parameters()
        STUDENT_CARER_CONTACT4LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT4Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT4Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT4Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT4 Before Update tail

'Record Form STUDENT_CARER_CONTACT4 Update Operation tail @99-F7F99F8C
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Update Operation tail

'Record Form STUDENT_CARER_CONTACT4 Delete Operation @99-157DAC6B
    Protected Sub STUDENT_CARER_CONTACT4_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT4 Delete Operation

'Button Button_Delete OnClick. @102-56FBB579
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Delete" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @102-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @99-AE34F759
        STUDENT_CARER_CONTACT4Parameters()
        STUDENT_CARER_CONTACT4LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @99-32EEFB0B
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT4 Cancel Operation @99-9FD0C850

    Protected Sub STUDENT_CARER_CONTACT4_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT4LoadItemFromRequest(item, True)
'End Record Form STUDENT_CARER_CONTACT4 Cancel Operation

'Record Form STUDENT_CARER_CONTACT4 Cancel Operation tail @99-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Cancel Operation tail

'Grid Grid_FamilyGroup Bind @256-766ED78A

    Protected Sub Grid_FamilyGroupBind()
        If Not Grid_FamilyGroupOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_FamilyGroup",GetType(Grid_FamilyGroupDataProvider.SortFields), 20, 100)
        End If
'End Grid Grid_FamilyGroup Bind

'Grid Form Grid_FamilyGroup BeforeShow tail @256-5B393C61
        Grid_FamilyGroupParameters()
        Grid_FamilyGroupData.SortField = CType(ViewState("Grid_FamilyGroupSortField"),Grid_FamilyGroupDataProvider.SortFields)
        Grid_FamilyGroupData.SortDir = CType(ViewState("Grid_FamilyGroupSortDir"),SortDirections)
        Grid_FamilyGroupData.PageNumber = CInt(ViewState("Grid_FamilyGroupPageNumber"))
        Grid_FamilyGroupData.RecordsPerPage = CInt(ViewState("Grid_FamilyGroupPageSize"))
        Grid_FamilyGroupRepeater.DataSource = Grid_FamilyGroupData.GetResultSet(PagesCount, Grid_FamilyGroupOperations)
        ViewState("Grid_FamilyGroupPagesCount") = PagesCount
        Dim item As Grid_FamilyGroupItem = New Grid_FamilyGroupItem()
        CType(Page,CCPage).ControlAttributes.Add(Grid_FamilyGroupRepeater,New CCSControlAttribute("numberOfColumns", FieldType._Text, (1)))
        Grid_FamilyGroupRepeater.DataBind
        FooterIndex = Grid_FamilyGroupRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_FamilyGroupRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form Grid_FamilyGroup BeforeShow tail

'Grid Grid_FamilyGroup Bind tail @256-E31F8E2A
    End Sub
'End Grid Grid_FamilyGroup Bind tail

'Grid Grid_FamilyGroup Table Parameters @256-371FA5DF

    Protected Sub Grid_FamilyGroupParameters()
        Try
            Grid_FamilyGroupData.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=Grid_FamilyGroupRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_FamilyGroupRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_FamilyGroup: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_FamilyGroup Table Parameters

'Grid Grid_FamilyGroup ItemDataBound event @256-866BAB1E

    Protected Sub Grid_FamilyGroupItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_FamilyGroupItem = CType(e.Item.DataItem,Grid_FamilyGroupItem)
        Dim Item as Grid_FamilyGroupItem = DataItem
        Dim FormDataSource As Grid_FamilyGroupItem() = CType(Grid_FamilyGroupRepeater.DataSource, Grid_FamilyGroupItem())
        Dim Grid_FamilyGroupDataRows As Integer = FormDataSource.Length
        Dim Grid_FamilyGroupIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_FamilyGroupCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_FamilyGroupRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_FamilyGroupCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_FamilyGroupRowOpenTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowOpenTag"),System.Web.UI.WebControls.PlaceHolder)
            Dim Grid_FamilyGroupRowComponents As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowComponents"),System.Web.UI.WebControls.PlaceHolder)
            Dim Grid_FamilyGroupSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_FamilyGroupSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid_FamilyGroupfirst_name As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGroupfirst_name"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGroupsurname As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGroupsurname"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGrouplast_enrol_year As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_FamilyGrouplast_enrol_year"),System.Web.UI.WebControls.Literal)
            Dim Grid_FamilyGroupRowCloseTag As System.Web.UI.WebControls.PlaceHolder = DirectCast(e.Item.FindControl("Grid_FamilyGroupRowCloseTag"),System.Web.UI.WebControls.PlaceHolder)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            Grid_FamilyGroupSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","", ViewState)
        End If
'End Grid Grid_FamilyGroup ItemDataBound event

'Grid Grid_FamilyGroup BeforeShowRow event @256-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid_FamilyGroup BeforeShowRow event

'Grid Grid_FamilyGroup Event BeforeShowRow. Action Gallery Layout @259-04C8B05D
            Utility.ManageGalleryPanels(e.Item, CInt(CType(Page,CCPage).ControlAttributes.GetAttribute("Grid_FamilyGroupRepeater","numberOfColumns")), Grid_FamilyGroupCurrentRowNumber, Grid_FamilyGroupData.RecordsPerPage, "Grid_FamilyGroupRowOpenTag", "Grid_FamilyGroupRowCloseTag", "Grid_FamilyGroupRowComponents", Grid_FamilyGroupDataRows, Grid_FamilyGroupIsForceIteration)
'End Grid Grid_FamilyGroup Event BeforeShowRow. Action Gallery Layout

'Grid Grid_FamilyGroup BeforeShowRow event tail @256-477CF3C9
        End If
'End Grid Grid_FamilyGroup BeforeShowRow event tail

'Grid Grid_FamilyGroup ItemDataBound event tail @256-E964BC14
        If Grid_FamilyGroupIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_FamilyGroupCurrentRowNumber, ListItemType.Item)
            Grid_FamilyGroupRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_FamilyGroupItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_FamilyGroup ItemDataBound event tail

'Grid Grid_FamilyGroup ItemCommand event @256-FFA97CD5

    Protected Sub Grid_FamilyGroupItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_FamilyGroupRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_FamilyGroupSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_FamilyGroupSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_FamilyGroupSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_FamilyGroupSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_FamilyGroupSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_FamilyGroupDataProvider.SortFields = 0
            ViewState("Grid_FamilyGroupSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_FamilyGroupPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_FamilyGroupPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_FamilyGroupPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_FamilyGroupPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_FamilyGroupBind
        End If
    End Sub
'End Grid Grid_FamilyGroup ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-86520A08
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Carer_FamilyGroupingContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CARER_CONTACT3Data = New STUDENT_CARER_CONTACT3DataProvider()
        STUDENT_CARER_CONTACT3Operations = New FormSupportedOperations(False, True, False, True, False)
        viewMaintainSearchRequestData = New viewMaintainSearchRequestDataProvider()
        viewMaintainSearchRequestOperations = New FormSupportedOperations(False, True, False, False, False)
        viewMaintainSearchRequestSearchData = New viewMaintainSearchRequestSearchDataProvider()
        viewMaintainSearchRequestSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STUDENT_CARER_CONTACT4Data = New STUDENT_CARER_CONTACT4DataProvider()
        STUDENT_CARER_CONTACT4Operations = New FormSupportedOperations(False, True, False, True, False)
        Grid_FamilyGroupData = New Grid_FamilyGroupDataProvider()
        Grid_FamilyGroupOperations = New FormSupportedOperations(False, True, False, False, False)
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

