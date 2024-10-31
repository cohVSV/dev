'SqlCommand Class @0-0A4577C8
Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Specialized
Imports System.Web
Imports DECV_PROD2007.Configuration

Namespace DECV_PROD2007.Data
Public Class SqlCommand
Inherits DataCommand

    Public Sub New(ByVal sqlQuery As String, ByVal dao As DataAccessObject)
        Me.SqlQuery = New StringBuilder(sqlQuery)
        m_dao = dao
    End Sub

	Public Sub AddParameter(paramName As String, param As FieldBase, format As String)
	   If param Is Nothing Then
		  Return
	   End If
	   Dim ft As FieldType = FieldType._Text
	   If TypeOf param Is TextField Or TypeOf param Is MemoField Then
		  ft = FieldType._Text
	   End If
	   If TypeOf param Is FloatField Or TypeOf param Is SingleField Or TypeOf param Is IntegerField Then
		  ft = FieldType._Integer
	   End If
	   If TypeOf param Is BooleanField Then
		  ft = FieldType._Boolean
	   End If
	   If TypeOf param Is DateField Then
		  ft = FieldType._Date
	   End If
	   AddParameter(paramName, param.GetFormattedValue(format), ft)
	End Sub 'AddParameter

	Public Sub AddParameter(paramName As String, param As Parameter, format As String)
	   If param Is Nothing Then
		  Return
	   End If
	   Dim ft As FieldType = FieldType._Text
	   If TypeOf param Is TextParameter Or TypeOf param Is MemoParameter Then
		  ft = FieldType._Text
	   End If
	   If TypeOf param Is FloatParameter Or TypeOf param Is SingleParameter Or TypeOf param Is IntegerParameter Then
		  ft = FieldType._Integer
	   End If
	   If TypeOf param Is BooleanParameter Then
		  ft = FieldType._Boolean
	   End If
	   If TypeOf param Is DateParameter Then
		  ft = FieldType._Date
	   End If
	   AddParameter(paramName, param.GetFormattedValue(format), ft)
	End Sub 'AddParameter

	Protected Sub AddParameter(paramName As String, param As String, fieldType As FieldType)
	   If param Is Nothing Then
		  Return
	   End If
	   Parameters.Add(paramName, Dao.ToSql(param, fieldType, False))
	End Sub 'AddParameter

  
    Protected Overloads Overrides Function ExecuteImpl() As DataSet
        Return m_dao.RunSql(ToString())
    End Function
    Protected Overloads Overrides Function ExecuteImpl(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        firstRecord = startRecord
        recordsNumber = maxRecords
        Return m_dao.RunSql(ToString(),startRecord,maxRecords)
    End Function

    Protected Overrides Function ExecuteNonQueryImpl() As Object
        Return m_dao.ExecuteNonQuery(ToString())
    End Function

    Protected Overrides Function ExecuteScalarImpl() As Object
        Return m_dao.ExecuteScalar(ToString())
    End Function

    Private firstRecord As Integer = 0
    Private recordsNumber As Integer = 0
    Public Overrides Function ToString() As String
	Dim keys(Parameters.Count) As Object
	Dim values(Parameters.Count) As Object
	Parameters.AllKeys.CopyTo(keys, 0)
	Parameters.AllValues.CopyTo(values, 0)
	Dim i As Integer
	For i = 0 To Parameters.Count - 1
	   SqlQuery.Replace("{" + keys(i).ToString() + "}", values(i).ToString())
	Next i
	
        Dim order As String = CType(IIf(OrderBy.Length > 0, " ORDER BY " & OrderBy, ""),String)
        Dim sSQL As String = SqlQuery.ToString()
        If sSQL.IndexOf("{SQL_OrderBy}") > 0 Then
            sSQL = sSQL.Replace("{SQL_OrderBy}", order)
        Else
            sSQL += order
        End If
        If m_dao._optimized Then
            sSQL = sSQL.Replace("{SqlParam_endRecord}",(firstRecord + recordsNumber).ToString())
            sSQL = sSQL.Replace("{SqlParam_Offset}",firstRecord.ToString())
            sSQL = sSQL.Replace("{SqlParam_numRecords}",recordsNumber.ToString())
        End If
        Return sSQL
    End Function
End Class
End Namespace
'End SqlCommand Class

