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

Namespace DECV_PROD2007.Menu_Student_maintain 'Namespace @1-457F377F

'Forms Definition @1-B3708E1B
Public Class [Menu_Student_maintainPage]
Inherits CCUserControl
'End Forms Definition

'Forms Objects @1-F165B69C
    Protected Menu_Student_maintainContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-06A42098
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.Link1Href = "StudentSummary.aspx"
            item.Link2Href = "StudentEnrolmentDetails_maintain.aspx"
            item.Link3Href = "Student_Census_maintain.aspx"
            item.Link4Href = "Student_Equipment_maintain.aspx"
            item.Link5Href = "Student_Medical_maintain.aspx"
            item.Link6Href = "Student_Address_panels_maintain.aspx"
            item.Link7Href = "Student_Subject_maintain.aspx"
            item.Link8Href = "FinancialAccounts_maintain.aspx"
            item.Link9Href = "Student_Comments_maintain.aspx"
            item.Link10Href = "Send_SMS_maintain.aspx"
            item.Link11Href = "Student_Carer_maintainext.aspx"
            item.LinkMenuHref = "Menu.aspx"
            item.Link12Href = "Student_Carer_FamilyGrouping.aspx"
            PageData.FillItem(item)
            Link1.InnerText += item.Link1.GetFormattedValue().Replace(vbCrLf,"")
            Link1.HRef = item.Link1Href+item.Link1HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link1.DataBind()
            Link2.InnerText += item.Link2.GetFormattedValue().Replace(vbCrLf,"")
            Link2.HRef = item.Link2Href+item.Link2HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link2.DataBind()
            Link3.InnerText += item.Link3.GetFormattedValue().Replace(vbCrLf,"")
            Link3.HRef = item.Link3Href+item.Link3HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link3.DataBind()
            Link4.InnerText += item.Link4.GetFormattedValue().Replace(vbCrLf,"")
            Link4.HRef = item.Link4Href+item.Link4HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link4.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf,"")
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link5.DataBind()
            Link6.InnerText += item.Link6.GetFormattedValue().Replace(vbCrLf,"")
            Link6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("GET","editmode", ViewState)
            Link6.DataBind()
            Link7.InnerText += item.Link7.GetFormattedValue().Replace(vbCrLf,"")
            Link7.HRef = item.Link7Href+item.Link7HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link7.DataBind()
            Link8.InnerText += item.Link8.GetFormattedValue().Replace(vbCrLf,"")
            Link8.HRef = item.Link8Href+item.Link8HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link8.DataBind()
            Link9.InnerText += item.Link9.GetFormattedValue().Replace(vbCrLf,"")
            Link9.HRef = item.Link9Href+item.Link9HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link9.DataBind()
            Link10.InnerText += item.Link10.GetFormattedValue().Replace(vbCrLf,"")
            Link10.HRef = item.Link10Href+item.Link10HrefParameters.ToString("GET","", ViewState)
            Link10.DataBind()
            Link11.InnerText += item.Link11.GetFormattedValue().Replace(vbCrLf,"")
            Link11.HRef = item.Link11Href+item.Link11HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link11.DataBind()
            LinkMenu.InnerText += item.LinkMenu.GetFormattedValue().Replace(vbCrLf,"")
            LinkMenu.HRef = item.LinkMenuHref+item.LinkMenuHrefParameters.ToString("None","", ViewState)
            LinkMenu.DataBind()
            Link12.InnerText += item.Link12.GetFormattedValue().Replace(vbCrLf,"")
            Link12.HRef = item.Link12Href+item.Link12HrefParameters.ToString("GET","flagattendingschool", ViewState)
            Link12.DataBind()
            lblnotifymessage.Text = Server.HtmlEncode(item.lblnotifymessage.GetFormattedValue()).Replace(vbCrLf,"<br>")
    End If
'End Page_Load Event BeforeIsPostBack

'Label lblnotifymessage Event BeforeShow. Action Retrieve Value for Control @21-295370DB
    lblnotifymessage.Text = (New TextField("", System.Web.HttpContext.Current.Session("notifymessage"))).GetFormattedValue()
'End Label lblnotifymessage Event BeforeShow. Action Retrieve Value for Control

'Label lblnotifymessage Event BeforeShow. Action Save Variable Value @22-7DC5B282
    HttpContext.Current.Session("notifymessage") = ""
'End Label lblnotifymessage Event BeforeShow. Action Save Variable Value

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-DD4CF489
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Menu_Student_maintainContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
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

