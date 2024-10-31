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

Namespace DECV_PROD2007.COMMENT_TYPE_maint 'Namespace @1-E267AC9D

'Forms Definition @1-9ADAD1FF
Public Class [COMMENT_TYPE_maintPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-07B6EC5B
    Protected COMMENT_TYPEData As COMMENT_TYPEDataProvider
    Protected COMMENT_TYPEOperations As FormSupportedOperations
    Protected COMMENT_TYPECurrentRowNumber As Integer
    Protected COMMENT_TYPESearchData As COMMENT_TYPESearchDataProvider
    Protected COMMENT_TYPESearchErrors As NameValueCollection = New NameValueCollection()
    Protected COMMENT_TYPESearchOperations As FormSupportedOperations
    Protected COMMENT_TYPESearchIsSubmitted As Boolean = False
    Protected COMMENT_TYPE1Data As COMMENT_TYPE1DataProvider
    Protected COMMENT_TYPE1Errors As NameValueCollection = New NameValueCollection()
    Protected COMMENT_TYPE1Operations As FormSupportedOperations
    Protected COMMENT_TYPE1IsSubmitted As Boolean = False
    Protected COMMENT_TYPE_maintContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-617EA17E
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            COMMENT_TYPEBind
            COMMENT_TYPESearchShow()
            COMMENT_TYPE1Show()
    End If
'End Page_Load Event BeforeIsPostBack

    End Sub 'Page_Load Event tail @1-E31F8E2A

'BeforeOutput Event @1-E563A382
Private Sub BeforeOutput(MainHTML As String, responseStream As Stream, ByRef Result As Boolean)
Result  = True
'End BeforeOutput Event

'BeforeOutput Event tail @1-E31F8E2A
End Sub
'End BeforeOutput Event tail

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Grid COMMENT_TYPE Bind @5-74ED8DF3

    Protected Sub COMMENT_TYPEBind()
        If Not COMMENT_TYPEOperations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"COMMENT_TYPE",GetType(COMMENT_TYPEDataProvider.SortFields), 20, 100)
        End If
'End Grid COMMENT_TYPE Bind

'Grid Form COMMENT_TYPE BeforeShow tail @5-D407EACE
        COMMENT_TYPEParameters()
        COMMENT_TYPEData.SortField = CType(ViewState("COMMENT_TYPESortField"),COMMENT_TYPEDataProvider.SortFields)
        COMMENT_TYPEData.SortDir = CType(ViewState("COMMENT_TYPESortDir"),SortDirections)
        COMMENT_TYPEData.PageNumber = CInt(ViewState("COMMENT_TYPEPageNumber"))
        COMMENT_TYPEData.RecordsPerPage = CInt(ViewState("COMMENT_TYPEPageSize"))
        COMMENT_TYPERepeater.DataSource = COMMENT_TYPEData.GetResultSet(PagesCount, COMMENT_TYPEOperations)
        ViewState("COMMENT_TYPEPagesCount") = PagesCount
        Dim item As COMMENT_TYPEItem = New COMMENT_TYPEItem()
        COMMENT_TYPERepeater.DataBind
        FooterIndex = COMMENT_TYPERepeater.Controls.Count - 1
        If PagesCount = 0 Then
            COMMENT_TYPERepeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim COMMENT_TYPECOMMENT_TYPE_Insert As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(COMMENT_TYPERepeater.Controls(FooterIndex).FindControl("COMMENT_TYPECOMMENT_TYPE_Insert"),System.Web.UI.HtmlControls.HtmlAnchor)
        Dim Sorter_COMMENT_TYPESorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_COMMENT_TYPESorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENT_DESCRIPTIONSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_COMMENT_DESCRIPTIONSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_STATUSSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_STATUSSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_PUBLIC_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_PUBLIC_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_SPECIAL_FLAGSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_SPECIAL_FLAGSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_COMMENT_HELPSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_COMMENT_HELPSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_BYSorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_BYSorter"),DECV_PROD2007.Controls.Sorter)
        Dim Sorter_LAST_ALTERED_DATESorter As DECV_PROD2007.Controls.Sorter = DirectCast(COMMENT_TYPERepeater.Controls(0).FindControl("Sorter_LAST_ALTERED_DATESorter"),DECV_PROD2007.Controls.Sorter)
        Dim NavigatorNavigator As DECV_PROD2007.Controls.Navigator = DirectCast(COMMENT_TYPERepeater.Controls(FooterIndex).FindControl("NavigatorNavigator"),DECV_PROD2007.Controls.Navigator)
        NavigatorNavigator.PageSizes = new Integer() {1,5,10,25,50}
        If PagesCount < 2 Then NavigatorNavigator.Visible = False

        item.COMMENT_TYPE_InsertHref = "COMMENT_TYPE_maint.aspx"
        COMMENT_TYPECOMMENT_TYPE_Insert.InnerText += item.COMMENT_TYPE_Insert.GetFormattedValue().Replace(vbCrLf,"")
        COMMENT_TYPECOMMENT_TYPE_Insert.HRef = item.COMMENT_TYPE_InsertHref+item.COMMENT_TYPE_InsertHrefParameters.ToString("GET","COMMENT_TYPE_ID", ViewState)
'End Grid Form COMMENT_TYPE BeforeShow tail

'Grid COMMENT_TYPE Bind tail @5-E31F8E2A
    End Sub
'End Grid COMMENT_TYPE Bind tail

'Grid COMMENT_TYPE Table Parameters @5-7BC62788

    Protected Sub COMMENT_TYPEParameters()
        Try
            COMMENT_TYPEData.Urls_keyword = TextParameter.GetParam("s_keyword", ParameterSourceType.URL, "", Nothing, false)

        Catch
            Dim ParentControls As ControlCollection=COMMENT_TYPERepeater.Parent.Controls
            Dim RepeaterIndex As Integer=ParentControls.IndexOf(COMMENT_TYPERepeater)
            ParentControls.RemoveAt(RepeaterIndex)
            Dim ErrorMessage as Literal=New Literal()
            ErrorMessage.Text="Error in Grid COMMENT_TYPE: Invalid parameter"
            ParentControls.AddAt(RepeaterIndex,ErrorMessage)
        End Try
    End Sub
'End Grid COMMENT_TYPE Table Parameters

'Grid COMMENT_TYPE ItemDataBound event @5-94F2BEA0

    Protected Sub COMMENT_TYPEItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as COMMENT_TYPEItem = CType(e.Item.DataItem,COMMENT_TYPEItem)
        Dim Item as COMMENT_TYPEItem = DataItem
        Dim FormDataSource As COMMENT_TYPEItem() = CType(COMMENT_TYPERepeater.DataSource, COMMENT_TYPEItem())
        Dim COMMENT_TYPEDataRows As Integer = FormDataSource.Length
        Dim COMMENT_TYPEIsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            COMMENT_TYPECurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(COMMENT_TYPERepeater,new CCSControlAttribute("rowNumber", FieldType._Integer, COMMENT_TYPECurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim COMMENT_TYPEDetail As System.Web.UI.HtmlControls.HtmlAnchor = DirectCast(e.Item.FindControl("COMMENT_TYPEDetail"),System.Web.UI.HtmlControls.HtmlAnchor)
            Dim COMMENT_TYPECOMMENT_TYPE1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPECOMMENT_TYPE1"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPECOMMENT_DESCRIPTION As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPECOMMENT_DESCRIPTION"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPESTATUS As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPESTATUS"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPEPUBLIC_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPEPUBLIC_FLAG"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPESPECIAL_FLAG As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPESPECIAL_FLAG"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPECOMMENT_HELP As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPECOMMENT_HELP"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPELAST_ALTERED_BY As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPELAST_ALTERED_BY"),System.Web.UI.WebControls.Literal)
            Dim COMMENT_TYPELAST_ALTERED_DATE As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("COMMENT_TYPELAST_ALTERED_DATE"),System.Web.UI.WebControls.Literal)
            DataItem.DetailHref = "COMMENT_TYPE_maint.aspx"
            COMMENT_TYPEDetail.HRef = DataItem.DetailHref & DataItem.DetailHrefParameters.ToString("GET","", ViewState)
        End If
'End Grid COMMENT_TYPE ItemDataBound event

'Grid COMMENT_TYPE ItemDataBound event tail @5-BD65CE74
        If COMMENT_TYPEIsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(COMMENT_TYPECurrentRowNumber, ListItemType.Item)
            COMMENT_TYPERepeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            COMMENT_TYPEItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid COMMENT_TYPE ItemDataBound event tail

'Grid COMMENT_TYPE ItemCommand event @5-42AA4BD4

    Protected Sub COMMENT_TYPEItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= COMMENT_TYPERepeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("COMMENT_TYPESortDir"),SortDirections) = SortDirections._Asc And ViewState("COMMENT_TYPESortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("COMMENT_TYPESortDir")=SortDirections._Desc
                Else
                    ViewState("COMMENT_TYPESortDir")=SortDirections._Asc
                End If
            Else
                ViewState("COMMENT_TYPESortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As COMMENT_TYPEDataProvider.SortFields = 0
            ViewState("COMMENT_TYPESortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("COMMENT_TYPEPageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("COMMENT_TYPEPageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("COMMENT_TYPEPageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("COMMENT_TYPEPageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            COMMENT_TYPEBind
        End If
    End Sub
'End Grid COMMENT_TYPE ItemCommand event

'Record Form COMMENT_TYPESearch Parameters @39-10DB5050

    Protected Sub COMMENT_TYPESearchParameters()
        Dim item As new COMMENT_TYPESearchItem
        Try
        Catch e As Exception
            COMMENT_TYPESearchErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form COMMENT_TYPESearch Parameters

'Record Form COMMENT_TYPESearch Show method @39-03B023BC
    Protected Sub COMMENT_TYPESearchShow()
        If COMMENT_TYPESearchOperations.None Then
            COMMENT_TYPESearchHolder.Visible = False
            Return
        End If
        Dim item As COMMENT_TYPESearchItem = COMMENT_TYPESearchItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not COMMENT_TYPESearchOperations.AllowRead
        item.ClearParametersHref = "COMMENT_TYPE_maint.aspx"
        COMMENT_TYPESearchErrors.Add(item.errors)
        If COMMENT_TYPESearchErrors.Count > 0 Then
            COMMENT_TYPESearchShowErrors()
            Return
        End If
'End Record Form COMMENT_TYPESearch Show method

'Record Form COMMENT_TYPESearch BeforeShow tail @39-00A74B0E
        COMMENT_TYPESearchParameters()
        COMMENT_TYPESearchData.FillItem(item, IsInsertMode)
        COMMENT_TYPESearchHolder.DataBind()
        COMMENT_TYPESearchClearParameters.InnerText += item.ClearParameters.GetFormattedValue().Replace(vbCrLf,"")
        COMMENT_TYPESearchClearParameters.HRef = item.ClearParametersHref+item.ClearParametersHrefParameters.ToString("GET","s_keyword", ViewState)
        COMMENT_TYPESearchs_keyword.Text=item.s_keyword.GetFormattedValue()
'End Record Form COMMENT_TYPESearch BeforeShow tail

'Record Form COMMENT_TYPESearch Show method tail @39-A2C64CE8
        If COMMENT_TYPESearchErrors.Count > 0 Then
            COMMENT_TYPESearchShowErrors()
        End If
    End Sub
'End Record Form COMMENT_TYPESearch Show method tail

'Record Form COMMENT_TYPESearch LoadItemFromRequest method @39-B9303A5F

    Protected Sub COMMENT_TYPESearchLoadItemFromRequest(item As COMMENT_TYPESearchItem, ByVal EnableValidation As Boolean)
        item.s_keyword.IsEmpty = IsNothing(Request.Form(COMMENT_TYPESearchs_keyword.UniqueID))
        If ControlCustomValues("COMMENT_TYPESearchs_keyword") Is Nothing Then
            item.s_keyword.SetValue(COMMENT_TYPESearchs_keyword.Text)
        Else
            item.s_keyword.SetValue(ControlCustomValues("COMMENT_TYPESearchs_keyword"))
        End If
        If EnableValidation Then
            item.Validate(COMMENT_TYPESearchData)
        End If
        COMMENT_TYPESearchErrors.Add(item.errors)
    End Sub
'End Record Form COMMENT_TYPESearch LoadItemFromRequest method

'Record Form COMMENT_TYPESearch GetRedirectUrl method @39-75351034

    Protected Function GetCOMMENT_TYPESearchRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "COMMENT_TYPE_maint.aspx"
        Dim p As String = parameters.ToString("None",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form COMMENT_TYPESearch GetRedirectUrl method

'Record Form COMMENT_TYPESearch ShowErrors method @39-6ACF3F78

    Protected Sub COMMENT_TYPESearchShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To COMMENT_TYPESearchErrors.Count - 1
        Select Case COMMENT_TYPESearchErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & COMMENT_TYPESearchErrors(i)
        End Select
        Next i
        COMMENT_TYPESearchError.Visible = True
        COMMENT_TYPESearchErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form COMMENT_TYPESearch ShowErrors method

'Record Form COMMENT_TYPESearch Insert Operation @39-6D8421CB

    Protected Sub COMMENT_TYPESearch_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        COMMENT_TYPESearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COMMENT_TYPESearch Insert Operation

'Record Form COMMENT_TYPESearch BeforeInsert tail @39-C36E076F
    COMMENT_TYPESearchParameters()
    COMMENT_TYPESearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COMMENT_TYPESearch BeforeInsert tail

'Record Form COMMENT_TYPESearch AfterInsert tail  @39-AF13890F
        ErrorFlag=(COMMENT_TYPESearchErrors.Count > 0)
        If ErrorFlag Then
            COMMENT_TYPESearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COMMENT_TYPESearch AfterInsert tail 

'Record Form COMMENT_TYPESearch Update Operation @39-DA19410B

    Protected Sub COMMENT_TYPESearch_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        COMMENT_TYPESearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COMMENT_TYPESearch Update Operation

'Record Form COMMENT_TYPESearch Before Update tail @39-C36E076F
        COMMENT_TYPESearchParameters()
        COMMENT_TYPESearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COMMENT_TYPESearch Before Update tail

'Record Form COMMENT_TYPESearch Update Operation tail @39-AF13890F
        ErrorFlag=(COMMENT_TYPESearchErrors.Count > 0)
        If ErrorFlag Then
            COMMENT_TYPESearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COMMENT_TYPESearch Update Operation tail

'Record Form COMMENT_TYPESearch Delete Operation @39-43EBC3CE
    Protected Sub COMMENT_TYPESearch_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        COMMENT_TYPESearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form COMMENT_TYPESearch Delete Operation

'Record Form BeforeDelete tail @39-C36E076F
        COMMENT_TYPESearchParameters()
        COMMENT_TYPESearchLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @39-94DE825F
        If ErrorFlag Then
            COMMENT_TYPESearchShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form COMMENT_TYPESearch Cancel Operation @39-F6FF4A20

    Protected Sub COMMENT_TYPESearch_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        COMMENT_TYPESearchIsSubmitted = True
        Dim RedirectUrl As String = ""
        COMMENT_TYPESearchLoadItemFromRequest(item, True)
'End Record Form COMMENT_TYPESearch Cancel Operation

'Record Form COMMENT_TYPESearch Cancel Operation tail @39-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form COMMENT_TYPESearch Cancel Operation tail

'Record Form COMMENT_TYPESearch Search Operation @39-92274DA2
    Protected Sub COMMENT_TYPESearch_Search(ByVal sender As Object, ByVal e As System.EventArgs)
        COMMENT_TYPESearchIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = True
        Dim item As COMMENT_TYPESearchItem = New COMMENT_TYPESearchItem()
        COMMENT_TYPESearchLoadItemFromRequest(item, EnableValidation)
'End Record Form COMMENT_TYPESearch Search Operation

'Button Button_DoSearch OnClick. @41-DA57399B
        If CType(sender,Control).ID = "COMMENT_TYPESearchButton_DoSearch" Then
            RedirectUrl = GetCOMMENT_TYPESearchRedirectUrl("", "s_keyword")
            EnableValidation  = True
'End Button Button_DoSearch OnClick.

'Button Button_DoSearch OnClick tail. @41-477CF3C9
        End If
'End Button Button_DoSearch OnClick tail.

'Record Form COMMENT_TYPESearch Search Operation tail @39-BFB80017
        ErrorFlag = COMMENT_TYPESearchErrors.Count > 0
        If ErrorFlag Then
            COMMENT_TYPESearchShowErrors()
        Else
            Dim Params As String = ""
            Dim li As ListItem
            Params = Params & IIf(COMMENT_TYPESearchs_keyword.Text <> "",("s_keyword=" & Server.UrlEncode(COMMENT_TYPESearchs_keyword.Text) & "&"), "")
            If Not RedirectUrl.EndsWith("?") Then
                RedirectUrl &= "&" &Params
            Else
                RedirectUrl &= Params
            End If
            RedirectUrl = RedirectUrl.TrimEnd(New Char(){"&"C})
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COMMENT_TYPESearch Search Operation tail

'Record Form COMMENT_TYPE1 Parameters @44-DAF4CF36

    Protected Sub COMMENT_TYPE1Parameters()
        Dim item As new COMMENT_TYPE1Item
        Try
            COMMENT_TYPE1Data.UrlCOMMENT_TYPE_ID = IntegerParameter.GetParam("COMMENT_TYPE_ID", ParameterSourceType.URL, "", Nothing, false)
        Catch e As Exception
            COMMENT_TYPE1Errors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form COMMENT_TYPE1 Parameters

'Record Form COMMENT_TYPE1 Show method @44-2624EB6A
    Protected Sub COMMENT_TYPE1Show()
        If COMMENT_TYPE1Operations.None Then
            COMMENT_TYPE1Holder.Visible = False
            Return
        End If
        Dim item As COMMENT_TYPE1Item = COMMENT_TYPE1Item.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not COMMENT_TYPE1Operations.AllowRead
        COMMENT_TYPE1Errors.Add(item.errors)
        If COMMENT_TYPE1Errors.Count > 0 Then
            COMMENT_TYPE1ShowErrors()
            Return
        End If
'End Record Form COMMENT_TYPE1 Show method

'Record Form COMMENT_TYPE1 BeforeShow tail @44-F28262DF
        COMMENT_TYPE1Parameters()
        COMMENT_TYPE1Data.FillItem(item, IsInsertMode)
        COMMENT_TYPE1Holder.DataBind()
        COMMENT_TYPE1Button_Insert.Visible=IsInsertMode AndAlso COMMENT_TYPE1Operations.AllowInsert
        COMMENT_TYPE1Button_Update.Visible=Not (IsInsertMode) AndAlso COMMENT_TYPE1Operations.AllowUpdate
        COMMENT_TYPE1COMMENT_TYPE2.Text=item.COMMENT_TYPE2.GetFormattedValue()
        COMMENT_TYPE1COMMENT_DESCRIPTION.Text=item.COMMENT_DESCRIPTION.GetFormattedValue()
        item.PUBLIC_FLAGItems.SetSelection(item.PUBLIC_FLAG.GetFormattedValue())
        COMMENT_TYPE1PUBLIC_FLAG.SelectedIndex = -1
        item.PUBLIC_FLAGItems.CopyTo(COMMENT_TYPE1PUBLIC_FLAG.Items, True)
        item.SPECIAL_FLAGItems.SetSelection(item.SPECIAL_FLAG.GetFormattedValue())
        COMMENT_TYPE1SPECIAL_FLAG.SelectedIndex = -1
        item.SPECIAL_FLAGItems.CopyTo(COMMENT_TYPE1SPECIAL_FLAG.Items, True)
        item.STATUSItems.SetSelection(item.STATUS.GetFormattedValue())
        COMMENT_TYPE1STATUS.SelectedIndex = -1
        item.STATUSItems.CopyTo(COMMENT_TYPE1STATUS.Items, True)
        COMMENT_TYPE1LAST_ALTERED_BY.Value = item.LAST_ALTERED_BY.GetFormattedValue()
        COMMENT_TYPE1LAST_ALTERED_DATE.Value = item.LAST_ALTERED_DATE.GetFormattedValue()
        COMMENT_TYPE1COMMENT_HELP.Text=item.COMMENT_HELP.GetFormattedValue()
        COMMENT_TYPE1lblCOMMENT_TYPE.Text = Server.HtmlEncode(item.lblCOMMENT_TYPE.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Record Form COMMENT_TYPE1 BeforeShow tail

'Record COMMENT_TYPE1 Event BeforeShow. Action Custom Code @108-73254650
    ' -------------------------
    '23-April-2015|EA| once COMMENT_TYPE entered it can't be changed or chaos will reign
    If (IsInsertMode) Then
    	'Add Mode
    	COMMENT_TYPE1lblCOMMENT_TYPE.Visible = False
    	COMMENT_TYPE1COMMENT_TYPE2.Visible = True
  	Else
    	'Edit Mode
    	COMMENT_TYPE1lblCOMMENT_TYPE.Visible = True
    	COMMENT_TYPE1COMMENT_TYPE2.Visible = False
  	End If

    ' -------------------------
'End Record COMMENT_TYPE1 Event BeforeShow. Action Custom Code

'Record Form COMMENT_TYPE1 Show method tail @44-388B6373
        If COMMENT_TYPE1Errors.Count > 0 Then
            COMMENT_TYPE1ShowErrors()
        End If
    End Sub
'End Record Form COMMENT_TYPE1 Show method tail

'Record Form COMMENT_TYPE1 LoadItemFromRequest method @44-5DD13CCC

    Protected Sub COMMENT_TYPE1LoadItemFromRequest(item As COMMENT_TYPE1Item, ByVal EnableValidation As Boolean)
        item.COMMENT_TYPE2.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1COMMENT_TYPE2.UniqueID))
        If ControlCustomValues("COMMENT_TYPE1COMMENT_TYPE2") Is Nothing Then
            item.COMMENT_TYPE2.SetValue(COMMENT_TYPE1COMMENT_TYPE2.Text)
        Else
            item.COMMENT_TYPE2.SetValue(ControlCustomValues("COMMENT_TYPE1COMMENT_TYPE2"))
        End If
        item.COMMENT_DESCRIPTION.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1COMMENT_DESCRIPTION.UniqueID))
        If ControlCustomValues("COMMENT_TYPE1COMMENT_DESCRIPTION") Is Nothing Then
            item.COMMENT_DESCRIPTION.SetValue(COMMENT_TYPE1COMMENT_DESCRIPTION.Text)
        Else
            item.COMMENT_DESCRIPTION.SetValue(ControlCustomValues("COMMENT_TYPE1COMMENT_DESCRIPTION"))
        End If
        Try
        item.PUBLIC_FLAG.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1PUBLIC_FLAG.UniqueID))
        If Not IsNothing(COMMENT_TYPE1PUBLIC_FLAG.SelectedItem) Then
            item.PUBLIC_FLAG.SetValue(COMMENT_TYPE1PUBLIC_FLAG.SelectedItem.Value)
        Else
            item.PUBLIC_FLAG.Value = Nothing
        End If
        item.PUBLIC_FLAGItems.CopyFrom(COMMENT_TYPE1PUBLIC_FLAG.Items)
        Catch ae As ArgumentException
            COMMENT_TYPE1Errors.Add("PUBLIC_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"PUBLIC FLAG"))
        End Try
        Try
        item.SPECIAL_FLAG.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1SPECIAL_FLAG.UniqueID))
        If Not IsNothing(COMMENT_TYPE1SPECIAL_FLAG.SelectedItem) Then
            item.SPECIAL_FLAG.SetValue(COMMENT_TYPE1SPECIAL_FLAG.SelectedItem.Value)
        Else
            item.SPECIAL_FLAG.Value = Nothing
        End If
        item.SPECIAL_FLAGItems.CopyFrom(COMMENT_TYPE1SPECIAL_FLAG.Items)
        Catch ae As ArgumentException
            COMMENT_TYPE1Errors.Add("SPECIAL_FLAG",String.Format(Resources.strings.CCS_IncorrectValue,"SPECIAL FLAG"))
        End Try
        Try
        item.STATUS.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1STATUS.UniqueID))
        If Not IsNothing(COMMENT_TYPE1STATUS.SelectedItem) Then
            item.STATUS.SetValue(COMMENT_TYPE1STATUS.SelectedItem.Value)
        Else
            item.STATUS.Value = Nothing
        End If
        item.STATUSItems.CopyFrom(COMMENT_TYPE1STATUS.Items)
        Catch ae As ArgumentException
            COMMENT_TYPE1Errors.Add("STATUS",String.Format(Resources.strings.CCS_IncorrectValue,"STATUS"))
        End Try
        item.LAST_ALTERED_BY.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1LAST_ALTERED_BY.UniqueID))
        item.LAST_ALTERED_BY.SetValue(COMMENT_TYPE1LAST_ALTERED_BY.Value)
        Try
        item.LAST_ALTERED_DATE.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1LAST_ALTERED_DATE.UniqueID))
        item.LAST_ALTERED_DATE.SetValue(COMMENT_TYPE1LAST_ALTERED_DATE.Value)
        Catch ae As ArgumentException
            COMMENT_TYPE1Errors.Add("LAST_ALTERED_DATE",String.Format(Resources.strings.CCS_IncorrectFormat,"LAST ALTERED DATE","dd/mm/yyyy h:nn AM/PM"))
        End Try
        item.COMMENT_HELP.IsEmpty = IsNothing(Request.Form(COMMENT_TYPE1COMMENT_HELP.UniqueID))
        If ControlCustomValues("COMMENT_TYPE1COMMENT_HELP") Is Nothing Then
            item.COMMENT_HELP.SetValue(COMMENT_TYPE1COMMENT_HELP.Text)
        Else
            item.COMMENT_HELP.SetValue(ControlCustomValues("COMMENT_TYPE1COMMENT_HELP"))
        End If
        If EnableValidation Then
            item.Validate(COMMENT_TYPE1Data)
        End If
        COMMENT_TYPE1Errors.Add(item.errors)
    End Sub
'End Record Form COMMENT_TYPE1 LoadItemFromRequest method

'Record Form COMMENT_TYPE1 GetRedirectUrl method @44-0CB4A18E

    Protected Function GetCOMMENT_TYPE1RedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = Request.Url.AbsolutePath
        Dim p As String = parameters.ToString("GET","COMMENT_TYPE_ID;" + removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form COMMENT_TYPE1 GetRedirectUrl method

'Record Form COMMENT_TYPE1 ShowErrors method @44-B063E6A5

    Protected Sub COMMENT_TYPE1ShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To COMMENT_TYPE1Errors.Count - 1
        Select Case COMMENT_TYPE1Errors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & COMMENT_TYPE1Errors(i)
        End Select
        Next i
        COMMENT_TYPE1Error.Visible = True
        COMMENT_TYPE1ErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form COMMENT_TYPE1 ShowErrors method

'Record Form COMMENT_TYPE1 Insert Operation @44-B7FF4A2C

    Protected Sub COMMENT_TYPE1_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPE1Item = New COMMENT_TYPE1Item()
        Dim ExecuteFlag As Boolean = True
        COMMENT_TYPE1IsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COMMENT_TYPE1 Insert Operation

'Button Button_Insert OnClick. @46-1B3FA635
        If CType(sender,Control).ID = "COMMENT_TYPE1Button_Insert" Then
            RedirectUrl = GetCOMMENT_TYPE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @46-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record COMMENT_TYPE1 Event BeforeInsert. Action Retrieve Value for Control @111-7734728D
        COMMENT_TYPE1COMMENT_TYPE2.Text = (New TextField("", (COMMENT_TYPE1COMMENT_TYPE2.Text.ToUpper))).GetFormattedValue()
'End Record COMMENT_TYPE1 Event BeforeInsert. Action Retrieve Value for Control

'Record Form COMMENT_TYPE1 BeforeInsert tail @44-EA62C8B0
    COMMENT_TYPE1Parameters()
    COMMENT_TYPE1LoadItemFromRequest(item, EnableValidation)
    If COMMENT_TYPE1Operations.AllowInsert Then
        ErrorFlag=(COMMENT_TYPE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                COMMENT_TYPE1Data.InsertItem(item)
            Catch ex As Exception
                COMMENT_TYPE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form COMMENT_TYPE1 BeforeInsert tail

'Record Form COMMENT_TYPE1 AfterInsert tail  @44-94C382AE
        End If
        ErrorFlag=(COMMENT_TYPE1Errors.Count > 0)
        If ErrorFlag Then
            COMMENT_TYPE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COMMENT_TYPE1 AfterInsert tail 

'Record Form COMMENT_TYPE1 Update Operation @44-7C2F7E98

    Protected Sub COMMENT_TYPE1_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPE1Item = New COMMENT_TYPE1Item()
        item.IsNew = False
        Dim ExecuteFlag As Boolean = True
        Dim ErrorFlag As Boolean = False
        COMMENT_TYPE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form COMMENT_TYPE1 Update Operation

'Button Button_Update OnClick. @47-9FF738AA
        If CType(sender,Control).ID = "COMMENT_TYPE1Button_Update" Then
            RedirectUrl = GetCOMMENT_TYPE1RedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @47-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record COMMENT_TYPE1 Event BeforeUpdate. Action Retrieve Value for Control @109-1345ABF8
        COMMENT_TYPE1LAST_ALTERED_BY.Value = (New TextField("", (dbutility.userid.tostring))).GetFormattedValue()
'End Record COMMENT_TYPE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record COMMENT_TYPE1 Event BeforeUpdate. Action Retrieve Value for Control @110-FC9A2C89
        COMMENT_TYPE1LAST_ALTERED_DATE.Value = (New DateField("dd\/MM\/yyyy h\:mm tt", (Now()))).GetFormattedValue()
'End Record COMMENT_TYPE1 Event BeforeUpdate. Action Retrieve Value for Control

'Record Form COMMENT_TYPE1 Before Update tail @44-50236D0D
        COMMENT_TYPE1Parameters()
        COMMENT_TYPE1LoadItemFromRequest(item, EnableValidation)
        If COMMENT_TYPE1Operations.AllowUpdate Then
        ErrorFlag = (COMMENT_TYPE1Errors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                COMMENT_TYPE1Data.UpdateItem(item)
            Catch ex As Exception
                COMMENT_TYPE1Errors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form COMMENT_TYPE1 Before Update tail

'Record Form COMMENT_TYPE1 Update Operation tail @44-94C382AE
        End If
        ErrorFlag=(COMMENT_TYPE1Errors.Count > 0)
        If ErrorFlag Then
            COMMENT_TYPE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form COMMENT_TYPE1 Update Operation tail

'Record Form COMMENT_TYPE1 Delete Operation @44-D69BD1DE
    Protected Sub COMMENT_TYPE1_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        COMMENT_TYPE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As COMMENT_TYPE1Item = New COMMENT_TYPE1Item()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form COMMENT_TYPE1 Delete Operation

'Record Form BeforeDelete tail @44-799037A7
        COMMENT_TYPE1Parameters()
        COMMENT_TYPE1LoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @44-5711CBE5
        If ErrorFlag Then
            COMMENT_TYPE1ShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form COMMENT_TYPE1 Cancel Operation @44-5B1C21BE

    Protected Sub COMMENT_TYPE1_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As COMMENT_TYPE1Item = New COMMENT_TYPE1Item()
        COMMENT_TYPE1IsSubmitted = True
        Dim RedirectUrl As String = ""
        COMMENT_TYPE1LoadItemFromRequest(item, False)
'End Record Form COMMENT_TYPE1 Cancel Operation

'Button Button_Cancel OnClick. @48-A71398EC
    If CType(sender,Control).ID = "COMMENT_TYPE1Button_Cancel" Then
        RedirectUrl = GetCOMMENT_TYPE1RedirectUrl("", "")
'End Button Button_Cancel OnClick.

'Button Button_Cancel OnClick tail. @48-477CF3C9
    End If
'End Button Button_Cancel OnClick tail.

'Record Form COMMENT_TYPE1 Cancel Operation tail @44-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form COMMENT_TYPE1 Cancel Operation tail

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-FF9941C7
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        COMMENT_TYPE_maintContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        COMMENT_TYPEData = New COMMENT_TYPEDataProvider()
        COMMENT_TYPEOperations = New FormSupportedOperations(False, True, False, False, False)
        COMMENT_TYPESearchData = New COMMENT_TYPESearchDataProvider()
        COMMENT_TYPESearchOperations = New FormSupportedOperations(False, True, True, True, True)
        COMMENT_TYPE1Data = New COMMENT_TYPE1DataProvider()
        COMMENT_TYPE1Operations = New FormSupportedOperations(False, True, True, True, False)
        Dim filter As New ResponseFilter(Response.Filter)
        AddHandler filter.OnFilterClose, AddressOf Me.BeforeOutput
        Response.Filter = filter
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

