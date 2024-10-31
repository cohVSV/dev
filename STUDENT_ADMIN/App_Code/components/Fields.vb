'Fields Classes @1-4E1A3C7F
Imports System
Namespace DECV_PROD2007.Data
Public Class FieldBase
    Private m_value As Object
    Private m_format As String

    Public Property Value As Object
        Get
            Return m_value
        End Get
        Set
            m_value = value
        End Set
    End Property

    Public Property Format As String
        Get
            Return m_format
        End Get
        Set
            m_format = value
        End Set
    End Property

    Private _IsEmpty As Boolean
    
    Public Property IsEmpty() As Boolean
        Get
            Return _IsEmpty
        End Get
        Set
            _IsEmpty = value
        End Set
    End Property

    Public Sub New
    End Sub

    Public Sub New(format_ As String)
        Format = format_
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub


	Public Overrides Overloads Function Equals(obj As Object) As Boolean
	   If Not TypeOf obj Is FieldBase Then
		  Return False
	   End If
		If Value Is Nothing And Not CType(obj, FieldBase).Value Is Nothing Then
			Return False
		End If
		If Not Value Is Nothing And CType(obj, FieldBase).Value Is Nothing Then
			Return False
		End If
	   If Value Is Nothing Or CType(obj, FieldBase).Value Is Nothing Then
		  Return Value = CType(obj, FieldBase).Value
	   End If
	   Return Value.Equals(CType(obj, FieldBase).Value)
	End Function 'Equals

	Protected Shared Function IsNull(obj As Object) As Boolean
	   Return obj Is Nothing
	End Function

	Public Function CompareTo(obj As Object) As Integer
	   If Value Is Nothing Then
		  Return - 1
	   End If
	   Return Value.CompareTo(CType(obj, FieldBase).Value)
	End Function

	Public Shared Function EqualOp(a As FieldBase, b As FieldBase) As Boolean
	   If IsNull(a) And IsNull(b) Then
		  Return True
	   End If
	   If IsNull(a) And Not IsNull(b) Then
		  Return False
	   End If
	   If Not IsNull(a) And IsNull(b) Then
		  Return False
	   End If
	   Return a.Equals(b)
	End Function

	Public Shared Function NotEqualOp(a As FieldBase, b As FieldBase) As Boolean
	   Return Not FieldBase.EqualOp(a,b)
	End Function

	Public Shared Function GreaterThanOrEqual(a As FieldBase, b As FieldBase) As Boolean
	   If a Is Nothing Then
		  Return FieldBase.EqualOp(a,b)
	   End If
	   Return a.CompareTo(b) >= 0
	End Function

	Public Shared Function GreaterThan(a As FieldBase, b As FieldBase) As Boolean
	   If a Is Nothing Then
		  Return False
	   End If
	   Return a.CompareTo(b) > 0
	End Function

	Public Shared Function LessThanOrEqual(a As FieldBase, b As FieldBase) As Boolean
	   If b Is Nothing Then
		  Return FieldBase.EqualOp(a,b)
	   End If
	   Return b.CompareTo(a) >= 0
	End Function

	Public Shared Function LessThan(a As FieldBase, b As FieldBase) As Boolean
	   If b Is Nothing Then
		  Return False
	   End If
	   Return b.CompareTo(a) > 0
	End Function

    
    Public Overridable Function GetFormattedValue(ByVal format_ As String) As String
        If IsNothing(Value) Or Value Is DBNull.Value Then
            Return ""
        Else
            Return Value.ToString()
        End If
    End Function

    Public Overridable Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overridable Sub SetValue(ByVal val As Object, ByVal format_ As String)
        If IsNothing(val) Then
            Return
        else
            If val Is DBNull.Value Or val.ToString() = "" Then
                Me.Value = Nothing
            else
                Me.Value = val
            End If
        End If
    End Sub

    Public Overridable Sub SetValue(ByVal val As Object)
        SetValue(val, Format)
    End Sub
End Class

Public Class TextField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return CType(IIf(Value Is DBNull.Value,"",Value.ToString()),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal val As Object, ByVal format As String)
        If IsNothing(val) Then
            Return
        Else
                If val Is DBNull.Value Or val.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Me.Value = val
                End If
        End If
    End Sub
End Class

Public Class MemoField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format AS String) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return CType(IIf(Value Is DBNull.Value,"",Value.ToString()),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Me.Value = Value
                End If
        End If
    End Sub
End Class

Public Class IntegerField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return CType(IIf(Value Is DBNull.Value,"",DBUtility.FormatNumber(Value,format)),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Try
                    If TypeOf Value Is String Then
                        Me.Value = DBUtility.ParseInt(Value.ToString(), format)
                    Else
                        Me.Value = Convert.ToInt64(Value)
                    End If
                    Catch
                        Throw New ArgumentException("Unable to set value for the Integer field: Unable to parse the 'Value' argument or cast it to the System.Int64 type")
                    End Try
                End If
        End If
    End Sub
End Class

Public Class FloatField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return CType(IIf(Value Is DBNull.Value,"",DBUtility.FormatNumber(Value,format)),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Try
                    If TypeOf Value Is String Then
                        Me.Value = DBUtility.ParseDouble(Value.ToString(),format)
                    Else
                        Me.Value = Convert.ToDouble(Value)
                    End If
                    Catch
                        Throw New ArgumentException("Unable to set value for the Float field: Unable to parse the 'Value' argument or cast it to the System.Double type")
                    End Try
                End If
        End If
    End Sub
End Class

Public Class SingleField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        If IsNothing(Value) Then
            Return ""
        Else
            Return CType(IIf(Value Is DBNull.Value,"",DBUtility.FormatNumber(Value,format)),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Try
                    If TypeOf Value Is String Then
                        Me.Value = DBUtility.ParseSingle(Value.ToString(),format)
                    Else
                        Me.Value = Convert.ToSingle(Value)
                    End If
                    Catch
                        Throw New ArgumentException("Unable to set value for the Single field: Unable to parse the 'Value' argument or cast it to the System.Single type")
                    End Try
                End If
        End If
    End Sub
End Class

Public Class DateField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        If IsNothing(Value) Then
            Return ""
        ElseIf format = "wi"
            Return CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).WeekdayNarrowNames(CInt(CDate(Value).DayOfWeek))
        Else
            Return CType(IIf(Value Is DBNull.Value,"",CType(Value, DateTime).ToString(format)),String)
        End If
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Try
                    If TypeOf Value Is String Then
                        Me.Value = DBUtility.ParseDate(Value.ToString(),format)
                    Else
                        Me.Value = Convert.ToDateTime(Value)
                    End If
                    Catch
                        Throw New ArgumentException("Unable to set value for the Date field: Unable to parse the 'Value' argument or cast it to the System.DateTime type")
                    End Try
                End If
        End If
    End Sub
End Class

Public Class BooleanField
    Inherits FieldBase
    Public Sub New
    End Sub

    Public Sub New(ByVal format_ As String, ByVal defaultValue As Object)
        Format = format_
        SetValue(defaultValue)
    End Sub

    Public Overloads Overrides Function GetFormattedValue(ByVal format As String) As String
        Return CType(IIf(Value Is DBNull.Value,"",DBUtility.FormatBool(Value,format)),String)
    End Function

    Public Overloads Overrides Function GetFormattedValue() As String
        Return GetFormattedValue(Format)
    End Function

    Public Overloads Overrides Sub SetValue(ByVal Value As Object, ByVal format As String)
        If IsNothing(Value) Then
            Return
        Else
                If Value Is DBNull.Value Or Value.ToString() = "" Then
                    Me.Value = Nothing
                Else
                    Try
                    If TypeOf Value Is String Then
                        Me.Value = DBUtility.ParseBool(Value.ToString(),format)
                    Else
                        Me.Value = Convert.ToBoolean(Value)
                    End If
                    Catch
                        Throw New ArgumentException("Unable to set value for the Boolean field: Unable to parse the 'Value' argument or cast it to the System.Boolean type")
                    End Try
                End If
        End If
    End Sub
End Class
End Namespace
'End Fields Classes

