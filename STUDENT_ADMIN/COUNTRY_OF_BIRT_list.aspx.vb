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

Namespace DECV_PROD2007.COUNTRY_OF_BIRT_list 'Namespace @1-6856B54F

'Forms Definition @1-DA3DCBD8
Public Class [COUNTRY_OF_BIRT_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-B099D779
    Protected COUNTRY_OF_BIRTHSearchData As COUNTRY_OF_BIRTHSearchDataProvider
    Protected COUNTRY_OF_BIRTHSearchErrors As NameValueCollection = New NameValueCollection()
    Protected COUNTRY_OF_BIRTHSearchOperations As FormSupportedOperations
    Protected COUNTRY_OF_BIRTHSearchIsSubmitted As Boolean = False
    Protected COUNTRY_OF_BIRTHData As COUNTRY_OF_BIRTHDataProvider
    Protected COUNTRY_OF_BIRTHOperations As FormSupportedOperations
    Protected COUNTRY_OF_BIRTHCurrentRowNumber As Integer
    Protected COUNTRY_OF_BIRT_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-286CE774
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            COUNTRY_OF_BIRTHSearchShow()
            COUNTRY_OF_BIRTHBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form COUNTRY_OF_BIRTHSearch Parameters @2-CAA52A02

    Protected Sub COUNTRY_OF_BIRTHSearchParameters()
        Dim item As new COUNTRY_OF_BIRTHSearchItem
        Try
        Catch e As Exception
            COUNTRY_OF_BIRTHSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch Parameters

'Record Form COUNTRY_OF_BIRTHSearch Show method @2-4C55266A
    Protected Sub COUNTRY_OF_BIRTHSearchShow()
        If COUNTRY_OF_BIRTHSearchOperations.None Then
            COUNTRY_OF_BIRTHSearchHolder.Visible = False
            Return
        End If
        Dim item As COUNTRY_OF_BIRTHSearchItem = COUNTRY_OF_BIRTHSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not COUNTRY_OF_BIRTHSearchOperations.AllowRead
        COUNTRY_OF_BIRTHSearchErrors.Add(item.errors)
        If COUNTRY_OF_BIRTHSearchErrors.Count > 0 Then
            COUNTRY_OF_BIRTHSearchShowErrors()
            Return
        End If
'End Record Form COUNTRY_OF_BIRTHSearch Show method

'Record Form COUNTRY_OF_BIRTHSearch BeforeShow tail @2-A3E5ACFF
        COUNTRY_OF_BIRTHSearchParameters()
        COUNTRY_OF_BIRTHSearchData.FillItem(item, IsInsertMode)
        COUNTRY_OF_BIRTHSearchHolder.DataBind()
        COUNTRY_OF_BIRTHSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form COUNTRY_OF_BIRTHSearch BeforeShow tail

'Record Form COUNTRY_OF_BIRTHSearch Show method tail @2-4075566F
        If COUNTRY_OF_BIRTHSearchErrors.Count > 0 Then
            COUNTRY_OF_BIRTHSearchShowErrors()
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch Show method tail

'Record Form COUNTRY_OF_BIRTHSearch LoadItemFromRequest method @2-293E2FB7

    Protected Sub COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item As COUNTRY_OF_BIRTHSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(COUNTRY_OF_BIRTHSearchs_keyword.UniqueID))
        If ControlCustomValues("COUNTRY_OF_BIRTHSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(COUNTRY_OF_BIRTHSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("COUNTRY_OF_BIRTHSearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(COUNTRY_OF_BIRTHSearchData)
        End If
        COUNTRY_OF_BIRTHSearchErrors.Add(item.errors)
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch LoadItemFromRequest method

'Record Form COUNTRY_OF_BIRTHSearch GetRedirectUrl method @2-DC82C2F7

    Protected Function GetCOUNTRY_OF_BIRTHSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "COUNTRY_OF_BIRT_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form COUNTRY_OF_BIRTHSearch GetRedirectUrl method

'Record Form COUNTRY_OF_BIRTHSearch ShowErrors method @2-B31CD0AF

    Protected Sub COUNTRY_OF_BIRTHSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To COUNTRY_OF_BIRTHSearchErrors.Count - 1
        Select Case COUNTRY_OF_BIRTHSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & COUNTRY_OF_BIRTHSearchErrors(i)
        End Select
        Next i
        COUNTRY_OF_BIRTHSearchError.Visible = True
        COUNTRY_OF_BIRTHSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch ShowErrors method

'Record Form COUNTRY_OF_BIRTHSearch Insert Operation @2-60356B31

    Protected Sub COUNTRY_OF_BIRTHSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        COUNTRY_OF_BIRTHSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COUNTRY_OF_BIRTHSearch Insert Operation

'Record Form COUNTRY_OF_BIRTHSearch BeforeInsert tail @2-E98535D4
    COUNTRY_OF_BIRTHSearchParameters()
    COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COUNTRY_OF_BIRTHSearch BeforeInsert tail

'Record Form COUNTRY_OF_BIRTHSearch AfterInsert tail  @2-AA85B913
        ErrorFlag=(COUNTRY_OF_BIRTHSearchErrors.Count > 0)
        If ErrorFlag Then
            COUNTRY_OF_BIRTHSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch AfterInsert tail 

'Record Form COUNTRY_OF_BIRTHSearch Update Operation @2-8D7EF5AA

    Protected Sub COUNTRY_OF_BIRTHSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        COUNTRY_OF_BIRTHSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COUNTRY_OF_BIRTHSearch Update Operation

'Record Form COUNTRY_OF_BIRTHSearch Before Update tail @2-E98535D4
        COUNTRY_OF_BIRTHSearchParameters()
        COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COUNTRY_OF_BIRTHSearch Before Update tail

'Record Form COUNTRY_OF_BIRTHSearch Update Operation tail @2-AA85B913
        ErrorFlag=(COUNTRY_OF_BIRTHSearchErrors.Count > 0)
        If ErrorFlag Then
            COUNTRY_OF_BIRTHSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch Update Operation tail

'Record Form COUNTRY_OF_BIRTHSearch Delete Operation @2-CF2C9C69
    Protected Sub COUNTRY_OF_BIRTHSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        COUNTRY_OF_BIRTHSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form COUNTRY_OF_BIRTHSearch Delete Operation

'Record Form BeforeDelete tail @2-E98535D4
        COUNTRY_OF_BIRTHSearchParameters()
        COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-6C4FB76D
        If ErrorFlag Then
            COUNTRY_OF_BIRTHSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form COUNTRY_OF_BIRTHSearch Cancel Operation @2-F00F4023

    Protected Sub COUNTRY_OF_BIRTHSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        COUNTRY_OF_BIRTHSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item, True)
'End Record Form COUNTRY_OF_BIRTHSearch Cancel Operation

'Record Form COUNTRY_OF_BIRTHSearch Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch Cancel Operation tail

'Record Form COUNTRY_OF_BIRTHSearch Search Operation @2-3800824C
    Protected Sub COUNTRY_OF_BIRTHSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        COUNTRY_OF_BIRTHSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        COUNTRY_OF_BIRTHSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COUNTRY_OF_BIRTHSearch Search Operation

'Button Button_DoSearch OnClick. @3-063A0FC5
        If CType(sender,Control).ID = "COUNTRY_OF_BIRTHSearchButton_DoSearch" Then
            RedirectUrl = GetCOUNTRY_OF_BIRTHSearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @3-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form COUNTRY_OF_BIRTHSearch Search Operation tail @2-3857B15E
        ErrorFlag = COUNTRY_OF_BIRTHSearchErrors.Count > 0
        If ErrorFlag Then
            COUNTRY_OF_BIRTHSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(COUNTRY_OF_BIRTHSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(COUNTRY_OF_BIRTHSearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COUNTRY_OF_BIRTHSearch Search Operation tail

'Grid COUNTRY_OF_BIRTH Bind @5-7BD00CE1

    Protected Sub COUNTRY_OF_BIRTHBind()
        If Not COUNTRY_OF_BIRTHOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"COUNTRY_OF_BIRTH",GetType(COUNTRY_OF_BIRTHDataProvider.SortFields), 20, 100)
        End If
'End Grid COUNTRY_OF_BIRTH Bind

'Grid Form COUNTRY_OF_BIRTH BeforeShow tail @5-117E90E2
        COUNTRY_OF_BIRTHParameters()
        COUNTRY_OF_BIRTHData.SortField = CType(ViewState("COUNTRY_OF_BIRTHSortField"),COUNTRY_OF_BIRTHDataProvider.SortFields)
        COUNTRY_OF_BIRTHData.SortDir = CType(ViewState("COUNTRY_OF_BIRTHSortDir"),SortDirections)
        COUNTRY_OF_BIRTHData.PageNumber = CInt(ViewState("COUNTRY_OF_BIRTHPageNumber"))
        COUNTRY_OF_BIRTHData.RecordsPerPage = CInt(ViewState("COUNTRY_OF_BIRTHPageSize"))
        COUNTRY_OF_BIRTHRepeater.DataSource = COUNTRY_OF_BIRTHData.GetResultSet(PagesCount, COUNTRY_OF_BIRTHOperations)
        ViewState("COUNTRY_OF_BIRTHPagesCount") = PagesCount
        Dim item As COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
        COUNTRY_OF_BIRTHRepeater.DataBind
        FooterIndex = COUNTRY_OF_BIRTHRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            COUNTRY_OF_BIRTHRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim COUNTRY_OF_BIRTHCOUNTRY_OF_BIRTH_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(FooterIndex).FindControl("COUNTRY_OF_BIRTHCOUNTRY_OF_BIRTH_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_COUNTRY_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(0).FindControl("Sorter_COUNTRY_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COUNTRY_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(0).FindControl("Sorter_COUNTRY_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(COUNTRY_OF_BIRTHRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.COUNTRY_OF_BIRTH_InsertHref = "COUNTRY_OF_BIRT_maint.aspx"
        COUNTRY_OF_BIRTHCOUNTRY_OF_BIRTH_Insert.InnerText += item.COUNTRY_OF_BIRTH_Insert.GetFormattedValue().Replace(vbCrLf,"")
        COUNTRY_OF_BIRTHCOUNTRY_OF_BIRTH_Insert.HRef = item.COUNTRY_OF_BIRTH_InsertHref+item.COUNTRY_OF_BIRTH_InsertHrefParameters.ToString("GET","COUNTRY_ID", ViewState)
'End Grid Form COUNTRY_OF_BIRTH BeforeShow tail

'Grid COUNTRY_OF_BIRTH Bind tail @5-E31F8E2A
    End Sub
'End Grid COUNTRY_OF_BIRTH Bind tail

'Grid COUNTRY_OF_BIRTH Table Parameters @5-A3C629D4

    Protected Sub COUNTRY_OF_BIRTHParameters()
        Try
            COUNTRY_OF_BIRTHData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=COUNTRY_OF_BIRTHRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(COUNTRY_OF_BIRTHRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid COUNTRY_OF_BIRTH: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid COUNTRY_OF_BIRTH Table Parameters

'Grid COUNTRY_OF_BIRTH ItemDataBound event @5-C63B7BDC

    Protected Sub COUNTRY_OF_BIRTHItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as COUNTRY_OF_BIRTHItem = CType(e.Item.DataItem,COUNTRY_OF_BIRTHItem)
        Dim Item as COUNTRY_OF_BIRTHItem = DataItem
        Dim FormDataSource As COUNTRY_OF_BIRTHItem() = CType(COUNTRY_OF_BIRTHRepeater.DataSource, COUNTRY_OF_BIRTHItem())
        Dim COUNTRY_OF_BIRTHDataRows As Integer = FormDataSource.Length
        Dim COUNTRY_OF_BIRTHIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            COUNTRY_OF_BIRTHCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(COUNTRY_OF_BIRTHRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, COUNTRY_OF_BIRTHCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim COUNTRY_OF_BIRTHCOUNTRY_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHCOUNTRY_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim COUNTRY_OF_BIRTHCOUNTRY_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHCOUNTRY_NAME"),System.Web.UI.WebControls.Literal)
            Dim COUNTRY_OF_BIRTHLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim COUNTRY_OF_BIRTHLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.COUNTRY_IDHref = "COUNTRY_OF_BIRT_maint.aspx"
            COUNTRY_OF_BIRTHCOUNTRY_ID.HRef = DataItem.COUNTRY_IDHref & DataItem.COUNTRY_IDHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim COUNTRY_OF_BIRTHAlt_COUNTRY_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHAlt_COUNTRY_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim COUNTRY_OF_BIRTHAlt_COUNTRY_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHAlt_COUNTRY_NAME"),System.Web.UI.WebControls.Literal)
            Dim COUNTRY_OF_BIRTHAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim COUNTRY_OF_BIRTHAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COUNTRY_OF_BIRTHAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_COUNTRY_IDHref = "COUNTRY_OF_BIRT_maint.aspx"
            COUNTRY_OF_BIRTHAlt_COUNTRY_ID.HRef = DataItem.Alt_COUNTRY_IDHref & DataItem.Alt_COUNTRY_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid COUNTRY_OF_BIRTH ItemDataBound event

'Grid COUNTRY_OF_BIRTH ItemDataBound event tail @5-0C5F2B67
        If COUNTRY_OF_BIRTHIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(COUNTRY_OF_BIRTHCurrentRowNumber, ListItemType.AlternatingItem)
                COUNTRY_OF_BIRTHRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(COUNTRY_OF_BIRTHCurrentRowNumber, ListItemType.Item)
                COUNTRY_OF_BIRTHRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            COUNTRY_OF_BIRTHItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid COUNTRY_OF_BIRTH ItemDataBound event tail

'Grid COUNTRY_OF_BIRTH ItemCommand event @5-38DC5F21

    Protected Sub COUNTRY_OF_BIRTHItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= COUNTRY_OF_BIRTHRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("COUNTRY_OF_BIRTHSortDir"),SortDirections) = SortDirections._Asc And ViewState("COUNTRY_OF_BIRTHSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("COUNTRY_OF_BIRTHSortDir")=SortDirections._Desc
                Else
                    ViewState("COUNTRY_OF_BIRTHSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("COUNTRY_OF_BIRTHSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As COUNTRY_OF_BIRTHDataProvider.SortFields = 0
            ViewState("COUNTRY_OF_BIRTHSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("COUNTRY_OF_BIRTHPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("COUNTRY_OF_BIRTHPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("COUNTRY_OF_BIRTHPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("COUNTRY_OF_BIRTHPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            COUNTRY_OF_BIRTHBind
        End If
    End Sub
'End Grid COUNTRY_OF_BIRTH ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-84F76D06
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        COUNTRY_OF_BIRT_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        COUNTRY_OF_BIRTHSearchData = New COUNTRY_OF_BIRTHSearchDataProvider()
        COUNTRY_OF_BIRTHSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        COUNTRY_OF_BIRTHData = New COUNTRY_OF_BIRTHDataProvider()
        COUNTRY_OF_BIRTHOperations = New FormSupportedOperations(False, True, False, False, False)
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

