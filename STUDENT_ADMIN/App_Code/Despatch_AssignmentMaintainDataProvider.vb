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

Namespace DECV_PROD2007.Despatch_AssignmentMaintain 'Namespace @1-E954D949

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

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Item Class @3-125CE40A
Public Class ASSIGNMENT_SUBMISSION_STU1Item
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ASSIGNMENT_SUBMISSION_STU1_TotalRecords As TextField
    Public ASSIGNMENT_SUBMISSION_SUBJECT_ID As IntegerField
    Public ASSIGNMENT_SUBMISSION_STUDENT_ID As FloatField
    Public ASSIGNMENT_ID As IntegerField
    Public SUBMISSION_ID As IntegerField
    Public RECEIVED_DATE As DateField
    Public RETURNED_DATE As DateField
    Public ASSIGNMENT_SUBMISSION_STAFF_ID As TextField
    Public ASSIGNMENT_SUBMISSION_STAFF_IDItems As ItemCollection
    Public COMMENTS As TextField
    Public checkboxDelete As BooleanField
    Public checkboxDeleteCheckedValue As BooleanField
    Public checkboxDeleteUncheckedValue As BooleanField
    Public Sub New()
    ASSIGNMENT_SUBMISSION_STU1_TotalRecords = New TextField("", Nothing)
    ASSIGNMENT_SUBMISSION_SUBJECT_ID = New IntegerField("", Nothing)
    ASSIGNMENT_SUBMISSION_STUDENT_ID = New FloatField("", Nothing)
    ASSIGNMENT_ID = New IntegerField("", Nothing)
    SUBMISSION_ID = New IntegerField("", Nothing)
    RECEIVED_DATE = New DateField("dd\/MM\/yy", Nothing)
    RETURNED_DATE = New DateField("dd\/MM\/yy", Nothing)
    ASSIGNMENT_SUBMISSION_STAFF_ID = New TextField("", Nothing)
    ASSIGNMENT_SUBMISSION_STAFF_IDItems = New ItemCollection()
    COMMENTS = New TextField("", Nothing)
    checkboxDelete = New BooleanField(Settings.BoolFormat, False)
    checkboxDeleteCheckedValue = New BooleanField(Settings.BoolFormat, True)
    checkboxDeleteUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STUDENT_IDField"
                    Return Me.STUDENT_IDField
                Case "ENROLMENT_YEARField"
                    Return Me.ENROLMENT_YEARField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "ASSIGNMENT_IDField"
                    Return Me.ASSIGNMENT_IDField
                Case "SUBMISSION_IDField"
                    Return Me.SUBMISSION_IDField
                Case "ASSIGNMENT_SUBMISSION_STUDENT_IDField"
                    Return Me.ASSIGNMENT_SUBMISSION_STUDENT_IDField
                Case "ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField"
                    Return Me.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_IDField"
                    Return Me.ASSIGNMENT_SUBMISSION_SUBJECT_IDField
                Case "ASSIGNMENT_SUBMISSION_STU1_TotalRecords"
                    Return Me.ASSIGNMENT_SUBMISSION_STU1_TotalRecords
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_ID"
                    Return Me.ASSIGNMENT_SUBMISSION_SUBJECT_ID
                Case "ASSIGNMENT_SUBMISSION_STUDENT_ID"
                    Return Me.ASSIGNMENT_SUBMISSION_STUDENT_ID
                Case "ASSIGNMENT_ID"
                    Return Me.ASSIGNMENT_ID
                Case "SUBMISSION_ID"
                    Return Me.SUBMISSION_ID
                Case "RECEIVED_DATE"
                    Return Me.RECEIVED_DATE
                Case "RETURNED_DATE"
                    Return Me.RETURNED_DATE
                Case "ASSIGNMENT_SUBMISSION_STAFF_ID"
                    Return Me.ASSIGNMENT_SUBMISSION_STAFF_ID
                Case "COMMENTS"
                    Return Me.COMMENTS
                Case "checkboxDelete"
                    Return Me.checkboxDelete
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STUDENT_IDField"
                    Me.STUDENT_IDField = CType(Value,FloatField)
                Case "ENROLMENT_YEARField"
                    Me.ENROLMENT_YEARField = CType(Value,FloatField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "ASSIGNMENT_IDField"
                    Me.ASSIGNMENT_IDField = CType(Value,IntegerField)
                Case "SUBMISSION_IDField"
                    Me.SUBMISSION_IDField = CType(Value,IntegerField)
                Case "ASSIGNMENT_SUBMISSION_STUDENT_IDField"
                    Me.ASSIGNMENT_SUBMISSION_STUDENT_IDField = CType(Value,FloatField)
                Case "ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField"
                    Me.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField = CType(Value,FloatField)
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_IDField"
                    Me.ASSIGNMENT_SUBMISSION_SUBJECT_IDField = CType(Value,IntegerField)
                Case "ASSIGNMENT_SUBMISSION_STU1_TotalRecords"
                    Me.ASSIGNMENT_SUBMISSION_STU1_TotalRecords = CType(Value,TextField)
                Case "ASSIGNMENT_SUBMISSION_SUBJECT_ID"
                    Me.ASSIGNMENT_SUBMISSION_SUBJECT_ID = CType(Value,IntegerField)
                Case "ASSIGNMENT_SUBMISSION_STUDENT_ID"
                    Me.ASSIGNMENT_SUBMISSION_STUDENT_ID = CType(Value,FloatField)
                Case "ASSIGNMENT_ID"
                    Me.ASSIGNMENT_ID = CType(Value,IntegerField)
                Case "SUBMISSION_ID"
                    Me.SUBMISSION_ID = CType(Value,IntegerField)
                Case "RECEIVED_DATE"
                    Me.RECEIVED_DATE = CType(Value,DateField)
                Case "RETURNED_DATE"
                    Me.RETURNED_DATE = CType(Value,DateField)
                Case "ASSIGNMENT_SUBMISSION_STAFF_ID"
                    Me.ASSIGNMENT_SUBMISSION_STAFF_ID = CType(Value,TextField)
                Case "COMMENTS"
                    Me.COMMENTS = CType(Value,TextField)
                Case "checkboxDelete"
                    Me.checkboxDelete = CType(Value,BooleanField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public  Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
        Set
            _deleteAllowed = Value
        End Set
    End Property

    Public Property IsNew As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public ReadOnly Property IsEmptyItem As Boolean
        Get
            Dim result As Boolean = True
            result = IsNothing(RECEIVED_DATE.Value) And result
            result = IsNothing(RETURNED_DATE.Value) And result
            result = IsNothing(ASSIGNMENT_SUBMISSION_STAFF_ID.Value) And result
            result = IsNothing(COMMENTS.Value) And result
            result = IsNothing(checkboxDelete.Value) And result
            result = IsNothing(STUDENT_IDField.Value) And result
            result = IsNothing(ENROLMENT_YEARField.Value) And result
            result = IsNothing(SUBJECT_IDField.Value) And result
            result = IsNothing(ASSIGNMENT_IDField.Value) And result
            result = IsNothing(SUBMISSION_IDField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STUDENT_IDField As FloatField = New FloatField()
    Public ENROLMENT_YEARField As FloatField = New FloatField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public ASSIGNMENT_IDField As IntegerField = New IntegerField()
    Public SUBMISSION_IDField As IntegerField = New IntegerField()
    Public ASSIGNMENT_SUBMISSION_STUDENT_IDField As FloatField = New FloatField()
    Public ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField As FloatField = New FloatField()
    Public ASSIGNMENT_SUBMISSION_SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As ASSIGNMENT_SUBMISSION_STU1DataProvider) As Boolean
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Item Class

'RECEIVED_DATE validate @65-69E452D7
        If IsNothing(RECEIVED_DATE.Value) OrElse RECEIVED_DATE.Value.ToString() ="" Then
            errors.Add("RECEIVED_DATE",String.Format(Resources.strings.CCS_RequiredField,"RECEIVED DATE"))
        End If
'End RECEIVED_DATE validate

'RETURNED_DATE validate @68-A209A5C1
        If (Not IsNothing(RETURNED_DATE.Value)) And (Not RETURNED_DATE.Value <= Now()) Then
            errors.Add("RETURNED_DATE","Returned Date must be On or Before Today")
        End If
'End RETURNED_DATE validate

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Item Class tail

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Header @3-5AB63846
Public Class ASSIGNMENT_SUBMISSION_STU1DataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Header

'Grid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Variables @3-BD2056A1

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_ASSIGNMENT_SUBMISSION_SUBJECT_ID
        Sorter_ASSIGNMENT_SUBMISSION_STUDENT_ID
        Sorter_ASSIGNMENT_ID
        Sorter_SUBMISSION_ID
        Sorter_RECEIVED_DATE
        Sorter_RETURNED_DATE
        Sorter_ASSIGNMENT_SUBMISSION_STAFF_ID
        Sorter_COMMENTS
    End Enum

    Private SortFieldsNames As String() = New String() {"ASSIGNMENT_SUBMISSION.SUBJECT_ID, ASSIGNMENT_SUBMISSION.STUDENT_ID, ASSIGNMENT_ID, SUBMISS" & _
"ION_ID","ASSIGNMENT_SUBMISSION.SUBJECT_ID","ASSIGNMENT_SUBMISSION.STUDENT_ID","ASSIGNMENT_ID","SUBMISSION_ID","RECEIVED_DATE","RETURNED_DATE","ASSIGNMENT_SUBMISSION.STAFF_ID","COMMENTS"}
    Private SortFieldsNamesDesc As String() = New string() {"ASSIGNMENT_SUBMISSION.SUBJECT_ID, ASSIGNMENT_SUBMISSION.STUDENT_ID, ASSIGNMENT_ID, SUBMISS" & _
"ION_ID","ASSIGNMENT_SUBMISSION.SUBJECT_ID DESC","ASSIGNMENT_SUBMISSION.STUDENT_ID DESC","ASSIGNMENT_ID DESC","SUBMISSION_ID DESC","RECEIVED_DATE DESC","RETURNED_DATE DESC","ASSIGNMENT_SUBMISSION.STAFF_ID DESC","COMMENTS DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_STUDENT_SUBJECT_STUDENT_ID  As FloatParameter
    Public Urls_STUDENT_SUBJECT_SUBJECT_ID  As IntegerParameter
    Public Urls_STUDENT_SUBJECT_STAFF_ID  As TextParameter
    Public CtrlRECEIVED_DATE  As DateParameter
    Public CtrlRETURNED_DATE  As DateParameter
    Public CtrlASSIGNMENT_SUBMISSION_STAFF_ID  As TextParameter
    Public CtrlCOMMENTS  As TextParameter
    Protected ASSIGNMENT_SUBMISSION_STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT STAFF_ID " & vbCrLf & _
          "FROM STAFF {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
'End Grid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Variables

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Constructor @3-FDE6F176

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} ASSIGNMENT_SUBMISSION.SUBJECT_ID AS ASSIGNMENT_SUBMISSION_" & _
          "SUBJECT_ID, ASSIGNMENT_ID, SUBMISSION_ID, " & vbCrLf & _
          "RECEIVED_DATE AS received_date," & vbCrLf & _
          "RETURNED_DATE AS returned_date, COMMENTS, " & vbCrLf & _
          "STUDENT_SUBJECT.STAFF_ID AS STUDENT_SUBJECT_STAFF_ID, " & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.STAFF_ID AS MARKERID," & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.STUDENT_ID AS ASSIGNMENT_SUBMISSION_STUDENT_ID, " & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.ENROLMENT_YEAR AS ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR," & vbCrLf & _
          "RECEIVED_DATE, " & vbCrLf & _
          "RETURNED_DATE " & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION INNER JOIN STUDENT_SUBJECT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.STUDENT_ID = STUDENT_SUBJECT.STUDENT_ID AND ASSIGNMENT_SUBMISSION.EN" & _
          "ROLMENT_YEAR = STUDENT_SUBJECT.ENROLMENT_YEAR AND ASSIGNMENT_SUBMISSION.SUBJECT_ID = STUDE" & _
          "NT_SUBJECT.SUBJECT_ID {SQL_Where} {SQL_OrderBy}", New String(){"expr19","And","s_STUDENT_SUBJECT_STUDENT_ID49","And","s_STUDENT_SUBJECT_SUBJECT_ID50","And","s_STUDENT_SUBJECT_STAFF_ID51"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ASSIGNMENT_SUBMISSION INNER JOIN STUDENT_SUBJECT ON" & vbCrLf & _
          "ASSIGNMENT_SUBMISSION.STUDENT_ID = STUDENT_SUBJECT.STUDENT_ID AND ASSIGNMENT_SUBMISSION.EN" & _
          "ROLMENT_YEAR = STUDENT_SUBJECT.ENROLMENT_YEAR AND ASSIGNMENT_SUBMISSION.SUBJECT_ID = STUDE" & _
          "NT_SUBJECT.SUBJECT_ID", New String(){"expr19","And","s_STUDENT_SUBJECT_STUDENT_ID49","And","s_STUDENT_SUBJECT_SUBJECT_ID50","And","s_STUDENT_SUBJECT_STAFF_ID51"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Constructor

'Record ASSIGNMENT_SUBMISSION_STU1 Data Provider Class CheckUnique Method @3-6312086B

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As ASSIGNMENT_SUBMISSION_STU1Item) As Boolean
        Return True
    End Function
'End Record ASSIGNMENT_SUBMISSION_STU1 Data Provider Class CheckUnique Method

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Update Method @3-33E0EB4E
    Protected Function UpdateItem(ByVal item As ASSIGNMENT_SUBMISSION_STU1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.ASSIGNMENT_SUBMISSION_STUDENT_IDField) Or IsNothing(item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField) Or IsNothing(item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField) Or IsNothing(item.ASSIGNMENT_IDField) Or IsNothing(item.SUBMISSION_IDField))
        Dim Update As DataCommand=new TableCommand("UPDATE ASSIGNMENT_SUBMISSION SET RECEIVED_DATE={RECEIVED_DATE}, " & vbCrLf & _
          "RETURNED_DATE={RETURNED_DATE}, ASSIGNMENT_SUBMISSION.STAFF_ID={ASSIGNMENT_SUBMISSION.STAFF" & _
          "_ID}, " & vbCrLf & _
          "COMMENTS={COMMENTS}", New String(){"ASSIGNMENT_SUBMISSION_STUDENT_ID108","And","ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR109","And","ASSIGNMENT_SUBMISSION_SUBJECT_ID110","And","ASSIGNMENT_ID111","And","SUBMISSION_ID112","And","expr116"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Update Method

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeBuildUpdate @3-B45A2393
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_STUDENT_ID108",item.ASSIGNMENT_SUBMISSION_STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR109",item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_SUBJECT_ID110",item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("ASSIGNMENT_ID111",item.ASSIGNMENT_IDField, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBMISSION_ID112",item.SUBMISSION_IDField, "","SUBMISSION_ID",Condition.Equal,False)
        Update.Parameters.Add("expr116","(ENROLMENT_YEAR=year(getdate()))")
        If item.RECEIVED_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{RECEIVED_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{RECEIVED_DATE}",Update.Dao.ToSql(item.RECEIVED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.RETURNED_DATE.Value Is Nothing Then
            Update.SqlQuery.Replace("{RETURNED_DATE}",Update.Dao.ToSql(Nothing,FieldType._Date))
        Else
            Update.SqlQuery.Replace("{RETURNED_DATE}",Update.Dao.ToSql(item.RETURNED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date))
        End If
        If item.ASSIGNMENT_SUBMISSION_STAFF_ID.Value Is Nothing Then
            Update.SqlQuery.Replace("{ASSIGNMENT_SUBMISSION.STAFF_ID}",Update.Dao.ToSql(("        ").ToString(),FieldType._Text))
        Else
            Update.SqlQuery.Replace("{ASSIGNMENT_SUBMISSION.STAFF_ID}",Update.Dao.ToSql(item.ASSIGNMENT_SUBMISSION_STAFF_ID.GetFormattedValue(""),FieldType._Text))
        End If
        If item.COMMENTS.Value Is Nothing Then
            Update.SqlQuery.Replace("{COMMENTS}",Update.Dao.ToSql(Nothing,FieldType._Text))
        Else
            Update.SqlQuery.Replace("{COMMENTS}",Update.Dao.ToSql(item.COMMENTS.GetFormattedValue(""),FieldType._Text))
        End If
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 BeforeBuildUpdate

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Execute Update  @3-24B27D7E
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Execute Update 

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 AfterExecuteUpdate

'Record ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Delete Method @3-0139A626
    Public Function DeleteItem(ByVal item As ASSIGNMENT_SUBMISSION_STU1Item) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.ASSIGNMENT_SUBMISSION_STUDENT_IDField) Or IsNothing(item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField) Or IsNothing(item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField) Or IsNothing(item.ASSIGNMENT_IDField) Or IsNothing(item.SUBMISSION_IDField))
        Dim Delete As DataCommand=new TableCommand("DELETE FROM ASSIGNMENT_SUBMISSION", New String(){"ASSIGNMENT_SUBMISSION_STUDENT_ID96","And","ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR97","And","ASSIGNMENT_SUBMISSION_SUBJECT_ID98","And","ASSIGNMENT_ID99","And","SUBMISSION_ID100"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Delete Method

'Record ASSIGNMENT_SUBMISSION_STU1 BeforeBuildDelete @3-37579C80
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_STUDENT_ID96",item.ASSIGNMENT_SUBMISSION_STUDENT_IDField, "","STUDENT_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR97",item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField, "","ENROLMENT_YEAR",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("ASSIGNMENT_SUBMISSION_SUBJECT_ID98",item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("ASSIGNMENT_ID99",item.ASSIGNMENT_IDField, "","ASSIGNMENT_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("SUBMISSION_ID100",item.SUBMISSION_IDField, "","SUBMISSION_ID",Condition.Equal,False)
'End Record ASSIGNMENT_SUBMISSION_STU1 BeforeBuildDelete

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Execute Delete @3-124DEAF1
        Delete.OpType = OperationType.Delete
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                result = Delete.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Execute Delete

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 AfterExecuteDelete @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 AfterExecuteDelete

'Grid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class GetResultSet Method @3-F9CDD574
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As ASSIGNMENT_SUBMISSION_STU1Item = CType(Items(i), ASSIGNMENT_SUBMISSION_STU1Item)
'End Grid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class GetResultSet Method

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Update @3-16326EAB
            If Not item.IsUpdated Then
                If item.IsDeleted And ops.AllowDelete Then
                    DeleteItem(item)
                    op = EditableGridOperation.Delete
                    isProcessed = True
                End If
                If Not(item.IsEmptyItem) And ops.AllowUpdate And Not(isProcessed) Then
                    UpdateItem(item)
                    op = EditableGridOperation.Update
                End If
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class Update

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class AfterUpdate

'EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class GetResultSet Method @3-1A09A93C
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As ASSIGNMENT_SUBMISSION_STU1Item()
'End EditableGrid ASSIGNMENT_SUBMISSION_STU1 Data Provider Class GetResultSet Method

'Before build Select @3-3AB34868
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_STUDENT_SUBJECT_STUDENT_ID49",Urls_STUDENT_SUBJECT_STUDENT_ID, "","STUDENT_SUBJECT.STUDENT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_SUBJECT_SUBJECT_ID50",Urls_STUDENT_SUBJECT_SUBJECT_ID, "","STUDENT_SUBJECT.SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("s_STUDENT_SUBJECT_STAFF_ID51",Urls_STUDENT_SUBJECT_STAFF_ID, "","STUDENT_SUBJECT.STAFF_ID",Condition.Contains,False)
        Select_.Parameters.Add("expr19","(STUDENT_SUBJECT.ENROLMENT_YEAR=year(getdate()))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy = SortFieldsNames(CInt(SortField)).Trim
        Else
            Select_.OrderBy = SortFieldsNamesDesc(CInt(SortField)).Trim
        End If
    Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @3-939614DD
        Dim dr As DataRowCollection = Nothing
        Dim rowCount as Integer = 0
        Dim ds As DataSet = Nothing
        If ops.AllowRead Then
            _pagesCount=0
            Try
                If RecordsPerPage>0
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _pagesCount = ExecuteCount()
                    m_recordCount = _pagesCount
                    If _pagesCount Mod RecordsPerPage>0 Then
                        _pagesCount = (_pagesCount\RecordsPerPage)+1
                    Else
                        _pagesCount = _pagesCount\RecordsPerPage
                    End If
                Else
                ds=ExecuteSelect()
                If ds.Tables(tableIndex).Rows.Count<>0 Then 
                    _pagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @3-64E23612
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As ASSIGNMENT_SUBMISSION_STU1Item
'End After execute Select

'ListBox ASSIGNMENT_SUBMISSION_STAFF_ID Initialize Data Source @70-3EE3D57F
    ASSIGNMENT_SUBMISSION_STAFF_IDDataCommand.Dao._optimized = False
    Dim ASSIGNMENT_SUBMISSION_STAFF_IDtableIndex As Integer = 0
    ASSIGNMENT_SUBMISSION_STAFF_IDDataCommand.OrderBy = "STAFF_ID"
    ASSIGNMENT_SUBMISSION_STAFF_IDDataCommand.Parameters.Clear()
'End ListBox ASSIGNMENT_SUBMISSION_STAFF_ID Initialize Data Source

'ListBox ASSIGNMENT_SUBMISSION_STAFF_ID BeforeExecuteSelect @70-E0EEFBC6
    Try
        ListBoxSource=ASSIGNMENT_SUBMISSION_STAFF_IDDataCommand.Execute().Tables(ASSIGNMENT_SUBMISSION_STAFF_IDtableIndex).Rows
    Catch ee as Exception 
        E=ee
    Finally
'End ListBox ASSIGNMENT_SUBMISSION_STAFF_ID BeforeExecuteSelect

'ListBox ASSIGNMENT_SUBMISSION_STAFF_ID AfterExecuteSelect @70-38DEC014
        If Not IsNothing(E) Then Throw E
    End Try
    Dim ASSIGNMENT_SUBMISSION_STAFF_IDItems As ItemCollection = New ItemCollection()
    For j=0 To ListBoxSource.Count-1 
        Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
        Dim Val As Object = ListBoxSource(j)("STAFF_ID")
        ASSIGNMENT_SUBMISSION_STAFF_IDItems.Add(Key, Val)
    Next
'End ListBox ASSIGNMENT_SUBMISSION_STAFF_ID AfterExecuteSelect

'After execute Select tail @3-D57E4CEA
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as ASSIGNMENT_SUBMISSION_STU1Item = New ASSIGNMENT_SUBMISSION_STU1Item()
            item.IsDeleteAllowed = ops.AllowDelete
            item.ASSIGNMENT_SUBMISSION_SUBJECT_ID.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_SUBJECT_ID"),"")
            item.ASSIGNMENT_SUBMISSION_STUDENT_ID.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_STUDENT_ID"),"")
            item.ASSIGNMENT_ID.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.SUBMISSION_ID.SetValue(dr(i)("SUBMISSION_ID"),"")
            item.RECEIVED_DATE.SetValue(dr(i)("RECEIVED_DATE"),Select_.DateFormat)
            item.RETURNED_DATE.SetValue(dr(i)("RETURNED_DATE"),Select_.DateFormat)
            item.ASSIGNMENT_SUBMISSION_STAFF_ID.SetValue(dr(i)("MARKERID"),"")
            item.ASSIGNMENT_SUBMISSION_STAFF_IDItems = CType(ASSIGNMENT_SUBMISSION_STAFF_IDItems.Clone(), ItemCollection)
            item.COMMENTS.SetValue(dr(i)("COMMENTS"),"")
            item.STUDENT_IDField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_STUDENT_ID"),"")
            item.ENROLMENT_YEARField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_SUBJECT_ID"),"")
            item.ASSIGNMENT_IDField.SetValue(dr(i)("ASSIGNMENT_ID"),"")
            item.SUBMISSION_IDField.SetValue(dr(i)("SUBMISSION_ID"),"")
            item.ASSIGNMENT_SUBMISSION_STUDENT_IDField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_STUDENT_ID"),"")
            item.ASSIGNMENT_SUBMISSION_ENROLMENT_YEARField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_ENROLMENT_YEAR"),"")
            item.ASSIGNMENT_SUBMISSION_SUBJECT_IDField.SetValue(dr(i)("ASSIGNMENT_SUBMISSION_SUBJECT_ID"),"")
            item.RawData = dr(i)
            result(i)=item
        Next i
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail


'Grid Data Provider tail @3-A61BA892
End Class
'End Grid Data Provider tail

'Record ASSIGNMENT_SUBMISSION_STU Item Class @33-051F70D4
Public Class ASSIGNMENT_SUBMISSION_STUItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_STUDENT_SUBJECT_STUDENT_ID As FloatField
    Public s_STUDENT_SUBJECT_SUBJECT_ID As IntegerField
    Public s_STUDENT_SUBJECT_STAFF_ID As TextField
    Public s_STUDENT_SUBJECT_STAFF_IDItems As ItemCollection
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_STUDENT_SUBJECT_STUDENT_ID = New FloatField("", Nothing)
    s_STUDENT_SUBJECT_SUBJECT_ID = New IntegerField("", Nothing)
    s_STUDENT_SUBJECT_STAFF_ID = New TextField("", "")
    s_STUDENT_SUBJECT_STAFF_IDItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As ASSIGNMENT_SUBMISSION_STUItem
        Dim item As ASSIGNMENT_SUBMISSION_STUItem = New ASSIGNMENT_SUBMISSION_STUItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_STUDENT_ID")) Then
        item.s_STUDENT_SUBJECT_STUDENT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_STUDENT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_SUBJECT_ID")) Then
        item.s_STUDENT_SUBJECT_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_STAFF_ID")) Then
        item.s_STUDENT_SUBJECT_STAFF_ID.SetValue(DBUtility.GetInitialValue("s_STUDENT_SUBJECT_STAFF_ID"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_STUDENT_SUBJECT_STUDENT_ID"
                    Return s_STUDENT_SUBJECT_STUDENT_ID
                Case "s_STUDENT_SUBJECT_SUBJECT_ID"
                    Return s_STUDENT_SUBJECT_SUBJECT_ID
                Case "s_STUDENT_SUBJECT_STAFF_ID"
                    Return s_STUDENT_SUBJECT_STAFF_ID
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_STUDENT_SUBJECT_STUDENT_ID"
                    s_STUDENT_SUBJECT_STUDENT_ID = CType(value, FloatField)
                Case "s_STUDENT_SUBJECT_SUBJECT_ID"
                    s_STUDENT_SUBJECT_SUBJECT_ID = CType(value, IntegerField)
                Case "s_STUDENT_SUBJECT_STAFF_ID"
                    s_STUDENT_SUBJECT_STAFF_ID = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As ASSIGNMENT_SUBMISSION_STUDataProvider)
'End Record ASSIGNMENT_SUBMISSION_STU Item Class

'Record ASSIGNMENT_SUBMISSION_STU Item Class tail @33-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record ASSIGNMENT_SUBMISSION_STU Item Class tail

'Record ASSIGNMENT_SUBMISSION_STU Data Provider Class @33-39554796
Public Class ASSIGNMENT_SUBMISSION_STUDataProvider
Inherits RecordDataProviderBase
'End Record ASSIGNMENT_SUBMISSION_STU Data Provider Class

'Record ASSIGNMENT_SUBMISSION_STU Data Provider Class Variables @33-99FCFF4B
    Protected s_STUDENT_SUBJECT_STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT staff_ID, " & vbCrLf & _
          "staffname " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr78","And","expr79"},Settings.connDECVPRODSQL2005DataAccessObject )
    Protected item As ASSIGNMENT_SUBMISSION_STUItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record ASSIGNMENT_SUBMISSION_STU Data Provider Class Variables

'Record ASSIGNMENT_SUBMISSION_STU Data Provider Class GetResultSet Method @33-1F1C93A9

    Public Sub FillItem(ByVal item As ASSIGNMENT_SUBMISSION_STUItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record ASSIGNMENT_SUBMISSION_STU Data Provider Class GetResultSet Method

'Record ASSIGNMENT_SUBMISSION_STU BeforeBuildSelect @33-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record ASSIGNMENT_SUBMISSION_STU BeforeBuildSelect

'Record ASSIGNMENT_SUBMISSION_STU AfterExecuteSelect @33-83591636
        End If
            IsInsertMode = True
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record ASSIGNMENT_SUBMISSION_STU AfterExecuteSelect

'ListBox s_STUDENT_SUBJECT_STAFF_ID Initialize Data Source @38-300883ED
        s_STUDENT_SUBJECT_STAFF_IDDataCommand.Dao._optimized = False
        Dim s_STUDENT_SUBJECT_STAFF_IDtableIndex As Integer = 0
        s_STUDENT_SUBJECT_STAFF_IDDataCommand.OrderBy = "STAFF_ID"
        s_STUDENT_SUBJECT_STAFF_IDDataCommand.Parameters.Clear()
        s_STUDENT_SUBJECT_STAFF_IDDataCommand.Parameters.Add("expr78","(STATUS=1)")
        s_STUDENT_SUBJECT_STAFF_IDDataCommand.Parameters.Add("expr79","(TEACHER_FLAG=1)")
'End ListBox s_STUDENT_SUBJECT_STAFF_ID Initialize Data Source

'ListBox s_STUDENT_SUBJECT_STAFF_ID BeforeExecuteSelect @38-7652625F
        Try
            ListBoxSource=s_STUDENT_SUBJECT_STAFF_IDDataCommand.Execute().Tables(s_STUDENT_SUBJECT_STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_STUDENT_SUBJECT_STAFF_ID BeforeExecuteSelect

'ListBox s_STUDENT_SUBJECT_STAFF_ID AfterExecuteSelect @38-93269B82
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("STAFF_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.s_STUDENT_SUBJECT_STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox s_STUDENT_SUBJECT_STAFF_ID AfterExecuteSelect

'Record ASSIGNMENT_SUBMISSION_STU AfterExecuteSelect tail @33-E31F8E2A
    End Sub
'End Record ASSIGNMENT_SUBMISSION_STU AfterExecuteSelect tail

'Record ASSIGNMENT_SUBMISSION_STU Data Provider Class @33-A61BA892
End Class

'End Record ASSIGNMENT_SUBMISSION_STU Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

