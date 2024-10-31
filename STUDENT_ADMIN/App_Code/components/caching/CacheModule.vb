'CacheModule class @0-502360D1
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Web
Imports System.Web.UI


Namespace DECV_PROD2007.Caching

   Public Class CacheModule
      Implements IHttpModule 'ToDo: Add Implements Clauses for implementation methods of these interface(s)
      
      Public Sub New()
      End Sub 'New
      
      
      Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
         AddHandler context.PreRequestHandlerExecute, AddressOf OnEntry
         AddHandler context.UpdateRequestCache, AddressOf OnLeave
      End Sub 'Init
      
      
      Public Sub Dispose() Implements IHttpModule.Dispose
         Throw New NotImplementedException()
      End Sub 'Dispose
      
      
      Private Sub OnEntry(sender As Object, e As EventArgs)
         Dim context As HttpApplication = CType(sender, HttpApplication)
         Dim cm As CacheManager = CType(context.Application("cache"), CacheManager)
         Dim h As IHttpHandler = HttpContext.Current.Handler
         If Not TypeOf h Is Page Then
            Return
         End If
         Dim fi As FieldInfo = CType(h,Object).GetType().GetField("cacheSettings")
         If fi Is Nothing Then
            Return
         End If
         Dim val As Object = CType(h,Object).GetType().InvokeMember("cacheSettings", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, h, Nothing)
         If val Is Nothing Or Not TypeOf val Is CacheSettings Then
            Return
         End If
         Dim settings As CacheSettings = CType(val, CacheSettings)
         
         Dim i As Integer
         For i = 0 To settings.Parameters.Count - 1
            Dim parameter As CacheParameter = CType(settings.Parameters(i), CacheParameter)
            If parameter.Type = CacheParameterType.Key Then
               GoTo ContinueFor1
            End If
            Select Case parameter.Source
               Case CacheParameterSource.Expression
                  If Not (parameter.Name Is Nothing) And parameter.Name <> "" Then settings.BypassPage = True
               Case CacheParameterSource.Get
                  If Not (context.Request.QueryString(parameter.Name) Is Nothing) Then settings.BypassPage = True
               Case CacheParameterSource.Post
                  If Not (context.Request.Form(parameter.Name) Is Nothing) Then settings.BypassPage = True
               Case CacheParameterSource.Session
                  If Not (context.Session(parameter.Name) Is Nothing) Then settings.BypassPage = True
            End Select
         ContinueFor1:
         Next i

         Dim body As Object = cm.GetObject(cm.GetCacheKey(context.Context.Request.Path, settings.Parameters))
         Dim currentStatus As HttpValidationStatus
         If settings.BypassPage Then
            currentStatus = HttpValidationStatus.IgnoreThisRequest
         Else
            If body Is Nothing Then
               currentStatus = HttpValidationStatus.Invalid
            Else
               currentStatus = HttpValidationStatus.Valid
            End If 
         End If

         If Not (settings.validateCallBack Is Nothing) Then
            settings.validateCallBack(HttpContext.Current, settings.userData, currentStatus)
            Select Case currentStatus
               Case HttpValidationStatus.IgnoreThisRequest
                  settings.BypassPage = True
                     Return
               Case HttpValidationStatus.Invalid
                  cm.RemoveObject(cm.GetCacheKey(context.Context.Request.Path, settings.Parameters))
                     Return
            End Select
         End If

         If Not (body Is Nothing) Then
            Dim ms As MemoryStream = CType(body, MemoryStream)
            ms.Position = 0
            Dim buffer(4096) As Byte
            Dim j As Integer = ms.Read(buffer, 0, 4096)
            While j > 0
               context.Context.Response.OutputStream.Write(buffer, 0, j)
               j = ms.Read(buffer, 0, 4096)
            End While
            
            context.CompleteRequest()
         End If
      End Sub 'OnEntry
      
      
      Private Sub OnLeave(sender As Object, e As EventArgs)
         Dim context As HttpApplication = CType(sender, HttpApplication)
         Dim cm As CacheManager = CType(context.Application("cache"), CacheManager)
         Dim h As IHttpHandler = HttpContext.Current.Handler
         If Not TypeOf h Is Page Then
            Return
         End If
         Dim fi As FieldInfo = CType(h,Object).GetType().GetField("cacheSettings")
         If fi Is Nothing Then
            Return
         End If
         Dim val As Object = CType(h,Object).GetType().InvokeMember("cacheSettings", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, h, Nothing)
         If val Is Nothing Or Not TypeOf val Is CacheSettings Then
            Return
         End If
         Dim settings As CacheSettings = CType(val, CacheSettings)
         Dim key As String = cm.GetCacheKey(context.Request.Path, settings.Parameters)
         If settings.BypassPage Then
            Return
         End If
         fi = CType(h,Object).GetType().GetField("pageFilter")
         If fi Is Nothing Then
            Return
         End If
         val = CType(h,Object).GetType().InvokeMember("pageFilter", BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField, Nothing, h, Nothing)
         If val Is Nothing Or Not TypeOf val Is ResponseFilter Then
            Return
         End If
         Dim pageFilter As ResponseFilter = CType(val, ResponseFilter)
         
         
         cm.PutObject(key, pageFilter.Body, settings.Duration)
      End Sub 'OnLeave 
   End Class 'CacheModule
End Namespace

'End CacheModule class

