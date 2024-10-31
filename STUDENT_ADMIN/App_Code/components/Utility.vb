'Using statements @0-8F28CF70
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web.SessionState
Imports System.Resources
Imports System.Globalization
Imports System.Collections.Specialized

Namespace DECV_PROD2007
'End Using statements

'ResponseFilter class @2b-AD4041E9
Public Delegate Sub OnFilterCloseHandler(htmlContent As String, responseStream As Stream, ByRef Result As Boolean)

Public Class ResponseFilter
   Inherits Stream
   Private responseStream As Stream 
   Private _position As Long
   Private html As New StringBuilder()
   Public Event OnFilterClose As OnFilterCloseHandler
   
   Public Sub New(inputStream As Stream) 
      responseStream = inputStream
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
    
   Public Overrides Sub Close()
      Dim data() As Byte
      
      Dim temp As String = html.ToString()
	  Dim Result As Boolean = False
	  RaiseEvent OnFilterClose(temp, responseStream, Result)
      If Not Result Then Return
      data = System.Text.UTF8Encoding.UTF8.GetBytes(temp)
      responseStream.Write(data, 0, data.Length)
      responseStream.Close()
   End Sub 
   
   
   Public Overrides Sub Flush()
      responseStream.Flush()
   End Sub 
   
   
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
    
   Public Overrides Function Seek(offset As Long, direction As System.IO.SeekOrigin) As Long
      Return responseStream.Seek(offset, direction)
   End Function 
   
   
   Public Overrides Sub SetLength(length As Long)
      responseStream.SetLength(length)
   End Sub 
   
   
   Public Overrides Function Read(buffer() As Byte, offset As Integer, count As Integer) As Integer
      Return responseStream.Read(buffer, offset, count)
   End Function 
   
   Public Overrides Sub Write(buffer() As Byte, offset As Integer, count As Integer) '
      html.Append(System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count))
   End Sub 
End Class 

'End ResponseFilter class

'CCSResourceManager class @1-7845666B
	Public Class CCSResourceManager
	   Inherits ResourceManager
	   
	   Public Sub New(baseName As String, [assembly] As System.Reflection.Assembly)
		  MyBase.New(baseName, [assembly])
	   End Sub
	   
	   Overloads Public Overrides Function GetString(name As String) As String
		  Dim val As String = Nothing
		  val = MyBase.GetString(name)
		  If val Is Nothing Then
			 val = name
		  End If
		  Return val
	   End Function
	   
	   Overloads Public Overrides Function GetString(name As String, culture As CultureInfo) As String
		  Dim val As String = Nothing
		  
			  val = MyBase.GetString(name, culture)
		  
		  If val Is Nothing Then
			 val = name
		  End If
		  Return val
	   End Function
	End Class 'CCSResourceManager 

'End CCSResourceManager class

   Public Class Utility 'Utility class @0-A2507587

'SetThreadCulture method @0-17FDF4FB
	Public Shared Sub SetThreadCulture()
	 Dim current As HttpContext = HttpContext.Current
         Dim locales As Hashtable = CType(current.Application("_locales"), Hashtable)
         If Not (current.Application(current.Request.PhysicalPath) Is Nothing) Then
            current.Request.ContentEncoding = System.Text.Encoding.GetEncoding(current.Application(current.Request.PhysicalPath).ToString())
         End If
		 Dim culture As String = ""
  	     culture = DECV_PROD2007.Configuration.Settings.SiteLanguage

	      System.Threading.Thread.CurrentThread.CurrentCulture = CType(locales(culture),CultureInfo)
		  System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture
  		  
	  End Sub 

'End SetThreadCulture method

'GetPageStyle method @0-63D070A9
	Public Shared Function GetPageStyle() As String
		 Dim current As HttpContext = HttpContext.Current
		 Dim style As String = ""
  	     
'End GetPageStyle method

'GetPageStyle method tail @0-7729CED8
		  If style Is Nothing Or style = "" Then style = "Blueprint"
		  
		  Return style
	  End Function 

'End GetPageStyle method tail

'ManageGalleryPanels method @1-55518893
	Public Shared Sub ManageGalleryPanels(currentItem As RepeaterItem, numberOfColumns As Integer, currentRow As Integer, pageSize As Integer, openPanelName As String, closePanelName As String, controlsPanelName As String, dataRows As Integer, ByRef isForceIteration As Boolean)
	   Dim maxRowNumber As Integer = IIf((dataRows Mod numberOfColumns) = 0, dataRows, (dataRows \ numberOfColumns + 1) * numberOfColumns)
	   Dim c As System.Web.UI.Control = currentItem.FindControl(openPanelName)
	   If Not (c Is Nothing) Then
		  c.Visible = numberOfColumns = 1 Or (currentRow Mod numberOfColumns = 1 And currentRow < maxRowNumber)
	   End If
	   c = currentItem.FindControl(closePanelName)
	   If Not (c Is Nothing) Then
		  c.Visible = currentRow Mod numberOfColumns = 0 Or currentRow = maxRowNumber
	   End If
	   c = currentItem.FindControl(controlsPanelName)
	   If Not (c Is Nothing) Then c.Visible = currentRow <= dataRows
	   isForceIteration = currentRow < maxRowNumber And currentRow >= dataRows
	End Sub 

'End ManageGalleryPanels method

'Update Panel method @1-B34CEC5D
        Public Shared Sub WriteUpdatePanelContent(MainHTML As String, panel As String)
            Dim fa As String = Regex.Match(MainHTML, "(<form[^>]*)action=""([^""]*)""([^>]*>)").Groups(2).Value
            Dim vs As String = Regex.Match(MainHTML, "(<input type=""hidden"" name=""__VIEWSTATE"" id=""__VIEWSTATE"" value="")([^""]*)("" />)").Groups(2).Value
            Dim ev As String = Regex.Match(MainHTML, "(<input type=""hidden"" name=""__EVENTVALIDATION"" id=""__EVENTVALIDATION"" value="")([^""]*)("" />)").Groups(2).Value
            Dim content As String = MainHTML.Substring(MainHTML.IndexOf("<div id=""" + panel + """>") + panel.Length + 12)
            Dim divBalance As Integer = 1
            Dim offset As Integer
            For Each match As Match In Regex.Matches(content, "<(/)?div(>)?")
                If (match.Value.StartsWith("<div")) Then divBalance = divBalance + 1 Else divBalance = divBalance - 1 
                If divBalance = 0 Then
                    offset = match.Index
                    Exit For
                End If
            Next
            HttpContext.Current.Response.Clear
            HttpContext.Current.Response.Write(content.Substring(0,offset))
            HttpContext.Current.Response.Write("<vs=""" & vs & """/>")
            HttpContext.Current.Response.Write("<ev=""" & ev & """/>")
            HttpContext.Current.Response.Write("<fa=""" & fa.Replace("&amp;FormFilter=" + panel, "").Replace("&amp;","&") & """/>")
        End Sub

'End Update Panel method

   End Class 'End Utility class @0-A61BA892

End Namespace 'End namespace @1b-5EA2E2E0

