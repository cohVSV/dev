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

Namespace DECV_PROD2007.FileUpload 'Namespace @1-62FAA141

'Forms Definition @1-65554F78
Public Class [FileUploadPage]
Inherits CCPage
'End Forms Definition

'Forms Objects @1-2769A511
    Protected UploadRecordData As UploadRecordDataProvider
    Protected UploadRecordErrors As NameValueCollection = New NameValueCollection()
    Protected UploadRecordOperations As FormSupportedOperations
    Protected UploadRecordIsSubmitted As Boolean = False
    Protected DataGrid1Data As DataGrid1DataProvider
    Protected DataGrid1Operations As FormSupportedOperations
    Protected DataGrid1CurrentRowNumber As Integer
    Protected FileUploadContentMeta As String
'End Forms Objects

'Page_Load Event @1-A2D2CF1E
Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
'End Page_Load Event

'Page_Load Event BeforeIsPostBack @1-01C073FD
    Dim item As PageItem = PageItem.CreateFromHttpRequest()
    ControlAttributes.Add(Page, New CCSControlAttribute("pathToRoot", FieldType._Text, ""), AttributeOption.Multiple)
    If Not IsPostBack Then
            Dim PageData As PageDataProvider = New PageDataProvider()
            PageData.FillItem(item)
            lblFilename.Text = Server.HtmlEncode(item.lblFilename.GetFormattedValue()).Replace(vbCrLf,"<br>")
            UploadRecordShow()
            DataGrid1Bind
    End If
'End Page_Load Event BeforeIsPostBack

'Page FileUpload Event BeforeShow. Action Custom Code @19-73254650
    ' -------------------------
    ' ERA: handle loading of file into Grid
	If not IsPostBack Then
		DataGrid1Repeater.visible = false
	end if

	if IsPostBack then
		DataGrid1Repeater.visible = true
		' call the parser
		dim FullFilePathName as string = "./uploads/" & UploadRecordFileUpload1.Text
		lblFilename.Text = Server.HtmlEncode(FullFilePathName)
	    Dim dt As DataTable = ParseCSVFile(Server.MapPath(FullFilePathName))
	    ' bind the resulting DataTable to a DataGrid Web Control
	    DataGrid1Repeater.DataSource = dt
	    DataGrid1Bind
	end if
    ' -------------------------
'End Page FileUpload Event BeforeShow. Action Custom Code

    End Sub 'Page_Load Event tail @1-E31F8E2A

 Protected Overrides Sub OnUnload(ByVal e As System.EventArgs) 'Page_Unload Event @1-D998A98F

    End Sub 'Page_Unload Event tail @1-E31F8E2A

'Record Form UploadRecord Parameters @2-2E4DD2EB

    Protected Sub UploadRecordParameters()
        Dim item As new UploadRecordItem
        Try
        Catch e As Exception
            UploadRecordErrors.Add("Parameters","Form Parameters: " + e.Message)
        End Try
    End Sub
'End Record Form UploadRecord Parameters

'Record Form UploadRecord Show method @2-4075233B
    Protected Sub UploadRecordShow()
        If UploadRecordOperations.None Then
            UploadRecordHolder.Visible = False
            Return
        End If
        Dim item As UploadRecordItem = UploadRecordItem.CreateFromHttpRequest()
        Dim IsInsertMode As Boolean = Not UploadRecordOperations.AllowRead
        UploadRecordErrors.Add(item.errors)
        If UploadRecordErrors.Count > 0 Then
            UploadRecordShowErrors()
            Return
        End If
'End Record Form UploadRecord Show method

'Record Form UploadRecord BeforeShow tail @2-B5499765
        UploadRecordParameters()
        UploadRecordData.FillItem(item, IsInsertMode)
        UploadRecordHolder.DataBind()
        UploadRecordButton_Insert.Visible=IsInsertMode AndAlso UploadRecordOperations.AllowInsert
        UploadRecordButton_Update.Visible=Not (IsInsertMode) AndAlso UploadRecordOperations.AllowUpdate
        UploadRecordButton_Delete.Visible=Not (IsInsertMode) AndAlso UploadRecordOperations.AllowDelete
        Try
            UploadRecordFileUpload1.FileFolder = "uploads"
        Catch ex As System.IO.DirectoryNotFoundException
            UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_FilesFolderNotFound,"File Upload"))
        Catch ex As System.Security.SecurityException
            UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_InsufficientPermissions,"File Upload"))
        End Try
        Try
            UploadRecordFileUpload1.TemporaryFolder = "%TEMP"
        Catch ex As System.IO.DirectoryNotFoundException
            UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_TempFolderNotFound,"File Upload"))
        Catch ex As System.Security.SecurityException
            UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_TempInsufficientPermissions,"File Upload"))
        End Try
        UploadRecordFileUpload1.AllowedFileMasks = "*.txt;"
        UploadRecordFileUpload1.DisallowedFileMasks = "*.exe;*.sql;*.bat;*.dll;*.com"
        UploadRecordFileUpload1.FileSizeLimit = 5000000
        UploadRecordFileUpload1.Required = True
        Try
            UploadRecordFileUpload1.Text=item.FileUpload1.GetFormattedValue()
        Catch ex As System.IO.FileNotFoundException
            Dim FileName As String = item.FileUpload1.GetFormattedValue()
            item.errors.Add("FileUpload1",String.Format(Resources.strings.CCS_FileNotFound,Item.FileUpload1.GetFormattedValue(),"File Upload"))
        End Try
'End Record Form UploadRecord BeforeShow tail

'Record Form UploadRecord Show method tail @2-47635516
        If UploadRecordErrors.Count > 0 Then
            UploadRecordShowErrors()
        End If
    End Sub
'End Record Form UploadRecord Show method tail

'Record Form UploadRecord LoadItemFromRequest method @2-49BC1F0A

    Protected Sub UploadRecordLoadItemFromRequest(item As UploadRecordItem, ByVal EnableValidation As Boolean)
        Try
            UploadRecordFileUpload1.ValidateFile()
            item.FileUpload1.SetValue(UploadRecordFileUpload1.Text)
        Catch ex As InvalidOperationException 
            If ex.Message = "The file type is not allowed." Then
                UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_WrongType,"File Upload"))
            End If
            If ex.Message = "The file is too large." Then
                UploadRecordErrors.Add("FileUpload1",String.Format(Resources.strings.CCS_LargeFile,"File Upload"))
            End If
        End Try
        item.FileUpload1.IsEmpty = UploadRecordFileUpload1.IsEmpty
        If EnableValidation Then
            item.Validate(UploadRecordData)
        End If
        UploadRecordErrors.Add(item.errors)
    End Sub
'End Record Form UploadRecord LoadItemFromRequest method

'Record Form UploadRecord GetRedirectUrl method @2-F821E3D2

    Protected Function GetUploadRecordRedirectUrl(ByVal redirect As String, ByVal removeList As String) As String
        Dim parameters As New LinkParameterCollection()
        If redirect = "" Then redirect = "FileUpload.aspx"
        Dim p As String = parameters.ToString("GET",removeList,ViewState)
        If p = "" Then p = "?"
        p = p.Replace("&amp;", "&")
        Return redirect + p
    End Function
'End Record Form UploadRecord GetRedirectUrl method

'Record Form UploadRecord ShowErrors method @2-0E35A414

    Protected Sub UploadRecordShowErrors()
        Dim DefaultMessage As String = ""
        Dim i As Integer
        For i = 0 To UploadRecordErrors.Count - 1
        Select Case UploadRecordErrors.AllKeys(i)
            Case Else
                If DefaultMessage  <> "" Then DefaultMessage &= "<br>"
                DefaultMessage = DefaultMessage & UploadRecordErrors(i)
        End Select
        Next i
        UploadRecordError.Visible = True
        UploadRecordErrorLabel.Text = DefaultMessage
    End Sub
'End Record Form UploadRecord ShowErrors method

'Record Form UploadRecord Insert Operation @2-F0B05005

    Protected Sub UploadRecord_Insert(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UploadRecordItem = New UploadRecordItem()
        Dim ExecuteFlag As Boolean = True
        UploadRecordIsSubmitted = True
        Dim ErrorFlag As Boolean = False
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UploadRecord Insert Operation

'Button Button_Insert OnClick. @4-C837C735
        If CType(sender,Control).ID = "UploadRecordButton_Insert" Then
            RedirectUrl = GetUploadRecordRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Insert OnClick.

'Button Button_Insert OnClick tail. @4-477CF3C9
        End If
'End Button Button_Insert OnClick tail.

'Record Form UploadRecord BeforeInsert tail @2-817C1517
    UploadRecordParameters()
    UploadRecordLoadItemFromRequest(item, EnableValidation)
    If UploadRecordOperations.AllowInsert Then
        ErrorFlag=(UploadRecordErrors.Count > 0)
        If ExecuteFlag And (Not ErrorFlag) Then
            Try
                UploadRecordData.InsertItem(item)
            Catch ex As Exception
                UploadRecordErrors.Add("DataProvider",ex.Message)
                ErrorFlag = True
            End Try
        End If
'End Record Form UploadRecord BeforeInsert tail

'Record Form UploadRecord AfterInsert tail  @2-888C3F76
            If Not(ErrorFlag) Then
                UploadRecordFileUpload1.SaveFile()
            End If
        End If
        ErrorFlag=(UploadRecordErrors.Count > 0)
        If ErrorFlag Then
            UploadRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UploadRecord AfterInsert tail 

'Record Form UploadRecord Update Operation @2-4577F8B1

    Protected Sub UploadRecord_Update(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UploadRecordItem = New UploadRecordItem()
        item.IsNew = False
        Dim ErrorFlag As Boolean = False
        UploadRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
'End Record Form UploadRecord Update Operation

'Button Button_Update OnClick. @5-BEE88626
        If CType(sender,Control).ID = "UploadRecordButton_Update" Then
            RedirectUrl = GetUploadRecordRedirectUrl("", "")
            EnableValidation  = True
'End Button Button_Update OnClick.

'Button Button_Update OnClick tail. @5-477CF3C9
        End If
'End Button Button_Update OnClick tail.

'Record Form UploadRecord Before Update tail @2-C2792F17
        UploadRecordParameters()
        UploadRecordLoadItemFromRequest(item, EnableValidation)
'End Record Form UploadRecord Before Update tail

'Record Form UploadRecord Update Operation tail @2-F836057F
            If Not(ErrorFlag) Then
                UploadRecordFileUpload1.SaveFile()
            End If
        ErrorFlag=(UploadRecordErrors.Count > 0)
        If ErrorFlag Then
            UploadRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form UploadRecord Update Operation tail

'Record Form UploadRecord Delete Operation @2-59F92E77
    Protected Sub UploadRecord_Delete(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ErrorFlag As Boolean = False
        UploadRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        Dim EnableValidation As Boolean = False
        Dim item As UploadRecordItem = New UploadRecordItem()
        item.IsNew  = False
        item.IsDeleted  = True
'End Record Form UploadRecord Delete Operation

'Button Button_Delete OnClick. @6-7B152EBD
        If CType(sender,Control).ID = "UploadRecordButton_Delete" Then
            RedirectUrl = GetUploadRecordRedirectUrl("", "")
            EnableValidation  = False
'End Button Button_Delete OnClick.

'Button Button_Delete OnClick tail. @6-477CF3C9
        End If
'End Button Button_Delete OnClick tail.

'Record Form BeforeDelete tail @2-C2792F17
        UploadRecordParameters()
        UploadRecordLoadItemFromRequest(item, EnableValidation)
'End Record Form BeforeDelete tail

'Record Form AfterDelete tail @2-47771B96
            If Not(ErrorFlag) Then
                UploadRecordFileUpload1.DeleteFile()
            End If
        If ErrorFlag Then
            UploadRecordShowErrors()
        Else
            Response.Redirect(RedirectUrl)
        End If
    End Sub
'End Record Form AfterDelete tail

'Record Form UploadRecord Cancel Operation @2-D4AC6220

    Protected Sub UploadRecord_Cancel(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As UploadRecordItem = New UploadRecordItem()
        UploadRecordIsSubmitted = True
        Dim RedirectUrl As String = ""
        UploadRecordLoadItemFromRequest(item, True)
'End Record Form UploadRecord Cancel Operation

'Record Form UploadRecord Cancel Operation tail @2-EA2B0FFB
        Response.Redirect(RedirectUrl)
    End Sub
'End Record Form UploadRecord Cancel Operation tail

'Grid DataGrid1 Bind @20-A83CFBF8

    Protected Sub DataGrid1Bind()
        If Not DataGrid1Operations.AllowRead Then Return
        Dim PagesCount As Integer
        Dim FooterIndex As Integer
        If Not(IsPostBack) Then
            DBUtility.InitializeGridParameters(ViewState,"DataGrid1",GetType(DataGrid1DataProvider.SortFields), 50, -1)
        End If
'End Grid DataGrid1 Bind

'Grid Form DataGrid1 BeforeShow tail @20-5420D39F
        DataGrid1Data.SortField = CType(ViewState("DataGrid1SortField"),DataGrid1DataProvider.SortFields)
        DataGrid1Data.SortDir = CType(ViewState("DataGrid1SortDir"),SortDirections)
        DataGrid1Data.PageNumber = CInt(ViewState("DataGrid1PageNumber"))
        DataGrid1Data.RecordsPerPage = CInt(ViewState("DataGrid1PageSize"))
        DataGrid1Repeater.DataSource = DataGrid1Data.GetResultSet(PagesCount, DataGrid1Operations)
        ViewState("DataGrid1PagesCount") = PagesCount
        Dim item As DataGrid1Item = New DataGrid1Item()
        CType(Page,CCPage).ControlAttributes.Add(DataGrid1Repeater,New CCSControlAttribute("RowNumber", FieldType._Text, Nothing))
        DataGrid1Repeater.DataBind
        FooterIndex = DataGrid1Repeater.Controls.Count - 1
        If PagesCount = 0 Then
            DataGrid1Repeater.Controls(FooterIndex).FindControl("NoRecords").Visible = True
        End If
        Dim DataGrid1DataGrid1_TotalRecords As System.Web.UI.WebControls.Literal = DirectCast(DataGrid1Repeater.Controls(0).FindControl("DataGrid1DataGrid1_TotalRecords"),System.Web.UI.WebControls.Literal)

        DataGrid1DataGrid1_TotalRecords.Text = Server.HtmlEncode(item.DataGrid1_TotalRecords.GetFormattedValue()).Replace(vbCrLf,"<br>")
'End Grid Form DataGrid1 BeforeShow tail

'Label DataGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records @22-9669C7AE
            DataGrid1DataGrid1_TotalRecords.Text = DataGrid1Data.RecordCount.ToString()
'End Label DataGrid1_TotalRecords Event BeforeShow. Action Retrieve number of records

'Grid DataGrid1 Bind tail @20-E31F8E2A
    End Sub
'End Grid DataGrid1 Bind tail

'Grid DataGrid1 ItemDataBound event @20-1068AC7A

    Protected Sub DataGrid1ItemDataBound(Sender as Object, e as RepeaterItemEventArgs)
        Dim DataItem as DataGrid1Item = CType(e.Item.DataItem,DataGrid1Item)
        Dim Item as DataGrid1Item = DataItem
        Dim FormDataSource As DataGrid1Item() = CType(DataGrid1Repeater.DataSource, DataGrid1Item())
        Dim DataGrid1DataRows As Integer = FormDataSource.Length
        Dim DataGrid1IsForceIteration As Boolean = False
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            DataGrid1CurrentRowNumber += 1
        CType(Page,CCPage).ControlAttributes.Add(DataGrid1Repeater,new CCSControlAttribute("rowNumber", FieldType._Integer, DataGrid1CurrentRowNumber), AttributeOption.Multiple)
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim DataGrid1Label1 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("DataGrid1Label1"),System.Web.UI.WebControls.Literal)
            Dim DataGrid1Label2 As System.Web.UI.WebControls.Literal = DirectCast(e.Item.FindControl("DataGrid1Label2"),System.Web.UI.WebControls.Literal)
        End If
'End Grid DataGrid1 ItemDataBound event

'Grid DataGrid1 ItemDataBound event tail @20-3E7C8434
        If DataGrid1IsForceIteration Then
            Dim ri As RepeaterItem = Nothing
            ri= New RepeaterItem(DataGrid1CurrentRowNumber, ListItemType.Item)
            DataGrid1Repeater.ItemTemplate.InstantiateIn(ri)
            ri.DataItem = DataItem
            ri.DataBind()
            e.Item.FindControl("IterationContainer").Controls.Add(ri)
            DataGrid1ItemDataBound(Sender, New RepeaterItemEventArgs(ri))
            ri.DataItem = Nothing
        End If
    End Sub
'End Grid DataGrid1 ItemDataBound event tail

'Grid DataGrid1 ItemCommand event @20-8464DE7A

    Protected Sub DataGrid1ItemCommand(Sender as Object, e as RepeaterCommandEventArgs)
        Dim FooterIndex as Integer= DataGrid1Repeater.Controls.Count - 1
        Dim BindAllowed as Boolean= False
        If e.CommandName = "Sort" Then
            If CType(e.CommandArgument,SorterState)=SorterState.None
                If CType(ViewState("DataGrid1SortDir"),SortDirections) = SortDirections._Asc And ViewState("DataGrid1SortField").ToString()=CType(e.CommandSource,Controls.Sorter).Field
                    ViewState("DataGrid1SortDir")=SortDirections._Desc
                Else
                    ViewState("DataGrid1SortDir")=SortDirections._Asc
                End If
            Else
                ViewState("DataGrid1SortDir")=CInt(CType(e.CommandSource,Controls.Sorter).State)
            End If
            Dim sf As DataGrid1DataProvider.SortFields = 0
            ViewState("DataGrid1SortField")=[Enum].Parse(sf.GetType(),CType(e.CommandSource,Controls.Sorter).Field)
            ViewState("DataGrid1PageNumber") = 1
            BindAllowed = True
        End If

        If e.CommandName="Navigate" Then
            ViewState("DataGrid1PageNumber") = Int32.Parse(e.CommandArgument.ToString())
            BindAllowed = True
        End If
        If e.CommandName="ChangePageSize" Then
            ViewState("DataGrid1PageSize") = Int32.Parse(CType(e.CommandArgument,Integer())(0).ToString())
            ViewState("DataGrid1PageNumber") = Int32.Parse(CType(e.CommandArgument,Integer())(1).ToString())
            BindAllowed = True
        End If
        If BindAllowed Then
            DataGrid1Bind
        End If
    End Sub
'End Grid DataGrid1 ItemCommand event

'OnInit Event @1-7CD4ED69
    #Region " Web Form Designer Generated Code "
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
'End OnInit Event

'OnInit Event Body @1-1922BC49
        ClientScript.GetPostBackEventReference(Me, "")
        Utility.SetThreadCulture()
        PageStyleName = Utility.GetPageStyle()
        FileUploadContentMeta = "text/html; charset=" +  CType(System.Threading.Thread.CurrentThread.CurrentCulture,CCSCultureInfo).Encoding
        If Application(Request.PhysicalPath) Is Nothing Then
            Application.Add(Request.PhysicalPath,Response.ContentEncoding.WebName)
        End If
        InitializeComponent()
        MyBase.OnInit(e)
        UploadRecordData = New UploadRecordDataProvider()
        UploadRecordOperations = New FormSupportedOperations(False, False, True, False, False)
        DataGrid1Data = New DataGrid1DataProvider()
        DataGrid1Operations = New FormSupportedOperations(False, True, False, False, False)
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

'ERA: Parsing code for CSV files
Public Function ParseCSV(ByVal inputString As String) As DataTable
    
    Dim dt As New DataTable()
    
    ' declare the Regular Expression that will match versus the input string
    Dim re As New Regex("((?<field>[^"",\r\n]+)|""(?<field>([^""]|"""")+)"")(,|(?<rowbreak>\r\n|\n|$))")
    
    Dim colArray As New ArrayList()
    Dim rowArray As New ArrayList()
    
    Dim colCount As Integer = 0
    Dim maxColCount As Integer = 0
    Dim rowbreak As String = ""
    Dim field As String = ""
    
    Dim mc As MatchCollection = re.Matches(inputString)
    
    For Each m As Match In mc
        
        ' retrieve the field and replace two double-quotes with a single double-quote
        field = m.Result("${field}").Replace("""""", """")
        
        rowbreak = m.Result("${rowbreak}")
        
        If field.Length > 0 Then
            colArray.Add(field)
            colCount += 1
        End If
        
        If rowbreak.Length > 0 Then
            
            ' add the column array to the row Array List
            rowArray.Add(colArray.ToArray())
            
            ' create a new Array List to hold the field values
            colArray = New ArrayList()
            
            If colCount > maxColCount Then
                maxColCount = colCount
            End If
            
            colCount = 0
        End If
    Next
    
    If rowbreak.Length = 0 Then
        ' this is executed when the last line doesn't
        ' end with a line break
        rowArray.Add(colArray.ToArray())
        If colCount > maxColCount Then
            maxColCount = colCount
        End If
    End If
    For i As Integer = 0 To maxColCount - 1
        dt.Columns.Add([String].Format("col{0:000}", i))
    Next
    
    ' create the columns for the table
    
    ' convert the row Array List into an Array object for easier access
    Dim ra As Array = rowArray.ToArray()
    For i As Integer = 0 To ra.Length - 1
        
        ' create a new DataRow
        Dim dr As DataRow = dt.NewRow()
        
        ' convert the column Array List into an Array object for easier access
        Dim ca As Array = DirectCast((ra.GetValue(i)), Array)
        For j As Integer = 0 To ca.Length - 1
            dr(j) = ca.GetValue(j)
        Next
        
        ' add each field into the new DataRow
        
        ' add the new DataRow to the DataTable
        dt.Rows.Add(dr)
    Next
    
    ' in case no data was parsed, create a single column
    If dt.Columns.Count = 0 Then
        dt.Columns.Add("NoData")
    End If
    
    Return dt
End Function

Public Function ParseCSVFile(ByVal path As String) As DataTable
    
    Dim inputString As String = ""
    
    ' check that the file exists before opening it
    If File.Exists(path) Then
        
        Dim sr As New StreamReader(path)
        inputString = sr.ReadToEnd()
            
        sr.Close()
    End If
    
    Return ParseCSV(inputString)
End Function


'Page class tail @1-DD082417
End Class
End Namespace
'End Page class tail

