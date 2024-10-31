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

Namespace DECV_PROD2007.popup_SchoolList 'Namespace @1-7596C9DF

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

'Record SUBJECTSearch Item Class @10-CC90E7E3
Public Class SUBJECTSearchItem
    Private _isNew As Boolean = True
    Private _isDeleted As Boolean = False
    Private rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public errors As NameValueCollection = New NameValueCollection()

    Public s_SEARCH_ALPHA As TextField
    Public s_SEARCH_ALPHAItems As ItemCollection
    Public Sub New()
    s_SEARCH_ALPHA = New TextField("", Nothing)
    s_SEARCH_ALPHAItems = New ItemCollection()
    End Sub

    Public Shared Function CreateFromHttpRequest() As SUBJECTSearchItem
        Dim item As SUBJECTSearchItem = New SUBJECTSearchItem()
        If Not IsNothing(DBUtility.GetInitialValue("s_SEARCH_ALPHA")) Then
        item.s_SEARCH_ALPHA.SetValue(DBUtility.GetInitialValue("s_SEARCH_ALPHA"))
        End If 
        If Not IsNothing(DBUtility.GetInitialValue("Button_DoSearch")) Then
        End If 
        Return item
    End Function

    Default Public Property Field(fieldName As String) As FieldBase
        Get
            Select fieldName
                Case "s_SEARCH_ALPHA"
                    Return s_SEARCH_ALPHA
                Case Else
                    Throw (New ArgumentOutOfRangeException())
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "s_SEARCH_ALPHA"
                    s_SEARCH_ALPHA = CType(value, TextField)
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

    Public Sub Validate(ByVal provider As SUBJECTSearchDataProvider)
'End Record SUBJECTSearch Item Class

's_SEARCH_ALPHA validate @12-D7B77AD5
        If IsNothing(s_SEARCH_ALPHA.Value) OrElse s_SEARCH_ALPHA.Value.ToString() ="" Then
            errors.Add("s_SEARCH_ALPHA",String.Format(Resources.strings.CCS_RequiredField,"Filter School Name"))
        End If
'End s_SEARCH_ALPHA validate

'Record SUBJECTSearch Item Class tail @10-C0ED3BDF
    End Sub
    Public RawData As DataRow = Nothing
End Class
'End Record SUBJECTSearch Item Class tail

'Record SUBJECTSearch Data Provider Class @10-A1051136
Public Class SUBJECTSearchDataProvider
Inherits RecordDataProviderBase
'End Record SUBJECTSearch Data Provider Class

'Record SUBJECTSearch Data Provider Class Variables @10-F4199C7D
    Protected item As SUBJECTSearchItem
    Protected rm As System.Resources.ResourceManager =  DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
'End Record SUBJECTSearch Data Provider Class Variables

'Record SUBJECTSearch Data Provider Class GetResultSet Method @10-B9833B10

    Public Sub FillItem(ByVal item As SUBJECTSearchItem, ByRef IsInsertMode As Boolean)
        Dim ReadNotAllowed As Boolean = IsInsertMode
        Dim E As Exception = Nothing
        Dim tableIndex As Integer = 0
'End Record SUBJECTSearch Data Provider Class GetResultSet Method

'Record SUBJECTSearch BeforeBuildSelect @10-5BE29CB0
        Dim ds As DataSet = Nothing
        Dim dr As DataRowCollection = Nothing
        If Not IsInsertMode Then
'End Record SUBJECTSearch BeforeBuildSelect

'Record SUBJECTSearch AfterExecuteSelect @10-79426A21
        End If
            IsInsertMode = True
'End Record SUBJECTSearch AfterExecuteSelect

'ListBox s_SEARCH_ALPHA AfterExecuteSelect @12-FF11826A
        
item.s_SEARCH_ALPHAItems.Add("A","A")
item.s_SEARCH_ALPHAItems.Add("B","B")
item.s_SEARCH_ALPHAItems.Add("C","C")
item.s_SEARCH_ALPHAItems.Add("D","D")
item.s_SEARCH_ALPHAItems.Add("E","E")
item.s_SEARCH_ALPHAItems.Add("F","F")
item.s_SEARCH_ALPHAItems.Add("G","G")
item.s_SEARCH_ALPHAItems.Add("H","H")
item.s_SEARCH_ALPHAItems.Add("I","I")
item.s_SEARCH_ALPHAItems.Add("J","J")
item.s_SEARCH_ALPHAItems.Add("K","K")
item.s_SEARCH_ALPHAItems.Add("L","L")
item.s_SEARCH_ALPHAItems.Add("M","M")
item.s_SEARCH_ALPHAItems.Add("N","N")
item.s_SEARCH_ALPHAItems.Add("O","O")
item.s_SEARCH_ALPHAItems.Add("P","P")
item.s_SEARCH_ALPHAItems.Add("Q","Q")
item.s_SEARCH_ALPHAItems.Add("R","R")
item.s_SEARCH_ALPHAItems.Add("S","S")
item.s_SEARCH_ALPHAItems.Add("T","T")
item.s_SEARCH_ALPHAItems.Add("U","U")
item.s_SEARCH_ALPHAItems.Add("V","V")
item.s_SEARCH_ALPHAItems.Add("W","W")
item.s_SEARCH_ALPHAItems.Add("X","X")
item.s_SEARCH_ALPHAItems.Add("Y","Y")
item.s_SEARCH_ALPHAItems.Add("Z","Z")
'End ListBox s_SEARCH_ALPHA AfterExecuteSelect

'Record SUBJECTSearch AfterExecuteSelect tail @10-E31F8E2A
    End Sub
'End Record SUBJECTSearch AfterExecuteSelect tail

'Record SUBJECTSearch Data Provider Class @10-A61BA892
End Class

'End Record SUBJECTSearch Data Provider Class

'Grid SCHOOL Item Class @2-2A5C8753
Public Class SCHOOLItem 
Implements IDataItem
    Public errors As NameValueCollection = New NameValueCollection()
    Protected rm As System.Resources.ResourceManager = CType(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public SCHOOL_ID As FloatField
    Public SCHOOL_IDHref As Object
    Public SCHOOL_IDHrefParameters As LinkParameterCollection
    Public SCHOOL_TITLE As TextField
    Public Sub New()
    SCHOOL_ID = New FloatField("0.00",Nothing)
    SCHOOL_IDHrefParameters = New LinkParameterCollection()
    SCHOOL_TITLE = New TextField("", Nothing)
    End Sub
    Public Default Property Field(ByVal fieldName As String) as FieldBase Implements _
        IDataItem.Field
        Get
            Select fieldName
                Case "SCHOOL_ID"
                    Return Me.SCHOOL_ID
                Case "SCHOOL_TITLE"
                    Return Me.SCHOOL_TITLE
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Get
        Set (ByVal Value As FieldBase)
            Select fieldName
                Case "SCHOOL_ID"
                    Me.SCHOOL_ID = CType(Value,FloatField)
                Case "SCHOOL_TITLE"
                    Me.SCHOOL_TITLE = CType(Value,TextField)
                Case Else
                    Throw New ArgumentOutOfRangeException()
            End Select
        End Set
    End Property

    Public RawData As DataRow = Nothing
End Class
'End Grid SCHOOL Item Class

'Grid SCHOOL Data Provider Class Header @2-AED79F2B
Public Class SCHOOLDataProvider
Inherits GridDataProviderBase
'End Grid SCHOOL Data Provider Class Header

'Grid SCHOOL Data Provider Class Variables @2-AD04C7ED

    Protected rm As System.Resources.ResourceManager = DirectCast(System.Web.HttpContext.Current.Application("rm"),System.Resources.ResourceManager)
    Public Enum SortFields
        _Default
        Sorter_SUBJECT_ID
        Sorter_SUBJECT_TITLE
    End Enum

    Private SortFieldsNames As String() = New String() {"SCHOOL_NAME","SCHOOL_ID","SCHOOL_NAME"}
    Private SortFieldsNamesDesc As String() = New string() {"SCHOOL_NAME","SCHOOL_ID DESC","SCHOOL_NAME DESC"}
    Public SortField As SortFields = SortFields._Default
    Public SortDir As SortDirections = SortDirections._Asc
    Public RecordsPerPage As Integer = 50
    Public PageNumber As Integer = 1
    Public Urls_SEARCH_ALPHA  As TextParameter
'End Grid SCHOOL Data Provider Class Variables

'Grid SCHOOL Data Provider Class GetResultSet Method @2-610E6DA9

    Public Sub New()
        Select_=new TableCommand("SELECT TOP {SqlParam_endRecord} SCHOOL_ID, " & vbCrLf & _
          "rtrim(SCHOOL_NAME) AS SCHOOL_NAME " & vbCrLf & _
          "FROM SCHOOL {SQL_Where} {SQL_OrderBy}", New String(){"expr36","And","s_SEARCH_ALPHA37","And","expr38"},Settings.connDECVPRODSQL2005DataAccessObject )
        Count=new TableCommand("SELECT COUNT(*)" & vbCrLf & _
          "FROM SCHOOL", New String(){"expr36","And","s_SEARCH_ALPHA37","And","expr38"},Settings.connDECVPRODSQL2005DataAccessObject , true)
    End Sub
'End Grid SCHOOL Data Provider Class GetResultSet Method

'Grid SCHOOL Data Provider Class GetResultSet Method @2-87B1CE2C
    Public Function GetResultSet(ByRef _PagesCount As Integer, ops As FormSupportedOperations) As SCHOOLItem()
'End Grid SCHOOL Data Provider Class GetResultSet Method

'Before build Select @2-C625DDB2
        Dim E as Exception = Nothing
        Select_.Parameters.Clear()
        CType(Select_,TableCommand).AddParameter("s_SEARCH_ALPHA37",Urls_SEARCH_ALPHA, "","SCHOOL_NAME",Condition.BeginsWith,True)
        Select_.Parameters.Add("expr36","(STATUS = 1)")
        Select_.Parameters.Add("expr38","(SCHOOL_TYPE_CODE NOT IN ('X'))")
        Count.Parameters = Select_.Parameters
        If SortDir = SortDirections._Asc Then
            Select_.OrderBy=SortFieldsNames(CInt(SortField)).Trim()
        Else
            Select_.OrderBy=SortFieldsNamesDesc(CInt(SortField)).Trim()
        End If
        Dim tableIndex As Integer = 0
'End Before build Select

'Execute Select @2-B3CC5F90
        Dim ds As DataSet = Nothing
        _PagesCount=0
        Dim result(-1) As SCHOOLItem
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

'After execute Select @2-573BD7AF
                If Not IsNothing(E) Then Throw E
            End Try
            Dim dr As DataRowCollection = ds.Tables(tableIndex).Rows
            result = New SCHOOLItem(dr.Count-1) {}
'End After execute Select

'After execute Select @2-79D6687E
            Dim j As Integer
'End After execute Select

'After execute Select tail @2-17661043
            Dim i as Integer
            For i = 0 To dr.Count - 1
                Dim item as SCHOOLItem = New SCHOOLItem()
                item.SCHOOL_ID.SetValue(dr(i)("SCHOOL_ID"),"")
                item.SCHOOL_IDHref = ""
                item.SCHOOL_TITLE.SetValue(dr(i)("SCHOOL_NAME"),"")
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

