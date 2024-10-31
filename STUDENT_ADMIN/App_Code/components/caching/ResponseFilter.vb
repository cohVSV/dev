'ResponseFilter class @0-4AF1FB37
'Target Framework version is 3.5
Imports System.IO

Namespace DECV_PROD2007.Caching

   Public Class ResponseFilter
      Inherits Stream
      Private _sink As Stream
      Private _position As Long
      Private _body As MemoryStream
      
      
      Public Sub New(sink As Stream)
         _sink = sink
         _body = New MemoryStream()
      End Sub 'New
      
      
      Public Overrides ReadOnly Property CanRead() As Boolean
         Get
            Return True
         End Get
      End Property 
      
      Public Overrides ReadOnly Property CanSeek() As Boolean
         Get
            Return True
         End Get
      End Property 
      
      Public Overrides ReadOnly Property CanWrite() As Boolean
         Get
            Return True
         End Get
      End Property 
      
      Public Overrides ReadOnly Property Length() As Long
         Get
            Return 0
         End Get
      End Property 
      
      Public Overrides Property Position() As Long
         Get
            Return _position
         End Get
         Set
            _position = value
         End Set
      End Property 
      
      Public ReadOnly Property Body() As MemoryStream
         Get
            Return _body
         End Get
      End Property
       
      Public Overrides Function Seek(offset As Long, direction As SeekOrigin) As Long
         Return _sink.Seek(offset, direction)
      End Function 'Seek
      
      
      Public Overrides Sub SetLength(length As Long)
         _sink.SetLength(length)
      End Sub 'SetLength
      
      
      Public Overrides Sub Close()
         _sink.Close()
      End Sub 'Close
      
      
      Public Overrides Sub Flush()
         _sink.Flush()
      End Sub 'Flush
      
      
      Public Overrides Function Read(buffer() As Byte, offset As Integer, count As Integer) As Integer
         Return _sink.Read(buffer, offset, count)
      End Function 'Read
      
      
      Public Overrides Sub Write(buffer() As Byte, offset As Integer, count As Integer)
         _body.Write(buffer, offset, count)
         _sink.Write(buffer, offset, count)
      End Sub 'Write 
   End Class 'ResponseFilter
End Namespace


'End ResponseFilter class

