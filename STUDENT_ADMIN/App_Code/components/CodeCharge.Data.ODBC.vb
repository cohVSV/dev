'CodeCharge.Data.ODBC Class @0-30B3010E
'Target Framework version is 3.5
Option Strict On
Imports System
Imports System.Collections
Imports System.Data
Imports System.Data.Odbc
Namespace DECV_PROD2007.Data
' <summary>
' Data Access Object for work with ODBC data providers.
'   </summary>
Public NotInheritable Class OdbcDao
Inherits DataAccessObject
    Private Dim aliases As OdbcType() =new OdbcType() {OdbcType.BigInt,OdbcType.Bit,OdbcType.Char,OdbcType.Date, _
            OdbcType.DateTime,OdbcType.Decimal,OdbcType.Double,OdbcType.Int,OdbcType.TinyInt,OdbcType.SmallInt, _
            OdbcType.NChar,OdbcType.NText,OdbcType.Numeric,OdbcType.NVarChar,OdbcType.Real,OdbcType.SmallDateTime, _
            OdbcType.Text,OdbcType.Time,OdbcType.VarChar}

    Private Dim m_connection As OdbcConnection
    Private Dim s_connection As ConnectionString

    Public Sub New(ByVal connection As ConnectionString)
        MyBase.New(connection)
        Me.Connection=new OdbcConnection(connection.Connection) 
        s_connection=connection
    End Sub

    Public Property ConnectionString() As String
        Get
            Return Connection.ConnectionString
        End Get
        Set (ByVal Value As String)
            m_connection = New OdbcConnection(Value)
        End Set
    End Property

    Public Property Connection() As OdbcConnection
        Get
            Return m_connection
        End Get
        Set (ByVal Value As OdbcConnection)
            m_connection = Value
            AddHandler m_connection.StateChange, AddressOf OnStateChange
        End Set
    End Property

    Public Overrides Readonly Property NativeConnection() As IDbConnection
        Get
            Return m_connection
        End Get
    End Property

    Private Sub OnStateChange(sender As object , e As StateChangeEventArgs )
        If e.OriginalState = ConnectionState.Closed And e.CurrentState = ConnectionState.Open Then
            Dim sql As string
            For Each sql in s_connection.ConnectionCommands
                Dim command As OdbcCommand = New OdbcCommand(s_connection.ConnectionCommands(sql),Connection)
                command.ExecuteNonQuery()
            Next
        End If
    End Sub

    Protected Overrides Function CheckConnectionImpl(ByVal login As String,ByVal password As String) As Boolean
        ConnectionString = "UID=""" & login & """;PWD=""" & password & """;" & ConnectionString
        Try
            Call Connection.Open()
            Call Connection.Close()
        Catch
            Return False
        End Try
        Return True
    End Function

    Protected Overloads Overrides Function RunSqlImpl(ByVal sql As String) As DataSet
        Dim adapter As OdbcDataAdapter = New OdbcDataAdapter(sql,Connection)
        Dim dataSet As DataSet = New DataSet()
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Call adapter.Fill(dataSet)
        Call adapter.Dispose()
        Call dataSet.Dispose()
            If Not flag Then Connection.Close()
        Return dataSet
    End Function

    Protected Overloads Overrides Function RunSqlImpl(ByVal sqlQuery As String,ByVal startRecord As Integer,ByVal maxRecords As Integer) As DataSet
        Dim adapter As OdbcDataAdapter = New OdbcDataAdapter(sqlQuery,Connection)
        Dim dataSet As DataSet = New DataSet()
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Call adapter.Fill(dataSet,startRecord,maxRecords,"Table")
        Call adapter.Dispose()
        Call dataSet.Dispose()
            If Not flag Then Connection.Close()
        Return dataSet
    End Function

    Protected Overrides Function ExecuteNonQueryImpl(ByVal sqlQuery As String) As Integer
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Dim command As OdbcCommand = New OdbcCommand(sqlQuery,Connection)
        Dim result As Integer = Convert.ToInt32(command.ExecuteNonQuery())
            If Not flag Then Connection.Close()
        Call command.Dispose()
        Return result
    End Function

    Protected Overrides Function ExecuteScalarImpl(ByVal sqlQuery As String) As Object
        Dim command As OdbcCommand = New OdbcCommand(sqlQuery,Connection)
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Dim result As Object = command.ExecuteScalar()
            If Not flag Then Connection.Close()
        Call command.Dispose()
        Return result
    End Function

    Private Function CreateCommand(ByVal sprocName As String,ByVal parameters As ParameterCollection) As OdbcCommand
        Dim command As OdbcCommand = New OdbcCommand( sprocName, Connection )
        command.CommandType = CommandType.StoredProcedure
        Dim i As Integer
        For i = 0 To parameters.Count - 1
            command.Parameters.Add(CType(parameters(i).Value, OdbcParameter))
        Next i
        Return command
    End Function

    Protected Overrides Function GetSPParameterImpl(ByVal Name As String,ByVal Value As Object,ByVal paramType As ParameterType, ByVal Direction As ParameterDirection, ByVal Size As Integer, ByVal Scale As Byte,ByVal Precision As Byte) As IDataParameter
        If paramType = ParameterType._RecordSet Then Return Nothing
        Dim p As OdbcParameter = New OdbcParameter(Name,aliases(paramType),Size)
        p.Direction = Direction
        If IsNothing(Value) Then
            p.Value = DBNull.Value
        Else
            p.Value = Value
        End If
        Return p
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Dim command As OdbcCommand = CreateCommand( sprocName, parameters)
            command.Connection = Connection
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
            Call command.ExecuteNonQuery()
            Dim parameter As OdbcParameter
            For Each parameter In command.Parameters
                parameters(parameter.ParameterName) = parameter
            Next
            Call command.Connection.Close()
            Call command.Dispose()
            If Not flag Then Connection.Close()
            Return 0
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, dataSet As DataSet) As Integer
        Call RunSPImpl(sprocName, parameters , dataSet, -1, 0)
        Return 0
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, dataSet As DataSet, ByVal startRecord As Integer, ByVal maxRecords As Integer) As Integer
        Dim dataSetAdapter As OdbcDataAdapter = New OdbcDataAdapter()
        dataSetAdapter.SelectCommand = CreateCommand( sprocName, parameters )
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        If startRecord < 0 Then
        Call dataSetAdapter.Fill( dataSet, "SourceTable" )
        Else
        Call dataSetAdapter.Fill( dataSet, startRecord, maxRecords, "SourceTable" )
        End If
        Dim parameter As OdbcParameter
        For Each parameter In dataSetAdapter.SelectCommand.Parameters
        parameters(parameter.ParameterName) = parameter
        Next
            If Not flag Then Connection.Close()
        Return 0
    End Function
End Class
End Namespace
'End CodeCharge.Data.ODBC Class

