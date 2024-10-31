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

Namespace DECV_PROD2007.ENROLMENT_CATEG_list 'Namespace @1-91BC5E68

'Page Data Class @1-FD75E446
Public Class PageItem
    Public errors As NameValueCollection = New NameValueCollection()

    Public link_addnewsubcategory As TextField
    Public link_addnewsubcategoryHref As Object
    Public link_addnewsubcategoryHrefParameters As LinkParameterCollection
    Public Sub New()
        link_addnewsubcategory = New TextField("",Nothing)
        link_addnewsubcategoryHrefParameters = New LinkParameterCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As PageItem
        Dim item As PageItem = New PageItem()
        item.link_addnewsubcategory.SetValue(DBUtility.GetInitialValue("link_addnewsubcategory"))
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "link_addnewsubcategory"
                    Return link_addnewsubcategory
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "link_addnewsubcategory"
                    link_addnewsubcategory = CType(value, TextField)
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

'Grid ENROLMENT_CATEGORY Item Class @2-D41BB144
Public Class ENROLMENT_CATEGORYItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public ENROLMENT_CATEGORY_Insert As TextField
    Public ENROLMENT_CATEGORY_InsertHref As Object
    Public ENROLMENT_CATEGORY_InsertHrefParameters As LinkParameterCollection
    Public CATEGORY_CODE As TextField
    Public CATEGORY_CODEHref As Object
    Public CATEGORY_CODEHrefParameters As LinkParameterCollection
    Public SUBCATEGORY_CODE As TextField
    Public SUBCATEGORY_FULL_TITLE As TextField
    Public STATUS As BooleanField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_CATEGORY_CODE As TextField
    Public Alt_CATEGORY_CODEHref As Object
    Public Alt_CATEGORY_CODEHrefParameters As LinkParameterCollection
    Public Alt_SUBCATEGORY_CODE As TextField
    Public Alt_SUBCATEGORY_FULL_TITLE As TextField
    Public Alt_STATUS As BooleanField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    ENROLMENT_CATEGORY_Insert = New TextField("",Nothing)
    ENROLMENT_CATEGORY_InsertHrefParameters = New LinkParameterCollection()
    CATEGORY_CODE = New TextField("",Nothing)
    CATEGORY_CODEHrefParameters = New LinkParameterCollection()
    SUBCATEGORY_CODE = New TextField("", Nothing)
    SUBCATEGORY_FULL_TITLE = New TextField("", Nothing)
    STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_CATEGORY_CODE = New TextField("",Nothing)
    Alt_CATEGORY_CODEHrefParameters = New LinkParameterCollection()
    Alt_SUBCATEGORY_CODE = New TextField("", Nothing)
    Alt_SUBCATEGORY_FULL_TITLE = New TextField("", Nothing)
    Alt_STATUS = New BooleanField(Settings.BoolFormat, Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "ENROLMENT_CATEGORY_Insert"
                    Return Me.ENROLMENT_CATEGORY_Insert
                Case "CATEGORY_CODE"
                    Return Me.CATEGORY_CODE
                Case "SUBCATEGORY_CODE"
                    Return Me.SUBCATEGORY_CODE
                Case "SUBCATEGORY_FULL_TITLE"
                    Return Me.SUBCATEGORY_FULL_TITLE
                Case "STATUS"
                    Return Me.STATUS
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_CATEGORY_CODE"
                    Return Me.Alt_CATEGORY_CODE
                Case "Alt_SUBCATEGORY_CODE"
                    Return Me.Alt_SUBCATEGORY_CODE
                Case "Alt_SUBCATEGORY_FULL_TITLE"
                    Return Me.Alt_SUBCATEGORY_FULL_TITLE
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
                Case "ENROLMENT_CATEGORY_Insert"
                    Me.ENROLMENT_CATEGORY_Insert = CType(Value,TextField)
                Case "CATEGORY_CODE"
                    Me.CATEGORY_CODE = CType(Value,TextField)
                Case "SUBCATEGORY_CODE"
                    Me.SUBCATEGORY_CODE = CType(Value,TextField)
                Case "SUBCATEGORY_FULL_TITLE"
                    Me.SUBCATEGORY_FULL_TITLE = CType(Value,TextField)
                Case "STATUS"
                    Me.STATUS = CType(Value,BooleanField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_CATEGORY_CODE"
                    Me.Alt_CATEGORY_CODE = CType(Value,TextField)
                Case "Alt_SUBCATEGORY_CODE"
                    Me.Alt_SUBCATEGORY_CODE = CType(Value,TextField)
                Case "Alt_SUBCATEGORY_FULL_TITLE"
                    Me.Alt_SUBCATEGORY_FULL_TITLE = CType(Value,TextField)
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
'End Grid ENROLMENT_CATEGORY Item Class

'Grid ENROLMENT_CATEGORY Data Provider Class Header @2-D791D030
Public Class ENROLMENT_CATEGORYDataProvider
Inherits GridDataProviderBase
'End Grid ENROLMENT_CATEGORY Data Provider Class Header

'Grid ENROLMENT_CATEGORY Data Provider Class Variables @2-5B99826B

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_CATEGORY_CODE
        Sorter_SUBCATEGORY_CODE
        Sorter_SUBCATEGORY_FULL_TITLE
        Sorter_STATUS
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"","CATEGORY_CODE","SUBCATEGORY_CODE","SUBCATEGORY_FULL_TITLE","STATUS","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"","CATEGORY_CODE DESC","SUBCATEGORY_CODE DESC","SUBCATEGORY_FULL_TITLE DESC","STATUS DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 40
    Public PageNumber As Integer = 1
'End Grid ENROLMENT_CATEGORY Data Provider Class Variables

'Grid ENROLMENT_CATEGORY Data Provider Class GetResultSet Method @2-9FA1212A

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} CATEGORY_CODE, SUBCATEGORY_CODE, " & vbCrLf & _
          "SUBCATEGORY_FULL_TITLE, STATUS, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM ENROLMENT_CATEGORY {SQL_Where} {SQL_OrderBy}", New String(){},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM ENROLMENT_CATEGORY", New String(){},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid ENROLMENT_CATEGORY Data Provider Class GetResultSet Method

'Grid ENROLMENT_CATEGORY Data Provider Class GetResultSet Method @2-6C41CB8E
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As ENROLMENT_CATEGORYItem()
'End Grid ENROLMENT_CATEGORY Data Provider Class GetResultSet Method

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

'Execute Select @2-FABA0C97
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As ENROLMENT_CATEGORYItem
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

'After execute Select @2-CE87967C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New ENROLMENT_CATEGORYItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-5D34A77B
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as ENROLMENT_CATEGORYItem = New ENROLMENT_CATEGORYItem()
                item.ENROLMENT_CATEGORY_InsertHref = "ENROLMENT_CATEG_maint.aspx"
                item.CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.CATEGORY_CODEHref = "ENROLMENT_CATEG_maint.aspx"
                item.CATEGORY_CODEHrefParameters.Add("SUBCATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SUBCATEGORY_CODE").ToString()))
                item.CATEGORY_CODEHrefParameters.Add("CATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CATEGORY_CODE").ToString()))
                item.SUBCATEGORY_CODE.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
                item.SUBCATEGORY_FULL_TITLE.SetValue(dr(i)("SUBCATEGORY_FULL_TITLE"),"")
                item.STATUS.SetValue(dr(i)("STATUS"),Select_.BoolFormat)
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_CATEGORY_CODE.SetValue(dr(i)("CATEGORY_CODE"),"")
                item.Alt_CATEGORY_CODEHref = "ENROLMENT_CATEG_maint.aspx"
                item.Alt_CATEGORY_CODEHrefParameters.Add("SUBCATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("SUBCATEGORY_CODE").ToString()))
                item.Alt_CATEGORY_CODEHrefParameters.Add("CATEGORY_CODE",System.Web.HttpUtility.UrlEncode(dr(i)("CATEGORY_CODE").ToString()))
                item.Alt_SUBCATEGORY_CODE.SetValue(dr(i)("SUBCATEGORY_CODE"),"")
                item.Alt_SUBCATEGORY_FULL_TITLE.SetValue(dr(i)("SUBCATEGORY_FULL_TITLE"),"")
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

