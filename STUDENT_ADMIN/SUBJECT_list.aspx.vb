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

Namespace DECV_PROD2007.SUBJECT_list 'Namespace @1-B68DC725

'Forms Definition @1-8EA55661
Public Class [SUBJECT_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-D693693C
    Protected SUBJECTData As SUBJECTDataProvider
    Protected SUBJECTOperations As FormSupportedOperations
    Protected SUBJECTCurrentRowNumber As Integer
    Protected SUBJECT1Data As SUBJECT1DataProvider
    Protected SUBJECT1Errors As NameValueCollection = New NameValueCollection()
    Protected SUBJECT1Operations As FormSupportedOperations
    Protected SUBJECT1IsSubmitted As Boolean = False
    Protected SUBJECT_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-E7482921
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "SUBJECT_maint.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","SUBJECT_ID", ViewState)
            Link1.DataBind()
            SUBJECTBind
            SUBJECT1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid SUBJECT Bind @6-1548C6BC

    Protected Sub SUBJECTBind()
        If Not SUBJECTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SUBJECT",GetType(SUBJECTDataProvider.SortFields), 50, 100)
        End If
'End Grid SUBJECT Bind

'Grid Form SUBJECT BeforeShow tail @6-191CF27F
        SUBJECTParameters()
        SUBJECTData.SortField = CType(ViewState("SUBJECTSortField"),SUBJECTDataProvider.SortFields)
        SUBJECTData.SortDir = CType(ViewState("SUBJECTSortDir"),SortDirections)
        SUBJECTData.PageNumber = CInt(ViewState("SUBJECTPageNumber"))
        SUBJECTData.RecordsPerPage = CInt(ViewState("SUBJECTPageSize"))
        SUBJECTRepeater.DataSource = SUBJECTData.GetResultSet(PagesCount, SUBJECTOperations)
        ViewState("SUBJECTPagesCount") = PagesCount
        Dim item As SUBJECTItem = New SUBJECTItem()
        SUBJECTRepeater.DataBind
        FooterIndex = SUBJECTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SUBJECTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_ABBREVSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_SUBJECT_ABBREVSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim SUBJECTSUBJECT_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(SUBJECTRepeater.Controls(FooterIndex).FindControl("SUBJECTSUBJECT_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(SUBJECTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim Sorter_YearlevelSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_YearlevelSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DefaultTeacherIDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_DefaultTeacherIDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim SorterCoreSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("SorterCoreSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ALLOCATE_STUDENTS_MAXSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SUBJECTRepeater.Controls(0).FindControl("Sorter_ALLOCATE_STUDENTS_MAXSorter"),DECV_PROD2007.Controls.Sorter)

        item.SUBJECT_InsertHref = "SUBJECT_maint.aspx"
        SUBJECTSUBJECT_Insert.InnerText += item.SUBJECT_Insert.GetFormattedValue().Replace(vbCrLf,"")
        SUBJECTSUBJECT_Insert.HRef = item.SUBJECT_InsertHref+item.SUBJECT_InsertHrefParameters.ToString("GET","SUBJECT_ID", ViewState)
'End Grid Form SUBJECT BeforeShow tail

'Grid SUBJECT Bind tail @6-E31F8E2A
    End Sub
'End Grid SUBJECT Bind tail

'Grid SUBJECT Table Parameters @6-95D38BAA

    Protected Sub SUBJECTParameters()
        Try
            SUBJECTData.Urls_yearlevel = IntegerParameter.GetParam("s_yearlevel", ParameterSourceType.URL, "", -1, false)
            SUBJECTData.Urls_subject_id = IntegerParameter.GetParam("s_subject_id", ParameterSourceType.URL, "", Nothing, false)
            SUBJECTData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
            SUBJECTData.Urls_status = IntegerParameter.GetParam("s_status", ParameterSourceType.URL, "", 1, false)

        Catch
            Dim ParentControls As ControlCollection=SUBJECTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SUBJECTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SUBJECT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SUBJECT Table Parameters

'Grid SUBJECT ItemDataBound event @6-F9662CEA

    Protected Sub SUBJECTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SUBJECTItem = CType(e.Item.DataItem,SUBJECTItem)
        Dim Item as SUBJECTItem = DataItem
        Dim FormDataSource As SUBJECTItem() = CType(SUBJECTRepeater.DataSource, SUBJECTItem())
        Dim SUBJECTDataRows As Integer = FormDataSource.Length
        Dim SUBJECTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SUBJECTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SUBJECTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SUBJECTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim SUBJECTSUBJECT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SUBJECTSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTSTATUS"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTPARENT_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTPARENT_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTLink1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SUBJECTLink1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SUBJECTCORE_YEARLEVELS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTCORE_YEARLEVELS"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTALLOCATE_STUDENTS_MAX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTALLOCATE_STUDENTS_MAX"),System.Web.UI.WebControls.Literal)
            DataItem.SUBJECT_IDHref = "SUBJECT_maint.aspx"
            SUBJECTSUBJECT_ID.HRef = DataItem.SUBJECT_IDHref & DataItem.SUBJECT_IDHrefParameters.ToString("GET","", ViewState)
            DataItem.Link1Href = "StudentSubject_TeacherStats.aspx"
            SUBJECTLink1.HRef = DataItem.Link1Href & DataItem.Link1HrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SUBJECTAlt_SUBJECT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SUBJECTAlt_SUBJECT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SUBJECTAlt_SUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTAlt_SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTAlt_SUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTAlt_SUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTYEAR_LEVEL1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTYEAR_LEVEL1"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTPARENT_SUBJECT_ID1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTPARENT_SUBJECT_ID1"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTLink2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SUBJECTLink2"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SUBJECTCORE_YEARLEVELS1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTCORE_YEARLEVELS1"),System.Web.UI.WebControls.Literal)
            Dim SUBJECTALLOCATE_STUDENTS_MAX1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTALLOCATE_STUDENTS_MAX1"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_SUBJECT_IDHref = "SUBJECT_maint.aspx"
            SUBJECTAlt_SUBJECT_ID.HRef = DataItem.Alt_SUBJECT_IDHref & DataItem.Alt_SUBJECT_IDHrefParameters.ToString("GET","", ViewState)
            DataItem.Link2Href = "StudentSubject_TeacherStats.aspx"
            SUBJECTLink2.HRef = DataItem.Link2Href & DataItem.Link2HrefParameters.ToString("GET","", ViewState)
        End If
'End Grid SUBJECT ItemDataBound event

'SUBJECT control Before Show @6-45B2F0AE
        If e.Item.ItemType = ListItemType.Item Then
'End SUBJECT control Before Show

'Get Control @55-571DE676
            Dim SUBJECTPARENT_SUBJECT_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTPARENT_SUBJECT_ID"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label PARENT_SUBJECT_ID Event BeforeShow. Action Custom Code @245-73254650
    ' -------------------------
    'If -1 then show text for Parent Group
    if (SUBJECTPARENT_SUBJECT_ID.Text = "-1") then
    	SUBJECTPARENT_SUBJECT_ID.Text = "Parent / Group Subject"
    else if (SUBJECTPARENT_SUBJECT_ID.Text = "0") then
		SUBJECTPARENT_SUBJECT_ID.Text = ""
    else
    	SUBJECTPARENT_SUBJECT_ID.Text = "Child of Group Subject"
    end if
    ' -------------------------
'End Label PARENT_SUBJECT_ID Event BeforeShow. Action Custom Code

'SUBJECT control Before Show tail @6-477CF3C9
        End If
'End SUBJECT control Before Show tail

'SUBJECT control Before Show @6-0303C5B0
        If e.Item.ItemType = ListItemType.AlternatingItem Then
'End SUBJECT control Before Show

'Get Control @57-37EDEB74
            Dim SUBJECTPARENT_SUBJECT_ID1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SUBJECTPARENT_SUBJECT_ID1"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label PARENT_SUBJECT_ID1 Event BeforeShow. Action Custom Code @246-73254650
    ' -------------------------
    'If -1 then show text for Parent Group
   if (SUBJECTPARENT_SUBJECT_ID1.Text = "-1") then
    	SUBJECTPARENT_SUBJECT_ID1.Text = "Parent / Group Subject"
    else if (SUBJECTPARENT_SUBJECT_ID1.Text = "0") then
		SUBJECTPARENT_SUBJECT_ID1.Text = ""
    else
    	SUBJECTPARENT_SUBJECT_ID1.Text = "Child of Group Subject"
    end if
    ' -------------------------
'End Label PARENT_SUBJECT_ID1 Event BeforeShow. Action Custom Code

'SUBJECT control Before Show tail @6-477CF3C9
        End If
'End SUBJECT control Before Show tail

'Grid SUBJECT ItemDataBound event tail @6-E43DB7B7
        If SUBJECTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(SUBJECTCurrentRowNumber, ListItemType.AlternatingItem)
                SUBJECTRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(SUBJECTCurrentRowNumber, ListItemType.Item)
                SUBJECTRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            SUBJECTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SUBJECT ItemDataBound event tail

'Grid SUBJECT ItemCommand event @6-0DD9B41C

    Protected Sub SUBJECTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SUBJECTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SUBJECTSortDir"),SortDirections) = SortDirections._Asc And ViewState("SUBJECTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SUBJECTSortDir")=SortDirections._Desc
                Else
                    ViewState("SUBJECTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SUBJECTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SUBJECTDataProvider.SortFields = 0
            ViewState("SUBJECTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SUBJECTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SUBJECTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SUBJECTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SUBJECTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SUBJECTBind
        End If
    End Sub
'End Grid SUBJECT ItemCommand event

'Record Form SUBJECT1 Parameters @41-CDE735D2

    Protected Sub SUBJECT1Parameters()
        Dim item As new SUBJECT1Item
        Try
        Catch e As Exception
            SUBJECT1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SUBJECT1 Parameters

'Record Form SUBJECT1 Show method @41-83C496BF
    Protected Sub SUBJECT1Show()
        If SUBJECT1Operations.None Then
            SUBJECT1Holder.Visible = False
            Return
        End If
        Dim item As SUBJECT1Item = SUBJECT1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SUBJECT1Operations.AllowRead
        item.ClearParametersHref = "SUBJECT_list.aspx"
        SUBJECT1Errors.Add(item.errors)
        If SUBJECT1Errors.Count > 0 Then
            SUBJECT1ShowErrors()
            Return
        End If
'End Record Form SUBJECT1 Show method

'Record Form SUBJECT1 BeforeShow tail @41-E928D60F
        SUBJECT1Parameters()
        SUBJECT1Data.FillItem(item, IsInsertMode)
        SUBJECT1Holder.DataBind()
        SUBJECT1ClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        SUBJECT1ClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword;s_yearlevel;s_status;s_subject_id", ViewState)
        SUBJECT1s_keyword.Text=item.s_keyword.GetFormattedValue()
        SUBJECT1s_yearlevel.Items.Add(new ListItem("Select Value",""))
        SUBJECT1s_yearlevel.Items(0).Selected = True
        item.s_yearlevelItems.SetSelection(item.s_yearlevel.GetFormattedValue())
        If Not item.s_yearlevelItems.GetSelectedItem() Is Nothing Then
            SUBJECT1s_yearlevel.SelectedIndex = -1
        End If
        item.s_yearlevelItems.CopyTo(SUBJECT1s_yearlevel.Items)
        item.s_statusItems.SetSelection(item.s_status.GetFormattedValue())
        SUBJECT1s_status.SelectedIndex = -1
        item.s_statusItems.CopyTo(SUBJECT1s_status.Items)
        SUBJECT1s_subject_id.Text=item.s_subject_id.GetFormattedValue()
'End Record Form SUBJECT1 BeforeShow tail

'Record Form SUBJECT1 Show method tail @41-EEB80F91
        If SUBJECT1Errors.Count > 0 Then
            SUBJECT1ShowErrors()
        End If
    End Sub
'End Record Form SUBJECT1 Show method tail

'Record Form SUBJECT1 LoadItemFromRequest method @41-4F48E8C7

    Protected Sub SUBJECT1LoadItemFromRequest(item As SUBJECT1Item, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(SUBJECT1s_keyword.UniqueID))
        If ControlCustomValues("SUBJECT1s_keyword") Is Nothing Then
            item.s_keyword.SetValue(SUBJECT1s_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("SUBJECT1s_keyword"))
        End If
        item.s_yearlevel.IsEmpty = IsNothing(Request.Form(SUBJECT1s_yearlevel.UniqueID))
        item.s_yearlevel.SetValue(SUBJECT1s_yearlevel.Value)
        item.s_yearlevelItems.CopyFrom(SUBJECT1s_yearlevel.Items)
        Try
        item.s_status.IsEmpty = IsNothing(Request.Form(SUBJECT1s_status.UniqueID))
        If Not IsNothing(SUBJECT1s_status.SelectedItem) Then
            item.s_status.SetValue(SUBJECT1s_status.SelectedItem.Value)
        Else
            item.s_status.Value = Nothing
        End If
        item.s_statusItems.CopyFrom(SUBJECT1s_status.Items)
        Catch ae As ArgumentException
            SUBJECT1Errors.Add("s_status",String.Format(Resources.strings.CCS_IncorrectValue,"s_status"))
        End Try
        item.s_subject_id.IsEmpty = IsNothing(Request.Form(SUBJECT1s_subject_id.UniqueID))
        If ControlCustomValues("SUBJECT1s_subject_id") Is Nothing Then
            item.s_subject_id.SetValue(SUBJECT1s_subject_id.Text)
        Else
            item.s_subject_id.SetValue(ControlCustomValues("SUBJECT1s_subject_id"))
        End If
        If EnableValidation Then
            item.Validate(SUBJECT1Data)
        End If
        SUBJECT1Errors.Add(item.errors)
    End Sub
'End Record Form SUBJECT1 LoadItemFromRequest method

'Record Form SUBJECT1 GetRedirectUrl method @41-842B5965

    Protected Function GetSUBJECT1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "SUBJECT_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SUBJECT1 GetRedirectUrl method

'Record Form SUBJECT1 ShowErrors method @41-F73FA74E

    Protected Sub SUBJECT1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SUBJECT1Errors.Count - 1
        Select Case SUBJECT1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SUBJECT1Errors(i)
        End Select
        Next i
        SUBJECT1Error.Visible = True
        SUBJECT1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SUBJECT1 ShowErrors method

'Record Form SUBJECT1 Insert Operation @41-EB9ABDC4

    Protected Sub SUBJECT1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        SUBJECT1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT1 Insert Operation

'Record Form SUBJECT1 BeforeInsert tail @41-84EAAB6B
    SUBJECT1Parameters()
    SUBJECT1LoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT1 BeforeInsert tail

'Record Form SUBJECT1 AfterInsert tail  @41-F12A9790
        ErrorFlag=(SUBJECT1Errors.Count > 0)
        If ErrorFlag Then
            SUBJECT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT1 AfterInsert tail 

'Record Form SUBJECT1 Update Operation @41-5851F61C

    Protected Sub SUBJECT1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SUBJECT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SUBJECT1 Update Operation

'Record Form SUBJECT1 Before Update tail @41-84EAAB6B
        SUBJECT1Parameters()
        SUBJECT1LoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT1 Before Update tail

'Record Form SUBJECT1 Update Operation tail @41-F12A9790
        ErrorFlag=(SUBJECT1Errors.Count > 0)
        If ErrorFlag Then
            SUBJECT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT1 Update Operation tail

'Record Form SUBJECT1 Delete Operation @41-5D1DBF6E
    Protected Sub SUBJECT1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SUBJECT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SUBJECT1 Delete Operation

'Record Form BeforeDelete tail @41-84EAAB6B
        SUBJECT1Parameters()
        SUBJECT1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @41-13C5565C
        If ErrorFlag Then
            SUBJECT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SUBJECT1 Cancel Operation @41-BD0A713C

    Protected Sub SUBJECT1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        SUBJECT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        SUBJECT1LoadItemFromRequest(item, True)
'End Record Form SUBJECT1 Cancel Operation

'Record Form SUBJECT1 Cancel Operation tail @41-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SUBJECT1 Cancel Operation tail

'Record Form SUBJECT1 Search Operation @41-429F05ED
    Protected Sub SUBJECT1_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SUBJECT1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SUBJECT1Item = New SUBJECT1Item()
        SUBJECT1LoadItemFromRequest(item, EnableValidation)
'End Record Form SUBJECT1 Search Operation

'Button Button_DoSearch OnClick. @43-09A7F210
        If CType(sender,Control).ID = "SUBJECT1Button_DoSearch" Then
            RedirectUrl = GetSUBJECT1RedirectUrl("", "s_keyword;s_yearlevel;s_status;s_subject_id")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @43-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SUBJECT1 Search Operation tail @41-469BFF02
        ErrorFlag = SUBJECT1Errors.Count > 0
        If ErrorFlag Then
            SUBJECT1ShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(SUBJECT1s_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(SUBJECT1s_keyword.Text) & "&"), "")
            For Each li In SUBJECT1s_yearlevel.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_yearlevel=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            For Each li In SUBJECT1s_status.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "s_status=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            Params = Params & IIf(SUBJECT1s_subject_id.Text <> "",("s_subject_id=" & Server.UrlEncode(SUBJECT1s_subject_id.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SUBJECT1 Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-469C0811
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SUBJECT_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SUBJECTData = New SUBJECTDataProvider()
        SUBJECTOperations = New FormSupportedOperations(False, True, False, False, False)
        SUBJECT1Data = New SUBJECT1DataProvider()
        SUBJECT1Operations = New FormSupportedOperations(False, True, True, True, True)
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

