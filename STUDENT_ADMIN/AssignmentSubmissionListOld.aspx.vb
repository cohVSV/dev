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

Namespace DECV_PROD2007.AssignmentSubmissionListOld 'Namespace @1-11EE52F8

'Forms Definition @1-1BA987B8
Public Class [AssignmentSubmissionListOldPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EF31C83B
    Protected ASSIGNMENT_SUBMISSION_SUBData As ASSIGNMENT_SUBMISSION_SUBDataProvider
    Protected ASSIGNMENT_SUBMISSION_SUBOperations As FormSupportedOperations
    Protected ASSIGNMENT_SUBMISSION_SUBCurrentRowNumber As Integer
    Protected ASSIGNMENT_SUBMISSIONData As ASSIGNMENT_SUBMISSIONDataProvider
    Protected ASSIGNMENT_SUBMISSIONErrors As NameValueCollection = New NameValueCollection()
    Protected ASSIGNMENT_SUBMISSIONOperations As FormSupportedOperations
    Protected ASSIGNMENT_SUBMISSIONIsSubmitted As Boolean = False
    Protected ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEName As String
    Protected ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEDateControl As String
    Protected RECEIVE_ASSIGNMENTData As RECEIVE_ASSIGNMENTDataProvider
    Protected RECEIVE_ASSIGNMENTErrors As NameValueCollection = New NameValueCollection()
    Protected RECEIVE_ASSIGNMENTOperations As FormSupportedOperations
    Protected RECEIVE_ASSIGNMENTIsSubmitted As Boolean = False
    Protected AssignmentSubmissionListOldContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A277D2F6
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            item.link_MenuHref = "Menu.aspx"
            item.Link_SearchRequestHref = "MaintainSearchRequest.aspx"
            item.link_AssignmentsHref = "AssignmentSubmissionListOld.aspx"
            item.Link10Href = "Send_SMS_maintain.aspx"
            item.Link6Href = "Student_Future_Intentions.aspx"
            item.Link5Href = "Student_Comments_maintain.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf,"")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref+item.Link_BacktoPastoralListHrefParameters.ToString("None","", ViewState)
            Link_BacktoPastoralList.DataBind()
            link_Menu.InnerText += item.link_Menu.GetFormattedValue().Replace(vbCrLf,"")
            link_Menu.HRef = item.link_MenuHref+item.link_MenuHrefParameters.ToString("None","", ViewState)
            link_Menu.DataBind()
            Link_SearchRequest.InnerText += item.Link_SearchRequest.GetFormattedValue().Replace(vbCrLf,"")
            Link_SearchRequest.HRef = item.Link_SearchRequestHref+item.Link_SearchRequestHrefParameters.ToString("GET","", ViewState)
            Link_SearchRequest.DataBind()
            link_Assignments.InnerText += item.link_Assignments.GetFormattedValue().Replace(vbCrLf,"")
            link_Assignments.HRef = item.link_AssignmentsHref+item.link_AssignmentsHrefParameters.ToString("GET","", ViewState)
            link_Assignments.DataBind()
            Link10.InnerText += item.Link10.GetFormattedValue().Replace(vbCrLf,"")
            Link10.HRef = item.Link10Href+item.Link10HrefParameters.ToString("GET","", ViewState)
            Link10.DataBind()
            Link6.InnerText += item.Link6.GetFormattedValue().Replace(vbCrLf,"")
            Link6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("GET","", ViewState)
            Link6.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf,"")
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("GET","", ViewState)
            Link5.DataBind()
            ASSIGNMENT_SUBMISSION_SUBBind
            ASSIGNMENT_SUBMISSIONShow()
            RECEIVE_ASSIGNMENTShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @48-73254650
    ' -------------------------
    'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")
	 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MenuStudentMaintain.visible = true
     End If
    ' -------------------------
'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL      'ERA: 2011-3-31|EA| if nothing in the RETURNED DATE then put today
'DEL  	ASSIGNMENT_SUBMISSIONlblDefaulted_Returned.Visible = false
'DEL  	if (ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text = "") then
'DEL  		ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text = (New DateField("dd\/MM\/yyyy", (Now()))).GetFormattedValue()
'DEL  		ASSIGNMENT_SUBMISSIONlblDefaulted_Returned.Visible = true
'DEL  	end if 
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      'ERA: 2011-3-31|EA| if nothing selected for Marker then put 'me'
'DEL  	ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = false
'DEL  
'DEL      If (ASSIGNMENT_SUBMISSIONSTAFF_ID.SelectedIndex = 0) Then
'DEL  		ASSIGNMENT_SUBMISSIONSTAFF_ID.Value = DBUtility.UserLogin.ToUpper()
'DEL  		ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = true
'DEL      End If
'DEL      ' -------------------------


    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid ASSIGNMENT_SUBMISSION_SUB Bind @2-D76C2BF6

    Protected Sub ASSIGNMENT_SUBMISSION_SUBBind()
        If Not ASSIGNMENT_SUBMISSION_SUBOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ASSIGNMENT_SUBMISSION_SUB",GetType(ASSIGNMENT_SUBMISSION_SUBDataProvider.SortFields), 80, 100)
        End If
'End Grid ASSIGNMENT_SUBMISSION_SUB Bind

'Grid Form ASSIGNMENT_SUBMISSION_SUB BeforeShow tail @2-CF16A8C0
        ASSIGNMENT_SUBMISSION_SUBParameters()
        ASSIGNMENT_SUBMISSION_SUBData.SortField = CType(ViewState("ASSIGNMENT_SUBMISSION_SUBSortField"),ASSIGNMENT_SUBMISSION_SUBDataProvider.SortFields)
        ASSIGNMENT_SUBMISSION_SUBData.SortDir = CType(ViewState("ASSIGNMENT_SUBMISSION_SUBSortDir"),SortDirections)
        ASSIGNMENT_SUBMISSION_SUBData.PageNumber = CInt(ViewState("ASSIGNMENT_SUBMISSION_SUBPageNumber"))
        ASSIGNMENT_SUBMISSION_SUBData.RecordsPerPage = CInt(ViewState("ASSIGNMENT_SUBMISSION_SUBPageSize"))
        ASSIGNMENT_SUBMISSION_SUBRepeater.DataSource = ASSIGNMENT_SUBMISSION_SUBData.GetResultSet(PagesCount, ASSIGNMENT_SUBMISSION_SUBOperations)
        ViewState("ASSIGNMENT_SUBMISSION_SUBPagesCount") = PagesCount
        Dim item As ASSIGNMENT_SUBMISSION_SUBItem = New ASSIGNMENT_SUBMISSION_SUBItem()
        ASSIGNMENT_SUBMISSION_SUBRepeater.DataBind
        FooterIndex = ASSIGNMENT_SUBMISSION_SUBRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim ASSIGNMENT_SUBMISSION_SUBlblStudent As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_SUBlblStudent"),System.Web.UI.WebControls.Literal)
        Dim ASSIGNMENT_SUBMISSION_SUBlblYear As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_SUBlblYear"),System.Web.UI.WebControls.Literal)
        Dim ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUB_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUB_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ASSIGNMENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_ASSIGNMENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBMISSION_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_SUBMISSION_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_received_dateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_received_dateSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_returned_dateSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_returned_dateSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENTSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_COMMENTSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Sorter_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("Sorter_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim ASSIGNMENT_SUBMISSION_SUBlinkAddAssignment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(ASSIGNMENT_SUBMISSION_SUBRepeater.Controls(0).FindControl("ASSIGNMENT_SUBMISSION_SUBlinkAddAssignment"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.lblStudent.SetValue(request.querystring("STUDENT_ID"))
        item.lblYear.SetValue(request.querystring("ENROLMENT_YEAR"))
        item.linkAddAssignmentHref = ""
        item.linkAddAssignmentHrefParameters.Add("ADD_ASSIGNMENT",System.Web.HttpUtility.UrlEncode((true).ToString()))
        ASSIGNMENT_SUBMISSION_SUBlblStudent.Text = Server.HtmlEncode(item.lblStudent.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSION_SUBlblYear.Text = Server.HtmlEncode(item.lblYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUB_TotalRecords.Text = Server.HtmlEncode(item.ASSIGNMENT_SUBMISSION_SUB_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSION_SUBlinkAddAssignment.InnerText += item.linkAddAssignment.GetFormattedValue().Replace(vbCrLf,"")
        ASSIGNMENT_SUBMISSION_SUBlinkAddAssignment.HRef = item.linkAddAssignmentHref+item.linkAddAssignmentHrefParameters.ToString("GET","ASSIGNMENT_ID", ViewState)
'End Grid Form ASSIGNMENT_SUBMISSION_SUB BeforeShow tail

'Label ASSIGNMENT_SUBMISSION_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records @18-286D09E0
            ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUB_TotalRecords.Text = ASSIGNMENT_SUBMISSION_SUBData.RecordCount.ToString()
'End Label ASSIGNMENT_SUBMISSION_SUB_TotalRecords Event BeforeShow. Action Retrieve number of records

'Navigator Navigator Event BeforeShow. Action Hide-Show Component @38-1F2D9A89
        If PagesCount < 2 Then
            NavigatorNavigator.Visible = False
        End If
'End Navigator Navigator Event BeforeShow. Action Hide-Show Component

'Grid ASSIGNMENT_SUBMISSION_SUB Bind tail @2-E31F8E2A
    End Sub
'End Grid ASSIGNMENT_SUBMISSION_SUB Bind tail

'Grid ASSIGNMENT_SUBMISSION_SUB Table Parameters @2-D4FBA0D5

    Protected Sub ASSIGNMENT_SUBMISSION_SUBParameters()
        Try
            ASSIGNMENT_SUBMISSION_SUBData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSION_SUBData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ASSIGNMENT_SUBMISSION_SUBRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ASSIGNMENT_SUBMISSION_SUBRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ASSIGNMENT_SUBMISSION_SUB: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid ASSIGNMENT_SUBMISSION_SUB Table Parameters

'Grid ASSIGNMENT_SUBMISSION_SUB ItemDataBound event @2-16279B4D

    Protected Sub ASSIGNMENT_SUBMISSION_SUBItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ASSIGNMENT_SUBMISSION_SUBItem = CType(e.Item.DataItem,ASSIGNMENT_SUBMISSION_SUBItem)
        Dim Item as ASSIGNMENT_SUBMISSION_SUBItem = DataItem
        Dim FormDataSource As ASSIGNMENT_SUBMISSION_SUBItem() = CType(ASSIGNMENT_SUBMISSION_SUBRepeater.DataSource, ASSIGNMENT_SUBMISSION_SUBItem())
        Dim ASSIGNMENT_SUBMISSION_SUBDataRows As Integer = FormDataSource.Length
        Dim ASSIGNMENT_SUBMISSION_SUBIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ASSIGNMENT_SUBMISSION_SUBCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENT_SUBMISSION_SUBRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ASSIGNMENT_SUBMISSION_SUBCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_SUBMISSION_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBASSIGNMENT_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBSUBMISSION_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBSUBMISSION_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBreceived_date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBreceived_date"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBreturned_date As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBreturned_date"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBCOMMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBCOMMENTS"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENT_SUBMISSION_SUBLink_ReturnAssignment As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBLink_ReturnAssignment"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim ASSIGNMENT_SUBMISSION_SUBDESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENT_SUBMISSION_SUBDESCRIPTION"),System.Web.UI.WebControls.Literal)
            DataItem.Link_ReturnAssignmentHref = "AssignmentSubmissionListOld.aspx"
            ASSIGNMENT_SUBMISSION_SUBLink_ReturnAssignment.HRef = DataItem.Link_ReturnAssignmentHref & DataItem.Link_ReturnAssignmentHrefParameters.ToString("None","", ViewState)
        End If
'End Grid ASSIGNMENT_SUBMISSION_SUB ItemDataBound event

'Grid ASSIGNMENT_SUBMISSION_SUB BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid ASSIGNMENT_SUBMISSION_SUB BeforeShowRow event

'Grid ASSIGNMENT_SUBMISSION_SUB Event BeforeShowRow. Action Set Row Style @27-735C87A0
            Dim styles27 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex27 As Integer = (ASSIGNMENT_SUBMISSION_SUBCurrentRowNumber - 1) Mod styles27.Length
            Dim rawStyle27 As String = styles27(styleIndex27).Replace("\;",";")
            If rawStyle27.IndexOf("=") = -1 And rawStyle27.IndexOf(":") > -1 Then
                rawStyle27 = "style=""" + rawStyle27 + """"
            ElseIf rawStyle27.IndexOf("=") = -1 And rawStyle27.IndexOf(":") = -1 And rawStyle27 <> "" Then
                rawStyle27 = "class=""" + rawStyle27 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENT_SUBMISSION_SUBRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle27), AttributeOption.Multiple)
'End Grid ASSIGNMENT_SUBMISSION_SUB Event BeforeShowRow. Action Set Row Style

'Grid ASSIGNMENT_SUBMISSION_SUB BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid ASSIGNMENT_SUBMISSION_SUB BeforeShowRow event tail

'Grid ASSIGNMENT_SUBMISSION_SUB ItemDataBound event tail @2-AF4CFBCF
        If ASSIGNMENT_SUBMISSION_SUBIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(ASSIGNMENT_SUBMISSION_SUBCurrentRowNumber, ListItemType.Item)
            ASSIGNMENT_SUBMISSION_SUBRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            ASSIGNMENT_SUBMISSION_SUBItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ASSIGNMENT_SUBMISSION_SUB ItemDataBound event tail

'Grid ASSIGNMENT_SUBMISSION_SUB ItemCommand event @2-0EB8D6CA

    Protected Sub ASSIGNMENT_SUBMISSION_SUBItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ASSIGNMENT_SUBMISSION_SUBRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ASSIGNMENT_SUBMISSION_SUBSortDir"),SortDirections) = SortDirections._Asc And ViewState("ASSIGNMENT_SUBMISSION_SUBSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ASSIGNMENT_SUBMISSION_SUBSortDir")=SortDirections._Desc
                Else
                    ViewState("ASSIGNMENT_SUBMISSION_SUBSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ASSIGNMENT_SUBMISSION_SUBSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ASSIGNMENT_SUBMISSION_SUBDataProvider.SortFields = 0
            ViewState("ASSIGNMENT_SUBMISSION_SUBSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ASSIGNMENT_SUBMISSION_SUBPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ASSIGNMENT_SUBMISSION_SUBPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ASSIGNMENT_SUBMISSION_SUBPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ASSIGNMENT_SUBMISSION_SUBPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ASSIGNMENT_SUBMISSION_SUBBind
        End If
    End Sub
'End Grid ASSIGNMENT_SUBMISSION_SUB ItemCommand event

'Record Form ASSIGNMENT_SUBMISSION Parameters @66-EB821AE9

    Protected Sub ASSIGNMENT_SUBMISSIONParameters()
        Dim item As new ASSIGNMENT_SUBMISSIONItem
        Try
            ASSIGNMENT_SUBMISSIONData.UrlASSIGNMENT_ID = IntegerParameter.GetParam("ASSIGNMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSIONData.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSIONData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSIONData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            ASSIGNMENT_SUBMISSIONData.UrlSUBMISSION_ID = IntegerParameter.GetParam("SUBMISSION_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            ASSIGNMENT_SUBMISSIONErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION Parameters

'Record Form ASSIGNMENT_SUBMISSION Show method @66-E8624B77
    Protected Sub ASSIGNMENT_SUBMISSIONShow()
        If ASSIGNMENT_SUBMISSIONOperations.None Then
            ASSIGNMENT_SUBMISSIONHolder.Visible = False
            Return
        End If
        Dim item As ASSIGNMENT_SUBMISSIONItem = ASSIGNMENT_SUBMISSIONItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ASSIGNMENT_SUBMISSIONOperations.AllowRead
        ASSIGNMENT_SUBMISSIONErrors.Add(item.errors)
        If ASSIGNMENT_SUBMISSIONErrors.Count > 0 Then
            ASSIGNMENT_SUBMISSIONShowErrors()
            Return
        End If
'End Record Form ASSIGNMENT_SUBMISSION Show method

'Record Form ASSIGNMENT_SUBMISSION BeforeShow tail @66-D3C45DA2
        ASSIGNMENT_SUBMISSIONParameters()
        ASSIGNMENT_SUBMISSIONData.FillItem(item, IsInsertMode)
        ASSIGNMENT_SUBMISSIONHolder.DataBind()
        ASSIGNMENT_SUBMISSIONButton_Update.Visible=Not (IsInsertMode) AndAlso ASSIGNMENT_SUBMISSIONOperations.AllowUpdate
        ASSIGNMENT_SUBMISSIONRECEIVED_DATE.Value = item.RECEIVED_DATE.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text=item.RETURNED_DATE.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEName = "ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE"
        ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATEDateControl = ASSIGNMENT_SUBMISSIONRETURNED_DATE.ClientID
        ASSIGNMENT_SUBMISSIONDatePicker_RETURNED_DATE.DataBind()
        ASSIGNMENT_SUBMISSIONSTAFF_ID.Items.Add(new ListItem("Select Value",""))
        ASSIGNMENT_SUBMISSIONSTAFF_ID.Items(0).Selected = True
        item.STAFF_IDItems.SetSelection(item.STAFF_ID.GetFormattedValue())
        If Not item.STAFF_IDItems.GetSelectedItem() Is Nothing Then
            ASSIGNMENT_SUBMISSIONSTAFF_ID.SelectedIndex = -1
        End If
        item.STAFF_IDItems.CopyTo(ASSIGNMENT_SUBMISSIONSTAFF_ID.Items)
        ASSIGNMENT_SUBMISSIONCOMMENTS.Text=item.COMMENTS.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONSUBJECT_ID.Value = item.SUBJECT_ID.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONASSIGNMENT_ID.Value = item.ASSIGNMENT_ID.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONlblAssignment.Text = Server.HtmlEncode(item.lblAssignment.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSIONlblSubmission.Text = Server.HtmlEncode(item.lblSubmission.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Text = item.lblDefaulted_Marker.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONlblDefaulted_Returned.Text = item.lblDefaulted_Returned.GetFormattedValue()
        ASSIGNMENT_SUBMISSIONlblRECEIVED_DATE.Text = Server.HtmlEncode(item.lblRECEIVED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form ASSIGNMENT_SUBMISSION BeforeShow tail

'TextBox RETURNED_DATE Event BeforeShow. Action Custom Code @100-73254650
    ' -------------------------
    'ERA: 2011-3-31|EA| if nothing in the RETURNED DATE then put today
	ASSIGNMENT_SUBMISSIONlblDefaulted_Returned.Visible = false
	if (ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text = "") then
		ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text = (New DateField("dd\/MM\/yyyy", (Now()))).GetFormattedValue()
		ASSIGNMENT_SUBMISSIONlblDefaulted_Returned.Visible = true
	end if 
    ' -------------------------
'End TextBox RETURNED_DATE Event BeforeShow. Action Custom Code

'ListBox STAFF_ID Event BeforeShow. Action Custom Code @101-73254650
    ' -------------------------
    'ERA: 2011-3-31|EA| if nothing selected for Marker then put 'me'
	ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = false

    If (ASSIGNMENT_SUBMISSIONSTAFF_ID.SelectedIndex = 0) Then
		ASSIGNMENT_SUBMISSIONSTAFF_ID.Value = DBUtility.UserLogin.ToUpper()
		ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = true
    End If
    ' -------------------------
'End ListBox STAFF_ID Event BeforeShow. Action Custom Code

'Record ASSIGNMENT_SUBMISSION Event BeforeShow. Action Hide-Show Component @93-B4044063
        Dim UrlASSIGNMENT_ID_93_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("ASSIGNMENT_ID"))
        Dim ExprParam2_93_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlASSIGNMENT_ID_93_1, ExprParam2_93_2) Then
            ASSIGNMENT_SUBMISSIONHolder.Visible = False
        End If
'End Record ASSIGNMENT_SUBMISSION Event BeforeShow. Action Hide-Show Component

'Record Form ASSIGNMENT_SUBMISSION Show method tail @66-934B29F4
        If ASSIGNMENT_SUBMISSIONErrors.Count > 0 Then
            ASSIGNMENT_SUBMISSIONShowErrors()
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION Show method tail

'Record Form ASSIGNMENT_SUBMISSION LoadItemFromRequest method @66-1F5050EA

    Protected Sub ASSIGNMENT_SUBMISSIONLoadItemFromRequest(item As ASSIGNMENT_SUBMISSIONItem, ByVal EnableValidation As Boolean)
        Try
        item.RECEIVED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONRECEIVED_DATE.UniqueID))
        item.RECEIVED_DATE.SetValue(ASSIGNMENT_SUBMISSIONRECEIVED_DATE.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("RECEIVED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"RECEIVED DATE","dd/mm/yyyy"))
        End Try
        Try
        item.RETURNED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONRETURNED_DATE.UniqueID))
        If ControlCustomValues("ASSIGNMENT_SUBMISSIONRETURNED_DATE") Is Nothing Then
            item.RETURNED_DATE.SetValue(ASSIGNMENT_SUBMISSIONRETURNED_DATE.Text)
        Else
            item.RETURNED_DATE.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSIONRETURNED_DATE"))
        End If
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("RETURNED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"RETURNED DATE","dd/mm/yyyy"))
        End Try
        item.STAFF_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONSTAFF_ID.UniqueID))
        item.STAFF_ID.SetValue(ASSIGNMENT_SUBMISSIONSTAFF_ID.Value)
        item.STAFF_IDItems.CopyFrom(ASSIGNMENT_SUBMISSIONSTAFF_ID.Items)
        item.COMMENTS.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONCOMMENTS.UniqueID))
        If ControlCustomValues("ASSIGNMENT_SUBMISSIONCOMMENTS") Is Nothing Then
            item.COMMENTS.SetValue(ASSIGNMENT_SUBMISSIONCOMMENTS.Text)
        Else
            item.COMMENTS.SetValue(ControlCustomValues("ASSIGNMENT_SUBMISSIONCOMMENTS"))
        End If
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(ASSIGNMENT_SUBMISSIONSTUDENT_ID.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(ASSIGNMENT_SUBMISSIONENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        Try
        item.SUBJECT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONSUBJECT_ID.UniqueID))
        item.SUBJECT_ID.SetValue(ASSIGNMENT_SUBMISSIONSUBJECT_ID.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"SUBJECT ID"))
        End Try
        Try
        item.ASSIGNMENT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONASSIGNMENT_ID.UniqueID))
        item.ASSIGNMENT_ID.SetValue(ASSIGNMENT_SUBMISSIONASSIGNMENT_ID.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("ASSIGNMENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"ASSIGNMENT ID"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            ASSIGNMENT_SUBMISSIONErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(ASSIGNMENT_SUBMISSIONData)
        End If
        ASSIGNMENT_SUBMISSIONErrors.Add(item.errors)
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION LoadItemFromRequest method

'Record Form ASSIGNMENT_SUBMISSION GetRedirectUrl method @66-CF53A4DC

    Protected Function GetASSIGNMENT_SUBMISSIONRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "AssignmentSubmissionListOld.aspx"
        Dim p As String = parameters.ToString("GET","ASSIGNMENT_ID; SUBMISSION_ID; SUBJECT_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ASSIGNMENT_SUBMISSION GetRedirectUrl method

'Record Form ASSIGNMENT_SUBMISSION ShowErrors method @66-CD0E0AEB

    Protected Sub ASSIGNMENT_SUBMISSIONShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ASSIGNMENT_SUBMISSIONErrors.Count - 1
        Select Case ASSIGNMENT_SUBMISSIONErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ASSIGNMENT_SUBMISSIONErrors(i)
        End Select
        Next i
        ASSIGNMENT_SUBMISSIONError.Visible = True
        ASSIGNMENT_SUBMISSIONErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION ShowErrors method

'Record Form ASSIGNMENT_SUBMISSION Insert Operation @66-6FB95F56

    Protected Sub ASSIGNMENT_SUBMISSION_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        ASSIGNMENT_SUBMISSIONIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENT_SUBMISSION Insert Operation

'Record Form ASSIGNMENT_SUBMISSION BeforeInsert tail @66-81884C0A
    ASSIGNMENT_SUBMISSIONParameters()
    ASSIGNMENT_SUBMISSIONLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENT_SUBMISSION BeforeInsert tail

'Record Form ASSIGNMENT_SUBMISSION AfterInsert tail  @66-E676388F
        ErrorFlag=(ASSIGNMENT_SUBMISSIONErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION AfterInsert tail 

'Record Form ASSIGNMENT_SUBMISSION Update Operation @66-C09BF052

    Protected Sub ASSIGNMENT_SUBMISSION_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        ASSIGNMENT_SUBMISSIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENT_SUBMISSION Update Operation

'Button Button_Update OnClick. @67-C0BE408B
        If CType(sender,Control).ID = "ASSIGNMENT_SUBMISSIONButton_Update" Then
            RedirectUrl = GetASSIGNMENT_SUBMISSIONRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @67-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record ASSIGNMENT_SUBMISSION Event BeforeUpdate. Action Retrieve Value for Control @83-8295F550
        ASSIGNMENT_SUBMISSIONLAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record ASSIGNMENT_SUBMISSION Event BeforeUpdate. Action Retrieve Value for Control

'Record ASSIGNMENT_SUBMISSION Event BeforeUpdate. Action Retrieve Value for Control @84-1BBE5307
        ASSIGNMENT_SUBMISSIONLAST_ALTERED_DATE.Value = (New DateField(Settings.DateFormat, (Now()))).GetFormattedValue()
'End Record ASSIGNMENT_SUBMISSION Event BeforeUpdate. Action Retrieve Value for Control

'Record Form ASSIGNMENT_SUBMISSION Before Update tail @66-8A9DEC67
        ASSIGNMENT_SUBMISSIONParameters()
        ASSIGNMENT_SUBMISSIONLoadItemFromRequest(item, EnableValidation)
        If ASSIGNMENT_SUBMISSIONOperations.AllowUpdate Then
        ErrorFlag = (ASSIGNMENT_SUBMISSIONErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                ASSIGNMENT_SUBMISSIONData.UpdateItem(item)
            Catch ex As Exception
                ASSIGNMENT_SUBMISSIONErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form ASSIGNMENT_SUBMISSION Before Update tail

'Record Form ASSIGNMENT_SUBMISSION Update Operation tail @66-7AB7142D
        End If
        ErrorFlag=(ASSIGNMENT_SUBMISSIONErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION Update Operation tail

'Record Form ASSIGNMENT_SUBMISSION Delete Operation @66-6BFBEA30
    Protected Sub ASSIGNMENT_SUBMISSION_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ASSIGNMENT_SUBMISSIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ASSIGNMENT_SUBMISSION Delete Operation

'Record Form BeforeDelete tail @66-81884C0A
        ASSIGNMENT_SUBMISSIONParameters()
        ASSIGNMENT_SUBMISSIONLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @66-8B2A0895
        If ErrorFlag Then
            ASSIGNMENT_SUBMISSIONShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ASSIGNMENT_SUBMISSION Cancel Operation @66-36A753ED

    Protected Sub ASSIGNMENT_SUBMISSION_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENT_SUBMISSIONItem = New ASSIGNMENT_SUBMISSIONItem()
        ASSIGNMENT_SUBMISSIONIsSubmitted = True
        Dim RedirectUrl As String = ""
        ASSIGNMENT_SUBMISSIONLoadItemFromRequest(item, False)
'End Record Form ASSIGNMENT_SUBMISSION Cancel Operation

'Button Button_Cancel OnClick. @68-12541705
    If CType(sender,Control).ID = "ASSIGNMENT_SUBMISSIONButton_Cancel" Then
        RedirectUrl = GetASSIGNMENT_SUBMISSIONRedirectUrl("", "ASSIGNMENT_ID")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @68-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form ASSIGNMENT_SUBMISSION Cancel Operation tail @66-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ASSIGNMENT_SUBMISSION Cancel Operation tail

'Record Form RECEIVE_ASSIGNMENT Parameters @192-2A5AD0AE

    Protected Sub RECEIVE_ASSIGNMENTParameters()
        Dim item As new RECEIVE_ASSIGNMENTItem
        Try
            RECEIVE_ASSIGNMENTData.UrlASSIGNMENT_ID = IntegerParameter.GetParam("ASSIGNMENT_ID", ParameterSourceType.URL, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.UrlSUBJECT_ID = IntegerParameter.GetParam("SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.UrlSUBMISSION_ID = IntegerParameter.GetParam("SUBMISSION_ID", ParameterSourceType.URL, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.CtrlSTUDENT_ID = FloatParameter.GetParam(item.STUDENT_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.CtrlENROLMENT_YEAR = FloatParameter.GetParam(item.ENROLMENT_YEAR.Value, ParameterSourceType.Control, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.CtrllistSUBJECTS = IntegerParameter.GetParam(item.listSUBJECTS.Value, ParameterSourceType.Control, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.CtrllistASSIGNMENTS = IntegerParameter.GetParam(item.listASSIGNMENTS.Value, ParameterSourceType.Control, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.CtrlLAST_ALTERED_BY = TextParameter.GetParam(item.LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
            RECEIVE_ASSIGNMENTData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", "", false)
        Catch e As Exception
            RECEIVE_ASSIGNMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form RECEIVE_ASSIGNMENT Parameters

'Record Form RECEIVE_ASSIGNMENT Show method @192-2695B611
    Protected Sub RECEIVE_ASSIGNMENTShow()
        If RECEIVE_ASSIGNMENTOperations.None Then
            RECEIVE_ASSIGNMENTHolder.Visible = False
            Return
        End If
        Dim item As RECEIVE_ASSIGNMENTItem = RECEIVE_ASSIGNMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not RECEIVE_ASSIGNMENTOperations.AllowRead
        RECEIVE_ASSIGNMENTErrors.Add(item.errors)
        If RECEIVE_ASSIGNMENTErrors.Count > 0 Then
            RECEIVE_ASSIGNMENTShowErrors()
            Return
        End If
'End Record Form RECEIVE_ASSIGNMENT Show method

'Record Form RECEIVE_ASSIGNMENT BeforeShow tail @192-04F9440B
        RECEIVE_ASSIGNMENTParameters()
        RECEIVE_ASSIGNMENTData.FillItem(item, IsInsertMode)
        RECEIVE_ASSIGNMENTHolder.DataBind()
        RECEIVE_ASSIGNMENTButton_Insert.Visible=IsInsertMode AndAlso RECEIVE_ASSIGNMENTOperations.AllowInsert
        RECEIVE_ASSIGNMENTSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        RECEIVE_ASSIGNMENTENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        RECEIVE_ASSIGNMENTLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        RECEIVE_ASSIGNMENTLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        RECEIVE_ASSIGNMENTlistSUBJECTS.Items.Add(new ListItem("Select First",""))
        RECEIVE_ASSIGNMENTlistSUBJECTS.Items(0).Selected = True
        item.listSUBJECTSItems.SetSelection(item.listSUBJECTS.GetFormattedValue())
        If Not item.listSUBJECTSItems.GetSelectedItem() Is Nothing Then
            RECEIVE_ASSIGNMENTlistSUBJECTS.SelectedIndex = -1
        End If
        item.listSUBJECTSItems.CopyTo(RECEIVE_ASSIGNMENTlistSUBJECTS.Items)
        RECEIVE_ASSIGNMENTlistASSIGNMENTS.Items.Add(new ListItem("then select Assignment",""))
        RECEIVE_ASSIGNMENTlistASSIGNMENTS.Items(0).Selected = True
        item.listASSIGNMENTSItems.SetSelection(item.listASSIGNMENTS.GetFormattedValue())
        If Not item.listASSIGNMENTSItems.GetSelectedItem() Is Nothing Then
            RECEIVE_ASSIGNMENTlistASSIGNMENTS.SelectedIndex = -1
        End If
        item.listASSIGNMENTSItems.CopyTo(RECEIVE_ASSIGNMENTlistASSIGNMENTS.Items)
        RECEIVE_ASSIGNMENTajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
'End Record Form RECEIVE_ASSIGNMENT BeforeShow tail

'DEL      ' -------------------------
'DEL      'ERA: 2011-3-31|EA| if nothing in the RETURNED DATE then put today
'DEL  	RECEIVE_ASSIGNMENTlblDefaulted_Returned.Visible = false
'DEL  	if (RECEIVE_ASSIGNMENTRECEIVED_DATE.Text = "") then
'DEL  		RECEIVE_ASSIGNMENTRECEIVED_DATE.Text = (New DateField("dd\/MM\/yyyy", (Now()))).GetFormattedValue()
'DEL  		RECEIVE_ASSIGNMENTlblDefaulted_Returned.Visible = true
'DEL  	end if 
'DEL      ' -------------------------

'Hidden STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @268-F2127661
            RECEIVE_ASSIGNMENTSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Hidden STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Hidden ENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control @269-A702A3D7
            RECEIVE_ASSIGNMENTENROLMENT_YEAR.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Hidden ENROLMENT_YEAR Event BeforeShow. Action Retrieve Value for Control

'DEL      ' -------------------------
'DEL      'ERA: 2011-3-31|EA| if nothing selected for Marker then put 'me'
'DEL  	ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = false
'DEL  
'DEL      If (ASSIGNMENT_SUBMISSIONSTAFF_ID.SelectedIndex = 0) Then
'DEL  		ASSIGNMENT_SUBMISSIONSTAFF_ID.Value = DBUtility.UserLogin.ToUpper()
'DEL  		ASSIGNMENT_SUBMISSIONlblDefaulted_Marker.Visible = true
'DEL      End If
'DEL      ' -------------------------


'Record RECEIVE_ASSIGNMENT Event BeforeShow. Action Hide-Show Component @219-49E5CA02
        Dim UrlADD_ASSIGNMENT_219_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("ADD_ASSIGNMENT"))
        Dim ExprParam2_219_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlADD_ASSIGNMENT_219_1, ExprParam2_219_2) Then
            RECEIVE_ASSIGNMENTHolder.Visible = False
        End If
'End Record RECEIVE_ASSIGNMENT Event BeforeShow. Action Hide-Show Component

'Record Form RECEIVE_ASSIGNMENT Show method tail @192-35D4FACF
        If RECEIVE_ASSIGNMENTErrors.Count > 0 Then
            RECEIVE_ASSIGNMENTShowErrors()
        End If
    End Sub
'End Record Form RECEIVE_ASSIGNMENT Show method tail

'Record Form RECEIVE_ASSIGNMENT LoadItemFromRequest method @192-D28744B8

    Protected Sub RECEIVE_ASSIGNMENTLoadItemFromRequest(item As RECEIVE_ASSIGNMENTItem, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(RECEIVE_ASSIGNMENTSTUDENT_ID.Value)
        Catch ae As ArgumentException
            RECEIVE_ASSIGNMENTErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(RECEIVE_ASSIGNMENTENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            RECEIVE_ASSIGNMENTErrors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(RECEIVE_ASSIGNMENTLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(RECEIVE_ASSIGNMENTLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            RECEIVE_ASSIGNMENTErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        item.listSUBJECTS.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTlistSUBJECTS.UniqueID))
        item.listSUBJECTS.SetValue(RECEIVE_ASSIGNMENTlistSUBJECTS.Value)
        item.listSUBJECTSItems.CopyFrom(RECEIVE_ASSIGNMENTlistSUBJECTS.Items)
        item.listASSIGNMENTS.IsEmpty = IsNothing(Request.Form(RECEIVE_ASSIGNMENTlistASSIGNMENTS.UniqueID))
        item.listASSIGNMENTS.SetValue(RECEIVE_ASSIGNMENTlistASSIGNMENTS.Value)
        item.listASSIGNMENTSItems.CopyFrom(RECEIVE_ASSIGNMENTlistASSIGNMENTS.Items)
        If EnableValidation Then
            item.Validate(RECEIVE_ASSIGNMENTData)
        End If
        RECEIVE_ASSIGNMENTErrors.Add(item.errors)
    End Sub
'End Record Form RECEIVE_ASSIGNMENT LoadItemFromRequest method

'Record Form RECEIVE_ASSIGNMENT GetRedirectUrl method @192-939C0C10

    Protected Function GetRECEIVE_ASSIGNMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "AssignmentSubmissionListOld.aspx"
        Dim p As String = parameters.ToString("GET","ASSIGNMENT_ID; SUBMISSION_ID; SUBJECT_ID;ADD_ASSIGNMENT;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form RECEIVE_ASSIGNMENT GetRedirectUrl method

'Record Form RECEIVE_ASSIGNMENT ShowErrors method @192-889BE719

    Protected Sub RECEIVE_ASSIGNMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To RECEIVE_ASSIGNMENTErrors.Count - 1
        Select Case RECEIVE_ASSIGNMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & RECEIVE_ASSIGNMENTErrors(i)
        End Select
        Next i
        RECEIVE_ASSIGNMENTError.Visible = True
        RECEIVE_ASSIGNMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form RECEIVE_ASSIGNMENT ShowErrors method

'Record Form RECEIVE_ASSIGNMENT Insert Operation @192-96EBB241

    Protected Sub RECEIVE_ASSIGNMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As RECEIVE_ASSIGNMENTItem = New RECEIVE_ASSIGNMENTItem()
        Dim ExecuteFlag As Boolean = True
        RECEIVE_ASSIGNMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form RECEIVE_ASSIGNMENT Insert Operation

'Button Button_Insert OnClick. @193-922F231C
        If CType(sender,Control).ID = "RECEIVE_ASSIGNMENTButton_Insert" Then
            RedirectUrl = GetRECEIVE_ASSIGNMENTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @193-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record RECEIVE_ASSIGNMENT Event BeforeInsert. Action Retrieve Value for Control @217-221F29CD
        RECEIVE_ASSIGNMENTLAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record RECEIVE_ASSIGNMENT Event BeforeInsert. Action Retrieve Value for Control

'Record RECEIVE_ASSIGNMENT Event BeforeInsert. Action Retrieve Value for Control @218-473BDBB8
        RECEIVE_ASSIGNMENTLAST_ALTERED_DATE.Value = (New DateField(Settings.DateFormat, (Now()))).GetFormattedValue()
'End Record RECEIVE_ASSIGNMENT Event BeforeInsert. Action Retrieve Value for Control

'Record Form RECEIVE_ASSIGNMENT BeforeInsert tail @192-EBDC2A54
    RECEIVE_ASSIGNMENTParameters()
    RECEIVE_ASSIGNMENTLoadItemFromRequest(item, EnableValidation)
    If RECEIVE_ASSIGNMENTOperations.AllowInsert Then
        ErrorFlag=(RECEIVE_ASSIGNMENTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                RECEIVE_ASSIGNMENTData.InsertItem(item)
            Catch ex As Exception
                RECEIVE_ASSIGNMENTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form RECEIVE_ASSIGNMENT BeforeInsert tail

'Record Form RECEIVE_ASSIGNMENT AfterInsert tail  @192-09CE73D5
        End If
        ErrorFlag=(RECEIVE_ASSIGNMENTErrors.Count > 0)
        If ErrorFlag Then
            RECEIVE_ASSIGNMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form RECEIVE_ASSIGNMENT AfterInsert tail 

'Record Form RECEIVE_ASSIGNMENT Update Operation @192-B9BEC6D8

    Protected Sub RECEIVE_ASSIGNMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As RECEIVE_ASSIGNMENTItem = New RECEIVE_ASSIGNMENTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        RECEIVE_ASSIGNMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form RECEIVE_ASSIGNMENT Update Operation

'Record Form RECEIVE_ASSIGNMENT Before Update tail @192-934A66D4
        RECEIVE_ASSIGNMENTParameters()
        RECEIVE_ASSIGNMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form RECEIVE_ASSIGNMENT Before Update tail

'Record Form RECEIVE_ASSIGNMENT Update Operation tail @192-BBFBE5B4
        ErrorFlag=(RECEIVE_ASSIGNMENTErrors.Count > 0)
        If ErrorFlag Then
            RECEIVE_ASSIGNMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form RECEIVE_ASSIGNMENT Update Operation tail

'Record Form RECEIVE_ASSIGNMENT Delete Operation @192-2A06C1CB
    Protected Sub RECEIVE_ASSIGNMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        RECEIVE_ASSIGNMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As RECEIVE_ASSIGNMENTItem = New RECEIVE_ASSIGNMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form RECEIVE_ASSIGNMENT Delete Operation

'Record Form BeforeDelete tail @192-934A66D4
        RECEIVE_ASSIGNMENTParameters()
        RECEIVE_ASSIGNMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @192-8C4F83F2
        If ErrorFlag Then
            RECEIVE_ASSIGNMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form RECEIVE_ASSIGNMENT Cancel Operation @192-1A1436EA

    Protected Sub RECEIVE_ASSIGNMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As RECEIVE_ASSIGNMENTItem = New RECEIVE_ASSIGNMENTItem()
        RECEIVE_ASSIGNMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        RECEIVE_ASSIGNMENTLoadItemFromRequest(item, False)
'End Record Form RECEIVE_ASSIGNMENT Cancel Operation

'Button Button_Cancel OnClick. @194-BE50887D
    If CType(sender,Control).ID = "RECEIVE_ASSIGNMENTButton_Cancel" Then
        RedirectUrl = GetRECEIVE_ASSIGNMENTRedirectUrl("", "ADD_ASSIGNMENT")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @194-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form RECEIVE_ASSIGNMENT Cancel Operation tail @192-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form RECEIVE_ASSIGNMENT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-47E7F5BE
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        AssignmentSubmissionListOldContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ASSIGNMENT_SUBMISSION_SUBData = New ASSIGNMENT_SUBMISSION_SUBDataProvider()
        ASSIGNMENT_SUBMISSION_SUBOperations = New FormSupportedOperations(False, True, False, False, False)
        ASSIGNMENT_SUBMISSIONData = New ASSIGNMENT_SUBMISSIONDataProvider()
        ASSIGNMENT_SUBMISSIONOperations = New FormSupportedOperations(False, True, False, True, False)
        RECEIVE_ASSIGNMENTData = New RECEIVE_ASSIGNMENTDataProvider()
        RECEIVE_ASSIGNMENTOperations = New FormSupportedOperations(False, False, True, False, False)
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

