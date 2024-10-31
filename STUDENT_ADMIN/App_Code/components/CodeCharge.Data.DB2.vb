'CodeCharge.Data.DB2DAO Class @0-8A8144E5
'Target Framework version is 3.5
Imports System
Imports System.Data
Imports System.Collections
#If DB2_INSTALLED = True Then
Imports IBM.Data.DB2
Namespace DECV_PROD2007.Data
' <summary>
' Data Access Object for work with DB2 data providers.
' </summary>
Public NotInheritable Class DB2Dao
Inherits DataAccessObject
    Private m_connection As DB2Connection
    Private Dim s_connection As ConnectionString
    Private aliases As DB2Type() = New DB2Type() {DB2Type.BigInt,DB2Type.SmallInt,DB2Type.Char,DB2Type.Date, _
            DB2Type.Date,DB2Type.Decimal,DB2Type.Double,DB2Type.Integer,DB2Type.SmallInt,DB2Type.SmallInt, _
            DB2Type.Graphic,DB2Type.Clob,DB2Type.Decimal,DB2Type.VarGraphic,DB2Type.Real,DB2Type.Timestamp, _
            DB2Type.Clob,DB2Type.Time,DB2Type.VarChar}

    Public Sub New(ByVal connection As ConnectionString)
        MyBase.New(connection)
        Me.Connection = New DB2Connection(connection.Connection)
        s_connection = connection
    End Sub

    Public Property ConnectionString() As String
        Get
            Return Connection.ConnectionString
        End Get
        Set (ByVal Value As String)
            m_connection = New DB2Connection(Value)
        End Set
    End Property

    Public Property Connection() As DB2Connection
        Get
            Return m_connection
        End Get
        Set (ByVal Value As DB2Connection)
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
                Dim command As DB2Command = New DB2Command(s_connection.ConnectionCommands(sql),Connection)
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
        Dim adapter As DB2DataAdapter = New DB2DataAdapter(sql,Connection)
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
        Dim adapter As DB2DataAdapter = New DB2DataAdapter(sqlQuery,Connection)
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
        Dim command As DB2Command = New DB2Command(sqlQuery,Connection)
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        Dim result As Object = command.ExecuteScalar()
        command.Connection.Close()
        command.Dispose()
        If Not flag Then Connection.Close()
        Return result
    End Function

    Protected Overrides Function ExecuteNonQueryImpl(ByVal sqlQuery As String) As Integer
        Dim command As DB2Command = New DB2Command(sqlQuery,Connection)
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        Dim result As Integer = Convert.ToInt32(command.ExecuteNonQuery())
        command.Connection.Close()
        command.Dispose()
        If Not flag Then Connection.Close()
        Return result
    End Function

    Private Function CreateCommand(ByVal sprocName As String, ByVal parameters As ParameterCollection) As DB2Command
        Dim command As DB2Command = New DB2Command( sprocName, Connection )
        command.CommandType = CommandType.StoredProcedure
        Dim i As Integer
        For i = 0 To parameters.Count - 1
            command.Parameters.Add(CType(parameters(i).Value, DB2Parameter))
        Next i
        Return command
    End Function

    Protected Overrides Function GetSPParameterImpl(ByVal name As String, ByVal value As Object, ByVal parameterType As ParameterType, ByVal parameterDirection As ParameterDirection, ByVal size As Integer, ByVal scale As Byte,ByVal precision As Byte) As IDataParameter
        Dim p As DB2Parameter = New DB2Parameter(name,aliases(CType(parameterType,Integer)),size)
        p.Direction = parameterDirection
        if IsNothing(value) Then
            p.Value = DBNull.Value
        Else
            p.Value = value
        End If
        Return p
    End Function

    Protected Overloads Overrides Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Dim command As DB2Command = CreateCommand( sprocName, parameters)
        command.Connection = Connection
        Dim flag As Boolean = False
        If Connection.State = ConnectionState.Open Then
            flag = True
        Else
            Connection.Open()
        End If
        command.ExecuteNonQuery()
        Dim parameter As DB2Parameter
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
        Dim dataSetAdapter As DB2DataAdapter = New DB2DataAdapter()
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
        Dim parameter As DB2Parameter
        For Each parameter In dataSetAdapter.SelectCommand.Parameters
        parameters(parameter.ParameterName) = parameter
        Next
            If Not flag Then Connection.Close()
        Return 0
    End Function
End Class
End Namespace
#End If
'End CodeCharge.Data.DB2DAO Class

