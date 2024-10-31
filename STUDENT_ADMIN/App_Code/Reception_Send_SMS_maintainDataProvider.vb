'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
'End Using Statements

Namespace DECV_PROD2007.Reception_Send_SMS_maintain 'Namespace @1-A8FD4AE4

'Page Data Class @1-0B77669F
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Sub New()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

End Class
'End Page Data Class

'Page Data Provider Class @1-E3544B64
Public Class PageDataProvider
Dim j As Integer
'End Page Data Provider Class

'Page Data Provider Class Constructor @1-12B526DF
    Public Sub New()
    End Sub
'End Page Data Provider Class Constructor

'Page Data Provider Class GetResultSet Method @1-F73C4626
    Public Sub FillItem(ByVal item As PageItem)
'End Page Data Provider Class GetResultSet Method

'Page Data Provider Class GetResultSet Method tail @1-E31F8E2A
    End Sub
'End Page Data Provider Class GetResultSet Method tail

'Page Data Provider class Tail @1-A61BA892
End Class
'End Page Data Provider class Tail

'Grid STUDENT_SMS_LOG Item Class @2-17DFC2B2
Public Class STUDENT_SMS_LOGItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public mobileno_sendto As TextField
    Public sms_text As TextField
    Public datetime_created As DateField
    Public sent_by As TextField
    Public Sub New()
    mobileno_sendto = New TextField("", Nothing)
    sms_text = New TextField("", Nothing)
    datetime_created = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    sent_by = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "mobileno_sendto"
                    Return Me.mobileno_sendto
                Case "sms_text"
                    Return Me.sms_text
                Case "datetime_created"
                    Return Me.datetime_created
                Case "sent_by"
                    Return Me.sent_by
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "mobileno_sendto"
                    Me.mobileno_sendto = CType(Value,TextField)
                Case "sms_text"
                    Me.sms_text = CType(Value,TextField)
                Case "datetime_created"
                    Me.datetime_created = CType(Value,DateField)
                Case "sent_by"
                    Me.sent_by = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid STUDENT_SMS_LOG Item Class

'Grid STUDENT_SMS_LOG Data Provider Class Header @2-0C1F6831
Public Class STUDENT_SMS_LOGDataProvider
Inherits GridDataProviderBase
'End Grid STUDENT_SMS_LOG Data Provider Class Header

'Grid STUDENT_SMS_LOG Data Provider Class Variables @2-94BF84DC

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_mobileno_sendto
        Sorter_sms_text
        Sorter_datetime_created
        Sorter_sent_by
    End Enum

    Private SortFieldsNames As String() = New String() {"id desc","mobileno_sendto","sms_text","datetime_created","sent_by"}
    Private SortFieldsNamesDesc As String() = New string() {"id desc","mobileno_sendto DESC","sms_text DESC","datetime_created DESC","sent_by DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
'End Grid STUDENT_SMS_LOG Data Provider Class Variables

'Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method @2-4643FA48

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} sent_by, datetime_created, sms_text, " & vbCrLf & _
          "mobileno_sendto, id " & vbCrLf & _
          "FROM STUDENT_SMS_LOG {SQL_Where} {SQL_OrderBy}", New String(){"expr4","And","expr7"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_SMS_LOG", New String(){"expr4","And","expr7"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method

'Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method @2-98840721
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_SMS_LOGItem()
'End Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method

'Before build Select @2-001B5612
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        Select_.Parameters.Add("expr4","(student_id = 0)")
        Select_.Parameters.Add("expr7","(datetime_created > DATEADD(M, -3, getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-29239485
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As STUDENT_SMS_LOGItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @2-59B9D24E
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New STUDENT_SMS_LOGItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-37737BF1
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_SMS_LOGItem = New STUDENT_SMS_LOGItem()
                item.mobileno_sendto.SetValue(dr(i)("mobileno_sendto"),"")
                item.sms_text.SetValue(dr(i)("sms_text"),"")
                item.datetime_created.SetValue(dr(i)("datetime_created"),Select_.DateFormat)
                item.sent_by.SetValue(dr(i)("sent_by"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'DEL      ' -------------------------
'DEL      'If the mobile number and SMS test is blank, then change flag so the Insert won't occur
'DEL  	'  Normal validation won't work as the hidden fields are defaulting first.
'DEL   		If (item.mobileno_sendto.IsEmpty and item.sms_text.IsEmpty) Then
'DEL  	        allEmptyFlag = true
'DEL          End If
'DEL      ' -------------------------

'DEL      ' -------------------------
'DEL  			    If ((item.errors.count = 0) and (Not allEmptyFlag)) Then
'DEL  				'2-3-2011|EA| let's send an SMS
'DEL  				'SendSms("http://www.smsglobal.com/http-api.php", SMSGlobalData("decv", "deCv2009", "61419524056", "61412039611", "HELLO WORLD...DECV"))
'DEL  				' 14-Nov-2011|EA| minor changes for sending multiple SMS (mainly in above IF determining when to run
'DEL  					dim url as string = "http://www.smsglobal.com/http-api.php"
'DEL  
'DEL  					dim destination as string = item.mobileno_sendto.Value
'DEL  					dim smstext as string = item.sms_text.Value
'DEL  
'DEL  					' double check for mobile number (10 digits+) and some message (5 chars+)
'DEL  					if (destination.Length > 9 AND smstext.Length > 4) then
'DEL  	
'DEL  						' put all the bits into a nice string
'DEL  				  		Dim postData As New System.Text.StringBuilder("action=sendsms")
'DEL  				        postData.Append("&user=") : postData.Append(System.Web.HttpUtility.UrlEncode("decv"))		' HARDCODE USER + PASSWORD
'DEL  				        postData.Append("&password=") : postData.Append(System.Web.HttpUtility.UrlEncode("deCv2009"))
'DEL  				        postData.Append("&from=") : postData.Append(System.Web.HttpUtility.UrlEncode("DECV"))	' DECV - is actually covered in SMS
'DEL  				        postData.Append("&to=") : postData.Append(System.Web.HttpUtility.UrlEncode(destination))
'DEL  				        postData.Append("&text=") : postData.Append(System.Web.HttpUtility.UrlEncode(smstext))
'DEL     
'DEL  				   		' prepare for sending
'DEL  				        Dim encoding As New System.Text.UTF8Encoding
'DEL  				        Dim data As Byte() = encoding.GetBytes(postData.ToString())
'DEL  
'DEL  						' Mar-2011, from Vikas B. set up proxy
'DEL  						Dim lclProxy As System.Net.WebProxy = New System.Net.WebProxy("http://proxy:8080", True)
'DEL  				      	Dim smsRequest As System.Net.HttpWebRequest = System.Net.WebRequest.Create(url)
'DEL  				      	smsRequest.Proxy = lclProxy	' use proxy in request.
'DEL  
'DEL  				        smsRequest.Method = "POST"
'DEL  				        smsRequest.ContentType = "application/x-www-form-urlencoded"
'DEL  				        smsRequest.ContentLength = data.Length
'DEL  
'DEL  				        Dim smsDataStream As System.IO.Stream
'DEL  				        smsDataStream = smsRequest.GetRequestStream()
'DEL  				        smsDataStream.Write(data, 0, data.Length)
'DEL  				        smsDataStream.Close()
'DEL  
'DEL  					End If
'DEL  				End If
'DEL      ' -------------------------

'Record NewSMSRecord Item Class @33-BC616781
Public Class NewSMSRecordItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public mobileno_sendto As TextField
    Public sms_text As TextField
    Public sms_status As TextField
    Public sent_by As TextField
    Public student_id As FloatField
    Public ajaxBusy As TextField
    Public lblMobileError As TextField
    Public Sub New()
    mobileno_sendto = New TextField("", Nothing)
    sms_text = New TextField("", Nothing)
    sms_status = New TextField("", "SENT")
    sent_by = New TextField("", DBUtility.UserLogin.ToUpper)
    student_id = New FloatField("", 0)
    ajaxBusy = New TextField("", Nothing)
    lblMobileError = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As NewSMSRecordItem
        Dim item As NewSMSRecordItem = New NewSMSRecordItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("mobileno_sendto")) Then
        item.mobileno_sendto.SetValue(DBUtility.GetInitialValue("mobileno_sendto"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("sms_text")) Then
        item.sms_text.SetValue(DBUtility.GetInitialValue("sms_text"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("sms_status")) Then
        item.sms_status.SetValue(DBUtility.GetInitialValue("sms_status"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("sent_by")) Then
        item.sent_by.SetValue(DBUtility.GetInitialValue("sent_by"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("student_id")) Then
        item.student_id.SetValue(DBUtility.GetInitialValue("student_id"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblMobileError")) Then
        item.lblMobileError.SetValue(DBUtility.GetInitialValue("lblMobileError"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "mobileno_sendto"
                    Return mobileno_sendto
                Case "sms_text"
                    Return sms_text
                Case "sms_status"
                    Return sms_status
                Case "sent_by"
                    Return sent_by
                Case "student_id"
                    Return student_id
                Case "ajaxBusy"
                    Return ajaxBusy
                Case "lblMobileError"
                    Return lblMobileError
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "mobileno_sendto"
                    mobileno_sendto = CType(value, TextField)
                Case "sms_text"
                    sms_text = CType(value, TextField)
                Case "sms_status"
                    sms_status = CType(value, TextField)
                Case "sent_by"
                    sent_by = CType(value, TextField)
                Case "student_id"
                    student_id = CType(value, FloatField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case "lblMobileError"
                    lblMobileError = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

    Public Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public Property IsDeleted() As Boolean
        Get
            Return _isDeleted
        End Get
        Set
            _isDeleted = Value
        End Set
    End Property

    Public Sub Validate(ByVal provider As NewSMSRecordDataProvider)
'End Record NewSMSRecord Item Class

'mobileno_sendto validate @37-303D14A3
        If IsNothing(mobileno_sendto.Value) OrElse mobileno_sendto.Value.ToString() ="" Then
            errors.Add("mobileno_sendto",String.Format(Resources.strings.CCS_RequiredField,"SEND TO NUMBER"))
        End If
'End mobileno_sendto validate

'sms_text validate @38-9880E307
        If IsNothing(sms_text.Value) OrElse sms_text.Value.ToString() ="" Then
            errors.Add("sms_text",String.Format(Resources.strings.CCS_RequiredField,"SMS MESSAGE TO SEND"))
        End If
'End sms_text validate

'Record NewSMSRecord Event OnValidate. Action Regular Expression Validation @86-57172D5A
        If Not (mobileno_sendto.Value Is Nothing) Then
            Dim mask As Regex = New Regex("(^04\d{2,3}[\s\-]{0,1}\d{3}[\s\-]{0,1}\d{3}$)",RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            If Not(mask.Match(mobileno_sendto.Value.ToString()).Success)
                errors.Add("mobileno_sendto",String.Format("MOBILE Phone Number must be an Australian number, with numbers, spaces, or hyphens only. e" & _
  "g: 0412 345 678 or 0412-345-678.","NewSMSRecord"))
            End If
        End If
'End Record NewSMSRecord Event OnValidate. Action Regular Expression Validation

'Record NewSMSRecord Event OnValidate. Action Validate Maximum Length @44-55C06968
        If Not (sms_text.Value Is Nothing) AndAlso sms_text.Value.ToString().Length > 140 Then
            errors.Add("sms_text",String.Format("The SMS Message cannot exceed 140 characters in length.","NewSMSRecord","140"))
        End If
'End Record NewSMSRecord Event OnValidate. Action Validate Maximum Length

'Record NewSMSRecord Event OnValidate. Action Validate Required Value @89-153B048B
        If (sms_text.Value Is Nothing) OrElse sms_text.Value.ToString()="" Then
            errors.Add("sms_text",String.Format("The SMS Message is required.","NewSMSRecord"))
        End If
'End Record NewSMSRecord Event OnValidate. Action Validate Required Value

'Record NewSMSRecord Item Class tail @33-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record NewSMSRecord Item Class tail

'Record NewSMSRecord Data Provider Class @33-619D5E9F
Public Class NewSMSRecordDataProvider
Inherits RecordDataProviderBase
'End Record NewSMSRecord Data Provider Class

'Record NewSMSRecord Data Provider Class Variables @33-E6AF16DA
    Public Urlid As IntegerParameter
    Protected item As NewSMSRecordItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record NewSMSRecord Data Provider Class Variables

'Record NewSMSRecord Data Provider Class Constructor @33-3902BFD2

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM STUDENT_SMS_LOG {SQL_Where} {SQL_OrderBy}", New String(){"id36"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record NewSMSRecord Data Provider Class Constructor

'Record NewSMSRecord Data Provider Class LoadParams Method @33-296B5411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(Urlid))
    End Function
'End Record NewSMSRecord Data Provider Class LoadParams Method

'Record NewSMSRecord Data Provider Class CheckUnique Method @33-A6118E87

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As NewSMSRecordItem) As Boolean
        Return True
    End Function
'End Record NewSMSRecord Data Provider Class CheckUnique Method

'Record NewSMSRecord Data Provider Class PrepareInsert Method @33-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record NewSMSRecord Data Provider Class PrepareInsert Method

'Record NewSMSRecord Data Provider Class PrepareInsert Method tail @33-E31F8E2A
    End Sub
'End Record NewSMSRecord Data Provider Class PrepareInsert Method tail

'Record NewSMSRecord Data Provider Class Insert Method @33-D9B2F961

    Public Function InsertItem(ByVal item As NewSMSRecordItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO STUDENT_SMS_LOG({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record NewSMSRecord Data Provider Class Insert Method

'Record NewSMSRecord Build insert @33-396A355C
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.mobileno_sendto.IsEmpty Then
        allEmptyFlag = item.mobileno_sendto.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "mobileno_sendto,"
        valuesList = valuesList & Insert.Dao.ToSql(item.mobileno_sendto.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.sms_text.IsEmpty Then
        allEmptyFlag = item.sms_text.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "sms_text,"
        valuesList = valuesList & Insert.Dao.ToSql(item.sms_text.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.sms_status.IsEmpty Then
        allEmptyFlag = item.sms_status.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "sms_status,"
        valuesList = valuesList & Insert.Dao.ToSql(item.sms_status.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.sent_by.IsEmpty Then
        allEmptyFlag = item.sent_by.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "sent_by,"
        valuesList = valuesList & Insert.Dao.ToSql(item.sent_by.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.student_id.IsEmpty Then
        allEmptyFlag = item.student_id.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "student_id,"
        valuesList = valuesList & Insert.Dao.ToSql(item.student_id.GetFormattedValue(""),FieldType._Float) & ","
        End If
		Insert.SqlQuery.Replace("{Fields}", fieldsList.TrimEnd(","C))
		Insert.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record NewSMSRecord Build insert

'Record NewSMSRecord AfterExecuteInsert @33-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record NewSMSRecord AfterExecuteInsert

'Record NewSMSRecord Data Provider Class GetResultSet Method @33-FB355219

    Public Sub FillItem(ByVal item As NewSMSRecordItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record NewSMSRecord Data Provider Class GetResultSet Method

'Record NewSMSRecord BeforeBuildSelect @33-8E2EEBDD
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("id36",Urlid, "","id",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record NewSMSRecord BeforeBuildSelect

'Record NewSMSRecord BeforeExecuteSelect @33-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record NewSMSRecord BeforeExecuteSelect

'Record NewSMSRecord AfterExecuteSelect @33-A840BB73
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.mobileno_sendto.SetValue(dr(i)("mobileno_sendto"),"")
            item.sms_text.SetValue(dr(i)("sms_text"),"")
            item.sms_status.SetValue(dr(i)("sms_status"),"")
            item.sent_by.SetValue(dr(i)("sent_by"),"")
            item.student_id.SetValue(dr(i)("student_id"),"")
        Else
            IsInsertMode = True
        End If
'End Record NewSMSRecord AfterExecuteSelect

'Record NewSMSRecord AfterExecuteSelect tail @33-E31F8E2A
    End Sub
'End Record NewSMSRecord AfterExecuteSelect tail

'Record NewSMSRecord Data Provider Class @33-A61BA892
End Class

'End Record NewSMSRecord Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

