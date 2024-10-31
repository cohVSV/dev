'Using Statements @1-ECBA6F53
Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports DECV_PROD2007
Imports DECV_PROD2007.Data
Imports DECV_PROD2007.Controls
Imports DECV_PROD2007.Security
Imports DECV_PROD2007.Configuration
'End Using Statements

Namespace DECV_PROD2007.FileUpload 'Namespace @1-62FAA141

'Page Data Class @1-A50DF695
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public lblFilename As TextField
    Public Sub New()
        lblFilename = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.lblFilename.SetValue(DBUtility.GetInitialValue("lblFilename"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "lblFilename"
                    Return lblFilename
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "lblFilename"
                    lblFilename = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

End Class
'End Page Data Class

'Page Data Provider Class @1-E3544B64
Public Class PageDataProvider
Dim j As Integer
'End Page Data Provider Class

'Page Data Provider Class Constructor @1-12B526DF
    Public Sub New()
    End Sub
'End Page Data Provider Class Constructor

'Page Data Provider Class GetResultSet Method @1-F73C4626
    Public Sub FillItem(ByVal item As PageItem)
'End Page Data Provider Class GetResultSet Method

'Page Data Provider Class GetResultSet Method tail @1-E31F8E2A
    End Sub
'End Page Data Provider Class GetResultSet Method tail

'Page Data Provider class Tail @1-A61BA892
End Class
'End Page Data Provider class Tail

'Record UploadRecord Item Class @2-3544F549
Public Class UploadRecordItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public FileUpload1 As TextField
    Public Sub New()
    FileUpload1 = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As UploadRecordItem
        Dim item As UploadRecordItem = New UploadRecordItem()
        If Not IsNothing(DBUtility.GetInitialValue("FileUpload1")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Insert")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Update")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_Delete")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "FileUpload1"
                    Return FileUpload1
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "FileUpload1"
                    FileUpload1 = CType(value, TextField)
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Set
    End Property

    Public Property IsNew() As Boolean
        Get
            Return _isNew
        End Get
        Set
            _isNew = Value
        End Set
    End Property

    Public Property IsDeleted() As Boolean
        Get
            Return _isDeleted
        End Get
        Set
            _isDeleted = Value
        End Set
    End Property

    Public Sub Validate(ByVal provider As UploadRecordDataProvider)
'End Record UploadRecord Item Class

'FileUpload1 validate @3-80FA798A
        If IsNothing(FileUpload1.Value) OrElse FileUpload1.Value.ToString() ="" Then
            errors.Add("FileUpload1",String.Format(Resources.strings.CCS_RequiredField,"File Upload"))
        End If
'End FileUpload1 validate

'Record UploadRecord Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record UploadRecord Item Class tail

'Record UploadRecord Data Provider Class @2-36161C7D
Public Class UploadRecordDataProvider
Inherits RecordDataProviderBase
'End Record UploadRecord Data Provider Class

'Record UploadRecord Data Provider Class Variables @2-FDF73639
    Protected item As UploadRecordItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record UploadRecord Data Provider Class Variables

'Record UploadRecord Data Provider Class Constructor @2-204740D2

    Public Sub New()
        Select_=new TableCommand("SELECT * " & vbCrLf & _
          "FROM tmp_filenames {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Insert=new TableCommand("INSERT INTO tmp_filenames() VALUES ()", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
        Select_.OrderBy=""
    End Sub
'End Record UploadRecord Data Provider Class Constructor

'Record UploadRecord Data Provider Class LoadParams Method @2-B45586B2

    Protected Function LoadParams() As Boolean
        Return True
    End Function
'End Record UploadRecord Data Provider Class LoadParams Method

'Record UploadRecord Data Provider Class CheckUnique Method @2-4002BEDD

    Public Function CheckUnique(ByVal ControlName As String, ByVal item As UploadRecordItem) As Boolean
        Return True
    End Function
'End Record UploadRecord Data Provider Class CheckUnique Method

'Record UploadRecord Data Provider Class PrepareInsert Method @2-C01FE792

    Protected Overrides Sub PrepareInsert()
        CmdExecution = True
'End Record UploadRecord Data Provider Class PrepareInsert Method

'Record UploadRecord Data Provider Class PrepareInsert Method tail @2-E31F8E2A
    End Sub
'End Record UploadRecord Data Provider Class PrepareInsert Method tail

'Record UploadRecord Data Provider Class Insert Method @2-6625B3EE

    Public Function InsertItem(ByVal item As UploadRecordItem) As Integer
        Me.item = item
'End Record UploadRecord Data Provider Class Insert Method

'Record UploadRecord Build insert @2-663ABA39
        Insert.Parameters.Clear()
        Dim result As Object = Nothing
        Dim E As Exception = Nothing
        Try
            result = ExecuteInsert()
        Catch ee As Exception
            E = ee
        Finally
'End Record UploadRecord Build insert

'Record UploadRecord AfterExecuteInsert @2-2FB4FB62
            If Not IsNothing(E) Then Throw E
        End Try
        Return CType(result, Integer)
    End Function
'End Record UploadRecord AfterExecuteInsert

'Record UploadRecord Data Provider Class GetResultSet Method @2-8D0F48E9

    Public Sub FillItem(ByVal item As UploadRecordItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record UploadRecord Data Provider Class GetResultSet Method

'Record UploadRecord BeforeBuildSelect @2-5D194071
        Select_.Parameters.Clear()
        IsInsertMode = Not LoadParams()
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record UploadRecord BeforeBuildSelect

'Record UploadRecord BeforeExecuteSelect @2-6E7CB476
            Try
                dr = ExecuteSelect().Tables(tableIndex).Rows
            Catch ee As Exception
                E = ee
            Finally
'End Record UploadRecord BeforeExecuteSelect

'Record UploadRecord AfterExecuteSelect @2-7B594618
                If Not IsNothing(E) Then Throw E
        End Try
        End If
        If (Not IsInsertMode) AndAlso (Not ReadNotAllowed) AndAlso dr.Count <> 0 Then
            Dim i As Integer = 0
            item.RawData = dr(i)
        Else
            IsInsertMode = True
        End If
'End Record UploadRecord AfterExecuteSelect

'Record UploadRecord AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record UploadRecord AfterExecuteSelect tail

'Record UploadRecord Data Provider Class @2-A61BA892
End Class

'End Record UploadRecord Data Provider Class

'Grid DataGrid1 Item Class @20-75E4C38F
Public Class DataGrid1Item 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public DataGrid1_TotalRecords As TextField
    Public Label1 As TextField
    Public Label2 As TextField
    Public Sub New()
    DataGrid1_TotalRecords = New TextField("", Nothing)
    Label1 = New TextField("", Nothing)
    Label2 = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "DataGrid1_TotalRecords"
                    Return Me.DataGrid1_TotalRecords
                Case "Label1"
                    Return Me.Label1
                Case "Label2"
                    Return Me.Label2
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "DataGrid1_TotalRecords"
                    Me.DataGrid1_TotalRecords = CType(Value,TextField)
                Case "Label1"
                    Me.Label1 = CType(Value,TextField)
                Case "Label2"
                    Me.Label2 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid DataGrid1 Item Class

'Grid DataGrid1 Data Provider Class Header @20-81C189A7
Public Class DataGrid1DataProvider
Inherits GridDataProviderBase
'End Grid DataGrid1 Data Provider Class Header

'Grid DataGrid1 Data Provider Class Variables @20-04D7CB3F

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
'End Grid DataGrid1 Data Provider Class Variables

'Grid DataGrid1 Data Provider Class GetResultSet Method @20-B276AEE1
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As DataGrid1Item()
'End Grid DataGrid1 Data Provider Class GetResultSet Method

'Before build Select @20-D54109E2
        Dim E as Exception = Nothing
        Dim tableIndex As Integer = 0
'End Before build Select

'After execute Select @20-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @20-D4DB566D
            Dim result(-1) as DataGrid1Item
            _PagesCount=0
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @20-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

