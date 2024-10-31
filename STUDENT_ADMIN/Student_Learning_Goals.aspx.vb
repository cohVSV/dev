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

Namespace DECV_PROD2007.Student_Learning_Goals 'Namespace @1-1CFB2AE7

'Forms Definition @1-9C1DA3D4
Public Class [Student_Learning_GoalsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-EDCFF74E
    Protected STUDENT_LEARNING_GOALS1Data As STUDENT_LEARNING_GOALS1DataProvider
    Protected STUDENT_LEARNING_GOALS1Operations As FormSupportedOperations
    Protected STUDENT_LEARNING_GOALS1CurrentRowNumber As Integer
    Protected STUDENT_LEARNING_GOALS2Data As STUDENT_LEARNING_GOALS2DataProvider
    Protected STUDENT_LEARNING_GOALS2Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_LEARNING_GOALS2Operations As FormSupportedOperations
    Protected STUDENT_LEARNING_GOALS2IsSubmitted As Boolean = False
    Protected Student_Learning_GoalsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-1F7AD7F6
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            STUDENT_LEARNING_GOALS1Bind
            STUDENT_LEARNING_GOALS2Show()
    End If
'End Page_Load Event BeforeIsPostBack

'Page Student_Learning_Goals Event BeforeShow. Action Custom Code @321-73254650
    ' -------------------------
     'Oct-2019|EA|ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    'convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
	dim arrHigherGroups as String() = strHigherGroups.split(",")
	If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
	    Panel_MenuStudentMaintain.visible = true
	End If
    ' -------------------------
'End Page Student_Learning_Goals Event BeforeShow. Action Custom Code

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

'DEL      ' -------------------------
'DEL      '16/7/2015|EA| change layout of Referred by
'DEL      STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatColumns = 3
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatDirection = RepeatDirection.Vertical
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.RepeatLayout = RepeatLayout.Table
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_ReferredBy.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL    	'6-Apr-2011|EA| change layout of Completed school level radio, into 2 columns, repeat horiz, left align.
'DEL    	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatColumns = 3
'DEL    	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatDirection = RepeatDirection.Vertical
'DEL    	STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.RepeatLayout = RepeatLayout.Table
'DEL    	'STUDENT_CENSUS_DATAHIGHEST_SCHOOL_LEVEL.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      '16/7/2015|EA| change layout of Disability checkboxes, into 2 columns, repeat horiz, left align.
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatColumns = 3
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatDirection = RepeatDirection.Vertical
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.RepeatLayout = RepeatLayout.Table
'DEL  	'STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  	'16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL       '16/7/2015|EA| change layout
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Previous_Enrol.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_CENSUS_DATARadioButton_Reason_for_Study.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      '16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatDirection = RepeatDirection.Vertical
'DEL  	STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.RepeatLayout = RepeatLayout.Table
'DEL  	'STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  	'16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatColumns = 3
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Support.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_Support.TextAlign = TextAlign.Right
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	'16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_Reactivation.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  	'16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_Inclusion.TextAlign = TextAlign.Right
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  	'16/7/2015|EA| change layout 
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatColumns = 2
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatDirection = RepeatDirection.Horizontal
'DEL  	STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.RepeatLayout = RepeatLayout.Flow
'DEL  	'STUDENT_DIAGNOSIS_DATARadioButton_Wellbeing.TextAlign = TextAlign.Right
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      '11-Apr-2011|EA| check the checkbox lists for Wellbeing 
'DEL  	' using example code from ExamplePack 1. Steps through options and checks all that apply.
'DEL  	' Main change is we use list of items not from database
'DEL  
'DEL  	if (item.Hidden_WellbeingList.Value <> "0" and item.Hidden_WellbeingList.Value <> "0,") then
'DEL  
'DEL  		Dim checkItemsDis As String() = item.Hidden_WellbeingList.Value.Split(New Char() {","c})
'DEL  	'	' loop through checkboxitems and compare against the array
'DEL  		Dim thisItemDis As String = ""
'DEL  		For Each thisItemDis In checkItemsDis
'DEL  			' set that item as checked
'DEL  			item.CheckBoxList_WellbeingItems.SetSelection(thisItemDis)
'DEL  		Next
'DEL  		' and display
'DEL  		STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items.Clear()
'DEL  	    item.CheckBoxList_WellbeingItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items)
'DEL  	end if
'DEL   
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL  
'DEL      '11-Apr-2011|EA| check the checkbox lists for Inclusion
'DEL  	
'DEL  	if (item.Hidden_InclusionList.Value <> "0" and item.Hidden_InclusionList.Value <> "0,") then
'DEL  
'DEL  		' split up the string into an array
'DEL  		Dim checkItemsPQ As String() = item.Hidden_InclusionList.Value.Split(New Char() {","c})
'DEL  		' loop through checkboxitems and compare against the array
'DEL  		Dim thisItemPQ As String = ""
'DEL  
'DEL  		For Each thisItemPQ In checkItemsPQ
'DEL  			' set that item as checked
'DEL  			item.CheckBoxList_InclusionItems.SetSelection(thisItemPQ)
'DEL  		Next
'DEL  
'DEL  		' and display
'DEL  		STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items.Clear()
'DEL      	item.CheckBoxList_InclusionItems.CopyTo(STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items)
'DEL  	end if
'DEL   
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL       '16/7/2015|EA| check the checkbox lists for Support
'DEL       '17/9/2015|EA| fix as was pointing to the Yes/No radio button
'DEL  	
'DEL  	if (item.Hidden_SupportList.Value <> "0" and item.Hidden_SupportList.Value <> "0,") then
'DEL  
'DEL  		' split up the string into an array
'DEL  		Dim checkItemsSup As String() = item.Hidden_SupportList.Value.Split(New Char() {","c})
'DEL  		' loop through checkboxitems and compare against the array
'DEL  		Dim thisItemSup As String = ""
'DEL  
'DEL  		For Each thisItemSup In checkItemsSup
'DEL  			' set that item as checked
'DEL  			item.SUPPORT_AT_ENROLMENT_TYPEItems.SetSelection(thisItemSup)
'DEL  		Next
'DEL  
'DEL  		' and display
'DEL  		STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items.Clear()
'DEL      	item.SUPPORT_AT_ENROLMENT_TYPEItems.CopyTo(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items)
'DEL  	end if
'DEL   
'DEL      ' -------------------------


'DEL      ' -------------------------
'DEL      '5-Sept-2018|EA| handle display of tickboxes
'DEL      'STUDENT_DIAGNOSIS_DATAHidden_Action_StudentConsult.Value = CheckListToString(STUDENT_DIAGNOSIS_DATACheckbox_StudentConsult.Items) 
'DEL  	DelimitedStringToCheckList(STUDENT_DIAGNOSIS_DATAHidden_Action_StudentConsult.Value	_
'DEL  		, STUDENT_DIAGNOSIS_DATACheckbox_StudentConsult.Items _
'DEL  		, item.Checkbox_StudentConsultItems)
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL     ' ERA: get the "Wellbeing" and "Inclusions" checkboxes that have been selected, and make comma-delimited strings for saving.
'DEL  	' combine the selected array items then join to string
'DEL  	Dim checkItemsPQ as String = "0,"
'DEL  	Dim thisItemPQ As ListItem
'DEL  
'DEL  	For Each thisItemPQ In STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items
'DEL  		if thisItemPQ.Selected then
'DEL  			checkItemsPQ += (thisItemPQ.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value = (checkItemsPQ.TrimEnd(","C))
'DEL  	
'DEL  	Dim checkItemsDis as String = "0,"
'DEL  	Dim thisItemDis As ListItem
'DEL  
'DEL  	For Each thisItemDis In STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items
'DEL  		if thisItemDis.Selected then
'DEL  			checkItemsDis += (thisItemDis.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value = (checkItemsDis.TrimEnd(","C))
'DEL  	
'DEL  	'17/09/2015|EA| fix instead of using rediobutton code which was wrong
'DEL  	Dim checkItemsSup as String = "0,"
'DEL  	Dim thisItemSup As ListItem
'DEL  
'DEL  	For Each thisItemSup In STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items
'DEL  		if thisItemSup.Selected then
'DEL  			checkItemsSup += (thisItemSup.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value = (checkItemsSup.TrimEnd(","C))
'DEL  	
'DEL  	'5-Sept-2018|EA|new tickboxes to handle stringify of ticked options
'DEL  	' TODO ++++++++++++++++ put the UPDATE items here as well once tested
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: get the "Wellbeing" and "Inclusions" checkboxes that have been selected, and make comma-delimited strings for saving.
'DEL  	' combine the selected array items then join to string
'DEL  	Dim checkItemsPQ as String = "0,"
'DEL  	Dim thisItemPQ As ListItem
'DEL  
'DEL  	For Each thisItemPQ In STUDENT_DIAGNOSIS_DATACheckBoxList_Wellbeing.Items
'DEL  		if thisItemPQ.Selected then
'DEL  			checkItemsPQ += (thisItemPQ.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_WellbeingList.Value = (checkItemsPQ.TrimEnd(","C))
'DEL  	
'DEL  	Dim checkItemsDis as String = "0,"
'DEL  	Dim thisItemDis As ListItem
'DEL  
'DEL  	For Each thisItemDis In STUDENT_DIAGNOSIS_DATACheckBoxList_Inclusion.Items
'DEL  		if thisItemDis.Selected then
'DEL  			checkItemsDis += (thisItemDis.Value) + ","
'DEL  		end if
'DEL  	Next
'DEL  
'DEL  	' put in hidden field for collection in BeforeBuild Update
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_InclusionList.Value = (checkItemsDis.TrimEnd(","C))
'DEL  	
'DEL  	
'DEL  	'17/09/2015|EA| fix instead of using rediobutton code which was wrong		
'DEL  	STUDENT_DIAGNOSIS_DATAHidden_SupportList.Value = CheckListToString(STUDENT_DIAGNOSIS_DATASUPPORT_AT_ENROLMENT_TYPE.Items) 
'DEL  	
'DEL  	'5-Sept-2018|EA|new tickboxes to handle stringify of ticked options
'DEL  	ConvertCheckLists()
'DEL  		
'DEL      ' -------------------------

'Grid STUDENT_LEARNING_GOALS1 Bind @166-F5DF54C4

    Protected Sub STUDENT_LEARNING_GOALS1Bind()
        If Not STUDENT_LEARNING_GOALS1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_LEARNING_GOALS1",GetType(STUDENT_LEARNING_GOALS1DataProvider.SortFields), 40, 100)
        End If
'End Grid STUDENT_LEARNING_GOALS1 Bind

'Grid Form STUDENT_LEARNING_GOALS1 BeforeShow tail @166-F51CFF89
        STUDENT_LEARNING_GOALS1Parameters()
        STUDENT_LEARNING_GOALS1Data.SortField = CType(ViewState("STUDENT_LEARNING_GOALS1SortField"),STUDENT_LEARNING_GOALS1DataProvider.SortFields)
        STUDENT_LEARNING_GOALS1Data.SortDir = CType(ViewState("STUDENT_LEARNING_GOALS1SortDir"),SortDirections)
        STUDENT_LEARNING_GOALS1Data.PageNumber = CInt(ViewState("STUDENT_LEARNING_GOALS1PageNumber"))
        STUDENT_LEARNING_GOALS1Data.RecordsPerPage = CInt(ViewState("STUDENT_LEARNING_GOALS1PageSize"))
        STUDENT_LEARNING_GOALS1Repeater.DataSource = STUDENT_LEARNING_GOALS1Data.GetResultSet(PagesCount, STUDENT_LEARNING_GOALS1Operations)
        ViewState("STUDENT_LEARNING_GOALS1PagesCount") = PagesCount
        Dim item As STUDENT_LEARNING_GOALS1Item = New STUDENT_LEARNING_GOALS1Item()
        STUDENT_LEARNING_GOALS1Repeater.DataBind
        FooterIndex = STUDENT_LEARNING_GOALS1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_LEARNING_GOALS1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(FooterIndex).FindControl("STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_GOAL_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_GOAL_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GOAL_CATEGORYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_GOAL_CATEGORYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GOAL_BY_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_GOAL_BY_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GOAL_RESULTSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_GOAL_RESULTSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CREATED_DATETIMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(0).FindControl("Sorter_CREATED_DATETIMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_LEARNING_GOALS1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.STUDENT_LEARNING_GOALS1_InsertHref = "Student_Learning_Goals.aspx"
        STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert.InnerText += item.STUDENT_LEARNING_GOALS1_Insert.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_LEARNING_GOALS1STUDENT_LEARNING_GOALS1_Insert.HRef = item.STUDENT_LEARNING_GOALS1_InsertHref+item.STUDENT_LEARNING_GOALS1_InsertHrefParameters.ToString("GET","LEARNING_GOAL_ID", ViewState)
'End Grid Form STUDENT_LEARNING_GOALS1 BeforeShow tail

'Grid STUDENT_LEARNING_GOALS1 Bind tail @166-E31F8E2A
    End Sub
'End Grid STUDENT_LEARNING_GOALS1 Bind tail

'Grid STUDENT_LEARNING_GOALS1 Table Parameters @166-AA123E18

    Protected Sub STUDENT_LEARNING_GOALS1Parameters()
        Try
            STUDENT_LEARNING_GOALS1Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_LEARNING_GOALS1Data.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_LEARNING_GOALS1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_LEARNING_GOALS1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_LEARNING_GOALS1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_LEARNING_GOALS1 Table Parameters

'Grid STUDENT_LEARNING_GOALS1 ItemDataBound event @166-8AF4ADEF

    Protected Sub STUDENT_LEARNING_GOALS1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_LEARNING_GOALS1Item = CType(e.Item.DataItem,STUDENT_LEARNING_GOALS1Item)
        Dim Item as STUDENT_LEARNING_GOALS1Item = DataItem
        Dim FormDataSource As STUDENT_LEARNING_GOALS1Item() = CType(STUDENT_LEARNING_GOALS1Repeater.DataSource, STUDENT_LEARNING_GOALS1Item())
        Dim STUDENT_LEARNING_GOALS1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_LEARNING_GOALS1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_LEARNING_GOALS1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_LEARNING_GOALS1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_LEARNING_GOALS1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_LEARNING_GOALS1Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_LEARNING_GOALS1GOAL_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1GOAL_TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1GOAL_CATEGORY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1GOAL_CATEGORY"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1GOAL_BY_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1GOAL_BY_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1GOAL_RESULT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1GOAL_RESULT"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1CREATED_DATETIME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1CREATED_DATETIME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1GOAL_DETAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1GOAL_DETAIL"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_LEARNING_GOALS1LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_LEARNING_GOALS1LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "Student_Learning_Goals.aspx"
            STUDENT_LEARNING_GOALS1Detail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STUDENT_LEARNING_GOALS1 ItemDataBound event

'Grid STUDENT_LEARNING_GOALS1 ItemDataBound event tail @166-3AE7E198
        If STUDENT_LEARNING_GOALS1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_LEARNING_GOALS1CurrentRowNumber, ListItemType.Item)
            STUDENT_LEARNING_GOALS1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_LEARNING_GOALS1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_LEARNING_GOALS1 ItemDataBound event tail

'Grid STUDENT_LEARNING_GOALS1 ItemCommand event @166-821B38F0

    Protected Sub STUDENT_LEARNING_GOALS1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_LEARNING_GOALS1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_LEARNING_GOALS1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_LEARNING_GOALS1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_LEARNING_GOALS1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_LEARNING_GOALS1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_LEARNING_GOALS1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_LEARNING_GOALS1DataProvider.SortFields = 0
            ViewState("STUDENT_LEARNING_GOALS1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_LEARNING_GOALS1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_LEARNING_GOALS1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_LEARNING_GOALS1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_LEARNING_GOALS1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_LEARNING_GOALS1Bind
        End If
    End Sub
'End Grid STUDENT_LEARNING_GOALS1 ItemCommand event

'Record Form STUDENT_LEARNING_GOALS2 Parameters @209-EAF281FB

    Protected Sub STUDENT_LEARNING_GOALS2Parameters()
        Dim item As new STUDENT_LEARNING_GOALS2Item
        Try
            STUDENT_LEARNING_GOALS2Data.UrlLEARNING_GOAL_ID = IntegerParameter.GetParam("LEARNING_GOAL_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_LEARNING_GOALS2Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STUDENT_LEARNING_GOALS2Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 Parameters

'Record Form STUDENT_LEARNING_GOALS2 Show method @209-0B11D97F
    Protected Sub STUDENT_LEARNING_GOALS2Show()
        If STUDENT_LEARNING_GOALS2Operations.None Then
            STUDENT_LEARNING_GOALS2Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_LEARNING_GOALS2Item = STUDENT_LEARNING_GOALS2Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_LEARNING_GOALS2Operations.AllowRead
        STUDENT_LEARNING_GOALS2Errors.Add(item.errors)
        If STUDENT_LEARNING_GOALS2Errors.Count > 0 Then
            STUDENT_LEARNING_GOALS2ShowErrors()
            Return
        End If
'End Record Form STUDENT_LEARNING_GOALS2 Show method

'Record Form STUDENT_LEARNING_GOALS2 BeforeShow tail @209-ECCBC859
        STUDENT_LEARNING_GOALS2Parameters()
        STUDENT_LEARNING_GOALS2Data.FillItem(item, IsInsertMode)
        STUDENT_LEARNING_GOALS2Holder.DataBind()
        STUDENT_LEARNING_GOALS2Button_Insert.Visible=IsInsertMode AndAlso STUDENT_LEARNING_GOALS2Operations.AllowInsert
        STUDENT_LEARNING_GOALS2Button_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_LEARNING_GOALS2Operations.AllowUpdate
        STUDENT_LEARNING_GOALS2Button_Delete.Visible=Not (IsInsertMode) AndAlso STUDENT_LEARNING_GOALS2Operations.AllowDelete
        STUDENT_LEARNING_GOALS2GOAL_TITLE.Text=item.GOAL_TITLE.GetFormattedValue()
        STUDENT_LEARNING_GOALS2STUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        STUDENT_LEARNING_GOALS2ENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        STUDENT_LEARNING_GOALS2CREATED_DATETIME.Value = item.CREATED_DATETIME.GetFormattedValue()
        STUDENT_LEARNING_GOALS2LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_LEARNING_GOALS2LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        STUDENT_LEARNING_GOALS2GOAL_BY_DATE.Text=item.GOAL_BY_DATE.GetFormattedValue()
        STUDENT_LEARNING_GOALS2GOAL_CATEGORY.Items.Add(new ListItem("Select Value",""))
        STUDENT_LEARNING_GOALS2GOAL_CATEGORY.Items(0).Selected = True
        item.GOAL_CATEGORYItems.SetSelection(item.GOAL_CATEGORY.GetFormattedValue())
        If Not item.GOAL_CATEGORYItems.GetSelectedItem() Is Nothing Then
            STUDENT_LEARNING_GOALS2GOAL_CATEGORY.SelectedIndex = -1
        End If
        item.GOAL_CATEGORYItems.CopyTo(STUDENT_LEARNING_GOALS2GOAL_CATEGORY.Items)
        STUDENT_LEARNING_GOALS2GOAL_DETAIL.Text=item.GOAL_DETAIL.GetFormattedValue()
        item.GOAL_RESULTItems.SetSelection(item.GOAL_RESULT.GetFormattedValue())
        If Not item.GOAL_RESULTItems.GetSelectedItem() Is Nothing Then
            STUDENT_LEARNING_GOALS2GOAL_RESULT.SelectedIndex = -1
        End If
        item.GOAL_RESULTItems.CopyTo(STUDENT_LEARNING_GOALS2GOAL_RESULT.Items)
        STUDENT_LEARNING_GOALS2RESULT_NOTES.Text=item.RESULT_NOTES.GetFormattedValue()
        STUDENT_LEARNING_GOALS2lblLAST_ALTERED_BY.Text = Server.HtmlEncode(item.lblLAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_LEARNING_GOALS2lblLAST_ALTERED_DATE.Text = Server.HtmlEncode(item.lblLAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form STUDENT_LEARNING_GOALS2 BeforeShow tail

'TextBox GOAL_BY_DATE Event BeforeShow. Action Custom Code @277-73254650
    ' -------------------------
    'Sept 2019|EA| if adding a new one then set for 1 Dec of current year (could use Enrolment year but is mostly calendar ear anyway)
    if (IsInsertMode) then
    	Dim tmpDueDate as new Date(Datetime.Now.Year,12,1)
		STUDENT_LEARNING_GOALS2GOAL_BY_DATE.Text = tmpDueDate.ToString("dd/MM/yyyy")
    end if
    ' -------------------------
'End TextBox GOAL_BY_DATE Event BeforeShow. Action Custom Code

'Record Form STUDENT_LEARNING_GOALS2 Show method tail @209-FD97416E
        If STUDENT_LEARNING_GOALS2Errors.Count > 0 Then
            STUDENT_LEARNING_GOALS2ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 Show method tail

'Record Form STUDENT_LEARNING_GOALS2 LoadItemFromRequest method @209-972C7F55

    Protected Sub STUDENT_LEARNING_GOALS2LoadItemFromRequest(item As STUDENT_LEARNING_GOALS2Item, ByVal EnableValidation As Boolean)
        item.GOAL_TITLE.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2GOAL_TITLE.UniqueID))
        If ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_TITLE") Is Nothing Then
            item.GOAL_TITLE.SetValue(STUDENT_LEARNING_GOALS2GOAL_TITLE.Text)
        Else
            item.GOAL_TITLE.SetValue(ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_TITLE"))
        End If
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2STUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(STUDENT_LEARNING_GOALS2STUDENT_ID.Value)
        Catch ae As ArgumentException
            STUDENT_LEARNING_GOALS2Errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2ENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(STUDENT_LEARNING_GOALS2ENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            STUDENT_LEARNING_GOALS2Errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        Try
        item.CREATED_DATETIME.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2CREATED_DATETIME.UniqueID))
        item.CREATED_DATETIME.SetValue(STUDENT_LEARNING_GOALS2CREATED_DATETIME.Value)
        Catch ae As ArgumentException
            STUDENT_LEARNING_GOALS2Errors.Add("CREATED_DATETIME",String.Format(Resources.strings.CCS_IncorrectFormat,"CREATED DATETIME","yyyy-mm-dd H:nn"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(STUDENT_LEARNING_GOALS2LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(STUDENT_LEARNING_GOALS2LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_LEARNING_GOALS2Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","yyyy-mm-dd H:nn"))
        End Try
        Try
        item.GOAL_BY_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2GOAL_BY_DATE.UniqueID))
        If ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_BY_DATE") Is Nothing Then
            item.GOAL_BY_DATE.SetValue(STUDENT_LEARNING_GOALS2GOAL_BY_DATE.Text)
        Else
            item.GOAL_BY_DATE.SetValue(ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_BY_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENT_LEARNING_GOALS2Errors.Add("GOAL_BY_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"GOAL BY DATE","d/m/yyyy"))
        End Try
        item.GOAL_CATEGORY.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2GOAL_CATEGORY.UniqueID))
        item.GOAL_CATEGORY.SetValue(STUDENT_LEARNING_GOALS2GOAL_CATEGORY.Value)
        item.GOAL_CATEGORYItems.CopyFrom(STUDENT_LEARNING_GOALS2GOAL_CATEGORY.Items)
        item.GOAL_DETAIL.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2GOAL_DETAIL.UniqueID))
        If ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_DETAIL") Is Nothing Then
            item.GOAL_DETAIL.SetValue(STUDENT_LEARNING_GOALS2GOAL_DETAIL.Text)
        Else
            item.GOAL_DETAIL.SetValue(ControlCustomValues("STUDENT_LEARNING_GOALS2GOAL_DETAIL"))
        End If
        item.GOAL_RESULT.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2GOAL_RESULT.UniqueID))
        item.GOAL_RESULT.SetValue(STUDENT_LEARNING_GOALS2GOAL_RESULT.Value)
        item.GOAL_RESULTItems.CopyFrom(STUDENT_LEARNING_GOALS2GOAL_RESULT.Items)
        item.RESULT_NOTES.IsEmpty = IsNothing(Request.Form(STUDENT_LEARNING_GOALS2RESULT_NOTES.UniqueID))
        If ControlCustomValues("STUDENT_LEARNING_GOALS2RESULT_NOTES") Is Nothing Then
            item.RESULT_NOTES.SetValue(STUDENT_LEARNING_GOALS2RESULT_NOTES.Text)
        Else
            item.RESULT_NOTES.SetValue(ControlCustomValues("STUDENT_LEARNING_GOALS2RESULT_NOTES"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_LEARNING_GOALS2Data)
        End If
        STUDENT_LEARNING_GOALS2Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 LoadItemFromRequest method

'Record Form STUDENT_LEARNING_GOALS2 GetRedirectUrl method @209-D4D9B558

    Protected Function GetSTUDENT_LEARNING_GOALS2RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_LEARNING_GOALS2 GetRedirectUrl method

'Record Form STUDENT_LEARNING_GOALS2 ShowErrors method @209-2F6B4DF5

    Protected Sub STUDENT_LEARNING_GOALS2ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_LEARNING_GOALS2Errors.Count - 1
        Select Case STUDENT_LEARNING_GOALS2Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_LEARNING_GOALS2Errors(i)
        End Select
        Next i
        STUDENT_LEARNING_GOALS2Error.Visible = True
        STUDENT_LEARNING_GOALS2ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 ShowErrors method

'Record Form STUDENT_LEARNING_GOALS2 Insert Operation @209-C4BFC5C2

    Protected Sub STUDENT_LEARNING_GOALS2_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_LEARNING_GOALS2Item = New STUDENT_LEARNING_GOALS2Item()
        Dim ExecuteFlag As Boolean = True
        STUDENT_LEARNING_GOALS2IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_LEARNING_GOALS2 Insert Operation

'Button Button_Insert OnClick. @211-4667743F
        If CType(sender,Control).ID = "STUDENT_LEARNING_GOALS2Button_Insert" Then
            RedirectUrl = GetSTUDENT_LEARNING_GOALS2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @211-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_LEARNING_GOALS2 BeforeInsert tail @209-C6B17B70
    STUDENT_LEARNING_GOALS2Parameters()
    STUDENT_LEARNING_GOALS2LoadItemFromRequest(item, EnableValidation)
    If STUDENT_LEARNING_GOALS2Operations.AllowInsert Then
        ErrorFlag=(STUDENT_LEARNING_GOALS2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_LEARNING_GOALS2Data.InsertItem(item)
            Catch ex As Exception
                STUDENT_LEARNING_GOALS2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_LEARNING_GOALS2 BeforeInsert tail

'Record STUDENT_LEARNING_GOALS2 Event AfterInsert. Action Custom Code @282-73254650
    ' -------------------------
    if (STUDENT_LEARNING_GOALS2Errors.Count = 0) then
    	HttpContext.Current.Session("notifymessage") = "Student Learning Goal has been Added"
    end if
    ' -------------------------
'End Record STUDENT_LEARNING_GOALS2 Event AfterInsert. Action Custom Code

'Record Form STUDENT_LEARNING_GOALS2 AfterInsert tail  @209-91CCC155
        End If
        ErrorFlag=(STUDENT_LEARNING_GOALS2Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_LEARNING_GOALS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 AfterInsert tail 

'Record Form STUDENT_LEARNING_GOALS2 Update Operation @209-10668991

    Protected Sub STUDENT_LEARNING_GOALS2_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_LEARNING_GOALS2Item = New STUDENT_LEARNING_GOALS2Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_LEARNING_GOALS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_LEARNING_GOALS2 Update Operation

'Button Button_Update OnClick. @212-A18AAC94
        If CType(sender,Control).ID = "STUDENT_LEARNING_GOALS2Button_Update" Then
            RedirectUrl = GetSTUDENT_LEARNING_GOALS2RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @212-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record STUDENT_LEARNING_GOALS2 Event BeforeUpdate. Action Retrieve Value for Control @278-2CC908E9
        STUDENT_LEARNING_GOALS2LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record STUDENT_LEARNING_GOALS2 Event BeforeUpdate. Action Retrieve Value for Control

'Record STUDENT_LEARNING_GOALS2 Event BeforeUpdate. Action Retrieve Value for Control @279-8514269F
        STUDENT_LEARNING_GOALS2LAST_ALTERED_DATE.Value = (New DateField("yyyy-MM-dd H\:mm", (Now()))).GetFormattedValue()
'End Record STUDENT_LEARNING_GOALS2 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form STUDENT_LEARNING_GOALS2 Before Update tail @209-A6C1732E
        STUDENT_LEARNING_GOALS2Parameters()
        STUDENT_LEARNING_GOALS2LoadItemFromRequest(item, EnableValidation)
        If STUDENT_LEARNING_GOALS2Operations.AllowUpdate Then
        ErrorFlag = (STUDENT_LEARNING_GOALS2Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_LEARNING_GOALS2Data.UpdateItem(item)
            Catch ex As Exception
                STUDENT_LEARNING_GOALS2Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_LEARNING_GOALS2 Before Update tail

'Record STUDENT_LEARNING_GOALS2 Event AfterUpdate. Action Custom Code @283-73254650
    ' -------------------------
    if (STUDENT_LEARNING_GOALS2Errors.Count = 0) then
    	HttpContext.Current.Session("notifymessage") = "Student Learning Goal has been Updated"
    end if
    ' -------------------------
'End Record STUDENT_LEARNING_GOALS2 Event AfterUpdate. Action Custom Code

'Record Form STUDENT_LEARNING_GOALS2 Update Operation tail @209-91CCC155
        End If
        ErrorFlag=(STUDENT_LEARNING_GOALS2Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_LEARNING_GOALS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 Update Operation tail

'Record Form STUDENT_LEARNING_GOALS2 Delete Operation @209-CD220933
    Protected Sub STUDENT_LEARNING_GOALS2_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_LEARNING_GOALS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_LEARNING_GOALS2Item = New STUDENT_LEARNING_GOALS2Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_LEARNING_GOALS2 Delete Operation

'Button Button_Delete OnClick. @213-19EAD33A
        If CType(sender,Control).ID = "STUDENT_LEARNING_GOALS2Button_Delete" Then
            RedirectUrl = GetSTUDENT_LEARNING_GOALS2RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @213-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @209-26D8BE73
        STUDENT_LEARNING_GOALS2Parameters()
        STUDENT_LEARNING_GOALS2LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @209-5502B4CF
        If ErrorFlag Then
            STUDENT_LEARNING_GOALS2ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_LEARNING_GOALS2 Cancel Operation @209-A6EFCE55

    Protected Sub STUDENT_LEARNING_GOALS2_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_LEARNING_GOALS2Item = New STUDENT_LEARNING_GOALS2Item()
        STUDENT_LEARNING_GOALS2IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_LEARNING_GOALS2LoadItemFromRequest(item, False)
'End Record Form STUDENT_LEARNING_GOALS2 Cancel Operation

'Button Button_Cancel OnClick. @215-F1967D91
    If CType(sender,Control).ID = "STUDENT_LEARNING_GOALS2Button_Cancel" Then
        RedirectUrl = GetSTUDENT_LEARNING_GOALS2RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @215-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_LEARNING_GOALS2 Cancel Operation tail @209-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_LEARNING_GOALS2 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-D40DBF02
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Learning_GoalsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_LEARNING_GOALS1Data = New STUDENT_LEARNING_GOALS1DataProvider()
        STUDENT_LEARNING_GOALS1Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_LEARNING_GOALS2Data = New STUDENT_LEARNING_GOALS2DataProvider()
        STUDENT_LEARNING_GOALS2Operations = New FormSupportedOperations(False, True, True, True, False)
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

