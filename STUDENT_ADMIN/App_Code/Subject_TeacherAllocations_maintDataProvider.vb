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

Namespace DECV_PROD2007.Subject_TeacherAllocations_maint 'Namespace @1-A7A0F2A4

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

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Item Class @3-9A1D1177
Public Class SUBJECT_TEACHER_SUBJECT_SItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = True
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public FIRSTNAME As MemoField
    Public SCAFFOLD_COURSEDEV_FLAG As IntegerField
    Public LAST_UPDATED As DateField
    Public SUBJECT_TEACHER_STAFF_ID As TextField
    Public SUBJECT_TEACHER_SUBJECT_ID As IntegerField
    Public SURNAME As MemoField
    Public lblLastUpdated As DateField
    Public TotalRecords As TextField
    Public rbAllocatable As IntegerField
    Public rbAllocatableItems As ItemCollection
    Public TIME_FRACTION As FloatField
    Public SCAFFOLD_COURSEDEV_UPDATED As DateField
    Public SCAFFOLD_COURSEDEV_FLAG1 As IntegerField
    Public checkDelete As BooleanField
    Public checkDeleteCheckedValue As BooleanField
    Public checkDeleteUncheckedValue As BooleanField
    Public Sub New()
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    FIRSTNAME = New MemoField("", Nothing)
    SCAFFOLD_COURSEDEV_FLAG = New IntegerField("", Nothing)
    LAST_UPDATED = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SUBJECT_TEACHER_STAFF_ID = New TextField("", Nothing)
    SUBJECT_TEACHER_SUBJECT_ID = New IntegerField("", Nothing)
    SURNAME = New MemoField("", Nothing)
    lblLastUpdated = New DateField("d MMM yyyy h\:mm tt", Nothing)
    TotalRecords = New TextField("", Nothing)
    rbAllocatable = New IntegerField("", Nothing)
    rbAllocatableItems = New ItemCollection()
    TIME_FRACTION = New FloatField("0.00", 0.0)
    SCAFFOLD_COURSEDEV_UPDATED = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SCAFFOLD_COURSEDEV_FLAG1 = New IntegerField("", 0)
    checkDelete = New BooleanField(Settings.BoolFormat, False)
    checkDeleteCheckedValue = New BooleanField(Settings.BoolFormat, True)
    checkDeleteUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase
        Get
            Select fieldName
                Case "STAFF_IDField"
                    Return Me.STAFF_IDField
                Case "SUBJECT_IDField"
                    Return Me.SUBJECT_IDField
                Case "SUBJECT_ABBREV"
                    Return Me.SUBJECT_ABBREV
                Case "SUBJECT_TITLE"
                    Return Me.SUBJECT_TITLE
                Case "FIRSTNAME"
                    Return Me.FIRSTNAME
                Case "SCAFFOLD_COURSEDEV_FLAG"
                    Return Me.SCAFFOLD_COURSEDEV_FLAG
                Case "LAST_UPDATED"
                    Return Me.LAST_UPDATED
                Case "SUBJECT_TEACHER_STAFF_ID"
                    Return Me.SUBJECT_TEACHER_STAFF_ID
                Case "SUBJECT_TEACHER_SUBJECT_ID"
                    Return Me.SUBJECT_TEACHER_SUBJECT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "lblLastUpdated"
                    Return Me.lblLastUpdated
                Case "TotalRecords"
                    Return Me.TotalRecords
                Case "rbAllocatable"
                    Return Me.rbAllocatable
                Case "TIME_FRACTION"
                    Return Me.TIME_FRACTION
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    Return Me.SCAFFOLD_COURSEDEV_UPDATED
                Case "SCAFFOLD_COURSEDEV_FLAG1"
                    Return Me.SCAFFOLD_COURSEDEV_FLAG1
                Case "checkDelete"
                    Return Me.checkDelete
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "STAFF_IDField"
                    Me.STAFF_IDField = CType(Value,TextField)
                Case "SUBJECT_IDField"
                    Me.SUBJECT_IDField = CType(Value,IntegerField)
                Case "SUBJECT_ABBREV"
                    Me.SUBJECT_ABBREV = CType(Value,TextField)
                Case "SUBJECT_TITLE"
                    Me.SUBJECT_TITLE = CType(Value,TextField)
                Case "FIRSTNAME"
                    Me.FIRSTNAME = CType(Value,MemoField)
                Case "SCAFFOLD_COURSEDEV_FLAG"
                    Me.SCAFFOLD_COURSEDEV_FLAG = CType(Value,IntegerField)
                Case "LAST_UPDATED"
                    Me.LAST_UPDATED = CType(Value,DateField)
                Case "SUBJECT_TEACHER_STAFF_ID"
                    Me.SUBJECT_TEACHER_STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_TEACHER_SUBJECT_ID"
                    Me.SUBJECT_TEACHER_SUBJECT_ID = CType(Value,IntegerField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,MemoField)
                Case "lblLastUpdated"
                    Me.lblLastUpdated = CType(Value,DateField)
                Case "TotalRecords"
                    Me.TotalRecords = CType(Value,TextField)
                Case "rbAllocatable"
                    Me.rbAllocatable = CType(Value,IntegerField)
                Case "TIME_FRACTION"
                    Me.TIME_FRACTION = CType(Value,FloatField)
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    Me.SCAFFOLD_COURSEDEV_UPDATED = CType(Value,DateField)
                Case "SCAFFOLD_COURSEDEV_FLAG1"
                    Me.SCAFFOLD_COURSEDEV_FLAG1 = CType(Value,IntegerField)
                Case "checkDelete"
                    Me.checkDelete = CType(Value,BooleanField)
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
            result = IsNothing(LAST_UPDATED.Value) And result
            result = IsNothing(SUBJECT_TEACHER_STAFF_ID.Value) And result
            result = IsNothing(SUBJECT_TEACHER_SUBJECT_ID.Value) And result
            result = IsNothing(rbAllocatable.Value) And result
            result = IsNothing(TIME_FRACTION.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_UPDATED.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_FLAG1.Value) And result
            result = IsNothing(checkDelete.Value) And result
            result = IsNothing(STAFF_IDField.Value) And result
            Return result
        End Get
    End Property

    Public IsDeleted As Boolean = False
    Public IsUpdated As Boolean = False
    Public STAFF_IDField As TextField = New TextField()
    Public SUBJECT_IDField As IntegerField = New IntegerField()
    Public Function Validate(ByVal provider As SUBJECT_TEACHER_SUBJECT_SDataProvider) As Boolean
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Item Class

'SUBJECT_TEACHER_STAFF_ID validate @30-C32E3968
        If IsNothing(SUBJECT_TEACHER_STAFF_ID.Value) OrElse SUBJECT_TEACHER_STAFF_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_TEACHER_STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT TEACHER STAFF ID"))
        End If
'End SUBJECT_TEACHER_STAFF_ID validate

'SUBJECT_TEACHER_SUBJECT_ID validate @29-A0EF1394
        If IsNothing(SUBJECT_TEACHER_SUBJECT_ID.Value) OrElse SUBJECT_TEACHER_SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_TEACHER_SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT TEACHER SUBJECT ID"))
        End If
'End SUBJECT_TEACHER_SUBJECT_ID validate

'TIME_FRACTION validate @344-8AA78A3F
        If IsNothing(TIME_FRACTION.Value) OrElse TIME_FRACTION.Value.ToString() ="" Then
            errors.Add("TIME_FRACTION",String.Format(Resources.strings.CCS_RequiredField,"Time Fraction"))
        End If
'End TIME_FRACTION validate

'TextBox TIME_FRACTION Event OnValidate. Action Validate Minimum Value @345-3EC522C5
        If Not (TIME_FRACTION.Value Is Nothing) Then
            If Convert.ToDouble(TIME_FRACTION.Value) < 0.00 Then
            errors.Add("TIME_FRACTION",String.Format("Time Fraction must be 0.0 or greater","Time Fraction","0.00"))
            End If
        End If
'End TextBox TIME_FRACTION Event OnValidate. Action Validate Minimum Value

'TextBox TIME_FRACTION Event OnValidate. Action Validate Maximum Value @346-54736467
        If Not (TIME_FRACTION.Value Is Nothing) Then
            If Convert.ToDouble(TIME_FRACTION.Value) > 1.1 Then
            errors.Add("TIME_FRACTION",String.Format("Time Fraction must not exceed 1.1 EFT","Time Fraction","1.1"))
            End If
        End If
'End TextBox TIME_FRACTION Event OnValidate. Action Validate Maximum Value

'SCAFFOLD_COURSEDEV_FLAG1 validate @388-F0F29363
        If IsNothing(SCAFFOLD_COURSEDEV_FLAG1.Value) OrElse SCAFFOLD_COURSEDEV_FLAG1.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_FLAG1",String.Format(Resources.strings.CCS_RequiredField,"SCAFFOLD COURSEDEV FLAG"))
        End If
'End SCAFFOLD_COURSEDEV_FLAG1 validate

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Item Class tail @3-11D8DCF0
        Return errors.Count = 0
    End Function
    Public RawData As DataRow = Nothing
End Class
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Item Class tail

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Header @3-35ACA224
Public Class SUBJECT_TEACHER_SUBJECT_SDataProvider
Inherits EditableGridDataProviderBase
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Header

'Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Variables @3-A56ED738

    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJECT_ABBREV
        Sorter_SUBJECT_TITLE
        Sorter_SCAFFOLD_COURSEDEV_FLAG
        Sorter_SCAFFOLD_COURSEDEV_UPDATED
    End Enum

    Private SortFieldsNames As String() = New String() {"SUBJECT_ABBREV","SUBJECT_ABBREV","SUBJECT_TITLE","SCAFFOLD_COURSEDEV_FLAG","SCAFFOLD_COURSEDEV_UPDATED"}
    Private SortFieldsNamesDesc As String() = New string() {"SUBJECT_ABBREV","SUBJECT_ABBREV DESC","SUBJECT_TITLE DESC","SCAFFOLD_COURSEDEV_FLAG DESC","SCAFFOLD_COURSEDEV_UPDATED DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public Urls_SUBJECT_ID  As IntegerParameter
    Public UrlrbShow  As FloatParameter
    Public CtrlSCAFFOLD_COURSEDEV_FLAG1  As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_UPDATED  As DateParameter
    Public CtrlTIME_FRACTION  As FloatParameter
    Public CtrlrbAllocatable  As IntegerParameter
    Public CtrlLAST_UPDATED  As DateParameter
'End Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Variables

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Constructor @3-33C345FB

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SUBJECT_ABBREV, SUBJECT_TITLE, " & vbCrLf & _
          "rtrim(FIRSTNAME) AS FIRSTNAME, rtrim(SURNAME) AS SURNAME, " & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID AS SUBJECT_ID," & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID AS STAFF_ID, SUBJECT_TIMEFRACTION, ALLOCATABLE_FLAG, " & vbCrLf & _
          "SUBJECT_TEACHER.LAST_ALTERED_BY AS SUBJECT_TEACHER_LAST_ALTERED_BY," & vbCrLf & _
          "SUBJECT_TEACHER.LAST_ALTERED_DATE AS SUBJECT_TEACHER_LAST_ALTERED_DATE, (case when SCAFFOL" & _
          "D_COURSEDEV_FLAG = 1 then 'Yes' else 'No' end) AS display_coursedev_flag," & vbCrLf & _
          "SCAFFOLD_COURSEDEV_FLAG, SCAFFOLD_COURSEDEV_UPDATED " & vbCrLf & _
          "FROM (SUBJECT_TEACHER INNER JOIN SUBJECT ON" & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN STAFF ON" & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID = STAFF.STAFF_ID {SQL_Where} {SQL_OrderBy}", New String(){"(","(","s_keyword406","Or","s_keyword407","Or","s_keyword408","Or","s_keyword409","Or","s_keyword410",")","Or","s_SUBJECT_ID411",")","And","rbShow412"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM (SUBJECT_TEACHER INNER JOIN SUBJECT ON" & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN STAFF ON" & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID = STAFF.STAFF_ID", New String(){"(","(","s_keyword406","Or","s_keyword407","Or","s_keyword408","Or","s_keyword409","Or","s_keyword410",")","Or","s_SUBJECT_ID411",")","And","rbShow412"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Constructor

'Record SUBJECT_TEACHER_SUBJECT_S Data Provider Class CheckUnique Method @3-7A3C5974

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_TEACHER_SUBJECT_SItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_TEACHER_SUBJECT_S Data Provider Class CheckUnique Method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Update Method @3-E3EDBD6E
    Protected Function UpdateItem(ByVal item As SUBJECT_TEACHER_SUBJECT_SItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STAFF_IDField) Or IsNothing(item.SUBJECT_IDField))
        Dim Update As DataCommand=new TableCommand("UPDATE SUBJECT_TEACHER SET {Values}", New String(){"STAFF_ID204","And","SUBJECT_ID205"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Update Method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeBuildUpdate @3-A9609375
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STAFF_ID204",item.STAFF_IDField, "","STAFF_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID205",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_FLAG1.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_FLAG1.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_FLAG1.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_FLAG=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_FLAG=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_FLAG1.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty And allEmptyFlag
        If IsNothing(item.SCAFFOLD_COURSEDEV_UPDATED.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_UPDATED=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_UPDATED=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        allEmptyFlag = item.TIME_FRACTION.IsEmpty And allEmptyFlag
        If Not item.TIME_FRACTION.IsEmpty Then
        If IsNothing(item.TIME_FRACTION.Value) Then
        valuesList = valuesList & "SUBJECT_TIMEFRACTION=" & Update.Dao.ToSql((0.0).ToString(),FieldType._Float) & ","
        Else
        valuesList = valuesList & "SUBJECT_TIMEFRACTION=" & Update.Dao.ToSql(item.TIME_FRACTION.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = item.rbAllocatable.IsEmpty And allEmptyFlag
        If Not item.rbAllocatable.IsEmpty Then
        If IsNothing(item.rbAllocatable.Value) Then
        valuesList = valuesList & "ALLOCATABLE_FLAG=" & Update.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        valuesList = valuesList & "ALLOCATABLE_FLAG=" & Update.Dao.ToSql(item.rbAllocatable.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.LAST_UPDATED.IsEmpty And allEmptyFlag
        If Not item.LAST_UPDATED.IsEmpty Then
        If IsNothing(item.LAST_UPDATED.Value) Then
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql((NOW()).ToString(),FieldType._Date) & ","
        Else
        valuesList = valuesList & "LAST_ALTERED_DATE=" & Update.Dao.ToSql(item.LAST_UPDATED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        End If
		Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(","C))
		
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeBuildUpdate

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Execute Update  @3-392E25E7
        Update.OpType = OperationType.Update
        Dim result As Object = 0
        Dim E As Exception = Nothing
        If CmdExecution Then
            If Not IsParametersPassed Then
                item.errors.Add("DataProvider",Resources.strings.CCS_CustomOperationError_MissingParameters)
                Return 0
            End If
            Try
                 If Not allEmptyFlag Then result = Update.ExecuteNonQuery()
            Catch e_ As Exception
                item.errors.Add("DataProvider",e_.Source + ":" + e_.Message)
            Finally
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Execute Update 

'EditableGrid SUBJECT_TEACHER_SUBJECT_S AfterExecuteUpdate @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S AfterExecuteUpdate

'Record SUBJECT_TEACHER_SUBJECT_S Data Provider Class Delete Method @3-21C50B20
    Public Function DeleteItem(ByVal item As SUBJECT_TEACHER_SUBJECT_SItem) As Integer
        Dim CmdExecution As Boolean = True
        Dim IsParametersPassed As Boolean = True
        IsParametersPassed = Not(IsNothing(item.STAFF_IDField) Or IsNothing(item.SUBJECT_IDField))
        Dim Delete As DataCommand=new TableCommand("DELETE FROM SUBJECT_TEACHER", New String(){"STAFF_ID430","And","SUBJECT_ID431"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT_TEACHER_SUBJECT_S Data Provider Class Delete Method

'Record SUBJECT_TEACHER_SUBJECT_S BeforeBuildDelete @3-7378EE61
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("STAFF_ID430",item.STAFF_IDField, "","STAFF_ID",Condition.Equal,False)
        CType(Delete,TableCommand).AddParameter("SUBJECT_ID431",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
'End Record SUBJECT_TEACHER_SUBJECT_S BeforeBuildDelete

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Execute Delete @3-124DEAF1
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
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Execute Delete

'EditableGrid SUBJECT_TEACHER_SUBJECT_S AfterExecuteDelete @3-0F8B2F9F
            End Try
        End If
        Return CType(result, Integer)
    End Function
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S AfterExecuteDelete

'Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method @3-603A5A77
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As SUBJECT_TEACHER_SUBJECT_SItem = CType(Items(i), SUBJECT_TEACHER_SUBJECT_SItem)
'End Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Update @3-16326EAB
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
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Update

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class AfterUpdate @3-6CCB76B9
                If item.errors.Count = 0 Then item.IsUpdated = True
                OnItemUpdated(New ItemUpdatedEventArgs(op, item))
            End If
        Next i
    End Sub
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class AfterUpdate

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method @3-4B751DC6
    Public Function GetResultSet(ByRef _pagesCount As Integer, ops As FormSupportedOperations) As SUBJECT_TEACHER_SUBJECT_SItem()
'End EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method

'Before build Select @3-B0B664E2
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword406",Urls_keyword, "","SUBJECT_TEACHER.STAFF_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword407",Urls_keyword, "","SUBJECT.SUBJECT_ABBREV",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword408",Urls_keyword, "","SUBJECT.SUBJECT_TITLE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword409",Urls_keyword, "","SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword410",Urls_keyword, "","FIRSTNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_SUBJECT_ID411",Urls_SUBJECT_ID, "","SUBJECT_TEACHER.SUBJECT_ID",Condition.Equal,False)
        CType(Select_,TableCommand).AddParameter("rbShow412",UrlrbShow, "","SUBJECT_TIMEFRACTION",Condition.GreaterThan,False)
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

'After execute Select @3-A3398A6D
                If Not IsNothing(E) Then Throw E
            End Try
            dr = ds.Tables(tableIndex).Rows
            rowCount = dr.Count
        End If
        Dim result(rowCount - 1) As SUBJECT_TEACHER_SUBJECT_SItem
'End After execute Select

'ListBox rbAllocatable AfterExecuteSelect @343-BFB81118
    Dim rbAllocatableItems As ItemCollection = New ItemCollection()
    
rbAllocatableItems.Add("1","Yes!")
rbAllocatableItems.Add("0","NOT to this Teacher")
'End ListBox rbAllocatable AfterExecuteSelect

'After execute Select tail @3-2A6461B4
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as SUBJECT_TEACHER_SUBJECT_SItem = New SUBJECT_TEACHER_SUBJECT_SItem()
            item.IsDeleteAllowed = ops.AllowDelete
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.FIRSTNAME.SetValue(dr(i)("FIRSTNAME"),"")
            item.SCAFFOLD_COURSEDEV_FLAG.SetValue(dr(i)("SCAFFOLD_COURSEDEV_FLAG"),"")
            item.LAST_UPDATED.SetValue(dr(i)("SUBJECT_TEACHER_LAST_ALTERED_DATE"),"yyyy-MM-dd HH\:mm\:ss")
            item.SUBJECT_TEACHER_STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.SUBJECT_TEACHER_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.lblLastUpdated.SetValue(dr(i)("SUBJECT_TEACHER_LAST_ALTERED_DATE"),Select_.DateFormat)
            item.rbAllocatable.SetValue(dr(i)("ALLOCATABLE_FLAG"),"")
            item.rbAllocatableItems = CType(rbAllocatableItems.Clone(), ItemCollection)
            item.TIME_FRACTION.SetValue(dr(i)("SUBJECT_TIMEFRACTION"),"")
            item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(dr(i)("SCAFFOLD_COURSEDEV_UPDATED"),"yyyy-MM-dd HH\:mm\:ss")
            item.SCAFFOLD_COURSEDEV_FLAG1.SetValue(dr(i)("SCAFFOLD_COURSEDEV_FLAG"),"")
            item.STAFF_IDField.SetValue(dr(i)("STAFF_ID"),"")
            item.SUBJECT_IDField.SetValue(dr(i)("SUBJECT_ID"),"")
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

'Record SUBJECT_SUBJECT_TEACHER Item Class @40-73CBBD61
Public Class SUBJECT_SUBJECT_TEACHERItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public ClearParameters As TextField
    Public ClearParametersHref As Object
    Public ClearParametersHrefParameters As LinkParameterCollection
    Public s_keyword As TextField
    Public s_SUBJECT_ID As IntegerField
    Public s_SUBJECT_IDItems As ItemCollection
    Public rbConfirm As IntegerField
    Public rbConfirmItems As ItemCollection
    Public lblConfirmError As TextField
    Public rbShow As IntegerField
    Public rbShowItems As ItemCollection
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    s_SUBJECT_ID = New IntegerField("", Nothing)
    s_SUBJECT_IDItems = New ItemCollection()
    rbConfirm = New IntegerField("", 0)
    rbConfirmItems = New ItemCollection()
    lblConfirmError = New TextField("", Nothing)
    rbShow = New IntegerField("", 0)
    rbShowItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECT_SUBJECT_TEACHERItem
        Dim item As SUBJECT_SUBJECT_TEACHERItem = New SUBJECT_SUBJECT_TEACHERItem()
        If Not IsNothing(DBUtility.GetInitialValue("ClearParameters")) Then
        item.ClearParameters.SetValue(DBUtility.GetInitialValue("ClearParameters"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_SUBJECT_ID")) Then
        item.s_SUBJECT_ID.SetValue(DBUtility.GetInitialValue("s_SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ButtonResetDevToNo")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbConfirm")) Then
        item.rbConfirm.SetValue(DBUtility.GetInitialValue("rbConfirm"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("lblConfirmError")) Then
        item.lblConfirmError.SetValue(DBUtility.GetInitialValue("lblConfirmError"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbShow")) Then
        item.rbShow.SetValue(DBUtility.GetInitialValue("rbShow"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "ClearParameters"
                    Return ClearParameters
                Case "s_keyword"
                    Return s_keyword
                Case "s_SUBJECT_ID"
                    Return s_SUBJECT_ID
                Case "rbConfirm"
                    Return rbConfirm
                Case "lblConfirmError"
                    Return lblConfirmError
                Case "rbShow"
                    Return rbShow
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "ClearParameters"
                    ClearParameters = CType(value, TextField)
                Case "s_keyword"
                    s_keyword = CType(value, TextField)
                Case "s_SUBJECT_ID"
                    s_SUBJECT_ID = CType(value, IntegerField)
                Case "rbConfirm"
                    rbConfirm = CType(value, IntegerField)
                Case "lblConfirmError"
                    lblConfirmError = CType(value, TextField)
                Case "rbShow"
                    rbShow = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As SUBJECT_SUBJECT_TEACHERDataProvider)
'End Record SUBJECT_SUBJECT_TEACHER Item Class

'rbConfirm validate @392-14C54645
        If IsNothing(rbConfirm.Value) OrElse rbConfirm.Value.ToString() ="" Then
            errors.Add("rbConfirm",String.Format(Resources.strings.CCS_RequiredField,"Confirm Reset"))
        End If
'End rbConfirm validate

'RadioButton rbConfirm Event OnValidate. Action Validate Minimum Value @393-3E27FC80
        If Not (rbConfirm.Value Is Nothing) Then
            If Convert.ToDouble(rbConfirm.Value) < 1 Then
            errors.Add("rbConfirm",String.Format("Must select 'Yes' to confirm Reset","Confirm Reset","1"))
            End If
        End If
'End RadioButton rbConfirm Event OnValidate. Action Validate Minimum Value

'Record SUBJECT_SUBJECT_TEACHER Item Class tail @40-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT_SUBJECT_TEACHER Item Class tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class @40-0446A6B3
Public Class SUBJECT_SUBJECT_TEACHERDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Variables @40-70986127
    Protected s_SUBJECT_IDDataCommand As DataCommand=new SqlCommand("select * from view_ReportParams_Subjects {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected item As SUBJECT_SUBJECT_TEACHERItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Variables

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Constructor @40-96A5F6A0

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT_TEACHER {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new SqlCommand("UPDATE SUBJECT_TEACHER " & vbCrLf & _
          "SET ALLOCATABLE_FLAG = 0 " & vbCrLf & _
          "WHERE ALLOCATABLE_FLAG = 1 ",Settings.connDECVPRODSQL2005DataAccessObject)
        Select_.OrderBy=""
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Constructor

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class LoadParams Method @40-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class LoadParams Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class CheckUnique Method @40-524FBB55

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_SUBJECT_TEACHERItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class CheckUnique Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method @40-3CDFF327

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareDelete Method tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Delete Method @40-5B4A7E9D
    Public Function DeleteItem(ByVal item As SUBJECT_SUBJECT_TEACHERItem) As Integer
        Me.item = item
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Delete Method

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete @40-708C4E57
        Delete.Parameters.Clear()
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteDelete()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildDelete

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class GetResultSet Method @40-2D3F5E0B

    Public Sub FillItem(ByVal item As SUBJECT_SUBJECT_TEACHERItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class GetResultSet Method

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildSelect @40-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildSelect

'Record SUBJECT_SUBJECT_TEACHER BeforeExecuteSelect @40-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SUBJECT_SUBJECT_TEACHER BeforeExecuteSelect

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect @40-732B00EB
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ClearParametersHref = "Subject_TeacherAllocations_maint.aspx"
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect

'ListBox s_SUBJECT_ID Initialize Data Source @69-94F6D4C1
        s_SUBJECT_IDDataCommand.Dao._optimized = False
        Dim s_SUBJECT_IDtableIndex As Integer = 0
        s_SUBJECT_IDDataCommand.OrderBy = "SUBJECT_TITLE"
        s_SUBJECT_IDDataCommand.Parameters.Clear()
'End ListBox s_SUBJECT_ID Initialize Data Source

'ListBox s_SUBJECT_ID BeforeExecuteSelect @69-AAB4F199
        Try
            ListBoxSource=s_SUBJECT_IDDataCommand.Execute().Tables(s_SUBJECT_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox s_SUBJECT_ID BeforeExecuteSelect

'ListBox s_SUBJECT_ID AfterExecuteSelect @69-2DE7F056
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.s_SUBJECT_IDItems.Add(Key, Val)
        Next
'End ListBox s_SUBJECT_ID AfterExecuteSelect

'ListBox rbConfirm AfterExecuteSelect @392-AC940DA7
        
item.rbConfirmItems.Add("0","<font color=#00FF00>No reset</font>")
item.rbConfirmItems.Add("1","<font color=#FF0000>Yes (Reset)</font>")
'End ListBox rbConfirm AfterExecuteSelect

'ListBox rbShow AfterExecuteSelect @400-7B57F5ED
        
item.rbShowItems.Add("0","Active only (TF > 0)")
item.rbShowItems.Add("-1","All Teachers")
'End ListBox rbShow AfterExecuteSelect

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class @40-A61BA892
End Class

'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Item Class @93-737DFF28
Public Class SUBJECT_TEACHERItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public SUBJECT_ID As IntegerField
    Public SUBJECT_IDItems As ItemCollection
    Public STAFF_ID As TextField
    Public STAFF_IDItems As ItemCollection
    Public SCAFFOLD_COURSEDEV_UPDATED As DateField
    Public SCAFFOLD_COURSEDEV_FLAG As IntegerField
    Public TIME_FRACTION As FloatField
    Public rbAllocatable As IntegerField
    Public rbAllocatableItems As ItemCollection
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_IDItems = New ItemCollection()
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    SCAFFOLD_COURSEDEV_UPDATED = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SCAFFOLD_COURSEDEV_FLAG = New IntegerField("", 0)
    TIME_FRACTION = New FloatField("0.00", 0.0)
    rbAllocatable = New IntegerField("", Nothing)
    rbAllocatableItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECT_TEACHERItem
        Dim item As SUBJECT_TEACHERItem = New SUBJECT_TEACHERItem()
        If Not IsNothing(DBUtility.GetInitialValue("SUBJECT_ID")) Then
        item.SUBJECT_ID.SetValue(DBUtility.GetInitialValue("SUBJECT_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("STAFF_ID")) Then
        item.STAFF_ID.SetValue(DBUtility.GetInitialValue("STAFF_ID"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_UPDATED")) Then
        item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_UPDATED"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ButtonInsert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("ButtonCancel")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_FLAG")) Then
        item.SCAFFOLD_COURSEDEV_FLAG.SetValue(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_FLAG"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TIME_FRACTION")) Then
        item.TIME_FRACTION.SetValue(DBUtility.GetInitialValue("TIME_FRACTION"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("rbAllocatable")) Then
        item.rbAllocatable.SetValue(DBUtility.GetInitialValue("rbAllocatable"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "SUBJECT_ID"
                    Return SUBJECT_ID
                Case "STAFF_ID"
                    Return STAFF_ID
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    Return SCAFFOLD_COURSEDEV_UPDATED
                Case "SCAFFOLD_COURSEDEV_FLAG"
                    Return SCAFFOLD_COURSEDEV_FLAG
                Case "TIME_FRACTION"
                    Return TIME_FRACTION
                Case "rbAllocatable"
                    Return rbAllocatable
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SUBJECT_ID"
                    SUBJECT_ID = CType(value, IntegerField)
                Case "STAFF_ID"
                    STAFF_ID = CType(value, TextField)
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    SCAFFOLD_COURSEDEV_UPDATED = CType(value, DateField)
                Case "SCAFFOLD_COURSEDEV_FLAG"
                    SCAFFOLD_COURSEDEV_FLAG = CType(value, IntegerField)
                Case "TIME_FRACTION"
                    TIME_FRACTION = CType(value, FloatField)
                Case "rbAllocatable"
                    rbAllocatable = CType(value, IntegerField)
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

    Public Sub Validate(ByVal provider As SUBJECT_TEACHERDataProvider)
'End Record SUBJECT_TEACHER Item Class

'SUBJECT_ID validate @94-22E3C20E
        If IsNothing(SUBJECT_ID.Value) OrElse SUBJECT_ID.Value.ToString() ="" Then
            errors.Add("SUBJECT_ID",String.Format(Resources.strings.CCS_RequiredField,"SUBJECT ID"))
        End If
'End SUBJECT_ID validate

'STAFF_ID validate @101-9B655313
        If IsNothing(STAFF_ID.Value) OrElse STAFF_ID.Value.ToString() ="" Then
            errors.Add("STAFF_ID",String.Format(Resources.strings.CCS_RequiredField,"STAFF ID"))
        End If
'End STAFF_ID validate

'SCAFFOLD_COURSEDEV_FLAG validate @103-24481E80
        If IsNothing(SCAFFOLD_COURSEDEV_FLAG.Value) OrElse SCAFFOLD_COURSEDEV_FLAG.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_FLAG",String.Format(Resources.strings.CCS_RequiredField,"SCAFFOLD COURSEDEV FLAG"))
        End If
'End SCAFFOLD_COURSEDEV_FLAG validate

'TIME_FRACTION validate @347-8AA78A3F
        If IsNothing(TIME_FRACTION.Value) OrElse TIME_FRACTION.Value.ToString() ="" Then
            errors.Add("TIME_FRACTION",String.Format(Resources.strings.CCS_RequiredField,"Time Fraction"))
        End If
'End TIME_FRACTION validate

'TextBox TIME_FRACTION Event OnValidate. Action Validate Minimum Value @348-3EC522C5
        If Not (TIME_FRACTION.Value Is Nothing) Then
            If Convert.ToDouble(TIME_FRACTION.Value) < 0.00 Then
            errors.Add("TIME_FRACTION",String.Format("Time Fraction must be 0.0 or greater","Time Fraction","0.00"))
            End If
        End If
'End TextBox TIME_FRACTION Event OnValidate. Action Validate Minimum Value

'TextBox TIME_FRACTION Event OnValidate. Action Validate Maximum Value @349-54736467
        If Not (TIME_FRACTION.Value Is Nothing) Then
            If Convert.ToDouble(TIME_FRACTION.Value) > 1.1 Then
            errors.Add("TIME_FRACTION",String.Format("Time Fraction must not exceed 1.1 EFT","Time Fraction","1.1"))
            End If
        End If
'End TextBox TIME_FRACTION Event OnValidate. Action Validate Maximum Value

'Record SUBJECT_TEACHER Item Class tail @93-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT_TEACHER Item Class tail

'Record SUBJECT_TEACHER Data Provider Class @93-73BC2482
Public Class SUBJECT_TEACHERDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Data Provider Class Variables @93-F34DCB3E
    Protected SUBJECT_IDDataCommand As DataCommand=new SqlCommand("select * from view_ReportParams_Subjects {SQL_OrderBy}",Settings.connDECVPRODSQL2005DataAccessObject)
    Protected STAFF_IDDataCommand As DataCommand=new TableCommand("SELECT * " & vbCrLf & _
          "FROM View_StaffList_Active_Inactive {SQL_Where} {SQL_OrderBy}", New String(){"expr219"},Settings.connDECVPRODSQL2005DataAccessObject )
    Public UrlSUBJECT_ID As TextParameter
    Public CtrlSUBJECT_ID As IntegerParameter
    Public CtrlSTAFF_ID As TextParameter
    Public CtrlSCAFFOLD_COURSEDEV_FLAG As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_UPDATED As DateParameter
    Public Expr200 As TextParameter
    Public Expr201 As DateParameter
    Public CtrlTIME_FRACTION As FloatParameter
    Public CtrlrbAllocatable As IntegerParameter
    Protected item As SUBJECT_TEACHERItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT_TEACHER Data Provider Class Variables

'Record SUBJECT_TEACHER Data Provider Class Constructor @93-FF59B87F

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT_TEACHER {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID356"},Settings.connDECVPRODSQL2005DataAccessObject )
        Select_.OrderBy=""
    End Sub
'End Record SUBJECT_TEACHER Data Provider Class Constructor

'Record SUBJECT_TEACHER Data Provider Class LoadParams Method @93-760FD411

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlSUBJECT_ID))
    End Function
'End Record SUBJECT_TEACHER Data Provider Class LoadParams Method

'Record SUBJECT_TEACHER Data Provider Class CheckUnique Method @93-CE9CF344

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As SUBJECT_TEACHERItem) As Boolean
        Return True
    End Function
'End Record SUBJECT_TEACHER Data Provider Class CheckUnique Method

'Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method @93-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method

'Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method tail @93-E31F8E2A
    End Sub
'End Record SUBJECT_TEACHER Data Provider Class PrepareInsert Method tail

'Record SUBJECT_TEACHER Data Provider Class Insert Method @93-FA2288B4

    Public Function InsertItem(ByVal item As SUBJECT_TEACHERItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO SUBJECT_TEACHER({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record SUBJECT_TEACHER Data Provider Class Insert Method

'Record SUBJECT_TEACHER Build insert @93-F4ED6907
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        allEmptyFlag = item.SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_ID.IsEmpty Then
        If IsNothing(item.SUBJECT_ID.Value) Then
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.STAFF_ID.IsEmpty And allEmptyFlag
        If Not item.STAFF_ID.IsEmpty Then
        If IsNothing(item.STAFF_ID.Value) Then
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "STAFF_ID,"
        valuesList = valuesList & Insert.Dao.ToSql(item.STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_FLAG.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_FLAG.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_FLAG.Value) Then
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCAFFOLD_COURSEDEV_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_UPDATED.Value) Then
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_UPDATED,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_UPDATED,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = (Expr200 Is Nothing) And allEmptyFlag
        If Not (Expr200 Is Nothing) Then
        If IsNothing(Expr200) Then
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(("unknown").ToString(),FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr200.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = (Expr201 Is Nothing) And allEmptyFlag
        If Not (Expr201 Is Nothing) Then
        If IsNothing(Expr201) Then
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr201.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.TIME_FRACTION.IsEmpty And allEmptyFlag
        If Not item.TIME_FRACTION.IsEmpty Then
        If IsNothing(item.TIME_FRACTION.Value) Then
        fieldsList = fieldsList & "SUBJECT_TIMEFRACTION,"
        valuesList = valuesList & Insert.Dao.ToSql((0.0).ToString(),FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_TIMEFRACTION,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TIME_FRACTION.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = item.rbAllocatable.IsEmpty And allEmptyFlag
        If Not item.rbAllocatable.IsEmpty Then
        If IsNothing(item.rbAllocatable.Value) Then
        fieldsList = fieldsList & "ALLOCATABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql((0).ToString(),FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "ALLOCATABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.rbAllocatable.GetFormattedValue(""),FieldType._Integer) & ","
        End If
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
'End Record SUBJECT_TEACHER Build insert

'Record SUBJECT_TEACHER AfterExecuteInsert @93-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT_TEACHER AfterExecuteInsert

'Record SUBJECT_TEACHER Data Provider Class GetResultSet Method @93-CCB2B35A

    Public Sub FillItem(ByVal item As SUBJECT_TEACHERItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECT_TEACHER Data Provider Class GetResultSet Method

'Record SUBJECT_TEACHER BeforeBuildSelect @93-CC1E4AA3
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID356",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECT_TEACHER BeforeBuildSelect

'Record SUBJECT_TEACHER BeforeExecuteSelect @93-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record SUBJECT_TEACHER BeforeExecuteSelect

'Record SUBJECT_TEACHER AfterExecuteSelect @93-348A3924
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(dr(i)("SCAFFOLD_COURSEDEV_UPDATED"),"yyyy-MM-dd HH\:mm\:ss")
            item.SCAFFOLD_COURSEDEV_FLAG.SetValue(dr(i)("SCAFFOLD_COURSEDEV_FLAG"),"")
            item.TIME_FRACTION.SetValue(dr(i)("SUBJECT_TIMEFRACTION"),"")
            item.rbAllocatable.SetValue(dr(i)("ALLOCATABLE_FLAG"),"")
        Else
            IsInsertMode = True
        End If
        Dim ListBoxSource As DataRowCollection = Nothing
        Dim j As Integer
'End Record SUBJECT_TEACHER AfterExecuteSelect

'ListBox SUBJECT_ID Initialize Data Source @94-B2EF6BFF
        SUBJECT_IDDataCommand.Dao._optimized = False
        Dim SUBJECT_IDtableIndex As Integer = 0
        SUBJECT_IDDataCommand.OrderBy = "SUBJECT_TITLE"
        SUBJECT_IDDataCommand.Parameters.Clear()
'End ListBox SUBJECT_ID Initialize Data Source

'ListBox SUBJECT_ID BeforeExecuteSelect @94-64D6C725
        Try
            ListBoxSource=SUBJECT_IDDataCommand.Execute().Tables(SUBJECT_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox SUBJECT_ID BeforeExecuteSelect

'ListBox SUBJECT_ID AfterExecuteSelect @94-43513585
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New IntegerField("", ListBoxSource(j)("SUBJECT_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("subject_displaylabel")
            item.SUBJECT_IDItems.Add(Key, Val)
        Next
'End ListBox SUBJECT_ID AfterExecuteSelect

'ListBox STAFF_ID Initialize Data Source @101-AFF30C3C
        STAFF_IDDataCommand.Dao._optimized = False
        Dim STAFF_IDtableIndex As Integer = 0
        STAFF_IDDataCommand.OrderBy = ""
        STAFF_IDDataCommand.Parameters.Clear()
        STAFF_IDDataCommand.Parameters.Add("expr219","(status = 1)")
'End ListBox STAFF_ID Initialize Data Source

'ListBox STAFF_ID BeforeExecuteSelect @101-0F683DF6
        Try
            ListBoxSource=STAFF_IDDataCommand.Execute().Tables(STAFF_IDtableIndex).Rows
        Catch ee as Exception 
            E=ee
        Finally
'End ListBox STAFF_ID BeforeExecuteSelect

'ListBox STAFF_ID AfterExecuteSelect @101-0FE625FB
            If Not IsNothing(E) Then Throw E
        End Try
        For j=0 To ListBoxSource.Count-1 
            Dim Key As String = (New TextField("", ListBoxSource(j)("staff_ID"))).GetFormattedValue("")
            Dim Val As Object = ListBoxSource(j)("staffname")
            item.STAFF_IDItems.Add(Key, Val)
        Next
'End ListBox STAFF_ID AfterExecuteSelect

'ListBox rbAllocatable AfterExecuteSelect @389-61A4F14E
        
item.rbAllocatableItems.Add("1","Yes!")
item.rbAllocatableItems.Add("0","NOT to this Teacher")
'End ListBox rbAllocatable AfterExecuteSelect

'Record SUBJECT_TEACHER AfterExecuteSelect tail @93-E31F8E2A
    End Sub
'End Record SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_TEACHER Data Provider Class @93-A61BA892
End Class

'End Record SUBJECT_TEACHER Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

