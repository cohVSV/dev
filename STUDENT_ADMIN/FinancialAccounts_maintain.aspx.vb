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

Namespace DECV_PROD2007.FinancialAccounts_maintain 'Namespace @1-C5F10A8B

'Forms Definition @1-598ADF80
Public Class [FinancialAccounts_maintainPage]
Inherits CCPage
'End Forms Definition

' ERA: page level Account Balance 
dim dblAccountBalance as single = 0.00
' ERA: page level Running balance for Auto calc fees
dim dblAutoBalance as single = 0.00

'Forms Objects @1-493DF7DE
    Protected Grid_TransactionsData As Grid_TransactionsDataProvider
    Protected Grid_TransactionsOperations As FormSupportedOperations
    Protected Grid_TransactionsCurrentRowNumber As Integer
    Protected txnData As txnDataProvider
    Protected txnErrors As NameValueCollection = New NameValueCollection()
    Protected txnOperations As FormSupportedOperations
    Protected txnIsSubmitted As Boolean = False
    Protected Grid1Data As Grid1DataProvider
    Protected Grid1Operations As FormSupportedOperations
    Protected Grid1CurrentRowNumber As Integer
    Protected TXN1Data As TXN1DataProvider
    Protected TXN1Errors As NameValueCollection = New NameValueCollection()
    Protected TXN1Operations As FormSupportedOperations
    Protected TXN1IsSubmitted As Boolean = False
    Protected TXN1DatePicker_TXN_DATEName As String
    Protected TXN1DatePicker_TXN_DATEDateControl As String
    Protected FinancialAccounts_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-0AF5675C
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            lblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
            lblEnrolmentYear.Text = Server.HtmlEncode(item.lblEnrolmentYear.GetFormattedValue()).Replace(vbCrLf,"<br>")
            Grid_TransactionsBind
            txnShow()
            Grid1Bind
            TXN1Show()
    End If
'End Page_Load Event BeforeIsPostBack

'Page FinancialAccounts_maintain Event BeforeShow. Action Retrieve Value for Control @48-D647D845
    lblStudentID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Page FinancialAccounts_maintain Event BeforeShow. Action Retrieve Value for Control

'Page FinancialAccounts_maintain Event BeforeShow. Action Retrieve Value for Control @49-C83A4706
    lblEnrolmentYear.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Page FinancialAccounts_maintain Event BeforeShow. Action Retrieve Value for Control

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

'Label lblAcctBalance Event BeforeShow. Action Custom Code @38-73254650
    ' -------------------------
    'ERA: put the dblAccountBalance into the lblAccountBalance
	' BUT note: if lblAccountBalance < 0 then reverse sign and change CRDR flag
	if dblAccountBalance < 0 then
		dblAccountBalance = (dblAccountBalance * -1.00)
		Grid_TransactionslblCRDRFlag.Text = "CR"
	else
		Grid_TransactionslblCRDRFlag.Text = "DR"
	end if
	Grid_TransactionslblAcctBalance.Text = dblAccountBalance.tostring("0.00")	'force formatting as was showing crap like '2.8421709430404E-14'
    ' -------------------------
'End Label lblAcctBalance Event BeforeShow. Action Custom Code

'Grid Grid_Transactions Bind tail @3-E31F8E2A
    End Sub
'End Grid Grid_Transactions Bind tail

'Grid Grid_Transactions Table Parameters @3-2DDEB433

    Protected Sub Grid_TransactionsParameters()
        Try
            Grid_TransactionsData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 1, false)
            Grid_TransactionsData.UrlENROLMENT_YEAR = TextParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", year(now()), false)

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

'Grid Grid_Transactions ItemDataBound event @3-CB5BFEB6

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
            Dim Grid_Transactionslink_TRANS_DATE As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Grid_Transactionslink_TRANS_DATE"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Grid_TransactionsTXN_ID As System.Web.UI.HtmlControls.HtmlInputHidden = DirectCast(e.Item.FindControl("Grid_TransactionsTXN_ID"),System.Web.UI.HtmlControls.HtmlInputHidden)
            Dim Grid_TransactionsTRANS_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsTRANS_CODE"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsAMOUNT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsAMOUNT"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsCR_DR_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsCR_DR_FLAG"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsCOMMENTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsCOMMENTS"),System.Web.UI.WebControls.Literal)
            Dim Grid_TransactionsRECEIPT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid_TransactionsRECEIPT"),System.Web.UI.WebControls.Literal)
            DataItem.link_TRANS_DATEHref = "FinancialAccounts_comments_maintain.aspx"
            Grid_Transactionslink_TRANS_DATE.HRef = DataItem.link_TRANS_DATEHref & DataItem.link_TRANS_DATEHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid Grid_Transactions ItemDataBound event

'Grid Grid_Transactions BeforeShowRow event @3-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid_Transactions BeforeShowRow event

'Grid Grid_Transactions Event BeforeShowRow. Action Set Row Style @6-4F0F6A57
            Dim styles6 As String() = Regex.Split("Row;AltRow","(?<!\\);")
            Dim styleIndex6 As Integer = (Grid_TransactionsCurrentRowNumber - 1) Mod styles6.Length
            Dim rawStyle6 As String = styles6(styleIndex6).Replace("\;",";")
            If rawStyle6.IndexOf("=") = -1 And rawStyle6.IndexOf(":") > -1 Then
                rawStyle6 = "style=""" + rawStyle6 + """"
            ElseIf rawStyle6.IndexOf("=") = -1 And rawStyle6.IndexOf(":") = -1 And rawStyle6 <> "" Then
                rawStyle6 = "class=""" + rawStyle6 + """"
            End If
            CType(Page,CCPage).ControlAttributes.Add(Grid_TransactionsRepeater, New CCSControlAttribute("rowStyle", FieldType._Text, rawStyle6), AttributeOption.Multiple)
'End Grid Grid_Transactions Event BeforeShowRow. Action Set Row Style

'Grid Grid_Transactions Event BeforeShowRow. Action Custom Code @37-73254650
    ' -------------------------
    'ERA: add each row's AMOUNT to a running total
		If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
			' check debit or credit and add/subtract appropriately
			if DataItem.cr_dr_flag.value = "C" then
    			dblAccountBalance -=  DataItem.Amount.Value
			elseif DataItem.cr_dr_flag.value = "D" then
				dblAccountBalance +=  DataItem.Amount.Value
			end if
  		End If
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

'Record Form txn Parameters @14-DFF8E578

    Protected Sub txnParameters()
        Dim item As new txnItem
        Try
            txnData.UrlTXN_ID = FloatParameter.GetParam("TXN_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            txnErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form txn Parameters

'Record Form txn Show method @14-C79FE585
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

'Record Form txn BeforeShow tail @14-72C2EA92
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
        txnCOMMENTS.Text=item.COMMENTS.GetFormattedValue()
        txnRECEIPT_NO.Text=item.RECEIPT_NO.GetFormattedValue()
        txnCR_DR_FLAG.Items.Add(new ListItem("Select Value",""))
        txnCR_DR_FLAG.Items(0).Selected = True
        item.CR_DR_FLAGItems.SetSelection(item.CR_DR_FLAG.GetFormattedValue())
        If Not item.CR_DR_FLAGItems.GetSelectedItem() Is Nothing Then
            txnCR_DR_FLAG.SelectedIndex = -1
        End If
        item.CR_DR_FLAGItems.CopyTo(txnCR_DR_FLAG.Items)
'End Record Form txn BeforeShow tail

'Record txn Event BeforeShow. Action Hide-Show Component @50-37A1A148
        Dim UrlSTUDENT_ID_50_1 As TextField = New TextField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))
        Dim ExprParam2_50_2 As TextField = New TextField("", (""))
        If FieldBase.EqualOp(UrlSTUDENT_ID_50_1, ExprParam2_50_2) Then
            txnHolder.Visible = False
        End If
'End Record txn Event BeforeShow. Action Hide-Show Component

'Record txn Event BeforeShow. Action Retrieve Value for Control @29-38A0D216
            txnSTUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record txn Event BeforeShow. Action Retrieve Value for Control

'Record txn Event BeforeShow. Action Retrieve Value for Control @30-46D48E27
            txnENROLMENT_YEAR.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record txn Event BeforeShow. Action Retrieve Value for Control

'Record Form txn Show method tail @14-F95F995F
        If txnErrors.Count > 0 Then
            txnShowErrors()
        End If
    End Sub
'End Record Form txn Show method tail

'Record Form txn LoadItemFromRequest method @14-17E2A238

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
        item.CR_DR_FLAG.IsEmpty = IsNothing(Request.Form(txnCR_DR_FLAG.UniqueID))
        item.CR_DR_FLAG.SetValue(txnCR_DR_FLAG.Value)
        item.CR_DR_FLAGItems.CopyFrom(txnCR_DR_FLAG.Items)
        If EnableValidation Then
            item.Validate(txnData)
        End If
        txnErrors.Add(item.errors)
    End Sub
'End Record Form txn LoadItemFromRequest method

'Record Form txn GetRedirectUrl method @14-FC9AB3C2

    Protected Function GettxnRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FinancialAccounts_maintain.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form txn GetRedirectUrl method

'Record Form txn ShowErrors method @14-791E75B0

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

'Record Form txn Insert Operation @14-CEA52B1C

    Protected Sub txn_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        Dim ExecuteFlag As Boolean = True
        txnIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Insert Operation

'Button Button_Insert OnClick. @15-4EBF1419
        If CType(sender,Control).ID = "txnButton_Insert" Then
            RedirectUrl = GettxnRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @15-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form txn BeforeInsert tail @14-0903FEAD
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

'Record Form txn AfterInsert tail  @14-B92F6AE8
        End If
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn AfterInsert tail 

'Record Form txn Update Operation @14-990AD327

    Protected Sub txn_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form txn Update Operation

'Record Form txn Before Update tail @14-E6529729
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
'End Record Form txn Before Update tail

'Record Form txn Update Operation tail @14-D1CD6F2C
        ErrorFlag=(txnErrors.Count > 0)
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form txn Update Operation tail

'Record Form txn Delete Operation @14-72AB614A
    Protected Sub txn_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As txnItem = New txnItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form txn Delete Operation

'Record Form BeforeDelete tail @14-E6529729
        txnParameters()
        txnLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @14-E92D4CBE
        If ErrorFlag Then
            txnShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form txn Cancel Operation @14-65F0173A

    Protected Sub txn_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As txnItem = New txnItem()
        txnIsSubmitted = True
        Dim RedirectUrl As String = ""
        txnLoadItemFromRequest(item, True)
'End Record Form txn Cancel Operation

'Record Form txn Cancel Operation tail @14-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form txn Cancel Operation tail

'Grid Grid1 Bind @54-78E5CD6D

    Protected Sub Grid1Bind()
        If Not Grid1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Grid1",GetType(Grid1DataProvider.SortFields), 10, 100)
        End If
'End Grid Grid1 Bind

'Grid Form Grid1 BeforeShow tail @54-420BD297
        Grid1Parameters()
        Grid1Data.SortField = CType(ViewState("Grid1SortField"),Grid1DataProvider.SortFields)
        Grid1Data.SortDir = CType(ViewState("Grid1SortDir"),SortDirections)
        Grid1Data.PageNumber = CInt(ViewState("Grid1PageNumber"))
        Grid1Data.RecordsPerPage = CInt(ViewState("Grid1PageSize"))
        Grid1Repeater.DataSource = Grid1Data.GetResultSet(PagesCount, Grid1Operations)
        ViewState("Grid1PagesCount") = PagesCount
        Dim item As Grid1Item = New Grid1Item()
        Grid1Repeater.DataBind
        FooterIndex = Grid1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            Grid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form Grid1 BeforeShow tail

'Grid Grid1 Bind tail @54-E31F8E2A
    End Sub
'End Grid Grid1 Bind tail

'Grid Grid1 Table Parameters @54-2D5619E8

    Protected Sub Grid1Parameters()
        Try
            Grid1Data.UrlSTUDENT_ID = IntegerParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", Nothing, false)
            Grid1Data.UrlENROLMENT_YEAR = IntegerParameter.GetParam("ENROLMENT_YEAR", ParameterSourceType.URL, "", Year(Now()), false)
            Grid1Data.PostinsertFlag = IntegerParameter.GetParam("insertFlag", ParameterSourceType.Form, "", 0, false)

        Catch
            Dim ParentControls As ControlCollection=Grid1Repeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Grid1Repeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Grid1: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Grid1 Table Parameters

'Grid Grid1 ItemDataBound event @54-017ABF31

    Protected Sub Grid1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Grid1Item = CType(e.Item.DataItem,Grid1Item)
        Dim Item as Grid1Item = DataItem
        Dim FormDataSource As Grid1Item() = CType(Grid1Repeater.DataSource, Grid1Item())
        Dim Grid1DataRows As Integer = FormDataSource.Length
        Dim Grid1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Grid1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Grid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Grid1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Grid1TODAY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1TODAY"),System.Web.UI.WebControls.Literal)
            Dim Grid1TXN_CODE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1TXN_CODE"),System.Web.UI.WebControls.Literal)
            Dim Grid1AMOUNT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1AMOUNT"),System.Web.UI.WebControls.Literal)
            Dim Grid1CR_DR_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1CR_DR_FLAG"),System.Web.UI.WebControls.Literal)
            Dim Grid1COMMENT As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Grid1COMMENT"),System.Web.UI.WebControls.Literal)
        End If
'End Grid Grid1 ItemDataBound event

'Grid Grid1 BeforeShowRow event @54-67518FFB
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
'End Grid Grid1 BeforeShowRow event

'Grid Grid1 Event BeforeShowRow. Action Custom Code @88-73254650
    ' -------------------------
	'ERA: add each row's AMOUNT to a running total (unfuddle #8)
	' check debit or credit and add/subtract appropriately
		if DataItem.cr_dr_flag.value = "C" then
			dblAutoBalance -=  DataItem.Amount.Value
		elseif DataItem.cr_dr_flag.value = "D" then
			dblAutoBalance +=  DataItem.Amount.Value
		end if
    ' -------------------------
'End Grid Grid1 Event BeforeShowRow. Action Custom Code

'Grid Grid1 BeforeShowRow event tail @54-477CF3C9
        End If
'End Grid Grid1 BeforeShowRow event tail

'Grid Grid1 ItemDataBound event tail @54-C2C5318F
        If Grid1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Grid1CurrentRowNumber, ListItemType.Item)
            Grid1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Grid1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Grid1 ItemDataBound event tail

'Grid Grid1 ItemCommand event @54-E28C8E00

    Protected Sub Grid1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Grid1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Grid1SortDir"),SortDirections) = SortDirections._Asc And ViewState("Grid1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Grid1SortDir")=SortDirections._Desc
                Else
                    ViewState("Grid1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Grid1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Grid1DataProvider.SortFields = 0
            ViewState("Grid1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Grid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Grid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Grid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Grid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Grid1Bind
        End If
    End Sub
'End Grid Grid1 ItemCommand event

'Record Form TXN1 Parameters @73-7864587B

    Protected Sub TXN1Parameters()
        Dim item As new TXN1Item
        Try
            TXN1Data.UrlTXN_ID = FloatParameter.GetParam("TXN_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            TXN1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form TXN1 Parameters

'Record Form TXN1 Show method @73-68454721
    Protected Sub TXN1Show()
        If TXN1Operations.None Then
            TXN1Holder.Visible = False
            Return
        End If
        Dim item As TXN1Item = TXN1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not TXN1Operations.AllowRead
        TXN1Errors.Add(item.errors)
        If TXN1Errors.Count > 0 Then
            TXN1ShowErrors()
            Return
        End If
'End Record Form TXN1 Show method

'Record Form TXN1 BeforeShow tail @73-703E5916
        TXN1Parameters()
        TXN1Data.FillItem(item, IsInsertMode)
        TXN1Holder.DataBind()
        TXN1Button_Insert_Payment.Visible=IsInsertMode AndAlso TXN1Operations.AllowInsert
        TXN1Button_Insert_FullPayment.Visible=IsInsertMode AndAlso TXN1Operations.AllowInsert
        TXN1TXN_DATE.Text=item.TXN_DATE.GetFormattedValue()
        TXN1DatePicker_TXN_DATEName = "TXN1DatePicker_TXN_DATE"
        TXN1DatePicker_TXN_DATEDateControl = TXN1TXN_DATE.ClientID
        TXN1DatePicker_TXN_DATE.DataBind()
        TXN1TXN_CODE.Value = item.TXN_CODE.GetFormattedValue()
        TXN1CR_DR_FLAG.Value = item.CR_DR_FLAG.GetFormattedValue()
        TXN1ENROLMENT_YEAR.Value = item.ENROLMENT_YEAR.GetFormattedValue()
        TXN1STUDENT_ID.Value = item.STUDENT_ID.GetFormattedValue()
        TXN1COMMENTS.Value = item.COMMENTS.GetFormattedValue()
        TXN1AMOUNT.Text=item.AMOUNT.GetFormattedValue()
        TXN1CAMPUS_CODE.Value = item.CAMPUS_CODE.GetFormattedValue()
        TXN1LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        TXN1LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
'End Record Form TXN1 BeforeShow tail

'Record TXN1 Event BeforeShow. Action Retrieve Value for Control @84-DF0F1DC7
            TXN1ENROLMENT_YEAR.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("ENROLMENT_YEAR"))).GetFormattedValue()
'End Record TXN1 Event BeforeShow. Action Retrieve Value for Control

'Record TXN1 Event BeforeShow. Action Retrieve Value for Control @85-0B3512D2
            TXN1STUDENT_ID.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("STUDENT_ID"))).GetFormattedValue()
'End Record TXN1 Event BeforeShow. Action Retrieve Value for Control

'Record Form TXN1 Show method tail @73-6963989F
        If TXN1Errors.Count > 0 Then
            TXN1ShowErrors()
        End If
    End Sub
'End Record Form TXN1 Show method tail

'Record Form TXN1 LoadItemFromRequest method @73-E5955B1D

    Protected Sub TXN1LoadItemFromRequest(item As TXN1Item, ByVal EnableValidation As Boolean)
        Try
        item.TXN_DATE.IsEmpty = IsNothing(Request.Form(TXN1TXN_DATE.UniqueID))
        If ControlCustomValues("TXN1TXN_DATE") Is Nothing Then
            item.TXN_DATE.SetValue(TXN1TXN_DATE.Text)
        Else
            item.TXN_DATE.SetValue(ControlCustomValues("TXN1TXN_DATE"))
        End If
        Catch ae As ArgumentException
            TXN1Errors.Add("TXN_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"DATE","dd/mm/yyyy"))
        End Try
        item.TXN_CODE.IsEmpty = IsNothing(Request.Form(TXN1TXN_CODE.UniqueID))
        item.TXN_CODE.SetValue(TXN1TXN_CODE.Value)
        item.CR_DR_FLAG.IsEmpty = IsNothing(Request.Form(TXN1CR_DR_FLAG.UniqueID))
        item.CR_DR_FLAG.SetValue(TXN1CR_DR_FLAG.Value)
        Try
        item.ENROLMENT_YEAR.IsEmpty = IsNothing(Request.Form(TXN1ENROLMENT_YEAR.UniqueID))
        item.ENROLMENT_YEAR.SetValue(TXN1ENROLMENT_YEAR.Value)
        Catch ae As ArgumentException
            TXN1Errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_IncorrectValue,"ENROLMENT YEAR"))
        End Try
        Try
        item.STUDENT_ID.IsEmpty = IsNothing(Request.Form(TXN1STUDENT_ID.UniqueID))
        item.STUDENT_ID.SetValue(TXN1STUDENT_ID.Value)
        Catch ae As ArgumentException
            TXN1Errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_IncorrectValue,"STUDENT ID"))
        End Try
        item.COMMENTS.IsEmpty = IsNothing(Request.Form(TXN1COMMENTS.UniqueID))
        item.COMMENTS.SetValue(TXN1COMMENTS.Value)
        Try
        item.AMOUNT.IsEmpty = IsNothing(Request.Form(TXN1AMOUNT.UniqueID))
        If ControlCustomValues("TXN1AMOUNT") Is Nothing Then
            item.AMOUNT.SetValue(TXN1AMOUNT.Text)
        Else
            item.AMOUNT.SetValue(ControlCustomValues("TXN1AMOUNT"))
        End If
        Catch ae As ArgumentException
            TXN1Errors.Add("AMOUNT",String.Format(Resources.strings.CCS_IncorrectFormat,"AMOUNT","0.00"))
        End Try
        item.CAMPUS_CODE.IsEmpty = IsNothing(Request.Form(TXN1CAMPUS_CODE.UniqueID))
        item.CAMPUS_CODE.SetValue(TXN1CAMPUS_CODE.Value)
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(TXN1LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(TXN1LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(TXN1LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(TXN1LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            TXN1Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST_ALTERED_DATE","dd/mm/yyyy"))
        End Try
        If EnableValidation Then
            item.Validate(TXN1Data)
        End If
        TXN1Errors.Add(item.errors)
    End Sub
'End Record Form TXN1 LoadItemFromRequest method

'Record Form TXN1 GetRedirectUrl method @73-5CE72661

    Protected Function GetTXN1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form TXN1 GetRedirectUrl method

'Record Form TXN1 ShowErrors method @73-D93775A2

    Protected Sub TXN1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To TXN1Errors.Count - 1
        Select Case TXN1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & TXN1Errors(i)
        End Select
        Next i
        TXN1Error.Visible = True
        TXN1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form TXN1 ShowErrors method

'Record Form TXN1 Insert Operation @73-72B5265F

    Protected Sub TXN1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN1Item = New TXN1Item()
        Dim ExecuteFlag As Boolean = True
        TXN1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN1 Insert Operation

'Button Button_Insert_Payment OnClick. @74-BB00BFCE
        If CType(sender,Control).ID = "TXN1Button_Insert_Payment" Then
            RedirectUrl = GetTXN1RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Insert_Payment OnClick.

'Button Button_Insert_Payment Event OnClick. Action Custom Code @92-73254650
    ' -------------------------
    ' ERA: don't Insert if nil payment, but process normal auto inserts
		if (TXN1AMOUNT.Text = "0.00") then
			ExecuteFlag = false
		end if
    ' -------------------------
'End Button Button_Insert_Payment Event OnClick. Action Custom Code

'Button Button_Insert_Payment OnClick tail. @74-477CF3C9
        End If
'End Button Button_Insert_Payment OnClick tail.

'Button Button_Insert_FullPayment OnClick. @86-7D6294DA
        If CType(sender,Control).ID = "TXN1Button_Insert_FullPayment" Then
            RedirectUrl = GetTXN1RedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Insert_FullPayment OnClick.

'Button Button_Insert_FullPayment Event OnClick. Action Retrieve Value for Control @89-A402748E
        TXN1AMOUNT.Text = (New SingleField("0.00", dblAutoBalance)).GetFormattedValue()
'End Button Button_Insert_FullPayment Event OnClick. Action Retrieve Value for Control

'Button Button_Insert_FullPayment OnClick tail. @86-477CF3C9
        End If
'End Button Button_Insert_FullPayment OnClick tail.

'Record TXN1 Event BeforeInsert. Action Custom Code @90-73254650
    ' -------------------------
    ' ERA: process the auto-calcs with InsertFlag = 1
	If (not ErrorFlag) Then

		Try
			Dim command=new SpCommand("sp_selCONTRIBUTION_ExistingStudent;1",Settings.connDECVPRODSQL2005DataAccessObject) 
			command.Parameters.Clear()
			CType(command,SpCommand).AddParameter("@RETURN_VALUE",0,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
			CType(command,SpCommand).AddParameter("@STUDENT_ID",TXN1STUDENT_ID.Value,ParameterType._Int,ParameterDirection.Input,0,0,10)
			CType(command,SpCommand).AddParameter("@ENROLMENT_YEAR",TXN1ENROLMENT_YEAR.Value,ParameterType._Int,ParameterDirection.Input,0,0,10)
			CType(command,SpCommand).AddParameter("@insertFlag",1,ParameterType._Int,ParameterDirection.Input,0,0,10)	' do insert via @insertFlag=1
			'debug
			command.ExecuteNonQuery
 		Catch ex As Exception
			TXN1Errors.Add("AutoInsert",ex.Message)
			ErrorFlag = True
		Finally

		End Try

	End If
    ' -------------------------
'End Record TXN1 Event BeforeInsert. Action Custom Code

'Record Form TXN1 BeforeInsert tail @73-AD661D7C
    TXN1Parameters()
    TXN1LoadItemFromRequest(item, EnableValidation)
    If TXN1Operations.AllowInsert Then
        ErrorFlag=(TXN1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                TXN1Data.InsertItem(item)
            Catch ex As Exception
                TXN1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form TXN1 BeforeInsert tail

'Record Form TXN1 AfterInsert tail  @73-25ED9360
        End If
        ErrorFlag=(TXN1Errors.Count > 0)
        If ErrorFlag Then
            TXN1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN1 AfterInsert tail 

'Record Form TXN1 Update Operation @73-5F8D7ABC

    Protected Sub TXN1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN1Item = New TXN1Item()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        TXN1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form TXN1 Update Operation

'Record Form TXN1 Before Update tail @73-504DFD46
        TXN1Parameters()
        TXN1LoadItemFromRequest(item, EnableValidation)
'End Record Form TXN1 Before Update tail

'Record Form TXN1 Update Operation tail @73-FA111D47
        ErrorFlag=(TXN1Errors.Count > 0)
        If ErrorFlag Then
            TXN1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form TXN1 Update Operation tail

'Record Form TXN1 Delete Operation @73-0C833DCE
    Protected Sub TXN1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        TXN1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As TXN1Item = New TXN1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form TXN1 Delete Operation

'Record Form BeforeDelete tail @73-504DFD46
        TXN1Parameters()
        TXN1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @73-A14448B7
        If ErrorFlag Then
            TXN1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form TXN1 Cancel Operation @73-001FDE82

    Protected Sub TXN1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As TXN1Item = New TXN1Item()
        TXN1IsSubmitted = True
        Dim RedirectUrl As String = ""
        TXN1LoadItemFromRequest(item, False)
'End Record Form TXN1 Cancel Operation

'Button Button_Cancel OnClick. @87-6CFD449D
    If CType(sender,Control).ID = "TXN1Button_Cancel" Then
        RedirectUrl = GetTXN1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @87-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form TXN1 Cancel Operation tail @73-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form TXN1 Cancel Operation tail

'DEL  	    ' -------------------------
'DEL  		'ERA: add each row's AMOUNT to a running total (unfuddle #8)
'DEL  		' check debit or credit and add/subtract appropriately
'DEL  			if DataItem.cr_dr_flag.value = "C" then
'DEL  				dblAutoBalance -=  DataItem.Amount.Value
'DEL  			elseif DataItem.cr_dr_flag.value = "D" then
'DEL  				dblAutoBalance +=  DataItem.Amount.Value
'DEL  			end if
'DEL  	    ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: don't Insert if nil payment, but process normal auto inserts
'DEL  		if (TXN1AMOUNT.Text = "0.00") then
'DEL  			ExecuteFlag = false
'DEL  		end if
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: process the auto-calcs with InsertFlag = 1
'DEL  	If (not ErrorFlag) Then
'DEL  
'DEL  		Try
'DEL  			Dim command=new SpCommand("sp_selCONTRIBUTION_ExistingStudent;1",Settings.connDECVPRODSQL2005DataAccessObject) 
'DEL  			command.Parameters.Clear()
'DEL  			CType(command,SpCommand).AddParameter("@RETURN_VALUE",0,ParameterType._Int,ParameterDirection.ReturnValue,0,0,10)
'DEL  			CType(command,SpCommand).AddParameter("@STUDENT_ID",TXN1STUDENT_ID.Value,ParameterType._Int,ParameterDirection.Input,0,0,10)
'DEL  			CType(command,SpCommand).AddParameter("@ENROLMENT_YEAR",TXN1ENROLMENT_YEAR.Value,ParameterType._Int,ParameterDirection.Input,0,0,10)
'DEL  			CType(command,SpCommand).AddParameter("@insertFlag",1,ParameterType._Int,ParameterDirection.Input,0,0,10)	' do insert via @insertFlag=1
'DEL  			'debug
'DEL  			command.ExecuteNonQuery
'DEL   		Catch ex As Exception
'DEL  			TXN1Errors.Add("AutoInsert",ex.Message)
'DEL  			ErrorFlag = True
'DEL  		Finally
'DEL  
'DEL  		End Try
'DEL  
'DEL  	End If
'DEL  
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      'ERA: put the dblAccountBalance into the lblAccountBalance
'DEL  	' BUT note: if lblAccountBalance < 0 then reverse sign and change CRDR flag
'DEL  	if dblAccountBalance < 0 then
'DEL  		dblAccountBalance = (dblAccountBalance * -1.00)
'DEL  		Grid_TransactionslblCRDRFlag.Text = "CR"
'DEL  	else
'DEL  		Grid_TransactionslblCRDRFlag.Text = "DR"
'DEL  	end if
'DEL  	Grid_TransactionslblAcctBalance.Text = dblAccountBalance.tostring("0.00")	'force formatting as was showing crap like '2.8421709430404E-14'
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      'ERA: add each row's AMOUNT to a running total
'DEL  		If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'DEL  			' check debit or credit and add/subtract appropriately
'DEL  			if DataItem.cr_dr_flag.value = "C" then
'DEL      			dblAccountBalance -=  DataItem.Amount.Value
'DEL  			elseif DataItem.cr_dr_flag.value = "D" then
'DEL  				dblAccountBalance +=  DataItem.Amount.Value
'DEL  			end if
'DEL    		End If
'DEL      ' -------------------------

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-3FEF55C9
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FinancialAccounts_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Grid_TransactionsData = New Grid_TransactionsDataProvider()
        Grid_TransactionsOperations = New FormSupportedOperations(False, True, False, False, False)
        txnData = New txnDataProvider()
        txnOperations = New FormSupportedOperations(False, False, True, False, False)
        Grid1Data = New Grid1DataProvider()
        Grid1Operations = New FormSupportedOperations(False, True, False, False, False)
        TXN1Data = New TXN1DataProvider()
        TXN1Operations = New FormSupportedOperations(False, False, True, False, False)
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

