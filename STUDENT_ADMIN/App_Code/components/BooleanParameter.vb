'DbSpProvider Class @0-2A3BBB12
'Target Framework version is 3.5
Imports System
Imports System.Globalization
Imports System.Collections

Namespace DECV_PROD2007.Data
   
   Public Class BooleanParameter
      Inherits Parameter
      
      
      Public Property Value() As Boolean
         Get
            Return CBool(Values(0))
         End Get
         Set
            Values(0) = value
         End Set
      End Property
      
      
      Public Sub New()
         MyClass.New(False, "", "")
      End Sub 'New
      
      
      Public Sub New(format As String)
         MyClass.New(False, format, "")
      End Sub 'New
      
      
      Public Sub New(format As String, dbFormat As String)
         MyClass.New(False, format, dbFormat)
      End Sub 'New
      
      
      Public Sub New(boolValue As Boolean)
         MyClass.New(boolValue, "", "")
      End Sub 'New
      
      
      Public Sub New(boolValue As Boolean, format As String)
         MyClass.New(boolValue, format, "")
      End Sub 'New
      
      
      Public Sub New(boolValue As Boolean, format As String, dbFormat As String)
         Value = boolValue
         Format = format
         DbFormat = dbFormat
      End Sub 'New
      
      
      Public Overrides Function GetValue() As Object
         Return CType(Value, Object)
      End Function 'GetValue
      
      
      Public Overloads Overrides Function GetFormattedValue(index As Integer, format As String) As String
         Dim v As Object = Nothing
         If Values.Length > index Then
            v = Values(index)
         Else
            Return "NULL"
         End If
         Dim val As Boolean = False
         If Not (v Is Nothing) Then
            val = CBool(v)
         Else
            Return "NULL"
         End If 
         Dim fVal As String = DBUtility.FormatBool(val, format)
         Try
            Int32.Parse(fVal)
            Return fVal
         Catch
			If fVal.ToLower(CultureInfo.CurrentCulture)="true" Or fVal.ToLower(CultureInfo.CurrentCulture)="false" Then
			  Return fVal
			Else
			  return "'"+fVal+"'"
			End If
         End Try
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
       
      Private Shared Function GetTypedVal(val As Object, format As String) As Boolean
         If TypeOf val Is String Then
            Return DBUtility.ParseBool(val.ToString(), format)
         Else
            Return Convert.ToBoolean(val)
         End If
      End Function 'GetTypedVal
       
      Overloads Public Shared Function GetParam(param As Object, defaultValue As Object) As BooleanParameter
         Return GetParam(param, "", defaultValue)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object) As BooleanParameter
         Return GetParam(param, "", Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String) As BooleanParameter
         Return GetParam(param, format, Nothing)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, format As String, defaultValue As Object) As BooleanParameter
         Return GetParam(param, ParameterSourceType.Expression, format, defaultValue, False)
      End Function 'GetParam
      
      
      Overloads Public Shared Function GetParam(param As Object, type As ParameterSourceType, format As String, defaultValue As Object, isNullable As Boolean) As BooleanParameter
         Dim val As Object = GetParamInternal(param, type)
         
         If val Is Nothing Then
            val = defaultValue
         End If
         Dim p As New BooleanParameter()
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

'End DbSpProvider Class

