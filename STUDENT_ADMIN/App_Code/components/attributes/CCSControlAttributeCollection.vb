'CCSControlAttributeCollection class @0-292201AA
'Target Framework version is 3.5
Imports System
Imports System.Collections
Imports System.Web.UI
Imports DECV_PROD2007.Data

Namespace DECV_PROD2007.Controls

   Public Class CCSControlAttributeCollection
      Inherits CollectionBase
      Private _Container As Control
      
      Public Property Container() As Control
         Get
            Return _Container
         End Get
         Set
            _Container = value
         End Set
      End Property
      
      
      Public Sub New(container As Control)
         Me.Container = container
      End Sub 'New
      
      
      Private Function GetSpecialAttribute(name As String) As CCSControlAttribute
         Dim sa As New CCSControlSpecialAttribute(Container)
         sa.Name = name
         If sa.IsSpecialAttribute Then
            Return sa
         End If
         Return Nothing
      End Function 'GetSpecialAttribute
      
      
      Private Function AddSpecialAttribute(value As CCSControlAttribute) As Boolean
         Dim sa As New CCSControlSpecialAttribute(Container, value)
         Dim isSpecial As Boolean = sa.IsSpecialAttribute
         If Not isSpecial And Not (Container Is Nothing) Then
            If TypeOf Container Is System.Web.UI.WebControls.WebControl Then
               CType(Container, System.Web.UI.WebControls.WebControl).Attributes(value.Name) = value.ToString()
            Else
               If TypeOf Container Is System.Web.UI.HtmlControls.HtmlControl Then
                  CType(Container, System.Web.UI.HtmlControls.HtmlControl).Attributes(value.Name) = value.ToString()
               End If
            End If
         End If
         Return isSpecial
      End Function 'AddSpecialAttribute
      
      
      Default Public Property Item(index As Integer) As CCSControlAttribute
         Get
            Return CType(List(index), CCSControlAttribute)
         End Get
         Set
            If AddSpecialAttribute(value) Then
               List.RemoveAt(index)
            Else
               List(index) = value
            End If
         End Set
      End Property
      
      
      Default Public Property Item(name As String) As CCSControlAttribute
         Get
            Dim result As CCSControlAttribute = GetSpecialAttribute(name)
            If Not (result Is Nothing) Then
               Return result
            End If 
            Dim i As Integer = IndexOf(name)
            If i > - 1 Then
               result = CType(List(i), CCSControlAttribute)
            End If
            Return result
         End Get
         Set
            If Not AddSpecialAttribute(value) Then
               Dim i As Integer = IndexOf(name)
               If i > - 1 Then
                  List(i) = value
               Else
                  List.Add(value)
               End If
            End If
         End Set
      End Property
       
      Public Function Add(value As CCSControlAttribute) As Integer
         If AddSpecialAttribute(value) Then
            Return - 1
         End If
         Return List.Add(value)
      End Function 'Add
      
      
      Overloads Public Function IndexOf(value As CCSControlAttribute) As Integer
         Return List.IndexOf(value)
      End Function 'IndexOf
      
      
      Overloads Public Function IndexOf(name As String) As Integer
         Dim i As Integer
         For i = 0 To List.Count - 1
            If CType(List(i), CCSControlAttribute).Name = name Then
               Return i
            End If
         Next i
         Return - 1
      End Function 'IndexOf
      
      
      Public Sub Insert(index As Integer, value As CCSControlAttribute)
         List.Insert(index, value)
      End Sub 'Insert
      
      
      Public Sub Remove(value As CCSControlAttribute)
         If Contains(value) Then
            List.Remove(value)
         End If
      End Sub 'Remove
       
      Public Function Contains(value As CCSControlAttribute) As Boolean
         ' If value is not of type CCSControlAttribute, this will return false.
         Return List.Contains(value)
      End Function 'Contains
   End Class 'CCSControlAttributeCollection 

End Namespace 

'End CCSControlAttributeCollection class

