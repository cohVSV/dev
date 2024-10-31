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

Namespace DECV_PROD2007.popup_StudentSubjectSearch 'Namespace @1-FBBB71AD

'Forms Definition @1-689D4C44
Public Class [popup_StudentSubjectSearchPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-736587E2
    Protected STUDENT_SUBJECT_SUBJECTData As STUDENT_SUBJECT_SUBJECTDataProvider
    Protected STUDENT_SUBJECT_SUBJECTErrors As NameValueCollection = New NameValueCollection()
    Protected STUDENT_SUBJECT_SUBJECTOperations As FormSupportedOperations
    Protected STUDENT_SUBJECT_SUBJECTIsSubmitted As Boolean = False
    Protected STUDENT_SUBJECT_SUBJECT1Data As STUDENT_SUBJECT_SUBJECT1DataProvider
    Protected STUDENT_SUBJECT_SUBJECT1Operations As FormSupportedOperations
    Protected STUDENT_SUBJECT_SUBJECT1CurrentRowNumber As Integer
    Protected popup_StudentSubjectSearchContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-6E60C8BB
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_SUBJECT_SUBJECTShow()
            STUDENT_SUBJECT_SUBJECT1Bind
    End If
'End Page_Load Event BeforeIsPostBack

'Page popup_StudentSubjectSearch Event BeforeShow. Action Hide-Show Component @47-2D464D34
        Dim Urls_STUDENT_ID_47_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_STUDENT_ID"))
        Dim ExprParam2_47_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_STUDENT_ID_47_1, ExprParam2_47_2) Then
            STUDENT_SUBJECT_SUBJECT1Repeater.Visible = False
        End If
'End Page popup_StudentSubjectSearch Event BeforeShow. Action Hide-Show Component

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STUDENT_SUBJECT_SUBJECT Parameters @19-8F0DD24E

    Protected Sub STUDENT_SUBJECT_SUBJECTParameters()
        Dim item As new STUDENT_SUBJECT_SUBJECTItem
        Try
        Catch e As Exception
            STUDENT_SUBJECT_SUBJECTErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT Parameters

'Record Form STUDENT_SUBJECT_SUBJECT Show method @19-279B3391
    Protected Sub STUDENT_SUBJECT_SUBJECTShow()
        If STUDENT_SUBJECT_SUBJECTOperations.None Then
            STUDENT_SUBJECT_SUBJECTHolder.Visible = False
            Return
        End If
        Dim item As STUDENT_SUBJECT_SUBJECTItem = STUDENT_SUBJECT_SUBJECTItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STUDENT_SUBJECT_SUBJECTOperations.AllowRead
        STUDENT_SUBJECT_SUBJECTErrors.Add(item.errors)
        If STUDENT_SUBJECT_SUBJECTErrors.Count > 0 Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
            Return
        End If
'End Record Form STUDENT_SUBJECT_SUBJECT Show method

'Record Form STUDENT_SUBJECT_SUBJECT BeforeShow tail @19-6D589363
        STUDENT_SUBJECT_SUBJECTParameters()
        STUDENT_SUBJECT_SUBJECTData.FillItem(item, IsInsertMode)
        STUDENT_SUBJECT_SUBJECTHolder.DataBind()
        STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.Text=item.s_STUDENT_ID.GetFormattedValue()
'End Record Form STUDENT_SUBJECT_SUBJECT BeforeShow tail

'TextBox s_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control @48-D7806B58
            STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.Text = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("p_STUDENTID"))).GetFormattedValue()
'End TextBox s_STUDENT_ID Event BeforeShow. Action Retrieve Value for Control

'Record Form STUDENT_SUBJECT_SUBJECT Show method tail @19-092DFE28
        If STUDENT_SUBJECT_SUBJECTErrors.Count > 0 Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
        End If
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT Show method tail

'Record Form STUDENT_SUBJECT_SUBJECT LoadItemFromRequest method @19-CE8EDB48

    Protected Sub STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item As STUDENT_SUBJECT_SUBJECTItem, ByVal EnableValidation As Boolean)
        Try
        item.s_STUDENT_ID.IsEmpty = IsNothing(Request.Form(STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.UniqueID))
        If ControlCustomValues("STUDENT_SUBJECT_SUBJECTs_STUDENT_ID") Is Nothing Then
            item.s_STUDENT_ID.SetValue(STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.Text)
        Else
            item.s_STUDENT_ID.SetValue(ControlCustomValues("STUDENT_SUBJECT_SUBJECTs_STUDENT_ID"))
        End If
        Catch ae As ArgumentException
            STUDENT_SUBJECT_SUBJECTErrors.Add("s_STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"s_STUDENT_ID"))
        End Try
        If EnableValidation Then
            item.Validate(STUDENT_SUBJECT_SUBJECTData)
        End If
        STUDENT_SUBJECT_SUBJECTErrors.Add(item.errors)
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT LoadItemFromRequest method

'Record Form STUDENT_SUBJECT_SUBJECT GetRedirectUrl method @19-8AA7FC39

    Protected Function GetSTUDENT_SUBJECT_SUBJECTRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "popup_StudentSubjectSearch.aspx"
        Dim p As String = parameters.ToString("All",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STUDENT_SUBJECT_SUBJECT GetRedirectUrl method

'Record Form STUDENT_SUBJECT_SUBJECT ShowErrors method @19-4CD31E1C

    Protected Sub STUDENT_SUBJECT_SUBJECTShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STUDENT_SUBJECT_SUBJECTErrors.Count - 1
        Select Case STUDENT_SUBJECT_SUBJECTErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STUDENT_SUBJECT_SUBJECTErrors(i)
        End Select
        Next i
        STUDENT_SUBJECT_SUBJECTError.Visible = True
        STUDENT_SUBJECT_SUBJECTErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT ShowErrors method

'Record Form STUDENT_SUBJECT_SUBJECT Insert Operation @19-2A971467

    Protected Sub STUDENT_SUBJECT_SUBJECT_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        STUDENT_SUBJECT_SUBJECTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_SUBJECT_SUBJECT Insert Operation

'Record Form STUDENT_SUBJECT_SUBJECT BeforeInsert tail @19-83FACB1C
    STUDENT_SUBJECT_SUBJECTParameters()
    STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_SUBJECT_SUBJECT BeforeInsert tail

'Record Form STUDENT_SUBJECT_SUBJECT AfterInsert tail  @19-6D0336DB
        ErrorFlag=(STUDENT_SUBJECT_SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT AfterInsert tail 

'Record Form STUDENT_SUBJECT_SUBJECT Update Operation @19-B0E5CDAE

    Protected Sub STUDENT_SUBJECT_SUBJECT_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STUDENT_SUBJECT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STUDENT_SUBJECT_SUBJECT Update Operation

'Record Form STUDENT_SUBJECT_SUBJECT Before Update tail @19-83FACB1C
        STUDENT_SUBJECT_SUBJECTParameters()
        STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_SUBJECT_SUBJECT Before Update tail

'Record Form STUDENT_SUBJECT_SUBJECT Update Operation tail @19-6D0336DB
        ErrorFlag=(STUDENT_SUBJECT_SUBJECTErrors.Count > 0)
        If ErrorFlag Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT Update Operation tail

'Record Form STUDENT_SUBJECT_SUBJECT Delete Operation @19-44A5335D
    Protected Sub STUDENT_SUBJECT_SUBJECT_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STUDENT_SUBJECT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STUDENT_SUBJECT_SUBJECT Delete Operation

'Record Form BeforeDelete tail @19-83FACB1C
        STUDENT_SUBJECT_SUBJECTParameters()
        STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @19-856267CB
        If ErrorFlag Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STUDENT_SUBJECT_SUBJECT Cancel Operation @19-8A5A2EDC

    Protected Sub STUDENT_SUBJECT_SUBJECT_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        STUDENT_SUBJECT_SUBJECTIsSubmitted = True
        Dim RedirectUrl As String = ""
        STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item, True)
'End Record Form STUDENT_SUBJECT_SUBJECT Cancel Operation

'Record Form STUDENT_SUBJECT_SUBJECT Cancel Operation tail @19-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT Cancel Operation tail

'Record Form STUDENT_SUBJECT_SUBJECT Search Operation @19-B522FBBC
    Protected Sub STUDENT_SUBJECT_SUBJECT_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STUDENT_SUBJECT_SUBJECTIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STUDENT_SUBJECT_SUBJECTItem = New STUDENT_SUBJECT_SUBJECTItem()
        STUDENT_SUBJECT_SUBJECTLoadItemFromRequest(item, EnableValidation)
'End Record Form STUDENT_SUBJECT_SUBJECT Search Operation

'Button Button_DoSearch OnClick. @20-6E4D9C4A
        If CType(sender,Control).ID = "STUDENT_SUBJECT_SUBJECTButton_DoSearch" Then
            RedirectUrl = GetSTUDENT_SUBJECT_SUBJECTRedirectUrl("", "s_STUDENT_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @20-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STUDENT_SUBJECT_SUBJECT Search Operation tail @19-938FEFED
        ErrorFlag = STUDENT_SUBJECT_SUBJECTErrors.Count > 0
        If ErrorFlag Then
            STUDENT_SUBJECT_SUBJECTShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.Text <> "",("s_STUDENT_ID=" & Server.UrlEncode(STUDENT_SUBJECT_SUBJECTs_STUDENT_ID.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STUDENT_SUBJECT_SUBJECT Search Operation tail

'Grid STUDENT_SUBJECT_SUBJECT1 Bind @2-0887F7F6

    Protected Sub STUDENT_SUBJECT_SUBJECT1Bind()
        If Not STUDENT_SUBJECT_SUBJECT1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_SUBJECT_SUBJECT1",GetType(STUDENT_SUBJECT_SUBJECT1DataProvider.SortFields), 80, 100)
        End If
'End Grid STUDENT_SUBJECT_SUBJECT1 Bind

'Grid Form STUDENT_SUBJECT_SUBJECT1 BeforeShow tail @2-DE26734B
        STUDENT_SUBJECT_SUBJECT1Parameters()
        STUDENT_SUBJECT_SUBJECT1Data.SortField = CType(ViewState("STUDENT_SUBJECT_SUBJECT1SortField"),STUDENT_SUBJECT_SUBJECT1DataProvider.SortFields)
        STUDENT_SUBJECT_SUBJECT1Data.SortDir = CType(ViewState("STUDENT_SUBJECT_SUBJECT1SortDir"),SortDirections)
        STUDENT_SUBJECT_SUBJECT1Data.PageNumber = CInt(ViewState("STUDENT_SUBJECT_SUBJECT1PageNumber"))
        STUDENT_SUBJECT_SUBJECT1Data.RecordsPerPage = CInt(ViewState("STUDENT_SUBJECT_SUBJECT1PageSize"))
        STUDENT_SUBJECT_SUBJECT1Repeater.DataSource = STUDENT_SUBJECT_SUBJECT1Data.GetResultSet(PagesCount, STUDENT_SUBJECT_SUBJECT1Operations)
        ViewState("STUDENT_SUBJECT_SUBJECT1PagesCount") = PagesCount
        Dim item As STUDENT_SUBJECT_SUBJECT1Item = New STUDENT_SUBJECT_SUBJECT1Item()
        STUDENT_SUBJECT_SUBJECT1Repeater.DataBind
        FooterIndex = STUDENT_SUBJECT_SUBJECT1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_SUBJECT_SUBJECT1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_STUDENT_SUBJECT_SUBJECT_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_STUDENT_SUBJECT_SUBJECT_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_ABBREVSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_SUBJECT_ABBREVSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJECT_TITLESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_SUBJECT_TITLESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SEMESTERSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_SEMESTERSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_YEAR_LEVELSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_YEAR_LEVELSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SUBJ_ENROL_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_SUBJ_ENROL_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_WITHDRAWAL_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_WITHDRAWAL_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_ENROLMENT_YEARSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(0).FindControl("Sorter_ENROLMENT_YEARSorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_SUBJECT_SUBJECT1Repeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

'End Grid Form STUDENT_SUBJECT_SUBJECT1 BeforeShow tail

'Grid STUDENT_SUBJECT_SUBJECT1 Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_SUBJECT_SUBJECT1 Bind tail

'Grid STUDENT_SUBJECT_SUBJECT1 Table Parameters @2-50BD1CAF

    Protected Sub STUDENT_SUBJECT_SUBJECT1Parameters()
        Try
            STUDENT_SUBJECT_SUBJECT1Data.Urls_STUDENT_ID = FloatParameter.GetParam("s_STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_SUBJECT_SUBJECT1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_SUBJECT_SUBJECT1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_SUBJECT_SUBJECT1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_SUBJECT_SUBJECT1 Table Parameters

'Grid STUDENT_SUBJECT_SUBJECT1 ItemDataBound event @2-70CFDCE0

    Protected Sub STUDENT_SUBJECT_SUBJECT1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_SUBJECT_SUBJECT1Item = CType(e.Item.DataItem,STUDENT_SUBJECT_SUBJECT1Item)
        Dim Item as STUDENT_SUBJECT_SUBJECT1Item = DataItem
        Dim FormDataSource As STUDENT_SUBJECT_SUBJECT1Item() = CType(STUDENT_SUBJECT_SUBJECT1Repeater.DataSource, STUDENT_SUBJECT_SUBJECT1Item())
        Dim STUDENT_SUBJECT_SUBJECT1DataRows As Integer = FormDataSource.Length
        Dim STUDENT_SUBJECT_SUBJECT1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_SUBJECT_SUBJECT1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_SUBJECT_SUBJECT1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_SUBJECT_SUBJECT1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_SUBJECT_SUBJECT1STUDENT_SUBJECT_SUBJECT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1STUDENT_SUBJECT_SUBJECT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STUDENT_SUBJECT_SUBJECT1SUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1SUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1SUBJECT_TITLE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1SUBJECT_TITLE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1SEMESTER As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1SEMESTER"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1YEAR_LEVEL As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1YEAR_LEVEL"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1SUBJ_ENROL_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1SUBJ_ENROL_STATUS"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1STAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1STAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1ENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1ENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1WITHDRAWAL_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1WITHDRAWAL_DATE"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SUBJECT_SUBJECT1ENROLMENT_YEAR As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SUBJECT_SUBJECT1ENROLMENT_YEAR"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_SUBJECT_SUBJECT_IDHref = ""
            STUDENT_SUBJECT_SUBJECT1STUDENT_SUBJECT_SUBJECT_ID.HRef = DataItem.STUDENT_SUBJECT_SUBJECT_IDHref & DataItem.STUDENT_SUBJECT_SUBJECT_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STUDENT_SUBJECT_SUBJECT1 ItemDataBound event

'Grid STUDENT_SUBJECT_SUBJECT1 BeforeShowRow event @2-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid STUDENT_SUBJECT_SUBJECT1 BeforeShowRow event

'Grid STUDENT_SUBJECT_SUBJECT1 Event BeforeShowRow. Action Set Row Style @33-C236FC8B
            Dim styles33 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex33 As Integer = (STUDENT_SUBJECT_SUBJECT1CurrentRowNumber - 1) Mod styles33.Length
            Dim rawStyle33 As String = styles33(styleIndex33).Replace("\;",";")
            If rawStyle33.IndexOf("=") = -1 And rawStyle33.IndexOf(":") > -1 Then
                rawStyle33 = "style=""" + rawStyle33 + """"
            ElseIf rawStyle33.IndexOf("=") = -1 And rawStyle33.IndexOf(":") = -1 And rawStyle33 <> "" Then
                rawStyle33 = "class=""" + rawStyle33 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(STUDENT_SUBJECT_SUBJECT1Repeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle33), AttributeOption.Multiple)
'End Grid STUDENT_SUBJECT_SUBJECT1 Event BeforeShowRow. Action Set Row Style

'Grid STUDENT_SUBJECT_SUBJECT1 BeforeShowRow event tail @2-477CF3C9
        End If
'End Grid STUDENT_SUBJECT_SUBJECT1 BeforeShowRow event tail

'Grid STUDENT_SUBJECT_SUBJECT1 ItemDataBound event tail @2-FC55A090
        If STUDENT_SUBJECT_SUBJECT1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_SUBJECT_SUBJECT1CurrentRowNumber, ListItemType.Item)
            STUDENT_SUBJECT_SUBJECT1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_SUBJECT_SUBJECT1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_SUBJECT_SUBJECT1 ItemDataBound event tail

'Grid STUDENT_SUBJECT_SUBJECT1 ItemCommand event @2-8F4DA804

    Protected Sub STUDENT_SUBJECT_SUBJECT1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_SUBJECT_SUBJECT1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_SUBJECT_SUBJECT1SortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_SUBJECT_SUBJECT1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_SUBJECT_SUBJECT1SortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_SUBJECT_SUBJECT1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_SUBJECT_SUBJECT1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_SUBJECT_SUBJECT1DataProvider.SortFields = 0
            ViewState("STUDENT_SUBJECT_SUBJECT1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_SUBJECT_SUBJECT1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_SUBJECT_SUBJECT1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_SUBJECT_SUBJECT1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_SUBJECT_SUBJECT1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_SUBJECT_SUBJECT1Bind
        End If
    End Sub
'End Grid STUDENT_SUBJECT_SUBJECT1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-CAE02993
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        popup_StudentSubjectSearchContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_SUBJECT_SUBJECTData = New STUDENT_SUBJECT_SUBJECTDataProvider()
        STUDENT_SUBJECT_SUBJECTOperations = New FormSupportedOperations(False, True, True, True, True)
        STUDENT_SUBJECT_SUBJECT1Data = New STUDENT_SUBJECT_SUBJECT1DataProvider()
        STUDENT_SUBJECT_SUBJECT1Operations = New FormSupportedOperations(False, True, False, False, False)
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

