'ParameterCollection class @0-3FE25DF7
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Namespace DECV_PROD2007.Data

   Public Class ParameterCollection
      Inherits NameObjectCollectionBase
      
      Private _de As New DictionaryEntry()
      
      Public Sub New()
      End Sub 'New
      
      
      Public Sub New(d As IDictionary, bReadOnly As [Boolean])
         Dim de As DictionaryEntry
         For Each de In  d
            Me.BaseAdd(CType(de.Key, [String]), de.Value)
         Next de
         Me.IsReadOnly = bReadOnly
      End Sub 'New
      
      
      Default Public ReadOnly Property Item(index As Integer) As DictionaryEntry
         Get
            _de.Key = Me.BaseGetKey(index)
            _de.Value = Me.BaseGet(index)
            Return _de
         End Get
      End Property
      
      
      Default Public Property Item(key As [String]) As [Object]
         Get
            Return Me.BaseGet(key)
         End Get
         Set
            Me.BaseSet(key, value)
         End Set
      End Property
      
      
      Public ReadOnly Property AllKeys() As [String]()
         Get
            Return Me.BaseGetAllKeys()
         End Get
      End Property
      
      
      Public ReadOnly Property AllValues() As Array
         Get
            Return Me.BaseGetAllValues()
         End Get
      End Property
      
      
      Public ReadOnly Property AllStringValues() As [String]()
         Get
            Return CType(Me.BaseGetAllValues(Type.GetType("System.String")), [String]())
         End Get
      End Property
      
      
      Public ReadOnly Property HasKeys() As [Boolean]
         Get
            Return Me.BaseHasKeys()
         End Get
      End Property
      
      
      Public Sub Add(key As [String], value As [Object])
         Me.BaseAdd(key, value)
      End Sub 'Add
      
      
      Overloads Public Sub Remove(key As [String])
         Me.BaseRemove(key)
      End Sub 'Remove
      
      
      Overloads Public Sub Remove(index As Integer)
         Me.BaseRemoveAt(index)
      End Sub 'Remove
      
      
      Public Sub Clear()
         Me.BaseClear()
      End Sub
   End Class 
End Namespace 

'End ParameterCollection class

