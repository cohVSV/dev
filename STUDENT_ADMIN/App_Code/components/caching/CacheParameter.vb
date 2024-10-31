'CacheParameter class @0-93F0F087
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Caching

   Public Enum CacheParameterType
      Key
      Bypass
   End Enum 'CacheParameterType
    _
   Public Enum CacheParameterSource
      [Get]
      Post
      Session
      Expression
   End Enum 'CacheParameterSource
    _
   Public Class CacheParameter
      Private m_type As CacheParameterType
      Private m_source As CacheParameterSource
      Private m_name As String
      
      
      Public Property Type() As CacheParameterType
         Get
            Return m_type
         End Get
         Set
            m_type = value
         End Set
      End Property 
      
      Public Property [Source]() As CacheParameterSource
         Get
            Return m_source
         End Get
         Set
            m_source = value
         End Set
      End Property 
      
      Public Property Name() As String
         Get
            Return m_name
         End Get
         Set
            m_name = value
         End Set
      End Property
       
      Public Sub New()
      End Sub 'New
      
      
      Public Sub New(name As String, [source] As CacheParameterSource, type As CacheParameterType)
         Name = name
         [Source] = [source]
         Type = type
      End Sub 'New
   End Class 'CacheParameter

End Namespace

'End CacheParameter class

