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

Namespace DECV_PROD2007.Student_Carer_Maint 'Namespace @1-4F98C101

'Forms Definition @1-6370A4E5
Public Class [Student_Carer_MaintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-689484F2
    Protected Grid1Data As Grid1DataProvider
    Protected Grid1Operations As FormSupportedOperations
    Protected Grid1CurrentRowNumber As Integer
    Protected STUDENT_CARER_CONTACTData As STUDENT_CARER_CONTACTDataProvider
    Protected STUDENT_CARER_CONTACTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_CARER_CONTACTOperations As FormSupportedOperations
    Protected STUDENT_CARER_CONTACTIsSubmitted As Boolean = False
    Protected Student_Carer_MaintContentMeta As String
'End Forms Objects
	Protected FlagAddCarer As Int64 = 0
	Protected FlagAddSuperVisor As Int64 = 0
	Protected iUrlCarer_ID As Int64 = 0
'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-EFA4211C
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Grid1Bind
            STUDENT_CARER_CONTACTShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid Grid1 Bind @4-78E5CD6D

    Protected Sub Grid1Bind()
        If Not Grid1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid1",GetType(Grid1DataProvider.SortFields), 10, 100)
        End If
'End Grid Grid1 Bind

'Grid Form Grid1 BeforeShow tail @4-0495A67D
        Grid1Parameters()
        Grid1Data.SortField = CType(ViewState("Grid1SortField"),Grid1DataProvider.SortFields)
        Grid1Data.SortDir = CType(ViewState("Grid1SortDir"),SortDirections)
        Grid1Data.PageNumber = CInt(ViewState("Grid1PageNumber"))
        Grid1Data.RecordsPerPage = CInt(ViewState("Grid1PageSize"))
        Grid1Repeater.DataSource = Grid1Data.GetResultSet(PagesCount, Grid1Operations)
        ViewState("Grid1PagesCount") = PagesCount
        Dim item As Grid1Item = New Grid1Item()
        Grid1Repeater.DataBind
        FooterIndex = Grid1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Grid1Grid1_AddCarer As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(Grid1Repeater.Controls(FooterIndex).FindControl("Grid1Grid1_AddCarer"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_HOME_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_HOME_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_WORK_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_WORK_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_MOBILESorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_MOBILESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_EMAILSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_EMAILSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_RELATIONSHIPSorter As DECV_PROD2007.Controls.Sorter = DirectCast(Grid1Repeater.Controls(0).FindControl("Sorter_RELATIONSHIPSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Grid1Grid1_AddSuperVisor As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(Grid1Repeater.Controls(FooterIndex).FindControl("Grid1Grid1_AddSuperVisor"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.Grid1_AddCarerHref = "Student_Carer_Maint.aspx"
        item.Grid1_AddSuperVisorHref = "Student_Carer_Maint.aspx"
        item.Grid1_AddSuperVisorHrefParameters.Add("Ss",System.Web.HttpUtility.UrlEncode((1).ToString()))
        Grid1Grid1_AddCarer.InnerText += item.Grid1_AddCarer.GetFormattedValue().Replace(vbCrLf,"")
        Grid1Grid1_AddCarer.HRef = item.Grid1_AddCarerHref+item.Grid1_AddCarerHrefParameters.ToString("GET","CARER_ID;Ss", ViewState)
        Grid1Grid1_AddSuperVisor.InnerText += item.Grid1_AddSuperVisor.GetFormattedValue().Replace(vbCrLf,"")
        Grid1Grid1_AddSuperVisor.HRef = item.Grid1_AddSuperVisorHref+item.Grid1_AddSuperVisorHrefParameters.ToString("GET","CARER_ID", ViewState)
'End Grid Form Grid1 BeforeShow tail

'Grid Grid1 Event BeforeShow. Action Declare Variable @76-50602C3D
        Dim TmpParentFlag As Int64 = 0
'End Grid Grid1 Event BeforeShow. Action Declare Variable

'Grid Grid1 Event BeforeShow. Action DLookup @75-CB653CEB
        TmpParentFlag = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "1" & " FROM " & "STUDENT" & " WHERE " & "STUDENT_ID=" &  Grid1Data.UrlSTUDENT_ID.tostring &  " and PARENT1>0 and PARENT2>0"))).Value, Int64)
'End Grid Grid1 Event BeforeShow. Action DLookup

'Grid Grid1 Event BeforeShow. Action Hide-Show Component @77-7994C900
        Dim ExprParam1_77_1 As IntegerField = New IntegerField("", (TmpParentFlag))
        Dim ExprParam2_77_2 As IntegerField = New IntegerField("", (1))
        If FieldBase.EqualOp(ExprParam1_77_1, ExprParam2_77_2) Then
            Grid1Grid1_AddCarer.Visible = False
			FlagAddCarer=1
        End If
'End Grid Grid1 Event BeforeShow. Action Hide-Show Component

'Grid Grid1 Event BeforeShow. Action Declare Variable @78-4E7B5F8E
        Dim TmpStudentSuperVisorFlag As Int64 = 0
'End Grid Grid1 Event BeforeShow. Action Declare Variable

'Grid Grid1 Event BeforeShow. Action DLookup @79-D44BF5EB
        TmpStudentSuperVisorFlag = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "1" & " FROM " & "STUDENT_ENROLMENT" & " WHERE " & "STUDENT_ID=" & Grid1Data.UrlSTUDENT_ID.tostring & " and ENROLMENT_YEAR=" & Grid1Data.UrlENROLMENT_YEAR.tostring  & " and ISNULL(SCHOOL_SUPERVISOR_NAME,0)>0"))).Value, Int64)
'End Grid Grid1 Event BeforeShow. Action DLookup

'Grid Grid1 Event BeforeShow. Action Hide-Show Component @81-05264ACE
        Dim ExprParam1_81_1 As IntegerField = New IntegerField("", (TmpStudentSuperVisorFlag))
        Dim ExprParam2_81_2 As IntegerField = New IntegerField("", (1))
        If FieldBase.EqualOp(ExprParam1_81_1, ExprParam2_81_2) Then
            Grid1Grid1_AddSuperVisor.Visible = False
			FlagAddSuperVisor=1	
        End If
'End Grid Grid1 Event BeforeShow. Action Hide-Show Component

'Grid Grid1 Bind tail @4-E31F8E2A
    End Sub
'End Grid Grid1 Bind tail

'Grid Grid1 Table Parameters @4-1042E387

    Protected Sub Grid1Parameters()
        Try
            Grid1Data.UrlSTUDENT_ID = FloatParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 56794, false)
            Grid1Data.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", "", false)

        Catch
            Dim ParentControls As ControlCollection=Grid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid1 Table Parameters

'Grid Grid1 ItemDataBound event @4-AC9EE61E

    Protected Sub Grid1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid1Item = CType(e.Item.DataItem,Grid1Item)
        Dim Item as Grid1Item = DataItem
        Dim FormDataSource As Grid1Item() = CType(Grid1Repeater.DataSource, Grid1Item())
        Dim Grid1DataRows As Integer = FormDataSource.Length
        Dim Grid1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid1Detail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid1Detail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid1TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1TITLE"),System.Web.UI.WebControls.Literal)
            Dim Grid1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim Grid1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim Grid1HOME_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1HOME_PHONE"),System.Web.UI.WebControls.Literal)
            Dim Grid1WORK_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1WORK_PHONE"),System.Web.UI.WebControls.Literal)
            Dim Grid1MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1MOBILE"),System.Web.UI.WebControls.Literal)
            Dim Grid1EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1EMAIL"),System.Web.UI.WebControls.Literal)
            Dim Grid1RELATIONSHIP As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1RELATIONSHIP"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "Student_Carer_Maint.aspx"
            Grid1Detail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid Grid1 ItemDataBound event

'Grid1 control Before Show @4-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid1 control Before Show

'Get Control @47-815A2106
            Dim Grid1RELATIONSHIP As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1RELATIONSHIP"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label RELATIONSHIP Event BeforeShow. Action Custom Code @72-73254650
    ' -------------------------
		if Grid1RELATIONSHIP.Text="PA" then
			Grid1RELATIONSHIP.Text="PARENT"
		else if Grid1RELATIONSHIP.Text="SP" then
			Grid1RELATIONSHIP.Text="STEP-PARENT"
		else if Grid1RELATIONSHIP.Text="AP" then
			Grid1RELATIONSHIP.Text="ADOPTIVE PARENT"
		else if Grid1RELATIONSHIP.Text="FP" then
			Grid1RELATIONSHIP.Text="FOSTER PARENT"
		else if Grid1RELATIONSHIP.Text="GP" then
			Grid1RELATIONSHIP.Text="GRAND PARENT"
		else if Grid1RELATIONSHIP.Text="HF" then
			Grid1RELATIONSHIP.Text="HOST FAMILY"
		else if Grid1RELATIONSHIP.Text="RE" then
			Grid1RELATIONSHIP.Text="RELATIVE"
		else if Grid1RELATIONSHIP.Text="FR" then
			Grid1RELATIONSHIP.Text="FRIEND"
		else if Grid1RELATIONSHIP.Text="SE" then
			Grid1RELATIONSHIP.Text="SELF"
		else if Grid1RELATIONSHIP.Text="OT" then
			Grid1RELATIONSHIP.Text="OTHER"
		else if Grid1RELATIONSHIP.Text="SS" then
			Grid1RELATIONSHIP.Text="SCHOOL SUPERVISOR"
		end if    

    ' -------------------------
'End Label RELATIONSHIP Event BeforeShow. Action Custom Code

'Grid1 control Before Show tail @4-477CF3C9
        End If
'End Grid1 control Before Show tail

'Grid Grid1 ItemDataBound event tail @4-C2C5318F
        If Grid1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid1CurrentRowNumber, ListItemType.Item)
            Grid1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid1 ItemDataBound event tail

'Grid Grid1 ItemCommand event @4-E28C8E00

    Protected Sub Grid1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid1SortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid1SortDir")=SortDirections._Desc
                Else
                    ViewState("Grid1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid1DataProvider.SortFields = 0
            ViewState("Grid1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid1Bind
        End If
    End Sub
'End Grid Grid1 ItemCommand event

'Record Form STUDENT_CARER_CONTACT Parameters @31-9897BD6C

    Protected Sub STUDENT_CARER_CONTACTParameters()
        Dim item As new STUDENT_CARER_CONTACTItem
        Try
            STUDENT_CARER_CONTACTData.UrlCARER_ID = FloatParameter.GetParam("CARER_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlHidden_Carer_ID = FloatParameter.GetParam(item.Hidden_Carer_ID.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.UrlStudent_ID = FloatParameter.GetParam("Student_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACTData.UrlENROLMENT_YEAR = FloatParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlTITLE = TextParameter.GetParam(item.TITLE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlSURNAME = TextParameter.GetParam(item.SURNAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlFIRST_NAME = TextParameter.GetParam(item.FIRST_NAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlRELATIONSHIP = TextParameter.GetParam(item.RELATIONSHIP.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlHOME_PHONE = TextParameter.GetParam(item.HOME_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlWORK_PHONE = TextParameter.GetParam(item.WORK_PHONE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlMOBILE = TextParameter.GetParam(item.MOBILE.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlEMAIL = TextParameter.GetParam(item.EMAIL.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENT_CARER_CONTACTData.CtrlLAST_ALTERED_BY = TextParameter.GetParam(item.LAST_ALTERED_BY.Value, ParameterSourceType.Control, "", Nothing, false)
        Catch e As Exception
            STUDENT_CARER_CONTACTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_CARER_CONTACT Parameters

'Record Form STUDENT_CARER_CONTACT Show method @31-018543DE
    Protected Sub STUDENT_CARER_CONTACTShow()
        If STUDENT_CARER_CONTACTOperations.None Then
            STUDENT_CARER_CONTACTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_CARER_CONTACTItem = STUDENT_CARER_CONTACTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_CARER_CONTACTOperations.AllowRead
        STUDENT_CARER_CONTACTErrors.Add(item.errors)
        If STUDENT_CARER_CONTACTErrors.Count > 0 Then
            STUDENT_CARER_CONTACTShowErrors()
            Return
        End If
'End Record Form STUDENT_CARER_CONTACT Show method

'Record Form STUDENT_CARER_CONTACT BeforeShow tail @31-07AB6848
        STUDENT_CARER_CONTACTParameters()
        STUDENT_CARER_CONTACTData.FillItem(item, IsInsertMode)
        STUDENT_CARER_CONTACTHolder.DataBind()
        STUDENT_CARER_CONTACTButton_Insert.Visible=IsInsertMode AndAlso STUDENT_CARER_CONTACTOperations.AllowInsert
        STUDENT_CARER_CONTACTButton_Update.Visible=Not (IsInsertMode) AndAlso STUDENT_CARER_CONTACTOperations.AllowUpdate
        STUDENT_CARER_CONTACTTITLE.Items.Add(new ListItem("Select Title",""))
        STUDENT_CARER_CONTACTTITLE.Items(0).Selected = True
        item.TITLEItems.SetSelection(item.TITLE.GetFormattedValue())
        If Not item.TITLEItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACTTITLE.SelectedIndex = -1
        End If
        item.TITLEItems.CopyTo(STUDENT_CARER_CONTACTTITLE.Items)
        STUDENT_CARER_CONTACTSURNAME.Text=item.SURNAME.GetFormattedValue()
        STUDENT_CARER_CONTACTFIRST_NAME.Text=item.FIRST_NAME.GetFormattedValue()
        STUDENT_CARER_CONTACTHOME_PHONE.Text=item.HOME_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACTWORK_PHONE.Text=item.WORK_PHONE.GetFormattedValue()
        STUDENT_CARER_CONTACTMOBILE.Text=item.MOBILE.GetFormattedValue()
        STUDENT_CARER_CONTACTEMAIL.Text=item.EMAIL.GetFormattedValue()
        STUDENT_CARER_CONTACTLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        STUDENT_CARER_CONTACTLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        STUDENT_CARER_CONTACTRELATIONSHIP.Items.Add(new ListItem("Select Relation",""))
        STUDENT_CARER_CONTACTRELATIONSHIP.Items(0).Selected = True
        item.RELATIONSHIPItems.SetSelection(item.RELATIONSHIP.GetFormattedValue())
        If Not item.RELATIONSHIPItems.GetSelectedItem() Is Nothing Then
            STUDENT_CARER_CONTACTRELATIONSHIP.SelectedIndex = -1
        End If
        item.RELATIONSHIPItems.CopyTo(STUDENT_CARER_CONTACTRELATIONSHIP.Items)
        STUDENT_CARER_CONTACTLabel_MESSAGE.Text = Server.HtmlEncode(item.Label_MESSAGE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STUDENT_CARER_CONTACTHidden_Surname.Value = item.Hidden_Surname.GetFormattedValue()
        STUDENT_CARER_CONTACTHidden_Carer_ID.Value = item.Hidden_Carer_ID.GetFormattedValue()
'End Record Form STUDENT_CARER_CONTACT BeforeShow tail

'DEL      ' -------------------------
'DEL     	
'DEL      ' -------------------------


'Label Label_MESSAGE Event BeforeShow. Action Custom Code @74-73254650
    ' ------------------------- 				
        If Not Request.QueryString("SS") Is Nothing Then
			STUDENT_CARER_CONTACTLabel_MESSAGE.TEXT="SUPERVISOR"
			STUDENT_CARER_CONTACTRELATIONSHIP.Value = "SS"
		ELSE
			STUDENT_CARER_CONTACTLabel_MESSAGE.TEXT="CARER"
			STUDENT_CARER_CONTACTRELATIONSHIP.Value=""
        End If
		If Not Request.QueryString("Carer_id") Is Nothing Then
			iUrlCarer_ID =Request.QueryString("Carer_id")
		else
			iUrlCarer_ID =0
		end if
    ' -------------------------
'End Label Label_MESSAGE Event BeforeShow. Action Custom Code

'Record STUDENT_CARER_CONTACT Event BeforeShow. Action Custom Code @82-73254650
    ' -------------------------
    ' check if the Add New link (Grid1Grid1_Insert) is visible, and change Student_Carer_Contact Record IsInsertMode property 
	if FlagAddSuperVisor=1 and FlagAddCarer=1 then
		STUDENT_CARER_CONTACTButton_Insert.Visible= false
	else if 	iUrlCarer_ID >0 then
		STUDENT_CARER_CONTACTButton_Insert.Visible= false
	else
		STUDENT_CARER_CONTACTButton_Insert.Visible=true
	end if
	'IsInsertMode AndAlso STUDENT_CARER_CONTACTOperations.AllowInsert
    ' -------------------------
'End Record STUDENT_CARER_CONTACT Event BeforeShow. Action Custom Code

'Record STUDENT_CARER_CONTACT Event BeforeShow. Action Retrieve Value for Control @173-676B582B
            STUDENT_CARER_CONTACTHidden_Carer_ID.Value = (New TextField("", iUrlCarer_ID)).GetFormattedValue()
'End Record STUDENT_CARER_CONTACT Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_CARER_CONTACT Show method tail @31-51088330
        If STUDENT_CARER_CONTACTErrors.Count > 0 Then
            STUDENT_CARER_CONTACTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT Show method tail

'Record Form STUDENT_CARER_CONTACT LoadItemFromRequest method @31-32BE54F9

    Protected Sub STUDENT_CARER_CONTACTLoadItemFromRequest(item As STUDENT_CARER_CONTACTItem, ByVal EnableValidation As Boolean)
        item.TITLE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTTITLE.UniqueID))
        item.TITLE.SetValue(STUDENT_CARER_CONTACTTITLE.Value)
        item.TITLEItems.CopyFrom(STUDENT_CARER_CONTACTTITLE.Items)
        item.SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTSURNAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTSURNAME") Is Nothing Then
            item.SURNAME.SetValue(STUDENT_CARER_CONTACTSURNAME.Text)
        Else
            item.SURNAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTSURNAME"))
        End If
        item.FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTFIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTFIRST_NAME") Is Nothing Then
            item.FIRST_NAME.SetValue(STUDENT_CARER_CONTACTFIRST_NAME.Text)
        Else
            item.FIRST_NAME.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTFIRST_NAME"))
        End If
        item.HOME_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTHOME_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTHOME_PHONE") Is Nothing Then
            item.HOME_PHONE.SetValue(STUDENT_CARER_CONTACTHOME_PHONE.Text)
        Else
            item.HOME_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTHOME_PHONE"))
        End If
        item.WORK_PHONE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTWORK_PHONE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTWORK_PHONE") Is Nothing Then
            item.WORK_PHONE.SetValue(STUDENT_CARER_CONTACTWORK_PHONE.Text)
        Else
            item.WORK_PHONE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTWORK_PHONE"))
        End If
        item.MOBILE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTMOBILE.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTMOBILE") Is Nothing Then
            item.MOBILE.SetValue(STUDENT_CARER_CONTACTMOBILE.Text)
        Else
            item.MOBILE.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTMOBILE"))
        End If
        item.EMAIL.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTEMAIL.UniqueID))
        If ControlCustomValues("STUDENT_CARER_CONTACTEMAIL") Is Nothing Then
            item.EMAIL.SetValue(STUDENT_CARER_CONTACTEMAIL.Text)
        Else
            item.EMAIL.SetValue(ControlCustomValues("STUDENT_CARER_CONTACTEMAIL"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(STUDENT_CARER_CONTACTLAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(STUDENT_CARER_CONTACTLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            STUDENT_CARER_CONTACTErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.RELATIONSHIP.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTRELATIONSHIP.UniqueID))
        item.RELATIONSHIP.SetValue(STUDENT_CARER_CONTACTRELATIONSHIP.Value)
        item.RELATIONSHIPItems.CopyFrom(STUDENT_CARER_CONTACTRELATIONSHIP.Items)
        item.Hidden_Surname.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTHidden_Surname.UniqueID))
        item.Hidden_Surname.SetValue(STUDENT_CARER_CONTACTHidden_Surname.Value)
        item.Hidden_Carer_ID.IsEmpty = IsNothing(Request.Form(STUDENT_CARER_CONTACTHidden_Carer_ID.UniqueID))
        item.Hidden_Carer_ID.SetValue(STUDENT_CARER_CONTACTHidden_Carer_ID.Value)
        If EnableValidation Then
            item.Validate(STUDENT_CARER_CONTACTData)
        End If
        STUDENT_CARER_CONTACTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_CARER_CONTACT LoadItemFromRequest method

'Record Form STUDENT_CARER_CONTACT GetRedirectUrl method @31-A4428C12

    Protected Function GetSTUDENT_CARER_CONTACTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","CARER_ID;Ss;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_CARER_CONTACT GetRedirectUrl method

'Record Form STUDENT_CARER_CONTACT ShowErrors method @31-A2B49E60

    Protected Sub STUDENT_CARER_CONTACTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_CARER_CONTACTErrors.Count - 1
        Select Case STUDENT_CARER_CONTACTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_CARER_CONTACTErrors(i)
        End Select
        Next i
        STUDENT_CARER_CONTACTError.Visible = True
        STUDENT_CARER_CONTACTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_CARER_CONTACT ShowErrors method

'Record Form STUDENT_CARER_CONTACT Insert Operation @31-3273945C

    Protected Sub STUDENT_CARER_CONTACT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        Dim ExecuteFlag As Boolean = True
        STUDENT_CARER_CONTACTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT Insert Operation

'Button Button_Insert OnClick. @32-D84077E5
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACTButton_Insert" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @32-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STUDENT_CARER_CONTACT BeforeInsert tail @31-5E99EC61
    STUDENT_CARER_CONTACTParameters()
    STUDENT_CARER_CONTACTLoadItemFromRequest(item, EnableValidation)
    If STUDENT_CARER_CONTACTOperations.AllowInsert Then
        ErrorFlag=(STUDENT_CARER_CONTACTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACTData.InsertItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT BeforeInsert tail

'Record Form STUDENT_CARER_CONTACT AfterInsert tail  @31-EBBAF2E1
        End If
        ErrorFlag=(STUDENT_CARER_CONTACTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT AfterInsert tail 

'Record Form STUDENT_CARER_CONTACT Update Operation @31-493B7812

    Protected Sub STUDENT_CARER_CONTACT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_CARER_CONTACT Update Operation

'Button Button_Update OnClick. @33-28CA5652
        If CType(sender,Control).ID = "STUDENT_CARER_CONTACTButton_Update" Then
            RedirectUrl = GetSTUDENT_CARER_CONTACTRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @33-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STUDENT_CARER_CONTACT Before Update tail @31-7C6E0EFA
        STUDENT_CARER_CONTACTParameters()
        STUDENT_CARER_CONTACTLoadItemFromRequest(item, EnableValidation)
        If STUDENT_CARER_CONTACTOperations.AllowUpdate Then
        ErrorFlag = (STUDENT_CARER_CONTACTErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENT_CARER_CONTACTData.UpdateItem(item)
            Catch ex As Exception
                STUDENT_CARER_CONTACTErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENT_CARER_CONTACT Before Update tail

'Record Form STUDENT_CARER_CONTACT Update Operation tail @31-EBBAF2E1
        End If
        ErrorFlag=(STUDENT_CARER_CONTACTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_CARER_CONTACTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_CARER_CONTACT Update Operation tail

'Record Form STUDENT_CARER_CONTACT Delete Operation @31-BC6DE462
    Protected Sub STUDENT_CARER_CONTACT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_CARER_CONTACTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_CARER_CONTACT Delete Operation

'Record Form BeforeDelete tail @31-9902603B
        STUDENT_CARER_CONTACTParameters()
        STUDENT_CARER_CONTACTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @31-AC600F77
        If ErrorFlag Then
            STUDENT_CARER_CONTACTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_CARER_CONTACT Cancel Operation @31-A77D8FD7

    Protected Sub STUDENT_CARER_CONTACT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_CARER_CONTACTItem = New STUDENT_CARER_CONTACTItem()
        STUDENT_CARER_CONTACTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_CARER_CONTACTLoadItemFromRequest(item, False)
'End Record Form STUDENT_CARER_CONTACT Cancel Operation

'Button Button_Cancel OnClick. @34-D924D7FA
    If CType(sender,Control).ID = "STUDENT_CARER_CONTACTButton_Cancel" Then
        RedirectUrl = GetSTUDENT_CARER_CONTACTRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @34-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STUDENT_CARER_CONTACT Cancel Operation tail @31-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_CARER_CONTACT Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-A9CF2A56
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_Carer_MaintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Grid1Data = New Grid1DataProvider()
        Grid1Operations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_CARER_CONTACTData = New STUDENT_CARER_CONTACTDataProvider()
        STUDENT_CARER_CONTACTOperations = New FormSupportedOperations(False, True, True, True, False)
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

