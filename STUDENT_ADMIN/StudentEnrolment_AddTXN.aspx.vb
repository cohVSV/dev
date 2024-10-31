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

Namespace DECV_PROD2007.StudentEnrolment_AddTXN 'Namespace @1-E8C67B90

'Forms Definition @1-7F4F42CB
Public Class [StudentEnrolment_AddTXNPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-461204A9
    Protected Grid_TransactionsData As Grid_TransactionsDataProvider
    Protected Grid_TransactionsOperations As FormSupportedOperations
    Protected Grid_TransactionsCurrentRowNumber As Integer
    Protected txnData As txnDataProvider
    Protected txnErrors As NameValueCollection = New NameValueCollection()
    Protected txnOperations As FormSupportedOperations
    Protected txnIsSubmitted As Boolean = False
    Protected StudentEnrolment_AddTXNContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-76A20C24
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Grid_TransactionsBind
            txnShow()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid Grid_Transactions Bind @3-15880F76

    Protected Sub Grid_TransactionsBind()
        If Not Grid_TransactionsOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid_Transactions",GetType(Grid_TransactionsDataProvider.SortFields), 80, 100)
        End If
'End Grid Grid_Transactions Bind

'Grid Form Grid_Transactions BeforeShow tail @3-A65FD8B7
        Grid_TransactionsParameters()
        Grid_TransactionsData.SortField = CType(ViewState("Grid_TransactionsSortField"),Grid_TransactionsDataProvider.SortFields)
        Grid_TransactionsData.SortDir = CType(ViewState("Grid_TransactionsSortDir"),SortDirections)
        Grid_TransactionsData.PageNumber = CInt(ViewState("Grid_TransactionsPageNumber"))
        Grid_TransactionsData.RecordsPerPage = CInt(ViewState("Grid_TransactionsPageSize"))
        Grid_TransactionsRepeater.DataSource = Grid_TransactionsData.GetResultSet(PagesCount, Grid_TransactionsOperations)
        ViewState("Grid_TransactionsPagesCount") = PagesCount
        Dim item As Grid_TransactionsItem = New Grid_TransactionsItem()
        Grid_TransactionsRepeater.DataBind
        FooterIndex = Grid_TransactionsRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid_TransactionsRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Grid_TransactionslblAcctBalance As System.Web.UI.WebControls.Literal = DirectCast(Grid_TransactionsRepeater.Controls(FooterIndex).FindControl("Grid_TransactionslblAcctBalance"),System.Web.UI.WebControls.Literal)
        Dim Grid_TransactionslblCRDRFlag As System.Web.UI.WebControls.Literal = DirectCast(Grid_TransactionsRepeater.Controls(FooterIndex).FindControl("Grid_TransactionslblCRDRFlag"),System.Web.UI.WebControls.Literal)

        Grid_TransactionslblAcctBalance.Text = Server.HtmlEncode(item.lblAcctBalance.GetFormattedValue()).Replace(vbCrLf,"<br>")
        Grid_TransactionslblCRDRFlag.Text = Server.HtmlEncode(item.lblCRDRFlag.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form Grid_Transactions BeforeShow tail

'Label lblAcctBalance Event BeforeShow. Action Custom Code @13-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Label lblAcctBalance Event BeforeShow. Action Custom Code

'Grid Grid_Transactions Bind tail @3-E31F8E2A
    End Sub
'End Grid Grid_Transactions Bind tail

'Grid Grid_Transactions Table Parameters @3-98DC2E19

    Protected Sub Grid_TransactionsParameters()
        Try
            Grid_TransactionsData.SestmpSTUDENT_ID = TextParameter.GetParam("tmpSTUDENT_ID", ParameterSourceType.Session, "", 0, false)
            Grid_TransactionsData.SestmpENROLMENT_YEAR = TextParameter.GetParam("tmpENROLMENT_YEAR", ParameterSourceType.Session, "", year(now()), false)

        Catch
            Dim ParentControls As ControlCollection=Grid_TransactionsRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid_TransactionsRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid_Transactions: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid_Transactions Table Parameters

'Grid Grid_Transactions ItemDataBound event @3-E8040726

    Protected Sub Grid_TransactionsItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid_TransactionsItem = CType(e.Item.DataItem,Grid_TransactionsItem)
        Dim Item as Grid_TransactionsItem = DataItem
        Dim FormDataSource As Grid_TransactionsItem() = CType(Grid_TransactionsRepeater.DataSource, Grid_TransactionsItem())
        Dim Grid_TransactionsDataRows As Integer = FormDataSource.Length
        Dim Grid_TransactionsIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid_TransactionsCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid_TransactionsRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid_TransactionsCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid_Transactionslink_TRANS_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_Transactionslink_TRANS_DATE"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsTXN_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Grid_TransactionsTXN_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim Grid_TransactionsTRANS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsTRANS_CODE"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsAMOUNT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsAMOUNT"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsCR_DR_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsCR_DR_FLAG"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsCOMMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsCOMMENTS"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsRECEIPT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsRECEIPT"),System.Web.UI.WebControls.Literal)
        End If
'End Grid Grid_Transactions ItemDataBound event

'Grid Grid_Transactions BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid_Transactions BeforeShowRow event

'Grid Grid_Transactions Event BeforeShowRow. Action Set Row Style @15-A095631A
            Dim styles15 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex15 As Integer = (Grid_TransactionsCurrentRowNumber - 1) Mod styles15.Length
            Dim rawStyle15 As String = styles15(styleIndex15).Replace("\;",";")
            If rawStyle15.IndexOf("=") = -1 And rawStyle15.IndexOf(":") > -1 Then
                rawStyle15 = "style=""" + rawStyle15 + """"
            ElseIf rawStyle15.IndexOf("=") = -1 And rawStyle15.IndexOf(":") = -1 And rawStyle15 <> "" Then
                rawStyle15 = "class=""" + rawStyle15 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(Grid_TransactionsRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle15), AttributeOption.Multiple)
'End Grid Grid_Transactions Event BeforeShowRow. Action Set Row Style

'Grid Grid_Transactions Event BeforeShowRow. Action Custom Code @16-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Grid Grid_Transactions Event BeforeShowRow. Action Custom Code

'Grid Grid_Transactions BeforeShowRow event tail @3-477CF3C9
        End If
'End Grid Grid_Transactions BeforeShowRow event tail

'Grid Grid_Transactions ItemDataBound event tail @3-3A3C2537
        If Grid_TransactionsIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid_TransactionsCurrentRowNumber, ListItemType.Item)
            Grid_TransactionsRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid_TransactionsItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid_Transactions ItemDataBound event tail

'Grid Grid_Transactions ItemCommand event @3-2EDA6C6A

    Protected Sub Grid_TransactionsItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid_TransactionsRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid_TransactionsSortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid_TransactionsSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid_TransactionsSortDir")=SortDirections._Desc
                Else
                    ViewState("Grid_TransactionsSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid_TransactionsSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid_TransactionsDataProvider.SortFields = 0
            ViewState("Grid_TransactionsSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid_TransactionsPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid_TransactionsPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid_TransactionsPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid_TransactionsPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid_TransactionsBind
        End If
    End Sub
'End Grid Grid_Transactions ItemCommand event

'Record Form txn Parameters @19-DFF8E578

    Protected Sub txnParameters()
        Dim item As new txnItem
        Try
            txnData.UrlTXN_ID = FloatParameter.GetParam("TXN_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            txnErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form txn Parameters

'Record Form txn Show method @19-C79FE585
    Protected Sub txnShow()
        If txnOperations.None Then
            txnHolder.Visible = False
            Return
        End If
        Dim item As txnItem = txnItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not txnOperations.AllowRead
        txnErrors.Add(item.errors)
        If txnErrors.Count > 0 Then
            txnShowErrors()
            Return
        End If
'End Record Form txn Show method

'Record Form txn BeforeShow tail @19-6F54D004
        txnParameters()
        txnData.FillItem(item, IsInsertMode)
        txnHolder.DataBind()
        txnButton_Insert.Visible=IsInsertMode AndAlso txnOperations.AllowInsert
        txnSTUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        txnENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        txnLAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        txnCAMPUS_CODE.Value = item.CAMPUS_CODE.GetFormattedValue()
        txnLAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        txnTXN_DATE.Text=item.TXN_DATE.GetFormattedValue()
        txnTXN_CODE.Items.Add(new ListItem("Select Value",""))
        txnTXN_CODE.Items(0).Selected = True
        item.TXN_CODEItems.SetSelection(item.TXN_CODE.GetFormattedValue())
        If Not item.TXN_CODEItems.GetSelectedItem() Is Nothing Then
            txnTXN_CODE.SelectedIndex = -1
        End If
        item.TXN_CODEItems.CopyTo(txnTXN_CODE.Items)
        txnAMOUNT.Text=item.AMOUNT.GetFormattedValue()
        txnCR_DR_FLAG.Items.Add(new ListItem("Select Value",""))
        txnCR_DR_FLAG.Items(0).Selected = True
        item.CR_DR_FLAGItems.SetSelection(item.CR_DR_FLAG.GetFormattedValue())
        If Not item.CR_DR_FLAGItems.GetSelectedItem() Is Nothing Then
            txnCR_DR_FLAG.SelectedIndex = -1
        End If
        item.CR_DR_FLAGItems.CopyTo(txnCR_DR_FLAG.Items)
        txnCOMMENTS.Text=item.COMMENTS.GetFormattedValue()
        txnRECEIPT_NO.Text=item.RECEIPT_NO.GetFormattedValue()
'End Record Form txn BeforeShow tail

'Record txn Event BeforeShow. Action Hide-Show Component @35-16733E9B
        Dim UrlSTUDENT_ID_35_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))
        Dim ExprParam2_35_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlSTUDENT_ID_35_1, ExprParam2_35_2) Then
            txnHolder.Visible = False
        End If
'End Record txn Event BeforeShow. Action Hide-Show Component

'Record txn Event BeforeShow. Action Retrieve Value for Control @36-FAB1C7D1
            txnSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Session("tmpSTUDENT_ID"))).GetFormattedValue()
'End Record txn Event BeforeShow. Action Retrieve Value for Control

'Record txn Event BeforeShow. Action Retrieve Value for Control @37-49B8C880
            txnENROLMENT_YEAR.Value = (New FloatField("", System.Web.HttpContext.Current.Session("tmpENROLMENT_YEAR"))).GetFormattedValue()
'End Record txn Event BeforeShow. Action Retrieve Value for Control

'Record Form txn Show method tail @19-F95F995F
        If txnErrors.Count > 0 Then
            txnShowErrors()
        End If
    End Sub
'End Record Form txn Show method tail

'Record Form txn LoadItemFromRequest method @19-F5847565

    Protected Sub txnLoadItemFromRequest(item As txnItem, ByVal EnableValidation As Boolean)
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(txnSTUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(txnSTUDENT_ID.Value)
        Catch ae As ArgumentException
            txnErrors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(txnENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(txnENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            txnErrors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(txnLAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(txnLAST_ALTERED_BY.Value)
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(txnCAMPUS_CODE.UniqueID))
        item.CAMPUS_CODE.SetValue(txnCAMPUS_CODE.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(txnLAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(txnLAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            txnErrors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST_ALTERED_DATE","dd/mm/yyyy"))
        End Try
        Try
        item.TXN_DATE.IsEmpty = IsNothing(Request.Form(txnTXN_DATE.UniqueID))
        If ControlCustomValues("txnTXN_DATE") Is Nothing Then
            item.TXN_DATE.SetValue(txnTXN_DATE.Text)
        Else
            item.TXN_DATE.SetValue(ControlCustomValues("txnTXN_DATE"))
        End If
        Catch ae As ArgumentException
            txnErrors.Add("TXN_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"Transaction Date","dd/mm/yyyy"))
        End Try
        item.TXN_CODE.IsEmpty = IsNothing(Request.Form(txnTXN_CODE.UniqueID))
        item.TXN_CODE.SetValue(txnTXN_CODE.Value)
        item.TXN_CODEItems.CopyFrom(txnTXN_CODE.Items)
        Try
        item.AMOUNT.IsEmpty = IsNothing(Request.Form(txnAMOUNT.UniqueID))
        If ControlCustomValues("txnAMOUNT") Is Nothing Then
            item.AMOUNT.SetValue(txnAMOUNT.Text)
        Else
            item.AMOUNT.SetValue(ControlCustomValues("txnAMOUNT"))
        End If
        Catch ae As ArgumentException
            txnErrors.Add("AMOUNT",String.Format(Resources.strings.CCS_IncorrectFormat,"Amount","0.#;;;;,;"))
        End Try
        item.CR_DR_FLAG.IsEmpty = IsNothing(Request.Form(txnCR_DR_FLAG.UniqueID))
        item.CR_DR_FLAG.SetValue(txnCR_DR_FLAG.Value)
        item.CR_DR_FLAGItems.CopyFrom(txnCR_DR_FLAG.Items)
        item.COMMENTS.IsEmpty = IsNothing(Request.Form(txnCOMMENTS.UniqueID))
        If ControlCustomValues("txnCOMMENTS") Is Nothing Then
            item.COMMENTS.SetValue(txnCOMMENTS.Text)
        Else
            item.COMMENTS.SetValue(ControlCustomValues("txnCOMMENTS"))
        End If
        item.RECEIPT_NO.IsEmpty = IsNothing(Request.Form(txnRECEIPT_NO.UniqueID))
        If ControlCustomValues("txnRECEIPT_NO") Is Nothing Then
            item.RECEIPT_NO.SetValue(txnRECEIPT_NO.Text)
        Else
            item.RECEIPT_NO.SetValue(ControlCustomValues("txnRECEIPT_NO"))
        End If
        If EnableValidation Then
            item.Validate(txnData)
        End If
        txnErrors.Add(item.errors)
    End Sub
'End Record Form txn LoadItemFromRequest method

'Record Form txn GetRedirectUrl method @19-FC9AB3C2

    Protected Function GettxnRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FinancialAccounts_maintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form txn GetRedirectUrl method

'Record Form txn ShowErrors method @19-791E75B0

    Protected Sub txnShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To txnErrors.Count - 1
        Select Case txnErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & txnErrors(i)
        End Select
        Next i
        txnError.Visible = True
        txnErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form txn ShowErrors method

'Record Form txn Insert Operation @19-CEA52B1C

    Protected Sub txn_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        Dim ExecuteFlag As Boolean = True
        txnIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Insert Operation

'Button Button_Insert OnClick. @34-4EBF1419
        If CType(sender,Control).ID = "txnButton_Insert" Then
            RedirectUrl = GettxnRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @34-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form txn BeforeInsert tail @19-0903FEAD
    txnParameters()
    txnLoadItemFromRequest(item, EnableValidation)
    If txnOperations.AllowInsert Then
        ErrorFlag=(txnErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                txnData.InsertItem(item)
            Catch ex As Exception
                txnErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form txn BeforeInsert tail

'Record Form txn AfterInsert tail  @19-B92F6AE8
        End If
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn AfterInsert tail 

'Record Form txn Update Operation @19-990AD327

    Protected Sub txn_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Update Operation

'Record Form txn Before Update tail @19-E6529729
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
'End Record Form txn Before Update tail

'Record Form txn Update Operation tail @19-D1CD6F2C
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn Update Operation tail

'Record Form txn Delete Operation @19-72AB614A
    Protected Sub txn_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As txnItem = New txnItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form txn Delete Operation

'Record Form BeforeDelete tail @19-E6529729
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @19-E92D4CBE
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form txn Cancel Operation @19-65F0173A

    Protected Sub txn_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        txnLoadItemFromRequest(item, True)
'End Record Form txn Cancel Operation

'Record Form txn Cancel Operation tail @19-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form txn Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-95DFBF79
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        StudentEnrolment_AddTXNContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Grid_TransactionsData = New Grid_TransactionsDataProvider()
        Grid_TransactionsOperations = New FormSupportedOperations(False, True, False, False, False)
        txnData = New txnDataProvider()
        txnOperations = New FormSupportedOperations(False, False, True, False, False)
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

