'ICacheManager class @0-B4CC9F7E
Imports System
Imports System.Collections

Namespace DECV_PROD2007.Caching

   Public Interface ICacheManager 
      Inherits IDisposable

      Function GetCacheKey(page As String, parameters As ArrayList) As String
      Function GetPageKey(page As String) As String
      Sub PutObject(key As String, item As Object, duration As TimeSpan)
      Function GetObject(key As String) As Object
      Sub RemoveObject(key As String)
      Sub ClearStartedWith(pageKey As String)
      Sub ClearExpired()
   End Interface 'ICacheManager

End Namespace

'End ICacheManager class

