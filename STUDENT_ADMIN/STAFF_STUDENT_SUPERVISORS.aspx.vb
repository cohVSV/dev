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

Namespace DECV_PROD2007.STAFF_STUDENT_SUPERVISORS 'Namespace @1-4F516B54

'Forms Definition @1-D630101D
Public Class [STAFF_STUDENT_SUPERVISORSPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2405832F
    Protected STAFF_STUDENT_SUPERVISORSData As STAFF_STUDENT_SUPERVISORSDataProvider
    Protected STAFF_STUDENT_SUPERVISORSOperations As FormSupportedOperations
    Protected STAFF_STUDENT_SUPERVISORSCurrentRowNumber As Integer
    Protected STAFF_STUDENT_SUPERVISORSSearchData As STAFF_STUDENT_SUPERVISORSSearchDataProvider
    Protected STAFF_STUDENT_SUPERVISORSSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STAFF_STUDENT_SUPERVISORSSearchOperations As FormSupportedOperations
    Protected STAFF_STUDENT_SUPERVISORSSearchIsSubmitted As Boolean = False
    Protected STAFF_STUDENT_SUPERVISORS1Data As STAFF_STUDENT_SUPERVISORS1DataProvider
    Protected STAFF_STUDENT_SUPERVISORS1Errors As NameValueCollection = New NameValueCollection()
    Protected STAFF_STUDENT_SUPERVISORS1Operations As FormSupportedOperations
    Protected STAFF_STUDENT_SUPERVISORS1IsSubmitted As Boolean = False
    Protected STAFF_STUDENT_SUPERVISORSContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B6E8C027
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.STAFF_STUDENT_SUPERVISORS_InsertHref = "STAFF_STUDENT_SUPERVISORS.aspx"
            item.STAFF_STUDENT_SUPERVISORS_InsertHrefParameters.Add("showEdit",System.Web.HttpUtility.UrlEncode((1).ToString()))
            PageData.FillItem(item)
            STAFF_STUDENT_SUPERVISORS_Insert.InnerText += item.STAFF_STUDENT_SUPERVISORS_Insert.GetFormattedValue().Replace(vbCrLf,"")
            STAFF_STUDENT_SUPERVISORS_Insert.HRef = item.STAFF_STUDENT_SUPERVISORS_InsertHref+item.STAFF_STUDENT_SUPERVISORS_InsertHrefParameters.ToString("GET","id", ViewState)
            STAFF_STUDENT_SUPERVISORS_Insert.DataBind()
            STAFF_STUDENT_SUPERVISORSBind
            STAFF_STUDENT_SUPERVISORSSearchShow()
            STAFF_STUDENT_SUPERVISORS1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STAFF_STUDENT_SUPERVISORS Bind @4-771AE06A

    Protected Sub STAFF_STUDENT_SUPERVISORSBind()
        If Not STAFF_STUDENT_SUPERVISORSOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF_STUDENT_SUPERVISORS",GetType(STAFF_STUDENT_SUPERVISORSDataProvider.SortFields), 30, 100)
        End If
'End Grid STAFF_STUDENT_SUPERVISORS Bind

'Grid Form STAFF_STUDENT_SUPERVISORS BeforeShow tail @4-54B111BD
        STAFF_STUDENT_SUPERVISORSParameters()
        STAFF_STUDENT_SUPERVISORSData.SortField = CType(ViewState("STAFF_STUDENT_SUPERVISORSSortField"),STAFF_STUDENT_SUPERVISORSDataProvider.SortFields)
        STAFF_STUDENT_SUPERVISORSData.SortDir = CType(ViewState("STAFF_STUDENT_SUPERVISORSSortDir"),SortDirections)
        STAFF_STUDENT_SUPERVISORSData.PageNumber = CInt(ViewState("STAFF_STUDENT_SUPERVISORSPageNumber"))
        STAFF_STUDENT_SUPERVISORSData.RecordsPerPage = CInt(ViewState("STAFF_STUDENT_SUPERVISORSPageSize"))
        STAFF_STUDENT_SUPERVISORSRepeater.DataSource = STAFF_STUDENT_SUPERVISORSData.GetResultSet(PagesCount, STAFF_STUDENT_SUPERVISORSOperations)
        ViewState("STAFF_STUDENT_SUPERVISORSPagesCount") = PagesCount
        Dim item As STAFF_STUDENT_SUPERVISORSItem = New STAFF_STUDENT_SUPERVISORSItem()
        STAFF_STUDENT_SUPERVISORSRepeater.DataBind
        FooterIndex = STAFF_STUDENT_SUPERVISORSRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STAFF_STUDENT_SUPERVISORSRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(FooterIndex).FindControl("STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUPERVISOR_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_SUPERVISOR_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUPERVISOR_EMAILSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_SUPERVISOR_EMAILSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUPERVISOR_PHONESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_SUPERVISOR_PHONESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFF_STUDENT_SUPERVISORSRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.STAFF_STUDENT_SUPERVISORS_InsertHref = "STAFF_STUDENT_SUPERVISORS.aspx"
        item.STAFF_STUDENT_SUPERVISORS_InsertHrefParameters.Add("showEdit",System.Web.HttpUtility.UrlEncode((1).ToString()))
        STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_Insert.InnerText += item.STAFF_STUDENT_SUPERVISORS_Insert.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_Insert.HRef = item.STAFF_STUDENT_SUPERVISORS_InsertHref+item.STAFF_STUDENT_SUPERVISORS_InsertHrefParameters.ToString("GET","id", ViewState)
        STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_TotalRecords.Text = Server.HtmlEncode(item.STAFF_STUDENT_SUPERVISORS_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form STAFF_STUDENT_SUPERVISORS BeforeShow tail

'Label STAFF_STUDENT_SUPERVISORS_TotalRecords Event BeforeShow. Action Retrieve number of records @12-89C2DB28
            STAFF_STUDENT_SUPERVISORSSTAFF_STUDENT_SUPERVISORS_TotalRecords.Text = STAFF_STUDENT_SUPERVISORSData.RecordCount.ToString()
'End Label STAFF_STUDENT_SUPERVISORS_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid STAFF_STUDENT_SUPERVISORS Bind tail @4-E31F8E2A
    End Sub
'End Grid STAFF_STUDENT_SUPERVISORS Bind tail

'Grid STAFF_STUDENT_SUPERVISORS Table Parameters @4-D6E45E88

    Protected Sub STAFF_STUDENT_SUPERVISORSParameters()
        Try
            STAFF_STUDENT_SUPERVISORSData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STAFF_STUDENT_SUPERVISORSRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STAFF_STUDENT_SUPERVISORSRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STAFF_STUDENT_SUPERVISORS: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STAFF_STUDENT_SUPERVISORS Table Parameters

'Grid STAFF_STUDENT_SUPERVISORS ItemDataBound event @4-926995DA

    Protected Sub STAFF_STUDENT_SUPERVISORSItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STAFF_STUDENT_SUPERVISORSItem = CType(e.Item.DataItem,STAFF_STUDENT_SUPERVISORSItem)
        Dim Item as STAFF_STUDENT_SUPERVISORSItem = DataItem
        Dim FormDataSource As STAFF_STUDENT_SUPERVISORSItem() = CType(STAFF_STUDENT_SUPERVISORSRepeater.DataSource, STAFF_STUDENT_SUPERVISORSItem())
        Dim STAFF_STUDENT_SUPERVISORSDataRows As Integer = FormDataSource.Length
        Dim STAFF_STUDENT_SUPERVISORSIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFF_STUDENT_SUPERVISORSCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STAFF_STUDENT_SUPERVISORSRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFF_STUDENT_SUPERVISORSCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STAFF_STUDENT_SUPERVISORSDetail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSDetail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STAFF_STUDENT_SUPERVISORSYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSSUPERVISOR_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSSUPERVISOR_NAME"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSSUPERVISOR_EMAIL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSSUPERVISOR_EMAIL"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSSUPERVISOR_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSSUPERVISOR_PHONE"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSSTATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STAFF_STUDENT_SUPERVISORSLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "STAFF_STUDENT_SUPERVISORS.aspx"
            DataItem.DetailHrefParameters.Add("showEdit",System.Web.HttpUtility.UrlEncode((1).ToString()))
            STAFF_STUDENT_SUPERVISORSDetail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF_STUDENT_SUPERVISORS ItemDataBound event

'Grid STAFF_STUDENT_SUPERVISORS BeforeShowRow event @4-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STAFF_STUDENT_SUPERVISORS BeforeShowRow event

'Grid STAFF_STUDENT_SUPERVISORS Event BeforeShowRow. Action Custom Code @65-73254650
			' -------------------------
			' ERA: if yearlevel zero then change display to 'Prep' for niceness
			Dim STAFF_STUDENT_SUPERVISORSYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFF_STUDENT_SUPERVISORSYEAR_LEVEL"),System.Web.UI.WebControls.Literal)
			if (STAFF_STUDENT_SUPERVISORSYEAR_LEVEL.Text = "0") then
				STAFF_STUDENT_SUPERVISORSYEAR_LEVEL.Text = "Prep"
			end if
			' -------------------------
'End Grid STAFF_STUDENT_SUPERVISORS Event BeforeShowRow. Action Custom Code

'Grid STAFF_STUDENT_SUPERVISORS BeforeShowRow event tail @4-477CF3C9
        End If
'End Grid STAFF_STUDENT_SUPERVISORS BeforeShowRow event tail



'Grid STAFF_STUDENT_SUPERVISORS ItemDataBound event tail @4-5A65F331
        If STAFF_STUDENT_SUPERVISORSIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STAFF_STUDENT_SUPERVISORSCurrentRowNumber, ListItemType.Item)
            STAFF_STUDENT_SUPERVISORSRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STAFF_STUDENT_SUPERVISORSItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STAFF_STUDENT_SUPERVISORS ItemDataBound event tail

'Grid STAFF_STUDENT_SUPERVISORS ItemCommand event @4-878B25C4

    Protected Sub STAFF_STUDENT_SUPERVISORSItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STAFF_STUDENT_SUPERVISORSRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STAFF_STUDENT_SUPERVISORSSortDir"),SortDirections) = SortDirections._Asc And ViewState("STAFF_STUDENT_SUPERVISORSSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STAFF_STUDENT_SUPERVISORSSortDir")=SortDirections._Desc
                Else
                    ViewState("STAFF_STUDENT_SUPERVISORSSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STAFF_STUDENT_SUPERVISORSSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STAFF_STUDENT_SUPERVISORSDataProvider.SortFields = 0
            ViewState("STAFF_STUDENT_SUPERVISORSSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STAFF_STUDENT_SUPERVISORSPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STAFF_STUDENT_SUPERVISORSPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STAFF_STUDENT_SUPERVISORSPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFF_STUDENT_SUPERVISORSPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STAFF_STUDENT_SUPERVISORSBind
        End If
    End Sub
'End Grid STAFF_STUDENT_SUPERVISORS ItemCommand event

'Record Form STAFF_STUDENT_SUPERVISORSSearch Parameters @5-A6173885

    Protected Sub STAFF_STUDENT_SUPERVISORSSearchParameters()
        Dim item As new STAFF_STUDENT_SUPERVISORSSearchItem
        Try
        Catch e As Exception
            STAFF_STUDENT_SUPERVISORSSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Parameters

'Record Form STAFF_STUDENT_SUPERVISORSSearch Show method @5-EAC8C086
    Protected Sub STAFF_STUDENT_SUPERVISORSSearchShow()
        If STAFF_STUDENT_SUPERVISORSSearchOperations.None Then
            STAFF_STUDENT_SUPERVISORSSearchHolder.Visible = False
            Return
        End If
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = STAFF_STUDENT_SUPERVISORSSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_STUDENT_SUPERVISORSSearchOperations.AllowRead
        item.ClearParametersHref = "STAFF_STUDENT_SUPERVISORS.aspx"
        STAFF_STUDENT_SUPERVISORSSearchErrors.Add(item.errors)
        If STAFF_STUDENT_SUPERVISORSSearchErrors.Count > 0 Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
            Return
        End If
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Show method

'Record Form STAFF_STUDENT_SUPERVISORSSearch BeforeShow tail @5-DC982FDE
        STAFF_STUDENT_SUPERVISORSSearchParameters()
        STAFF_STUDENT_SUPERVISORSSearchData.FillItem(item, IsInsertMode)
        STAFF_STUDENT_SUPERVISORSSearchHolder.DataBind()
        STAFF_STUDENT_SUPERVISORSSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        STAFF_STUDENT_SUPERVISORSSearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        STAFF_STUDENT_SUPERVISORSSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form STAFF_STUDENT_SUPERVISORSSearch BeforeShow tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch Show method tail @5-546CA1B6
        If STAFF_STUDENT_SUPERVISORSSearchErrors.Count > 0 Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Show method tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch LoadItemFromRequest method @5-6D0E12FB

    Protected Sub STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item As STAFF_STUDENT_SUPERVISORSSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORSSearchs_keyword.UniqueID))
        If ControlCustomValues("STAFF_STUDENT_SUPERVISORSSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(STAFF_STUDENT_SUPERVISORSSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("STAFF_STUDENT_SUPERVISORSSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(STAFF_STUDENT_SUPERVISORSSearchData)
        End If
        STAFF_STUDENT_SUPERVISORSSearchErrors.Add(item.errors)
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch LoadItemFromRequest method

'Record Form STAFF_STUDENT_SUPERVISORSSearch GetRedirectUrl method @5-B6CB8005

    Protected Function GetSTAFF_STUDENT_SUPERVISORSSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "STAFF_STUDENT_SUPERVISORS.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_STUDENT_SUPERVISORSSearch GetRedirectUrl method

'Record Form STAFF_STUDENT_SUPERVISORSSearch ShowErrors method @5-F3F37AB9

    Protected Sub STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_STUDENT_SUPERVISORSSearchErrors.Count - 1
        Select Case STAFF_STUDENT_SUPERVISORSSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_STUDENT_SUPERVISORSSearchErrors(i)
        End Select
        Next i
        STAFF_STUDENT_SUPERVISORSSearchError.Visible = True
        STAFF_STUDENT_SUPERVISORSSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch ShowErrors method

'Record Form STAFF_STUDENT_SUPERVISORSSearch Insert Operation @5-D2B177BE

    Protected Sub STAFF_STUDENT_SUPERVISORSSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
        STAFF_STUDENT_SUPERVISORSSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Insert Operation

'Record Form STAFF_STUDENT_SUPERVISORSSearch BeforeInsert tail @5-76D151E3
    STAFF_STUDENT_SUPERVISORSSearchParameters()
    STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_STUDENT_SUPERVISORSSearch BeforeInsert tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch AfterInsert tail  @5-F3C719E0
        ErrorFlag=(STAFF_STUDENT_SUPERVISORSSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch AfterInsert tail 

'Record Form STAFF_STUDENT_SUPERVISORSSearch Update Operation @5-0EF9E3E4

    Protected Sub STAFF_STUDENT_SUPERVISORSSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STAFF_STUDENT_SUPERVISORSSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Update Operation

'Record Form STAFF_STUDENT_SUPERVISORSSearch Before Update tail @5-76D151E3
        STAFF_STUDENT_SUPERVISORSSearchParameters()
        STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Before Update tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch Update Operation tail @5-F3C719E0
        ErrorFlag=(STAFF_STUDENT_SUPERVISORSSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Update Operation tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch Delete Operation @5-03851C57
    Protected Sub STAFF_STUDENT_SUPERVISORSSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFF_STUDENT_SUPERVISORSSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Delete Operation

'Record Form BeforeDelete tail @5-76D151E3
        STAFF_STUDENT_SUPERVISORSSearchParameters()
        STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @5-C3A02D61
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch Cancel Operation @5-0D0B167B

    Protected Sub STAFF_STUDENT_SUPERVISORSSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
        STAFF_STUDENT_SUPERVISORSSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item, True)
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Cancel Operation

'Record Form STAFF_STUDENT_SUPERVISORSSearch Cancel Operation tail @5-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Cancel Operation tail

'Record Form STAFF_STUDENT_SUPERVISORSSearch Search Operation @5-BEC657F4
    Protected Sub STAFF_STUDENT_SUPERVISORSSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STAFF_STUDENT_SUPERVISORSSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STAFF_STUDENT_SUPERVISORSSearchItem = New STAFF_STUDENT_SUPERVISORSSearchItem()
        STAFF_STUDENT_SUPERVISORSSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Search Operation

'Button Button_DoSearch OnClick. @7-C740713D
        If CType(sender,Control).ID = "STAFF_STUDENT_SUPERVISORSSearchButton_DoSearch" Then
            RedirectUrl = GetSTAFF_STUDENT_SUPERVISORSSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @7-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STAFF_STUDENT_SUPERVISORSSearch Search Operation tail @5-04A4F22E
        ErrorFlag = STAFF_STUDENT_SUPERVISORSSearchErrors.Count > 0
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORSSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STAFF_STUDENT_SUPERVISORSSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(STAFF_STUDENT_SUPERVISORSSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORSSearch Search Operation tail

'Record Form STAFF_STUDENT_SUPERVISORS1 Parameters @40-A1BA8772

    Protected Sub STAFF_STUDENT_SUPERVISORS1Parameters()
        Dim item As new STAFF_STUDENT_SUPERVISORS1Item
        Try
            STAFF_STUDENT_SUPERVISORS1Data.Urlid = IntegerParameter.GetParam("id", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            STAFF_STUDENT_SUPERVISORS1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 Parameters

'Record Form STAFF_STUDENT_SUPERVISORS1 Show method @40-BE0C3C36
    Protected Sub STAFF_STUDENT_SUPERVISORS1Show()
        If STAFF_STUDENT_SUPERVISORS1Operations.None Then
            STAFF_STUDENT_SUPERVISORS1Holder.Visible = False
            Return
        End If
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = STAFF_STUDENT_SUPERVISORS1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFF_STUDENT_SUPERVISORS1Operations.AllowRead
        STAFF_STUDENT_SUPERVISORS1Errors.Add(item.errors)
        If STAFF_STUDENT_SUPERVISORS1Errors.Count > 0 Then
            STAFF_STUDENT_SUPERVISORS1ShowErrors()
            Return
        End If
'End Record Form STAFF_STUDENT_SUPERVISORS1 Show method

'Record Form STAFF_STUDENT_SUPERVISORS1 BeforeShow tail @40-77CBA9DA
        STAFF_STUDENT_SUPERVISORS1Parameters()
        STAFF_STUDENT_SUPERVISORS1Data.FillItem(item, IsInsertMode)
        STAFF_STUDENT_SUPERVISORS1Holder.DataBind()
        STAFF_STUDENT_SUPERVISORS1Button_Insert.Visible=IsInsertMode AndAlso STAFF_STUDENT_SUPERVISORS1Operations.AllowInsert
        STAFF_STUDENT_SUPERVISORS1Button_Update.Visible=Not (IsInsertMode) AndAlso STAFF_STUDENT_SUPERVISORS1Operations.AllowUpdate
        STAFF_STUDENT_SUPERVISORS1Button_Delete.Visible=Not (IsInsertMode) AndAlso STAFF_STUDENT_SUPERVISORS1Operations.AllowDelete
        STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.Items.Add(new ListItem("Select Value",""))
        STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.Items(0).Selected = True
        item.YEAR_LEVELItems.SetSelection(item.YEAR_LEVEL.GetFormattedValue())
        If Not item.YEAR_LEVELItems.GetSelectedItem() Is Nothing Then
            STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.SelectedIndex = -1
        End If
        item.YEAR_LEVELItems.CopyTo(STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.Items)
        STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME.Text=item.SUPERVISOR_NAME.GetFormattedValue()
        STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL.Text=item.SUPERVISOR_EMAIL.GetFormattedValue()
        STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE.Text=item.SUPERVISOR_PHONE.GetFormattedValue()
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        STAFF_STUDENT_SUPERVISORS1STATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(STAFF_STUDENT_SUPERVISORS1STATUS.Items)
        STAFF_STUDENT_SUPERVISORS1LAST_ALTERED_BY.Text = Server.HtmlEncode(item.LAST_ALTERED_BY.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_STUDENT_SUPERVISORS1LAST_ALTERED_DATE.Text = Server.HtmlEncode(item.LAST_ALTERED_DATE.GetFormattedValue()).Replace(vbCrLf,"<br>")
        STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_BY.Value = item.Hidden_LAST_ALTERED_BY.GetFormattedValue()
        STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_DATE.Value = item.Hidden_LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form STAFF_STUDENT_SUPERVISORS1 BeforeShow tail

'Hidden Hidden_LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control @57-A6B573CB
            STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserLogin.ToUpper()))).GetFormattedValue()
'End Hidden Hidden_LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control

'Hidden Hidden_LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control @58-5781DC8A
            STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_DATE.Value = (New TextField("", (Now()))).GetFormattedValue()
'End Hidden Hidden_LAST_ALTERED_DATE Event BeforeShow. Action Retrieve Value for Control

'Record STAFF_STUDENT_SUPERVISORS1 Event BeforeShow. Action Hide-Show Component @61-CE18497B
        Dim UrlshowEdit_61_1 As IntegerField = New IntegerField("", System.Web.HttpContext.Current.Request.QueryString("showEdit"))
        Dim ExprParam2_61_2 As IntegerField = New IntegerField("", (1))
        If FieldBase.NotEqualOp(UrlshowEdit_61_1, ExprParam2_61_2) Then
            STAFF_STUDENT_SUPERVISORS1Holder.Visible = False
        End If
'End Record STAFF_STUDENT_SUPERVISORS1 Event BeforeShow. Action Hide-Show Component

'Record Form STAFF_STUDENT_SUPERVISORS1 Show method tail @40-1530F3AE
        If STAFF_STUDENT_SUPERVISORS1Errors.Count > 0 Then
            STAFF_STUDENT_SUPERVISORS1ShowErrors()
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 Show method tail

'Record Form STAFF_STUDENT_SUPERVISORS1 LoadItemFromRequest method @40-B42052EB

    Protected Sub STAFF_STUDENT_SUPERVISORS1LoadItemFromRequest(item As STAFF_STUDENT_SUPERVISORS1Item, ByVal EnableValidation As Boolean)
        Try
        item.YEAR_LEVEL.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.UniqueID))
        item.YEAR_LEVEL.SetValue(STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.Value)
        item.YEAR_LEVELItems.CopyFrom(STAFF_STUDENT_SUPERVISORS1YEAR_LEVEL.Items)
        Catch ae As ArgumentException
            STAFF_STUDENT_SUPERVISORS1Errors.Add("YEAR_LEVEL",String.Format(Resources.strings.CCS_IncorrectValue,"YEAR LEVEL"))
        End Try
        item.SUPERVISOR_NAME.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME.UniqueID))
        If ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME") Is Nothing Then
            item.SUPERVISOR_NAME.SetValue(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME.Text)
        Else
            item.SUPERVISOR_NAME.SetValue(ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_NAME"))
        End If
        item.SUPERVISOR_EMAIL.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL.UniqueID))
        If ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL") Is Nothing Then
            item.SUPERVISOR_EMAIL.SetValue(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL.Text)
        Else
            item.SUPERVISOR_EMAIL.SetValue(ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_EMAIL"))
        End If
        item.SUPERVISOR_PHONE.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE.UniqueID))
        If ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE") Is Nothing Then
            item.SUPERVISOR_PHONE.SetValue(STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE.Text)
        Else
            item.SUPERVISOR_PHONE.SetValue(ControlCustomValues("STAFF_STUDENT_SUPERVISORS1SUPERVISOR_PHONE"))
        End If
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1STATUS.UniqueID))
        If Not IsNothing(STAFF_STUDENT_SUPERVISORS1STATUS.SelectedItem) Then
            item.STATUS.SetValue(STAFF_STUDENT_SUPERVISORS1STATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(STAFF_STUDENT_SUPERVISORS1STATUS.Items)
        Catch ae As ArgumentException
            STAFF_STUDENT_SUPERVISORS1Errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        item.Hidden_LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_BY.UniqueID))
        item.Hidden_LAST_ALTERED_BY.SetValue(STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_BY.Value)
        item.Hidden_LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_DATE.UniqueID))
        item.Hidden_LAST_ALTERED_DATE.SetValue(STAFF_STUDENT_SUPERVISORS1Hidden_LAST_ALTERED_DATE.Value)
        If EnableValidation Then
            item.Validate(STAFF_STUDENT_SUPERVISORS1Data)
        End If
        STAFF_STUDENT_SUPERVISORS1Errors.Add(item.errors)
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 LoadItemFromRequest method

'Record Form STAFF_STUDENT_SUPERVISORS1 GetRedirectUrl method @40-96500A9D

    Protected Function GetSTAFF_STUDENT_SUPERVISORS1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","showEdit;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFF_STUDENT_SUPERVISORS1 GetRedirectUrl method

'Record Form STAFF_STUDENT_SUPERVISORS1 ShowErrors method @40-34A07E44

    Protected Sub STAFF_STUDENT_SUPERVISORS1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFF_STUDENT_SUPERVISORS1Errors.Count - 1
        Select Case STAFF_STUDENT_SUPERVISORS1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFF_STUDENT_SUPERVISORS1Errors(i)
        End Select
        Next i
        STAFF_STUDENT_SUPERVISORS1Error.Visible = True
        STAFF_STUDENT_SUPERVISORS1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 ShowErrors method

'Record Form STAFF_STUDENT_SUPERVISORS1 Insert Operation @40-839F3D29

    Protected Sub STAFF_STUDENT_SUPERVISORS1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = New STAFF_STUDENT_SUPERVISORS1Item()
        Dim ExecuteFlag As Boolean = True
        STAFF_STUDENT_SUPERVISORS1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_STUDENT_SUPERVISORS1 Insert Operation

'Button Button_Insert OnClick. @41-480A8961
        If CType(sender,Control).ID = "STAFF_STUDENT_SUPERVISORS1Button_Insert" Then
            RedirectUrl = GetSTAFF_STUDENT_SUPERVISORS1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @41-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form STAFF_STUDENT_SUPERVISORS1 BeforeInsert tail @40-0195FF34
    STAFF_STUDENT_SUPERVISORS1Parameters()
    STAFF_STUDENT_SUPERVISORS1LoadItemFromRequest(item, EnableValidation)
    If STAFF_STUDENT_SUPERVISORS1Operations.AllowInsert Then
        ErrorFlag=(STAFF_STUDENT_SUPERVISORS1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_STUDENT_SUPERVISORS1Data.InsertItem(item)
            Catch ex As Exception
                STAFF_STUDENT_SUPERVISORS1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_STUDENT_SUPERVISORS1 BeforeInsert tail

'Record Form STAFF_STUDENT_SUPERVISORS1 AfterInsert tail  @40-DD67B2C8
        End If
        ErrorFlag=(STAFF_STUDENT_SUPERVISORS1Errors.Count > 0)
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 AfterInsert tail 

'Record Form STAFF_STUDENT_SUPERVISORS1 Update Operation @40-69CD383B

    Protected Sub STAFF_STUDENT_SUPERVISORS1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = New STAFF_STUDENT_SUPERVISORS1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_STUDENT_SUPERVISORS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFF_STUDENT_SUPERVISORS1 Update Operation

'Button Button_Update OnClick. @42-0A7DEAD5
        If CType(sender,Control).ID = "STAFF_STUDENT_SUPERVISORS1Button_Update" Then
            RedirectUrl = GetSTAFF_STUDENT_SUPERVISORS1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @42-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form STAFF_STUDENT_SUPERVISORS1 Before Update tail @40-8E9246A2
        STAFF_STUDENT_SUPERVISORS1Parameters()
        STAFF_STUDENT_SUPERVISORS1LoadItemFromRequest(item, EnableValidation)
        If STAFF_STUDENT_SUPERVISORS1Operations.AllowUpdate Then
        ErrorFlag = (STAFF_STUDENT_SUPERVISORS1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_STUDENT_SUPERVISORS1Data.UpdateItem(item)
            Catch ex As Exception
                STAFF_STUDENT_SUPERVISORS1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form STAFF_STUDENT_SUPERVISORS1 Before Update tail

'Record Form STAFF_STUDENT_SUPERVISORS1 Update Operation tail @40-DD67B2C8
        End If
        ErrorFlag=(STAFF_STUDENT_SUPERVISORS1Errors.Count > 0)
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 Update Operation tail

'Record Form STAFF_STUDENT_SUPERVISORS1 Delete Operation @40-3FC3892B
    Protected Sub STAFF_STUDENT_SUPERVISORS1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        STAFF_STUDENT_SUPERVISORS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = New STAFF_STUDENT_SUPERVISORS1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFF_STUDENT_SUPERVISORS1 Delete Operation

'Button Button_Delete OnClick. @43-7E6D7CB6
        If CType(sender,Control).ID = "STAFF_STUDENT_SUPERVISORS1Button_Delete" Then
            RedirectUrl = GetSTAFF_STUDENT_SUPERVISORS1RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @43-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @40-9CF03BA6
        STAFF_STUDENT_SUPERVISORS1Parameters()
        STAFF_STUDENT_SUPERVISORS1LoadItemFromRequest(item, EnableValidation)
        If STAFF_STUDENT_SUPERVISORS1Operations.AllowDelete Then
        ErrorFlag = (STAFF_STUDENT_SUPERVISORS1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                STAFF_STUDENT_SUPERVISORS1Data.DeleteItem(item)
            Catch ex As Exception
                STAFF_STUDENT_SUPERVISORS1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @40-294C0AC2
        End If
        If ErrorFlag Then
            STAFF_STUDENT_SUPERVISORS1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFF_STUDENT_SUPERVISORS1 Cancel Operation @40-67BA26CE

    Protected Sub STAFF_STUDENT_SUPERVISORS1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFF_STUDENT_SUPERVISORS1Item = New STAFF_STUDENT_SUPERVISORS1Item()
        STAFF_STUDENT_SUPERVISORS1IsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFF_STUDENT_SUPERVISORS1LoadItemFromRequest(item, False)
'End Record Form STAFF_STUDENT_SUPERVISORS1 Cancel Operation

'Button Button_Cancel OnClick. @45-1EC42D35
    If CType(sender,Control).ID = "STAFF_STUDENT_SUPERVISORS1Button_Cancel" Then
        RedirectUrl = GetSTAFF_STUDENT_SUPERVISORS1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @45-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form STAFF_STUDENT_SUPERVISORS1 Cancel Operation tail @40-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFF_STUDENT_SUPERVISORS1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-29B3471D
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        STAFF_STUDENT_SUPERVISORSContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFF_STUDENT_SUPERVISORSData = New STAFF_STUDENT_SUPERVISORSDataProvider()
        STAFF_STUDENT_SUPERVISORSOperations = New FormSupportedOperations(False, True, False, False, False)
        STAFF_STUDENT_SUPERVISORSSearchData = New STAFF_STUDENT_SUPERVISORSSearchDataProvider()
        STAFF_STUDENT_SUPERVISORSSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STAFF_STUDENT_SUPERVISORS1Data = New STAFF_STUDENT_SUPERVISORS1DataProvider()
        STAFF_STUDENT_SUPERVISORS1Operations = New FormSupportedOperations(False, True, True, True, True)
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

