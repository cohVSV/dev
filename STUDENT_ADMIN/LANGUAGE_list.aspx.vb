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

Namespace DECV_PROD2007.LANGUAGE_list 'Namespace @1-3864DF94

'Forms Definition @1-326A3F4E
Public Class [LANGUAGE_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-F13FC2DA
    Protected LANGUAGEData As LANGUAGEDataProvider
    Protected LANGUAGEOperations As FormSupportedOperations
    Protected LANGUAGECurrentRowNumber As Integer
    Protected LANGUAGE1Data As LANGUAGE1DataProvider
    Protected LANGUAGE1Errors As NameValueCollection = New NameValueCollection()
    Protected LANGUAGE1Operations As FormSupportedOperations
    Protected LANGUAGE1IsSubmitted As Boolean = False
    Protected LANGUAGE_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-EC6CA96F
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            LANGUAGEBind
            LANGUAGE1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid LANGUAGE Bind @2-8ABDC88D

    Protected Sub LANGUAGEBind()
        If Not LANGUAGEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"LANGUAGE",GetType(LANGUAGEDataProvider.SortFields), 20, 250)
        End If
'End Grid LANGUAGE Bind

'Grid Form LANGUAGE BeforeShow tail @2-042EB621
        LANGUAGEParameters()
        LANGUAGEData.SortField = CType(ViewState("LANGUAGESortField"),LANGUAGEDataProvider.SortFields)
        LANGUAGEData.SortDir = CType(ViewState("LANGUAGESortDir"),SortDirections)
        LANGUAGEData.PageNumber = CInt(ViewState("LANGUAGEPageNumber"))
        LANGUAGEData.RecordsPerPage = CInt(ViewState("LANGUAGEPageSize"))
        LANGUAGERepeater.DataSource = LANGUAGEData.GetResultSet(PagesCount, LANGUAGEOperations)
        ViewState("LANGUAGEPagesCount") = PagesCount
        Dim item As LANGUAGEItem = New LANGUAGEItem()
        LANGUAGERepeater.DataBind
        FooterIndex = LANGUAGERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            LANGUAGERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_LANG_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(LANGUAGERepeater.Controls(0).FindControl("Sorter_LANG_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LANG_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(LANGUAGERepeater.Controls(0).FindControl("Sorter_LANG_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(LANGUAGERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(LANGUAGERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim LANGUAGELANGUAGE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(LANGUAGERepeater.Controls(0).FindControl("LANGUAGELANGUAGE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Navigator1Navigator As DECV_PROD2007.Controls.Navigator = DirectCast(LANGUAGERepeater.Controls(FooterIndex).FindControl("Navigator1Navigator"),DECV_PROD2007.Controls.Navigator)
        Navigator1Navigator.PageSizes = new Integer() {50,100,250,500}
        If PagesCount < 2 Then Navigator1Navigator.Visible = False

        item.LANGUAGE_InsertHref = "LANGUAGE_maint.aspx"
        LANGUAGELANGUAGE_Insert.InnerText += item.LANGUAGE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        LANGUAGELANGUAGE_Insert.HRef = item.LANGUAGE_InsertHref+item.LANGUAGE_InsertHrefParameters.ToString("GET","LANG_CODE", ViewState)
'End Grid Form LANGUAGE BeforeShow tail

'Grid LANGUAGE Bind tail @2-E31F8E2A
    End Sub
'End Grid LANGUAGE Bind tail

'Grid LANGUAGE Table Parameters @2-281025AD

    Protected Sub LANGUAGEParameters()
        Try
            LANGUAGEData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=LANGUAGERepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(LANGUAGERepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid LANGUAGE: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid LANGUAGE Table Parameters

'Grid LANGUAGE ItemDataBound event @2-A6C58072

    Protected Sub LANGUAGEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as LANGUAGEItem = CType(e.Item.DataItem,LANGUAGEItem)
        Dim Item as LANGUAGEItem = DataItem
        Dim FormDataSource As LANGUAGEItem() = CType(LANGUAGERepeater.DataSource, LANGUAGEItem())
        Dim LANGUAGEDataRows As Integer = FormDataSource.Length
        Dim LANGUAGEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            LANGUAGECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(LANGUAGERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, LANGUAGECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim LANGUAGELANG_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("LANGUAGELANG_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim LANGUAGELANG_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGELANG_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim LANGUAGELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim LANGUAGELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.LANG_CODEHref = "LANGUAGE_maint.aspx"
            LANGUAGELANG_CODE.HRef = DataItem.LANG_CODEHref & DataItem.LANG_CODEHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim LANGUAGEAlt_LANG_CODE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("LANGUAGEAlt_LANG_CODE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim LANGUAGEAlt_LANG_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGEAlt_LANG_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim LANGUAGEAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGEAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim LANGUAGEAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("LANGUAGEAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_LANG_CODEHref = "LANGUAGE_maint.aspx"
            LANGUAGEAlt_LANG_CODE.HRef = DataItem.Alt_LANG_CODEHref & DataItem.Alt_LANG_CODEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid LANGUAGE ItemDataBound event

'Grid LANGUAGE ItemDataBound event tail @2-8EBCDC30
        If LANGUAGEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(LANGUAGECurrentRowNumber, ListItemType.AlternatingItem)
                LANGUAGERepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(LANGUAGECurrentRowNumber, ListItemType.Item)
                LANGUAGERepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            LANGUAGEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid LANGUAGE ItemDataBound event tail

'Grid LANGUAGE ItemCommand event @2-816936AE

    Protected Sub LANGUAGEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= LANGUAGERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("LANGUAGESortDir"),SortDirections) = SortDirections._Asc And ViewState("LANGUAGESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("LANGUAGESortDir")=SortDirections._Desc
                Else
                    ViewState("LANGUAGESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("LANGUAGESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As LANGUAGEDataProvider.SortFields = 0
            ViewState("LANGUAGESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("LANGUAGEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("LANGUAGEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("LANGUAGEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("LANGUAGEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            LANGUAGEBind
        End If
    End Sub
'End Grid LANGUAGE ItemCommand event

'Record Form LANGUAGE1 Parameters @27-6986F3FB

    Protected Sub LANGUAGE1Parameters()
        Dim item As new LANGUAGE1Item
        Try
        Catch e As Exception
            LANGUAGE1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form LANGUAGE1 Parameters

'Record Form LANGUAGE1 Show method @27-0D7435D8
    Protected Sub LANGUAGE1Show()
        If LANGUAGE1Operations.None Then
            LANGUAGE1Holder.Visible = False
            Return
        End If
        Dim item As LANGUAGE1Item = LANGUAGE1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not LANGUAGE1Operations.AllowRead
        item.ClearParametersHref = "LANGUAGE_list.aspx"
        LANGUAGE1Errors.Add(item.errors)
        If LANGUAGE1Errors.Count > 0 Then
            LANGUAGE1ShowErrors()
            Return
        End If
'End Record Form LANGUAGE1 Show method

'Record Form LANGUAGE1 BeforeShow tail @27-52498660
        LANGUAGE1Parameters()
        LANGUAGE1Data.FillItem(item, IsInsertMode)
        LANGUAGE1Holder.DataBind()
        LANGUAGE1ClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        LANGUAGE1ClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        LANGUAGE1s_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form LANGUAGE1 BeforeShow tail

'Record Form LANGUAGE1 Show method tail @27-5FCDC861
        If LANGUAGE1Errors.Count > 0 Then
            LANGUAGE1ShowErrors()
        End If
    End Sub
'End Record Form LANGUAGE1 Show method tail

'Record Form LANGUAGE1 LoadItemFromRequest method @27-462DACD8

    Protected Sub LANGUAGE1LoadItemFromRequest(item As LANGUAGE1Item, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(LANGUAGE1s_keyword.UniqueID))
        If ControlCustomValues("LANGUAGE1s_keyword") Is Nothing Then
            item.s_keyword.SetValue(LANGUAGE1s_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("LANGUAGE1s_keyword"))
        End If
        If EnableValidation Then
            item.Validate(LANGUAGE1Data)
        End If
        LANGUAGE1Errors.Add(item.errors)
    End Sub
'End Record Form LANGUAGE1 LoadItemFromRequest method

'Record Form LANGUAGE1 GetRedirectUrl method @27-4EEAD488

    Protected Function GetLANGUAGE1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "LANGUAGE_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form LANGUAGE1 GetRedirectUrl method

'Record Form LANGUAGE1 ShowErrors method @27-010C456E

    Protected Sub LANGUAGE1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To LANGUAGE1Errors.Count - 1
        Select Case LANGUAGE1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & LANGUAGE1Errors(i)
        End Select
        Next i
        LANGUAGE1Error.Visible = True
        LANGUAGE1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form LANGUAGE1 ShowErrors method

'Record Form LANGUAGE1 Insert Operation @27-90A3651C

    Protected Sub LANGUAGE1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        LANGUAGE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form LANGUAGE1 Insert Operation

'Record Form LANGUAGE1 BeforeInsert tail @27-EB0D1EA5
    LANGUAGE1Parameters()
    LANGUAGE1LoadItemFromRequest(item, EnableValidation)
'End Record Form LANGUAGE1 BeforeInsert tail

'Record Form LANGUAGE1 AfterInsert tail  @27-BB926A33
        ErrorFlag=(LANGUAGE1Errors.Count > 0)
        If ErrorFlag Then
            LANGUAGE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form LANGUAGE1 AfterInsert tail 

'Record Form LANGUAGE1 Update Operation @27-EAC29B47

    Protected Sub LANGUAGE1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        LANGUAGE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form LANGUAGE1 Update Operation

'Record Form LANGUAGE1 Before Update tail @27-EB0D1EA5
        LANGUAGE1Parameters()
        LANGUAGE1LoadItemFromRequest(item, EnableValidation)
'End Record Form LANGUAGE1 Before Update tail

'Record Form LANGUAGE1 Update Operation tail @27-BB926A33
        ErrorFlag=(LANGUAGE1Errors.Count > 0)
        If ErrorFlag Then
            LANGUAGE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form LANGUAGE1 Update Operation tail

'Record Form LANGUAGE1 Delete Operation @27-3CEC7267
    Protected Sub LANGUAGE1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        LANGUAGE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form LANGUAGE1 Delete Operation

'Record Form BeforeDelete tail @27-EB0D1EA5
        LANGUAGE1Parameters()
        LANGUAGE1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @27-F57346A8
        If ErrorFlag Then
            LANGUAGE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form LANGUAGE1 Cancel Operation @27-9D7A2FC3

    Protected Sub LANGUAGE1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        LANGUAGE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        LANGUAGE1LoadItemFromRequest(item, True)
'End Record Form LANGUAGE1 Cancel Operation

'Record Form LANGUAGE1 Cancel Operation tail @27-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form LANGUAGE1 Cancel Operation tail

'Record Form LANGUAGE1 Search Operation @27-FFA0E37E
    Protected Sub LANGUAGE1_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        LANGUAGE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As LANGUAGE1Item = New LANGUAGE1Item()
        LANGUAGE1LoadItemFromRequest(item, EnableValidation)
'End Record Form LANGUAGE1 Search Operation

'Button Button_DoSearch OnClick. @29-42B01914
        If CType(sender,Control).ID = "LANGUAGE1Button_DoSearch" Then
            RedirectUrl = GetLANGUAGE1RedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @29-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form LANGUAGE1 Search Operation tail @27-B59040A6
        ErrorFlag = LANGUAGE1Errors.Count > 0
        If ErrorFlag Then
            LANGUAGE1ShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(LANGUAGE1s_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(LANGUAGE1s_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form LANGUAGE1 Search Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-771C1D9C
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        LANGUAGE_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        LANGUAGEData = New LANGUAGEDataProvider()
        LANGUAGEOperations = New FormSupportedOperations(False, True, False, False, False)
        LANGUAGE1Data = New LANGUAGE1DataProvider()
        LANGUAGE1Operations = New FormSupportedOperations(False, True, True, True, True)
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

