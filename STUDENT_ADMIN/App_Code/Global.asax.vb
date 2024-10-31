'Global @1-C8083EDB
'Target Framework version is 3.5
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Resources
Imports System.Globalization
Imports System.Collections.Specialized

Namespace DECV_PROD2007

Public Class clsGlobal
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

        ' Fires when the application is started
	
	Dim rm As ResourceManager = New CCSResourceManager("resources.strings", System.Reflection.Assembly.Load(New System.Reflection.AssemblyName("app_GlobalResources")))
	
	Application("_locales") = System.Configuration.ConfigurationManager.GetSection("locales")
	Application("rm") = rm
	HttpContext.Current.Cache.Insert("__InvalidateAllPages", DateTime.Now, Nothing, _
												System.DateTime.MaxValue, System.TimeSpan.Zero, _
												System.Web.Caching.CacheItemPriority.NotRemovable, _
												Nothing)

   ' 4 Feb 2021|RW| Adding TLS1.2 and TLS1.3 to the negotiated security protocols, in preparation for SMS Global supporting 1.2+ only
   '                As of .NET 4.7, SecurityProtocol is by default set to SecurityProtocolType.SystemDefault to inherit the system (OS) setting
   '                Adding multiple protocols should ensure that they're in the mix during the negotiation.
   System.Net.ServicePointManager.SecurityProtocol = (System.Net.ServicePointManager.SecurityProtocol Or System.Net.SecurityProtocolType.Tls13 Or System.Net.SecurityProtocolType.Tls12)
End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
          If Not Application(Request.PhysicalPath) is Nothing Then
            Request.ContentEncoding = System.Text.Encoding.GetEncoding(Application(Request.PhysicalPath).ToString())
          End If
      
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
End Namespace
'End Global

