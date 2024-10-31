'CodeCharge.Data.DataAccessObject Class @0-A2F356C8
'Target Framework version is 3.5
Imports System
Imports System.Data
Imports System.Collections
Namespace DECV_PROD2007.Data
Public Class DataAccessObject
    Implements IDisposable
    Protected Dim _server As String = ""
    Public Dim _optimized As Boolean = False
    Protected Dim _dateFormat As String = ""
    Protected Dim _boolFormat As String = ""
    Protected Dim DateLeftDelim As String = ""
    Protected Dim DateRightDelim As String = ""

    Public Property DateFormat() As String
        Get
            Return _dateFormat
        End Get
        Set (ByVal Value As String)
            _dateFormat = Value
        End Set
    End Property

    Public Property BoolFormat() As String
        Get
            Return _boolFormat
        End Get
        Set (ByVal Value As String)
            _boolFormat = Value
        End Set
    End Property

    Public Readonly Overridable Property NativeConnection() As IDbConnection
        Get
            Return Nothing
        End Get
    End Property

    Public Sub New
    End Sub

    Public Overridable Sub Dispose Implements System.IDisposable.Dispose
    End Sub

  Public __connection As ConnectionString = Nothing
  
    Public Sub New(connection As ConnectionString)
    Me.New(connection, connection.Optimized)
    End Sub

    Public Sub New(ByVal connection As ConnectionString, optimized As Boolean)
        Me.DateFormat=connection.dateFormat:Me.BoolFormat=connection.boolFormat
        Me.DateLeftDelim=connection.dateLeftDelim:Me.DateRightDelim=connection.dateRightDelim
        Me._server=connection.server: Me._optimized=optimized
        Me.__connection=connection
    End Sub

    Public Function CheckConnection(ByVal login As String, ByVal password As String) As Boolean
        Return CheckConnectionImpl(login,password)
    End Function

    Public Function RunSql(ByVal sqlQuery As String) As DataSet
        Return RunSqlImpl(sqlQuery)
    End Function

    Public Function RunSql(ByVal sqlQuery As String,ByVal firstRecord As Integer, ByVal recordsNumber As Integer) As DataSet
        Return RunSqlImpl(sqlQuery, firstRecord, recordsNumber)
    End Function

    Public Function ExecuteNonQuery(ByVal sqlQuery As String) As Integer
        Return ExecuteNonQueryImpl(sqlQuery)
    End Function

    Public Function ExecuteScalar(ByVal sql As String) As Object
        Return ExecuteScalarImpl(sql)
    End Function

    Public Function GetSPParameter(ByVal name As String,ByRef value As Object,ByVal parameterType As ParameterType, ByVal parameterDirection As ParameterDirection, ByVal size As Integer, ByVal scale As Byte,ByVal precision As Byte) As IDataParameter
        Return GetSPParameterImpl(name,value,parameterType,parameterDirection,size,scale,precision)
    End Function

    Public Function RunSP(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Return RunSPImpl(sprocName,parameters)
    End Function

    Public Function RunSP(ByVal sprocName As String, ByVal parameters As ParameterCollection, ByVal retSet As DataSet) As Integer
        Return RunSPImpl(sprocName,parameters,retSet)
    End Function

    Public Function RunSP(ByVal sprocName As String, ByVal parameters As ParameterCollection, ByVal retSet As DataSet, ByVal startRecord As Integer, ByVal maxRecords As Integer) As Integer
        Return RunSPImpl(sprocName,parameters,retSet,startRecord,maxRecords)
    End Function

    Public Function ToSql(ByVal param As String,ByVal paramType As FieldType) As String
        Return ToSql(param,paramType, true)
    End Function

    Public Function ToSql(ByVal param As String, ByVal paramType As FieldType, ByVal AddQuotes As Boolean) As String
        Dim startQuoteSign As String = ""
        Dim endQuoteSign As String = ""
        If AddQuotes And (IsNothing(param) Or param = "") Then Return "NULL"
        If addQuotes Then
            If _server = "MSSQLServer" Then
                startQuoteSign = "N'"
                endQuoteSign = "'"
            Else
                startQuoteSign = "'"
                endQuoteSign = "'"
            End If
        End If
            Select paramType
            Case FieldType._Text,FieldType._Memo
                If _server = "MySQL" Then param = param.Replace("\", "\\")
                Return startQuoteSign + param.Replace("'","''") + endQuoteSign
            Case FieldType._Integer,FieldType._Float,FieldType._Single
                Return param.Replace(",",".")
            Case FieldType._Date
                Return CType(IIf(AddQuotes,DateLeftDelim,""),String) + param + CType(IIf(AddQuotes,DateRightDelim,""),String)
            Case FieldType._Boolean
                Return param
            Case Else
                Return ""
            End Select
    End Function

    Protected Overridable Function CheckConnectionImpl(ByVal login As String, ByVal password As String) As Boolean
        Return True
    End Function

    Protected Overridable Function RunSqlImpl(ByVal sqlQuery As String) As DataSet
        Return Nothing
    End Function

    Protected Overridable Function RunSqlImpl(ByVal sqlQuery As String,ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        Return Nothing
    End Function

    Protected Overridable Function ExecuteNonQueryImpl(ByVal sqlQuery As String) As Integer
        Return 0
    End Function

    Protected Overridable Function ExecuteScalarImpl(ByVal sqlQuery As String) As Object
        Return 0
    End Function

    Protected Overridable Function GetSPParameterImpl(ByVal name As String,ByVal value As Object, ByVal parameterType As ParameterType, ByVal parameterDirection As ParameterDirection, ByVal size As Integer, ByVal scale As Byte, ByVal precision As Byte) As IDataParameter
        Return Nothing
    End Function

    Protected Overridable Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection) As Integer
        Return 0
    End Function

    Protected Overridable Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, ByVal retSet As DataSet) As Integer
        Return 0
    End Function

    Protected Overridable Function RunSPImpl(ByVal sprocName As String, ByVal parameters As ParameterCollection, ByVal retSet As DataSet, ByVal startRecord As Integer, ByVal maxRecords As Integer) As Integer
        Return 0
    End Function
End Class
End Namespace
'End CodeCharge.Data.DataAccessObject Class

