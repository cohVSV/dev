'CacheSettings class @0-A98FB12E
Imports System
Imports System.Collections
Imports System.Web

Namespace DECV_PROD2007.Caching

   Public Class CacheSettings
      Private m_parameters As New ArrayList()
      Friend validateCallBack As HttpCacheValidateHandler
      Friend userData As Object = Nothing
      Private m_bypassPage As Boolean = False
      
      Private m_duration As TimeSpan
      
      
      Public Property Duration() As TimeSpan
         Get
            Return m_duration
         End Get
         Set
            m_duration = value
         End Set
      End Property 
      
      Public ReadOnly Property Parameters() As ArrayList
         Get
            Return m_parameters
         End Get
      End Property 
      
      Public Property BypassPage() As Boolean
         Get
            Return m_bypassPage
         End Get
         Set
            m_bypassPage = value
         End Set
      End Property

      Public Sub AddValidationCallback(handler As HttpCacheValidateHandler, data As Object)
         validateCallBack = handler
         userData = data
      End Sub

   End Class 'CacheSettings

End Namespace

'End CacheSettings class

