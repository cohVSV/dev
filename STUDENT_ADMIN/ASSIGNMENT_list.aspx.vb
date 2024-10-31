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

Namespace DECV_PROD2007.ASSIGNMENT_list 'Namespace @1-F9F02EC8

'Forms Definition @1-BB1DB026
Public Class [ASSIGNMENT_listPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-87D908EE
    Protected ASSIGNMENTSearchData As ASSIGNMENTSearchDataProvider
    Protected ASSIGNMENTSearchErrors As NameValueCollection = New NameValueCollection()
    Protected ASSIGNMENTSearchOperations As FormSupportedOperations
    Protected ASSIGNMENTSearchIsSubmitted As Boolean = False
    Protected ASSIGNMENTData As ASSIGNMENTDataProvider
    Protected ASSIGNMENTOperations As FormSupportedOperations
    Protected ASSIGNMENTCurrentRowNumber As Integer
    Protected ASSIGNMENT_listContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-660757EA
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "ASSIGNMENT_maint.aspx"
            item.Link1HrefParameters.Add("SUBJECT_ID",Request.QueryString,"s_SUBJECT_ID")
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","ASSIGNMENT_ID", ViewState)
            Link1.DataBind()
            ASSIGNMENTSearchShow()
            ASSIGNMENTBind
    End If
'End Page_Load Event BeforeIsPostBack

'Page ASSIGNMENT_list Event BeforeShow. Action Hide-Show Component @30-AC78F358
        Dim Urls_SUBJECT_ID_30_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID"))
        Dim ExprParam2_30_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SUBJECT_ID_30_1, ExprParam2_30_2) Then
            Link1.Visible = False
        End If
'End Page ASSIGNMENT_list Event BeforeShow. Action Hide-Show Component

'Page ASSIGNMENT_list Event BeforeShow. Action Hide-Show Component @33-F7DF19D5
        Dim Urls_SUBJECT_ID_33_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID"))
        Dim ExprParam2_33_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(Urls_SUBJECT_ID_33_1, ExprParam2_33_2) Then
            ASSIGNMENTRepeater.Visible = False
        End If
'End Page ASSIGNMENT_list Event BeforeShow. Action Hide-Show Component

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form ASSIGNMENTSearch Parameters @4-6BAADD0B

    Protected Sub ASSIGNMENTSearchParameters()
        Dim item As new ASSIGNMENTSearchItem
        Try
        Catch e As Exception
            ASSIGNMENTSearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form ASSIGNMENTSearch Parameters

'Record Form ASSIGNMENTSearch Show method @4-D3C119BB
    Protected Sub ASSIGNMENTSearchShow()
        If ASSIGNMENTSearchOperations.None Then
            ASSIGNMENTSearchHolder.Visible = False
            Return
        End If
        Dim item As ASSIGNMENTSearchItem = ASSIGNMENTSearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not ASSIGNMENTSearchOperations.AllowRead
        ASSIGNMENTSearchErrors.Add(item.errors)
        If ASSIGNMENTSearchErrors.Count > 0 Then
            ASSIGNMENTSearchShowErrors()
            Return
        End If
'End Record Form ASSIGNMENTSearch Show method

'Record Form ASSIGNMENTSearch BeforeShow tail @4-63C782CE
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchData.FillItem(item, IsInsertMode)
        ASSIGNMENTSearchHolder.DataBind()
        ASSIGNMENTSearchs_SUBJECT_ID.Text=item.s_SUBJECT_ID.GetFormattedValue()
'End Record Form ASSIGNMENTSearch BeforeShow tail

'Record Form ASSIGNMENTSearch Show method tail @4-0CEBD826
        If ASSIGNMENTSearchErrors.Count > 0 Then
            ASSIGNMENTSearchShowErrors()
        End If
    End Sub
'End Record Form ASSIGNMENTSearch Show method tail

'Record Form ASSIGNMENTSearch LoadItemFromRequest method @4-ECE8F4AB

    Protected Sub ASSIGNMENTSearchLoadItemFromRequest(item As ASSIGNMENTSearchItem, ByVal EnableValidation As Boolean)
        Try
        item.s_SUBJECT_ID.IsEmpty = IsNothing(Request.Form(ASSIGNMENTSearchs_SUBJECT_ID.UniqueID))
        If ControlCustomValues("ASSIGNMENTSearchs_SUBJECT_ID") Is Nothing Then
            item.s_SUBJECT_ID.SetValue(ASSIGNMENTSearchs_SUBJECT_ID.Text)
        Else
            item.s_SUBJECT_ID.SetValue(ControlCustomValues("ASSIGNMENTSearchs_SUBJECT_ID"))
        End If
        Catch ae As ArgumentException
            ASSIGNMENTSearchErrors.Add("s_SUBJECT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"s_SUBJECT_ID"))
        End Try
        If EnableValidation Then
            item.Validate(ASSIGNMENTSearchData)
        End If
        ASSIGNMENTSearchErrors.Add(item.errors)
    End Sub
'End Record Form ASSIGNMENTSearch LoadItemFromRequest method

'Record Form ASSIGNMENTSearch GetRedirectUrl method @4-870A168E

    Protected Function GetASSIGNMENTSearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "ASSIGNMENT_list.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form ASSIGNMENTSearch GetRedirectUrl method

'Record Form ASSIGNMENTSearch ShowErrors method @4-0B228DF4

    Protected Sub ASSIGNMENTSearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To ASSIGNMENTSearchErrors.Count - 1
        Select Case ASSIGNMENTSearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & ASSIGNMENTSearchErrors(i)
        End Select
        Next i
        ASSIGNMENTSearchError.Visible = True
        ASSIGNMENTSearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form ASSIGNMENTSearch ShowErrors method

'Record Form ASSIGNMENTSearch Insert Operation @4-1589C885

    Protected Sub ASSIGNMENTSearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENTSearch Insert Operation

'Record Form ASSIGNMENTSearch BeforeInsert tail @4-A64950C7
    ASSIGNMENTSearchParameters()
    ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch BeforeInsert tail

'Record Form ASSIGNMENTSearch AfterInsert tail  @4-C5746470
        ErrorFlag=(ASSIGNMENTSearchErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENTSearch AfterInsert tail 

'Record Form ASSIGNMENTSearch Update Operation @4-019318B4

    Protected Sub ASSIGNMENTSearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form ASSIGNMENTSearch Update Operation

'Record Form ASSIGNMENTSearch Before Update tail @4-A64950C7
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch Before Update tail

'Record Form ASSIGNMENTSearch Update Operation tail @4-C5746470
        ErrorFlag=(ASSIGNMENTSearchErrors.Count > 0)
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENTSearch Update Operation tail

'Record Form ASSIGNMENTSearch Delete Operation @4-3815AB8A
    Protected Sub ASSIGNMENTSearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form ASSIGNMENTSearch Delete Operation

'Record Form BeforeDelete tail @4-A64950C7
        ASSIGNMENTSearchParameters()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @4-C750D8B6
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form ASSIGNMENTSearch Cancel Operation @4-38BA0E91

    Protected Sub ASSIGNMENTSearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        ASSIGNMENTSearchLoadItemFromRequest(item, True)
'End Record Form ASSIGNMENTSearch Cancel Operation

'Record Form ASSIGNMENTSearch Cancel Operation tail @4-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form ASSIGNMENTSearch Cancel Operation tail

'Record Form ASSIGNMENTSearch Search Operation @4-6C57EEC8
    Protected Sub ASSIGNMENTSearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        ASSIGNMENTSearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As ASSIGNMENTSearchItem = New ASSIGNMENTSearchItem()
        ASSIGNMENTSearchLoadItemFromRequest(item, EnableValidation)
'End Record Form ASSIGNMENTSearch Search Operation

'Button Button_DoSearch OnClick. @5-AF1D2EE7
        If CType(sender,Control).ID = "ASSIGNMENTSearchButton_DoSearch" Then
            RedirectUrl = GetASSIGNMENTSearchRedirectUrl("", "s_SUBJECT_ID")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @5-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form ASSIGNMENTSearch Search Operation tail @4-D64EA098
        ErrorFlag = ASSIGNMENTSearchErrors.Count > 0
        If ErrorFlag Then
            ASSIGNMENTSearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(ASSIGNMENTSearchs_SUBJECT_ID.Text <> "",("s_SUBJECT_ID=" & Server.UrlEncode(ASSIGNMENTSearchs_SUBJECT_ID.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form ASSIGNMENTSearch Search Operation tail

'Grid ASSIGNMENT Bind @3-632466EB

    Protected Sub ASSIGNMENTBind()
        If Not ASSIGNMENTOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"ASSIGNMENT",GetType(ASSIGNMENTDataProvider.SortFields), 80, 100)
        End If
'End Grid ASSIGNMENT Bind

'Grid Form ASSIGNMENT BeforeShow tail @3-B0806060
        ASSIGNMENTParameters()
        ASSIGNMENTData.SortField = CType(ViewState("ASSIGNMENTSortField"),ASSIGNMENTDataProvider.SortFields)
        ASSIGNMENTData.SortDir = CType(ViewState("ASSIGNMENTSortDir"),SortDirections)
        ASSIGNMENTData.PageNumber = CInt(ViewState("ASSIGNMENTPageNumber"))
        ASSIGNMENTData.RecordsPerPage = CInt(ViewState("ASSIGNMENTPageSize"))
        ASSIGNMENTRepeater.DataSource = ASSIGNMENTData.GetResultSet(PagesCount, ASSIGNMENTOperations)
        ViewState("ASSIGNMENTPagesCount") = PagesCount
        Dim item As ASSIGNMENTItem = New ASSIGNMENTItem()
        ASSIGNMENTRepeater.DataBind
        FooterIndex = ASSIGNMENTRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim ASSIGNMENTASSIGNMENT_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTASSIGNMENT_TotalRecords"),System.Web.UI.WebControls.Literal)
        Dim ASSIGNMENTlblSubjectID As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTlblSubjectID"),System.Web.UI.WebControls.Literal)
        Dim ASSIGNMENTlblSubjectName As System.Web.UI.WebControls.Literal = DirectCast(ASSIGNMENTRepeater.Controls(0).FindControl("ASSIGNMENTlblSubjectName"),System.Web.UI.WebControls.Literal)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(ASSIGNMENTRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        ASSIGNMENTASSIGNMENT_TotalRecords.Text = Server.HtmlEncode(item.ASSIGNMENT_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENTlblSubjectID.Text = Server.HtmlEncode(item.lblSubjectID.GetFormattedValue()).Replace(vbCrLf,"<br>")
        ASSIGNMENTlblSubjectName.Text = Server.HtmlEncode(item.lblSubjectName.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form ASSIGNMENT BeforeShow tail

'Label ASSIGNMENT_TotalRecords Event BeforeShow. Action Retrieve number of records @8-A359E2AD
            ASSIGNMENTASSIGNMENT_TotalRecords.Text = ASSIGNMENTData.RecordCount.ToString()
'End Label ASSIGNMENT_TotalRecords Event BeforeShow. Action Retrieve number of records

'Label lblSubjectName Event BeforeShow. Action Declare Variable @22-24705C7F
            Dim tmpSubjectID As Double = 0
'End Label lblSubjectName Event BeforeShow. Action Declare Variable

'Label lblSubjectName Event BeforeShow. Action Retrieve Value for Variable @21-024E2D28
            tmpSubjectID = System.Web.HttpContext.Current.Request.QueryString("s_SUBJECT_ID")
'End Label lblSubjectName Event BeforeShow. Action Retrieve Value for Variable

'Label lblSubjectName Event BeforeShow. Action DLookup @20-9989DB30
            ASSIGNMENTlblSubjectName.Text = (New TextField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "SUBJECT_TITLE" & " FROM " & "SUBJECT" & " WHERE " & "SUBJECT_ID = " & tmpSubjectID.ToString))).GetFormattedValue("")
'End Label lblSubjectName Event BeforeShow. Action DLookup

'Label lblSubjectName Event BeforeShow. Action Retrieve Value for Control @24-ED1813D3
            ASSIGNMENTlblSubjectID.Text = (New TextField("", tmpSubjectID)).GetFormattedValue()
'End Label lblSubjectName Event BeforeShow. Action Retrieve Value for Control

'Grid ASSIGNMENT Bind tail @3-E31F8E2A
    End Sub
'End Grid ASSIGNMENT Bind tail

'Grid ASSIGNMENT Table Parameters @3-448D0E5E

    Protected Sub ASSIGNMENTParameters()
        Try
            ASSIGNMENTData.Urls_SUBJECT_ID = IntegerParameter.GetParam("s_SUBJECT_ID", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=ASSIGNMENTRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(ASSIGNMENTRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid ASSIGNMENT: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid ASSIGNMENT Table Parameters

'Grid ASSIGNMENT ItemDataBound event @3-C6CE59A5

    Protected Sub ASSIGNMENTItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as ASSIGNMENTItem = CType(e.Item.DataItem,ASSIGNMENTItem)
        Dim Item as ASSIGNMENTItem = DataItem
        Dim FormDataSource As ASSIGNMENTItem() = CType(ASSIGNMENTRepeater.DataSource, ASSIGNMENTItem())
        Dim ASSIGNMENTDataRows As Integer = FormDataSource.Length
        Dim ASSIGNMENTIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ASSIGNMENTCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENTRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, ASSIGNMENTCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ASSIGNMENTASSIGNMENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("ASSIGNMENTASSIGNMENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim ASSIGNMENTDESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTDESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTSTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTSTATUS"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTLAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTLAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTLAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            Dim ASSIGNMENTARCHIVE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("ASSIGNMENTARCHIVE"),System.Web.UI.WebControls.Literal)
            DataItem.ASSIGNMENT_IDHref = "ASSIGNMENT_maint.aspx"
            ASSIGNMENTASSIGNMENT_ID.HRef = DataItem.ASSIGNMENT_IDHref & DataItem.ASSIGNMENT_IDHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid ASSIGNMENT ItemDataBound event

'Grid ASSIGNMENT BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid ASSIGNMENT BeforeShowRow event

'Grid ASSIGNMENT Event BeforeShowRow. Action Set Row Style @10-557E6405
            Dim styles10 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex10 As Integer = (ASSIGNMENTCurrentRowNumber - 1) Mod styles10.Length
            Dim rawStyle10 As String = styles10(styleIndex10).Replace("\;",";")
            If rawStyle10.IndexOf("=") = -1 And rawStyle10.IndexOf(":") > -1 Then
                rawStyle10 = "style=""" + rawStyle10 + """"
            ElseIf rawStyle10.IndexOf("=") = -1 And rawStyle10.IndexOf(":") = -1 And rawStyle10 <> "" Then
                rawStyle10 = "class=""" + rawStyle10 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(ASSIGNMENTRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle10), AttributeOption.Multiple)
'End Grid ASSIGNMENT Event BeforeShowRow. Action Set Row Style

'Grid ASSIGNMENT BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid ASSIGNMENT BeforeShowRow event tail

'Grid ASSIGNMENT ItemDataBound event tail @3-696858CE
        If ASSIGNMENTIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(ASSIGNMENTCurrentRowNumber, ListItemType.Item)
            ASSIGNMENTRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            ASSIGNMENTItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid ASSIGNMENT ItemDataBound event tail

'Grid ASSIGNMENT ItemCommand event @3-1279F498

    Protected Sub ASSIGNMENTItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= ASSIGNMENTRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("ASSIGNMENTSortDir"),SortDirections) = SortDirections._Asc And ViewState("ASSIGNMENTSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("ASSIGNMENTSortDir")=SortDirections._Desc
                Else
                    ViewState("ASSIGNMENTSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("ASSIGNMENTSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As ASSIGNMENTDataProvider.SortFields = 0
            ViewState("ASSIGNMENTSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("ASSIGNMENTPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("ASSIGNMENTPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("ASSIGNMENTPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("ASSIGNMENTPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            ASSIGNMENTBind
        End If
    End Sub
'End Grid ASSIGNMENT ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-67FEBEB6
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        ASSIGNMENT_listContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        ASSIGNMENTSearchData = New ASSIGNMENTSearchDataProvider()
        ASSIGNMENTSearchOperations = New FormSupportedOperations(False, True, True, True, True)
        ASSIGNMENTData = New ASSIGNMENTDataProvider()
        ASSIGNMENTOperations = New FormSupportedOperations(False, True, False, False, False)
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

