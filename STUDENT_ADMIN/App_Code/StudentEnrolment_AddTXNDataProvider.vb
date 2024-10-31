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

Namespace DECV_PROD2007.StudentEnrolment_AddTXN 'Namespace @1-E8C67B90

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

'Grid Grid_Transactions Item Class @3-5F80302E
Public Class Grid_TransactionsItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public link_TRANS_DATE As DateField
    Public TXN_ID As FloatField
    Public TRANS_CODE As TextField
    Public AMOUNT As FloatField
    Public CR_DR_FLAG As TextField
    Public COMMENTS As TextField
    Public RECEIPT As TextField
    Public lblAcctBalance As FloatField
    Public lblCRDRFlag As TextField
    Public Sub New()
    link_TRANS_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    TXN_ID = New FloatField("", Nothing)
    TRANS_CODE = New TextField("", Nothing)
    AMOUNT = New FloatField("$0.00", Nothing)
    CR_DR_FLAG = New TextField("", Nothing)
    COMMENTS = New TextField("", Nothing)
    RECEIPT = New TextField("", Nothing)
    lblAcctBalance = New FloatField("$0.00", 0.00)
    lblCRDRFlag = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "link_TRANS_DATE"
                    Return Me.link_TRANS_DATE
                Case "TXN_ID"
                    Return Me.TXN_ID
                Case "TRANS_CODE"
                    Return Me.TRANS_CODE
                Case "AMOUNT"
                    Return Me.AMOUNT
                Case "CR_DR_FLAG"
                    Return Me.CR_DR_FLAG
                Case "COMMENTS"
                    Return Me.COMMENTS
                Case "RECEIPT"
                    Return Me.RECEIPT
                Case "lblAcctBalance"
                    Return Me.lblAcctBalance
                Case "lblCRDRFlag"
                    Return Me.lblCRDRFlag
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "link_TRANS_DATE"
                    Me.link_TRANS_DATE = CType(Value,DateField)
                Case "TXN_ID"
                    Me.TXN_ID = CType(Value,FloatField)
                Case "TRANS_CODE"
                    Me.TRANS_CODE = CType(Value,TextField)
                Case "AMOUNT"
                    Me.AMOUNT = CType(Value,FloatField)
                Case "CR_DR_FLAG"
                    Me.CR_DR_FLAG = CType(Value,TextField)
                Case "COMMENTS"
                    Me.COMMENTS = CType(Value,TextField)
                Case "RECEIPT"
                    Me.RECEIPT = CType(Value,TextField)
                Case "lblAcctBalance"
                    Me.lblAcctBalance = CType(Value,FloatField)
                Case "lblCRDRFlag"
                    Me.lblCRDRFlag = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid Grid_Transactions Item Class

'Grid Grid_Transactions Data Provider Class Header @3-A8F8D342
Public Class Grid_TransactionsDataProvider
Inherits GridDataProviderBase
'End Grid Grid_Transactions Data Provider Class Header

'Grid Grid_Transactions Data Provider Class Variables @3-AA3C60CB

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {"TXN_ID"}
    Private SortFieldsNamesDesc As String() = New string() {"TXN_ID"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public SestmpSTUDENT_ID  As TextParameter
    Public SestmpENROLMENT_YEAR  As TextParameter
'End Grid Grid_Transactions Data Provider Class Variables

'Grid Grid_Transactions Data Provider Class GetResultSet Method @3-3555EE7A

    Public Sub New()
        Select_=new SqlCommand("select TOP {SqlParam_endRecord} a.TXN_ID, a.TXN_DATE as TRANS_DATE, convert(varchar(20),b." & _
          "TXN_TYPE) as TRANS_CODE, convert(numeric(6,2),a.AMOUNT) as AMOUNT, a.CR_DR_FLAG, a.COMMENT" & _
          "S, " & vbCrLf & _
          "convert(varchar(10),a.RECEIPT_NO) as RECEIPT" & vbCrLf & _
          " from TEMP_TXN a, TXN_CODE b where STUDENT_ID= {STUDENT_ID} and ENROLMENT_YEAR= {ENROLMENT" & _
          "_YEAR} and a.CAMPUS_CODE='D' and a.TXN_CODE=b.TXN_CODE {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
        Count=new SqlCommand("SELECT COUNT(*) FROM (select a.TXN_ID, a.TXN_DATE as TRANS_DATE, convert(varchar(20),b.TXN" & _
          "_TYPE) as TRANS_CODE, convert(numeric(6,2),a.AMOUNT) as AMOUNT, a.CR_DR_FLAG, a.COMMENTS, " & vbCrLf & _
          "convert(varchar(10),a.RECEIPT_NO) as RECEIPT" & vbCrLf & _
          " from TEMP_TXN a, TXN_CODE b where STUDENT_ID= {STUDENT_ID} and ENROLMENT_YEAR= {ENROLMENT" & _
          "_YEAR} and a.CAMPUS_CODE='D' and a.TXN_CODE=b.TXN_CODE) cnt",Settings.connDECVPRODSQL2005DataAccessObject)
    End Sub
'End Grid Grid_Transactions Data Provider Class GetResultSet Method

'Grid Grid_Transactions Data Provider Class GetResultSet Method @3-B66CEE3E
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As Grid_TransactionsItem()
'End Grid Grid_Transactions Data Provider Class GetResultSet Method

'Before build Select @3-CE67AE20
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("STUDENT_ID",SestmpSTUDENT_ID, "")
        CType(Select_,SqlCommand).AddParameter("ENROLMENT_YEAR",SestmpENROLMENT_YEAR, "")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-D419C0A6
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As Grid_TransactionsItem
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

'After execute Select @3-B24D9D2A
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New Grid_TransactionsItem(dr.Count-1) {}
'End After execute Select

'After execute Select @3-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @3-F432BFAD
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as Grid_TransactionsItem = New Grid_TransactionsItem()
                item.link_TRANS_DATE.SetValue(dr(i)("TRANS_DATE"),Select_.DateFormat)
                item.TXN_ID.SetValue(dr(i)("TXN_ID"),"")
                item.TRANS_CODE.SetValue(dr(i)("TRANS_CODE"),"")
                item.AMOUNT.SetValue(dr(i)("AMOUNT"),"")
                item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
                item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
                item.RECEIPT.SetValue(dr(i)("RECEIPT"),"")
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record txn Item Class @19-162B1B02
Public Class txnItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public LAST_ALTERED_BY As TextField
    Public CAMPUS_CODE As TextField
    Public LAST_ALTERED_DATE As DateField
    Public TXN_DATE As DateField
    Public TXN_CODE As TextField
    Public TXN_CODEItems As ItemCollection
    Public AMOUNT As SingleField
    Public CR_DR_FLAG As TextField
    Public CR_DR_FLAGItems As ItemCollection
    Public COMMENTS As TextField
    Public RECEIPT_NO As TextField
    Public Sub New()
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    LAST_ALTERED_BY = New TextField("", DBUtility.UserID)
    CAMPUS_CODE = New TextField("", "D")
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, DateTime.Now)
    TXN_DATE = New DateField("dd\/MM\/yyyy", DateTime.Now)
    TXN_CODE = New TextField("", "P")
    TXN_CODEItems = New ItemCollection()
    AMOUNT = New SingleField("0.#;;;;,;", Nothing)
    CR_DR_FLAG = New TextField("", "C")
    CR_DR_FLAGItems = New ItemCollection()
    COMMENTS = New TextField("", Nothing)
    RECEIPT_NO = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As txnItem
        Dim item As txnItem = New txnItem()
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CAMPUS_CODE")) Then
        item.CAMPUS_CODE.SetValue(DBUtility.GetInitialValue("CAMPUS_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXN_DATE")) Then
        item.TXN_DATE.SetValue(DBUtility.GetInitialValue("TXN_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TXN_CODE")) Then
        item.TXN_CODE.SetValue(DBUtility.GetInitialValue("TXN_CODE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("AMOUNT")) Then
        item.AMOUNT.SetValue(DBUtility.GetInitialValue("AMOUNT"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("CR_DR_FLAG")) Then
        item.CR_DR_FLAG.SetValue(DBUtility.GetInitialValue("CR_DR_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("COMMENTS")) Then
        item.COMMENTS.SetValue(DBUtility.GetInitialValue("COMMENTS"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("RECEIPT_NO")) Then
        item.RECEIPT_NO.SetValue(DBUtility.GetInitialValue("RECEIPT_NO"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "CAMPUS_CODE"
                    Return CAMPUS_CODE
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case "TXN_DATE"
                    Return TXN_DATE
                Case "TXN_CODE"
                    Return TXN_CODE
                Case "AMOUNT"
                    Return AMOUNT
                Case "CR_DR_FLAG"
                    Return CR_DR_FLAG
                Case "COMMENTS"
                    Return COMMENTS
                Case "RECEIPT_NO"
                    Return RECEIPT_NO
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "CAMPUS_CODE"
                    CAMPUS_CODE = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
                Case "TXN_DATE"
                    TXN_DATE = CType(value, DateField)
                Case "TXN_CODE"
                    TXN_CODE = CType(value, TextField)
                Case "AMOUNT"
                    AMOUNT = CType(value, SingleField)
                Case "CR_DR_FLAG"
                    CR_DR_FLAG = CType(value, TextField)
                Case "COMMENTS"
                    COMMENTS = CType(value, TextField)
                Case "RECEIPT_NO"
                    RECEIPT_NO = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As txnDataProvider)
'End Record txn Item Class

'STUDENT_ID validate @20-6D9CF271
        If IsNothing(STUDENT_ID.Value) OrElse STUDENT_ID.Value.ToString() ="" Then
            errors.Add("STUDENT_ID",String.Format(Resources.strings.CCS_RequiredField,"STUDENT ID"))
        End If
'End STUDENT_ID validate

'ENROLMENT_YEAR validate @21-2458998A
        If IsNothing(ENROLMENT_YEAR.Value) OrElse ENROLMENT_YEAR.Value.ToString() ="" Then
            errors.Add("ENROLMENT_YEAR",String.Format(Resources.strings.CCS_RequiredField,"ENROLMENT YEAR"))
        End If
'End ENROLMENT_YEAR validate

'LAST_ALTERED_BY validate @22-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'TXN_DATE validate @25-C89BF883
        If IsNothing(TXN_DATE.Value) OrElse TXN_DATE.Value.ToString() ="" Then
            errors.Add("TXN_DATE",String.Format(Resources.strings.CCS_RequiredField,"Transaction Date"))
        End If
'End TXN_DATE validate

'TXN_CODE validate @26-E156091D
        If IsNothing(TXN_CODE.Value) OrElse TXN_CODE.Value.ToString() ="" Then
            errors.Add("TXN_CODE",String.Format(Resources.strings.CCS_RequiredField,"Transaction Code"))
        End If
'End TXN_CODE validate

'AMOUNT validate @30-7B097E1D
        If IsNothing(AMOUNT.Value) OrElse AMOUNT.Value.ToString() ="" Then
            errors.Add("AMOUNT",String.Format(Resources.strings.CCS_RequiredField,"Amount"))
        End If
'End AMOUNT validate

'CR_DR_FLAG validate @31-18B78CA2
        If IsNothing(CR_DR_FLAG.Value) OrElse CR_DR_FLAG.Value.ToString() ="" Then
            errors.Add("CR_DR_FLAG",String.Format(Resources.strings.CCS_RequiredField,"DR/CR drop-down"))
        End If
'End CR_DR_FLAG validate

'Record txn Event OnValidate. Action Validate Maximum Length @38-57036DA2
        If Not (COMMENTS.Value Is Nothing) AndAlso COMMENTS.Value.ToString().Length > 60 Then
            errors.Add("COMMENTS",String.Format("Field [Comment] Must not exceed 60 characters","txn","60"))
        End If
'End Record txn Event OnValidate. Action Validate Maximum Length

'Record txn Event OnValidate. Action Validate Maximum Value @39-67C82E5F
        If Not (AMOUNT.Value Is Nothing) Then
            If Convert.ToDouble(AMOUNT.Value) > 10000 Then
            errors.Add("AMOUNT",String.Format("Field [Amount] Must be less than 10,000","txn","10000"))
            End If
        End If
'End Record txn Event OnValidate. Action Validate Maximum Value

'Record txn Item Class tail @19-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record txn Item Class tail

'Record txn Data Provider Class @19-81ADC002
Public Class txnDataProvider
Inherits RecordDataProviderBase
'End Record txn Data Provider Class

'Record txn Data Provider Class Variables @19-FB6C466A
    Protected TXN_CODEDataCommand As DataCommand=new TableCommand("SELECT TXN_CODE, TXN_TYPE " & vbCrLf & _
          "FROM TXN_CODE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlTXN_ID As FloatParameter
    Protected item As txnItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record txn Data Provider Class Variables

'Record txn Data Provider Class Constructor @19-96A2A14B

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM TEMP_TXN {SQL_Where} {SQL_OrderBy}", New String(){"TXN_ID40"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record txn Data Provider Class Constructor

'Record txn Data Provider Class LoadParams Method @19-DD3A9412

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlTXN_ID))
    End Function
'End Record txn Data Provider Class LoadParams Method

'Record txn Data Provider Class CheckUnique Method @19-DCA7F5B4

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As txnItem) As Boolean
        Return True
    End Function
'End Record txn Data Provider Class CheckUnique Method

'Record txn Data Provider Class PrepareInsert Method @19-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record txn Data Provider Class PrepareInsert Method

'Record txn Data Provider Class PrepareInsert Method tail @19-E31F8E2A
    End Sub
'End Record txn Data Provider Class PrepareInsert Method tail

'Record txn Data Provider Class Insert Method @19-1B93CD4F

    Public Function InsertItem(ByVal item As txnItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO TEMP_TXN({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record txn Data Provider Class Insert Method

'Record txn Build insert @19-A63D5D10
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.STUDENT_ID.IsEmpty Then
        allEmptyFlag = item.STUDENT_ID.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "STUDENT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STUDENT_ID.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.ENROLMENT_YEAR.IsEmpty Then
        allEmptyFlag = item.ENROLMENT_YEAR.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "ENROLMENT_YEAR,"
        valuesList = valuesList & Insert.Dao.ToSql(item.ENROLMENT_YEAR.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.CAMPUS_CODE.IsEmpty Then
        allEmptyFlag = item.CAMPUS_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CAMPUS_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CAMPUS_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.TXN_DATE.IsEmpty Then
        allEmptyFlag = item.TXN_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TXN_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TXN_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        If Not item.TXN_CODE.IsEmpty Then
        allEmptyFlag = item.TXN_CODE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TXN_CODE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TXN_CODE.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.AMOUNT.IsEmpty Then
        allEmptyFlag = item.AMOUNT.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "AMOUNT,"
        valuesList = valuesList & Insert.Dao.ToSql(item.AMOUNT.GetFormattedValue(""),FieldType._Single) & ","
        End If
        If Not item.CR_DR_FLAG.IsEmpty Then
        allEmptyFlag = item.CR_DR_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "CR_DR_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.CR_DR_FLAG.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.COMMENTS.IsEmpty Then
        allEmptyFlag = item.COMMENTS.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "COMMENTS,"
        valuesList = valuesList & Insert.Dao.ToSql(item.COMMENTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.RECEIPT_NO.IsEmpty Then
        allEmptyFlag = item.RECEIPT_NO.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "RECEIPT_NO,"
        valuesList = valuesList & Insert.Dao.ToSql(item.RECEIPT_NO.GetFormattedValue(""),FieldType._Text) & ","
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
'End Record txn Build insert

'Record txn AfterExecuteInsert @19-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record txn AfterExecuteInsert

'Record txn Data Provider Class GetResultSet Method @19-B64A42CB

    Public Sub FillItem(ByVal item As txnItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record txn Data Provider Class GetResultSet Method

'Record txn BeforeBuildSelect @19-23CB9849
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("TXN_ID40",UrlTXN_ID, "","TXN_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record txn BeforeBuildSelect

'Record txn BeforeExecuteSelect @19-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record txn BeforeExecuteSelect

'Record txn AfterExecuteSelect @19-FBF86AC8
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.CAMPUS_CODE.SetValue(dr(i)("CAMPUS_CODE"),"")
            item.TXN_DATE.SetValue(dr(i)("TXN_DATE"),Select_.DateFormat)
            item.TXN_CODE.SetValue(dr(i)("TXN_CODE"),"")
            item.AMOUNT.SetValue(dr(i)("AMOUNT"),"")
            item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
            item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
            item.RECEIPT_NO.SetValue(dr(i)("RECEIPT_NO"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record txn AfterExecuteSelect

'ListBox TXN_CODE Initialize Data Source @26-507961B2
        TXN_CODEDataCommand.Dao._optimized = False
        Dim TXN_CODEtableIndex As Integer = 0
        TXN_CODEDataCommand.OrderBy = "TXN_TYPE"
        TXN_CODEDataCommand.Parameters.Clear()
'End ListBox TXN_CODE Initialize Data Source

'ListBox TXN_CODE BeforeExecuteSelect @26-7E9BA4DE
        Try
            ListBoxSource=TXN_CODEDataCommand.Execute().Tables(TXN_CODEtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox TXN_CODE BeforeExecuteSelect

'ListBox TXN_CODE AfterExecuteSelect @26-FFE61AE3
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("TXN_CODE"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("TXN_TYPE")
            item.TXN_CODEItems.Add(Key, Val)
        Next
'End ListBox TXN_CODE AfterExecuteSelect

'ListBox CR_DR_FLAG AfterExecuteSelect @31-40EDC06F
        
item.CR_DR_FLAGItems.Add("C","CR")
item.CR_DR_FLAGItems.Add("D","DR")
'End ListBox CR_DR_FLAG AfterExecuteSelect

'Record txn AfterExecuteSelect tail @19-E31F8E2A
    End Sub
'End Record txn AfterExecuteSelect tail

'Record txn Data Provider Class @19-A61BA892
End Class

'End Record txn Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

