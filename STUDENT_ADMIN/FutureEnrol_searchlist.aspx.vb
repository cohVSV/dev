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

Namespace DECV_PROD2007.FutureEnrol_searchlist 'Namespace @1-BE158E0C

'Forms Definition @1-7BDD24B9
Public Class [FutureEnrol_searchlistPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-D22FC89E
    Protected STUDENT_ENROLMENT_STUDENTData As STUDENT_ENROLMENT_STUDENTDataProvider
    Protected STUDENT_ENROLMENT_STUDENTOperations As FormSupportedOperations
    Protected STUDENT_ENROLMENT_STUDENTCurrentRowNumber As Integer
    Protected STUDENT_ENROLMENT_STUDENT1Data As STUDENT_ENROLMENT_STUDENT1DataProvider
    Protected STUDENT_ENROLMENT_STUDENT1Errors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_ENROLMENT_STUDENT1Operations As FormSupportedOperations
    Protected STUDENT_ENROLMENT_STUDENT1IsSubmitted As Boolean = False
    Protected STUDENTSearchData As STUDENTSearchDataProvider
    Protected STUDENTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENTSearchOperations As FormSupportedOperations
    Protected STUDENTSearchIsSubmitted As Boolean = False
    Protected FutureEnrol_searchlistContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-280391A2
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_ENROLMENT_STUDENTBind
            STUDENT_ENROLMENT_STUDENT1Show()
            STUDENTSearchShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_ENROLMENT_STUDENT Bind @3-78C4D9CE

    Protected Sub STUDENT_ENROLMENT_STUDENTBind()
        If Not STUDENT_ENROLMENT_STUDENTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_ENROLMENT_STUDENT",GetType(STUDENT_ENROLMENT_STUDENTDataProvider.SortFields), 50, 100)
        End If
'End Grid STUDENT_ENROLMENT_STUDENT Bind

'Grid Form STUDENT_ENROLMENT_STUDENT BeforeShow tail @3-DEC68A49
        STUDENT_ENROLMENT_STUDENTParameters()
        STUDENT_ENROLMENT_STUDENTData.SortField = CType(ViewState("STUDENT_ENROLMENT_STUDENTSortField"),STUDENT_ENROLMENT_STUDENTDataProvider.SortFields)
        STUDENT_ENROLMENT_STUDENTData.SortDir = CType(ViewState("STUDENT_ENROLMENT_STUDENTSortDir"),SortDirections)
        STUDENT_ENROLMENT_STUDENTData.PageNumber = CInt(ViewState("STUDENT_ENROLMENT_STUDENTPageNumber"))
        STUDENT_ENROLMENT_STUDENTData.RecordsPerPage = CInt(ViewState("STUDENT_ENROLMENT_STUDENTPageSize"))
        STUDENT_ENROLMENT_STUDENTRepeater.DataSource = STUDENT_ENROLMENT_STUDENTData.GetResultSet(PagesCount, STUDENT_ENROLMENT_STUDENTOperations)
        ViewState("STUDENT_ENROLMENT_STUDENTPagesCount") = PagesCount
        Dim item As STUDENT_ENROLMENT_STUDENTItem = New STUDENT_ENROLMENT_STUDENTItem()
        STUDENT_ENROLMENT_STUDENTRepeater.DataBind
        FooterIndex = STUDENT_ENROLMENT_STUDENTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_ENROLMENT_STUDENTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STUDENT_ENROLMENT_STUDENTSTUDENT_ENROLMENT_STUDENT_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("STUDENT_ENROLMENT_STUDENTSTUDENT_ENROLMENT_STUDENT_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_STUDENT_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_STUDENT_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CATEGORY_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_CATEGORY_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_ENROLMENT_STUDENTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        STUDENT_ENROLMENT_STUDENTSTUDENT_ENROLMENT_STUDENT_TotalRecords.Text = Server.HtmlEncode(item.STUDENT_ENROLMENT_STUDENT_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form STUDENT_ENROLMENT_STUDENT BeforeShow tail

'Label STUDENT_ENROLMENT_STUDENT_TotalRecords Event BeforeShow. Action Retrieve number of records @20-7D71A1FD
            STUDENT_ENROLMENT_STUDENTSTUDENT_ENROLMENT_STUDENT_TotalRecords.Text = STUDENT_ENROLMENT_STUDENTData.RecordCount.ToString()
'End Label STUDENT_ENROLMENT_STUDENT_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid STUDENT_ENROLMENT_STUDENT Bind tail @3-E31F8E2A
    End Sub
'End Grid STUDENT_ENROLMENT_STUDENT Bind tail

'Grid STUDENT_ENROLMENT_STUDENT Table Parameters @3-39E83334

    Protected Sub STUDENT_ENROLMENT_STUDENTParameters()
        Try
            STUDENT_ENROLMENT_STUDENTData.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            STUDENT_ENROLMENT_STUDENTData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_ENROLMENT_STUDENTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_ENROLMENT_STUDENTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_ENROLMENT_STUDENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_ENROLMENT_STUDENT Table Parameters

'Grid STUDENT_ENROLMENT_STUDENT ItemDataBound event @3-7663FD44

    Protected Sub STUDENT_ENROLMENT_STUDENTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_ENROLMENT_STUDENTItem = CType(e.Item.DataItem,STUDENT_ENROLMENT_STUDENTItem)
        Dim Item as STUDENT_ENROLMENT_STUDENTItem = DataItem
        Dim FormDataSource As STUDENT_ENROLMENT_STUDENTItem() = CType(STUDENT_ENROLMENT_STUDENTRepeater.DataSource, STUDENT_ENROLMENT_STUDENTItem())
        Dim STUDENT_ENROLMENT_STUDENTDataRows As Integer = FormDataSource.Length
        Dim STUDENT_ENROLMENT_STUDENTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_ENROLMENT_STUDENTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_ENROLMENT_STUDENTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_ENROLMENT_STUDENTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_ENROLMENT_STUDENTSTUDENT_STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTSTUDENT_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_ENROLMENT_STUDENTFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_ENROLMENT_STUDENTSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTSURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_ENROLMENT_STUDENTCATEGORY_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTCATEGORY_CODE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_ENROLMENT_STUDENTYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_ENROLMENT_STUDENTENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_ENROLMENT_STUDENTENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_ENROLMENT_STUDENTENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_STUDENT_IDHref = "FutureEnrol_StudentMaintain.aspx"
            STUDENT_ENROLMENT_STUDENTSTUDENT_STUDENT_ID.HRef = DataItem.STUDENT_STUDENT_IDHref & DataItem.STUDENT_STUDENT_IDHrefParameters.ToString("GET","s_STUDENT_ID;s_SURNAME", ViewState)
        End If
'End Grid STUDENT_ENROLMENT_STUDENT ItemDataBound event

'Grid STUDENT_ENROLMENT_STUDENT ItemDataBound event tail @3-32376175
        If STUDENT_ENROLMENT_STUDENTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_ENROLMENT_STUDENTCurrentRowNumber, ListItemType.Item)
            STUDENT_ENROLMENT_STUDENTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_ENROLMENT_STUDENTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_ENROLMENT_STUDENT ItemDataBound event tail

'Grid STUDENT_ENROLMENT_STUDENT ItemCommand event @3-7439B9A5

    Protected Sub STUDENT_ENROLMENT_STUDENTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_ENROLMENT_STUDENTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_ENROLMENT_STUDENTSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_ENROLMENT_STUDENTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_ENROLMENT_STUDENTSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_ENROLMENT_STUDENTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_ENROLMENT_STUDENTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_ENROLMENT_STUDENTDataProvider.SortFields = 0
            ViewState("STUDENT_ENROLMENT_STUDENTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_ENROLMENT_STUDENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_ENROLMENT_STUDENTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_ENROLMENT_STUDENTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_ENROLMENT_STUDENTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_ENROLMENT_STUDENTBind
        End If
    End Sub
'End Grid STUDENT_ENROLMENT_STUDENT ItemCommand event

'Record Form STUDENT_ENROLMENT_STUDENT1 Parameters @38-0AD6F974

    Protected Sub STUDENT_ENROLMENT_STUDENT1Parameters()
        Dim item As new STUDENT_ENROLMENT_STUDENT1Item
        Try
        Catch e As Exception
            STUDENT_ENROLMENT_STUDENT1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 Parameters

'Record Form STUDENT_ENROLMENT_STUDENT1 Show method @38-CA5459C5
    Protected Sub STUDENT_ENROLMENT_STUDENT1Show()
        If STUDENT_ENROLMENT_STUDENT1Operations.None Then
            STUDENT_ENROLMENT_STUDENT1Holder.Visible = False
            Return
        End If
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = STUDENT_ENROLMENT_STUDENT1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_ENROLMENT_STUDENT1Operations.AllowRead
        item.ClearParametersHref = "FutureEnrol_searchlist.aspx"
        STUDENT_ENROLMENT_STUDENT1Errors.Add(item.errors)
        If STUDENT_ENROLMENT_STUDENT1Errors.Count > 0 Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
            Return
        End If
'End Record Form STUDENT_ENROLMENT_STUDENT1 Show method

'Record Form STUDENT_ENROLMENT_STUDENT1 BeforeShow tail @38-C1749726
        STUDENT_ENROLMENT_STUDENT1Parameters()
        STUDENT_ENROLMENT_STUDENT1Data.FillItem(item, IsInsertMode)
        STUDENT_ENROLMENT_STUDENT1Holder.DataBind()
        STUDENT_ENROLMENT_STUDENT1ClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_ENROLMENT_STUDENT1ClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_STUDENT_ID;s_SURNAME", ViewState)
        STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
        STUDENT_ENROLMENT_STUDENT1s_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
'End Record Form STUDENT_ENROLMENT_STUDENT1 BeforeShow tail

'Record Form STUDENT_ENROLMENT_STUDENT1 Show method tail @38-4547084C
        If STUDENT_ENROLMENT_STUDENT1Errors.Count > 0 Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 Show method tail

'Record Form STUDENT_ENROLMENT_STUDENT1 LoadItemFromRequest method @38-12EB9CB1

    Protected Sub STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item As STUDENT_ENROLMENT_STUDENT1Item, ByVal EnableValidation As Boolean)
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            STUDENT_ENROLMENT_STUDENT1Errors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_ENROLMENT_STUDENT1s_SURNAME.UniqueID))
        If ControlCustomValues("STUDENT_ENROLMENT_STUDENT1s_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(STUDENT_ENROLMENT_STUDENT1s_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("STUDENT_ENROLMENT_STUDENT1s_SURNAME"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_ENROLMENT_STUDENT1Data)
        End If
        STUDENT_ENROLMENT_STUDENT1Errors.Add(item.errors)
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 LoadItemFromRequest method

'Record Form STUDENT_ENROLMENT_STUDENT1 GetRedirectUrl method @38-72AE2941

    Protected Function GetSTUDENT_ENROLMENT_STUDENT1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FutureEnrol_searchlist.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_ENROLMENT_STUDENT1 GetRedirectUrl method

'Record Form STUDENT_ENROLMENT_STUDENT1 ShowErrors method @38-D29B8C6E

    Protected Sub STUDENT_ENROLMENT_STUDENT1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_ENROLMENT_STUDENT1Errors.Count - 1
        Select Case STUDENT_ENROLMENT_STUDENT1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_ENROLMENT_STUDENT1Errors(i)
        End Select
        Next i
        STUDENT_ENROLMENT_STUDENT1Error.Visible = True
        STUDENT_ENROLMENT_STUDENT1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 ShowErrors method

'Record Form STUDENT_ENROLMENT_STUDENT1 Insert Operation @38-4927E1AB

    Protected Sub STUDENT_ENROLMENT_STUDENT1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        STUDENT_ENROLMENT_STUDENT1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT_STUDENT1 Insert Operation

'Record Form STUDENT_ENROLMENT_STUDENT1 BeforeInsert tail @38-31D16360
    STUDENT_ENROLMENT_STUDENT1Parameters()
    STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_ENROLMENT_STUDENT1 BeforeInsert tail

'Record Form STUDENT_ENROLMENT_STUDENT1 AfterInsert tail  @38-58ED7003
        ErrorFlag=(STUDENT_ENROLMENT_STUDENT1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 AfterInsert tail 

'Record Form STUDENT_ENROLMENT_STUDENT1 Update Operation @38-FE4E8EF5

    Protected Sub STUDENT_ENROLMENT_STUDENT1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENT_STUDENT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_ENROLMENT_STUDENT1 Update Operation

'Record Form STUDENT_ENROLMENT_STUDENT1 Before Update tail @38-31D16360
        STUDENT_ENROLMENT_STUDENT1Parameters()
        STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_ENROLMENT_STUDENT1 Before Update tail

'Record Form STUDENT_ENROLMENT_STUDENT1 Update Operation tail @38-58ED7003
        ErrorFlag=(STUDENT_ENROLMENT_STUDENT1Errors.Count > 0)
        If ErrorFlag Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 Update Operation tail

'Record Form STUDENT_ENROLMENT_STUDENT1 Delete Operation @38-FD597A3B
    Protected Sub STUDENT_ENROLMENT_STUDENT1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_ENROLMENT_STUDENT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_ENROLMENT_STUDENT1 Delete Operation

'Record Form BeforeDelete tail @38-31D16360
        STUDENT_ENROLMENT_STUDENT1Parameters()
        STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @38-0B864BBF
        If ErrorFlag Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_ENROLMENT_STUDENT1 Cancel Operation @38-EC4AFC1A

    Protected Sub STUDENT_ENROLMENT_STUDENT1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        STUDENT_ENROLMENT_STUDENT1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item, True)
'End Record Form STUDENT_ENROLMENT_STUDENT1 Cancel Operation

'Record Form STUDENT_ENROLMENT_STUDENT1 Cancel Operation tail @38-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 Cancel Operation tail

'Record Form STUDENT_ENROLMENT_STUDENT1 Search Operation @38-6B68A78C
    Protected Sub STUDENT_ENROLMENT_STUDENT1_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STUDENT_ENROLMENT_STUDENT1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STUDENT_ENROLMENT_STUDENT1Item = New STUDENT_ENROLMENT_STUDENT1Item()
        STUDENT_ENROLMENT_STUDENT1LoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_ENROLMENT_STUDENT1 Search Operation

'Button Button_DoSearch OnClick. @40-B8EACF56
        If CType(sender,Control).ID = "STUDENT_ENROLMENT_STUDENT1Button_DoSearch" Then
            RedirectUrl = GetSTUDENT_ENROLMENT_STUDENT1RedirectUrl("", "s_STUDENT_ID;s_SURNAME")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @40-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENT_ENROLMENT_STUDENT1 Search Operation tail @38-8EF58DB5
        ErrorFlag = STUDENT_ENROLMENT_STUDENT1Errors.Count > 0
        If ErrorFlag Then
            STUDENT_ENROLMENT_STUDENT1ShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(STUDENT_ENROLMENT_STUDENT1s_STUDENT_ID.Text) & "&"), "")
            Params = Params & IIf(STUDENT_ENROLMENT_STUDENT1s_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(STUDENT_ENROLMENT_STUDENT1s_SURNAME.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_ENROLMENT_STUDENT1 Search Operation tail

'Record Form STUDENTSearch Parameters @10-6DC6F117

    Protected Sub STUDENTSearchParameters()
        Dim item As new STUDENTSearchItem
        Try
            STUDENTSearchData.Ctrls_SURNAME = TextParameter.GetParam(item.s_SURNAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENTSearchData.Ctrls_FIRST_NAME = TextParameter.GetParam(item.s_FIRST_NAME.Value, ParameterSourceType.Control, "", Nothing, false)
            STUDENTSearchData.Ctrls_BIRTH_DATE = DateParameter.GetParam(item.s_BIRTH_DATE.Value, ParameterSourceType.Control, "dd\/MM\/yyyy", Nothing, false)
            STUDENTSearchData.Expr93 = TextParameter.GetParam("U", ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr94 = TextParameter.GetParam("OTHER", ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr95 = TextParameter.GetParam("OTHER", ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr96 = FloatParameter.GetParam("16261.00", ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr97 = FloatParameter.GetParam(263, ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr98 = BooleanParameter.GetParam(0, ParameterSourceType.Expression, Settings.BoolFormat, Nothing, false)
            STUDENTSearchData.Expr99 = BooleanParameter.GetParam(0, ParameterSourceType.Expression, Settings.BoolFormat, Nothing, false)
            STUDENTSearchData.Expr100 = BooleanParameter.GetParam(0, ParameterSourceType.Expression, Settings.BoolFormat, Nothing, false)
            STUDENTSearchData.Expr101 = TextParameter.GetParam(DBUtility.UserID.ToUpper, ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr102 = DateParameter.GetParam(Now(), ParameterSourceType.Expression, Settings.DateFormat, Nothing, false)
            STUDENTSearchData.Expr103 = TextParameter.GetParam("N", ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr104 = TextParameter.GetParam(0, ParameterSourceType.Expression, "", Nothing, false)
            STUDENTSearchData.Expr106 = FloatParameter.GetParam("16261.00", ParameterSourceType.Expression, "", Nothing, false)
        Catch e As Exception
            STUDENTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENTSearch Parameters

'Record Form STUDENTSearch Show method @10-CAB5E5FC
    Protected Sub STUDENTSearchShow()
        If STUDENTSearchOperations.None Then
            STUDENTSearchHolder.Visible = False
            Return
        End If
        Dim item As STUDENTSearchItem = STUDENTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENTSearchOperations.AllowRead
        STUDENTSearchErrors.Add(item.errors)
        If STUDENTSearchErrors.Count > 0 Then
            STUDENTSearchShowErrors()
            Return
        End If
'End Record Form STUDENTSearch Show method

'Record Form STUDENTSearch BeforeShow tail @10-C848A17D
        STUDENTSearchParameters()
        STUDENTSearchData.FillItem(item, IsInsertMode)
        STUDENTSearchHolder.DataBind()
        STUDENTSearchButton_DoSearch.Visible=IsInsertMode AndAlso STUDENTSearchOperations.AllowInsert
        STUDENTSearchs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
        STUDENTSearchs_FIRST_NAME.Text=item.s_FIRST_NAME.GetFormattedValue()
        STUDENTSearchs_BIRTH_DATE.Text=item.s_BIRTH_DATE.GetFormattedValue()
        STUDENTSearchs_ENROL_YEAR.Text=item.s_ENROL_YEAR.GetFormattedValue()
        STUDENTSearchHidden_NewStudentID.Value = item.Hidden_NewStudentID.GetFormattedValue()
'End Record Form STUDENTSearch BeforeShow tail

'TextBox s_ENROL_YEAR Event BeforeShow. Action Custom Code @86-73254650
    ' -------------------------
    'Get Enrol Year depending on when in current year
    STUDENTSearchs_ENROL_YEAR.Text = DateTime.Today.Year + 1
    if (DateTime.Today.Month < 9) then
    	STUDENTSearchs_ENROL_YEAR.Text = DateTime.Today.Year
    end if
    
    ' -------------------------
'End TextBox s_ENROL_YEAR Event BeforeShow. Action Custom Code

'Record Form STUDENTSearch Show method tail @10-3D876956
        If STUDENTSearchErrors.Count > 0 Then
            STUDENTSearchShowErrors()
        End If
    End Sub
'End Record Form STUDENTSearch Show method tail

'Record Form STUDENTSearch LoadItemFromRequest method @10-5D565780

    Protected Sub STUDENTSearchLoadItemFromRequest(item As STUDENTSearchItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_SURNAME.UniqueID))
        If ControlCustomValues("STUDENTSearchs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(STUDENTSearchs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("STUDENTSearchs_SURNAME"))
        End If
        item.s_FIRST_NAME.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_FIRST_NAME.UniqueID))
        If ControlCustomValues("STUDENTSearchs_FIRST_NAME") Is Nothing Then
            item.s_FIRST_NAME.SetValue(STUDENTSearchs_FIRST_NAME.Text)
        Else
            item.s_FIRST_NAME.SetValue(ControlCustomValues("STUDENTSearchs_FIRST_NAME"))
        End If
        Try
        item.s_BIRTH_DATE.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_BIRTH_DATE.UniqueID))
        If ControlCustomValues("STUDENTSearchs_BIRTH_DATE") Is Nothing Then
            item.s_BIRTH_DATE.SetValue(STUDENTSearchs_BIRTH_DATE.Text)
        Else
            item.s_BIRTH_DATE.SetValue(ControlCustomValues("STUDENTSearchs_BIRTH_DATE"))
        End If
        Catch ae As ArgumentException
            STUDENTSearchErrors.Add("s_BIRTH_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Birth Date","dd/mm/yyyy"))
        End Try
        Try
        item.s_ENROL_YEAR.IsEmpty = IsNothing(Request.Form(STUDENTSearchs_ENROL_YEAR.UniqueID))
        If ControlCustomValues("STUDENTSearchs_ENROL_YEAR") Is Nothing Then
            item.s_ENROL_YEAR.SetValue(STUDENTSearchs_ENROL_YEAR.Text)
        Else
            item.s_ENROL_YEAR.SetValue(ControlCustomValues("STUDENTSearchs_ENROL_YEAR"))
        End If
        Catch ae As ArgumentException
            STUDENTSearchErrors.Add("s_ENROL_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"s_ENROL_YEAR"))
        End Try
        item.Hidden_NewStudentID.IsEmpty = IsNothing(Request.Form(STUDENTSearchHidden_NewStudentID.UniqueID))
        item.Hidden_NewStudentID.SetValue(STUDENTSearchHidden_NewStudentID.Value)
        If EnableValidation Then
            item.Validate(STUDENTSearchData)
        End If
        STUDENTSearchErrors.Add(item.errors)
    End Sub
'End Record Form STUDENTSearch LoadItemFromRequest method

'Record Form STUDENTSearch GetRedirectUrl method @10-1C0B0A7E

    Protected Function GetSTUDENTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FutureEnrol_StudentMaintain.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENTSearch GetRedirectUrl method

'Record Form STUDENTSearch ShowErrors method @10-1C937A91

    Protected Sub STUDENTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENTSearchErrors.Count - 1
        Select Case STUDENTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENTSearchErrors(i)
        End Select
        Next i
        STUDENTSearchError.Visible = True
        STUDENTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENTSearch ShowErrors method

'Record Form STUDENTSearch Insert Operation @10-1CFBB8DD

    Protected Sub STUDENTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        Dim ExecuteFlag As Boolean = True
        STUDENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENTSearch Insert Operation

'Button Button_DoSearch OnClick. @11-EB7254F2
        If CType(sender,Control).ID = "STUDENTSearchButton_DoSearch" Then
            RedirectUrl = GetSTUDENTSearchRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @11-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENTSearch BeforeInsert tail @10-61535513
    STUDENTSearchParameters()
    STUDENTSearchLoadItemFromRequest(item, EnableValidation)
    If STUDENTSearchOperations.AllowInsert Then
        ErrorFlag=(STUDENTSearchErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STUDENTSearchData.InsertItem(item)
            Catch ex As Exception
                STUDENTSearchErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STUDENTSearch BeforeInsert tail

'Record STUDENTSearch Event AfterInsert. Action Custom Code @87-73254650
    ' -------------------------
    ' Dec-2018|EA| redirectondone if ExprKey1 =1 then Ok and get ExprKey8, if < 0 then error
    ' bkmk
    'response.write(STUDENTSearchData.ExprKey1)
    'HttpContext.Current.Session("notifymessage") = STUDENTSearchData.ExprKey8.Value()
    
'	if (STUDENTSearchData.ExprKey1.GetValue() > 0) then
'		' should be student ID, so add parameters STUDENT_ID ExprKey8 and ENROLMENT_YEAR item.s_ENROL_YEAR to redirect
'		Dim params As New LinkParameterCollection()
'	    params.Add("STUDENT_ID", STUDENTSearchData.ExprKey8.Value)
'	    params.Add("ENROLMENT_YEAR", STUDENTSearchs_ENROL_YEAR.Text)
'		RedirectUrl += params.ToString()
'	else
		' some error so show message as error
'		STUDENTSearchErrors.Add("DataProvider",STUDENTSearchData.ExprKey8.Value())
'		ErrorFlag = True
'	end if
    ' -------------------------
'End Record STUDENTSearch Event AfterInsert. Action Custom Code

'Record STUDENTSearch Event AfterInsert. Action Custom Code @89-73254650
    ' -------------------------
    ' Dec-2018|EA| using Table Insert as procs where too bloody hard to set up
    dim tmpNewStudentID as string = CType((New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT IDENT_CURRENT('STUDENT')"))).Value, String)
    if (tmpNewStudentID <> "") then
		' pass into Proc to create other stubs as needed
		dim stubProc as string = ""
		stubProc = "exec [dbo].[spi_FutureEnrolment_AddStudent_stubs] " + tmpNewStudentID + ", " + STUDENTSearchs_ENROL_YEAR.Text + ", 'F', '" + DBUtility.UserID.ToUpper + "'"
		dim stubReturn as integer = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteNonQuery(stubProc)
    	    	
		' should be student ID, so add parameters STUDENT_ID ExprKey8 and ENROLMENT_YEAR item.s_ENROL_YEAR to redirect
		Dim params As New LinkParameterCollection()
	    params.Add("STUDENT_ID", tmpNewStudentID)
	    params.Add("ENROLMENT_YEAR", STUDENTSearchs_ENROL_YEAR.Text)
		RedirectUrl = RedirectUrl.TrimEnd(CChar("?")) + params.ToString()
	else
		STUDENTSearchErrors.Add("Form","Something went wrong adding Student")
		STUDENTSearchErrors.Add("Form",tmpNewStudentID)
		
    end if
    ' -------------------------
'End Record STUDENTSearch Event AfterInsert. Action Custom Code

'Record Form STUDENTSearch AfterInsert tail  @10-9106AF45
        End If
        ErrorFlag=(STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENTSearch AfterInsert tail 

'Record Form STUDENTSearch Update Operation @10-49C7EA22

    Protected Sub STUDENTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENTSearch Update Operation

'Record Form STUDENTSearch Before Update tail @10-90C102AB
        STUDENTSearchParameters()
        STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENTSearch Before Update tail

'Record Form STUDENTSearch Update Operation tail @10-66E9745E
        ErrorFlag=(STUDENTSearchErrors.Count > 0)
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENTSearch Update Operation tail

'Record Form STUDENTSearch Delete Operation @10-268559B4
    Protected Sub STUDENTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENTSearch Delete Operation

'Record Form BeforeDelete tail @10-90C102AB
        STUDENTSearchParameters()
        STUDENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @10-12F51A07
        If ErrorFlag Then
            STUDENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENTSearch Cancel Operation @10-0DAF015A

    Protected Sub STUDENTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENTSearchItem = New STUDENTSearchItem()
        STUDENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENTSearchLoadItemFromRequest(item, True)
'End Record Form STUDENTSearch Cancel Operation

'Record Form STUDENTSearch Cancel Operation tail @10-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENTSearch Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-4E63CCE5
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FutureEnrol_searchlistContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_ENROLMENT_STUDENTData = New STUDENT_ENROLMENT_STUDENTDataProvider()
        STUDENT_ENROLMENT_STUDENTOperations = New FormSupportedOperations(False, True, False, False, False)
        STUDENT_ENROLMENT_STUDENT1Data = New STUDENT_ENROLMENT_STUDENT1DataProvider()
        STUDENT_ENROLMENT_STUDENT1Operations = New FormSupportedOperations(False, True, True, True, True)
        STUDENTSearchData = New STUDENTSearchDataProvider()
        STUDENTSearchOperations = New FormSupportedOperations(False, False, True, False, False)
        If Not(DBUtility.AuthorizeUser(New String(){"2","3","4","6","9","11"})) Then
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

