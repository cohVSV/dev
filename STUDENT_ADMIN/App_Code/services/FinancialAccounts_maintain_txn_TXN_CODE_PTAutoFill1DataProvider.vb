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

Namespace DECV_PROD2007.services.FinancialAccounts_maintain_txn_TXN_CODE_PTAutoFill1 'Namespace @1-BA2D417A

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

'Grid TXN_CODE Item Class @2-09ABF872
Public Class TXN_CODEItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public TXN_CODE As TextField
    Public CR_DR_FLAG As TextField
    Public Sub New()
    TXN_CODE = New TextField("", Nothing)
    CR_DR_FLAG = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "TXN_CODE"
                    Return Me.TXN_CODE
                Case "CR_DR_FLAG"
                    Return Me.CR_DR_FLAG
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "TXN_CODE"
                    Me.TXN_CODE = CType(Value,TextField)
                Case "CR_DR_FLAG"
                    Me.CR_DR_FLAG = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid TXN_CODE Item Class

'Grid TXN_CODE Data Provider Class Header @2-1B828872
Public Class TXN_CODEDataProvider
Inherits GridDataProviderBase
'End Grid TXN_CODE Data Provider Class Header

'Grid TXN_CODE Data Provider Class Variables @2-AE34B2FE

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
    End Enum

    Private SortFieldsNames As String() = New String() {""}
    Private SortFieldsNamesDesc As String() = New string() {""}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 10
    Public PageNumber As Integer = 1
    Public Urlkeyword  As TextParameter
'End Grid TXN_CODE Data Provider Class Variables

'Grid TXN_CODE Data Provider Class GetResultSet Method @2-37F38C99

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} CR_DR_FLAG, " & vbCrLf & _
          "TXN_CODE " & vbCrLf & _
          "FROM TXN_CODE {SQL_Where} {SQL_OrderBy}", New String(){"keyword121"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM TXN_CODE", New String(){"keyword121"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid TXN_CODE Data Provider Class GetResultSet Method

'Grid TXN_CODE Data Provider Class GetResultSet Method @2-D9C0073D
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As TXN_CODEItem()
'End Grid TXN_CODE Data Provider Class GetResultSet Method

'Before build Select @2-ABD97FBA
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("keyword121",Urlkeyword, "","TXN_CODE",Condition.Equal,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-F5833492
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As TXN_CODEItem
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

'After execute Select @2-0216F164
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New TXN_CODEItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-12944B68
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as TXN_CODEItem = New TXN_CODEItem()
                item.TXN_CODE.SetValue(dr(i)("TXN_CODE"),"")
                item.CR_DR_FLAG.SetValue(dr(i)("CR_DR_FLAG"),"")
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

