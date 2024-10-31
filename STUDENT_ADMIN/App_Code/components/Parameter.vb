'Parameter Class @0-DF3FFDD3
'Target Framework version is 3.5
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Data
 
Public Enum ParameterSourceType
   URL
   Form
   Cookie
   Application
   Session
   Expression
   Control
End Enum 'ParameterSourceType
 

MustInherit Public Class Parameter
   
   Private _values(0) As Object
   
   Public Property Values() As Object()
      Get
         Return _values
      End Get
      Set
         _values = value
      End Set
   End Property
   
   
   Public ReadOnly Property IsMultiple() As Boolean
      Get
         Return _values.Length > 1
      End Get
   End Property
   
   
   Private _format As String = ""
   
   Public Property Format() As String
      Get
         Return _format
      End Get
      Set
         _format = value
      End Set
   End Property
   
   Private _dBformat As String = ""
   
   Public Property DbFormat() As String
      Get
         Return _dBformat
      End Get
      Set
         _dBformat = value
      End Set
   End Property
   
   Protected _IsNull As Boolean = False
   
   Public ReadOnly Property IsNull() As Boolean
      Get
         Return _IsNull
      End Get
   End Property
   
   
   Protected Shared Function GetParamAsString(param As Object, defaultValue As Object) As Object
      If param Is Nothing Then
         Return defaultValue
      End If
      Dim strValue As String
      strValue = param.ToString()
      If strValue = "" Then
         Return defaultValue
      End If
      Return param
   End Function 'GetParamAsString
   
   
   Protected Shared Function GetParamInternal(val As Object, type As ParameterSourceType) As Object
      Dim result As Object = Nothing
      Dim current As System.Web.HttpContext = System.Web.HttpContext.Current
      Select Case type
         Case ParameterSourceType.URL
            If current.Request.QueryString(val.ToString()) Is Nothing Then
               Exit Function
            End If
            result = current.Request.QueryString.GetValues(val.ToString())
         Case ParameterSourceType.Form
            If current.Request.Form(val.ToString()) Is Nothing Then
               Exit Function
            End If
            result = current.Request.Form.GetValues(val.ToString())
         Case ParameterSourceType.Cookie
            If current.Request.Cookies(val.ToString()) Is Nothing Then
               Exit Function
            End If
            Dim temp(current.Request.Cookies(val.ToString()).Values.Count-1) As String
            current.Request.Cookies(val.ToString()).Values.CopyTo(temp, 0)
            result = temp
         Case ParameterSourceType.Application
            result = current.Application(val.ToString())
         Case ParameterSourceType.Session
            result = current.Session(val.ToString())
         Case ParameterSourceType.Expression, ParameterSourceType.Control
            result = val
      End Select
      
      If TypeOf result Is ICollection Then
         Dim temp(CType(result, ICollection).Count - 1) As Object
         CType(result, ICollection).CopyTo(temp, 0)
         Dim flag As Boolean = False
         Dim o As Object
         For Each o In  temp
            flag = flag Or( Not (o Is Nothing) And o.ToString() <> "")
         Next o
         If Not flag Then
            Return Nothing
         End If
      Else
         If Not (result Is Nothing) AndAlso result.ToString() = "" Then
            Return Nothing
         End If
      End If
      Return result
   End Function 'GetParamInternal
   
   
   Overloads Overridable Public Function ToString(format As String) As String
      Return Me.GetFormattedValue(format)
   End Function 'ToString
   
   
   Overloads Overridable Public Function ToString(index As Integer, format As String) As String
      Return Me.GetFormattedValue(index, format)
   End Function 'ToString
   
   
   Overloads Public Overridable Function GetFormattedValue(format As String) As String
      Dim result As String = ""
      Dim i As Integer
      For i = 0 To Values.Length - 1
         result += GetFormattedValue(i, format) + ","
      Next i
      Return result.TrimEnd(","c)
   End Function 'GetFormattedValue
   
   
   Overloads Public MustOverride Function GetFormattedValue(index As Integer, format As String) As String
   
   Public MustOverride Function GetValue() As Object
   
   Overloads Public MustOverride Sub SetValue(value As Object)
   
   Overloads Public MustOverride Sub SetValue(value As Object, defaultValue As Object)
End Class 'Parameter
End Namespace

'End Parameter Class

