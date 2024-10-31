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

Namespace DECV_PROD2007.VSREnrolment 'Namespace @1-5272238C

    'Forms Definition @1-074C8695
    Public Class [VSREnrolmentPage]
        Inherits CCPage
        'End Forms Definition

        'Forms Objects @1-2B6A7C00
        Protected viewVSNSearchData As viewVSNSearchDataProvider
        Protected viewVSNSearchErrors As NameValueCollection = New NameValueCollection()
        Protected viewVSNSearchOperations As FormSupportedOperations
        Protected viewVSNSearchIsSubmitted As Boolean = False
        Protected viewVSNData As viewVSNDataProvider
        Protected viewVSNOperations As FormSupportedOperations
        Protected viewVSNCurrentRowNumber As Integer
        Protected VSREnrolmentContentMeta As String
        'End Forms Objects

        'Page_Load Event @1-A2D2CF1E
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            'End Page_Load Event

            'Page_Load Event BeforeIsPostBack @1-C418A9A0
            Dim item As PageItem = PageItem.CreateFromHttpRequest()
            ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
            If Not IsPostBack Then
                Dim PageData As PageDataProvider = New PageDataProvider()
                PageData.FillItem(item)
                viewVSNSearchShow()
                viewVSNBind()
            End If
            'End Page_Load Event BeforeIsPostBack

        End Sub 'Page_Load Event tail @1-E31F8E2A

        Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

        End Sub 'Page_Unload Event tail @1-E31F8E2A

        'Record Form viewVSNSearch Parameters @2-F1C893C7

        Protected Sub viewVSNSearchParameters()
            Dim item As New viewVSNSearchItem
            Try
            Catch e As Exception
                viewVSNSearchErrors.Add("Parameters", "Form Parameters: " + e.Message)
            End Try
        End Sub
        'End Record Form viewVSNSearch Parameters

        'Record Form viewVSNSearch Show method @2-CBA0049B
        Protected Sub viewVSNSearchShow()
            If viewVSNSearchOperations.None Then
                viewVSNSearchHolder.Visible = False
                Return
            End If
            Dim item As viewVSNSearchItem = viewVSNSearchItem.CreateFromHttpRequest()
            Dim IsInsertMode As Boolean = Not viewVSNSearchOperations.AllowRead
            item.ClearParametersHref = "VSREmrolment.aspx"
            viewVSNSearchErrors.Add(item.errors)
            If viewVSNSearchErrors.Count > 0 Then
                viewVSNSearchShowErrors()
                Return
            End If
            'End Record Form viewVSNSearch Show method

            'Record Form viewVSNSearch BeforeShow tail @2-0B5E1B26
            viewVSNSearchParameters()
            viewVSNSearchData.FillItem(item, IsInsertMode)
            viewVSNSearchHolder.DataBind()
            viewVSNSearchs_SURNAME.Text = item.s_SURNAME.GetFormattedValue()
            viewVSNSearchs_STUDENT_ID.Text = item.s_STUDENT_ID.GetFormattedValue()
            viewVSNSearchs_ENROLMENT_YEAR.Text = item.s_ENROLMENT_YEAR.GetFormattedValue()
            viewVSNSearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf, "")
            viewVSNSearchClearParameters.HRef = item.ClearParametersHref + item.ClearParametersHrefParameters.ToString("GET", "s_SURNAME;s_STUDENT_ID;s_RECEIPT_NO;s_ENROLMENT_YEAR", ViewState)
            viewVSNSearchs_STUDENT_VSN.Text = item.s_STUDENT_VSN.GetFormattedValue()
            'End Record Form viewVSNSearch BeforeShow tail

            'Record Form viewVSNSearch Show method tail @2-4BE60A14
            If viewVSNSearchErrors.Count > 0 Then
                viewVSNSearchShowErrors()
            End If
        End Sub
        'End Record Form viewVSNSearch Show method tail

        'Record Form viewVSNSearch LoadItemFromRequest method @2-99E75505

        Protected Sub viewVSNSearchLoadItemFromRequest(ByVal item As viewVSNSearchItem, ByVal EnableValidation As Boolean)
            item.s_SURNAME.IsEmpty = IsNothing(Request.Form(viewVSNSearchs_SURNAME.UniqueID))
            If ControlCustomValues("viewVSNSearchs_SURNAME") Is Nothing Then
                item.s_SURNAME.SetValue(viewVSNSearchs_SURNAME.Text)
            Else
                item.s_SURNAME.SetValue(ControlCustomValues("viewVSNSearchs_SURNAME"))
            End If
            item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(viewVSNSearchs_STUDENT_ID.UniqueID))
            If ControlCustomValues("viewVSNSearchs_STUDENT_ID") Is Nothing Then
                item.s_STUDENT_ID.SetValue(viewVSNSearchs_STUDENT_ID.Text)
            Else
                item.s_STUDENT_ID.SetValue(ControlCustomValues("viewVSNSearchs_STUDENT_ID"))
            End If
            Try
                item.s_ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(viewVSNSearchs_ENROLMENT_YEAR.UniqueID))
                If ControlCustomValues("viewVSNSearchs_ENROLMENT_YEAR") Is Nothing Then
                    item.s_ENROLMENT_YEAR.SetValue(viewVSNSearchs_ENROLMENT_YEAR.Text)
                Else
                    item.s_ENROLMENT_YEAR.SetValue(ControlCustomValues("viewVSNSearchs_ENROLMENT_YEAR"))
                End If
            Catch ae As ArgumentException
                viewVSNSearchErrors.Add("s_ENROLMENT_YEAR", String.Format(Resources.strings.CCS_IncorrectValue, "s_ENROLMENT_YEAR"))
            End Try
            item.s_STUDENT_VSN.IsEmpty = IsNothing(Request.Form(viewVSNSearchs_STUDENT_VSN.UniqueID))
            If ControlCustomValues("viewVSNSearchs_STUDENT_VSN") Is Nothing Then
                item.s_STUDENT_VSN.SetValue(viewVSNSearchs_STUDENT_VSN.Text)
            Else
                item.s_STUDENT_VSN.SetValue(ControlCustomValues("viewVSNSearchs_STUDENT_VSN"))
            End If
            If EnableValidation Then
                item.Validate(viewVSNSearchData)
            End If
            viewVSNSearchErrors.Add(item.errors)
        End Sub
        'End Record Form viewVSNSearch LoadItemFromRequest method

        'Record Form viewVSNSearch GetRedirectUrl method @2-51AA55A4

        Protected Function GetviewVSNSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
            Dim parameters As New LinkParameterCollection()
            If redirect = "" Then redirect = "VSREnrolment.aspx"
            Dim p As String = parameters.ToString("None", removeList, ViewState)
            If p = "" Then p = "?"
            p = p.Replace("&amp;", "&")
            Return redirect + p
        End Function
        'End Record Form viewVSNSearch GetRedirectUrl method

        'Record Form viewVSNSearch ShowErrors method @2-9FD6C0B5

        Protected Sub viewVSNSearchShowErrors()
            Dim DefaultMessage As String = ""
            Dim i As Integer
            For i = 0 To viewVSNSearchErrors.Count - 1
                Select Case viewVSNSearchErrors.AllKeys(i)
                    Case Else
                        If DefaultMessage <> "" Then DefaultMessage &= "<br>"
                        DefaultMessage = DefaultMessage & viewVSNSearchErrors(i)
                End Select
            Next i
            viewVSNSearchError.Visible = True
            viewVSNSearchErrorLabel.Text = DefaultMessage
        End Sub
        'End Record Form viewVSNSearch ShowErrors method

        'Record Form viewVSNSearch Insert Operation @2-95D4E1BA

        Protected Sub viewVSNSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim item As viewVSNSearchItem = New viewVSNSearchItem()
            viewVSNSearchIsSubmitted = True
            Dim ErrorFlag As Boolean = False
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = False
            'End Record Form viewVSNSearch Insert Operation

            'Record Form viewVSNSearch BeforeInsert tail @2-F6AAED64
            viewVSNSearchParameters()
            viewVSNSearchLoadItemFromRequest(item, EnableValidation)
            'End Record Form viewVSNSearch BeforeInsert tail

            'Record Form viewVSNSearch AfterInsert tail  @2-107E74F5
            ErrorFlag = (viewVSNSearchErrors.Count > 0)
            If ErrorFlag Then
                viewVSNSearchShowErrors()
            Else
                Response.Redirect(RedirectUrl)
            End If
        End Sub
        'End Record Form viewVSNSearch AfterInsert tail 

        'Record Form viewVSNSearch Update Operation @2-E0FCD62C

        Protected Sub viewVSNSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim item As viewVSNSearchItem = New viewVSNSearchItem()
            item.IsNew = False
            Dim ErrorFlag As Boolean = False
            viewVSNSearchIsSubmitted = True
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = False
            'End Record Form viewVSNSearch Update Operation

            'Record Form viewVSNSearch Before Update tail @2-F6AAED64
            viewVSNSearchParameters()
            viewVSNSearchLoadItemFromRequest(item, EnableValidation)
            'End Record Form viewVSNSearch Before Update tail

            'Record Form viewVSNSearch Update Operation tail @2-107E74F5
            ErrorFlag = (viewVSNSearchErrors.Count > 0)
            If ErrorFlag Then
                viewVSNSearchShowErrors()
            Else
                Response.Redirect(RedirectUrl)
            End If
        End Sub
        'End Record Form viewVSNSearch Update Operation tail

        'Record Form viewVSNSearch Delete Operation @2-19EC1222
        Protected Sub viewVSNSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim ErrorFlag As Boolean = False
            viewVSNSearchIsSubmitted = True
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = False
            Dim item As viewVSNSearchItem = New viewVSNSearchItem()
            item.IsNew = False
            item.IsDeleted = True
            'End Record Form viewVSNSearch Delete Operation

            'Record Form BeforeDelete tail @2-F6AAED64
            viewVSNSearchParameters()
            viewVSNSearchLoadItemFromRequest(item, EnableValidation)
            'End Record Form BeforeDelete tail

            'Record Form AfterDelete tail @2-F36ADA23
            If ErrorFlag Then
                viewVSNSearchShowErrors()
            Else
                Response.Redirect(RedirectUrl)
            End If
        End Sub
        'End Record Form AfterDelete tail

        'Record Form viewVSNSearch Cancel Operation @2-8BCB90FD

        Protected Sub viewVSNSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim item As viewVSNSearchItem = New viewVSNSearchItem()
            viewVSNSearchIsSubmitted = True
            Dim RedirectUrl As String = ""
            viewVSNSearchLoadItemFromRequest(item, True)
            'End Record Form viewVSNSearch Cancel Operation

            'Record Form viewVSNSearch Cancel Operation tail @2-EA2B0FFB
            Response.Redirect(RedirectUrl)
        End Sub
        'End Record Form viewVSNSearch Cancel Operation tail

        'Record Form viewVSNSearch Search Operation @2-CEA8A6D8
        Protected Sub viewVSNSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
            viewVSNSearchIsSubmitted = True
            Dim ErrorFlag As Boolean = False
            Dim RedirectUrl As String = ""
            Dim EnableValidation As Boolean = True
            Dim item As viewVSNSearchItem = New viewVSNSearchItem()
            viewVSNSearchLoadItemFromRequest(item, EnableValidation)
            'End Record Form viewVSNSearch Search Operation

            'DEL      ' -------------------------
            'DEL      ' ERA: add an 'exist=1' parameter to URL querystring to flow through to the search 
            'DEL  	' code is actually added 30 lines below, with this stub kept here for ease of finding it
            'DEL  			tmpExistParam = "exist=1"
            'DEL      ' -------------------------

            'Button Button_DoSearch OnClick. @11-37B188C0
            If CType(sender, Control).ID = "viewVSNSearchButton_DoSearch" Then
                RedirectUrl = GetviewVSNSearchRedirectUrl("", "s_SURNAME;s_STUDENT_ID;s_ENROLMENT_YEAR;s_STUDENT_VSN")
                EnableValidation = True
                'End Button Button_DoSearch OnClick.

                'Button Button_DoSearch Event OnClick. Action Custom Code @12-73254650
                ' -------------------------
                ' ERA: add an 'exist=2' parameter to URL querystring to flow through to the search 
                ' code is actually added 30 lines below, with this stub kept here for ease of finding it
                Dim tmpExistParam As String = "exist=2"
                ' -------------------------
                'End Button Button_DoSearch Event OnClick. Action Custom Code

                'Button Button_DoSearch OnClick tail. @11-477CF3C9
            End If
            'End Button Button_DoSearch OnClick tail.

            'Record Form viewVSNSearch Search Operation tail @2-65A2DFF1
            ErrorFlag = viewVSNSearchErrors.Count > 0
            If ErrorFlag Then
                viewVSNSearchShowErrors()
            Else
                Dim Params As String = ""
                Dim li As ListItem
                Params = Params & IIf(viewVSNSearchs_SURNAME.Text <> "", ("s_SURNAME=" & Server.UrlEncode(viewVSNSearchs_SURNAME.Text) & "&"), "")
                Params = Params & IIf(viewVSNSearchs_STUDENT_ID.Text <> "", ("s_STUDENT_ID=" & Server.UrlEncode(viewVSNSearchs_STUDENT_ID.Text) & "&"), "")
                Params = Params & IIf(viewVSNSearchs_ENROLMENT_YEAR.Text <> "", ("s_ENROLMENT_YEAR=" & Server.UrlEncode(viewVSNSearchs_ENROLMENT_YEAR.Text) & "&"), "")
                Params = Params & IIf(viewVSNSearchs_STUDENT_VSN.Text <> "", ("s_STUDENT_VSN=" & Server.UrlEncode(viewVSNSearchs_STUDENT_VSN.Text) & "&"), "")
                If Not RedirectUrl.EndsWith("?") Then
                    RedirectUrl &= "&" & Params
                Else
                    RedirectUrl &= Params
                End If
                RedirectUrl = RedirectUrl.TrimEnd(New Char() {"&"c})
                Response.Redirect(RedirectUrl)
            End If
        End Sub
        'End Record Form viewVSNSearch Search Operation tail

        'Grid viewVSN Bind @14-1383C40B

        Protected Sub viewVSNBind()
            If Not viewVSNOperations.AllowRead Then Return
            Dim PagesCount As Integer
            Dim FooterIndex As Integer
            If Not (IsPostBack) Then
                DBUtility.InitializeGridParameters(ViewState, "viewVSN", GetType(viewVSNDataProvider.SortFields), 25, 100)
            End If
            'End Grid viewVSN Bind

            'Grid Form viewVSN BeforeShow tail @14-D8550D82
            viewVSNParameters()
            viewVSNData.SortField = CType(ViewState("viewVSNSortField"), viewVSNDataProvider.SortFields)
            viewVSNData.SortDir = CType(ViewState("viewVSNSortDir"), SortDirections)
            viewVSNData.PageNumber = CInt(ViewState("viewVSNPageNumber"))
            viewVSNData.RecordsPerPage = CInt(ViewState("viewVSNPageSize"))
            viewVSNRepeater.DataSource = viewVSNData.GetResultSet(PagesCount, viewVSNOperations)
            ViewState("viewVSNPagesCount") = PagesCount
            Dim item As viewVSNItem = New viewVSNItem()
            viewVSNRepeater.DataBind()
            FooterIndex = viewVSNRepeater.Controls.Count - 1
            If PagesCount = 0 Then
                viewVSNRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
            End If
            Dim Sorter_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_STUDENT_IDSorter"), DECV_PROD2007.Controls.Sorter)
            Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(viewVSNRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"), DECV_PROD2007.Controls.Navigator)
            NavigatorNavigator.PageSizes = New Integer() {1, 5, 10, 25, 50}
            If PagesCount < 2 Then NavigatorNavigator.Visible = False
            Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_ENROLMENT_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_ENROLMENT_STATUSSorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_VSN1Sorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_VSN1Sorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_VSREnrolledSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_VSREnrolledSorter"), DECV_PROD2007.Controls.Sorter)
            Dim Sorter_VSRVerifiedSorter As DECV_PROD2007.Controls.Sorter = DirectCast(viewVSNRepeater.Controls(0).FindControl("Sorter_VSRVerifiedSorter"), DECV_PROD2007.Controls.Sorter)

            'End Grid Form viewVSN BeforeShow tail

            'Grid viewVSN Event BeforeShow. Action Custom Code @33-73254650
            ' -------------------------
            ' Vikas: only display if something to display, and not if initial open
            If (IsNothing(viewVSNData.Urls_SURNAME) And IsNothing(viewVSNData.Urls_Student_ID)) And IsNothing(viewVSNData.Urls_STUDENT_VSN) Then
                viewVSNRepeater.Visible = False
            End If

            ' -------------------------
            'End Grid viewVSN Event BeforeShow. Action Custom Code

            'Grid viewVSN Bind tail @14-E31F8E2A
        End Sub
        'End Grid viewVSN Bind tail

        'Grid viewVSN Table Parameters @14-4267346C

        Protected Sub viewVSNParameters()
            Try
                viewVSNData.Urls_Student_ID = FloatParameter.GetParam("s_Student_ID", ParameterSourceType.URL, "", Nothing, False)
                viewVSNData.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, False)
                viewVSNData.Urls_STUDENT_VSN = TextParameter.GetParam("s_STUDENT_VSN", ParameterSourceType.URL, "", Nothing, False)
                viewVSNData.Urls_ENROLMENT_YEAR = FloatParameter.GetParam("s_ENROLMENT_YEAR", ParameterSourceType.URL, "", Nothing, False)

            Catch
                Dim ParentControls As ControlCollection = viewVSNRepeater.Parent.Controls
                Dim RepeaterIndex As Integer = ParentControls.IndexOf(viewVSNRepeater)
                ParentControls.RemoveAt(RepeaterIndex)
                Dim ErrorMessage As Literal = New Literal()
                ErrorMessage.Text = "Error in Grid viewVSN: Invalid parameter"
                ParentControls.AddAt(RepeaterIndex, ErrorMessage)
            End Try
        End Sub
        'End Grid viewVSN Table Parameters

        'Grid viewVSN ItemDataBound event @14-BE6D9D66

        Protected Sub viewVSNItemDataBound(ByVal Sender As Object, ByVal e As RepeaterItemEventArgs)
            Dim DataItem As viewVSNItem = CType(e.Item.DataItem, viewVSNItem)
            Dim Item As viewVSNItem = DataItem
            Dim FormDataSource As viewVSNItem() = CType(viewVSNRepeater.DataSource, viewVSNItem())
            Dim viewVSNDataRows As Integer = FormDataSource.Length
            Dim viewVSNIsForceIteration As Boolean = False
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                viewVSNCurrentRowNumber += 1
                CType(Page, CCPage).ControlAttributes.Add(viewVSNRepeater, New CCSControlAttribute("rowNumber", FieldType._Integer, viewVSNCurrentRowNumber), AttributeOption.Multiple)
            End If
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim viewVSNSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewVSNSTUDENT_ID"), System.Web.UI.HtmlControls.HtmlAnchor)
                Dim viewVSNSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNSURNAME"), System.Web.UI.WebControls.Literal)
                Dim viewVSNFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNFIRST_NAME"), System.Web.UI.WebControls.Literal)
                Dim viewVSNYEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNYEAR_LEVEL"), System.Web.UI.WebControls.Literal)
                Dim viewVSNENROLMENT_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNENROLMENT_STATUS"), System.Web.UI.WebControls.Literal)
                Dim viewVSNENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNENROLMENT_YEAR"), System.Web.UI.WebControls.Literal)
                Dim viewVSNVSN As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNVSN"), System.Web.UI.WebControls.Literal)
                Dim viewVSNVSREnrolled As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNVSREnrolled"), System.Web.UI.WebControls.Literal)
                Dim viewVSNVSRVerified As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("viewVSNVSRVerified"), System.Web.UI.WebControls.Literal)
                DataItem.STUDENT_IDHref = "StudentSummary.aspx"
                viewVSNSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET", "s_SURNAME;s_ENROLMENT_YEAR", ViewState)
            End If
            'End Grid viewVSN ItemDataBound event

            'viewVSN control Before Show @14-EBC08450
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'End viewVSN control Before Show

                'Get Control @22-C055D030
                Dim viewVSNSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("viewVSNSTUDENT_ID"), System.Web.UI.HtmlControls.HtmlAnchor)
                'End Get Control

                'Link STUDENT_ID Event BeforeShow. Action Custom Code @23-73254650
                ' -------------------------
                ' ERA: change the hyperlink depending on if the exist=1 
                '	(if 1 then StudentEnrolment_AddStudent else leave as is: Student Summary)
                If Request.QueryString("exist") = "1" Then
                    DataItem.STUDENT_IDHref = "StudentEnrolment_AddNewYear.aspx"
                    viewVSNSTUDENT_ID.HRef = DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("GET", "", ViewState)
                End If
                ' -------------------------
                'End Link STUDENT_ID Event BeforeShow. Action Custom Code

                'viewVSN control Before Show tail @14-477CF3C9
            End If
            'End viewVSN control Before Show tail

            'Grid viewVSN ItemDataBound event tail @14-0E1046EB
            If viewVSNIsForceIteration Then
                Dim ri As RepeaterItem = Nothing
                ri = New RepeaterItem(viewVSNCurrentRowNumber, ListItemType.Item)
                viewVSNRepeater.ItemTemplate.InstantiateIn(ri)
                ri.DataItem = DataItem
                ri.DataBind()
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
                viewVSNItemDataBound(Sender, New RepeaterItemEventArgs(ri))
                ri.DataItem = Nothing
            End If
        End Sub
        'End Grid viewVSN ItemDataBound event tail

        'Grid viewVSN ItemCommand event @14-F5F26DB1

        Protected Sub viewVSNItemCommand(ByVal Sender As Object, ByVal e As RepeaterCommandEventArgs)
            Dim FooterIndex As Integer = viewVSNRepeater.Controls.Count - 1
            Dim BindAllowed As Boolean = False
            If e.CommandName = "Sort" Then
                If CType(e.CommandArgument, SorterState) = SorterState.None Then
                    If CType(ViewState("viewVSNSortDir"), SortDirections) = SortDirections._Asc And ViewState("viewVSNSortField").ToString() = CType(e.CommandSource, Controls.Sorter).Field Then
                        ViewState("viewVSNSortDir") = SortDirections._Desc
                    Else
                        ViewState("viewVSNSortDir") = SortDirections._Asc
                    End If
                Else
                    ViewState("viewVSNSortDir") = CInt(CType(e.CommandSource, Controls.Sorter).State)
                End If
                Dim sf As viewVSNDataProvider.SortFields = 0
                ViewState("viewVSNSortField") = [Enum].Parse(sf.GetType(), CType(e.CommandSource, Controls.Sorter).Field)
                ViewState("viewVSNPageNumber") = 1
                BindAllowed = True
            End If

            If e.CommandName = "Navigate" Then
                ViewState("viewVSNPageNumber") = Int32.Parse(e.CommandArgument.ToString())
                BindAllowed = True
            End If
            If e.CommandName = "ChangePageSize" Then
                ViewState("viewVSNPageSize") = Int32.Parse(CType(e.CommandArgument, Integer())(0).ToString())
                ViewState("viewVSNPageNumber") = Int32.Parse(CType(e.CommandArgument, Integer())(1).ToString())
                BindAllowed = True
            End If
            If BindAllowed Then
                viewVSNBind()
            End If
        End Sub
        'End Grid viewVSN ItemCommand event

        'OnInit Event @1-7CD4ED69
#Region " Web Form Designer Generated Code "
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            'End OnInit Event

            'OnInit Event Body @1-2A3968C4
            ClientScript.GetPostBackEventReference(Me, "")
            Utility.SetThreadCulture()
            PageStyleName = Utility.GetPageStyle()
            VSREnrolmentContentMeta = "text/html; charset=" + CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).Encoding
            If Application(Request.PhysicalPath) Is Nothing Then
                Application.Add(Request.PhysicalPath, Response.ContentEncoding.WebName)
            End If
            InitializeComponent()
            MyBase.OnInit(e)
            viewVSNSearchData = New viewVSNSearchDataProvider()
            viewVSNSearchOperations = New FormSupportedOperations(False, True, True, True, True)
            viewVSNData = New viewVSNDataProvider()
            viewVSNOperations = New FormSupportedOperations(False, True, False, False, False)
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

