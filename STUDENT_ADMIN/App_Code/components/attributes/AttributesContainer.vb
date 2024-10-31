'AttributesContainer class @0-0AE8AEDD
'Target Framework version is 3.5
Imports System
Imports System.Collections
Imports System.Web.UI

Namespace DECV_PROD2007.Controls
   <Flags()>  _
Public Enum AttributeOption
   None = &H1
   Multiple = &H2
End Enum 'AttributeOption
 _
Public Class AttributesContainer
   Inherits DictionaryBase

      Default Public Property Item(key As Control) As CCSControlAttributeCollection
         Get
            If Dictionary(key) Is Nothing Then
               Dictionary(key) = New CCSControlAttributeCollection(key)
            End If
            Return CType(Dictionary(key), CCSControlAttributeCollection)
         End Get
         Set
            If Not (value Is Nothing) Then
               value.Container = key
            End If
            Dictionary(key) = value
         End Set
      End Property
      
      
      Default Public Property Item(key As Control, index As Integer) As CCSControlAttributeCollection
         Get
            key = GetKeyByIndex(key, index)
            Return Me(key)
         End Get
         Set
            key = GetKeyByIndex(key, index)
            Me(key) = value
         End Set
      End Property
      
      
      Public ReadOnly Property Keys() As ICollection
         Get
            Return Dictionary.Keys
         End Get
      End Property
      
      
      Public ReadOnly Property Values() As ICollection
         Get
            Return Dictionary.Values
         End Get
      End Property
      
      
      Private Function GetKeyByIndex(key As Control, index As Integer) As Control
         If TypeOf key Is System.Web.UI.WebControls.Repeater Or TypeOf key Is CCDirectoryItem Or TypeOf key Is CCPathItem Then
            key = key.Controls(index)
         End If 
         Return key
      End Function 'GetKeyByIndex
      
      
      Private Function GetKey(key As Control) As Control
         Return GetKeyByIndex(key, key.Controls.Count - 1)
      End Function 'GetKey
      
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttributeCollection)
         If Not (value Is Nothing) Then
            value.Container = key
         End If
         Dictionary.Add(key, value)
      End Sub 'Add
      
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttributeCollection, index As Integer)
         key = GetKeyByIndex(key, index)
         If Not (value Is Nothing) Then
            value.Container = key
         End If
         Dictionary.Add(key, value)
      End Sub 'Add
      
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttributeCollection, options As AttributeOption)
         If(options And AttributeOption.Multiple) = AttributeOption.Multiple Then
            key = GetKey(key)
         End If 
         If Not (value Is Nothing) Then
            value.Container = key
         End If
         Dictionary.Add(key, value)
      End Sub 'Add
      
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttribute)
         If Me(key) Is Nothing Then
            Dictionary.Add(key, New CCSControlAttributeCollection(key))
         End If
         Me(key)(value.Name) = value
      End Sub 'Add
       
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttribute, index As Integer)
         key = GetKeyByIndex(key, index)
         If Me(key) Is Nothing Then
            Dictionary.Add(key, New CCSControlAttributeCollection(key))
         End If
         Me(key)(value.Name) = value
      End Sub 'Add
      
      
      
      Overloads Public Sub Add(key As Control, value As CCSControlAttribute, options As AttributeOption)
         If(options And AttributeOption.Multiple) = AttributeOption.Multiple Then
            key = GetKey(key)
         End If 
         If Me(key) Is Nothing Then
            Dictionary.Add(key, New CCSControlAttributeCollection(key))
         End If
         Me(key)(value.Name) = value
      End Sub 'Add
      
      
      Public Function Contains(key As Control) As Boolean
         Return Dictionary.Contains(key)
      End Function 'Contains
      
      
      Public Sub Remove(key As Control)
         Dictionary.Remove(key)
      End Sub 'Remove
      
      
      Overloads Public Function GetAttribute(control As String, name As String) As String
         Dim c As Control
         For Each c In  Keys
            If control = "pageAttribute" And TypeOf c Is System.Web.UI.Page Then
               If Not (Me(c)(name) Is Nothing) Then
                  Return Me(c)(name).ToString()
               End If
            End If
            If c.ID = control Then
               If Not (Me(c)(name) Is Nothing) Then
                  Return Me(c)(name).ToString()
               End If
            End If
         Next c
         Return ""
      End Function 'GetAttribute
      
      
      Overloads Public Function GetAttribute(control As String, name As String, index As Integer) As String
         Dim c As Control
         For Each c In  Keys
            If control = "pageAttribute" And TypeOf c Is System.Web.UI.Page Then
               If Not (Me(c)(name) Is Nothing) Then
                  Return Me(c)(name).ToString()
               End If
            End If
            If c.ID = control Then
               Dim key As Control = GetKeyByIndex(c, index)
               If Not (Me(key)(name) Is Nothing) Then
                  Return Me(key)(name).ToString()
               End If
            End If
         Next c
         Return ""
      End Function 'GetAttribute

End Class 'AttributesContainer
End Namespace

'End AttributesContainer class

