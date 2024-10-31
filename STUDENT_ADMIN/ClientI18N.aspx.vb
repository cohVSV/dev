'Client @1-89737F27
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace DECV_PROD2007
Public Partial Class __client
   Inherits System.Web.UI.Page
   Protected allowedFiles As New NameValueCollection()
   Protected rm As System.Resources.ResourceManager
   
	Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Request.QueryString("file") Is Nothing Or allowedFiles(Request.QueryString("file")) Is Nothing Then
         Response.End()
      End If
      Dim sr As New StreamReader(MapPath(Request.QueryString("file")))
      Dim rawBody As String = sr.ReadToEnd()
      sr.Close()
      Dim body As New StringBuilder(rawBody)
      Dim res As New Regex("{res:([^}]*)}", RegexOptions.Multiline)
      Dim positions As MatchCollection = res.Matches(rawBody)
      Dim m As Match
      For Each m In  positions
         body.Replace(m.Value, rm.GetString(m.Groups(1).Value))
      Next m 
      Response.ContentType = allowedFiles(Request.QueryString("file"))
      Response.Write(body.ToString())
      Response.End()
   End Sub 'Page_Load
    
   
   Protected Overrides Sub OnInit(e As EventArgs)
	  InitializeComponent()
      MyBase.OnInit(e)
      rm = CType(Application("rm"), System.Resources.ResourceManager)
      Utility.SetThreadCulture()
	  Response.ContentEncoding = System.Text.Encoding.UTF8
	  allowedFiles.Add("DatePicker.js", "application/x-javascript")
      allowedFiles.Add("Functions.js", "application/x-javascript")
   End Sub 'OnInit
   
   
   Private Sub InitializeComponent()
   End Sub
End Class
End Namespace
'End Client

