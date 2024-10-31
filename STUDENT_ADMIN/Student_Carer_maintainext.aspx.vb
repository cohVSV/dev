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

Namespace DECV_PROD2007.Student_Carer_maintainext 'Namespace @1-59A439EF

'Forms Definition @1-DDCAE7E9
Public Class [Student_Carer_maintainextPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-B28F46E9
    Protected STUDENT_CARER_CONTACTData As STUDENT_CARER_CONTACTDataProvider
    Protected STUDENT_CARER_CONTACTOperations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACTCurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT1Data As STUDENT_CARER_CONTACT1DataProvider
    Protected STUDENT_CARER_CONTACT1Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT1CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT2Data As STUDENT_CARER_CONTACT2DataProvider
    Protected STUDENT_CARER_CONTACT2Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT2CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT3Data As STUDENT_CARER_CONTACT3DataProvider
    Protected STUDENT_CARER_CONTACT3Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT3Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT3IsSubmitted As Boolean = False
    Protected STUDENT_CARER_CONTACT4Data As STUDENT_CARER_CONTACT4DataProvider
    Protected STUDENT_CARER_CONTACT4Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT4Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT4IsSubmitted As Boolean = False
    Protected ListSchoolSupervisorsData As ListSchoolSupervisorsDataProvider
    Protected ListSchoolSupervisorsErrors As NameValueCollection = New NameValueCollection()
    Protected ListSchoolSupervisorsOperations As FormSupportedOperations
    Protected ListSchoolSupervisorsIsSubmitted As Boolean = False
    Protected STUDENT_CARER_CONTACT5Data As STUDENT_CARER_CONTACT5DataProvider
    Protected STUDENT_CARER_CONTACT5Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT5CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACTSearchData As STUDENT_CARER_CONTACTSearchDataProvider
    Protected STUDENT_CARER_CONTACTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACTSearchOperations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACTSearchIsSubmitted As Boolean = False
    Protected STUDENT_CARER_CONTACT6Data As STUDENT_CARER_CONTACT6DataProvider
    Protected STUDENT_CARER_CONTACT6Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT6Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT6IsSubmitted As Boolean = False
    Protected STUDENT_CARER_CONTACT7Data As STUDENT_CARER_CONTACT7DataProvider
    Protected STUDENT_CARER_CONTACT7Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT7CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT8Data As STUDENT_CARER_CONTACT8DataProvider
    Protected STUDENT_CARER_CONTACT8Operations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT8CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACT_EMERGENCY_EDITData As STUDENT_CARER_CONTACT_EMERGENCY_EDITDataProvider
    Protected STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACT_EMERGENCY_EDITIsSubmitted As Boolean = False
    Protected Student_Carer_maintainextContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A9F64D7E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_CARER_CONTACTBind
            STUDENT_CARER_CONTACT1Bind
            STUDENT_CARER_CONTACT2Bind
            STUDENT_CARER_CONTACT3Show()
            STUDENT_CARER_CONTACT4Show()
            ListSchoolSupervisorsShow()
            STUDENT_CARER_CONTACT5Bind
            STUDENT_CARER_CONTACTSearchShow()
            STUDENT_CARER_CONTACT6Show()
            STUDENT_CARER_CONTACT7Bind
            STUDENT_CARER_CONTACT8Bind
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel1 Event BeforeShow. Action Hide-Show Component @545-1A00B148
        Dim Urlcarertype_545_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_545_2 As TextField = New TextField("", ("S"))
        If FieldBase.EqualOp(Urlcarertype_545_1, ExprParam2_545_2) Then
            Panel1.Visible = False
        End If
'End Panel Panel1 Event BeforeShow. Action Hide-Show Component

'DEL      ' -------------------------
'DEL      ' ERA: if no records in Parent A, then don't even show parent B
'DEL      ' -------------------------


    End Sub 'Page_Load Event tail @1-E31F8E2A

'BeforeOutput Event @1-E563A382
Private Sub BeforeOutput(MainHTML As String, responseStream As Stream, ByRef Result As Boolean)
Result  = True
'End BeforeOutput Event

'BeforeOutput Event tail @1-E31F8E2A
End Sub
'End BeforeOutput Event tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_CARER_CONTACT Bind @3-C4822082

    Protected Sub STUDENT_CARER_CONTACTBind()
        If Not STUDENT_CARER_CONTACTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT",GetType(STUDENT_CARER_CONTACTDataProvider.SortFields), 1, 1)
        End If
'End Grid STUDENT_CARER_CONTACT Bind

'Grid Form STUDENT_CARER_CONTACT BeforeShow tail @3-58114D12
        STUDENT_CARER_CONTACTParameters()
        STUDENT_CARER_CONTACTData.SortField = CType(ViewState("STUDENT_CARER_CONTACTSortField"),STUDENT_CARER_CONTACTDataProvider.SortFields)
        STUDENT_CARER_CONTACTData.SortDir = CType(ViewState("STUDENT_CARER_CONTACTSortDir"),SortDirections)
        STUDENT_CARER_CONTACTData.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACTPageNumber"))
        STUDENT_CARER_CONTACTData.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACTPageSize"))
        STUDENT_CARER_CONTACTRepeater.DataSource = STUDENT_CARER_CONTACTData.GetResultSet(PagesCount, STUDENT_CARER_CONTACTOperations)
        ViewState("STUDENT_CARER_CONTACTPagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        STUDENT_CARER_CONTACTRepeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_CARER_CONTACTlink_AddParent As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACTRepeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACTlink_AddParent"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim STUDENT_CARER_CONTACTlinkFamilyGroup As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACTRepeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACTlinkFamilyGroup"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.link_AddParentHref = "Student_Carer_maintainext.aspx"
        item.link_AddParentHrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("A").ToString()))
        item.linkFamilyGroupHref = "Student_Carer_FamilyGrouping.aspx"
        STUDENT_CARER_CONTACTlink_AddParent.InnerText += item.link_AddParent.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACTlink_AddParent.HRef = item.link_AddParentHref+item.link_AddParentHrefParameters.ToString("GET","CARER_ID;STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
        STUDENT_CARER_CONTACTlinkFamilyGroup.InnerText += item.linkFamilyGroup.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACTlinkFamilyGroup.HRef = item.linkFamilyGroupHref+item.linkFamilyGroupHrefParameters.ToString("GET","", ViewState)
'End Grid Form STUDENT_CARER_CONTACT BeforeShow tail

'Grid STUDENT_CARER_CONTACT Bind tail @3-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT Bind tail

'Grid STUDENT_CARER_CONTACT Table Parameters @3-6D9B2426

    Protected Sub STUDENT_CARER_CONTACTParameters()
        Try
            STUDENT_CARER_CONTACTData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT Table Parameters

'Grid STUDENT_CARER_CONTACT ItemDataBound event @3-0F3C33EE

    Protected Sub STUDENT_CARER_CONTACTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACTItem = CType(e.Item.DataItem,STUDENT_CARER_CONTACTItem)
        Dim Item as STUDENT_CARER_CONTACTItem = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACTItem() = CType(STUDENT_CARER_CONTACTRepeater.DataSource, STUDENT_CARER_CONTACTItem())
        Dim STUDENT_CARER_CONTACTDataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACTCARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTCARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTTITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTTITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTRELATIONSHIP As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTRELATIONSHIP"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STUDENT_CARER_CONTACTHOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTHOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTWORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTWORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTMOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTMOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTEMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTEMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACTSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTSURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACTLink_EditParentA As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTLink_EditParentA"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTPORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACTRELATIONSHIP.Items.Add(new ListItem("Select Value",""))
            STUDENT_CARER_CONTACTRELATIONSHIP.Items(0).Selected = True
            DataItem.RELATIONSHIPItems.SetSelection(DataItem.RELATIONSHIP.GetFormattedValue())
            If Not DataItem.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
                STUDENT_CARER_CONTACTRELATIONSHIP.SelectedIndex = -1
            End If
            DataItem.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACTRELATIONSHIP.Items)
            STUDENT_CARER_CONTACTEMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
            DataItem.Link_EditParentAHref = "Student_Carer_maintainext.aspx"
            DataItem.Link_EditParentAHrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("A").ToString()))
            STUDENT_CARER_CONTACTLink_EditParentA.HRef = DataItem.Link_EditParentAHref & DataItem.Link_EditParentAHrefParameters.ToString("GET","STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT ItemDataBound event

'STUDENT_CARER_CONTACT control Before Show @3-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT control Before Show

'Get Control @12-14865EBD
            Dim STUDENT_CARER_CONTACTEMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACTEMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

      ' -------------------------
      ' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding VSV Student").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACTEMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if
      ' -------------------------

'Link EMAIL Event BeforeShow. Action Custom Code @63-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT control Before Show tail @3-477CF3C9
        End If
'End STUDENT_CARER_CONTACT control Before Show tail

'Grid STUDENT_CARER_CONTACT ItemDataBound event tail @3-C1013562
        If STUDENT_CARER_CONTACTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACTCurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT ItemCommand event @3-0CA7373B

    Protected Sub STUDENT_CARER_CONTACTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACTDataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACTBind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT ItemCommand event

'Grid STUDENT_CARER_CONTACT1 Bind @13-1EB6D292

    Protected Sub STUDENT_CARER_CONTACT1Bind()
        If Not STUDENT_CARER_CONTACT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT1",GetType(STUDENT_CARER_CONTACT1DataProvider.SortFields), 1, 1)
        End If
'End Grid STUDENT_CARER_CONTACT1 Bind

'Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail @13-8FA05452
        STUDENT_CARER_CONTACT1Parameters()
        STUDENT_CARER_CONTACT1Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT1SortField"),STUDENT_CARER_CONTACT1DataProvider.SortFields)
        STUDENT_CARER_CONTACT1Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections)
        STUDENT_CARER_CONTACT1Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT1PageNumber"))
        STUDENT_CARER_CONTACT1Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT1PageSize"))
        STUDENT_CARER_CONTACT1Repeater.DataSource = STUDENT_CARER_CONTACT1Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT1Operations)
        ViewState("STUDENT_CARER_CONTACT1PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT1Item = New STUDENT_CARER_CONTACT1Item()
        STUDENT_CARER_CONTACT1Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_CARER_CONTACT1link_AddParent As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACT1Repeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACT1link_AddParent"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.link_AddParentHref = "Student_Carer_maintainext.aspx"
        item.link_AddParentHrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("B").ToString()))
        STUDENT_CARER_CONTACT1link_AddParent.InnerText += item.link_AddParent.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACT1link_AddParent.HRef = item.link_AddParentHref+item.link_AddParentHrefParameters.ToString("GET","CARER_ID", ViewState)
'End Grid Form STUDENT_CARER_CONTACT1 BeforeShow tail

'Grid STUDENT_CARER_CONTACT1 Bind tail @13-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Bind tail

'Grid STUDENT_CARER_CONTACT1 Table Parameters @13-6FD750E0

    Protected Sub STUDENT_CARER_CONTACT1Parameters()
        Try
            STUDENT_CARER_CONTACT1Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT1 Table Parameters

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event @13-3E9E3062

    Protected Sub STUDENT_CARER_CONTACT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT1Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT1Item)
        Dim Item as STUDENT_CARER_CONTACT1Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT1Item() = CType(STUDENT_CARER_CONTACT1Repeater.DataSource, STUDENT_CARER_CONTACT1Item())
        Dim STUDENT_CARER_CONTACT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT1CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT1Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT1RELATIONSHIP As System.Web.UI.HtmlControls.HtmlSelect = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1RELATIONSHIP"),System.Web.UI.HtmlControls.HtmlSelect)
            Dim STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1PORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACT1EMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
            DataItem.Link1Href = "Student_Carer_maintainext.aspx"
            DataItem.Link1HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("B").ToString()))
            STUDENT_CARER_CONTACT1Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
            STUDENT_CARER_CONTACT1RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
            STUDENT_CARER_CONTACT1RELATIONSHIP.Items(0).Selected = True
            DataItem.RELATIONSHIPItems.SetSelection(DataItem.RELATIONSHIP.GetFormattedValue())
            If Not DataItem.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
                STUDENT_CARER_CONTACT1RELATIONSHIP.SelectedIndex = -1
            End If
            DataItem.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT1RELATIONSHIP.Items)
        End If
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event

'STUDENT_CARER_CONTACT1 control Before Show @13-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT1 control Before Show

'Get Control @20-4A89D30C
            Dim STUDENT_CARER_CONTACT1EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT1EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL Event BeforeShow. Action Custom Code @64-73254650
    ' -------------------------
	' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	'NOTE Form name ...Contact1
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding VSV Student").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACT1EMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if
    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT1 control Before Show tail @13-477CF3C9
        End If
'End STUDENT_CARER_CONTACT1 control Before Show tail

'Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail @13-348AA5A8
        If STUDENT_CARER_CONTACT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT1CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT1 ItemCommand event @13-AAD04B91

    Protected Sub STUDENT_CARER_CONTACT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT1DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT1Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT1 ItemCommand event

'Grid STUDENT_CARER_CONTACT2 Bind @23-690FF79E

    Protected Sub STUDENT_CARER_CONTACT2Bind()
        If Not STUDENT_CARER_CONTACT2Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT2",GetType(STUDENT_CARER_CONTACT2DataProvider.SortFields), 1, 1)
        End If
'End Grid STUDENT_CARER_CONTACT2 Bind

'Grid Form STUDENT_CARER_CONTACT2 BeforeShow tail @23-35E97C2A
        STUDENT_CARER_CONTACT2Parameters()
        STUDENT_CARER_CONTACT2Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT2SortField"),STUDENT_CARER_CONTACT2DataProvider.SortFields)
        STUDENT_CARER_CONTACT2Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT2SortDir"),SortDirections)
        STUDENT_CARER_CONTACT2Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT2PageNumber"))
        STUDENT_CARER_CONTACT2Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT2PageSize"))
        STUDENT_CARER_CONTACT2Repeater.DataSource = STUDENT_CARER_CONTACT2Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT2Operations)
        ViewState("STUDENT_CARER_CONTACT2PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT2Item = New STUDENT_CARER_CONTACT2Item()
        STUDENT_CARER_CONTACT2Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT2Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT2Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_CARER_CONTACT2link_AddParent As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACT2Repeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACT2link_AddParent"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim STUDENT_CARER_CONTACT2lblSupervisor As System.Web.UI.WebControls.Literal = DirectCast(STUDENT_CARER_CONTACT2Repeater.Controls(0).FindControl("STUDENT_CARER_CONTACT2lblSupervisor"),System.Web.UI.WebControls.Literal)

        item.link_AddParentHref = "Student_Carer_maintainext.aspx"
        item.link_AddParentHrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("S").ToString()))
        STUDENT_CARER_CONTACT2link_AddParent.InnerText += item.link_AddParent.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACT2link_AddParent.HRef = item.link_AddParentHref+item.link_AddParentHrefParameters.ToString("GET","CARER_ID;STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
        STUDENT_CARER_CONTACT2lblSupervisor.Text = Server.HtmlEncode(item.lblSupervisor.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form STUDENT_CARER_CONTACT2 BeforeShow tail

'Grid STUDENT_CARER_CONTACT2 Bind tail @23-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Bind tail

'Grid STUDENT_CARER_CONTACT2 Table Parameters @23-C777A0DB

    Protected Sub STUDENT_CARER_CONTACT2Parameters()
        Try
            STUDENT_CARER_CONTACT2Data.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
            STUDENT_CARER_CONTACT2Data.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT2Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT2Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT2: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT2 Table Parameters

'Grid STUDENT_CARER_CONTACT2 ItemDataBound event @23-CE61DD37

    Protected Sub STUDENT_CARER_CONTACT2ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT2Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT2Item)
        Dim Item as STUDENT_CARER_CONTACT2Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT2Item() = CType(STUDENT_CARER_CONTACT2Repeater.DataSource, STUDENT_CARER_CONTACT2Item())
        Dim STUDENT_CARER_CONTACT2DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT2IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT2CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT2Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT2CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT2CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT2SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2Link_EditSupervisor As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2Link_EditSupervisor"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT2LinkAddSupervisor2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2LinkAddSupervisor2"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SUPERVISOR_POSITION_OTHER"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2SUPERVISOR_POSITION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2SUPERVISOR_POSITION"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2PORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT2Supervisortype As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2Supervisortype"),System.Web.UI.WebControls.Literal)
            STUDENT_CARER_CONTACT2EMAIL.HRef = DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
            DataItem.Link_EditSupervisorHref = "Student_Carer_maintainext.aspx"
            DataItem.Link_EditSupervisorHrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("S").ToString()))
            STUDENT_CARER_CONTACT2Link_EditSupervisor.HRef = DataItem.Link_EditSupervisorHref & DataItem.Link_EditSupervisorHrefParameters.ToString("GET","STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
            DataItem.LinkAddSupervisor2Href = "Student_Carer_maintainext.aspx"
            DataItem.LinkAddSupervisor2HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("S").ToString()))
            STUDENT_CARER_CONTACT2LinkAddSupervisor2.HRef = DataItem.LinkAddSupervisor2Href & DataItem.LinkAddSupervisor2HrefParameters.ToString("GET","CARER_ID;STUDENT_CARER_CONTACT2PageSize;STUDENT_CARER_CONTACTDir;STUDENT_CARER_CONTACT2Dir;STUDENT_CARER_CONTACT1Dir;STUDENT_CARER_CONTACTageSize;STUDENT_CARER_CONTACT1PageSize;", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT2 ItemDataBound event

'STUDENT_CARER_CONTACT2 control Before Show @23-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT2 control Before Show

'Get Control @30-19D1C384
            Dim STUDENT_CARER_CONTACT2EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT2EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL Event BeforeShow. Action Custom Code @65-73254650
    ' -------------------------
	' ERA: add the parameters of student name and number to email mailto link - note: could do it through the parameter wizard but it insists on UrlEncoding which puts '+' in for every ' ' (space)
	'NOTE Form name ...Contact2
		DataItem.EMAILHrefParameters.Add("subject",("Message regarding VSV Student").ToString())
  		if not IsDBNull(DataItem.EMAILHref) then
  			STUDENT_CARER_CONTACT2EMAIL.HRef = "mailto:" + DataItem.EMAILHref & DataItem.EMAILHrefParameters.ToString("None","", ViewState)
	  	end if

    ' -------------------------
'End Link EMAIL Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      '26-Oct-2018|EA| display special supervisor type if not School Supervisor
'DEL      Dim STUDENT_CARER_CONTACT2lblSupervisor As System.Web.UI.WebControls.Literal = DirectCast(STUDENT_CARER_CONTACT2Repeater.Controls(0).FindControl("STUDENT_CARER_CONTACT2lblSupervisor"),System.Web.UI.WebControls.Literal)
'DEL      STUDENT_CARER_CONTACT2lblSupervisor.Text = "School Supervisor"
'DEL      if (DataItem.Supervisortype.GetFormattedValue() <> "") then
'DEL      	STUDENT_CARER_CONTACT2lblSupervisor.Text = DataItem.Supervisortype.GetFormattedValue()
'DEL      end if
'DEL      ' -------------------------


'STUDENT_CARER_CONTACT2 control Before Show tail @23-477CF3C9
        End If
'End STUDENT_CARER_CONTACT2 control Before Show tail

'Grid STUDENT_CARER_CONTACT2 ItemDataBound event tail @23-82B2D1A7
        If STUDENT_CARER_CONTACT2IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT2CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT2Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT2ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT2 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT2 ItemCommand event @23-2BC3CD4C

    Protected Sub STUDENT_CARER_CONTACT2ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT2Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT2SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT2SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT2SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT2SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT2SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT2DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT2SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT2PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT2PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT2Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT2 ItemCommand event

'Record Form STUDENT_CARER_CONTACT3 Parameters @33-0CAF781A

    Protected Sub STUDENT_CARER_CONTACT3Parameters()
        Dim item As new STUDENT_CARER_CONTACT3Item
        Try
            STUDENT_CARER_CONTACT3Data.UrlCARER_ID = FloatParameter.GetParam("CARER_ID", ParameterSourceType.URL, "", 0, false)
            STUDENT_CARER_CONTACT3Data.UrlStudent_ID = FloatParameter.GetParam("Student_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlTITLE = TextParameter.GetParam(item.TITLE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlSURNAME = TextParameter.GetParam(item.SURNAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlFIRST_NAME = TextParameter.GetParam(item.FIRST_NAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlRELATIONSHIP = TextParameter.GetParam(item.RELATIONSHIP.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlHOME_PHONE = TextParameter.GetParam(item.HOME_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlWORK_PHONE = TextParameter.GetParam(item.WORK_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlMOBILE = TextParameter.GetParam(item.MOBILE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlEMAIL = TextParameter.GetParam(item.EMAIL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlHidden_LAST_ALTERED_BY = TextParameter.GetParam(item.Hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT3Data.CtrlHidden_STUDENT_ID = TextParameter.GetParam(item.Hidden_STUDENT_ID.Value, ParameterSourceType.Control, "", 0, false)
            STUDENT_CARER_CONTACT3Data.CtrlHidden_CarerId = TextParameter.GetParam(item.Hidden_CarerId.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            STUDENT_CARER_CONTACT3Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Parameters

'Record Form STUDENT_CARER_CONTACT3 Show method @33-6B025CB6
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

'Record Form STUDENT_CARER_CONTACT3 BeforeShow tail @33-367E492C
        STUDENT_CARER_CONTACT3Parameters()
        STUDENT_CARER_CONTACT3Data.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT3Holder.DataBind()
        STUDENT_CARER_CONTACT3Button_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACT3Operations.AllowInsert
        STUDENT_CARER_CONTACT3Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT3Operations.AllowUpdate
        STUDENT_CARER_CONTACT3Button_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT3Operations.AllowDelete
        STUDENT_CARER_CONTACT3TITLE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT3TITLE.Items(0).Selected = True
        item.TITLEItems.SetSelection(item.TITLE.GetFormattedValue())
        If Not item.TITLEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT3TITLE.SelectedIndex = -1
        End If
        item.TITLEItems.CopyTo(STUDENT_CARER_CONTACT3TITLE.Items)
        STUDENT_CARER_CONTACT3SURNAME.Text=item.SURNAME.GetFormattedValue()
        STUDENT_CARER_CONTACT3FIRST_NAME.Text=item.FIRST_NAME.GetFormattedValue()
        STUDENT_CARER_CONTACT3RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT3RELATIONSHIP.Items(0).Selected = True
        item.RELATIONSHIPItems.SetSelection(item.RELATIONSHIP.GetFormattedValue())
        If Not item.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT3RELATIONSHIP.SelectedIndex = -1
        End If
        item.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT3RELATIONSHIP.Items)
        STUDENT_CARER_CONTACT3HOME_PHONE.Text=item.HOME_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACT3WORK_PHONE.Text=item.WORK_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACT3MOBILE.Text=item.MOBILE.GetFormattedValue()
        STUDENT_CARER_CONTACT3EMAIL.Text=item.EMAIL.GetFormattedValue()
        STUDENT_CARER_CONTACT3LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value = item.Hidden_STUDENT_ID.GetFormattedValue()
        STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_CARER_CONTACT3lblCARER_ID.Text = Server.HtmlEncode(item.lblCARER_ID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT3Hidden_CarerId.Value = item.Hidden_CarerId.GetFormattedValue()
        STUDENT_CARER_CONTACT3Hidden_DuperCarer.Value = item.Hidden_DuperCarer.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACT3 BeforeShow tail

'Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @171-D3D960B1
            STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden Hidden_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component @75-D0853F33
        Dim Urlcarertype_75_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_75_2 As TextField = New TextField("", ("S"))
        If FieldBase.EqualOp(Urlcarertype_75_1, ExprParam2_75_2) Then
            STUDENT_CARER_CONTACT3Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component

'Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component @133-0CC42881
        Dim Urlcarertype_133_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_133_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urlcarertype_133_1, ExprParam2_133_2) Then
            STUDENT_CARER_CONTACT3Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component

'Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component @546-8DAD1FE1
        Dim Urlcarertype_546_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_546_2 As TextField = New TextField("", ("A"))
        If FieldBase.EqualOp(Urlcarertype_546_1, ExprParam2_546_2) Then
            STUDENT_CARER_CONTACT3Button_Delete.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component

'Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component @653-E2BDAFF8
        Dim Urlcarertype_653_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_653_2 As TextField = New TextField("", ("E"))
        If FieldBase.EqualOp(Urlcarertype_653_1, ExprParam2_653_2) Then
            STUDENT_CARER_CONTACT3Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT3 Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT3 Show method tail @33-9A35F43C
        If STUDENT_CARER_CONTACT3Errors.Count > 0 Then
            STUDENT_CARER_CONTACT3ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Show method tail

'Record Form STUDENT_CARER_CONTACT3 LoadItemFromRequest method @33-9E5356EB

    Protected Sub STUDENT_CARER_CONTACT3LoadItemFromRequest(item As STUDENT_CARER_CONTACT3Item, ByVal EnableValidation As Boolean)
        item.TITLE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3TITLE.UniqueID))
        item.TITLE.SetValue(STUDENT_CARER_CONTACT3TITLE.Value)
        item.TITLEItems.CopyFrom(STUDENT_CARER_CONTACT3TITLE.Items)
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3SURNAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3SURNAME") Is Nothing Then
            item.SURNAME.SetValue(STUDENT_CARER_CONTACT3SURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3SURNAME"))
        End If
        item.FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3FIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3FIRST_NAME") Is Nothing Then
            item.FIRST_NAME.SetValue(STUDENT_CARER_CONTACT3FIRST_NAME.Text)
        Else
            item.FIRST_NAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3FIRST_NAME"))
        End If
        item.RELATIONSHIP.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3RELATIONSHIP.UniqueID))
        item.RELATIONSHIP.SetValue(STUDENT_CARER_CONTACT3RELATIONSHIP.Value)
        item.RELATIONSHIPItems.CopyFrom(STUDENT_CARER_CONTACT3RELATIONSHIP.Items)
        item.HOME_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3HOME_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3HOME_PHONE") Is Nothing Then
            item.HOME_PHONE.SetValue(STUDENT_CARER_CONTACT3HOME_PHONE.Text)
        Else
            item.HOME_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3HOME_PHONE"))
        End If
        item.WORK_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3WORK_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3WORK_PHONE") Is Nothing Then
            item.WORK_PHONE.SetValue(STUDENT_CARER_CONTACT3WORK_PHONE.Text)
        Else
            item.WORK_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3WORK_PHONE"))
        End If
        item.MOBILE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3MOBILE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3MOBILE") Is Nothing Then
            item.MOBILE.SetValue(STUDENT_CARER_CONTACT3MOBILE.Text)
        Else
            item.MOBILE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3MOBILE"))
        End If
        item.EMAIL.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3EMAIL.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT3EMAIL") Is Nothing Then
            item.EMAIL.SetValue(STUDENT_CARER_CONTACT3EMAIL.Text)
        Else
            item.EMAIL.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT3EMAIL"))
        End If
        item.Hidden_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.UniqueID))
        item.Hidden_STUDENT_ID.SetValue(STUDENT_CARER_CONTACT3Hidden_STUDENT_ID.Value)
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value)
        item.Hidden_CarerId.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_CarerId.UniqueID))
        item.Hidden_CarerId.SetValue(STUDENT_CARER_CONTACT3Hidden_CarerId.Value)
        Try
        item.Hidden_DuperCarer.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT3Hidden_DuperCarer.UniqueID))
        item.Hidden_DuperCarer.SetValue(STUDENT_CARER_CONTACT3Hidden_DuperCarer.Value)
        Catch ae As ArgumentException
            STUDENT_CARER_CONTACT3Errors.Add("Hidden_DuperCarer",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_DuperCarer"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT3Data)
        End If
        STUDENT_CARER_CONTACT3Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT3 GetRedirectUrl method @33-778889E4

    Protected Function GetSTUDENT_CARER_CONTACT3RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","CARER_ID;carertype;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT3 GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT3 ShowErrors method @33-6E817C65

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

'Record Form STUDENT_CARER_CONTACT3 Insert Operation @33-64852650

    Protected Sub STUDENT_CARER_CONTACT3_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        Dim ExecuteFlag As Boolean = True
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT3 Insert Operation

'Button Button_Insert OnClick. @34-9621A83C
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @34-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT3 BeforeInsert tail @33-67859E84
    STUDENT_CARER_CONTACT3Parameters()
    STUDENT_CARER_CONTACT3LoadItemFromRequest(item, EnableValidation)
    If STUDENT_CARER_CONTACT3Operations.AllowInsert Then
        ErrorFlag=(STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT3Data.InsertItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT3Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT3 BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT3 AfterInsert tail  @33-6A575A40
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT3 Update Operation @33-0E52FABE

    Protected Sub STUDENT_CARER_CONTACT3_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT3 Update Operation

'Button Button_Update OnClick. @35-C3D40432
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @35-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Retrieve Value for Control @291-17EE561C
        STUDENT_CARER_CONTACT3Hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_CARER_CONTACT3 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_CARER_CONTACT3 Before Update tail @33-EF02AA52
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

'Record Form STUDENT_CARER_CONTACT3 Update Operation tail @33-6A575A40
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Update Operation tail

'Record Form STUDENT_CARER_CONTACT3 Delete Operation @33-E301F236
    Protected Sub STUDENT_CARER_CONTACT3_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT3 Delete Operation

'Button Button_Delete OnClick. @36-D38CE750
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Delete" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @36-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @33-1460BD40
        STUDENT_CARER_CONTACT3Parameters()
        STUDENT_CARER_CONTACT3LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT3Operations.AllowDelete Then
        ErrorFlag = (STUDENT_CARER_CONTACT3Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT3Data.DeleteItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT3Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @33-2F7C6765
        End If
        If ErrorFlag Then
            STUDENT_CARER_CONTACT3ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT3 Cancel Operation @33-DC88A918

    Protected Sub STUDENT_CARER_CONTACT3_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT3Item = New STUDENT_CARER_CONTACT3Item()
        STUDENT_CARER_CONTACT3IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT3LoadItemFromRequest(item, False)
'End Record Form STUDENT_CARER_CONTACT3 Cancel Operation

'Button Button_Cancel OnClick. @38-3013081A
    If CType(sender,Control).ID = "STUDENT_CARER_CONTACT3Button_Cancel" Then
        RedirectUrl = GetSTUDENT_CARER_CONTACT3RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @38-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CARER_CONTACT3 Cancel Operation tail @33-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT3 Cancel Operation tail

'DEL      Protected Sub Grid_SchoolSupervisorlink_carer_idUpdateDB1_SchoolSupervisorExecute()
'DEL          Dim UpdateDB1_SchoolSupervisorUpdate As TableCommand 
'DEL          UpdateDB1_SchoolSupervisorUpdate=new TableCommand("UPDATE STUDENT_ENROLMENT SET CARER_ID_SCHOOL_SUPERVISOR={CARER_ID_SCHOOL_SUPERVISOR}", New String(){"STUDENT_ID141","And","ENROLMENT_YEAR142"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'DEL          Dim UrlSTUDENT_ID As FloatParameter  = FloatParameter.GetParam("UrlSTUDENT_ID", ParameterSourceType.Form, "", Nothing, false)
'DEL          Dim UrlENROLMENT_YEAR As FloatParameter  = FloatParameter.GetParam("UrlENROLMENT_YEAR", ParameterSourceType.Form, "", Nothing, false)
'DEL          CType(UpdateDB1_SchoolSupervisorUpdate,TableCommand).AddParameter("STUDENT_ID141",UrlSTUDENT_ID, "","STUDENT_ID",Condition.Equal,False)
'DEL          CType(UpdateDB1_SchoolSupervisorUpdate,TableCommand).AddParameter("ENROLMENT_YEAR142",UrlENROLMENT_YEAR, "","ENROLMENT_YEAR",Condition.Equal,False)
'DEL  		'ERA: 29-Nov-2010 manually added "" in the 'New IntegerField("", Request.Form...' code as not generated and seemed to be a problem
'DEL          UpdateDB1_SchoolSupervisorUpdate.SqlQuery.Replace("{CARER_ID_SCHOOL_SUPERVISOR}",UpdateDB1_SchoolSupervisorUpdate.Dao.ToSql(New IntegerField("", Request.Form("CARER_ID")).GetFormattedValue(""""), FieldType._Integer))
'DEL          Try
'DEL              UpdateDB1_SchoolSupervisorUpdate.ExecuteNonQuery()
'DEL          Catch e As Exception
'DEL              Response.Write(e.Message)
'DEL              Response.StatusCode = 500
'DEL          Finally
'DEL              Response.End()
'DEL          End Try
'DEL      End Sub


'Record Form STUDENT_CARER_CONTACT4 Parameters @103-6613846C

    Protected Sub STUDENT_CARER_CONTACT4Parameters()
        Dim item As new STUDENT_CARER_CONTACT4Item
        Try
            STUDENT_CARER_CONTACT4Data.ExprKey243 = TextParameter.GetParam("", ParameterSourceType.Expression, "", "", false)
            STUDENT_CARER_CONTACT4Data.UrlCARER_ID = FloatParameter.GetParam("CARER_ID", ParameterSourceType.URL, "", 0, false)
            STUDENT_CARER_CONTACT4Data.UrlStudent_ID = FloatParameter.GetParam("Student_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlTITLE = TextParameter.GetParam(item.TITLE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlSURNAME = TextParameter.GetParam(item.SURNAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlFIRST_NAME = TextParameter.GetParam(item.FIRST_NAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlRELATIONSHIP = TextParameter.GetParam(item.RELATIONSHIP.Value, ParameterSourceType.Control, "", "SS", false)
            STUDENT_CARER_CONTACT4Data.ExprKey248 = TextParameter.GetParam("", ParameterSourceType.Expression, "", "", false)
            STUDENT_CARER_CONTACT4Data.CtrlWORK_PHONE = TextParameter.GetParam(item.WORK_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlMOBILE = TextParameter.GetParam(item.MOBILE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlEMAIL = TextParameter.GetParam(item.EMAIL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlHidden_LAST_ALTERED_BY = TextParameter.GetParam(item.Hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlSUPERVISOR_POSITION = TextParameter.GetParam(item.SUPERVISOR_POSITION.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlSUPERVISOR_POSITION_OTHER = TextParameter.GetParam(item.SUPERVISOR_POSITION_OTHER.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT4Data.CtrlHidden_NewCarerID = IntegerParameter.GetParam(item.Hidden_NewCarerID.Value, ParameterSourceType.Control, "", 0, false)
        Catch e As Exception
            STUDENT_CARER_CONTACT4Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Parameters

'Record Form STUDENT_CARER_CONTACT4 Show method @103-6F5E23AF
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

'Record Form STUDENT_CARER_CONTACT4 BeforeShow tail @103-64A00A1E
        STUDENT_CARER_CONTACT4Parameters()
        STUDENT_CARER_CONTACT4Data.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT4Holder.DataBind()
        STUDENT_CARER_CONTACT4Button_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACT4Operations.AllowInsert
        STUDENT_CARER_CONTACT4Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT4Operations.AllowUpdate
        STUDENT_CARER_CONTACT4Button_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT4Operations.AllowDelete
        STUDENT_CARER_CONTACT4TITLE.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT4TITLE.Items(0).Selected = True
        item.TITLEItems.SetSelection(item.TITLE.GetFormattedValue())
        If Not item.TITLEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT4TITLE.SelectedIndex = -1
        End If
        item.TITLEItems.CopyTo(STUDENT_CARER_CONTACT4TITLE.Items)
        STUDENT_CARER_CONTACT4SURNAME.Text=item.SURNAME.GetFormattedValue()
        STUDENT_CARER_CONTACT4FIRST_NAME.Text=item.FIRST_NAME.GetFormattedValue()
        STUDENT_CARER_CONTACT4WORK_PHONE.Text=item.WORK_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACT4MOBILE.Text=item.MOBILE.GetFormattedValue()
        STUDENT_CARER_CONTACT4EMAIL.Text=item.EMAIL.GetFormattedValue()
        STUDENT_CARER_CONTACT4LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_CARER_CONTACT4Hidden_NewCarerID.Value = item.Hidden_NewCarerID.GetFormattedValue()
        STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.Items(0).Selected = True
        item.SUPERVISOR_POSITIONItems.SetSelection(item.SUPERVISOR_POSITION.GetFormattedValue())
        If Not item.SUPERVISOR_POSITIONItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.SelectedIndex = -1
        End If
        item.SUPERVISOR_POSITIONItems.CopyTo(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.Items)
        STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER.Text=item.SUPERVISOR_POSITION_OTHER.GetFormattedValue()
        STUDENT_CARER_CONTACT4RELATIONSHIP.Items.Add(new ListItem("Select Value",""))
        STUDENT_CARER_CONTACT4RELATIONSHIP.Items(0).Selected = True
        item.RELATIONSHIPItems.SetSelection(item.RELATIONSHIP.GetFormattedValue())
        If Not item.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACT4RELATIONSHIP.SelectedIndex = -1
        End If
        item.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACT4RELATIONSHIP.Items)
'End Record Form STUDENT_CARER_CONTACT4 BeforeShow tail

'Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Hide-Show Component @127-BBBFD6C5
        Dim Urlcarertype_127_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_127_2 As TextField = New TextField("", ("S"))
        If FieldBase.NotEqualOp(Urlcarertype_127_1, ExprParam2_127_2) Then
            STUDENT_CARER_CONTACT4Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT4 Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT4 Show method tail @103-B0440F22
        If STUDENT_CARER_CONTACT4Errors.Count > 0 Then
            STUDENT_CARER_CONTACT4ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Show method tail

'Record Form STUDENT_CARER_CONTACT4 LoadItemFromRequest method @103-BF9EF51C

    Protected Sub STUDENT_CARER_CONTACT4LoadItemFromRequest(item As STUDENT_CARER_CONTACT4Item, ByVal EnableValidation As Boolean)
        item.TITLE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4TITLE.UniqueID))
        item.TITLE.SetValue(STUDENT_CARER_CONTACT4TITLE.Value)
        item.TITLEItems.CopyFrom(STUDENT_CARER_CONTACT4TITLE.Items)
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4SURNAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4SURNAME") Is Nothing Then
            item.SURNAME.SetValue(STUDENT_CARER_CONTACT4SURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4SURNAME"))
        End If
        item.FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4FIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4FIRST_NAME") Is Nothing Then
            item.FIRST_NAME.SetValue(STUDENT_CARER_CONTACT4FIRST_NAME.Text)
        Else
            item.FIRST_NAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4FIRST_NAME"))
        End If
        item.WORK_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4WORK_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4WORK_PHONE") Is Nothing Then
            item.WORK_PHONE.SetValue(STUDENT_CARER_CONTACT4WORK_PHONE.Text)
        Else
            item.WORK_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4WORK_PHONE"))
        End If
        item.MOBILE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4MOBILE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4MOBILE") Is Nothing Then
            item.MOBILE.SetValue(STUDENT_CARER_CONTACT4MOBILE.Text)
        Else
            item.MOBILE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4MOBILE"))
        End If
        item.EMAIL.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4EMAIL.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4EMAIL") Is Nothing Then
            item.EMAIL.SetValue(STUDENT_CARER_CONTACT4EMAIL.Text)
        Else
            item.EMAIL.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4EMAIL"))
        End If
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value)
        Try
        item.Hidden_NewCarerID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4Hidden_NewCarerID.UniqueID))
        item.Hidden_NewCarerID.SetValue(STUDENT_CARER_CONTACT4Hidden_NewCarerID.Value)
        Catch ae As ArgumentException
            STUDENT_CARER_CONTACT4Errors.Add("Hidden_NewCarerID",String.Format(Resources.strings.CCS_IncorrectValue,"Hidden_NewCarerID"))
        End Try
        item.SUPERVISOR_POSITION.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.UniqueID))
        item.SUPERVISOR_POSITION.SetValue(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.Value)
        item.SUPERVISOR_POSITIONItems.CopyFrom(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION.Items)
        item.SUPERVISOR_POSITION_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER") Is Nothing Then
            item.SUPERVISOR_POSITION_OTHER.SetValue(STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER.Text)
        Else
            item.SUPERVISOR_POSITION_OTHER.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT4SUPERVISOR_POSITION_OTHER"))
        End If
        item.RELATIONSHIP.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT4RELATIONSHIP.UniqueID))
        item.RELATIONSHIP.SetValue(STUDENT_CARER_CONTACT4RELATIONSHIP.Value)
        item.RELATIONSHIPItems.CopyFrom(STUDENT_CARER_CONTACT4RELATIONSHIP.Items)
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT4Data)
        End If
        STUDENT_CARER_CONTACT4Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT4 GetRedirectUrl method @103-BF9C8175

    Protected Function GetSTUDENT_CARER_CONTACT4RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_maintainext.aspx"
        Dim p As String = parameters.ToString("GET","CARER_ID;carertype;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT4 GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT4 ShowErrors method @103-7B3C4534

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

'Record Form STUDENT_CARER_CONTACT4 Insert Operation @103-3D8202EA

    Protected Sub STUDENT_CARER_CONTACT4_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        Dim ExecuteFlag As Boolean = True
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT4 Insert Operation

'Button Button_Insert OnClick. @104-8443596E
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @104-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT4 BeforeInsert tail @103-40EA8D68
    STUDENT_CARER_CONTACT4Parameters()
    STUDENT_CARER_CONTACT4LoadItemFromRequest(item, EnableValidation)
    If STUDENT_CARER_CONTACT4Operations.AllowInsert Then
        ErrorFlag=(STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT4Data.InsertItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT4Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT4 BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT4 AfterInsert tail  @103-F7F99F8C
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT4 Update Operation @103-6DBE9AB2

    Protected Sub STUDENT_CARER_CONTACT4_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT4 Update Operation

'Button Button_Update OnClick. @105-D1B6F560
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @105-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Retrieve Value for Control @290-D8C7BAF8
        STUDENT_CARER_CONTACT4Hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_CARER_CONTACT4 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_CARER_CONTACT4 Before Update tail @103-C86DB9BE
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

'Record Form STUDENT_CARER_CONTACT4 Update Operation tail @103-F7F99F8C
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT4Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Update Operation tail

'Record Form STUDENT_CARER_CONTACT4 Delete Operation @103-157DAC6B
    Protected Sub STUDENT_CARER_CONTACT4_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT4 Delete Operation

'Button Button_Delete OnClick. @106-56FBB579
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Delete" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @106-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @103-AE34F759
        STUDENT_CARER_CONTACT4Parameters()
        STUDENT_CARER_CONTACT4LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @103-32EEFB0B
        If ErrorFlag Then
            STUDENT_CARER_CONTACT4ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT4 Cancel Operation @103-FB6C7FC1

    Protected Sub STUDENT_CARER_CONTACT4_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT4Item = New STUDENT_CARER_CONTACT4Item()
        STUDENT_CARER_CONTACT4IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT4LoadItemFromRequest(item, False)
'End Record Form STUDENT_CARER_CONTACT4 Cancel Operation

'Button Button_Cancel OnClick. @108-A3512F13
    If CType(sender,Control).ID = "STUDENT_CARER_CONTACT4Button_Cancel" Then
        RedirectUrl = GetSTUDENT_CARER_CONTACT4RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @108-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CARER_CONTACT4 Cancel Operation tail @103-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT4 Cancel Operation tail

'Record Form ListSchoolSupervisors Parameters @196-568D7B4A

    Protected Sub ListSchoolSupervisorsParameters()
        Dim item As new ListSchoolSupervisorsItem
        Try
            ListSchoolSupervisorsData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            ListSchoolSupervisorsData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
        Catch e As Exception
            ListSchoolSupervisorsErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ListSchoolSupervisors Parameters

'Record Form ListSchoolSupervisors Show method @196-16939131
    Protected Sub ListSchoolSupervisorsShow()
        If ListSchoolSupervisorsOperations.None Then
            ListSchoolSupervisorsHolder.Visible = False
            Return
        End If
        Dim item As ListSchoolSupervisorsItem = ListSchoolSupervisorsItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ListSchoolSupervisorsOperations.AllowRead
        ListSchoolSupervisorsErrors.Add(item.errors)
        If ListSchoolSupervisorsErrors.Count > 0 Then
            ListSchoolSupervisorsShowErrors()
            Return
        End If
'End Record Form ListSchoolSupervisors Show method

'Record Form ListSchoolSupervisors BeforeShow tail @196-EE3BA9CA
        ListSchoolSupervisorsParameters()
        ListSchoolSupervisorsData.FillItem(item, IsInsertMode)
        ListSchoolSupervisorsHolder.DataBind()
        ListSchoolSupervisorsButton_Update.Visible=Not (IsInsertMode) AndAlso ListSchoolSupervisorsOperations.AllowUpdate
        item.carer_id_SSItems.SetSelection(item.carer_id_SS.GetFormattedValue())
        ListSchoolSupervisorscarer_id_SS.SelectedIndex = -1
        item.carer_id_SSItems.CopyTo(ListSchoolSupervisorscarer_id_SS.Items)
'End Record Form ListSchoolSupervisors BeforeShow tail

'RadioButton carer_id_SS Event BeforeShow. Action Custom Code @238-73254650
    ' -------------------------
    '  ' ERA: make flow down screen not across
	ListSchoolSupervisorscarer_id_SS.RepeatDirection = RepeatDirection.Vertical

    ' -------------------------
'End RadioButton carer_id_SS Event BeforeShow. Action Custom Code

'Record ListSchoolSupervisors Event BeforeShow. Action Hide-Show Component @207-44BEA809
        Dim Urlcarertype_207_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_207_2 As TextField = New TextField("", ("S"))
        If FieldBase.NotEqualOp(Urlcarertype_207_1, ExprParam2_207_2) Then
            ListSchoolSupervisorsHolder.Visible = False
        End If
'End Record ListSchoolSupervisors Event BeforeShow. Action Hide-Show Component

'Record ListSchoolSupervisors Event BeforeShow. Action Custom Code @202-73254650
    ' -------------------------
    ' ERA: check if the list of School Supervisors in Radio buttons = 0 and hide.
	if ListSchoolSupervisorscarer_id_SS.Items.Count = 0 then
		ListSchoolSupervisorsHolder.visible = false
	end if
    ' -------------------------
'End Record ListSchoolSupervisors Event BeforeShow. Action Custom Code

'Record Form ListSchoolSupervisors Show method tail @196-63287A80
        If ListSchoolSupervisorsErrors.Count > 0 Then
            ListSchoolSupervisorsShowErrors()
        End If
    End Sub
'End Record Form ListSchoolSupervisors Show method tail

'Record Form ListSchoolSupervisors LoadItemFromRequest method @196-6D3C4CB5

    Protected Sub ListSchoolSupervisorsLoadItemFromRequest(item As ListSchoolSupervisorsItem, ByVal EnableValidation As Boolean)
        item.carer_id_SS.IsEmpty = IsNothing(Request.Form(ListSchoolSupervisorscarer_id_SS.UniqueID))
        If Not IsNothing(ListSchoolSupervisorscarer_id_SS.SelectedItem) Then
            item.carer_id_SS.SetValue(ListSchoolSupervisorscarer_id_SS.SelectedItem.Value)
        Else
            item.carer_id_SS.Value = Nothing
        End If
        item.carer_id_SSItems.CopyFrom(ListSchoolSupervisorscarer_id_SS.Items)
        If EnableValidation Then
            item.Validate(ListSchoolSupervisorsData)
        End If
        ListSchoolSupervisorsErrors.Add(item.errors)
    End Sub
'End Record Form ListSchoolSupervisors LoadItemFromRequest method

'Record Form ListSchoolSupervisors GetRedirectUrl method @196-67EDB370

    Protected Function GetListSchoolSupervisorsRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_maintainext.aspx"
        Dim p As String = parameters.ToString("GET","CARER_ID;carertype;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ListSchoolSupervisors GetRedirectUrl method

'Record Form ListSchoolSupervisors ShowErrors method @196-8A18CE5A

    Protected Sub ListSchoolSupervisorsShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ListSchoolSupervisorsErrors.Count - 1
        Select Case ListSchoolSupervisorsErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ListSchoolSupervisorsErrors(i)
        End Select
        Next i
        ListSchoolSupervisorsError.Visible = True
        ListSchoolSupervisorsErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ListSchoolSupervisors ShowErrors method

'Record Form ListSchoolSupervisors Insert Operation @196-C04AC8D8

    Protected Sub ListSchoolSupervisors_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ListSchoolSupervisorsItem = New ListSchoolSupervisorsItem()
        ListSchoolSupervisorsIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ListSchoolSupervisors Insert Operation

'Record Form ListSchoolSupervisors BeforeInsert tail @196-DF8A7246
    ListSchoolSupervisorsParameters()
    ListSchoolSupervisorsLoadItemFromRequest(item, EnableValidation)
'End Record Form ListSchoolSupervisors BeforeInsert tail

'Record Form ListSchoolSupervisors AfterInsert tail  @196-508BB805
        ErrorFlag=(ListSchoolSupervisorsErrors.Count > 0)
        If ErrorFlag Then
            ListSchoolSupervisorsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ListSchoolSupervisors AfterInsert tail 

'Record Form ListSchoolSupervisors Update Operation @196-66E199A6

    Protected Sub ListSchoolSupervisors_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ListSchoolSupervisorsItem = New ListSchoolSupervisorsItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        ListSchoolSupervisorsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ListSchoolSupervisors Update Operation

'Button Button_Update OnClick. @199-A6AAF2ED
        If CType(sender,Control).ID = "ListSchoolSupervisorsButton_Update" Then
            RedirectUrl = GetListSchoolSupervisorsRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @199-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form ListSchoolSupervisors Before Update tail @196-93652EAF
        ListSchoolSupervisorsParameters()
        ListSchoolSupervisorsLoadItemFromRequest(item, EnableValidation)
        If ListSchoolSupervisorsOperations.AllowUpdate Then
        ErrorFlag = (ListSchoolSupervisorsErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ListSchoolSupervisorsData.UpdateItem(item)
            Catch ex As Exception
                ListSchoolSupervisorsErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ListSchoolSupervisors Before Update tail

'Record Form ListSchoolSupervisors Update Operation tail @196-CC4A94A7
        End If
        ErrorFlag=(ListSchoolSupervisorsErrors.Count > 0)
        If ErrorFlag Then
            ListSchoolSupervisorsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ListSchoolSupervisors Update Operation tail

'Record Form ListSchoolSupervisors Delete Operation @196-49C3FC98
    Protected Sub ListSchoolSupervisors_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ListSchoolSupervisorsIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ListSchoolSupervisorsItem = New ListSchoolSupervisorsItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ListSchoolSupervisors Delete Operation

'Record Form BeforeDelete tail @196-DF8A7246
        ListSchoolSupervisorsParameters()
        ListSchoolSupervisorsLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @196-5F8212FE
        If ErrorFlag Then
            ListSchoolSupervisorsShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ListSchoolSupervisors Cancel Operation @196-DB54C83D

    Protected Sub ListSchoolSupervisors_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ListSchoolSupervisorsItem = New ListSchoolSupervisorsItem()
        ListSchoolSupervisorsIsSubmitted = True
        Dim RedirectUrl As String = ""
        ListSchoolSupervisorsLoadItemFromRequest(item, True)
'End Record Form ListSchoolSupervisors Cancel Operation

'Button Button_Cancel OnClick. @237-4E244906
    If CType(sender,Control).ID = "ListSchoolSupervisorsButton_Cancel" Then
        RedirectUrl = GetListSchoolSupervisorsRedirectUrl("Student_Carer_maintainext.aspx", "carertype;CARER_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @237-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form ListSchoolSupervisors Cancel Operation tail @196-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ListSchoolSupervisors Cancel Operation tail

'Grid STUDENT_CARER_CONTACT5 Bind @398-64116FD0

    Protected Sub STUDENT_CARER_CONTACT5Bind()
        If Not STUDENT_CARER_CONTACT5Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT5",GetType(STUDENT_CARER_CONTACT5DataProvider.SortFields), 10, 50)
        End If
'End Grid STUDENT_CARER_CONTACT5 Bind

'Grid Form STUDENT_CARER_CONTACT5 BeforeShow tail @398-5B21E18E
        STUDENT_CARER_CONTACT5Parameters()
        STUDENT_CARER_CONTACT5Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT5SortField"),STUDENT_CARER_CONTACT5DataProvider.SortFields)
        STUDENT_CARER_CONTACT5Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT5SortDir"),SortDirections)
        STUDENT_CARER_CONTACT5Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT5PageNumber"))
        STUDENT_CARER_CONTACT5Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT5PageSize"))
        STUDENT_CARER_CONTACT5Repeater.DataSource = STUDENT_CARER_CONTACT5Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT5Operations)
        ViewState("STUDENT_CARER_CONTACT5PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT5Item = New STUDENT_CARER_CONTACT5Item()
        STUDENT_CARER_CONTACT5Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT5Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT5Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_CARER_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_CARER_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_HOME_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_HOME_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MOBILESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_MOBILESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_EMAILSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_EMAILSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PORTAL_LAST_LOGIN_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(0).FindControl("Sorter_PORTAL_LAST_LOGIN_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_CARER_CONTACT5Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form STUDENT_CARER_CONTACT5 BeforeShow tail

'Grid STUDENT_CARER_CONTACT5 Event BeforeShow. Action Hide-Show Component @536-FDC2C516
        Dim UrllinkCarerID_536_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("linkCarerID"))
        Dim ExprParam2_536_2 As TextField = New TextField("", (""))
        If FieldBase.NotEqualOp(UrllinkCarerID_536_1, ExprParam2_536_2) Then
            STUDENT_CARER_CONTACT5Repeater.Visible = False
        End If
'End Grid STUDENT_CARER_CONTACT5 Event BeforeShow. Action Hide-Show Component

'Grid STUDENT_CARER_CONTACT5 Bind tail @398-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT5 Bind tail

'Grid STUDENT_CARER_CONTACT5 Table Parameters @398-A64B9AA4

    Protected Sub STUDENT_CARER_CONTACT5Parameters()
        Try
            STUDENT_CARER_CONTACT5Data.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT5Data.Urls_FIRST_NAME = TextParameter.GetParam("s_FIRST_NAME", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT5Data.Urls_EMAIL = TextParameter.GetParam("s_EMAIL", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT5Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT5Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT5: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT5 Table Parameters

'Grid STUDENT_CARER_CONTACT5 ItemDataBound event @398-1AA5E02A

    Protected Sub STUDENT_CARER_CONTACT5ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT5Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT5Item)
        Dim Item as STUDENT_CARER_CONTACT5Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT5Item() = CType(STUDENT_CARER_CONTACT5Repeater.DataSource, STUDENT_CARER_CONTACT5Item())
        Dim STUDENT_CARER_CONTACT5DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT5IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT5CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT5Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT5CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT5Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_CARER_CONTACT5CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5EMAIL"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5PORTAL_LAST_LOGIN_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5PORTAL_LAST_LOGIN_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT5RELATIONSHIP As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5RELATIONSHIP"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "Student_Carer_maintainext.aspx"
            DataItem.DetailHrefParameters.Add("STUDENT_ID",Request.QueryString,"STUDENT_ID")
            DataItem.DetailHrefParameters.Add("ENROLMENT_YEAR",Request.QueryString,"ENROLMENT_YEAR")
            STUDENT_CARER_CONTACT5Detail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("None","", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT5 ItemDataBound event

'STUDENT_CARER_CONTACT5 control Before Show @398-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End STUDENT_CARER_CONTACT5 control Before Show

'Get Control @407-696147F6
            Dim STUDENT_CARER_CONTACT5Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT5Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link Detail Event BeforeShow. Action Custom Code @568-73254650
    ' -------------------------
    '5-Dec-2018|EA| if relationship is "SS" then hide link
    	if (DataItem.RELATIONSHIP.GetFormattedValue() = "SS") then
    		STUDENT_CARER_CONTACT5Detail.Visible = false
    	else
    		STUDENT_CARER_CONTACT5Detail.Visible = true
    	end if
    ' -------------------------
'End Link Detail Event BeforeShow. Action Custom Code

'STUDENT_CARER_CONTACT5 control Before Show tail @398-477CF3C9
        End If
'End STUDENT_CARER_CONTACT5 control Before Show tail

'Grid STUDENT_CARER_CONTACT5 ItemDataBound event tail @398-585B13FD
        If STUDENT_CARER_CONTACT5IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT5CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT5Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT5ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT5 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT5 ItemCommand event @398-8D9B44FC

    Protected Sub STUDENT_CARER_CONTACT5ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT5Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT5SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT5SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT5SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT5SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT5SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT5DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT5SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT5PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT5PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT5Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT5 ItemCommand event

'Record Form STUDENT_CARER_CONTACTSearch Parameters @434-270BE092

    Protected Sub STUDENT_CARER_CONTACTSearchParameters()
        Dim item As new STUDENT_CARER_CONTACTSearchItem
        Try
        Catch e As Exception
            STUDENT_CARER_CONTACTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch Parameters

'Record Form STUDENT_CARER_CONTACTSearch Show method @434-57B3CE29
    Protected Sub STUDENT_CARER_CONTACTSearchShow()
        If STUDENT_CARER_CONTACTSearchOperations.None Then
            STUDENT_CARER_CONTACTSearchHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACTSearchItem = STUDENT_CARER_CONTACTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACTSearchOperations.AllowRead
        item.ClearParametersHref = "Student_Carer_maintainext.aspx"
        STUDENT_CARER_CONTACTSearchErrors.Add(item.errors)
        If STUDENT_CARER_CONTACTSearchErrors.Count > 0 Then
            STUDENT_CARER_CONTACTSearchShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACTSearch Show method

'Record Form STUDENT_CARER_CONTACTSearch BeforeShow tail @434-9377DE18
        STUDENT_CARER_CONTACTSearchParameters()
        STUDENT_CARER_CONTACTSearchData.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACTSearchHolder.DataBind()
        STUDENT_CARER_CONTACTSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACTSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_SURNAME;s_FIRST_NAME;s_EMAIL", ViewState)
        STUDENT_CARER_CONTACTSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        STUDENT_CARER_CONTACTSearchs_FIRST_NAME.Text=item.s_FIRST_NAME.GetFormattedValue()
        STUDENT_CARER_CONTACTSearchs_EMAIL.Text=item.s_EMAIL.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACTSearch BeforeShow tail

'Record Form STUDENT_CARER_CONTACTSearch Show method tail @434-4AE19220
        If STUDENT_CARER_CONTACTSearchErrors.Count > 0 Then
            STUDENT_CARER_CONTACTSearchShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch Show method tail

'Record Form STUDENT_CARER_CONTACTSearch LoadItemFromRequest method @434-0C8AF9EB

    Protected Sub STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item As STUDENT_CARER_CONTACTSearchItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTSearchs_SURNAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTSearchs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(STUDENT_CARER_CONTACTSearchs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTSearchs_SURNAME"))
        End If
        item.s_FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTSearchs_FIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTSearchs_FIRST_NAME") Is Nothing Then
            item.s_FIRST_NAME.SetValue(STUDENT_CARER_CONTACTSearchs_FIRST_NAME.Text)
        Else
            item.s_FIRST_NAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTSearchs_FIRST_NAME"))
        End If
        item.s_EMAIL.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTSearchs_EMAIL.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTSearchs_EMAIL") Is Nothing Then
            item.s_EMAIL.SetValue(STUDENT_CARER_CONTACTSearchs_EMAIL.Text)
        Else
            item.s_EMAIL.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTSearchs_EMAIL"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACTSearchData)
        End If
        STUDENT_CARER_CONTACTSearchErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACTSearch GetRedirectUrl method @434-BE452203

    Protected Function GetSTUDENT_CARER_CONTACTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_maintainext.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACTSearch GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACTSearch ShowErrors method @434-AD77F283

    Protected Sub STUDENT_CARER_CONTACTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACTSearchErrors.Count - 1
        Select Case STUDENT_CARER_CONTACTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACTSearchErrors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACTSearchError.Visible = True
        STUDENT_CARER_CONTACTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch ShowErrors method

'Record Form STUDENT_CARER_CONTACTSearch Insert Operation @434-27A0172A

    Protected Sub STUDENT_CARER_CONTACTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        STUDENT_CARER_CONTACTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACTSearch Insert Operation

'Record Form STUDENT_CARER_CONTACTSearch BeforeInsert tail @434-C2D6A73C
    STUDENT_CARER_CONTACTSearchParameters()
    STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACTSearch BeforeInsert tail

'Record Form STUDENT_CARER_CONTACTSearch AfterInsert tail  @434-534CCA84
        ErrorFlag=(STUDENT_CARER_CONTACTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch AfterInsert tail 

'Record Form STUDENT_CARER_CONTACTSearch Update Operation @434-97FB86EB

    Protected Sub STUDENT_CARER_CONTACTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACTSearch Update Operation

'Record Form STUDENT_CARER_CONTACTSearch Before Update tail @434-C2D6A73C
        STUDENT_CARER_CONTACTSearchParameters()
        STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACTSearch Before Update tail

'Record Form STUDENT_CARER_CONTACTSearch Update Operation tail @434-534CCA84
        ErrorFlag=(STUDENT_CARER_CONTACTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch Update Operation tail

'Record Form STUDENT_CARER_CONTACTSearch Delete Operation @434-8CCE24C9
    Protected Sub STUDENT_CARER_CONTACTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACTSearch Delete Operation

'Record Form BeforeDelete tail @434-C2D6A73C
        STUDENT_CARER_CONTACTSearchParameters()
        STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @434-9C0C6FA2
        If ErrorFlag Then
            STUDENT_CARER_CONTACTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACTSearch Cancel Operation @434-941DFDA7

    Protected Sub STUDENT_CARER_CONTACTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        STUDENT_CARER_CONTACTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item, True)
'End Record Form STUDENT_CARER_CONTACTSearch Cancel Operation

'Record Form STUDENT_CARER_CONTACTSearch Cancel Operation tail @434-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch Cancel Operation tail

'Record Form STUDENT_CARER_CONTACTSearch Search Operation @434-B89CE351
    Protected Sub STUDENT_CARER_CONTACTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STUDENT_CARER_CONTACTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STUDENT_CARER_CONTACTSearchItem = New STUDENT_CARER_CONTACTSearchItem()
        STUDENT_CARER_CONTACTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACTSearch Search Operation

'Button Button_DoSearch OnClick. @436-861FA2C5
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACTSearchButton_DoSearch" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACTSearchRedirectUrl("", "s_SURNAME;s_FIRST_NAME;s_EMAIL")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @436-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENT_CARER_CONTACTSearch Search Operation tail @434-91A52BB5
        ErrorFlag = STUDENT_CARER_CONTACTSearchErrors.Count > 0
        If ErrorFlag Then
            STUDENT_CARER_CONTACTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STUDENT_CARER_CONTACTSearchs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(STUDENT_CARER_CONTACTSearchs_SURNAME.Text) & "&"), "")
            Params = Params & IIf(STUDENT_CARER_CONTACTSearchs_FIRST_NAME.Text <> "",("s_FIRST_NAME=" & Server.UrlEncode(STUDENT_CARER_CONTACTSearchs_FIRST_NAME.Text) & "&"), "")
            Params = Params & IIf(STUDENT_CARER_CONTACTSearchs_EMAIL.Text <> "",("s_EMAIL=" & Server.UrlEncode(STUDENT_CARER_CONTACTSearchs_EMAIL.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACTSearch Search Operation tail

'Record Form STUDENT_CARER_CONTACT6 Parameters @441-6EA86B59

    Protected Sub STUDENT_CARER_CONTACT6Parameters()
        Dim item As new STUDENT_CARER_CONTACT6Item
        Try
            STUDENT_CARER_CONTACT6Data.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", DateTime.Now.Year, false)
            STUDENT_CARER_CONTACT6Data.CtrlEMAIL = TextParameter.GetParam(item.EMAIL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT6Data.UrllinkCarerID = IntegerParameter.GetParam("linkCarerID", ParameterSourceType.URL, "", 0, false)
            STUDENT_CARER_CONTACT6Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)
            STUDENT_CARER_CONTACT6Data.CtrlradioCarerType = TextParameter.GetParam(item.radioCarerType.Value, ParameterSourceType.Control, "", "A", false)
        Catch e As Exception
            STUDENT_CARER_CONTACT6Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 Parameters

'Record Form STUDENT_CARER_CONTACT6 Show method @441-6C0D6AC9
    Protected Sub STUDENT_CARER_CONTACT6Show()
        If STUDENT_CARER_CONTACT6Operations.None Then
            STUDENT_CARER_CONTACT6Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACT6Item = STUDENT_CARER_CONTACT6Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACT6Operations.AllowRead
        STUDENT_CARER_CONTACT6Errors.Add(item.errors)
        If STUDENT_CARER_CONTACT6Errors.Count > 0 Then
            STUDENT_CARER_CONTACT6ShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACT6 Show method

'Record Form STUDENT_CARER_CONTACT6 BeforeShow tail @441-ECA2C457
        STUDENT_CARER_CONTACT6Parameters()
        STUDENT_CARER_CONTACT6Data.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT6Holder.DataBind()
        STUDENT_CARER_CONTACT6Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT6Operations.AllowUpdate
        STUDENT_CARER_CONTACT6Button_LinkParent.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT6Operations.AllowDelete
        STUDENT_CARER_CONTACT6FIRST_NAME.Text = Server.HtmlEncode(item.FIRST_NAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACT6EMAIL.Text=item.EMAIL.GetFormattedValue()
        STUDENT_CARER_CONTACT6SURNAME.Text = Server.HtmlEncode(item.SURNAME.GetFormattedValue()).Replace(vbCrLf,"<br>")
        item.radioCarerTypeItems.SetSelection(item.radioCarerType.GetFormattedValue())
        STUDENT_CARER_CONTACT6radioCarerType.SelectedIndex = -1
        item.radioCarerTypeItems.CopyTo(STUDENT_CARER_CONTACT6radioCarerType.Items)
'End Record Form STUDENT_CARER_CONTACT6 BeforeShow tail

'Record STUDENT_CARER_CONTACT6 Event BeforeShow. Action Hide-Show Component @537-70046719
        Dim UrllinkCarerID_537_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("linkCarerID"))
        Dim ExprParam2_537_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrllinkCarerID_537_1, ExprParam2_537_2) Then
            STUDENT_CARER_CONTACT6Holder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT6 Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT6 Show method tail @441-AC649E46
        If STUDENT_CARER_CONTACT6Errors.Count > 0 Then
            STUDENT_CARER_CONTACT6ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 Show method tail

'Record Form STUDENT_CARER_CONTACT6 LoadItemFromRequest method @441-0CC2FA57

    Protected Sub STUDENT_CARER_CONTACT6LoadItemFromRequest(item As STUDENT_CARER_CONTACT6Item, ByVal EnableValidation As Boolean)
        item.EMAIL.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT6EMAIL.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT6EMAIL") Is Nothing Then
            item.EMAIL.SetValue(STUDENT_CARER_CONTACT6EMAIL.Text)
        Else
            item.EMAIL.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT6EMAIL"))
        End If
        item.radioCarerType.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT6radioCarerType.UniqueID))
        If Not IsNothing(STUDENT_CARER_CONTACT6radioCarerType.SelectedItem) Then
            item.radioCarerType.SetValue(STUDENT_CARER_CONTACT6radioCarerType.SelectedItem.Value)
        Else
            item.radioCarerType.Value = Nothing
        End If
        item.radioCarerTypeItems.CopyFrom(STUDENT_CARER_CONTACT6radioCarerType.Items)
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT6Data)
        End If
        STUDENT_CARER_CONTACT6Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT6 GetRedirectUrl method @441-AC0A1E32

    Protected Function GetSTUDENT_CARER_CONTACT6RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "Student_Carer_maintainext.aspx"
        Dim p As String = parameters.ToString("GET","linkCarerID;s_EMAIL;s_SURNAME;s_FIRST_NAME;STUDENT_CARER_CONTACT5PageSize;CARER_ID;carertype;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT6 GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT6 ShowErrors method @441-FF628C54

    Protected Sub STUDENT_CARER_CONTACT6ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACT6Errors.Count - 1
        Select Case STUDENT_CARER_CONTACT6Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACT6Errors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACT6Error.Visible = True
        STUDENT_CARER_CONTACT6ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 ShowErrors method

'Record Form STUDENT_CARER_CONTACT6 Insert Operation @441-43AEE566

    Protected Sub STUDENT_CARER_CONTACT6_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT6Item = New STUDENT_CARER_CONTACT6Item()
        STUDENT_CARER_CONTACT6IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT6 Insert Operation

'Record Form STUDENT_CARER_CONTACT6 BeforeInsert tail @441-78BCA2DA
    STUDENT_CARER_CONTACT6Parameters()
    STUDENT_CARER_CONTACT6LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_CARER_CONTACT6 BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT6 AfterInsert tail  @441-791FE836
        ErrorFlag=(STUDENT_CARER_CONTACT6Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT6ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT6 Update Operation @441-CB00B5EC

    Protected Sub STUDENT_CARER_CONTACT6_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT6Item = New STUDENT_CARER_CONTACT6Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT6IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT6 Update Operation

'Button Button_Update OnClick. @443-9B78868A
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT6Button_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT6RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @443-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT_CARER_CONTACT6 Before Update tail @441-9439028D
        STUDENT_CARER_CONTACT6Parameters()
        STUDENT_CARER_CONTACT6LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT6Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_CARER_CONTACT6Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT6Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT6Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT6 Before Update tail

'Record STUDENT_CARER_CONTACT6 Event AfterUpdate. Action Save Variable Value @533-1F200E64
        HttpContext.Current.Session("notifymessage") = "Carer Email has been updated"
'End Record STUDENT_CARER_CONTACT6 Event AfterUpdate. Action Save Variable Value

'Record Form STUDENT_CARER_CONTACT6 Update Operation tail @441-D7F6C67F
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT6Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT6ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 Update Operation tail

'Record Form STUDENT_CARER_CONTACT6 Delete Operation @441-C4664E9A
    Protected Sub STUDENT_CARER_CONTACT6_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT6IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT6Item = New STUDENT_CARER_CONTACT6Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT6 Delete Operation

'Button Button_LinkParent OnClick. @444-F8012E0B
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT6Button_LinkParent" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT6RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_LinkParent OnClick.

'Button Button_LinkParent OnClick tail. @444-477CF3C9
        End If
'End Button Button_LinkParent OnClick tail.

'Record Form BeforeDelete tail @441-6F5B159F
        STUDENT_CARER_CONTACT6Parameters()
        STUDENT_CARER_CONTACT6LoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT6Operations.AllowDelete Then
        ErrorFlag = (STUDENT_CARER_CONTACT6Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT6Data.DeleteItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT6Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record STUDENT_CARER_CONTACT6 Event AfterDelete. Action Save Variable Value @534-E175D8ED
        HttpContext.Current.Session("notifymessage") = "Carer Linked to Student"
'End Record STUDENT_CARER_CONTACT6 Event AfterDelete. Action Save Variable Value

'Record Form AfterDelete tail @441-95D650FB
        End If
        If ErrorFlag Then
            STUDENT_CARER_CONTACT6ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT6 Cancel Operation @441-A7529C3C

    Protected Sub STUDENT_CARER_CONTACT6_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT6Item = New STUDENT_CARER_CONTACT6Item()
        STUDENT_CARER_CONTACT6IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT6LoadItemFromRequest(item, False)
'End Record Form STUDENT_CARER_CONTACT6 Cancel Operation

'Button Button_Cancel OnClick. @445-BF4C7625
    If CType(sender,Control).ID = "STUDENT_CARER_CONTACT6Button_Cancel" Then
        RedirectUrl = GetSTUDENT_CARER_CONTACT6RedirectUrl("", "linkCarerID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @445-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CARER_CONTACT6 Cancel Operation tail @441-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT6 Cancel Operation tail

'Grid STUDENT_CARER_CONTACT7 Bind @571-B9BA7FAC

    Protected Sub STUDENT_CARER_CONTACT7Bind()
        If Not STUDENT_CARER_CONTACT7Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT7",GetType(STUDENT_CARER_CONTACT7DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT7 Bind

'Grid Form STUDENT_CARER_CONTACT7 BeforeShow tail @571-E1FD3D75
        STUDENT_CARER_CONTACT7Parameters()
        STUDENT_CARER_CONTACT7Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT7SortField"),STUDENT_CARER_CONTACT7DataProvider.SortFields)
        STUDENT_CARER_CONTACT7Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT7SortDir"),SortDirections)
        STUDENT_CARER_CONTACT7Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT7PageNumber"))
        STUDENT_CARER_CONTACT7Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT7PageSize"))
        STUDENT_CARER_CONTACT7Repeater.DataSource = STUDENT_CARER_CONTACT7Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT7Operations)
        ViewState("STUDENT_CARER_CONTACT7PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT7Item = New STUDENT_CARER_CONTACT7Item()
        STUDENT_CARER_CONTACT7Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT7Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT7Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_CARER_CONTACT7Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACT7Repeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACT7Link1"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.Link1Href = ""
        item.Link1HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("E").ToString()))
        STUDENT_CARER_CONTACT7Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACT7Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
'End Grid Form STUDENT_CARER_CONTACT7 BeforeShow tail

'Grid STUDENT_CARER_CONTACT7 Bind tail @571-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT7 Bind tail

'Grid STUDENT_CARER_CONTACT7 Table Parameters @571-0A39863B

    Protected Sub STUDENT_CARER_CONTACT7Parameters()
        Try
            STUDENT_CARER_CONTACT7Data.UrlStudent_ID = IntegerParameter.GetParam("Student_ID", ParameterSourceType.URL, "", 66236, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT7Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT7Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT7: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT7 Table Parameters

'Grid STUDENT_CARER_CONTACT7 ItemDataBound event @571-A76AC681

    Protected Sub STUDENT_CARER_CONTACT7ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT7Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT7Item)
        Dim Item as STUDENT_CARER_CONTACT7Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT7Item() = CType(STUDENT_CARER_CONTACT7Repeater.DataSource, STUDENT_CARER_CONTACT7Item())
        Dim STUDENT_CARER_CONTACT7DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT7IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT7CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT7Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT7CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT7CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7SUPERVISOR_POSITION_OTHER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7SUPERVISOR_POSITION_OTHER"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT7Link2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT7Link2"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.Link2Href = ""
            DataItem.Link2HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("E").ToString()))
            STUDENT_CARER_CONTACT7Link2.HRef = DataItem.Link2Href & DataItem.Link2HrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT7 ItemDataBound event

'Grid STUDENT_CARER_CONTACT7 ItemDataBound event tail @571-838B4BF7
        If STUDENT_CARER_CONTACT7IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT7CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT7Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT7ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT7 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT7 ItemCommand event @571-7386406A

    Protected Sub STUDENT_CARER_CONTACT7ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT7Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT7SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT7SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT7SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT7SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT7SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT7DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT7SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT7PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT7PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT7PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT7PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT7Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT7 ItemCommand event

'Grid STUDENT_CARER_CONTACT8 Bind @590-7CCFD041

    Protected Sub STUDENT_CARER_CONTACT8Bind()
        If Not STUDENT_CARER_CONTACT8Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_CARER_CONTACT8",GetType(STUDENT_CARER_CONTACT8DataProvider.SortFields), 10, 100)
        End If
'End Grid STUDENT_CARER_CONTACT8 Bind

'Grid Form STUDENT_CARER_CONTACT8 BeforeShow tail @590-0E7FF415
        STUDENT_CARER_CONTACT8Parameters()
        STUDENT_CARER_CONTACT8Data.SortField = CType(ViewState("STUDENT_CARER_CONTACT8SortField"),STUDENT_CARER_CONTACT8DataProvider.SortFields)
        STUDENT_CARER_CONTACT8Data.SortDir = CType(ViewState("STUDENT_CARER_CONTACT8SortDir"),SortDirections)
        STUDENT_CARER_CONTACT8Data.PageNumber = CInt(ViewState("STUDENT_CARER_CONTACT8PageNumber"))
        STUDENT_CARER_CONTACT8Data.RecordsPerPage = CInt(ViewState("STUDENT_CARER_CONTACT8PageSize"))
        STUDENT_CARER_CONTACT8Repeater.DataSource = STUDENT_CARER_CONTACT8Data.GetResultSet(PagesCount, STUDENT_CARER_CONTACT8Operations)
        ViewState("STUDENT_CARER_CONTACT8PagesCount") = PagesCount
        Dim item As STUDENT_CARER_CONTACT8Item = New STUDENT_CARER_CONTACT8Item()
        STUDENT_CARER_CONTACT8Repeater.DataBind
        FooterIndex = STUDENT_CARER_CONTACT8Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_CARER_CONTACT8Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_CARER_CONTACT8Link2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_CARER_CONTACT8Repeater.Controls(FooterIndex).FindControl("STUDENT_CARER_CONTACT8Link2"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.Link2Href = ""
        item.Link2HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("E").ToString()))
        STUDENT_CARER_CONTACT8Link2.InnerText += item.Link2.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_CARER_CONTACT8Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("GET","", ViewState)
'End Grid Form STUDENT_CARER_CONTACT8 BeforeShow tail

'Grid STUDENT_CARER_CONTACT8 Bind tail @590-E31F8E2A
    End Sub
'End Grid STUDENT_CARER_CONTACT8 Bind tail

'Grid STUDENT_CARER_CONTACT8 Table Parameters @590-6FFBB642

    Protected Sub STUDENT_CARER_CONTACT8Parameters()
        Try
            STUDENT_CARER_CONTACT8Data.UrlStudent_ID = TextParameter.GetParam("Student_ID", ParameterSourceType.URL, "", 66236, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_CARER_CONTACT8Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_CARER_CONTACT8Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_CARER_CONTACT8: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_CARER_CONTACT8 Table Parameters

'Grid STUDENT_CARER_CONTACT8 ItemDataBound event @590-D9867A38

    Protected Sub STUDENT_CARER_CONTACT8ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_CARER_CONTACT8Item = CType(e.Item.DataItem,STUDENT_CARER_CONTACT8Item)
        Dim Item as STUDENT_CARER_CONTACT8Item = DataItem
        Dim FormDataSource As STUDENT_CARER_CONTACT8Item() = CType(STUDENT_CARER_CONTACT8Repeater.DataSource, STUDENT_CARER_CONTACT8Item())
        Dim STUDENT_CARER_CONTACT8DataRows As Integer = FormDataSource.Length
        Dim STUDENT_CARER_CONTACT8IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_CARER_CONTACT8CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_CARER_CONTACT8Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_CARER_CONTACT8CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_CARER_CONTACT8CARER_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8CARER_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8MOBILE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8SUPERVISOR_POSITION_OTHER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8SUPERVISOR_POSITION_OTHER"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_CARER_CONTACT8Link1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_CARER_CONTACT8Link1"),System.Web.UI.HtmlControls.HtmlAnchor)
            DataItem.Link1Href = ""
            DataItem.Link1HrefParameters.Add("carertype",System.Web.HttpUtility.UrlEncode(("E").ToString()))
            STUDENT_CARER_CONTACT8Link1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STUDENT_CARER_CONTACT8 ItemDataBound event

'Grid STUDENT_CARER_CONTACT8 ItemDataBound event tail @590-80C1E507
        If STUDENT_CARER_CONTACT8IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_CARER_CONTACT8CurrentRowNumber, ListItemType.Item)
            STUDENT_CARER_CONTACT8Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_CARER_CONTACT8ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT8 ItemDataBound event tail

'Grid STUDENT_CARER_CONTACT8 ItemCommand event @590-9B48D700

    Protected Sub STUDENT_CARER_CONTACT8ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_CARER_CONTACT8Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_CARER_CONTACT8SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_CARER_CONTACT8SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_CARER_CONTACT8SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_CARER_CONTACT8SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_CARER_CONTACT8SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_CARER_CONTACT8DataProvider.SortFields = 0
            ViewState("STUDENT_CARER_CONTACT8SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_CARER_CONTACT8PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_CARER_CONTACT8PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_CARER_CONTACT8PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_CARER_CONTACT8PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_CARER_CONTACT8Bind
        End If
    End Sub
'End Grid STUDENT_CARER_CONTACT8 ItemCommand event

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Parameters @654-B96A3486

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDITParameters()
        Dim item As new STUDENT_CARER_CONTACT_EMERGENCY_EDITItem
        Try
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlContact_ID = FloatParameter.GetParam("Contact_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey424 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey427 = TextParameter.GetParam("EC", ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey429 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlMobile = TextParameter.GetParam("Mobile", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey431 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey433 = TextParameter.GetParam("OT", ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey435 = IntegerParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlCARER_ID = FloatParameter.GetParam("CARER_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlStudent_ID = FloatParameter.GetParam("Student_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlEnrolmentYear = FloatParameter.GetParam("EnrolmentYear", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey440 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlSURNAME = TextParameter.GetParam(item.SURNAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlFIRST_NAME = TextParameter.GetParam(item.FIRST_NAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey443 = TextParameter.GetParam("EC", ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlHOME_PHONE = TextParameter.GetParam(item.HOME_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey445 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlMOBILE = TextParameter.GetParam(item.MOBILE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey447 = TextParameter.GetParam(Nothing, ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlHidden_LAST_ALTERED_BY = TextParameter.GetParam(item.Hidden_LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.ExprKey449 = TextParameter.GetParam("OT", ParameterSourceType.Expression, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.CtrlSUPERVISOR_POSITION_OTHER = TextParameter.GetParam(item.SUPERVISOR_POSITION_OTHER.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UrlNewCarerID = IntegerParameter.GetParam("NewCarerID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Parameters

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Show method @654-4AD539A3
    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDITShow()
        If STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.None Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = STUDENT_CARER_CONTACT_EMERGENCY_EDITItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowRead
        STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add(item.errors)
        If STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0 Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Show method

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeShow tail @654-EAD6FAC6
        STUDENT_CARER_CONTACT_EMERGENCY_EDITParameters()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITData.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACT_EMERGENCY_EDITHolder.DataBind()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowInsert
        STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowUpdate
        STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowDelete
        STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME.Text=item.FIRST_NAME.GetFormattedValue()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME.Text=item.SURNAME.GetFormattedValue()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE.Text=item.HOME_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE.Text=item.MOBILE.GetFormattedValue()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER.Text=item.SUPERVISOR_POSITION_OTHER.GetFormattedValue()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITHidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeShow tail

'Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Event BeforeShow. Action Hide-Show Component @677-AD79D577
        Dim Urlcarertype_677_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("carertype"))
        Dim ExprParam2_677_2 As TextField = New TextField("", ("E"))
        If FieldBase.NotEqualOp(Urlcarertype_677_1, ExprParam2_677_2) Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITHolder.Visible = False
        End If
'End Record STUDENT_CARER_CONTACT_EMERGENCY_EDIT Event BeforeShow. Action Hide-Show Component

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Show method tail @654-421E598A
        If STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0 Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Show method tail

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT LoadItemFromRequest method @654-7D4E2492

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDITLoadItemFromRequest(item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem, ByVal EnableValidation As Boolean)
        item.FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME") Is Nothing Then
            item.FIRST_NAME.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME.Text)
        Else
            item.FIRST_NAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITFIRST_NAME"))
        End If
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME") Is Nothing Then
            item.SURNAME.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITSURNAME"))
        End If
        item.HOME_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE") Is Nothing Then
            item.HOME_PHONE.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE.Text)
        Else
            item.HOME_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITHOME_PHONE"))
        End If
        item.MOBILE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE") Is Nothing Then
            item.MOBILE.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE.Text)
        Else
            item.MOBILE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITMOBILE"))
        End If
        item.SUPERVISOR_POSITION_OTHER.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER") Is Nothing Then
            item.SUPERVISOR_POSITION_OTHER.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER.Text)
        Else
            item.SUPERVISOR_POSITION_OTHER.SetValue(ControlCustomValues("STUDENT_CARER_CONTACT_EMERGENCY_EDITSUPERVISOR_POSITION_OTHER"))
        End If
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACT_EMERGENCY_EDITHidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACT_EMERGENCY_EDITHidden_LAST_ALTERED_BY.Value)
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACT_EMERGENCY_EDITData)
        End If
        STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT GetRedirectUrl method @654-5992E7DE

    Protected Function GetSTUDENT_CARER_CONTACT_EMERGENCY_EDITRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","CARER_ID;carertype;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT ShowErrors method @654-8A00D39C

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count - 1
        Select Case STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACT_EMERGENCY_EDITError.Visible = True
        STUDENT_CARER_CONTACT_EMERGENCY_EDITErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT ShowErrors method

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Insert Operation @654-61B21369

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = New STUDENT_CARER_CONTACT_EMERGENCY_EDITItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_CARER_CONTACT_EMERGENCY_EDITIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Insert Operation

'Button Button_Insert OnClick. @656-CE7DAA98
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT_EMERGENCY_EDITRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @656-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeInsert tail @654-E001D201
    STUDENT_CARER_CONTACT_EMERGENCY_EDITParameters()
    STUDENT_CARER_CONTACT_EMERGENCY_EDITLoadItemFromRequest(item, EnableValidation)
    If STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowInsert Then
        ErrorFlag=(STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT_EMERGENCY_EDITData.InsertItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterInsert tail  @654-F1D8E38B
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Update Operation @654-8EAD1ED4

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = New STUDENT_CARER_CONTACT_EMERGENCY_EDITItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT_EMERGENCY_EDITIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Update Operation

'Button Button_Update OnClick. @657-598FC063
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT_EMERGENCY_EDITRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @657-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Before Update tail @654-F4899950
        STUDENT_CARER_CONTACT_EMERGENCY_EDITParameters()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITLoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT_EMERGENCY_EDITData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Before Update tail

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Update Operation tail @654-F1D8E38B
        End If
        ErrorFlag=(STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Update Operation tail

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Delete Operation @654-976C7807
    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACT_EMERGENCY_EDITIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = New STUDENT_CARER_CONTACT_EMERGENCY_EDITItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Delete Operation

'Button Button_Delete OnClick. @658-4FF7D0CC
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Delete" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACT_EMERGENCY_EDITRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @658-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @654-E849650A
        STUDENT_CARER_CONTACT_EMERGENCY_EDITParameters()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITLoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations.AllowDelete Then
        ErrorFlag = (STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACT_EMERGENCY_EDITData.DeleteItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACT_EMERGENCY_EDITErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @654-35C7F38C
        End If
        If ErrorFlag Then
            STUDENT_CARER_CONTACT_EMERGENCY_EDITShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Cancel Operation @654-319FB21C

    Protected Sub STUDENT_CARER_CONTACT_EMERGENCY_EDIT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACT_EMERGENCY_EDITItem = New STUDENT_CARER_CONTACT_EMERGENCY_EDITItem()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACT_EMERGENCY_EDITLoadItemFromRequest(item, False)
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Cancel Operation

'Button Button_Cancel OnClick. @659-18DF65B4
    If CType(sender,Control).ID = "STUDENT_CARER_CONTACT_EMERGENCY_EDITButton_Cancel" Then
        RedirectUrl = GetSTUDENT_CARER_CONTACT_EMERGENCY_EDITRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @659-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Cancel Operation tail @654-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT_EMERGENCY_EDIT Cancel Operation tail

'DEL      ' -------------------------
'DEL  	' ERA: add the parameters mailto link -	'NOTE Form name ...STUDENT
'DEL  		DataItem.STUDENT_EMAILHrefParameters.Add("subject",("Message from DECV").ToString())
'DEL    		if not IsDBNull(DataItem.STUDENT_EMAILHref) then
'DEL    			STUDENTSTUDENT_EMAIL.HRef = "mailto:" + DataItem.STUDENT_EMAILHref & DataItem.STUDENT_EMAILHrefParameters.ToString("None","", ViewState)
'DEL  	  	end if
'DEL      ' -------------------------

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-59CEDC7A
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Carer_maintainextContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_CARER_CONTACTData = New STUDENT_CARER_CONTACTDataProvider()
        STUDENT_CARER_CONTACTOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT1Data = New STUDENT_CARER_CONTACT1DataProvider()
        STUDENT_CARER_CONTACT1Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT2Data = New STUDENT_CARER_CONTACT2DataProvider()
        STUDENT_CARER_CONTACT2Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT3Data = New STUDENT_CARER_CONTACT3DataProvider()
        STUDENT_CARER_CONTACT3Operations = New FormSupportedOperations(False, True, True, True, True)
        STUDENT_CARER_CONTACT4Data = New STUDENT_CARER_CONTACT4DataProvider()
        STUDENT_CARER_CONTACT4Operations = New FormSupportedOperations(False, True, True, True, False)
        ListSchoolSupervisorsData = New ListSchoolSupervisorsDataProvider()
        ListSchoolSupervisorsOperations = New FormSupportedOperations(False, True, False, True, False)
        STUDENT_CARER_CONTACT5Data = New STUDENT_CARER_CONTACT5DataProvider()
        STUDENT_CARER_CONTACT5Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACTSearchData = New STUDENT_CARER_CONTACTSearchDataProvider()
        STUDENT_CARER_CONTACTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STUDENT_CARER_CONTACT6Data = New STUDENT_CARER_CONTACT6DataProvider()
        STUDENT_CARER_CONTACT6Operations = New FormSupportedOperations(False, True, False, True, True)
        STUDENT_CARER_CONTACT7Data = New STUDENT_CARER_CONTACT7DataProvider()
        STUDENT_CARER_CONTACT7Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT8Data = New STUDENT_CARER_CONTACT8DataProvider()
        STUDENT_CARER_CONTACT8Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACT_EMERGENCY_EDITData = New STUDENT_CARER_CONTACT_EMERGENCY_EDITDataProvider()
        STUDENT_CARER_CONTACT_EMERGENCY_EDITOperations = New FormSupportedOperations(False, True, True, True, True)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

