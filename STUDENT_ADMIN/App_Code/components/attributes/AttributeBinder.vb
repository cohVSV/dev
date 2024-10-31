'AttributeBinder class @0-7E390ED1
'Target Framework version is 3.5
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Web.UI.HtmlControls
Imports System.Security.Permissions
Imports System.Web.UI.WebControls


Namespace DECV_PROD2007.Controls
    _
   Public Class AttributeBinder
      Inherits WebControl
      
      Public Property ContainerId() As String
         Get
            Return CStr(ViewState("ContainerId"))
         End Get
         Set
            ViewState("ContainerId") = value
         End Set
      End Property 
      
      
      Public Property Name() As String
         Get
            Return CStr(ViewState("Name"))
         End Get
         Set
            ViewState("Name") = value
         End Set
      End Property
      
      
      Protected Property Val() As String
         Get
            Return CStr(ViewState("Val"))
         End Get
         Set
            ViewState("Val") = value
         End Set
      End Property
      
      Public Sub New()
      End Sub 'New
      
      
      Protected Overrides Sub OnPreRender(e As EventArgs)
         Dim ctl As Control = Nothing
         Dim con As AttributesContainer = CType(Page, CCPage).ControlAttributes
         If ContainerId = "pageAttribute" Then
            ctl = Page
         Else
            Dim container As Control = NamingContainer
            
            While Not (container Is Nothing) And ctl Is Nothing
               ctl = container.FindControl(ContainerId)
               container = container.NamingContainer
            End While
            
            If TypeOf NamingContainer Is RepeaterItem AndAlso(con(ctl) Is Nothing OrElse con(ctl)(Name) Is Nothing) Then
               ctl = NamingContainer
            End If
         End If 
         If Not (con(ctl) Is Nothing) AndAlso Not (con(ctl)(Name) Is Nothing) Then
            Val = Convert.ToString(con(ctl)(Name))
         End If
      End Sub 'OnPreRender
       
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         writer.Write(Val)
      End Sub 'Render
   End Class 'AttributeBinder
End Namespace 'T_C_MSSQL_IIS.Controls

'End AttributeBinder class

