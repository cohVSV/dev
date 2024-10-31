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

Namespace DECV_PROD2007.COUNTRY_OF_BIRT_list 'Namespace @1-6856B54F

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

'Record COUNTRY_OF_BIRTHSearch Item Class @2-1FADD363
Public Class COUNTRY_OF_BIRTHSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_keyword As TextField
    Public Sub New()
    s_keyword = New TextField("", Nothing)
    End Sub

    Public Shared Function CreateFromHttpRequest() As COUNTRY_OF_BIRTHSearchItem
        Dim item As COUNTRY_OF_BIRTHSearchItem = New COUNTRY_OF_BIRTHSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("s_keyword")) Then
        item.s_keyword.SetValue(DBUtility.GetInitialValue("s_keyword"))
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_keyword"
                    Return s_keyword
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_keyword"
                    s_keyword = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As COUNTRY_OF_BIRTHSearchDataProvider)
'End Record COUNTRY_OF_BIRTHSearch Item Class

'Record COUNTRY_OF_BIRTHSearch Item Class tail @2-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record COUNTRY_OF_BIRTHSearch Item Class tail

'Record COUNTRY_OF_BIRTHSearch Data Provider Class @2-D5F96302
Public Class COUNTRY_OF_BIRTHSearchDataProvider
Inherits RecordDataProviderBase
'End Record COUNTRY_OF_BIRTHSearch Data Provider Class

'Record COUNTRY_OF_BIRTHSearch Data Provider Class Variables @2-34AF14E8
    Protected item As COUNTRY_OF_BIRTHSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record COUNTRY_OF_BIRTHSearch Data Provider Class Variables

'Record COUNTRY_OF_BIRTHSearch Data Provider Class GetResultSet Method @2-0503932B

    Public Sub FillItem(ByVal item As COUNTRY_OF_BIRTHSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim tableIndex As Integer = 0
'End Record COUNTRY_OF_BIRTHSearch Data Provider Class GetResultSet Method

'Record COUNTRY_OF_BIRTHSearch BeforeBuildSelect @2-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record COUNTRY_OF_BIRTHSearch BeforeBuildSelect

'Record COUNTRY_OF_BIRTHSearch AfterExecuteSelect @2-79426A21
        End If
            IsInsertMode = True
'End Record COUNTRY_OF_BIRTHSearch AfterExecuteSelect

'Record COUNTRY_OF_BIRTHSearch AfterExecuteSelect tail @2-E31F8E2A
    End Sub
'End Record COUNTRY_OF_BIRTHSearch AfterExecuteSelect tail

'Record COUNTRY_OF_BIRTHSearch Data Provider Class @2-A61BA892
End Class

'End Record COUNTRY_OF_BIRTHSearch Data Provider Class

'Grid COUNTRY_OF_BIRTH Item Class @5-10C914DC
Public Class COUNTRY_OF_BIRTHItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public COUNTRY_OF_BIRTH_Insert As TextField
    Public COUNTRY_OF_BIRTH_InsertHref As Object
    Public COUNTRY_OF_BIRTH_InsertHrefParameters As LinkParameterCollection
    Public COUNTRY_ID As IntegerField
    Public COUNTRY_IDHref As Object
    Public COUNTRY_IDHrefParameters As LinkParameterCollection
    Public COUNTRY_NAME As TextField
    Public LAST_ALTERED_BY As TextField
    Public LAST_ALTERED_DATE As DateField
    Public Alt_COUNTRY_ID As IntegerField
    Public Alt_COUNTRY_IDHref As Object
    Public Alt_COUNTRY_IDHrefParameters As LinkParameterCollection
    Public Alt_COUNTRY_NAME As TextField
    Public Alt_LAST_ALTERED_BY As TextField
    Public Alt_LAST_ALTERED_DATE As DateField
    Public Sub New()
    COUNTRY_OF_BIRTH_Insert = New TextField("",Nothing)
    COUNTRY_OF_BIRTH_InsertHrefParameters = New LinkParameterCollection()
    COUNTRY_ID = New IntegerField("",Nothing)
    COUNTRY_IDHrefParameters = New LinkParameterCollection()
    COUNTRY_NAME = New TextField("", Nothing)
    LAST_ALTERED_BY = New TextField("", Nothing)
    LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    Alt_COUNTRY_ID = New IntegerField("",Nothing)
    Alt_COUNTRY_IDHrefParameters = New LinkParameterCollection()
    Alt_COUNTRY_NAME = New TextField("", Nothing)
    Alt_LAST_ALTERED_BY = New TextField("", Nothing)
    Alt_LAST_ALTERED_DATE = New DateField(Settings.DateFormat, Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "COUNTRY_OF_BIRTH_Insert"
                    Return Me.COUNTRY_OF_BIRTH_Insert
                Case "COUNTRY_ID"
                    Return Me.COUNTRY_ID
                Case "COUNTRY_NAME"
                    Return Me.COUNTRY_NAME
                Case "LAST_ALTERED_BY"
                    Return Me.LAST_ALTERED_BY
                Case "LAST_ALTERED_DATE"
                    Return Me.LAST_ALTERED_DATE
                Case "Alt_COUNTRY_ID"
                    Return Me.Alt_COUNTRY_ID
                Case "Alt_COUNTRY_NAME"
                    Return Me.Alt_COUNTRY_NAME
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
                Case "COUNTRY_OF_BIRTH_Insert"
                    Me.COUNTRY_OF_BIRTH_Insert = CType(Value,TextField)
                Case "COUNTRY_ID"
                    Me.COUNTRY_ID = CType(Value,IntegerField)
                Case "COUNTRY_NAME"
                    Me.COUNTRY_NAME = CType(Value,TextField)
                Case "LAST_ALTERED_BY"
                    Me.LAST_ALTERED_BY = CType(Value,TextField)
                Case "LAST_ALTERED_DATE"
                    Me.LAST_ALTERED_DATE = CType(Value,DateField)
                Case "Alt_COUNTRY_ID"
                    Me.Alt_COUNTRY_ID = CType(Value,IntegerField)
                Case "Alt_COUNTRY_NAME"
                    Me.Alt_COUNTRY_NAME = CType(Value,TextField)
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
'End Grid COUNTRY_OF_BIRTH Item Class

'Grid COUNTRY_OF_BIRTH Data Provider Class Header @5-9D805EDA
Public Class COUNTRY_OF_BIRTHDataProvider
Inherits GridDataProviderBase
'End Grid COUNTRY_OF_BIRTH Data Provider Class Header

'Grid COUNTRY_OF_BIRTH Data Provider Class Variables @5-75DCEE72

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_COUNTRY_ID
        Sorter_COUNTRY_NAME
        Sorter_LAST_ALTERED_BY
        Sorter_LAST_ALTERED_DATE
    End Enum

    Private SortFieldsNames As String() = New String() {"COUNTRY_NAME","COUNTRY_ID","COUNTRY_NAME","LAST_ALTERED_BY","LAST_ALTERED_DATE"}
    Private SortFieldsNamesDesc As String() = New string() {"COUNTRY_NAME","COUNTRY_ID DESC","COUNTRY_NAME DESC","LAST_ALTERED_BY DESC","LAST_ALTERED_DATE DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 20
    Public PageNumber As Integer = 1
    Public Urls_keyword  As TextParameter
'End Grid COUNTRY_OF_BIRTH Data Provider Class Variables

'Grid COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method @5-DBAC987E

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} COUNTRY_ID, COUNTRY_NAME, LAST_ALTERED_BY, " & vbCrLf & _
          "LAST_ALTERED_DATE " & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH {SQL_Where} {SQL_OrderBy}", New String(){"s_keyword8"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM COUNTRY_OF_BIRTH", New String(){"s_keyword8"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method

'Grid COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method @5-3CC00B0D
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As COUNTRY_OF_BIRTHItem()
'End Grid COUNTRY_OF_BIRTH Data Provider Class GetResultSet Method

'Before build Select @5-73E6EA29
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_keyword8",Urls_keyword, "","COUNTRY_NAME",Condition.Contains,False)
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @5-4E55B639
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As COUNTRY_OF_BIRTHItem
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

'After execute Select @5-C3FF4E4C
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New COUNTRY_OF_BIRTHItem(dr.Count-1) {}
'End After execute Select

'After execute Select @5-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @5-0320466D
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as COUNTRY_OF_BIRTHItem = New COUNTRY_OF_BIRTHItem()
                item.COUNTRY_OF_BIRTH_InsertHref = "COUNTRY_OF_BIRT_maint.aspx"
                item.COUNTRY_ID.SetValue(dr(i)("COUNTRY_ID"),"")
                item.COUNTRY_IDHref = "COUNTRY_OF_BIRT_maint.aspx"
                item.COUNTRY_IDHrefParameters.Add("COUNTRY_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COUNTRY_ID").ToString()))
                item.COUNTRY_NAME.SetValue(dr(i)("COUNTRY_NAME"),"")
                item.LAST_ALTERED_BY.SetValue(dr(i)("LAST_ALTERED_BY"),"")
                item.LAST_ALTERED_DATE.SetValue(dr(i)("LAST_ALTERED_DATE"),Select_.DateFormat)
                item.Alt_COUNTRY_ID.SetValue(dr(i)("COUNTRY_ID"),"")
                item.Alt_COUNTRY_IDHref = "COUNTRY_OF_BIRT_maint.aspx"
                item.Alt_COUNTRY_IDHrefParameters.Add("COUNTRY_ID",System.Web.HttpUtility.UrlEncode(dr(i)("COUNTRY_ID").ToString()))
                item.Alt_COUNTRY_NAME.SetValue(dr(i)("COUNTRY_NAME"),"")
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

'Grid Data Provider tail @5-A61BA892
End Class
'End Grid Data Provider tail

'Page Data Provider Tail 2 @1-5EA2E2E0
End Namespace
'End Page Data Provider Tail 2

