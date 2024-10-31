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

Namespace DECV_PROD2007.Subject_CourseDev_maint 'Namespace @1-8A0210C7

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

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Item Class @3-900F7D02
Public Class SUBJECT_TEACHER_SUBJECT_SItem
    Public errors As NameValueCollection = New NameValueCollection()
    Public RowId As Integer
    Private _deleteAllowed As Boolean = False
    Private _isNew As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SUBJECT_ABBREV As TextField
    Public SUBJECT_TITLE As TextField
    Public FIRSTNAME As MemoField
    Public SCAFFOLD_COURSEDEV_FLAG As IntegerField
    Public SCAFFOLD_COURSEDEV_FLAGItems As ItemCollection
    Public SCAFFOLD_COURSEDEV_UPDATED As DateField
    Public SUBJECT_TEACHER_STAFF_ID As TextField
    Public SUBJECT_TEACHER_SUBJECT_ID As IntegerField
    Public SURNAME As MemoField
    Public lblScaffoldLastUpdated As DateField
    Public TotalRecords As TextField
    Public SCAFFOLD_COURSEDEV_MODIFIER As TextField
    Public SCAFFOLD_COURSEDEV_STARTDATE As DateField
    Public SCAFFOLD_COURSEDEV_ENDDATE As DateField
    Public Sub New()
    SUBJECT_ABBREV = New TextField("", Nothing)
    SUBJECT_TITLE = New TextField("", Nothing)
    FIRSTNAME = New MemoField("", Nothing)
    SCAFFOLD_COURSEDEV_FLAG = New IntegerField("", Nothing)
    SCAFFOLD_COURSEDEV_FLAGItems = New ItemCollection()
    SCAFFOLD_COURSEDEV_UPDATED = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SUBJECT_TEACHER_STAFF_ID = New TextField("", Nothing)
    SUBJECT_TEACHER_SUBJECT_ID = New IntegerField("", Nothing)
    SURNAME = New MemoField("", Nothing)
    lblScaffoldLastUpdated = New DateField("d MMM yyyy h\:mm tt", Nothing)
    TotalRecords = New TextField("", Nothing)
    SCAFFOLD_COURSEDEV_MODIFIER = New TextField("", Nothing)
    SCAFFOLD_COURSEDEV_STARTDATE = New DateField("d\/M\/yyyy", Nothing)
    SCAFFOLD_COURSEDEV_ENDDATE = New DateField("d\/M\/yyyy", Nothing)
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
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    Return Me.SCAFFOLD_COURSEDEV_UPDATED
                Case "SUBJECT_TEACHER_STAFF_ID"
                    Return Me.SUBJECT_TEACHER_STAFF_ID
                Case "SUBJECT_TEACHER_SUBJECT_ID"
                    Return Me.SUBJECT_TEACHER_SUBJECT_ID
                Case "SURNAME"
                    Return Me.SURNAME
                Case "lblScaffoldLastUpdated"
                    Return Me.lblScaffoldLastUpdated
                Case "TotalRecords"
                    Return Me.TotalRecords
                Case "SCAFFOLD_COURSEDEV_MODIFIER"
                    Return Me.SCAFFOLD_COURSEDEV_MODIFIER
                Case "SCAFFOLD_COURSEDEV_STARTDATE"
                    Return Me.SCAFFOLD_COURSEDEV_STARTDATE
                Case "SCAFFOLD_COURSEDEV_ENDDATE"
                    Return Me.SCAFFOLD_COURSEDEV_ENDDATE
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
                Case "SCAFFOLD_COURSEDEV_UPDATED"
                    Me.SCAFFOLD_COURSEDEV_UPDATED = CType(Value,DateField)
                Case "SUBJECT_TEACHER_STAFF_ID"
                    Me.SUBJECT_TEACHER_STAFF_ID = CType(Value,TextField)
                Case "SUBJECT_TEACHER_SUBJECT_ID"
                    Me.SUBJECT_TEACHER_SUBJECT_ID = CType(Value,IntegerField)
                Case "SURNAME"
                    Me.SURNAME = CType(Value,MemoField)
                Case "lblScaffoldLastUpdated"
                    Me.lblScaffoldLastUpdated = CType(Value,DateField)
                Case "TotalRecords"
                    Me.TotalRecords = CType(Value,TextField)
                Case "SCAFFOLD_COURSEDEV_MODIFIER"
                    Me.SCAFFOLD_COURSEDEV_MODIFIER = CType(Value,TextField)
                Case "SCAFFOLD_COURSEDEV_STARTDATE"
                    Me.SCAFFOLD_COURSEDEV_STARTDATE = CType(Value,DateField)
                Case "SCAFFOLD_COURSEDEV_ENDDATE"
                    Me.SCAFFOLD_COURSEDEV_ENDDATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public ReadOnly Property IsDeleteAllowed As Boolean
        Get
            Return  Not(IsEmptyItem) AndAlso _deleteAllowed
        End Get
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
            result = IsNothing(SCAFFOLD_COURSEDEV_FLAG.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_UPDATED.Value) And result
            result = IsNothing(SUBJECT_TEACHER_STAFF_ID.Value) And result
            result = IsNothing(SUBJECT_TEACHER_SUBJECT_ID.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_MODIFIER.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_STARTDATE.Value) And result
            result = IsNothing(SCAFFOLD_COURSEDEV_ENDDATE.Value) And result
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

'SCAFFOLD_COURSEDEV_FLAG validate @35-CD256747
        If IsNothing(SCAFFOLD_COURSEDEV_FLAG.Value) OrElse SCAFFOLD_COURSEDEV_FLAG.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_FLAG",String.Format(Resources.strings.CCS_RequiredField,"SCAFFOLD COURSE DEV?"))
        End If
'End SCAFFOLD_COURSEDEV_FLAG validate

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

'SCAFFOLD_COURSEDEV_STARTDATE validate @294-1A6545CE
        If IsNothing(SCAFFOLD_COURSEDEV_STARTDATE.Value) OrElse SCAFFOLD_COURSEDEV_STARTDATE.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_STARTDATE",String.Format(Resources.strings.CCS_RequiredField,"Date From"))
        End If
'End SCAFFOLD_COURSEDEV_STARTDATE validate

'SCAFFOLD_COURSEDEV_ENDDATE validate @296-C0A114A8
        If IsNothing(SCAFFOLD_COURSEDEV_ENDDATE.Value) OrElse SCAFFOLD_COURSEDEV_ENDDATE.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_ENDDATE",String.Format(Resources.strings.CCS_RequiredField,"Date To"))
        End If
'End SCAFFOLD_COURSEDEV_ENDDATE validate

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

'Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Variables @3-48CBA198

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
    Public RecordsPerPage As Integer = 80
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
    Public Urls_SUBJECT_ID  As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_FLAG  As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_UPDATED  As DateParameter
    Public CtrlSUBJECT_TEACHER_STAFF_ID  As TextParameter
    Public CtrlSUBJECT_TEACHER_SUBJECT_ID  As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_STARTDATE  As DateParameter
    Public CtrlSCAFFOLD_COURSEDEV_ENDDATE  As DateParameter
    Public Expr328  As TextParameter
    Public CtrlSCAFFOLD_COURSEDEV_MODIFIER  As TextParameter
'End Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Variables

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Constructor @3-415D652F

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SCAFFOLD_COURSEDEV_FLAG, SUBJECT_ABBREV, " & vbCrLf & _
          "SUBJECT_TITLE, rtrim(FIRSTNAME) AS FIRSTNAME, rtrim(SURNAME) AS SURNAME, " & vbCrLf & _
          "SCAFFOLD_COURSEDEV_UPDATED," & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID AS SUBJECT_ID, " & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID AS STAFF_ID, SCAFFOLD_COURSEDEV_STARTDATE, " & vbCrLf & _
          "SCAFFOLD_COURSEDEV_ENDDATE," & vbCrLf & _
          "SCAFFOLD_COURSEDEV_MODIFIER " & vbCrLf & _
          "FROM (SUBJECT_TEACHER INNER JOIN SUBJECT ON" & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN STAFF ON" & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID = STAFF.STAFF_ID {SQL_Where} {SQL_OrderBy}", New String(){"(","s_keyword303","Or","s_keyword304","Or","s_keyword305","Or","s_keyword306","Or","s_keyword307",")","Or","s_SUBJECT_ID308"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM (SUBJECT_TEACHER INNER JOIN SUBJECT ON" & vbCrLf & _
          "SUBJECT_TEACHER.SUBJECT_ID = SUBJECT.SUBJECT_ID) INNER JOIN STAFF ON" & vbCrLf & _
          "SUBJECT_TEACHER.STAFF_ID = STAFF.STAFF_ID", New String(){"(","s_keyword303","Or","s_keyword304","Or","s_keyword305","Or","s_keyword306","Or","s_keyword307",")","Or","s_SUBJECT_ID308"},Settings.connDECVPRODSQL2005DataAccessObject , true)
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

'EditableGrid SUBJECT_TEACHER_SUBJECT_S BeforeBuildUpdate @3-6DA9A230
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("STAFF_ID204",item.STAFF_IDField, "","STAFF_ID",Condition.Equal,False)
        CType(Update,TableCommand).AddParameter("SUBJECT_ID205",item.SUBJECT_IDField, "","SUBJECT_ID",Condition.Equal,False)
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_FLAG.IsEmpty And allEmptyFlag
        If IsNothing(item.SCAFFOLD_COURSEDEV_FLAG.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_FLAG=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_FLAG=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_FLAG.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_UPDATED.IsEmpty And allEmptyFlag
        If IsNothing(item.SCAFFOLD_COURSEDEV_UPDATED.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_UPDATED=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_UPDATED=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_UPDATED.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
        End If
        allEmptyFlag = item.SUBJECT_TEACHER_STAFF_ID.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TEACHER_STAFF_ID.IsEmpty Then
        If IsNothing(item.SUBJECT_TEACHER_STAFF_ID.Value) Then
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "STAFF_ID=" & Update.Dao.ToSql(item.SUBJECT_TEACHER_STAFF_ID.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SUBJECT_TEACHER_SUBJECT_ID.IsEmpty And allEmptyFlag
        If Not item.SUBJECT_TEACHER_SUBJECT_ID.IsEmpty Then
        If IsNothing(item.SUBJECT_TEACHER_SUBJECT_ID.Value) Then
        valuesList = valuesList & "SUBJECT_ID=" & Update.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        valuesList = valuesList & "SUBJECT_ID=" & Update.Dao.ToSql(item.SUBJECT_TEACHER_SUBJECT_ID.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_STARTDATE.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_STARTDATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_STARTDATE=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_STARTDATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_ENDDATE.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_ENDDATE=" & Update.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_ENDDATE=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_ENDDATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = (Expr328 Is Nothing) And allEmptyFlag
        If Not (Expr328 Is Nothing) Then
        If IsNothing(Expr328) Then
        valuesList = valuesList & "SCAFFOLD_COURSDEV_UPDATED_BY=" & Update.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSDEV_UPDATED_BY=" & Update.Dao.ToSql(Expr328.GetFormattedValue(""),FieldType._Text) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_MODIFIER.Value) Then
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_MODIFIER=" & Update.Dao.ToSql(("").ToString(),FieldType._Text) & ","
        Else
        valuesList = valuesList & "SCAFFOLD_COURSEDEV_MODIFIER=" & Update.Dao.ToSql(item.SCAFFOLD_COURSEDEV_MODIFIER.GetFormattedValue(""),FieldType._Text) & ","
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

'Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method @3-603A5A77
    Public Sub Update(Items As ArrayList, ops As FormSupportedOperations)
        Dim i As Integer
        For i = 0 To Items.Count - 1
            Dim op As EditableGridOperation = EditableGridOperation.Insert
            Dim isProcessed As Boolean = False
            Dim item As SUBJECT_TEACHER_SUBJECT_SItem = CType(Items(i), SUBJECT_TEACHER_SUBJECT_SItem)
'End Grid SUBJECT_TEACHER_SUBJECT_S Data Provider Class GetResultSet Method

'EditableGrid SUBJECT_TEACHER_SUBJECT_S Data Provider Class Update @3-B4FF46D4
            If Not item.IsUpdated Then
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

'Before build Select @3-BAADD026
        _pagesCount = 0
        Dim E as Exception = Nothing
        Dim j As Integer
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword303",Urls_keyword, "","SUBJECT_TEACHER.STAFF_ID",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword304",Urls_keyword, "","SUBJECT.SUBJECT_ABBREV",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword305",Urls_keyword, "","SUBJECT.SUBJECT_TITLE",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword306",Urls_keyword, "","SURNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_keyword307",Urls_keyword, "","FIRSTNAME",Condition.Contains,False)
        CType(Select_,TableCommand).AddParameter("s_SUBJECT_ID308",Urls_SUBJECT_ID, "","SUBJECT_TEACHER.SUBJECT_ID",Condition.Equal,False)
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

'ListBox SCAFFOLD_COURSEDEV_FLAG AfterExecuteSelect @35-F89575F1
    Dim SCAFFOLD_COURSEDEV_FLAGItems As ItemCollection = New ItemCollection()
    
SCAFFOLD_COURSEDEV_FLAGItems.Add("0","No")
SCAFFOLD_COURSEDEV_FLAGItems.Add("1","Yes")
'End ListBox SCAFFOLD_COURSEDEV_FLAG AfterExecuteSelect

'After execute Select tail @3-A8EF5ABC
        Dim i as Integer
        For i = 0 To rowCount - 1
            Dim item as SUBJECT_TEACHER_SUBJECT_SItem = New SUBJECT_TEACHER_SUBJECT_SItem()
            item.SUBJECT_ABBREV.SetValue(dr(i)("SUBJECT_ABBREV"),"")
            item.SUBJECT_TITLE.SetValue(dr(i)("SUBJECT_TITLE"),"")
            item.FIRSTNAME.SetValue(dr(i)("FIRSTNAME"),"")
            item.SCAFFOLD_COURSEDEV_FLAG.SetValue(dr(i)("SCAFFOLD_COURSEDEV_FLAG"),"")
            item.SCAFFOLD_COURSEDEV_FLAGItems = CType(SCAFFOLD_COURSEDEV_FLAGItems.Clone(), ItemCollection)
            item.SCAFFOLD_COURSEDEV_UPDATED.SetValue(dr(i)("SCAFFOLD_COURSEDEV_UPDATED"),"yyyy-MM-dd HH\:mm\:ss")
            item.SUBJECT_TEACHER_STAFF_ID.SetValue(dr(i)("STAFF_ID"),"")
            item.SUBJECT_TEACHER_SUBJECT_ID.SetValue(dr(i)("SUBJECT_ID"),"")
            item.SURNAME.SetValue(dr(i)("SURNAME"),"")
            item.lblScaffoldLastUpdated.SetValue(dr(i)("SCAFFOLD_COURSEDEV_UPDATED"),Select_.DateFormat)
            item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(dr(i)("SCAFFOLD_COURSEDEV_MODIFIER"),"")
            item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(dr(i)("SCAFFOLD_COURSEDEV_STARTDATE"),Select_.DateFormat)
            item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(dr(i)("SCAFFOLD_COURSEDEV_ENDDATE"),Select_.DateFormat)
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

'Record SUBJECT_SUBJECT_TEACHER Item Class @40-9BDCD6B5
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
    Public Sub New()
    ClearParameters = New TextField("",Nothing)
    ClearParametersHrefParameters = New LinkParameterCollection()
    s_keyword = New TextField("", Nothing)
    s_SUBJECT_ID = New IntegerField("", Nothing)
    s_SUBJECT_IDItems = New ItemCollection()
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
        If Not IsNothing(DBUtility.GetInitialValue("ButtonResetDevToTeachers")) Then
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

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Constructor @40-CC5A9984

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT_TEACHER {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Update=new SqlCommand("UPDATE SUBJECT_TEACHER " & vbCrLf & _
          "SET SCAFFOLD_COURSEDEV_FLAG = ALLOCATABLE_FLAG " & vbCrLf & _
          ", SCAFFOLD_COURSEDEV_UPDATED = GETDATE() ",Settings.connDECVPRODSQL2005DataAccessObject)
        Delete=new SqlCommand("UPDATE SUBJECT_TEACHER " & vbCrLf & _
          "SET SCAFFOLD_COURSEDEV_FLAG = 0 " & vbCrLf & _
          ", SCAFFOLD_COURSEDEV_UPDATED = GETDATE() " & vbCrLf & _
          "WHERE SCAFFOLD_COURSEDEV_FLAG = 1 ",Settings.connDECVPRODSQL2005DataAccessObject)
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

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareUpdate Method @40-0A131024

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareUpdate Method

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareUpdate Method tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class PrepareUpdate Method tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class Update Method @40-6F26A0E2

    Public Function UpdateItem(ByVal item As SUBJECT_SUBJECT_TEACHERItem) As Integer
        Me.item = item
'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class Update Method

'Record SUBJECT_SUBJECT_TEACHER BeforeBuildUpdate @40-AD037AB7
        Update.Parameters.Clear()
        Dim result As Object = 0
        Dim E As Exception = Nothing
        Try
            result = ExecuteUpdate()
        Catch ee As Exception
            E = ee
        Finally
            If Not IsParametersPassed Then
                Throw New Exception(Resources.strings.CCS_CustomOperationError_MissingParameters)
            End If
'End Record SUBJECT_SUBJECT_TEACHER BeforeBuildUpdate

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteUpdate @40-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteUpdate

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

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect @40-A7328E8E
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.ClearParametersHref = "Subject_CourseDev_maint.aspx"
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

'Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail @40-E31F8E2A
    End Sub
'End Record SUBJECT_SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_SUBJECT_TEACHER Data Provider Class @40-A61BA892
End Class

'End Record SUBJECT_SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Item Class @93-0A7C9AFA
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
    Public SCAFFOLD_COURSEDEV_STARTDATE As DateField
    Public SCAFFOLD_COURSEDEV_MODIFIER As TextField
    Public SCAFFOLD_COURSEDEV_ENDDATE As DateField
    Public Sub New()
    SUBJECT_ID = New IntegerField("", Nothing)
    SUBJECT_IDItems = New ItemCollection()
    STAFF_ID = New TextField("", Nothing)
    STAFF_IDItems = New ItemCollection()
    SCAFFOLD_COURSEDEV_UPDATED = New DateField("dd\/MM\/yyyy h\:mm tt", DateTime.Now)
    SCAFFOLD_COURSEDEV_FLAG = New IntegerField("", 1)
    SCAFFOLD_COURSEDEV_STARTDATE = New DateField("d\/M\/yyyy", DateTime.Now)
    SCAFFOLD_COURSEDEV_MODIFIER = New TextField("", Nothing)
    SCAFFOLD_COURSEDEV_ENDDATE = New DateField("d\/M\/yyyy", Nothing)
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
        If Not IsNothing(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_STARTDATE")) Then
        item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_STARTDATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_StartDate")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_MODIFIER")) Then
        item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_MODIFIER"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_ENDDATE")) Then
        item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(DBUtility.GetInitialValue("SCAFFOLD_COURSEDEV_ENDDATE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("DatePicker_SCAFFOLD_COURSEDEV_ENDDATE")) Then
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
                Case "SCAFFOLD_COURSEDEV_STARTDATE"
                    Return SCAFFOLD_COURSEDEV_STARTDATE
                Case "SCAFFOLD_COURSEDEV_MODIFIER"
                    Return SCAFFOLD_COURSEDEV_MODIFIER
                Case "SCAFFOLD_COURSEDEV_ENDDATE"
                    Return SCAFFOLD_COURSEDEV_ENDDATE
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
                Case "SCAFFOLD_COURSEDEV_STARTDATE"
                    SCAFFOLD_COURSEDEV_STARTDATE = CType(value, DateField)
                Case "SCAFFOLD_COURSEDEV_MODIFIER"
                    SCAFFOLD_COURSEDEV_MODIFIER = CType(value, TextField)
                Case "SCAFFOLD_COURSEDEV_ENDDATE"
                    SCAFFOLD_COURSEDEV_ENDDATE = CType(value, DateField)
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

'SCAFFOLD_COURSEDEV_STARTDATE validate @330-1A6545CE
        If IsNothing(SCAFFOLD_COURSEDEV_STARTDATE.Value) OrElse SCAFFOLD_COURSEDEV_STARTDATE.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_STARTDATE",String.Format(Resources.strings.CCS_RequiredField,"Date From"))
        End If
'End SCAFFOLD_COURSEDEV_STARTDATE validate

'SCAFFOLD_COURSEDEV_ENDDATE validate @335-C0A114A8
        If IsNothing(SCAFFOLD_COURSEDEV_ENDDATE.Value) OrElse SCAFFOLD_COURSEDEV_ENDDATE.Value.ToString() ="" Then
            errors.Add("SCAFFOLD_COURSEDEV_ENDDATE",String.Format(Resources.strings.CCS_RequiredField,"Date To"))
        End If
'End SCAFFOLD_COURSEDEV_ENDDATE validate

'Record SUBJECT_TEACHER Item Class tail @93-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECT_TEACHER Item Class tail

'Record SUBJECT_TEACHER Data Provider Class @93-73BC2482
Public Class SUBJECT_TEACHERDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECT_TEACHER Data Provider Class

'Record SUBJECT_TEACHER Data Provider Class Variables @93-4AF0A936
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
    Public Expr202 As FloatParameter
    Public Expr203 As IntegerParameter
    Public CtrlSCAFFOLD_COURSEDEV_STARTDATE As DateParameter
    Public CtrlSCAFFOLD_COURSEDEV_ENDDATE As DateParameter
    Public CtrlSCAFFOLD_COURSEDEV_MODIFIER As TextParameter
    Protected item As SUBJECT_TEACHERItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECT_TEACHER Data Provider Class Variables

'Record SUBJECT_TEACHER Data Provider Class Constructor @93-D322BBE2

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM SUBJECT_TEACHER {SQL_Where} {SQL_OrderBy}", New String(){"SUBJECT_ID105"},Settings.connDECVPRODSQL2005DataAccessObject )
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

'Record SUBJECT_TEACHER Build insert @93-4375A2AB
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
        allEmptyFlag = (Expr202 Is Nothing) And allEmptyFlag
        If Not (Expr202 Is Nothing) Then
        If IsNothing(Expr202) Then
        fieldsList = fieldsList & "SUBJECT_TIMEFRACTION,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Float) & ","
        Else
        fieldsList = fieldsList & "SUBJECT_TIMEFRACTION,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr202.GetFormattedValue(""),FieldType._Float) & ","
        End If
        End If
        allEmptyFlag = (Expr203 Is Nothing) And allEmptyFlag
        If Not (Expr203 Is Nothing) Then
        If IsNothing(Expr203) Then
        fieldsList = fieldsList & "ALLOCATABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Integer) & ","
        Else
        fieldsList = fieldsList & "ALLOCATABLE_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(Expr203.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_STARTDATE.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_STARTDATE.Value) Then
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_STARTDATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_STARTDATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCAFFOLD_COURSEDEV_STARTDATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_ENDDATE.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_ENDDATE.Value) Then
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_ENDDATE,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Date) & ","
        Else
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_ENDDATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCAFFOLD_COURSEDEV_ENDDATE.GetFormattedValue("yyyy-MM-dd HH\:mm\:ss"),FieldType._Date) & ","
        End If
        End If
        allEmptyFlag = item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty And allEmptyFlag
        If Not item.SCAFFOLD_COURSEDEV_MODIFIER.IsEmpty Then
        If IsNothing(item.SCAFFOLD_COURSEDEV_MODIFIER.Value) Then
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_MODIFIER,"
        valuesList = valuesList & Insert.Dao.ToSql(Nothing,FieldType._Text) & ","
        Else
        fieldsList = fieldsList & "SCAFFOLD_COURSEDEV_MODIFIER,"
        valuesList = valuesList & Insert.Dao.ToSql(item.SCAFFOLD_COURSEDEV_MODIFIER.GetFormattedValue(""),FieldType._Text) & ","
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

'Record SUBJECT_TEACHER BeforeBuildSelect @93-D81E8CF6
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("SUBJECT_ID105",UrlSUBJECT_ID, "","SUBJECT_ID",Condition.Equal,False)
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

'Record SUBJECT_TEACHER AfterExecuteSelect @93-9BEA2892
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
            item.SCAFFOLD_COURSEDEV_STARTDATE.SetValue(dr(i)("SCAFFOLD_COURSEDEV_STARTDATE"),Select_.DateFormat)
            item.SCAFFOLD_COURSEDEV_MODIFIER.SetValue(dr(i)("SCAFFOLD_COURSEDEV_MODIFIER"),"")
            item.SCAFFOLD_COURSEDEV_ENDDATE.SetValue(dr(i)("SCAFFOLD_COURSEDEV_ENDDATE"),Select_.DateFormat)
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

'Record SUBJECT_TEACHER AfterExecuteSelect tail @93-E31F8E2A
    End Sub
'End Record SUBJECT_TEACHER AfterExecuteSelect tail

'Record SUBJECT_TEACHER Data Provider Class @93-A61BA892
End Class

'End Record SUBJECT_TEACHER Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

