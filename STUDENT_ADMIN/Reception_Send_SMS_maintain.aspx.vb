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

Namespace DECV_PROD2007.Reception_Send_SMS_maintain 'Namespace @1-A8FD4AE4

'Forms Definition @1-E5853AF1
Public Class [Reception_Send_SMS_maintainPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-C4124AA9
    Protected STUDENT_SMS_LOGData As STUDENT_SMS_LOGDataProvider
    Protected STUDENT_SMS_LOGOperations As FormSupportedOperations
    Protected STUDENT_SMS_LOGCurrentRowNumber As Integer
    Protected NewSMSRecordData As NewSMSRecordDataProvider
    Protected NewSMSRecordErrors As NameValueCollection = New NameValueCollection()
    Protected NewSMSRecordOperations As FormSupportedOperations
    Protected NewSMSRecordIsSubmitted As Boolean = False
    Protected Reception_Send_SMS_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-B962A530
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            STUDENT_SMS_LOGBind
            NewSMSRecordShow()
    End If
'End Page_Load Event BeforeIsPostBack

'DEL      ' -------------------------

'Page Reception_Send_SMS_maintain Event BeforeShow. Action Custom Code @47-73254650
    ' -------------------------
    ' Write your own code here.
    ' -------------------------
'End Page Reception_Send_SMS_maintain Event BeforeShow. Action Custom Code


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

'Grid Form STUDENT_SMS_LOG BeforeShow tail @2-FEE58D46
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

'End Grid Form STUDENT_SMS_LOG BeforeShow tail

'Grid STUDENT_SMS_LOG Bind tail @2-E31F8E2A
    End Sub
'End Grid STUDENT_SMS_LOG Bind tail

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

'DEL      ' -------------------------
'DEL      ' ERA: change direction of repeater - .net needs this, other languages use <BR> in HTML
'DEL  	'  this saves editting the aspx page (which then causing problems as it doesn't update after that)
'DEL  	NewSMSRecordmobileno_sendto.RepeatDirection = RepeatDirection.Vertical
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL      ' ERA: 24-Aug-2010|EA| if no Mobile numbers (ie: NewSMSRecordmobileno_sendto.Items.Count = 0) then show message and turn off radiobutton and Send SMS button
'DEL  
'DEL  		if NewSMSRecordmobileno_sendto.Items.Count = 0 then
'DEL  			NewSMSRecordlblNoSMSNumbers.visible = true
'DEL  			NewSMSRecordButton_Insert.Visible = false
'DEL  			NewSMSRecordsms_text.visible = false
'DEL  		else
'DEL  			NewSMSRecordlblNoSMSNumbers.visible = false
'DEL  		end if
'DEL  		
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  	If (Not ErrorFlag) Then
'DEL  	'2-3-2011|EA| let's send an SMS
'DEL  	'SendSms("http://www.smsglobal.com/http-api.php", SMSGlobalData("decv", "deCv2009", "61419524056", "61412039611", "HELLO WORLD...DECV"))
'DEL  		dim url as string = "http://www.smsglobal.com/http-api.php"
'DEL  
'DEL  		dim destination as string = item.mobileno_sendto.Value
'DEL  		dim smstext as string = item.sms_text.Value
'DEL  
'DEL  		' double check for mobile number (10 digits+) and some message (5 chars+)
'DEL  		if (destination.Length > 9 AND smstext.Length > 4) then
'DEL  	
'DEL  			' put all the bits into a nice string
'DEL  	  		Dim postData As New System.Text.StringBuilder("action=sendsms")
'DEL  	        postData.Append("&user=") : postData.Append(System.Web.HttpUtility.UrlEncode("decv"))		' HARDCODE USER + PASSWORD
'DEL  	        postData.Append("&password=") : postData.Append(System.Web.HttpUtility.UrlEncode("deCv2009"))
'DEL  	        postData.Append("&from=") : postData.Append(System.Web.HttpUtility.UrlEncode("DECV"))	' DECV - is actually covered in SMS
'DEL  	        postData.Append("&to=") : postData.Append(System.Web.HttpUtility.UrlEncode(destination))
'DEL  	        postData.Append("&text=") : postData.Append(System.Web.HttpUtility.UrlEncode(smstext))
'DEL     
'DEL  	   		' prepare for sending
'DEL  	        Dim encoding As New System.Text.UTF8Encoding
'DEL  	        Dim data As Byte() = encoding.GetBytes(postData.ToString())
'DEL  		'Local Proxy ---VB 22/03/2011
'DEL  		Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy:8080", True)
'DEL  			' Mar-2011, from Vikas B. set up proxy
'DEL  			Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy:8080", True)
'DEL  	      	Dim smsRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
'DEL  	      	smsRequest.Proxy = lclProxy	' use proxy in request.
'DEL  
'DEL  	        smsRequest.Method = "POST"
'DEL  	        smsRequest.ContentType = "application/x-www-form-urlencoded"
'DEL  	        smsRequest.ContentLength = data.Length
'DEL  
'DEL  	        Dim smsDataStream As System.IO.Stream
'DEL  	        smsDataStream = smsRequest.GetRequestStream()
'DEL  	        smsDataStream.Write(data, 0, data.Length)
'DEL  	        smsDataStream.Close()
'DEL  
'DEL  			' may not need response, yet
'DEL  	        'Dim smsResponse As System.Net.WebResponse = smsRequest.GetResponse()
'DEL  
'DEL  	        'Dim responseBuffer(smsResponse.ContentLength - 1) As Byte
'DEL  	        'smsResponse.GetResponseStream().Read(responseBuffer, 0, smsResponse.ContentLength - 1)
'DEL  	        'smsResponse.Close()
'DEL  	        'Return encoding.GetString(responseBuffer)
'DEL  
'DEL  			' and if Response is Ok, then we could add comment, or wait for confirmation through SMS Responder.
'DEL  
'DEL  		    'ERA: 07-April-2011|EA| after insert, do a small insert into the STUDENT_COMMENT to show comment without phone number as CONTACT_SMS
'DEL  			'NOTE: if using the NewDao.ToSql(somedata,FieldType._Text) then exclude enclosing single quotes as they are added automatically
'DEL  			Try
'DEL  				Dim NewDao As DataAccessObject = Settings.connDECVPRODSQL2005DataAccessObject
'DEL  				Dim Sql As String = "insert into STUDENT_COMMENT ([COMMENT_ID],[STUDENT_ID],[COMMENT],[LAST_ALTERED_BY],[LAST_ALTERED_DATE],[ACTIVE_STATUS],[COMMENT_TYPE]) SELECT (select (max(COMMENT_ID+1)) from STUDENT_COMMENT) , " & NewDao.ToSql(item.STUDENT_ID.Value, FieldType._Text, True) & ", "& NewDao.ToSql(item.sms_text.Value,FieldType._Text) & ", "& NewDao.ToSql(DBUtility.UserLogin.ToUpper,FieldType._Text, True) & ", getdate(), 'A', 'CONTACT_SMS'"
'DEL  				'response.write(Sql.ToUpper)
'DEL  				'response.end
'DEL  				NewDao.RunSql(Sql)
'DEL  	        Catch ex As Exception
'DEL  	            NewSMSRecordErrors.Add("Comment Insert","Error inserting Comment: " & ex.Message)
'DEL  	            ErrorFlag = True
'DEL  	        End Try
'DEL  
'DEL  		End If
'DEL  	End If
'DEL      ' -------------------------

'Record Form NewSMSRecord Parameters @33-648B3E1E

    Protected Sub NewSMSRecordParameters()
        Dim item As new NewSMSRecordItem
        Try
            NewSMSRecordData.Urlid = IntegerParameter.GetParam("id", ParameterSourceType.URL, "", Nothing, false)
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

'Record Form NewSMSRecord BeforeShow tail @33-2A7FAE86
        NewSMSRecordParameters()
        NewSMSRecordData.FillItem(item, IsInsertMode)
        NewSMSRecordHolder.DataBind()
        NewSMSRecordButton_Insert.Visible=IsInsertMode AndAlso NewSMSRecordOperations.AllowInsert
        NewSMSRecordmobileno_sendto.Text=item.mobileno_sendto.GetFormattedValue()
        NewSMSRecordsms_text.Text=item.sms_text.GetFormattedValue()
        NewSMSRecordsms_status.Value = item.sms_status.GetFormattedValue()
        NewSMSRecordsent_by.Value = item.sent_by.GetFormattedValue()
        NewSMSRecordstudent_id.Value = item.student_id.GetFormattedValue()
        NewSMSRecordajaxBusy.ImageUrl += item.ajaxBusy.GetFormattedValue()
        NewSMSRecordlblMobileError.Text = Server.HtmlEncode(item.lblMobileError.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form NewSMSRecord BeforeShow tail

'Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control @45-C0719CE0
            NewSMSRecordsent_by.Value = (New TextField("", (DBUtility.UserLogin.ToUpper))).GetFormattedValue()
'End Record NewSMSRecord Event BeforeShow. Action Retrieve Value for Control

'Record Form NewSMSRecord Show method tail @33-B0B19112
        If NewSMSRecordErrors.Count > 0 Then
            NewSMSRecordShowErrors()
        End If
    End Sub
'End Record Form NewSMSRecord Show method tail

'Record Form NewSMSRecord LoadItemFromRequest method @33-94747CD3

    Protected Sub NewSMSRecordLoadItemFromRequest(item As NewSMSRecordItem, ByVal EnableValidation As Boolean)
        item.mobileno_sendto.IsEmpty = IsNothing(Request.Form(NewSMSRecordmobileno_sendto.UniqueID))
        If ControlCustomValues("NewSMSRecordmobileno_sendto") Is Nothing Then
            item.mobileno_sendto.SetValue(NewSMSRecordmobileno_sendto.Text)
        Else
            item.mobileno_sendto.SetValue(ControlCustomValues("NewSMSRecordmobileno_sendto"))
        End If
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

'Record Form NewSMSRecord ShowErrors method @33-74BF991B

    Protected Sub NewSMSRecordShowErrors()
        NewSMSRecordlblMobileError.Text = ""
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To NewSMSRecordErrors.Count - 1
        Select Case NewSMSRecordErrors.AllKeys(i)
            Case "mobileno_sendto"
                If NewSMSRecordlblMobileError.Text <> "" Then  NewSMSRecordlblMobileError.Text &= "<br>"
                NewSMSRecordlblMobileError.Text = NewSMSRecordlblMobileError.Text & NewSMSRecordErrors(i)
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

				dim destination as string = item.mobileno_sendto.Value
				dim smstext as string = item.sms_text.Value

				' double check for mobile number (10 digits+) and some message (5 chars+)
				if (destination.Length > 9 AND smstext.Length > 4) then
	
					' put all the bits into a nice string
			  		Dim postData As New System.Text.StringBuilder("action=sendsms")
			        postData.Append("&user=") : postData.Append(System.Web.HttpUtility.UrlEncode("decv"))		' HARDCODE USER + PASSWORD
					'postData.Append("&password=") : postData.Append(System.Web.HttpUtility.UrlEncode("deCv2009")) Old details
			        postData.Append("&password=") : postData.Append(System.Web.HttpUtility.UrlEncode("gJp3FTyZ"))
			        postData.Append("&from=") : postData.Append(System.Web.HttpUtility.UrlEncode("DECV"))	' DECV - is actually covered in SMS
			        postData.Append("&to=") : postData.Append(System.Web.HttpUtility.UrlEncode(destination))
			        postData.Append("&text=") : postData.Append(System.Web.HttpUtility.UrlEncode(smstext))
   
			   		' prepare for sending
			        Dim encoding As New System.Text.UTF8Encoding
			        Dim data As Byte() = encoding.GetBytes(postData.ToString())
					' Mar-2011, from Vikas B. set up proxy
					' Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy:8080", True)
					' Changed to external proxy while testing internal proxy - ticket 656
					Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy.education.netspace.net.au:8080", True)
			      	Dim smsRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
			      	smsRequest.Proxy = lclProxy	' use proxy in request.

			        smsRequest.Method = "POST"
			        smsRequest.ContentType = "application/x-www-form-urlencoded"
			        smsRequest.ContentLength = data.Length

			        Dim smsDataStream As System.IO.Stream
			        smsDataStream = smsRequest.GetRequestStream()
			        smsDataStream.Write(data, 0, data.Length)
			        smsDataStream.Close()

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

'OnInit Event Body @1-053C3FD0
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Reception_Send_SMS_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        STUDENT_SMS_LOGData = New STUDENT_SMS_LOGDataProvider()
        STUDENT_SMS_LOGOperations = New FormSupportedOperations(False, True, False, False, False)
        NewSMSRecordData = New NewSMSRecordDataProvider()
        NewSMSRecordOperations = New FormSupportedOperations(False, False, True, False, False)
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

