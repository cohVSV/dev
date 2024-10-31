'DateParameter Class @0-517D003A
'Target Framework version is 3.5
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Data
   
   Public Class DateParameter
      Inherits Parameter
      
      
      Public Property Value() As DateTime
         Get
            Return CType(Values(0), DateTime)
         End Get
         Set
            Values(0) = value
         End Set
      End Property
      
      
      Public Sub New()
         MyClass.New(DateTime.Now, "", "")
      End Sub 'New
      
      
      Public Sub New(format As String)
         MyClass.New(DateTime.Now, format, "")
      End Sub 'New
      
      
      Public Sub New(format As String, dbFormat As String)
         MyClass.New(DateTime.Now, format, dbFormat)
      End Sub 'New
      
      
      Public Sub New(Value As DateTime)
         MyClass.New(Value, "", "")
      End Sub 'New
      
      
      Public Sub New(Value As DateTime, format As String)
         MyClass.New(Value, format, "")
      End Sub 'New
      
      
      Public Sub New(Value As DateTime, format As String, dbFormat As String)
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
         Dim v As DateTime
         If Not (val Is Nothing) Then
            v = CType(val, DateTime)
         Else
            Return "NULL"
         End If 
         If format.Length = 0 Then
            Return v.ToString()
         Else
            If Not (format Is Nothing) And format = "wi" Then
               Return CType(System.Threading.Thread.CurrentThread.CurrentCulture, CCSCultureInfo).WeekdayNarrowNames(CInt(v.DayOfWeek))
            Else
               Return v.ToString(format)
            End If
         End If 
      End Function 'GetFormattedValue
       
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
       
      Private Shared Function GetTypedVal(val As Object, format As String) As DateTime
         If TypeOf val Is String Then
            Return DBUtility.ParseDate(val.ToString(), format)
         Else
            If TypeOf val Is TimeSpan Then
               Return DateTime.op_Addition(new DateTime(1, 1, 1), CType(val, TimeSpan))
            Else
               Return Convert.ToDateTime(val)
            End If 
         End If
      End Function 'GetTypedVal
       
      Public Overloads Function ToString() As String
         Return Me.GetFormattedValue(DbFormat)
      End Function 'ToString
      
      
      Overloads Public Shared Function GetParam(param As Object, defaultValue As Object) As DateParameter
         Return GetParam(param, "", defaultValue)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object) As DateParameter
         Return GetParam(param, "", Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String) As DateParameter
         Return GetParam(param, format, Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String, defaultValue As Object) As DateParameter
         Return GetParam(param, ParameterSourceType.Expression, format, defaultValue, False)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, type As ParameterSourceType, format As String, defaultValue As Object, isNullable As Boolean) As DateParameter
         Dim val As Object = GetParamInternal(param, type)
         
         If val Is Nothing Then
            val = defaultValue
         End If
         Dim p As New DateParameter()
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
      End Function 
   End Class 
End Namespace 

'End DateParameter Class

