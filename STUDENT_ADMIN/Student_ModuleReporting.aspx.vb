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

Namespace DECV_PROD2007.Student_ModuleReporting 'Namespace @1-21B735DB

'Forms Definition @1-77FA47C6
Public Class [Student_ModuleReportingPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2628571E
    Protected SCAFFOLD_MODULE_GRADE_SCAData As SCAFFOLD_MODULE_GRADE_SCADataProvider
    Protected SCAFFOLD_MODULE_GRADE_SCAOperations As FormSupportedOperations
    Protected Student_ModuleReportingContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-D345AA2F
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            item.link_MenuHref = "Menu.aspx"
            item.Link_SearchRequestHref = "MaintainSearchRequest.aspx"
            item.link_AssignmentsHref = "AssignmentSubmissionList.aspx"
            item.Link10Href = "Send_SMS_maintain.aspx"
            item.Link6Href = "Student_Future_Intentions.aspx"
            item.Link5Href = "Student_Comments_maintain.aspx"
            item.Link_BacktosummaryHref = "StudentSummary.aspx"
            item.Link_BacktoPastoralListHref = "PastoralTeacher_StudentList.aspx"
            item.linkExternalReportHref = "http://intranet/ReportServer?/Staff+Reports/Module+Reporting&rs:Command=Render&"
            item.linkExternalReportHrefParameters.Add("StudentID",Request.QueryString,"STUDENT_ID")
            PageData.FillItem(item)
            link_Menu.InnerText += item.link_Menu.GetFormattedValue().Replace(vbCrLf,"")
            link_Menu.HRef = item.link_MenuHref+item.link_MenuHrefParameters.ToString("None","", ViewState)
            link_Menu.DataBind()
            Link_SearchRequest.InnerText += item.Link_SearchRequest.GetFormattedValue().Replace(vbCrLf,"")
            Link_SearchRequest.HRef = item.Link_SearchRequestHref+item.Link_SearchRequestHrefParameters.ToString("GET","", ViewState)
            Link_SearchRequest.DataBind()
            link_Assignments.InnerText += item.link_Assignments.GetFormattedValue().Replace(vbCrLf,"")
            link_Assignments.HRef = item.link_AssignmentsHref+item.link_AssignmentsHrefParameters.ToString("GET","", ViewState)
            link_Assignments.DataBind()
            Link10.InnerText += item.Link10.GetFormattedValue().Replace(vbCrLf,"")
            Link10.HRef = item.Link10Href+item.Link10HrefParameters.ToString("GET","", ViewState)
            Link10.DataBind()
            Link6.InnerText += item.Link6.GetFormattedValue().Replace(vbCrLf,"")
            Link6.HRef = item.Link6Href+item.Link6HrefParameters.ToString("GET","", ViewState)
            Link6.DataBind()
            Link5.InnerText += item.Link5.GetFormattedValue().Replace(vbCrLf,"")
            Link5.HRef = item.Link5Href+item.Link5HrefParameters.ToString("GET","", ViewState)
            Link5.DataBind()
            Link_Backtosummary.InnerText += item.Link_Backtosummary.GetFormattedValue().Replace(vbCrLf,"")
            Link_Backtosummary.HRef = item.Link_BacktosummaryHref+item.Link_BacktosummaryHrefParameters.ToString("GET","", ViewState)
            Link_Backtosummary.DataBind()
            Link_BacktoPastoralList.InnerText += item.Link_BacktoPastoralList.GetFormattedValue().Replace(vbCrLf,"")
            Link_BacktoPastoralList.HRef = item.Link_BacktoPastoralListHref+item.Link_BacktoPastoralListHrefParameters.ToString("None","", ViewState)
            Link_BacktoPastoralList.DataBind()
            linkExternalReport.InnerText += item.linkExternalReport.GetFormattedValue().Replace(vbCrLf,"")
            linkExternalReport.HRef = item.linkExternalReportHref+item.linkExternalReportHrefParameters.ToString("None","", ViewState)
            linkExternalReport.DataBind()
            SCAFFOLD_MODULE_GRADE_SCABind
    End If
'End Page_Load Event BeforeIsPostBack

'Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code @16-73254650
    ' -------------------------
    'ERA: if in the proper groups then display Maintain panel (eg: 8 doesn't see it but 9 does.
    '23-July-2015|EA| convert to global setting incase we need to add a new group in future
	dim strHigherGroups as String = System.Configuration.ConfigurationManager.AppSettings("strHigherSecurityGroups") 
    dim arrHigherGroups as String() = strHigherGroups.split(",")
	 'If (DBUtility.AuthorizeUser(New String(){"2","3","4","5","6","7","9","12"})) Then
	 If (DBUtility.AuthorizeUser(arrHigherGroups)) Then
            Panel_MenuStudentMaintain.visible = true
     End If
    ' -------------------------
'End Panel Panel_MenuStudentMaintain Event BeforeShow. Action Custom Code

'Link linkExternalReport Event BeforeShow. Action Custom Code @242-73254650
    ' -------------------------
    '23 Mar-2017|EA| adjust parameter for StudentID so can be passed to ReportingServer (
    linkExternalReport.HRef = linkExternalReport.HRef.Replace("&?","&")

    ' -------------------------
'End Link linkExternalReport Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Report SCAFFOLD_MODULE_GRADE_SCA Bind @23-C0C4F235
    Protected Sub SCAFFOLD_MODULE_GRADE_SCABind()
        If Not SCAFFOLD_MODULE_GRADE_SCAOperations.AllowRead Then Return
        If Not IsPostBack Then
            DBUtility.InitializeGridParameters(ViewState,"SCAFFOLD_MODULE_GRADE_SCA",GetType(SCAFFOLD_MODULE_GRADE_SCADataProvider.SortFields), 0, 200)
        End If
'End Report SCAFFOLD_MODULE_GRADE_SCA Bind

'Report Form SCAFFOLD_MODULE_GRADE_SCA BeforeShow tail @23-AA9B14FB
        SCAFFOLD_MODULE_GRADE_SCAParameters
        SCAFFOLD_MODULE_GRADE_SCAData.SortField = CType(ViewState("SCAFFOLD_MODULE_GRADE_SCASortField"),SCAFFOLD_MODULE_GRADE_SCADataProvider.SortFields)
        SCAFFOLD_MODULE_GRADE_SCAData.SortDir = CType(ViewState("SCAFFOLD_MODULE_GRADE_SCASortDir"),SortDirections)
        SCAFFOLD_MODULE_GRADE_SCA.DataSource = SCAFFOLD_MODULE_GRADE_SCAData.GetResultSet(SCAFFOLD_MODULE_GRADE_SCAOperations)
        SCAFFOLD_MODULE_GRADE_SCA.DataBind()
'End Report Form SCAFFOLD_MODULE_GRADE_SCA BeforeShow tail

	End Sub 'Report SCAFFOLD_MODULE_GRADE_SCA Bind tail @23-E31F8E2A

'Report SCAFFOLD_MODULE_GRADE_SCA Table Parameters @23-AEAD6D24

    Protected Sub SCAFFOLD_MODULE_GRADE_SCAParameters()
        Try
            SCAFFOLD_MODULE_GRADE_SCAData.UrlSTUDENT_ID = TextParameter.GetParam("STUDENT_ID", ParameterSourceType.URL, "", 56794, false)

        Catch
            Dim ParentControls As ControlCollection=SCAFFOLD_MODULE_GRADE_SCA.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(SCAFFOLD_MODULE_GRADE_SCA)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid SCAFFOLD_MODULE_GRADE_SCA: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Report SCAFFOLD_MODULE_GRADE_SCA Table Parameters

'Report SCAFFOLD_MODULE_GRADE_SCA BeforeShowSection event @23-B34364D7
    Protected Sub SCAFFOLD_MODULE_GRADE_SCABeforeShowSection(Sender As Object , e As BeforeShowSectionEventArgs)
        Dim DataItem As SCAFFOLD_MODULE_GRADE_SCAItem  = CType(e.Item.DataItem, SCAFFOLD_MODULE_GRADE_SCAItem)
        Dim Item As SCAFFOLD_MODULE_GRADE_SCAItem  = DataItem
        If IsNothing(DataItem) Then DataItem = New SCAFFOLD_MODULE_GRADE_SCAItem()
        Select e.Item.name
            Case "Report_Header"
            Case "Page_Header"
            Case "SCAFFOLD_USER_student_id_Header"
                Dim SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_id As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_id"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_firstname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_firstname"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_lastname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCASCAFFOLD_USER_student_lastname"),ReportLabel)
            Case "shortname_Header"
                Dim SCAFFOLD_MODULE_GRADE_SCAshortname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAshortname"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAfullname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAfullname"),ReportLabel)
            Case "Detail"
                Dim SCAFFOLD_MODULE_GRADE_SCAname As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAname"),System.Web.UI.HtmlControls.HtmlAnchor)
                Dim SCAFFOLD_MODULE_GRADE_SCAdategraded As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAdategraded"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAstr_long_grade As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAstr_long_grade"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAstr_feedback As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAstr_feedback"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAfirstname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAfirstname"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAlastname As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAlastname"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAlblgradestyle As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAlblgradestyle"),ReportLabel)
                Dim SCAFFOLD_MODULE_GRADE_SCAessentialquestion As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAessentialquestion"),ReportLabel)
                DataItem.nameHref = "https://lms.decvonline.vic.edu.au/mod/assign/view.php"
                SCAFFOLD_MODULE_GRADE_SCAname.HRef = DataItem.nameHref & DataItem.nameHrefParameters.ToString("None","", ViewState)
            Case "shortname_Footer"
            Case "SCAFFOLD_USER_student_id_Footer"
            Case "Report_Footer"
                Dim SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport"),System.Web.UI.HtmlControls.HtmlAnchor)
                DataItem.linkExternalReportHref = "http://intranet/ReportServer?/Staff+Reports/Module+Reporting&rs:Command=Render&"
                DataItem.linkExternalReportHrefParameters.Add("StudentID",Request.QueryString,"STUDENT_ID")
                SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport.HRef = DataItem.linkExternalReportHref & DataItem.linkExternalReportHrefParameters.ToString("None","", ViewState)
            Case "Page_Footer"
                Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(e.Item.FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        End Select
'End Report SCAFFOLD_MODULE_GRADE_SCA BeforeShowSection event

		Select e.Item.name 'BeforeShow events @23-4EF46BEF

			case "Detail": 'Section Detail BeforeShow events @51-D5562AB6

'Get str_feedback control @64-E86676C1
                Dim SCAFFOLD_MODULE_GRADE_SCAstr_feedback As ReportLabel = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAstr_feedback"),ReportLabel)
'End Get str_feedback control

'ReportLabel str_feedback Event BeforeShow. Action Custom Code @141-73254650
    ' -------------------------
    '29-Oct-2015|EA| convert the HTML junk into HTML to retain formatting
    SCAFFOLD_MODULE_GRADE_SCAstr_feedback.Text = Server.HtmlDecode(SCAFFOLD_MODULE_GRADE_SCAstr_feedback.Text)
    '1-June-2017|EA| and strip out the <a> to reduce error with HTML links
    ' Regular Expressions namespace added at top of file (Note: above HtmlDecode converts the &lt; to <, so the Regex works)
    SCAFFOLD_MODULE_GRADE_SCAstr_feedback.Text = Regex.Replace(SCAFFOLD_MODULE_GRADE_SCAstr_feedback.Text, "</?(a|A).*?>", "")
    ' -------------------------
'End ReportLabel str_feedback Event BeforeShow. Action Custom Code

			case "Report_Footer": 'Section Report_Footer BeforeShow events @54-60B7C39E

'Get linkExternalReport control @239-2855C64E
                Dim SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get linkExternalReport control

'Link linkExternalReport Event BeforeShow. Action Custom Code @240-73254650
    ' -------------------------
    '23 Mar-2017|EA| adjust parameter for StudentID so can be passed to ReportingServer (
    SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport.HRef = SCAFFOLD_MODULE_GRADE_SCAlinkExternalReport.HRef.Replace("&?","&")
    ' -------------------------
'End Link linkExternalReport Event BeforeShow. Action Custom Code

		End Select 'BeforeShow events @23-3508C6CC

    End Sub 'Section SCAFFOLD_MODULE_GRADE_SCA BeforeShow events tail @23-E31F8E2A

'Report SCAFFOLD_MODULE_GRADE_SCA ItemCommand event @23-AF49C5DB
    Protected Sub SCAFFOLD_MODULE_GRADE_SCAItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("SCAFFOLD_MODULE_GRADE_SCASortDir"),SortDirections) = SortDirections._Asc And ViewState("SCAFFOLD_MODULE_GRADE_SCASortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("SCAFFOLD_MODULE_GRADE_SCASortDir")=SortDirections._Desc
                Else
                    ViewState("SCAFFOLD_MODULE_GRADE_SCASortDir")=SortDirections._Asc
                End If
            Else
                ViewState("SCAFFOLD_MODULE_GRADE_SCASortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As SCAFFOLD_MODULE_GRADE_SCADataProvider.SortFields = 0
            ViewState("SCAFFOLD_MODULE_GRADE_SCASortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("SCAFFOLD_MODULE_GRADE_SCAPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            SCAFFOLD_MODULE_GRADE_SCA.PreviewPageNumber = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            SCAFFOLD_MODULE_GRADE_SCABind
        End If
    End Sub
'End Report SCAFFOLD_MODULE_GRADE_SCA ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-9640DBBD
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_ModuleReportingContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        SCAFFOLD_MODULE_GRADE_SCAData = new SCAFFOLD_MODULE_GRADE_SCADataProvider()
        SCAFFOLD_MODULE_GRADE_SCAOperations = New FormSupportedOperations(False, True, False, False, False)
        AddHandler SCAFFOLD_MODULE_GRADE_SCA.ItemCommand, AddressOf Me.SCAFFOLD_MODULE_GRADE_SCAItemCommand
        AddHandler SCAFFOLD_MODULE_GRADE_SCA.BeforeShowSection, AddressOf Me.SCAFFOLD_MODULE_GRADE_SCABeforeShowSection
        SCAFFOLD_MODULE_GRADE_SCA.Groups.Add("SCAFFOLD_USER_student_id","SCAFFOLD_USER_student_idGroupField")
        SCAFFOLD_MODULE_GRADE_SCA.Groups.Add("shortname","shortnameGroupField")
        If Request("ViewMode") Is Nothing Then SCAFFOLD_MODULE_GRADE_SCA.ViewMode= ReportViewMode.Web
        If Not(User.Identity.IsAuthenticated) Then
            Response.Redirect(Settings.AccessDeniedUrl & "?ret_link=" & Server.UrlEncode(Request("SCRIPT_NAME") & "?" & Request("QUERY_STRING")))
        End If
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

