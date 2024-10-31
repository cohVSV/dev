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

Namespace DECV_PROD2007.REGION_list 'Namespace @1-639AF3B4

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

'Grid REGION Item Class @2-04888C34
Public Class REGIONItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public REGION_Insert As TextField
    Public REGION_InsertHref As Object
    Public REGION_InsertHrefParameters As LinkParameterCollection
    Public REGION_NAME As TextField
    Public PHONE As TextField
    Public FAX As TextField
    Public EMAIL_ADDRESS As TextField
    Public SUBURB_TOWN As TextField
    Public Alt_REGION_NAME As TextField
    Public Alt_PHONE As TextField
    Public Alt_FAX As TextField
    Public Alt_EMAIL_ADDRESS As TextField
    Public Alt_SUBURB_TOWN As TextField
    Public STATUS As TextField
    Public STATUS1 As TextField
    Public REGION_ID As FloatField
    Public REGION_IDHref As Object
    Public REGION_IDHrefParameters As LinkParameterCollection
    Public Alt_REGION_ID As FloatField
    Public Alt_REGION_IDHref As Object
    Public Alt_REGION_IDHrefParameters As LinkParameterCollection
    Public ID As TextField
    Public ID1 As TextField
    Public Sub New()
    REGION_Insert = New TextField("",Nothing)
    REGION_InsertHrefParameters = New LinkParameterCollection()
    REGION_NAME = New TextField("", Nothing)
    PHONE = New TextField("", Nothing)
    FAX = New TextField("", Nothing)
    EMAIL_ADDRESS = New TextField("", Nothing)
    SUBURB_TOWN = New TextField("", Nothing)
    Alt_REGION_NAME = New TextField("", Nothing)
    Alt_PHONE = New TextField("", Nothing)
    Alt_FAX = New TextField("", Nothing)
    Alt_EMAIL_ADDRESS = New TextField("", Nothing)
    Alt_SUBURB_TOWN = New TextField("", Nothing)
    STATUS = New TextField("", Nothing)
    STATUS1 = New TextField("", Nothing)
    REGION_ID = New FloatField("",Nothing)
    REGION_IDHrefParameters = New LinkParameterCollection()
    Alt_REGION_ID = New FloatField("",Nothing)
    Alt_REGION_IDHrefParameters = New LinkParameterCollection()
    ID = New TextField("", Nothing)
    ID1 = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "REGION_Insert"
                    Return Me.REGION_Insert
                Case "REGION_NAME"
                    Return Me.REGION_NAME
                Case "PHONE"
                    Return Me.PHONE
                Case "FAX"
                    Return Me.FAX
                Case "EMAIL_ADDRESS"
                    Return Me.EMAIL_ADDRESS
                Case "SUBURB_TOWN"
                    Return Me.SUBURB_TOWN
                Case "Alt_REGION_NAME"
                    Return Me.Alt_REGION_NAME
                Case "Alt_PHONE"
                    Return Me.Alt_PHONE
                Case "Alt_FAX"
                    Return Me.Alt_FAX
                Case "Alt_EMAIL_ADDRESS"
                    Return Me.Alt_EMAIL_ADDRESS
                Case "Alt_SUBURB_TOWN"
                    Return Me.Alt_SUBURB_TOWN
                Case "STATUS"
                    Return Me.STATUS
                Case "STATUS1"
                    Return Me.STATUS1
                Case "REGION_ID"
                    Return Me.REGION_ID
                Case "Alt_REGION_ID"
                    Return Me.Alt_REGION_ID
                Case "ID"
                    Return Me.ID
                Case "ID1"
                    Return Me.ID1
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "REGION_Insert"
                    Me.REGION_Insert = CType(Value,TextField)
                Case "REGION_NAME"
                    Me.REGION_NAME = CType(Value,TextField)
                Case "PHONE"
                    Me.PHONE = CType(Value,TextField)
                Case "FAX"
                    Me.FAX = CType(Value,TextField)
                Case "EMAIL_ADDRESS"
                    Me.EMAIL_ADDRESS = CType(Value,TextField)
                Case "SUBURB_TOWN"
                    Me.SUBURB_TOWN = CType(Value,TextField)
                Case "Alt_REGION_NAME"
                    Me.Alt_REGION_NAME = CType(Value,TextField)
                Case "Alt_PHONE"
                    Me.Alt_PHONE = CType(Value,TextField)
                Case "Alt_FAX"
                    Me.Alt_FAX = CType(Value,TextField)
                Case "Alt_EMAIL_ADDRESS"
                    Me.Alt_EMAIL_ADDRESS = CType(Value,TextField)
                Case "Alt_SUBURB_TOWN"
                    Me.Alt_SUBURB_TOWN = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,TextField)
                Case "STATUS1"
                    Me.STATUS1 = CType(Value,TextField)
                Case "REGION_ID"
                    Me.REGION_ID = CType(Value,FloatField)
                Case "Alt_REGION_ID"
                    Me.Alt_REGION_ID = CType(Value,FloatField)
                Case "ID"
                    Me.ID = CType(Value,TextField)
                Case "ID1"
                    Me.ID1 = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid REGION Item Class

'Grid REGION Data Provider Class Header @2-B02782B5
Public Class REGIONDataProvider
Inherits GridDataProviderBase
'End Grid REGION Data Provider Class Header

'Grid REGION Data Provider Class Variables @2-BAD8F86C

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_REGION_ID
        Sorter_REGION_NAME
        Sorter_PHONE
        Sorter_FAX
        Sorter_EMAIL_ADDRESS
        Sorter_SUBURB_TOWN
    End Enum

    Private SortFieldsNames As String() = New String() {"","REGION_ID","REGION_NAME","PHONE","FAX","EMAIL_ADDRESS","SUBURB_TOWN"}
    Private SortFieldsNamesDesc As String() = New string() {"","REGION_ID DESC","REGION_NAME DESC","PHONE DESC","FAX DESC","EMAIL_ADDRESS DESC","SUBURB_TOWN DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid REGION Data Provider Class Variables

'Grid REGION Data Provider Class GetResultSet Method @2-FC9C779B

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} REGION_ID, REGION_NAME, PHONE, FAX, EMAIL_ADDRESS, " & vbCrLf & _
          "SUBURB_TOWN, STATUS " & vbCrLf & _
          "FROM REGION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM REGION", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid REGION Data Provider Class GetResultSet Method

'Grid REGION Data Provider Class GetResultSet Method @2-E12F7B2E
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As REGIONItem()
'End Grid REGION Data Provider Class GetResultSet Method

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

'Execute Select @2-9701A626
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As REGIONItem
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

'After execute Select @2-65C7DB85
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New REGIONItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-B3457640
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as REGIONItem = New REGIONItem()
                item.REGION_InsertHref = "REGION_maint.aspx"
                item.REGION_NAME.SetValue(dr(i)("REGION_NAME"),"")
                item.PHONE.SetValue(dr(i)("PHONE"),"")
                item.FAX.SetValue(dr(i)("FAX"),"")
                item.EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.Alt_REGION_NAME.SetValue(dr(i)("REGION_NAME"),"")
                item.Alt_PHONE.SetValue(dr(i)("PHONE"),"")
                item.Alt_FAX.SetValue(dr(i)("FAX"),"")
                item.Alt_EMAIL_ADDRESS.SetValue(dr(i)("EMAIL_ADDRESS"),"")
                item.Alt_SUBURB_TOWN.SetValue(dr(i)("SUBURB_TOWN"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),"")
                item.STATUS1.SetValue(dr(i)("STATUS"),"")
                item.REGION_ID.SetValue(dr(i)("REGION_ID"),"")
                item.REGION_IDHref = "REGION_maint.aspx"
                item.REGION_IDHrefParameters.Add("REGION_ID",System.Web.HttpUtility.UrlEncode(dr(i)("REGION_ID").ToString()))
                item.Alt_REGION_ID.SetValue(dr(i)("REGION_ID"),"")
                item.Alt_REGION_IDHref = "REGION_maint.aspx"
                item.Alt_REGION_IDHrefParameters.Add("REGION_ID",System.Web.HttpUtility.UrlEncode(dr(i)("REGION_ID").ToString()))
                item.ID.SetValue(dr(i)("REGION_ID"),"")
                item.ID1.SetValue(dr(i)("REGION_ID"),"")
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

