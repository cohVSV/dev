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

Namespace DECV_PROD2007.Send_SMS_maintain 'Namespace @1-417B6534

'Page Data Class @1-9DBCC9EC
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Backtosummary As TextField
    Public Link_BacktosummaryHref As Object
    Public Link_BacktosummaryHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Backtosummary = New TextField("",Nothing)
        Link_BacktosummaryHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Backtosummary.SetValue(DBUtility.GetInitialValue("Link_Backtosummary"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Backtosummary"
                    Return Link_Backtosummary
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Backtosummary"
                    Link_Backtosummary = CType(value, TextField)
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

'Grid STUDENT_SMS_LOG Item Class @2-C96E9D01
Public Class STUDENT_SMS_LOGItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public mobileno_sendto As TextField
    Public sms_text As TextField
    Public datetime_created As DateField
    Public sent_by As TextField
    Public Link1 As TextField
    Public Link1Href As Object
    Public Link1HrefParameters As LinkParameterCollection
    Public Sub New()
    mobileno_sendto = New TextField("", Nothing)
    sms_text = New TextField("", Nothing)
    datetime_created = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    sent_by = New TextField("", Nothing)
    Link1 = New TextField("",Nothing)
    Link1HrefParameters = New LinkParameterCollection()
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
                Case "Link1"
                    Return Me.Link1
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
                Case "Link1"
                    Me.Link1 = CType(Value,TextField)
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

'Grid STUDENT_SMS_LOG Data Provider Class Variables @2-267DE92A

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
    Public Urlstudent_id  As FloatParameter
'End Grid STUDENT_SMS_LOG Data Provider Class Variables

'Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method @2-C980169B

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} sent_by, datetime_created, sms_text, " & vbCrLf & _
          "mobileno_sendto, id " & vbCrLf & _
          "FROM STUDENT_SMS_LOG {SQL_Where} {SQL_OrderBy}", New String(){"student_id4","And","expr7"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM STUDENT_SMS_LOG", New String(){"student_id4","And","expr7"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method

'Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method @2-98840721
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As STUDENT_SMS_LOGItem()
'End Grid STUDENT_SMS_LOG Data Provider Class GetResultSet Method

'Before build Select @2-0DF1AE26
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("student_id4",Urlstudent_id, "","student_id",Condition.Equal,False)
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

'After execute Select tail @2-79919964
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as STUDENT_SMS_LOGItem = New STUDENT_SMS_LOGItem()
                item.mobileno_sendto.SetValue(dr(i)("mobileno_sendto"),"")
                item.sms_text.SetValue(dr(i)("sms_text"),"")
                item.datetime_created.SetValue(dr(i)("datetime_created"),Select_.DateFormat)
                item.sent_by.SetValue(dr(i)("sent_by"),"")
                item.Link1Href = "Student_Comments_maintain.aspx"
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

'Record NewSMSRecord Item Class @33-8D38DFD6
Public Class NewSMSRecordItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public mobileno_sendto As TextField
    Public mobileno_sendtoItems As ItemCollection
    Public sms_text As TextField
    Public sms_status As TextField
    Public sent_by As TextField
    Public student_id As FloatField
    Public lblNoSMSNumbers As TextField
    Public ajaxBusy As TextField
    Public lblStudentID As TextField
    Public Sub New()
    mobileno_sendto = New TextField("", Nothing)
    mobileno_sendtoItems = New ItemCollection()
    sms_text = New TextField("", Nothing)
    sms_status = New TextField("", "SENT")
    sent_by = New TextField("", DBUtility.UserLogin.ToUpper)
    student_id = New FloatField("", Nothing)
    lblNoSMSNumbers = New TextField("", "<font color='red'>No Mobile Numbers found for this Student.</font>")
    ajaxBusy = New TextField("", Nothing)
    lblStudentID = New TextField("", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("lblNoSMSNumbers")) Then
        item.lblNoSMSNumbers.SetValue(DBUtility.GetInitialValue("lblNoSMSNumbers"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ajaxBusy")) Then
        item.ajaxBusy.SetValue(DBUtility.GetInitialValue("ajaxBusy"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblStudentID")) Then
        item.lblStudentID.SetValue(DBUtility.GetInitialValue("lblStudentID"))
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
                Case "lblNoSMSNumbers"
                    Return lblNoSMSNumbers
                Case "ajaxBusy"
                    Return ajaxBusy
                Case "lblStudentID"
                    Return lblStudentID
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
                Case "lblNoSMSNumbers"
                    lblNoSMSNumbers = CType(value, TextField)
                Case "ajaxBusy"
                    ajaxBusy = CType(value, TextField)
                Case "lblStudentID"
                    lblStudentID = CType(value, TextField)
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

'Record NewSMSRecord Event OnValidate. Action Validate Maximum Length @44-55C06968
        If Not (sms_text.Value Is Nothing) AndAlso sms_text.Value.ToString().Length > 140 Then
            errors.Add("sms_text",String.Format("The SMS Message cannot exceed 140 characters in length.","NewSMSRecord","140"))
        End If
'End Record NewSMSRecord Event OnValidate. Action Validate Maximum Length

'Record NewSMSRecord Event OnValidate. Action Validate Required Value @72-5FE1BF9D
        If (mobileno_sendto.Value Is Nothing) OrElse mobileno_sendto.Value.ToString()="" Then
            errors.Add("mobileno_sendto",String.Format("Please select a number to Send the message to.","NewSMSRecord"))
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

'Record NewSMSRecord Data Provider Class Variables @33-C0E2FE03
    Protected mobileno_sendtoDataCommand As DataCommand=new SqlCommand("--declare @studentID int = 56794;" & vbCrLf & _
          "" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            st.STUDENT_MOBILE," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            isnull(nullif(st.PREFERRED_NAME, ''), rtrim(st.FIRST_NAME))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            rtrim(st.SURNAME)," & vbCrLf & _
          "            ' (Student Mobile)'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   st.STUDENT_MOBILE as ContactMobile," & vbCrLf & _
          "   1 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          " where" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (st.STUDENT_MOBILE like '04%')" & vbCrLf & _
          "      or (st.STUDENT_MOBILE like '0011%')" & vbCrLf & _
          "      or (st.STUDENT_MOBILE like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          "union all" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            paddr.PHONE_A," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(paddr.ADDRESSEE))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(paddr.AGENT))," & vbCrLf & _
          "            ' (Addressee Phone A)'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   paddr.PHONE_A as ContactMobile," & vbCrLf & _
          "   2 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.ADDRESS as paddr" & vbCrLf & _
          "      on st.POSTAL_ADDRESS_ID = paddr.ADDRESS_ID" & vbCrLf & _
          "         and st.CURR_RESID_ADDRESS_ID = paddr.ADDRESS_ID" & vbCrLf & _
          " where" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (paddr.PHONE_A like '04%')" & vbCrLf & _
          "      or (paddr.PHONE_A like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          "union all" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            paddr.PHONE_B," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(paddr.ADDRESSEE))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(paddr.AGENT))," & vbCrLf & _
          "            ' (Addressee Phone B)'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   paddr.PHONE_B as ContactMobile," & vbCrLf & _
          "   3 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.ADDRESS as paddr" & vbCrLf & _
          "      on st.POSTAL_ADDRESS_ID = paddr.ADDRESS_ID" & vbCrLf & _
          "         and st.CURR_RESID_ADDRESS_ID = paddr.ADDRESS_ID" & vbCrLf & _
          " where" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (paddr.PHONE_B like '04%')" & vbCrLf & _
          "      or (paddr.PHONE_B like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          "union all" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            scca.MOBILE," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(scca.FIRST_NAME))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(scca.SURNAME))," & vbCrLf & _
          "            ' ('," & vbCrLf & _
          "            isnull(vrt.RelationshipType, 'Other')," & vbCrLf & _
          "            ')'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   scca.MOBILE as ContactMobile," & vbCrLf & _
          "   4 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.STUDENT_CARER_CONTACT as scca" & vbCrLf & _
          "      on st.CARER_ID_PARENT_A = scca.CARER_ID" & vbCrLf & _
          "   left join dbo.vwRelationshipType as vrt" & vbCrLf & _
          "      on (vrt.RelationshipTypeID = scca.RELATIONSHIP)" & vbCrLf & _
          " where" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (scca.MOBILE like '04%')" & vbCrLf & _
          "      or (scca.MOBILE like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          "union all" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            sccb.MOBILE," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(sccb.FIRST_NAME))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(sccb.SURNAME))," & vbCrLf & _
          "            ' ('," & vbCrLf & _
          "            isnull(vrt.RelationshipType, 'Other')," & vbCrLf & _
          "            ')'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   sccb.MOBILE as ContactMobile," & vbCrLf & _
          "   5 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.STUDENT_CARER_CONTACT as sccb" & vbCrLf & _
          "      on st.CARER_ID_PARENT_B = sccb.CARER_ID" & vbCrLf & _
          "   left join dbo.vwRelationshipType as vrt" & vbCrLf & _
          "      on (vrt.RelationshipTypeID = sccb.RELATIONSHIP)" & vbCrLf & _
          " where" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (sccb.MOBILE like '04%')" & vbCrLf & _
          "      or (sccb.MOBILE like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          "union all" & vbCrLf & _
          "select" & vbCrLf & _
          "   st.STUDENT_ID," & vbCrLf & _
          "   concat(" & vbCrLf & _
          "            sccsv.MOBILE," & vbCrLf & _
          "            ' - '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(sccsv.FIRST_NAME))," & vbCrLf & _
          "            ' '," & vbCrLf & _
          "            dbo.ProperCase(rtrim(sccsv.SURNAME))," & vbCrLf & _
          "            ' ('," & vbCrLf & _
          "            isnull(vrt.RelationshipType, 'Other')," & vbCrLf & _
          "            ')'" & vbCrLf & _
          "         ) as ContactName," & vbCrLf & _
          "   sccsv.MOBILE as ContactMobile," & vbCrLf & _
          "   6 as ContactOrder" & vbCrLf & _
          " from" & vbCrLf & _
          "   dbo.STUDENT as st" & vbCrLf & _
          "   inner join dbo.STUDENT_ENROLMENT as se" & vbCrLf & _
          "      on st.STUDENT_ID = se.STUDENT_ID" & vbCrLf & _
          "   inner join dbo.STUDENT_CARER_CONTACT as sccsv" & vbCrLf & _
          "      on se.CARER_ID_SCHOOL_SUPERVISOR = sccsv.CARER_ID" & vbCrLf & _
          "   left join dbo.vwRelationshipType as vrt" & vbCrLf & _
          "      on (vrt.RelationshipTypeID = sccsv.RELATIONSHIP)" & vbCrLf & _
          " where" & vbCrLf & _
          "   (se.ENROLMENT_YEAR = year(getdate()))" & vbCrLf & _
          "   and" & vbCrLf & _
          "   (" & vbCrLf & _
          "      (sccsv.MOBILE like '04%')" & vbCrLf & _
          "      or (sccsv.MOBILE like '+61 4%')" & vbCrLf & _
          "   )" & vbCrLf & _
          "   and (st.STUDENT_ID = {student_id})" & vbCrLf & _
          " order by" & vbCrLf & _
          "   ContactOrder;",Settings.connDECVPRODSQL2005DataAccessObject)
    Public Urlid As IntegerParameter
    Public UrlSTUDENT_ID As TextParameter
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

'Record NewSMSRecord AfterExecuteSelect @33-640F9DD4
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
            item.lblStudentID.SetValue(dr(i)("student_id"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record NewSMSRecord AfterExecuteSelect

'ListBox mobileno_sendto Initialize Data Source @37-365F962F
        mobileno_sendtoDataCommand.Dao._optimized = False
        Dim mobileno_sendtotableIndex As Integer = 0
        mobileno_sendtoDataCommand.OrderBy = ""
        mobileno_sendtoDataCommand.Parameters.Clear()
        CType(mobileno_sendtoDataCommand,SqlCommand).AddParameter("student_id",UrlSTUDENT_ID, "")
'End ListBox mobileno_sendto Initialize Data Source

'ListBox mobileno_sendto BeforeExecuteSelect @37-EE45C373
        Try
            ListBoxSource=mobileno_sendtoDataCommand.Execute().Tables(mobileno_sendtotableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox mobileno_sendto BeforeExecuteSelect

'ListBox mobileno_sendto AfterExecuteSelect @37-ECA7B93C
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("ContactMobile"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("ContactName")
            item.mobileno_sendtoItems.Add(Key, Val)
        Next
'End ListBox mobileno_sendto AfterExecuteSelect

'Record NewSMSRecord AfterExecuteSelect tail @33-E31F8E2A
    End Sub
'End Record NewSMSRecord AfterExecuteSelect tail

'Record NewSMSRecord Data Provider Class @33-A61BA892
End Class

'End Record NewSMSRecord Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

