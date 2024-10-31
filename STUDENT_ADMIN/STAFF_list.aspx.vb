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

Namespace DECV_PROD2007.STAFF_list 'Namespace @1-47384C0B

'Forms Definition @1-B1D3C1AE
Public Class [STAFF_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-6920F327
    Protected STAFFSearchData As STAFFSearchDataProvider
    Protected STAFFSearchErrors As NameValueCollection = New NameValueCollection()
    Protected STAFFSearchOperations As FormSupportedOperations
    Protected STAFFSearchIsSubmitted As Boolean = False
    Protected STAFFData As STAFFDataProvider
    Protected STAFFOperations As FormSupportedOperations
    Protected STAFFCurrentRowNumber As Integer
    Protected STAFF_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-59AD5EFE
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_AddNewHref = "STAFF_maint.aspx"
            PageData.FillItem(item)
            Link_AddNew.InnerText += item.Link_AddNew.GetFormattedValue().Replace(vbCrLf,"")
            Link_AddNew.HRef = item.Link_AddNewHref+item.Link_AddNewHrefParameters.ToString("GET","STAFF_ID", ViewState)
            Link_AddNew.DataBind()
            STAFFSearchShow()
            STAFFBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form STAFFSearch Parameters @2-69873E49

    Protected Sub STAFFSearchParameters()
        Dim item As new STAFFSearchItem
        Try
        Catch e As Exception
            STAFFSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form STAFFSearch Parameters

'Record Form STAFFSearch Show method @2-F0D9CAF7
    Protected Sub STAFFSearchShow()
        If STAFFSearchOperations.None Then
            STAFFSearchHolder.Visible = False
            Return
        End If
        Dim item As STAFFSearchItem = STAFFSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not STAFFSearchOperations.AllowRead
        STAFFSearchErrors.Add(item.errors)
        If STAFFSearchErrors.Count > 0 Then
            STAFFSearchShowErrors()
            Return
        End If
'End Record Form STAFFSearch Show method

'Record Form STAFFSearch BeforeShow tail @2-BAE6C749
        STAFFSearchParameters()
        STAFFSearchData.FillItem(item, IsInsertMode)
        STAFFSearchHolder.DataBind()
        STAFFSearchs_keyword.Text=item.s_keyword.GetFormattedValue()
        item.rbStatusItems.SetSelection(item.rbStatus.GetFormattedValue())
        STAFFSearchrbStatus.SelectedIndex = -1
        item.rbStatusItems.CopyTo(STAFFSearchrbStatus.Items)
'End Record Form STAFFSearch BeforeShow tail

'Record Form STAFFSearch Show method tail @2-279B381F
        If STAFFSearchErrors.Count > 0 Then
            STAFFSearchShowErrors()
        End If
    End Sub
'End Record Form STAFFSearch Show method tail

'Record Form STAFFSearch LoadItemFromRequest method @2-BC56DB55

    Protected Sub STAFFSearchLoadItemFromRequest(item As STAFFSearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(STAFFSearchs_keyword.UniqueID))
        If ControlCustomValues("STAFFSearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(STAFFSearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("STAFFSearchs_keyword"))
        End If
        item.rbStatus.IsEmpty = IsNothing(Request.Form(STAFFSearchrbStatus.UniqueID))
        If Not IsNothing(STAFFSearchrbStatus.SelectedItem) Then
            item.rbStatus.SetValue(STAFFSearchrbStatus.SelectedItem.Value)
        Else
            item.rbStatus.Value = Nothing
        End If
        item.rbStatusItems.CopyFrom(STAFFSearchrbStatus.Items)
        If EnableValidation Then
            item.Validate(STAFFSearchData)
        End If
        STAFFSearchErrors.Add(item.errors)
    End Sub
'End Record Form STAFFSearch LoadItemFromRequest method

'Record Form STAFFSearch GetRedirectUrl method @2-5FA66450

    Protected Function GetSTAFFSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "STAFF_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form STAFFSearch GetRedirectUrl method

'Record Form STAFFSearch ShowErrors method @2-91FF3D51

    Protected Sub STAFFSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To STAFFSearchErrors.Count - 1
        Select Case STAFFSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & STAFFSearchErrors(i)
        End Select
        Next i
        STAFFSearchError.Visible = True
        STAFFSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form STAFFSearch ShowErrors method

'Record Form STAFFSearch Insert Operation @2-1D82198D

    Protected Sub STAFFSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        STAFFSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFFSearch Insert Operation

'Record Form STAFFSearch BeforeInsert tail @2-514D26BE
    STAFFSearchParameters()
    STAFFSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFFSearch BeforeInsert tail

'Record Form STAFFSearch AfterInsert tail  @2-8BFB0F24
        ErrorFlag=(STAFFSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFFSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFFSearch AfterInsert tail 

'Record Form STAFFSearch Update Operation @2-BAE0C98E

    Protected Sub STAFFSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        STAFFSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form STAFFSearch Update Operation

'Record Form STAFFSearch Before Update tail @2-514D26BE
        STAFFSearchParameters()
        STAFFSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFFSearch Before Update tail

'Record Form STAFFSearch Update Operation tail @2-8BFB0F24
        ErrorFlag=(STAFFSearchErrors.Count > 0)
        If ErrorFlag Then
            STAFFSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form STAFFSearch Update Operation tail

'Record Form STAFFSearch Delete Operation @2-005056CC
    Protected Sub STAFFSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        STAFFSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form STAFFSearch Delete Operation

'Record Form BeforeDelete tail @2-514D26BE
        STAFFSearchParameters()
        STAFFSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-DF4D9354
        If ErrorFlag Then
            STAFFSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form STAFFSearch Cancel Operation @2-41B78E33

    Protected Sub STAFFSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        STAFFSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        STAFFSearchLoadItemFromRequest(item, True)
'End Record Form STAFFSearch Cancel Operation

'Record Form STAFFSearch Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form STAFFSearch Cancel Operation tail

'Record Form STAFFSearch Search Operation @2-79416646
    Protected Sub STAFFSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        STAFFSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As STAFFSearchItem = New STAFFSearchItem()
        STAFFSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form STAFFSearch Search Operation

'Button Button_DoSearch OnClick. @3-F154C5EA
        If CType(sender,Control).ID = "STAFFSearchButton_DoSearch" Then
            RedirectUrl = GetSTAFFSearchRedirectUrl("", "s_keyword;rbStatus")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @3-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form STAFFSearch Search Operation tail @2-C247B3F7
        ErrorFlag = STAFFSearchErrors.Count > 0
        If ErrorFlag Then
            STAFFSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(STAFFSearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(STAFFSearchs_keyword.Text) & "&"), "")
            For Each li In STAFFSearchrbStatus.Items
                If li.Selected And Not "".Equals(li.Value) Then
                    Params &= "rbStatus=" & Server.UrlEncode(li.Value) & "&"
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
'End Record Form STAFFSearch Search Operation tail

'Grid STAFF Bind @5-9626FB88

    Protected Sub STAFFBind()
        If Not STAFFOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STAFF",GetType(STAFFDataProvider.SortFields), 50, 100)
        End If
'End Grid STAFF Bind

'Grid Form STAFF BeforeShow tail @5-ECFCDF1A
        STAFFParameters()
        STAFFData.SortField = CType(ViewState("STAFFSortField"),STAFFDataProvider.SortFields)
        STAFFData.SortDir = CType(ViewState("STAFFSortDir"),SortDirections)
        STAFFData.PageNumber = CInt(ViewState("STAFFPageNumber"))
        STAFFData.RecordsPerPage = CInt(ViewState("STAFFPageSize"))
        STAFFRepeater.DataSource = STAFFData.GetResultSet(PagesCount, STAFFOperations)
        ViewState("STAFFPagesCount") = PagesCount
        Dim item As STAFFItem = New STAFFItem()
        STAFFRepeater.DataBind
        FooterIndex = STAFFRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STAFFRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim STAFFSTAFF_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STAFFRepeater.Controls(FooterIndex).FindControl("STAFFSTAFF_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_STAFF_IDSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_STAFF_IDSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SURNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_SURNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_FIRSTNAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_FIRSTNAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TEACHER_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_TEACHER_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_GROUP_NAMESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_GROUP_NAMESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(STAFFRepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Navigator1Navigator As DECV_PROD2007.Controls.Navigator = DirectCast(STAFFRepeater.Controls(FooterIndex).FindControl("Navigator1Navigator"),DECV_PROD2007.Controls.Navigator)
        Navigator1Navigator.PageSizes = new Integer() {50,100,250,5000}
        If PagesCount < 2 Then Navigator1Navigator.Visible = False

        item.STAFF_InsertHref = "STAFF_maint.aspx"
        STAFFSTAFF_Insert.InnerText += item.STAFF_Insert.GetFormattedValue().Replace(vbCrLf,"")
        STAFFSTAFF_Insert.HRef = item.STAFF_InsertHref+item.STAFF_InsertHrefParameters.ToString("GET","STAFF_ID", ViewState)
'End Grid Form STAFF BeforeShow tail

'Grid STAFF Bind tail @5-E31F8E2A
    End Sub
'End Grid STAFF Bind tail

'Grid STAFF Table Parameters @5-188E0F0D

    Protected Sub STAFFParameters()
        Try
            STAFFData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)
            STAFFData.UrlrbStatus = TextParameter.GetParam("rbStatus", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STAFFRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STAFFRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STAFF: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STAFF Table Parameters

'Grid STAFF ItemDataBound event @5-3FE329EB

    Protected Sub STAFFItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STAFFItem = CType(e.Item.DataItem,STAFFItem)
        Dim Item as STAFFItem = DataItem
        Dim FormDataSource As STAFFItem() = CType(STAFFRepeater.DataSource, STAFFItem())
        Dim STAFFDataRows As Integer = FormDataSource.Length
        Dim STAFFIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STAFFCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STAFFRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STAFFCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Then
            Dim STAFFSTAFF_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFFSTAFF_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STAFFSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFSURNAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFFIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFFIRSTNAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFTEACHER_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFTEACHER_FLAG"),System.Web.UI.WebControls.Literal)
            Dim STAFFGROUP_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFGROUP_NAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFSTATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFFLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STAFFLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.STAFF_IDHref = "STAFF_maint.aspx"
            STAFFSTAFF_ID.HRef = DataItem.STAFF_IDHref & DataItem.STAFF_IDHrefParameters.ToString("GET","", ViewState)
        End If
        If e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STAFFAlt_STAFF_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("STAFFAlt_STAFF_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim STAFFAlt_SURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_SURNAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_FIRSTNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_FIRSTNAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_TEACHER_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_TEACHER_FLAG"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_GROUP_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_GROUP_NAME"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_STATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_STATUS"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_LAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_LAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim STAFFAlt_LAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STAFFAlt_LAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.Alt_STAFF_IDHref = "STAFF_maint.aspx"
            STAFFAlt_STAFF_ID.HRef = DataItem.Alt_STAFF_IDHref & DataItem.Alt_STAFF_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid STAFF ItemDataBound event

'Grid STAFF ItemDataBound event tail @5-4024D71E
        If STAFFIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            If e.Item.ItemType = ListItemType.Item Then
                ri= new RepeaterItem(STAFFCurrentRowNumber, ListItemType.AlternatingItem)
                STAFFRepeater.AlternatingItemTemplate.InstantiateIn(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                ri= new RepeaterItem(STAFFCurrentRowNumber, ListItemType.Item)
                STAFFRepeater.ItemTemplate.InstantiateIn(ri)
            End If
            ri.DataItem = DataItem
            ri.DataBind()
            If e.Item.ItemType = ListItemType.Item Then
                e.Item.FindControl("AltIterationContainer").Controls.Add(ri)
            ElseIf e.Item.ItemType = ListItemType.AlternatingItem
                e.Item.FindControl("IterationContainer").Controls.Add(ri)
            End If
            STAFFItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STAFF ItemDataBound event tail

'Grid STAFF ItemCommand event @5-30A01151

    Protected Sub STAFFItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STAFFRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STAFFSortDir"),SortDirections) = SortDirections._Asc And ViewState("STAFFSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STAFFSortDir")=SortDirections._Desc
                Else
                    ViewState("STAFFSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STAFFSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STAFFDataProvider.SortFields = 0
            ViewState("STAFFSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STAFFPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STAFFPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STAFFPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STAFFPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STAFFBind
        End If
    End Sub
'End Grid STAFF ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-6105D6C2
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        STAFF_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STAFFSearchData = New STAFFSearchDataProvider()
        STAFFSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        STAFFData = New STAFFDataProvider()
        STAFFOperations = New FormSupportedOperations(False, True, False, False, False)
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

