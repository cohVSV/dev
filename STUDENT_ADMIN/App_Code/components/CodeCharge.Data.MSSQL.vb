'CodeCharge.Data.SqlDAO Class @0-B0A7466E
'Target Framework version is 3.5
Imports System
Imports System.Data
Imports System.Data.SqlClient 
Imports System.Data.SqlTypes 
Imports System.Collections
Namespace DECV_PROD2007.Data
''' <summary>
''' Data Access Object for work with SQL server.
''' </summary>

Public NotInheritable Class SqlDao
Inherits DataAccessObject
    Private aliases As SqlDbType() = New SqlDbType() {SqlDbType.BigInt,SqlDbType.Bit,SqlDbType.Char,SqlDbType.DateTime, _
            SqlDbType.DateTime,SqlDbType.Decimal,SqlDbType.Float,SqlDbType.Int,SqlDbType.TinyInt,SqlDbType.SmallInt, _
            SqlDbType.NChar,SqlDbType.NText,SqlDbType.Decimal,SqlDbType.NVarChar,SqlDbType.Real,SqlDbType.SmallDateTime, _
            SqlDbType.Text,SqlDbType.DateTime,SqlDbType.VarChar}
    Private m_connection As SqlConnection
    Private Dim s_connection As ConnectionString

    Public Sub New(ByVal connStr As ConnectionString)
        MyBase.New(connStr)
        Me.Connection = New SqlConnection(connStr.Connection)
        s_connection = connStr
    End Sub

    Public Property ConnectionString() As String
        Get
            Return Connection.ConnectionString
        End Get
        Set (ByVal Value As String)
            Connection = New SqlConnection(Value)
        End Set
    End Property

    Public Property Connection() As SqlConnection
        Get
            Return m_connection
        End Get
        Set (ByVal Value As SqlConnection)
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
                Dim command As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(s_connection.ConnectionCommands(sql),Connection)
                command.ExecuteNonQuery()
            Next
        End If
    End Sub

    Protected Overrides Function CheckConnectionImpl(ByVal login As String,ByVal password As String) As Boolean
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
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql,Connection)
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

    Protected Overloads Overrides Function RunSqlImpl(ByVal sqlQuery As String,ByVal startRecord As Integer,ByVal maxRecords As Integer) As DataSet
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(sqlQuery,Connection)
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

    Protected Overrides Function ExecuteNonQueryImpl(ByVal sqlQuery As String) As Integer
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Dim command As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(sqlQuery,Connection)
        Dim result As Integer = Convert.ToInt32(command.ExecuteNonQuery())
            If Not flag Then Connection.Close()
        command.Dispose()
        Return result
    End Function

    Protected Overrides Function ExecuteScalarImpl(ByVal sqlQuery As String) As Object
        Dim command As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(sqlQuery,Connection)
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
        Dim result As Object = command.ExecuteScalar()
           If Not flag Then Connection.Close()
        command.Dispose()
        Return result
    End Function

    Private Function CreateCommand(ByVal sprocName As String,ByVal parameters As ParameterCollection) As System.Data.SqlClient.SqlCommand
        Dim command As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand( sprocName, Connection )
        command.CommandType = CommandType.StoredProcedure
        Dim i As Integer
        For i = 0 To parameters.Count - 1
            command.Parameters.Add(CType(parameters(i).Value, SqlParameter))
        Next i
        Return command
    End Function

    Protected Overrides Function GetSPParameterImpl(ByVal name As String,ByVal value As Object,ByVal paramType As ParameterType, ByVal parameterDirection As ParameterDirection, ByVal size As Integer, ByVal scale As Byte,ByVal precision As Byte) As IDataParameter
        If paramType = ParameterType._RecordSet Then Return Nothing
        Dim p As SqlParameter = New SqlParameter(name,aliases(CType(paramType,Integer)),size)
        p.Direction = parameterDirection
        If IsNothing(value) Then
            p.Value = DBNull.Value
        Else
            p.Value = value
        End If
        Return p
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Dim command As System.Data.SqlClient.SqlCommand = CreateCommand(sprocName, parameters)
            command.Connection = Connection
            Dim flag As Boolean = False
            If Connection.State = ConnectionState.Open Then
                flag = True
            Else
                Connection.Open()
            End If
            command.ExecuteNonQuery()
            Dim parameter As SqlParameter
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
        Dim dataSetAdapter As SqlDataAdapter = New SqlDataAdapter()
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
        Dim parameter As SqlParameter
        For Each parameter In dataSetAdapter.SelectCommand.Parameters
        parameters(parameter.ParameterName) = parameter
        Next
            If Not flag Then Connection.Close()
        Return 0
    End Function
End Class
End Namespace
'End CodeCharge.Data.SqlDAO Class

