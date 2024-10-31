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

Namespace DECV_PROD2007.KEY_LEARNING_AR_list 'Namespace @1-EC1B6ACF

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

'Grid KEY_LEARNING_AREA Item Class @2-ECE41F59
Public Class KEY_LEARNING_AREAItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public KEY_LEARNING_AREA_Insert As TextField
    Public KEY_LEARNING_AREA_InsertHref As Object
    Public KEY_LEARNING_AREA_InsertHrefParameters As LinkParameterCollection
    Public KLA_ID As FloatField
    Public KLA_IDHref As Object
    Public KLA_IDHrefParameters As LinkParameterCollection
    Public KEY_LEARNING_AREA As TextField
    Public STATUS As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_KLA_ID As FloatField
    Public Alt_KLA_IDHref As Object
    Public Alt_KLA_IDHrefParameters As LinkParameterCollection
    Public Alt_KEY_LEARNING_AREA As TextField
    Public Alt_STATUS As BooleanField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    KEY_LEARNING_AREA_Insert = New TextField("",Nothing)
    KEY_LEARNING_AREA_InsertHrefParameters = New LinkParameterCollection()
    KLA_ID = New FloatField("",Nothing)
    KLA_IDHrefParameters = New LinkParameterCollection()
    KEY_LEARNING_AREA = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_KLA_ID = New FloatField("",Nothing)
    Alt_KLA_IDHrefParameters = New LinkParameterCollection()
    Alt_KEY_LEARNING_AREA = New TextField("", Nothing)
    Alt_STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "KEY_LEARNING_AREA_Insert"
                    Return Me.KEY_LEARNING_AREA_Insert
                Case "KLA_ID"
                    Return Me.KLA_ID
                Case "KEY_LEARNING_AREA"
                    Return Me.KEY_LEARNING_AREA
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_KLA_ID"
                    Return Me.Alt_KLA_ID
                Case "Alt_KEY_LEARNING_AREA"
                    Return Me.Alt_KEY_LEARNING_AREA
                Case "Alt_STATUS"
                    Return Me.Alt_STATUS
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
                Case "KEY_LEARNING_AREA_Insert"
                    Me.KEY_LEARNING_AREA_Insert = CType(Value,TextField)
                Case "KLA_ID"
                    Me.KLA_ID = CType(Value,FloatField)
                Case "KEY_LEARNING_AREA"
                    Me.KEY_LEARNING_AREA = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_KLA_ID"
                    Me.Alt_KLA_ID = CType(Value,FloatField)
                Case "Alt_KEY_LEARNING_AREA"
                    Me.Alt_KEY_LEARNING_AREA = CType(Value,TextField)
                Case "Alt_STATUS"
                    Me.Alt_STATUS = CType(Value,BooleanField)
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
'End Grid KEY_LEARNING_AREA Item Class

'Grid KEY_LEARNING_AREA Data Provider Class Header @2-5AE99BAF
Public Class KEY_LEARNING_AREADataProvider
Inherits GridDataProviderBase
'End Grid KEY_LEARNING_AREA Data Provider Class Header

'Grid KEY_LEARNING_AREA Data Provider Class Variables @2-BF32C9FD

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_KLA_ID
        Sorter_KEY_LEARNING_AREA
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","KLA_ID","KEY_LEARNING_AREA","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","KLA_ID DESC","KEY_LEARNING_AREA DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
'End Grid KEY_LEARNING_AREA Data Provider Class Variables

'Grid KEY_LEARNING_AREA Data Provider Class GetResultSet Method @2-87F057D8

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} KLA_ID, KEY_LEARNING_AREA, STATUS, " & vbCrLf & _
          "LAST_ALTERED_BY, LAST_ALTERED_DATE " & vbCrLf & _
          "FROM KEY_LEARNING_AREA {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM KEY_LEARNING_AREA", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid KEY_LEARNING_AREA Data Provider Class GetResultSet Method

'Grid KEY_LEARNING_AREA Data Provider Class GetResultSet Method @2-E6B593DC
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As KEY_LEARNING_AREAItem()
'End Grid KEY_LEARNING_AREA Data Provider Class GetResultSet Method

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

'Execute Select @2-CB89A356
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As KEY_LEARNING_AREAItem
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

'After execute Select @2-F203FA5C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New KEY_LEARNING_AREAItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-10361FDB
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as KEY_LEARNING_AREAItem = New KEY_LEARNING_AREAItem()
                item.KEY_LEARNING_AREA_InsertHref = "KEY_LEARNING_AR_maint.aspx"
                item.KLA_ID.SetValue(dr(i)("KLA_ID"),"")
                item.KLA_IDHref = "KEY_LEARNING_AR_maint.aspx"
                item.KLA_IDHrefParameters.Add("KLA_ID",System.Web.HttpUtility.UrlEncode(dr(i)("KLA_ID").ToString()))
                item.KEY_LEARNING_AREA.SetValue(dr(i)("KEY_LEARNING_AREA"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_KLA_ID.SetValue(dr(i)("KLA_ID"),"")
                item.Alt_KLA_IDHref = "KEY_LEARNING_AR_maint.aspx"
                item.Alt_KLA_IDHrefParameters.Add("KLA_ID",System.Web.HttpUtility.UrlEncode(dr(i)("KLA_ID").ToString()))
                item.Alt_KEY_LEARNING_AREA.SetValue(dr(i)("KEY_LEARNING_AREA"),"")
                item.Alt_STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
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

