'TableCommand Class @0-CCDBF7A6
Imports System
Imports System.Data
Imports System.Text
Imports System.Collections.Specialized
Imports System.Web
Imports DECV_PROD2007.Configuration

Public Enum Condition
Equal
NotEqual
LessThan
LessThanOrEqual
GreaterThan
GreaterThanOrEqual
BeginsWith
NotBeginsWith
EndsWith
NotEndsWith
Contains
NotContains
NotNull
IsNull
DefaultNull
Between
NotBetween
[In]
NotIn
End Enum

Namespace DECV_PROD2007.Data
Public Class TableCommand
Inherits DataCommand
    Protected whereTemplate_ As String()
    Public Where As String = ""
    Public Operation As String = ""

    Public Sub New(ByVal sqlQuery As String,ByVal staticWhere As String, ByVal joinOperation As String, ByVal whereTemplate As String(),ByVal dao As DataAccessObject)
        Me.SqlQuery = New StringBuilder(sqlQuery)
        Me.whereTemplate = whereTemplate
        Me.Where = staticWhere
        Me.Operation = joinOperation
        m_dao = dao
    End Sub

    Public Sub New(ByVal sqlQuery As String,ByVal staticWhere As String, ByVal joinOperation As String, ByVal whereTemplate As String(),ByVal dao As DataAccessObject, ignoreOptimization As Boolean)
        Me.SqlQuery = New StringBuilder(sqlQuery)
        Me.whereTemplate = whereTemplate
        Me.Where = staticWhere
        Me.Operation = joinOperation
        m_dao = dao
        If ignoreOptimization Then m_dao._optimized = False
    End Sub

    Public Sub New(ByVal sqlQuery As String,ByVal whereTemplate As String(),ByVal dao As DataAccessObject)
        Me.New(sqlQuery, "", "", whereTemplate, dao)
    End Sub
    Public Sub New(ByVal sqlQuery As String,ByVal whereTemplate As String(),ByVal dao As DataAccessObject, ignoreOptimization As Boolean)
        Me.New(sqlQuery, "", "", whereTemplate, dao, ignoreOptimization)
    End Sub


	Public Sub AddParameter(paramName As String, param As FieldBase, format As String, field As String, op As Condition, useDefaultNull As Boolean)
	   Dim val As String = ""
	   Dim val1 As String = ""
	   Dim ft As FieldType = FieldType._Boolean
	   If useDefaultNull And param Is Nothing Then
		  op = Condition.IsNull
	   Else
		  If Not (param Is Nothing) Then
			 val = param.GetFormattedValue(format)
		  Else
			 Parameters.Add(paramName, "")
			 Return
		  End If
	   End If
	   If TypeOf param Is TextField Or TypeOf param Is MemoField Then
		  ft = FieldType._Text
	   End If
	   If TypeOf param Is FloatField Or TypeOf param Is SingleField Or TypeOf param Is IntegerField Then
		  ft = FieldType._Integer
	   End If
	   If TypeOf param Is DateField Then
		  ft = FieldType._Date
	   End If
	   AddParameter(paramName, val, val1, ft, field, op)
	End Sub

	
Public Sub AddParameter(paramName As String, param As Parameter, format As String, field As String, op As Condition, useDefaultNull As Boolean)
   Dim val As String = ""
   Dim val1 As String = ""
   Dim ft As FieldType = FieldType._Boolean
   If TypeOf param Is TextParameter Or TypeOf param Is MemoParameter Then
      ft = FieldType._Text
   End If
   If TypeOf param Is FloatParameter Or TypeOf param Is SingleParameter Or TypeOf param Is IntegerParameter Then
      ft = FieldType._Integer
   End If
   If TypeOf param Is DateParameter Then
      ft = FieldType._Date
   End If
   If useDefaultNull And param Is Nothing Then
      op = Condition.IsNull
   Else
      If Not (param Is Nothing) And(op = Condition.In Or op = Condition.NotIn) Then
         Dim z As Integer
         For z = 0 To param.Values.Length - 1
            val += Dao.ToSql(param.GetFormattedValue(z, format), ft, True) + ","
         Next z
         val = val.TrimEnd(","c)
      Else
         If Not (param Is Nothing) And op <> Condition.Between And op <> Condition.NotBetween Then
            val = param.GetFormattedValue(format)
         Else
            If op = Condition.Between Or op = Condition.NotBetween AndAlso Not param.IsNull Then
               val = param.GetFormattedValue(0, format)
               If param.IsMultiple Then
                  val1 = param.GetFormattedValue(1, format)
               Else
                  val1 = val
               End If
            Else
               Parameters.Add(paramName, "")
               Return
            End If
         End If
      End If
   End If
   AddParameter(paramName, val, val1, ft, field, op)
   End Sub 'AddParameter

	Protected Sub AddParameter(paramName As String, param As String, param1 As String, fieldType As FieldType, field As String, op As Condition)
	   Dim p As String = CType(Iif(fieldType = FieldType._Text,"%",""), String)
	   Select Case op
		  Case Condition.Equal
			 Parameters.Add(paramName, field + " = " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.NotEqual
			 Parameters.Add(paramName, field + " <> " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.LessThan
			 Parameters.Add(paramName, field + " < " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.GreaterThan
			 Parameters.Add(paramName, field + " > " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.LessThanOrEqual
			 Parameters.Add(paramName, field + " <= " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.GreaterThanOrEqual
			 Parameters.Add(paramName, field + " >= " + Dao.ToSql(param, fieldType, True))
				Return
		  Case Condition.BeginsWith
			 Parameters.Add(paramName, field + " like " + Dao.ToSql(param + p, fieldType, True))
				Return
		  Case Condition.NotBeginsWith
			 Parameters.Add(paramName, field + " not like " + Dao.ToSql(param + p, fieldType, True))
				Return
		  Case Condition.EndsWith
			 Parameters.Add(paramName, field + " like " + Dao.ToSql(p + param, fieldType, True))
				Return
		  Case Condition.NotEndsWith
			 Parameters.Add(paramName, field + " not like " + Dao.ToSql(p + param, fieldType, True))
				Return
		  Case Condition.Contains
			 Parameters.Add(paramName, field + " like " + Dao.ToSql(p + param + p, fieldType, True))
				Return
		  Case Condition.NotContains
			 Parameters.Add(paramName, field + " not like " + Dao.ToSql(p + param + p, fieldType, True))
				Return
		  Case Condition.NotNull
			 Parameters.Add(paramName, field + " IS NOT NULL")
				Return
		  Case Condition.IsNull
			 Parameters.Add(paramName, field + " IS NULL")
				Return
		  Case Condition.Between
	        Parameters.Add(paramName,field + " BETWEEN " +  Dao.ToSql(param, fieldType, true) + " AND " +  Dao.ToSql(param1, fieldType, true))
			Return
          Case Condition.NotBetween
	        Parameters.Add(paramName,field + " NOT BETWEEN " +  Dao.ToSql(param, fieldType, true) + " AND " +  Dao.ToSql(param1, fieldType, true))
			Return
          Case Condition.In
	        Parameters.Add(paramName,field + " IN(" + param + ")" )
			Return
          Case Condition.NotIn
	        Parameters.Add(paramName,field + " NOT IN(" + param + ")" )
			Return

	   End Select
	End Sub

  
    Public Property WhereTemplate As String()
        Get
            Return whereTemplate_
        End Get
        Set
            whereTemplate_ = value
        End Set
    End Property

    Protected Function PrepareWhere() As String
		If IsNothing(whereTemplate_) OrElse whereTemplate_.Length = 0 Then Return ""
        Dim template(whereTemplate_.Length-1) As String
		If Not IsNothing(whereTemplate_) Then whereTemplate_.CopyTo(template, 0)
		Dim i As Integer
		For i = 0 To template.Length - 1
			If Not (template(i) = "(" Or template(i) = ")" Or template(i) = "Or" Or template(i) = "And") Then template(i) = Parameters(template(i)).ToString()
		Next i
		Return (New WhereBuilder(template)).GetWhere()
  
    End Function

    Protected Overloads Overrides Function ExecuteImpl(ByVal startRecord As Integer, ByVal maxRecords As Integer) As DataSet
        firstRecord = startRecord
        recordsNumber = maxRecords
        if Dao.__connection.Server = "MySQL" And Dao._optimized = True Then
            return m_dao.RunSql(ToString(), 0, maxRecords)
        End if
        Return m_dao.RunSql(ToString(),startRecord,maxRecords)
    End Function
    Protected Overloads Overrides Function ExecuteImpl() As DataSet
        Return m_dao.RunSql(ToString())
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
        Dim where_ As String = PrepareWhere()
        Dim sSQL As String = SqlQuery.ToString()
        If Not (where_ Is Nothing) And where_.Length > 0 Then
            where_ = " WHERE " + CStr(IIf(Not (Where Is Nothing) And Where.Length > 0,Where + " " + Operation,"")) + " (" + where_ + ")"
        Else
            where_ = CType(IIf(Where.Length > 0, " WHERE " & Where,""),String)
        End If
        Dim order As String = CType(IIf(OrderBy.Length > 0," ORDER BY " & OrderBy,""),String)
        If (sSQL.IndexOf("{SQL_Where}") > 0 Or sSQL.IndexOf("{SQL_OrderBy}") > 0) And OpType = OperationType.Select_ Then
            sSQL = sSQL.Replace("{SQL_Where}", where_)
            sSQL = sSQL.Replace("{SQL_OrderBy}", order)
        Else
            sSQL += where_ + order
        End If
        If m_dao._optimized And OpType = OperationType.Select_ Then
            If m_dao.__connection.TopRecordsPlace = TopRecordsPlace.afterQuery Then sSQL += m_dao.__connection.TopRecordsClause
            sSQL = sSQL.Replace("{SqlParam_endRecord}",(firstRecord + recordsNumber).ToString())
            sSQL = sSQL.Replace("{SqlParam_Offset}",firstRecord.ToString())
            sSQL = sSQL.Replace("{SqlParam_numRecords}",recordsNumber.ToString())
        End If
        Return sSQL
    End Function
End Class
End Namespace
'End TableCommand Class

