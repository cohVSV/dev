'FlashChart class @0-0E887F56
'Target Framework version is 3.5
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Security.Permissions
Imports System.Text.RegularExpressions
Imports System.Xml

Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Configuration
 
Namespace DECV_PROD2007.Controls
    Public Class FlashChart
	 Inherits Control
        Private _title As String
        Private _width As Integer
        Private _height As Integer
        Private _servicePath As String
        Private _dataSource() As IDataItem
        Private isBinded As Boolean =  False 
 
        Public Property Title() As String
        	Get 
                Return _title
        	End Get
        	Set (ByVal Value As String) 
                _title = value
        	End Set
        End Property

        Public Property DataSource() As IDataItem()
        	Get 
                Return _dataSource
        	End Get
        	Set (ByVal Value As IDataItem()) 
                _dataSource = value
        	End Set
        End Property

        Public Property Width() As Integer
        	Get 
                Return _width
        	End Get
        	Set (ByVal Value As Integer) 
                _width = value
        	End Set
        End Property

        Public Property Height() As Integer
        	Get 
                Return _height
        	End Get
        	Set (ByVal Value As Integer) 
                _height = value
        	End Set
        End Property

        Public Property ServicePath() As String
        	Get 
                Return _servicePath
        	End Get
        	Set (ByVal Value As String) 
                _servicePath = value
        	End Set
        End Property
 
        Protected Overrides Sub OnDataBinding(ByVal e As EventArgs)
            isBinded = True
            MyBase.OnDataBinding(e)
            If Page.Request("callbackControl") = ID Then
                RenderService()
            End If
        End Sub
 
        Private  Sub RenderService()
            Dim serviceDoc As XmlDocument =  New XmlDocument() 
            Dim xmlPath As String =  Path.Combine(Path.Combine(Page.Request.PhysicalApplicationPath,AppRelativeTemplateSourceDirectory.Substring(2).Replace("/","\\")),_servicePath) 
            serviceDoc.Load(xmlPath)
            Dim TitleNode As XmlNode = serviceDoc.SelectSingleNode("/root/chartarea/title/@text")
            If Not(TitleNode Is Nothing) Then
                Dim resKey As String = Regex.Match(TitleNode.Value, "^\{res:([^\}]+)\}").Groups(1).ToString()
                If resKey <> "" Then TitleNode.Value = Resources.strings.ResourceManager.GetString(resKey)
            End If
            Dim TemplateRowNode As XmlNode =  serviceDoc.SelectSingleNode("/root/data/rows/row").Clone() 
            Dim RowsNode As XmlNode =  serviceDoc.SelectSingleNode("/root/data/rows") 
            RowsNode.RemoveAll()
            Dim i As Integer
            For  i = 0 To _dataSource.Length - 1
                Dim cNode As XmlNode =  TemplateRowNode.Clone() 
                Dim j As Integer
                For  j = 0 To cNode.Attributes.Count - 1
                    Dim dsFields() As String =  cNode.Attributes(j).Value.Split(New Char() {"}"c,"{"c})
                    cNode.Attributes(j).Value = _dataSource(i)(dsFields(1)).GetFormattedValue("")
                Next
                RowsNode.AppendChild(cNode)
            Next
            Page.Response.AppendHeader("CACHE-CONTROL","NO-CACHE")
            Page.Response.ContentType = "text/xml"
            Page.Response.Write(serviceDoc.InnerXml)
            Page.Response.End()
        End Sub
 
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            Dim src As String = New Uri(Page.Request.Url, ".").OriginalString
            src = src.Substring(0, src.LastIndexOf(CType(Page,Control).AppRelativeTemplateSourceDirectory.Substring(1))) + "/FlashChart.swf?XMLDataFile=%3FcallbackControl%3D" & ID & Page.Server.UrlEncode("&" + Page.ClientQueryString)
            Dim param As NameValueCollection =  New NameValueCollection() 
            param.Add("quality", "high")
            param.Add("movie", src)
            param.Add("wmode", "transparent")
            param.Add("scale", "exactfit")
            writer.WriteBeginTag("object")
            writer.WriteAttribute("classid", "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000")
            writer.WriteAttribute("codebase", "http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0")
            writer.WriteAttribute("id", ClientID)
 
            writer.WriteAttribute("height", Height.ToString())
            writer.WriteAttribute("width", Width.ToString())
            writer.WriteAttribute("accesskey", "q")
            writer.WriteAttribute("tabindex", "1")
            writer.WriteAttribute("title", Title)
            writer.Write(">" & vbCrLf)
 
            Dim key As String
            For Each key In param.Keys
                writer.WriteBeginTag("param")
                writer.WriteAttribute("name", key)
                writer.WriteAttribute("value", param(key))
                writer.Write("/>" & vbCrLf)
            Next
 
            writer.WriteBeginTag("embed")
            writer.WriteAttribute("type", "application/x-shockwave-flash")
            writer.WriteAttribute("pluginspage", "http://www.macromedia.com/go/getflashplayer")
            writer.WriteAttribute("src", src)
            writer.WriteAttribute("height", Height.ToString())
            writer.WriteAttribute("width", Width.ToString())
            writer.WriteAttribute("quality", "high")
            writer.WriteAttribute("scale", "exactfit")
            writer.WriteAttribute("wmode", "transparent")
            writer.Write("/>" & vbCrLf)
 
            writer.WriteEndTag("object")
        End Sub
    End Class' FlashChart
End Namespace

'End FlashChart class

