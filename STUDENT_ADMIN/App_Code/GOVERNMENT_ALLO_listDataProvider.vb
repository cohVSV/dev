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

Namespace DECV_PROD2007.GOVERNMENT_ALLO_list 'Namespace @1-9855ADA5

'Page Data Class @1-0B77669F
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Sub New()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
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

'Grid GOVERNMENT_ALLOWANCE Item Class @2-7FB210F7
Public Class GOVERNMENT_ALLOWANCEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public GOVERNMENT_ALLOWANCE_Insert As TextField
    Public GOVERNMENT_ALLOWANCE_InsertHref As Object
    Public GOVERNMENT_ALLOWANCE_InsertHrefParameters As LinkParameterCollection
    Public ALLOWANCE_CODE As IntegerField
    Public ALLOWANCE_CODEHref As Object
    Public ALLOWANCE_CODEHrefParameters As LinkParameterCollection
    Public ALLOWANCE_TITLE As TextField
    Public ALLOWANCE_DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_ALLOWANCE_CODE As IntegerField
    Public Alt_ALLOWANCE_CODEHref As Object
    Public Alt_ALLOWANCE_CODEHrefParameters As LinkParameterCollection
    Public Alt_ALLOWANCE_TITLE As TextField
    Public Alt_ALLOWANCE_DESCRIPTION As TextField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    GOVERNMENT_ALLOWANCE_Insert = New TextField("",Nothing)
    GOVERNMENT_ALLOWANCE_InsertHrefParameters = New LinkParameterCollection()
    ALLOWANCE_CODE = New IntegerField("",Nothing)
    ALLOWANCE_CODEHrefParameters = New LinkParameterCollection()
    ALLOWANCE_TITLE = New TextField("", Nothing)
    ALLOWANCE_DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_ALLOWANCE_CODE = New IntegerField("",Nothing)
    Alt_ALLOWANCE_CODEHrefParameters = New LinkParameterCollection()
    Alt_ALLOWANCE_TITLE = New TextField("", Nothing)
    Alt_ALLOWANCE_DESCRIPTION = New TextField("", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "GOVERNMENT_ALLOWANCE_Insert"
                    Return Me.GOVERNMENT_ALLOWANCE_Insert
                Case "ALLOWANCE_CODE"
                    Return Me.ALLOWANCE_CODE
                Case "ALLOWANCE_TITLE"
                    Return Me.ALLOWANCE_TITLE
                Case "ALLOWANCE_DESCRIPTION"
                    Return Me.ALLOWANCE_DESCRIPTION
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_ALLOWANCE_CODE"
                    Return Me.Alt_ALLOWANCE_CODE
                Case "Alt_ALLOWANCE_TITLE"
                    Return Me.Alt_ALLOWANCE_TITLE
                Case "Alt_ALLOWANCE_DESCRIPTION"
                    Return Me.Alt_ALLOWANCE_DESCRIPTION
                Case "Alt_LAST_ALTERED_BY"
                    Return Me.Alt_LAST_ALTERED_BY
                Case "Alt_LAST_ALTERED_DATE"
                    Return Me.Alt_LAST_ALTERED_DATE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "GOVERNMENT_ALLOWANCE_Insert"
                    Me.GOVERNMENT_ALLOWANCE_Insert = CType(Value,TextField)
                Case "ALLOWANCE_CODE"
                    Me.ALLOWANCE_CODE = CType(Value,IntegerField)
                Case "ALLOWANCE_TITLE"
                    Me.ALLOWANCE_TITLE = CType(Value,TextField)
                Case "ALLOWANCE_DESCRIPTION"
                    Me.ALLOWANCE_DESCRIPTION = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_ALLOWANCE_CODE"
                    Me.Alt_ALLOWANCE_CODE = CType(Value,IntegerField)
                Case "Alt_ALLOWANCE_TITLE"
                    Me.Alt_ALLOWANCE_TITLE = CType(Value,TextField)
                Case "Alt_ALLOWANCE_DESCRIPTION"
                    Me.Alt_ALLOWANCE_DESCRIPTION = CType(Value,TextField)
                Case "Alt_LAST_ALTERED_BY"
                    Me.Alt_LAST_ALTERED_BY = CType(Value,TextField)
                Case "Alt_LAST_ALTERED_DATE"
                    Me.Alt_LAST_ALTERED_DATE = CType(Value,DateField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid GOVERNMENT_ALLOWANCE Item Class

'Grid GOVERNMENT_ALLOWANCE Data Provider Class Header @2-0EACB0FF
Public Class GOVERNMENT_ALLOWANCEDataProvider
Inherits GridDataProviderBase
'End Grid GOVERNMENT_ALLOWANCE Data Provider Class Header

'Grid GOVERNMENT_ALLOWANCE Data Provider Class Variables @2-3346868C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_ALLOWANCE_CODE
        Sorter_ALLOWANCE_TITLE
        Sorter_ALLOWANCE_DESCRIPTION
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","ALLOWANCE_CODE","ALLOWANCE_TITLE","ALLOWANCE_DESCRIPTION","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","ALLOWANCE_CODE DESC","ALLOWANCE_TITLE DESC","ALLOWANCE_DESCRIPTION DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid GOVERNMENT_ALLOWANCE Data Provider Class Variables

'Grid GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method @2-5EE7FC50

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} ALLOWANCE_CODE, ALLOWANCE_TITLE, " & vbCrLf & _
          "ALLOWANCE_DESCRIPTION, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM GOVERNMENT_ALLOWANCE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM GOVERNMENT_ALLOWANCE", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method

'Grid GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method @2-7D6EE3EE
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As GOVERNMENT_ALLOWANCEItem()
'End Grid GOVERNMENT_ALLOWANCE Data Provider Class GetResultSet Method

'Before build Select @2-3C363B34
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-12BB01F4
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As GOVERNMENT_ALLOWANCEItem
        If ops.AllowRead Then
            Try
                If RecordsPerPage > 0 Then
                    ds=ExecuteSelect((PageNumber-1)*RecordsPerPage,RecordsPerPage)
                    _PagesCount = ExecuteCount()
                    m_recordCount = _PagesCount
                    If _PagesCount Mod RecordsPerPage>0 Then
                        _PagesCount = (_PagesCount\RecordsPerPage)+1
                    Else
                        _PagesCount = _PagesCount\RecordsPerPage
                    End If
                Else
                    ds=ExecuteSelect()
                    If ds.Tables(tableIndex).Rows.Count<>0 Then 
                        _PagesCount=1:m_recordCount = ds.Tables(tableIndex).Rows.Count
                    End If
                End If
            Catch ee as Exception
                E=ee
            Finally
'End Execute Select

'After execute Select @2-E9007BCA
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New GOVERNMENT_ALLOWANCEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-F8242A08
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as GOVERNMENT_ALLOWANCEItem = New GOVERNMENT_ALLOWANCEItem()
                item.GOVERNMENT_ALLOWANCE_InsertHref = "GOVERNMENT_ALLO_maint.aspx"
                item.ALLOWANCE_CODE.SetValue(dr(i)("ALLOWANCE_CODE"),"")
                item.ALLOWANCE_CODEHref = "GOVERNMENT_ALLO_maint.aspx"
                item.ALLOWANCE_CODEHrefParameters.Add("ALLOWANCE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("ALLOWANCE_CODE").ToString()))
                item.ALLOWANCE_TITLE.SetValue(dr(i)("ALLOWANCE_TITLE"),"")
                item.ALLOWANCE_DESCRIPTION.SetValue(dr(i)("ALLOWANCE_DESCRIPTION"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_ALLOWANCE_CODE.SetValue(dr(i)("ALLOWANCE_CODE"),"")
                item.Alt_ALLOWANCE_CODEHref = "GOVERNMENT_ALLO_maint.aspx"
                item.Alt_ALLOWANCE_CODEHrefParameters.Add("ALLOWANCE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("ALLOWANCE_CODE").ToString()))
                item.Alt_ALLOWANCE_TITLE.SetValue(dr(i)("ALLOWANCE_TITLE"),"")
                item.Alt_ALLOWANCE_DESCRIPTION.SetValue(dr(i)("ALLOWANCE_DESCRIPTION"),"")
                item.Alt_LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.Alt_LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.RawData = dr(i)
                result(i)=item
            Next
            _isEmpty = IIf(dr.Count = 0, True, False)
        End If
        Me.m_pagesCount = _PagesCount
        Return result 
    End Function
'End After execute Select tail

'Grid Data Provider tail @2-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

