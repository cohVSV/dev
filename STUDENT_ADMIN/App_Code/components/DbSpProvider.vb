'SqlCommand Class @0-373BC24C
Imports System
Imports System.Data
Imports System.Text
Imports System.Collections
Imports System.Web
Imports DECV_PROD2007.Configuration

Namespace DECV_PROD2007.Data
Public Class SpCommand
Inherits DataCommand
    Public Sub New(ByVal spName As String, ByVal dao As DataAccessObject)
        Me.SqlQuery = New StringBuilder(spName)
        m_dao = dao
    End Sub

    Public Sub ClearParams()
        Parameters_.Clear()
    End Sub

    Public Sub AddParameter(ByVal paramName As String, ByVal paramValue As Object, ByVal paramType As ParameterType, ByVal paramDirection As ParameterDirection, ByVal paramSize As Integer, ByVal paramScale As Byte,ByVal paramPrecision As Byte)
		If TypeOf paramValue Is Parameter Then
		   paramValue = CType(paramValue, Parameter).GetValue()
		End If
		If TypeOf paramValue Is FieldBase Then
		   paramValue = CType(paramValue, FieldBase).Value
		End If

		Dim param As Object = Dao.GetSPParameter(paramName, paramValue, paramType, paramDirection, paramSize, paramScale, paramPrecision)
		If Not (param Is Nothing) Then
		   Parameters.Add(paramName, param)
		End If
  
    End Sub

    Protected Overloads Overrides Function ExecuteImpl() As DataSet
        Return ExecuteImpl(-1, 0)
    End Function

    Protected Overloads Overrides Function ExecuteImpl(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        Dim ds As DataSet = New DataSet()
        m_dao.RunSP(Me.SqlQuery.ToString(), Parameters,ds, startRecord, maxRecords)
        Return ds
    End Function

    Protected Overrides Function ExecuteNonQueryImpl() As Object
        Return m_dao.RunSP(Me.SqlQuery.ToString(), Parameters)
    End Function

End Class
End Namespace
'End SqlCommand Class

