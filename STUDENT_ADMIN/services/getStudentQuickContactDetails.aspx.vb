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

Namespace DECV_PROD2007.services.getStudentQuickContactDetails 'Namespace @1-FF31C0B8

'Forms Definition @1-4FD5D063
Public Class [getStudentQuickContactDetailsPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-5E36044A
    Protected sps_StudentQuickContactLoData As sps_StudentQuickContactLoDataProvider
    Protected sps_StudentQuickContactLoOperations As FormSupportedOperations
    Protected sps_StudentQuickContactLoCurrentRowNumber As Integer
    Protected getStudentQuickContactDetailsContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-D7DAEB10
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, "../"), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            sps_StudentQuickContactLoBind
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid sps_StudentQuickContactLo Bind @2-9B9DA5D6

    Protected Sub sps_StudentQuickContactLoBind()
        If Not sps_StudentQuickContactLoOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"sps_StudentQuickContactLo",GetType(sps_StudentQuickContactLoDataProvider.SortFields), 10, 100)
        End If
'End Grid sps_StudentQuickContactLo Bind

'Grid Form sps_StudentQuickContactLo BeforeShow tail @2-2E63F746
        sps_StudentQuickContactLoParameters()
        sps_StudentQuickContactLoData.SortField = CType(ViewState("sps_StudentQuickContactLoSortField"),sps_StudentQuickContactLoDataProvider.SortFields)
        sps_StudentQuickContactLoData.SortDir = CType(ViewState("sps_StudentQuickContactLoSortDir"),SortDirections)
        sps_StudentQuickContactLoData.PageNumber = CInt(ViewState("sps_StudentQuickContactLoPageNumber"))
        sps_StudentQuickContactLoData.RecordsPerPage = CInt(ViewState("sps_StudentQuickContactLoPageSize"))
        sps_StudentQuickContactLoRepeater.DataSource = sps_StudentQuickContactLoData.GetResultSet(PagesCount, sps_StudentQuickContactLoOperations)
        ViewState("sps_StudentQuickContactLoPagesCount") = PagesCount
        Dim item As sps_StudentQuickContactLoItem = New sps_StudentQuickContactLoItem()
        sps_StudentQuickContactLoRepeater.DataBind
        FooterIndex = sps_StudentQuickContactLoRepeater.Controls.Count - 1

'End Grid Form sps_StudentQuickContactLo BeforeShow tail

'Grid sps_StudentQuickContactLo Bind tail @2-E31F8E2A
    End Sub
'End Grid sps_StudentQuickContactLo Bind tail

'Grid sps_StudentQuickContactLo Table Parameters @2-B9E44880

    Protected Sub sps_StudentQuickContactLoParameters()
        Try
            sps_StudentQuickContactLoData.Urlterm = TextParameter.GetParam("term", ParameterSourceType.URL, "", Nothing, false)
            sps_StudentQuickContactLoData.Urlstaffid = TextParameter.GetParam("staffid", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=sps_StudentQuickContactLoRepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(sps_StudentQuickContactLoRepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid sps_StudentQuickContactLo: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid sps_StudentQuickContactLo Table Parameters

'Grid sps_StudentQuickContactLo ItemDataBound event @2-467765B2

    Protected Sub sps_StudentQuickContactLoItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as sps_StudentQuickContactLoItem = CType(e.Item.DataItem,sps_StudentQuickContactLoItem)
        Dim Item as sps_StudentQuickContactLoItem = DataItem
        Dim FormDataSource As sps_StudentQuickContactLoItem() = CType(sps_StudentQuickContactLoRepeater.DataSource, sps_StudentQuickContactLoItem())
        Dim sps_StudentQuickContactLoDataRows As Integer = FormDataSource.Length
        Dim sps_StudentQuickContactLoIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            sps_StudentQuickContactLoCurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(sps_StudentQuickContactLoRepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, sps_StudentQuickContactLoCurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim sps_StudentQuickContactLostudent_id As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("sps_StudentQuickContactLostudent_id"),System.Web.UI.WebControls.Literal)
            Dim sps_StudentQuickContactLoStudentName1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("sps_StudentQuickContactLoStudentName1"),System.Web.UI.WebControls.Literal)
        End If
'End Grid sps_StudentQuickContactLo ItemDataBound event

'Grid sps_StudentQuickContactLo ItemDataBound event tail @2-C9B14150
        If sps_StudentQuickContactLoIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(sps_StudentQuickContactLoCurrentRowNumber, ListItemType.Item)
            sps_StudentQuickContactLoRepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            sps_StudentQuickContactLoItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid sps_StudentQuickContactLo ItemDataBound event tail

'Grid sps_StudentQuickContactLo ItemCommand event @2-BD9A8EF5

    Protected Sub sps_StudentQuickContactLoItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= sps_StudentQuickContactLoRepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("sps_StudentQuickContactLoSortDir"),SortDirections) = SortDirections._Asc And ViewState("sps_StudentQuickContactLoSortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("sps_StudentQuickContactLoSortDir")=SortDirections._Desc
                Else
                    ViewState("sps_StudentQuickContactLoSortDir")=SortDirections._Asc
                End If
            Else
                ViewState("sps_StudentQuickContactLoSortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As sps_StudentQuickContactLoDataProvider.SortFields = 0
            ViewState("sps_StudentQuickContactLoSortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("sps_StudentQuickContactLoPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("sps_StudentQuickContactLoPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("sps_StudentQuickContactLoPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("sps_StudentQuickContactLoPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            sps_StudentQuickContactLoBind
        End If
    End Sub
'End Grid sps_StudentQuickContactLo ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-6EB44FD8
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        getStudentQuickContactDetailsContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        InitializeComponent()
        MyBase.OnInit(e)
        sps_StudentQuickContactLoData = New sps_StudentQuickContactLoDataProvider()
        sps_StudentQuickContactLoOperations = New FormSupportedOperations(False, True, False, False, False)
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

