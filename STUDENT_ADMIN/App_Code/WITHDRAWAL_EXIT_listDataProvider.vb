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

Namespace DECV_PROD2007.WITHDRAWAL_EXIT_list 'Namespace @1-403F2FB2

'Page Data Class @1-E2383BD0
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public Link_AddNew As TextField
    Public Link_AddNewHref As Object
    Public Link_AddNewHrefParameters As LinkParameterCollection
    Public Sub New()
        Link_AddNew = New TextField("",Nothing)
        Link_AddNewHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.Link_AddNew.SetValue(DBUtility.GetInitialValue("Link_AddNew"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "Link_AddNew"
                    Return Link_AddNew
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "Link_AddNew"
                    Link_AddNew = CType(value, TextField)
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

'Grid WITHDRAWAL_EXIT_DESTINATI Item Class @2-30034DB5
Public Class WITHDRAWAL_EXIT_DESTINATIItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public WITHDRAWAL_EXIT_DESTINATI_Insert As TextField
    Public WITHDRAWAL_EXIT_DESTINATI_InsertHref As Object
    Public WITHDRAWAL_EXIT_DESTINATI_InsertHrefParameters As LinkParameterCollection
    Public Detail As TextField
    Public DetailHref As Object
    Public DetailHrefParameters As LinkParameterCollection
    Public WD_DEST_ID As FloatField
    Public EXIT_DESTINATION_DESCRIPTION As TextField
    Public DISPLAY_ORDER As IntegerField
    Public GROUPING As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_Detail As TextField
    Public Alt_DetailHref As Object
    Public Alt_DetailHrefParameters As LinkParameterCollection
    Public Alt_WD_DEST_ID As FloatField
    Public Alt_EXIT_DESTINATION_DESCRIPTION As TextField
    Public Alt_DISPLAY_ORDER As IntegerField
    Public Alt_GROUPING As TextField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    WITHDRAWAL_EXIT_DESTINATI_Insert = New TextField("",Nothing)
    WITHDRAWAL_EXIT_DESTINATI_InsertHrefParameters = New LinkParameterCollection()
    Detail = New TextField("",Nothing)
    DetailHrefParameters = New LinkParameterCollection()
    WD_DEST_ID = New FloatField("", Nothing)
    EXIT_DESTINATION_DESCRIPTION = New TextField("", Nothing)
    DISPLAY_ORDER = New IntegerField("", Nothing)
    GROUPING = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    Alt_Detail = New TextField("",Nothing)
    Alt_DetailHrefParameters = New LinkParameterCollection()
    Alt_WD_DEST_ID = New FloatField("", Nothing)
    Alt_EXIT_DESTINATION_DESCRIPTION = New TextField("", Nothing)
    Alt_DISPLAY_ORDER = New IntegerField("", Nothing)
    Alt_GROUPING = New TextField("", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField("dd\/MM\/yyyy h\:mm tt", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "WITHDRAWAL_EXIT_DESTINATI_Insert"
                    Return Me.WITHDRAWAL_EXIT_DESTINATI_Insert
                Case "Detail"
                    Return Me.Detail
                Case "WD_DEST_ID"
                    Return Me.WD_DEST_ID
                Case "EXIT_DESTINATION_DESCRIPTION"
                    Return Me.EXIT_DESTINATION_DESCRIPTION
                Case "DISPLAY_ORDER"
                    Return Me.DISPLAY_ORDER
                Case "GROUPING"
                    Return Me.GROUPING
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_Detail"
                    Return Me.Alt_Detail
                Case "Alt_WD_DEST_ID"
                    Return Me.Alt_WD_DEST_ID
                Case "Alt_EXIT_DESTINATION_DESCRIPTION"
                    Return Me.Alt_EXIT_DESTINATION_DESCRIPTION
                Case "Alt_DISPLAY_ORDER"
                    Return Me.Alt_DISPLAY_ORDER
                Case "Alt_GROUPING"
                    Return Me.Alt_GROUPING
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
                Case "WITHDRAWAL_EXIT_DESTINATI_Insert"
                    Me.WITHDRAWAL_EXIT_DESTINATI_Insert = CType(Value,TextField)
                Case "Detail"
                    Me.Detail = CType(Value,TextField)
                Case "WD_DEST_ID"
                    Me.WD_DEST_ID = CType(Value,FloatField)
                Case "EXIT_DESTINATION_DESCRIPTION"
                    Me.EXIT_DESTINATION_DESCRIPTION = CType(Value,TextField)
                Case "DISPLAY_ORDER"
                    Me.DISPLAY_ORDER = CType(Value,IntegerField)
                Case "GROUPING"
                    Me.GROUPING = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_Detail"
                    Me.Alt_Detail = CType(Value,TextField)
                Case "Alt_WD_DEST_ID"
                    Me.Alt_WD_DEST_ID = CType(Value,FloatField)
                Case "Alt_EXIT_DESTINATION_DESCRIPTION"
                    Me.Alt_EXIT_DESTINATION_DESCRIPTION = CType(Value,TextField)
                Case "Alt_DISPLAY_ORDER"
                    Me.Alt_DISPLAY_ORDER = CType(Value,IntegerField)
                Case "Alt_GROUPING"
                    Me.Alt_GROUPING = CType(Value,TextField)
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
'End Grid WITHDRAWAL_EXIT_DESTINATI Item Class

'Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class Header @2-2B0585FE
Public Class WITHDRAWAL_EXIT_DESTINATIDataProvider
Inherits GridDataProviderBase
'End Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class Header

'Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class Variables @2-4E8DF1A5

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_WD_DEST_ID
        Sorter_EXIT_DESTINATION_DESCRIPTION
        Sorter_DISPLAY_ORDER
        Sorter_GROUPING
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","WD_DEST_ID","EXIT_DESTINATION_DESCRIPTION","DISPLAY_ORDER","GROUPING","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","WD_DEST_ID DESC","EXIT_DESTINATION_DESCRIPTION DESC","DISPLAY_ORDER DESC","GROUPING DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
'End Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class Variables

'Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method @2-46FB9AB9

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} WD_DEST_ID, EXIT_DESTINATION_DESCRIPTION, " & vbCrLf & _
          "DISPLAY_ORDER, GROUPING, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM WITHDRAWAL_EXIT_DESTINATION", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method

'Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method @2-587B1CEB
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As WITHDRAWAL_EXIT_DESTINATIItem()
'End Grid WITHDRAWAL_EXIT_DESTINATI Data Provider Class GetResultSet Method

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

'Execute Select @2-AD54F2F7
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As WITHDRAWAL_EXIT_DESTINATIItem
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

'After execute Select @2-48484E1F
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New WITHDRAWAL_EXIT_DESTINATIItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-C10B015C
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as WITHDRAWAL_EXIT_DESTINATIItem = New WITHDRAWAL_EXIT_DESTINATIItem()
                item.WITHDRAWAL_EXIT_DESTINATI_InsertHref = "WITHDRAWAL_EXIT_maint.aspx"
                item.DetailHref = "WITHDRAWAL_EXIT_maint.aspx"
                item.DetailHrefParameters.Add("WD_DEST_ID",System.Web.HttpUtility.UrlEncode(dr(i)("WD_DEST_ID").ToString()))
                item.WD_DEST_ID.SetValue(dr(i)("WD_DEST_ID"),"")
                item.EXIT_DESTINATION_DESCRIPTION.SetValue(dr(i)("EXIT_DESTINATION_DESCRIPTION"),"")
                item.DISPLAY_ORDER.SetValue(dr(i)("DISPLAY_ORDER"),"")
                item.GROUPING.SetValue(dr(i)("GROUPING"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_DetailHref = "WITHDRAWAL_EXIT_maint.aspx"
                item.Alt_DetailHrefParameters.Add("WD_DEST_ID",System.Web.HttpUtility.UrlEncode(dr(i)("WD_DEST_ID").ToString()))
                item.Alt_WD_DEST_ID.SetValue(dr(i)("WD_DEST_ID"),"")
                item.Alt_EXIT_DESTINATION_DESCRIPTION.SetValue(dr(i)("EXIT_DESTINATION_DESCRIPTION"),"")
                item.Alt_DISPLAY_ORDER.SetValue(dr(i)("DISPLAY_ORDER"),"")
                item.Alt_GROUPING.SetValue(dr(i)("GROUPING"),"")
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

