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

Namespace DECV_PROD2007.Student_AdvisoryGroup_Export 'Namespace @1-C3932ED2

'Forms Definition @1-B428C545
Public Class [Student_AdvisoryGroup_ExportPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-0C4BA466
    Protected Students_GridData As Students_GridDataProvider
    Protected Students_GridOperations As FormSupportedOperations
    Protected Students_GridCurrentRowNumber As Integer
    Protected Student_AdvisoryGroup_ExportContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event


'Page Student_AdvisoryGroup_Export Event OnInitializeView. Action Custom Code @116-73254650
    ' -------------------------
    
   	'ERA: 09-Mar-2018|EA| this page ALWAYS export to Excel
    	Dim ExportFileName As String
    	ExportFileName = "StudentAdvisoryList.xls"
    	'Set Content type to Excel
    	Response.ContentType = "application/vnd.ms-excel"
    	'Fix IE 5.0-5.5 bug with Content-Disposition=attachment
    	If  Request.ServerVariables.Get("HTTP_USER_AGENT").IndexOf("MSIE 5.5;") <> -1 Or _
    		Request.ServerVariables.Get("HTTP_USER_AGENT").IndexOf("MSIE 5.0;") <> -1 Then
  		Response.AddHeader("Content-Disposition", "filename=" & ExportFileName & ";")
  	Else
  			Response.AddHeader("Content-Disposition", "attachment; filename=" & ExportFileName & ";")
  	End If
    ' -------------------------
'End Page Student_AdvisoryGroup_Export Event OnInitializeView. Action Custom Code

'Page_Load Event BeforeIsPostBack @1-60D4B6B7
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            Students_GridBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A


'Grid Students_Grid Bind @25-D8CD1BCF

    Protected Sub Students_GridBind()
        If Not Students_GridOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"Students_Grid",GetType(Students_GridDataProvider.SortFields), 100, 150)
        End If
'End Grid Students_Grid Bind

'Grid Form Students_Grid BeforeShow tail @25-FC48C50A
        Students_GridParameters()
        Students_GridData.SortField = CType(ViewState("Students_GridSortField"),Students_GridDataProvider.SortFields)
        Students_GridData.SortDir = CType(ViewState("Students_GridSortDir"),SortDirections)
        Students_GridData.PageNumber = CInt(ViewState("Students_GridPageNumber"))
        Students_GridData.RecordsPerPage = CInt(ViewState("Students_GridPageSize"))
        Students_GridRepeater.DataSource = Students_GridData.GetResultSet(PagesCount, Students_GridOperations)
        ViewState("Students_GridPagesCount") = PagesCount
        Dim item As Students_GridItem = New Students_GridItem()
        Students_GridRepeater.DataBind
        FooterIndex = Students_GridRepeater.Controls.Count - 1
        If PagesCount = 0 Then
            Students_GridRepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If

'End Grid Form Students_Grid BeforeShow tail

'Grid Students_Grid Bind tail @25-E31F8E2A
    End Sub
'End Grid Students_Grid Bind tail

'Grid Students_Grid Table Parameters @25-32D30A01

    Protected Sub Students_GridParameters()
        Try
            Students_GridData.Expr160 = TextParameter.GetParam(DBUtility.UserLogin.ToUpper, ParameterSourceType.Expression, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=Students_GridRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(Students_GridRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid Students_Grid: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid Students_Grid Table Parameters

'Grid Students_Grid ItemDataBound event @25-2DEBF73B

    Protected Sub Students_GridItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as Students_GridItem = CType(e.Item.DataItem,Students_GridItem)
        Dim Item as Students_GridItem = DataItem
        Dim FormDataSource As Students_GridItem() = CType(Students_GridRepeater.DataSource, Students_GridItem())
        Dim Students_GridDataRows As Integer = FormDataSource.Length
        Dim Students_GridIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Students_GridCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(Students_GridRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, Students_GridCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Students_GridSURNAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSURNAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridFIRST_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridFIRST_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSCHOOL_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSCHOOL_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSTUDENT_ID As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridSTUDENT_ID"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridQuickContact As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridQuickContact"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridContacts As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridContacts"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridPHONE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridPHONE1"),System.Web.UI.WebControls.Literal)
            Dim Students_GridEMAIL1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridEMAIL1"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridEMAIL2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridEMAIL2"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridPHONE2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridPHONE2"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSUBJECT_ABBREV As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSUBJECT_ABBREV"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSTAFF_ID As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSTAFF_ID"),System.Web.UI.WebControls.Literal)
            Dim Students_Gridlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_Gridlabel_ALERTS"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSCHOOL_SUPER_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSCHOOL_SUPER_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSCHOOL_SUPER_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridSCHOOL_SUPER_PHONE"),System.Web.UI.WebControls.Literal)
            Dim Students_GridSCHOOL_SUPER_EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridSCHOOL_SUPER_EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridPARENT_NAME As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridPARENT_NAME"),System.Web.UI.WebControls.Literal)
            Dim Students_GridPARENT_MOBILE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridPARENT_MOBILE"),System.Web.UI.WebControls.Literal)
            Dim Students_GridPARENT_PHONE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridPARENT_PHONE"),System.Web.UI.WebControls.Literal)
            Dim Students_GridPARENT_EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridPARENT_EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim Students_GridENROLMENT_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridENROLMENT_DATE"),System.Web.UI.WebControls.Literal)
            Dim Students_GridLAD As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_GridLAD"),System.Web.UI.WebControls.Literal)
            DataItem.STUDENT_IDHref = "StudentSummary.aspx"
            Students_GridSTUDENT_ID.HRef = Settings.ServerURL +DataItem.STUDENT_IDHref & DataItem.STUDENT_IDHrefParameters.ToString("None","", ViewState)
            DataItem.QuickContactHref = "WinLogin/StudentContactQuickEntry.aspx"
            Students_GridQuickContact.HRef = Settings.ServerURL +DataItem.QuickContactHref & DataItem.QuickContactHrefParameters.ToString("None","", ViewState)
            DataItem.ContactsHref = "Student_Comments_maintain.aspx"
            Students_GridContacts.HRef = Settings.ServerURL +DataItem.ContactsHref & DataItem.ContactsHrefParameters.ToString("None","", ViewState)
            Students_GridEMAIL1.HRef = DataItem.EMAIL1Href & DataItem.EMAIL1HrefParameters.ToString("None","", ViewState)
            Students_GridEMAIL2.HRef = DataItem.EMAIL2Href & DataItem.EMAIL2HrefParameters.ToString("None","", ViewState)
            Students_GridSCHOOL_SUPER_EMAIL.HRef = DataItem.SCHOOL_SUPER_EMAILHref & DataItem.SCHOOL_SUPER_EMAILHrefParameters.ToString("GET","", ViewState)
            Students_GridPARENT_EMAIL.HRef = DataItem.PARENT_EMAILHref & DataItem.PARENT_EMAILHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid Students_Grid ItemDataBound event

'Students_Grid control Before Show @25-EBC08450
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
'End Students_Grid control Before Show

'Get Control @128-7F378D5A
            Dim Students_GridEMAIL1 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridEMAIL1"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL1 Event BeforeShow. Action Custom Code @130-73254650
    ' -------------------------
	' ERA: 2011-01-28 change to mailto link with Subject
	' NOTE Form name ...Students_Grid
		DataItem.EMAIL1HrefParameters.Add("subject",("Message from VSV").ToString())
  		if not IsDBNull(DataItem.EMAIL1Href) then
  			Students_GridEMAIL1.HRef = "mailto:" + DataItem.EMAIL1Href & DataItem.EMAIL1HrefParameters.ToString("None","", ViewState)
	  	end if
    ' -------------------------
'End Link EMAIL1 Event BeforeShow. Action Custom Code

'Get Control @129-C0A38819
            Dim Students_GridEMAIL2 As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridEMAIL2"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link EMAIL2 Event BeforeShow. Action Custom Code @131-73254650
    ' -------------------------
	' ERA: 2011-01-28 change to mailto link with Subject
	' NOTE Form name ...Students_Grid
		DataItem.EMAIL2HrefParameters.Add("subject",("Message from VSV").ToString())
  		if not IsDBNull(DataItem.EMAIL2Href) then
  			Students_GridEMAIL2.HRef = "mailto:" + DataItem.EMAIL2Href & DataItem.EMAIL2HrefParameters.ToString("None","", ViewState)
	  	end if
    ' -------------------------
'End Link EMAIL2 Event BeforeShow. Action Custom Code

'Get Control @140-4FC3D295
            Dim Students_Gridlabel_ALERTS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("Students_Gridlabel_ALERTS"),System.Web.UI.WebControls.Literal)
'End Get Control

'Label label_ALERTS Event BeforeShow. Action Declare Variable @141-E947C756
            Dim intAlerts As Int64 = 0
'End Label label_ALERTS Event BeforeShow. Action Declare Variable

'Label label_ALERTS Event BeforeShow. Action DLookup @142-862826E4
            intAlerts = CType((New IntegerField("",Settings.connDECVPRODSQL2005DataAccessObject.ExecuteScalar("SELECT " & "count(student_id)" & " FROM " & "[view_StudentSummary_Alerts]" & " WHERE " & "STUDENT_ID = " &  DataItem.STUDENT_ID.GetFormattedValue() & ""))).Value, Int64)
'End Label label_ALERTS Event BeforeShow. Action DLookup

'Label label_ALERTS Event BeforeShow. Action Custom Code @143-73254650
    ' -------------------------
    Students_Gridlabel_ALERTS.Visible = false
	Students_Gridlabel_ALERTS.Text = "<font color='red'><b>Alert!</b></font>"

    if (intAlerts > 0) then
		Students_Gridlabel_ALERTS.Visible = true
	end if
    ' -------------------------
'End Label label_ALERTS Event BeforeShow. Action Custom Code

'Get Control @146-7E7BFBC2
            Dim Students_GridSCHOOL_SUPER_EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridSCHOOL_SUPER_EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link SCHOOL_SUPER_EMAIL Event BeforeShow. Action Custom Code @147-73254650
    ' -------------------------
	' ERA: 2011-10-24 change to mailto link with Subject, copied from above postal address
	' NOTE Form name ...Students_Grid
		if not (DataItem.school_super_email.getformattedvalue() = "N/A") then
			DataItem.SCHOOL_SUPER_EMAILHrefParameters.Add("subject",("Message from VSV").ToString())
	  		if not IsDBNull(DataItem.SCHOOL_SUPER_EMAILHref) then
  				Students_GridSCHOOL_SUPER_EMAIL.HRef = "mailto:" + DataItem.SCHOOL_SUPER_EMAILHref & DataItem.SCHOOL_SUPER_EMAILHrefParameters.ToString("None","", ViewState)
	  		end if
		else
			Students_GridSCHOOL_SUPER_EMAIL.Visible = false
		end if
    ' -------------------------
'End Link SCHOOL_SUPER_EMAIL Event BeforeShow. Action Custom Code

'Get Control @152-7D190F7D
            Dim Students_GridPARENT_EMAIL As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("Students_GridPARENT_EMAIL"),System.Web.UI.HtmlControls.HtmlAnchor)
'End Get Control

'Link PARENT_EMAIL Event BeforeShow. Action Custom Code @153-73254650
    ' -------------------------
	' ERA: 2012-06-18 change to mailto link with Subject, copied from above School email
	' NOTE Form name ...Students_Grid
		if not (DataItem.parent_email.getformattedvalue() = "N/A") then
			DataItem.parent_emailhrefparameters.Add("subject",("Message from VSV").ToString())
	  		if not IsDBNull(DataItem.parent_emailhref) then
  				Students_GridPARENT_EMAIL.HRef = "mailto:" + DataItem.parent_emailhref & DataItem.parent_emailhrefparameters.ToString("None","", ViewState)
	  		end if
		else
			Students_GridPARENT_EMAIL.Visible = false
		end if
    ' -------------------------
'End Link PARENT_EMAIL Event BeforeShow. Action Custom Code

'Students_Grid control Before Show tail @25-477CF3C9
        End If
'End Students_Grid control Before Show tail

'Grid Students_Grid ItemDataBound event tail @25-036507A9
        If Students_GridIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(Students_GridCurrentRowNumber, ListItemType.Item)
            Students_GridRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            Students_GridItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid Students_Grid ItemDataBound event tail

'Grid Students_Grid ItemCommand event @25-65BA42CA

    Protected Sub Students_GridItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= Students_GridRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("Students_GridSortDir"),SortDirections) = SortDirections._Asc And ViewState("Students_GridSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("Students_GridSortDir")=SortDirections._Desc
                Else
                    ViewState("Students_GridSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("Students_GridSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As Students_GridDataProvider.SortFields = 0
            ViewState("Students_GridSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("Students_GridPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("Students_GridPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("Students_GridPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("Students_GridPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            Students_GridBind
        End If
    End Sub
'End Grid Students_Grid ItemCommand event


'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-732B2A00
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        Student_AdvisoryGroup_ExportContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        Students_GridData = New Students_GridDataProvider()
        Students_GridOperations = New FormSupportedOperations(True, True, False, False, False)
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

