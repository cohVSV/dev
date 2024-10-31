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

Namespace DECV_PROD2007.SCHOOL_list 'Namespace @1-FB143B6E

'Forms Definition @1-88BB9934
Public Class [SCHOOL_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-0BBD94E3
    Protected SCHOOLSearchData As SCHOOLSearchDataProvider
    Protected SCHOOLSearchErrors As NameValueCollection = New NameValueCollection()
    Protected SCHOOLSearchOperations As FormSupportedOperations
    Protected SCHOOLSearchIsSubmitted As Boolean = False
    Protected SCHOOLData As SCHOOLDataProvider
    Protected SCHOOLOperations As FormSupportedOperations
    Protected SCHOOLCurrentRowNumber As Integer
    Protected SCHOOL_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-873B2F93
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            SCHOOLSearchShow()
            SCHOOLBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form SCHOOLSearch Parameters @67-77B44725

    Protected Sub SCHOOLSearchParameters()
        Dim item As new SCHOOLSearchItem
        Try
        Catch e As Exception
            SCHOOLSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form SCHOOLSearch Parameters

'Record Form SCHOOLSearch Show method @67-69ECB903
    Protected Sub SCHOOLSearchShow()
        If SCHOOLSearchOperations.None Then
            SCHOOLSearchHolder.Visible = False
            Return
        End If
        Dim item As SCHOOLSearchItem = SCHOOLSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not SCHOOLSearchOperations.AllowRead
        SCHOOLSearchErrors.Add(item.errors)
        If SCHOOLSearchErrors.Count > 0 Then
            SCHOOLSearchShowErrors()
            Return
        End If
'End Record Form SCHOOLSearch Show method

'Record Form SCHOOLSearch BeforeShow tail @67-731930EC
        SCHOOLSearchParameters()
        SCHOOLSearchData.FillItem(item, IsInsertMode)
        SCHOOLSearchHolder.DataBind()
        SCHOOLSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
        SCHOOLSearchlbSCHOOL_TYPE.Items.Add(new ListItem("Select Value",""))
        SCHOOLSearchlbSCHOOL_TYPE.Items(0).Selected = True
        item.lbSCHOOL_TYPEItems.SetSelection(item.lbSCHOOL_TYPE.GetFormattedValue())
        If Not item.lbSCHOOL_TYPEItems.GetSelectedItem() Is Nothing Then
            SCHOOLSearchlbSCHOOL_TYPE.SelectedIndex = -1
        End If
        item.lbSCHOOL_TYPEItems.CopyTo(SCHOOLSearchlbSCHOOL_TYPE.Items)
'End Record Form SCHOOLSearch BeforeShow tail

'Record Form SCHOOLSearch Show method tail @67-BAD42734
        If SCHOOLSearchErrors.Count > 0 Then
            SCHOOLSearchShowErrors()
        End If
    End Sub
'End Record Form SCHOOLSearch Show method tail

'Record Form SCHOOLSearch LoadItemFromRequest method @67-7D8823F4

    Protected Sub SCHOOLSearchLoadItemFromRequest(item As SCHOOLSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(SCHOOLSearchs_keyword.UniqueID))
        If ControlCustomValues("SCHOOLSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(SCHOOLSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("SCHOOLSearchs_keyword"))
        End If
        item.lbSCHOOL_TYPE.IsEmpty = IsNothing(Request.Form(SCHOOLSearchlbSCHOOL_TYPE.UniqueID))
        item.lbSCHOOL_TYPE.SetValue(SCHOOLSearchlbSCHOOL_TYPE.Value)
        item.lbSCHOOL_TYPEItems.CopyFrom(SCHOOLSearchlbSCHOOL_TYPE.Items)
        If EnableValidation Then
            item.Validate(SCHOOLSearchData)
        End If
        SCHOOLSearchErrors.Add(item.errors)
    End Sub
'End Record Form SCHOOLSearch LoadItemFromRequest method

'Record Form SCHOOLSearch GetRedirectUrl method @67-D0741330

    Protected Function GetSCHOOLSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "SCHOOL_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form SCHOOLSearch GetRedirectUrl method

'Record Form SCHOOLSearch ShowErrors method @67-B7DED751

    Protected Sub SCHOOLSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To SCHOOLSearchErrors.Count - 1
        Select Case SCHOOLSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & SCHOOLSearchErrors(i)
        End Select
        Next i
        SCHOOLSearchError.Visible = True
        SCHOOLSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form SCHOOLSearch ShowErrors method

'Record Form SCHOOLSearch Insert Operation @67-6372C929

    Protected Sub SCHOOLSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        SCHOOLSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOLSearch Insert Operation

'Record Form SCHOOLSearch BeforeInsert tail @67-3E43CF94
    SCHOOLSearchParameters()
    SCHOOLSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SCHOOLSearch BeforeInsert tail

'Record Form SCHOOLSearch AfterInsert tail  @67-44C92DA7
        ErrorFlag=(SCHOOLSearchErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOLSearch AfterInsert tail 

'Record Form SCHOOLSearch Update Operation @67-7B330E24

    Protected Sub SCHOOLSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        SCHOOLSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form SCHOOLSearch Update Operation

'Record Form SCHOOLSearch Before Update tail @67-3E43CF94
        SCHOOLSearchParameters()
        SCHOOLSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SCHOOLSearch Before Update tail

'Record Form SCHOOLSearch Update Operation tail @67-44C92DA7
        ErrorFlag=(SCHOOLSearchErrors.Count > 0)
        If ErrorFlag Then
            SCHOOLSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOLSearch Update Operation tail

'Record Form SCHOOLSearch Delete Operation @67-876D7535
    Protected Sub SCHOOLSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        SCHOOLSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form SCHOOLSearch Delete Operation

'Record Form BeforeDelete tail @67-3E43CF94
        SCHOOLSearchParameters()
        SCHOOLSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @67-32C030FD
        If ErrorFlag Then
            SCHOOLSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form SCHOOLSearch Cancel Operation @67-569277D7

    Protected Sub SCHOOLSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        SCHOOLSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        SCHOOLSearchLoadItemFromRequest(item, True)
'End Record Form SCHOOLSearch Cancel Operation

'Record Form SCHOOLSearch Cancel Operation tail @67-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form SCHOOLSearch Cancel Operation tail

'Record Form SCHOOLSearch Search Operation @67-B6CEDD50
    Protected Sub SCHOOLSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        SCHOOLSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As SCHOOLSearchItem = New SCHOOLSearchItem()
        SCHOOLSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form SCHOOLSearch Search Operation

'Button Button_DoSearch OnClick. @68-25E9703B
        If CType(sender,Control).ID = "SCHOOLSearchButton_DoSearch" Then
            RedirectUrl = GetSCHOOLSearchRedirectUrl("", "s_keyword;lbSCHOOL_TYPE")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @68-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form SCHOOLSearch Search Operation tail @67-90D2693D
        ErrorFlag = SCHOOLSearchErrors.Count > 0
        If ErrorFlag Then
            SCHOOLSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(SCHOOLSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(SCHOOLSearchs_keyword.Text) & "&"), "")
            For Each li In SCHOOLSearchlbSCHOOL_TYPE.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "lbSCHOOL_TYPE=" & Server.UrlEncode(li.Value) & "&"
                End If
            Next li
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form SCHOOLSearch Search Operation tail

'Grid SCHOOL Bind @66-C7D3D9C5

    Protected Sub SCHOOLBind()
        If Not SCHOOLOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"SCHOOL",GetType(SCHOOLDataProvider.SortFields), 20, 100)
        End If
'End Grid SCHOOL Bind

'Grid Form SCHOOL BeforeShow tail @66-1431084B
        SCHOOLParameters()
        SCHOOLData.SortField = CType(ViewState("SCHOOLSortField"),SCHOOLDataProvider.SortFields)
        SCHOOLData.SortDir = CType(ViewState("SCHOOLSortDir"),SortDirections)
        SCHOOLData.PageNumber = CInt(ViewState("SCHOOLPageNumber"))
        SCHOOLData.RecordsPerPage = CInt(ViewState("SCHOOLPageSize"))
        SCHOOLRepeater.DataSource = SCHOOLData.GetResultSet(PagesCount, SCHOOLOperations)
        ViewState("SCHOOLPagesCount") = PagesCount
        Dim item As SCHOOLItem = New SCHOOLItem()
        SCHOOLRepeater.DataBind
        FooterIndex = SCHOOLRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            SCHOOLRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_SCHOOL_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_SCHOOL_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SCHOOL_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_SCHOOL_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_REGION_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_REGION_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_METRO_CATEGORYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_METRO_CATEGORYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(SCHOOLRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(SCHOOLRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim SCHOOLlink_AnotherNewSchool As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(SCHOOLRepeater.Controls(FooterIndex).FindControl("SCHOOLlink_AnotherNewSchool"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim SCHOOLlink_NewSchool As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(SCHOOLRepeater.Controls(0).FindControl("SCHOOLlink_NewSchool"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.link_AnotherNewSchoolHref = "SCHOOL_maint.aspx"
        item.link_NewSchoolHref = "SCHOOL_maint.aspx"
        SCHOOLlink_AnotherNewSchool.InnerText += item.link_AnotherNewSchool.GetFormattedValue().Replace(vbCrLf,"")
        SCHOOLlink_AnotherNewSchool.HRef = item.link_AnotherNewSchoolHref+item.link_AnotherNewSchoolHrefParameters.ToString("GET","SCHOOL_ID", ViewState)
        SCHOOLlink_NewSchool.InnerText += item.link_NewSchool.GetFormattedValue().Replace(vbCrLf,"")
        SCHOOLlink_NewSchool.HRef = item.link_NewSchoolHref+item.link_NewSchoolHrefParameters.ToString("GET","SCHOOL_ID", ViewState)
'End Grid Form SCHOOL BeforeShow tail

'Grid SCHOOL Bind tail @66-E31F8E2A
    End Sub
'End Grid SCHOOL Bind tail

'Grid SCHOOL Table Parameters @66-13AA14C5

    Protected Sub SCHOOLParameters()
        Try
            SCHOOLData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
            SCHOOLData.UrllbSCHOOL_TYPE = TextParameter.GetParam("lbSCHOOL_TYPE", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=SCHOOLRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SCHOOLRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SCHOOL: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid SCHOOL Table Parameters

'Grid SCHOOL ItemDataBound event @66-9403FB43

    Protected Sub SCHOOLItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as SCHOOLItem = CType(e.Item.DataItem,SCHOOLItem)
        Dim Item as SCHOOLItem = DataItem
        Dim FormDataSource As SCHOOLItem() = CType(SCHOOLRepeater.DataSource, SCHOOLItem())
        Dim SCHOOLDataRows As Integer = FormDataSource.Length
        Dim SCHOOLIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            SCHOOLCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(SCHOOLRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, SCHOOLCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim SCHOOLSCHOOL_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCHOOLSCHOOL_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim SCHOOLSCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLSCHOOL_NAME"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLREGION_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLREGION_ID"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLMETRO_CATEGORY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLMETRO_CATEGORY"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLSTATUS"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim SCHOOLSCHOOL_TYPE_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("SCHOOLSCHOOL_TYPE_CODE"),System.Web.UI.WebControls.Literal)
            DataItem.SCHOOL_IDHref = "SCHOOL_maint.aspx"
            SCHOOLSCHOOL_ID.HRef = DataItem.SCHOOL_IDHref & DataItem.SCHOOL_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid SCHOOL ItemDataBound event

'Grid SCHOOL ItemDataBound event tail @66-0BAF0BDC
        If SCHOOLIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(SCHOOLCurrentRowNumber, ListItemType.Item)
            SCHOOLRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            SCHOOLItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid SCHOOL ItemDataBound event tail

'Grid SCHOOL ItemCommand event @66-8E658108

    Protected Sub SCHOOLItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= SCHOOLRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SCHOOLSortDir"),SortDirections) = SortDirections._Asc And ViewState("SCHOOLSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SCHOOLSortDir")=SortDirections._Desc
                Else
                    ViewState("SCHOOLSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SCHOOLSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SCHOOLDataProvider.SortFields = 0
            ViewState("SCHOOLSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SCHOOLPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("SCHOOLPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("SCHOOLPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("SCHOOLPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SCHOOLBind
        End If
    End Sub
'End Grid SCHOOL ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-CA0CB1B3
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        SCHOOL_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCHOOLSearchData = New SCHOOLSearchDataProvider()
        SCHOOLSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        SCHOOLData = New SCHOOLDataProvider()
        SCHOOLOperations = New FormSupportedOperations(False, True, False, False, False)
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

