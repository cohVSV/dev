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

Namespace DECV_PROD2007.FTE_RULES_maint 'Namespace @1-5D46EE36

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

'Record FTE_RULES Item Class @2-26FF02C7
Public Class FTE_RULESItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public FROM_YEAR_LEVEL As IntegerField
    Public TO_YEAR_LEVEL As IntegerField
    Public FTE As FloatField
    Public FULLTIME_FLAG As BooleanField
    Public FULLTIME_FLAGCheckedValue As BooleanField
    Public FULLTIME_FLAGUncheckedValue As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Sub New()
    FROM_YEAR_LEVEL = New IntegerField("", Nothing)
    TO_YEAR_LEVEL = New IntegerField("", Nothing)
    FTE = New FloatField("", Nothing)
    FULLTIME_FLAG = New BooleanField(Settings.BoolFormat, False)
    FULLTIME_FLAGCheckedValue = New BooleanField(Settings.BoolFormat, True)
    FULLTIME_FLAGUncheckedValue = New BooleanField(Settings.BoolFormat, False)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As FTE_RULESItem
        Dim item As FTE_RULESItem = New FTE_RULESItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FROM_YEAR_LEVEL")) Then
        item.FROM_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("FROM_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("TO_YEAR_LEVEL")) Then
        item.TO_YEAR_LEVEL.SetValue(DBUtility.GetInitialValue("TO_YEAR_LEVEL"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FTE")) Then
        item.FTE.SetValue(DBUtility.GetInitialValue("FTE"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("FULLTIME_FLAG")) Then
        If Not IsNothing(System.Web.HttpContext.Current.Request("FULLTIME_FLAG")) Then
            item.FULLTIME_FLAG.Value = item.FULLTIME_FLAGCheckedValue.Value
        End If
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_BY")) Then
        item.LAST_ALTERED_BY.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_BY"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("LAST_ALTERED_DATE")) Then
        item.LAST_ALTERED_DATE.SetValue(DBUtility.GetInitialValue("LAST_ALTERED_DATE"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "FROM_YEAR_LEVEL"
                    Return FROM_YEAR_LEVEL
                Case "TO_YEAR_LEVEL"
                    Return TO_YEAR_LEVEL
                Case "FTE"
                    Return FTE
                Case "FULLTIME_FLAG"
                    Return FULLTIME_FLAG
                Case "LAST_ALTERED_BY"
                    Return LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return LAST_ALTERED_DATE
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "FROM_YEAR_LEVEL"
                    FROM_YEAR_LEVEL = CType(value, IntegerField)
                Case "TO_YEAR_LEVEL"
                    TO_YEAR_LEVEL = CType(value, IntegerField)
                Case "FTE"
                    FTE = CType(value, FloatField)
                Case "FULLTIME_FLAG"
                    FULLTIME_FLAG = CType(value, BooleanField)
                Case "LAST_ALTERED_BY"
                    LAST_ALTERED_BY = CType(value, TextField)
                Case "LAST_ALTERED_DATE"
                    LAST_ALTERED_DATE = CType(value, DateField)
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

    Public Sub Validate(ByVal provider As FTE_RULESDataProvider)
'End Record FTE_RULES Item Class

'FROM_YEAR_LEVEL validate @7-DBECF43B
        If IsNothing(FROM_YEAR_LEVEL.Value) OrElse FROM_YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("FROM_YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"FROM YEAR LEVEL"))
        End If
'End FROM_YEAR_LEVEL validate

'TO_YEAR_LEVEL validate @8-5E29939C
        If IsNothing(TO_YEAR_LEVEL.Value) OrElse TO_YEAR_LEVEL.Value.ToString() ="" Then
            errors.Add("TO_YEAR_LEVEL",String.Format(Resources.strings.CCS_RequiredField,"TO YEAR LEVEL"))
        End If
'End TO_YEAR_LEVEL validate

'FTE validate @9-EE62D452
        If IsNothing(FTE.Value) OrElse FTE.Value.ToString() ="" Then
            errors.Add("FTE",String.Format(Resources.strings.CCS_RequiredField,"FTE"))
        End If
'End FTE validate

'FULLTIME_FLAG validate @10-D202FE06
        If IsNothing(FULLTIME_FLAG.Value) OrElse FULLTIME_FLAG.Value.ToString() ="" Then
            errors.Add("FULLTIME_FLAG",String.Format(Resources.strings.CCS_RequiredField,"FULLTIME FLAG"))
        End If
'End FULLTIME_FLAG validate

'LAST_ALTERED_BY validate @11-256A6854
        If IsNothing(LAST_ALTERED_BY.Value) OrElse LAST_ALTERED_BY.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_BY",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED BY"))
        End If
'End LAST_ALTERED_BY validate

'LAST_ALTERED_DATE validate @12-C5989D76
        If IsNothing(LAST_ALTERED_DATE.Value) OrElse LAST_ALTERED_DATE.Value.ToString() ="" Then
            errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_RequiredField,"LAST ALTERED DATE"))
        End If
'End LAST_ALTERED_DATE validate

'Record FTE_RULES Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record FTE_RULES Item Class tail

'Record FTE_RULES Data Provider Class @2-2A972342
Public Class FTE_RULESDataProvider
Inherits RecordDataProviderBase
'End Record FTE_RULES Data Provider Class

'Record FTE_RULES Data Provider Class Variables @2-5EE73CA9
    Public UrlUNIT As IntegerParameter
    Protected item As FTE_RULESItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record FTE_RULES Data Provider Class Variables

'Record FTE_RULES Data Provider Class Constructor @2-F35B1E96

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM FTE_RULES {SQL_Where} {SQL_OrderBy}", New String(){"UNIT6"},Settings.connDECVPRODSQL2005DataAccessObject )
        Delete=new TableCommand("DELETE FROM FTE_RULES", New String(){"UNIT6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record FTE_RULES Data Provider Class Constructor

'Record FTE_RULES Data Provider Class LoadParams Method @2-520265AF

    Protected Function LoadParams() As Boolean
        Return Not (IsNothing(UrlUNIT))
    End Function
'End Record FTE_RULES Data Provider Class LoadParams Method

'Record FTE_RULES Data Provider Class CheckUnique Method @2-E97CC368

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As FTE_RULESItem) As Boolean
        Return True
    End Function
'End Record FTE_RULES Data Provider Class CheckUnique Method

'Record FTE_RULES Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record FTE_RULES Data Provider Class PrepareInsert Method

'Record FTE_RULES Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record FTE_RULES Data Provider Class PrepareInsert Method tail

'Record FTE_RULES Data Provider Class Insert Method @2-56A70BD9

    Public Function InsertItem(ByVal item As FTE_RULESItem) As Integer
        Me.item = item
        Insert=new TableCommand("INSERT INTO FTE_RULES({Fields}) VALUES ({Values})", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record FTE_RULES Data Provider Class Insert Method

'Record FTE_RULES Build insert @2-DA7E1CA2
		Dim fieldsList As String = ""
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Insert.Parameters.Clear()
        If Not item.FROM_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.FROM_YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FROM_YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.TO_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.TO_YEAR_LEVEL.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "TO_YEAR_LEVEL,"
        valuesList = valuesList & Insert.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.FTE.IsEmpty Then
        allEmptyFlag = item.FTE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FTE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FTE.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.FULLTIME_FLAG.IsEmpty Then
        allEmptyFlag = item.FULLTIME_FLAG.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "FULLTIME_FLAG,"
        valuesList = valuesList & Insert.Dao.ToSql(item.FULLTIME_FLAG.GetFormattedValue(Insert.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_BY,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        fieldsList = fieldsList & "LAST_ALTERED_DATE,"
        valuesList = valuesList & Insert.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Insert.DateFormat),FieldType._Date) & ","
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
'End Record FTE_RULES Build insert

'Record FTE_RULES AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record FTE_RULES AfterExecuteInsert

'Record FTE_RULES Data Provider Class PrepareUpdate Method @2-2218F8D7

    Protected Overrides Sub PrepareUpdate()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record FTE_RULES Data Provider Class PrepareUpdate Method

'Record FTE_RULES Data Provider Class PrepareUpdate Method tail @2-E31F8E2A
    End Sub
'End Record FTE_RULES Data Provider Class PrepareUpdate Method tail

'Record FTE_RULES Data Provider Class Update Method @2-531316C0

    Public Function UpdateItem(ByVal item As FTE_RULESItem) As Integer
        Me.item = item
        Update=new TableCommand("UPDATE FTE_RULES SET {Values}", New String(){"UNIT6"},Settings.connDECVPRODSQL2005DataAccessObject , true)
'End Record FTE_RULES Data Provider Class Update Method

'Record FTE_RULES BeforeBuildUpdate @2-E9F82298
		Dim valuesList As String = ""
		Dim allEmptyFlag As Boolean= True
		
        Update.Parameters.Clear()
        CType(Update,TableCommand).AddParameter("UNIT6",UrlUNIT, "","UNIT",Condition.Equal,False)
        If Not item.FROM_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.FROM_YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FROM_YEAR_LEVEL=" + Update.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.TO_YEAR_LEVEL.IsEmpty Then
        allEmptyFlag = item.TO_YEAR_LEVEL.IsEmpty And allEmptyFlag
        valuesList = valuesList & "TO_YEAR_LEVEL=" + Update.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer) & ","
        End If
        If Not item.FTE.IsEmpty Then
        allEmptyFlag = item.FTE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FTE=" + Update.Dao.ToSql(item.FTE.GetFormattedValue(""),FieldType._Float) & ","
        End If
        If Not item.FULLTIME_FLAG.IsEmpty Then
        allEmptyFlag = item.FULLTIME_FLAG.IsEmpty And allEmptyFlag
        valuesList = valuesList & "FULLTIME_FLAG=" + Update.Dao.ToSql(item.FULLTIME_FLAG.GetFormattedValue(Update.BoolFormat),FieldType._Boolean) & ","
        End If
        If Not item.LAST_ALTERED_BY.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_BY.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_BY=" + Update.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text) & ","
        End If
        If Not item.LAST_ALTERED_DATE.IsEmpty Then
        allEmptyFlag = item.LAST_ALTERED_DATE.IsEmpty And allEmptyFlag
        valuesList = valuesList & "LAST_ALTERED_DATE=" + Update.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Update.DateFormat),FieldType._Date) & ","
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
'End Record FTE_RULES BeforeBuildUpdate

'Record FTE_RULES AfterExecuteUpdate @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record FTE_RULES AfterExecuteUpdate

'Record FTE_RULES Data Provider Class PrepareDelete Method @2-F7361E57

    Protected Overrides Sub PrepareDelete()
        CmdExecution = True
        IsParametersPassed = LoadParams()
'End Record FTE_RULES Data Provider Class PrepareDelete Method

'Record FTE_RULES Data Provider Class PrepareDelete Method tail @2-E31F8E2A
    End Sub
'End Record FTE_RULES Data Provider Class PrepareDelete Method tail

'Record FTE_RULES Data Provider Class Delete Method @2-4B0EDEFC
    Public Function DeleteItem(ByVal item As FTE_RULESItem) As Integer
        Me.item = item
'End Record FTE_RULES Data Provider Class Delete Method

'Record FTE_RULES BeforeBuildDelete @2-E0671F02
        Delete.Parameters.Clear()
        CType(Delete,TableCommand).AddParameter("UNIT6",UrlUNIT, "","UNIT",Condition.Equal,False)
        Delete.SqlQuery.Replace("{FROM_YEAR_LEVEL}",Delete.Dao.ToSql(item.FROM_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{TO_YEAR_LEVEL}",Delete.Dao.ToSql(item.TO_YEAR_LEVEL.GetFormattedValue(""),FieldType._Integer))
        Delete.SqlQuery.Replace("{FTE}",Delete.Dao.ToSql(item.FTE.GetFormattedValue(""),FieldType._Float))
        Delete.SqlQuery.Replace("{FULLTIME_FLAG}",Delete.Dao.ToSql(item.FULLTIME_FLAG.GetFormattedValue(Delete.BoolFormat),FieldType._Boolean))
        Delete.SqlQuery.Replace("{LAST_ALTERED_BY}",Delete.Dao.ToSql(item.LAST_ALTERED_BY.GetFormattedValue(""),FieldType._Text))
        Delete.SqlQuery.Replace("{LAST_ALTERED_DATE}",Delete.Dao.ToSql(item.LAST_ALTERED_DATE.GetFormattedValue(Delete.DateFormat),FieldType._Date))
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
'End Record FTE_RULES BeforeBuildDelete

'Record FTE_RULES BeforeBuildDelete @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record FTE_RULES BeforeBuildDelete

'Record FTE_RULES Data Provider Class GetResultSet Method @2-48A1AB42

    Public Sub FillItem(ByVal item As FTE_RULESItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record FTE_RULES Data Provider Class GetResultSet Method

'Record FTE_RULES BeforeBuildSelect @2-14F5A7E2
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("UNIT6",UrlUNIT, "","UNIT",Condition.Equal,False)
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record FTE_RULES BeforeBuildSelect

'Record FTE_RULES BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record FTE_RULES BeforeExecuteSelect

'Record FTE_RULES AfterExecuteSelect @2-98CB0751
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
            item.FROM_YEAR_LEVEL.SetValue(dr(i)("FROM_YEAR_LEVEL"),"")
            item.TO_YEAR_LEVEL.SetValue(dr(i)("TO_YEAR_LEVEL"),"")
            item.FTE.SetValue(dr(i)("FTE"),"")
            item.FULLTIME_FLAG.SetValue(dr(i)("FULLTIME_FLAG"),Select_.BoolFormat)
            item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
            item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
        Else
            IsInsertMode = True
        End If
'End Record FTE_RULES AfterExecuteSelect

'Record FTE_RULES AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record FTE_RULES AfterExecuteSelect tail

'Record FTE_RULES Data Provider Class @2-A61BA892
End Class

'End Record FTE_RULES Data Provider Class

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

