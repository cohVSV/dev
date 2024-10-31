'FloatParameter Class @0-CDEF2050
'Target Framework version is 3.5
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Data
   
   Public Class FloatParameter
      Inherits Parameter
      
      
      Public Property Value() As [Double]
         Get
            Return CType(Values(0), [Double])
         End Get
         Set
            Values(0) = value
         End Set
      End Property
      
      
      Public Sub New()
         MyClass.New([Double].NaN, "", "")
      End Sub 'New
      
      
      Public Sub New(format As String)
         MyClass.New([Double].NaN, format, "")
      End Sub 'New
      
      
      Public Sub New(format As String, dbFormat As String)
         MyClass.New([Double].NaN, format, dbFormat)
      End Sub 'New
      
      
      Public Sub New(Value As [Double])
         MyClass.New(Value, "", "")
      End Sub 'New
      
      
      Public Sub New(Value As [Double], format As String)
         MyClass.New(Value, format, "")
      End Sub 'New
      
      
      Public Sub New(Value As [Double], format As String, dbFormat As String)
         Me.Value = Value
         Format = format
         DbFormat = dbFormat
      End Sub 'New
      
      
      Public Overrides Function GetValue() As Object
         Return CType(Value, Object)
      End Function 'GetValue
      
      
      Overloads Public Overrides Function GetFormattedValue(index As Integer, format As String) As String
         Dim val As Object = Nothing
         If Values.Length > index Then
            val = Values(index)
         Else
            Return "NULL"
         End If
         Dim v As Double = 0
         If Not (val Is Nothing) Then
            v = CDbl(val)
         Else
            Return "NULL"
         End If 
         Return DBUtility.FormatNumber(v, format)
      End Function 'GetFormattedValue
      
      
      
      Public Overloads Function ToString() As String
         Return Me.GetFormattedValue(DbFormat)
      End Function 'ToString
      
      
      Overloads Public Overrides Sub SetValue(value As Object)
         SetValue(value, Nothing)
      End Sub 'SetValue
      
      
      Overloads Public Overrides Sub SetValue(value As Object, defaultValue As Object)
         If value Is Nothing Then
            value = defaultValue
         End If
         If value Is Nothing Then
            _IsNull = True
         Else
            Value = GetTypedVal(value, Format)
         End If
      End Sub 'SetValue
       
      Private Shared Function GetTypedVal(val As Object, format As String) As [Double]
         If TypeOf val Is String Then
            Return DBUtility.ParseDouble(val.ToString(), format)
         Else
            Return Convert.ToDouble(val)
         End If 
      End Function 'GetTypedVal
      
      
      Overloads Public Shared Function GetParam(param As Object, defaultValue As Object) As FloatParameter
         Return GetParam(param, "", defaultValue)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object) As FloatParameter
         Return GetParam(param, "", Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String) As FloatParameter
         Return GetParam(param, format, Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String, defaultValue As Object) As FloatParameter
         Return GetParam(param, ParameterSourceType.Expression, format, defaultValue, False)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, type As ParameterSourceType, format As String, defaultValue As Object, isNullable As Boolean) As FloatParameter
         Dim val As Object = GetParamInternal(param, type)
         
         If val Is Nothing Then
            val = defaultValue
         End If
         Dim p As New FloatParameter()
         If val Is Nothing Then
            If Not isNullable Then
               Return Nothing
            End If
            p._IsNull = True
            Return p
         End If
         
         If TypeOf val Is ICollection Then
            p.Values = New Object(CType(val, ICollection).Count - 1) {}
            CType(val, ICollection).CopyTo(p.Values, 0)
            Dim i As Integer
            For i = 0 To p.Values.Length - 1
               If Not (p.Values(i) Is Nothing) Then
                  p.Values(i) = GetTypedVal(p.Values(i), format)
               End If
            Next i
         Else
            p.Value = GetTypedVal(val, format)
         End If
         Return p
      End Function 'GetParam
   End Class 'FloatParameter 
End Namespace 'T_C_MSSQL_IIS.Data


'End FloatParameter Class

