'IntegerParameter Class @0-D1A11FDE
'Target Framework version is 3.5
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Data
    
   Public Class IntegerParameter
      Inherits Parameter
      
      
      Public Property Value() As Int64
         Get
            Return CType(Values(0), Int64)
         End Get
         Set
            Values(0) = value
         End Set
      End Property
      
      
      Public Sub New()
         MyClass.New(0, "", "")
      End Sub 'New
      
      
      Public Sub New(format As String)
         MyClass.New(0, format, "")
      End Sub 'New
      
      
      Public Sub New(format As String, dbFormat As String)
         MyClass.New(0, format, dbFormat)
      End Sub 'New
      
      
      Public Sub New(Value As Int64)
         MyClass.New(Value, "", "")
      End Sub 'New
      
      
      Public Sub New(Value As Int64, format As String)
         MyClass.New(Value, format, "")
      End Sub 'New
      
      
      Public Sub New(Value As Int64, format As String, dbFormat As String)
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
         Dim v As Int64 = 0
         If Not (val Is Nothing) Then
            v = CType(val, Int64)
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
       
      Private Shared Function GetTypedVal(val As Object, format As String) As Int64
         If TypeOf val Is String Then
            Return DBUtility.ParseInt(val.ToString(), format)
         Else
            Return Convert.ToInt64(val)
         End If 
      End Function 'GetTypedVal
      
      
      Overloads Public Shared Function GetParam(param As Object, defaultValue As Object) As IntegerParameter
         Return GetParam(param, "", defaultValue)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object) As IntegerParameter
         Return GetParam(param, "", Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String) As IntegerParameter
         Return GetParam(param, format, Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String, defaultValue As Object) As IntegerParameter
         Return GetParam(param, ParameterSourceType.Expression, format, defaultValue, False)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, type As ParameterSourceType, format As String, defaultValue As Object, isNullable As Boolean) As IntegerParameter
         Dim val As Object = GetParamInternal(param, type)
         
         If val Is Nothing Then
            val = defaultValue
         End If
         Dim p As New IntegerParameter()
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
   End Class 'IntegerParameter 
End Namespace 'T_C_MSSQL_IIS.Data

'End IntegerParameter Class

