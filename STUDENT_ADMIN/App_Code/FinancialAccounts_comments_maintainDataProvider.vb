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

Namespace DECV_PROD2007.FinancialAccounts_comments_maintain 'Namespace @1-5A29E4EE

'Page Data Class @1-E5A07DF6
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_Back As TextField
    Public Link_BackHref As Object
    Public Link_BackHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_Back = New TextField("",Nothing)
        Link_BackHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_Back.SetValue(DBUtility.GetInitialValue("Link_Back"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_Back"
                    Return Link_Back
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_Back"
                    Link_Back = CType(value, TextField)
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

'Record txn Item Class @3-92062D87
Public Class txnItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public TXN_ID As FloatField
    Public STUDENT_ID As FloatField
    Public ENROLMENT_YEAR As FloatField
    Public TRANS_DATE As DateField
    Public TRANS_CODE As TextField
    Public AMOUNT As SingleField
    Public CR_DR_FLAG As TextField
    Public COMMENTS As TextField
    Public RECEIPT_NO As TextField
    Public Sub New()
    TXN_ID = New FloatField("", Nothing)
    STUDENT_ID = New FloatField("", Nothing)
    ENROLMENT_YEAR = New FloatField("", Nothing)
    TRANS_DATE = New DateField("dd\/MM\/yyyy", Nothing)
    TRANS_CODE = New TextField("", Nothing)
    AMOUNT = New SingleField("$0.00", 0.00)
    CR_DR_FLAG = New TextField("", Nothing)
    COMMENTS = New TextField("", Nothing)
    RECEIPT_NO = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As txnItem
        Dim item As txnItem = New txnItem()
        If Not IsNothing(DBUtility.GetInitialValue("TXN_ID")) Then
        item.TXN_ID.SetValue(DBUtility.GetInitialValue("TXN_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STUDENT_ID")) Then
        item.STUDENT_ID.SetValue(DBUtility.GetInitialValue("STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ENROLMENT_YEAR")) Then
        item.ENROLMENT_YEAR.SetValue(DBUtility.GetInitialValue("ENROLMENT_YEAR"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TRANS_DATE")) Then
        item.TRANS_DATE.SetValue(DBUtility.GetInitialValue("TRANS_DATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TRANS_CODE")) Then
        item.TRANS_CODE.SetValue(DBUtility.GetInitialValue("TRANS_CODE"))
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
        If Not IsNothing(DBUtility.GetInitialValue("Button_Cancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "TXN_ID"
                    Return TXN_ID
                Case "STUDENT_ID"
                    Return STUDENT_ID
                Case "ENROLMENT_YEAR"
                    Return ENROLMENT_YEAR
                Case "TRANS_DATE"
                    Return TRANS_DATE
                Case "TRANS_CODE"
                    Return TRANS_CODE
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
                Case "TXN_ID"
                    TXN_ID = CType(value, FloatField)
                Case "STUDENT_ID"
                    STUDENT_ID = CType(value, FloatField)
                Case "ENROLMENT_YEAR"
                    ENROLMENT_YEAR = CType(value, FloatField)
                Case "TRANS_DATE"
                    TRANS_DATE = CType(value, DateField)
                Case "TRANS_CODE"
                    TRANS_CODE = CType(value, TextField)
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

'TXN_ID validate @14-9DF9499E
        If IsNothing(TXN_ID.Value) OrElse TXN_ID.Value.ToString() ="" Then
            errors.Add("TXN_ID",String.Format(Resources.strings.CCS_RequiredField,"Transaction ID"))
        End If
'End TXN_ID validate

'Record txn Event OnValidate. Action Validate Maximum Length @20-57036DA2
        If Not (COMMENTS.Value Is Nothing) AndAlso COMMENTS.Value.ToString().Length > 60 Then
            errors.Add("COMMENTS",String.Format("Field [Comment] Must not exceed 60 characters","txn","60"))
        End If
'End Record txn Event OnValidate. Action Validate Maximum Length

'Record txn Item Class tail @3-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record txn Item Class tail

'Record txn Data Provider Class @3-81ADC002
Public Class txnDataProvider
Inherits RecordDataProviderBase
'End Record txn Data Provider Class

'Record txn Data Provider Class Variables @3-5844966C
    Public UrlTXN_ID As FloatParameter
    Public CtrlTXN_ID As FloatParameter
    Public SesUserID As TextParameter
    Public Expr23 As DateParameter
    Public CtrlCOMMENTS As TextParameter
    Public CtrlRECEIPT_NO As TextParameter
    Protected item As txnItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record txn Data Provider Class Variables

'Record txn Data Provider Class Constructor @3-A6BF1937

    Public Sub New()
        Select_=new SqlCommand("select a.TXN_ID, a.STUDENT_ID, a.ENROLMENT_YEAR, a.TXN_DATE as TRANS_DATE, convert(varchar" & _
          "(20),b.TXN_TYPE) as TRANS_CODE, convert(numeric(6,2),a.AMOUNT) as AMOUNT, a.CR_DR_FLAG, a." & _
          "COMMENTS, " & vbCrLf & _
          "convert(varchar(10),a.RECEIPT_NO) as RECEIPT" & vbCrLf & _
          " from TXN a, TXN_CODE b where a.TXN_ID = {TXN_ID} and a.TXN_CODE=b.TXN_CODE ",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record txn Data Provider Class Constructor

'Record txn Data Provider Class LoadParams Method @3-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record txn Data Provider Class LoadParams Method

'Record txn Data Provider Class CheckUnique Method @3-DCA7F5B4

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As txnItem) As Boolean
        Return True
    End Function
'End Record txn Data Provider Class CheckUnique Method

'Record txn Data Provider Class PrepareUpdate Method @3-6D06FB67

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = Not(IsNothing(item.TXN_ID))
'End Record txn Data Provider Class PrepareUpdate Method

'Record txn Data Provider Class PrepareUpdate Method tail @3-E31F8E2A
    End Sub
'End Record txn Data Provider Class PrepareUpdate Method tail

'Record txn Data Provider Class Update Method @3-290E2D0C

    Public Function UpdateItem(ByVal item As txnItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE txn SET {Values}", New String(){"TXN_ID27"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record txn Data Provider Class Update Method

'Record txn BeforeBuildUpdate @3-8BFC14BE
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("TXN_ID27",item.TXN_ID, "","TXN_ID",Condition.Equal,False)
        allEmptyFlag = (SesUserID Is Nothing) And allEmptyFlag
        If Not (SesUserID Is Nothing) Then
        If IsNothing(SesUserID) Then
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_BY=" & Update.Dao.ToSql(SesUserID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr23 Is Nothing) And allEmptyFlag
        If Not (Expr23 Is Nothing) Then
        If IsNothing(Expr23) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(Expr23.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.COMMENTS.IsEmpty And allEmptyFlag
        If Not item.COMMENTS.IsEmpty Then
        If IsNothing(item.COMMENTS.Value) Then
        valuesList = valuesList & "COMMENTS=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "COMMENTS=" & Update.Dao.ToSql(item.COMMENTS.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.RECEIPT_NO.IsEmpty And allEmptyFlag
        If Not item.RECEIPT_NO.IsEmpty Then
        If IsNothing(item.RECEIPT_NO.Value) Then
        valuesList = valuesList & "RECEIPT_NO=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "RECEIPT_NO=" & Update.Dao.ToSql(item.RECEIPT_NO.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
             If Not allEmptyFlag Then result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record txn BeforeBuildUpdate

'Record txn AfterExecuteUpdate @3-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record txn AfterExecuteUpdate

'Record txn Data Provider Class GetResultSet Method @3-B64A42CB

    Public Sub FillItem(ByVal item As txnItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record txn Data Provider Class GetResultSet Method

'Record txn BeforeBuildSelect @3-A68D1724
        Select_.Parameters.Clear()
        CType(Select_,SqlCommand).AddParameter("TXN_ID",UrlTXN_ID, "")
        IsInsertMode = (IsNothing(UrlTXN_ID))
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record txn BeforeBuildSelect

'Record txn BeforeExecuteSelect @3-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record txn BeforeExecuteSelect

'Record txn AfterExecuteSelect @3-46541460
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.TXN_ID.SetValue(dr(i)("TXN_ID"),"")
            item.STUDENT_ID.SetValue(dr(i)("STUDENT_ID"),"")
            item.ENROLMENT_YEAR.SetValue(dr(i)("ENROLMENT_YEAR"),"")
            item.TRANS_DATE.SetValue(dr(i)("TRANS_DATE"),Select_.DateFormat)
            item.TRANS_CODE.SetValue(dr(i)("TRANS_CODE"),"")
            item.AMOUNT.SetValue(dr(i)("AMOUNT"),"")
            item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
            item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
            item.RECEIPT_NO.SetValue(dr(i)("RECEIPT"),"")
        Else
            IsInsertMode = True
        End If
'End Record txn AfterExecuteSelect

'Record txn AfterExecuteSelect tail @3-E31F8E2A
    End Sub
'End Record txn AfterExecuteSelect tail

'Record txn Data Provider Class @3-A61BA892
End Class

'End Record txn Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

