'CacheManager class @0-2A658E74
Imports System
Imports System.Collections
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Web.Caching


Namespace DECV_PROD2007.Caching

   Public Class CacheManager
      Implements ICacheManager
      
      Public Sub New()
      End Sub 'New
      
      
      Public Function GetCacheKey(page As String, parameters As ArrayList) As String Implements ICacheManager.GetCacheKey
         Dim result As New StringBuilder()
         Dim context As HttpContext = HttpContext.Current
         result.Append(GetPageKey(page))
         Dim i As Integer
         For i = 0 To parameters.Count - 1
            Dim parameter As CacheParameter = CType(parameters(i), CacheParameter)
            If parameter.Type = CacheParameterType.Bypass Then
               GoTo ContinueFor1
            End If
            Select Case parameter.Source
               Case CacheParameterSource.Expression
                  result.Append("EXPR:")
                  result.Append(parameter.Name)
               Case CacheParameterSource.Get
                  
                  If Not (context.Request.QueryString(parameter.Name) Is Nothing) Then
                     result.Append("GET:")
                     result.Append(context.Request.QueryString(parameter.Name))
                  End If
               Case CacheParameterSource.Post
                  If Not (context.Request.Form(parameter.Name) Is Nothing) Then
                     result.Append("POST:")
                     result.Append(context.Request.QueryString(parameter.Name))
                  End If
               Case CacheParameterSource.Session
                  If Not (context.Session(parameter.Name) Is Nothing) Then
                     result.Append("SESS:")
                     result.Append(context.Request.QueryString(parameter.Name))
                  End If
            End Select
            
            result.Append(";"c)
         ContinueFor1:
         Next i
         Return result.ToString().TrimEnd(";"c)
      End Function 'GetCacheKey
      
      
      Public Function GetPageKey(page As String) As String Implements ICacheManager.GetPageKey
         Dim md5 As New MD5CryptoServiceProvider()
         Dim encoding As New ASCIIEncoding()
         Dim [source] As Byte() = encoding.GetBytes(page)
         Dim hash As Byte() = md5.ComputeHash([source])
         Dim result As String = encoding.GetString(hash)
         
         Return result
      End Function 'GetPageKey
      
      
      Public Sub PutObject(key As String, item As Object, duration As TimeSpan) Implements ICacheManager.PutObject
         Dim context As HttpContext = HttpContext.Current
         context.Cache.Add(key, item, Nothing, DateTime.Now.Add(duration), Cache.NoSlidingExpiration, CacheItemPriority.Default, Nothing)
      End Sub 'PutObject
      
      
      Public Function GetObject(key As String) As Object Implements ICacheManager.GetObject
         Dim context As HttpContext = HttpContext.Current
         Return context.Cache.Get(key)
      End Function 'GetObject
      
      
      Public Sub RemoveObject(key As String) Implements ICacheManager.RemoveObject
         Dim context As HttpContext = HttpContext.Current
         context.Cache.Remove(key)
      End Sub 'RemoveObject
      
      
      Public Sub ClearStartedWith(pageKey As String) Implements ICacheManager.ClearStartedWith
         Dim context As HttpContext = HttpContext.Current
         Dim entry As DictionaryEntry
         For Each entry In  context.Cache
            If entry.Key.ToString().StartsWith(pageKey) Then
               context.Cache.Remove(entry.Key.ToString())
            End If
         Next entry
      End Sub 'ClearStartedWith
       
      Public Sub ClearExpired() Implements ICacheManager.ClearExpired
      End Sub 'ClearExpired
      
      
      #Region "IDisposable Members"
      Public Sub Dispose()  Implements IDisposable.Dispose

      End Sub 'Dispose
      #End Region

   End Class 'CacheManager
End Namespace

'End CacheManager class

