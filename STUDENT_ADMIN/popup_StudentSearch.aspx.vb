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

Namespace DECV_PROD2007.popup_StudentSearch 'Namespace @1-A40F6DF6

'Forms Definition @1-966D1463
Public Class [popup_StudentSearchPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-3227A197
    Protected STUDENT_STUDENT_ENROLMENTData As STUDENT_STUDENT_ENROLMENTDataProvider
    Protected STUDENT_STUDENT_ENROLMENTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_STUDENT_ENROLMENTOperations As FormSupportedOperations
    Protected STUDENT_STUDENT_ENROLMENTIsSubmitted As Boolean = False
    Protected STUDENT_STUDENT_ENROLMENT1Data As STUDENT_STUDENT_ENROLMENT1DataProvider
    Protected STUDENT_STUDENT_ENROLMENT1Operations As FormSupportedOperations
    Protected STUDENT_STUDENT_ENROLMENT1CurrentRowNumber As Integer
    Protected popup_StudentSearchContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-A135B644
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_STUDENT_ENROLMENTShow()
            STUDENT_STUDENT_ENROLMENT1Bind
    End If
'End Page_Load Event BeforeIsPostBack

'Page popup_StudentSearch Event BeforeShow. Action Hide-Show Component @33-195C3C3B
        Dim Urls_SURNAME_33_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SURNAME"))
        Dim ExprParam2_33_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SURNAME_33_1, ExprParam2_33_2) Then
            STUDENT_STUDENT_ENROLMENT1Repeater.Visible = False
        End If
'End Page popup_StudentSearch Event BeforeShow. Action Hide-Show Component

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_STUDENT_ENROLMENT Parameters @14-6D30DF52

    Protected Sub STUDENT_STUDENT_ENROLMENTParameters()
        Dim item As new STUDENT_STUDENT_ENROLMENTItem
        Try
        Catch e As Exception
            STUDENT_STUDENT_ENROLMENTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT Parameters

'Record Form STUDENT_STUDENT_ENROLMENT Show method @14-4E28A0C5
    Protected Sub STUDENT_STUDENT_ENROLMENTShow()
        If STUDENT_STUDENT_ENROLMENTOperations.None Then
            STUDENT_STUDENT_ENROLMENTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_STUDENT_ENROLMENTItem = STUDENT_STUDENT_ENROLMENTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_STUDENT_ENROLMENTOperations.AllowRead
        STUDENT_STUDENT_ENROLMENTErrors.Add(item.errors)
        If STUDENT_STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
            Return
        End If
'End Record Form STUDENT_STUDENT_ENROLMENT Show method

'Record Form STUDENT_STUDENT_ENROLMENT BeforeShow tail @14-65BD41CA
        STUDENT_STUDENT_ENROLMENTParameters()
        STUDENT_STUDENT_ENROLMENTData.FillItem(item, IsInsertMode)
        STUDENT_STUDENT_ENROLMENTHolder.DataBind()
        STUDENT_STUDENT_ENROLMENTs_SURNAME.Text=item.s_SURNAME.GetFormattedValue()
'End Record Form STUDENT_STUDENT_ENROLMENT BeforeShow tail

'Record Form STUDENT_STUDENT_ENROLMENT Show method tail @14-B871BD6B
        If STUDENT_STUDENT_ENROLMENTErrors.Count > 0 Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT Show method tail

'Record Form STUDENT_STUDENT_ENROLMENT LoadItemFromRequest method @14-F6D119FA

    Protected Sub STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item As STUDENT_STUDENT_ENROLMENTItem, ByVal EnableValidation As Boolean)
        item.s_SURNAME.IsEmpty = IsNothing(Request.Form(STUDENT_STUDENT_ENROLMENTs_SURNAME.UniqueID))
        If ControlCustomValues("STUDENT_STUDENT_ENROLMENTs_SURNAME") Is Nothing Then
            item.s_SURNAME.SetValue(STUDENT_STUDENT_ENROLMENTs_SURNAME.Text)
        Else
            item.s_SURNAME.SetValue(ControlCustomValues("STUDENT_STUDENT_ENROLMENTs_SURNAME"))
        End If
        If EnableValidation Then
            item.Validate(STUDENT_STUDENT_ENROLMENTData)
        End If
        STUDENT_STUDENT_ENROLMENTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT LoadItemFromRequest method

'Record Form STUDENT_STUDENT_ENROLMENT GetRedirectUrl method @14-57801DA4

    Protected Function GetSTUDENT_STUDENT_ENROLMENTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "popup_StudentSearch.aspx"
        Dim p As String = parameters.ToString("All",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_STUDENT_ENROLMENT GetRedirectUrl method

'Record Form STUDENT_STUDENT_ENROLMENT ShowErrors method @14-FE671E69

    Protected Sub STUDENT_STUDENT_ENROLMENTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_STUDENT_ENROLMENTErrors.Count - 1
        Select Case STUDENT_STUDENT_ENROLMENTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_STUDENT_ENROLMENTErrors(i)
        End Select
        Next i
        STUDENT_STUDENT_ENROLMENTError.Visible = True
        STUDENT_STUDENT_ENROLMENTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT ShowErrors method

'Record Form STUDENT_STUDENT_ENROLMENT Insert Operation @14-DE7CD31F

    Protected Sub STUDENT_STUDENT_ENROLMENT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        STUDENT_STUDENT_ENROLMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_STUDENT_ENROLMENT Insert Operation

'Record Form STUDENT_STUDENT_ENROLMENT BeforeInsert tail @14-D5CC75EB
    STUDENT_STUDENT_ENROLMENTParameters()
    STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_STUDENT_ENROLMENT BeforeInsert tail

'Record Form STUDENT_STUDENT_ENROLMENT AfterInsert tail  @14-CDB65E26
        ErrorFlag=(STUDENT_STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT AfterInsert tail 

'Record Form STUDENT_STUDENT_ENROLMENT Update Operation @14-F380A16E

    Protected Sub STUDENT_STUDENT_ENROLMENT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_STUDENT_ENROLMENT Update Operation

'Record Form STUDENT_STUDENT_ENROLMENT Before Update tail @14-D5CC75EB
        STUDENT_STUDENT_ENROLMENTParameters()
        STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_STUDENT_ENROLMENT Before Update tail

'Record Form STUDENT_STUDENT_ENROLMENT Update Operation tail @14-CDB65E26
        ErrorFlag=(STUDENT_STUDENT_ENROLMENTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT Update Operation tail

'Record Form STUDENT_STUDENT_ENROLMENT Delete Operation @14-3E877752
    Protected Sub STUDENT_STUDENT_ENROLMENT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_STUDENT_ENROLMENT Delete Operation

'Record Form BeforeDelete tail @14-D5CC75EB
        STUDENT_STUDENT_ENROLMENTParameters()
        STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @14-9D564C7E
        If ErrorFlag Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_STUDENT_ENROLMENT Cancel Operation @14-09BABA3E

    Protected Sub STUDENT_STUDENT_ENROLMENT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        STUDENT_STUDENT_ENROLMENTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item, True)
'End Record Form STUDENT_STUDENT_ENROLMENT Cancel Operation

'Record Form STUDENT_STUDENT_ENROLMENT Cancel Operation tail @14-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT Cancel Operation tail

'Record Form STUDENT_STUDENT_ENROLMENT Search Operation @14-F82433C0
    Protected Sub STUDENT_STUDENT_ENROLMENT_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STUDENT_STUDENT_ENROLMENTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STUDENT_STUDENT_ENROLMENTItem = New STUDENT_STUDENT_ENROLMENTItem()
        STUDENT_STUDENT_ENROLMENTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_STUDENT_ENROLMENT Search Operation

'Button Button_DoSearch OnClick. @34-8CDF5C16
        If CType(sender,Control).ID = "STUDENT_STUDENT_ENROLMENTButton_DoSearch" Then
            RedirectUrl = GetSTUDENT_STUDENT_ENROLMENTRedirectUrl("", "s_SURNAME")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @34-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENT_STUDENT_ENROLMENT Search Operation tail @14-92D8AAB8
        ErrorFlag = STUDENT_STUDENT_ENROLMENTErrors.Count > 0
        If ErrorFlag Then
            STUDENT_STUDENT_ENROLMENTShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STUDENT_STUDENT_ENROLMENTs_SURNAME.Text <> "",("s_SURNAME=" & Server.UrlEncode(STUDENT_STUDENT_ENROLMENTs_SURNAME.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_STUDENT_ENROLMENT Search Operation tail

'Grid STUDENT_STUDENT_ENROLMENT1 Bind @2-1A089A16

    Protected Sub STUDENT_STUDENT_ENROLMENT1Bind()
        If Not STUDENT_STUDENT_ENROLMENT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_STUDENT_ENROLMENT1",GetType(STUDENT_STUDENT_ENROLMENT1DataProvider.SortFields), 80, 100)
        End If
'End Grid STUDENT_STUDENT_ENROLMENT1 Bind

'Grid Form STUDENT_STUDENT_ENROLMENT1 BeforeShow tail @2-0C8E5C8B
        STUDENT_STUDENT_ENROLMENT1Parameters()
        STUDENT_STUDENT_ENROLMENT1Data.SortField = CType(ViewState("STUDENT_STUDENT_ENROLMENT1SortField"),STUDENT_STUDENT_ENROLMENT1DataProvider.SortFields)
        STUDENT_STUDENT_ENROLMENT1Data.SortDir = CType(ViewState("STUDENT_STUDENT_ENROLMENT1SortDir"),SortDirections)
        STUDENT_STUDENT_ENROLMENT1Data.PageNumber = CInt(ViewState("STUDENT_STUDENT_ENROLMENT1PageNumber"))
        STUDENT_STUDENT_ENROLMENT1Data.RecordsPerPage = CInt(ViewState("STUDENT_STUDENT_ENROLMENT1PageSize"))
        STUDENT_STUDENT_ENROLMENT1Repeater.DataSource = STUDENT_STUDENT_ENROLMENT1Data.GetResultSet(PagesCount, STUDENT_STUDENT_ENROLMENT1Operations)
        ViewState("STUDENT_STUDENT_ENROLMENT1PagesCount") = PagesCount
        Dim item As STUDENT_STUDENT_ENROLMENT1Item = New STUDENT_STUDENT_ENROLMENT1Item()
        STUDENT_STUDENT_ENROLMENT1Repeater.DataBind
        FooterIndex = STUDENT_STUDENT_ENROLMENT1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_STUDENT_ENROLMENT1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_STUDENT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_STUDENT_STUDENT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRST_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_FIRST_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEXSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_SEXSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_STUDENT_ENROLMENT1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form STUDENT_STUDENT_ENROLMENT1 BeforeShow tail

'Grid STUDENT_STUDENT_ENROLMENT1 Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_STUDENT_ENROLMENT1 Bind tail

'Grid STUDENT_STUDENT_ENROLMENT1 Table Parameters @2-68EE6930

    Protected Sub STUDENT_STUDENT_ENROLMENT1Parameters()
        Try
            STUDENT_STUDENT_ENROLMENT1Data.Urls_SURNAME = TextParameter.GetParam("s_SURNAME", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_STUDENT_ENROLMENT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_STUDENT_ENROLMENT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_STUDENT_ENROLMENT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_STUDENT_ENROLMENT1 Table Parameters

'Grid STUDENT_STUDENT_ENROLMENT1 ItemDataBound event @2-D09B6600

    Protected Sub STUDENT_STUDENT_ENROLMENT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_STUDENT_ENROLMENT1Item = CType(e.Item.DataItem,STUDENT_STUDENT_ENROLMENT1Item)
        Dim Item as STUDENT_STUDENT_ENROLMENT1Item = DataItem
        Dim FormDataSource As STUDENT_STUDENT_ENROLMENT1Item() = CType(STUDENT_STUDENT_ENROLMENT1Repeater.DataSource, STUDENT_STUDENT_ENROLMENT1Item())
        Dim STUDENT_STUDENT_ENROLMENT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_STUDENT_ENROLMENT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_STUDENT_ENROLMENT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_STUDENT_ENROLMENT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_STUDENT_ENROLMENT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_STUDENT_ENROLMENT1STUDENT_STUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1STUDENT_STUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_STUDENT_ENROLMENT1SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_STUDENT_ENROLMENT1FIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1FIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_STUDENT_ENROLMENT1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_STUDENT_ENROLMENT1SEX As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1SEX"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_STUDENT_ENROLMENT1ENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_STUDENT_ENROLMENT1ENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_STUDENT_IDHref = ""
            STUDENT_STUDENT_ENROLMENT1STUDENT_STUDENT_ID.HRef = DataItem.STUDENT_STUDENT_IDHref & DataItem.STUDENT_STUDENT_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STUDENT_STUDENT_ENROLMENT1 ItemDataBound event

'Grid STUDENT_STUDENT_ENROLMENT1 BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STUDENT_STUDENT_ENROLMENT1 BeforeShowRow event

'Grid STUDENT_STUDENT_ENROLMENT1 Event BeforeShowRow. Action Set Row Style @24-F2A33BF2
            Dim styles24 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex24 As Integer = (STUDENT_STUDENT_ENROLMENT1CurrentRowNumber - 1) Mod styles24.Length
            Dim rawStyle24 As String = styles24(styleIndex24).Replace("\;",";")
            If rawStyle24.IndexOf("=") = -1 And rawStyle24.IndexOf(":") > -1 Then
                rawStyle24 = "style=""" + rawStyle24 + """"
            ElseIf rawStyle24.IndexOf("=") = -1 And rawStyle24.IndexOf(":") = -1 And rawStyle24 <> "" Then
                rawStyle24 = "class=""" + rawStyle24 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(STUDENT_STUDENT_ENROLMENT1Repeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle24), AttributeOption.Multiple)
'End Grid STUDENT_STUDENT_ENROLMENT1 Event BeforeShowRow. Action Set Row Style

'Grid STUDENT_STUDENT_ENROLMENT1 BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid STUDENT_STUDENT_ENROLMENT1 BeforeShowRow event tail

'Grid STUDENT_STUDENT_ENROLMENT1 ItemDataBound event tail @2-B60F1A2A
        If STUDENT_STUDENT_ENROLMENT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_STUDENT_ENROLMENT1CurrentRowNumber, ListItemType.Item)
            STUDENT_STUDENT_ENROLMENT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_STUDENT_ENROLMENT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_STUDENT_ENROLMENT1 ItemDataBound event tail

'Grid STUDENT_STUDENT_ENROLMENT1 ItemCommand event @2-CFA18A8A

    Protected Sub STUDENT_STUDENT_ENROLMENT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_STUDENT_ENROLMENT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_STUDENT_ENROLMENT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_STUDENT_ENROLMENT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_STUDENT_ENROLMENT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_STUDENT_ENROLMENT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_STUDENT_ENROLMENT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_STUDENT_ENROLMENT1DataProvider.SortFields = 0
            ViewState("STUDENT_STUDENT_ENROLMENT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_STUDENT_ENROLMENT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_STUDENT_ENROLMENT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_STUDENT_ENROLMENT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_STUDENT_ENROLMENT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_STUDENT_ENROLMENT1Bind
        End If
    End Sub
'End Grid STUDENT_STUDENT_ENROLMENT1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-AA2D18D8
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        popup_StudentSearchContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_STUDENT_ENROLMENTData = New STUDENT_STUDENT_ENROLMENTDataProvider()
        STUDENT_STUDENT_ENROLMENTOperations = New FormSupportedOperations(False, True, True, True, True)
        STUDENT_STUDENT_ENROLMENT1Data = New STUDENT_STUDENT_ENROLMENT1DataProvider()
        STUDENT_STUDENT_ENROLMENT1Operations = New FormSupportedOperations(False, True, False, False, False)
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

