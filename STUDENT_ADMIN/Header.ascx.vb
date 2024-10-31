'Using Statements @1-82FB19C3
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics
Imports System.Web
Imports System.IO
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
Imports DECV_PROD2007.Controls
'End Using Statements

Namespace DECV_PROD2007.Header 'Namespace @1-69F39CD6

'Forms Definition @1-D5294B33
Public Class [HeaderPage]
Inherits CCUserControl
'End Forms Definition

'Forms Objects @1-5EB57695
    Protected HeaderContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-7F804C86
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.LinkMenuHref = "Menu.aspx"
            item.ImageLink1Href = "mailto:pcsupport@vsv.vic.edu.au"
            item.ImageLink1HrefParameters.Add("subject",System.Web.HttpUtility.UrlEncode(("New_SQLDB_Query").ToString()))
            item.ImageLink2Href = "http://intranet/REPORTS/Pages/Folder.aspx"
            PageData.FillItem(item)
            LinkMenu.InnerText += item.LinkMenu.GetFormattedValue().Replace(vbCrLf,"")
            LinkMenu.HRef = item.LinkMenuHref+item.LinkMenuHrefParameters.ToString("None","", ViewState)
            LinkMenu.DataBind()
            ImageLink1.ImageUrl += item.ImageLink1.GetFormattedValue()
            ImageLink1.NavigateUrl += item.ImageLink1Href+item.ImageLink1HrefParameters.ToString("GET","", ViewState).Replace("&amp;", "&")
            ImageLink1.DataBind()
            ImageLink2.ImageUrl += item.ImageLink2.GetFormattedValue()
            ImageLink2.NavigateUrl += item.ImageLink2Href+item.ImageLink2HrefParameters.ToString("None","", ViewState).Replace("&amp;", "&")
            ImageLink2.DataBind()
            lblnotifymessage.Text = Server.HtmlEncode(item.lblnotifymessage.GetFormattedValue()).Replace(vbCrLf,"<br>")
    End If
'End Page_Load Event BeforeIsPostBack

'Label lblnotifymessage Event BeforeShow. Action Retrieve Value for Control @12-295370DB
    lblnotifymessage.Text = (New TextField("", System.Web.HttpContext.Current.Session("notifymessage"))).GetFormattedValue()
'End Label lblnotifymessage Event BeforeShow. Action Retrieve Value for Control

'Label lblnotifymessage Event BeforeShow. Action Save Variable Value @13-7DC5B282
    HttpContext.Current.Session("notifymessage") = ""
'End Label lblnotifymessage Event BeforeShow. Action Save Variable Value

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-135C2C19
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        HeaderContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
'End OnInit Event Body

'OnInit Event tail @1-BB95D25C
    PageStyleName = Server.UrlEncode(PageStyleName)
    End Sub
'End OnInit Event tail

'InitializeComponent Event @1-EA5E2628
    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub
    #End Region
'End InitializeComponent Event

'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

