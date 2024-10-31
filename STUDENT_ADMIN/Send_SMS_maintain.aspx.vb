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

Namespace DECV_PROD2007.Send_SMS_maintain 'Namespace @1-417B6534

'Forms Definition @1-2D5778D0
Public Class [Send_SMS_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-411E0013
    Protected STUDENT_SMS_LOGData As STUDENT_SMS_LOGDataProvider
    Protected STUDENT_SMS_LOGOperations As FormSupportedOperations
    Protected STUDENT_SMS_LOGCurrentRowNumber As Integer
    Protected NewSMSRecordData As NewSMSRecordDataProvider
    Protected NewSMSRecordErrors As NameValueCollection = New NameValueCollection()
    Protected NewSMSRecordOperations As FormSupportedOperations
    Protected NewSMSRecordIsSubmitted As Boolean = False
    Protected Send_SMS_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-075F0E6D
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            PageData.FillItem(item)
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            STUDENT_SMS_LOGBind
            NewSMSRecordShow()
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @51-73254650
    ' -------------------------
    'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")
	 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MenuStudentMaintain.visible = true
     End If
    ' -------------------------
'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

'Page Send_SMS_maintain Event BeforeShow. Action Custom Code @47-73254650
    ' -------------------------
    ' ERA: 23-Aug-2010|EA| Collect this user's list of Access Groups and put into Session Var "AccessGroups", if not there already
	if Session("AccessGroups") = "" then
		Session("AccessGroups") = Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("exec sps_GetUserAccessFunctions " & Settings.connDECVPRODSQL2005DataAccessObject.ToSql(session("UserID").ToString(), FieldType._Text, true))
	end if

    Dim boolAccessGroupM As Boolean = Session("AccessGroups").ToString.Contains("M")

	'if the user is in the correct access group, or they are the Pastoral Care teacher for this year, then allow Adding
	If (boolAccessGroupM) Then
		NewSMSRecordHolder.Visible = True
		Panel_MenuStudentMaintain.visible = true
		Link_BacktoSummary.visible = (not Panel_MenuStudentMaintain.visible)	' show the plain link if the menu isn't there
	else
		NewSMSRecordHolder.Visible = False
		Panel_MenuStudentMaintain.visible = false
		Link_BacktoSummary.visible = (not Panel_MenuStudentMaintain.visible)	' show the plain link if the menu isn't there
	end if

	' for debug 2-Dec-2010 - any user can send SMS for now. 
	NewSMSRecordHolder.Visible = True


    ' -------------------------
'End Page Send_SMS_maintain Event BeforeShow. Action Custom Code

'DEL      ' -------------------------
'DEL  	'######## TESTING ########
'DEL      'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
'DEL  	 If (DBUtility.AuthorizeUser(New String(){"9"})) Then
'DEL          NewSMSRecordHolder.Visible = True
'DEL  	 Else
'DEL  	 	NewSMSRecordHolder.Visible = False
'DEL       End If
'DEL  	 '######## TESTING ########
'DEL      ' -------------------------


    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid STUDENT_SMS_LOG Bind @2-314F12B7

    Protected Sub STUDENT_SMS_LOGBind()
        If Not STUDENT_SMS_LOGOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"STUDENT_SMS_LOG",GetType(STUDENT_SMS_LOGDataProvider.SortFields), 50, 100)
        End If
'End Grid STUDENT_SMS_LOG Bind

'Grid Form STUDENT_SMS_LOG BeforeShow tail @2-8C796402
        STUDENT_SMS_LOGParameters()
        STUDENT_SMS_LOGData.SortField = CType(ViewState("STUDENT_SMS_LOGSortField"),STUDENT_SMS_LOGDataProvider.SortFields)
        STUDENT_SMS_LOGData.SortDir = CType(ViewState("STUDENT_SMS_LOGSortDir"),SortDirections)
        STUDENT_SMS_LOGData.PageNumber = CInt(ViewState("STUDENT_SMS_LOGPageNumber"))
        STUDENT_SMS_LOGData.RecordsPerPage = CInt(ViewState("STUDENT_SMS_LOGPageSize"))
        STUDENT_SMS_LOGRepeater.DataSource = STUDENT_SMS_LOGData.GetResultSet(PagesCount, STUDENT_SMS_LOGOperations)
        ViewState("STUDENT_SMS_LOGPagesCount") = PagesCount
        Dim item As STUDENT_SMS_LOGItem = New STUDENT_SMS_LOGItem()
        STUDENT_SMS_LOGRepeater.DataBind
        FooterIndex = STUDENT_SMS_LOGRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            STUDENT_SMS_LOGRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim Sorter_mobileno_sendtoSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SMS_LOGRepeater.Controls(0).FindControl("Sorter_mobileno_sendtoSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_sms_textSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SMS_LOGRepeater.Controls(0).FindControl("Sorter_sms_textSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_datetime_createdSorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SMS_LOGRepeater.Controls(0).FindControl("Sorter_datetime_createdSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_sent_bySorter As DECV_PROD2007.Controls.Sorter = DirectCast(STUDENT_SMS_LOGRepeater.Controls(0).FindControl("Sorter_sent_bySorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(STUDENT_SMS_LOGRepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False
        Dim STUDENT_SMS_LOGLink1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(STUDENT_SMS_LOGRepeater.Controls(FooterIndex).FindControl("STUDENT_SMS_LOGLink1"),System.Web.UI.HtmlControls.HtmlAnchor)

        item.Link1Href = "Student_Comments_maintain.aspx"
        STUDENT_SMS_LOGLink1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
        STUDENT_SMS_LOGLink1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","", ViewState)
'End Grid Form STUDENT_SMS_LOG BeforeShow tail

'Grid STUDENT_SMS_LOG Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_SMS_LOG Bind tail

'Grid STUDENT_SMS_LOG Table Parameters @2-BAB57B7E

    Protected Sub STUDENT_SMS_LOGParameters()
        Try
            STUDENT_SMS_LOGData.Urlstudent_id = FloatParameter.GetParam("student_id", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=STUDENT_SMS_LOGRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(STUDENT_SMS_LOGRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid STUDENT_SMS_LOG: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid STUDENT_SMS_LOG Table Parameters

'Grid STUDENT_SMS_LOG ItemDataBound event @2-5A39D1F1

    Protected Sub STUDENT_SMS_LOGItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as STUDENT_SMS_LOGItem = CType(e.Item.DataItem,STUDENT_SMS_LOGItem)
        Dim Item as STUDENT_SMS_LOGItem = DataItem
        Dim FormDataSource As STUDENT_SMS_LOGItem() = CType(STUDENT_SMS_LOGRepeater.DataSource, STUDENT_SMS_LOGItem())
        Dim STUDENT_SMS_LOGDataRows As Integer = FormDataSource.Length
        Dim STUDENT_SMS_LOGIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            STUDENT_SMS_LOGCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(STUDENT_SMS_LOGRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, STUDENT_SMS_LOGCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim STUDENT_SMS_LOGmobileno_sendto As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SMS_LOGmobileno_sendto"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SMS_LOGsms_text As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SMS_LOGsms_text"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SMS_LOGdatetime_created As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SMS_LOGdatetime_created"),System.Web.UI.WebControls.Literal)
            Dim STUDENT_SMS_LOGsent_by As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("STUDENT_SMS_LOGsent_by"),System.Web.UI.WebControls.Literal)
        End If
'End Grid STUDENT_SMS_LOG ItemDataBound event

'Grid STUDENT_SMS_LOG ItemDataBound event tail @2-E85913D8
        If STUDENT_SMS_LOGIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(STUDENT_SMS_LOGCurrentRowNumber, ListItemType.Item)
            STUDENT_SMS_LOGRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            STUDENT_SMS_LOGItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid STUDENT_SMS_LOG ItemDataBound event tail

'Grid STUDENT_SMS_LOG ItemCommand event @2-D7C72EFD

    Protected Sub STUDENT_SMS_LOGItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= STUDENT_SMS_LOGRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("STUDENT_SMS_LOGSortDir"),SortDirections) = SortDirections._Asc And ViewState("STUDENT_SMS_LOGSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("STUDENT_SMS_LOGSortDir")=SortDirections._Desc
                Else
                    ViewState("STUDENT_SMS_LOGSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("STUDENT_SMS_LOGSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As STUDENT_SMS_LOGDataProvider.SortFields = 0
            ViewState("STUDENT_SMS_LOGSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("STUDENT_SMS_LOGPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("STUDENT_SMS_LOGPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("STUDENT_SMS_LOGPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("STUDENT_SMS_LOGPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            STUDENT_SMS_LOGBind
        End If
    End Sub
'End Grid STUDENT_SMS_LOG ItemCommand event

'Record Form NewSMSRecord Parameters @33-C5B0B30C

    Protected Sub NewSMSRecordParameters()
        Dim item As new NewSMSRecordItem
        Try
            NewSMSRecordData.Urlid = IntegerParameter.GetParam("id", ParameterSourceType.URL, "", Nothing, false)
            NewSMSRecordData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 0, false)
        Catch e As Exception
            NewSMSRecordErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form NewSMSRecord Parameters

'Record Form NewSMSRecord Show method @33-22DD88F2
    Protected Sub NewSMSRecordShow()
        If NewSMSRecordOperations.None Then
            NewSMSRecordHolder.Visible = False
            Return
        End If
        Dim item As NewSMSRecordItem = NewSMSRecordItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not NewSMSRecordOperations.AllowRead
        NewSMSRecordErrors.Add(item.errors)
        If NewSMSRecordErrors.Count > 0 Then
            NewSMSRecordShowErrors()
            Return
        End If
'End Record Form NewSMSRecord Show method

'Record Form NewSMSRecord BeforeShow tail @33-28039F20
        NewSMSRecordParameters()
        NewSMSRecordData.FillItem(item, IsInsertMode)
        NewSMSRecordHolder.DataBind()
        NewSMSRecordButton_Insert.Visible=IsInsertMode AndAlso NewSMSRecordOperations.AllowInsert
        item.mobileno_sendtoItems.SetSelection(item.mobileno_sendto.GetFormattedValue())
        NewSMSRecordmobileno_sendto.SelectedIndex = -1
        item.mobileno_sendtoItems.CopyTo(NewSMSRecordmobileno_sendto.Items)
        NewSMSRecordsms_text.Text=item.sms_text.GetFormattedValue()
        NewSMSRecordsms_status.Value = item.sms_status.GetFormattedValue()
        NewSMSRecordsent_by.Value = item.sent_by.GetFormattedValue()
        NewSMSRecordstudent_id.Value = item.student_id.GetFormattedValue()
        NewSMSRecordlblNoSMSNumbers.Text = item.lblNoSMSNumbers.GetFormattedValue()
        NewSMSRecordajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
        NewSMSRecordlblStudentID.Text = Server.HtmlEncode(item.lblStudentID.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form NewSMSRecord BeforeShow tail

'RadioButton mobileno_sendto Event BeforeShow. Action Custom Code @52-73254650
    ' -------------------------
    ' ERA: change direction of repeater - .net needs this, other languages use <BR> in HTML
	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
	NewSMSRecordmobileno_sendto.RepeatDirection = RepeatDirection.Vertical
    ' -------------------------
'End RadioButton mobileno_sendto Event BeforeShow. Action Custom Code

'Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control @42-161390B3
            NewSMSRecordstudent_id.Value = (New FloatField("", System.Web.HttpContext.Current.Request.QueryString("student_id"))).GetFormattedValue()
'End Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control

'Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control @45-C0719CE0
            NewSMSRecordsent_by.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control

'Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control @65-F7127C1E
            NewSMSRecordlblStudentID.Text = (New TextField("", System.Web.HttpContext.Current.Request.QueryString("student_id"))).GetFormattedValue()
'End Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control

'Record NewSMSRecord Event BeforeShow. Action Custom Code @54-73254650
    ' -------------------------
    ' ERA: 24-Aug-2010|EA| if no Mobile numbers (ie: NewSMSRecordmobileno_sendto.Items.Count = 0) then show message and turn off radiobutton and Send SMS button

		if NewSMSRecordmobileno_sendto.Items.Count = 0 then
			NewSMSRecordlblNoSMSNumbers.visible = true
			NewSMSRecordButton_Insert.Visible = false
			NewSMSRecordsms_text.visible = false
		else
			NewSMSRecordlblNoSMSNumbers.visible = false
		end if
		
    ' -------------------------
'End Record NewSMSRecord Event BeforeShow. Action Custom Code

'Record Form NewSMSRecord Show method tail @33-B0B19112
        If NewSMSRecordErrors.Count > 0 Then
            NewSMSRecordShowErrors()
        End If
    End Sub
'End Record Form NewSMSRecord Show method tail

'Record Form NewSMSRecord LoadItemFromRequest method @33-17CE4038

    Protected Sub NewSMSRecordLoadItemFromRequest(item As NewSMSRecordItem, ByVal EnableValidation As Boolean)
        item.mobileno_sendto.IsEmpty = IsNothing(Request.Form(NewSMSRecordmobileno_sendto.UniqueID))
        If Not IsNothing(NewSMSRecordmobileno_sendto.SelectedItem) Then
            item.mobileno_sendto.SetValue(NewSMSRecordmobileno_sendto.SelectedItem.Value)
        Else
            item.mobileno_sendto.Value = Nothing
        End If
        item.mobileno_sendtoItems.CopyFrom(NewSMSRecordmobileno_sendto.Items)
        item.sms_text.IsEmpty = IsNothing(Request.Form(NewSMSRecordsms_text.UniqueID))
        If ControlCustomValues("NewSMSRecordsms_text") Is Nothing Then
            item.sms_text.SetValue(NewSMSRecordsms_text.Text)
        Else
            item.sms_text.SetValue(ControlCustomValues("NewSMSRecordsms_text"))
        End If
        item.sms_status.IsEmpty = IsNothing(Request.Form(NewSMSRecordsms_status.UniqueID))
        item.sms_status.SetValue(NewSMSRecordsms_status.Value)
        item.sent_by.IsEmpty = IsNothing(Request.Form(NewSMSRecordsent_by.UniqueID))
        item.sent_by.SetValue(NewSMSRecordsent_by.Value)
        Try
        item.student_id.IsEmpty = IsNothing(Request.Form(NewSMSRecordstudent_id.UniqueID))
        item.student_id.SetValue(NewSMSRecordstudent_id.Value)
        Catch ae As ArgumentException
            NewSMSRecordErrors.Add("student_id",String.Format(Resources.strings.CCS_IncorrectValue,"Student Id"))
        End Try
        If EnableValidation Then
            item.Validate(NewSMSRecordData)
        End If
        NewSMSRecordErrors.Add(item.errors)
    End Sub
'End Record Form NewSMSRecord LoadItemFromRequest method

'Record Form NewSMSRecord GetRedirectUrl method @33-10791C50

    Protected Function GetNewSMSRecordRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form NewSMSRecord GetRedirectUrl method

'Record Form NewSMSRecord ShowErrors method @33-E06352D9

    Protected Sub NewSMSRecordShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To NewSMSRecordErrors.Count - 1
        Select Case NewSMSRecordErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & NewSMSRecordErrors(i)
        End Select
        Next i
        NewSMSRecordError.Visible = True
        NewSMSRecordErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form NewSMSRecord ShowErrors method

'Record Form NewSMSRecord Insert Operation @33-68F9137D

    Protected Sub NewSMSRecord_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewSMSRecordItem = New NewSMSRecordItem()
        Dim ExecuteFlag As Boolean = True
        NewSMSRecordIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewSMSRecord Insert Operation

'Button Button_Insert OnClick. @34-E41429C4
        If CType(sender,Control).ID = "NewSMSRecordButton_Insert" Then
            RedirectUrl = GetNewSMSRecordRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @34-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form NewSMSRecord BeforeInsert tail @33-763A2D30
    NewSMSRecordParameters()
    NewSMSRecordLoadItemFromRequest(item, EnableValidation)
    If NewSMSRecordOperations.AllowInsert Then
        ErrorFlag=(NewSMSRecordErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                NewSMSRecordData.InsertItem(item)
            Catch ex As Exception
                NewSMSRecordErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form NewSMSRecord BeforeInsert tail

'Record NewSMSRecord Event AfterInsert. Action Custom Code @46-73254650
    ' -------------------------
	If (Not ErrorFlag) Then
	'2-3-2011|EA| let's send an SMS
	'22-01-2016 new API login: decv, pass: gJp3FTyZ
	'SendSms("http://www.smsglobal.com/http-api.php", SMSGlobalData("decv", "deCv2009", "61419524056", "61412039611", "HELLO WORLD...DECV"))
		dim url as string = "http://www.smsglobal.com/http-api.php"

		dim destination = item.mobileno_sendto.Value.ToString()
      ' 7 Apr 2022|RW| Convert mobile number to simplified Aus format if needed, as the API service currently chokes on international prefix numbers
      If (destination.StartsWith("+61 4")) Then
         destination = destination.Replace("+61 4", "04")
      End If
		'dim smstext as string = item.sms_text.Value
		' 16-Nov-2011|EA| update to use regex like Javascript to strip out unusual characters
		' 22-May-2014|EA| allow weird chars now, so remove this (#610)
		'Dim mask As Regex = New Regex("[^0-9a-zA-Z\s\.\!\@\(\)\+\?\-]",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        'dim smstext as string = (mask.Replace(item.sms_text.Value,""))
        dim smstext as string = (item.sms_text.Value)

		' double check for mobile number (10 digits+) and some message (5 chars+)
		if (destination.Length > 9 AND smstext.Length > 4) then
			
			'12-Mar-2018|EA| collect URL, user/pwd, Proxy addresses from web.config instead of hardcoding, after SMS Global API changes
			url = System.Configuration.ConfigurationManager.AppSettings("SMSGlobal_EndpointURL") 
			dim smsuser as string = System.Configuration.ConfigurationManager.AppSettings("SMSGlobal_Username") 'decv
			dim smspwd as string = System.Configuration.ConfigurationManager.AppSettings("SMSGlobal_PWD") 'gJp3FTyZ
			dim webproxy as string = System.Configuration.ConfigurationManager.AppSettings("DECVWebProxy") 
			
	
			' put all the bits into a nice string
	  		Dim postData As New System.Text.StringBuilder("action=sendsms")
	        postData.Append("&user=") : postData.Append(System.Web.HttpUtility.UrlEncode(smsuser))		' HARDCODE USER + PASSWORD
	        postData.Append("&password=") : postData.Append(System.Web.HttpUtility.UrlEncode(smspwd))
	        postData.Append("&from=") : postData.Append(System.Web.HttpUtility.UrlEncode("VSV"))	' DECV - is actually covered in SMS
	        postData.Append("&to=") : postData.Append(System.Web.HttpUtility.UrlEncode(destination))
	        postData.Append("&text=") : postData.Append(System.Web.HttpUtility.UrlEncode(smstext))
   
	   		' prepare for sending
	        Dim encoding As New System.Text.UTF8Encoding
	        Dim data As Byte() = encoding.GetBytes(postData.ToString())
		'Local Proxy ---VB 22/03/2011
		'Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy:8080", True)
			' Mar-2011, from Vikas B. set up proxy
			'24-July-2014|EA| proxy:8080 had problems so changed to proxy.education.netspace.net.au:8080 per Matt A
			'12-Mar-2018|EA| collect Proxy address from web.config instead of hardcoding, after SMS Global API changes
			'Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy.education.netspace.net.au:8080", True)
			Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy(webproxy, True)
	      	Dim smsRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
	      	smsRequest.Proxy = lclProxy	' use proxy in request.

	        smsRequest.Method = "POST"
	        smsRequest.ContentType = "application/x-www-form-urlencoded"
	        smsRequest.ContentLength = data.Length

	        Dim smsDataStream As System.IO.Stream
	        smsDataStream = smsRequest.GetRequestStream()
	        smsDataStream.Write(data, 0, data.Length)
	        smsDataStream.Close()

			' may not need response, yet
	        'Dim smsResponse As System.Net.WebResponse = smsRequest.GetResponse()

	        'Dim responseBuffer(smsResponse.ContentLength - 1) As Byte
	        'smsResponse.GetResponseStream().Read(responseBuffer, 0, smsResponse.ContentLength - 1)
	        'smsResponse.Close()
	        'Return encoding.GetString(responseBuffer)

			' and if Response is Ok, then we could add comment, or wait for confirmation through SMS Responder.

		    'ERA: 07-April-2011|EA| after insert, do a small insert into the STUDENT_COMMENT to show comment without phone number as CONTACT_SMS
			'NOTE: if using the NewDao.ToSql(somedata,FieldType._Text) then exclude enclosing single quotes as they are added automatically
			Try
				Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
				Dim Sql As String = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(smstext,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'CONTACT_SMS'"
				'response.write(Sql.ToUpper)
				'response.end
				NewDao.RunSql(Sql)
	        Catch ex As Exception
	            NewSMSRecordErrors.Add("Comment Insert","Error inserting Comment: " & ex.Message)
	            ErrorFlag = True
	        End Try

		End If
	End If
    ' -------------------------
'End Record NewSMSRecord Event AfterInsert. Action Custom Code


'Record Form NewSMSRecord AfterInsert tail  @33-AE45AF05
        End If
        ErrorFlag=(NewSMSRecordErrors.Count > 0)
        If ErrorFlag Then
            NewSMSRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewSMSRecord AfterInsert tail 

'Record Form NewSMSRecord Update Operation @33-6B20D676

    Protected Sub NewSMSRecord_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewSMSRecordItem = New NewSMSRecordItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        NewSMSRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form NewSMSRecord Update Operation

'Record Form NewSMSRecord Before Update tail @33-2812894C
        NewSMSRecordParameters()
        NewSMSRecordLoadItemFromRequest(item, EnableValidation)
'End Record Form NewSMSRecord Before Update tail

'Record Form NewSMSRecord Update Operation tail @33-2A0ECE1A
        ErrorFlag=(NewSMSRecordErrors.Count > 0)
        If ErrorFlag Then
            NewSMSRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form NewSMSRecord Update Operation tail

'Record Form NewSMSRecord Delete Operation @33-BA23108D
    Protected Sub NewSMSRecord_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        NewSMSRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As NewSMSRecordItem = New NewSMSRecordItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form NewSMSRecord Delete Operation

'Record Form BeforeDelete tail @33-2812894C
        NewSMSRecordParameters()
        NewSMSRecordLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @33-E6E5E980
        If ErrorFlag Then
            NewSMSRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form NewSMSRecord Cancel Operation @33-F9A82531

    Protected Sub NewSMSRecord_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As NewSMSRecordItem = New NewSMSRecordItem()
        NewSMSRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        NewSMSRecordLoadItemFromRequest(item, False)
'End Record Form NewSMSRecord Cancel Operation

'Button Button_Cancel OnClick. @35-FDE3E34B
    If CType(sender,Control).ID = "NewSMSRecordButton_Cancel" Then
        RedirectUrl = GetNewSMSRecordRedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @35-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form NewSMSRecord Cancel Operation tail @33-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form NewSMSRecord Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-1867C0F1
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Send_SMS_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_SMS_LOGData = New STUDENT_SMS_LOGDataProvider()
        STUDENT_SMS_LOGOperations = New FormSupportedOperations(False, True, False, False, False)
        NewSMSRecordData = New NewSMSRecordDataProvider()
        NewSMSRecordOperations = New FormSupportedOperations(False, False, True, False, False)
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

