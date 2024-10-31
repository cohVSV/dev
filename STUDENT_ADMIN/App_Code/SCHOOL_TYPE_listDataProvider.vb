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

Namespace DECV_PROD2007.SCHOOL_TYPE_list 'Namespace @1-D5F5CBEB

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

'Grid SCHOOL_TYPE Item Class @2-1ADEAF9B
Public Class SCHOOL_TYPEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SCHOOL_TYPE_Insert As TextField
    Public SCHOOL_TYPE_InsertHref As Object
    Public SCHOOL_TYPE_InsertHrefParameters As LinkParameterCollection
    Public SCHOOL_TYPE_CODE As TextField
    Public SCHOOL_TYPE_CODEHref As Object
    Public SCHOOL_TYPE_CODEHrefParameters As LinkParameterCollection
    Public SCHOOL_TYPE_DESCRIPTION As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_SCHOOL_TYPE_CODE As TextField
    Public Alt_SCHOOL_TYPE_CODEHref As Object
    Public Alt_SCHOOL_TYPE_CODEHrefParameters As LinkParameterCollection
    Public Alt_SCHOOL_TYPE_DESCRIPTION As TextField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    SCHOOL_TYPE_Insert = New TextField("",Nothing)
    SCHOOL_TYPE_InsertHrefParameters = New LinkParameterCollection()
    SCHOOL_TYPE_CODE = New TextField("",Nothing)
    SCHOOL_TYPE_CODEHrefParameters = New LinkParameterCollection()
    SCHOOL_TYPE_DESCRIPTION = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_SCHOOL_TYPE_CODE = New TextField("",Nothing)
    Alt_SCHOOL_TYPE_CODEHrefParameters = New LinkParameterCollection()
    Alt_SCHOOL_TYPE_DESCRIPTION = New TextField("", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SCHOOL_TYPE_Insert"
                    Return Me.SCHOOL_TYPE_Insert
                Case "SCHOOL_TYPE_CODE"
                    Return Me.SCHOOL_TYPE_CODE
                Case "SCHOOL_TYPE_DESCRIPTION"
                    Return Me.SCHOOL_TYPE_DESCRIPTION
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_SCHOOL_TYPE_CODE"
                    Return Me.Alt_SCHOOL_TYPE_CODE
                Case "Alt_SCHOOL_TYPE_DESCRIPTION"
                    Return Me.Alt_SCHOOL_TYPE_DESCRIPTION
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
                Case "SCHOOL_TYPE_Insert"
                    Me.SCHOOL_TYPE_Insert = CType(Value,TextField)
                Case "SCHOOL_TYPE_CODE"
                    Me.SCHOOL_TYPE_CODE = CType(Value,TextField)
                Case "SCHOOL_TYPE_DESCRIPTION"
                    Me.SCHOOL_TYPE_DESCRIPTION = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_SCHOOL_TYPE_CODE"
                    Me.Alt_SCHOOL_TYPE_CODE = CType(Value,TextField)
                Case "Alt_SCHOOL_TYPE_DESCRIPTION"
                    Me.Alt_SCHOOL_TYPE_DESCRIPTION = CType(Value,TextField)
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
'End Grid SCHOOL_TYPE Item Class

'Grid SCHOOL_TYPE Data Provider Class Header @2-9860BA87
Public Class SCHOOL_TYPEDataProvider
Inherits GridDataProviderBase
'End Grid SCHOOL_TYPE Data Provider Class Header

'Grid SCHOOL_TYPE Data Provider Class Variables @2-F492E317

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SCHOOL_TYPE_CODE
        Sorter_SCHOOL_TYPE_DESCRIPTION
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","SCHOOL_TYPE_CODE","SCHOOL_TYPE_DESCRIPTION","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","SCHOOL_TYPE_CODE DESC","SCHOOL_TYPE_DESCRIPTION DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid SCHOOL_TYPE Data Provider Class Variables

'Grid SCHOOL_TYPE Data Provider Class GetResultSet Method @2-3F3C77EE

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SCHOOL_TYPE_CODE, SCHOOL_TYPE_DESCRIPTION, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE " & vbCrLf & _
          "FROM SCHOOL_TYPE {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SCHOOL_TYPE", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SCHOOL_TYPE Data Provider Class GetResultSet Method

'Grid SCHOOL_TYPE Data Provider Class GetResultSet Method @2-86D34340
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SCHOOL_TYPEItem()
'End Grid SCHOOL_TYPE Data Provider Class GetResultSet Method

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

'Execute Select @2-7D67C2B4
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SCHOOL_TYPEItem
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

'After execute Select @2-CA092675
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SCHOOL_TYPEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-760513C5
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SCHOOL_TYPEItem = New SCHOOL_TYPEItem()
                item.SCHOOL_TYPE_InsertHref = "SCHOOL_TYPE_maint.aspx"
                item.SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
                item.SCHOOL_TYPE_CODEHref = "SCHOOL_TYPE_maint.aspx"
                item.SCHOOL_TYPE_CODEHrefParameters.Add("SCHOOL_TYPE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_TYPE_CODE").ToString()))
                item.SCHOOL_TYPE_DESCRIPTION.SetValue(dr(i)("SCHOOL_TYPE_DESCRIPTION"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_SCHOOL_TYPE_CODE.SetValue(dr(i)("SCHOOL_TYPE_CODE"),"")
                item.Alt_SCHOOL_TYPE_CODEHref = "SCHOOL_TYPE_maint.aspx"
                item.Alt_SCHOOL_TYPE_CODEHrefParameters.Add("SCHOOL_TYPE_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SCHOOL_TYPE_CODE").ToString()))
                item.Alt_SCHOOL_TYPE_DESCRIPTION.SetValue(dr(i)("SCHOOL_TYPE_DESCRIPTION"),"")
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

