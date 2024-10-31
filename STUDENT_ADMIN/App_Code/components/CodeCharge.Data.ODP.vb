'CodeCharge.Data.ODPDAO Class @0-D6F8149F
'Target Framework version is 3.5
Imports System
Imports System.Data
Imports System.Collections
#if ODP_INSTALLED
Imports Oracle.DataAccess.Client
Namespace DECV_PROD2007.Data
' <summary>
' Data Access Object for work with Oracle data providers.
' </summary>
Public NotInheritable Class ODPDao
Inherits DataAccessObject
    Private m_connection As OracleConnection
    Private Dim s_connection As ConnectionString
    Private aliases As OracleDbType() = New OracleDbType() {OracleDbType.Int64,OracleDbType.Byte,OracleDbType.Char,OracleDbType.Date, _
            OracleDbType.Date,OracleDbType.Decimal,OracleDbType.Double,OracleDbType.Int32,OracleDbType.Byte,OracleDbType.Int16, _
            OracleDbType.NChar,OracleDbType.NClob,OracleDbType.Int32,OracleDbType.NVarchar2,OracleDbType.Double,OracleDbType.Date, _
            OracleDbType.Clob,OracleDbType.Date,OracleDbType.Varchar2,OracleDbType.RefCursor}

    Public Sub New(ByVal connection As ConnectionString)
        MyBase.New(connection)
        Me.Connection = New OracleConnection(connection.Connection)
        s_connection = connection
    End Sub

    Public Property ConnectionString() As String
        Get
            Return Connection.ConnectionString
        End Get
        Set (ByVal Value As String)
            m_connection = New OracleConnection(Value)
        End Set
    End Property

    Public Property Connection() As OracleConnection
        Get
            Return m_connection
        End Get
        Set (ByVal Value As OracleConnection)
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
                Dim command As OracleCommand = New OracleCommand(s_connection.ConnectionCommands(sql),Connection)
                command.ExecuteNonQuery()
            Next
        End If
    End Sub

    Protected Overrides Function CheckConnectionImpl(ByVal login As String, ByVal password As String) As Boolean
        ConnectionString += ";User ID=""" & login & """;Password=""" & password & """"
        Try
            Connection.Open()
            Connection.Close()
        Catch
            Return False
        End Try
        Return True
    End Function

    Protected Overloads Overrides Function RunSqlImpl(ByVal sql As String) As DataSet
        Dim adapter As OracleDataAdapter = New OracleDataAdapter(sql,Connection)
        Dim dataSet As DataSet = New DataSet()
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        adapter.Fill(dataSet)
        adapter.Dispose()
        dataSet.Dispose()
        If Not flag Then Connection.Close()
        Return dataSet
    End Function

    Protected Overloads Overrides Function RunSqlImpl(ByVal sqlQuery As String,ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        Dim adapter As OracleDataAdapter = New OracleDataAdapter(sqlQuery,Connection)
        Dim dataSet As DataSet = New DataSet()
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        adapter.Fill(dataSet,startRecord,maxRecords,"Table")
        adapter.Dispose()
        dataSet.Dispose()
        If Not flag Then Connection.Close()
        Return dataSet
    End Function

    Protected Overrides Function ExecuteScalarImpl(ByVal sqlQuery As String) As Object
        Dim command As OracleCommand = New OracleCommand(sqlQuery,Connection)
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        Dim result As Object = command.ExecuteScalar()
        command.Dispose()
        If Not flag Then Connection.Close()
        Return result
    End Function

    Protected Overrides Function ExecuteNonQueryImpl(ByVal sqlQuery As String) As Integer
        Dim command As OracleCommand = New OracleCommand(sqlQuery,Connection)
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        Dim result As Integer = Convert.ToInt32(command.ExecuteNonQuery())
        If Not flag Then Connection.Close()
        command.Dispose()
        Return result
    End Function

    Private Function CreateCommand(ByVal sprocName As String, ByVal parameters As ParameterCollection) As OracleCommand
        Dim command As OracleCommand = New OracleCommand( sprocName, Connection )
        command.CommandType = CommandType.StoredProcedure
        Dim parameter As DictionaryEntry
        Dim i As Integer
        For i = 0 To parameters.Count - 1
            command.Parameters.Add(CType(parameters(i).Value, OracleParameter))
        Next i
        Return command
    End Function

    Protected Overrides Function GetSPParameterImpl(ByVal name As String, ByVal value As Object, ByVal parameterType As ParameterType, ByVal parameterDirection As ParameterDirection, ByVal size As Integer, ByVal scale As Byte,ByVal precision As Byte) As IDataParameter
        Dim p As OracleParameter = New OracleParameter(name,aliases(CType(parameterType,Integer)),size)
        p.Direction = parameterDirection
        if IsNothing(value) Then
            p.Value = DBNull.Value
        Else
            p.Value = value
        End If
        Return p
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Dim command As OracleCommand = CreateCommand( sprocName, parameters)
        command.Connection = Connection
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        command.ExecuteNonQuery()
        Dim parameter As OracleParameter
        For Each parameter In command.Parameters
            parameters(parameter.ParameterName) = parameter
        Next
        If Not flag Then Connection.Close()
        command.Dispose()
        Return 0
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, dataSet As DataSet) As Integer
        Call RunSPImpl(sprocName, parameters , dataSet, -1, 0)
        Return 0
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, dataSet As DataSet, ByVal startRecord As Integer, ByVal maxRecords As Integer) As Integer
        Dim dataSetAdapter As OracleDataAdapter = New OracleDataAdapter()
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
        Dim parameter As OracleParameter
        For Each parameter In dataSetAdapter.SelectCommand.Parameters
        parameters(parameter.ParameterName) = parameter
        Next
            If Not flag Then Connection.Close()
        Return 0
    End Function
End Class
End Namespace
#End If
'End CodeCharge.Data.ODPDAO Class

