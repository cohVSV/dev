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

Namespace DECV_PROD2007.TXN_CODE_list 'Namespace @1-88108F06

'Forms Definition @1-E1FAB736
Public Class [TXN_CODE_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-ECD22531
    Protected TXN_CODEData As TXN_CODEDataProvider
    Protected TXN_CODEOperations As FormSupportedOperations
    Protected TXN_CODECurrentRowNumber As Integer
    Protected TXN_CODE1Data As TXN_CODE1DataProvider
    Protected TXN_CODE1Errors As NameValueCollection = New NameValueCollection()
    Protected TXN_CODE1Operations As FormSupportedOperations
    Protected TXN_CODE1IsSubmitted As Boolean = False
    Protected TXN_CODE_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-5A054660
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            TXN_CODEBind
            TXN_CODE1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid TXN_CODE Bind @34-1D94F0AD

    Protected Sub TXN_CODEBind()
        If Not TXN_CODEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"TXN_CODE",GetType(TXN_CODEDataProvider.SortFields), 20, 100)
        End If
'End Grid TXN_CODE Bind

'Grid Form TXN_CODE BeforeShow tail @34-501F3B58
        TXN_CODEData.SortField = CType(ViewState("TXN_CODESortField"),TXN_CODEDataProvider.SortFields)
        TXN_CODEData.SortDir = CType(ViewState("TXN_CODESortDir"),SortDirections)
        TXN_CODEData.PageNumber = CInt(ViewState("TXN_CODEPageNumber"))
        TXN_CODEData.RecordsPerPage = CInt(ViewState("TXN_CODEPageSize"))
        TXN_CODERepeater.DataSource = TXN_CODEData.GetResultSet(PagesCount, TXN_CODEOperations)
        ViewState("TXN_CODEPagesCount") = PagesCount
        Dim item As TXN_CODEItem = New TXN_CODEItem()
        TXN_CODERepeater.DataBind
        FooterIndex = TXN_CODERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            TXN_CODERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim TXN_CODETXN_CODE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(TXN_CODERepeater.Controls(FooterIndex).FindControl("TXN_CODETXN_CODE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_TXN_CODESorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_TXN_CODESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_TXN_TYPESorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_TXN_TYPESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_CR_DR_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_CR_DR_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(TXN_CODERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(TXN_CODERepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.TXN_CODE_InsertHref = "TXN_CODE_list.aspx"
        TXN_CODETXN_CODE_Insert.InnerText += item.TXN_CODE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        TXN_CODETXN_CODE_Insert.HRef = item.TXN_CODE_InsertHref+item.TXN_CODE_InsertHrefParameters.ToString("GET","TXN_CODE", ViewState)
'End Grid Form TXN_CODE BeforeShow tail

'Grid TXN_CODE Bind tail @34-E31F8E2A
    End Sub
'End Grid TXN_CODE Bind tail

'Grid TXN_CODE ItemDataBound event @34-40D56B99

    Protected Sub TXN_CODEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as TXN_CODEItem = CType(e.Item.DataItem,TXN_CODEItem)
        Dim Item as TXN_CODEItem = DataItem
        Dim FormDataSource As TXN_CODEItem() = CType(TXN_CODERepeater.DataSource, TXN_CODEItem())
        Dim TXN_CODEDataRows As Integer = FormDataSource.Length
        Dim TXN_CODEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            TXN_CODECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(TXN_CODERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, TXN_CODECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim TXN_CODEDetail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("TXN_CODEDetail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim TXN_CODETXN_CODE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODETXN_CODE1"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODETXN_TYPE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODETXN_TYPE"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODECR_DR_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODECR_DR_FLAG"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODEDESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODEDESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim TXN_CODELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("TXN_CODELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "TXN_CODE_list.aspx"
            TXN_CODEDetail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid TXN_CODE ItemDataBound event

'Grid TXN_CODE ItemDataBound event tail @34-8F030ACB
        If TXN_CODEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(TXN_CODECurrentRowNumber, ListItemType.Item)
            TXN_CODERepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            TXN_CODEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid TXN_CODE ItemDataBound event tail

'Grid TXN_CODE ItemCommand event @34-52B7A15F

    Protected Sub TXN_CODEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= TXN_CODERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("TXN_CODESortDir"),SortDirections) = SortDirections._Asc And ViewState("TXN_CODESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("TXN_CODESortDir")=SortDirections._Desc
                Else
                    ViewState("TXN_CODESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("TXN_CODESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As TXN_CODEDataProvider.SortFields = 0
            ViewState("TXN_CODESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("TXN_CODEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("TXN_CODEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("TXN_CODEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("TXN_CODEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            TXN_CODEBind
        End If
    End Sub
'End Grid TXN_CODE ItemCommand event

'Record Form TXN_CODE1 Parameters @58-7AF773A6

    Protected Sub TXN_CODE1Parameters()
        Dim item As new TXN_CODE1Item
        Try
            TXN_CODE1Data.UrlTXN_CODE = TextParameter.GetParam("TXN_CODE", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            TXN_CODE1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form TXN_CODE1 Parameters

'Record Form TXN_CODE1 Show method @58-10CDB67A
    Protected Sub TXN_CODE1Show()
        If TXN_CODE1Operations.None Then
            TXN_CODE1Holder.Visible = False
            Return
        End If
        Dim item As TXN_CODE1Item = TXN_CODE1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TXN_CODE1Operations.AllowRead
        TXN_CODE1Errors.Add(item.errors)
        If TXN_CODE1Errors.Count > 0 Then
            TXN_CODE1ShowErrors()
            Return
        End If
'End Record Form TXN_CODE1 Show method

'Record Form TXN_CODE1 BeforeShow tail @58-7325D58C
        TXN_CODE1Parameters()
        TXN_CODE1Data.FillItem(item, IsInsertMode)
        TXN_CODE1Holder.DataBind()
        TXN_CODE1Button_Insert.Visible=IsInsertMode AndAlso TXN_CODE1Operations.AllowInsert
        TXN_CODE1Button_Update.Visible=Not (IsInsertMode) AndAlso TXN_CODE1Operations.AllowUpdate
        TXN_CODE1TXN_CODE.Text=item.TXN_CODE.GetFormattedValue()
        TXN_CODE1TXN_TYPE.Text=item.TXN_TYPE.GetFormattedValue()
        item.CR_DR_FLAGItems.SetSelection(item.CR_DR_FLAG.GetFormattedValue())
        TXN_CODE1CR_DR_FLAG.SelectedIndex = -1
        item.CR_DR_FLAGItems.CopyTo(TXN_CODE1CR_DR_FLAG.Items, True)
        TXN_CODE1DESCRIPTION.Text=item.DESCRIPTION.GetFormattedValue()
        TXN_CODE1LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        TXN_CODE1LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form TXN_CODE1 BeforeShow tail

'Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control @74-34B55159
            TXN_CODE1LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserID.ToUpper))).GetFormattedValue()
'End Hidden LAST_ALTERED_BY Event BeforeShow. Action Retrieve Value for Control

'Record Form TXN_CODE1 Show method tail @58-B020EAD5
        If TXN_CODE1Errors.Count > 0 Then
            TXN_CODE1ShowErrors()
        End If
    End Sub
'End Record Form TXN_CODE1 Show method tail

'Record Form TXN_CODE1 LoadItemFromRequest method @58-477F08CD

    Protected Sub TXN_CODE1LoadItemFromRequest(item As TXN_CODE1Item, ByVal EnableValidation As Boolean)
        item.TXN_CODE.IsEmpty = IsNothing(Request.Form(TXN_CODE1TXN_CODE.UniqueID))
        If ControlCustomValues("TXN_CODE1TXN_CODE") Is Nothing Then
            item.TXN_CODE.SetValue(TXN_CODE1TXN_CODE.Text)
        Else
            item.TXN_CODE.SetValue(ControlCustomValues("TXN_CODE1TXN_CODE"))
        End If
        item.TXN_TYPE.IsEmpty = IsNothing(Request.Form(TXN_CODE1TXN_TYPE.UniqueID))
        If ControlCustomValues("TXN_CODE1TXN_TYPE") Is Nothing Then
            item.TXN_TYPE.SetValue(TXN_CODE1TXN_TYPE.Text)
        Else
            item.TXN_TYPE.SetValue(ControlCustomValues("TXN_CODE1TXN_TYPE"))
        End If
        item.CR_DR_FLAG.IsEmpty = IsNothing(Request.Form(TXN_CODE1CR_DR_FLAG.UniqueID))
        If Not IsNothing(TXN_CODE1CR_DR_FLAG.SelectedItem) Then
            item.CR_DR_FLAG.SetValue(TXN_CODE1CR_DR_FLAG.SelectedItem.Value)
        Else
            item.CR_DR_FLAG.Value = Nothing
        End If
        item.CR_DR_FLAGItems.CopyFrom(TXN_CODE1CR_DR_FLAG.Items)
        item.DESCRIPTION.IsEmpty = IsNothing(Request.Form(TXN_CODE1DESCRIPTION.UniqueID))
        If ControlCustomValues("TXN_CODE1DESCRIPTION") Is Nothing Then
            item.DESCRIPTION.SetValue(TXN_CODE1DESCRIPTION.Text)
        Else
            item.DESCRIPTION.SetValue(ControlCustomValues("TXN_CODE1DESCRIPTION"))
        End If
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(TXN_CODE1LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(TXN_CODE1LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(TXN_CODE1LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(TXN_CODE1LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            TXN_CODE1Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(TXN_CODE1Data)
        End If
        TXN_CODE1Errors.Add(item.errors)
    End Sub
'End Record Form TXN_CODE1 LoadItemFromRequest method

'Record Form TXN_CODE1 GetRedirectUrl method @58-CE026010

    Protected Function GetTXN_CODE1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form TXN_CODE1 GetRedirectUrl method

'Record Form TXN_CODE1 ShowErrors method @58-BC5C11CB

    Protected Sub TXN_CODE1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To TXN_CODE1Errors.Count - 1
        Select Case TXN_CODE1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & TXN_CODE1Errors(i)
        End Select
        Next i
        TXN_CODE1Error.Visible = True
        TXN_CODE1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form TXN_CODE1 ShowErrors method

'Record Form TXN_CODE1 Insert Operation @58-CBBC59A6

    Protected Sub TXN_CODE1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODE1Item = New TXN_CODE1Item()
        Dim ExecuteFlag As Boolean = True
        TXN_CODE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN_CODE1 Insert Operation

'Button Button_Insert OnClick. @60-4C3444B2
        If CType(sender,Control).ID = "TXN_CODE1Button_Insert" Then
            RedirectUrl = GetTXN_CODE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @60-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form TXN_CODE1 BeforeInsert tail @58-868F010D
    TXN_CODE1Parameters()
    TXN_CODE1LoadItemFromRequest(item, EnableValidation)
    If TXN_CODE1Operations.AllowInsert Then
        ErrorFlag=(TXN_CODE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN_CODE1Data.InsertItem(item)
            Catch ex As Exception
                TXN_CODE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form TXN_CODE1 BeforeInsert tail

'Record TXN_CODE1 Event AfterInsert. Action Save Variable Value @71-A7EBABD6
        HttpContext.Current.Session("notifymessage") = "Item has been Added"
'End Record TXN_CODE1 Event AfterInsert. Action Save Variable Value

'Record Form TXN_CODE1 AfterInsert tail  @58-099F5C73
        End If
        ErrorFlag=(TXN_CODE1Errors.Count > 0)
        If ErrorFlag Then
            TXN_CODE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN_CODE1 AfterInsert tail 

'Record Form TXN_CODE1 Update Operation @58-81759FC1

    Protected Sub TXN_CODE1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODE1Item = New TXN_CODE1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        TXN_CODE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN_CODE1 Update Operation

'Button Button_Update OnClick. @61-4B55FB8D
        If CType(sender,Control).ID = "TXN_CODE1Button_Update" Then
            RedirectUrl = GetTXN_CODE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @61-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record TXN_CODE1 Event BeforeUpdate. Action Retrieve Value for Control @72-34B55159
        TXN_CODE1LAST_ALTERED_BY.Value = (New TextField("", (DBUtility.UserID.ToUpper))).GetFormattedValue()
'End Record TXN_CODE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record TXN_CODE1 Event BeforeUpdate. Action Retrieve Value for Control @73-057FCFAC
        TXN_CODE1LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy", (Now()))).GetFormattedValue()
'End Record TXN_CODE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form TXN_CODE1 Before Update tail @58-FF36E12D
        TXN_CODE1Parameters()
        TXN_CODE1LoadItemFromRequest(item, EnableValidation)
        If TXN_CODE1Operations.AllowUpdate Then
        ErrorFlag = (TXN_CODE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN_CODE1Data.UpdateItem(item)
            Catch ex As Exception
                TXN_CODE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form TXN_CODE1 Before Update tail

'Record TXN_CODE1 Event AfterUpdate. Action Save Variable Value @70-B862AFBC
        HttpContext.Current.Session("notifymessage") = "Item has been Updated"
'End Record TXN_CODE1 Event AfterUpdate. Action Save Variable Value

'Record Form TXN_CODE1 Update Operation tail @58-099F5C73
        End If
        ErrorFlag=(TXN_CODE1Errors.Count > 0)
        If ErrorFlag Then
            TXN_CODE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN_CODE1 Update Operation tail

'Record Form TXN_CODE1 Delete Operation @58-5A2BB881
    Protected Sub TXN_CODE1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        TXN_CODE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As TXN_CODE1Item = New TXN_CODE1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form TXN_CODE1 Delete Operation

'Record Form BeforeDelete tail @58-610C0510
        TXN_CODE1Parameters()
        TXN_CODE1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @58-FDF6E2B8
        If ErrorFlag Then
            TXN_CODE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form TXN_CODE1 Cancel Operation @58-E072BF5C

    Protected Sub TXN_CODE1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN_CODE1Item = New TXN_CODE1Item()
        TXN_CODE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        TXN_CODE1LoadItemFromRequest(item, False)
'End Record Form TXN_CODE1 Cancel Operation

'Button Button_Cancel OnClick. @62-59B4AD01
    If CType(sender,Control).ID = "TXN_CODE1Button_Cancel" Then
        RedirectUrl = GetTXN_CODE1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @62-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form TXN_CODE1 Cancel Operation tail @58-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form TXN_CODE1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-35D559FD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        TXN_CODE_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        TXN_CODEData = New TXN_CODEDataProvider()
        TXN_CODEOperations = New FormSupportedOperations(False, True, False, False, False)
        TXN_CODE1Data = New TXN_CODE1DataProvider()
        TXN_CODE1Operations = New FormSupportedOperations(False, True, True, True, False)
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

