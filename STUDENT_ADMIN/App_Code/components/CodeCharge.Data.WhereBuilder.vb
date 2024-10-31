'CodeCharge.Data.WhereBuilder Class @0-1EBF204B
Imports System
Imports System.Data

Namespace DECV_PROD2007.Data
  Public Class WhereBuilder
    Private elements As System.Collections.Queue

    Public Sub New(ByVal parameters As String())
      elements = new System.Collections.Queue(parameters)
      elements.Enqueue("")
      elements.Enqueue("")
      elements.Enqueue("")
      elements.Enqueue("")
      elements.Enqueue("")
	End Sub

    Public Function GetWhere() As String
      Dim first As String = ""
      Dim op As String = ""
      Dim second As String = ""
      Dim UsePrevOp As Boolean = False
      Do While elements.Count > 3
        If first = "" Then
          first = CType(elements.Dequeue(),String)
          If first = "(" Then
            first = GetWhere()
            If first <> "" Then first = "(" & first & ")"
          End If
        End If
        If Not UsePrevOp Then
          op = CType(elements.Dequeue(),String)
        End If
		If op=")" Then Return first
        UsePrevOp = False
        second = CType(elements.Dequeue(),String)
        If second = "(" Then
          second = GetWhere()
          If second <> "" Then second = "(" & second & ")"
        End If
        If IsNothing(first) Then first = ""
        If IsNothing(second) Then second = ""
        If first.Trim() <> "" And second <> "" Then
          first = first & " " & op & " " & second
        Else
          Dim Peek As String = CType(elements.Peek(),String)
          If first.Trim() = "" And second <> "" Then first = first & " " & second
          If first.Trim() <> "" And second = "" And Peek = "And" Then
          	UsePrevOp = True
          	elements.Dequeue()
          End If
          If first = "" And second = "" And Peek <> ")" Then first = first & " "
        End If
        If CType(elements.Peek(),String) = ")" Then
        	elements.Dequeue()
        	Return first.Trim()
        End If
      Loop
	  If first.Trim()=")" Then first=""
      Return first.Trim()
    End Function
  End Class
End Namespace
'End CodeCharge.Data.WhereBuilder Class

